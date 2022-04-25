Public Class FrImmo

#Region "Form"
    Private Sub FrImmo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.LoadData()
    End Sub

    Private Sub FrImmo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.SommeDeImmobilisationsDataGridView.ClearSelection()
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub AddNewImmoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewImmoToolStripButton.Click
        Dim fr As New FrSaisieImmo()

        fr.ShowDialog()

        Me.LoadData()
    End Sub

    Private Sub CederImmoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CederImmoToolStripButton.Click
        If (Me.ImmobilisationsDataGridView.SelectedRows.Count > 1) Then
            MsgBox("Veuillez ne sélectionner qu'une seule immobilisation.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If

        If (Me.ImmobilisationsDataGridView.SelectedRows.Count <> 0) Then
            Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = CType(CType(Me.ImmobilisationsBindingSource.Current, DataRowView).Row, ImmobilisationsDataSet.ImmobilisationsRow)
            Dim idImmo As New Immobilisations.IdImmo(immobilisationsDR.IDossier, immobilisationsDR.ICpt, immobilisationsDR.IOrdre, immobilisationsDR.IActi)
            Dim fr As New FrSaisieImmo(FrSaisieImmo.Actions.Cession, idImmo)

            If (fr.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Me.LoadData()
            End If
        End If
    End Sub

    Private Sub ModifierToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierToolStripButton.Click
        Me.ModifierImmobilisation()
    End Sub

    Private Sub SupprimerImmoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerImmoToolStripButton.Click
        If (Me.ImmobilisationsDataGridView.SelectedRows.Count <> 0) Then
            Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = CType(CType(Me.ImmobilisationsBindingSource.Current, DataRowView).Row, ImmobilisationsDataSet.ImmobilisationsRow)

            If (MsgBox("Voulez-vous réellement supprimer cette immobilisation ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                Exit Sub
            End If

            If My.Dossier.Principal.DateClotureCompta < immobilisationsDR.IDtAcquis Then
                If My.Dossier.Principal.DateDebutEx > immobilisationsDR.IDtAcquis Then
                    If (MsgBox("Attention : immobilisation ANTERIEURE, voulez-vous vraiment la SUPPRIMER ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If

                Me.SupprimerImmobilisation(immobilisationsDR)

                MsgBox("Immobilisation supprimée.", MsgBoxStyle.Information, "")

                Me.LoadData()
            End If
        End If
    End Sub

    Private Sub ExporterImmoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterImmoToolStripButton.Click
        With Me.SaveFileDialog1
            .DefaultExt = "csv"
            .Filter = "Fichiers csv (*.csv)|*.csv"
            .FileName = String.Format("AgrigestEDI_Amort_{0}_{1:ddMMyyyyhhmmss}.csv", My.User.Name, Now)

            If (.ShowDialog = DialogResult.OK) Then
                Me.ExporterAuFormatCSV(.FileName)
            End If
        End With
    End Sub

    Private Sub ChoixAmortToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChoixAmortToolStripButton.Click
        Dim fr As New FrChoixAmort(Me.ImmobilisationsDataSet)

        fr.ShowDialog(Me)

        'Recalcul des valeurs résiduelles et plus values
        Dim gestionImmo As New Immobilisations.Immobilisation(Immobilisations.Immobilisation.ModeImmo.Calcul)
        Dim dv As New DataView(Me.ImmobilisationsDataSet.Immobilisations, "ITypAmt='D'", "", DataViewRowState.CurrentRows)

        For Each drv As DataRowView In dv
            gestionImmo.CalculerDonneesAmort(drv)
        Next

        Me.LoadData()
    End Sub

    Private Sub SimulationToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimulationToolStripButton.Click
        Dim fr As New FrSimulAmort(Me.ImmobilisationsDataSet)

        fr.ShowDialog()
    End Sub

    Private Sub ImprimerImmoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerImmoToolStripButton.Click
        Dim fr As New FrImpImmo

        fr.ShowDialog()
    End Sub
#End Region

#Region "ImmobilisationsDataGridView"
    Private Sub ImmobilisationsDataGridView_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ImmobilisationsDataGridView.CellMouseDoubleClick
        Me.ModifierImmobilisation()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        Me.ImmobilisationsTableAdapter.FillByIDossier(Me.ImmobilisationsDataSet.Immobilisations, My.User.Name)
        Me.ImmobilisationsBindingSource.Sort = "ICpt, IActi, IOrdre ASC"
        Me.ImmobilisationsBindingSource.ResetBindings(True)

        Me.SommeDeImmobilisationsTableAdapter.FillByIDossier(Me.ImmobilisationsDataSet.SommeDeImmobilisations, My.User.Name)
        'Ajout de la ligne de totalisation
        If (Me.ImmobilisationsDataSet.SommeDeImmobilisations.Rows.Count > 0) Then
            Me.AjouterLigneTotalisation()
        End If
        Me.SommeDeImmobilisationsBindingSource.ResetBindings(True)
        Me.SommeDeImmobilisationsDataGridView.ClearSelection()
    End Sub

    Private Sub ModifierImmobilisation()
        If (Me.ImmobilisationsDataGridView.SelectedRows.Count > 1) Then
            MsgBox("Veuillez ne sélectionner qu'une seule immobilisation.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If

        If (Me.ImmobilisationsDataGridView.SelectedRows.Count <> 0) Then
            Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = CType(CType(Me.ImmobilisationsBindingSource.Current, DataRowView).Row, ImmobilisationsDataSet.ImmobilisationsRow)
            Dim idImmo As New Immobilisations.IdImmo(immobilisationsDR.IDossier, immobilisationsDR.ICpt, immobilisationsDR.IOrdre, immobilisationsDR.IActi)
            Dim fr As New FrSaisieImmo(FrSaisieImmo.Actions.Modif, idImmo)

            If (fr.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Me.LoadData()
            End If
        End If
    End Sub

    Private Sub SupprimerImmobilisation(ByVal immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow)
        Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
            immobilisationsTA.DeleteByIDossier_ICpt_IActi_IOrdre(immobilisationsDR.IDossier, immobilisationsDR.ICpt, _
                                                                immobilisationsDR.IActi, immobilisationsDR.IOrdre)
        End Using
    End Sub

    Private Sub AjouterLigneTotalisation()
        Dim SommeDeImmobilisationsDR As ImmobilisationsDataSet.SommeDeImmobilisationsRow = Me.ImmobilisationsDataSet.SommeDeImmobilisations.NewSommeDeImmobilisationsRow()

        SommeDeImmobilisationsDR.ICpt = "Total"
        SommeDeImmobilisationsDR.SommeDeIValAcquis = CDec(Me.ImmobilisationsDataSet.SommeDeImmobilisations.Compute("SUM(SommeDeIValAcquis)", ""))
        SommeDeImmobilisationsDR.SommeDeIAmtExTot = CDec(Me.ImmobilisationsDataSet.SommeDeImmobilisations.Compute("SUM(SommeDeIAmtExTot)", ""))
        SommeDeImmobilisationsDR.SommeDeIAmtCumTot = CDec(Me.ImmobilisationsDataSet.SommeDeImmobilisations.Compute("SUM(SommeDeIAmtCumTot)", ""))
        SommeDeImmobilisationsDR.SommeDeIValResid = CDec(Me.ImmobilisationsDataSet.SommeDeImmobilisations.Compute("SUM(SommeDeIValResid)", ""))

        Me.ImmobilisationsDataSet.SommeDeImmobilisations.Rows.Add(SommeDeImmobilisationsDR)
    End Sub

    Private Sub ExporterAuFormatCSV(ByVal nomFichier As String)
        Dim immobilisationsImpressionDT As ImmobilisationsDataSet.ImmobilisationsImpressionDataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsImpressionTableAdapter
                immobilisationsImpressionDT = immobilisationsTA.GetDataByIDossier(My.User.Name)
            End Using

            Dim expCsv As New ExportCsv(immobilisationsImpressionDT, ExportCsv.SeparateurEnum.POINTVIRGULE, True, nomFichier)

            expCsv.Exporter(Nothing)

            MsgBox("Export terminé.", MsgBoxStyle.Information, "")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

End Class