Public Class GestionFactureMasse

    Private WithEvents frRecherche As GRC.FrRecherche

    Private maTable As String
    Private dsBase As DataSet
    Private lstClients As ArrayList
    Private selectionMultiple As Boolean = True
    Private critereClients As String

    Public Sub New()
        maTable = "Entreprise"
    End Sub

    Public Sub New(ByVal ds As DataSet)
        Me.New()
        Me.dsBase = ds
    End Sub

    'Ouvre la fenetre de séléction des clients et retourne la liste des nClient séléctionnés
    Private Sub OuvrirSelectionClients(Optional ByVal critere As String = "")
        Me.critereClients = critere
        frRecherche = New GRC.FrRecherche(dsBase, maTable)
        With frRecherche
            .Show()
        End With
    End Sub

    Public Function SelectionnerClients(ByVal ds As DataSet, Optional ByVal critere As String = "") As ArrayList
        dsBase = ds
        OuvrirSelectionClients(critere)
        While lstClients Is Nothing
            Application.DoEvents()
        End While
        Return lstClients
    End Function

    Private Sub LancerLaRecherche(ByVal strCritere As String) Handles frRecherche.AffectuerRecherche
        Dim dvTmp As DataView
        dvTmp = New DataView(dsBase.Tables(maTable))
        If Me.critereClients.Length > 0 Then
            If strCritere.Length > 0 Then
                strCritere &= " AND "
            End If
            strCritere &= Me.critereClients
        End If

        dvTmp.RowFilter = strCritere
        dvTmp.Sort = "Nom"

        Dim lst As New ArrayList
        Select Case dvTmp.Count
            Case 0
                MsgBox("Pas de résultat disponible")
            Case Else
                Dim frSelection As New FrSelectionMultiple
                With frSelection
                    .Text = "Sélection des clients"
                    .lstContents.SelectionMode = CType(IIf(selectionMultiple, SelectionMode.MultiExtended, SelectionMode.One), SelectionMode)
                    .lstContents.Items.Clear()
                    For Each rwv As DataRowView In dvTmp
                        If Not IsDBNull(rwv("Nom")) Then
                            .lstContents.Items.Add(New FrSelectionMultiple.ListItem(CType(rwv("Nom"), String), rwv("nEntreprise")))
                        End If
                    Next
                    If .ShowDialog = DialogResult.OK Then
                        For Each item As FrSelectionMultiple.ListItem In .lstContents.SelectedItems
                            lst.Add(item.Value)
                        Next
                    End If
                End With
        End Select
        frRecherche.Close()
        lstClients = lst
    End Sub

    Public Sub GenererFactures(ByVal lstFacturesSource As List(Of Integer), ByVal type As Pieces.TypePieces)
        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            DefinitionDonnees.Instance.Fill(ds, type.ToString, s)
            DefinitionDonnees.Instance.Fill(ds, type.ToString & "_Detail", s)
            DefinitionDonnees.Instance.Fill(ds, "Niveau2", s)
            DefinitionDonnees.Instance.Fill(ds, "ListeChoix", s)
            GenererFactures(lstFacturesSource, ds)
            s.UpdateTable(ds, type.ToString, Nothing)
            s.UpdateTable(ds, type.ToString & "_Detail", Nothing)
        End Using
    End Sub

    'Duplique les factures indiquées en permettant de sélectionner les clients pour lesquels les factures doivent etre générées
    Public Sub GenererFactures(ByVal lstFacturesSource As List(Of Integer), ByVal ds As DataSet)
        dsBase = ds
        OuvrirSelectionClients()
        While lstClients Is Nothing
            Application.DoEvents()
        End While

        If lstClients.Count > 0 Then
            For Each nDevis As Integer In lstFacturesSource
                For Each nClient As Integer In lstClients
                    CopierFacture(nDevis, nClient)
                Next
            Next
            MessageBox.Show("Opération Terminée")
        End If
    End Sub

    Public Function SelectionnerUnClient(Optional ByVal ds As DataSet = Nothing) As Integer
        If Not ds Is Nothing Then
            Me.dsBase = ds
        End If
        If Me.dsBase Is Nothing Then Exit Function
        Me.selectionMultiple = False
        OuvrirSelectionClients()
        While lstClients Is Nothing
            Application.DoEvents()
        End While

        If lstClients.Count > 0 Then
            Return CInt(lstClients(0))
        End If
    End Function

    Private Sub CopierFacture(ByVal nDevis As Integer, ByVal nClient As Integer)

        Dim rwFactureSrc As DataRow = dsBase.Tables("VFacture").Select("nDevis=" & nDevis)(0)
        Dim rwFactureDest As DataRow = dsBase.Tables("VFacture").NewRow
        'Initialiser les valeurs de la ligne Facture
        CopyRow(rwFactureSrc, rwFactureDest)
        'Modifier les valeurs de la facture qui doivent etre modifiées
        With rwFactureDest
            .Item("nClient") = nClient
            .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.VFacture)
            .Item("AdresseFacture") = AdresseFacturation(nClient)
            .Item("DateFacture") = Today
            .Item("Paye") = False
            .Item("ExportCompta") = False
            .Item("DateExportCompta") = DBNull.Value
            '.Item("DateEcheance") = DBNull.Value
            .Item("DateRelance1") = DBNull.Value
            .Item("DateRelance2") = DBNull.Value
            .Item("DateImpr") = DBNull.Value
        End With
        dsBase.Tables("VFacture").Rows.Add(rwFactureDest)

        'Copier telles qu'elles les lignes détails de la facture
        For Each rwDetailSrc As DataRow In rwFactureSrc.GetChildRows("VFactureVFacture_Detail")
            Dim rwDetailDest As DataRow = dsBase.Tables("VFacture_Detail").NewRow
            CopyRow(rwDetailSrc, rwDetailDest)
            rwDetailDest.SetParentRow(rwFactureDest)
            dsBase.Tables("VFacture_Detail").Rows.Add(rwDetailDest)
        Next

        'MAJ la base de données
        'On est obligé de le faire à chaque facture pour que le calcul du prochain n° soit bon
        'FrDonnees.ConfigSqlServer.UpdateAdapters(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)
    End Sub

    Public Function AdresseFacturation(ByVal nClient As Integer) As String
        Return AdresseFacturation(dsBase, nClient)
    End Function

    Public Shared Function AdresseFacturation(ByVal dsBase As DataSet, ByVal nClient As Integer) As String
        Dim rw As DataRow = dsBase.Tables("Entreprise").Select("nEntreprise=" & nClient)(0)

        Dim strAdresse As String = String.Format("{4} {0}" & vbCrLf & "{1}" & vbCrLf & "{2} {3}", rw("Nom"), rw("Adresse"), rw("CodePostal"), rw("Ville"), rw("Civilite"))

        If rw.Table.Columns.Contains("SuffixePostal") AndAlso Not IsDBNull(rw("SuffixePostal")) Then
            strAdresse &= " " & CStr(rw("SuffixePostal"))
        End If

        If rw.Table.Columns.Contains("Pays") AndAlso Not IsDBNull(rw("Pays")) Then
            Dim strPays As String = CStr(rw("Pays"))
            If strPays.Length > 0 Then
                strAdresse &= vbCrLf & strPays
            End If
        End If
        Return strAdresse
    End Function

End Class
