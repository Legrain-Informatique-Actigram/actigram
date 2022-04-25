<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.MMenuGeneral = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuChangerExpl = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuChangerDossier = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.MMenuSauvegarder = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuRestaurer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MMenuQuitter = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuParam = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuParametrage = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.MotDePasseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.MMenuAssistantPlanC = New System.Windows.Forms.ToolStripMenuItem
        Me.AssistantCréationDeModèlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ConfigurerPlanTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.JournauxPlanTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TVAPlanTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComptesPlanTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.SelectionnerBDDBaremesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererBaremeMaterielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererBaremeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererMaterielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererTypesMaterielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererBaremeForfaitaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GererFaçonsCulturalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MethodeEvaluationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ConfigurerAnnexesTiersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.SessionNetViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuSAV = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuLog = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuLancerInter = New System.Windows.Forms.ToolStripMenuItem
        Me.DonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirBDDBaremesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UtilitaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChercherLesPiècesDéséquilibréesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VérifierLéquilibreDuRésultatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VérifierLaCohérenceTVAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerLesComptesHorsPLCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MettreÀJourLesLibellésDuPLCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuAide = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuActivation = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuAPropos = New System.Windows.Forms.ToolStripMenuItem
        Me.AscendSidebar1 = New AgrigestEDI.GestionMenu.AscendSidebar
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMenuGeneral, Me.MMenuParam, Me.MMenuMaintenance, Me.MMenuOptions})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(736, 24)
        Me.MenuStrip2.TabIndex = 9
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'MMenuGeneral
        '
        Me.MMenuGeneral.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMenuChangerExpl, Me.MMenuChangerDossier, Me.ToolStripSeparator2, Me.MMenuSauvegarder, Me.MMenuRestaurer, Me.ToolStripSeparator1, Me.MMenuQuitter})
        Me.MMenuGeneral.Name = "MMenuGeneral"
        Me.MMenuGeneral.Size = New System.Drawing.Size(59, 20)
        Me.MMenuGeneral.Text = "Général"
        '
        'MMenuChangerExpl
        '
        Me.MMenuChangerExpl.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.MMenuChangerExpl.Name = "MMenuChangerExpl"
        Me.MMenuChangerExpl.Size = New System.Drawing.Size(218, 22)
        Me.MMenuChangerExpl.Text = "Changer d'exploitation..."
        '
        'MMenuChangerDossier
        '
        Me.MMenuChangerDossier.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.MMenuChangerDossier.Name = "MMenuChangerDossier"
        Me.MMenuChangerDossier.Size = New System.Drawing.Size(218, 22)
        Me.MMenuChangerDossier.Text = "Changer d'exercice..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(215, 6)
        '
        'MMenuSauvegarder
        '
        Me.MMenuSauvegarder.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.MMenuSauvegarder.Name = "MMenuSauvegarder"
        Me.MMenuSauvegarder.Size = New System.Drawing.Size(218, 22)
        Me.MMenuSauvegarder.Text = "Sauvegarder..."
        '
        'MMenuRestaurer
        '
        Me.MMenuRestaurer.Image = Global.AgrigestEDI.My.Resources.Resources.restore
        Me.MMenuRestaurer.Name = "MMenuRestaurer"
        Me.MMenuRestaurer.Size = New System.Drawing.Size(218, 22)
        Me.MMenuRestaurer.Text = "Restaurer une sauvegarde..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(215, 6)
        '
        'MMenuQuitter
        '
        Me.MMenuQuitter.Name = "MMenuQuitter"
        Me.MMenuQuitter.Size = New System.Drawing.Size(218, 22)
        Me.MMenuQuitter.Text = "Quitter"
        '
        'MMenuParam
        '
        Me.MMenuParam.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMenuParametrage, Me.ToolStripSeparator3, Me.MotDePasseToolStripMenuItem, Me.ToolStripSeparator6, Me.MMenuAssistantPlanC, Me.AssistantCréationDeModèlesToolStripMenuItem, Me.ToolStripSeparator4, Me.ConfigurerPlanTypeToolStripMenuItem, Me.ToolStripSeparator7, Me.SelectionnerBDDBaremesToolStripMenuItem, Me.GererBaremeMaterielToolStripMenuItem, Me.GérerLeBarèmeForfaitaireToolStripMenuItem, Me.MethodeEvaluationToolStripMenuItem, Me.ToolStripSeparator5, Me.ConfigurerAnnexesTiersToolStripMenuItem})
        Me.MMenuParam.Name = "MMenuParam"
        Me.MMenuParam.Size = New System.Drawing.Size(86, 20)
        Me.MMenuParam.Text = "Paramétrage"
        '
        'MMenuParametrage
        '
        Me.MMenuParametrage.Image = Global.AgrigestEDI.My.Resources.Resources.outils
        Me.MMenuParametrage.Name = "MMenuParametrage"
        Me.MMenuParametrage.Size = New System.Drawing.Size(320, 22)
        Me.MMenuParametrage.Text = "Paramètres..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(317, 6)
        '
        'MotDePasseToolStripMenuItem
        '
        Me.MotDePasseToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.GetPermission
        Me.MotDePasseToolStripMenuItem.Name = "MotDePasseToolStripMenuItem"
        Me.MotDePasseToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.MotDePasseToolStripMenuItem.Text = "Mot de passe..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(317, 6)
        '
        'MMenuAssistantPlanC
        '
        Me.MMenuAssistantPlanC.Image = Global.AgrigestEDI.My.Resources.Resources.NewReportHS
        Me.MMenuAssistantPlanC.Name = "MMenuAssistantPlanC"
        Me.MMenuAssistantPlanC.Size = New System.Drawing.Size(320, 22)
        Me.MMenuAssistantPlanC.Text = "Assistant création plan comptable..."
        '
        'AssistantCréationDeModèlesToolStripMenuItem
        '
        Me.AssistantCréationDeModèlesToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.NewReportHS
        Me.AssistantCréationDeModèlesToolStripMenuItem.Name = "AssistantCréationDeModèlesToolStripMenuItem"
        Me.AssistantCréationDeModèlesToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.AssistantCréationDeModèlesToolStripMenuItem.Text = "Assistant création de modèles..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(317, 6)
        '
        'ConfigurerPlanTypeToolStripMenuItem
        '
        Me.ConfigurerPlanTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JournauxPlanTypeToolStripMenuItem, Me.TVAPlanTypeToolStripMenuItem, Me.ComptesPlanTypeToolStripMenuItem})
        Me.ConfigurerPlanTypeToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.Book_StackOfReportsHS
        Me.ConfigurerPlanTypeToolStripMenuItem.Name = "ConfigurerPlanTypeToolStripMenuItem"
        Me.ConfigurerPlanTypeToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.ConfigurerPlanTypeToolStripMenuItem.Text = "Configurer le plan type"
        '
        'JournauxPlanTypeToolStripMenuItem
        '
        Me.JournauxPlanTypeToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.Book_StackOfReportsHS
        Me.JournauxPlanTypeToolStripMenuItem.Name = "JournauxPlanTypeToolStripMenuItem"
        Me.JournauxPlanTypeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.JournauxPlanTypeToolStripMenuItem.Text = "Journaux"
        '
        'TVAPlanTypeToolStripMenuItem
        '
        Me.TVAPlanTypeToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.Book_StackOfReportsHS
        Me.TVAPlanTypeToolStripMenuItem.Name = "TVAPlanTypeToolStripMenuItem"
        Me.TVAPlanTypeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TVAPlanTypeToolStripMenuItem.Text = "TVA"
        '
        'ComptesPlanTypeToolStripMenuItem
        '
        Me.ComptesPlanTypeToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.Book_StackOfReportsHS
        Me.ComptesPlanTypeToolStripMenuItem.Name = "ComptesPlanTypeToolStripMenuItem"
        Me.ComptesPlanTypeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ComptesPlanTypeToolStripMenuItem.Text = "Comptes"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(317, 6)
        '
        'SelectionnerBDDBaremesToolStripMenuItem
        '
        Me.SelectionnerBDDBaremesToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.database
        Me.SelectionnerBDDBaremesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.SelectionnerBDDBaremesToolStripMenuItem.Name = "SelectionnerBDDBaremesToolStripMenuItem"
        Me.SelectionnerBDDBaremesToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.SelectionnerBDDBaremesToolStripMenuItem.Text = "Sélectionner la base de données des barèmes..."
        Me.SelectionnerBDDBaremesToolStripMenuItem.ToolTipText = "Sélectionner la base de données des barèmes..."
        '
        'GererBaremeMaterielToolStripMenuItem
        '
        Me.GererBaremeMaterielToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GererBaremeToolStripMenuItem, Me.GererMaterielToolStripMenuItem, Me.GererTypesMaterielToolStripMenuItem})
        Me.GererBaremeMaterielToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.GererBaremeMaterielToolStripMenuItem.Name = "GererBaremeMaterielToolStripMenuItem"
        Me.GererBaremeMaterielToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.GererBaremeMaterielToolStripMenuItem.Text = "Gérer le barème du matériel"
        Me.GererBaremeMaterielToolStripMenuItem.ToolTipText = "Gérer le barème du matériel"
        '
        'GererBaremeToolStripMenuItem
        '
        Me.GererBaremeToolStripMenuItem.Name = "GererBaremeToolStripMenuItem"
        Me.GererBaremeToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.GererBaremeToolStripMenuItem.Text = "Gérer le barème..."
        Me.GererBaremeToolStripMenuItem.ToolTipText = "Gérer le barème"
        '
        'GererMaterielToolStripMenuItem
        '
        Me.GererMaterielToolStripMenuItem.Name = "GererMaterielToolStripMenuItem"
        Me.GererMaterielToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.GererMaterielToolStripMenuItem.Text = "Gérer le métériel..."
        Me.GererMaterielToolStripMenuItem.ToolTipText = "Gérer le métériel"
        '
        'GererTypesMaterielToolStripMenuItem
        '
        Me.GererTypesMaterielToolStripMenuItem.Name = "GererTypesMaterielToolStripMenuItem"
        Me.GererTypesMaterielToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.GererTypesMaterielToolStripMenuItem.Text = "Gérer les types de matériel..."
        Me.GererTypesMaterielToolStripMenuItem.ToolTipText = "Gérer les types de matériel"
        '
        'GérerLeBarèmeForfaitaireToolStripMenuItem
        '
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GererBaremeForfaitaireToolStripMenuItem, Me.GererFaçonsCulturalesToolStripMenuItem})
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.Name = "GérerLeBarèmeForfaitaireToolStripMenuItem"
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.Text = "Gérer le barème forfaitaire"
        Me.GérerLeBarèmeForfaitaireToolStripMenuItem.ToolTipText = "Gérer le barème forfaitaire"
        '
        'GererBaremeForfaitaireToolStripMenuItem
        '
        Me.GererBaremeForfaitaireToolStripMenuItem.Name = "GererBaremeForfaitaireToolStripMenuItem"
        Me.GererBaremeForfaitaireToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.GererBaremeForfaitaireToolStripMenuItem.Text = "Gérer le barème forfaitaire..."
        Me.GererBaremeForfaitaireToolStripMenuItem.ToolTipText = "Gérer le barème forfaitaire..."
        '
        'GererFaçonsCulturalesToolStripMenuItem
        '
        Me.GererFaçonsCulturalesToolStripMenuItem.Name = "GererFaçonsCulturalesToolStripMenuItem"
        Me.GererFaçonsCulturalesToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.GererFaçonsCulturalesToolStripMenuItem.Text = "Gérer les façons culturales..."
        Me.GererFaçonsCulturalesToolStripMenuItem.ToolTipText = "Gérer les façons culturales..."
        '
        'MethodeEvaluationToolStripMenuItem
        '
        Me.MethodeEvaluationToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.calc
        Me.MethodeEvaluationToolStripMenuItem.Name = "MethodeEvaluationToolStripMenuItem"
        Me.MethodeEvaluationToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.MethodeEvaluationToolStripMenuItem.Text = "Méthode d'évaluation..."
        Me.MethodeEvaluationToolStripMenuItem.ToolTipText = "Méthode d'évaluation des avances aux cultures"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(317, 6)
        '
        'ConfigurerAnnexesTiersToolStripMenuItem
        '
        Me.ConfigurerAnnexesTiersToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.outils
        Me.ConfigurerAnnexesTiersToolStripMenuItem.Name = "ConfigurerAnnexesTiersToolStripMenuItem"
        Me.ConfigurerAnnexesTiersToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.ConfigurerAnnexesTiersToolStripMenuItem.Text = "Configurer les annexes de tiers..."
        Me.ConfigurerAnnexesTiersToolStripMenuItem.ToolTipText = "Configurer les annexes de tiers..."
        '
        'MMenuMaintenance
        '
        Me.MMenuMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SessionNetViewerToolStripMenuItem, Me.MMenuSAV, Me.MMenuLog, Me.MMenuLancerInter, Me.DonnéesToolStripMenuItem})
        Me.MMenuMaintenance.Name = "MMenuMaintenance"
        Me.MMenuMaintenance.Size = New System.Drawing.Size(88, 20)
        Me.MMenuMaintenance.Text = "Maintenance"
        '
        'SessionNetViewerToolStripMenuItem
        '
        Me.SessionNetViewerToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.netviewer16
        Me.SessionNetViewerToolStripMenuItem.Name = "SessionNetViewerToolStripMenuItem"
        Me.SessionNetViewerToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.SessionNetViewerToolStripMenuItem.Text = "Session NetViewer..."
        '
        'MMenuSAV
        '
        Me.MMenuSAV.Image = Global.AgrigestEDI.My.Resources.Resources.tel
        Me.MMenuSAV.Name = "MMenuSAV"
        Me.MMenuSAV.Size = New System.Drawing.Size(264, 22)
        Me.MMenuSAV.Text = "Consulter les coordonnées du SAV..."
        '
        'MMenuLog
        '
        Me.MMenuLog.Image = Global.AgrigestEDI.My.Resources.Resources.log
        Me.MMenuLog.Name = "MMenuLog"
        Me.MMenuLog.Size = New System.Drawing.Size(264, 22)
        Me.MMenuLog.Text = "Afficher le fichier log..."
        '
        'MMenuLancerInter
        '
        Me.MMenuLancerInter.Image = Global.AgrigestEDI.My.Resources.Resources.ultravnc
        Me.MMenuLancerInter.Name = "MMenuLancerInter"
        Me.MMenuLancerInter.Size = New System.Drawing.Size(264, 22)
        Me.MMenuLancerInter.Text = "Lancer la téléintervention..."
        '
        'DonnéesToolStripMenuItem
        '
        Me.DonnéesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem, Me.OuvrirLeRépertoireDapplicationToolStripMenuItem, Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem, Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem, Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem, Me.OuvrirBDDBaremesToolStripMenuItem, Me.UtilitaireToolStripMenuItem, Me.DebugToolStripMenuItem})
        Me.DonnéesToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.database
        Me.DonnéesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.DonnéesToolStripMenuItem.Name = "DonnéesToolStripMenuItem"
        Me.DonnéesToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.DonnéesToolStripMenuItem.Text = "Données"
        '
        'AfficherLaConfigurationDesExploitationsToolStripMenuItem
        '
        Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.copy
        Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem.Name = "AfficherLaConfigurationDesExploitationsToolStripMenuItem"
        Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.AfficherLaConfigurationDesExploitationsToolStripMenuItem.Text = "Afficher la configuration des exploitations..."
        '
        'OuvrirLeRépertoireDapplicationToolStripMenuItem
        '
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Name = "OuvrirLeRépertoireDapplicationToolStripMenuItem"
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Text = "Ouvrir le répertoire d'application..."
        '
        'OuvrirLeRépertoireDeDonnéesToolStripMenuItem
        '
        Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem.Name = "OuvrirLeRépertoireDeDonnéesToolStripMenuItem"
        Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.OuvrirLeRépertoireDeDonnéesToolStripMenuItem.Text = "Ouvrir le répertoire de données..."
        '
        'OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem
        '
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.database
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Name = "OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem"
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Text = "Ouvrir la base de données en cours..."
        '
        'OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem
        '
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.database
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.Name = "OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem"
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem.Text = "Ouvrir la base de plan type en cours..."
        '
        'OuvrirBDDBaremesToolStripMenuItem
        '
        Me.OuvrirBDDBaremesToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.database
        Me.OuvrirBDDBaremesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.OuvrirBDDBaremesToolStripMenuItem.Name = "OuvrirBDDBaremesToolStripMenuItem"
        Me.OuvrirBDDBaremesToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.OuvrirBDDBaremesToolStripMenuItem.Text = "Ouvrir la base de données des barèmes..."
        '
        'UtilitaireToolStripMenuItem
        '
        Me.UtilitaireToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.icone_util16
        Me.UtilitaireToolStripMenuItem.Name = "UtilitaireToolStripMenuItem"
        Me.UtilitaireToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.UtilitaireToolStripMenuItem.Text = "Utilitaire..."
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChercherLesPiècesDéséquilibréesToolStripMenuItem, Me.VérifierLéquilibreDuRésultatToolStripMenuItem, Me.VérifierLaCohérenceTVAToolStripMenuItem, Me.SupprimerLesComptesHorsPLCToolStripMenuItem, Me.SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem, Me.MettreÀJourLesLibellésDuPLCToolStripMenuItem})
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.DebugToolStripMenuItem.Text = "Maintenance avancée"
        '
        'ChercherLesPiècesDéséquilibréesToolStripMenuItem
        '
        Me.ChercherLesPiècesDéséquilibréesToolStripMenuItem.Name = "ChercherLesPiècesDéséquilibréesToolStripMenuItem"
        Me.ChercherLesPiècesDéséquilibréesToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.ChercherLesPiècesDéséquilibréesToolStripMenuItem.Text = "Chercher les pièces déséquilibrées"
        '
        'VérifierLéquilibreDuRésultatToolStripMenuItem
        '
        Me.VérifierLéquilibreDuRésultatToolStripMenuItem.Name = "VérifierLéquilibreDuRésultatToolStripMenuItem"
        Me.VérifierLéquilibreDuRésultatToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.VérifierLéquilibreDuRésultatToolStripMenuItem.Text = "Vérifier l'équilibre du résultat"
        '
        'VérifierLaCohérenceTVAToolStripMenuItem
        '
        Me.VérifierLaCohérenceTVAToolStripMenuItem.Name = "VérifierLaCohérenceTVAToolStripMenuItem"
        Me.VérifierLaCohérenceTVAToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.VérifierLaCohérenceTVAToolStripMenuItem.Text = "Vérifier la cohérence TVA"
        '
        'SupprimerLesComptesHorsPLCToolStripMenuItem
        '
        Me.SupprimerLesComptesHorsPLCToolStripMenuItem.Name = "SupprimerLesComptesHorsPLCToolStripMenuItem"
        Me.SupprimerLesComptesHorsPLCToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.SupprimerLesComptesHorsPLCToolStripMenuItem.Text = "Supprimer les comptes hors PLC"
        '
        'SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem
        '
        Me.SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem.Name = "SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem"
        Me.SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem.Text = "Supprimer les comptes du PLC non mouvementés"
        '
        'MettreÀJourLesLibellésDuPLCToolStripMenuItem
        '
        Me.MettreÀJourLesLibellésDuPLCToolStripMenuItem.Name = "MettreÀJourLesLibellésDuPLCToolStripMenuItem"
        Me.MettreÀJourLesLibellésDuPLCToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.MettreÀJourLesLibellésDuPLCToolStripMenuItem.Text = "Mettre à jour les libellés du PLC"
        '
        'MMenuOptions
        '
        Me.MMenuOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MMenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMenuAide, Me.MMenuActivation, Me.MMenuAPropos})
        Me.MMenuOptions.Name = "MMenuOptions"
        Me.MMenuOptions.ShowShortcutKeys = False
        Me.MMenuOptions.Size = New System.Drawing.Size(24, 20)
        Me.MMenuOptions.Text = "?"
        Me.MMenuOptions.ToolTipText = "Aide"
        '
        'MMenuAide
        '
        Me.MMenuAide.Image = Global.AgrigestEDI.My.Resources.Resources.aide
        Me.MMenuAide.Name = "MMenuAide"
        Me.MMenuAide.Size = New System.Drawing.Size(173, 22)
        Me.MMenuAide.Text = "Consulter l'aide..."
        '
        'MMenuActivation
        '
        Me.MMenuActivation.Image = Global.AgrigestEDI.My.Resources.Resources.cle
        Me.MMenuActivation.Name = "MMenuActivation"
        Me.MMenuActivation.Size = New System.Drawing.Size(173, 22)
        Me.MMenuActivation.Text = "Activer le logiciel..."
        '
        'MMenuAPropos
        '
        Me.MMenuAPropos.Name = "MMenuAPropos"
        Me.MMenuAPropos.Size = New System.Drawing.Size(173, 22)
        Me.MMenuAPropos.Text = "A propos..."
        '
        'AscendSidebar1
        '
        Me.AscendSidebar1.BackColor = System.Drawing.SystemColors.Control
        Me.AscendSidebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AscendSidebar1.Location = New System.Drawing.Point(0, 24)
        Me.AscendSidebar1.Menus = Nothing
        Me.AscendSidebar1.Name = "AscendSidebar1"
        Me.AscendSidebar1.Size = New System.Drawing.Size(210, 504)
        Me.AscendSidebar1.TabIndex = 11
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 528)
        Me.Controls.Add(Me.AscendSidebar1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents MMenuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuAPropos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuActivation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuChangerDossier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuSauvegarder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuRestaurer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuQuitter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuParam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuParametrage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuAssistantPlanC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuLancerInter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuSAV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuAide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuChangerExpl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DonnéesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfficherLaConfigurationDesExploitationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLeRépertoireDapplicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLeRépertoireDeDonnéesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLaBaseDePlanTypeEnCoursToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssistantCréationDeModèlesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AscendSidebar1 As AgrigestEDI.GestionMenu.AscendSidebar
    Friend WithEvents SessionNetViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtilitaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VérifierLaCohérenceTVAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerLesComptesHorsPLCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerLesComptesDuPLCNonMouvementésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChercherLesPiècesDéséquilibréesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VérifierLéquilibreDuRésultatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MettreÀJourLesLibellésDuPLCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectionnerBDDBaremesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirBDDBaremesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererBaremeMaterielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererBaremeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererMaterielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererTypesMaterielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GérerLeBarèmeForfaitaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererBaremeForfaitaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GererFaçonsCulturalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurerAnnexesTiersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MethodeEvaluationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MotDePasseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConfigurerPlanTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournauxPlanTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TVAPlanTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComptesPlanTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
