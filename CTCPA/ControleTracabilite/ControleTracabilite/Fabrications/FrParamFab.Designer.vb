<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrParamFab
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
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.TxtCoef = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.CompositionProduitDataGridView = New System.Windows.Forms.DataGridView
        Me.FKMouvementDetailMouvementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MouvementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.MouvementTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
        Me.Mouvement_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
        Me.CodeProduitComposition = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
        Me.LibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
        Me.LibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GradientPanel1.SuspendLayout()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompositionProduitDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKMouvementDetailMouvementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.TxtCoef)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(492, 43)
        Me.GradientPanel1.TabIndex = 78
        '
        'TxtCoef
        '
        Me.TxtCoef.Location = New System.Drawing.Point(109, 12)
        Me.TxtCoef.Name = "TxtCoef"
        Me.TxtCoef.Size = New System.Drawing.Size(49, 20)
        Me.TxtCoef.TabIndex = 5
        Me.TxtCoef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Quantité à traiter :"
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CompositionProduitDataGridView
        '
        Me.CompositionProduitDataGridView.AllowUserToAddRows = False
        Me.CompositionProduitDataGridView.AllowUserToDeleteRows = False
        Me.CompositionProduitDataGridView.AutoGenerateColumns = False
        Me.CompositionProduitDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeProduitComposition, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.LibUnite1, Me.DataGridViewTextBoxColumn8, Me.LibUnite2})
        Me.CompositionProduitDataGridView.DataSource = Me.FKMouvementDetailMouvementBindingSource
        Me.CompositionProduitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionProduitDataGridView.Location = New System.Drawing.Point(0, 43)
        Me.CompositionProduitDataGridView.Name = "CompositionProduitDataGridView"
        Me.CompositionProduitDataGridView.ReadOnly = True
        Me.CompositionProduitDataGridView.Size = New System.Drawing.Size(492, 177)
        Me.CompositionProduitDataGridView.TabIndex = 78
        '
        'FKMouvementDetailMouvementBindingSource
        '
        Me.FKMouvementDetailMouvementBindingSource.DataMember = "FK_Mouvement_Detail_Mouvement"
        Me.FKMouvementDetailMouvementBindingSource.DataSource = Me.MouvementBindingSource
        '
        'MouvementBindingSource
        '
        Me.MouvementBindingSource.DataMember = "Mouvement"
        Me.MouvementBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.BtCancel)
        Me.GradientPanel2.Controls.Add(Me.BtOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 220)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(492, 50)
        Me.GradientPanel2.TabIndex = 79
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(405, 15)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 1
        Me.BtCancel.Text = "Annuler"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOK.Location = New System.Drawing.Point(324, 15)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'MouvementTableAdapter
        '
        Me.MouvementTableAdapter.ClearBeforeFill = True
        '
        'Mouvement_DetailTableAdapter
        '
        Me.Mouvement_DetailTableAdapter.ClearBeforeFill = True
        '
        'CodeProduitComposition
        '
        Me.CodeProduitComposition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitComposition.DataPropertyName = "CodeProduit"
        Me.CodeProduitComposition.HeaderText = "Produit"
        Me.CodeProduitComposition.Name = "CodeProduitComposition"
        Me.CodeProduitComposition.ReadOnly = True
        Me.CodeProduitComposition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodeProduitComposition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodeProduitComposition.Width = 47
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Unite1"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn6.HeaderText = "Qté U1"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.Width = 67
        '
        'LibUnite1
        '
        Me.LibUnite1.DataPropertyName = "LibUnite1"
        Me.LibUnite1.HeaderText = ""
        Me.LibUnite1.Name = "LibUnite1"
        Me.LibUnite1.ReadOnly = True
        Me.LibUnite1.Width = 30
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Unite2"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Qté U2"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.Width = 67
        '
        'LibUnite2
        '
        Me.LibUnite2.DataPropertyName = "LibUnite2"
        Me.LibUnite2.HeaderText = ""
        Me.LibUnite2.Name = "LibUnite2"
        Me.LibUnite2.ReadOnly = True
        Me.LibUnite2.Width = 30
        '
        'FrParamFab
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(492, 270)
        Me.Controls.Add(Me.CompositionProduitDataGridView)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrParamFab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nouvelle fabrication"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompositionProduitDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKMouvementDetailMouvementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents CompositionProduitDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCoef As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents MouvementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MouvementTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
    Friend WithEvents FKMouvementDetailMouvementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Mouvement_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
    Friend WithEvents CodeProduitComposition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As ControleTracabilite.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As ControleTracabilite.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
