Public Class GestionApproFact

    Private Const NCompteRED As String = "70748000"
    Private Const NActiRED As String = "0000"

#Region "Import des produits"
    Public Shared Sub Importer(ByVal chemin As String, Optional ByVal defaultInactif As Boolean = True)
        If Not IO.File.Exists(chemin) Then
            Throw New ApplicationException("Fichier introuvable")
        End If

        'Charger le fichier CSV
        Dim frp As FrProgressBar
        Dim reader As New CsvFileReader(chemin)
        Dim cntLine As Integer = reader.CountLines

        Try
            Cursor.Current = Cursors.WaitCursor
            reader.Open(1)

            'Demander son Bassin Versant à l'utilisateur
            Dim bassins As New Collections.Specialized.StringCollection

            For Each fld As String In reader.FieldNames
                If fld.StartsWith("TAX-") Then
                    bassins.Add(fld.Replace("TAX-", ""))
                End If
            Next

            Dim colTax As String = Choix(bassins, "Sélectionnez le code de votre bassin versant.")

            If colTax Is Nothing Then Throw New ApplicationException("Import annulé.")

            colTax = "TAX-" & colTax

            Dim cntAddProduits As Integer = 0
            Dim cntUpdproduits As Integer = 0

            'Pour chaque ligne
            frp = InitProgressBar(cntLine, "Lecture du fichier en cours")

            Dim ApproFactDS As New ApproFactDataSet
            Dim listeEANEnErreur As New List(Of String)

            Using FamilleTA As New ApproFactDataSetTableAdapters.FamilleTableAdapter
                Using ProduitTA As New ApproFactDataSetTableAdapters.ProduitTableAdapter
                    With ApproFactDS.Tables("Produit").Columns("nProduit")
                        .AutoIncrement = True
                        .AutoIncrementSeed = CLng(ProduitTA.GetMaxnProduit().GetValueOrDefault()) + 1
                        .AutoIncrementStep = 1
                    End With

                    ApproFactDS.Tables("Produit").Columns("IsEnVente").DefaultValue = True
                    ApproFactDS.Tables("Produit").Columns("SeuilStock").DefaultValue = 0
                    ApproFactDS.Tables("Produit").Columns("IsAMM").DefaultValue = True
                    ApproFactDS.Tables("Produit").Columns("GestionStock").DefaultValue = True
                    ApproFactDS.Tables("Produit").Columns("DecompteAuto").DefaultValue = False

                    'chargement des familles
                    FamilleTA.Fill(ApproFactDS.Famille)

                    'Chargement des produits
                    ProduitTA.Fill(ApproFactDS.Produit)

                    While reader.ReadLine
                        Select Case reader.Field("TYP_LIG")
                            Case "TAX-AMM"
                                'Pas importé
                            Case "TAX-SUB-AMM"
                                'Pas importé
                            Case "TAX-UC"
                                'On importe que les lignes UC_TYP = UC
                                Dim uc_typ As String = reader.Field("UC_TYP")

                                If (uc_typ <> "UC") Then
                                    Continue While
                                End If

                                'Créer les produits à la vente, à retrouver par EAN
                                Dim ean As String = reader.Field("UC_EAN_UC").Replace("'", "")

                                'Vérifie que le nombre de positions de l'EAN n'est pas supérieur à 13
                                If (ean.Length > 13) Then
                                    If Not (listeEANEnErreur.Contains(ean)) Then
                                        listeEANEnErreur.Add(ean)

                                        Continue While
                                    End If
                                End If

                                Dim amm As String = reader.Field("ETI_AMM")
                                Dim ProduitDR As ApproFactDataSet.ProduitRow = GestionApproFact.FindProduitByEAN(ApproFactDS, ean)

                                If (ProduitDR Is Nothing) Then
                                    'Création d'un produit UC
                                    ProduitDR = ApproFactDS.Produit.NewProduitRow

                                    With ProduitDR
                                        .CodeProduit = Convert.ToString(.Item("nProduit"))
                                        .Libelle = reader.Field("NOM_COM")
                                        .Unite1 = Left(reader.Field("UC_TYP"), 2)
                                        .TypeFacturation = "U1"
                                        .Famille1 = GetFamille(ApproFactDS, "UC")
                                        If reader.Field("UC_UNIT_VENDU").Length > 0 Then
                                            .Unite2 = Left(reader.Field("UC_UNIT_VENDU"), 2)
                                            .CoefU2 = CInt(reader.Field("UC_VENDU"))
                                        End If
                                        .CodeBarre = ean
                                        .IsPrixHT = True
                                        .ProduitAchat = True
                                        .ProduitVente = True
                                        .ProduitCompose = False
                                        .Inactif = defaultInactif
                                        .IsSortieImpr = True
                                        .IsAMM = True
                                        .AMM = amm
                                        .TAXSM = DecimalParse(reader.Field(colTax))
                                        .DateMaj = Today
                                    End With

                                    ApproFactDS.Produit.AddProduitRow(ProduitDR)

                                    cntAddProduits += 1
                                Else
                                    'Mise à jour
                                    With ProduitDR
                                        .Libelle = reader.Field("NOM_COM")
                                        .Unite1 = Left(reader.Field("UC_TYP"), 2)
                                        .TypeFacturation = "U1"
                                        .Famille1 = GetFamille(ApproFactDS, "UC")
                                        If reader.Field("UC_UNIT_VENDU").Length > 0 Then
                                            .Unite2 = Left(reader.Field("UC_UNIT_VENDU"), 2)
                                            .CoefU2 = CInt(reader.Field("UC_VENDU"))
                                        End If
                                        .CodeBarre = ean
                                        .IsPrixHT = True
                                        .ProduitAchat = True
                                        .ProduitVente = True
                                        .ProduitCompose = False
                                        .Inactif = defaultInactif
                                        .IsSortieImpr = True
                                        .IsAMM = True
                                        .AMM = amm
                                        .TAXSM = DecimalParse(reader.Field(colTax))
                                        .DateMaj = Today
                                    End With

                                    cntUpdproduits += 1
                                End If
                            Case "TAX-SUB-UC"
                                'Pas importé
                        End Select

                        frp.Value += 1
                    End While

                    'MAJ de la base SQL
                    frp.Text = "Ecriture des données"
                    frp.Value = frp.Maximum

                    'Mise à jour de la table Famille
                    FamilleTA.Update(ApproFactDS.Famille)

                    'Mise à jour de la table Produit
                    ProduitTA.Update(ApproFactDS.Produit)
                End Using
            End Using

            frp.Close()
            frp = Nothing

            Dim msg As String = String.Format("Import terminé : " & vbCrLf & _
                                            "    produits : {0} créés, {1} mis à jour" & vbCrLf & _
                                            "    EAN non conforme non importé(s): {2}", cntAddProduits, cntUpdproduits, String.Join(",", listeEANEnErreur.ToArray()))

            MsgBox(msg, MsgBoxStyle.Information)
        Finally
            If Not frp Is Nothing Then frp.Close()
            reader.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'Public Shared Sub Importer(ByVal ds As DataSet, ByVal chemin As String, Optional ByVal AjouterInexistant As Boolean = False, Optional ByVal defaultInactif As Boolean = True, Optional ByVal importUc As Boolean = True)
    '    If Not IO.File.Exists(chemin) Then
    '        Throw New ApplicationException("Fichier introuvable")
    '    End If
    '    'Charger le fichier CSV
    '    Dim frp As FrProgressBar
    '    Dim reader As New CsvFileReader(chemin)
    '    Dim cntLine As Integer = reader.CountLines
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        reader.Open(1)
    '        'Demander son Bassin Versant à l'utilisateur
    '        Dim bassins As New Collections.Specialized.StringCollection
    '        For Each fld As String In reader.FieldNames
    '            If fld.StartsWith("TAX-") Then
    '                bassins.Add(fld.Replace("TAX-", ""))
    '            End If
    '        Next
    '        Dim colTax As String = Choix(bassins, "Sélectionnez le code de votre bassin versant.")
    '        If colTax Is Nothing Then Throw New ApplicationException("Import annulé.")
    '        colTax = "TAX-" & colTax
    '        Dim cntAddAMM As Integer = 0
    '        Dim cntUpdAMM As Integer = 0
    '        Dim cntAddUC As Integer = 0
    '        Dim cntUpdUC As Integer = 0

    '        'Pour chaque ligne
    '        frp = InitProgressBar(cntLine, "Lecture du fichier en cours")

    '        While reader.ReadLine
    '            Select Case reader.Field("TYP_LIG")
    '                Case "TAX-AMM"
    '                    'Gestion des produits de base => leur donner l'AMM et les marquer comme produit de base

    '                    'chercher le produit dans DS qui correspond à l'AMM
    '                    Dim amm As String = reader.Field("ETI_AMM")
    '                    Dim dr As DataRow = FindProduitByAMM(ds, amm)
    '                    If dr Is Nothing And AjouterInexistant Then
    '                        'Création d'un produit AMM
    '                        dr = ds.Tables("Produit").NewRow
    '                        With dr
    '                            .Item("CodeProduit") = Convert.ToString(.Item("nProduit"))
    '                            .Item("Libelle") = reader.Field("NOM_COM")
    '                            .Item("Unite1") = Left(reader.Field("UC_UNIT_VENDU"), 2)
    '                            .Item("TypeFacturation") = "U1"
    '                            .Item("Famille1") = GetFamille(ds, "AMM")
    '                            .Item("IsPrixHT") = True
    '                            .Item("ProduitAchat") = True
    '                            .Item("ProduitVente") = True
    '                            .Item("IsSortieImpr") = True
    '                            .Item("ProduitCompose") = False
    '                            .Item("Inactif") = defaultInactif
    '                            .Item("IsAMM") = True
    '                            .Item("AMM") = amm
    '                            .Item("TAXSM") = DecimalParse(reader.Field(colTax))
    '                            .Item("DateMaj") = Today
    '                        End With
    '                        ds.Tables("Produit").Rows.Add(dr)
    '                        cntAddAMM += 1
    '                    Else
    '                        dr("TAXSM") = DecimalParse(reader.Field(colTax))
    '                        dr("DateMaj") = Today
    '                        cntUpdAMM += 1
    '                    End If

    '                    'TODO Création du fournisseur ?
    '                Case "TAX-SUB-AMM"
    '                    'Pas importé
    '                Case "TAX-UC"
    '                    If importUc Then
    '                        'Créer les produits à la vente, a retrouver par EAN
    '                        Dim ean As String = reader.Field("UC_EAN_UC").Replace("'", "")
    '                        Dim dr As DataRow = FindProduitByEAN(ds, ean)
    '                        If dr Is Nothing Then
    '                            'Création d'un produit UC
    '                            dr = ds.Tables("Produit").NewRow
    '                            With dr
    '                                .Item("CodeProduit") = Convert.ToString(.Item("nProduit"))
    '                                .Item("Libelle") = reader.Field("NOM_COM")
    '                                .Item("Unite1") = Left(reader.Field("UC_TYP"), 2)
    '                                .Item("TypeFacturation") = "U1"
    '                                .Item("Famille1") = GetFamille(ds, "UC")
    '                                If reader.Field("UC_UNIT_VENDU").Length > 0 Then
    '                                    .Item("Unite2") = Left(reader.Field("UC_UNIT_VENDU"), 2)
    '                                    .Item("CoefU2") = CInt(reader.Field("UC_VENDU"))
    '                                End If
    '                                .Item("CodeBarre") = ean
    '                                .Item("IsPrixHT") = True
    '                                .Item("ProduitAchat") = True
    '                                .Item("ProduitVente") = True
    '                                .Item("ProduitCompose") = True
    '                                .Item("Inactif") = defaultInactif
    '                                .Item("IsSortieImpr") = True

    '                            End With
    '                            ds.Tables("Produit").Rows.Add(dr)
    '                            cntAddUC += 1
    '                        Else
    '                            'Mise à jour => Refaire la composition
    '                            With dr
    '                                .Item("Libelle") = reader.Field("NOM_COM")
    '                                .Item("Unite1") = Left(reader.Field("UC_TYP"), 2)
    '                                If reader.Field("UC_UNIT_VENDU").Length > 0 Then
    '                                    .Item("Unite2") = Left(reader.Field("UC_UNIT_VENDU"), 2)
    '                                    .Item("CoefU2") = CInt(reader.Field("UC_VENDU"))
    '                                End If
    '                            End With
    '                            EffacerComposition(dr)
    '                            cntUpdUC += 1
    '                        End If

    '                        'Mettre dans la composition les produits AMM
    '                        Dim amm As String = reader.Field("ETI_AMM").Trim
    '                        If amm.Length > 0 Then
    '                            Dim drAMM As DataRow = FindProduitByAMM(ds, amm)
    '                            If Not drAMM Is Nothing Then
    '                                Dim qte As Decimal = DecimalParse(reader.Field("UC_VENDU"))
    '                                AjouterProduitComposition(dr, drAMM, qte)
    '                            End If
    '                        End If
    '                    End If
    '                Case "TAX-SUB-UC"
    '                    If importUc Then
    '                        'Composition d'une UC (à retrouver par l'EAN)
    '                        Dim ean As String = reader.Field("UC_EAN_UC").Replace("'", "")
    '                        Dim dr As DataRow = FindProduitByEAN(ds, ean)
    '                        If Not dr Is Nothing Then
    '                            Dim amm As String = reader.Field("ETI_AMM").Trim
    '                            If amm.Length > 0 Then
    '                                Dim drAMM As DataRow = FindProduitByAMM(ds, amm)
    '                                If Not drAMM Is Nothing Then
    '                                    Dim qte As Decimal = DecimalParse(reader.Field("UC_VENDU"))
    '                                    AjouterProduitComposition(dr, drAMM, qte)
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '            End Select
    '            frp.Value += 1
    '        End While
    '        'MAJ de la base SQL
    '        frp.Text = "Ecriture des données"
    '        frp.Value = frp.Maximum
    '        Using s As New SqlProxy
    '            s.UpdateTable(ds, "Produit")
    '        End Using
    '        frp.Close()
    '        frp = Nothing

    '        Dim msg As String = String.Format("Import terminé : " & vbCrLf & _
    '                                        "    AMM : {0} créés, {1} mis à jour" & vbCrLf & _
    '                                        "    UC : {2} créés, {3} mis à jour", cntAddAMM, cntUpdAMM, cntAddUC, cntUpdUC)
    '        MsgBox(msg, MsgBoxStyle.Information)
    '    Finally
    '        If Not frp Is Nothing Then frp.Close()
    '        reader.Close()
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

    Private Shared Function GetFamille(ByVal ds As DataSet, ByVal famille As String) As Integer
        Dim rws() As DataRow = ds.Tables("FAMILLE").Select(String.Format("Famille='{0}'", famille))
        If rws.Length = 0 Then
            With ds.Tables("Famille")
                Dim nFamilleDep As Integer = 1
                Dim Obj As Object = .Compute("Max(nFamille)", "")
                If Not IsDBNull(Obj) Then nFamilleDep = CInt(Obj) + 1

                With .Columns("nFamille")
                    .AutoIncrement = True
                    .AutoIncrementSeed = nFamilleDep
                    .AutoIncrementStep = 1
                End With

                Dim dr As DataRow = .NewRow
                dr.Item("Famille") = famille
                .Rows.Add(dr)
                Return CInt(dr.Item("nFamille"))
            End With
        Else
            Return CInt(rws(0).Item("nFamille"))
        End If
    End Function

    Private Shared Function GetFamille(ByVal ApproFactDS As ApproFactDataSet, ByVal famille As String) As Short
        Dim FamilleDR() As ApproFactDataSet.FamilleRow = CType(ApproFactDS.Famille.Select(String.Format("Famille='{0}'", famille)), ApproFactDataSet.FamilleRow())

        If (FamilleDR.Length = 0) Then
            With ApproFactDS.Famille
                Dim nFamilleDep As Integer = 1
                Dim Obj As Object = .Compute("Max(nFamille)", "")
                If Not IsDBNull(Obj) Then nFamilleDep = CInt(Obj) + 1

                With .Columns("nFamille")
                    .AutoIncrement = True
                    .AutoIncrementSeed = nFamilleDep
                    .AutoIncrementStep = 1
                End With

                Dim newFamilleDR As ApproFactDataSet.FamilleRow = .NewFamilleRow

                newFamilleDR.Famille = famille

                .Rows.Add(newFamilleDR)

                Return CShort(newFamilleDR.nFamille)
            End With
        Else
            Return CShort(FamilleDR(0).nFamille)
        End If
    End Function

    Private Shared Sub AjouterProduitComposition(ByVal drPere As DataRow, ByVal drFils As DataRow, ByVal qte As Decimal)
        Dim dtComp As DataTable = drPere.Table.DataSet.Tables("CompositionProduit")
        Dim drComp As DataRow = FindRow(drPere.Table.DataSet, "CompositionProduit", String.Format("CodeProduit='{0}' AND CodeProduitComposition='{1}'", Convert.ToString(drPere("CodeProduit")).Replace("'", "''"), Convert.ToString(drFils("CodeProduit")).Replace("'", "''")))
        If Not drComp Is Nothing Then
            With drComp
                .Item("Libelle") = Left(Convert.ToString(drFils.Item("Libelle")), 50)
                .Item("LibUnite1") = drFils.Item("Unite1")
                .Item("LibUnite2") = drFils.Item("Unite2")
                .Item("Unite1") = qte
            End With
        Else
            drComp = dtComp.NewRow
            With drComp
                .Item("CodeProduit") = drPere.Item("CodeProduit")
                .Item("CodeProduitComposition") = drFils.Item("CodeProduit")
                .Item("Libelle") = Left(Convert.ToString(drFils.Item("Libelle")), 50)
                .Item("LibUnite1") = drFils.Item("Unite1")
                .Item("LibUnite2") = drFils.Item("Unite2")
                .Item("Unite1") = qte
            End With
            dtComp.Rows.Add(drComp)
        End If
    End Sub

    Private Shared Sub EffacerComposition(ByVal drPere As DataRow)
        Dim rws() As DataRow = drPere.GetChildRows("ProduitCompositionProduit")
        For Each dr As DataRow In rws
            dr.Delete()
        Next
    End Sub

#Region "Utils"
    Private Shared Function DecimalParse(ByVal s As String, Optional ByVal defaultValue As Decimal = 0) As Decimal
        Try
            s = s.Replace("."c, Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            s = s.Replace(","c, Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            Return Decimal.Parse(s)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Private Shared Function FindProduitByAMM(ByVal ds As DataSet, ByVal amm As String) As DataRow
        Return FindProduitByCritere(ds, String.Format("AMM='{0}' AND IsAMM=True", amm))
    End Function

    Private Shared Function FindProduitByEAN(ByVal ds As DataSet, ByVal ean As String) As DataRow
        Return FindProduitByCritere(ds, String.Format("CodeBarre='{0}'", ean))
    End Function

    Private Shared Function FindProduitByEAN(ByVal ApproFactDS As ApproFactDataSet, ByVal ean As String) As ApproFactDataSet.ProduitRow
        Return FindProduitByCritere(ApproFactDS, String.Format("CodeBarre='{0}'", ean))
    End Function

    Private Shared Function FindProduitByCritere(ByVal ds As DataSet, ByVal critere As String) As DataRow
        Return FindRow(ds, "Produit", critere)
    End Function

    Private Shared Function FindProduitByCritere(ByVal ApproFactDS As ApproFactDataSet, ByVal critere As String) As ApproFactDataSet.ProduitRow
        Return FindRow(ApproFactDS, "Produit", critere)
    End Function

    Private Shared Function FindRow(ByVal ds As DataSet, ByVal table As String, ByVal critere As String) As DataRow
        Dim res As DataRow
        Dim rws() As DataRow = ds.Tables(table).Select(critere)
        If rws.Length > 0 Then
            res = rws(0)
        End If
        Return res
    End Function

    Private Shared Function FindRow(ByVal ApproFactDS As ApproFactDataSet, ByVal table As String, ByVal critere As String) As ApproFactDataSet.ProduitRow
        Dim res As ApproFactDataSet.ProduitRow
        Dim rws() As ApproFactDataSet.ProduitRow = CType(ApproFactDS.Tables(table).Select(critere), ApproFactDataSet.ProduitRow())

        If rws.Length > 0 Then
            res = rws(0)
        End If

        Return res
    End Function
#End Region

    Private Shared Function Choix(ByVal items As Collections.Specialized.StringCollection, ByVal title As String) As String
        Dim res As String
        Dim frSelection As New FrSelectionMultiple
        With frSelection
            .Text = title
            With .lstContents
                .SelectionMode = SelectionMode.One
                .Items.Clear()
                For Each s As String In items
                    .Items.Add(New FrSelectionMultiple.ListItem(NomBassin(s), s))
                Next
            End With
            If .ShowDialog = DialogResult.OK Then
                For Each item As FrSelectionMultiple.ListItem In .lstContents.SelectedItems
                    res = CStr(item.Value)
                    Exit For
                Next
            End If
        End With
        Application.DoEvents()
        Return res
    End Function

    Private Shared Function NomBassin(ByVal code As String) As String
        Select Case code
            Case "AG" : Return "Adour-Garonne"
            Case "AP" : Return "Artois-Picardie"
            Case "LB" : Return "Loire-Bretagne"
            Case "RM" : Return "Rhin-Meuse"
            Case "RMC" : Return "Rhône-Méditerrannée-Corse"
            Case "SM" : Return "Seine-Normandie"
            Case Else : Return code
        End Select
    End Function
#End Region

#Region "Génération des redevance"
    Public Shared Sub AddRecapRedevance(ByVal hash As Hashtable, ByVal codeproduit As String, ByVal unite1 As Object, ByVal unite2 As Object, ByVal TTVA As Object)
        'MODIF TV 14/09/2012
        'Chercher pour le code produit les sous-produits (niveau 1 ou 2) étant des AMM ainsi que leur quantité
        'Dim sql As String = String.Format("SELECT 1 as Unite1, 1 as Unite2, Libelle, Unite1 as LibUnite1,Unite2 as LibUnite2 ,AMM, TAXSM  " & _
        '                                "FROM Produit  " & _
        '                                "WHERE CodeProduit='{0}' AND IsAMM=1 " & _
        '                                "UNION SELECT cp.Unite1,cp.Unite2,cpp.Libelle,cpp.Unite1 as LibUnite1,cpp.Unite2 as LibUnite2, cpp.AMM,cpp.TAXSM " & _
        '                                "FROM CompositionProduit cp  " & _
        '                                "INNER JOIN Produit cpp ON cp.CodeProduitComposition = cpp.CodeProduit " & _
        '                                "WHERE cp.CodeProduit='{0}' AND cpp.IsAMM=1 " & _
        '                                "UNION SELECT cp.Unite1 * cpcp.Unite1,cp.Unite2 * cpcp.Unite2, " & _
        '                                "cpcpp.Libelle,cpcpp.Unite1 as LibUnite1,cpcpp.Unite2 as LibUnite2 ,cpcpp.AMM,cpcpp.TAXSM " & _
        '                                "FROM CompositionProduit cp  " & _
        '                                "INNER JOIN CompositionProduit cpcp ON cp.CodeProduitComposition = cpcp.CodeProduit " & _
        '                                "INNER JOIN Produit cpcpp ON cpcp.CodeProduitComposition = cpcpp.CodeProduit " & _
        '                                "WHERE cp.CodeProduit='{0}' AND cpcpp.IsAMM=1", codeproduit.Replace("'", "''"))

        'Dim sql As String = String.Format("SELECT 1 as Unite1, 1 as Unite2, Libelle, Unite1 as LibUnite1,Unite2 as LibUnite2 ,AMM, TAXSM  " & _
        '                                "FROM Produit  " & _
        '                                "WHERE CodeProduit='{0}' AND IsAMM=1 ", codeproduit.Replace("'", "''"))

        'Vérifie si le produit est composé
        Dim sql As String = String.Empty
        Dim dt As DataTable

        sql = String.Format("SELECT CodeProduit FROM Produit WHERE CodeProduit = '{0}' AND ProduitCompose = 1", codeproduit.Replace("'", "''"))

        Using s As New SqlProxy
            dt = s.ExecuteDataTable(sql)
        End Using

        'Si le produit n'est pas composé, on récupère les infos redevance contenues dans la fiche produit 
        If (dt.Rows.Count = 0) Then
            sql = String.Format("SELECT 1 as Unite1, 1 as Unite2, Libelle, Unite1 as LibUnite1,Unite2 as LibUnite2 ,AMM, TAXSM  " & _
                                "FROM Produit  " & _
                                "WHERE CodeProduit='{0}' AND IsAMM=1 ", codeproduit.Replace("'", "''"))
        Else 'Sinon on récupère les infos dans les fiches des produits de composition
            sql = String.Format("SELECT cp.Unite1, cp.Unite2, cpp.Libelle, cpp.Unite1 AS LibUnite1, cpp.Unite2 AS LibUnite2, cpp.AMM, cpp.TAXSM " & _
                                "FROM CompositionProduit AS cp INNER JOIN Produit AS cpp ON cp.CodeProduitComposition = cpp.CodeProduit " & _
                                "WHERE (cp.CodeProduit = '{0}') AND (cpp.IsAMM = 1)", codeproduit.Replace("'", "''"))
        End If

        'Dim dt As DataTable
        'FIN MODIF TV 14/09/2012

        Using s As New SqlProxy
            dt = s.ExecuteDataTable(Sql)
        End Using

        For Each rwProd As DataRow In dt.Rows
            'AMM doit être renseigné sinon pas de création de ligne
            If Not (rwProd.IsNull("AMM")) AndAlso Not (Convert.ToString(rwProd.Item("AMM")) = String.Empty) Then
                If Not hash.ContainsKey(rwProd("AMM")) Then
                    Dim r As New RecapRedevance
                    r.AMM = Convert.ToString(rwProd("AMM"))
                    If Not rwProd.IsNull("TAXSM") Then r.TAXSM = CDec(rwProd("TAXSM"))
                    r.Libelle = Convert.ToString(rwProd("Libelle"))
                    r.TTVA = Convert.ToString(TTVA) 'S'il y a plusieurs TTVA différent, c'est le premier qui gagne
                    r.LibUnite1 = Convert.ToString(rwProd("LibUnite1"))
                    r.LibUnite2 = Convert.ToString(rwProd("LibUnite2"))
                    If Not IsDBNull(rwProd("Unite1")) AndAlso Not IsDBNull(unite1) Then r.Unite1 = CDec(unite1) * CDec(rwProd("Unite1"))
                    If Not IsDBNull(rwProd("Unite2")) AndAlso Not IsDBNull(unite2) Then r.Unite2 = CDec(unite2) * CDec(rwProd("Unite2"))
                    hash.Add(rwProd("AMM"), r)
                Else
                    Dim r As RecapRedevance = CType(hash(rwProd("AMM")), RecapRedevance)
                    If Not IsDBNull(rwProd("Unite1")) AndAlso Not IsDBNull(unite1) Then r.Unite1 += CDec(unite1) * CDec(rwProd("Unite1"))
                    If Not IsDBNull(rwProd("Unite2")) AndAlso Not IsDBNull(unite2) Then r.Unite2 += CDec(unite2) * CDec(rwProd("Unite2"))
                End If
            End If
        Next
    End Sub

    Private Shared Sub AjoutLigneRedevance(ByVal ds As DataSet, ByVal nDevis As Integer, ByVal r As RecapRedevance)
        Dim rwDetailRed As DataRow
        Dim rws() As DataRow = ds.Tables("VFacture_Detail").Select(String.Format("nDevis={0}", nDevis))
        If rws.Length > 0 Then
            With rws(rws.Length - 1)
                If Convert.ToString(.Item("CodeProduit")) = "" AndAlso Convert.ToString(.Item("Libelle")) = "" Then
                    rwDetailRed = rws(rws.Length - 1)
                End If
            End With
        End If
        If rwDetailRed Is Nothing Then
            rwDetailRed = ds.Tables("VFacture_Detail").NewRow

            'MODIF TV 17/09/2012
            rwDetailRed("nDetailDevis") = Pieces.GetNDetailDevis("VFacture_Detail")
            'FIN MODIF TV 17/09/2012

            rwDetailRed("nDevis") = nDevis
            ds.Tables("VFacture_Detail").Rows.Add(rwDetailRed)
        End If

        With rwDetailRed
            .Item("CodeProduit") = String.Format("RED-{0}", r.AMM)
            .Item("Libelle") = String.Format("{0} - REDEVANCE", r.Libelle)
            .Item("LibUnite1") = r.LibUnite1
            .Item("LibUnite2") = r.LibUnite2
            .Item("PrixUHT") = r.TAXSM
            If r.TTVA.Length > 0 Then .Item("TTVA") = r.TTVA
            If r.Unite1 <> 0 Then .Item("Unite1") = r.Unite1
            If r.Unite1 <> 0 Then .Item("Unite2") = r.Unite2
            .Item("MontantLigneHT") = Actigram.MathUtil.ArithmeticRound(r.Unite1 * r.TAXSM, 2)
            .Item("MontantLigneTVA") = Actigram.MathUtil.ArithmeticRound(CDec(.Item("MontantLigneHT")) * TrouverTxTVA(ds, r.TTVA), 2)
            .Item("MontantLigneTTC") = CDec(.Item("MontantLigneHT")) + CDec(.Item("MontantLigneTVA"))
            .Item("NCompte") = NCompteRED
            .Item("NActivite") = NActiRED
        End With
    End Sub

    Public Shared Sub AjoutLignesRedevance(ByVal ds As DataSet, ByVal nDevis As Integer)
        Try
            Cursor.Current = Cursors.WaitCursor
            'Faire un récap des lignes soumises à redevance
            Dim hash As New Hashtable
            For Each rw As DataRow In ds.Tables("VFacture_Detail").Select(String.Format("nDevis={0}", nDevis))
                AddRecapRedevance(hash, Convert.ToString(rw("CodeProduit")), rw("Unite1"), rw("Unite2"), rw("TTVA"))
            Next

            'Réinit à null les lignes de redevances
            For Each rwRed As DataRow In ds.Tables("VFacture_Detail").Select(String.Format("nDevis={0} AND CodeProduit LIKE 'RED-*'", nDevis))
                rwRed("Unite1") = DBNull.Value
                rwRed("Unite2") = DBNull.Value
            Next

            'Pour chaque redevance vérifier que la ligne de redevance est présente
            For Each r As RecapRedevance In hash.Values
                Dim rwsRed() As DataRow = ds.Tables("VFacture_Detail").Select(String.Format("nDevis={0} AND CodeProduit='RED-{1}'", nDevis, r.AMM))
                If rwsRed.Length > 0 Then
                    'Si oui, vérifier les quantités (et recalculer le montant ligne)
                    With rwsRed(0)
                        If r.Unite1 <> 0 Then .Item("Unite1") = r.Unite1
                        If r.Unite2 <> 0 Then .Item("Unite2") = r.Unite2
                        .Item("MontantLigneHT") = Actigram.MathUtil.ArithmeticRound(r.Unite1 * CDec(.Item("PrixUHT")), 2)
                        .Item("MontantLigneTVA") = Actigram.MathUtil.ArithmeticRound(CDec(.Item("MontantLigneHT")) * TrouverTxTVA(ds, r.TTVA), 2)
                        .Item("MontantLigneTTC") = CDec(.Item("MontantLigneHT")) + CDec(.Item("MontantLigneTVA"))
                    End With
                Else
                    'Sinon créer la ligne de redevance
                    AjoutLigneRedevance(ds, nDevis, r)
                End If
            Next

            'Supprimer les lignes de redevance en trop
            For Each rwRed As DataRow In ds.Tables("VFacture_Detail").Select(String.Format("nDevis={0} AND CodeProduit LIKE 'RED-*' AND Unite1 IS NULL", nDevis))
                rwRed.Delete()
            Next
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Class RecapRedevance
        Public AMM As String
        Public TAXSM As Decimal
        Public Libelle As String
        Public TTVA As String
        Public LibUnite1 As String
        Public LibUnite2 As String
        Public Unite1 As Decimal
        Public Unite2 As Decimal
    End Class
#End Region

#Region "Génération de BL"
    Private Shared Function InitProgressBar(ByVal max As Integer, Optional ByVal text As String = "Traitement en cours") As FrProgressBar
        Dim FrP As New FrProgressBar
        With FrP
            .Text = text
            .TopMost = True
            .Maximum = max
            .Value = 0
            .Show()
        End With
        Return FrP
    End Function

    'Créer les BL appro à partir d'une facture d'achat
    Public Shared Function GenererBLAppro(ByVal nDevis As Integer, ByVal ds As DataSet) As Integer
        Dim FrP As FrProgressBar
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim res As Integer = 0
            Using s As New SqlProxy
                Dim sql As String = "select distinct BC.nClient " & _
                                    "from Appro_BCD_AFD appro " & _
                                    "inner join AFacture_Detail AFD ON appro.AFD_nDevisDetail = AFD.nDetailDevis " & _
                                    "inner join VBonCommande_Detail BCD ON appro.BCD_nDevisDetail = BCD.nDetailDevis " & _
                                    "inner join VBonCommande BC on BCD.nDevis=BC.nDevis " & _
                                    "where AFD.nDevis = " & nDevis
                Dim dtClients As DataTable = s.ExecuteDataTable(sql)
                If dtClients.Rows.Count > 0 Then
                    sql = "select BC.nClient,BC.nfacture, appro.* " & _
                        "from Appro_BCD_AFD appro " & _
                        "inner join AFacture_Detail AFD ON appro.AFD_nDevisDetail = AFD.nDetailDevis " & _
                        "inner join VBonCommande_Detail BCD ON appro.BCD_nDevisDetail = BCD.nDetailDevis " & _
                        "inner join VBonCommande BC on BCD.nDevis=BC.nDevis " & _
                        "WHERE AFD.nDevis = " & nDevis
                    Dim dtCommandes As DataTable = s.ExecuteDataTable(sql)
                    FrP = InitProgressBar(dtClients.Rows.Count, "Génération des bons de livraison en cours")

                    For Each drC As DataRow In dtClients.Rows
                        Dim nClient As Integer = CInt(drC("nClient"))
                        Dim rwsComm() As DataRow = dtCommandes.Select(String.Format("nClient={0}", nClient), "nfacture")
                        If rwsComm.Length > 0 Then
                            GestionApproFact.CreerBLAppro(ds, nDevis, nClient, rwsComm)
                            FrP.Value += 1
                            res += 1
                        End If
                    Next

                    'MAJ la base de données
                    FrP.Text = "Mise à jour des données"
                    Dim tables As String() = {"VBonLivraison", "VBonLivraison_Detail"}
                    s.UpdateTables(ds, tables)


                    'Marquer les BC entièrement traités comme "paye"
                    Dim dtCommandesPayees As DataTable = _
                    s.ExecuteDataTable("select nDevis from " & _
                                "vboncommande where paye=0 and nDevis not in ( " & _
                                "select bcd.nDevis from vboncommande_detail bcd " & _
                                "left join Appro_BCD_AFD app on app.BCD_nDevisDetail=bcd.nDetailDevis " & _
                                "where bcd.unite1 is not null " & _
                                "group by bcd.nDevis,bcd.nDetailDevis,bcd.unite1 " & _
                                "having not (bcd.unite1-sum(isnull(app.bc_unite1,0))=0 and min(isnull(BLD_nDevisDetail,0))>0))")
                    For Each dr As DataRow In dtCommandesPayees.Rows
                        Dim drBC As DataRow = SelectSingleRow(ds.Tables("VBonCommande"), String.Format("paye=false AND nDevis={0}", dr("nDevis")), "")
                        If Not drBC Is Nothing Then
                            drBC("Paye") = True
                        End If
                    Next

                    s.UpdateTable(ds, "VBonCommande")
                    FrP.Close()
                    FrP = Nothing
                    MsgBox("Opération Terminée", MsgBoxStyle.Information)
                End If
            End Using
            Return res
        Finally
            If Not FrP Is Nothing Then FrP.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Shared Sub CreerBLAppro(ByVal dsBase As DataSet, ByVal ndevis As Integer, ByVal nClient As Integer, ByVal rwsCmd() As DataRow)
        Dim dtProduit As DataTable = dsBase.Tables("Produit")
        Dim rwFactureSrc As DataRow = dsBase.Tables("AFacture").Select("nDevis=" & ndevis)(0)
        Dim rwFactureDest As DataRow = dsBase.Tables("VBonLivraison").NewRow
        'Initialiser les valeurs de la ligne BL
        CopyRow(rwFactureSrc, rwFactureDest)
        'Modifier les valeurs du BL qui doivent etre modifiées
        With rwFactureDest
            .Item("nClient") = nClient
            .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.VBonLivraison)
            .Item("AdresseFacture") = GestionFactureMasse.AdresseFacturation(dsBase, nClient)
            .Item("DateFacture") = Now.ToString("dd/MM/yy")
            .Item("Origine") = "AFacture"
            .Item("nOrigine") = ndevis
            .Item("Paye") = False
            .Item("ExportCompta") = False
            .Item("DateExportCompta") = DBNull.Value
            .Item("DateRelance1") = DBNull.Value
            .Item("DateRelance2") = DBNull.Value
            .Item("MontantHT") = DBNull.Value
            .Item("MontantTVA") = DBNull.Value
            .Item("MontantTTC") = DBNull.Value
        End With
        dsBase.Tables("VBonLivraison").Rows.Add(rwFactureDest)

        Dim montantHT As Decimal
        Dim montantTVA As Decimal
        Dim montantTTC As Decimal
        'Pour chaque ligne de commande
        'Créer une ligne de BL de vente
        Dim curCmd As Integer = -1
        For Each rwCmd As DataRow In rwsCmd
            If curCmd <> CInt(rwCmd("nfacture")) Then
                curCmd = CInt(rwCmd("nfacture"))
                'Créer une ligne d'intercalaire
                Dim rwInter As DataRow = dsBase.Tables("VBonLivraison_Detail").NewRow
                rwInter.SetParentRow(rwFactureDest)
                rwInter("Libelle") = String.Format("Bon de commande n°{0}", curCmd)
                dsBase.Tables("VBonLivraison_Detail").Rows.Add(rwInter)
            End If
            Dim rwDetailDest As DataRow = dsBase.Tables("VBonLivraison_Detail").NewRow
            Dim rwDetailSrc As DataRow = SelectSingleRow(dsBase.Tables("AFacture_Detail"), String.Format("nDetailDevis={0}", rwCmd("AFD_nDevisDetail")), "")
            Dim rwProd As DataRow = SelectSingleRow(dsBase.Tables("Produit"), String.Format("CodeProduit='{0}'", CStr(rwDetailSrc("CodeProduit")).Replace("'", "''")), "")
            CopyRow(rwDetailSrc, rwDetailDest)
            With rwDetailDest
                .SetParentRow(rwFactureDest)
                ' - Prix U HT = Prix U SRAP (colonne PrixUTTCVente)
                If Not IsDBNull(rwDetailSrc("PrixUTTCVente")) Then
                    .Item("PrixUHT") = rwDetailSrc("PrixUTTCVente")
                Else
                    .Item("PrixUHT") = rwDetailSrc("PrixUHT")
                End If
                .Item("PrixUAchatHT") = rwDetailSrc("PrixUHT")
                .Item("NbParution") = rwDetailSrc("nDetailDevis")
                ' - Qte = Null, Montant = Null
                If Not rwProd Is Nothing Then .Item("TTVA") = rwProd("TTVA")
                .Item("Unite1") = rwCmd("AF_Unite1")
                .Item("Unite2") = rwCmd("AF_Unite2")
                .Item("MontantLigneHT") = DBNull.Value
                .Item("MontantLigneTVA") = DBNull.Value
                .Item("MontantLigneTTC") = DBNull.Value
            End With
            CalculerMontantsLigne(dsBase, rwDetailDest, rwProd, rwFactureDest)
            If Not IsDBNull(rwDetailDest("MontantLigneHT")) Then montantHT += CDec(rwDetailDest("MontantLigneHT"))
            If Not IsDBNull(rwDetailDest("MontantLigneTVA")) Then montantTVA += CDec(rwDetailDest("MontantLigneTVA"))
            If Not IsDBNull(rwDetailDest("MontantLigneTTC")) Then montantTTC += CDec(rwDetailDest("MontantLigneTTC"))
            'Noter la ligne de commande comme traitée par le BL
            LierBL_AF_BC(CInt(rwDetailDest("nDetailDevis")), CInt(rwCmd("AFD_nDevisDetail")), CInt(rwCmd("BCD_nDevisDetail")))
            dsBase.Tables("VBonLivraison_Detail").Rows.Add(rwDetailDest)
        Next
        With rwFactureDest
            .Item("MontantHT") = montantHT
            .Item("MontantTVA") = montantTVA
            .Item("MontantTTC") = montantTTC
        End With
    End Sub

    Private Shared Sub LierBL_AF_BC(ByVal BLD_nDevisDetail As Integer, ByVal AFD_nDevisDetail As Integer, ByVal BCD_nDevisDetail As Integer)
        Using s As New SqlProxy
            s.ExecuteNonQuery(String.Format("Update Appro_BCD_AFD Set BLD_nDevisDetail={0} WHERE AFD_nDevisDetail={1} And BCD_nDevisDetail={2}", BLD_nDevisDetail, AFD_nDevisDetail, BCD_nDevisDetail))
        End Using
    End Sub

    'Private Shared Sub CreerBLAppro(ByVal dsBase As DataSet, ByVal nDevis As Integer, ByVal nClient As Integer)

    '    Dim dtProduit As DataTable = dsBase.Tables("Produit")
    '    Dim rwFactureSrc As DataRow = dsBase.Tables("AFacture").Select("nDevis=" & nDevis)(0)
    '    Dim rwFactureDest As DataRow = dsBase.Tables("VBonLivraison").NewRow
    '    'Initialiser les valeurs de la ligne BL
    '    GestionFactureMasse.CopyRw(rwFactureSrc, rwFactureDest)
    '    'Modifier les valeurs du BL qui doivent etre modifiées
    '    With rwFactureDest
    '        .Item("nClient") = nClient
    '        .Item("nFacture") = FrBonCommande.GetNFacture("VBonLivraison")
    '        .Item("AdresseFacture") = GestionFactureMasse.AdresseFacturation(dsBase, nClient)
    '        .Item("DateFacture") = Now.ToString("dd/MM/yy")
    '        .Item("Origine") = "AFacture"
    '        .Item("nOrigine") = nDevis
    '        .Item("Paye") = False
    '        .Item("ExportCompta") = False
    '        .Item("DateExportCompta") = DBNull.Value
    '        .Item("DateRelance1") = DBNull.Value
    '        .Item("DateRelance2") = DBNull.Value
    '        .Item("MontantHT") = DBNull.Value
    '        .Item("MontantTVA") = DBNull.Value
    '        .Item("MontantTTC") = DBNull.Value
    '    End With
    '    dsBase.Tables("VBonLivraison").Rows.Add(rwFactureDest)

    '    'Pour chaque ligne de la facture d'achat
    '    'Créer une ligne de BL de vente
    '    For Each rwDetailSrc As DataRow In rwFactureSrc.GetChildRows("AFactureAFacture_Detail")
    '        Dim rwDetailDest As DataRow = dsBase.Tables("VBonLivraison_Detail").NewRow
    '        Dim rwProd As DataRow = SelectSingleRow(dsBase.Tables("Produit"), String.Format("CodeProduit='{0}'", CStr(rwDetailSrc("CodeProduit")).Replace("'", "''")))
    '        GestionFactureMasse.CopyRw(rwDetailSrc, rwDetailDest)
    '        With rwDetailDest
    '            .SetParentRow(rwFactureDest)
    '            ' - Prix U HT = Prix U SRAP (colonne PrixUTTCVente)
    '            If Not IsDBNull(rwDetailSrc("PrixUTTCVente")) Then
    '                .Item("PrixUHT") = rwDetailSrc("PrixUTTCVente")
    '            Else
    '                .Item("PrixUHT") = rwDetailSrc("PrixUHT")
    '            End If
    '            .Item("PrixUAchatHT") = rwDetailSrc("PrixUHT")
    '            ' - Qte = Null, Montant = Null
    '            If Not rwProd Is Nothing Then .Item("TTVA") = rwProd("TTVA")
    '            .Item("Unite1") = DBNull.Value
    '            .Item("Unite2") = DBNull.Value
    '            .Item("MontantLigneHT") = DBNull.Value
    '            .Item("MontantLigneTVA") = DBNull.Value
    '            .Item("MontantLigneTTC") = DBNull.Value

    '        End With
    '        dsBase.Tables("VBonLivraison_Detail").Rows.Add(rwDetailDest)
    '    Next
    'End Sub

    Public Shared Sub NettoyerFacture(ByVal ds As DataSet, ByVal nDevis As Integer)
        'Recopier les lignes de la facture dans l'ordre alpha des produits et en ignorant les lignes vide et intercalaire
        Dim rws() As DataRow = ds.Tables("VFacture_Detail").Select("nDevis=" & nDevis, "Libelle")
        For Each dr As DataRow In rws
            If Convert.ToString(dr("CodeProduit")).Length > 0 Then
                'Dupliquer la ligne
                Dim drNew As DataRow = ds.Tables("VFacture_Detail").NewRow
                CopyRow(dr, drNew)
                ds.Tables("VFacture_Detail").Rows.Add(drNew)
            End If
            'Supprimer la ligne d'origine
            dr.Delete()
        Next
    End Sub
#End Region

#Region "RFC"
    'Créer les avoirs de fin de campagne pour les adhérents ayant acheté un produit ayant eu un prix négocié
    Public Shared Function GenererAvoirsAppro(ByVal ds As DataSet) As Integer
        'SAISIE DES DATES
        Dim fr As New FrOptionsGeneAvoirs(Now.Date.AddYears(-1), Now.Date)
        If Not fr.ShowDialog = DialogResult.OK Then Exit Function
        Dim dtDeb As Date = fr.DtDeb
        Dim dtFin As Date = fr.DtFin
        dtDeb = dtDeb.Date
        dtFin = dtFin.AddDays(1).Date
        Try
            Cursor.Current = Cursors.WaitCursor
            Using s As New SqlProxy
                Dim sql As String = String.Format("SELECT DISTINCT f.nClient " & _
                                    "FROM VFacture AS f " & _
                                    "WHERE f.DateFacture>='{0:dd/MM/yyyy}' AND  f.DateFacture<'{1:dd/MM/yyyy}'", dtDeb, dtFin)
                Dim dt As DataTable = s.ExecuteDataTable(sql)
                If dt.Rows.Count = 0 Then
                    MsgBox("Aucune facture d'appro n'a été trouvée dans la période choisie.", MsgBoxStyle.Information)
                    Return 0
                End If

                Dim nClients(dt.Rows.Count - 1) As String
                For i As Integer = 0 To dt.Rows.Count - 1
                    nClients(i) = Convert.ToString(dt.Rows(i)("nClient"))
                Next

                Dim g As New GestionFactureMasse
                Dim lstClients As ArrayList = g.SelectionnerClients(ds, String.Format("nEntreprise IN ({0})", String.Join(",", nClients)))

                Dim res As Integer = 0
                If lstClients.Count > 0 Then
                    Using frp As FrProgressBar = InitProgressBar(lstClients.Count, "Génération des avoirs en cours")
                        For Each nClient As Integer In lstClients
                            GestionApproFact.CreerAvoirAppro(s, ds, nClient, dtDeb, dtFin)
                            res += 1
                            frp.Value += 1
                        Next
                    End Using
                    MessageBox.Show("Opération Terminée")
                End If
                Return res
            End Using
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Shared Sub CreerAvoirAppro(ByVal s As SqlProxy, ByVal dsBase As DataSet, ByVal nClient As Integer, ByVal dtDeb As Date, ByVal dtFin As Date)
        Dim sql As String = String.Format("SELECT f.nClient,f.nFacture,f.DateFacture, " & _
                            "fd.CodeProduit,fd.Libelle,fd.Unite1,fd.LibUnite1,fd.Unite2,fd.LibUnite2,fd.TTVA,fd.nCompte,fd.nActivite,isnull(fd.PrixUHT,0) as PrixVente, " & _
                            "case when ad.nDetailDevis is not null then isnull(ad.PrixUHT,0) else isnull(fd.PrixUAchatHT,0) end as PrixAchat " & _
                            "FROM VFacture as f " & _
                            "INNER JOIN VFacture_Detail as fd ON f.nDevis=fd.nDevis " & _
                            "LEFT JOIN AFacture_Detail as ad ON fd.NbParution=ad.nDetailDevis " & _
                            "WHERE fd.Unite1 IS NOT NULL " & _
                            "AND f.nClient={0} AND f.DateFacture>='{1:dd/MM/yyyy}' AND  f.DateFacture<'{2:dd/MM/yyyy}'" & _
                            "ORDER BY f.nFacture", nClient, dtDeb, dtFin)


        Dim dt As DataTable = s.ExecuteDataTable(sql)
        Dim rws() As DataRow = dt.Select("PrixAchat>0 AND PrixAchat<PrixVente")
        If rws.Length > 0 Then
            'Créer la facture
            Dim rwFacture As DataRow = dsBase.Tables("VFacture").NewRow
            With rwFacture
                .Item("nClient") = nClient
                .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.VFacture)
                .Item("AdresseFacture") = GestionFactureMasse.AdresseFacturation(dsBase, nClient)
                .Item("DateFacture") = Now.ToString("dd/MM/yy")
            End With
            dsBase.Tables("VFacture").Rows.Add(rwFacture)
            Dim MontantAvoirHT As Decimal = 0
            Dim MontantAvoirTVA As Decimal = 0
            Dim nFacture As Integer = 0
            For Each dr As DataRow In rws
                If CInt(dr("nFacture")) <> nFacture Then
                    'Créer une ligne intercalaire
                    Dim rwInter As DataRow = dsBase.Tables("VFacture_Detail").NewRow
                    With rwInter
                        .SetParentRow(rwFacture)
                        .Item("Libelle") = String.Format("FACTURE n°{0} DU {1:dd/MM/yyyy}", dr("nFacture"), dr("dateFacture"))
                    End With
                    dsBase.Tables("VFacture_Detail").Rows.Add(rwInter)
                    nFacture = CInt(dr("nFacture"))
                End If
                'Créer la ligne de détail
                Dim u1 As Decimal = 0
                If Not IsDBNull(dr("Unite1")) Then u1 = -CDec(dr("Unite1"))
                Dim prixU As Decimal = Math.Abs(CDec(dr("PrixAchat")) - CDec(dr("PrixVente")))
                Dim txtva As Decimal = TrouverTxTVA(dsBase, Convert.ToString(dr("TTVA")))
                Dim mtHT As Decimal = Math.Round(u1 * prixU, 2)
                Dim mtTVA As Decimal = mtHT * txtva
                MontantAvoirHT += mtHT
                MontantAvoirTVA += mtTVA

                Dim rwDetail As DataRow = dsBase.Tables("VFacture_Detail").NewRow
                With rwDetail
                    .SetParentRow(rwFacture)
                    .Item("CodeProduit") = String.Format("AV-{0}", dr("CodeProduit"))
                    .Item("Libelle") = String.Format("AVOIR SUR {0}", dr("Libelle"))
                    .Item("LibUnite1") = dr("LibUnite1")
                    .Item("LibUnite2") = dr("LibUnite2")
                    .Item("Unite1") = u1
                    If Not IsDBNull(dr("Unite2")) Then .Item("Unite2") = -CDec(dr("Unite2"))
                    .Item("PrixUHT") = prixU
                    .Item("TTVA") = dr("TTVA")
                    .Item("MontantLigneHT") = mtHT
                    .Item("MontantLigneTVA") = mtTVA
                    .Item("MontantLigneTTC") = mtHT + mtTVA
                    .Item("NCompte") = dr("NCompte")
                    .Item("NActivite") = dr("NActivite")
                End With
                dsBase.Tables("VFacture_Detail").Rows.Add(rwDetail)
            Next

            MontantAvoirTVA = Math.Round(MontantAvoirTVA, 2)
            With rwFacture
                .Item("MontantHT") = MontantAvoirHT
                .Item("MontantTVA") = MontantAvoirTVA
                .Item("MontantTTC") = MontantAvoirHT + MontantAvoirTVA
            End With

        End If

        'MAJ la base de données
        'On est obligé de le faire à chaque facture pour que le calcul du prochain n° soit bon
        s.UpdateTables(dsBase, New String() {"VFacture", "VFacture_Detail"})
    End Sub
#End Region

    Private Shared Function TrouverTxTVA(ByVal dsBase As DataSet, ByVal TTVA As String) As Decimal
        Dim res As Decimal = 0
        If TTVA.Length > 0 Then
            Dim rwsTVA() As DataRow = dsBase.Tables("TVA").Select(String.Format("TTVA='{0}'", TTVA.Replace("'", "''")))
            If rwsTVA.Length > 0 Then
                Return CDec(rwsTVA(0)("TTaux")) / 100
            End If
        End If
        Return res
    End Function

    'Public Shared Function ExecDataTable(ByVal sql As String) As DataTable
    '    Dim dt As DataTable
    '    Dim conn As New SqlClient.SqlConnection(FrDonnees.GetstrConnexion(FrApplication.Utilisateur, FrApplication.Pwd))
    '    Dim dta As New SqlClient.SqlDataAdapter(sql, conn)
    '    Try
    '        dt = New DataTable
    '        dta.Fill(dt)
    '    Finally
    '        dta.Dispose()
    '        If conn.State <> ConnectionState.Closed Then conn.Close()
    '    End Try
    '    Return dt
    'End Function

    'Public Shared Sub ExecNonQuery(ByVal sql As String)
    '    Dim conn As New SqlClient.SqlConnection(FrDonnees.GetstrConnexion(FrApplication.Utilisateur, FrApplication.Pwd))
    '    Dim cmd As New SqlClient.SqlCommand(sql, conn)
    '    Try
    '        If conn.State <> ConnectionState.Open Then conn.Open()
    '        cmd.ExecuteNonQuery()
    '    Finally
    '        cmd.Dispose()
    '        If conn.State <> ConnectionState.Closed Then conn.Close()
    '    End Try
    'End Sub

    'Public Shared Function SelectSingleRow(ByVal dt As DataTable, ByVal selectStr As String, Optional ByVal sort As String = "") As DataRow
    '    If dt Is Nothing Then Return Nothing
    '    Dim rws() As DataRow = dt.Select(selectStr, sort)
    '    If rws.Length > 0 Then
    '        Return rws(0)
    '    Else
    '        Return Nothing
    '    End If
    'End Function


#Region "Génération des Factures d'Achat"
    'Créer les factures d'achat à partir des bons de commande
    Public Shared Function GenererAchatAppro(ByVal ds As DataSet) As Integer
        Dim fr As New FrCreerCommandeFourn
        If fr.ShowDialog = DialogResult.Cancel Then Return -1
        Dim nDevis As Integer = 0

        Dim rwFournisseur As DataRow = SelectSingleRow(ds.Tables("Entreprise"), "nEntreprise=" & fr.nFourn, "")
        Dim strAdresse As String
        With rwFournisseur
            strAdresse = Convert.ToString(.Item("Nom"))
            If Convert.ToString(.Item("Adresse")).Length > 0 Then
                If strAdresse.Length > 0 Then strAdresse += vbCrLf
                strAdresse += Convert.ToString(.Item("Adresse"))
            End If
            strAdresse += String.Format("{0} {1}", .Item("CodePostal"), .Item("Ville"))
        End With

        Dim rwNCmdF As DataRow = ds.Tables("AFacture").NewRow
        With rwNCmdF
            .Item("nClient") = fr.nFourn
            .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.AFacture)
            .Item("DateFacture") = Today
            .Item("Paye") = False
            .Item("ExportCompta") = False
            .Item("DateExportCompta") = DBNull.Value
            .Item("FacturationTTC") = rwFournisseur("FacturationTTC")
            .Item("AdresseFacture") = strAdresse
        End With
        ds.Tables("AFacture").Rows.Add(rwNCmdF)
        nDevis = CInt(rwNCmdF("nDevis"))

        Dim dtProduit As DataTable = ds.Tables("Produit")
        Dim dtComm As DataTable = fr.Result
        For Each dr As DataRow In dtComm.Rows
            Dim rwProd As DataRow = SelectSingleRow(dtProduit, String.Format("CodeProduit='{0}'", CStr(dr("CodeProduit")).Replace("'", "''")), "")
            Dim rwDetailDest As DataRow
            Dim rws() As DataRow = ds.Tables("AFacture_Detail").Select(String.Format("nDevis={0} AND CodeProduit='{1}'", nDevis, CStr(dr("CodeProduit")).Replace("'", "''")))
            If rws.Length = 0 Then
                rwDetailDest = ds.Tables("AFacture_Detail").NewRow
                With rwDetailDest
                    .SetParentRow(rwNCmdF)
                    .Item("CodeProduit") = dr("CodeProduit")
                    .Item("Libelle") = dr("Libelle")
                    If Not rwProd Is Nothing Then .Item("PrixUHT") = rwProd("PrixAHT")
                    If Not rwProd Is Nothing Then .Item("PrixUTTC") = rwProd("PrixATTC")
                    If Not rwProd Is Nothing Then .Item("TTVA") = rwProd("TTVA")
                    .Item("Unite1") = 0
                    .Item("Unite2") = 0
                    .Item("LibUnite1") = dr("LibUnite1")
                    .Item("LibUnite2") = dr("LibUnite2")
                End With
                ds.Tables("AFacture_Detail").Rows.Add(rwDetailDest)
            Else
                rwDetailDest = rws(0)
            End If
            With rwDetailDest
                .Item("Unite1") = CDec(.Item("Unite1")) + CDec(ReplaceDbNull(dr("Unite1"), 0))
                .Item("Unite2") = CDec(.Item("Unite2")) + CDec(ReplaceDbNull(dr("Unite2"), 0))
                CalculerMontantsLigne(ds, rwDetailDest, rwProd, rwNCmdF)
            End With
            'Affecter les quantités commandées aux BC clients
            AffecterBCFact(ds, dr, rwDetailDest)
        Next
        FrBonCommande.CalculMontant(ds, rwNCmdF, "AFactureAFacture_Detail", Pieces.TypePieces.AFacture)

        'MAJ Base
        Dim tables As String() = {"AFacture", "AFacture_Detail"}
        Using s As New SqlProxy
            s.UpdateTables(ds, tables)
        End Using
        Return nDevis
    End Function

    Private Shared Sub CalculerMontantsLigne(ByVal ds As DataSet, ByVal rwDetailDest As DataRow, ByVal rwProd As DataRow, ByVal rwCmd As DataRow)
        With rwDetailDest
            .Item("MontantLigneHT") = DBNull.Value
            .Item("MontantLigneTVA") = DBNull.Value
            .Item("MontantLigneTTC") = DBNull.Value
        End With
        If IsDBNull(rwDetailDest("Unite1")) Then Exit Sub
        Dim tauxTVA As Decimal = TrouverTauxTVA(ds, rwDetailDest("TTVA"))
        Dim qte As Decimal = CDec(rwDetailDest("Unite1"))
        If Not rwProd Is Nothing Then
            Select Case Convert.ToString(rwProd("TypeFacturation"))
                Case "U2"
                    qte = CDec(ReplaceDbNull(rwDetailDest("Unite2"), 0))
                Case "U1xU2"
                    qte = qte * CDec(ReplaceDbNull(rwDetailDest("Unite2"), 0))
            End Select
        End If
        Dim montantTTC As Decimal
        Dim montantHT As Decimal
        If CBool(rwCmd("FacturationTTC")) Then
            If Not IsDBNull(rwDetailDest("PrixUTTC")) Then
                montantTTC = qte * CDec(rwDetailDest("PrixUTTC"))
                montantHT = montantTTC / (1 + tauxTVA)
            End If
        Else
            If Not IsDBNull(rwDetailDest("PrixUHT")) Then
                montantHT = qte * CDec(rwDetailDest("PrixUHT"))
                montantTTC = montantHT * (1 + tauxTVA)
            End If
        End If
        With rwDetailDest
            .Item("MontantLigneHT") = montantHT
            .Item("MontantLigneTVA") = montantTTC - montantHT
            .Item("MontantLigneTTC") = montantTTC
        End With
    End Sub

    Private Shared Function TrouverTauxTVA(ByVal ds As DataSet, ByVal ttva As Object) As Decimal
        If IsDBNull(ttva) Then Return 0
        Dim rws() As DataRow = ds.Tables("TVA").Select(String.Format("TTVA='{0}'", CStr(ttva).Replace("'", "''")))
        If rws.Length = 0 Then Return 0
        Return CDec(rws(0)("TTaux")) / 100
    End Function

    Private Shared Sub AffecterBCFact(ByVal ds As DataSet, ByVal drCommande As DataRow, ByVal drDetailFact As DataRow)
        Dim dt As DataTable = ds.Tables("Appro_BCD_AFD")
        Dim rows() As DataRow = dt.Select(String.Format("BCD_nDevisDetail={0} AND AFD_nDevisDetail={1}", drCommande("BCD_nDetailDevis"), drDetailFact("nDetailDevis")))
        Dim dr As DataRow
        If rows.Length = 0 Then
            dr = dt.NewRow
            dr("BCD_nDevisDetail") = drCommande("BCD_nDetailDevis")
            dr("AFD_nDevisDetail") = drDetailFact("nDetailDevis")
            dt.Rows.Add(dr)
        Else
            dr = rows(0)
        End If
        dr("BC_Unite1") = drCommande("Unite1")
        dr("BC_Unite2") = drCommande("Unite2")
        dr("AF_Unite1") = drCommande("Unite1")
        dr("AF_Unite2") = drCommande("Unite2")
    End Sub

#End Region

#Region "Impression "
    Public Shared Function ImprimerBilan(ByVal dtDeb As Date, ByVal dtFin As Date) As Form
        Dim ApproFactDS As New ApproFactDataSet

        'Chargement des données BilanVenteApproFact
        Using ImprBilanVenteApproFactTA As New ApproFactDataSetTableAdapters.ImprBilanVenteApproFactTableAdapter
            ImprBilanVenteApproFactTA.Fill(ApproFactDS.ImprBilanVenteApproFact, dtDeb, dtFin.AddDays(1))
        End Using

        'Chargement des données de la table Parametres
        Using ParametresTA As New ApproFactDataSetTableAdapters.ParametresTableAdapter
            ParametresTA.Fill(ApproFactDS.Parametres)
        End Using

        'Chargement du rapport
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(ApproFactDS, "RptBilanVenteApproFact.rpt")

        'Renseignement des paramètres
        With fr.Parametres
            .EnTete = ValeurParamImpression(ApproFactDS.Parametres, "EnTete", "", "")
            .EnTeteDetail = ValeurParamImpression(ApproFactDS.Parametres, "EnTeteDetail", "", "")
            .SetValue("AgenceEau", ValeurParamImpression(ApproFactDS.Parametres, "AgenceEau", "", ""))
            .SetValue("Tel", ValeurParamImpression(ApproFactDS.Parametres, "NTel", "", ""))
            .SetValue("dtDeb", dtDeb)
            .SetValue("dtFin", dtFin)
        End With

        fr.Show()

        Return fr

        ''Récup des données
        'Dim sql As String = String.Format("select p.libelle, p.AMM, c.codepostal, " & _
        '                    "f.nfacture,f.datefacture, " & _
        '                    "fd.montantligneht, fd.unite1,fd.libunite1 " & _
        '                    "FROM VFacture f " & _
        '                    "INNER JOIN Entreprise c ON f.nClient=c.nEntreprise " & _
        '                    "INNER JOIN VFacture_Detail fd ON f.nDevis=fd.nDevis " & _
        '                    "INNER JOIN Produit p ON fd.CodeProduit = 'RED-' + p.AMM AND p.IsAMM=1 AND p.Inactif=0" & _
        '                    "WHERE fd.codeproduit like 'RED-%' " & _
        '                    "AND f.datefacture>='{0:dd/MM/yyyy}' AND f.datefacture<'{1:dd/MM/yyyy}'", dtDeb, dtFin.AddDays(1))

        'Dim dt As DataTable

        'Using s As New SqlProxy
        '    dt = s.ExecuteDataTable(sql)
        'End Using

        'dt.TableName = "BilanVenteApproFact"

        'Dim newDs As New DataSet

        'newDs.Tables.Add(dt)

        ''Chargement du rapport
        'Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(newDs, "RptBilanVenteApproFact.rpt")

        ''Renseignement des paramètres
        'Dim dtParams As DataTable

        'If Not ds Is Nothing AndAlso ds.Tables.Contains("Parametres") Then
        '    dtParams = ds.Tables("Parametres")
        'End If

        'With fr.Parametres
        '    .EnTete = ValeurParamImpression(dtParams, "EnTete", "", "")
        '    .EnTeteDetail = ValeurParamImpression(dtParams, "EnTeteDetail", "", "")
        '    .SetValue("AgenceEau", ValeurParamImpression(dtParams, "AgenceEau", "", ""))
        '    .SetValue("Tel", ValeurParamImpression(dtParams, "NTel", "", ""))
        '    .SetValue("dtDeb", dtDeb)
        '    .SetValue("dtFin", dtFin)
        'End With

        'fr.Show()

        'Return fr
    End Function

    Private Shared Function ValeurParamImpression(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
        Dim res As String = valeurDefaut
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And (TypePiece is null Or TypePiece='{1}')", nomParam, nomTable), "TypePiece desc")
            If rws.Length > 0 Then
                res = Convert.ToString(rws(0).Item("Valeur"))
            End If
        End If
        Return res
    End Function
#End Region

End Class

#Region " Excel "
'Public Shared Function GetExcelConnString(ByVal fileName As String, Optional ByVal hasHeadersOnFirstRow As Boolean = False, Optional ByVal isReadOnly As Boolean = True, Optional ByVal guessColTypes As Boolean = False) As String
'    Return String.Format("Provider:Microsoft.Jet.OLEDB.4.0;DataSource={0};Extended Properties=""Excel 8.0;HDR={1};ReadOnly={2};IMEX={3};""", fileName, IIf(hasHeadersOnFirstRow, 1, 0), IIf(isReadOnly, 1, 0), IIf(guessColTypes, 0, 1))
'End Function

'Public Shared Function LoadExcelSheet(ByVal fileName As String, ByVal sheetName As String, Optional ByVal whereClause As String = "1=1", Optional ByVal selectClause As String = "*") As DataTable
'    Dim cn As New OleDb.OleDbConnection(GetExcelConnString(fileName))
'    Try
'        Return GetExcelSheet(cn, sheetName, whereClause, selectClause)
'    Finally
'        cn.Close()
'    End Try
'End Function

'Public Shared Function GetExcelSheet(ByVal conn As OleDb.OleDbConnection, ByVal sheetName As String, Optional ByVal whereClause As String = "1=1", Optional ByVal selectClause As String = "*") As DataTable
'    Dim myAdapter As New OleDb.OleDbDataAdapter(String.Format("SELECT {2} FROM [{0}$] WHERE {1}", sheetName, whereClause, selectClause), conn)
'    Dim dt As New DataTable
'    myAdapter.Fill(dt)
'    myAdapter.Dispose()
'    Return dt
'End Function
#End Region

#Region " CSV "
Public Class CsvFileReader
    Implements IDisposable

    Private Const STRING_DEL As Char = """"c

#Region "Props"
    Private sr As IO.StreamReader
    Private fields() As String

    Private _fieldNames() As String
    Public Property FieldNames() As String()
        Get
            Return _fieldNames
        End Get
        Set(ByVal Value As String())
            _fieldNames = Value
        End Set
    End Property

    Private _filename As String
    Public Property Filename() As String
        Get
            Return _filename
        End Get
        Set(ByVal Value As String)
            _filename = Value
        End Set
    End Property

    Private _separator As String
    Public Property Separator() As String
        Get
            Return _separator
        End Get
        Set(ByVal Value As String)
            _separator = Value
        End Set
    End Property

    Private _commentCar As String
    Public Property CommentLine() As String
        Get
            Return _commentCar
        End Get
        Set(ByVal Value As String)
            _commentCar = Value
        End Set
    End Property

    Private _fieldNamesOnFirstLine As Boolean
    Public Property FieldNamesOnFirstLine() As Boolean
        Get
            Return _fieldNamesOnFirstLine
        End Get
        Set(ByVal Value As Boolean)
            _fieldNamesOnFirstLine = Value
        End Set
    End Property
#End Region

    Public Sub New()

    End Sub

    Public Sub New(ByVal filename As String, Optional ByVal FieldNamesOnFirstLine As Boolean = True, Optional ByVal separator As String = ";", Optional ByVal commentCar As String = "#")
        Me.New()
        Me.Filename = filename
        Me.FieldNamesOnFirstLine = FieldNamesOnFirstLine
        Me.Separator = separator
        Me.CommentLine = commentCar
    End Sub

#Region "Open, Close et Dispose"
    Public Sub Open(Optional ByVal skipLines As Integer = 0)
        If Not IO.File.Exists(Me.Filename) Then Throw New IO.FileNotFoundException("Fichier introuvable", Me.Filename)
        Me.sr = New IO.StreamReader(Me.Filename, True)
        For i As Integer = 0 To skipLines - 1
            sr.ReadLine()
        Next
        If Me.FieldNamesOnFirstLine Then
            Me.ReadLine()
            ReDim _fieldNames(Me.fields.Length - 1)
            For i As Integer = 0 To Me.fields.Length - 1
                _fieldNames(i) = fields(i)
            Next
        End If
    End Sub

    Public Sub Close()
        Me.Dispose()
    End Sub

    Private disposedValue As Boolean = False        ' Pour détecter les appels redondants
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' libérez des ressources managées en cas d'appel explicite
            End If
            'libérez des ressources non managées partagées
            If Not sr Is Nothing Then
                sr.Close()
                sr = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#End Region

    Public Function CountLines() As Integer
        If sr Is Nothing Then Me.Open()
        Dim fs As IO.FileStream = CType(sr.BaseStream, IO.FileStream)
        Dim pos As Long = fs.Position
        fs.Position = 0
        Dim cnt As Integer = 0
        Dim line As String = sr.ReadLine
        While Not line Is Nothing
            If Not Me.CommentLine Is Nothing And line.StartsWith(Me.CommentLine) Then
            Else
                cnt += 1
            End If
            line = sr.ReadLine
        End While
        fs.Position = pos
        Return cnt
    End Function

    Public Function ReadLine() As Boolean
        If sr Is Nothing Then Me.Open()
        Dim line As String = sr.ReadLine
        If Not line Is Nothing AndAlso Not Me.CommentLine Is Nothing Then
            If line.StartsWith(Me.CommentLine) Then
                line = sr.ReadLine
            End If
        End If
        If line Is Nothing Then Return False
        If Me.Separator Is Nothing Then Throw New ApplicationException("Le séparateur n'est pas configuré")
        Dim tmpFields() As String = Split(line, Me.Separator)

        'Recopier dans fields en virant au passage les quotes et en traitant les doubles quotes
        ReDim fields(tmpFields.GetUpperBound(0))
        Dim j As Integer = 0
        For i As Integer = 0 To tmpFields.Length - 1
            Dim fld As String = tmpFields(i)
            If fld.StartsWith(STRING_DEL) Then
                While Not fld.EndsWith(STRING_DEL)
                    i += 1
                    If i = tmpFields.Length Then Exit While
                    fld &= Me.Separator & tmpFields(i)
                End While
                If fld.EndsWith(STRING_DEL) Then
                    fld = fld.Substring(1, fld.Length - 2)
                    fld = fld.Replace(STRING_DEL & STRING_DEL, STRING_DEL)
                End If
            End If
            fields(j) = fld
            j += 1
        Next
        ReDim Preserve fields(j - 1)
        Return True
    End Function

    Public Function Field(ByVal fieldName As String) As String
        If Not Me.FieldNamesOnFirstLine Then Return Nothing
        Dim i As Integer = Array.IndexOf(_fieldNames, fieldName)
        If i < 0 Then Return Nothing
        Return Field(i)
    End Function

    Public Function Field(ByVal index As Integer) As String
        Return Me.fields(index)
    End Function
End Class
#End Region
