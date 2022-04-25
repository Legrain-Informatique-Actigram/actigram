Public Class FrContactSupport

#Region "Page"
    Private Sub FrContactSupport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
    End Sub
#End Region

    Private Sub lnkMailSupport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMailSupport.LinkClicked
        Process.Start(String.Format("mailto:{0}", My.Settings.SupportMail))
    End Sub
End Class