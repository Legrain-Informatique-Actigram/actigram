Namespace Receptions
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.BRBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.NomClientTextBox = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.TxNLot = New System.Windows.Forms.TextBox
            Me.FournBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ABonReception_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ABonReception_DetailDataGridView = New System.Windows.Forms.DataGridView
            Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            Me.ABonReceptionTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
            Me.ABonReception_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn10 = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColNbEtiq = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            NClientLabel = New System.Windows.Forms.Label
            CType(Me.BRBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BRBindingNavigator.SuspendLayout()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ABonReception_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ABonReception_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'NClientLabel
            '
            NClientLabel.AutoSize = True
            NClientLabel.Location = New System.Drawing.Point(12, 11)
            NClientLabel.Name = "NClientLabel"
            NClientLabel.Size = New System.Drawing.Size(64, 13)
            NClientLabel.TabIndex = 0
            NClientLabel.Text = "Fournisseur:"
            '
            'BRBindingNavigator
            '
            Me.BRBindingNavigator.AddNewItem = Nothing
            Me.BRBindingNavigator.BindingSource = Me.BRBindingSource
            Me.BRBindingNavigator.CountItem = Nothing
            Me.BRBindingNavigator.DeleteItem = Nothing
            Me.BRBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BRBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFermer, Me.ToolStripButton1})
            Me.BRBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.BRBindingNavigator.MoveFirstItem = Nothing
            Me.BRBindingNavigator.MoveLastItem = Nothing
            Me.BRBindingNavigator.MoveNextItem = Nothing
            Me.BRBindingNavigator.MovePreviousItem = Nothing
            Me.BRBindingNavigator.Name = "BRBindingNavigator"
            Me.BRBindingNavigator.PositionItem = Nothing
            Me.BRBindingNavigator.Size = New System.Drawing.Size(618, 25)
            Me.BRBindingNavigator.TabIndex = 0
            Me.BRBindingNavigator.Text = "BindingNavigator1"
            '
            'BRBindingSource
            '
            Me.BRBindingSource.DataMember = "ABonReception"
            Me.BRBindingSource.DataSource = Me.AgrifactTracaDataSet
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
            Me.GradientPanel1.Controls.Add(Me.NomClientTextBox)
            Me.GradientPanel1.Controls.Add(Me.Label1)
            Me.GradientPanel1.Controls.Add(Me.TxNLot)
            Me.GradientPanel1.Controls.Add(NClientLabel)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(618, 76)
            Me.GradientPanel1.TabIndex = 1
            '
            'NomClientTextBox
            '
            Me.NomClientTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BRBindingSource, "NomClient", True))
            Me.NomClientTextBox.Location = New System.Drawing.Point(82, 8)
            Me.NomClientTextBox.Name = "NomClientTextBox"
            Me.NomClientTextBox.ReadOnly = True
            Me.NomClientTextBox.Size = New System.Drawing.Size(369, 20)
            Me.NomClientTextBox.TabIndex = 14
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 38)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(51, 13)
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "N° du lot:"
            '
            'TxNLot
            '
            Me.TxNLot.Location = New System.Drawing.Point(82, 35)
            Me.TxNLot.MaxLength = 255
            Me.TxNLot.Name = "TxNLot"
            Me.TxNLot.ReadOnly = True
            Me.TxNLot.Size = New System.Drawing.Size(167, 20)
            Me.TxNLot.TabIndex = 12
            '
            'FournBindingSource
            '
            Me.FournBindingSource.DataMember = "Entreprise"
            Me.FournBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.FournBindingSource.Sort = "Nom"
            '
            'ABonReception_DetailBindingSource
            '
            Me.ABonReception_DetailBindingSource.DataMember = "FK_ABonReception_Detail_ABonReception"
            Me.ABonReception_DetailBindingSource.DataSource = Me.BRBindingSource
            '
            'ABonReception_DetailDataGridView
            '
            Me.ABonReception_DetailDataGridView.AllowUserToAddRows = False
            Me.ABonReception_DetailDataGridView.AllowUserToDeleteRows = False
            Me.ABonReception_DetailDataGridView.AutoGenerateColumns = False
            Me.ABonReception_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.ColNbEtiq})
            Me.ABonReception_DetailDataGridView.DataSource = Me.ABonReception_DetailBindingSource
            Me.ABonReception_DetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ABonReception_DetailDataGridView.Location = New System.Drawing.Point(3, 16)
            Me.ABonReception_DetailDataGridView.Name = "ABonReception_DetailDataGridView"
            Me.ABonReception_DetailDataGridView.Size = New System.Drawing.Size(612, 210)
            Me.ABonReception_DetailDataGridView.TabIndex = 1
            '
            'ProduitBindingSource
            '
            Me.ProduitBindingSource.DataMember = "Produit"
            Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ProduitBindingSource.Filter = "ProduitAchat=1"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.ABonReception_DetailDataGridView)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 101)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(618, 229)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Produits"
            '
            'ProduitTableAdapter
            '
            Me.ProduitTableAdapter.ClearBeforeFill = True
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'ABonReceptionTableAdapter
            '
            Me.ABonReceptionTableAdapter.ClearBeforeFill = True
            '
            'ABonReception_DetailTableAdapter
            '
            Me.ABonReception_DetailTableAdapter.ClearBeforeFill = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "CodeProduit"
            Me.DataGridViewTextBoxColumn5.HeaderText = "Code"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "Libelle"
            Me.DataGridViewTextBoxColumn6.HeaderText = "Libellé"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "Unite1"
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "N3"
            Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn8.HeaderText = "Quantité 1"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn8.Width = 75
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "LibUnite1"
            Me.DataGridViewTextBoxColumn9.HeaderText = ""
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 30
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "Unite2"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N3"
            Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité 2"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn10.Width = 75
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "LibUnite2"
            Me.DataGridViewTextBoxColumn11.HeaderText = ""
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Width = 30
            '
            'ColNbEtiq
            '
            Me.ColNbEtiq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColNbEtiq.HeaderText = "Nb Etiq."
            Me.ColNbEtiq.Name = "ColNbEtiq"
            Me.ColNbEtiq.Width = 70
            '
            'FrImprEtiqCB
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(618, 330)
            Me.ControlBox = False
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.BRBindingNavigator)
            Me.Name = "FrImprEtiqCB"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Impression d'étiquettes code-barre"
            CType(Me.BRBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BRBindingNavigator.ResumeLayout(False)
            Me.BRBindingNavigator.PerformLayout()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ABonReception_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ABonReception_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents BRBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Friend WithEvents BRBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents FournBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents ABonReceptionTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
        Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ABonReception_DetailBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ABonReception_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
        Friend WithEvents ABonReception_DetailDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TxNLot As System.Windows.Forms.TextBox
        Friend WithEvents NomClientTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColNbEtiq As ControleTracabilite.DatagridViewNumericTextBoxColumn
    End Class
End Namespace