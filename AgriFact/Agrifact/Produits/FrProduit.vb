Imports System.Data.SqlClient

Public Class FrProduit
    Inherits GRC.FrBase

#Region "Ctor"
    'Public Sub New(ByRef data As DataSet)
    '    Me.New()
    '    ds = data
    'End Sub

    'Public Sub New(ByRef data As DataSet, ByVal nProduit As Object)
    '    Me.New(data)
    '    nProduitMove = nProduit
    'End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nProduit As Integer)
        Me.New()
        Me.id = nProduit
        Me.AjouterEnregistrement = False
    End Sub

    Public Sub New(ByVal CodeProduit As String)
        Me.New()
        Me.CodeProduitEnCours = CodeProduit
        Me.id = -1
        Me.AjouterEnregistrement = False
    End Sub
#End Region

#Region "Props"
    Private dsCompo As DataSet
    Private GestCompta As Compta
    Private Const NomLiaisonCompo As String = "ProduitCompositionProduit"
    Friend WithEvents tpStocks As System.Windows.Forms.TabPage
    Friend WithEvents StocksDatagridview As System.Windows.Forms.DataGridView
    Friend WithEvents StocksBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbDetailLots As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbMarquerTermine As System.Windows.Forms.ToolStripButton
    Friend WithEvents StocksDataSet As AgriFact.StocksDataSet
    Friend WithEvents EtatStockTA As AgriFact.StocksDataSetTableAdapters.EtatStockTA
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotTermine As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DepotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockActuelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockActuelU2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibUnite2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbMarquerNonTermine As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColCodeProduitComposition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBtSelectProd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLibU1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLibU2 As System.Windows.Forms.DataGridViewTextBoxColumn

    Public CodeProduitEnCours As String = ""

    Private ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.ProduitBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.ProduitBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nProduit() As String
        Get
            Return Convert.ToString(Me.CurrentDrv("nProduit"))
        End Get
    End Property
#End Region

#Region " Code généré par le Concepteur Windows Form "
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
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImprEt As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbMajBalance As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSaisiePrix As System.Windows.Forms.ToolStripButton
    Friend WithEvents CompositionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CompoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompoBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PtImage As System.Windows.Forms.PictureBox
    Friend WithEvents dlgImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuLigne As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuSupprimer As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LbCA As System.Windows.Forms.Label
    Friend WithEvents LbVolume As System.Windows.Forms.Label
    Friend WithEvents LbStockActuel As System.Windows.Forms.Label
    Friend WithEvents LbCmdClient As System.Windows.Forms.Label
    Friend WithEvents LbStockDispo As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Graphique2 As Actigram.Windows.Forms.Indicateurs.Graphique
    Friend WithEvents Graphique1 As Actigram.Windows.Forms.Indicateurs.Graphique
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtSupprImage As System.Windows.Forms.Button
    Friend WithEvents BtParcourir As System.Windows.Forms.Button
    Friend WithEvents gcProduit As AgriFact.GestionControles
    Friend WithEvents gcCompta As AgriFact.GestionControles
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpProduit As System.Windows.Forms.TabPage
    Friend WithEvents tpCompta As System.Windows.Forms.TabPage
    Friend WithEvents tpStats As System.Windows.Forms.TabPage
    Friend WithEvents tpImage As System.Windows.Forms.TabPage
    Friend WithEvents tpCompo As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrProduit))
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
        Me.MenuLigne = New System.Windows.Forms.ContextMenu
        Me.MenuSupprimer = New System.Windows.Forms.MenuItem
        Me.BtSupprImage = New System.Windows.Forms.Button
        Me.BtParcourir = New System.Windows.Forms.Button
        Me.PtImage = New System.Windows.Forms.PictureBox
        Me.dlgImage = New System.Windows.Forms.OpenFileDialog
        Me.Graphique2 = New Actigram.Windows.Forms.Indicateurs.Graphique
        Me.Graphique1 = New Actigram.Windows.Forms.Indicateurs.Graphique
        Me.LbStockDispo = New System.Windows.Forms.Label
        Me.LbCmdClient = New System.Windows.Forms.Label
        Me.LbStockActuel = New System.Windows.Forms.Label
        Me.LbVolume = New System.Windows.Forms.Label
        Me.LbCA = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpProduit = New System.Windows.Forms.TabPage
        Me.gcProduit = New AgriFact.GestionControles
        Me.tpCompta = New System.Windows.Forms.TabPage
        Me.tpStats = New System.Windows.Forms.TabPage
        Me.tpImage = New System.Windows.Forms.TabPage
        Me.tpCompo = New System.Windows.Forms.TabPage
        Me.CompositionDataGridView = New System.Windows.Forms.DataGridView
        Me.ColCodeProduitComposition = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBtSelectProd = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ColLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLibU1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLibU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CompoBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.tpStocks = New System.Windows.Forms.TabPage
        Me.StocksDatagridview = New System.Windows.Forms.DataGridView
        Me.NLotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotTermine = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DepotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockActuelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockActuelU2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibUnite2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StocksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.TbDetailLots = New System.Windows.Forms.ToolStripButton
        Me.tbMarquerTermine = New System.Windows.Forms.ToolStripButton
        Me.tbMarquerNonTermine = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprEt = New System.Windows.Forms.ToolStripButton
        Me.TbMajBalance = New System.Windows.Forms.ToolStripButton
        Me.TbSaisiePrix = New System.Windows.Forms.ToolStripButton
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtatStockTA = New AgriFact.StocksDataSetTableAdapters.EtatStockTA
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn
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
        Me.gcCompta = New AgriFact.GestionControles
        CType(Me.PtImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpProduit.SuspendLayout()
        Me.tpStats.SuspendLayout()
        Me.tpImage.SuspendLayout()
        Me.tpCompo.SuspendLayout()
        CType(Me.CompositionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompoBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CompoBindingNavigator.SuspendLayout()
        Me.tpStocks.SuspendLayout()
        CType(Me.StocksDatagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MenuLigne
        '
        Me.MenuLigne.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuSupprimer})
        '
        'MenuSupprimer
        '
        Me.MenuSupprimer.Index = 0
        Me.MenuSupprimer.Text = "Supprimer"
        '
        'BtSupprImage
        '
        Me.BtSupprImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSupprImage.Location = New System.Drawing.Point(320, 8)
        Me.BtSupprImage.Name = "BtSupprImage"
        Me.BtSupprImage.Size = New System.Drawing.Size(96, 24)
        Me.BtSupprImage.TabIndex = 2
        Me.BtSupprImage.Text = "Effacer l'image"
        '
        'BtParcourir
        '
        Me.BtParcourir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtParcourir.Location = New System.Drawing.Point(424, 8)
        Me.BtParcourir.Name = "BtParcourir"
        Me.BtParcourir.Size = New System.Drawing.Size(80, 24)
        Me.BtParcourir.TabIndex = 1
        Me.BtParcourir.Text = "Parcourir"
        '
        'PtImage
        '
        Me.PtImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PtImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PtImage.Location = New System.Drawing.Point(16, 40)
        Me.PtImage.Name = "PtImage"
        Me.PtImage.Size = New System.Drawing.Size(488, 511)
        Me.PtImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PtImage.TabIndex = 0
        Me.PtImage.TabStop = False
        '
        'Graphique2
        '
        Me.Graphique2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graphique2.EspaceLegendeX = 20
        Me.Graphique2.EspaceLegendeY = 35
        Me.Graphique2.GraphBackColor = System.Drawing.Color.White
        Me.Graphique2.IntervaleBarre = 10
        Me.Graphique2.IntervaleBarreIntraSerie = 10
        Me.Graphique2.LargeurBarre = 50
        Me.Graphique2.LegendeUnite = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Graphique2.LegendeXBackColor = System.Drawing.Color.White
        Me.Graphique2.LegendeYBackColor = System.Drawing.Color.White
        Me.Graphique2.Location = New System.Drawing.Point(248, 200)
        Me.Graphique2.Name = "Graphique2"
        Me.Graphique2.NbSerie = 1
        Me.Graphique2.RefreshAuto = True
        Me.Graphique2.Size = New System.Drawing.Size(256, 104)
        Me.Graphique2.TabIndex = 15
        Me.Graphique2.Text = "Graphique4"
        Me.Graphique2.ValeurMax = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Graphique2.ValeurMin = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Graphique1
        '
        Me.Graphique1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graphique1.EspaceLegendeX = 20
        Me.Graphique1.EspaceLegendeY = 35
        Me.Graphique1.GraphBackColor = System.Drawing.Color.White
        Me.Graphique1.IntervaleBarre = 10
        Me.Graphique1.IntervaleBarreIntraSerie = 10
        Me.Graphique1.LargeurBarre = 50
        Me.Graphique1.LegendeUnite = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Graphique1.LegendeXBackColor = System.Drawing.Color.White
        Me.Graphique1.LegendeYBackColor = System.Drawing.Color.White
        Me.Graphique1.Location = New System.Drawing.Point(248, 64)
        Me.Graphique1.Name = "Graphique1"
        Me.Graphique1.NbSerie = 1
        Me.Graphique1.RefreshAuto = True
        Me.Graphique1.Size = New System.Drawing.Size(256, 104)
        Me.Graphique1.TabIndex = 14
        Me.Graphique1.Text = "Graphique3"
        Me.Graphique1.ValeurMax = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Graphique1.ValeurMin = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'LbStockDispo
        '
        Me.LbStockDispo.Location = New System.Drawing.Point(16, 192)
        Me.LbStockDispo.Name = "LbStockDispo"
        Me.LbStockDispo.Size = New System.Drawing.Size(208, 23)
        Me.LbStockDispo.TabIndex = 13
        Me.LbStockDispo.Text = "Stock Dispo :"
        Me.LbStockDispo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbCmdClient
        '
        Me.LbCmdClient.Location = New System.Drawing.Point(16, 160)
        Me.LbCmdClient.Name = "LbCmdClient"
        Me.LbCmdClient.Size = New System.Drawing.Size(208, 23)
        Me.LbCmdClient.TabIndex = 12
        Me.LbCmdClient.Text = "Cmd Client :"
        Me.LbCmdClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbStockActuel
        '
        Me.LbStockActuel.Location = New System.Drawing.Point(16, 128)
        Me.LbStockActuel.Name = "LbStockActuel"
        Me.LbStockActuel.Size = New System.Drawing.Size(208, 23)
        Me.LbStockActuel.TabIndex = 10
        Me.LbStockActuel.Text = "Stock Actuel :"
        Me.LbStockActuel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbVolume
        '
        Me.LbVolume.Location = New System.Drawing.Point(16, 96)
        Me.LbVolume.Name = "LbVolume"
        Me.LbVolume.Size = New System.Drawing.Size(208, 23)
        Me.LbVolume.TabIndex = 9
        Me.LbVolume.Text = "Volume :"
        Me.LbVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbCA
        '
        Me.LbCA.Location = New System.Drawing.Point(16, 64)
        Me.LbCA.Name = "LbCA"
        Me.LbCA.Size = New System.Drawing.Size(208, 23)
        Me.LbCA.TabIndex = 8
        Me.LbCA.Text = "CA :"
        Me.LbCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(280, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(224, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Volume"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(280, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Chiffre d'affaire"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpProduit)
        Me.TabControl1.Controls.Add(Me.tpCompta)
        Me.TabControl1.Controls.Add(Me.tpStats)
        Me.TabControl1.Controls.Add(Me.tpImage)
        Me.TabControl1.Controls.Add(Me.tpCompo)
        Me.TabControl1.Controls.Add(Me.tpStocks)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 39)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(520, 591)
        Me.TabControl1.TabIndex = 21
        '
        'tpProduit
        '
        Me.tpProduit.Controls.Add(Me.gcProduit)
        Me.tpProduit.Location = New System.Drawing.Point(4, 22)
        Me.tpProduit.Name = "tpProduit"
        Me.tpProduit.Size = New System.Drawing.Size(512, 565)
        Me.tpProduit.TabIndex = 0
        Me.tpProduit.Text = "Général"
        Me.tpProduit.UseVisualStyleBackColor = True
        '
        'gcProduit
        '
        Me.gcProduit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcProduit.AutorisationListe = Nothing
        Me.gcProduit.Autorisations = ""
        Me.gcProduit.AutoriseAjt = True
        Me.gcProduit.AutoriseModif = True
        Me.gcProduit.AutoriseSuppr = True
        Me.gcProduit.AutoScroll = True
        Me.gcProduit.AutoSize = True
        Me.gcProduit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcProduit.DataSource = Nothing
        Me.gcProduit.DsBase = Nothing
        Me.gcProduit.FiltreAffichage = ""
        Me.gcProduit.Label1Top = 10
        Me.gcProduit.LabelLeft = 10
        Me.gcProduit.LargeurText = 250
        Me.gcProduit.LiaisonDonnees = True
        Me.gcProduit.Lien = Nothing
        Me.gcProduit.LigneHauteur = 20
        Me.gcProduit.LigneIntervale = 5
        Me.gcProduit.Location = New System.Drawing.Point(0, 0)
        Me.gcProduit.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcProduit.Name = "gcProduit"
        Me.gcProduit.NomTableConfig = Nothing
        Me.gcProduit.NuméroNiveau1 = 0
        Me.gcProduit.Size = New System.Drawing.Size(512, 565)
        Me.gcProduit.TabIndex = 7
        Me.gcProduit.Table = "Produit"
        Me.gcProduit.TableListeChoix = "ListeChoix"
        Me.gcProduit.TableParam = "Niveau2"
        Me.gcProduit.TexteLeft = 115
        Me.gcProduit.TypeRecherche = False
        '
        'tpCompta
        '
        Me.tpCompta.Location = New System.Drawing.Point(4, 22)
        Me.tpCompta.Name = "tpCompta"
        Me.tpCompta.Size = New System.Drawing.Size(512, 565)
        Me.tpCompta.TabIndex = 1
        Me.tpCompta.Text = "Compta"
        Me.tpCompta.UseVisualStyleBackColor = True
        '
        'tpStats
        '
        Me.tpStats.Controls.Add(Me.LbVolume)
        Me.tpStats.Controls.Add(Me.LbCA)
        Me.tpStats.Controls.Add(Me.Label2)
        Me.tpStats.Controls.Add(Me.LbStockActuel)
        Me.tpStats.Controls.Add(Me.Label1)
        Me.tpStats.Controls.Add(Me.LbCmdClient)
        Me.tpStats.Controls.Add(Me.LbStockDispo)
        Me.tpStats.Controls.Add(Me.Graphique2)
        Me.tpStats.Controls.Add(Me.Graphique1)
        Me.tpStats.Location = New System.Drawing.Point(4, 22)
        Me.tpStats.Name = "tpStats"
        Me.tpStats.Size = New System.Drawing.Size(512, 565)
        Me.tpStats.TabIndex = 2
        Me.tpStats.Text = "Statistiques"
        Me.tpStats.UseVisualStyleBackColor = True
        '
        'tpImage
        '
        Me.tpImage.Controls.Add(Me.PtImage)
        Me.tpImage.Controls.Add(Me.BtSupprImage)
        Me.tpImage.Controls.Add(Me.BtParcourir)
        Me.tpImage.Location = New System.Drawing.Point(4, 22)
        Me.tpImage.Name = "tpImage"
        Me.tpImage.Size = New System.Drawing.Size(512, 565)
        Me.tpImage.TabIndex = 4
        Me.tpImage.Text = "Image"
        Me.tpImage.UseVisualStyleBackColor = True
        '
        'tpCompo
        '
        Me.tpCompo.Controls.Add(Me.CompositionDataGridView)
        Me.tpCompo.Controls.Add(Me.CompoBindingNavigator)
        Me.tpCompo.Location = New System.Drawing.Point(4, 22)
        Me.tpCompo.Name = "tpCompo"
        Me.tpCompo.Size = New System.Drawing.Size(512, 565)
        Me.tpCompo.TabIndex = 5
        Me.tpCompo.Text = "Composition"
        Me.tpCompo.UseVisualStyleBackColor = True
        '
        'CompositionDataGridView
        '
        Me.CompositionDataGridView.AutoGenerateColumns = False
        Me.CompositionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CompositionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodeProduitComposition, Me.ColBtSelectProd, Me.ColLibelle, Me.ColUnite1, Me.ColLibU1, Me.ColUnite2, Me.ColLibU2})
        Me.CompositionDataGridView.DataSource = Me.CompoBindingSource
        Me.CompositionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.CompositionDataGridView.Name = "CompositionDataGridView"
        Me.CompositionDataGridView.Size = New System.Drawing.Size(512, 540)
        Me.CompositionDataGridView.TabIndex = 36
        '
        'ColCodeProduitComposition
        '
        Me.ColCodeProduitComposition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColCodeProduitComposition.DataPropertyName = "CodeProduitComposition"
        Me.ColCodeProduitComposition.HeaderText = "Code"
        Me.ColCodeProduitComposition.Name = "ColCodeProduitComposition"
        Me.ColCodeProduitComposition.Width = 57
        '
        'ColBtSelectProd
        '
        Me.ColBtSelectProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 3", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle1.NullValue = "€"
        Me.ColBtSelectProd.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColBtSelectProd.HeaderText = ""
        Me.ColBtSelectProd.Name = "ColBtSelectProd"
        Me.ColBtSelectProd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColBtSelectProd.Text = "€"
        Me.ColBtSelectProd.ToolTipText = "Sélectionner un produit"
        Me.ColBtSelectProd.UseColumnTextForButtonValue = True
        Me.ColBtSelectProd.Width = 20
        '
        'ColLibelle
        '
        Me.ColLibelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColLibelle.DataPropertyName = "Libelle"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColLibelle.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColLibelle.HeaderText = "Libelle"
        Me.ColLibelle.Name = "ColLibelle"
        '
        'ColUnite1
        '
        Me.ColUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColUnite1.DataPropertyName = "Unite1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N3"
        Me.ColUnite1.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColUnite1.HeaderText = "Unité 1"
        Me.ColUnite1.Name = "ColUnite1"
        Me.ColUnite1.Width = 66
        '
        'ColLibU1
        '
        Me.ColLibU1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColLibU1.DataPropertyName = "LibUnite1"
        Me.ColLibU1.HeaderText = ""
        Me.ColLibU1.Name = "ColLibU1"
        Me.ColLibU1.ReadOnly = True
        Me.ColLibU1.Width = 21
        '
        'ColUnite2
        '
        Me.ColUnite2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColUnite2.DataPropertyName = "Unite2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        Me.ColUnite2.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColUnite2.HeaderText = "Unité 2"
        Me.ColUnite2.Name = "ColUnite2"
        Me.ColUnite2.Width = 66
        '
        'ColLibU2
        '
        Me.ColLibU2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColLibU2.DataPropertyName = "LibUnite2"
        Me.ColLibU2.HeaderText = ""
        Me.ColLibU2.Name = "ColLibU2"
        Me.ColLibU2.ReadOnly = True
        Me.ColLibU2.Width = 21
        '
        'CompoBindingNavigator
        '
        Me.CompoBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CompoBindingNavigator.BindingSource = Me.CompoBindingSource
        Me.CompoBindingNavigator.CountItem = Nothing
        Me.CompoBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CompoBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.CompoBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.CompoBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CompoBindingNavigator.MoveFirstItem = Nothing
        Me.CompoBindingNavigator.MoveLastItem = Nothing
        Me.CompoBindingNavigator.MoveNextItem = Nothing
        Me.CompoBindingNavigator.MovePreviousItem = Nothing
        Me.CompoBindingNavigator.Name = "CompoBindingNavigator"
        Me.CompoBindingNavigator.PositionItem = Nothing
        Me.CompoBindingNavigator.Size = New System.Drawing.Size(512, 25)
        Me.CompoBindingNavigator.TabIndex = 37
        Me.CompoBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'tpStocks
        '
        Me.tpStocks.Controls.Add(Me.StocksDatagridview)
        Me.tpStocks.Controls.Add(Me.ToolStrip2)
        Me.tpStocks.Location = New System.Drawing.Point(4, 22)
        Me.tpStocks.Name = "tpStocks"
        Me.tpStocks.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStocks.Size = New System.Drawing.Size(512, 565)
        Me.tpStocks.TabIndex = 6
        Me.tpStocks.Text = "Stocks"
        Me.tpStocks.UseVisualStyleBackColor = True
        '
        'StocksDatagridview
        '
        Me.StocksDatagridview.AllowUserToAddRows = False
        Me.StocksDatagridview.AllowUserToDeleteRows = False
        Me.StocksDatagridview.AutoGenerateColumns = False
        Me.StocksDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StocksDatagridview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NLotDataGridViewTextBoxColumn, Me.LotTermine, Me.DepotDataGridViewTextBoxColumn, Me.StockActuelDataGridViewTextBoxColumn, Me.LibUnite1DataGridViewTextBoxColumn, Me.StockActuelU2DataGridViewTextBoxColumn, Me.LibUnite2DataGridViewTextBoxColumn})
        Me.StocksDatagridview.DataSource = Me.StocksBindingSource
        Me.StocksDatagridview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StocksDatagridview.Location = New System.Drawing.Point(3, 3)
        Me.StocksDatagridview.Name = "StocksDatagridview"
        Me.StocksDatagridview.ReadOnly = True
        Me.StocksDatagridview.Size = New System.Drawing.Size(506, 559)
        Me.StocksDatagridview.TabIndex = 1
        '
        'NLotDataGridViewTextBoxColumn
        '
        Me.NLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NLotDataGridViewTextBoxColumn.DataPropertyName = "nLot"
        Me.NLotDataGridViewTextBoxColumn.HeaderText = "Lot"
        Me.NLotDataGridViewTextBoxColumn.Name = "NLotDataGridViewTextBoxColumn"
        Me.NLotDataGridViewTextBoxColumn.ReadOnly = True
        Me.NLotDataGridViewTextBoxColumn.Width = 47
        '
        'LotTermine
        '
        Me.LotTermine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LotTermine.DataPropertyName = "LotTermine"
        Me.LotTermine.HeaderText = "Terminé"
        Me.LotTermine.Name = "LotTermine"
        Me.LotTermine.ReadOnly = True
        Me.LotTermine.Width = 51
        '
        'DepotDataGridViewTextBoxColumn
        '
        Me.DepotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DepotDataGridViewTextBoxColumn.DataPropertyName = "Depot"
        Me.DepotDataGridViewTextBoxColumn.HeaderText = "Dépot"
        Me.DepotDataGridViewTextBoxColumn.Name = "DepotDataGridViewTextBoxColumn"
        Me.DepotDataGridViewTextBoxColumn.ReadOnly = True
        Me.DepotDataGridViewTextBoxColumn.Width = 61
        '
        'StockActuelDataGridViewTextBoxColumn
        '
        Me.StockActuelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StockActuelDataGridViewTextBoxColumn.DataPropertyName = "StockActuel"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.StockActuelDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.StockActuelDataGridViewTextBoxColumn.HeaderText = "En stock"
        Me.StockActuelDataGridViewTextBoxColumn.Name = "StockActuelDataGridViewTextBoxColumn"
        Me.StockActuelDataGridViewTextBoxColumn.ReadOnly = True
        Me.StockActuelDataGridViewTextBoxColumn.Width = 74
        '
        'LibUnite1DataGridViewTextBoxColumn
        '
        Me.LibUnite1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.LibUnite1DataGridViewTextBoxColumn.DataPropertyName = "LibUnite1"
        Me.LibUnite1DataGridViewTextBoxColumn.HeaderText = ""
        Me.LibUnite1DataGridViewTextBoxColumn.Name = "LibUnite1DataGridViewTextBoxColumn"
        Me.LibUnite1DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite1DataGridViewTextBoxColumn.Width = 20
        '
        'StockActuelU2DataGridViewTextBoxColumn
        '
        Me.StockActuelU2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StockActuelU2DataGridViewTextBoxColumn.DataPropertyName = "StockActuelU2"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N3"
        Me.StockActuelU2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.StockActuelU2DataGridViewTextBoxColumn.HeaderText = "En stock"
        Me.StockActuelU2DataGridViewTextBoxColumn.Name = "StockActuelU2DataGridViewTextBoxColumn"
        Me.StockActuelU2DataGridViewTextBoxColumn.ReadOnly = True
        Me.StockActuelU2DataGridViewTextBoxColumn.Width = 74
        '
        'LibUnite2DataGridViewTextBoxColumn
        '
        Me.LibUnite2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.LibUnite2DataGridViewTextBoxColumn.DataPropertyName = "LibUnite2"
        Me.LibUnite2DataGridViewTextBoxColumn.HeaderText = ""
        Me.LibUnite2DataGridViewTextBoxColumn.Name = "LibUnite2DataGridViewTextBoxColumn"
        Me.LibUnite2DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite2DataGridViewTextBoxColumn.Width = 20
        '
        'StocksBindingSource
        '
        Me.StocksBindingSource.DataMember = "EtatStock"
        Me.StocksBindingSource.DataSource = Me.StocksDataSet
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbDetailLots, Me.tbMarquerTermine, Me.tbMarquerNonTermine})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        Me.ToolStrip2.Visible = False
        '
        'TbDetailLots
        '
        Me.TbDetailLots.CheckOnClick = True
        Me.TbDetailLots.Image = Global.AgriFact.My.Resources.Resources.liste
        Me.TbDetailLots.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDetailLots.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDetailLots.Name = "TbDetailLots"
        Me.TbDetailLots.Size = New System.Drawing.Size(100, 22)
        Me.TbDetailLots.Text = "Détail des lots"
        '
        'tbMarquerTermine
        '
        Me.tbMarquerTermine.Image = Global.AgriFact.My.Resources.Resources.bloque
        Me.tbMarquerTermine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbMarquerTermine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbMarquerTermine.Name = "tbMarquerTermine"
        Me.tbMarquerTermine.Size = New System.Drawing.Size(116, 22)
        Me.tbMarquerTermine.Text = "Marquer terminé"
        '
        'tbMarquerNonTermine
        '
        Me.tbMarquerNonTermine.Image = Global.AgriFact.My.Resources.Resources.check
        Me.tbMarquerNonTermine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbMarquerNonTermine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbMarquerNonTermine.Name = "tbMarquerNonTermine"
        Me.tbMarquerNonTermine.Size = New System.Drawing.Size(137, 22)
        Me.tbMarquerNonTermine.Text = "Marquer non terminé"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbClose, Me.TbSave, Me.TbSuppr, Me.ToolStripSeparator1, Me.TbImprEt, Me.TbMajBalance, Me.TbSaisiePrix})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(520, 39)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 36)
        Me.TbClose.Text = "Fermer"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save24
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 36)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbSuppr
        '
        Me.TbSuppr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSuppr.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbSuppr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSuppr.Name = "TbSuppr"
        Me.TbSuppr.Size = New System.Drawing.Size(27, 36)
        Me.TbSuppr.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'TbImprEt
        '
        Me.TbImprEt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImprEt.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprEt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprEt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprEt.Name = "TbImprEt"
        Me.TbImprEt.Size = New System.Drawing.Size(36, 36)
        Me.TbImprEt.Text = "Imprimer étiquettes"
        '
        'TbMajBalance
        '
        Me.TbMajBalance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbMajBalance.Image = Global.AgriFact.My.Resources.Resources.Compta
        Me.TbMajBalance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbMajBalance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMajBalance.Name = "TbMajBalance"
        Me.TbMajBalance.Size = New System.Drawing.Size(31, 36)
        Me.TbMajBalance.Text = "Envoi Balance"
        '
        'TbSaisiePrix
        '
        Me.TbSaisiePrix.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSaisiePrix.Image = Global.AgriFact.My.Resources.Resources.Finance
        Me.TbSaisiePrix.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSaisiePrix.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSaisiePrix.Name = "TbSaisiePrix"
        Me.TbSaisiePrix.Size = New System.Drawing.Size(31, 36)
        Me.TbSaisiePrix.Text = "Saisir les prix"
        '
        'EtatStockTA
        '
        Me.EtatStockTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CodeProduitComposition"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Wingdings 3", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle7.NullValue = "€"
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn1.Text = "€"
        Me.DataGridViewButtonColumn1.ToolTipText = "Sélectionner un produit"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Width = 20
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Unite1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N3"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unité 1"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LibUnite1"
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N3"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unité 2"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "LibUnite2"
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Depot"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Dépot"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "nLot"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Lot"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "StockActuel"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N3"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn9.HeaderText = "En stock"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "LibUnite1"
        Me.DataGridViewTextBoxColumn10.HeaderText = ""
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 20
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "StockActuelU2"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N3"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn11.HeaderText = "En stock"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "LibUnite2"
        Me.DataGridViewTextBoxColumn12.HeaderText = ""
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 20
        '
        'gcCompta
        '
        Me.gcCompta.AutorisationListe = Nothing
        Me.gcCompta.Autorisations = ""
        Me.gcCompta.AutoriseAjt = True
        Me.gcCompta.AutoriseModif = True
        Me.gcCompta.AutoriseSuppr = True
        Me.gcCompta.AutoScroll = True
        Me.gcCompta.AutoSize = True
        Me.gcCompta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcCompta.DataSource = Nothing
        Me.gcCompta.DsBase = Nothing
        Me.gcCompta.FiltreAffichage = ""
        Me.gcCompta.Label1Top = 10
        Me.gcCompta.LabelLeft = 10
        Me.gcCompta.LargeurText = 250
        Me.gcCompta.LiaisonDonnees = True
        Me.gcCompta.Lien = Nothing
        Me.gcCompta.LigneHauteur = 20
        Me.gcCompta.LigneIntervale = 5
        Me.gcCompta.Location = New System.Drawing.Point(152, 0)
        Me.gcCompta.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcCompta.Name = "gcCompta"
        Me.gcCompta.NomTableConfig = Nothing
        Me.gcCompta.NuméroNiveau1 = 7
        Me.gcCompta.Size = New System.Drawing.Size(150, 150)
        Me.gcCompta.TabIndex = 8
        Me.gcCompta.Table = "Produit"
        Me.gcCompta.TableListeChoix = "ListeChoix"
        Me.gcCompta.TableParam = "Niveau2"
        Me.gcCompta.TexteLeft = 115
        Me.gcCompta.TypeRecherche = False
        '
        'FrProduit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gcCompta)
        Me.KeyPreview = True
        Me.Name = "FrProduit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiche Produit"
        CType(Me.PtImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpProduit.ResumeLayout(False)
        Me.tpProduit.PerformLayout()
        Me.tpStats.ResumeLayout(False)
        Me.tpImage.ResumeLayout(False)
        Me.tpCompo.ResumeLayout(False)
        Me.tpCompo.PerformLayout()
        CType(Me.CompositionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompoBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CompoBindingNavigator.ResumeLayout(False)
        Me.CompoBindingNavigator.PerformLayout()
        Me.tpStocks.ResumeLayout(False)
        Me.tpStocks.PerformLayout()
        CType(Me.StocksDatagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"

    Private Sub ChargerDonnees()
        Me.ds = New DataSet
        Me.dsCompo = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            If FrApplication.Modules.ModuleCompta Then Compta.ChargerDonneesCompta(ds)
            DefinitionDonnees.Instance.Fill(ds, "TVA", s)
            DefinitionDonnees.Instance.Fill(ds, "Famille", s)
            DefinitionDonnees.Instance.Fill(dsCompo, "Produit", s, "Inactif=0")

            If CInt(Me.id) >= 0 OrElse Me.CodeProduitEnCours <> "" Then
                Dim where As String
                If CInt(Me.id) >= 0 Then
                    where = String.Format("nProduit={0}", Me.id)
                Else
                    where = FormatExpression("CodeProduit={0}", Me.CodeProduitEnCours)
                End If
                DefinitionDonnees.Instance.Fill(ds, "Produit", s, where)
                Me.ds.AcceptChanges()
                With Me.ProduitBindingSource
                    .DataSource = ds
                    .DataMember = "Produit"
                End With

                If FrApplication.Modules.ModuleGestionWeb Then
                    If Me.CurrentDrv.Row.Table.Columns.Contains("Image") Then
                        Dim strImage As String = Convert.ToString(Me.CurrentDrv("Image"))
                        If strImage <> "" AndAlso IO.File.Exists(strImage) Then
                            PtImage.Load(strImage)
                        Else
                            PtImage.Image = Nothing
                        End If
                    End If
                End If
                Me.Text = "Produit : " & Convert.ToString(Me.CurrentDrv("Libelle"))
                DefinitionDonnees.Instance.Fill(ds, "CompositionProduit", s, FormatExpression("CodeProduit={0}", Me.CurrentDrv("CodeProduit")))
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, "Produit", s)
                DefinitionDonnees.Instance.FillSchema(ds, "CompositionProduit", s)
                With Me.ds.Tables("Produit")
                    .Columns("CodeProduit").DefaultValue = ""
                    .Columns("TypeFacturation").DefaultValue = "U1"
                    .Columns("ProduitAchat").DefaultValue = True
                    .Columns("ProduitVente").DefaultValue = True
                    If (Me.ds.Tables("Produit").Columns.Contains("IsEnVente")) Then
                        .Columns("IsEnVente").DefaultValue = True
                    End If
                End With
                With Me.ProduitBindingSource
                    .DataSource = ds
                    .DataMember = "Produit"
                End With
                Me.ProduitBindingSource.AddNew()
                ValeurDefautProduit(Me.CurrentDrv, s)
                Me.Text = "Produit"
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)
        ConfigDataTableEvents(Me.ds.Tables("Produit"), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables("CompositionProduit"), AddressOf Datarowchanged, True)
        Databinding()

        Me.CodeProduitEnCours = Convert.ToString(Me.CurrentDrv("CodeProduit"))
    End Sub

    Private Shared Sub ValeurDefautProduit(ByRef rwv As DataRowView, ByVal s As SqlProxy)
        Dim VDef As ValeurDefaultApplication = FrApplication.ValeurDefault
        With rwv
            .Item("Famille1") = DBNull.Value
            .Item("GestionStock") = VDef.ProduitGestionStock
            If .Row.Table.Columns.Contains("DecompteAuto") Then
                .Item("DecompteAuto") = VDef.ProduitDecompteStockAuto
            End If
            .Item("ProduitAchat") = VDef.ProduitAchat
            .Item("ProduitVente") = VDef.ProduitVente
            .Item("TypeFacturation") = VDef.ProduitTypeFacturation
            .Item("TTVA") = VDef.ProduitTxTVAVente
            If Not VDef.ProduitNCompteAAuto Then
                .Item("NCompteA") = VDef.ProduitNCompteA
            Else
                Dim maxCompte As Long = s.GetMaxValue("Produit", "NCompteA", "SUBSTRING(NCompteA,4,5)<>'99999'")
                If maxCompte > 0 Then
                    rwv("NCompteA") = maxCompte + 1
                Else
                    rwv("NCompteA") = VDef.ProduitNCompteA
                End If
            End If
            .Item("NActiviteA") = VDef.ProduitNActiviteA
            If VDef.ProduitNCompteVAuto = False Then
                .Item("NCompteV") = VDef.ProduitNCompteV
            Else
                Dim maxCompte As Long = s.GetMaxValue("Produit", "NCompteV", "SUBSTRING(NCompteV,4,5)<>'99999'")
                If maxCompte > 0 Then
                    rwv("NCompteV") = maxCompte + 1
                Else
                    rwv("NCompteV") = VDef.ProduitNCompteV
                End If
            End If
            .Item("NActiviteV") = VDef.ProduitNActiviteV

            If .Row.Table.Columns.Contains("IsSortieImpr") Then
                .Item("IsSortieImpr") = True
            End If

            If .Row.Table.Columns.Contains("IsEnVente") Then
                .Item("IsEnVente") = True
            End If
        End With
    End Sub

    Private Sub Databinding()
        With Me.CompoBindingSource
            .SuspendBinding()
            .DataSource = Me.ProduitBindingSource
            .DataMember = NomLiaisonCompo
            .ResumeBinding()
        End With
        Me.CompositionDataGridView.DataSource = Me.CompoBindingSource
        Me.ds.Tables("CompositionProduit").Columns("CodeProduit").DefaultValue = Me.CurrentDrv("CodeProduit")

        'Databinding
        Me.gcProduit.SetDataSource(CType(Me.ProduitBindingSource.List, DataView))
        Me.gcCompta.SetDataSource(CType(Me.ProduitBindingSource.List, DataView))

        If FrApplication.Modules.ModuleCompta Then
            GestCompta = New Compta(ds, Me.ProduitBindingSource.CurrencyManager, "Libelle")
            AddHandler gcCompta.AfficheNewPerso, AddressOf GestCompta.AfficheNewPerso
            AddHandler gcCompta.CtlValidating, AddressOf GestCompta.VerifValidating
        End If

        If Not IsDBNull(Me.CurrentDrv("ProduitCompose")) Then
            SetTabVisible(Me.TabControl1, Me.tpCompo, CBool(Me.CurrentDrv("ProduitCompose")))
        Else
            SetTabVisible(Me.TabControl1, Me.tpCompo, False)
        End If

        'AfficheStatistique()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If Not Me.ds.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.CompoBindingSource.EndEdit()
        Me.ProduitBindingSource.EndEdit()
        If Me.ds.HasChanges Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                Case MsgBoxResult.No
                    'On continue sans enregistrer
                Case MsgBoxResult.Yes
                    If Not Enregistrer() Then
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        'Vérifie que le Code produit n'existe pas déjà
        Dim rw As DataRow = Me.CurrentDrv.Row
        Dim codeProduit As String = rw.Item("CodeProduit").ToString()
        Dim nb As Integer = GetNbCodeProduit(codeProduit, CInt(Me.nProduit))

        If nb > 0 Then
            MsgBox("Le Code Produit existe déjà.", MsgBoxStyle.Exclamation, "Erreur")

            Me.gcProduit.Controls.Item(0).Controls.Item(1).Focus()

            Return False
        End If

        'Enregistrer
        If Not Me.Validate() Then Return False

        Me.CompoBindingSource.EndEdit()
        Me.ProduitBindingSource.EndEdit()

        'Il faut tester avant MAJ de la base s'il y a eu modif
        Dim oldCodeProduit As String = Me.CodeProduitEnCours
        Dim codeProduitModif As Boolean = InfoModifiee("CodeProduit", Nothing)
        Dim infosComptaVenteModif As Boolean = FrApplication.Modules.ModuleCompta AndAlso InfosComptaModifiees("V")
        Dim infosComptaExportModif As Boolean = FrApplication.Modules.ModuleCompta AndAlso InfosComptaModifiees("X")
        Dim infosComptaAchatModif As Boolean = FrApplication.Modules.ModuleCompta AndAlso InfosComptaModifiees("A")

        'Si l'unité 1 et/ou l'unité 2 ont été modifiées, on les modifie également dans la table Mouvement_Detail
        Me.MAJUnitesDansMouvementDetail()

        Dim res As Boolean = UpdateBase()

        If res Then
            If codeProduitModif Then PropagerModifsCodeProduit(oldCodeProduit, Me.CodeProduitEnCours)
            If FrApplication.Modules.ModuleTarif Then VerifierTarifs(Me.CodeProduitEnCours)
            If infosComptaVenteModif Then PropagerModifsComptaVente(Me.CodeProduitEnCours)
            If infosComptaExportModif Then PropagerModifsComptaExport(Me.CodeProduitEnCours)
            If infosComptaAchatModif Then PropagerModifsComptaAchat(Me.CodeProduitEnCours)
        End If

        Return res
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Produit", "CompositionProduit"}
            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using
            If Me.ProduitBindingSource.Position >= 0 Then
                Me.CodeProduitEnCours = Convert.ToString(Me.CurrentDrv("CodeProduit"))
            Else
                Me.CodeProduitEnCours = Nothing
            End If
            Return True
        Catch ex As DBConcurrencyException
            LogException(ex)
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function InfoModifiee(ByVal champ As String, ByVal nullValue As Object) As Boolean
        If Me.ProduitBindingSource.Position < 0 Then Return False
        Dim rw As DataRow = Me.CurrentDrv.Row
        If rw.RowState = DataRowState.Modified Then
            If rw(champ).Equals(nullValue) Then rw(champ) = DBNull.Value
            Return Not rw(champ, DataRowVersion.Current).Equals(rw(champ, DataRowVersion.Original))
        End If
        Return False
    End Function

    Private Sub MAJUnitesDansMouvementDetail()
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub

        Dim rw As DataRow = Me.CurrentDrv.Row
        Dim nouvelleValeur As String = String.Empty
        Dim ancienneValeur As String = String.Empty

        'Unité 1
        nouvelleValeur = Convert.ToString(rw("Unite1"))

        Using prodTableAdapter As New DsProduitsTableAdapters.ProduitTableAdapter
            Dim prodDataTable As DsProduits.ProduitDataTable = prodTableAdapter.GetDataBynProduit(Convert.ToDecimal(Me.nProduit))

            For Each prodRow As DsProduits.ProduitRow In prodDataTable.Rows
                If (prodRow.IsUnite1Null) Then
                    ancienneValeur = String.Empty
                Else
                    ancienneValeur = prodRow.Unite1
                End If
            Next
        End Using

        If (nouvelleValeur <> ancienneValeur) Then
            Dim queryString As String = "UPDATE Mouvement_Detail " & _
                                        "SET LibUnite1='" & Replace(nouvelleValeur, "'", "''") & "' " & _
                                        "WHERE CodeProduit='" & Replace(Me.CodeProduitEnCours, "'", "''") & "'"

            Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End If

        'Unité 2
        nouvelleValeur = Convert.ToString(rw("Unite2"))

        Using prodTableAdapter As New DsProduitsTableAdapters.ProduitTableAdapter
            Dim prodDataTable As DsProduits.ProduitDataTable = prodTableAdapter.GetDataBynProduit(Convert.ToDecimal(Me.nProduit))

            For Each prodRow As DsProduits.ProduitRow In prodDataTable.Rows
                If (prodRow.IsUnite2Null) Then
                    ancienneValeur = String.Empty
                Else
                    ancienneValeur = prodRow.Unite2
                End If
            Next
        End Using

        If (nouvelleValeur <> ancienneValeur) Then
            Dim queryString As String = "UPDATE Mouvement_Detail " & _
                                        "SET LibUnite2='" & Replace(nouvelleValeur, "'", "''") & "' " & _
                                        "WHERE CodeProduit='" & Replace(Me.CodeProduitEnCours, "'", "''") & "'"

            Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                Dim sqlComm As New SqlCommand(queryString, sqlConn)
                sqlComm.Connection.Open()
                sqlComm.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Private Sub VerifierTarifs(ByVal codeProduit As String)
        If codeProduit = "" Then Exit Sub
        Using s As New SqlProxy
            Dim sql As String = "INSERT INTO Tarif_Detail(nTarifDetail,nTarif,Codeproduit) " & _
                                "SELECT (SELECT MAX(nTarifDetail) FROM Tarif_Detail)+1+nTarif, nTarif,{0} AS codeproduit " & _
                                "FROM Tarif " & _
                                "WHERE nTarif NOT IN (SELECT nTarif FROM Tarif_Detail WHERE CodeProduit={0})"
            s.ExecuteNonQuery(SqlProxy.FormatSql(sql, codeProduit))
        End Using
    End Sub

    Private Sub PropagerModifsCodeProduit(ByVal oldCodeProduit As String, ByVal codeProduit As String)
        If oldCodeProduit = "" OrElse codeProduit = "" Then Exit Sub
        Using s As New SqlProxy
            'Propager aux compositions (normalement c'est déjà fait)
            s.ExecuteNonQuery(SqlProxy.FormatSql("UPDATE CompositionProduit SET CodeProduit={0} WHERE CodeProduit={1}", codeProduit, oldCodeProduit))
            s.ExecuteNonQuery(SqlProxy.FormatSql("UPDATE CompositionProduit SET CodeProduitComposition={0} WHERE CodeProduitComposition={1}", codeProduit, oldCodeProduit))
            'Propager aux tarifs
            s.ExecuteNonQuery(SqlProxy.FormatSql("UPDATE Tarif_Detail SET CodeProduit={0} WHERE CodeProduit={1}", codeProduit, oldCodeProduit))
            'Demander pour propager aux pièces ?
            Dim dtChildObjects As DsProduits.ProduitChildrenDataTable
            Using dta As New DsProduitsTableAdapters.ProduitChildrenTA
                dtChildObjects = dta.GetDataByCodeProduit(oldCodeProduit)
            End Using
            If dtChildObjects.Count > 0 Then
                If MsgBox("Propager le nouveau code produit aux pièces de facturation existantes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim sql As String = "UPDATE {0} SET CodeProduit={{0}} WHERE CodeProduit={{1}}"
                    For Each dr As DsProduits.ProduitChildrenRow In dtChildObjects
                        s.ExecuteNonQuery(SqlProxy.FormatSql(String.Format(sql, dr.tablename), codeProduit, oldCodeProduit))
                    Next
                End If
            End If
        End Using
    End Sub

    Private Sub PropagerDeleteCodeProduit(ByVal codeProduit As String)
        If codeProduit = "" Then Exit Sub
        Using s As New SqlProxy
            'Propager aux compositions (normalement c'est déjà fait)
            s.ExecuteNonQuery(SqlProxy.FormatSql("DELETE FROM CompositionProduit WHERE CodeProduit={0}", codeProduit))
            s.ExecuteNonQuery(SqlProxy.FormatSql("DELETE FROM CompositionProduit WHERE CodeProduitComposition={0}", codeProduit))
            'Propager aux tarifs
            s.ExecuteNonQuery(SqlProxy.FormatSql("DELETE FROM Tarif_Detail WHERE CodeProduit={0}", codeProduit))
        End Using
    End Sub

    Private Shared Function CheckForProduitChild(ByVal codeProduit As String) As Boolean
        If codeProduit = "" Then Return True
        Dim dtChildObjects As DsProduits.ProduitChildrenDataTable
        Using dta As New DsProduitsTableAdapters.ProduitChildrenTA
            dtChildObjects = dta.GetDataByCodeProduit(codeProduit)
        End Using
        If dtChildObjects.Count > 0 Then
            Dim msg As New System.Text.StringBuilder("Ce produit est utilisé dans :" & vbCrLf)
            For Each dr As DsProduits.ProduitChildrenRow In dtChildObjects
                msg.AppendFormat("  {0} {1}" & vbCrLf, dr.nb, dr._lib)
            Next
            msg.AppendLine("Voulez-vous continuer ?")
            Return MsgBox(msg.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes
        Else
            Return True
        End If
    End Function

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles gcProduit.MustRefreshTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                ds.EnforceConstraints = False
                Using s As New SqlProxy
                    s.Fill(ds, t)
                End Using
                ds.EnforceConstraints = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles gcProduit.MustUpdateTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                Using s As New SqlProxy
                    s.UpdateTable(ds, t)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If (Me.SupprimerProduit()) Then
            Me.Close()
        End If

        'If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        'Try
        '    If Not CheckForProduitChild(Me.CodeProduitEnCours) Then Exit Sub
        '    Me.ProduitBindingSource.RemoveCurrent()
        '    If UpdateBase() Then
        '        PropagerDeleteCodeProduit(Me.CodeProduitEnCours)
        '        Me.Close()
        '    End If
        'Catch ex As UserCancelledException
        'Catch ex As Exception
        '    Throw New ApplicationException(ex.Message, ex)
        'End Try
    End Sub

    Private Sub TpImprEt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprEt.Click
        ImprimerEtiquette()
    End Sub

    Private Sub TbMajBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbMajBalance.Click
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Me.ProduitBindingSource.EndEdit()
        If Not DemanderEnregistrement() Then Exit Sub

        With New Actigram.Balance.Mira.GestionMira
            .TableTVA = ds.Tables("TVA")
            .nBalance = 0
            .EnvoiMajProduit(New DataRow() {Me.CurrentDrv.Row}, CBool(ParametresApplication.ValeurParametre("PriceOverWrite", False)))
            .nBalance = 1
        End With
    End Sub

    Private Sub TbSaisiePrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSaisiePrix.Click
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Me.ProduitBindingSource.EndEdit()
        If Not DemanderEnregistrement() Then Exit Sub

        Dim fr As New FrSaisieTarifs()
        fr.ColProdVisible = False
        fr.CodeProduit = Convert.ToString(Me.CurrentDrv("CodeProduit"))
        fr.ShowDialog(Me)
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.ProduitBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbSuppr.Enabled = rowExists
        Me.TbImprEt.Enabled = rowExists
        Me.TbMajBalance.Enabled = rowExists
        Me.TbSaisiePrix.Enabled = rowExists
    End Sub

#End Region

#Region "Form Events"
    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.CompositionDataGridView.DataSource = Nothing
        ApplyStyle(Me.CompositionDataGridView, False)
        ApplyStyle(Me.StocksDatagridview)
        '-- MODULES
        Me.TbMajBalance.Visible = FrApplication.Modules.ModuleBalance
        Me.TbSaisiePrix.Visible = FrApplication.Modules.ModuleTarif

        If Not FrApplication.Modules.ModuleCompta Then
            Me.TabControl1.TabPages.Remove(Me.tpCompta)
        Else
            Me.Controls.Remove(Me.gcCompta)
            Me.tpCompta.Controls.Add(Me.gcCompta)
            Me.gcCompta.Dock = DockStyle.Fill
        End If

        If Not FrApplication.Modules.ModuleGestionWeb Then
            Me.TabControl1.TabPages.Remove(Me.tpImage)
        End If

        If Not FrApplication.Modules.ModuleStock Then
            Me.TabControl1.TabPages.Remove(Me.tpStocks)
        End If

        Me.LbStockActuel.Visible = FrApplication.Modules.ModuleStock
        Me.LbStockDispo.Visible = FrApplication.Modules.ModuleStock
        Me.LbCmdClient.Visible = FrApplication.Modules.ModuleStock

        Dim strFiltreAffichage As String = GestionControles.GetFiltreAffichage
        Me.gcProduit.FiltreAffichage = strFiltreAffichage
        Me.gcCompta.FiltreAffichage = strFiltreAffichage

        '-- ETIQUETTES
        Try
            Dim lab As New Dymo.LabelEngine
        Catch ex As Exception
            TbImprEt.Visible = False
        End Try

        ChargerDonnees()
        Me.TabControl1.SelectedTab = Me.tpProduit
        MajBoutons()
    End Sub

    Private Sub Me_Closing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                If Me.ProduitBindingSource.Position >= 0 Then

                    DemanderEnregistrement(e)
                    If e.Cancel Then Exit Sub

                    Me.OnSelectObject(Me.nProduit)
                End If
        End Select
    End Sub

    Private Sub FrProduit_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        For Each ctrl As Control In Me.gcProduit.Controls(0).Controls
            If Convert.ToString(ctrl.Tag) = "CodeProduit" Then
                If (Me.CodeProduitEnCours <> "") Then
                    ctrl.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean = True
        If Not Me.gcCompta.VerifContraintes Then
            res = False
            Me.TabControl1.SelectedTab = Me.tpCompta
        End If
        If Not Me.gcProduit.VerifContraintes Then
            res = False
            Me.TabControl1.SelectedTab = Me.tpProduit
        End If
        If res Then
            res = MyBase.Validate
        End If
        Return res
    End Function
#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is tpStats Then
            'Me.AfficheStatistique()
        ElseIf TabControl1.SelectedTab Is tpCompo Then
            'Forcer l'enregistrement du produit
            If Not Enregistrer() Then
                Me.TabControl1.SelectedTab = Me.tpProduit
            Else
                Me.ColUnite1.HeaderText = String.Format("1 {0} =", Me.CurrentDrv("Unite1"))
                Me.ColUnite2.HeaderText = String.Format("1 {0} =", Me.CurrentDrv("Unite2"))
            End If
        ElseIf TabControl1.SelectedTab Is tpStocks Then
            ChargerStocks()
        End If
    End Sub

#Region "Gestion Propriétés Produit"
    Private Sub gcProduit_CtlValidating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gcProduit.CtlValidating
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Dim rwv As DataRowView = Me.CurrentDrv
        Dim ctl As Control = CType(sender, Control)
        If Convert.ToString(ctl.Tag) = "CodeProduit" Then
            'TODO si on change le code produit, proposer de propager aux factures existantes
            CheckCodeProduit(ctl)
            'On a changé le code produit => On doit mettre à jour la liaison avec dvCompo
            'If ctl.Text.Length > 0 Then
            '    dvCompo = rwv.CreateChildView(_NomLiaisonCompo)
            '    dvCompo.Sort = "Libelle"
            '    Me.ndbCompo.SetDataSource(dvCompo)
            '    SetListSort("Libelle")
            '    SetListDatasource(dvCompo)
            'End If
        End If
    End Sub

    Private Sub gcProduit_CtlValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcProduit.CtlValidated
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Me.ProduitBindingSource.EndEdit()
        Dim rwv As DataRowView = Me.CurrentDrv
        Dim ctl As Control = CType(sender, Control)
        If Convert.ToString(ctl.Tag) = "CoefAV" Then
            If ctl.Text <> "" Then
                With rwv
                    If Not IsDBNull(.Item("PrixAHT")) Then
                        .BeginEdit()
                        .Item("PrixVHT") = CDec(.Item("PrixAHT")) * CDec(ctl.Text)
                        .EndEdit()
                    End If
                End With
            End If
        ElseIf Convert.ToString(ctl.Tag) = "Libelle" Then
            If Convert.ToString(rwv.Item("CodeProduit")) = "" Then
                Dim mots() As String = ctl.Text.Split(" "c)
                Dim strCodeProduit As String = ""
                If mots.Length = 1 Then 'Un seul mot
                    strCodeProduit = Microsoft.VisualBasic.Left(mots(0), 6)
                ElseIf mots.Length > 1 Then
                    strCodeProduit = Microsoft.VisualBasic.Left(mots(0), 4) & Microsoft.VisualBasic.Left(mots(1), 2)
                End If
                Dim n As Integer = 0
                Dim strCodePlus As String = GetUniqueCodeProduit(strCodeProduit)
                With rwv
                    .BeginEdit()
                    .Item("CodeProduit") = strCodePlus
                    .EndEdit()
                End With
            End If
        End If
    End Sub

    Private Sub gcProduit_AfficheNewPerso(ByVal sender As System.Object, ByVal strType As String) Handles gcProduit.AfficheNewPerso
        If strType = "Famille" Then
            Dim FrF As New FrListeFamilles()
            AddHandler FrF.FormClosed, AddressOf ReloadFamilles
            FrF.WindowState = FormWindowState.Normal
            FrF.StartPosition = FormStartPosition.CenterParent
            FrF.Show(Me)
        End If
    End Sub

    Private Sub gcProduit_CtlTextchanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcProduit.CtlTextchanged
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Dim ctl As Control = CType(sender, Control)
        If Convert.ToString(ctl.Tag) = "CodeProduit" Then
            CheckCodeProduit(ctl)
        End If
    End Sub

    Private Sub gcProduit_CtlCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcProduit.CtlCheckedChanged
        If Convert.ToString(CType(sender, Control).Tag) = "ProduitCompose" Then
            Dim ck As CheckBox = CType(sender, CheckBox)
            Me.TabControl1.SuspendLayout()
            If Not IsDBNull(Me.CurrentDrv("ProduitCompose")) Then
                SetTabVisible(Me.TabControl1, Me.tpCompo, ck.Checked)
            Else
                SetTabVisible(Me.TabControl1, Me.tpCompo, False)
            End If
            Me.TabControl1.SelectedTab = Me.tpProduit
            Me.TabControl1.ResumeLayout()
        End If
    End Sub

    Private Sub SetTabVisible(ByVal tc As TabControl, ByVal tp As TabPage, ByVal visible As Boolean)
        If visible And Not tc.TabPages.Contains(tp) Then
            tc.TabPages.Add(tp)
        ElseIf Not visible And tc.TabPages.Contains(tp) Then
            tc.TabPages.Remove(tp)
        End If
    End Sub

    Private Sub ReloadFamilles(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            ds.EnforceConstraints = False
            DefinitionDonnees.Instance.Fill(ds, "Famille")
            ds.EnforceConstraints = True
        End If
    End Sub

#End Region

#Region "Gestion Compositions"
    Private Sub CompositionProduitDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CompositionDataGridView.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        Select Case CompositionDataGridView.Columns(e.ColumnIndex).DataPropertyName
            Case "CodeProduitComposition"
                Dim codeProduit As String = Convert.ToString(CompositionDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                Dim drProduit As DataRow = SelectSingleRow(Of DataRow)(dsCompo.Tables("Produit"), FormatExpression("CodeProduit={0}", codeProduit), "")
                If drProduit IsNot Nothing Then
                    Dim drCompo As DataRow = CType(CompoBindingSource.Current, DataRowView).Row
                    If Not drProduit.IsNull("Libelle") Then drCompo("Libelle") = drProduit("Libelle")
                    If Not drProduit.IsNull("Unite1") Then drCompo("LibUnite1") = drProduit("Unite1")
                    If Not drProduit.IsNull("Unite2") Then drCompo("LibUnite2") = drProduit("Unite2")
                    Me.CompoBindingSource.ResetCurrentItem()
                    Me.CompositionDataGridView.Refresh()
                    ConfigCompoRow(CompositionDataGridView.CurrentRow, CType(CompoBindingSource.Current, DataRowView))
                    'ElseIf codeProduit.Length > 0 Then
                    '    Dim c As DataGridViewCell = CompositionDataGridView.CurrentRow.Cells(Me.ColCodeProduitComposition.Index)
                    '    ShowSelectionProduit(c)
                End If
            Case "Unite1"
                Dim u1 As Object = CompositionDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If Not IsDBNull(u1) Then
                    Dim du As Decimal = CDec(u1)
                    If du - Decimal.Round(du, 3) <> 0 Then
                        MsgBox("Attention, le nombre d'unité 1 sera tronqué à 3 décimales", MsgBoxStyle.Exclamation)
                    End If
                    Dim libu1 As String = Convert.ToString(CompositionDataGridView.Rows(e.RowIndex).Cells(ColLibU1.Index).Value)
                    If libu1 = Convert.ToString(Me.CurrentDrv("Unite1")) AndAlso du <> 1 Then
                        Dim libelle As String = Convert.ToString(CompositionDataGridView.Rows(e.RowIndex).Cells(ColLibelle.Index).Value)
                        If MsgBox(String.Format("Confirmez-vous que 1{0} de {1} est composé de {2}{3} de {4} ?", Me.CurrentDrv("Unite1"), Me.CurrentDrv("Libelle"), du, libu1, libelle), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                            CompositionDataGridView.CancelEdit()
                            Exit Sub
                        End If
                    End If
                End If
            Case "Unite2"
                Dim u2 As Object = CompositionDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If Not IsDBNull(u2) Then
                    Dim du As Decimal = CDec(u2)
                    If du - Decimal.Round(du, 3) <> 0 Then
                        MsgBox("Attention, le nombre d'unité 2 sera tronqué à 3 décimales", MsgBoxStyle.Exclamation)
                    End If
                    Dim libu2 As String = Convert.ToString(CompositionDataGridView.Rows(e.RowIndex).Cells(ColLibU2.Index).Value)
                    If libu2 = Convert.ToString(Me.CurrentDrv("Unite2")) AndAlso du <> 1 Then
                        Dim libelle As String = Convert.ToString(CompositionDataGridView.Rows(e.RowIndex).Cells(ColLibelle.Index).Value)
                        If MsgBox(String.Format("Confirmez-vous que 1{0} de {1} est composé de {2}{3} de {4} ?", Me.CurrentDrv("Unite2"), Me.CurrentDrv("Libelle"), du, libu2, libelle), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                            CompositionDataGridView.CancelEdit()
                            Exit Sub
                        End If
                    End If
                End If
                'Dim drCompo As DataRow = CType(CompoBindingSource.Current, DataRowView).Row
                'Dim drProduit As DataRow = SelectSingleRow(Of DataRow)(dsCompo.Tables("Produit"), FormatExpression("CodeProduit={0}", drCompo("CodeProduit")), "")
                'If drProduit IsNot Nothing Then
                '    If Not drProduit.IsNull("CoefU2") Then
                '        If IsDBNull(u1) Then
                '            drCompo("Unite2") = DBNull.Value
                '        Else
                '            drCompo("Unite2") = CDec(drProduit("CoefU2")) * CDec(u1)
                '        End If
                '        Me.CompoBindingSource.ResetCurrentItem()
                '        Me.CompositionDataGridView.Refresh()
                '    End If
                'End If
        End Select
    End Sub

    Private Sub CompositionDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles CompositionDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In CompositionDataGridView.Rows
                ConfigCompoRow(r)
            Next
        ElseIf e.ListChangedType = System.ComponentModel.ListChangedType.ItemChanged Then
            Dim r As DataGridViewRow = CompositionDataGridView.CurrentRow
            ConfigCompoRow(r)
        End If
    End Sub

    Private Sub ConfigCompoRow(ByVal r As DataGridViewRow)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim drv As DataRowView = Cast(Of DataRowView)(r.DataBoundItem)
        ConfigCompoRow(r, drv)
    End Sub

    Private Sub ConfigCompoRow(ByVal r As DataGridViewRow, ByVal drv As DataRowView)
        r.Cells(Me.ColUnite1.Index).ReadOnly = (Convert.ToString(drv("LibUnite1")).Length = 0)
        r.Cells(Me.ColUnite2.Index).ReadOnly = (Convert.ToString(drv("LibUnite2")).Length = 0)
    End Sub

    Private Sub CompositionDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CompositionDataGridView.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Me.ColBtSelectProd.Index Then
            ShowSelectionProduit(Me.CompositionDataGridView.Rows(e.RowIndex).Cells(ColCodeProduitComposition.Index))
        End If
    End Sub

    Private _stop As Boolean = False
    Private Sub ShowSelectionProduit(ByVal cell As DataGridViewCell)
        If _stop Then Exit Sub
        _stop = True
        Dim r As Rectangle = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
        Dim pt As Point = cell.DataGridView.PointToScreen(r.Location)
        pt.Offset(0, r.Height)

        Dim frSelectionProduit As New FrSelection(cell, 0)
        With frSelectionProduit
            AddHandler .Closed, AddressOf frSelectionProduit_Closed
            .StartPosition = FormStartPosition.Manual
            If pt.Y + .Height > My.Computer.Screen.Bounds.Height Then
                pt.Offset(0, -(r.Height + .Height))
            End If
            .Location = pt

            .AddColumn("Code", "CodeProduit", 60, DataGridViewContentAlignment.MiddleCenter)
            .AddColumn("Produit", "Libelle", 150, , , DataGridViewAutoSizeColumnMode.Fill)
            Dim dvS As DataView = New DataView(dsCompo.Tables("Produit"), "", "Libelle", DataViewRowState.CurrentRows)
            Dim strFiltreTypePRoduit As String = ""
            .DataSource = dvS

            .Owner = Me
            .Show()

            With .Liste
                .ClearSelection()
                For Each ro As DataGridViewRow In .Rows
                    If ro.Cells("Libelle").Value.ToString.ToUpper.StartsWith(Convert.ToString(cell.Value).ToUpper) Then
                        ro.Selected = True
                        Exit For
                    End If
                Next
            End With
        End With
    End Sub

    Private Sub frSelectionProduit_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CompositionDataGridView.CurrentCell = Me.CompositionDataGridView.CurrentRow.Cells(Me.ColCodeProduitComposition.Index)
        _stop = False
    End Sub
#End Region

#Region "Gestion Image"
    Private Function GetImageReduite(ByVal strFileName As String, ByVal Coef As Decimal) As Image
        Dim ImDep As Image = CType(Image.FromFile(strFileName), Bitmap)
        Dim im As New Bitmap(Convert.ToInt32(ImDep.Width * Coef), Convert.ToInt32(ImDep.Height * Coef))
        Using g As Graphics = Graphics.FromImage(im)
            g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.DrawImage(ImDep, 0, 0, im.Width, im.Height)
        End Using
        Return im
    End Function

    Private Sub BtAnnulerImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtSupprImage.Click
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        If ds.Tables("Prodtui").Columns.Contains("Image") Then
            Me.CurrentDrv("Image") = DBNull.Value
            PtImage.Image = Nothing
        End If
    End Sub

    Private Sub PtImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles PtImage.DoubleClick, BtParcourir.Click
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        If Not ds.Tables("Produit").Columns.Contains("Image") Then Exit Sub
        If Me.dlgImage.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If Me.dlgImage.FileName <> "" Then
            Dim repImages As String = IO.Path.Combine(Application.StartupPath, "Images")
            If Not IO.Directory.Exists(repImages) Then IO.Directory.CreateDirectory(repImages)
            Dim repImagesGd As String = IO.Path.Combine(repImages, "Gd")
            If Not IO.Directory.Exists(repImagesGd) Then IO.Directory.CreateDirectory(repImagesGd)

            Dim cheminImage As String = IO.Path.Combine(repImagesGd, String.Format("{0}.jpg", Me.CurrentDrv("CodeProduit")))
            Dim Im As Image = GetImageReduite(Me.dlgImage.FileName, 1D)
            Im.Save(cheminImage, System.Drawing.Imaging.ImageFormat.Jpeg)
            Me.CurrentDrv("Image") = cheminImage
            PtImage.Image = Im
        Else
            Me.CurrentDrv("Image") = DBNull.Value
            PtImage.Image = Nothing
        End If
    End Sub
#End Region

    'TODO STATISTIQUES PRODUIT
    '#Region "Gestion stats"
    '    Private Sub DeclencheAfficheStats(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    '    Handles TabPerso2.TabClick
    '        Me.AfficheStatistique()
    '    End Sub

    '    Private Sub AfficheStatAnnee(ByRef rwv As DataRowView, ByVal TxTVA As Decimal)

    '        Dim Br As New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetValeurCAHTPeriode(rwv, Now.AddYears(-1).ToString("01/01/yyyy"), Now.AddYears(0).ToString("01/01/yyyy"), TxTVA)
    '        Me.Graphique1.Valeurs.Add(Br)
    '        Me.Graphique1.Legendes.Add(Now.AddYears(-1).ToString("yyyy"))

    '        Br = New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetValeurCAHTPeriode(rwv, Now.AddYears(0).ToString("01/01/yyyy"), Now.AddYears(1).ToString("01/01/yyyy"), TxTVA)
    '        Me.Graphique1.Valeurs.Add(Br)
    '        Me.Graphique1.Legendes.Add(Now.AddYears(0).ToString("yyyy"))

    '        Br = New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetVolumePeriode(rwv, Now.AddYears(-1).ToString("01/01/yyyy"), Now.AddYears(0).ToString("01/01/yyyy"), TxTVA)
    '        Me.Graphique2.Valeurs.Add(Br)
    '        Me.Graphique2.Legendes.Add(Now.AddYears(-1).ToString("yyyy"))

    '        Br = New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetVolumePeriode(rwv, Now.AddYears(0).ToString("01/01/yyyy"), Now.AddYears(1).ToString("01/01/yyyy"), TxTVA)
    '        Me.Graphique2.Valeurs.Add(Br)
    '        Me.Graphique2.Legendes.Add(Now.AddYears(0).ToString("yyyy"))

    '    End Sub

    '    Private Function GetValeurCAHTPeriode(ByRef rwProduit As DataRowView, ByVal dtDebut As String, ByVal dtFin As String, ByVal TxTVA As Decimal) As Decimal
    '        Dim sumHT As Object
    '        Dim sumTTC As Object
    '        Dim caHT As Decimal = 0

    '        sumHT = ds.Tables("VFacture_Detail").Compute("Sum(MontantLigneHT)", "CodeProduit='" & Convert.ToString(rwProduit.Item("CodeProduit")) & "' And Parent(VFactureVFacture_Detail).DateFacture>=#" & dtDebut & "# And Parent(VFactureVFacture_Detail).DateFacture<#" & dtFin & "#")
    '        sumTTC = ds.Tables("VFacture_Detail").Compute("Sum(MontantLigneTTC)", "CodeProduit='" & Convert.ToString(rwProduit.Item("CodeProduit")) & "' And Parent(VFactureVFacture_Detail).DateFacture>=#" & dtDebut & "# And Parent(VFactureVFacture_Detail).DateFacture<#" & dtFin & "#")
    '        caHT = 0
    '        If Not sumHT Is DBNull.Value Then
    '            caHT += Convert.ToDecimal(sumHT)
    '        End If
    '        If Not sumTTC Is DBNull.Value Then
    '            caHT += Convert.ToDecimal(sumTTC) / (1 + TxTVA / 100)
    '        End If
    '        Return caHT
    '    End Function

    '    Private Function GetVolumePeriode(ByRef rwProduit As DataRowView, ByVal dtDebut As String, ByVal dtFin As String, ByVal TxTVA As Decimal) As Decimal
    '        Dim obj As Object
    '        Dim resultat As Decimal = 0
    '        obj = ds.Tables("VFacture_Detail").Compute("Sum(Unite1)", "CodeProduit='" & Convert.ToString(rwProduit.Item("CodeProduit")) & "' And Parent(VFactureVFacture_Detail).DateFacture>=#" & dtDebut & "# And Parent(VFactureVFacture_Detail).DateFacture<#" & dtFin & "#")
    '        If Not obj Is DBNull.Value Then
    '            resultat = Convert.ToDecimal(obj)
    '        End If
    '        Return resultat
    '    End Function

    '    Private Sub AfficheStatMoisLigneCAHT(ByRef rwv As DataRowView, ByVal TxTVA As Decimal, ByVal nMois As Integer)
    '        Dim Br As New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetValeurCAHTPeriode(rwv, Now.AddMonths(nMois).ToString("MM/01/yyyy"), Now.AddMonths(nMois + 1).ToString("MM/01/yyyy"), TxTVA)
    '        Me.Graphique1.Valeurs.Add(Br)
    '        Me.Graphique1.Legendes.Add(Now.AddMonths(nMois).ToString("MMMM"))
    '    End Sub

    '    Private Sub AfficheStatMoisLigneVolume(ByRef rwv As DataRowView, ByVal TxTVA As Decimal, ByVal nMois As Integer)
    '        Dim Br As New Actigram.Windows.Forms.Indicateurs.Barre
    '        Br.Valeur = GetVolumePeriode(rwv, Now.AddMonths(nMois).ToString("MM/01/yyyy"), Now.AddMonths(nMois + 1).ToString("MM/01/yyyy"), TxTVA)
    '        Me.Graphique2.Valeurs.Add(Br)
    '        Me.Graphique2.Legendes.Add(Now.AddMonths(nMois).ToString("MMMM"))
    '    End Sub

    '    Private Sub AfficheStatMois(ByRef rwv As DataRowView, ByVal TxTVA As Decimal)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, -5)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, -4)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, -3)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, -2)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, -1)
    '        AfficheStatMoisLigneCAHT(rwv, TxTVA, 0)

    '        AfficheStatMoisLigneVolume(rwv, TxTVA, -5)
    '        AfficheStatMoisLigneVolume(rwv, TxTVA, -4)
    '        AfficheStatMoisLigneVolume(rwv, TxTVA, -3)
    '        AfficheStatMoisLigneVolume(rwv, TxTVA, -2)
    '        AfficheStatMoisLigneVolume(rwv, TxTVA, -1)
    '        AfficheStatMoisLigneVolume(rwv, TxTVA, 0)
    '    End Sub

    '    Private Sub AfficheStatistique()
    '        If dv Is Nothing Then Exit Sub
    '        If Me.BindingContext(dv).Position = -1 Then Exit Sub

    '        Static dsEtatStock As DataSet
    '        If dsEtatStock Is Nothing Then
    '            dsEtatStock = New DataSet
    '            Dim tbStock As DataTable = FrEtatStock.GetProduitStock.Copy
    '            Dim tbStockCmd As DataTable = FrEtatStock.GetProduitCmd.Copy
    '            tbStock.TableName = "StockActuel"
    '            tbStockCmd.TableName = "StockCmd"
    '            dsEtatStock.Tables.Add(tbStock)
    '            dsEtatStock.Tables.Add(tbStockCmd)
    '        End If

    '        If Not Me.tpStats.Visible Then Exit Sub

    '        With Me.Graphique1
    '            .RefreshAuto = False
    '            .Valeurs.Clear()
    '            .Legendes.Clear()
    '        End With

    '        With Me.Graphique2
    '            .RefreshAuto = False
    '            .Valeurs.Clear()
    '            .Legendes.Clear()
    '        End With



    '        Dim rwv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
    '        Dim obj As Object
    '        obj = ds.Tables("VFacture_Detail").Compute("Sum(Unite1)", "CodeProduit='" & Convert.ToString(rwv("CodeProduit")).Replace("'", "''") & "'")
    '        If Not obj Is DBNull.Value Then
    '            Me.LbVolume.Text = "Volume : " & Convert.ToDecimal(obj).ToString("# ##0.000 " & Convert.ToString(rwv("Unite1")))
    '        Else
    '            Me.LbVolume.Text = "Volume : "
    '        End If

    '        Dim sumHT As Object
    '        Dim sumTTC As Object
    '        sumHT = ds.Tables("VFacture_Detail").Compute("Sum(MontantLigneHT)", "CodeProduit='" & Convert.ToString(rwv("CodeProduit")).Replace("'", "''") & "'")
    '        sumTTC = ds.Tables("VFacture_Detail").Compute("Sum(MontantLigneTTC)", "CodeProduit='" & Convert.ToString(rwv("CodeProduit")).Replace("'", "''") & "'")
    '        Dim CaHT As Decimal = 0
    '        Dim TxTVA As Decimal = 0
    '        Dim rwTVA() As DataRow = ds.Tables("TVA").Select("TTVA='" & Convert.ToString(rwv.Item("TTVA")).Replace("'", "''") & "'")
    '        If rwTVA.GetUpperBound(0) >= 0 Then
    '            TxTVA = Convert.ToDecimal(rwTVA(0).Item("TTaux"))
    '        End If
    '        If Not sumHT Is DBNull.Value Then
    '            CaHT += Convert.ToDecimal(sumHT)
    '        End If
    '        If Not sumTTC Is DBNull.Value Then
    '            CaHT += Convert.ToDecimal(sumTTC) / (1 + TxTVA / 100)
    '        End If
    '        If CaHT <> 0 Then
    '            Me.LbCA.Text = "CA : " & CaHT.ToString("# ##0.00 €")
    '        Else
    '            Me.LbCA.Text = "CA : "
    '        End If

    '        Dim rw() As DataRow = dsEtatStock.Tables("StockActuel").Select("CodeProduit='" & Convert.ToString(rwv.Item("CodeProduit")).Replace("'", "''") & "'")
    '        Dim StockActuel As Decimal = 0
    '        Dim StockCmd As Decimal = 0
    '        Dim LibUnite As String = ""
    '        Me.LbStockActuel.Text = "Stock Actuel : "
    '        If rw.GetUpperBound(0) >= 0 Then
    '            If Not rw(0).Item("Unite1") Is DBNull.Value Then
    '                StockActuel = Convert.ToDecimal(rw(0).Item("Unite1"))
    '                LibUnite = Convert.ToString(rw(0).Item("LibUnite1"))
    '                Me.LbStockActuel.Text = "Stock Actuel : " & StockActuel.ToString("# ##0.000") & " " & Convert.ToString(rw(0).Item("LibUnite1"))
    '            End If
    '        End If
    '        rw = dsEtatStock.Tables("StockCmd").Select("CodeProduit='" & Convert.ToString(rwv.Item("CodeProduit")).Replace("'", "''") & "'")
    '        Me.LbCmdClient.Text = "Stock Cmd : "
    '        If rw.GetUpperBound(0) >= 0 Then
    '            If Not rw(0).Item("Unite1") Is DBNull.Value Then
    '                StockCmd = Convert.ToDecimal(rw(0).Item("Unite1"))
    '                LibUnite = Convert.ToString(rw(0).Item("LibUnite1"))
    '                Me.LbCmdClient.Text = "Stock Cmd : " & (StockCmd * -1).ToString("# ##0.000") & " " & Convert.ToString(rw(0).Item("LibUnite1"))
    '            End If
    '        End If
    '        Me.LbStockDispo.Text = "Stock Dispo :"
    '        If StockActuel <> 0 Or StockCmd <> 0 Then
    '            Me.LbStockDispo.Text = "Stock Dispo : " & (StockActuel + StockCmd).ToString("# ##0.000") & " " & LibUnite
    '        End If

    '        If Me.TabPerso2.SelectedTab.Text = "Mois" Then
    '            Me.Graphique1.LargeurBarre = 24
    '            Me.Graphique2.LargeurBarre = 24
    '            Me.AfficheStatMois(rwv, TxTVA)
    '        Else
    '            Me.Graphique1.LargeurBarre = 100
    '            Me.Graphique2.LargeurBarre = 100
    '            Me.AfficheStatAnnee(rwv, TxTVA)
    '        End If

    '        Me.Graphique1.RefreshAuto = True
    '        Me.Graphique2.RefreshAuto = True

    '    End Sub

    '    Private Sub Graphique1_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer) Handles Graphique1.ClickLegende
    '        If sender.Valeurs.Item(nBarre).Valeur <> 0 Then
    '            Me.LbCA.Text = "CA (" & sender.Legendes.Item(nBarre) & "): " & sender.Valeurs.Item(nBarre).Valeur.ToString("# ##0.00 €")
    '        Else
    '            Me.LbCA.Text = "CA (" & sender.Legendes.Item(nBarre) & "):"
    '        End If
    '    End Sub

    '    Private Sub Graphique2_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer) Handles Graphique2.ClickLegende
    '        If sender.Valeurs.Item(nBarre).Valeur <> 0 Then
    '            Me.LbVolume.Text = "Volume (" & sender.Legendes.Item(nBarre) & "): " & sender.Valeurs.Item(nBarre).Valeur.ToString("# ##0.00")
    '        Else
    '            Me.LbVolume.Text = "Volume (" & sender.Legendes.Item(nBarre) & "):"
    '        End If
    '    End Sub
    '#End Region

#Region "Compta"
    Private Function InfosComptaModifiees(ByVal type As String) As Boolean
        If Me.ProduitBindingSource.Position < 0 Then Return False
        Dim rw As DataRow = Me.CurrentDrv.Row
        If rw.RowState = DataRowState.Modified Then
            Dim champCompte As String = "NCompte" & type
            Dim champActi As String = "NActivite" & type
            If TypeOf rw(champCompte) Is String AndAlso CStr(rw(champCompte)) = "" Then rw(champCompte) = DBNull.Value
            If TypeOf rw(champActi) Is String AndAlso CStr(rw(champActi)) = "" Then rw(champActi) = DBNull.Value
            Return Convert.ToString(rw(champCompte, DataRowVersion.Current)) <> Convert.ToString(rw(champCompte, DataRowVersion.Original)) _
            OrElse Convert.ToString(rw(champActi, DataRowVersion.Current)) <> Convert.ToString(rw(champActi, DataRowVersion.Original))
        End If
        Return False
    End Function

    Private Sub PropagerModifsComptaVente(ByVal codeProduit As String)
        PropagerModifsCompta(codeProduit, New String() {"VBonCommande", "VBonLivraison", "VFacture", "VDevis"}, "NCompteV", "NActiviteV", "de vente", False)
    End Sub

    Private Sub PropagerModifsComptaExport(ByVal codeProduit As String)
        PropagerModifsCompta(codeProduit, New String() {"VBonCommande", "VBonLivraison", "VFacture", "VDevis"}, "NCompteX", "NActiviteX", "de vente à l'export", True)
    End Sub

    Private Sub PropagerModifsComptaAchat(ByVal codeProduit As String)
        PropagerModifsCompta(codeProduit, New String() {"ABonReception", "AFacture"}, "NCompteA", "NActiviteA", "d'achat", False)
    End Sub

    Private Sub PropagerModifsCompta(ByVal codeProduit As String, ByVal nomsTable() As String, ByVal champCompte As String, ByVal champActi As String, ByVal typePiece As String, ByVal isExport As Boolean)
        Using s As New SqlProxy
            Dim cnt As Integer
            For Each nomTable As String In nomsTable
                Dim sql As String = String.Format("SELECT COUNT(*) " & _
                                                "FROM {0} f INNER JOIN {0}_Detail fd ON f.nDevis=fd.nDevis " & _
                                                "INNER JOIN entreprise e ON f.nClient=e.nEntreprise " & _
                                                "INNER JOIN produit p ON p.CodeProduit=fd.CodeProduit " & _
                                                "WHERE fd.CodeProduit={{0}} AND (ExportCompta=0 OR ExportCompta IS NULL) " & _
                                                "AND isnull(e.isExport,0)={{1}} " & _
                                                "AND ( fd.NCompte<>p.{1} OR fd.NActivite<>p.{2}) ", nomTable, champCompte, champActi)
                cnt += s.ExecuteScalarInt(SqlProxy.FormatSql(sql, codeProduit, isExport))
            Next
            If cnt > 0 Then
                If MsgBox(String.Format("Propager la modification aux pièces {0} non exportées existantes ?", typePiece), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Modifier les pieces de vente
                    For Each nomTable As String In nomsTable
                        Dim sql As String = String.Format("UPDATE {0}_detail " & _
                                                        "SET NCompte=p.{1},NActivite=p.{2} " & _
                                                        "FROM produit p,{0} f,Entreprise e " & _
                                                        "WHERE {0}_detail.codeproduit = p.codeproduit " & _
                                                        "AND f.ndevis={0}_detail.ndevis " & _
                                                        "AND f.nClient=e.nEntreprise " & _
                                                        "AND p.codeproduit={{0}} " & _
                                                        "AND isnull(e.IsExport,0)={{1}} " & _
                                                        "AND (f.exportcompta=0 OR f.exportcompta IS NULL)", nomTable, champCompte, champActi)
                        s.ExecuteNonQuery(SqlProxy.FormatSql(sql, codeProduit, isExport))
                    Next
                End If
            End If
        End Using
    End Sub
#End Region

#Region "Fonctionnel"
    Private Sub ImprimerEtiquette()
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Dim lab As New Dymo.LabelEngine
        Dim txPrintTx As New Dymo.TextObj
        Dim txPrintCB As New Dymo.BarCodeObj

        Try
            lab.OpenFile(Application.StartupPath & "\Produit.lwl")

            Dim NomProduit As String = ""
            Dim Description As String = ""
            Dim PrixU As Decimal = 0
            Dim Poids As Decimal = 0
            Dim Prix As Decimal = 0
            Dim CB As String = ""

            Dim rwv As DataRowView = Me.CurrentDrv

            NomProduit = Convert.ToString(rwv.Item("Libelle"))
            Description = Convert.ToString(rwv.Item("LibelleLong"))
            If Not rwv.Item("PrixVTTC") Is DBNull.Value Then
                PrixU = Convert.ToDecimal(rwv.Item("PrixVTTC"))
            End If
            If Not rwv.Item("CoefU2") Is DBNull.Value Then
                Poids = Convert.ToDecimal(rwv.Item("CoefU2"))
            End If
            CB = Convert.ToString(rwv.Item("CodeBarre"))
            Prix = Decimal.Round(Poids * PrixU, 2)

            Dim cl As DataColumn
            For Each cl In rwv.Row.Table.Columns
                If lab.PrintObject.FindObj(cl.ColumnName) <> 0 Then
                    If cl.ColumnName <> "Libelle" And cl.ColumnName <> "LibelleLong" And cl.ColumnName <> "PrixVTTC" And cl.ColumnName <> "CoefU2" Then
                        txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj(cl.ColumnName)), Dymo.TextObj)
                        If Not rwv.Item(cl.ColumnName) Is DBNull.Value Then
                            txPrintTx.TextAttributes.Text = Convert.ToString(rwv.Item(cl.ColumnName))
                        Else
                            txPrintTx.TextAttributes.Text = ""
                        End If
                    End If
                End If
            Next

            If lab.PrintObject.FindObj("Nom") <> 0 Then
                txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Nom")), Dymo.TextObj)
                txPrintTx.TextAttributes.Text = NomProduit
            End If
            If lab.PrintObject.FindObj("Description") <> 0 Then
                txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Description")), Dymo.TextObj)
                txPrintTx.TextAttributes.Text = Description
            End If
            If lab.PrintObject.FindObj("PrixU") <> 0 Then
                txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("PrixU")), Dymo.TextObj)
                txPrintTx.TextAttributes.Text = PrixU.ToString("# ##0.00 €")
            End If
            If lab.PrintObject.FindObj("Prix") <> 0 Then
                txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Prix")), Dymo.TextObj)
                txPrintTx.TextAttributes.Text = Prix.ToString("# ##0.00 €")
            End If
            If lab.PrintObject.FindObj("Poids") <> 0 Then
                txPrintTx = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Poids")), Dymo.TextObj)
                txPrintTx.TextAttributes.Text = Poids.ToString("0.00#")
            End If
            If lab.PrintObject.FindObj("CBProduit") <> 0 Then
                txPrintCB = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("CBProduit")), Dymo.BarCodeObj)
                txPrintCB.Text = CB.PadLeft(7, "0"c) & (Poids * 1000).ToString("0").PadLeft(5, "0"c)
            End If

            Dim q As Boolean, DeviceName As String, PortName As String, Copies As Integer
            DeviceName = "DYMO LabelWriter 320"
            'DeviceName = "Fax"
            'PortName = "USB001"
            'PortName = ""
            Copies = 1
            q = lab.PrintLabel(DeviceName, PortName, Copies, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetUniqueCodeProduit(ByVal strCodeProduit As String) As String
        If strCodeProduit = Me.CodeProduitEnCours Then Return strCodeProduit
        Dim res As String = strCodeProduit
        Dim nb As Integer = GetNbCodeProduit(res, -1)
        Dim n As Integer = 0
        While nb > 0
            n += 1
            res = strCodeProduit & n
            nb = GetNbCodeProduit(res, -1)
        End While
        Return res
    End Function

    Private Sub CheckCodeProduit(ByVal ctl As Control)
        'If ctl.Text.Length = 0 Then Exit Sub
        'Dim nb As Integer = GetNbCodeProduit(ctl.Text, CInt(Me.nProduit))
        'If nb > 0 Then ctl.Text = ""
        'If Me.gcProduit.GetErreur(ctl) = "Ce Code Produit existe déjà" Then
        '    Me.gcProduit.SetErreur(ctl, "")
        'End If
    End Sub

    Private Function GetNbCodeProduit(ByVal code As String, ByVal nProduit As Integer) As Integer
        Using s As New SqlProxy
            Return s.ExecuteScalarInt(SqlProxy.FormatSql("SELECT COUNT(*) AS nb FROM Produit WHERE CodeProduit={0} AND nProduit<>{1}", code, nProduit))
        End Using
    End Function
#End Region

#Region " Gestion Stocks "
    Private Sub ChargerStocks()
        Cursor.Current = Cursors.WaitCursor
        Try
            tbMarquerTermine.Visible = TbDetailLots.Checked
            tbMarquerNonTermine.Visible = TbDetailLots.Checked
            LotTermine.Visible = TbDetailLots.Checked
            NLotDataGridViewTextBoxColumn.Visible = TbDetailLots.Checked
            Me.StocksDatagridview.UseWaitCursor = True
            Application.DoEvents()
            Me.StocksDataSet.EnforceConstraints = False
            Me.EtatStockTA.FillEtatStock(Me.StocksDataSet.EtatStock, Today, Today, "Tous", TbDetailLots.Checked)
            Me.StocksBindingSource.Filter = FormatExpression("CodeProduit={0}", Me.CodeProduitEnCours)
        Finally
            Me.StocksDatagridview.UseWaitCursor = False
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub TbDetailLots_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDetailLots.CheckedChanged
        ChargerStocks()
    End Sub

    Private Sub tbMarquerTermine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMarquerTermine.Click
        Dim reload As Boolean = False
        Using dta As New StocksDataSetTableAdapters.LotsTerminesTA
            For Each r As DataGridViewRow In Me.StocksDatagridview.SelectedRows
                If r.DataBoundItem Is Nothing Then Continue For
                Dim drv As DataRowView = CType(r.DataBoundItem, DataRowView)
                If CBool(drv("LotTermine")) Then Continue For
                Dim nlot As String = Convert.ToString(drv("NLot"))
                Dim codepro As String = Convert.ToString(drv("CodeProduit"))
                If nlot.Length > 0 AndAlso codepro.Length > 0 Then
                    dta.Insert(nlot, codepro)
                    reload = True
                End If
            Next
        End Using
        If reload Then ChargerStocks()
    End Sub

    Private Sub tbMarquerNonTermine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMarquerNonTermine.Click
        Dim reload As Boolean = False
        Using dta As New StocksDataSetTableAdapters.LotsTerminesTA
            For Each r As DataGridViewRow In Me.StocksDatagridview.SelectedRows
                If r.DataBoundItem Is Nothing Then Continue For
                Dim drv As DataRowView = CType(r.DataBoundItem, DataRowView)
                If Not CBool(drv("LotTermine")) Then Continue For
                Dim nlot As String = Convert.ToString(drv("NLot"))
                Dim codepro As String = Convert.ToString(drv("CodeProduit"))
                If nlot.Length > 0 AndAlso codepro.Length > 0 Then
                    dta.Delete(nlot, codepro)
                    reload = True
                End If
            Next
        End Using
        If reload Then ChargerStocks()
    End Sub
#End Region

    Private Sub CompositionDataGridView_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CompositionDataGridView.CellContentDoubleClick
        If e.ColumnIndex = ColLibelle.Index Then
            dg_ZoomTextBoxCells(sender, e)
        End If
    End Sub

#Region "Méthodes diverses"
    Private Function SupprimerProduit() As Boolean
        If Me.ProduitBindingSource.Position < 0 Then Exit Function

        Try
            If Not CheckForProduitChild(Me.CodeProduitEnCours) Then Exit Function

            Me.ProduitBindingSource.RemoveCurrent()

            Using sqlConnection As New SqlConnection(My.Settings.AgrifactConnString)
                sqlConnection.Open()

                Dim sqlCommand As SqlCommand = sqlConnection.CreateCommand()
                Dim sqlTransaction As SqlTransaction

                sqlTransaction = sqlConnection.BeginTransaction("TransactionProduit")

                sqlCommand.Connection = sqlConnection
                sqlCommand.Transaction = sqlTransaction

                Try
                    'Suppression des compositions liées au produit
                    sqlCommand.CommandText = _
                      String.Format("DELETE FROM CompositionProduit WHERE CodeProduit='{0}'", Me.CodeProduitEnCours)

                    sqlCommand.ExecuteNonQuery()

                    sqlCommand.CommandText = _
                      String.Format("DELETE FROM CompositionProduit WHERE CodeProduitComposition='{0}'", Me.CodeProduitEnCours)

                    sqlCommand.ExecuteNonQuery()

                    'Suppression des tarifs liées au produit
                    sqlCommand.CommandText = _
                      String.Format("DELETE FROM Tarif_Detail WHERE CodeProduit='{0}'", Me.CodeProduitEnCours)

                    sqlCommand.ExecuteNonQuery()

                    'Suppression du produit
                    sqlCommand.CommandText = _
                      String.Format("DELETE FROM Produit WHERE CodeProduit='{0}'", Me.CodeProduitEnCours)

                    sqlCommand.ExecuteNonQuery()

                    sqlTransaction.Commit()

                    Return True
                Catch ex As Exception
                    If sqlTransaction IsNot Nothing Then sqlTransaction.Rollback()

                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function
#End Region

End Class
