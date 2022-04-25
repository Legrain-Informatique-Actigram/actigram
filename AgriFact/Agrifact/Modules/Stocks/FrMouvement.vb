Imports GRC
Imports Actigram.Windows.Forms
Imports System.Data.SqlClient

Public Class FrMouvement
    Inherits GRC.FrBase

#Region "Ctors"
    Public Sub New()
        MyBase.New()
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nMouvement As Object)
        Me.New()
        Me.id = nMouvement
    End Sub
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
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents GestionControles2 As GestionControles
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImprEt As System.Windows.Forms.ToolStripButton
    Friend WithEvents MouvementDetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents MouvementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ctxLigne As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DupliquerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbCreerLot As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColCodeProduit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBtSelectProd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Nlot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBtLot As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLibU1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLibU2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouvementDetailBindingSource As System.Windows.Forms.BindingSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrMouvement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbSuppr = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprEt = New System.Windows.Forms.ToolStripButton
        Me.TbCreerLot = New System.Windows.Forms.ToolStripButton
        Me.MouvementDetailDataGridView = New System.Windows.Forms.DataGridView
        Me.ctxLigne = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DupliquerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GestionControles2 = New AgriFact.GestionControles
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.MouvementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MouvementDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColCodeProduit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBtSelectProd = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Nlot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBtLot = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ColLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColUnite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLibU1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColUnite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLibU2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.MouvementDetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxLigne.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MouvementDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbClose, Me.TbSave, Me.TbSuppr, Me.ToolStripSeparator1, Me.TbImprEt, Me.TbCreerLot})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(576, 39)
        Me.ToolStrip1.TabIndex = 24
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
        'TbCreerLot
        '
        Me.TbCreerLot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCreerLot.Image = Global.AgriFact.My.Resources.Resources.Cube
        Me.TbCreerLot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbCreerLot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCreerLot.Name = "TbCreerLot"
        Me.TbCreerLot.Size = New System.Drawing.Size(31, 36)
        Me.TbCreerLot.Text = "Créer un lot"
        '
        'MouvementDetailDataGridView
        '
        Me.MouvementDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MouvementDetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodeProduit, Me.ColBtSelectProd, Me.Nlot, Me.ColBtLot, Me.ColLibelle, Me.ColUnite1, Me.ColLibU1, Me.ColUnite2, Me.ColLibU2})
        Me.MouvementDetailDataGridView.ContextMenuStrip = Me.ctxLigne
        Me.MouvementDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MouvementDetailDataGridView.Location = New System.Drawing.Point(5, 5)
        Me.MouvementDetailDataGridView.Name = "MouvementDetailDataGridView"
        Me.MouvementDetailDataGridView.Size = New System.Drawing.Size(566, 235)
        Me.MouvementDetailDataGridView.TabIndex = 37
        '
        'ctxLigne
        '
        Me.ctxLigne.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem, Me.DupliquerToolStripMenuItem})
        Me.ctxLigne.Name = "ctxLigne"
        Me.ctxLigne.Size = New System.Drawing.Size(130, 48)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'DupliquerToolStripMenuItem
        '
        Me.DupliquerToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.CopyHS
        Me.DupliquerToolStripMenuItem.Name = "DupliquerToolStripMenuItem"
        Me.DupliquerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DupliquerToolStripMenuItem.Text = "Dupliquer"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel1.Controls.Add(Me.GestionControles2)
        Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(547, 211)
        Me.GradientPanel1.TabIndex = 0
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
        Me.GradientCaption1.Size = New System.Drawing.Size(547, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Mouvement"
        '
        'GestionControles2
        '
        Me.GestionControles2.AutorisationListe = Nothing
        Me.GestionControles2.Autorisations = ""
        Me.GestionControles2.AutoriseAjt = True
        Me.GestionControles2.AutoriseModif = True
        Me.GestionControles2.AutoriseSuppr = True
        Me.GestionControles2.AutoSize = True
        Me.GestionControles2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles2.BackColor = System.Drawing.Color.Transparent
        Me.GestionControles2.DataSource = Nothing
        Me.GestionControles2.DsBase = Nothing
        Me.GestionControles2.FiltreAffichage = ""
        Me.GestionControles2.Label1Top = 10
        Me.GestionControles2.LabelLeft = 1
        Me.GestionControles2.LargeurText = 230
        Me.GestionControles2.LiaisonDonnees = True
        Me.GestionControles2.Lien = Nothing
        Me.GestionControles2.LigneHauteur = 20
        Me.GestionControles2.LigneIntervale = 5
        Me.GestionControles2.Location = New System.Drawing.Point(3, 24)
        Me.GestionControles2.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles2.Name = "GestionControles2"
        Me.GestionControles2.NomTableConfig = Nothing
        Me.GestionControles2.NuméroNiveau1 = 0
        Me.GestionControles2.Size = New System.Drawing.Size(541, 178)
        Me.GestionControles2.TabIndex = 18
        Me.GestionControles2.Table = "Mouvement"
        Me.GestionControles2.TableListeChoix = "ListeChoix"
        Me.GestionControles2.TableParam = "Niveau2"
        Me.GestionControles2.TexteLeft = 115
        Me.GestionControles2.TypeRecherche = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.GradientPanel1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.MouvementDetailDataGridView)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Size = New System.Drawing.Size(576, 504)
        Me.SplitContainer1.SplitterDistance = 255
        Me.SplitContainer1.TabIndex = 39
        '
        'ColCodeProduit
        '
        Me.ColCodeProduit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColCodeProduit.DataPropertyName = "CodeProduit"
        Me.ColCodeProduit.HeaderText = "Code"
        Me.ColCodeProduit.Name = "ColCodeProduit"
        Me.ColCodeProduit.Width = 57
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
        'Nlot
        '
        Me.Nlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Nlot.DataPropertyName = "NLot"
        Me.Nlot.HeaderText = "Lot"
        Me.Nlot.Name = "Nlot"
        Me.Nlot.ReadOnly = True
        Me.Nlot.Width = 47
        '
        'ColBtLot
        '
        Me.ColBtLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColBtLot.DataPropertyName = "NLot"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Wingdings 3", 8.25!)
        DataGridViewCellStyle2.NullValue = "€"
        Me.ColBtLot.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColBtLot.HeaderText = ""
        Me.ColBtLot.Name = "ColBtLot"
        Me.ColBtLot.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColBtLot.Text = "€"
        Me.ColBtLot.ToolTipText = "Sélectionner un lot"
        Me.ColBtLot.UseColumnTextForButtonValue = True
        Me.ColBtLot.Width = 20
        '
        'ColLibelle
        '
        Me.ColLibelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColLibelle.DataPropertyName = "Libelle"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColLibelle.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColLibelle.HeaderText = "Libelle"
        Me.ColLibelle.Name = "ColLibelle"
        '
        'ColUnite1
        '
        Me.ColUnite1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColUnite1.DataPropertyName = "Unite1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        Me.ColUnite1.DefaultCellStyle = DataGridViewCellStyle4
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.ColUnite2.DefaultCellStyle = DataGridViewCellStyle5
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
        'FrMouvement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 543)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrMouvement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mouvements"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.MouvementDetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxLigne.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MouvementDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Propriétés"
    Private modif As Boolean = False
    Private _NomTable As String = "Mouvement"
    Private _NomTableDetail As String = "Mouvement_Detail"
    Private _NomTableCle As String = "nMouvement"
    Private _NomTableDetailCle As String = "nMouvementDetail"
    Private _NomLiaison As String = "MouvementMouvement_Detail"

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.MouvementBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.MouvementBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nMouvement() As Integer
        Get
            If Me.MouvementBindingSource.Position < 0 Then Return -1
            Return CInt(Me.CurrentDrv("nMouvement"))
        End Get
    End Property

    Private _type As Stocks.TypeMouvement = Stocks.TypeMouvement.None
    Public Property TypeMouvement() As Stocks.TypeMouvement
        Get
            Return _type
        End Get
        Set(ByVal value As Stocks.TypeMouvement)
            _type = value
            Select Case value
                Case Stocks.TypeMouvement.Transfert_dépôt
                    Me.GestionControles2.NuméroNiveau1 = 0
                Case Else
                    Me.GestionControles2.NuméroNiveau1 = 9
            End Select
        End Set
    End Property
#End Region

#Region "Données"
    Private Sub ChargerProduits(ByVal s As SqlProxy)
        Me.ds.EnforceConstraints = False
        DefinitionDonnees.Instance.Fill(ds, "Famille", s)
        DefinitionDonnees.Instance.Fill(ds, "Produit", s, "Inactif=0")
        Me.ds.EnforceConstraints = True
    End Sub

    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            ChargerProduits(s)
            GestionControles.FillTablesConfig(Me.ds, s)
            If CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("{0}={1}", _NomTableCle, Me.id)
                DefinitionDonnees.Instance.Fill(ds, _NomTable, s, where)
                DefinitionDonnees.Instance.Fill(ds, _NomTableDetail, s, where)
                With Me.MouvementBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With
                Me.TypeMouvement = EnumParse(Of Stocks.TypeMouvement)(Convert.ToString(Me.CurrentDrv("TypeMouvement")))
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, _NomTable, s)
                DefinitionDonnees.Instance.FillSchema(ds, _NomTableDetail, s)
                'Databinding
                With Me.MouvementBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With
                'Création de la nouvelle ligne
                Me.MouvementBindingSource.AddNew()
                With Me.CurrentDrv
                    '.Item("nPiece") = Pieces.GetNFacture(Pieces.TypePieces.Mouvement)
                    .Item("DateMouvement") = Today
                    .Item("TypeMouvement") = Me.TypeMouvement.ToString.Replace("_", " ")
                End With
                Me.MouvementBindingSource.EndEdit()
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)

        ConfigDataTableEvents(Me.ds.Tables(_NomTable), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables(_NomTableDetail), AddressOf Datarowchanged, True)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        With Me.MouvementDetailBindingSource
            .DataSource = Me.MouvementBindingSource
            .DataMember = _NomLiaison
        End With
        Me.MouvementDetailDataGridView.AutoGenerateColumns = False
        Me.MouvementDetailDataGridView.DataSource = Me.MouvementDetailBindingSource
        Me.GestionControles2.SetDataSource(CType(Me.MouvementBindingSource.List, DataView))
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        res = Me.GestionControles2.VerifContraintes
        If res Then
            res = MyBase.Validate()
        End If
        Return res
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
        Me.MouvementBindingSource.EndEdit()
        Me.MouvementDetailBindingSource.EndEdit()
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
        'Enregistrer
        If Not Me.Validate() Then Return False
        Me.MouvementBindingSource.EndEdit()
        Me.MouvementDetailBindingSource.EndEdit()
        If ds.HasChanges Then
            If UpdateBase() Then
                modif = True
                Return True
            End If
        End If
        Return False
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {_NomTable, _NomTableDetail}
            Using s As New SqlProxy
                If IsDBNull(Me.CurrentDrv("nPiece")) Then
                    Me.CurrentDrv("nPiece") = Pieces.GetNFacture(s, Pieces.TypePieces.Mouvement)
                    Me.MouvementBindingSource.EndEdit()
                End If
                s.UpdateTables(ds, strNomTable)
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles2.MustRefreshTable
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

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles2.MustUpdateTable
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

    Private Sub RechargerProduit(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.UserClosing Or CloseReason.None
                Cursor.Current = Cursors.WaitCursor
                Using s As New SqlProxy
                    ChargerProduits(s)
                End Using
                Cursor.Current = Cursors.Default
        End Select
    End Sub
#End Region

#Region " Form events "
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.MouvementBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nMouvement)
                End If
                If modif Then Me.DialogResult = Windows.Forms.DialogResult.OK
        End Select
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.MouvementDetailDataGridView, False)
        With MouvementDetailDataGridView
            AddHandler .MouseDown, AddressOf dg_GestionClicDroit
        End With
        AddHandler Me.GestionControles2.CtlValidated, AddressOf CtlValidated
        ChargerDonnees()
        MajBoutons()
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel1.Height = Math.Max(Me.SplitContainer1.Panel1.Height - Me.SplitContainer1.Panel1.Padding.Top - Me.SplitContainer1.Panel1.Padding.Bottom, Me.GestionControles2.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub SplitContainer1_Panel1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.Resize
        Me.GradientPanel1.Height = Math.Max(Me.SplitContainer1.Panel1.Height - Me.SplitContainer1.Panel1.Padding.Top - Me.SplitContainer1.Panel1.Padding.Bottom, Me.GestionControles2.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.MouvementBindingSource.EndEdit()
    End Sub
#End Region

#Region " Toolbar "
    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.MouvementBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbSuppr.Enabled = rowExists
        Me.TbImprEt.Enabled = rowExists
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.MouvementBindingSource.Position < 0 Then Exit Sub
        Try
            Me.MouvementBindingSource.RemoveCurrent()
            If UpdateBase() Then Me.Close()
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbImprEt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprEt.Click
        If Me.MouvementBindingSource.Position < 0 Then Exit Sub
        Me.MouvementBindingSource.EndEdit()
        If Me.TypeMouvement = Stocks.TypeMouvement.Inventaire Then
            Cursor.Current = Cursors.WaitCursor
            FrInventaire.ImprimerInventaire(CDate(Me.CurrentDrv("DateMouvement")), CStr(Me.CurrentDrv("DepotDest")), False)
            Cursor.Current = Cursors.Default
        Else
            ImprimerMouvement(Me.CurrentDrv)
        End If
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbCreerLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCreerLot.Click
        Using fr As New FrLot
            fr.ShowDialog(Me)
        End Using
    End Sub
#End Region

#Region " Grille "
    Private Sub MouvementDetailDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MouvementDetailDataGridView.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        Select Case MouvementDetailDataGridView.Columns(e.ColumnIndex).DataPropertyName
            Case "CodeProduit"
                Dim codeProduit As String = Convert.ToString(MouvementDetailDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                Dim drProduit As DataRow = SelectSingleRow(Of DataRow)(Me.ds.Tables("Produit"), FormatExpression("CodeProduit={0}", codeProduit), "")
                If drProduit IsNot Nothing Then
                    Dim drDetail As DataRow = CType(MouvementDetailBindingSource.Current, DataRowView).Row
                    If Not drProduit.IsNull("Libelle") Then drDetail("Libelle") = drProduit("Libelle")
                    If Not drProduit.IsNull("Unite1") Then drDetail("LibUnite1") = drProduit("Unite1")
                    If Not drProduit.IsNull("Unite2") Then drDetail("LibUnite2") = drProduit("Unite2")
                    Me.MouvementDetailBindingSource.ResetCurrentItem()
                    Me.MouvementDetailDataGridView.Refresh()
                    ConfigDetailRow(MouvementDetailDataGridView.CurrentRow, CType(MouvementDetailBindingSource.Current, DataRowView))
                End If
                'Case "NLot"
                '    Dim drDetail As DataRow = CType(MouvementDetailBindingSource.Current, DataRowView).Row
                '    Me.MouvementDetailBindingSource.ResetCurrentItem()
                '    Me.MouvementDetailDataGridView.Refresh()
            Case "Unite1"
                Dim u1 As Object = MouvementDetailDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If Not IsDBNull(u1) Then
                    Dim du As Decimal = CDec(u1)
                    If du - Decimal.Round(du, 3) <> 0 Then
                        MsgBox("Attention, le nombre d'unité 1 sera tronqué à 3 décimales", MsgBoxStyle.Exclamation)
                    End If
                End If
                Dim drDetail As DataRow = CType(MouvementDetailBindingSource.Current, DataRowView).Row
                Dim drProduit As DataRow = SelectSingleRow(Of DataRow)(ds.Tables("Produit"), FormatExpression("CodeProduit={0}", drDetail("CodeProduit")), "")
                If drProduit IsNot Nothing Then
                    If Not drProduit.IsNull("CoefU2") Then
                        If IsDBNull(u1) Then
                            drDetail("Unite2") = DBNull.Value
                        Else
                            drDetail("Unite2") = CDec(drProduit("CoefU2")) * CDec(u1)
                        End If
                        Me.MouvementDetailBindingSource.ResetCurrentItem()
                        Me.MouvementDetailDataGridView.Refresh()
                    End If
                End If
            Case "Unite2"
                Dim u2 As Object = MouvementDetailDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If Not IsDBNull(u2) Then
                    Dim du As Decimal = CDec(u2)
                    If du - Decimal.Round(du, 3) <> 0 Then
                        MsgBox("Attention, le nombre d'unité 2 sera tronqué à 3 décimales", MsgBoxStyle.Exclamation)
                    End If
                End If
        End Select
    End Sub

    Private Sub MouvementDetailDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles MouvementDetailDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In MouvementDetailDataGridView.Rows
                ConfigDetailRow(r)
            Next
        ElseIf e.ListChangedType = System.ComponentModel.ListChangedType.ItemChanged Then
            ConfigDetailRow(MouvementDetailDataGridView.CurrentRow)
        End If
    End Sub

    Private Sub MouvementDetailDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MouvementDetailDataGridView.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Me.ColBtSelectProd.Index Then
            ShowSelectionProduit(Me.MouvementDetailDataGridView.Rows(e.RowIndex).Cells(ColCodeProduit.Index))
        ElseIf e.ColumnIndex = Me.ColBtLot.Index Then
            ShowSelectionLot(Me.MouvementDetailDataGridView.Rows(e.RowIndex).Cells(Nlot.Index))
        End If
    End Sub

    Private Sub MouvementDetailDataGridView_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MouvementDetailDataGridView.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = ColCodeProduit.Index Then
            Dim cell As DataGridViewTextBoxCell = CType(Me.MouvementDetailDataGridView.Rows(e.RowIndex).Cells(ColCodeProduit.Index), DataGridViewTextBoxCell)
            If Convert.ToString(cell.Value) <> "" Then
                Dim FrP As New FrProduit(Convert.ToString(cell.Value))
                AddHandler FrP.FormClosed, AddressOf RechargerProduit
                FrP.Owner = Me
                FrP.Show()
            End If
        ElseIf e.ColumnIndex = Nlot.Index Then
            Dim cell As DataGridViewTextBoxCell = CType(Me.MouvementDetailDataGridView.Rows(e.RowIndex).Cells(Nlot.Index), DataGridViewTextBoxCell)
            Dim FrP As New FrLot(Convert.ToString(cell.Value))
            FrP.Owner = Me
            FrP.Show()
        ElseIf e.ColumnIndex = ColLibelle.Index Then
            dg_ZoomTextBoxCells(sender, e)
        End If
    End Sub

    Private Sub SupprimerLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Me.MouvementDetailDataGridView.CurrentRow.IsNewRow Then
            Me.MouvementDetailDataGridView.CancelEdit()
            Exit Sub
        End If
        Try
            Me.MouvementDetailBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub DupliquerLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripMenuItem.Click
        If Me.MouvementDetailDataGridView.CurrentRow.IsNewRow Then Exit Sub
        If Me.MouvementDetailBindingSource.Position < 0 Then Exit Sub
        Dim curDrv As DataRowView = CType(Me.MouvementDetailBindingSource.Current, DataRowView)
        Dim newDrv As DataRowView = CType(Me.MouvementDetailBindingSource.AddNew, DataRowView)
        If Not newDrv Is Nothing Then
            newDrv.BeginEdit()
            CopyRow(curDrv.Row, newDrv.Row)
            newDrv.EndEdit()
            Me.MouvementDetailBindingSource.ResetBindings(False)
        End If
    End Sub

    Private Sub ConfigDetailRow(ByVal r As DataGridViewRow)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim drv As DataRowView = Cast(Of DataRowView)(r.DataBoundItem)
        ConfigDetailRow(r, drv)
    End Sub

    Private Sub ConfigDetailRow(ByVal r As DataGridViewRow, ByVal drv As DataRowView)
        r.Cells(Me.ColUnite1.Index).ReadOnly = (Convert.ToString(drv("LibUnite1")).Length = 0)
        r.Cells(Me.ColUnite2.Index).ReadOnly = (Convert.ToString(drv("LibUnite2")).Length = 0)
    End Sub

#Region " Selection Produit "
    Private _stop As Boolean = False
    Private Sub ShowSelectionProduit(ByVal cell As DataGridViewCell)
        If _stop Then Exit Sub
        _stop = True

        'Dim filtre As String = "Inactif=False AND GestionStock=True"
        Dim dvS As DataView = New DataView(Me.ds.Tables("Produit"), "", "Libelle", DataViewRowState.CurrentRows)

        'Création du Dataview source
        Dim filtres As New List(Of String)
        Dim filtreBase As String = String.Join(" AND ", filtres.ToArray)
        'Filtrage produits actifs seulement
        filtres.Add("Inactif=False")
        'Filtrage produits avec gestion de stock
        filtres.Add("GestionStock=True")
        'Filtrage par code produit
        Dim code As String = Convert.ToString(cell.OwningRow.Cells(ColCodeProduit.Index).Value)
        If code.Length > 0 Then
            filtres.Add(FormatExpression("(CodeProduit like {0} OR Libelle like {0})", code & "*"))
        End If

        If filtres.Count > 0 Then dvs.RowFilter = String.Join(" AND ", filtres.ToArray)
        dvs.Sort = "Libelle"

        Dim frSelectionProduit As New FrSelection(cell, 0)
        With frSelectionProduit
            AddHandler .Closed, AddressOf frSelectionProduit_Closed
            .StartPosition = FormStartPosition.Manual
            .Location = GetPosition(frSelectionProduit, cell)

            .AddColumn("Code", "CodeProduit", 60, DataGridViewContentAlignment.MiddleCenter)
            .AddColumn("Produit", "Libelle", 150, DataGridViewContentAlignment.MiddleLeft, , DataGridViewAutoSizeColumnMode.Fill)

            .DataSource = dvS

            .Owner = Me
            .Show()

            With .Liste
                .ClearSelection()
                For Each r As DataGridViewRow In .Rows
                    If r.Cells("Libelle").Value.ToString.ToUpper.StartsWith(Convert.ToString(cell.Value).ToUpper) Then
                        r.Selected = True
                        Exit For
                    End If
                Next
            End With
        End With
    End Sub

    Private Sub frSelectionProduit_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MouvementDetailDataGridView.CurrentCell = Me.MouvementDetailDataGridView.CurrentRow.Cells(Me.ColCodeProduit.Index)
        _stop = False
    End Sub

    Private Function GetPosition(ByVal fr As Form, ByVal cell As DataGridViewCell) As Point
        Dim r As Rectangle = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
        Dim pt As Point = cell.DataGridView.PointToScreen(r.Location)
        pt.Offset(0, r.Height)
        If pt.Y + fr.Height > My.Computer.Screen.Bounds.Height Then
            pt.Offset(0, -(r.Height + fr.Height))
        End If
        Return pt
    End Function
#End Region

#Region " Selection Lot "
    Private Sub ShowSelectionLot(ByVal cell As DataGridViewCell)
        If _stop Then Exit Sub
        Dim codeProduit As String = Convert.ToString(cell.OwningRow.Cells(ColCodeProduit.Index).Value)
        If codeProduit = "" Then Exit Sub

        _stop = True
        Dim dt As StocksDataSet.LotDataTable

        'Recherche de la valeur du paramètre "Création des lots dans Solstyce"
        Dim creerLotDansSolstyce As Boolean = Me.RecupererValeurCreationLotsSolstyce()

        'Si le paramètre "Création des lots dans Solstyce" est coché
        If (creerLotDansSolstyce) Then
            Using dta As New StocksDataSetTableAdapters.LotTA
                'MODIF TV 30/01/2012 --> MODIF SUPPRIMEE LE 05/10/2012 car ne marche pas chez Micouleau
                'dt = dta.GetDataLotsNonTerminesByCodeProduit(codeProduit)
                '----------------------------------

                Select Case Me.TypeMouvement
                    Case Stocks.TypeMouvement.Entrées, Stocks.TypeMouvement.Conditionnement, Stocks.TypeMouvement.Fabrication, Stocks.TypeMouvement.Habillage, Stocks.TypeMouvement.Mise_en_bouteille
                        'Tous les lots non terminés sont valides (ou bien tous les lots ?)
                        dt = dta.GetDataLotsNonTermines
                    Case Else
                        'Seuls les lots non terminés pour ce produit sont valides
                        dt = dta.GetDataLotsNonTerminesByProduit(codeProduit)
                End Select
            End Using
        Else 'Sinon
            Using dta As New StocksDataSetTableAdapters.LotTA
                dt = dta.GetDataLotsNonTerminesByCodeProduit(codeProduit)
            End Using
        End If

        Dim dvS As DataView = New DataView(dt)

        Dim frSelectionLot As New FrSelection(cell, 0)
        With frSelectionLot
            AddHandler .Closed, AddressOf frSelectionLot_Closed
            .Width = 300
            .StartPosition = FormStartPosition.Manual
            .Location = GetPosition(frSelectionLot, cell)
            .AddColumn("Lot n°", "NLot", 60, DataGridViewContentAlignment.MiddleLeft, , DataGridViewAutoSizeColumnMode.Fill)
            .AddColumn("Date", "DateCreation", 60, DataGridViewContentAlignment.MiddleLeft, "d")
            .DataSource = dvS
            .Owner = Me
            .Show()
        End With
    End Sub

    Private Sub frSelectionLot_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MouvementDetailDataGridView.CurrentCell = Me.MouvementDetailDataGridView.CurrentRow.Cells(Me.Nlot.Index)
        _stop = False
    End Sub
#End Region

#End Region

#Region "Méthodes diverses"
    Private Sub ImprimerMouvement(ByVal drv As DataRowView)
        Dim myDs As DataSet = ds.Clone
        myDs.EnforceConstraints = False
        myDs.Merge(New DataRow() {drv.Row})
        myDs.Merge(drv.Row.GetChildRows(_NomLiaison))
        Try
            Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeMouvement.rpt")
            fr.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function RecupererValeurCreationLotsSolstyce() As Boolean
        Dim creerLotsDansSolstyce As Boolean = True

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            sqlConn.Open()

            Using sqlComm As New SqlCommand
                sqlComm.Connection = sqlConn
                sqlComm.CommandText = "SELECT Valeur FROM Parametres WHERE Cle='CreerLotsDansSolstyce'"

                Dim sqlDR As SqlDataReader = sqlComm.ExecuteReader()
                Dim valeur As String = String.Empty

                While sqlDR.Read()
                    If Not (IsDBNull(sqlDR(0))) Then
                        valeur = sqlDR(0).ToString()
                    End If
                End While

                If (valeur = String.Empty) Then
                    creerLotsDansSolstyce = True
                Else
                    creerLotsDansSolstyce = CBool(valeur)
                End If
            End Using
        End Using

        Return creerLotsDansSolstyce
    End Function
#End Region

End Class