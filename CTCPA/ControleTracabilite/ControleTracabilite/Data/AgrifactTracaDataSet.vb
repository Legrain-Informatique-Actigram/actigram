Partial Class AgrifactTracaDataSet

    Partial Class MouvementDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.MouvementTableAdapter)
            Me.nMouvementColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class Mouvement_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter)
            Me.nMouvementDetailColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub

        Public Sub MatPremFromSign()
            For Each dr As Mouvement_DetailRow In Me.Rows
                If (Not dr.IsUnite1Null AndAlso dr.Unite1 < 0) _
                OrElse ((dr.IsUnite1Null OrElse dr.Unite1 = 0) AndAlso (Not dr.IsUnite2Null AndAlso dr.Unite2 < 0)) Then
                    dr.MatPrem = True
                    If Not dr.IsUnite1Null Then dr.Unite1 = Math.Abs(dr.Unite1)
                    If Not dr.IsUnite2Null Then dr.Unite2 = Math.Abs(dr.Unite2)
                End If
            Next
            Me.AcceptChanges()
        End Sub


        Public Sub SignFromMatPrem()
            For Each dr As Mouvement_DetailRow In Me.Rows
                If Not dr.RowState = DataRowState.Deleted Then
                    If dr.MatPrem Then
                        If Not dr.IsUnite1Null Then dr.Unite1 = -dr.Unite1
                        If Not dr.IsUnite2Null Then dr.Unite2 = -dr.Unite2
                    End If
                End If
            Next
        End Sub

        Private Sub Mouvement_DetailDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.MatPremColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class ProduitDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter)
            Me.nProduitColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class EntrepriseDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter)
            Me.nEntrepriseColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class ABonReception_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter)
            Me.nDetailDevisColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class ABonReceptionDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter)
            Me.nDevisColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class FamilleDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.FamilleTableAdapter)
            Me.nFamilleColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class CompositionProduitDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New AgrifactTracaDataSetTableAdapters.CompositionProduitTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As AgrifactTracaDataSetTableAdapters.CompositionProduitTableAdapter)
            Me.nCompositionProduitColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

End Class

Namespace AgrifactTracaDataSetTableAdapters
    Partial Class ListeChoixTableAdapter
        Public Enum NomsChoix
            FormeJuridique
            ListeBanque
            ListeDepots
            ListeModeReglement
            ListeTypeFacturation
            ListeTypeMouvement
            ListeUnite
        End Enum

        Public Overloads Sub FillByNomChoix(ByVal dt As AgrifactTracaDataSet.ListeChoixDataTable, ByVal nomChoix As NomsChoix)
            FillByNomChoix(dt, nomChoix.ToString)
        End Sub

        Public Overloads Function GetDataByNomChoix(ByVal nomChoix As NomsChoix) As AgrifactTracaDataSet.ListeChoixDataTable
            Return GetDataByNomChoix(nomChoix.ToString)
        End Function
    End Class

    Partial Class ProduitTableAdapter
        Public Enum FiltreProduits
            Tous
            MatieresPremieres
            ProduitsFinis
        End Enum

        Public Overloads Sub Fill(ByVal dt As AgrifactTracaDataSet.ProduitDataTable, ByVal filtre As FiltreProduits, Optional ByVal InclureInactifs As Boolean = False)
            Select Case filtre
                Case FiltreProduits.Tous
                    FillByInactif(dt, InclureInactifs)
                Case FiltreProduits.MatieresPremieres
                    FillMP(dt, InclureInactifs)
                Case FiltreProduits.ProduitsFinis
                    FillPF(dt, InclureInactifs)
            End Select
        End Sub

        Public Function GetNewCodeBarre() As String
            Dim cb As String = Me.GetMaxCodeBarre
            If IsDBNull(cb) OrElse cb Is Nothing Then cb = "0"
            Dim i As Long
            If Long.TryParse(cb, i) Then
                cb = CStr(i + 1).PadLeft(4, "0"c)
            End If
            Return cb
        End Function

        Public Sub UpdateCodeProduit(ByVal oldCode As String, ByVal newCode As String)
            Dim cmd As New SqlClient.SqlCommand("", Me.Connection)
            Dim tables() As String = {"CompositionProduit", "ABonReception_Detail", "AFacture_Detail", "DefinitionControle", _
                                    "DefinitionControle", "Mouvement_Detail", "Tarif_Detail", "Tarif_Detail", _
                                    "VBonCommande_Detail", "VBonLivraison_Detail", "VDevis_Detail", "VFacture_Detail"}
            If Me.Connection.State = ConnectionState.Closed Then Me.Connection.Open()
            cmd.CommandText = "BEGIN TRANSACTION" : cmd.ExecuteNonQuery()
            Try
                For Each table As String In tables
                    cmd.CommandText = String.Format("UPDATE [{0}] SET CodeProduit='{2}' WHERE CodeProduit='{1}'", table, oldCode, newCode)
                    cmd.ExecuteNonQuery()
                Next
                cmd.CommandText = "COMMIT TRANSACTION" : cmd.ExecuteNonQuery()
            Catch ex As Exception
                cmd.CommandText = "ROLLBACK TRANSACTION" : cmd.ExecuteNonQuery()
                Throw ex
            End Try
        End Sub

    End Class

    Partial Class DefinitionControleTableAdapter
        Public Function GetNextId(ByVal codeProduit As String) As Integer
            Dim id As Nullable(Of Integer) = Me.GetMaxId(codeProduit)
            Return id.GetValueOrDefault(0) + 1
        End Function
    End Class

    Partial Class MouvementTableAdapter
        Public Overloads Sub FillByType(ByVal dt As AgrifactTracaDataSet.MouvementDataTable, ByVal type As Stocks.GestionStock.TypeMouvement)
            Me.FillByType(dt, type.ToString)
        End Sub
    End Class
End Namespace
