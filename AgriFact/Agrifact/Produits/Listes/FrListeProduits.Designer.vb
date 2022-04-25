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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EntrepriseBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.ProduitDataGridView = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbDupliquer = New System.Windows.Forms.ToolStripButton
        Me.TxRecherche = New System.Windows.Forms.ToolStripTextBox
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbMajBalance = New System.Windows.Forms.ToolStripButton
        Me.TbSaisieTarifs = New System.Windows.Forms.ToolStripButton
        Me.cbTarifs = New System.Windows.Forms.ToolStripComboBox
        Me.LbTarif = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.TbModifierCodeProduit = New System.Windows.Forms.ToolStripButton
        Me.TbFusionner = New System.Windows.Forms.ToolStripButton
        Me.WatermarkProvider = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.ProduitTA = New AgriFact.DsAgrifactTableAdapters.ProduitTA
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TarifTableAdapter = New AgriFact.DsAgrifactTableAdapters.TarifTableAdapter
        Me.FamilleTA = New AgriFact.DsAgrifactTableAdapters.FamilleTA
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Famille1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeProduitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixVHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixVTTCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.marque = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ProduitDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntrepriseBindingNavigatorSaveItem
        '
        Me.EntrepriseBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EntrepriseBindingNavigatorSaveItem.Image = CType(resources.GetObject("EntrepriseBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EntrepriseBindingNavigatorSaveItem.Name = "EntrepriseBindingNavigatorSaveItem"
        Me.EntrepriseBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 31)
        Me.EntrepriseBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(23, 31)
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
        Me.TbFilter.Size = New System.Drawing.Size(23, 31)
        Me.TbFilter.Text = "Tous"
        '
        'TbSearch
        '
        Me.TbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSearch.Image = Global.AgriFact.My.Resources.Resources.search
        Me.TbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSearch.Name = "TbSearch"
        Me.TbSearch.Size = New System.Drawing.Size(23, 31)
        Me.TbSearch.Text = "Rechercher..."
        '
        'ProduitDataGridView
        '
        Me.ProduitDataGridView.AllowUserToAddRows = False
        Me.ProduitDataGridView.AllowUserToDeleteRows = False
        Me.ProduitDataGridView.AutoGenerateColumns = False
        Me.ProduitDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.Famille1DataGridViewTextBoxColumn, Me.CodeProduitDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.PrixVHTDataGridViewTextBoxColumn, Me.PrixVTTCDataGridViewTextBoxColumn, Me.marque})
        Me.ProduitDataGridView.DataSource = Me.ProduitBindingSource
        Me.ProduitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProduitDataGridView.Location = New System.Drawing.Point(0, 34)
        Me.ProduitDataGridView.Name = "ProduitDataGridView"
        Me.ProduitDataGridView.ReadOnly = True
        Me.ProduitDataGridView.Size = New System.Drawing.Size(668, 317)
        Me.ProduitDataGridView.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntrepriseBindingNavigatorSaveItem, Me.TbNew, Me.TbDupliquer, Me.ToolStripSeparator1, Me.TbImpr, Me.TbSearch, Me.TbFilter, Me.TxRecherche, Me.TbClose, Me.ToolStripSeparator2, Me.TbMajBalance, Me.TbSaisieTarifs, Me.cbTarifs, Me.LbTarif, Me.ToolStripSeparator3, Me.TbModifierCodeProduit, Me.TbFusionner})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(668, 34)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbNew
        '
        Me.TbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNew.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNew.Name = "TbNew"
        Me.TbNew.Size = New System.Drawing.Size(23, 31)
        Me.TbNew.Text = "Nouveau"
        '
        'TbDupliquer
        '
        Me.TbDupliquer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDupliquer.Image = Global.AgriFact.My.Resources.Resources.CopyHS
        Me.TbDupliquer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDupliquer.Name = "TbDupliquer"
        Me.TbDupliquer.Size = New System.Drawing.Size(23, 31)
        Me.TbDupliquer.Text = "Dupliquer"
        '
        'TxRecherche
        '
        Me.TxRecherche.Name = "TxRecherche"
        Me.TxRecherche.Size = New System.Drawing.Size(100, 34)
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
        Me.TbClose.Size = New System.Drawing.Size(23, 31)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'TbMajBalance
        '
        Me.TbMajBalance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbMajBalance.Image = Global.AgriFact.My.Resources.Resources.Compta
        Me.TbMajBalance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMajBalance.Name = "TbMajBalance"
        Me.TbMajBalance.Size = New System.Drawing.Size(23, 31)
        Me.TbMajBalance.Text = "Envoi balance"
        '
        'TbSaisieTarifs
        '
        Me.TbSaisieTarifs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSaisieTarifs.Image = Global.AgriFact.My.Resources.Resources.Finance
        Me.TbSaisieTarifs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSaisieTarifs.Name = "TbSaisieTarifs"
        Me.TbSaisieTarifs.Size = New System.Drawing.Size(23, 31)
        Me.TbSaisieTarifs.Text = "Saisir les prix"
        '
        'cbTarifs
        '
        Me.cbTarifs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cbTarifs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarifs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbTarifs.Name = "cbTarifs"
        Me.cbTarifs.Size = New System.Drawing.Size(121, 34)
        '
        'LbTarif
        '
        Me.LbTarif.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LbTarif.Name = "LbTarif"
        Me.LbTarif.Size = New System.Drawing.Size(37, 31)
        Me.LbTarif.Text = "Tarif :"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'TbModifierCodeProduit
        '
        Me.TbModifierCodeProduit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbModifierCodeProduit.Image = Global.AgriFact.My.Resources.Resources.EditTableHS
        Me.TbModifierCodeProduit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbModifierCodeProduit.Name = "TbModifierCodeProduit"
        Me.TbModifierCodeProduit.Size = New System.Drawing.Size(23, 31)
        Me.TbModifierCodeProduit.Text = "ToolStripButton1"
        Me.TbModifierCodeProduit.ToolTipText = "Modifier le code produit"
        '
        'TbFusionner
        '
        Me.TbFusionner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFusionner.Image = Global.AgriFact.My.Resources.Resources.SychronizeListHS
        Me.TbFusionner.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFusionner.Name = "TbFusionner"
        Me.TbFusionner.Size = New System.Drawing.Size(23, 31)
        Me.TbFusionner.Text = "Fusionner produits"
        Me.TbFusionner.ToolTipText = "Fusionner produits"
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PrixVTTC"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Prix TTC"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProduitTA
        '
        Me.ProduitTA.ClearBeforeFill = True
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "Tarif"
        Me.TarifBindingSource.DataSource = Me.DsAgrifact
        '
        'TarifTableAdapter
        '
        Me.TarifTableAdapter.ClearBeforeFill = True
        '
        'FamilleTA
        '
        Me.FamilleTA.ClearBeforeFill = True
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
        'Famille1DataGridViewTextBoxColumn
        '
        Me.Famille1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Famille1DataGridViewTextBoxColumn.DataPropertyName = "NomFamille"
        Me.Famille1DataGridViewTextBoxColumn.HeaderText = "Famille"
        Me.Famille1DataGridViewTextBoxColumn.Name = "Famille1DataGridViewTextBoxColumn"
        Me.Famille1DataGridViewTextBoxColumn.ReadOnly = True
        Me.Famille1DataGridViewTextBoxColumn.Width = 64
        '
        'CodeProduitDataGridViewTextBoxColumn
        '
        Me.CodeProduitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitDataGridViewTextBoxColumn.DataPropertyName = "CodeProduit"
        Me.CodeProduitDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.CodeProduitDataGridViewTextBoxColumn.Name = "CodeProduitDataGridViewTextBoxColumn"
        Me.CodeProduitDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodeProduitDataGridViewTextBoxColumn.Width = 57
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Produit"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrixVHTDataGridViewTextBoxColumn
        '
        Me.PrixVHTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixVHTDataGridViewTextBoxColumn.DataPropertyName = "PrixVHT"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        Me.PrixVHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.PrixVHTDataGridViewTextBoxColumn.HeaderText = "Prix HT"
        Me.PrixVHTDataGridViewTextBoxColumn.Name = "PrixVHTDataGridViewTextBoxColumn"
        Me.PrixVHTDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixVHTDataGridViewTextBoxColumn.Width = 67
        '
        'PrixVTTCDataGridViewTextBoxColumn
        '
        Me.PrixVTTCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixVTTCDataGridViewTextBoxColumn.DataPropertyName = "PrixVTTC"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.PrixVTTCDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrixVTTCDataGridViewTextBoxColumn.HeaderText = "Prix TTC"
        Me.PrixVTTCDataGridViewTextBoxColumn.Name = "PrixVTTCDataGridViewTextBoxColumn"
        Me.PrixVTTCDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixVTTCDataGridViewTextBoxColumn.Width = 73
        '
        'marque
        '
        Me.marque.DataPropertyName = "marque"
        Me.marque.HeaderText = "Marque"
        Me.marque.Name = "marque"
        Me.marque.ReadOnly = True
        '
        'FrListeProduits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProduitDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeProduits"
        Me.Text = "Liste des produits"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ProduitDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsAgrifact As AgriFact.DsAgrifact
    Friend WithEvents EntrepriseBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProduitDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbMajBalance As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSaisieTarifs As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDupliquer As System.Windows.Forms.ToolStripButton
    Friend WithEvents LbTarif As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbTarifs As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTA As AgriFact.DsAgrifactTableAdapters.ProduitTA
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TarifTableAdapter As AgriFact.DsAgrifactTableAdapters.TarifTableAdapter
    Friend WithEvents FamilleTA As AgriFact.DsAgrifactTableAdapters.FamilleTA
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbModifierCodeProduit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFusionner As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Famille1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixVHTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixVTTCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marque As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
