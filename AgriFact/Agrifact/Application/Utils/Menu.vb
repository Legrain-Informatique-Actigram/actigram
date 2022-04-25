Imports System.Xml.Serialization
Namespace GestionMenu
    Public Class Menu
        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public Specifique As Boolean
        <XmlArray(), XmlArrayItem("Item", GetType(Item))> _
        Public Items As New List(Of Item)

        Public Shared Function LoadFromString(ByVal s As String) As List(Of Menu)
            Dim xser As New XmlSerializer(GetType(List(Of Menu)))
            Dim st As New IO.StringReader(s)
            Dim res As List(Of Menu) = DirectCast(xser.Deserialize(st), List(Of Menu))
            st.Close()
            Return res
        End Function

        Public Shared Function ListerMenus() As List(Of Menu)
            Dim menus As List(Of Menu) = GestionMenu.Menu.LoadFromString(My.Resources.Menus)
            'If My.User.Name <> Utilisateur.ADMIN Then
            '    If My.Users.Utilisateur.MenusAffiches.Count > 0 Then
            '        menus.RemoveAll(AddressOf My.Users.Utilisateur.IsMenuSpecifiqueNotSet)
            '        For Each m As Menu In menus
            '            m.Items.RemoveAll(AddressOf My.Users.Utilisateur.IsItemSpecifiqueNotSet)
            '        Next
            '    End If
            '    If My.Users.Utilisateur.MenusMasques.Count > 0 Then
            '        menus.RemoveAll(AddressOf My.Users.Utilisateur.IsMenuMasque)
            '        For Each m As Menu In menus
            '            m.Items.RemoveAll(AddressOf My.Users.Utilisateur.IsItemMasque)
            '        Next
            '    End If
            'End If
            Return menus
        End Function

        Public Shared Sub ChargerMenus(ByVal NavPane As Ascend.Windows.Forms.NavigationPane, ByVal ClickDelegate As System.EventHandler)
            Dim menus As List(Of Menu) = ListerMenus()
            NavPane.NavigationPages.Clear()
            For Each m As Menu In menus
                Dim npp As New Ascend.Windows.Forms.NavigationPanePage
                With npp
                    .Font = NavPane.Font
                    .Tag = m
                    .Key = m.Nom
                    .Name = "npp" & m.Nom
                    .Text = m.Text
                    '.Visible = Not m.Specifique
                    If m.Image.Length > 0 Then
                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(m.Image), Image)
                    End If
                    ConfigNavPage(npp)
                    Dim layout As New FlowLayoutPanel
                    With layout
                        .Dock = DockStyle.Fill
                        .FlowDirection = FlowDirection.TopDown
                    End With
                    .Controls.Add(layout)
                    With layout
                        For Each i As Item In m.Items
                            Select Case i.Type
                                Case Item.ItemType.MenuItem
                                    Dim lnk As New LinkLabel
                                    With lnk
                                        .Tag = i
                                        .AutoSize = True
                                        .Height = i.IconSize
                                        .Width = NavPane.Width - 10
                                        .Name = i.Nom
                                        .TextAlign = ContentAlignment.MiddleLeft
                                        .ImageAlign = ContentAlignment.MiddleLeft
                                        .Padding = New Padding(i.IconSize, 0, 0, 0)
                                        .Margin = New Padding(3)
                                        .Font = NavPane.Font
                                        '.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                        .ForeColor = Color.DarkBlue
                                        .LinkColor = Color.DarkBlue
                                        .LinkBehavior = LinkBehavior.HoverUnderline
                                        If i.Image.Length > 0 Then
                                            .Image = DirectCast(My.Resources.ResourceManager.GetObject(i.Image), Image)
                                        End If
                                        .Text = i.Text
                                        .Visible = Not i.Specifique
                                        AddHandler .Click, ClickDelegate
                                    End With
                                    .Controls.Add(lnk)
                                Case Item.ItemType.Separator
                                    Dim gc As Ascend.Windows.Forms.GradientCaption = CreateMenuSeparator(i.Text, NavPane.Width - 2)
                                    .Controls.Add(gc)
                            End Select
                        Next
                    End With
                End With
                If Not m.Specifique Then
                    NavPane.NavigationPages.Add(npp)
                End If
            Next
            If NavPane.NavigationPages.Count > 0 Then
                NavPane.SelectedIndex = 0
            End If
        End Sub

        Private Shared Sub ConfigNavPage(ByVal npp As Ascend.Windows.Forms.NavigationPanePage)
            With npp
                .ActiveGradientHighColor = System.Drawing.Color.White
                .ActiveGradientLowColor = System.Drawing.Color.Orange
                .ButtonFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
                .ButtonForeColor = System.Drawing.Color.DarkBlue
                .GradientHighColor = System.Drawing.Color.White
                .GradientLowColor = System.Drawing.Color.LightSteelBlue
                .HighlightGradientHighColor = System.Drawing.Color.White
                .HighlightGradientLowColor = System.Drawing.Color.SteelBlue
                .ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
                .ImageFooter = Nothing
                .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            End With
        End Sub

        Private Shared Function CreateMenuSeparator(ByVal text As String, ByVal width As Integer) As Ascend.Windows.Forms.GradientCaption
            Dim gc As New Ascend.Windows.Forms.GradientCaption
            With gc
                .Border = New Ascend.Border(0, 1, 0, 2)
                .BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
                .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .GradientHighColor = System.Drawing.SystemColors.InactiveCaption
                .GradientLowColor = System.Drawing.SystemColors.Window
                .GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
                .Size = New System.Drawing.Size(width, 20)
                .Text = text
            End With
            Return gc
        End Function

        Public Shared Sub ChargerMenus(ByVal lv As ListView)
            Dim menus As List(Of Menu) = ListerMenus()
            lv.Items.Clear()
            With lv.Groups
                .Clear()
                .Add("crayon16", "Saisies")
                .Add("liste", "Listes")
                .Add("table", "Récaps")
                .Add("impr", "Etats")
                .Add("import", "Imports")
            End With
            For Each m As Menu In menus
                For Each i As Item In m.Items
                    Select Case i.Type
                        Case Item.ItemType.MenuItem
                            Dim lvi As New ListViewItem
                            If lv.Groups(i.Image) Is Nothing Then
                                lv.Groups.Add(i.Image, i.Image)
                            End If
                            With lvi
                                .Tag = i
                                .Text = i.Text
                                .Name = i.Nom
                                .ImageKey = m.Image
                                .Group = lv.Groups(i.Image)
                            End With
                            lv.Items.Add(lvi)
                    End Select
                Next
            Next
        End Sub

        Public Shared Sub ApplyFrameHeaderStyle(ByVal gc As Ascend.Windows.Forms.GradientCaption)
            With gc
                .CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
                .Font = New Font(SystemFonts.MenuFont, FontStyle.Bold)
                .ForeColor = System.Drawing.SystemColors.WindowText
                .GradientHighColor = System.Drawing.SystemColors.Window
                .GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
                .RenderMode = Ascend.Windows.Forms.RenderMode.Glass
            End With
            
        End Sub
    End Class

    Public Class Item
        Public Enum ItemType
            MenuItem
            Separator
        End Enum

        <XmlAttribute()> Public Type As ItemType
        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public Form As String
        <XmlAttribute()> Public IconSize As Integer
        <XmlAttribute()> Public Specifique As Boolean
        <XmlAttribute()> Public Dialog As Boolean
    End Class
End Namespace

