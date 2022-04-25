Public Class FrMain

    Private Sub ApplicationsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Me.Validate()
        Me.ApplicationsBindingSource.EndEdit()
        Me.ApplicationsTableAdapter.Update(Me.DsActiUpdates.Applications)
    End Sub

    Private Sub FrMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall, CloseReason.FormOwnerClosing, CloseReason.UserClosing
                If Me.DsActiUpdates.HasChanges Then
                    Select Case MsgBox("Enregistrer ?", MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes
                            ApplicationsBindingNavigatorSaveItem_Click(Nothing, Nothing)
                        Case MsgBoxResult.Cancel
                            e.Cancel = True
                    End Select
                End If
        End Select
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.ApplicationsDataGridView, False)
        Me.ApplicationsTableAdapter.Fill(Me.DsActiUpdates.Applications)
        MajBoutons()
    End Sub

    Private Sub ApplicationsBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationsBindingSource.PositionChanged
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbUpdates.Enabled = ApplicationsBindingSource.Position >= 0
    End Sub

    Private Sub TbUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbUpdates.Click
        If Me.ApplicationsBindingSource.Current Is Nothing Then Exit Sub
        Dim drApp As dsActiUpdates.ApplicationsRow = CType(CType(Me.ApplicationsBindingSource.Current, DataRowView).Row, dsActiUpdates.ApplicationsRow)
        If IsDBNull(drApp("Nom")) Then Exit Sub
        Dim fr As New FrUpdates
        fr.AppName = drApp.Nom
        fr.Show(Me)
    End Sub

    Private Sub ApplicationsDataGridView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ApplicationsDataGridView.MouseDoubleClick
        TbUpdates.PerformClick()
    End Sub

    Private Sub TbParametres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbParametres.Click
        Using fr As New FrParametres
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.ApplicationsTableAdapter = New dsActiUpdatesTableAdapters.ApplicationsTableAdapter
            End If
        End Using
    End Sub
End Class
