<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieClient
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
        Dim AdresseLabel As System.Windows.Forms.Label
        Dim CodePostalLabel As System.Windows.Forms.Label
        Dim VilleLabel As System.Windows.Forms.Label
        Dim PaysLabel As System.Windows.Forms.Label
        Dim EMailLabel As System.Windows.Forms.Label
        Dim SiteInternetLabel As System.Windows.Forms.Label
        Dim NTarifLabel As System.Windows.Forms.Label
        Dim RemiseLabel As System.Windows.Forms.Label
        Dim ModePaiementLabel As System.Windows.Forms.Label
        Dim BanqueLabel As System.Windows.Forms.Label
        Dim FacturationTTCLabel As System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbInactif = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.FournBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpCoords = New System.Windows.Forms.TabPage
        Me.AdresseTextBox = New System.Windows.Forms.TextBox
        Me.SiteInternetTextBox = New System.Windows.Forms.TextBox
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox
        Me.VilleTextBox = New System.Windows.Forms.TextBox
        Me.EMailTextBox = New System.Windows.Forms.TextBox
        Me.PaysTextBox = New System.Windows.Forms.TextBox
        Me.tpFacturation = New System.Windows.Forms.TabPage
        Me.FacturationTTCCheckBox = New System.Windows.Forms.CheckBox
        Me.BanqueComboBox = New System.Windows.Forms.ComboBox
        Me.BanqueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModePaiementComboBox = New System.Windows.Forms.ComboBox
        Me.ModesPaiementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RemiseTextBox = New System.Windows.Forms.TextBox
        Me.NTarifComboBox = New System.Windows.Forms.ComboBox
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpTel = New System.Windows.Forms.TabPage
        Me.TelephoneEntrepriseDataGridView = New System.Windows.Forms.DataGridView
        Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Numero = New PointDeVente.DatagridViewNumericTextBoxColumn
        Me.TelephoneEntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpObs = New System.Windows.Forms.TabPage
        Me.ObservationsTextBox = New System.Windows.Forms.TextBox
        Me.CibleCommercialTabPage = New System.Windows.Forms.TabPage
        Me.NouveauCibleCommercialButton = New System.Windows.Forms.Button
        Me.AjouterCibleCommercialButton = New System.Windows.Forms.Button
        Me.CibleCommercialComboBox = New System.Windows.Forms.ComboBox
        Me.ListeChoixCibleCommercialBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CibleCommercialTextBox = New System.Windows.Forms.TextBox
        Me.CiviliteComboBox = New System.Windows.Forms.ComboBox
        Me.CivilitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NomTextBox = New System.Windows.Forms.TextBox
        Me.EntrepriseTA = New PointDeVente.DsAgrifactTableAdapters.EntrepriseTA
        Me.ListeChoixTA = New PointDeVente.DsAgrifactTableAdapters.ListeChoixTA
        Me.TelephoneEntrepriseTableAdapter = New PointDeVente.DsAgrifactTableAdapters.TelephoneEntrepriseTA
        Me.TarifTableAdapter = New PointDeVente.DsAgrifactTableAdapters.TarifTA
        AdresseLabel = New System.Windows.Forms.Label
        CodePostalLabel = New System.Windows.Forms.Label
        VilleLabel = New System.Windows.Forms.Label
        PaysLabel = New System.Windows.Forms.Label
        EMailLabel = New System.Windows.Forms.Label
        SiteInternetLabel = New System.Windows.Forms.Label
        NTarifLabel = New System.Windows.Forms.Label
        RemiseLabel = New System.Windows.Forms.Label
        ModePaiementLabel = New System.Windows.Forms.Label
        BanqueLabel = New System.Windows.Forms.Label
        FacturationTTCLabel = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpCoords.SuspendLayout()
        Me.tpFacturation.SuspendLayout()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModesPaiementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTel.SuspendLayout()
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpObs.SuspendLayout()
        Me.CibleCommercialTabPage.SuspendLayout()
        CType(Me.ListeChoixCibleCommercialBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CivilitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AdresseLabel
        '
        AdresseLabel.AutoSize = True
        AdresseLabel.Location = New System.Drawing.Point(6, 3)
        AdresseLabel.Name = "AdresseLabel"
        AdresseLabel.Size = New System.Drawing.Size(48, 13)
        AdresseLabel.TabIndex = 0
        AdresseLabel.Text = "Adresse:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(6, 100)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(24, 13)
        CodePostalLabel.TabIndex = 2
        CodePostalLabel.Text = "CP:"
        '
        'VilleLabel
        '
        VilleLabel.AutoSize = True
        VilleLabel.Location = New System.Drawing.Point(68, 100)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(29, 13)
        VilleLabel.TabIndex = 4
        VilleLabel.Text = "Ville:"
        '
        'PaysLabel
        '
        PaysLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        PaysLabel.AutoSize = True
        PaysLabel.Location = New System.Drawing.Point(314, 100)
        PaysLabel.Name = "PaysLabel"
        PaysLabel.Size = New System.Drawing.Size(33, 13)
        PaysLabel.TabIndex = 6
        PaysLabel.Text = "Pays:"
        '
        'EMailLabel
        '
        EMailLabel.AutoSize = True
        EMailLabel.Location = New System.Drawing.Point(6, 145)
        EMailLabel.Name = "EMailLabel"
        EMailLabel.Size = New System.Drawing.Size(36, 13)
        EMailLabel.TabIndex = 8
        EMailLabel.Text = "EMail:"
        '
        'SiteInternetLabel
        '
        SiteInternetLabel.AutoSize = True
        SiteInternetLabel.Location = New System.Drawing.Point(6, 168)
        SiteInternetLabel.Name = "SiteInternetLabel"
        SiteInternetLabel.Size = New System.Drawing.Size(54, 13)
        SiteInternetLabel.TabIndex = 10
        SiteInternetLabel.Text = "Site Web:"
        '
        'NTarifLabel
        '
        NTarifLabel.AutoSize = True
        NTarifLabel.Location = New System.Drawing.Point(6, 9)
        NTarifLabel.Name = "NTarifLabel"
        NTarifLabel.Size = New System.Drawing.Size(31, 13)
        NTarifLabel.TabIndex = 0
        NTarifLabel.Text = "Tarif:"
        '
        'RemiseLabel
        '
        RemiseLabel.AutoSize = True
        RemiseLabel.Location = New System.Drawing.Point(6, 90)
        RemiseLabel.Name = "RemiseLabel"
        RemiseLabel.Size = New System.Drawing.Size(45, 13)
        RemiseLabel.TabIndex = 6
        RemiseLabel.Text = "Remise:"
        '
        'ModePaiementLabel
        '
        ModePaiementLabel.AutoSize = True
        ModePaiementLabel.Location = New System.Drawing.Point(6, 36)
        ModePaiementLabel.Name = "ModePaiementLabel"
        ModePaiementLabel.Size = New System.Drawing.Size(84, 13)
        ModePaiementLabel.TabIndex = 2
        ModePaiementLabel.Text = "Mode Paiement:"
        '
        'BanqueLabel
        '
        BanqueLabel.AutoSize = True
        BanqueLabel.Location = New System.Drawing.Point(6, 63)
        BanqueLabel.Name = "BanqueLabel"
        BanqueLabel.Size = New System.Drawing.Size(47, 13)
        BanqueLabel.TabIndex = 4
        BanqueLabel.Text = "Banque:"
        '
        'FacturationTTCLabel
        '
        FacturationTTCLabel.AutoSize = True
        FacturationTTCLabel.Location = New System.Drawing.Point(6, 118)
        FacturationTTCLabel.Name = "FacturationTTCLabel"
        FacturationTTCLabel.Size = New System.Drawing.Size(87, 13)
        FacturationTTCLabel.TabIndex = 8
        FacturationTTCLabel.Text = "Facturation TTC:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.TbInactif, Me.TbFermer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(448, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.PointDeVente.My.Resources.Resources.save
        Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
        Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbInactif
        '
        Me.TbInactif.Checked = True
        Me.TbInactif.CheckOnClick = True
        Me.TbInactif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbInactif.Image = Global.PointDeVente.My.Resources.Resources.actif
        Me.TbInactif.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbInactif.Name = "TbInactif"
        Me.TbInactif.Size = New System.Drawing.Size(84, 22)
        Me.TbInactif.Text = "Client actif"
        Me.TbInactif.ToolTipText = "Marquer le fournisseur inactif"
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.PointDeVente.My.Resources.Resources.close
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'FournBindingSource
        '
        Me.FournBindingSource.DataMember = "Entreprise"
        Me.FournBindingSource.DataSource = Me.DsAgrifact
        Me.FournBindingSource.Sort = "Nom"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.TabControl1)
        Me.GradientPanel1.Controls.Add(Me.CiviliteComboBox)
        Me.GradientPanel1.Controls.Add(Me.NomTextBox)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(448, 276)
        Me.GradientPanel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpCoords)
        Me.TabControl1.Controls.Add(Me.tpFacturation)
        Me.TabControl1.Controls.Add(Me.tpTel)
        Me.TabControl1.Controls.Add(Me.tpObs)
        Me.TabControl1.Controls.Add(Me.CibleCommercialTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(425, 233)
        Me.TabControl1.TabIndex = 2
        '
        'tpCoords
        '
        Me.tpCoords.Controls.Add(Me.AdresseTextBox)
        Me.tpCoords.Controls.Add(SiteInternetLabel)
        Me.tpCoords.Controls.Add(AdresseLabel)
        Me.tpCoords.Controls.Add(Me.SiteInternetTextBox)
        Me.tpCoords.Controls.Add(Me.CodePostalTextBox)
        Me.tpCoords.Controls.Add(EMailLabel)
        Me.tpCoords.Controls.Add(Me.VilleTextBox)
        Me.tpCoords.Controls.Add(Me.EMailTextBox)
        Me.tpCoords.Controls.Add(VilleLabel)
        Me.tpCoords.Controls.Add(CodePostalLabel)
        Me.tpCoords.Controls.Add(PaysLabel)
        Me.tpCoords.Controls.Add(Me.PaysTextBox)
        Me.tpCoords.Location = New System.Drawing.Point(4, 22)
        Me.tpCoords.Name = "tpCoords"
        Me.tpCoords.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCoords.Size = New System.Drawing.Size(417, 207)
        Me.tpCoords.TabIndex = 0
        Me.tpCoords.Text = "Coordonnées"
        Me.tpCoords.UseVisualStyleBackColor = True
        '
        'AdresseTextBox
        '
        Me.AdresseTextBox.AcceptsReturn = True
        Me.AdresseTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdresseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Adresse", True))
        Me.AdresseTextBox.Location = New System.Drawing.Point(3, 19)
        Me.AdresseTextBox.Multiline = True
        Me.AdresseTextBox.Name = "AdresseTextBox"
        Me.AdresseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AdresseTextBox.Size = New System.Drawing.Size(408, 78)
        Me.AdresseTextBox.TabIndex = 1
        '
        'SiteInternetTextBox
        '
        Me.SiteInternetTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SiteInternetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "SiteInternet", True))
        Me.SiteInternetTextBox.Location = New System.Drawing.Point(71, 168)
        Me.SiteInternetTextBox.Name = "SiteInternetTextBox"
        Me.SiteInternetTextBox.Size = New System.Drawing.Size(341, 20)
        Me.SiteInternetTextBox.TabIndex = 11
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(5, 116)
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(60, 20)
        Me.CodePostalTextBox.TabIndex = 3
        Me.CodePostalTextBox.Text = "99 999"
        Me.CodePostalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VilleTextBox
        '
        Me.VilleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(71, 116)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(239, 20)
        Me.VilleTextBox.TabIndex = 5
        '
        'EMailTextBox
        '
        Me.EMailTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EMailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "EMail", True))
        Me.EMailTextBox.Location = New System.Drawing.Point(71, 142)
        Me.EMailTextBox.Name = "EMailTextBox"
        Me.EMailTextBox.Size = New System.Drawing.Size(340, 20)
        Me.EMailTextBox.TabIndex = 9
        '
        'PaysTextBox
        '
        Me.PaysTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaysTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Pays", True))
        Me.PaysTextBox.Location = New System.Drawing.Point(316, 116)
        Me.PaysTextBox.Name = "PaysTextBox"
        Me.PaysTextBox.Size = New System.Drawing.Size(95, 20)
        Me.PaysTextBox.TabIndex = 7
        '
        'tpFacturation
        '
        Me.tpFacturation.AutoScroll = True
        Me.tpFacturation.Controls.Add(FacturationTTCLabel)
        Me.tpFacturation.Controls.Add(Me.FacturationTTCCheckBox)
        Me.tpFacturation.Controls.Add(BanqueLabel)
        Me.tpFacturation.Controls.Add(Me.BanqueComboBox)
        Me.tpFacturation.Controls.Add(ModePaiementLabel)
        Me.tpFacturation.Controls.Add(Me.ModePaiementComboBox)
        Me.tpFacturation.Controls.Add(RemiseLabel)
        Me.tpFacturation.Controls.Add(Me.RemiseTextBox)
        Me.tpFacturation.Controls.Add(NTarifLabel)
        Me.tpFacturation.Controls.Add(Me.NTarifComboBox)
        Me.tpFacturation.Location = New System.Drawing.Point(4, 22)
        Me.tpFacturation.Name = "tpFacturation"
        Me.tpFacturation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFacturation.Size = New System.Drawing.Size(417, 207)
        Me.tpFacturation.TabIndex = 1
        Me.tpFacturation.Text = "Facturation"
        Me.tpFacturation.UseVisualStyleBackColor = True
        '
        'FacturationTTCCheckBox
        '
        Me.FacturationTTCCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.FournBindingSource, "FacturationTTC", True))
        Me.FacturationTTCCheckBox.Location = New System.Drawing.Point(96, 113)
        Me.FacturationTTCCheckBox.Name = "FacturationTTCCheckBox"
        Me.FacturationTTCCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.FacturationTTCCheckBox.TabIndex = 9
        '
        'BanqueComboBox
        '
        Me.BanqueComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Banque", True))
        Me.BanqueComboBox.DataSource = Me.BanqueBindingSource
        Me.BanqueComboBox.DisplayMember = "Valeur"
        Me.BanqueComboBox.FormattingEnabled = True
        Me.BanqueComboBox.Location = New System.Drawing.Point(96, 60)
        Me.BanqueComboBox.Name = "BanqueComboBox"
        Me.BanqueComboBox.Size = New System.Drawing.Size(203, 21)
        Me.BanqueComboBox.TabIndex = 5
        Me.BanqueComboBox.ValueMember = "Valeur"
        '
        'BanqueBindingSource
        '
        Me.BanqueBindingSource.DataMember = "ListeChoix"
        Me.BanqueBindingSource.DataSource = Me.DsAgrifact
        Me.BanqueBindingSource.Sort = "nOrdreValeur"
        '
        'ModePaiementComboBox
        '
        Me.ModePaiementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "ModePaiement", True))
        Me.ModePaiementComboBox.DataSource = Me.ModesPaiementBindingSource
        Me.ModePaiementComboBox.DisplayMember = "Valeur"
        Me.ModePaiementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModePaiementComboBox.FormattingEnabled = True
        Me.ModePaiementComboBox.Location = New System.Drawing.Point(96, 33)
        Me.ModePaiementComboBox.Name = "ModePaiementComboBox"
        Me.ModePaiementComboBox.Size = New System.Drawing.Size(203, 21)
        Me.ModePaiementComboBox.TabIndex = 3
        Me.ModePaiementComboBox.ValueMember = "Valeur"
        '
        'ModesPaiementBindingSource
        '
        Me.ModesPaiementBindingSource.DataMember = "ListeChoix"
        Me.ModesPaiementBindingSource.DataSource = Me.DsAgrifact
        Me.ModesPaiementBindingSource.Sort = "nOrdreValeur"
        '
        'RemiseTextBox
        '
        Me.RemiseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Remise", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "#0.00'%'"))
        Me.RemiseTextBox.Location = New System.Drawing.Point(96, 87)
        Me.RemiseTextBox.MaxLength = 7
        Me.RemiseTextBox.Name = "RemiseTextBox"
        Me.RemiseTextBox.Size = New System.Drawing.Size(50, 20)
        Me.RemiseTextBox.TabIndex = 7
        Me.RemiseTextBox.Text = "100,00%"
        Me.RemiseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NTarifComboBox
        '
        Me.NTarifComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.FournBindingSource, "nTarif", True))
        Me.NTarifComboBox.DataSource = Me.TarifBindingSource
        Me.NTarifComboBox.DisplayMember = "Libelle"
        Me.NTarifComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NTarifComboBox.FormattingEnabled = True
        Me.NTarifComboBox.Location = New System.Drawing.Point(96, 6)
        Me.NTarifComboBox.Name = "NTarifComboBox"
        Me.NTarifComboBox.Size = New System.Drawing.Size(203, 21)
        Me.NTarifComboBox.TabIndex = 1
        Me.NTarifComboBox.ValueMember = "nTarif"
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "Tarif"
        Me.TarifBindingSource.DataSource = Me.DsAgrifact
        '
        'tpTel
        '
        Me.tpTel.Controls.Add(Me.TelephoneEntrepriseDataGridView)
        Me.tpTel.Location = New System.Drawing.Point(4, 22)
        Me.tpTel.Name = "tpTel"
        Me.tpTel.Size = New System.Drawing.Size(417, 207)
        Me.tpTel.TabIndex = 2
        Me.tpTel.Text = "Téléphone"
        Me.tpTel.UseVisualStyleBackColor = True
        '
        'TelephoneEntrepriseDataGridView
        '
        Me.TelephoneEntrepriseDataGridView.AutoGenerateColumns = False
        Me.TelephoneEntrepriseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TelephoneEntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.Type, Me.Numero})
        Me.TelephoneEntrepriseDataGridView.DataSource = Me.TelephoneEntrepriseBindingSource
        Me.TelephoneEntrepriseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelephoneEntrepriseDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.TelephoneEntrepriseDataGridView.Name = "TelephoneEntrepriseDataGridView"
        Me.TelephoneEntrepriseDataGridView.RowHeadersVisible = False
        Me.TelephoneEntrepriseDataGridView.Size = New System.Drawing.Size(417, 207)
        Me.TelephoneEntrepriseDataGridView.TabIndex = 0
        '
        'NEntrepriseDataGridViewTextBoxColumn
        '
        Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
        Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.DisplayStyleForCurrentCellOnly = True
        Me.Type.HeaderText = "Type"
        Me.Type.Items.AddRange(New Object() {"Siège", "Portable", "Fax"})
        Me.Type.Name = "Type"
        Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Numero
        '
        Me.Numero.DataPropertyName = "Numero"
        Me.Numero.HeaderText = "Numéro"
        Me.Numero.Name = "Numero"
        Me.Numero.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TelephoneEntrepriseBindingSource
        '
        Me.TelephoneEntrepriseBindingSource.DataMember = "FK_TelephoneEntreprise_Entreprise"
        Me.TelephoneEntrepriseBindingSource.DataSource = Me.FournBindingSource
        '
        'tpObs
        '
        Me.tpObs.Controls.Add(Me.ObservationsTextBox)
        Me.tpObs.Location = New System.Drawing.Point(4, 22)
        Me.tpObs.Name = "tpObs"
        Me.tpObs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpObs.Size = New System.Drawing.Size(417, 207)
        Me.tpObs.TabIndex = 3
        Me.tpObs.Text = "Observations"
        Me.tpObs.UseVisualStyleBackColor = True
        '
        'ObservationsTextBox
        '
        Me.ObservationsTextBox.AcceptsReturn = True
        Me.ObservationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Observations", True))
        Me.ObservationsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObservationsTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ObservationsTextBox.Multiline = True
        Me.ObservationsTextBox.Name = "ObservationsTextBox"
        Me.ObservationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ObservationsTextBox.Size = New System.Drawing.Size(411, 201)
        Me.ObservationsTextBox.TabIndex = 16
        '
        'CibleCommercialTabPage
        '
        Me.CibleCommercialTabPage.Controls.Add(Me.NouveauCibleCommercialButton)
        Me.CibleCommercialTabPage.Controls.Add(Me.AjouterCibleCommercialButton)
        Me.CibleCommercialTabPage.Controls.Add(Me.CibleCommercialComboBox)
        Me.CibleCommercialTabPage.Controls.Add(Me.CibleCommercialTextBox)
        Me.CibleCommercialTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CibleCommercialTabPage.Name = "CibleCommercialTabPage"
        Me.CibleCommercialTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CibleCommercialTabPage.Size = New System.Drawing.Size(417, 207)
        Me.CibleCommercialTabPage.TabIndex = 4
        Me.CibleCommercialTabPage.Text = "Cible commerciale"
        Me.CibleCommercialTabPage.UseVisualStyleBackColor = True
        '
        'NouveauCibleCommercialButton
        '
        Me.NouveauCibleCommercialButton.Location = New System.Drawing.Point(318, 33)
        Me.NouveauCibleCommercialButton.Name = "NouveauCibleCommercialButton"
        Me.NouveauCibleCommercialButton.Size = New System.Drawing.Size(93, 23)
        Me.NouveauCibleCommercialButton.TabIndex = 3
        Me.NouveauCibleCommercialButton.Text = "Nouveau"
        Me.NouveauCibleCommercialButton.UseVisualStyleBackColor = True
        '
        'AjouterCibleCommercialButton
        '
        Me.AjouterCibleCommercialButton.Location = New System.Drawing.Point(211, 33)
        Me.AjouterCibleCommercialButton.Name = "AjouterCibleCommercialButton"
        Me.AjouterCibleCommercialButton.Size = New System.Drawing.Size(101, 23)
        Me.AjouterCibleCommercialButton.TabIndex = 2
        Me.AjouterCibleCommercialButton.Text = "Ajouter"
        Me.AjouterCibleCommercialButton.UseVisualStyleBackColor = True
        '
        'CibleCommercialComboBox
        '
        Me.CibleCommercialComboBox.DataSource = Me.ListeChoixCibleCommercialBindingSource
        Me.CibleCommercialComboBox.DisplayMember = "Valeur"
        Me.CibleCommercialComboBox.FormattingEnabled = True
        Me.CibleCommercialComboBox.Location = New System.Drawing.Point(211, 6)
        Me.CibleCommercialComboBox.Name = "CibleCommercialComboBox"
        Me.CibleCommercialComboBox.Size = New System.Drawing.Size(200, 21)
        Me.CibleCommercialComboBox.TabIndex = 1
        Me.CibleCommercialComboBox.ValueMember = "Valeur"
        '
        'ListeChoixCibleCommercialBindingSource
        '
        Me.ListeChoixCibleCommercialBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixCibleCommercialBindingSource.DataSource = Me.DsAgrifact
        Me.ListeChoixCibleCommercialBindingSource.Filter = ""
        '
        'CibleCommercialTextBox
        '
        Me.CibleCommercialTextBox.AcceptsReturn = True
        Me.CibleCommercialTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "CibleCommercial", True))
        Me.CibleCommercialTextBox.Location = New System.Drawing.Point(6, 6)
        Me.CibleCommercialTextBox.Multiline = True
        Me.CibleCommercialTextBox.Name = "CibleCommercialTextBox"
        Me.CibleCommercialTextBox.Size = New System.Drawing.Size(199, 195)
        Me.CibleCommercialTextBox.TabIndex = 0
        '
        'CiviliteComboBox
        '
        Me.CiviliteComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Civilite", True))
        Me.CiviliteComboBox.DataSource = Me.CivilitesBindingSource
        Me.CiviliteComboBox.DisplayMember = "Valeur"
        Me.CiviliteComboBox.FormattingEnabled = True
        Me.CiviliteComboBox.Location = New System.Drawing.Point(12, 8)
        Me.CiviliteComboBox.Name = "CiviliteComboBox"
        Me.CiviliteComboBox.Size = New System.Drawing.Size(79, 21)
        Me.CiviliteComboBox.TabIndex = 0
        Me.CiviliteComboBox.ValueMember = "Valeur"
        '
        'CivilitesBindingSource
        '
        Me.CivilitesBindingSource.DataMember = "ListeChoix"
        Me.CivilitesBindingSource.DataSource = Me.DsAgrifact
        Me.CivilitesBindingSource.Sort = "nOrdreValeur"
        '
        'NomTextBox
        '
        Me.NomTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(97, 9)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(339, 20)
        Me.NomTextBox.TabIndex = 1
        '
        'EntrepriseTA
        '
        Me.EntrepriseTA.ClearBeforeFill = True
        '
        'ListeChoixTA
        '
        Me.ListeChoixTA.ClearBeforeFill = True
        '
        'TelephoneEntrepriseTableAdapter
        '
        Me.TelephoneEntrepriseTableAdapter.ClearBeforeFill = True
        '
        'TarifTableAdapter
        '
        Me.TarifTableAdapter.ClearBeforeFill = True
        '
        'FrSaisieClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(448, 301)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrSaisieClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fiche Client"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpCoords.ResumeLayout(False)
        Me.tpCoords.PerformLayout()
        Me.tpFacturation.ResumeLayout(False)
        Me.tpFacturation.PerformLayout()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModesPaiementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTel.ResumeLayout(False)
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpObs.ResumeLayout(False)
        Me.tpObs.PerformLayout()
        Me.CibleCommercialTabPage.ResumeLayout(False)
        Me.CibleCommercialTabPage.PerformLayout()
        CType(Me.ListeChoixCibleCommercialBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CivilitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents FournBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents EntrepriseTA As PointDeVente.DsAgrifactTableAdapters.EntrepriseTA
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaysTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ObservationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CiviliteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CivilitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTA As PointDeVente.DsAgrifactTableAdapters.ListeChoixTA
    Friend WithEvents TelephoneEntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TelephoneEntrepriseTableAdapter As PointDeVente.DsAgrifactTableAdapters.TelephoneEntrepriseTA
    Friend WithEvents TelephoneEntrepriseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Numero As PointDeVente.DatagridViewNumericTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SiteInternetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EMailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TbInactif As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpCoords As System.Windows.Forms.TabPage
    Friend WithEvents tpFacturation As System.Windows.Forms.TabPage
    Friend WithEvents tpTel As System.Windows.Forms.TabPage
    Friend WithEvents tpObs As System.Windows.Forms.TabPage
    Friend WithEvents ModePaiementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ModesPaiementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RemiseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NTarifComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TarifTableAdapter As PointDeVente.DsAgrifactTableAdapters.TarifTA
    Friend WithEvents BanqueComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BanqueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FacturationTTCCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CibleCommercialTabPage As System.Windows.Forms.TabPage
    Friend WithEvents CibleCommercialTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CibleCommercialComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ListeChoixCibleCommercialBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AjouterCibleCommercialButton As System.Windows.Forms.Button
    Friend WithEvents NouveauCibleCommercialButton As System.Windows.Forms.Button
End Class