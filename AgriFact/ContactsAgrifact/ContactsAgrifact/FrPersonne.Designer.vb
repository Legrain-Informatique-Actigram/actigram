﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrPersonne
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
        Me.components = New System.ComponentModel.Container()
        Dim NomLabel As System.Windows.Forms.Label
        Dim AdresseLabel As System.Windows.Forms.Label
        Dim CodePostalLabel As System.Windows.Forms.Label
        Dim VilleLabel As System.Windows.Forms.Label
        Dim EMailLabel As System.Windows.Forms.Label
        Dim PrenomLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact()
        Me.AdresseTextBox = New System.Windows.Forms.TextBox()
        Me.ObservationsTextBox = New System.Windows.Forms.TextBox()
        Me.TelephoneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TelephoneDataGridView = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpInters = New System.Windows.Forms.TabPage()
        Me.EvenementDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.lbTotalInterLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbTotalInter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tpTel = New System.Windows.Forms.TabPage()
        Me.tpCoord = New System.Windows.Forms.TabPage()
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox()
        Me.LnkMail = New System.Windows.Forms.LinkLabel()
        Me.tpObs = New System.Windows.Forms.TabPage()
        Me.LnkEntreprise = New System.Windows.Forms.LinkLabel()
        Me.PersonneTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter()
        Me.TelephoneTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.TelephoneTableAdapter()
        Me.EntrepriseTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtClose = New System.Windows.Forms.ToolStripButton()
        Me.TbIntervention = New System.Windows.Forms.ToolStripButton()
        Me.TbCopyCoords = New System.Windows.Forms.ToolStripButton()
        Me.NomTextBox = New System.Windows.Forms.TextBox()
        Me.PrenomTextBox = New System.Windows.Forms.TextBox()
        Me.EvenementTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter()
        Me.NPersonneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        NomLabel = New System.Windows.Forms.Label()
        AdresseLabel = New System.Windows.Forms.Label()
        CodePostalLabel = New System.Windows.Forms.Label()
        VilleLabel = New System.Windows.Forms.Label()
        EMailLabel = New System.Windows.Forms.Label()
        PrenomLabel = New System.Windows.Forms.Label()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpInters.SuspendLayout()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.tpTel.SuspendLayout()
        Me.tpCoord.SuspendLayout()
        Me.tpObs.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NomLabel
        '
        NomLabel.AutoSize = True
        NomLabel.Location = New System.Drawing.Point(12, 28)
        NomLabel.Name = "NomLabel"
        NomLabel.Size = New System.Drawing.Size(32, 13)
        NomLabel.TabIndex = 2
        NomLabel.Text = "Nom:"
        '
        'AdresseLabel
        '
        AdresseLabel.AutoSize = True
        AdresseLabel.Location = New System.Drawing.Point(6, 3)
        AdresseLabel.Name = "AdresseLabel"
        AdresseLabel.Size = New System.Drawing.Size(48, 13)
        AdresseLabel.TabIndex = 4
        AdresseLabel.Text = "Adresse:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(6, 144)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(24, 13)
        CodePostalLabel.TabIndex = 6
        CodePostalLabel.Text = "CP:"
        '
        'VilleLabel
        '
        VilleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        VilleLabel.AutoSize = True
        VilleLabel.Location = New System.Drawing.Point(113, 144)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(29, 13)
        VilleLabel.TabIndex = 8
        VilleLabel.Text = "Ville:"
        '
        'EMailLabel
        '
        EMailLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        EMailLabel.AutoSize = True
        EMailLabel.Location = New System.Drawing.Point(6, 170)
        EMailLabel.Name = "EMailLabel"
        EMailLabel.Size = New System.Drawing.Size(36, 13)
        EMailLabel.TabIndex = 10
        EMailLabel.Text = "EMail:"
        '
        'PrenomLabel
        '
        PrenomLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        PrenomLabel.AutoSize = True
        PrenomLabel.Location = New System.Drawing.Point(381, 29)
        PrenomLabel.Name = "PrenomLabel"
        PrenomLabel.Size = New System.Drawing.Size(46, 13)
        PrenomLabel.TabIndex = 14
        PrenomLabel.Text = "Prenom:"
        '
        'PersonneBindingSource
        '
        Me.PersonneBindingSource.DataMember = "Personne"
        Me.PersonneBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AdresseTextBox
        '
        Me.AdresseTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdresseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "Adresse", True))
        Me.AdresseTextBox.Location = New System.Drawing.Point(9, 19)
        Me.AdresseTextBox.Multiline = True
        Me.AdresseTextBox.Name = "AdresseTextBox"
        Me.AdresseTextBox.ReadOnly = True
        Me.AdresseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AdresseTextBox.Size = New System.Drawing.Size(531, 116)
        Me.AdresseTextBox.TabIndex = 5
        '
        'ObservationsTextBox
        '
        Me.ObservationsTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.ObservationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "Observations", True))
        Me.ObservationsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObservationsTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ObservationsTextBox.Multiline = True
        Me.ObservationsTextBox.Name = "ObservationsTextBox"
        Me.ObservationsTextBox.ReadOnly = True
        Me.ObservationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ObservationsTextBox.Size = New System.Drawing.Size(550, 195)
        Me.ObservationsTextBox.TabIndex = 13
        '
        'TelephoneBindingSource
        '
        Me.TelephoneBindingSource.DataMember = "FK_Telephone_Personne"
        Me.TelephoneBindingSource.DataSource = Me.PersonneBindingSource
        Me.TelephoneBindingSource.Filter = "Numero is not null AND Numero<>''"
        '
        'TelephoneDataGridView
        '
        Me.TelephoneDataGridView.AllowUserToAddRows = False
        Me.TelephoneDataGridView.AllowUserToDeleteRows = False
        Me.TelephoneDataGridView.AutoGenerateColumns = False
        Me.TelephoneDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.TelephoneDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TelephoneDataGridView.ColumnHeadersVisible = False
        Me.TelephoneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NPersonneDataGridViewTextBoxColumn, Me.Type, Me.Numero})
        Me.TelephoneDataGridView.DataSource = Me.TelephoneBindingSource
        Me.TelephoneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelephoneDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.TelephoneDataGridView.Name = "TelephoneDataGridView"
        Me.TelephoneDataGridView.ReadOnly = True
        Me.TelephoneDataGridView.Size = New System.Drawing.Size(544, 189)
        Me.TelephoneDataGridView.TabIndex = 14
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpInters)
        Me.TabControl1.Controls.Add(Me.tpTel)
        Me.TabControl1.Controls.Add(Me.tpCoord)
        Me.TabControl1.Controls.Add(Me.tpObs)
        Me.TabControl1.Location = New System.Drawing.Point(0, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(558, 221)
        Me.TabControl1.TabIndex = 17
        '
        'tpInters
        '
        Me.tpInters.Controls.Add(Me.EvenementDataGridView)
        Me.tpInters.Controls.Add(Me.StatusStrip2)
        Me.tpInters.Location = New System.Drawing.Point(4, 22)
        Me.tpInters.Name = "tpInters"
        Me.tpInters.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInters.Size = New System.Drawing.Size(550, 195)
        Me.tpInters.TabIndex = 3
        Me.tpInters.Text = "Interventions"
        Me.tpInters.UseVisualStyleBackColor = True
        '
        'EvenementDataGridView
        '
        Me.EvenementDataGridView.AllowUserToAddRows = False
        Me.EvenementDataGridView.AllowUserToDeleteRows = False
        Me.EvenementDataGridView.AutoGenerateColumns = False
        Me.EvenementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.NomClient, Me.DataGridViewTextBoxColumn33})
        Me.EvenementDataGridView.DataSource = Me.EvenementBindingSource
        Me.EvenementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EvenementDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.EvenementDataGridView.Name = "EvenementDataGridView"
        Me.EvenementDataGridView.ReadOnly = True
        Me.EvenementDataGridView.Size = New System.Drawing.Size(544, 167)
        Me.EvenementDataGridView.TabIndex = 4
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Realise"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Fini"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Width = 29
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 56
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "ProduitsPresentes"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Width = 65
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "DateEv"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 55
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "Duree"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn28.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn28.HeaderText = "Duree"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Width = 61
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "UniteDuree"
        Me.DataGridViewTextBoxColumn29.HeaderText = ""
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 19
        '
        'NomClient
        '
        Me.NomClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomClient.DataPropertyName = "NomClient"
        Me.NomClient.HeaderText = "Client"
        Me.NomClient.Name = "NomClient"
        Me.NomClient.ReadOnly = True
        Me.NomClient.Width = 58
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'EvenementBindingSource
        '
        Me.EvenementBindingSource.DataMember = "Evenement"
        Me.EvenementBindingSource.DataSource = Me.DsAgrifact
        Me.EvenementBindingSource.Sort = "DateEv"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbTotalInterLabel, Me.lbTotalInter})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 170)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(544, 22)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 3
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lbTotalInterLabel
        '
        Me.lbTotalInterLabel.Name = "lbTotalInterLabel"
        Me.lbTotalInterLabel.Size = New System.Drawing.Size(461, 17)
        Me.lbTotalInterLabel.Spring = True
        Me.lbTotalInterLabel.Text = "Total :"
        Me.lbTotalInterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalInter
        '
        Me.lbTotalInter.Name = "lbTotalInter"
        Me.lbTotalInter.Size = New System.Drawing.Size(68, 17)
        Me.lbTotalInter.Text = "lbTotalInter"
        '
        'tpTel
        '
        Me.tpTel.Controls.Add(Me.TelephoneDataGridView)
        Me.tpTel.Location = New System.Drawing.Point(4, 22)
        Me.tpTel.Name = "tpTel"
        Me.tpTel.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTel.Size = New System.Drawing.Size(550, 195)
        Me.tpTel.TabIndex = 0
        Me.tpTel.Text = "Téléphone"
        Me.tpTel.UseVisualStyleBackColor = True
        '
        'tpCoord
        '
        Me.tpCoord.AutoScroll = True
        Me.tpCoord.Controls.Add(Me.VilleTextBox)
        Me.tpCoord.Controls.Add(Me.CodePostalTextBox)
        Me.tpCoord.Controls.Add(Me.LnkMail)
        Me.tpCoord.Controls.Add(AdresseLabel)
        Me.tpCoord.Controls.Add(Me.AdresseTextBox)
        Me.tpCoord.Controls.Add(CodePostalLabel)
        Me.tpCoord.Controls.Add(VilleLabel)
        Me.tpCoord.Controls.Add(EMailLabel)
        Me.tpCoord.Location = New System.Drawing.Point(4, 22)
        Me.tpCoord.Name = "tpCoord"
        Me.tpCoord.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCoord.Size = New System.Drawing.Size(550, 195)
        Me.tpCoord.TabIndex = 1
        Me.tpCoord.Text = "Coordonnées"
        Me.tpCoord.UseVisualStyleBackColor = True
        '
        'VilleTextBox
        '
        Me.VilleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(147, 141)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(393, 20)
        Me.VilleTextBox.TabIndex = 14
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(36, 141)
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(71, 20)
        Me.CodePostalTextBox.TabIndex = 13
        '
        'LnkMail
        '
        Me.LnkMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LnkMail.AutoSize = True
        Me.LnkMail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "EMail", True))
        Me.LnkMail.Location = New System.Drawing.Point(40, 170)
        Me.LnkMail.Name = "LnkMail"
        Me.LnkMail.Size = New System.Drawing.Size(44, 13)
        Me.LnkMail.TabIndex = 12
        Me.LnkMail.TabStop = True
        Me.LnkMail.Text = "LnkMail"
        '
        'tpObs
        '
        Me.tpObs.Controls.Add(Me.ObservationsTextBox)
        Me.tpObs.Location = New System.Drawing.Point(4, 22)
        Me.tpObs.Name = "tpObs"
        Me.tpObs.Size = New System.Drawing.Size(550, 195)
        Me.tpObs.TabIndex = 2
        Me.tpObs.Text = "Observations"
        Me.tpObs.UseVisualStyleBackColor = True
        '
        'LnkEntreprise
        '
        Me.LnkEntreprise.AutoSize = True
        Me.LnkEntreprise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "NomEntreprise", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "Pas d'entreprise"))
        Me.LnkEntreprise.Location = New System.Drawing.Point(12, 51)
        Me.LnkEntreprise.Name = "LnkEntreprise"
        Me.LnkEntreprise.Size = New System.Drawing.Size(54, 13)
        Me.LnkEntreprise.TabIndex = 18
        Me.LnkEntreprise.TabStop = True
        Me.LnkEntreprise.Text = "Entreprise"
        '
        'PersonneTableAdapter
        '
        Me.PersonneTableAdapter.ClearBeforeFill = True
        '
        'TelephoneTableAdapter
        '
        Me.TelephoneTableAdapter.ClearBeforeFill = True
        '
        'EntrepriseTableAdapter
        '
        Me.EntrepriseTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nPersonne"
        Me.DataGridViewTextBoxColumn1.HeaderText = "nPersonne"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Numero"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Numero"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtClose, Me.TbIntervention, Me.TbCopyCoords})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(558, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtClose
        '
        Me.BtClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtClose.Image = Global.ContactsAgrifact.My.Resources.Resources.close
        Me.BtClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(23, 22)
        Me.BtClose.Text = "Fermer"
        '
        'TbIntervention
        '
        Me.TbIntervention.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbIntervention.Image = Global.ContactsAgrifact.My.Resources.Resources.ExpirationHS
        Me.TbIntervention.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbIntervention.Name = "TbIntervention"
        Me.TbIntervention.Size = New System.Drawing.Size(23, 22)
        Me.TbIntervention.Text = "Débuter une intervention"
        '
        'TbCopyCoords
        '
        Me.TbCopyCoords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCopyCoords.Image = Global.ContactsAgrifact.My.Resources.Resources.PasteHS
        Me.TbCopyCoords.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCopyCoords.Name = "TbCopyCoords"
        Me.TbCopyCoords.Size = New System.Drawing.Size(23, 22)
        Me.TbCopyCoords.Text = "Copier les coordonnées"
        '
        'NomTextBox
        '
        Me.NomTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(47, 25)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.ReadOnly = True
        Me.NomTextBox.Size = New System.Drawing.Size(328, 20)
        Me.NomTextBox.TabIndex = 20
        '
        'PrenomTextBox
        '
        Me.PrenomTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrenomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonneBindingSource, "Prenom", True))
        Me.PrenomTextBox.Location = New System.Drawing.Point(433, 25)
        Me.PrenomTextBox.Name = "PrenomTextBox"
        Me.PrenomTextBox.ReadOnly = True
        Me.PrenomTextBox.Size = New System.Drawing.Size(113, 20)
        Me.PrenomTextBox.TabIndex = 21
        '
        'EvenementTableAdapter
        '
        Me.EvenementTableAdapter.ClearBeforeFill = True
        '
        'NPersonneDataGridViewTextBoxColumn
        '
        Me.NPersonneDataGridViewTextBoxColumn.DataPropertyName = "nPersonne"
        Me.NPersonneDataGridViewTextBoxColumn.HeaderText = "nPersonne"
        Me.NPersonneDataGridViewTextBoxColumn.Name = "NPersonneDataGridViewTextBoxColumn"
        Me.NPersonneDataGridViewTextBoxColumn.ReadOnly = True
        Me.NPersonneDataGridViewTextBoxColumn.Visible = False
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 5
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Numero.DataPropertyName = "Numero"
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'FrPersonne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 287)
        Me.Controls.Add(Me.PrenomTextBox)
        Me.Controls.Add(Me.NomTextBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LnkEntreprise)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(PrenomLabel)
        Me.Controls.Add(NomLabel)
        Me.Name = "FrPersonne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrPersonne"
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpInters.ResumeLayout(False)
        Me.tpInters.PerformLayout()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.tpTel.ResumeLayout(False)
        Me.tpCoord.ResumeLayout(False)
        Me.tpCoord.PerformLayout()
        Me.tpObs.ResumeLayout(False)
        Me.tpObs.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdresseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ObservationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelephoneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonneTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter
    Friend WithEvents TelephoneTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.TelephoneTableAdapter
    Friend WithEvents TelephoneDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpTel As System.Windows.Forms.TabPage
    Friend WithEvents tpCoord As System.Windows.Forms.TabPage
    Friend WithEvents tpObs As System.Windows.Forms.TabPage
    Friend WithEvents LnkMail As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkEntreprise As System.Windows.Forms.LinkLabel
    Friend WithEvents EntrepriseTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbCopyCoords As System.Windows.Forms.ToolStripButton
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrenomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tpInters As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbTotalInterLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbTotalInter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EvenementTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter
    Friend WithEvents EvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvenementDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TbIntervention As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomClient As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NPersonneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
