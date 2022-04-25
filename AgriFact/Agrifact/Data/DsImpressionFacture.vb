


Partial Public Class DsImpressionFacture
    Partial Class EntrepriseDataTable

        Private Sub EntrepriseDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.SirenColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class Entreprise1DataTable

    End Class

    Class ProduitDataTable

    End Class

End Class
