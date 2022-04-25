Public Class FrListeTarif

    Inherits GRC.FrBase
    Dim dv As DataView
    Dim _BmpSelect As Bitmap
    Private WithEvents FrA As FrAssistantTarif
    Private WithEvents FrLstProduit As FrListeProduits

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    Public Sub New(ByRef monDataset As DataSet)
        Me.New()
        ds = monDataset
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
    Friend WithEvents Grille1 As Actigram.Windows.Forms.Grilles.Grille
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TbFermer As System.Windows.Forms.ToolBarButton
    Friend WithEvents LbLabel1 As Actigram.Windows.Forms.Grilles.LbLabel
    Friend WithEvents LbLabel2 As Actigram.Windows.Forms.Grilles.LbLabel
    Friend WithEvents LbLabel3 As Actigram.Windows.Forms.Grilles.LbLabel
    Friend WithEvents NavigationDataBindings1 As GRC.NavigationDataBindings
    Friend WithEvents BtSelect As Actigram.Windows.Forms.Grilles.BtButton
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolBarButton
    Friend WithEvents LbLibelle As Actigram.Windows.Forms.Grilles.LbLabel
    Friend WithEvents PanelColor1 As Actigram.Windows.Forms.Grilles.PanelColorTri
    Friend WithEvents LabelColor1 As Actigram.Windows.Forms.Grilles.LabelColorTri
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TbSaisieTarif As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrListeTarif))
        Me.Grille1 = New Actigram.Windows.Forms.Grilles.Grille
        Me.BtSelect = New Actigram.Windows.Forms.Grilles.BtButton(1, 0, 20, 20, "", True)
        Me.LbLibelle = New Actigram.Windows.Forms.Grilles.LbLabel(30, 0, 20, 250, "Libelle", "Libelle", True)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TbImprimer = New System.Windows.Forms.ToolBarButton
        Me.TbFermer = New System.Windows.Forms.ToolBarButton
        Me.LbLabel1 = New Actigram.Windows.Forms.Grilles.LbLabel(0, 0, 23, 100, "LbLabel1", "", True)
        Me.LbLabel2 = New Actigram.Windows.Forms.Grilles.LbLabel(0, 0, 23, 100, "LbLabel2", "", True)
        Me.LbLabel3 = New Actigram.Windows.Forms.Grilles.LbLabel(0, 0, 23, 100, "LbLabel3", "", True)
        Me.NavigationDataBindings1 = New GRC.NavigationDataBindings
        Me.PanelColor1 = New Actigram.Windows.Forms.Grilles.PanelColorTri
        Me.LabelColor1 = New Actigram.Windows.Forms.Grilles.LabelColorTri
        Me.Button1 = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TbSaisieTarif = New System.Windows.Forms.ToolBarButton
        Me.PanelColor1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'Grille1
        '
        Me.Grille1.AllowAddNewGroupe = False
        Me.Grille1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grille1.AutoScroll = True
        Me.Grille1.BackColor = System.Drawing.Color.White
        Me.Grille1.ContextMenuGroupe = Nothing
        Me.Grille1.DataSource = Nothing
        Me.Grille1.ErreurColor = System.Drawing.Color.Red
        Me.Grille1.GroupeAlternateBackColor = System.Drawing.Color.White
        Me.Grille1.GroupeBackColor = System.Drawing.Color.Lavender
        Me.Grille1.GroupeBackColorSelected = System.Drawing.Color.Yellow
        Me.Grille1.GroupeHighlightBackColor = System.Drawing.Color.Red
        Me.Grille1.GroupeHighlightForeColor = System.Drawing.Color.Blue
        Me.Grille1.HauteurGroupe = 20.0!
        Me.Grille1.HighlightTest = Nothing
        Me.Grille1.ImageFaux = Nothing
        Me.Grille1.ImageVrai = Nothing
        Me.Grille1.ListeBoutonGroupe.Add(Me.BtSelect)
        Me.Grille1.ListeLabelGroupe.Add(Me.LbLibelle)
        Me.Grille1.Location = New System.Drawing.Point(8, 96)
        Me.Grille1.Name = "Grille1"
        Me.Grille1.SelectedGroupe = -1
        Me.Grille1.SelectImage = CType(resources.GetObject("Grille1.SelectImage"), System.Drawing.Image)
        Me.Grille1.Size = New System.Drawing.Size(400, 336)
        Me.Grille1.TabIndex = 0
        Me.Grille1.TabStop = True
        Me.Grille1.TypeDegrade = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        '
        'BtSelect
        '
        Me.BtSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSelect.Location = New System.Drawing.Point(1, 0)
        Me.BtSelect.Name = "BtSelect"
        Me.BtSelect.Size = New System.Drawing.Size(20, 20)
        Me.BtSelect.TabIndex = 7
        '
        'LbLibelle
        '
        Me.LbLibelle.AfficheSiNull = ""
        Me.LbLibelle.AfficheSiZero = "0"
        Me.LbLibelle.ChampsLie = "Libelle"
        Me.LbLibelle.ControlSortieForm = Nothing
        Me.LbLibelle.FormatNumeric = ""
        Me.LbLibelle.FormatNumeric1 = ""
        Me.LbLibelle.ImageFaux = Nothing
        Me.LbLibelle.ImageVrai = Nothing
        Me.LbLibelle.Location = New System.Drawing.Point(30, 0)
        Me.LbLibelle.Name = "LbLibelle"
        Me.LbLibelle.NomColorColumn = ""
        Me.LbLibelle.Size = New System.Drawing.Size(250, 20)
        Me.LbLibelle.TabIndex = 5
        Me.LbLibelle.Text = "Libelle"
        Me.LbLibelle.TextInfo = ""
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TbSaisieTarif, Me.TbImprimer, Me.TbFermer})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList24
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(416, 50)
        Me.ToolBar1.TabIndex = 1
        '
        'TbImprimer
        '
        Me.TbImprimer.ImageIndex = 3
        Me.TbImprimer.Text = "Imprimer"
        Me.TbImprimer.Visible = False
        '
        'TbFermer
        '
        Me.TbFermer.ImageIndex = 5
        Me.TbFermer.Text = "Fermer"
        Me.TbFermer.ToolTipText = "Fermer le formulaire en cours"
        '
        'LbLabel1
        '
        Me.LbLabel1.AfficheSiNull = ""
        Me.LbLabel1.AfficheSiZero = "0"
        Me.LbLabel1.ChampsLie = ""
        Me.LbLabel1.ControlSortieForm = Nothing
        Me.LbLabel1.FormatNumeric = ""
        Me.LbLabel1.FormatNumeric1 = ""
        Me.LbLabel1.ImageFaux = Nothing
        Me.LbLabel1.ImageVrai = Nothing
        Me.LbLabel1.Location = New System.Drawing.Point(0, 0)
        Me.LbLabel1.Name = "LbLabel1"
        Me.LbLabel1.NomColorColumn = ""
        Me.LbLabel1.TabIndex = 0
        Me.LbLabel1.Text = "LbLabel1"
        Me.LbLabel1.TextInfo = ""
        '
        'LbLabel2
        '
        Me.LbLabel2.AfficheSiNull = ""
        Me.LbLabel2.AfficheSiZero = "0"
        Me.LbLabel2.ChampsLie = ""
        Me.LbLabel2.ControlSortieForm = Nothing
        Me.LbLabel2.FormatNumeric = ""
        Me.LbLabel2.FormatNumeric1 = ""
        Me.LbLabel2.ImageFaux = Nothing
        Me.LbLabel2.ImageVrai = Nothing
        Me.LbLabel2.Location = New System.Drawing.Point(0, 0)
        Me.LbLabel2.Name = "LbLabel2"
        Me.LbLabel2.NomColorColumn = ""
        Me.LbLabel2.TabIndex = 0
        Me.LbLabel2.Text = "LbLabel2"
        Me.LbLabel2.TextInfo = ""
        '
        'LbLabel3
        '
        Me.LbLabel3.AfficheSiNull = ""
        Me.LbLabel3.AfficheSiZero = "0"
        Me.LbLabel3.ChampsLie = ""
        Me.LbLabel3.ControlSortieForm = Nothing
        Me.LbLabel3.FormatNumeric = ""
        Me.LbLabel3.FormatNumeric1 = ""
        Me.LbLabel3.ImageFaux = Nothing
        Me.LbLabel3.ImageVrai = Nothing
        Me.LbLabel3.Location = New System.Drawing.Point(0, 0)
        Me.LbLabel3.Name = "LbLabel3"
        Me.LbLabel3.NomColorColumn = ""
        Me.LbLabel3.TabIndex = 0
        Me.LbLabel3.Text = "LbLabel3"
        Me.LbLabel3.TextInfo = ""
        '
        'NavigationDataBindings1
        '
        Me.NavigationDataBindings1.AfficherRecherche = False
        Me.NavigationDataBindings1.AjouterEnregistrementAddNew = False
        Me.NavigationDataBindings1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavigationDataBindings1.DataSource = Nothing
        Me.NavigationDataBindings1.DepartColor = System.Drawing.Color.LightGreen
        Me.NavigationDataBindings1.FinColor = System.Drawing.Color.DarkGreen
        Me.NavigationDataBindings1.Location = New System.Drawing.Point(32, 440)
        Me.NavigationDataBindings1.MajVisible = False
        Me.NavigationDataBindings1.Name = "NavigationDataBindings1"
        Me.NavigationDataBindings1.OrientationDegrade = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.NavigationDataBindings1.Size = New System.Drawing.Size(352, 32)
        Me.NavigationDataBindings1.StartFilter = Nothing
        Me.NavigationDataBindings1.TabIndex = 3
        Me.NavigationDataBindings1.Table = Nothing
        '
        'PanelColor1
        '
        Me.PanelColor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelColor1.BackColor = System.Drawing.Color.White
        Me.PanelColor1.Controls.Add(Me.LabelColor1)
        Me.PanelColor1.Controls.Add(Me.Button1)
        Me.PanelColor1.CouleurDebut = System.Drawing.Color.White
        Me.PanelColor1.CouleurFin = System.Drawing.Color.LightSteelBlue
        Me.PanelColor1.Grille = Me.Grille1
        Me.PanelColor1.Location = New System.Drawing.Point(8, 56)
        Me.PanelColor1.Name = "PanelColor1"
        Me.PanelColor1.Orientation = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.PanelColor1.Size = New System.Drawing.Size(400, 32)
        Me.PanelColor1.TabIndex = 2
        '
        'LabelColor1
        '
        Me.LabelColor1.BackColor = System.Drawing.SystemColors.Control
        Me.LabelColor1.Champs = "Libelle"
        Me.LabelColor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelColor1.Location = New System.Drawing.Point(48, 8)
        Me.LabelColor1.Name = "LabelColor1"
        Me.LabelColor1.ParentPanelColor = Me.PanelColor1
        Me.LabelColor1.Size = New System.Drawing.Size(56, 23)
        Me.LabelColor1.TabIndex = 4
        Me.LabelColor1.Text = "Tarif"
        Me.LabelColor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelColor1.Tri = System.Windows.Forms.SortOrder.None
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(153, Byte), CType(51, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button1, "Sélectionner / désélectionner tous les enregistrements")
        '
        'TbSaisieTarif
        '
        Me.TbSaisieTarif.ImageIndex = 1
        Me.TbSaisieTarif.Text = "Saisir les prix"
        '
        'FrListeTarif
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 478)
        Me.Controls.Add(Me.NavigationDataBindings1)
        Me.Controls.Add(Me.PanelColor1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Grille1)
        Me.Name = "FrListeTarif"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste Tarifs"
        Me.PanelColor1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrListeClient_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dv = New DataView(ds.Tables("Tarif"), "nTarif<>0", "nTarif", DataViewRowState.CurrentRows)
        Me.NavigationDataBindings1.SetDataSource(dv)
        Me.Grille1.DataSource = dv
        Me.Grille1.Refresh()
        Me.Grille1.SelectedGroupe = -1
    End Sub

    Private Sub Grille1_SelectedGroupeClick(ByVal Groupe As System.Data.DataRowView) Handles Grille1.SelectedGroupeClick
        With New FrSaisieTarifs(ds)
            .ColTarifVisible = False
            .nTarif = CInt(Groupe.Item("nTarif"))
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub BtSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelect.Click
        Me.Grille1.SelectGroupeEnCours()
        If Me.Grille1.GroupeEnCoursIsSelected = True Then
            'Me.BtSelect.BackColor = Color.Red
            If _BmpSelect Is Nothing Then
                _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
                _BmpSelect.MakeTransparent(Color.White)
                Me.BtSelect.ImageAlign = ContentAlignment.MiddleLeft
            End If
            Me.BtSelect.Image = _BmpSelect
        Else
            Me.BtSelect.BackColor = Me.Grille1.GroupeBackColorSelected
            Me.BtSelect.Image = Nothing
        End If
    End Sub

    Private Sub Grille1_EntreGroupe(ByVal Groupe As System.Data.DataRowView) Handles Grille1.EntreGroupe
        If Me.Grille1.SelectedRows.Contains(Groupe) = True Then
            If _BmpSelect Is Nothing Then
                _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
                _BmpSelect.MakeTransparent(Color.White)
                Me.BtSelect.ImageAlign = ContentAlignment.MiddleLeft
            End If
            Me.BtSelect.Image = _BmpSelect
        Else
            Me.BtSelect.BackColor = Me.Grille1.GroupeBackColorSelected
            Me.BtSelect.Image = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.Grille1.SelectedRows.Count = 0 Then
            Dim rw As DataRowView
            For Each rw In Me.dv
                Me.Grille1.SelectedRows.Add(rw)
            Next
        Else
            Me.Grille1.SelectedRows.Clear()
        End If
        Me.Grille1.Refresh()
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button Is Me.TbFermer Then
            Me.Close()
        ElseIf e.Button Is Me.TbSaisieTarif Then
            Dim fr As New FrSaisieTarifs(ds)
            If Me.Grille1.SelectedGroupe >= 0 Then
                fr.nTarif = CInt(dv(Me.Grille1.SelectedGroupe)("nTarif"))
                fr.ColTarifVisible = False
            End If
            fr.ShowDialog(Me)
        End If
    End Sub

    Private Sub NavigationDataBindings1_DataMove(ByVal strTable As String, ByVal intPosition As Integer) Handles NavigationDataBindings1.DataMove
        Me.Grille1.SelectedGroupe = Me.BindingContext(dv).Position
    End Sub

    Private Sub NavigationDataBindings1_AddNew() Handles NavigationDataBindings1.AddNew
        'If Me.BindingContext(dv).Position <> -1 Then
        '    FrE = New FrFamille(ds, CType(Me.BindingContext(dv).Current, DataRowView).Item("nFamille"))

        '    'FrE = New FrFamille(ds, "")
        '    FrE.Owner = Me
        '    FrE.FiltreType = Me.FiltreType
        '    FrE.Show()
        'End If
        Me.Grille1.SelectedGroupe = -1
        FrA = New FrAssistantTarif(ds)
        FrA.Owner = Me
        FrA.Show()
    End Sub

    Private Sub FrE_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrA.Closed
        If Me.Grille1.SelectedGroupe <> -1 Then
            Me.Grille1.SelectedGroupe = Me.Grille1.SelectedGroupe
        End If
        dv = New DataView(ds.Tables("Tarif"), "nTarif<>0", "nTarif", DataViewRowState.CurrentRows)
        Me.Grille1.DataSource = dv
        Me.Grille1.ActualiserTop()
        Me.Grille1.Refresh()
    End Sub

    Private Sub NavigationDataBindings1_RemoveAt(ByVal intPosition As Integer) Handles NavigationDataBindings1.RemoveAt
        FrDonnees.ConfigSqlServer.UpdateAdapters(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Delete)
    End Sub

    Private Sub NavigationDataBindings1_BeforeAddNew(ByVal e As System.ComponentModel.CancelEventArgs) Handles NavigationDataBindings1.BeforeAddNew
        Me.dv.RowFilter = ""
        Me.dv.Sort = ""
    End Sub

    Private Sub NavigationDataBindings1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationDataBindings1.Load

    End Sub
End Class
