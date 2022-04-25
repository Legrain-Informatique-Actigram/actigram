Public Class DatabaseUpdate

    Private cheminBase As String

    Private nbUpdates As Integer
    Private curUpdate As Integer
    Private nomScript As String

    Public Event ReportsProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)

#Region "Constructeurs"
    Public Sub New(ByVal cheminBase As String)
        Me.cheminBase = cheminBase
    End Sub
#End Region

#Region "M�thodes diverses"
    Public Sub Update()
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

        'Se connecter � la base de donn�es
        If cheminBase.Trim.Length = 0 Then
            Throw New ArgumentException("Param�tres de connexion insuffisants, connexion impossible.")
        End If

        'Sauvegarde de la base de donn�es
        If Not (Me.SaveDataBase(cheminBase)) Then
            If (MsgBox("La sauvegarde de la base de donn�es a �chou�. Voulez-vous continuer la mise � jour ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                Exit Sub
            End If
        End If

        Dim cn As New SqlProxy(SqlProxy.GetConnectionString(cheminBase))

        cn.Open()

        Try
            'Charger la liste des mises � jour
            Dim lst As ListUpdates = ListUpdates.LoadXml(asm.GetManifestResourceStream(asm.GetName.Name & ".ListUpdates.xml"))

            'D�terminer la version initiale de la base
            Dim version As String = DeterminerVersionBase(cn)

            nbUpdates = lst.GetNbUpdates(version)
            If nbUpdates = 0 Then Throw New ArgumentException("La base est d�j� � jour.")

            curUpdate = 0
            Dim upd As Update = lst.GetNextUpdate(version)

            'Tant qu'il y a des mises � jour pour la base
            While Not upd Is Nothing
                nomScript = upd.NomScript
                'Jouer la mise � jour
                Dim sr As New ScriptRunner(cheminBase)
                AddHandler sr.ReportsProgress, AddressOf ScriptReportsProgress
                sr.RunSqlScript(asm.GetManifestResourceStream(asm.GetName.Name & "." & upd.NomScript))
                version = upd.VersionApres
                MajVersionBase(cn, version)
                upd = lst.GetNextUpdate(version)
                curUpdate += 1
            End While

            ReportProgress(nbUpdates * 100, nbUpdates * 100, "Termin�")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Function SaveDataBase(ByVal cheminBase As String) As Boolean
        Dim nomFichier As String = "save_" & System.IO.Path.GetFileNameWithoutExtension(cheminBase) & "_" & String.Format("{0:ddMMyyyyhhmmss}", Now) & System.IO.Path.GetExtension(cheminBase)

        Try
            System.IO.File.Copy(cheminBase, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(cheminBase), nomFichier), True)

            Return True
        Catch ex As Exception
            MsgBox("Impossible de sauvegarder la base de donn�es. " & ex.Message)

            Return False
        End Try
    End Function

    Public Function Simulate() As String
        Dim res As String = ""

        Try
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

            'Se connecter � la base de donn�es
            Dim cn As New SqlProxy(SqlProxy.GetConnectionString(cheminBase))

            cn.Open()

            'Charger la liste des mises � jour
            Dim lst As ListUpdates = ListUpdates.LoadXml(asm.GetManifestResourceStream(asm.GetName.Name & ".ListUpdates.xml"))
            Dim versionBase As String = DeterminerVersionBase(cn)
            Dim nbUpdates As Integer = lst.GetNbUpdates(versionBase)

            res = String.Format("La base est actuellement en version {0}" & vbCrLf & _
                                "{1} mises � jour vont �tre d�roul�es", versionBase, nbUpdates)
            If nbUpdates > 0 Then res &= " : "

            Dim upd As Update = lst.GetNextUpdate(versionBase)

            While Not upd Is Nothing
                res &= vbCrLf & " - " & upd.NomScript
                versionBase = upd.VersionApres
                upd = lst.GetNextUpdate(versionBase)
            End While
        Catch ex As Exception
            res = "La mise � jour est impossible : " & vbCrLf & ex.Message
        End Try

        Return res
    End Function

    Public Sub RunScript(ByVal fichier As String)
        'Se connecter � la base de donn�es
        If cheminBase.Trim.Length = 0 Then
            Throw New ArgumentException("Param�tres de connexion insuffisants, connexion impossible.")
        End If

        Dim cn As New SqlProxy(SqlProxy.GetConnectionString(cheminBase))

        cn.Open()

        Try
            nbUpdates = 1
            nomScript = fichier

            'Jouer la mise � jour
            Dim sr As New ScriptRunner(cheminBase)

            AddHandler sr.ReportsProgress, AddressOf ScriptReportsProgress
            sr.RunSqlScript(fichier)
            ReportProgress(100, 100, "Termin�")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ScriptReportsProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)
        Dim max As Integer = nbUpdates * 100
        Dim progress As Integer = curUpdate * 100 + (e.progress * 100 \ e.max)

        ReportProgress(progress, max, "D�roulement du script " & nomScript)
    End Sub

    Public Sub ReportProgress(ByVal progress As Integer, Optional ByVal max As Integer = 100, Optional ByVal status As String = "")
        RaiseEvent ReportsProgress(Me, New ProgressEventArgs(progress, max, status))
    End Sub
#End Region

#Region "M�thodes partag�es"
    Public Shared Function DeterminerVersionBase(ByVal cn As SqlProxy) As String
        Dim version As String = Nothing

        Try
            version = CStr(cn.ExecuteScalar("select valeur from ParamApplication where cle='VersionBase'"))
        Catch ex As Exception
            'On ne fait rien en cas d'exception, on remonte juste une version "0"
        End Try

        If version Is Nothing Then version = "0"

        Return version
    End Function

    Private Shared Sub MajVersionBase(ByVal cn As SqlProxy, ByVal version As String)
        Try
            cn.Connection.Close()
            cn.ExecuteScalar(String.Format("UPDATE ParamApplication SET Valeur='{0}' WHERE Cle='VersionBase'", version))
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class
