Imports System.Data.oledb
Public Class SqlProxy
    Implements IDisposable

    Private Const CONN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};"

#Region "Propriétés"
    Private _conn As OleDbConnection
    Public Property Connection() As OleDbConnection
        Get
            Return _conn
        End Get
        Set(ByVal Value As OleDbConnection)
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
                _conn = New OleDbConnection(Value)
            End If
            _conn.Open()
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal Connection As OleDbConnection)
        Me.New()
        Me.Connection = Connection
    End Sub

    Public Sub New(ByVal ConnectionString As String)
        Me.New()
        Me.ConnectionString = ConnectionString
    End Sub
#End Region

#Region "Shared"

    Public Shared Function GetConnectionString(ByVal CheminBase As String) As String
        Return String.Format(CONN_STRING, CheminBase)
    End Function

#End Region

#Region "Méthodes diverses"
    Public Function ExecuteDataTable(ByVal sql As String) As DataTable
        Try
            Dim dta As New OleDbDataAdapter(CreateCommand(sql))
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

    Public Function ExecuteScalar(ByVal sql As String) As Object
        Try
            Return CreateCommand(sql).ExecuteScalar()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function ExecuteReader(ByVal sql As String) As OleDbDataReader
        Try
            Return CreateCommand(sql).ExecuteReader()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function CreateCommand(ByVal sql As String) As OleDbCommand
        Open()
        Dim cmd As New OleDbCommand(sql, _conn)
        Debug.WriteLine(sql)
        Return cmd
    End Function

    Public Sub Open()
        Try
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
#End Region

End Class
