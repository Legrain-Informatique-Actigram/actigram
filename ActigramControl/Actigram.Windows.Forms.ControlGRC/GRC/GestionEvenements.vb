Public Class GestionEvenementsBase
    Inherits System.Windows.Forms.UserControl
    Dim ds As DataSet
    Dim dv As DataView
    Dim dt As String = ""
    Dim dtParticipant As String = ""
    Dim strFilterDep As String = ""
    Dim strFilter As String = ""
    Dim lstEvParticipant As Hashtable
    'Dim lstEvSelect As SortedList
    Dim maListeImage As ListeTypenImage
    Dim nPersonne As String
    Dim _AFaireSeul As Boolean
    Dim _Jour As Boolean = False
    Dim _Semaine As Boolean = False
    Dim _Mois As Boolean = False
    Dim FiltreDate As String = ""
    Dim ActionCheck As Boolean = False
    Dim _LibellePeriode As String = ""
    Dim TypeEntite As String
    Dim _TbSelect As DataTable
    Dim _AfficheOrdre As Boolean = True
    Dim _CouleurItemImportant As Color = Color.Red
    Dim _CouleurItemPeuImportant As Color = Color.Gray
    Dim Desc As Boolean = False
    Dim _AfficherListeDemande As Boolean = False
    Dim _LibelleSelection As String = ""

    Public Event AffichenEnregistrement(ByVal strType As String, ByRef momDataset As DataSet, ByVal nEnregistrement As Object, ByRef fr As FrBase)
    Public Event SelectionLibelleChange(ByVal strLibelleSelection As String)
    Private nSemaine As Integer = 0
    Private nMois As Integer = 0
    Private nJour As Integer = 0

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du UserControl pour nettoyer la liste des composants.
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents XpBar1 As Actigram.Windows.Forms.XPBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents BtAvance As Actigram.Windows.Forms.BoutonImage
    Friend WithEvents BtRecule As Actigram.Windows.Forms.BoutonImage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GestionEvenementsBase))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Envoi courrier", "01/01/02", "Ludo", "Envoi courrier relance au GAB", "Pas de dossier", "Pas de document joint"}, 2)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Formation", "02/04/03", "Ludovic", "Formation visual basic.net v1", "d:\vbnet\agrigest", "Pas de pièces jointes"}, 0)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.XpBar1 = New Actigram.Windows.Forms.XPBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtDebut = New System.Windows.Forms.DateTimePicker
        Me.dtFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtAvance = New Actigram.Windows.Forms.BoutonImage
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtRecule = New Actigram.Windows.Forms.BoutonImage
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.ImageIndex = 1
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 152)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Tous", 1, 1, New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Envoi Courrier", 2, 2, New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Auteurs", 1, 1, New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Ludo", 6, 6), New System.Windows.Forms.TreeNode("Julien", 6, 6), New System.Windows.Forms.TreeNode("Truc", 6, 6)})}), New System.Windows.Forms.TreeNode("Formation", 0, 0, New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Auteurs", 1, 1)}), New System.Windows.Forms.TreeNode("Appel Telephonique", 3, 3, New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Auteurs", 1, 1)}), New System.Windows.Forms.TreeNode("Cotisation", 4, 4)})})
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(181, 152)
        Me.TreeView1.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 304)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.AutoArrange = False
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader11, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        ListViewItem2.StateImageIndex = 0
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.ListView1.Location = New System.Drawing.Point(184, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(472, 304)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 3
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type Evènement"
        Me.ColumnHeader1.Width = 110
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Date"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Auteur"
        Me.ColumnHeader2.Width = 123
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Libelle"
        Me.ColumnHeader3.Width = 200
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 192)
        Me.MonthCalendar1.MaxSelectionCount = 31
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 4
        Me.MonthCalendar1.Visible = False
        '
        'XpBar1
        '
        Me.XpBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpBar1.Angle = 10
        Me.XpBar1.AutoScroll = True
        Me.XpBar1.BackColor = System.Drawing.Color.White
        Me.XpBar1.BackColorFlecheTransparent = True
        Me.XpBar1.Cadre = False
        Me.XpBar1.CouleurDroite = System.Drawing.Color.LightSteelBlue
        Me.XpBar1.CouleurFondItem = System.Drawing.Color.White
        Me.XpBar1.CouleurGauche = System.Drawing.Color.White
        Me.XpBar1.CouleurItem = System.Drawing.Color.DarkBlue
        Me.XpBar1.CouleurSelectedItem = System.Drawing.Color.DarkBlue
        Me.XpBar1.CouleurSelectedTitre = System.Drawing.Color.MediumBlue
        Me.XpBar1.CouleurTitre = System.Drawing.Color.DarkBlue
        Me.XpBar1.EcartBordure = 5.0!
        Me.XpBar1.EspaceGauche = 2.0!
        Me.XpBar1.EspaceImageText = 5.0!
        Me.XpBar1.FondFleche = System.Drawing.Color.WhiteSmoke
        Me.XpBar1.HauteurEntete = 25
        Me.XpBar1.HauteurItem = 20.0!
        Me.XpBar1.ImageList = Me.ImageList1
        Me.XpBar1.ImageListItem = Me.ImageList1
        Me.XpBar1.IntervalGroupe = 5
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Test", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Test", System.Drawing.Color.Red, -1, True)}, True, True))
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Test2", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Test2", System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte)), -1, True)}, True, True))
        Me.XpBar1.LeftItemText = 0.0!
        Me.XpBar1.Location = New System.Drawing.Point(184, 0)
        Me.XpBar1.MonoFleche = True
        Me.XpBar1.Name = "XpBar1"
        Me.XpBar1.PoliceItems = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpBar1.PoliceItemsSelectionnés = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpBar1.PoliceTitre = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpBar1.Size = New System.Drawing.Size(472, 304)
        Me.XpBar1.TabIndex = 5
        Me.XpBar1.TailleRond = 5.0!
        Me.XpBar1.TitreDegrade = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.XpBar1.TransparentColorDebut = System.Drawing.Color.Gray
        Me.XpBar1.TransparentColorFin = System.Drawing.Color.White
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Du"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtDebut
        '
        Me.dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtDebut.Location = New System.Drawing.Point(40, 32)
        Me.dtDebut.Name = "dtDebut"
        Me.dtDebut.Size = New System.Drawing.Size(104, 20)
        Me.dtDebut.TabIndex = 7
        Me.dtDebut.Value = New Date(2005, 1, 1, 9, 56, 0, 0)
        '
        'dtFin
        '
        Me.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFin.Location = New System.Drawing.Point(40, 64)
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(104, 20)
        Me.dtFin.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Au"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Blue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Sélection"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Blue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 24)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Filtre"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtAvance
        '
        Me.BtAvance.CausesValidation = False
        Me.BtAvance.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtAvance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAvance.ImageIndex = 0
        Me.BtAvance.ImageList = Me.ImageList4
        Me.BtAvance.Location = New System.Drawing.Point(104, 88)
        Me.BtAvance.Name = "BtAvance"
        Me.BtAvance.Size = New System.Drawing.Size(24, 24)
        Me.BtAvance.TabIndex = 12
        Me.BtAvance.Visible = False
        '
        'ImageList4
        '
        Me.ImageList4.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList4.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        '
        'BtRecule
        '
        Me.BtRecule.CausesValidation = False
        Me.BtRecule.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtRecule.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtRecule.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtRecule.ImageIndex = 1
        Me.BtRecule.ImageList = Me.ImageList4
        Me.BtRecule.Location = New System.Drawing.Point(48, 88)
        Me.BtRecule.Name = "BtRecule"
        Me.BtRecule.Size = New System.Drawing.Size(24, 24)
        Me.BtRecule.TabIndex = 13
        Me.BtRecule.Visible = False
        '
        'GestionEvenementsBase
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtRecule)
        Me.Controls.Add(Me.BtAvance)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtFin)
        Me.Controls.Add(Me.dtDebut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.XpBar1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Splitter1)
        Me.Name = "GestionEvenementsBase"
        Me.Size = New System.Drawing.Size(656, 304)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propriétés"
    Public ReadOnly Property LibelleSelection() As String
        Get
            Return _LibelleSelection
        End Get
    End Property

    Public ReadOnly Property DateDebutSelection() As Date
        Get
            'Return Me.MonthCalendar1.SelectionStart
            Return Me.dtDebut.Value
        End Get
    End Property

    Public ReadOnly Property DateFinSelection() As Date
        Get
            'Return Me.MonthCalendar1.SelectionEnd
            Return Me.dtFin.Value
        End Get
    End Property

    Public Property AfficherListeDemande() As Boolean
        Get
            Return _AfficherListeDemande
        End Get
        Set(ByVal Value As Boolean)
            _AfficherListeDemande = Value
        End Set
    End Property

    Public Property TriDescandant() As Boolean
        Get
            Return Desc
        End Get
        Set(ByVal Value As Boolean)
            Desc = Value
        End Set
    End Property

    Public Property CouleurItemImportant() As Color
        Get
            Return _CouleurItemImportant
        End Get
        Set(ByVal Value As Color)
            _CouleurItemImportant = Value
        End Set
    End Property

    Public Property CouleurItemPeuImportant() As Color
        Get
            Return _CouleurItemPeuImportant
        End Get
        Set(ByVal Value As Color)
            _CouleurItemPeuImportant = Value
        End Set
    End Property

    Public Property AfficheOrdre() As Boolean
        Get
            Return _AfficheOrdre
        End Get
        Set(ByVal Value As Boolean)
            _AfficheOrdre = Value
            If Not dv Is Nothing Then
                RefreshData()
            End If
        End Set
    End Property

    Public ReadOnly Property TableSelect() As DataTable
        Get
            Return _TbSelect
        End Get
    End Property

    Public ReadOnly Property LibellePeriode() As String
        Get
            Return _LibellePeriode
        End Get
    End Property

    Public Property Jour() As Boolean
        Get
            Return _Jour
        End Get
        Set(ByVal Value As Boolean)
            _Jour = Value
            If Value = True Then
                _Semaine = False
                _Mois = False
                Me.BtAvance.Visible = False
                Me.BtRecule.Visible = False
                'FiltreDate = "DateEv=#" & Now.ToString("MM/dd/yyyy") & "#"
                'Me.MonthCalendar1.SelectionStart = Now
                'Me.MonthCalendar1.SelectionEnd = Now
                nJour = 0
                Me.dtDebut.Value = Now
                Me.dtFin.Value = Now
            Else
                'Me.MonthCalendar1.SelectionStart = Now
                'Me.MonthCalendar1.SelectionEnd = Now
                'Me.dtDebut.Value = Now
                'Me.dtFin.Value = Now
                Me.dtDebut.Value = Convert.ToDateTime("01/01/05")
                Me.dtFin.Value = Actigram.Dates.Dates.GetLastDayOfWeek(Now)
                FiltreDate = ""
                _LibellePeriode = ""
                If Not dv Is Nothing Then
                    RefreshData()
                End If
            End If
            'Me.MonthCalendar1_DateSelected(Me.MonthCalendar1, New System.Windows.Forms.DateRangeEventArgs(Me.MonthCalendar1.SelectionStart, Me.MonthCalendar1.SelectionEnd))
            Me.dtDebut_ValueChanged(Me.dtDebut, New EventArgs)
        End Set
    End Property

    Public Property Semaine() As Boolean
        Get
            Return _Semaine
        End Get
        Set(ByVal Value As Boolean)
            _Semaine = Value
            If Value = True Then
                _Jour = False
                _Mois = False
                Me.BtAvance.Visible = True
                Me.BtRecule.Visible = True
                nSemaine = 0
                ''Dim dtDebutSemaine As Date = Me.MonthCalendar1.SelectionStart
                ''Dim dtFinSemaine As Date = Me.MonthCalendar1.SelectionStart
                ''Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                ''    dtDebutSemaine = dtDebutSemaine.AddDays(-1)
                ''Loop
                ''Do Until dtFinSemaine.DayOfWeek = DayOfWeek.Sunday
                ''    dtFinSemaine = dtFinSemaine.AddDays(1)
                ''Loop
                ''FiltreDate = "(DateEv>=#" & dtDebutSemaine.ToString("MM/dd/yyyy") & "# And DateEv<=#" & dtFinSemaine.ToString("MM/dd/yyyy") & "#)"
                ''Me.MonthCalendar1.SelectionStart = dtDebutSemaine
                ''Me.MonthCalendar1.SelectionEnd = dtFinSemaine
            Else
                'Me.MonthCalendar1.SelectionStart = Now
                'Me.MonthCalendar1.SelectionEnd = Now
                Me.BtAvance.Visible = False
                Me.BtRecule.Visible = False
                Me.dtDebut.Value = Convert.ToDateTime("01/01/05")
                Me.dtFin.Value = Actigram.Dates.Dates.GetLastDayOfWeek(Now)
                FiltreDate = ""
                _LibellePeriode = ""
                If Not dv Is Nothing Then
                    RefreshData()
                End If
            End If
            'Me.MonthCalendar1_DateSelected(Me.MonthCalendar1, New System.Windows.Forms.DateRangeEventArgs(Me.MonthCalendar1.SelectionStart, Me.MonthCalendar1.SelectionEnd))
            Me.dtDebut_ValueChanged(Me.dtDebut, New EventArgs)
        End Set
    End Property

    Public Property Mois() As Boolean
        Get
            Return _Mois
        End Get
        Set(ByVal Value As Boolean)
            _Mois = Value
            If Value = True Then
                _Jour = False
                _Semaine = False
                Me.BtAvance.Visible = True
                Me.BtRecule.Visible = True
                nMois = 0
                Dim dtFinMois As Date
                dtFinMois = Convert.ToDateTime(Me.MonthCalendar1.SelectionStart.ToString("01/MM/yyyy"))
                dtFinMois = dtFinMois.AddMonths(1).AddDays(-1)
                'FiltreDate = "(DateEv>=#" & Now.ToString("MM/01/yyyy") & "# And DateEv<=#" & dtFinMois.ToString("MM/dd/yyyy") & "#)"
                'Me.MonthCalendar1.SelectionStart = Convert.ToDateTime(Me.MonthCalendar1.SelectionStart.ToString("01/MM/yyyy"))
                'Me.MonthCalendar1.SelectionEnd = dtFinMois
                Me.dtDebut.Value = Convert.ToDateTime(Me.MonthCalendar1.SelectionStart.ToString("01/MM/yyyy"))
                Me.dtFin.Value = Me.dtDebut.Value.AddMonths(1).AddDays(-1)
            Else
                'Me.MonthCalendar1.SelectionStart = Now
                'Me.MonthCalendar1.SelectionEnd = Now
                Me.BtAvance.Visible = False
                Me.BtRecule.Visible = False
                Me.dtDebut.Value = Convert.ToDateTime("01/01/05")
                Me.dtFin.Value = Actigram.Dates.Dates.GetLastDayOfWeek(Now)
                FiltreDate = ""
                _LibellePeriode = ""
                If Not dv Is Nothing Then
                    RefreshData()
                End If
            End If
            'Me.MonthCalendar1_DateSelected(Me.MonthCalendar1, New System.Windows.Forms.DateRangeEventArgs(Me.MonthCalendar1.SelectionStart, Me.MonthCalendar1.SelectionEnd))
            Me.dtDebut_ValueChanged(Me.dtDebut, New EventArgs)
        End Set
    End Property

    Public Property AFaireSeul() As Boolean
        Get
            Return _AFaireSeul
        End Get
        Set(ByVal Value As Boolean)
            _AFaireSeul = Value
            If Not Me.dv Is Nothing Then
                Me.LoadData(True)
            End If
        End Set
    End Property

#End Region

    Public Sub SetDatasource(ByRef momDataView As DataView, ByVal momFiltre As String)
        ds = momDataView.Table.DataSet
        dv = momDataView
        dt = momDataView.Table.TableName
        dtParticipant = "EvenementPersonne"
        strFilterDep = momFiltre
        maListeImage = New ListeTypenImage(ds.Tables("ListeChoix"))

        'lstEvParticipant = New Hashtable
        'lstEvSelect = New SortedList

        'If ds.Tables(dt).Columns.Contains("Select") = False Then
        '    'ds.Tables(dt).Columns.Add("Select", GetType(Boolean), "True")
        '    ds.Tables(dt).Columns.Add("Select", GetType(Boolean))
        '    'Else
        '    '    ds.Tables(dt).Columns.Remove("Select")
        '    '    ds.Tables(dt).Columns.Add("Select", GetType(Boolean), "True")
        'End If

        LoadData(True)
    End Sub

    Public Sub SetDatasource(ByRef momDataView As DataView, ByVal momFiltre As String, ByVal momTypeEntite As String, ByVal momnEntite As String)
        ds = momDataView.Table.DataSet
        dv = momDataView
        dt = momDataView.Table.TableName
        dtParticipant = "EvenementPersonne"
        nPersonne = momnEntite
        strFilterDep = momFiltre
        maListeImage = New ListeTypenImage(ds.Tables("ListeChoix"))
        TypeEntite = momTypeEntite
        'If ds.Tables(dt).Columns.Contains("Select") = False Then
        '    ds.Tables(dt).Columns.Add("Select", GetType(Boolean))
        '    'Else
        '    '    ds.Tables(dt).Columns.Remove("Select")
        '    '    ds.Tables(dt).Columns.Add("Select", GetType(Boolean))
        'End If

        'lstEvParticipant = New Hashtable
        'lstEvSelect = New SortedList


        'If nPersonne <> "" Then
        '    Dim rwTmp() As DataRow
        '    Dim rwTmpI As DataRow

        '    Select Case momTypeEntite
        '        Case "Personne"
        '            rwTmp = ds.Tables(dtParticipant).Select("nPersonne" & "=" & nPersonne)
        '        Case "Entreprise"
        '            rwTmp = ds.Tables(dtParticipant).Select("nEntreprise" & "=" & nPersonne)
        '    End Select

        '    For Each rwTmpI In rwTmp
        '        If lstEvSelect.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
        '            'lstEvParticipant.Add(rwTmpI.Item("nEvenement"), rwTmpI.Item("nEvenement"))
        '            lstEvSelect.Add(rwTmpI.Item("nEvenement"), rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv"))
        '        End If
        '    Next

        '    If momTypeEntite = "Entreprise" Then
        '        Dim rwTmpLstPersonne() As DataRow
        '        Dim rwTmpLstPersonneI As DataRow

        '        'rwTmpLstPersonne = ds.Tables("Employe").Select("nEntreprise=" & nPersonne)
        '        rwTmpLstPersonne = ds.Tables("Personne").Select("nEntreprise=" & nPersonne)
        '        For Each rwTmpLstPersonneI In rwTmpLstPersonne
        '            rwTmp = ds.Tables(dtParticipant).Select("nPersonne" & "=" & Convert.ToString(rwTmpLstPersonneI.Item("nPersonne")))
        '            For Each rwTmpI In rwTmp
        '                If lstEvSelect.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
        '                    'lstEvParticipant.Add(rwTmpI.Item("nEvenement"), rwTmpI.Item("nEvenement"))
        '                    lstEvSelect.Add(rwTmpI.Item("nEvenement"), rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv"))
        '                End If
        '            Next
        '        Next

        '    End If

        '    'If momTypeEntite = "Personne" Then
        '    '    rwTmp = ds.Tables(dt).Select("nPersonneAuteur" & "=" & nPersonne)

        '    '    For Each rwTmpI In rwTmp
        '    '        If lstEvParticipant.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
        '    '            lstEvParticipant.Add(rwTmpI.Item("nEvenement"), rwTmpI.Item("nEvenement"))
        '    '        End If
        '    '    Next
        '    'End If
        'End If

        LoadData(True)
    End Sub

    Public Sub RefreshData()
        LoadData(True)
    End Sub

    Private Sub LoadData(ByVal ModifierTreeview As Boolean)
        ActionCheck = False
        Desc = False
        Dim rwI As DataRow
        Dim strFilterTmp As String = ""
        Dim strAfficheOrdre As String = ""

        XpBar1.ClearItems()

        If ModifierTreeview = True Then
            'Me.TreeView1.Nodes(0).Nodes.Clear()
            'Me.TreeView1.Nodes(0).Nodes.Add("Type Evènements")
            'Me.TreeView1.Nodes(0).Nodes(0).Tag = dt & ".Type"

            Me.TreeView1.Nodes.Clear()
            Me.TreeView1.Nodes.Add("Type Evènements")
            Me.TreeView1.Nodes(0).Tag = dt & ".Type"

            'Me.TreeView1.Nodes(0).Nodes.Add("Auteurs")
            'Me.TreeView1.Nodes(0).Nodes(1).Tag = dt & ".Auteur"
            'Me.TreeView1.Nodes(0).Nodes.Add("Participant")
            'Me.TreeView1.Nodes(0).Nodes(2).Tag = dtParticipant & ".nPersonne"
        End If

        'Me.ListView1.Items.Clear()

        'Me.ListView1.BeginUpdate()

        If strFilter.Length <> 0 And strFilterDep.Length <> 0 Then
            strFilterTmp = "(" & strFilterDep & ") And (" & strFilter & ")"
        ElseIf strFilter.Length <> 0 Then
            strFilterTmp = strFilter
        ElseIf strFilterDep.Length <> 0 Then
            strFilterTmp = strFilterDep
        End If

        If Me.AFaireSeul = True Then
            If strFilterTmp.Length > 0 Then
                strFilterTmp += " And "
            End If
            If Me.AfficherListeDemande = True Then
                strFilterTmp &= "DemandeOk=False"
            Else
                strFilterTmp &= "Realise=False"
            End If
        End If

        If Me.AfficheOrdre = False Then
            If strFilterTmp.Length > 9 Then
                strFilterTmp += " And "
            End If
            strFilterTmp += "TypeEv<>'OrdreInsertion'"
        Else
            strAfficheOrdre = " TypeEv='OrdreInsertion' Or "
        End If

        'rwD = ds.Tables(dt).Select(strFilterTmp)
        If FiltreDate.Length > 0 Then
            If strFilterTmp.Length > 0 Then
                strFilterTmp += " And "
            End If
            strFilterTmp += FiltreDate
        End If

        dv.RowFilter = strFilterTmp
        dv.Sort = "nEvenement"

        'lstEvSelect = New SortedList

        Dim tb As New DataTable
        tb.Columns.Add("nEvenement", GetType(Decimal))
        tb.Columns.Add("DateEv", GetType(Date))


        Dim drv As DataRowView

        If nPersonne <> "" Then
            Dim strFiltreEntreprise As String = ""

            If Not TypeEntite Is Nothing Then

                Dim rwTmp() As DataRow = Nothing

                Select Case TypeEntite
                    Case "Personne"
                        rwTmp = ds.Tables(dtParticipant).Select("nPersonne" & "=" & nPersonne)
                        'Desc = True
                    Case "Entreprise"
                        rwTmp = ds.Tables(dtParticipant).Select("nEntreprise" & "=" & nPersonne)
                        If ds.Tables("Evenement").Columns.Contains("nClient") Then
                            strFiltreEntreprise = " Or nClient=" & nPersonne
                        End If
                        Desc = True
                    Case Else
                End Select

                For Each rwTmpI As DataRow In rwTmp
                    If dv.Find(rwTmpI.Item("nEvenement")) >= 0 Then
                        If tb.Select("nEvenement=" & Convert.ToString(rwTmpI.Item("nEvenement"))).GetUpperBound(0) < 0 Then
                            Dim rwn As DataRow
                            rwn = tb.NewRow
                            rwn.Item("nEvenement") = rwTmpI.Item("nEvenement")
                            rwn.Item("DateEv") = rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv")
                            tb.Rows.Add(rwn)
                        End If
                        'If lstEvSelect.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
                        '    lstEvSelect.Add(rwTmpI.Item("nEvenement"), rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv"))
                        'End If
                    End If
                Next

                If TypeEntite = "Entreprise" Then
                    Dim rwTmpLstPersonne() As DataRow
                    Dim rwTmpLstPersonneI As DataRow

                    rwTmpLstPersonne = ds.Tables("Personne").Select("nEntreprise=" & nPersonne)
                    For Each rwTmpLstPersonneI In rwTmpLstPersonne
                        rwTmp = ds.Tables(dtParticipant).Select("nPersonne" & "=" & Convert.ToString(rwTmpLstPersonneI.Item("nPersonne")))
                        For Each rwTmpI As DataRow In rwTmp
                            If dv.Find(rwTmpI.Item("nEvenement")) >= 0 Then
                                If tb.Select("nEvenement=" & Convert.ToString(rwTmpI.Item("nEvenement"))).GetUpperBound(0) < 0 Then
                                    Dim rwn As DataRow
                                    rwn = tb.NewRow
                                    rwn.Item("nEvenement") = rwTmpI.Item("nEvenement")
                                    rwn.Item("DateEv") = rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv")
                                    tb.Rows.Add(rwn)
                                End If
                                'If lstEvSelect.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
                                '    lstEvSelect.Add(rwTmpI.Item("nEvenement"), rwTmpI.Table.DataSet.Tables("Evenement").Rows.Find(rwTmpI.Item("nEvenement")).Item("DateEv"))
                                'End If
                            End If
                        Next
                    Next
                End If
            End If


            'For i = 0 To dv.Count - 1
            '    Dim rwN As DataRow
            '    rwN = ds.Tables("Select").NewRow
            '    rwN.Item("nCle") = dv.Item(i).Item("nEvenement")
            '    rwI = dv.Item(i)
            '    If lstEvParticipant.ContainsKey(rwI.Item("nEvenement")) = True Then
            '        Try
            '            rwN.Item("Select") = True
            '            'rwI.Item("Select") = True
            '        Catch
            '        End Try
            '    Else
            '        rwN.Item("Select") = False
            '        'rwI.Item("Select") = False
            '    End If
            '    ds.Tables("Select").Rows.Add(rwN)
            'Next

            'If nPersonne <> "" Then

            If strFiltreEntreprise.Length > 0 Then
                strAfficheOrdre = ""
            End If

            If TypeEntite = "Personne" Then
                If dv.RowFilter.Length <> 0 Then
                    '* Ne Tient pas compte de du destinataire
                    'dv.RowFilter = "(" & dv.RowFilter & ") And (Convert(nEvenement,'System.String') Like '*" & nPersonne & "' Or nPersonneAuteur=" & nPersonne & " Or Select=True)"
                    '* Tous le Monde
                    'dv.RowFilter = "(" & dv.RowFilter & ") And (Convert(nEvenement,'System.String') Like '*" & nPersonne & "' Or nPersonneAuteur=" & nPersonne & " Or nPersonneDestinataire=" & nPersonne & " Or Select=True)"
                    '* Seulement Destinataire
                    'dv.RowFilter = "(" & dv.RowFilter & ") And (nPersonneDestinataire=" & nPersonne & " Or Select=True)"
                    If Me.AfficherListeDemande = True Then
                        dv.RowFilter = "(" & dv.RowFilter & ") And (((nPersonneAuteur=" & nPersonne & " And nPersonneDestinataire<>" & nPersonne & ") " & strFiltreEntreprise & "))"
                    Else
                        dv.RowFilter = "(" & dv.RowFilter & ") And (" & strAfficheOrdre & "(nPersonneDestinataire=" & nPersonne & " " & strFiltreEntreprise & "))"
                    End If
                Else
                    'dv.RowFilter = "convert(nEvenement,'System.String') Like '*" & nPersonne & "' Or nPersonneAuteur=" & nPersonne & " Or Select=True"

                    'dv.RowFilter = "convert(nEvenement,'System.String') Like '*" & nPersonne & "' Or nPersonneAuteur=" & nPersonne & " Or nPersonneDestinataire=" & nPersonne & " Or Select=True"

                    'dv.RowFilter = "nPersonneDestinataire=" & nPersonne & " Or Parent(SelectEvenement).Select=True"
                    If AfficherListeDemande = True Then
                        dv.RowFilter = "((nPersonneAuteur=" & nPersonne & " And nPersonneDestinataire<>" & nPersonne & ") " & strFiltreEntreprise & ")"
                    Else
                        dv.RowFilter = strAfficheOrdre & "nPersonneDestinataire=" & nPersonne & " " & strFiltreEntreprise
                    End If
                End If
            Else
                If dv.RowFilter.Length <> 0 Then
                    If Me.AfficherListeDemande = True Then
                        dv.RowFilter = "(" & dv.RowFilter & ") And (1=0 " & strFiltreEntreprise & ")"
                    Else
                        dv.RowFilter = "(" & dv.RowFilter & ") And (" & strAfficheOrdre & " (1=0" & strFiltreEntreprise & "))"
                    End If
                Else
                    If AfficherListeDemande = True Then
                        dv.RowFilter = "1=0  " & strFiltreEntreprise
                    Else
                        dv.RowFilter = strAfficheOrdre & " (1=0 " & strFiltreEntreprise & ")"
                    End If
                End If
            End If

            'If dv.RowFilter.Length <> 0 Then
            '    dv.RowFilter = "(" & dv.RowFilter & ") Or Select=True"
            'Else
            '    dv.RowFilter = "Select=True"
            'End If
        End If

        'If Me._AfficheOrdre = True Then
        '    dv.RowFilter = "(" & dv.RowFilter & ") or TypeEv='OrdreInsertion'"
        'End If

        If Desc = True Then
            dv.Sort = "DateEv Desc"
        Else
            dv.Sort = "DateEv"
        End If

        For Each drv In dv
            If tb.Select("nEvenement=" & Convert.ToString(drv.Item("nEvenement"))).GetUpperBound(0) < 0 Then
                Dim rwn As DataRow
                rwn = tb.NewRow
                rwn.Item("nEvenement") = drv.Item("nEvenement")
                rwn.Item("DateEv") = drv.Item("DateEv")
                tb.Rows.Add(rwn)
            End If
            'If lstEvSelect.ContainsKey(drv.Item("nEvenement")) = False Then
            '    'lstEvParticipant.Add(drv.Item("nEvenement"), drv.Item("nEvenement"))
            '    lstEvSelect.Add(drv.Item("nEvenement"), drv.Item("DateEv"))
            'End If
        Next

        '<*
        'If ds.Tables(dt).Columns.Contains("Auteur") = False Then
        '    ds.Tables(dt).Columns.Add("Auteur", GetType(String), "Parent(PersonneEvenement).Nom + iif(Parent(PersonneEvenement).Prenom Is Null,'',' ' + Parent(PersonneEvenement).Prenom)")
        'End If
        'If ds.Tables(dtParticipant).Columns.Contains("Participant") = False Then
        '    ds.Tables(dtParticipant).Columns.Add("Participant", GetType(String), "Parent(PersonneEvenementPersonne).Nom + iif(Parent(PersonneEvenement).Prenom Is Null,'',' ' + Parent(PersonneEvenementPersonne).Prenom)")
        'End If
        '*>

        Dim dtLast As Date
        Dim xpG As Actigram.Windows.Forms.XPGroup = Nothing

        'Dim E As IDictionaryEnumerator = lstEvSelect.GetEnumerator

        'Do Until E.MoveNext = False
        '    Dim rwn As DataRow
        '    rwn = tb.NewRow
        '    rwn.Item("nCle") = E.Key
        '    rwn.Item("DateEv") = E.Value
        '    tb.Rows.Add(rwn)
        'Loop

        _TbSelect = tb
        Dim tbv As New DataView(tb)
        Dim tbvr As DataRowView
        'tbv.Sort = "DateEv"
        If Desc = True Then
            tbv.Sort = "DateEv Desc"
        Else
            tbv.Sort = "DateEv"
        End If

        For Each tbvr In tbv
            'Do Until E.MoveNext = False

            'For i = 0 To dv.Count - 1
            'rwI = dv.Item(i)
            rwI = dv.Table.Rows.Find(tbvr.Item("nEvenement"))
            Dim strType As String = ""
            Dim nImage As Integer
            If Not rwI.Item("Type") Is DBNull.Value Then
                strType = CType(rwI.Item("Type"), String)
            End If
            nImage = maListeImage.GetnImage(strType)
            If ModifierTreeview = True Then
                If TreeNodesFindText.FindText(TreeView1.Nodes(0).Nodes, strType) = False Then
                    'If Not IsDBNull(rwI("Type")) And (lstEvParticipant.Count = 0 Or (lstEvParticipant.Count <> 0 And lstEvParticipant.ContainsValue(rwI("nEvenement")))) Then
                    If Not rwI.Item("Type") Is DBNull.Value Then
                        If TreeView1.Nodes(0).Nodes.IndexOf(New TreeNode(strType)) = -1 Then
                            Dim nd As TreeNode
                            If nImage = -1 Then
                                nd = New TreeNode(strType)
                            Else
                                nd = New TreeNode(strType, nImage, nImage)
                            End If
                            nd.Tag = strType
                            TreeView1.Nodes(0).Nodes.Add(nd)
                        End If
                    End If
                End If
                'If TreeNodesFindText.FindText(TreeView1.Nodes(0).Nodes(0).Nodes, strType) = False Then
                '    If TreeView1.Nodes(0).Nodes(0).Nodes.IndexOf(New TreeNode(strType)) = -1 Then
                '        Dim nd As TreeNode
                '        If nImage = -1 Then
                '            nd = New TreeNode(strType)
                '        Else
                '            nd = New TreeNode(strType, nImage, nImage)
                '        End If
                '        nd.Tag = strType
                '        TreeView1.Nodes(0).Nodes(0).Nodes.Add(nd)
                '    End If
                'End If
            End If

            'Dim it As ListViewItem

            If Convert.ToDateTime(rwI.Item("DateEv")) <> dtLast Then
                dtLast = Convert.ToDateTime(rwI.Item("DateEv"))
                xpG = New Actigram.Windows.Forms.XPGroup(dtLast.ToString("dddd dd MMMM yyyy"))
                xpG.AfficheListeItem = True
                Me.XpBar1.Items.Add(xpG)
                'it = New ListViewItem(dtLast.ToString("dddd dd MMMM"))
                'it.Font = New Font(it.Font, FontStyle.Bold)
                'ListView1.Items.Add(it)
            End If

            Dim xpI As New Actigram.Windows.Forms.XPItem
            'Dim dvTmp As DataView
            Dim dvTmp() As DataRow
            Dim strContact As String = ""
            Dim strLibelle As String = ""

            'dvTmp = rwI.CreateChildView("EvenementEvenementPersonne")
            dvTmp = rwI.GetChildRows("EvenementEvenementPersonne")
            Dim nbI As Integer
            Dim NomOk As Boolean = False
            For nbI = 0 To dvTmp.GetUpperBound(0)
                If Not dvTmp(nbI).Item("nEntreprise") Is DBNull.Value Then
                    Dim rwTmp() As DataRow
                    rwTmp = dvTmp(nbI).Table.DataSet.Tables("Entreprise").Select("nEntreprise=" & Convert.ToString(dvTmp(nbI).Item("nEntreprise")))
                    If rwTmp.GetUpperBound(0) >= 0 Then
                        If Not rwTmp(0).Item("Nom") Is DBNull.Value Then
                            strContact += Convert.ToString(rwTmp(0).Item("Nom"))
                            NomOk = True
                            Exit For
                        End If
                    End If
                End If
            Next
            If NomOk = False Then
                For nbI = 0 To dvTmp.GetUpperBound(0)
                    If Not dvTmp(nbI).Item("nPersonne") Is DBNull.Value Then
                        Dim rwTmp() As DataRow
                        rwTmp = dvTmp(nbI).Table.DataSet.Tables("Personne").Select("nPersonne=" & Convert.ToString(dvTmp(nbI).Item("nPersonne")))
                        If rwTmp.GetUpperBound(0) >= 0 Then
                            If Not rwTmp(0).Item("Nom") Is DBNull.Value Then
                                strContact += Convert.ToString(rwTmp(0).Item("Nom"))
                            End If
                            If Not rwTmp(0).Item("Prenom") Is DBNull.Value Then
                                If strContact.Length > 0 Then
                                    strContact += " "
                                End If
                                strContact += Convert.ToString(rwTmp(0).Item("Prenom"))
                            End If
                            NomOk = True
                            Exit For
                        End If
                    End If
                Next
            End If
            'If dvTmp.GetUpperBound(0) >= 0 Then


            '    'strContact += Convert.ToString(dvTmp.Table.DataSet.Tables("Personne").Select("nPersonne=" & Convert.ToString(dvTmp(0).Item("nPersonne")))(0).Item("Nom"))

            '    'End If
            '    'Else
            '    'strContact = Convert.ToString(dvTmp.Item(0).Item("Participant")) & " : "
            'End If
            If strContact.Length > 0 Then
                strContact += " : "
            End If

            If Convert.ToString(rwI.Item("TypeEv")) = "OrdreInsertion" Then
                If Not rwI.GetParentRow("ClientEvenement") Is Nothing Then
                    strLibelle = "Pub : " & Convert.ToString(rwI.GetParentRow("ClientEvenement").Item("Nom")) & " (" & Convert.ToString(rwI.Item("Format")) & " , " & Convert.ToString(rwI.Item("Couleur")) & ")"
                Else
                    strLibelle = "Pub : ? (" & Convert.ToString(rwI.Item("Format")) & " , " & Convert.ToString(rwI.Item("Couleur")) & ")"
                End If
            Else
                strLibelle = strContact & Convert.ToString(rwI.Item("Libelle"))
            End If

            xpI.Text = strLibelle.Replace(vbCrLf, " - ")
            xpI.Tag = rwI("nEvenement")


            If nImage = -1 Then
                'it = New ListViewItem(strType)
            Else
                'it = New ListViewItem(strType, nImage)
                xpI.ImageIndex = nImage
            End If
            xpI.Barre = False
            If Me.AfficherListeDemande = True Then
                If Not rwI("Realise") Is DBNull.Value Then
                    If Convert.ToBoolean(rwI("Realise")) = True Then
                        xpI.Barre = True
                    End If
                End If
            End If
            Select Case Convert.ToString(rwI("Priorite"))
                Case "Important"
                    'it.ForeColor = Color.Red
                    xpI.TextColor = Me.CouleurItemImportant
                    xpI.TextHoverColor = Me.CouleurItemImportant
                Case "Facultatif"
                    'it.ForeColor = Color.Silver
                    xpI.TextColor = Me.CouleurItemPeuImportant
                    xpI.TextHoverColor = Me.CouleurItemPeuImportant
            End Select
            'it.Tag = rwI("nEvenement")
            'it.Checked = CType(rwI("Realise"), Boolean)
            'Dim sbs As New ListViewItem.ListViewSubItemCollection(it)
            'If Not IsDBNull(rwI("DateEv")) Then
            '    sbs.Add(CType(rwI("DateEv"), String))
            'Else
            '    sbs.Add("")
            'End If
            'If Not IsDBNull(rwI("Auteur")) Then
            '    sbs.Add(CType(rwI("Auteur"), String))
            'Else
            '    sbs.Add("")
            'End If
            'If Not IsDBNull(rwI("Libelle")) Then
            '    sbs.Add(CType(rwI("Libelle"), String))
            'Else
            '    sbs.Add("")
            'End If

            xpG.Items.Add(xpI)
            'ListView1.Items.Add(it)

            'If ModifierTreeview = True Then
            '    Dim myrwTmp() As DataRow
            '    Dim myrwTmpI As DataRow
            '    myrwTmp = ds.Tables("EvenementPersonne").Select("nEvenement=" & CType(rwI("nEvenement"), Integer))
            '    For Each myrwTmpI In myrwTmp
            '        Dim strParticipant As String
            '        strParticipant = CType(myrwTmpI.Item("Participant"), String)
            '        If TreeNodesFindText.FindText(TreeView1.Nodes(0).Nodes(2).Nodes, strParticipant) = False Then
            '            Dim nd As New TreeNode(strParticipant, 6, 6)
            '            nd.Tag = myrwTmpI.Item("nPersonne")
            '            TreeView1.Nodes(0).Nodes(2).Nodes.Add(nd)
            '        End If
            '    Next
            'End If
            'End If
            'Next
        Next
        'Loop

        'Me.ListView1.EndUpdate()

        If Me.strFilter <> "" And ModifierTreeview = True Then
            Dim nd As TreeNode
            For Each nd In Me.TreeView1.Nodes(0).Nodes
                If strFilter.IndexOf(nd.Text) >= 0 Then
                    nd.Checked = True
                End If
            Next
        End If

        ActionCheck = True

        Me.TreeView1.ExpandAll()
        Me.XpBar1.Select()

        If Me.AFaireSeul = True Then
            _LibelleSelection = "A Faire " & _LibellePeriode
        Else
            _LibelleSelection = "Fait et A Faire " & _LibellePeriode
        End If

        RaiseEvent SelectionLibelleChange(_LibelleSelection)

    End Sub

    'Private Sub ListView1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
    '    Me.ListView1.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Ascending)
    '    Me.ListView1.Columns(e.Column).ListView.Sort()
    'End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        Dim node As TreeNode
        Dim nodeParent As TreeNode
        Dim strTmpFilter As String
        Dim strNameCol As String
        Dim strNameTable As String
        Dim listFilter As New Hashtable
        lstEvParticipant = New Hashtable

        'strTmpFilter = ""

        'For Each nodeParent In TreeView1.Nodes(0).Nodes
        '    If nodeParent.Checked = True Then
        '        If Not IsDBNull(nodeParent.Parent.Tag) Then
        '            Dim tb() As String
        '            tb = CType(nodeParent.Parent.Tag, String).Split("."c)
        '            strNameTable = tb(0)
        '            strNameCol = tb(1)
        '            If strNameCol <> "" Then
        '                strTmpFilter &= strNameCol & "='" & CType(nodeParent.Tag, String) & "' or "
        '            End If
        '        End If
        '    End If
        'Next

        'If strTmpFilter.Length <> 0 Then
        '    strTmpFilter = "(" & strTmpFilter.Remove(strTmpFilter.Length - 4, 4) & ")"
        'End If
        'Me.strFilter = strTmpFilter

        'LoadData(False)

        'Exit Sub

        For Each nodeParent In TreeView1.Nodes
            For Each node In nodeParent.Nodes
                If node.Checked = True Then
                    If Not IsDBNull(node.Parent.Tag) Then
                        Dim tb() As String
                        tb = CType(node.Parent.Tag, String).Split("."c)
                        strNameTable = tb(0)
                        strNameCol = tb(1)
                        If strNameTable = dt Then
                            If strNameCol <> "" Then
                                If listFilter.ContainsKey(node.Parent) = False Then
                                    listFilter.Add(node.Parent, "")
                                End If
                                strTmpFilter = CType(listFilter.Item(node.Parent), String)
                                Select Case ds.Tables(strNameTable).Columns(strNameCol).DataType.ToString
                                    Case GetType(String).ToString()
                                        strTmpFilter &= strNameCol & "='" & CType(node.Tag, String) & "' or "
                                End Select
                                listFilter.Item(node.Parent) = strTmpFilter
                            End If
                        ElseIf strNameTable = dtParticipant Then
                            If strNameCol <> "" Then
                                Dim rwTmp() As DataRow
                                Dim rwTmpI As DataRow

                                rwTmp = ds.Tables(dtParticipant).Select(strNameCol & "=" & CType(node.Tag, String))

                                For Each rwTmpI In rwTmp
                                    If lstEvParticipant.ContainsValue(rwTmpI.Item("nEvenement")) = False Then
                                        lstEvParticipant.Add(rwTmpI.Item("nEvenement"), rwTmpI.Item("nEvenement"))
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            Next
        Next

        strTmpFilter = ""

        Dim n As IDictionaryEnumerator

        n = listFilter.GetEnumerator

        Dim nI As Integer = 0

        For nI = 0 To listFilter.Count - 1
            n.MoveNext()
            If CType(n.Value, String).Length > 0 Then
                strTmpFilter &= "(" & CType(n.Value, String).Remove(CType(n.Value, String).Length - 4, 4) & ") And "
            End If
        Next

        'For Each n In listFilter.Values
        'strTmpFilter &= CType(n.Value, String).Remove(CType(n.Value, String).Length - 4, 4) & " And "
        'Next

        If strTmpFilter.Length <> 0 Then
            strTmpFilter = strTmpFilter.Remove(strTmpFilter.Length - 5, 5)
        End If
        Me.strFilter = strTmpFilter
        LoadData(False)
    End Sub

    'Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
    '    Dim lstI As ListViewItem
    '    Dim strFilterTmp As String
    '    For Each lstI In ListView1.SelectedItems
    '        Dim fr As New FrEvenement(ds, lstI.Tag)
    '        If strFilter.Length <> 0 And strFilterDep.Length <> 0 Then
    '            strFilterTmp = "(" & strFilterDep & ") And (" & strFilter & ")"
    '        ElseIf strFilter.Length <> 0 Then
    '            strFilterTmp = strFilter
    '        ElseIf strFilterDep.Length <> 0 Then
    '            strFilterTmp = strFilterDep
    '        End If
    '        fr.FiltrePlus = strFilterTmp
    '        fr.Show()
    '    Next
    'End Sub

    'Private Sub ListView1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck
    '    If ActionCheck = True Then
    '        If Not Me.ParentForm.MdiParent Is Nothing Then
    '            CType(Me.ParentForm.MdiParent, FrApplication).StBar.Text = Me.ListView1.PointToClient(CType(sender, ListView).Cursor.Position).X.ToString
    '            If Me.ListView1.PointToClient(CType(sender, ListView).Cursor.Position).X < 20 Then
    '                If Not CType(sender, ListView).Items(e.Index).Tag Is Nothing Then
    '                    Me.ds.Tables("Evenement").Select("nEvenement=" & CType(CType(sender, ListView).Items(e.Index).Tag, String))(0).Item("Realise") = e.NewValue
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub XpBar1_ItemClick(ByVal XPItem As Actigram.Windows.Forms.XPItem) Handles XpBar1.ItemClick
        Dim fr As FrBase = Nothing
        RaiseEvent AffichenEnregistrement("Evenement", ds, XPItem.Tag, fr)

        If fr Is Nothing Then Exit Sub

        Dim strFilterTmp As String = ""
        If strFilter.Length <> 0 And strFilterDep.Length <> 0 Then
            strFilterTmp = "(" & strFilterDep & ") And (" & strFilter & ")"
        ElseIf strFilter.Length <> 0 Then
            strFilterTmp = strFilter
        ElseIf strFilterDep.Length <> 0 Then
            strFilterTmp = strFilterDep
        End If
        fr.FiltrePlus = strFilterTmp
        fr.Owner = Me.ParentForm
        fr.Show()
        'End If
    End Sub

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        If Me.Mois = True Then
            Me.MonthCalendar1.SelectionEnd = Me.MonthCalendar1.SelectionStart.AddMonths(1).AddDays(-1)
        End If
        If Me.Semaine = True Then
            Dim dtDebutSemaine As Date = Me.MonthCalendar1.SelectionStart
            Dim dtFinSemaine As Date = Me.MonthCalendar1.SelectionStart
            Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                dtDebutSemaine = dtDebutSemaine.AddDays(-1)
            Loop
            Do Until dtFinSemaine.DayOfWeek = DayOfWeek.Sunday
                dtFinSemaine = dtFinSemaine.AddDays(1)
            Loop
            'FiltreDate = "(DateEv>=#" & dtDebutSemaine.ToString("MM/dd/yyyy") & "# And DateEv<=#" & dtFinSemaine.ToString("MM/dd/yyyy") & "#)"
            Me.MonthCalendar1.SelectionStart = dtDebutSemaine
            Me.MonthCalendar1.SelectionEnd = dtFinSemaine
        End If
        FiltreDate = "(DateEv>=#" & Me.MonthCalendar1.SelectionStart.ToString("MM/dd/yyyy") & "# And DateEv<=#" & Me.MonthCalendar1.SelectionEnd.ToString("MM/dd/yyyy") & "#)"
        _LibellePeriode = ""
        If Me.Mois = False And Me.Jour = False And Me.Semaine = False Then
            FiltreDate = "(DateEv<=#" & Actigram.Dates.Dates.GetLastDayOfWeek(Now).ToString("MM/dd/yyyy") & "#)"
            _LibellePeriode = "avant le " & Actigram.Dates.Dates.GetLastDayOfWeek(Now).ToString("dddd dd MMMM yyyy")
        End If
        If _LibellePeriode.Length = 0 Then
            If Me.MonthCalendar1.SelectionStart = Me.MonthCalendar1.SelectionEnd Then
                _LibellePeriode = "le " & Me.MonthCalendar1.SelectionStart.ToString("dddd dd MMMM yyyy")
            Else
                _LibellePeriode = "du " & Me.MonthCalendar1.SelectionStart.ToString("dddd dd MMMM yyyy") & " au " & Me.MonthCalendar1.SelectionEnd.ToString("dddd dd MMMM yyyy")
            End If
        End If

        If Not dv Is Nothing Then
            RefreshData()
        End If
    End Sub

    Private Sub MonthCalendar1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MonthCalendar1.MouseUp
        'Dim p As New Point(e.X, e.Y)
        'Select Case Me.MonthCalendar1.HitTest(Me.MonthCalendar1.PointToClient(p).X, Me.MonthCalendar1.PointToClient(p).Y).HitArea
        '    Case MonthCalendar.HitArea.CalendarBackground
        'End Select
        Me.MonthCalendar1_DateSelected(Me.MonthCalendar1, New System.Windows.Forms.DateRangeEventArgs(Me.MonthCalendar1.SelectionStart, Me.MonthCalendar1.SelectionEnd))
    End Sub

    Private Sub dtDebut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDebut.ValueChanged, dtFin.ValueChanged
        If Me.Mois = True Then
            Me.dtDebut.Value = Convert.ToDateTime(Now.ToString("01/MM/yy")).AddMonths(nMois)
            Me.dtFin.Value = Me.dtDebut.Value.AddMonths(1).AddDays(-1)
        End If
        If Me.Semaine = True Then
            Dim dtDebutSemaine As Date = Me.MonthCalendar1.SelectionStart
            Dim dtFinSemaine As Date = Me.MonthCalendar1.SelectionStart
            Do Until dtDebutSemaine.DayOfWeek = DayOfWeek.Monday
                dtDebutSemaine = dtDebutSemaine.AddDays(-1)
            Loop
            Do Until dtFinSemaine.DayOfWeek = DayOfWeek.Sunday
                dtFinSemaine = dtFinSemaine.AddDays(1)
            Loop
            'FiltreDate = "(DateEv>=#" & dtDebutSemaine.ToString("MM/dd/yyyy") & "# And DateEv<=#" & dtFinSemaine.ToString("MM/dd/yyyy") & "#)"
            Me.dtDebut.Value = dtDebutSemaine.AddDays(nSemaine * 7)
            Me.dtFin.Value = dtFinSemaine.AddDays(nSemaine * 7)
        End If
        FiltreDate = "(DateEv>=#" & dtDebut.Value.ToString("MM/dd/yyyy") & "# And DateEv<=#" & Me.dtFin.Value.ToString("MM/dd/yyyy") & "#)"
        _LibellePeriode = ""
        If Me.Mois = False And Me.Jour = False And Me.Semaine = False Then
            If Me.dtDebut.Value = Convert.ToDateTime("01/01/05") Then
                FiltreDate = "(DateEv<=#" & Me.dtFin.Value.ToString("MM/dd/yyyy") & "#)"
                _LibellePeriode = "avant le " & Me.dtFin.Value.ToString("dddd dd MMMM yyyy")
            End If
        End If
        If _LibellePeriode.Length = 0 Then
            If Me.dtDebut.Value = Me.dtFin.Value Then
                _LibellePeriode = "le " & Me.dtDebut.Value.ToString("dddd dd MMMM yyyy")
            Else
                _LibellePeriode = "du " & Me.dtDebut.Value.ToString("dddd dd MMMM yyyy") & " au " & Me.dtFin.Value.ToString("dddd dd MMMM yyyy")
            End If
        End If

        If Not dv Is Nothing Then
            RefreshData()
        End If
    End Sub

    Private Sub BtAvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAvance.Click
        If Me.Semaine = True Then
            nSemaine += 1
        End If
        If Me.Mois = True Then
            nMois += 1
        End If
        If Me.Jour = True Then
            nJour += 1
        End If
        Me.dtDebut_ValueChanged(Me.dtDebut, New EventArgs)
    End Sub

    Private Sub BtRecule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRecule.Click
        If Me.Semaine = True Then
            nSemaine -= 1
        End If
        If Me.Mois = True Then
            nMois -= 1
        End If
        If Me.Jour = True Then
            nJour -= 1
        End If
        Me.dtDebut_ValueChanged(Me.dtDebut, New EventArgs)
    End Sub
End Class

Public Class ListeTypenImage
    Dim lstnImage As Hashtable

    Sub New(ByVal dt As DataTable)
        Dim rw() As DataRow
        Dim rwi As DataRow
        lstnImage = New Hashtable
        rw = dt.Select("NomChoix='ListeTypeEv'")
        For Each rwi In rw
            If Not IsDBNull(rwi("Valeur")) Then
                If IsDBNull(rwi("nImage")) Then
                    lstnImage.Add(rwi("Valeur"), 0)
                Else
                    lstnImage.Add(rwi("Valeur"), rwi("nImage"))
                End If
            End If
        Next
    End Sub

    Public Function GetnImage(ByVal strType As String) As Integer
        If lstnImage.ContainsKey(strType) Then
            Return CType(lstnImage.Item(strType), Integer)
        Else
            Return -1
        End If
    End Function

End Class
