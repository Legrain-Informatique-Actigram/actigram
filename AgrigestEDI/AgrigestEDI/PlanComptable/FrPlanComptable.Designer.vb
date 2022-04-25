<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrPlanComptable
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
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlanComptableTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
        Me.PlanComptableBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ImprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CMenuAction = New System.Windows.Forms.ToolStripDropDownButton
        Me.CMenuActivite = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuActiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuActiModif = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuPlanC = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuPlanCNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuPlanCModif = New System.Windows.Forms.ToolStripMenuItem
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.PlanComptableBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TxFilterPlc = New System.Windows.Forms.ToolStripTextBox
        Me.PlanComptableDataGridView = New AgrigestEDI.DataGridViewEnter
        Me.PlActi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActDisplay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AQte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlCpt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlCLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlRepD = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.PlRepC = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.PlRepQt1 = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.CU1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlRepQt2 = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.CU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CtxGrille = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisualiserLeCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ModifierLeCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerLeCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComptesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MouvementsTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlanComptableBindingNavigator.SuspendLayout()
        CType(Me.PlanComptableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtxGrille.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlanComptableBindingSource
        '
        Me.PlanComptableBindingSource.DataMember = "PlanComptable"
        Me.PlanComptableBindingSource.DataSource = Me.DsPLC
        Me.PlanComptableBindingSource.Sort = "PlCpt,PlActi"
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableBindingNavigator
        '
        Me.PlanComptableBindingNavigator.AddNewItem = Nothing
        Me.PlanComptableBindingNavigator.BindingSource = Me.PlanComptableBindingSource
        Me.PlanComptableBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.PlanComptableBindingNavigator.DeleteItem = Nothing
        Me.PlanComptableBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PlanComptableBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ImprimerToolStripButton, Me.CMenuAction, Me.BindingNavigatorDeleteItem, Me.PlanComptableBindingNavigatorSaveItem, Me.TbFermer, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.TxFilterPlc})
        Me.PlanComptableBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.PlanComptableBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.PlanComptableBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.PlanComptableBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.PlanComptableBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.PlanComptableBindingNavigator.Name = "PlanComptableBindingNavigator"
        Me.PlanComptableBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.PlanComptableBindingNavigator.Size = New System.Drawing.Size(670, 25)
        Me.PlanComptableBindingNavigator.TabIndex = 0
        Me.PlanComptableBindingNavigator.Text = "BindingNavigator1"
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
        Me.BindingNavigatorMoveFirstItem.Image = Global.AgrigestEDI.My.Resources.Resources.first
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = Global.AgrigestEDI.My.Resources.Resources.previous
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
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
        Me.BindingNavigatorMoveNextItem.Image = Global.AgrigestEDI.My.Resources.Resources._next
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = Global.AgrigestEDI.My.Resources.Resources.last
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
        'ImprimerToolStripButton
        '
        Me.ImprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.impr
        Me.ImprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimerToolStripButton.Name = "ImprimerToolStripButton"
        Me.ImprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimerToolStripButton.Text = "Imprimer le plan comptable"
        '
        'CMenuAction
        '
        Me.CMenuAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CMenuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuActivite, Me.CMenuPlanC})
        Me.CMenuAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMenuAction.Name = "CMenuAction"
        Me.CMenuAction.Size = New System.Drawing.Size(55, 22)
        Me.CMenuAction.Text = "Action"
        '
        'CMenuActivite
        '
        Me.CMenuActivite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuActiNew, Me.CMenuActiModif})
        Me.CMenuActivite.Name = "CMenuActivite"
        Me.CMenuActivite.Size = New System.Drawing.Size(157, 22)
        Me.CMenuActivite.Text = "Activité"
        '
        'CMenuActiNew
        '
        Me.CMenuActiNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.CMenuActiNew.Name = "CMenuActiNew"
        Me.CMenuActiNew.Size = New System.Drawing.Size(214, 22)
        Me.CMenuActiNew.Text = "Créer une nouvelle activité"
        '
        'CMenuActiModif
        '
        Me.CMenuActiModif.Image = Global.AgrigestEDI.My.Resources.Resources.liste
        Me.CMenuActiModif.Name = "CMenuActiModif"
        Me.CMenuActiModif.Size = New System.Drawing.Size(214, 22)
        Me.CMenuActiModif.Text = "Modifier une activité"
        Me.CMenuActiModif.Visible = False
        '
        'CMenuPlanC
        '
        Me.CMenuPlanC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuPlanCNew, Me.CMenuPlanCModif})
        Me.CMenuPlanC.Name = "CMenuPlanC"
        Me.CMenuPlanC.Size = New System.Drawing.Size(157, 22)
        Me.CMenuPlanC.Text = "Plan comptable"
        '
        'CMenuPlanCNew
        '
        Me.CMenuPlanCNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.CMenuPlanCNew.Name = "CMenuPlanCNew"
        Me.CMenuPlanCNew.Size = New System.Drawing.Size(212, 22)
        Me.CMenuPlanCNew.Text = "Créer un nouveau compte"
        '
        'CMenuPlanCModif
        '
        Me.CMenuPlanCModif.Image = Global.AgrigestEDI.My.Resources.Resources.liste
        Me.CMenuPlanCModif.Name = "CMenuPlanCModif"
        Me.CMenuPlanCModif.Size = New System.Drawing.Size(212, 22)
        Me.CMenuPlanCModif.Text = "Modifier les comptes"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'PlanComptableBindingNavigatorSaveItem
        '
        Me.PlanComptableBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PlanComptableBindingNavigatorSaveItem.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.PlanComptableBindingNavigatorSaveItem.Name = "PlanComptableBindingNavigatorSaveItem"
        Me.PlanComptableBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.PlanComptableBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripLabel1.Text = "Comptes commençant par:"
        '
        'TxFilterPlc
        '
        Me.TxFilterPlc.AutoSize = False
        Me.TxFilterPlc.MaxLength = 8
        Me.TxFilterPlc.Name = "TxFilterPlc"
        Me.TxFilterPlc.Size = New System.Drawing.Size(100, 25)
        '
        'PlanComptableDataGridView
        '
        Me.PlanComptableDataGridView.AllowUserToAddRows = False
        Me.PlanComptableDataGridView.AllowUserToDeleteRows = False
        Me.PlanComptableDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlanComptableDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.PlanComptableDataGridView.ColumnHeadersHeight = 35
        Me.PlanComptableDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PlActi, Me.ActDisplay, Me.AQte, Me.AUnit, Me.PlCpt, Me.PlCLib, Me.PlRepD, Me.PlRepC, Me.PlRepQt1, Me.CU1, Me.PlRepQt2, Me.CU2, Me.PlLib, Me.Column1})
        Me.PlanComptableDataGridView.ContextMenuStrip = Me.CtxGrille
        Me.PlanComptableDataGridView.DataSource = Me.PlanComptableBindingSource
        Me.PlanComptableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlanComptableDataGridView.JumpToMontant = False
        Me.PlanComptableDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PlanComptableDataGridView.Name = "PlanComptableDataGridView"
        Me.PlanComptableDataGridView.Size = New System.Drawing.Size(670, 359)
        Me.PlanComptableDataGridView.TabIndex = 1
        '
        'PlActi
        '
        Me.PlActi.DataPropertyName = "PlActi"
        Me.PlActi.HeaderText = "Code Activité"
        Me.PlActi.Name = "PlActi"
        Me.PlActi.ReadOnly = True
        Me.PlActi.Width = 50
        '
        'ActDisplay
        '
        Me.ActDisplay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ActDisplay.DataPropertyName = "ActDisplay"
        Me.ActDisplay.HeaderText = "Libellé Activité"
        Me.ActDisplay.Name = "ActDisplay"
        Me.ActDisplay.ReadOnly = True
        Me.ActDisplay.Width = 92
        '
        'AQte
        '
        Me.AQte.DataPropertyName = "AQte"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.AQte.DefaultCellStyle = DataGridViewCellStyle2
        Me.AQte.HeaderText = "Unité d'Act."
        Me.AQte.Name = "AQte"
        Me.AQte.ReadOnly = True
        Me.AQte.Width = 40
        '
        'AUnit
        '
        Me.AUnit.DataPropertyName = "AUnit"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.AUnit.DefaultCellStyle = DataGridViewCellStyle3
        Me.AUnit.HeaderText = ""
        Me.AUnit.Name = "AUnit"
        Me.AUnit.ReadOnly = True
        Me.AUnit.Width = 20
        '
        'PlCpt
        '
        Me.PlCpt.DataPropertyName = "PlCpt"
        Me.PlCpt.HeaderText = "N° de Compte"
        Me.PlCpt.Name = "PlCpt"
        Me.PlCpt.ReadOnly = True
        Me.PlCpt.Width = 75
        '
        'PlCLib
        '
        Me.PlCLib.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PlCLib.DataPropertyName = "CptDisplay"
        Me.PlCLib.HeaderText = "Libellé du compte"
        Me.PlCLib.MaxInputLength = 30
        Me.PlCLib.Name = "PlCLib"
        Me.PlCLib.ReadOnly = True
        '
        'PlRepD
        '
        Me.PlRepD.DataPropertyName = "PlRepG_D"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "# ##0.00 €;-# ##0.00 €;"""""
        DataGridViewCellStyle4.NullValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.PlRepD.DefaultCellStyle = DataGridViewCellStyle4
        Me.PlRepD.HeaderText = "Montant Débit"
        Me.PlRepD.Name = "PlRepD"
        Me.PlRepD.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlRepD.Visible = False
        Me.PlRepD.Width = 90
        '
        'PlRepC
        '
        Me.PlRepC.DataPropertyName = "PlRepG_C"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "# ##0.00 €;-# ##0.00 €;"""""
        DataGridViewCellStyle5.NullValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.PlRepC.DefaultCellStyle = DataGridViewCellStyle5
        Me.PlRepC.HeaderText = "Montant Crédit"
        Me.PlRepC.Name = "PlRepC"
        Me.PlRepC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlRepC.Visible = False
        Me.PlRepC.Width = 90
        '
        'PlRepQt1
        '
        Me.PlRepQt1.DataPropertyName = "PlRepG_U1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "# ##0.000;-# ##0.000;"""""
        DataGridViewCellStyle6.NullValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.PlRepQt1.DefaultCellStyle = DataGridViewCellStyle6
        Me.PlRepQt1.HeaderText = "Quantité 1"
        Me.PlRepQt1.Name = "PlRepQt1"
        Me.PlRepQt1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlRepQt1.Visible = False
        Me.PlRepQt1.Width = 80
        '
        'CU1
        '
        Me.CU1.DataPropertyName = "CU1"
        Me.CU1.HeaderText = ""
        Me.CU1.Name = "CU1"
        Me.CU1.ReadOnly = True
        Me.CU1.Visible = False
        Me.CU1.Width = 20
        '
        'PlRepQt2
        '
        Me.PlRepQt2.DataPropertyName = "PlRepG_U2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "# ##0.000;-# ##0.000;"""""
        DataGridViewCellStyle7.NullValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.PlRepQt2.DefaultCellStyle = DataGridViewCellStyle7
        Me.PlRepQt2.HeaderText = "Quantité 2"
        Me.PlRepQt2.Name = "PlRepQt2"
        Me.PlRepQt2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlRepQt2.Visible = False
        Me.PlRepQt2.Width = 80
        '
        'CU2
        '
        Me.CU2.DataPropertyName = "CU2"
        Me.CU2.HeaderText = ""
        Me.CU2.Name = "CU2"
        Me.CU2.ReadOnly = True
        Me.CU2.Visible = False
        Me.CU2.Width = 20
        '
        'PlLib
        '
        Me.PlLib.DataPropertyName = "PlLib"
        Me.PlLib.HeaderText = "Libellé du plan comptable"
        Me.PlLib.MaxInputLength = 55
        Me.PlLib.Name = "PlLib"
        Me.PlLib.Width = 300
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 5
        '
        'CtxGrille
        '
        Me.CtxGrille.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisualiserLeCompteToolStripMenuItem, Me.ToolStripSeparator2, Me.ModifierLeCompteToolStripMenuItem, Me.SupprimerLeCompteToolStripMenuItem})
        Me.CtxGrille.Name = "CtxGrille"
        Me.CtxGrille.Size = New System.Drawing.Size(189, 76)
        '
        'VisualiserLeCompteToolStripMenuItem
        '
        Me.VisualiserLeCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.VisualiserLeCompteToolStripMenuItem.Name = "VisualiserLeCompteToolStripMenuItem"
        Me.VisualiserLeCompteToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.VisualiserLeCompteToolStripMenuItem.Text = "Visualiser le compte..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(185, 6)
        '
        'ModifierLeCompteToolStripMenuItem
        '
        Me.ModifierLeCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.ModifierLeCompteToolStripMenuItem.Name = "ModifierLeCompteToolStripMenuItem"
        Me.ModifierLeCompteToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ModifierLeCompteToolStripMenuItem.Text = "Modifier le compte..."
        '
        'SupprimerLeCompteToolStripMenuItem
        '
        Me.SupprimerLeCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerLeCompteToolStripMenuItem.Name = "SupprimerLeCompteToolStripMenuItem"
        Me.SupprimerLeCompteToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SupprimerLeCompteToolStripMenuItem.Text = "Supprimer le compte"
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PlCpt"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Compte"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "PlRepA_U2"
        Me.DataGridViewTextBoxColumn12.HeaderText = "RepA_U2"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'FrPlanComptable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.PlanComptableDataGridView)
        Me.Controls.Add(Me.PlanComptableBindingNavigator)
        Me.Name = "FrPlanComptable"
        Me.ShowIcon = False
        Me.Text = "Plan Comptable"
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlanComptableBindingNavigator.ResumeLayout(False)
        Me.PlanComptableBindingNavigator.PerformLayout()
        CType(Me.PlanComptableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtxGrille.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
    Friend WithEvents PlanComptableBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PlanComptableBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PlanComptableDataGridView As DataGridViewEnter
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ActivitesTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TxFilterPlc As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents CtxGrille As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModifierLeCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualiserLeCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerLeCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuAction As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CMenuActivite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuActiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuActiModif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuPlanC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuPlanCNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuPlanCModif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.MouvementsTableAdapter
    Friend WithEvents PlActi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActDisplay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AQte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlCpt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlCLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlRepD As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents PlRepC As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents PlRepQt1 As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents CU1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlRepQt2 As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents CU2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImprimerToolStripButton As System.Windows.Forms.ToolStripButton
End Class
