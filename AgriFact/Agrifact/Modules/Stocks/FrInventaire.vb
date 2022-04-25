Public Class FrInventaire

    Private dtRecap As Date
    Private dtInv As Date
    Private depot As String
    Private gestionLot As Boolean

    Private modif As Boolean

#Region "Form"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.InventaireDataGridView, False)
        ChargerInventaire()
        ConfigDataTableEvents(Me.StocksDataSet.Inventaire, AddressOf MajBoutons)
        TxRecherche_TextChanged(Nothing, Nothing)
        MajBoutons()
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If modif Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "Données"   
    Private Sub ChargerInventaire()
        Using fr As New FrInventaireOptions
            If fr.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            dtInv = fr.DateInventaire
            depot = fr.NomDepot
            gestionLot = fr.GestionLots
        End Using

        dtRecap = dtInv

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.InventaireBindingSource.SuspendBinding()
            ChargerInventaire(StocksDataSet, dtInv, dtRecap, depot, gestionLot)
            Me.StocksDataSet.Inventaire.AcceptChanges()
            Me.InventaireBindingSource.ResumeBinding()
            Me.Text = String.Format("Inventaire du {0:dd/MM/yyyy} pour le dépot {1}", Me.dtInv, Me.depot)
        Finally
            Cursor.Current = Cursors.Default
        End Try
        modif = False
    End Sub

    Private Shared Sub ChargerInventaire(ByVal StocksDataSet As StocksDataSet, ByVal dtInv As Date, ByVal dtRecap As Date, ByVal depot As String, ByVal gestionLot As Boolean)
        If StocksDataSet Is Nothing Then
            StocksDataSet = New StocksDataSet
        End If

        Using dta As New StocksDataSetTableAdapters.InventaireTA
            dta.FillInv(StocksDataSet.Inventaire, dtRecap, dtInv, depot, gestionLot)
        End Using

        'Chercher si un Inventaire existe déjà
        Using dta As New StocksDataSetTableAdapters.MouvementTA
            dta.FillByTypeDateDepot(StocksDataSet.Mouvement, Stocks.TypeMouvement.Inventaire.ToString, dtInv, depot)
        End Using

        Dim drMvt As StocksDataSet.MouvementRow

        If StocksDataSet.Mouvement.Count > 0 Then
            drMvt = StocksDataSet.Mouvement(0)

            Using dta As New StocksDataSetTableAdapters.Mouvement_DetailTA
                dta.FillBynMouvement(StocksDataSet.Mouvement_Detail, drMvt.nMouvement)
            End Using
        End If

        If StocksDataSet.Mouvement_Detail.Count > 0 Then
            For Each drMD As StocksDataSet.Mouvement_DetailRow In StocksDataSet.Mouvement_Detail
                Dim testNull As String

                If drMD.IsnLotNull Then testNull = "(nLot is null or nLot='')" Else testNull = String.Format("nLot='{0}'", drMD.nLot.Replace("'", "''"))

                Dim q As String = String.Format("CodeProduit='{0}' And {1}", drMD.CodeProduit.Replace("'", "''"), testNull)
                Dim drInv As StocksDataSet.InventaireRow = SelectSingleRow(Of StocksDataSet.InventaireRow)(StocksDataSet.Inventaire, q, "")

                If drInv IsNot Nothing Then
                    drInv.QteU1Depart -= drMD.Unite1
                    drInv.QteU2Depart -= drMD.Unite2

                    If dtRecap.Date = dtInv.Date Then
                        drInv.DepartU1 -= drMD.Unite1
                        drInv.DepartU2 -= drMD.Unite2
                    End If

                    If drMD.Unite1 > 0 Then
                        drInv.EntréeU1 -= drMD.Unite1
                        drInv.EntréeU2 -= drMD.Unite2
                    Else
                        drInv.SortieU1 -= drMD.Unite1
                        drInv.SortieU2 -= drMD.Unite2
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Enregistrer()
        Me.Validate()

        Me.InventaireBindingSource.EndEdit()

        If Me.StocksDataSet.HasChanges Then
            Try
                Cursor.Current = Cursors.WaitCursor

                Me.StocksDataSet.Mouvement.InitAutoIncrementSeed()
                Me.StocksDataSet.Mouvement_Detail.InitAutoIncrementSeed()

                'Il faut remettre tout ca dans le mouvement
                Dim drMvt As StocksDataSet.MouvementRow

                If Me.StocksDataSet.Mouvement.Count > 0 Then
                    drMvt = Me.StocksDataSet.Mouvement(0)
                    drMvt.DateModif = Now.Date
                    'On supprime tout pour réécrire
                    For Each dr As StocksDataSet.Mouvement_DetailRow In drMvt.GetMouvement_DetailRows
                        dr.Delete()
                    Next
                Else
                    drMvt = StocksDataSet.Mouvement.NewMouvementRow

                    With drMvt
                        .nPiece = .nMouvement.ToString
                        .DateMouvement = Me.dtInv
                        .DateModif = Now.Date
                        .TypeMouvement = Stocks.TypeMouvement.Inventaire.ToString
                        .DepotDest = Me.depot
                        .DepotDepart = ""
                        .Description = Me.Text
                    End With

                    StocksDataSet.Mouvement.AddMouvementRow(drMvt)
                End If

                Dim n As Integer = 0
                For Each drInv As StocksDataSet.InventaireRow In Me.StocksDataSet.Inventaire
                    If drInv.EcartU1 <> 0 Then
                        n += 1

                        Dim drMvtD As StocksDataSet.Mouvement_DetailRow = StocksDataSet.Mouvement_Detail.NewMouvement_DetailRow

                        With drMvtD
                            .nMouvement = drMvt.nMouvement
                            .nLigne = n
                            If Not drInv.IsnLotNull Then .nLot = drInv.nLot
                            .CodeProduit = drInv.CodeProduit
                            .Libelle = drInv.Libelle
                            .Unite1 = drInv.EcartU1
                            .Unite2 = drInv.EcartU2
                            If Not drInv.IsLibUnite1Null Then .LibUnite1 = drInv.LibUnite1
                            If Not drInv.IsLibUnite2Null Then .LibUnite2 = drInv.LibUnite2
                        End With
                        StocksDataSet.Mouvement_Detail.AddMouvement_DetailRow(drMvtD)
                    End If
                Next

                'Enregistrement en base
                Me.MouvementTA.Update(StocksDataSet.Mouvement)
                Me.Mouvement_DetailTA.Update(StocksDataSet.Mouvement_Detail)

                Me.StocksDataSet.Inventaire.AcceptChanges()
                modif = True
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.InventaireBindingSource.EndEdit()
        If Me.StocksDataSet.HasChanges Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function
#End Region

#Region "Toolbar"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(Me.StocksDataSet, "RptInventaire.rpt")
        fr.Parametres.EnTete = Me.Text
        fr.Show()
    End Sub

    Private Sub TbCancelFiltre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCancelFiltre.Click
        TxRecherche.Text = ""
        TxRecherche.Focus()
    End Sub

    Private Sub TxRecherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRecherche.TextChanged
        Dim q As String = TxRecherche.Text.Trim
        Dim flt As String = ""
        If q.Length > 0 Then
            flt = String.Format("CodeProduit like '{0}' OR Famille like '{0}' OR Libelle like '{0}' OR nLot like '{0}'", "%" & q.Replace("'", "''") & "%")
        End If
        Me.InventaireBindingSource.Filter = flt
        Me.TbCancelFiltre.Visible = flt.Length > 0
    End Sub
#End Region

#Region "InventaireDataGridView"
    Private Sub InventaireDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles InventaireDataGridView.CellValueChanged
        If (e.RowIndex > -1) Then
            If CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

            'Si modification de la quantité U1 - recalcul des infos de U2
            If (InventaireDataGridView.Columns(e.ColumnIndex).DataPropertyName = "QteU1") Then
                Dim inventaireRow As StocksDataSet.InventaireRow = CType(CType(CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem, DataRowView).Row, StocksDataSet.InventaireRow)

                If Not (inventaireRow.IsEcartU1Null) Then
                    'Recherche le coeffU2 du produit
                    Dim coefU2 As Decimal = 0

                    Using produitTA As New StocksDataSetTableAdapters.ProduitTableAdapter
                        Dim produitDT As StocksDataSet.ProduitDataTable = produitTA.GetDataByCodeProduit(inventaireRow.CodeProduit)

                        For Each produitDR As StocksDataSet.ProduitRow In produitDT.Rows
                            If Not (produitDR.IsCoefU2Null) Then
                                coefU2 = produitDR.CoefU2
                            End If
                        Next
                    End Using

                    inventaireRow.QteU2 = inventaireRow.QteU1 * coefU2
                End If
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        TbSave.Enabled = Me.StocksDataSet.HasChanges
    End Sub

    Public Shared Sub ImprimerInventaire(ByVal dtInv As Date, ByVal depot As String, Optional ByVal gestionLot As Boolean = False)
        Dim ds As New StocksDataSet
        ChargerInventaire(ds, dtInv, dtInv, depot, gestionLot)
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(ds, "RptInventaire.rpt")
        With fr.Parametres
            .EnTete = String.Format("Inventaire du {0:dd/MM/yyyy} pour le dépot {1}", dtInv, depot)
            .SetValue("DtDeb", dtInv)
            .SetValue("DtInv", dtInv)
        End With
        fr.Show()
    End Sub
#End Region

End Class