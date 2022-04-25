Imports GRC

Public Class FrStatistiques
    Inherits System.Windows.Forms.Form

    Private Dossier As String = "Etats\RptStatsClients"
    Private Rapport As Rapport

#Region "Constructeur"
    Public Sub New(ByVal strDossier As String)
        Me.New()
        Me.Dossier = strDossier
    End Sub
#End Region

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
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvModeles As System.Windows.Forms.TreeView
    Friend WithEvents paramsLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents gcModeles As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents ilTree As System.Windows.Forms.ImageList
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrStatistiques))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tvModeles = New System.Windows.Forms.TreeView
        Me.ilTree = New System.Windows.Forms.ImageList(Me.components)
        Me.gcModeles = New Ascend.Windows.Forms.GradientCaption
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.paramsLayout = New System.Windows.Forms.FlowLayoutPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        ''
        ''ImageList16
        ''
        'Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.ImageList16.Images.SetKeyName(0, "")
        ''
        ''ImageList32
        ''
        'Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.ImageList32.Images.SetKeyName(0, "")
        'Me.ImageList32.Images.SetKeyName(1, "")
        'Me.ImageList32.Images.SetKeyName(2, "")
        'Me.ImageList32.Images.SetKeyName(3, "")
        'Me.ImageList32.Images.SetKeyName(4, "")
        'Me.ImageList32.Images.SetKeyName(5, "")
        'Me.ImageList32.Images.SetKeyName(6, "")
        'Me.ImageList32.Images.SetKeyName(7, "")
        'Me.ImageList32.Images.SetKeyName(8, "")
        'Me.ImageList32.Images.SetKeyName(9, "")
        'Me.ImageList32.Images.SetKeyName(10, "")
        'Me.ImageList32.Images.SetKeyName(11, "")
        ''
        ''ImageList24
        ''
        'Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.ImageList24.Images.SetKeyName(0, "")
        'Me.ImageList24.Images.SetKeyName(1, "")
        'Me.ImageList24.Images.SetKeyName(2, "")
        'Me.ImageList24.Images.SetKeyName(3, "")
        'Me.ImageList24.Images.SetKeyName(4, "")
        'Me.ImageList24.Images.SetKeyName(5, "")
        'Me.ImageList24.Images.SetKeyName(6, "")
        'Me.ImageList24.Images.SetKeyName(7, "")
        'Me.ImageList24.Images.SetKeyName(8, "")
        'Me.ImageList24.Images.SetKeyName(9, "")
        'Me.ImageList24.Images.SetKeyName(10, "")
        'Me.ImageList24.Images.SetKeyName(11, "")
        'Me.ImageList24.Images.SetKeyName(12, "")
        'Me.ImageList24.Images.SetKeyName(13, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbImpr, Me.TbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(720, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbImpr
        '
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(94, 36)
        Me.TbImpr.Text = "Afficher..."
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 36)
        Me.TbClose.Text = "Fermer"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvModeles)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gcModeles)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GradientPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GradientCaption1)
        Me.SplitContainer1.Size = New System.Drawing.Size(720, 392)
        Me.SplitContainer1.SplitterDistance = 308
        Me.SplitContainer1.TabIndex = 15
        '
        'tvModeles
        '
        Me.tvModeles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvModeles.FullRowSelect = True
        Me.tvModeles.HotTracking = True
        Me.tvModeles.ImageIndex = 0
        Me.tvModeles.ImageList = Me.ilTree
        Me.tvModeles.Location = New System.Drawing.Point(0, 24)
        Me.tvModeles.Name = "tvModeles"
        Me.tvModeles.SelectedImageIndex = 0
        Me.tvModeles.ShowLines = False
        Me.tvModeles.ShowRootLines = False
        Me.tvModeles.Size = New System.Drawing.Size(308, 368)
        Me.tvModeles.TabIndex = 0
        '
        'ilTree
        '
        Me.ilTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilTree.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilTree.TransparentColor = System.Drawing.Color.Transparent
        '
        'gcModeles
        '
        Me.gcModeles.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcModeles.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gcModeles.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.gcModeles.Location = New System.Drawing.Point(0, 0)
        Me.gcModeles.Name = "gcModeles"
        Me.gcModeles.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.gcModeles.Size = New System.Drawing.Size(308, 24)
        Me.gcModeles.TabIndex = 1
        Me.gcModeles.Text = "Modèles"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.Controls.Add(Me.paramsLayout)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 24)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(408, 368)
        Me.GradientPanel1.TabIndex = 20
        '
        'paramsLayout
        '
        Me.paramsLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paramsLayout.Location = New System.Drawing.Point(5, 5)
        Me.paramsLayout.Name = "paramsLayout"
        Me.paramsLayout.Size = New System.Drawing.Size(398, 358)
        Me.paramsLayout.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(408, 24)
        Me.GradientCaption1.TabIndex = 21
        Me.GradientCaption1.Text = "Paramètres"
        '
        'FrStatistiques
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrStatistiques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assistant Statistiques Clients"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Page"
    Private Sub FrAssistantRequete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.gcModeles)
        With ilTree.Images
            .Add("rpt", My.Resources.report)
        End With
    End Sub

    Private Sub FrStatistiques_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ChargerModeles()
    End Sub
#End Region

#Region "TreeView"
    Private Sub tvModeles_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvModeles.AfterSelect
        Me.Rapport = Nothing
        ChargerReport(CType(e.Node.Tag, String))
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtAfficher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        Me.AfficheResultat()
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerModeles()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.tvModeles.BeginUpdate()
        Try
            Dim dir As String = CheminComplet(Dossier)
            If IO.Directory.Exists(dir) Then
                For Each fl As String In IO.Directory.GetFiles(dir, "*.rpt")
                    AjouterNode(fl)
                Next
            End If
        Finally
            Me.tvModeles.EndUpdate()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AjouterNode(ByVal path As String)
        Dim n As New TreeNode
        With n
            .Text = IO.Path.GetFileNameWithoutExtension(path)
            .ImageKey = "rpt"
            .Tag = path
        End With
        Me.tvModeles.Nodes.Add(n)
    End Sub

    Private Sub ChargerReport(ByVal strCheminEtat As String)
        Me.paramsLayout.Controls.Clear()
        Me.TbImpr.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim rapport As New Rapport(strCheminEtat)
            If Not rapport.IsLoaded Then
                rapport.LoadReport()
            End If
            If rapport.Name = "Erreur" Then
                Me.tvModeles.SelectedNode.ForeColor = Color.Red
                Exit Sub
            Else
                Me.tvModeles.SelectedNode.ForeColor = Me.tvModeles.ForeColor
            End If

            Me.Rapport = rapport

            For Each p As Parameter In rapport.Parameters
                AddControl(p)
            Next

            Me.TbImpr.Enabled = True
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AddControl(ByVal p As Parameter)
        Dim ctl As Control = CreateParamControl(p)
        Dim lb As New Label()
        With lb
            .Width = 200
            .Height = ctl.Height
            If p.ReportName = "" Then
                .Text = p.Description
            Else
                .Text = String.Format("{0} - {1}", p.ReportName, p.Description)
            End If
        End With
        With paramsLayout
            .Controls.Add(lb)
            .Controls.Add(ctl)
            .SetFlowBreak(ctl, True)
        End With
    End Sub

    Private Function CreateParamControl(ByVal p As Parameter) As Control
        Dim ctl As Control
        If p.Type Is GetType(Date) Then
            ctl = New DateTimePicker
            ctl.DataBindings.Add("Value", p, "Value", True, DataSourceUpdateMode.OnPropertyChanged, Now)
            p.Value = Now
            Select Case p.Format
                Case "d"
                    With CType(ctl, DateTimePicker)
                        .Format = DateTimePickerFormat.Short
                        .Width = 87
                    End With
                Case "T"
                    With CType(ctl, DateTimePicker)
                        .Format = DateTimePickerFormat.Time
                        .ShowUpDown = True
                        .Width = 87
                    End With
                Case "G"
                    With CType(ctl, DateTimePicker)
                        .Format = DateTimePickerFormat.Custom
                        .CustomFormat = "dd/MM/yyyy HH:mm:ss"
                        .Width = 134
                    End With
            End Select
        ElseIf p.Type Is GetType(Boolean) Then
            ctl = New CheckBox
            ctl.DataBindings.Add("Checked", p, "Value", False, DataSourceUpdateMode.OnPropertyChanged, False)
        ElseIf p.Type Is GetType(Decimal) Then
            ctl = New TextBox
            Dim b As Binding = ctl.DataBindings.Add("Text", p, "Value", True, DataSourceUpdateMode.OnValidation, 0)
            With b
                .FormatString = p.Format
                AddHandler .Parse, AddressOf CurrencyParse
            End With
        Else
            ctl = New TextBox
            ctl.DataBindings.Add("Text", p, "Value", False, DataSourceUpdateMode.OnValidation, "")
        End If
        ctl.Name = "ctl" & p.Name
        ctl.Tag = p
        Return ctl
    End Function

    Private Sub AfficheResultat()
        Try
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Me.Rapport.ShowReport(Me)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

End Class
