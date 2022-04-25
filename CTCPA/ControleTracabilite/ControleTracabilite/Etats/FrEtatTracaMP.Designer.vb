Namespace Etats
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrEtatTracaMP
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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.EtatTracaMPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EtatsDataset = New ControleTracabilite.EtatsDataset
            Me.BtImpr = New System.Windows.Forms.ToolStripButton
            Me.TbFilter = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
            Me.cbMP = New System.Windows.Forms.ToolStripComboBox
            Me.OKToolStripButton = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.EtatTracaMPDataGridView = New System.Windows.Forms.DataGridView
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColControle = New ControleTracabilite.DataGridViewDisableButtonColumn
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewDisableButtonColumn1 = New ControleTracabilite.DataGridViewDisableButtonColumn
            Me.EtatTracaMPTableAdapter = New ControleTracabilite.EtatsDatasetTableAdapters.EtatTracaMPTableAdapter
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.ChkFourn = New System.Windows.Forms.CheckBox
            Me.dtpFin = New System.Windows.Forms.DateTimePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.dtpDeb = New System.Windows.Forms.DateTimePicker
            Me.Label3 = New System.Windows.Forms.Label
            Me.GcFiltrer = New Ascend.Windows.Forms.GradientCaption
            Me.CbFournisseur = New System.Windows.Forms.ComboBox
            Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            CType(Me.EtatTracaMPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatTracaMPDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.EtatTracaMPBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtImpr, Me.TbFilter, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cbMP, Me.OKToolStripButton, Me.TbFermer})
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
            'EtatTracaMPBindingSource
            '
            Me.EtatTracaMPBindingSource.DataMember = "EtatTracaMP"
            Me.EtatTracaMPBindingSource.DataSource = Me.EtatsDataset
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
            'TbFilter
            '
            Me.TbFilter.Checked = True
            Me.TbFilter.CheckOnClick = True
            Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
            Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFilter.Image = Global.ControleTracabilite.My.Resources.Resources.filter
            Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFilter.Name = "TbFilter"
            Me.TbFilter.Size = New System.Drawing.Size(23, 22)
            Me.TbFilter.Text = "Filtrer les bons de réception"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'ToolStripLabel1
            '
            Me.ToolStripLabel1.Name = "ToolStripLabel1"
            Me.ToolStripLabel1.Size = New System.Drawing.Size(100, 22)
            Me.ToolStripLabel1.Text = "Matière première:"
            '
            'cbMP
            '
            Me.cbMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbMP.DropDownWidth = 300
            Me.cbMP.Name = "cbMP"
            Me.cbMP.Size = New System.Drawing.Size(121, 25)
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
            'EtatTracaMPDataGridView
            '
            Me.EtatTracaMPDataGridView.AllowUserToAddRows = False
            Me.EtatTracaMPDataGridView.AllowUserToDeleteRows = False
            Me.EtatTracaMPDataGridView.AutoGenerateColumns = False
            Me.EtatTracaMPDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.EtatTracaMPDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.ColControle})
            Me.EtatTracaMPDataGridView.DataSource = Me.EtatTracaMPBindingSource
            Me.EtatTracaMPDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.EtatTracaMPDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.EtatTracaMPDataGridView.Name = "EtatTracaMPDataGridView"
            Me.EtatTracaMPDataGridView.ReadOnly = True
            Me.EtatTracaMPDataGridView.Size = New System.Drawing.Size(510, 394)
            Me.EtatTracaMPDataGridView.TabIndex = 4
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
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "nlotmp"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn3.HeaderText = "Lot BR"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Width = 65
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "datefacture"
            DataGridViewCellStyle2.Format = "d"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Width = 55
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "codeproduit"
            Me.DataGridViewTextBoxColumn8.HeaderText = "Code PF"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Width = 73
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "nlot"
            Me.DataGridViewTextBoxColumn7.HeaderText = "Lot Fab."
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Width = 71
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
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N3"
            Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle3
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
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "N3"
            Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle4
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
            'EtatTracaMPTableAdapter
            '
            Me.EtatTracaMPTableAdapter.ClearBeforeFill = True
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ProduitBindingSource
            '
            Me.ProduitBindingSource.DataMember = "Produit"
            Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'ProduitTableAdapter
            '
            Me.ProduitTableAdapter.ClearBeforeFill = True
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            Me.SplitContainer1.IsSplitterFixed = True
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.EtatTracaMPDataGridView)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(682, 394)
            Me.SplitContainer1.SplitterDistance = 510
            Me.SplitContainer1.TabIndex = 5
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.ChkFourn)
            Me.Panel1.Controls.Add(Me.dtpFin)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.dtpDeb)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.GcFiltrer)
            Me.Panel1.Controls.Add(Me.CbFournisseur)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(168, 394)
            Me.Panel1.TabIndex = 2
            '
            'ChkFourn
            '
            Me.ChkFourn.AutoSize = True
            Me.ChkFourn.Location = New System.Drawing.Point(3, 30)
            Me.ChkFourn.Name = "ChkFourn"
            Me.ChkFourn.Size = New System.Drawing.Size(146, 17)
            Me.ChkFourn.TabIndex = 11
            Me.ChkFourn.Text = "Filtrer pour le fournisseur :"
            Me.ChkFourn.UseVisualStyleBackColor = True
            '
            'dtpFin
            '
            Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFin.Location = New System.Drawing.Point(45, 108)
            Me.dtpFin.Name = "dtpFin"
            Me.dtpFin.Size = New System.Drawing.Size(89, 20)
            Me.dtpFin.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 112)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(26, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Au :"
            '
            'dtpDeb
            '
            Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDeb.Location = New System.Drawing.Point(45, 82)
            Me.dtpDeb.Name = "dtpDeb"
            Me.dtpDeb.Size = New System.Drawing.Size(89, 20)
            Me.dtpDeb.TabIndex = 8
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 86)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(27, 13)
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Du :"
            '
            'GcFiltrer
            '
            Me.GcFiltrer.Border = New Ascend.Border(0, 1, 0, 2)
            Me.GcFiltrer.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
            Me.GcFiltrer.Dock = System.Windows.Forms.DockStyle.Top
            Me.GcFiltrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GcFiltrer.GradientHighColor = System.Drawing.SystemColors.InactiveCaption
            Me.GcFiltrer.GradientLowColor = System.Drawing.SystemColors.Window
            Me.GcFiltrer.Image = Global.ControleTracabilite.My.Resources.Resources.filter
            Me.GcFiltrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.GcFiltrer.Location = New System.Drawing.Point(0, 0)
            Me.GcFiltrer.Name = "GcFiltrer"
            Me.GcFiltrer.Size = New System.Drawing.Size(168, 24)
            Me.GcFiltrer.TabIndex = 6
            Me.GcFiltrer.Text = "Filtrer"
            '
            'CbFournisseur
            '
            Me.CbFournisseur.DataSource = Me.EntrepriseBindingSource
            Me.CbFournisseur.DisplayMember = "Nom"
            Me.CbFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CbFournisseur.FormattingEnabled = True
            Me.CbFournisseur.Location = New System.Drawing.Point(3, 53)
            Me.CbFournisseur.Name = "CbFournisseur"
            Me.CbFournisseur.Size = New System.Drawing.Size(160, 21)
            Me.CbFournisseur.TabIndex = 1
            Me.CbFournisseur.ValueMember = "nEntreprise"
            '
            'EntrepriseBindingSource
            '
            Me.EntrepriseBindingSource.DataMember = "Entreprise"
            Me.EntrepriseBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'FrEtatTracaMP
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 419)
            Me.ControlBox = False
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrEtatTracaMP"
            Me.Text = "Etat Tracabilité par Matière Première"
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            CType(Me.EtatTracaMPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatTracaMPDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents cbMP As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents OKToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents EtatsDataset As ControleTracabilite.EtatsDataset
        Friend WithEvents EtatTracaMPBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents EtatTracaMPDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents BtImpr As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents DataGridViewDisableButtonColumn1 As ControleTracabilite.DataGridViewDisableButtonColumn
        Friend WithEvents EtatTracaMPTableAdapter As ControleTracabilite.EtatsDatasetTableAdapters.EtatTracaMPTableAdapter
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ChkFourn As System.Windows.Forms.CheckBox
        Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GcFiltrer As Ascend.Windows.Forms.GradientCaption
        Friend WithEvents CbFournisseur As System.Windows.Forms.ComboBox
        Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColControle As ControleTracabilite.DataGridViewDisableButtonColumn
    End Class
End Namespace
