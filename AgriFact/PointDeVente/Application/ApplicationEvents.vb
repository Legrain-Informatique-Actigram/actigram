Namespace My

    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

#Region "Gestion des connectionString"
        Public Const DefaultConnStringPropertyName As String = "ConnString"

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

        Private _adminValidated As Boolean = False
        Public Property AdminValidated() As Boolean
            Get
                Return _adminValidated
            End Get
            Set(ByVal value As Boolean)
                _adminValidated = value
            End Set
        End Property


        Private _nCaisse As Integer = -1
        Public Property CurrentCaisse() As Integer
            Get
                Return _nCaisse
            End Get
            Set(ByVal value As Integer)
                _nCaisse = value
            End Set
        End Property

        Public ReadOnly Property AbsoluteRepEtats() As String
            Get
                If IO.Path.IsPathRooted(My.Settings.RepEtats) Then
                    Return My.Settings.RepEtats
                Else
                    Return IO.Path.Combine(My.Application.Info.DirectoryPath, My.Settings.RepEtats)
                End If
            End Get
        End Property

    End Class

    ' Les événements suivants sont disponibles pour MyApplication :
    ' 
    ' Startup : déclenché lors du démarrage de l'application, avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si l'application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication
        'Fonction pour la dt de compil
        Public ReadOnly Property BuildDate() As DateTime
            Get
                Return GetBuildDate(Me.Info.Version)
            End Get
        End Property

        Private Function GetBuildDate(ByVal v As System.Version) As DateTime
            'Build dates start from 01/01/2000 
            Dim result As Date = #1/1/2000#

            'Add the number of days (build) 
            result = result.AddDays(v.Build)

            'Add the number of seconds since midnight (revision) multiplied by 2 
            result = result.AddSeconds(v.Revision * 2)


            'If we're currently in daylight saving time add an extra hour 
            If TimeZone.IsDaylightSavingTime(Now, TimeZone.CurrentTimeZone.GetDaylightChanges(Now.Year)) Then result.AddHours(1)

            Return result
        End Function


        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Cursor.Current = Cursors.WaitCursor
            LogMessage(String.Format("V{0} lancée sur {1} par {2}", My.Application.Info.Version, My.Computer.Name, Environment.UserName))

            'Préchargement Crystal
            'EcranCrystal.Prechargement()

            'My.User.CurrentPrincipal = Nothing
            'Dim f As New Connexion
            'f.ShowDialog()

            'SqlProxy.SetDefaultConnection(SqlProxy.GetConnectionString("DEV1\AGRIFACT", "AgrifactLaffont", "sa", "ludo"))
            'Test de la base de données 
            If Not SqlProxy.TestDefaultConnection(True) Then
                Using fr As New FrParametres
                    fr.ShowDialog()
                End Using
            End If

            'If Not My.User.IsAuthenticated Then End
            Cursor.Current = Cursors.Default
        End Sub

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

