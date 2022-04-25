Public Class FrChoixPrems

#Region "Page"
    Private Sub FrPassCloture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
    End Sub
#End Region

#Region "Boutons"
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btDemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDemo.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub BtImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImport.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub BtRestaurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRestaurer.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
#End Region

End Class
