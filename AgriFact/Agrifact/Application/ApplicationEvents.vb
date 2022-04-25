Namespace My


    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

#Region "Gestion des connectionString"
        Public Const DefaultConnStringPropertyName As String = "AgrifactConnString"

        Private Shared settingsToOverride() As String = {DefaultConnStringPropertyName}
        Private Shared userOverrideFormat As String = "{0}UserOverride"

        Public Sub SetUserOverride(ByVal [property] As String, ByVal value As String)
            Me([property]) = value
        End Sub

        Public Sub LoadUserOverride()
            Dim userProperty As String
            For Each appProperty As String In settingsToOverride
                userProperty = String.Format(userOverrideFormat, appProperty)
                If CType(Me(userProperty), String).Length > 0 Then
                    Me(appProperty) = Me(userProperty)
                End If
            Next
        End Sub

        Public Sub SaveUserOverride()
            Dim userProperty As String
            For Each appProperty As String In settingsToOverride
                userProperty = String.Format(userOverrideFormat, appProperty)
                Me(userProperty) = Me(appProperty)
            Next
        End Sub

        'Au chargement : transfere les versions User dans les variables d'application
        Private Sub Me_SettingsLoaded(ByVal sender As Object, ByVal e As System.Configuration.SettingsLoadedEventArgs) _
            Handles Me.SettingsLoaded
            LoadUserOverride()
        End Sub

        'A la sauvegarde : sauvegarde les valeurs des variables d'appli dans les variables User
        Private Sub Me_SettingsSaving(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles Me.SettingsSaving
            SaveUserOverride()
        End Sub
#End Region

        Public ReadOnly Property DefaultConnString() As String
            Get
                Return Me.AgrifactConnString
            End Get
        End Property
    End Class

    ' Les �v�nements suivants sont disponibles pour MyApplication�:
    ' 
    ' Startup�: d�clench� lors du d�marrage de l'application, avant la cr�ation du formulaire de d�marrage.
    ' Shutdown�: d�clench� apr�s la fermeture de tous les formulaires de l'application. Cet �v�nement n'est pas d�clench� si l'application se termine de fa�on anormale.
    ' UnhandledException�: d�clench� si l'application rencontre une exception non g�r�e.
    ' StartupNextInstance�: d�clench� lors du lancement d'une application � instance unique et si l'application est d�j� active. 
    ' NetworkAvailabilityChanged�: d�clench� lorsque la connexion r�seau est connect�e ou d�connect�e.
    Partial Friend Class MyApplication


        Public ReadOnly Property MyMainForm() As Form
            Get
                Return Me.MainForm
            End Get
        End Property

        Public Function GetAppDataPath() As String
            Dim path As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), String.Format("{0}\{1}", Me.Info.CompanyName, Me.Info.ProductName))
            If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
            Return path
        End Function

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            LogMessage(String.Format("{1}{0}", New String("-"c, 100), vbCrLf))
            LogMessage(String.Format("Version {0} du {3:dd/MM/yyyy} lanc�e par '{1}' sur '{2}'", Application.Info.Version, Environment.UserName, Environment.MachineName, BuildDate))
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If TypeOf e.Exception Is UserCancelledException Then
                e.ExitApplication = False
            ElseIf TypeOf e.Exception Is ApplicationException Then
                LogException(e.Exception, TraceEventType.Error)
                MsgBox("Une erreur s'est produite : " & vbCrLf & e.Exception.Message, MsgBoxStyle.Exclamation, "Erreur")
                e.ExitApplication = False
            Else
                LogException(e.Exception)
                MsgBox("Une erreur s'est produite, l'application va se terminer : " & vbCrLf & e.Exception.Message, MsgBoxStyle.Critical, "Erreur")
                e.ExitApplication = True
            End If
        End Sub

    End Class

End Namespace

