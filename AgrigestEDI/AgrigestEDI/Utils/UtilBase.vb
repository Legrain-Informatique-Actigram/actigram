Imports System.Data.OleDb

Module UtilBase

    Private DEBUG_SQL As Boolean = My.Settings.DebugSql

    Public Function GetConnexion() As OleDbConnection
        Return ConnecterBase(My.Settings.CheminBase)
    End Function

    Public Function ConnecterBase(ByVal chemin As String) As OleDbConnection
        Dim conn As New OleDbConnection(AccessConnectionString(CheminComplet(chemin)))
        conn.Open()
        Return conn
    End Function

    Public Function AccessConnectionString(ByVal chemin As String) As String
        With New OleDb.OleDbConnectionStringBuilder()
            .Provider = "Microsoft.Jet.OLEDB.4.0"
            .DataSource = chemin
            Return .ConnectionString
        End With
    End Function

    Public Sub CompacterBases()
        CompacterBase(My.Settings.CheminBase)
    End Sub

    Public Sub CompacterBase(ByVal chemin As String)
        'chemin = CheminComplet(chemin)
        'If IO.File.Exists(chemin) Then
        '    Try
        '        If IO.File.Exists(IO.Path.GetFileNameWithoutExtension(chemin) & ".ldb") Then
        '            LogMessage(String.Format("Le compactage de la base de données '{0}' est impossible car elle est utilisée", chemin))
        '            Exit Sub
        '        Else
        '            If IO.File.Exists(chemin & "CPT") Then IO.File.Delete(chemin & "CPT")
        '            Dim mybaseCompacte As New dao.DBEngineClass
        '            mybaseCompacte.CompactDatabase(chemin, chemin & "CPT")
        '            IO.File.Delete(chemin)
        '            IO.File.Move(chemin & "CPT", chemin)
        '        End If
        '    Catch ex As Exception
        '        LogException(ex)
        '        MsgBox(String.Format("Le compactage de la base de données '{0}' a echoué", chemin), MsgBoxStyle.Exclamation, "Compactage")
        '    End Try
        'End If
    End Sub

    Public Sub GererOleDbException(ByVal ex As OleDbException)
        Select Case ex.ErrorCode
            'Case 547
            '    MsgBox("La suppression est impossible car des enregistrements sont liés", MsgBoxStyle.Exclamation, "Suppression impossible")
            Case Else
                Throw ex
        End Select
    End Sub

    Public Sub DebugPrintQuery(ByVal sql As String, ByVal conn As OleDb.OleDbConnection)
        Using dr As OleDb.OleDbDataReader = UtilBase.ExecuteDataReader(sql, conn)
            While dr.Read
                Dim obj(dr.FieldCount - 1) As Object
                dr.GetValues(obj)
                Debug.Print(String.Join(",", FormatEach(obj, "'{0}'").ToArray))
            End While
        End Using
    End Sub

    Public Sub DebugCommand(ByVal cmd As OleDb.OleDbCommand)
        Dim msg As New System.Text.StringBuilder
        msg.AppendLine(cmd.CommandText)
        If cmd.Parameters.Count > 0 Then
            msg.Append(" with values(")
            For Each p As OleDbParameter In cmd.Parameters
                msg.Append(String.Format("{0}={1},", p.ParameterName, p.Value))
            Next
            msg.AppendLine(")")
        End If
        msg.AppendFormat("at {0}", New StackTrace(1, True))
        LogMessage(msg.ToString)
    End Sub

#Region "Construction de SQL"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuildSqlInsert(ByVal dt As DataTable) As String
        Dim colList As New System.Text.StringBuilder
        Dim valueList As New System.Text.StringBuilder
        For Each col As DataColumn In dt.Columns
            AppendColumn(colList, "[{0}]", col)
            AppendColumn(valueList, "{{{1}}}", col)
        Next
        Return String.Format("INSERT INTO [{0}]({1}) VALUES({2})", dt.TableName, colList.ToString, valueList.ToString)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="colCles"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuildSqlUpdate(ByVal dt As DataTable, ByVal colCles() As String) As String
        Dim setList As New System.Text.StringBuilder
        Dim whereList As New System.Text.StringBuilder
        For Each col As DataColumn In dt.Columns
            If Array.IndexOf(colCles, col.ColumnName) >= 0 Then
                AppendColumn(whereList, "[{0}]={{{1}}}", col)
            Else
                AppendColumn(setList, "[{0}]={{{1}}}", col)
            End If
        Next
        Return String.Format("UPDATE [{0}] SET {1} WHERE {2}", dt.TableName, setList.ToString, whereList.ToString)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sb"></param>
    ''' <param name="format"></param>
    ''' <param name="col"></param>
    ''' <remarks></remarks>
    Private Sub AppendColumn(ByVal sb As System.Text.StringBuilder, ByVal format As String, ByVal col As DataColumn)
        If sb.Length > 0 Then
            sb.Append(",")
        End If
        sb.AppendFormat(format, col.ColumnName, col.Ordinal)
    End Sub
#End Region

#Region "Fonctions SQL"

#Region "Force DataAdapter"
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

        Public Shared Function ForceDelete(ByVal dta As OleDb.OleDbDataAdapter, ByVal ds As DataSet) As Integer
            Dim res As Integer
            For Each m As Data.Common.DataTableMapping In dta.TableMappings
                If ds.Tables.Contains(m.DataSetTable) Then res += ForceDelete(dta, ds.Tables(m.DataSetTable))
            Next
            Return res
        End Function

        Public Shared Function ForceDelete(ByVal dta As OleDb.OleDbDataAdapter, ByVal dt As DataTable) As Integer
            Return ForceDelete(dta, dt.Select)
        End Function

        Public Shared Function ForceDelete(ByVal dta As OleDb.OleDbDataAdapter, ByVal rws() As DataRow) As Integer
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

        Public Shared Function ForceInsert(ByVal dta As OleDb.OleDbDataAdapter, ByVal ds As DataSet) As Integer
            Dim res As Integer
            For Each m As Data.Common.DataTableMapping In dta.TableMappings
                If ds.Tables.Contains(m.DataSetTable) Then res += ForceInsert(dta, ds.Tables(m.DataSetTable))
            Next
            Return res
        End Function

        Public Shared Function ForceInsert(ByVal dta As OleDb.OleDbDataAdapter, ByVal dt As DataTable) As Integer
            Return ForceInsert(dta, dt.Select)
        End Function

        Public Shared Function ForceInsert(ByVal dta As OleDb.OleDbDataAdapter, ByVal rws() As DataRow) As Integer
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

        Public Shared Function ForceUpdate(ByVal dta As OleDb.OleDbDataAdapter, ByVal ds As DataSet) As Integer
            Dim res As Integer
            For Each m As Data.Common.DataTableMapping In dta.TableMappings
                If ds.Tables.Contains(m.DataSetTable) Then res += ForceUpdate(dta, ds.Tables(m.DataSetTable))
            Next
            Return res
        End Function

        Public Shared Function ForceUpdate(ByVal dta As OleDb.OleDbDataAdapter, ByVal dt As DataTable) As Integer
            Return ForceUpdate(dta, dt.Select)
        End Function

        Public Shared Function ForceUpdate(ByVal dta As OleDb.OleDbDataAdapter, ByVal rws() As DataRow) As Integer
            Return ExecCommand(dta.UpdateCommand, rws, dta.ContinueUpdateOnError, True)
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

        Public Shared Function ExecCommand(ByVal cmd As OleDb.OleDbCommand, ByVal rws() As DataRow, ByVal ContinueUpdateOnError As Boolean, Optional ByVal alwaysUseCurrentData As Boolean = False) As Integer
            If cmd Is Nothing Then Throw New NullReferenceException("Objet SqlCommand obligatoire")
            Dim res As Integer
            For Each rw As DataRow In rws
                Try
                    ExecCommand(cmd, rw, alwaysUseCurrentData)
                    res += 1
                Catch ex As OleDbException
                    rw.RowError = ex.Message
                    If Not ContinueUpdateOnError Then Throw ex
                End Try
            Next
            Return res
        End Function

        Public Shared Sub ExecCommand(ByVal cmd As OleDb.OleDbCommand, ByVal rw As DataRow, Optional ByVal alwaysUseCurrentData As Boolean = False)
            For Each p As OleDb.OleDbParameter In cmd.Parameters
                If rw.Table.Columns.Contains(p.SourceColumn) Then
                    If rw.RowState = DataRowState.Unchanged Or alwaysUseCurrentData Then
                        p.Value = rw.Item(p.SourceColumn, DataRowVersion.Current)
                    Else
                        p.Value = rw.Item(p.SourceColumn, p.SourceVersion)
                    End If
                Else
                    p.Value = DBNull.Value
                End If
            Next
            cmd.ExecuteNonQuery()
        End Sub

    End Class
#End Region

#Region "Avec Transaction"
    Public Function ExecuteScalarDec(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As Decimal
        Return CDec(ReplaceDbNull(ExecuteScalar(sql, t), 0D))
    End Function

    Public Function ExecuteScalarInt(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As Integer
        Return CInt(ReplaceDbNull(ExecuteScalar(sql, t), 0))
    End Function

    Public Function ExecuteScalarStr(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As String
        Return Convert.ToString(ReplaceDbNull(ExecuteScalar(sql, t), ""))
    End Function

    Public Function ExecuteScalar(Of T)(ByVal sql As String, ByVal trans As OleDb.OleDbTransaction, ByVal defaultValue As T) As T
        Return CType(ReplaceDbNull(ExecuteScalar(sql, trans), defaultValue), T)
    End Function

    Public Function ExecuteScalar(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As Object
        Return CreateCommand(sql, t).ExecuteScalar
    End Function

    Public Sub ExecuteNonQuery(ByVal sql As String, ByVal t As OleDb.OleDbTransaction)
        CreateCommand(sql, t).ExecuteNonQuery()
    End Sub

    Public Sub ExecuteNonQuery(ByVal sql As String, ByVal conn As OleDb.OleDbConnection, ByVal t As OleDb.OleDbTransaction, ByVal cheminBase As String)
        If t Is Nothing Then
            If conn Is Nothing Then
                conn = ConnecterBase(cheminBase)
                ExecuteNonQuery(sql, conn)
                conn.Close()
            Else
                ExecuteNonQuery(sql, conn)
            End If
        Else
            ExecuteNonQuery(sql, t)
        End If
    End Sub

    Public Function ExecuteDataReader(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As OleDb.OleDbDataReader
        Return CreateCommand(sql, t).ExecuteReader
    End Function

    Public Function ExecuteDataTable(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As DataTable
        Return ExecuteDataTable(CreateCommand(sql, t))
    End Function

    Public Sub FillDataTable(ByVal dt As DataTable, ByVal sql As String, ByVal t As OleDb.OleDbTransaction)
        FillDataTable(dt, CreateCommand(sql, t))
    End Sub

    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String, ByVal t As OleDb.OleDbTransaction)
        SupprimerLignes(nomTable, nomColonne, valeur, "{0}='{1}'", t)
    End Sub

    Public Sub SupprimerLignes(ByVal nomTable As String, ByVal nomColonne As String, ByVal valeur As String, ByVal testFormat As String, ByVal t As OleDb.OleDbTransaction)
        Dim test As String = String.Format(testFormat, nomColonne, valeur)
        ExecuteNonQuery(String.Format("delete from {0} where {1}", nomTable, test), t)
    End Sub

    Private Function CreateCommand(ByVal sql As String, ByVal t As OleDb.OleDbTransaction) As OleDb.OleDbCommand
        Dim cmd As New OleDb.OleDbCommand(sql, t.Connection, t)
        If DEBUG_SQL Then Debug.WriteLine(cmd.CommandText)
        Return cmd
    End Function
#End Region

#Region "Sans Transaction"
    Public Function ExecuteDataTable(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As DataTable
        Return ExecuteDataTable(CreateCommand(sql, conn))
    End Function

    Public Sub FillDataTable(ByVal dt As DataTable, ByVal sql As String, ByVal conn As OleDb.OleDbConnection)
        FillDataTable(dt, CreateCommand(sql, conn))
    End Sub

    Public Function ExecuteDataReader(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As OleDb.OleDbDataReader
        Return CreateCommand(sql, conn).ExecuteReader
    End Function

    Public Sub ExecuteNonQuery(ByVal sql As String, ByVal conn As OleDb.OleDbConnection)
        CreateCommand(sql, conn).ExecuteNonQuery()
    End Sub

    Public Function ExecuteScalarDec(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As Decimal
        Return CDec(ReplaceDbNull(ExecuteScalar(sql, conn), 0D))
    End Function

    Public Function ExecuteScalarStr(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As String
        Return Convert.ToString(ReplaceDbNull(ExecuteScalar(sql, conn), ""))
    End Function

    Public Function ExecuteScalarInt(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As Integer
        Return CInt(ReplaceDbNull(ExecuteScalar(sql, conn), 0))
    End Function

    Public Function ExecuteScalar(Of T)(ByVal sql As String, ByVal conn As OleDb.OleDbConnection, ByVal defaultValue As T) As T
        Return CType(ReplaceDbNull(ExecuteScalar(sql, conn), defaultValue), T)
    End Function

    Public Function ExecuteScalar(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As Object
        If conn.State = ConnectionState.Closed Then conn.Open()
        Return CreateCommand(sql, conn).ExecuteScalar
    End Function

    Private Function CreateCommand(ByVal sql As String, ByVal conn As OleDb.OleDbConnection) As OleDb.OleDbCommand
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        If DEBUG_SQL Then Debug.WriteLine(cmd.CommandText)
        Return cmd
    End Function
#End Region

    Public Function ExecuteDataTable(ByVal selectCommand As OleDb.OleDbCommand) As DataTable
        Dim dt As New DataTable
        FillDataTable(dt, selectCommand)
        Return dt
    End Function

    Public Sub FillDataTable(ByVal dt As DataTable, ByVal selectCommand As OleDb.OleDbCommand)
        Dim da As New OleDb.OleDbDataAdapter(selectCommand)
        da.Fill(dt)
    End Sub

    Public Function ReplaceDbNull(Of T)(ByVal value As Object, ByVal replace As T) As T
        Return CType(IIf(IsDBNull(value), replace, value), T)
    End Function

    Public Function FormatSql(ByVal sql As String, ByVal ParamArray values() As Object) As String
        Dim formattedValues(values.Length) As Object
        For i As Integer = 0 To values.Length - 1
            Dim value As Object = values(i)
            If value Is Nothing Or IsDBNull(value) Then
                formattedValues(i) = "null"
            Else
                If TypeOf value Is String Then
                    formattedValues(i) = "'" & CStr(value).Replace("'", "''") & "'"
                ElseIf TypeOf value Is Decimal Then
                    formattedValues(i) = CDec(value).ToString().Replace(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
                ElseIf TypeOf value Is Single Or TypeOf value Is Double Then
                    If Double.IsInfinity(CDbl(value)) Or Double.IsNaN(CDbl(value)) Then
                        formattedValues(i) = "null"
                    Else
                        formattedValues(i) = CDec(value).ToString().Replace(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
                    End If
                ElseIf TypeOf value Is Date Then
                    formattedValues(i) = CDate(value).ToString("#MM/dd/yyyy#")
                Else
                    formattedValues(i) = value
                End If
            End If
        Next
        Return String.Format(sql, formattedValues)
    End Function

    ''' <summary>
    ''' Permet de mettre à niveau la base de donnée de Agrigest² vers AgrigestEDI
    ''' </summary>
    ''' <param name="sCheminBase"></param>
    ''' <remarks></remarks>
    Sub Convert_AgrigestToAgrigestEDI(ByVal sCheminBase As String)

        Dim dbEngine As New dao.DBEngineClass
        Dim db As dao.Database

        db = dbEngine.OpenDatabase(sCheminBase)

        db.Execute("ALTER TABLE Lignes DROP CONSTRAINT TVALignes;")
        db.Execute("ALTER TABLE TVA DROP CONSTRAINT TVARecapTVA;")
        db.Execute("DROP TABLE TVA;")
        db.Execute("DROP TABLE TVARecap;")
        db.Execute("DROP TABLE TVACO;")
        db.Execute("DROP TABLE Rica;")
        db.Execute("DROP TABLE RicaCO;")
        db.Execute("DROP TABLE PlanTypeCO;")
        db.Execute("DROP TABLE PlanTypeAgricole;")
        db.Execute("DROP TABLE PlanTypeGeneral;")
        db.Execute("ALTER TABLE Comptes ADD COLUMN CCptContre TEXT(8) NOT NULL;")
        db.Execute("ALTER TABLE Comptes ADD COLUMN C_DC TEXT(1) NOT NULL;")
        db.Execute("ALTER TABLE Comptes ALTER COLUMN CLib TEXT(30);")
        db.Execute("ALTER TABLE Pieces ADD COLUMN Exporte BIT NULL;")
        db.Execute("ALTER TABLE Pieces ADD COLUMN DateExport DATETIME NULL;")
        db.Execute("ALTER TABLE Pieces ADD COLUMN Libelle TEXT(50) NULL;")
        db.Execute("ALTER TABLE Pieces ADD COLUMN Journal TEXT(50) NULL;")
        db.Execute("ALTER TABLE Pieces ADD COLUMN PPieceImport TEXT(50) NULL;")
        db.Execute("ALTER TABLE Lignes ALTER COLUMN LLib TEXT(55);")
        db.Execute("ALTER TABLE ModLignes ALTER COLUMN ModLLib TEXT(55);")
        db.Execute("ALTER TABLE PlanComptable ADD COLUMN PlLib TEXT(55) NOT NULL;")
        db.Execute("UPDATE Activites INNER JOIN (Comptes INNER JOIN PlanComptable ON (Comptes.CCpt = PlanComptable.PlCpt) AND (Comptes.CDossier = PlanComptable.PlDossier)) ON (Activites.AActi = PlanComptable.PlActi) AND (Activites.ADossier = PlanComptable.PlDossier) SET PlanComptable.PlLib = [Comptes].[CLib]+' - '+[Activites].[ALib];")
        db.Execute("UPDATE Pieces SET Pieces.Journal = '09';")
        db.Execute("UPDATE Pieces SET Pieces.Libelle = 'Piece ' + CSTR(Pieces.PPiece) + ' du ' +  CSTR(Pieces.PDate);")

        db.Close()
    End Sub

#End Region

End Module
