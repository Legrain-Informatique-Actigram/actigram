Public Class FrAuthentification

    Private _Exploitation As Exploitation

#Region "Constructeurs"
    Public Sub New(ByVal expl As Exploitation)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._Exploitation = expl
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim motDePasseExpl As String = String.Empty

        If Not (String.IsNullOrEmpty(Me._Exploitation.MotDePasse)) Then
            motDePasseExpl = Me.rc4(Me._Exploitation.MotDePasse, "qlR_82")

            If (motDePasseExpl = Me.MotDePasseTextBox.Text) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Mot de passe incorrect.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function rc4(ByVal message As String, ByVal motdepasse As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cipher As New System.Text.StringBuilder
        Dim returnCipher As String = String.Empty
        Dim sbox As Integer() = New Integer(256) {}
        Dim cle As Integer() = New Integer(256) {}
        Dim intLength As Integer = motdepasse.Length
        Dim a As Integer = 0

        While a <= 255
            Dim ctmp As Char = (motdepasse.Substring((a Mod intLength), 1).ToCharArray()(0))
            cle(a) = Microsoft.VisualBasic.Strings.Asc(ctmp)
            sbox(a) = a
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While

        Dim x As Integer = 0
        Dim b As Integer = 0

        While b <= 255
            x = (x + sbox(b) + cle(b)) Mod 256
            Dim tempSwap As Integer = sbox(b)
            sbox(b) = sbox(x)
            sbox(x) = tempSwap
            System.Math.Max(System.Threading.Interlocked.Increment(b), b - 1)
        End While

        a = 1

        While a <= message.Length
            Dim itmp As Integer = 0
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            itmp = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = itmp
            Dim k As Integer = sbox((sbox(i) + sbox(j)) Mod 256)
            Dim ctmp As Char = message.Substring(a - 1, 1).ToCharArray()(0)
            itmp = Asc(ctmp)
            Dim cipherby As Integer = itmp Xor k
            cipher.Append(Chr(cipherby))
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While

        returnCipher = cipher.ToString
        cipher.Length = 0

        Return returnCipher
    End Function
#End Region

End Class