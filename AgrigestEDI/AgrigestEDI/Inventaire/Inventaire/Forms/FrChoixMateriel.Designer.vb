<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixMateriel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrChoixMateriel))
        Me.BAREME_AFFICHAGEDataGridView = New System.Windows.Forms.DataGridView
        Me.ID_MATERIEL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleMateriel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INFO_COMPL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CODE_TYPE_MATERIEL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ANNEE_BAREME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COUT_TOTAL_PAR_HEURE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BAREME_AFFICHAGEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.BAREME_AFFICHAGETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.BAREME_AFFICHAGETableAdapter
        CType(Me.BAREME_AFFICHAGEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREME_AFFICHAGEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BAREME_AFFICHAGEDataGridView
        '
        Me.BAREME_AFFICHAGEDataGridView.AllowUserToAddRows = False
        Me.BAREME_AFFICHAGEDataGridView.AllowUserToDeleteRows = False
        Me.BAREME_AFFICHAGEDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BAREME_AFFICHAGEDataGridView.AutoGenerateColumns = False
        Me.BAREME_AFFICHAGEDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.BAREME_AFFICHAGEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BAREME_AFFICHAGEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_MATERIEL, Me.LibelleMateriel, Me.INFO_COMPL, Me.CODE_TYPE_MATERIEL, Me.ANNEE_BAREME, Me.COUT_TOTAL_PAR_HEURE})
        Me.BAREME_AFFICHAGEDataGridView.DataSource = Me.BAREME_AFFICHAGEBindingSource
        Me.BAREME_AFFICHAGEDataGridView.Location = New System.Drawing.Point(12, 26)
        Me.BAREME_AFFICHAGEDataGridView.Name = "BAREME_AFFICHAGEDataGridView"
        Me.BAREME_AFFICHAGEDataGridView.ReadOnly = True
        Me.BAREME_AFFICHAGEDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BAREME_AFFICHAGEDataGridView.Size = New System.Drawing.Size(700, 427)
        Me.BAREME_AFFICHAGEDataGridView.TabIndex = 0
        '
        'ID_MATERIEL
        '
        Me.ID_MATERIEL.DataPropertyName = "ID_MATERIEL"
        Me.ID_MATERIEL.HeaderText = "ID_MATERIEL"
        Me.ID_MATERIEL.Name = "ID_MATERIEL"
        Me.ID_MATERIEL.ReadOnly = True
        Me.ID_MATERIEL.Visible = False
        '
        'LibelleMateriel
        '
        Me.LibelleMateriel.DataPropertyName = "LibelleMateriel"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LibelleMateriel.DefaultCellStyle = DataGridViewCellStyle1
        Me.LibelleMateriel.HeaderText = "Matériel"
        Me.LibelleMateriel.Name = "LibelleMateriel"
        Me.LibelleMateriel.ReadOnly = True
        Me.LibelleMateriel.Width = 350
        '
        'INFO_COMPL
        '
        Me.INFO_COMPL.DataPropertyName = "INFO_COMPL"
        Me.INFO_COMPL.HeaderText = "Info compl."
        Me.INFO_COMPL.Name = "INFO_COMPL"
        Me.INFO_COMPL.ReadOnly = True
        '
        'CODE_TYPE_MATERIEL
        '
        Me.CODE_TYPE_MATERIEL.DataPropertyName = "CODE_TYPE_MATERIEL"
        Me.CODE_TYPE_MATERIEL.HeaderText = "Type"
        Me.CODE_TYPE_MATERIEL.Name = "CODE_TYPE_MATERIEL"
        Me.CODE_TYPE_MATERIEL.ReadOnly = True
        Me.CODE_TYPE_MATERIEL.Width = 50
        '
        'ANNEE_BAREME
        '
        Me.ANNEE_BAREME.DataPropertyName = "ANNEE_BAREME"
        Me.ANNEE_BAREME.HeaderText = "Année"
        Me.ANNEE_BAREME.Name = "ANNEE_BAREME"
        Me.ANNEE_BAREME.ReadOnly = True
        Me.ANNEE_BAREME.Width = 60
        '
        'COUT_TOTAL_PAR_HEURE
        '
        Me.COUT_TOTAL_PAR_HEURE.DataPropertyName = "COUT_TOTAL_PAR_HEURE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COUT_TOTAL_PAR_HEURE.DefaultCellStyle = DataGridViewCellStyle2
        Me.COUT_TOTAL_PAR_HEURE.HeaderText = "Coût/h"
        Me.COUT_TOTAL_PAR_HEURE.Name = "COUT_TOTAL_PAR_HEURE"
        Me.COUT_TOTAL_PAR_HEURE.ReadOnly = True
        Me.COUT_TOTAL_PAR_HEURE.Width = 80
        '
        'BAREME_AFFICHAGEBindingSource
        '
        Me.BAREME_AFFICHAGEBindingSource.DataMember = "BAREME_AFFICHAGE"
        Me.BAREME_AFFICHAGEBindingSource.DataSource = Me.DataSetBaremes
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 10)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(700, 10)
        Me.ProgressBar1.TabIndex = 1
        '
        'BAREME_AFFICHAGETableAdapter
        '
        Me.BAREME_AFFICHAGETableAdapter.ClearBeforeFill = True
        '
        'FrChoixMateriel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(724, 465)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BAREME_AFFICHAGEDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrChoixMateriel"
        Me.Text = "Choix du matériel"
        CType(Me.BAREME_AFFICHAGEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREME_AFFICHAGEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents BAREME_AFFICHAGEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BAREME_AFFICHAGETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.BAREME_AFFICHAGETableAdapter
    Friend WithEvents BAREME_AFFICHAGEDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ID_MATERIEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleMateriel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INFO_COMPL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODE_TYPE_MATERIEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANNEE_BAREME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUT_TOTAL_PAR_HEURE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
