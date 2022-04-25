<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrBonCommande
    Inherits GRC.FrBase

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
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code. 
    Friend WithEvents ctxLigne As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DupliquerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PieceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PieceDetailBindingSource As System.Windows.Forms.BindingSource
    Friend Shadows WithEvents ds As System.Data.DataSet
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents PiecesDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgvPieceDetail As DataGridViewEnter
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImpressionDirecteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpressionRelanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbAfficheReglement As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GpFacturation As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents LbMarge As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TxCodeBarre As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TbRegler As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents AffecterUnAcompteavoirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CréanceIrrécouvrableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gcFacturation As GestionControles
    Friend WithEvents Taux As System.Windows.Forms.ColumnHeader
    Friend WithEvents MontantHT As System.Windows.Forms.ColumnHeader
    Friend WithEvents MontantTVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstTxTVA As System.Windows.Forms.ListView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrBonCommande))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"5,5%", "12 315,56 €", "2 315,24 €"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("19.6%")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LstTxTVA = New System.Windows.Forms.ListView
        Me.Taux = New System.Windows.Forms.ColumnHeader
        Me.MontantHT = New System.Windows.Forms.ColumnHeader
        Me.MontantTVA = New System.Windows.Forms.ColumnHeader
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprimer = New System.Windows.Forms.ToolStripSplitButton
        Me.ImpressionDirecteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImpressionRelanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbRegler = New System.Windows.Forms.ToolStripSplitButton
        Me.AffecterUnAcompteavoirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CréanceIrrécouvrableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbAfficheReglement = New System.Windows.Forms.ToolStripButton
        Me.LbMarge = New System.Windows.Forms.ToolStripLabel
        Me.TxCodeBarre = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.CreerLotToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.PrecedentToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SuivantToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GpFacturation = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GbEcheance = New System.Windows.Forms.GroupBox
        Me.gcEcheance = New AgriFact.GestionControles
        Me.gcFacturation = New AgriFact.GestionControles
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.PieceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PieceDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New System.Data.DataSet
        Me.ctxLigne = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DupliquerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PiecesDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.TVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption4 = New Ascend.Windows.Forms.GradientCaption
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LbMontantTTC = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LbMontantTVA = New System.Windows.Forms.Label
        Me.LbMontantHT = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvPieceDetail = New AgriFact.DataGridViewEnter
        Me.NDetailDevisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeProduitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBtCodeProduit = New System.Windows.Forms.DataGridViewButtonColumn
        Me.NLotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBtNLot = New System.Windows.Forms.DataGridViewButtonColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unite1DataGridViewTextBoxColumn = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.LibUnite1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unite2DataGridViewTextBoxColumn = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.LibUnite2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixUDataGridViewTextBoxColumn = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.RemiseDataGridViewTextBoxColumn = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.TTVADataGridViewTextBoxColumn = New GRC.DatagridViewComboboxColumnCustom
        Me.MontantLigneDataGridViewTextBoxColumn = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.PrixUTTC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrixUAchatHT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NCompte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NActivite = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatagridViewNumericTextBoxColumn1 = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatagridViewNumericTextBoxColumn2 = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatagridViewNumericTextBoxColumn3 = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.DatagridViewNumericTextBoxColumn4 = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DatagridViewNumericTextBoxColumn5 = New AgriFact.DatagridViewNumericTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GpFacturation.SuspendLayout()
        Me.GbEcheance.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PieceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PieceDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxLigne.SuspendLayout()
        CType(Me.PiecesDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvPieceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ImageList24.Images.SetKeyName(14, "")
        '
        'LstTxTVA
        '
        Me.LstTxTVA.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Taux, Me.MontantHT, Me.MontantTVA})
        Me.LstTxTVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstTxTVA.FullRowSelect = True
        Me.LstTxTVA.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.LstTxTVA.Location = New System.Drawing.Point(0, 24)
        Me.LstTxTVA.Name = "LstTxTVA"
        Me.LstTxTVA.Size = New System.Drawing.Size(274, 145)
        Me.LstTxTVA.TabIndex = 1
        Me.LstTxTVA.UseCompatibleStateImageBehavior = False
        Me.LstTxTVA.View = System.Windows.Forms.View.Details
        '
        'Taux
        '
        Me.Taux.Text = "Taux"
        Me.Taux.Width = 50
        '
        'MontantHT
        '
        Me.MontantHT.Text = "Base HT"
        Me.MontantHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MontantHT.Width = 70
        '
        'MontantTVA
        '
        Me.MontantTVA.Text = "Montant TVA"
        Me.MontantTVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MontantTVA.Width = 80
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.TbClose, Me.ToolStripSeparator1, Me.TbImprimer, Me.ToolStripSeparator2, Me.TbRegler, Me.TbAfficheReglement, Me.LbMarge, Me.TxCodeBarre, Me.ToolStripSeparator3, Me.CreerLotToolStripButton, Me.ToolStripSeparator4, Me.PrecedentToolStripButton, Me.SuivantToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = CType(resources.GetObject("TbSave.Image"), System.Drawing.Image)
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 36)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = CType(resources.GetObject("TbDelete.Image"), System.Drawing.Image)
        Me.TbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(27, 36)
        Me.TbDelete.Text = "Supprimer"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = CType(resources.GetObject("TbClose.Image"), System.Drawing.Image)
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 36)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'TbImprimer
        '
        Me.TbImprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImprimer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImpressionDirecteToolStripMenuItem, Me.ImpressionRelanceToolStripMenuItem})
        Me.TbImprimer.Image = CType(resources.GetObject("TbImprimer.Image"), System.Drawing.Image)
        Me.TbImprimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimer.Name = "TbImprimer"
        Me.TbImprimer.Size = New System.Drawing.Size(48, 36)
        Me.TbImprimer.Text = "Imprimer"
        '
        'ImpressionDirecteToolStripMenuItem
        '
        Me.ImpressionDirecteToolStripMenuItem.Name = "ImpressionDirecteToolStripMenuItem"
        Me.ImpressionDirecteToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ImpressionDirecteToolStripMenuItem.Text = "Impression directe..."
        '
        'ImpressionRelanceToolStripMenuItem
        '
        Me.ImpressionRelanceToolStripMenuItem.Name = "ImpressionRelanceToolStripMenuItem"
        Me.ImpressionRelanceToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ImpressionRelanceToolStripMenuItem.Text = "Impression relance..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'TbRegler
        '
        Me.TbRegler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbRegler.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AffecterUnAcompteavoirToolStripMenuItem, Me.CréanceIrrécouvrableToolStripMenuItem})
        Me.TbRegler.Image = CType(resources.GetObject("TbRegler.Image"), System.Drawing.Image)
        Me.TbRegler.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbRegler.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbRegler.Name = "TbRegler"
        Me.TbRegler.Size = New System.Drawing.Size(43, 36)
        Me.TbRegler.Text = "Régler"
        '
        'AffecterUnAcompteavoirToolStripMenuItem
        '
        Me.AffecterUnAcompteavoirToolStripMenuItem.Image = CType(resources.GetObject("AffecterUnAcompteavoirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AffecterUnAcompteavoirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AffecterUnAcompteavoirToolStripMenuItem.Name = "AffecterUnAcompteavoirToolStripMenuItem"
        Me.AffecterUnAcompteavoirToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AffecterUnAcompteavoirToolStripMenuItem.Text = "Affecter un acompte/avoir..."
        '
        'CréanceIrrécouvrableToolStripMenuItem
        '
        Me.CréanceIrrécouvrableToolStripMenuItem.Image = CType(resources.GetObject("CréanceIrrécouvrableToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CréanceIrrécouvrableToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CréanceIrrécouvrableToolStripMenuItem.Name = "CréanceIrrécouvrableToolStripMenuItem"
        Me.CréanceIrrécouvrableToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CréanceIrrécouvrableToolStripMenuItem.Text = "Créance irrécouvrable"
        '
        'TbAfficheReglement
        '
        Me.TbAfficheReglement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbAfficheReglement.Image = CType(resources.GetObject("TbAfficheReglement.Image"), System.Drawing.Image)
        Me.TbAfficheReglement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbAfficheReglement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbAfficheReglement.Name = "TbAfficheReglement"
        Me.TbAfficheReglement.Size = New System.Drawing.Size(36, 36)
        Me.TbAfficheReglement.Text = "Afficher le réglement"
        '
        'LbMarge
        '
        Me.LbMarge.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LbMarge.Name = "LbMarge"
        Me.LbMarge.Size = New System.Drawing.Size(54, 36)
        Me.LbMarge.Text = "LbMarge"
        '
        'TxCodeBarre
        '
        Me.TxCodeBarre.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TxCodeBarre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxCodeBarre.Name = "TxCodeBarre"
        Me.TxCodeBarre.Size = New System.Drawing.Size(100, 39)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'CreerLotToolStripButton
        '
        Me.CreerLotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CreerLotToolStripButton.Image = Global.AgriFact.My.Resources.Resources.Cube
        Me.CreerLotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CreerLotToolStripButton.Name = "CreerLotToolStripButton"
        Me.CreerLotToolStripButton.Size = New System.Drawing.Size(28, 36)
        Me.CreerLotToolStripButton.Text = "Créer un lot"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'PrecedentToolStripButton
        '
        Me.PrecedentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrecedentToolStripButton.Image = Global.AgriFact.My.Resources.Resources.prev24
        Me.PrecedentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrecedentToolStripButton.Name = "PrecedentToolStripButton"
        Me.PrecedentToolStripButton.Size = New System.Drawing.Size(28, 36)
        Me.PrecedentToolStripButton.Text = "Précédent"
        '
        'SuivantToolStripButton
        '
        Me.SuivantToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SuivantToolStripButton.Image = Global.AgriFact.My.Resources.Resources.next24
        Me.SuivantToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SuivantToolStripButton.Name = "SuivantToolStripButton"
        Me.SuivantToolStripButton.Size = New System.Drawing.Size(28, 36)
        Me.SuivantToolStripButton.Text = "Suivant"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GpFacturation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 261)
        Me.Panel1.TabIndex = 0
        '
        'GpFacturation
        '
        Me.GpFacturation.AutoScroll = True
        Me.GpFacturation.Border = New Ascend.Border(1)
        Me.GpFacturation.Controls.Add(Me.GradientCaption1)
        Me.GpFacturation.Controls.Add(Me.GbEcheance)
        Me.GpFacturation.Controls.Add(Me.gcFacturation)
        Me.GpFacturation.CornerRadius = New Ascend.CornerRadius(7)
        Me.GpFacturation.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GpFacturation.Location = New System.Drawing.Point(0, 0)
        Me.GpFacturation.Name = "GpFacturation"
        Me.GpFacturation.Size = New System.Drawing.Size(529, 211)
        Me.GpFacturation.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(529, 24)
        Me.GradientCaption1.TabIndex = 0
        '
        'GbEcheance
        '
        Me.GbEcheance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbEcheance.Controls.Add(Me.gcEcheance)
        Me.GbEcheance.Location = New System.Drawing.Point(324, 98)
        Me.GbEcheance.Name = "GbEcheance"
        Me.GbEcheance.Size = New System.Drawing.Size(202, 100)
        Me.GbEcheance.TabIndex = 2
        Me.GbEcheance.TabStop = False
        Me.GbEcheance.Text = "Echéance"
        '
        'gcEcheance
        '
        Me.gcEcheance.AutorisationListe = Nothing
        Me.gcEcheance.Autorisations = ""
        Me.gcEcheance.AutoriseAjt = True
        Me.gcEcheance.AutoriseModif = True
        Me.gcEcheance.AutoriseSuppr = True
        Me.gcEcheance.AutoSize = True
        Me.gcEcheance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcEcheance.BackColor = System.Drawing.Color.Transparent
        Me.gcEcheance.DataSource = Nothing
        Me.gcEcheance.DsBase = Nothing
        Me.gcEcheance.FiltreAffichage = ""
        Me.gcEcheance.Label1Top = 1
        Me.gcEcheance.LabelLeft = 1
        Me.gcEcheance.LargeurText = 100
        Me.gcEcheance.LiaisonDonnees = True
        Me.gcEcheance.Lien = Nothing
        Me.gcEcheance.LigneHauteur = 20
        Me.gcEcheance.LigneIntervale = 5
        Me.gcEcheance.Location = New System.Drawing.Point(6, 19)
        Me.gcEcheance.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcEcheance.Name = "gcEcheance"
        Me.gcEcheance.NomTableConfig = Nothing
        Me.gcEcheance.NuméroNiveau1 = 3
        Me.gcEcheance.Size = New System.Drawing.Size(190, 150)
        Me.gcEcheance.TabIndex = 0
        Me.gcEcheance.Table = "Devis"
        Me.gcEcheance.TableListeChoix = "ListeChoix"
        Me.gcEcheance.TableParam = "Niveau2"
        Me.gcEcheance.TexteLeft = 75
        Me.gcEcheance.TypeRecherche = False
        '
        'gcFacturation
        '
        Me.gcFacturation.AutorisationListe = Nothing
        Me.gcFacturation.Autorisations = ""
        Me.gcFacturation.AutoriseAjt = True
        Me.gcFacturation.AutoriseModif = True
        Me.gcFacturation.AutoriseSuppr = True
        Me.gcFacturation.AutoSize = True
        Me.gcFacturation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcFacturation.DataSource = Nothing
        Me.gcFacturation.DsBase = Nothing
        Me.gcFacturation.FiltreAffichage = ""
        Me.gcFacturation.Label1Top = 10
        Me.gcFacturation.LabelLeft = 1
        Me.gcFacturation.LargeurText = 250
        Me.gcFacturation.LiaisonDonnees = True
        Me.gcFacturation.Lien = Nothing
        Me.gcFacturation.LigneHauteur = 20
        Me.gcFacturation.LigneIntervale = 5
        Me.gcFacturation.Location = New System.Drawing.Point(0, 24)
        Me.gcFacturation.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcFacturation.Name = "gcFacturation"
        Me.gcFacturation.NomTableConfig = Nothing
        Me.gcFacturation.NuméroNiveau1 = 0
        Me.gcFacturation.Size = New System.Drawing.Size(529, 168)
        Me.gcFacturation.TabIndex = 1
        Me.gcFacturation.Table = "VDevis"
        Me.gcFacturation.TableListeChoix = "ListeChoix"
        Me.gcFacturation.TableParam = "Niveau2"
        Me.gcFacturation.TexteLeft = 115
        Me.gcFacturation.TypeRecherche = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LstTxTVA)
        Me.Panel2.Controls.Add(Me.GradientCaption2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel2.Size = New System.Drawing.Size(274, 174)
        Me.Panel2.TabIndex = 0
        '
        'GradientCaption2
        '
        Me.GradientCaption2.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption2.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption2.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption2.Name = "GradientCaption2"
        Me.GradientCaption2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption2.Size = New System.Drawing.Size(274, 24)
        Me.GradientCaption2.TabIndex = 0
        Me.GradientCaption2.Text = "Détail TVA"
        '
        'PieceBindingSource
        '
        '
        'ds
        '
        Me.ds.DataSetName = "NewDataSet"
        '
        'ctxLigne
        '
        Me.ctxLigne.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DupliquerToolStripMenuItem, Me.SupprimerToolStripMenuItem})
        Me.ctxLigne.Name = "ctxLigne"
        Me.ctxLigne.Size = New System.Drawing.Size(130, 48)
        '
        'DupliquerToolStripMenuItem
        '
        Me.DupliquerToolStripMenuItem.Image = CType(resources.GetObject("DupliquerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DupliquerToolStripMenuItem.Name = "DupliquerToolStripMenuItem"
        Me.DupliquerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DupliquerToolStripMenuItem.Text = "Dupliquer"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = CType(resources.GetObject("SupprimerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'PiecesDetailBindingSource
        '
        Me.PiecesDetailBindingSource.DataMember = "Pieces_Detail"
        Me.PiecesDetailBindingSource.DataSource = Me.DsPieces
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GradientPanel1)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 267)
        Me.SplitContainer1.SplitterDistance = 503
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.Controls.Add(Me.GradientCaption4)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.LbMontantTTC)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.LbMontantTVA)
        Me.GradientPanel1.Controls.Add(Me.LbMontantHT)
        Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 177)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(274, 87)
        Me.GradientPanel1.TabIndex = 1
        '
        'GradientCaption4
        '
        Me.GradientCaption4.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption4.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption4.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption4.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption4.Name = "GradientCaption4"
        Me.GradientCaption4.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption4.Size = New System.Drawing.Size(274, 24)
        Me.GradientCaption4.TabIndex = 0
        Me.GradientCaption4.Text = "Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Montant TTC :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Montant HT :"
        '
        'LbMontantTTC
        '
        Me.LbMontantTTC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbMontantTTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbMontantTTC.Location = New System.Drawing.Point(73, 59)
        Me.LbMontantTTC.Name = "LbMontantTTC"
        Me.LbMontantTTC.Size = New System.Drawing.Size(195, 13)
        Me.LbMontantTTC.TabIndex = 5
        Me.LbMontantTTC.Text = "MontantTtc"
        Me.LbMontantTTC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Montant TVA :"
        '
        'LbMontantTVA
        '
        Me.LbMontantTVA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbMontantTVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbMontantTVA.Location = New System.Drawing.Point(76, 43)
        Me.LbMontantTVA.Name = "LbMontantTVA"
        Me.LbMontantTVA.Size = New System.Drawing.Size(192, 16)
        Me.LbMontantTVA.TabIndex = 3
        Me.LbMontantTVA.Text = "MontantTva"
        Me.LbMontantTVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LbMontantHT
        '
        Me.LbMontantHT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbMontantHT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbMontantHT.Location = New System.Drawing.Point(76, 27)
        Me.LbMontantHT.Name = "LbMontantHT"
        Me.LbMontantHT.Size = New System.Drawing.Size(192, 16)
        Me.LbMontantHT.TabIndex = 1
        Me.LbMontantHT.Text = "MontantHT"
        Me.LbMontantHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvPieceDetail)
        Me.SplitContainer2.Size = New System.Drawing.Size(784, 535)
        Me.SplitContainer2.SplitterDistance = 267
        Me.SplitContainer2.TabIndex = 1
        '
        'dgvPieceDetail
        '
        Me.dgvPieceDetail.AutoGenerateColumns = False
        Me.dgvPieceDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPieceDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPieceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPieceDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NDetailDevisDataGridViewTextBoxColumn, Me.CodeProduitDataGridViewTextBoxColumn, Me.ColBtCodeProduit, Me.NLotDataGridViewTextBoxColumn, Me.ColBtNLot, Me.LibelleDataGridViewTextBoxColumn, Me.Unite1DataGridViewTextBoxColumn, Me.LibUnite1DataGridViewTextBoxColumn, Me.Unite2DataGridViewTextBoxColumn, Me.LibUnite2DataGridViewTextBoxColumn, Me.PrixUDataGridViewTextBoxColumn, Me.RemiseDataGridViewTextBoxColumn, Me.TTVADataGridViewTextBoxColumn, Me.MontantLigneDataGridViewTextBoxColumn, Me.PrixUTTC, Me.PrixUAchatHT, Me.NCompte, Me.NActivite})
        Me.dgvPieceDetail.ContextMenuStrip = Me.ctxLigne
        Me.dgvPieceDetail.DataSource = Me.PiecesDetailBindingSource
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPieceDetail.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPieceDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPieceDetail.Location = New System.Drawing.Point(0, 0)
        Me.dgvPieceDetail.MultiSelect = False
        Me.dgvPieceDetail.Name = "dgvPieceDetail"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPieceDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPieceDetail.RowHeadersWidth = 25
        Me.dgvPieceDetail.Size = New System.Drawing.Size(784, 264)
        Me.dgvPieceDetail.TabIndex = 0
        '
        'NDetailDevisDataGridViewTextBoxColumn
        '
        Me.NDetailDevisDataGridViewTextBoxColumn.DataPropertyName = "nDetailDevis"
        Me.NDetailDevisDataGridViewTextBoxColumn.HeaderText = "nDetailDevis"
        Me.NDetailDevisDataGridViewTextBoxColumn.Name = "NDetailDevisDataGridViewTextBoxColumn"
        Me.NDetailDevisDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NDetailDevisDataGridViewTextBoxColumn.Visible = False
        Me.NDetailDevisDataGridViewTextBoxColumn.Width = 190
        '
        'CodeProduitDataGridViewTextBoxColumn
        '
        Me.CodeProduitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeProduitDataGridViewTextBoxColumn.DataPropertyName = "CodeProduit"
        Me.CodeProduitDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.CodeProduitDataGridViewTextBoxColumn.Name = "CodeProduitDataGridViewTextBoxColumn"
        Me.CodeProduitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodeProduitDataGridViewTextBoxColumn.Width = 38
        '
        'ColBtCodeProduit
        '
        Me.ColBtCodeProduit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Wingdings 3", 9.0!)
        DataGridViewCellStyle2.NullValue = "€"
        Me.ColBtCodeProduit.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColBtCodeProduit.HeaderText = ""
        Me.ColBtCodeProduit.Name = "ColBtCodeProduit"
        Me.ColBtCodeProduit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColBtCodeProduit.Text = "€"
        Me.ColBtCodeProduit.ToolTipText = "Rechercher un produit"
        Me.ColBtCodeProduit.UseColumnTextForButtonValue = True
        Me.ColBtCodeProduit.Width = 20
        '
        'NLotDataGridViewTextBoxColumn
        '
        Me.NLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NLotDataGridViewTextBoxColumn.DataPropertyName = "NLot"
        Me.NLotDataGridViewTextBoxColumn.HeaderText = "NLot"
        Me.NLotDataGridViewTextBoxColumn.Name = "NLotDataGridViewTextBoxColumn"
        Me.NLotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NLotDataGridViewTextBoxColumn.Width = 36
        '
        'ColBtNLot
        '
        Me.ColBtNLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Wingdings 3", 9.0!)
        DataGridViewCellStyle3.NullValue = "€"
        Me.ColBtNLot.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColBtNLot.HeaderText = ""
        Me.ColBtNLot.Name = "ColBtNLot"
        Me.ColBtNLot.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColBtNLot.Text = "€"
        Me.ColBtNLot.ToolTipText = "Rechercher un Lot"
        Me.ColBtNLot.UseColumnTextForButtonValue = True
        Me.ColBtNLot.Width = 20
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LibelleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Unite1DataGridViewTextBoxColumn
        '
        Me.Unite1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Unite1DataGridViewTextBoxColumn.DataPropertyName = "Unite1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.Unite1DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.Unite1DataGridViewTextBoxColumn.HeaderText = "Unité 1"
        Me.Unite1DataGridViewTextBoxColumn.Name = "Unite1DataGridViewTextBoxColumn"
        Me.Unite1DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unite1DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Unite1DataGridViewTextBoxColumn.Width = 47
        '
        'LibUnite1DataGridViewTextBoxColumn
        '
        Me.LibUnite1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite1DataGridViewTextBoxColumn.DataPropertyName = "LibUnite1"
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LibUnite1DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.LibUnite1DataGridViewTextBoxColumn.HeaderText = ""
        Me.LibUnite1DataGridViewTextBoxColumn.Name = "LibUnite1DataGridViewTextBoxColumn"
        Me.LibUnite1DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite1DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LibUnite1DataGridViewTextBoxColumn.Width = 21
        '
        'Unite2DataGridViewTextBoxColumn
        '
        Me.Unite2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Unite2DataGridViewTextBoxColumn.DataPropertyName = "Unite2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        Me.Unite2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.Unite2DataGridViewTextBoxColumn.HeaderText = "Unité 2"
        Me.Unite2DataGridViewTextBoxColumn.Name = "Unite2DataGridViewTextBoxColumn"
        Me.Unite2DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unite2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Unite2DataGridViewTextBoxColumn.Width = 47
        '
        'LibUnite2DataGridViewTextBoxColumn
        '
        Me.LibUnite2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibUnite2DataGridViewTextBoxColumn.DataPropertyName = "LibUnite2"
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LibUnite2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.LibUnite2DataGridViewTextBoxColumn.HeaderText = ""
        Me.LibUnite2DataGridViewTextBoxColumn.Name = "LibUnite2DataGridViewTextBoxColumn"
        Me.LibUnite2DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LibUnite2DataGridViewTextBoxColumn.Width = 21
        '
        'PrixUDataGridViewTextBoxColumn
        '
        Me.PrixUDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixUDataGridViewTextBoxColumn.DataPropertyName = "PrixUHT"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C3"
        Me.PrixUDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.PrixUDataGridViewTextBoxColumn.HeaderText = "Prix U"
        Me.PrixUDataGridViewTextBoxColumn.Name = "PrixUDataGridViewTextBoxColumn"
        Me.PrixUDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrixUDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrixUDataGridViewTextBoxColumn.Width = 41
        '
        'RemiseDataGridViewTextBoxColumn
        '
        Me.RemiseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RemiseDataGridViewTextBoxColumn.DataPropertyName = "Remise"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "#0.00'%'"
        Me.RemiseDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.RemiseDataGridViewTextBoxColumn.HeaderText = "Remise"
        Me.RemiseDataGridViewTextBoxColumn.Name = "RemiseDataGridViewTextBoxColumn"
        Me.RemiseDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RemiseDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RemiseDataGridViewTextBoxColumn.Width = 48
        '
        'TTVADataGridViewTextBoxColumn
        '
        Me.TTVADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TTVADataGridViewTextBoxColumn.DataPropertyName = "TTVA"
        Me.TTVADataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.TTVADataGridViewTextBoxColumn.DisplayStyleForCurrentCellOnly = True
        Me.TTVADataGridViewTextBoxColumn.HeaderText = "TVA"
        Me.TTVADataGridViewTextBoxColumn.Name = "TTVADataGridViewTextBoxColumn"
        Me.TTVADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TTVADataGridViewTextBoxColumn.Width = 39
        '
        'MontantLigneDataGridViewTextBoxColumn
        '
        Me.MontantLigneDataGridViewTextBoxColumn.DataPropertyName = "MontantLigneHT"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.Format = "C2"
        Me.MontantLigneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.MontantLigneDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantLigneDataGridViewTextBoxColumn.Name = "MontantLigneDataGridViewTextBoxColumn"
        Me.MontantLigneDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantLigneDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MontantLigneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PrixUTTC
        '
        Me.PrixUTTC.DataPropertyName = "PrixUTTC"
        Me.PrixUTTC.HeaderText = "PrixUTTC"
        Me.PrixUTTC.Name = "PrixUTTC"
        Me.PrixUTTC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrixUTTC.Visible = False
        '
        'PrixUAchatHT
        '
        Me.PrixUAchatHT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixUAchatHT.DataPropertyName = "PrixUAchatHT"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.PrixUAchatHT.DefaultCellStyle = DataGridViewCellStyle12
        Me.PrixUAchatHT.HeaderText = "PUAHT"
        Me.PrixUAchatHT.Name = "PrixUAchatHT"
        Me.PrixUAchatHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrixUAchatHT.Width = 50
        '
        'NCompte
        '
        Me.NCompte.DataPropertyName = "NCompte"
        Me.NCompte.HeaderText = "NCompte"
        Me.NCompte.Name = "NCompte"
        Me.NCompte.Visible = False
        '
        'NActivite
        '
        Me.NActivite.DataPropertyName = "NActivite"
        Me.NActivite.HeaderText = "NActivite"
        Me.NActivite.Name = "NActivite"
        Me.NActivite.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nDetailDevis"
        Me.DataGridViewTextBoxColumn1.HeaderText = "nDetailDevis"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CodeProduit"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NLot"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NLot"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Libellé"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DatagridViewNumericTextBoxColumn1
        '
        Me.DatagridViewNumericTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DatagridViewNumericTextBoxColumn1.DataPropertyName = "Unite1"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N3"
        Me.DatagridViewNumericTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle15
        Me.DatagridViewNumericTextBoxColumn1.HeaderText = "Unité 1"
        Me.DatagridViewNumericTextBoxColumn1.Name = "DatagridViewNumericTextBoxColumn1"
        Me.DatagridViewNumericTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "LibUnite1"
        Me.DataGridViewTextBoxColumn5.HeaderText = ""
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DatagridViewNumericTextBoxColumn2
        '
        Me.DatagridViewNumericTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DatagridViewNumericTextBoxColumn2.DataPropertyName = "Unite2"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N3"
        Me.DatagridViewNumericTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle16
        Me.DatagridViewNumericTextBoxColumn2.HeaderText = "Unité 2"
        Me.DatagridViewNumericTextBoxColumn2.Name = "DatagridViewNumericTextBoxColumn2"
        Me.DatagridViewNumericTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "LibUnite2"
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DatagridViewNumericTextBoxColumn3
        '
        Me.DatagridViewNumericTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DatagridViewNumericTextBoxColumn3.DataPropertyName = "PrixUHT"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "C2"
        Me.DatagridViewNumericTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle17
        Me.DatagridViewNumericTextBoxColumn3.HeaderText = "Prix U"
        Me.DatagridViewNumericTextBoxColumn3.Name = "DatagridViewNumericTextBoxColumn3"
        Me.DatagridViewNumericTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DatagridViewNumericTextBoxColumn4
        '
        Me.DatagridViewNumericTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DatagridViewNumericTextBoxColumn4.DataPropertyName = "Remise"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "#0.00'%'"
        Me.DatagridViewNumericTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle18
        Me.DatagridViewNumericTextBoxColumn4.HeaderText = "Remise"
        Me.DatagridViewNumericTextBoxColumn4.Name = "DatagridViewNumericTextBoxColumn4"
        Me.DatagridViewNumericTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "TTVA"
        Me.DataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = True
        Me.DataGridViewComboBoxColumn1.HeaderText = "TVA"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DatagridViewNumericTextBoxColumn5
        '
        Me.DatagridViewNumericTextBoxColumn5.DataPropertyName = "MontantLigneHT"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.Format = "C2"
        Me.DatagridViewNumericTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle19
        Me.DatagridViewNumericTextBoxColumn5.HeaderText = "Montant"
        Me.DatagridViewNumericTextBoxColumn5.Name = "DatagridViewNumericTextBoxColumn5"
        Me.DatagridViewNumericTextBoxColumn5.ReadOnly = True
        Me.DatagridViewNumericTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PrixUTTC"
        Me.DataGridViewTextBoxColumn7.HeaderText = "PrixUTTC"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PrixUAchatHT"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PrixUAchatHT"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'FrBonCommande
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 574)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrBonCommande"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facture"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GpFacturation.ResumeLayout(False)
        Me.GpFacturation.PerformLayout()
        Me.GbEcheance.ResumeLayout(False)
        Me.GbEcheance.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PieceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PieceDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxLigne.ResumeLayout(False)
        CType(Me.PiecesDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvPieceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatagridViewNumericTextBoxColumn1 As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatagridViewNumericTextBoxColumn2 As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatagridViewNumericTextBoxColumn3 As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents DatagridViewNumericTextBoxColumn4 As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DatagridViewNumericTextBoxColumn5 As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption4 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LbMontantTTC As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LbMontantTVA As System.Windows.Forms.Label
    Friend WithEvents LbMontantHT As System.Windows.Forms.Label
    Friend WithEvents TVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GbEcheance As System.Windows.Forms.GroupBox
    Friend WithEvents gcEcheance As AgriFact.GestionControles
    Friend WithEvents CreerLotToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SuivantToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrecedentToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NDetailDevisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBtCodeProduit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents NLotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBtNLot As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unite1DataGridViewTextBoxColumn As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unite2DataGridViewTextBoxColumn As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents LibUnite2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixUDataGridViewTextBoxColumn As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents RemiseDataGridViewTextBoxColumn As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents TTVADataGridViewTextBoxColumn As GRC.DatagridViewComboboxColumnCustom
    Friend WithEvents MontantLigneDataGridViewTextBoxColumn As AgriFact.DatagridViewNumericTextBoxColumn
    Friend WithEvents PrixUTTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixUAchatHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NCompte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NActivite As System.Windows.Forms.DataGridViewTextBoxColumn

End Class