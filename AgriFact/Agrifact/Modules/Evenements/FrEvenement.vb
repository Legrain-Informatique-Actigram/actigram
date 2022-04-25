Imports GRC
Imports Actigram.Windows.Forms

Public Class FrEvenement
    Inherits GRC.FrBase
    Dim LstEvenementMove() As Object
    Dim momTableAjout As String
    Dim momCleTableAjout As String
    Dim cleAjout As List(Of Integer)
    Public Type As String
    Public TypeEv As String
    Public DateEv As Date
    Public Auteur As Object
    Public Libelle As String
    Public Observation As String
    Public Origine As Form
    Public nOrigine As String
    Public Action As Boolean = True

    Private nNiveau2 As Integer = -1
    Private bmpUser As Bitmap
    Private bmpUserAccounts As Bitmap


#Region " Ctor "
    Public Sub New()
        InitializeComponent()
        Me.id = -1
        AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nEvenementSouhaite As Integer)
        Me.New()
        id = nEvenementSouhaite
        AjouterEnregistrement = False
    End Sub

    Public Sub New(ByVal LibelleFenetre As String, ByVal strLibelle As String, ByVal nNiveau As Integer, ByVal LibelleTypeEv As String, ByVal strTypeEv As String, ByVal IsAction As Boolean)
        Me.New()
        Action = IsAction
        TypeEv = strTypeEv
        Libelle = strLibelle
        Type = LibelleTypeEv
        nNiveau2 = nNiveau
        AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nouveau As Boolean, Optional ByVal IsAction As Boolean = True)
        Me.New()
        AjouterEnregistrement = nouveau
        Action = IsAction
        TypeEv = Action.ToString
    End Sub

    Public Sub New(ByVal cleAjout As Integer, ByVal TableAjout As String, ByVal CleTableAjout As String)
        Me.New()
        Me.momTableAjout = TableAjout
        Me.momCleTableAjout = CleTableAjout
        Me.cleAjout = New List(Of Integer)
        Me.cleAjout.Add(cleAjout)
    End Sub

    Public Sub New(ByVal clesAjout As List(Of Integer), ByVal TableAjout As String, ByVal CleTableAjout As String)
        Me.New()
        Me.cleAjout = clesAjout
        momTableAjout = TableAjout
        momCleTableAjout = CleTableAjout
    End Sub

    'Public Sub New(ByVal nouveau As Boolean, ByVal lstEvenementSouhaite() As Object, ByVal TableAjout As String, ByVal CleTableAjout As String, ByVal strType As String, ByVal dt As Date, ByVal nAuteur As Object, ByVal strLibelle As String, ByVal strObservation As String, ByVal FrOrigine As Form, ByVal nFrOrigine As String)
    '    Me.New(momDataset)
    '    LstEvenementMove = lstEvenementSouhaite
    '    AjouterEnregistrement = nouveau
    '    momTableAjout = TableAjout
    '    momCleTableAjout = CleTableAjout
    '    Type = strType
    '    DateEv = dt
    '    Auteur = nAuteur
    '    Libelle = strLibelle
    '    Observation = strObservation
    '    Origine = FrOrigine
    '    nOrigine = nFrOrigine
    'End Sub
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
    Friend WithEvents EvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvPersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvPieceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents EvPersonneDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbAddPersonne As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSupprContact As System.Windows.Forms.ToolStripButton
    Friend WithEvents GradientCaption3 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents DsEvenements As AgriFact.DsEvenements
    Friend WithEvents EvenementPersonneDisplayTA As AgriFact.DsEvenementsTableAdapters.EvenementPersonneDisplayTA
    Friend WithEvents NEvenementPersonneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIconeType As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbAddEntreprise As System.Windows.Forms.ToolStripButton
    Friend WithEvents GestionControles1 As AgriFact.GestionControles
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbOrigine As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbImprimerListe As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuite As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Dim WithEvents frT As FrSituationEvenement
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrEvenement))
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbOrigine = New System.Windows.Forms.ToolStripButton
        Me.TbSuite = New System.Windows.Forms.ToolStripButton
        Me.TbImprimerListe = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.EvPersonneDataGridView = New System.Windows.Forms.DataGridView
        Me.NEvenementPersonneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColIconeType = New System.Windows.Forms.DataGridViewImageColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EvPersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEvenements = New AgriFact.DsEvenements
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.TbAddPersonne = New System.Windows.Forms.ToolStripButton
        Me.TbAddEntreprise = New System.Windows.Forms.ToolStripButton
        Me.TbSupprContact = New System.Windows.Forms.ToolStripButton
        Me.GradientCaption3 = New Ascend.Windows.Forms.GradientCaption
        Me.EvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EvPieceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EvenementPersonneDisplayTA = New AgriFact.DsEvenementsTableAdapters.EvenementPersonneDisplayTA
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.EvPersonneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvPersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEvenements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvPieceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ImageList24.Images.SetKeyName(8, "")
        Me.ImageList24.Images.SetKeyName(9, "")
        Me.ImageList24.Images.SetKeyName(10, "")
        Me.ImageList24.Images.SetKeyName(11, "")
        Me.ImageList24.Images.SetKeyName(12, "")
        Me.ImageList24.Images.SetKeyName(13, "")
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
        Me.GestionControles1.Location = New System.Drawing.Point(3, 30)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NomTableConfig = Nothing
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(449, 426)
        Me.GestionControles1.TabIndex = 1
        Me.GestionControles1.Table = "Evenement"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 170
        Me.GestionControles1.TypeRecherche = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbClose, Me.TbSave, Me.TbSuppr, Me.ToolStripSeparator1, Me.TbOrigine, Me.TbSuite, Me.TbImprimerListe})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(824, 39)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 36)
        Me.TbClose.Text = "Fermer"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save24
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 36)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbSuppr
        '
        Me.TbSuppr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuppr.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbSuppr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuppr.Name = "TbSuppr"
        Me.TbSuppr.Size = New System.Drawing.Size(27, 36)
        Me.TbSuppr.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'TbOrigine
        '
        Me.TbOrigine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbOrigine.Image = Global.AgriFact.My.Resources.Resources.prev24
        Me.TbOrigine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbOrigine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbOrigine.Name = "TbOrigine"
        Me.TbOrigine.Size = New System.Drawing.Size(28, 36)
        Me.TbOrigine.Text = "Origine"
        Me.TbOrigine.Visible = False
        '
        'TbSuite
        '
        Me.TbSuite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuite.Image = Global.AgriFact.My.Resources.Resources.next24
        Me.TbSuite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSuite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuite.Name = "TbSuite"
        Me.TbSuite.Size = New System.Drawing.Size(28, 36)
        Me.TbSuite.Text = "Suite"
        Me.TbSuite.Visible = False
        '
        'TbImprimerListe
        '
        Me.TbImprimerListe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImprimerListe.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimerListe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimerListe.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimerListe.Name = "TbImprimerListe"
        Me.TbImprimerListe.Size = New System.Drawing.Size(36, 36)
        Me.TbImprimerListe.Text = "Imprimer liste"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GradientPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Size = New System.Drawing.Size(824, 509)
        Me.SplitContainer1.SplitterDistance = 541
        Me.SplitContainer1.TabIndex = 7
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel1.Controls.Add(Me.GestionControles1)
        Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(455, 464)
        Me.GradientPanel1.TabIndex = 2
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
        Me.GradientCaption1.Size = New System.Drawing.Size(455, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Evènement"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.EvPersonneDataGridView)
        Me.Panel3.Controls.Add(Me.ToolStrip2)
        Me.Panel3.Controls.Add(Me.GradientCaption3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(279, 509)
        Me.Panel3.TabIndex = 28
        '
        'EvPersonneDataGridView
        '
        Me.EvPersonneDataGridView.AllowUserToAddRows = False
        Me.EvPersonneDataGridView.AllowUserToDeleteRows = False
        Me.EvPersonneDataGridView.AutoGenerateColumns = False
        Me.EvPersonneDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EvPersonneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEvenementPersonneDataGridViewTextBoxColumn, Me.ColIconeType, Me.NomDataGridViewTextBoxColumn})
        Me.EvPersonneDataGridView.DataSource = Me.EvPersonneBindingSource
        Me.EvPersonneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EvPersonneDataGridView.Location = New System.Drawing.Point(0, 24)
        Me.EvPersonneDataGridView.Name = "EvPersonneDataGridView"
        Me.EvPersonneDataGridView.ReadOnly = True
        Me.EvPersonneDataGridView.RowHeadersWidth = 25
        Me.EvPersonneDataGridView.Size = New System.Drawing.Size(255, 485)
        Me.EvPersonneDataGridView.TabIndex = 11
        '
        'NEvenementPersonneDataGridViewTextBoxColumn
        '
        Me.NEvenementPersonneDataGridViewTextBoxColumn.DataPropertyName = "nEvenementPersonne"
        Me.NEvenementPersonneDataGridViewTextBoxColumn.HeaderText = "nEvenementPersonne"
        Me.NEvenementPersonneDataGridViewTextBoxColumn.Name = "NEvenementPersonneDataGridViewTextBoxColumn"
        Me.NEvenementPersonneDataGridViewTextBoxColumn.ReadOnly = True
        Me.NEvenementPersonneDataGridViewTextBoxColumn.Visible = False
        '
        'ColIconeType
        '
        Me.ColIconeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColIconeType.HeaderText = ""
        Me.ColIconeType.Name = "ColIconeType"
        Me.ColIconeType.ReadOnly = True
        Me.ColIconeType.Width = 20
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EvPersonneBindingSource
        '
        Me.EvPersonneBindingSource.DataMember = "EvenementPersonneDisplay"
        Me.EvPersonneBindingSource.DataSource = Me.DsEvenements
        '
        'DsEvenements
        '
        Me.DsEvenements.DataSetName = "DsEvenements"
        Me.DsEvenements.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbAddPersonne, Me.TbAddEntreprise, Me.TbSupprContact})
        Me.ToolStrip2.Location = New System.Drawing.Point(255, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(24, 485)
        Me.ToolStrip2.TabIndex = 12
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TbAddPersonne
        '
        Me.TbAddPersonne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbAddPersonne.Image = Global.AgriFact.My.Resources.Resources.user
        Me.TbAddPersonne.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbAddPersonne.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbAddPersonne.Name = "TbAddPersonne"
        Me.TbAddPersonne.Size = New System.Drawing.Size(21, 20)
        Me.TbAddPersonne.Text = "Ajouter une personne"
        '
        'TbAddEntreprise
        '
        Me.TbAddEntreprise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbAddEntreprise.Image = Global.AgriFact.My.Resources.Resources.userAccounts
        Me.TbAddEntreprise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbAddEntreprise.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbAddEntreprise.Name = "TbAddEntreprise"
        Me.TbAddEntreprise.Size = New System.Drawing.Size(21, 19)
        Me.TbAddEntreprise.Text = "Ajouter une entreprise"
        '
        'TbSupprContact
        '
        Me.TbSupprContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSupprContact.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbSupprContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSupprContact.Name = "TbSupprContact"
        Me.TbSupprContact.Size = New System.Drawing.Size(21, 20)
        Me.TbSupprContact.Text = "Supprimer le participant"
        '
        'GradientCaption3
        '
        Me.GradientCaption3.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption3.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption3.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption3.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption3.Name = "GradientCaption3"
        Me.GradientCaption3.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption3.Size = New System.Drawing.Size(279, 24)
        Me.GradientCaption3.TabIndex = 1
        Me.GradientCaption3.Text = "Participants"
        '
        'EvenementPersonneDisplayTA
        '
        Me.EvenementPersonneDisplayTA.ClearBeforeFill = True
        '
        'FrEvenement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrEvenement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Evènement"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.EvPersonneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvPersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEvenements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvPieceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Props"
    Private _NomTable As String = "Evenement"
    Private _NomTableCle As String = "nEvenement"
    'Private _NomTableDetail As String = "EvenementPersonne"
    'Private _NomTableDetailCle As String = "nEvenementPersonne"
    'Private _NomLiaison As String = "EvenementEvenementPersonne"
    Private _NomTableDetail2 As String = "EvenementPiece"
    Private _NomTableDetailCle2 As String = "nEvenementPiece"
    Private _NomLiaison2 As String = "EvenementEvenementPiece"

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.EvenementBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.EvenementBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nEvenement() As Integer
        Get
            If Me.EvenementBindingSource.Position < 0 Then Return -1
            Return CInt(Me.CurrentDrv(_NomTableCle))
        End Get
    End Property
#End Region

#Region " Données "

    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            DefinitionDonnees.Instance.Fill(ds, "TelephoneEntreprise", s)
            DefinitionDonnees.Instance.Fill(ds, "Personne", s)
            DefinitionDonnees.Instance.Fill(ds, "Telephone", s)
            If CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("{0}={1}", _NomTableCle, Me.id)
                DefinitionDonnees.Instance.Fill(ds, _NomTable, s, where)
                With EvenementPersonneDisplayTA
                    .Connection = s.Connection
                    .Fill(Me.DsEvenements.EvenementPersonneDisplay, CDec(Me.id))
                End With
                Me.DsEvenements.EvenementPersonneDisplay.InitAutoIncrementSeed(EvenementPersonneDisplayTA)
                DefinitionDonnees.Instance.Fill(ds, _NomTableDetail2, s, where)
                With Me.EvenementBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With
                Me.TypeEv = Convert.ToString(Me.CurrentDrv("TypeEv"))
            ElseIf AjouterEnregistrement Then
                If TypeEv Is Nothing Then
                    TypeEv = Action.ToString
                End If
                DefinitionDonnees.Instance.FillSchema(ds, _NomTable, s)
                DefinitionDonnees.Instance.FillSchema(ds, _NomTableDetail2, s)
                EvenementPersonneDisplayTA.Connection = s.Connection
                Me.DsEvenements.EvenementPersonneDisplay.InitAutoIncrementSeed(EvenementPersonneDisplayTA)
                'Databinding
                With Me.EvenementBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With
                'Création de la nouvelle ligne
                Me.EvenementBindingSource.AddNew()
                With Me.CurrentDrv
                    .Item("DateCreation") = Now
                    .Item("Priorite") = "Normal"
                    .Item("DateEv") = Date.Today
                    .Item("TypeEv") = TypeEv
                    .Item("Realise") = Not Action
                    If Me.Type IsNot Nothing Then
                        .Item("Type") = Type
                    Else
                        .Item("Type") = DBNull.Value
                    End If
                    If FrApplication.nUtilisateur <> -1 Then
                        .Item("nPersonneAuteur") = FrApplication.nUtilisateur
                        .Item("nPersonneDestinataire") = FrApplication.nUtilisateur
                    End If
                    If GRC.FrBase.Autorisation <> "Tous" Then .Item("Dep") = GRC.FrBase.Autorisation
                    If Not Type Is Nothing Then .Item("Type") = Type
                    If Date.MinValue <> DateEv Then .Item("DateEv") = DateEv
                    If Not Auteur Is Nothing Then .Item("nPersonneAuteur") = Auteur
                    If Not Libelle Is Nothing Then .Item("Libelle") = Libelle
                    If Not Observation Is Nothing Then .Item("Observation") = Observation
                    If Not Origine Is Nothing Then .Item("Origine") = Origine
                    If Not nOrigine Is Nothing Then .Item("nOrigine") = nOrigine
                End With
                Me.EvenementBindingSource.EndEdit()
                If cleAjout IsNot Nothing Then
                    For Each cle As Integer In cleAjout
                        AjouterLigne(momTableAjout, cle)
                    Next
                End If
            End If
        End Using
        With Me.ds.Tables("Personne").Columns
            If Not .Contains("NomPrenom") Then .Add("NomPrenom", GetType(String), "Nom + iif(Prenom is null,'',' ' + Prenom)")
        End With
        DefinitionDonnees.Instance.CreateRelations(ds)

        ConfigDataTableEvents(Me.ds.Tables(_NomTable), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.DsEvenements.EvenementPersonneDisplay, AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables(_NomTableDetail2), AddressOf Datarowchanged, True)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        Select Case TypeEv
            Case "True"
                Me.Text = "Evènement"
                Me.GestionControles1.NuméroNiveau1 = 0
                Action = True
            Case "False"
                Me.Text = "Evènement"
                Me.GestionControles1.NuméroNiveau1 = 1
                Action = False
            Case "OrdreInsertion"
                Me.Text = "Insertions"
                Me.GestionControles1.NuméroNiveau1 = 5
                Action = True
        End Select
        With Me.EvPieceBindingSource
            .DataSource = Me.EvenementBindingSource
            .DataMember = _NomLiaison2
        End With

        Me.GestionControles1.SetDataSource(CType(Me.EvenementBindingSource.List, DataView))
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
            If Not Me.ds.HasChanges AndAlso Not Me.DsEvenements.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.EvenementBindingSource.EndEdit()
        Me.EvPersonneBindingSource.EndEdit()
        Me.EvPieceBindingSource.EndEdit()
        If Me.ds.HasChanges OrElse Me.DsEvenements.HasChanges Then
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
        Me.EvenementBindingSource.EndEdit()
        Me.EvPersonneBindingSource.EndEdit()
        Me.EvPieceBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {_NomTable, _NomTableDetail2}
            Using s As New SqlProxy
                EvenementPersonneDisplayTA.Connection = s.Connection
                EvenementPersonneDisplayTA.Update(Me.DsEvenements.EvenementPersonneDisplay.Select("", "", DataViewRowState.Deleted))
                For Each dr As DataRow In ds.Tables("Evenement").Select("", "", DataViewRowState.Deleted)
                    s.ExecuteNonQuery(String.Format("DELETE FROM EvenementPersonne WHERE nEvenement={0}", dr.Item("nEvenement", DataRowVersion.Original)))
                Next
                s.UpdateTables(ds, strNomTable)
                EvenementPersonneDisplayTA.Update(Me.DsEvenements.EvenementPersonneDisplay)
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

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                If ds.HasChanges AndAlso Not Me.Validate Then
                    If MsgBox("L'enregistrement est impossible, voulez-vous sortir en abandonnant les modifications ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        e.Cancel = False
                        Exit Sub
                    End If
                End If
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.EvenementBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nEvenement)
                End If
        End Select
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bmpUser = My.Resources.IconesTypeEv.user
        bmpUser.MakeTransparent(Color.Magenta)
        bmpUserAccounts = My.Resources.IconesTypeEv.userAccounts
        bmpUserAccounts.MakeTransparent(Color.Magenta)

        SetChildFormIcon(Me)
        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated
        ChargerDonnees()
        ApplyStyle(Me.EvPersonneDataGridView)
        If GRC.FrBase.LstAutorisation.Contains("Evenement") Then
            Dim Droits As Autorisations = CType(LstAutorisation("Evenement"), Autorisations)
            With Me.GestionControles1
                .AutoriseAjt = Droits.Ajt
                .AutoriseSuppr = Droits.Suppr
            End With
            Me.TbSuite.Enabled = Droits.Ajt
        End If
        If GRC.FrBase.LstAutorisation.Contains("Devis") Then
            Dim Droits As Autorisations
            Droits = CType(LstAutorisation("Devis"), Autorisations)
        End If
        MajBoutons()
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel1.Height = Math.Max(Me.SplitContainer1.Panel1.Height - Me.SplitContainer1.Panel1.Padding.Top - Me.SplitContainer1.Panel1.Padding.Bottom, Me.GestionControles1.Height + Me.GradientCaption1.Height)
        Me.GradientPanel1.Width = Me.SplitContainer1.Panel1.Width - 20
        Me.GestionControles1.Width = Me.GradientPanel1.ClientSize.Width
        GestionAutorisation()
    End Sub

    Private Sub SplitContainer1_Panel1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.Resize
        Me.GradientPanel1.Width = Me.SplitContainer1.Panel1.Width - 20
        Me.GestionControles1.Width = Me.GradientPanel1.ClientSize.Width
        Me.GradientPanel1.Height = Math.Max(Me.SplitContainer1.Panel1.Height - Me.SplitContainer1.Panel1.Padding.Top - Me.SplitContainer1.Panel1.Padding.Bottom, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.EvenementBindingSource.EndEdit()
    End Sub


    Private Sub EvPersonneDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles EvPersonneDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each dr As DataGridViewRow In EvPersonneDataGridView.Rows
                SetColIcone(dr)
            Next
        ElseIf e.ListChangedType = System.ComponentModel.ListChangedType.ItemAdded Then
            SetColIcone(EvPersonneDataGridView.CurrentRow)
        End If
    End Sub

    Private Sub SetColIcone(ByVal dr As DataGridViewRow)
        Select Case CType(dr.DataBoundItem, DataRowView)("Type").ToString
            Case "P" : Cast(Of DataGridViewImageCell)(dr.Cells(Me.ColIconeType.Index)).Value = bmpUser
            Case "E" : Cast(Of DataGridViewImageCell)(dr.Cells(Me.ColIconeType.Index)).Value = bmpUserAccounts
        End Select
    End Sub


#Region " Toolbar "
    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.EvenementBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbSuppr.Enabled = rowExists
        Me.TbImprimerListe.Enabled = rowExists
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        Try
            Me.EvenementBindingSource.RemoveCurrent()
            If UpdateBase() Then Me.Close()
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbNouveauDevis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.BindingContext(dv).Position <> -1 Then
        '    Dim nEntreprise As Object
        '    Dim nContact As Object
        '    For Each itl As ListViewItem In Me.GestionDetailListe1.ListView1.Items
        '        If itl.ImageIndex = 7 Then
        '            nContact = itl.Tag
        '        End If
        '        If itl.ImageIndex = 9 Then
        '            nEntreprise = itl.Tag
        '        End If
        '    Next
        'If nEntreprise Is Nothing Then
        '    If Not nContact Is Nothing Then
        '        Dim rw() As DataRow
        '        rw = ds.Tables("Employe").Select("nPersonne=" & Convert.ToString(nContact))
        '        If rw.GetUpperBound(0) >= 0 Then
        '            nEntreprise = rw(0).Item("nEntreprise")
        '        End If
        '    End If
        'End If

        'Dim FrD As New FrBonCommande(True, Me.ToString, Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nEvenement")), nEntreprise, nContact)
        'FrD.Owner = Me
        'FrD.Show()
        'End If
    End Sub

    Private Sub TbOrigine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOrigine.Click
        'If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        'If TbOrigine.Checked Then
        '    frT = New FrSituationEvenement(CType(Me.EvenementBindingSource.List, DataView))
        '    With frT
        '        .Owner = Me
        '        .StartPosition = FormStartPosition.Manual
        '        .Location = Me.PointToScreen(Me.GbDocument.Location)
        '        .Size = Me.GbDocument.Size
        '        .Show()
        '        .Situation(Me.nEvenement, "Evenement")
        '    End With
        'Else
        '    Dim fr As Form
        '    For Each fr In Me.OwnedForms
        '        If TypeOf fr Is FrSituationEvenement Then
        '            fr.Close()
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub TbSuite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuite.Click
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        '    SuiteADonner()
    End Sub

    Private Sub TbImprimerListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimerListe.Click
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        ImprimerListeCampagne()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

    Private Sub GestionAutorisation()
        If FrApplication.nUtilisateur = -1 Then Exit Sub
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub

        Dim drv As DataRowView = Me.CurrentDrv
        Dim ok As Boolean = False
        If Not IsDBNull(drv("nPersonneAuteur")) Then
            If CInt(drv.Item("nPersonneAuteur")) = FrApplication.nUtilisateur Then
                Me.GestionControles1.AutoriseNiveau(2)
                Me.TbAddPersonne.Enabled = True
                Me.TbSupprContact.Enabled = True
                If GRC.FrBase.LstAutorisation.Contains("Evenement") Then
                    Me.TbSuppr.Enabled = True
                    If Me.TbSuite.Enabled <> CType(LstAutorisation("Evenement"), Autorisations).Ajt Then
                        Me.TbSuite.Enabled = CType(LstAutorisation("Evenement"), Autorisations).Ajt
                    End If
                Else
                    Me.TbSuppr.Enabled = True
                    If Me.TbSuite.Enabled = False Then
                        Me.TbSuite.Enabled = True
                    End If
                End If
                ok = True
            End If
        End If
        If Not ok AndAlso Not IsDBNull(drv("nPersonneDestinataire")) Then
            If CInt(drv.Item("nPersonneDestinataire")) = FrApplication.nUtilisateur Then
                Me.GestionControles1.AutoriseNiveau(1)
                Me.TbAddPersonne.Enabled = False
                Me.TbSupprContact.Enabled = False
                Me.TbSuppr.Enabled = False
                If GRC.FrBase.LstAutorisation.Contains("Evenement") Then
                    If Me.TbSuite.Enabled <> CType(LstAutorisation("Evenement"), Autorisations).Ajt Then
                        Me.TbSuite.Enabled = CType(LstAutorisation("Evenement"), Autorisations).Ajt
                    End If
                Else
                    If Me.TbSuite.Enabled = False Then
                        Me.TbSuite.Enabled = True
                    End If
                End If
                ok = True
            End If
        End If
        If Not ok Then
            Me.GestionControles1.AutoriseNiveau(0)
            Me.TbAddPersonne.Enabled = False
            Me.TbSupprContact.Enabled = False
            Me.TbSuppr.Enabled = False
            If Me.TbSuite.Enabled = True Then
                Me.TbSuite.Enabled = False
            End If
        End If
    End Sub

    Private Sub ImprimerFicheContact()
        Dim myDs As DataSet = ds.Clone
        myDs.EnforceConstraints = False
        myDs.Merge(ds.Tables("Entreprise").Select())
        myDs.Merge(ds.Tables("Personne").Select())
        myDs.Merge(ds.Tables("TelephoneEntreprise").Select())
        myDs.Merge(ds.Tables("Telephone").Select())
        myDs.Merge(ds.Tables("Evenement").Select("nEvenement=" & Me.nEvenement))
        myDs.Merge(ds.Tables("EvenementPersonne").Select("nEvenement=" & Me.nEvenement & " And nPersonne Is Not Null"))

        Dim fr As FrFusion = GestionImpression.TrouverRapport(myDs, "RptFicheContactEv.rpt")
        fr.Show()

    End Sub

    Private Sub ImprimerListeCampagne()
        Dim nEvenement As Integer = Me.nEvenement

        Dim myDs As DataSet = ds.Clone
        myDs.EnforceConstraints = False
        myDs.Merge(ds.Tables("Evenement").Select("nEvenement=" & nEvenement))
        myDs.Merge(ds.Tables("EvenementPersonne").Select("nEvenement=" & nEvenement & " And nPersonne Is Null"))
        myDs.Merge(ds.Tables("Entreprise").Select())
        myDs.Merge(ds.Tables("TelephoneEntreprise").Select())
        For Each rwTmpI As DataRow In ds.Tables("EvenementPersonne").Select("nEvenement=" & nEvenement & " And nEntreprise Is Null")
            myDs.Merge(ds.Tables("Personne").Select("nPersonne=" & Convert.ToString(rwTmpI.Item("nPersonne"))))
            myDs.Merge(ds.Tables("Telephone").Select("nPersonne=" & Convert.ToString(rwTmpI.Item("nPersonne"))))
        Next

        Dim fr As FrFusion = GestionImpression.TrouverRapport(myDs, "RptCampagneEt.rpt")
        fr.Show()
    End Sub

#Region "OLD"
    'Private Sub SuiteADonner()
    '    If Me.BindingContext(dv).Position <> -1 Then
    '        CType(Me.BindingContext(dv).Current, DataRowView).Item("AContacter") = True
    '        If Convert.ToBoolean(CType(Me.BindingContext(dv).Current, DataRowView).Item("AContacter")) = True Then
    '            'Dim dv As DataView
    '            'dv = CType(Me.DataGrid1.DataSource, DataView)

    '            Me.BindingContext(dv).EndCurrentEdit()
    '            If dv.Table.DataSet.Tables("Evenement").Select("Origine='" & Me.ToString & "' And nOrigine='" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nEvenement")) & "'").GetUpperBound(0) < 0 Then

    '                Dim dtRow() As DataRow
    '                dtRow = dv.Table.DataSet.Tables("EvenementPersonne").Select("nEvenement=" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nEvenement")))

    '                Dim i As Integer

    '                Dim nbParticipant As Integer = dtRow.GetUpperBound(0)
    '                Dim ClientExist As Boolean = False

    '                If CType(Me.BindingContext(dv).Current, DataRowView).Row.Table.Columns.Contains("nClient") = True Then
    '                    If Not CType(Me.BindingContext(dv).Current, DataRowView).Item("nClient") Is DBNull.Value Then
    '                        nbParticipant += 1
    '                        ClientExist = True
    '                    End If
    '                End If

    '                Dim lst(nbParticipant) As Object

    '                If ClientExist = True Then
    '                    lst(nbParticipant) = Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nClient")) & "|Entreprise|nEntreprise"
    '                End If

    '                For i = 0 To dtRow.GetUpperBound(0)
    '                    If IsDBNull(dtRow(i).Item("nEntreprise")) = False Then
    '                        lst(i) = Convert.ToString(dtRow(i).Item("nEntreprise")) & "|Entreprise|nEntreprise"
    '                    Else
    '                        lst(i) = Convert.ToString(dtRow(i).Item("nPersonne")) & "|Personne|nPersonne"
    '                    End If
    '                Next

    '                Dim dtDate As Date
    '                Dim strLibelle As String = ""
    '                Dim strType As String = ""
    '                'If Not CType(Me.BindingContext(dv).Current, DataRowView).Item("DateContact") Is System.DBNull.Value Then
    '                '    dtDate = Convert.ToDateTime(CType(Me.BindingContext(dv).Current, DataRowView).Item("DateContact"))
    '                'End If
    '                'If Not CType(Me.BindingContext(dv).Current, DataRowView).Item("DateContact") Is System.DBNull.Value Then
    '                strLibelle = "Suite : " & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("Type"))
    '                'End If
    '                If Not CType(Me.BindingContext(dv).Current, DataRowView).Item("DateEv") Is System.DBNull.Value Then
    '                    strLibelle &= " du " & Convert.ToDateTime(CType(Me.BindingContext(dv).Current, DataRowView).Item("DateEv")).ToString("dd/MM/yyyy")
    '                End If
    '                'If Not CType(Me.BindingContext(dv).Current, DataRowView).Item("SuiteADonner") Is System.DBNull.Value Then
    '                '    strType = Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("SuiteADonner"))
    '                'End If
    '                Dim frEv As New FrEvenement(lst, "Entreprise", "nEntreprise", strType, dtDate, CType(Me.BindingContext(dv).Current, DataRowView).Item("nPersonneAuteur"), strLibelle, "", Me, Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item("nEvenement")))
    '                'frEv.MdiParent = Me.MdiParent
    '                frEv.Owner = Me
    '                frEv.Show()
    '            End If
    '        End If
    '    End If
    'End Sub


    'Private Sub RefreshTwParutionMultiple()
    '    Me.TwParutionMultiple.BeginUpdate()

    '    Me.TwParutionMultiple.Nodes.Clear()

    '    If Me.BindingContext(dv).Position <> -1 Then
    '        Dim drV As DataRowView
    '        drV = CType(Me.BindingContext(dv).Current, DataRowView)
    '        If Not drV.Item("nOrigine") Is DBNull.Value Then
    '            Dim rw() As DataRow
    '            rw = dv.Table.Select("nEvenement=" & Convert.ToString(drV.Item("nOrigine")))
    '            If rw.GetUpperBound(0) >= 0 Then
    '                Dim it As New TreeNode
    '                it.Text = Convert.ToString(rw(0).Item("Libelle")) & " " & Convert.ToDateTime(rw(0).Item("DateEv")).ToString("dd/MM/yy")
    '                it.Tag = rw(0).Item("nEvenement")
    '                Me.TwParutionMultiple.Nodes.Add(it)

    '                Dim rwChild() As DataRow
    '                rwChild = dv.Table.Select("nOrigine=" & Convert.ToString(drV.Item("nOrigine")))

    '                If rwChild.GetUpperBound(0) >= 0 Then
    '                    Dim rwC As DataRow
    '                    For Each rwC In rwChild
    '                        Dim itC As New TreeNode
    '                        If Convert.ToInt32(drV.Item("nEvenement")) = Convert.ToInt32(rwC.Item("nEvenement")) Then
    '                            itC.NodeFont = New Font(Me.TwParutionMultiple.Font, FontStyle.Bold)
    '                        End If
    '                        itC.Text = Convert.ToString(rwC.Item("Libelle")) & " " & Convert.ToDateTime(rwC.Item("DateEv")).ToString("dd/MM/yy")
    '                        itC.Tag = rwC.Item("nEvenement")
    '                        it.Nodes.Add(itC)
    '                    Next
    '                End If
    '            End If
    '        Else
    '            Dim rwChild() As DataRow
    '            rwChild = dv.Table.Select("nOrigine=" & Convert.ToString(drV.Item("nEvenement")))

    '            If rwChild.GetUpperBound(0) >= 0 Then

    '                Dim it As New TreeNode
    '                it.Text = Convert.ToString(drV.Item("Libelle")) & " " & Convert.ToDateTime(drV.Item("DateEv")).ToString("dd/MM/yy")
    '                it.Tag = drV.Item("nEvenement")
    '                it.NodeFont = New Font(Me.TwParutionMultiple.Font, FontStyle.Bold)
    '                Me.TwParutionMultiple.Nodes.Add(it)

    '                Dim rwC As DataRow
    '                For Each rwC In rwChild
    '                    Dim itC As New TreeNode
    '                    itC.Text = Convert.ToString(rwC.Item("Libelle")) & " " & Convert.ToDateTime(rwC.Item("DateEv")).ToString("dd/MM/yy")
    '                    itC.Tag = rwC.Item("nEvenement")
    '                    it.Nodes.Add(itC)
    '                Next
    '            End If
    '        End If
    '    End If
    '    Me.TwParutionMultiple.ExpandAll()

    '    Me.TwParutionMultiple.EndUpdate()
    'End Sub

    'Private Sub BtAjouterParution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim drv As DataRow

    '    drv = Me.dv.Table.NewRow

    '    drv.Item("DateCreation") = Now
    '    drv.Item("Priorite") = "Normal"
    '    drv.Item("DateEv") = Date.Today
    '    drv.Item("Realise") = False
    '    drv.Item("Origine") = Me.ToString
    '    If CType(Me.BindingContext(dv).Current, DataRowView).Item("nOrigine") Is DBNull.Value Then
    '        drv.Item("nOrigine") = CType(Me.BindingContext(dv).Current, DataRowView).Item("nEvenement")
    '    Else
    '        drv.Item("nOrigine") = CType(Me.BindingContext(dv).Current, DataRowView).Item("nOrigine")
    '    End If

    '    Dim cl As DataColumn

    '    For Each cl In drv.Table.Columns
    '        If drv.Item(cl.ColumnName) Is DBNull.Value Or drv.Item(cl.ColumnName).GetType.ToString = GetType(Boolean).ToString Then
    '            drv.Item(cl.ColumnName) = CType(Me.BindingContext(dv).Current, DataRowView).Item(cl.ColumnName)
    '        End If
    '    Next

    '    '* Facturation Par Parution
    '    'drv.Item("PrixHT") = DBNull.Value
    '    drv.Item("Facture") = False

    '    Me.dv.Table.Rows.Add(drv)

    '    'Me.RefreshTwParutionMultiple()
    'End Sub

    'Private Sub TwParutionMultiple_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
    '    Me.BindingContext(dv).Position = dv.Find(e.Node.Tag)
    '    Me.NavigationDataBindings1.PositionChanged()
    'End Sub
#End Region

#Region " Gestion des participants "
    Private dtRecherche As String
    Private myRecherche As FrRecherche
    Private Sub TbAddPersonne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TbAddPersonne.Click, TbAddEntreprise.Click
        If sender Is TbAddPersonne Then
            dtRecherche = "Personne"
        Else
            dtRecherche = "Entreprise"
        End If
        myRecherche = New FrRecherche(ds, dtRecherche)
        AddHandler myRecherche.AffectuerRecherche, AddressOf AffectuerRecherche
        myRecherche.Show()
    End Sub

    Private Sub AffectuerRecherche(ByVal critereRecherche As String)
        Dim strCle As String = "n" & dtRecherche
        Dim cols As New List(Of DataGridViewColumn)
        cols.Add(CreateColumn("Nom", "Nom", DataGridViewAutoSizeColumnMode.Fill))
        If dtRecherche = "Personne" Then
            cols.Add(CreateColumn("Prenom", "Prénom", DataGridViewAutoSizeColumnMode.AllCells))
        End If
        cols.Add(CreateColumn("CodePostal", "CP", DataGridViewAutoSizeColumnMode.AllCells))
        cols.Add(CreateColumn("Ville", "Ville", DataGridViewAutoSizeColumnMode.AllCells))

        Dim dv As New DataView(ds.Tables(dtRecherche), critereRecherche, "Nom", DataViewRowState.CurrentRows)
        Dim frSelection As New FrResultatRecherche(dv, strCle, cols)
        AddHandler frSelection.SelectLigne, AddressOf frSelection_SelectLigne
        frSelection.Show()
    End Sub

    Private Function CreateColumn(ByVal col As String, ByVal header As String, ByVal autosizemode As DataGridViewAutoSizeColumnMode) As DataGridViewTextBoxColumn
        Dim c As New DataGridViewTextBoxColumn
        c.HeaderText = header
        c.DataPropertyName = col
        c.AutoSizeMode = autosizemode
        Return c
    End Function

    Private Sub frSelection_SelectLigne(ByVal nKey As Object)
        AjouterLigne(dtRecherche, CInt(nKey))
        dtRecherche = Nothing
        If myRecherche IsNot Nothing Then
            myRecherche.Close()
            myRecherche = Nothing
        End If
    End Sub

    Private Sub AjouterLigne(ByVal dtRecherche As String, ByVal nKey As Integer)
        Me.EvPersonneBindingSource.AddNew()
        With CType(Me.EvPersonneBindingSource.Current, DataRowView)
            .Item("nEvenement") = Me.nEvenement
            .Item("n" & dtRecherche) = nKey
            Dim dr As DataRow = SelectSingleRow(Me.ds.Tables(dtRecherche), "n" & dtRecherche & "=" & nKey, "")
            If dr IsNot Nothing Then
                If dtRecherche = "Entreprise" Then
                    .Item("Nom") = dr("Nom")
                    .Item("Type") = "E"
                Else
                    .Item("Nom") = String.Format("{0} {1}", dr("Nom"), dr("Prenom")).Trim
                    .Item("Type") = "P"
                End If
            End If
        End With
        Me.EvPersonneBindingSource.EndEdit()
    End Sub

    Private Sub TbSupprContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSupprContact.Click
        Try
            Me.EvPersonneBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub
#End Region

End Class
