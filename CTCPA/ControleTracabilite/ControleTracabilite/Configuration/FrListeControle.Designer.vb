Namespace Controles
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeControles
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeControles))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.DefinitionControleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.DefinitionControleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.MoveDownToolStripButton = New System.Windows.Forms.ToolStripButton
            Me.MoveUpToolStripButton = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.TbApercu = New System.Windows.Forms.ToolStripButton
            Me.DefinitionControleDataGridView = New System.Windows.Forms.DataGridView
            Me.TypeColumn = New System.Windows.Forms.DataGridViewImageColumn
            Me.ColIdControle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.GroupeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.LibelleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            CType(Me.DefinitionControleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DefinitionControleBindingNavigator.SuspendLayout()
            CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DefinitionControleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefinitionControleBindingNavigator
            '
            Me.DefinitionControleBindingNavigator.AddNewItem = Nothing
            Me.DefinitionControleBindingNavigator.BindingSource = Me.DefinitionControleBindingSource
            Me.DefinitionControleBindingNavigator.CountItem = Nothing
            Me.DefinitionControleBindingNavigator.DeleteItem = Nothing
            Me.DefinitionControleBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.DefinitionControleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripSeparator1, Me.TbFermer, Me.MoveDownToolStripButton, Me.MoveUpToolStripButton, Me.ToolStripSeparator2, Me.TbApercu})
            Me.DefinitionControleBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.DefinitionControleBindingNavigator.MoveFirstItem = Nothing
            Me.DefinitionControleBindingNavigator.MoveLastItem = Nothing
            Me.DefinitionControleBindingNavigator.MoveNextItem = Nothing
            Me.DefinitionControleBindingNavigator.MovePreviousItem = Nothing
            Me.DefinitionControleBindingNavigator.Name = "DefinitionControleBindingNavigator"
            Me.DefinitionControleBindingNavigator.PositionItem = Nothing
            Me.DefinitionControleBindingNavigator.Size = New System.Drawing.Size(593, 25)
            Me.DefinitionControleBindingNavigator.TabIndex = 0
            Me.DefinitionControleBindingNavigator.Text = "BindingNavigator1"
            '
            'DefinitionControleBindingSource
            '
            Me.DefinitionControleBindingSource.DataSource = GetType(ControleTracabilite.Controles.DefinitionControle)
            '
            'BindingNavigatorAddNewItem
            '
            Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorAddNewItem.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
            Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
            '
            'BindingNavigatorDeleteItem
            '
            Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorDeleteItem.Image = Global.ControleTracabilite.My.Resources.Resources.suppr
            Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
            Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorDeleteItem.Text = "Supprimer"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = CType(resources.GetObject("TbFermer.Image"), System.Drawing.Image)
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'MoveDownToolStripButton
            '
            Me.MoveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.MoveDownToolStripButton.Image = Global.ControleTracabilite.My.Resources.Resources.BuilderDialog_movedown
            Me.MoveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.MoveDownToolStripButton.Name = "MoveDownToolStripButton"
            Me.MoveDownToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.MoveDownToolStripButton.Text = "Descendre le contrôle"
            '
            'MoveUpToolStripButton
            '
            Me.MoveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.MoveUpToolStripButton.Image = Global.ControleTracabilite.My.Resources.Resources.BuilderDialog_moveup
            Me.MoveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.MoveUpToolStripButton.Name = "MoveUpToolStripButton"
            Me.MoveUpToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.MoveUpToolStripButton.Text = "Remonter le contrôle"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'TbApercu
            '
            Me.TbApercu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbApercu.Image = CType(resources.GetObject("TbApercu.Image"), System.Drawing.Image)
            Me.TbApercu.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbApercu.Name = "TbApercu"
            Me.TbApercu.Size = New System.Drawing.Size(23, 22)
            Me.TbApercu.Text = "Aperçu des contrôles"
            '
            'DefinitionControleDataGridView
            '
            Me.DefinitionControleDataGridView.AllowUserToAddRows = False
            Me.DefinitionControleDataGridView.AllowUserToDeleteRows = False
            Me.DefinitionControleDataGridView.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
            Me.DefinitionControleDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DefinitionControleDataGridView.AutoGenerateColumns = False
            Me.DefinitionControleDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro
            Me.DefinitionControleDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
            Me.DefinitionControleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypeColumn, Me.ColIdControle, Me.GroupeColumn, Me.LibelleColumn})
            Me.DefinitionControleDataGridView.DataSource = Me.DefinitionControleBindingSource
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSteelBlue
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DefinitionControleDataGridView.DefaultCellStyle = DataGridViewCellStyle3
            Me.DefinitionControleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DefinitionControleDataGridView.Location = New System.Drawing.Point(0, 25)
            Me.DefinitionControleDataGridView.MultiSelect = False
            Me.DefinitionControleDataGridView.Name = "DefinitionControleDataGridView"
            Me.DefinitionControleDataGridView.ReadOnly = True
            Me.DefinitionControleDataGridView.RowHeadersVisible = False
            Me.DefinitionControleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.DefinitionControleDataGridView.Size = New System.Drawing.Size(593, 382)
            Me.DefinitionControleDataGridView.TabIndex = 1
            '
            'TypeColumn
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.NullValue = "Nothing"
            Me.TypeColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.TypeColumn.HeaderText = ""
            Me.TypeColumn.Name = "TypeColumn"
            Me.TypeColumn.ReadOnly = True
            Me.TypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.TypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.TypeColumn.Width = 20
            '
            'ColIdControle
            '
            Me.ColIdControle.DataPropertyName = "IdControle"
            Me.ColIdControle.HeaderText = "#"
            Me.ColIdControle.Name = "ColIdControle"
            Me.ColIdControle.ReadOnly = True
            Me.ColIdControle.Width = 30
            '
            'GroupeColumn
            '
            Me.GroupeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.GroupeColumn.DataPropertyName = "GroupeControle"
            Me.GroupeColumn.HeaderText = "Groupe"
            Me.GroupeColumn.Name = "GroupeColumn"
            Me.GroupeColumn.ReadOnly = True
            Me.GroupeColumn.Width = 67
            '
            'LibelleColumn
            '
            Me.LibelleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.LibelleColumn.DataPropertyName = "Libelle"
            Me.LibelleColumn.HeaderText = "Libelle"
            Me.LibelleColumn.Name = "LibelleColumn"
            Me.LibelleColumn.ReadOnly = True
            '
            'FrListeControles
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(593, 407)
            Me.ControlBox = False
            Me.Controls.Add(Me.DefinitionControleDataGridView)
            Me.Controls.Add(Me.DefinitionControleBindingNavigator)
            Me.Name = "FrListeControles"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Liste des contrôles"
            CType(Me.DefinitionControleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DefinitionControleBindingNavigator.ResumeLayout(False)
            Me.DefinitionControleBindingNavigator.PerformLayout()
            CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DefinitionControleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents DefinitionControleBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DefinitionControleBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents DefinitionControleDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents TbApercu As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents TypeColumn As System.Windows.Forms.DataGridViewImageColumn
        Friend WithEvents ColIdControle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents GroupeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents LibelleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MoveDownToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents MoveUpToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

    End Class
End Namespace