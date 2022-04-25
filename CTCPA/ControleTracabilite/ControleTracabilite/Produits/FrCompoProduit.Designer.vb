<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCompoProduit
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
        Dim CodeProduitLabel As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrCompoProduit))
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.lbUnit = New System.Windows.Forms.Label
        Me.TxtCoef = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LibelleLabel1 = New System.Windows.Forms.Label
        Me.MasterProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.CodeProduitLabel1 = New System.Windows.Forms.Label
        Me.CompositionProduitDataGridView = New System.Windows.Forms.DataGridView
        Me.CodeProduitComposition = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
        Me.LibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
        Me.LibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompositionProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbCreerMP = New System.Windows.Forms.ToolStripButton
        Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Me.CompositionProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.CompositionProduitTableAdapter
        CodeProduitLabel = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        CType(Me.MasterProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompositionProduitDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompositionProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CodeProduitLabel
        '
        CodeProduitLabel.AutoSize = True
        CodeProduitLabel.Location = New System.Drawing.Point(12, 13)
        CodeProduitLabel.Name = "CodeProduitLabel"
        CodeProduitLabel.Size = New System.Drawing.Size(71, 13)
        CodeProduitLabel.TabIndex = 0
        CodeProduitLabel.Text = "Code Produit:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(40, 45)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(40, 13)
        LibelleLabel.TabIndex = 2
        LibelleLabel.Text = "Libelle:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.lbUnit)
        Me.GradientPanel1.Controls.Add(Me.TxtCoef)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(LibelleLabel)
        Me.GradientPanel1.Controls.Add(Me.LibelleLabel1)
        Me.GradientPanel1.Controls.Add(CodeProduitLabel)
        Me.GradientPanel1.Controls.Add(Me.CodeProduitLabel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(654, 105)
        Me.GradientPanel1.TabIndex = 78
        '
        'lbUnit
        '
        Me.lbUnit.AutoSize = True
        Me.lbUnit.Location = New System.Drawing.Point(510, 74)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(71, 13)
        Me.lbUnit.TabIndex = 6
        Me.lbUnit.Text = "{0} de produit"
        '
        'TxtCoef
        '
        Me.TxtCoef.Location = New System.Drawing.Point(449, 71)
        Me.TxtCoef.Name = "TxtCoef"
        Me.TxtCoef.Size = New System.Drawing.Size(61, 20)
        Me.TxtCoef.TabIndex = 5
        Me.TxtCoef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(357, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Veuillez entrer les quantités de matière première nécessaires pour fabriquer"
        '
        'LibelleLabel1
        '
        Me.LibelleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LibelleLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MasterProduitBindingSource, "Libelle", True))
        Me.LibelleLabel1.Location = New System.Drawing.Point(89, 45)
        Me.LibelleLabel1.Name = "LibelleLabel1"
        Me.LibelleLabel1.Size = New System.Drawing.Size(544, 20)
        Me.LibelleLabel1.TabIndex = 3
        '
        'MasterProduitBindingSource
        '
        Me.MasterProduitBindingSource.DataMember = "Produit"
        Me.MasterProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CodeProduitLabel1
        '
        Me.CodeProduitLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodeProduitLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MasterProduitBindingSource, "CodeProduit", True))
        Me.CodeProduitLabel1.Location = New System.Drawing.Point(89, 13)
        Me.CodeProduitLabel1.Name = "CodeProduitLabel1"
        Me.CodeProduitLabel1.Size = New System.Drawing.Size(544, 21)
        Me.CodeProduitLabel1.TabIndex = 1
        '
        'CompositionProduitDataGridView
        '
        Me.CompositionProduitDataGridView.AutoGenerateColumns = False
        Me.CompositionProduitDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeProduitComposition, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.LibUnite1, Me.DataGridViewTextBoxColumn8, Me.LibUnite2})
        Me.CompositionProduitDataGridView.DataSource = Me.CompositionProduitBindingSource
        Me.CompositionProduitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionProduitDataGridView.Location = New System.Drawing.Point(0, 155)
        Me.CompositionProduitDataGridView.Name = "CompositionProduitDataGridView"
        Me.CompositionProduitDataGridView.Size = New System.Drawing.Size(654, 291)
        Me.CompositionProduitDataGridView.TabIndex = 78
        '
        'CodeProduitComposition
        '
        Me.CodeProduitComposition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitComposition.DataPropertyName = "CodeProduitComposition"
        Me.CodeProduitComposition.DataSource = Me.ProduitBindingSource
        Me.CodeProduitComposition.DisplayMember = "ProduitDisplay"
        Me.CodeProduitComposition.DisplayStyleForCurrentCellOnly = True
        Me.CodeProduitComposition.DropDownWidth = 400
        Me.CodeProduitComposition.HeaderText = "Produit"
        Me.CodeProduitComposition.Name = "CodeProduitComposition"
        Me.CodeProduitComposition.ValueMember = "CodeProduit"
        Me.CodeProduitComposition.Width = 46
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
        Me.ProduitBindingSource.Filter = "ProduitAchat=True"
        Me.ProduitBindingSource.Sort = "Libelle"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Unite1"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn6.HeaderText = "Qté U1"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.Width = 66
        '
        'LibUnite1
        '
        Me.LibUnite1.DataPropertyName = "LibUnite1"
        Me.LibUnite1.HeaderText = ""
        Me.LibUnite1.Name = "LibUnite1"
        Me.LibUnite1.ReadOnly = True
        Me.LibUnite1.Width = 30
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Unite2"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Qté U2"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.Width = 66
        '
        'LibUnite2
        '
        Me.LibUnite2.DataPropertyName = "LibUnite2"
        Me.LibUnite2.HeaderText = ""
        Me.LibUnite2.Name = "LibUnite2"
        Me.LibUnite2.ReadOnly = True
        Me.LibUnite2.Width = 30
        '
        'CompositionProduitBindingSource
        '
        Me.CompositionProduitBindingSource.AllowNew = True
        Me.CompositionProduitBindingSource.DataMember = "ProduitPereCompositionProduit"
        Me.CompositionProduitBindingSource.DataSource = Me.MasterProduitBindingSource
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem1
        Me.BindingNavigator1.BindingSource = Me.CompositionProduitBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem1
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem1})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 130)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(654, 25)
        Me.BindingNavigator1.TabIndex = 79
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem1
        '
        Me.BindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem1.Image = Global.ControleTracabilite.My.Resources.Resources._new
        Me.BindingNavigatorAddNewItem1.Name = "BindingNavigatorAddNewItem1"
        Me.BindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem1.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem1
        '
        Me.BindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem1.Image = CType(resources.GetObject("BindingNavigatorDeleteItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem1.Name = "BindingNavigatorDeleteItem1"
        Me.BindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem1.Text = "Supprimer"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbFermer, Me.ToolStripSeparator1, Me.TbCreerMP})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(654, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.ControleTracabilite.My.Resources.Resources.save
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbCreerMP
        '
        Me.TbCreerMP.Image = CType(resources.GetObject("TbCreerMP.Image"), System.Drawing.Image)
        Me.TbCreerMP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCreerMP.Name = "TbCreerMP"
        Me.TbCreerMP.Size = New System.Drawing.Size(171, 22)
        Me.TbCreerMP.Text = "Créer une matière première"
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'CompositionProduitTableAdapter
        '
        Me.CompositionProduitTableAdapter.ClearBeforeFill = True
        '
        'FrCompoProduit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(654, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.CompositionProduitDataGridView)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrCompoProduit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recette Transformation"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.MasterProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompositionProduitDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompositionProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents CompositionProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompositionProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.CompositionProduitTableAdapter
    Friend WithEvents CompositionProduitDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MasterProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LibelleLabel1 As System.Windows.Forms.Label
    Friend WithEvents CodeProduitLabel1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCoef As System.Windows.Forms.TextBox
    Friend WithEvents lbUnit As System.Windows.Forms.Label
    Friend WithEvents CodeProduitComposition As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As ControleTracabilite.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As ControleTracabilite.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbCreerMP As System.Windows.Forms.ToolStripButton
End Class
