<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixValeurForfaitaire
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrChoixValeurForfaitaire))
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BAREME_FORFAITAIRE_AFFICHAGETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.BAREME_FORFAITAIRE_AFFICHAGETableAdapter
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView = New System.Windows.Forms.DataGridView
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BAREME_FORFAITAIRE_AFFICHAGEBindingSource
        '
        Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource.DataMember = "BAREME_FORFAITAIRE_AFFICHAGE"
        Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource.DataSource = Me.DataSetBaremes
        '
        'BAREME_FORFAITAIRE_AFFICHAGETableAdapter
        '
        Me.BAREME_FORFAITAIRE_AFFICHAGETableAdapter.ClearBeforeFill = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(561, 10)
        Me.ProgressBar1.TabIndex = 0
        '
        'BAREME_FORFAITAIRE_AFFICHAGEDataGridView
        '
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.AllowUserToAddRows = False
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.AllowUserToDeleteRows = False
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.AutoGenerateColumns = False
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn, Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn, Me.VALEURFORFAITAIREDataGridViewTextBoxColumn})
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.DataSource = Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.Location = New System.Drawing.Point(12, 28)
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.Name = "BAREME_FORFAITAIRE_AFFICHAGEDataGridView"
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.ReadOnly = True
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.Size = New System.Drawing.Size(561, 562)
        Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView.TabIndex = 1
        '
        'LIBELLEFACONCULTURALEDataGridViewTextBoxColumn
        '
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.DataPropertyName = "LIBELLE_FACON_CULTURALE"
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.Name = "LIBELLEFACONCULTURALEDataGridViewTextBoxColumn"
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.ReadOnly = True
        Me.LIBELLEFACONCULTURALEDataGridViewTextBoxColumn.Width = 350
        '
        'ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn
        '
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.DataPropertyName = "ANNEE_BAREME_FORFAITAIRE"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.HeaderText = "Année"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.Name = "ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.ReadOnly = True
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.Width = 60
        '
        'VALEURFORFAITAIREDataGridViewTextBoxColumn
        '
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.DataPropertyName = "VALEUR_FORFAITAIRE"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.HeaderText = "Val. forf."
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.Name = "VALEURFORFAITAIREDataGridViewTextBoxColumn"
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.ReadOnly = True
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.Width = 80
        '
        'FrChoixValeurForfaitaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(585, 602)
        Me.Controls.Add(Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrChoixValeurForfaitaire"
        Me.Text = "Choix valeur forfaitaire"
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREME_FORFAITAIRE_AFFICHAGEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents BAREME_FORFAITAIRE_AFFICHAGEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BAREME_FORFAITAIRE_AFFICHAGETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.BAREME_FORFAITAIRE_AFFICHAGETableAdapter
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BAREME_FORFAITAIRE_AFFICHAGEDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LIBELLEFACONCULTURALEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALEURFORFAITAIREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
