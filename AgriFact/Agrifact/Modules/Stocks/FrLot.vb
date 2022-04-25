Imports System.Data.SqlClient

Public Class FrLot
    Inherits GRC.FrBase

    Private _nlot As String
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents IdLotProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeProduitDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Private _InfosModifiees As Boolean = False

#Region "Propriétés"
    Public Property NLot() As String
        Get
            Return _nlot
        End Get
        Set(ByVal value As String)
            _nlot = value
        End Set
    End Property

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.LotBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.LotBindingSource.Current)
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal nLot As String)
        Me.New()
        Me.NLot = nLot
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
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents LotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents LotProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StocksDataSet As AgriFact.StocksDataSet
    Friend WithEvents DataGridViewLotProduit As System.Windows.Forms.DataGridView
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As AgriFact.StocksDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents GestionControles1 As AgriFact.GestionControles
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrLot))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.LotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridViewLotProduit = New System.Windows.Forms.DataGridView
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.ProduitTableAdapter = New AgriFact.StocksDataSetTableAdapters.ProduitTableAdapter
        Me.LotProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdLotProduitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NLotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeProduitDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridViewLotProduit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Code"
        Me.DataGridTextBoxColumn2.MappingName = "CodeProduitComposition"
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Libellé"
        Me.DataGridTextBoxColumn1.MappingName = "LibelleProduitComposition"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Quantité"
        Me.DataGridTextBoxColumn3.MappingName = "Qt"
        Me.DataGridTextBoxColumn3.Width = 50
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbClose, Me.TbSave, Me.TbSuppr, Me.ToolStripSeparator1, Me.TbImpr})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(907, 39)
        Me.ToolStrip1.TabIndex = 9
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
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(36, 36)
        Me.TbImpr.Text = "Imprimer la fiche traça"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 408)
        Me.Panel1.TabIndex = 11
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
        Me.GradientPanel2.Size = New System.Drawing.Size(414, 408)
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
        Me.GradientCaption1.Size = New System.Drawing.Size(414, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Informations générales"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridViewLotProduit)
        Me.Panel2.Controls.Add(Me.GradientCaption2)
        Me.Panel2.Location = New System.Drawing.Point(432, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(463, 408)
        Me.Panel2.TabIndex = 12
        '
        'DataGridViewLotProduit
        '
        Me.DataGridViewLotProduit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewLotProduit.AutoGenerateColumns = False
        Me.DataGridViewLotProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLotProduit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdLotProduitDataGridViewTextBoxColumn, Me.NLotDataGridViewTextBoxColumn, Me.CodeProduitDataGridViewComboBoxColumn})
        Me.DataGridViewLotProduit.DataSource = Me.LotProduitBindingSource
        Me.DataGridViewLotProduit.Location = New System.Drawing.Point(3, 30)
        Me.DataGridViewLotProduit.Name = "DataGridViewLotProduit"
        Me.DataGridViewLotProduit.Size = New System.Drawing.Size(457, 375)
        Me.DataGridViewLotProduit.TabIndex = 2
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
        Me.GradientCaption2.Size = New System.Drawing.Size(463, 24)
        Me.GradientCaption2.TabIndex = 1
        Me.GradientCaption2.Text = "Produit(s) associé(s)"
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.StocksDataSet
        Me.ProduitBindingSource.Sort = "CodeProduit ASC"
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'LotProduitBindingSource
        '
        Me.LotProduitBindingSource.DataSource = GetType(AgriFact.Stocks.LotProduit)
        '
        'GestionControles1
        '
        Me.GestionControles1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.GestionControles1.Location = New System.Drawing.Point(3, 33)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NomTableConfig = Nothing
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(408, 375)
        Me.GestionControles1.TabIndex = 8
        Me.GestionControles1.Table = "Lot"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 115
        Me.GestionControles1.TypeRecherche = False
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "CodeProduit"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.ProduitBindingSource
        Me.DataGridViewComboBoxColumn1.DisplayMember = "Libelle"
        Me.DataGridViewComboBoxColumn1.HeaderText = "Libellé"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.ValueMember = "CodeProduit"
        Me.DataGridViewComboBoxColumn1.Width = 250
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "LibelleProduit"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.HeaderText = "LibelleProduit"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'IdLotProduitDataGridViewTextBoxColumn
        '
        Me.IdLotProduitDataGridViewTextBoxColumn.DataPropertyName = "IdLotProduit"
        Me.IdLotProduitDataGridViewTextBoxColumn.HeaderText = "IdLotProduit"
        Me.IdLotProduitDataGridViewTextBoxColumn.Name = "IdLotProduitDataGridViewTextBoxColumn"
        Me.IdLotProduitDataGridViewTextBoxColumn.Visible = False
        '
        'NLotDataGridViewTextBoxColumn
        '
        Me.NLotDataGridViewTextBoxColumn.DataPropertyName = "nLot"
        Me.NLotDataGridViewTextBoxColumn.HeaderText = "nLot"
        Me.NLotDataGridViewTextBoxColumn.Name = "NLotDataGridViewTextBoxColumn"
        Me.NLotDataGridViewTextBoxColumn.Visible = False
        '
        'CodeProduitDataGridViewComboBoxColumn
        '
        Me.CodeProduitDataGridViewComboBoxColumn.DataPropertyName = "CodeProduit"
        Me.CodeProduitDataGridViewComboBoxColumn.DataSource = Me.ProduitBindingSource
        Me.CodeProduitDataGridViewComboBoxColumn.DisplayMember = "ProduitDisplay"
        Me.CodeProduitDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.CodeProduitDataGridViewComboBoxColumn.HeaderText = "Code Produit"
        Me.CodeProduitDataGridViewComboBoxColumn.Name = "CodeProduitDataGridViewComboBoxColumn"
        Me.CodeProduitDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodeProduitDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CodeProduitDataGridViewComboBoxColumn.ValueMember = "CodeProduit"
        Me.CodeProduitDataGridViewComboBoxColumn.Width = 400
        '
        'FrLot
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(907, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrLot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lots"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridViewLotProduit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Données "
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)

            If Me.NLot IsNot Nothing Then
                DefinitionDonnees.Instance.Fill(ds, "Lot", s, SqlProxy.FormatSql("nLot={0}", Me.NLot))

                With Me.LotBindingSource
                    .DataSource = ds
                    .DataMember = "Lot"
                End With

                'Chargement des produits associés au lot
                Me.LotProduitBindingSource.DataSource = Stocks.ListeLotsProduits.ListeLotsProduitsParnLot(Me.NLot)
            Else
                DefinitionDonnees.Instance.FillSchema(ds, "Lot", s)

                'Databinding
                With Me.LotBindingSource
                    .DataSource = ds
                    .DataMember = "Lot"
                End With

                'Création de la nouvelle ligne
                Me.LotBindingSource.AddNew()

                With Me.CurrentDrv
                    .Item("DateCreation") = Today
                End With
            End If
        End Using

        ConfigDataTableEvents(Me.ds.Tables("Lot"), AddressOf Datarowchanged, True)
        DataBinding()

        'Chargement des produits actifs
        Me.ProduitTableAdapter.FillByInactif(Me.StocksDataSet.Produit, False)
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub DataBinding()
        Me.GestionControles1.SetDataSource(CType(Me.LotBindingSource.List, DataView))
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean

        res = Me.GestionControles1.VerifContraintes

        'If res Then
        'res = MyBase.Validate()
        'End If

        Return res
    End Function

    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If (Not (Me.ds.HasChanges) Or Not (Me._InfosModifiees)) Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.LotBindingSource.EndEdit()
        If (Me.ds.HasChanges Or Me._InfosModifiees) Then
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
        Me.LotBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Lot"}

            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using

            If Not (Me.CurrentDrv Is Nothing) Then
                If Not (Me.CurrentDrv.Item("nLot") Is Nothing) Then
                    If Not (Me.CurrentDrv.Item("nLot").ToString() = String.Empty) Then
                        Me.EnregistrerLotProduit()
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region " Form Events "
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.LotBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.NLot)
                End If
        End Select
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        If Me.Validate Then Me.LotBindingSource.EndEdit()
        'Me.LotBindingSource.EndEdit()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated
        ChargerDonnees()
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = (Me.ds.HasChanges Or Me._InfosModifiees)
        Dim rowExists As Boolean = (Me.LotBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbSuppr.Enabled = rowExists
        Me.TbImpr.Enabled = rowExists
    End Sub
#End Region

#Region " Toolbar "
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.LotBindingSource.Position < 0 Then Exit Sub

        Try
            Dim nLot As String = Me.CurrentDrv.Item("nLot").ToString()

            Me.LotBindingSource.RemoveCurrent()
            Me.SupprimerLotProduit(nLot)

            If UpdateBase() Then
                Me.Close()
            End If
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerFicheTraca()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "LotProduitBindingSource"
    Private Sub LotProduitBindingSource_ListChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles LotProduitBindingSource.ListChanged
        Select Case e.ListChangedType
            Case System.ComponentModel.ListChangedType.ItemAdded, System.ComponentModel.ListChangedType.ItemChanged, System.ComponentModel.ListChangedType.ItemDeleted
                If (Me.Validate()) Then
                    Me._InfosModifiees = True
                    Me.MajBoutons()
                End If
        End Select
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ImprimerFicheTraca()
        If Not Me.Enregistrer Then Exit Sub
        ImprimerFicheTraca(Me, Convert.ToString(Me.CurrentDrv("nLot")))
    End Sub

    Public Shared Sub ImprimerFicheTraca(ByVal ownerForm As Form, ByVal ParamArray nLots() As String)
        If FrApplication.Parametres.ImpressionSQLServer Then
            MsgBox("Impression non disponible.", MsgBoxStyle.Exclamation, "Erreur")
        Else
            Dim myDs As New DataSet
            Using s As New SqlProxy
                For Each nLot As String In nLots
                    s.FillBy(myDs, "Lot", SqlProxy.FormatSql("nLot={0}", nLot), False)
                    Dim sql As String = SqlProxy.FormatSql("Select  [nLot],[nFacture],[DateFacture],[Nom],[CodeProduit],[Libelle],[Unite1],[LibUnite1] " & _
                                                " From Entreprise e inner join VFacture f on e.nEntreprise=f.nClient " & _
                                                " Inner join VFacture_Detail fd on f.ndevis=fd.ndevis " & _
                                                " Where fd.nLot={0} order by nFacture", nLot)
                    s.Fill(myDs, sql, "Factures", False)
                Next
            End Using
            Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptFicheTraca.rpt")
            fr.Owner = ownerForm
            fr.Show()
        End If
    End Sub

    Private Sub EnregistrerLotProduit()
        Dim listeLotsProduits As New Stocks.ListeLotsProduits()

        'Récupération du contenu des lignes du DataGridViewLotProduit dans une liste d'objets
        For Each dgvr As DataGridViewRow In Me.DataGridViewLotProduit.Rows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            Dim lotProduit As Stocks.LotProduit = CType(dgvr.DataBoundItem, Stocks.LotProduit)

            listeLotsProduits.Add(lotProduit)
        Next

        'Mise à jour dans la base de données
        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            Dim sqlTrans As SqlTransaction = Nothing

            Try
                sqlConn.Open()

                sqlTrans = sqlConn.BeginTransaction

                Stocks.ListeLotsProduits.ModifierListeLotsProduitsParLot(listeLotsProduits, Me.CurrentDrv.Item("nLot").ToString(), sqlTrans)

                sqlTrans.Commit()
                sqlTrans = Nothing

                Me._InfosModifiees = False
            Catch ex As Exception
                If Not (sqlTrans Is Nothing) Then sqlTrans.Rollback()

                Throw ex
            End Try
        End Using
    End Sub

    Private Sub SupprimerLotProduit(ByVal nLot As String)
        'Mise à jour dans la base de données
        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            Dim sqlTrans As SqlTransaction = Nothing

            Try
                sqlConn.Open()

                sqlTrans = sqlConn.BeginTransaction

                Stocks.LotProduit.SupprimerLotsProduitsParnLot(nLot)

                sqlTrans.Commit()
                sqlTrans = Nothing

                Me._InfosModifiees = False
            Catch ex As Exception
                If Not (sqlTrans Is Nothing) Then sqlTrans.Rollback()

                Throw ex
            End Try
        End Using
    End Sub
#End Region

End Class
