Imports GRC

Public Class FrAgenda
    Inherits Form
    
    Private strTypeEntite As String
    Private nEntite As Integer

#Region "Ctor"
    Public Sub New(ByVal TypeEntite As String, ByVal momnEntite As Integer)
        Me.New()
        strTypeEntite = TypeEntite
        nEntite = momnEntite
    End Sub
#End Region

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
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvAgenda As System.Windows.Forms.ListView
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption4 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents tvFiltre As System.Windows.Forms.TreeView
    Friend WithEvents dtpSelFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbSelFin As System.Windows.Forms.Label
    Friend WithEvents dtpSelDeb As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbJour As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSemaine As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbMois As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsEvenements As AgriFact.DsEvenements
    Friend WithEvents EvenementTA As AgriFact.DsEvenementsTableAdapters.EvenementTA
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents EvenementPersonneDisplayTA As AgriFact.DsEvenementsTableAdapters.EvenementPersonneDisplayTA
    Friend WithEvents ListeChoixTA As AgriFact.DsEvenementsTableAdapters.ListeChoixTA
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilTypeEv24 As System.Windows.Forms.ImageList
    Friend WithEvents TbPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ilTypeEv As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAgenda))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Téléphoner")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rendez-vous")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tous", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Mardi 01 juin 2010", System.Windows.Forms.HorizontalAlignment.Right)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Mercredi 02 juin 2010", System.Windows.Forms.HorizontalAlignment.Right)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Faire un truc à 16h du genre vachement long et tout")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Faire un truc à 17h")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Faire un truc à 12h")
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ilTypeEv = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tvFiltre = New System.Windows.Forms.TreeView
        Me.ilTypeEv24 = New System.Windows.Forms.ImageList(Me.components)
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.dtpSelFin = New System.Windows.Forms.DateTimePicker
        Me.lbSelFin = New System.Windows.Forms.Label
        Me.dtpSelDeb = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientCaption4 = New Ascend.Windows.Forms.GradientCaption
        Me.lvAgenda = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbJour = New System.Windows.Forms.ToolStripButton
        Me.TbSemaine = New System.Windows.Forms.ToolStripButton
        Me.TbMois = New System.Windows.Forms.ToolStripButton
        Me.TbPrev = New System.Windows.Forms.ToolStripButton
        Me.TbNext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.DsEvenements = New AgriFact.DsEvenements
        Me.EvenementTA = New AgriFact.DsEvenementsTableAdapters.EvenementTA
        Me.EvenementPersonneDisplayTA = New AgriFact.DsEvenementsTableAdapters.EvenementPersonneDisplayTA
        Me.ListeChoixTA = New AgriFact.DsEvenementsTableAdapters.ListeChoixTA
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DsEvenements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        '
        'ilTypeEv
        '
        Me.ilTypeEv.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilTypeEv.ImageSize = New System.Drawing.Size(32, 32)
        Me.ilTypeEv.TransparentColor = System.Drawing.Color.Transparent
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvFiltre)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GradientCaption1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GradientPanel1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvAgenda)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(824, 501)
        Me.SplitContainer1.SplitterDistance = 188
        Me.SplitContainer1.TabIndex = 2
        '
        'tvFiltre
        '
        Me.tvFiltre.CheckBoxes = True
        Me.tvFiltre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvFiltre.FullRowSelect = True
        Me.tvFiltre.ImageIndex = 0
        Me.tvFiltre.ImageList = Me.ilTypeEv24
        Me.tvFiltre.Location = New System.Drawing.Point(3, 130)
        Me.tvFiltre.Name = "tvFiltre"
        TreeNode1.Name = "Tel"
        TreeNode1.Text = "Téléphoner"
        TreeNode2.Name = "RV"
        TreeNode2.Text = "Rendez-vous"
        TreeNode3.Name = "Tous"
        TreeNode3.Text = "Tous"
        Me.tvFiltre.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.tvFiltre.SelectedImageIndex = 0
        Me.tvFiltre.ShowLines = False
        Me.tvFiltre.ShowPlusMinus = False
        Me.tvFiltre.Size = New System.Drawing.Size(182, 368)
        Me.tvFiltre.TabIndex = 3
        '
        'ilTypeEv24
        '
        Me.ilTypeEv24.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilTypeEv24.ImageSize = New System.Drawing.Size(24, 24)
        Me.ilTypeEv24.TransparentColor = System.Drawing.Color.Transparent
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(3, 106)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(182, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Filtre"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(182, 11)
        Me.Panel1.TabIndex = 4
        '
        'GradientPanel1
        '
        Me.GradientPanel1.AutoScroll = True
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.Controls.Add(Me.dtpSelFin)
        Me.GradientPanel1.Controls.Add(Me.lbSelFin)
        Me.GradientPanel1.Controls.Add(Me.dtpSelDeb)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.GradientCaption4)
        Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(182, 92)
        Me.GradientPanel1.TabIndex = 2
        '
        'dtpSelFin
        '
        Me.dtpSelFin.Enabled = False
        Me.dtpSelFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSelFin.Location = New System.Drawing.Point(56, 56)
        Me.dtpSelFin.Name = "dtpSelFin"
        Me.dtpSelFin.Size = New System.Drawing.Size(100, 20)
        Me.dtpSelFin.TabIndex = 4
        '
        'lbSelFin
        '
        Me.lbSelFin.AutoSize = True
        Me.lbSelFin.Location = New System.Drawing.Point(30, 62)
        Me.lbSelFin.Name = "lbSelFin"
        Me.lbSelFin.Size = New System.Drawing.Size(20, 13)
        Me.lbSelFin.TabIndex = 3
        Me.lbSelFin.Text = "Au"
        '
        'dtpSelDeb
        '
        Me.dtpSelDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSelDeb.Location = New System.Drawing.Point(56, 30)
        Me.dtpSelDeb.Name = "dtpSelDeb"
        Me.dtpSelDeb.Size = New System.Drawing.Size(100, 20)
        Me.dtpSelDeb.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Du"
        '
        'GradientCaption4
        '
        Me.GradientCaption4.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption4.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption4.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption4.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption4.Name = "GradientCaption4"
        Me.GradientCaption4.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption4.Size = New System.Drawing.Size(182, 24)
        Me.GradientCaption4.TabIndex = 0
        Me.GradientCaption4.Text = "Sélection"
        '
        'lvAgenda
        '
        Me.lvAgenda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvAgenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAgenda.FullRowSelect = True
        ListViewGroup1.Header = "Mardi 01 juin 2010"
        ListViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Right
        ListViewGroup1.Name = "20100601"
        ListViewGroup2.Header = "Mercredi 02 juin 2010"
        ListViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Right
        ListViewGroup2.Name = "20100602"
        Me.lvAgenda.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.lvAgenda.HideSelection = False
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup1
        ListViewItem3.Group = ListViewGroup2
        Me.lvAgenda.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lvAgenda.LargeImageList = Me.ilTypeEv
        Me.lvAgenda.Location = New System.Drawing.Point(3, 3)
        Me.lvAgenda.MultiSelect = False
        Me.lvAgenda.Name = "lvAgenda"
        Me.lvAgenda.Size = New System.Drawing.Size(626, 495)
        Me.lvAgenda.SmallImageList = Me.ilTypeEv24
        Me.lvAgenda.TabIndex = 0
        Me.lvAgenda.TileSize = New System.Drawing.Size(320, 34)
        Me.lvAgenda.UseCompatibleStateImageBehavior = False
        Me.lvAgenda.View = System.Windows.Forms.View.Tile
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbJour, Me.TbSemaine, Me.TbMois, Me.TbPrev, Me.TbNext, Me.ToolStripSeparator1, Me.TbFilter, Me.TbImpr, Me.TbClose, Me.ToolStripSeparator2, Me.TbNew, Me.TbSuppr})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(824, 49)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbJour
        '
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
        'TbPrev
        '
        Me.TbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbPrev.Image = Global.AgriFact.My.Resources.Resources.prev24
        Me.TbPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbPrev.Name = "TbPrev"
        Me.TbPrev.Size = New System.Drawing.Size(28, 46)
        Me.TbPrev.Text = "Précédent"
        '
        'TbNext
        '
        Me.TbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNext.Image = Global.AgriFact.My.Resources.Resources.next24
        Me.TbNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNext.Name = "TbNext"
        Me.TbNext.Size = New System.Drawing.Size(28, 46)
        Me.TbNext.Text = "Suivant"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 49)
        '
        'TbFilter
        '
        Me.TbFilter.Checked = True
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 46)
        Me.TbFilter.Text = "A faire"
        '
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(36, 46)
        Me.TbImpr.Text = "Imprimer"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 46)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 49)
        '
        'TbNew
        '
        Me.TbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNew.Image = Global.AgriFact.My.Resources.Resources.new24
        Me.TbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNew.Name = "TbNew"
        Me.TbNew.Size = New System.Drawing.Size(28, 46)
        Me.TbNew.Text = "Nouvel événement"
        '
        'TbSuppr
        '
        Me.TbSuppr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuppr.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbSuppr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuppr.Name = "TbSuppr"
        Me.TbSuppr.Size = New System.Drawing.Size(27, 46)
        Me.TbSuppr.Text = "Supprimer l'événement"
        '
        'DsEvenements
        '
        Me.DsEvenements.DataSetName = "DsEvenements"
        Me.DsEvenements.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EvenementTA
        '
        Me.EvenementTA.ClearBeforeFill = True
        '
        'EvenementPersonneDisplayTA
        '
        Me.EvenementPersonneDisplayTA.ClearBeforeFill = True
        '
        'ListeChoixTA
        '
        Me.ListeChoixTA.ClearBeforeFill = True
        '
        'FrAgenda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(824, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrAgenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DsEvenements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        ilTypeEv.Images.Clear()
        ilTypeEv24.Images.Clear()
        Me.ListeChoixTA.FillTypeEv(Me.DsEvenements.ListeChoix)
        ilTypeEv.Images.Add("defaultEv", My.Resources.IconesTypeEv.defaultEv)
        ilTypeEv24.Images.Add("defaultEv", My.Resources.IconesTypeEv.defaultEv)
        For Each dr As DsEvenements.ListeChoixRow In Me.DsEvenements.ListeChoix
            Dim nomRes As String = dr.Valeur.Replace(" ", "_").Replace("-", "_").Replace("/", "_")
            Dim im As Image = CType(My.Resources.IconesTypeEv.ResourceManager.GetObject(nomRes), Image)
            If im Is Nothing Then
                im = My.Resources.IconesTypeEv.defaultEv
            End If
            ilTypeEv.Images.Add(dr.Valeur, im)
            ilTypeEv24.Images.Add(dr.Valeur, im)
        Next
        RemplirTreeView()
        ChargerAgenda()
    End Sub
    Private Sub ChargerAgenda()
        Dim currentKey As Decimal = -1

        If lvAgenda.FocusedItem IsNot Nothing Then
            If CType(lvAgenda.FocusedItem.Tag, DataRow).RowState <> DataRowState.Deleted AndAlso CType(lvAgenda.FocusedItem.Tag, DataRow).RowState <> DataRowState.Detached Then
                currentKey = CDec(CType(lvAgenda.FocusedItem.Tag, DataRow).Item("nEvenement"))
            End If
        End If

        If strTypeEntite IsNot Nothing Then
            If strTypeEntite = "Entreprise" Then
                'MODIF TV 17/02/2012
                EvenementTA.FillByClientSansOrdreInsertion(Me.DsEvenements.Evenement, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                EvenementPersonneDisplayTA.FillByClientSansOrdreInsertion(Me.DsEvenements.EvenementPersonneDisplay, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                'EvenementTA.FillByClient(Me.DsEvenements.Evenement, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                'EvenementPersonneDisplayTA.FillByClient(Me.DsEvenements.EvenementPersonneDisplay, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                '---------------------
            ElseIf strTypeEntite = "Personne" Then
                'MODIF TV 17/02/2012
                EvenementTA.FillAgendaSansOrdreInsertion(Me.DsEvenements.Evenement, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                EvenementPersonneDisplayTA.FillAgendaSansOrdreInsertion(Me.DsEvenements.EvenementPersonneDisplay, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                'EvenementTA.FillAgenda(Me.DsEvenements.Evenement, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                'EvenementPersonneDisplayTA.FillAgenda(Me.DsEvenements.EvenementPersonneDisplay, nEntite, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
                '--------------------
            End If
        Else
            'MODIF TV 17/02/2012
            EvenementTA.FillAgendaSansOrdreInsertion(Me.DsEvenements.Evenement, FrApplication.nUtilisateur, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
            EvenementPersonneDisplayTA.FillAgendaSansOrdreInsertion(Me.DsEvenements.EvenementPersonneDisplay, FrApplication.nUtilisateur, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
            'EvenementTA.FillAgenda(Me.DsEvenements.Evenement, FrApplication.nUtilisateur, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
            'EvenementPersonneDisplayTA.FillAgenda(Me.DsEvenements.EvenementPersonneDisplay, FrApplication.nUtilisateur, TbFilter.Checked, dtpSelDeb.Value.Date, dtpSelFin.Value.Date)
            '------------------------
        End If

        RemplirListView(currentKey)
    End Sub

    Private Sub RemplirTreeView()
        With Me.tvFiltre
            .Nodes.Clear()
            Dim rootNode As TreeNode = .Nodes.Add("Tous", "Tous", "defaultEv")
            For Each dr As DsEvenements.ListeChoixRow In Me.DsEvenements.ListeChoix
                'MODIF TV 03/02/2012
                If (dr.Valeur = "Ordre Insertion") Then
                    Continue For
                End If

                Dim n As TreeNode = rootNode.Nodes.Add(dr.Valeur, dr.Valeur)
                n.ImageKey = dr.Valeur
                n.SelectedImageKey = dr.Valeur
            Next
            rootNode.Checked = True
            rootNode.Expand()
        End With
    End Sub

    Private Sub RemplirListView(ByVal currentKey As Decimal)
        Dim currentLvi As ListViewItem
        With Me.lvAgenda
            .BeginUpdate()
            .Items.Clear()
            .Groups.Clear()
            '.BackColor = SystemColors.GradientInactiveCaption
            For Each dr As DsEvenements.EvenementRow In Me.DsEvenements.Evenement.Select("", "DateEv")
                If Not CheckFiltreType(dr.Type) Then Continue For
                Dim groupe As String = dr.DateEv.ToString("yyyyMMdd")
                If .Groups(groupe) Is Nothing Then
                    Dim g As ListViewGroup = .Groups.Add(groupe, dr.DateEv.ToString("D"))
                    g.HeaderAlignment = HorizontalAlignment.Right
                End If
                Dim lvi As New ListViewItem(dr.Libelle)
                With lvi
                    .Group = Me.lvAgenda.Groups(groupe)
                    .Tag = dr
                    .ImageKey = dr.Type
                    If Convert.ToString(dr("Priorite")) = "Important" Then
                        .ForeColor = Color.Red
                    End If
                    .SubItems.Add(GetSubItemText(dr.nEvenement))
                    If currentKey = dr.nEvenement Then currentLvi = lvi
                End With
                .Items.Add(lvi)
            Next
            .EndUpdate()
            If currentLvi IsNot Nothing Then
                currentLvi.Focused = True
                currentLvi.EnsureVisible()
            End If
        End With
    End Sub

    Private Function GetSubItemText(ByVal nEvenement As Decimal) As String
        Dim res As String = ""
        For Each dr As DsEvenements.EvenementPersonneDisplayRow In Me.DsEvenements.EvenementPersonneDisplay.Select("nEvenement=" & nEvenement)
            If res.Length > 0 Then res &= " - "
            res &= dr.Nom
        Next
        Return res & " "
    End Function

    Private filtresType As List(Of String)
    Private Function CheckFiltreType(ByVal type As String) As Boolean
        If filtresType Is Nothing OrElse filtresType.Count = 0 Then Return True
        Return filtresType.Contains(type)
    End Function
#End Region

#Region "Form events"
    Private _loaded As Boolean = False
    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        If strTypeEntite Is Nothing Then
            Me.dtpSelDeb.Value = Today
            Me.TbMois.Checked = True
        Else
            Me.TbMois.Checked = False
            Me.TbJour.Checked = False
            Me.TbSemaine.Checked = False
            Me.dtpSelDeb.Value = #1/1/2000#
            Me.dtpSelFin.Value = #1/1/2020#
        End If
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsEvenements.Evenement, Nothing, True)
        _loaded = True
    End Sub
#End Region

#Region "Choix de date"
    Private Sub TbJour_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles TbJour.Click, TbMois.Click, TbSemaine.Click
        If sender IsNot TbJour Then TbJour.Checked = False
        If sender IsNot TbSemaine Then TbSemaine.Checked = False
        If sender IsNot TbMois Then TbMois.Checked = False
        CType(sender, ToolStripButton).Checked = Not CType(sender, ToolStripButton).Checked
    End Sub

    Private Sub TbPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbPrev.Click
        IncrDate(-1)
    End Sub

    Private Sub TbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNext.Click
        IncrDate(1)
    End Sub

    Private Sub IncrDate(ByVal incr As Integer)
        If Me.TbMois.Checked Then
            Me.dtpSelDeb.Value = Me.dtpSelDeb.Value.AddMonths(incr * 1)
        ElseIf Me.TbSemaine.Checked Then
            Me.dtpSelDeb.Value = Me.dtpSelDeb.Value.AddDays(incr * 7)
        Else
            Me.dtpSelDeb.Value = Me.dtpSelDeb.Value.AddDays(incr)
        End If
    End Sub

    Private Sub TbJour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TbJour.CheckedChanged, TbMois.CheckedChanged, TbSemaine.CheckedChanged

        If Not (TbMois.Checked OrElse TbJour.Checked OrElse TbSemaine.Checked) Then
            Me.dtpSelFin.Visible = True
            Me.dtpSelFin.Enabled = True
            Me.lbSelFin.Visible = True
            TbPrev.Enabled = False
            TbNext.Enabled = False
        Else
            TbPrev.Enabled = True
            TbNext.Enabled = True
            Me.dtpSelFin.Enabled = False
            If sender Is Me.TbMois AndAlso Me.TbMois.Checked Then
                Dim dt As Date = New Date(dtpSelDeb.Value.Year, dtpSelDeb.Value.Month, 1)
                If dt <> Me.dtpSelDeb.Value Then
                    Me.dtpSelDeb.Value = dt
                Else
                    dtpSelDeb_ValueChanged(Nothing, EventArgs.Empty)
                End If
                Me.dtpSelFin.Visible = True
                Me.lbSelFin.Visible = True
            ElseIf sender Is Me.TbSemaine AndAlso Me.TbSemaine.Checked Then
                Dim dt As Date = dtpSelDeb.Value.AddDays(1 - CInt(dtpSelDeb.Value.DayOfWeek))
                If dt <> Me.dtpSelDeb.Value Then
                    Me.dtpSelDeb.Value = dt
                Else
                    dtpSelDeb_ValueChanged(Nothing, EventArgs.Empty)
                End If
                Me.dtpSelFin.Visible = True
                Me.lbSelFin.Visible = True
            ElseIf sender Is Me.TbJour AndAlso TbJour.Checked Then
                dtpSelDeb_ValueChanged(Nothing, EventArgs.Empty)
                Me.dtpSelFin.Visible = False
                Me.lbSelFin.Visible = False
            End If
        End If
    End Sub

    Private Sub dtpSelDeb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSelDeb.ValueChanged
        If Not _loaded Then Exit Sub
        If Me.TbMois.Checked Then
            Me.dtpSelFin.Value = Me.dtpSelDeb.Value.AddMonths(1).AddDays(-1)
        ElseIf Me.TbSemaine.Checked Then
            Me.dtpSelFin.Value = Me.dtpSelDeb.Value.AddDays(6)
        ElseIf Me.TbJour.Checked Then
            Me.dtpSelFin.Value = Me.dtpSelDeb.Value
        End If
        ChargerAgenda()
    End Sub

    Private Sub dtpSelFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpSelFin.ValueChanged
        If Not _loaded Then Exit Sub
        If Not dtpSelFin.Enabled Then Exit Sub
        ChargerAgenda()
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerPlaning()
    End Sub

    Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        ChargerAgenda()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.lvAgenda.FocusedItem Is Nothing Then Exit Sub
        If Me.lvAgenda.FocusedItem.Tag Is Nothing Then Exit Sub
        Try
            Dim dr As DsEvenements.EvenementRow = CType(Me.lvAgenda.FocusedItem.Tag, DsEvenements.EvenementRow)
            dr.Delete()
            'Enregistrement en base
            Using s As New SqlProxy
                s.ExecuteNonQuery(String.Format("DELETE FROM EvenementPersonne WHERE nEvenement={0}", dr.Item("nEvenement", DataRowVersion.Original)))
                s.ExecuteNonQuery(String.Format("DELETE FROM EvenementPiece WHERE nEvenement={0}", dr.Item("nEvenement", DataRowVersion.Original)))
            End Using
            EvenementTA.Update(Me.DsEvenements.Evenement)
            ChargerAgenda()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub TbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        Dim dt As Date = Me.dtpSelDeb.Value
        If Me.lvAgenda.FocusedItem IsNot Nothing AndAlso Me.lvAgenda.FocusedItem.Tag IsNot Nothing Then
            Dim dr As DsEvenements.EvenementRow = CType(Me.lvAgenda.FocusedItem.Tag, DsEvenements.EvenementRow)
            dt = dr.DateEv
        End If
        Dim fr As New FrEvenement()
        fr.DateEv = dt
        AddHandler fr.FormClosed, AddressOf ChildFormClosed
        AddHandler fr.SelectObject, AddressOf ChildFormSelectObject
        fr.Show(Me)
    End Sub

    Private Sub ChildFormSelectObject(ByVal nKey As Object)
        If nKey Is Nothing Then Exit Sub
        For Each lvi As ListViewItem In Me.lvAgenda.Items
            If lvi.Tag IsNot Nothing Then
                If CType(lvi.Tag, DsEvenements.EvenementRow).nEvenement = CDec(nKey) Then
                    lvi.Focused = True
                    lvi.EnsureVisible()
                    Exit For
                End If
            End If
        Next
    End Sub

#End Region

#Region "Listview"
    Private Sub lvAgenda_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAgenda.Resize
        If Not lvAgenda.TileSize.IsEmpty Then
            lvAgenda.TileSize = New Size(lvAgenda.Width - 25, lvAgenda.TileSize.Height)
        End If
    End Sub

    Private Sub lvAgenda_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAgenda.ItemActivate
        If lvAgenda.FocusedItem Is Nothing Then Exit Sub
        If lvAgenda.FocusedItem.Tag Is Nothing Then Exit Sub
        Dim dr As DsEvenements.EvenementRow = CType(lvAgenda.FocusedItem.Tag, DsEvenements.EvenementRow)
        Dim fr As New FrEvenement(CInt(dr.nEvenement))
        AddHandler fr.FormClosed, AddressOf ChildFormClosed
        fr.Show(Me)
    End Sub

    Private Sub ChildFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            ChargerAgenda()
        End If
    End Sub
#End Region

#Region " Treeview de filtrage "
    Private _waitForIt As Boolean = False
    Private Sub tvFiltre_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFiltre.AfterCheck
        If _waitForIt Then Exit Sub
        _waitForIt = True

        If e.Node.Checked Then
            For Each n As TreeNode In e.Node.Nodes
                n.Checked = True
                n.ForeColor = SystemColors.GrayText
            Next
        Else
            For Each n As TreeNode In e.Node.Nodes
                n.Checked = False
                n.ForeColor = SystemColors.WindowText
            Next
        End If
        _waitForIt = False
        Me.filtresType = New List(Of String)
        If e.Node.Name <> "Tous" OrElse Not e.Node.Checked Then
            For Each n As TreeNode In Me.tvFiltre.Nodes(0).Nodes
                If n.Checked Then Me.filtresType.Add(n.Name)
            Next
        End If
        Dim currentKey As Decimal = -1
        If lvAgenda.FocusedItem IsNot Nothing Then
            currentKey = CDec(CType(lvAgenda.FocusedItem.Tag, DataRow).Item("nEvenement"))
        End If
        RemplirListView(currentKey)
    End Sub

    Private Sub tvFiltre_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFiltre.BeforeCheck
        If e.Node.Parent Is Nothing Then Exit Sub
        If e.Node.Parent.Checked AndAlso e.Node.Checked Then e.Cancel = True
    End Sub
#End Region

    Private Sub ImprimerPlaning()

        Dim myDs As DataSet = New DataSet
        myDs.EnforceConstraints = False
        myDs.Merge(Me.DsEvenements.Evenement)
        myDs.Merge(Me.DsEvenements.EvenementPersonneDisplay)
        myDs.Tables("EvenementPersonneDisplay").TableName = "EvenementPersonne"
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s)
            DefinitionDonnees.Instance.Fill(myDs, "Personne", s)
        End Using

        Dim libSel As String = String.Format("du {0:dddd dd/MM/yy} au {1:dddd dd/MM/yy}", Me.dtpSelDeb.Value, Me.dtpSelFin.Value)
        If filtresType IsNot Nothing AndAlso filtresType.Count > 0 Then
            libSel &= String.Format(" de type {0}", String.Join(", ", filtresType.ToArray))
        End If
        If TbFilter.Checked Then
            libSel &= " non réalisé"
        End If
        If Me.strTypeEntite IsNot Nothing Then
            If Me.strTypeEntite = "Entreprise" Then
                Dim drEnt As DataRow = SelectSingleRow(myDs.Tables("Entreprise"), "nEntreprise=" & nEntite, "")
                If drEnt IsNot Nothing Then
                    libSel &= String.Format(" concernant {0}", drEnt("Nom"))
                End If
            Else
                Dim drPers As DataRow = SelectSingleRow(myDs.Tables("Personne"), "nPersonne=" & nEntite, "")
                If drPers IsNot Nothing Then
                    libSel &= String.Format(" concernant {0} {1}", drPers("Prenom"), drPers("Nom"))
                End If
            End If
        Else
            libSel &= " pour l'utilisateur " & FrApplication.Utilisateur
        End If

        Dim fr As FrFusion = GestionImpression.TrouverRapport(myDs, "RptPlanning.rpt")
        fr.LibelleSelection = libSel
        fr.Show()
    End Sub

End Class
