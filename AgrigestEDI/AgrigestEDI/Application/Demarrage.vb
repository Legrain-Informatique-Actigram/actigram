Public Class Demarrage

    Public StartupExpl As String

    Public Event StartupProgressed(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

#Region "Méthodes diverses"
    Private Sub SetProgress(ByVal progress As Integer, Optional ByVal status As String = Nothing)
        RaiseEvent StartupProgressed(Me, New System.ComponentModel.ProgressChangedEventArgs(progress, status))
    End Sub

    Public Sub Run()
        'FtpCogedis.ParamsFtp.EncryptParam()
        'DebugMethods.test()

        Cursor.Current = Cursors.WaitCursor
        LogMessage(String.Format("{3} -  V{0} du {4:dd/MM/yy} lancée sur {1} par {2}", My.Application.Info.Version, My.Computer.Name, Environment.UserName, Now, BuildDate()))

        With My.Settings
            If .MustUpgrade Then
                .Upgrade()
                .MustUpgrade = False
                .Save()
                LogMessage("Paramètres d'application mis à jour depuis une version antérieure.")
            End If
        End With

        SetProgress(0, My.Resources.Strings.Initialisation)
        SetProgress(20, My.Resources.Strings.Demarrage_VerifCle)

        'Vérification de la clé
        My.Settings.Cle = LectureCleActivation()
        If My.Settings.Cle Is Nothing Then
            MsgBox(My.Resources.Strings.Demarrage_CopiePasActivee, MsgBoxStyle.Exclamation)
            LogMessage(My.Resources.Strings.Demarrage_CopiePasActivee)
            End
        End If

        If My.Settings.AutoUpdate Then
            SetProgress(25, "Recherche des mises à jour")
            FrUpdates.VerifUpdates()
        End If

        'Préchargement(Crystal)
        'SetProgress(30, "Préchargement Crystal")
        'EcranCrystal.PrechargementAsync()

        SetProgress(30, My.Resources.Strings.Demarrage_ChoixDeLExploitation)
        Using fr As New ChoixExploitation
            fr.SkipIfSingle = True
            If fr.Charger(Me.StartupExpl) Then
                fr.ShowDialog()
            End If
        End Using

        If My.Settings.Exploitation IsNot Nothing Then
            SetProgress(40, My.Resources.Strings.Demarrage_ConnexionBase)
            TestConnexion(My.Settings.CheminBase)

            SetProgress(50, My.Resources.Strings.Demarrage_CompactageDeLaBase)
            CompacterBase(My.Settings.CheminBase)

            'Vérification de l'existence de la base
            If Not IO.File.Exists(My.Settings.CheminBase) Then
                Try
                    'Tentative de restauration en cas de problème
                    SetProgress(60, My.Resources.Strings.Demarrage_Restauration)
                    MsgBox(My.Resources.Strings.Demarrage_Restore1 & vbCrLf & My.Resources.Strings.Demarrage_Restore, MsgBoxStyle.Exclamation, "Attention")
                    RestaurerSauvegarde(My.Settings.CheminBase)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & "Restauration impossible.", MsgBoxStyle.Critical, "Erreur")
                    End
                End Try
            End If

            ''Vérification de la version de la base
            'If Not VerifVersionBase() Then
            '    'MsgBox("La base de données n'est pas compatible avec cette version de l'application." & vbCrLf & "Elle doit être mise à jour.", MsgBoxStyle.Critical)
            '    'End

            '    If (MsgBox("La base de données n'est pas compatible avec cette version de l'application. " & vbCrLf & "Voulez-vous effectuer la mise à jour maintenant ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            '        Dim cheminFichierMigrationBase As String = System.IO.Path.Combine(Application.StartupPath, "MigrationBase.exe")
            '        Dim pi As New ProcessStartInfo

            '        With pi
            '            .FileName = cheminFichierMigrationBase
            '            .Arguments = String.Format("-base=""{0}"" -auto", My.Settings.CheminBase)
            '            .UseShellExecute = True
            '        End With
            '        Dim p As Process = Process.Start(pi)
            '        p.WaitForExit()

            '        'Refaire la vérification de version
            '        If Not VerifVersionBase() Then
            '            MsgBox("La mise à jour a échoué.", MsgBoxStyle.Critical)
            '            End
            '        End If
            '    Else
            '        End
            '    End If
            'End If

            'Téléchargement des EDI => Seulement au démarrage pour ne pas plomber à chaque changement de dossier
            If FtpCogedis.ParamsFtp.IsAvailable AndAlso My.Settings.AutoCheckFTP Then
                SetProgress(70, "Vérification en ligne des EDI")
                FtpCogedis.CheckAndDownload()
            End If

            SetProgress(80, My.Resources.Strings.Demarrage_ChoixDuDossier)
            My.User.CurrentPrincipal = Nothing
            Using fr As New ChoixDossier(My.Settings.Exploitation.CodeExpl)
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.User.CurrentPrincipal = fr.Dossier

                    'Import des EDI => Doit se faire une fois l'exercice choisi
                    If FtpCogedis.ParamsFtp.IsAvailable AndAlso My.Settings.AutoImportEDI Then
                        SetProgress(90, "Importation des EDI")
                        FrImportEdis.VerifEdis()
                    End If

                End If
            End Using
        End If
        Cursor.Current = Cursors.Default
        SetProgress(100, My.Resources.Strings.Demarrage_OuvertureDeLApplication)
    End Sub
#End Region

#Region "Shared"
    Public Shared Function LectureCleActivation(Optional ByVal forceForm As Boolean = False) As Securite.Activation.Cle
        Dim res As Securite.Activation.Cle = Nothing
        'Lire la clé dans la base de registre
        Dim c As String = GetValueRegistre("Cle", "")
        Dim codeUtil As String = GetValueRegistre("CodeUtilisateur", "")
        If c <> "" Then
            Try
                res = Securite.Activation.Cle.Parse(Securite.XorEncryption.EnCrypt(Long.Parse(c, Globalization.NumberStyles.HexNumber)))
                If Not res.IsValid(codeUtil) Then
                    If res.DateValidite.Date < Now.Date Then
                        MsgBox(String.Format(My.Resources.Strings.Cle_Expiree, res.DateValidite), MsgBoxStyle.Exclamation)
                    Else
                        MsgBox(My.Resources.Strings.Cle_PasValide, MsgBoxStyle.Exclamation)
                    End If
                    res = Nothing
                End If
            Catch ex As Exception
                MsgBox(My.Resources.Strings.Cle_PasValide, MsgBoxStyle.Exclamation)
                res = Nothing
            End Try
        End If
        'Si elle n'est pas présente, ouvrir la fenêtre FrActivation
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
            SetValueRegistre("CodeUtilisateur", codeUtil)
        End If
        Return res
    End Function

    Private Shared Sub InitCleInstallation()
        Try
            Dim CheminBaseII As String = GetValueRegistre("Dossier_Install", "")
            If CheminBaseII = "" Then
                SetValueRegistre("Dossier_Install", Application.StartupPath)
            End If
        Catch
        End Try
    End Sub

    Private Shared Function LectCleCG() As String
        Return GetValueRegistre("CG", "")
    End Function

#Region "Fonctions Registre"
    Private Const CLE_REGISTRE As String = "SOFTWARE\ESAP\AgrigestEDI"

    Private Shared Function GetCleRegistre() As Microsoft.Win32.RegistryKey
        Return Microsoft.Win32.Registry.LocalMachine.OpenSubKey(CLE_REGISTRE, True)
    End Function

    Private Shared Function CreateCleRegistre() As Microsoft.Win32.RegistryKey
        Return Microsoft.Win32.Registry.LocalMachine.CreateSubKey(CLE_REGISTRE)
    End Function

    Private Shared Function GetValueRegistre(ByVal valueName As String, Optional ByVal defaultValue As String = "") As String
        Dim key As Microsoft.Win32.RegistryKey = GetCleRegistre()
        If Not key Is Nothing Then
            Dim val As String = Convert.ToString(key.GetValue(valueName, defaultValue))
            key.Close()
            Return val
        Else
            Return defaultValue
        End If
    End Function

    Private Shared Sub SetValueRegistre(ByVal valueName As String, ByVal value As String)
        Dim key As Microsoft.Win32.RegistryKey = GetCleRegistre()
        If key Is Nothing Then key = CreateCleRegistre()
        key.SetValue(valueName, value)
        key.Close()
    End Sub
#End Region

    Private Const Taille_100Mo As Integer = 104857600

    Private Shared Sub CompacterBase(ByVal baseSource As String)
        'Compactage de la BDD 
        ' Ne marche plus : trouver comment y caller le mot de passe !!!
        ' En attendant, on désactive le mot de passe 'CBP' de la BDD 
        If IO.File.Exists(baseSource) Then
            If New IO.FileInfo(baseSource).Length > Taille_100Mo Then
                Try
                    Dim baseDest As String = baseSource & ".compacte.mdb"
                    Dim dbEngine As New dao.DBEngineClass
                    If IO.File.Exists(baseDest) Then IO.File.Delete(baseDest)
                    dbEngine.CompactDatabase(baseSource, baseDest)
                    If IO.File.Exists(baseDest) Then
                        IO.File.Delete(baseSource)
                        IO.File.Move(baseDest, baseSource)
                    End If
                Catch
                End Try
            End If
            'Sauvegarde de la base : je l'ai passé après le compactage pour pouvoir le faire en arrière plan.
            SauvegardeFichierAsync(baseSource, 2)
        End If
    End Sub

    Private Shared Sub SauvegardeFichierAsync(ByVal filename As String, Optional ByVal nbKeep As Integer = 0)
        Dim th As New Threading.Thread(AddressOf SauvegardeFichier)
        th.Start(filename & ";" & nbKeep)
    End Sub

    Private Shared Sub SauvegardeFichier(ByVal param As Object)
        If Not TypeOf param Is String Then Exit Sub
        Dim params() As String = CStr(param).Split(";"c)
        SauvegardeFichier(params(0), CInt(params(1)))
    End Sub

    Private Shared Sub SauvegardeFichier(ByVal filename As String, Optional ByVal nbKeep As Integer = 0)
        Dim dirSauv As String = String.Format("{0}\Sauvegarde", My.Application.GetAppDataPath)
        If Not IO.Directory.Exists(dirSauv) Then IO.Directory.CreateDirectory(dirSauv)
        Dim nom As String = IO.Path.GetFileNameWithoutExtension(filename)
        Dim ext As String = IO.Path.GetExtension(filename)
        IO.File.Copy(filename, String.Format("{0}\{1}.{2:yyyyMMdd_HHmm}{3}", dirSauv, nom, Now, ext), True)
        If nbKeep > 0 Then
            Dim files() As String = IO.Directory.GetFiles(dirSauv, String.Format("{0}.*{1}", nom, ext))
            If files.Length > nbKeep Then
                Array.Sort(files)
                For i As Integer = 0 To files.Length - 1 - nbKeep
                    Try
                        IO.File.Delete(files(i))
                    Catch
                    End Try
                Next
            End If
        End If
    End Sub

    Private Shared Sub RestaurerSauvegarde(ByVal filename As String)
        Dim dirSauv As String = String.Format("{0}\Sauvegarde", My.Application.GetAppDataPath)
        If Not IO.Directory.Exists(dirSauv) Then
            Throw New ApplicationException(My.Resources.Strings.Restore_RepertoireEstIntrouvable)
        End If
        Dim nom As String = IO.Path.GetFileNameWithoutExtension(filename)
        Dim ext As String = IO.Path.GetExtension(filename)
        Dim files() As String = IO.Directory.GetFiles(dirSauv, String.Format("{0}.*{1}", nom, ext))
        If files.Length = 0 Then
            Throw New ApplicationException(String.Format(My.Resources.Strings.Restore_AucuneSauvegardeDisponible, nom, ext))
        End If
        Array.Sort(files)
        Dim backup As String = files(files.Length - 1)
        IO.File.Copy(backup, filename)
        Dim fi As New IO.FileInfo(backup)
        MsgBox(String.Format(My.Resources.Strings.Restore_Restauree, nom, ext, fi.LastWriteTime))
    End Sub

    Private Shared Sub TestConnexion()
        TestConnexion(My.Settings.CheminBase)
    End Sub

    Private Shared Sub TestConnexion(ByVal cheminBase As String)
        If IO.File.Exists(cheminBase) Then
            Try
                UtilBase.ConnecterBase(cheminBase)
            Catch ex As OleDb.OleDbException
                Try
                    IO.File.Move(cheminBase, cheminBase & ".corrompu")
                Catch
                End Try
            End Try
        End If
    End Sub

    Private Shared Function VerifVersionBase() As Boolean
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Try
                Dim sql As String = "SELECT Valeur FROM ParamApplication WHERE Cle='VersionBase'"
                Dim versionBase As String = UtilBase.ExecuteScalarStr(sql, conn)
                Return versionBase = My.Settings.VersionBase
            Catch ex As OleDb.OleDbException
                LogException(ex)
                Return False
            End Try
        End Using
    End Function
#End Region

End Class