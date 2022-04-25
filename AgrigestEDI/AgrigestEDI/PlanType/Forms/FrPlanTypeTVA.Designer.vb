<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrPlanTypeTVA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrPlanTypeTVA))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TTVATextBox = New System.Windows.Forms.TextBox
        Me.TVAAvecErreurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetdbPlanType = New AgrigestEDI.DataSetdbPlanType
        Me.Label2 = New System.Windows.Forms.Label
        Me.TypTVAComboBox = New System.Windows.Forms.ComboBox
        Me.TypeTVAPlanTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TCptComboBox = New System.Windows.Forms.ComboBox
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetAgrigest = New AgrigestEDI.DataSetAgrigest
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TCtrlCl_DCComboBox = New System.Windows.Forms.ComboBox
        Me.D_CBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TTauxTextBox = New System.Windows.Forms.TextBox
        Me.TColonneTextBox = New System.Windows.Forms.TextBox
        Me.TLigneTextBox = New System.Windows.Forms.TextBox
        Me.PlanComptableTableAdapter = New AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
        Me.TVAAvecErreurDataGridView = New System.Windows.Forms.DataGridView
        Me.TTVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TJournalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypTVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TMtTVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TCptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TCtrlMtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TTauxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TColonneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TLigneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TCtrlClDCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TCtrlClNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelléDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Erreur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TVAAvecErreurTableAdapter = New AgrigestEDI.DataSetdbPlanTypeTableAdapters.TVAAvecErreurTableAdapter
        Me.SupprimerTypeButton = New System.Windows.Forms.Button
        Me.SupprimerCompteButton = New System.Windows.Forms.Button
        Me.SupprimerTCtrlCl_DCButton = New System.Windows.Forms.Button
        Me.TCtrlCl_NumTextBox = New System.Windows.Forms.TextBox
        Me.TJournalTextBox = New System.Windows.Forms.TextBox
        Me.TMtTVATextBox = New System.Windows.Forms.TextBox
        Me.TCtrlMtTextBox = New System.Windows.Forms.TextBox
        Me.TVAAvecErreurBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.TVAGroupBox = New System.Windows.Forms.GroupBox
        CType(Me.TVAAvecErreurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetdbPlanType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeTVAPlanTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_CBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVAAvecErreurDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVAAvecErreurBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TVAAvecErreurBindingNavigator.SuspendLayout()
        Me.TVAGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Code TVA :"
        '
        'TTVATextBox
        '
        Me.TTVATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TTVA", True))
        Me.TTVATextBox.Location = New System.Drawing.Point(116, 19)
        Me.TTVATextBox.MaxLength = 5
        Me.TTVATextBox.Name = "TTVATextBox"
        Me.TTVATextBox.Size = New System.Drawing.Size(38, 20)
        Me.TTVATextBox.TabIndex = 14
        Me.TTVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVAAvecErreurBindingSource
        '
        Me.TVAAvecErreurBindingSource.DataMember = "TVAAvecErreur"
        Me.TVAAvecErreurBindingSource.DataSource = Me.DataSetdbPlanType
        '
        'DataSetdbPlanType
        '
        Me.DataSetdbPlanType.DataSetName = "DataSetdbPlanType"
        Me.DataSetdbPlanType.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(308, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Journal :"
        '
        'TypTVAComboBox
        '
        Me.TypTVAComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TVAAvecErreurBindingSource, "TypTVA", True))
        Me.TypTVAComboBox.DataSource = Me.TypeTVAPlanTypeBindingSource
        Me.TypTVAComboBox.DisplayMember = "LibelletypeTVA"
        Me.TypTVAComboBox.FormattingEnabled = True
        Me.TypTVAComboBox.Location = New System.Drawing.Point(116, 45)
        Me.TypTVAComboBox.Name = "TypTVAComboBox"
        Me.TypTVAComboBox.Size = New System.Drawing.Size(103, 21)
        Me.TypTVAComboBox.TabIndex = 18
        Me.TypTVAComboBox.ValueMember = "TypeTVA"
        '
        'TypeTVAPlanTypeBindingSource
        '
        Me.TypeTVAPlanTypeBindingSource.DataMember = "TypeTVAPlanType"
        Me.TypeTVAPlanTypeBindingSource.DataSource = Me.DataSetdbPlanType
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Type :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(308, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Montant TVA :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Compte :"
        '
        'TCptComboBox
        '
        Me.TCptComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TVAAvecErreurBindingSource, "TCpt", True))
        Me.TCptComboBox.DataSource = Me.PlanComptableBindingSource
        Me.TCptComboBox.DisplayMember = "PlCpt"
        Me.TCptComboBox.FormattingEnabled = True
        Me.TCptComboBox.Location = New System.Drawing.Point(116, 72)
        Me.TCptComboBox.Name = "TCptComboBox"
        Me.TCptComboBox.Size = New System.Drawing.Size(103, 21)
        Me.TCptComboBox.TabIndex = 22
        Me.TCptComboBox.ValueMember = "PlCpt"
        '
        'PlanComptableBindingSource
        '
        Me.PlanComptableBindingSource.DataMember = "PlanComptable"
        Me.PlanComptableBindingSource.DataSource = Me.DataSetAgrigest
        '
        'DataSetAgrigest
        '
        Me.DataSetAgrigest.DataSetName = "DataSetAgrigest"
        Me.DataSetAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Contrôle montant :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Taux :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(308, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Colonne :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Ligne :"
        '
        'TCtrlCl_DCComboBox
        '
        Me.TCtrlCl_DCComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TVAAvecErreurBindingSource, "TCtrlCl_DC", True))
        Me.TCtrlCl_DCComboBox.DataSource = Me.D_CBindingSource
        Me.TCtrlCl_DCComboBox.DisplayMember = "Sens"
        Me.TCtrlCl_DCComboBox.FormattingEnabled = True
        Me.TCtrlCl_DCComboBox.Location = New System.Drawing.Point(407, 125)
        Me.TCtrlCl_DCComboBox.Name = "TCtrlCl_DCComboBox"
        Me.TCtrlCl_DCComboBox.Size = New System.Drawing.Size(38, 21)
        Me.TCtrlCl_DCComboBox.TabIndex = 32
        Me.TCtrlCl_DCComboBox.ValueMember = "Sens"
        '
        'D_CBindingSource
        '
        Me.D_CBindingSource.DataMember = "D_C"
        Me.D_CBindingSource.DataSource = Me.DataSetdbPlanType
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(308, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Contrôle D/C :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Contrôle numéro :"
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "Libellé", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(407, 151)
        Me.LibelleTextBox.MaxLength = 40
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(257, 20)
        Me.LibelleTextBox.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(308, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Libellé :"
        '
        'TTauxTextBox
        '
        Me.TTauxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TTaux", True))
        Me.TTauxTextBox.Location = New System.Drawing.Point(116, 99)
        Me.TTauxTextBox.Name = "TTauxTextBox"
        Me.TTauxTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TTauxTextBox.TabIndex = 37
        Me.TTauxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TColonneTextBox
        '
        Me.TColonneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TColonne", True))
        Me.TColonneTextBox.Location = New System.Drawing.Point(407, 99)
        Me.TColonneTextBox.Name = "TColonneTextBox"
        Me.TColonneTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TColonneTextBox.TabIndex = 38
        Me.TColonneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLigneTextBox
        '
        Me.TLigneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TLigne", True))
        Me.TLigneTextBox.Location = New System.Drawing.Point(116, 125)
        Me.TLigneTextBox.Name = "TLigneTextBox"
        Me.TLigneTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TLigneTextBox.TabIndex = 39
        Me.TLigneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'TVAAvecErreurDataGridView
        '
        Me.TVAAvecErreurDataGridView.AllowUserToAddRows = False
        Me.TVAAvecErreurDataGridView.AllowUserToDeleteRows = False
        Me.TVAAvecErreurDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TVAAvecErreurDataGridView.AutoGenerateColumns = False
        Me.TVAAvecErreurDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.TVAAvecErreurDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TVAAvecErreurDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TTVADataGridViewTextBoxColumn, Me.TJournalDataGridViewTextBoxColumn, Me.TypTVADataGridViewTextBoxColumn, Me.TMtTVADataGridViewTextBoxColumn, Me.TCptDataGridViewTextBoxColumn, Me.TCtrlMtDataGridViewTextBoxColumn, Me.TTauxDataGridViewTextBoxColumn, Me.TColonneDataGridViewTextBoxColumn, Me.TLigneDataGridViewTextBoxColumn, Me.TCtrlClDCDataGridViewTextBoxColumn, Me.TCtrlClNumDataGridViewTextBoxColumn, Me.LibelléDataGridViewTextBoxColumn, Me.Erreur})
        Me.TVAAvecErreurDataGridView.DataSource = Me.TVAAvecErreurBindingSource
        Me.TVAAvecErreurDataGridView.Location = New System.Drawing.Point(12, 219)
        Me.TVAAvecErreurDataGridView.MultiSelect = False
        Me.TVAAvecErreurDataGridView.Name = "TVAAvecErreurDataGridView"
        Me.TVAAvecErreurDataGridView.ReadOnly = True
        Me.TVAAvecErreurDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TVAAvecErreurDataGridView.Size = New System.Drawing.Size(892, 291)
        Me.TVAAvecErreurDataGridView.TabIndex = 40
        '
        'TTVADataGridViewTextBoxColumn
        '
        Me.TTVADataGridViewTextBoxColumn.DataPropertyName = "TTVA"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TTVADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.TTVADataGridViewTextBoxColumn.HeaderText = "Code TVA"
        Me.TTVADataGridViewTextBoxColumn.Name = "TTVADataGridViewTextBoxColumn"
        Me.TTVADataGridViewTextBoxColumn.ReadOnly = True
        Me.TTVADataGridViewTextBoxColumn.Width = 60
        '
        'TJournalDataGridViewTextBoxColumn
        '
        Me.TJournalDataGridViewTextBoxColumn.DataPropertyName = "TJournal"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TJournalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TJournalDataGridViewTextBoxColumn.HeaderText = "Journal"
        Me.TJournalDataGridViewTextBoxColumn.Name = "TJournalDataGridViewTextBoxColumn"
        Me.TJournalDataGridViewTextBoxColumn.ReadOnly = True
        Me.TJournalDataGridViewTextBoxColumn.Width = 50
        '
        'TypTVADataGridViewTextBoxColumn
        '
        Me.TypTVADataGridViewTextBoxColumn.DataPropertyName = "TypTVA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TypTVADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TypTVADataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypTVADataGridViewTextBoxColumn.Name = "TypTVADataGridViewTextBoxColumn"
        Me.TypTVADataGridViewTextBoxColumn.ReadOnly = True
        Me.TypTVADataGridViewTextBoxColumn.Width = 50
        '
        'TMtTVADataGridViewTextBoxColumn
        '
        Me.TMtTVADataGridViewTextBoxColumn.DataPropertyName = "TMtTVA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TMtTVADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.TMtTVADataGridViewTextBoxColumn.HeaderText = "Mt TVA"
        Me.TMtTVADataGridViewTextBoxColumn.Name = "TMtTVADataGridViewTextBoxColumn"
        Me.TMtTVADataGridViewTextBoxColumn.ReadOnly = True
        Me.TMtTVADataGridViewTextBoxColumn.Width = 50
        '
        'TCptDataGridViewTextBoxColumn
        '
        Me.TCptDataGridViewTextBoxColumn.DataPropertyName = "TCpt"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TCptDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TCptDataGridViewTextBoxColumn.HeaderText = "Compte"
        Me.TCptDataGridViewTextBoxColumn.Name = "TCptDataGridViewTextBoxColumn"
        Me.TCptDataGridViewTextBoxColumn.ReadOnly = True
        Me.TCptDataGridViewTextBoxColumn.Width = 80
        '
        'TCtrlMtDataGridViewTextBoxColumn
        '
        Me.TCtrlMtDataGridViewTextBoxColumn.DataPropertyName = "TCtrlMt"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TCtrlMtDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TCtrlMtDataGridViewTextBoxColumn.HeaderText = "Ctrl mt"
        Me.TCtrlMtDataGridViewTextBoxColumn.Name = "TCtrlMtDataGridViewTextBoxColumn"
        Me.TCtrlMtDataGridViewTextBoxColumn.ReadOnly = True
        Me.TCtrlMtDataGridViewTextBoxColumn.Width = 50
        '
        'TTauxDataGridViewTextBoxColumn
        '
        Me.TTauxDataGridViewTextBoxColumn.DataPropertyName = "TTaux"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TTauxDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.TTauxDataGridViewTextBoxColumn.HeaderText = "Taux"
        Me.TTauxDataGridViewTextBoxColumn.Name = "TTauxDataGridViewTextBoxColumn"
        Me.TTauxDataGridViewTextBoxColumn.ReadOnly = True
        Me.TTauxDataGridViewTextBoxColumn.Width = 60
        '
        'TColonneDataGridViewTextBoxColumn
        '
        Me.TColonneDataGridViewTextBoxColumn.DataPropertyName = "TColonne"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TColonneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.TColonneDataGridViewTextBoxColumn.HeaderText = "Col."
        Me.TColonneDataGridViewTextBoxColumn.Name = "TColonneDataGridViewTextBoxColumn"
        Me.TColonneDataGridViewTextBoxColumn.ReadOnly = True
        Me.TColonneDataGridViewTextBoxColumn.Width = 50
        '
        'TLigneDataGridViewTextBoxColumn
        '
        Me.TLigneDataGridViewTextBoxColumn.DataPropertyName = "TLigne"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TLigneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.TLigneDataGridViewTextBoxColumn.HeaderText = "Lig."
        Me.TLigneDataGridViewTextBoxColumn.Name = "TLigneDataGridViewTextBoxColumn"
        Me.TLigneDataGridViewTextBoxColumn.ReadOnly = True
        Me.TLigneDataGridViewTextBoxColumn.Width = 50
        '
        'TCtrlClDCDataGridViewTextBoxColumn
        '
        Me.TCtrlClDCDataGridViewTextBoxColumn.DataPropertyName = "TCtrlCl_DC"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TCtrlClDCDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.TCtrlClDCDataGridViewTextBoxColumn.HeaderText = "Ctrl D/C"
        Me.TCtrlClDCDataGridViewTextBoxColumn.Name = "TCtrlClDCDataGridViewTextBoxColumn"
        Me.TCtrlClDCDataGridViewTextBoxColumn.ReadOnly = True
        Me.TCtrlClDCDataGridViewTextBoxColumn.Width = 60
        '
        'TCtrlClNumDataGridViewTextBoxColumn
        '
        Me.TCtrlClNumDataGridViewTextBoxColumn.DataPropertyName = "TCtrlCl_Num"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TCtrlClNumDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.TCtrlClNumDataGridViewTextBoxColumn.HeaderText = "Ctrl num"
        Me.TCtrlClNumDataGridViewTextBoxColumn.Name = "TCtrlClNumDataGridViewTextBoxColumn"
        Me.TCtrlClNumDataGridViewTextBoxColumn.ReadOnly = True
        Me.TCtrlClNumDataGridViewTextBoxColumn.Width = 60
        '
        'LibelléDataGridViewTextBoxColumn
        '
        Me.LibelléDataGridViewTextBoxColumn.DataPropertyName = "Libellé"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LibelléDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.LibelléDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LibelléDataGridViewTextBoxColumn.Name = "LibelléDataGridViewTextBoxColumn"
        Me.LibelléDataGridViewTextBoxColumn.ReadOnly = True
        Me.LibelléDataGridViewTextBoxColumn.Width = 180
        '
        'Erreur
        '
        Me.Erreur.DataPropertyName = "Erreur"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Erreur.DefaultCellStyle = DataGridViewCellStyle13
        Me.Erreur.HeaderText = "Erreur"
        Me.Erreur.Name = "Erreur"
        Me.Erreur.ReadOnly = True
        Me.Erreur.Width = 180
        '
        'TVAAvecErreurTableAdapter
        '
        Me.TVAAvecErreurTableAdapter.ClearBeforeFill = True
        '
        'SupprimerTypeButton
        '
        Me.SupprimerTypeButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerTypeButton.Location = New System.Drawing.Point(225, 43)
        Me.SupprimerTypeButton.Name = "SupprimerTypeButton"
        Me.SupprimerTypeButton.Size = New System.Drawing.Size(28, 23)
        Me.SupprimerTypeButton.TabIndex = 41
        Me.SupprimerTypeButton.UseVisualStyleBackColor = True
        '
        'SupprimerCompteButton
        '
        Me.SupprimerCompteButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerCompteButton.Location = New System.Drawing.Point(225, 70)
        Me.SupprimerCompteButton.Name = "SupprimerCompteButton"
        Me.SupprimerCompteButton.Size = New System.Drawing.Size(28, 23)
        Me.SupprimerCompteButton.TabIndex = 42
        Me.SupprimerCompteButton.UseVisualStyleBackColor = True
        '
        'SupprimerTCtrlCl_DCButton
        '
        Me.SupprimerTCtrlCl_DCButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerTCtrlCl_DCButton.Location = New System.Drawing.Point(451, 123)
        Me.SupprimerTCtrlCl_DCButton.Name = "SupprimerTCtrlCl_DCButton"
        Me.SupprimerTCtrlCl_DCButton.Size = New System.Drawing.Size(28, 23)
        Me.SupprimerTCtrlCl_DCButton.TabIndex = 43
        Me.SupprimerTCtrlCl_DCButton.UseVisualStyleBackColor = True
        '
        'TCtrlCl_NumTextBox
        '
        Me.TCtrlCl_NumTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TCtrlCl_Num", True))
        Me.TCtrlCl_NumTextBox.Location = New System.Drawing.Point(116, 151)
        Me.TCtrlCl_NumTextBox.MaxLength = 1
        Me.TCtrlCl_NumTextBox.Name = "TCtrlCl_NumTextBox"
        Me.TCtrlCl_NumTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TCtrlCl_NumTextBox.TabIndex = 44
        Me.TCtrlCl_NumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TJournalTextBox
        '
        Me.TJournalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TJournal", True))
        Me.TJournalTextBox.Location = New System.Drawing.Point(407, 19)
        Me.TJournalTextBox.MaxLength = 1
        Me.TJournalTextBox.Name = "TJournalTextBox"
        Me.TJournalTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TJournalTextBox.TabIndex = 45
        Me.TJournalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMtTVATextBox
        '
        Me.TMtTVATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TMtTVA", True))
        Me.TMtTVATextBox.Location = New System.Drawing.Point(407, 45)
        Me.TMtTVATextBox.MaxLength = 1
        Me.TMtTVATextBox.Name = "TMtTVATextBox"
        Me.TMtTVATextBox.Size = New System.Drawing.Size(38, 20)
        Me.TMtTVATextBox.TabIndex = 46
        Me.TMtTVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCtrlMtTextBox
        '
        Me.TCtrlMtTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TVAAvecErreurBindingSource, "TCtrlMt", True))
        Me.TCtrlMtTextBox.Location = New System.Drawing.Point(407, 72)
        Me.TCtrlMtTextBox.MaxLength = 1
        Me.TCtrlMtTextBox.Name = "TCtrlMtTextBox"
        Me.TCtrlMtTextBox.Size = New System.Drawing.Size(38, 20)
        Me.TCtrlMtTextBox.TabIndex = 47
        Me.TCtrlMtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVAAvecErreurBindingNavigator
        '
        Me.TVAAvecErreurBindingNavigator.AddNewItem = Nothing
        Me.TVAAvecErreurBindingNavigator.BindingSource = Me.TVAAvecErreurBindingSource
        Me.TVAAvecErreurBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TVAAvecErreurBindingNavigator.DeleteItem = Nothing
        Me.TVAAvecErreurBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.NewToolStripButton, Me.DeleteToolStripButton, Me.SaveToolStripButton})
        Me.TVAAvecErreurBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TVAAvecErreurBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TVAAvecErreurBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TVAAvecErreurBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TVAAvecErreurBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TVAAvecErreurBindingNavigator.Name = "TVAAvecErreurBindingNavigator"
        Me.TVAAvecErreurBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TVAAvecErreurBindingNavigator.Size = New System.Drawing.Size(916, 25)
        Me.TVAAvecErreurBindingNavigator.TabIndex = 48
        Me.TVAAvecErreurBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.NewDocumentHS
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "Nouveau"
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DeleteToolStripButton.Text = "Supprimer"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "Enregistrer"
        '
        'TVAGroupBox
        '
        Me.TVAGroupBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TVAGroupBox.Controls.Add(Me.TTVATextBox)
        Me.TVAGroupBox.Controls.Add(Me.Label1)
        Me.TVAGroupBox.Controls.Add(Me.SupprimerTCtrlCl_DCButton)
        Me.TVAGroupBox.Controls.Add(Me.LibelleTextBox)
        Me.TVAGroupBox.Controls.Add(Me.Label12)
        Me.TVAGroupBox.Controls.Add(Me.TCtrlMtTextBox)
        Me.TVAGroupBox.Controls.Add(Me.TypTVAComboBox)
        Me.TVAGroupBox.Controls.Add(Me.TColonneTextBox)
        Me.TVAGroupBox.Controls.Add(Me.TMtTVATextBox)
        Me.TVAGroupBox.Controls.Add(Me.TCtrlCl_DCComboBox)
        Me.TVAGroupBox.Controls.Add(Me.Label10)
        Me.TVAGroupBox.Controls.Add(Me.Label3)
        Me.TVAGroupBox.Controls.Add(Me.TJournalTextBox)
        Me.TVAGroupBox.Controls.Add(Me.SupprimerTypeButton)
        Me.TVAGroupBox.Controls.Add(Me.Label8)
        Me.TVAGroupBox.Controls.Add(Me.TCtrlCl_NumTextBox)
        Me.TVAGroupBox.Controls.Add(Me.TCptComboBox)
        Me.TVAGroupBox.Controls.Add(Me.Label5)
        Me.TVAGroupBox.Controls.Add(Me.Label6)
        Me.TVAGroupBox.Controls.Add(Me.SupprimerCompteButton)
        Me.TVAGroupBox.Controls.Add(Me.TLigneTextBox)
        Me.TVAGroupBox.Controls.Add(Me.TTauxTextBox)
        Me.TVAGroupBox.Controls.Add(Me.Label4)
        Me.TVAGroupBox.Controls.Add(Me.Label11)
        Me.TVAGroupBox.Controls.Add(Me.Label7)
        Me.TVAGroupBox.Controls.Add(Me.Label9)
        Me.TVAGroupBox.Controls.Add(Me.Label2)
        Me.TVAGroupBox.Location = New System.Drawing.Point(12, 28)
        Me.TVAGroupBox.Name = "TVAGroupBox"
        Me.TVAGroupBox.Size = New System.Drawing.Size(687, 185)
        Me.TVAGroupBox.TabIndex = 49
        Me.TVAGroupBox.TabStop = False
        Me.TVAGroupBox.Text = "TVA"
        '
        'FrPlanTypeTVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 522)
        Me.Controls.Add(Me.TVAGroupBox)
        Me.Controls.Add(Me.TVAAvecErreurBindingNavigator)
        Me.Controls.Add(Me.TVAAvecErreurDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrPlanTypeTVA"
        Me.Text = "TVA"
        CType(Me.TVAAvecErreurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetdbPlanType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeTVAPlanTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_CBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVAAvecErreurDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVAAvecErreurBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TVAAvecErreurBindingNavigator.ResumeLayout(False)
        Me.TVAAvecErreurBindingNavigator.PerformLayout()
        Me.TVAGroupBox.ResumeLayout(False)
        Me.TVAGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TypTVAComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TCptComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TCtrlCl_DCComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TTauxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TColonneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TLigneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DataSetAgrigest As AgrigestEDI.DataSetAgrigest
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents TVAAvecErreurDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataSetdbPlanType As AgrigestEDI.DataSetdbPlanType
    Friend WithEvents TVAAvecErreurBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TVAAvecErreurTableAdapter As AgrigestEDI.DataSetdbPlanTypeTableAdapters.TVAAvecErreurTableAdapter
    Friend WithEvents SupprimerTypeButton As System.Windows.Forms.Button
    Friend WithEvents SupprimerCompteButton As System.Windows.Forms.Button
    Friend WithEvents SupprimerTCtrlCl_DCButton As System.Windows.Forms.Button
    Friend WithEvents TypeTVAPlanTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TCtrlCl_NumTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TJournalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TMtTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents TCtrlMtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents D_CBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TVAAvecErreurBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TVAGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TTVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TJournalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypTVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TMtTVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TCptDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TCtrlMtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TTauxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TColonneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLigneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TCtrlClDCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TCtrlClNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelléDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Erreur As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
