Namespace My

    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

#Region "Gestion des connectionString"
        Public Const DefaultConnStringPropertyName As String = "ConnAgrifact"

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

    ' Les événements suivants sont disponibles pour MyApplication :
    ' 
    ' Startup : déclenché lors du démarrage de l'application, avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si l'application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If TypeOf e.Exception Is ApplicationException Then
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

