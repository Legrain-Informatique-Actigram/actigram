Imports System.ComponentModel
Imports Actigram.Securite.SecuriteConverter

Namespace Donnees

    'Public Class Utils
    'Public Shared Function ReplaceDbNull(ByVal value As Object, ByVal replace As Object) As Object
    '    If IsDBNull(value) Then Return replace Else Return value
    'End Function

    'Public Shared Sub DebugDataset(ByVal ds As DataSet, Optional ByVal skipEmptyTables As Boolean = True)
    '    Dim fs As New IO.FileStream("c:\toto.htm", IO.FileMode.Create)
    '    Dim sw As New IO.StreamWriter(fs, System.Text.Encoding.Default)
    '    sw.WriteLine("<html><head><style>" & _
    '                    "body {font-family:arial;font-size: 10pt}" & vbCrLf & _
    '                    "td {font-family:arial;font-size: 10pt}" & _
    '                    "</style></head><body><a name=""top"">")
    '    For Each dt As DataTable In ds.Tables
    '        If Not skipEmptyTables OrElse dt.Rows.Count > 0 Then
    '            sw.WriteLine(String.Format("<a href=""#{0}"">Table {0}</a><br>", dt.TableName))
    '        End If
    '    Next
    '    For Each dt As DataTable In ds.Tables
    '        If Not skipEmptyTables OrElse dt.Rows.Count > 0 Then
    '            DebugDatatable(dt, sw)
    '        End If
    '    Next
    '    sw.WriteLine("</body></html>")
    '    sw.Close()
    '    Process.Start("c:\toto.htm")
    'End Sub

    'Public Shared Sub DebugDatatable(ByVal dt As DataTable)
    '    Dim fs As New IO.FileStream("c:\toto.htm", IO.FileMode.Create)
    '    Dim sw As New IO.StreamWriter(fs, System.Text.Encoding.Default)
    '    sw.WriteLine("<html><head><style>" & _
    '                    "body {font-family:arial;font-size: 10pt}" & vbCrLf & _
    '                    "td {font-family:arial;font-size: 10pt}" & _
    '                    "</style></head><body><a name=""top"">")
    '    DebugDatatable(dt, sw)
    '    sw.WriteLine("</body></html>")
    '    sw.Close()
    '    Process.Start("c:\toto.htm")
    'End Sub

    'Public Shared Sub DebugDatatable(ByVal dt As DataTable, ByVal sw As IO.StreamWriter)
    '    sw.WriteLine(String.Format("<h1><a name=""{0}"">Table {0} <a href=""#top"">Top</a></h1>", dt.TableName))
    '    sw.Write("<table cellpadding=""2"" cellspacing=""0"" border=""1"" ><thead><tr>")
    '    For Each dc As DataColumn In dt.Columns
    '        sw.Write("<th>" & dc.ColumnName & "</th>")
    '    Next
    '    sw.WriteLine("</tr></thead>")
    '    sw.WriteLine("<tbody>")
    '    For Each dr As DataRow In dt.Rows
    '        sw.WriteLine("<tr>")
    '        For i As Integer = 0 To dt.Columns.Count - 1
    '            sw.WriteLine("<td>")
    '            Try
    '                sw.Write(CStr(ReplaceDbNull(dr(i), "[NULL]")))
    '            Catch ex As Exception
    '                sw.Write("<span style=""color:red"">" & ex.Message & "</span>")
    '            End Try
    '            sw.WriteLine("</td>")
    '        Next
    '        sw.WriteLine("</tr>")
    '    Next
    '    sw.WriteLine("</tbody></table>")
    'End Sub

    '#Region "Force DataAdapter"
    '#Region "Force Delete"
    '        Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
    '            Dim res As Integer
    '            For Each m As Data.Common.DataTableMapping In dta.TableMappings
    '                If ds.Tables.Contains(m.DataSetTable) Then res += ForceDelete(dta, ds.Tables(m.DataSetTable))
    '            Next
    '            Return res
    '        End Function

    '        Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
    '            Return ForceDelete(dta, dt.Select)
    '        End Function

    '        Public Shared Function ForceDelete(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
    '            Return ExecCommand(dta.DeleteCommand, rws, dta.ContinueUpdateOnError)
    '        End Function
    '#End Region

    '#Region "Force Insert"
    '        Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
    '            Dim res As Integer
    '            For Each m As Data.Common.DataTableMapping In dta.TableMappings
    '                If ds.Tables.Contains(m.DataSetTable) Then res += ForceInsert(dta, ds.Tables(m.DataSetTable))
    '            Next
    '            Return res
    '        End Function

    '        Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
    '            Return ForceInsert(dta, dt.Select)
    '        End Function

    '        Public Shared Function ForceInsert(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
    '            Return ExecCommand(dta.InsertCommand, rws, dta.ContinueUpdateOnError)
    '        End Function
    '#End Region

    '#Region "Force Update"
    '        Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal ds As DataSet) As Integer
    '            Dim res As Integer
    '            For Each m As Data.Common.DataTableMapping In dta.TableMappings
    '                If ds.Tables.Contains(m.DataSetTable) Then res += ForceUpdate(dta, ds.Tables(m.DataSetTable))
    '            Next
    '            Return res
    '        End Function

    '        Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal dt As DataTable) As Integer
    '            Return ForceUpdate(dta, dt.Select)
    '        End Function

    '        Public Shared Function ForceUpdate(ByVal dta As SqlClient.SqlDataAdapter, ByVal rws() As DataRow) As Integer
    '            Return ExecCommand(dta.UpdateCommand, rws, dta.ContinueUpdateOnError)
    '        End Function
    '#End Region

    '        Public Shared Function ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rws() As DataRow, ByVal ContinueUpdateOnError As Boolean) As Integer
    '            If cmd Is Nothing Then Throw New NullReferenceException("Objet SqlCommand obligatoire")
    '            Dim res As Integer
    '            For Each rw As DataRow In rws
    '                Try
    '                    ExecCommand(cmd, rw)
    '                    res += 1
    '                Catch ex As DataException
    '                    rw.RowError = ex.Message
    '                    If Not ContinueUpdateOnError Then Throw ex
    '                End Try
    '            Next
    '            Return res
    '        End Function

    '        Public Shared Sub ExecCommand(ByVal cmd As SqlClient.SqlCommand, ByVal rw As DataRow)
    '            For Each p As SqlClient.SqlParameter In cmd.Parameters
    '                p.Value = rw.Item(p.SourceColumn, p.SourceVersion)
    '            Next
    '            cmd.ExecuteNonQuery()
    '        End Sub
    '#End Region


    'End Class

    '    Public Class ConfigurationOleDb
    '        Private cn As OleDb.OleDbConnection
    '        Private ds As DataSet
    '        Private dtAdapter() As OleDb.OleDbDataAdapter

    '#Region "Propriétés"
    '        Public WriteOnly Property Connexion() As OleDb.OleDbConnection
    '            Set(ByVal Value As OleDb.OleDbConnection)
    '                cn = Value
    '            End Set
    '        End Property

    '        Public Property Dataset() As DataSet
    '            Get
    '                Return ds
    '            End Get
    '            Set(ByVal Value As DataSet)
    '                ds = Value
    '            End Set
    '        End Property
    '#End Region

    '        <Description("Configure une collection de DataAdapter depuis le schéma de données du dataset")> _
    '        Public Sub ChargeDonneesFromSchema(Optional ByVal Fill As Boolean = True)
    '            ReDim dtAdapter(ds.Tables.Count - 1)
    '            Dim tb As DataTable
    '            Dim i As Integer
    '            For Each tb In ds.Tables
    '                If tb.ExtendedProperties.ContainsKey("CleDeTri") And tb.ExtendedProperties.ContainsKey("OrdreDeTri") Then
    '                    ChargeDonnees(dtAdapter(i), tb.TableName, CType(tb.ExtendedProperties("CleDeTri"), String), CType(tb.ExtendedProperties("OrdreDeTri"), String), Fill)
    '                End If
    '                i += 1
    '            Next
    '        End Sub

    '        <Description("Applique la méthode Update à l'ensemble des DataAdapters de la collection")> _
    '        Public Sub UpdateAdapters()
    '            Dim dtA As OleDb.OleDbDataAdapter
    '            For Each dtA In dtAdapter
    '                dtA.Update(ds)
    '            Next
    '        End Sub

    '        <Description("Applique la méthode Fill à l'ensemble des DataAdapters de la collection")> _
    '        Public Sub FillAdapters()
    '            Dim dtA As OleDb.OleDbDataAdapter
    '            For Each dtA In dtAdapter
    '                dtA.Fill(ds)
    '            Next
    '        End Sub

    '        <Description("Configurer un DataAdapter")> _
    '        Public Sub ChargeDonnees(ByRef dtAdapter As OleDb.OleDbDataAdapter, ByVal strTable As String, ByVal strCle As String, Optional ByVal strOrderBy As String = "", Optional ByVal Fill As Boolean = True)
    '            Dim ObjCB As OleDb.OleDbCommandBuilder

    '            If strCle <> "" Or strOrderBy <> "" Then
    '                dtAdapter = New OleDb.OleDbDataAdapter("Select * From " & strTable & " Order By " & strCle & strOrderBy, cn)
    '            Else
    '                dtAdapter = New OleDb.OleDbDataAdapter("Select * From " & strTable, cn)
    '            End If

    '            ObjCB = New OleDb.OleDbCommandBuilder(dtAdapter)
    '            If Fill = True Then
    '                dtAdapter.Fill(ds, strTable)
    '            End If
    '            dtAdapter.InsertCommand = ObjCB.GetInsertCommand
    '            dtAdapter.UpdateCommand = ObjCB.GetUpdateCommand
    '            dtAdapter.DeleteCommand = ObjCB.GetDeleteCommand


    '            If Fill = True Then
    '                If strCle <> "" Then
    '                    If ds.Tables(strTable).Columns(strCle).DataType.IsValueType = True Then
    '                        ds.Tables(strTable).Columns(strCle).AutoIncrement = True
    '                        If IsDBNull(ds.Tables(strTable).Compute("Max(" & strCle & ")", "")) Then
    '                            ds.Tables(strTable).Columns(strCle).AutoIncrementSeed = 0
    '                        Else
    '                            ds.Tables(strTable).Columns(strCle).AutoIncrementSeed = CType(ds.Tables(strTable).Compute("Max(" & strCle & ")", ""), Long) + 1
    '                        End If
    '                        ds.Tables(strTable).Columns(strCle).AutoIncrementStep = 1
    '                    End If
    '                End If

    '                Dim cl As DataColumn

    '                For Each cl In ds.Tables(strTable).Columns
    '                    If cl.DataType.ToString = "System.Boolean" Then
    '                        cl.DefaultValue = False
    '                    End If
    '                Next

    '                ds.Tables(strTable).DefaultView.Sort = strCle
    '                If ds.Tables(strTable).ExtendedProperties.ContainsKey("CleDeTri") Then
    '                    ds.Tables(strTable).ExtendedProperties.Item("CleDeTri") = strCle
    '                Else
    '                    ds.Tables(strTable).ExtendedProperties.Add("CleDeTri", strCle)
    '                End If
    '                If ds.Tables(strTable).ExtendedProperties.ContainsKey("OrdreDeTri") Then
    '                    ds.Tables(strTable).ExtendedProperties.Item("OrdreDeTri") = strOrderBy
    '                Else
    '                    ds.Tables(strTable).ExtendedProperties.Add("OrdreDeTri", strOrderBy)
    '                End If
    '            End If
    '        End Sub
    '    End Class

    Public Class ConfigurationSqlServer
        Private cn As SqlClient.SqlConnection
        Private ds As DataSet
        Private dtAdapter() As SqlClient.SqlDataAdapter
        Private lstNomTable() As String
        Private lstOrdreUpdate() As Integer
        'Private lstNomTable As New SortedList

#Region "Propriétés"
        Public WriteOnly Property Connexion() As SqlClient.SqlConnection
            Set(ByVal Value As SqlClient.SqlConnection)
                cn = Value
            End Set
        End Property

        Public Property Dataset() As DataSet
            Get
                Return ds
            End Get
            Set(ByVal Value As DataSet)
                ds = Value
            End Set
        End Property

#End Region

        Public Function GetDtaTable(ByVal NomTable As String) As SqlClient.SqlDataAdapter
            For i As Integer = 0 To lstNomTable.Length - 1
                If lstNomTable(i) = NomTable Then
                    Return dtAdapter(i)
                End If
            Next
            Return Nothing
        End Function


        <Description("Configure une collection de DataAdapter depuis le schéma de données du dataset")> _
        Public Function ChargeDonneesFromSchema(Optional ByVal Fill As Boolean = True, Optional ByVal SynchroPartiel As Boolean = True, Optional ByVal User As String = "", Optional ByVal Pwd As String = "") As String
            Try
                ReDim dtAdapter(ds.Tables.Count - 1)
                ReDim lstNomTable(dtAdapter.GetUpperBound(0))
                ReDim lstOrdreUpdate(dtAdapter.GetUpperBound(0))
                Dim tb As DataTable
                Dim i As Integer = 0
                For Each tb In ds.Tables
                    If tb.ExtendedProperties.ContainsKey("CleDeTri") And tb.ExtendedProperties.ContainsKey("OrdreDeTri") Then
                        ChargeDonnees(dtAdapter(i), tb.TableName, CType(tb.ExtendedProperties("CleDeTri"), String), CType(tb.ExtendedProperties("OrdreDeTri"), String), Fill, , SynchroPartiel, , User, Pwd)
                        lstNomTable(i) = tb.TableName
                        If tb.ExtendedProperties.ContainsKey("OrdreUpdate") = True Then
                            lstOrdreUpdate(i) = CType(tb.ExtendedProperties.Item("OrdreUpdate"), Integer)
                        Else
                            lstOrdreUpdate(i) = 5
                        End If
                    End If
                    i += 1
                Next
                Dim cl As DataColumn
                For Each tb In ds.Tables
                    For Each cl In tb.Columns
                        If cl.Expression <> "" Then
                            cl.Expression = cl.Expression
                        End If
                    Next
                Next
                Return ""
            Catch ex As DataException
                Return ex.Message
            End Try
        End Function

        Public Enum MethodeUpdate
            Delete
            Insert
        End Enum

        Private Function GetNiveau(ByVal tb As DataTable) As Integer
            Return GetNiveau(0, tb)
        End Function

        Private Function GetNiveau(ByRef nNiveau As Integer, ByVal tb As DataTable) As Integer
            Dim ct As Constraint
            For Each ct In tb.Constraints
                If TypeOf ct Is ForeignKeyConstraint Then
                    nNiveau += 1
                    If CType(ct, ForeignKeyConstraint).RelatedTable.TableName <> tb.TableName Then
                        GetNiveau(nNiveau, CType(ct, ForeignKeyConstraint).RelatedTable)
                    End If
                End If
            Next
            Return nNiveau
        End Function

        <Description("Applique la méthode Update à l'ensemble des DataAdapters de la collection")> _
        Public Function UpdateAdapters(ByVal methode As MethodeUpdate) As String
            Dim strListeErr As New Text.StringBuilder
            Try
                Dim nPassageToDo As Integer = 1
                For Each tb As DataTable In ds.Tables
                    Dim nbN As Integer = GetNiveau(tb)
                    nPassageToDo = Math.Max(nPassageToDo, nbN)
                    If Not tb.ExtendedProperties.Contains("nNiveau") Then
                        tb.ExtendedProperties.Add("nNiveau", nbN)
                    Else
                        tb.ExtendedProperties.Item("nNiveau") = nbN
                    End If
                    'Debug.WriteLine(String.Format("{0} est de niveau {1}", tb.TableName, nbN))
                Next

                For nPassage As Integer = 0 To nPassageToDo
                    Dim nEnCours As Integer
                    If methode = MethodeUpdate.Insert Then
                        nEnCours = nPassage
                    Else
                        nEnCours = nPassageToDo - nPassage
                    End If
                    For i As Integer = 0 To dtAdapter.Length - 1
                        Try
                            If CInt(ds.Tables(lstNomTable(i)).ExtendedProperties("nNiveau")) = nEnCours Then
                                dtAdapter(i).ContinueUpdateOnError = True
                                If ds.Tables.Contains(lstNomTable(i)) Then AdapterPartiel(dtAdapter(i), ds.Tables(lstNomTable(i)))
                            End If
                        Catch ex As Exception
                            strListeErr.AppendFormat("{0}({1}){2}" & vbCrLf, lstNomTable(i), ds.Tables(lstNomTable(i)).ExtendedProperties("nNiveau"), ex.ToString)
                        Finally
                            If ds.Tables(lstNomTable(i)).HasErrors = True Then
                                If Convert.ToInt32(ds.Tables(lstNomTable(i)).ExtendedProperties("nNiveau")) = nEnCours Then
                                    AppendTableErrors(strListeErr, ds.Tables(lstNomTable(i)))
                                End If
                            End If
                        End Try
                    Next
                Next
            Catch ex As Exception
                If strListeErr.Length > 0 Then strListeErr.Append(vbCrLf)
                strListeErr.AppendFormat("Message:{0}" & vbCrLf & "{1}", ex.Message, ex.StackTrace)
            End Try
            Return strListeErr.ToString
        End Function

        Public Shared Sub AppendTableErrors(ByVal strListeErr As Text.StringBuilder, ByVal dtErreurs As DataTable)
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

        Public Shared Function GetRowData(ByVal dr As DataRow, ByVal version As DataRowVersion) As String
            Dim res As New Text.StringBuilder
            For Each cl As DataColumn In dr.Table.Columns
                Try
                    res.AppendFormat("{0}|", IIf(IsDBNull(dr.Item(cl.ColumnName, version)), "NULL", dr.Item(cl.ColumnName, version)))
                Catch
                End Try
            Next
            Return res.ToString
        End Function

        Public Sub AdapterPartiel(ByVal dtAdapter As SqlClient.SqlDataAdapter, ByVal tb As DataTable)
            '<* Evite les erreurs de synchro sur les colonnes avec des expressions

            'ENLEVE PAR JEREMIE LE 23/01/07, il me semble que les colonnes expression ne doivent
            'pas poser de probleme vu comment sont générées les commandes....

            'Dim cl As DataColumn
            'Dim LstColToRemove As New Queue
            'For Each cl In tb.Columns
            '    If Not cl.Expression Is Nothing Then
            '        If cl.Expression.Length > 0 Then
            '            LstColToRemove.Enqueue(cl)
            '        End If
            '    End If
            'Next

            'Do Until LstColToRemove.Count = 0
            '    tb.Columns.Remove(CType(LstColToRemove.Dequeue, DataColumn))
            'Loop
            '*>

            If Not dtAdapter.UpdateCommand Is Nothing Then

                Dim cmdDepart As SqlClient.SqlCommand = dtAdapter.UpdateCommand

                For Each rwTmp As DataRow In tb.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
                    Dim strSet As String = ""
                    Dim strWhereCmd As String = ""
                    Dim strCount As String = ""
                    Dim cmdVerif As New SqlClient.SqlCommand("Select * From " & tb.TableName & " Where " & strWhereCmd, dtAdapter.UpdateCommand.Connection)
                    Dim cmd As New SqlClient.SqlCommand("Select * From " & tb.TableName, dtAdapter.UpdateCommand.Connection)


                    For Each prm As SqlClient.SqlParameter In cmdDepart.Parameters
                        If prm.SourceColumn <> "" Then
                            Select Case prm.SourceVersion
                                Case DataRowVersion.Current
                                    If Convert.ToString(rwTmp.Item(prm.SourceColumn)) <> Convert.ToString(rwTmp.Item(prm.SourceColumn, DataRowVersion.Original)) Then
                                        If strSet.Length > 0 Then
                                            strSet += ","
                                        End If
                                        strSet += prm.SourceColumn & "=" & prm.ParameterName
                                        Dim prmN As New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                                        cmd.Parameters.Add(prmN)
                                    End If
                                Case DataRowVersion.Original
                                    If strWhereCmd.Length > 0 Then
                                        strWhereCmd += " And "
                                    End If
                                    strWhereCmd += prm.SourceColumn & "=" & prm.ParameterName
                                    strCount = prm.SourceColumn
                                    Dim prmN As New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                                    cmd.Parameters.Add(prmN)

                                    prmN = New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                                    cmdVerif.Parameters.Add(prmN)
                            End Select
                        End If
                    Next
                    If strSet.Length > 0 And strWhereCmd.Length > 0 Then
                        cmd.CommandText = "UpDate " & tb.TableName & " Set " & strSet & " Where " & strWhereCmd
                        dtAdapter.UpdateCommand = cmd
                        cmdVerif.CommandText = "Select Count(" & strCount & ") From " & tb.TableName & " Where " & strWhereCmd
                        For Each prmVerif As SqlClient.SqlParameter In cmdVerif.Parameters
                            prmVerif.Value = rwTmp.Item(prmVerif.SourceColumn)
                        Next
                        If cmdVerif.Connection.State <> ConnectionState.Open Then
                            cmdVerif.Connection.Open()
                        End If
                        Dim ResultVerif As Object = cmdVerif.ExecuteScalar
                        If Not ResultVerif Is DBNull.Value Then
                            If Convert.ToInt32(ResultVerif) > 0 Then
                                Debug.WriteLine(dtAdapter.UpdateCommand.CommandText)
                                Dim nbRowAffected As Integer = dtAdapter.Update(New DataRow() {rwTmp})
                                If nbRowAffected = 0 Then
                                    Dim cmdInsert As SqlClient.SqlCommand = dtAdapter.InsertCommand
                                    For Each prmInsert As SqlClient.SqlParameter In cmdInsert.Parameters
                                        prmInsert.Value = rwTmp.Item(prmInsert.SourceColumn)
                                    Next
                                    Debug.WriteLine(cmdInsert.CommandText)
                                    cmdInsert.ExecuteNonQuery()
                                End If
                            End If
                        End If
                        If cmdVerif.Connection.State <> ConnectionState.Closed Then
                            cmdVerif.Connection.Close()
                        End If
                    End If
                Next
                dtAdapter.UpdateCommand = cmdDepart
            End If
            'Lancer toutes les autres modifs (Insert, Delete)
            Dim nb As Integer = dtAdapter.Update(tb)
        End Sub

        '<Description("Applique la méthode Update à l'ensemble des DataAdapters de la collection")> _
        'Public Function UpdateAdapters() As String
        '    Dim dtA As SqlClient.SqlDataAdapter
        '    Dim strListeErr As String
        '    Dim i As Integer
        '    Dim iOrdre As Integer
        '    For iOrdre = 0 To 10
        '        For i = 0 To dtAdapter.GetUpperBound(0)
        '            If lstOrdreUpdate(i) = iOrdre Then
        '                Try
        '                    dtAdapter(i).ContinueUpdateOnError = True
        '                    dtAdapter(i).Update(ds, lstNomTable(i))
        '                Catch ex As Exception
        '                    strListeErr += lstNomTable(i) & "(" & lstOrdreUpdate(i) & ")" & ex.Message & vbCrLf
        '                Finally
        '                    If ds.Tables(lstNomTable(i)).HasErrors = True Then
        '                        Dim dtErreurs As DataTable = ds.Tables(lstNomTable(i))
        '                        If Not dtErreurs Is Nothing Then
        '                            If dtErreurs.Rows.Count > 0 Then
        '                                Dim rE As DataRow
        '                                Dim cl As DataColumn
        '                                For Each rE In dtErreurs.Rows
        '                                    If rE.RowError <> "" Then
        '                                        strListeErr += rE.RowError
        '                                        strListeErr += vbCrLf
        '                                        For Each cl In dtErreurs.Columns
        '                                            Try
        '                                                If rE.Table.Columns.Contains(cl.ColumnName) = True Then
        '                                                    strListeErr += Convert.ToString(rE.Item(cl.ColumnName)) & "|"
        '                                                End If
        '                                            Catch ex As Exception
        '                                            End Try
        '                                        Next
        '                                        strListeErr += vbCrLf
        '                                    End If
        '                                Next
        '                            End If
        '                        End If
        '                    End If
        '                End Try
        '            End If
        '        Next
        '    Next
        '    Return strListeErr
        'End Function

        '<Description("Applique la méthode Fill à l'ensemble des DataAdapters de la collection")> _
        'Public Sub FillAdapters()
        '    Dim dtA As SqlClient.SqlDataAdapter
        '    For Each dtA In dtAdapter
        '        dtA.Fill(ds)
        '    Next
        'End Sub

        <Description("Configurer un DataAdapter")> _
        Public Sub ChargeDonnees(ByRef dtAdapter As SqlClient.SqlDataAdapter, ByVal strTable As String, ByVal strCle As String, Optional ByVal strOrderBy As String = "", Optional ByVal Fill As Boolean = True, Optional ByVal lstColAutoNum As String = "", Optional ByVal SynchroPartiel As Boolean = True, Optional ByVal strWhere As String = "", Optional ByVal User As String = "", Optional ByVal Pwd As String = "")
            dtAdapter = ChargeDonnees(Me.ds, strTable, strCle, strOrderBy, Fill, lstColAutoNum, SynchroPartiel, strWhere, User, Pwd)
        End Sub

        Public Function ChargeDonnees(ByVal ds As DataSet, ByVal strTable As String, ByVal strCle As String, Optional ByVal strOrderBy As String = "", Optional ByVal Fill As Boolean = True, Optional ByVal lstColAutoNum As String = "", Optional ByVal SynchroPartiel As Boolean = True, Optional ByVal strWhere As String = "", Optional ByVal User As String = "", Optional ByVal Pwd As String = "") As SqlClient.SqlDataAdapter
            Dim ObjCB As SqlClient.SqlCommandBuilder

            Dim strOrderBySql As String = ""

            If strCle <> "" And strOrderBy = "" Then
                strOrderBySql = strTable & "." & strCle
            End If
            If strOrderBy <> "" Then
                If strOrderBySql.Length > 0 Then
                    strOrderBySql += ","
                End If
                strOrderBySql += strOrderBy
            End If

            If strOrderBySql.Length > 0 Then
                strOrderBySql = " Order By " & strOrderBySql
            End If

            Dim strSelectJoin As String = ""

            If SynchroPartiel = True Then
                strSelectJoin = Donnees.GestionBaseSql.GetInnerJoinPartiel(strTable, User)
            End If

            If strTable = "Utilisateurs" Then
                If strWhere = "" Then
                    strWhere = " Where Utilisateur='" & User & "' And Password='" & Pwd & "'"
                End If
            End If

            Dim dtAdapter As New SqlClient.SqlDataAdapter("Select " & strTable & ".* From " & strTable & strSelectJoin & strWhere & strOrderBySql, cn)

            ObjCB = New SqlClient.SqlCommandBuilder(dtAdapter)
            If Fill Then
                Try
                    dtAdapter.SelectCommand.CommandTimeout = 120
                    dtAdapter.Fill(ds, strTable)
                Catch ex As Exception
                    Dim a As String
                    a = "1"
                End Try
            End If
            dtAdapter.SelectCommand.CommandText = "Select " & strTable & ".* From " & strTable & strWhere & strOrderBySql
            dtAdapter.InsertCommand = ObjCB.GetInsertCommand
            dtAdapter.UpdateCommand = ObjCB.GetUpdateCommand
            dtAdapter.DeleteCommand = ObjCB.GetDeleteCommand

            If strCle <> "" Then

                Dim strWhereAd As String = ""
                Dim cmd As New SqlClient.SqlCommand("Select * From " & strTable, cn)
                Dim cmdDel As New SqlClient.SqlCommand("Select * From " & strTable, cn)

                Dim prm As Data.SqlClient.SqlParameter
                Dim strCmd As String = dtAdapter.UpdateCommand.CommandText.Substring(0, dtAdapter.UpdateCommand.CommandText.ToUpper.IndexOf("WHERE"))

                Array.IndexOf(strCle.Split(","c), "NomChoix")


                For Each prm In dtAdapter.UpdateCommand.Parameters


                    If prm.SourceVersion = DataRowVersion.Original Then
                        If Array.IndexOf(strCle.Split(","c), prm.SourceColumn) >= 0 And prm.SourceColumn <> "" Then
                            If strWhereAd.Length > 0 Then
                                strWhereAd += " And "
                            End If
                            strWhereAd += prm.SourceColumn & "=" & prm.ParameterName
                            Dim prmN As New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                            cmd.Parameters.Add(prmN)
                            Dim prmDelN As New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                            cmdDel.Parameters.Add(prmDelN)
                        End If
                    Else
                        If Array.IndexOf(strCle.Split(","c), prm.SourceColumn) < 0 And prm.SourceColumn <> "" Then
                            Dim prmN As New SqlClient.SqlParameter(prm.ParameterName, prm.SqlDbType, prm.Size, prm.Direction, True, prm.Precision, prm.Scale, prm.SourceColumn, prm.SourceVersion, prm.Value)
                            cmd.Parameters.Add(prmN)
                        End If
                    End If
                Next

                Dim strSet As String = ""
                Dim strWhereCmd As String = ""

                For Each prm In cmd.Parameters
                    If prm.SourceVersion = DataRowVersion.Original Then
                        If strWhereCmd.Length > 0 Then
                            strWhereCmd += " And "
                        End If
                        strWhereCmd += prm.SourceColumn & "=" & prm.ParameterName
                    Else
                        If strSet.Length > 0 Then
                            strSet += " , "
                        End If
                        strSet += prm.SourceColumn & "=" & prm.ParameterName
                        If prm.SqlDbType = SqlDbType.NVarChar Then
                            ds.Tables(strTable).Columns(prm.SourceColumn).MaxLength = 255
                        End If
                    End If
                Next

                cmd.CommandText = "UpDate " & strTable & " Set " & strSet & " Where " & strWhereCmd
                cmdDel.CommandText = "Delete From " & strTable & " Where " & strWhereCmd
                dtAdapter.UpdateCommand = cmd
                dtAdapter.DeleteCommand = cmdDel
            End If

            If Fill = True Then
                If strCle <> "" Then
                    Dim a() As String
                    Dim b As String
                    Dim i As Integer = 0

                    a = strCle.Split(","c)

                    Dim cols(a.GetUpperBound(0)) As DataColumn

                    For Each b In a
                        cols.SetValue(ds.Tables(strTable).Columns(b), i)
                        i += 1
                    Next
                    If cols.GetUpperBound(0) >= 0 Then
                        ds.Tables(strTable).PrimaryKey = cols
                    End If
                End If

                For Each cl As DataColumn In ds.Tables(strTable).Columns
                    If cl.DataType.ToString = "System.Boolean" Then
                        cl.DefaultValue = False
                    End If
                Next

                For Each bT As String In Split(lstColAutoNum, ",")
                    If ds.Tables(strTable).Columns.Contains(bT) = True Then
                        ds.Tables(strTable).Columns(bT).AutoIncrement = True
                    End If
                Next

                ds.Tables(strTable).DefaultView.Sort = strCle
                If ds.Tables(strTable).ExtendedProperties.ContainsKey("CleDeTri") Then
                    ds.Tables(strTable).ExtendedProperties.Item("CleDeTri") = strCle
                Else
                    ds.Tables(strTable).ExtendedProperties.Add("CleDeTri", strCle)
                End If
                If ds.Tables(strTable).ExtendedProperties.ContainsKey("OrdreDeTri") Then
                    ds.Tables(strTable).ExtendedProperties.Item("OrdreDeTri") = strOrderBy
                Else
                    ds.Tables(strTable).ExtendedProperties.Add("OrdreDeTri", strOrderBy)
                End If
            End If
            Return dtAdapter
        End Function

    End Class

    Public Class ConfigDivers
        Shared Sub ActuCompteur(ByVal ds As DataSet, ByVal nUtilisateur As Int32)
            Dim tb As DataTable
            Dim cl As DataColumn

            For Each tb In ds.Tables
                If tb.ExtendedProperties.ContainsKey("CleDeTri") = True Then
                    tb.DefaultView.Sort = Convert.ToString(tb.ExtendedProperties.Item("CleDeTri"))
                End If
                For Each cl In tb.Columns
                    If cl.AutoIncrement = True Then
                        Dim Obj As Object
                        Dim nCleMax As Long
                        Obj = tb.Compute("Max(" & cl.ColumnName & ")", "")
                        If Not Obj Is System.DBNull.Value Then
                            nCleMax = CLng(Obj) + 2000
                            nCleMax = (nCleMax \ 1000) * 1000 + nUtilisateur
                        Else
                            nCleMax = 1000 + nUtilisateur
                        End If
                        tb.Columns(cl.ColumnName).AutoIncrementSeed = nCleMax
                        tb.Columns(cl.ColumnName).AutoIncrementStep = 1000
                    End If
                    If cl.ExtendedProperties.ContainsKey("DefaultValue") = True Then
                        Select Case CType(cl.ExtendedProperties.Item("DefaultValue"), String)
                            Case "Now"
                                cl.DefaultValue = Now.ToShortDateString
                        End Select
                    End If
                Next
            Next
        End Sub

    End Class

    'Public Class SynchroFunctions
    '    Public Shared Function VersionDispo(ByVal ServerFilePath As String, Optional ByRef nVersion As Long = 0) As String
    '        Dim strTemp As String
    '        Dim nVersionDispo As Integer = 1

    '        Do Until System.IO.File.Exists(ServerFilePath.Replace("SchemaDonnees0.xml", "SchemaDonnees" & nVersionDispo & ".xml")) = False
    '            nVersionDispo += 1
    '        Loop

    '        nVersion = nVersionDispo - 1

    '        If System.IO.File.Exists(ServerFilePath.Replace("SchemaDonnees0.xml", "SchemaDonnees" & nVersion & ".xml")) Then
    '            '* Lecture et décryptage du fichier
    '            strTemp = Actigram.Securite.SecuriteConverter.DeCrypteFromFileToString(ServerFilePath.Replace("SchemaDonnees0.xml", "SchemaDonnees" & nVersion & ".xml"))
    '            '* Cryptage des données sous forme de string
    '            Return Actigram.Securite.SecuriteConverter.CrypteString(strTemp)
    '        Else
    '            Return ""
    '        End If

    '    End Function

    '    Public Shared Function RecupBaseDataset(ByVal strconnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByRef nbLastConnection As Long, ByVal ServerFileSchemaActuel As String, Optional ByVal SynchroPartiel As Boolean = True, Optional ByRef strErreur As String = "") As DataSet
    '        Dim dsApMAJ As New DataSet
    '        Dim mDaT As New Donnees.ConfigurationSqlServer
    '        'Dim cn As New SqlClient.SqlConnection("Initial Catalog=LEA;Data Source=(local);User ID=sa;password=;")

    '        Dim User As String = Actigram.Securite.SecuriteConverter.DeCrypteString(Utilisateur)
    '        Dim Pwd As String = Actigram.Securite.SecuriteConverter.DeCrypteString(MotPasse)

    '        'Dim User As String = Utilisateur
    '        'Dim Pwd As String = MotPasse

    '        Dim cn As New SqlClient.SqlConnection(strconnexion.Replace("Utilisateur", User).Replace("Pwd", Pwd))

    '        Try
    '            cn.Open()
    '        Catch ex As Exception
    '            strErreur = ex.Message
    '            Return Nothing
    '        End Try

    '        Dim cmd As New Data.SqlClient.SqlCommand("Select max(nTrans) From Transactions", cn)
    '        Dim objTmp As Object
    '        objTmp = cmd.ExecuteScalar
    '        If Not objTmp Is DBNull.Value Then
    '            nbLastConnection = Convert.ToInt64(objTmp)
    '        Else
    '            nbLastConnection = 0
    '        End If

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsApMAJ, ServerFileSchemaActuel)

    '        Dim str As New System.IO.StringReader(ServerFileSchemaActuel)
    '        dsApMAJ.ReadXmlSchema(str)

    '        mDaT = New Donnees.ConfigurationSqlServer

    '        mDaT.Connexion = cn
    '        mDaT.Dataset = dsApMAJ
    '        Dim rep As String = ""
    '        dsApMAJ.EnforceConstraints = False
    '        rep = mDaT.ChargeDonneesFromSchema(True, SynchroPartiel, User, Pwd)
    '        dsApMAJ.EnforceConstraints = True
    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '        End If

    '        If rep <> "" Then
    '            strErreur = "Erreur chargement des données dans RecupBase : " & vbCrLf & rep
    '            'Return CrypteString("Erreur chargement des données dans RecupBase : " & vbCrLf & rep)
    '            Return Nothing
    '        End If

    '        'Dim strTmp As String
    '        'strTmp = Actigram.Securite.SecuriteConverter.CrypteString(dsApMAJ.GetXml)

    '        Return dsApMAJ
    '    End Function

    '    Public Shared Function RecupBase(ByVal strconnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByRef nbLastConnection As Long, ByVal ServerFileSchemaActuel As String, Optional ByVal SynchroPartiel As Boolean = True) As String
    '        Dim dsApMAJ As New DataSet
    '        Dim mDaT As New Donnees.ConfigurationSqlServer
    '        'Dim cn As New SqlClient.SqlConnection("Initial Catalog=LEA;Data Source=(local);User ID=sa;password=;")

    '        Dim User As String = Actigram.Securite.SecuriteConverter.DeCrypteString(Utilisateur)
    '        Dim Pwd As String = Actigram.Securite.SecuriteConverter.DeCrypteString(MotPasse)

    '        Dim cn As New SqlClient.SqlConnection(strconnexion.Replace("Utilisateur", User).Replace("Pwd", Pwd))

    '        Try
    '            cn.Open()

    '            If SynchroPartiel = True Then
    '                Dim cmdTmp As New SqlClient.SqlCommand("Delete From [ListeEntreprise" & User & "]", cn)
    '                cmdTmp.ExecuteNonQuery()

    '                cmdTmp.CommandText = "Insert Into [ListeEntreprise" & User & "] Select * From GetListeEntreprise(null)"
    '                cmdTmp.ExecuteNonQuery()

    '                '* Pour limite le temps de traitement des requetes des Tables Evenement, EvenementPersonne,EvenementPiece
    '                cmdTmp.CommandText = "Select Departement From Utilisateurs Where Utilisateur='" & User & "' And Password='" & Pwd & "'"
    '                Dim ObjReponse As Object
    '                ObjReponse = cmdTmp.ExecuteScalar
    '                If Not ObjReponse Is DBNull.Value Then
    '                    If Convert.ToString(ObjReponse).ToUpper = "TOUS" Then
    '                        SynchroPartiel = False
    '                    End If
    '                End If
    '            End If

    '        Catch ex As Exception
    '            Return CrypteString(ex.Message)
    '        End Try

    '        Dim cmd As New Data.SqlClient.SqlCommand("Select max(nTrans) From Transactions", cn)
    '        Dim objTmp As Object
    '        objTmp = cmd.ExecuteScalar
    '        If Not objTmp Is DBNull.Value Then
    '            nbLastConnection = Convert.ToInt64(objTmp)
    '        Else
    '            nbLastConnection = 0
    '        End If

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsApMAJ, ServerFileSchemaActuel)

    '        Dim str As New System.IO.StringReader(ServerFileSchemaActuel)

    '        dsApMAJ.ReadXmlSchema(str)

    '        mDaT = New Donnees.ConfigurationSqlServer

    '        mDaT.Connexion = cn
    '        mDaT.Dataset = dsApMAJ
    '        Dim rep As String = ""
    '        dsApMAJ.EnforceConstraints = False
    '        rep = mDaT.ChargeDonneesFromSchema(True, SynchroPartiel, User, Pwd)

    '        Try
    '            dsApMAJ.EnforceConstraints = True
    '        Catch ex As Exception
    '            Return ex.Message & vbCrLf & ex.StackTrace
    '        End Try

    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '        End If

    '        If rep <> "" Then
    '            Return CrypteString("Erreur chargement des données dans RecupBase : " & vbCrLf & rep)
    '            Exit Function
    '        End If

    '        Dim strTmp As String
    '        strTmp = Actigram.Securite.SecuriteConverter.CrypteString(dsApMAJ.GetXml)

    '        Return strTmp
    '    End Function

    '    Public Shared Function SynchroPartiel(ByVal strConnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByRef strDonneesPartiel As String, ByVal ServerFileSchemaActuel As String, Optional ByVal SynchroP As Boolean = True) As String
    '        Dim dsAvMAJ As New DataSet
    '        Dim strLstErreur As String
    '        Dim mDaT As New Donnees.ConfigurationSqlServer

    '        Dim User As String = Actigram.Securite.SecuriteConverter.DeCrypteString(Utilisateur)
    '        Dim Pwd As String = Actigram.Securite.SecuriteConverter.DeCrypteString(MotPasse)

    '        Dim cn As New SqlClient.SqlConnection(strConnexion.Replace("Utilisateur", User).Replace("Pwd", Pwd))

    '        Try
    '            cn.Open()

    '            'If SynchroP = True Then
    '            '    Dim cmdTmp As New SqlClient.SqlCommand("Delete From [ListeEntreprise" & User & "]", cn)
    '            '    cmdTmp.ExecuteNonQuery()
    '            '    cmdTmp.CommandText = "Insert Into [ListeEntreprise" & User & "] Select * From GetListeEntreprise(null)"
    '            '    cmdTmp.ExecuteNonQuery()
    '            'End If

    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsAvMAJ, ServerFileSchemaActuel)
    '        If ServerFileSchemaActuel.StartsWith("<") = False Then
    '            Return ServerFileSchemaActuel
    '        End If
    '        Dim str As New System.IO.StringReader(ServerFileSchemaActuel)
    '        dsAvMAJ.EnforceConstraints = False
    '        dsAvMAJ.ReadXmlSchema(str)

    '        Try
    '            Dim strDonneesDepart As String = Actigram.Securite.SecuriteConverter.DeCrypteString(strDonneesPartiel)
    '            Dim memReader As New System.IO.StringReader(strDonneesDepart)
    '            Dim xmlReader As New System.Xml.XmlTextReader(memReader)
    '            dsAvMAJ.ReadXml(xmlReader, XmlReadMode.DiffGram)
    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try

    '        mDaT.Connexion = cn

    '        If Not dsAvMAJ.GetChanges(DataRowState.Deleted) Is Nothing Then
    '            'Dim tb As DataTable
    '            'For Each tb In dsAvMAJ.Tables
    '            '    tb.ExtendedProperties.Add("OrdreUpdate", 0)
    '            'Next
    '            dsAvMAJ.Tables("Evenement").ExtendedProperties.Add("OrdreUpdate", 6)
    '            dsAvMAJ.Tables("Devis").ExtendedProperties.Add("OrdreUpdate", 6)
    '            dsAvMAJ.Tables("Produit").ExtendedProperties.Add("OrdreUpdate", 6)
    '            dsAvMAJ.Tables("Entreprise").ExtendedProperties.Add("OrdreUpdate", 7)
    '            dsAvMAJ.Tables("Personne").ExtendedProperties.Add("OrdreUpdate", 7)
    '            dsAvMAJ.Tables("Niveau1").ExtendedProperties.Add("OrdreUpdate", 7)
    '        Else
    '            dsAvMAJ.Tables("Entreprise").ExtendedProperties.Add("OrdreUpdate", 0)
    '            dsAvMAJ.Tables("Niveau1").ExtendedProperties.Add("OrdreUpdate", 0)
    '            dsAvMAJ.Tables("Personne").ExtendedProperties.Add("OrdreUpdate", 1)
    '            dsAvMAJ.Tables("Evenement").ExtendedProperties.Add("OrdreUpdate", 2)
    '            dsAvMAJ.Tables("Devis").ExtendedProperties.Add("OrdreUpdate", 2)
    '            dsAvMAJ.Tables("Produit").ExtendedProperties.Add("OrdreUpdate", 3)
    '        End If

    '        mDaT.Dataset = dsAvMAJ

    '        mDaT.ChargeDonneesFromSchema(False, SynchroP)
    '        If Not dsAvMAJ.GetChanges(DataRowState.Deleted) Is Nothing Then
    '            strLstErreur = mDaT.UpdateAdapters(ConfigurationSqlServer.MethodeUpdate.Delete)
    '        Else
    '            strLstErreur = mDaT.UpdateAdapters(ConfigurationSqlServer.MethodeUpdate.Insert)
    '        End If
    '        'strLstErreur = mDaT.UpdateAdapters()

    '        If strLstErreur = "" Then strLstErreur = "Ok"

    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '        End If

    '        Return strLstErreur
    '    End Function

    '    Public Shared Function RecupModif(ByVal strConnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByRef nbLastConnection As Long, ByRef XmlSchema As String, ByVal ServerFilePathSchemaActuel As String, Optional ByVal SynchroPartiel As Boolean = True) As String
    '        'Dim nbLastConnection As Integer
    '        'Dim nUtilisateur As Integer = 0
    '        Dim dsModif As New DataSet
    '        Dim tbTrans As New DataTable
    '        Dim mDaT As New Donnees.ConfigurationSqlServer

    '        Dim cn As New SqlClient.SqlConnection(strConnexion.Replace("Utilisateur", DeCrypteString(Utilisateur)).Replace("Pwd", DeCrypteString(MotPasse)))

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsModif, Application.StartupPath & "\SchemaDonneesActuel.xml")
    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsModif, ServerFilePathSchemaActuel)
    '        Dim str As New System.IO.StringReader(ServerFilePathSchemaActuel)

    '        If ServerFilePathSchemaActuel.StartsWith("<") = False Then
    '            Return ServerFilePathSchemaActuel
    '        End If

    '        dsModif.ReadXmlSchema(str)


    '        Dim strSqlLstPersonneAvModif As String
    '        Dim strSqlLstPersonneAvDelete As String
    '        Dim strSqlLstPersonneInsert As String
    '        Dim strSqlLstPersonneUpdate As String
    '        Dim strSqlLstPersonneDelete As String
    '        Dim nMaxTrans As Long

    '        Dim tb As DataTable

    '        Try
    '            cn.Open()

    '            If SynchroPartiel = True Then
    '                Dim cmdTmp As New SqlClient.SqlCommand("Delete From [ListeEntreprise" & DeCrypteString(Utilisateur) & "]", cn)
    '                cmdTmp.ExecuteNonQuery()
    '                cmdTmp.CommandText = "Insert Into [ListeEntreprise" & DeCrypteString(Utilisateur) & "] Select * From GetListeEntreprise(null)"
    '                cmdTmp.ExecuteNonQuery()
    '            End If

    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try

    '        Dim cmd As New Data.SqlClient.SqlCommand("Select max(nTrans) From Transactions", cn)
    '        Dim objTmp As Object
    '        objTmp = cmd.ExecuteScalar
    '        If Not objTmp Is DBNull.Value Then
    '            nMaxTrans = Convert.ToInt64(objTmp)
    '        End If

    '        Try
    '            dsModif.EnforceConstraints = False

    '            For Each tb In dsModif.Tables
    '                If tb.PrimaryKey.GetUpperBound(0) >= 0 Then
    '                    Dim strCleOn As String = ""
    '                    Dim strCleOnGetListeEntreprise As String = ""
    '                    Dim strCleIn As String = ""
    '                    Dim strCleAs As String = ""

    '                    Dim cle As DataColumn
    '                    Dim iCle As Integer = 0
    '                    Dim striCle As String = ""

    '                    For Each cle In tb.PrimaryKey
    '                        If iCle = 0 Then
    '                            striCle = ""
    '                        Else
    '                            striCle = iCle.ToString
    '                        End If
    '                        If strCleOn.Length > 0 Then
    '                            strCleOn += " And "
    '                            strCleIn += " + "
    '                            strCleAs += ","
    '                        End If
    '                        strCleOn += "[" & tb.TableName & "].[" & cle.ColumnName & "]=Transactions.nCleTrans" & striCle
    '                        strCleIn += "Transactions.nCleTrans" & striCle
    '                        strCleAs += "nCleTrans" & striCle & " As '" & cle.ColumnName & "'"
    '                        iCle += 1
    '                    Next

    '                    strCleOn = "(" & strCleOn & ")"
    '                    strCleIn = "(" & strCleIn & ")"

    '                    If SynchroPartiel = True Then
    '                        strCleOnGetListeEntreprise = Donnees.GestionBaseSql.GetInnerJoinPartiel(tb.TableName, DeCrypteString(Utilisateur))
    '                    End If

    '                    '* Liste des Personnnes à inserer pour modification ultérieur
    '                    strSqlLstPersonneAvModif = "Select [" & tb.TableName & "].* From [" & tb.TableName & "] Inner Join Transactions On " & strCleOn & strCleOnGetListeEntreprise & " " & _
    '                    "Where  " & strCleIn & " Not in (Select " & strCleIn & " From Transactions Where (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And (ActionTrans='INSERTED' OR ActionTrans='DELETED')) " & _
    '                    "And (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And ActionTrans='UPDATED' And idUser<>CURRENT_USER"

    '                    Dim dtAPersonne As New SqlClient.SqlDataAdapter(strSqlLstPersonneAvModif, cn)
    '                    'Try
    '                    dtAPersonne.Fill(dsModif.Tables(tb.TableName))
    '                    'Catch ex As Exception
    '                    '    Return CrypteString(ex.Message)
    '                    'End Try

    '                    '* Liste des Personnes à inserer pour suppression ultérieur
    '                    Dim tbDeleted As New DataTable
    '                    strSqlLstPersonneAvDelete = "Select Distinct " & strCleAs & " From Transactions " & _
    '                    "Where  " & strCleIn & " Not in (Select " & strCleIn & " From Transactions Where (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And (ActionTrans='INSERTED')) " & _
    '                    "And (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And ActionTrans='DELETED' And idUser<>CURRENT_USER"

    '                    dtAPersonne = New SqlClient.SqlDataAdapter(strSqlLstPersonneAvDelete, cn)

    '                    dtAPersonne.Fill(tbDeleted)

    '                    Dim rwi As DataRow
    '                    Dim rwA As DataRow

    '                    For Each rwi In tbDeleted.Rows
    '                        rwA = tb.NewRow
    '                        Dim cl As DataColumn
    '                        For Each cl In tb.PrimaryKey
    '                            rwA.Item(cl.ColumnName) = rwi.Item(cl.ColumnName)
    '                        Next
    '                        tb.Rows.Add(rwA)
    '                    Next
    '                    tb.AcceptChanges()

    '                    '* Liste des personnes insérées durant la période et non supprimées depuis
    '                    '* Liste des personnes a insérer
    '                    strSqlLstPersonneInsert = "Select [" & tb.TableName & "].* From Transactions Inner Join [" & tb.TableName & "] On " & strCleOn & strCleOnGetListeEntreprise & "  Where  " & strCleIn & " Not in (Select " & strCleIn & " From Transactions Where (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And  ActionTrans='DELETED') " & _
    '                    "And Transactions.TableTrans='" & tb.TableName & "' And (Transactions.nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And Transactions.ActionTrans='INSERTED' And idUser<>CURRENT_USER"

    '                    dtAPersonne = New SqlClient.SqlDataAdapter(strSqlLstPersonneInsert, cn)
    '                    dtAPersonne.AcceptChangesDuringFill = False
    '                    dtAPersonne.Fill(tb)

    '                    '* Liste des personnes modifiées, qui n'ont pas été insérée dans cette période ni supprimée
    '                    '* Liste des personnes a modifier
    '                    strSqlLstPersonneUpdate = "Select [" & tb.TableName & "].* From [" & tb.TableName & "] Inner Join Transactions On " & strCleOn & strCleOnGetListeEntreprise & " " & _
    '                    "Where  " & strCleIn & " Not in (Select " & strCleIn & " From Transactions Where (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And  (ActionTrans='DELETED' Or ActionTrans='INSERTED')) " & _
    '                    "And (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And ActionTrans='UPDATED' And idUser<>CURRENT_USER"

    '                    dtAPersonne = New SqlClient.SqlDataAdapter(strSqlLstPersonneUpdate, cn)
    '                    dtAPersonne.AcceptChangesDuringFill = False
    '                    Dim tbUpdate As New DataTable
    '                    dtAPersonne.Fill(tbUpdate)

    '                    For Each rwi In tbUpdate.Rows
    '                        Dim rwU As DataRow
    '                        Dim obj(tb.PrimaryKey.GetUpperBound(0)) As Object
    '                        Dim nTCleName(1) As String
    '                        Dim cl As DataColumn
    '                        Dim i As Integer = 0
    '                        For Each cl In tb.PrimaryKey
    '                            obj.SetValue(rwi.Item(cl.ColumnName), i)
    '                            nTCleName(i) = cl.ColumnName
    '                            i += 1
    '                        Next
    '                        rwU = tb.Rows.Find(obj)
    '                        For Each cl In tb.Columns
    '                            If cl.Expression = "" Then
    '                                If cl.ColumnName <> nTCleName(0) And cl.ColumnName <> nTCleName(1) Then
    '                                    rwU.Item(cl.ColumnName) = rwi.Item(cl.ColumnName)
    '                                End If
    '                            End If
    '                        Next
    '                    Next

    '                    '* Liste des personnes supprimées dans cette périodes et furent insérées précédament
    '                    '* Liste des personne à supprimées
    '                    tbDeleted = New DataTable
    '                    strSqlLstPersonneDelete = "Select " & strCleAs & " From Transactions " & _
    '                    "Where  Transactions.nCleTrans Not in (Select nCleTrans From Transactions Where (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And (ActionTrans='INSERTED')) " & _
    '                    "And (nTrans>" & nbLastConnection.ToString & " And nTrans<=" & nMaxTrans & ") And TableTrans='" & tb.TableName & "' And ActionTrans='DELETED' And idUser<>CURRENT_USER"

    '                    dtAPersonne = New SqlClient.SqlDataAdapter(strSqlLstPersonneAvDelete, cn)

    '                    dtAPersonne.Fill(tbDeleted)

    '                    For Each rwi In tbDeleted.Rows
    '                        Dim obj(tb.PrimaryKey.GetUpperBound(0)) As Object
    '                        Dim cl As DataColumn
    '                        Dim i As Integer = 0
    '                        For Each cl In tb.PrimaryKey
    '                            obj.SetValue(rwi.Item(cl.ColumnName), i)
    '                            i += 1
    '                        Next
    '                        tb.Rows.Find(obj).Delete()
    '                    Next
    '                End If
    '            Next

    '            If cn.State <> ConnectionState.Closed Then
    '                cn.Close()
    '            End If

    '            If Not dsModif.GetChanges Is Nothing Then
    '                Dim strTmp As String
    '                Dim strBuilder As New System.Text.StringBuilder
    '                Dim memWriter As New System.IO.StringWriter(strBuilder)
    '                Dim xmlWriter As New System.Xml.XmlTextWriter(memWriter)
    '                dsModif.WriteXml(xmlWriter, XmlWriteMode.DiffGram)

    '                strTmp = CrypteString(strBuilder.ToString)

    '                strBuilder = New System.Text.StringBuilder
    '                memWriter = New System.IO.StringWriter(strBuilder)
    '                xmlWriter = New System.Xml.XmlTextWriter(memWriter)

    '                dsModif.WriteXmlSchema(xmlWriter)

    '                XmlSchema = CrypteString(strBuilder.ToString)

    '                nbLastConnection = nMaxTrans

    '                Return strTmp
    '            Else

    '                nbLastConnection = nMaxTrans

    '                Return ""
    '            End If
    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try


    '        'Me.DataGrid1.DataSource = dsModif.GetChanges

    '    End Function

    '    Public Shared Function SynchroDonnees(ByVal strConnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByRef strDonnees As String, ByRef strLstErreur As String, ByVal ServerFileSchemaActuel As String, Optional ByVal SynchroPartiel As Boolean = True) As String
    '        Dim dsAvMAJ As New DataSet
    '        Dim dsApMAJ As New DataSet
    '        Dim mDaT As New Donnees.ConfigurationSqlServer
    '        Dim cn As New SqlClient.SqlConnection(strConnexion)

    '        Try
    '            cn.Open()
    '        Catch ex As Exception
    '            Return CrypteString(ex.Message)
    '        End Try

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsAvMAJ, ServerFileSchemaActuel)
    '        Dim str As New System.IO.StringReader(ServerFileSchemaActuel)
    '        dsAvMAJ.ReadXmlSchema(str)

    '        Dim strDonneesDepart As String = Actigram.Securite.SecuriteConverter.DeCrypteString(strDonnees)
    '        Dim memReader As New System.IO.StringReader(strDonneesDepart)
    '        Dim xmlReader As New System.Xml.XmlTextReader(memReader)
    '        dsAvMAJ.ReadXml(xmlReader)

    '        mDaT.Connexion = cn
    '        mDaT.Dataset = dsAvMAJ
    '        mDaT.ChargeDonneesFromSchema(False, SynchroPartiel)
    '        strLstErreur = mDaT.UpdateAdapters(ConfigurationSqlServer.MethodeUpdate.Insert)

    '        'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsApMAJ, ServerFileSchemaActuel)
    '        str = New System.IO.StringReader(ServerFileSchemaActuel)
    '        dsApMAJ.ReadXmlSchema(str)

    '        mDaT = New Donnees.ConfigurationSqlServer
    '        mDaT.Connexion = cn
    '        mDaT.Dataset = dsApMAJ
    '        mDaT.ChargeDonneesFromSchema(True)
    '        Dim strTmp As String
    '        strTmp = Actigram.Securite.SecuriteConverter.CrypteString(dsApMAJ.GetXml)

    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '        End If

    '        Return strTmp
    '    End Function

    'End Class

    Public Class GestionBaseSql

        'Public Shared Function CreerDeclencheurs(ByVal strConnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByVal ServerFileSchemaActuel As String) As String

        '    Dim strSql As String = ""
        '    Dim strMessage As String = ""

        '    'Dim cn As New SqlClient.SqlConnection(strConnexion)
        '    'Dim cn As New SqlClient.SqlConnection(strConnexion.Replace("Utilisateur", DeCrypteString(Utilisateur)).Replace("Pwd", DeCrypteString(MotPasse)))
        '    Dim cn As New SqlClient.SqlConnection(strConnexion.Replace("Utilisateur", Utilisateur).Replace("Pwd", MotPasse))
        '    Dim nCleName As String
        '    Dim tb As DataTable
        '    Dim cmd As New SqlClient.SqlCommand(strSql, cn)
        '    Dim dsModif As New DataSet

        '    'Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(dsModif, ServerFileSchemaActuel)
        '    Dim str As New System.IO.StringReader(ServerFileSchemaActuel)
        '    dsModif.ReadXmlSchema(str)

        '    tb = dsModif.Tables("Entreprise")
        '    nCleName = "nEntreprise"

        '    Try
        '        cn.Open()
        '    Catch ex As Exception
        '        strMessage += ex.Message
        '        'Return ex.Message
        '    End Try


        '    'strSql = "IF EXISTS (Select name From sysobjects where name='Trig_SupprCascade_Personne' and type='TR')" & vbCrLf
        '    'strSql += "Drop Trigger [Trig_SupprCascade_Personne]" & vbCrLf

        '    'cmd.CommandText = strSql
        '    'Try
        '    '    cmd.ExecuteNonQuery()
        '    'Catch ex As Exception
        '    '    MsgBox(ex.Message)
        '    'End Try


        '    'strSql = "CREATE TRIGGER [Trig_SupprCascade_Personne] ON [Personne] " & vbCrLf
        '    'strSql += "FOR DELETE " & vbCrLf
        '    'strSql += "AS " & vbCrLf
        '    'strSql += vbCrLf
        '    'strSql += "Delete From Adresse Where nPersonne in (Select nPersonne From deleted)"

        '    'cmd.CommandText = strSql
        '    'Try
        '    '    cmd.ExecuteNonQuery()
        '    'Catch ex As Exception
        '    '    MsgBox(ex.Message)
        '    'End Try


        '    For Each tb In dsModif.Tables
        '        If tb.PrimaryKey.GetUpperBound(0) >= 0 Then

        '            Dim strCleSelect As String = ""
        '            Dim strCleInto As String = ""

        '            Dim cle As DataColumn
        '            Dim iCle As Integer = 0
        '            Dim striCle As String = ""

        '            For Each cle In tb.PrimaryKey
        '                If iCle = 0 Then
        '                    striCle = ""
        '                Else
        '                    striCle = iCle.ToString
        '                End If
        '                If strCleSelect.Length > 0 Then
        '                    strCleSelect += ","
        '                    strCleInto += ","
        '                End If
        '                strCleSelect += "inserted.[" & cle.ColumnName & "]"
        '                strCleInto += "Transactions.nCleTrans" & striCle
        '                iCle += 1
        '            Next

        '            'strCleOn = "(" & strCleOn & ")"
        '            'strCleIn = "(" & strCleIn & ")"

        '            strSql = "IF EXISTS (Select name From sysobjects where name='Trig_General_" & tb.TableName & "' and type='TR')" & vbCrLf
        '            strSql += "Drop Trigger [Trig_General_" & tb.TableName & "]" & vbCrLf

        '            cmd.CommandText = strSql
        '            Try
        '                cmd.ExecuteNonQuery()
        '            Catch ex As Exception
        '                If strMessage.Length > 0 Then
        '                    strMessage += "****Fin****"
        '                End If
        '                strMessage += ex.Message
        '                'Return ex.Message
        '            End Try


        '            strSql = "CREATE TRIGGER [Trig_General_" & tb.TableName & "] ON [" & tb.TableName & "] " & vbCrLf
        '            strSql += "FOR INSERT, DELETE " & vbCrLf
        '            strSql += "AS " & vbCrLf
        '            strSql += vbCrLf
        '            strSql += "Select " & strCleSelect & " From inserted " & vbCrLf
        '            strSql += vbCrLf
        '            strSql += "INSERT INTO Transactions (Transactions.idUser,Transactions.TableTrans,Transactions.ActionTrans," & strCleInto & ") " & vbCrLf
        '            strSql += "select  CURRENT_USER,'" & tb.TableName & "','INSERTED'," & strCleSelect & " From inserted " & vbCrLf
        '            strSql += vbCrLf
        '            strSql += "Select " & strCleSelect.Replace("inserted", "deleted") & " From deleted " & vbCrLf
        '            strSql += vbCrLf
        '            strSql += "INSERT INTO Transactions (Transactions.idUser,Transactions.TableTrans,Transactions.ActionTrans," & strCleInto & ") " & vbCrLf
        '            strSql += "select  CURRENT_USER,'" & tb.TableName & "','DELETED'," & strCleSelect.Replace("inserted", "deleted") & " From deleted"

        '            cmd.CommandText = strSql
        '            Try
        '                cmd.ExecuteNonQuery()
        '            Catch ex As Exception
        '                If strMessage.Length > 0 Then
        '                    strMessage += "****Fin****"
        '                End If
        '                strMessage += ex.Message
        '                'Return ex.Message
        '            End Try

        '            strSql = "IF EXISTS (Select name From sysobjects where name='Trig_General_" & tb.TableName & "' and type='TR')" & vbCrLf
        '            strSql += "Drop Trigger [Trig_Update_" & tb.TableName & "]" & vbCrLf

        '            cmd.CommandText = strSql
        '            Try
        '                cmd.ExecuteNonQuery()
        '            Catch ex As Exception
        '                If strMessage.Length > 0 Then
        '                    strMessage += "****Fin****"
        '                End If
        '                strMessage += ex.Message
        '                'Return ex.Message
        '            End Try


        '            strSql = "CREATE TRIGGER [Trig_Update_" & tb.TableName & "] ON [" & tb.TableName & "] " & vbCrLf
        '            strSql += "FOR UPDATE " & vbCrLf
        '            strSql += "AS " & vbCrLf
        '            strSql += "Select " & strCleSelect & " From inserted " & vbCrLf
        '            strSql += vbCrLf
        '            strSql += "INSERT INTO Transactions (Transactions.idUser,Transactions.TableTrans,Transactions.ActionTrans," & strCleInto & ") " & vbCrLf
        '            strSql += "select  CURRENT_USER,'" & tb.TableName & "','UPDATED'," & strCleSelect & " From inserted"

        '            cmd.CommandText = strSql
        '            Try
        '                cmd.ExecuteNonQuery()
        '            Catch ex As Exception
        '                If strMessage.Length > 0 Then
        '                    strMessage += "****Fin****"
        '                End If
        '                strMessage += ex.Message
        '                'Return ex.Message
        '            End Try
        '        End If
        '    Next

        '    If cn.State <> ConnectionState.Open Then
        '        cn.Close()
        '        'Return ""
        '    End If

        '    Return strMessage

        'End Function

        Public Shared Function GetInnerJoinPartiel(ByVal strTable As String, Optional ByVal Utilisateur As String = "") As String
            Dim strTableListeEntreprise As String = ""
            If Utilisateur <> "" Then
                strTableListeEntreprise = " [ListeEntreprise" & Utilisateur & "] "
            Else
                strTableListeEntreprise = " GetListeEntreprise(null) "
            End If
            Select Case strTable
                Case "Entreprise"
                    Return " Inner Join (Select nEntreprise From " & strTableListeEntreprise & ") as Selection On " & strTable & ".nEntreprise=Selection.nEntreprise "
                Case "Evenement"
                    Return " Inner Join (Select Distinct EvenementPersonne.nEvenement From EvenementPersonne Inner Join (Select nEntreprise,null as nPersonne From " & strTableListeEntreprise & " Union Select null,nPersonne From Personne Inner Join " & strTableListeEntreprise & " As ListeEntreprise On Personne.nEntreprise=ListeEntreprise.nEntreprise Union Select null,nPersonne From Utilisateurs) AS Selection On (EvenementPersonne.nEntreprise=Selection.nEntreprise Or EvenementPersonne.nPersonne=Selection.nPersonne)) As SelectionEv On Evenement.nEvenement=SelectionEv.nEvenement "
                Case "EvenementPiece"
                    Return " Inner Join (Select Distinct EvenementPersonne.nEvenement From EvenementPersonne Inner Join (Select nEntreprise,null as nPersonne From " & strTableListeEntreprise & " Union Select null,nPersonne From Personne Inner Join " & strTableListeEntreprise & " As ListeEntreprise On Personne.nEntreprise=ListeEntreprise.nEntreprise Union Select null,nPersonne From Utilisateurs) AS Selection On (EvenementPersonne.nEntreprise=Selection.nEntreprise Or EvenementPersonne.nPersonne=Selection.nPersonne)) As SelectionEv On EvenementPiece.nEvenement=SelectionEv.nEvenement "
                Case "EvenementPersonne"
                    Return " Inner Join (Select nEntreprise,null as nPersonne From " & strTableListeEntreprise & " Union Select null,nPersonne From Personne Inner Join " & strTableListeEntreprise & " As ListeEntreprise On Personne.nEntreprise=ListeEntreprise.nEntreprise Union Select null,nPersonne From Utilisateurs) AS Selection On (EvenementPersonne.nEntreprise=Selection.nEntreprise Or EvenementPersonne.nPersonne=Selection.nPersonne)"
                    'Return " Inner Join (Select nEntreprise,null as nPersonne From " & strTableListeEntreprise & " Union Select null,nPersonne From Personne Where nEntreprise In (Select nEntreprise From " & strTableListeEntreprise & ") Union Select null,nPersonne From Utilisateurs) AS Selection On (EvenementPersonne.nEntreprise=Selection.nEntreprise Or EvenementPersonne.nPersonne=Selection.nPersonne)"
                    'Return " Where nEntreprise in (Select nEntreprise From " & strTableListeEntreprise & ") Or nPersonne in (Select nPersonne From Personne Inner Join (Select nEntreprise From " & strTableListeEntreprise & ") As Selection On Personne.nEntreprise=Selection.nEntreprise)  "
                Case "Personne"
                    Return " Inner Join (Select nPersonne From Personne Where nEntreprise In (Select nEntreprise From " & strTableListeEntreprise & ") Union Select nPersonne From Utilisateurs) As Selection On Personne.nPersonne=Selection.nPersonne "
                    'Return " Where nEntreprise in (Select nEntreprise From " & strTableListeEntreprise & ") or nPersonne In (Select nPersonne From Utilisateurs) "
                Case "Telephone"
                    Return " Inner Join (Select nPersonne From Personne Where nEntreprise  In (Select nEntreprise From " & strTableListeEntreprise & ") Or nPersonne In (Select nPersonne From Utilisateurs)) As Selection1 On " & strTable & ".nPersonne=Selection1.nPersonne "
                Case "TelephoneEntreprise"
                    Return " Inner Join (Select nEntreprise From " & strTableListeEntreprise & ") as Selection On " & strTable & ".nEntreprise=Selection.nEntreprise "
                Case "Devis"
                    Return " Inner Join (Select nEntreprise From " & strTableListeEntreprise & ") As Selection On " & strTable & ".nClient=Selection.nEntreprise "
                    'Return " Where nEntreprise In (Select nEntreprise From " & strTableListeEntreprise & ")"
                Case "DetailDevis"
                    Return " Inner Join (Select nDevis From Devis Inner Join (Select nEntreprise From " & strTableListeEntreprise & ") as Selection On Devis.nClient=Selection.nEntreprise) As Selection1 On DetailDevis.nDevis=Selection1.nDevis"
                Case Else
                    Return ""
            End Select
        End Function

    End Class

    'Public Class UpDateFunction

    '    Shared Function UpLoadFichierJoint(ByVal strConnexion As String, ByVal CheminFichier As String, ByVal Fichier As String) As String
    '        Dim cn As New SqlClient.SqlConnection(strConnexion)
    '        Try
    '            cn.Open()
    '            cn.Close()

    '            Actigram.Fichiers.ManipulationFichier.Base64ToFichier(Fichier, CheminFichier)

    '        Catch ex As Exception
    '            Return ex.Message & vbCrLf & ex.StackTrace
    '        End Try
    '    End Function

    '    Shared Function DownloadFichierJoint(ByVal strConnexion As String, ByVal CheminFichier As String) As String
    '        Dim cn As New SqlClient.SqlConnection(strConnexion)
    '        Try
    '            cn.Open()
    '            cn.Close()

    '            Return Actigram.Fichiers.ManipulationFichier.FichierToBase64(CheminFichier)

    '        Catch ex As Exception
    '            Return ex.Message & vbCrLf & ex.StackTrace
    '        End Try
    '    End Function

    '    Shared Function UpLoadFichier(ByVal nVersion As String, ByVal NomFichier As String, ByVal strConnexion As String, ByVal Fichier As String) As String

    '        Dim cn As New SqlClient.SqlConnection(strConnexion)
    '        Try
    '            cn.Open()

    '            Dim ds As New DataSet

    '            Dim dtA As New SqlClient.SqlDataAdapter("Select * From UpDateFichier", cn)
    '            Dim CmdBuild As New SqlClient.SqlCommandBuilder(dtA)
    '            dtA.UpdateCommand = CmdBuild.GetUpdateCommand
    '            dtA.InsertCommand = CmdBuild.GetInsertCommand
    '            dtA.DeleteCommand = CmdBuild.GetDeleteCommand

    '            dtA.Fill(ds)

    '            Dim rw() As DataRow = ds.Tables(0).Select("NomFichier='" & NomFichier & "'")
    '            If rw.GetUpperBound(0) >= 0 Then
    '                rw(0).Item("nVersion") = nVersion
    '                rw(0).Item("Fichier") = Fichier
    '            Else
    '                Dim rwN As DataRow
    '                rwN = ds.Tables(0).NewRow
    '                rwN.Item("nVersion") = nVersion
    '                rwN.Item("NomFichier") = NomFichier
    '                rwN.Item("Fichier") = Fichier
    '                ds.Tables(0).Rows.Add(rwN)
    '            End If

    '            dtA.Update(ds)

    '            'Dim strUpDate As String

    '            'Dim cmd As New SqlClient.SqlCommand("Update UpDateFichier Set nVersion='" & nVersion & "', Fichier='" & Fichier & "' Where NomFichier='" & NomFichier & "'", cn)
    '            'If cmd.ExecuteNonQuery() = 0 Then
    '            '    cmd.CommandText = "Insert Into UpdateFichier (nVersion,NomFichier) values ('" & nVersion & "','" & NomFichier & "')"
    '            '    cmd.ExecuteNonQuery()
    '            '    cmd.CommandText = "Update UpDateFichier Set nVersion='" & nVersion & "', Fichier='" & Fichier & "' Where NomFichier='" & NomFichier & "'"
    '            '    cmd.ExecuteNonQuery()
    '            'End If

    '        Catch ex As Exception
    '            Return ex.Message & vbCrLf & ex.StackTrace
    '        Finally
    '            If cn.State <> ConnectionState.Closed Then
    '                cn.Close()
    '            End If
    '        End Try

    '    End Function

    '    Shared Function VerifUpDateDispo(ByVal nVersion As String, ByVal NomFichier As String, ByVal strConnexion As String) As Boolean
    '        Dim cn As New SqlClient.SqlConnection(strConnexion)
    '        Try
    '            cn.Open()

    '            Dim cmd As New SqlClient.SqlCommand("Select max(nVersion) From UpDateFichier Where nVersion>'" & nVersion & "' And NomFichier='" & NomFichier & "'", cn)

    '            Dim obj As Object

    '            obj = cmd.ExecuteScalar

    '            If Not obj Is DBNull.Value Then
    '                Return True
    '            End If

    '        Catch ex As Exception
    '        Finally
    '            If cn.State <> ConnectionState.Closed Then
    '                cn.Close()
    '            End If
    '        End Try

    '    End Function

    '    Shared Function VerifUpDate(ByVal nVersion As String, ByVal NomFichier As String, ByVal strConnexion As String) As DataSet
    '        Dim cn As New SqlClient.SqlConnection(strConnexion)
    '        Try
    '            cn.Open()

    '            Dim cmd As New SqlClient.SqlCommand("Select max(nVersion) From UpDateFichier Where nVersion>'" & nVersion & "' And NomFichier='" & NomFichier & "'", cn)

    '            Dim obj As Object

    '            obj = cmd.ExecuteScalar

    '            If Not obj Is DBNull.Value Then
    '                Dim ds As New DataSet
    '                Dim dta As New SqlClient.SqlDataAdapter("Select * From UpDateFichier", cn)
    '                dta.Fill(ds)
    '                Return ds
    '                'cmd.CommandText = "Select Fichier From UpDateFichier Where nVersion='" & Convert.ToString(obj) & "' And NomFichier='" & NomFichier & "'"
    '                ''Dim cmdFichier As New SqlClient.SqlCommand("Selet Fichier From UpDateFichier Where nVersion='" & Convert.ToString(obj) & "' And NomFichier='" & NomFichier & "'", cn)
    '                ''Return Convert.ToString(cmdFichier.ExecuteScalar)
    '                'Return Convert.ToString(cmd.ExecuteScalar)
    '                'Else
    '                '    Return ""
    '            End If

    '        Catch ex As Exception
    '            'Return ex.Message
    '        Finally
    '            If cn.State <> ConnectionState.Closed Then
    '                cn.Close()
    '            End If
    '        End Try

    '    End Function
    'End Class

    'Public Class GestionFacture

    '    Public Shared Function GetNFacture(ByVal strConnexion As String, ByVal Utilisateur As String, ByVal MotPasse As String, ByVal nbFacture As Long, ByVal Annee As Integer, ByRef nFactureDepart As Long) As String

    '        Dim User As String = Actigram.Securite.SecuriteConverter.DeCrypteString(Utilisateur)
    '        Dim Pwd As String = Actigram.Securite.SecuriteConverter.DeCrypteString(MotPasse)

    '        Dim cn As New SqlClient.SqlConnection(strConnexion.Replace("Utilisateur", User).Replace("Pwd", Pwd))

    '        Try
    '            cn.Open()
    '        Catch ex As Exception
    '            Return ex.Message & vbCrLf & cn.ConnectionString
    '        End Try

    '        Try
    '            Dim nMaxFacture As Object
    '            Dim strSql As String = ""
    '            strSql = "Select Max(NFacture) From NFacture Where Annee=" & Annee
    '            Dim cmd As New SqlClient.SqlCommand(strSql, cn)

    '            nMaxFacture = cmd.ExecuteScalar

    '            If nMaxFacture Is DBNull.Value Then
    '                nMaxFacture = 1
    '            End If
    '            Dim nFact As Long
    '            Dim nFacture As Long = Convert.ToInt64(nMaxFacture)
    '            For nFact = 1 To nbFacture
    '                nFacture += 1
    '                cmd.CommandText = "Insert Into NFacture (Annee,NFacture) Values (" & Annee & "," & nFacture & ")"
    '                cmd.ExecuteNonQuery()
    '            Next

    '            nFactureDepart = Convert.ToInt64(nMaxFacture) + 1

    '            Return "Ok"

    '        Catch ex As Exception
    '            Return ex.Message
    '        Finally
    '            If cn.State = ConnectionState.Open Then
    '                cn.Close()
    '            End If
    '        End Try


    '    End Function

    'End Class

End Namespace
