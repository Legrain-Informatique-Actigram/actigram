Imports AgrigestEDI.GestionMenu
Public Class Main
    Private Const NOM_ACCUEIL As String = "Accueil"
    Public sNameOpenMenu As String = ""

    'TODO PROBLEME DE VERIF TVA (sur encaissement) DANS LES PIECES DE REMISE
    '=> NE FAIRE LA GESTION DE TVA QU'EN JOURNAL D'ACHAT OU VENTE

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "Form"
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Init
        Me.Text = WindowText()

        'Actions de démarrage
        Using fr As New Splash
            With fr
                .MdiParent = Me
                .Show()
            End With
            My.Settings.Demarrage.Run()
            'Init interface
            ChargerUser()
        End Using
    End Sub
#End Region

#Region "AscendSidebar"
    Private Sub MenuItemActivate(ByVal sender As Object, ByVal e As EventArgs) Handles AscendSidebar1.MenuItemClick
        Dim i As Item
        If TypeOf sender Is Control Then
            i = CType(CType(sender, Control).Tag, Item)
        ElseIf TypeOf sender Is ListViewItem Then
            i = CType(CType(sender, ListViewItem).Tag, Item)
        Else
            Exit Sub
        End If
        If i.Form IsNot Nothing AndAlso i.Form.Length > 0 Then
            sNameOpenMenu = i.Nom
            AfficherEcran(i.Form, i.Dialog)
        Else
            Select Case i.Nom
                Case "ImportEcriture"
                    Using fr As New FrImportationIsagri()
                        If fr.ShowDialog = Windows.Forms.DialogResult.Retry Then
                            'On a changé d'exploitation, il faut se mettre à jour
                            MMenuChangerExpl_Click(Nothing, Nothing)
                        End If
                    End Using
                Case "ImportEDI"
                    FrImportEdis.VerifEdis(True)
                Case "InvStocksMag"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_STOCKSENMAG)
                Case "InvAnimaux"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_ANIMAUX)
                Case "InvStocksPdtTerre"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_STOCKSPRODTERRE)
                Case "InvFacCult"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_FACONSCULTURALES)
                Case "InvAvCult"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_AVAUXCULTURES)
                Case "InvStocksPdtFinis"
                    Me.OpenInventoryForm(My.Resources.CODE_TYPEINV_STOCKSPRODFINIS)
            End Select
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function WindowText() As String
        Dim vers As String
        Dim Nom As String = ""
        Dim ExoDebut As String = ""
        Dim ExoFin As String = ""
        Dim infosCloture As String = String.Empty
        '#If DEBUG Then
        'vers = My.Application.Info.Version.ToString
        '#Else
        vers = My.Application.Info.Version.ToString(2)
        '#End If
        If TypeOf My.User.CurrentPrincipal Is DossierPrincipal Then
            With CType(My.User.CurrentPrincipal, DossierPrincipal)
                Nom = .NomExploi1
                ExoDebut = .DateDebutEx.ToShortDateString
                ExoFin = .DateFinEx.ToShortDateString
                If Not (.DateClotureCompta = Date.MinValue) Then
                    infosCloture = " - Dossier cloturé le " & .DateClotureCompta.ToShortDateString
                End If
            End With
            Return String.Format("{0} {5}- {1} - {2} - Exercice du {3} au {4}{6}", My.Application.Info.ProductName, Nom, My.User.Name, ExoDebut, ExoFin, vers, infosCloture)
        End If

        Return String.Format("{0} {2}- {1}", My.Application.Info.ProductName, My.User.Name, vers)

    End Function

    Private Sub ChargerUser()
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        'Gestion de la sécurité
        Me.Text = WindowText()

        'Chargement de la page d'acceuil
        If Me.MdiChildren.Length = 0 Then
            Dim trouve As Boolean = False
            For Each f As Form In Me.MdiChildren
                If f.Name = NOM_ACCUEIL Then
                    trouve = True
                    Exit For
                End If
            Next
            If Not trouve Then AfficherEcran(NOM_ACCUEIL)
        End If

        'Chargement du menu
        'GestionMenu.Menu.ChargerMenus(Me.NavPane, New EventHandler(AddressOf MenuItemActivate))
        Me.AscendSidebar1.LoadMenus(GestionMenu.Menu.ListerMenus)
        If My.User.Name <> "" Then
            ParametrePlanComptable()
        End If

    End Sub

    Private Sub ParametrePlanComptable()
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT count(*) FROM PlanComptable WHERE PlDossier='" + My.User.Name + "'", conn) = 0 Then
                Application.DoEvents()
                With New FrAssistantCreationDossier
                    .ShowDialog()
                End With
            End If
        End Using
    End Sub

    Public Function AfficherEcran(ByVal className As String, Optional ByVal dialog As Boolean = False) As DialogResult
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
        If asm.GetType(GetType(Main).Namespace & "." & className, False) Is Nothing Then
            Throw New ApplicationException(My.Resources.Strings.AfficherEcran_LeNomDeClasseEstIncorrect)
        End If
        Dim f As Object = asm.CreateInstance(GetType(Main).Namespace & "." & className)
        If Not TypeOf f Is Form Then
            Throw New ApplicationException(My.Resources.Strings.AfficherEcran_PasUnEcran)
        End If
        Return AfficherEcran(CType(f, Form), dialog)
    End Function

    Private Function AfficherEcran(ByVal fr As Form, Optional ByVal dialog As Boolean = False) As DialogResult
        If fr.Name <> NOM_ACCUEIL Then
            Array.ForEach(Me.MdiChildren, AddressOf CloseForm)
        End If

        If Not TypeOf fr Is IPrechargement OrElse _
        CType(fr, IPrechargement).Precharger(CBool(IIf(sNameOpenMenu = "RecherchePiece" Or sNameOpenMenu = "RechercheBordereau", True, False))) Then

            If TypeOf fr Is IMenu Then AddHandler CType(fr, IMenu).MenuItemActivate, AddressOf MenuItemActivate
            If dialog Then
                With fr
                    .StartPosition = FormStartPosition.CenterParent
                    Dim res As DialogResult = .ShowDialog(Me)
                    ChildFormClosed(Nothing, Nothing)
                    Return res
                End With
            Else
                Me.AscendSidebar1.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()
                With fr
                    AddHandler .FormClosed, AddressOf ChildFormClosed
                    If Me.IsMdiContainer Then .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With
                Me.AscendSidebar1.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End If

        If Me.MdiChildren.Length = 0 Or (Me.MdiChildren.Length = 1 And Me.MdiChildren(0).Name = NOM_ACCUEIL) Then
            Dim trouve As Boolean = False
            For Each f As Form In Me.MdiChildren
                If f.Name = NOM_ACCUEIL Then
                    trouve = True
                    f.WindowState = FormWindowState.Maximized
                    Exit For
                End If
            Next
            If Not trouve Then AfficherEcran(NOM_ACCUEIL)
        End If

    End Function

    Public Shared Sub CloseForm(ByVal f As Form)
        If f.Name <> NOM_ACCUEIL Then
            f.Close()
        Else
            f.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub OpenInventoryForm(ByVal codeTypeInventaire As String)
        For Each f As Form In Me.MdiChildren
            If Not (f.Name = NOM_ACCUEIL) Then
                f.Close()
            End If
        Next

        Dim gestTypeInv As New Inventaire.ClassesControleur.GestionnaireTypeInventaire(My.Settings.dbDonneesConnectionString)
        Dim typeInv As Inventaire.ClassesMetier.TypeInventaire = gestTypeInv.GetTypeInventaire(codeTypeInventaire)

        With New FrInventaireGroupes(typeInv)
            If Me.IsMdiContainer Then .MdiParent = Me

            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

#Region "Gestion des evenements des forms enfants"
    Private Sub ChildFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If Me.MdiChildren.Length = 0 OrElse (Me.MdiChildren.Length = 1 And Me.MdiChildren(0).Name = NOM_ACCUEIL) Then
            Dim trouve As Boolean = False
            For Each f As Form In Me.MdiChildren
                If f.Name = NOM_ACCUEIL Then
                    trouve = True
                    f.WindowState = FormWindowState.Maximized
                    Exit For
                End If
            Next
            If Not trouve Then AfficherEcran(NOM_ACCUEIL)
        End If
    End Sub
#End Region

#Region "Gestion du Menu"

#Region "General"
    Private Sub MMenuChangerExpl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuChangerExpl.Click
        Using fr As New ChoixExploitation
            If fr.Charger Then
                If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MMenuChangerDossier_Click(Nothing, Nothing)
                End If
            End If
        End Using
    End Sub

    Private Sub MMenuChangerDossier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuChangerDossier.Click
        Using fr As New ChoixDossier(My.Settings.Exploitation.CodeExpl)
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.User.CurrentPrincipal = fr.Dossier

                'Import des EDI
                If My.Settings.AutoImportEDI Then FrImportEdis.VerifEdis()

                ChargerUser()
            End If
        End Using
    End Sub

    Private Sub MMenuSauvegarder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuSauvegarder.Click
        AfficherEcran("FrSauvegarde", True)
    End Sub

    Private Sub MMenuRestaurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuRestaurer.Click
        If AfficherEcran("FrRestauration", True) = Windows.Forms.DialogResult.OK Then
            'On a changé d'exploitation, il faut se mettre à jour
            MMenuChangerExpl_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub MMenuQuitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuQuitter.Click
        Me.Close()
    End Sub
#End Region

#Region "Parametrage"
    Private Sub MMenuParametrage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuParametrage.Click
        AfficherEcran("Admin.SaisieOption")
    End Sub

    Private Sub MMenuAssistantPlanC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuAssistantPlanC.Click
        With New FrAssistantCreationDossier
            .Mode = FrAssistantCreationDossier.ModeAssistant.PlanCSeul
            .ShowDialog()
        End With
    End Sub

    Private Sub AssistantCréationDeModèlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssistantCréationDeModèlesToolStripMenuItem.Click
        With New FrAssistantCreationDossier
            .Mode = FrAssistantCreationDossier.ModeAssistant.ModeleSeul
            .ShowDialog()
        End With
    End Sub

    Private Sub MotDePasseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotDePasseToolStripMenuItem.Click
        With New FrSaisieMotDePasse
            .ShowDialog()
        End With
    End Sub

    Private Sub JournauxPlanTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournauxPlanTypeToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        AfficherEcran("FrPlanTypeJournaux")
    End Sub

    Private Sub TVAPlanTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TVAPlanTypeToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        AfficherEcran("FrPlanTypeTVA")
    End Sub

    Private Sub ComptesPlanTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComptesPlanTypeToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        AfficherEcran("FrPlanType")
    End Sub

#Region "Barème"
    Private Sub SelectionnerBDDBaremesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerBDDBaremesToolStripMenuItem.Click
        With New FrBDDBaremes
            .ShowDialog()
        End With
    End Sub

    Private Sub GererBaremeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GererBaremeToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrGererBareme")
    End Sub

    Private Sub GererMaterielToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GererMaterielToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrGererMateriel")
    End Sub

    Private Sub GererTypesMaterielToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GererTypesMaterielToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrGererTypesMateriel")
    End Sub

    Private Sub GererBaremeForfaitaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GererBaremeForfaitaireToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrGererBaremeForfaitaire")
    End Sub

    Private Sub GererFaçonsCulturalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GererFaçonsCulturalesToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrGererFaconsCulturales")
    End Sub

    Private Sub ConfigurerAnnexesTiersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurerAnnexesTiersToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        Me.AfficherEcran("FrConfigurerAnnexesTiers")
    End Sub

    Private Sub MethodeEvaluationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MethodeEvaluationToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub

        With New FrMethodeEvaluation()
            .ShowDialog()
        End With
    End Sub
#End Region
#End Region

#Region "Maintenance"

    Private Sub MMenuLancerInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuLancerInter.Click
        If Not MMenuLancerInter.Checked Then
            If UltraVnc.Instance.StartVNC() Then
                Me.Text = WindowText() + My.Resources.Strings.TeleinterventionEnCours
                MMenuLancerInter.Text = My.Resources.Strings.ArreterLaTeleintervention
                MMenuLancerInter.Checked = True
            End If
        Else
            UltraVnc.Instance.StopVNC()
            Me.Text = WindowText()
            MMenuLancerInter.Text = My.Resources.Strings.LancerLaTeleintervention
            MMenuLancerInter.Checked = False
        End If
    End Sub

    Private Sub SessionNetViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SessionNetViewerToolStripMenuItem.Click
        NetViewer.StartNetViewer()
    End Sub

    Private Sub MMenuSAV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuSAV.Click
        Using fr As New FrContactSupport
            fr.ShowDialog()
        End Using
    End Sub

    Private Sub MMenuLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuLog.Click
        With My.Application.Log.DefaultFileLogWriter
            .Flush()
            OuvrirFichier(.FullLogFileName)
        End With
    End Sub

    Private Sub AfficherLaConfigurationDesExploitationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfficherLaConfigurationDesExploitationsToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        Try
            OuvrirFichier(Exploitation.CheminFichier, "Edit")
        Catch ex As Exception
            'Pas de verbe Edit => 
            Try
                OuvrirFichier(Exploitation.CheminFichier)
            Catch
                'Pas d'application associée
                Process.Start("notepad.exe", Exploitation.CheminFichier)
            End Try
        End Try

    End Sub

    Private Sub OuvrirLeRépertoireDapplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeRépertoireDapplicationToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier(AppDirPath)
    End Sub

    Private Sub OuvrirLeRépertoireDeDonnéesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeRépertoireDeDonnéesToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier(My.Application.GetAppDataPath)
    End Sub

    Private Sub OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier(My.Settings.CheminBase)
    End Sub

    Private Sub OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier(My.Settings.CheminBaseConfig)
    End Sub

    Private Sub OuvrirBDDBaremesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirBDDBaremesToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier(GetDataSource(My.Settings.BaremesConnectionString))
    End Sub

    Private Sub UtilitaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilitaireToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        OuvrirFichier("UtilitaireAccess.exe", , String.Format("-file=""{0}""", My.Settings.CheminBase))
    End Sub

    Private Sub VérifierLaCohérenceTVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VérifierLaCohérenceTVAToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.VerifierCoherenceTVA()
    End Sub

    Private Sub SupprimerLesComptesHorsPLCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerLesComptesHorsPLCToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.SupprimerComptesHorsPLC()
    End Sub

    Private Sub SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.SupprimerComptesNonMouvementes()
    End Sub

    Private Sub MettreÀJourLesLibellésDuPLCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MettreÀJourLesLibellésDuPLCToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.MettreAJourLibellePLC()
    End Sub

    Private Sub ChercherLesPiècesDéséquilibréesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChercherLesPiècesDéséquilibréesToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.VerifPiecesDesequilibrees()
    End Sub

    Private Sub VérifierLéquilibreDuRésultatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VérifierLéquilibreDuRésultatToolStripMenuItem.Click
        If Not FrPassCloture.VerifAdmin Then Exit Sub
        DebugMethods.VerifResultat()
    End Sub
#End Region

#Region "Aide"

    Private Sub MMenuAide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuAide.Click
        OuvrirFichier("aide.pdf")
    End Sub

    Private Sub MMenuActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuActivation.Click
        My.Settings.Cle = Demarrage.LectureCleActivation(True)
    End Sub

    Private Sub MMenuAPropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMenuAPropos.Click
        Call New AboutBox().ShowDialog()
    End Sub

#End Region

#End Region

End Class

Public Interface IPrechargement
    Function Precharger(ByVal AvancedOption As Boolean) As Boolean
End Interface

Public Interface IMenu
    Event MenuItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs)
End Interface
