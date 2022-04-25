Imports AgrigestEDI.Utilities.FTP

Public Class FtpCogedis

    Public RemoteDir As String
    Public LocalDir As String

#Region "Propriétés"
    Private _params As ParamsFtp
    Public Property Parameters() As ParamsFtp
        Get
            Return _params
        End Get
        Set(ByVal value As ParamsFtp)
            _params = value
        End Set
    End Property
#End Region

#Region "Méthodes partagées"
    Public Shared Sub CheckAndDownload()
        If My.Settings.Exploitation Is Nothing Then Exit Sub
        Dim ftp As New FtpCogedis
        With ftp
            Try
                .Open()
            Catch ex As Exception
                LogException(ex)
                MsgBox("La connexion au serveur de téléchargement des EDI a échoué :" & ex.Message, MsgBoxStyle.Exclamation)
                Exit Sub
            End Try
            For Each fileDesc As EdiFileDescription In ftp.Parameters.FileDescriptions
                Dim remoteDir As String = String.Format(fileDesc.RemoteDirPattern, FrImportEdis.GetTrimmedCodeExpl)
                Dim files As List(Of String)
                Try
                    files = .ListFiles(remoteDir, FrImportEdis.GetEdiFileNamePattern(fileDesc.FilenamePattern))
                Catch ex As Exception
                    LogException(ex)
                    MsgBox("La recherche en ligne des EDI a échoué :" & ex.Message, MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try
                Try
                    If files.Count > 0 Then
                        Dim DirEDI As String = FrImportEdis.GetEdiDirectory(fileDesc.LocalDirPattern)
                        Using fr As New FrProgressBar
                            With fr
                                .Text = "Téléchargement des EDI..."
                                .Maximum = files.Count
                                .Value = 0
                                .TopMost = True
                                .Show()
                            End With
                            For Each f As String In files
                                .RemoteDir = remoteDir
                                .DownloadFile(f, IO.Path.Combine(DirEDI, f), True, True)
                                fr.Value += 1
                            Next
                        End Using
                    End If
                Catch ex As Exception
                    LogException(ex)
                    MsgBox("Le téléchargement des EDI a échoué :" & ex.Message, MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try
            Next
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Sub Open(ByVal params As ParamsFtp)
        Me.Parameters = params
        Open()
    End Sub

    Public Sub Open(ByVal server As String, Optional ByVal port As Integer = 21, Optional ByVal login As String = Nothing, Optional ByVal password As String = Nothing, Optional ByVal initialDirectory As String = Nothing)
        Me.Parameters = New ParamsFtp
        With Me.Parameters
            .Server = server
            .Port = port
            .Login = login
            .Password = password
            Dim f As New EdiFileDescription
            With f
                .RemoteDirPattern = initialDirectory
            End With
            .FileDescriptions.Add(f)
        End With
        Open()
    End Sub

    Public Sub Open()
        Dim ftpClient As FTPclient = GetClient()
        If ftpClient IsNot Nothing Then
            Dim res As String = ftpClient.GetCurrentDir()
        End If
    End Sub

    Private Function GetClient() As FTPclient
        'Chargement des params par défaut
        If Me.Parameters Is Nothing Then Me.Parameters = ParamsFtp.Load
        If Me.Parameters Is Nothing Then Throw New ArgumentNullException("Parameters", "Les paramètres de connexion sont introuvables")

        Try
            Dim ftpClient As New FTPclient(Me.Parameters.Server, Me.Parameters.Login, Me.Parameters.Password)
            Return ftpClient
        Catch ex As Exception
            LogException(ex)
            Return Nothing
        End Try
    End Function

    Public Function ListFiles(Optional ByVal remoteDir As String = "", Optional ByVal pattern As String = Nothing) As List(Of String)
        Dim ftpClient As FTPclient = GetClient()
        If ftpClient IsNot Nothing Then
            Dim allEntries As FTPdirectory = ftpClient.ListDirectoryDetail(remoteDir)
            Dim files As List(Of FTPfileInfo)
            If pattern IsNot Nothing Then
                Dim matcher As New FileMatcher(pattern)
                files = allEntries.FindAll(AddressOf matcher.IsMatch)
            Else
                files = allEntries.GetFiles
            End If
            If files IsNot Nothing Then
                Dim filenames As New List(Of String)
                For Each fi As FTPfileInfo In files
                    filenames.Add(fi.Filename)
                Next
                Return filenames
            End If
        End If
        Return Nothing
    End Function

    Public Sub DownloadFile(ByVal remoteFile As String, ByVal localFile As String, Optional ByVal overwrite As Boolean = True, Optional ByVal deleteRemote As Boolean = False)
        Dim targetDir As String = IO.Path.GetDirectoryName(localFile)
        If Not IO.Directory.Exists(targetDir) Then IO.Directory.CreateDirectory(targetDir)
        Dim ftpClient As FTPclient = GetClient()
        If ftpClient IsNot Nothing Then
            If Me.RemoteDir IsNot Nothing Then ftpClient.CurrentDirectory = Me.RemoteDir
            If ftpClient.Download(remoteFile, localFile, overwrite) Then
                LogMessage(String.Format("FTP DOWNLOADED {0}\{1} to {2}", ftpClient.CurrentDirectory, remoteFile, localFile))
                If deleteRemote Then
                    ftpClient.FtpDelete(remoteFile)
                    LogMessage(String.Format("FTP DELETED {0}\{1}", ftpClient.CurrentDirectory, remoteFile))
                End If
            End If
        End If
    End Sub

    Public Sub DowloadFiles(ByVal remoteFiles As List(Of String), Optional ByVal localDir As String = Nothing, Optional ByVal overwrite As Boolean = True)
        If localDir Is Nothing Then
            localDir = Me.LocalDir
        End If
        For Each s As String In remoteFiles
            Me.DownloadFile(s, IO.Path.Combine(localDir, s), overwrite)
        Next
    End Sub
#End Region

#Region "Classes internes"
    Private Class FileMatcher

        Public pattern As String

#Region "Constructeur"
        Public Sub New()

        End Sub

        Public Sub New(ByVal pattern As String)
            Me.New()
            Me.pattern = pattern
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function IsMatch(ByVal f As FTPfileInfo) As Boolean
            If String.IsNullOrEmpty(pattern) Then Return True
            Return f.Filename.ToUpper Like pattern.ToUpper
        End Function
#End Region

    End Class

    Public Class ParamsFtp

        Private Const NOM_FICHIER_PARAM_SRC As String = "Data\ParamEdi.xml"
        Private Const NOM_FICHIER_PARAM As String = "Data\ParamEdi.dat"

#Region "Props"
        Private _server As String
        Public Property Server() As String
            Get
                Return _server
            End Get
            Set(ByVal value As String)
                _server = value
            End Set
        End Property


        Private _port As Integer = 21
        Public Property Port() As Integer
            Get
                Return _port
            End Get
            Set(ByVal value As Integer)
                _port = value
            End Set
        End Property


        Private _login As String
        Public Property Login() As String
            Get
                Return _login
            End Get
            Set(ByVal value As String)
                _login = value
            End Set
        End Property


        Private _pass As String
        Public Property Password() As String
            Get
                Return _pass
            End Get
            Set(ByVal value As String)
                _pass = value
            End Set
        End Property

        Private _files As New List(Of EdiFileDescription)
        Public Property FileDescriptions() As List(Of EdiFileDescription)
            Get
                Return _files
            End Get
            Set(ByVal value As List(Of EdiFileDescription))
                _files = value
            End Set
        End Property

#End Region

#Region "Shared"
        Public Shared ReadOnly Property IsAvailable() As Boolean
            Get
                Dim cheminParam As String = CheminComplet(NOM_FICHIER_PARAM)
                Return IO.File.Exists(cheminParam)
            End Get
        End Property

        Public Shared Function Load() As ParamsFtp
            Dim cheminParam As String = CheminComplet(NOM_FICHIER_PARAM)
            If Not IO.File.Exists(cheminParam) Then Return Nothing
            Dim params As String = My.Computer.FileSystem.ReadAllText(cheminParam).Trim
            Dim res As ParamsFtp = DeSerializeFromString(Of ParamsFtp)(Securite.XorEncryption.EnCryptFromX(params))
            Return res
        End Function

        Public Shared Function EncryptParam() As String
            Dim cheminParam As String = CheminComplet(NOM_FICHIER_PARAM_SRC)
            If Not IO.File.Exists(cheminParam) Then Return Nothing
            Dim params As String = My.Computer.FileSystem.ReadAllText(cheminParam)
            Dim res As String = Securite.XorEncryption.EnCryptToX(params)
            Debug.Print(res)
            Return res
        End Function
#End Region

    End Class

    Public Class EdiFileDescription

        <Xml.Serialization.XmlAttribute()> Public FilenamePattern As String
        <Xml.Serialization.XmlAttribute()> Public RemoteDirPattern As String
        <Xml.Serialization.XmlAttribute()> Public LocalDirPattern As String

    End Class
#End Region

End Class