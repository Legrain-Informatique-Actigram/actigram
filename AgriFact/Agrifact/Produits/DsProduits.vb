Namespace DsProduitsTableAdapters
    Partial Class SaisieTarifsTA
        Public Overloads Function UpdatePrixStandard(ByVal dt As DsProduits.SaisieTarifsDataTable) As Integer
            Return ForceDataAdapter.ExecCommand(Me.CommandCollection(4), dt, Me.Adapter.ContinueUpdateOnError)
        End Function

        Public Overloads Function UpdateTarifs(ByVal dt As DsProduits.SaisieTarifsDataTable) As Integer
            Return ForceDataAdapter.ExecCommand(Me.CommandCollection(5), dt, Me.Adapter.ContinueUpdateOnError)
        End Function
    End Class
End Namespace

Partial Public Class DsProduits
    Partial Class SaisieTarifsDataTable

        Private Sub SaisieTarifsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.PrixVTTCColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
