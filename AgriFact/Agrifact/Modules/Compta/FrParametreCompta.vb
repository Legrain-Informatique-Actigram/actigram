Public Class FrParametreCompta
    Inherits GRC.FrBase

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
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbRegimeTVA As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents CbDossier As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpFourchettesV As System.Windows.Forms.TabPage
    Friend WithEvents tpExos As System.Windows.Forms.TabPage
    Friend WithEvents tpJournaux As System.Windows.Forms.TabPage
    Friend WithEvents tpTVA As System.Windows.Forms.TabPage
    Friend WithEvents tpFourchettesA As System.Windows.Forms.TabPage
    Friend WithEvents nudVFactDeb As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudVFactFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkFourchVFact As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkFourchVRegl As System.Windows.Forms.CheckBox
    Friend WithEvents nudVReglFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudVReglDeb As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkFourchAFact As System.Windows.Forms.CheckBox
    Friend WithEvents nudAFactFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAFactDeb As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkFourchARegl As System.Windows.Forms.CheckBox
    Friend WithEvents nudAReglFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAReglDeb As System.Windows.Forms.NumericUpDown
    Friend WithEvents tpParam As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CbModeCompta As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxNomDossier As System.Windows.Forms.TextBox
    Friend WithEvents CbModeExport As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dgExercices As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TbNewDossier As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSupprDossier As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgJournal As System.Windows.Forms.DataGridView
    Friend WithEvents ColCodeJournal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJCompteContre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbNewJournal As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSupprJournal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgTVA As System.Windows.Forms.DataGridView
    Friend WithEvents TVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbNewTVA As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSupprTVA As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ColExpl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDtDebEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDtFinEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFiller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBoxRgpCptsPdtsExportVtes As System.Windows.Forms.CheckBox
    Friend WithEvents VFactureNumFactureAgrifactCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents VFactureRacineNumPieceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents VFactureComposerNumPieceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LimiterCptImportComptaCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DossiersBindingSource As System.Windows.Forms.BindingSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrParametreCompta))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtOk = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.VFactureRacineNumPieceTextBox = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.VFactureComposerNumPieceCheckBox = New System.Windows.Forms.CheckBox
        Me.VFactureNumFactureAgrifactCheckBox = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ChkFourchVFact = New System.Windows.Forms.CheckBox
        Me.nudVFactFin = New System.Windows.Forms.NumericUpDown
        Me.nudVFactDeb = New System.Windows.Forms.NumericUpDown
        Me.CbDossier = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CbRegimeTVA = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ChkFourchVRegl = New System.Windows.Forms.CheckBox
        Me.nudVReglFin = New System.Windows.Forms.NumericUpDown
        Me.nudVReglDeb = New System.Windows.Forms.NumericUpDown
        Me.BtCancel = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpParam = New System.Windows.Forms.TabPage
        Me.CheckBoxRgpCptsPdtsExportVtes = New System.Windows.Forms.CheckBox
        Me.CbModeExport = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxNomDossier = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CbModeCompta = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tpFourchettesV = New System.Windows.Forms.TabPage
        Me.tpFourchettesA = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChkFourchARegl = New System.Windows.Forms.CheckBox
        Me.nudAReglFin = New System.Windows.Forms.NumericUpDown
        Me.nudAReglDeb = New System.Windows.Forms.NumericUpDown
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ChkFourchAFact = New System.Windows.Forms.CheckBox
        Me.nudAFactFin = New System.Windows.Forms.NumericUpDown
        Me.nudAFactDeb = New System.Windows.Forms.NumericUpDown
        Me.tpExos = New System.Windows.Forms.TabPage
        Me.dgExercices = New System.Windows.Forms.DataGridView
        Me.DossiersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbNewDossier = New System.Windows.Forms.ToolStripButton
        Me.TbSupprDossier = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tpJournaux = New System.Windows.Forms.TabPage
        Me.dgJournal = New System.Windows.Forms.DataGridView
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.TbNewJournal = New System.Windows.Forms.ToolStripButton
        Me.TbSupprJournal = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.tpTVA = New System.Windows.Forms.TabPage
        Me.dgTVA = New System.Windows.Forms.DataGridView
        Me.TVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.TbNewTVA = New System.Windows.Forms.ToolStripButton
        Me.TbSupprTVA = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColExpl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDtDebEx = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDtFinEx = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFiller = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCodeJournal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJCompteContre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LimiterCptImportComptaCheckBox = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudVFactFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVFactDeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudVReglFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVReglDeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpParam.SuspendLayout()
        Me.tpFourchettesV.SuspendLayout()
        Me.tpFourchettesA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAReglFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAReglDeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudAFactFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAFactDeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpExos.SuspendLayout()
        CType(Me.dgExercices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tpJournaux.SuspendLayout()
        CType(Me.dgJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.tpTVA.SuspendLayout()
        CType(Me.dgTVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
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
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dossier:"
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.Location = New System.Drawing.Point(330, 10)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 3
        Me.BtOk.Text = "OK"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.VFactureRacineNumPieceTextBox)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.VFactureComposerNumPieceCheckBox)
        Me.GroupBox2.Controls.Add(Me.VFactureNumFactureAgrifactCheckBox)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.ChkFourchVFact)
        Me.GroupBox2.Controls.Add(Me.nudVFactFin)
        Me.GroupBox2.Controls.Add(Me.nudVFactDeb)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(474, 150)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Factures de Vente"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(254, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(194, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "+ derniers chiffres du numéro de facture"
        '
        'VFactureRacineNumPieceTextBox
        '
        Me.VFactureRacineNumPieceTextBox.Location = New System.Drawing.Point(221, 119)
        Me.VFactureRacineNumPieceTextBox.MaxLength = 2
        Me.VFactureRacineNumPieceTextBox.Name = "VFactureRacineNumPieceTextBox"
        Me.VFactureRacineNumPieceTextBox.Size = New System.Drawing.Size(27, 20)
        Me.VFactureRacineNumPieceTextBox.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(188, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Racine (2 positions max. numériques) :"
        '
        'VFactureComposerNumPieceCheckBox
        '
        Me.VFactureComposerNumPieceCheckBox.AutoSize = True
        Me.VFactureComposerNumPieceCheckBox.Location = New System.Drawing.Point(6, 96)
        Me.VFactureComposerNumPieceCheckBox.Name = "VFactureComposerNumPieceCheckBox"
        Me.VFactureComposerNumPieceCheckBox.Size = New System.Drawing.Size(271, 17)
        Me.VFactureComposerNumPieceCheckBox.TabIndex = 14
        Me.VFactureComposerNumPieceCheckBox.Text = "Composer le numéro de pièce (5 positions maximum)"
        Me.VFactureComposerNumPieceCheckBox.UseVisualStyleBackColor = True
        '
        'VFactureNumFactureAgrifactCheckBox
        '
        Me.VFactureNumFactureAgrifactCheckBox.AutoSize = True
        Me.VFactureNumFactureAgrifactCheckBox.Location = New System.Drawing.Point(6, 73)
        Me.VFactureNumFactureAgrifactCheckBox.Name = "VFactureNumFactureAgrifactCheckBox"
        Me.VFactureNumFactureAgrifactCheckBox.Size = New System.Drawing.Size(397, 17)
        Me.VFactureNumFactureAgrifactCheckBox.TabIndex = 13
        Me.VFactureNumFactureAgrifactCheckBox.Text = "Conserver les 5 derniers chiffres du numéro de facture pour le numéro de pièce"
        Me.VFactureNumFactureAgrifactCheckBox.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(218, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "et"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "afin de les conserver entre"
        '
        'ChkFourchVFact
        '
        Me.ChkFourchVFact.AutoSize = True
        Me.ChkFourchVFact.Location = New System.Drawing.Point(6, 19)
        Me.ChkFourchVFact.Name = "ChkFourchVFact"
        Me.ChkFourchVFact.Size = New System.Drawing.Size(242, 17)
        Me.ChkFourchVFact.TabIndex = 10
        Me.ChkFourchVFact.Text = "Modifier les n° de pièce des factures de vente"
        '
        'nudVFactFin
        '
        Me.nudVFactFin.Location = New System.Drawing.Point(240, 42)
        Me.nudVFactFin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudVFactFin.Name = "nudVFactFin"
        Me.nudVFactFin.Size = New System.Drawing.Size(56, 20)
        Me.nudVFactFin.TabIndex = 9
        Me.nudVFactFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudVFactFin.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'nudVFactDeb
        '
        Me.nudVFactDeb.Location = New System.Drawing.Point(156, 42)
        Me.nudVFactDeb.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudVFactDeb.Name = "nudVFactDeb"
        Me.nudVFactDeb.Size = New System.Drawing.Size(56, 20)
        Me.nudVFactDeb.TabIndex = 8
        Me.nudVFactDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudVFactDeb.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'CbDossier
        '
        Me.CbDossier.Location = New System.Drawing.Point(111, 69)
        Me.CbDossier.Name = "CbDossier"
        Me.CbDossier.Size = New System.Drawing.Size(176, 21)
        Me.CbDossier.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Régime TVA:"
        '
        'CbRegimeTVA
        '
        Me.CbRegimeTVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbRegimeTVA.Location = New System.Drawing.Point(111, 122)
        Me.CbRegimeTVA.Name = "CbRegimeTVA"
        Me.CbRegimeTVA.Size = New System.Drawing.Size(176, 21)
        Me.CbRegimeTVA.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ChkFourchVRegl)
        Me.GroupBox3.Controls.Add(Me.nudVReglFin)
        Me.GroupBox3.Controls.Add(Me.nudVReglDeb)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 170)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(474, 70)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Réglements de Vente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "et"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "afin de les conserver entre"
        '
        'ChkFourchVRegl
        '
        Me.ChkFourchVRegl.AutoSize = True
        Me.ChkFourchVRegl.Location = New System.Drawing.Point(6, 19)
        Me.ChkFourchVRegl.Name = "ChkFourchVRegl"
        Me.ChkFourchVRegl.Size = New System.Drawing.Size(255, 17)
        Me.ChkFourchVRegl.TabIndex = 15
        Me.ChkFourchVRegl.Text = "Modifier les n° de pièce des réglements de vente"
        '
        'nudVReglFin
        '
        Me.nudVReglFin.Location = New System.Drawing.Point(240, 42)
        Me.nudVReglFin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudVReglFin.Name = "nudVReglFin"
        Me.nudVReglFin.Size = New System.Drawing.Size(56, 20)
        Me.nudVReglFin.TabIndex = 14
        Me.nudVReglFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudVReglFin.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'nudVReglDeb
        '
        Me.nudVReglDeb.Location = New System.Drawing.Point(156, 42)
        Me.nudVReglDeb.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudVReglDeb.Name = "nudVReglDeb"
        Me.nudVReglDeb.Size = New System.Drawing.Size(56, 20)
        Me.nudVReglDeb.TabIndex = 13
        Me.nudVReglDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudVReglDeb.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(411, 10)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 8
        Me.BtCancel.Text = "Annuler"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpParam)
        Me.TabControl1.Controls.Add(Me.tpFourchettesV)
        Me.TabControl1.Controls.Add(Me.tpFourchettesA)
        Me.TabControl1.Controls.Add(Me.tpExos)
        Me.TabControl1.Controls.Add(Me.tpJournaux)
        Me.TabControl1.Controls.Add(Me.tpTVA)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(498, 269)
        Me.TabControl1.TabIndex = 9
        '
        'tpParam
        '
        Me.tpParam.Controls.Add(Me.LimiterCptImportComptaCheckBox)
        Me.tpParam.Controls.Add(Me.CheckBoxRgpCptsPdtsExportVtes)
        Me.tpParam.Controls.Add(Me.CbModeExport)
        Me.tpParam.Controls.Add(Me.Label13)
        Me.tpParam.Controls.Add(Me.TxNomDossier)
        Me.tpParam.Controls.Add(Me.Label10)
        Me.tpParam.Controls.Add(Me.CbModeCompta)
        Me.tpParam.Controls.Add(Me.Label9)
        Me.tpParam.Controls.Add(Me.Label1)
        Me.tpParam.Controls.Add(Me.CbDossier)
        Me.tpParam.Controls.Add(Me.Label3)
        Me.tpParam.Controls.Add(Me.CbRegimeTVA)
        Me.tpParam.Location = New System.Drawing.Point(4, 22)
        Me.tpParam.Name = "tpParam"
        Me.tpParam.Size = New System.Drawing.Size(490, 243)
        Me.tpParam.TabIndex = 5
        Me.tpParam.Text = "Paramètres"
        Me.tpParam.UseVisualStyleBackColor = True
        '
        'CheckBoxRgpCptsPdtsExportVtes
        '
        Me.CheckBoxRgpCptsPdtsExportVtes.AutoSize = True
        Me.CheckBoxRgpCptsPdtsExportVtes.Location = New System.Drawing.Point(11, 149)
        Me.CheckBoxRgpCptsPdtsExportVtes.Name = "CheckBoxRgpCptsPdtsExportVtes"
        Me.CheckBoxRgpCptsPdtsExportVtes.Size = New System.Drawing.Size(366, 17)
        Me.CheckBoxRgpCptsPdtsExportVtes.TabIndex = 16
        Me.CheckBoxRgpCptsPdtsExportVtes.Text = "Regrouper les comptes de produits lors de l'export des factures de vente"
        Me.CheckBoxRgpCptsPdtsExportVtes.UseVisualStyleBackColor = True
        '
        'CbModeExport
        '
        Me.CbModeExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbModeExport.Location = New System.Drawing.Point(111, 42)
        Me.CbModeExport.Name = "CbModeExport"
        Me.CbModeExport.Size = New System.Drawing.Size(176, 21)
        Me.CbModeExport.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Mode export :"
        '
        'TxNomDossier
        '
        Me.TxNomDossier.Location = New System.Drawing.Point(111, 96)
        Me.TxNomDossier.Name = "TxNomDossier"
        Me.TxNomDossier.Size = New System.Drawing.Size(240, 20)
        Me.TxNomDossier.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Nom du dossier:"
        '
        'CbModeCompta
        '
        Me.CbModeCompta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbModeCompta.Location = New System.Drawing.Point(111, 15)
        Me.CbModeCompta.Name = "CbModeCompta"
        Me.CbModeCompta.Size = New System.Drawing.Size(176, 21)
        Me.CbModeCompta.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Mode :"
        '
        'tpFourchettesV
        '
        Me.tpFourchettesV.Controls.Add(Me.GroupBox2)
        Me.tpFourchettesV.Controls.Add(Me.GroupBox3)
        Me.tpFourchettesV.Location = New System.Drawing.Point(4, 22)
        Me.tpFourchettesV.Name = "tpFourchettesV"
        Me.tpFourchettesV.Size = New System.Drawing.Size(490, 243)
        Me.tpFourchettesV.TabIndex = 0
        Me.tpFourchettesV.Text = "Fourchettes Vente"
        Me.tpFourchettesV.UseVisualStyleBackColor = True
        '
        'tpFourchettesA
        '
        Me.tpFourchettesA.Controls.Add(Me.GroupBox1)
        Me.tpFourchettesA.Controls.Add(Me.GroupBox5)
        Me.tpFourchettesA.Location = New System.Drawing.Point(4, 22)
        Me.tpFourchettesA.Name = "tpFourchettesA"
        Me.tpFourchettesA.Size = New System.Drawing.Size(490, 243)
        Me.tpFourchettesA.TabIndex = 4
        Me.tpFourchettesA.Text = "Fourchettes Achat"
        Me.tpFourchettesA.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ChkFourchARegl)
        Me.GroupBox1.Controls.Add(Me.nudAReglFin)
        Me.GroupBox1.Controls.Add(Me.nudAReglDeb)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 71)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Réglements d'Achat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "et"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "afin de les conserver entre"
        '
        'ChkFourchARegl
        '
        Me.ChkFourchARegl.AutoSize = True
        Me.ChkFourchARegl.Location = New System.Drawing.Point(6, 19)
        Me.ChkFourchARegl.Name = "ChkFourchARegl"
        Me.ChkFourchARegl.Size = New System.Drawing.Size(248, 17)
        Me.ChkFourchARegl.TabIndex = 10
        Me.ChkFourchARegl.Text = "Modifier les n° de pièce des réglements d'achat"
        '
        'nudAReglFin
        '
        Me.nudAReglFin.Location = New System.Drawing.Point(240, 42)
        Me.nudAReglFin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudAReglFin.Name = "nudAReglFin"
        Me.nudAReglFin.Size = New System.Drawing.Size(56, 20)
        Me.nudAReglFin.TabIndex = 9
        Me.nudAReglFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAReglFin.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'nudAReglDeb
        '
        Me.nudAReglDeb.Location = New System.Drawing.Point(156, 42)
        Me.nudAReglDeb.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudAReglDeb.Name = "nudAReglDeb"
        Me.nudAReglDeb.Size = New System.Drawing.Size(56, 20)
        Me.nudAReglDeb.TabIndex = 8
        Me.nudAReglDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAReglDeb.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.ChkFourchAFact)
        Me.GroupBox5.Controls.Add(Me.nudAFactFin)
        Me.GroupBox5.Controls.Add(Me.nudAFactDeb)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 14)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(320, 71)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Factures d'Achat"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "et"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "afin de les conserver entre"
        '
        'ChkFourchAFact
        '
        Me.ChkFourchAFact.AutoSize = True
        Me.ChkFourchAFact.Location = New System.Drawing.Point(6, 19)
        Me.ChkFourchAFact.Name = "ChkFourchAFact"
        Me.ChkFourchAFact.Size = New System.Drawing.Size(235, 17)
        Me.ChkFourchAFact.TabIndex = 10
        Me.ChkFourchAFact.Text = "Modifier les n° de pièce des factures d'achat"
        '
        'nudAFactFin
        '
        Me.nudAFactFin.Location = New System.Drawing.Point(240, 42)
        Me.nudAFactFin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudAFactFin.Name = "nudAFactFin"
        Me.nudAFactFin.Size = New System.Drawing.Size(56, 20)
        Me.nudAFactFin.TabIndex = 9
        Me.nudAFactFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAFactFin.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'nudAFactDeb
        '
        Me.nudAFactDeb.Location = New System.Drawing.Point(156, 42)
        Me.nudAFactDeb.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudAFactDeb.Name = "nudAFactDeb"
        Me.nudAFactDeb.Size = New System.Drawing.Size(56, 20)
        Me.nudAFactDeb.TabIndex = 8
        Me.nudAFactDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAFactDeb.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'tpExos
        '
        Me.tpExos.Controls.Add(Me.dgExercices)
        Me.tpExos.Controls.Add(Me.ToolStrip1)
        Me.tpExos.Location = New System.Drawing.Point(4, 22)
        Me.tpExos.Name = "tpExos"
        Me.tpExos.Size = New System.Drawing.Size(490, 243)
        Me.tpExos.TabIndex = 1
        Me.tpExos.Text = "Exercices"
        Me.tpExos.UseVisualStyleBackColor = True
        '
        'dgExercices
        '
        Me.dgExercices.AutoGenerateColumns = False
        Me.dgExercices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgExercices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColExpl, Me.ColDtDebEx, Me.ColDtFinEx, Me.ColFiller})
        Me.dgExercices.DataSource = Me.DossiersBindingSource
        Me.dgExercices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgExercices.Location = New System.Drawing.Point(0, 25)
        Me.dgExercices.Name = "dgExercices"
        Me.dgExercices.Size = New System.Drawing.Size(490, 218)
        Me.dgExercices.TabIndex = 1
        '
        'DossiersBindingSource
        '
        Me.DossiersBindingSource.DataMember = "Dossiers"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbNewDossier, Me.TbSupprDossier, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(490, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbNewDossier
        '
        Me.TbNewDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNewDossier.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNewDossier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNewDossier.Name = "TbNewDossier"
        Me.TbNewDossier.Size = New System.Drawing.Size(23, 22)
        Me.TbNewDossier.Text = "Nouvel exercice"
        '
        'TbSupprDossier
        '
        Me.TbSupprDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSupprDossier.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbSupprDossier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSupprDossier.Name = "TbSupprDossier"
        Me.TbSupprDossier.Size = New System.Drawing.Size(23, 22)
        Me.TbSupprDossier.Text = "Supprimer"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(172, 22)
        Me.ToolStripLabel1.Text = "Dates des exercices comptables"
        '
        'tpJournaux
        '
        Me.tpJournaux.Controls.Add(Me.dgJournal)
        Me.tpJournaux.Controls.Add(Me.ToolStrip2)
        Me.tpJournaux.Location = New System.Drawing.Point(4, 22)
        Me.tpJournaux.Name = "tpJournaux"
        Me.tpJournaux.Size = New System.Drawing.Size(490, 243)
        Me.tpJournaux.TabIndex = 2
        Me.tpJournaux.Text = "Journaux"
        Me.tpJournaux.UseVisualStyleBackColor = True
        '
        'dgJournal
        '
        Me.dgJournal.AutoGenerateColumns = False
        Me.dgJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgJournal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodeJournal, Me.ColJType, Me.ColJCompteContre, Me.ColJLibelle})
        Me.dgJournal.DataSource = Me.JournalBindingSource
        Me.dgJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgJournal.Location = New System.Drawing.Point(0, 25)
        Me.dgJournal.Name = "dgJournal"
        Me.dgJournal.Size = New System.Drawing.Size(490, 218)
        Me.dgJournal.TabIndex = 4
        '
        'JournalBindingSource
        '
        Me.JournalBindingSource.DataMember = "Journal"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbNewJournal, Me.TbSupprJournal, Me.ToolStripLabel2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(490, 25)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TbNewJournal
        '
        Me.TbNewJournal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNewJournal.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNewJournal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNewJournal.Name = "TbNewJournal"
        Me.TbNewJournal.Size = New System.Drawing.Size(23, 22)
        Me.TbNewJournal.Text = "Nouveau"
        '
        'TbSupprJournal
        '
        Me.TbSupprJournal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSupprJournal.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbSupprJournal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSupprJournal.Name = "TbSupprJournal"
        Me.TbSupprJournal.Size = New System.Drawing.Size(23, 22)
        Me.TbSupprJournal.Text = "Supprimer"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(166, 22)
        Me.ToolStripLabel2.Text = "Liste des journaux comptables"
        '
        'tpTVA
        '
        Me.tpTVA.Controls.Add(Me.dgTVA)
        Me.tpTVA.Controls.Add(Me.ToolStrip3)
        Me.tpTVA.Location = New System.Drawing.Point(4, 22)
        Me.tpTVA.Name = "tpTVA"
        Me.tpTVA.Size = New System.Drawing.Size(490, 243)
        Me.tpTVA.TabIndex = 3
        Me.tpTVA.Text = "TVA"
        Me.tpTVA.UseVisualStyleBackColor = True
        '
        'dgTVA
        '
        Me.dgTVA.AutoGenerateColumns = False
        Me.dgTVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTVA.DataSource = Me.TVABindingSource
        Me.dgTVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTVA.Location = New System.Drawing.Point(0, 25)
        Me.dgTVA.Name = "dgTVA"
        Me.dgTVA.Size = New System.Drawing.Size(490, 218)
        Me.dgTVA.TabIndex = 5
        '
        'TVABindingSource
        '
        Me.TVABindingSource.DataMember = "TVA"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbNewTVA, Me.TbSupprTVA, Me.ToolStripLabel3})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(490, 25)
        Me.ToolStrip3.TabIndex = 4
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'TbNewTVA
        '
        Me.TbNewTVA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNewTVA.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.TbNewTVA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNewTVA.Name = "TbNewTVA"
        Me.TbNewTVA.Size = New System.Drawing.Size(23, 22)
        Me.TbNewTVA.Text = "Nouveau"
        '
        'TbSupprTVA
        '
        Me.TbSupprTVA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSupprTVA.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.TbSupprTVA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSupprTVA.Name = "TbSupprTVA"
        Me.TbSupprTVA.Size = New System.Drawing.Size(23, 22)
        Me.TbSupprTVA.Text = "Supprimer"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripLabel3.Text = "Liste des codes TVA"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtOk)
        Me.GradientPanel2.Controls.Add(Me.BtCancel)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 269)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(498, 45)
        Me.GradientPanel2.TabIndex = 20
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Libelle"
        Me.DataGridTextBoxColumn9.MappingName = "TLibelle"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 180
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Compte"
        Me.DataGridTextBoxColumn11.MappingName = "TCpt"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.Width = 60
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = "#0.00 '%'"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Taux"
        Me.DataGridTextBoxColumn10.MappingName = "TTaux"
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "A/V"
        Me.DataGridTextBoxColumn13.MappingName = "TJournal"
        Me.DataGridTextBoxColumn13.Width = 30
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Type"
        Me.DataGridTextBoxColumn12.MappingName = "TypTVA"
        Me.DataGridTextBoxColumn12.Width = 40
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Code"
        Me.DataGridTextBoxColumn8.MappingName = "TTVA"
        Me.DataGridTextBoxColumn8.Width = 40
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DExpl"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Dossier"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 67
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DDtDebEx"
        DataGridViewCellStyle9.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "Début d'Ex."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 87
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DDtFinEx"
        DataGridViewCellStyle10.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fin d'Ex."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 72
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "JCodeJournal"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 57
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "JType"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 56
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "JCompteContre"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Contrepartie"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "JLibelle"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Libellé"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'ColExpl
        '
        Me.ColExpl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColExpl.DataPropertyName = "DExpl"
        Me.ColExpl.HeaderText = "Dossier"
        Me.ColExpl.Name = "ColExpl"
        Me.ColExpl.Width = 67
        '
        'ColDtDebEx
        '
        Me.ColDtDebEx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColDtDebEx.DataPropertyName = "DDtDebEx"
        DataGridViewCellStyle11.Format = "d"
        Me.ColDtDebEx.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColDtDebEx.HeaderText = "Début d'Ex."
        Me.ColDtDebEx.Name = "ColDtDebEx"
        Me.ColDtDebEx.Width = 87
        '
        'ColDtFinEx
        '
        Me.ColDtFinEx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColDtFinEx.DataPropertyName = "DDtFinEx"
        DataGridViewCellStyle12.Format = "d"
        Me.ColDtFinEx.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColDtFinEx.HeaderText = "Fin d'Ex."
        Me.ColDtFinEx.Name = "ColDtFinEx"
        Me.ColDtFinEx.Width = 72
        '
        'ColFiller
        '
        Me.ColFiller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColFiller.HeaderText = ""
        Me.ColFiller.Name = "ColFiller"
        Me.ColFiller.ReadOnly = True
        '
        'ColCodeJournal
        '
        Me.ColCodeJournal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColCodeJournal.DataPropertyName = "JCodeJournal"
        Me.ColCodeJournal.HeaderText = "Code"
        Me.ColCodeJournal.Name = "ColCodeJournal"
        Me.ColCodeJournal.Width = 57
        '
        'ColJType
        '
        Me.ColJType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColJType.DataPropertyName = "JType"
        Me.ColJType.HeaderText = "Type"
        Me.ColJType.Name = "ColJType"
        Me.ColJType.Width = 56
        '
        'ColJCompteContre
        '
        Me.ColJCompteContre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColJCompteContre.DataPropertyName = "JCompteContre"
        Me.ColJCompteContre.HeaderText = "Contrepartie"
        Me.ColJCompteContre.Name = "ColJCompteContre"
        Me.ColJCompteContre.Width = 89
        '
        'ColJLibelle
        '
        Me.ColJLibelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColJLibelle.DataPropertyName = "JLibelle"
        Me.ColJLibelle.HeaderText = "Libellé"
        Me.ColJLibelle.Name = "ColJLibelle"
        '
        'LimiterCptImportComptaCheckBox
        '
        Me.LimiterCptImportComptaCheckBox.AutoSize = True
        Me.LimiterCptImportComptaCheckBox.Location = New System.Drawing.Point(11, 172)
        Me.LimiterCptImportComptaCheckBox.Name = "LimiterCptImportComptaCheckBox"
        Me.LimiterCptImportComptaCheckBox.Size = New System.Drawing.Size(421, 17)
        Me.LimiterCptImportComptaCheckBox.TabIndex = 17
        Me.LimiterCptImportComptaCheckBox.Text = "Limiter le nombre de comptes importés depuis l'application de comptabilité (Agrig" & _
            "est²)"
        Me.LimiterCptImportComptaCheckBox.UseVisualStyleBackColor = True
        '
        'FrParametreCompta
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(498, 314)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParametreCompta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametres Compta"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudVFactFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVFactDeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudVReglFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVReglDeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpParam.ResumeLayout(False)
        Me.tpParam.PerformLayout()
        Me.tpFourchettesV.ResumeLayout(False)
        Me.tpFourchettesA.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAReglFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAReglDeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudAFactFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAFactDeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpExos.ResumeLayout(False)
        Me.tpExos.PerformLayout()
        CType(Me.dgExercices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tpJournaux.ResumeLayout(False)
        Me.tpJournaux.PerformLayout()
        CType(Me.dgJournal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpTVA.ResumeLayout(False)
        Me.tpTVA.PerformLayout()
        CType(Me.dgTVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FillCbModeExport()
        Dim selValue As Compta.ModesExport
        If CbModeExport.SelectedIndex >= 0 Then
            selValue = CType(CType(CbModeExport.SelectedItem, ListboxItem).Value, Compta.ModesExport)
        Else
            selValue = Compta.ModeExport
        End If
        With CbModeExport.Items
            .Clear()
            Select Case Compta.ModeCompta
                Case Compta.ModesCompta.Agrigest2 : .Add(New ListboxItem("Agrigest²", Compta.ModesExport.Agrigest2))
                Case Compta.ModesCompta.AgrigestEDI : .Add(New ListboxItem("AgrigestEDI", Compta.ModesExport.AgrigestEDI))
            End Select
            .Add(New ListboxItem("Isacompta", Compta.ModesExport.Isacompta))
            .Add(New ListboxItem("ISTEA", Compta.ModesExport.ISTEA))
            .Add(New ListboxItem("EPICEA", Compta.ModesExport.Epicea))
            .Add(New ListboxItem("Infovia/Vitisoft", Compta.ModesExport.Infovia))
            .Add(New ListboxItem("POMO", Compta.ModesExport.Pomo))
        End With
        For Each l As ListboxItem In Me.CbModeExport.Items
            If CType(l.Value, Compta.ModesExport) = selValue Then
                CbModeExport.SelectedItem = l
                Exit Sub
            End If
        Next
    End Sub

    Private Sub FrParametreCompta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.dgExercices, False)
        ApplyStyle(Me.dgJournal, False)
        ApplyStyle(Me.dgTVA, False)
        Me.dgExercices.AutoGenerateColumns = False
        Me.dgJournal.AutoGenerateColumns = False
        Me.dgTVA.AutoGenerateColumns = True
        Me.dgTVA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Compta.ResetCompta(False)
        Dim modes() As Compta.ModesCompta = Compta.DeterminerModeCompta()
        With CbModeCompta
            .Items.Clear()
            For Each m As Compta.ModesCompta In modes
                .Items.Add(m)
            Next
            .SelectedItem = Compta.ModeCompta
        End With

        FillCbModeExport()

        With Me.CbRegimeTVA.Items
            .Clear()
            .Add("TVA sur Facturation")
            .Add("TVA sur Encaissement")
        End With
        Me.CbRegimeTVA.SelectedIndex = CInt(IIf(Compta.TVAEncaissement, 1, 0))

        Me.CheckBoxRgpCptsPdtsExportVtes.Checked = Compta.RgpCptsPdtsExportVtes
        Me.LimiterCptImportComptaCheckBox.Checked = Compta.LimiterCptImportCompta
        Me.VFactureNumFactureAgrifactCheckBox.Checked = Compta.VFactureNumFactureAgrifact
        Me.VFactureComposerNumPieceCheckBox.Checked = Compta.VFactureComposerNumPiece
        Me.VFactureRacineNumPieceTextBox.Text = Compta.VFactureRacineNumPiece

        ChargerFourchettes()
    End Sub

    Private Sub CbModeCompta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbModeCompta.SelectedIndexChanged
        Compta.ModeCompta = CType(CbModeCompta.SelectedItem, Compta.ModesCompta)
        If Compta.ModeCompta <> Compta.ModesCompta.Deconnecte Then
            Me.ds = Nothing
            Dim dtDossiers As DataTable = Compta.ListerDossiers
            If Not dtDossiers Is Nothing Then
                With Me.CbDossier
                    .DataSource = dtDossiers
                    .ValueMember = "DDossier"
                    .DisplayMember = "DDossier"
                End With
            End If
            'Ne pas laisser la main sur les exercices, TVA et Journaux
            With Me.TabControl1.TabPages
                If .Contains(tpExos) Then .Remove(tpExos)
                If .Contains(tpJournaux) Then .Remove(tpJournaux)
                If .Contains(tpTVA) Then .Remove(tpTVA)
                Me.TabControl1.SelectedIndex = 0
            End With
            Me.TxNomDossier.Enabled = False
        Else
            Me.CbDossier.DataSource = Nothing
            'CHARGER LES DONNEES EXO,TVA et JOURNAUX
            Me.ds = New DataSet
            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(Me.ds, "Dossiers", s)
                DefinitionDonnees.Instance.Fill(Me.ds, "Journal", s)
                DefinitionDonnees.Instance.Fill(Me.ds, "TVA", s)
            End Using
            AddHandler Me.ds.Tables("Dossiers").RowChanged, AddressOf DossiersRowChanged
            Me.ds.Tables("Dossiers").Columns("DDossier").DefaultValue = ""

            Me.DossiersBindingSource.DataSource = Me.ds
            Me.JournalBindingSource.DataSource = Me.ds
            Me.TVABindingSource.DataSource = Me.ds

            'Redonner la main sur les exercices, TVA et Journaux
            With Me.TabControl1.TabPages
                If Not .Contains(tpExos) Then .Add(tpExos)
                If Not .Contains(tpJournaux) Then .Add(tpJournaux)
                If Not .Contains(tpTVA) Then .Add(tpTVA)
                Me.TabControl1.SelectedIndex = 0
            End With

            Me.TxNomDossier.Enabled = True
        End If
        Me.CbDossier.Text = Compta.NDossierCompta
        Me.TxNomDossier.Text = Compta.NomDossier
        FillCbModeExport()
    End Sub

    'Affecte automatiquement un nom de dossier à chaque exercice
    Private Sub DossiersRowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        If e.Action = DataRowAction.Add Or e.Action = DataRowAction.Change Then
            'Et remplir le code exploitation
            If e.Row.IsNull("DExpl") Then e.Row("DExpl") = Microsoft.VisualBasic.Left(Me.CbDossier.Text, 6)
            'Créer un code dossier qui va bien
            If Convert.ToString(e.Row("DDossier")) = "" Then
                Dim yrFin As Integer = CDate(e.Row("DDtFinEx")).Year Mod 2000
                Dim codeDossier As String = String.Format("{0}{1:00}", e.Row("DExpl"), yrFin)
                While Not e.Row.Table.Rows.Find(codeDossier) Is Nothing
                    yrFin += 1
                    codeDossier = String.Format("{0}{1:00}", e.Row("DExpl"), yrFin)
                End While
                e.Row("DDossier") = codeDossier
            End If
        End If
    End Sub

    Private Sub EnregistrerParametresCompta()
        'Mise à jour des paramètres dans la classe Compta
        Compta.NDossierCompta = Me.CbDossier.Text
        Compta.NomDossier = Me.TxNomDossier.Text
        Compta.TVAEncaissement = (Me.CbRegimeTVA.Text = "TVA sur Encaissement")
        If CbModeExport.SelectedIndex >= 0 Then
            Compta.ModeExport = CType(CType(CbModeExport.SelectedItem, ListboxItem).Value, Compta.ModesExport)
        End If

        Compta.RgpCptsPdtsExportVtes = Me.CheckBoxRgpCptsPdtsExportVtes.Checked
        Compta.LimiterCptImportCompta = Me.LimiterCptImportComptaCheckBox.Checked
        Compta.VFactureNumFactureAgrifact = Me.VFactureNumFactureAgrifactCheckBox.Checked
        Compta.VFactureComposerNumPiece = Me.VFactureComposerNumPieceCheckBox.Checked

        'Me.VFactureNumFactureAgrifactCheckBox_CheckedChanged(Nothing, Nothing)
        'Me.VFactureComposerNumPieceCheckBox_CheckedChanged(Nothing, Nothing)

        Compta.VFactureRacineNumPiece = Me.VFactureRacineNumPieceTextBox.Text

        Compta.ChkFourchVFact = Me.ChkFourchVFact.Checked

        EnregistrerFourchettes()
        EnregistrerDonneesBase()

        'Enregistrement dans le fichier parametres
        Compta.EnregistrerParametres()
    End Sub

    Private Sub EnregistrerDonneesBase()
        If Me.ds Is Nothing Then Exit Sub
        If Me.ds.HasChanges Then
            Using s As New SqlProxy
                s.UpdateTables(ds, New String() {"Dossiers", "Journal", "TVA"})
            End Using
        End If
    End Sub

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        EnregistrerParametresCompta()
        If Compta.ModeCompta <> Compta.ModesCompta.Deconnecte Then
            Compta.ChargerDonnees()
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#Region "Gestion des fourchettes"
    Private Sub ChargerFourchettes()
        'Fourchettes vente
        Me.nudVFactDeb.Value = FixValue(CInt(Compta.BlocNPieceDebutVFacture), nudVFactDeb)
        Me.nudVFactFin.Value = FixValue(CInt(Compta.BlocNPieceFinVFacture), nudVFactFin)
        'Me.ChkFourchVFact.Checked = Not (Me.nudVFactDeb.Value = 0 And Me.nudVFactFin.Value = 99999)
        Me.ChkFourchVFact.Checked = Compta.ChkFourchVFact
        ChkFourchVFact_CheckedChanged(Nothing, Nothing)
        Me.nudVReglDeb.Value = FixValue(CInt(Compta.BlocNPieceDebutVReglement), nudVReglDeb)
        Me.nudVReglFin.Value = FixValue(CInt(Compta.BlocNPieceFinVReglement), nudVReglFin)
        Me.ChkFourchVRegl.Checked = Not (Me.nudVReglDeb.Value = 0 And Me.nudVReglFin.Value = 99999)
        ChkFourchVRegl_CheckedChanged(Nothing, Nothing)

        'Fourchettes achat
        If Not FrApplication.Modules.ModuleAchat Then
            Me.TabControl1.TabPages.Remove(tpFourchettesA)
        Else
            Me.nudAFactDeb.Value = FixValue(CInt(Compta.BlocNPieceDebutAFacture), nudAFactDeb)
            Me.nudAFactFin.Value = FixValue(CInt(Compta.BlocNPieceFinAFacture), nudAFactFin)
            Me.ChkFourchAFact.Checked = Not (Me.nudAFactDeb.Value = 0 And Me.nudAFactFin.Value = 99999)
            ChkFourchAFact_CheckedChanged(Nothing, Nothing)
            Me.nudAReglDeb.Value = FixValue(CInt(Compta.BlocNPieceDebutAReglement), nudAReglDeb)
            Me.nudAReglFin.Value = FixValue(CInt(Compta.BlocNPieceFinAReglement), nudAReglFin)
            Me.ChkFourchARegl.Checked = Not (Me.nudAReglDeb.Value = 0 And Me.nudAReglFin.Value = 99999)
            ChkFourchARegl_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Function FixValue(ByVal value As Decimal, ByVal nud As NumericUpDown) As Decimal
        Return Math.Max(Math.Min(value, nud.Maximum), nud.Minimum)
    End Function

    Private Sub EnregistrerFourchettes()
        Compta.BlocNPieceDebutVFacture = Me.nudVFactDeb.Value.ToString
        Compta.BlocNPieceFinVFacture = Me.nudVFactFin.Value.ToString
        Compta.BlocNPieceDebutVReglement = Me.nudVReglDeb.Value.ToString
        Compta.BlocNPieceFinVReglement = Me.nudVReglFin.Value.ToString

        Compta.BlocNPieceDebutAFacture = Me.nudAFactDeb.Value.ToString
        Compta.BlocNPieceFinAFacture = Me.nudAFactFin.Value.ToString
        Compta.BlocNPieceDebutAReglement = Me.nudAReglDeb.Value.ToString
        Compta.BlocNPieceFinAReglement = Me.nudAReglFin.Value.ToString
    End Sub

    Private Sub ChkFourchVFact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourchVFact.CheckedChanged
        If Not ChkFourchVFact.Checked Then
            nudVFactDeb.Value = 0
            nudVFactDeb.Enabled = False
            nudVFactFin.Value = 99999
            nudVFactFin.Enabled = False
        Else
            nudVFactDeb.Enabled = True
            nudVFactFin.Enabled = True
            Me.VFactureNumFactureAgrifactCheckBox.Checked = False
            Me.VFactureComposerNumPieceCheckBox.Checked = False
            Me.VFactureRacineNumPieceTextBox.Text = String.Empty
            Me.VFactureRacineNumPieceTextBox.Enabled = False
        End If
    End Sub

    Private Sub VFactureNumFactureAgrifactCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VFactureNumFactureAgrifactCheckBox.CheckedChanged
        If Me.VFactureNumFactureAgrifactCheckBox.Checked Then
            Me.ChkFourchVFact.Checked = False
            nudVFactDeb.Value = 0
            nudVFactDeb.Enabled = False
            nudVFactFin.Value = 99999
            nudVFactFin.Enabled = False
            Me.VFactureComposerNumPieceCheckBox.Checked = False
            Me.VFactureRacineNumPieceTextBox.Text = String.Empty
            Me.VFactureRacineNumPieceTextBox.Enabled = False
        End If
    End Sub

    Private Sub VFactureComposerNumPieceCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VFactureComposerNumPieceCheckBox.CheckedChanged
        If Me.VFactureComposerNumPieceCheckBox.Checked Then
            Me.ChkFourchVFact.Checked = False
            nudVFactDeb.Value = 0
            nudVFactDeb.Enabled = False
            nudVFactFin.Value = 99999
            nudVFactFin.Enabled = False
            Me.VFactureNumFactureAgrifactCheckBox.Checked = False
            Me.VFactureRacineNumPieceTextBox.Enabled = True
        End If
    End Sub

    Private Sub ChkFourchVRegl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourchVRegl.CheckedChanged
        If Not ChkFourchVRegl.Checked Then
            nudVReglDeb.Value = 0
            nudVReglDeb.Enabled = False
            nudVReglFin.Value = 99999
            nudVReglFin.Enabled = False
        Else
            nudVReglDeb.Enabled = True
            nudVReglFin.Enabled = True
        End If
    End Sub

    Private Sub ChkFourchAFact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourchAFact.CheckedChanged
        If Not ChkFourchAFact.Checked Then
            nudAFactDeb.Value = 0
            nudAFactDeb.Enabled = False
            nudAFactFin.Value = 99999
            nudAFactFin.Enabled = False
        Else
            nudAFactDeb.Enabled = True
            nudAFactFin.Enabled = True
        End If
    End Sub

    Private Sub ChkFourchARegl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourchARegl.CheckedChanged
        If Not ChkFourchARegl.Checked Then
            nudAReglDeb.Value = 0
            nudAReglDeb.Enabled = False
            nudAReglFin.Value = 99999
            nudAReglFin.Enabled = False
        Else
            nudAReglDeb.Enabled = True
            nudAReglFin.Enabled = True
        End If
    End Sub
#End Region

    Private Sub CbDossier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDossier.SelectedIndexChanged
        If CbDossier.SelectedIndex >= 0 Then
            If CType(CbDossier.DataSource, DataTable).Columns.Contains("NomDossier") Then
                TxNomDossier.Text = Convert.ToString(CType(CbDossier.SelectedItem, DataRowView)("NomDossier"))
            End If
        End If
    End Sub

#Region "Toolbars"
    Private Sub TbNewDossier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewDossier.Click
        Me.DossiersBindingSource.AddNew()
    End Sub

    Private Sub TbSupprDossier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSupprDossier.Click
        Try
            Me.DossiersBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub TbNewJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewJournal.Click
        Me.JournalBindingSource.AddNew()
    End Sub

    Private Sub TbSupprJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSupprJournal.Click
        Try
            Me.JournalBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub TbNewTVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewTVA.Click
        Me.TVABindingSource.AddNew()
    End Sub

    Private Sub TbSupprTVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSupprTVA.Click
        Try
            Me.TVABindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub
#End Region

    Private Sub VFactureRacineTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VFactureRacineNumPieceTextBox.TextChanged
        If (Me.VFactureRacineNumPieceTextBox.Text.Length > 0) Then
            If Not (IsNumeric(Me.VFactureRacineNumPieceTextBox.Text)) Then
                MsgBox("La racine doit être une valeur numérique.", MsgBoxStyle.Exclamation, "")

                Me.VFactureRacineNumPieceTextBox.Text = String.Empty
            End If
        End If
    End Sub
End Class
