Module Utils
    Public Enum ModeExportation
        Delimite
        TailleFixe
    End Enum

    Public Sub SetTransaction(ByVal dta As OleDb.OleDbDataAdapter, ByVal t As OleDb.OleDbTransaction)
        If Not dta.SelectCommand Is Nothing Then SetTransaction(dta.SelectCommand, t)
        If Not dta.DeleteCommand Is Nothing Then SetTransaction(dta.DeleteCommand, t)
        If Not dta.UpdateCommand Is Nothing Then SetTransaction(dta.UpdateCommand, t)
        If Not dta.InsertCommand Is Nothing Then SetTransaction(dta.InsertCommand, t)
    End Sub

    Public Sub SetTransaction(ByVal cmd As OleDb.OleDbCommand, ByVal t As OleDb.OleDbTransaction)
        cmd.Connection = t.Connection
        cmd.Transaction = t
    End Sub

    Public Sub AppendTableErrors(ByVal strListeErr As Text.StringBuilder, ByVal dtErreurs As DataTable)
        If Not dtErreurs Is Nothing Then
            Dim i As Integer = 0
            For Each rE As DataRow In dtErreurs.Rows
                If rE.RowState <> DataRowState.Deleted Then
                    If rE.RowError.Length > 0 Then
                        strListeErr.AppendFormat("Erreur sur la table {1}, ligne {2} : {0}" & vbCrLf, rE.RowError, dtErreurs.TableName, i)
                        Dim colsError() As DataColumn = rE.GetColumnsInError
                        For Each col As DataColumn In colsError
                            strListeErr.AppendFormat("Colonne {0} : {1}" & vbCrLf, col.ColumnName, rE.GetColumnError(col))
                        Next
                        If rE.RowState <> DataRowState.Added Then
                            strListeErr.AppendFormat("Origine: {0}" & vbCrLf, GetRowData(rE, DataRowVersion.Original))
                        End If
                        strListeErr.AppendFormat("Current: {0}" & vbCrLf, GetRowData(rE, DataRowVersion.Current))
                    End If
                End If
                i += 1
            Next
        End If
    End Sub

    Public Function GetRowData(ByVal dr As DataRow, ByVal version As DataRowVersion) As String
        Dim res As New Text.StringBuilder
        For Each cl As DataColumn In dr.Table.Columns
            Try
                res.AppendFormat("{0}|", ReplaceDbNull(dr.Item(cl.ColumnName, version), "NULL"))
            Catch
            End Try
        Next
        Return res.ToString
    End Function


    Public Function SelectSingleRow(ByVal dt As DataTable, ByVal expression As String, ByVal ParamArray params() As Object) As DataRow
        Dim dr As DataRow = Nothing
        Dim rws() As DataRow = dt.Select(String.Format(expression, params))
        If rws.Length > 0 Then
            dr = rws(0)
        End If
        Return dr
    End Function

   

    Public Function ReplaceDbNull(ByVal obj As Object, ByVal defaultValue As Object) As Object
        If IsDBNull(obj) Then Return defaultValue Else Return obj
    End Function
End Module

Public Module FormatUtils
    Public Sub EcrireLigneFormat(ByVal tw As IO.TextWriter, ByVal format As String, ByVal dateFormat As String, ByVal ParamArray fields() As Object)
        Dim values() As Object = ReplaceDefaultValues(fields, dateFormat)
        tw.WriteLine(String.Format(format, values).Replace(",", "."))
    End Sub

    Public Sub EcrireLigneSep(ByVal tw As IO.TextWriter, ByVal sep As String, ByVal dateFormat As String, ByVal ParamArray fields() As Object)
        Dim formattedValues() As String = FormatValues(ReplaceDefaultValues(fields, dateFormat), dateFormat)
        tw.WriteLine(String.Join(sep, formattedValues))
    End Sub

    Public Function ReplaceDefaultValues(ByVal fields() As Object, ByVal dateFormat As String) As Object()
        Dim formattedValues(fields.Length - 1) As Object
        For i As Integer = 0 To fields.Length - 1
            If fields(i) Is Nothing Then
                formattedValues(i) = ""
            Else
                If TypeOf fields(i) Is Boolean Then
                    formattedValues(i) = IIf(CBool(fields(i)), "1", "0")
                ElseIf TypeOf fields(i) Is Date Then
                    If CDate(fields(i)) = Date.MinValue Then
                        formattedValues(i) = ""
                    Else
                        formattedValues(i) = CDate(fields(i)).ToString(dateFormat)
                    End If
                Else
                    formattedValues(i) = fields(i)
                End If
            End If
        Next
        Return formattedValues
    End Function

    Public Function FormatValues(ByVal fields() As Object, ByVal dateFormat As String) As String()
        Dim formattedValues(fields.Length - 1) As String
        For i As Integer = 0 To fields.Length - 1
            If TypeOf fields(i) Is Date Then
                formattedValues(i) = CDate(fields(i)).ToString(dateFormat)
            ElseIf TypeOf fields(i) Is Double Or TypeOf fields(i) Is Decimal Then
                formattedValues(i) = String.Format("{0:#0.00}", fields(i)).Replace(",", ".")
            Else
                formattedValues(i) = String.Format("{0}", fields(i))
            End If
        Next
        Return formattedValues
    End Function

End Module