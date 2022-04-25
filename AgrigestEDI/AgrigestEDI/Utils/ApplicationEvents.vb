Imports System.Configuration
Imports System.Xml

Namespace My
    Partial Class MySettings

#Region "Gestion des connectionString"
        Public Const dbDonneesConnStringPropertyName As String = "dbDonneesConnectionString"
        Public Const dbPlanTypeConnStringPropertyName As String = "dbPlantypeCOConnectionString"
        Public Const BaremesConnStringPropertyName As String = "BaremesConnectionString"

        Private Shared settingsToOverride() As String = {BaremesConnStringPropertyName}
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

#Region "Propriétés"
        Private _verifAdminOK As Boolean
        Public Property VerifAdminOK() As Boolean
            Get
                Return _verifAdminOK
            End Get
            Set(ByVal value As Boolean)
                _verifAdminOK = value
            End Set
        End Property

        Private _exp As Exploitation
        Public Property Exploitation() As Exploitation
            Get
                Return _exp
            End Get
            Set(ByVal value As Exploitation)
                _exp = value
            End Set
        End Property

        Private _demarrage As Demarrage
        Public Property Demarrage() As Demarrage
            Get
                Return _demarrage
            End Get
            Set(ByVal value As Demarrage)
                _demarrage = value
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

        Public Property AbsoluteRepEtats() As String
            Get
                Return CheminComplet(My.Settings.RepEtats)
            End Get
            Set(ByVal value As String)
                My.Settings.RepEtats = value.Replace(My.Application.Info.DirectoryPath & "\", "")
            End Set
        End Property

        Public Property AbsoluteCheminVNC() As String
            Get
                Return CheminComplet(My.Settings.CheminVNC)
            End Get
            Set(ByVal value As String)
                My.Settings.CheminVNC = value.Replace(My.Application.Info.DirectoryPath & "\", "")
            End Set
        End Property

        Private _cheminBase As String
        Public ReadOnly Property CheminBase() As String
            Get
                If _cheminBase Is Nothing Then
                    Dim c As New OleDb.OleDbConnectionStringBuilder(My.Settings.dbDonneesConnectionString)
                    _cheminBase = c.DataSource
                End If
                Return CheminComplet(_cheminBase)
            End Get
        End Property

        Private _cheminBaseConfig As String
        Public ReadOnly Property CheminBaseConfig() As String
            Get
                If _cheminBaseConfig Is Nothing Then
                    Dim c As New OleDb.OleDbConnectionStringBuilder(My.Settings.dbPlantypeCOConnectionString)
                    _cheminBaseConfig = c.DataSource
                End If
                Return CheminComplet(_cheminBaseConfig)
            End Get
        End Property
#End Region

#Region "Méthodes diverses"
        Public Sub ResetChemins()
            _cheminBase = Nothing
            _cheminBaseConfig = Nothing
        End Sub

        Public Sub EcrireParametre(ByVal name As String, ByVal value As Object)
            Try
                Me(name) = value
            Catch ex As System.Configuration.SettingsPropertyNotFoundException
                Dim prop As New SettingsProperty(Me.Properties.Item("RepEtats"))
                With prop
                    .Name = name
                    .PropertyType = value.GetType
                End With
                Me.Properties.Add(prop)
                Me(name) = value
            End Try
        End Sub

        Public Function LireParametre(Of T)(ByVal name As String, ByVal defaultValue As T) As T
            Dim o As Object = Nothing
            Try
                o = Me(name)
            Catch ex As System.Configuration.SettingsPropertyNotFoundException
            End Try
            If o Is Nothing Then
                o = defaultValue
            End If
            Return CType(o, T)
        End Function
#End Region

    End Class
End Namespace

Namespace My
    Public Class Dossier

#Region "Propriétés"
        Public Shared ReadOnly Property Principal() As DossierPrincipal
            Get
                If Not TypeOf My.User.CurrentPrincipal Is DossierPrincipal Then
                    Return Nothing
                Else
                    Return DirectCast(My.User.CurrentPrincipal, DossierPrincipal)
                End If
            End Get
        End Property
#End Region

    End Class

    ''' <summary>
    '''Les événements suivants sont disponibles pour MyApplication :
    ''' 
    ''' Startup : déclenché lors du démarrage de l'application, avant la création du formulaire de démarrage.
    ''' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ''' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ''' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si l'application est déjà active. 
    ''' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    ''' </summary>
    ''' <remarks></remarks>
    Partial Friend Class MyApplication

#Region "Méthodes diverses"
        Public Function GetAppDataPath() As String
            Dim path As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), String.Format("{0}\{1}", Me.Info.CompanyName, Me.Info.ProductName))
            If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
            Return path
        End Function

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            My.Settings.Demarrage = New Demarrage
            For Each arg As String In e.CommandLine
                Dim par As New CommandParam(arg)
                Select Case par.Name
                    Case "-expl" : My.Settings.Demarrage.StartupExpl = par.Value
                End Select
            Next
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If TypeOf e.Exception Is Eval.Evaluator.parserexception Then
                e.ExitApplication = False
            ElseIf TypeOf e.Exception Is ApplicationException Then
                LogException(e.Exception, TraceEventType.Error)
                MsgBox(My.Resources.Strings.ErreurAppli & vbCrLf & e.Exception.Message, MsgBoxStyle.Exclamation, "Erreur")
                e.ExitApplication = False
            Else
                LogException(e.Exception)
                MsgBox(My.Resources.Strings.ErreurCritique & vbCrLf & e.Exception.Message, MsgBoxStyle.Critical, "Erreur")
                e.ExitApplication = True
            End If
        End Sub
#End Region

    End Class
End Namespace

