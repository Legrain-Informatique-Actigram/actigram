﻿Namespace Stocks
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.StocksDataSet = New ControleTracabilite.StocksDataSet
            Me.InventaireBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.InventaireTA = New ControleTracabilite.StocksDataSetTableAdapters.InventaireTA
            Me.InventaireDataGridView = New System.Windows.Forms.DataGridView
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.EcartU1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
            Me.TbImpr = New System.Windows.Forms.ToolStripButton
            Me.TbSave = New System.Windows.Forms.ToolStripButton
            Me.TbClose = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.TbCodeBarre = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.TxRecherche = New System.Windows.Forms.ToolStripTextBox
            Me.TbCancelFiltre = New System.Windows.Forms.ToolStripButton
            Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.Mouvement_DetailTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
            Me.MouvementTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
            CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.InventaireBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.InventaireDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip1.SuspendLayout()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.InventaireDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.EcartU1})
            Me.InventaireDataGridView.DataSource = Me.InventaireBindingSource
            Me.InventaireDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.InventaireDataGridView.Location = New System.Drawing.Point(0, 25)
            Me.InventaireDataGridView.Name = "InventaireDataGridView"
            Me.InventaireDataGridView.Size = New System.Drawing.Size(731, 277)
            Me.InventaireDataGridView.TabIndex = 2
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
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "nLot"
            Me.DataGridViewTextBoxColumn8.HeaderText = "Lot"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Width = 47
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
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "QteU1Depart"
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "N3"
            DataGridViewCellStyle1.NullValue = "0"
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn9.HeaderText = "Qte. Théo."
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 83
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "QteU1"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N3"
            DataGridViewCellStyle2.NullValue = "0"
            Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.Width = 72
            '
            'EcartU1
            '
            Me.EcartU1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.EcartU1.DataPropertyName = "EcartU1"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            DataGridViewCellStyle3.NullValue = "0"
            Me.EcartU1.DefaultCellStyle = DataGridViewCellStyle3
            Me.EcartU1.HeaderText = "Ecart"
            Me.EcartU1.Name = "EcartU1"
            Me.EcartU1.ReadOnly = True
            Me.EcartU1.Width = 57
            '
            'ToolStrip1
            '
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImpr, Me.TbSave, Me.TbClose, Me.ToolStripSeparator1, Me.TbCodeBarre, Me.ToolStripSeparator2, Me.TxRecherche, Me.TbCancelFiltre})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(731, 25)
            Me.ToolStrip1.TabIndex = 3
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'TbImpr
            '
            Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbImpr.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbImpr.Name = "TbImpr"
            Me.TbImpr.Size = New System.Drawing.Size(23, 22)
            Me.TbImpr.Text = "Imprimer"
            '
            'TbSave
            '
            Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbSave.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbSave.Name = "TbSave"
            Me.TbSave.Size = New System.Drawing.Size(23, 22)
            Me.TbSave.Text = "Enregistrer"
            '
            'TbClose
            '
            Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbClose.Image = Global.ControleTracabilite.My.Resources.Resources.close
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
            'TbCodeBarre
            '
            Me.TbCodeBarre.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
            Me.TbCodeBarre.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbCodeBarre.Name = "TbCodeBarre"
            Me.TbCodeBarre.Size = New System.Drawing.Size(135, 22)
            Me.TbCodeBarre.Text = "Saisie par code barre"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
            Me.TbCancelFiltre.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbCancelFiltre.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbCancelFiltre.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbCancelFiltre.Name = "TbCancelFiltre"
            Me.TbCancelFiltre.Size = New System.Drawing.Size(23, 22)
            Me.TbCancelFiltre.Text = "Supprimer le filtre"
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Mouvement_DetailTableAdapter
            '
            Me.Mouvement_DetailTableAdapter.ClearBeforeFill = True
            '
            'MouvementTableAdapter
            '
            Me.MouvementTableAdapter.ClearBeforeFill = True
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
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents StocksDataSet As ControleTracabilite.StocksDataSet
        Friend WithEvents InventaireBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents InventaireTA As ControleTracabilite.StocksDataSetTableAdapters.InventaireTA
        Friend WithEvents InventaireDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EcartU1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbCodeBarre As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TxRecherche As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
        Friend WithEvents TbCancelFiltre As System.Windows.Forms.ToolStripButton
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents Mouvement_DetailTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
        Friend WithEvents MouvementTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
    End Class

End Namespace