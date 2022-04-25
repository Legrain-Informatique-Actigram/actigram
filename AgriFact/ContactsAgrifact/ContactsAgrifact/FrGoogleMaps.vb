Public Class FrGoogleMaps


    Private _SearchUrl As String
    Public Property SearchUrl() As String
        Get
            Return _SearchUrl
        End Get
        Set(ByVal value As String)
            _SearchUrl = value
            If loaded Then LoadUrl()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal searchUrl As String)
        Me.New()
        Me.SearchUrl = searchUrl
    End Sub

    Private loaded As Boolean = False
    Private Sub FrGoogleMaps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUrl()
        loaded = True
    End Sub

    Private Sub LoadUrl()
        If Me.SearchUrl IsNot Nothing Then
            '    Dim html As String = "<html><body> " & _
            '                        "<iframe width=""100%"" height=""100%"" frameborder=""0"" scrolling=""yes"" marginheight=""0"" marginwidth=""0"" src=""{0}&output=embed&s=AARTsJqmsG0ywO0_IglviyKIgMan0FH5sg""></iframe> " & _
            '                        "<br /><small><a href=""{0}&source=embed"" style=""color:#0000FF;text-align:left"">Agrandir le plan</a></small> " & _
            '                        "</body></html>"
            '    html = String.Format(html, Me.SearchUrl)
            '    wb.DocumentText = html
            wb.Navigate(Me.SearchUrl)
        End If
    End Sub
End Class