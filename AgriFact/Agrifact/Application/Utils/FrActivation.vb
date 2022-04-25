Namespace Securite.Activation
    Public Class FrActivation
        Inherits System.Windows.Forms.Form

        Private Sub FrActivation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            Me.TxCodeUtilisateur.Text = Actigram.Securite.GetLicence.GetNSerie
            'Me.TxCodeUtilisateur.Text = "D083D748"
            Dim Cle As String = Actigram.Securite.GetLicence.GetCle
            If Cle IsNot Nothing Then
                SaisieCle1.CleText = Cle
                Cle = Nothing
            End If
            BtOK.Enabled = (SaisieCle1.CleText.Length = 16)
            lbValid.Text = ""
        End Sub

        Private Sub SaisieCle1_CleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaisieCle1.CleChanged
            BtOK.Enabled = (SaisieCle1.CleText.Length = 16)
        End Sub

        Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
            Try
                Cursor.Current = Cursors.WaitCursor
                If Actigram.Securite.GetLicence.IsValideCle(SaisieCle1.CleText) Then
                    Actigram.Securite.GetLicence.SetCleReg(SaisieCle1.CleText)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    Me.lbValid.ForeColor = Color.Red
                    Me.lbValid.Text = "La clé n'est pas valide"
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)
                Me.lbValid.ForeColor = Color.Red
                Me.lbValid.Text = "La clé n'est pas valide"
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace