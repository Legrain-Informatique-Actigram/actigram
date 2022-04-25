Namespace My

    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Public Const DefaultConnStringPropertyName As String = "ConnString"

        Private Shared settingsToOverride() As String = {DefaultConnStringPropertyName}
        Private Shared userOverrideFormat As String = "{0}UserOverride"

#Region "Propri�t�s"
        Public Property AbsoluteRepPdf() As String
            Get
                Return CheminComplet(My.Settings.RepPDF)
            End Get
            Set(ByVal value As String)
                My.Settings.RepPDF = value.Replace(My.Application.Info.DirectoryPath & "\", "")
            End Set
        End Property

        Private _cle As Securite.Activation.Cle
        Public Property Cle() As Securite.Activation.Cle
            Get
                Return _cle
            End Get
            Set(ByVal value As Securite.Activation.Cle)
                _cle = value
            End Set
        End Property

        Private _adminValidated As Boolean = False
        Public Property AdminValidated() As Boolean
            Get
                Return _adminValidated
            End Get
            Set(ByVal value As Boolean)
                _adminValidated = value
            End Set
        End Property
#End Region

#Region "Gestion des connectionString"
        Public Sub SetUserOverride(ByVal [property] As String, ByVal value As String)
            Me([property]) = value
        End Sub
#End Region

#Region "Settings"
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

#Region "Propri�t�s"
        'Fonction pour la dt de compil
        Public ReadOnly Property BuildDate() As DateTime
            Get
                Return GetBuildDate(Me.Info.Version)
            End Get
        End Property

        Public ReadOnly Property RepEtats() As String
            Get
                Return IO.Path.Combine(My.Application.Info.DirectoryPath, "Etats")
            End Get
        End Property
#End Region

#Region "MyApplication"
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Cursor.Current = Cursors.WaitCursor
            LogMessage(String.Format("V{0} lanc�e sur {1} par {2}", My.Application.Info.Version, My.Computer.Name, Environment.UserName))

            With My.Settings
                If .UpdateRequired Then
                    .Upgrade()
                    .UpdateRequired = False
                    .Save()
                    LogMessage("Settings r�cup�r�s d'une version pr�c�dente.")
                End If
            End With

            'V�rification de la cl�
            My.Settings.Cle = LectureCleActivation()
            If My.Settings.Cle Is Nothing Then
                MsgBox("Cette copie n'est pas activ�e", MsgBoxStyle.Exclamation)
                LogMessage("Cette copie n'est pas activ�e")
                End
            End If

            'Pr�chargement Crystal
            'EcranCrystal.Prechargement()

            'My.User.CurrentPrincipal = Nothing
            'Dim f As New Connexion
            'f.ShowDialog()

            'SqlProxy.SetDefaultConnection(SqlProxy.GetConnectionString("DEV1\AGRIFACT", "AgrifactLaffont", "sa", "ludo"))

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
#End Region

#Region "M�thodes diverses"
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
#End Region

#Region "M�thodes partag�es"
        Public Shared Function LectureCleActivation(Optional ByVal forceForm As Boolean = False) As Securite.Activation.Cle
            Dim res As Securite.Activation.Cle = Nothing
            'Lire la cl� dans la base de registre
            Dim c As String = GetValueRegistre("Cle", "")
            Dim codeUtil As String = GetValueRegistre("CodeUtilisateur", "")
            If c <> "" Then
                Try
                    res = Securite.Activation.Cle.Parse(Securite.XorEncryption.EnCrypt(Long.Parse(c, Globalization.NumberStyles.HexNumber)))
                    If Not res.IsValid(codeUtil) Then
                        If res.DateValidite.Date < Now.Date Then
                            MsgBox(String.Format("La cl� d'activation a expir� depuis le {0:dd/MM/yy}.", res.DateValidite), MsgBoxStyle.Exclamation)
                        Else
                            MsgBox("La cl� d'activation n'est pas valide.", MsgBoxStyle.Exclamation)
                        End If
                        res = Nothing
                    End If
                Catch ex As Exception
                    MsgBox("La cl� d'activation n'est pas valide.", MsgBoxStyle.Exclamation)
                    res = Nothing
                End Try
            End If
            'Si elle n'est pas pr�sente, ouvrir la fen�tre FrActivation
            If res Is Nothing Or forceForm Then
                Dim fr As New Securite.Activation.FrActivation
                If codeUtil <> "" Then fr.CodeUtilisateur = codeUtil
                If res IsNot Nothing Then fr.Cle = res
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    res = fr.Cle
                    codeUtil = fr.CodeUtilisateur
                End If
            End If
            If Not res Is Nothing Then
                SetValueRegistre("Cle", Securite.XorEncryption.EnCrypt(res.ToLong).ToString("X16"))
            Else
                SetValueRegistre("Cle", "")
            End If
            SetValueRegistre("CodeUtilisateur", codeUtil)
            Return res
        End Function
#End Region

    End Class

End Namespace

