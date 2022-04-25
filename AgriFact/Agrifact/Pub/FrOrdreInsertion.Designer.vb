<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrOrdreInsertion
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.FactureCheckBox = New System.Windows.Forms.CheckBox
        Me.EvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PubDataSet = New AgriFact.PubDataSet
        Me.Label16 = New System.Windows.Forms.Label
        Me.AutreSupportCheckBox = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.ObservationTextBox = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.FacturationMCheckBox = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PrixHTTextBox = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ListeRubriqueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.EmplacementComboBox = New System.Windows.Forms.ComboBox
        Me.ListeEmplacementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.ContenuComboBox = New System.Windows.Forms.ComboBox
        Me.ListeContenuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.CouleurComboBox = New System.Windows.Forms.ComboBox
        Me.ListeCouleurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.FormatComboBox = New System.Windows.Forms.ComboBox
        Me.ListeFormatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.ClientComboBox = New System.Windows.Forms.ComboBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.CommercialComboBox = New System.Windows.Forms.ComboBox
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.RealiseCheckBox = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateEvDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.TypeEvComboBox = New System.Windows.Forms.ComboBox
        Me.ListeTypeEvBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.EvenementDataGridView = New System.Windows.Forms.DataGridView
        Me.NEvenementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateEvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RealiseDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FactureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DatePreFacturationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EvenementTableAdapter = New AgriFact.PubDataSetTableAdapters.EvenementTableAdapter
        Me.ListeChoixTableAdapter = New AgriFact.PubDataSetTableAdapters.ListeChoixTableAdapter
        Me.PersonneTableAdapter = New AgriFact.PubDataSetTableAdapters.PersonneTableAdapter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RubriqueComboBox = New System.Windows.Forms.ComboBox
        Me.ChercherClientButton = New System.Windows.Forms.Button
        Me.AjouterRubriqueButton = New System.Windows.Forms.Button
        Me.AjouterEmplacementButton = New System.Windows.Forms.Button
        Me.AjouterContenuButton = New System.Windows.Forms.Button
        Me.AjouterCouleurButton = New System.Windows.Forms.Button
        Me.AjouterFormatButton = New System.Windows.Forms.Button
        Me.AjouterTypeEvButton = New System.Windows.Forms.Button
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.FermerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EnregistrerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.DupliquerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ImprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EntrepriseTableAdapter = New AgriFact.PubDataSetTableAdapters.EntrepriseTableAdapter
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
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeRubriqueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeEmplacementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeContenuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeCouleurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeFormatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeTypeEvBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FactureCheckBox
        '
        Me.FactureCheckBox.AutoSize = True
        Me.FactureCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.EvenementBindingSource, "Facture", True))
        Me.FactureCheckBox.Location = New System.Drawing.Point(166, 446)
        Me.FactureCheckBox.Name = "FactureCheckBox"
        Me.FactureCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.FactureCheckBox.TabIndex = 37
        Me.FactureCheckBox.UseVisualStyleBackColor = True
        '
        'EvenementBindingSource
        '
        Me.EvenementBindingSource.DataMember = "Evenement"
        Me.EvenementBindingSource.DataSource = Me.PubDataSet
        Me.EvenementBindingSource.Sort = "nEvenement DESC"
        '
        'PubDataSet
        '
        Me.PubDataSet.DataSetName = "PubDataSet"
        Me.PubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 447)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Facturé"
        '
        'AutreSupportCheckBox
        '
        Me.AutreSupportCheckBox.AutoSize = True
        Me.AutreSupportCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.EvenementBindingSource, "AutreSupport", True))
        Me.AutreSupportCheckBox.Location = New System.Drawing.Point(166, 425)
        Me.AutreSupportCheckBox.Name = "AutreSupportCheckBox"
        Me.AutreSupportCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.AutreSupportCheckBox.TabIndex = 35
        Me.AutreSupportCheckBox.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 426)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Autre support"
        '
        'ObservationTextBox
        '
        Me.ObservationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Observation", True))
        Me.ObservationTextBox.Location = New System.Drawing.Point(166, 341)
        Me.ObservationTextBox.Multiline = True
        Me.ObservationTextBox.Name = "ObservationTextBox"
        Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservationTextBox.Size = New System.Drawing.Size(218, 79)
        Me.ObservationTextBox.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Observation"
        '
        'FacturationMCheckBox
        '
        Me.FacturationMCheckBox.AutoSize = True
        Me.FacturationMCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.EvenementBindingSource, "FacturationM", True))
        Me.FacturationMCheckBox.Location = New System.Drawing.Point(166, 321)
        Me.FacturationMCheckBox.Name = "FacturationMCheckBox"
        Me.FacturationMCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.FacturationMCheckBox.TabIndex = 31
        Me.FacturationMCheckBox.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 322)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Facturation mensuelle"
        '
        'PrixHTTextBox
        '
        Me.PrixHTTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "PrixHT", True))
        Me.PrixHTTextBox.Location = New System.Drawing.Point(166, 295)
        Me.PrixHTTextBox.Name = "PrixHTTextBox"
        Me.PrixHTTextBox.Size = New System.Drawing.Size(217, 20)
        Me.PrixHTTextBox.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 298)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Prix HT de la parution"
        '
        'ListeRubriqueBindingSource
        '
        Me.ListeRubriqueBindingSource.DataMember = "ListeChoix"
        Me.ListeRubriqueBindingSource.DataSource = Me.PubDataSet
        Me.ListeRubriqueBindingSource.Sort = "nOrdreValeur"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Rubrique"
        '
        'EmplacementComboBox
        '
        Me.EmplacementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Emplacement", True))
        Me.EmplacementComboBox.DataSource = Me.ListeEmplacementBindingSource
        Me.EmplacementComboBox.DisplayMember = "Valeur"
        Me.EmplacementComboBox.FormattingEnabled = True
        Me.EmplacementComboBox.Location = New System.Drawing.Point(166, 241)
        Me.EmplacementComboBox.Name = "EmplacementComboBox"
        Me.EmplacementComboBox.Size = New System.Drawing.Size(218, 21)
        Me.EmplacementComboBox.TabIndex = 25
        '
        'ListeEmplacementBindingSource
        '
        Me.ListeEmplacementBindingSource.DataMember = "ListeChoix"
        Me.ListeEmplacementBindingSource.DataSource = Me.PubDataSet
        Me.ListeEmplacementBindingSource.Sort = "nOrdreValeur"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Emplacement"
        '
        'ContenuComboBox
        '
        Me.ContenuComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Contenu", True))
        Me.ContenuComboBox.DataSource = Me.ListeContenuBindingSource
        Me.ContenuComboBox.DisplayMember = "Valeur"
        Me.ContenuComboBox.FormattingEnabled = True
        Me.ContenuComboBox.Location = New System.Drawing.Point(166, 214)
        Me.ContenuComboBox.Name = "ContenuComboBox"
        Me.ContenuComboBox.Size = New System.Drawing.Size(217, 21)
        Me.ContenuComboBox.TabIndex = 21
        '
        'ListeContenuBindingSource
        '
        Me.ListeContenuBindingSource.DataMember = "ListeChoix"
        Me.ListeContenuBindingSource.DataSource = Me.PubDataSet
        Me.ListeContenuBindingSource.Sort = "nOrdreValeur"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Contenu"
        '
        'CouleurComboBox
        '
        Me.CouleurComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Couleur", True))
        Me.CouleurComboBox.DataSource = Me.ListeCouleurBindingSource
        Me.CouleurComboBox.DisplayMember = "Valeur"
        Me.CouleurComboBox.FormattingEnabled = True
        Me.CouleurComboBox.Location = New System.Drawing.Point(166, 187)
        Me.CouleurComboBox.Name = "CouleurComboBox"
        Me.CouleurComboBox.Size = New System.Drawing.Size(217, 21)
        Me.CouleurComboBox.TabIndex = 19
        '
        'ListeCouleurBindingSource
        '
        Me.ListeCouleurBindingSource.DataMember = "ListeChoix"
        Me.ListeCouleurBindingSource.DataSource = Me.PubDataSet
        Me.ListeCouleurBindingSource.Sort = "nOrdreValeur"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Couleur"
        '
        'FormatComboBox
        '
        Me.FormatComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Format", True))
        Me.FormatComboBox.DataSource = Me.ListeFormatBindingSource
        Me.FormatComboBox.DisplayMember = "Valeur"
        Me.FormatComboBox.FormattingEnabled = True
        Me.FormatComboBox.Location = New System.Drawing.Point(166, 160)
        Me.FormatComboBox.Name = "FormatComboBox"
        Me.FormatComboBox.Size = New System.Drawing.Size(218, 21)
        Me.FormatComboBox.TabIndex = 17
        '
        'ListeFormatBindingSource
        '
        Me.ListeFormatBindingSource.DataMember = "ListeChoix"
        Me.ListeFormatBindingSource.DataSource = Me.PubDataSet
        Me.ListeFormatBindingSource.Sort = "nOrdreValeur"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Format"
        '
        'ClientComboBox
        '
        Me.ClientComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "nClient", True))
        Me.ClientComboBox.DataSource = Me.EntrepriseBindingSource
        Me.ClientComboBox.DisplayMember = "Nom"
        Me.ClientComboBox.FormattingEnabled = True
        Me.ClientComboBox.Location = New System.Drawing.Point(166, 133)
        Me.ClientComboBox.Name = "ClientComboBox"
        Me.ClientComboBox.Size = New System.Drawing.Size(218, 21)
        Me.ClientComboBox.TabIndex = 15
        Me.ClientComboBox.ValueMember = "nEntreprise"
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.PubDataSet
        Me.EntrepriseBindingSource.Sort = "Nom"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Client"
        '
        'CommercialComboBox
        '
        Me.CommercialComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "nPersonneAuteur", True))
        Me.CommercialComboBox.DataSource = Me.PersonneBindingSource
        Me.CommercialComboBox.DisplayMember = "Nom"
        Me.CommercialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CommercialComboBox.FormattingEnabled = True
        Me.CommercialComboBox.Location = New System.Drawing.Point(166, 106)
        Me.CommercialComboBox.Name = "CommercialComboBox"
        Me.CommercialComboBox.Size = New System.Drawing.Size(218, 21)
        Me.CommercialComboBox.TabIndex = 13
        Me.CommercialComboBox.ValueMember = "nPersonne"
        '
        'PersonneBindingSource
        '
        Me.PersonneBindingSource.DataMember = "Personne"
        Me.PersonneBindingSource.DataSource = Me.PubDataSet
        Me.PersonneBindingSource.Sort = "Nom"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Commercial"
        '
        'RealiseCheckBox
        '
        Me.RealiseCheckBox.AutoSize = True
        Me.RealiseCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.EvenementBindingSource, "Realise", True))
        Me.RealiseCheckBox.Location = New System.Drawing.Point(166, 86)
        Me.RealiseCheckBox.Name = "RealiseCheckBox"
        Me.RealiseCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.RealiseCheckBox.TabIndex = 11
        Me.RealiseCheckBox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Réalisé"
        '
        'DateEvDateTimePicker
        '
        Me.DateEvDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EvenementBindingSource, "DateEv", True))
        Me.DateEvDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateEvDateTimePicker.Location = New System.Drawing.Point(166, 60)
        Me.DateEvDateTimePicker.Name = "DateEvDateTimePicker"
        Me.DateEvDateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateEvDateTimePicker.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Date de parution"
        '
        'TypeEvComboBox
        '
        Me.TypeEvComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "Type", True))
        Me.TypeEvComboBox.DataSource = Me.ListeTypeEvBindingSource
        Me.TypeEvComboBox.DisplayMember = "Valeur"
        Me.TypeEvComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeEvComboBox.FormattingEnabled = True
        Me.TypeEvComboBox.Location = New System.Drawing.Point(166, 33)
        Me.TypeEvComboBox.Name = "TypeEvComboBox"
        Me.TypeEvComboBox.Size = New System.Drawing.Size(218, 21)
        Me.TypeEvComboBox.TabIndex = 7
        Me.TypeEvComboBox.ValueMember = "Valeur"
        '
        'ListeTypeEvBindingSource
        '
        Me.ListeTypeEvBindingSource.DataMember = "ListeChoix"
        Me.ListeTypeEvBindingSource.DataSource = Me.PubDataSet
        Me.ListeTypeEvBindingSource.Sort = "nOrdreValeur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Type d'évènement"
        '
        'EvenementDataGridView
        '
        Me.EvenementDataGridView.AllowUserToAddRows = False
        Me.EvenementDataGridView.AllowUserToDeleteRows = False
        Me.EvenementDataGridView.AutoGenerateColumns = False
        Me.EvenementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EvenementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEvenementDataGridViewTextBoxColumn, Me.DateEvDataGridViewTextBoxColumn, Me.Type, Me.RealiseDataGridViewCheckBoxColumn, Me.FactureDataGridViewCheckBoxColumn, Me.DatePreFacturationDataGridViewTextBoxColumn})
        Me.EvenementDataGridView.DataSource = Me.EvenementBindingSource
        Me.EvenementDataGridView.Location = New System.Drawing.Point(464, 28)
        Me.EvenementDataGridView.MultiSelect = False
        Me.EvenementDataGridView.Name = "EvenementDataGridView"
        Me.EvenementDataGridView.ReadOnly = True
        Me.EvenementDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EvenementDataGridView.Size = New System.Drawing.Size(465, 498)
        Me.EvenementDataGridView.TabIndex = 4
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DateEvDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateEvDataGridViewTextBoxColumn.HeaderText = "Date parution"
        Me.DateEvDataGridViewTextBoxColumn.Name = "DateEvDataGridViewTextBoxColumn"
        Me.DateEvDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateEvDataGridViewTextBoxColumn.Width = 80
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Type.DefaultCellStyle = DataGridViewCellStyle2
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'RealiseDataGridViewCheckBoxColumn
        '
        Me.RealiseDataGridViewCheckBoxColumn.DataPropertyName = "Realise"
        Me.RealiseDataGridViewCheckBoxColumn.HeaderText = "Réalisé"
        Me.RealiseDataGridViewCheckBoxColumn.Name = "RealiseDataGridViewCheckBoxColumn"
        Me.RealiseDataGridViewCheckBoxColumn.ReadOnly = True
        Me.RealiseDataGridViewCheckBoxColumn.Width = 60
        '
        'FactureDataGridViewCheckBoxColumn
        '
        Me.FactureDataGridViewCheckBoxColumn.DataPropertyName = "Facture"
        Me.FactureDataGridViewCheckBoxColumn.HeaderText = "Facturé"
        Me.FactureDataGridViewCheckBoxColumn.Name = "FactureDataGridViewCheckBoxColumn"
        Me.FactureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.FactureDataGridViewCheckBoxColumn.Width = 60
        '
        'DatePreFacturationDataGridViewTextBoxColumn
        '
        Me.DatePreFacturationDataGridViewTextBoxColumn.DataPropertyName = "DatePreFacturation"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DatePreFacturationDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DatePreFacturationDataGridViewTextBoxColumn.HeaderText = "Date pré-facturation"
        Me.DatePreFacturationDataGridViewTextBoxColumn.Name = "DatePreFacturationDataGridViewTextBoxColumn"
        Me.DatePreFacturationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EvenementTableAdapter
        '
        Me.EvenementTableAdapter.ClearBeforeFill = True
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'PersonneTableAdapter
        '
        Me.PersonneTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.RubriqueComboBox)
        Me.Panel1.Controls.Add(Me.ChercherClientButton)
        Me.Panel1.Controls.Add(Me.AjouterRubriqueButton)
        Me.Panel1.Controls.Add(Me.AjouterEmplacementButton)
        Me.Panel1.Controls.Add(Me.AjouterContenuButton)
        Me.Panel1.Controls.Add(Me.AjouterCouleurButton)
        Me.Panel1.Controls.Add(Me.AjouterFormatButton)
        Me.Panel1.Controls.Add(Me.AjouterTypeEvButton)
        Me.Panel1.Controls.Add(Me.FactureCheckBox)
        Me.Panel1.Controls.Add(Me.GradientCaption2)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.AutreSupportCheckBox)
        Me.Panel1.Controls.Add(Me.TypeEvComboBox)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ObservationTextBox)
        Me.Panel1.Controls.Add(Me.DateEvDateTimePicker)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.FacturationMCheckBox)
        Me.Panel1.Controls.Add(Me.RealiseCheckBox)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PrixHTTextBox)
        Me.Panel1.Controls.Add(Me.CommercialComboBox)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ClientComboBox)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.EmplacementComboBox)
        Me.Panel1.Controls.Add(Me.FormatComboBox)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CouleurComboBox)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.ContenuComboBox)
        Me.Panel1.Location = New System.Drawing.Point(12, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(446, 498)
        Me.Panel1.TabIndex = 5
        '
        'RubriqueComboBox
        '
        Me.RubriqueComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Rubrique", True))
        Me.RubriqueComboBox.DataSource = Me.ListeRubriqueBindingSource
        Me.RubriqueComboBox.DisplayMember = "Valeur"
        Me.RubriqueComboBox.FormattingEnabled = True
        Me.RubriqueComboBox.Location = New System.Drawing.Point(166, 268)
        Me.RubriqueComboBox.Name = "RubriqueComboBox"
        Me.RubriqueComboBox.Size = New System.Drawing.Size(218, 21)
        Me.RubriqueComboBox.TabIndex = 48
        '
        'ChercherClientButton
        '
        Me.ChercherClientButton.Image = Global.AgriFact.My.Resources.Resources.search
        Me.ChercherClientButton.Location = New System.Drawing.Point(390, 131)
        Me.ChercherClientButton.Name = "ChercherClientButton"
        Me.ChercherClientButton.Size = New System.Drawing.Size(35, 23)
        Me.ChercherClientButton.TabIndex = 45
        Me.ChercherClientButton.Tag = "ListeTypeEv"
        Me.ChercherClientButton.UseVisualStyleBackColor = True
        '
        'AjouterRubriqueButton
        '
        Me.AjouterRubriqueButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterRubriqueButton.Location = New System.Drawing.Point(390, 266)
        Me.AjouterRubriqueButton.Name = "AjouterRubriqueButton"
        Me.AjouterRubriqueButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterRubriqueButton.TabIndex = 44
        Me.AjouterRubriqueButton.Tag = "ListeRubrique"
        Me.AjouterRubriqueButton.UseVisualStyleBackColor = True
        '
        'AjouterEmplacementButton
        '
        Me.AjouterEmplacementButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterEmplacementButton.Location = New System.Drawing.Point(390, 239)
        Me.AjouterEmplacementButton.Name = "AjouterEmplacementButton"
        Me.AjouterEmplacementButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterEmplacementButton.TabIndex = 43
        Me.AjouterEmplacementButton.Tag = "ListeEmplacement"
        Me.AjouterEmplacementButton.UseVisualStyleBackColor = True
        '
        'AjouterContenuButton
        '
        Me.AjouterContenuButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterContenuButton.Location = New System.Drawing.Point(390, 212)
        Me.AjouterContenuButton.Name = "AjouterContenuButton"
        Me.AjouterContenuButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterContenuButton.TabIndex = 42
        Me.AjouterContenuButton.Tag = "ListeContenu"
        Me.AjouterContenuButton.UseVisualStyleBackColor = True
        '
        'AjouterCouleurButton
        '
        Me.AjouterCouleurButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterCouleurButton.Location = New System.Drawing.Point(390, 185)
        Me.AjouterCouleurButton.Name = "AjouterCouleurButton"
        Me.AjouterCouleurButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterCouleurButton.TabIndex = 41
        Me.AjouterCouleurButton.Tag = "ListeCouleur"
        Me.AjouterCouleurButton.UseVisualStyleBackColor = True
        '
        'AjouterFormatButton
        '
        Me.AjouterFormatButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterFormatButton.Location = New System.Drawing.Point(390, 158)
        Me.AjouterFormatButton.Name = "AjouterFormatButton"
        Me.AjouterFormatButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterFormatButton.TabIndex = 40
        Me.AjouterFormatButton.Tag = "ListeFormat"
        Me.AjouterFormatButton.UseVisualStyleBackColor = True
        '
        'AjouterTypeEvButton
        '
        Me.AjouterTypeEvButton.Image = Global.AgriFact.My.Resources.Resources.plus
        Me.AjouterTypeEvButton.Location = New System.Drawing.Point(390, 31)
        Me.AjouterTypeEvButton.Name = "AjouterTypeEvButton"
        Me.AjouterTypeEvButton.Size = New System.Drawing.Size(35, 23)
        Me.AjouterTypeEvButton.TabIndex = 38
        Me.AjouterTypeEvButton.Tag = "ListeTypeEv"
        Me.AjouterTypeEvButton.UseVisualStyleBackColor = True
        '
        'GradientCaption2
        '
        Me.GradientCaption2.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption2.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption2.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption2.Name = "GradientCaption2"
        Me.GradientCaption2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption2.Size = New System.Drawing.Size(446, 24)
        Me.GradientCaption2.TabIndex = 1
        Me.GradientCaption2.Text = "Ordre d'insertion"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerToolStripButton, Me.EnregistrerToolStripButton, Me.SupprimerToolStripButton, Me.ToolStripSeparator1, Me.DupliquerToolStripButton, Me.ToolStripSeparator2, Me.ImprimerToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(941, 25)
        Me.ToolStrip1.TabIndex = 6
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
        'EnregistrerToolStripButton
        '
        Me.EnregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EnregistrerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.EnregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EnregistrerToolStripButton.Name = "EnregistrerToolStripButton"
        Me.EnregistrerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.EnregistrerToolStripButton.Text = "Enregistrer"
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
        'DupliquerToolStripButton
        '
        Me.DupliquerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DupliquerToolStripButton.Image = Global.AgriFact.My.Resources.Resources.CopyHS
        Me.DupliquerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DupliquerToolStripButton.Name = "DupliquerToolStripButton"
        Me.DupliquerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DupliquerToolStripButton.Text = "Dupliquer"
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
        'EntrepriseTableAdapter
        '
        Me.EntrepriseTableAdapter.ClearBeforeFill = True
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TypeEv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "TypeEv"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DateCreation"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "DateCreation"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Origine"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn4.HeaderText = "Origine"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "nOrigine"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn5.HeaderText = "nOrigine"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "nImage"
        Me.DataGridViewTextBoxColumn6.HeaderText = "nImage"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Dep"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Dep"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DateEv"
        Me.DataGridViewTextBoxColumn9.HeaderText = "DateEv"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Priorite"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Priorite"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Duree"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Duree"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "UniteDuree"
        Me.DataGridViewTextBoxColumn12.HeaderText = "UniteDuree"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "nPersonneAuteur"
        Me.DataGridViewTextBoxColumn13.HeaderText = "nPersonneAuteur"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
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
        'FrOrdreInsertion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(941, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.EvenementDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrOrdreInsertion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ordre d'insertion"
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeRubriqueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeEmplacementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeContenuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeCouleurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeFormatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeTypeEvBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvenementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContenuComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CouleurComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FormatComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CommercialComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RealiseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateEvDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TypeEvComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrixHTTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EmplacementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents AutreSupportCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents FacturationMCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FactureCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PubDataSet As AgriFact.PubDataSet
    Friend WithEvents EvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvenementTableAdapter As AgriFact.PubDataSetTableAdapters.EvenementTableAdapter
    Friend WithEvents EvenementDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents ListeTypeEvBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As AgriFact.PubDataSetTableAdapters.ListeChoixTableAdapter
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonneTableAdapter As AgriFact.PubDataSetTableAdapters.PersonneTableAdapter
    Friend WithEvents ClientComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ListeFormatBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeCouleurBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeContenuBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeEmplacementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeRubriqueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents AjouterTypeEvButton As System.Windows.Forms.Button
    Friend WithEvents AjouterRubriqueButton As System.Windows.Forms.Button
    Friend WithEvents AjouterEmplacementButton As System.Windows.Forms.Button
    Friend WithEvents AjouterContenuButton As System.Windows.Forms.Button
    Friend WithEvents AjouterCouleurButton As System.Windows.Forms.Button
    Friend WithEvents AjouterFormatButton As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents FermerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EnregistrerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DupliquerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChercherClientButton As System.Windows.Forms.Button
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseTableAdapter As AgriFact.PubDataSetTableAdapters.EntrepriseTableAdapter
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NEvenementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateEvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RealiseDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FactureDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DatePreFacturationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RubriqueComboBox As System.Windows.Forms.ComboBox
End Class
