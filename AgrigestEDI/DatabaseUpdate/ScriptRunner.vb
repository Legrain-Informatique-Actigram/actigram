Imports System.IO
Imports System.Data.oledb

Public Class ProgressEventArgs

    Public progress As Integer = 0
    Public max As Integer = 100
    Public status As String = ""

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal progress As Integer, Optional ByVal max As Integer = 100, Optional ByVal status As String = "")
        Me.progress = progress
        Me.max = max
        Me.status = status
    End Sub
#End Region

End Class

Public Class ScriptRunner

    Public Event ReportsProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)

    Public CheminBase As String

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal cheminBase As String)
        Me.CheminBase = cheminBase
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function ConnectionString() As String
        Return SqlProxy.GetConnectionString(CheminBase)
    End Function

    Public Sub RunSqlScript(ByVal scriptPath As String)
        RunSqlScript(New IO.FileStream(scriptPath, FileMode.Open))
    End Sub

    Public Sub RunSqlScript(ByVal s As IO.Stream)
        Dim sqlScript As String
        Dim sr As New StreamReader(s, True)

        sqlScript = sr.ReadToEnd
        sr.Close()

        Using oleDbConn As New OleDbConnection(ConnectionString)
            oleDbConn.Open()

            Dim oleDbComm As OleDbCommand = oleDbConn.CreateCommand()
            Dim oleDbTrans As OleDbTransaction

            oleDbTrans = oleDbConn.BeginTransaction()

            oleDbComm.Connection = oleDbConn
            oleDbComm.Transaction = oleDbTrans

            Dim i As Integer = 0
            Dim commands() As String = Split(sqlScript, vbCrLf & "GO" & vbCrLf)

            ReportProgress(i, commands.Length)

            Try
                For Each command As String In commands
                    Debug.Print(command)

                    If command.Trim.Length > 0 Then
                        oleDbComm.CommandText = command
                        oleDbComm.ExecuteNonQuery()

                        i += 1
                        ReportProgress(i, commands.Length)
                    End If
                Next

                oleDbTrans.Commit()
            Catch ex As Exception
                oleDbTrans.Rollback()

                Throw New Exception("La mise à jour de la base de données : " & Me.CheminBase & " ne s'est pas terminée correctement. " & ex.Message)

                'Throw ex
                'MsgBox(ex.Message)
            End Try
        End Using
    End Sub

    'Public Sub RunSqlScript(ByVal s As IO.Stream)
    '    Dim sqlScript As String
    '    Dim sr As New StreamReader(s, True)

    '    sqlScript = sr.ReadToEnd
    '    sr.Close()

    '    Dim cn As New SqlProxy(ConnectionString)

    '    Dim i As Integer = 0
    '    Dim commands() As String = Split(sqlScript, vbCrLf & "GO" & vbCrLf)

    '    ReportProgress(i, commands.Length)

    '    For Each command As String In commands
    '        Debug.Print(command)

    '        If command.Trim.Length > 0 Then
    '            Try
    '                cn.ExecuteNonQuery(command)
    '                i += 1
    '                ReportProgress(i, commands.Length)
    '            Catch ex As OleDbException
    '                'Try
    '                '    cn.ExecuteNonQuery("ROLLBACK TRANSACTION")
    '                'Catch
    '                'End Try
    '                Throw ex
    '            End Try
    '        End If
    '    Next
    '    cn.Close()
    'End Sub

    Public Sub ReportProgress(ByVal progress As Integer, Optional ByVal max As Integer = 100, Optional ByVal status As String = "")
        RaiseEvent ReportsProgress(Me, New ProgressEventArgs(progress, max, status))
    End Sub
#End Region

End Class
