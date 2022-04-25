Imports System.Data.SqlClient
Public Class SqlProxy
    Implements IDisposable

    Public Event ScriptProgress(ByVal percent As Integer, ByVal etat As String)

#Region "Propriétés"
    Private _conn As SqlConnection
    Public Property Connection() As SqlConnection
        Get
            Return _conn
        End Get
        Set(ByVal Value As SqlConnection)
            _conn = Value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            If Not _conn Is Nothing Then
                Return _conn.ConnectionString
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            If Not _conn Is Nothing Then
                If _conn.State <> ConnectionState.Closed Then
                    _conn.Close()
                End If
                _conn.ConnectionString = Value
            Else
                _conn = New SqlConnection(Value)
            End If
            _conn.Open()
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        Me.New()
        Me.Connection = Connection
    End Sub

    Public Sub New(ByVal ConnectionString As String)
        Me.New()
        Me.ConnectionString = ConnectionString
    End Sub
#End Region

#Region "Shared"
    Public Shared Function TestDefaultConnection(Optional ByVal showError As Boolean = False) As Boolean
        Return TestConnection(My.Settings.ConnString, showError)
    End Function

    Public Shared Function TestConnection(ByVal connString As String, Optional ByVal showError As Boolean = False) As Boolean
        Try
            Return TestConnection(New SqlConnection(connString), showError)
        Catch ex As SqlClient.SqlException
            LogException(ex)
            If showError Then MsgBox("Connexion à la base de données impossible : " & ex.Message, MsgBoxStyle.Critical, "Erreur")
            Return False
        End Try
    End Function

    Public Shared Function TestConnection(ByVal conn As SqlConnection, Optional ByVal showError As Boolean = False) As Boolean
        Try
            conn.Open()
            Return True
        Catch ex As SqlClient.SqlException
            LogException(ex)
            If showError Then MsgBox("Connexion à la base de données impossible : " & ex.Message, MsgBoxStyle.Critical, "Erreur")
            Return False
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
    End Function

    Public Shared Sub SetDefaultConnection(ByVal conn As SqlConnection)
        SetDefaultConnection(conn.ConnectionString)
    End Sub

    Public Shared Sub SetDefaultConnection(ByVal connString As String)
        My.Settings.SetUserOverride("ConnString", connString)
        My.Settings.Save()
    End Sub

    Public Shared Function GetDefaultConnection() As SqlConnection
        Return New SqlConnection(My.Settings.ConnString)
    End Function

    'OLD WAY
    'Private Const CONN_STRING As String = "Data Source={0};Persist Security Info=True;Initial Catalog={1};{2}"
    'Public Shared Function GetConnectionString(ByVal DataServer As String, ByVal DataBase As String, Optional ByVal Login As String = Nothing, Optional ByVal Pwd As String = Nothing) As String
    '    Dim loginString As String
    '    If Login IsNot Nothing AndAlso Login.Length = 0 Then Login = Nothing
    '    If Login Is Nothing Then
    '        loginString = "Integrated Security=True"
    '    Else
    '        loginString = String.Format("User Id={0};Password={1}", Login, Pwd)
    '    End If
    '    Return String.Format(CONN_STRING, DataServer, DataBase, loginString)
    'End Function

    Public Shared Function GetConnectionString(ByVal DataServer As String, ByVal DataBase As String, Optional ByVal Login As String = Nothing, Optional ByVal Pwd As String = Nothing) As String
        With New SqlConnectionStringBuilder()
            .DataSource = DataServer
            .InitialCatalog = DataBase
            If Login Is Nothing OrElse Login.Length = 0 Then
                .IntegratedSecurity = True
            Else
                .IntegratedSecurity = False
                .UserID = Login
                .Password = Pwd
            End If
            Return .ConnectionString
        End With
    End Function

   Public Shared Function FormatSqlValue(ByVal value As String, ByVal sqldatatype As String) As String
        If value Is Nothing OrElse value.ToLower = "null" Then
            Return "NULL"
        Else
            Select Case sqldatatype.ToLower
                Case "nvarchar", "ntext", "nchar"
                    value = String.Format("N'{0}'", value.Replace("'", "''"))
                Case "varchar", "text", "char"
                    value = String.Format("'{0}'", value.Replace("'", "''"))
                Case "datetime", "smalldatetime"
                    value = String.Format("'{0:dd-MM-yyyy HH:mm:ss}'", CDate(value))
                Case Else
                    value = DecimalParse(value).GetValueOrDefault.ToString.Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, ".")
            End Select
            Return value
        End If
    End Function

    Public Shared Function FormatSql(ByVal sql As String, ByVal ParamArray values() As Object) As String
        Dim formattedValues(values.Length) As Object
        For i As Integer = 0 To values.Length - 1
            formattedValues(i) = FormatSqlValue(values(i))
        Next
        Return String.Format(sql, formattedValues)
    End Function

    Public Shared Function FormatSqlValue(ByVal value As Object) As String
        Dim res As String
        If IsDBNull(value) Or value Is Nothing Then
            res = "NULL"
        Else
            If TypeOf value Is String Then
                res = "N'" & CStr(value).Replace("'", "''") & "'"
            ElseIf TypeOf value Is Date Then
                res = String.Format("'{0:dd-MM-yyyy HH:mm:ss}'", value)
            ElseIf TypeOf value Is Boolean Then
                res = CStr(IIf(CBool(value), "1", "0"))
            ElseIf TypeOf value Is Decimal Or TypeOf value Is Single Then
                res = CDec(value).ToString().Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, ".")
            Else
                res = String.Format("{0}", value)
            End If
        End If
        Return res
    End Function

    Public Shared Sub GererSqlException(ByVal ex As SqlException)
        Select Case ex.Number
            Case 547
                MsgBox("La suppression est impossible car des enregistrements sont liés", MsgBoxStyle.Exclamation, "Suppression impossible")
            Case Else
                Throw ex
        End Select
    End Sub

    Public Shared Function GetMaxValue(ByVal conn As SqlConnection, ByVal tableName As String, ByVal columnName As String) As Integer
        Dim proxy As New SqlProxy(conn)
        Return proxy.ExecuteScalarInt(String.Format("SELECT MAX([{1}]) as Cnt FROM [{0}]", tableName, columnName))
    End Function



#Region "Force DataAdapter"
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
#End Region

    Public Shared Function ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rws() As DataRow, ByVal ContinueUpdateOnError As Boolean) As Integer
        If cmd Is Nothing Then Throw New NullReferenceException("Objet SqlCommand obligatoire")
        Dim res As Integer
        For Each rw As DataRow In rws
            Try
                ExecCommand(cmd, rw)
                res += 1
            Catch ex As DataException
                rw.RowError = ex.Message
                If Not ContinueUpdateOnError Then Throw ex
            End Try
        Next
        Return res
    End Function

    Public Shared Sub ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rw As DataRow)
        For Each p As SqlClient.SqlParameter In cmd.Parameters
            p.Value = rw.Item(p.SourceColumn, p.SourceVersion)
        Next
        cmd.ExecuteNonQuery()
    End Sub
#End Region

#End Region

    Public Function ExecuteDataTable(ByVal sql As String) As DataTable
        Try
            Dim dta As New SqlDataAdapter(CreateCommand(Sql))
            Dim dt As New DataTable
            dta.Fill(dt)
            Return dt
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Sub ExecuteNonQuery(ByVal sql As String)
        Try
            CreateCommand(sql).ExecuteNonQuery()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Sub

    Public Function ExecuteScalarBool(ByVal sql As String) As Boolean
        Return CBool(ReplaceDbNull(CreateCommand(sql).ExecuteScalar, False))
    End Function

    Public Function ExecuteScalarDec(ByVal sql As String) As Decimal
        Return CDec(ReplaceDbNull(CreateCommand(sql).ExecuteScalar, 0))
    End Function

    Public Function ExecuteScalarInt(ByVal sql As String) As Integer
        Return CInt(ReplaceDbNull(CreateCommand(sql).ExecuteScalar, 0))
    End Function

    Public Function ExecuteScalar(ByVal sql As String) As Object
        Try
            Return CreateCommand(sql).ExecuteScalar()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function ExecuteReader(ByVal sql As String) As SqlDataReader
        Try
            Return CreateCommand(sql).ExecuteReader()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function CreateCommand(ByVal sql As String) As SqlCommand
        Open()
        Dim cmd As New SqlClient.SqlCommand(sql, _conn)
        Debug.WriteLine(sql)
        Return cmd
    End Function


    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String)
        SupprimerLignes(nomTable, nomColonne, valeur, "{0}='{1}'")
    End Sub

    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String, ByVal testFormat As String)
        Dim test As String = String.Format(testFormat, nomColonne, valeur)
        ExecuteNonQuery(String.Format("delete from [{0}] where {1}", nomTable, test))
    End Sub

    Public Sub RunScript(ByVal script As String, Optional ByVal useTransaction As Boolean = True, Optional ByVal args() As Object = Nothing)
        Dim commands() As String = Microsoft.VisualBasic.Split(script, vbCrLf & "GO" & vbCrLf)
        Dim i As Integer = 0
        Try
            If useTransaction Then Me.ExecuteNonQuery("BEGIN TRANSACTION")
            For Each command As String In commands
                RaiseEvent ScriptProgress(CInt(i * 100 / commands.Length), "")
                Dim sql As String
                If args Is Nothing Then sql = command Else sql = String.Format(command, args)
                Me.ExecuteNonQuery(sql)
                i += 1
            Next
            If useTransaction Then Me.ExecuteNonQuery("COMMIT TRANSACTION")
        Catch ex As SqlException
            If useTransaction Then Me.ExecuteNonQuery("ROLLBACK TRANSACTION")
            Throw ex
        End Try
    End Sub

    Public Sub Open()
        Try
            If _conn Is Nothing Then
                _conn = GetDefaultConnection()
            End If
            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Sub

    Public Sub Close()
        Me.Dispose()
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        If Not _conn Is Nothing Then
            If _conn.State <> ConnectionState.Closed Then
                _conn.Close()
            End If
            _conn = Nothing
        End If
    End Sub

End Class
