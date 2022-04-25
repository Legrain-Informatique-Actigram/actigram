Public Class GestionTransfos

#Region "Méthodes partagées"
    Public Shared Sub ConversionBR(ByVal drMvt As AgrifactTracaDataSet.MouvementRow, Optional ByVal ownerForm As Form = Nothing)
        If MsgBox(String.Format("Voulez-vous créer un BR pour les produits du lot n°{0} du {1:dd/MM/yy} ?", drMvt.nPiece, drMvt.DateMouvement), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim ds As AgrifactTracaDataSet = Cast(Of AgrifactTracaDataSet)(drMvt.Table.DataSet)
                Cursor.Current = Cursors.WaitCursor
                Dim nMouvement As Decimal = drMvt.nMouvement
                'Charger la liste des MP
                Using dta As New AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
                    dta.Fill(ds.Produit, AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres, True)
                End Using
                'Remplir les détails pour le Mvt
                Using dta As New AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
                    dta.FillBynMouvement(ds.Mouvement_Detail, nMouvement)
                End Using
                'Remplir les infos de l'entreprise
                Using dta As New AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
                    dta.FillEntreprise(ds.Entreprise)
                End Using

                If ds.Entreprise.Rows.Count = 0 Then
                    MsgBox("Impossible de trouver l'entreprise parmi les fournisseurs." & vbCrLf & "Veuillez créer un fournisseur pour l'entreprise.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                'Identifier les produits finis (Unite1>0) qui sont également des matières premières
                Dim drPF() As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow())(ds.Mouvement_Detail.Select("unite1>0 AND nMouvement=" & nMouvement))
                Dim trouve As Boolean = False
                For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In drPF
                    If dr.ProduitRow IsNot Nothing Then
                        If dr.ProduitRow.ProduitAchat Then
                            trouve = True
                            Exit For
                        End If
                    End If
                Next

                'S'il n'y en a pas, sortir en erreur
                If Not trouve Then
                    MsgBox("Aucun produit issu de cette fabrication n'est une matière première.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                Dim drEnt As AgrifactTracaDataSet.EntrepriseRow = Cast(Of AgrifactTracaDataSet.EntrepriseRow)(ds.Entreprise.Rows(0))
                Dim newNDevis As Decimal
                Using dtaBR As New AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
                    Using dtaBR_detail As New AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
                        ds.ABonReception.InitAutoIncrementSeed(dtaBR)
                        ds.ABonReception_Detail.InitAutoIncrementSeed(dtaBR_detail)

                        'Sinon, créer un BR avec
                        Dim drBR As AgrifactTracaDataSet.ABonReceptionRow = ds.ABonReception.NewABonReceptionRow
                        With drBR
                            .nClient = drEnt.nEntreprise
                            .DateFacture = drMvt.DateMouvement
                            .Observation = String.Format("Produits de la fab. n°{0} du {1:dd/MM/yy}", drMvt.nPiece, drMvt.DateMouvement)
                        End With
                        ds.ABonReception.Rows.Add(drBR)
                        newNDevis = drBR.nDevis

                        'Pour chaque ligne de produit
                        drPF = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow())(ds.Mouvement_Detail.Select("unite1>0 AND nMouvement=" & nMouvement))
                        For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In drPF
                            If dr.ProduitRow IsNot Nothing Then
                                If dr.ProduitRow.ProduitAchat Then
                                    'Créer une ligne de BR_Detail
                                    Dim drBRd As AgrifactTracaDataSet.ABonReception_DetailRow = ds.ABonReception_Detail.NewABonReception_DetailRow
                                    With drBRd
                                        .nDevis = newNDevis
                                        .CodeProduit = dr.CodeProduit
                                        .NLot = dr.nLot
                                        If Not dr.IsLibelleNull Then .Libelle = dr.Libelle
                                        If Not dr.IsUnite1Null Then .Unite1 = dr.Unite1
                                        If Not dr.IsUnite2Null Then .Unite2 = dr.Unite2
                                        If Not dr.IsLibUnite1Null Then .LibUnite1 = dr.LibUnite1
                                        If Not dr.IsLibUnite2Null Then .LibUnite2 = dr.LibUnite2
                                    End With
                                    ds.ABonReception_Detail.Rows.Add(drBRd)
                                End If
                            End If
                        Next

                        'Enregistrer en base
                        dtaBR.Update(ds.ABonReception)
                        dtaBR_detail.Update(ds.ABonReception_Detail)
                    End Using
                End Using
                Using fr As New Receptions.FrSaisieBR(CInt(newNDevis))
                    If ownerForm IsNot Nothing Then fr.Owner = ownerForm
                    fr.ShowDialog()
                End Using
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Sub

    Public Shared Sub ModeleToFab(ByVal drMvt As AgrifactTracaDataSet.MouvementRow, Optional ByVal ownerForm As Form = Nothing)
        If MsgBox(String.Format("Voulez-vous créer une Fabrication à partir du modèle {0} ?", drMvt.nPiece), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Demander le multiplicateur à appliquer
            Dim mult As Decimal
            Using param As New FrParamFab(CInt(drMvt.nMouvement))
                If param.ShowDialog(ownerForm) = DialogResult.Cancel Then Exit Sub
                mult = param.Result
            End Using

            Dim newNMvt As Decimal = CopyMvt(drMvt, Stocks.GestionStock.TypeMouvement.Conditionnement, mult, "")

            Using fr As New Fabrications.FrSaisieTransfo(CInt(newNMvt))
                If ownerForm IsNot Nothing Then fr.Owner = ownerForm
                fr.ShowDialog()
            End Using
        End If
    End Sub

    Public Shared Sub FabToModele(ByVal drMvt As AgrifactTracaDataSet.MouvementRow, Optional ByVal ownerForm As Form = Nothing)
        If MsgBox(String.Format("Voulez-vous créer un modèle à partir de la fabrication {0} ?", drMvt.nPiece), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim nomModele As String = InputBox("Entrez le nom du modèle", , "Nouveau Modèle")
            If nomModele = "" Then Exit Sub
            CopyMvt(drMvt, Stocks.GestionStock.TypeMouvement.ModeleFab, 1, nomModele)
            MsgBox("Modèle enregistré", MsgBoxStyle.Information)
        End If
    End Sub

    Private Shared Function CopyMvt(ByVal drMvt As AgrifactTracaDataSet.MouvementRow, ByVal type As Stocks.GestionStock.TypeMouvement, ByVal mult As Decimal, ByVal nPiece As String) As Decimal
        Try
            Dim ds As AgrifactTracaDataSet = Cast(Of AgrifactTracaDataSet)(drMvt.Table.DataSet)
            Cursor.Current = Cursors.WaitCursor

            Dim nMouvement As Decimal = drMvt.nMouvement
            Dim newNMvt As Decimal

            Using dtaMvt As New AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
                Using dtaDetail As New AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
                    'Init les clés
                    ds.Mouvement.InitAutoIncrementSeed(dtaMvt)
                    ds.Mouvement_Detail.InitAutoIncrementSeed(dtaDetail)
                    'Remplir les détails pour le Mvt
                    dtaDetail.FillBynMouvement(ds.Mouvement_Detail, nMouvement)
                    'Recopier la ligne de mouvement
                    Dim drNewMvt As AgrifactTracaDataSet.MouvementRow = ds.Mouvement.NewMouvementRow
                    CopyRow(drMvt, drNewMvt)
                    With drNewMvt
                        .TypeMouvement = type.ToString
                        .nPiece = nPiece
                        If type = Stocks.GestionStock.TypeMouvement.Conditionnement _
                        AndAlso My.Settings.FormatLotFab.Length > 0 Then
                            .nPiece = Microsoft.VisualBasic.Left(Lots.GetNLotFab(CInt(.nMouvement), Now, Convert.ToString(.Item("Description"))), ds.Mouvement.DescriptionColumn.MaxLength)
                        End If
                        .DateModif = Today
                        .DateMouvement = Now
                    End With
                    ds.Mouvement.AddMouvementRow(drNewMvt)
                    newNMvt = drNewMvt.nMouvement

                    'Recopier les lignes de mouvement détail
                    For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In drMvt.GetMouvement_DetailRows
                        Dim drNewDetail As AgrifactTracaDataSet.Mouvement_DetailRow = ds.Mouvement_Detail.NewMouvement_DetailRow
                        CopyRow(dr, drNewDetail)
                        With drNewDetail
                            .nMouvement = newNMvt
                            .SetnLotNull() 'On ne conserve pas les lots
                            'Propager le n° de lot aux lignes de détail pour les produits finis
                            If Not .IsUnite1Null AndAlso .Unite1 > 0 Then
                                .nLot = drNewMvt.nPiece
                            End If
                            If Not .IsUnite1Null Then .Unite1 *= mult
                            If Not .IsUnite2Null Then .Unite2 *= mult
                        End With
                        ds.Mouvement_Detail.AddMouvement_DetailRow(drNewDetail)
                    Next

                    'Enregistrer en base
                    dtaMvt.Update(drNewMvt)
                    dtaDetail.Update(drNewMvt.GetMouvement_DetailRows)
                End Using
            End Using
            Return newNMvt
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function
#End Region

End Class
