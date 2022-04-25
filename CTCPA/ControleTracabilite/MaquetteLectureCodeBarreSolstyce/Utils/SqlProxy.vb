Imports System.Data.SqlClient

''' <summary>
''' Cette classe contient un ensemble de fonctions utiles pour accéder à des bases de donnés SQL Server
''' </summary>
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

#Region "Gestion de la chaine de connexion par défaut"
    Public Shared Function TestDefaultConnection() As Boolean
        Return TestConnection(My.Settings.ConnString)
    End Function

    Public Shared Sub SetDefaultConnection(ByVal conn As SqlConnection)
        SetDefaultConnection(conn.ConnectionString)
    End Sub

    Public Shared Sub SetDefaultConnection(ByVal connString As String)
        My.Settings.SetUserOverride(My.MySettings.DefaultConnStringPropertyName, connString)
    End Sub

    Public Shared Function GetDefaultConnection() As SqlConnection
        Return New SqlConnection(My.Settings.ConnString)
    End Function
#End Region

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

    ''' <summary>
    ''' Applique un format à la chaine en formattant les arguments pour être utilisés dans du SQL (doublage des ', remplacement des "," en "." dans les décimaux, format des dates, gestion des NULL)
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Exemple d'utilisation : 
    ''' Dim sql as String = SqlProxy.FormatSql("UPDATE Client SET Nom={0}, Ville={1},CA={2}","supplément d'âme",Nothing,5/2)
    ''' 'sql = "UPDATE Client SET Nom=N'supplément d''âme', Ville=NULL,CA=2.5"
    ''' </remarks>
    Public Shared Function FormatSql(ByVal sql As String, ByVal ParamArray values() As Object) As String
        Dim formattedValues(values.Length) As String
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

    Public Function GetMaxValue(ByVal tableName As String, ByVal columnName As String, Optional ByVal whereExpr As String = "1=1") As Long
        Return SqlProxy.GetMaxValue(Me.Connection, tableName, columnName, whereExpr)
    End Function

    ''' <summary>
    ''' Exécute une requête et en renvoie le résultat dans un objet Datatable
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Exemple de code pour éxécuter une requête sur la base de données par défaut et la récupérer dans une Datatable :
    ''' Dim dt As DataTable
    ''' Using s As New SqlProxy
    '''     dt = s.ExecuteDataTable("SELECT * FROM Client")
    ''' End Using    
    '''  </remarks>
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

    Private Function GetAdapter(ByVal sql As String, Optional ByVal buildUpdateCommands As Boolean = False) As SqlDataAdapter
        Dim dta As New SqlDataAdapter(CreateCommand(sql))
        If buildUpdateCommands Then SqlProxy.BuildUpdateCommands(dta)
        Return dta
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
        Return CDec(ReplaceDbNull(CreateCommand(sql).ExecuteScalar, 0D))
    End Function

    ''' <summary>
    ''' Exécute une requête et en renvoie le premier champ sous la forme d'un entier
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Exemple de code pour éxécuter une requête sur la base de données par défaut et en récupérer le premier champs dans un entier :
    ''' Dim cnt As Integer = 0
    ''' Using s As New SqlProxy
    '''     cnt = s.ExecuteScalarInt("SELECT Count(*) FROM Client")
    ''' End Using    
    ''' </remarks>
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
        'Debug.WriteLine(sql)
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
