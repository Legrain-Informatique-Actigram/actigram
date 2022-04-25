<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeReglement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeReglement))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.RemiseBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbSearch = New System.Windows.Forms.ToolStripButton
        Me.ReglDataGridView = New System.Windows.Forms.DataGridView
        Me.ReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNew = New System.Windows.Forms.ToolStripButton
        Me.TbImprimer = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbFiltrer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbDeposer = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ReglementTA = New AgriFact.DsPiecesTableAdapters.ReglementTA
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.NReglementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateReglement = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nMode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payeur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BanqueClient = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Montant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Depose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColFiller = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ReglDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RemiseBindingNavigatorSaveItem
        '
        Me.RemiseBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RemiseBindingNavigatorSaveItem.Image = CType(resources.GetObject("RemiseBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.RemiseBindingNavigatorSaveItem.Name = "RemiseBindingNavigatorSaveItem"
        Me.RemiseBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.RemiseBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbSearch
        '
        Me.TbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSearch.Image = Global.AgriFact.My.Resources.Resources.search
        Me.TbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSearch.Name = "TbSearch"
        Me.TbSearch.Size = New System.Drawing.Size(23, 22)
        Me.TbSearch.Text = "Rechercher..."
        '
        'ReglDataGridView
        '
        Me.ReglDataGridView.AllowUserToAddRows = False
        Me.ReglDataGridView.AllowUserToDeleteRows = False
        Me.ReglDataGridView.AutoGenerateColumns = False
        Me.ReglDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.NReglementDataGridViewTextBoxColumn, Me.DateReglement, Me.nMode, Me.Payeur, Me.BanqueClient, Me.Observation, Me.Montant, Me.Depose, Me.ColFiller})
        Me.ReglDataGridView.DataSource = Me.ReglementBindingSource
        Me.ReglDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReglDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ReglDataGridView.Name = "ReglDataGridView"
        Me.ReglDataGridView.ReadOnly = True
        Me.ReglDataGridView.Size = New System.Drawing.Size(575, 304)
        Me.ReglDataGridView.TabIndex = 1
        '
        'ReglementBindingSource
        '
        Me.ReglementBindingSource.DataMember = "Reglement"
        Me.ReglementBindingSource.DataSource = Me.DsPieces
        Me.ReglementBindingSource.Filter = "Depose=False"
        Me.ReglementBindingSource.Sort = "DateReglement Desc"
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemiseBindingNavigatorSaveItem, Me.TbNew, Me.ToolStripSeparator1, Me.TbImprimer, Me.TbSearch, Me.TbClose, Me.TbFiltrer, Me.ToolStripSeparator2, Me.TbDeposer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(575, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbNew
        '
        Me.TbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNew.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNew.Name = "TbNew"
        Me.TbNew.Size = New System.Drawing.Size(23, 22)
        Me.TbNew.Text = "Nouveau réglement"
        '
        'TbImprimer
        '
        Me.TbImprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImprimer.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimer.Name = "TbImprimer"
        Me.TbImprimer.Size = New System.Drawing.Size(23, 22)
        Me.TbImprimer.Text = "Imprimer la liste"
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
        'TbFiltrer
        '
        Me.TbFiltrer.Checked = True
        Me.TbFiltrer.CheckOnClick = True
        Me.TbFiltrer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFiltrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFiltrer.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbFiltrer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFiltrer.Name = "TbFiltrer"
        Me.TbFiltrer.Size = New System.Drawing.Size(23, 22)
        Me.TbFiltrer.Text = "Appliquer le filtre"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TbDeposer
        '
        Me.TbDeposer.Image = Global.AgriFact.My.Resources.Resources.RoutingSlipHS
        Me.TbDeposer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDeposer.Name = "TbDeposer"
        Me.TbDeposer.Size = New System.Drawing.Size(70, 22)
        Me.TbDeposer.Text = "Déposer"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbTotal, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 329)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(575, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbTotal
        '
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(511, 17)
        Me.lbTotal.Spring = True
        Me.lbTotal.Text = "Total : 99 999 999,99€"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(49, 17)
        Me.ToolStripStatusLabel2.Text = "              "
        '
        'ReglementTA
        '
        Me.ReglementTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Civilite"
        DataGridViewCellStyle3.Format = "d"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Civ."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        DataGridViewCellStyle4.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CodePostal"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Code Postal"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Observation"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Montant"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Montant"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.HeaderText = ""
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "nReglement"
        Me.DataGridViewTextBoxColumn8.HeaderText = "nReglement"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DateReglement"
        Me.DataGridViewTextBoxColumn9.HeaderText = "DateReglement"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DateDepot"
        Me.DataGridViewTextBoxColumn10.HeaderText = "DateDepot"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "nEntreprise"
        Me.DataGridViewTextBoxColumn11.HeaderText = "nEntreprise"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "nMode"
        Me.DataGridViewTextBoxColumn12.HeaderText = "nMode"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "nCheque"
        Me.DataGridViewTextBoxColumn13.HeaderText = "nCheque"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "ModeReglement"
        Me.DataGridViewTextBoxColumn14.HeaderText = "ModeReglement"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Observation"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Montant"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Perte"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Perte"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Profit"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Profit"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "TxEscompte"
        Me.DataGridViewTextBoxColumn19.HeaderText = "TxEscompte"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "MontantEscompte"
        Me.DataGridViewTextBoxColumn20.HeaderText = "MontantEscompte"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "DateExportCompta"
        Me.DataGridViewTextBoxColumn21.HeaderText = "DateExportCompta"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "BanqueClient"
        Me.DataGridViewTextBoxColumn22.HeaderText = "BanqueClient"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Payeur"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Payeur"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'ColSel
        '
        Me.ColSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColSel.HeaderText = ""
        Me.ColSel.Name = "ColSel"
        Me.ColSel.ReadOnly = True
        Me.ColSel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColSel.Width = 20
        '
        'NReglementDataGridViewTextBoxColumn
        '
        Me.NReglementDataGridViewTextBoxColumn.DataPropertyName = "nReglement"
        Me.NReglementDataGridViewTextBoxColumn.HeaderText = "nReglement"
        Me.NReglementDataGridViewTextBoxColumn.Name = "NReglementDataGridViewTextBoxColumn"
        Me.NReglementDataGridViewTextBoxColumn.ReadOnly = True
        Me.NReglementDataGridViewTextBoxColumn.Visible = False
        '
        'DateReglement
        '
        Me.DateReglement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateReglement.DataPropertyName = "DateReglement"
        DataGridViewCellStyle1.Format = "d"
        Me.DateReglement.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateReglement.HeaderText = "Date"
        Me.DateReglement.Name = "DateReglement"
        Me.DateReglement.ReadOnly = True
        Me.DateReglement.Width = 55
        '
        'nMode
        '
        Me.nMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nMode.DataPropertyName = "nMode"
        Me.nMode.HeaderText = "Type"
        Me.nMode.Name = "nMode"
        Me.nMode.ReadOnly = True
        Me.nMode.Width = 56
        '
        'Payeur
        '
        Me.Payeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Payeur.DataPropertyName = "Payeur"
        Me.Payeur.HeaderText = "Payeur"
        Me.Payeur.Name = "Payeur"
        Me.Payeur.ReadOnly = True
        '
        'BanqueClient
        '
        Me.BanqueClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BanqueClient.DataPropertyName = "BanqueClient"
        Me.BanqueClient.HeaderText = "Banque"
        Me.BanqueClient.Name = "BanqueClient"
        Me.BanqueClient.ReadOnly = True
        Me.BanqueClient.Width = 69
        '
        'Observation
        '
        Me.Observation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Observation.DataPropertyName = "Observation"
        Me.Observation.HeaderText = "Observation"
        Me.Observation.Name = "Observation"
        Me.Observation.ReadOnly = True
        Me.Observation.Width = 89
        '
        'Montant
        '
        Me.Montant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Montant.DataPropertyName = "Montant"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.Montant.DefaultCellStyle = DataGridViewCellStyle2
        Me.Montant.HeaderText = "Montant"
        Me.Montant.Name = "Montant"
        Me.Montant.ReadOnly = True
        Me.Montant.Width = 71
        '
        'Depose
        '
        Me.Depose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Depose.DataPropertyName = "Depose"
        Me.Depose.HeaderText = "Deposé"
        Me.Depose.Name = "Depose"
        Me.Depose.ReadOnly = True
        Me.Depose.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Depose.Width = 50
        '
        'ColFiller
        '
        Me.ColFiller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColFiller.HeaderText = ""
        Me.ColFiller.Name = "ColFiller"
        Me.ColFiller.ReadOnly = True
        Me.ColFiller.Width = 5
        '
        'FrListeReglement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.ReglDataGridView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeReglement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des réglements clients"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ReglDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RemiseBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReglDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents ReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbFiltrer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbDeposer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ReglementTA As AgriFact.DsPiecesTableAdapters.ReglementTA
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NReglementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReglement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BanqueClient As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Montant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Depose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColFiller As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
