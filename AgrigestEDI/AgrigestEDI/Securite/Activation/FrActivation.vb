Namespace Securite.Activation
    Public Class FrActivation
        Inherits System.Windows.Forms.Form

        Public Cle As Cle = Nothing

#Region "Propriétés"
        Public Property CodeUtilisateur() As String
            Get
                Return Me.TxCodeUtilisateur.Text
            End Get
            Set(ByVal Value As String)
                Me.TxCodeUtilisateur.Text = Value
            End Set
        End Property
#End Region

#Region "Form"
        Private Sub FrActivation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            lbTel.Text = My.Settings.SupportTel
            If Me.CodeUtilisateur = "" Then
                Me.TxCodeUtilisateur.Text = Securite.Utils.GetNSerie
            End If
            If Me.Cle IsNot Nothing Then
                SaisieCle1.Cle = Me.Cle.ToLong
                Me.Cle = Nothing
            End If
            'TxCodeUtilisateur.Enabled = (FrMDI.CG <> "CO")
            BtOK.Enabled = (SaisieCle1.CleText.Length = 16)
            lbValid.Text = ""
        End Sub
#End Region

#Region "Boutons"
        Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim cl As Cle = Cle.Parse(XorEncryption.EnCrypt(Me.SaisieCle1.Cle))
                With cl
                    If .IsValid(TxCodeUtilisateur.Text.Trim) Then
                        Cle = cl
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        Me.lbValid.ForeColor = Color.Red
                        If Not .IsCodeValid(TxCodeUtilisateur.Text.Trim) Then
                            Me.lbValid.Text = My.Resources.Strings.Cle_CodeUtilisateurInvalide
                        ElseIf .DateValidite.Date < Now.Date Then
                            Me.lbValid.Text = String.Format(My.Resources.Strings.Cle_Expiree, .DateValidite)
                        Else
                            Me.lbValid.Text = My.Resources.Strings.Cle_PasValide
                        End If
                    End If
                End With
            Catch ex As Exception
                'ajout TV 29/05/2012
                MsgBox(ex.Message & ex.StackTrace)
                '-------------------

                Debug.WriteLine(ex.ToString)
                Me.lbValid.ForeColor = Color.Red
                Me.lbValid.Text = My.Resources.Strings.Cle_PasValide
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
#End Region

        Private Sub SaisieCle1_CleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaisieCle1.CleChanged
            BtOK.Enabled = (SaisieCle1.CleText.Length = 16)
        End Sub

    End Class
End Namespace