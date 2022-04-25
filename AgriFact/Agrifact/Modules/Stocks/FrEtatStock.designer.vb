<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrEtatStock
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Label3 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.EtatStockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.TbImpr = New System.Windows.Forms.ToolStripSplitButton
        Me.EtatDesStocksParFamilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EtatDesStocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.SeulementProduitsEnAlerteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AfficherU1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AfficherU2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CbFamilles = New System.Windows.Forms.ToolStripComboBox
        Me.TxRech = New System.Windows.Forms.ToolStripTextBox
        Me.TbClearRech = New System.Windows.Forms.ToolStripButton
        Me.EtatStockDataGridView = New System.Windows.Forms.DataGridView
        Me.ColAttention = New System.Windows.Forms.DataGridViewImageColumn
        Me.NLotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Depot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FamilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeProduitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntréeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SortieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockActuel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartU2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntréeU2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SortieU2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockActuelU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.BtExpandPanel = New System.Windows.Forms.Button
        Me.chkGestionLots = New System.Windows.Forms.CheckBox
        Me.CbDepot = New System.Windows.Forms.ComboBox
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtGo = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFin = New System.Windows.Forms.DateTimePicker
        Me.dtpDeb = New System.Windows.Forms.DateTimePicker
        Me.EtatStockTableAdapter = New AgriFact.StocksDataSetTableAdapters.EtatStockTA
        Me.FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewDisableButtonColumn1 = New AgriFact.DataGridViewDisableButtonColumn
        Me.ListeChoixTableAdapter = New AgriFact.StocksDataSetTableAdapters.ListeChoixTA
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Label3 = New System.Windows.Forms.Label
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.EtatStockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtatStockDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 39)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(69, 13)
        Label3.TabIndex = 5
        Label3.Text = "pour le dépôt"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.EtatStockBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImpr, Me.ToolStripSeparator1, Me.TbFermer, Me.ToolStripDropDownButton1, Me.TxRech, Me.TbClearRech})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(723, 25)
        Me.BindingNavigator1.TabIndex = 3
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'EtatStockBindingSource
        '
        Me.EtatStockBindingSource.DataMember = "EtatStock"
        Me.EtatStockBindingSource.DataSource = Me.StocksDataSet
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EtatDesStocksParFamilleToolStripMenuItem, Me.EtatDesStocksToolStripMenuItem})
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(32, 22)
        Me.TbImpr.Text = "Imprimer l'état des stocks..."
        '
        'EtatDesStocksParFamilleToolStripMenuItem
        '
        Me.EtatDesStocksParFamilleToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.EtatDesStocksParFamilleToolStripMenuItem.Name = "EtatDesStocksParFamilleToolStripMenuItem"
        Me.EtatDesStocksParFamilleToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.EtatDesStocksParFamilleToolStripMenuItem.Text = "Etat des stocks par famille..."
        '
        'EtatDesStocksToolStripMenuItem
        '
        Me.EtatDesStocksToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.EtatDesStocksToolStripMenuItem.Name = "EtatDesStocksToolStripMenuItem"
        Me.EtatDesStocksToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.EtatDesStocksToolStripMenuItem.Text = "Etat des stocks..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeulementProduitsEnAlerteToolStripMenuItem, Me.AfficherU1ToolStripMenuItem, Me.AfficherU2ToolStripMenuItem, Me.CbFamilles})
        Me.ToolStripDropDownButton1.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "Affichage"
        '
        'SeulementProduitsEnAlerteToolStripMenuItem
        '
        Me.SeulementProduitsEnAlerteToolStripMenuItem.CheckOnClick = True
        Me.SeulementProduitsEnAlerteToolStripMenuItem.Name = "SeulementProduitsEnAlerteToolStripMenuItem"
        Me.SeulementProduitsEnAlerteToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.SeulementProduitsEnAlerteToolStripMenuItem.Text = "Seulement produits en alerte"
        '
        'AfficherU1ToolStripMenuItem
        '
        Me.AfficherU1ToolStripMenuItem.Checked = True
        Me.AfficherU1ToolStripMenuItem.CheckOnClick = True
        Me.AfficherU1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AfficherU1ToolStripMenuItem.Name = "AfficherU1ToolStripMenuItem"
        Me.AfficherU1ToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.AfficherU1ToolStripMenuItem.Text = "Afficher Unité 1"
        '
        'AfficherU2ToolStripMenuItem
        '
        Me.AfficherU2ToolStripMenuItem.CheckOnClick = True
        Me.AfficherU2ToolStripMenuItem.Name = "AfficherU2ToolStripMenuItem"
        Me.AfficherU2ToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.AfficherU2ToolStripMenuItem.Text = "Afficher Unité 2"
        '
        'CbFamilles
        '
        Me.CbFamilles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbFamilles.DropDownWidth = 300
        Me.CbFamilles.Name = "CbFamilles"
        Me.CbFamilles.Size = New System.Drawing.Size(200, 23)
        '
        'TxRech
        '
        Me.TxRech.Name = "TxRech"
        Me.TxRech.Size = New System.Drawing.Size(200, 25)
        Me.WatermarkProvider1.SetWatermark(Me.TxRech, "Rechercher")
        '
        'TbClearRech
        '
        Me.TbClearRech.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClearRech.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClearRech.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClearRech.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClearRech.Name = "TbClearRech"
        Me.TbClearRech.Size = New System.Drawing.Size(23, 22)
        Me.TbClearRech.Text = "Effacer la recherche"
        '
        'EtatStockDataGridView
        '
        Me.EtatStockDataGridView.AllowUserToAddRows = False
        Me.EtatStockDataGridView.AllowUserToDeleteRows = False
        Me.EtatStockDataGridView.AutoGenerateColumns = False
        Me.EtatStockDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.EtatStockDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColAttention, Me.NLotDataGridViewTextBoxColumn, Me.Depot, Me.FamilleDataGridViewTextBoxColumn, Me.CodeProduitDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.LibUnite1DataGridViewTextBoxColumn, Me.DepartDataGridViewTextBoxColumn, Me.EntréeDataGridViewTextBoxColumn, Me.SortieDataGridViewTextBoxColumn, Me.StockActuel, Me.LibUnite2DataGridViewTextBoxColumn, Me.DepartU2DataGridViewTextBoxColumn, Me.EntréeU2DataGridViewTextBoxColumn, Me.SortieU2DataGridViewTextBoxColumn, Me.StockActuelU2})
        Me.EtatStockDataGridView.DataSource = Me.EtatStockBindingSource
        Me.EtatStockDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EtatStockDataGridView.Location = New System.Drawing.Point(0, 96)
        Me.EtatStockDataGridView.Name = "EtatStockDataGridView"
        Me.EtatStockDataGridView.ReadOnly = True
        Me.EtatStockDataGridView.Size = New System.Drawing.Size(723, 323)
        Me.EtatStockDataGridView.TabIndex = 4
        '
        'ColAttention
        '
        Me.ColAttention.HeaderText = ""
        Me.ColAttention.Name = "ColAttention"
        Me.ColAttention.ReadOnly = True
        Me.ColAttention.Width = 5
        '
        'NLotDataGridViewTextBoxColumn
        '
        Me.NLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NLotDataGridViewTextBoxColumn.DataPropertyName = "nLot"
        Me.NLotDataGridViewTextBoxColumn.HeaderText = "N° de lot"
        Me.NLotDataGridViewTextBoxColumn.Name = "NLotDataGridViewTextBoxColumn"
        Me.NLotDataGridViewTextBoxColumn.ReadOnly = True
        Me.NLotDataGridViewTextBoxColumn.Width = 73
        '
        'Depot
        '
        Me.Depot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Depot.DataPropertyName = "Depot"
        Me.Depot.HeaderText = "Dépôt"
        Me.Depot.Name = "Depot"
        Me.Depot.ReadOnly = True
        Me.Depot.Width = 61
        '
        'FamilleDataGridViewTextBoxColumn
        '
        Me.FamilleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FamilleDataGridViewTextBoxColumn.DataPropertyName = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.HeaderText = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.Name = "FamilleDataGridViewTextBoxColumn"
        Me.FamilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.FamilleDataGridViewTextBoxColumn.Width = 64
        '
        'CodeProduitDataGridViewTextBoxColumn
        '
        Me.CodeProduitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitDataGridViewTextBoxColumn.DataPropertyName = "CodeProduit"
        Me.CodeProduitDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.CodeProduitDataGridViewTextBoxColumn.Name = "CodeProduitDataGridViewTextBoxColumn"
        Me.CodeProduitDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodeProduitDataGridViewTextBoxColumn.Width = 57
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Produit"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibUnite1DataGridViewTextBoxColumn
        '
        Me.LibUnite1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite1DataGridViewTextBoxColumn.DataPropertyName = "LibUnite1"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LibUnite1DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LibUnite1DataGridViewTextBoxColumn.HeaderText = "U1"
        Me.LibUnite1DataGridViewTextBoxColumn.Name = "LibUnite1DataGridViewTextBoxColumn"
        Me.LibUnite1DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite1DataGridViewTextBoxColumn.Width = 46
        '
        'DepartDataGridViewTextBoxColumn
        '
        Me.DepartDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DepartDataGridViewTextBoxColumn.DataPropertyName = "Depart"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        Me.DepartDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DepartDataGridViewTextBoxColumn.HeaderText = "Départ"
        Me.DepartDataGridViewTextBoxColumn.Name = "DepartDataGridViewTextBoxColumn"
        Me.DepartDataGridViewTextBoxColumn.ReadOnly = True
        Me.DepartDataGridViewTextBoxColumn.Width = 64
        '
        'EntréeDataGridViewTextBoxColumn
        '
        Me.EntréeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EntréeDataGridViewTextBoxColumn.DataPropertyName = "Entrée"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N3"
        Me.EntréeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.EntréeDataGridViewTextBoxColumn.HeaderText = "Entrées"
        Me.EntréeDataGridViewTextBoxColumn.Name = "EntréeDataGridViewTextBoxColumn"
        Me.EntréeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EntréeDataGridViewTextBoxColumn.Width = 68
        '
        'SortieDataGridViewTextBoxColumn
        '
        Me.SortieDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SortieDataGridViewTextBoxColumn.DataPropertyName = "Sortie"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        Me.SortieDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.SortieDataGridViewTextBoxColumn.HeaderText = "Sorties"
        Me.SortieDataGridViewTextBoxColumn.Name = "SortieDataGridViewTextBoxColumn"
        Me.SortieDataGridViewTextBoxColumn.ReadOnly = True
        Me.SortieDataGridViewTextBoxColumn.Width = 64
        '
        'StockActuel
        '
        Me.StockActuel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StockActuel.DataPropertyName = "StockActuel"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.StockActuel.DefaultCellStyle = DataGridViewCellStyle5
        Me.StockActuel.HeaderText = "En Stock"
        Me.StockActuel.Name = "StockActuel"
        Me.StockActuel.ReadOnly = True
        Me.StockActuel.Width = 76
        '
        'LibUnite2DataGridViewTextBoxColumn
        '
        Me.LibUnite2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite2DataGridViewTextBoxColumn.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LibUnite2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.LibUnite2DataGridViewTextBoxColumn.HeaderText = "U2"
        Me.LibUnite2DataGridViewTextBoxColumn.Name = "LibUnite2DataGridViewTextBoxColumn"
        Me.LibUnite2DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite2DataGridViewTextBoxColumn.Width = 46
        '
        'DepartU2DataGridViewTextBoxColumn
        '
        Me.DepartU2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DepartU2DataGridViewTextBoxColumn.DataPropertyName = "DepartU2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        Me.DepartU2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DepartU2DataGridViewTextBoxColumn.HeaderText = "Départ"
        Me.DepartU2DataGridViewTextBoxColumn.Name = "DepartU2DataGridViewTextBoxColumn"
        Me.DepartU2DataGridViewTextBoxColumn.ReadOnly = True
        Me.DepartU2DataGridViewTextBoxColumn.Width = 64
        '
        'EntréeU2DataGridViewTextBoxColumn
        '
        Me.EntréeU2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EntréeU2DataGridViewTextBoxColumn.DataPropertyName = "EntréeU2"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N3"
        Me.EntréeU2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.EntréeU2DataGridViewTextBoxColumn.HeaderText = "Entrées"
        Me.EntréeU2DataGridViewTextBoxColumn.Name = "EntréeU2DataGridViewTextBoxColumn"
        Me.EntréeU2DataGridViewTextBoxColumn.ReadOnly = True
        Me.EntréeU2DataGridViewTextBoxColumn.Width = 68
        '
        'SortieU2DataGridViewTextBoxColumn
        '
        Me.SortieU2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SortieU2DataGridViewTextBoxColumn.DataPropertyName = "SortieU2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N3"
        Me.SortieU2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.SortieU2DataGridViewTextBoxColumn.HeaderText = "Sorties"
        Me.SortieU2DataGridViewTextBoxColumn.Name = "SortieU2DataGridViewTextBoxColumn"
        Me.SortieU2DataGridViewTextBoxColumn.ReadOnly = True
        Me.SortieU2DataGridViewTextBoxColumn.Width = 64
        '
        'StockActuelU2
        '
        Me.StockActuelU2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StockActuelU2.DataPropertyName = "StockActuelU2"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N3"
        Me.StockActuelU2.DefaultCellStyle = DataGridViewCellStyle10
        Me.StockActuelU2.HeaderText = "En Stock"
        Me.StockActuelU2.Name = "StockActuelU2"
        Me.StockActuelU2.ReadOnly = True
        Me.StockActuelU2.Width = 76
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.BtExpandPanel)
        Me.GradientPanel1.Controls.Add(Me.chkGestionLots)
        Me.GradientPanel1.Controls.Add(Me.CbDepot)
        Me.GradientPanel1.Controls.Add(Label3)
        Me.GradientPanel1.Controls.Add(Me.BtGo)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.dtpFin)
        Me.GradientPanel1.Controls.Add(Me.dtpDeb)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(723, 71)
        Me.GradientPanel1.TabIndex = 79
        '
        'BtExpandPanel
        '
        Me.BtExpandPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtExpandPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtExpandPanel.FlatAppearance.BorderSize = 0
        Me.BtExpandPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtExpandPanel.Image = Global.AgriFact.My.Resources.Resources.Expand_large
        Me.BtExpandPanel.Location = New System.Drawing.Point(699, 7)
        Me.BtExpandPanel.Name = "BtExpandPanel"
        Me.BtExpandPanel.Size = New System.Drawing.Size(16, 16)
        Me.BtExpandPanel.TabIndex = 84
        Me.BtExpandPanel.UseVisualStyleBackColor = False
        '
        'chkGestionLots
        '
        Me.chkGestionLots.AutoSize = True
        Me.chkGestionLots.Location = New System.Drawing.Point(244, 38)
        Me.chkGestionLots.Name = "chkGestionLots"
        Me.chkGestionLots.Size = New System.Drawing.Size(117, 17)
        Me.chkGestionLots.TabIndex = 83
        Me.chkGestionLots.Text = "avec détail des lots"
        Me.chkGestionLots.UseVisualStyleBackColor = True
        '
        'CbDepot
        '
        Me.CbDepot.DataSource = Me.ListeChoixBindingSource
        Me.CbDepot.DisplayMember = "Valeur"
        Me.CbDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepot.FormattingEnabled = True
        Me.CbDepot.Location = New System.Drawing.Point(87, 36)
        Me.CbDepot.Name = "CbDepot"
        Me.CbDepot.Size = New System.Drawing.Size(151, 21)
        Me.CbDepot.TabIndex = 82
        Me.CbDepot.ValueMember = "Valeur"
        '
        'ListeChoixBindingSource
        '
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.DataSource = Me.StocksDataSet
        Me.ListeChoixBindingSource.Filter = "Valeur is not null"
        Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
        '
        'BtGo
        '
        Me.BtGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtGo.Image = Global.AgriFact.My.Resources.Resources.Retry
        Me.BtGo.Location = New System.Drawing.Point(329, 6)
        Me.BtGo.Name = "BtGo"
        Me.BtGo.Size = New System.Drawing.Size(24, 24)
        Me.BtGo.TabIndex = 4
        Me.BtGo.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "au"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Etats des stocks du"
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(235, 8)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(88, 20)
        Me.dtpFin.TabIndex = 1
        '
        'dtpDeb
        '
        Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeb.Location = New System.Drawing.Point(114, 8)
        Me.dtpDeb.Name = "dtpDeb"
        Me.dtpDeb.Size = New System.Drawing.Size(90, 20)
        Me.dtpDeb.TabIndex = 0
        '
        'EtatStockTableAdapter
        '
        Me.EtatStockTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomFamille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Famille"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CodeProduit"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 58
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unite1"
        Me.DataGridViewTextBoxColumn4.HeaderText = "U1"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn5.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Depart"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N3"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn6.HeaderText = "Départ"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 65
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Entrée"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N3"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn7.HeaderText = "Entrées"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 69
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Sortie"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N3"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn8.HeaderText = "Sorties"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 65
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn9.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DepartU2"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N3"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn10.HeaderText = "Départ"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 65
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "EntréeU2"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N3"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn11.HeaderText = "Entrées"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 69
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "SortieU2"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N3"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn12.HeaderText = "Sorties"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 65
        '
        'DataGridViewDisableButtonColumn1
        '
        Me.DataGridViewDisableButtonColumn1.HeaderText = "Contrôle"
        Me.DataGridViewDisableButtonColumn1.Image = Global.AgriFact.My.Resources.Resources.complete16
        Me.DataGridViewDisableButtonColumn1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
        Me.DataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = True
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'FrEtatStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.EtatStockDataGridView)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Name = "FrEtatStock"
        Me.Text = "Etat des Stocks"
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.EtatStockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtatStockDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EtatStockDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewDisableButtonColumn1 As DataGridViewDisableButtonColumn
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtGo As System.Windows.Forms.Button
    Friend WithEvents LotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EtatStockBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StocksDataSet As StocksDataSet
    Friend WithEvents EtatStockTableAdapter As StocksDataSetTableAdapters.EtatStockTA
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AfficherU1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfficherU2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CbFamilles As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents FamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeulementProduitsEnAlerteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CbDepot As System.Windows.Forms.ComboBox
    Friend WithEvents chkGestionLots As System.Windows.Forms.CheckBox
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As StocksDataSetTableAdapters.ListeChoixTA
    Friend WithEvents ColAttention As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents NLotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Depot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FamilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntréeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortieDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockActuel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartU2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntréeU2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortieU2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockActuelU2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents EtatDesStocksParFamilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EtatDesStocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxRech As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents TbClearRech As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtExpandPanel As System.Windows.Forms.Button
End Class
