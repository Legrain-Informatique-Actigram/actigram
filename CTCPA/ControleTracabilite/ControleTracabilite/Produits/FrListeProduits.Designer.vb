<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeProduits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeProduits))
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Me.ProduitDataGridView = New System.Windows.Forms.DataGridView
        Me.NomFamille = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ProduitVente = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FamilleTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.TbDupliquer = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbCompo = New System.Windows.Forms.ToolStripButton
        Me.TbControles = New System.Windows.Forms.ToolStripButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
        Me.ProduitBindingSource.Sort = "NomFamille,CodeProduit"
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'ProduitDataGridView
        '
        Me.ProduitDataGridView.AllowUserToAddRows = False
        Me.ProduitDataGridView.AllowUserToDeleteRows = False
        Me.ProduitDataGridView.AutoGenerateColumns = False
        Me.ProduitDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ProduitDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomFamille, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn6, Me.ProduitVente, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.ProduitDataGridView.DataSource = Me.ProduitBindingSource
        Me.ProduitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProduitDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ProduitDataGridView.MultiSelect = False
        Me.ProduitDataGridView.Name = "ProduitDataGridView"
        Me.ProduitDataGridView.ReadOnly = True
        Me.ProduitDataGridView.Size = New System.Drawing.Size(682, 363)
        Me.ProduitDataGridView.TabIndex = 1
        '
        'NomFamille
        '
        Me.NomFamille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomFamille.DataPropertyName = "NomFamille"
        Me.NomFamille.HeaderText = "Famille"
        Me.NomFamille.Name = "NomFamille"
        Me.NomFamille.ReadOnly = True
        Me.NomFamille.Width = 64
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CodeProduit"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 57
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn6
        '
        Me.DataGridViewCheckBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn6.DataPropertyName = "ProduitAchat"
        Me.DataGridViewCheckBoxColumn6.HeaderText = "MP"
        Me.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6"
        Me.DataGridViewCheckBoxColumn6.ReadOnly = True
        Me.DataGridViewCheckBoxColumn6.Width = 29
        '
        'ProduitVente
        '
        Me.ProduitVente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ProduitVente.DataPropertyName = "ProduitVente"
        Me.ProduitVente.HeaderText = "PF"
        Me.ProduitVente.Name = "ProduitVente"
        Me.ProduitVente.ReadOnly = True
        Me.ProduitVente.Width = 26
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Unite1"
        Me.DataGridViewTextBoxColumn10.HeaderText = "U1"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 46
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Unite2"
        Me.DataGridViewTextBoxColumn11.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 46
        '
        'FamilleTableAdapter
        '
        Me.FamilleTableAdapter.ClearBeforeFill = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.ProduitBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFilter, Me.BindingNavigatorSeparator2, Me.TbSave, Me.BindingNavigatorAddNewItem, Me.TbDupliquer, Me.BindingNavigatorDeleteItem, Me.TbClose, Me.ToolStripSeparator1, Me.TbCompo, Me.TbControles})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(682, 25)
        Me.BindingNavigator1.TabIndex = 3
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'TbFilter
        '
        Me.TbFilter.Checked = True
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.ControleTracabilite.My.Resources.Resources.filter
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 22)
        Me.TbFilter.Text = "Filtrer les produits actifs"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.ControleTracabilite.My.Resources.Resources._new
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'TbDupliquer
        '
        Me.TbDupliquer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDupliquer.Image = Global.ControleTracabilite.My.Resources.Resources.CopyHS
        Me.TbDupliquer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDupliquer.Name = "TbDupliquer"
        Me.TbDupliquer.Size = New System.Drawing.Size(23, 22)
        Me.TbDupliquer.Text = "Dupliquer le produit"
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
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.ControleTracabilite.My.Resources.Resources.close
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbCompo
        '
        Me.TbCompo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCompo.Image = Global.ControleTracabilite.My.Resources.Resources.compo
        Me.TbCompo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCompo.Name = "TbCompo"
        Me.TbCompo.Size = New System.Drawing.Size(23, 22)
        Me.TbCompo.Text = "Recette"
        '
        'TbControles
        '
        Me.TbControles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbControles.Image = Global.ControleTracabilite.My.Resources.Resources.controles
        Me.TbControles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbControles.Name = "TbControles"
        Me.TbControles.Size = New System.Drawing.Size(23, 22)
        Me.TbControles.Text = "Controles"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomFamille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unite1"
        Me.DataGridViewTextBoxColumn4.HeaderText = "U1"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
        Me.DataGridViewTextBoxColumn5.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'FrListeProduits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProduitDataGridView)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Name = "FrListeProduits"
        Me.Text = "Liste des Produits"
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents ProduitDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents FamilleTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbCompo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbControles As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents NomFamille As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ProduitVente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbDupliquer As System.Windows.Forms.ToolStripButton
End Class
