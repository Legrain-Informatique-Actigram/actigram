<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrConfigurerAnnexesTiers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrConfigurerAnnexesTiers))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.FOURCHETTE_COMPTESDataGridView = New System.Windows.Forms.DataGridView
        Me.ACTIF_PASSIFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.EST_DETAILLE = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TYPE_PLAN_COMPTABLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FOURCHETTE_COMPTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FOURCHETTE_COMPTESTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter
        Me.ACTIF_PASSIFTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter
        Me.TYPE_PLAN_COMPTABLETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter
        Me.FOURCHETTE_COMPTESBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.COMPTE_DEB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPTE_FIN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ID_ACTIF_PASSIF = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.POSITION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ID_TYPE_PLAN_COMPTABLE = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.FOURCHETTE_COMPTESDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACTIF_PASSIFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TYPE_PLAN_COMPTABLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOURCHETTE_COMPTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOURCHETTE_COMPTESBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FOURCHETTE_COMPTESBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'FOURCHETTE_COMPTESDataGridView
        '
        Me.FOURCHETTE_COMPTESDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FOURCHETTE_COMPTESDataGridView.AutoGenerateColumns = False
        Me.FOURCHETTE_COMPTESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FOURCHETTE_COMPTESDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EST_DETAILLE, Me.COMPTE_DEB, Me.COMPTE_FIN, Me.ID_ACTIF_PASSIF, Me.POSITION, Me.ID_TYPE_PLAN_COMPTABLE})
        Me.FOURCHETTE_COMPTESDataGridView.DataSource = Me.FOURCHETTE_COMPTESBindingSource
        Me.FOURCHETTE_COMPTESDataGridView.Location = New System.Drawing.Point(12, 28)
        Me.FOURCHETTE_COMPTESDataGridView.Name = "FOURCHETTE_COMPTESDataGridView"
        Me.FOURCHETTE_COMPTESDataGridView.Size = New System.Drawing.Size(587, 433)
        Me.FOURCHETTE_COMPTESDataGridView.TabIndex = 0
        '
        'ACTIF_PASSIFBindingSource
        '
        Me.ACTIF_PASSIFBindingSource.DataMember = "ACTIF_PASSIF"
        Me.ACTIF_PASSIFBindingSource.DataSource = Me.DataSetBaremes
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EST_DETAILLE
        '
        Me.EST_DETAILLE.DataPropertyName = "EST_DETAILLE"
        Me.EST_DETAILLE.HeaderText = "Détaillé"
        Me.EST_DETAILLE.Name = "EST_DETAILLE"
        Me.EST_DETAILLE.Width = 60
        '
        'TYPE_PLAN_COMPTABLEBindingSource
        '
        Me.TYPE_PLAN_COMPTABLEBindingSource.DataMember = "TYPE_PLAN_COMPTABLE"
        Me.TYPE_PLAN_COMPTABLEBindingSource.DataSource = Me.DataSetBaremes
        '
        'FOURCHETTE_COMPTESBindingSource
        '
        Me.FOURCHETTE_COMPTESBindingSource.DataMember = "FOURCHETTE_COMPTES"
        Me.FOURCHETTE_COMPTESBindingSource.DataSource = Me.DataSetBaremes
        '
        'FOURCHETTE_COMPTESTableAdapter
        '
        Me.FOURCHETTE_COMPTESTableAdapter.ClearBeforeFill = True
        '
        'ACTIF_PASSIFTableAdapter
        '
        Me.ACTIF_PASSIFTableAdapter.ClearBeforeFill = True
        '
        'TYPE_PLAN_COMPTABLETableAdapter
        '
        Me.TYPE_PLAN_COMPTABLETableAdapter.ClearBeforeFill = True
        '
        'FOURCHETTE_COMPTESBindingNavigator
        '
        Me.FOURCHETTE_COMPTESBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.FOURCHETTE_COMPTESBindingNavigator.BindingSource = Me.FOURCHETTE_COMPTESBindingSource
        Me.FOURCHETTE_COMPTESBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.FOURCHETTE_COMPTESBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.FOURCHETTE_COMPTESBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.FOURCHETTE_COMPTESBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.FOURCHETTE_COMPTESBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.FOURCHETTE_COMPTESBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.FOURCHETTE_COMPTESBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.FOURCHETTE_COMPTESBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.FOURCHETTE_COMPTESBindingNavigator.Name = "FOURCHETTE_COMPTESBindingNavigator"
        Me.FOURCHETTE_COMPTESBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.FOURCHETTE_COMPTESBindingNavigator.Size = New System.Drawing.Size(611, 25)
        Me.FOURCHETTE_COMPTESBindingNavigator.TabIndex = 1
        Me.FOURCHETTE_COMPTESBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "COMPTE_DEB"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Compte début"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 8
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "COMPTE_FIN"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Compte fin"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 8
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "ID_ACTIF_PASSIF"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.ACTIF_PASSIFBindingSource
        Me.DataGridViewComboBoxColumn1.DisplayMember = "LIBELLE_ACTIF_PASSIF"
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DataGridViewComboBoxColumn1.HeaderText = "Actif/Passif"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.ValueMember = "ID_ACTIF_PASSIF"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "POSITION"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Position"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "ID_TYPE_PLAN_COMPTABLE"
        Me.DataGridViewComboBoxColumn2.DataSource = Me.TYPE_PLAN_COMPTABLEBindingSource
        Me.DataGridViewComboBoxColumn2.DisplayMember = "LIBELLE_TYPE_PLAN_COMPTABLE"
        Me.DataGridViewComboBoxColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DataGridViewComboBoxColumn2.HeaderText = "Type plan comptable"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.ValueMember = "ID_TYPE_PLAN_COMPTABLE"
        '
        'COMPTE_DEB
        '
        Me.COMPTE_DEB.DataPropertyName = "COMPTE_DEB"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COMPTE_DEB.DefaultCellStyle = DataGridViewCellStyle1
        Me.COMPTE_DEB.HeaderText = "Compte début"
        Me.COMPTE_DEB.MaxInputLength = 8
        Me.COMPTE_DEB.Name = "COMPTE_DEB"
        '
        'COMPTE_FIN
        '
        Me.COMPTE_FIN.DataPropertyName = "COMPTE_FIN"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COMPTE_FIN.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPTE_FIN.HeaderText = "Compte fin"
        Me.COMPTE_FIN.MaxInputLength = 8
        Me.COMPTE_FIN.Name = "COMPTE_FIN"
        '
        'ID_ACTIF_PASSIF
        '
        Me.ID_ACTIF_PASSIF.DataPropertyName = "ID_ACTIF_PASSIF"
        Me.ID_ACTIF_PASSIF.DataSource = Me.ACTIF_PASSIFBindingSource
        Me.ID_ACTIF_PASSIF.DisplayMember = "LIBELLE_ACTIF_PASSIF"
        Me.ID_ACTIF_PASSIF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ID_ACTIF_PASSIF.HeaderText = "Actif/Passif"
        Me.ID_ACTIF_PASSIF.Name = "ID_ACTIF_PASSIF"
        Me.ID_ACTIF_PASSIF.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ID_ACTIF_PASSIF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ID_ACTIF_PASSIF.ValueMember = "ID_ACTIF_PASSIF"
        '
        'POSITION
        '
        Me.POSITION.DataPropertyName = "POSITION"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.POSITION.DefaultCellStyle = DataGridViewCellStyle3
        Me.POSITION.HeaderText = "Position"
        Me.POSITION.Name = "POSITION"
        Me.POSITION.Width = 60
        '
        'ID_TYPE_PLAN_COMPTABLE
        '
        Me.ID_TYPE_PLAN_COMPTABLE.DataPropertyName = "ID_TYPE_PLAN_COMPTABLE"
        Me.ID_TYPE_PLAN_COMPTABLE.DataSource = Me.TYPE_PLAN_COMPTABLEBindingSource
        Me.ID_TYPE_PLAN_COMPTABLE.DisplayMember = "LIBELLE_TYPE_PLAN_COMPTABLE"
        Me.ID_TYPE_PLAN_COMPTABLE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ID_TYPE_PLAN_COMPTABLE.HeaderText = "Type plan comptable"
        Me.ID_TYPE_PLAN_COMPTABLE.Name = "ID_TYPE_PLAN_COMPTABLE"
        Me.ID_TYPE_PLAN_COMPTABLE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ID_TYPE_PLAN_COMPTABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ID_TYPE_PLAN_COMPTABLE.ValueMember = "ID_TYPE_PLAN_COMPTABLE"
        '
        'FrConfigurerAnnexesTiers
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(611, 473)
        Me.Controls.Add(Me.FOURCHETTE_COMPTESBindingNavigator)
        Me.Controls.Add(Me.FOURCHETTE_COMPTESDataGridView)
        Me.Name = "FrConfigurerAnnexesTiers"
        Me.Text = "Configurer les annexes de tiers"
        CType(Me.FOURCHETTE_COMPTESDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACTIF_PASSIFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TYPE_PLAN_COMPTABLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOURCHETTE_COMPTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOURCHETTE_COMPTESBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FOURCHETTE_COMPTESBindingNavigator.ResumeLayout(False)
        Me.FOURCHETTE_COMPTESBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents FOURCHETTE_COMPTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOURCHETTE_COMPTESTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter
    Friend WithEvents ACTIF_PASSIFBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ACTIF_PASSIFTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter
    Friend WithEvents FOURCHETTE_COMPTESDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TYPE_PLAN_COMPTABLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TYPE_PLAN_COMPTABLETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter
    Friend WithEvents COMPTE_DEB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPTE_FIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID_ACTIF_PASSIF As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents POSITION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EST_DETAILLE As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID_TYPE_PLAN_COMPTABLE As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FOURCHETTE_COMPTESBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
