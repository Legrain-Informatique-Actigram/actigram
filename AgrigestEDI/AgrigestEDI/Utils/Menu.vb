Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization

Namespace GestionMenu
    ''' <summary>
    ''' Class permettant la gestion du menu latéral
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Menu
        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public ImageTransparentColor As String = ""
        <XmlAttribute()> Public Specifique As Boolean
        <XmlArray(), XmlArrayItem("Item", GetType(Item))> _
        Public Items As New List(Of Item)

#Region "Propriétés"
        <XmlIgnore()> Public ReadOnly Property Enabled() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Méthodes partagées"
        Public Shared Function LoadFromString(ByVal s As String) As List(Of Menu)
            Dim xser As New XmlSerializer(GetType(List(Of Menu)))
            Dim st As New IO.StringReader(s)
            Dim res As List(Of Menu) = DirectCast(xser.Deserialize(st), List(Of Menu))
            st.Close()
            Return res
        End Function

        Public Shared Function ListerMenus() As List(Of Menu)
            Dim menus As List(Of Menu) = GestionMenu.Menu.LoadFromString(My.Resources.Menus)
            Return menus
        End Function

        Public Shared Sub ChargerMenus(ByVal NavPane As Ascend.Windows.Forms.NavigationPane, ByVal ClickDelegate As System.EventHandler)
            Dim menus As List(Of Menu) = ListerMenus()
            NavPane.NavigationPages.Clear()
            For Each m As Menu In menus
                Dim npp As New Ascend.Windows.Forms.NavigationPanePage
                With npp
                    .Tag = m
                    .Key = m.Nom
                    .Name = "npp" & m.Nom
                    .Text = m.Text
                    If m.Image.Length > 0 Then
                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(m.Image), Image)
                    End If
                    Dim lnkTop As Integer = 0
                    For Each i As Item In m.Items
                        Select Case i.Type
                            Case Item.ItemType.MenuItem
                                lnkTop += 2
                                Dim lnk As New LinkLabel
                                With lnk
                                    'Permet de d'activer ou pas le lien en fonction du chargement du dossier
                                    'S'il existe le dossier, le bouton est actif
                                    If i.LockEmptyDossier And My.User.Name = "" Then
                                        .Enabled = False
                                    End If
                                    .Tag = i
                                    .Top = lnkTop
                                    .AutoSize = False
                                    .Height = i.IconSize
                                    .Width = NavPane.Width - 10
                                    .Name = i.Nom
                                    .TextAlign = ContentAlignment.MiddleLeft
                                    .ImageAlign = ContentAlignment.MiddleLeft
                                    .Padding = New Padding(i.IconSize, 0, 0, 0)
                                    If i.Image.Length > 0 Then
                                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(i.Image), Image)
                                    End If
                                    .Text = i.Text
                                    'If i.Form.Length = 0 Then .Enabled = False
                                    AddHandler .Click, ClickDelegate
                                    lnkTop += .Height
                                End With
                                .Controls.Add(lnk)
                            Case Item.ItemType.Separator
                                If lnkTop > 0 Then lnkTop += 5
                                Dim gc As Ascend.Windows.Forms.GradientCaption = CreateMenuSeparator(i.Text, lnkTop, NavPane.Width - 2)
                                lnkTop += gc.Height + 2
                                .Controls.Add(gc)
                        End Select
                    Next
                End With
                NavPane.NavigationPages.Add(npp)
            Next
            If NavPane.NavigationPages.Count > 0 Then
                NavPane.SelectedIndex = 0
            End If
        End Sub

        Private Shared Function CreateMenuSeparator(ByVal text As String, ByVal top As Integer, ByVal width As Integer) As Ascend.Windows.Forms.GradientCaption
            Dim gc As New Ascend.Windows.Forms.GradientCaption
            With gc
                .Border = New Ascend.Border(0, 1, 0, 2)
                .BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
                .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .GradientHighColor = System.Drawing.SystemColors.InactiveCaption
                .GradientLowColor = System.Drawing.SystemColors.Window
                .GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
                .Location = New System.Drawing.Point(0, top)
                .Size = New System.Drawing.Size(width, 20)
                .Text = text
            End With
            Return gc
        End Function

        ''' <summary>
        ''' Permet d'afficher le menu sur la page d'acceuil
        ''' </summary>
        ''' <param name="lv"></param>
        ''' <remarks></remarks>
        Public Shared Sub ChargerMenus(ByVal lv As ListView)
            Dim menus As List(Of Menu) = ListerMenus()
            lv.Items.Clear()
            With lv.Groups
                .Clear()
            End With
            For Each m As Menu In menus
                For Each i As Item In m.Items
                    If i.Acceuil Then
                        Select Case i.Type
                            Case Item.ItemType.Separator
                                lv.Groups.Add(i.Nom, i.Text)
                            Case Item.ItemType.MenuItem
                                Dim lvi As New ListViewItem
                                With lvi
                                    .Tag = i
                                    .Text = i.Text
                                    .Name = i.Nom
                                    .ImageKey = i.Image
                                    .Group = lv.Groups(i.Master)
                                    If (i.LockEmptyDossier And My.User.Name = "") Then
                                        .ForeColor = SystemColors.GrayText
                                    End If
                                    .SubItems.Add(i.Description)
                                End With
                                lv.Items.Add(lvi)
                        End Select
                    End If
                Next
            Next
        End Sub
#End Region

    End Class

    Public Class Item

        Public Enum ItemType
            MenuItem
            Separator
        End Enum

        <XmlAttribute()> Public Type As ItemType
        <XmlAttribute()> Public Master As String
        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        Public Description As String = ""
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public ImageTransparentColor As String = ""
        <XmlAttribute()> Public Form As String
        <XmlAttribute()> Public IconSize As Integer
        <XmlAttribute()> Public LockEmptyDossier As Boolean
        <XmlAttribute()> Public Specifique As Boolean
        <XmlAttribute()> Public Dialog As Boolean
        <XmlAttribute()> Public Acceuil As Boolean

#Region "Propriétés"
        <XmlIgnore()> Public ReadOnly Property Enabled() As Boolean
            Get
                Return Not (LockEmptyDossier AndAlso My.User.Name = "")
            End Get
        End Property
#End Region

    End Class
End Namespace

Namespace GestionMenuEtats
    Public Class Menu

        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public Specifique As Boolean
        <XmlArray(), XmlArrayItem("Item", GetType(Item))> _
        Public Items As New List(Of Item)

#Region "Méthodes partagées"
        Public Shared Function LoadFromString(ByVal s As String) As List(Of Menu)
            Dim xser As New XmlSerializer(GetType(List(Of Menu)))
            Dim st As New IO.StringReader(s)
            Dim res As List(Of Menu) = DirectCast(xser.Deserialize(st), List(Of Menu))
            st.Close()
            Return res
        End Function

        Public Shared Function ListerMenus() As List(Of Menu)
            Dim menus As List(Of Menu) = GestionMenuEtats.Menu.LoadFromString(My.Resources.Etats)
            Return menus
        End Function

        Public Shared Sub ChargerMenus(ByVal NavPane As Ascend.Windows.Forms.NavigationPane, ByVal ClickDelegate As System.EventHandler)
            Dim menus As List(Of Menu) = ListerMenus()
            NavPane.NavigationPages.Clear()
            For Each m As Menu In menus
                Dim npp As New Ascend.Windows.Forms.NavigationPanePage
                With npp
                    .Tag = m
                    .Key = m.Nom
                    .Name = "npp" & m.Nom
                    .Text = m.Text
                    If m.Image.Length > 0 Then
                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(m.Image), Image)
                    End If
                    Dim lnkTop As Integer = 0
                    For Each i As Item In m.Items
                        Select Case i.Type
                            Case Item.ItemType.MenuItem
                                lnkTop += 2
                                Dim lnk As New LinkLabel
                                With lnk
                                    If i.LockEmptyDossier And My.User.Name = "" Then
                                        .Enabled = False
                                    End If
                                    .Tag = i
                                    .Top = lnkTop
                                    .AutoSize = False
                                    .Height = i.IconSize
                                    .Width = NavPane.Width - 10
                                    .Name = i.Nom
                                    .TextAlign = ContentAlignment.MiddleLeft
                                    .ImageAlign = ContentAlignment.MiddleLeft
                                    .Padding = New Padding(i.IconSize, 0, 0, 0)
                                    If i.Image.Length > 0 Then
                                        .Image = DirectCast(My.Resources.ResourceManager.GetObject(i.Image), Image)
                                    End If
                                    .Text = i.Text
                                    If i.Etat.Length = 0 Then .Enabled = False
                                    AddHandler .Click, ClickDelegate
                                    lnkTop += .Height
                                End With
                                .Controls.Add(lnk)
                            Case Item.ItemType.Separator
                                If lnkTop > 0 Then lnkTop += 5
                                Dim gc As Ascend.Windows.Forms.GradientCaption = CreateMenuSeparator(i.Text, lnkTop, NavPane.Width - 2)
                                lnkTop += gc.Height + 2
                                .Controls.Add(gc)
                        End Select
                    Next
                End With
                NavPane.NavigationPages.Add(npp)
            Next
            If NavPane.NavigationPages.Count > 0 Then
                NavPane.SelectedIndex = 0
            End If
        End Sub

        Private Shared Function CreateMenuSeparator(ByVal text As String, ByVal top As Integer, ByVal width As Integer) As Ascend.Windows.Forms.GradientCaption
            Dim gc As New Ascend.Windows.Forms.GradientCaption
            With gc
                .Border = New Ascend.Border(0, 1, 0, 2)
                .BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
                .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .GradientHighColor = System.Drawing.SystemColors.InactiveCaption
                .GradientLowColor = System.Drawing.SystemColors.Window
                .GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
                .Location = New System.Drawing.Point(0, top)
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
            End With
            For Each m As Menu In menus
                For Each i As Item In m.Items
                    Select Case i.Type
                        Case Item.ItemType.Separator
                            Dim lvi As New ListViewItem
                            lv.Groups.Add(i.Text, i.Text)
                        Case Item.ItemType.MenuItem
                            Dim lvi As New ListViewItem
                            With lvi
                                .Tag = i
                                .Text = i.Text
                                .Name = i.Nom
                                .ImageKey = i.Image
                                .Group = lv.Groups(i.Master)
                            End With
                            lv.Items.Add(lvi)
                    End Select
                Next
            Next
        End Sub
#End Region

    End Class

    Public Class Item

        Public Enum ItemType
            MenuItem
            Separator
        End Enum

        <XmlAttribute()> Public Type As ItemType
        <XmlAttribute()> Public Master As String
        <XmlAttribute()> Public Nom As String
        <XmlAttribute()> Public Text As String
        <XmlAttribute()> Public Image As String
        <XmlAttribute()> Public Etat As String
        <XmlAttribute()> Public IconSize As Integer
        <XmlAttribute()> Public LockEmptyDossier As Boolean
        <XmlAttribute()> Public Specifique As Boolean
        <XmlAttribute()> Public Dialog As Boolean
    End Class
End Namespace
