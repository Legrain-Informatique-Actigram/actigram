Public Class FrValidAdmin

#Region "Méthodes partagées"
    Public Shared Function ValidAdmin() As Boolean
        If My.Settings.AdminValidated Then
            Return True
        Else
            Using fr As New FrValidAdmin
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Settings.AdminValidated = True
                    Return True
                Else
                    Return False
                End If
            End Using
        End If
    End Function
#End Region

#Region "Page"
    Private Sub FrValidAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxPass.Text = ""
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Me.TxPass.Text = My.Settings.PassAdmin Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Exclamation)
            Me.TxPass.SelectAll()
            Me.TxPass.Focus()
        End If
    End Sub
#End Region

End Class