Public Class Accueil
    Implements IMenu

    Public Event MenuItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Implements IMenu.MenuItemActivate

#Region "Page"
    Private Sub Accueil_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lvMenus.BeginUpdate()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)
        With ilIcons
            .Images.Add("_new", My.Resources.IconesAccueil.wi0062_48)
            .Images.Add("book", My.Resources.IconesAccueil.book_48)
            .Images.Add("impr", My.Resources.IconesAccueil.printer_48)
            .Images.Add("find", My.Resources.find)
            .Images.Add("export", My.Resources.export)
            .Images.Add("liste", My.Resources.liste)
            .Images.Add("restore", My.Resources.restore)
            .Images.Add("save", My.Resources.save)
        End With
        GestionMenu.Menu.ChargerMenus(Me.lvMenus)
    End Sub
#End Region

    Private Sub Me_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Me.LbTitre.Text = Me.Text
    End Sub

    Private Sub lvMenus_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMenus.ItemActivate
        If lvMenus.SelectedItems.Count = 0 OrElse lvMenus.SelectedItems(0).ForeColor = SystemColors.GrayText Then Exit Sub
        RaiseEvent MenuItemActivate(lvMenus.SelectedItems(0), e)
    End Sub

End Class
