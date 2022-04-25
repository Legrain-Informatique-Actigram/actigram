Namespace Controles
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrDetailControle
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
            Dim GroupeControleLabel As System.Windows.Forms.Label
            Dim LibelleLabel As System.Windows.Forms.Label
            Dim TypeLabel As System.Windows.Forms.Label
            Me.ValeursDefautLabel = New System.Windows.Forms.Label
            Me.ValeursPossiblesLabel = New System.Windows.Forms.Label
            Me.GroupeControleTextBox = New System.Windows.Forms.TextBox
            Me.DefinitionControleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.LibelleTextBox = New System.Windows.Forms.TextBox
            Me.ValeursDefautTextBox = New System.Windows.Forms.TextBox
            Me.ValeursPossiblesTextBox = New System.Windows.Forms.TextBox
            Me.BaremesDataGridView = New System.Windows.Forms.DataGridView
            Me.NBaremeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Expression = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ResultatConformite = New System.Windows.Forms.DataGridViewCheckBoxColumn
            Me.CheminDoc = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ActionCorrective = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.BaremesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TypeComboBox = New System.Windows.Forms.ComboBox
            Me.ControleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.TbEnregistrer = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.TypeLabel2 = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.DefinitionControleTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
            Me.BaremeTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            GroupeControleLabel = New System.Windows.Forms.Label
            LibelleLabel = New System.Windows.Forms.Label
            TypeLabel = New System.Windows.Forms.Label
            CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BaremesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BaremesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ControleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ControleBindingNavigator.SuspendLayout()
            Me.GradientPanel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupeControleLabel
            '
            GroupeControleLabel.AutoSize = True
            GroupeControleLabel.Location = New System.Drawing.Point(8, 11)
            GroupeControleLabel.Name = "GroupeControleLabel"
            GroupeControleLabel.Size = New System.Drawing.Size(87, 13)
            GroupeControleLabel.TabIndex = 0
            GroupeControleLabel.Text = "Groupe Controle:"
            '
            'LibelleLabel
            '
            LibelleLabel.AutoSize = True
            LibelleLabel.Location = New System.Drawing.Point(8, 37)
            LibelleLabel.Name = "LibelleLabel"
            LibelleLabel.Size = New System.Drawing.Size(40, 13)
            LibelleLabel.TabIndex = 2
            LibelleLabel.Text = "Libellé:"
            '
            'TypeLabel
            '
            TypeLabel.AutoSize = True
            TypeLabel.Location = New System.Drawing.Point(8, 63)
            TypeLabel.Name = "TypeLabel"
            TypeLabel.Size = New System.Drawing.Size(34, 13)
            TypeLabel.TabIndex = 4
            TypeLabel.Text = "Type:"
            '
            'ValeursDefautLabel
            '
            Me.ValeursDefautLabel.AutoSize = True
            Me.ValeursDefautLabel.Location = New System.Drawing.Point(8, 92)
            Me.ValeursDefautLabel.Name = "ValeursDefautLabel"
            Me.ValeursDefautLabel.Size = New System.Drawing.Size(80, 13)
            Me.ValeursDefautLabel.TabIndex = 6
            Me.ValeursDefautLabel.Text = "Valeurs Defaut:"
            '
            'ValeursPossiblesLabel
            '
            Me.ValeursPossiblesLabel.AutoSize = True
            Me.ValeursPossiblesLabel.Location = New System.Drawing.Point(8, 118)
            Me.ValeursPossiblesLabel.Name = "ValeursPossiblesLabel"
            Me.ValeursPossiblesLabel.Size = New System.Drawing.Size(92, 13)
            Me.ValeursPossiblesLabel.TabIndex = 8
            Me.ValeursPossiblesLabel.Text = "Valeurs Possibles:"
            '
            'GroupeControleTextBox
            '
            Me.GroupeControleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupeControleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DefinitionControleBindingSource, "Groupe", True))
            Me.GroupeControleTextBox.Location = New System.Drawing.Point(106, 8)
            Me.GroupeControleTextBox.MaxLength = 255
            Me.GroupeControleTextBox.Name = "GroupeControleTextBox"
            Me.GroupeControleTextBox.Size = New System.Drawing.Size(362, 20)
            Me.GroupeControleTextBox.TabIndex = 1
            '
            'DefinitionControleBindingSource
            '
            Me.DefinitionControleBindingSource.DataMember = "DefinitionControle"
            Me.DefinitionControleBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'LibelleTextBox
            '
            Me.LibelleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DefinitionControleBindingSource, "Libelle", True))
            Me.LibelleTextBox.Location = New System.Drawing.Point(106, 34)
            Me.LibelleTextBox.MaxLength = 255
            Me.LibelleTextBox.Name = "LibelleTextBox"
            Me.LibelleTextBox.Size = New System.Drawing.Size(362, 20)
            Me.LibelleTextBox.TabIndex = 3
            '
            'ValeursDefautTextBox
            '
            Me.ValeursDefautTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ValeursDefautTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DefinitionControleBindingSource, "ValeursDefaut", True))
            Me.ValeursDefautTextBox.Location = New System.Drawing.Point(106, 89)
            Me.ValeursDefautTextBox.MaxLength = 255
            Me.ValeursDefautTextBox.Name = "ValeursDefautTextBox"
            Me.ValeursDefautTextBox.Size = New System.Drawing.Size(362, 20)
            Me.ValeursDefautTextBox.TabIndex = 7
            '
            'ValeursPossiblesTextBox
            '
            Me.ValeursPossiblesTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ValeursPossiblesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DefinitionControleBindingSource, "ValeursPossibles", True))
            Me.ValeursPossiblesTextBox.Location = New System.Drawing.Point(106, 115)
            Me.ValeursPossiblesTextBox.MaxLength = 255
            Me.ValeursPossiblesTextBox.Name = "ValeursPossiblesTextBox"
            Me.ValeursPossiblesTextBox.Size = New System.Drawing.Size(362, 20)
            Me.ValeursPossiblesTextBox.TabIndex = 9
            '
            'BaremesDataGridView
            '
            Me.BaremesDataGridView.AllowUserToAddRows = False
            Me.BaremesDataGridView.AutoGenerateColumns = False
            Me.BaremesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NBaremeDataGridViewTextBoxColumn, Me.Expression, Me.ResultatConformite, Me.CheminDoc, Me.ActionCorrective})
            Me.BaremesDataGridView.DataSource = Me.BaremesBindingSource
            Me.BaremesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BaremesDataGridView.Location = New System.Drawing.Point(3, 41)
            Me.BaremesDataGridView.Name = "BaremesDataGridView"
            Me.BaremesDataGridView.ReadOnly = True
            Me.BaremesDataGridView.Size = New System.Drawing.Size(473, 238)
            Me.BaremesDataGridView.TabIndex = 1
            '
            'NBaremeDataGridViewTextBoxColumn
            '
            Me.NBaremeDataGridViewTextBoxColumn.DataPropertyName = "nBareme"
            Me.NBaremeDataGridViewTextBoxColumn.HeaderText = "nBareme"
            Me.NBaremeDataGridViewTextBoxColumn.Name = "NBaremeDataGridViewTextBoxColumn"
            Me.NBaremeDataGridViewTextBoxColumn.ReadOnly = True
            Me.NBaremeDataGridViewTextBoxColumn.Visible = False
            '
            'Expression
            '
            Me.Expression.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.Expression.DataPropertyName = "Expression"
            Me.Expression.HeaderText = "Expression"
            Me.Expression.Name = "Expression"
            Me.Expression.ReadOnly = True
            Me.Expression.Width = 83
            '
            'ResultatConformite
            '
            Me.ResultatConformite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ResultatConformite.DataPropertyName = "ResultatConformite"
            Me.ResultatConformite.HeaderText = "Conformité"
            Me.ResultatConformite.Name = "ResultatConformite"
            Me.ResultatConformite.ReadOnly = True
            Me.ResultatConformite.Width = 63
            '
            'CheminDoc
            '
            Me.CheminDoc.DataPropertyName = "CheminDoc"
            Me.CheminDoc.HeaderText = "Document lié"
            Me.CheminDoc.Name = "CheminDoc"
            Me.CheminDoc.ReadOnly = True
            '
            'ActionCorrective
            '
            Me.ActionCorrective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ActionCorrective.DataPropertyName = "ActionCorrective"
            Me.ActionCorrective.HeaderText = "Action Corrective"
            Me.ActionCorrective.Name = "ActionCorrective"
            Me.ActionCorrective.ReadOnly = True
            '
            'BaremesBindingSource
            '
            Me.BaremesBindingSource.DataMember = "FK_Bareme_DefinitionControle"
            Me.BaremesBindingSource.DataSource = Me.DefinitionControleBindingSource
            '
            'TypeComboBox
            '
            Me.TypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.TypeComboBox.FormattingEnabled = True
            Me.TypeComboBox.ItemHeight = 17
            Me.TypeComboBox.Location = New System.Drawing.Point(106, 60)
            Me.TypeComboBox.Name = "TypeComboBox"
            Me.TypeComboBox.Size = New System.Drawing.Size(182, 23)
            Me.TypeComboBox.TabIndex = 5
            '
            'ControleBindingNavigator
            '
            Me.ControleBindingNavigator.AddNewItem = Nothing
            Me.ControleBindingNavigator.CountItem = Nothing
            Me.ControleBindingNavigator.DeleteItem = Nothing
            Me.ControleBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ControleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbEnregistrer, Me.TbFermer})
            Me.ControleBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.ControleBindingNavigator.MoveFirstItem = Nothing
            Me.ControleBindingNavigator.MoveLastItem = Nothing
            Me.ControleBindingNavigator.MoveNextItem = Nothing
            Me.ControleBindingNavigator.MovePreviousItem = Nothing
            Me.ControleBindingNavigator.Name = "ControleBindingNavigator"
            Me.ControleBindingNavigator.PositionItem = Nothing
            Me.ControleBindingNavigator.Size = New System.Drawing.Size(479, 25)
            Me.ControleBindingNavigator.TabIndex = 0
            Me.ControleBindingNavigator.Text = "BindingNavigator1"
            '
            'TbEnregistrer
            '
            Me.TbEnregistrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbEnregistrer.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.TbEnregistrer.Name = "TbEnregistrer"
            Me.TbEnregistrer.Size = New System.Drawing.Size(23, 22)
            Me.TbEnregistrer.Text = "Enregistrer les données"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.TypeComboBox)
            Me.GradientPanel1.Controls.Add(Me.TypeLabel2)
            Me.GradientPanel1.Controls.Add(GroupeControleLabel)
            Me.GradientPanel1.Controls.Add(Me.ValeursPossiblesTextBox)
            Me.GradientPanel1.Controls.Add(TypeLabel)
            Me.GradientPanel1.Controls.Add(Me.ValeursPossiblesLabel)
            Me.GradientPanel1.Controls.Add(Me.ValeursDefautTextBox)
            Me.GradientPanel1.Controls.Add(Me.ValeursDefautLabel)
            Me.GradientPanel1.Controls.Add(Me.LibelleTextBox)
            Me.GradientPanel1.Controls.Add(LibelleLabel)
            Me.GradientPanel1.Controls.Add(Me.GroupeControleTextBox)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(479, 155)
            Me.GradientPanel1.TabIndex = 1
            '
            'TypeLabel2
            '
            Me.TypeLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DefinitionControleBindingSource, "Type", True))
            Me.TypeLabel2.ForeColor = System.Drawing.Color.Black
            Me.TypeLabel2.Location = New System.Drawing.Point(113, 63)
            Me.TypeLabel2.Name = "TypeLabel2"
            Me.TypeLabel2.Size = New System.Drawing.Size(100, 16)
            Me.TypeLabel2.TabIndex = 11
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.BaremesDataGridView)
            Me.GroupBox1.Controls.Add(Me.BindingNavigator1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 180)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(479, 282)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Barèmes"
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.BaremesBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
            Me.BindingNavigator1.Location = New System.Drawing.Point(3, 16)
            Me.BindingNavigator1.MoveFirstItem = Nothing
            Me.BindingNavigator1.MoveLastItem = Nothing
            Me.BindingNavigator1.MoveNextItem = Nothing
            Me.BindingNavigator1.MovePreviousItem = Nothing
            Me.BindingNavigator1.Name = "BindingNavigator1"
            Me.BindingNavigator1.PositionItem = Nothing
            Me.BindingNavigator1.Size = New System.Drawing.Size(473, 25)
            Me.BindingNavigator1.TabIndex = 0
            Me.BindingNavigator1.Text = "BindingNavigator1"
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
            'DefinitionControleTableAdapter
            '
            Me.DefinitionControleTableAdapter.ClearBeforeFill = True
            '
            'BaremeTableAdapter
            '
            Me.BaremeTableAdapter.ClearBeforeFill = True
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "nBareme"
            Me.DataGridViewTextBoxColumn1.HeaderText = "nBareme"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "Expression"
            Me.DataGridViewTextBoxColumn2.HeaderText = "Expression"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "CheminDoc"
            Me.DataGridViewTextBoxColumn3.HeaderText = "Document lié"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "ActionCorrective"
            Me.DataGridViewTextBoxColumn4.HeaderText = "Action Corrective"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'FrDetailControle
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(479, 462)
            Me.ControlBox = False
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.ControleBindingNavigator)
            Me.Name = "FrDetailControle"
            Me.Text = "Propriétés du Contrôle"
            CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BaremesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BaremesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ControleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ControleBindingNavigator.ResumeLayout(False)
            Me.ControleBindingNavigator.PerformLayout()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents DefinitionControleBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents GroupeControleTextBox As System.Windows.Forms.TextBox
        Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ValeursDefautTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ValeursPossiblesTextBox As System.Windows.Forms.TextBox
        Friend WithEvents BaremesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BaremesDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ValeursDefautLabel As System.Windows.Forms.Label
        Friend WithEvents ValeursPossiblesLabel As System.Windows.Forms.Label
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents DefinitionControleTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
        Friend WithEvents BaremeTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
        Friend WithEvents ControleBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents TbEnregistrer As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TypeLabel2 As System.Windows.Forms.Label
        Friend WithEvents NBaremeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Expression As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ResultatConformite As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents CheminDoc As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActionCorrective As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
