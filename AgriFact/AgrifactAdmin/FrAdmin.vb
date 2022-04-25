Public Class FrAdmin
    Inherits System.Windows.Forms.Form

    Private Const CONNECTION_STRING As String = "data source={0};initial catalog={1};user id={2};password={3};persist security info=True"
    Private cn As SqlClient.SqlConnection
    Private XPEnCours As MenuEnCours

    Enum MenuEnCours
        Utilisateur
        Groupe
        Organisme
        Contact
        Evenement
        Produit
        ABonReception
        AFacture
        VDevis
        VBonCommande
        VBonLivraison
        VFacture
        Banque
        Lot
        Famille
        GroupeArticle
        TVA
        Mouvement
        VReglement
        AReglement
        VRemise
    End Enum


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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents XpBar1 As Actigram.Windows.Forms.XPBar
    Friend WithEvents ImageList24 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList16 As System.Windows.Forms.ImageList
    Friend WithEvents Lst As System.Windows.Forms.ListView
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TbFermer As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbListe As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbIcone As System.Windows.Forms.ToolBarButton
    Friend WithEvents ContextMenuUtilisateur As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemProprietes As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSupprimer As System.Windows.Forms.MenuItem
    Friend WithEvents TbDetail As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItemNouveau As System.Windows.Forms.MenuItem
    Friend WithEvents TbMonter As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbDescendre As System.Windows.Forms.ToolBarButton
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents MenuItemApercu As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrAdmin))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.XpBar1 = New Actigram.Windows.Forms.XPBar
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Lst = New System.Windows.Forms.ListView
        Me.ContextMenuUtilisateur = New System.Windows.Forms.ContextMenu
        Me.MenuItemNouveau = New System.Windows.Forms.MenuItem
        Me.MenuItemProprietes = New System.Windows.Forms.MenuItem
        Me.MenuItemSupprimer = New System.Windows.Forms.MenuItem
        Me.MenuItemApercu = New System.Windows.Forms.MenuItem
        Me.ImageList24 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList16 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TbMonter = New System.Windows.Forms.ToolBarButton
        Me.TbDescendre = New System.Windows.Forms.ToolBarButton
        Me.TbDetail = New System.Windows.Forms.ToolBarButton
        Me.TbListe = New System.Windows.Forms.ToolBarButton
        Me.TbIcone = New System.Windows.Forms.ToolBarButton
        Me.TbFermer = New System.Windows.Forms.ToolBarButton
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.XpBar1)
        Me.Panel1.Location = New System.Drawing.Point(0, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 384)
        Me.Panel1.TabIndex = 0
        '
        'XpBar1
        '
        Me.XpBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpBar1.Angle = 15
        Me.XpBar1.AutoScroll = True
        Me.XpBar1.CouleurDroite = System.Drawing.Color.LightSteelBlue
        Me.XpBar1.CouleurFondItem = System.Drawing.Color.White
        Me.XpBar1.CouleurGauche = System.Drawing.Color.White
        Me.XpBar1.CouleurItem = System.Drawing.Color.Blue
        Me.XpBar1.CouleurSelectedItem = System.Drawing.Color.Blue
        Me.XpBar1.CouleurSelectedTitre = System.Drawing.Color.RoyalBlue
        Me.XpBar1.CouleurTitre = System.Drawing.Color.Blue
        Me.XpBar1.EcartBordure = 1.0!
        Me.XpBar1.EspaceGauche = 2.0!
        Me.XpBar1.EspaceImageText = 5.0!
        Me.XpBar1.FondFleche = System.Drawing.Color.WhiteSmoke
        Me.XpBar1.HauteurEntete = 30
        Me.XpBar1.HauteurItem = 20.0!
        Me.XpBar1.ImageList = Nothing
        Me.XpBar1.ImageListItem = Nothing
        Me.XpBar1.IntervalGroupe = 5
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Utilisateurs", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Nouveau", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Liste", System.Drawing.Color.Empty, -1, True)}, False, True))
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Groupes", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Nouveau", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Liste", System.Drawing.Color.Empty, -1, True)}, False, True))
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Base", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Organismes", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Contacts", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Evenements", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Produits", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Lots", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("ABonReception", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("AFacture", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("AReglement", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VDevis", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VBonCommande", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VBonLivraison", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VFacture", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VReglement", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("VRemise", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Familles", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Groupes", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Mouvements", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("Banques", System.Drawing.Color.Empty, -1, True)}, False, True))
        Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Administrateur", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Attacher une Base", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("UltraVNC", System.Drawing.Color.Empty, -1, True)}, False, True))
        Me.XpBar1.LeftItemText = 0.0!
        Me.XpBar1.Location = New System.Drawing.Point(0, 0)
        Me.XpBar1.Name = "XpBar1"
        Me.XpBar1.PoliceItems = New System.Drawing.Font("Comic Sans MS", 10.0!)
        Me.XpBar1.PoliceItemsSelectionnés = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Underline)
        Me.XpBar1.PoliceTitre = New System.Drawing.Font("Comic Sans MS", 12.0!)
        Me.XpBar1.Size = New System.Drawing.Size(200, 384)
        Me.XpBar1.TabIndex = 0
        Me.XpBar1.TailleRond = 8.0!
        Me.XpBar1.TitreDegrade = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.XpBar1.TransparentColorDebut = System.Drawing.Color.Gray
        Me.XpBar1.TransparentColorFin = System.Drawing.Color.White
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Lst)
        Me.Panel2.Location = New System.Drawing.Point(208, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(696, 384)
        Me.Panel2.TabIndex = 2
        '
        'Lst
        '
        Me.Lst.AllowDrop = True
        Me.Lst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lst.ContextMenu = Me.ContextMenuUtilisateur
        Me.Lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lst.HideSelection = False
        Me.Lst.LargeImageList = Me.ImageList24
        Me.Lst.Location = New System.Drawing.Point(0, 0)
        Me.Lst.Name = "Lst"
        Me.Lst.Size = New System.Drawing.Size(696, 384)
        Me.Lst.SmallImageList = Me.ImageList16
        Me.Lst.TabIndex = 0
        '
        'ContextMenuUtilisateur
        '
        Me.ContextMenuUtilisateur.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemNouveau, Me.MenuItemProprietes, Me.MenuItemSupprimer, Me.MenuItemApercu})
        '
        'MenuItemNouveau
        '
        Me.MenuItemNouveau.Index = 0
        Me.MenuItemNouveau.Text = "Nouveau"
        '
        'MenuItemProprietes
        '
        Me.MenuItemProprietes.Index = 1
        Me.MenuItemProprietes.Text = "Propriétés"
        '
        'MenuItemSupprimer
        '
        Me.MenuItemSupprimer.Index = 2
        Me.MenuItemSupprimer.Text = "Supprimer"
        '
        'MenuItemApercu
        '
        Me.MenuItemApercu.Index = 3
        Me.MenuItemApercu.Text = "Apercu"
        '
        'ImageList24
        '
        Me.ImageList24.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList24.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageList16
        '
        Me.ImageList16.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList16.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TbMonter, Me.TbDescendre, Me.TbDetail, Me.TbListe, Me.TbIcone, Me.TbFermer})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList24
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(904, 50)
        Me.ToolBar1.TabIndex = 3
        '
        'TbMonter
        '
        Me.TbMonter.ImageIndex = 3
        Me.TbMonter.Text = "Monter"
        Me.TbMonter.Visible = False
        '
        'TbDescendre
        '
        Me.TbDescendre.ImageIndex = 4
        Me.TbDescendre.Text = "Descendre"
        Me.TbDescendre.Visible = False
        '
        'TbDetail
        '
        Me.TbDetail.Text = "Detail"
        Me.TbDetail.Visible = False
        '
        'TbListe
        '
        Me.TbListe.Text = "Liste"
        Me.TbListe.Visible = False
        '
        'TbIcone
        '
        Me.TbIcone.Text = "Icones"
        Me.TbIcone.Visible = False
        '
        'TbFermer
        '
        Me.TbFermer.ImageIndex = 2
        Me.TbFermer.Text = "Fermer"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=DELL;packet size=4096;user id=sa;data source=""dell\actigram"";persi" & _
        "st security info=False;password=""ludo"""
        '
        'FrAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(904, 446)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrAdmin"
        Me.Text = "Administration"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrAdmin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cn = New SqlClient.SqlConnection(GetstrConnexion)
            cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question)
            If cn.State <> ConnectionState.Open Then
                'On n'a pas réussi à obtenir de connexion, on n'affiche que le menu "Attacher une base de données"
                Me.XpBar1.Items.Clear()
                Me.XpBar1.Items.Add(New Actigram.Windows.Forms.XPGroup("Administrateur", Me.XpBar1, -1, New Actigram.Windows.Forms.XPItem() {New Actigram.Windows.Forms.XPItem("Attacher une Base", System.Drawing.Color.Empty, -1, True), New Actigram.Windows.Forms.XPItem("UltraVNC", System.Drawing.Color.Empty, -1, True)}, False, True))
            End If
        End Try
    End Sub

    Private Sub FrAdmin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.RefreshLst()
    End Sub

    Private Sub XpBar1_ItemClick(ByVal XPItem As Actigram.Windows.Forms.XPItem) Handles XpBar1.ItemClick
        Me.TbDescendre.Visible = False
        Me.TbMonter.Visible = False

        '* Nouvel Utilisateur
        Dim str As String = XPItem.XPGroup.TextGroupe & XPItem.Text
        Select Case str
            Case "UtilisateursNouveau"
                XPEnCours = MenuEnCours.Utilisateur
                CreerUser()
            Case "UtilisateursListe"
                XPEnCours = MenuEnCours.Utilisateur
                RefreshLst()
            Case "GroupesNouveau"
                XPEnCours = MenuEnCours.Groupe
                CreerRole()
            Case "GroupesListe"
                XPEnCours = MenuEnCours.Groupe
                RefreshLst()
            Case "BaseOrganismes"
                XPEnCours = MenuEnCours.Organisme
                RefreshLst()
            Case "BaseContacts"
                XPEnCours = MenuEnCours.Contact
                RefreshLst()
            Case "BaseEvenements"
                XPEnCours = MenuEnCours.Evenement
                RefreshLst()
            Case "BaseProduits"
                XPEnCours = MenuEnCours.Produit
                RefreshLst()
            Case "BaseLots"
                XPEnCours = MenuEnCours.Lot
                RefreshLst()
            Case "BaseABonReception"
                XPEnCours = MenuEnCours.ABonReception
                RefreshLst()
            Case "BaseAFacture"
                XPEnCours = MenuEnCours.AFacture
                RefreshLst()
            Case "BaseAReglement"
                XPEnCours = MenuEnCours.AReglement
                RefreshLst()
            Case "BaseVDevis"
                XPEnCours = MenuEnCours.VDevis
                RefreshLst()
            Case "BaseVBonCommande"
                XPEnCours = MenuEnCours.VBonCommande
                RefreshLst()
            Case "BaseVBonLivraison"
                XPEnCours = MenuEnCours.VBonLivraison
                RefreshLst()
            Case "BaseVFacture"
                XPEnCours = MenuEnCours.VFacture
                RefreshLst()
            Case "BaseVReglement"
                XPEnCours = MenuEnCours.VReglement
                RefreshLst()
            Case "BaseVRemise"
                XPEnCours = MenuEnCours.VRemise
                RefreshLst()
            Case "BaseFamilles"
                XPEnCours = MenuEnCours.Famille
                RefreshLst()
            Case "BaseGroupes"
                XPEnCours = MenuEnCours.Groupe
                RefreshLst()
            Case "BaseMouvements"
                XPEnCours = MenuEnCours.Mouvement
                RefreshLst()
            Case "BaseBanques"
                XPEnCours = MenuEnCours.Banque
                RefreshLst()
            Case "AdministrateurAttacher une Base"
                Dim Fr As New FrAdminBase(cn)
                Fr.Show()
            Case "AdministrateurUltraVNC"
                LancerUltraVNC()
        End Select
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button Is Me.TbFermer Then
            Me.Close()
        ElseIf e.Button Is Me.TbIcone Then
            Me.Lst.View = View.LargeIcon
        ElseIf e.Button Is Me.TbListe Then
            Me.Lst.View = View.List
        ElseIf e.Button Is Me.TbDetail Then
            Me.Lst.View = View.Details
        ElseIf e.Button Is Me.TbMonter Then
            Select Case XPEnCours
                Case MenuEnCours.Utilisateur
                Case MenuEnCours.Groupe
                Case Else
                    Monter()
            End Select
        ElseIf e.Button Is Me.TbDescendre Then
            Select Case XPEnCours
                Case MenuEnCours.Utilisateur
                Case MenuEnCours.Groupe
                Case Else
                    Descendre()
            End Select
        End If
    End Sub

#Region "Gestion Menu contextuel"

    Private Sub MenuItemProprietes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemProprietes.Click
        If Lst.SelectedItems.Count = 1 Then
            Select Case XPEnCours
                Case MenuEnCours.Utilisateur
                    ProprieteUser()
                Case MenuEnCours.Groupe
                    ProprieteRole()
                Case Else
                    Proprietechamps()
            End Select
        End If
    End Sub

    Private Sub MenuItemSupprimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemSupprimer.Click
        Dim selectedItems(Lst.SelectedItems.Count - 1) As ListViewItem
        Lst.SelectedItems.CopyTo(selectedItems, 0)

        'BUG, les items de la listview sont deselectionnés apres le MsgBox
        If MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Select Case XPEnCours
                    Case MenuEnCours.Utilisateur
                        For Each It As ListViewItem In selectedItems
                            CType(It.Tag, Utilisateur).Supprimer(cn)
                        Next
                    Case MenuEnCours.Groupe
                        For Each It As ListViewItem In selectedItems
                            CType(It.Tag, Role).Supprimer(cn)
                        Next
                    Case Else
                        For Each It As ListViewItem In selectedItems
                            CType(It.Tag, ParamNiveau2).Supprimer(cn)
                        Next
                End Select
                MessageBox.Show("Suppression Terminée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.RefreshLst()
            End Try
        End If
    End Sub

    Private Sub MenuItemNouveau_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemNouveau.Click
        Select Case XPEnCours
            Case MenuEnCours.Utilisateur
                CreerUser()
            Case MenuEnCours.Groupe
                CreerRole()
            Case Else
                CreerChamps()
        End Select
    End Sub

    Private Sub MenuItemApercu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemApercu.Click
        Dim fr As New FrInterface(cn, ParamNiveau2.NomTableSql(XPEnCours))
        fr.Show()
    End Sub
#End Region

    Public Sub RefreshLst()
        If cn.State = ConnectionState.Open Then
            Select Case XPEnCours
                Case MenuEnCours.Utilisateur
                    Me.RefreshLstUser()
                Case MenuEnCours.Groupe
                    Me.RefreshLstGroupe()
                Case Else
                    Me.TbDescendre.Visible = True
                    Me.TbMonter.Visible = True
                    Me.Lst.View = View.Details
                    Me.RefreshLstChamps()
            End Select
        End If
    End Sub


    Private Function GetstrConnexion() As String
        FrGestionParametres.ChargerParametres()
        Dim ServeurSQL As String = CStr(FrGestionParametres.ValeurParametre("ServeurSQL", "localhost\agrifact"))
        Dim BaseSQL As String = CStr(FrGestionParametres.ValeurParametre("BASESQL", "agrifact"))
        Dim User As String = "sa"
        Dim Pwd As String = CStr(FrGestionParametres.ValeurParametre("saPwd", "ludo"))
        Return String.Format(CONNECTION_STRING, ServeurSQL, BaseSQL, User, Pwd)
    End Function

#Region "Gestion User"
    Private Sub CreerUser()
        Dim FrU As New FrUtilisateur(cn)
        FrU.Owner = Me
        FrU.Show()
    End Sub

    Private Sub ProprieteUser()
        Dim FrU As New FrUtilisateur(cn, CType(Lst.SelectedItems(0).Tag, Utilisateur))
        FrU.Owner = Me
        FrU.Show()
    End Sub

    Private Sub RefreshLstUser()
        Me.Lst.Items.Clear()

        With Lst.Columns
            .Clear()
            .Add("Login", 150, HorizontalAlignment.Left)
            .Add("Departement", 150, HorizontalAlignment.Left)
            .Add("Groupe", 150, HorizontalAlignment.Left)
        End With

        For Each rw As DataRow In Utilisateur.Select(cn).Rows
            If Not rw.Item("Utilisateur") Is DBNull.Value Then
                Dim User As New Utilisateur(rw)
                Dim it As New ListViewItem(CStr(rw.Item("Utilisateur")), 0)
                Me.Lst.Items.Add(it)
                With it
                    .Tag = User
                    .SubItems.Add(User.Departement)
                    .SubItems.Add(User.nGroupe)
                End With                
            End If
        Next
    End Sub

#End Region

#Region "Gestion Roles"
    Private Sub CreerRole()
        Dim FrR As New FrRole(cn)
        FrR.Owner = Me
        FrR.Show()
    End Sub

    Private Sub ProprieteRole()
        Dim FrR As New FrRole(cn, CType(Lst.SelectedItems(0).Tag, Role))
        FrR.Owner = Me
        FrR.Show()
    End Sub

    Private Sub RefreshLstGroupe()

        Me.Lst.Items.Clear()

        With Lst.Columns
            .Clear()
            .Add("nGroupe", 150, HorizontalAlignment.Left)
            .Add("Groupe", 150, HorizontalAlignment.Left)
        End With


        For Each rw As DataRow In Role.Select(cn).Rows
            If Not IsDBNull(rw.Item("nGroupeAutorisation")) Then
                Dim Role As New Role(rw)
                Dim it As New ListViewItem(Role.nGroupe, 0)
                it.Tag = Role
                Me.Lst.Items.Add(it)
                it.SubItems.Add(Role.Groupe)
            End If
        Next
    End Sub
#End Region

#Region "Gestion Champs"
    Private Sub CreerChamps()
        Dim FrC As FrChamps
        Select Case XPEnCours
            Case MenuEnCours.Organisme
                FrC = New FrChamps(cn, "Entreprise")
            Case MenuEnCours.Contact
                FrC = New FrChamps(cn, "Personne")
            Case MenuEnCours.Evenement
                FrC = New FrChamps(cn, "Evenement")
            Case MenuEnCours.Produit
                FrC = New FrChamps(cn, "Produit")
            Case Else
                FrC = New FrChamps(cn)
        End Select
        FrC.Owner = Me
        FrC.Show()
    End Sub

    Private Sub Proprietechamps()
        Dim FrC As New FrChamps(cn, CType(Lst.SelectedItems(0).Tag, ParamNiveau2))
        FrC.Owner = Me
        FrC.Show()
    End Sub

    Private Sub Monter()
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim strMonte As String = ""
            For Each it As ListViewItem In Me.Lst.SelectedItems
                strMonte &= it.Text & ";"
                CType(it.Tag, ParamNiveau2).Monter(cn)
            Next

            Me.RefreshLst()

            For Each it As ListViewItem In Me.Lst.Items
                If strMonte.IndexOf(it.Text & ";") >= 0 Then
                    it.Selected = True
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Descendre()
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim strMonte As String = ""
            For Each it As ListViewItem In Me.Lst.SelectedItems
                strMonte &= it.Text & ";"
                CType(it.Tag, ParamNiveau2).Descendre(cn)
            Next

            Me.RefreshLst()

            For Each it As ListViewItem In Me.Lst.Items
                If strMonte.IndexOf(it.Text & ";") >= 0 Then
                    it.Selected = True
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RefreshLstChamps()
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Lst.Items.Clear()

            With Lst.Columns
                .Clear()
                .Add("Champs", 150, HorizontalAlignment.Left)
                .Add("Libelle", 150, HorizontalAlignment.Left)
                .Add("Liste Choix", 150, HorizontalAlignment.Left)
                .Add("Visible", 50, HorizontalAlignment.Center)
                .Add("Form Recherche", 50, HorizontalAlignment.Center)
                .Add("Rslt Recherche", 50, HorizontalAlignment.Center)
            End With


            Dim dt As DataTable = ParamNiveau2.Select(XPEnCours, cn)

            For Each rw As DataRow In dt.Rows
                If Not rw.Item("nNiveau2") Is DBNull.Value Then
                    Dim Param As New ParamNiveau2(rw)
                    Dim it As New ListViewItem(Param.Champs, 0)
                    Me.Lst.Items.Add(it)
                    With it
                        .Tag = Param
                        With .SubItems
                            .Add(Param.Libelle)
                            .Add(Param.ListeChoix)
                            .Add(Param.Visible)
                            .Add(Param.FormulaireRecherche)
                            .Add(Param.ResultatRecherche)
                        End With
                    End With
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
#End Region

#Region "Gestion ListView"
    Private Sub Lst_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles Lst.ItemDrag
        Me.Text = "Item Drag"
    End Sub

    Private Sub Lst_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Lst.DragDrop
        If TypeOf e.Data Is ListViewItem Then
            MsgBox(CType(e.Data, ListViewItem).Text)
        End If
    End Sub

    Private Sub Lst_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lst.DoubleClick
        MenuItemProprietes.PerformClick()
    End Sub
#End Region

#Region "UltraVNC"
    Public Sub LancerUltraVNC()
        Dim cheminVNC As String = CStr(FrGestionParametres.ValeurParametre("CheminVNC", Application.StartupPath & "\UltraVNC"))
        Dim AdresseVNC As String = CStr(FrGestionParametres.ValeurParametre("AdresseVNC", "193.251.24.103:5500"))
        Dim AdresseVNCID As String = CStr(FrGestionParametres.ValeurParametre("AdresseVNCID", "1"))

        Dim vncExistant() As Process = Process.GetProcessesByName("winvnc")
        If vncExistant.Length > 0 Then
            Dim pr As New Process
            Dim prI As New ProcessStartInfo(cheminVNC & "\WinVNC.exe")
            prI.Arguments = " -kill"
            pr = Process.Start(prI)
            pr.WaitForExit()
            MessageBox.Show("La téléintervention est terminée")
        Else
            Dim pr As New Process
            Dim prI As New ProcessStartInfo(cheminVNC & "\WinVNC.exe")
            prI.Arguments = " -kill"
            pr = Process.Start(prI)
            pr.WaitForExit()
            prI.Arguments = " -run"
            pr = Process.Start(prI)
            pr.WaitForExit(2000)
            prI.Arguments = " -autoreconnect ID:" & AdresseVNCID & " -connect " & AdresseVNC
            pr = Process.Start(prI)
            pr.WaitForExit()
            MessageBox.Show("La téléintervention peut commencer")
        End If
    End Sub
#End Region

End Class
