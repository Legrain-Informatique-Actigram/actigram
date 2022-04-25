Public Class FrChoixValeurAvAuxCult

    Private _InvGroupes As Inventaire.ClassesMetier.InventaireGroupes
    Private _TypeInventaireALister As Inventaire.ClassesMetier.TypeInventaire
    Private _InvGroupesChoisi As Inventaire.ClassesMetier.InventaireGroupes

#Region "Propriétés"
    Public Property InvGroupesChoisi() As Inventaire.ClassesMetier.InventaireGroupes
        Get
            Return Me._InvGroupesChoisi
        End Get
        Set(ByVal value As Inventaire.ClassesMetier.InventaireGroupes)
            Me._InvGroupesChoisi = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes, ByVal typeInvALister As Inventaire.ClassesMetier.TypeInventaire)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._InvGroupes = invGroupes
        Me._TypeInventaireALister = typeInvALister
    End Sub
#End Region

#Region "Form"
    Private Sub FrChoixValeurAvAuxCult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ConstruireTitre()

        Me.ProgressBar1.Visible = False
    End Sub

    Private Sub FrChoixValeurAvAuxCult_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.ChargerDonnees()
    End Sub
#End Region

#Region "DataGridViewInventaireGroupe"
    Private Sub DataGridViewInventaireGroupe_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewInventaireGroupe.DoubleClick
        If (CType(sender, DataGridView).SelectedRows.Count > 0) Then
            Dim listeInvGrp As Inventaire.ClassesMetier.ListeInventairesGroupes = Me.GetSelectedRows()

            If (listeInvGrp.Count > 0) Then
                Me._InvGroupesChoisi = listeInvGrp(0)

                Me.Close()
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Dim i As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ProgressBar1.Visible = True

            Me.Enabled = False

            Me.ReportProgress(0)

            Me.ChargerGroupes()

            Me.ReportProgress(100)
        Finally
            Me.Cursor = Cursors.Default

            Me.ProgressBar1.Visible = False

            Me.Enabled = True
        End Try
    End Sub

    Private Sub ConstruireTitre()
        Me.Text = "Choix valeur - " & Me._TypeInventaireALister.LibelleTypeInventaire
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer)
        Me.ProgressBar1.Value = percent
        Application.DoEvents()
    End Sub

    Private Sub ChargerGroupes()
        Dim listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes = Nothing
        Dim gestInvGpes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)

        listeInvGpes = gestInvGpes.GetListeInventairesGroupes(Me._InvGroupes.INVGDossier, Me._TypeInventaireALister.CodeTypeInventaire)

        'Trier la liste par N° de compte et par libellé 
        Inventaire.ClassesMetier.ListeInventairesGroupes.Trier(listeInvGpes, "INVGCpt,INVGLib", SortOrder.Ascending)

        Me.InventaireGroupeBindingSource.DataSource = listeInvGpes

        Me.InventaireGroupeBindingSource.ResetBindings(True)
    End Sub

    Private Function GetSelectedRows() As Inventaire.ClassesMetier.ListeInventairesGroupes
        Dim listeInvGrp As New Inventaire.ClassesMetier.ListeInventairesGroupes

        For Each row As DataGridViewRow In Me.DataGridViewInventaireGroupe.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is Inventaire.ClassesMetier.InventaireGroupes Then Continue For

            Dim invGrp As Inventaire.ClassesMetier.InventaireGroupes = DirectCast(row.DataBoundItem, Inventaire.ClassesMetier.InventaireGroupes)

            listeInvGrp.Add(invGrp)
        Next

        Return listeInvGrp
    End Function
#End Region

End Class