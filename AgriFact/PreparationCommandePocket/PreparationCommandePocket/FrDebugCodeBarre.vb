Public Class FrDebugCodeBarre

    Private Sub FrDebugCodeBarre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxCode.Text = ""
        TxResult.Text = ""
    End Sub


    Private Sub TxCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxCode.TextChanged
        Dim res As String = ""
        For Each c As Char In TxCode.Text.ToCharArray
            res &= AscW(c).ToString("X2") & " "
        Next
        TxResult.Text = res
    End Sub
End Class