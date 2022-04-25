Namespace Etats
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrEtatTracaLot
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
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.EtatTracaLotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EtatsDataset = New ControleTracabilite.EtatsDataset
            Me.BtImpr = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
            Me.cbLot = New System.Windows.Forms.ToolStripComboBox
            Me.OKToolStripButton = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.EtatTracaLotDataGridView = New System.Windows.Forms.DataGridView
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColControle = New ControleTracabilite.DataGridViewDisableButtonColumn
            Me.LotsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EtatTracaLotTableAdapter = New ControleTracabilite.EtatsDatasetTableAdapters.EtatTracaLotTableAdapter
            Me.ListeLotsTableAdapter = New ControleTracabilite.EtatsDatasetTableAdapters.ListeLotsTableAdapter
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewDisableButtonColumn1 = New ControleTracabilite.DataGridViewDisableButtonColumn
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            CType(Me.EtatTracaLotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatTracaLotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.EtatTracaLotBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtImpr, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cbLot, Me.OKToolStripButton, Me.TbFermer})
            Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
            Me.BindingNavigator1.MoveFirstItem = Nothing
            Me.BindingNavigator1.MoveLastItem = Nothing
            Me.BindingNavigator1.MoveNextItem = Nothing
            Me.BindingNavigator1.MovePreviousItem = Nothing
            Me.BindingNavigator1.Name = "BindingNavigator1"
            Me.BindingNavigator1.PositionItem = Nothing
            Me.BindingNavigator1.Size = New System.Drawing.Size(682, 25)
            Me.BindingNavigator1.TabIndex = 3
            Me.BindingNavigator1.Text = "BindingNavigator1"
            '
            'EtatTracaLotBindingSource
            '
            Me.EtatTracaLotBindingSource.DataMember = "EtatTracaLot"
            Me.EtatTracaLotBindingSource.DataSource = Me.EtatsDataset
            '
            'EtatsDataset
            '
            Me.EtatsDataset.DataSetName = "EtatsDataset"
            Me.EtatsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BtImpr
            '
            Me.BtImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BtImpr.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.BtImpr.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtImpr.Name = "BtImpr"
            Me.BtImpr.Size = New System.Drawing.Size(23, 22)
            Me.BtImpr.Text = "Imprimer"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'ToolStripLabel1
            '
            Me.ToolStripLabel1.Name = "ToolStripLabel1"
            Me.ToolStripLabel1.Size = New System.Drawing.Size(222, 22)
            Me.ToolStripLabel1.Text = "Liste des MP pour la fabrication du lot n°"
            '
            'cbLot
            '
            Me.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLot.DropDownWidth = 300
            Me.cbLot.Name = "cbLot"
            Me.cbLot.Size = New System.Drawing.Size(121, 25)
            '
            'OKToolStripButton
            '
            Me.OKToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.OKToolStripButton.Image = Global.ControleTracabilite.My.Resources.Resources.Retry
            Me.OKToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.OKToolStripButton.Name = "OKToolStripButton"
            Me.OKToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.OKToolStripButton.Text = "OK"
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
            'EtatTracaLotDataGridView
            '
            Me.EtatTracaLotDataGridView.AllowUserToAddRows = False
            Me.EtatTracaLotDataGridView.AllowUserToDeleteRows = False
            Me.EtatTracaLotDataGridView.AutoGenerateColumns = False
            Me.EtatTracaLotDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.EtatTracaLotDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.ColControle})
            Me.EtatTracaLotDataGridView.DataSource = Me.EtatTracaLotBindingSource
            Me.EtatTracaLotDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.EtatTracaLotDataGridView.Location = New System.Drawing.Point(0, 25)
            Me.EtatTracaLotDataGridView.Name = "EtatTracaLotDataGridView"
            Me.EtatTracaLotDataGridView.ReadOnly = True
            Me.EtatTracaLotDataGridView.Size = New System.Drawing.Size(682, 394)
            Me.EtatTracaLotDataGridView.TabIndex = 4
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "nom"
            Me.DataGridViewTextBoxColumn2.HeaderText = "Fournisseur"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Width = 86
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "datefacture"
            DataGridViewCellStyle1.Format = "d"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Width = 55
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "nlot"
            Me.DataGridViewTextBoxColumn7.HeaderText = "Lot BR"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Width = 65
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "codeproduit"
            Me.DataGridViewTextBoxColumn8.HeaderText = "Code"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Width = 57
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "libelle"
            Me.DataGridViewTextBoxColumn9.HeaderText = "Libellé"
            Me.DataGridViewTextBoxColumn9.MinimumWidth = 40
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "unite1"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N3"
            Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn10.HeaderText = "Qté 1"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Width = 58
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "libunite1"
            Me.DataGridViewTextBoxColumn11.HeaderText = ""
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Width = 19
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn12.DataPropertyName = "unite2"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewTextBoxColumn12.HeaderText = "Qté 2"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.ReadOnly = True
            Me.DataGridViewTextBoxColumn12.Width = 58
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn13.DataPropertyName = "libunite2"
            Me.DataGridViewTextBoxColumn13.HeaderText = ""
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            Me.DataGridViewTextBoxColumn13.Width = 19
            '
            'ColControle
            '
            Me.ColControle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColControle.HeaderText = "Contrôle"
            Me.ColControle.Image = Global.ControleTracabilite.My.Resources.Resources.controles
            Me.ColControle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.ColControle.Name = "ColControle"
            Me.ColControle.ReadOnly = True
            Me.ColControle.UseColumnTextForButtonValue = True
            Me.ColControle.Width = 52
            '
            'LotsBindingSource
            '
            Me.LotsBindingSource.DataMember = "ListeLots"
            Me.LotsBindingSource.DataSource = Me.EtatsDataset
            Me.LotsBindingSource.Sort = "nLot"
            '
            'EtatTracaLotTableAdapter
            '
            Me.EtatTracaLotTableAdapter.ClearBeforeFill = True
            '
            'ListeLotsTableAdapter
            '
            Me.ListeLotsTableAdapter.ClearBeforeFill = True
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomFamille"
            Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unite1"
            Me.DataGridViewTextBoxColumn4.HeaderText = "U1"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
            Me.DataGridViewTextBoxColumn5.HeaderText = "U2"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewDisableButtonColumn1
            '
            Me.DataGridViewDisableButtonColumn1.HeaderText = "Contrôle"
            Me.DataGridViewDisableButtonColumn1.Image = Global.ControleTracabilite.My.Resources.Resources.controles
            Me.DataGridViewDisableButtonColumn1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
            Me.DataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = True
            '
            'FrEtatTracaLot
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 419)
            Me.ControlBox = False
            Me.Controls.Add(Me.EtatTracaLotDataGridView)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrEtatTracaLot"
            Me.Text = "Etat Tracabilité par Transformation"
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            CType(Me.EtatTracaLotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatTracaLotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents cbLot As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents OKToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents EtatsDataset As ControleTracabilite.EtatsDataset
        Friend WithEvents EtatTracaLotBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents EtatTracaLotTableAdapter As ControleTracabilite.EtatsDatasetTableAdapters.EtatTracaLotTableAdapter
        Friend WithEvents EtatTracaLotDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents LotsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ListeLotsTableAdapter As ControleTracabilite.EtatsDatasetTableAdapters.ListeLotsTableAdapter
        Friend WithEvents BtImpr As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents DataGridViewDisableButtonColumn1 As ControleTracabilite.DataGridViewDisableButtonColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColControle As ControleTracabilite.DataGridViewDisableButtonColumn
    End Class
End Namespace
