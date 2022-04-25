<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrFicheProduit
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
        Dim CodeProduitLabel As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim LibelleLongLabel As System.Windows.Forms.Label
        Dim Famille1Label As System.Windows.Forms.Label
        Dim Unite1Label1 As System.Windows.Forms.Label
        Dim Unite2Label1 As System.Windows.Forms.Label
        Dim CodeBarreLabel As System.Windows.Forms.Label
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
        Me.ProduitBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbInactif = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbComposition = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.TbControles = New System.Windows.Forms.ToolStripButton
        Me.CodeProduitTextBox = New System.Windows.Forms.TextBox
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.LibelleLongTextBox = New System.Windows.Forms.TextBox
        Me.ProduitAchatCheckBox = New System.Windows.Forms.CheckBox
        Me.Famille1ComboBox = New System.Windows.Forms.ComboBox
        Me.FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.MarqueTextBox = New System.Windows.Forms.TextBox
        Me.MarqueLabel = New System.Windows.Forms.Label
        Me.PoidsUnitaireTextBox = New System.Windows.Forms.TextBox
        Me.QteCondTextBox = New System.Windows.Forms.TextBox
        Me.PoidsUnitaireLabel = New System.Windows.Forms.Label
        Me.QteCondLabel = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbU1 = New System.Windows.Forms.Label
        Me.TxSeuilStock = New System.Windows.Forms.TextBox
        Me.lbSeuilStock = New System.Windows.Forms.Label
        Me.chkStock = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Unite1ComboBox = New System.Windows.Forms.ComboBox
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbDescUnites = New System.Windows.Forms.Label
        Me.ChkCoefU2 = New System.Windows.Forms.CheckBox
        Me.Unite2ComboBox = New System.Windows.Forms.ComboBox
        Me.ListeChoixBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.CoefU2TextBox = New System.Windows.Forms.TextBox
        Me.ProduitVenteCheckBox = New System.Windows.Forms.CheckBox
        Me.BtNewCB = New System.Windows.Forms.Button
        Me.CodeBarreTextBox = New System.Windows.Forms.TextBox
        Me.FamilleTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ListeChoixTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
        CodeProduitLabel = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        LibelleLongLabel = New System.Windows.Forms.Label
        Famille1Label = New System.Windows.Forms.Label
        Unite1Label1 = New System.Windows.Forms.Label
        Unite2Label1 = New System.Windows.Forms.Label
        CodeBarreLabel = New System.Windows.Forms.Label
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProduitBindingNavigator.SuspendLayout()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CodeProduitLabel
        '
        CodeProduitLabel.AutoSize = True
        CodeProduitLabel.Location = New System.Drawing.Point(12, 18)
        CodeProduitLabel.Name = "CodeProduitLabel"
        CodeProduitLabel.Size = New System.Drawing.Size(71, 13)
        CodeProduitLabel.TabIndex = 0
        CodeProduitLabel.Text = "Code Produit:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(12, 72)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(40, 13)
        LibelleLabel.TabIndex = 7
        LibelleLabel.Text = "Libelle:"
        '
        'LibelleLongLabel
        '
        LibelleLongLabel.AutoSize = True
        LibelleLongLabel.Location = New System.Drawing.Point(12, 308)
        LibelleLongLabel.Name = "LibelleLongLabel"
        LibelleLongLabel.Size = New System.Drawing.Size(63, 13)
        LibelleLongLabel.TabIndex = 12
        LibelleLongLabel.Text = "Description:"
        '
        'Famille1Label
        '
        Famille1Label.AutoSize = True
        Famille1Label.Location = New System.Drawing.Point(12, 45)
        Famille1Label.Name = "Famille1Label"
        Famille1Label.Size = New System.Drawing.Size(42, 13)
        Famille1Label.TabIndex = 5
        Famille1Label.Text = "Famille:"
        '
        'Unite1Label1
        '
        Unite1Label1.AutoSize = True
        Unite1Label1.Location = New System.Drawing.Point(6, 22)
        Unite1Label1.Name = "Unite1Label1"
        Unite1Label1.Size = New System.Drawing.Size(41, 13)
        Unite1Label1.TabIndex = 0
        Unite1Label1.Text = "Unite1:"
        '
        'Unite2Label1
        '
        Unite2Label1.AutoSize = True
        Unite2Label1.Location = New System.Drawing.Point(132, 22)
        Unite2Label1.Name = "Unite2Label1"
        Unite2Label1.Size = New System.Drawing.Size(41, 13)
        Unite2Label1.TabIndex = 2
        Unite2Label1.Text = "Unite2:"
        '
        'CodeBarreLabel
        '
        CodeBarreLabel.AutoSize = True
        CodeBarreLabel.Location = New System.Drawing.Point(259, 18)
        CodeBarreLabel.Name = "CodeBarreLabel"
        CodeBarreLabel.Size = New System.Drawing.Size(32, 13)
        CodeBarreLabel.TabIndex = 2
        CodeBarreLabel.Text = "EAN:"
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'ProduitBindingNavigator
        '
        Me.ProduitBindingNavigator.AddNewItem = Nothing
        Me.ProduitBindingNavigator.BindingSource = Me.ProduitBindingSource
        Me.ProduitBindingNavigator.CountItem = Nothing
        Me.ProduitBindingNavigator.DeleteItem = Nothing
        Me.ProduitBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ProduitBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.TbInactif, Me.ToolStripSeparator2, Me.TbComposition, Me.TbFermer, Me.TbControles})
        Me.ProduitBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ProduitBindingNavigator.MoveFirstItem = Nothing
        Me.ProduitBindingNavigator.MoveLastItem = Nothing
        Me.ProduitBindingNavigator.MoveNextItem = Nothing
        Me.ProduitBindingNavigator.MovePreviousItem = Nothing
        Me.ProduitBindingNavigator.Name = "ProduitBindingNavigator"
        Me.ProduitBindingNavigator.PositionItem = Nothing
        Me.ProduitBindingNavigator.Size = New System.Drawing.Size(424, 25)
        Me.ProduitBindingNavigator.TabIndex = 0
        Me.ProduitBindingNavigator.Text = "BindingNavigator1"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
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
        Me.TbInactif.CheckOnClick = True
        Me.TbInactif.Image = Global.ControleTracabilite.My.Resources.Resources.inactif
        Me.TbInactif.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbInactif.Name = "TbInactif"
        Me.TbInactif.Size = New System.Drawing.Size(102, 22)
        Me.TbInactif.Text = "Produit inactif"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TbComposition
        '
        Me.TbComposition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbComposition.Image = Global.ControleTracabilite.My.Resources.Resources.compo
        Me.TbComposition.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbComposition.Name = "TbComposition"
        Me.TbComposition.Size = New System.Drawing.Size(23, 22)
        Me.TbComposition.Text = "Recette"
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
        'TbControles
        '
        Me.TbControles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbControles.Image = Global.ControleTracabilite.My.Resources.Resources.controles
        Me.TbControles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbControles.Name = "TbControles"
        Me.TbControles.Size = New System.Drawing.Size(23, 22)
        Me.TbControles.Text = "Contrôles produit"
        '
        'CodeProduitTextBox
        '
        Me.CodeProduitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "CodeProduit", True))
        Me.CodeProduitTextBox.Location = New System.Drawing.Point(89, 15)
        Me.CodeProduitTextBox.MaxLength = 255
        Me.CodeProduitTextBox.Name = "CodeProduitTextBox"
        Me.CodeProduitTextBox.Size = New System.Drawing.Size(170, 20)
        Me.CodeProduitTextBox.TabIndex = 1
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(89, 69)
        Me.LibelleTextBox.MaxLength = 255
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(322, 20)
        Me.LibelleTextBox.TabIndex = 8
        '
        'LibelleLongTextBox
        '
        Me.LibelleLongTextBox.AcceptsReturn = True
        Me.LibelleLongTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LibelleLongTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "LibelleLong", True))
        Me.LibelleLongTextBox.Location = New System.Drawing.Point(89, 305)
        Me.LibelleLongTextBox.Multiline = True
        Me.LibelleLongTextBox.Name = "LibelleLongTextBox"
        Me.LibelleLongTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LibelleLongTextBox.Size = New System.Drawing.Size(323, 133)
        Me.LibelleLongTextBox.TabIndex = 13
        '
        'ProduitAchatCheckBox
        '
        Me.ProduitAchatCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.ProduitBindingSource, "ProduitAchat", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ProduitAchatCheckBox.Location = New System.Drawing.Point(89, 95)
        Me.ProduitAchatCheckBox.Name = "ProduitAchatCheckBox"
        Me.ProduitAchatCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ProduitAchatCheckBox.TabIndex = 9
        Me.ProduitAchatCheckBox.Text = "Matière première"
        '
        'Famille1ComboBox
        '
        Me.Famille1ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ProduitBindingSource, "Famille1", True))
        Me.Famille1ComboBox.DataSource = Me.FamilleBindingSource
        Me.Famille1ComboBox.DisplayMember = "Famille"
        Me.Famille1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Famille1ComboBox.FormattingEnabled = True
        Me.Famille1ComboBox.Location = New System.Drawing.Point(89, 41)
        Me.Famille1ComboBox.Name = "Famille1ComboBox"
        Me.Famille1ComboBox.Size = New System.Drawing.Size(322, 21)
        Me.Famille1ComboBox.TabIndex = 6
        Me.Famille1ComboBox.ValueMember = "nFamille"
        '
        'FamilleBindingSource
        '
        Me.FamilleBindingSource.DataMember = "Famille"
        Me.FamilleBindingSource.DataSource = Me.AgrifactTracaDataSet
        Me.FamilleBindingSource.Sort = "Famille"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.MarqueTextBox)
        Me.GradientPanel1.Controls.Add(Me.MarqueLabel)
        Me.GradientPanel1.Controls.Add(Me.PoidsUnitaireTextBox)
        Me.GradientPanel1.Controls.Add(Me.QteCondTextBox)
        Me.GradientPanel1.Controls.Add(Me.PoidsUnitaireLabel)
        Me.GradientPanel1.Controls.Add(Me.QteCondLabel)
        Me.GradientPanel1.Controls.Add(Me.GroupBox2)
        Me.GradientPanel1.Controls.Add(Me.GroupBox1)
        Me.GradientPanel1.Controls.Add(Me.ProduitVenteCheckBox)
        Me.GradientPanel1.Controls.Add(Me.BtNewCB)
        Me.GradientPanel1.Controls.Add(CodeBarreLabel)
        Me.GradientPanel1.Controls.Add(Me.CodeBarreTextBox)
        Me.GradientPanel1.Controls.Add(Me.CodeProduitTextBox)
        Me.GradientPanel1.Controls.Add(Famille1Label)
        Me.GradientPanel1.Controls.Add(Me.Famille1ComboBox)
        Me.GradientPanel1.Controls.Add(CodeProduitLabel)
        Me.GradientPanel1.Controls.Add(LibelleLabel)
        Me.GradientPanel1.Controls.Add(Me.ProduitAchatCheckBox)
        Me.GradientPanel1.Controls.Add(Me.LibelleTextBox)
        Me.GradientPanel1.Controls.Add(LibelleLongLabel)
        Me.GradientPanel1.Controls.Add(Me.LibelleLongTextBox)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(424, 522)
        Me.GradientPanel1.TabIndex = 1
        '
        'MarqueTextBox
        '
        Me.MarqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "marque", True))
        Me.MarqueTextBox.Location = New System.Drawing.Point(89, 489)
        Me.MarqueTextBox.Name = "MarqueTextBox"
        Me.MarqueTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MarqueTextBox.TabIndex = 20
        '
        'MarqueLabel
        '
        Me.MarqueLabel.AutoSize = True
        Me.MarqueLabel.Location = New System.Drawing.Point(12, 492)
        Me.MarqueLabel.Name = "MarqueLabel"
        Me.MarqueLabel.Size = New System.Drawing.Size(43, 13)
        Me.MarqueLabel.TabIndex = 19
        Me.MarqueLabel.Text = "Marque"
        '
        'PoidsUnitaireTextBox
        '
        Me.PoidsUnitaireTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "poidsUnitaire", True))
        Me.PoidsUnitaireTextBox.Location = New System.Drawing.Point(89, 463)
        Me.PoidsUnitaireTextBox.Name = "PoidsUnitaireTextBox"
        Me.PoidsUnitaireTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PoidsUnitaireTextBox.TabIndex = 18
        '
        'QteCondTextBox
        '
        Me.QteCondTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "qteConditionnement", True))
        Me.QteCondTextBox.Location = New System.Drawing.Point(89, 436)
        Me.QteCondTextBox.Name = "QteCondTextBox"
        Me.QteCondTextBox.Size = New System.Drawing.Size(100, 20)
        Me.QteCondTextBox.TabIndex = 17
        '
        'PoidsUnitaireLabel
        '
        Me.PoidsUnitaireLabel.AutoSize = True
        Me.PoidsUnitaireLabel.Location = New System.Drawing.Point(12, 466)
        Me.PoidsUnitaireLabel.Name = "PoidsUnitaireLabel"
        Me.PoidsUnitaireLabel.Size = New System.Drawing.Size(72, 13)
        Me.PoidsUnitaireLabel.TabIndex = 16
        Me.PoidsUnitaireLabel.Text = "Poids Unitaire"
        '
        'QteCondLabel
        '
        Me.QteCondLabel.AutoSize = True
        Me.QteCondLabel.Location = New System.Drawing.Point(12, 439)
        Me.QteCondLabel.Name = "QteCondLabel"
        Me.QteCondLabel.Size = New System.Drawing.Size(55, 13)
        Me.QteCondLabel.TabIndex = 15
        Me.QteCondLabel.Text = "Qté Cond."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbU1)
        Me.GroupBox2.Controls.Add(Me.TxSeuilStock)
        Me.GroupBox2.Controls.Add(Me.lbSeuilStock)
        Me.GroupBox2.Controls.Add(Me.chkStock)
        Me.GroupBox2.Location = New System.Drawing.Point(89, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 68)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock"
        '
        'lbU1
        '
        Me.lbU1.AutoSize = True
        Me.lbU1.Location = New System.Drawing.Point(229, 39)
        Me.lbU1.Name = "lbU1"
        Me.lbU1.Size = New System.Drawing.Size(29, 13)
        Me.lbU1.TabIndex = 7
        Me.lbU1.Text = "lbU1"
        '
        'TxSeuilStock
        '
        Me.TxSeuilStock.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "SeuilStock", True))
        Me.TxSeuilStock.Location = New System.Drawing.Point(176, 36)
        Me.TxSeuilStock.Name = "TxSeuilStock"
        Me.TxSeuilStock.Size = New System.Drawing.Size(47, 20)
        Me.TxSeuilStock.TabIndex = 6
        Me.TxSeuilStock.Text = "999.999"
        Me.TxSeuilStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbSeuilStock
        '
        Me.lbSeuilStock.AutoSize = True
        Me.lbSeuilStock.Location = New System.Drawing.Point(6, 39)
        Me.lbSeuilStock.Name = "lbSeuilStock"
        Me.lbSeuilStock.Size = New System.Drawing.Size(164, 13)
        Me.lbSeuilStock.TabIndex = 1
        Me.lbSeuilStock.Text = "Alerte si le stock est en deça de :"
        '
        'chkStock
        '
        Me.chkStock.AutoSize = True
        Me.chkStock.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.ProduitBindingSource, "GestionStock", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkStock.Location = New System.Drawing.Point(9, 19)
        Me.chkStock.Name = "chkStock"
        Me.chkStock.Size = New System.Drawing.Size(92, 17)
        Me.chkStock.TabIndex = 0
        Me.chkStock.Text = "Gérer le stock"
        Me.chkStock.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Unite1ComboBox)
        Me.GroupBox1.Controls.Add(Me.lbDescUnites)
        Me.GroupBox1.Controls.Add(Unite1Label1)
        Me.GroupBox1.Controls.Add(Me.ChkCoefU2)
        Me.GroupBox1.Controls.Add(Me.Unite2ComboBox)
        Me.GroupBox1.Controls.Add(Me.CoefU2TextBox)
        Me.GroupBox1.Controls.Add(Unite2Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(89, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 100)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Unités"
        '
        'Unite1ComboBox
        '
        Me.Unite1ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Unite1", True))
        Me.Unite1ComboBox.DataSource = Me.ListeChoixBindingSource
        Me.Unite1ComboBox.DisplayMember = "Valeur"
        Me.Unite1ComboBox.FormattingEnabled = True
        Me.Unite1ComboBox.Location = New System.Drawing.Point(53, 19)
        Me.Unite1ComboBox.MaxLength = 2
        Me.Unite1ComboBox.Name = "Unite1ComboBox"
        Me.Unite1ComboBox.Size = New System.Drawing.Size(65, 21)
        Me.Unite1ComboBox.TabIndex = 1
        Me.Unite1ComboBox.ValueMember = "Valeur"
        '
        'ListeChoixBindingSource
        '
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.DataSource = Me.AgrifactTracaDataSet
        Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
        '
        'lbDescUnites
        '
        Me.lbDescUnites.AutoSize = True
        Me.lbDescUnites.Location = New System.Drawing.Point(9, 69)
        Me.lbDescUnites.Name = "lbDescUnites"
        Me.lbDescUnites.Size = New System.Drawing.Size(70, 13)
        Me.lbDescUnites.TabIndex = 6
        Me.lbDescUnites.Text = "lbDescUnites"
        '
        'ChkCoefU2
        '
        Me.ChkCoefU2.AutoSize = True
        Me.ChkCoefU2.Location = New System.Drawing.Point(9, 48)
        Me.ChkCoefU2.Name = "ChkCoefU2"
        Me.ChkCoefU2.Size = New System.Drawing.Size(182, 17)
        Me.ChkCoefU2.TabIndex = 4
        Me.ChkCoefU2.Text = "Calcul auto. de U2 avec le coef :"
        Me.ChkCoefU2.UseVisualStyleBackColor = True
        '
        'Unite2ComboBox
        '
        Me.Unite2ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Unite2", True))
        Me.Unite2ComboBox.DataSource = Me.ListeChoixBindingSource2
        Me.Unite2ComboBox.DisplayMember = "Valeur"
        Me.Unite2ComboBox.FormattingEnabled = True
        Me.Unite2ComboBox.Location = New System.Drawing.Point(179, 19)
        Me.Unite2ComboBox.MaxLength = 2
        Me.Unite2ComboBox.Name = "Unite2ComboBox"
        Me.Unite2ComboBox.Size = New System.Drawing.Size(65, 21)
        Me.Unite2ComboBox.TabIndex = 3
        Me.Unite2ComboBox.ValueMember = "Valeur"
        '
        'ListeChoixBindingSource2
        '
        Me.ListeChoixBindingSource2.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource2.DataSource = Me.AgrifactTracaDataSet
        Me.ListeChoixBindingSource2.Sort = "nOrdreValeur"
        '
        'CoefU2TextBox
        '
        Me.CoefU2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "CoefU2", True))
        Me.CoefU2TextBox.Location = New System.Drawing.Point(197, 46)
        Me.CoefU2TextBox.Name = "CoefU2TextBox"
        Me.CoefU2TextBox.Size = New System.Drawing.Size(47, 20)
        Me.CoefU2TextBox.TabIndex = 5
        Me.CoefU2TextBox.Text = "999.999"
        Me.CoefU2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ProduitVenteCheckBox
        '
        Me.ProduitVenteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.ProduitBindingSource, "ProduitVente", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ProduitVenteCheckBox.Location = New System.Drawing.Point(199, 95)
        Me.ProduitVenteCheckBox.Name = "ProduitVenteCheckBox"
        Me.ProduitVenteCheckBox.Size = New System.Drawing.Size(82, 24)
        Me.ProduitVenteCheckBox.TabIndex = 10
        Me.ProduitVenteCheckBox.Text = "Produit fini"
        '
        'BtNewCB
        '
        Me.BtNewCB.Enabled = False
        Me.BtNewCB.Image = Global.ControleTracabilite.My.Resources.Resources.BarCodeHS
        Me.BtNewCB.Location = New System.Drawing.Point(379, 13)
        Me.BtNewCB.Name = "BtNewCB"
        Me.BtNewCB.Size = New System.Drawing.Size(32, 23)
        Me.BtNewCB.TabIndex = 4
        Me.BtNewCB.UseVisualStyleBackColor = True
        '
        'CodeBarreTextBox
        '
        Me.CodeBarreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "CodeBarre", True))
        Me.CodeBarreTextBox.Location = New System.Drawing.Point(291, 15)
        Me.CodeBarreTextBox.MaxLength = 13
        Me.CodeBarreTextBox.Name = "CodeBarreTextBox"
        Me.CodeBarreTextBox.Size = New System.Drawing.Size(87, 20)
        Me.CodeBarreTextBox.TabIndex = 3
        '
        'FamilleTableAdapter
        '
        Me.FamilleTableAdapter.ClearBeforeFill = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'FrFicheProduit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(424, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ProduitBindingNavigator)
        Me.Name = "FrFicheProduit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fiche Produit"
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProduitBindingNavigator.ResumeLayout(False)
        Me.ProduitBindingNavigator.PerformLayout()
        CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents ProduitBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CodeProduitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibelleLongTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProduitAchatCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Famille1ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents FamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamilleTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbComposition As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbControles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TbInactif As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Unite2ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Unite1ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
    Friend WithEvents ListeChoixBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents CodeBarreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BtNewCB As System.Windows.Forms.Button
    Friend WithEvents ProduitVenteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CoefU2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChkCoefU2 As System.Windows.Forms.CheckBox
    Friend WithEvents lbDescUnites As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxSeuilStock As System.Windows.Forms.TextBox
    Friend WithEvents lbSeuilStock As System.Windows.Forms.Label
    Friend WithEvents chkStock As System.Windows.Forms.CheckBox
    Friend WithEvents lbU1 As System.Windows.Forms.Label
    Friend WithEvents QteCondLabel As System.Windows.Forms.Label
    Friend WithEvents PoidsUnitaireTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QteCondTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PoidsUnitaireLabel As System.Windows.Forms.Label
    Friend WithEvents MarqueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MarqueLabel As System.Windows.Forms.Label
End Class
