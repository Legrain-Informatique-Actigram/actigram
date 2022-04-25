Imports Ascend.Windows.Forms
Namespace GestionMenu
    Public Class AscendSidebar

        Public Event MenuItemClick(ByVal sender As Object, ByVal e As EventArgs)

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal menus As List(Of GestionMenu.Menu))
            Me.New()
            Me.Menus = menus
        End Sub
#End Region

#Region "Propriétés"
        Private _menus As List(Of GestionMenu.Menu)
        Public Property Menus() As List(Of GestionMenu.Menu)
            Get
                Return _menus
            End Get
            Set(ByVal value As List(Of GestionMenu.Menu))
                _menus = value
            End Set
        End Property
#End Region

#Region "Form"
        Private Sub AscendSidebar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ClearMenus()
            If Me.Menus Is Nothing Then Exit Sub
            LoadMenus()
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub ItemClicked(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent MenuItemClick(sender, e)
        End Sub

        Public Sub ClearMenus()
            Me.mylayout.Controls.Clear()
            Me.mylayout.RowStyles.Clear()
            Me.mylayout.RowCount = 1
        End Sub

        Public Sub LoadMenus(ByVal menus As List(Of Menu))
            Me.Menus = menus
            LoadMenus()
        End Sub

        Public Sub LoadMenus()
            ClearMenus()

            Dim clickDelegate As New EventHandler(AddressOf Me.ItemClicked)
            Me.mylayout.RowCount = Menus.Count * 2
            Dim j As Integer = 0
            For Each m As Menu In Menus
                Me.mylayout.Controls.Add(CreateMenuHeader(m))
                Me.mylayout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim menuPanel As New GradientPanel
                With menuPanel
                    .AntiAlias = True
                    .CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
                    .Margin = New Padding(0)
                    .Dock = DockStyle.Fill
                    .GradientHighColor = SystemColors.Window
                    .GradientLowColor = SystemColors.Window
                End With
                Dim itemLayout As New FlowLayoutPanel
                With itemLayout
                    .Padding = New Padding(0, 3, 0, 0)
                    .Top = 0
                    .Left = 0
                    .Width = Me.Width
                    .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    .AutoSize = True
                    .FlowDirection = FlowDirection.TopDown
                End With
                With itemLayout
                    For Each i As Item In m.Items
                        Select Case i.Type
                            Case Item.ItemType.MenuItem
                                Dim lnk As New LinkLabel
                                With lnk
                                    .Enabled = m.Enabled AndAlso i.Enabled
                                    .Tag = i
                                    .AutoSize = False
                                    .Height = i.IconSize
                                    .Width = Me.Width - 10
                                    .Name = i.Nom
                                    .TextAlign = ContentAlignment.MiddleLeft
                                    .ImageAlign = ContentAlignment.MiddleLeft
                                    .Margin = New Padding(3)
                                    .Padding = New Padding(i.IconSize, 0, 0, 0)
                                    If i.Image.Length > 0 Then
                                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(i.Image), Image)
                                        If i.ImageTransparentColor.Length > 0 Then
                                            CType(.Image, Bitmap).MakeTransparent(Color.FromName(i.ImageTransparentColor))
                                        End If
                                    End If
                                    .Text = i.Text
                                    AddHandler .Click, clickDelegate
                                End With
                                .Controls.Add(lnk)
                            Case Item.ItemType.Separator
                                Dim gc As Ascend.Windows.Forms.GradientCaption = CreateMenuSeparator(i.Text)
                                .Controls.Add(gc)
                        End Select
                    Next
                    'Filler
                    Dim filler As New Label
                    filler.Height = 10
                    .Controls.Add(filler)
                End With
                menuPanel.Controls.Add(itemLayout)
                Me.mylayout.Controls.Add(menuPanel)
                Me.mylayout.RowStyles.Add(New RowStyle(SizeType.Absolute, itemLayout.Height))
            Next
        End Sub
#End Region

#Region "Méthodes partagées"
        Private Shared Function CreateMenuSeparator(ByVal text As String) As Ascend.Windows.Forms.GradientCaption
            Dim gc As New Ascend.Windows.Forms.GradientCaption
            With gc
                .Border = New Ascend.Border(0, 0, 0, 2)
                .BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
                .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .BackColor = Color.Transparent
                .ForeColor = SystemColors.WindowText
                .RenderMode = RenderMode.Flat
                .GradientHighColor = Color.Transparent
                .GradientLowColor = Color.Transparent
                .Text = text
            End With
            Return gc
        End Function

        Private Shared Function CreateMenuHeader(ByVal m As Menu) As GradientCaption
            Dim menuHeader As New GradientCaption
            With menuHeader
                .Tag = m
                .Dock = System.Windows.Forms.DockStyle.Top
                .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
                .Border = New Ascend.Border(0, 1, 0, 0)
                .BorderColor = New Ascend.BorderColor(Color.MidnightBlue)
                .ForeColor = System.Drawing.Color.White
                .GradientHighColor = System.Drawing.Color.AliceBlue
                .GradientLowColor = System.Drawing.Color.SteelBlue
                .RenderMode = Ascend.Windows.Forms.RenderMode.Glass
                .ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
                .Margin = New System.Windows.Forms.Padding(0)
                .Name = "npp" & m.Nom
                .Text = m.Text
                .Height = 30
                If m.Image.Length > 0 Then
                    .Image = DirectCast(My.Resources.ResourceManager.GetObject(m.Image), Image)
                End If
            End With
            Return menuHeader
        End Function
#End Region

    End Class
End Namespace