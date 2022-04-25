Public Class FrChoixMateriel

    Private _Bareme_AffichageDR As DataSetBaremes.BAREME_AFFICHAGERow
    Private _Type_Materiel As Baremes.ClassesMetier.Type_Materiel
    Private _CodeDossier As String
    Private _Annee As String

#Region "Propriétés"
    Public Property Bareme_AffichageDR() As DataSetBaremes.BAREME_AFFICHAGERow
        Get
            Return Me._Bareme_AffichageDR
        End Get
        Set(ByVal value As DataSetBaremes.BAREME_AFFICHAGERow)
            Me._Bareme_AffichageDR = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal type_Materiel As Baremes.ClassesMetier.Type_Materiel, ByVal codeDossier As String, ByVal annee As String)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._Type_Materiel = type_Materiel
        Me._CodeDossier = codeDossier
        Me._Annee = annee
    End Sub
#End Region

#Region "Form"
    Private Sub FrChoixMateriel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ConstruireTitre()

        Me.ProgressBar1.Visible = False
    End Sub

    Private Sub FrChoixMateriel_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.ChargerDonnees()
    End Sub
#End Region

#Region "BAREME_AFFICHAGEDataGridView"
    Private Sub BAREME_AFFICHAGEDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAREME_AFFICHAGEDataGridView.DoubleClick
        If (CType(sender, DataGridView).SelectedRows.Count > 0) Then
            If CType(sender, DataGridView).SelectedRows(0).DataBoundItem Is Nothing Then Exit Sub

            If Not TypeOf CType(sender, DataGridView).SelectedRows(0).DataBoundItem Is DataRowView Then Exit Sub

            Me._Bareme_AffichageDR = DirectCast(DirectCast(CType(sender, DataGridView).SelectedRows(0).DataBoundItem, DataRowView).Row, DataSetBaremes.BAREME_AFFICHAGERow)

            Me.Close()
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

            Me.BAREME_AFFICHAGETableAdapter.FillByANNEE_BAREMEEtCODE_TYPE_MATERIEL(Me.DataSetBaremes.BAREME_AFFICHAGE, Me._Annee, Me._Type_Materiel.CODE_TYPE_MATERIEL)

            Me.Filtrer()

            'Renseigne le libelle matériel interne
            Dim listeBaremeAffichageDR() As DataSetBaremes.BAREME_AFFICHAGERow = CType(Me.DataSetBaremes.BAREME_AFFICHAGE.Select(Me.ConstruireFiltre(), "LibelleMateriel"), AgrigestEDI.DataSetBaremes.BAREME_AFFICHAGERow())

            If Not (listeBaremeAffichageDR Is Nothing) Then
                Using inventaireMaterielTA As New DataSetAgrigestTableAdapters.InventaireMaterielTableAdapter
                    For Each bareme_AffichageDR As DataSetBaremes.BAREME_AFFICHAGERow In listeBaremeAffichageDR
                        Dim inventaireMaterielDT As DataSetAgrigest.InventaireMaterielDataTable = inventaireMaterielTA.GetDataByID_MATERIEL(bareme_AffichageDR.ID_MATERIEL)

                        If (inventaireMaterielDT.Rows.Count > 0) Then
                            Dim inventaireMaterielDR As DataSetAgrigest.InventaireMaterielRow = CType(inventaireMaterielDT.Rows(0), DataSetAgrigest.InventaireMaterielRow)

                            If Not (inventaireMaterielDR.IsLibelleMaterielNull) Then
                                bareme_AffichageDR.LibelleMateriel = inventaireMaterielDR.LibelleMateriel
                            End If
                        End If

                        i += 1 : Me.ReportProgress(i * 100 \ listeBaremeAffichageDR.Length)
                    Next
                End Using
            End If

            Me.BAREME_AFFICHAGEBindingSource.Sort = "LibelleMateriel"

            Me.ReportProgress(100)
        Finally
            Me.Cursor = Cursors.Default

            Me.ProgressBar1.Visible = False

            Me.Enabled = True
        End Try
    End Sub

    Private Sub ConstruireTitre()
        Me.Text = "Choix du matériel - " & Me._Type_Materiel.LIBELLE_TYPE_MATERIEL
    End Sub

    Private Function ConstruireFiltre() As String
        Dim listeCriteres As New List(Of String)
        Dim filtreID_MATERIEL As String = String.Empty
        Dim filtre As String = String.Empty
        Dim i As Integer = 1

        'Filtrage par type de matériel
        listeCriteres.Add(String.Format("(CODE_TYPE_MATERIEL = '{0}')", Me._Type_Materiel.CODE_TYPE_MATERIEL))

        'Filtrage par ID_MATERIEL
        Dim gestInvMat As New Inventaire.ClassesControleur.GestionnaireInventaireMateriel(My.Settings.dbDonneesConnectionString)
        Dim listeInvMat As Inventaire.ClassesMetier.ListeInventairesMateriel = gestInvMat.GetListeInventairesMateriel(Me._CodeDossier)

        For Each invMat As Inventaire.ClassesMetier.InventaireMateriel In listeInvMat
            If (invMat.ID_MATERIEL.HasValue) Then
                filtreID_MATERIEL = filtreID_MATERIEL & invMat.ID_MATERIEL.ToString() & ","
            End If
        Next

        If Not (String.IsNullOrEmpty(filtreID_MATERIEL)) Then
            filtreID_MATERIEL = Microsoft.VisualBasic.Left(filtreID_MATERIEL, filtreID_MATERIEL.Length - 1)

            listeCriteres.Add(String.Format("(ID_MATERIEL IN ({0}))", filtreID_MATERIEL))
        Else
            listeCriteres.Add(String.Format("(ID_MATERIEL IN ({0}))", "-1"))
        End If

        For Each s As String In listeCriteres
            If (i = listeCriteres.Count) Then
                filtre = filtre & s
            Else
                filtre = filtre & s & " AND "
            End If

            i = i + 1
        Next

        Return filtre
    End Function

    Private Sub Filtrer()
        Me.BAREME_AFFICHAGEBindingSource.Filter = Me.ConstruireFiltre
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer)
        Me.ProgressBar1.Value = percent
        Application.DoEvents()
    End Sub
#End Region

End Class