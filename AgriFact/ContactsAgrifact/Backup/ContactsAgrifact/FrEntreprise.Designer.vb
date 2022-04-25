<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrEntreprise
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
        Dim CiviliteLabel As System.Windows.Forms.Label
        Dim NomLabel As System.Windows.Forms.Label
        Dim AdresseLabel As System.Windows.Forms.Label
        Dim CodePostalLabel As System.Windows.Forms.Label
        Dim VilleLabel As System.Windows.Forms.Label
        Dim EMailLabel As System.Windows.Forms.Label
        Dim EMailLabel1 As System.Windows.Forms.Label
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.AdresseTextBox = New System.Windows.Forms.TextBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.ObservationsTextBox = New System.Windows.Forms.TextBox
        Me.TelephoneEntrepriseDataGridView = New System.Windows.Forms.DataGridView
        Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumeroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TelephoneEntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpCoord = New System.Windows.Forms.TabPage
        Me.VilleTextBox = New System.Windows.Forms.TextBox
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox
        Me.LnkMail = New System.Windows.Forms.LinkLabel
        Me.tpContacts = New System.Windows.Forms.TabPage
        Me.PersonneDataGridView = New System.Windows.Forms.DataGridView
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FonctionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpInters = New System.Windows.Forms.TabPage
        Me.EvenementDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip
        Me.lbTotalInterLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbTotalInter = New System.Windows.Forms.ToolStripStatusLabel
        Me.tpCompte = New System.Windows.Forms.TabPage
        Me.RecapCompteDataGridView = New System.Windows.Forms.DataGridView
        Me.TraiteDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColAgrifactButton = New ContactsAgrifact.DataGridViewDisableButtonColumn
        Me.RecapCompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.tpProduits = New System.Windows.Forms.TabPage
        Me.RecapProduitsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RecapProduitsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpObs = New System.Windows.Forms.TabPage
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtClose = New System.Windows.Forms.ToolStripButton
        Me.TbIntervention = New System.Windows.Forms.ToolStripButton
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.TbCopyCoords = New System.Windows.Forms.ToolStripButton
        Me.TbGoogleMaps = New System.Windows.Forms.ToolStripSplitButton
        Me.ChercherLadresseComplèteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChercherLaCommuneUniquementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbOpenAgrifact = New System.Windows.Forms.ToolStripButton
        Me.NomTextBox = New System.Windows.Forms.TextBox
        Me.CiviliteComboBox = New System.Windows.Forms.ComboBox
        Me.EMailLinkLabel = New System.Windows.Forms.LinkLabel
        Me.EntrepriseTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter
        Me.TelephoneEntrepriseTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
        Me.PersonneTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter
        Me.RecapProduitsTA = New ContactsAgrifact.DsAgrifactTableAdapters.RecapProduitsTA
        Me.RecapCompteTA = New ContactsAgrifact.DsAgrifactTableAdapters.RecapCompteTA
        Me.EvenementTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CiviliteLabel = New System.Windows.Forms.Label
        NomLabel = New System.Windows.Forms.Label
        AdresseLabel = New System.Windows.Forms.Label
        CodePostalLabel = New System.Windows.Forms.Label
        VilleLabel = New System.Windows.Forms.Label
        EMailLabel = New System.Windows.Forms.Label
        EMailLabel1 = New System.Windows.Forms.Label
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpCoord.SuspendLayout()
        Me.tpContacts.SuspendLayout()
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInters.SuspendLayout()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.tpCompte.SuspendLayout()
        CType(Me.RecapCompteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecapCompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tpProduits.SuspendLayout()
        CType(Me.RecapProduitsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecapProduitsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpObs.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CiviliteLabel
        '
        CiviliteLabel.AutoSize = True
        CiviliteLabel.Location = New System.Drawing.Point(12, 32)
        CiviliteLabel.Name = "CiviliteLabel"
        CiviliteLabel.Size = New System.Drawing.Size(40, 13)
        CiviliteLabel.TabIndex = 0
        CiviliteLabel.Text = "Civilite:"
        '
        'NomLabel
        '
        NomLabel.AutoSize = True
        NomLabel.Location = New System.Drawing.Point(136, 32)
        NomLabel.Name = "NomLabel"
        NomLabel.Size = New System.Drawing.Size(32, 13)
        NomLabel.TabIndex = 2
        NomLabel.Text = "Nom:"
        '
        'AdresseLabel
        '
        AdresseLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        AdresseLabel.AutoSize = True
        AdresseLabel.Location = New System.Drawing.Point(6, 128)
        AdresseLabel.Name = "AdresseLabel"
        AdresseLabel.Size = New System.Drawing.Size(48, 13)
        AdresseLabel.TabIndex = 4
        AdresseLabel.Text = "Adresse:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(6, 252)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(24, 13)
        CodePostalLabel.TabIndex = 6
        CodePostalLabel.Text = "CP:"
        '
        'VilleLabel
        '
        VilleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        VilleLabel.AutoSize = True
        VilleLabel.Location = New System.Drawing.Point(113, 252)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(29, 13)
        VilleLabel.TabIndex = 8
        VilleLabel.Text = "Ville:"
        '
        'EMailLabel
        '
        EMailLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        EMailLabel.AutoSize = True
        EMailLabel.Location = New System.Drawing.Point(6, 271)
        EMailLabel.Name = "EMailLabel"
        EMailLabel.Size = New System.Drawing.Size(36, 13)
        EMailLabel.TabIndex = 10
        EMailLabel.Text = "EMail:"
        '
        'EMailLabel1
        '
        EMailLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        EMailLabel1.AutoSize = True
        EMailLabel1.Location = New System.Drawing.Point(136, 52)
        EMailLabel1.Name = "EMailLabel1"
        EMailLabel1.Size = New System.Drawing.Size(36, 13)
        EMailLabel1.TabIndex = 14
        EMailLabel1.Text = "EMail:"
        '
        'AdresseTextBox
        '
        Me.AdresseTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdresseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "Adresse", True))
        Me.AdresseTextBox.Location = New System.Drawing.Point(9, 145)
        Me.AdresseTextBox.Multiline = True
        Me.AdresseTextBox.Name = "AdresseTextBox"
        Me.AdresseTextBox.ReadOnly = True
        Me.AdresseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AdresseTextBox.Size = New System.Drawing.Size(532, 97)
        Me.AdresseTextBox.TabIndex = 5
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ObservationsTextBox
        '
        Me.ObservationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "Observations", True))
        Me.ObservationsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObservationsTextBox.Location = New System.Drawing.Point(5, 5)
        Me.ObservationsTextBox.Multiline = True
        Me.ObservationsTextBox.Name = "ObservationsTextBox"
        Me.ObservationsTextBox.ReadOnly = True
        Me.ObservationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ObservationsTextBox.Size = New System.Drawing.Size(540, 263)
        Me.ObservationsTextBox.TabIndex = 13
        '
        'TelephoneEntrepriseDataGridView
        '
        Me.TelephoneEntrepriseDataGridView.AllowUserToAddRows = False
        Me.TelephoneEntrepriseDataGridView.AllowUserToDeleteRows = False
        Me.TelephoneEntrepriseDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TelephoneEntrepriseDataGridView.AutoGenerateColumns = False
        Me.TelephoneEntrepriseDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.TelephoneEntrepriseDataGridView.ColumnHeadersVisible = False
        Me.TelephoneEntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.NumeroDataGridViewTextBoxColumn})
        Me.TelephoneEntrepriseDataGridView.DataSource = Me.TelephoneEntrepriseBindingSource
        Me.TelephoneEntrepriseDataGridView.Location = New System.Drawing.Point(9, 6)
        Me.TelephoneEntrepriseDataGridView.Name = "TelephoneEntrepriseDataGridView"
        Me.TelephoneEntrepriseDataGridView.ReadOnly = True
        Me.TelephoneEntrepriseDataGridView.Size = New System.Drawing.Size(532, 119)
        Me.TelephoneEntrepriseDataGridView.TabIndex = 14
        '
        'NEntrepriseDataGridViewTextBoxColumn
        '
        Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
        Me.NEntrepriseDataGridViewTextBoxColumn.ReadOnly = True
        Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NumeroDataGridViewTextBoxColumn
        '
        Me.NumeroDataGridViewTextBoxColumn.DataPropertyName = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.HeaderText = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.Name = "NumeroDataGridViewTextBoxColumn"
        Me.NumeroDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TelephoneEntrepriseBindingSource
        '
        Me.TelephoneEntrepriseBindingSource.DataMember = "FK_TelephoneEntreprise_Entreprise"
        Me.TelephoneEntrepriseBindingSource.DataSource = Me.EntrepriseBindingSource
        Me.TelephoneEntrepriseBindingSource.Filter = "Numero is not null AND Numero<>''"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpCoord)
        Me.TabControl1.Controls.Add(Me.tpContacts)
        Me.TabControl1.Controls.Add(Me.tpInters)
        Me.TabControl1.Controls.Add(Me.tpCompte)
        Me.TabControl1.Controls.Add(Me.tpProduits)
        Me.TabControl1.Controls.Add(Me.tpObs)
        Me.TabControl1.Location = New System.Drawing.Point(1, 68)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(558, 299)
        Me.TabControl1.TabIndex = 16
        '
        'tpCoord
        '
        Me.tpCoord.AutoScroll = True
        Me.tpCoord.Controls.Add(Me.VilleTextBox)
        Me.tpCoord.Controls.Add(Me.CodePostalTextBox)
        Me.tpCoord.Controls.Add(Me.TelephoneEntrepriseDataGridView)
        Me.tpCoord.Controls.Add(Me.LnkMail)
        Me.tpCoord.Controls.Add(AdresseLabel)
        Me.tpCoord.Controls.Add(Me.AdresseTextBox)
        Me.tpCoord.Controls.Add(CodePostalLabel)
        Me.tpCoord.Controls.Add(EMailLabel)
        Me.tpCoord.Controls.Add(VilleLabel)
        Me.tpCoord.Location = New System.Drawing.Point(4, 22)
        Me.tpCoord.Name = "tpCoord"
        Me.tpCoord.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCoord.Size = New System.Drawing.Size(550, 273)
        Me.tpCoord.TabIndex = 1
        Me.tpCoord.Text = "Coordonnées"
        Me.tpCoord.UseVisualStyleBackColor = True
        '
        'VilleTextBox
        '
        Me.VilleTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(148, 248)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.ReadOnly = True
        Me.VilleTextBox.Size = New System.Drawing.Size(393, 20)
        Me.VilleTextBox.TabIndex = 17
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(36, 248)
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.ReadOnly = True
        Me.CodePostalTextBox.Size = New System.Drawing.Size(71, 20)
        Me.CodePostalTextBox.TabIndex = 16
        '
        'LnkMail
        '
        Me.LnkMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LnkMail.AutoSize = True
        Me.LnkMail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "EMail", True))
        Me.LnkMail.Location = New System.Drawing.Point(39, 271)
        Me.LnkMail.Name = "LnkMail"
        Me.LnkMail.Size = New System.Drawing.Size(44, 13)
        Me.LnkMail.TabIndex = 12
        Me.LnkMail.TabStop = True
        Me.LnkMail.Text = "LnkMail"
        '
        'tpContacts
        '
        Me.tpContacts.AutoScroll = True
        Me.tpContacts.Controls.Add(Me.PersonneDataGridView)
        Me.tpContacts.Location = New System.Drawing.Point(4, 22)
        Me.tpContacts.Name = "tpContacts"
        Me.tpContacts.Size = New System.Drawing.Size(550, 273)
        Me.tpContacts.TabIndex = 3
        Me.tpContacts.Text = "Contacts"
        Me.tpContacts.UseVisualStyleBackColor = True
        '
        'PersonneDataGridView
        '
        Me.PersonneDataGridView.AllowUserToAddRows = False
        Me.PersonneDataGridView.AllowUserToDeleteRows = False
        Me.PersonneDataGridView.AutoGenerateColumns = False
        Me.PersonneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomDataGridViewTextBoxColumn, Me.PrenomDataGridViewTextBoxColumn, Me.FonctionDataGridViewTextBoxColumn, Me.EMailDataGridViewTextBoxColumn})
        Me.PersonneDataGridView.DataSource = Me.PersonneBindingSource
        Me.PersonneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonneDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.PersonneDataGridView.Name = "PersonneDataGridView"
        Me.PersonneDataGridView.ReadOnly = True
        Me.PersonneDataGridView.Size = New System.Drawing.Size(550, 273)
        Me.PersonneDataGridView.TabIndex = 0
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrenomDataGridViewTextBoxColumn
        '
        Me.PrenomDataGridViewTextBoxColumn.DataPropertyName = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.HeaderText = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.Name = "PrenomDataGridViewTextBoxColumn"
        Me.PrenomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FonctionDataGridViewTextBoxColumn
        '
        Me.FonctionDataGridViewTextBoxColumn.DataPropertyName = "Fonction"
        Me.FonctionDataGridViewTextBoxColumn.HeaderText = "Fonction"
        Me.FonctionDataGridViewTextBoxColumn.Name = "FonctionDataGridViewTextBoxColumn"
        Me.FonctionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EMailDataGridViewTextBoxColumn
        '
        Me.EMailDataGridViewTextBoxColumn.DataPropertyName = "EMail"
        Me.EMailDataGridViewTextBoxColumn.HeaderText = "EMail"
        Me.EMailDataGridViewTextBoxColumn.Name = "EMailDataGridViewTextBoxColumn"
        Me.EMailDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PersonneBindingSource
        '
        Me.PersonneBindingSource.DataMember = "FK_Personne_Entreprise"
        Me.PersonneBindingSource.DataSource = Me.EntrepriseBindingSource
        '
        'tpInters
        '
        Me.tpInters.AutoScroll = True
        Me.tpInters.Controls.Add(Me.EvenementDataGridView)
        Me.tpInters.Controls.Add(Me.StatusStrip2)
        Me.tpInters.Location = New System.Drawing.Point(4, 22)
        Me.tpInters.Name = "tpInters"
        Me.tpInters.Size = New System.Drawing.Size(550, 273)
        Me.tpInters.TabIndex = 6
        Me.tpInters.Text = "Interventions"
        Me.tpInters.UseVisualStyleBackColor = True
        '
        'EvenementDataGridView
        '
        Me.EvenementDataGridView.AllowUserToAddRows = False
        Me.EvenementDataGridView.AllowUserToDeleteRows = False
        Me.EvenementDataGridView.AutoGenerateColumns = False
        Me.EvenementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn33})
        Me.EvenementDataGridView.DataSource = Me.EvenementBindingSource
        Me.EvenementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EvenementDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.EvenementDataGridView.Name = "EvenementDataGridView"
        Me.EvenementDataGridView.ReadOnly = True
        Me.EvenementDataGridView.Size = New System.Drawing.Size(550, 251)
        Me.EvenementDataGridView.TabIndex = 0
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
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "NomAuteur"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Intervenant"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 86
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
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 251)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(550, 22)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 2
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lbTotalInterLabel
        '
        Me.lbTotalInterLabel.Name = "lbTotalInterLabel"
        Me.lbTotalInterLabel.Size = New System.Drawing.Size(436, 17)
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
        'tpCompte
        '
        Me.tpCompte.AutoScroll = True
        Me.tpCompte.Controls.Add(Me.RecapCompteDataGridView)
        Me.tpCompte.Controls.Add(Me.StatusStrip1)
        Me.tpCompte.Location = New System.Drawing.Point(4, 22)
        Me.tpCompte.Name = "tpCompte"
        Me.tpCompte.Size = New System.Drawing.Size(550, 273)
        Me.tpCompte.TabIndex = 5
        Me.tpCompte.Text = "Compte client"
        Me.tpCompte.UseVisualStyleBackColor = True
        '
        'RecapCompteDataGridView
        '
        Me.RecapCompteDataGridView.AllowUserToAddRows = False
        Me.RecapCompteDataGridView.AllowUserToDeleteRows = False
        Me.RecapCompteDataGridView.AutoGenerateColumns = False
        Me.RecapCompteDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TraiteDataGridViewCheckBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn, Me.ColAgrifactButton})
        Me.RecapCompteDataGridView.DataSource = Me.RecapCompteBindingSource
        Me.RecapCompteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecapCompteDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RecapCompteDataGridView.Name = "RecapCompteDataGridView"
        Me.RecapCompteDataGridView.ReadOnly = True
        Me.RecapCompteDataGridView.Size = New System.Drawing.Size(550, 251)
        Me.RecapCompteDataGridView.TabIndex = 0
        '
        'TraiteDataGridViewCheckBoxColumn
        '
        Me.TraiteDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TraiteDataGridViewCheckBoxColumn.DataPropertyName = "traite"
        Me.TraiteDataGridViewCheckBoxColumn.HeaderText = "Traité"
        Me.TraiteDataGridViewCheckBoxColumn.Name = "TraiteDataGridViewCheckBoxColumn"
        Me.TraiteDataGridViewCheckBoxColumn.ReadOnly = True
        Me.TraiteDataGridViewCheckBoxColumn.Width = 40
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "montant"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'ColAgrifactButton
        '
        Me.ColAgrifactButton.HeaderText = ""
        Me.ColAgrifactButton.Image = Global.ContactsAgrifact.My.Resources.Resources.Logo_Agrifact16
        Me.ColAgrifactButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ColAgrifactButton.Name = "ColAgrifactButton"
        Me.ColAgrifactButton.ReadOnly = True
        Me.ColAgrifactButton.Text = ""
        Me.ColAgrifactButton.Width = 32
        '
        'RecapCompteBindingSource
        '
        Me.RecapCompteBindingSource.DataMember = "RecapCompte"
        Me.RecapCompteBindingSource.DataSource = Me.DsAgrifact
        Me.RecapCompteBindingSource.Sort = "Date"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 251)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(550, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(491, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Total :"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotal
        '
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(44, 17)
        Me.lbTotal.Text = "lbTotal"
        '
        'tpProduits
        '
        Me.tpProduits.AutoScroll = True
        Me.tpProduits.Controls.Add(Me.RecapProduitsDataGridView)
        Me.tpProduits.Location = New System.Drawing.Point(4, 22)
        Me.tpProduits.Name = "tpProduits"
        Me.tpProduits.Size = New System.Drawing.Size(550, 273)
        Me.tpProduits.TabIndex = 4
        Me.tpProduits.Text = "Produits"
        Me.tpProduits.UseVisualStyleBackColor = True
        '
        'RecapProduitsDataGridView
        '
        Me.RecapProduitsDataGridView.AllowUserToAddRows = False
        Me.RecapProduitsDataGridView.AllowUserToDeleteRows = False
        Me.RecapProduitsDataGridView.AutoGenerateColumns = False
        Me.RecapProduitsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        Me.RecapProduitsDataGridView.DataSource = Me.RecapProduitsBindingSource
        Me.RecapProduitsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecapProduitsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RecapProduitsDataGridView.Name = "RecapProduitsDataGridView"
        Me.RecapProduitsDataGridView.ReadOnly = True
        Me.RecapProduitsDataGridView.Size = New System.Drawing.Size(550, 273)
        Me.RecapProduitsDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "famille"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 64
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "codeproduit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn10.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 57
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "unite1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn12.HeaderText = "Qte"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 49
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "libunite1"
        Me.DataGridViewTextBoxColumn13.HeaderText = ""
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 19
        '
        'RecapProduitsBindingSource
        '
        Me.RecapProduitsBindingSource.DataMember = "RecapProduits"
        Me.RecapProduitsBindingSource.DataSource = Me.DsAgrifact
        Me.RecapProduitsBindingSource.Sort = "Famille,Libelle"
        '
        'tpObs
        '
        Me.tpObs.Controls.Add(Me.ObservationsTextBox)
        Me.tpObs.Location = New System.Drawing.Point(4, 22)
        Me.tpObs.Name = "tpObs"
        Me.tpObs.Padding = New System.Windows.Forms.Padding(5)
        Me.tpObs.Size = New System.Drawing.Size(550, 273)
        Me.tpObs.TabIndex = 2
        Me.tpObs.Text = "Observations"
        Me.tpObs.UseVisualStyleBackColor = True
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "traite"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Traité"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtClose, Me.TbIntervention, Me.TbFilter, Me.ToolStripButton1, Me.TbCopyCoords, Me.TbGoogleMaps, Me.TbOpenAgrifact})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(558, 25)
        Me.ToolStrip1.TabIndex = 17
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
        'TbFilter
        '
        Me.TbFilter.Checked = True
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.ContactsAgrifact.My.Resources.Resources.filter
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 22)
        Me.TbFilter.Text = "Afficher tous"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.ContactsAgrifact.My.Resources.Resources.ActualSizeHS
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
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
        'TbGoogleMaps
        '
        Me.TbGoogleMaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbGoogleMaps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChercherLadresseComplèteToolStripMenuItem, Me.ChercherLaCommuneUniquementToolStripMenuItem})
        Me.TbGoogleMaps.Image = Global.ContactsAgrifact.My.Resources.Resources.google_earth
        Me.TbGoogleMaps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbGoogleMaps.Name = "TbGoogleMaps"
        Me.TbGoogleMaps.Size = New System.Drawing.Size(32, 22)
        Me.TbGoogleMaps.Text = "Cherchez l'adresse dans Google Maps..."
        '
        'ChercherLadresseComplèteToolStripMenuItem
        '
        Me.ChercherLadresseComplèteToolStripMenuItem.Image = Global.ContactsAgrifact.My.Resources.Resources.google_earth
        Me.ChercherLadresseComplèteToolStripMenuItem.Name = "ChercherLadresseComplèteToolStripMenuItem"
        Me.ChercherLadresseComplèteToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.ChercherLadresseComplèteToolStripMenuItem.Text = "Chercher l'adresse complète..."
        '
        'ChercherLaCommuneUniquementToolStripMenuItem
        '
        Me.ChercherLaCommuneUniquementToolStripMenuItem.Image = Global.ContactsAgrifact.My.Resources.Resources.google_earth
        Me.ChercherLaCommuneUniquementToolStripMenuItem.Name = "ChercherLaCommuneUniquementToolStripMenuItem"
        Me.ChercherLaCommuneUniquementToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.ChercherLaCommuneUniquementToolStripMenuItem.Text = "Chercher la commune uniquement..."
        '
        'TbOpenAgrifact
        '
        Me.TbOpenAgrifact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbOpenAgrifact.Image = Global.ContactsAgrifact.My.Resources.Resources.Logo_Agrifact16
        Me.TbOpenAgrifact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbOpenAgrifact.Name = "TbOpenAgrifact"
        Me.TbOpenAgrifact.Size = New System.Drawing.Size(23, 22)
        Me.TbOpenAgrifact.Text = "Voir dans Agrifact"
        '
        'NomTextBox
        '
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(174, 29)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.ReadOnly = True
        Me.NomTextBox.Size = New System.Drawing.Size(373, 20)
        Me.NomTextBox.TabIndex = 18
        '
        'CiviliteComboBox
        '
        Me.CiviliteComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "Civilite", True))
        Me.CiviliteComboBox.Enabled = False
        Me.CiviliteComboBox.FormattingEnabled = True
        Me.CiviliteComboBox.Location = New System.Drawing.Point(58, 29)
        Me.CiviliteComboBox.Name = "CiviliteComboBox"
        Me.CiviliteComboBox.Size = New System.Drawing.Size(72, 21)
        Me.CiviliteComboBox.TabIndex = 19
        '
        'EMailLinkLabel
        '
        Me.EMailLinkLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EMailLinkLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EntrepriseBindingSource, "EMail", True))
        Me.EMailLinkLabel.Location = New System.Drawing.Point(171, 52)
        Me.EMailLinkLabel.Name = "EMailLinkLabel"
        Me.EMailLinkLabel.Size = New System.Drawing.Size(270, 13)
        Me.EMailLinkLabel.TabIndex = 15
        Me.EMailLinkLabel.TabStop = True
        Me.EMailLinkLabel.Text = "Email"
        '
        'EntrepriseTableAdapter
        '
        Me.EntrepriseTableAdapter.ClearBeforeFill = True
        '
        'TelephoneEntrepriseTableAdapter
        '
        Me.TelephoneEntrepriseTableAdapter.ClearBeforeFill = True
        '
        'PersonneTableAdapter
        '
        Me.PersonneTableAdapter.ClearBeforeFill = True
        '
        'RecapProduitsTA
        '
        Me.RecapProduitsTA.ClearBeforeFill = True
        '
        'RecapCompteTA
        '
        Me.RecapCompteTA.ClearBeforeFill = True
        '
        'EvenementTableAdapter
        '
        Me.EvenementTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Type"
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
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Prenom"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Prénom"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Fonction"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fonction"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Fonction"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fonction"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Prenom"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "Prénom"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Date"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn14.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Fonction"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn16.HeaderText = "Fonction"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Date"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn17.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "montant"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn19.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "unite1"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn20.HeaderText = "Qte"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "libunite1"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn21.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn21.HeaderText = ""
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "libunite1"
        Me.DataGridViewTextBoxColumn22.HeaderText = ""
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'FrEntreprise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 366)
        Me.Controls.Add(Me.CiviliteComboBox)
        Me.Controls.Add(Me.NomTextBox)
        Me.Controls.Add(EMailLabel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.EMailLinkLabel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(NomLabel)
        Me.Controls.Add(CiviliteLabel)
        Me.Name = "FrEntreprise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Entreprise"
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpCoord.ResumeLayout(False)
        Me.tpCoord.PerformLayout()
        Me.tpContacts.ResumeLayout(False)
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInters.ResumeLayout(False)
        Me.tpInters.PerformLayout()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.tpCompte.ResumeLayout(False)
        Me.tpCompte.PerformLayout()
        CType(Me.RecapCompteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecapCompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tpProduits.ResumeLayout(False)
        CType(Me.RecapProduitsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecapProduitsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpObs.ResumeLayout(False)
        Me.tpObs.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter
    Friend WithEvents AdresseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ObservationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelephoneEntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TelephoneEntrepriseTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
    Friend WithEvents TelephoneEntrepriseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpCoord As System.Windows.Forms.TabPage
    Friend WithEvents tpObs As System.Windows.Forms.TabPage
    Friend WithEvents tpContacts As System.Windows.Forms.TabPage
    Friend WithEvents LnkMail As System.Windows.Forms.LinkLabel
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonneTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter
    Friend WithEvents PersonneDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbIntervention As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpProduits As System.Windows.Forms.TabPage
    Friend WithEvents tpCompte As System.Windows.Forms.TabPage
    Friend WithEvents RecapProduitsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecapProduitsTA As ContactsAgrifact.DsAgrifactTableAdapters.RecapProduitsTA
    Friend WithEvents RecapProduitsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RecapCompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecapCompteTA As ContactsAgrifact.DsAgrifactTableAdapters.RecapCompteTA
    Friend WithEvents RecapCompteDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpInters As System.Windows.Forms.TabPage
    Friend WithEvents EvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvenementTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter
    Friend WithEvents EvenementDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FonctionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EMailLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CiviliteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TbCopyCoords As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbGoogleMaps As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ChercherLadresseComplèteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChercherLaCommuneUniquementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbOpenAgrifact As System.Windows.Forms.ToolStripButton
    Friend WithEvents TraiteDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAgrifactButton As ContactsAgrifact.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbTotalInterLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbTotalInter As System.Windows.Forms.ToolStripStatusLabel
End Class
