<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeLots
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.DupliquerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.TbTermine = New System.Windows.Forms.ToolStripButton
        Me.ReactiverLotTermineToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.TbTous = New System.Windows.Forms.ToolStripButton
        Me.TxRech = New System.Windows.Forms.ToolStripTextBox
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.LotDataGridView = New System.Windows.Forms.DataGridView
        Me.Termine = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.LotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.LotTA = New AgriFact.StocksDataSetTableAdapters.LotTA
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        CType(Me.LotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbNew, Me.DupliquerToolStripButton, Me.TbSuppr, Me.TbTermine, Me.ReactiverLotTermineToolStripButton, Me.ToolStripSeparator1, Me.TbClose, Me.TbImpr, Me.TbSearch, Me.TbTous, Me.TxRech})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(680, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbNew
        '
        Me.TbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNew.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNew.Name = "TbNew"
        Me.TbNew.Size = New System.Drawing.Size(23, 22)
        Me.TbNew.Text = "Nouveau lot"
        '
        'DupliquerToolStripButton
        '
        Me.DupliquerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DupliquerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.CopyHS
        Me.DupliquerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DupliquerToolStripButton.Name = "DupliquerToolStripButton"
        Me.DupliquerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DupliquerToolStripButton.Text = "Dupliquer"
        '
        'TbSuppr
        '
        Me.TbSuppr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuppr.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbSuppr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuppr.Name = "TbSuppr"
        Me.TbSuppr.Size = New System.Drawing.Size(23, 22)
        Me.TbSuppr.Text = "Supprimer"
        '
        'TbTermine
        '
        Me.TbTermine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbTermine.Image = Global.AgriFact.My.Resources.Resources.bloque
        Me.TbTermine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbTermine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbTermine.Name = "TbTermine"
        Me.TbTermine.Size = New System.Drawing.Size(23, 22)
        Me.TbTermine.Text = "Marquer le lot comme terminé"
        '
        'ReactiverLotTermineToolStripButton
        '
        Me.ReactiverLotTermineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ReactiverLotTermineToolStripButton.Image = Global.AgriFact.My.Resources.Resources.Removehyperlink
        Me.ReactiverLotTermineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReactiverLotTermineToolStripButton.Name = "ReactiverLotTermineToolStripButton"
        Me.ReactiverLotTermineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ReactiverLotTermineToolStripButton.Text = "Réactiver un lot terminé"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(23, 22)
        Me.TbImpr.Text = "Imprimer"
        '
        'TbSearch
        '
        Me.TbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSearch.Image = Global.AgriFact.My.Resources.Resources.search
        Me.TbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSearch.Name = "TbSearch"
        Me.TbSearch.Size = New System.Drawing.Size(23, 22)
        Me.TbSearch.Text = "Rechercher"
        '
        'TbTous
        '
        Me.TbTous.Checked = True
        Me.TbTous.CheckOnClick = True
        Me.TbTous.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbTous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbTous.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbTous.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbTous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbTous.Name = "TbTous"
        Me.TbTous.Size = New System.Drawing.Size(23, 22)
        Me.TbTous.Text = "Non terminés seulement"
        '
        'TxRech
        '
        Me.TxRech.Name = "TxRech"
        Me.TxRech.Size = New System.Drawing.Size(100, 25)
        Me.WatermarkProvider1.SetWatermark(Me.TxRech, "Rechercher")
        '
        'LotDataGridView
        '
        Me.LotDataGridView.AllowUserToAddRows = False
        Me.LotDataGridView.AllowUserToDeleteRows = False
        Me.LotDataGridView.AutoGenerateColumns = False
        Me.LotDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Termine, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn6})
        Me.LotDataGridView.DataSource = Me.LotBindingSource
        Me.LotDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LotDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.LotDataGridView.Name = "LotDataGridView"
        Me.LotDataGridView.ReadOnly = True
        Me.LotDataGridView.Size = New System.Drawing.Size(680, 402)
        Me.LotDataGridView.TabIndex = 2
        '
        'Termine
        '
        Me.Termine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Termine.DataPropertyName = "Termine"
        Me.Termine.HeaderText = "Terminé"
        Me.Termine.Name = "Termine"
        Me.Termine.ReadOnly = True
        Me.Termine.Width = 50
        '
        'LotBindingSource
        '
        Me.LotBindingSource.DataMember = "Lot"
        Me.LotBindingSource.DataSource = Me.StocksDataSet
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LotTA
        '
        Me.LotTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nLot"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° Lot"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 62
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DateCreation"
        DataGridViewCellStyle1.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 55
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Observations"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Observations"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'FrListeLots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 427)
        Me.ControlBox = False
        Me.Controls.Add(Me.LotDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeLots"
        Me.Text = "Liste des Lots"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.LotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbTous As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxRech As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents StocksDataSet As AgriFact.StocksDataSet
    Friend WithEvents LotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotTA As AgriFact.StocksDataSetTableAdapters.LotTA
    Friend WithEvents LotDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Termine As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbTermine As System.Windows.Forms.ToolStripButton
    Friend WithEvents DupliquerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReactiverLotTermineToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
