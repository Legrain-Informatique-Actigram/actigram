<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRechLot
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
        Me.StocksDataSet = New ControleTracabilite.StocksDataSet
        Me.LotsProduitsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotsDataGridView = New System.Windows.Forms.DataGridView
        Me.NlotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TpDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TxRech = New System.Windows.Forms.ToolStripTextBox
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.LotsProduitsTA = New ControleTracabilite.StocksDataSetTableAdapters.LotsProduitsTA
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotsProduitsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LotsProduitsBindingSource
        '
        Me.LotsProduitsBindingSource.DataMember = "LotsProduits"
        Me.LotsProduitsBindingSource.DataSource = Me.StocksDataSet
        Me.LotsProduitsBindingSource.Sort = ""
        '
        'LotsDataGridView
        '
        Me.LotsDataGridView.AllowUserToAddRows = False
        Me.LotsDataGridView.AllowUserToDeleteRows = False
        Me.LotsDataGridView.AutoGenerateColumns = False
        Me.LotsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LotsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NlotDataGridViewTextBoxColumn, Me.DtDataGridViewTextBoxColumn, Me.TpDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn})
        Me.LotsDataGridView.DataSource = Me.LotsProduitsBindingSource
        Me.LotsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LotsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.LotsDataGridView.MultiSelect = False
        Me.LotsDataGridView.Name = "LotsDataGridView"
        Me.LotsDataGridView.ReadOnly = True
        Me.LotsDataGridView.Size = New System.Drawing.Size(492, 227)
        Me.LotsDataGridView.StandardTab = True
        Me.LotsDataGridView.TabIndex = 1
        '
        'NlotDataGridViewTextBoxColumn
        '
        Me.NlotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NlotDataGridViewTextBoxColumn.DataPropertyName = "nlot"
        Me.NlotDataGridViewTextBoxColumn.HeaderText = "Lot"
        Me.NlotDataGridViewTextBoxColumn.Name = "NlotDataGridViewTextBoxColumn"
        Me.NlotDataGridViewTextBoxColumn.ReadOnly = True
        Me.NlotDataGridViewTextBoxColumn.Width = 47
        '
        'DtDataGridViewTextBoxColumn
        '
        Me.DtDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DtDataGridViewTextBoxColumn.DataPropertyName = "Dt"
        DataGridViewCellStyle1.Format = "d"
        Me.DtDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DtDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DtDataGridViewTextBoxColumn.Name = "DtDataGridViewTextBoxColumn"
        Me.DtDataGridViewTextBoxColumn.ReadOnly = True
        Me.DtDataGridViewTextBoxColumn.Width = 55
        '
        'TpDataGridViewTextBoxColumn
        '
        Me.TpDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TpDataGridViewTextBoxColumn.DataPropertyName = "tp"
        Me.TpDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TpDataGridViewTextBoxColumn.Name = "TpDataGridViewTextBoxColumn"
        Me.TpDataGridViewTextBoxColumn.ReadOnly = True
        Me.TpDataGridViewTextBoxColumn.Width = 56
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
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
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TxRech})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TxRech
        '
        Me.TxRech.AcceptsReturn = True
        Me.TxRech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxRech.Margin = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.TxRech.Name = "TxRech"
        Me.TxRech.Size = New System.Drawing.Size(200, 25)
        Me.WatermarkProvider1.SetWatermark(Me.TxRech, "Rechercher")
        '
        'LotsProduitsTA
        '
        Me.LotsProduitsTA.ClearBeforeFill = True
        '
        'FrRechLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 252)
        Me.Controls.Add(Me.LotsDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrRechLot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rechercher un lot"
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotsProduitsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StocksDataSet As ControleTracabilite.StocksDataSet
    Friend WithEvents LotsProduitsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxRech As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents LotsProduitsTA As ControleTracabilite.StocksDataSetTableAdapters.LotsProduitsTA
    Friend WithEvents NlotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TpDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
