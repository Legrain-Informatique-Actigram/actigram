Imports CrystalDecisions.CrystalReports.Engine

Public Class FrPlanComptable
    Implements IPrechargement

#Region "Page"
    Private Sub FrPlanComptable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        'ConfigNumericControl(TxFilterPlc)
        AddHandler Me.DsPLC.PlanComptable.PlanComptableRowDeleting, AddressOf VerifSuppr
        AddHandler Me.PlanComptableDataGridView.CellParsing, AddressOf dg_CellParsing
        AddHandler Me.PlanComptableDataGridView.DataError, AddressOf dg_DataError
        ApplyStyle(Me.PlanComptableDataGridView, False)
        ChargerDossier()
    End Sub

    Private Sub FrPlanComptable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DsPLC.HasChanges Then
            Select Case MsgBox(My.Resources.Strings.EnregistrerLesModifications, MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger
        Return True
    End Function

    Private Sub Enregistrer()
        Me.Validate()
        Me.PlanComptableBindingSource.EndEdit()
        Me.PlanComptableTableAdapter.Update(Me.DsPLC.PlanComptable)
        Me.ComptesTableAdapter.Update(Me.DsPLC.Comptes)
        Me.ActivitesTableAdapter.Update(Me.DsPLC.Activites)
    End Sub

    Private Sub ChargerDossier()
        Me.Cursor = Cursors.WaitCursor
        With Me.DsPLC
            .EnforceConstraints = False
            Me.ActivitesTableAdapter.FillByDossier(.Activites, My.User.Name)
            Me.ComptesTableAdapter.FillByDossier(.Comptes, My.User.Name)
            Me.PlanComptableTableAdapter.FillByDossier(.PlanComptable, My.User.Name)
            .EnforceConstraints = True
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VerifSuppr(ByVal sender As Object, ByVal e As dsPLC.PlanComptableRowChangeEvent)
        If e.Action = DataRowAction.Delete Then
            If MouvementsTableAdapter.IsCompteUsed(e.Row.PlDossier, e.Row.PlCpt, e.Row.PlActi).GetValueOrDefault > 0 Then
                Throw New UserCancelledException(My.Resources.Strings.SuppressionAnnulee)
            Else
                If MsgBox(My.Resources.Strings.PLC_VerifSupprCompte, MsgBoxStyle.OkCancel, My.Resources.Strings.Suppression) = MsgBoxResult.Cancel Then Throw New UserCancelledException("Suppression annulée")
            End If
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ModifierLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierLeCompteToolStripMenuItem.Click
        If Me.PlanComptableBindingSource.Current Is Nothing Then Exit Sub
        Dim drPlc As dsPLC.PlanComptableRow = CType(CType(Me.PlanComptableBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
        Using fr As New FrAssistantCreationCompte()
            With fr
                .Mode = FrAssistantCreationCompte.ModeAssistant.Modification
                .nCompte = drPlc.PlCpt
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ChargerDossier()
                    If fr.NouveauCompte IsNot Nothing Then
                        Me.PlanComptableBindingSource.Position = Me.PlanComptableBindingSource.Find("PlCpt", fr.NouveauCompte.PlCpt)
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub SupprimerLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SupprimerLeCompteToolStripMenuItem.Click, BindingNavigatorDeleteItem.Click
        Try
            Dim drplc As dsPLC.PlanComptableRow = CType(CType(Me.PlanComptableBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
            Dim drCpt As dsPLC.ComptesRow = drplc.ComptesRowParent
            Dim drActi As dsPLC.ActivitesRow = drplc.ActivitesRowParent
            Me.PlanComptableBindingSource.RemoveCurrent()
            If drCpt.GetPlanComptableRows.Length = 0 Then drCpt.Delete()
            If drActi.GetPlanComptableRows.Length = 0 Then drActi.Delete()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub VisualiserLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualiserLeCompteToolStripMenuItem.Click
        If Me.PlanComptableBindingSource.Current Is Nothing Then Exit Sub
        Dim drPlc As dsPLC.PlanComptableRow = CType(CType(Me.PlanComptableBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
        Using fr As New FrVisuCompte()
            With fr
                .nCompte = drPlc.PlCpt
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub CMenuPlanCNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMenuPlanCNew.Click
        Using fr As New FrAssistantCreationCompte()
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDossier()
                If fr.NouveauCompte IsNot Nothing Then
                    Me.PlanComptableBindingSource.Position = Me.PlanComptableBindingSource.Find("PlCpt", fr.NouveauCompte.PlCpt)
                End If
            End If
        End Using
    End Sub

    Private Sub CMenuPlanCModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMenuPlanCModif.Click
        Using fr As New FrAssistantCreationCompte()
            With fr
                .Filter = Me.TxFilterPlc.Text.Trim
                .Mode = FrAssistantCreationCompte.ModeAssistant.Modification
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ChargerDossier()
                End If
            End With
        End Using
    End Sub

    Private Sub CMenuActiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMenuActiNew.Click
        Using fr As New FrAssistantCreationActivite(DsPLC)
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDossier()
                If fr.NouveauActivite IsNot Nothing Then
                    Me.PlanComptableBindingSource.Position = Me.PlanComptableBindingSource.Find("PlCpt", fr.NouveauActivite.PlCpt)
                End If
            End If
        End Using
    End Sub

    Private Sub CMenuActiModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMenuActiModif.Click
        Using fr As New FrAssistantCreationActivite(DsPLC)
            With fr
                '.Filter = Me.TxFilterPlc.Text.Trim
                .Mode = FrAssistantCreationActivite.ModeAssistant.Modification
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ChargerDossier()
                End If
            End With
        End Using
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        Cursor.Current = Cursors.WaitCursor
        Dim ds As DataSet = ImprPLC.GetDataRptPLC()
        Using report As ReportDocument = ImprPLC.PrepareRptPLC(ds, True)
            ImprPLC.AffichDonneesGen(report)
            Using fr As New EcranCrystal(report)
                fr.ShowDialog()
            End Using
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub PlanComptableBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanComptableBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub
#End Region

#Region "PlanComptableDataGridView"
    Private Sub PlanComptableDataGridView_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PlanComptableDataGridView.CellContentDoubleClick
        If Me.PlanComptableBindingSource.Current Is Nothing Then Exit Sub
        Dim drPlc As dsPLC.PlanComptableRow = CType(CType(Me.PlanComptableBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
        Using fr As New FrVisuCompte()
            With fr
                .nCompte = drPlc.PlCpt
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub PlanComptableDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PlanComptableDataGridView.RowEnter
        If Me.PlanComptableDataGridView.CurrentRow Is Nothing Then Exit Sub
        Dim r As DataGridViewRow = Me.PlanComptableDataGridView.CurrentRow
        Try
            If r.DataBoundItem Is Nothing Then Exit Sub
        Catch ex As Exception
            Exit Sub
        End Try
        Dim drPlc As dsPLC.PlanComptableRow = CType(CType(r.DataBoundItem, DataRowView).Row, dsPLC.PlanComptableRow)
        r.Cells(PlRepQt1.Name).ReadOnly = (drPlc.IsCU1Null OrElse drPlc.CU1.Trim.Length = 0)
        r.Cells(PlRepQt2.Name).ReadOnly = (drPlc.IsCU2Null OrElse drPlc.CU2.Trim.Length = 0)
    End Sub

    Private Sub PlanComptableDataGridView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PlanComptableDataGridView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hi As DataGridView.HitTestInfo = PlanComptableDataGridView.HitTest(e.X, e.Y)
            If hi.Type = DataGridViewHitTestType.Cell Or hi.Type = DataGridViewHitTestType.RowHeader Then
                Dim r As DataGridViewRow = PlanComptableDataGridView.Rows(hi.RowIndex)
                If r.DataBoundItem IsNot Nothing Then
                    PlanComptableBindingSource.Position = PlanComptableBindingSource.IndexOf(r.DataBoundItem)
                End If
                r.Selected = True
            End If
        End If
    End Sub
#End Region

#Region "Filtre comptes"
    Private Sub TxFilterPlc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxFilterPlc.TextChanged
        If TxFilterPlc.Text.Length = 0 Then
            PlanComptableBindingSource.Filter = ""
        Else
            PlanComptableBindingSource.Position = -1
            PlanComptableBindingSource.Filter = String.Format("PlCpt like '{0}*'", TxFilterPlc.Text.Replace("'", "''"))
            TxFilterPlc.SelectionStart = TxFilterPlc.Text.Length
        End If
    End Sub
#End Region

End Class