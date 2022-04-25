Public Class DatabaseUpdate

    Private dataserver As String
    Private database As String
    Private sa As String
    Private sapwd As String

    Private nbUpdates As Integer
    Private curUpdate As Integer
    Private nomScript As String

    Public Event ReportsProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)

    Public Sub New(ByVal dataserver As String, ByVal database As String, ByVal sa As String, ByVal sapwd As String)
        Me.dataserver = dataserver
        Me.database = database
        Me.sa = sa
        Me.sapwd = sapwd
    End Sub

    Public Sub Update()
        'Se connecter à la base de données
        If dataserver.Trim.Length = 0 Or database.Trim.Length = 0 Then
            Throw New ArgumentException("Paramètres de connexion insuffisants, connexion impossible.")
        End If

        Using cn As New SqlProxy(SqlProxy.GetConnectionString(dataserver, database, sa, sapwd))
            AddHandler cn.ScriptProgress, AddressOf ScriptReportsProgress
            'Verif qu'on est SysAdmin
            Dim verif As Boolean = cn.ExecuteScalarBool("select IS_SRVROLEMEMBER('sysadmin')")
            If Not verif Then Throw New Exception("Vous n'avez pas les droits requis pour mettre à jour la base de données.")

            'Charger la liste des mises à jour
            Dim lst As ListUpdates = ListUpdates.LoadXml(My.Resources.ListUpdates)

            'Déterminer la version initiale de la base
            Dim version As String = DeterminerVersionBase(cn)

            nbUpdates = lst.GetNbUpdates(version)
            If nbUpdates = 0 Then Throw New ArgumentException("La base est déjà à jour.")

            curUpdate = 0
            Dim scriptManager As Resources.ResourceManager = My.Resources.Scripts.ResourceManager
            Dim upd As Update = lst.GetNextUpdate(version)

            'Tant qu'il y a des mises à jour pour la base
            While Not upd Is Nothing
                nomScript = Replace(System.IO.Path.GetFileNameWithoutExtension(upd.NomScript), ".", "_")
                'Jouer la mise à jour
                cn.RunScript(scriptManager.GetString(nomScript))
                'cn.RunScript(My.Resources.Scripts.ResourceManager.GetString(test))
                version = upd.VersionApres
                MajVersionBase(cn, version)
                upd = lst.GetNextUpdate(version)
                curUpdate += 1
            End While
            ReportProgress(nbUpdates * 100, nbUpdates * 100, "Terminé")
        End Using
    End Sub

    Public Function Simulate() As String
        Dim res As String = ""
        'Se connecter à la base de données
        Using cn As New SqlProxy(SqlProxy.GetConnectionString(dataserver, database, sa, sapwd))
            Try
                'Verif qu'on est SysAdmin
                Dim verif As Boolean = cn.ExecuteScalarBool("select IS_SRVROLEMEMBER('sysadmin')")
                If Not verif Then Throw New Exception("Vous n'avez pas les droits requis pour mettre à jour la base de données.")

                'Charger la liste des mises à jour
                Dim lst As ListUpdates = ListUpdates.LoadXml(My.Resources.ListUpdates)
                Dim version As String = DeterminerVersionBase(cn)
                Dim nbUpdates As Integer = lst.GetNbUpdates(version)

                res = String.Format("La base est actuellement en version {0}" & vbCrLf & _
                                    "{1} mises à jour vont être déroulées", version, nbUpdates)
                If nbUpdates > 0 Then res &= " : "

                Dim upd As Update = lst.GetNextUpdate(version)
                While Not upd Is Nothing
                    res &= vbCrLf & " - " & upd.NomScript
                    version = upd.VersionApres
                    upd = lst.GetNextUpdate(version)
                End While
            Catch ex As Exception
                res = "La mise à jour est impossible : " & vbCrLf & ex.Message
            End Try
        End Using
        Return res
    End Function

    Private Sub ScriptReportsProgress(ByVal percent As Integer, ByVal etat As String)
        Dim max As Integer = nbUpdates * 100
        Dim progress As Integer = curUpdate * 100 + percent
        ReportProgress(progress, max, "Déroulement du script " & nomScript)
    End Sub

    Public Sub ReportProgress(ByVal progress As Integer, Optional ByVal max As Integer = 100, Optional ByVal status As String = "")
        RaiseEvent ReportsProgress(Me, New ProgressEventArgs(progress, max, status))
    End Sub

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
            cn.ExecuteScalar(String.Format("UPDATE ParamApplication SET Valeur='{0}' WHERE Cle='VersionBase'", version))
        Catch ex As Exception
        End Try

    End Sub

End Class

Public Class ProgressEventArgs
    Public progress As Integer = 0
    Public max As Integer = 100
    Public status As String = ""
    Public Sub New()

    End Sub

    Public Sub New(ByVal progress As Integer, Optional ByVal max As Integer = 100, Optional ByVal status As String = "")
        Me.progress = progress
        Me.max = max
        Me.status = status
    End Sub
End Class