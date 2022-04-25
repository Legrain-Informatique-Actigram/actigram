Public Class FrChoixValeurForfaitaire

    Private _Bareme_Forfaitaire_AffichageDR As DataSetBaremes.BAREME_FORFAITAIRE_AFFICHAGERow
    Private _CodeDossier As String
    Private _Annee As String

#Region "Propriétés"
    Public Property Bareme_Forfaitaire_AffichageDR() As DataSetBaremes.BAREME_FORFAITAIRE_AFFICHAGERow
        Get
            Return Me._Bareme_Forfaitaire_AffichageDR
        End Get
        Set(ByVal value As DataSetBaremes.BAREME_FORFAITAIRE_AFFICHAGERow)
            Me._Bareme_Forfaitaire_AffichageDR = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal codeDossier As String, ByVal annee As String)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._CodeDossier = codeDossier
        Me._Annee = annee
    End Sub
#End Region

#Region "Form"
    Private Sub FrChoixValeurForfaitaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ConstruireTitre()

        Me.ProgressBar1.Visible = False
    End Sub

    Private Sub FrChoixValeurForfaitaire_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.ChargerDonnees()
    End Sub
#End Region

#Region "BAREME_FORFAITAIRE_AFFICHAGEDataGridView"
    Private Sub BAREME_FORFAITAIRE_AFFICHAGEDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAREME_FORFAITAIRE_AFFICHAGEDataGridView.DoubleClick
        If (CType(sender, DataGridView).SelectedRows.Count > 0) Then
            If CType(sender, DataGridView).SelectedRows(0).DataBoundItem Is Nothing Then Exit Sub

            If Not TypeOf CType(sender, DataGridView).SelectedRows(0).DataBoundItem Is DataRowView Then Exit Sub

            Me._Bareme_Forfaitaire_AffichageDR = DirectCast(DirectCast(CType(sender, DataGridView).SelectedRows(0).DataBoundItem, DataRowView).Row, DataSetBaremes.BAREME_FORFAITAIRE_AFFICHAGERow)

            Me.Close()
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConstruireTitre()
        Me.Text = "Choix d'une valeur forfaitaire"
    End Sub

    Private Sub ChargerDonnees()
        Dim i As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ProgressBar1.Visible = True

            Me.Enabled = False

            Me.ReportProgress(0)

            Me.BAREME_FORFAITAIRE_AFFICHAGETableAdapter.FillByANNEE_BAREME_FORFAITAIRE(Me.DataSetBaremes.BAREME_FORFAITAIRE_AFFICHAGE, Me._Annee)

            Me.BAREME_FORFAITAIRE_AFFICHAGEBindingSource.Sort = "LIBELLE_FACON_CULTURALE ASC"

            Me.ReportProgress(100)
        Finally
            Me.Cursor = Cursors.Default

            Me.ProgressBar1.Visible = False

            Me.Enabled = True
        End Try
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer)
        Me.ProgressBar1.Value = percent
        Application.DoEvents()
    End Sub
#End Region

End Class