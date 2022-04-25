Imports ICSharpCode.SharpZipLib.Zip
Imports System.Configuration

Public Class GestionSauvegarde

    Private worker As System.ComponentModel.BackgroundWorker

#Region "Méthodes diverses"
    Private Sub ReportProgress(ByVal progress As Integer, Optional ByVal status As String = Nothing)
        If worker Is Nothing Then Exit Sub
        worker.ReportProgress(progress, status)
    End Sub

    'A mettre dans l'archive : 
    ' - Données de la base (Backup de la base) seulement si on est sur le serveur de données
    ' - Fichier parametres
    ' - Fichier Manifest de la sauvegarde
    Public Sub Sauvegarder(ByVal fichierSauvegarde As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        If worker IsNot Nothing Then Me.worker = worker

        ReportProgress(0, "Initialisation")

        'Créer un répertoire temporaire
        Dim tempDir As String = Environment.ExpandEnvironmentVariables(String.Format("{0}SolstyceSave{1:yyMMddHHmmss}", "%windir%\Temp\", Now))
        IO.Directory.CreateDirectory(tempDir)

        Try

            Dim m As New ManifestSauvegarde

            'Enregistrer la base de données
            ReportProgress(10, "Sauvegarde des données")
            Try
                BackupDatabase(My.Settings.ConnString, tempDir & "\Donnees.bk")
                m.Items.Add(New DatabaseBackup("Base de données", "Donnees.bk", ""))
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Avertissement")
            End Try

            'Copier le fichier "Parametres"
            ReportProgress(40, "Sauvegarde des paramètres")
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
            IO.File.Copy(config.FilePath, IO.Path.Combine(tempDir, IO.Path.GetFileName(config.FilePath)))
            m.Items.Add(New Fichier("Paramétrage", IO.Path.GetFileName(config.FilePath), True))

            'Ajouter le fichier Manifest
            m.Enregistrer(tempDir & "\MANIFEST.XML")

            'Zipper le résultat dans le nom de fichier passé en paramètre
            ReportProgress(75, "Compression des données")
            Dim fz As New FastZip
            fz.CreateZip(tempDir & ".zip", tempDir, True, "", "")
            IO.File.Move(tempDir & ".zip", fichierSauvegarde)

            'Supprimer le répertoire temporaire
            ReportProgress(100, "Finalisation")
        Finally
            Try
                IO.Directory.Delete(tempDir, True)
            Catch
            End Try
        End Try
    End Sub

    Public Sub Restaurer(ByVal fichierSauvegarde As String, ByVal repDest As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        If worker IsNot Nothing Then Me.worker = worker

        ReportProgress(10, "Décompression des données")

        'Créer un répertoire temporaire
        Dim tempDir As String = Environment.ExpandEnvironmentVariables(String.Format("{0}AgrifactRestore{1:yyMMddHHmmss}", "%windir%\Temp\", Now))
        IO.Directory.CreateDirectory(tempDir)

        Try
            Dim fz As New FastZip
            fz.ExtractZip(fichierSauvegarde, tempDir, "")

            Dim m As ManifestSauvegarde = LireEtVerifierManifest(tempDir)

            'Faire choisir les items à restaurer
            Using FrChoix As New FrChoixRestauration(m)
                FrChoix.TopMost = True
                If FrChoix.ShowDialog() = DialogResult.Cancel Then
                    Throw New Exception("Restauration annulée")
                Else
                    m = FrChoix.Selection
                End If
            End Using

            ReportProgress(10, "Vérification de la sauvegarde")
            If Not IO.Directory.Exists(repDest) Then IO.Directory.CreateDirectory(repDest)

            Dim i As Integer = 0
            For Each item As ItemBackup In m.Items
                i += 1
                ReportProgress((i * 80 \ m.Items.Count) + 10, "Restauration en cours de : " & item.description)
                If TypeOf item Is DatabaseBackup Then
                    'Restauration d'une base de données
                    Try
                        Dim db As DatabaseBackup = CType(item, DatabaseBackup)
                        RestoreDatabase(My.Settings.ConnString, tempDir & "\" & db.fichierBackup, db.nomBase)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Avertissement")
                    End Try
                ElseIf TypeOf item Is Dossier Then
                    'Restauration d'un dossier
                    Dim d As Dossier = CType(item, Dossier)
                    CopyDir(tempDir & "\" & d.nomDossier, repDest)
                ElseIf TypeOf item Is Fichier Then
                    'Restauration d'un fichier
                    Dim f As Fichier = CType(item, Fichier)
                    Dim fichierOri As String = repDest & "\" & f.nomFichier
                    If IO.File.Exists(fichierOri) And f.sauvegarderFichierAvantRemplacement Then
                        'Eventuellement sauvegarde du fichier existant
                        IO.File.Copy(fichierOri, fichierOri & ".bak", True)
                    End If
                    IO.File.Copy(tempDir & "\" & f.nomFichier, fichierOri, True)
                Else
                    'Type de données à récupérer inconnu
                End If
            Next

        Catch ex As ZipException
            Throw New Exception("Fichier sauvegarde invalide." & vbCrLf & "Restauration impossible.")
        Catch ex As Exception
            Throw ex
        Finally
            ReportProgress(100, "Finalisation")
            IO.Directory.Delete(tempDir, True)
        End Try
    End Sub

    Private Function LireEtVerifierManifest(ByVal repDonnees As String) As ManifestSauvegarde
        Dim m As ManifestSauvegarde

        Try
            'Charger le MANIFEST
            m = ManifestSauvegarde.Charger(repDonnees & "\MANIFEST.XML")
        Catch ex As Exception
            'Plante si le fichier est absent ou endommagé
            If MsgBox("La sauvegarde semble endommagée." & vbCrLf & _
                    "La restauration risque de rencontrer des problèmes." & vbCrLf & _
                    "Souhaitez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Créer un MANIFEST standard pour tenter la restauration
                m = New ManifestSauvegarde
                m.Items.Add(New DatabaseBackup("Base de données", "Donnees.bk", ""))
                m.Items.Add(New Fichier("Paramétrage", "user.config", True))
            Else
                Throw New Exception("Restauration annulée")
            End If
        End Try


        'Vérification de la version de sauvegarde
        Select Case m.Version
            Case Is <= ManifestSauvegarde.VERSION_COURANTE
                'Faire ici les traitements qui s'imposent pour la rétrocompatibilité
            Case Else 'Cas des versions de sauvegarde non gérées
                If MsgBox("Cette sauvegarde a été produite par une version plus récente d'AgriFact." & vbCrLf & _
                "La restauration risque de rencontrer des problèmes." & vbCrLf & _
                "Souhaitez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Throw New Exception("Restauration annulée")
                End If
        End Select

        'Pour chaque Item du MANIFEST, vérifier que les éléments sont présents
        For i As Integer = m.Items.Count - 1 To 0 Step -1
            Dim item As ItemBackup = CType(m.Items(i), ItemBackup)
            Dim verif As Boolean = True
            If TypeOf item Is DatabaseBackup Then
                verif = IO.File.Exists(repDonnees & "\" & CType(item, DatabaseBackup).fichierBackup)
            ElseIf TypeOf item Is Fichier Then
                verif = IO.File.Exists(repDonnees & "\" & CType(item, Fichier).nomFichier)
            ElseIf TypeOf item Is Dossier Then
                verif = IO.Directory.Exists(repDonnees & "\" & CType(item, Dossier).nomDossier)
            Else
                'Type de données à récupérer inconnu
            End If

            'Si absence, demander à l'utilisateur si la restauration doit quand même avoir lieu
            If Not verif Then
                If MsgBox("L'élément '" & item.description & "' n'est pas présent dans la sauvegarde." & vbCrLf & _
                    "Cet élément ne pourra pas être restauré." & vbCrLf & _
                    "Souhaitez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Supprimer l'item du manifest utilisé pour la restauration
                    m.Items.RemoveAt(i)
                Else
                    Throw New Exception("Restauration annulée")
                End If
            End If
        Next

        If m.Items.Count = 0 Then
            Throw New Exception("Aucun élément n'est récupérable." & vbCrLf & "Restauration annulée.")
        End If

        Return m
    End Function
#End Region

#Region "Fonctions SQL Server"
    Private Shared Sub BackupDatabase(ByVal connectionString As String, ByVal filename As String)
        Dim conn As New SqlClient.SqlConnection(connectionString)
        Try
            conn.Open()
            'Vérification qu'on se trouve bien sur le serveur de données
            Dim cmd As New SqlClient.SqlCommand("SELECT SERVERPROPERTY('MachineName')", conn)
            Dim serverName As String = CStr(cmd.ExecuteScalar)
            If String.Compare(serverName, Environment.MachineName, True) <> 0 Then
                Throw New Exception("La sauvegarde des données est impossible depuis un poste distant." & vbCrLf & _
                                    "Pour sauvegarder les données vous devez executer Agrifact sur le poste hébergeant la base de données.")
            Else
                cmd.CommandText = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}' WITH FORMAT,INIT", conn.Database, filename)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
    End Sub

    Private Shared Sub RestoreDatabase(ByVal connectionString As String, ByVal filename As String, Optional ByVal baseARestaurer As String = "")
        Dim conn As New SqlClient.SqlConnection(connectionString)
        Try
            conn.Open()

            'Récuperer le nom et le serveur de la base Agrifact courante 
            '(pour savoir si c'est une restauration ou un transfert de données)
            Dim curBaseName As String = conn.Database
            Dim curServerName As String = conn.DataSource

            'Vérification qu'on se trouve bien sur le serveur de données
            Dim cmd As New SqlClient.SqlCommand("SELECT SERVERPROPERTY('MachineName')", conn)
            Dim serverName As String = CStr(cmd.ExecuteScalar)
            If String.Compare(serverName, Environment.MachineName, True) <> 0 Then
                Throw New Exception("L'import des données est impossible depuis un poste distant." & vbCrLf & _
                                    "Pour importer les données vous devez executer Agrifact sur le poste hébergeant la base de données.")
            End If

            'Se placer sur la base MASTER
            cmd.CommandText = "USE MASTER"
            cmd.ExecuteNonQuery()

            'Récupérer le nom et le serveur de la base de données dans le fichier de sauvegarde
            cmd.CommandText = String.Format("RESTORE HEADERONLY FROM DISK='{0}' WITH FILE=1", filename)
            Dim srcBaseName As String = ""
            Dim srcServerName As String = ""
            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                srcBaseName = CStr(dr("DatabaseName"))
                srcServerName = CStr(dr("ServerName"))
            End If
            dr.Close()

            Dim sqlRestore As String
            If (baseARestaurer = "" Or baseARestaurer = srcBaseName) And srcBaseName = curBaseName And srcServerName = curServerName Then
                'On restaure la base telle qu'elle a été sauvegardée (la sauvegarde a bien été faite sur le poste en cours, pas de gestion de fichier à faire)
                baseARestaurer = srcBaseName
                sqlRestore = String.Format("RESTORE DATABASE [{0}] FROM DISK='{1}' WITH REPLACE", baseARestaurer, filename)
            Else
                'On restaure la base sauvegardée dans une nouvelle base ou sur une nouvelle machine


                'Trouver les noms logiques des fichiers de la base
                Dim dataLogicalFile As String = "", logLogicalFile As String = ""
                cmd.CommandText = String.Format("RESTORE FILELISTONLY FROM DISK='{0}' WITH FILE=1", filename)
                dr = cmd.ExecuteReader
                While dr.Read
                    Select Case CStr(dr("Type"))
                        Case "D"
                            dataLogicalFile = CStr(dr("LogicalName"))
                        Case "L"
                            logLogicalFile = CStr(dr("LogicalName"))
                    End Select
                End While
                dr.Close()

                If baseARestaurer = "" Or baseARestaurer = curBaseName Then
                    baseARestaurer = curBaseName

                    'Trouver les noms physiques des fichiers actuels
                    Dim dataPhysicalFile As String = "", logPhysicalFile As String = ""
                    cmd.CommandText = String.Format("SELECT * FROM [{0}]..sysfiles", baseARestaurer)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        Select Case CInt(dr("groupid"))
                            Case 1
                                dataPhysicalFile = CStr(dr("filename")).Trim
                            Case 0
                                logPhysicalFile = CStr(dr("filename")).Trim
                        End Select
                    End While
                    dr.Close()

                    sqlRestore = String.Format("RESTORE DATABASE [{0}] FROM DISK='{1}' WITH REPLACE, MOVE '{2}' TO '{4}', MOVE '{3}' TO '{5}'", baseARestaurer, filename, dataLogicalFile, logLogicalFile, dataPhysicalFile, logPhysicalFile)
                Else
                    'C'est une nouvelle base, on pose les fichiers dans un nouvel emplacement
                    Dim PhysicalFile As String = Application.StartupPath & "\Data\" & baseARestaurer
                    sqlRestore = String.Format("RESTORE DATABASE [{0}] FROM DISK='{1}' WITH REPLACE, MOVE '{2}' TO '{4}.mdf', MOVE '{3}' TO '{4}.ldf'", baseARestaurer, filename, dataLogicalFile, logLogicalFile, PhysicalFile)
                End If
            End If

            'Placer la base en SINGLE USER pour tuer les connexions existantes
            cmd.CommandText = String.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", baseARestaurer)
            cmd.ExecuteNonQuery()

            'Execution de la commande de restauration
            cmd.CommandText = sqlRestore
            cmd.ExecuteNonQuery()

            cmd.CommandText = String.Format("ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE", baseARestaurer)
            cmd.ExecuteNonQuery()
            conn.Close()

            'Recréer les utilisateurs pour réparer les connexions
            'TODO A revoir... pour le moment on se connecte tout le temps SA alors...
            'RecreerUtilisateurs(connectionString, baseARestaurer)

        Catch ex As Exception
            Throw ex
        Finally
            If conn.State <> ConnectionState.Closed Then
                Dim cmd As New SqlClient.SqlCommand(String.Format("ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE", baseARestaurer), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            End If
        End Try
    End Sub

    Public Shared Sub RecreerUtilisateurs(ByVal connectionString As String, ByVal base As String)
        Dim conn As New SqlClient.SqlConnection(connectionString)
        conn.Open()

        If conn.Database.ToLower <> base.ToLower Then
            Dim cmd As New SqlClient.SqlCommand("USE " & base, conn)
            cmd.ExecuteNonQuery()
        End If

        Dim rapport As New System.Text.StringBuilder
        Dim dt As New DataTable
        Dim dta As New SqlClient.SqlDataAdapter("Select Utilisateur, Password From Utilisateurs", conn)
        dta.Fill(dt)

        For Each rw As DataRow In dt.Rows
            Try
                RecreerUtilisateur(conn, Convert.ToString(rw("Utilisateur")), Convert.ToString(rw("Password")), base)
            Catch ex As Exception
                rapport.AppendFormat("Erreur dans la création de l'utilisateur {0} : {1}" & vbCrLf, rw("Utilisateur"), ex.Message)
            End Try
        Next
        conn.Close()

        If rapport.Length > 0 Then
            Throw New Exception(rapport.ToString)
        End If

    End Sub

    Private Shared Sub RecreerUtilisateur(ByRef conn As SqlClient.SqlConnection, ByVal Utilisateur As String, ByVal Password As String, ByVal BaseSql As String)
        Dim cmd As New SqlClient.SqlCommand("", conn)
        cmd.CommandText = "select count(*) from master.dbo.syslogins where name='" & Utilisateur & "'"
        If CInt(cmd.ExecuteScalar()) = 0 Then
            'Si le login n'existe pas, le créer
            cmd.CommandText = String.Format("Exec sp_addlogin @loginame=N'{0}',@passwd=N'{1}',@defdb={2}", Utilisateur, Password, BaseSql)
            cmd.ExecuteNonQuery()
        Else
            'Sinon MAJ son Password
            cmd.CommandText = String.Format("Exec sp_password NULL, '{1}', '{0}'", Utilisateur, Password)
            cmd.ExecuteNonQuery()
        End If

        'Si l'utilisateur de BDD existe, le supprimer
        Try
            cmd.CommandText = String.Format("Exec sp_dropuser '{0}'", Utilisateur)
            cmd.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            If ex.Number <> 15008 Then Throw ex
        End Try

        'Créer le user dans la base dans le groupe "Utilisateurs"
        cmd.CommandText = String.Format("Exec sp_adduser '{0}','{0}','{1}'", Utilisateur, "Utilisateurs")
        cmd.ExecuteNonQuery()
    End Sub
#End Region

#Region "Méthodes partagées"
    Private Shared Sub CopyDir(ByVal dirSrc As String, ByVal dirDest As String, Optional ByVal overwrite As Boolean = True, Optional ByVal recurse As Boolean = True)
        Dim fics() As String = IO.Directory.GetFiles(dirSrc)
        If fics.Length > 0 Then
            Dim dirCopy As String = dirDest & "\" & IO.Path.GetFileName(dirSrc)
            If Not IO.Directory.Exists(dirCopy) Then IO.Directory.CreateDirectory(dirCopy)
            For Each fic As String In fics
                IO.File.Copy(fic, dirCopy & "\" & IO.Path.GetFileName(fic), overwrite)
            Next
        End If
        If recurse Then
            Dim dirs() As String = IO.Directory.GetDirectories(dirSrc)
            If dirs.Length > 0 Then
                Dim dirCopy As String = dirDest & "\" & IO.Path.GetFileName(dirSrc)
                If Not IO.Directory.Exists(dirCopy) Then IO.Directory.CreateDirectory(dirCopy)
                For Each dir As String In dirs
                    CopyDir(dir, dirCopy, overwrite, recurse)
                Next
            End If
        End If
    End Sub
#End Region

#Region "Structure du Manifest de la sauvegarde"
    Public Class ManifestSauvegarde

        Public Const VERSION_COURANTE As String = "1.0"
        <Xml.Serialization.XmlAttribute()> Public Version As String

        <Xml.Serialization.XmlArray(), _
        Xml.Serialization.XmlArrayItem(GetType(DatabaseBackup)), _
        Xml.Serialization.XmlArrayItem(GetType(Dossier)), _
        Xml.Serialization.XmlArrayItem(GetType(Fichier))> _
        Public Items As New ArrayList

#Region "Constructeur"
        Public Sub New()
            Me.Version = VERSION_COURANTE
        End Sub
#End Region

#Region "Import/Export XML"
        Public Sub Enregistrer(ByVal fichier As String)
            Dim xser As New Xml.Serialization.XmlSerializer(GetType(ManifestSauvegarde))
            Dim sw As New IO.StreamWriter(fichier)
            xser.Serialize(sw, Me)
            sw.Close()
        End Sub

        Public Shared Function Charger(ByVal fichier As String) As ManifestSauvegarde
            Dim m As ManifestSauvegarde
            Dim xser As New Xml.Serialization.XmlSerializer(GetType(ManifestSauvegarde))
            Dim sr As New IO.StreamReader(fichier)
            Try
                m = CType(xser.Deserialize(sr), ManifestSauvegarde)
            Finally
                sr.Close()
            End Try
            Return m
        End Function
#End Region

    End Class

    Public Class ItemBackup

        <Xml.Serialization.XmlAttribute()> Public description As String

#Region "Méthodes diverses"
        Public Overrides Function ToString() As String
            Return description
        End Function
#End Region

    End Class

    Public Class DatabaseBackup
        Inherits ItemBackup

        <Xml.Serialization.XmlAttribute()> Public fichierBackup As String
        <Xml.Serialization.XmlAttribute()> Public nomBase As String

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal description As String, ByVal fichierBackup As String, ByVal nomBase As String)
            Me.New()
            Me.description = description
            Me.fichierBackup = fichierBackup
            Me.nomBase = nomBase
        End Sub
#End Region

    End Class

    Public Class Dossier
        Inherits ItemBackup

        <Xml.Serialization.XmlAttribute()> Public nomDossier As String

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal description As String, ByVal nomDossier As String)
            Me.New()
            Me.description = description
            Me.nomDossier = nomDossier
        End Sub
#End Region

    End Class

    Public Class Fichier
        Inherits ItemBackup

        <Xml.Serialization.XmlAttribute()> Public nomFichier As String
        <Xml.Serialization.XmlAttribute()> Public sauvegarderFichierAvantRemplacement As Boolean = False

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal description As String, ByVal nomFichier As String, ByVal sauvegarderFichierAvantRemplacement As Boolean)
            Me.New()
            Me.description = description
            Me.nomFichier = nomFichier
            Me.sauvegarderFichierAvantRemplacement = sauvegarderFichierAvantRemplacement
        End Sub
#End Region

    End Class
#End Region

End Class
