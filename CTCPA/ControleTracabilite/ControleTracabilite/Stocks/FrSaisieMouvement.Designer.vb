Namespace Stocks
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieMouvement
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
            Dim TypeMouvementLabel As System.Windows.Forms.Label
            Dim DepotDepartLabel As System.Windows.Forms.Label
            Dim DepotDestLabel As System.Windows.Forms.Label
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.NPieceLabel = New System.Windows.Forms.Label
            Me.DateFactureLabel = New System.Windows.Forms.Label
            Me.MouvBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.MouvBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.TbImprimer = New System.Windows.Forms.ToolStripButton
            Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.BtDepots = New System.Windows.Forms.Button
            Me.DepotDestComboBox = New System.Windows.Forms.ComboBox
            Me.ChoixDepotDestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DepotDepartComboBox = New System.Windows.Forms.ComboBox
            Me.ChoixDepotDepartBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TypeMouvementComboBox = New System.Windows.Forms.ComboBox
            Me.ChoixTypeMvtBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TbRefreshNLot = New System.Windows.Forms.Button
            Me.DescriptionTextBox = New System.Windows.Forms.TextBox
            Me.NPieceTextBox = New System.Windows.Forms.TextBox
            Me.DateFactureDateTimePicker = New System.Windows.Forms.DateTimePicker
            Me.MouvDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.MouvDetailBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem1 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.TbCodeBarre = New System.Windows.Forms.ToolStripButton
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.MouvementTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
            Me.Mouvement_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
            Me.ProduitsDataGridView = New System.Windows.Forms.DataGridView
            Me.NMouvementDetailDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFCodeProduit = New ControleTracabilite.DatagridViewComboboxColumnCustom
            Me.ColRechProd = New System.Windows.Forms.DataGridViewButtonColumn
            Me.nLot = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColRechLot = New System.Windows.Forms.DataGridViewButtonColumn
            Me.PFLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFUnite1 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.PFLibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.PFUnite2 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.PFLibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ListeChoixTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
            DescriptionLabel = New System.Windows.Forms.Label
            TypeMouvementLabel = New System.Windows.Forms.Label
            DepotDepartLabel = New System.Windows.Forms.Label
            DepotDestLabel = New System.Windows.Forms.Label
            CType(Me.MouvBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MouvBindingNavigator.SuspendLayout()
            CType(Me.MouvBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.ChoixDepotDestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChoixDepotDepartBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChoixTypeMvtBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MouvDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MouvDetailBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MouvDetailBindingNavigator.SuspendLayout()
            CType(Me.ProduitsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DescriptionLabel
            '
            DescriptionLabel.AutoSize = True
            DescriptionLabel.Location = New System.Drawing.Point(15, 38)
            DescriptionLabel.Name = "DescriptionLabel"
            DescriptionLabel.Size = New System.Drawing.Size(63, 13)
            DescriptionLabel.TabIndex = 7
            DescriptionLabel.Text = "Description:"
            '
            'TypeMouvementLabel
            '
            TypeMouvementLabel.AutoSize = True
            TypeMouvementLabel.Location = New System.Drawing.Point(15, 12)
            TypeMouvementLabel.Name = "TypeMouvementLabel"
            TypeMouvementLabel.Size = New System.Drawing.Size(69, 13)
            TypeMouvementLabel.TabIndex = 0
            TypeMouvementLabel.Text = "Mouvement :"
            '
            'DepotDepartLabel
            '
            DepotDepartLabel.AutoSize = True
            DepotDepartLabel.Location = New System.Drawing.Point(15, 64)
            DepotDepartLabel.Name = "DepotDepartLabel"
            DepotDepartLabel.Size = New System.Drawing.Size(71, 13)
            DepotDepartLabel.TabIndex = 9
            DepotDepartLabel.Text = "Provenance :"
            '
            'DepotDestLabel
            '
            DepotDestLabel.AutoSize = True
            DepotDestLabel.Location = New System.Drawing.Point(248, 64)
            DepotDestLabel.Name = "DepotDestLabel"
            DepotDestLabel.Size = New System.Drawing.Size(66, 13)
            DepotDestLabel.TabIndex = 11
            DepotDestLabel.Text = "Destination :"
            '
            'NPieceLabel
            '
            Me.NPieceLabel.AutoSize = True
            Me.NPieceLabel.Location = New System.Drawing.Point(248, 12)
            Me.NPieceLabel.Name = "NPieceLabel"
            Me.NPieceLabel.Size = New System.Drawing.Size(22, 13)
            Me.NPieceLabel.TabIndex = 2
            Me.NPieceLabel.Text = "N°:"
            Me.NPieceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'DateFactureLabel
            '
            Me.DateFactureLabel.AutoSize = True
            Me.DateFactureLabel.Location = New System.Drawing.Point(409, 14)
            Me.DateFactureLabel.Name = "DateFactureLabel"
            Me.DateFactureLabel.Size = New System.Drawing.Size(33, 13)
            Me.DateFactureLabel.TabIndex = 5
            Me.DateFactureLabel.Text = "Date:"
            '
            'MouvBindingNavigator
            '
            Me.MouvBindingNavigator.AddNewItem = Nothing
            Me.MouvBindingNavigator.BindingSource = Me.MouvBindingSource
            Me.MouvBindingNavigator.CountItem = Nothing
            Me.MouvBindingNavigator.DeleteItem = Nothing
            Me.MouvBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MouvBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImprimer, Me.ProduitBindingNavigatorSaveItem, Me.TbFermer})
            Me.MouvBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.MouvBindingNavigator.MoveFirstItem = Nothing
            Me.MouvBindingNavigator.MoveLastItem = Nothing
            Me.MouvBindingNavigator.MoveNextItem = Nothing
            Me.MouvBindingNavigator.MovePreviousItem = Nothing
            Me.MouvBindingNavigator.Name = "MouvBindingNavigator"
            Me.MouvBindingNavigator.PositionItem = Nothing
            Me.MouvBindingNavigator.Size = New System.Drawing.Size(711, 25)
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
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.BtDepots)
            Me.GradientPanel1.Controls.Add(DepotDestLabel)
            Me.GradientPanel1.Controls.Add(Me.DepotDestComboBox)
            Me.GradientPanel1.Controls.Add(DepotDepartLabel)
            Me.GradientPanel1.Controls.Add(Me.DepotDepartComboBox)
            Me.GradientPanel1.Controls.Add(TypeMouvementLabel)
            Me.GradientPanel1.Controls.Add(Me.TypeMouvementComboBox)
            Me.GradientPanel1.Controls.Add(Me.TbRefreshNLot)
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
            Me.GradientPanel1.Size = New System.Drawing.Size(711, 93)
            Me.GradientPanel1.TabIndex = 1
            '
            'BtDepots
            '
            Me.BtDepots.Location = New System.Drawing.Point(476, 61)
            Me.BtDepots.Name = "BtDepots"
            Me.BtDepots.Size = New System.Drawing.Size(58, 21)
            Me.BtDepots.TabIndex = 13
            Me.BtDepots.Text = "Dépôts"
            Me.BtDepots.UseVisualStyleBackColor = True
            '
            'DepotDestComboBox
            '
            Me.DepotDestComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "DepotDest", True))
            Me.DepotDestComboBox.DataSource = Me.ChoixDepotDestBindingSource
            Me.DepotDestComboBox.DisplayMember = "Valeur"
            Me.DepotDestComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.DepotDestComboBox.FormattingEnabled = True
            Me.DepotDestComboBox.Location = New System.Drawing.Point(320, 61)
            Me.DepotDestComboBox.Name = "DepotDestComboBox"
            Me.DepotDestComboBox.Size = New System.Drawing.Size(150, 21)
            Me.DepotDestComboBox.TabIndex = 12
            Me.DepotDestComboBox.ValueMember = "Valeur"
            '
            'ChoixDepotDestBindingSource
            '
            Me.ChoixDepotDestBindingSource.DataMember = "ListeChoix"
            Me.ChoixDepotDestBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ChoixDepotDestBindingSource.Sort = "nOrdreValeur"
            '
            'DepotDepartComboBox
            '
            Me.DepotDepartComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "DepotDepart", True))
            Me.DepotDepartComboBox.DataSource = Me.ChoixDepotDepartBindingSource
            Me.DepotDepartComboBox.DisplayMember = "Valeur"
            Me.DepotDepartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.DepotDepartComboBox.FormattingEnabled = True
            Me.DepotDepartComboBox.Location = New System.Drawing.Point(92, 61)
            Me.DepotDepartComboBox.Name = "DepotDepartComboBox"
            Me.DepotDepartComboBox.Size = New System.Drawing.Size(150, 21)
            Me.DepotDepartComboBox.TabIndex = 10
            Me.DepotDepartComboBox.ValueMember = "Valeur"
            '
            'ChoixDepotDepartBindingSource
            '
            Me.ChoixDepotDepartBindingSource.DataMember = "ListeChoix"
            Me.ChoixDepotDepartBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ChoixDepotDepartBindingSource.Sort = "nOrdreValeur"
            '
            'TypeMouvementComboBox
            '
            Me.TypeMouvementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MouvBindingSource, "TypeMouvement", True))
            Me.TypeMouvementComboBox.DataSource = Me.ChoixTypeMvtBindingSource
            Me.TypeMouvementComboBox.DisplayMember = "Valeur"
            Me.TypeMouvementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.TypeMouvementComboBox.FormattingEnabled = True
            Me.TypeMouvementComboBox.Location = New System.Drawing.Point(92, 8)
            Me.TypeMouvementComboBox.Name = "TypeMouvementComboBox"
            Me.TypeMouvementComboBox.Size = New System.Drawing.Size(150, 21)
            Me.TypeMouvementComboBox.TabIndex = 1
            Me.TypeMouvementComboBox.ValueMember = "Valeur"
            '
            'ChoixTypeMvtBindingSource
            '
            Me.ChoixTypeMvtBindingSource.DataMember = "ListeChoix"
            Me.ChoixTypeMvtBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ChoixTypeMvtBindingSource.Filter = ""
            Me.ChoixTypeMvtBindingSource.Sort = "nOrdreValeur"
            '
            'TbRefreshNLot
            '
            Me.TbRefreshNLot.Enabled = False
            Me.TbRefreshNLot.Image = Global.ControleTracabilite.My.Resources.Resources.RepeatHS
            Me.TbRefreshNLot.Location = New System.Drawing.Point(378, 10)
            Me.TbRefreshNLot.Name = "TbRefreshNLot"
            Me.TbRefreshNLot.Size = New System.Drawing.Size(26, 20)
            Me.TbRefreshNLot.TabIndex = 4
            Me.TbRefreshNLot.UseVisualStyleBackColor = True
            '
            'DescriptionTextBox
            '
            Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "Description", True))
            Me.DescriptionTextBox.Location = New System.Drawing.Point(92, 35)
            Me.DescriptionTextBox.MaxLength = 50
            Me.DescriptionTextBox.Name = "DescriptionTextBox"
            Me.DescriptionTextBox.Size = New System.Drawing.Size(442, 20)
            Me.DescriptionTextBox.TabIndex = 8
            '
            'NPieceTextBox
            '
            Me.NPieceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MouvBindingSource, "nPiece", True))
            Me.NPieceTextBox.Location = New System.Drawing.Point(276, 10)
            Me.NPieceTextBox.Name = "NPieceTextBox"
            Me.NPieceTextBox.Size = New System.Drawing.Size(102, 20)
            Me.NPieceTextBox.TabIndex = 3
            Me.NPieceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'DateFactureDateTimePicker
            '
            Me.DateFactureDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.MouvBindingSource, "DateMouvement", True))
            Me.DateFactureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.DateFactureDateTimePicker.Location = New System.Drawing.Point(448, 10)
            Me.DateFactureDateTimePicker.Name = "DateFactureDateTimePicker"
            Me.DateFactureDateTimePicker.Size = New System.Drawing.Size(86, 20)
            Me.DateFactureDateTimePicker.TabIndex = 6
            '
            'MouvDetailBindingSource
            '
            Me.MouvDetailBindingSource.DataMember = "FK_Mouvement_Detail_Mouvement"
            Me.MouvDetailBindingSource.DataSource = Me.MouvBindingSource
            Me.MouvDetailBindingSource.Filter = ""
            '
            'ProduitBindingSource
            '
            Me.ProduitBindingSource.DataMember = "Produit"
            Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitBindingSource.Filter = ""
            Me.ProduitBindingSource.Sort = "Libelle"
            '
            'MouvDetailBindingNavigator
            '
            Me.MouvDetailBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem1
            Me.MouvDetailBindingNavigator.BindingSource = Me.MouvDetailBindingSource
            Me.MouvDetailBindingNavigator.CountItem = Nothing
            Me.MouvDetailBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem1
            Me.MouvDetailBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MouvDetailBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem1, Me.ToolStripSeparator1, Me.TbCodeBarre})
            Me.MouvDetailBindingNavigator.Location = New System.Drawing.Point(0, 118)
            Me.MouvDetailBindingNavigator.MoveFirstItem = Nothing
            Me.MouvDetailBindingNavigator.MoveLastItem = Nothing
            Me.MouvDetailBindingNavigator.MoveNextItem = Nothing
            Me.MouvDetailBindingNavigator.MovePreviousItem = Nothing
            Me.MouvDetailBindingNavigator.Name = "MouvDetailBindingNavigator"
            Me.MouvDetailBindingNavigator.PositionItem = Nothing
            Me.MouvDetailBindingNavigator.Size = New System.Drawing.Size(711, 25)
            Me.MouvDetailBindingNavigator.TabIndex = 2
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
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'TbCodeBarre
            '
            Me.TbCodeBarre.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
            Me.TbCodeBarre.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbCodeBarre.Name = "TbCodeBarre"
            Me.TbCodeBarre.Size = New System.Drawing.Size(135, 22)
            Me.TbCodeBarre.Text = "Saisie par code barre"
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
            'ProduitsDataGridView
            '
            Me.ProduitsDataGridView.AutoGenerateColumns = False
            Me.ProduitsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NMouvementDetailDataGridViewTextBoxColumn1, Me.PFCodeProduit, Me.ColRechProd, Me.nLot, Me.ColRechLot, Me.PFLibelle, Me.PFUnite1, Me.PFLibUnite1, Me.PFUnite2, Me.PFLibUnite2})
            Me.ProduitsDataGridView.DataSource = Me.MouvDetailBindingSource
            Me.ProduitsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ProduitsDataGridView.Location = New System.Drawing.Point(0, 143)
            Me.ProduitsDataGridView.Name = "ProduitsDataGridView"
            Me.ProduitsDataGridView.Size = New System.Drawing.Size(711, 314)
            Me.ProduitsDataGridView.TabIndex = 3
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
            Me.PFCodeProduit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PFCodeProduit.DataPropertyName = "CodeProduit"
            Me.PFCodeProduit.DataSource = Me.ProduitBindingSource
            Me.PFCodeProduit.DisplayMember = "ProduitDisplay"
            Me.PFCodeProduit.DisplayStyleForCurrentCellOnly = True
            Me.PFCodeProduit.DropDownWidth = 400
            Me.PFCodeProduit.HeaderText = "Code"
            Me.PFCodeProduit.Name = "PFCodeProduit"
            Me.PFCodeProduit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFCodeProduit.ValueMember = "CodeProduit"
            Me.PFCodeProduit.Width = 38
            '
            'ColRechProd
            '
            Me.ColRechProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
            DataGridViewCellStyle1.NullValue = "€"
            Me.ColRechProd.DefaultCellStyle = DataGridViewCellStyle1
            Me.ColRechProd.HeaderText = ""
            Me.ColRechProd.Name = "ColRechProd"
            Me.ColRechProd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ColRechProd.Text = "€"
            Me.ColRechProd.ToolTipText = "Rechercher un produit"
            Me.ColRechProd.Width = 20
            '
            'nLot
            '
            Me.nLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.nLot.DataPropertyName = "nLot"
            Me.nLot.HeaderText = "Lot"
            Me.nLot.Name = "nLot"
            Me.nLot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.nLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.nLot.Width = 28
            '
            'ColRechLot
            '
            Me.ColRechLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
            DataGridViewCellStyle2.NullValue = "€"
            Me.ColRechLot.DefaultCellStyle = DataGridViewCellStyle2
            Me.ColRechLot.HeaderText = ""
            Me.ColRechLot.Name = "ColRechLot"
            Me.ColRechLot.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ColRechLot.Text = "€"
            Me.ColRechLot.ToolTipText = "Rechercher un Lot"
            Me.ColRechLot.Width = 20
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
            Me.PFUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PFUnite1.DataPropertyName = "Unite1"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.PFUnite1.DefaultCellStyle = DataGridViewCellStyle3
            Me.PFUnite1.HeaderText = "Quantité 1"
            Me.PFUnite1.Name = "PFUnite1"
            Me.PFUnite1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFUnite1.Width = 81
            '
            'PFLibUnite1
            '
            Me.PFLibUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PFLibUnite1.DataPropertyName = "LibUnite1"
            Me.PFLibUnite1.HeaderText = ""
            Me.PFLibUnite1.Name = "PFLibUnite1"
            Me.PFLibUnite1.ReadOnly = True
            Me.PFLibUnite1.Width = 19
            '
            'PFUnite2
            '
            Me.PFUnite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PFUnite2.DataPropertyName = "Unite2"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "N3"
            Me.PFUnite2.DefaultCellStyle = DataGridViewCellStyle4
            Me.PFUnite2.HeaderText = "Quantité 2"
            Me.PFUnite2.Name = "PFUnite2"
            Me.PFUnite2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PFUnite2.Width = 81
            '
            'PFLibUnite2
            '
            Me.PFLibUnite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PFLibUnite2.DataPropertyName = "LibUnite2"
            Me.PFLibUnite2.HeaderText = ""
            Me.PFLibUnite2.Name = "PFLibUnite2"
            Me.PFLibUnite2.ReadOnly = True
            Me.PFLibUnite2.Width = 19
            '
            'ListeChoixTableAdapter
            '
            Me.ListeChoixTableAdapter.ClearBeforeFill = True
            '
            'FrSaisieMouvement
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(711, 457)
            Me.ControlBox = False
            Me.Controls.Add(Me.ProduitsDataGridView)
            Me.Controls.Add(Me.MouvDetailBindingNavigator)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.MouvBindingNavigator)
            Me.Name = "FrSaisieMouvement"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Saisie d'un mouvement"
            CType(Me.MouvBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MouvBindingNavigator.ResumeLayout(False)
            Me.MouvBindingNavigator.PerformLayout()
            CType(Me.MouvBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.ChoixDepotDestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChoixDepotDepartBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChoixTypeMvtBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MouvDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MouvDetailBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MouvDetailBindingNavigator.ResumeLayout(False)
            Me.MouvDetailBindingNavigator.PerformLayout()
            CType(Me.ProduitsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DateFactureDateTimePicker As System.Windows.Forms.DateTimePicker
        Friend WithEvents MouvDetailBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents MouvDetailBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
        Friend WithEvents MouvementTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
        Friend WithEvents Mouvement_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
        Friend WithEvents NPieceTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DateFactureLabel As System.Windows.Forms.Label
        Friend WithEvents NPieceLabel As System.Windows.Forms.Label
        Friend WithEvents TbRefreshNLot As System.Windows.Forms.Button
        Friend WithEvents ProduitsDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents DepotDestComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents DepotDepartComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents TypeMouvementComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ChoixTypeMvtBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ListeChoixTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
        Friend WithEvents ChoixDepotDepartBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ChoixDepotDestBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbCodeBarre As System.Windows.Forms.ToolStripButton
        Friend WithEvents NMouvementDetailDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFCodeProduit As ControleTracabilite.DatagridViewComboboxColumnCustom
        Friend WithEvents ColRechProd As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents nLot As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColRechLot As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents PFLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFUnite1 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents PFLibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PFUnite2 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents PFLibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BtDepots As System.Windows.Forms.Button
    End Class
End Namespace