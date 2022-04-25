Public Class FrTableauBord
    Inherits GRC.FrBase
    Dim strFiltre As String = ""
    Dim nEntite As String = ""
    Dim strTypeEntite As String = ""
    Friend WithEvents npPlanning As Ascend.Windows.Forms.NavigationPane
    Friend WithEvents NavigationPanePage1 As Ascend.Windows.Forms.NavigationPanePage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Dim FiltreDepart As String = ""

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub


    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lbPanierMoyen As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbJour As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSemaine As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbMois As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LbVentes As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents LbAchats As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents LbFréquentations As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents TbImprimerJour As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SousFamilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourSousFamilleFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourSousFamilleFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FamilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourFamilleSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatJourFamilleSousFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbImprimerSemaine As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineSousFamilleFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineSousFamilleFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineFamilleSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatSemaineFamilleSousFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbImprimerMois As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisSousFamilleFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisSousFamilleFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisFamilleSousFamille As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtatMoisFamilleSousFamillePLU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Graphique1 As Actigram.Windows.Forms.Indicateurs.Graphique
    Friend WithEvents Graphique2 As Actigram.Windows.Forms.Indicateurs.Graphique
    Friend WithEvents Graphique3 As Actigram.Windows.Forms.Indicateurs.Graphique
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrTableauBord))
        Me.Graphique1 = New Actigram.Windows.Forms.Indicateurs.Graphique
        Me.Graphique2 = New Actigram.Windows.Forms.Indicateurs.Graphique
        Me.Graphique3 = New Actigram.Windows.Forms.Indicateurs.Graphique
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.lbPanierMoyen = New System.Windows.Forms.ToolStripLabel
        Me.TbJour = New System.Windows.Forms.ToolStripButton
        Me.TbSemaine = New System.Windows.Forms.ToolStripButton
        Me.TbMois = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprimerJour = New System.Windows.Forms.ToolStripSplitButton
        Me.SousFamilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourSousFamilleFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourSousFamilleFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.FamilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourFamilleSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatJourFamilleSousFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.TbImprimerSemaine = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineSousFamilleFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineSousFamilleFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineFamilleSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatSemaineFamilleSousFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.TbImprimerMois = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisSousFamilleFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisSousFamilleFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisFamilleSousFamille = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuEtatMoisFamilleSousFamillePLU = New System.Windows.Forms.ToolStripMenuItem
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.LbAchats = New Ascend.Windows.Forms.GradientCaption
        Me.LbFréquentations = New Ascend.Windows.Forms.GradientCaption
        Me.LbVentes = New Ascend.Windows.Forms.GradientCaption
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.npPlanning = New Ascend.Windows.Forms.NavigationPane
        Me.NavigationPanePage1 = New Ascend.Windows.Forms.NavigationPanePage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.npPlanning.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.Images.SetKeyName(0, "")
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList32.Images.SetKeyName(0, "")
        Me.ImageList32.Images.SetKeyName(1, "")
        Me.ImageList32.Images.SetKeyName(2, "")
        Me.ImageList32.Images.SetKeyName(3, "")
        Me.ImageList32.Images.SetKeyName(4, "")
        Me.ImageList32.Images.SetKeyName(5, "")
        Me.ImageList32.Images.SetKeyName(6, "")
        Me.ImageList32.Images.SetKeyName(7, "")
        Me.ImageList32.Images.SetKeyName(8, "")
        Me.ImageList32.Images.SetKeyName(9, "")
        Me.ImageList32.Images.SetKeyName(10, "")
        Me.ImageList32.Images.SetKeyName(11, "")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.Images.SetKeyName(0, "")
        Me.ImageList24.Images.SetKeyName(1, "")
        Me.ImageList24.Images.SetKeyName(2, "")
        Me.ImageList24.Images.SetKeyName(3, "")
        Me.ImageList24.Images.SetKeyName(4, "")
        Me.ImageList24.Images.SetKeyName(5, "")
        Me.ImageList24.Images.SetKeyName(6, "")
        Me.ImageList24.Images.SetKeyName(7, "")
        Me.ImageList24.Images.SetKeyName(8, "")
        Me.ImageList24.Images.SetKeyName(9, "")
        Me.ImageList24.Images.SetKeyName(10, "")
        Me.ImageList24.Images.SetKeyName(11, "")
        Me.ImageList24.Images.SetKeyName(12, "")
        Me.ImageList24.Images.SetKeyName(13, "")
        '
        'Graphique1
        '
        Me.Graphique1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graphique1.BackColor = System.Drawing.Color.White
        Me.Graphique1.EspaceLegendeX = 20
        Me.Graphique1.EspaceLegendeY = 29
        Me.Graphique1.GraphBackColor = System.Drawing.Color.White
        Me.Graphique1.IntervaleBarre = 10
        Me.Graphique1.IntervaleBarreIntraSerie = 0
        Me.Graphique1.LargeurBarre = 25
        Me.Graphique1.LegendeUnite = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Graphique1.LegendeXBackColor = System.Drawing.Color.White
        Me.Graphique1.LegendeYBackColor = System.Drawing.Color.White
        Me.Graphique1.Location = New System.Drawing.Point(7, 384)
        Me.Graphique1.Name = "Graphique1"
        Me.Graphique1.NbSerie = 1
        Me.Graphique1.RefreshAuto = True
        Me.Graphique1.Size = New System.Drawing.Size(257, 144)
        Me.Graphique1.TabIndex = 0
        Me.Graphique1.Text = "Graphique1"
        Me.Graphique1.ValeurMax = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Graphique1.ValeurMin = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Graphique2
        '
        Me.Graphique2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graphique2.BackColor = System.Drawing.Color.White
        Me.Graphique2.EspaceLegendeX = 20
        Me.Graphique2.EspaceLegendeY = 29
        Me.Graphique2.GraphBackColor = System.Drawing.Color.White
        Me.Graphique2.IntervaleBarre = 10
        Me.Graphique2.IntervaleBarreIntraSerie = 10
        Me.Graphique2.LargeurBarre = 25
        Me.Graphique2.LegendeUnite = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Graphique2.LegendeXBackColor = System.Drawing.Color.White
        Me.Graphique2.LegendeYBackColor = System.Drawing.Color.White
        Me.Graphique2.Location = New System.Drawing.Point(7, 50)
        Me.Graphique2.Name = "Graphique2"
        Me.Graphique2.NbSerie = 1
        Me.Graphique2.RefreshAuto = True
        Me.Graphique2.Size = New System.Drawing.Size(257, 144)
        Me.Graphique2.TabIndex = 2
        Me.Graphique2.Text = "Graphique2"
        Me.Graphique2.ValeurMax = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Graphique2.ValeurMin = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Graphique3
        '
        Me.Graphique3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graphique3.BackColor = System.Drawing.Color.White
        Me.Graphique3.EspaceLegendeX = 20
        Me.Graphique3.EspaceLegendeY = 29
        Me.Graphique3.GraphBackColor = System.Drawing.Color.White
        Me.Graphique3.IntervaleBarre = 10
        Me.Graphique3.IntervaleBarreIntraSerie = 0
        Me.Graphique3.LargeurBarre = 25
        Me.Graphique3.LegendeUnite = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Graphique3.LegendeXBackColor = System.Drawing.Color.White
        Me.Graphique3.LegendeYBackColor = System.Drawing.Color.White
        Me.Graphique3.Location = New System.Drawing.Point(7, 217)
        Me.Graphique3.Name = "Graphique3"
        Me.Graphique3.NbSerie = 1
        Me.Graphique3.RefreshAuto = True
        Me.Graphique3.Size = New System.Drawing.Size(257, 144)
        Me.Graphique3.TabIndex = 7
        Me.Graphique3.Text = "Graphique3"
        Me.Graphique3.ValeurMax = New Decimal(New Integer() {30, 0, 0, 0})
        Me.Graphique3.ValeurMin = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(3, 1)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(95, 20)
        Me.dtDate.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFermer, Me.lbPanierMoyen, Me.TbJour, Me.TbSemaine, Me.TbMois, Me.ToolStripSeparator1, Me.TbImprimerJour, Me.TbImprimerSemaine, Me.TbImprimerMois})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(760, 49)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 46)
        Me.TbFermer.Text = "Fermer"
        '
        'lbPanierMoyen
        '
        Me.lbPanierMoyen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbPanierMoyen.Name = "lbPanierMoyen"
        Me.lbPanierMoyen.Size = New System.Drawing.Size(87, 46)
        Me.lbPanierMoyen.Text = "lbPanierMoyen"
        '
        'TbJour
        '
        Me.TbJour.Checked = True
        Me.TbJour.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbJour.Image = Global.AgriFact.My.Resources.Resources.Agenda
        Me.TbJour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbJour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbJour.Name = "TbJour"
        Me.TbJour.Size = New System.Drawing.Size(33, 46)
        Me.TbJour.Text = "Jour"
        Me.TbJour.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TbSemaine
        '
        Me.TbSemaine.Image = Global.AgriFact.My.Resources.Resources.Agenda
        Me.TbSemaine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSemaine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSemaine.Name = "TbSemaine"
        Me.TbSemaine.Size = New System.Drawing.Size(56, 46)
        Me.TbSemaine.Text = "Semaine"
        Me.TbSemaine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TbMois
        '
        Me.TbMois.Image = Global.AgriFact.My.Resources.Resources.Agenda
        Me.TbMois.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbMois.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMois.Name = "TbMois"
        Me.TbMois.Size = New System.Drawing.Size(37, 46)
        Me.TbMois.Text = "Mois"
        Me.TbMois.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 49)
        '
        'TbImprimerJour
        '
        Me.TbImprimerJour.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SousFamilleToolStripMenuItem, Me.FamilleToolStripMenuItem})
        Me.TbImprimerJour.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimerJour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimerJour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimerJour.Name = "TbImprimerJour"
        Me.TbImprimerJour.Size = New System.Drawing.Size(100, 46)
        Me.TbImprimerJour.Text = "Etat Jour"
        '
        'SousFamilleToolStripMenuItem
        '
        Me.SousFamilleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatJourSousFamille, Me.MenuEtatJourSousFamilleFamille, Me.MenuEtatJourSousFamilleFamillePLU})
        Me.SousFamilleToolStripMenuItem.Name = "SousFamilleToolStripMenuItem"
        Me.SousFamilleToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SousFamilleToolStripMenuItem.Text = "par Sous famille"
        '
        'MenuEtatJourSousFamille
        '
        Me.MenuEtatJourSousFamille.Name = "MenuEtatJourSousFamille"
        Me.MenuEtatJourSousFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatJourSousFamille.Text = "par Sous Famille..."
        '
        'MenuEtatJourSousFamilleFamille
        '
        Me.MenuEtatJourSousFamilleFamille.Name = "MenuEtatJourSousFamilleFamille"
        Me.MenuEtatJourSousFamilleFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatJourSousFamilleFamille.Text = "...et par Famille..."
        '
        'MenuEtatJourSousFamilleFamillePLU
        '
        Me.MenuEtatJourSousFamilleFamillePLU.Name = "MenuEtatJourSousFamilleFamillePLU"
        Me.MenuEtatJourSousFamilleFamillePLU.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatJourSousFamilleFamillePLU.Text = "...et par PLU..."
        '
        'FamilleToolStripMenuItem
        '
        Me.FamilleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatJourFamille, Me.MenuEtatJourFamilleSousFamille, Me.MenuEtatJourFamilleSousFamillePLU})
        Me.FamilleToolStripMenuItem.Name = "FamilleToolStripMenuItem"
        Me.FamilleToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FamilleToolStripMenuItem.Text = "par Famille"
        '
        'MenuEtatJourFamille
        '
        Me.MenuEtatJourFamille.Name = "MenuEtatJourFamille"
        Me.MenuEtatJourFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatJourFamille.Text = "par Famille..."
        '
        'MenuEtatJourFamilleSousFamille
        '
        Me.MenuEtatJourFamilleSousFamille.Name = "MenuEtatJourFamilleSousFamille"
        Me.MenuEtatJourFamilleSousFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatJourFamilleSousFamille.Text = "... et par Sous Famille..."
        '
        'MenuEtatJourFamilleSousFamillePLU
        '
        Me.MenuEtatJourFamilleSousFamillePLU.Name = "MenuEtatJourFamilleSousFamillePLU"
        Me.MenuEtatJourFamilleSousFamillePLU.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatJourFamilleSousFamillePLU.Text = "... et par PLU..."
        '
        'TbImprimerSemaine
        '
        Me.TbImprimerSemaine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem5})
        Me.TbImprimerSemaine.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimerSemaine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimerSemaine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimerSemaine.Name = "TbImprimerSemaine"
        Me.TbImprimerSemaine.Size = New System.Drawing.Size(123, 46)
        Me.TbImprimerSemaine.Text = "Etat Semaine"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatSemaineSousFamille, Me.MenuEtatSemaineSousFamilleFamille, Me.MenuEtatSemaineSousFamilleFamillePLU})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem1.Text = "par Sous famille"
        '
        'MenuEtatSemaineSousFamille
        '
        Me.MenuEtatSemaineSousFamille.Name = "MenuEtatSemaineSousFamille"
        Me.MenuEtatSemaineSousFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatSemaineSousFamille.Text = "par Sous Famille..."
        '
        'MenuEtatSemaineSousFamilleFamille
        '
        Me.MenuEtatSemaineSousFamilleFamille.Name = "MenuEtatSemaineSousFamilleFamille"
        Me.MenuEtatSemaineSousFamilleFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatSemaineSousFamilleFamille.Text = "...et par Famille..."
        '
        'MenuEtatSemaineSousFamilleFamillePLU
        '
        Me.MenuEtatSemaineSousFamilleFamillePLU.Name = "MenuEtatSemaineSousFamilleFamillePLU"
        Me.MenuEtatSemaineSousFamilleFamillePLU.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatSemaineSousFamilleFamillePLU.Text = "...et par PLU..."
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatSemaineFamille, Me.MenuEtatSemaineFamilleSousFamille, Me.MenuEtatSemaineFamilleSousFamillePLU})
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem5.Text = "par Famille"
        '
        'MenuEtatSemaineFamille
        '
        Me.MenuEtatSemaineFamille.Name = "MenuEtatSemaineFamille"
        Me.MenuEtatSemaineFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatSemaineFamille.Text = "par Famille..."
        '
        'MenuEtatSemaineFamilleSousFamille
        '
        Me.MenuEtatSemaineFamilleSousFamille.Name = "MenuEtatSemaineFamilleSousFamille"
        Me.MenuEtatSemaineFamilleSousFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatSemaineFamilleSousFamille.Text = "... et par Sous Famille..."
        '
        'MenuEtatSemaineFamilleSousFamillePLU
        '
        Me.MenuEtatSemaineFamilleSousFamillePLU.Name = "MenuEtatSemaineFamilleSousFamillePLU"
        Me.MenuEtatSemaineFamilleSousFamillePLU.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatSemaineFamilleSousFamillePLU.Text = "... et par PLU..."
        '
        'TbImprimerMois
        '
        Me.TbImprimerMois.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9, Me.ToolStripMenuItem13})
        Me.TbImprimerMois.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimerMois.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimerMois.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimerMois.Name = "TbImprimerMois"
        Me.TbImprimerMois.Size = New System.Drawing.Size(104, 46)
        Me.TbImprimerMois.Text = "Etat Mois"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatMoisSousFamille, Me.MenuEtatMoisSousFamilleFamille, Me.MenuEtatMoisSousFamilleFamillePLU})
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem9.Text = "par Sous famille"
        '
        'MenuEtatMoisSousFamille
        '
        Me.MenuEtatMoisSousFamille.Name = "MenuEtatMoisSousFamille"
        Me.MenuEtatMoisSousFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatMoisSousFamille.Text = "par Sous Famille..."
        '
        'MenuEtatMoisSousFamilleFamille
        '
        Me.MenuEtatMoisSousFamilleFamille.Name = "MenuEtatMoisSousFamilleFamille"
        Me.MenuEtatMoisSousFamilleFamille.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatMoisSousFamilleFamille.Text = "...et par Famille..."
        '
        'MenuEtatMoisSousFamilleFamillePLU
        '
        Me.MenuEtatMoisSousFamilleFamillePLU.Name = "MenuEtatMoisSousFamilleFamillePLU"
        Me.MenuEtatMoisSousFamilleFamillePLU.Size = New System.Drawing.Size(169, 22)
        Me.MenuEtatMoisSousFamilleFamillePLU.Text = "...et par PLU..."
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEtatMoisFamille, Me.MenuEtatMoisFamilleSousFamille, Me.MenuEtatMoisFamilleSousFamillePLU})
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem13.Text = "par Famille"
        '
        'MenuEtatMoisFamille
        '
        Me.MenuEtatMoisFamille.Name = "MenuEtatMoisFamille"
        Me.MenuEtatMoisFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatMoisFamille.Text = "par Famille..."
        '
        'MenuEtatMoisFamilleSousFamille
        '
        Me.MenuEtatMoisFamilleSousFamille.Name = "MenuEtatMoisFamilleSousFamille"
        Me.MenuEtatMoisFamilleSousFamille.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatMoisFamilleSousFamille.Text = "... et par Sous Famille..."
        '
        'MenuEtatMoisFamilleSousFamillePLU
        '
        Me.MenuEtatMoisFamilleSousFamillePLU.Name = "MenuEtatMoisFamilleSousFamillePLU"
        Me.MenuEtatMoisFamilleSousFamillePLU.Size = New System.Drawing.Size(194, 22)
        Me.MenuEtatMoisFamilleSousFamillePLU.Text = "... et par PLU..."
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.LbAchats)
        Me.GradientPanel2.Controls.Add(Me.LbFréquentations)
        Me.GradientPanel2.Controls.Add(Me.LbVentes)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.Controls.Add(Me.Graphique1)
        Me.GradientPanel2.Controls.Add(Me.Graphique3)
        Me.GradientPanel2.Controls.Add(Me.Graphique2)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(5, 5)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(267, 523)
        Me.GradientPanel2.TabIndex = 24
        '
        'LbAchats
        '
        Me.LbAchats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbAchats.Border = New Ascend.Border(0, 1, 0, 2)
        Me.LbAchats.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.LbAchats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAchats.ForeColor = System.Drawing.SystemColors.MenuText
        Me.LbAchats.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbAchats.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.LbAchats.Location = New System.Drawing.Point(1, 358)
        Me.LbAchats.Name = "LbAchats"
        Me.LbAchats.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.LbAchats.Size = New System.Drawing.Size(265, 20)
        Me.LbAchats.TabIndex = 11
        Me.LbAchats.Text = "Achats"
        '
        'LbFréquentations
        '
        Me.LbFréquentations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbFréquentations.Border = New Ascend.Border(0, 1, 0, 2)
        Me.LbFréquentations.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.LbFréquentations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbFréquentations.ForeColor = System.Drawing.SystemColors.MenuText
        Me.LbFréquentations.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbFréquentations.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.LbFréquentations.Location = New System.Drawing.Point(1, 191)
        Me.LbFréquentations.Name = "LbFréquentations"
        Me.LbFréquentations.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.LbFréquentations.Size = New System.Drawing.Size(265, 20)
        Me.LbFréquentations.TabIndex = 10
        Me.LbFréquentations.Text = "Fréquentations"
        '
        'LbVentes
        '
        Me.LbVentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbVentes.Border = New Ascend.Border(0, 1, 0, 2)
        Me.LbVentes.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.LbVentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbVentes.ForeColor = System.Drawing.SystemColors.MenuText
        Me.LbVentes.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbVentes.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.LbVentes.Location = New System.Drawing.Point(1, 24)
        Me.LbVentes.Name = "LbVentes"
        Me.LbVentes.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.LbVentes.Size = New System.Drawing.Size(265, 20)
        Me.LbVentes.TabIndex = 9
        Me.LbVentes.Text = "Ventes"
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(267, 24)
        Me.GradientCaption1.TabIndex = 1
        Me.GradientCaption1.Text = "Statistiques"
        '
        'npPlanning
        '
        Me.npPlanning.AllowAddOrRemove = False
        Me.npPlanning.AllowOptions = False
        Me.npPlanning.ButtonActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.npPlanning.ButtonActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.npPlanning.ButtonBorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.npPlanning.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.npPlanning.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.npPlanning.ButtonGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.npPlanning.ButtonGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.npPlanning.ButtonHighlightGradientHighColor = System.Drawing.Color.White
        Me.npPlanning.ButtonHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.npPlanning.CaptionBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.npPlanning.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.npPlanning.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.npPlanning.CaptionGradientHighColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.npPlanning.CaptionGradientLowColor = System.Drawing.SystemColors.ActiveCaption
        Me.npPlanning.CaptionHeight = 30
        Me.npPlanning.CaptionImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.npPlanning.Controls.Add(Me.NavigationPanePage1)
        Me.npPlanning.Cursor = System.Windows.Forms.Cursors.Default
        Me.npPlanning.Dock = System.Windows.Forms.DockStyle.Fill
        Me.npPlanning.FooterGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.npPlanning.FooterGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.npPlanning.FooterHeight = 0
        Me.npPlanning.FooterHighlightGradientHighColor = System.Drawing.Color.White
        Me.npPlanning.FooterHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.npPlanning.ImageInCaption = True
        Me.npPlanning.Location = New System.Drawing.Point(5, 29)
        Me.npPlanning.Name = "npPlanning"
        Me.npPlanning.NavigationPages.AddRange(New Ascend.Windows.Forms.NavigationPanePage() {Me.NavigationPanePage1})
        Me.npPlanning.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.npPlanning.Size = New System.Drawing.Size(469, 499)
        Me.npPlanning.TabIndex = 12
        Me.npPlanning.VisibleButtonCount = 1
        '
        'NavigationPanePage1
        '
        Me.NavigationPanePage1.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage1.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage1.AutoScroll = True
        Me.NavigationPanePage1.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.NavigationPanePage1.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage1.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage1.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage1.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage1.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage1.Image = Nothing
        Me.NavigationPanePage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ImageFooter = Nothing
        Me.NavigationPanePage1.ImageIndex = -1
        Me.NavigationPanePage1.ImageIndexFooter = -1
        Me.NavigationPanePage1.ImageKey = ""
        Me.NavigationPanePage1.ImageKeyFooter = ""
        Me.NavigationPanePage1.ImageList = Nothing
        Me.NavigationPanePage1.ImageListFooter = Nothing
        Me.NavigationPanePage1.Key = "NavigationPanePage1"
        Me.NavigationPanePage1.Location = New System.Drawing.Point(1, 27)
        Me.NavigationPanePage1.Name = "NavigationPanePage1"
        Me.NavigationPanePage1.Size = New System.Drawing.Size(467, 432)
        Me.NavigationPanePage1.TabIndex = 0
        Me.NavigationPanePage1.Text = "NavigationPanePage1"
        Me.NavigationPanePage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ToolTipText = Nothing
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.npPlanning)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GradientPanel2)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Size = New System.Drawing.Size(760, 533)
        Me.SplitContainer1.SplitterDistance = 479
        Me.SplitContainer1.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 24)
        Me.Panel1.TabIndex = 0
        '
        'FrTableauBord
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(760, 582)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrTableauBord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tableau de Bord"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.npPlanning.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Page"
    Private Sub FrTableauBord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChargerDonnees()
        Me.lbPanierMoyen.Text = ""
        Me.dtDate.Value = Now 'Remplir planning et Remplir graphique implicite
    End Sub
#End Region

#Region " Remplissage du Planning "
    Private Function CreerPage(ByVal nom As String, ByVal text As String, Optional ByVal image As String = "") As Ascend.Windows.Forms.NavigationPanePage
        Dim npp As New Ascend.Windows.Forms.NavigationPanePage
        With npp
            .Font = npPlanning.Font
            .Key = nom
            .Name = "npp" & nom
            .Text = text
            If image.Length > 0 Then
                .Image = DirectCast(My.Resources.ResourceManager.GetObject(image), Image)
            End If

            'Dim layout As New FlowLayoutPanel
            'With layout
            '    .Dock = DockStyle.Fill
            '    .FlowDirection = FlowDirection.LeftToRight
            '    .AutoScroll = True
            'End With
            '.Controls.Add(layout)
            Dim lv As New ListView
            With lv
                .MultiSelect = False
                .HeaderStyle = ColumnHeaderStyle.None
                .Name = "lv" & nom
                .Dock = DockStyle.Fill
                .View = View.Details
                .Columns.Add("", npPlanning.Width - 25)
                AddHandler .ItemActivate, AddressOf Lv_ItemActivate
                AddHandler .Resize, AddressOf Lv_Resize
            End With
            .Controls.Add(lv)
        End With
        Return npp
    End Function

    Private Sub Lv_Resize(ByVal sender As Object, ByVal e As EventArgs)
        With CType(sender, ListView)
            If .Columns.Count > 0 Then
                .Columns(0).Width = .Width - 25
            End If
        End With
    End Sub

    Private Sub AjouterLien(ByVal npp As Ascend.Windows.Forms.NavigationPanePage, ByVal Nom As String, ByVal Text As String, ByVal Tag As Object)
        Dim lv As ListView = CType(npp.Controls(0), ListView)
        Dim lvi As New ListViewItem
        With lvi
            .Name = Nom
            .Text = Text
            .Tag = Tag
        End With
        lv.Items.Add(lvi)
    End Sub

    Private Sub RemplirPlanning(ByVal dt As Date)
        Cursor.Current = Cursors.WaitCursor
        ds.EnforceConstraints = False
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Evenement", s, SqlProxy.FormatSql("DateEV<={0} And (Realise=0 Or Realise Is Null) And nPersonneDestinataire={1}", dt, FrApplication.nUtilisateur))
            DefinitionDonnees.Instance.Fill(ds, "EvenementPersonne", s, SqlProxy.FormatSql("nEvenement IN (SELECT nEvenement FROM Evenement WHERE DateEV<={0} And (Realise=0 Or Realise Is Null) And nPersonneDestinataire={1})", dt, FrApplication.nUtilisateur))
            DefinitionDonnees.Instance.Fill(ds, "VBonCommande", s, SqlProxy.FormatSql("DateEcheance<={0} And (Paye=0 Or Paye Is Null)", dt))
            DefinitionDonnees.Instance.Fill(ds, "VFacture", s, SqlProxy.FormatSql("DateEcheance<={0} And (Paye=0 Or Paye Is Null)", dt))
        End Using
        ds.EnforceConstraints = True
        DefinitionDonnees.Instance.CreateRelations(ds)

        Me.npPlanning.NavigationPages.Clear()
        npPlanning.NavigationPages.Clear()

        Dim npp As Ascend.Windows.Forms.NavigationPanePage

        If ds.Tables("Evenement").Rows.Count > 0 Then
            npp = CreerPage("Planning", "Planning", "Agenda")
            For Each rw As DataRow In ds.Tables("Evenement").Select("", "DateEv")
                AjouterLien(npp, String.Format("ev{0}", rw("nEvenement")), GetLibelleEvenement(rw), rw("nEvenement"))
            Next
            Me.npPlanning.NavigationPages.Add(npp)
        End If

        If ds.Tables("VBonCommande").Rows.Count > 0 Then
            npp = CreerPage("Commandes", "Commandes à Traiter", "Factures")
            For Each rw As DataRow In ds.Tables("VBonCommande").Select("", "DateEcheance")
                AjouterLien(npp, String.Format("cmd{0}", rw("nDevis")), GetLibelleCommandes(rw), rw("nDevis"))
            Next
            Me.npPlanning.NavigationPages.Add(npp)
        End If

        If ds.Tables("VFacture").Rows.Count > 0 Then
            npp = CreerPage("Factures", "Factures à Echeance", "Factures")
            For Each rw As DataRow In ds.Tables("VFacture").Select("", "DateEcheance")
                AjouterLien(npp, String.Format("fact{0}", rw("nDevis")), GetLibelleFactures(rw), rw("nDevis"))
            Next
            Me.npPlanning.NavigationPages.Add(npp)
        End If

        Dim dtStock As DataTable = Stocks.GetProduitReApprot
        If dtStock.Rows.Count > 0 Then
            npp = CreerPage("Reappro", "Réapprovisionnement", "Cube")
            For Each rw As DataRow In dtStock.Select
                AjouterLien(npp, String.Format("reapp{0}", rw("CodeProduit")), GetLibelleReApprot(rw), rw("CodeProduit"))
            Next
            Me.npPlanning.NavigationPages.Add(npp)
        End If

        If npPlanning.NavigationPages.Count > 0 Then
            npPlanning.SelectedIndex = 0
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Function GetLibelleReApprot(ByRef rwi As DataRow) As String
        Return String.Format("{0} - {1} ({2:N3} {3})", rwi("CodeProduit"), rwi("Libelle"), rwi("Unite1"), rwi("LibUnite1"))
    End Function

    Private Function GetLibelleFactures(ByRef rwi As DataRow) As String
        Dim strLibelle As String = String.Format("{0:dd/MM/yy} - {1}", rwi("DateEcheance"), rwi.GetParentRow("ClientVFacture").Item("Nom"))
        If rwi.Table.Columns.Contains("Secteur") Then
            If Not rwi.IsNull("Secteur") AndAlso CStr(rwi("Secteur")).Length > 0 Then
                strLibelle &= " : " & CStr(rwi.Item("Secteur"))
            End If
        End If
        Return strLibelle
    End Function

    Private Function GetLibelleCommandes(ByRef rwi As DataRow) As String
        Dim strLibelle As String = String.Format("{0:dd/MM/yy} - {1}", rwi("DateEcheance"), rwi.GetParentRow("ClientVBonCommande").Item("Nom"))
        If rwi.Table.Columns.Contains("Secteur") Then
            If Not rwi.IsNull("Secteur") AndAlso CStr(rwi("Secteur")).Length > 0 Then
                strLibelle &= " : " & CStr(rwi.Item("Secteur"))
            End If
        End If
        Return strLibelle
    End Function

    Private Function GetLibelleEvenement(ByRef rwi As DataRow) As String
        Dim strContact As String = ""

        Dim drParticipants() As DataRow = rwi.GetChildRows("EvenementEvenementPersonne")
        For Each drPart As DataRow In drParticipants
            If Not drPart.IsNull("nEntreprise") Then
                Dim drEnt As DataRow = drPart.GetParentRow("EntrepriseEvenementPersonne")
                If drEnt IsNot Nothing Then
                    If Not drEnt.IsNull("Nom") Then
                        strContact = Convert.ToString(drEnt("Nom"))
                        Exit For
                    End If
                End If
            End If
        Next

        If strContact.Length = 0 Then
            For Each drPart As DataRow In drParticipants
                If Not drPart.IsNull("nPersonne") Then
                    Dim drPers As DataRow = drPart.GetParentRow("PersonneEvenementPersonne")
                    If drPers IsNot Nothing Then
                        strContact = String.Format("{0} {1}", drPers("Nom"), drPers("Prenom")).Trim
                        Exit For
                    End If
                End If
            Next
        End If
        If strContact.Length > 0 Then strContact &= " : "

        Return strContact & Convert.ToString(rwi("Libelle"))
    End Function
#End Region

#Region " Toolbar "
    Private Sub TbEtatJour_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimerJour.ButtonClick
        ImprimerJour()
    End Sub

    Private Sub ToolStripDropDownButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimerSemaine.ButtonClick
        ImprimerSemaine()
    End Sub

    Private Sub ToolStripDropDownButton2_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimerMois.ButtonClick
        ImprimerMois()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub TbJour_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles TbJour.Click, TbMois.Click, TbSemaine.Click
        If sender IsNot TbJour Then TbJour.Checked = False
        If sender IsNot TbSemaine Then TbSemaine.Checked = False
        If sender IsNot TbMois Then TbMois.Checked = False
        If Not CType(sender, ToolStripButton).Checked Then CType(sender, ToolStripButton).Checked = True
    End Sub

    Private Sub TbJour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TbJour.CheckedChanged, TbMois.CheckedChanged, TbSemaine.CheckedChanged
        If Not CType(sender, ToolStripButton).Checked Then Exit Sub
        If Me.TbMois.Checked Then
            RemplirGraphique("Mois")
        ElseIf Me.TbSemaine.Checked Then
            RemplirGraphique("Semaine")
        Else
            RemplirGraphique("Jour")
        End If
    End Sub

    Private Sub MenuEtatJour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEtatJourFamille.Click, MenuEtatJourFamilleSousFamille.Click, MenuEtatJourFamilleSousFamillePLU.Click

        If sender Is Me.MenuEtatJourSousFamille Then
            ImprimerJour("ESousFamille")
        ElseIf sender Is Me.MenuEtatJourSousFamilleFamille Then
            ImprimerJour("ESousFamilleFamille")
        ElseIf sender Is Me.MenuEtatJourSousFamilleFamillePLU Then
            ImprimerJour("ESousFamilleFamillePLU")
        ElseIf sender Is Me.MenuEtatJourFamille Then
            ImprimerJour("EFamille")
        ElseIf sender Is Me.MenuEtatJourFamilleSousFamille Then
            ImprimerJour("EFamilleSousFamille")
        ElseIf sender Is Me.MenuEtatJourFamilleSousFamillePLU Then
            ImprimerJour("EFamilleSousFamillePLU")
        End If
    End Sub

    Private Sub MenuEtatMois_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEtatMoisFamille.Click, MenuEtatMoisFamilleSousFamille.Click, MenuEtatMoisFamilleSousFamillePLU.Click

        If sender Is Me.MenuEtatMoisSousFamille Then
            ImprimerMois("ESousFamille")
        ElseIf sender Is Me.MenuEtatMoisSousFamilleFamille Then
            ImprimerMois("ESousFamilleFamille")
        ElseIf sender Is Me.MenuEtatMoisSousFamilleFamillePLU Then
            ImprimerMois("ESousFamilleFamillePLU")
        ElseIf sender Is Me.MenuEtatMoisFamille Then
            ImprimerMois("EFamille")
        ElseIf sender Is Me.MenuEtatMoisFamilleSousFamille Then
            ImprimerMois("EFamilleSousFamille")
        ElseIf sender Is Me.MenuEtatMoisFamilleSousFamillePLU Then
            ImprimerMois("EFamilleSousFamillePLU")
        End If
    End Sub

    Private Sub MenuEtatSemaine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEtatSemaineFamille.Click, MenuEtatSemaineFamilleSousFamille.Click, MenuEtatSemaineFamilleSousFamillePLU.Click


        If sender Is Me.MenuEtatSemaineSousFamille Then
            ImprimerSemaine("ESousFamille")
        ElseIf sender Is Me.MenuEtatSemaineSousFamilleFamille Then
            ImprimerSemaine("ESousFamilleFamille")
        ElseIf sender Is Me.MenuEtatSemaineSousFamilleFamillePLU Then
            ImprimerSemaine("ESousFamilleFamillePLU")
        ElseIf sender Is Me.MenuEtatSemaineFamille Then
            ImprimerSemaine("EFamille")
        ElseIf sender Is Me.MenuEtatSemaineFamilleSousFamille Then
            ImprimerSemaine("EFamilleSousFamille")
        ElseIf sender Is Me.MenuEtatSemaineFamilleSousFamillePLU Then
            ImprimerSemaine("EFamilleSousFamillePLU")
        End If
    End Sub
#End Region

#Region " Control Events "
    Private Sub dtDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDate.ValueChanged
        RemplirPlanning(dtDate.Value.Date)
        If Me.TbMois.Checked Then
            RemplirGraphique("Mois")
        ElseIf Me.TbSemaine.Checked Then
            RemplirGraphique("Semaine")
        Else
            RemplirGraphique("Jour")
        End If
    End Sub

    Private Sub Lv_ItemActivate(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = CType(sender, ListView)
        Select Case lv.Name
            Case "lvPlanning"
                Dim frE As New FrEvenement(CInt(lv.FocusedItem.Tag))
                frE.Owner = Me
                frE.Show()
            Case "lvCommandes"
                Dim frB As New FrBonCommande(CInt(lv.FocusedItem.Tag))
                frB.TypePiece = Pieces.TypePieces.VBonCommande
                frB.Owner = Me
                frB.Show()
            Case "lvFactures"
                Dim frB As New FrBonCommande(CInt(lv.FocusedItem.Tag))
                frB.TypePiece = Pieces.TypePieces.VFacture
                frB.Owner = Me
                frB.Show()
            Case "lvReappro"
                Dim frP As New FrProduit(CStr(lv.FocusedItem.Tag))
                frP.Owner = Me
                frP.Show()
        End Select
    End Sub
#End Region

#Region " Statistiques "
    Private Sub RemplirGraphique(ByVal Type As String)
        Using s As New SqlProxy
            Select Case Type
                Case "Jour"
                    Dim dtDebutSemaine As Date = dtDate.Value
                    Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                        dtDebutSemaine = dtDebutSemaine.AddDays(-1)
                    Loop

                    Me.Graphique1.RefreshAuto = False
                    Me.Graphique2.RefreshAuto = False
                    Me.Graphique3.RefreshAuto = False

                    Me.Graphique1.Valeurs.Clear()
                    Me.Graphique2.Valeurs.Clear()
                    Me.Graphique3.Valeurs.Clear()
                    Me.Graphique1.Legendes.Clear()
                    Me.Graphique2.Legendes.Clear()
                    Me.Graphique3.Legendes.Clear()

                    Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
                    Dim nJour As Integer
                    Dim dt As Date = dtDebutSemaine
                    Dim nLastJourVente As Integer = -1
                    Dim nLastJourAchat As Integer = -1
                    Dim nLastJourFreq As Integer = -1

                    For nJour = 0 To 6
                        Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddDays(nJour), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        If br.Valeur > 0 Then
                            nLastJourAchat = nJour
                        End If

                        br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(nJour), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Red
                        If br.Valeur > 0 Then
                            nLastJourVente = nJour
                        End If
                        'br.Valeur2 = Me.GetMontantPayeHT("VFacture", Type, dt.AddDays(nJour))
                        'br.Couleur2 = Color.Green
                        ''Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red

                        br = Me.Graphique3.Valeurs.Add(GetNbClient("VFacture", Type, dt.AddDays(nJour), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Green
                        If br.Valeur > 0 Then
                            nLastJourFreq = nJour
                        End If

                        'br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.AddDays(nJour))
                        'br.Couleur2 = Color.Yellow
                        ''br.Valeur3 = -1

                        'br = Me.Graphique3.Valeurs.Add(Me.GetNbClient("VFacture", Type, dt.AddDays(nJour)))
                        'If br.Valeur > ValeurMaxGraphique Then
                        '    ValeurMaxGraphique = br.Valeur
                        'End If
                        'br.Couleur = Color.Blue
                        'br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.AddDays(nJour))
                        'br.Couleur2 = Color.Yellow
                        ''br.Valeur3 = br.Valeur / 2 + 10

                        Dim Legende As String = dt.AddDays(nJour).ToString("dddd")
                        Me.Graphique1.Legendes.Add(Legende)
                        Me.Graphique2.Legendes.Add(Legende)
                        Me.Graphique3.Legendes.Add(Legende)

                    Next

                    If nLastJourVente >= 0 Then
                        Me.LbVentes.Text = "Ventes"
                        Me.lbPanierMoyen.Text = ""
                        Me.Graphique2_ClickLegende(Me.Graphique2, nLastJourVente)
                    End If
                    If nLastJourAchat >= 0 Then
                        Me.LbAchats.Text = "Achats"
                        Me.Graphique1_ClickLegende(Me.Graphique1, nLastJourAchat)
                    End If
                    If nLastJourFreq >= 0 Then
                        Me.LbFréquentations.Text = "Fréquentations"
                        Me.Graphique3_ClickLegende(Me.Graphique3, nLastJourFreq)
                    End If


                    'Me.Graphique1.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique2.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique3.ValeurMax = valeurmaxgraphique

                    'Me.Graphique1.ResumeLayout()
                    'Me.Graphique2.ResumeLayout()
                    'Me.Graphique3.ResumeLayout()

                    Me.Graphique1.RefreshAuto = True
                    Me.Graphique2.RefreshAuto = True
                    Me.Graphique3.RefreshAuto = True
                Case "Mois"
                    Dim dtDebutSemaine As Date = dtDate.Value
                    Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                        dtDebutSemaine = dtDebutSemaine.AddDays(-1)
                    Loop
                    Dim nJour As Integer
                    Dim dt As Date = dtDebutSemaine

                    Me.Graphique1.RefreshAuto = False
                    Me.Graphique2.RefreshAuto = False
                    Me.Graphique3.RefreshAuto = False

                    Me.Graphique1.Valeurs.Clear()
                    Me.Graphique2.Valeurs.Clear()
                    Me.Graphique3.Valeurs.Clear()
                    Me.Graphique1.Legendes.Clear()
                    Me.Graphique2.Legendes.Clear()
                    Me.Graphique3.Legendes.Clear()

                    Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
                    Dim nLastJourVente As Integer = -1
                    Dim nLastJourAchat As Integer = -1
                    Dim nLastJourFreq As Integer = -1
                    For nJour = 0 To 6
                        Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddMonths(-(6 - nJour)), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        If br.Valeur > 0 Then
                            nLastJourAchat = nJour
                        End If
                        'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red
                        br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddMonths(-(6 - nJour)), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Red
                        If br.Valeur > 0 Then
                            nLastJourVente = nJour
                        End If
                        'br.Valeur2 = GetMontantPayeHT("VFacture", Type, dt.AddMonths(-(5 - nJour)))
                        'br.Couleur2 = Color.Yellow

                        br = Me.Graphique3.Valeurs.Add(GetNbClient("VFacture", Type, dt.AddMonths(-(6 - nJour)), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Green
                        If br.Valeur > 0 Then
                            nLastJourFreq = nJour
                        End If
                        ''br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.AddMonths(-(5 - nJour)))
                        ''br.Couleur2 = Color.Yellow

                        'br = Me.Graphique3.Valeurs.Add(GetNbClient("AFacture", Type, dt.AddMonths(-(5 - nJour))))
                        'If br.Valeur > ValeurMaxGraphique Then
                        '    ValeurMaxGraphique = br.Valeur
                        'End If
                        'br.Couleur = Color.Blue
                        'br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.AddMonths(-(5 - nJour)))
                        'br.Couleur2 = Color.Yellow


                        Dim Legende As String = dt.AddMonths(-(6 - nJour)).ToString("MMMM")
                        Me.Graphique1.Legendes.Add(Legende)
                        Me.Graphique2.Legendes.Add(Legende)
                        Me.Graphique3.Legendes.Add(Legende)

                        'dt.AddDays(1)
                    Next

                    'Me.Graphique1.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique2.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique3.ValeurMax = valeurmaxgraphique

                    If nLastJourVente >= 0 Then
                        Me.LbVentes.Text = "Ventes"
                        Me.lbPanierMoyen.Text = ""
                        Me.Graphique2_ClickLegende(Me.Graphique2, nLastJourVente)
                    End If
                    If nLastJourAchat >= 0 Then
                        Me.LbAchats.Text = "Achats"
                        Me.Graphique1_ClickLegende(Me.Graphique1, nLastJourAchat)
                    End If
                    If nLastJourFreq >= 0 Then
                        Me.LbFréquentations.Text = "Fréquentations"
                        Me.Graphique3_ClickLegende(Me.Graphique3, nLastJourFreq)
                    End If


                    Me.Graphique1.RefreshAuto = True
                    Me.Graphique2.RefreshAuto = True
                    Me.Graphique3.RefreshAuto = True
                    'dt = dtDebutSemaine
                    'For nJour = 0 To 5
                    '    Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddMonths(-(5 - nJour))))
                    '    If br.Valeur > ValeurMaxGraphique Then
                    '        ValeurMaxGraphique = br.Valeur
                    '    End If
                    '    br.Couleur = Color.Red
                    '    Me.Graphique2.Legendes.Add(dt.AddMonths(-(5 - nJour)).ToString("MMMM"))
                    'Next
                    'Me.Graphique1.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique2.ValeurMax = ValeurMaxGraphique
                Case "Semaine"
                    Dim dtDebutSemaine As Date = dtDate.Value
                    Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                        dtDebutSemaine = dtDebutSemaine.AddDays(-1)
                    Loop
                    Dim nJour As Integer
                    Dim dt As Date = dtDebutSemaine

                    Me.Graphique1.RefreshAuto = False
                    Me.Graphique2.RefreshAuto = False
                    Me.Graphique3.RefreshAuto = False

                    Me.Graphique1.Valeurs.Clear()
                    Me.Graphique2.Valeurs.Clear()
                    Me.Graphique3.Valeurs.Clear()
                    Me.Graphique1.Legendes.Clear()
                    Me.Graphique2.Legendes.Clear()
                    Me.Graphique3.Legendes.Clear()

                    Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
                    Dim nLastJourVente As Integer = -1
                    Dim nLastJourAchat As Integer = -1
                    Dim nLastJourFreq As Integer = -1
                    For nJour = 0 To 6
                        Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddDays(-(6 - nJour) * 7), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        If br.Valeur > 0 Then
                            nLastJourAchat = nJour
                        End If
                        'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red
                        br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(-(6 - nJour) * 7), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Red
                        If br.Valeur > 0 Then
                            nLastJourVente = nJour
                        End If
                        'br.Valeur2 = GetMontantPayeHT("VFacture", Type, dt.AddDays(-(5 - nJour) * 7))
                        'br.Couleur2 = Color.Yellow

                        br = Me.Graphique3.Valeurs.Add(GetNbClient("VFacture", Type, dt.AddDays(-(6 - nJour) * 7), s))
                        If br.Valeur > ValeurMaxGraphique Then
                            ValeurMaxGraphique = br.Valeur
                        End If
                        br.Couleur = Color.Green
                        If br.Valeur > 0 Then
                            nLastJourFreq = nJour
                        End If
                        'br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.Adddays(-(5 - nJour) * 7))
                        'br.Couleur2 = Color.Yellow

                        'br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("AFacture", Type, dt.Adddays(-(5 - nJour) * 7)))
                        'If br.Valeur > ValeurMaxGraphique Then
                        '    ValeurMaxGraphique = br.Valeur
                        'End If
                        'br.Couleur = Color.Blue
                        'br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.Adddays(-(5 - nJour) * 7))
                        'br.Couleur2 = Color.Yellow


                        Dim Legende As String = Actigram.Dates.Dates.GetNWeek(dt.AddDays(-(6 - nJour) * 7)).ToString
                        Me.Graphique1.Legendes.Add(Legende)
                        Me.Graphique2.Legendes.Add(Legende)
                        Me.Graphique3.Legendes.Add(Legende)

                        'dt.AddDays(1)
                    Next
                    'Me.Graphique1.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique2.ValeurMax = ValeurMaxGraphique
                    'Me.Graphique3.ValeurMax = valeurmaxgraphique

                    If nLastJourVente >= 0 Then
                        Me.LbVentes.Text = "Ventes"
                        Me.lbPanierMoyen.Text = ""
                        Me.Graphique2_ClickLegende(Me.Graphique2, nLastJourVente)
                    End If
                    If nLastJourAchat >= 0 Then
                        Me.LbAchats.Text = "Achats"
                        Me.Graphique1_ClickLegende(Me.Graphique1, nLastJourAchat)
                    End If
                    If nLastJourFreq >= 0 Then
                        Me.LbFréquentations.Text = "Fréquentations"
                        Me.Graphique3_ClickLegende(Me.Graphique3, nLastJourFreq)
                    End If

                    Me.Graphique1.RefreshAuto = True
                    Me.Graphique2.RefreshAuto = True
                    Me.Graphique3.RefreshAuto = True
            End Select
        End Using
    End Sub

    'Private Sub RemplirGraphiqueClassique(ByVal Type As String)
    '    Using s As New SqlProxy
    '        Select Case Type
    '            Case "Jour"
    '                Dim dtDebutSemaine As Date = Now
    '                Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
    '                    dtDebutSemaine = dtDebutSemaine.AddDays(-1)
    '                Loop

    '                Me.Graphique1.RefreshAuto = False
    '                Me.Graphique2.RefreshAuto = False
    '                Me.Graphique3.RefreshAuto = False

    '                Me.Graphique1.Valeurs.Clear()
    '                Me.Graphique2.Valeurs.Clear()
    '                Me.Graphique3.Valeurs.Clear()
    '                Me.Graphique1.Legendes.Clear()
    '                Me.Graphique2.Legendes.Clear()
    '                Me.Graphique3.Legendes.Clear()

    '                Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
    '                Dim nJour As Integer
    '                Dim dt As Date = dtDebutSemaine
    '                For nJour = 0 To 5
    '                    Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddDays(nJour), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    'Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", dt.AddDays(nJour)))
    '                    'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(nJour))).Couleur = Color.Green
    '                    'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(nJour))).Couleur = Color.Red
    '                    'dt.AddDays(1)

    '                    br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(nJour), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Red
    '                    br.Valeur2 = Me.GetMontantPayeHT("VFacture", Type, dt.AddDays(nJour), s)
    '                    br.Couleur2 = Color.Green
    '                    'Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("VFacture", Type, dt.AddDays(nJour), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Green
    '                    br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.AddDays(nJour), s)
    '                    br.Couleur2 = Color.Yellow
    '                    'br.Valeur3 = -1

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("AFacture", Type, dt.AddDays(nJour), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Blue
    '                    br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.AddDays(nJour), s)
    '                    br.Couleur2 = Color.Yellow
    '                    'br.Valeur3 = br.Valeur / 2 + 10

    '                    Dim Legende As String = dt.AddDays(nJour).ToString("dddd")
    '                    Me.Graphique1.Legendes.Add(Legende)
    '                    Me.Graphique2.Legendes.Add(Legende)
    '                    Me.Graphique3.Legendes.Add(Legende)

    '                Next

    '                'Me.Graphique1.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique2.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique3.ValeurMax = valeurmaxgraphique

    '                'Me.Graphique1.ResumeLayout()
    '                'Me.Graphique2.ResumeLayout()
    '                'Me.Graphique3.ResumeLayout()
    '                Me.Graphique1.RefreshAuto = True
    '                Me.Graphique2.RefreshAuto = True
    '                Me.Graphique3.RefreshAuto = True
    '            Case "Mois"
    '                Dim dtDebutSemaine As Date = Now
    '                Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
    '                    dtDebutSemaine = dtDebutSemaine.AddDays(-1)
    '                Loop
    '                Dim nJour As Integer
    '                Dim dt As Date = dtDebutSemaine

    '                Me.Graphique1.RefreshAuto = False
    '                Me.Graphique2.RefreshAuto = False
    '                Me.Graphique3.RefreshAuto = False

    '                Me.Graphique1.Valeurs.Clear()
    '                Me.Graphique2.Valeurs.Clear()
    '                Me.Graphique3.Valeurs.Clear()
    '                Me.Graphique1.Legendes.Clear()
    '                Me.Graphique2.Legendes.Clear()
    '                Me.Graphique3.Legendes.Clear()

    '                Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
    '                For nJour = 0 To 5
    '                    Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddMonths(-(5 - nJour)), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red
    '                    br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddMonths(-(5 - nJour)), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Red
    '                    br.Valeur2 = GetMontantPayeHT("VFacture", Type, dt.AddMonths(-(5 - nJour)), s)
    '                    br.Couleur2 = Color.Yellow

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("VFacture", Type, dt.AddMonths(-(5 - nJour)), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Green
    '                    br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.AddMonths(-(5 - nJour)), s)
    '                    br.Couleur2 = Color.Yellow

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("AFacture", Type, dt.AddMonths(-(5 - nJour)), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Blue
    '                    br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.AddMonths(-(5 - nJour)), s)
    '                    br.Couleur2 = Color.Yellow


    '                    Dim Legende As String = dt.AddMonths(-(5 - nJour)).ToString("MMMM")
    '                    Me.Graphique1.Legendes.Add(Legende)
    '                    Me.Graphique2.Legendes.Add(Legende)
    '                    Me.Graphique3.Legendes.Add(Legende)

    '                    'dt.AddDays(1)
    '                Next

    '                'Me.Graphique1.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique2.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique3.ValeurMax = valeurmaxgraphique

    '                Me.Graphique1.RefreshAuto = True
    '                Me.Graphique2.RefreshAuto = True
    '                Me.Graphique3.RefreshAuto = True
    '                'dt = dtDebutSemaine
    '                'For nJour = 0 To 5
    '                '    Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddMonths(-(5 - nJour))))
    '                '    If br.Valeur > ValeurMaxGraphique Then
    '                '        ValeurMaxGraphique = br.Valeur
    '                '    End If
    '                '    br.Couleur = Color.Red
    '                '    Me.Graphique2.Legendes.Add(dt.AddMonths(-(5 - nJour)).ToString("MMMM"))
    '                'Next
    '                'Me.Graphique1.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique2.ValeurMax = ValeurMaxGraphique
    '            Case "Semaine"
    '                Dim dtDebutSemaine As Date = Now
    '                Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
    '                    dtDebutSemaine = dtDebutSemaine.AddDays(-1)
    '                Loop
    '                Dim nJour As Integer
    '                Dim dt As Date = dtDebutSemaine

    '                Me.Graphique1.RefreshAuto = False
    '                Me.Graphique2.RefreshAuto = False
    '                Me.Graphique3.RefreshAuto = False

    '                Me.Graphique1.Valeurs.Clear()
    '                Me.Graphique2.Valeurs.Clear()
    '                Me.Graphique3.Valeurs.Clear()
    '                Me.Graphique1.Legendes.Clear()
    '                Me.Graphique2.Legendes.Clear()
    '                Me.Graphique3.Legendes.Clear()

    '                Dim ValeurMaxGraphique As Decimal = Me.Graphique1.ValeurMax
    '                For nJour = 0 To 5
    '                    Dim br As Actigram.Windows.Forms.Indicateurs.Barre = Me.Graphique1.Valeurs.Add(GetMontantHT("AFacture", Type, dt.AddDays(-(5 - nJour) * 7), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    'Me.Graphique1.Valeurs.Add(GetMontantHT("VFacture", dt.AddDays(nJour))).Couleur = Color.Red
    '                    br = Me.Graphique2.Valeurs.Add(GetMontantHT("VFacture", Type, dt.AddDays(-(5 - nJour) * 7), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Red
    '                    br.Valeur2 = GetMontantPayeHT("VFacture", Type, dt.AddDays(-(5 - nJour) * 7), s)
    '                    br.Couleur2 = Color.Yellow

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("VFacture", Type, dt.AddDays(-(5 - nJour) * 7), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Green
    '                    br.Valeur2 = GetMontantEcheancePayeHT("VFacture", Type, dt.AddDays(-(5 - nJour) * 7), s)
    '                    br.Couleur2 = Color.Yellow

    '                    br = Me.Graphique3.Valeurs.Add(GetMontantEcheanceHT("AFacture", Type, dt.AddDays(-(5 - nJour) * 7), s))
    '                    If br.Valeur > ValeurMaxGraphique Then
    '                        ValeurMaxGraphique = br.Valeur
    '                    End If
    '                    br.Couleur = Color.Blue
    '                    br.Valeur2 = GetMontantEcheancePayeHT("AFacture", Type, dt.AddDays(-(5 - nJour) * 7), s)
    '                    br.Couleur2 = Color.Yellow


    '                    Dim Legende As String = Actigram.Dates.Dates.GetNWeek(dt.AddDays(-(5 - nJour) * 7)).ToString
    '                    Me.Graphique1.Legendes.Add(Legende)
    '                    Me.Graphique2.Legendes.Add(Legende)
    '                    Me.Graphique3.Legendes.Add(Legende)

    '                    'dt.AddDays(1)
    '                Next
    '                'Me.Graphique1.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique2.ValeurMax = ValeurMaxGraphique
    '                'Me.Graphique3.ValeurMax = valeurmaxgraphique

    '                Me.Graphique1.RefreshAuto = True
    '                Me.Graphique2.RefreshAuto = True
    '                Me.Graphique3.RefreshAuto = True
    '        End Select
    '    End Using
    'End Sub

    Private Function GetMontantHT(ByVal nomTable As String, ByVal Type As String, ByVal dt As Date, ByVal s As SqlProxy) As Decimal
        Dim Resultat As Decimal
        Dim sql As String = "SELECT Sum(MontantHT) FROM " & nomTable & " WHERE " & GetClauseDate("DateFacture", dt, Type)
        Resultat = s.ExecuteScalarDec(sql)
        If nomTable = "VFacture" Then
            sql = "SELECT Sum(TotalMontant) FROM Trame WHERE BookingCancel=0 AND " & GetClauseDate("dtTicket", dt, Type)
            Resultat += s.ExecuteScalarDec(sql)
        End If
        Return Resultat
    End Function

    Private Function GetMontantPayeHT(ByVal nomTable As String, ByVal Type As String, ByVal dt As Date, ByVal s As SqlProxy) As Decimal
        Dim sql As String = "SELECT Sum(MontantHT) FROM " & nomTable & " WHERE Paye=1 AND " & GetClauseDate("datefacture", dt, Type)
        Return s.ExecuteScalarDec(sql)
    End Function

    Private Function GetMontantEcheanceHT(ByVal nomTable As String, ByVal Type As String, ByVal dt As Date, ByVal s As SqlProxy) As Decimal
        Dim sql As String = "SELECT Sum(MontantHT) FROM " & nomTable & " WHERE " & GetClauseDate("DateEcheance", dt, Type)
        Return s.ExecuteScalarDec(sql)
    End Function

    Private Function GetMontantEcheancePayeHT(ByVal nomTable As String, ByVal Type As String, ByVal dt As Date, ByVal s As SqlProxy) As Decimal
        Dim sql As String = "SELECT Sum(MontantHT) FROM " & nomTable & " WHERE Paye=1 AND " & GetClauseDate("DateEcheance", dt, Type)
        Return s.ExecuteScalarDec(sql)
    End Function

    Private Function GetNbClient(ByVal nomTable As String, ByVal Type As String, ByVal dt As Date, ByVal s As SqlProxy) As Decimal
        Dim Resultat As Decimal
        Dim sql As String = "SELECT Count(nDevis) FROM " & nomTable & " WHERE " & GetClauseDate("DateFacture", dt, Type)
        Resultat = s.ExecuteScalarDec(sql)
        If nomTable = "VFacture" Then
            sql = "SELECT Count(nTicket) FROM Trame WHERE (TotalMontant Is NOT Null) And BookingCancel=0 AND " & GetClauseDate("dtTicket", dt, Type)
            Resultat += s.ExecuteScalarDec(sql)
        End If
        Return Resultat
    End Function

    Private Function GetClauseDate(ByVal col As String, ByVal dt As Date, ByVal type As String) As String
        Select Case type
            Case "Jour"
                Return SqlProxy.FormatSql(col & "={0}", dt)
            Case "Semaine"
                dt = dt.AddDays(1 - dt.DayOfWeek) 'Lundi de la semaine
                Return SqlProxy.FormatSql("datediff(day,{0}," & col & ") between 0 and 7", dt)
            Case "Mois"
                dt = New Date(dt.Year, dt.Month, 1) '1er du mois
                Return SqlProxy.FormatSql("datediff(month,{0}," & col & ")=0", dt)
        End Select
        Return ""
    End Function

    Private Sub Graphique2_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer) Handles Graphique2.ClickLegende
        Me.LbVentes.Text = "Ventes : (" & sender.Legendes.Item(nBarre) & ") " & sender.Valeurs.Item(nBarre).Valeur.ToString("C2")
        If Me.Graphique3.Valeurs.Item(nBarre).Valeur > 0 Then
            Me.lbPanierMoyen.Text = "Panier Moyen : (" & sender.Legendes.Item(nBarre) & ") " & (sender.Valeurs.Item(nBarre).Valeur / Me.Graphique3.Valeurs.Item(nBarre).Valeur).ToString("C2")
        Else
            Me.lbPanierMoyen.Text = ""
        End If
    End Sub

    Private Sub Graphique1_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer) Handles Graphique1.ClickLegende
        Me.LbAchats.Text = "Achats : (" & sender.Legendes.Item(nBarre) & ") " & sender.Valeurs.Item(nBarre).Valeur.ToString("C2")
    End Sub

    Private Sub Graphique3_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer) Handles Graphique3.ClickLegende
        Me.LbFréquentations.Text = "Fréquentations : (" & sender.Legendes.Item(nBarre) & ") " & sender.Valeurs.Item(nBarre).Valeur
    End Sub
#End Region

#Region " Etats "
    Private Sub ImprimerJour(Optional ByVal Type As String = "EFamilleSousFamillePLU")
        Dim frF As GRC.FrFusion
        Select Case Type
            Case "ESousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParJour5.rpt")
            Case "ESousFamilleFamille"
                frF = GestionImpression.TrouverRapport("RptCaParJour4.rpt")
            Case "ESousFamilleFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParJour3.rpt")
            Case "EFamille"
                frF = GestionImpression.TrouverRapport("RptCaParJourFamille5.rpt")
            Case "EFamilleSousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParJourFamille4.rpt")
            Case "EFamilleSousFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParJourFamille3.rpt")
        End Select
        If Not frF Is Nothing Then
            'Impression par jour : du lundi au dimanche de la semaine de la date sélectionnée
            Dim dt As Date = Me.dtDate.Value
            Do Until dt.DayOfWeek = DayOfWeek.Monday
                dt = dt.AddDays(-1)
            Loop
            frF.DateDebut = dt
            frF.DateFin = dt.AddDays(6)

            frF.Show()
        End If
    End Sub

    Private Sub ImprimerSemaine(Optional ByVal Type As String = "EFamilleSousFamillePLU")
        Dim frF As GRC.FrFusion
        Select Case Type
            Case "ESousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParSemaine5.rpt")
            Case "ESousFamilleFamille"
                frF = GestionImpression.TrouverRapport("RptCaParSemaine4.rpt")
            Case "ESousFamilleFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParSemaine3.rpt")
            Case "EFamille"
                frF = GestionImpression.TrouverRapport("RptCaParSemaineFamille5.rpt")
            Case "EFamilleSousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParSemaineFamille4.rpt")
            Case "EFamilleSousFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParSemaineFamille3.rpt")
        End Select

        'Impression par semaine : de 4 semaines avant à 1 semaine après le lundi de la date sélectionné
        Dim dtDebSemaine As Date = Me.dtDate.Value
        Do Until dtDebSemaine.DayOfWeek = DayOfWeek.Monday
            dtDebSemaine = dtDebSemaine.AddDays(-1)
        Loop
        frF.DateDebut = dtDebSemaine.AddDays(-4 * 7)
        frF.DateFin = dtDebSemaine.AddDays(7)
        frF.Show()
    End Sub

    Private Sub ImprimerMois(Optional ByVal Type As String = "EFamilleSousFamillePLU")
        Dim frF As GRC.FrFusion
        Select Case Type
            Case "ESousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParMois5.rpt")
            Case "ESousFamilleFamille"
                frF = GestionImpression.TrouverRapport("RptCaParMois4.rpt")
            Case "ESousFamilleFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParMois3.rpt")
            Case "EFamille"
                frF = GestionImpression.TrouverRapport("RptCaParMoisFamille5.rpt")
            Case "EFamilleSousFamille"
                frF = GestionImpression.TrouverRapport("RptCaParMoisFamille4.rpt")
            Case "EFamilleSousFamillePLU"
                frF = GestionImpression.TrouverRapport("RptCaParMoisFamille3.rpt")
        End Select
        'Impression par mois : de 11 mois en arrière à fin du mois de la date sélectionnée
        Dim dtDebMois As Date = New Date(Me.dtDate.Value.Year, Me.dtDate.Value.Month, 1)
        frF.DateDebut = dtDebMois.AddMonths(-11)
        frF.DateFin = dtDebMois.AddMonths(1).AddDays(-1)
        frF.Show()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            DefinitionDonnees.Instance.Fill(ds, "Personne", s)
        End Using
    End Sub
#End Region

End Class
