Imports System.Data.SqlClient

Namespace Utilitaires
    Public Class UtilitairesSQLServer

#Region "Méthodes partagées"
        Public Shared Sub DemarrerServiceSql(ByVal instanceSql As String)
            Dim sqlServ As New ServiceProcess.ServiceController("MSSQL$" & instanceSql, Environment.MachineName)

            If sqlServ.Status <> ServiceProcess.ServiceControllerStatus.Running Then
                sqlServ.Start()
            End If

            sqlServ.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromMinutes(1))

            Console.WriteLine("Service SQLEXPRESS démarré.")
        End Sub

        Public Shared Function TestConnection(ByVal connString As String) As Boolean
            Try
                Return TestConnection(New SqlConnection(connString))
            Catch ex As SqlClient.SqlException
                'Console.WriteLine("Connexion à la base de données impossible : " & connString & " " & ex.Message)
                Return False
            End Try
        End Function

        Public Shared Function TestConnection(ByVal conn As SqlConnection) As Boolean
            Try
                Dim build As New SqlConnectionStringBuilder(conn.ConnectionString)
                build.ConnectTimeout = 5
                conn.ConnectionString = build.ConnectionString
                conn.Open()
                Return True

            Catch ex As SqlClient.SqlException
                'Console.WriteLine("Connexion à la base de données impossible : " & conn.ConnectionString & " " & ex.Message)
                Return False
            Finally
                If conn IsNot Nothing Then
                    conn.Close()
                End If
            End Try
        End Function

        Public Shared Sub SauverBases(ByVal parametres As ArrayList)
            Dim connString As String = String.Empty

            For Each par As ExecParam In parametres
                Try
                    'Construction de la chaîne de connexion
                    connString = ConstruireConnString(par)

                    If TestConnection(connString) Then
                        Dim connStringMaster As String = ConstruireConnString(par, True)
                        Dim queryString As String = String.Empty

                        'Récupération des noms de fichiers et de leur emplacement
                        queryString = "SELECT sysaltfiles.fileid, sysaltfiles.filename " & _
                                        "FROM sysdatabases INNER JOIN sysaltfiles " & _
                                        "ON sysdatabases.dbid = sysaltfiles.dbid " & _
                                        "WHERE sysdatabases.name='" & Replace(par.BaseSQL, "'", "''") & "'"

                        Using sqlConn As New SqlConnection(connStringMaster)
                            Dim sqlComm As New SqlCommand(queryString, sqlConn)
                            sqlConn.Open()

                            Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()

                            While sqlDR.Read()
                                If (CInt(sqlDR.Item("fileid")) = 1) Then
                                    par.CheminAccesFichierMDF = Convert.ToString(sqlDR.Item("filename")).Trim
                                ElseIf (CInt(sqlDR.Item("fileid")) = 2) Then
                                    par.CheminAccesFichierLDF = Convert.ToString(sqlDR.Item("filename")).Trim
                                End If
                            End While

                            sqlDR.Close()

                            'Passe la base de données en accès exclusif
                            queryString = "ALTER DATABASE [" & par.BaseSQL & "] " & _
                                            "SET SINGLE_USER WITH ROLLBACK IMMEDIATE"

                            sqlComm.CommandText = queryString

                            sqlComm.ExecuteNonQuery()

                            'Sauve la base de données
                            queryString = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", par.BaseSQL, Replace(par.CheminAccesFichierMDF, "mdf", "bak"))

                            'Fait une copie des fichiers mdf et ldf
                            'System.IO.File.Copy(par.CheminAccesFichierMDF, Replace(par.CheminAccesFichierMDF, ".mdf", "_save.mdf"), True)
                            'System.IO.File.Copy(par.CheminAccesFichierMDF, Replace(par.CheminAccesFichierLDF, ".ldf", "_save.ldf"), True)

                            sqlComm.CommandText = queryString

                            sqlComm.ExecuteNonQuery()

                            Migration.log.AppendFormat("Base <{0}> sauvegardée sous <{1}>." & vbCrLf, par.BaseSQL, Replace(par.CheminAccesFichierMDF, "mdf", "bak"))
                            Console.WriteLine("Base <" & par.BaseSQL & "> sauvegardée sous <" & Replace(par.CheminAccesFichierMDF, "mdf", "bak") & ">.")
                        End Using
                    Else
                        Migration.log.AppendFormat("Connexion à {0} impossible. Pas de sauvegarde de la base {1} effectuée." & vbCrLf, connString, par.BaseSQL)
                        Console.WriteLine("Connexion à <" & connString & "> impossible. Pas de sauvegarde de la base <" & par.BaseSQL & "> effectuée.")
                    End If
                Catch ex As Exception
                    Migration.log.AppendFormat("{0}" & vbCrLf, ex.Message)
                    Console.WriteLine(ex.Message)
                End Try
            Next
        End Sub

        Public Shared Sub DetacherBases(ByVal parametres As ArrayList, Optional ByVal versionAgrifact As String = "Ancienne")
            Dim connString As String = String.Empty

            For Each par As ExecParam In parametres
                Try
                    'Construction de la chaîne de connexion
                    connString = ConstruireConnString(par)

                    If TestConnection(connString) Then
                        Dim connStringMaster As String = ConstruireConnString(par, True)
                        Dim queryString As String = String.Empty

                        'Récupération des noms de fichiers et de leur emplacement
                        queryString = "SELECT sysaltfiles.fileid, sysaltfiles.filename " & _
                                        "FROM sysdatabases INNER JOIN sysaltfiles " & _
                                        "ON sysdatabases.dbid = sysaltfiles.dbid " & _
                                        "WHERE sysdatabases.name='" & Replace(par.BaseSQL, "'", "''") & "'"

                        Using sqlConn As New SqlConnection(connStringMaster)
                            Dim sqlComm As New SqlCommand(queryString, sqlConn)
                            sqlConn.Open()

                            Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()

                            While sqlDR.Read()
                                If (CInt(sqlDR.Item("fileid")) = 1) Then
                                    par.CheminAccesFichierMDF = Convert.ToString(sqlDR.Item("filename")).Trim
                                ElseIf (CInt(sqlDR.Item("fileid")) = 2) Then
                                    par.CheminAccesFichierLDF = Convert.ToString(sqlDR.Item("filename")).Trim
                                End If
                            End While

                            sqlDR.Close()

                            'Passe la base de données en accès exclusif
                            queryString = "ALTER DATABASE [" & par.BaseSQL & "] " & _
                                            "SET SINGLE_USER WITH ROLLBACK IMMEDIATE"

                            sqlComm.CommandText = queryString

                            sqlComm.ExecuteNonQuery()

                            'Détache la base de données
                            queryString = String.Format("exec sp_detach_db @dbname = N'{0}'", Replace(par.BaseSQL, "'", "''"))

                            sqlComm.CommandText = queryString

                            sqlComm.ExecuteNonQuery()

                            Migration.log.AppendFormat("Base <{0}> détachée de l'instance <{1}>." & vbCrLf, par.BaseSQL, par.ServeurSQL)
                            Console.WriteLine("Base <" & par.BaseSQL & "> détachée de l'instance <" & par.ServeurSQL & ">.")
                        End Using
                    Else
                        Migration.log.AppendFormat("Bases de données <{0}> non attachée à l'instance <{1}>. Pas de détachement nécessaire." & vbCrLf, par.BaseSQL, par.ServeurSQL)
                        Console.WriteLine("Bases de données <" & par.BaseSQL & "> non attachée à l'instance <" & par.ServeurSQL & ">. Pas de détachement nécessaire.")
                    End If
                Catch ex As Exception
                    Migration.log.AppendFormat("{0}" & vbCrLf, ex.Message)
                    Console.WriteLine(ex.Message)
                End Try
            Next
        End Sub

        Public Shared Function ConstruireConnString(ByVal par As ExecParam, Optional ByVal master As Boolean = False) As String
            Dim sa As String = String.Empty

            If par.SaPWd Is Nothing Then
                sa = "integrated security=true"
            Else
                sa = String.Format("user id=sa;password={0}", par.SaPWd)
            End If

            Return String.Format("initial catalog={2};data source={0};{1};persist security info=True", IIf(par.ServeurSQL.Contains("\"), par.ServeurSQL, ".\" & par.ServeurSQL), sa, IIf(master = True, "master", par.BaseSQL))
        End Function

        Public Shared Sub AttacherBases(ByVal parametres As ArrayList, ByVal instanceSql As String, Optional ByVal versionAgrifact As String = "Ancienne")
            Dim connString As String = String.Empty

            For Each par As ExecParam In parametres
                Try
                    par.ServeurSQL = My.Computer.Name & "\" & instanceSql
                    'Construction de la chaîne de connexion
                    connString = ConstruireConnString(par, False)

                    'Vérification que les fichiers .mdf et .ldf sont présents
                    If (System.IO.File.Exists(par.CheminAccesFichierMDF) And System.IO.File.Exists(par.CheminAccesFichierLDF)) Then
                        Dim groupeUtilisateursMSSQL As String = My.Computer.Name & "\SQLServer2005MSSQLUser$" & My.Computer.Name & "$" & instanceSql

                        Utilitaires.UtilitairesDivers.AddDirectorySecurity(IO.Path.GetDirectoryName(par.CheminAccesFichierMDF), _
                                             groupeUtilisateursMSSQL, Security.AccessControl.FileSystemRights.FullControl, _
                                             Security.AccessControl.AccessControlType.Allow)

                        'Attache la base
                        Dim connStringMaster As String = ConstruireConnString(par, True)
                        Dim queryString As String = String.Empty

                        queryString = String.Format("exec sp_attach_db @dbname = N'{0}', @filename1 = N'{1}', @filename2 = N'{2}'", Replace(par.BaseSQL, "'", "''"), Replace(par.CheminAccesFichierMDF, "'", "''"), Replace(par.CheminAccesFichierLDF, "'", "''"))

                        Using sqlConn As New SqlConnection(connStringMaster)
                            Dim sqlComm As New SqlCommand(queryString, sqlConn)
                            sqlConn.Open()

                            sqlComm.ExecuteNonQuery()

                            Console.WriteLine("Base <" & par.BaseSQL & "> attachée à l'instance <" & par.ServeurSQL & ">.")
                        End Using

                        'Création des utilisateurs
                        Dim dataSet As New DataSet
                        Dim dataTab As DataTable = Nothing
                        Dim sqlDA As SqlDataAdapter = Nothing

                        queryString = "Select Utilisateur, Password From Utilisateurs"

                        If TestConnection(connString) Then
                            Using sqlConn As New SqlConnection(connString)
                                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                                sqlConn.Open()

                                sqlDA = New SqlDataAdapter(sqlComm)
                                sqlDA.Fill(dataSet, "Utilisateur")
                                dataTab = dataSet.Tables("Utilisateur")

                                For Each utilisateurRow As DataRow In dataTab.Rows
                                    Utilitaires.UtilitairesSQLServer.GererUtilisateurs(utilisateurRow, par.BaseSQL, connString)
                                Next
                            End Using

                            Console.WriteLine("Utilisateurs crées dans la base " & par.BaseSQL & ".")
                        End If
                    Else
                        Console.WriteLine("Impossible de joindre la base de données <" & par.BaseSQL & "> à l'instance <" & instanceSql & "> (Base de données non présente dans l'ancienne instance <" & par.ServeurSQL & ">.")
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Next
        End Sub

        Public Shared Sub GererUtilisateurs(ByVal utilisateurRow As DataRow, ByVal baseParDefaut As String, ByVal connString As String)
            'Création du login si inexistant
            If Not (Utilitaires.UtilitairesSQLServer.LoginExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)) Then
                Utilitaires.UtilitairesSQLServer.CreerLogin(Convert.ToString(utilisateurRow.Item("Utilisateur")), Convert.ToString(utilisateurRow.Item("Password")), baseParDefaut, connString)
            Else 'Sinon MAJ du login
                Utilitaires.UtilitairesSQLServer.ModifierLogin(Convert.ToString(utilisateurRow.Item("Utilisateur")), Convert.ToString(utilisateurRow.Item("Password")), baseParDefaut, connString)
            End If

            'Suppression du schéma dans la base de données
            If (Utilitaires.UtilitairesSQLServer.SchemaExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), baseParDefaut, connString)) Then
                Utilitaires.UtilitairesSQLServer.SupprimerSchema(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
            End If

            'Suppression du user dans la base de données
            If (Utilitaires.UtilitairesSQLServer.UserExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), baseParDefaut, connString)) Then
                Utilitaires.UtilitairesSQLServer.SupprimerUser(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
            End If

            'Création du user dans la base de données
            Utilitaires.UtilitairesSQLServer.CreerUser(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)

            'Ajouter user au rôle Utilisateur
            Utilitaires.UtilitairesSQLServer.AjouterMembreARole(Convert.ToString(utilisateurRow.Item("Utilisateur")), "Utilisateurs", connString)

            'Création du schéma dans la base de données
            Utilitaires.UtilitairesSQLServer.CreerSchema(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
        End Sub

        Public Shared Function LoginExiste(ByVal login As String, ByVal connString As String) As Boolean
            Dim queryString As String = String.Format("select count(*) from master.sys.server_principals where name='{0}';", Replace(login, "'", "''"))
            Dim existe As Boolean = False

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                sqlConn.Open()

                Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()

                While sqlDR.Read()
                    If (CInt(sqlDR(0)) > 0) Then
                        existe = True
                    End If
                End While

                sqlDR.Close()
            End Using

            Return existe
        End Function

        Public Shared Sub CreerLogin(ByVal login As String, ByVal password As String, ByVal baseParDefaut As String, ByVal connString As String)
            Dim queryString As String = String.Format("CREATE LOGIN [{0}] WITH PASSWORD='{1}', DEFAULT_DATABASE=[{2}], CHECK_POLICY=OFF, CHECK_EXPIRATION=OFF", login, password, baseParDefaut)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Sub ModifierLogin(ByVal login As String, ByVal password As String, ByVal baseParDefaut As String, ByVal connString As String)
            Dim queryString As String = String.Format("ALTER LOGIN [{0}] WITH PASSWORD='{1}', DEFAULT_DATABASE=[{2}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", login, password, baseParDefaut)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Function UserExiste(ByVal user As String, ByVal base As String, ByVal connString As String) As Boolean
            Dim queryString As String = String.Format("select count(*) from [{0}].sys.database_principals where name='{1}';", base, Replace(user, "'", "''"))
            Dim existe As Boolean = False

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                sqlConn.Open()

                Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()

                While sqlDR.Read()
                    If (CInt(sqlDR(0)) > 0) Then
                        existe = True
                    End If
                End While

                sqlDR.Close()
            End Using

            Return existe
        End Function

        Public Shared Sub SupprimerUser(ByVal user As String, ByVal connString As String)
            Dim queryString As String = String.Format("DROP USER [{0}]", user)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Sub CreerUser(ByVal user As String, ByVal connString As String)
            Dim queryString As String = String.Format("CREATE USER [{0}] FOR LOGIN [{0}]", user)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Function SchemaExiste(ByVal schema As String, ByVal base As String, ByVal connString As String) As Boolean
            Dim queryString As String = String.Format("select count(*) from [{0}].sys.schemas where name='{1}';", base, Replace(schema, "'", "''"))
            Dim existe As Boolean = False

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                sqlConn.Open()

                Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()

                While sqlDR.Read()
                    If (CInt(sqlDR(0)) > 0) Then
                        existe = True
                    End If
                End While

                sqlDR.Close()
            End Using

            Return existe
        End Function

        Public Shared Sub SupprimerSchema(ByVal schema As String, ByVal connString As String)
            Dim queryString As String = String.Format("DROP SCHEMA [{0}]", schema)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Sub CreerSchema(ByVal schema As String, ByVal connString As String)
            Dim queryString As String = String.Format("CREATE SCHEMA [{0}] AUTHORIZATION [{0}]", schema)

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Sub AjouterMembreARole(ByVal user As String, ByVal role As String, ByVal connString As String)
            Dim queryString As String = String.Format("EXEC sp_addrolemember '{0}', '{1}'", Replace(role, "'", "''"), Replace(user, "'", "''"))

            Using sqlConn As New SqlConnection(connString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)

                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End Sub

        Public Shared Sub InstallerSQLEXPRESS(ByVal instanceName As String, ByVal saPwd As String, ByVal CheminAccesFichierInstallSQLEXPRESS As String, Optional ByVal account As String = Nothing)
            'Si l'instance à créer n'existe pas déjà
            If instanceName Is Nothing OrElse instanceName.Length = 0 Then
                instanceName = "MSSQLSERVER"
            End If

            Dim chemin As String = Environment.CurrentDirectory & CheminAccesFichierInstallSQLEXPRESS

            If Not VerifInstanceSql(instanceName) Then
                If (System.IO.File.Exists(chemin)) Then
                    Dim st As New ProcessStartInfo(chemin)
                    Dim securitySettings As String

                    If saPwd Is Nothing Then
                        securitySettings = ""
                    Else
                        securitySettings = String.Format("SECURITYMODE=SQL SAPWD=""{0}""", saPwd)
                    End If

                    Dim accountSetting As String

                    If account Is Nothing Then
                        accountSetting = ""
                    Else
                        accountSetting = String.Format("SQLACCOUNT=""{0}""", GetAccountName(account))
                    End If

                    st.Arguments = String.Format("-q /norebootchk /qb reboot=ReallySuppress ADDLOCAL=all SQLAUTOSTART=1 {0} {2} INSTANCENAME=""{1}"" DISABLENETWORKPROTOCOLS=0", securitySettings, instanceName, accountSetting)
                    'st.WorkingDirectory = Environment.CurrentDirectory & "\Support\Components"
                    st.UseShellExecute = True
                    st.WindowStyle = ProcessWindowStyle.Normal

                    Dim pr As Process = Process.Start(st)

                    pr.WaitForExit()

                    If (VerifInstanceSql(instanceName)) Then
                        Migration.log.AppendFormat("Installation de l'instance de SQLEXPRESS à partir du fichier {0} terminée." & vbCrLf, chemin)
                        Console.WriteLine("Installation de l'instance de SQLEXPRESS à partir du fichier " & chemin & " terminée.")
                    Else
                        Migration.log.AppendFormat("Impossible d'installer l'instance SQLEXPRESS à partir du fichier {0} terminée." & vbCrLf, chemin)
                        Console.WriteLine("Impossible d'installer l'instance SQLEXPRESS à partir du fichier " & chemin & " terminée.")
                    End If
                Else
                    Migration.log.AppendFormat("Fichier d'installation de SQLEXPRESS <{0}> introuvable." & vbCrLf, chemin)
                    Console.WriteLine("Fichier d'installation de SQLEXPRESS <" & chemin & "> introuvable.")
                End If
            Else
                Migration.log.AppendFormat("L'instance SQLEXPRESS est déjà installée." & vbCrLf)
                Console.WriteLine("L'instance SQLEXPRESS est déjà installée.")
            End If
        End Sub

        Public Shared Function VerifInstanceSql(ByVal instanceName As String) As Boolean
            Using regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft")
                Using subKey As Microsoft.Win32.RegistryKey = regKey.OpenSubKey("Microsoft SQL Server\" & instanceName)
                    Return subKey IsNot Nothing
                End Using
            End Using
        End Function

        Public Shared Function GetAccountName(ByVal accountName As String) As String
            'Gets the account real name : LOCALSYSTEM => AUTORITE NT\System ...
            Dim res As String = ""

            Try
                Dim sidType As System.Security.Principal.WellKnownSidType

                Select Case accountName.ToUpper
                    Case "LOCALSYSTEM"
                        sidType = Security.Principal.WellKnownSidType.LocalSystemSid
                    Case "LOCALSERVICE"
                        sidType = Security.Principal.WellKnownSidType.LocalServiceSid
                    Case "NETWORKSERVICE"
                        sidType = Security.Principal.WellKnownSidType.NetworkServiceSid
                End Select

                Dim sid As New System.Security.Principal.SecurityIdentifier(sidType, Nothing)
                Dim account As System.Security.Principal.NTAccount = CType(sid.Translate(GetType(System.Security.Principal.NTAccount)), System.Security.Principal.NTAccount)

                res = account.Value
            Catch
            End Try
            Return res
        End Function
#End Region

    End Class
End Namespace
