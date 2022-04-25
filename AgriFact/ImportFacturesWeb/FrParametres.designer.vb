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
        Dim Label1 As System.Windows.Forms.Label
        Dim CodeProduitPortLabel As System.Windows.Forms.Label
        Dim CodeTVADefautLabel As System.Windows.Forms.Label
        Dim CompteClientDefautLabel As System.Windows.Forms.Label
        Dim CompteProduitDefautLabel As System.Windows.Forms.Label
        Dim FamilleDefautLabel As System.Windows.Forms.Label
        Dim ConnectionStringBuilderWrapper2 As ImportFacturesWeb.ConnectionStringBuilderWrapper = New ImportFacturesWeb.ConnectionStringBuilderWrapper
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig = New ImportFacturesWeb.SqlConnectionConfig
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbDossiers = New System.Windows.Forms.ComboBox
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DossierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.FamilleDefautComboBox = New System.Windows.Forms.ComboBox
        Me.FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ImportFacturesWeb.DsAgrifact
        Me.CompteProduitDefautTextBox = New System.Windows.Forms.TextBox
        Me.CompteClientDefautTextBox = New System.Windows.Forms.TextBox
        Me.CodeTVADefautComboBox = New System.Windows.Forms.ComboBox
        Me.TVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CodeProduitPortComboBox = New System.Windows.Forms.ComboBox
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitTableAdapter = New ImportFacturesWeb.DsAgrifactTableAdapters.ProduitTableAdapter
        Me.TVATableAdapter = New ImportFacturesWeb.DsAgrifactTableAdapters.TVATableAdapter
        Me.FamilleTableAdapter = New ImportFacturesWeb.DsAgrifactTableAdapters.FamilleTableAdapter
        Me.VerfiNFactCheckBox = New System.Windows.Forms.CheckBox
        Label1 = New System.Windows.Forms.Label
        CodeProduitPortLabel = New System.Windows.Forms.Label
        CodeTVADefautLabel = New System.Windows.Forms.Label
        CompteClientDefautLabel = New System.Windows.Forms.Label
        CompteProduitDefautLabel = New System.Windows.Forms.Label
        FamilleDefautLabel = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DossierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 31)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(48, 13)
        Label1.TabIndex = 1
        Label1.Text = "Dossier :"
        '
        'CodeProduitPortLabel
        '
        CodeProduitPortLabel.AutoSize = True
        CodeProduitPortLabel.Location = New System.Drawing.Point(6, 28)
        CodeProduitPortLabel.Name = "CodeProduitPortLabel"
        CodeProduitPortLabel.Size = New System.Drawing.Size(65, 13)
        CodeProduitPortLabel.TabIndex = 0
        CodeProduitPortLabel.Text = "Produit Port:"
        '
        'CodeTVADefautLabel
        '
        CodeTVADefautLabel.AutoSize = True
        CodeTVADefautLabel.Location = New System.Drawing.Point(6, 82)
        CodeTVADefautLabel.Name = "CodeTVADefautLabel"
        CodeTVADefautLabel.Size = New System.Drawing.Size(59, 13)
        CodeTVADefautLabel.TabIndex = 2
        CodeTVADefautLabel.Text = "Code TVA:"
        '
        'CompteClientDefautLabel
        '
        CompteClientDefautLabel.AutoSize = True
        CompteClientDefautLabel.Location = New System.Drawing.Point(6, 109)
        CompteClientDefautLabel.Name = "CompteClientDefautLabel"
        CompteClientDefautLabel.Size = New System.Drawing.Size(61, 13)
        CompteClientDefautLabel.TabIndex = 4
        CompteClientDefautLabel.Text = "Cpte Client:"
        '
        'CompteProduitDefautLabel
        '
        CompteProduitDefautLabel.AutoSize = True
        CompteProduitDefautLabel.Location = New System.Drawing.Point(141, 109)
        CompteProduitDefautLabel.Name = "CompteProduitDefautLabel"
        CompteProduitDefautLabel.Size = New System.Drawing.Size(82, 13)
        CompteProduitDefautLabel.TabIndex = 6
        CompteProduitDefautLabel.Text = "Compte Produit:"
        '
        'FamilleDefautLabel
        '
        FamilleDefautLabel.AutoSize = True
        FamilleDefautLabel.Location = New System.Drawing.Point(6, 55)
        FamilleDefautLabel.Name = "FamilleDefautLabel"
        FamilleDefautLabel.Size = New System.Drawing.Size(42, 13)
        FamilleDefautLabel.TabIndex = 8
        FamilleDefautLabel.Text = "Famille:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres de connexion"
        '
        'SqlConnectionConfig
        '
        ConnectionStringBuilderWrapper2.ConnectionString = "Integrated Security=True"
        ConnectionStringBuilderWrapper2.Database = ""
        ConnectionStringBuilderWrapper2.Login = ""
        ConnectionStringBuilderWrapper2.Password = ""
        ConnectionStringBuilderWrapper2.Server = ""
        Me.SqlConnectionConfig.ConnectionStringBuilder = ConnectionStringBuilderWrapper2
        Me.SqlConnectionConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 16)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(330, 141)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(358, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.ImportFacturesWeb.My.Resources.Resources.saveHS
        Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
        Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'cbDossiers
        '
        Me.cbDossiers.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "LastDossier", True))
        Me.cbDossiers.DataSource = Me.DossierBindingSource
        Me.cbDossiers.DisplayMember = "Nom"
        Me.cbDossiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDossiers.FormattingEnabled = True
        Me.cbDossiers.Location = New System.Drawing.Point(67, 28)
        Me.cbDossiers.Name = "cbDossiers"
        Me.cbDossiers.Size = New System.Drawing.Size(272, 21)
        Me.cbDossiers.TabIndex = 2
        Me.cbDossiers.ValueMember = "Nom"
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(ImportFacturesWeb.My.MySettings)
        '
        'DossierBindingSource
        '
        Me.DossierBindingSource.DataSource = GetType(ImportFacturesWeb.Dossier)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.VerfiNFactCheckBox)
        Me.GroupBox2.Controls.Add(FamilleDefautLabel)
        Me.GroupBox2.Controls.Add(Me.FamilleDefautComboBox)
        Me.GroupBox2.Controls.Add(CompteProduitDefautLabel)
        Me.GroupBox2.Controls.Add(Me.CompteProduitDefautTextBox)
        Me.GroupBox2.Controls.Add(CompteClientDefautLabel)
        Me.GroupBox2.Controls.Add(Me.CompteClientDefautTextBox)
        Me.GroupBox2.Controls.Add(CodeTVADefautLabel)
        Me.GroupBox2.Controls.Add(Me.CodeTVADefautComboBox)
        Me.GroupBox2.Controls.Add(CodeProduitPortLabel)
        Me.GroupBox2.Controls.Add(Me.CodeProduitPortComboBox)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 161)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options de facturation par défaut"
        '
        'FamilleDefautComboBox
        '
        Me.FamilleDefautComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "FamilleDefaut", True))
        Me.FamilleDefautComboBox.DataSource = Me.FamilleBindingSource
        Me.FamilleDefautComboBox.DisplayMember = "Famille"
        Me.FamilleDefautComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FamilleDefautComboBox.FormattingEnabled = True
        Me.FamilleDefautComboBox.Location = New System.Drawing.Point(77, 52)
        Me.FamilleDefautComboBox.Name = "FamilleDefautComboBox"
        Me.FamilleDefautComboBox.Size = New System.Drawing.Size(210, 21)
        Me.FamilleDefautComboBox.TabIndex = 9
        Me.FamilleDefautComboBox.ValueMember = "nFamille"
        '
        'FamilleBindingSource
        '
        Me.FamilleBindingSource.DataMember = "Famille"
        Me.FamilleBindingSource.DataSource = Me.DsAgrifact
        Me.FamilleBindingSource.Sort = "Famille"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CompteProduitDefautTextBox
        '
        Me.CompteProduitDefautTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "CompteProduitDefaut", True))
        Me.CompteProduitDefautTextBox.Location = New System.Drawing.Point(229, 106)
        Me.CompteProduitDefautTextBox.Name = "CompteProduitDefautTextBox"
        Me.CompteProduitDefautTextBox.Size = New System.Drawing.Size(58, 20)
        Me.CompteProduitDefautTextBox.TabIndex = 7
        Me.CompteProduitDefautTextBox.Text = "00000000"
        '
        'CompteClientDefautTextBox
        '
        Me.CompteClientDefautTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "CompteClientDefaut", True))
        Me.CompteClientDefautTextBox.Location = New System.Drawing.Point(77, 106)
        Me.CompteClientDefautTextBox.Name = "CompteClientDefautTextBox"
        Me.CompteClientDefautTextBox.Size = New System.Drawing.Size(58, 20)
        Me.CompteClientDefautTextBox.TabIndex = 5
        Me.CompteClientDefautTextBox.Text = "00000000"
        '
        'CodeTVADefautComboBox
        '
        Me.CodeTVADefautComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "CodeTVADefaut", True))
        Me.CodeTVADefautComboBox.DataSource = Me.TVABindingSource
        Me.CodeTVADefautComboBox.DisplayMember = "TLibelle"
        Me.CodeTVADefautComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CodeTVADefautComboBox.FormattingEnabled = True
        Me.CodeTVADefautComboBox.Location = New System.Drawing.Point(77, 79)
        Me.CodeTVADefautComboBox.Name = "CodeTVADefautComboBox"
        Me.CodeTVADefautComboBox.Size = New System.Drawing.Size(210, 21)
        Me.CodeTVADefautComboBox.TabIndex = 3
        Me.CodeTVADefautComboBox.ValueMember = "TTVA"
        '
        'TVABindingSource
        '
        Me.TVABindingSource.DataMember = "TVA"
        Me.TVABindingSource.DataSource = Me.DsAgrifact
        '
        'CodeProduitPortComboBox
        '
        Me.CodeProduitPortComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MySettingsBindingSource, "CodeProduitPort", True))
        Me.CodeProduitPortComboBox.DataSource = Me.ProduitBindingSource
        Me.CodeProduitPortComboBox.DisplayMember = "Libelle"
        Me.CodeProduitPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CodeProduitPortComboBox.FormattingEnabled = True
        Me.CodeProduitPortComboBox.Location = New System.Drawing.Point(77, 25)
        Me.CodeProduitPortComboBox.Name = "CodeProduitPortComboBox"
        Me.CodeProduitPortComboBox.Size = New System.Drawing.Size(210, 21)
        Me.CodeProduitPortComboBox.TabIndex = 1
        Me.CodeProduitPortComboBox.ValueMember = "CodeProduit"
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.DsAgrifact
        Me.ProduitBindingSource.Filter = "Inactif=0"
        Me.ProduitBindingSource.Sort = "Libelle"
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'TVATableAdapter
        '
        Me.TVATableAdapter.ClearBeforeFill = True
        '
        'FamilleTableAdapter
        '
        Me.FamilleTableAdapter.ClearBeforeFill = True
        '
        'VerfiNFactCheckBox
        '
        Me.VerfiNFactCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.MySettingsBindingSource, "VerfiNFact", True))
        Me.VerfiNFactCheckBox.Location = New System.Drawing.Point(77, 132)
        Me.VerfiNFactCheckBox.Name = "VerfiNFactCheckBox"
        Me.VerfiNFactCheckBox.Size = New System.Drawing.Size(210, 24)
        Me.VerfiNFactCheckBox.TabIndex = 11
        Me.VerfiNFactCheckBox.Text = "Vérifier l'unicité des n° de facture"
        '
        'FrParametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(358, 394)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cbDossiers)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DossierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfig As SqlConnectionConfig
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbDossiers As System.Windows.Forms.ComboBox
    Friend WithEvents DossierBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CompteProduitDefautTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompteClientDefautTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeTVADefautComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CodeProduitPortComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DsAgrifact As ImportFacturesWeb.DsAgrifact
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As ImportFacturesWeb.DsAgrifactTableAdapters.ProduitTableAdapter
    Friend WithEvents TVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TVATableAdapter As ImportFacturesWeb.DsAgrifactTableAdapters.TVATableAdapter
    Friend WithEvents FamilleDefautComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamilleTableAdapter As ImportFacturesWeb.DsAgrifactTableAdapters.FamilleTableAdapter
    Friend WithEvents VerfiNFactCheckBox As System.Windows.Forms.CheckBox
End Class