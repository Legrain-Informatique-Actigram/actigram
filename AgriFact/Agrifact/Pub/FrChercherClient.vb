Public Class FrChercherClient

    Private _EntrepriseDR As PubDataSet.EntrepriseRow

#Region "Propriétés"
    Public Property EntrepriseDR() As PubDataSet.EntrepriseRow
        Get
            Return Me._EntrepriseDR
        End Get
        Set(ByVal value As PubDataSet.EntrepriseRow)
            Me._EntrepriseDR = value
        End Set
    End Property
#End Region

#Region "Button"
    Private Sub ChercherButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChercherButton.Click
        Me.LoadData()
    End Sub
#End Region

#Region "EntrepriseDataGridView"
    Private Sub EntrepriseDataGridView_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles EntrepriseDataGridView.CellMouseDoubleClick
        Dim listeEntrepriseDR As List(Of PubDataSet.EntrepriseRow) = Me.GetSelectedRows()

        If (listeEntrepriseDR.Count > 0) Then
            Dim EntrepriseDR As PubDataSet.EntrepriseRow = listeEntrepriseDR(0)

            Me.EntrepriseDR = EntrepriseDR
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        Dim nom As String = String.Empty

        If (Me.NomTextBox.Text.Length > 0) Then
            nom = Me.NomTextBox.Text.Trim

            Me.EntrepriseTableAdapter.FillByNomClient(Me.PubDataSet.Entreprise, String.Format("%{0}%", Replace(nom, "'", "''")))
        End If
    End Sub

    Private Function GetSelectedRows() As List(Of PubDataSet.EntrepriseRow)
        Dim listeEntrepriseDR As New List(Of PubDataSet.EntrepriseRow)

        For Each row As DataGridViewRow In Me.EntrepriseDataGridView.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

            Dim EntrepriseDR As PubDataSet.EntrepriseRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, PubDataSet.EntrepriseRow)

            listeEntrepriseDR.Add(EntrepriseDR)
        Next

        Return listeEntrepriseDR
    End Function
#End Region

End Class