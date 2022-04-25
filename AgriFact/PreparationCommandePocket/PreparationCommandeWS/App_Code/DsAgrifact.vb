Imports Microsoft.VisualBasic

Namespace DsAgrifactTableAdapters
    Partial Class VBonLivraison_DetailTA
        Public Sub InitAutoIncrementSeed(ByVal dt As DsAgrifact.VBonLivraison_DetailDataTable)
            Using s As New SqlProxy(Me.Connection)
                Dim maxId As Integer = s.GetMaxValue(dt.TableName, dt.nDetailDevisColumn.ColumnName)
                dt.nDetailDevisColumn.AutoIncrementSeed = maxId + 1
            End Using
        End Sub
    End Class
End Namespace