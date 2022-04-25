Public Class FrPassCloture

#Region "Page"
    Private Sub FrPassCloture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.PasswordTextBox.Select()
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PasswordTextBox.Text = My.Settings.AdminPassw Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Information, "Mot de passe")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function VerifAdmin() As Boolean

        If My.Settings.VerifAdminOK Then
            Return True
        Else
            Dim res As Boolean = False
            Using fr As New FrPassCloture
                res = (fr.ShowDialog = Windows.Forms.DialogResult.OK)
                My.Settings.VerifAdminOK = res
            End Using
            Return res
        End If
    End Function
#End Region

End Class
