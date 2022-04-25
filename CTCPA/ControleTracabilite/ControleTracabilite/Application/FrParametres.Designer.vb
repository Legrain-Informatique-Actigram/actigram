<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrParametres
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
        Dim RepPDFLabel As System.Windows.Forms.Label
        Dim PeriodeHistoLabel As System.Windows.Forms.Label
        Dim ConnectionStringBuilderWrapper1 As ControleTracabilite.ConnectionStringBuilderWrapper = New ControleTracabilite.ConnectionStringBuilderWrapper
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.lbExempleLotFab = New System.Windows.Forms.Label
        Me.lbExempleLotBR = New System.Windows.Forms.Label
        Me.lnkAideFormatLotFab = New System.Windows.Forms.LinkLabel
        Me.lnkAideFormatLotBR = New System.Windows.Forms.LinkLabel
        Me.TxFormatLotFab = New System.Windows.Forms.TextBox
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxFormatLotBR = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PeriodeHistoNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.lnkAddPdf = New System.Windows.Forms.LinkLabel
        Me.BtBrowsePdf = New System.Windows.Forms.Button
        Me.RepPDFTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig = New ControleTracabilite.SqlConnectionConfig
        Me.ctxAideFormat = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NAutomatiquenumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParDéfautnumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Sur2Chiffresnum00ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Sur3Chiffresnum000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DateDuJourdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParDéfautdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormatCourtdatejjMMaaaaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormatAlphadateaaMMjjToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuantièmequantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParDéfautquantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Sur3Chifffresquant000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DateEtHeuredateHHmmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNom = New System.Windows.Forms.ToolStripMenuItem
        Me.EntiernomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PremiersCarnomS4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DescriptiondescToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EntierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PremiersCardescS8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        RepPDFLabel = New System.Windows.Forms.Label
        PeriodeHistoLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodeHistoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ctxAideFormat.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepPDFLabel
        '
        RepPDFLabel.AutoSize = True
        RepPDFLabel.Location = New System.Drawing.Point(8, 288)
        RepPDFLabel.Name = "RepPDFLabel"
        RepPDFLabel.Size = New System.Drawing.Size(154, 13)
        RepPDFLabel.TabIndex = 1
        RepPDFLabel.Text = "Emplacement des fichiers PDF:"
        '
        'PeriodeHistoLabel
        '
        PeriodeHistoLabel.AutoSize = True
        PeriodeHistoLabel.Location = New System.Drawing.Point(8, 261)
        PeriodeHistoLabel.Name = "PeriodeHistoLabel"
        PeriodeHistoLabel.Size = New System.Drawing.Size(106, 13)
        PeriodeHistoLabel.TabIndex = 6
        PeriodeHistoLabel.Text = "Affichage par défaut:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.lbExempleLotFab)
        Me.GradientPanel1.Controls.Add(Me.lbExempleLotBR)
        Me.GradientPanel1.Controls.Add(Me.lnkAideFormatLotFab)
        Me.GradientPanel1.Controls.Add(Me.lnkAideFormatLotBR)
        Me.GradientPanel1.Controls.Add(Me.TxFormatLotFab)
        Me.GradientPanel1.Controls.Add(Me.TxFormatLotBR)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(PeriodeHistoLabel)
        Me.GradientPanel1.Controls.Add(Me.PeriodeHistoNumericUpDown)
        Me.GradientPanel1.Controls.Add(Me.lnkAddPdf)
        Me.GradientPanel1.Controls.Add(Me.BtBrowsePdf)
        Me.GradientPanel1.Controls.Add(RepPDFLabel)
        Me.GradientPanel1.Controls.Add(Me.RepPDFTextBox)
        Me.GradientPanel1.Controls.Add(Me.GroupBox1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(409, 336)
        Me.GradientPanel1.TabIndex = 1
        '
        'lbExempleLotFab
        '
        Me.lbExempleLotFab.AutoSize = True
        Me.lbExempleLotFab.Location = New System.Drawing.Point(144, 243)
        Me.lbExempleLotFab.Name = "lbExempleLotFab"
        Me.lbExempleLotFab.Size = New System.Drawing.Size(88, 13)
        Me.lbExempleLotFab.TabIndex = 16
        Me.lbExempleLotFab.Text = "lbExempleLotFab"
        '
        'lbExempleLotBR
        '
        Me.lbExempleLotBR.AutoSize = True
        Me.lbExempleLotBR.Location = New System.Drawing.Point(144, 204)
        Me.lbExempleLotBR.Name = "lbExempleLotBR"
        Me.lbExempleLotBR.Size = New System.Drawing.Size(85, 13)
        Me.lbExempleLotBR.TabIndex = 15
        Me.lbExempleLotBR.Text = "lbExempleLotBR"
        '
        'lnkAideFormatLotFab
        '
        Me.lnkAideFormatLotFab.AutoSize = True
        Me.lnkAideFormatLotFab.Image = Global.ControleTracabilite.My.Resources.Resources.aide
        Me.lnkAideFormatLotFab.Location = New System.Drawing.Point(378, 223)
        Me.lnkAideFormatLotFab.Name = "lnkAideFormatLotFab"
        Me.lnkAideFormatLotFab.Padding = New System.Windows.Forms.Padding(16, 2, 0, 2)
        Me.lnkAideFormatLotFab.Size = New System.Drawing.Size(16, 17)
        Me.lnkAideFormatLotFab.TabIndex = 14
        '
        'lnkAideFormatLotBR
        '
        Me.lnkAideFormatLotBR.AutoSize = True
        Me.lnkAideFormatLotBR.Image = Global.ControleTracabilite.My.Resources.Resources.aide
        Me.lnkAideFormatLotBR.Location = New System.Drawing.Point(378, 183)
        Me.lnkAideFormatLotBR.Name = "lnkAideFormatLotBR"
        Me.lnkAideFormatLotBR.Padding = New System.Windows.Forms.Padding(16, 2, 0, 2)
        Me.lnkAideFormatLotBR.Size = New System.Drawing.Size(16, 17)
        Me.lnkAideFormatLotBR.TabIndex = 13
        '
        'TxFormatLotFab
        '
        Me.TxFormatLotFab.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "FormatLotFab", True))
        Me.TxFormatLotFab.Location = New System.Drawing.Point(147, 220)
        Me.TxFormatLotFab.Name = "TxFormatLotFab"
        Me.TxFormatLotFab.Size = New System.Drawing.Size(224, 20)
        Me.TxFormatLotFab.TabIndex = 12
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'TxFormatLotBR
        '
        Me.TxFormatLotBR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "FormatLotBR", True))
        Me.TxFormatLotBR.Location = New System.Drawing.Point(147, 181)
        Me.TxFormatLotBR.Name = "TxFormatLotBR"
        Me.TxFormatLotBR.Size = New System.Drawing.Size(225, 20)
        Me.TxFormatLotBR.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "N° de lot auto pour les fabr.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "N° de lot auto pour les BR:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(223, 261)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "jours"
        '
        'PeriodeHistoNumericUpDown
        '
        Me.PeriodeHistoNumericUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.MySettingsBindingSource, "PeriodeHisto", True))
        Me.PeriodeHistoNumericUpDown.Location = New System.Drawing.Point(168, 259)
        Me.PeriodeHistoNumericUpDown.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.PeriodeHistoNumericUpDown.Name = "PeriodeHistoNumericUpDown"
        Me.PeriodeHistoNumericUpDown.Size = New System.Drawing.Size(49, 20)
        Me.PeriodeHistoNumericUpDown.TabIndex = 7
        Me.PeriodeHistoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lnkAddPdf
        '
        Me.lnkAddPdf.AutoSize = True
        Me.lnkAddPdf.Location = New System.Drawing.Point(165, 308)
        Me.lnkAddPdf.Name = "lnkAddPdf"
        Me.lnkAddPdf.Size = New System.Drawing.Size(119, 13)
        Me.lnkAddPdf.TabIndex = 5
        Me.lnkAddPdf.TabStop = True
        Me.lnkAddPdf.Text = "Ajouter un fichier PDF..."
        '
        'BtBrowsePdf
        '
        Me.BtBrowsePdf.Image = Global.ControleTracabilite.My.Resources.Resources.open
        Me.BtBrowsePdf.Location = New System.Drawing.Point(366, 283)
        Me.BtBrowsePdf.Name = "BtBrowsePdf"
        Me.BtBrowsePdf.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowsePdf.TabIndex = 4
        Me.BtBrowsePdf.UseVisualStyleBackColor = True
        '
        'RepPDFTextBox
        '
        Me.RepPDFTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "RepPDF", True))
        Me.RepPDFTextBox.Location = New System.Drawing.Point(168, 285)
        Me.RepPDFTextBox.Name = "RepPDFTextBox"
        Me.RepPDFTextBox.Size = New System.Drawing.Size(192, 20)
        Me.RepPDFTextBox.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 165)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres de connexion"
        '
        'SqlConnectionConfig
        '
        ConnectionStringBuilderWrapper1.ConnectionString = "Integrated Security=True"
        ConnectionStringBuilderWrapper1.Database = ""
        ConnectionStringBuilderWrapper1.Login = ""
        ConnectionStringBuilderWrapper1.Password = ""
        ConnectionStringBuilderWrapper1.Server = ""
        Me.SqlConnectionConfig.ConnectionStringBuilder = ConnectionStringBuilderWrapper1
        Me.SqlConnectionConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 16)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(383, 146)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'ctxAideFormat
        '
        Me.ctxAideFormat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NAutomatiquenumToolStripMenuItem, Me.DateDuJourdateToolStripMenuItem, Me.mnuNom, Me.DescriptiondescToolStripMenuItem})
        Me.ctxAideFormat.Name = "ctxAideFormat"
        Me.ctxAideFormat.Size = New System.Drawing.Size(223, 92)
        '
        'NAutomatiquenumToolStripMenuItem
        '
        Me.NAutomatiquenumToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParDéfautnumToolStripMenuItem, Me.Sur2Chiffresnum00ToolStripMenuItem, Me.Sur3Chiffresnum000ToolStripMenuItem})
        Me.NAutomatiquenumToolStripMenuItem.Name = "NAutomatiquenumToolStripMenuItem"
        Me.NAutomatiquenumToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.NAutomatiquenumToolStripMenuItem.Text = "N° automatique : {num}"
        '
        'ParDéfautnumToolStripMenuItem
        '
        Me.ParDéfautnumToolStripMenuItem.Name = "ParDéfautnumToolStripMenuItem"
        Me.ParDéfautnumToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ParDéfautnumToolStripMenuItem.Tag = "{num}"
        Me.ParDéfautnumToolStripMenuItem.Text = "par défaut : {num}"
        '
        'Sur2Chiffresnum00ToolStripMenuItem
        '
        Me.Sur2Chiffresnum00ToolStripMenuItem.Name = "Sur2Chiffresnum00ToolStripMenuItem"
        Me.Sur2Chiffresnum00ToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.Sur2Chiffresnum00ToolStripMenuItem.Tag = "{num:00}"
        Me.Sur2Chiffresnum00ToolStripMenuItem.Text = "sur 2 chiffres : {num:00}"
        '
        'Sur3Chiffresnum000ToolStripMenuItem
        '
        Me.Sur3Chiffresnum000ToolStripMenuItem.Name = "Sur3Chiffresnum000ToolStripMenuItem"
        Me.Sur3Chiffresnum000ToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.Sur3Chiffresnum000ToolStripMenuItem.Tag = "{num:000}"
        Me.Sur3Chiffresnum000ToolStripMenuItem.Text = "sur 3 chiffres : {num:000}"
        '
        'DateDuJourdateToolStripMenuItem
        '
        Me.DateDuJourdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParDéfautdateToolStripMenuItem, Me.FormatCourtdatejjMMaaaaToolStripMenuItem, Me.FormatAlphadateaaMMjjToolStripMenuItem, Me.QuantièmequantToolStripMenuItem, Me.DateEtHeuredateHHmmToolStripMenuItem})
        Me.DateDuJourdateToolStripMenuItem.Name = "DateDuJourdateToolStripMenuItem"
        Me.DateDuJourdateToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.DateDuJourdateToolStripMenuItem.Text = "Date du jour : {date}"
        '
        'ParDéfautdateToolStripMenuItem
        '
        Me.ParDéfautdateToolStripMenuItem.Name = "ParDéfautdateToolStripMenuItem"
        Me.ParDéfautdateToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ParDéfautdateToolStripMenuItem.Tag = "{date}"
        Me.ParDéfautdateToolStripMenuItem.Text = "par défaut : {date}"
        '
        'FormatCourtdatejjMMaaaaToolStripMenuItem
        '
        Me.FormatCourtdatejjMMaaaaToolStripMenuItem.Name = "FormatCourtdatejjMMaaaaToolStripMenuItem"
        Me.FormatCourtdatejjMMaaaaToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.FormatCourtdatejjMMaaaaToolStripMenuItem.Tag = "{date:jj/MM/aaaa}"
        Me.FormatCourtdatejjMMaaaaToolStripMenuItem.Text = "format court : {date:jj/MM/aaaa}"
        '
        'FormatAlphadateaaMMjjToolStripMenuItem
        '
        Me.FormatAlphadateaaMMjjToolStripMenuItem.Name = "FormatAlphadateaaMMjjToolStripMenuItem"
        Me.FormatAlphadateaaMMjjToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.FormatAlphadateaaMMjjToolStripMenuItem.Tag = "{date:aaMMjj}"
        Me.FormatAlphadateaaMMjjToolStripMenuItem.Text = "format alpha : {date:aaMMjj}"
        '
        'QuantièmequantToolStripMenuItem
        '
        Me.QuantièmequantToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParDéfautquantToolStripMenuItem, Me.Sur3Chifffresquant000ToolStripMenuItem})
        Me.QuantièmequantToolStripMenuItem.Name = "QuantièmequantToolStripMenuItem"
        Me.QuantièmequantToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.QuantièmequantToolStripMenuItem.Text = "quantième :{quant}"
        '
        'ParDéfautquantToolStripMenuItem
        '
        Me.ParDéfautquantToolStripMenuItem.Name = "ParDéfautquantToolStripMenuItem"
        Me.ParDéfautquantToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ParDéfautquantToolStripMenuItem.Tag = "{quant}"
        Me.ParDéfautquantToolStripMenuItem.Text = "par défaut : {quant}"
        '
        'Sur3Chifffresquant000ToolStripMenuItem
        '
        Me.Sur3Chifffresquant000ToolStripMenuItem.Name = "Sur3Chifffresquant000ToolStripMenuItem"
        Me.Sur3Chifffresquant000ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.Sur3Chifffresquant000ToolStripMenuItem.Tag = "{quant:000}"
        Me.Sur3Chifffresquant000ToolStripMenuItem.Text = "sur 3 chifffres : {quant:000}"
        '
        'DateEtHeuredateHHmmToolStripMenuItem
        '
        Me.DateEtHeuredateHHmmToolStripMenuItem.Name = "DateEtHeuredateHHmmToolStripMenuItem"
        Me.DateEtHeuredateHHmmToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.DateEtHeuredateHHmmToolStripMenuItem.Tag = "{date:HH:mm}"
        Me.DateEtHeuredateHHmmToolStripMenuItem.Text = "date et heure : {date:HH:mm}"
        '
        'mnuNom
        '
        Me.mnuNom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntiernomToolStripMenuItem, Me.PremiersCarnomS4ToolStripMenuItem})
        Me.mnuNom.Name = "mnuNom"
        Me.mnuNom.Size = New System.Drawing.Size(222, 22)
        Me.mnuNom.Tag = ""
        Me.mnuNom.Text = "Nom du fournisseur : {nom}"
        '
        'EntiernomToolStripMenuItem
        '
        Me.EntiernomToolStripMenuItem.Name = "EntiernomToolStripMenuItem"
        Me.EntiernomToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.EntiernomToolStripMenuItem.Tag = "{nom}"
        Me.EntiernomToolStripMenuItem.Text = "entier : {nom}"
        '
        'PremiersCarnomS4ToolStripMenuItem
        '
        Me.PremiersCarnomS4ToolStripMenuItem.Name = "PremiersCarnomS4ToolStripMenuItem"
        Me.PremiersCarnomS4ToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.PremiersCarnomS4ToolStripMenuItem.Tag = "{nom:S4}"
        Me.PremiersCarnomS4ToolStripMenuItem.Text = "4 premiers car. : {nom:S4}"
        '
        'DescriptiondescToolStripMenuItem
        '
        Me.DescriptiondescToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntierToolStripMenuItem, Me.PremiersCardescS8ToolStripMenuItem})
        Me.DescriptiondescToolStripMenuItem.Name = "DescriptiondescToolStripMenuItem"
        Me.DescriptiondescToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.DescriptiondescToolStripMenuItem.Text = "Description : {desc}"
        '
        'EntierToolStripMenuItem
        '
        Me.EntierToolStripMenuItem.Name = "EntierToolStripMenuItem"
        Me.EntierToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.EntierToolStripMenuItem.Tag = "{desc}"
        Me.EntierToolStripMenuItem.Text = "entier : {desc}"
        '
        'PremiersCardescS8ToolStripMenuItem
        '
        Me.PremiersCardescS8ToolStripMenuItem.Name = "PremiersCardescS8ToolStripMenuItem"
        Me.PremiersCardescS8ToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.PremiersCardescS8ToolStripMenuItem.Tag = "{desc:S8}"
        Me.PremiersCardescS8ToolStripMenuItem.Text = "8 premiers car. : {desc:S8}"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
        Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
        Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
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
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.TbFermer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(409, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrParametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(409, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramètres"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodeHistoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ctxAideFormat.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfig As ControleTracabilite.SqlConnectionConfig
    Friend WithEvents RepPDFTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtBrowsePdf As System.Windows.Forms.Button
    Friend WithEvents lnkAddPdf As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PeriodeHistoNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxFormatLotFab As System.Windows.Forms.TextBox
    Friend WithEvents TxFormatLotBR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnkAideFormatLotBR As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAideFormatLotFab As System.Windows.Forms.LinkLabel
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lbExempleLotFab As System.Windows.Forms.Label
    Friend WithEvents lbExempleLotBR As System.Windows.Forms.Label
    Friend WithEvents ctxAideFormat As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NAutomatiquenumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateDuJourdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sur2Chiffresnum00ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParDéfautnumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sur3Chiffresnum000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParDéfautdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatCourtdatejjMMaaaaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatAlphadateaaMMjjToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuantièmequantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParDéfautquantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sur3Chifffresquant000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateEtHeuredateHHmmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntiernomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PremiersCarnomS4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescriptiondescToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PremiersCardescS8ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class