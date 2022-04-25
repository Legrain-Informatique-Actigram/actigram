Public Class ExecParam
    Public NomDossier As String
    Public ServeurSQL As String
    Public BaseSQL As String
    Public Login As String
    Public saPWd As String

    Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
    Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"
    Private Const FICHIER_PARAMETRE_SAUVEGARDE As String = "Parametres.xml.bak"

    Private _CheminAccesFichierMDF As String
    Private _CheminAccesFichierLDF As String

#Region "Propriétés"
    Public Property CheminAccesFichierMDF() As String
        Get
            Return _CheminAccesFichierMDF
        End Get
        Set(ByVal Value As String)
            _CheminAccesFichierMDF = Value
        End Set
    End Property

    Public Property CheminAccesFichierLDF() As String
        Get
            Return _CheminAccesFichierLDF
        End Get
        Set(ByVal Value As String)
            _CheminAccesFichierLDF = Value
        End Set
    End Property
#End Region

#Region "Constructeur"
    Public Sub New()

    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function ParseConnString(ByVal connString As String) As ExecParam
        Dim cb As New SqlClient.SqlConnectionStringBuilder(connString)
        Dim res As New ExecParam

        Try
            res.ServeurSQL = cb.DataSource
            res.BaseSQL = cb.InitialCatalog

            If Not cb.IntegratedSecurity Then
                res.Login = cb.UserID
                res.saPWd = cb.Password
            End If

            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ReadParam(ByVal NomDossier As String) As ExecParam
        Dim tb As DataTable = LoadParams()

        Try
            For Each rw As DataRow In tb.Rows
                If String.Compare(rw("NomDossier"), NomDossier, True) = 0 Then
                    Return ReadParam(rw)
                End If
            Next

            Console.WriteLine(String.Format("Aucun dossier nommé '{0}' n'a été trouvé.", NomDossier))
            Throw New Exception(String.Format("Aucun dossier nommé '{0}' n'a été trouvé.", NomDossier))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ReadParam(ByVal index As Integer) As ExecParam
        Dim tb As DataTable = LoadParams()

        Try
            If index < tb.Rows.Count Then
                Return ReadParam(tb.Rows(index))
            Else
                Console.WriteLine(String.Format("Le fichier paramètre ne contient que {0} dossiers", tb.Rows.Count))
                Throw New IndexOutOfRangeException(String.Format("Le fichier paramètre ne contient que {0} dossiers", tb.Rows.Count))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ReadAllParams(Optional ByVal versionAgrifact As String = "Ancienne") As ArrayList
        Dim tb As DataTable = LoadParams(versionAgrifact)
        Dim res As New ArrayList

        Try
            For Each rw As DataRow In tb.Rows
                res.Add(ReadParam(rw))
            Next

            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Function LoadParams(Optional ByVal versionAgrifact As String = "Ancienne") As DataTable
        Dim fichierParametre As String = String.Empty

        fichierParametre = CheminFichierParam(versionAgrifact)

        Try
            If IO.File.Exists(fichierParametre) Then
                Dim dsParamLocaux As New DataSet
                dsParamLocaux.ReadXml(fichierParametre)
                If dsParamLocaux.Tables.Contains("Parametres") Then
                    Return dsParamLocaux.Tables("Parametres")
                Else
                    Console.WriteLine("Fichier paramètre mal formé.")
                    Throw New Exception("Fichier paramètre mal formé")
                End If
            Else
                Console.WriteLine("Fichier paramètre introuvable <" & fichierParametre & ">.")
                Throw New Exception("Fichier paramètre introuvable")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheminFichierParam(Optional ByVal versionAgrifact As String = "Nouvelle") As String
        Dim chemin As String = String.Empty

        Try
            Select Case versionAgrifact
                Case "Nouvelle"
                    chemin = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)
                Case "Ancienne"
                    chemin = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)
            End Select

            Return chemin
        Catch ex As Exception
            Throw ex
        End Try  
    End Function

    Public Shared Function ReadParam(ByVal rw As DataRow) As ExecParam
        Dim par As New ExecParam
        Try
            With par
                .NomDossier = rw.Item("NomDossier")
                .ServeurSQL = rw.Item("ServeurSQL")
                .BaseSQL = rw.Item("BaseSQL")
                .Login = "sa"
                .saPWd = rw.Item("saPwd")
            End With

            Return par
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DefaultParam() As ExecParam
        Dim par As New ExecParam

        Try
            With par
                .NomDossier = "Agrifact"
                .ServeurSQL = ".\Agrifact"
                .BaseSQL = "Agrifact"
                .Login = "sa"
                .saPWd = "ludo"
            End With

            Return par
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ApplicationPath() As String
        Return IO.Path.GetDirectoryName(Reflection.Assembly.GetEntryAssembly().Location)
    End Function
#End Region

End Class
