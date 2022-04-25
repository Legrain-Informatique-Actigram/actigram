<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrGererMateriel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGererMateriel))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MATERIELDataGridView = New System.Windows.Forms.DataGridView
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.TYPE_MATERIELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.MATERIELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MATERIELBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SupprimerMaterielToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.MATERIELTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.MATERIELTableAdapter
        Me.TYPE_MATERIELTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.MATERIELDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TYPE_MATERIELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATERIELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATERIELBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MATERIELBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'MATERIELDataGridView
        '
        Me.MATERIELDataGridView.AllowUserToDeleteRows = False
        Me.MATERIELDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MATERIELDataGridView.AutoGenerateColumns = False
        Me.MATERIELDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MATERIELDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LIBELLEMATERIELDataGridViewTextBoxColumn, Me.IDTYPEMATERIELDataGridViewComboBoxColumn})
        Me.MATERIELDataGridView.DataSource = Me.MATERIELBindingSource
        Me.MATERIELDataGridView.Location = New System.Drawing.Point(12, 41)
        Me.MATERIELDataGridView.Name = "MATERIELDataGridView"
        Me.MATERIELDataGridView.Size = New System.Drawing.Size(762, 518)
        Me.MATERIELDataGridView.TabIndex = 0
        '
        'LIBELLEMATERIELDataGridViewTextBoxColumn
        '
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn.DataPropertyName = "LIBELLE_MATERIEL"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn.Name = "LIBELLEMATERIELDataGridViewTextBoxColumn"
        Me.LIBELLEMATERIELDataGridViewTextBoxColumn.Width = 550
        '
        'IDTYPEMATERIELDataGridViewComboBoxColumn
        '
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.DataPropertyName = "ID_TYPE_MATERIEL"
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.DataSource = Me.TYPE_MATERIELBindingSource
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.DisplayMember = "LIBELLE_TYPE_MATERIEL"
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.HeaderText = "Type"
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.Name = "IDTYPEMATERIELDataGridViewComboBoxColumn"
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.ValueMember = "ID_TYPE_MATERIEL"
        Me.IDTYPEMATERIELDataGridViewComboBoxColumn.Width = 150
        '
        'TYPE_MATERIELBindingSource
        '
        Me.TYPE_MATERIELBindingSource.DataMember = "TYPE_MATERIEL"
        Me.TYPE_MATERIELBindingSource.DataSource = Me.DataSetBaremes
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MATERIELBindingSource
        '
        Me.MATERIELBindingSource.DataMember = "MATERIEL"
        Me.MATERIELBindingSource.DataSource = Me.DataSetBaremes
        '
        'MATERIELBindingNavigator
        '
        Me.MATERIELBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.MATERIELBindingNavigator.BindingSource = Me.MATERIELBindingSource
        Me.MATERIELBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.MATERIELBindingNavigator.DeleteItem = Nothing
        Me.MATERIELBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.SupprimerMaterielToolStripButton})
        Me.MATERIELBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.MATERIELBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.MATERIELBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.MATERIELBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.MATERIELBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.MATERIELBindingNavigator.Name = "MATERIELBindingNavigator"
        Me.MATERIELBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.MATERIELBindingNavigator.Size = New System.Drawing.Size(786, 25)
        Me.MATERIELBindingNavigator.TabIndex = 1
        Me.MATERIELBindingNavigator.Text = "BindingNavigator1"
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
        'SupprimerMaterielToolStripButton
        '
        Me.SupprimerMaterielToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerMaterielToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerMaterielToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerMaterielToolStripButton.Name = "SupprimerMaterielToolStripButton"
        Me.SupprimerMaterielToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SupprimerMaterielToolStripButton.Text = "Supprimer le matériel"
        '
        'MATERIELTableAdapter
        '
        Me.MATERIELTableAdapter.ClearBeforeFill = True
        '
        'TYPE_MATERIELTableAdapter
        '
        Me.TYPE_MATERIELTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "LIBELLE_MATERIEL"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Libellé"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 550
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "ID_TYPE_MATERIEL"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.TYPE_MATERIELBindingSource
        Me.DataGridViewComboBoxColumn1.DisplayMember = "LIBELLE_TYPE_MATERIEL"
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DataGridViewComboBoxColumn1.HeaderText = "Type"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.ValueMember = "ID_TYPE_MATERIEL"
        Me.DataGridViewComboBoxColumn1.Width = 150
        '
        'FrGererMateriel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(786, 571)
        Me.Controls.Add(Me.MATERIELBindingNavigator)
        Me.Controls.Add(Me.MATERIELDataGridView)
        Me.Name = "FrGererMateriel"
        Me.Text = "Gérer le matériel"
        CType(Me.MATERIELDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TYPE_MATERIELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATERIELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATERIELBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MATERIELBindingNavigator.ResumeLayout(False)
        Me.MATERIELBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents MATERIELBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MATERIELTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.MATERIELTableAdapter
    Friend WithEvents MATERIELDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TYPE_MATERIELBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TYPE_MATERIELTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter
    Friend WithEvents MATERIELBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerMaterielToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LIBELLEMATERIELDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTYPEMATERIELDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
