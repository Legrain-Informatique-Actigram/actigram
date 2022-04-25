<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrlisteOrdresInsertion
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CriteresGroupBox = New System.Windows.Forms.GroupBox
        Me.FacturationMCheckBox = New System.Windows.Forms.CheckBox
        Me.DefiltrerButton = New System.Windows.Forms.Button
        Me.FiltrerButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DateParutionFinDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DateParutionDebutDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ChercherClientButton = New System.Windows.Forms.Button
        Me.FactureCheckBox = New System.Windows.Forms.CheckBox
        Me.RealiseCheckBox = New System.Windows.Forms.CheckBox
        Me.NomClientTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.AffichageEvenementDataGridView = New System.Windows.Forms.DataGridView
        Me.AffichageEvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PubDataSet = New AgriFact.PubDataSet
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.FermerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NouveauToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrefacturerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ImprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.AfficherCompteRenduToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.AffichageEvenementTableAdapter = New AgriFact.PubDataSetTableAdapters.AffichageEvenementTableAdapter
        Me.EvenementTableAdapter = New AgriFact.PubDataSetTableAdapters.EvenementTableAdapter
        Me.ProduitTableAdapter = New AgriFact.PubDataSetTableAdapters.ProduitTableAdapter
        Me.TVATableAdapter = New AgriFact.PubDataSetTableAdapters.TVATableAdapter
        Me.VBonLivraisonTableAdapter = New AgriFact.PubDataSetTableAdapters.VBonLivraisonTableAdapter
        Me.VBonLivraison_DetailTableAdapter = New AgriFact.PubDataSetTableAdapters.VBonLivraison_DetailTableAdapter
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
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NEvenementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateEvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RealiseDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FactureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FacturationMDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.AutreSupportDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.NomAuteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FormatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CouleurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContenuDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmplacementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RubriqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ObservationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CriteresGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.AffichageEvenementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AffichageEvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CriteresGroupBox
        '
        Me.CriteresGroupBox.Controls.Add(Me.FacturationMCheckBox)
        Me.CriteresGroupBox.Controls.Add(Me.DefiltrerButton)
        Me.CriteresGroupBox.Controls.Add(Me.FiltrerButton)
        Me.CriteresGroupBox.Controls.Add(Me.GroupBox1)
        Me.CriteresGroupBox.Controls.Add(Me.ChercherClientButton)
        Me.CriteresGroupBox.Controls.Add(Me.FactureCheckBox)
        Me.CriteresGroupBox.Controls.Add(Me.RealiseCheckBox)
        Me.CriteresGroupBox.Controls.Add(Me.NomClientTextBox)
        Me.CriteresGroupBox.Controls.Add(Me.Label1)
        Me.CriteresGroupBox.Location = New System.Drawing.Point(12, 28)
        Me.CriteresGroupBox.Name = "CriteresGroupBox"
        Me.CriteresGroupBox.Size = New System.Drawing.Size(863, 121)
        Me.CriteresGroupBox.TabIndex = 1
        Me.CriteresGroupBox.TabStop = False
        Me.CriteresGroupBox.Text = "Critères"
        '
        'FacturationMCheckBox
        '
        Me.FacturationMCheckBox.AutoSize = True
        Me.FacturationMCheckBox.Location = New System.Drawing.Point(530, 78)
        Me.FacturationMCheckBox.Name = "FacturationMCheckBox"
        Me.FacturationMCheckBox.Size = New System.Drawing.Size(129, 17)
        Me.FacturationMCheckBox.TabIndex = 8
        Me.FacturationMCheckBox.Text = "Facturation mensuelle"
        Me.FacturationMCheckBox.ThreeState = True
        Me.FacturationMCheckBox.UseVisualStyleBackColor = True
        '
        'DefiltrerButton
        '
        Me.DefiltrerButton.Location = New System.Drawing.Point(701, 92)
        Me.DefiltrerButton.Name = "DefiltrerButton"
        Me.DefiltrerButton.Size = New System.Drawing.Size(75, 23)
        Me.DefiltrerButton.TabIndex = 7
        Me.DefiltrerButton.Text = "Défiltrer"
        Me.DefiltrerButton.UseVisualStyleBackColor = True
        '
        'FiltrerButton
        '
        Me.FiltrerButton.Location = New System.Drawing.Point(782, 92)
        Me.FiltrerButton.Name = "FiltrerButton"
        Me.FiltrerButton.Size = New System.Drawing.Size(75, 23)
        Me.FiltrerButton.TabIndex = 6
        Me.FiltrerButton.Text = "Filtrer"
        Me.FiltrerButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateParutionFinDateTimePicker)
        Me.GroupBox1.Controls.Add(Me.DateParutionDebutDateTimePicker)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(331, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(169, 79)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date parution"
        '
        'DateParutionFinDateTimePicker
        '
        Me.DateParutionFinDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateParutionFinDateTimePicker.Location = New System.Drawing.Point(39, 46)
        Me.DateParutionFinDateTimePicker.Name = "DateParutionFinDateTimePicker"
        Me.DateParutionFinDateTimePicker.ShowCheckBox = True
        Me.DateParutionFinDateTimePicker.Size = New System.Drawing.Size(113, 20)
        Me.DateParutionFinDateTimePicker.TabIndex = 3
        '
        'DateParutionDebutDateTimePicker
        '
        Me.DateParutionDebutDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateParutionDebutDateTimePicker.Location = New System.Drawing.Point(39, 20)
        Me.DateParutionDebutDateTimePicker.Name = "DateParutionDebutDateTimePicker"
        Me.DateParutionDebutDateTimePicker.ShowCheckBox = True
        Me.DateParutionDebutDateTimePicker.Size = New System.Drawing.Size(113, 20)
        Me.DateParutionDebutDateTimePicker.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "au :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Du :"
        '
        'ChercherClientButton
        '
        Me.ChercherClientButton.Image = Global.AgriFact.My.Resources.Resources.search
        Me.ChercherClientButton.Location = New System.Drawing.Point(280, 26)
        Me.ChercherClientButton.Name = "ChercherClientButton"
        Me.ChercherClientButton.Size = New System.Drawing.Size(30, 23)
        Me.ChercherClientButton.TabIndex = 2
        Me.ChercherClientButton.UseVisualStyleBackColor = True
        '
        'FactureCheckBox
        '
        Me.FactureCheckBox.AutoSize = True
        Me.FactureCheckBox.Location = New System.Drawing.Point(530, 32)
        Me.FactureCheckBox.Name = "FactureCheckBox"
        Me.FactureCheckBox.Size = New System.Drawing.Size(62, 17)
        Me.FactureCheckBox.TabIndex = 5
        Me.FactureCheckBox.Text = "Facturé"
        Me.FactureCheckBox.ThreeState = True
        Me.FactureCheckBox.UseVisualStyleBackColor = True
        '
        'RealiseCheckBox
        '
        Me.RealiseCheckBox.AutoSize = True
        Me.RealiseCheckBox.Location = New System.Drawing.Point(530, 55)
        Me.RealiseCheckBox.Name = "RealiseCheckBox"
        Me.RealiseCheckBox.Size = New System.Drawing.Size(61, 17)
        Me.RealiseCheckBox.TabIndex = 3
        Me.RealiseCheckBox.Text = "Réalisé"
        Me.RealiseCheckBox.ThreeState = True
        Me.RealiseCheckBox.UseVisualStyleBackColor = True
        '
        'NomClientTextBox
        '
        Me.NomClientTextBox.Location = New System.Drawing.Point(51, 28)
        Me.NomClientTextBox.Name = "NomClientTextBox"
        Me.NomClientTextBox.Size = New System.Drawing.Size(223, 20)
        Me.NomClientTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client :"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 556)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(941, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'AffichageEvenementDataGridView
        '
        Me.AffichageEvenementDataGridView.AllowUserToAddRows = False
        Me.AffichageEvenementDataGridView.AllowUserToDeleteRows = False
        Me.AffichageEvenementDataGridView.AutoGenerateColumns = False
        Me.AffichageEvenementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AffichageEvenementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEvenementDataGridViewTextBoxColumn, Me.DateEvDataGridViewTextBoxColumn, Me.NomClientDataGridViewTextBoxColumn, Me.PrixHTDataGridViewTextBoxColumn, Me.RealiseDataGridViewCheckBoxColumn, Me.FactureDataGridViewCheckBoxColumn, Me.FacturationMDataGridViewCheckBoxColumn, Me.AutreSupportDataGridViewCheckBoxColumn, Me.NomAuteurDataGridViewTextBoxColumn, Me.FormatDataGridViewTextBoxColumn, Me.CouleurDataGridViewTextBoxColumn, Me.ContenuDataGridViewTextBoxColumn, Me.EmplacementDataGridViewTextBoxColumn, Me.RubriqueDataGridViewTextBoxColumn, Me.ObservationDataGridViewTextBoxColumn})
        Me.AffichageEvenementDataGridView.DataSource = Me.AffichageEvenementBindingSource
        Me.AffichageEvenementDataGridView.Location = New System.Drawing.Point(12, 155)
        Me.AffichageEvenementDataGridView.Name = "AffichageEvenementDataGridView"
        Me.AffichageEvenementDataGridView.ReadOnly = True
        Me.AffichageEvenementDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AffichageEvenementDataGridView.Size = New System.Drawing.Size(863, 368)
        Me.AffichageEvenementDataGridView.TabIndex = 3
        '
        'AffichageEvenementBindingSource
        '
        Me.AffichageEvenementBindingSource.DataMember = "AffichageEvenement"
        Me.AffichageEvenementBindingSource.DataSource = Me.PubDataSet
        Me.AffichageEvenementBindingSource.Sort = "DateEv Desc"
        '
        'PubDataSet
        '
        Me.PubDataSet.DataSetName = "PubDataSet"
        Me.PubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerToolStripButton, Me.NouveauToolStripButton, Me.SupprimerToolStripButton, Me.ToolStripSeparator1, Me.PrefacturerToolStripButton, Me.ToolStripSeparator2, Me.ImprimerToolStripButton, Me.ToolStripSeparator3, Me.AfficherCompteRenduToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(941, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FermerToolStripButton
        '
        Me.FermerToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.FermerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FermerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.FermerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FermerToolStripButton.Name = "FermerToolStripButton"
        Me.FermerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FermerToolStripButton.Text = "Fermer"
        '
        'NouveauToolStripButton
        '
        Me.NouveauToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NouveauToolStripButton.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.NouveauToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NouveauToolStripButton.Name = "NouveauToolStripButton"
        Me.NouveauToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NouveauToolStripButton.Text = "Nouveau"
        '
        'SupprimerToolStripButton
        '
        Me.SupprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.SupprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerToolStripButton.Name = "SupprimerToolStripButton"
        Me.SupprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SupprimerToolStripButton.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrefacturerToolStripButton
        '
        Me.PrefacturerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrefacturerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.Factures
        Me.PrefacturerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrefacturerToolStripButton.Name = "PrefacturerToolStripButton"
        Me.PrefacturerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrefacturerToolStripButton.Text = "Pré-facturer"
        Me.PrefacturerToolStripButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ImprimerToolStripButton
        '
        Me.ImprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.impr
        Me.ImprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimerToolStripButton.Name = "ImprimerToolStripButton"
        Me.ImprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimerToolStripButton.Text = "Imprimer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'AfficherCompteRenduToolStripButton
        '
        Me.AfficherCompteRenduToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AfficherCompteRenduToolStripButton.Image = Global.AgriFact.My.Resources.Resources.EditTableHS
        Me.AfficherCompteRenduToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AfficherCompteRenduToolStripButton.Name = "AfficherCompteRenduToolStripButton"
        Me.AfficherCompteRenduToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AfficherCompteRenduToolStripButton.Text = "Afficher le compte rendu"
        '
        'AffichageEvenementTableAdapter
        '
        Me.AffichageEvenementTableAdapter.ClearBeforeFill = True
        '
        'EvenementTableAdapter
        '
        Me.EvenementTableAdapter.ClearBeforeFill = True
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'TVATableAdapter
        '
        Me.TVATableAdapter.ClearBeforeFill = True
        '
        'VBonLivraisonTableAdapter
        '
        Me.VBonLivraisonTableAdapter.ClearBeforeFill = True
        '
        'VBonLivraison_DetailTableAdapter
        '
        Me.VBonLivraison_DetailTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nEvenement"
        Me.DataGridViewTextBoxColumn1.HeaderText = "nEvenement"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TypeEv"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn2.HeaderText = "TypeEv"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DateCreation"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "d"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn3.HeaderText = "DateCreation"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Origine"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn4.HeaderText = "Origine"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "nOrigine"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn5.HeaderText = "nOrigine"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "nImage"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn6.HeaderText = "nImage"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Dep"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn7.HeaderText = "Dep"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Type"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn8.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DateEv"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn9.HeaderText = "DateEv"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Priorite"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn10.HeaderText = "Priorite"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Duree"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "C2"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn11.HeaderText = "Duree"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "UniteDuree"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn12.HeaderText = "UniteDuree"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "nPersonneAuteur"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn13.HeaderText = "nPersonneAuteur"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 200
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "nPersonneDestinataire"
        Me.DataGridViewTextBoxColumn14.HeaderText = "nPersonneDestinataire"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "nClient"
        Me.DataGridViewTextBoxColumn15.HeaderText = "nClient"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "ProduitsPresentes"
        Me.DataGridViewTextBoxColumn17.HeaderText = "ProduitsPresentes"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Observation"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Dossier"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Dossier"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "SuiteADonner"
        Me.DataGridViewTextBoxColumn20.HeaderText = "SuiteADonner"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "DateContact"
        Me.DataGridViewTextBoxColumn21.HeaderText = "DateContact"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Conclusion"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Conclusion"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Format"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Format"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Couleur"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Couleur"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Contenu"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Contenu"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Emplacement"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Emplacement"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "Rubrique"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Rubrique"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "PrixHT"
        Me.DataGridViewTextBoxColumn28.HeaderText = "PrixHT"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "FacturationObs"
        Me.DataGridViewTextBoxColumn29.HeaderText = "FacturationObs"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "nPreFacturation"
        Me.DataGridViewTextBoxColumn30.HeaderText = "nPreFacturation"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "DatePreFacturation"
        Me.DataGridViewTextBoxColumn31.HeaderText = "DatePreFacturation"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "NomClient"
        Me.DataGridViewTextBoxColumn32.HeaderText = "NomClient"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "NomAuteur"
        Me.DataGridViewTextBoxColumn33.HeaderText = "NomAuteur"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "NomDestinataire"
        Me.DataGridViewTextBoxColumn34.HeaderText = "NomDestinataire"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        '
        'NEvenementDataGridViewTextBoxColumn
        '
        Me.NEvenementDataGridViewTextBoxColumn.DataPropertyName = "nEvenement"
        Me.NEvenementDataGridViewTextBoxColumn.HeaderText = "nEvenement"
        Me.NEvenementDataGridViewTextBoxColumn.Name = "NEvenementDataGridViewTextBoxColumn"
        Me.NEvenementDataGridViewTextBoxColumn.ReadOnly = True
        Me.NEvenementDataGridViewTextBoxColumn.Visible = False
        '
        'DateEvDataGridViewTextBoxColumn
        '
        Me.DateEvDataGridViewTextBoxColumn.DataPropertyName = "DateEv"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DateEvDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateEvDataGridViewTextBoxColumn.HeaderText = "Date parution"
        Me.DateEvDataGridViewTextBoxColumn.Name = "DateEvDataGridViewTextBoxColumn"
        Me.DateEvDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateEvDataGridViewTextBoxColumn.Width = 80
        '
        'NomClientDataGridViewTextBoxColumn
        '
        Me.NomClientDataGridViewTextBoxColumn.DataPropertyName = "NomClient"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NomClientDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.NomClientDataGridViewTextBoxColumn.HeaderText = "Client"
        Me.NomClientDataGridViewTextBoxColumn.Name = "NomClientDataGridViewTextBoxColumn"
        Me.NomClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.NomClientDataGridViewTextBoxColumn.Width = 200
        '
        'PrixHTDataGridViewTextBoxColumn
        '
        Me.PrixHTDataGridViewTextBoxColumn.DataPropertyName = "PrixHT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PrixHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrixHTDataGridViewTextBoxColumn.HeaderText = "Prix HT"
        Me.PrixHTDataGridViewTextBoxColumn.Name = "PrixHTDataGridViewTextBoxColumn"
        Me.PrixHTDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixHTDataGridViewTextBoxColumn.Width = 80
        '
        'RealiseDataGridViewCheckBoxColumn
        '
        Me.RealiseDataGridViewCheckBoxColumn.DataPropertyName = "Realise"
        Me.RealiseDataGridViewCheckBoxColumn.HeaderText = "Réalisé"
        Me.RealiseDataGridViewCheckBoxColumn.Name = "RealiseDataGridViewCheckBoxColumn"
        Me.RealiseDataGridViewCheckBoxColumn.ReadOnly = True
        Me.RealiseDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RealiseDataGridViewCheckBoxColumn.Width = 60
        '
        'FactureDataGridViewCheckBoxColumn
        '
        Me.FactureDataGridViewCheckBoxColumn.DataPropertyName = "Facture"
        Me.FactureDataGridViewCheckBoxColumn.HeaderText = "Facturé"
        Me.FactureDataGridViewCheckBoxColumn.Name = "FactureDataGridViewCheckBoxColumn"
        Me.FactureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.FactureDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FactureDataGridViewCheckBoxColumn.Width = 80
        '
        'FacturationMDataGridViewCheckBoxColumn
        '
        Me.FacturationMDataGridViewCheckBoxColumn.DataPropertyName = "FacturationM"
        Me.FacturationMDataGridViewCheckBoxColumn.HeaderText = "Facturation mensuelle"
        Me.FacturationMDataGridViewCheckBoxColumn.Name = "FacturationMDataGridViewCheckBoxColumn"
        Me.FacturationMDataGridViewCheckBoxColumn.ReadOnly = True
        Me.FacturationMDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FacturationMDataGridViewCheckBoxColumn.Width = 80
        '
        'AutreSupportDataGridViewCheckBoxColumn
        '
        Me.AutreSupportDataGridViewCheckBoxColumn.DataPropertyName = "AutreSupport"
        Me.AutreSupportDataGridViewCheckBoxColumn.HeaderText = "Autre support"
        Me.AutreSupportDataGridViewCheckBoxColumn.Name = "AutreSupportDataGridViewCheckBoxColumn"
        Me.AutreSupportDataGridViewCheckBoxColumn.ReadOnly = True
        Me.AutreSupportDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.AutreSupportDataGridViewCheckBoxColumn.Width = 80
        '
        'NomAuteurDataGridViewTextBoxColumn
        '
        Me.NomAuteurDataGridViewTextBoxColumn.DataPropertyName = "NomAuteur"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NomAuteurDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.NomAuteurDataGridViewTextBoxColumn.HeaderText = "Commercial"
        Me.NomAuteurDataGridViewTextBoxColumn.Name = "NomAuteurDataGridViewTextBoxColumn"
        Me.NomAuteurDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FormatDataGridViewTextBoxColumn
        '
        Me.FormatDataGridViewTextBoxColumn.DataPropertyName = "Format"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FormatDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.FormatDataGridViewTextBoxColumn.HeaderText = "Format"
        Me.FormatDataGridViewTextBoxColumn.Name = "FormatDataGridViewTextBoxColumn"
        Me.FormatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CouleurDataGridViewTextBoxColumn
        '
        Me.CouleurDataGridViewTextBoxColumn.DataPropertyName = "Couleur"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CouleurDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.CouleurDataGridViewTextBoxColumn.HeaderText = "Couleur"
        Me.CouleurDataGridViewTextBoxColumn.Name = "CouleurDataGridViewTextBoxColumn"
        Me.CouleurDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ContenuDataGridViewTextBoxColumn
        '
        Me.ContenuDataGridViewTextBoxColumn.DataPropertyName = "Contenu"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ContenuDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.ContenuDataGridViewTextBoxColumn.HeaderText = "Contenu"
        Me.ContenuDataGridViewTextBoxColumn.Name = "ContenuDataGridViewTextBoxColumn"
        Me.ContenuDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmplacementDataGridViewTextBoxColumn
        '
        Me.EmplacementDataGridViewTextBoxColumn.DataPropertyName = "Emplacement"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmplacementDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.EmplacementDataGridViewTextBoxColumn.HeaderText = "Emplacement"
        Me.EmplacementDataGridViewTextBoxColumn.Name = "EmplacementDataGridViewTextBoxColumn"
        Me.EmplacementDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RubriqueDataGridViewTextBoxColumn
        '
        Me.RubriqueDataGridViewTextBoxColumn.DataPropertyName = "Rubrique"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RubriqueDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.RubriqueDataGridViewTextBoxColumn.HeaderText = "Rubrique"
        Me.RubriqueDataGridViewTextBoxColumn.Name = "RubriqueDataGridViewTextBoxColumn"
        Me.RubriqueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ObservationDataGridViewTextBoxColumn
        '
        Me.ObservationDataGridViewTextBoxColumn.DataPropertyName = "Observation"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ObservationDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.ObservationDataGridViewTextBoxColumn.HeaderText = "Observation"
        Me.ObservationDataGridViewTextBoxColumn.Name = "ObservationDataGridViewTextBoxColumn"
        Me.ObservationDataGridViewTextBoxColumn.ReadOnly = True
        Me.ObservationDataGridViewTextBoxColumn.Width = 150
        '
        'FrlisteOrdresInsertion
        '
        Me.AcceptButton = Me.FiltrerButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 578)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.AffichageEvenementDataGridView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CriteresGroupBox)
        Me.KeyPreview = True
        Me.Name = "FrlisteOrdresInsertion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste des ordres d'insertion"
        Me.CriteresGroupBox.ResumeLayout(False)
        Me.CriteresGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.AffichageEvenementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AffichageEvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PubDataSet As AgriFact.PubDataSet
    Friend WithEvents AffichageEvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AffichageEvenementTableAdapter As AgriFact.PubDataSetTableAdapters.AffichageEvenementTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CriteresGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ChercherClientButton As System.Windows.Forms.Button
    Friend WithEvents NomClientTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateParutionFinDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateParutionDebutDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RealiseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FactureCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AffichageEvenementDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DefiltrerButton As System.Windows.Forms.Button
    Friend WithEvents FiltrerButton As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NouveauToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EvenementTableAdapter As AgriFact.PubDataSetTableAdapters.EvenementTableAdapter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AfficherCompteRenduToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrefacturerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProduitTableAdapter As AgriFact.PubDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents TVATableAdapter As AgriFact.PubDataSetTableAdapters.TVATableAdapter
    Friend WithEvents VBonLivraisonTableAdapter As AgriFact.PubDataSetTableAdapters.VBonLivraisonTableAdapter
    Friend WithEvents VBonLivraison_DetailTableAdapter As AgriFact.PubDataSetTableAdapters.VBonLivraison_DetailTableAdapter
    Friend WithEvents FacturationMCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ImprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FermerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NEvenementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateEvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixHTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RealiseDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FactureDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FacturationMDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AutreSupportDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NomAuteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CouleurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContenuDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmplacementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RubriqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
