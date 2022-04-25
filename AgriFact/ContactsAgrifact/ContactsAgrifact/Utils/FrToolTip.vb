Public Class FrToolTip

    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle = (parameters.ClassStyle Or &H20000)
            Return parameters
        End Get
    End Property

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            lbTooltip.Text = value
        End Set
    End Property

    Private Sub FrToolTip_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Me.Close()
    End Sub

    Private Sub FrToolTip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbTooltip.Text = ""
        lbTooltip.Text = Me.Text
        Me.Height = lbTooltip.Height + 10
        Me.Width = lbTooltip.Width + 10
    End Sub

End Class