Namespace Fournisseurs
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeFourn
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeFourn))
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.FournBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.FournDataGridView = New System.Windows.Forms.DataGridView
            Me.Civilite = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BtFiltrer = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.TbClose = New System.Windows.Forms.ToolStripButton
            Me.TbSave = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.TbBR = New System.Windows.Forms.ToolStripButton
            Me.TbNewBR = New System.Windows.Forms.ToolStripButton
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FournDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SuspendLayout()
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'FournBindingSource
            '
            Me.FournBindingSource.DataMember = "Entreprise"
            Me.FournBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.FournBindingSource.Sort = "Nom"
            '
            'FournDataGridView
            '
            Me.FournDataGridView.AllowUserToAddRows = False
            Me.FournDataGridView.AllowUserToDeleteRows = False
            Me.FournDataGridView.AutoGenerateColumns = False
            Me.FournDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Civilite, Me.NomDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn})
            Me.FournDataGridView.DataSource = Me.FournBindingSource
            Me.FournDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FournDataGridView.Location = New System.Drawing.Point(0, 25)
            Me.FournDataGridView.MultiSelect = False
            Me.FournDataGridView.Name = "FournDataGridView"
            Me.FournDataGridView.ReadOnly = True
            Me.FournDataGridView.Size = New System.Drawing.Size(682, 363)
            Me.FournDataGridView.TabIndex = 1
            '
            'Civilite
            '
            Me.Civilite.DataPropertyName = "Civilite"
            Me.Civilite.HeaderText = "Civilite"
            Me.Civilite.Name = "Civilite"
            Me.Civilite.ReadOnly = True
            Me.Civilite.Width = 60
            '
            'NomDataGridViewTextBoxColumn
            '
            Me.NomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
            Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
            Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
            Me.NomDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CodePostalDataGridViewTextBoxColumn
            '
            Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "CodePostal"
            Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "CP"
            Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
            Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
            Me.CodePostalDataGridViewTextBoxColumn.Width = 60
            '
            'VilleDataGridViewTextBoxColumn
            '
            Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
            Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
            Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
            Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.FournBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtFiltrer, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbClose, Me.TbSave, Me.ToolStripSeparator1, Me.TbBR, Me.TbNewBR})
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
            'BtFiltrer
            '
            Me.BtFiltrer.Checked = True
            Me.BtFiltrer.CheckOnClick = True
            Me.BtFiltrer.CheckState = System.Windows.Forms.CheckState.Checked
            Me.BtFiltrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BtFiltrer.Image = Global.ControleTracabilite.My.Resources.Resources.filter
            Me.BtFiltrer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtFiltrer.Name = "BtFiltrer"
            Me.BtFiltrer.Size = New System.Drawing.Size(23, 22)
            Me.BtFiltrer.Text = "Fournisseurs actifs seulement"
            '
            'BindingNavigatorSeparator2
            '
            Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
            Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
            'TbSave
            '
            Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbSave.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbSave.Name = "TbSave"
            Me.TbSave.Size = New System.Drawing.Size(23, 22)
            Me.TbSave.Text = "Enregistrer"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'TbBR
            '
            Me.TbBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbBR.Image = Global.ControleTracabilite.My.Resources.Resources.liste
            Me.TbBR.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbBR.Name = "TbBR"
            Me.TbBR.Size = New System.Drawing.Size(23, 22)
            Me.TbBR.Text = "Afficher les bons de réception de ce fournisseur"
            '
            'TbNewBR
            '
            Me.TbNewBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbNewBR.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.TbNewBR.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbNewBR.Name = "TbNewBR"
            Me.TbNewBR.Size = New System.Drawing.Size(23, 22)
            Me.TbNewBR.Text = "Saisir un nouveau bon de réception"
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
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'FrListeFourn
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 388)
            Me.ControlBox = False
            Me.Controls.Add(Me.FournDataGridView)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrListeFourn"
            Me.Text = "Liste des Fournisseurs"
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FournDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents FournBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents FournDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents Civilite As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbBR As System.Windows.Forms.ToolStripButton
        Friend WithEvents BtFiltrer As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbNewBR As System.Windows.Forms.ToolStripButton
    End Class
End Namespace
