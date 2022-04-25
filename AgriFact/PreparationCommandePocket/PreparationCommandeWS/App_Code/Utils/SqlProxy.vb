Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Collections.Generic

Public Class SqlProxy
    Implements IDisposable

    Public Event ScriptProgress(ByVal percent As Integer, ByVal etat As String)

#Region "Propriétés"
    Private _conn As SqlConnection
    Public Property Connection() As SqlConnection
        Get
            If _conn Is Nothing Then
                _conn = SqlProxy.GetDefaultConnection
            End If
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
    Public Shared Function TestDefaultConnection() As Boolean
        Return TestConnection(My.Global.Application.DefaultConnectionString)
    End Function

    Public Shared Function TestConnection(ByVal connString As String) As Boolean
        Try
            Return TestConnection(New SqlConnection(connString))
        Catch ex As SqlClient.SqlException
            LogException(ex)
            MsgBox("Connexion à la base de données impossible : " & ex.Message, MsgBoxStyle.Critical, "Erreur")
            Return False
        End Try
    End Function

    Public Shared Function TestConnection(ByVal conn As SqlConnection) As Boolean
        Try
            Dim build As New SqlConnectionStringBuilder(conn.ConnectionString)
            build.ConnectTimeout = 5
            conn.ConnectionString = build.ConnectionString
            conn.Open()
            Return True

        Catch ex As SqlClient.SqlException
            LogException(ex)
            MsgBox("Connexion à la base de données impossible : " & ex.Message, MsgBoxStyle.Critical, "Erreur")
            Return False
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
    End Function

    Public Shared Function GetDefaultConnection() As SqlConnection
        Return New SqlConnection(My.Global.Application.DefaultConnectionString)
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

    Public Shared Function ReplaceDbNull(ByVal value As Object, ByVal replace As Object) As Object
        Return IIf(IsDBNull(value), replace, value)
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
                res = String.Format("'{0}'", value)
            ElseIf TypeOf value Is Decimal Or TypeOf value Is Single Then
                res = CDec(value).ToString().Replace(",", ".")
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

    Public Shared Function GetMaxValue(ByVal conn As SqlConnection, ByVal tableName As String, ByVal columnName As String, Optional ByVal whereExpr As String = "1=1") As Integer
        Dim proxy As New SqlProxy(conn)
        Return proxy.ExecuteScalarInt(String.Format("SELECT MAX([{1}]) as Cnt FROM [{0}] WHERE {2}", tableName, columnName, whereExpr))
    End Function

    Private Shared Sub BuildUpdateCommands(ByVal dta As SqlDataAdapter)
        Dim dtAB As New SqlClient.SqlCommandBuilder(dta)
        dta.UpdateCommand = dtAB.GetUpdateCommand
        dta.InsertCommand = dtAB.GetInsertCommand
        dta.DeleteCommand = dtAB.GetDeleteCommand
    End Sub
#End Region

#Region "DataAdapters"
    Public Sub Fill(ByVal ds As DataSet, ByVal sql As String, ByVal tableName As String, Optional ByVal clearBeforeFill As Boolean = True)
        Try
            Using dta As SqlDataAdapter = GetAdapter(sql)
                If tableName IsNot Nothing Then
                    If clearBeforeFill AndAlso ds.Tables.Contains(tableName) Then
                        ds.Tables(tableName).Clear()
                    End If
                    dta.Fill(ds, tableName)
                Else
                    dta.Fill(ds)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Sub

    Public Sub FillBy(ByVal ds As DataSet, ByVal tableName As String, ByVal whereClause As String, Optional ByVal clearBeforeFill As Boolean = True)
        Fill(ds, String.Format("SELECT * FROM {0} WHERE {1}", tableName, whereClause), tableName, clearBeforeFill)
    End Sub

    Public Sub Fill(ByVal ds As DataSet, ByVal tableName As String, Optional ByVal clearBeforeFill As Boolean = True)
        Fill(ds, String.Format("SELECT * FROM {0}", tableName), tableName, clearBeforeFill)
    End Sub

    Public Sub FillSchema(ByVal ds As DataSet, ByVal tableName As String)
        FillBy(ds, tableName, "1=0")
    End Sub

    Public Sub Update(ByVal ds As DataSet)
        For Each t As DataTable In ds.Tables
            UpdateTable(ds, t.TableName, Nothing)
        Next
    End Sub

    Public Sub UpdateTables(ByVal ds As DataSet, ByVal tablenames() As String)
        Dim adapters As Dictionary(Of String, SqlDataAdapter) = CreateAdapters(tablenames)
        Try
            Array.Reverse(tablenames)
            For Each t As String In tablenames
                UpdateTableDeleted(ds, t, adapters)
            Next
            Array.Reverse(tablenames)
            For Each t As String In tablenames
                UpdateTable(ds, t, adapters)
            Next
        Finally
            For Each dta As SqlDataAdapter In adapters.Values
                dta.Dispose()
            Next
        End Try
    End Sub

    Private Function CreateAdapters(ByVal tablenames() As String) As Dictionary(Of String, SqlDataAdapter)
        Dim res As New Dictionary(Of String, SqlDataAdapter)
        For Each t As String In tablenames
            Dim sql As String = String.Format("SELECT * FROM {0}", t)
            Dim dta As SqlDataAdapter = GetAdapter(sql, True)
            res.Add(t, dta)
        Next
        Return res
    End Function


    Public Sub UpdateTableDeleted(ByVal ds As DataSet, ByVal tablename As String, ByVal adapters As Dictionary(Of String, SqlDataAdapter))
        If Not ds.Tables.Contains(tablename) Then Exit Sub
        Dim dta As SqlDataAdapter
        Dim dtaToBeDisposed As Boolean = False
        If adapters IsNot Nothing AndAlso adapters.ContainsKey(tablename) Then
            dta = adapters(tablename)
        Else
            Dim sql As String = String.Format("SELECT * FROM {0}", tablename)
            dta = GetAdapter(sql, True)
            dtaToBeDisposed = True
        End If
        Try
            dta.Update(ds.Tables(tablename).Select("", "", DataViewRowState.Deleted))
        Finally
            If dtaToBeDisposed Then dta.Dispose()
        End Try
    End Sub

    Public Sub UpdateTable(ByVal ds As DataSet, ByVal tablename As String, ByVal adapters As Dictionary(Of String, SqlDataAdapter))
        If Not ds.Tables.Contains(tablename) Then Exit Sub
        Dim dta As SqlDataAdapter
        Dim dtaToBeDisposed As Boolean = False
        If adapters IsNot Nothing AndAlso adapters.ContainsKey(tablename) Then
            dta = adapters(tablename)
        Else
            Dim sql As String = String.Format("SELECT * FROM {0}", tablename)
            dta = GetAdapter(sql, True)
            dtaToBeDisposed = True
        End If
        Try
            dta.Update(ds.Tables(tablename))
        Finally
            If dtaToBeDisposed Then dta.Dispose()
        End Try
    End Sub

    Private Function GetAdapter(ByVal sql As String, Optional ByVal buildUpdateCommands As Boolean = False) As SqlDataAdapter
        Dim dta As New SqlDataAdapter(CreateCommand(sql))
        If buildUpdateCommands Then SqlProxy.BuildUpdateCommands(dta)
        Return dta
    End Function
#End Region

    Public Function GetMaxValue(ByVal tableName As String, ByVal columnName As String, Optional ByVal whereExpr As String = "1=1") As Long
        Return SqlProxy.GetMaxValue(Me.Connection, tableName, columnName, whereExpr)
    End Function

    Public Function ExecuteDataTable(ByVal sql As String, Optional ByVal tableName As String = Nothing) As DataTable
        Try
            Using dta As SqlDataAdapter = GetAdapter(sql)
                Dim dt As New DataTable
                dta.Fill(dt)
                If tableName IsNot Nothing Then dt.TableName = tableName
                Return dt
            End Using
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
        Return DecimalParse(ReplaceDbNull(CreateCommand(sql).ExecuteScalar, "0").ToString).GetValueOrDefault
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
        'If My.Settings.DebugSql Then Debug.WriteLine(sql)
        Return cmd
    End Function


    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String)
        SupprimerLignes(nomTable, nomColonne, valeur, "{0}='{1}'")
    End Sub

    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String, ByVal testFormat As String)
        Dim test As String = String.Format(testFormat, nomColonne, valeur)
        ExecuteNonQuery(FormatSql("delete from [{0}] where {1}", nomTable, test))
    End Sub

    Public Sub RunScriptFile(ByVal scriptFile As String, Optional ByVal useTransaction As Boolean = True, Optional ByVal args() As Object = Nothing)
        If Not IO.File.Exists(scriptFile) Then Exit Sub
        Dim script As String = My.Computer.FileSystem.ReadAllText(scriptFile)
        RunScript(script, useTransaction, args)
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
