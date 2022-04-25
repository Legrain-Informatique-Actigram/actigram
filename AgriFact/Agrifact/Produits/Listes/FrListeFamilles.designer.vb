<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeFamilles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeFamilles))
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FamilleDataGridView = New System.Windows.Forms.DataGridView
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FamilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FamilleTA = New AgriFact.DsAgrifactTableAdapters.FamilleTA
        Me.FamilleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbProduits = New System.Windows.Forms.ToolStripButton
        Me.TbEnvoiBalance = New System.Windows.Forms.ToolStripButton
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FamilleBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FamilleBindingSource
        '
        Me.FamilleBindingSource.DataMember = "Famille"
        Me.FamilleBindingSource.DataSource = Me.DsAgrifact
        Me.FamilleBindingSource.Sort = "Famille"
        '
        'FamilleDataGridView
        '
        Me.FamilleDataGridView.AutoGenerateColumns = False
        Me.FamilleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.FamilleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.FamilleDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn})
        Me.FamilleDataGridView.DataSource = Me.FamilleBindingSource
        Me.FamilleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FamilleDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.FamilleDataGridView.Name = "FamilleDataGridView"
        Me.FamilleDataGridView.Size = New System.Drawing.Size(682, 363)
        Me.FamilleDataGridView.TabIndex = 1
        '
        'ColSel
        '
        Me.ColSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColSel.HeaderText = ""
        Me.ColSel.Name = "ColSel"
        Me.ColSel.Width = 20
        '
        'FamilleDataGridViewTextBoxColumn
        '
        Me.FamilleDataGridViewTextBoxColumn.DataPropertyName = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.HeaderText = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.MaxInputLength = 255
        Me.FamilleDataGridViewTextBoxColumn.Name = "FamilleDataGridViewTextBoxColumn"
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'FamilleTA
        '
        Me.FamilleTA.ClearBeforeFill = True
        '
        'FamilleBindingNavigator
        '
        Me.FamilleBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.FamilleBindingNavigator.BindingSource = Me.FamilleBindingSource
        Me.FamilleBindingNavigator.CountItem = Nothing
        Me.FamilleBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.FamilleBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.FamilleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbFermer, Me.ToolStripSeparator1, Me.TbImpr, Me.TbProduits, Me.TbEnvoiBalance})
        Me.FamilleBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.FamilleBindingNavigator.MoveFirstItem = Nothing
        Me.FamilleBindingNavigator.MoveLastItem = Nothing
        Me.FamilleBindingNavigator.MoveNextItem = Nothing
        Me.FamilleBindingNavigator.MovePreviousItem = Nothing
        Me.FamilleBindingNavigator.Name = "FamilleBindingNavigator"
        Me.FamilleBindingNavigator.PositionItem = Nothing
        Me.FamilleBindingNavigator.Size = New System.Drawing.Size(682, 25)
        Me.FamilleBindingNavigator.TabIndex = 3
        Me.FamilleBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.AgriFact.My.Resources.Resources.new16
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
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.AgriFact.My.Resources.Resources.close16
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
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(23, 22)
        Me.TbImpr.Text = "Imprimer la liste des produits"
        '
        'TbProduits
        '
        Me.TbProduits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbProduits.Image = Global.AgriFact.My.Resources.Resources.Cube
        Me.TbProduits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbProduits.Name = "TbProduits"
        Me.TbProduits.Size = New System.Drawing.Size(23, 22)
        Me.TbProduits.Text = "Produits"
        '
        'TbEnvoiBalance
        '
        Me.TbEnvoiBalance.Image = Global.AgriFact.My.Resources.Resources.Compta
        Me.TbEnvoiBalance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbEnvoiBalance.Name = "TbEnvoiBalance"
        Me.TbEnvoiBalance.Size = New System.Drawing.Size(100, 22)
        Me.TbEnvoiBalance.Text = "Envoi balance"
        '
        'FrListeFamilles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.FamilleDataGridView)
        Me.Controls.Add(Me.FamilleBindingNavigator)
        Me.Name = "FrListeFamilles"
        Me.Text = "Liste des Familles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FamilleBindingNavigator.ResumeLayout(False)
        Me.FamilleBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As DsAgrifact
    Friend WithEvents FamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamilleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents FamilleTA As DsAgrifactTableAdapters.FamilleTA
    Friend WithEvents FamilleBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbProduits As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbEnvoiBalance As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FamilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
