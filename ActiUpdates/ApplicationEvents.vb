Namespace My

    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

#Region "Gestion des connectionString"
        Public Const DefaultConnStringPropertyName As String = "ActiUpdatesConnString"

        Private Shared settingsToOverride() As String = {DefaultConnStringPropertyName}
        Private Shared userOverrideFormat As String = "{0}UserOverride"

        Public Sub SetUserOverride(ByVal [property] As String, ByVal value As String)
            Me([property]) = value
        End Sub

        'Au chargement : transfere les versions User dans les variables d'application
        Private Sub Me_SettingsLoaded(ByVal sender As Object, ByVal e As System.Configuration.SettingsLoadedEventArgs) _
            Handles Me.SettingsLoaded
            Dim userProperty As String
            For Each appProperty As String In settingsToOverride
                userProperty = String.Format(userOverrideFormat, appProperty)
                If CType(Me(userProperty), String).Length > 0 Then
                    Me(appProperty) = Me(userProperty)
                End If
            Next
        End Sub

        'A la sauvegarde : sauvegarde les valeurs des variables d'appli dans les variables User
        Private Sub Me_SettingsSaving(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles Me.SettingsSaving
            Dim userProperty As String
            For Each appProperty As String In settingsToOverride
                userProperty = String.Format(userOverrideFormat, appProperty)
                Me(userProperty) = Me(appProperty)
            Next
        End Sub
#End Region

    End Class
    ' Les �v�nements suivants sont disponibles pour MyApplication�:
    ' 
    ' Startup�: d�clench� lors du d�marrage de l'application, avant la cr�ation du formulaire de d�marrage.
    ' Shutdown�: d�clench� apr�s la fermeture de tous les formulaires de l'application. Cet �v�nement n'est pas d�clench� si l'application se termine de fa�on anormale.
    ' UnhandledException�: d�clench� si l'application rencontre une exception non g�r�e.
    ' StartupNextInstance�: d�clench� lors du lancement d'une application � instance unique et si l'application est d�j� active. 
    ' NetworkAvailabilityChanged�: d�clench� lorsque la connexion r�seau est connect�e ou d�connect�e.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox(e.Exception.Message)
            LogException(e.Exception)
        End Sub
    End Class

End Namespace

