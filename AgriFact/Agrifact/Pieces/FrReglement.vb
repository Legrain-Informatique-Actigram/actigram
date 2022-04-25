Imports GRC
Imports Actigram.Windows.Forms
Imports System.Data.SqlClient

Public Class FrReglement
    Inherits GRC.FrBase

#Region "Ctor"
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nReglement As Integer)
        Me.New()
        Me.id = nReglement
        Me.AjouterEnregistrement = False
    End Sub

    Public Sub New(ByVal drfacture As DataRow)
        Me.New()
        lstFacture = New List(Of DataRow)
        lstFacture.Add(drfacture)
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal FacturesaRegler As List(Of DataRow))
        Me.New()
        lstFacture = FacturesaRegler
        Me.AjouterEnregistrement = True
    End Sub
#End Region

#Region "Props"
    Private lstFacture As List(Of DataRow)
    Private facturesToCheck As New List(Of Integer)
    Private EcartAutorise As Decimal = 5
    Private NomTable As String = "Reglement"
    Private NomTableDetail As String = "Reglement_Detail"
    Private NomTableFacture As String = "VFacture"
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStripFrReglementDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AffecterFacturesAReglementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nDetailReglement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.ReglBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.ReglBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nReglement() As Integer
        Get
            Return CInt(Me.CurrentDrv("nReglement"))
        End Get
    End Property

    Private _type As FrListeReglement.TypeReglement = FrListeReglement.TypeReglement.Vente
    Public Property TypeRegl() As FrListeReglement.TypeReglement
        Get
            Return _type
        End Get
        Set(ByVal value As FrListeReglement.TypeReglement)
            _type = value
        End Set
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
    Friend WithEvents GestionControles1 As GestionControles
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbAfficheRemise As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents FrReglementDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FrReglementDetailTA As AgriFact.DsPiecesTableAdapters.FrReglementDetailTA
    Friend WithEvents FrReglementDetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ReglBindingSource As System.Windows.Forms.BindingSource

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrReglement))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprimer = New System.Windows.Forms.ToolStripButton
        Me.TbAfficheRemise = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.FrReglementDetailDataGridView = New System.Windows.Forms.DataGridView
        Me.ContextMenuStripFrReglementDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AffecterFacturesAReglementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FrReglementDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.ReglBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FrReglementDetailTA = New AgriFact.DsPiecesTableAdapters.FrReglementDetailTA
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nDetailReglement = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.FrReglementDetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripFrReglementDetail.SuspendLayout()
        CType(Me.FrReglementDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReglBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ImageList24.Images.SetKeyName(14, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.TbClose, Me.ToolStripSeparator1, Me.TbImprimer, Me.TbAfficheRemise})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(561, 39)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(27, 36)
        Me.TbDelete.Text = "Supprimer"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'TbImprimer
        '
        Me.TbImprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImprimer.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimer.Name = "TbImprimer"
        Me.TbImprimer.Size = New System.Drawing.Size(36, 36)
        Me.TbImprimer.Text = "Imprimer"
        '
        'TbAfficheRemise
        '
        Me.TbAfficheRemise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbAfficheRemise.Image = Global.AgriFact.My.Resources.Resources.remise
        Me.TbAfficheRemise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbAfficheRemise.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbAfficheRemise.Name = "TbAfficheRemise"
        Me.TbAfficheRemise.Size = New System.Drawing.Size(36, 36)
        Me.TbAfficheRemise.Text = "Afficher la remise"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(8, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 352)
        Me.Panel1.TabIndex = 12
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.BorderColor = New Ascend.BorderColor(System.Drawing.Color.DarkOliveGreen)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(499, 349)
        Me.GradientPanel2.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.DarkOliveGreen)
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.Color.White
        Me.GradientCaption1.GradientHighColor = System.Drawing.Color.LightBlue
        Me.GradientCaption1.GradientLowColor = System.Drawing.Color.SteelBlue
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(499, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Réglement"
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
        Me.GestionControles1.LargeurText = 250
        Me.GestionControles1.LiaisonDonnees = True
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(3, 30)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NomTableConfig = Nothing
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(493, 316)
        Me.GestionControles1.TabIndex = 0
        Me.GestionControles1.Table = "Reglement"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 150
        Me.GestionControles1.TypeRecherche = False
        '
        'FrReglementDetailDataGridView
        '
        Me.FrReglementDetailDataGridView.AllowUserToAddRows = False
        Me.FrReglementDetailDataGridView.AllowUserToDeleteRows = False
        Me.FrReglementDetailDataGridView.AutoGenerateColumns = False
        Me.FrReglementDetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nDetailReglement, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.FrReglementDetailDataGridView.ContextMenuStrip = Me.ContextMenuStripFrReglementDetail
        Me.FrReglementDetailDataGridView.DataSource = Me.FrReglementDetailBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FrReglementDetailDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.FrReglementDetailDataGridView.Location = New System.Drawing.Point(8, 400)
        Me.FrReglementDetailDataGridView.Name = "FrReglementDetailDataGridView"
        Me.FrReglementDetailDataGridView.Size = New System.Drawing.Size(499, 120)
        Me.FrReglementDetailDataGridView.TabIndex = 14
        '
        'ContextMenuStripFrReglementDetail
        '
        Me.ContextMenuStripFrReglementDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AffecterFacturesAReglementToolStripMenuItem, Me.SupprimerToolStripMenuItem})
        Me.ContextMenuStripFrReglementDetail.Name = "ContextMenuStripFrReglementDetail"
        Me.ContextMenuStripFrReglementDetail.Size = New System.Drawing.Size(256, 48)
        '
        'AffecterFacturesAReglementToolStripMenuItem
        '
        Me.AffecterFacturesAReglementToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Factures
        Me.AffecterFacturesAReglementToolStripMenuItem.Name = "AffecterFacturesAReglementToolStripMenuItem"
        Me.AffecterFacturesAReglementToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AffecterFacturesAReglementToolStripMenuItem.Text = "Affecter des factures au règlement"
        Me.AffecterFacturesAReglementToolStripMenuItem.ToolTipText = "Affecter des factures au règlement"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'FrReglementDetailBindingSource
        '
        Me.FrReglementDetailBindingSource.DataMember = "FrReglementDetail"
        Me.FrReglementDetailBindingSource.DataSource = Me.DsPieces
        Me.FrReglementDetailBindingSource.Sort = "nFacture"
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrReglementDetailTA
        '
        Me.FrReglementDetailTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nfacture"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.Format = "C2"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° Facture"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "datefacture"
        DataGridViewCellStyle8.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'nDetailReglement
        '
        Me.nDetailReglement.DataPropertyName = "nDetailReglement"
        Me.nDetailReglement.HeaderText = "nDetailReglement"
        Me.nDetailReglement.Name = "nDetailReglement"
        Me.nDetailReglement.ReadOnly = True
        Me.nDetailReglement.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "nfacture"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.HeaderText = "N° Facture"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 83
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "datefacture"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 55
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "client"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn5.HeaderText = "Client"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "montantTTC"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn6.HeaderText = "Montant TTC"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 95
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "montant"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "C2"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn7.HeaderText = "Réglé"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'FrReglement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(561, 532)
        Me.ControlBox = False
        Me.Controls.Add(Me.FrReglementDetailDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrReglement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reglement"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.FrReglementDetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripFrReglementDetail.ResumeLayout(False)
        CType(Me.FrReglementDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReglBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            If TypeRegl = FrListeReglement.TypeReglement.Achat Then
                DefinitionDonnees.Instance.FillSchema(ds, "Reglement", s)
            End If
            If CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("nReglement={0}", Me.id)
                DefinitionDonnees.Instance.Fill(ds, NomTable, s, where)
                DefinitionDonnees.Instance.Fill(ds, NomTableDetail, s, where)
                With Me.ReglBindingSource
                    .DataSource = ds
                    .DataMember = NomTable
                End With
                If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
                    Me.FrReglementDetailTA.FillByReglementAchat(Me.DsPieces.FrReglementDetail, Me.nReglement)
                Else
                    Me.FrReglementDetailTA.FillByReglementVente(Me.DsPieces.FrReglementDetail, Me.nReglement)
                End If
                For Each dr As DataRow In Me.ds.Tables(NomTableDetail).Rows
                    facturesToCheck.Add(CInt(dr("nFacture")))
                Next
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, NomTable, s)
                DefinitionDonnees.Instance.FillSchema(ds, NomTableDetail, s)
                'Databinding
                With Me.ReglBindingSource
                    .DataSource = ds
                    .DataMember = NomTable
                End With
                'Création de la nouvelle ligne
                CreerReglement(lstFacture)
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)

        ConfigDataTableEvents(Me.ds.Tables(NomTable), AddressOf Datarowchanged, True)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        Me.GestionControles1.SetDataSource(CType(Me.ReglBindingSource.List, DataView))
        If Me.ReglBindingSource.Position >= 0 Then
            If (Me.TypeRegl = FrListeReglement.TypeReglement.Vente AndAlso CBool(Me.CurrentDrv("Depose"))) _
            OrElse (Me.TypeRegl = FrListeReglement.TypeReglement.Achat AndAlso CBool(Me.CurrentDrv("ExportCompta"))) Then
                Me.GestionControles1.Enabled = False
                Me.FrReglementDetailDataGridView.ReadOnly = True
                Me.FrReglementDetailDataGridView.ContextMenuStrip = Nothing
            End If
        End If
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
        Me.ReglBindingSource.EndEdit()
        If Me.ds.HasChanges Then
            If Not (Me.VerifierEscompte()) Then
                MsgBox("Enregistrement impossible; la somme de l'escompte et du règlement est différente de la somme TTC des factures ou de la somme des montants réglés.", MsgBoxStyle.Exclamation, "")

                e.Cancel = True
                Exit Sub
            End If

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
        Me.ReglBindingSource.EndEdit()

        'Dépot automatique des réglements de 0€, des Virements, Carte Bancaire et Prélèvements
        Dim mode As String = Convert.ToString(Me.CurrentDrv.Item("nMode")).ToLower
        If CDec(Me.CurrentDrv.Item("Montant")) = 0 Then
            If Me.ReglBindingSource.AllowEdit Then Me.CurrentDrv.Item("Depose") = True
        End If

        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {NomTable, NomTableDetail}

            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using

            ''Mise à jour des lignes de détail
            'Dim queryString As String = String.Empty
            'Dim montant As Decimal = 0

            'For Each detailDGVR As DataGridViewRow In Me.FrReglementDetailDataGridView.Rows
            '    Dim detailDR As DataRow = CType(detailDGVR.DataBoundItem, DataRowView).Row

            '    If Not (detailDR.IsNull("montant")) Then
            '        montant = CDec(detailDR("montant"))
            '    Else
            '        montant = 0
            '    End If

            '    Using s As New SqlProxy
            '        If (montant <> 0) Then
            '            queryString = String.Format("UPDATE [{0}] SET [Montant] = {1} WHERE nDetailReglement={2}", Me.NomTableDetail, Replace(montant.ToString(), ",", "."), detailDR.Item("nDetailReglement"))
            '        Else
            '            queryString = String.Format("DELETE FROM [{0}] WHERE nDetailReglement={1}", Me.NomTableDetail, detailDR.Item("nDetailReglement"))
            '        End If

            '        s.ExecuteNonQuery(queryString)
            '    End Using
            'Next

            'Marquer les factures comme réglées ou non dans la base
            If Not facturesToCheck Is Nothing Then
                Using dta As New DsPiecesTableAdapters.ReglementsTA
                    For Each nDevis As Integer In facturesToCheck
                        If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
                            dta.UpdateAFacturePaye(nDevis)
                        Else
                            dta.UpdateVFacturePaye(nDevis)
                        End If
                    Next
                End Using
            End If

            If Me.ReglBindingSource.Position >= 0 Then 'Au cas ou on serait en train d'enregistrer une suppression
                If Me.TypeRegl = FrListeReglement.TypeReglement.Vente Then
                    Dim curDrv As DataRowView = Me.CurrentDrv

                    'MODIF TV 10/02/2012 : 
                    Dim remiseAuto As Boolean = False

                    Using ModeReglement_DetailTA As New DsAgrifactTableAdapters.ModeReglement_DetailTableAdapter
                        Dim ModeReglement_DetailDT As DsAgrifact.ModeReglement_DetailDataTable = ModeReglement_DetailTA.GetDataByModeReglement(Convert.ToString(curDrv.Item("nMode")))

                        If (ModeReglement_DetailDT.Rows.Count > 0) Then
                            Dim ModeReglement_DetailDR As DsAgrifact.ModeReglement_DetailRow = CType(ModeReglement_DetailDT.Rows(0), DsAgrifact.ModeReglement_DetailRow)

                            remiseAuto = ModeReglement_DetailDR.RemiseAuto
                        End If
                    End Using

                    'Si le mode de règlement est en remise automatique, on crée une remise
                    'avec la banque associée au mode de règlement detail
                    If (remiseAuto) Then
                        If IsDBNull(curDrv.Item("Depose")) OrElse Not CBool(curDrv.Item("Depose")) Then
                            Using s As New SqlProxy
                                FrRemise.CreerRemise(curDrv.Row, s)
                                curDrv.Row("depose") = True
                                s.UpdateTable(ds, "Reglement")
                            End Using
                        End If
                    End If
                End If

                ''Dépot automatique des virements, carte bancaire et prélèvements
                'Select Case Convert.ToString(curDrv.Item("nMode")).ToLower
                '    Case "virement", "carte bancaire", "prélèvement"
                '        If IsDBNull(curDrv.Item("Depose")) OrElse Not CBool(curDrv.Item("Depose")) Then
                '            Using s As New SqlProxy
                '                FrRemise.CreerRemise(curDrv.Row, s)
                '                curDrv.Row("depose") = True
                '                s.UpdateTable(ds, "Reglement")
                '            End Using
                '        End If
                'End Select
                '---------------------------
            End If

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

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                If Not Me.Validate Then
                    If MsgBox("L'enregistrement est impossible, voulez-vous sortir en abandonnant les modifications ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        e.Cancel = False
                        Exit Sub
                    End If
                End If

                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.ReglBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nReglement)
                End If
        End Select
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        EcartAutorise = FrApplication.ValeurDefault.EcartReglement
        ApplyStyle(Me.FrReglementDetailDataGridView)
        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated

        Select Case Me.TypeRegl
            Case FrListeReglement.TypeReglement.Vente
                NomTable = "Reglement"
                NomTableFacture = "VFacture"
                Me.Text = "Règlement - Clients"
                Me.TbAfficheRemise.Visible = True
            Case FrListeReglement.TypeReglement.Achat
                NomTable = "AReglement"
                NomTableFacture = "AFacture"
                Me.Text = "Règlement - Fournisseurs"
                Me.TbAfficheRemise.Visible = False
        End Select
        NomTableDetail = NomTable & "_Detail"

        ChargerDonnees()
        MajBoutons()
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.ReglBindingSource.EndEdit()
        If TypeOf sender Is TextBox _
       AndAlso (CType(sender, TextBox).DataBindings(0).BindingMemberInfo.BindingField = "Montant" _
       Or CType(sender, TextBox).DataBindings(0).BindingMemberInfo.BindingField = "MontantEscompte") Then
            AffecterReglement()
        End If
    End Sub

    Private Sub Me_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '(Ctrl+M)
        If e.KeyCode = Keys.M And e.Modifiers = Keys.Control Then
            If Not (CBool(Me.CurrentDrv("ExportCompta"))) Then
                Me.GestionControles1.Enabled = True
                Me.FrReglementDetailDataGridView.ReadOnly = False
                Me.FrReglementDetailDataGridView.ContextMenuStrip = Me.ContextMenuStripFrReglementDetail
                MajBoutons()
            Else
                MsgBox("Modification impossible car le réglement a été exporté en comptabilité.", MsgBoxStyle.Information, "Réglement exporté en comptabilité")
            End If
        End If
    End Sub
#End Region

#Region "Toolbar"
    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.ReglBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)

        'MODIF TV 27/01/2012 : pas de suppression possible si règlement déposé
        Me.TbDelete.Enabled = rowExists AndAlso Me.GestionControles1.Enabled AndAlso Not (CBool(Me.CurrentDrv("Depose")))
        'Me.TbDelete.Enabled = rowExists AndAlso Me.GestionControles1.Enabled
        '-------------------------------------------------

        Me.TbImprimer.Enabled = rowExists
        TbAfficheRemise.Enabled = rowExists AndAlso CBool(Me.CurrentDrv("Depose"))
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        If Not (Me.VerifierEscompte()) Then
            MsgBox("Enregistrement impossible; la somme de l'escompte et du règlement est différente de la somme TTC des factures ou de la somme des montants réglés.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If

        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.ReglBindingSource.Position < 0 Then Exit Sub

        Try
            'AJOUT TV 27/01/2012
            'Si le règlement est déposé, impossibilité de le supprimer
            If (CBool(Me.CurrentDrv("Depose"))) Then
                MsgBox("Ce règlement a été déposé et appartient à une remise. Impossible de le supprimer.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If
            '----------------------------------------

            'Récupération de la liste des nFacture associés au règlement
            Dim lstFact As New List(Of Integer)

            For Each dr As DataRow In Me.ds.Tables(NomTableDetail).Select("nReglement=" & Me.nReglement)
                lstFact.Add(CInt(dr("nFacture")))
            Next

            Me.ReglBindingSource.RemoveCurrent()

            If UpdateBase() Then
                'Marquer toutes les factures associées au règlement comme non payées
                Using s As New SqlProxy
                    For Each nDevis As Integer In lstFact
                        s.ExecuteNonQuery(String.Format("UPDATE {0} SET paye=0 WHERE nDevis={1}", NomTableFacture, nDevis))
                    Next
                End Using

                Me.Close()
            End If
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
        If Me.ReglBindingSource.Position < 0 Then Exit Sub
        Me.ReglBindingSource.EndEdit()
        If Convert.ToString(Me.CurrentDrv("nMode")).ToLower = "traite" Then
            ImprimerTraite()
        End If
    End Sub

    Private Sub TbAfficheRemise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbAfficheRemise.Click
        If Me.ReglBindingSource.Position < 0 Then Exit Sub
        Using s As New SqlProxy
            Dim nRemise As Integer = s.ExecuteScalarInt("SELECT nRemise FROM Remise_Detail WHERE nReglement=" & Me.nReglement)
            If nRemise = 0 Then
                MsgBox("Pas de remise...", MsgBoxStyle.Information, "Attention")
            Else
                With New FrRemise(nRemise)
                    .Show(Me)
                End With
            End If
        End Using
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "FrReglementDetailDataGridView"
    Private Sub FrReglementDetailDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FrReglementDetailDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        AfficheFacture(CInt(Cast(Of DataRowView)(Me.FrReglementDetailBindingSource.Current).Item("nDevis")))
    End Sub

    Private Sub FrReglementDetailDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FrReglementDetailDataGridView.CellValueChanged
        If (e.RowIndex > -1) Then
            If CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

            'Mise à jour du montant de la ligne de détail
            If (FrReglementDetailDataGridView.Columns(e.ColumnIndex).DataPropertyName = "montant") Then
                Dim detailDR As DataRow = CType(CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem, DataRowView).Row

                Dim detailRgtDR() As DataRow = ds.Tables(Me.NomTableDetail).Select(String.Format("nDetailReglement={0}", detailDR("nDetailReglement")))

                For Each dr As DataRow In detailRgtDR
                    dr("montant") = detailDR("montant")
                Next

                MajBoutons()
            End If
        End If
    End Sub

    Private Sub FrReglementDetailDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles FrReglementDetailDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité 
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Decimal
            If (Me.FrReglementDetailDataGridView.Columns(FrReglementDetailDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Decimal)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle 
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If
        End If
    End Sub
#End Region

#Region "ContextMenuStripFrReglementDetail"
    Private Sub AffecterFacturesAReglementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AffecterFacturesAReglementToolStripMenuItem.Click
        Me.AffecterFacturesAReglement()
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If (Me.FrReglementDetailDataGridView.SelectedRows.Count > 0) Then
            Dim listeDetailReglementDR As New List(Of DataRow)

            For Each r As DataGridViewRow In Me.FrReglementDetailDataGridView.SelectedRows
                If r.DataBoundItem IsNot Nothing Then
                    listeDetailReglementDR.Add(Cast(Of DataRowView)(r.DataBoundItem).Row)
                End If
            Next

            Me.SupprimerDetailReglement(listeDetailReglementDR)
        End If
    End Sub
#End Region

#Region " Fonctionnel "
    Public Shared Sub GestionAvanceClient(ByVal nClient As Integer, ByRef lstFacture As List(Of DataRow), Optional ByVal msgIfNoAvance As Boolean = False)
        Dim avance As Decimal
        Dim avoirs As Decimal
        Using dta As New DsPiecesTableAdapters.ReglementsTA
            'Calculer l'avance du client (montant de réglement non affecté)
            avance = dta.GetAvanceClient(nClient).GetValueOrDefault
            'Calculer le montant des avoirs du client (montant des avoirs non affectés)
            avoirs = dta.GetAvoirsClient(nClient).GetValueOrDefault
        End Using

        'Si ni l'un ni l'autre
        If avance = 0 And avoirs = 0 Then
            If msgIfNoAvance Then MsgBox("Ce client ne compte ni acompte ni avoir.", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Sinon, afficher la liste qui fera le boulot
        Dim dlg As New FrReglementAvances
        With dlg
            .nClient = nClient
            .lstFactures = lstFacture
            .ShowDialog()
            lstFacture = New List(Of DataRow)(.lstFactures)
        End With
    End Sub

    Public Shared Sub CreerReglementIrrecouvrable(ByVal drFacture As DataRow)
        CreerReglementIrrecouvrable(New List(Of DataRow)(New DataRow() {drFacture}))
    End Sub

    Public Shared Sub CreerReglementIrrecouvrable(ByVal lstFacture As List(Of DataRow))
        If lstFacture.Count = 0 Then Exit Sub

        Dim type As FrListeReglement.TypeReglement = FrListeReglement.TypeReglement.Vente
        Dim _NomTable As String = "Reglement"
        Dim _NomTableDetail As String = "Reglement_Detail"
        Dim _NomTableFacture As String = "VFacture"
        Dim _NomLiaison As String = _NomTable & _NomTableDetail

        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.FillSchema(ds, _NomTable, s)
            DefinitionDonnees.Instance.FillSchema(ds, _NomTableDetail, s)
        End Using

        Dim nEntreprise As Long = -1
        'If Not IsDBNull(lstFacture(0)("nPayeur")) Then
        'nEntreprise = CLng(lstFacture(0)("nPayeur"))
        'Else
        nEntreprise = CLng(lstFacture(0)("nClient"))
        'End If

        'Créer le réglement
        Dim drRegl As DataRow
        drRegl = ds.Tables(_NomTable).NewRow
        With drRegl
            .Item("DateReglement") = Now.Date
            .Item("nEntreprise") = nEntreprise
            .Item("BanqueClient") = "créance irrécouvrable"
            .Item("nMode") = ""
            .Item("Depose") = True
            'Le réglement ne sera jamais exporté car pas de remise.
        End With
        ds.Tables(_NomTable).Rows.Add(drRegl)

        Dim strMontantTotal As Decimal = 0
        Dim dtDetail As DataTable = ds.Tables(_NomTableDetail)
        'Créer les réglements pour les factures
        For Each rwF As DataRow In lstFacture
            'Calculer le reste à payer sur cette facture
            Dim MtResteAPayer As Decimal = CalculerResteAPayer(type, CInt(rwF("nDevis")), CInt(drRegl("nReglement")))
            If MtResteAPayer <> 0 Then
                'Créer la ligne de Détail Réglement
                Dim dr As DataRow = ds.Tables(_NomTableDetail).NewRow
                With dr
                    .BeginEdit()
                    .Item("nReglement") = drRegl("nReglement")
                    .Item("nFacture") = rwF("nDevis")
                    .Item("Montant") = MtResteAPayer
                    .EndEdit()
                End With
                ds.Tables(_NomTableDetail).Rows.Add(dr)
            End If

            'Incrémenter le montant du chèque
            strMontantTotal += MtResteAPayer
        Next

        drRegl.Item("Montant") = strMontantTotal
        drRegl.EndEdit()

        'Enregistrement des données
        Using s As New SqlProxy
            s.UpdateTables(ds, New String() {_NomTable, _NomTableDetail})
        End Using
        Using dta As New DsPiecesTableAdapters.ReglementsTA
            For Each dr As DataRow In lstFacture
                dta.UpdateVFacturePaye(CInt(dr("nDevis")))
            Next
        End Using
    End Sub

    Private Sub CreerReglement(ByVal lstFacture As List(Of DataRow))
        'If lstFacture Is Nothing OrElse lstFacture.Count = 0 Then Exit Sub

        Dim nEntreprise As Long = -1
        Dim dtEntreprise As DataTable

        If lstFacture IsNot Nothing AndAlso lstFacture.Count > 0 Then
            If lstFacture(0).Table.Columns.Contains("nPayeur") AndAlso Not lstFacture(0).IsNull("nPayeur") Then
                nEntreprise = CLng(lstFacture(0)("nPayeur"))
            Else
                nEntreprise = CLng(lstFacture(0)("nClient"))
            End If
            Using s As New SqlProxy
                dtEntreprise = s.ExecuteDataTable("SELECT * FROM Entreprise WHERE nEntreprise=" & nEntreprise, "Entreprise")
            End Using
        End If

        'Créer le réglement
        Me.ReglBindingSource.AddNew()
        Dim drvRegl As DataRowView = Me.CurrentDrv
        With drvRegl
            .Item("DateReglement") = Now.Date
            .Item("nMode") = "Chèque" 'Par défaut
            If nEntreprise >= 0 Then
                .Item("nEntreprise") = nEntreprise
                If dtEntreprise.Rows.Count > 0 Then
                    Dim drEnt As DataRow = dtEntreprise.Rows(0)
                    If dtEntreprise.Columns.Contains("Banque") Then
                        If Not drEnt.IsNull("Banque") Then
                            .Item("BanqueClient") = drEnt("Banque")
                        End If
                    End If
                    If dtEntreprise.Columns.Contains("ModePaiement") _
                    AndAlso Not drEnt.IsNull("ModePaiement") Then
                        .Item("nMode") = drEnt("ModePaiement")
                    End If
                End If
            End If
        End With
        Me.ReglBindingSource.EndEdit()

        Me.DsPieces.FrReglementDetail.Clear()
        If lstFacture IsNot Nothing AndAlso lstFacture.Count > 0 Then
            Dim dtDetail As DataTable = Me.ds.Tables(NomTableDetail)
            Me.FrReglementDetailTA.ClearBeforeFill = False

            Dim strMontantTotal As Decimal = 0
            'Créer les réglements pour les factures
            For Each rwF As DataRow In lstFacture
                'Calculer le reste à payer sur cette facture
                Dim MtResteAPayer As Decimal = CalculerResteAPayer(CInt(rwF("nDevis")), CInt(drvRegl("nReglement")))
                If MtResteAPayer <> 0 Then
                    'Créer la ligne de Détail Réglement
                    Dim drDetail As DataRow = dtDetail.NewRow
                    With drDetail
                        .Item("nReglement") = drvRegl("nReglement")
                        .Item("nFacture") = rwF("nDevis")
                        .Item("Montant") = MtResteAPayer
                    End With
                    dtDetail.Rows.Add(drDetail)
                End If
                'Incrémenter le montant du chèque
                strMontantTotal += MtResteAPayer
                If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
                    Me.FrReglementDetailTA.FillDummyByFactureAchat(Me.DsPieces.FrReglementDetail, CInt(rwF("nDevis")), MtResteAPayer)
                Else
                    Me.FrReglementDetailTA.FillDummyByFactureVente(Me.DsPieces.FrReglementDetail, CInt(rwF("nDevis")), MtResteAPayer)
                End If
                facturesToCheck.Add(CInt(rwF("nDevis")))
            Next

            drvRegl("Montant") = strMontantTotal
            Me.ReglBindingSource.EndEdit()
        End If
    End Sub

    Private Sub AffecterReglement()
        'TODO GERER LES ESCOMPTES
        Dim drvRegl As DataRowView = Me.CurrentDrv

        Dim dMontantDetail As Decimal = 0
        Dim dMontantAvoir As Decimal = 0

        'Calculer pour les factures du réglement, la somme des reste à payer (pertes) et des avoirs (profits)
        For Each rwDetail As DataRow In ds.Tables(NomTableDetail).Select(String.Format("nReglement={0}", drvRegl.Item("nReglement")))
            Dim MtResteAPayer As Decimal = CalculerResteAPayer(CInt(rwDetail("nFacture")), CInt(drvRegl("nReglement")))
            If MtResteAPayer < 0 Then
                dMontantAvoir += MtResteAPayer
            Else
                dMontantDetail += MtResteAPayer
            End If
        Next

        'Le montant qu'on peut régler est le montant du réglement plus la somme des avoirs dispos 
        '(qu'on retranche vu qu'ils sont en négatifs)
        Dim dMontantDispo As Decimal = 0
        If Not IsDBNull(drvRegl.Item("Montant")) Then dMontantDispo = CDec(drvRegl.Item("Montant"))
        dMontantDispo -= dMontantAvoir

        'On ajoute le montant de l'escompte saisi au montant du règlement
        If Not IsDBNull(drvRegl.Item("MontantEscompte")) Then
            dMontantDispo = dMontantDispo + Convert.ToDecimal(drvRegl.Item("MontantEscompte"))
        End If

        Dim rwLast As DataRow
        'Pour chaque ligne de détail du reglement (triés par montant décroissant : les avoirs en dernier)
        For Each rwDetail As DataRow In ds.Tables(NomTableDetail).Select(String.Format("nReglement={0}", drvRegl("nReglement")), "Montant Desc")
            'Dim rwFacture As DataRow = rwDetail.GetParentRow(_NomLiaisonFactureReglement)
            Dim drAffiche As DsPieces.FrReglementDetailRow = SelectSingleRow(Of DsPieces.FrReglementDetailRow)(Me.DsPieces.FrReglementDetail, String.Format("nDevis={0}", rwDetail("nFacture")), "")
            'Calculer le reste à payer
            Dim MtResteAPayer As Decimal = CalculerResteAPayer(CInt(rwDetail("nFacture")), CInt(drvRegl("nReglement")))

            'On annule les eventuels pertes et profits existant
            rwDetail("Perte") = DBNull.Value
            rwDetail("Profit") = DBNull.Value

            If MtResteAPayer >= 0 Then 'S'il y a du reste à payer sur la facture
                If dMontantDispo >= MtResteAPayer Then 'S'il y a assez dispo, on règle la facture
                    rwDetail("Montant") = MtResteAPayer
                    dMontantDispo -= MtResteAPayer
                    MtResteAPayer = 0
                Else
                    'Sinon on affecte tout le dispo
                    rwDetail("Montant") = dMontantDispo
                    MtResteAPayer -= dMontantDispo
                    dMontantDispo = 0

                    'Si ce qui reste à payer est dans la marge autorisée, on le passe en perte
                    If MtResteAPayer < EcartAutorise Then
                        If drAffiche IsNot Nothing Then
                            Dim msg As String = String.Format("Il reste {0:C2} sur {1:C2} à payer pour la facture n°{2}." & vbCrLf & "Les passer en perte ?", MtResteAPayer, drAffiche("MontantTTC"), drAffiche("nFacture"))
                            If MsgBox(msg, MsgBoxStyle.YesNo, "Perte & Profit") = MsgBoxResult.Yes Then
                                rwDetail("Perte") = MtResteAPayer
                                rwDetail("Montant") = CDec(rwDetail("Montant")) + MtResteAPayer
                            End If
                        End If
                    End If
                End If
            Else 'Sinon (la facture est un avoir à affecter)
                'S'il restait du dispo, on le déduit du montant d'avoir
                If dMontantDispo > 0 Then
                    dMontantAvoir += dMontantDispo
                    dMontantDispo = 0
                End If

                If dMontantAvoir <= MtResteAPayer Then
                    'S'il y a assez d'avoir, on règle la facture
                    rwDetail("Montant") = MtResteAPayer
                    dMontantAvoir -= MtResteAPayer
                Else
                    'Sinon on affecte tout l'avoir qui nous reste, il en reste 
                    rwDetail("Montant") = dMontantAvoir
                    dMontantAvoir = 0
                End If
            End If
            rwLast = rwDetail
            drAffiche.montant = CDec(rwDetail("Montant"))
        Next

        'On n'affecte un profit qu'une fois toutes les factures passées
        'Le profit est mis sur la derniere facture (celle dont le montant de reglement est le plus faible)
        If dMontantDispo + dMontantAvoir > 0 And dMontantDispo + dMontantAvoir < EcartAutorise Then
            If dMontantDispo <> dMontantDetail Then 'Cas ou rien n'a été affecté ?
                Dim msg As String = String.Format("Il reste {0:C2} non affectés sur ce réglement." & vbCrLf & "Les passer en profit ?", dMontantDispo)
                If MsgBox(msg, MsgBoxStyle.YesNo, "Perte & Profit") = MsgBoxResult.Yes Then
                    rwLast("Profit") = dMontantDispo
                    rwLast("Perte") = DBNull.Value
                End If
            End If
        End If

        'Calculer les pertes et profits totaux pour le réglement
        drvRegl("Profit") = ds.Tables(NomTableDetail).Compute("Sum(Profit)", String.Format("nReglement={0}", drvRegl("nReglement")))
        drvRegl("Perte") = ds.Tables(NomTableDetail).Compute("Sum(Perte)", String.Format("nReglement={0}", drvRegl("nReglement")))
        drvRegl.EndEdit()
    End Sub

    Private Function CalculerResteAPayer(ByVal nDevis As Integer, ByVal nReglement As Integer) As Decimal
        Return CalculerResteAPayer(Me.TypeRegl, nDevis, nReglement)
    End Function

    Private Shared Function CalculerResteAPayer(ByVal type As FrListeReglement.TypeReglement, ByVal nDevis As Integer, ByVal nReglement As Integer) As Decimal
        Using dta As New DsPiecesTableAdapters.ReglementsTA
            If type = FrListeReglement.TypeReglement.Vente Then
                Return dta.GetResteAReglerVente(nDevis, nReglement).GetValueOrDefault
            Else
                Return dta.GetResteAReglerAchat(nDevis, nReglement).GetValueOrDefault
            End If
        End Using
    End Function

    Private Sub AfficheFacture(ByVal nDevis As Integer)
        With New FrBonCommande(nDevis)
            If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
                .TypePiece = Pieces.TypePieces.AFacture
            Else
                .TypePiece = Pieces.TypePieces.VFacture
            End If
            .Owner = Me
            .Show()
        End With
    End Sub

    Private Sub ImprimerTraite()
        Dim drv As DataRowView = Me.CurrentDrv
        Dim nReglement As Long = Me.nReglement

        Dim myDs As DataSet = ds.Clone
        With myDs
            .EnforceConstraints = False
            .Merge(New DataRow() {Me.CurrentDrv.Row})
        End With
        Dim tel As String = ""
        Dim siret As String = ""
        Dim ville As String = ""
        Dim facture As String = ""
        'Dim dateEcheance As String = ""
        Dim dateEcheance As Date
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(myDs, "Parametres", s)
            DefinitionDonnees.Instance.Fill(myDs, "Banque", s)
            DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s)
            Dim sql As String = "SELECT Ville,Observations,Numero " & _
                                "FROM Entreprise e LEFT JOIN TelephoneEntreprise t ON e.nEntreprise=t.nEntreprise " & _
                                "WHERE TypeClient='Entreprise'"
            Using dr As SqlClient.SqlDataReader = s.ExecuteReader(sql)
                If dr.Read Then
                    tel = Convert.ToString(dr("Numero"))
                    siret = Convert.ToString(dr("Observations"))
                    ville = Convert.ToString(dr("Ville"))
                End If
            End Using
            sql = "SELECT nFacture " & _
           "FROM  Reglement_Detail " & _
                               "WHERE nReglement=" & nReglement
            Using dr As SqlClient.SqlDataReader = s.ExecuteReader(sql)
                If dr.Read Then
                    facture = Convert.ToString(dr("nFacture"))
                End If
            End Using

            sql = "SELECT nFacture " & _
            "FROM  VFacture " & _
            "WHERE nDevis=" & facture
            Using dr As SqlClient.SqlDataReader = s.ExecuteReader(sql)
                If dr.Read Then
                    facture = Convert.ToString(dr("nFacture"))
                End If
            End Using


            sql = "SELECT DateEcheance " & _
           "FROM  VFacture " & _
           "WHERE nFacture=" & facture
            Using dr As SqlClient.SqlDataReader = s.ExecuteReader(sql)
                If dr.Read Then

                    dateEcheance = Convert.ToDateTime(dr("DateEcheance"))


                End If
            End Using
        End Using

        Dim fr As FrFusion = GestionImpression.TrouverRapport(myDs, "RptTraite.rpt")
        GestionImpression.AppliquerParametres(fr, myDs)
        With fr.Parametres
            .SetValue("Tel", tel)
            .SetValue("Siret", siret)
            .SetValue("Ville", ville)
            .SetValue("facture", facture)
            .SetValue("dateEch", dateEcheance)
        End With
        fr.Show()
    End Sub

    Private Sub AffecterFacturesAReglement()
        If (Me.Enregistrer()) Then
            Me.MajBoutons()

            Me.id = Me.nReglement

            Dim drvRegl As DataRowView = Me.CurrentDrv
            Dim nEntreprise As Decimal = 0
            Dim nReglement As Decimal = 0

            If Not (IsDBNull(drvRegl("nEntreprise"))) Then
                nEntreprise = CDec(drvRegl("nEntreprise"))
            End If

            If Not (IsDBNull(drvRegl("nReglement"))) Then
                nReglement = CDec(drvRegl("nReglement"))
            End If

            Dim listeFacturesDR As New List(Of DataRow)

            For Each r As DataGridViewRow In Me.FrReglementDetailDataGridView.Rows
                If r.DataBoundItem IsNot Nothing Then
                    listeFacturesDR.Add(Cast(Of DataRowView)(r.DataBoundItem).Row)
                End If
            Next

            If ((nEntreprise > 0) And (nReglement > 0)) Then
                Dim fr As New FrAffecterFacturesAReglement(nEntreprise, nReglement, listeFacturesDR, Me.NomTableDetail, Me.NomTableFacture, Me.TypeRegl)

                With fr
                    .ShowDialog()
                End With

                'Rechargement des lignes de détail
                Me.RechargerLignesDetailReglement()
            Else
                MsgBox("Veuillez sélectionner un tiers.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If
        End If
    End Sub

    Private Sub SupprimerDetailReglement(ByVal listeDR As List(Of DataRow))
        If (listeDR.Count > 0) Then
            Using rgtsTA As New DsPiecesTableAdapters.ReglementsTA
                Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                    sqlConn.Open()

                    Using sqlComm As New SqlCommand
                        sqlComm.Connection = sqlConn

                        For Each dr As DataRow In listeDR
                            'Suppression de la ligne de détail
                            sqlComm.CommandText = String.Format("DELETE FROM {0} WHERE nDetailReglement={1}", Me.NomTableDetail, dr("nDetailReglement"))

                            sqlComm.ExecuteNonQuery()

                            'Gestion de l'indicateur Paye de la facture
                            If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
                                rgtsTA.UpdateAFacturePaye(CInt(dr("nDevis")))
                            Else
                                rgtsTA.UpdateVFacturePaye(CInt(dr("nDevis")))
                            End If
                        Next
                    End Using
                End Using
            End Using
        End If
        
        'Rechargement des lignes de détail
        Me.RechargerLignesDetailReglement()
    End Sub

    Private Sub RechargerLignesDetailReglement()
        Me.DsPieces.FrReglementDetail.Clear()

        If Me.TypeRegl = FrListeReglement.TypeReglement.Achat Then
            Me.FrReglementDetailTA.FillByReglementAchat(Me.DsPieces.FrReglementDetail, Me.nReglement)
        Else
            Me.FrReglementDetailTA.FillByReglementVente(Me.DsPieces.FrReglementDetail, Me.nReglement)
        End If

        Dim where As String = String.Format("nReglement={0}", Me.id)

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(Me.ds, NomTableDetail, s, where)
        End Using
    End Sub

    Private Sub EditingControlDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = CType(sender, DataGridViewTextBoxEditingControl).Text

        'On s'assure que le point ou la virgule n'a été tapé qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du séparateur décimal utilisé dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub

    Private Function VerifierEscompte() As Boolean
        Dim curDrv As DataRowView = Me.CurrentDrv
        Dim rgtDR As DataRow = curDrv.Row
        Dim montantRgt As Decimal = 0
        Dim montantEscompte As Decimal = 0

        If Not (rgtDR.IsNull("MontantEscompte")) Then
            montantEscompte = CDec(rgtDR("MontantEscompte"))
            If Not (rgtDR.IsNull("Montant")) Then
                montantRgt = CDec(rgtDR("Montant"))
            End If

            'Récupération de la liste des détails
            Dim sommeMontantRegle As Decimal = 0
            Dim sommeMontantTTC As Decimal = 0

            For Each detailDGVR As DataGridViewRow In Me.FrReglementDetailDataGridView.Rows
                Dim detailDR As DataRow = CType(detailDGVR.DataBoundItem, DataRowView).Row

                If Not (detailDR.IsNull("montant")) Then
                    sommeMontantRegle = sommeMontantRegle + CDec(detailDR("montant"))
                End If

                If Not (detailDR.IsNull("montantTTC")) Then
                    sommeMontantTTC = sommeMontantTTC + CDec(detailDR("montantTTC"))
                End If
            Next

            'formattage montnat escompte : seulement 2 chiffres après la virgule
            montantEscompte = Math.Round(montantEscompte, 2)

            rgtDR("MontantEscompte") = montantEscompte

            'Vérification que montant escompte + montant règlement = somme montants TTC factures 
            '= somme des montants réglés
            If (montantEscompte + montantRgt <> sommeMontantRegle) Or (montantEscompte + montantRgt <> sommeMontantTTC) Then
                Return False
            End If
        End If

        Return True
    End Function

    'Private Sub GererAvances(ByVal lstFacture() As DataRow, ByVal nEntreprise As Long)
    '    'Gestion de l'utilisation des avances pour le règlement des factures en cours
    '    Dim dtRegl As DataTable = ds.Tables(_NomTable)
    '    Dim dtDetail As DataTable = ds.Tables(_NomTableDetail)

    '    Dim sbMsg As New System.Text.StringBuilder

    '    'Pour chaque reglement du payeur
    '    Dim rwAvance() As DataRow = dtRegl.Select(String.Format("nEntreprise={0}", nEntreprise))
    '    For Each rwRgl As DataRow In rwAvance
    '        If Not IsDBNull(rwRgl("Montant")) Then
    '            'Calculer le montant réglé par le règlement sur les factures
    '            Dim Result As Object = ds.Tables(_NomTableDetail).Compute("Sum(Montant)", "nReglement=" & Convert.ToString(rwRgl.Item("nReglement")))
    '            If Not IsDBNull(Result) Then
    '                'Calculer le montant du réglement moins le profit eventuel
    '                Dim MontantRegl As Decimal = CDec(rwRgl("Montant"))
    '                If Not IsDBNull(rwRgl("Profit")) Then
    '                    MontantRegl -= CDec(rwRgl("Profit"))
    '                End If
    '                'Si le montant du réglement est supérieur au montant réglé, il y a une avance
    '                If MontantRegl > CDec(Result) Then
    '                    Dim Avance As Decimal = MontantRegl - CDec(Result)

    '                    'Pour chaque facture à régler
    '                    For Each rwF As DataRow In lstFacture
    '                        'S'il y a un reste à payer, affecter l'avance nécessaire à cette facture
    '                        Dim MtResteAPayer As Decimal = CalculerResteAPayer(rwF, CLng(rwRgl("nReglement")))
    '                        If MtResteAPayer > 0 Then
    '                            Dim rwND As DataRow = dtDetail.NewRow
    '                            With rwND
    '                                .Item("nReglement") = rwRgl("nReglement")
    '                                .Item("nFacture") = rwF("nDevis")
    '                                If Avance >= MtResteAPayer Then
    '                                    .Item("Montant") = MtResteAPayer
    '                                    Avance -= MtResteAPayer
    '                                    rwF("Paye") = True
    '                                    sbMsg.AppendFormat(vbCrLf & "- Facture n°{0} du {1:dd/MM/yyyy}", rwF("nFacture"), rwF("dateFacture"))
    '                                Else
    '                                    .Item("Montant") = Avance
    '                                    Avance = 0
    '                                End If
    '                            End With
    '                            dtDetail.Rows.Add(rwND)
    '                        End If

    '                        'Si on n'a plus d'avance, on sort
    '                        If Avance = 0 Then Exit For
    '                    Next
    '                End If
    '            End If
    '        End If
    '    Next
    '    'Avertir l'utilisateur de l'utilisation des avances
    '    If sbMsg.Length > 0 Then
    '        MsgBox("Les factures suivantes ont été réglées par les avances : " & vbCrLf & sbMsg.ToString, MsgBoxStyle.Information, "Réglement")
    '    End If
    'End Sub

#End Region

End Class
