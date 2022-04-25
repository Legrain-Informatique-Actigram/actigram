<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeChoix
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
        Me.PubDataSet = New AgriFact.PubDataSet
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListeChoixTableAdapter = New AgriFact.PubDataSetTableAdapters.ListeChoixTableAdapter
        Me.ListeChoixDataGridView = New System.Windows.Forms.DataGridView
        Me.NomChoixDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NOrdreValeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomChampsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LargeurChampsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NImageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PubDataSet
        '
        Me.PubDataSet.DataSetName = "DsAgrifact"
        Me.PubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListeChoixBindingSource
        '
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.DataSource = Me.PubDataSet
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'ListeChoixDataGridView
        '
        Me.ListeChoixDataGridView.AutoGenerateColumns = False
        Me.ListeChoixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListeChoixDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomChoixDataGridViewTextBoxColumn, Me.NOrdreValeurDataGridViewTextBoxColumn, Me.ValeurDataGridViewTextBoxColumn, Me.NomChampsDataGridViewTextBoxColumn, Me.LargeurChampsDataGridViewTextBoxColumn, Me.NImageDataGridViewTextBoxColumn})
        Me.ListeChoixDataGridView.DataSource = Me.ListeChoixBindingSource
        Me.ListeChoixDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListeChoixDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ListeChoixDataGridView.Name = "ListeChoixDataGridView"
        Me.ListeChoixDataGridView.Size = New System.Drawing.Size(317, 328)
        Me.ListeChoixDataGridView.TabIndex = 0
        '
        'NomChoixDataGridViewTextBoxColumn
        '
        Me.NomChoixDataGridViewTextBoxColumn.DataPropertyName = "NomChoix"
        Me.NomChoixDataGridViewTextBoxColumn.HeaderText = "NomChoix"
        Me.NomChoixDataGridViewTextBoxColumn.Name = "NomChoixDataGridViewTextBoxColumn"
        Me.NomChoixDataGridViewTextBoxColumn.Visible = False
        '
        'NOrdreValeurDataGridViewTextBoxColumn
        '
        Me.NOrdreValeurDataGridViewTextBoxColumn.DataPropertyName = "nOrdreValeur"
        Me.NOrdreValeurDataGridViewTextBoxColumn.HeaderText = "nOrdreValeur"
        Me.NOrdreValeurDataGridViewTextBoxColumn.Name = "NOrdreValeurDataGridViewTextBoxColumn"
        Me.NOrdreValeurDataGridViewTextBoxColumn.Visible = False
        '
        'ValeurDataGridViewTextBoxColumn
        '
        Me.ValeurDataGridViewTextBoxColumn.DataPropertyName = "Valeur"
        Me.ValeurDataGridViewTextBoxColumn.HeaderText = "Valeur"
        Me.ValeurDataGridViewTextBoxColumn.Name = "ValeurDataGridViewTextBoxColumn"
        Me.ValeurDataGridViewTextBoxColumn.Width = 250
        '
        'NomChampsDataGridViewTextBoxColumn
        '
        Me.NomChampsDataGridViewTextBoxColumn.DataPropertyName = "NomChamps"
        Me.NomChampsDataGridViewTextBoxColumn.HeaderText = "NomChamps"
        Me.NomChampsDataGridViewTextBoxColumn.Name = "NomChampsDataGridViewTextBoxColumn"
        Me.NomChampsDataGridViewTextBoxColumn.Visible = False
        '
        'LargeurChampsDataGridViewTextBoxColumn
        '
        Me.LargeurChampsDataGridViewTextBoxColumn.DataPropertyName = "LargeurChamps"
        Me.LargeurChampsDataGridViewTextBoxColumn.HeaderText = "LargeurChamps"
        Me.LargeurChampsDataGridViewTextBoxColumn.Name = "LargeurChampsDataGridViewTextBoxColumn"
        Me.LargeurChampsDataGridViewTextBoxColumn.Visible = False
        '
        'NImageDataGridViewTextBoxColumn
        '
        Me.NImageDataGridViewTextBoxColumn.DataPropertyName = "nImage"
        Me.NImageDataGridViewTextBoxColumn.HeaderText = "nImage"
        Me.NImageDataGridViewTextBoxColumn.Name = "NImageDataGridViewTextBoxColumn"
        Me.NImageDataGridViewTextBoxColumn.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomChoix"
        Me.DataGridViewTextBoxColumn1.HeaderText = "NomChoix"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "nOrdreValeur"
        Me.DataGridViewTextBoxColumn2.HeaderText = "nOrdreValeur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Valeur"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Valeur"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NomChamps"
        Me.DataGridViewTextBoxColumn4.HeaderText = "NomChamps"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "LargeurChamps"
        Me.DataGridViewTextBoxColumn5.HeaderText = "LargeurChamps"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "nImage"
        Me.DataGridViewTextBoxColumn6.HeaderText = "nImage"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'FrListeChoix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(317, 328)
        Me.Controls.Add(Me.ListeChoixDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrListeChoix"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste choix"
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PubDataSet As AgriFact.PubDataSet
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As AgriFact.PubDataSetTableAdapters.ListeChoixTableAdapter
    Friend WithEvents ListeChoixDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomChoixDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOrdreValeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomChampsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LargeurChampsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NImageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
