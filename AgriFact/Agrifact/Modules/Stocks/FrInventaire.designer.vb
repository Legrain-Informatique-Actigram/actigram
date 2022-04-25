<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrInventaire
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.InventaireBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventaireTA = New AgriFact.StocksDataSetTableAdapters.InventaireTA
        Me.InventaireDataGridView = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TxRecherche = New System.Windows.Forms.ToolStripTextBox
        Me.TbCancelFiltre = New System.Windows.Forms.ToolStripButton
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.Mouvement_DetailTA = New AgriFact.StocksDataSetTableAdapters.Mouvement_DetailTA
        Me.MouvementTA = New AgriFact.StocksDataSetTableAdapters.MouvementTA
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EcartU1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QteU2Depart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QteU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EcartU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventaireBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventaireDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InventaireBindingSource
        '
        Me.InventaireBindingSource.DataMember = "Inventaire"
        Me.InventaireBindingSource.DataSource = Me.StocksDataSet
        '
        'InventaireTA
        '
        Me.InventaireTA.ClearBeforeFill = True
        '
        'InventaireDataGridView
        '
        Me.InventaireDataGridView.AllowUserToAddRows = False
        Me.InventaireDataGridView.AllowUserToDeleteRows = False
        Me.InventaireDataGridView.AutoGenerateColumns = False
        Me.InventaireDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.EcartU1, Me.LibUnite1, Me.QteU2Depart, Me.QteU2, Me.EcartU2, Me.LibUnite2})
        Me.InventaireDataGridView.DataSource = Me.InventaireBindingSource
        Me.InventaireDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InventaireDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.InventaireDataGridView.Name = "InventaireDataGridView"
        Me.InventaireDataGridView.Size = New System.Drawing.Size(731, 277)
        Me.InventaireDataGridView.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImpr, Me.TbSave, Me.TbClose, Me.ToolStripSeparator1, Me.TxRecherche, Me.TbCancelFiltre})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(731, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(23, 22)
        Me.TbImpr.Text = "Imprimer"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TxRecherche
        '
        Me.TxRecherche.AcceptsReturn = True
        Me.TxRecherche.Name = "TxRecherche"
        Me.TxRecherche.Size = New System.Drawing.Size(200, 25)
        Me.WatermarkProvider1.SetWatermark(Me.TxRecherche, "Rechercher")
        '
        'TbCancelFiltre
        '
        Me.TbCancelFiltre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCancelFiltre.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbCancelFiltre.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbCancelFiltre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCancelFiltre.Name = "TbCancelFiltre"
        Me.TbCancelFiltre.Size = New System.Drawing.Size(23, 22)
        Me.TbCancelFiltre.Text = "Supprimer le filtre"
        '
        'Mouvement_DetailTA
        '
        Me.Mouvement_DetailTA.ClearBeforeFill = True
        '
        'MouvementTA
        '
        Me.MouvementTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "LibUnite1"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N3"
        DataGridViewCellStyle10.NullValue = "0"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unité"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 47
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "QteU1Depart"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N3"
        DataGridViewCellStyle11.NullValue = "0"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn6.HeaderText = "Qte. Théo."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "QteU1"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N3"
        DataGridViewCellStyle12.NullValue = "0"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn7.HeaderText = "Quantité"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "EcartU2"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N3"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn11.HeaderText = "EcartU2"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 89
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "EcartU2"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N3"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn12.HeaderText = "Ecart U2"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 74
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn13.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 46
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Famille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CodeProduit"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Code Produit"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 93
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LibUnite1"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unité"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 57
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "nLot"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        DataGridViewCellStyle1.NullValue = "0"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn8.HeaderText = "Lot"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 47
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "QteU1Depart"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn9.HeaderText = "Qte. Théo. U1"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "QteU1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité U1"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 89
        '
        'EcartU1
        '
        Me.EcartU1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EcartU1.DataPropertyName = "EcartU1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = "0"
        Me.EcartU1.DefaultCellStyle = DataGridViewCellStyle4
        Me.EcartU1.HeaderText = "Ecart U1"
        Me.EcartU1.Name = "EcartU1"
        Me.EcartU1.ReadOnly = True
        Me.EcartU1.Width = 74
        '
        'LibUnite1
        '
        Me.LibUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite1.DataPropertyName = "LibUnite1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LibUnite1.DefaultCellStyle = DataGridViewCellStyle5
        Me.LibUnite1.HeaderText = "U1"
        Me.LibUnite1.Name = "LibUnite1"
        Me.LibUnite1.ReadOnly = True
        Me.LibUnite1.Width = 46
        '
        'QteU2Depart
        '
        Me.QteU2Depart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.QteU2Depart.DataPropertyName = "QteU2Depart"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N3"
        Me.QteU2Depart.DefaultCellStyle = DataGridViewCellStyle6
        Me.QteU2Depart.HeaderText = "Qte. Théo. U2"
        Me.QteU2Depart.Name = "QteU2Depart"
        Me.QteU2Depart.ReadOnly = True
        '
        'QteU2
        '
        Me.QteU2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.QteU2.DataPropertyName = "QteU2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        Me.QteU2.DefaultCellStyle = DataGridViewCellStyle7
        Me.QteU2.HeaderText = "Quantité U2"
        Me.QteU2.Name = "QteU2"
        Me.QteU2.ReadOnly = True
        Me.QteU2.Width = 89
        '
        'EcartU2
        '
        Me.EcartU2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EcartU2.DataPropertyName = "EcartU2"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N3"
        Me.EcartU2.DefaultCellStyle = DataGridViewCellStyle8
        Me.EcartU2.HeaderText = "Ecart U2"
        Me.EcartU2.Name = "EcartU2"
        Me.EcartU2.ReadOnly = True
        Me.EcartU2.Width = 74
        '
        'LibUnite2
        '
        Me.LibUnite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite2.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LibUnite2.DefaultCellStyle = DataGridViewCellStyle9
        Me.LibUnite2.HeaderText = "U2"
        Me.LibUnite2.Name = "LibUnite2"
        Me.LibUnite2.ReadOnly = True
        Me.LibUnite2.Width = 46
        '
        'FrInventaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 302)
        Me.ControlBox = False
        Me.Controls.Add(Me.InventaireDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrInventaire"
        Me.Text = "Inventaire"
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventaireBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventaireDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StocksDataSet As StocksDataSet
    Friend WithEvents InventaireBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventaireTA As StocksDataSetTableAdapters.InventaireTA
    Friend WithEvents InventaireDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TxRecherche As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents TbCancelFiltre As System.Windows.Forms.ToolStripButton
    Friend WithEvents Mouvement_DetailTA As StocksDataSetTableAdapters.Mouvement_DetailTA
    Friend WithEvents MouvementTA As StocksDataSetTableAdapters.MouvementTA
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EcartU1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QteU2Depart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QteU2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EcartU2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class