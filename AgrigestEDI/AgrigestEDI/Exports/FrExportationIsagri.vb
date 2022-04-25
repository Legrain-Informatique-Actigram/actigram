Imports AgrigestEDI.Interfaces.IsAgri
Public Class FrExportationIsagri

#Region "Boutons"
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtExporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExporter.Click
        If TxCheminExport.Text.Trim.Length = 0 Or TxNomFichier.Text.Trim.Length = 0 Then Exit Sub
        'Enregistrer la préférence du fichier d'Export IsAgri
        Dim dirExport As String = TxCheminExport.Text
        Try
            My.Settings.EcrireParametre("CheExpIsAgri", dirExport)
            My.Settings.Save()
        Catch ex As Exception
            LogException(ex)
        End Try

        'Archiver le contenu de dirExport
        If ChkArchiver.Checked Then ArchiveRepertoire(dirExport)
        'Créer un raccourci vers le répertoire d'export sur le bureau
        If ChkRaccourci.Checked Then RaccourciRepertoire(dirExport)

        Dim fichierExport As String = IO.Path.Combine(dirExport, TxNomFichier.Text)
        If IO.File.Exists(fichierExport) Then
            If MsgBox(String.Format(My.Resources.Strings.FIchierExistant, IO.Path.GetFileName(fichierExport)), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor
        PanProgress.Visible = True
        Application.DoEvents()
        Try
            Dim nDossier As String = My.User.Name
            Dim nExpl As String = My.Dossier.Principal.CodeExpl
            If Not String.IsNullOrEmpty(Me.TxCodeExpl.Text.Trim) Then
                nExpl = Me.TxCodeExpl.Text.Trim
            End If

            Try
                Dim opt As New OptionsExport(chkFullCompta.Checked, String.Format("export dossier {1} au {2:yyMMdd}", nExpl, nDossier, Now.Date))
                Dim ex As New Exportateur
                AddHandler ex.ExportProgressed, AddressOf ExportProgressed
                ex.Exporter(nExpl, nDossier, fichierExport, opt)

                ReportProgress(100)
                MsgBox(My.Resources.Strings.Export_Succes, MsgBoxStyle.Information, "Export")
                Process.Start(dirExport)
                If nExpl <> My.Dossier.Principal.CodeExpl AndAlso nExpl <> My.Settings.Exploitation.CodeExplImport Then
                    If MsgBox(String.Format("Voulez-vous enregistrer '{0}' comme code dossier d'exportation pour cette exploitation ?", nExpl), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        With My.Settings.Exploitation
                            .CodeExplImport = nExpl
                            .Enregistrer()
                        End With
                    End If
                End If
                Me.DialogResult = DialogResult.OK
            Catch ex As ApplicationException
                If MsgBox(My.Resources.Strings.Export_RecapProblemes & vbCrLf & _
                ex.Message & vbCrLf & My.Resources.Strings.EnregistrerRapport, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                    With saveDlg
                        .DefaultExt = "txt"
                        .Filter = "Fichiers texte (*.txt)|*.txt"
                        .FileName = "Rapport d'erreur exportation compta.txt"
                        If .ShowDialog = DialogResult.OK Then
                            WriteToTextFile(.FileName, ex.Message + vbCrLf + ex.StackTrace)
                            Process.Start(.FileName)
                        End If
                    End With
                End If
                Me.DialogResult = DialogResult.Cancel
            End Try
            Me.Close()
        Finally
            PanProgress.Visible = False
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        With folderDlg
            If TxCheminExport.Text = "" Then
                .SelectedPath = My.Settings.LireParametre("CheExpIsAgri", Application.StartupPath & "\Exports")
            Else
                .SelectedPath = TxCheminExport.Text
            End If
            If .ShowDialog = DialogResult.OK Then
                TxCheminExport.Text = .SelectedPath
            End If
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ArchiveRepertoire(ByVal dir As String, Optional ByVal overwrite As Boolean = True)
        If Not IO.Directory.Exists(dir & "\Archives") Then IO.Directory.CreateDirectory(dir & "\Archives")
        Dim files() As String = IO.Directory.GetFiles(dir, "*.ecr")
        For Each f As String In files
            Dim dest As String = dir & "\Archives\" & IO.Path.GetFileName(f)
            If IO.File.Exists(dest) AndAlso overwrite Then
                IO.File.Delete(dest)
            End If
            IO.File.Move(f, dest)
        Next
    End Sub

    Private Sub RaccourciRepertoire(ByVal dir As String)
        Dim nomRaccourci As String = IO.Path.GetFileNameWithoutExtension(dir)
        Dim fichierRaccourci As String = String.Format("{0}\{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), nomRaccourci)
        Dim s As New vbAccelerator.Components.Shell.ShellLink
        If IO.File.Exists(fichierRaccourci) Then
            s.Open(fichierRaccourci)
        End If
        s.Target = dir
        s.Description = My.Resources.Strings.Export_DescriptionRaccourciExports
        s.Save(fichierRaccourci)
    End Sub

    Private Sub WriteToTextFile(ByVal filename As String, ByVal text As String)
        Dim sw As New IO.StreamWriter(filename)
        Try
            sw.WriteLine(text)
        Finally
            sw.Close()
        End Try
    End Sub

    Private Sub ExportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs)
        ReportProgress(e.Percent, e.Status)
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = CStr(status)
            Application.DoEvents()
        End If
        Me.pgBar.Value = percent
    End Sub
#End Region

#Region "Page"
    Private Sub FrExportationIsagri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel3.Height
            .BringToFront()
            .Visible = False
        End With
        Me.chkFullCompta.Checked = My.Dossier.Principal.ExportComplet
        Dim dirExport As String = My.Settings.LireParametre("CheExpIsAgri", Application.StartupPath & "\Exports")
        'Dim dirExport As String = FrMDI.Parametres.LireParametre("CheExpIsAgri", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
        If Not IO.Directory.Exists(dirExport) Then IO.Directory.CreateDirectory(dirExport)
        Dim nExpl As String = CInt(Mid(My.User.Name, 2, 5)).ToString
        Dim nDos As String = Mid(My.User.Name, 2)
        TxCheminExport.Text = dirExport
        Me.TxCodeExpl.Text = ""
        If Not String.IsNullOrEmpty(My.Settings.Exploitation.CodeExplImport) Then
            Me.TxCodeExpl.Text = My.Settings.Exploitation.CodeExplImport
        Else
            If My.Settings.Exploitation.CodeExpl.StartsWith("C") Then
                Me.TxCodeExpl.Text = My.Settings.Exploitation.CodeExpl.Substring(1)
            Else
                Me.TxCodeExpl.Text = My.Settings.Exploitation.CodeExpl
            End If
        End If
        TxNomFichier.Text = String.Format("{0}-export_exo_{1}_au_{2:yyMMdd}.ecr", Me.TxCodeExpl.Text, nDos, Now.Date)
    End Sub
#End Region

    Private Sub BtAnnulerExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnulerExport.Click
        Call New FrExportationIsagriAnnulation().ShowDialog()
    End Sub

End Class
