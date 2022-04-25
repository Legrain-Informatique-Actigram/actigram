<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeBanque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeBanque))
        Me.BanqueBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.BanqueDataGridView = New System.Windows.Forms.DataGridView
        Me.NCompteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BanqueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbFiltrer = New System.Windows.Forms.ToolStripButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BanqueTA = New AgriFact.DsPiecesTableAdapters.BanqueTA
        CType(Me.BanqueDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BanqueBindingNavigatorSaveItem
        '
        Me.BanqueBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BanqueBindingNavigatorSaveItem.Image = CType(resources.GetObject("BanqueBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.BanqueBindingNavigatorSaveItem.Name = "BanqueBindingNavigatorSaveItem"
        Me.BanqueBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.BanqueBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbSearch
        '
        Me.TbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSearch.Image = Global.AgriFact.My.Resources.Resources.search
        Me.TbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSearch.Name = "TbSearch"
        Me.TbSearch.Size = New System.Drawing.Size(23, 22)
        Me.TbSearch.Text = "Rechercher..."
        '
        'BanqueDataGridView
        '
        Me.BanqueDataGridView.AllowUserToAddRows = False
        Me.BanqueDataGridView.AllowUserToDeleteRows = False
        Me.BanqueDataGridView.AutoGenerateColumns = False
        Me.BanqueDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NCompteDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn})
        Me.BanqueDataGridView.DataSource = Me.BanqueBindingSource
        Me.BanqueDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BanqueDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.BanqueDataGridView.Name = "BanqueDataGridView"
        Me.BanqueDataGridView.ReadOnly = True
        Me.BanqueDataGridView.Size = New System.Drawing.Size(575, 326)
        Me.BanqueDataGridView.TabIndex = 1
        '
        'NCompteDataGridViewTextBoxColumn
        '
        Me.NCompteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NCompteDataGridViewTextBoxColumn.DataPropertyName = "NCompte"
        Me.NCompteDataGridViewTextBoxColumn.HeaderText = "Compte"
        Me.NCompteDataGridViewTextBoxColumn.Name = "NCompteDataGridViewTextBoxColumn"
        Me.NCompteDataGridViewTextBoxColumn.ReadOnly = True
        Me.NCompteDataGridViewTextBoxColumn.Width = 68
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BanqueBindingSource
        '
        Me.BanqueBindingSource.DataMember = "Banque"
        Me.BanqueBindingSource.DataSource = Me.DsPieces
        Me.BanqueBindingSource.Sort = "Libelle"
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BanqueBindingNavigatorSaveItem, Me.TbNew, Me.TbDelete, Me.ToolStripSeparator1, Me.TbSearch, Me.TbClose, Me.TbFiltrer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(575, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbNew
        '
        Me.TbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNew.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNew.Name = "TbNew"
        Me.TbNew.Size = New System.Drawing.Size(23, 22)
        Me.TbNew.Text = "Nouveau"
        '
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(23, 22)
        Me.TbDelete.Text = "Supprimer"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'TbFiltrer
        '
        Me.TbFiltrer.CheckOnClick = True
        Me.TbFiltrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFiltrer.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbFiltrer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFiltrer.Name = "TbFiltrer"
        Me.TbFiltrer.Size = New System.Drawing.Size(23, 22)
        Me.TbFiltrer.Text = "Appliquer le filtre"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Civilite"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Civ."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CodePostal"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Code Postal"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'BanqueTA
        '
        Me.BanqueTA.ClearBeforeFill = True
        '
        'FrListeBanque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.BanqueDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeBanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des comptes bancaires"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BanqueDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BanqueBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BanqueDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents BanqueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BanqueTA As AgriFact.DsPiecesTableAdapters.BanqueTA
    Friend WithEvents NCompteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbFiltrer As System.Windows.Forms.ToolStripButton
End Class
