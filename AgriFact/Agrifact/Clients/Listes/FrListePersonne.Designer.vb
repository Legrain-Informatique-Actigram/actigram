<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListePersonne
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListePersonne))
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.EntrepriseBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.PersonneDataGridView = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TxRecherche = New System.Windows.Forms.ToolStripTextBox
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.WatermarkProvider = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PersonneTA = New AgriFact.DsAgrifactTableAdapters.PersonneTA
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fonction = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypePersonne = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PersonneBindingSource
        '
        Me.PersonneBindingSource.DataMember = "Personne"
        Me.PersonneBindingSource.DataSource = Me.DsAgrifact
        Me.PersonneBindingSource.Sort = "Nom"
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
        'PersonneDataGridView
        '
        Me.PersonneDataGridView.AllowUserToAddRows = False
        Me.PersonneDataGridView.AllowUserToDeleteRows = False
        Me.PersonneDataGridView.AutoGenerateColumns = False
        Me.PersonneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.DataGridViewTextBoxColumn9, Me.Prenom, Me.Fonction, Me.TypePersonne, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.PersonneDataGridView.DataSource = Me.PersonneBindingSource
        Me.PersonneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonneDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PersonneDataGridView.Name = "PersonneDataGridView"
        Me.PersonneDataGridView.ReadOnly = True
        Me.PersonneDataGridView.Size = New System.Drawing.Size(575, 326)
        Me.PersonneDataGridView.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntrepriseBindingNavigatorSaveItem, Me.TbNew, Me.TbDelete, Me.ToolStripSeparator1, Me.TbImpr, Me.TbSearch, Me.TbFilter, Me.TxRecherche, Me.TbClose})
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
        'PersonneTA
        '
        Me.PersonneTA.ClearBeforeFill = True
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
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'Prenom
        '
        Me.Prenom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Prenom.DataPropertyName = "Prenom"
        Me.Prenom.HeaderText = "Prenom"
        Me.Prenom.Name = "Prenom"
        Me.Prenom.ReadOnly = True
        Me.Prenom.Width = 68
        '
        'Fonction
        '
        Me.Fonction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Fonction.DataPropertyName = "Fonction"
        Me.Fonction.HeaderText = "Fonction"
        Me.Fonction.Name = "Fonction"
        Me.Fonction.ReadOnly = True
        Me.Fonction.Width = 73
        '
        'TypePersonne
        '
        Me.TypePersonne.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TypePersonne.DataPropertyName = "TypeClient"
        Me.TypePersonne.HeaderText = "Type"
        Me.TypePersonne.Name = "TypePersonne"
        Me.TypePersonne.ReadOnly = True
        Me.TypePersonne.Width = 56
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
        'FrListePersonne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.PersonneDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListePersonne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des contacts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As AgriFact.DsAgrifact
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PersonneDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents PersonneTA As AgriFact.DsAgrifactTableAdapters.PersonneTA
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prenom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fonction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypePersonne As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
