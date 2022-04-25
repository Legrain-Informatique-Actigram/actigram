Imports System.Data.SqlClient
Imports System.Security.Principal

Public Class TachesInstallation

#Region "Propriétés"
    Public parametres As New ParametresInstallation
    Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
    Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"
#End Region

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal parametres As ParametresInstallation)
        Me.New()
        Me.parametres = parametres
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Sub InstallSql()
        If parametres.VersionSql.Equals("SqlExpress", StringComparison.CurrentCultureIgnoreCase) Then
            InstallSqlExpress()
        Else
            InstallMsde()
        End If
    End Sub

    Public Sub InstallMsde()
        'Si l'instance à créer n'existe pas déjà
        Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft")

        If regKey.OpenSubKey("Microsoft SQL Server\" & parametres.InstanceSql) Is Nothing Then
            Dim st As New ProcessStartInfo(Application.StartupPath & "\MSDE\setup.exe")
            st.Arguments = String.Format("SAPWD=""{0}"" SECURITYMODE=SQL INSTANCENAME=""{1}"" DISABLENETWORKPROTOCOLS=0", parametres.SaPwd, parametres.InstanceSql)
            st.WorkingDirectory = Application.StartupPath & "\MSDE"
            st.UseShellExecute = True
            st.WindowStyle = ProcessWindowStyle.Normal
            Dim pr As Process = Process.Start(st)
            pr.WaitForExit()
        Else
            Throw New Exception("L'instance est déjà installée")
        End If
    End Sub

    Public Sub InstallSqlExpress()
        InstallSqlExpress(parametres.InstanceSql, parametres.SaPwd, parametres.Account)
    End Sub

    Public Sub AttacheBase(ByVal paramdossier As ParametresDossier)

        Dim cn As New SqlProxy(ParametresDossier.GetConnexionString(parametres, paramdossier, "master"))

        'Si la base à créer n'existe pas déjà
        If CInt(cn.ExecuteScalar("select count(*) from sysdatabases where name='" & Replace(paramdossier.BaseSql, "'", "''") & "'")) > 0 Then
            'Throw New Exception("La base " & paramdossier.BaseSql & " existe déjà")
            'Pas d'exception si la base existe déjà
            cn.Close()
            Exit Sub
        End If

        Dim strSql As String = String.Empty

        Dim fichierBaseSource As String = parametres.ExpandVars(paramdossier.FichierBaseSource)

        If Not IO.File.Exists(fichierBaseSource & ".mdf") OrElse Not IO.File.Exists(fichierBaseSource & ".ldf") Then
            Throw New ApplicationException("Fichier de base de données introuvable")
        End If

        Dim fichierBaseDest As String = parametres.ExpandVars(paramdossier.RepBaseDest) & "\" & paramdossier.BaseSql

        Dim groupeUtilisateursMSSQL As String = My.Computer.Name & "\SQLServer2005MSSQLUser$" & My.Computer.Name & "$" & parametres.InstanceSql

        'Crée le dossier
        IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichierBaseDest))
        'Donne les droits complets sur le dossier au groupe d'utilisateurs MSSQL
        AddDirectorySecurity(IO.Path.GetDirectoryName(fichierBaseDest), groupeUtilisateursMSSQL, Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)

        'Si les fichiers .mdf et .ldf n'existent pas déjà dans le répertoire de destination
        'on les copie à partir du répertoire source
        If Not IO.File.Exists(fichierBaseDest & ".mdf") Then
            'Copie le fichier
            IO.File.Copy(fichierBaseSource & ".mdf", fichierBaseDest & ".mdf")
            'Donne les droits complets sur le fichier au groupe d'utilisateurs MSSQL
            AddDirectorySecurity(fichierBaseDest & ".mdf", groupeUtilisateursMSSQL, Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)
            'Supprimer les attributs (ReadOnly)
            IO.File.SetAttributes(fichierBaseDest & ".mdf", IO.FileAttributes.Normal)
        End If

        If Not IO.File.Exists(fichierBaseDest & ".ldf") Then
            'Copie le fichier
            IO.File.Copy(fichierBaseSource & ".ldf", fichierBaseDest & ".ldf")
            'Donne les droits complets sur le fichier au groupe d'utilisateurs MSSQL
            AddDirectorySecurity(fichierBaseDest & ".ldf", groupeUtilisateursMSSQL, Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)
            'Supprimer les attributs (ReadOnly)
            IO.File.SetAttributes(fichierBaseDest & ".ldf", IO.FileAttributes.Normal)
        End If

        'Attacher la base de données
        strSql = String.Format("exec sp_attach_db @dbname = N'{0}', @filename1 = N'{1}.mdf', @filename2 = N'{1}.ldf'", Replace(paramdossier.BaseSql, "'", "''"), Replace(fichierBaseDest, "'", "''"))

        cn.ExecuteNonQuery(strSql)
        cn.Close()
    End Sub

    Private Sub AddDirectorySecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As Security.AccessControl.FileSystemRights, ByVal ControlType As Security.AccessControl.AccessControlType)
        ' Create a new DirectoryInfoobject.
        Dim dInfo As New System.IO.DirectoryInfo(FileName)

        ' Get a DirectorySecurity object that represents the 
        ' current security settings.
        Dim dSecurity As Security.AccessControl.DirectorySecurity = dInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        dSecurity.AddAccessRule(New Security.AccessControl.FileSystemAccessRule(Account, Rights, ControlType))

        ' Set the new access settings.
        dInfo.SetAccessControl(dSecurity)

    End Sub

    Public Sub RecreerUtilisateurs(ByVal paramdossier As ParametresDossier)
        If Not paramdossier.RecreerUtils Then Exit Sub

        'Ajout des utilisateurs
        Dim sqlSelect As String = String.Empty
        Dim dataSet As New DataSet
        Dim dataTab As DataTable = Nothing
        Dim sqlDA As SqlDataAdapter = Nothing
        Dim connString As String = ParametresDossier.GetConnexionString(parametres, paramdossier)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand

            TachesInstallation.Delay(2)

            sqlConn.Open()

            sqlComm.Connection = sqlConn

            'Ajout du nom de connexion Windows de l'utilisateur si nécessaire
            If Not (Me.LoginExiste(WindowsIdentity.GetCurrent.Name, connString)) Then
                'Ajout de la connexion
                sqlSelect = String.Format("CREATE LOGIN [{0}] FROM WINDOWS", WindowsIdentity.GetCurrent.Name)

                sqlComm.CommandText = sqlSelect

                sqlComm.ExecuteNonQuery()

                'Octroi des droits sysadmin
                sqlSelect = String.Format("EXEC sp_addsrvrolemember '{0}', 'sysadmin'", WindowsIdentity.GetCurrent.Name)

                sqlComm.CommandText = sqlSelect

                sqlComm.ExecuteNonQuery()
            End If

            'Octroi du rôle db_owner au nom de connexion Windows de l'utilisateur
            Me.AjouterMembreARole(WindowsIdentity.GetCurrent.Name, "db_owner", connString, paramdossier.BaseSql)

            'Récupération de la liste des utilisateurs présents dans la table Utilisateurs
            sqlSelect = "Select Utilisateur, Password From Utilisateurs"
            sqlComm.CommandText = sqlSelect
            sqlDA = New SqlDataAdapter(sqlComm)
            sqlDA.Fill(dataSet, "Utilisateur")
            dataTab = dataSet.Tables("Utilisateur")
        End Using

        For Each utilisateurRow As DataRow In dataTab.Rows
            Me.GererUtilisateurs(utilisateurRow, paramdossier.BaseSql, connString)
        Next
    End Sub

    Private Sub GererUtilisateurs(ByVal utilisateurRow As DataRow, ByVal baseParDefaut As String, ByVal connString As String)
        'Création du login si inexistant
        If Not (Me.LoginExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)) Then
            Me.CreerLogin(Convert.ToString(utilisateurRow.Item("Utilisateur")), Convert.ToString(utilisateurRow.Item("Password")), baseParDefaut, connString)
        Else 'Sinon MAJ du login
            Me.ModifierLogin(Convert.ToString(utilisateurRow.Item("Utilisateur")), Convert.ToString(utilisateurRow.Item("Password")), baseParDefaut, connString)
        End If

        'Suppression du schéma dans la base de données
        If (Me.SchemaExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), baseParDefaut, connString)) Then
            Me.SupprimerSchema(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
        End If

        'Suppression du user dans la base de données
        If (Me.UserExiste(Convert.ToString(utilisateurRow.Item("Utilisateur")), baseParDefaut, connString)) Then
            Me.SupprimerUser(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
        End If

        'Création du user dans la base de données
        Me.CreerUser(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)

        'Ajouter user au rôle Utilisateur
        'avec gestion de l'utilisateur spécial "admin"
        If (Convert.ToString(utilisateurRow.Item("Utilisateur")) <> "agrifactadmin") Then
            Me.AjouterMembreARole(Convert.ToString(utilisateurRow.Item("Utilisateur")), "Utilisateurs", connString)
        Else
            Me.AjouterMembreARole("agrifactadmin", "db_owner", connString)
        End If

        'Création du schéma dans la base de données
        Me.CreerSchema(Convert.ToString(utilisateurRow.Item("Utilisateur")), connString)
    End Sub

    Public Shared Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date

        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)

        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
    End Sub

    Private Function LoginExiste(ByVal login As String, ByVal connString As String) As Boolean
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

    Private Sub CreerLogin(ByVal login As String, ByVal password As String, ByVal baseParDefaut As String, ByVal connString As String)
        Dim queryString As String = String.Format("CREATE LOGIN [{0}] WITH PASSWORD='{1}', DEFAULT_DATABASE=[{2}], CHECK_POLICY=OFF, CHECK_EXPIRATION=OFF", login, password, baseParDefaut)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ModifierLogin(ByVal login As String, ByVal password As String, ByVal baseParDefaut As String, ByVal connString As String)
        Dim queryString As String = String.Format("ALTER LOGIN [{0}] WITH PASSWORD='{1}', DEFAULT_DATABASE=[{2}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", login, password, baseParDefaut)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Function UserExiste(ByVal user As String, ByVal base As String, ByVal connString As String) As Boolean
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

    Private Sub SupprimerUser(ByVal user As String, ByVal connString As String)
        Dim queryString As String = String.Format("DROP USER [{0}]", user)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub CreerUser(ByVal user As String, ByVal connString As String)
        Dim queryString As String = String.Format("CREATE USER [{0}] FOR LOGIN [{0}]", user)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Function SchemaExiste(ByVal schema As String, ByVal base As String, ByVal connString As String) As Boolean
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

    Private Sub SupprimerSchema(ByVal schema As String, ByVal connString As String)
        Dim queryString As String = String.Format("DROP SCHEMA [{0}]", schema)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub CreerSchema(ByVal schema As String, ByVal connString As String)
        Dim queryString As String = String.Format("CREATE SCHEMA [{0}] AUTHORIZATION [{0}]", schema)

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub AjouterMembreARole(ByVal user As String, ByVal role As String, ByVal connString As String)
        Dim queryString As String = String.Format("EXEC sp_addrolemember '{0}', '{1}'", Replace(role, "'", "''"), Replace(user, "'", "''"))

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub AjouterMembreARole(ByVal user As String, ByVal role As String, ByVal connString As String, ByVal BaseSql As String)
        Dim queryString As String = String.Format("USE " & BaseSql & "; EXEC sp_addrolemember '{0}', '{1}'", Replace(role, "'", "''"), Replace(user, "'", "''"))

        Using sqlConn As New SqlConnection(connString)
            Dim sqlComm As New SqlCommand(queryString, sqlConn)

            sqlComm.Connection.Open()
            sqlComm.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub CreerUtilisateur(ByRef cn As SqlProxy, ByVal Nom As String, ByVal Pwd As String, ByVal BaseSql As String)
        Try
            cn.ExecuteNonQuery("Use " & BaseSql)

            Try
                cn.ExecuteNonQuery("Delete From Utilisateurs Where Utilisateur='ludo' And Password='ludo'")
            Catch ex As Exception
            End Try

            Dim nPersonne As String = "1"

            If CInt(cn.ExecuteScalar("Select count(*) From Personne Where Nom='" & Replace(Nom, "'", "''") & "'")) = 0 Then
                '* Recherche du premier nPersonne libre
                Dim oResult As Object = cn.ExecuteScalar("Select Max(nPersonne) From Personne Where nPersonne<1000")

                If Not oResult Is DBNull.Value Then
                    nPersonne = (CInt(oResult) + 1).ToString
                End If

                '* Insertion Personne
                Try
                    cn.ExecuteNonQuery("Insert Into Personne (nPersonne,Nom,Prenom) Values (" & nPersonne & ",'" & Replace(Nom, "'", "''") & "','')")
                Catch
                End Try

                '* Insertion Tel Personne
                Try
                    cn.ExecuteNonQuery("Insert Into Telephone (nPersonne,Type,Numero) Values (" & nPersonne & ",'Portable','')")
                Catch
                End Try
            Else
                nPersonne = CStr(cn.ExecuteScalar("select nPersonne From Personne Where Nom='" & Replace(Nom, "'", "''") & "'"))
            End If

            '* Insertion Utilisateur
            Try
                cn.ExecuteNonQuery("Insert Into Utilisateurs (Utilisateur,Password,Departement,nPersonne,nGroupe) Values ('" & Replace(Nom, "'", "''") & "','" & Pwd & "','Tous'," & nPersonne & ",1)")
            Catch
            End Try

            '* Creation Nouvelle Connexion au server
            Try
                cn.ExecuteNonQuery("Exec sp_addlogin @loginame='" & Replace(Nom, "'", "''") & "',@passwd='" & Pwd & "',@defdb=[" & BaseSql & "]")
            Catch ex As SqlClient.SqlException
                If ex.Number <> 15025 Then
                    MessageBox.Show(ex.Message)
                End If
            End Try

            '* Suppression de l'utilisateur dans la base de données (au cas ou il existerait)
            Try
                cn.ExecuteNonQuery("Exec sp_dropuser @name_in_db='" & Replace(Nom, "'", "''") & "'")
            Catch
            End Try

            '* Creation de l'Utilisateur dans la base de données
            Try
                cn.ExecuteNonQuery("Exec sp_adduser @loginame='" & Replace(Nom, "'", "''") & "',@name_in_db='" & Replace(Nom, "'", "''") & "'")
            Catch ex As SqlClient.SqlException
                If ex.Number <> 15023 Then
                    MessageBox.Show(ex.Message)
                End If
            End Try

            '* Ajout de l'utilisateur du role utilisateurs
            Try
                cn.ExecuteNonQuery("Exec sp_addrolemember 'Utilisateurs','" & Replace(Nom, "'", "''") & "'")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub InitialiserParametres()
        Dim chemin As String = String.Empty
        Dim ancienChemin As String = String.Empty

        chemin = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)

        If Not (IO.File.Exists(chemin)) Then
            ancienChemin = IO.Path.Combine(Application.StartupPath, FICHIER_PARAMETRE)

            If IO.File.Exists(ancienChemin) Then
                'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

                IO.File.Move(ancienChemin, chemin)
            End If
        End If

        Dim fichierParametre As String = chemin

        If IO.File.Exists(fichierParametre) Then
            Dim dsParamLocaux As New DataSet

            dsParamLocaux.ReadXml(fichierParametre)

            If dsParamLocaux.Tables.Contains("Parametres") Then
                Dim tb As DataTable = dsParamLocaux.Tables("Parametres")

                CreateColumn(tb, "NomDossier", GetType(String))
                CreateColumn(tb, "ServeurSQL", GetType(String))
                CreateColumn(tb, "BaseSQL", GetType(String))
                CreateColumn(tb, "saPwd", GetType(String))

                'Enregistrer tous les dossiers
                For Each paramdossier As ParametresDossier In parametres.Dossiers
                    EcrireParametres(tb, paramdossier)
                Next

                'Virer toutes les lignes parametres non initialisées (ServeurSQL vide)
                Dim rwTodelete As New ArrayList

                For Each rw As DataRow In tb.Rows
                    If Convert.ToString(rw("ServeurSQL")).Length = 0 _
                    Or String.Compare(Convert.ToString(rw("ServeurSQL")), "localhost\agrifact", True) = 0 Then
                        rwTodelete.Add(rw)
                    End If
                Next

                For Each rw As DataRow In rwTodelete
                    rw.Delete()
                Next
            End If

            dsParamLocaux.WriteXml(fichierParametre)
        End If
    End Sub

    Private Sub EcrireParametres(ByVal tb As DataTable, ByVal paramdossier As ParametresDossier)
        Dim rw As DataRow

        Select Case tb.Rows.Count
            Case 0 'Cas impossible à priori
                Exit Sub
            Case Else
                Dim rows() As DataRow = tb.Select("NomDossier='" & paramdossier.NomDossier & "'")

                If rows.Length = 0 Then
                    'Le dossier n'existe pas, on va le créer en dupliquant la premiere ligne
                    rw = tb.LoadDataRow(tb.Rows(0).ItemArray, True)
                Else
                    rw = rows(0)
                End If
        End Select

        rw.Item("NomDossier") = paramdossier.NomDossier
        rw.Item("ServeurSQL") = Environment.MachineName & "\" & parametres.InstanceSql
        rw.Item("BaseSQL") = paramdossier.BaseSql
        rw.Item("saPwd") = parametres.SaPwd
    End Sub

    Private Sub CreateColumn(ByVal tb As DataTable, ByVal nomCol As String, ByVal type As Type)
        If Not tb.Columns.Contains(nomCol) Then
            tb.Columns.Add(nomCol, type)
        End If
    End Sub

    Public Sub DemarrerServiceSql()
        Dim sqlServ As New ServiceProcess.ServiceController("MSSQL$" & parametres.InstanceSql, Environment.MachineName)

        If sqlServ.Status <> ServiceProcess.ServiceControllerStatus.Running Then
            sqlServ.Start()
        End If

        sqlServ.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromMinutes(1))
    End Sub

    Public Sub ValiderInstallation()
        If parametres.AgrifactKey Is Nothing Then Exit Sub

        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(parametres.AgrifactKey, True)

        If key Is Nothing Then
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(parametres.AgrifactKey)
        End If

        key.SetValue("InstallBase", "Ok")
        key.Close()
    End Sub

    Public Function VerifierInstallation(Optional ByVal installSqlIfAbsent As Boolean = False) As Boolean
        'TODO Améliorer cette vérif : 
        ' - Est-ce que Parametres existe et n'est pas vierge ?
        ' - ESt-ce que la base désignée par parametres existe ?
        '...
        Dim res As Boolean = False

        If parametres.AgrifactKey IsNot Nothing Then
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(parametres.AgrifactKey, True)

            If Not key Is Nothing Then
                If Not key.GetValue("InstallBase") Is Nothing _
                AndAlso Convert.ToString(key.GetValue("InstallBase")).Length > 0 Then
                    res = True
                End If

                key.Close()
            End If
        Else
            If VerifInstanceSql(parametres.InstanceSql) Then
                For Each paramDossier As ParametresDossier In parametres.Dossiers
                    res = False

                    If Not VerifBaseSql(parametres, paramDossier) Then
                        Exit For
                    Else
                        res = True
                    End If
                Next
            ElseIf installSqlIfAbsent Then
                InstallSql()
            End If
        End If

        Return res
    End Function

    Public Sub InstallAuto(Optional ByVal force As Boolean = False)
        If Not VerifierInstallation(True) Or force Then
            DemarrerServiceSql()

            For Each paramdossier As ParametresDossier In parametres.Dossiers
                'Pause
                TachesInstallation.Delay(2)

                AttacheBase(paramdossier)

                'Pause
                TachesInstallation.Delay(2)

                RecreerUtilisateurs(paramdossier)
            Next

            InitialiserParametres()
            ValiderInstallation()
        Else
            Throw New Exception("Des données Agrifact sont déjà présentes sur l'ordinateur." & vbCrLf & _
                               "L'installation d'une nouvelle base est inutile.")
        End If
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Sub InstallSqlExpress(ByVal instanceName As String, ByVal saPwd As String, Optional ByVal account As String = Nothing)
        'Si l'instance à créer n'existe pas déjà
        If instanceName Is Nothing OrElse instanceName.Length = 0 Then
            instanceName = "MSSQLSERVER"
        End If

        If Not VerifInstanceSql(instanceName) Then
            Dim chemin As String = Environment.CurrentDirectory & "\Support\Components\SQLEXPR_FRA.exe"

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
            st.WorkingDirectory = Environment.CurrentDirectory & "\Support\Components"
            st.UseShellExecute = True
            st.WindowStyle = ProcessWindowStyle.Normal

            Dim pr As Process = Process.Start(st)

            pr.WaitForExit()

            If (VerifInstanceSql(instanceName)) Then
                MsgBox("Installation de l'instance SQL Server " & instanceName & " à partir du fichier " & chemin & " terminée.", MsgBoxStyle.Exclamation, "")
            Else
                MsgBox("Impossible d'installer l'instance SQL Server " & instanceName & " à partir du fichier " & chemin & " terminée.", MsgBoxStyle.Critical, "")
            End If
        Else
            Throw New Exception("L'instance est déjà installée")
        End If
    End Sub

    Private Shared Function GetAccountName(ByVal accountName As String) As String
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

    Private Shared Function VerifInstanceSql(ByVal instanceName As String) As Boolean
        Using regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft")
            Using subKey As Microsoft.Win32.RegistryKey = regKey.OpenSubKey("Microsoft SQL Server\" & instanceName)
                Return subKey IsNot Nothing
            End Using
        End Using
    End Function

    Private Shared Function VerifBaseSql(ByVal param As ParametresInstallation, ByVal dossier As ParametresDossier) As Boolean
        Using cn As New SqlClient.SqlConnection(ParametresDossier.GetConnexionString(param, dossier))
            Try
                cn.Open()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function
#End Region

End Class
