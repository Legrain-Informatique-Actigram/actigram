Imports System.Data.SqlClient

Public Class FrRemplacerCodeProduitPiece

    Private _ListeNDevis As List(Of String)
    Private _TypePiece As Pieces.TypePieces

#Region "Constructeurs"
    Public Sub New(ByVal listeNDevis As List(Of String), ByVal typePiece As Pieces.TypePieces)
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._ListeNDevis = listeNDevis
        Me._TypePiece = typePiece
    End Sub
#End Region

#Region "Form"
    Private Sub FrModifierCodeProduitPiece_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadData()
    End Sub
#End Region

#Region "Button"
    Private Sub ValiderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValiderButton.Click
        If (Me._ListeNDevis.Count > 0) Then
            Me.RemplacerCodeProduit(String.Join(",", Me._ListeNDevis.ToArray))
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        'Chargement de la liste des produits pouvant être remplacer
        If (Me._ListeNDevis.Count > 0) Then
            Me.ProduitARemplacerBindingSource.DataSource = Me.GetProduitARemplacerDT(String.Join(",", Me._ListeNDevis.ToArray()))
        End If

        'Chargement de la liste des produits de remplacement
        Me.ProduitTableAdapter.Fill(Me.DsPieces.Produit)
    End Sub

    Private Function GetProduitARemplacerDT(ByVal listeNDevis As String) As DataTable
        Dim sqlQuery As String = String.Empty
        Dim ds As New DataSet
        Dim tablePiece_Detail As String = Me._TypePiece.ToString() & "_Detail"

        If (listeNDevis.Length > 0) Then
            Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                sqlConn.Open()

                sqlQuery = String.Format("SELECT Produit.CodeProduit, Produit.CodeProduit + CASE WHEN Produit.Libelle IS NULL " & _
                        "THEN '' ELSE ' - ' + CAST(Produit.Libelle AS NVARCHAR(2000)) END AS CodeProduit_Libelle " & _
                        "FROM {0} INNER JOIN Produit ON {0}.CodeProduit = Produit.CodeProduit " & _
                        "WHERE ({0}.nDevis IN ({1})) " & _
                        "GROUP BY Produit.CodeProduit, Produit.CodeProduit + CASE WHEN Produit.Libelle IS NULL " & _
                        "THEN '' ELSE ' - ' + CAST(Produit.Libelle AS NVARCHAR(2000)) END " & _
                        "ORDER BY Produit.CodeProduit", tablePiece_Detail, listeNDevis)

                Using sqlComm As New SqlCommand(sqlQuery, sqlConn)
                    Dim sqlDA As New SqlDataAdapter(sqlComm)

                    sqlDA.Fill(ds, "ProduitARemplacer")
                End Using
            End Using
        Else
            Return Nothing
        End If

        Return ds.Tables("ProduitARemplacer")
    End Function

    Private Sub RemplacerCodeProduit(ByVal listeNDevis As String)
        Dim sqlQuery As String = String.Empty
        Dim tablePiece_Detail As String = Me._TypePiece.ToString() & "_Detail"

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            sqlConn.Open()

            sqlQuery = String.Format("UPDATE {0} SET CodeProduit='{1}' " & _
                    "WHERE (CodeProduit='{2}') AND " & _
                    "({0}.nDevis IN ({3}))", tablePiece_Detail, _
                    Replace(Me.ProduitDeRemplacementComboBox.SelectedValue.ToString(), "'", "''"), _
                    Replace(Me.ProduitARemplacerComboBox.SelectedValue.ToString(), "'", "''"), _
                    listeNDevis)

            Using sqlComm As New SqlCommand(sqlQuery, sqlConn)
                sqlComm.ExecuteNonQuery()
            End Using
        End Using
    End Sub
#End Region

End Class