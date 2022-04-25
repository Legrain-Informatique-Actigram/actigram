Public Class FrRemise
    Inherits GRC.FrBase

#Region "Ctor"
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nRemise As Integer)
        Me.New()
        Me.id = nRemise
        Me.AjouterEnregistrement = False
    End Sub

    Public Sub New(ByVal ReglementsADeposer As List(Of DataRow))
        Me.New()
        lstReglements = ReglementsADeposer
        Me.AjouterEnregistrement = True
    End Sub
#End Region

#Region "Props"
    Private lstReglements As List(Of DataRow)

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.RemiseBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.RemiseBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nRemise() As Integer
        Get
            Return CInt(Me.CurrentDrv("nRemise"))
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
    Friend WithEvents GestionControles1 As GestionControles
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbReglRejete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents dgReglements As System.Windows.Forms.DataGridView
    Friend WithEvents FrRemiseDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents FrRemiseDetailTA As AgriFact.DsPiecesTableAdapters.FrRemiseDetailTA
    Friend WithEvents DateReglementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NModeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BanqueClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemiseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrRemise))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbImprimer = New System.Windows.Forms.ToolStripButton
        Me.TbReglRejete = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.dgReglements = New System.Windows.Forms.DataGridView
        Me.DateReglementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NModeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BanqueClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FrRemiseDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.FrRemiseDetailTA = New AgriFact.DsPiecesTableAdapters.FrRemiseDetailTA
        Me.RemiseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.dgReglements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FrRemiseDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemiseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.TbClose, Me.ToolStripSeparator1, Me.TbImprimer, Me.TbReglRejete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(546, 39)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = Global.AgriFact.My.Resources.Resources.Suppr24
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
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
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
        Me.TbImprimer.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImprimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimer.Name = "TbImprimer"
        Me.TbImprimer.Size = New System.Drawing.Size(36, 36)
        Me.TbImprimer.Text = "Imprimer"
        '
        'TbReglRejete
        '
        Me.TbReglRejete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbReglRejete.Image = Global.AgriFact.My.Resources.Resources.reglement_rejete
        Me.TbReglRejete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbReglRejete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbReglRejete.Name = "TbReglRejete"
        Me.TbReglRejete.Size = New System.Drawing.Size(31, 36)
        Me.TbReglRejete.Text = "Réglement rejeté"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(8, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 256)
        Me.Panel1.TabIndex = 11
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.BorderColor = New Ascend.BorderColor(System.Drawing.Color.DarkOliveGreen)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.Color.DarkSeaGreen
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(499, 256)
        Me.GradientPanel2.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.DarkOliveGreen)
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.Color.White
        Me.GradientCaption1.GradientHighColor = System.Drawing.Color.DarkSeaGreen
        Me.GradientCaption1.GradientLowColor = System.Drawing.Color.SeaGreen
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(499, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Remise"
        '
        'GestionControles1
        '
        Me.GestionControles1.AutorisationListe = Nothing
        Me.GestionControles1.Autorisations = ""
        Me.GestionControles1.AutoriseAjt = True
        Me.GestionControles1.AutoriseModif = True
        Me.GestionControles1.AutoriseSuppr = True
        Me.GestionControles1.AutoSize = True
        Me.GestionControles1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles1.DataSource = Nothing
        Me.GestionControles1.DsBase = Nothing
        Me.GestionControles1.FiltreAffichage = ""
        Me.GestionControles1.Label1Top = 10
        Me.GestionControles1.LabelLeft = 10
        Me.GestionControles1.LargeurText = 250
        Me.GestionControles1.LiaisonDonnees = True
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(0, 30)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(471, 223)
        Me.GestionControles1.TabIndex = 0
        Me.GestionControles1.Table = "Remise"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 150
        Me.GestionControles1.TypeRecherche = False
        '
        'dgReglements
        '
        Me.dgReglements.AllowUserToAddRows = False
        Me.dgReglements.AllowUserToDeleteRows = False
        Me.dgReglements.AutoGenerateColumns = False
        Me.dgReglements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReglements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateReglementDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.NModeDataGridViewTextBoxColumn, Me.BanqueClientDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn})
        Me.dgReglements.DataSource = Me.FrRemiseDetailBindingSource
        Me.dgReglements.Location = New System.Drawing.Point(8, 317)
        Me.dgReglements.Name = "dgReglements"
        Me.dgReglements.ReadOnly = True
        Me.dgReglements.Size = New System.Drawing.Size(498, 229)
        Me.dgReglements.TabIndex = 12
        '
        'DateReglementDataGridViewTextBoxColumn
        '
        Me.DateReglementDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateReglementDataGridViewTextBoxColumn.DataPropertyName = "DateReglement"
        DataGridViewCellStyle1.Format = "d"
        Me.DateReglementDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateReglementDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateReglementDataGridViewTextBoxColumn.Name = "DateReglementDataGridViewTextBoxColumn"
        Me.DateReglementDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateReglementDataGridViewTextBoxColumn.Width = 55
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Payeur"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NModeDataGridViewTextBoxColumn
        '
        Me.NModeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NModeDataGridViewTextBoxColumn.DataPropertyName = "nMode"
        Me.NModeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.NModeDataGridViewTextBoxColumn.Name = "NModeDataGridViewTextBoxColumn"
        Me.NModeDataGridViewTextBoxColumn.ReadOnly = True
        Me.NModeDataGridViewTextBoxColumn.Width = 56
        '
        'BanqueClientDataGridViewTextBoxColumn
        '
        Me.BanqueClientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BanqueClientDataGridViewTextBoxColumn.DataPropertyName = "BanqueClient"
        Me.BanqueClientDataGridViewTextBoxColumn.HeaderText = "Banque"
        Me.BanqueClientDataGridViewTextBoxColumn.Name = "BanqueClientDataGridViewTextBoxColumn"
        Me.BanqueClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.BanqueClientDataGridViewTextBoxColumn.Width = 69
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "Montant"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'FrRemiseDetailBindingSource
        '
        Me.FrRemiseDetailBindingSource.DataMember = "FrRemiseDetail"
        Me.FrRemiseDetailBindingSource.DataSource = Me.DsPieces
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrRemiseDetailTA
        '
        Me.FrRemiseDetailTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DateReglement"
        DataGridViewCellStyle3.Format = "d"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Payeur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "nMode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BanqueClient"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Banque"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Montant"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'FrRemise
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(546, 558)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgReglements)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrRemise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remise - Clients"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.dgReglements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FrRemiseDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemiseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            DefinitionDonnees.Instance.Fill(ds, "Banque", s)
            If CInt(Me.id) >= 0 Then
                DefinitionDonnees.Instance.Fill(ds, "Remise", s, String.Format("nRemise={0}", Me.id))
                DefinitionDonnees.Instance.Fill(ds, "Remise_Detail", s, String.Format("nRemise={0}", Me.id))
                With Me.RemiseBindingSource
                    .DataSource = ds
                    .DataMember = "Remise"
                End With
                Me.FrRemiseDetailTA.FillByRemise(Me.DsPieces.FrRemiseDetail, Me.nRemise)
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, "Remise", s)
                DefinitionDonnees.Instance.FillSchema(ds, "Remise_Detail", s)
                'Databinding
                With Me.RemiseBindingSource
                    .DataSource = ds
                    .DataMember = "Remise"
                End With
                'Création de la nouvelle ligne
                CreerRemise()
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)

        ConfigDataTableEvents(Me.ds.Tables("Remise"), AddressOf Datarowchanged, True)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        Me.GestionControles1.SetDataSource(CType(Me.RemiseBindingSource.List, DataView))
        If Me.RemiseBindingSource.Position >= 0 AndAlso CBool(Me.CurrentDrv("ExportCompta")) Then
            Me.GestionControles1.Enabled = False
        End If
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        res = Me.GestionControles1.VerifContraintes
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
        Me.RemiseBindingSource.EndEdit()
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
        Me.RemiseBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Remise", "Remise_Detail"}
            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
                'Marquer les factures comme réglées dans la base
                If Not lstReglements Is Nothing Then
                    For Each dr As DataRow In lstReglements
                        s.ExecuteNonQuery(SqlProxy.FormatSql("UPDATE Reglement SET Depose=1 WHERE nReglement={0}", dr("nReglement")))
                    Next
                    lstReglements = Nothing
                End If
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub CreerRemise()
        Me.RemiseBindingSource.AddNew()
        Dim drv As DataRowView = Me.CurrentDrv
        drv("DateRemise") = Today
        drv.EndEdit()

        Me.FrRemiseDetailTA.ClearBeforeFill = False
        Me.DsPieces.FrRemiseDetail.Clear()

        Dim typesRemise As New List(Of String)
        Dim MontantRemise As Decimal = 0
        For Each drRegl As DataRow In lstReglements
            Dim drDetail As DataRow = Me.ds.Tables("Remise_Detail").NewRow
            drDetail("nRemise") = Me.nRemise
            drDetail("nReglement") = drRegl("nReglement")
            Me.ds.Tables("Remise_Detail").Rows.Add(drDetail)
            If Not typesRemise.Contains(Convert.ToString(drRegl("nMode"))) Then typesRemise.Add(Convert.ToString(drRegl("nMode")))
            If Not drRegl.IsNull("Montant") Then
                MontantRemise += CDec(drRegl("Montant"))
            End If
            Me.FrRemiseDetailTA.FillDummyByReglement(Me.DsPieces.FrRemiseDetail, CDec(drRegl("nReglement")))
        Next
        If typesRemise.Count = 1 Then
            drv("TypeRemise") = typesRemise(0)
        End If
        If Not IsDBNull(FrApplication.ValeurDefault.nBanqueEntreprise) Then
            drv("nBanque") = FrApplication.ValeurDefault.nBanqueEntreprise
        End If
        drv("Montant") = MontantRemise
        Me.RemiseBindingSource.EndEdit()
    End Sub

    Public Shared Sub CreerRemise(ByVal drReglement As DataRow)
        Using s As New SqlProxy
            CreerRemise(drReglement, s)
        End Using
    End Sub

    Public Shared Sub CreerRemise(ByVal drReglement As DataRow, ByVal s As SqlProxy)
        Dim ds As New DataSet

        DefinitionDonnees.Instance.FillSchema(ds, "Remise", s)
        DefinitionDonnees.Instance.FillSchema(ds, "Remise_Detail", s)
        DefinitionDonnees.Instance.CreateRelations(ds)

        Dim drRemise As DataRow = ds.Tables("Remise").NewRow
        With drRemise
            .Item("DateRemise") = drReglement("DateReglement")
            .Item("TypeRemise") = drReglement("nMode")

            'MODIF TV 10/02/2012
            'Recherche de la banque de dépôt
            Using ModeReglement_DetailTA As New DsAgrifactTableAdapters.ModeReglement_DetailTableAdapter
                Dim ModeReglement_DetailDT As DsAgrifact.ModeReglement_DetailDataTable = ModeReglement_DetailTA.GetDataByModeReglement(Convert.ToString(drReglement("nMode")))

                If (ModeReglement_DetailDT.Rows.Count > 0) Then
                    Dim ModeReglement_DetailDR As DsAgrifact.ModeReglement_DetailRow = CType(ModeReglement_DetailDT.Rows(0), DsAgrifact.ModeReglement_DetailRow)

                    If Not (ModeReglement_DetailDR.IsnBanqueNull) Then
                        .Item("nBanque") = ModeReglement_DetailDR.nBanque
                    Else
                        .Item("nBanque") = FrApplication.ValeurDefault.nBanqueEntreprise
                    End If
                End If
            End Using
            '.Item("nBanque") = FrApplication.ValeurDefault.nBanqueEntreprise
            '--------------------------------

            .Item("Observation") = "Creation Automatique"
            .Item("Montant") = drReglement("Montant")
        End With
        ds.Tables("Remise").Rows.Add(drRemise)

        Dim drRemiseD As DataRow = ds.Tables("Remise_Detail").NewRow
        With drRemiseD
            .Item("nRemise") = drRemise.Item("nRemise")
            .Item("nReglement") = drReglement.Item("nReglement")
        End With
        ds.Tables("Remise_Detail").Rows.Add(drRemiseD)

        s.UpdateTables(ds, New String() {"Remise", "Remise_Detail"})
    End Sub

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustRefreshTable
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

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustUpdateTable
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

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.RemiseBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nRemise)
                End If
        End Select
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.dgReglements)
        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated
        ChargerDonnees()
        MajBoutons()
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.RemiseBindingSource.EndEdit()
    End Sub

    Private Sub Me_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '(Ctrl+M)
        If e.KeyCode = Keys.M And e.Modifiers = Keys.Control Then
            If Not (CBool(Me.CurrentDrv("ExportCompta"))) Then
                Me.GestionControles1.Enabled = True
            Else
                MsgBox("Modification de la remise impossible car elle a été exportée en comptabilité.", MsgBoxStyle.Information, "Remise exportée en comptabilité")
            End If
        End If
    End Sub

    Private Sub FrRemiseDetailBindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrRemiseDetailBindingSource.PositionChanged
        Me.TbReglRejete.Enabled = Me.FrRemiseDetailBindingSource.Position >= 0
    End Sub
#End Region

#Region "Toolbar"
    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.RemiseBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbDelete.Enabled = rowExists
        Me.TbImprimer.Enabled = rowExists
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.RemiseBindingSource.Position < 0 Then Exit Sub
        Try
            Dim lstRegl As New List(Of Integer)
            For Each dr As DataRow In Me.ds.Tables("Remise_Detail").Select("nRemise=" & Me.nRemise)
                lstRegl.Add(CInt(dr("nReglement")))
            Next
            Me.RemiseBindingSource.RemoveCurrent()
            If UpdateBase() Then
                'Marquer tous les réglements comme non déposés
                Using s As New SqlProxy
                    For Each nReglement As Integer In lstRegl
                        s.ExecuteNonQuery("UPDATE Reglement SET depose=0 WHERE nReglement=" & nReglement)
                    Next
                End Using
                Me.Close()
            End If
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
        ImprimerRemise()
    End Sub

    Private Sub TbReglRejete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbReglRejete.Click
        ChequeRejete()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "Grille"
    Private Sub dgReglements_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReglements.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        AfficheReglement(CInt(Cast(Of DataRowView)(Me.FrRemiseDetailBindingSource.Current).Item("nReglement")))
    End Sub
#End Region

#Region "Fonctionnel"
    Private Sub ChequeRejete()
        If Me.FrRemiseDetailBindingSource.Position < 0 Then Exit Sub

        Dim drvRem As DataRowView = Me.CurrentDrv
        Dim drvRemDet As DataRowView = CType(Me.FrRemiseDetailBindingSource.Current, DataRowView)
        If Not IsDBNull(drvRem("ExportCompta")) AndAlso CBool(drvRem("ExportCompta")) Then
            If MsgBox("Cette remise a déjà été exporté en compta." & vbCrLf & _
                    "Si vous voulez quand-même la modifier," & vbCrLf & _
                    "l'écriture comptable devra être modifiée manuellement", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
        Else
            If MsgBox(String.Format("Voulez-vous rejeter le réglement {0} du {1:dd/MM/yy} de {2:C2} ?", drvRemDet("nMode"), drvRemDet("DateReglement"), drvRemDet("Montant")), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Dim nReglement As Integer = CInt(drvRemDet("nReglement"))

        Using dta As New DsPiecesTableAdapters.ReglementsTA
            'Modifier l'observation du réglement
            'Modifier le montant du réglement
            'Démarquer la/les factures payées
            dta.RejeterReglement(nReglement, String.Format("{0}{2} rejeté de {1:C2}", drvRemDet("nMode"), drvRemDet("Montant"), IIf(Convert.ToString(drvRemDet("Observation")).Length > 0, String.Format(" n°{0}", drvRemDet("Observation")), "")))
        End Using
        'Modifier le montant de la remise
        drvRem("Montant") = CDec(drvRem("Montant")) - CDec(drvRemDet("Montant"))

        'Enregistrer en base
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub ImprimerRemise()
        If Me.RemiseBindingSource.Position < 0 Then Exit Sub
        Me.RemiseBindingSource.EndEdit()

        Dim myDs As DataSet = ds.Clone
        With myDs
            .EnforceConstraints = False
            .Merge(New DataRow() {Me.CurrentDrv.Row})
        End With
        Dim nRemise As Integer = Me.nRemise
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(myDs, "Banque", s)
            DefinitionDonnees.Instance.Fill(myDs, "Parametres", s)
            DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s, String.Format("nEntreprise IN (SELECT nEntreprise FROM Reglement rg INNER JOIN Remise_Detail rmd ON rmd.nReglement=rg.nReglement WHERE nRemise={0})", nRemise))
            DefinitionDonnees.Instance.Fill(myDs, "VFacture", s, String.Format("nDevis IN (SELECT nDevis FROM Reglement_Detail rgd INNER JOIN Remise_Detail rmd ON rmd.nReglement=rgd.nReglement WHERE nRemise={0})", nRemise))
            DefinitionDonnees.Instance.Fill(myDs, "Reglement", s, String.Format("nReglement IN (SELECT nReglement FROM Remise_Detail WHERE nRemise={0})", nRemise))
            DefinitionDonnees.Instance.Fill(myDs, "Reglement_Detail", s, String.Format("nReglement IN (SELECT nReglement FROM Remise_Detail WHERE nRemise={0})", nRemise))
            DefinitionDonnees.Instance.Fill(myDs, "Remise_Detail", s, "nRemise=" & nRemise)
        End Using
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptRemise.rpt")
        GestionImpression.AppliquerParametres(fr, myDs)
        fr.Show()
    End Sub

    Private Sub AfficheReglement(ByVal nReglement As Integer)
        With New FrReglement(nReglement)
            .Show(Me)
        End With
    End Sub
#End Region

End Class