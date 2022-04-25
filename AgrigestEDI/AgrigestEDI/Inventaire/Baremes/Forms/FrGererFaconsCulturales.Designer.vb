<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrGererFaconsCulturales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGererFaconsCulturales))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.FACON_CULTURALEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FACON_CULTURALETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter
        Me.FACON_CULTURALEBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.FACON_CULTURALEDataGridView = New System.Windows.Forms.DataGridView
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FACON_CULTURALEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FACON_CULTURALEBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FACON_CULTURALEBindingNavigator.SuspendLayout()
        CType(Me.FACON_CULTURALEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FACON_CULTURALEBindingSource
        '
        Me.FACON_CULTURALEBindingSource.DataMember = "FACON_CULTURALE"
        Me.FACON_CULTURALEBindingSource.DataSource = Me.DataSetBaremes
        '
        'FACON_CULTURALETableAdapter
        '
        Me.FACON_CULTURALETableAdapter.ClearBeforeFill = True
        '
        'FACON_CULTURALEBindingNavigator
        '
        Me.FACON_CULTURALEBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.FACON_CULTURALEBindingNavigator.BindingSource = Me.FACON_CULTURALEBindingSource
        Me.FACON_CULTURALEBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.FACON_CULTURALEBindingNavigator.DeleteItem = Nothing
        Me.FACON_CULTURALEBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.SupprimerToolStripButton})
        Me.FACON_CULTURALEBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.FACON_CULTURALEBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.FACON_CULTURALEBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.FACON_CULTURALEBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.FACON_CULTURALEBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.FACON_CULTURALEBindingNavigator.Name = "FACON_CULTURALEBindingNavigator"
        Me.FACON_CULTURALEBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.FACON_CULTURALEBindingNavigator.Size = New System.Drawing.Size(639, 25)
        Me.FACON_CULTURALEBindingNavigator.TabIndex = 0
        Me.FACON_CULTURALEBindingNavigator.Text = "BindingNavigator1"
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
        'SupprimerToolStripButton
        '
        Me.SupprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerToolStripButton.Name = "SupprimerToolStripButton"
        Me.SupprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SupprimerToolStripButton.Text = "Supprimer"
        '
        'FACON_CULTURALEDataGridView
        '
        Me.FACON_CULTURALEDataGridView.AllowUserToDeleteRows = False
        Me.FACON_CULTURALEDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FACON_CULTURALEDataGridView.AutoGenerateColumns = False
        Me.FACON_CULTURALEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FACON_CULTURALEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn})
        Me.FACON_CULTURALEDataGridView.DataSource = Me.FACON_CULTURALEBindingSource
        Me.FACON_CULTURALEDataGridView.Location = New System.Drawing.Point(12, 28)
        Me.FACON_CULTURALEDataGridView.Name = "FACON_CULTURALEDataGridView"
        Me.FACON_CULTURALEDataGridView.Size = New System.Drawing.Size(615, 562)
        Me.FACON_CULTURALEDataGridView.TabIndex = 1
        '
        'LIBELLEFACONCULTURALEDataGridViewTextBoxColumn
        '
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.DataPropertyName = "LIBELLE_FACON_CULTURALE"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.Name = "LIBELLEFACONCULTURALEDataGridViewTextBoxColumn"
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.Width = 550
        '
        'FrGererFaconsCulturales
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(639, 602)
        Me.Controls.Add(Me.FACON_CULTURALEDataGridView)
        Me.Controls.Add(Me.FACON_CULTURALEBindingNavigator)
        Me.Name = "FrGererFaconsCulturales"
        Me.Text = "Gérer les façons culturales"
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FACON_CULTURALEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FACON_CULTURALEBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FACON_CULTURALEBindingNavigator.ResumeLayout(False)
        Me.FACON_CULTURALEBindingNavigator.PerformLayout()
        CType(Me.FACON_CULTURALEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents FACON_CULTURALEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FACON_CULTURALETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter
    Friend WithEvents FACON_CULTURALEBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FACON_CULTURALEDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LIBELLEFACONCULTURALEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
