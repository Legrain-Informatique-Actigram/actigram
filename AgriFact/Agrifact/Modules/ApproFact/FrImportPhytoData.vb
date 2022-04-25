Public Class FrImportPhytoData

#Region "Form"
    Private Sub FrImportPhytoData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        TxtChemin.Text = String.Empty
    End Sub
#End Region

#Region "Button"
    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Hide()

            GestionApproFact.Importer(TxtChemin.Text, ChkNouveauInactif.Checked)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Me.Close()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtParcourir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtParcourir.Click
        With Me.openDlg
            If .ShowDialog = DialogResult.OK Then
                Me.TxtChemin.Text = .FileName
            End If
        End With
    End Sub
#End Region

End Class