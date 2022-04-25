<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeClient))
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.EntrepriseBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.EntrepriseDataGridView = New System.Windows.Forms.DataGridView
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.TbFusionner = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TxRecherche = New System.Windows.Forms.ToolStripTextBox
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.WatermarkProvider = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.EntrepriseTA = New AgriFact.DsAgrifactTableAdapters.EntrepriseTA
        Me.export_excel = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.DsAgrifact
        Me.EntrepriseBindingSource.Sort = "Nom"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EntrepriseBindingNavigatorSaveItem
        '
        Me.EntrepriseBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EntrepriseBindingNavigatorSaveItem.Image = CType(resources.GetObject("EntrepriseBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EntrepriseBindingNavigatorSaveItem.Name = "EntrepriseBindingNavigatorSaveItem"
        Me.EntrepriseBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.EntrepriseBindingNavigatorSaveItem.Text = "Enregistrer les données"
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
        Me.TbImpr.Text = "Imprimer la liste"
        '
        'TbFilter
        '
        Me.TbFilter.Checked = True
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 22)
        Me.TbFilter.Text = "Tous"
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
        'EntrepriseDataGridView
        '
        Me.EntrepriseDataGridView.AllowUserToAddRows = False
        Me.EntrepriseDataGridView.AllowUserToDeleteRows = False
        Me.EntrepriseDataGridView.AutoGenerateColumns = False
        Me.EntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.Pays})
        Me.EntrepriseDataGridView.DataSource = Me.EntrepriseBindingSource
        Me.EntrepriseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EntrepriseDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.EntrepriseDataGridView.Name = "EntrepriseDataGridView"
        Me.EntrepriseDataGridView.ReadOnly = True
        Me.EntrepriseDataGridView.Size = New System.Drawing.Size(575, 326)
        Me.EntrepriseDataGridView.TabIndex = 1
        '
        'ColSel
        '
        Me.ColSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColSel.HeaderText = "Sel."
        Me.ColSel.Name = "ColSel"
        Me.ColSel.ReadOnly = True
        Me.ColSel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColSel.Width = 31
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "Civilite"
        Me.DataGridViewTextBoxColumn40.HeaderText = "Civ."
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        Me.DataGridViewTextBoxColumn40.Width = 50
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CodePostal"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Code Postal"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 89
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 51
        '
        'Pays
        '
        Me.Pays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Pays.DataPropertyName = "Pays"
        Me.Pays.HeaderText = "Pays"
        Me.Pays.Name = "Pays"
        Me.Pays.ReadOnly = True
        Me.Pays.Width = 55
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntrepriseBindingNavigatorSaveItem, Me.TbNew, Me.TbDelete, Me.ToolStripSeparator1, Me.TbImpr, Me.ToolStripSeparator3, Me.TbFusionner, Me.ToolStripSeparator2, Me.TbSearch, Me.TbFilter, Me.TxRecherche, Me.TbClose, Me.ToolStripSeparator4})
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TbFusionner
        '
        Me.TbFusionner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFusionner.Image = Global.AgriFact.My.Resources.Resources.SychronizeListHS
        Me.TbFusionner.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFusionner.Name = "TbFusionner"
        Me.TbFusionner.Size = New System.Drawing.Size(23, 22)
        Me.TbFusionner.Text = "ToolStripButton1"
        Me.TbFusionner.ToolTipText = "Fusionner tiers"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TxRecherche
        '
        Me.TxRecherche.Name = "TxRecherche"
        Me.TxRecherche.Size = New System.Drawing.Size(100, 25)
        Me.WatermarkProvider.SetWatermark(Me.TxRecherche, "Rechercher")
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'EntrepriseTA
        '
        Me.EntrepriseTA.ClearBeforeFill = True
        '
        'export_excel
        '
        Me.export_excel.Image = Global.AgriFact.My.Resources.Resources.exportcsv
        Me.export_excel.Location = New System.Drawing.Point(290, 0)
        Me.export_excel.Name = "export_excel"
        Me.export_excel.Size = New System.Drawing.Size(25, 25)
        Me.export_excel.TabIndex = 3
        Me.export_excel.UseVisualStyleBackColor = True
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
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Pays"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Pays"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'FrListeClient
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(575, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.export_excel)
        Me.Controls.Add(Me.EntrepriseDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrListeClient"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As AgriFact.DsAgrifact
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseTA As AgriFact.DsAgrifactTableAdapters.EntrepriseTA
    Friend WithEvents EntrepriseBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents EntrepriseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxRecherche As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbFusionner As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents export_excel As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
