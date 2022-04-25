Namespace Fabrications
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrImprEtiqCB
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
            Dim NClientLabel As System.Windows.Forms.Label
            Dim DescriptionLabel As System.Windows.Forms.Label
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.MvtBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.MvtBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.Label2 = New System.Windows.Forms.Label
            Me.DescriptionTextBox = New System.Windows.Forms.TextBox
            Me.NomClientTextBox = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.TxNLot = New System.Windows.Forms.TextBox
            Me.Mouvement_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Mouvement_DetailDataGridView = New System.Windows.Forms.DataGridView
            Me.NMouvementDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.CodeProduit = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Unite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.LibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Unite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.LibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColNbEtiq = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.MouvementTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
            Me.Mouvement_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
            NClientLabel = New System.Windows.Forms.Label
            DescriptionLabel = New System.Windows.Forms.Label
            CType(Me.MvtBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MvtBindingNavigator.SuspendLayout()
            CType(Me.MvtBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.Mouvement_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Mouvement_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'NClientLabel
            '
            NClientLabel.AutoSize = True
            NClientLabel.Location = New System.Drawing.Point(12, 11)
            NClientLabel.Name = "NClientLabel"
            NClientLabel.Size = New System.Drawing.Size(36, 13)
            NClientLabel.TabIndex = 0
            NClientLabel.Text = "Date :"
            '
            'DescriptionLabel
            '
            DescriptionLabel.AutoSize = True
            DescriptionLabel.Location = New System.Drawing.Point(12, 37)
            DescriptionLabel.Name = "DescriptionLabel"
            DescriptionLabel.Size = New System.Drawing.Size(63, 13)
            DescriptionLabel.TabIndex = 4
            DescriptionLabel.Text = "Description:"
            '
            'MvtBindingNavigator
            '
            Me.MvtBindingNavigator.AddNewItem = Nothing
            Me.MvtBindingNavigator.BindingSource = Me.MvtBindingSource
            Me.MvtBindingNavigator.CountItem = Nothing
            Me.MvtBindingNavigator.DeleteItem = Nothing
            Me.MvtBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.MvtBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFermer, Me.ToolStripButton1})
            Me.MvtBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.MvtBindingNavigator.MoveFirstItem = Nothing
            Me.MvtBindingNavigator.MoveLastItem = Nothing
            Me.MvtBindingNavigator.MoveNextItem = Nothing
            Me.MvtBindingNavigator.MovePreviousItem = Nothing
            Me.MvtBindingNavigator.Name = "MvtBindingNavigator"
            Me.MvtBindingNavigator.PositionItem = Nothing
            Me.MvtBindingNavigator.Size = New System.Drawing.Size(634, 25)
            Me.MvtBindingNavigator.TabIndex = 0
            Me.MvtBindingNavigator.Text = "BindingNavigator1"
            '
            'MvtBindingSource
            '
            Me.MvtBindingSource.DataMember = "Mouvement"
            Me.MvtBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'ToolStripButton1
            '
            Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton1.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton1.Name = "ToolStripButton1"
            Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton1.Text = "Imprimer les étiquettes"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.Label2)
            Me.GradientPanel1.Controls.Add(DescriptionLabel)
            Me.GradientPanel1.Controls.Add(Me.DescriptionTextBox)
            Me.GradientPanel1.Controls.Add(Me.NomClientTextBox)
            Me.GradientPanel1.Controls.Add(Me.Label1)
            Me.GradientPanel1.Controls.Add(Me.TxNLot)
            Me.GradientPanel1.Controls.Add(NClientLabel)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(634, 89)
            Me.GradientPanel1.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Red
            Me.Label2.Location = New System.Drawing.Point(12, 50)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(245, 31)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "FABRICATION !!!"
            Me.Label2.Visible = False
            '
            'DescriptionTextBox
            '
            Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MvtBindingSource, "Description", True))
            Me.DescriptionTextBox.Location = New System.Drawing.Point(81, 34)
            Me.DescriptionTextBox.Name = "DescriptionTextBox"
            Me.DescriptionTextBox.ReadOnly = True
            Me.DescriptionTextBox.Size = New System.Drawing.Size(370, 20)
            Me.DescriptionTextBox.TabIndex = 5
            '
            'NomClientTextBox
            '
            Me.NomClientTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MvtBindingSource, "DateMouvement", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
            Me.NomClientTextBox.Location = New System.Drawing.Point(81, 8)
            Me.NomClientTextBox.Name = "NomClientTextBox"
            Me.NomClientTextBox.ReadOnly = True
            Me.NomClientTextBox.Size = New System.Drawing.Size(140, 20)
            Me.NomClientTextBox.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(227, 11)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(51, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "N° du lot:"
            '
            'TxNLot
            '
            Me.TxNLot.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MvtBindingSource, "nPiece", True))
            Me.TxNLot.Location = New System.Drawing.Point(284, 8)
            Me.TxNLot.MaxLength = 255
            Me.TxNLot.Name = "TxNLot"
            Me.TxNLot.ReadOnly = True
            Me.TxNLot.Size = New System.Drawing.Size(167, 20)
            Me.TxNLot.TabIndex = 3
            '
            'Mouvement_DetailBindingSource
            '
            Me.Mouvement_DetailBindingSource.DataMember = "FK_Mouvement_Detail_Mouvement"
            Me.Mouvement_DetailBindingSource.DataSource = Me.MvtBindingSource
            Me.Mouvement_DetailBindingSource.Filter = "MatPrem=False"
            '
            'Mouvement_DetailDataGridView
            '
            Me.Mouvement_DetailDataGridView.AllowUserToAddRows = False
            Me.Mouvement_DetailDataGridView.AllowUserToDeleteRows = False
            Me.Mouvement_DetailDataGridView.AutoGenerateColumns = False
            Me.Mouvement_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NMouvementDetailDataGridViewTextBoxColumn, Me.CodeProduit, Me.Libelle, Me.Unite1, Me.LibUnite1, Me.Unite2, Me.LibUnite2, Me.ColNbEtiq})
            Me.Mouvement_DetailDataGridView.DataSource = Me.Mouvement_DetailBindingSource
            Me.Mouvement_DetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Mouvement_DetailDataGridView.Location = New System.Drawing.Point(3, 16)
            Me.Mouvement_DetailDataGridView.Name = "Mouvement_DetailDataGridView"
            Me.Mouvement_DetailDataGridView.Size = New System.Drawing.Size(628, 197)
            Me.Mouvement_DetailDataGridView.TabIndex = 0
            '
            'NMouvementDetailDataGridViewTextBoxColumn
            '
            Me.NMouvementDetailDataGridViewTextBoxColumn.DataPropertyName = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn.HeaderText = "nMouvementDetail"
            Me.NMouvementDetailDataGridViewTextBoxColumn.Name = "NMouvementDetailDataGridViewTextBoxColumn"
            Me.NMouvementDetailDataGridViewTextBoxColumn.Visible = False
            '
            'CodeProduit
            '
            Me.CodeProduit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.CodeProduit.DataPropertyName = "CodeProduit"
            Me.CodeProduit.HeaderText = "Code"
            Me.CodeProduit.Name = "CodeProduit"
            Me.CodeProduit.ReadOnly = True
            Me.CodeProduit.Width = 57
            '
            'Libelle
            '
            Me.Libelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.Libelle.DataPropertyName = "Libelle"
            Me.Libelle.HeaderText = "Libellé"
            Me.Libelle.Name = "Libelle"
            Me.Libelle.ReadOnly = True
            '
            'Unite1
            '
            Me.Unite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.Unite1.DataPropertyName = "Unite1"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.Unite1.DefaultCellStyle = DataGridViewCellStyle3
            Me.Unite1.HeaderText = "Quantité 1"
            Me.Unite1.Name = "Unite1"
            Me.Unite1.ReadOnly = True
            Me.Unite1.Width = 81
            '
            'LibUnite1
            '
            Me.LibUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.LibUnite1.DataPropertyName = "LibUnite1"
            Me.LibUnite1.HeaderText = ""
            Me.LibUnite1.Name = "LibUnite1"
            Me.LibUnite1.ReadOnly = True
            Me.LibUnite1.Width = 30
            '
            'Unite2
            '
            Me.Unite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.Unite2.DataPropertyName = "Unite2"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "N3"
            Me.Unite2.DefaultCellStyle = DataGridViewCellStyle4
            Me.Unite2.HeaderText = "Quantité 2"
            Me.Unite2.Name = "Unite2"
            Me.Unite2.ReadOnly = True
            Me.Unite2.Width = 81
            '
            'LibUnite2
            '
            Me.LibUnite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.LibUnite2.DataPropertyName = "LibUnite2"
            Me.LibUnite2.HeaderText = ""
            Me.LibUnite2.Name = "LibUnite2"
            Me.LibUnite2.ReadOnly = True
            Me.LibUnite2.Width = 30
            '
            'ColNbEtiq
            '
            Me.ColNbEtiq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColNbEtiq.HeaderText = "Nb Etiq."
            Me.ColNbEtiq.Name = "ColNbEtiq"
            Me.ColNbEtiq.Width = 70
            '
            'ProduitBindingSource
            '
            Me.ProduitBindingSource.DataMember = "Produit"
            Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitBindingSource.Filter = "ProduitAchat=1"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Mouvement_DetailDataGridView)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 114)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(634, 216)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Produits"
            '
            'ProduitTableAdapter
            '
            Me.ProduitTableAdapter.ClearBeforeFill = True
            '
            'MouvementTableAdapter
            '
            Me.MouvementTableAdapter.ClearBeforeFill = True
            '
            'Mouvement_DetailTableAdapter
            '
            Me.Mouvement_DetailTableAdapter.ClearBeforeFill = True
            '
            'FrImprEtiqCB
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(634, 330)
            Me.ControlBox = False
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.MvtBindingNavigator)
            Me.Name = "FrImprEtiqCB"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Impression d'étiquettes code-barre"
            CType(Me.MvtBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MvtBindingNavigator.ResumeLayout(False)
            Me.MvtBindingNavigator.PerformLayout()
            CType(Me.MvtBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.Mouvement_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Mouvement_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents MvtBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Friend WithEvents MvtBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Mouvement_DetailBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Mouvement_DetailDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TxNLot As System.Windows.Forms.TextBox
        Friend WithEvents NomClientTextBox As System.Windows.Forms.TextBox
        Friend WithEvents MouvementTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
        Friend WithEvents Mouvement_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents NMouvementDetailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CodeProduit As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Unite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents LibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Unite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents LibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColNbEtiq As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    End Class
End Namespace