Public Class FrChoixCession

#Region "Propriétés"
    Public ReadOnly Property IsPartielle() As Boolean
        Get
            Return Me.PartielleRadioButton.Checked
        End Get
    End Property
#End Region

#Region "Form"
    Private Sub FrChoixCession_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TotaleRadioButton.Checked = True
    End Sub
#End Region

End Class