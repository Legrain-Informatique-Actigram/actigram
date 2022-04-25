Imports System.Data.SqlClient

Public Class Migration
    Const UIDAgrifactOld As String = "{67104DAD-E5C4-4D73-8932-091430A2A4F8}"
    Const fichierXMLParamInstallSQLEXPRESS As String = "ParamInstallSQLEXPRESS.xml"

    Public Shared log As New System.Text.StringBuilder()

    Public Sub MigrerAgrifact()
        Try
            'Désinstallation de l'ancienne version d'Agrifact
            If (DesintallerAncienneVersion()) Then
                'Chargement des informations présentes dans l'ancien fichier Parametres.xml
                Dim parametres As New ArrayList

                'Récupération des informations des dossiers dans l'ancien fichier Parametres.xml
                parametres = ExecParam.ReadAllParams("Ancienne")

                'Sauvegarde des bases de données
                Utilitaires.UtilitairesSQLServer.SauverBases(parametres)

                'Les bases de données définies dans l'ancien fichier Parametres.xml sont détachées
                Utilitaires.UtilitairesSQLServer.DetacherBases(parametres, "Ancienne")

                'Chargement des paramètres d'installation de SQLEXPRESS
                Dim cheminXMLParamInstallSQLEXPRESS As String = Environment.CurrentDirectory & "\" & fichierXMLParamInstallSQLEXPRESS

                If (System.IO.File.Exists(cheminXMLParamInstallSQLEXPRESS)) Then
                    Dim paramSQLEXPRESS As New ParamInstallSQLEXPRESS(cheminXMLParamInstallSQLEXPRESS)

                    'Installation de l'intance de SQLEXPRESS
                    Utilitaires.UtilitairesSQLServer.InstallerSQLEXPRESS(paramSQLEXPRESS.InstanceSql, paramSQLEXPRESS.SaPwd, paramSQLEXPRESS.CheminAccesFichierInstallSQLEXPRESS, paramSQLEXPRESS.Account)

                    'Démarrage du service Sql
                    Utilitaires.UtilitairesSQLServer.DemarrerServiceSql(paramSQLEXPRESS.InstanceSql)

                    'Joint les bases de données à l'instance de SQLEXPRESS
                    Utilitaires.UtilitairesSQLServer.AttacherBases(parametres, paramSQLEXPRESS.InstanceSql, "Ancienne")

                    'Copie les informations de l'ancien Parametres.xml dans le nouveau
                    Utilitaires.UtilitairesParametres.InitialiserParametres(parametres, paramSQLEXPRESS.InstanceSql)
                End If

                'Installation de la nouvelle version d'Agrifact
                IntallerNouvelleVersion()
            Else
                Migration.log.AppendFormat("Migration annulée.")
                Console.WriteLine("Migration annulée.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function DesintallerAncienneVersion() As Boolean
        Dim uninstallRegKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")

        Try
            If Not (uninstallRegKey.OpenSubKey(UIDAgrifactOld) Is Nothing) Then
                'Création du nouveau Parametres.xml si necessaire
                Utilitaires.UtilitairesDivers.CreerNouveauFichierParametresXML()

                Dim commandeDesinstallation As String = "MsiExec.exe /X" & UIDAgrifactOld & " /PASSIVE"
                Dim uninstallProcessStartInfo As New ProcessStartInfo("cmd.exe")

                uninstallProcessStartInfo.Arguments = "/C " & """" & commandeDesinstallation & """"
                uninstallProcessStartInfo.UseShellExecute = True
                uninstallProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal

                Dim uninstallProcess As Process = Process.Start(uninstallProcessStartInfo)
                uninstallProcess.WaitForExit()

                Migration.log.AppendFormat("Désinstallation de l'ancienne version d'Agrifact terminée." & vbCrLf)
                Console.WriteLine("Désinstallation de l'ancienne version d'Agrifact terminée.")

                Return True
            Else
                Migration.log.AppendFormat("Pas d'ancienne version d'Agrifact détectée." & vbCrLf)
                Console.WriteLine("Pas d'ancienne version d'Agrifact détectée.")

                Return False
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub IntallerNouvelleVersion()
        Dim cheminFichierSetup As String = Environment.CurrentDirectory & "\setupAgrifact.2.5.exe"

        Try
            If (System.IO.File.Exists(cheminFichierSetup)) Then
                Dim uninstallProcessStartInfo As New ProcessStartInfo(cheminFichierSetup)

                'uninstallProcessStartInfo.Arguments = "/C " & """" & cheminFichierSetup & """"
                uninstallProcessStartInfo.UseShellExecute = True
                uninstallProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden

                Dim uninstallProcess As Process = Process.Start(uninstallProcessStartInfo)
                uninstallProcess.WaitForExit()

                Migration.log.AppendFormat("Nouvelle version d'Agrifact installée à partir du fichier <{0}>." & vbCrLf, cheminFichierSetup)
                Console.WriteLine("Nouvelle version d'Agrifact installée.")
            Else
                Migration.log.AppendFormat("Fichier setupAgrifact introuvable dans le chemin <{0}>." & vbCrLf, cheminFichierSetup)
                Console.WriteLine("Fichier setupAgrifact introuvable dans le chemin <" & cheminFichierSetup & ">.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
