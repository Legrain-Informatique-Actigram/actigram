Public Class ForceDataAdapter

#Region "Force Delete"
    Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
        Dim res As Integer
        For Each m As Data.Common.DataTableMapping In dta.TableMappings
            If ds.Tables.Contains(m.DataSetTable) Then res += ForceDelete(dta, ds.Tables(m.DataSetTable))
        Next
        Return res
    End Function

    Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
        Return ForceDelete(dta, dt.Select)
    End Function

    Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
        Return ExecCommand(dta.DeleteCommand, rws, dta.ContinueUpdateOnError)
    End Function
#End Region

#Region "Force Insert"
    Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
        Dim res As Integer
        For Each m As Data.Common.DataTableMapping In dta.TableMappings
            If ds.Tables.Contains(m.DataSetTable) Then res += ForceInsert(dta, ds.Tables(m.DataSetTable))
        Next
        Return res
    End Function

    Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
        Return ForceInsert(dta, dt.Select)
    End Function

    Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
        Return ExecCommand(dta.InsertCommand, rws, dta.ContinueUpdateOnError)
    End Function

    Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal rw As DataRow) As Integer
        Dim res As Integer
        Try
            ExecCommand(dta.InsertCommand, rw)
            res += 1
        Catch ex As DataException
            rw.RowError = ex.Message
            If Not dta.ContinueUpdateOnError Then Throw ex
        End Try
        Return res
    End Function
#End Region

#Region "Force Update"
    Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
        Dim res As Integer
        For Each m As Data.Common.DataTableMapping In dta.TableMappings
            If ds.Tables.Contains(m.DataSetTable) Then res += ForceUpdate(dta, ds.Tables(m.DataSetTable))
        Next
        Return res
    End Function

    Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
        Return ForceUpdate(dta, dt.Select)
    End Function

    Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
        Return ExecCommand(dta.UpdateCommand, rws, dta.ContinueUpdateOnError)
    End Function

    Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal rw As DataRow) As Integer
        Dim res As Integer
        Try
            ExecCommand(dta.UpdateCommand, rw)
            res += 1
        Catch ex As DataException
            rw.RowError = ex.Message
            If Not dta.ContinueUpdateOnError Then Throw ex
        End Try
        Return res
    End Function
#End Region

    Public Shared Function ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal dt As DataTable, ByVal ContinueUpdateOnError As Boolean) As Integer
        Return ExecCommand(cmd, dt.Select, ContinueUpdateOnError)
    End Function

    Public Shared Function ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rws() As DataRow, ByVal ContinueUpdateOnError As Boolean) As Integer
        If cmd Is Nothing Then Throw New NullReferenceException("Objet SqlCommand obligatoire")
        If cmd.Connection Is Nothing Then Throw New NullReferenceException("Connection non affectée")
        Dim mustCloseConnection As Boolean = False
        If cmd.Connection.State <> ConnectionState.Open Then
            cmd.Connection.Open()
            mustCloseConnection = True
        End If
        Try
            Dim res As Integer
            For Each rw As DataRow In rws
                Try
                    ExecCommand(cmd, rw)
                    res += 1
                Catch ex As DataException
                    rw.RowError = ex.Message
                    If Not ContinueUpdateOnError Then Throw New Exception(ex.Message, ex)
                End Try
            Next
            Return res
        Finally
            If mustCloseConnection Then cmd.Connection.Close()
        End Try
    End Function

    Public Shared Sub ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rw As DataRow)
        For Each p As SqlClient.SqlParameter In cmd.Parameters
            p.Value = rw.Item(p.SourceColumn, p.SourceVersion)
        Next
        cmd.ExecuteNonQuery()
    End Sub
End Class