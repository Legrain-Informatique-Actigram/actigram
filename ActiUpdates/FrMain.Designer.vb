<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrMain))
        Me.DsActiUpdates = New ActiUpdates.dsActiUpdates
        Me.ApplicationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ApplicationsTableAdapter = New ActiUpdates.dsActiUpdatesTableAdapters.ApplicationsTableAdapter
        Me.ApplicationsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbUpdates = New System.Windows.Forms.ToolStripButton
        Me.TbParametres = New System.Windows.Forms.ToolStripButton
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsActiUpdates
        '
        Me.DsActiUpdates.DataSetName = "dsActiUpdates"
        Me.DsActiUpdates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ApplicationsBindingSource
        '
        Me.ApplicationsBindingSource.DataMember = "Applications"
        Me.ApplicationsBindingSource.DataSource = Me.DsActiUpdates
        '
        'ApplicationsTableAdapter
        '
        Me.ApplicationsTableAdapter.ClearBeforeFill = True
        '
        'ApplicationsDataGridView
        '
        Me.ApplicationsDataGridView.AllowUserToDeleteRows = False
        Me.ApplicationsDataGridView.AutoGenerateColumns = False
        Me.ApplicationsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.ApplicationsDataGridView.DataSource = Me.ApplicationsBindingSource
        Me.ApplicationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ApplicationsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ApplicationsDataGridView.Name = "ApplicationsDataGridView"
        Me.ApplicationsDataGridView.Size = New System.Drawing.Size(519, 234)
        Me.ApplicationsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 54
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbUpdates, Me.TbParametres})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(519, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.ActiUpdates.My.Resources.Resources.save
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer les modifications"
        '
        'TbUpdates
        '
        Me.TbUpdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbUpdates.Image = Global.ActiUpdates.My.Resources.Resources.VSObject_Properties
        Me.TbUpdates.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbUpdates.Name = "TbUpdates"
        Me.TbUpdates.Size = New System.Drawing.Size(23, 22)
        Me.TbUpdates.Text = "Afficher les mises à jour"
        '
        'TbParametres
        '
        Me.TbParametres.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbParametres.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbParametres.Image = Global.ActiUpdates.My.Resources.Resources.outils
        Me.TbParametres.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbParametres.Name = "TbParametres"
        Me.TbParametres.Size = New System.Drawing.Size(23, 22)
        Me.TbParametres.Text = "Paramètres"
        '
        'FrMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 259)
        Me.Controls.Add(Me.ApplicationsDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrMain"
        Me.Text = "Applications"
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsActiUpdates As ActiUpdates.dsActiUpdates
    Friend WithEvents ApplicationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ApplicationsTableAdapter As ActiUpdates.dsActiUpdatesTableAdapters.ApplicationsTableAdapter
    Friend WithEvents ApplicationsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbUpdates As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbParametres As System.Windows.Forms.ToolStripButton

End Class
