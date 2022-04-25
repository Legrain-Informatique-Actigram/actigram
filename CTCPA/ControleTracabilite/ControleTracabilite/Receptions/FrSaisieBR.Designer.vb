Namespace Receptions
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieBR
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
            Dim NClientLabel As System.Windows.Forms.Label
            Dim DateFactureLabel As System.Windows.Forms.Label
            Dim ObservationLabel As System.Windows.Forms.Label
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.BRBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.TbImprimer = New System.Windows.Forms.ToolStripButton
            Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.TbPrintBarcode = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.TbRefreshNLot = New System.Windows.Forms.Button
            Me.Label1 = New System.Windows.Forms.Label
            Me.TxNLot = New System.Windows.Forms.TextBox
            Me.TermineCheckBox = New System.Windows.Forms.CheckBox
            Me.ObservationTextBox = New System.Windows.Forms.TextBox
            Me.DateFactureDateTimePicker = New System.Windows.Forms.DateTimePicker
            Me.NClientComboBox = New System.Windows.Forms.ComboBox
            Me.FournBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ABonReception_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ABonReception_DetailDataGridView = New System.Windows.Forms.DataGridView
            Me.ColCode = New System.Windows.Forms.DataGridViewComboBoxColumn
            Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ColRechProd = New System.Windows.Forms.DataGridViewButtonColumn
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn10 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColControles = New ControleTracabilite.DataGridViewDisableButtonColumn
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem1 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.ToolStripButtonAppliquerResultats = New System.Windows.Forms.ToolStripButton
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            Me.ABonReceptionTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
            Me.ABonReception_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
            NClientLabel = New System.Windows.Forms.Label
            DateFactureLabel = New System.Windows.Forms.Label
            ObservationLabel = New System.Windows.Forms.Label
            CType(Me.BRBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BRBindingNavigator.SuspendLayout()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ABonReception_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ABonReception_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SuspendLayout()
            '
            'NClientLabel
            '
            NClientLabel.AutoSize = True
            NClientLabel.Location = New System.Drawing.Point(12, 11)
            NClientLabel.Name = "NClientLabel"
            NClientLabel.Size = New System.Drawing.Size(64, 13)
            NClientLabel.TabIndex = 0
            NClientLabel.Text = "Fournisseur:"
            '
            'DateFactureLabel
            '
            DateFactureLabel.AutoSize = True
            DateFactureLabel.Location = New System.Drawing.Point(43, 38)
            DateFactureLabel.Name = "DateFactureLabel"
            DateFactureLabel.Size = New System.Drawing.Size(33, 13)
            DateFactureLabel.TabIndex = 2
            DateFactureLabel.Text = "Date:"
            '
            'ObservationLabel
            '
            ObservationLabel.AutoSize = True
            ObservationLabel.Location = New System.Drawing.Point(4, 64)
            ObservationLabel.Name = "ObservationLabel"
            ObservationLabel.Size = New System.Drawing.Size(72, 13)
            ObservationLabel.TabIndex = 8
            ObservationLabel.Text = "Observations:"
            '
            'BRBindingNavigator
            '
            Me.BRBindingNavigator.AddNewItem = Nothing
            Me.BRBindingNavigator.BindingSource = Me.BRBindingSource
            Me.BRBindingNavigator.CountItem = Nothing
            Me.BRBindingNavigator.DeleteItem = Nothing
            Me.BRBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BRBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImprimer, Me.ProduitBindingNavigatorSaveItem, Me.TbFermer, Me.TbPrintBarcode})
            Me.BRBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.BRBindingNavigator.MoveFirstItem = Nothing
            Me.BRBindingNavigator.MoveLastItem = Nothing
            Me.BRBindingNavigator.MoveNextItem = Nothing
            Me.BRBindingNavigator.MovePreviousItem = Nothing
            Me.BRBindingNavigator.Name = "BRBindingNavigator"
            Me.BRBindingNavigator.PositionItem = Nothing
            Me.BRBindingNavigator.Size = New System.Drawing.Size(618, 25)
            Me.BRBindingNavigator.TabIndex = 0
            Me.BRBindingNavigator.Text = "BindingNavigator1"
            '
            'BRBindingSource
            '
            Me.BRBindingSource.DataMember = "ABonReception"
            Me.BRBindingSource.DataSource = Me.AgrifactTracaDataSet
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
            Me.TbImprimer.Text = "Imprimer le bon de réception"
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
            'TbPrintBarcode
            '
            Me.TbPrintBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbPrintBarcode.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
            Me.TbPrintBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbPrintBarcode.Name = "TbPrintBarcode"
            Me.TbPrintBarcode.Size = New System.Drawing.Size(23, 22)
            Me.TbPrintBarcode.Text = "Imprimer des etiquettes code-barre"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.TbRefreshNLot)
            Me.GradientPanel1.Controls.Add(Me.Label1)
            Me.GradientPanel1.Controls.Add(Me.TxNLot)
            Me.GradientPanel1.Controls.Add(Me.TermineCheckBox)
            Me.GradientPanel1.Controls.Add(ObservationLabel)
            Me.GradientPanel1.Controls.Add(Me.ObservationTextBox)
            Me.GradientPanel1.Controls.Add(DateFactureLabel)
            Me.GradientPanel1.Controls.Add(Me.DateFactureDateTimePicker)
            Me.GradientPanel1.Controls.Add(NClientLabel)
            Me.GradientPanel1.Controls.Add(Me.NClientComboBox)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(618, 155)
            Me.GradientPanel1.TabIndex = 1
            '
            'TbRefreshNLot
            '
            Me.TbRefreshNLot.Image = Global.ControleTracabilite.My.Resources.Resources.RepeatHS
            Me.TbRefreshNLot.Location = New System.Drawing.Point(400, 35)
            Me.TbRefreshNLot.Name = "TbRefreshNLot"
            Me.TbRefreshNLot.Size = New System.Drawing.Size(26, 20)
            Me.TbRefreshNLot.TabIndex = 6
            Me.TbRefreshNLot.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(176, 38)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(51, 13)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "N° du lot:"
            '
            'TxNLot
            '
            Me.TxNLot.Location = New System.Drawing.Point(233, 35)
            Me.TxNLot.MaxLength = 255
            Me.TxNLot.Name = "TxNLot"
            Me.TxNLot.Size = New System.Drawing.Size(167, 20)
            Me.TxNLot.TabIndex = 5
            '
            'TermineCheckBox
            '
            Me.TermineCheckBox.AutoSize = True
            Me.TermineCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BRBindingSource, "Termine", True))
            Me.TermineCheckBox.Location = New System.Drawing.Point(432, 38)
            Me.TermineCheckBox.Name = "TermineCheckBox"
            Me.TermineCheckBox.Size = New System.Drawing.Size(64, 17)
            Me.TermineCheckBox.TabIndex = 7
            Me.TermineCheckBox.Text = "Terminé"
            '
            'ObservationTextBox
            '
            Me.ObservationTextBox.AcceptsReturn = True
            Me.ObservationTextBox.AcceptsTab = True
            Me.ObservationTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ObservationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BRBindingSource, "Observation", True))
            Me.ObservationTextBox.Location = New System.Drawing.Point(82, 61)
            Me.ObservationTextBox.Multiline = True
            Me.ObservationTextBox.Name = "ObservationTextBox"
            Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ObservationTextBox.Size = New System.Drawing.Size(524, 86)
            Me.ObservationTextBox.TabIndex = 9
            '
            'DateFactureDateTimePicker
            '
            Me.DateFactureDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BRBindingSource, "DateFacture", True))
            Me.DateFactureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.DateFactureDateTimePicker.Location = New System.Drawing.Point(82, 35)
            Me.DateFactureDateTimePicker.Name = "DateFactureDateTimePicker"
            Me.DateFactureDateTimePicker.Size = New System.Drawing.Size(88, 20)
            Me.DateFactureDateTimePicker.TabIndex = 3
            '
            'NClientComboBox
            '
            Me.NClientComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.NClientComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.NClientComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BRBindingSource, "nClient", True))
            Me.NClientComboBox.DataSource = Me.FournBindingSource
            Me.NClientComboBox.DisplayMember = "Nom"
            Me.NClientComboBox.FormattingEnabled = True
            Me.NClientComboBox.Location = New System.Drawing.Point(82, 8)
            Me.NClientComboBox.Name = "NClientComboBox"
            Me.NClientComboBox.Size = New System.Drawing.Size(318, 21)
            Me.NClientComboBox.TabIndex = 1
            Me.NClientComboBox.ValueMember = "nEntreprise"
            '
            'FournBindingSource
            '
            Me.FournBindingSource.DataMember = "Entreprise"
            Me.FournBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.FournBindingSource.Sort = "Nom"
            '
            'ABonReception_DetailBindingSource
            '
            Me.ABonReception_DetailBindingSource.DataMember = "FK_ABonReception_Detail_ABonReception"
            Me.ABonReception_DetailBindingSource.DataSource = Me.BRBindingSource
            '
            'ABonReception_DetailDataGridView
            '
            Me.ABonReception_DetailDataGridView.AutoGenerateColumns = False
            Me.ABonReception_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCode, Me.ColRechProd, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.ColControles})
            Me.ABonReception_DetailDataGridView.DataSource = Me.ABonReception_DetailBindingSource
            Me.ABonReception_DetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ABonReception_DetailDataGridView.Location = New System.Drawing.Point(3, 41)
            Me.ABonReception_DetailDataGridView.MultiSelect = False
            Me.ABonReception_DetailDataGridView.Name = "ABonReception_DetailDataGridView"
            Me.ABonReception_DetailDataGridView.Size = New System.Drawing.Size(612, 233)
            Me.ABonReception_DetailDataGridView.TabIndex = 1
            '
            'ColCode
            '
            Me.ColCode.DataPropertyName = "CodeProduit"
            Me.ColCode.DataSource = Me.ProduitBindingSource
            Me.ColCode.DisplayMember = "ProduitDisplay"
            Me.ColCode.DisplayStyleForCurrentCellOnly = True
            Me.ColCode.DropDownWidth = 400
            Me.ColCode.HeaderText = "Code"
            Me.ColCode.Name = "ColCode"
            Me.ColCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ColCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.ColCode.ValueMember = "CodeProduit"
            '
            'ProduitBindingSource
            '
            Me.ProduitBindingSource.DataMember = "Produit"
            Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitBindingSource.Filter = "ProduitAchat=1 AND Inactif=False"
            Me.ProduitBindingSource.Sort = "Libelle"
            '
            'ColRechProd
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 3", 9.0!)
            DataGridViewCellStyle1.NullValue = "€"
            Me.ColRechProd.DefaultCellStyle = DataGridViewCellStyle1
            Me.ColRechProd.HeaderText = ""
            Me.ColRechProd.Name = "ColRechProd"
            Me.ColRechProd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ColRechProd.Text = "€"
            Me.ColRechProd.ToolTipText = "Rechercher un produit"
            Me.ColRechProd.UseColumnTextForButtonValue = True
            Me.ColRechProd.Width = 20
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "Libelle"
            Me.DataGridViewTextBoxColumn6.HeaderText = "Libellé"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "Unite1"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N3"
            Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn8.HeaderText = "Quantité 1"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn8.Width = 75
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "LibUnite1"
            Me.DataGridViewTextBoxColumn9.HeaderText = ""
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 30
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "Unite2"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité 2"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn10.Width = 75
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "LibUnite2"
            Me.DataGridViewTextBoxColumn11.HeaderText = ""
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Width = 30
            '
            'ColControles
            '
            Me.ColControles.HeaderText = ""
            Me.ColControles.Image = Global.ControleTracabilite.My.Resources.Resources.controles
            Me.ColControles.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.ColControles.Name = "ColControles"
            Me.ColControles.Text = ""
            Me.ColControles.ToolTipText = "Contrôles du produit"
            Me.ColControles.UseColumnTextForButtonValue = True
            Me.ColControles.Width = 30
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.ABonReception_DetailDataGridView)
            Me.GroupBox1.Controls.Add(Me.BindingNavigator1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 180)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(618, 277)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Produits"
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem1
            Me.BindingNavigator1.BindingSource = Me.ABonReception_DetailBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem1
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem1, Me.ToolStripSeparator1, Me.ToolStripButtonAppliquerResultats})
            Me.BindingNavigator1.Location = New System.Drawing.Point(3, 16)
            Me.BindingNavigator1.MoveFirstItem = Nothing
            Me.BindingNavigator1.MoveLastItem = Nothing
            Me.BindingNavigator1.MoveNextItem = Nothing
            Me.BindingNavigator1.MovePreviousItem = Nothing
            Me.BindingNavigator1.Name = "BindingNavigator1"
            Me.BindingNavigator1.PositionItem = Nothing
            Me.BindingNavigator1.Size = New System.Drawing.Size(612, 25)
            Me.BindingNavigator1.TabIndex = 0
            Me.BindingNavigator1.Text = "BindingNavigator1"
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
            'ToolStripButtonAppliquerResultats
            '
            Me.ToolStripButtonAppliquerResultats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButtonAppliquerResultats.Image = Global.ControleTracabilite.My.Resources.Resources.Import
            Me.ToolStripButtonAppliquerResultats.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButtonAppliquerResultats.Name = "ToolStripButtonAppliquerResultats"
            Me.ToolStripButtonAppliquerResultats.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButtonAppliquerResultats.Text = "ToolStripButtonCopierResultats"
            Me.ToolStripButtonAppliquerResultats.ToolTipText = "Appliquer les résultats des contrôles associés à la ligne sélectionnée à tous les" & _
                " contrôles communs de la liste."
            '
            'ProduitTableAdapter
            '
            Me.ProduitTableAdapter.ClearBeforeFill = True
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'ABonReceptionTableAdapter
            '
            Me.ABonReceptionTableAdapter.ClearBeforeFill = True
            '
            'ABonReception_DetailTableAdapter
            '
            Me.ABonReception_DetailTableAdapter.ClearBeforeFill = True
            '
            'FrSaisieBR
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(618, 457)
            Me.ControlBox = False
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.BRBindingNavigator)
            Me.Name = "FrSaisieBR"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Saisie d'un bon de réception"
            CType(Me.BRBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BRBindingNavigator.ResumeLayout(False)
            Me.BRBindingNavigator.PerformLayout()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ABonReception_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ABonReception_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents BRBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Friend WithEvents BRBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents FournBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents ABonReceptionTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
        Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DateFactureDateTimePicker As System.Windows.Forms.DateTimePicker
        Friend WithEvents NClientComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ABonReception_DetailBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ABonReception_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
        Friend WithEvents ABonReception_DetailDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
        Friend WithEvents TermineCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TxNLot As System.Windows.Forms.TextBox
        Friend WithEvents TbPrintBarcode As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbRefreshNLot As System.Windows.Forms.Button
        Friend WithEvents ColCode As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents ColRechProd As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColControles As ControleTracabilite.DataGridViewDisableButtonColumn
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripButtonAppliquerResultats As System.Windows.Forms.ToolStripButton
    End Class
End Namespace