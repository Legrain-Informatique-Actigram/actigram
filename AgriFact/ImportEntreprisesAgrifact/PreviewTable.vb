Public Class PreviewTable
    Public Shared Sub PreviewItems(ByVal list As List(Of IDataItem))
        Dim dt As New DataTable
        Dim item As IDataItem = list(0)
        For i As Integer = 0 To item.NbCol - 1
            dt.Columns.Add(item.NomCols(i), item.ItemArray(i).GetType)
        Next
        For Each it As IDataItem In list
            dt.LoadDataRow(it.ItemArray, False)
        Next
        dt.AcceptChanges()
        With New PreviewTable
            .DataGridView1.DataSource = dt
            .Show()
        End With
    End Sub
End Class