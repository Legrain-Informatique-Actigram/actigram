Namespace Fabrications
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieTransfo
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
            Dim DescriptionLabel As System.Windows.Forms.Label
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrSaisieTransfo))
            Me.NPieceLabel = New System.Windows.Forms.Label
            Me.DateFactureLabel = New System.Windows.Forms.Label
            Me.MouvBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.MouvBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.TbImprimer = New System.Windows.Forms.ToolStripButton
            Me.TbPrintBarcode = New System.Windows.Forms.ToolStripButton
            Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.TbNewModele = New System.Windows.Forms.ToolStripButton
            Me.TbNewFab = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.cbAfficheBR = New System.Windows.Forms.CheckBox
            Me.TbRefreshNLot = New System.Windows.Forms.Button
            Me.LnkInfosPlus = New System.Windows.Forms.LinkLabel
            Me.DescriptionTextBox = New System.Windows.Forms.TextBox
            Me.NPieceTextBox = New System.Windows.Forms.TextBox
            Me.DateFactureDateTimePicker = New System.Windows.Forms.DateTimePicker
            Me.MouvPFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProduitsFinisDataGridView = New System.Windows.Forms.DataGridView
            Me.NMouvementDetailDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFCodeProduit = New ControleTracabilite.DatagridViewComboboxColumnCustom
            Me.ProduitPFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ColRechProdPF = New System.Windows.Forms.DataGridViewButtonColumn
            Me.PFLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFUnite1 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.PFLibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFUnite2 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.PFLibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColControle = New ControleTracabilite.DataGridViewDisableButtonColumn
            Me.MouvDetailBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem1 = New System.Windows.Forms.ToolStripButton
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.MouvementTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
            Me.Mouvement_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
            Me.TabControl1 = New System.Windows.Forms.TabControl
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.TabPage2 = New System.Windows.Forms.TabPage
            Me.MatPremsDataGridView = New System.Windows.Forms.DataGridView
            Me.MPCodeProduit = New ControleTracabilite.DatagridViewComboboxColumnCustom
            Me.ProduitMPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ColRechProdMP = New System.Windows.Forms.DataGridViewButtonColumn
            Me.MPnLot = New ControleTracabilite.DatagridViewComboboxColumnCustom
            Me.LotFabricationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.MPLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MPUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MPLibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MPUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MPLibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.NMouvementDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MouvMPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.MatPremBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.TbAffecterMP = New System.Windows.Forms.ToolStripButton
            Me.TbCodeBarre = New System.Windows.Forms.ToolStripButton
            Me.BRDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            Me.BRTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
            Me.BRDetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
            Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
            Me.LotFabricationTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotFabricationTableAdapter
            DescriptionLabel = New System.Windows.Forms.Label
            CType(Me.MouvBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MouvBindingNavigator.SuspendLayout()
            CType(Me.MouvBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.MouvPFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitsFinisDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitPFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MouvDetailBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MouvDetailBindingNavigator.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.MatPremsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitMPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LotFabricationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MouvMPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MatPremBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MatPremBindingNavigator.SuspendLayout()
            CType(Me.BRDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DescriptionLabel
            '
            DescriptionLabel.AutoSize = True
            DescriptionLabel.Location = New System.Drawing.Point(22, 36)
            DescriptionLabel.Name = "DescriptionLabel"
            DescriptionLabel.Size = New System.Drawing.Size(63, 13)
            DescriptionLabel.TabIndex = 6
            DescriptionLabel.Text = "Description:"
            '
            'NPieceLabel
            '
            Me.NPieceLabel.AutoSize = True
            Me.NPieceLabel.Location = New System.Drawing.Point(8, 10)
            Me.NPieceLabel.Name = "NPieceLabel"
            Me.NPieceLabel.Size = New System.Drawing.Size(77, 13)
            Me.NPieceLabel.TabIndex = 0
            Me.NPieceLabel.Text = "N° Fabrication:"
            Me.NPieceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'DateFactureLabel
            '
            Me.DateFactureLabel.AutoSize = True
            Me.DateFactureLabel.Location = New System.Drawing.Point(264, 11)
            Me.DateFactureLabel.Name = "DateFactureLabel"
            Me.DateFactureLabel.Size = New System.Drawing.Size(33, 13)
            Me.DateFactureLabel.TabIndex = 4
            Me.DateFactureLabel.Text = "Date:"
            '
            'MouvBindingNavigator
            '
            Me.MouvBindingNavigator.AddNewItem = Nothing
            Me.MouvBindingNavigator.BindingSource = Me.MouvBindingSource
            Me.MouvBindingNavigator.CountItem = Nothing
            Me.MouvBindingNavigator.DeleteItem = Nothing
            Me.MouvBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MouvBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImprimer, Me.TbPrintBarcode, Me.ProduitBindingNavigatorSaveItem, Me.TbFermer, Me.TbNewModele, Me.TbNewFab})
            Me.MouvBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.MouvBindingNavigator.MoveFirstItem = Nothing
            Me.MouvBindingNavigator.MoveLastItem = Nothing
            Me.MouvBindingNavigator.MoveNextItem = Nothing
            Me.MouvBindingNavigator.MovePreviousItem = Nothing
            Me.MouvBindingNavigator.Name = "MouvBindingNavigator"
            Me.MouvBindingNavigator.PositionItem = Nothing
            Me.MouvBindingNavigator.Size = New System.Drawing.Size(700, 25)
            Me.MouvBindingNavigator.TabIndex = 0
            Me.MouvBindingNavigator.Text = "BindingNavigator1"
            '
            'MouvBindingSource
            '
            Me.MouvBindingSource.DataMember = "Mouvement"
            Me.MouvBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'TbImprimer
            '
            Me.TbImprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbImprimer.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbImprimer.Name = "TbImprimer"
            Me.TbImprimer.Size = New System.Drawing.Size(23, 22)
            Me.TbImprimer.Text = "Imprimer la fiche de fabrication"
            '
            'TbPrintBarcode
            '
            Me.TbPrintBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbPrintBarcode.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
            Me.TbPrintBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbPrintBarcode.Name = "TbPrintBarcode"
            Me.TbPrintBarcode.Size = New System.Drawing.Size(23, 22)
            Me.TbPrintBarcode.Text = "Imprimer des etiquettes code-barre"
            '
            'ProduitBindingNavigatorSaveItem
            '
            Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ProduitBindingNavigatorSaveItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
            Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
            Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'TbNewModele
            '
            Me.TbNewModele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbNewModele.Image = Global.ControleTracabilite.My.Resources.Resources.SaveFormDesignHS
            Me.TbNewModele.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbNewModele.Name = "TbNewModele"
            Me.TbNewModele.Size = New System.Drawing.Size(23, 22)
            Me.TbNewModele.Text = "Créer un modèle à partir de cette fabrication"
            '
            'TbNewFab
            '
            Me.TbNewFab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbNewFab.Image = Global.ControleTracabilite.My.Resources.Resources.NewCardHS
            Me.TbNewFab.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbNewFab.Name = "TbNewFab"
            Me.TbNewFab.Size = New System.Drawing.Size(23, 22)
            Me.TbNewFab.Text = "Créer une nouvelle fabrication à partir de ce modèle"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.cbAfficheBR)
            Me.GradientPanel1.Controls.Add(Me.TbRefreshNLot)
            Me.GradientPanel1.Controls.Add(Me.LnkInfosPlus)
            Me.GradientPanel1.Controls.Add(DescriptionLabel)
            Me.GradientPanel1.Controls.Add(Me.DescriptionTextBox)
            Me.GradientPanel1.Controls.Add(Me.NPieceLabel)
            Me.GradientPanel1.Controls.Add(Me.NPieceTextBox)
            Me.GradientPanel1.Controls.Add(Me.DateFactureLabel)
            Me.GradientPanel1.Controls.Add(Me.DateFactureDateTimePicker)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(700, 85)
            Me.GradientPanel1.TabIndex = 1
            '
            'cbAfficheBR
            '
            Me.cbAfficheBR.AutoSize = True
            Me.cbAfficheBR.Location = New System.Drawing.Point(25, 59)
            Me.cbAfficheBR.Name = "cbAfficheBR"
            Me.cbAfficheBR.Size = New System.Drawing.Size(151, 17)
            Me.cbAfficheBR.TabIndex = 10
            Me.cbAfficheBR.Text = "Afficher Bon de Réception"
            Me.cbAfficheBR.UseVisualStyleBackColor = True
            '
            'TbRefreshNLot
            '
            Me.TbRefreshNLot.Image = Global.ControleTracabilite.My.Resources.Resources.RepeatHS
            Me.TbRefreshNLot.Location = New System.Drawing.Point(232, 8)
            Me.TbRefreshNLot.Name = "TbRefreshNLot"
            Me.TbRefreshNLot.Size = New System.Drawing.Size(26, 20)
            Me.TbRefreshNLot.TabIndex = 9
            Me.TbRefreshNLot.UseVisualStyleBackColor = True
            '
            'LnkInfosPlus
            '
            Me.LnkInfosPlus.AutoSize = True
            Me.LnkInfosPlus.Location = New System.Drawing.Point(395, 11)
            Me.LnkInfosPlus.Name = "LnkInfosPlus"
            Me.LnkInfosPlus.Size = New System.Drawing.Size(155, 13)
            Me.LnkInfosPlus.TabIndex = 8
            Me.LnkInfosPlus.TabStop = True
            Me.LnkInfosPlus.Text = "Informations complémentaires..."
            Me.LnkInfosPlus.Visible = False
            '
            'DescriptionTextBox
            '
            Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "Description", True))
            Me.DescriptionTextBox.Location = New System.Drawing.Point(91, 33)
            Me.DescriptionTextBox.MaxLength = 50
            Me.DescriptionTextBox.Name = "DescriptionTextBox"
            Me.DescriptionTextBox.Size = New System.Drawing.Size(420, 20)
            Me.DescriptionTextBox.TabIndex = 7
            '
            'NPieceTextBox
            '
            Me.NPieceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "nPiece", True))
            Me.NPieceTextBox.Location = New System.Drawing.Point(91, 7)
            Me.NPieceTextBox.Name = "NPieceTextBox"
            Me.NPieceTextBox.Size = New System.Drawing.Size(135, 20)
            Me.NPieceTextBox.TabIndex = 1
            Me.NPieceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'DateFactureDateTimePicker
            '
            Me.DateFactureDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.MouvBindingSource, "DateMouvement", True))
            Me.DateFactureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.DateFactureDateTimePicker.Location = New System.Drawing.Point(303, 7)
            Me.DateFactureDateTimePicker.Name = "DateFactureDateTimePicker"
            Me.DateFactureDateTimePicker.Size = New System.Drawing.Size(86, 20)
            Me.DateFactureDateTimePicker.TabIndex = 5
            '
            'MouvPFBindingSource
            '
            Me.MouvPFBindingSource.DataMember = "FK_Mouvement_Detail_Mouvement"
            Me.MouvPFBindingSource.DataSource = Me.MouvBindingSource
            Me.MouvPFBindingSource.Filter = "MatPrem=False"
            '
            'ProduitsFinisDataGridView
            '
            Me.ProduitsFinisDataGridView.AutoGenerateColumns = False
            Me.ProduitsFinisDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NMouvementDetailDataGridViewTextBoxColumn1, Me.PFCodeProduit, Me.ColRechProdPF, Me.PFLibelle, Me.PFUnite1, Me.PFLibUnite1, Me.PFUnite2, Me.PFLibUnite2, Me.ColControle})
            Me.ProduitsFinisDataGridView.DataSource = Me.MouvPFBindingSource
            Me.ProduitsFinisDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ProduitsFinisDataGridView.Location = New System.Drawing.Point(3, 28)
            Me.ProduitsFinisDataGridView.Name = "ProduitsFinisDataGridView"
            Me.ProduitsFinisDataGridView.Size = New System.Drawing.Size(686, 290)
            Me.ProduitsFinisDataGridView.TabIndex = 1
            '
            'NMouvementDetailDataGridViewTextBoxColumn1
            '
            Me.NMouvementDetailDataGridViewTextBoxColumn1.DataPropertyName = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn1.HeaderText = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn1.Name = "NMouvementDetailDataGridViewTextBoxColumn1"
            Me.NMouvementDetailDataGridViewTextBoxColumn1.Visible = False
            '
            'PFCodeProduit
            '
            Me.PFCodeProduit.DataPropertyName = "CodeProduit"
            Me.PFCodeProduit.DataSource = Me.ProduitPFBindingSource
            Me.PFCodeProduit.DisplayMember = "ProduitDisplay"
            Me.PFCodeProduit.DisplayStyleForCurrentCellOnly = True
            Me.PFCodeProduit.DropDownWidth = 400
            Me.PFCodeProduit.HeaderText = "Code"
            Me.PFCodeProduit.Name = "PFCodeProduit"
            Me.PFCodeProduit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFCodeProduit.ValueMember = "CodeProduit"
            '
            'ProduitPFBindingSource
            '
            Me.ProduitPFBindingSource.DataMember = "Produit"
            Me.ProduitPFBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitPFBindingSource.Filter = "ProduitVente=True"
            Me.ProduitPFBindingSource.Sort = "Libelle"
            '
            'ColRechProdPF
            '
            Me.ColRechProdPF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
            DataGridViewCellStyle1.NullValue = "€"
            Me.ColRechProdPF.DefaultCellStyle = DataGridViewCellStyle1
            Me.ColRechProdPF.HeaderText = ""
            Me.ColRechProdPF.Name = "ColRechProdPF"
            Me.ColRechProdPF.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ColRechProdPF.Text = "€"
            Me.ColRechProdPF.ToolTipText = "Rechercher un produit"
            Me.ColRechProdPF.Width = 20
            '
            'PFLibelle
            '
            Me.PFLibelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PFLibelle.DataPropertyName = "Libelle"
            Me.PFLibelle.HeaderText = "Libellé"
            Me.PFLibelle.Name = "PFLibelle"
            '
            'PFUnite1
            '
            Me.PFUnite1.DataPropertyName = "Unite1"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N3"
            Me.PFUnite1.DefaultCellStyle = DataGridViewCellStyle2
            Me.PFUnite1.HeaderText = "Quantité 1"
            Me.PFUnite1.Name = "PFUnite1"
            Me.PFUnite1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFUnite1.Width = 75
            '
            'PFLibUnite1
            '
            Me.PFLibUnite1.DataPropertyName = "LibUnite1"
            Me.PFLibUnite1.HeaderText = ""
            Me.PFLibUnite1.Name = "PFLibUnite1"
            Me.PFLibUnite1.ReadOnly = True
            Me.PFLibUnite1.Width = 30
            '
            'PFUnite2
            '
            Me.PFUnite2.DataPropertyName = "Unite2"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.PFUnite2.DefaultCellStyle = DataGridViewCellStyle3
            Me.PFUnite2.HeaderText = "Quantité 2"
            Me.PFUnite2.Name = "PFUnite2"
            Me.PFUnite2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFUnite2.Width = 75
            '
            'PFLibUnite2
            '
            Me.PFLibUnite2.DataPropertyName = "LibUnite2"
            Me.PFLibUnite2.HeaderText = ""
            Me.PFLibUnite2.Name = "PFLibUnite2"
            Me.PFLibUnite2.ReadOnly = True
            Me.PFLibUnite2.Width = 30
            '
            'ColControle
            '
            Me.ColControle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColControle.HeaderText = "Contrôle"
            Me.ColControle.Image = Global.ControleTracabilite.My.Resources.Resources.controles
            Me.ColControle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.ColControle.Name = "ColControle"
            Me.ColControle.UseColumnTextForButtonValue = True
            Me.ColControle.Width = 52
            '
            'MouvDetailBindingNavigator
            '
            Me.MouvDetailBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem1
            Me.MouvDetailBindingNavigator.BindingSource = Me.MouvPFBindingSource
            Me.MouvDetailBindingNavigator.CountItem = Nothing
            Me.MouvDetailBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem1
            Me.MouvDetailBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MouvDetailBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem1})
            Me.MouvDetailBindingNavigator.Location = New System.Drawing.Point(3, 3)
            Me.MouvDetailBindingNavigator.MoveFirstItem = Nothing
            Me.MouvDetailBindingNavigator.MoveLastItem = Nothing
            Me.MouvDetailBindingNavigator.MoveNextItem = Nothing
            Me.MouvDetailBindingNavigator.MovePreviousItem = Nothing
            Me.MouvDetailBindingNavigator.Name = "MouvDetailBindingNavigator"
            Me.MouvDetailBindingNavigator.PositionItem = Nothing
            Me.MouvDetailBindingNavigator.Size = New System.Drawing.Size(686, 25)
            Me.MouvDetailBindingNavigator.TabIndex = 0
            Me.MouvDetailBindingNavigator.Text = "BindingNavigator1"
            '
            'BindingNavigatorAddNewItem1
            '
            Me.BindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorAddNewItem1.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.BindingNavigatorAddNewItem1.Name = "BindingNavigatorAddNewItem1"
            Me.BindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorAddNewItem1.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorAddNewItem1.Text = "Ajouter nouveau"
            '
            'BindingNavigatorDeleteItem1
            '
            Me.BindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorDeleteItem1.Image = Global.ControleTracabilite.My.Resources.Resources.suppr
            Me.BindingNavigatorDeleteItem1.Name = "BindingNavigatorDeleteItem1"
            Me.BindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorDeleteItem1.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorDeleteItem1.Text = "Supprimer"
            '
            'ProduitTableAdapter
            '
            Me.ProduitTableAdapter.ClearBeforeFill = True
            '
            'MouvementTableAdapter
            '
            Me.MouvementTableAdapter.ClearBeforeFill = True
            '
            'Mouvement_DetailTableAdapter
            '
            Me.Mouvement_DetailTableAdapter.ClearBeforeFill = True
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(0, 110)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(700, 347)
            Me.TabControl1.TabIndex = 2
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.ProduitsFinisDataGridView)
            Me.TabPage1.Controls.Add(Me.MouvDetailBindingNavigator)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(692, 321)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Produits finis"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.MatPremsDataGridView)
            Me.TabPage2.Controls.Add(Me.MatPremBindingNavigator)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(692, 337)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Matières premières"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'MatPremsDataGridView
            '
            Me.MatPremsDataGridView.AutoGenerateColumns = False
            Me.MatPremsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MPCodeProduit, Me.ColRechProdMP, Me.MPnLot, Me.MPLibelle, Me.MPUnite1, Me.MPLibUnite1, Me.MPUnite2, Me.MPLibUnite2, Me.NMouvementDetailDataGridViewTextBoxColumn})
            Me.MatPremsDataGridView.DataSource = Me.MouvMPBindingSource
            Me.MatPremsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MatPremsDataGridView.Location = New System.Drawing.Point(3, 28)
            Me.MatPremsDataGridView.Name = "MatPremsDataGridView"
            Me.MatPremsDataGridView.Size = New System.Drawing.Size(686, 306)
            Me.MatPremsDataGridView.TabIndex = 9
            '
            'MPCodeProduit
            '
            Me.MPCodeProduit.DataPropertyName = "CodeProduit"
            Me.MPCodeProduit.DataSource = Me.ProduitMPBindingSource
            Me.MPCodeProduit.DisplayMember = "ProduitDisplay"
            Me.MPCodeProduit.DisplayStyleForCurrentCellOnly = True
            Me.MPCodeProduit.DropDownWidth = 400
            Me.MPCodeProduit.HeaderText = "Code"
            Me.MPCodeProduit.Name = "MPCodeProduit"
            Me.MPCodeProduit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.MPCodeProduit.ValueMember = "CodeProduit"
            Me.MPCodeProduit.Width = 75
            '
            'ProduitMPBindingSource
            '
            Me.ProduitMPBindingSource.DataMember = "Produit"
            Me.ProduitMPBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitMPBindingSource.Filter = "ProduitAchat=True"
            Me.ProduitMPBindingSource.Sort = "Libelle"
            '
            'ColRechProdMP
            '
            Me.ColRechProdMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
            DataGridViewCellStyle4.NullValue = "€"
            Me.ColRechProdMP.DefaultCellStyle = DataGridViewCellStyle4
            Me.ColRechProdMP.HeaderText = ""
            Me.ColRechProdMP.Name = "ColRechProdMP"
            Me.ColRechProdMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ColRechProdMP.Text = "€"
            Me.ColRechProdMP.ToolTipText = "Rechercher un produit"
            Me.ColRechProdMP.UseColumnTextForButtonValue = True
            Me.ColRechProdMP.Width = 20
            '
            'MPnLot
            '
            Me.MPnLot.DataPropertyName = "nLot"
            Me.MPnLot.DataSource = Me.LotFabricationBindingSource
            Me.MPnLot.DisplayMember = "NLot"
            Me.MPnLot.DisplayStyleForCurrentCellOnly = True
            Me.MPnLot.DropDownWidth = 300
            Me.MPnLot.HeaderText = "Lot"
            Me.MPnLot.Name = "MPnLot"
            Me.MPnLot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.MPnLot.ValueMember = "NLot"
            Me.MPnLot.Width = 120
            '
            'LotFabricationBindingSource
            '
            Me.LotFabricationBindingSource.DataMember = "LotFabrication"
            Me.LotFabricationBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'MPLibelle
            '
            Me.MPLibelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.MPLibelle.DataPropertyName = "Libelle"
            Me.MPLibelle.HeaderText = "Libellé"
            Me.MPLibelle.Name = "MPLibelle"
            '
            'MPUnite1
            '
            Me.MPUnite1.DataPropertyName = "Unite1"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.Format = "N3"
            Me.MPUnite1.DefaultCellStyle = DataGridViewCellStyle5
            Me.MPUnite1.HeaderText = "Quantité 1"
            Me.MPUnite1.Name = "MPUnite1"
            Me.MPUnite1.Width = 75
            '
            'MPLibUnite1
            '
            Me.MPLibUnite1.DataPropertyName = "LibUnite1"
            Me.MPLibUnite1.HeaderText = ""
            Me.MPLibUnite1.Name = "MPLibUnite1"
            Me.MPLibUnite1.ReadOnly = True
            Me.MPLibUnite1.Width = 30
            '
            'MPUnite2
            '
            Me.MPUnite2.DataPropertyName = "Unite2"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.Format = "N3"
            Me.MPUnite2.DefaultCellStyle = DataGridViewCellStyle6
            Me.MPUnite2.HeaderText = "Quantité 2"
            Me.MPUnite2.Name = "MPUnite2"
            Me.MPUnite2.Width = 75
            '
            'MPLibUnite2
            '
            Me.MPLibUnite2.DataPropertyName = "LibUnite2"
            Me.MPLibUnite2.HeaderText = ""
            Me.MPLibUnite2.Name = "MPLibUnite2"
            Me.MPLibUnite2.ReadOnly = True
            Me.MPLibUnite2.Width = 30
            '
            'NMouvementDetailDataGridViewTextBoxColumn
            '
            Me.NMouvementDetailDataGridViewTextBoxColumn.DataPropertyName = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn.HeaderText = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn.Name = "NMouvementDetailDataGridViewTextBoxColumn"
            Me.NMouvementDetailDataGridViewTextBoxColumn.Visible = False
            '
            'MouvMPBindingSource
            '
            Me.MouvMPBindingSource.DataMember = "FK_Mouvement_Detail_Mouvement"
            Me.MouvMPBindingSource.DataSource = Me.MouvBindingSource
            Me.MouvMPBindingSource.Filter = "MatPrem=True"
            '
            'MatPremBindingNavigator
            '
            Me.MatPremBindingNavigator.AddNewItem = Me.ToolStripButton2
            Me.MatPremBindingNavigator.BindingSource = Me.MouvMPBindingSource
            Me.MatPremBindingNavigator.CountItem = Nothing
            Me.MatPremBindingNavigator.DeleteItem = Me.ToolStripButton3
            Me.MatPremBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MatPremBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator4, Me.TbAffecterMP, Me.TbCodeBarre})
            Me.MatPremBindingNavigator.Location = New System.Drawing.Point(3, 3)
            Me.MatPremBindingNavigator.MoveFirstItem = Nothing
            Me.MatPremBindingNavigator.MoveLastItem = Nothing
            Me.MatPremBindingNavigator.MoveNextItem = Nothing
            Me.MatPremBindingNavigator.MovePreviousItem = Nothing
            Me.MatPremBindingNavigator.Name = "MatPremBindingNavigator"
            Me.MatPremBindingNavigator.PositionItem = Nothing
            Me.MatPremBindingNavigator.Size = New System.Drawing.Size(686, 25)
            Me.MatPremBindingNavigator.TabIndex = 10
            Me.MatPremBindingNavigator.Text = "BindingNavigator1"
            '
            'ToolStripButton2
            '
            Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton2.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.ToolStripButton2.Name = "ToolStripButton2"
            Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
            Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton2.Text = "Ajouter nouveau"
            '
            'ToolStripButton3
            '
            Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton3.Image = Global.ControleTracabilite.My.Resources.Resources.suppr
            Me.ToolStripButton3.Name = "ToolStripButton3"
            Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
            Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton3.Text = "Supprimer"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'TbAffecterMP
            '
            Me.TbAffecterMP.Image = Global.ControleTracabilite.My.Resources.Resources.compo
            Me.TbAffecterMP.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbAffecterMP.Name = "TbAffecterMP"
            Me.TbAffecterMP.Size = New System.Drawing.Size(189, 22)
            Me.TbAffecterMP.Text = "Affecter les matières premières"
            '
            'TbCodeBarre
            '
            Me.TbCodeBarre.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
            Me.TbCodeBarre.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbCodeBarre.Name = "TbCodeBarre"
            Me.TbCodeBarre.Size = New System.Drawing.Size(135, 22)
            Me.TbCodeBarre.Text = "Saisie par code barre"
            '
            'BRDetailBindingSource
            '
            Me.BRDetailBindingSource.DataMember = "ABonReception_Detail"
            Me.BRDetailBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'BRTableAdapter
            '
            Me.BRTableAdapter.ClearBeforeFill = True
            '
            'BRDetailTableAdapter
            '
            Me.BRDetailTableAdapter.ClearBeforeFill = True
            '
            'ToolStripButton4
            '
            Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
            Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton4.Name = "ToolStripButton4"
            Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton4.Text = "ToolStripButton4"
            '
            'ToolStripButton5
            '
            Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
            Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton5.Name = "ToolStripButton5"
            Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton5.Text = "ToolStripButton5"
            '
            'LotFabricationTableAdapter
            '
            Me.LotFabricationTableAdapter.ClearBeforeFill = True
            '
            'FrSaisieTransfo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(700, 457)
            Me.ControlBox = False
            Me.Controls.Add(Me.TabControl1)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.MouvBindingNavigator)
            Me.Name = "FrSaisieTransfo"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Saisie d'une fabrication"
            CType(Me.MouvBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MouvBindingNavigator.ResumeLayout(False)
            Me.MouvBindingNavigator.PerformLayout()
            CType(Me.MouvBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.MouvPFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitsFinisDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitPFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MouvDetailBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MouvDetailBindingNavigator.ResumeLayout(False)
            Me.MouvDetailBindingNavigator.PerformLayout()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage2.PerformLayout()
            CType(Me.MatPremsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitMPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LotFabricationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MouvMPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MatPremBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MatPremBindingNavigator.ResumeLayout(False)
            Me.MatPremBindingNavigator.PerformLayout()
            CType(Me.BRDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents MouvBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Friend WithEvents MouvBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents ProduitPFBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DateFactureDateTimePicker As System.Windows.Forms.DateTimePicker
        Friend WithEvents MouvPFBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitsFinisDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents MouvDetailBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
        Friend WithEvents MouvementTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
        Friend WithEvents Mouvement_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
        Friend WithEvents NPieceTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents MatPremBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
        Friend WithEvents MatPremsDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents MouvMPBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbAffecterMP As System.Windows.Forms.ToolStripButton
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents BRTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
        Friend WithEvents BRDetailBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BRDetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
        Friend WithEvents ProduitMPBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LnkInfosPlus As System.Windows.Forms.LinkLabel
        Friend WithEvents TbCodeBarre As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
        Friend WithEvents DateFactureLabel As System.Windows.Forms.Label
        Friend WithEvents NPieceLabel As System.Windows.Forms.Label
        Friend WithEvents TbNewFab As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbNewModele As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbRefreshNLot As System.Windows.Forms.Button
        Friend WithEvents NMouvementDetailDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFCodeProduit As ControleTracabilite.DatagridViewComboboxColumnCustom
        Friend WithEvents ColRechProdPF As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents PFLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFUnite1 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents PFLibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFUnite2 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents PFLibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColControle As ControleTracabilite.DataGridViewDisableButtonColumn
        Friend WithEvents TbPrintBarcode As System.Windows.Forms.ToolStripButton
        Friend WithEvents LotFabricationBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LotFabricationTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotFabricationTableAdapter
        Friend WithEvents MPCodeProduit As ControleTracabilite.DatagridViewComboboxColumnCustom
        Friend WithEvents ColRechProdMP As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents MPnLot As ControleTracabilite.DatagridViewComboboxColumnCustom
        Friend WithEvents MPLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MPUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MPLibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MPUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MPLibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NMouvementDetailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cbAfficheBR As System.Windows.Forms.CheckBox
    End Class
End Namespace