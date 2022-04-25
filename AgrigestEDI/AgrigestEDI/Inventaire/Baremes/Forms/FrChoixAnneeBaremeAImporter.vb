Public Class FrChoixAnneeBaremeAImporter

#Region "Button"
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "TextBoxAnneeBaremeAImporter"
    Private Sub TextBoxAnneeBaremeAImporter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAnneeBaremeAImporter.KeyPress
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

End Class