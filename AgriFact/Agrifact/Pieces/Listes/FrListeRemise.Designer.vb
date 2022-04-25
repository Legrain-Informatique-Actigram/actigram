<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeRemise
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeRemise))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.RemiseBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.RemiseDataGridView = New System.Windows.Forms.DataGridView
        Me.RemiseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.ImprimerLaRemiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimerLaListeDesRemisesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbFiltrer = New System.Windows.Forms.ToolStripButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemiseTA = New AgriFact.DsPiecesTableAdapters.RemiseTA
        Me.BanqueTA = New AgriFact.DsPiecesTableAdapters.BanqueTA
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DateRemiseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomBanque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NRemiseBanqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeRemiseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExportCompta = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColFiller = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.RemiseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemiseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RemiseBindingNavigatorSaveItem
        '
        Me.RemiseBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RemiseBindingNavigatorSaveItem.Image = CType(resources.GetObject("RemiseBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.RemiseBindingNavigatorSaveItem.Name = "RemiseBindingNavigatorSaveItem"
        Me.RemiseBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.RemiseBindingNavigatorSaveItem.Text = "Enregistrer les données"
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
        'RemiseDataGridView
        '
        Me.RemiseDataGridView.AllowUserToAddRows = False
        Me.RemiseDataGridView.AllowUserToDeleteRows = False
        Me.RemiseDataGridView.AutoGenerateColumns = False
        Me.RemiseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.DateRemiseDataGridViewTextBoxColumn, Me.NomBanque, Me.NRemiseBanqueDataGridViewTextBoxColumn, Me.TypeRemiseDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn, Me.ExportCompta, Me.ColFiller})
        Me.RemiseDataGridView.DataSource = Me.RemiseBindingSource
        Me.RemiseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RemiseDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.RemiseDataGridView.Name = "RemiseDataGridView"
        Me.RemiseDataGridView.ReadOnly = True
        Me.RemiseDataGridView.Size = New System.Drawing.Size(575, 326)
        Me.RemiseDataGridView.TabIndex = 1
        '
        'RemiseBindingSource
        '
        Me.RemiseBindingSource.DataMember = "Remise"
        Me.RemiseBindingSource.DataSource = Me.DsPieces
        Me.RemiseBindingSource.Filter = "ExportCompta=False"
        Me.RemiseBindingSource.Sort = "DateRemise Desc"
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemiseBindingNavigatorSaveItem, Me.TbDelete, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.TbSearch, Me.TbClose, Me.TbFiltrer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(575, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerLaRemiseToolStripMenuItem, Me.ImprimerLaListeDesRemisesToolStripMenuItem})
        Me.ToolStripButton1.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ImprimerLaRemiseToolStripMenuItem
        '
        Me.ImprimerLaRemiseToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.ImprimerLaRemiseToolStripMenuItem.Name = "ImprimerLaRemiseToolStripMenuItem"
        Me.ImprimerLaRemiseToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ImprimerLaRemiseToolStripMenuItem.Text = "Imprimer la remise..."
        '
        'ImprimerLaListeDesRemisesToolStripMenuItem
        '
        Me.ImprimerLaListeDesRemisesToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.ImprimerLaListeDesRemisesToolStripMenuItem.Name = "ImprimerLaListeDesRemisesToolStripMenuItem"
        Me.ImprimerLaListeDesRemisesToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ImprimerLaListeDesRemisesToolStripMenuItem.Text = "Imprimer la liste des remises..."
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
        Me.TbFiltrer.Checked = True
        Me.TbFiltrer.CheckOnClick = True
        Me.TbFiltrer.CheckState = System.Windows.Forms.CheckState.Checked
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
        'RemiseTA
        '
        Me.RemiseTA.ClearBeforeFill = True
        '
        'BanqueTA
        '
        Me.BanqueTA.ClearBeforeFill = True
        '
        'ColSel
        '
        Me.ColSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColSel.HeaderText = ""
        Me.ColSel.Name = "ColSel"
        Me.ColSel.ReadOnly = True
        Me.ColSel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColSel.Width = 20
        '
        'DateRemiseDataGridViewTextBoxColumn
        '
        Me.DateRemiseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateRemiseDataGridViewTextBoxColumn.DataPropertyName = "DateRemise"
        DataGridViewCellStyle1.Format = "d"
        Me.DateRemiseDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateRemiseDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateRemiseDataGridViewTextBoxColumn.Name = "DateRemiseDataGridViewTextBoxColumn"
        Me.DateRemiseDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateRemiseDataGridViewTextBoxColumn.Width = 55
        '
        'NomBanque
        '
        Me.NomBanque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomBanque.DataPropertyName = "NomBanque"
        Me.NomBanque.HeaderText = "Banque"
        Me.NomBanque.Name = "NomBanque"
        Me.NomBanque.ReadOnly = True
        Me.NomBanque.Width = 69
        '
        'NRemiseBanqueDataGridViewTextBoxColumn
        '
        Me.NRemiseBanqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NRemiseBanqueDataGridViewTextBoxColumn.DataPropertyName = "nRemiseBanque"
        Me.NRemiseBanqueDataGridViewTextBoxColumn.HeaderText = "N° Remise"
        Me.NRemiseBanqueDataGridViewTextBoxColumn.Name = "NRemiseBanqueDataGridViewTextBoxColumn"
        Me.NRemiseBanqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.NRemiseBanqueDataGridViewTextBoxColumn.Width = 82
        '
        'TypeRemiseDataGridViewTextBoxColumn
        '
        Me.TypeRemiseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TypeRemiseDataGridViewTextBoxColumn.DataPropertyName = "TypeRemise"
        Me.TypeRemiseDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeRemiseDataGridViewTextBoxColumn.Name = "TypeRemiseDataGridViewTextBoxColumn"
        Me.TypeRemiseDataGridViewTextBoxColumn.ReadOnly = True
        Me.TypeRemiseDataGridViewTextBoxColumn.Width = 56
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "Montant"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'ExportCompta
        '
        Me.ExportCompta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ExportCompta.DataPropertyName = "ExportCompta"
        Me.ExportCompta.HeaderText = "Exporté"
        Me.ExportCompta.Name = "ExportCompta"
        Me.ExportCompta.ReadOnly = True
        Me.ExportCompta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExportCompta.Width = 50
        '
        'ColFiller
        '
        Me.ColFiller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColFiller.HeaderText = ""
        Me.ColFiller.Name = "ColFiller"
        Me.ColFiller.ReadOnly = True
        '
        'FrListeRemise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.RemiseDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeRemise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des remises bancaires"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RemiseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemiseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RemiseBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents RemiseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents RemiseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbFiltrer As System.Windows.Forms.ToolStripButton
    Friend WithEvents RemiseTA As AgriFact.DsPiecesTableAdapters.RemiseTA
    Friend WithEvents BanqueTA As AgriFact.DsPiecesTableAdapters.BanqueTA
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimerLaRemiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimerLaListeDesRemisesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DateRemiseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomBanque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRemiseBanqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeRemiseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportCompta As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColFiller As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
