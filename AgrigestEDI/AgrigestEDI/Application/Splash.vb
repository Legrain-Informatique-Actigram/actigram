Public NotInheritable Class Splash

    Private progress As Integer = 0
    Private desc As String = ""
    Private mustRefresh As Boolean

#Region "Page"
    Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configurez le texte de la boîte de dialogue au moment de l'exécution en fonction des informations d'assembly de l'application.  
        'Titre de l'application
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle.Text = My.Application.Info.Title
        'Else
        '    'Si le titre de l'application est absent, utilisez le nom de l'application, sans l'extension
        '    ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Mettez en forme les informations de version à l'aide du texte défini dans le contrôle Version au moment du design en tant que
        '  chaîne de mise en forme. Ceci permet une localisation efficace si besoin est.
        '  Les informations de génération et de révision peuvent être incluses en utilisant le code suivant et en remplaçant le 
        '  texte du contrôle de version par "Version {0}.{1:00}.{2}.{3}" ou un équivalent. Voir
        '  String.Format() dans l'aide pour plus d'informations.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Informations de copyright
        'Copyright.Text = My.Application.Info.Copyright
        While My.Settings.Demarrage Is Nothing
            System.Threading.Thread.Sleep(100)
        End While
        AddHandler My.Settings.Demarrage.StartupProgressed, AddressOf ApplicationStartupProgressed
        mustRefresh = True
    End Sub

    Private Sub Splash_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Application.DoEvents()
        '    Me.TopMost = False
        '    While Me.Visible
        '        RefreshProgress()
        '        System.Threading.Thread.Sleep(100)
        '    End While
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub RefreshProgress()
        If mustRefresh Then
            Me.pgBar.Value = Math.Min(progress, Me.pgBar.Maximum)
            Me.LbDescription.Text = desc & "..."
            If progress <> 0 Then Me.BringToFront()
            mustRefresh = False
            'If progress = 100 Then
            '    Me.Hide()
            'End If
        End If
        Application.DoEvents()
    End Sub

    Private Sub ApplicationStartupProgressed(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        progress = e.ProgressPercentage
        If e.UserState IsNot Nothing AndAlso TypeOf e.UserState Is String Then
            desc = CStr(e.UserState)
        End If
        mustRefresh = True
        RefreshProgress()
    End Sub
#End Region

End Class
