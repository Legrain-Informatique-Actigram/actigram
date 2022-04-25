Public Class FrSauvegarde

#Region "Page"
    Private Sub FrSauvegarde_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.DossiersShowTableAdapter.Fill(Me.DbDonneesDataSet.Dossiers)

        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel2.Height
            .BringToFront()
            .Visible = False
        End With
        TxCheminSav.Text = My.Settings.LireParametre("CheSauvegarde", Application.StartupPath & "\Sauvegarde")
        cboDossier.SelectedIndex = cboDossier.FindString(My.User.Name)
        If cboDossier.SelectedValue IsNot Nothing Then TxNomFichier.Text = "PEAVM" + cboDossier.SelectedValue.ToString
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtSauvegarder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSauvegarder.Click
        If cboDossier.SelectedValue Is Nothing Then Exit Sub
        Dim sDossier As String = Convert.ToString(CType(cboDossier.SelectedItem, DataRowView)("DDossier"))
        Dim sExploitation As String = Convert.ToString(CType(cboDossier.SelectedItem, DataRowView)("DExpl"))
        Try
            My.Settings.EcrireParametre("CheSauvegarde", TxCheminSav.Text)
            My.Settings.Save()
        Catch ex As Exception
            LogException(ex)
        End Try


        If TxCheminSav.Text.Trim.Length = 0 Or TxNomFichier.Text.Trim.Length = 0 Then Exit Sub

        Dim dirSauv As String = TxCheminSav.Text
        If Not IO.Directory.Exists(dirSauv) Then IO.Directory.CreateDirectory(dirSauv)
        'Vérifie l'existance du fichier
        Dim fichierSauv As String = IO.Path.Combine(dirSauv, TxNomFichier.Text)
        fichierSauv &= CStr(IIf(ChkZip.Checked, ".zip", ".xml"))
        If IO.File.Exists(fichierSauv) Then
            If MsgBox(String.Format(My.Resources.Strings.FIchierExistant, IO.Path.GetFileName(fichierSauv)), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor
        PanProgress.Visible = True
        Application.DoEvents()
        Try
            Try
                ReportProgress(0, My.Resources.Strings.Initialisation)

                ReportProgress(0, My.Resources.Strings.ChargementDesDonnees)
                Dim dsSave As New dbSauvRest
                'Dossier
                Me.PlanComptableTableAdapter.FillByDossier(dsSave.PlanComptable, sDossier)
                Me.PiecesTableAdapter.FillByDossier(dsSave.Pieces, sDossier)
                ReportProgress(12)
                Me.MouvementsTableAdapter.FillByDossier(dsSave.Mouvements, sDossier)
                Me.LignesTableAdapter.FillByDossier(dsSave.Lignes, sDossier)
                ReportProgress(24)
                Me.InventaireLignesTableAdapter.FillByDossier(dsSave.InventaireLignes, sDossier)
                Me.InventaireGroupesTableAdapter.FillByDossier(dsSave.InventaireGroupes, sDossier)
                ReportProgress(36)
                Me.ImmobilisationsTableAdapter.FillByDossier(dsSave.Immobilisations, sDossier)
                Me.DossiersTableAdapter.FillByDossier(dsSave.Dossiers, sDossier)
                ReportProgress(48)
                Me.ComptesTableAdapter.FillByDossier(dsSave.Comptes, sDossier)
                Me.ActivitesTableAdapter.FillByDossier(dsSave.Activites, sDossier)
                ReportProgress(60)
                'Exploitation
                Me.ExploitationsTableAdapter.FillByExploitation(dsSave.Exploitations, sExploitation)
                Try
                    Me.ModLignesTableAdapter.FillByExploitation(dsSave.ModLignes, sExploitation)
                Catch ex As ConstraintException
                End Try
                Me.ModMouvementsTableAdapter.FillByExploitation(dsSave.ModMouvements, sExploitation)
                ReportProgress(72)
                Me.EmpruntLignesTableAdapter.FillByExploitation(dsSave.EmpruntLignes, sExploitation)
                ReportProgress(84)
                Me.EmpruntGroupesTableAdapter.FillByExploitation(dsSave.EmpruntGroupes, sExploitation)

                ReportProgress(84, My.Resources.Strings.EcritureDuFichier)

                'On passe par un fichier temporaire pour sauvegarder
                Dim tempDir As String = String.Format("{0}AgrigestSave{1:yyMMddHHmmss}", IO.Path.GetTempPath, Now)
                Dim cheminXml As String = IO.Path.Combine(tempDir, TxNomFichier.Text & ".xml")

                IO.Directory.CreateDirectory(tempDir)
                dsSave.WriteXml(cheminXml, XmlWriteMode.WriteSchema)

                'Compression du fichier temporaire
                If ChkZip.Checked Then
                    ReportProgress(92, My.Resources.Strings.Sauvegarde_CompressionDesDonnees)
                    Dim tempPath As String = IO.Path.GetTempFileName
                    Dim fz As New ICSharpCode.SharpZipLib.Zip.FastZip
                    fz.CreateZip(tempPath, tempDir, False, "", "")
                    'Déplacement de la sauvegarde vers la destination finale
                    If IO.File.Exists(fichierSauv) Then IO.File.Delete(fichierSauv)
                    IO.File.Move(tempPath, fichierSauv)
                Else
                    If IO.File.Exists(fichierSauv) Then IO.File.Delete(fichierSauv)
                    IO.File.Move(cheminXml, fichierSauv)
                End If
                'Suppression du répertoire temporaire
                Try
                    IO.Directory.Delete(tempDir, True)
                Catch
                End Try


                ReportProgress(100, My.Resources.Strings.Sauvegarde_Achevee)
                MsgBox(My.Resources.Strings.Sauvegarde_Succes, MsgBoxStyle.Information, My.Resources.Strings.Sauvegarde)
                'Process.Start(TxCheminSav.Text)
                Me.DialogResult = DialogResult.OK

            Catch ex As ApplicationException
                If MsgBox(My.Resources.Strings.Sauvegarde_RecapProblemes & vbCrLf & _
                ex.Message & vbCrLf & My.Resources.Strings.EnregistrerRapport, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                    With saveDlg
                        .DefaultExt = "txt"
                        .Filter = "Fichiers texte (*.txt)|*.txt"
                        .FileName = "Rapport d'erreur sauvegarde.txt"
                        If .ShowDialog = DialogResult.OK Then
                            My.Computer.FileSystem.WriteAllText(.FileName, ex.Message, False)
                            Process.Start(.FileName)
                        End If
                    End With
                End If
                Me.DialogResult = DialogResult.Cancel
            End Try
            Me.Close()
        Finally
            'PanProgress.Visible = False
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        With folderDlg
            If TxCheminSav.Text = "" Then
                .SelectedPath = My.Settings.LireParametre("CheSauvegarde", Application.StartupPath & "\Sauvegarde")
            Else
                .SelectedPath = TxCheminSav.Text
            End If
            If .ShowDialog = DialogResult.OK Then
                TxCheminSav.Text = .SelectedPath
            End If
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = CStr(status)
            Application.DoEvents()
        End If
        Me.pgBar.Value = percent
    End Sub
#End Region

    Private Sub cboDossier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDossier.SelectedIndexChanged
        If cboDossier.SelectedValue Is Nothing Then Exit Sub
        TxNomFichier.Text = "PEAVM" + cboDossier.SelectedValue.ToString
    End Sub
End Class