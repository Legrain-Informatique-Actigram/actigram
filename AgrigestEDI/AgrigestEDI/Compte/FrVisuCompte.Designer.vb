<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrVisuCompte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim CompteDisplayLabel As System.Windows.Forms.Label
        Dim ActDisplayLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrVisuCompte))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DbDonneesDataSet = New AgrigestEDI.dbDonneesDataSet
        Me.cboCompteDisplay = New System.Windows.Forms.ComboBox
        Me.CompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.cboActDisplay = New System.Windows.Forms.ComboBox
        Me.PlanActiviteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MouvementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MouvementsTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
        Me.dgvMouvements = New System.Windows.Forms.DataGridView
        Me.CMSOptionLigne = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LettrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DélettrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmsVisualiserPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmsModifPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsSupprPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.ActionsDdb = New System.Windows.Forms.ToolStripDropDownButton
        Me.chkFull = New System.Windows.Forms.CheckBox
        Me.lblDateEnd = New System.Windows.Forms.Label
        Me.lblDateStart = New System.Windows.Forms.Label
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.pgBar = New System.Windows.Forms.ToolStripProgressBar
        Me.lbStatut = New System.Windows.Forms.ToolStripLabel
        Me.TbFiltrerLettrage = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.RechercheCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimerLeCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LettrageAutomatiqueToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tlpLettrage = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbLettreMtD = New System.Windows.Forms.Label
        Me.lbLettreSoldeD = New System.Windows.Forms.Label
        Me.lbLettreMtC = New System.Windows.Forms.Label
        Me.lbLettreSoldeC = New System.Windows.Forms.Label
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.TLPTotaux = New System.Windows.Forms.TableLayoutPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLabelTotalPro = New System.Windows.Forms.Label
        Me.lblLabelSoldePro = New System.Windows.Forms.Label
        Me.lblLabelTotalGen = New System.Windows.Forms.Label
        Me.lblLabelSoldeGen = New System.Windows.Forms.Label
        Me.lblDebitTotalPro = New System.Windows.Forms.Label
        Me.lblDebitSoldePro = New System.Windows.Forms.Label
        Me.lblDebitTotalGen = New System.Windows.Forms.Label
        Me.lblDebitSoldeGen = New System.Windows.Forms.Label
        Me.lblCreditTotalPro = New System.Windows.Forms.Label
        Me.lblCreditSoldePro = New System.Windows.Forms.Label
        Me.lblCreditTotalGen = New System.Windows.Forms.Label
        Me.lblCreditSoldeGen = New System.Windows.Forms.Label
        Me.lbRepD = New System.Windows.Forms.Label
        Me.lbRepC = New System.Windows.Forms.Label
        Me.ActivitesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
        Me.PlanComptableTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
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
        Me.LignesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
        Me.PiecesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
        Me.PanFooter = New Ascend.Windows.Forms.GradientPanel
        Me.TlpTotauxUnit = New System.Windows.Forms.TableLayoutPanel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblQuantite1TotalPro = New System.Windows.Forms.Label
        Me.lblQuantite1TotalGen = New System.Windows.Forms.Label
        Me.lblQuantite2TotalPro = New System.Windows.Forms.Label
        Me.lblQuantite2TotalGen = New System.Windows.Forms.Label
        Me.lbRepU1 = New System.Windows.Forms.Label
        Me.lbRepU2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblQuantite1UnitSoldePro = New System.Windows.Forms.Label
        Me.lblQuantite1UnitSoldeGen = New System.Windows.Forms.Label
        Me.lblQuantite2UnitSoldePro = New System.Windows.Forms.Label
        Me.lblQuantite2UnitSoldeGen = New System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.dgvDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalPiece = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvPiece = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvActiv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibellePiece = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvDebit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvCredit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvQuantite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvQuantite1U = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvQuantite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvQuantite2U = New System.Windows.Forms.DataGridViewTextBoxColumn
        CompteDisplayLabel = New System.Windows.Forms.Label
        ActDisplayLabel = New System.Windows.Forms.Label
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanActiviteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MouvementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMouvements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSOptionLigne.SuspendLayout()
        Me.tlpLettrage.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.TLPTotaux.SuspendLayout()
        Me.PanFooter.SuspendLayout()
        Me.TlpTotauxUnit.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CompteDisplayLabel
        '
        CompteDisplayLabel.AutoSize = True
        CompteDisplayLabel.Location = New System.Drawing.Point(8, 14)
        CompteDisplayLabel.Name = "CompteDisplayLabel"
        CompteDisplayLabel.Size = New System.Drawing.Size(49, 13)
        CompteDisplayLabel.TabIndex = 0
        CompteDisplayLabel.Text = "Compte :"
        '
        'ActDisplayLabel
        '
        ActDisplayLabel.AutoSize = True
        ActDisplayLabel.Location = New System.Drawing.Point(8, 38)
        ActDisplayLabel.Name = "ActDisplayLabel"
        ActDisplayLabel.Size = New System.Drawing.Size(48, 13)
        ActDisplayLabel.TabIndex = 2
        ActDisplayLabel.Text = "Activité :"
        '
        'DbDonneesDataSet
        '
        Me.DbDonneesDataSet.DataSetName = "dbDonneesDataSet"
        Me.DbDonneesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCompteDisplay
        '
        Me.cboCompteDisplay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCompteDisplay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompteDisplay.DataSource = Me.CompteBindingSource
        Me.cboCompteDisplay.DisplayMember = "CDisplay"
        Me.cboCompteDisplay.FormattingEnabled = True
        Me.cboCompteDisplay.Location = New System.Drawing.Point(63, 8)
        Me.cboCompteDisplay.Name = "cboCompteDisplay"
        Me.cboCompteDisplay.Size = New System.Drawing.Size(405, 21)
        Me.cboCompteDisplay.TabIndex = 1
        Me.cboCompteDisplay.ValueMember = "CCpt"
        '
        'CompteBindingSource
        '
        Me.CompteBindingSource.DataMember = "Comptes"
        Me.CompteBindingSource.DataSource = Me.DsPLC
        Me.CompteBindingSource.Sort = "CCpt"
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboActDisplay
        '
        Me.cboActDisplay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboActDisplay.DataSource = Me.PlanActiviteBindingSource
        Me.cboActDisplay.DisplayMember = "ADisplay"
        Me.cboActDisplay.Enabled = False
        Me.cboActDisplay.FormattingEnabled = True
        Me.cboActDisplay.Location = New System.Drawing.Point(63, 35)
        Me.cboActDisplay.Name = "cboActDisplay"
        Me.cboActDisplay.Size = New System.Drawing.Size(208, 21)
        Me.cboActDisplay.TabIndex = 3
        Me.cboActDisplay.ValueMember = "PlActi"
        '
        'PlanActiviteBindingSource
        '
        Me.PlanActiviteBindingSource.DataMember = "ComptesPlanComptable"
        Me.PlanActiviteBindingSource.DataSource = Me.CompteBindingSource
        Me.PlanActiviteBindingSource.Sort = "PlCpt,PlActi"
        '
        'MouvementsBindingSource
        '
        Me.MouvementsBindingSource.DataMember = "Mouvements"
        Me.MouvementsBindingSource.DataSource = Me.DbDonneesDataSet
        Me.MouvementsBindingSource.Sort = "MDate"
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'dgvMouvements
        '
        Me.dgvMouvements.AllowUserToAddRows = False
        Me.dgvMouvements.AllowUserToDeleteRows = False
        Me.dgvMouvements.AllowUserToResizeColumns = False
        Me.dgvMouvements.AllowUserToResizeRows = False
        Me.dgvMouvements.AutoGenerateColumns = False
        Me.dgvMouvements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMouvements.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMouvements.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMouvements.ColumnHeadersHeight = 35
        Me.dgvMouvements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDate, Me.JournalPiece, Me.dgvPiece, Me.dgvActiv, Me.LibellePiece, Me.dgvLib, Me.dgvDebit, Me.dgvCredit, Me.dgvQuantite1, Me.dgvQuantite1U, Me.dgvQuantite2, Me.dgvQuantite2U})
        Me.dgvMouvements.ContextMenuStrip = Me.CMSOptionLigne
        Me.dgvMouvements.DataSource = Me.MouvementsBindingSource
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMouvements.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvMouvements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMouvements.GridColor = System.Drawing.Color.LimeGreen
        Me.dgvMouvements.Location = New System.Drawing.Point(0, 94)
        Me.dgvMouvements.Name = "dgvMouvements"
        Me.dgvMouvements.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMouvements.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvMouvements.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvMouvements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMouvements.Size = New System.Drawing.Size(772, 307)
        Me.dgvMouvements.TabIndex = 0
        '
        'CMSOptionLigne
        '
        Me.CMSOptionLigne.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LettrerToolStripMenuItem, Me.DélettrerToolStripMenuItem, Me.ToolStripSeparator1, Me.cmsVisualiserPiece, Me.ToolStripSeparator2, Me.cmsModifPiece, Me.cmsSupprPiece})
        Me.CMSOptionLigne.Name = "CMSOptionLigne"
        Me.CMSOptionLigne.Size = New System.Drawing.Size(188, 126)
        '
        'LettrerToolStripMenuItem
        '
        Me.LettrerToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.Flag_redHS
        Me.LettrerToolStripMenuItem.Name = "LettrerToolStripMenuItem"
        Me.LettrerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LettrerToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.LettrerToolStripMenuItem.Text = "Lettrer"
        '
        'DélettrerToolStripMenuItem
        '
        Me.DélettrerToolStripMenuItem.Name = "DélettrerToolStripMenuItem"
        Me.DélettrerToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.DélettrerToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.DélettrerToolStripMenuItem.Text = "Délettrer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'cmsVisualiserPiece
        '
        Me.cmsVisualiserPiece.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.cmsVisualiserPiece.Name = "cmsVisualiserPiece"
        Me.cmsVisualiserPiece.Size = New System.Drawing.Size(187, 22)
        Me.cmsVisualiserPiece.Text = "Visualiser la pièce..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(184, 6)
        '
        'cmsModifPiece
        '
        Me.cmsModifPiece.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.cmsModifPiece.Name = "cmsModifPiece"
        Me.cmsModifPiece.Size = New System.Drawing.Size(187, 22)
        Me.cmsModifPiece.Text = "Modifier la pièce..."
        '
        'cmsSupprPiece
        '
        Me.cmsSupprPiece.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.cmsSupprPiece.Name = "cmsSupprPiece"
        Me.cmsSupprPiece.Size = New System.Drawing.Size(187, 22)
        Me.cmsSupprPiece.Text = "Supprimer la pièce"
        '
        'ActionsDdb
        '
        Me.ActionsDdb.Image = Global.AgrigestEDI.My.Resources.Resources.outils
        Me.ActionsDdb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ActionsDdb.Name = "ActionsDdb"
        Me.ActionsDdb.Size = New System.Drawing.Size(81, 22)
        Me.ActionsDdb.Text = "Ecritures"
        '
        'chkFull
        '
        Me.chkFull.AutoSize = True
        Me.chkFull.Checked = True
        Me.chkFull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFull.Enabled = False
        Me.chkFull.Location = New System.Drawing.Point(277, 37)
        Me.chkFull.Name = "chkFull"
        Me.chkFull.Size = New System.Drawing.Size(117, 17)
        Me.chkFull.TabIndex = 8
        Me.chkFull.Text = "Toutes les activités"
        Me.chkFull.UseVisualStyleBackColor = True
        '
        'lblDateEnd
        '
        Me.lblDateEnd.AutoSize = True
        Me.lblDateEnd.Location = New System.Drawing.Point(569, 38)
        Me.lblDateEnd.Name = "lblDateEnd"
        Me.lblDateEnd.Size = New System.Drawing.Size(19, 13)
        Me.lblDateEnd.TabIndex = 6
        Me.lblDateEnd.Text = "au"
        '
        'lblDateStart
        '
        Me.lblDateStart.AutoSize = True
        Me.lblDateStart.Location = New System.Drawing.Point(406, 38)
        Me.lblDateStart.Name = "lblDateStart"
        Me.lblDateStart.Size = New System.Drawing.Size(61, 13)
        Me.lblDateStart.TabIndex = 4
        Me.lblDateStart.Text = "Période du "
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEnd.Location = New System.Drawing.Point(594, 34)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(90, 20)
        Me.dtpDateEnd.TabIndex = 7
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(473, 34)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(90, 20)
        Me.dtpDateStart.TabIndex = 5
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Fermer"
        '
        'pgBar
        '
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(100, 22)
        '
        'lbStatut
        '
        Me.lbStatut.Name = "lbStatut"
        Me.lbStatut.Size = New System.Drawing.Size(48, 22)
        Me.lbStatut.Text = "lbStatut"
        '
        'TbFiltrerLettrage
        '
        Me.TbFiltrerLettrage.Checked = True
        Me.TbFiltrerLettrage.CheckOnClick = True
        Me.TbFiltrerLettrage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFiltrerLettrage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFiltrerLettrage.Image = Global.AgrigestEDI.My.Resources.Resources.filter
        Me.TbFiltrerLettrage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFiltrerLettrage.Name = "TbFiltrerLettrage"
        Me.TbFiltrerLettrage.Size = New System.Drawing.Size(23, 22)
        Me.TbFiltrerLettrage.Text = "Masquer les écritures lettrées."
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechercheCompteToolStripMenuItem, Me.ImprimerLeCompteToolStripMenuItem, Me.LettrageAutomatiqueToolStripMenuItem1, Me.NafficherQueLesComptesMouvementésToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripDropDownButton1.Text = "Comptes"
        '
        'RechercheCompteToolStripMenuItem
        '
        Me.RechercheCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.find
        Me.RechercheCompteToolStripMenuItem.Name = "RechercheCompteToolStripMenuItem"
        Me.RechercheCompteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.RechercheCompteToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.RechercheCompteToolStripMenuItem.Text = "Recherche compte..."
        '
        'ImprimerLeCompteToolStripMenuItem
        '
        Me.ImprimerLeCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.impr
        Me.ImprimerLeCompteToolStripMenuItem.Name = "ImprimerLeCompteToolStripMenuItem"
        Me.ImprimerLeCompteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimerLeCompteToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ImprimerLeCompteToolStripMenuItem.Text = "Imprimer le compte..."
        '
        'LettrageAutomatiqueToolStripMenuItem1
        '
        Me.LettrageAutomatiqueToolStripMenuItem1.Image = Global.AgrigestEDI.My.Resources.Resources.Flag_redHS
        Me.LettrageAutomatiqueToolStripMenuItem1.Name = "LettrageAutomatiqueToolStripMenuItem1"
        Me.LettrageAutomatiqueToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.LettrageAutomatiqueToolStripMenuItem1.Size = New System.Drawing.Size(258, 22)
        Me.LettrageAutomatiqueToolStripMenuItem1.Text = "Lettrage automatique..."
        '
        'NafficherQueLesComptesMouvementésToolStripMenuItem
        '
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Checked = True
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.CheckOnClick = True
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.filter
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Name = "NafficherQueLesComptesMouvementésToolStripMenuItem"
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Text = "Seulement comptes mouvementés"
        '
        'tlpLettrage
        '
        Me.tlpLettrage.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tlpLettrage.ColumnCount = 2
        Me.tlpLettrage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLettrage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLettrage.Controls.Add(Me.Label2, 0, 0)
        Me.tlpLettrage.Controls.Add(Me.Label3, 1, 0)
        Me.tlpLettrage.Controls.Add(Me.lbLettreMtD, 0, 1)
        Me.tlpLettrage.Controls.Add(Me.lbLettreSoldeD, 0, 2)
        Me.tlpLettrage.Controls.Add(Me.lbLettreMtC, 1, 1)
        Me.tlpLettrage.Controls.Add(Me.lbLettreSoldeC, 1, 2)
        Me.tlpLettrage.Location = New System.Drawing.Point(8, 8)
        Me.tlpLettrage.Name = "tlpLettrage"
        Me.tlpLettrage.RowCount = 3
        Me.tlpLettrage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpLettrage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpLettrage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpLettrage.Size = New System.Drawing.Size(173, 54)
        Me.tlpLettrage.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Débit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(90, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Crédit"
        '
        'lbLettreMtD
        '
        Me.lbLettreMtD.AutoSize = True
        Me.lbLettreMtD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLettreMtD.Location = New System.Drawing.Point(5, 19)
        Me.lbLettreMtD.Name = "lbLettreMtD"
        Me.lbLettreMtD.Size = New System.Drawing.Size(77, 15)
        Me.lbLettreMtD.TabIndex = 2
        Me.lbLettreMtD.Text = "0 000 000,00 €"
        Me.lbLettreMtD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbLettreSoldeD
        '
        Me.lbLettreSoldeD.AutoSize = True
        Me.lbLettreSoldeD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLettreSoldeD.Location = New System.Drawing.Point(5, 36)
        Me.lbLettreSoldeD.Name = "lbLettreSoldeD"
        Me.lbLettreSoldeD.Size = New System.Drawing.Size(77, 16)
        Me.lbLettreSoldeD.TabIndex = 3
        Me.lbLettreSoldeD.Text = "0 000 000,00 €"
        Me.lbLettreSoldeD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbLettreMtC
        '
        Me.lbLettreMtC.AutoSize = True
        Me.lbLettreMtC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLettreMtC.Location = New System.Drawing.Point(90, 19)
        Me.lbLettreMtC.Name = "lbLettreMtC"
        Me.lbLettreMtC.Size = New System.Drawing.Size(78, 15)
        Me.lbLettreMtC.TabIndex = 4
        Me.lbLettreMtC.Text = "0 000 000,00 €"
        Me.lbLettreMtC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbLettreSoldeC
        '
        Me.lbLettreSoldeC.AutoSize = True
        Me.lbLettreSoldeC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLettreSoldeC.Location = New System.Drawing.Point(90, 36)
        Me.lbLettreSoldeC.Name = "lbLettreSoldeC"
        Me.lbLettreSoldeC.Size = New System.Drawing.Size(78, 16)
        Me.lbLettreSoldeC.TabIndex = 5
        Me.lbLettreSoldeC.Text = "0 000 000,00 €"
        Me.lbLettreSoldeC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.AutoSize = False
        Me.BindingNavigator1.BindingSource = Me.CompteBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.ToolStripLabel1, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.TbFiltrerLettrage, Me.ToolStripDropDownButton1, Me.ActionsDdb, Me.pgBar, Me.lbStatut})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripLabel1
        Me.BindingNavigator1.Size = New System.Drawing.Size(772, 25)
        Me.BindingNavigator1.TabIndex = 1
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel1.Text = "0"
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
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TLPTotaux
        '
        Me.TLPTotaux.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TLPTotaux.ColumnCount = 4
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TLPTotaux.Controls.Add(Me.Label5, 2, 0)
        Me.TLPTotaux.Controls.Add(Me.Label4, 1, 0)
        Me.TLPTotaux.Controls.Add(Me.Label1, 0, 1)
        Me.TLPTotaux.Controls.Add(Me.lblLabelTotalPro, 0, 2)
        Me.TLPTotaux.Controls.Add(Me.lblLabelSoldePro, 0, 3)
        Me.TLPTotaux.Controls.Add(Me.lblLabelTotalGen, 0, 4)
        Me.TLPTotaux.Controls.Add(Me.lblLabelSoldeGen, 0, 5)
        Me.TLPTotaux.Controls.Add(Me.lblDebitTotalPro, 1, 2)
        Me.TLPTotaux.Controls.Add(Me.lblDebitSoldePro, 1, 3)
        Me.TLPTotaux.Controls.Add(Me.lblDebitTotalGen, 1, 4)
        Me.TLPTotaux.Controls.Add(Me.lblDebitSoldeGen, 1, 5)
        Me.TLPTotaux.Controls.Add(Me.lblCreditTotalPro, 2, 2)
        Me.TLPTotaux.Controls.Add(Me.lblCreditSoldePro, 2, 3)
        Me.TLPTotaux.Controls.Add(Me.lblCreditTotalGen, 2, 4)
        Me.TLPTotaux.Controls.Add(Me.lblCreditSoldeGen, 2, 5)
        Me.TLPTotaux.Controls.Add(Me.lbRepD, 1, 1)
        Me.TLPTotaux.Controls.Add(Me.lbRepC, 2, 1)
        Me.TLPTotaux.Location = New System.Drawing.Point(187, 8)
        Me.TLPTotaux.Name = "TLPTotaux"
        Me.TLPTotaux.RowCount = 6
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.Size = New System.Drawing.Size(268, 106)
        Me.TLPTotaux.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(179, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Crédit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(87, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Débit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Reports"
        '
        'lblLabelTotalPro
        '
        Me.lblLabelTotalPro.AutoSize = True
        Me.lblLabelTotalPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLabelTotalPro.Location = New System.Drawing.Point(5, 36)
        Me.lblLabelTotalPro.Name = "lblLabelTotalPro"
        Me.lblLabelTotalPro.Size = New System.Drawing.Size(74, 15)
        Me.lblLabelTotalPro.TabIndex = 0
        Me.lblLabelTotalPro.Text = "Total progr."
        '
        'lblLabelSoldePro
        '
        Me.lblLabelSoldePro.AutoSize = True
        Me.lblLabelSoldePro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLabelSoldePro.Location = New System.Drawing.Point(5, 53)
        Me.lblLabelSoldePro.Name = "lblLabelSoldePro"
        Me.lblLabelSoldePro.Size = New System.Drawing.Size(74, 15)
        Me.lblLabelSoldePro.TabIndex = 4
        Me.lblLabelSoldePro.Text = "Solde progr."
        '
        'lblLabelTotalGen
        '
        Me.lblLabelTotalGen.AutoSize = True
        Me.lblLabelTotalGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLabelTotalGen.Location = New System.Drawing.Point(5, 70)
        Me.lblLabelTotalGen.Name = "lblLabelTotalGen"
        Me.lblLabelTotalGen.Size = New System.Drawing.Size(74, 15)
        Me.lblLabelTotalGen.TabIndex = 7
        Me.lblLabelTotalGen.Text = "Total général"
        '
        'lblLabelSoldeGen
        '
        Me.lblLabelSoldeGen.AutoSize = True
        Me.lblLabelSoldeGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLabelSoldeGen.Location = New System.Drawing.Point(5, 87)
        Me.lblLabelSoldeGen.Name = "lblLabelSoldeGen"
        Me.lblLabelSoldeGen.Size = New System.Drawing.Size(74, 17)
        Me.lblLabelSoldeGen.TabIndex = 11
        Me.lblLabelSoldeGen.Text = "Solde général"
        '
        'lblDebitTotalPro
        '
        Me.lblDebitTotalPro.AutoSize = True
        Me.lblDebitTotalPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDebitTotalPro.Location = New System.Drawing.Point(87, 36)
        Me.lblDebitTotalPro.Name = "lblDebitTotalPro"
        Me.lblDebitTotalPro.Size = New System.Drawing.Size(84, 15)
        Me.lblDebitTotalPro.TabIndex = 1
        Me.lblDebitTotalPro.Text = "0 000 000,00 €"
        Me.lblDebitTotalPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebitSoldePro
        '
        Me.lblDebitSoldePro.AutoSize = True
        Me.lblDebitSoldePro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDebitSoldePro.Location = New System.Drawing.Point(87, 53)
        Me.lblDebitSoldePro.Name = "lblDebitSoldePro"
        Me.lblDebitSoldePro.Size = New System.Drawing.Size(84, 15)
        Me.lblDebitSoldePro.TabIndex = 5
        Me.lblDebitSoldePro.Text = "0 000 000,00 €"
        Me.lblDebitSoldePro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebitTotalGen
        '
        Me.lblDebitTotalGen.AutoSize = True
        Me.lblDebitTotalGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDebitTotalGen.Location = New System.Drawing.Point(87, 70)
        Me.lblDebitTotalGen.Name = "lblDebitTotalGen"
        Me.lblDebitTotalGen.Size = New System.Drawing.Size(84, 15)
        Me.lblDebitTotalGen.TabIndex = 8
        Me.lblDebitTotalGen.Text = "0 000 000,00 €"
        Me.lblDebitTotalGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebitSoldeGen
        '
        Me.lblDebitSoldeGen.AutoSize = True
        Me.lblDebitSoldeGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDebitSoldeGen.Location = New System.Drawing.Point(87, 87)
        Me.lblDebitSoldeGen.Name = "lblDebitSoldeGen"
        Me.lblDebitSoldeGen.Size = New System.Drawing.Size(84, 17)
        Me.lblDebitSoldeGen.TabIndex = 12
        Me.lblDebitSoldeGen.Text = "0 000 000,00 €"
        Me.lblDebitSoldeGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditTotalPro
        '
        Me.lblCreditTotalPro.AutoSize = True
        Me.lblCreditTotalPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCreditTotalPro.Location = New System.Drawing.Point(179, 36)
        Me.lblCreditTotalPro.Name = "lblCreditTotalPro"
        Me.lblCreditTotalPro.Size = New System.Drawing.Size(84, 15)
        Me.lblCreditTotalPro.TabIndex = 2
        Me.lblCreditTotalPro.Text = "0 000 000,00 €"
        Me.lblCreditTotalPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditSoldePro
        '
        Me.lblCreditSoldePro.AutoSize = True
        Me.lblCreditSoldePro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCreditSoldePro.Location = New System.Drawing.Point(179, 53)
        Me.lblCreditSoldePro.Name = "lblCreditSoldePro"
        Me.lblCreditSoldePro.Size = New System.Drawing.Size(84, 15)
        Me.lblCreditSoldePro.TabIndex = 6
        Me.lblCreditSoldePro.Text = "0 000 000,00 €"
        Me.lblCreditSoldePro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditTotalGen
        '
        Me.lblCreditTotalGen.AutoSize = True
        Me.lblCreditTotalGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCreditTotalGen.Location = New System.Drawing.Point(179, 70)
        Me.lblCreditTotalGen.Name = "lblCreditTotalGen"
        Me.lblCreditTotalGen.Size = New System.Drawing.Size(84, 15)
        Me.lblCreditTotalGen.TabIndex = 9
        Me.lblCreditTotalGen.Text = "0 000 000,00 €"
        Me.lblCreditTotalGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditSoldeGen
        '
        Me.lblCreditSoldeGen.AutoSize = True
        Me.lblCreditSoldeGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCreditSoldeGen.Location = New System.Drawing.Point(179, 87)
        Me.lblCreditSoldeGen.Name = "lblCreditSoldeGen"
        Me.lblCreditSoldeGen.Size = New System.Drawing.Size(84, 17)
        Me.lblCreditSoldeGen.TabIndex = 13
        Me.lblCreditSoldeGen.Text = "0 000 000,00 €"
        Me.lblCreditSoldeGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbRepD
        '
        Me.lbRepD.AutoSize = True
        Me.lbRepD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRepD.Location = New System.Drawing.Point(87, 19)
        Me.lbRepD.Name = "lbRepD"
        Me.lbRepD.Size = New System.Drawing.Size(84, 15)
        Me.lbRepD.TabIndex = 29
        Me.lbRepD.Text = "0 000 000,00 €"
        Me.lbRepD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbRepC
        '
        Me.lbRepC.AutoSize = True
        Me.lbRepC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRepC.Location = New System.Drawing.Point(179, 19)
        Me.lbRepC.Name = "lbRepC"
        Me.lbRepC.Size = New System.Drawing.Size(84, 15)
        Me.lbRepC.TabIndex = 30
        Me.lbRepC.Text = "0 000 000,00 €"
        Me.lbRepC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "MDate"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "MPiece"
        Me.DataGridViewTextBoxColumn2.HeaderText = "N° Pièce"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "MActi"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Activité"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LibellePiece"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Libellé de la ligne"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "MMtDeb"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn5.HeaderText = "Montant Débit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "MMtCre"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn6.HeaderText = "Montant Crédit"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "MQte1"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "# ##0.000;-# ##0.000;"""""
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn7.HeaderText = "Quantité 1"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "# ##0.000;-# ##0.000;"""""
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn8.HeaderText = "Quantité 1 unité"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "MQte2"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "# ##0.000;-# ##0.000;"""""
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn9.HeaderText = "Quantité 2"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "# ##0.000;-# ##0.000;"""""
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité 2 unité"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
        '
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'PanFooter
        '
        Me.PanFooter.Controls.Add(Me.TlpTotauxUnit)
        Me.PanFooter.Controls.Add(Me.TLPTotaux)
        Me.PanFooter.Controls.Add(Me.tlpLettrage)
        Me.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanFooter.GradientHighColor = System.Drawing.Color.White
        Me.PanFooter.GradientLowColor = System.Drawing.Color.Lavender
        Me.PanFooter.Location = New System.Drawing.Point(0, 401)
        Me.PanFooter.Name = "PanFooter"
        Me.PanFooter.Padding = New System.Windows.Forms.Padding(5)
        Me.PanFooter.Size = New System.Drawing.Size(772, 122)
        Me.PanFooter.TabIndex = 33
        '
        'TlpTotauxUnit
        '
        Me.TlpTotauxUnit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TlpTotauxUnit.ColumnCount = 3
        Me.TlpTotauxUnit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TlpTotauxUnit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TlpTotauxUnit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TlpTotauxUnit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TlpTotauxUnit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TlpTotauxUnit.Controls.Add(Me.Label7, 2, 0)
        Me.TlpTotauxUnit.Controls.Add(Me.Label8, 0, 1)
        Me.TlpTotauxUnit.Controls.Add(Me.Label9, 0, 2)
        Me.TlpTotauxUnit.Controls.Add(Me.Label10, 0, 3)
        Me.TlpTotauxUnit.Controls.Add(Me.Label11, 0, 4)
        Me.TlpTotauxUnit.Controls.Add(Me.Label12, 0, 5)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite1TotalPro, 1, 2)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite1TotalGen, 1, 4)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite2TotalPro, 2, 2)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite2TotalGen, 2, 4)
        Me.TlpTotauxUnit.Controls.Add(Me.lbRepU1, 1, 1)
        Me.TlpTotauxUnit.Controls.Add(Me.lbRepU2, 2, 1)
        Me.TlpTotauxUnit.Controls.Add(Me.Label6, 1, 0)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite1UnitSoldePro, 1, 3)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite1UnitSoldeGen, 1, 5)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite2UnitSoldePro, 2, 3)
        Me.TlpTotauxUnit.Controls.Add(Me.lblQuantite2UnitSoldeGen, 2, 5)
        Me.TlpTotauxUnit.Location = New System.Drawing.Point(461, 8)
        Me.TlpTotauxUnit.Name = "TlpTotauxUnit"
        Me.TlpTotauxUnit.RowCount = 6
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TlpTotauxUnit.Size = New System.Drawing.Size(285, 106)
        Me.TlpTotauxUnit.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(192, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Quantité 2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(5, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Reports"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(5, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total progr."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(5, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Prix U. progr."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(5, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Total général"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(5, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Prix U. général"
        '
        'lblQuantite1TotalPro
        '
        Me.lblQuantite1TotalPro.AutoSize = True
        Me.lblQuantite1TotalPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite1TotalPro.Location = New System.Drawing.Point(100, 36)
        Me.lblQuantite1TotalPro.Name = "lblQuantite1TotalPro"
        Me.lblQuantite1TotalPro.Size = New System.Drawing.Size(84, 15)
        Me.lblQuantite1TotalPro.TabIndex = 3
        Me.lblQuantite1TotalPro.Text = "0 000 000,00 €"
        Me.lblQuantite1TotalPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite1TotalGen
        '
        Me.lblQuantite1TotalGen.AutoSize = True
        Me.lblQuantite1TotalGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite1TotalGen.Location = New System.Drawing.Point(100, 70)
        Me.lblQuantite1TotalGen.Name = "lblQuantite1TotalGen"
        Me.lblQuantite1TotalGen.Size = New System.Drawing.Size(84, 15)
        Me.lblQuantite1TotalGen.TabIndex = 10
        Me.lblQuantite1TotalGen.Text = "0 000 000,00 €"
        Me.lblQuantite1TotalGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite2TotalPro
        '
        Me.lblQuantite2TotalPro.AutoSize = True
        Me.lblQuantite2TotalPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite2TotalPro.Location = New System.Drawing.Point(192, 36)
        Me.lblQuantite2TotalPro.Name = "lblQuantite2TotalPro"
        Me.lblQuantite2TotalPro.Size = New System.Drawing.Size(98, 15)
        Me.lblQuantite2TotalPro.TabIndex = 20
        Me.lblQuantite2TotalPro.Text = "0 000 000,00 €"
        Me.lblQuantite2TotalPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite2TotalGen
        '
        Me.lblQuantite2TotalGen.AutoSize = True
        Me.lblQuantite2TotalGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite2TotalGen.Location = New System.Drawing.Point(192, 70)
        Me.lblQuantite2TotalGen.Name = "lblQuantite2TotalGen"
        Me.lblQuantite2TotalGen.Size = New System.Drawing.Size(98, 15)
        Me.lblQuantite2TotalGen.TabIndex = 22
        Me.lblQuantite2TotalGen.Text = "0 000 000,00 €"
        Me.lblQuantite2TotalGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbRepU1
        '
        Me.lbRepU1.AutoSize = True
        Me.lbRepU1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRepU1.Location = New System.Drawing.Point(100, 19)
        Me.lbRepU1.Name = "lbRepU1"
        Me.lbRepU1.Size = New System.Drawing.Size(84, 15)
        Me.lbRepU1.TabIndex = 0
        Me.lbRepU1.Text = "0 000 000,00 €"
        Me.lbRepU1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbRepU2
        '
        Me.lbRepU2.AutoSize = True
        Me.lbRepU2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRepU2.Location = New System.Drawing.Point(192, 19)
        Me.lbRepU2.Name = "lbRepU2"
        Me.lbRepU2.Size = New System.Drawing.Size(98, 15)
        Me.lbRepU2.TabIndex = 32
        Me.lbRepU2.Text = "0 000 000,00 €"
        Me.lbRepU2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(100, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Quantité 1"
        '
        'lblQuantite1UnitSoldePro
        '
        Me.lblQuantite1UnitSoldePro.AutoSize = True
        Me.lblQuantite1UnitSoldePro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite1UnitSoldePro.Location = New System.Drawing.Point(100, 53)
        Me.lblQuantite1UnitSoldePro.Name = "lblQuantite1UnitSoldePro"
        Me.lblQuantite1UnitSoldePro.Size = New System.Drawing.Size(84, 15)
        Me.lblQuantite1UnitSoldePro.TabIndex = 17
        Me.lblQuantite1UnitSoldePro.Text = "0 000 000,00 €"
        Me.lblQuantite1UnitSoldePro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite1UnitSoldeGen
        '
        Me.lblQuantite1UnitSoldeGen.AutoSize = True
        Me.lblQuantite1UnitSoldeGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite1UnitSoldeGen.Location = New System.Drawing.Point(100, 87)
        Me.lblQuantite1UnitSoldeGen.Name = "lblQuantite1UnitSoldeGen"
        Me.lblQuantite1UnitSoldeGen.Size = New System.Drawing.Size(84, 17)
        Me.lblQuantite1UnitSoldeGen.TabIndex = 14
        Me.lblQuantite1UnitSoldeGen.Text = "0 000 000,00 €"
        Me.lblQuantite1UnitSoldeGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite2UnitSoldePro
        '
        Me.lblQuantite2UnitSoldePro.AutoSize = True
        Me.lblQuantite2UnitSoldePro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite2UnitSoldePro.Location = New System.Drawing.Point(192, 53)
        Me.lblQuantite2UnitSoldePro.Name = "lblQuantite2UnitSoldePro"
        Me.lblQuantite2UnitSoldePro.Size = New System.Drawing.Size(98, 15)
        Me.lblQuantite2UnitSoldePro.TabIndex = 25
        Me.lblQuantite2UnitSoldePro.Text = "0 000 000,00 €"
        Me.lblQuantite2UnitSoldePro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantite2UnitSoldeGen
        '
        Me.lblQuantite2UnitSoldeGen.AutoSize = True
        Me.lblQuantite2UnitSoldeGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantite2UnitSoldeGen.Location = New System.Drawing.Point(192, 87)
        Me.lblQuantite2UnitSoldeGen.Name = "lblQuantite2UnitSoldeGen"
        Me.lblQuantite2UnitSoldeGen.Size = New System.Drawing.Size(98, 17)
        Me.lblQuantite2UnitSoldeGen.TabIndex = 27
        Me.lblQuantite2UnitSoldeGen.Text = "0 000 000,00 €"
        Me.lblQuantite2UnitSoldeGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.chkFull)
        Me.GradientPanel1.Controls.Add(Me.cboActDisplay)
        Me.GradientPanel1.Controls.Add(Me.lblDateEnd)
        Me.GradientPanel1.Controls.Add(ActDisplayLabel)
        Me.GradientPanel1.Controls.Add(Me.lblDateStart)
        Me.GradientPanel1.Controls.Add(CompteDisplayLabel)
        Me.GradientPanel1.Controls.Add(Me.dtpDateEnd)
        Me.GradientPanel1.Controls.Add(Me.cboCompteDisplay)
        Me.GradientPanel1.Controls.Add(Me.dtpDateStart)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(772, 69)
        Me.GradientPanel1.TabIndex = 34
        '
        'dgvDate
        '
        Me.dgvDate.DataPropertyName = "MDate"
        Me.dgvDate.HeaderText = "Date"
        Me.dgvDate.Name = "dgvDate"
        Me.dgvDate.ReadOnly = True
        Me.dgvDate.Width = 80
        '
        'JournalPiece
        '
        Me.JournalPiece.DataPropertyName = "JournalPiece"
        Me.JournalPiece.HeaderText = "Journal"
        Me.JournalPiece.Name = "JournalPiece"
        Me.JournalPiece.ReadOnly = True
        Me.JournalPiece.Width = 45
        '
        'dgvPiece
        '
        Me.dgvPiece.DataPropertyName = "MPiece"
        Me.dgvPiece.HeaderText = "N° Pièce"
        Me.dgvPiece.Name = "dgvPiece"
        Me.dgvPiece.ReadOnly = True
        Me.dgvPiece.Width = 80
        '
        'dgvActiv
        '
        Me.dgvActiv.DataPropertyName = "MActi"
        Me.dgvActiv.HeaderText = "Activité"
        Me.dgvActiv.Name = "dgvActiv"
        Me.dgvActiv.ReadOnly = True
        Me.dgvActiv.Width = 50
        '
        'LibellePiece
        '
        Me.LibellePiece.DataPropertyName = "LibellePiece"
        Me.LibellePiece.HeaderText = "Libellé de la pièce"
        Me.LibellePiece.Name = "LibellePiece"
        Me.LibellePiece.ReadOnly = True
        Me.LibellePiece.Width = 200
        '
        'dgvLib
        '
        Me.dgvLib.DataPropertyName = "LibelleLigne"
        Me.dgvLib.HeaderText = "Libellé de la ligne"
        Me.dgvLib.Name = "dgvLib"
        Me.dgvLib.ReadOnly = True
        Me.dgvLib.Width = 200
        '
        'dgvDebit
        '
        Me.dgvDebit.DataPropertyName = "MMtDeb"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDebit.HeaderText = "Montant Débit"
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.ReadOnly = True
        '
        'dgvCredit
        '
        Me.dgvCredit.DataPropertyName = "MMtCre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCredit.HeaderText = "Montant Crédit"
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = True
        '
        'dgvQuantite1
        '
        Me.dgvQuantite1.DataPropertyName = "MQte1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "# ##0.000;-# ##0.000;"""""
        Me.dgvQuantite1.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuantite1.HeaderText = "Quantité 1"
        Me.dgvQuantite1.Name = "dgvQuantite1"
        Me.dgvQuantite1.ReadOnly = True
        '
        'dgvQuantite1U
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "# ##0.000;-# ##0.000;"""""
        Me.dgvQuantite1U.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvQuantite1U.HeaderText = "Quantité 1 unité"
        Me.dgvQuantite1U.Name = "dgvQuantite1U"
        Me.dgvQuantite1U.ReadOnly = True
        Me.dgvQuantite1U.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvQuantite2
        '
        Me.dgvQuantite2.DataPropertyName = "MQte2"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "# ##0.000;-# ##0.000;"""""
        Me.dgvQuantite2.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvQuantite2.HeaderText = "Quantité 2"
        Me.dgvQuantite2.Name = "dgvQuantite2"
        Me.dgvQuantite2.ReadOnly = True
        '
        'dgvQuantite2U
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "# ##0.000;-# ##0.000;"""""
        Me.dgvQuantite2U.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvQuantite2U.HeaderText = "Quantité 2 unité"
        Me.dgvQuantite2U.Name = "dgvQuantite2U"
        Me.dgvQuantite2U.ReadOnly = True
        Me.dgvQuantite2U.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FrVisuCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 523)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvMouvements)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.PanFooter)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Name = "FrVisuCompte"
        Me.Text = "Consultation des comptes"
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanActiviteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MouvementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMouvements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSOptionLigne.ResumeLayout(False)
        Me.tlpLettrage.ResumeLayout(False)
        Me.tlpLettrage.PerformLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.TLPTotaux.ResumeLayout(False)
        Me.TLPTotaux.PerformLayout()
        Me.PanFooter.ResumeLayout(False)
        Me.TlpTotauxUnit.ResumeLayout(False)
        Me.TlpTotauxUnit.PerformLayout()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbDonneesDataSet As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents cboCompteDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents cboActDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents MouvementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
    Friend WithEvents dgvMouvements As System.Windows.Forms.DataGridView
    Friend WithEvents PlanActiviteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblDateEnd As System.Windows.Forms.Label
    Friend WithEvents lblDateStart As System.Windows.Forms.Label
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents TLPTotaux As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLabelTotalPro As System.Windows.Forms.Label
    Friend WithEvents lblLabelSoldePro As System.Windows.Forms.Label
    Friend WithEvents lblLabelTotalGen As System.Windows.Forms.Label
    Friend WithEvents lblLabelSoldeGen As System.Windows.Forms.Label
    Friend WithEvents lblDebitTotalPro As System.Windows.Forms.Label
    Friend WithEvents lblDebitSoldePro As System.Windows.Forms.Label
    Friend WithEvents lblDebitTotalGen As System.Windows.Forms.Label
    Friend WithEvents lblDebitSoldeGen As System.Windows.Forms.Label
    Friend WithEvents lblCreditTotalPro As System.Windows.Forms.Label
    Friend WithEvents lblCreditSoldePro As System.Windows.Forms.Label
    Friend WithEvents lblCreditTotalGen As System.Windows.Forms.Label
    Friend WithEvents lblCreditSoldeGen As System.Windows.Forms.Label
    Friend WithEvents CMSOptionLigne As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsModifPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSupprPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkFull As System.Windows.Forms.CheckBox
    Friend WithEvents pgBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lbStatut As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmsVisualiserPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbRepD As System.Windows.Forms.Label
    Friend WithEvents lbRepC As System.Windows.Forms.Label
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents LettrerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DélettrerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActionsDdb As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TbFiltrerLettrage As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlpLettrage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbLettreMtD As System.Windows.Forms.Label
    Friend WithEvents lbLettreSoldeD As System.Windows.Forms.Label
    Friend WithEvents lbLettreMtC As System.Windows.Forms.Label
    Friend WithEvents lbLettreSoldeC As System.Windows.Forms.Label
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents LettrageAutomatiqueToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechercheCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanFooter As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ImprimerLeCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TlpTotauxUnit As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblQuantite1TotalPro As System.Windows.Forms.Label
    Friend WithEvents lblQuantite1TotalGen As System.Windows.Forms.Label
    Friend WithEvents lblQuantite1UnitSoldePro As System.Windows.Forms.Label
    Friend WithEvents lblQuantite1UnitSoldeGen As System.Windows.Forms.Label
    Friend WithEvents lblQuantite2TotalPro As System.Windows.Forms.Label
    Friend WithEvents lblQuantite2TotalGen As System.Windows.Forms.Label
    Friend WithEvents lblQuantite2UnitSoldePro As System.Windows.Forms.Label
    Friend WithEvents lblQuantite2UnitSoldeGen As System.Windows.Forms.Label
    Friend WithEvents lbRepU1 As System.Windows.Forms.Label
    Friend WithEvents lbRepU2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NafficherQueLesComptesMouvementésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalPiece As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvPiece As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvActiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibellePiece As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvQuantite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvQuantite1U As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvQuantite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvQuantite2U As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
