<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrGererTypesMateriel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGererTypesMateriel))
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.TYPE_MATERIELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorTYPE_MATERIEL = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.ToolStripButtonSupprimerTypeMateriel = New System.Windows.Forms.ToolStripButton
        Me.TYPE_MATERIELTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter
        Me.DataGridViewTYPE_MATERIEL = New System.Windows.Forms.DataGridView
        Me.CODETYPEMATERIELDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TYPE_MATERIELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigatorTYPE_MATERIEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorTYPE_MATERIEL.SuspendLayout()
        CType(Me.DataGridViewTYPE_MATERIEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TYPE_MATERIELBindingSource
        '
        Me.TYPE_MATERIELBindingSource.DataMember = "TYPE_MATERIEL"
        Me.TYPE_MATERIELBindingSource.DataSource = Me.DataSetBaremes
        '
        'BindingNavigatorTYPE_MATERIEL
        '
        Me.BindingNavigatorTYPE_MATERIEL.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigatorTYPE_MATERIEL.BindingSource = Me.TYPE_MATERIELBindingSource
        Me.BindingNavigatorTYPE_MATERIEL.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigatorTYPE_MATERIEL.DeleteItem = Nothing
        Me.BindingNavigatorTYPE_MATERIEL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.ToolStripButtonSupprimerTypeMateriel})
        Me.BindingNavigatorTYPE_MATERIEL.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigatorTYPE_MATERIEL.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigatorTYPE_MATERIEL.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigatorTYPE_MATERIEL.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigatorTYPE_MATERIEL.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigatorTYPE_MATERIEL.Name = "BindingNavigatorTYPE_MATERIEL"
        Me.BindingNavigatorTYPE_MATERIEL.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigatorTYPE_MATERIEL.Size = New System.Drawing.Size(428, 25)
        Me.BindingNavigatorTYPE_MATERIEL.TabIndex = 0
        Me.BindingNavigatorTYPE_MATERIEL.Text = "BindingNavigator1"
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
        'ToolStripButtonSupprimerTypeMateriel
        '
        Me.ToolStripButtonSupprimerTypeMateriel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSupprimerTypeMateriel.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.ToolStripButtonSupprimerTypeMateriel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSupprimerTypeMateriel.Name = "ToolStripButtonSupprimerTypeMateriel"
        Me.ToolStripButtonSupprimerTypeMateriel.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonSupprimerTypeMateriel.Text = "Supprimer le type de matériel"
        '
        'TYPE_MATERIELTableAdapter
        '
        Me.TYPE_MATERIELTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTYPE_MATERIEL
        '
        Me.DataGridViewTYPE_MATERIEL.AllowUserToDeleteRows = False
        Me.DataGridViewTYPE_MATERIEL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewTYPE_MATERIEL.AutoGenerateColumns = False
        Me.DataGridViewTYPE_MATERIEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTYPE_MATERIEL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODETYPEMATERIELDataGridViewTextBoxColumn, Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn})
        Me.DataGridViewTYPE_MATERIEL.DataSource = Me.TYPE_MATERIELBindingSource
        Me.DataGridViewTYPE_MATERIEL.Location = New System.Drawing.Point(12, 28)
        Me.DataGridViewTYPE_MATERIEL.Name = "DataGridViewTYPE_MATERIEL"
        Me.DataGridViewTYPE_MATERIEL.Size = New System.Drawing.Size(404, 384)
        Me.DataGridViewTYPE_MATERIEL.TabIndex = 1
        '
        'CODETYPEMATERIELDataGridViewTextBoxColumn
        '
        Me.CODETYPEMATERIELDataGridViewTextBoxColumn.DataPropertyName = "CODE_TYPE_MATERIEL"
        Me.CODETYPEMATERIELDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.CODETYPEMATERIELDataGridViewTextBoxColumn.Name = "CODETYPEMATERIELDataGridViewTextBoxColumn"
        '
        'LIBELLETYPEMATERIELDataGridViewTextBoxColumn
        '
        Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn.DataPropertyName = "LIBELLE_TYPE_MATERIEL"
        Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn.Name = "LIBELLETYPEMATERIELDataGridViewTextBoxColumn"
        Me.LIBELLETYPEMATERIELDataGridViewTextBoxColumn.Width = 250
        '
        'FrGererTypesMateriel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(428, 424)
        Me.Controls.Add(Me.DataGridViewTYPE_MATERIEL)
        Me.Controls.Add(Me.BindingNavigatorTYPE_MATERIEL)
        Me.Name = "FrGererTypesMateriel"
        Me.Text = "Gérer les types de matériel"
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TYPE_MATERIELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigatorTYPE_MATERIEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorTYPE_MATERIEL.ResumeLayout(False)
        Me.BindingNavigatorTYPE_MATERIEL.PerformLayout()
        CType(Me.DataGridViewTYPE_MATERIEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents TYPE_MATERIELBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigatorTYPE_MATERIEL As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents TYPE_MATERIELTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter
    Friend WithEvents ToolStripButtonSupprimerTypeMateriel As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTYPE_MATERIEL As System.Windows.Forms.DataGridView
    Friend WithEvents CODETYPEMATERIELDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LIBELLETYPEMATERIELDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
