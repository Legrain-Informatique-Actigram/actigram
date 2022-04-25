Public Class FrAffecterFacturesAReglement

    Private _nEntreprise As Decimal
    Private _nReglement As Decimal
    Private _ListeFacturesDR As List(Of DataRow)
    Private _NomTableDetail As String
    Private _NomTableFacture As String
    Private _TypeRegl As FrListeReglement.TypeReglement

#Region "Constructeurs"
    Public Sub New(ByVal nEntreprise As Decimal, ByVal nReglement As Decimal, ByVal listeFacturesDR As List(Of DataRow), ByVal nomTableDetail As String, ByVal nomTableFacture As String, ByVal typeRegl As FrListeReglement.TypeReglement)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Me._nEntreprise = nEntreprise
        Me._nReglement = nReglement
        Me._ListeFacturesDR = listeFacturesDR
        Me._NomTableDetail = nomTableDetail
        Me._NomTableFacture = nomTableFacture
        Me._TypeRegl = typeRegl
    End Sub
#End Region

#Region "Form"
    Private Sub FrAffecterReglementAFactures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ChargerDonnees()
    End Sub
#End Region

#Region "DataGridViewPieces"
    Private Sub DataGridViewPieces_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewPieces.SelectionChanged
        Me.RecalculerTotalSelection()
    End Sub

    Private Sub DataGridViewPieces_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewPieces.DoubleClick
        Me.CreerReglementDetail()
        Me.Close()
    End Sub
#End Region

#Region "Boutons"
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Me.CreerReglementDetail()
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Dim filtreFactures As String = Me.ConstruireFiltreFactures()

        If Me._TypeRegl = FrListeReglement.TypeReglement.Achat Then
            Me.PiecesTA.FillAFactureByClientByPaye(Me.DsPieces.Pieces, Me._nEntreprise, False)
        Else
            Me.PiecesTA.FillImputationReglementByClient(Me.DsPieces.Pieces, Me._nEntreprise)
            'Me.PiecesTA.FillVFactureByClientByPaye(Me.DsPieces.Pieces, Me._nEntreprise, False)
        End If

        If (filtreFactures <> String.Empty) Then
            Me.PiecesBindingSource.Filter = "nDevis NOT IN (" & filtreFactures & ")"
        End If
    End Sub

    Private Sub RecalculerTotalSelection()
        Dim total As Decimal = 0

        For Each dr As DataRow In SelectedRows()
            total += CDec(dr("Reste"))
        Next

        Me.LabelTotalSelection.Text = total.ToString("C2")
    End Sub

    Private Function SelectedRows() As List(Of DataRow)
        Dim listeDR As New List(Of DataRow)

        For Each r As DataGridViewRow In Me.DataGridViewPieces.SelectedRows
            If r.DataBoundItem IsNot Nothing Then
                listeDR.Add(Cast(Of DataRowView)(r.DataBoundItem).Row)
            End If
        Next

        Return listeDR
    End Function

    Private Sub CreerReglementDetail()
        If (Me.SelectedRows.Count > 0) Then
            Dim ds As New DataSet

            Using s As New SqlProxy
                DefinitionDonnees.Instance.FillSchema(ds, Me._NomTableDetail, s)
                DefinitionDonnees.Instance.FillSchema(ds, Me._NomTableFacture, s)

                Dim detailReglementDT As DataTable = ds.Tables(Me._NomTableDetail)

                For Each dr As DataRow In Me.SelectedRows()
                    'Création du
                    Dim detailReglementDR As DataRow = detailReglementDT.NewRow

                    With detailReglementDR
                        .Item("nReglement") = Me._nReglement
                        .Item("nFacture") = dr("nDevis")
                        .Item("Montant") = dr("reste")
                    End With

                    detailReglementDT.Rows.Add(detailReglementDR)

                    'Mise à jour de l'indicateur Paye dans la table des factures
                    Dim where As String = String.Format("nDevis={0}", dr("nDevis"))

                    DefinitionDonnees.Instance.Fill(ds, Me._NomTableFacture, s, where)

                    Dim factureDR() As DataRow = ds.Tables(Me._NomTableFacture).Select(String.Format("nDevis={0}", dr("nDevis")))

                    For Each factDR As DataRow In factureDR
                        factDR("Paye") = True
                    Next
                Next

                'Mise à jour de la base de données
                Dim strNomTable() As String = {Me._NomTableDetail, Me._NomTableFacture}

                s.UpdateTables(ds, strNomTable)
            End Using
        End If
    End Sub

    Private Function ConstruireFiltreFactures() As String
        Dim filtreFactures As String = String.Empty

        For Each dr As DataRow In Me._ListeFacturesDR
            If Not (dr.IsNull("nDevis")) Then
                filtreFactures = filtreFactures & Convert.ToString(dr("nDevis")) & ","
            End If
        Next

        If (filtreFactures.Length > 0) Then
            filtreFactures = Mid(filtreFactures, 1, filtreFactures.Length - 1)
        End If

        Return filtreFactures
    End Function
#End Region

End Class