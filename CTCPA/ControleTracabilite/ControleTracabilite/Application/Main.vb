Imports ControleTracabilite.GestionMenu
Public Class Main

    Private Const NOM_ACCUEIL As String = "Accueil"
    Private origConnString As String

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "Page"
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Init
        Me.Text = WindowText()
        Me.NavPane.NavigationPages.Clear()
        'Connexion
        ChargerUser()
    End Sub
#End Region

#Region " Gestion des evenements des forms enfants "
    Private Sub ChildFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        'MajBoutons(True)
    End Sub
#End Region

#Region "Boutons"
    Private Sub SauvegardeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SauvegardeToolStripMenuItem.Click
        Sauvegarde()
    End Sub

    Private Sub RestaurerUneSauvegardeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurerUneSauvegardeToolStripMenuItem.Click
        If Not FrValidAdmin.ValidAdmin Then Exit Sub
        Restaurer()
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ParamètresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamètresToolStripMenuItem.Click
        origConnString = My.Settings.ConnString
        Dim fr As New FrParametres
        With fr
            AddHandler .FormClosed, AddressOf ParamFormClosed
            .Owner = Me
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function WindowText() As String
        Dim vers As String
#If DEBUG Then
        vers = My.Application.Info.Version.ToString
#Else
        vers = My.Application.Info.Version.ToString(2)
#End If
        Return String.Format("{0} - v{2}", My.Application.Info.Title, My.User.Name, vers)
    End Function

    Private Sub ChargerUser()
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        'Gestion de la sécurité
        Me.Text = WindowText()

        'Chargement du menu
        GestionMenu.Menu.ChargerMenus(Me.NavPane, New EventHandler(AddressOf MenuItemActivate))

        Select Case VerifIdentiteServeur()
            Case Windows.Forms.DialogResult.OK
                'Rien, on continue
                ServiceNormal()
            Case Windows.Forms.DialogResult.Retry
                'Paramétrage à vérifier
                ServiceMinimum()
                ParamètresToolStripMenuItem_Click(Nothing, Nothing)
            Case Windows.Forms.DialogResult.Abort
                'Erreur : sortie de l'application
                ServiceMinimum()
        End Select
    End Sub

    Private Sub ServiceMinimum()
        Me.NavPane.Enabled = False
        Me.SauvegardeToolStripMenuItem.Enabled = False
    End Sub

    Private Sub ServiceNormal()
        Me.NavPane.Enabled = True
        Me.SauvegardeToolStripMenuItem.Enabled = True
    End Sub

    Private Sub MenuItemActivate(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Item
        If TypeOf sender Is Control Then
            i = CType(CType(sender, Control).Tag, Item)
        ElseIf TypeOf sender Is ListViewItem Then
            i = CType(CType(sender, ListViewItem).Tag, Item)
        Else
            Exit Sub
        End If
        If i.Form IsNot Nothing AndAlso i.Form.Length > 0 Then
            AfficherEcran(i.Form, i.Dialog, i.Arguments)
        Else
            Select Case i.Nom
            End Select
        End If
    End Sub

    Public Sub AfficherEcran(ByVal className As String, Optional ByVal dialog As Boolean = False, Optional ByVal arguments As String = Nothing)
        Try
            Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
            If asm.GetType(GetType(Main).Namespace & "." & className, False) Is Nothing Then
                Throw New ApplicationException("Le nom de classe est incorrect")
            End If
            Dim f As Object = asm.CreateInstance(GetType(Main).Namespace & "." & className)
            If Not TypeOf f Is Form Then
                Throw New ApplicationException("La classe définie n'est pas un écran")
            End If
            AfficherEcran(CType(f, Form), dialog, arguments)
        Catch ex As Exception
            LogException(ex)
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub AfficherEcran(ByVal fr As Form, Optional ByVal dialog As Boolean = False, Optional ByVal arguments As String = Nothing)
        If TypeOf fr Is IArgumentable Then DirectCast(fr, IArgumentable).Arguments = arguments
        If Not TypeOf fr Is IPrechargement OrElse CType(fr, IPrechargement).Precharger Then
            If dialog Then
                With fr
                    .Owner = Me
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                Me.NavPane.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()
                If fr.Name <> NOM_ACCUEIL Then
                    Array.ForEach(Me.MdiChildren, AddressOf CloseForm)
                End If
                With fr
                    AddHandler .FormClosed, AddressOf ChildFormClosed
                    .Owner = Me
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With
                Me.NavPane.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Public Shared Sub CloseForm(ByVal f As Form)
        If f.Name <> NOM_ACCUEIL Then
            f.Close()
        Else
            f.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub ParamFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If My.Settings.ConnString <> origConnString Then
            Select Case VerifIdentiteServeur()
                Case Windows.Forms.DialogResult.OK
                    'Rien, on continue
                    ServiceNormal()
                Case Windows.Forms.DialogResult.Retry
                    'Paramétrage à vérifier
                    ServiceMinimum()
                Case Windows.Forms.DialogResult.Abort
                    'Erreur : sortie de l'application
                    ServiceMinimum()
            End Select
        End If
    End Sub
#End Region

#Region " Maintenance "
    Private Sub MMenuLancerInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuLancerInter.Click
        If Not MMenuLancerInter.Checked Then
            If UltraVnc.Instance.StartVNC() Then
                Me.Text = WindowText() + " - Ultra VNC : Téléintervention en cours"
                MMenuLancerInter.Tag = "Arrêter la téléintervention"
                MMenuLancerInter.Checked = True
            End If
        Else
            UltraVnc.Instance.StopVNC()
            Me.Text = WindowText()
            MMenuLancerInter.Tag = "Lancer la téléintervention"
            MMenuLancerInter.Checked = False
        End If
    End Sub

    Private Sub ActivationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivationToolStripMenuItem.Click
        My.Settings.Cle = My.MyApplication.LectureCleActivation(True)
        If My.Settings.Cle Is Nothing Then Application.Exit()
    End Sub

    Private Sub SessionNetviewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SessionNetviewerToolStripMenuItem.Click
        NetViewer.StartNetViewer()
    End Sub

    Private Sub MMenuLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuLog.Click
        With My.Application.Log.DefaultFileLogWriter
            .Flush()
            OuvrirFichier(.FullLogFileName)
        End With
    End Sub

    Private Sub OuvrirLeRépertoireDapplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeRépertoireDapplicationToolStripMenuItem.Click
        OuvrirFichier(My.Application.Info.DirectoryPath)
    End Sub

    Private Sub OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Click
        If Not FrValidAdmin.ValidAdmin Then Exit Sub
        Dim csBuilder As New SqlClient.SqlConnectionStringBuilder(My.Settings.ConnString)
        OuvrirFichier(CheminComplet("Utilitaire.exe"), , String.Format("-server=""{0}"" -base=""{1}""", csBuilder.DataSource, csBuilder.InitialCatalog))
    End Sub

    Private Sub ImporterDesModèlesDeContrôleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImporterDesModèlesDeContrôleToolStripMenuItem.Click
        If Not FrValidAdmin.ValidAdmin Then Exit Sub
        Using fr As New FrImportModeles
            fr.StartPosition = FormStartPosition.CenterParent
            fr.ShowDialog(Me)
        End Using
    End Sub
#End Region

#Region " Gestion Sauvegarde "
    Private frProgressionSauvegarde As FrProgressBar

    Private Sub PrepareProgression()
        frProgressionSauvegarde = New FrProgressBar
        With frProgressionSauvegarde
            .Maximum = 100
            .Text = ""
            .Show(Me)
        End With
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Application.DoEvents()
    End Sub

    Private Sub RunSauvegarde(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim gs As New GestionSauvegarde
        gs.Sauvegarder(CStr(e.Argument), Cast(Of System.ComponentModel.BackgroundWorker)(sender))
    End Sub

    Private Sub RunRestauration(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim gs As New GestionSauvegarde
        gs.Restaurer(CStr(e.Argument), Application.StartupPath, Cast(Of System.ComponentModel.BackgroundWorker)(sender))
    End Sub

    Private Sub WorkCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Not e.Cancelled Then
            If e.Error IsNot Nothing Then
                LogException(e.Error)
            End If
        End If
        Me.Cursor = Cursors.Default
        Me.Enabled = True
        If frProgressionSauvegarde IsNot Nothing Then
            frProgressionSauvegarde.Close()
            frProgressionSauvegarde = Nothing
        End If
    End Sub


    Private Sub Sauvegarde()
        Array.ForEach(Me.MdiChildren, AddressOf CloseForm)

        Using opD As New SaveFileDialog
            With opD
                .FileName = String.Format("Sauvegarde {0} {1:dd-MM-yyyy}", My.Application.Info.ProductName, Now)
                .Filter = "Sauvegarde complète (*.afz)|*.afz;*.zip"
                .FilterIndex = 0
                .AddExtension = True
                If .ShowDialog = DialogResult.OK Then
                    Application.DoEvents()
                    If .FileName <> "" Then
                        Select Case IO.Path.GetExtension(.FileName).ToLower
                            Case ".afz", ".zip"
                                PrepareProgression()

                                Dim worker As New System.ComponentModel.BackgroundWorker
                                With worker
                                    .WorkerReportsProgress = True
                                    AddHandler .ProgressChanged, AddressOf frProgressionSauvegarde.UpdateProgress
                                    AddHandler .DoWork, AddressOf RunSauvegarde
                                    AddHandler .RunWorkerCompleted, AddressOf WorkCompleted
                                    .RunWorkerAsync(opD.FileName)
                                End With
                        End Select
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub Restaurer()
        Array.ForEach(Me.MdiChildren, AddressOf CloseForm)

        Using opD As New OpenFileDialog
            With opD
                .Filter = "Sauvegarde complète (*.afz)|*.afz;*.zip"
                .FilterIndex = 0
                If .ShowDialog = DialogResult.OK Then
                    Application.DoEvents()
                    If MsgBox("Cette opération va écraser les données actuelles de l'application." & vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    Try
                        Select Case IO.Path.GetExtension(.FileName).ToLower
                            Case ".afz", ".zip"
                                PrepareProgression()

                                Dim worker As New System.ComponentModel.BackgroundWorker
                                With worker
                                    .WorkerReportsProgress = True
                                    AddHandler .ProgressChanged, AddressOf frProgressionSauvegarde.UpdateProgress
                                    AddHandler .DoWork, AddressOf RunRestauration
                                    AddHandler .RunWorkerCompleted, AddressOf WorkCompleted
                                    .RunWorkerAsync(opD.FileName)
                                End With
                        End Select
                    Catch ex As Exception
                        LogException(ex)
                        MsgBox(ex.Message)
                    End Try
                End If
            End With
        End Using
    End Sub


#End Region

#Region "Méthodes partagées"
    Public Shared Function VerifIdentiteServeur() As DialogResult
        Dim res As DialogResult
        Using s As New SqlProxy
            Try
                s.Open()
                'Requete sur la table Entreprise pour valider les droits de l'utilisateur 
                'et vérifier que la base est bien Agrifact
                s.ExecuteScalarInt("select count(*) as cnt from Entreprise")
                'Vérifier la version de la base
                VerifierVersionBase(s)
                res = System.Windows.Forms.DialogResult.OK
            Catch ex As SqlClient.SqlException
                Dim msg As String = ""
                Select Case ex.Number
                    Case 17 'Serveur introuvable
                        'Essayer de démarrer le serveur, on sait jamais.
                        If Not TryRestartServer(s.Connection.DataSource) Then
                            msg = String.Format("Le serveur de base de données '{0}' est introuvable.", s.Connection.DataSource)
                        Else
                            res = VerifIdentiteServeur()
                        End If
                    Case 208 'Objet introuvable'
                        msg = String.Format("La base de données '{0}' n'est pas une base {1}.", s.Connection.Database, Application.ProductName)
                        res = System.Windows.Forms.DialogResult.Retry
                    Case 229 'Autorisation refusée
                        msg = String.Format("Vous n'avez pas les droits pour accéder à la base de données '{0}'.", s.Connection.Database)
                        res = System.Windows.Forms.DialogResult.Retry
                    Case 4060 'Base inexistante ou hors ligne
                        msg = String.Format("La base de données '{0}' n'existe pas ou vous n'avez pas les droits pour y accéder.", s.Connection.Database)
                        res = System.Windows.Forms.DialogResult.Retry
                    Case 18456 'Erreur de login password
                        res = System.Windows.Forms.DialogResult.Retry
                    Case Else
                        msg = "Erreur : " & ex.Message
                        res = System.Windows.Forms.DialogResult.Abort
                End Select
                If res = System.Windows.Forms.DialogResult.Abort Then
                    MsgBox(msg, MsgBoxStyle.Critical, "Attention")
                ElseIf res = Windows.Forms.DialogResult.Retry Then
                    MsgBox(msg & vbCrLf & "Vérifiez le paramétrage.", MsgBoxStyle.Exclamation, "Attention")
                End If
            Catch ex As ApplicationException 'Retour de VerifierVersionBase
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Attention")
                res = System.Windows.Forms.DialogResult.Abort
            End Try
        End Using
        Return res
    End Function

    Private Shared Function TryRestartServer(ByVal server As String) As Boolean
        server = server.ToUpper.Replace(Environment.MachineName.ToUpper, ".")
        If server.StartsWith(".") Then
            Dim cmd As String = "NET START MSSQL"
            If server.Length > 1 Then
                cmd &= "$" & server.Replace(".\", "")
            End If
            Dim pi As New ProcessStartInfo
            With pi
                .FileName = "cmd.exe"
                .Arguments = "/C """ & cmd & """"
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            Dim p As Process = Process.Start(pi)
            p.WaitForExit(10000)
            Return p.ExitCode = 0
        Else
            Return False
        End If
    End Function

    Public Shared Sub VerifierVersionBase(ByVal s As SqlProxy)
        Dim versionappli As New Version(My.Settings.VersionBase)
        Dim versionbase As Version = Nothing
        Try
            versionbase = New Version(Convert.ToString(s.ExecuteScalar("select valeur from ParamApplication where cle='VersionBase'")))
        Catch ex As Exception
            'On ne fait rien en cas d'exception, on remonte juste une version "0.0"
        End Try
        If versionbase Is Nothing Then versionbase = New Version("0.0")
        If CompareVersions(versionbase, versionappli) > 0 Then
            Throw New ApplicationException(String.Format("L'application n'est pas à jour, vous devez obtenir une mise à jour."))
        ElseIf CompareVersions(versionbase, versionappli, 2) < 0 Then
            Dim databaseUpdate As String = IO.Path.Combine(Application.StartupPath, "DatabaseUpdate.exe")
            If IO.File.Exists(databaseUpdate) Then
                Dim fv As FileVersionInfo = FileVersionInfo.GetVersionInfo(databaseUpdate)
                If versionappli.ToString(2) = fv.FileMajorPart & "." & fv.FileMinorPart _
                AndAlso MsgBox(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}." & vbCrLf & "Voulez-vous effectuer la mise à jour maintenant ?", versionappli), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim pi As New ProcessStartInfo
                    With pi
                        .FileName = databaseUpdate
                        .Arguments = String.Format("-conn=""{0}"" -auto", My.Settings.ConnString)
                        .UseShellExecute = True
                    End With
                    Dim p As Process = Process.Start(pi)
                    p.WaitForExit()
                    'Refaire la vérif
                    VerifierVersionBase(s)
                Else
                    Throw New ApplicationException(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}.", versionappli))
                End If
            Else
                Throw New ApplicationException(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}.", versionappli))
            End If
        End If
    End Sub

    Private Shared Function CompareVersions(ByVal a As Version, ByVal b As Version, Optional ByVal fieldCount As Integer = 4) As Integer
        Dim res As Integer = a.Major - b.Major
        If res = 0 Then
            res = a.Minor - b.Minor
            If res = 0 Then
                res = a.Build - b.Build
                If res = 0 Then
                    res = a.Revision - b.Revision
                End If
            End If
        End If
        Return res
    End Function
#End Region

End Class

