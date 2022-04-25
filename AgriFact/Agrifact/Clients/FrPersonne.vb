Imports GRC

Public Class FrPersonne
    Inherits GRC.FrBase


#Region "Ctors"
    'Public Sub New(ByRef momDataset As DataSet)
    '    Me.New()
    '    ds = momDataset
    '    nEntreprise = DBNull.Value
    'End Sub

    'Public Sub New(ByRef momDataset As DataSet, ByVal nEvenementSouhaite As Object)
    '    Me.New(momDataset)
    '    nEntreprise = nEvenementSouhaite
    'End Sub

    'Public Sub New(ByRef momDataset As DataSet, ByVal nouveau As Boolean)
    '    Me.New(momDataset)
    '    AjouterEnregistrement = nouveau
    'End Sub

    'Public Sub New(ByRef momDataset As DataSet, ByVal nouveau As Boolean, ByVal SelectnEntreprise As Object)
    '    Me.New(momDataset, nouveau)
    '    nEntreprise = SelectnEntreprise
    'End Sub

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nPersonne As Integer)
        Me.New()
        Me.id = nPersonne
        Me.AjouterEnregistrement = False
    End Sub

    Public Sub New(ByVal nEntreprise As Integer, ByVal nouveau As Boolean)
        Me.New()
        Me.nEntreprise = nEntreprise
        Me.AjouterEnregistrement = nouveau
    End Sub
#End Region

#Region "Props"
    Dim dv As DataView
    Dim nEntreprise As Integer

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.PersonneBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.PersonneBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nPersonne() As String
        Get
            Return Convert.ToString(Me.CurrentDrv("nPersonne"))
        End Get
    End Property
#End Region

#Region " Code généré par le Concepteur Windows Form "

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
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbMesEvents As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MesÉvènementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelÉvènementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientPanel3 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TelephoneDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As AgriFact.DatagridViewComboboxColumnCustom
    Friend WithEvents NumeroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTel As AgriFact.DataGridViewDisableButtonColumn
    Friend WithEvents navTels As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TelephoneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GestionControles1 As AgriFact.GestionControles
    Friend WithEvents GbAdresse As System.Windows.Forms.GroupBox
    Friend WithEvents GestionAdresseII1 As GRC.GestionAdresseII
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrPersonne))
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.GbAdresse = New System.Windows.Forms.GroupBox
        Me.GestionAdresseII1 = New GRC.GestionAdresseII
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbMesEvents = New System.Windows.Forms.ToolStripDropDownButton
        Me.MesÉvènementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouvelÉvènementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GradientPanel3 = New Ascend.Windows.Forms.GradientPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TelephoneDataGridView = New System.Windows.Forms.DataGridView
        Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeDataGridViewTextBoxColumn = New AgriFact.DatagridViewComboboxColumnCustom
        Me.NumeroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTel = New AgriFact.DataGridViewDisableButtonColumn
        Me.TelephoneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.navTels = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GbAdresse.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TelephoneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navTels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navTels.SuspendLayout()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'GestionControles1
        '
        Me.GestionControles1.AutorisationListe = Nothing
        Me.GestionControles1.Autorisations = ""
        Me.GestionControles1.AutoriseAjt = True
        Me.GestionControles1.AutoriseModif = True
        Me.GestionControles1.AutoriseSuppr = True
        Me.GestionControles1.AutoSize = True
        Me.GestionControles1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles1.DataSource = Nothing
        Me.GestionControles1.DsBase = Nothing
        Me.GestionControles1.FiltreAffichage = ""
        Me.GestionControles1.Label1Top = 10
        Me.GestionControles1.LabelLeft = 10
        Me.GestionControles1.LargeurText = 260
        Me.GestionControles1.LiaisonDonnees = True
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(3, 25)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(459, 326)
        Me.GestionControles1.TabIndex = 0
        Me.GestionControles1.Table = "Personne"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 150
        Me.GestionControles1.TypeRecherche = False
        '
        'GbAdresse
        '
        Me.GbAdresse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbAdresse.Controls.Add(Me.GestionAdresseII1)
        Me.GbAdresse.Location = New System.Drawing.Point(3, 25)
        Me.GbAdresse.Name = "GbAdresse"
        Me.GbAdresse.Size = New System.Drawing.Size(247, 120)
        Me.GbAdresse.TabIndex = 1
        Me.GbAdresse.TabStop = False
        Me.GbAdresse.Text = "Adresse"
        '
        'GestionAdresseII1
        '
        Me.GestionAdresseII1.db = Nothing
        Me.GestionAdresseII1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GestionAdresseII1.Livraison = False
        Me.GestionAdresseII1.Location = New System.Drawing.Point(3, 16)
        Me.GestionAdresseII1.Name = "GestionAdresseII1"
        Me.GestionAdresseII1.Size = New System.Drawing.Size(241, 101)
        Me.GestionAdresseII1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.ToolStripSeparator1, Me.TbMesEvents, Me.TbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(768, 34)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save24
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 31)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(27, 31)
        Me.TbDelete.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'TbMesEvents
        '
        Me.TbMesEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbMesEvents.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MesÉvènementsToolStripMenuItem, Me.NouvelÉvènementToolStripMenuItem})
        Me.TbMesEvents.Image = Global.AgriFact.My.Resources.Resources.Agenda
        Me.TbMesEvents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbMesEvents.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMesEvents.Name = "TbMesEvents"
        Me.TbMesEvents.Size = New System.Drawing.Size(40, 31)
        Me.TbMesEvents.Text = "Mes évènements"
        Me.TbMesEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MesÉvènementsToolStripMenuItem
        '
        Me.MesÉvènementsToolStripMenuItem.Name = "MesÉvènementsToolStripMenuItem"
        Me.MesÉvènementsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MesÉvènementsToolStripMenuItem.Text = "Mes évènements..."
        '
        'NouvelÉvènementToolStripMenuItem
        '
        Me.NouvelÉvènementToolStripMenuItem.Name = "NouvelÉvènementToolStripMenuItem"
        Me.NouvelÉvènementToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NouvelÉvènementToolStripMenuItem.Text = "Nouvel évènement..."
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 31)
        Me.TbClose.Text = "Fermer"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 357)
        Me.Panel1.TabIndex = 1
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(463, 357)
        Me.GradientPanel2.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(463, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Informations générales"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel3.Border = New Ascend.Border(1)
        Me.GradientPanel3.Controls.Add(Me.GroupBox1)
        Me.GradientPanel3.Controls.Add(Me.GradientCaption2)
        Me.GradientPanel3.Controls.Add(Me.GbAdresse)
        Me.GradientPanel3.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel3.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel3.Location = New System.Drawing.Point(503, 37)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(253, 357)
        Me.GradientPanel3.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TelephoneDataGridView)
        Me.GroupBox1.Controls.Add(Me.navTels)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 206)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Téléphones"
        '
        'TelephoneDataGridView
        '
        Me.TelephoneDataGridView.AutoGenerateColumns = False
        Me.TelephoneDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TelephoneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.NumeroDataGridViewTextBoxColumn, Me.ColTel})
        Me.TelephoneDataGridView.DataSource = Me.TelephoneBindingSource
        Me.TelephoneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelephoneDataGridView.Location = New System.Drawing.Point(27, 16)
        Me.TelephoneDataGridView.Name = "TelephoneDataGridView"
        Me.TelephoneDataGridView.RowHeadersWidth = 25
        Me.TelephoneDataGridView.Size = New System.Drawing.Size(217, 187)
        Me.TelephoneDataGridView.TabIndex = 1
        '
        'NEntrepriseDataGridViewTextBoxColumn
        '
        Me.NEntrepriseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
        Me.NEntrepriseDataGridViewTextBoxColumn.Width = 68
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
        Me.TypeDataGridViewTextBoxColumn.DisplayStyleForCurrentCellOnly = True
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Items.AddRange(New Object() {"Siège", "Portable", "Fax", "Téléphone", "Email", "Email1", "Email2", "Téléphone1", "Téléphone2"})
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'NumeroDataGridViewTextBoxColumn
        '
        Me.NumeroDataGridViewTextBoxColumn.DataPropertyName = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.HeaderText = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.Name = "NumeroDataGridViewTextBoxColumn"
        '
        'ColTel
        '
        Me.ColTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColTel.HeaderText = ""
        Me.ColTel.Image = Global.AgriFact.My.Resources.Resources.DialHS
        Me.ColTel.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ColTel.Name = "ColTel"
        Me.ColTel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColTel.ToolTipText = "Appeller"
        Me.ColTel.Width = 30
        '
        'navTels
        '
        Me.navTels.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.navTels.BindingSource = Me.TelephoneBindingSource
        Me.navTels.CountItem = Nothing
        Me.navTels.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.navTels.Dock = System.Windows.Forms.DockStyle.Left
        Me.navTels.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.navTels.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.navTels.Location = New System.Drawing.Point(3, 16)
        Me.navTels.MoveFirstItem = Nothing
        Me.navTels.MoveLastItem = Nothing
        Me.navTels.MoveNextItem = Nothing
        Me.navTels.MovePreviousItem = Nothing
        Me.navTels.Name = "navTels"
        Me.navTels.PositionItem = Nothing
        Me.navTels.Size = New System.Drawing.Size(24, 187)
        Me.navTels.TabIndex = 0
        Me.navTels.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(21, 20)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(21, 20)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'GradientCaption2
        '
        Me.GradientCaption2.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption2.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption2.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption2.Name = "GradientCaption2"
        Me.GradientCaption2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption2.Size = New System.Drawing.Size(253, 24)
        Me.GradientCaption2.TabIndex = 0
        Me.GradientCaption2.Text = "Coordonnées"
        '
        'FrPersonne
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(768, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrPersonne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiche Individu"
        Me.GbAdresse.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TelephoneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navTels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navTels.ResumeLayout(False)
        Me.navTels.PerformLayout()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            If CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("nPersonne={0}", Me.id)
                DefinitionDonnees.Instance.Fill(ds, "Personne", s, where)
                DefinitionDonnees.Instance.Fill(ds, "Telephone", s, where)
                If ds.Tables("Personne").Rows.Count > 0 Then
                    Dim dr As DataRow = ds.Tables("Personne").Rows(0)
                    If Not dr.IsNull("nEntreprise") Then
                        DefinitionDonnees.Instance.Fill(ds, "Entreprise", s, String.Format("nEntreprise={0}", dr("nEntreprise")))
                    End If
                End If
                Me.ds.AcceptChanges()
                With Me.PersonneBindingSource
                    .DataSource = ds
                    .DataMember = "Personne"
                End With
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, "Personne", s)
                DefinitionDonnees.Instance.FillSchema(ds, "Telephone", s)
                If nEntreprise > 0 Then
                    DefinitionDonnees.Instance.Fill(ds, "Entreprise", s, String.Format("nEntreprise={0}", Me.nEntreprise))
                End If
                'Valeurs par défaut
                With Me.ds.Tables("Personne").Columns
                    If GRC.FrBase.Autorisation <> "Tous" Then
                        .Item("Dep").DefaultValue = GRC.FrBase.Autorisation
                    End If
                    .Item("TypePersonne").DefaultValue = FiltreType
                    If nEntreprise > 0 Then
                        .Item("nEntreprise").DefaultValue = Me.nEntreprise
                    End If
                End With
                'Databinding
                With Me.PersonneBindingSource
                    .DataSource = ds
                    .DataMember = "Personne"
                End With
                'Création de la nouvelle ligne
                Me.PersonneBindingSource.AddNew()
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)
        ConfigDataTableEvents(Me.ds.Tables("Personne"), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables("Telephone"), AddressOf Datarowchanged, False)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        With Me.TelephoneBindingSource
            .SuspendBinding()
            .DataSource = Me.PersonneBindingSource
            .DataMember = "PersonneTelephone"
            .ResumeBinding()
        End With
        Me.TelephoneDataGridView.DataSource = Me.TelephoneBindingSource

        'Databinding
        Me.GestionControles1.SetDataSource(CType(Me.PersonneBindingSource.List, DataView))
        Me.GestionAdresseII1.db = Me.PersonneBindingSource.CurrencyManager
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        res = Me.GestionControles1.VerifContraintes
        If res Then
            res = MyBase.Validate()
        End If
        Return res
    End Function


    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If Not Me.ds.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.TelephoneBindingSource.EndEdit()
        Me.PersonneBindingSource.EndEdit()
        If Me.ds.HasChanges Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                Case MsgBoxResult.No
                    'On continue sans enregistrer
                Case MsgBoxResult.Yes
                    If Not Enregistrer() Then
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        'Enregistrer
        If Not Me.Validate() Then Return False
        Me.TelephoneBindingSource.EndEdit()
        Me.PersonneBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Personne", "Telephone"}
            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustRefreshTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                ds.EnforceConstraints = False
                Using s As New SqlProxy
                    s.Fill(ds, t)
                End Using
                ds.EnforceConstraints = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustUpdateTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                Using s As New SqlProxy
                    s.UpdateTable(ds, t)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub


#End Region

    Private Sub GestionDesDroits()
        If GRC.FrBase.LstAutorisation.Contains("General") Then
            Dim Droits As Autorisations = CType(LstAutorisation("General"), Autorisations)
            Me.TbDelete.Enabled = Droits.Suppr
            Me.GestionControles1.AutoriseModif = Droits.Modif
            Me.GestionControles1.AutoriseAjt = Droits.Ajt
            Me.GestionControles1.AutoriseSuppr = Droits.Suppr
            Me.TelephoneDataGridView.ReadOnly = Not Droits.Modif
            Me.GbAdresse.Enabled = Droits.Modif
        End If
        If GRC.FrBase.LstAutorisation.Contains("Evenement") Then
            Dim Droits As Autorisations = CType(LstAutorisation("Evenement"), Autorisations)
            Me.TbMesEvents.Enabled = Droits.Modif
        End If
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.PersonneBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbDelete.Enabled = rowExists
        Me.TbMesEvents.Enabled = rowExists
    End Sub

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.PersonneBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nEntreprise)
                End If
        End Select
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.PersonneBindingSource.EndEdit()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption2)

        Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False

        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated

        Me.GestionAdresseII1.ConnectionString = My.Settings.DefaultConnString

        ApplyStyle(Me.TelephoneDataGridView, False)
        With TelephoneDataGridView
            AddHandler .EditingControlShowing, AddressOf MakeComboDropDown
            AddHandler .CellValidating, AddressOf cellvalidating
        End With
        Me.TelephoneDataGridView.DataSource = Nothing

        With FrApplication.Modules
            Me.TbMesEvents.Visible = .ModuleEvenement
        End With

        ChargerDonnees()
        GestionDesDroits()
        MajBoutons()
    End Sub
#End Region

#Region "Gestion de la combobox du Type de téléphone"
    Private Sub MakeComboDropDown(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            cmb.DropDownStyle = ComboBoxStyle.DropDown
            Dim value As String = Convert.ToString(grid.CurrentCell.Value)
            If cmb.Items.IndexOf(value) = -1 Then
                cmb.Items.Add(value)
                Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.CurrentCell.OwningColumn, DataGridViewComboBoxColumn)
                If cmbCol IsNot Nothing Then cmbCol.Items.Add(value)
            End If
        End If
    End Sub

    Private Sub cellvalidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
        If e.ColumnIndex = Me.TypeDataGridViewTextBoxColumn.Index Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            If TypeOf grid.EditingControl Is DataGridViewComboBoxEditingControl Then
                Dim cmb As DataGridViewComboBoxEditingControl = CType(grid.EditingControl, DataGridViewComboBoxEditingControl)
                Dim value As String = cmb.Text
                If cmb.Items.IndexOf(value) = -1 Then
                    cmb.Items.Add(value)
                    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
                    If cmbCol IsNot Nothing Then cmbCol.Items.Add(value)
                End If
                grid.CurrentCell.Value = value
            End If
        ElseIf e.ColumnIndex = Me.NumeroDataGridViewTextBoxColumn.Index Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            Dim r As DataGridViewRow = grid.Rows(e.RowIndex)
            Dim cell As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells(Me.ColTel.Index))
            cell.ButtonVisible = Convert.ToString(e.FormattedValue).Length > 0
        End If
    End Sub


    Private Sub TelephoneEntrepriseDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles TelephoneDataGridView.DataBindingComplete
        If e.ListChangedType <> System.ComponentModel.ListChangedType.Reset Then Exit Sub
        For Each r As DataGridViewRow In Me.TelephoneDataGridView.Rows
            Dim cell As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells(Me.ColTel.Index))
            Dim vis As Boolean = False
            If r.DataBoundItem IsNot Nothing Then
                If TypeOf r.DataBoundItem Is DataRowView Then
                    If Convert.ToString(Cast(Of DataRowView)(r.DataBoundItem)("Numero")).Length > 0 Then
                        vis = True
                    End If
                End If
            End If
            cell.ButtonVisible = vis
        Next
    End Sub

    Private Sub TelephoneEntrepriseDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TelephoneDataGridView.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex <> ColTel.Index Then Exit Sub
        Dim r As DataGridViewRow = TelephoneDataGridView.Rows(e.RowIndex)
        If r.DataBoundItem Is Nothing Then Exit Sub
        If Cast(Of DataRowView)(r.DataBoundItem).IsNew Then Exit Sub
        Dim drTel As DataRow = Cast(Of DataRowView)(r.DataBoundItem).Row
        If Convert.ToString(drTel("Numero")).Length = 0 Then Exit Sub
        'TODO APPELLER NUMERO
        MsgBox(String.Format("Appeller le {0}", drTel("Numero")))
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        Try
            Me.PersonneBindingSource.RemoveCurrent()
            If UpdateBase() Then Me.Close()
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub MesÉvènementsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MesÉvènementsToolStripMenuItem.Click
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        With New FrAgenda("Personne", CInt(Me.nPersonne))
            .Show(Me)
        End With
    End Sub

    Private Sub NouvelÉvènementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelÉvènementToolStripMenuItem.Click
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        With New FrEvenement(CInt(Me.nPersonne), "Personne", "nPersonne")
            .Show(Me)
        End With
    End Sub
#End Region


    'Private Sub Form6_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    If FiltreType <> "" Then
    '        dv.RowFilter = "TypePersonne='" & FiltreType & "'"
    '    End If
    '    '* Filtre Departement
    '    If FiltreType <> "" Then
    '        If FiltrePlus <> "" Then
    '            dv.RowFilter += " And (" & FiltrePlus & ")"
    '        End If
    '    Else
    '        dv.RowFilter = FiltrePlus
    '    End If
    'End Sub

    'Private Sub ImprimerFiche()
    '    Dim fr As FrFusion
    '    Dim myDs As DataSet = ds.Clone

    '    myDs.Merge(ds.Tables("Personne").Select("nPersonne=" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nPersonne"))))
    '    myDs.Merge(ds.Tables("Entreprise").Select())
    '    myDs.Merge(ds.Tables("Employe").Select("nPersonne=" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nPersonne"))))
    '    myDs.Merge(ds.Tables("AdresseEntreprise").Select())
    '    myDs.Merge(ds.Tables("TelephoneEntreprise").Select())
    '    myDs.Merge(ds.Tables("Telephone").Select("nPersonne=" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nPersonne"))))
    '    '* Ajout Fiche Organisme
    '    myDs.Merge(ds.Tables("Devis").Select())
    '    myDs.Merge(ds.Tables("DetailDevis").Select())
    '    myDs.Merge(ds.Tables("Evenement").Select())
    '    myDs.Merge(ds.Tables("EvenementPersonne").Select("nPersonne=" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nPersonne"))))

    '    fr = GestionImpression.TrouverRapport(myDs, "RptLstEvOrganisme.rpt")
    '    fr.Show()

    'End Sub

End Class
