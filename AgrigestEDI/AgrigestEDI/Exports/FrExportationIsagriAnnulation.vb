Imports System.Data.OleDb

Public Class FrExportationIsagriAnnulation

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim conn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Try
                Dim sql As String = String.Format("Select distinct DateExport from Pieces where PDossier='{0}' and not DateExport is null order by DateExport desc", My.User.Name)
                Dim dt As DataTable = UtilBase.ExecuteDataTable(sql, conn)
                With ChkExports
                    .BeginUpdate()
                    With .Items
                        .Clear()
                        For Each dr As DataRow In dt.Rows
                            .Add(New ListboxItem(String.Format("{0:ddd dd MMMM yyyy}", dr("DateExport")), dr("DateExport")), False)
                        Next
                    End With
                    .EndUpdate()
                End With
            Finally
                If Not conn Is Nothing AndAlso conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If ChkExports.CheckedItems.Count > 0 Then
            If MsgBox(My.Resources.Strings.Export_AskAnnulation, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim conn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDbTransaction = Nothing
            Try
                'Maj de la base
                conn.Open()
                t = conn.BeginTransaction
                For Each i As ListboxItem In ChkExports.CheckedItems
                    UtilBase.ExecuteNonQuery(String.Format("UPDATE Pieces SET Exporte=False, DateExport=Null WHERE PDossier='{1}' AND DateExport=#{0:MM/dd/yyyy}#", i.Value, My.User.Name), t)
                Next
                t.Commit()
                conn.Close()

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                If Not t Is Nothing Then t.Rollback()
                Throw ex
            Finally
                If Not conn Is Nothing AndAlso conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
        End If
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

End Class
