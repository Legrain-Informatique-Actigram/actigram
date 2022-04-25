Public Class FrInfosGenerales
    Inherits GRC.FrBase
    Dim dsParamLocaux As DataSet

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents TxNom As System.Windows.Forms.TextBox
    Friend WithEvents TxCoordonnees As System.Windows.Forms.TextBox
    Friend WithEvents TxPiedPage As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxCodeEtablissement As System.Windows.Forms.TextBox
    Friend WithEvents TxCodeGuichet As System.Windows.Forms.TextBox
    Friend WithEvents TxNCompte As System.Windows.Forms.TextBox
    Friend WithEvents TxCleRIB As System.Windows.Forms.TextBox
    Friend WithEvents TxDomiciliation As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TbInfosGenerales As System.Windows.Forms.TabPage
    Friend WithEvents TbGestionSite As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxEMail As System.Windows.Forms.TextBox
    Friend WithEvents TxServerSMTP As System.Windows.Forms.TextBox
    Friend WithEvents TxServiceGestionSite As System.Windows.Forms.TextBox
    Friend WithEvents TxAdresseSite As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Friend WithEvents GbReglement As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CbBanque As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxEcartReglement As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtSupprimerLogo As System.Windows.Forms.Button
    Friend WithEvents BtAjouterLogo As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxNomDossier As System.Windows.Forms.TextBox
    Friend WithEvents TbAvance As System.Windows.Forms.TabPage
    Friend WithEvents TbParamImpression As System.Windows.Forms.TabPage
    Friend WithEvents TxInfoLegale2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxInfoLegale As System.Windows.Forms.TextBox
    Friend WithEvents cbTypePiece As System.Windows.Forms.ComboBox
    Friend WithEvents BtUseDefault As System.Windows.Forms.Button
    Friend WithEvents ChkImprimerRIB As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarquerFactures As System.Windows.Forms.CheckBox
    Friend WithEvents TxRepEtatsSpecifiques As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowseRepEtatsSpec As System.Windows.Forms.Button
    Friend WithEvents ChkEtatsSpec As System.Windows.Forms.CheckBox
    Friend WithEvents gbApprofact As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtAgenceEau As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CbFormatEnveloppe As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nudLeft As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents nudTop As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxIdMaj As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxPwdMaj As System.Windows.Forms.TextBox
    Friend WithEvents TxPwdMajConf As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtNumAgrement As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodeNAF As System.Windows.Forms.TextBox
    Friend WithEvents TxtSIRET As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CbNumAgrPrefixe As System.Windows.Forms.ComboBox
    Friend WithEvents GbMarge As System.Windows.Forms.GroupBox
    Friend WithEvents TxObjectifMarge As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents gbStocks As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDtInitStock As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkLimitStock As System.Windows.Forms.CheckBox
    Friend WithEvents gbNFacture As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbTypePieceNum As System.Windows.Forms.ComboBox
    Friend WithEvents lbNFacture As System.Windows.Forms.Label
    Friend WithEvents btInitNFacture As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBoxEscompte As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDelaiValiditeEscompte As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTauxEscompte As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxSolstyce As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxCreationLotsSolstyce As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxOrdreDeFacturation As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents UtiliserModelesImpServicesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents SWIFT_BICTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents CodePaysIBANTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents EcheanceVisibleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ModeRgtParDefTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents NomAbregeEntiteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents NbJoursEcheanceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents FdMEcheanceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ActiverMenuPubCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AutresParametresTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DsAgrifact As AgriFact.DsAgrifact
    Friend WithEvents ModeReglement_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModeReglement_DetailTableAdapter As AgriFact.DsAgrifactTableAdapters.ModeReglement_DetailTableAdapter
    Friend WithEvents BanqueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BanqueTableAdapter As AgriFact.DsAgrifactTableAdapters.BanqueTableAdapter
    Friend WithEvents ListeModeReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As AgriFact.DsAgrifactTableAdapters.ListeChoixTableAdapter
    Friend WithEvents ModeReglement_DetailGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ModeReglement_DetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ModeReglement As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents nBanque As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents RemiseAutoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BtSaveLogo As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrInfosGenerales))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.TxNom = New System.Windows.Forms.TextBox
        Me.TxCoordonnees = New System.Windows.Forms.TextBox
        Me.TxPiedPage = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxCodeEtablissement = New System.Windows.Forms.TextBox
        Me.TxCodeGuichet = New System.Windows.Forms.TextBox
        Me.TxNCompte = New System.Windows.Forms.TextBox
        Me.TxCleRIB = New System.Windows.Forms.TextBox
        Me.TxDomiciliation = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TbInfosGenerales = New System.Windows.Forms.TabPage
        Me.Label42 = New System.Windows.Forms.Label
        Me.SWIFT_BICTextBox = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.CodePaysIBANTextBox = New System.Windows.Forms.TextBox
        Me.BtSaveLogo = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxNomDossier = New System.Windows.Forms.TextBox
        Me.BtAjouterLogo = New System.Windows.Forms.Button
        Me.BtSupprimerLogo = New System.Windows.Forms.Button
        Me.Logo = New System.Windows.Forms.PictureBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TbParamImpression = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.EcheanceVisibleCheckBox = New System.Windows.Forms.CheckBox
        Me.NomAbregeEntiteTextBox = New System.Windows.Forms.TextBox
        Me.ModeRgtParDefTextBox = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.UtiliserModelesImpServicesCheckBox = New System.Windows.Forms.CheckBox
        Me.TextBoxOrdreDeFacturation = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.cbTypePiece = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.nudTop = New System.Windows.Forms.NumericUpDown
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.nudLeft = New System.Windows.Forms.NumericUpDown
        Me.Label22 = New System.Windows.Forms.Label
        Me.CbFormatEnveloppe = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ChkEtatsSpec = New System.Windows.Forms.CheckBox
        Me.BtBrowseRepEtatsSpec = New System.Windows.Forms.Button
        Me.TxRepEtatsSpecifiques = New System.Windows.Forms.TextBox
        Me.ChkMarquerFactures = New System.Windows.Forms.CheckBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxInfoLegale = New System.Windows.Forms.TextBox
        Me.ChkImprimerRIB = New System.Windows.Forms.CheckBox
        Me.BtUseDefault = New System.Windows.Forms.Button
        Me.TxInfoLegale2 = New System.Windows.Forms.TextBox
        Me.TbAvance = New System.Windows.Forms.TabPage
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.gbNFacture = New System.Windows.Forms.GroupBox
        Me.cbTypePieceNum = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.lbNFacture = New System.Windows.Forms.Label
        Me.btInitNFacture = New System.Windows.Forms.Button
        Me.GbReglement = New System.Windows.Forms.GroupBox
        Me.TxEcartReglement = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CbBanque = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.gbStocks = New System.Windows.Forms.GroupBox
        Me.dtpDtInitStock = New System.Windows.Forms.DateTimePicker
        Me.ChkLimitStock = New System.Windows.Forms.CheckBox
        Me.gbApprofact = New System.Windows.Forms.GroupBox
        Me.CbNumAgrPrefixe = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxtSIRET = New System.Windows.Forms.TextBox
        Me.TxtCodeNAF = New System.Windows.Forms.TextBox
        Me.TxtNumAgrement = New System.Windows.Forms.TextBox
        Me.TxtAgenceEau = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.GbMarge = New System.Windows.Forms.GroupBox
        Me.TxObjectifMarge = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.GroupBoxEscompte = New System.Windows.Forms.GroupBox
        Me.TextBoxDelaiValiditeEscompte = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.TextBoxTauxEscompte = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.GroupBoxSolstyce = New System.Windows.Forms.GroupBox
        Me.CheckBoxCreationLotsSolstyce = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.FdMEcheanceCheckBox = New System.Windows.Forms.CheckBox
        Me.NbJoursEcheanceTextBox = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.ActiverMenuPubCheckBox = New System.Windows.Forms.CheckBox
        Me.TbGestionSite = New System.Windows.Forms.TabPage
        Me.TxPwdMajConf = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxPwdMaj = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxIdMaj = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxAdresseSite = New System.Windows.Forms.TextBox
        Me.TxServiceGestionSite = New System.Windows.Forms.TextBox
        Me.TxServerSMTP = New System.Windows.Forms.TextBox
        Me.TxEMail = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.AutresParametresTabPage = New System.Windows.Forms.TabPage
        Me.ModeReglement_DetailGroupBox = New System.Windows.Forms.GroupBox
        Me.ModeReglement_DetailDataGridView = New System.Windows.Forms.DataGridView
        Me.ListeModeReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.BanqueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModeReglement_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModeReglement_DetailTableAdapter = New AgriFact.DsAgrifactTableAdapters.ModeReglement_DetailTableAdapter
        Me.BanqueTableAdapter = New AgriFact.DsAgrifactTableAdapters.BanqueTableAdapter
        Me.ListeChoixTableAdapter = New AgriFact.DsAgrifactTableAdapters.ListeChoixTableAdapter
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModeReglement = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.nBanque = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.RemiseAutoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.TbInfosGenerales.SuspendLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbParamImpression.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TbAvance.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gbNFacture.SuspendLayout()
        Me.GbReglement.SuspendLayout()
        Me.gbStocks.SuspendLayout()
        Me.gbApprofact.SuspendLayout()
        Me.GbMarge.SuspendLayout()
        Me.GroupBoxEscompte.SuspendLayout()
        Me.GroupBoxSolstyce.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TbGestionSite.SuspendLayout()
        Me.AutresParametresTabPage.SuspendLayout()
        Me.ModeReglement_DetailGroupBox.SuspendLayout()
        CType(Me.ModeReglement_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeModeReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModeReglement_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.Images.SetKeyName(0, "")
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList32.Images.SetKeyName(0, "")
        Me.ImageList32.Images.SetKeyName(1, "")
        Me.ImageList32.Images.SetKeyName(2, "")
        Me.ImageList32.Images.SetKeyName(3, "")
        Me.ImageList32.Images.SetKeyName(4, "")
        Me.ImageList32.Images.SetKeyName(5, "")
        Me.ImageList32.Images.SetKeyName(6, "")
        Me.ImageList32.Images.SetKeyName(7, "")
        Me.ImageList32.Images.SetKeyName(8, "")
        Me.ImageList32.Images.SetKeyName(9, "")
        Me.ImageList32.Images.SetKeyName(10, "")
        Me.ImageList32.Images.SetKeyName(11, "")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.Images.SetKeyName(0, "")
        Me.ImageList24.Images.SetKeyName(1, "")
        Me.ImageList24.Images.SetKeyName(2, "")
        Me.ImageList24.Images.SetKeyName(3, "")
        Me.ImageList24.Images.SetKeyName(4, "")
        Me.ImageList24.Images.SetKeyName(5, "")
        Me.ImageList24.Images.SetKeyName(6, "")
        Me.ImageList24.Images.SetKeyName(7, "")
        Me.ImageList24.Images.SetKeyName(8, "")
        Me.ImageList24.Images.SetKeyName(9, "")
        Me.ImageList24.Images.SetKeyName(10, "")
        Me.ImageList24.Images.SetKeyName(11, "")
        Me.ImageList24.Images.SetKeyName(12, "")
        Me.ImageList24.Images.SetKeyName(13, "")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Société"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Coordonnées"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Infos Pied Page"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(490, 641)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 4
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.Location = New System.Drawing.Point(410, 641)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 3
        Me.BtOk.Text = "OK"
        '
        'TxNom
        '
        Me.TxNom.Location = New System.Drawing.Point(112, 32)
        Me.TxNom.MaxLength = 255
        Me.TxNom.Name = "TxNom"
        Me.TxNom.Size = New System.Drawing.Size(440, 20)
        Me.TxNom.TabIndex = 5
        '
        'TxCoordonnees
        '
        Me.TxCoordonnees.AcceptsReturn = True
        Me.TxCoordonnees.AcceptsTab = True
        Me.TxCoordonnees.Location = New System.Drawing.Point(112, 56)
        Me.TxCoordonnees.MaxLength = 254
        Me.TxCoordonnees.Multiline = True
        Me.TxCoordonnees.Name = "TxCoordonnees"
        Me.TxCoordonnees.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxCoordonnees.Size = New System.Drawing.Size(440, 80)
        Me.TxCoordonnees.TabIndex = 6
        '
        'TxPiedPage
        '
        Me.TxPiedPage.AcceptsReturn = True
        Me.TxPiedPage.AcceptsTab = True
        Me.TxPiedPage.Location = New System.Drawing.Point(112, 144)
        Me.TxPiedPage.MaxLength = 254
        Me.TxPiedPage.Multiline = True
        Me.TxPiedPage.Name = "TxPiedPage"
        Me.TxPiedPage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxPiedPage.Size = New System.Drawing.Size(440, 96)
        Me.TxPiedPage.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "IBAN"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(156, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 32)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Code Etablissement"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(241, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 32)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Code Guichet"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(296, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 32)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "N° de Compte"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(376, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 32)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Clé RIB"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(408, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 32)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Domiciliation"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxCodeEtablissement
        '
        Me.TxCodeEtablissement.Location = New System.Drawing.Point(159, 288)
        Me.TxCodeEtablissement.MaxLength = 5
        Me.TxCodeEtablissement.Name = "TxCodeEtablissement"
        Me.TxCodeEtablissement.Size = New System.Drawing.Size(67, 20)
        Me.TxCodeEtablissement.TabIndex = 16
        Me.TxCodeEtablissement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxCodeGuichet
        '
        Me.TxCodeGuichet.Location = New System.Drawing.Point(226, 288)
        Me.TxCodeGuichet.MaxLength = 5
        Me.TxCodeGuichet.Name = "TxCodeGuichet"
        Me.TxCodeGuichet.Size = New System.Drawing.Size(70, 20)
        Me.TxCodeGuichet.TabIndex = 17
        Me.TxCodeGuichet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxNCompte
        '
        Me.TxNCompte.Location = New System.Drawing.Point(296, 288)
        Me.TxNCompte.MaxLength = 11
        Me.TxNCompte.Name = "TxNCompte"
        Me.TxNCompte.Size = New System.Drawing.Size(80, 20)
        Me.TxNCompte.TabIndex = 18
        Me.TxNCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxCleRIB
        '
        Me.TxCleRIB.Location = New System.Drawing.Point(376, 288)
        Me.TxCleRIB.MaxLength = 2
        Me.TxCleRIB.Name = "TxCleRIB"
        Me.TxCleRIB.Size = New System.Drawing.Size(32, 20)
        Me.TxCleRIB.TabIndex = 19
        Me.TxCleRIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxDomiciliation
        '
        Me.TxDomiciliation.Location = New System.Drawing.Point(408, 288)
        Me.TxDomiciliation.MaxLength = 50
        Me.TxDomiciliation.Name = "TxDomiciliation"
        Me.TxDomiciliation.Size = New System.Drawing.Size(144, 20)
        Me.TxDomiciliation.TabIndex = 20
        Me.TxDomiciliation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TbInfosGenerales)
        Me.TabControl1.Controls.Add(Me.TbParamImpression)
        Me.TabControl1.Controls.Add(Me.TbAvance)
        Me.TabControl1.Controls.Add(Me.TbGestionSite)
        Me.TabControl1.Controls.Add(Me.AutresParametresTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(568, 631)
        Me.TabControl1.TabIndex = 22
        '
        'TbInfosGenerales
        '
        Me.TbInfosGenerales.BackColor = System.Drawing.Color.Transparent
        Me.TbInfosGenerales.Controls.Add(Me.Label42)
        Me.TbInfosGenerales.Controls.Add(Me.SWIFT_BICTextBox)
        Me.TbInfosGenerales.Controls.Add(Me.Label39)
        Me.TbInfosGenerales.Controls.Add(Me.CodePaysIBANTextBox)
        Me.TbInfosGenerales.Controls.Add(Me.BtSaveLogo)
        Me.TbInfosGenerales.Controls.Add(Me.Label18)
        Me.TbInfosGenerales.Controls.Add(Me.TxNomDossier)
        Me.TbInfosGenerales.Controls.Add(Me.BtAjouterLogo)
        Me.TbInfosGenerales.Controls.Add(Me.BtSupprimerLogo)
        Me.TbInfosGenerales.Controls.Add(Me.Logo)
        Me.TbInfosGenerales.Controls.Add(Me.Label15)
        Me.TbInfosGenerales.Controls.Add(Me.Label9)
        Me.TbInfosGenerales.Controls.Add(Me.Label10)
        Me.TbInfosGenerales.Controls.Add(Me.TxCodeEtablissement)
        Me.TbInfosGenerales.Controls.Add(Me.TxCleRIB)
        Me.TbInfosGenerales.Controls.Add(Me.TxCodeGuichet)
        Me.TbInfosGenerales.Controls.Add(Me.Label8)
        Me.TbInfosGenerales.Controls.Add(Me.TxDomiciliation)
        Me.TbInfosGenerales.Controls.Add(Me.TxPiedPage)
        Me.TbInfosGenerales.Controls.Add(Me.Label3)
        Me.TbInfosGenerales.Controls.Add(Me.Label1)
        Me.TbInfosGenerales.Controls.Add(Me.Label2)
        Me.TbInfosGenerales.Controls.Add(Me.TxNom)
        Me.TbInfosGenerales.Controls.Add(Me.TxCoordonnees)
        Me.TbInfosGenerales.Controls.Add(Me.TxNCompte)
        Me.TbInfosGenerales.Controls.Add(Me.Label5)
        Me.TbInfosGenerales.Controls.Add(Me.Label6)
        Me.TbInfosGenerales.Controls.Add(Me.Label7)
        Me.TbInfosGenerales.Location = New System.Drawing.Point(4, 22)
        Me.TbInfosGenerales.Name = "TbInfosGenerales"
        Me.TbInfosGenerales.Size = New System.Drawing.Size(560, 605)
        Me.TbInfosGenerales.TabIndex = 0
        Me.TbInfosGenerales.Text = "Infos Générales"
        Me.TbInfosGenerales.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(112, 253)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(47, 32)
        Me.Label42.TabIndex = 32
        Me.Label42.Text = "Code Pays"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SWIFT_BICTextBox
        '
        Me.SWIFT_BICTextBox.Location = New System.Drawing.Point(185, 314)
        Me.SWIFT_BICTextBox.MaxLength = 11
        Me.SWIFT_BICTextBox.Name = "SWIFT_BICTextBox"
        Me.SWIFT_BICTextBox.Size = New System.Drawing.Size(144, 20)
        Me.SWIFT_BICTextBox.TabIndex = 31
        Me.SWIFT_BICTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(109, 313)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 20)
        Me.Label39.TabIndex = 30
        Me.Label39.Text = "SWIFT/BIC"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CodePaysIBANTextBox
        '
        Me.CodePaysIBANTextBox.Location = New System.Drawing.Point(112, 288)
        Me.CodePaysIBANTextBox.MaxLength = 4
        Me.CodePaysIBANTextBox.Name = "CodePaysIBANTextBox"
        Me.CodePaysIBANTextBox.Size = New System.Drawing.Size(47, 20)
        Me.CodePaysIBANTextBox.TabIndex = 29
        Me.CodePaysIBANTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtSaveLogo
        '
        Me.BtSaveLogo.Location = New System.Drawing.Point(112, 415)
        Me.BtSaveLogo.Name = "BtSaveLogo"
        Me.BtSaveLogo.Size = New System.Drawing.Size(120, 23)
        Me.BtSaveLogo.TabIndex = 28
        Me.BtSaveLogo.Text = "Enregistrer le Logo"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 23)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Nom du dossier"
        '
        'TxNomDossier
        '
        Me.TxNomDossier.Location = New System.Drawing.Point(112, 8)
        Me.TxNomDossier.Name = "TxNomDossier"
        Me.TxNomDossier.Size = New System.Drawing.Size(440, 20)
        Me.TxNomDossier.TabIndex = 27
        '
        'BtAjouterLogo
        '
        Me.BtAjouterLogo.Location = New System.Drawing.Point(112, 351)
        Me.BtAjouterLogo.Name = "BtAjouterLogo"
        Me.BtAjouterLogo.Size = New System.Drawing.Size(120, 23)
        Me.BtAjouterLogo.TabIndex = 25
        Me.BtAjouterLogo.Text = "Ajouter un Logo"
        '
        'BtSupprimerLogo
        '
        Me.BtSupprimerLogo.Location = New System.Drawing.Point(112, 383)
        Me.BtSupprimerLogo.Name = "BtSupprimerLogo"
        Me.BtSupprimerLogo.Size = New System.Drawing.Size(120, 23)
        Me.BtSupprimerLogo.TabIndex = 24
        Me.BtSupprimerLogo.Text = "Supprimer le Logo"
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.White
        Me.Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Logo.Location = New System.Drawing.Point(240, 351)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(140, 150)
        Me.Logo.TabIndex = 23
        Me.Logo.TabStop = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 351)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 23)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Logo"
        '
        'TbParamImpression
        '
        Me.TbParamImpression.Controls.Add(Me.GroupBox3)
        Me.TbParamImpression.Controls.Add(Me.Label38)
        Me.TbParamImpression.Controls.Add(Me.Label37)
        Me.TbParamImpression.Controls.Add(Me.UtiliserModelesImpServicesCheckBox)
        Me.TbParamImpression.Controls.Add(Me.TextBoxOrdreDeFacturation)
        Me.TbParamImpression.Controls.Add(Me.Label36)
        Me.TbParamImpression.Controls.Add(Me.cbTypePiece)
        Me.TbParamImpression.Controls.Add(Me.GroupBox2)
        Me.TbParamImpression.Controls.Add(Me.ChkEtatsSpec)
        Me.TbParamImpression.Controls.Add(Me.BtBrowseRepEtatsSpec)
        Me.TbParamImpression.Controls.Add(Me.TxRepEtatsSpecifiques)
        Me.TbParamImpression.Controls.Add(Me.ChkMarquerFactures)
        Me.TbParamImpression.Controls.Add(Me.Label19)
        Me.TbParamImpression.Controls.Add(Me.GroupBox1)
        Me.TbParamImpression.Location = New System.Drawing.Point(4, 22)
        Me.TbParamImpression.Name = "TbParamImpression"
        Me.TbParamImpression.Size = New System.Drawing.Size(560, 605)
        Me.TbParamImpression.TabIndex = 3
        Me.TbParamImpression.Text = "Paramètres impressions"
        Me.TbParamImpression.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.EcheanceVisibleCheckBox)
        Me.GroupBox3.Controls.Add(Me.NomAbregeEntiteTextBox)
        Me.GroupBox3.Controls.Add(Me.ModeRgtParDefTextBox)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Location = New System.Drawing.Point(326, 380)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(226, 104)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Infos complémentaires"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 27)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(100, 13)
        Me.Label40.TabIndex = 41
        Me.Label40.Text = "Nom abrégé entité :"
        '
        'EcheanceVisibleCheckBox
        '
        Me.EcheanceVisibleCheckBox.AutoSize = True
        Me.EcheanceVisibleCheckBox.Location = New System.Drawing.Point(6, 75)
        Me.EcheanceVisibleCheckBox.Name = "EcheanceVisibleCheckBox"
        Me.EcheanceVisibleCheckBox.Size = New System.Drawing.Size(107, 17)
        Me.EcheanceVisibleCheckBox.TabIndex = 45
        Me.EcheanceVisibleCheckBox.Text = "Echéance visible"
        Me.EcheanceVisibleCheckBox.UseVisualStyleBackColor = True
        '
        'NomAbregeEntiteTextBox
        '
        Me.NomAbregeEntiteTextBox.Location = New System.Drawing.Point(123, 21)
        Me.NomAbregeEntiteTextBox.Name = "NomAbregeEntiteTextBox"
        Me.NomAbregeEntiteTextBox.Size = New System.Drawing.Size(98, 20)
        Me.NomAbregeEntiteTextBox.TabIndex = 42
        '
        'ModeRgtParDefTextBox
        '
        Me.ModeRgtParDefTextBox.Location = New System.Drawing.Point(123, 50)
        Me.ModeRgtParDefTextBox.Name = "ModeRgtParDefTextBox"
        Me.ModeRgtParDefTextBox.Size = New System.Drawing.Size(98, 20)
        Me.ModeRgtParDefTextBox.TabIndex = 44
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 53)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(94, 13)
        Me.Label41.TabIndex = 43
        Me.Label41.Text = "Mode rgt par déf. :"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(24, 353)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(199, 13)
        Me.Label38.TabIndex = 40
        Me.Label38.Text = " par service contenant ses propres états)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(24, 334)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(334, 13)
        Me.Label37.TabIndex = 39
        Me.Label37.Text = "(Le répertoire des états spécifiques devra posséder un sous-répertoire"
        '
        'UtiliserModelesImpServicesCheckBox
        '
        Me.UtiliserModelesImpServicesCheckBox.AutoSize = True
        Me.UtiliserModelesImpServicesCheckBox.Location = New System.Drawing.Point(8, 314)
        Me.UtiliserModelesImpServicesCheckBox.Name = "UtiliserModelesImpServicesCheckBox"
        Me.UtiliserModelesImpServicesCheckBox.Size = New System.Drawing.Size(293, 17)
        Me.UtiliserModelesImpServicesCheckBox.TabIndex = 38
        Me.UtiliserModelesImpServicesCheckBox.Text = "Utiliser les modèles d'impression en fonction des services"
        Me.UtiliserModelesImpServicesCheckBox.UseVisualStyleBackColor = True
        '
        'TextBoxOrdreDeFacturation
        '
        Me.TextBoxOrdreDeFacturation.Location = New System.Drawing.Point(176, 490)
        Me.TextBoxOrdreDeFacturation.Name = "TextBoxOrdreDeFacturation"
        Me.TextBoxOrdreDeFacturation.Size = New System.Drawing.Size(202, 20)
        Me.TextBoxOrdreDeFacturation.TabIndex = 37
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(5, 493)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(104, 13)
        Me.Label36.TabIndex = 36
        Me.Label36.Text = "Ordre de facturation:"
        '
        'cbTypePiece
        '
        Me.cbTypePiece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTypePiece.Location = New System.Drawing.Point(152, 12)
        Me.cbTypePiece.Name = "cbTypePiece"
        Me.cbTypePiece.Size = New System.Drawing.Size(144, 21)
        Me.cbTypePiece.TabIndex = 25
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.nudTop)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.nudLeft)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.CbFormatEnveloppe)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 380)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 104)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Positionnement de l'adresse"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(248, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(23, 13)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "mm"
        '
        'nudTop
        '
        Me.nudTop.Location = New System.Drawing.Point(176, 72)
        Me.nudTop.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.nudTop.Name = "nudTop"
        Me.nudTop.Size = New System.Drawing.Size(64, 20)
        Me.nudTop.TabIndex = 6
        Me.nudTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(120, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Haut :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(248, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 13)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "mm"
        '
        'nudLeft
        '
        Me.nudLeft.Location = New System.Drawing.Point(176, 48)
        Me.nudLeft.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.nudLeft.Name = "nudLeft"
        Me.nudLeft.Size = New System.Drawing.Size(64, 20)
        Me.nudLeft.TabIndex = 3
        Me.nudLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(120, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Gauche :"
        '
        'CbFormatEnveloppe
        '
        Me.CbFormatEnveloppe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbFormatEnveloppe.Location = New System.Drawing.Point(176, 22)
        Me.CbFormatEnveloppe.Name = "CbFormatEnveloppe"
        Me.CbFormatEnveloppe.Size = New System.Drawing.Size(121, 21)
        Me.CbFormatEnveloppe.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(151, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Format d'enveloppe à fenêtre :"
        '
        'ChkEtatsSpec
        '
        Me.ChkEtatsSpec.Location = New System.Drawing.Point(8, 284)
        Me.ChkEtatsSpec.Name = "ChkEtatsSpec"
        Me.ChkEtatsSpec.Size = New System.Drawing.Size(168, 24)
        Me.ChkEtatsSpec.TabIndex = 34
        Me.ChkEtatsSpec.Text = "Utiliser les états spécifiques:"
        '
        'BtBrowseRepEtatsSpec
        '
        Me.BtBrowseRepEtatsSpec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtBrowseRepEtatsSpec.Location = New System.Drawing.Point(472, 285)
        Me.BtBrowseRepEtatsSpec.Name = "BtBrowseRepEtatsSpec"
        Me.BtBrowseRepEtatsSpec.Size = New System.Drawing.Size(75, 23)
        Me.BtBrowseRepEtatsSpec.TabIndex = 33
        Me.BtBrowseRepEtatsSpec.Text = "Parcourir..."
        '
        'TxRepEtatsSpecifiques
        '
        Me.TxRepEtatsSpecifiques.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxRepEtatsSpecifiques.Location = New System.Drawing.Point(176, 286)
        Me.TxRepEtatsSpecifiques.Name = "TxRepEtatsSpecifiques"
        Me.TxRepEtatsSpecifiques.Size = New System.Drawing.Size(288, 20)
        Me.TxRepEtatsSpecifiques.TabIndex = 31
        Me.TxRepEtatsSpecifiques.Text = "RepEtatsSpecifiques"
        '
        'ChkMarquerFactures
        '
        Me.ChkMarquerFactures.Location = New System.Drawing.Point(8, 256)
        Me.ChkMarquerFactures.Name = "ChkMarquerFactures"
        Me.ChkMarquerFactures.Size = New System.Drawing.Size(536, 24)
        Me.ChkMarquerFactures.TabIndex = 30
        Me.ChkMarquerFactures.Text = "Verrouiller les factures imprimées"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(135, 13)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Paramètres d'impression     "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxInfoLegale)
        Me.GroupBox1.Controls.Add(Me.ChkImprimerRIB)
        Me.GroupBox1.Controls.Add(Me.BtUseDefault)
        Me.GroupBox1.Controls.Add(Me.TxInfoLegale2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 232)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Informations légales"
        '
        'TxInfoLegale
        '
        Me.TxInfoLegale.AcceptsReturn = True
        Me.TxInfoLegale.AcceptsTab = True
        Me.TxInfoLegale.Location = New System.Drawing.Point(8, 40)
        Me.TxInfoLegale.MaxLength = 254
        Me.TxInfoLegale.Multiline = True
        Me.TxInfoLegale.Name = "TxInfoLegale"
        Me.TxInfoLegale.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxInfoLegale.Size = New System.Drawing.Size(520, 64)
        Me.TxInfoLegale.TabIndex = 23
        '
        'ChkImprimerRIB
        '
        Me.ChkImprimerRIB.Location = New System.Drawing.Point(16, 192)
        Me.ChkImprimerRIB.Name = "ChkImprimerRIB"
        Me.ChkImprimerRIB.Size = New System.Drawing.Size(216, 24)
        Me.ChkImprimerRIB.TabIndex = 27
        Me.ChkImprimerRIB.Text = "Imprimer les coordonnées bancaires"
        '
        'BtUseDefault
        '
        Me.BtUseDefault.Location = New System.Drawing.Point(360, 192)
        Me.BtUseDefault.Name = "BtUseDefault"
        Me.BtUseDefault.Size = New System.Drawing.Size(168, 23)
        Me.BtUseDefault.TabIndex = 26
        Me.BtUseDefault.Text = "Utiliser les options par défaut"
        '
        'TxInfoLegale2
        '
        Me.TxInfoLegale2.AcceptsReturn = True
        Me.TxInfoLegale2.AcceptsTab = True
        Me.TxInfoLegale2.Location = New System.Drawing.Point(8, 112)
        Me.TxInfoLegale2.MaxLength = 254
        Me.TxInfoLegale2.Multiline = True
        Me.TxInfoLegale2.Name = "TxInfoLegale2"
        Me.TxInfoLegale2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxInfoLegale2.Size = New System.Drawing.Size(520, 72)
        Me.TxInfoLegale2.TabIndex = 24
        '
        'TbAvance
        '
        Me.TbAvance.Controls.Add(Me.FlowLayoutPanel1)
        Me.TbAvance.Location = New System.Drawing.Point(4, 22)
        Me.TbAvance.Name = "TbAvance"
        Me.TbAvance.Size = New System.Drawing.Size(560, 605)
        Me.TbAvance.TabIndex = 2
        Me.TbAvance.Text = "Propriétés Avancées"
        Me.TbAvance.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.gbNFacture)
        Me.FlowLayoutPanel1.Controls.Add(Me.GbReglement)
        Me.FlowLayoutPanel1.Controls.Add(Me.gbStocks)
        Me.FlowLayoutPanel1.Controls.Add(Me.gbApprofact)
        Me.FlowLayoutPanel1.Controls.Add(Me.GbMarge)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBoxEscompte)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBoxSolstyce)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.ActiverMenuPubCheckBox)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(560, 605)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'gbNFacture
        '
        Me.gbNFacture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbNFacture.Controls.Add(Me.cbTypePieceNum)
        Me.gbNFacture.Controls.Add(Me.Label33)
        Me.gbNFacture.Controls.Add(Me.lbNFacture)
        Me.gbNFacture.Controls.Add(Me.btInitNFacture)
        Me.gbNFacture.Location = New System.Drawing.Point(8, 8)
        Me.gbNFacture.Name = "gbNFacture"
        Me.gbNFacture.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbNFacture.Size = New System.Drawing.Size(408, 64)
        Me.gbNFacture.TabIndex = 4
        Me.gbNFacture.TabStop = False
        Me.gbNFacture.Text = "Numérotation des "
        '
        'cbTypePieceNum
        '
        Me.cbTypePieceNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTypePieceNum.Location = New System.Drawing.Point(107, 0)
        Me.cbTypePieceNum.Name = "cbTypePieceNum"
        Me.cbTypePieceNum.Size = New System.Drawing.Size(144, 21)
        Me.cbTypePieceNum.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Window
        Me.Label33.Location = New System.Drawing.Point(6, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(118, 21)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Numérotation des "
        '
        'lbNFacture
        '
        Me.lbNFacture.AutoSize = True
        Me.lbNFacture.Location = New System.Drawing.Point(8, 32)
        Me.lbNFacture.Name = "lbNFacture"
        Me.lbNFacture.Size = New System.Drawing.Size(167, 13)
        Me.lbNFacture.TabIndex = 2
        Me.lbNFacture.Text = "Le prochain numéro de {0} est {1}"
        '
        'btInitNFacture
        '
        Me.btInitNFacture.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btInitNFacture.Location = New System.Drawing.Point(288, 24)
        Me.btInitNFacture.Name = "btInitNFacture"
        Me.btInitNFacture.Size = New System.Drawing.Size(104, 32)
        Me.btInitNFacture.TabIndex = 3
        Me.btInitNFacture.Text = "Recommencer la numérotation"
        '
        'GbReglement
        '
        Me.GbReglement.Controls.Add(Me.TxEcartReglement)
        Me.GbReglement.Controls.Add(Me.Label17)
        Me.GbReglement.Controls.Add(Me.CbBanque)
        Me.GbReglement.Controls.Add(Me.Label16)
        Me.GbReglement.Location = New System.Drawing.Point(8, 78)
        Me.GbReglement.Name = "GbReglement"
        Me.GbReglement.Size = New System.Drawing.Size(408, 83)
        Me.GbReglement.TabIndex = 0
        Me.GbReglement.TabStop = False
        Me.GbReglement.Text = "Règlements"
        '
        'TxEcartReglement
        '
        Me.TxEcartReglement.Location = New System.Drawing.Point(166, 54)
        Me.TxEcartReglement.Name = "TxEcartReglement"
        Me.TxEcartReglement.Size = New System.Drawing.Size(176, 20)
        Me.TxEcartReglement.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 17)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Ecart de Règlement Autorisé"
        '
        'CbBanque
        '
        Me.CbBanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbBanque.Location = New System.Drawing.Point(166, 27)
        Me.CbBanque.Name = "CbBanque"
        Me.CbBanque.Size = New System.Drawing.Size(176, 21)
        Me.CbBanque.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Votre Banque"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbStocks
        '
        Me.gbStocks.Controls.Add(Me.dtpDtInitStock)
        Me.gbStocks.Controls.Add(Me.ChkLimitStock)
        Me.gbStocks.Location = New System.Drawing.Point(8, 167)
        Me.gbStocks.Name = "gbStocks"
        Me.gbStocks.Size = New System.Drawing.Size(408, 56)
        Me.gbStocks.TabIndex = 3
        Me.gbStocks.TabStop = False
        Me.gbStocks.Text = "Stocks"
        '
        'dtpDtInitStock
        '
        Me.dtpDtInitStock.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDtInitStock.Location = New System.Drawing.Point(219, 21)
        Me.dtpDtInitStock.Name = "dtpDtInitStock"
        Me.dtpDtInitStock.Size = New System.Drawing.Size(88, 20)
        Me.dtpDtInitStock.TabIndex = 1
        Me.dtpDtInitStock.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'ChkLimitStock
        '
        Me.ChkLimitStock.Location = New System.Drawing.Point(11, 19)
        Me.ChkLimitStock.Name = "ChkLimitStock"
        Me.ChkLimitStock.Size = New System.Drawing.Size(208, 24)
        Me.ChkLimitStock.TabIndex = 0
        Me.ChkLimitStock.Text = "Ne calculer les stocks qu'à partir du "
        '
        'gbApprofact
        '
        Me.gbApprofact.Controls.Add(Me.CbNumAgrPrefixe)
        Me.gbApprofact.Controls.Add(Me.Label31)
        Me.gbApprofact.Controls.Add(Me.Label30)
        Me.gbApprofact.Controls.Add(Me.Label29)
        Me.gbApprofact.Controls.Add(Me.TxtSIRET)
        Me.gbApprofact.Controls.Add(Me.TxtCodeNAF)
        Me.gbApprofact.Controls.Add(Me.TxtNumAgrement)
        Me.gbApprofact.Controls.Add(Me.TxtAgenceEau)
        Me.gbApprofact.Controls.Add(Me.Label20)
        Me.gbApprofact.Location = New System.Drawing.Point(8, 229)
        Me.gbApprofact.Name = "gbApprofact"
        Me.gbApprofact.Size = New System.Drawing.Size(408, 104)
        Me.gbApprofact.TabIndex = 1
        Me.gbApprofact.TabStop = False
        Me.gbApprofact.Text = "ApproFact"
        '
        'CbNumAgrPrefixe
        '
        Me.CbNumAgrPrefixe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbNumAgrPrefixe.Location = New System.Drawing.Point(136, 48)
        Me.CbNumAgrPrefixe.Name = "CbNumAgrPrefixe"
        Me.CbNumAgrPrefixe.Size = New System.Drawing.Size(48, 21)
        Me.CbNumAgrPrefixe.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 75)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(104, 23)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "SIRET"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(234, 51)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 23)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "Code NAF"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 51)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(104, 23)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "N° agrément"
        '
        'TxtSIRET
        '
        Me.TxtSIRET.Location = New System.Drawing.Point(136, 72)
        Me.TxtSIRET.MaxLength = 14
        Me.TxtSIRET.Name = "TxtSIRET"
        Me.TxtSIRET.Size = New System.Drawing.Size(96, 20)
        Me.TxtSIRET.TabIndex = 5
        Me.TxtSIRET.Text = "99999999999999"
        '
        'TxtCodeNAF
        '
        Me.TxtCodeNAF.Location = New System.Drawing.Point(304, 48)
        Me.TxtCodeNAF.MaxLength = 5
        Me.TxtCodeNAF.Name = "TxtCodeNAF"
        Me.TxtCodeNAF.Size = New System.Drawing.Size(96, 20)
        Me.TxtCodeNAF.TabIndex = 4
        Me.TxtCodeNAF.Text = "9999Z"
        '
        'TxtNumAgrement
        '
        Me.TxtNumAgrement.Location = New System.Drawing.Point(192, 48)
        Me.TxtNumAgrement.MaxLength = 5
        Me.TxtNumAgrement.Name = "TxtNumAgrement"
        Me.TxtNumAgrement.Size = New System.Drawing.Size(40, 20)
        Me.TxtNumAgrement.TabIndex = 3
        Me.TxtNumAgrement.Text = "99999"
        '
        'TxtAgenceEau
        '
        Me.TxtAgenceEau.Location = New System.Drawing.Point(136, 24)
        Me.TxtAgenceEau.MaxLength = 100
        Me.TxtAgenceEau.Name = "TxtAgenceEau"
        Me.TxtAgenceEau.Size = New System.Drawing.Size(264, 20)
        Me.TxtAgenceEau.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 23)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Agence de l'eau"
        '
        'GbMarge
        '
        Me.GbMarge.Controls.Add(Me.TxObjectifMarge)
        Me.GbMarge.Controls.Add(Me.Label32)
        Me.GbMarge.Location = New System.Drawing.Point(8, 339)
        Me.GbMarge.Name = "GbMarge"
        Me.GbMarge.Size = New System.Drawing.Size(408, 56)
        Me.GbMarge.TabIndex = 2
        Me.GbMarge.TabStop = False
        Me.GbMarge.Text = "Marge"
        '
        'TxObjectifMarge
        '
        Me.TxObjectifMarge.Location = New System.Drawing.Point(103, 22)
        Me.TxObjectifMarge.Name = "TxObjectifMarge"
        Me.TxObjectifMarge.Size = New System.Drawing.Size(56, 20)
        Me.TxObjectifMarge.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(8, 25)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 16)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Objectif de Marge"
        '
        'GroupBoxEscompte
        '
        Me.GroupBoxEscompte.Controls.Add(Me.TextBoxDelaiValiditeEscompte)
        Me.GroupBoxEscompte.Controls.Add(Me.Label35)
        Me.GroupBoxEscompte.Controls.Add(Me.TextBoxTauxEscompte)
        Me.GroupBoxEscompte.Controls.Add(Me.Label34)
        Me.GroupBoxEscompte.Location = New System.Drawing.Point(8, 401)
        Me.GroupBoxEscompte.Name = "GroupBoxEscompte"
        Me.GroupBoxEscompte.Size = New System.Drawing.Size(408, 54)
        Me.GroupBoxEscompte.TabIndex = 5
        Me.GroupBoxEscompte.TabStop = False
        Me.GroupBoxEscompte.Text = "Escompte"
        '
        'TextBoxDelaiValiditeEscompte
        '
        Me.TextBoxDelaiValiditeEscompte.Location = New System.Drawing.Point(314, 19)
        Me.TextBoxDelaiValiditeEscompte.Name = "TextBoxDelaiValiditeEscompte"
        Me.TextBoxDelaiValiditeEscompte.Size = New System.Drawing.Size(56, 20)
        Me.TextBoxDelaiValiditeEscompte.TabIndex = 5
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(190, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(118, 16)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Délai de validité (jours)"
        '
        'TextBoxTauxEscompte
        '
        Me.TextBoxTauxEscompte.Location = New System.Drawing.Point(118, 19)
        Me.TextBoxTauxEscompte.Name = "TextBoxTauxEscompte"
        Me.TextBoxTauxEscompte.Size = New System.Drawing.Size(56, 20)
        Me.TextBoxTauxEscompte.TabIndex = 3
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(7, 22)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(105, 16)
        Me.Label34.TabIndex = 2
        Me.Label34.Text = "Taux d'escompte (%)"
        '
        'GroupBoxSolstyce
        '
        Me.GroupBoxSolstyce.Controls.Add(Me.CheckBoxCreationLotsSolstyce)
        Me.GroupBoxSolstyce.Location = New System.Drawing.Point(8, 461)
        Me.GroupBoxSolstyce.Name = "GroupBoxSolstyce"
        Me.GroupBoxSolstyce.Size = New System.Drawing.Size(408, 49)
        Me.GroupBoxSolstyce.TabIndex = 6
        Me.GroupBoxSolstyce.TabStop = False
        Me.GroupBoxSolstyce.Text = "Solstyce"
        '
        'CheckBoxCreationLotsSolstyce
        '
        Me.CheckBoxCreationLotsSolstyce.AutoSize = True
        Me.CheckBoxCreationLotsSolstyce.Checked = True
        Me.CheckBoxCreationLotsSolstyce.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCreationLotsSolstyce.Location = New System.Drawing.Point(9, 19)
        Me.CheckBoxCreationLotsSolstyce.Name = "CheckBoxCreationLotsSolstyce"
        Me.CheckBoxCreationLotsSolstyce.Size = New System.Drawing.Size(173, 17)
        Me.CheckBoxCreationLotsSolstyce.TabIndex = 0
        Me.CheckBoxCreationLotsSolstyce.Text = "Création des lots dans Solstyce"
        Me.CheckBoxCreationLotsSolstyce.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.FdMEcheanceCheckBox)
        Me.GroupBox4.Controls.Add(Me.NbJoursEcheanceTextBox)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 516)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Echéance"
        '
        'FdMEcheanceCheckBox
        '
        Me.FdMEcheanceCheckBox.AutoSize = True
        Me.FdMEcheanceCheckBox.Location = New System.Drawing.Point(192, 24)
        Me.FdMEcheanceCheckBox.Name = "FdMEcheanceCheckBox"
        Me.FdMEcheanceCheckBox.Size = New System.Drawing.Size(79, 17)
        Me.FdMEcheanceCheckBox.TabIndex = 2
        Me.FdMEcheanceCheckBox.Text = "Fin de mois"
        Me.FdMEcheanceCheckBox.UseVisualStyleBackColor = True
        '
        'NbJoursEcheanceTextBox
        '
        Me.NbJoursEcheanceTextBox.Location = New System.Drawing.Point(114, 22)
        Me.NbJoursEcheanceTextBox.Name = "NbJoursEcheanceTextBox"
        Me.NbJoursEcheanceTextBox.Size = New System.Drawing.Size(56, 20)
        Me.NbJoursEcheanceTextBox.TabIndex = 1
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(8, 25)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(100, 16)
        Me.Label43.TabIndex = 0
        Me.Label43.Text = "Nombre de jours"
        '
        'ActiverMenuPubCheckBox
        '
        Me.ActiverMenuPubCheckBox.AutoSize = True
        Me.ActiverMenuPubCheckBox.Location = New System.Drawing.Point(8, 578)
        Me.ActiverMenuPubCheckBox.Name = "ActiverMenuPubCheckBox"
        Me.ActiverMenuPubCheckBox.Size = New System.Drawing.Size(141, 17)
        Me.ActiverMenuPubCheckBox.TabIndex = 8
        Me.ActiverMenuPubCheckBox.Text = "Activer le menu publicité"
        Me.ActiverMenuPubCheckBox.UseVisualStyleBackColor = True
        '
        'TbGestionSite
        '
        Me.TbGestionSite.Controls.Add(Me.TxPwdMajConf)
        Me.TbGestionSite.Controls.Add(Me.Label28)
        Me.TbGestionSite.Controls.Add(Me.TxPwdMaj)
        Me.TbGestionSite.Controls.Add(Me.Label27)
        Me.TbGestionSite.Controls.Add(Me.TxIdMaj)
        Me.TbGestionSite.Controls.Add(Me.Label26)
        Me.TbGestionSite.Controls.Add(Me.TxAdresseSite)
        Me.TbGestionSite.Controls.Add(Me.TxServiceGestionSite)
        Me.TbGestionSite.Controls.Add(Me.TxServerSMTP)
        Me.TbGestionSite.Controls.Add(Me.TxEMail)
        Me.TbGestionSite.Controls.Add(Me.Label14)
        Me.TbGestionSite.Controls.Add(Me.Label13)
        Me.TbGestionSite.Controls.Add(Me.Label12)
        Me.TbGestionSite.Controls.Add(Me.Label11)
        Me.TbGestionSite.Location = New System.Drawing.Point(4, 22)
        Me.TbGestionSite.Name = "TbGestionSite"
        Me.TbGestionSite.Size = New System.Drawing.Size(560, 605)
        Me.TbGestionSite.TabIndex = 1
        Me.TbGestionSite.Text = "Gestion Site"
        Me.TbGestionSite.UseVisualStyleBackColor = True
        '
        'TxPwdMajConf
        '
        Me.TxPwdMajConf.Location = New System.Drawing.Point(114, 172)
        Me.TxPwdMajConf.Name = "TxPwdMajConf"
        Me.TxPwdMajConf.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxPwdMajConf.Size = New System.Drawing.Size(144, 20)
        Me.TxPwdMajConf.TabIndex = 15
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(10, 172)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(100, 32)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "Confirmez le mot de passe"
        '
        'TxPwdMaj
        '
        Me.TxPwdMaj.Location = New System.Drawing.Point(114, 146)
        Me.TxPwdMaj.Name = "TxPwdMaj"
        Me.TxPwdMaj.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxPwdMaj.Size = New System.Drawing.Size(144, 20)
        Me.TxPwdMaj.TabIndex = 13
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(10, 146)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 24)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Mot de passe"
        '
        'TxIdMaj
        '
        Me.TxIdMaj.Location = New System.Drawing.Point(114, 120)
        Me.TxIdMaj.Name = "TxIdMaj"
        Me.TxIdMaj.Size = New System.Drawing.Size(144, 20)
        Me.TxIdMaj.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(10, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 24)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "Identifiant"
        '
        'TxAdresseSite
        '
        Me.TxAdresseSite.Location = New System.Drawing.Point(114, 94)
        Me.TxAdresseSite.Name = "TxAdresseSite"
        Me.TxAdresseSite.Size = New System.Drawing.Size(440, 20)
        Me.TxAdresseSite.TabIndex = 9
        '
        'TxServiceGestionSite
        '
        Me.TxServiceGestionSite.Location = New System.Drawing.Point(114, 68)
        Me.TxServiceGestionSite.Name = "TxServiceGestionSite"
        Me.TxServiceGestionSite.Size = New System.Drawing.Size(440, 20)
        Me.TxServiceGestionSite.TabIndex = 8
        '
        'TxServerSMTP
        '
        Me.TxServerSMTP.Location = New System.Drawing.Point(114, 42)
        Me.TxServerSMTP.Name = "TxServerSMTP"
        Me.TxServerSMTP.Size = New System.Drawing.Size(144, 20)
        Me.TxServerSMTP.TabIndex = 7
        '
        'TxEMail
        '
        Me.TxEMail.Location = New System.Drawing.Point(114, 16)
        Me.TxEMail.Name = "TxEMail"
        Me.TxEMail.Size = New System.Drawing.Size(144, 20)
        Me.TxEMail.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 24)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Adresse Site"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 24)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Service Gest. Site"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(10, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Serveur SMTP"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "E Mail"
        '
        'AutresParametresTabPage
        '
        Me.AutresParametresTabPage.Controls.Add(Me.ModeReglement_DetailGroupBox)
        Me.AutresParametresTabPage.Location = New System.Drawing.Point(4, 22)
        Me.AutresParametresTabPage.Name = "AutresParametresTabPage"
        Me.AutresParametresTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.AutresParametresTabPage.Size = New System.Drawing.Size(560, 605)
        Me.AutresParametresTabPage.TabIndex = 4
        Me.AutresParametresTabPage.Text = "Autres paramètres"
        Me.AutresParametresTabPage.UseVisualStyleBackColor = True
        '
        'ModeReglement_DetailGroupBox
        '
        Me.ModeReglement_DetailGroupBox.Controls.Add(Me.ModeReglement_DetailDataGridView)
        Me.ModeReglement_DetailGroupBox.Location = New System.Drawing.Point(8, 6)
        Me.ModeReglement_DetailGroupBox.Name = "ModeReglement_DetailGroupBox"
        Me.ModeReglement_DetailGroupBox.Size = New System.Drawing.Size(546, 236)
        Me.ModeReglement_DetailGroupBox.TabIndex = 1
        Me.ModeReglement_DetailGroupBox.TabStop = False
        Me.ModeReglement_DetailGroupBox.Text = "Informations modes de règlement"
        '
        'ModeReglement_DetailDataGridView
        '
        Me.ModeReglement_DetailDataGridView.AutoGenerateColumns = False
        Me.ModeReglement_DetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ModeReglement_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ModeReglement, Me.nBanque, Me.RemiseAutoDataGridViewCheckBoxColumn})
        Me.ModeReglement_DetailDataGridView.DataSource = Me.ModeReglement_DetailBindingSource
        Me.ModeReglement_DetailDataGridView.Location = New System.Drawing.Point(6, 19)
        Me.ModeReglement_DetailDataGridView.MultiSelect = False
        Me.ModeReglement_DetailDataGridView.Name = "ModeReglement_DetailDataGridView"
        Me.ModeReglement_DetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ModeReglement_DetailDataGridView.Size = New System.Drawing.Size(534, 197)
        Me.ModeReglement_DetailDataGridView.TabIndex = 0
        '
        'ListeModeReglementBindingSource
        '
        Me.ListeModeReglementBindingSource.DataMember = "ListeChoix"
        Me.ListeModeReglementBindingSource.DataSource = Me.DsAgrifact
        Me.ListeModeReglementBindingSource.Sort = "nOrdreValeur"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BanqueBindingSource
        '
        Me.BanqueBindingSource.DataMember = "Banque"
        Me.BanqueBindingSource.DataSource = Me.DsAgrifact
        Me.BanqueBindingSource.Sort = "Libelle ASC"
        '
        'ModeReglement_DetailBindingSource
        '
        Me.ModeReglement_DetailBindingSource.DataMember = "ModeReglement_Detail"
        Me.ModeReglement_DetailBindingSource.DataSource = Me.DsAgrifact
        Me.ModeReglement_DetailBindingSource.Sort = "ModeReglement ASC"
        '
        'ModeReglement_DetailTableAdapter
        '
        Me.ModeReglement_DetailTableAdapter.ClearBeforeFill = True
        '
        'BanqueTableAdapter
        '
        Me.BanqueTableAdapter.ClearBeforeFill = True
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "ModeReglement"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.ListeModeReglementBindingSource
        Me.DataGridViewComboBoxColumn1.DisplayMember = "Valeur"
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.HeaderText = "Mode de règlement"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.ValueMember = "Valeur"
        Me.DataGridViewComboBoxColumn1.Width = 150
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "nBanque"
        Me.DataGridViewComboBoxColumn2.DataSource = Me.BanqueBindingSource
        Me.DataGridViewComboBoxColumn2.DisplayMember = "Libelle"
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn2.HeaderText = "Banque"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.ValueMember = "nBanque"
        Me.DataGridViewComboBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_ModeReglement_Detail"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_ModeReglement_Detail"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'ModeReglement
        '
        Me.ModeReglement.DataPropertyName = "ModeReglement"
        Me.ModeReglement.DataSource = Me.ListeModeReglementBindingSource
        Me.ModeReglement.DisplayMember = "Valeur"
        Me.ModeReglement.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ModeReglement.HeaderText = "Mode de règlement"
        Me.ModeReglement.Name = "ModeReglement"
        Me.ModeReglement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ModeReglement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ModeReglement.ValueMember = "Valeur"
        Me.ModeReglement.Width = 150
        '
        'nBanque
        '
        Me.nBanque.DataPropertyName = "nBanque"
        Me.nBanque.DataSource = Me.BanqueBindingSource
        Me.nBanque.DisplayMember = "Libelle"
        Me.nBanque.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.nBanque.HeaderText = "Banque"
        Me.nBanque.Name = "nBanque"
        Me.nBanque.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nBanque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nBanque.ValueMember = "nBanque"
        Me.nBanque.Width = 250
        '
        'RemiseAutoDataGridViewCheckBoxColumn
        '
        Me.RemiseAutoDataGridViewCheckBoxColumn.DataPropertyName = "RemiseAuto"
        Me.RemiseAutoDataGridViewCheckBoxColumn.HeaderText = "Remise auto"
        Me.RemiseAutoDataGridViewCheckBoxColumn.Name = "RemiseAutoDataGridViewCheckBoxColumn"
        Me.RemiseAutoDataGridViewCheckBoxColumn.Width = 60
        '
        'FrInfosGenerales
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(570, 671)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BtOk)
        Me.Controls.Add(Me.BtAnnuler)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrInfosGenerales"
        Me.Text = "Infos Générales"
        Me.TabControl1.ResumeLayout(False)
        Me.TbInfosGenerales.ResumeLayout(False)
        Me.TbInfosGenerales.PerformLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbParamImpression.ResumeLayout(False)
        Me.TbParamImpression.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TbAvance.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gbNFacture.ResumeLayout(False)
        Me.gbNFacture.PerformLayout()
        Me.GbReglement.ResumeLayout(False)
        Me.GbReglement.PerformLayout()
        Me.gbStocks.ResumeLayout(False)
        Me.gbApprofact.ResumeLayout(False)
        Me.gbApprofact.PerformLayout()
        Me.GbMarge.ResumeLayout(False)
        Me.GbMarge.PerformLayout()
        Me.GroupBoxEscompte.ResumeLayout(False)
        Me.GroupBoxEscompte.PerformLayout()
        Me.GroupBoxSolstyce.ResumeLayout(False)
        Me.GroupBoxSolstyce.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TbGestionSite.ResumeLayout(False)
        Me.TbGestionSite.PerformLayout()
        Me.AutresParametresTabPage.ResumeLayout(False)
        Me.ModeReglement_DetailGroupBox.ResumeLayout(False)
        CType(Me.ModeReglement_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeModeReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModeReglement_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Page"
    Private Sub FrParametres_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        ChargerDonnees()
        'ONGLET AVANCÉ
        'Gestion des numérotations
        Me.lbNFacture.Tag = Me.lbNFacture.Text
        With cbTypePieceNum.Items
            .Clear()
            .Add(New ListboxItem("Facture client", "VFacture"))
            .Add(New ListboxItem("Devis", "VDevis"))
            .Add(New ListboxItem("Bon de commande", "VBonCommande"))
            .Add(New ListboxItem("Bon de livraison", "VBonLivraison"))
            If FrApplication.Modules.ModuleAchat Then
                .Add(New ListboxItem("Facture fournisseur", "AFacture"))
                .Add(New ListboxItem("Bon de réception", "ABonReception"))
            End If
        End With
        cbTypePieceNum.SelectedIndex = 0

        'Gestion réglements
        With CbBanque
            .DataSource = ds.Tables("Banque")
            .DisplayMember = "Libelle"
            .ValueMember = "nBanque"
        End With
        'ConfigCurrencyControl(Me.TxEcartReglement, 2)        

        'Approfact
        gbApprofact.Visible = FrApplication.Modules.ModuleApproFact
        InitControlesApprofact()

        'Marge
        GbMarge.Visible = FrApplication.Modules.ModuleGestionMarge
        'ConfigPercentControl(Me.TxObjectifMarge, 0)

        'Stocks
        gbStocks.Visible = FrApplication.Modules.ModuleStock
        If FrApplication.Modules.ModuleStock Then
            Me.dtpDtInitStock.MaxDate = Today
            Dim dt As Date = CDate(ParametresBase.GetValeur(ds, "DtInitStock", Nothing, "01/01/2000"))
            Me.ChkLimitStock.Checked = (dt <> #1/1/2000#)
            Me.dtpDtInitStock.Enabled = Me.ChkLimitStock.Checked
            Me.dtpDtInitStock.Value = dt
        End If


        'ONGLET OPTIONS D'IMPRESSION
        With cbTypePiece.Items
            .Clear()
            .Add(New ListboxItem("par défaut", Nothing))
            .Add(New ListboxItem("des Factures client", "VFacture"))
            .Add(New ListboxItem("des Devis", "VDevis"))
            .Add(New ListboxItem("des Bons de commande", "VBonCommande"))
            .Add(New ListboxItem("des Bons de livraison", "VBonLivraison"))
            If FrApplication.Modules.ModuleAchat Then
                .Add(New ListboxItem("des Factures fournisseur", "AFacture"))
                .Add(New ListboxItem("des Bons de réception", "ABonReception"))
            End If
        End With
        cbTypePiece.SelectedIndex = 0

        With CbFormatEnveloppe.Items
            .Clear()
            .Add(New ListboxItem("DL (plié en 3)", New Point(115, 50)))
            .Add(New ListboxItem("C5 (plié en 2)", New Point(115, 60)))
            .Add(New ListboxItem("Personnalisé...", Nothing))
        End With


        'Chargement parametres base
        If ds.Tables.Contains("Parametres") Then
            Me.TxNom.Text = ParametresBase.GetValeur(ds, "EnTete", Nothing, "")
            Me.TxCoordonnees.Text = ParametresBase.GetValeur(ds, "EnTeteDetail", Nothing, "")
            Me.TxPiedPage.Text = ParametresBase.GetValeur(ds, "PiedPageDetail", Nothing, "")
            'RIB
            Me.CodePaysIBANTextBox.Text = ParametresBase.GetValeur(ds, "CodePaysIBAN", Nothing, "")
            Me.TxCodeEtablissement.Text = ParametresBase.GetValeur(ds, "CodeEtablissement", Nothing, "")
            Me.TxCodeGuichet.Text = ParametresBase.GetValeur(ds, "CodeGuichet", Nothing, "")
            Me.TxNCompte.Text = ParametresBase.GetValeur(ds, "NCompte", Nothing, "")
            Me.TxCleRIB.Text = ParametresBase.GetValeur(ds, "CleRIB", Nothing, "")
            Me.TxDomiciliation.Text = ParametresBase.GetValeur(ds, "Domiciliation", Nothing, "")
            Me.SWIFT_BICTextBox.Text = ParametresBase.GetValeur(ds, "SWIFT_BIC", Nothing, "")

            'Chargement logo
            Me.Logo.Image = ParametresBase.GetLogo(ds.Tables("Parametres"))
            Me.BtSupprimerLogo.Enabled = Not Me.Logo.Image Is Nothing
            Me.BtSaveLogo.Enabled = Not Me.Logo.Image Is Nothing

            'OPTIONS IMPRESSION
            Dim p As New Point
            p.X = Integer.Parse(ParametresBase.GetValeur(ds, "AdresseLeft", Nothing, "115"))
            p.Y = Integer.Parse(ParametresBase.GetValeur(ds, "AdresseTop", Nothing, "50"))
            For Each l As ListboxItem In CbFormatEnveloppe.Items
                If Not l.Value Is Nothing Then
                    If p.Equals(CType(l.Value, Point)) Then
                        CbFormatEnveloppe.SelectedItem = l
                        Exit For
                    End If
                Else
                    CbFormatEnveloppe.SelectedItem = l
                    nudLeft.Value = p.X
                    nudTop.Value = p.Y
                End If
            Next

            'AVANCÉ
            InitValeursApprofact()

            'SITE
            Me.TxEMail.Text = ParametresBase.GetValeur(ds, "EMail", Nothing, "")
        End If

        'Chargement parametres appli
        With FrApplication.Parametres
            Me.TxNomDossier.Text = .NomDossier
            'IMPRESSION
            Me.ChkMarquerFactures.Checked = CBool(ParametresApplication.ValeurParametre("MarquerFacturesImprimees", True))
            Me.TxRepEtatsSpecifiques.Text = .RepEtatsSpecifiques
            Me.ChkEtatsSpec.Checked = (.RepEtatsSpecifiques.Length > 0)
            'AVANCE
            If FrApplication.Modules.ModuleGestionMarge Then
                TxObjectifMarge.Text = CStr(.ObjectifMarge)
            End If
            'SITE
            Me.TxServiceGestionSite.Text = .ServiceGestionSite
            Me.TxIdMaj.Text = ParametresApplication.ValeurParametre("IdMaj", "admin").ToString
            Me.TxPwdMaj.Text = ParametresApplication.ValeurParametre("PwdMaj", "admin").ToString
            Me.TxPwdMajConf.Text = Me.TxPwdMaj.Text
            Me.TxServiceGestionSite.Text = .ServiceGestionSite
            Me.TxServerSMTP.Text = .ServerSmtp
            Me.TxAdresseSite.Text = .AdresseSite
        End With

        'Chargement valeur défaut
        With FrApplication.ValeurDefault
            Me.CbBanque.SelectedValue = .nBanqueEntreprise
            Me.TxEcartReglement.Text = .EcartReglement.ToString
        End With

        'Chargement infos Escompte
        Me.ChargerInfosEscompte()

        'Chargement infos Solstyce
        Me.ChargerInfosSolstyce()

        'Chargement infos Ordre de facturation
        Me.ChargerOrdreDeFacturation()

        'Chargement infos Utiliser les modèles d'impression en fonction des services
        Me.ChargerInfosUtiliserModelesImpServices()

        'Chargement infos complémentaires
        Me.ChargerInfosComplementaires()

        'Chargement infos Echéance
        Me.ChargerInfosEcheance()

        'Chargement Activer menu publicité
        Me.ChargerActiverMenuPub()

        Me.ChkEtatsSpec_CheckedChanged(Nothing, Nothing)
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        If Me.TxPwdMaj.Text <> Me.TxPwdMajConf.Text Then
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Exclamation)

            Exit Sub
        End If

        If FrApplication.Modules.ModuleGestionMarge Then
            Dim d As Decimal = PercentParse(TxObjectifMarge.Text.Trim).GetValueOrDefault

            ParametresApplication.EnregistrerParametre("ObjectifMarge", d)
            FrApplication.Parametres.ObjectifMarge = d
        End If

        'Enregistrement parametres Base
        Dim dtParams As DataTable = ds.Tables("Parametres")

        ParametresBase.SetValeur(dtParams, "EnTete", Nothing, Me.TxNom.Text)
        ParametresBase.SetValeur(dtParams, "EnTeteDetail", Nothing, Me.TxCoordonnees.Text)
        ParametresBase.SetValeur(dtParams, "PiedPageDetail", Nothing, Me.TxPiedPage.Text)
        If nomTable Is Nothing Or nomTable <> "" Then
            ParametresBase.SetValeur(ds, "InfoLegale", nomTable, Me.TxInfoLegale.Text)
            ParametresBase.SetValeur(ds, "InfoLegale2", nomTable, Me.TxInfoLegale2.Text)
            ParametresBase.SetValeur(ds, "ImprimerRIB", nomTable, Me.ChkImprimerRIB.Checked.ToString)
        End If
        ParametresBase.SetValeur(dtParams, "CodePaysIBAN", Nothing, Me.CodePaysIBANTextBox.Text)
        ParametresBase.SetValeur(dtParams, "CodeEtablissement", Nothing, Me.TxCodeEtablissement.Text)
        ParametresBase.SetValeur(dtParams, "CodeGuichet", Nothing, Me.TxCodeGuichet.Text)
        ParametresBase.SetValeur(dtParams, "NCompte", Nothing, Me.TxNCompte.Text)
        ParametresBase.SetValeur(dtParams, "CleRIB", Nothing, Me.TxCleRIB.Text)
        ParametresBase.SetValeur(dtParams, "Domiciliation", Nothing, Me.TxDomiciliation.Text)
        ParametresBase.SetValeur(dtParams, "SWIFT_BIC", Nothing, Me.SWIFT_BICTextBox.Text)
        ParametresBase.SetValeur(dtParams, "EMail", Nothing, Me.TxEMail.Text)
        ParametresBase.SetValeur(dtParams, "AdresseLeft", Nothing, nudLeft.Value.ToString)
        ParametresBase.SetValeur(dtParams, "AdresseTop", Nothing, nudTop.Value.ToString)
        Me.SetValeursApprofact(dtParams)
        Me.SetValeursStock(dtParams)
        Me.SetValeursEscompte(dtParams)
        Me.SetValeursSolstyce(dtParams)
        Me.SetValeursOrdreDeFacturation(dtParams)
        Me.SetValeursUtiliserModelesImpServices(dtParams)
        Me.SetValeursInfosComplementaires(dtParams)
        Me.SetValeursEcheance(dtParams)
        Me.SetValeursActiverMenuPub(dtParams)

        Using s As New SqlProxy
            s.UpdateTable(ds, "Parametres")
        End Using

        'Enregistrement parametres application
        With FrApplication.Parametres
            If Me.TxNomDossier.Text.Trim.Length > 0 Then .NomDossier = Me.TxNomDossier.Text

            'Options d'impression
            If ChkEtatsSpec.Checked Then
                .RepEtatsSpecifiques = Me.TxRepEtatsSpecifiques.Text
            Else
                .RepEtatsSpecifiques = ""
            End If

            ParametresApplication.EnregistrerParametre("MarquerFacturesImprimees", ChkMarquerFactures.Checked, False)

            'Site
            .ServerSmtp = Me.TxServerSMTP.Text
            .AdresseSite = Me.TxAdresseSite.Text
            .ServiceGestionSite = Me.TxServiceGestionSite.Text
            ParametresApplication.EnregistrerParametre("IdMaj", TxIdMaj.Text.Trim, False)
            ParametresApplication.EnregistrerParametre("PwdMaj", TxPwdMaj.Text.Trim, False)

            .Enregistrer(False)
        End With

        'Enregistrement valeur par défaut
        With FrApplication.ValeurDefault
            .EcartReglement = CurrencyParse(TxEcartReglement.Text.Trim).GetValueOrDefault(5)
            .nBanqueEntreprise = IIf(Me.CbBanque.Text = "", DBNull.Value, Me.CbBanque.SelectedValue)
            .Enregistrer(False)
        End With

        ParametresApplication.EnregistrerParametres()

        'Enregistrement des informations modes de règlement
        Me.EnregistrerModeReglement_Detail()

        Me.Close()
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub
#End Region

#Region "Gestion Logo"

    Private Sub AjouterLogo()
        If Not ds.Tables.Contains("Parametres") Then Exit Sub

        Dim chemin As String
        With New OpenFileDialog
            Try
                .Title = "Choisissez le fichier image contenant votre logo."
                .Filter = "Images (*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|Tous les fichiers (*.*)|*.*"
                If .ShowDialog() = DialogResult.Cancel Then Exit Sub
                chemin = .FileName
            Finally
                .Dispose()
            End Try
        End With

        Cursor.Current = Cursors.WaitCursor

        Me.Logo.Image = ParametresBase.SetLogo(ds.Tables("Parametres"), chemin)
        Me.BtSupprimerLogo.Enabled = Not Me.Logo.Image Is Nothing
        Me.BtSaveLogo.Enabled = Not Me.Logo.Image Is Nothing
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Logo.Click, BtAjouterLogo.Click
        AjouterLogo()
    End Sub

    Private Sub BtSupprimerLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSupprimerLogo.Click
        If MsgBox("Voulez-vous vraiment supprimer cette image ?", MsgBoxStyle.YesNo, "Suppression") = MsgBoxResult.Yes Then
            ParametresBase.DeleteLogo(ds.Tables("Parametres"))
            Logo.Image = Nothing
            Me.BtSupprimerLogo.Enabled = Not Me.Logo.Image Is Nothing
            Me.BtSaveLogo.Enabled = Not Me.Logo.Image Is Nothing
        End If
    End Sub

    Private Sub BtSaveLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSaveLogo.Click
        If Me.Logo.Image Is Nothing Then Exit Sub
        Dim chemin As String
        With New SaveFileDialog
            Try
                .Filter = "Image Bitmap(*.bmp)|*.bmp"
                If .ShowDialog() = DialogResult.Cancel Then Exit Sub
                chemin = .FileName
            Finally
                .Dispose()
            End Try
        End With
        Me.Logo.Image.Save(chemin, Imaging.ImageFormat.Bmp)
        MsgBox("Le logo a été enregistré sur l'ordinateur", MsgBoxStyle.Information)
    End Sub
#End Region

#Region "Gestion des n° de facture"
    Private Sub cbTypePieceNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTypePieceNum.SelectedIndexChanged
        Dim nomPiece As String = CType(cbTypePieceNum.SelectedItem, ListboxItem).Text
        Dim nomTable As String = CStr(CType(cbTypePieceNum.SelectedItem, ListboxItem).Value)
        Dim nextNFacture As Long = Pieces.GetNFacture(EnumParse(Of Pieces.TypePieces)(nomTable), True)
        Me.lbNFacture.Text = String.Format(CStr(lbNFacture.Tag), nomPiece, nextNFacture)
    End Sub

    Private Sub btInitNFacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInitNFacture.Click
        Dim nomTable As String = CStr(CType(cbTypePieceNum.SelectedItem, ListboxItem).Value)
        Dim vDefaut As Long = Pieces.GetNFactureDefaut(EnumParse(Of Pieces.TypePieces)(nomTable))
        Dim nFacture As Long
        While True
            Dim rep As String = InputBox("Entrez le numéro auquel la numérotation doit recommencer.", "Recommencer la numérotation", CStr(vDefaut))
            If rep = "" Then Exit Sub
            Try
                nFacture = Long.Parse(rep)
                Exit While
            Catch ex As Exception
            End Try
        End While
        Pieces.SetNFacture(nomTable, nFacture)
        cbTypePieceNum_SelectedIndexChanged(Nothing, Nothing)
    End Sub

#End Region

#Region "Approfact"
    Private Sub InitControlesApprofact()
        If Not FrApplication.Modules.ModuleApproFact Then Exit Sub
        With CbNumAgrPrefixe.Items
            .Clear()
            .Add("XX")
            .Add("AL")
            .Add("AQ")
            .Add("AU")
            .Add("BN")
            .Add("BO")
            .Add("BR")
            .Add("CE")
            .Add("CA")
            .Add("CO")
            .Add("FC")
            .Add("GU")
            .Add("GY")
            .Add("HN")
            .Add("IF")
            .Add("LR")
            .Add("LI")
            .Add("LO")
            .Add("MA")
            .Add("MP")
            .Add("NC")
            .Add("PA")
            .Add("PL")
            .Add("PI")
            .Add("PC")
            .Add("RE")
            .Add("RH")
        End With
    End Sub

    Private Sub InitValeursApprofact()
        If Not FrApplication.Modules.ModuleApproFact Then Exit Sub
        Me.TxtAgenceEau.Text = ParametresBase.GetValeur(ds, "AgenceEau", Nothing, "")
        Me.TxtCodeNAF.Text = ParametresBase.GetValeur(ds, "CodeNAF", Nothing, "")
        Me.TxtSIRET.Text = ParametresBase.GetValeur(ds, "Siret", Nothing, "")
        Dim numAgrement As String = ParametresBase.GetValeur(ds, "NumeroAgrement", Nothing, "")
        If numAgrement.Length = 0 Then numAgrement = "XX0000"
        Me.CbNumAgrPrefixe.SelectedItem = numAgrement.Substring(0, 2)
        Me.TxtNumAgrement.Text = numAgrement.Substring(2)
    End Sub

    Private Sub SetValeursApprofact(ByVal dtParams As DataTable)
        If Not FrApplication.Modules.ModuleApproFact Then Exit Sub
        ParametresBase.SetValeur(dtParams, "AgenceEau", Nothing, Me.TxtAgenceEau.Text)
        ParametresBase.SetValeur(dtParams, "CodeNAF", Nothing, Me.TxtCodeNAF.Text)
        ParametresBase.SetValeur(dtParams, "Siret", Nothing, Me.TxtSIRET.Text)
        ParametresBase.SetValeur(dtParams, "NumeroAgrement", Nothing, CStr(Me.CbNumAgrPrefixe.SelectedItem) & Me.TxtNumAgrement.Text)
    End Sub
#End Region

#Region "Stocks"
    Private Sub ChkLimitStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLimitStock.CheckedChanged
        Me.dtpDtInitStock.Enabled = Me.ChkLimitStock.Checked
    End Sub

    Private Sub SetValeursStock(ByVal dtParams As DataTable)
        If Not FrApplication.Modules.ModuleStock Then Exit Sub
        If Me.ChkLimitStock.Checked Then
            ParametresBase.SetValeur(dtParams, "DtInitStock", Nothing, dtpDtInitStock.Value.ToString("dd/MM/yyyy"))
        Else
            ParametresBase.DeleteValeur(dtParams, "DtInitStock", Nothing)
        End If
    End Sub
#End Region

#Region "Options d'impression"
    Private nomTable As String = ""

    Private Sub cbTypePiece_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTypePiece.SelectedIndexChanged
        If nomTable Is Nothing Or nomTable <> "" Then
            ParametresBase.SetValeur(ds, "InfoLegale", nomTable, Me.TxInfoLegale.Text)
            ParametresBase.SetValeur(ds, "InfoLegale2", nomTable, Me.TxInfoLegale2.Text)
            ParametresBase.SetValeur(ds, "ImprimerRIB", nomTable, Me.ChkImprimerRIB.Checked.ToString)
        End If
        nomTable = CStr(CType(cbTypePiece.SelectedItem, ListboxItem).Value)
        Me.TxInfoLegale.Text = ParametresBase.GetValeur(ds, "InfoLegale", nomTable, "")
        Me.TxInfoLegale2.Text = ParametresBase.GetValeur(ds, "InfoLegale2", nomTable, "")
        Me.ChkImprimerRIB.Checked = Boolean.Parse(ParametresBase.GetValeur(ds, "ImprimerRIB", nomTable, "True"))
        BtUseDefault.Enabled = Not nomTable Is Nothing
    End Sub

    Private Sub BtUseDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUseDefault.Click
        If nomTable <> "" Then
            ParametresBase.DeleteValeur(ds, "InfoLegale", nomTable)
            ParametresBase.DeleteValeur(ds, "InfoLegale2", nomTable)
        End If
        nomTable = ""
        cbTypePiece.SelectedIndex = 0
    End Sub

    Private Sub ChkEtatsSpec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEtatsSpec.CheckedChanged
        Me.TxRepEtatsSpecifiques.Enabled = ChkEtatsSpec.Checked
        Me.BtBrowseRepEtatsSpec.Enabled = ChkEtatsSpec.Checked
        Me.UtiliserModelesImpServicesCheckBox.Enabled = ChkEtatsSpec.Checked
        Me.Label37.Enabled = ChkEtatsSpec.Checked
        Me.Label38.Enabled = ChkEtatsSpec.Checked
        If Not ChkEtatsSpec.Checked Then
            Me.TxRepEtatsSpecifiques.Text = ""
            Me.UtiliserModelesImpServicesCheckBox.Checked = False
            Me.Label37.Enabled = False
            Me.Label38.Enabled = False
        End If
    End Sub

    Private Sub BtBrowseRepEtatsSpec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowseRepEtatsSpec.Click
        Dim dlg As New FolderBrowserDialog
        Dim rep As String = Me.TxRepEtatsSpecifiques.Text
        If Not IO.Path.IsPathRooted(rep) Then
            rep = IO.Path.Combine(Application.StartupPath, Me.TxRepEtatsSpecifiques.Text)
        End If
        dlg.SelectedPath = rep
        If dlg.ShowDialog = DialogResult.OK Then
            rep = dlg.SelectedPath
            If rep.StartsWith(Application.StartupPath) Then
                rep = rep.Replace(Application.StartupPath & "\", "")
            End If
            Me.TxRepEtatsSpecifiques.Text = rep
        End If
    End Sub

    Private Sub CbFormatEnveloppe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbFormatEnveloppe.SelectedIndexChanged
        If CbFormatEnveloppe.SelectedItem Is Nothing Then Exit Sub
        Dim l As ListboxItem = CType(CbFormatEnveloppe.SelectedItem, ListboxItem)
        If l.Value Is Nothing Then
            nudLeft.Enabled = True
            nudTop.Enabled = True
        Else
            With CType(l.Value, Point)
                nudLeft.Value = .X
                nudTop.Value = .Y
            End With
            nudLeft.Enabled = False
            nudTop.Enabled = False
        End If
    End Sub

    Private Sub ChargerOrdreDeFacturation()
        Me.TextBoxOrdreDeFacturation.Text = ParametresBase.GetValeur(ds, "OrdreDeFacturation", Nothing, "")
    End Sub

    Private Sub SetValeursOrdreDeFacturation(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "OrdreDeFacturation", Nothing, Me.TextBoxOrdreDeFacturation.Text)
    End Sub

    Private Sub ChargerInfosUtiliserModelesImpServices()
        Me.UtiliserModelesImpServicesCheckBox.Checked = CBool(ParametresBase.GetValeur(ds, "UtiliserModelesImpServices", Nothing, "False"))
    End Sub

    Private Sub SetValeursUtiliserModelesImpServices(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "UtiliserModelesImpServices", Nothing, Me.UtiliserModelesImpServicesCheckBox.Checked.ToString())
    End Sub

    Private Sub ChargerInfosComplementaires()
        Me.NomAbregeEntiteTextBox.Text = ParametresBase.GetValeur(ds, "NomAbregeEntite", Nothing, "")
        Me.ModeRgtParDefTextBox.Text = ParametresBase.GetValeur(ds, "ModeRgtParDef", Nothing, "")
        Me.EcheanceVisibleCheckBox.Checked = CBool(ParametresBase.GetValeur(ds, "EcheanceVisible", Nothing, "False"))
    End Sub

    Private Sub SetValeursInfosComplementaires(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "NomAbregeEntite", Nothing, Me.NomAbregeEntiteTextBox.Text)
        ParametresBase.SetValeur(dtParams, "ModeRgtParDef", Nothing, Me.ModeRgtParDefTextBox.Text)
        ParametresBase.SetValeur(dtParams, "EcheanceVisible", Nothing, Me.EcheanceVisibleCheckBox.Checked.ToString())
    End Sub
#End Region

#Region "Escompte"
    Private Sub ChargerInfosEscompte()
        Me.TextBoxTauxEscompte.Text = ParametresBase.GetValeur(ds, "TauxEscompte", Nothing, "")
        Me.TextBoxDelaiValiditeEscompte.Text = ParametresBase.GetValeur(ds, "DelaiValiditeEscompte", Nothing, "")
    End Sub

    Private Sub SetValeursEscompte(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "TauxEscompte", Nothing, Me.TextBoxTauxEscompte.Text)
        ParametresBase.SetValeur(dtParams, "DelaiValiditeEscompte", Nothing, Me.TextBoxDelaiValiditeEscompte.Text)
    End Sub
#End Region

#Region "Solstyce"
    Private Sub ChargerInfosSolstyce()
        Me.CheckBoxCreationLotsSolstyce.Checked = CBool(ParametresBase.GetValeur(ds, "CreerLotsDansSolstyce", Nothing, "True"))
    End Sub

    Private Sub SetValeursSolstyce(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "CreerLotsDansSolstyce", Nothing, Me.CheckBoxCreationLotsSolstyce.Checked.ToString())
    End Sub
#End Region

#Region "Echéance"
    Private Sub ChargerInfosEcheance()
        Me.NbJoursEcheanceTextBox.Text = ParametresBase.GetValeur(ds, "NbJoursEcheance", Nothing, "")
        Me.FdMEcheanceCheckBox.Checked = CBool(ParametresBase.GetValeur(ds, "FdMEcheance", Nothing, "False"))
    End Sub

    Private Sub SetValeursEcheance(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "NbJoursEcheance", Nothing, Me.NbJoursEcheanceTextBox.Text)
        ParametresBase.SetValeur(dtParams, "FdMEcheance", Nothing, Me.FdMEcheanceCheckBox.Checked.ToString())
    End Sub
#End Region

#Region "Menu pub"
    Private Sub ChargerActiverMenuPub()
        Me.ActiverMenuPubCheckBox.Checked = CBool(ParametresBase.GetValeur(ds, "ActiverMenuPub", Nothing, "False"))
    End Sub

    Private Sub SetValeursActiverMenuPub(ByVal dtParams As DataTable)
        ParametresBase.SetValeur(dtParams, "ActiverMenuPub", Nothing, Me.ActiverMenuPubCheckBox.Checked.ToString())
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Me.ListeModeReglementBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeModeReglement.ToString())
        Me.BanqueTableAdapter.Fill(Me.DsAgrifact.Banque)
        Me.ModeReglement_DetailTableAdapter.Fill(Me.DsAgrifact.ModeReglement_Detail)

        Me.ds = New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(Me.ds, "Banque", s)
            DefinitionDonnees.Instance.Fill(Me.ds, "Parametres", s)
        End Using
    End Sub

    Private Sub EnregistrerModeReglement_Detail()
        If Me.DsAgrifact.HasChanges Then
            Me.ModeReglement_DetailTableAdapter.Update(Me.DsAgrifact.ModeReglement_Detail)
        End If
    End Sub
#End Region

End Class
