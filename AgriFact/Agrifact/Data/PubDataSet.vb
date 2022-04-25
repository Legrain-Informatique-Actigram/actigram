Partial Class PubDataSet

    Partial Class EvenementDataTable
        Public Sub InitAutoIncrementSeed()
            Using EvenementTA As New PubDataSetTableAdapters.EvenementTableAdapter
                Me.nEvenementColumn.AutoIncrement = True
                Me.nEvenementColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(EvenementTA.Connection, Me.TableName, Me.nEvenementColumn.ColumnName) + 1
            End Using
        End Sub
    End Class

End Class
