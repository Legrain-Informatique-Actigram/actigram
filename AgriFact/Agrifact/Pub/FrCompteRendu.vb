Public Class FrCompteRendu

    Public Shared texteCompteRendu As New System.Text.StringBuilder

#Region "Form"
    Private Sub FrCompteRendu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (FrCompteRendu.texteCompteRendu Is Nothing) Then
            Me.TextBox1.Text = FrCompteRendu.texteCompteRendu.ToString().Trim
        End If
    End Sub
#End Region

#Region "ContextMenuStrip1"
    Private Sub EffacerToutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EffacerToutToolStripMenuItem.Click
        Me.TextBox1.Text = String.Empty
        FrCompteRendu.texteCompteRendu = New System.Text.StringBuilder
    End Sub
#End Region

End Class