<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrPlanTypeJournaux
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrPlanTypeJournaux))
        Me.Label1 = New System.Windows.Forms.Label
        Me.JCodeJournalTextBox = New System.Windows.Forms.TextBox
        Me.JournalAvecErreurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetdbPlanType = New AgrigestEDI.DataSetdbPlanType
        Me.JCodeLibelleTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.JTypeComboBox = New System.Windows.Forms.ComboBox
        Me.TypeJournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.JCompteContreComboBox = New System.Windows.Forms.ComboBox
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetAgrigest = New AgrigestEDI.DataSetAgrigest
        Me.JLibelleTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.JournalAvecErreurDataGridView = New System.Windows.Forms.DataGridView
        Me.JCodeJournalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JCodeLibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JCompteContreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JLibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErreurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SupprimerCompteContreButton = New System.Windows.Forms.Button
        Me.PlanComptableTableAdapter = New AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
        Me.JournalAvecErreurTableAdapter = New AgrigestEDI.DataSetdbPlanTypeTableAdapters.JournalAvecErreurTableAdapter
        Me.JournalAvecErreurBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.JournauxGroupBox = New System.Windows.Forms.GroupBox
        CType(Me.JournalAvecErreurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetdbPlanType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeJournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JournalAvecErreurDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JournalAvecErreurBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.JournalAvecErreurBindingNavigator.SuspendLayout()
        Me.JournauxGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code journal :"
        '
        'JCodeJournalTextBox
        '
        Me.JCodeJournalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JournalAvecErreurBindingSource, "JCodeJournal", True))
        Me.JCodeJournalTextBox.Enabled = False
        Me.JCodeJournalTextBox.Location = New System.Drawing.Point(149, 19)
        Me.JCodeJournalTextBox.MaxLength = 2
        Me.JCodeJournalTextBox.Name = "JCodeJournalTextBox"
        Me.JCodeJournalTextBox.Size = New System.Drawing.Size(29, 20)
        Me.JCodeJournalTextBox.TabIndex = 1
        Me.JCodeJournalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'JournalAvecErreurBindingSource
        '
        Me.JournalAvecErreurBindingSource.DataMember = "JournalAvecErreur"
        Me.JournalAvecErreurBindingSource.DataSource = Me.DataSetdbPlanType
        '
        'DataSetdbPlanType
        '
        Me.DataSetdbPlanType.DataSetName = "DataSetdbPlanType"
        Me.DataSetdbPlanType.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'JCodeLibelleTextBox
        '
        Me.JCodeLibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JournalAvecErreurBindingSource, "JCodeLibelle", True))
        Me.JCodeLibelleTextBox.Location = New System.Drawing.Point(149, 45)
        Me.JCodeLibelleTextBox.MaxLength = 50
        Me.JCodeLibelleTextBox.Name = "JCodeLibelleTextBox"
        Me.JCodeLibelleTextBox.Size = New System.Drawing.Size(311, 20)
        Me.JCodeLibelleTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Code libellé :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Type :"
        '
        'JTypeComboBox
        '
        Me.JTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.JournalAvecErreurBindingSource, "JType", True))
        Me.JTypeComboBox.DataSource = Me.TypeJournalBindingSource
        Me.JTypeComboBox.DisplayMember = "LibelleTypeJournal"
        Me.JTypeComboBox.FormattingEnabled = True
        Me.JTypeComboBox.Location = New System.Drawing.Point(149, 71)
        Me.JTypeComboBox.Name = "JTypeComboBox"
        Me.JTypeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.JTypeComboBox.TabIndex = 3
        Me.JTypeComboBox.ValueMember = "TypeJournal"
        '
        'TypeJournalBindingSource
        '
        Me.TypeJournalBindingSource.DataMember = "TypeJournal"
        Me.TypeJournalBindingSource.DataSource = Me.DataSetdbPlanType
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Compte de contrepartie :"
        '
        'JCompteContreComboBox
        '
        Me.JCompteContreComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.JournalAvecErreurBindingSource, "JCompteContre", True))
        Me.JCompteContreComboBox.DataSource = Me.PlanComptableBindingSource
        Me.JCompteContreComboBox.DisplayMember = "PlCpt"
        Me.JCompteContreComboBox.FormattingEnabled = True
        Me.JCompteContreComboBox.Location = New System.Drawing.Point(149, 98)
        Me.JCompteContreComboBox.Name = "JCompteContreComboBox"
        Me.JCompteContreComboBox.Size = New System.Drawing.Size(121, 21)
        Me.JCompteContreComboBox.TabIndex = 4
        Me.JCompteContreComboBox.ValueMember = "PlCpt"
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
        'JLibelleTextBox
        '
        Me.JLibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JournalAvecErreurBindingSource, "JLibelle", True))
        Me.JLibelleTextBox.Location = New System.Drawing.Point(149, 125)
        Me.JLibelleTextBox.MaxLength = 50
        Me.JLibelleTextBox.Name = "JLibelleTextBox"
        Me.JLibelleTextBox.Size = New System.Drawing.Size(311, 20)
        Me.JLibelleTextBox.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Libellé :"
        '
        'JournalAvecErreurDataGridView
        '
        Me.JournalAvecErreurDataGridView.AllowUserToAddRows = False
        Me.JournalAvecErreurDataGridView.AllowUserToDeleteRows = False
        Me.JournalAvecErreurDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JournalAvecErreurDataGridView.AutoGenerateColumns = False
        Me.JournalAvecErreurDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.JournalAvecErreurDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.JournalAvecErreurDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JCodeJournalDataGridViewTextBoxColumn, Me.JCodeLibelleDataGridViewTextBoxColumn, Me.JTypeDataGridViewTextBoxColumn, Me.JCompteContreDataGridViewTextBoxColumn, Me.JLibelleDataGridViewTextBoxColumn, Me.ErreurDataGridViewTextBoxColumn})
        Me.JournalAvecErreurDataGridView.DataSource = Me.JournalAvecErreurBindingSource
        Me.JournalAvecErreurDataGridView.Location = New System.Drawing.Point(12, 216)
        Me.JournalAvecErreurDataGridView.MultiSelect = False
        Me.JournalAvecErreurDataGridView.Name = "JournalAvecErreurDataGridView"
        Me.JournalAvecErreurDataGridView.ReadOnly = True
        Me.JournalAvecErreurDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.JournalAvecErreurDataGridView.Size = New System.Drawing.Size(884, 252)
        Me.JournalAvecErreurDataGridView.TabIndex = 9
        '
        'JCodeJournalDataGridViewTextBoxColumn
        '
        Me.JCodeJournalDataGridViewTextBoxColumn.DataPropertyName = "JCodeJournal"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.JCodeJournalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.JCodeJournalDataGridViewTextBoxColumn.HeaderText = "Code journal"
        Me.JCodeJournalDataGridViewTextBoxColumn.Name = "JCodeJournalDataGridViewTextBoxColumn"
        Me.JCodeJournalDataGridViewTextBoxColumn.ReadOnly = True
        Me.JCodeJournalDataGridViewTextBoxColumn.Width = 60
        '
        'JCodeLibelleDataGridViewTextBoxColumn
        '
        Me.JCodeLibelleDataGridViewTextBoxColumn.DataPropertyName = "JCodeLibelle"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JCodeLibelleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.JCodeLibelleDataGridViewTextBoxColumn.HeaderText = "Code libelle"
        Me.JCodeLibelleDataGridViewTextBoxColumn.Name = "JCodeLibelleDataGridViewTextBoxColumn"
        Me.JCodeLibelleDataGridViewTextBoxColumn.ReadOnly = True
        Me.JCodeLibelleDataGridViewTextBoxColumn.Width = 200
        '
        'JTypeDataGridViewTextBoxColumn
        '
        Me.JTypeDataGridViewTextBoxColumn.DataPropertyName = "JType"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.JTypeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.JTypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.JTypeDataGridViewTextBoxColumn.Name = "JTypeDataGridViewTextBoxColumn"
        Me.JTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.JTypeDataGridViewTextBoxColumn.Width = 60
        '
        'JCompteContreDataGridViewTextBoxColumn
        '
        Me.JCompteContreDataGridViewTextBoxColumn.DataPropertyName = "JCompteContre"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.JCompteContreDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.JCompteContreDataGridViewTextBoxColumn.HeaderText = "Compte contrepartie"
        Me.JCompteContreDataGridViewTextBoxColumn.Name = "JCompteContreDataGridViewTextBoxColumn"
        Me.JCompteContreDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JLibelleDataGridViewTextBoxColumn
        '
        Me.JLibelleDataGridViewTextBoxColumn.DataPropertyName = "JLibelle"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JLibelleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.JLibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.JLibelleDataGridViewTextBoxColumn.Name = "JLibelleDataGridViewTextBoxColumn"
        Me.JLibelleDataGridViewTextBoxColumn.ReadOnly = True
        Me.JLibelleDataGridViewTextBoxColumn.Width = 200
        '
        'ErreurDataGridViewTextBoxColumn
        '
        Me.ErreurDataGridViewTextBoxColumn.DataPropertyName = "Erreur"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ErreurDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ErreurDataGridViewTextBoxColumn.HeaderText = "Erreur"
        Me.ErreurDataGridViewTextBoxColumn.Name = "ErreurDataGridViewTextBoxColumn"
        Me.ErreurDataGridViewTextBoxColumn.ReadOnly = True
        Me.ErreurDataGridViewTextBoxColumn.Width = 200
        '
        'SupprimerCompteContreButton
        '
        Me.SupprimerCompteContreButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerCompteContreButton.Location = New System.Drawing.Point(276, 96)
        Me.SupprimerCompteContreButton.Name = "SupprimerCompteContreButton"
        Me.SupprimerCompteContreButton.Size = New System.Drawing.Size(28, 23)
        Me.SupprimerCompteContreButton.TabIndex = 10
        Me.SupprimerCompteContreButton.UseVisualStyleBackColor = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'JournalAvecErreurTableAdapter
        '
        Me.JournalAvecErreurTableAdapter.ClearBeforeFill = True
        '
        'JournalAvecErreurBindingNavigator
        '
        Me.JournalAvecErreurBindingNavigator.AddNewItem = Nothing
        Me.JournalAvecErreurBindingNavigator.BindingSource = Me.JournalAvecErreurBindingSource
        Me.JournalAvecErreurBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.JournalAvecErreurBindingNavigator.DeleteItem = Nothing
        Me.JournalAvecErreurBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.NewToolStripButton, Me.DeleteToolStripButton, Me.SaveToolStripButton})
        Me.JournalAvecErreurBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.JournalAvecErreurBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.JournalAvecErreurBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.JournalAvecErreurBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.JournalAvecErreurBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.JournalAvecErreurBindingNavigator.Name = "JournalAvecErreurBindingNavigator"
        Me.JournalAvecErreurBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.JournalAvecErreurBindingNavigator.Size = New System.Drawing.Size(908, 25)
        Me.JournalAvecErreurBindingNavigator.TabIndex = 12
        Me.JournalAvecErreurBindingNavigator.Text = "BindingNavigator1"
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
        'JournauxGroupBox
        '
        Me.JournauxGroupBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.JournauxGroupBox.Controls.Add(Me.JCodeJournalTextBox)
        Me.JournauxGroupBox.Controls.Add(Me.Label1)
        Me.JournauxGroupBox.Controls.Add(Me.SupprimerCompteContreButton)
        Me.JournauxGroupBox.Controls.Add(Me.JLibelleTextBox)
        Me.JournauxGroupBox.Controls.Add(Me.Label5)
        Me.JournauxGroupBox.Controls.Add(Me.JCodeLibelleTextBox)
        Me.JournauxGroupBox.Controls.Add(Me.Label2)
        Me.JournauxGroupBox.Controls.Add(Me.JTypeComboBox)
        Me.JournauxGroupBox.Controls.Add(Me.Label3)
        Me.JournauxGroupBox.Controls.Add(Me.JCompteContreComboBox)
        Me.JournauxGroupBox.Controls.Add(Me.Label4)
        Me.JournauxGroupBox.Location = New System.Drawing.Point(12, 28)
        Me.JournauxGroupBox.Name = "JournauxGroupBox"
        Me.JournauxGroupBox.Size = New System.Drawing.Size(504, 182)
        Me.JournauxGroupBox.TabIndex = 13
        Me.JournauxGroupBox.TabStop = False
        Me.JournauxGroupBox.Text = "Journaux"
        '
        'FrPlanTypeJournaux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 480)
        Me.Controls.Add(Me.JournauxGroupBox)
        Me.Controls.Add(Me.JournalAvecErreurBindingNavigator)
        Me.Controls.Add(Me.JournalAvecErreurDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrPlanTypeJournaux"
        Me.Text = "Journaux"
        CType(Me.JournalAvecErreurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetdbPlanType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeJournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JournalAvecErreurDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JournalAvecErreurBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.JournalAvecErreurBindingNavigator.ResumeLayout(False)
        Me.JournalAvecErreurBindingNavigator.PerformLayout()
        Me.JournauxGroupBox.ResumeLayout(False)
        Me.JournauxGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents JCodeJournalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JCodeLibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents JTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents JCompteContreComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents JLibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents JournalAvecErreurDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SupprimerCompteContreButton As System.Windows.Forms.Button
    Friend WithEvents DataSetAgrigest As AgrigestEDI.DataSetAgrigest
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents DataSetdbPlanType As AgrigestEDI.DataSetdbPlanType
    Friend WithEvents JournalAvecErreurBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalAvecErreurTableAdapter As AgrigestEDI.DataSetdbPlanTypeTableAdapters.JournalAvecErreurTableAdapter
    Friend WithEvents JCodeJournalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JCodeLibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JCompteContreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JLibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErreurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeJournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalAvecErreurBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents JournauxGroupBox As System.Windows.Forms.GroupBox
End Class
