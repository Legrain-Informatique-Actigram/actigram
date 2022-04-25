<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RappBancaire
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
        Dim CompteDisplayLabel As System.Windows.Forms.Label
        Dim ActDisplayLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RappBancaire))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.toolStripRappBancaire = New System.Windows.Forms.ToolStrip
        Me.toolStripButtonImprimerRappBancaire = New System.Windows.Forms.ToolStripButton
        Me.toolStripButtonQuitter = New System.Windows.Forms.ToolStripButton
        Me.toolStripButtonRecharger = New System.Windows.Forms.ToolStripButton
        Me.comboBoxCompte = New System.Windows.Forms.ComboBox
        Me.ComptesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.Label3 = New System.Windows.Forms.Label
        Me.GbInfosPointage = New System.Windows.Forms.GroupBox
        Me.labelCodePt = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.labelSoldePtEnCoursD = New System.Windows.Forms.Label
        Me.labelSoldeEcrPtD = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.labelSoldePtEnCoursC = New System.Windows.Forms.Label
        Me.labelSoldeEcrPtC = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dateTimePickerDatePt = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.buttonRechAv = New System.Windows.Forms.Button
        Me.dateTimePickerDateMaxEcr = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.radioButtonToutes = New System.Windows.Forms.RadioButton
        Me.radioButtonPt = New System.Windows.Forms.RadioButton
        Me.radioButtonNonPt = New System.Windows.Forms.RadioButton
        Me.buttonDept = New System.Windows.Forms.Button
        Me.buttonPt = New System.Windows.Forms.Button
        Me.comboBoxActivite = New System.Windows.Forms.ComboBox
        Me.PlanActivitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlanComptableTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
        Me.MouvementsTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
        Me.MouvementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbDonneesDataSet = New AgrigestEDI.dbDonneesDataSet
        Me.dataGridViewMvts = New System.Windows.Forms.DataGridView
        Me.MDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalPieceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPieceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleLigneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MMtDebDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MMtCreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPointage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MDatePointage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.contextMenuStripDataGridViewMvts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripMenuItemPointer = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripMenuItemDepointer = New System.Windows.Forms.ToolStripMenuItem
        Me.PiecesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
        Me.LignesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
        Me.TLPTotaux = New System.Windows.Forms.TableLayoutPanel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.labelSoldeMvtsD = New System.Windows.Forms.Label
        Me.labelTotalMvtsD = New System.Windows.Forms.Label
        Me.labelSoldeMvtsC = New System.Windows.Forms.Label
        Me.labelTotalMvtsC = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.labelSoldeCptD = New System.Windows.Forms.Label
        Me.labelSoldeCptC = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.labelLibelle = New System.Windows.Forms.Label
        Me.labelNumPiece = New System.Windows.Forms.Label
        Me.labelMt = New System.Windows.Forms.Label
        Me.labelDatePt = New System.Windows.Forms.Label
        Me.labelDateEcr = New System.Windows.Forms.Label
        Me.labelTypeEcr = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        CompteDisplayLabel = New System.Windows.Forms.Label
        ActDisplayLabel = New System.Windows.Forms.Label
        Me.toolStripRappBancaire.SuspendLayout()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbInfosPointage.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PlanActivitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MouvementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridViewMvts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenuStripDataGridViewMvts.SuspendLayout()
        Me.TLPTotaux.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CompteDisplayLabel
        '
        CompteDisplayLabel.AutoSize = True
        CompteDisplayLabel.Location = New System.Drawing.Point(9, 46)
        CompteDisplayLabel.Name = "CompteDisplayLabel"
        CompteDisplayLabel.Size = New System.Drawing.Size(49, 13)
        CompteDisplayLabel.TabIndex = 2
        CompteDisplayLabel.Text = "Compte :"
        '
        'ActDisplayLabel
        '
        ActDisplayLabel.AutoSize = True
        ActDisplayLabel.Location = New System.Drawing.Point(417, 46)
        ActDisplayLabel.Name = "ActDisplayLabel"
        ActDisplayLabel.Size = New System.Drawing.Size(48, 13)
        ActDisplayLabel.TabIndex = 20
        ActDisplayLabel.Text = "Activité :"
        '
        'toolStripRappBancaire
        '
        Me.toolStripRappBancaire.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonImprimerRappBancaire, Me.toolStripButtonQuitter, Me.toolStripButtonRecharger})
        Me.toolStripRappBancaire.Location = New System.Drawing.Point(0, 0)
        Me.toolStripRappBancaire.Name = "toolStripRappBancaire"
        Me.toolStripRappBancaire.Size = New System.Drawing.Size(989, 25)
        Me.toolStripRappBancaire.TabIndex = 0
        Me.toolStripRappBancaire.Text = "toolStripRappBancaire"
        '
        'toolStripButtonImprimerRappBancaire
        '
        Me.toolStripButtonImprimerRappBancaire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonImprimerRappBancaire.Image = CType(resources.GetObject("toolStripButtonImprimerRappBancaire.Image"), System.Drawing.Image)
        Me.toolStripButtonImprimerRappBancaire.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonImprimerRappBancaire.Name = "toolStripButtonImprimerRappBancaire"
        Me.toolStripButtonImprimerRappBancaire.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonImprimerRappBancaire.Text = "&Imprimer le rapprochement bancaire"
        '
        'toolStripButtonQuitter
        '
        Me.toolStripButtonQuitter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.toolStripButtonQuitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonQuitter.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.toolStripButtonQuitter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonQuitter.Name = "toolStripButtonQuitter"
        Me.toolStripButtonQuitter.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonQuitter.Text = "Fermer"
        '
        'toolStripButtonRecharger
        '
        Me.toolStripButtonRecharger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButtonRecharger.Image = Global.AgrigestEDI.My.Resources.Resources.RefreshDocViewHS
        Me.toolStripButtonRecharger.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButtonRecharger.Name = "toolStripButtonRecharger"
        Me.toolStripButtonRecharger.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButtonRecharger.Text = "Recharger"
        '
        'comboBoxCompte
        '
        Me.comboBoxCompte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboBoxCompte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboBoxCompte.DataSource = Me.ComptesBindingSource
        Me.comboBoxCompte.DisplayMember = "CDisplay"
        Me.comboBoxCompte.FormattingEnabled = True
        Me.comboBoxCompte.Location = New System.Drawing.Point(64, 43)
        Me.comboBoxCompte.Name = "comboBoxCompte"
        Me.comboBoxCompte.Size = New System.Drawing.Size(322, 21)
        Me.comboBoxCompte.TabIndex = 3
        Me.comboBoxCompte.ValueMember = "CCpt"
        '
        'ComptesBindingSource
        '
        Me.ComptesBindingSource.DataMember = "Comptes"
        Me.ComptesBindingSource.DataSource = Me.DsPLC
        Me.ComptesBindingSource.Sort = "CCpt"
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(707, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Solde :"
        '
        'GbInfosPointage
        '
        Me.GbInfosPointage.Controls.Add(Me.labelCodePt)
        Me.GbInfosPointage.Controls.Add(Me.TableLayoutPanel2)
        Me.GbInfosPointage.Controls.Add(Me.Label1)
        Me.GbInfosPointage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GbInfosPointage.Location = New System.Drawing.Point(18, 69)
        Me.GbInfosPointage.Name = "GbInfosPointage"
        Me.GbInfosPointage.Size = New System.Drawing.Size(414, 105)
        Me.GbInfosPointage.TabIndex = 11
        Me.GbInfosPointage.TabStop = False
        Me.GbInfosPointage.Text = "Informations pointage"
        '
        'labelCodePt
        '
        Me.labelCodePt.AutoSize = True
        Me.labelCodePt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelCodePt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelCodePt.Location = New System.Drawing.Point(105, 24)
        Me.labelCodePt.Name = "labelCodePt"
        Me.labelCodePt.Size = New System.Drawing.Size(27, 15)
        Me.labelCodePt.TabIndex = 30
        Me.labelCodePt.Text = "000"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.labelSoldePtEnCoursD, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.labelSoldeEcrPtD, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.labelSoldePtEnCoursC, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.labelSoldeEcrPtC, 2, 1)
        Me.TableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(20, 42)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(371, 53)
        Me.TableLayoutPanel2.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(5, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 15)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Solde pointage en cours"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(5, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Solde écritures pointées"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelSoldePtEnCoursD
        '
        Me.labelSoldePtEnCoursD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldePtEnCoursD.Location = New System.Drawing.Point(157, 36)
        Me.labelSoldePtEnCoursD.Name = "labelSoldePtEnCoursD"
        Me.labelSoldePtEnCoursD.Size = New System.Drawing.Size(89, 15)
        Me.labelSoldePtEnCoursD.TabIndex = 32
        Me.labelSoldePtEnCoursD.Text = "0 000 000,00 €"
        Me.labelSoldePtEnCoursD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelSoldeEcrPtD
        '
        Me.labelSoldeEcrPtD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldeEcrPtD.Location = New System.Drawing.Point(157, 19)
        Me.labelSoldeEcrPtD.Name = "labelSoldeEcrPtD"
        Me.labelSoldeEcrPtD.Size = New System.Drawing.Size(89, 15)
        Me.labelSoldeEcrPtD.TabIndex = 31
        Me.labelSoldeEcrPtD.Text = "0 000 000,00 €"
        Me.labelSoldeEcrPtD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(264, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 15)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Crédit"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(157, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Débit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelSoldePtEnCoursC
        '
        Me.labelSoldePtEnCoursC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldePtEnCoursC.Location = New System.Drawing.Point(264, 36)
        Me.labelSoldePtEnCoursC.Name = "labelSoldePtEnCoursC"
        Me.labelSoldePtEnCoursC.Size = New System.Drawing.Size(90, 15)
        Me.labelSoldePtEnCoursC.TabIndex = 31
        Me.labelSoldePtEnCoursC.Text = "0 000 000,00 €"
        Me.labelSoldePtEnCoursC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelSoldeEcrPtC
        '
        Me.labelSoldeEcrPtC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldeEcrPtC.Location = New System.Drawing.Point(264, 19)
        Me.labelSoldeEcrPtC.Name = "labelSoldeEcrPtC"
        Me.labelSoldeEcrPtC.Size = New System.Drawing.Size(90, 15)
        Me.labelSoldeEcrPtC.TabIndex = 30
        Me.labelSoldeEcrPtC.Text = "0 000 000,00 €"
        Me.labelSoldeEcrPtC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Code pointage :"
        '
        'dateTimePickerDatePt
        '
        Me.dateTimePickerDatePt.Checked = False
        Me.dateTimePickerDatePt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerDatePt.Location = New System.Drawing.Point(322, 56)
        Me.dateTimePickerDatePt.Name = "dateTimePickerDatePt"
        Me.dateTimePickerDatePt.ShowCheckBox = True
        Me.dateTimePickerDatePt.Size = New System.Drawing.Size(113, 20)
        Me.dateTimePickerDatePt.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(233, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Date pointage  :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.buttonRechAv)
        Me.GroupBox3.Controls.Add(Me.dateTimePickerDatePt)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.dateTimePickerDateMaxEcr)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.radioButtonToutes)
        Me.GroupBox3.Controls.Add(Me.radioButtonPt)
        Me.GroupBox3.Controls.Add(Me.radioButtonNonPt)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox3.Location = New System.Drawing.Point(477, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(488, 105)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtre"
        '
        'buttonRechAv
        '
        Me.buttonRechAv.Image = Global.AgrigestEDI.My.Resources.Resources.find
        Me.buttonRechAv.Location = New System.Drawing.Point(461, 82)
        Me.buttonRechAv.Name = "buttonRechAv"
        Me.buttonRechAv.Size = New System.Drawing.Size(27, 23)
        Me.buttonRechAv.TabIndex = 29
        Me.buttonRechAv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonRechAv.UseVisualStyleBackColor = True
        '
        'dateTimePickerDateMaxEcr
        '
        Me.dateTimePickerDateMaxEcr.Checked = False
        Me.dateTimePickerDateMaxEcr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerDateMaxEcr.Location = New System.Drawing.Point(87, 56)
        Me.dateTimePickerDateMaxEcr.Name = "dateTimePickerDateMaxEcr"
        Me.dateTimePickerDateMaxEcr.Size = New System.Drawing.Size(95, 20)
        Me.dateTimePickerDateMaxEcr.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(26, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Jusqu'au :"
        '
        'radioButtonToutes
        '
        Me.radioButtonToutes.AutoSize = True
        Me.radioButtonToutes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioButtonToutes.Location = New System.Drawing.Point(212, 28)
        Me.radioButtonToutes.Name = "radioButtonToutes"
        Me.radioButtonToutes.Size = New System.Drawing.Size(58, 17)
        Me.radioButtonToutes.TabIndex = 2
        Me.radioButtonToutes.TabStop = True
        Me.radioButtonToutes.Text = "Toutes"
        Me.radioButtonToutes.UseVisualStyleBackColor = True
        '
        'radioButtonPt
        '
        Me.radioButtonPt.AutoSize = True
        Me.radioButtonPt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioButtonPt.Location = New System.Drawing.Point(124, 28)
        Me.radioButtonPt.Name = "radioButtonPt"
        Me.radioButtonPt.Size = New System.Drawing.Size(66, 17)
        Me.radioButtonPt.TabIndex = 1
        Me.radioButtonPt.TabStop = True
        Me.radioButtonPt.Text = "Pointées"
        Me.radioButtonPt.UseVisualStyleBackColor = True
        '
        'radioButtonNonPt
        '
        Me.radioButtonNonPt.AutoSize = True
        Me.radioButtonNonPt.Checked = True
        Me.radioButtonNonPt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioButtonNonPt.Location = New System.Drawing.Point(30, 28)
        Me.radioButtonNonPt.Name = "radioButtonNonPt"
        Me.radioButtonNonPt.Size = New System.Drawing.Size(88, 17)
        Me.radioButtonNonPt.TabIndex = 0
        Me.radioButtonNonPt.TabStop = True
        Me.radioButtonNonPt.Text = "Non pointées"
        Me.radioButtonNonPt.UseVisualStyleBackColor = True
        '
        'buttonDept
        '
        Me.buttonDept.Image = Global.AgrigestEDI.My.Resources.Resources.DeleteHS
        Me.buttonDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonDept.Location = New System.Drawing.Point(390, 180)
        Me.buttonDept.Name = "buttonDept"
        Me.buttonDept.Size = New System.Drawing.Size(75, 23)
        Me.buttonDept.TabIndex = 19
        Me.buttonDept.Text = "Dépointer"
        Me.buttonDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonDept.UseVisualStyleBackColor = True
        '
        'buttonPt
        '
        Me.buttonPt.Image = Global.AgrigestEDI.My.Resources.Resources.CheckSpellingHS
        Me.buttonPt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPt.Location = New System.Drawing.Point(520, 180)
        Me.buttonPt.Name = "buttonPt"
        Me.buttonPt.Size = New System.Drawing.Size(75, 23)
        Me.buttonPt.TabIndex = 18
        Me.buttonPt.Text = "Pointer"
        Me.buttonPt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPt.UseVisualStyleBackColor = True
        '
        'comboBoxActivite
        '
        Me.comboBoxActivite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboBoxActivite.DataSource = Me.PlanActivitesBindingSource
        Me.comboBoxActivite.DisplayMember = "ADisplay"
        Me.comboBoxActivite.Enabled = False
        Me.comboBoxActivite.FormattingEnabled = True
        Me.comboBoxActivite.Location = New System.Drawing.Point(471, 43)
        Me.comboBoxActivite.Name = "comboBoxActivite"
        Me.comboBoxActivite.Size = New System.Drawing.Size(213, 21)
        Me.comboBoxActivite.TabIndex = 21
        Me.comboBoxActivite.ValueMember = "PlActi"
        '
        'PlanActivitesBindingSource
        '
        Me.PlanActivitesBindingSource.DataMember = "ComptesPlanComptable"
        Me.PlanActivitesBindingSource.DataSource = Me.ComptesBindingSource
        Me.PlanActivitesBindingSource.Sort = "PlCpt,PlActi"
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'MouvementsBindingSource
        '
        Me.MouvementsBindingSource.DataMember = "Mouvements"
        Me.MouvementsBindingSource.DataSource = Me.DbDonneesDataSet
        Me.MouvementsBindingSource.Sort = "MDate"
        '
        'DbDonneesDataSet
        '
        Me.DbDonneesDataSet.DataSetName = "dbDonneesDataSet"
        Me.DbDonneesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dataGridViewMvts
        '
        Me.dataGridViewMvts.AllowUserToAddRows = False
        Me.dataGridViewMvts.AllowUserToDeleteRows = False
        Me.dataGridViewMvts.AllowUserToOrderColumns = True
        Me.dataGridViewMvts.AllowUserToResizeColumns = False
        Me.dataGridViewMvts.AllowUserToResizeRows = False
        Me.dataGridViewMvts.AutoGenerateColumns = False
        Me.dataGridViewMvts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dataGridViewMvts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridViewMvts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridViewMvts.ColumnHeadersHeight = 35
        Me.dataGridViewMvts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MDateDataGridViewTextBoxColumn, Me.JournalPieceDataGridViewTextBoxColumn, Me.MPieceDataGridViewTextBoxColumn, Me.LibelleLigneDataGridViewTextBoxColumn, Me.MMtDebDataGridViewTextBoxColumn, Me.MMtCreDataGridViewTextBoxColumn, Me.MPointage, Me.MDatePointage})
        Me.dataGridViewMvts.ContextMenuStrip = Me.contextMenuStripDataGridViewMvts
        Me.dataGridViewMvts.DataSource = Me.MouvementsBindingSource
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridViewMvts.DefaultCellStyle = DataGridViewCellStyle10
        Me.dataGridViewMvts.GridColor = System.Drawing.Color.LimeGreen
        Me.dataGridViewMvts.Location = New System.Drawing.Point(12, 209)
        Me.dataGridViewMvts.Name = "dataGridViewMvts"
        Me.dataGridViewMvts.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridViewMvts.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dataGridViewMvts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridViewMvts.Size = New System.Drawing.Size(960, 383)
        Me.dataGridViewMvts.TabIndex = 22
        '
        'MDateDataGridViewTextBoxColumn
        '
        Me.MDateDataGridViewTextBoxColumn.DataPropertyName = "MDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.MDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.MDateDataGridViewTextBoxColumn.Name = "MDateDataGridViewTextBoxColumn"
        Me.MDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.MDateDataGridViewTextBoxColumn.Width = 80
        '
        'JournalPieceDataGridViewTextBoxColumn
        '
        Me.JournalPieceDataGridViewTextBoxColumn.DataPropertyName = "JournalPiece"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.JournalPieceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.JournalPieceDataGridViewTextBoxColumn.HeaderText = "Journal"
        Me.JournalPieceDataGridViewTextBoxColumn.Name = "JournalPieceDataGridViewTextBoxColumn"
        Me.JournalPieceDataGridViewTextBoxColumn.ReadOnly = True
        Me.JournalPieceDataGridViewTextBoxColumn.Width = 80
        '
        'MPieceDataGridViewTextBoxColumn
        '
        Me.MPieceDataGridViewTextBoxColumn.DataPropertyName = "MPiece"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MPieceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.MPieceDataGridViewTextBoxColumn.HeaderText = "N° pièce"
        Me.MPieceDataGridViewTextBoxColumn.Name = "MPieceDataGridViewTextBoxColumn"
        Me.MPieceDataGridViewTextBoxColumn.ReadOnly = True
        Me.MPieceDataGridViewTextBoxColumn.Width = 80
        '
        'LibelleLigneDataGridViewTextBoxColumn
        '
        Me.LibelleLigneDataGridViewTextBoxColumn.DataPropertyName = "LibelleLigne"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.LibelleLigneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.LibelleLigneDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleLigneDataGridViewTextBoxColumn.Name = "LibelleLigneDataGridViewTextBoxColumn"
        Me.LibelleLigneDataGridViewTextBoxColumn.ReadOnly = True
        Me.LibelleLigneDataGridViewTextBoxColumn.Width = 300
        '
        'MMtDebDataGridViewTextBoxColumn
        '
        Me.MMtDebDataGridViewTextBoxColumn.DataPropertyName = "MMtDeb"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.MMtDebDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.MMtDebDataGridViewTextBoxColumn.HeaderText = "Débit"
        Me.MMtDebDataGridViewTextBoxColumn.Name = "MMtDebDataGridViewTextBoxColumn"
        Me.MMtDebDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MMtCreDataGridViewTextBoxColumn
        '
        Me.MMtCreDataGridViewTextBoxColumn.DataPropertyName = "MMtCre"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.MMtCreDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.MMtCreDataGridViewTextBoxColumn.HeaderText = "Crédit"
        Me.MMtCreDataGridViewTextBoxColumn.Name = "MMtCreDataGridViewTextBoxColumn"
        Me.MMtCreDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MPointage
        '
        Me.MPointage.DataPropertyName = "MPointage"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MPointage.DefaultCellStyle = DataGridViewCellStyle8
        Me.MPointage.HeaderText = "Code pointage"
        Me.MPointage.Name = "MPointage"
        Me.MPointage.ReadOnly = True
        Me.MPointage.Width = 80
        '
        'MDatePointage
        '
        Me.MDatePointage.DataPropertyName = "MDatePointage"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.MDatePointage.DefaultCellStyle = DataGridViewCellStyle9
        Me.MDatePointage.HeaderText = "Date pointage"
        Me.MDatePointage.Name = "MDatePointage"
        Me.MDatePointage.ReadOnly = True
        Me.MDatePointage.Width = 80
        '
        'contextMenuStripDataGridViewMvts
        '
        Me.contextMenuStripDataGridViewMvts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItemPointer, Me.toolStripMenuItemDepointer})
        Me.contextMenuStripDataGridViewMvts.Name = "contextMenuStripDataGridViewMvts"
        Me.contextMenuStripDataGridViewMvts.Size = New System.Drawing.Size(133, 48)
        '
        'toolStripMenuItemPointer
        '
        Me.toolStripMenuItemPointer.Image = Global.AgrigestEDI.My.Resources.Resources.CheckSpellingHS
        Me.toolStripMenuItemPointer.Name = "toolStripMenuItemPointer"
        Me.toolStripMenuItemPointer.Size = New System.Drawing.Size(132, 22)
        Me.toolStripMenuItemPointer.Text = "Pointer"
        '
        'toolStripMenuItemDepointer
        '
        Me.toolStripMenuItemDepointer.Image = Global.AgrigestEDI.My.Resources.Resources.DeleteHS
        Me.toolStripMenuItemDepointer.Name = "toolStripMenuItemDepointer"
        Me.toolStripMenuItemDepointer.Size = New System.Drawing.Size(132, 22)
        Me.toolStripMenuItemDepointer.Text = "Dépointer"
        '
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
        '
        'TLPTotaux
        '
        Me.TLPTotaux.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TLPTotaux.ColumnCount = 3
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TLPTotaux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TLPTotaux.Controls.Add(Me.Label11, 0, 2)
        Me.TLPTotaux.Controls.Add(Me.Label7, 0, 1)
        Me.TLPTotaux.Controls.Add(Me.Label8, 2, 0)
        Me.TLPTotaux.Controls.Add(Me.Label14, 1, 0)
        Me.TLPTotaux.Controls.Add(Me.labelSoldeMvtsD, 1, 2)
        Me.TLPTotaux.Controls.Add(Me.labelTotalMvtsD, 1, 1)
        Me.TLPTotaux.Controls.Add(Me.labelSoldeMvtsC, 2, 2)
        Me.TLPTotaux.Controls.Add(Me.labelTotalMvtsC, 2, 1)
        Me.TLPTotaux.Location = New System.Drawing.Point(492, 598)
        Me.TLPTotaux.Name = "TLPTotaux"
        Me.TLPTotaux.RowCount = 4
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TLPTotaux.Size = New System.Drawing.Size(301, 53)
        Me.TLPTotaux.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(5, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 15)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Solde général"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(5, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 15)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Total général"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(204, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 15)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Crédit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(102, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 15)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Débit"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelSoldeMvtsD
        '
        Me.labelSoldeMvtsD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldeMvtsD.Location = New System.Drawing.Point(102, 36)
        Me.labelSoldeMvtsD.Name = "labelSoldeMvtsD"
        Me.labelSoldeMvtsD.Size = New System.Drawing.Size(90, 15)
        Me.labelSoldeMvtsD.TabIndex = 35
        Me.labelSoldeMvtsD.Text = "0 000 000,00 €"
        Me.labelSoldeMvtsD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelTotalMvtsD
        '
        Me.labelTotalMvtsD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelTotalMvtsD.Location = New System.Drawing.Point(102, 19)
        Me.labelTotalMvtsD.Name = "labelTotalMvtsD"
        Me.labelTotalMvtsD.Size = New System.Drawing.Size(90, 15)
        Me.labelTotalMvtsD.TabIndex = 34
        Me.labelTotalMvtsD.Text = "0 000 000,00 €"
        Me.labelTotalMvtsD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelSoldeMvtsC
        '
        Me.labelSoldeMvtsC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelSoldeMvtsC.Location = New System.Drawing.Point(204, 36)
        Me.labelSoldeMvtsC.Name = "labelSoldeMvtsC"
        Me.labelSoldeMvtsC.Size = New System.Drawing.Size(90, 15)
        Me.labelSoldeMvtsC.TabIndex = 33
        Me.labelSoldeMvtsC.Text = "0 000 000,00 €"
        Me.labelSoldeMvtsC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelTotalMvtsC
        '
        Me.labelTotalMvtsC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelTotalMvtsC.Location = New System.Drawing.Point(204, 19)
        Me.labelTotalMvtsC.Name = "labelTotalMvtsC"
        Me.labelTotalMvtsC.Size = New System.Drawing.Size(90, 15)
        Me.labelTotalMvtsC.TabIndex = 32
        Me.labelTotalMvtsC.Text = "0 000 000,00 €"
        Me.labelTotalMvtsC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.labelSoldeCptD, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.labelSoldeCptC, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(758, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(207, 39)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Débit"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelSoldeCptD
        '
        Me.labelSoldeCptD.Location = New System.Drawing.Point(5, 19)
        Me.labelSoldeCptD.Name = "labelSoldeCptD"
        Me.labelSoldeCptD.Size = New System.Drawing.Size(94, 18)
        Me.labelSoldeCptD.TabIndex = 30
        Me.labelSoldeCptD.Text = "0 000 000,00 €"
        Me.labelSoldeCptD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelSoldeCptC
        '
        Me.labelSoldeCptC.Location = New System.Drawing.Point(107, 19)
        Me.labelSoldeCptC.Name = "labelSoldeCptC"
        Me.labelSoldeCptC.Size = New System.Drawing.Size(90, 18)
        Me.labelSoldeCptC.TabIndex = 29
        Me.labelSoldeCptC.Text = "0 000 000,00 €"
        Me.labelSoldeCptC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(107, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Crédit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.labelLibelle, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.labelNumPiece, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.labelMt, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.labelDatePt, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.labelDateEcr, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.labelTypeEcr, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label19, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label16, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 3)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(12, 598)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.16129!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.83871!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(350, 110)
        Me.TableLayoutPanel3.TabIndex = 29
        '
        'labelLibelle
        '
        Me.labelLibelle.Location = New System.Drawing.Point(103, 93)
        Me.labelLibelle.Name = "labelLibelle"
        Me.labelLibelle.Size = New System.Drawing.Size(244, 17)
        Me.labelLibelle.TabIndex = 11
        Me.labelLibelle.Text = "test"
        Me.labelLibelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelNumPiece
        '
        Me.labelNumPiece.Location = New System.Drawing.Point(103, 74)
        Me.labelNumPiece.Name = "labelNumPiece"
        Me.labelNumPiece.Size = New System.Drawing.Size(244, 17)
        Me.labelNumPiece.TabIndex = 10
        Me.labelNumPiece.Text = "256256"
        Me.labelNumPiece.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelMt
        '
        Me.labelMt.Location = New System.Drawing.Point(103, 55)
        Me.labelMt.Name = "labelMt"
        Me.labelMt.Size = New System.Drawing.Size(244, 17)
        Me.labelMt.TabIndex = 9
        Me.labelMt.Text = "au débit de 100 000,00 à 200 000,00"
        Me.labelMt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelDatePt
        '
        Me.labelDatePt.Location = New System.Drawing.Point(103, 37)
        Me.labelDatePt.Name = "labelDatePt"
        Me.labelDatePt.Size = New System.Drawing.Size(244, 17)
        Me.labelDatePt.TabIndex = 8
        Me.labelDatePt.Text = "01/01/2010"
        Me.labelDatePt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelDateEcr
        '
        Me.labelDateEcr.Location = New System.Drawing.Point(103, 17)
        Me.labelDateEcr.Name = "labelDateEcr"
        Me.labelDateEcr.Size = New System.Drawing.Size(244, 17)
        Me.labelDateEcr.TabIndex = 7
        Me.labelDateEcr.Text = "du 01/01/2010 jusqu'au 31/12/2010"
        Me.labelDateEcr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelTypeEcr
        '
        Me.labelTypeEcr.Location = New System.Drawing.Point(103, 0)
        Me.labelTypeEcr.Name = "labelTypeEcr"
        Me.labelTypeEcr.Size = New System.Drawing.Size(244, 17)
        Me.labelTypeEcr.TabIndex = 6
        Me.labelTypeEcr.Text = "Non pointées"
        Me.labelTypeEcr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(3, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 17)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Libellé :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(3, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 19)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "N° pièce :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(3, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 17)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Type d'écriture(s) :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(3, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 20)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Date écriture(s) :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(3, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 18)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Date pointage :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(3, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 19)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Montant :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RappBancaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(989, 720)
        Me.Controls.Add(Me.dataGridViewMvts)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.buttonDept)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.toolStripRappBancaire)
        Me.Controls.Add(Me.TLPTotaux)
        Me.Controls.Add(Me.buttonPt)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.comboBoxActivite)
        Me.Controls.Add(ActDisplayLabel)
        Me.Controls.Add(Me.GbInfosPointage)
        Me.Controls.Add(CompteDisplayLabel)
        Me.Controls.Add(Me.comboBoxCompte)
        Me.Controls.Add(Me.Label3)
        Me.Name = "RappBancaire"
        Me.Text = "Rapprochement bancaire"
        Me.toolStripRappBancaire.ResumeLayout(False)
        Me.toolStripRappBancaire.PerformLayout()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbInfosPointage.ResumeLayout(False)
        Me.GbInfosPointage.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PlanActivitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MouvementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridViewMvts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenuStripDataGridViewMvts.ResumeLayout(False)
        Me.TLPTotaux.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolStripRappBancaire As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripButtonImprimerRappBancaire As System.Windows.Forms.ToolStripButton
    Friend WithEvents comboBoxCompte As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GbInfosPointage As System.Windows.Forms.GroupBox
    Friend WithEvents dateTimePickerDatePt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dateTimePickerDateMaxEcr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents radioButtonToutes As System.Windows.Forms.RadioButton
    Friend WithEvents radioButtonPt As System.Windows.Forms.RadioButton
    Friend WithEvents radioButtonNonPt As System.Windows.Forms.RadioButton
    Friend WithEvents buttonDept As System.Windows.Forms.Button
    Friend WithEvents buttonPt As System.Windows.Forms.Button
    Friend WithEvents comboBoxActivite As System.Windows.Forms.ComboBox
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents ComptesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
    Friend WithEvents PlanActivitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
    Friend WithEvents MouvementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dataGridViewMvts As System.Windows.Forms.DataGridView
    Friend WithEvents DbDonneesDataSet As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TLPTotaux As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents toolStripButtonQuitter As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelCodePt As System.Windows.Forms.Label
    Friend WithEvents toolStripButtonRecharger As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelSoldeCptC As System.Windows.Forms.Label
    Friend WithEvents labelSoldeCptD As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents labelSoldeEcrPtC As System.Windows.Forms.Label
    Friend WithEvents labelSoldePtEnCoursC As System.Windows.Forms.Label
    Friend WithEvents labelSoldeEcrPtD As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents labelSoldePtEnCoursD As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents labelTotalMvtsC As System.Windows.Forms.Label
    Friend WithEvents labelSoldeMvtsC As System.Windows.Forms.Label
    Friend WithEvents labelTotalMvtsD As System.Windows.Forms.Label
    Friend WithEvents labelSoldeMvtsD As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalPieceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPieceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleLigneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MMtDebDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MMtCreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPointage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MDatePointage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents contextMenuStripDataGridViewMvts As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents toolStripMenuItemPointer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripMenuItemDepointer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonRechAv As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents labelNumPiece As System.Windows.Forms.Label
    Friend WithEvents labelMt As System.Windows.Forms.Label
    Friend WithEvents labelDatePt As System.Windows.Forms.Label
    Friend WithEvents labelDateEcr As System.Windows.Forms.Label
    Friend WithEvents labelTypeEcr As System.Windows.Forms.Label
    Friend WithEvents labelLibelle As System.Windows.Forms.Label
End Class
