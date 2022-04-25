<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim AdresseFactureLabel As System.Windows.Forms.Label
        Dim NClientLabel As System.Windows.Forms.Label
        Dim NFactureLabel As System.Windows.Forms.Label
        Dim DateFactureLabel As System.Windows.Forms.Label
        Dim ObservationLabel As System.Windows.Forms.Label
        Dim MontantHTLabel As System.Windows.Forms.Label
        Dim MontantTVALabel As System.Windows.Forms.Label
        Dim MontantTTCLabel As System.Windows.Forms.Label
        Dim NTarifLabel As System.Windows.Forms.Label
        Dim RemiseLabel As System.Windows.Forms.Label
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NouvelleFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnregistrerLaFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnnulerLaFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechercherUneFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechargerLaFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbRegler = New System.Windows.Forms.ToolStripButton
        Me.TbParametres = New System.Windows.Forms.ToolStripButton
        Me.TbSplitImprimer = New System.Windows.Forms.ToolStripSplitButton
        Me.ImprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AperçuAvantImpressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimerFacturetteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BtCaisse = New System.Windows.Forms.ToolStripButton
        Me.BtRecaps = New System.Windows.Forms.ToolStripButton
        Me.VFacture_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VFactureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.TVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VFactureTA = New PointDeVente.DsAgrifactTableAdapters.VFactureTA
        Me.AdresseFactureTextBox = New System.Windows.Forms.TextBox
        Me.NClientComboBox = New System.Windows.Forms.ComboBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NFactureTextBox = New System.Windows.Forms.TextBox
        Me.DateFactureDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ObservationTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RemiseTextBox = New System.Windows.Forms.TextBox
        Me.NTarifComboBox = New System.Windows.Forms.ComboBox
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtNewClient = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtFindClient = New Ascend.Windows.Forms.GradientNavigationButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RecapTVADataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RecapTVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.MontantTTCLabel1 = New System.Windows.Forms.Label
        Me.MontantTVALabel1 = New System.Windows.Forms.Label
        Me.MontantHTLabel1 = New System.Windows.Forms.Label
        Me.VFacture_DetailTA = New PointDeVente.DsAgrifactTableAdapters.VFacture_DetailTA
        Me.VFacture_DetailDataGridView = New PointDeVente.DataGridViewEnter
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DupliquerLaLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerLaLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CodeProduitCol = New PointDeVente.DatagridViewComboboxColumnCustom
        Me.CodeProduitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SearchProduitDataGridViewButtonColumn = New PointDeVente.DataGridViewDisableButtonColumn
        Me.LibelleCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.U1Col = New PointDeVente.DatagridViewNumericTextBoxColumn
        Me.LibU1Col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.U2Col = New PointDeVente.DatagridViewNumericTextBoxColumn
        Me.LibU2Col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixUTTCCol = New PointDeVente.DatagridViewNumericTextBoxColumn
        Me.RemiseCol = New PointDeVente.DatagridViewNumericTextBoxColumn
        Me.TVACol = New PointDeVente.DatagridViewComboboxColumnCustom
        Me.MontantTTCCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        AdresseFactureLabel = New System.Windows.Forms.Label
        NClientLabel = New System.Windows.Forms.Label
        NFactureLabel = New System.Windows.Forms.Label
        DateFactureLabel = New System.Windows.Forms.Label
        ObservationLabel = New System.Windows.Forms.Label
        MontantHTLabel = New System.Windows.Forms.Label
        MontantTVALabel = New System.Windows.Forms.Label
        MontantTTCLabel = New System.Windows.Forms.Label
        NTarifLabel = New System.Windows.Forms.Label
        RemiseLabel = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.VFacture_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VFactureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.RecapTVADataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecapTVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.VFacture_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdresseFactureLabel
        '
        AdresseFactureLabel.AutoSize = True
        AdresseFactureLabel.Location = New System.Drawing.Point(6, 72)
        AdresseFactureLabel.Name = "AdresseFactureLabel"
        AdresseFactureLabel.Size = New System.Drawing.Size(48, 13)
        AdresseFactureLabel.TabIndex = 8
        AdresseFactureLabel.Text = "Adresse:"
        '
        'NClientLabel
        '
        NClientLabel.AutoSize = True
        NClientLabel.Location = New System.Drawing.Point(6, 48)
        NClientLabel.Name = "NClientLabel"
        NClientLabel.Size = New System.Drawing.Size(36, 13)
        NClientLabel.TabIndex = 4
        NClientLabel.Text = "Client:"
        '
        'NFactureLabel
        '
        NFactureLabel.AutoSize = True
        NFactureLabel.Location = New System.Drawing.Point(6, 22)
        NFactureLabel.Name = "NFactureLabel"
        NFactureLabel.Size = New System.Drawing.Size(46, 13)
        NFactureLabel.TabIndex = 0
        NFactureLabel.Text = "Facture:"
        '
        'DateFactureLabel
        '
        DateFactureLabel.AutoSize = True
        DateFactureLabel.Location = New System.Drawing.Point(166, 23)
        DateFactureLabel.Name = "DateFactureLabel"
        DateFactureLabel.Size = New System.Drawing.Size(25, 13)
        DateFactureLabel.TabIndex = 2
        DateFactureLabel.Text = "du :"
        '
        'ObservationLabel
        '
        ObservationLabel.AutoSize = True
        ObservationLabel.Location = New System.Drawing.Point(303, 22)
        ObservationLabel.Name = "ObservationLabel"
        ObservationLabel.Size = New System.Drawing.Size(72, 13)
        ObservationLabel.TabIndex = 10
        ObservationLabel.Text = "Observations:"
        '
        'MontantHTLabel
        '
        MontantHTLabel.AutoSize = True
        MontantHTLabel.Location = New System.Drawing.Point(6, 17)
        MontantHTLabel.Name = "MontantHTLabel"
        MontantHTLabel.Size = New System.Drawing.Size(67, 13)
        MontantHTLabel.TabIndex = 0
        MontantHTLabel.Text = "Montant HT:"
        '
        'MontantTVALabel
        '
        MontantTVALabel.AutoSize = True
        MontantTVALabel.Location = New System.Drawing.Point(6, 37)
        MontantTVALabel.Name = "MontantTVALabel"
        MontantTVALabel.Size = New System.Drawing.Size(73, 13)
        MontantTVALabel.TabIndex = 2
        MontantTVALabel.Text = "Montant TVA:"
        '
        'MontantTTCLabel
        '
        MontantTTCLabel.AutoSize = True
        MontantTTCLabel.Location = New System.Drawing.Point(6, 57)
        MontantTTCLabel.Name = "MontantTTCLabel"
        MontantTTCLabel.Size = New System.Drawing.Size(73, 13)
        MontantTTCLabel.TabIndex = 4
        MontantTTCLabel.Text = "Montant TTC:"
        '
        'NTarifLabel
        '
        NTarifLabel.AutoSize = True
        NTarifLabel.Location = New System.Drawing.Point(6, 151)
        NTarifLabel.Name = "NTarifLabel"
        NTarifLabel.Size = New System.Drawing.Size(31, 13)
        NTarifLabel.TabIndex = 12
        NTarifLabel.Text = "Tarif:"
        '
        'RemiseLabel
        '
        RemiseLabel.AutoSize = True
        RemiseLabel.Location = New System.Drawing.Point(306, 151)
        RemiseLabel.Name = "RemiseLabel"
        RemiseLabel.Size = New System.Drawing.Size(45, 13)
        RemiseLabel.TabIndex = 14
        RemiseLabel.Text = "Remise:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.TbRegler, Me.TbParametres, Me.TbSplitImprimer, Me.BtCaisse, Me.BtRecaps})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(797, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouvelleFactureToolStripMenuItem, Me.EnregistrerLaFactureToolStripMenuItem, Me.AnnulerLaFactureToolStripMenuItem, Me.RechercherUneFactureToolStripMenuItem, Me.RechargerLaFactureToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.PointDeVente.My.Resources.Resources.hi0046_32
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(96, 36)
        Me.ToolStripDropDownButton1.Text = "Factures"
        '
        'NouvelleFactureToolStripMenuItem
        '
        Me.NouvelleFactureToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources._new
        Me.NouvelleFactureToolStripMenuItem.Name = "NouvelleFactureToolStripMenuItem"
        Me.NouvelleFactureToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NouvelleFactureToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.NouvelleFactureToolStripMenuItem.Text = "Nouvelle facture"
        '
        'EnregistrerLaFactureToolStripMenuItem
        '
        Me.EnregistrerLaFactureToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.save
        Me.EnregistrerLaFactureToolStripMenuItem.Name = "EnregistrerLaFactureToolStripMenuItem"
        Me.EnregistrerLaFactureToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.EnregistrerLaFactureToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.EnregistrerLaFactureToolStripMenuItem.Text = "Enregistrer la facture"
        '
        'AnnulerLaFactureToolStripMenuItem
        '
        Me.AnnulerLaFactureToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.suppr
        Me.AnnulerLaFactureToolStripMenuItem.Name = "AnnulerLaFactureToolStripMenuItem"
        Me.AnnulerLaFactureToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AnnulerLaFactureToolStripMenuItem.Text = "Annuler la facture"
        '
        'RechercherUneFactureToolStripMenuItem
        '
        Me.RechercherUneFactureToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.search
        Me.RechercherUneFactureToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.RechercherUneFactureToolStripMenuItem.Name = "RechercherUneFactureToolStripMenuItem"
        Me.RechercherUneFactureToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.RechercherUneFactureToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.RechercherUneFactureToolStripMenuItem.Text = "Rechercher une facture..."
        '
        'RechargerLaFactureToolStripMenuItem
        '
        Me.RechargerLaFactureToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.RefreshDocViewHS
        Me.RechargerLaFactureToolStripMenuItem.Name = "RechargerLaFactureToolStripMenuItem"
        Me.RechargerLaFactureToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.RechargerLaFactureToolStripMenuItem.Text = "Recharger la facture en cours"
        '
        'TbRegler
        '
        Me.TbRegler.Image = Global.PointDeVente.My.Resources.Resources.pay
        Me.TbRegler.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbRegler.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbRegler.Name = "TbRegler"
        Me.TbRegler.Size = New System.Drawing.Size(76, 36)
        Me.TbRegler.Text = "Régler"
        '
        'TbParametres
        '
        Me.TbParametres.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbParametres.Image = Global.PointDeVente.My.Resources.Resources.aide24
        Me.TbParametres.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbParametres.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbParametres.Name = "TbParametres"
        Me.TbParametres.Size = New System.Drawing.Size(94, 36)
        Me.TbParametres.Text = "Paramètres"
        '
        'TbSplitImprimer
        '
        Me.TbSplitImprimer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerToolStripMenuItem, Me.AperçuAvantImpressionToolStripMenuItem, Me.ImprimerFacturetteToolStripMenuItem})
        Me.TbSplitImprimer.Image = Global.PointDeVente.My.Resources.Resources.impr32
        Me.TbSplitImprimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSplitImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSplitImprimer.Name = "TbSplitImprimer"
        Me.TbSplitImprimer.Size = New System.Drawing.Size(104, 36)
        Me.TbSplitImprimer.Tag = "Imprimer"
        Me.TbSplitImprimer.Text = "Imprimer"
        '
        'ImprimerToolStripMenuItem
        '
        Me.ImprimerToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.impr
        Me.ImprimerToolStripMenuItem.Name = "ImprimerToolStripMenuItem"
        Me.ImprimerToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ImprimerToolStripMenuItem.Text = "Imprimer la facture"
        '
        'AperçuAvantImpressionToolStripMenuItem
        '
        Me.AperçuAvantImpressionToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.preview
        Me.AperçuAvantImpressionToolStripMenuItem.Name = "AperçuAvantImpressionToolStripMenuItem"
        Me.AperçuAvantImpressionToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.AperçuAvantImpressionToolStripMenuItem.Text = "Aperçu avant impression..."
        '
        'ImprimerFacturetteToolStripMenuItem
        '
        Me.ImprimerFacturetteToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.ticket
        Me.ImprimerFacturetteToolStripMenuItem.Name = "ImprimerFacturetteToolStripMenuItem"
        Me.ImprimerFacturetteToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ImprimerFacturetteToolStripMenuItem.Text = "Facturette"
        '
        'BtCaisse
        '
        Me.BtCaisse.Image = Global.PointDeVente.My.Resources.Resources.bi0035_32
        Me.BtCaisse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtCaisse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtCaisse.Name = "BtCaisse"
        Me.BtCaisse.Size = New System.Drawing.Size(76, 36)
        Me.BtCaisse.Text = "Caisse"
        '
        'BtRecaps
        '
        Me.BtRecaps.Image = Global.PointDeVente.My.Resources.Resources.stats
        Me.BtRecaps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtRecaps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtRecaps.Name = "BtRecaps"
        Me.BtRecaps.Size = New System.Drawing.Size(69, 36)
        Me.BtRecaps.Text = "Récaps"
        '
        'VFacture_DetailBindingSource
        '
        Me.VFacture_DetailBindingSource.DataMember = "FK_VFacture_Detail_VFacture"
        Me.VFacture_DetailBindingSource.DataSource = Me.VFactureBindingSource
        '
        'VFactureBindingSource
        '
        Me.VFactureBindingSource.DataMember = "VFacture"
        Me.VFactureBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TVABindingSource
        '
        Me.TVABindingSource.DataMember = "TVA"
        Me.TVABindingSource.DataSource = Me.DsAgrifact
        Me.TVABindingSource.Sort = "TVADisplay"
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.DsAgrifact
        Me.ProduitBindingSource.Sort = "Libelle"
        '
        'VFactureTA
        '
        Me.VFactureTA.ClearBeforeFill = True
        '
        'AdresseFactureTextBox
        '
        Me.AdresseFactureTextBox.AcceptsReturn = True
        Me.AdresseFactureTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "AdresseFacture", True))
        Me.AdresseFactureTextBox.Location = New System.Drawing.Point(60, 72)
        Me.AdresseFactureTextBox.Multiline = True
        Me.AdresseFactureTextBox.Name = "AdresseFactureTextBox"
        Me.AdresseFactureTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AdresseFactureTextBox.Size = New System.Drawing.Size(240, 70)
        Me.AdresseFactureTextBox.TabIndex = 9
        '
        'NClientComboBox
        '
        Me.NClientComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.NClientComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.NClientComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VFactureBindingSource, "nClient", True))
        Me.NClientComboBox.DataSource = Me.EntrepriseBindingSource
        Me.NClientComboBox.DisplayMember = "Nom"
        Me.NClientComboBox.FormattingEnabled = True
        Me.NClientComboBox.Location = New System.Drawing.Point(60, 45)
        Me.NClientComboBox.Name = "NClientComboBox"
        Me.NClientComboBox.Size = New System.Drawing.Size(196, 21)
        Me.NClientComboBox.TabIndex = 5
        Me.NClientComboBox.ValueMember = "nEntreprise"
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.DsAgrifact
        Me.EntrepriseBindingSource.Sort = "Nom"
        '
        'NFactureTextBox
        '
        Me.NFactureTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "nFacture", True))
        Me.NFactureTextBox.Location = New System.Drawing.Point(60, 19)
        Me.NFactureTextBox.Name = "NFactureTextBox"
        Me.NFactureTextBox.ReadOnly = True
        Me.NFactureTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NFactureTextBox.TabIndex = 1
        '
        'DateFactureDateTimePicker
        '
        Me.DateFactureDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.VFactureBindingSource, "DateFacture", True))
        Me.DateFactureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFactureDateTimePicker.Location = New System.Drawing.Point(197, 19)
        Me.DateFactureDateTimePicker.Name = "DateFactureDateTimePicker"
        Me.DateFactureDateTimePicker.Size = New System.Drawing.Size(88, 20)
        Me.DateFactureDateTimePicker.TabIndex = 3
        '
        'ObservationTextBox
        '
        Me.ObservationTextBox.AcceptsReturn = True
        Me.ObservationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "Observation", True))
        Me.ObservationTextBox.Location = New System.Drawing.Point(306, 45)
        Me.ObservationTextBox.Multiline = True
        Me.ObservationTextBox.Name = "ObservationTextBox"
        Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ObservationTextBox.Size = New System.Drawing.Size(239, 97)
        Me.ObservationTextBox.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(RemiseLabel)
        Me.GroupBox1.Controls.Add(Me.RemiseTextBox)
        Me.GroupBox1.Controls.Add(NTarifLabel)
        Me.GroupBox1.Controls.Add(Me.NTarifComboBox)
        Me.GroupBox1.Controls.Add(Me.BtNewClient)
        Me.GroupBox1.Controls.Add(Me.BtFindClient)
        Me.GroupBox1.Controls.Add(Me.NFactureTextBox)
        Me.GroupBox1.Controls.Add(Me.AdresseFactureTextBox)
        Me.GroupBox1.Controls.Add(ObservationLabel)
        Me.GroupBox1.Controls.Add(AdresseFactureLabel)
        Me.GroupBox1.Controls.Add(Me.ObservationTextBox)
        Me.GroupBox1.Controls.Add(Me.NClientComboBox)
        Me.GroupBox1.Controls.Add(NClientLabel)
        Me.GroupBox1.Controls.Add(NFactureLabel)
        Me.GroupBox1.Controls.Add(DateFactureLabel)
        Me.GroupBox1.Controls.Add(Me.DateFactureDateTimePicker)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 348)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Facturation"
        '
        'RemiseTextBox
        '
        Me.RemiseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "Remise", True))
        Me.RemiseTextBox.Location = New System.Drawing.Point(360, 148)
        Me.RemiseTextBox.Name = "RemiseTextBox"
        Me.RemiseTextBox.Size = New System.Drawing.Size(51, 20)
        Me.RemiseTextBox.TabIndex = 15
        Me.RemiseTextBox.Text = "100,00%"
        Me.RemiseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NTarifComboBox
        '
        Me.NTarifComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VFactureBindingSource, "nTarif", True))
        Me.NTarifComboBox.DataSource = Me.TarifBindingSource
        Me.NTarifComboBox.DisplayMember = "Libelle"
        Me.NTarifComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NTarifComboBox.FormattingEnabled = True
        Me.NTarifComboBox.Location = New System.Drawing.Point(60, 148)
        Me.NTarifComboBox.Name = "NTarifComboBox"
        Me.NTarifComboBox.Size = New System.Drawing.Size(240, 21)
        Me.NTarifComboBox.TabIndex = 13
        Me.NTarifComboBox.ValueMember = "nTarif"
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "Tarif"
        Me.TarifBindingSource.DataSource = Me.DsAgrifact
        Me.TarifBindingSource.Sort = "Libelle"
        '
        'BtNewClient
        '
        Me.BtNewClient.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtNewClient.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.BtNewClient.ActiveOnClick = False
        Me.BtNewClient.AntiAlias = True
        Me.BtNewClient.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtNewClient.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtNewClient.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtNewClient.HighColorLuminance = 1.3!
        Me.BtNewClient.Image = Global.PointDeVente.My.Resources.Resources._new
        Me.BtNewClient.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtNewClient.Location = New System.Drawing.Point(278, 45)
        Me.BtNewClient.LowColorLuminance = 1.3!
        Me.BtNewClient.Name = "BtNewClient"
        Me.BtNewClient.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtNewClient.Size = New System.Drawing.Size(22, 21)
        Me.BtNewClient.StayActiveAfterClick = False
        Me.BtNewClient.TabIndex = 7
        Me.BtNewClient.TabStop = True
        Me.ToolTip1.SetToolTip(Me.BtNewClient, "Saisir un nouveau client")
        '
        'BtFindClient
        '
        Me.BtFindClient.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtFindClient.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.BtFindClient.ActiveOnClick = False
        Me.BtFindClient.AntiAlias = True
        Me.BtFindClient.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtFindClient.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtFindClient.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtFindClient.HighColorLuminance = 1.3!
        Me.BtFindClient.Image = Global.PointDeVente.My.Resources.Resources.search
        Me.BtFindClient.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtFindClient.Location = New System.Drawing.Point(256, 45)
        Me.BtFindClient.LowColorLuminance = 1.3!
        Me.BtFindClient.Name = "BtFindClient"
        Me.BtFindClient.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtFindClient.Size = New System.Drawing.Size(22, 21)
        Me.BtFindClient.StayActiveAfterClick = False
        Me.BtFindClient.TabIndex = 6
        Me.BtFindClient.TabStop = True
        Me.ToolTip1.SetToolTip(Me.BtFindClient, "Rechercher un client")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RecapTVADataGridView)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 101)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Détail TVA"
        '
        'RecapTVADataGridView
        '
        Me.RecapTVADataGridView.AllowUserToAddRows = False
        Me.RecapTVADataGridView.AllowUserToDeleteRows = False
        Me.RecapTVADataGridView.AutoGenerateColumns = False
        Me.RecapTVADataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RecapTVADataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RecapTVADataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.RecapTVADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.RecapTVADataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.RecapTVADataGridView.DataSource = Me.RecapTVABindingSource
        Me.RecapTVADataGridView.EnableHeadersVisualStyles = False
        Me.RecapTVADataGridView.Location = New System.Drawing.Point(6, 19)
        Me.RecapTVADataGridView.Name = "RecapTVADataGridView"
        Me.RecapTVADataGridView.ReadOnly = True
        Me.RecapTVADataGridView.RowHeadersVisible = False
        Me.RecapTVADataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect
        Me.RecapTVADataGridView.Size = New System.Drawing.Size(189, 74)
        Me.RecapTVADataGridView.TabIndex = 0
        Me.RecapTVADataGridView.TabStop = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Taux"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "p"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Taux"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 40
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "BaseHT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "C2"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Base HT"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MontantTVA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "C2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "TVA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 36
        '
        'RecapTVABindingSource
        '
        Me.RecapTVABindingSource.DataSource = GetType(PointDeVente.RecapTVA)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(MontantTTCLabel)
        Me.GroupBox3.Controls.Add(Me.MontantTTCLabel1)
        Me.GroupBox3.Controls.Add(MontantTVALabel)
        Me.GroupBox3.Controls.Add(Me.MontantTVALabel1)
        Me.GroupBox3.Controls.Add(MontantHTLabel)
        Me.GroupBox3.Controls.Add(Me.MontantHTLabel1)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 80)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total"
        '
        'MontantTTCLabel1
        '
        Me.MontantTTCLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "MontantTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantTTCLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontantTTCLabel1.Location = New System.Drawing.Point(85, 53)
        Me.MontantTTCLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.MontantTTCLabel1.Name = "MontantTTCLabel1"
        Me.MontantTTCLabel1.Size = New System.Drawing.Size(82, 20)
        Me.MontantTTCLabel1.TabIndex = 5
        Me.MontantTTCLabel1.Text = "300 000,25 €"
        Me.MontantTTCLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MontantTVALabel1
        '
        Me.MontantTVALabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "MontantTVA", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantTVALabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontantTVALabel1.Location = New System.Drawing.Point(85, 33)
        Me.MontantTVALabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.MontantTVALabel1.Name = "MontantTVALabel1"
        Me.MontantTVALabel1.Size = New System.Drawing.Size(82, 20)
        Me.MontantTVALabel1.TabIndex = 3
        Me.MontantTVALabel1.Text = "10,25 €"
        Me.MontantTVALabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MontantHTLabel1
        '
        Me.MontantHTLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VFactureBindingSource, "MontantHT", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantHTLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontantHTLabel1.Location = New System.Drawing.Point(85, 13)
        Me.MontantHTLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.MontantHTLabel1.Name = "MontantHTLabel1"
        Me.MontantHTLabel1.Size = New System.Drawing.Size(82, 20)
        Me.MontantHTLabel1.TabIndex = 1
        Me.MontantHTLabel1.Text = "100,00 €"
        Me.MontantHTLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VFacture_DetailTA
        '
        Me.VFacture_DetailTA.ClearBeforeFill = True
        '
        'VFacture_DetailDataGridView
        '
        Me.VFacture_DetailDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VFacture_DetailDataGridView.AutoGenerateColumns = False
        Me.VFacture_DetailDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.VFacture_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeProduitCol, Me.CodeProduitDataGridViewTextBoxColumn, Me.SearchProduitDataGridViewButtonColumn, Me.LibelleCol, Me.U1Col, Me.LibU1Col, Me.U2Col, Me.LibU2Col, Me.PrixUTTCCol, Me.RemiseCol, Me.TVACol, Me.MontantTTCCol})
        Me.VFacture_DetailDataGridView.ContextMenuStrip = Me.ctxMenu
        Me.VFacture_DetailDataGridView.DataSource = Me.VFacture_DetailBindingSource
        Me.VFacture_DetailDataGridView.Location = New System.Drawing.Point(0, 238)
        Me.VFacture_DetailDataGridView.Name = "VFacture_DetailDataGridView"
        Me.VFacture_DetailDataGridView.RowHeadersWidth = 25
        Me.VFacture_DetailDataGridView.Size = New System.Drawing.Size(797, 286)
        Me.VFacture_DetailDataGridView.TabIndex = 4
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DupliquerLaLigneToolStripMenuItem, Me.SupprimerLaLigneToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(171, 48)
        '
        'DupliquerLaLigneToolStripMenuItem
        '
        Me.DupliquerLaLigneToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.CopyHS
        Me.DupliquerLaLigneToolStripMenuItem.Name = "DupliquerLaLigneToolStripMenuItem"
        Me.DupliquerLaLigneToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.DupliquerLaLigneToolStripMenuItem.Text = "Dupliquer la ligne"
        '
        'SupprimerLaLigneToolStripMenuItem
        '
        Me.SupprimerLaLigneToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.suppr
        Me.SupprimerLaLigneToolStripMenuItem.Name = "SupprimerLaLigneToolStripMenuItem"
        Me.SupprimerLaLigneToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.SupprimerLaLigneToolStripMenuItem.Text = "Supprimer la ligne"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel1.Controls.Add(Me.GroupBox2)
        Me.GradientPanel1.Controls.Add(Me.GroupBox3)
        Me.GradientPanel1.Location = New System.Drawing.Point(575, 42)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(222, 199)
        Me.GradientPanel1.TabIndex = 5
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel2.Controls.Add(Me.GroupBox1)
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 42)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(577, 351)
        Me.GradientPanel2.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 524)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(797, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CodeProduitCol
        '
        Me.CodeProduitCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitCol.DataPropertyName = "CodeProduit"
        Me.CodeProduitCol.DataSource = Me.ProduitBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.CodeProduitCol.DefaultCellStyle = DataGridViewCellStyle5
        Me.CodeProduitCol.DisplayMember = "Libelle"
        Me.CodeProduitCol.DisplayStyleForCurrentCellOnly = True
        Me.CodeProduitCol.DropDownWidth = 250
        Me.CodeProduitCol.HeaderText = "Code"
        Me.CodeProduitCol.Name = "CodeProduitCol"
        Me.CodeProduitCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodeProduitCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CodeProduitCol.ValueMember = "CodeProduit"
        Me.CodeProduitCol.Visible = False
        Me.CodeProduitCol.Width = 57
        '
        'CodeProduitDataGridViewTextBoxColumn
        '
        Me.CodeProduitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitDataGridViewTextBoxColumn.DataPropertyName = "CodeProduit"
        Me.CodeProduitDataGridViewTextBoxColumn.HeaderText = "CodeProduit"
        Me.CodeProduitDataGridViewTextBoxColumn.Name = "CodeProduitDataGridViewTextBoxColumn"
        Me.CodeProduitDataGridViewTextBoxColumn.Width = 90
        '
        'SearchProduitDataGridViewButtonColumn
        '
        Me.SearchProduitDataGridViewButtonColumn.HeaderText = ""
        Me.SearchProduitDataGridViewButtonColumn.Image = Global.PointDeVente.My.Resources.Resources.search_glyph
        Me.SearchProduitDataGridViewButtonColumn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SearchProduitDataGridViewButtonColumn.Name = "SearchProduitDataGridViewButtonColumn"
        Me.SearchProduitDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SearchProduitDataGridViewButtonColumn.ToolTipText = "Chercher un produit"
        Me.SearchProduitDataGridViewButtonColumn.Width = 22
        '
        'LibelleCol
        '
        Me.LibelleCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleCol.DataPropertyName = "Libelle"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LibelleCol.DefaultCellStyle = DataGridViewCellStyle6
        Me.LibelleCol.HeaderText = "Libelle"
        Me.LibelleCol.Name = "LibelleCol"
        '
        'U1Col
        '
        Me.U1Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.U1Col.DataPropertyName = "Unite1"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N2"
        Me.U1Col.DefaultCellStyle = DataGridViewCellStyle7
        Me.U1Col.HeaderText = "Unite 1"
        Me.U1Col.Name = "U1Col"
        Me.U1Col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.U1Col.Width = 66
        '
        'LibU1Col
        '
        Me.LibU1Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibU1Col.DataPropertyName = "LibUnite1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LibU1Col.DefaultCellStyle = DataGridViewCellStyle8
        Me.LibU1Col.HeaderText = ""
        Me.LibU1Col.Name = "LibU1Col"
        Me.LibU1Col.ReadOnly = True
        Me.LibU1Col.Width = 19
        '
        'U2Col
        '
        Me.U2Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.U2Col.DataPropertyName = "Unite2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.Format = "N2"
        Me.U2Col.DefaultCellStyle = DataGridViewCellStyle9
        Me.U2Col.HeaderText = "Unite 2"
        Me.U2Col.Name = "U2Col"
        Me.U2Col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.U2Col.Width = 66
        '
        'LibU2Col
        '
        Me.LibU2Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibU2Col.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LibU2Col.DefaultCellStyle = DataGridViewCellStyle10
        Me.LibU2Col.HeaderText = ""
        Me.LibU2Col.Name = "LibU2Col"
        Me.LibU2Col.ReadOnly = True
        Me.LibU2Col.Width = 19
        '
        'PrixUTTCCol
        '
        Me.PrixUTTCCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixUTTCCol.DataPropertyName = "PrixUTTC"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle11.Format = "C2"
        Me.PrixUTTCCol.DefaultCellStyle = DataGridViewCellStyle11
        Me.PrixUTTCCol.HeaderText = "Prix U"
        Me.PrixUTTCCol.Name = "PrixUTTCCol"
        Me.PrixUTTCCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrixUTTCCol.Width = 60
        '
        'RemiseCol
        '
        Me.RemiseCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RemiseCol.DataPropertyName = "Remise"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle12.Format = "#0.00'%'"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.RemiseCol.DefaultCellStyle = DataGridViewCellStyle12
        Me.RemiseCol.HeaderText = "Remise"
        Me.RemiseCol.Name = "RemiseCol"
        Me.RemiseCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RemiseCol.Width = 67
        '
        'TVACol
        '
        Me.TVACol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TVACol.DataPropertyName = "TTVA"
        Me.TVACol.DataSource = Me.TVABindingSource
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.TVACol.DefaultCellStyle = DataGridViewCellStyle13
        Me.TVACol.DisplayMember = "TVADisplay"
        Me.TVACol.DisplayStyleForCurrentCellOnly = True
        Me.TVACol.DropDownWidth = 300
        Me.TVACol.HeaderText = "TVA"
        Me.TVACol.Name = "TVACol"
        Me.TVACol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TVACol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TVACol.ValueMember = "TTVA"
        Me.TVACol.Width = 53
        '
        'MontantTTCCol
        '
        Me.MontantTTCCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantTTCCol.DataPropertyName = "MontantLigneTTC"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.Format = "C2"
        Me.MontantTTCCol.DefaultCellStyle = DataGridViewCellStyle14
        Me.MontantTTCCol.HeaderText = "Montant"
        Me.MontantTTCCol.Name = "MontantTTCCol"
        Me.MontantTTCCol.ReadOnly = True
        Me.MontantTTCCol.Width = 71
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 546)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.VFacture_DetailDataGridView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(662, 430)
        Me.Name = "Main"
        Me.Text = "Agrifact - Point de vente"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.VFacture_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VFactureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.RecapTVADataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecapTVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.VFacture_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbParametres As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents RechercherUneFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbRegler As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents VFactureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VFactureTA As PointDeVente.DsAgrifactTableAdapters.VFactureTA
    Friend WithEvents AdresseFactureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NClientComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NFactureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateFactureDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MontantTTCLabel1 As System.Windows.Forms.Label
    Friend WithEvents MontantTVALabel1 As System.Windows.Forms.Label
    Friend WithEvents MontantHTLabel1 As System.Windows.Forms.Label
    Friend WithEvents VFacture_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VFacture_DetailTA As PointDeVente.DsAgrifactTableAdapters.VFacture_DetailTA
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VFacture_DetailDataGridView As DataGridViewEnter
    Friend WithEvents NouvelleFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerLaFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnnulerLaFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecapTVADataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RecapTVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DupliquerLaLigneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerLaLigneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtFindClient As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtNewClient As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NTarifComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RemiseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtCaisse As System.Windows.Forms.ToolStripButton
    Friend WithEvents RechargerLaFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtRecaps As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSplitImprimer As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AperçuAvantImpressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimerFacturetteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeProduitCol As PointDeVente.DatagridViewComboboxColumnCustom
    Friend WithEvents CodeProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SearchProduitDataGridViewButtonColumn As PointDeVente.DataGridViewDisableButtonColumn
    Friend WithEvents LibelleCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U1Col As PointDeVente.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibU1Col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U2Col As PointDeVente.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibU2Col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixUTTCCol As PointDeVente.DatagridViewNumericTextBoxColumn
    Friend WithEvents RemiseCol As PointDeVente.DatagridViewNumericTextBoxColumn
    Friend WithEvents TVACol As PointDeVente.DatagridViewComboboxColumnCustom
    Friend WithEvents MontantTTCCol As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
