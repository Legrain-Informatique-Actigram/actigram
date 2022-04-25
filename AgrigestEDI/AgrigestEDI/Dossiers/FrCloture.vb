Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class FrCloture

    Private Const nOrdreD As Byte = 1
    Private Const nOrdreC As Byte = 3

#Region "Page"
    Private Sub FrCloture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel2.Height
            .BringToFront()
            .Visible = False
        End With

        Dim dossier As DossierPrincipal = My.Dossier.Principal

        'Pas d'action possible si l'exercice est clôturé définitivement 
        '(= date arrêtée renseignée pour le dossier en cours)
        If (dossier.DateClotureCompta > Date.MinValue) Then
            Me.DesactiverForm()

            MsgBox("Pas d'action disponible. Dossier en cours clôturé définitivement.", MsgBoxStyle.Information, "Exercice clôturé")

            Exit Sub
        End If

        Me.PlanComptableExistTableAdapter.FillByDossier(Me.ds.PlanComptable, My.User.Name)
        Me.DossiersExistTableAdapter.FillByDossier(Me.ds.Dossiers, My.User.Name)

        'Initialisation de la form
        Me.InitialiserForm()
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            'Validation des dates du nouvel exercice saisies
            If Not (Me.DatesNouvelExerciceOK()) Then
                Exit Sub
            End If

            If Me.rbtDefinitive.Checked Or Me.rbtProvisoire.Checked Then
                CloturerDossier(Me.rbtDefinitive.Checked)

                'Sauvegarde des comptes de reports détaillés saisis
                My.Settings.FiltreCptesAReporterNonLettres = Me.txCptNonLettres.Text
                My.Settings.Save()

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Veuillez sélectionner un type de clôture.", MsgBoxStyle.Information, "Sélection type clôture")

                Exit Sub
            End If
        Catch ex As ApplicationException
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clôture")
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Cases à cocher"
    Private Sub chkReportNonLettre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReportNonLettre.CheckedChanged
        Me.lbCptNonLettres.Enabled = chkReportNonLettre.Checked
        Me.txCptNonLettres.Enabled = chkReportNonLettre.Checked
    End Sub
#End Region

#Region "Fonctionnel"
    Private Sub CloturerDossier(ByVal bClotureDefinitive As Boolean)
        PanProgress.Visible = True

        'Chargement des infos du dossier en cours
        Dim dossierEnCours As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)

        ReportProgress(0, My.Resources.Strings.Initialisation)

        Using dossiersTA As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
            Dim oleDbTrans As OleDb.OleDbTransaction

            Using oleDbConn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                Try
                    oleDbConn.Open()

                    oleDbTrans = oleDbConn.BeginTransaction

                    ReportProgress(15, My.Resources.Strings.Cloture_TrouverExercice)

                    Me.DossiersExistTableAdapter.SetTransaction(oleDbTrans)

                    Dim codeNouveauDossier As String = Me.CodeDossierSuivant(My.User.Name)

                    'Si pas de dossier suivant : création du nouveau dossier 
                    '+ création du plan comptable sur le nouveau dossier
                    '+ création de la pièce d'AN
                    If (codeNouveauDossier = String.Empty) Then
                        Dim bAjouter As Boolean = False
                        Dim i As Integer = 65

                        ReportProgress(25, My.Resources.Strings.Cloture_CreerCodeExercice)

                        'Vérification qu'un code dossier est encore disponible
                        codeNouveauDossier = dossierEnCours.CodeExpl + Microsoft.VisualBasic.Right(dtpDebut.Value.Year.ToString, 2)

                        While Not bAjouter
                            If CInt(dossiersTA.ExistsDossier(dossierEnCours.CodeExpl, codeNouveauDossier)) = 0 Then
                                bAjouter = True
                            Else
                                If i = 90 Then
                                    Throw New ApplicationException(My.Resources.Strings.Cloture_PlusDeCodeDispo)
                                Else
                                    codeNouveauDossier = dossierEnCours.CodeExpl + Chr(i) + Microsoft.VisualBasic.Right(Me.dtpFin.Value.Year.ToString, 1)
                                End If
                            End If
                        End While

                        ReportProgress(30, My.Resources.Strings.Cloture_CreerNouvelExercice)

                        'Création du nouveau dossier + du plan comptable du nouveau dossier
                        codeNouveauDossier = CreateNewExo(codeNouveauDossier, oleDbTrans)

                        ReportProgress(45, My.Resources.Strings.Cloture_DateNouveauDossier)

                        'Mise à jour des dates de début et de fin d'exercice du nouveau dossier
                        Me.DossiersExistTableAdapter.UpdateDateDossier(CDate(dtpDebut.Value.ToShortDateString), CDate(dtpFin.Value.ToShortDateString), Nothing, codeNouveauDossier, dossierEnCours.CodeExpl)

                        ReportProgress(50, My.Resources.Strings.Cloture_DateAncienDossier)

                        'Création de la pièce d'AN
                        CreerPieceAN(oleDbConn, oleDbTrans, codeNouveauDossier, chkReportNonLettre.Checked, txCptNonLettres.Text)

                        'Si c'est une clôture définitive 
                        If bClotureDefinitive Then
                            'Mise à jour de la date d'arrêté du dossier en cours
                            Me.DossiersExistTableAdapter.UpdateDateDossier(dossierEnCours.DateDebutEx, dossierEnCours.DateFinEx, dossierEnCours.DateFinEx, dossierEnCours.Identity.Name, dossierEnCours.CodeExpl)
                            dossierEnCours.DateClotureCompta = dossierEnCours.DateFinEx
                        End If
                    Else
                        'Modification de la pièce d'AN
                        ModifierPieceAN(oleDbConn, oleDbTrans, codeNouveauDossier, chkReportNonLettre.Checked, txCptNonLettres.Text)

                        'Si c'est une clôture définitive 
                        If bClotureDefinitive Then
                            'Mise à jour de la date d'arrêté du dossier en cours
                            Me.DossiersExistTableAdapter.UpdateDateDossier(CDate(dossierEnCours.DateDebutEx.ToShortDateString), CDate(dossierEnCours.DateFinEx.ToShortDateString), dossierEnCours.DateFinEx, dossierEnCours.Identity.Name, dossierEnCours.CodeExpl)
                            dossierEnCours.DateClotureCompta = CDate(dossierEnCours.DateFinEx.ToShortDateString)
                        End If
                    End If

                    oleDbTrans.Commit()
                Catch ex As Exception
                    oleDbTrans.Rollback()

                    Throw New ApplicationException(ex.Message, ex)
                End Try
            End Using

            If bClotureDefinitive Then
                ReportProgress(100, My.Resources.Strings.Cloture_ExerciceCloture)
                MsgBox(My.Resources.Strings.Cloture_ExerciceCloture, MsgBoxStyle.Information, My.Resources.Strings.Cloture)
            Else
                ReportProgress(100, My.Resources.Strings.Cloture_ClotureProvisoireOK)
                MsgBox(My.Resources.Strings.Cloture_ClotureProvisoireOK, MsgBoxStyle.Information, My.Resources.Strings.Cloture)
            End If

            PanProgress.Visible = False
        End Using
    End Sub

    Private Sub CreerPieceAN(ByVal oleDbConn As OleDbConnection, ByVal oleDbTrans As OleDb.OleDbTransaction, _
    ByVal codeNouveauDossier As String, ByVal reporterNonLettre As Boolean, ByVal filtreCptsNonLettres As String)
        Dim genererRANEcrPointees As Boolean = False
        Dim dsReport As New dbSauvRest

        dsReport.EnforceConstraints = False

        ReportProgress(55, My.Resources.Strings.ChargementDesDonnees)

        'Charge les données concernant le dossier en cours
        With dsReport
            Me.ActivitesTableAdapterReport.FillByDossier(.Activites, My.User.Name)
            Me.ComptesTableAdapterReport.FillByDossier(.Comptes, My.User.Name)
            Me.PlanComptableTableAdapterReport.FillByDossier(.PlanComptable, My.User.Name)
            Me.MouvementsTableAdapterReport.FillByDossier(.Mouvements, My.User.Name)
            Me.LignesTableAdapterReport.FillByDossier(.Lignes, My.User.Name)
        End With

        'Calcul des reports du dossier en cours
        ReportProgress(70, My.Resources.Strings.Cloture_CalculDesReports)
        CalculerReports(dsReport, reporterNonLettre, filtreCptsNonLettres)

        'Calcul du résultat du dossier en cours
        Dim resultat As Decimal = Me.CalculerResultat(dsReport, reporterNonLettre, filtreCptsNonLettres)

        ReportProgress(0, My.Resources.Strings.Cloture_EnregistrerReport)

        'Affectation des TableAdapter à la transaction
        Me.PiecesTableAdapterReport.SetTransaction(oleDbTrans)
        Me.MouvementsTableAdapterReport.SetTransaction(oleDbTrans)
        Me.LignesTableAdapterReport.SetTransaction(oleDbTrans)

        Dim journalAN As String = My.Dossier.Principal.JournalAN

        'Suppression des enregistrements du journal des A NOUVEAUX du nouveau dossier
        Dim xPieceDelete As dbSauvRest.PiecesDataTable = New dbSauvRest.PiecesDataTable
        Me.PiecesTableAdapterReport.FillByDossierJournal(xPieceDelete, codeNouveauDossier, journalAN)

        For Each xPiece As dbSauvRest.PiecesRow In xPieceDelete
            Me.MouvementsTableAdapterReport.DeleteANouveau(xPiece.PDossier, xPiece.PPiece, xPiece.PDate)
            Me.LignesTableAdapterReport.DeleteANouveau(xPiece.PDossier, xPiece.PPiece, xPiece.PDate)
            Me.PiecesTableAdapterReport.DeleteANouveau(xPiece.PDossier, journalAN)
        Next

        'Trouver le premier n° de pièce dispo le premier jour de l'exercice du dossier en cours
        Dim nNumPiece As Integer = 1
        Dim nLigne As Integer = 0
        While Me.PiecesTableAdapterReport.PieceExists(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString)).GetValueOrDefault > 0
            nNumPiece += 1
        End While

        'Création de la pièce d'A NOUVEAU dans le nouveau dossier
        Me.PiecesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), False, Nothing, _
        "A Nouveau", journalAN, Nothing, True)

        'Création de la ligne de résultat
        Dim drCptResult As dbSauvRest.PlanComptableRow = CType(CType(cboCompte.SelectedItem, DataRowView).Row, _
        dbSauvRest.PlanComptableRow)

        VerifPlanComptable(codeNouveauDossier, drCptResult, oleDbTrans)

        Dim sCptResultat As String = drCptResult.PlCpt

        Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, Nothing, _
        "Résultat d'exercice N-1", "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), _
        New Nullable(Of Date))

        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
        CByte(IIf(resultat >= 0, nOrdreD, nOrdreC)), sCptResultat, "0000", CDec(IIf(resultat > 0, Math.Abs(resultat), 0)), _
        CDec(IIf(resultat > 0, 0, Math.Abs(resultat))), CStr(IIf(resultat < 0, "C", "D")), Nothing, Nothing, Nothing, _
        Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
        CByte(IIf(resultat >= 0, nOrdreC, nOrdreD)), "48800000", "0000", CDec(IIf(resultat > 0, 0, Math.Abs(resultat))), _
        CDec(IIf(resultat > 0, Math.Abs(resultat), 0)), CStr(IIf(resultat < 0, "D", "C")), Nothing, Nothing, Nothing, _
        Nothing, Nothing, sCptResultat, "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

        nLigne += 1

        'Suppression des MIdANouveauSuiv de la table Mouvements du dossier en cours 
        'et des MIdANouveau du nouveau dossier
        Me.MouvementsTableAdapterReport.UpdateMIdANouveauSuivParDossier(Nothing, My.User.Name)
        Me.MouvementsTableAdapterReport.UpdateMIdANouveauParDossier(Nothing, codeNouveauDossier)

        'Création des lignes de report
        Dim i As Integer = 0

        For Each drPLC As dbSauvRest.PlanComptableRow In dsReport.PlanComptable.Rows
            ReportProgress(i, My.Resources.Strings.Cloture_EnregistrerReport & " " & drPLC.PlCpt & " " & i, dsReport.PlanComptable.Rows.Count + 1) : i += 1

            'S'assurer de la présence du compte dans le PLC du nouveau dossier
            VerifPlanComptable(codeNouveauDossier, drPLC, oleDbTrans)

            If ReplaceDbNull(drPLC("PlRepG_D"), 0D) <> 0 OrElse ReplaceDbNull(drPLC("PlRepG_C"), 0D) <> 0 Then
                Debug.Print("Report pour le compte {0}/{1}", drPLC.PlCpt, drPLC.PlActi)

                Dim libligne As String = Convert.ToString(drPLC("PlLib"))

                If libligne.Length = 0 Then
                    libligne = Convert.ToString(drPLC.ComptesRowParent("CLib"))
                End If

                Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, "", libligne, _
                "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), New Nullable(Of Date))

                Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                CByte(IIf(drPLC.PlRepG_D = 0, nOrdreC, nOrdreD)), drPLC.PlCpt, CStr(IIf(drPLC.PlActi = Nothing, "0000", _
                drPLC.PlActi)), drPLC.PlRepG_D, drPLC.PlRepG_C, CStr(IIf(drPLC.PlRepG_D > 0, "D", "C")), drPLC.PlRepG_U1, _
                drPLC.PlRepG_U2, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

                Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                CByte(IIf(drPLC.PlRepG_D = 0, nOrdreD, nOrdreC)), "48800000", "0000", drPLC.PlRepG_C, drPLC.PlRepG_D, _
                CStr(IIf(drPLC.PlRepG_D > 0, "C", "D")), 0, 0, Nothing, Nothing, Nothing, drPLC.PlCpt, _
                CStr(IIf(drPLC.PlActi = Nothing, "0000", drPLC.PlActi)), Nothing, Nothing, Nothing, Nothing, Nothing)

                nLigne += 1
            End If

            'Eventuellement report des écritures non lettrées
            If reporterNonLettre AndAlso VerifFiltre(drPLC.PlCpt, filtreCptsNonLettres) Then
                Dim rwsMvtNonLettres() As dbSauvRest.MouvementsRow = TrouverMvtNonLettres(dsReport, drPLC.PlCpt, drPLC.PlActi)
                Dim nouveauIdANouveauSuiv As Integer = 0

                For Each rwMvt As dbSauvRest.MouvementsRow In rwsMvtNonLettres
                    If (rwMvt.MMtDeb = 0 AndAlso rwMvt.MMtCre = 0) Then Continue For

                    'Calcul d'un nouvel MIdANouveauSuiv pour le dossier en cours
                    If (Me.MouvementsTableAdapterReport.MaxIdANouveauSuivParDossier(My.User.Name).HasValue) Then
                        nouveauIdANouveauSuiv = CInt(Me.MouvementsTableAdapterReport.MaxIdANouveauSuivParDossier(My.User.Name)) + 1
                    Else
                        nouveauIdANouveauSuiv = 1
                    End If

                    'Mise à jour du MIdANouveauSuiv pour le mouvement dans le dossier en cours
                    Me.MouvementsTableAdapterReport.UpdateMIdANouveauSuivParMouvement(nouveauIdANouveauSuiv, rwMvt.MDossier, _
                    rwMvt.MPiece, rwMvt.MDate, rwMvt.MLig, rwMvt.MOrdre)

                    Dim rwLigne As dbSauvRest.LignesRow = rwMvt.LignesRowParent
                    Dim libligne As String = Mid(ReplaceDbNull(rwLigne("LLib"), "") & " " & ReplaceDbNull(rwLigne("LDate"), "") & " " & ReplaceDbNull(rwLigne("LPiece"), ""), 1, 55)
                    Dim cpt As String = drPLC.PlCpt
                    Dim acti As String = drPLC.PlActi
                    Dim MtD As Decimal = rwMvt.MMtDeb
                    Dim MtC As Decimal = rwMvt.MMtCre

                    Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, "", libligne, _
                    "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), New Nullable(Of Date))

                    Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                    CByte(IIf(MtD = 0, nOrdreC, nOrdreD)), cpt, acti, MtD, MtC, CStr(IIf(MtD <> 0, "D", "C")), 0, 0, _
                    Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, nouveauIdANouveauSuiv, Nothing)

                    Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                    CByte(IIf(MtD = 0, nOrdreD, nOrdreC)), "48800000", "0000", MtC, MtD, CStr(IIf(MtD <> 0, "C", "D")), _
                    0, 0, Nothing, Nothing, Nothing, cpt, acti, Nothing, Nothing, Nothing, nouveauIdANouveauSuiv, Nothing)

                    nLigne += 1
                Next
            End If
        Next

        'Génération des écritures de contrepartie pour les écritures pointées
        If reporterNonLettre AndAlso VerifFiltre("512", filtreCptsNonLettres) Then
            Me.GenererRANEcrituresPointees(codeNouveauDossier, nNumPiece, nLigne, journalAN)
        End If

        'Suppression des 48800000 en trop dans le nouveau dossier(48800000 associés à des écritures lettrées non prise 
        'en compte dans la pièce d'AN. Par contre les 48800000 eux apparaissent dans la pièce d'AN)
        Me.Supprimer48800000EnTrop(codeNouveauDossier, oleDbTrans)

        'Mise à jour du champ DComptesReportsDetaillesCloture de la table Dossiers pour le nouveau dossier
        Me.DossiersTableAdapter.UpdateComptesReportsDetaillesCloture(filtreCptsNonLettres, codeNouveauDossier)
    End Sub

    Private Sub ModifierPieceAN(ByVal oleDbConn As OleDbConnection, ByVal oleDbTrans As OleDb.OleDbTransaction, _
    ByVal codeNouveauDossier As String, ByVal reporterNonLettre As Boolean, ByVal filtreCptsNonLettres As String)

        Dim genererRANEcrPointees As Boolean = False
        Dim dsReport As New dbSauvRest

        dsReport.EnforceConstraints = False

        ReportProgress(55, My.Resources.Strings.ChargementDesDonnees)

        'Charge les données concernant le dossier en cours
        With dsReport
            Me.ActivitesTableAdapterReport.FillByDossier(.Activites, My.User.Name)
            Me.ComptesTableAdapterReport.FillByDossier(.Comptes, My.User.Name)
            Me.PlanComptableTableAdapterReport.FillByDossier(.PlanComptable, My.User.Name)
            Me.MouvementsTableAdapterReport.FillByDossier(.Mouvements, My.User.Name)
            Me.LignesTableAdapterReport.FillByDossier(.Lignes, My.User.Name)
        End With

        'Calcul des reports du dossier en cours
        ReportProgress(70, My.Resources.Strings.Cloture_CalculDesReports)
        CalculerReports(dsReport, reporterNonLettre, filtreCptsNonLettres)

        'Calcul du résultat du dossier en cours
        Dim resultat As Decimal = Me.CalculerResultat(dsReport, reporterNonLettre, filtreCptsNonLettres)

        ReportProgress(0, My.Resources.Strings.Cloture_EnregistrerReport)

        'Affectation des TableAdapter à la transaction
        Me.PiecesTableAdapterReport.SetTransaction(oleDbTrans)
        Me.MouvementsTableAdapterReport.SetTransaction(oleDbTrans)
        Me.LignesTableAdapterReport.SetTransaction(oleDbTrans)

        'vérifie si la pièce d'AN de clôture existe dans le nouveau dossier sinon la créer
        Dim journalAN As String = My.Dossier.Principal.JournalAN
        Dim nNumPiece As Integer = 1

        If (Me.PiecesTableAdapterReport.PieceIssueDeClotureExiste(codeNouveauDossier, True, journalAN).GetValueOrDefault = 0) Then
            'Trouver le premier n° de pièce dispo le premier jour de l'exercice dans le nouveau dossier
            While Me.PiecesTableAdapterReport.PieceExists(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString)).GetValueOrDefault > 0
                nNumPiece += 1
            End While

            'Création de la pièce d'A NOUVEAU dans le nouveau dossier
            Me.PiecesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), False, Nothing, _
            "A Nouveau", journalAN, Nothing, True)
        End If

        'Suppression des mouvements des comptes sans reports détaillés dans le nouveau dossier
        Me.SupprimerMouvementsCptsSansReportsDetailles(codeNouveauDossier, journalAN)

        'Suppression des lignes des comptes sans reports détaillés dans le nouveau dossier
        Me.SupprimerLignesCptsSansReportsDetailles(codeNouveauDossier, journalAN)

        Dim nLigne As Integer = 0

        'Récupération du numéro de ligne maximum dans la pièce d'AN du nouveau dossier
        nLigne = Me.MaxLigne(codeNouveauDossier, journalAN) + 1

        'Création de la ligne de résultat
        Dim drCptResult As dbSauvRest.PlanComptableRow = CType(CType(cboCompte.SelectedItem, DataRowView).Row, _
        dbSauvRest.PlanComptableRow)

        VerifPlanComptable(codeNouveauDossier, drCptResult, oleDbTrans)

        Dim sCptResultat As String = drCptResult.PlCpt

        Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, Nothing, _
        "Résultat d'exercice N-1", "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), _
        New Nullable(Of Date))

        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
        CByte(IIf(resultat >= 0, nOrdreD, nOrdreC)), sCptResultat, "0000", CDec(IIf(resultat > 0, Math.Abs(resultat), 0)), _
        CDec(IIf(resultat > 0, 0, Math.Abs(resultat))), CStr(IIf(resultat < 0, "C", "D")), Nothing, Nothing, Nothing, _
        Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
        CByte(IIf(resultat >= 0, nOrdreC, nOrdreD)), "48800000", "0000", CDec(IIf(resultat > 0, 0, Math.Abs(resultat))), _
        CDec(IIf(resultat > 0, Math.Abs(resultat), 0)), CStr(IIf(resultat < 0, "D", "C")), Nothing, Nothing, Nothing, _
        Nothing, Nothing, sCptResultat, "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

        nLigne += 1

        'Création des lignes de report
        Dim i As Integer = 0

        For Each drPLC As dbSauvRest.PlanComptableRow In dsReport.PlanComptable.Rows
            ReportProgress(i, My.Resources.Strings.Cloture_EnregistrerReport & " " & drPLC.PlCpt & " " & i, dsReport.PlanComptable.Rows.Count + 1) : i += 1

            'S'assurer de la présence du compte dans le PLC du nouveau dossier
            VerifPlanComptable(codeNouveauDossier, drPLC, oleDbTrans)

            Debug.Print("Report pour le compte {0}/{1}", drPLC.PlCpt, drPLC.PlActi)

            If ReplaceDbNull(drPLC("PlRepG_D"), 0D) <> 0 OrElse ReplaceDbNull(drPLC("PlRepG_C"), 0D) <> 0 Then
                Dim libligne As String = Convert.ToString(drPLC("PlLib"))

                If libligne.Length = 0 Then
                    libligne = Convert.ToString(drPLC.ComptesRowParent("CLib"))
                End If

                Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, "", libligne, _
                "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), New Nullable(Of Date))

                Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                CByte(IIf(drPLC.PlRepG_D = 0, nOrdreC, nOrdreD)), drPLC.PlCpt, CStr(IIf(drPLC.PlActi = Nothing, "0000", _
                drPLC.PlActi)), drPLC.PlRepG_D, drPLC.PlRepG_C, CStr(IIf(drPLC.PlRepG_D > 0, "D", "C")), drPLC.PlRepG_U1, _
                drPLC.PlRepG_U2, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

                Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                CByte(IIf(drPLC.PlRepG_D = 0, nOrdreD, nOrdreC)), "48800000", "0000", drPLC.PlRepG_C, drPLC.PlRepG_D, _
                CStr(IIf(drPLC.PlRepG_D > 0, "C", "D")), 0, 0, Nothing, Nothing, Nothing, drPLC.PlCpt, _
                CStr(IIf(drPLC.PlActi = Nothing, "0000", drPLC.PlActi)), Nothing, Nothing, Nothing, Nothing, Nothing)

                nLigne += 1
            End If

            'Eventuellement report des écritures non lettrées
            If reporterNonLettre AndAlso VerifFiltre(drPLC.PlCpt, filtreCptsNonLettres) Then
                Dim rwsMvtNonLettres() As dbSauvRest.MouvementsRow = TrouverMvtNonLettres(dsReport, drPLC.PlCpt, drPLC.PlActi)
                Dim nouveauIdANouveauSuiv As Integer = 0

                For Each rwMvt As dbSauvRest.MouvementsRow In rwsMvtNonLettres

                    If (rwMvt.MMtDeb = 0 AndAlso rwMvt.MMtCre = 0) Then Continue For
                    Dim rwLigne As dbSauvRest.LignesRow = rwMvt.LignesRowParent
                    Dim libligne As String = Mid(ReplaceDbNull(rwLigne("LLib"), "") & " " & ReplaceDbNull(rwLigne("LDate"), "") & " " & ReplaceDbNull(rwLigne("LPiece"), ""), 1, 55)
                    Dim cpt As String = drPLC.PlCpt
                    Dim acti As String = drPLC.PlActi
                    Dim MtD As Decimal = rwMvt.MMtDeb
                    Dim MtC As Decimal = rwMvt.MMtCre

                    'Si MIdANouveauSuiv dans le dossier en cours est vide, 
                    'on calcule un nouveau MIdANouveauSuiv pour l'affecter au mouvement
                    If (rwMvt.IsMIdANouveauSuivNull) Then
                        If (Me.MouvementsTableAdapterReport.MaxIdANouveauSuivParDossier(My.User.Name).HasValue) Then
                            nouveauIdANouveauSuiv = CInt(Me.MouvementsTableAdapterReport.MaxIdANouveauSuivParDossier(My.User.Name)) + 1
                        Else
                            nouveauIdANouveauSuiv = 1
                        End If

                        'Mise à jour du MIdANouveauSuiv pour le mouvement dans le dossier en cours
                        Me.MouvementsTableAdapterReport.UpdateMIdANouveauSuivParMouvement(nouveauIdANouveauSuiv, rwMvt.MDossier, _
                        rwMvt.MPiece, rwMvt.MDate, rwMvt.MLig, rwMvt.MOrdre)

                        'on crée la ligne et le mouvement dans le nouveau dossier
                        Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, "", _
                        libligne, "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), _
                        New Nullable(Of Date))

                        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                        CByte(IIf(MtD = 0, nOrdreC, nOrdreD)), cpt, acti, MtD, MtC, CStr(IIf(MtD <> 0, "D", "C")), _
                        0, 0, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, nouveauIdANouveauSuiv, Nothing)

                        Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                        CByte(IIf(MtD = 0, nOrdreD, nOrdreC)), "48800000", "0000", MtC, MtD, CStr(IIf(MtD <> 0, "C", "D")), _
                        0, 0, Nothing, Nothing, Nothing, cpt, acti, Nothing, Nothing, Nothing, nouveauIdANouveauSuiv, Nothing)

                        nLigne += 1
                    Else
                        Dim mvtsNouveauDossierDataTable As dbSauvRest.MouvementsDataTable = Me.MouvementsTableAdapterReport.GetDataByMIdANouveauEtMDossier(rwMvt.MIdANouveauSuiv, codeNouveauDossier)

                        'Si le MIdANouveauSuiv existe dans la pièce d'AN du nouveau dossier
                        If (mvtsNouveauDossierDataTable.Rows.Count > 0) Then
                            For Each mvtsNouveauDossierRow As dbSauvRest.MouvementsRow In mvtsNouveauDossierDataTable.Rows
                                'Si le montant ou le numéro de compte de la pièce d'AN du nouveau dossier et le montant 
                                'ou le numéro de compte du mouvement 
                                'du dossier en cours sont différents, 
                                'on met à jour la pièce d'AN du nouveau dossier avec  
                                'le mouvement du dossier en cours
                                'Suppression du pointage et du lettrage
                                If (Me.MontantsDifferents(rwMvt, mvtsNouveauDossierRow) Or Me.ComptesDifferents(rwMvt, mvtsNouveauDossierRow) Or Not (rwMvt.IsMLettrageNull)) Then
                                    'Si le mouvement ne concerne pas un 48800000
                                    If (mvtsNouveauDossierRow.MCpt <> "48800000") Then
                                        Me.MouvementsTableAdapterReport.UpdateReduit( _
                                        rwMvt.MCpt, rwMvt.MActi, rwMvt.MMtDeb, rwMvt.MMtCre, rwMvt.MD_C, _
                                        mvtsNouveauDossierRow.MCptCtr, mvtsNouveauDossierRow.MActCtr, _
                                        Nothing, Nothing, Nothing, _
                                        mvtsNouveauDossierRow.MDossier, mvtsNouveauDossierRow.MPiece, mvtsNouveauDossierRow.MDate, _
                                        mvtsNouveauDossierRow.MLig, mvtsNouveauDossierRow.MOrdre)

                                        'Suppression du lettrage associé si necessaire
                                        If Not (mvtsNouveauDossierRow.IsMLettrageNull) Then
                                            Me.MouvementsTableAdapterReport.MettreLettrageANull( _
                                            mvtsNouveauDossierRow.MDossier, mvtsNouveauDossierRow.MCpt, mvtsNouveauDossierRow.MLettrage)
                                        End If
                                    Else 'si le mouvement concerne un 48800000
                                        Me.MouvementsTableAdapterReport.UpdateReduit( _
                                        mvtsNouveauDossierRow.MCpt, mvtsNouveauDossierRow.MActi, _
                                        rwMvt.MMtCre, rwMvt.MMtDeb, CStr(IIf(rwMvt.MD_C = "D", "C", "D")), _
                                        rwMvt.MCpt, rwMvt.MActi, _
                                        Nothing, Nothing, Nothing, _
                                        mvtsNouveauDossierRow.MDossier, mvtsNouveauDossierRow.MPiece, mvtsNouveauDossierRow.MDate, _
                                        mvtsNouveauDossierRow.MLig, mvtsNouveauDossierRow.MOrdre)
                                    End If

                                    'Met à jour le libellé dans la ligne
                                    'Recherche de la ligne liée au mouvement dans le dossier en cours
                                    Dim ligDossierEnCoursDataTable As dbSauvRest.LignesDataTable = Me.LignesTableAdapterReport.GetDataByDossierPieceDateLig(rwMvt.MDossier, rwMvt.MPiece, rwMvt.MDate, rwMvt.MLig)

                                    For Each ligDossierEnCoursRow As dbSauvRest.LignesRow In ligDossierEnCoursDataTable.Select
                                        'Mise à jour de la ligne liée au mouvement dans le nouveau dossier
                                        Me.LignesTableAdapterReport.UpdateLib(libligne, _
                                        mvtsNouveauDossierRow.MDossier, mvtsNouveauDossierRow.MPiece, _
                                        mvtsNouveauDossierRow.MDate, mvtsNouveauDossierRow.MLig)
                                    Next
                                End If
                            Next
                        Else
                            'Si le MIdANouveauSuiv n'existe pas dans la pièce d'AN du nouveau dossier
                            'on crée la ligne et le mouvement dans le nouveau dossier
                            Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, "", _
                            libligne, "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), _
                            New Nullable(Of Date))

                            Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                            CByte(IIf(MtD = 0, nOrdreC, nOrdreD)), cpt, acti, MtD, MtC, CStr(IIf(MtD <> 0, "D", "C")), _
                            0, 0, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, rwMvt.MIdANouveauSuiv, Nothing)

                            Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                            CByte(IIf(MtD = 0, nOrdreD, nOrdreC)), "48800000", "0000", MtC, MtD, CStr(IIf(MtD <> 0, "C", "D")), _
                            0, 0, Nothing, Nothing, Nothing, cpt, acti, Nothing, Nothing, Nothing, rwMvt.MIdANouveauSuiv, Nothing)

                            nLigne += 1
                        End If
                    End If
                Next
            End If
        Next

        'Génération des écritures de contrepartie pour les écritures pointées
        ReportProgress(0, "Génération mouvements écritures pointées")

        If reporterNonLettre AndAlso VerifFiltre("512", filtreCptsNonLettres) Then
            Me.GenererRANEcrituresPointees(codeNouveauDossier, nNumPiece, nLigne, journalAN)
        End If

        'Supprime les lignes et les mouvements du nouveau dossier qui n'ont pas un MIdANouveau 
        'correspondant à un MIdANouveauSuiv dans le dossier en cours
        'Suppression des lignes et mouvements de la pièce d'AN du nouveau dossier
        'qui ont été lettrés dans le dossier en cours
        ReportProgress(0, "Purge de l'écriture d'AN")
        Me.PurgerANNouveauDossier(My.User.Name, codeNouveauDossier, journalAN, oleDbTrans)

        'Suppression des 48800000 en trop (48800000 associés à des écritures lettrées non prise 
        'en compte dans la pièce d'AN. Par contre les 48800000 eux apparaissent dans la pièce d'AN)
        ReportProgress(0, "Suppression des 488 en trop")
        Me.Supprimer48800000EnTrop(codeNouveauDossier, oleDbTrans)
    End Sub

    Private Sub PurgerANNouveauDossier(ByVal codeDossierEnCours As String, ByVal codeNouveauDossier As String, _
    ByVal codeJournal As String, ByVal oleDbTrans As OleDb.OleDbTransaction)
        Dim queryString As String = String.Empty

        'Supprime les lignes et les mouvements du nouveau dossier qui n'ont pas un MIdANouveau 
        'correspondant à un MIdANouveauSuiv dans le dossier en cours

        'Suppression des lettrages associés avant suppression
        queryString = "UPDATE Mouvements SET MLettrage = NULL " & _
                        "WHERE Mouvements.MDossier='" & Replace(codeNouveauDossier, "'", "''") & "' " & _
                        "AND Mouvements.MLettrage Is Not Null " & _
                        "AND Mouvements.MIdANouveau Not In " & _
                        "(SELECT Mouvements.MIdANouveauSuiv " & _
                        "FROM Mouvements " & _
                        "WHERE Mouvements.MDossier='" & Replace(codeDossierEnCours, "'", "''") & "' " & _
                        "AND Mouvements.MIdANouveauSuiv Is Not Null)"

        Dim oleDbComm As New OleDbCommand(queryString, oleDbTrans.Connection)

        oleDbComm.Transaction = oleDbTrans

        oleDbComm.ExecuteNonQuery()

        'Supprime les mouvements du nouveau dossier qui n'ont pas un MIdANouveau 
        'correspondant à un MIdANouveauSuiv dans le dossier en cours 
        queryString = "DELETE FROM Mouvements " & _
                        "WHERE MDossier='" & Replace(codeNouveauDossier, "'", "''") & "' " & _
                        "AND MIdANouveau Not IN " & _
                        "(SELECT Mouvements.MIdANouveauSuiv " & _
                        "FROM Mouvements " & _
                        "WHERE (Mouvements.MDossier='" & Replace(codeDossierEnCours, "'", "''") & "') " & _
                        "AND (Mouvements.MIdANouveauSuiv Is Not Null))"

        oleDbComm.CommandText = queryString

        oleDbComm.ExecuteNonQuery()

        'Suppression des mouvements de la pièce d'AN du nouveau dossier
        'qui ont été lettrés dans le dossier en cours
        queryString = "DELETE * FROM Mouvements " & _
                        "WHERE MDossier='" & Replace(codeNouveauDossier, "'", "''") & "' " & _
                        "AND MIdANouveau IN " & _
                        "(SELECT Mouvements.MIdANouveauSuiv " & _
                        "FROM Mouvements " & _
                        "WHERE Mouvements.MIdANouveauSuiv Is Not Null " & _
                        "AND Mouvements.MDossier='" & Replace(codeDossierEnCours, "'", "''") & "' " & _
                        "AND Mouvements.MLettrage Is Not Null)"

        oleDbComm.CommandText = queryString

        oleDbComm.ExecuteNonQuery()

        'Supprime les lignes du nouveau dossier qui n'ont pas un MIdANouveau 
        'correspondant à un MIdANouveauSuiv dans le dossier en cours
        Me.SupprimerLignesCptsSansReportsDetailles(codeNouveauDossier, codeJournal)
    End Sub

    Private Function MontantsDifferents(ByVal mvtsDossierEnCoursRow As dbSauvRest.MouvementsRow, _
    ByVal mvtsNouveauDossierRow As dbSauvRest.MouvementsRow) As Boolean

        Dim montantDebitDossierEnCours As Decimal = 0
        Dim montantCreditDossierEnCours As Decimal = 0
        Dim montantDebitNouveauDossier As Decimal = 0
        Dim montantCreditNouveauDossier As Decimal = 0

        If Not (mvtsDossierEnCoursRow.IsMMtDebNull) Then
            montantDebitDossierEnCours = mvtsDossierEnCoursRow.MMtDeb
        Else
            montantDebitDossierEnCours = 0
        End If

        If Not (mvtsDossierEnCoursRow.IsMMtCreNull) Then
            montantCreditDossierEnCours = mvtsDossierEnCoursRow.MMtCre
        Else
            montantCreditDossierEnCours = 0
        End If

        If Not (mvtsNouveauDossierRow.IsMMtDebNull) Then
            montantDebitNouveauDossier = mvtsNouveauDossierRow.MMtDeb
        Else
            montantDebitNouveauDossier = 0
        End If

        If Not (mvtsNouveauDossierRow.IsMMtCreNull) Then
            montantCreditNouveauDossier = mvtsNouveauDossierRow.MMtCre
        Else
            montantCreditNouveauDossier = 0
        End If

        'Comparaison des montants au débit
        If (montantDebitDossierEnCours <> montantDebitNouveauDossier) Then
            Return True
        End If

        'Comparaison des montants au crédit
        If (montantCreditDossierEnCours <> montantCreditNouveauDossier) Then
            Return True
        End If

        Return False
    End Function

    Private Function ComptesDifferents(ByVal mvtsDossierEnCoursRow As dbSauvRest.MouvementsRow, _
    ByVal mvtsNouveauDossierRow As dbSauvRest.MouvementsRow) As Boolean

        Dim compteDossierEnCours As String = String.Empty
        Dim compteNouveauDossier As String = String.Empty

        If Not (mvtsDossierEnCoursRow.IsMCptNull) Then
            compteDossierEnCours = mvtsDossierEnCoursRow.MCpt
        Else
            compteDossierEnCours = String.Empty
        End If

        If Not (mvtsNouveauDossierRow.IsMCptNull) Then
            compteNouveauDossier = mvtsNouveauDossierRow.MCpt
        Else
            compteNouveauDossier = String.Empty
        End If

        'Comparaison des comptes
        If (String.Compare(compteDossierEnCours, compteNouveauDossier) <> 0) Then
            Return True
        End If

        Return False
    End Function

    Private Sub Supprimer48800000EnTrop(ByVal codeDossier As String, ByVal oleDbTrans As OleDb.OleDbTransaction)
        Dim queryString As String = String.Empty

        queryString = "DELETE * FROM Mouvements WHERE MDossier='" & codeDossier & "' AND MIdANouveau IN " & _
                        "(SELECT Mouvements.MIdANouveau " & _
                        "FROM Mouvements LEFT JOIN " & _
                        "(SELECT Mouvements.* " & _
                        "FROM Mouvements AS Mouvements_1 INNER JOIN Mouvements ON " & _
                        "(Mouvements_1.MDossier = Mouvements.MDossier) AND (Mouvements_1.MPiece = Mouvements.MPiece) " & _
                        "AND (Mouvements_1.MDate = Mouvements.MDate) AND (Mouvements_1.MLig = Mouvements.MLig) " & _
                        "WHERE (((Mouvements.MDossier)='" & codeDossier & "') AND ((Mouvements_1.MCpt)<>'48800000') " & _
                        "AND ((Mouvements_1.MDossier)='" & codeDossier & "'))) AS test ON " & _
                        "(Mouvements.MOrdre = test.MOrdre) AND (Mouvements.MLig = test.MLig) " & _
                        "AND (Mouvements.MDate = test.MDate) AND (Mouvements.MPiece = test.MPiece) " & _
                        "AND (Mouvements.MDossier = test.MDossier) " & _
                        "WHERE (((Mouvements.MDossier)='" & codeDossier & "') AND ((test.MDossier) Is Null)))"


        Dim oleDbComm As New OleDbCommand(queryString, oleDbTrans.Connection)

        oleDbComm.Transaction = oleDbTrans

        oleDbComm.ExecuteNonQuery()
    End Sub

    Private Sub SupprimerMouvementsCptsSansReportsDetailles(ByVal codeDossier As String, ByVal codeJournal As String)
        Dim mvtsDataTable As dbSauvRest.MouvementsDataTable = Me.MouvementsTableAdapterReport.GetDataByCptsSansReportsDetailles(codeJournal, True, codeDossier)

        For Each mvtsRow As dbSauvRest.MouvementsRow In mvtsDataTable.Rows
            Me.MouvementsTableAdapterReport.Delete(mvtsRow.MDossier, mvtsRow.MPiece, mvtsRow.MDate, mvtsRow.MLig, mvtsRow.MOrdre)
        Next
    End Sub

    Private Sub SupprimerLignesCptsSansReportsDetailles(ByVal codeDossier As String, ByVal codeJournal As String)
        Dim ligDataTable As dbSauvRest.LignesDataTable = Me.LignesTableAdapterReport.GetDataByLignesSansMouvementsParDossierEtJournal(codeJournal, codeDossier)

        For Each ligRow As dbSauvRest.LignesRow In ligDataTable.Rows
            Me.LignesTableAdapterReport.Delete(ligRow.LDossier, ligRow.LPiece, ligRow.LDate, ligRow.LLig)
        Next
    End Sub

    Private Function MaxLigne(ByVal codeDossier As String, ByVal codeJournal As String) As Integer
        Dim maxLig As Integer = 0

        maxLig = Me.LignesTableAdapterReport.MaxLigneParDossierEtJournalEtIssueDeCloture(codeDossier, codeJournal, True).GetValueOrDefault

        Return maxLig
    End Function

    Private Sub GenererRANEcrituresPointees(ByVal codeNouveauDossier As String, ByVal nNumPiece As Integer, ByVal nLigne As Integer, ByVal journalAN As String)
        Dim oleDbSelect As String = String.Empty

        oleDbSelect = "SELECT SUM(MMtDeb) - SUM(MMtCre) AS SoldeEcrPoint, MCpt, MDossier " & _
                        "FROM Mouvements " & _
                        "WHERE MPointage Is Not NULL " & _
                        "GROUP BY MCpt, MDossier " & _
                        "HAVING (MDossier = '" & My.User.Name & "')"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            Dim oleDbDataReader As OleDbDataReader = oleDbCommand.ExecuteReader()

            Try
                While oleDbDataReader.Read()
                    Dim soldeEcrPoint As Decimal = 0
                    Dim compteTreso As String = String.Empty
                    Dim codePointage As String = String.Empty
                    Dim datePointage As Date = Date.MinValue

                    If Not (IsDBNull(oleDbDataReader("MCpt"))) Then
                        compteTreso = oleDbDataReader("MCpt").ToString()
                    End If

                    If Not (IsDBNull(oleDbDataReader("SoldeEcrPoint"))) Then
                        soldeEcrPoint = CDec(oleDbDataReader("SoldeEcrPoint"))
                    End If

                    'Calcul du code pointage
                    Using dtaMouvement As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
                        codePointage = RapprochementBancaire.CodePointage.CreerCodePointage(dtaMouvement.MaxPointage)
                    End Using

                    'formatage de la date de pointage
                    datePointage = CDate(FormatDateTime(Now, DateFormat.ShortDate))

                    'Création des lignes d'A NOUVEAU
                    Me.LignesTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                    Nothing, "RAN N-1", "O", "O", journalAN, "", New Nullable(Of Date), New Nullable(Of Date), _
                    New Nullable(Of Date))

                    Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                    CByte(IIf(soldeEcrPoint >= 0, nOrdreD, nOrdreC)), compteTreso, "0000", _
                    CDec(IIf(soldeEcrPoint > 0, Math.Abs(soldeEcrPoint), 0)), _
                    CDec(IIf(soldeEcrPoint > 0, 0, Math.Abs(soldeEcrPoint))), CStr(IIf(soldeEcrPoint < 0, "C", "D")), _
                    Nothing, Nothing, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, codePointage, _
                    datePointage, Nothing, Nothing)

                    Me.MouvementsTableAdapterReport.Insert(codeNouveauDossier, nNumPiece, CDate(dtpDebut.Value.ToShortDateString), nLigne, _
                    CByte(IIf(soldeEcrPoint >= 0, nOrdreC, nOrdreD)), "48800000", "0000", _
                    CDec(IIf(soldeEcrPoint > 0, 0, Math.Abs(soldeEcrPoint))), _
                    CDec(IIf(soldeEcrPoint > 0, Math.Abs(soldeEcrPoint), 0)), CStr(IIf(soldeEcrPoint < 0, "D", "C")), _
                    Nothing, Nothing, Nothing, Nothing, Nothing, compteTreso, "0000", Nothing, Nothing, _
                    Nothing, Nothing, Nothing)

                    nLigne += 1
                End While
            Finally
                oleDbDataReader.Close()
            End Try
        End Using
    End Sub

    Private Function SoldeEcrPointees() As Decimal
        Dim oleDbSelect As String = String.Empty
        Dim solde As Decimal = 0

        oleDbSelect = "SELECT IIf(ISNULL(SUM(MMtDeb) - SUM(MMtCre)), 0, SUM(MMtDeb) - SUM(MMtCre)) AS SoldeEcrPoint " & _
                        "FROM Mouvements " & _
                        "WHERE MPointage Is Not NULL AND MDossier = '" & My.User.Name & "'"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            solde = Convert.ToDecimal(oleDbCommand.ExecuteScalar())
        End Using

        Return solde
    End Function

    Private Function CalculerResultat(ByVal dsReport As dbSauvRest, ByVal reporterNonLettre As Boolean, _
    ByVal filtreCptsNonLettres As String) As Decimal

        Dim resultatGestionD As Decimal = 0
        Dim resultatGestionC As Decimal = 0
        Dim resultatBilanD As Decimal = 0
        Dim resultatBilanC As Decimal = 0
        Dim resultat As Decimal = 0

        For Each drPLC As dbSauvRest.PlanComptableRow In dsReport.PlanComptable.Rows
            If drPLC.PlCpt > "6" Then
                resultatGestionD += ReplaceDbNull(drPLC.Item("PlSoldeG_D"), 0D)
                resultatGestionC += ReplaceDbNull(drPLC.Item("PlSoldeG_C"), 0D)
            Else
                resultatBilanD += ReplaceDbNull(drPLC.Item("PlRepG_D"), 0D)
                resultatBilanC += ReplaceDbNull(drPLC.Item("PlRepG_C"), 0D)
            End If

            'Eventuellement prendre en compte les mouvements non lettrés
            If reporterNonLettre AndAlso VerifFiltre(drPLC.PlCpt, filtreCptsNonLettres) Then
                Dim rwsMvtNonLettres() As dbSauvRest.MouvementsRow = TrouverMvtNonLettres(dsReport, drPLC.PlCpt, drPLC.PlActi)
                For Each rwMvt As dbSauvRest.MouvementsRow In rwsMvtNonLettres
                    If drPLC.PlCpt > "6" Then
                        resultatGestionD += ReplaceDbNull(rwMvt.Item("MMtDeb"), 0D)
                        resultatGestionC += ReplaceDbNull(rwMvt.Item("MMtCre"), 0D)
                    Else
                        resultatBilanD += ReplaceDbNull(rwMvt.Item("MMtDeb"), 0D)
                        resultatBilanC += ReplaceDbNull(rwMvt.Item("MMtCre"), 0D)
                    End If
                Next
            End If
        Next

        'Ajout du montant des écritures de contrepartie pour les écritures pointées
        Dim soldeEcrPointees As Decimal = 0

        If reporterNonLettre AndAlso VerifFiltre("512", filtreCptsNonLettres) Then
            soldeEcrPointees = Me.SoldeEcrPointees()
        End If

        resultat = resultatGestionD - resultatGestionC

        'Contrôle de cohérence
        If resultatBilanD - resultatBilanC + soldeEcrPointees <> -resultat Then
            Throw New ApplicationException(String.Format(My.Resources.Strings.Cloture_AvertissementProblemeBalance, _
            Math.Abs(Math.Abs(resultatBilanD - resultatBilanC) + Math.Abs(soldeEcrPointees) - Math.Abs(resultat)).ToString))
        End If

        Return resultat
    End Function

    Private Function TrouverMvtNonLettres(ByVal dsReport As dbSauvRest, ByVal Cpt As String, ByVal Acti As String) As dbSauvRest.MouvementsRow()
        Dim rws() As DataRow = dsReport.Mouvements.Select(String.Format("MCpt='{0}' AND MActi='{1}' AND MLettrage IS NULL AND MPointage IS NULL", Cpt, Acti))

        Return CType(rws, dbSauvRest.MouvementsRow())
    End Function

    Private Sub VerifPlanComptable(ByVal nDossier As String, ByVal drPLC As dbSauvRest.PlanComptableRow, ByVal t As OleDb.OleDbTransaction)
        Dim cnt As Integer = UtilBase.ExecuteScalarInt(FormatSql("SELECT COUNT(*) FROM PlanComptable WHERE PlDossier={0} AND PlCpt={1} AND PlActi={2}", nDossier, drPLC.PlCpt, drPLC.PlActi), t)
        If cnt = 0 Then
            VerifCompte(nDossier, drPLC.ComptesRowParent, t)
            VerifActi(nDossier, drPLC.ActivitesRowParent, t)
            Using dta As New dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
                dta.SetTransaction(t)
                dta.Insert(nDossier, drPLC.PlCpt, drPLC.PlActi, Convert.ToString(drPLC("PlLib")))
            End Using
        End If
    End Sub

    Private Sub VerifCompte(ByVal nDossier As String, ByVal drCpt As dbSauvRest.ComptesRow, ByVal t As OleDb.OleDbTransaction)
        Dim cnt As Integer = UtilBase.ExecuteScalarInt(FormatSql("SELECT COUNT(*) FROM Comptes WHERE CDossier={0} AND CCpt={1}", nDossier, drCpt.CCpt), t)
        If cnt = 0 Then
            Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                dta.SetTransaction(t)

                Dim libelle As String = String.Empty
                If (drCpt.IsCLibNull) Then
                    libelle = String.Empty
                Else
                    libelle = drCpt.CLib
                End If

                Dim unite1 As String = String.Empty
                If (drCpt.IsCU1Null) Then
                    unite1 = String.Empty
                Else
                    unite1 = drCpt.CU1
                End If

                Dim unite2 As String = String.Empty
                If (drCpt.IsCU2Null) Then
                    unite2 = String.Empty
                Else
                    unite2 = drCpt.CU2
                End If

                dta.Insert(nDossier, drCpt.CCpt, libelle, unite1, unite2, _
                Convert.ToString(drCpt("CCptContre")), Convert.ToString(drCpt("C_DC")))
            End Using
        End If
    End Sub

    Private Sub VerifActi(ByVal nDossier As String, ByVal drActi As dbSauvRest.ActivitesRow, ByVal t As OleDb.OleDbTransaction)
        Dim cnt As Integer = UtilBase.ExecuteScalarInt(FormatSql("SELECT COUNT(*) FROM Activites WHERE ADossier={0} AND AActi={1}", nDossier, drActi.AActi), t)
        If cnt = 0 Then
            Using dta As New dbDonneesDataSetTableAdapters.ActivitesTableAdapter
                dta.SetTransaction(t)
                dta.Insert(nDossier, drActi.AActi, drActi.ALib, drActi.AQte, drActi.AUnit)
            End Using
        End If
    End Sub

    Private Sub CalculerReports(ByRef dsReport As dbSauvRest, ByVal exclureNonLettre As Boolean, ByVal filtreExclusion As String)
        For Each drPLC As dbSauvRest.PlanComptableRow In dsReport.PlanComptable.Rows
            If drPLC.PlCpt = "48800000" Then Continue For
            Dim recapReport As New RecapCompte
            recapReport.Add(drPLC)

            Dim recapGen As New RecapCompte
            'If drPLC.PlCpt Like "41*" Then Stop
            Dim exclu As Boolean = exclureNonLettre AndAlso VerifFiltre(drPLC.PlCpt, filtreExclusion)
            For Each drMvt As dbSauvRest.MouvementsRow In dsReport.PlanComptable.FindMouvsByCptAndActi(drPLC.PlCpt, drPLC.PlActi).GetMouvementsRows
                If Not (exclu AndAlso drMvt.IsMLettrageNull) Then
                    recapGen.Add(drMvt)
                End If
            Next

            recapGen.Add(recapReport)
            If drPLC.PlCpt > "6" Then
                If recapGen.SoldeCred >= 0 Then
                    drPLC.PlSoldeG_D = 0
                    drPLC.PlSoldeG_C = recapGen.SoldeAbs
                Else
                    drPLC.PlSoldeG_D = recapGen.SoldeAbs
                    drPLC.PlSoldeG_C = 0
                End If
                drPLC.PlSoldeG_U1 = recapGen.PrixUnit1
                drPLC.PlSoldeG_U2 = recapGen.PrixUnit2
            Else
                If recapGen.SoldeCred >= 0 Then
                    drPLC.PlRepG_D = 0
                    drPLC.PlRepG_C = recapGen.SoldeAbs
                Else
                    drPLC.PlRepG_D = recapGen.SoldeAbs
                    drPLC.PlRepG_C = 0
                End If
                drPLC.PlRepG_U1 = recapGen.PrixUnit1
                drPLC.PlRepG_U2 = recapGen.PrixUnit2
            End If
        Next
    End Sub

    Private Function VerifFiltre(ByVal cpt As String, ByVal filtre As String) As Boolean
        Dim filtres() As String = filtre.Split(";"c)
        For Each f As String In filtres
            If cpt Like f & "*" Then Return True
        Next
        Return False
    End Function

    Private Function ListeComptesfiltreCptsNonLettres(ByVal filtre As String) As String
        Dim filtres() As String = filtre.Split(";"c)
        Dim listeCpts As String = String.Empty

        For Each f As String In filtres
            listeCpts = listeCpts & f & ","
        Next

        listeCpts = Mid(listeCpts, 0, listeCpts.Length - 1)

        Return listeCpts
    End Function

    Private Function CreateNewExo(ByVal sNewExo As String, ByRef oleDbTrans As OleDb.OleDbTransaction) As String
        Dim dsNewExo As New dbSauvRest
        Dim xDossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)

        Try
            ReportProgress(0, My.Resources.Strings.ChargementDesDonnees)
            'Dossier
            Me.PlanComptableTableAdapter.FillByDossier(dsNewExo.PlanComptable, xDossier.Identity.Name)
            ReportProgress(12)
            Me.InventaireLignesTableAdapter.FillByDossier(dsNewExo.InventaireLignes, xDossier.Identity.Name)
            Me.InventaireGroupesTableAdapter.FillByDossier(dsNewExo.InventaireGroupes, xDossier.Identity.Name)
            ReportProgress(36)
            Me.ImmobilisationsTableAdapter.FillByDossier(dsNewExo.Immobilisations, xDossier.Identity.Name)
            Me.DossiersTableAdapter.FillByDossier(dsNewExo.Dossiers, xDossier.Identity.Name)
            ReportProgress(48)
            Me.ComptesTableAdapter.FillByDossier(dsNewExo.Comptes, xDossier.Identity.Name)
            Me.ActivitesTableAdapter.FillByDossier(dsNewExo.Activites, xDossier.Identity.Name)

            For Each xRow As dbSauvRest.PlanComptableRow In dsNewExo.PlanComptable.Rows
                xRow.PlDossier = sNewExo
            Next

            For Each xRow As dbSauvRest.InventaireLignesRow In dsNewExo.InventaireLignes.Rows
                xRow.INVLDossier = sNewExo
            Next

            For Each xRow As dbSauvRest.InventaireGroupesRow In dsNewExo.InventaireGroupes.Rows
                xRow.INVGDossier = sNewExo
            Next

            For Each xRow As dbSauvRest.ImmobilisationsRow In dsNewExo.Immobilisations.Rows
                xRow.IDossier = sNewExo
            Next

            For Each xRow As dbSauvRest.DossiersRow In dsNewExo.Dossiers.Rows
                xRow.DDossier = sNewExo
                xRow.DDtDebEx = CDate(dtpDebut.Value.ToShortDateString)
                xRow.DDtFinEx = CDate(dtpFin.Value.ToShortDateString)
            Next

            For Each xRow As dbSauvRest.ComptesRow In dsNewExo.Comptes.Rows
                xRow.CDossier = sNewExo
            Next

            For Each xRow As dbSauvRest.ActivitesRow In dsNewExo.Activites.Rows
                xRow.ADossier = sNewExo
            Next

            SaveAllData(dsNewExo, oleDbTrans)
            Return sNewExo

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
            Return ""
        End Try
    End Function

    Private Sub SaveAllData(ByVal dsCreateNew As DataSet, ByRef t As OleDb.OleDbTransaction)
        Try
            ReportProgress(7)
            Me.DossiersTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.DossiersTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(20)
            Me.ActivitesTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.ActivitesTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(30)
            Me.ComptesTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.ComptesTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(40)
            Me.PlanComptableTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.PlanComptableTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(70)
            Me.ImmobilisationsTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.ImmobilisationsTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(75)
            Me.InventaireGroupesTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.InventaireGroupesTableAdapter.GetDataAdapter, dsCreateNew)

            ReportProgress(80)
            Me.InventaireLignesTableAdapter.SetTransaction(t)
            ForceDataAdapter.ForceInsert(Me.InventaireLignesTableAdapter.GetDataAdapter, dsCreateNew)
        Catch ex As OleDb.OleDbException
            t.Rollback()
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Class RecapCompte
        Public MontantC As Decimal = 0D
        Public MontantD As Decimal = 0D
        Public Qt1 As Decimal = 0D
        Public Qt2 As Decimal = 0D

#Region "Propriétés"
        Public ReadOnly Property SoldeCred() As Decimal
            Get
                Return MontantC - MontantD
            End Get
        End Property

        Public ReadOnly Property SoldeAbs() As Decimal
            Get
                Return Math.Abs(SoldeCred)
            End Get
        End Property

        Public ReadOnly Property PrixUnit1() As Decimal
            Get
                If Qt1 > 0 Then
                    Return Me.SoldeAbs / Qt1
                Else
                    Return 0
                End If
            End Get
        End Property

        Public ReadOnly Property PrixUnit2() As Decimal
            Get
                If Qt2 > 0 Then
                    Return Me.SoldeAbs / Qt2
                Else
                    Return 0
                End If
            End Get
        End Property
#End Region

#Region "Méthodes diverses"
        Public Sub Add(ByVal recap As RecapCompte)
            Me.MontantC += ReplaceDbNull(recap.MontantC, 0D)
            Me.MontantD += ReplaceDbNull(recap.MontantD, 0D)
            Me.Qt1 += ReplaceDbNull(recap.Qt1, 0D)
            Me.Qt2 += ReplaceDbNull(recap.Qt2, 0D)
        End Sub

        Public Sub Add(ByVal dr As dbSauvRest.PlanComptableRow)
            Me.MontantC += ReplaceDbNull(dr.Item("PlRepG_C"), 0D)
            Me.MontantD += ReplaceDbNull(dr.Item("PlRepG_D"), 0D)
            Me.Qt1 += ReplaceDbNull(dr.Item("PlRepG_U1"), 0D)
            Me.Qt2 += ReplaceDbNull(dr.Item("PlRepG_U2"), 0D)
        End Sub

        Public Sub Add(ByVal dr As dbSauvRest.MouvementsRow)
            Me.MontantC += ReplaceDbNull(dr.Item("MMtCre"), 0D)
            Me.MontantD += ReplaceDbNull(dr.Item("MMtDeb"), 0D)
            Me.Qt1 += ReplaceDbNull(dr.Item("MQte1"), 0D)
            Me.Qt2 += ReplaceDbNull(dr.Item("MQte2"), 0D)
        End Sub
#End Region

    End Class
#End Region

#Region "Méthodes diverses"
    Private Sub DesactiverForm()
        Me.rbtDefinitive.Checked = True
        ResizeTo(Me.gpbCloture)
        Me.gpbCloture.Enabled = False
        Me.OK_Button.Enabled = False
    End Sub

    Private Sub InitialiserForm()
        Dim dossier As DossierPrincipal = My.Dossier.Principal
        Dim codeDossierSuivant As String = Me.CodeDossierSuivant(My.User.Name)
        Dim dtNewDeb As Date = Date.MinValue
        Dim dtNewFin As Date = Date.MinValue

        'Se positionner sur le compte de résultat par défaut
        Me.CompteBindingSource.Position = Me.CompteBindingSource.Find("PlCpt", "12000000")
        Me.txCptNonLettres.Text = My.Settings.FiltreCptesAReporterNonLettres

        'S'il existe un exercice N + 1, on grise les dates de début et de fin d'exercice suivant 
        'ainsi que les options de clôture et de reports détaillés.
        'On rempli la zone des comptes avec reports détaillés avec les données
        'de la table Dossiers pour le nouveau dossier
        If Not String.IsNullOrEmpty(codeDossierSuivant) Then
            Me.gpbDate.Enabled = False
            Me.gpbOptionsDef.Enabled = False

            'Recherche des dates de début et de fin de l'exercice suivant
            If (Me.DateDebutExercice(codeDossierSuivant) <> Date.MinValue) Then
                dtNewDeb = Me.DateDebutExercice(codeDossierSuivant)
            Else
                dtNewDeb = System.Windows.Forms.DateTimePicker.MinDateTime
            End If

            If (Me.DateFinExercice(codeDossierSuivant) <> Date.MinValue) Then
                dtNewFin = Me.DateFinExercice(codeDossierSuivant)
            Else
                dtNewFin = System.Windows.Forms.DateTimePicker.MinDateTime
            End If

            Me.txCptNonLettres.Text = Me.ComptesReportsDetaillesCloture(codeDossierSuivant)
        Else
            dtNewDeb = My.Dossier.Principal.DateFinEx.AddDays(1)
            dtNewFin = dtNewDeb.AddMonths(12).AddDays(-1)
        End If

        'Initialisation des dates de début et de fin d'exercice suivant
        With Me.dtpDebut
            .Value = dtNewDeb
            .MinDate = dtNewDeb
            .MaxDate = dtNewDeb.AddMonths(14).AddDays(-2)
        End With

        With Me.dtpFin
            .Value = dtNewFin
            .MaxDate = dtNewDeb.AddMonths(14).AddDays(-1)
            .MinDate = dtNewDeb.AddDays(1)
        End With

        Me.dtpDebut.Enabled = False
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing, Optional ByVal max As Integer = 100)
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = Convert.ToString(status)
            Application.DoEvents()
        End If

        Me.pgBar.Value = (percent * 100 \ max)
    End Sub

    Private Sub ResizeTo(ByVal gb As GroupBox)
        Me.SetClientSizeCore(Me.ClientSize.Width, gb.Bottom + gb.Margin.Bottom + GradientPanel2.Height)
    End Sub

    Private Function DatesNouvelExerciceOK() As Boolean
        If Me.dtpDebut.Value > Me.dtpFin.Value Then
            MsgBox(My.Resources.Strings.SelectionDate_DateInferieureADateFin, MsgBoxStyle.Information, My.Resources.Strings.SelectionDate)

            Return False
        ElseIf DateDiff(DateInterval.Month, Me.dtpDebut.Value, Me.dtpFin.Value.AddDays(1)) > 14 Then
            MsgBox(My.Resources.Strings.Date_Ecart14Mois, MsgBoxStyle.Information, My.Resources.Strings.SelectionDate)

            Return False
        End If

        Return True
    End Function

    Private Function DateDebutExercice(ByVal codeDossier As String) As Date
        Dim oleDbSelect As String = String.Empty
        Dim dateDeb As Date = Date.MinValue

        oleDbSelect = "SELECT DDtDebEx " & _
                        "FROM Dossiers " & _
                        "WHERE DDossier = '" & codeDossier & "'"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            If Not (IsDBNull(oleDbCommand.ExecuteScalar())) Then
                dateDeb = Convert.ToDateTime(oleDbCommand.ExecuteScalar())
            End If
        End Using

        Return dateDeb
    End Function

    Private Function DateFinExercice(ByVal codeDossier As String) As Date
        Dim oleDbSelect As String = String.Empty
        Dim dateFin As Date = Date.MinValue

        oleDbSelect = "SELECT DDtFinEx " & _
                        "FROM Dossiers " & _
                        "WHERE DDossier = '" & codeDossier & "'"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            If Not (IsDBNull(oleDbCommand.ExecuteScalar())) Then
                dateFin = Convert.ToDateTime(oleDbCommand.ExecuteScalar())
            End If
        End Using

        Return dateFin
    End Function

    Private Function ComptesReportsDetaillesCloture(ByVal codeDossier As String) As String
        Dim oleDbSelect As String = String.Empty
        Dim comptes As String = String.Empty

        oleDbSelect = "SELECT DComptesReportsDetaillesCloture " & _
                        "FROM Dossiers " & _
                        "WHERE DDossier = '" & codeDossier & "'"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            If Not (IsDBNull(oleDbCommand.ExecuteScalar())) Then
                comptes = Convert.ToString(oleDbCommand.ExecuteScalar())
            End If
        End Using

        Return comptes
    End Function

    Private Function CodeDossierSuivant(ByVal codeDossier As String) As String
        Dim oleDbSelect As String = String.Empty
        Dim codeDossierSuiv As String = String.Empty

        oleDbSelect = "SELECT TOP 1 DDossier " & _
                        "FROM Dossiers " & _
                        "WHERE DDtDebEx = " & _
                        "(SELECT Min(Dossiers.DDtDebEx) AS MINDATEDEB " & _
                        "FROM Dossiers " & _
                        "WHERE Dossiers.DDtDebEx >= " & _
                        "(SELECT Dossiers.DDtFinEx " & _
                        "FROM Dossiers " & _
                        "WHERE Dossiers.DDossier='" & Replace(codeDossier, "'", "''") & "'))"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            If Not (IsDBNull(oleDbCommand.ExecuteScalar())) Then
                codeDossierSuiv = Convert.ToString(oleDbCommand.ExecuteScalar())
            End If
        End Using

        Return codeDossierSuiv
    End Function
#End Region

End Class

