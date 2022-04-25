<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrUpdates
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.UpdatesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Niveau = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TailleFichier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsActiUpdates = New ActiUpdates.dsActiUpdates
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbAdd = New System.Windows.Forms.ToolStripButton
        Me.TbModif = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbTest = New System.Windows.Forms.ToolStripButton
        Me.UpdatesTableAdapter = New ActiUpdates.dsActiUpdatesTableAdapters.UpdatesTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.UpdatesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UpdatesDataGridView
        '
        Me.UpdatesDataGridView.AllowUserToAddRows = False
        Me.UpdatesDataGridView.AllowUserToDeleteRows = False
        Me.UpdatesDataGridView.AutoGenerateColumns = False
        Me.UpdatesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.Niveau, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn8, Me.TailleFichier, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn5})
        Me.UpdatesDataGridView.DataSource = Me.UpdatesBindingSource
        Me.UpdatesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdatesDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.UpdatesDataGridView.MultiSelect = False
        Me.UpdatesDataGridView.Name = "UpdatesDataGridView"
        Me.UpdatesDataGridView.ReadOnly = True
        Me.UpdatesDataGridView.RowHeadersWidth = 25
        Me.UpdatesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.UpdatesDataGridView.ShowEditingIcon = False
        Me.UpdatesDataGridView.Size = New System.Drawing.Size(654, 171)
        Me.UpdatesDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Version"
        DataGridViewCellStyle1.Format = "g"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.HeaderText = "Version"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 67
        '
        'Niveau
        '
        Me.Niveau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Niveau.HeaderText = "Niveau"
        Me.Niveau.Name = "Niveau"
        Me.Niveau.ReadOnly = True
        Me.Niveau.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Niveau.Width = 66
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Actif"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Actif"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 34
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DateFichier"
        DataGridViewCellStyle2.Format = "g"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 55
        '
        'TailleFichier
        '
        Me.TailleFichier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TailleFichier.HeaderText = "Taille"
        Me.TailleFichier.Name = "TailleFichier"
        Me.TailleFichier.ReadOnly = True
        Me.TailleFichier.Width = 57
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Description"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn6.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DownloadPath"
        DataGridViewCellStyle4.Format = "g"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fichier"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 63
        '
        'UpdatesBindingSource
        '
        Me.UpdatesBindingSource.DataMember = "Updates"
        Me.UpdatesBindingSource.DataSource = Me.DsActiUpdates
        Me.UpdatesBindingSource.Sort = "version desc"
        '
        'DsActiUpdates
        '
        Me.DsActiUpdates.DataSetName = "dsActiUpdates"
        Me.DsActiUpdates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbAdd, Me.TbModif, Me.TbSuppr, Me.ToolStripSeparator1, Me.TbTest})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(654, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbAdd
        '
        Me.TbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbAdd.Image = Global.ActiUpdates.My.Resources.Resources.crayon16
        Me.TbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbAdd.Name = "TbAdd"
        Me.TbAdd.Size = New System.Drawing.Size(23, 22)
        Me.TbAdd.Text = "Ajouter une mise à jour"
        '
        'TbModif
        '
        Me.TbModif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbModif.Image = Global.ActiUpdates.My.Resources.Resources.edit
        Me.TbModif.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbModif.Name = "TbModif"
        Me.TbModif.Size = New System.Drawing.Size(23, 22)
        Me.TbModif.Text = "Modifier"
        '
        'TbSuppr
        '
        Me.TbSuppr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuppr.Image = Global.ActiUpdates.My.Resources.Resources.suppr
        Me.TbSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuppr.Name = "TbSuppr"
        Me.TbSuppr.Size = New System.Drawing.Size(23, 22)
        Me.TbSuppr.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbTest
        '
        Me.TbTest.Image = Global.ActiUpdates.My.Resources.Resources.install
        Me.TbTest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbTest.Name = "TbTest"
        Me.TbTest.Size = New System.Drawing.Size(141, 22)
        Me.TbTest.Text = "Tester la mise à jour..."
        '
        'UpdatesTableAdapter
        '
        Me.UpdatesTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Version"
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn1.HeaderText = "Version"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Niveau"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'FrUpdates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 196)
        Me.Controls.Add(Me.UpdatesDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrUpdates"
        Me.Text = "Mises à jour"
        CType(Me.UpdatesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsActiUpdates As ActiUpdates.dsActiUpdates
    Friend WithEvents UpdatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UpdatesTableAdapter As ActiUpdates.dsActiUpdatesTableAdapters.UpdatesTableAdapter
    Friend WithEvents UpdatesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbModif As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbTest As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Niveau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TailleFichier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
