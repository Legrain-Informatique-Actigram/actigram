Public Class FrRestauration

#Region " GUI "
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtRestaurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRestaurer.Click
        If TxNomFichier.Text.Trim.Length = 0 Then Exit Sub

        'Vérifie l'existence du fichier
        Dim fichierRest As String = TxNomFichier.Text
        If Not IO.File.Exists(fichierRest) Then
            If MsgBox(String.Format(My.Resources.Strings.FichierIntrouvable, IO.Path.GetFileName(fichierRest)), MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then Exit Sub
        End If
        Restaurer(fichierRest)
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        With RestDlg
            .Multiselect = False
            .InitialDirectory = My.Settings.LireParametre("CheSauvegarde", Application.StartupPath & "\Sauvegarde")
            If .ShowDialog = DialogResult.OK Then
                TxNomFichier.Text = .FileName
            End If
        End With
    End Sub

    Private Sub FrRestauration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel3.Height
            .BringToFront()
            .Visible = False
        End With
        'TxNomFichier.Text = My.Settings.LireParametre("CheSauvegarde", Application.StartupPath & "\Sauvegarde")
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = Convert.ToString(status)
            Application.DoEvents()
        End If
        Me.pgBar.Value = percent
    End Sub

    Private Function ChargerFichierSauvegarde(ByVal fichier As String) As DataSet
        Dim fichierSauv As String
        Dim tempDir As String = ""
        Select Case IO.Path.GetExtension(Me.TxNomFichier.Text).ToLower
            Case ".zip"
                tempDir = String.Format("{0}AgrigestRestore{1:yyMMddHHmmss}", IO.Path.GetTempPath, Now)
                IO.Directory.CreateDirectory(tempDir)
                Dim fz As New ICSharpCode.SharpZipLib.Zip.FastZip
                fz.ExtractZip(Me.TxNomFichier.Text, tempDir, "")
                Dim nomFichSauv As String = IO.Path.GetFileNameWithoutExtension(Me.TxNomFichier.Text) & ".xml"
                If Not IO.File.Exists(tempDir & "\" & nomFichSauv) Then
                    Throw New ApplicationException(My.Resources.Strings.Restauration_SauvegardeEndommagee)
                Else
                    fichierSauv = tempDir & "\" & nomFichSauv
                End If
            Case ".xml"
                fichierSauv = Me.TxNomFichier.Text
        End Select

        Try
            Dim ds As New DataSet
            ds.EnforceConstraints = False
            ds.ReadXml(fichierSauv)
            Return ds
        Finally
            Try
                If IO.Directory.Exists(tempDir) Then IO.Directory.Delete(tempDir)
            Catch
            End Try
        End Try
    End Function

    Private Sub Restaurer(ByVal fichierRest As String)
        Dim prevExpl As Exploitation = My.Settings.Exploitation
        Cursor.Current = Cursors.WaitCursor
        PanProgress.Visible = True
        Application.DoEvents()
        Try
            ReportProgress(0, My.Resources.Strings.Initialisation & "...")
            Dim dsRestauration As DataSet
            ReportProgress(5, My.Resources.Strings.Restore_LectureDeLaSauvegarde)
            Try
                dsRestauration = ChargerFichierSauvegarde(fichierRest)
            Catch ex As Exception
                Throw New ApplicationException(My.Resources.Strings.Restore_ProblemeDeLectureDuFichier & ex.Message, ex)
            End Try

            Dim sDossier As String = dsRestauration.Tables("Dossiers").Rows(0)("DDossier").ToString
            Dim CodeExpl As String = dsRestauration.Tables("Exploitations").Rows(0)("EExpl").ToString

            ReportProgress(6, "Initialisation du dossier...")
            'TROUVER LA BONNE EXPLOITATION
            Dim expl As Exploitation
            If My.Settings.Exploitation IsNot Nothing AndAlso My.Settings.Exploitation.CodeExpl = CodeExpl Then
                expl = My.Settings.Exploitation
            Else
                expl = Exploitation.Trouver(CodeExpl)
                If expl Is Nothing Then
                    'NOUVELLE EXPLOITATION
                    expl = New Exploitation
                    With expl
                        .CodeExpl = CodeExpl
                        .CreerBase()
                        .CheminBasePlanType = My.Settings.CheminBaseConfig
                    End With
                End If
                'ON SE POSITIONNE SUR LA BONNE BASE
                expl.Choisir()
                'ON A GAGNE LE DROIT DE REINITIALISER LES DATAADAPTERS
                ResetAdapters()
            End If

            If CInt(Me.DossiersWorkTableAdapter.ExistsDossier(CodeExpl, sDossier)) = 0 Then
                'Le dossier n'existe pas dans la base : on le crée
                WriteData(dsRestauration, False, CodeExpl, sDossier)
            ElseIf MsgBox(My.Resources.Strings.Restore_AskEcraserDossier, MsgBoxStyle.YesNo, My.Resources.Strings.Restauration) = MsgBoxResult.Yes Then
                'Le dossier existe déjà : on demande confirmation de son écrasement
                WriteData(dsRestauration, True, CodeExpl, sDossier)
            Else
                'Sinon on annule la resto
                Throw New ApplicationException(My.Resources.Strings.Restore_Cancel)
            End If

            'Récupérer le nom de l'exploitation tel qu'importé
            expl.Nom = dsRestauration.Tables("Exploitations").Rows(0)("ENom1").ToString
            'Enlever l'exploitation XML qui eventuellement existait déjà
            Exploitation.Enlever(CodeExpl)
            'Enregister la liste XML des exploitations
            Exploitation.Ajouter(expl)
            ReportProgress(100)
            MsgBox(My.Resources.Strings.Restore_Succes, MsgBoxStyle.Information, My.Resources.Strings.Restauration)
            Me.DialogResult = DialogResult.OK
        Catch ex As ApplicationException
            LogException(ex)
            If MsgBox(My.Resources.Strings.Restore_RecapProblemes & vbCrLf & _
            ex.Message & vbCrLf & My.Resources.Strings.EnregistrerRapport, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                With ErrorDlg
                    .DefaultExt = "txt"
                    .Filter = "Fichiers texte (*.txt)|*.txt"
                    .FileName = "Rapport d'erreur restauration.txt"
                    If .ShowDialog = DialogResult.OK Then
                        My.Computer.FileSystem.WriteAllText(.FileName, ex.Message, False)
                        Process.Start(.FileName)
                    End If
                End With
            End If
            'on se remet sur l'exploitation précédente pour rétablir les chemins aux bases
            If prevExpl IsNot Nothing Then prevExpl.Choisir()
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            'Il y a eu une erreur, on se remet sur l'exploitation précédente
            If prevExpl IsNot Nothing Then prevExpl.Choisir()
            Throw New Exception(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
            Me.Close()
        End Try
    End Sub

    Private Sub ResetAdapters()
        'Dossiers
        Me.DossiersWorkTableAdapter = New dbDonneesDataSetTableAdapters.DossiersTableAdapter
        Me.ExploitationsTableAdapter = New dbSauvRestTableAdapters.ExploitationsTableAdapter
        Me.DossiersTableAdapter = New dbSauvRestTableAdapters.DossiersTableAdapter
        'Plan Comptable
        Me.ActivitesTableAdapter = New dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New dbSauvRestTableAdapters.ComptesTableAdapter
        Me.PlanComptableTableAdapter = New dbSauvRestTableAdapters.PlanComptableTableAdapter
        'Pieces
        Me.PiecesTableAdapter = New dbSauvRestTableAdapters.PiecesTableAdapter
        Me.LignesTableAdapter = New dbSauvRestTableAdapters.LignesTableAdapter
        Me.MouvementsTableAdapter = New dbSauvRestTableAdapters.MouvementsTableAdapter
        'Immo/Inventaires/Emprunts
        Me.ImmobilisationsTableAdapter = New dbSauvRestTableAdapters.ImmobilisationsTableAdapter
        Me.InventaireGroupesTableAdapter = New dbSauvRestTableAdapters.InventaireGroupesTableAdapter
        Me.InventaireLignesTableAdapter = New dbSauvRestTableAdapters.InventaireLignesTableAdapter
        Me.EmpruntGroupesTableAdapter = New dbSauvRestTableAdapters.EmpruntGroupesTableAdapter
        Me.EmpruntLignesTableAdapter = New dbSauvRestTableAdapters.EmpruntLignesTableAdapter
        'Modèles
        Me.ModLignesTableAdapter = New dbSauvRestTableAdapters.ModLignesTableAdapter
        Me.ModMouvementsTableAdapter = New dbSauvRestTableAdapters.ModMouvementsTableAdapter
    End Sub

    Private Sub SetAdaptersTransaction(ByVal t As OleDb.OleDbTransaction)
        'Dossiers
        Me.ExploitationsTableAdapter.SetTransaction(t)
        Me.DossiersTableAdapter.SetTransaction(t)
        'Plan Comptable
        Me.ActivitesTableAdapter.SetTransaction(t)
        Me.ComptesTableAdapter.SetTransaction(t)
        Me.PlanComptableTableAdapter.SetTransaction(t)
        'Pieces
        Me.PiecesTableAdapter.SetTransaction(t)
        Me.LignesTableAdapter.SetTransaction(t)
        Me.MouvementsTableAdapter.SetTransaction(t)
        'Immo/Inventaires/Emprunts
        Me.ImmobilisationsTableAdapter.SetTransaction(t)
        Me.InventaireGroupesTableAdapter.SetTransaction(t)
        Me.InventaireLignesTableAdapter.SetTransaction(t)
        Me.EmpruntGroupesTableAdapter.SetTransaction(t)
        Me.EmpruntLignesTableAdapter.SetTransaction(t)
        'Modèles
        Me.ModLignesTableAdapter.SetTransaction(t)
        Me.ModMouvementsTableAdapter.SetTransaction(t)
    End Sub

    Private Sub WriteData(ByVal dsRestauration As DataSet, ByVal bDelete As Boolean, ByVal sExploitation As String, ByVal sDossier As String)
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDb.OleDbTransaction
            Try
                conn.Open()
                t = conn.BeginTransaction
                SetAdaptersTransaction(t)

                If bDelete Then
                    ReportProgress(7, "Suppression des données existantes...")
                    DeleteExistingData(t, sExploitation, sDossier)
                End If

                ReportProgress(10, My.Resources.Strings.ChargementDesDonnees)
                'DOSSIER
                If ExecuteScalarInt(String.Format("SELECT count(*) FROM Exploitations WHERE EExpl='{0}'", sExploitation), t) = 0 Then
                    ForceDataAdapter.ForceInsert(Me.ExploitationsTableAdapter.GetDataAdapter, dsRestauration)
                Else
                    ForceDataAdapter.ForceUpdate(Me.ExploitationsTableAdapter.GetDataAdapter, dsRestauration)
                End If
                ForceDataAdapter.ForceInsert(Me.DossiersTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(20)
                'PLAN COMPTABLE
                ForceDataAdapter.ForceInsert(Me.ActivitesTableAdapter.GetDataAdapter, dsRestauration)
                ForceDataAdapter.ForceInsert(Me.ComptesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(25)
                ForceDataAdapter.ForceInsert(Me.PlanComptableTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(30)
                'PIECES
                ForceDataAdapter.ForceInsert(Me.PiecesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(40)
                ForceDataAdapter.ForceInsert(Me.LignesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(50)
                ForceDataAdapter.ForceInsert(Me.MouvementsTableAdapter.GetDataAdapter, dsRestauration)
                Me.MouvementsTableAdapter.FixLettrage()
                ReportProgress(70)
                'IMMO/INV/EMPRUNTS
                ForceDataAdapter.ForceInsert(Me.ImmobilisationsTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(75)
                ForceDataAdapter.ForceInsert(Me.InventaireGroupesTableAdapter.GetDataAdapter, dsRestauration)
                ForceDataAdapter.ForceInsert(Me.InventaireLignesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(80)
                ForceDataAdapter.ForceInsert(Me.EmpruntGroupesTableAdapter.GetDataAdapter, dsRestauration)
                ForceDataAdapter.ForceInsert(Me.EmpruntLignesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(85)
                'MODELES
                ForceDataAdapter.ForceInsert(Me.ModLignesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(90)
                ForceDataAdapter.ForceInsert(Me.ModMouvementsTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(100)

                t.Commit()
            Catch ex As Exception
                If t IsNot Nothing Then t.Rollback()
                Throw New ApplicationException(ex.Message, ex)
            End Try
        End Using
    End Sub

    Private Sub DeleteExistingData(ByRef t As OleDb.OleDbTransaction, ByVal sExploitation As String, ByVal sDossier As String)
        SupprimerLignes("InventaireLignes", "INVLDossier", sDossier, t)
        SupprimerLignes("InventaireGroupes", "INVGDossier", sDossier, t)
        SupprimerLignes("Immobilisations", "IDossier", sDossier, t)
        SupprimerLignes("Immobilisations", "IDossier", sDossier, t)
        SupprimerLignes("Mouvements", "MDossier", sDossier, t)
        SupprimerLignes("Lignes", "LDossier", sDossier, t)
        SupprimerLignes("Pieces", "PDossier", sDossier, t)
        SupprimerLignes("PlanComptable", "PlDossier", sDossier, t)
        SupprimerLignes("Activites", "ADossier", sDossier, t)
        SupprimerLignes("Comptes", "CDossier", sDossier, t)
        SupprimerLignes("Dossiers", "DDossier", sDossier, t)
        SupprimerLignes("EmpruntLignes", "EMPLExpl", sExploitation, t)
        SupprimerLignes("EmpruntGroupes", "EMPGExpl", sExploitation, t)
        SupprimerLignes("ModMouvements", "ModMExpl", sExploitation, t)
        SupprimerLignes("ModLignes", "ModLExpl", sExploitation, t)
        'S'il n'y a pas d'autre dossier de cette exploitation, on supprime aussi l'exploitation
        If ExecuteScalarInt(String.Format("SELECT count(*) FROM Dossiers WHERE DDossier <> '{0}' AND DExpl='{1}'", sDossier, sExploitation), t) = 0 Then
            SupprimerLignes("Exploitations", "EExpl", sExploitation, t)
        End If
    End Sub
#End Region

End Class