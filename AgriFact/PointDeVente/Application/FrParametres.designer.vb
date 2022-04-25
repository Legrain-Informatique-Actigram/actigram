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
        Dim PrinterNameLabel As System.Windows.Forms.Label
        Dim ConnectionStringBuilderWrapper1 As PointDeVente.ConnectionStringBuilderWrapper = New PointDeVente.ConnectionStringBuilderWrapper
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpOptions = New System.Windows.Forms.TabPage
        Me.ComboBoxDefautCompte = New System.Windows.Forms.ComboBox
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComptesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.ComboBoxDefautTarif = New System.Windows.Forms.ComboBox
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.labelTarifParDefaut = New System.Windows.Forms.Label
        Me.BtChoixImpr = New System.Windows.Forms.Button
        Me.PrinterNameTextBox = New System.Windows.Forms.TextBox
        Me.PosPrinterEnabledCheckBox = New System.Windows.Forms.CheckBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LnkReclaimNFacture = New System.Windows.Forms.LinkLabel
        Me.lbNFacture = New System.Windows.Forms.Label
        Me.lnkResetNFacture = New System.Windows.Forms.LinkLabel
        Me.tpConnexion = New System.Windows.Forms.TabPage
        Me.SqlConnectionConfig = New PointDeVente.SqlConnectionConfig
        Me.tpMaint = New System.Windows.Forms.TabPage
        Me.LnkLog = New System.Windows.Forms.LinkLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.EntrepriseTA = New PointDeVente.DsAgrifactTableAdapters.EntrepriseTA
        Me.TarifTA = New PointDeVente.DsAgrifactTableAdapters.TarifTA
        Me.ComptesTableAdapter = New PointDeVente.DsAgrifactTableAdapters.ComptesTableAdapter
        PrinterNameLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpOptions.SuspendLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tpConnexion.SuspendLayout()
        Me.tpMaint.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrinterNameLabel
        '
        PrinterNameLabel.AutoSize = True
        PrinterNameLabel.Location = New System.Drawing.Point(6, 138)
        PrinterNameLabel.Name = "PrinterNameLabel"
        PrinterNameLabel.Size = New System.Drawing.Size(90, 13)
        PrinterNameLabel.TabIndex = 8
        PrinterNameLabel.Text = "Imprimante ticket:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.TabControl1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(367, 335)
        Me.GradientPanel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpOptions)
        Me.TabControl1.Controls.Add(Me.tpConnexion)
        Me.TabControl1.Controls.Add(Me.tpMaint)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(349, 319)
        Me.TabControl1.TabIndex = 6
        '
        'tpOptions
        '
        Me.tpOptions.AutoScroll = True
        Me.tpOptions.Controls.Add(Me.ComboBoxDefautCompte)
        Me.tpOptions.Controls.Add(Me.ComboBoxDefautTarif)
        Me.tpOptions.Controls.Add(Me.Label2)
        Me.tpOptions.Controls.Add(Me.labelTarifParDefaut)
        Me.tpOptions.Controls.Add(Me.BtChoixImpr)
        Me.tpOptions.Controls.Add(PrinterNameLabel)
        Me.tpOptions.Controls.Add(Me.PrinterNameTextBox)
        Me.tpOptions.Controls.Add(Me.PosPrinterEnabledCheckBox)
        Me.tpOptions.Controls.Add(Me.ComboBox1)
        Me.tpOptions.Controls.Add(Me.Label1)
        Me.tpOptions.Controls.Add(Me.GroupBox2)
        Me.tpOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpOptions.Name = "tpOptions"
        Me.tpOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOptions.Size = New System.Drawing.Size(341, 293)
        Me.tpOptions.TabIndex = 0
        Me.tpOptions.Text = "Options"
        Me.tpOptions.UseVisualStyleBackColor = True
        '
        'ComboBoxDefautCompte
        '
        Me.ComboBoxDefautCompte.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "nCompteDefaut", True))
        Me.ComboBoxDefautCompte.DataSource = Me.ComptesBindingSource
        Me.ComboBoxDefautCompte.DisplayMember = "CCpt"
        Me.ComboBoxDefautCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDefautCompte.FormattingEnabled = True
        Me.ComboBoxDefautCompte.Location = New System.Drawing.Point(111, 84)
        Me.ComboBoxDefautCompte.Name = "ComboBoxDefautCompte"
        Me.ComboBoxDefautCompte.Size = New System.Drawing.Size(224, 21)
        Me.ComboBoxDefautCompte.TabIndex = 20
        Me.ComboBoxDefautCompte.ValueMember = "CCpt"
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'ComptesBindingSource
        '
        Me.ComptesBindingSource.DataMember = "Comptes"
        Me.ComptesBindingSource.DataSource = Me.DsAgrifact
        Me.ComptesBindingSource.Sort = "CCpt"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBoxDefautTarif
        '
        Me.ComboBoxDefautTarif.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "nTarifDefaut", True))
        Me.ComboBoxDefautTarif.DataSource = Me.TarifBindingSource
        Me.ComboBoxDefautTarif.DisplayMember = "Libelle"
        Me.ComboBoxDefautTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDefautTarif.FormattingEnabled = True
        Me.ComboBoxDefautTarif.Location = New System.Drawing.Point(111, 45)
        Me.ComboBoxDefautTarif.Name = "ComboBoxDefautTarif"
        Me.ComboBoxDefautTarif.Size = New System.Drawing.Size(224, 21)
        Me.ComboBoxDefautTarif.TabIndex = 19
        Me.ComboBoxDefautTarif.ValueMember = "nTarif"
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "Tarif"
        Me.TarifBindingSource.DataSource = Me.DsAgrifact
        Me.TarifBindingSource.Sort = "Libelle"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Compte par défaut :"
        '
        'labelTarifParDefaut
        '
        Me.labelTarifParDefaut.AutoSize = True
        Me.labelTarifParDefaut.Location = New System.Drawing.Point(6, 48)
        Me.labelTarifParDefaut.Name = "labelTarifParDefaut"
        Me.labelTarifParDefaut.Size = New System.Drawing.Size(85, 13)
        Me.labelTarifParDefaut.TabIndex = 15
        Me.labelTarifParDefaut.Text = "Tarif par défaut :"
        '
        'BtChoixImpr
        '
        Me.BtChoixImpr.Image = Global.PointDeVente.My.Resources.Resources.impr
        Me.BtChoixImpr.Location = New System.Drawing.Point(287, 132)
        Me.BtChoixImpr.Name = "BtChoixImpr"
        Me.BtChoixImpr.Size = New System.Drawing.Size(32, 23)
        Me.BtChoixImpr.TabIndex = 14
        Me.BtChoixImpr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtChoixImpr.UseVisualStyleBackColor = True
        '
        'PrinterNameTextBox
        '
        Me.PrinterNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "PrinterName", True))
        Me.PrinterNameTextBox.Location = New System.Drawing.Point(99, 135)
        Me.PrinterNameTextBox.Name = "PrinterNameTextBox"
        Me.PrinterNameTextBox.Size = New System.Drawing.Size(182, 20)
        Me.PrinterNameTextBox.TabIndex = 9
        '
        'PosPrinterEnabledCheckBox
        '
        Me.PosPrinterEnabledCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.MySettingsBindingSource, "PrinterEnabled", True))
        Me.PosPrinterEnabledCheckBox.Location = New System.Drawing.Point(99, 161)
        Me.PosPrinterEnabledCheckBox.Name = "PosPrinterEnabledCheckBox"
        Me.PosPrinterEnabledCheckBox.Size = New System.Drawing.Size(192, 24)
        Me.PosPrinterEnabledCheckBox.TabIndex = 8
        Me.PosPrinterEnabledCheckBox.Text = "Activer l'impression de facturette"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "nClientDefaut", True))
        Me.ComboBox1.DataSource = Me.EntrepriseBindingSource
        Me.ComboBox1.DisplayMember = "Nom"
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(111, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(224, 21)
        Me.ComboBox1.TabIndex = 7
        Me.ComboBox1.ValueMember = "nEntreprise"
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.DsAgrifact
        Me.EntrepriseBindingSource.Filter = ""
        Me.EntrepriseBindingSource.Sort = "Nom"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Client par défaut :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LnkReclaimNFacture)
        Me.GroupBox2.Controls.Add(Me.lbNFacture)
        Me.GroupBox2.Controls.Add(Me.lnkResetNFacture)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(310, 89)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Numérotation des factures"
        '
        'LnkReclaimNFacture
        '
        Me.LnkReclaimNFacture.AutoSize = True
        Me.LnkReclaimNFacture.Image = Global.PointDeVente.My.Resources.Resources.RefreshDocViewHS
        Me.LnkReclaimNFacture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LnkReclaimNFacture.Location = New System.Drawing.Point(5, 29)
        Me.LnkReclaimNFacture.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.LnkReclaimNFacture.Name = "LnkReclaimNFacture"
        Me.LnkReclaimNFacture.Padding = New System.Windows.Forms.Padding(18, 2, 0, 2)
        Me.LnkReclaimNFacture.Size = New System.Drawing.Size(172, 17)
        Me.LnkReclaimNFacture.TabIndex = 2
        Me.LnkReclaimNFacture.TabStop = True
        Me.LnkReclaimNFacture.Text = "Recaler les numéros de facture"
        '
        'lbNFacture
        '
        Me.lbNFacture.AutoSize = True
        Me.lbNFacture.Location = New System.Drawing.Point(6, 16)
        Me.lbNFacture.Name = "lbNFacture"
        Me.lbNFacture.Size = New System.Drawing.Size(173, 13)
        Me.lbNFacture.TabIndex = 4
        Me.lbNFacture.Text = "La prochaine facture aura le n°{0} :"
        '
        'lnkResetNFacture
        '
        Me.lnkResetNFacture.AutoSize = True
        Me.lnkResetNFacture.Image = Global.PointDeVente.My.Resources.Resources._new
        Me.lnkResetNFacture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkResetNFacture.Location = New System.Drawing.Point(6, 49)
        Me.lnkResetNFacture.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkResetNFacture.Name = "lnkResetNFacture"
        Me.lnkResetNFacture.Padding = New System.Windows.Forms.Padding(18, 2, 0, 2)
        Me.lnkResetNFacture.Size = New System.Drawing.Size(225, 17)
        Me.lnkResetNFacture.TabIndex = 3
        Me.lnkResetNFacture.TabStop = True
        Me.lnkResetNFacture.Text = "Redémarrer la numérotation des factures..."
        '
        'tpConnexion
        '
        Me.tpConnexion.Controls.Add(Me.SqlConnectionConfig)
        Me.tpConnexion.Location = New System.Drawing.Point(4, 22)
        Me.tpConnexion.Name = "tpConnexion"
        Me.tpConnexion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConnexion.Size = New System.Drawing.Size(341, 293)
        Me.tpConnexion.TabIndex = 1
        Me.tpConnexion.Text = "Base de données"
        Me.tpConnexion.UseVisualStyleBackColor = True
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
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 3)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(335, 287)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'tpMaint
        '
        Me.tpMaint.Controls.Add(Me.LnkLog)
        Me.tpMaint.Location = New System.Drawing.Point(4, 22)
        Me.tpMaint.Name = "tpMaint"
        Me.tpMaint.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMaint.Size = New System.Drawing.Size(341, 293)
        Me.tpMaint.TabIndex = 2
        Me.tpMaint.Text = "Maintenance"
        Me.tpMaint.UseVisualStyleBackColor = True
        '
        'LnkLog
        '
        Me.LnkLog.AutoSize = True
        Me.LnkLog.Image = Global.PointDeVente.My.Resources.Resources.log
        Me.LnkLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LnkLog.Location = New System.Drawing.Point(6, 12)
        Me.LnkLog.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.LnkLog.Name = "LnkLog"
        Me.LnkLog.Padding = New System.Windows.Forms.Padding(18, 2, 0, 2)
        Me.LnkLog.Size = New System.Drawing.Size(129, 17)
        Me.LnkLog.TabIndex = 1
        Me.LnkLog.TabStop = True
        Me.LnkLog.Text = "Afficher le fichier log..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.TbFermer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(367, 25)
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
        'EntrepriseTA
        '
        Me.EntrepriseTA.ClearBeforeFill = True
        '
        'TarifTA
        '
        Me.TarifTA.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'FrParametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(367, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramètres"
        Me.GradientPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpOptions.ResumeLayout(False)
        Me.tpOptions.PerformLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpConnexion.ResumeLayout(False)
        Me.tpMaint.ResumeLayout(False)
        Me.tpMaint.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SqlConnectionConfig As PointDeVente.SqlConnectionConfig
    Friend WithEvents LnkLog As System.Windows.Forms.LinkLabel
    Friend WithEvents lbNFacture As System.Windows.Forms.Label
    Friend WithEvents lnkResetNFacture As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkReclaimNFacture As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpOptions As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpConnexion As System.Windows.Forms.TabPage
    Friend WithEvents tpMaint As System.Windows.Forms.TabPage
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseTA As PointDeVente.DsAgrifactTableAdapters.EntrepriseTA
    Friend WithEvents PosPrinterEnabledCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrinterNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BtChoixImpr As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents labelTarifParDefaut As System.Windows.Forms.Label
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TarifTA As PointDeVente.DsAgrifactTableAdapters.TarifTA
    Friend WithEvents ComptesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComptesTableAdapter As PointDeVente.DsAgrifactTableAdapters.ComptesTableAdapter
    Friend WithEvents ComboBoxDefautCompte As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxDefautTarif As System.Windows.Forms.ComboBox
End Class