Partial Public Class FrRequete

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
    Friend WithEvents TxRequete As System.Windows.Forms.TextBox
    Friend WithEvents TvObjects As System.Windows.Forms.TreeView
    Friend WithEvents openDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents saveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DgResults As System.Windows.Forms.DataGridView
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents status2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ctxObjets As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAlter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpResult As System.Windows.Forms.TabPage
    Friend WithEvents tpMessages As System.Windows.Forms.TabPage
    Friend WithEvents txMessages As System.Windows.Forms.TextBox
    Friend WithEvents SplitVertical As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitHorizontal As System.Windows.Forms.SplitContainer
    Friend WithEvents mnuExec As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents OuvrirFichierSQLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerLaRequêteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExporterRésultatsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtConnect As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SauvegarderLaBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurerUneBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Statusstrip As System.Windows.Forms.StatusStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrRequete))
        Me.status = New System.Windows.Forms.ToolStripStatusLabel
        Me.status2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TvObjects = New System.Windows.Forms.TreeView
        Me.ctxObjets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesc = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExec = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInsert = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAlter = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxRequete = New System.Windows.Forms.TextBox
        Me.openDialog = New System.Windows.Forms.OpenFileDialog
        Me.saveDialog = New System.Windows.Forms.SaveFileDialog
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtConnect = New System.Windows.Forms.ToolStripSplitButton
        Me.SauvegarderLaBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurerUneBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExplorateurDobjetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RésultatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.OuvrirFichierSQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnregistrerLaRequêteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExporterRésultatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnregistrerMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitExec = New System.Windows.Forms.ToolStripSplitButton
        Me.RequêteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DgResults = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.ctxTab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViderLesMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViderLesRésultatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tpResult = New System.Windows.Forms.TabPage
        Me.tpMessages = New System.Windows.Forms.TabPage
        Me.txMessages = New System.Windows.Forms.TextBox
        Me.SplitVertical = New System.Windows.Forms.SplitContainer
        Me.SplitHorizontal = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ExecuterDDLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Statusstrip = New System.Windows.Forms.StatusStrip
        Statusstrip.SuspendLayout()
        Me.ctxObjets.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.ctxTab.SuspendLayout()
        Me.tpResult.SuspendLayout()
        Me.tpMessages.SuspendLayout()
        Me.SplitVertical.Panel1.SuspendLayout()
        Me.SplitVertical.Panel2.SuspendLayout()
        Me.SplitVertical.SuspendLayout()
        Me.SplitHorizontal.Panel1.SuspendLayout()
        Me.SplitHorizontal.Panel2.SuspendLayout()
        Me.SplitHorizontal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Statusstrip
        '
        Statusstrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status, Me.status2})
        Statusstrip.Location = New System.Drawing.Point(0, 462)
        Statusstrip.Name = "Statusstrip"
        Statusstrip.Size = New System.Drawing.Size(768, 24)
        Statusstrip.TabIndex = 9
        Statusstrip.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(38, 19)
        Me.status.Text = "status"
        '
        'status2
        '
        Me.status2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.status2.Name = "status2"
        Me.status2.Size = New System.Drawing.Size(48, 19)
        Me.status2.Text = "status2"
        '
        'TvObjects
        '
        Me.TvObjects.ContextMenuStrip = Me.ctxObjets
        Me.TvObjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TvObjects.ImageIndex = 0
        Me.TvObjects.ImageList = Me.ImageList1
        Me.TvObjects.Location = New System.Drawing.Point(0, 0)
        Me.TvObjects.Name = "TvObjects"
        Me.TvObjects.SelectedImageIndex = 0
        Me.TvObjects.Size = New System.Drawing.Size(256, 435)
        Me.TvObjects.TabIndex = 1
        '
        'ctxObjets
        '
        Me.ctxObjets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesc, Me.ToolStripSeparator1, Me.mnuSelect, Me.mnuExec, Me.mnuInsert, Me.mnuUpdate, Me.mnuDelete, Me.mnuAlter})
        Me.ctxObjets.Name = "ctxObjets"
        Me.ctxObjets.Size = New System.Drawing.Size(174, 164)
        '
        'mnuDesc
        '
        Me.mnuDesc.Image = Global.Utilitaire.My.Resources.Resources.PropertiesHS
        Me.mnuDesc.Name = "mnuDesc"
        Me.mnuDesc.Size = New System.Drawing.Size(173, 22)
        Me.mnuDesc.Text = "Description..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'mnuSelect
        '
        Me.mnuSelect.Image = Global.Utilitaire.My.Resources.Resources.DataSet_TableView
        Me.mnuSelect.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(173, 22)
        Me.mnuSelect.Text = "Requête SELECT..."
        '
        'mnuExec
        '
        Me.mnuExec.Image = Global.Utilitaire.My.Resources.Resources.exec
        Me.mnuExec.Name = "mnuExec"
        Me.mnuExec.Size = New System.Drawing.Size(173, 22)
        Me.mnuExec.Text = "Requête EXEC..."
        '
        'mnuInsert
        '
        Me.mnuInsert.Image = Global.Utilitaire.My.Resources.Resources.AddTableHS
        Me.mnuInsert.Name = "mnuInsert"
        Me.mnuInsert.Size = New System.Drawing.Size(173, 22)
        Me.mnuInsert.Text = "Requête INSERT..."
        '
        'mnuUpdate
        '
        Me.mnuUpdate.Image = Global.Utilitaire.My.Resources.Resources.EditTableHS
        Me.mnuUpdate.Name = "mnuUpdate"
        Me.mnuUpdate.Size = New System.Drawing.Size(173, 22)
        Me.mnuUpdate.Text = "Requête UPDATE..."
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = Global.Utilitaire.My.Resources.Resources.DeleteHS
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(173, 22)
        Me.mnuDelete.Text = "Requête DELETE..."
        '
        'mnuAlter
        '
        Me.mnuAlter.Image = Global.Utilitaire.My.Resources.Resources.alter
        Me.mnuAlter.Name = "mnuAlter"
        Me.mnuAlter.Size = New System.Drawing.Size(173, 22)
        Me.mnuAlter.Text = "Requête ALTER..."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "db")
        Me.ImageList1.Images.SetKeyName(1, "folder")
        Me.ImageList1.Images.SetKeyName(2, "table")
        Me.ImageList1.Images.SetKeyName(3, "proc")
        Me.ImageList1.Images.SetKeyName(4, "vue")
        '
        'TxRequete
        '
        Me.TxRequete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxRequete.Location = New System.Drawing.Point(0, 0)
        Me.TxRequete.Multiline = True
        Me.TxRequete.Name = "TxRequete"
        Me.TxRequete.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxRequete.Size = New System.Drawing.Size(498, 163)
        Me.TxRequete.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtConnect, Me.ToolStripDropDownButton3, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.SplitExec})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtConnect
        '
        Me.BtConnect.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SauvegarderLaBaseToolStripMenuItem, Me.RestaurerUneBaseToolStripMenuItem})
        Me.BtConnect.Image = Global.Utilitaire.My.Resources.Resources.connect
        Me.BtConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtConnect.Name = "BtConnect"
        Me.BtConnect.Size = New System.Drawing.Size(96, 22)
        Me.BtConnect.Text = "Connexion"
        '
        'SauvegarderLaBaseToolStripMenuItem
        '
        Me.SauvegarderLaBaseToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.savedatabase
        Me.SauvegarderLaBaseToolStripMenuItem.Name = "SauvegarderLaBaseToolStripMenuItem"
        Me.SauvegarderLaBaseToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SauvegarderLaBaseToolStripMenuItem.Text = "Sauvegarder la base..."
        '
        'RestaurerUneBaseToolStripMenuItem
        '
        Me.RestaurerUneBaseToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.restoredatabase
        Me.RestaurerUneBaseToolStripMenuItem.Name = "RestaurerUneBaseToolStripMenuItem"
        Me.RestaurerUneBaseToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.RestaurerUneBaseToolStripMenuItem.Text = "Restaurer une base..."
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExplorateurDobjetsToolStripMenuItem, Me.RésultatsToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripDropDownButton3.Text = "Affichage"
        '
        'ExplorateurDobjetsToolStripMenuItem
        '
        Me.ExplorateurDobjetsToolStripMenuItem.Checked = True
        Me.ExplorateurDobjetsToolStripMenuItem.CheckOnClick = True
        Me.ExplorateurDobjetsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExplorateurDobjetsToolStripMenuItem.Name = "ExplorateurDobjetsToolStripMenuItem"
        Me.ExplorateurDobjetsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.ExplorateurDobjetsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ExplorateurDobjetsToolStripMenuItem.Text = "Explorateur d'objets"
        '
        'RésultatsToolStripMenuItem
        '
        Me.RésultatsToolStripMenuItem.Checked = True
        Me.RésultatsToolStripMenuItem.CheckOnClick = True
        Me.RésultatsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RésultatsToolStripMenuItem.Name = "RésultatsToolStripMenuItem"
        Me.RésultatsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.RésultatsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RésultatsToolStripMenuItem.Text = "Résultats"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirFichierSQLToolStripMenuItem, Me.EnregistrerLaRequêteToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Utilitaire.My.Resources.Resources.VSProject_script
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripDropDownButton1.Text = "Script SQL"
        '
        'OuvrirFichierSQLToolStripMenuItem
        '
        Me.OuvrirFichierSQLToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.open
        Me.OuvrirFichierSQLToolStripMenuItem.Name = "OuvrirFichierSQLToolStripMenuItem"
        Me.OuvrirFichierSQLToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OuvrirFichierSQLToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.OuvrirFichierSQLToolStripMenuItem.Text = "Ouvrir un fichier SQL..."
        '
        'EnregistrerLaRequêteToolStripMenuItem
        '
        Me.EnregistrerLaRequêteToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.save
        Me.EnregistrerLaRequêteToolStripMenuItem.Name = "EnregistrerLaRequêteToolStripMenuItem"
        Me.EnregistrerLaRequêteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.EnregistrerLaRequêteToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.EnregistrerLaRequêteToolStripMenuItem.Text = "Enregistrer la requête..."
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExporterRésultatsToolStripMenuItem, Me.EnregistrerMessagesToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = Global.Utilitaire.My.Resources.Resources.table
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripDropDownButton2.Text = "Résultats"
        '
        'ExporterRésultatsToolStripMenuItem
        '
        Me.ExporterRésultatsToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.export
        Me.ExporterRésultatsToolStripMenuItem.Name = "ExporterRésultatsToolStripMenuItem"
        Me.ExporterRésultatsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ExporterRésultatsToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ExporterRésultatsToolStripMenuItem.Text = "Exporter résultats..."
        '
        'EnregistrerMessagesToolStripMenuItem
        '
        Me.EnregistrerMessagesToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.save
        Me.EnregistrerMessagesToolStripMenuItem.Name = "EnregistrerMessagesToolStripMenuItem"
        Me.EnregistrerMessagesToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.EnregistrerMessagesToolStripMenuItem.Text = "Enregistrer messages..."
        '
        'SplitExec
        '
        Me.SplitExec.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequêteToolStripMenuItem, Me.ExecuterDDLToolStripMenuItem})
        Me.SplitExec.Image = Global.Utilitaire.My.Resources.Resources.exec
        Me.SplitExec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SplitExec.Name = "SplitExec"
        Me.SplitExec.Size = New System.Drawing.Size(83, 22)
        Me.SplitExec.Text = "Executer"
        '
        'RequêteToolStripMenuItem
        '
        Me.RequêteToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.execresults
        Me.RequêteToolStripMenuItem.Name = "RequêteToolStripMenuItem"
        Me.RequêteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RequêteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RequêteToolStripMenuItem.Text = "Requête"
        '
        'DgResults
        '
        Me.DgResults.AllowUserToAddRows = False
        Me.DgResults.AllowUserToDeleteRows = False
        Me.DgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgResults.Location = New System.Drawing.Point(3, 3)
        Me.DgResults.Name = "DgResults"
        Me.DgResults.ReadOnly = True
        Me.DgResults.Size = New System.Drawing.Size(484, 237)
        Me.DgResults.TabIndex = 8
        '
        'TabControl1
        '
        Me.TabControl1.ContextMenuStrip = Me.ctxTab
        Me.TabControl1.Controls.Add(Me.tpResult)
        Me.TabControl1.Controls.Add(Me.tpMessages)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(498, 270)
        Me.TabControl1.TabIndex = 10
        '
        'ctxTab
        '
        Me.ctxTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViderLesMessagesToolStripMenuItem, Me.ViderLesRésultatsToolStripMenuItem})
        Me.ctxTab.Name = "ctxTab"
        Me.ctxTab.Size = New System.Drawing.Size(182, 48)
        '
        'ViderLesMessagesToolStripMenuItem
        '
        Me.ViderLesMessagesToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.clear
        Me.ViderLesMessagesToolStripMenuItem.Name = "ViderLesMessagesToolStripMenuItem"
        Me.ViderLesMessagesToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ViderLesMessagesToolStripMenuItem.Text = "Effacer les messages"
        '
        'ViderLesRésultatsToolStripMenuItem
        '
        Me.ViderLesRésultatsToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.clear
        Me.ViderLesRésultatsToolStripMenuItem.Name = "ViderLesRésultatsToolStripMenuItem"
        Me.ViderLesRésultatsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ViderLesRésultatsToolStripMenuItem.Text = "Effacer les résultats"
        '
        'tpResult
        '
        Me.tpResult.Controls.Add(Me.DgResults)
        Me.tpResult.ImageKey = "table"
        Me.tpResult.Location = New System.Drawing.Point(4, 23)
        Me.tpResult.Name = "tpResult"
        Me.tpResult.Padding = New System.Windows.Forms.Padding(3)
        Me.tpResult.Size = New System.Drawing.Size(490, 243)
        Me.tpResult.TabIndex = 0
        Me.tpResult.Text = "Résultats"
        Me.tpResult.UseVisualStyleBackColor = True
        '
        'tpMessages
        '
        Me.tpMessages.Controls.Add(Me.txMessages)
        Me.tpMessages.ImageKey = "proc"
        Me.tpMessages.Location = New System.Drawing.Point(4, 23)
        Me.tpMessages.Name = "tpMessages"
        Me.tpMessages.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessages.Size = New System.Drawing.Size(490, 245)
        Me.tpMessages.TabIndex = 1
        Me.tpMessages.Text = "Messages"
        Me.tpMessages.UseVisualStyleBackColor = True
        '
        'txMessages
        '
        Me.txMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txMessages.Location = New System.Drawing.Point(3, 3)
        Me.txMessages.Multiline = True
        Me.txMessages.Name = "txMessages"
        Me.txMessages.ReadOnly = True
        Me.txMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txMessages.Size = New System.Drawing.Size(484, 239)
        Me.txMessages.TabIndex = 0
        '
        'SplitVertical
        '
        Me.SplitVertical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitVertical.Location = New System.Drawing.Point(5, 0)
        Me.SplitVertical.Name = "SplitVertical"
        '
        'SplitVertical.Panel1
        '
        Me.SplitVertical.Panel1.Controls.Add(Me.TvObjects)
        Me.SplitVertical.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        '
        'SplitVertical.Panel2
        '
        Me.SplitVertical.Panel2.Controls.Add(Me.SplitHorizontal)
        Me.SplitVertical.Size = New System.Drawing.Size(758, 437)
        Me.SplitVertical.SplitterDistance = 256
        Me.SplitVertical.TabIndex = 12
        '
        'SplitHorizontal
        '
        Me.SplitHorizontal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitHorizontal.Location = New System.Drawing.Point(0, 0)
        Me.SplitHorizontal.Name = "SplitHorizontal"
        Me.SplitHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitHorizontal.Panel1
        '
        Me.SplitHorizontal.Panel1.Controls.Add(Me.TxRequete)
        '
        'SplitHorizontal.Panel2
        '
        Me.SplitHorizontal.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitHorizontal.Size = New System.Drawing.Size(498, 437)
        Me.SplitHorizontal.SplitterDistance = 163
        Me.SplitHorizontal.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitVertical)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel1.Size = New System.Drawing.Size(768, 437)
        Me.Panel1.TabIndex = 3
        '
        'ExecuterDDLToolStripMenuItem
        '
        Me.ExecuterDDLToolStripMenuItem.Image = Global.Utilitaire.My.Resources.Resources.exec
        Me.ExecuterDDLToolStripMenuItem.Name = "ExecuterDDLToolStripMenuItem"
        Me.ExecuterDDLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExecuterDDLToolStripMenuItem.Text = "Executer DDL"
        '
        'FrRequete
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(768, 486)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Statusstrip)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(656, 408)
        Me.Name = "FrRequete"
        Me.Text = "Requetes"
        Statusstrip.ResumeLayout(False)
        Statusstrip.PerformLayout()
        Me.ctxObjets.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ctxTab.ResumeLayout(False)
        Me.tpResult.ResumeLayout(False)
        Me.tpMessages.ResumeLayout(False)
        Me.tpMessages.PerformLayout()
        Me.SplitVertical.Panel1.ResumeLayout(False)
        Me.SplitVertical.Panel2.ResumeLayout(False)
        Me.SplitVertical.ResumeLayout(False)
        Me.SplitHorizontal.Panel1.ResumeLayout(False)
        Me.SplitHorizontal.Panel1.PerformLayout()
        Me.SplitHorizontal.Panel2.ResumeLayout(False)
        Me.SplitHorizontal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExplorateurDobjetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RésultatsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxTab As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViderLesMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViderLesRésultatsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitExec As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents RequêteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ExecuterDDLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
