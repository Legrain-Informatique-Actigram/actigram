Imports System.Data.SqlClient

Public Class FrRequete
    Inherits System.Windows.Forms.Form

    Private conn As SqlProxy
    Private connString As String

    Private Sub FrRequete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.DgResults)
        ChargerParametres()

        status.Text = "Non connecté"
        status2.Text = ""

        TxRequete.Text = ""
        TvObjects.Nodes.Clear()

        MajBoutons()
    End Sub

    Private Sub FrRequete_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not conn Is Nothing Then conn.Close()
    End Sub

#Region "Evenements GUI"

    Private Sub TbScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirFichierSQLToolStripMenuItem.Click
        With openDialog
            .Filter = "Fichiers SQL (*.sql)|*.sql"
            .FilterIndex = 0
            .Title = "Sélectionnez le script SQL à charger"
            .DefaultExt = "sql"
            If .ShowDialog = DialogResult.OK Then
                ChargerScript(.FileName)
            End If
        End With
        MajBoutons()
    End Sub

    Private Sub TbSaveSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerLaRequêteToolStripMenuItem.Click
        With saveDialog
            .FileName = ""
            .Filter = "Fichiers SQL (*.sql)|*.sql"
            .FilterIndex = 0
            .Title = "Sélectionnez l'emplacement de sauvegarde du script SQL"
            .DefaultExt = "sql"
            If .ShowDialog = DialogResult.OK Then
                EnregistrerScript(.FileName)
            End If
        End With
    End Sub

    Private Sub TbExporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterRésultatsToolStripMenuItem.Click
        Exporter()
        MajBoutons()
    End Sub


    Private Sub EnregistrerMessagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerMessagesToolStripMenuItem.Click
        With saveDialog
            .FileName = ""
            .Filter = "Fichiers texte (*.txt)|*.txt"
            .FilterIndex = 0
            .Title = "Sélectionnez l'emplacement de sauvegarde des messages"
            .DefaultExt = "txt"
            If .ShowDialog = DialogResult.OK Then
                EnregistrerMessages(.FileName)
            End If
        End With
    End Sub

    Private Sub TxRequete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRequete.KeyPress
        'Gérer le Ctrl+A
        If Asc(e.KeyChar) = 1 And Form.ModifierKeys = Keys.Control Then
            TxRequete.SelectAll()
            e.Handled = True
        End If
    End Sub

    'Private Sub FrRequete_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
    '    If e.KeyCode = Keys.F5 Then
    '        BtQuery_Click(Nothing, Nothing)
    '    End If
    'End Sub

    Private Sub TvObjects_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TvObjects.MouseDown
        Dim node As TreeNode = TvObjects.GetNodeAt(e.X, e.Y)
        If Not node Is Nothing Then TvObjects.SelectedNode = node
    End Sub

    Private Sub TvObjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TvObjects.DoubleClick
        mnuDesc.PerformClick()
    End Sub

    Private Sub Tx_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles TxRequete.TextChanged
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        'Liés à la connexion
        TxRequete.Enabled = Not conn Is Nothing
        TvObjects.Enabled = Not conn Is Nothing
        OuvrirFichierSQLToolStripMenuItem.Enabled = Not conn Is Nothing
        SauvegarderLaBaseToolStripMenuItem.Enabled = Not conn Is Nothing
        RestaurerUneBaseToolStripMenuItem.Enabled = Not conn Is Nothing

        'Liés à la requête
        SplitExec.Enabled = TxRequete.Text.Trim.Length > 0
        RequêteToolStripMenuItem.Enabled = TxRequete.Text.Trim.Length > 0
        EnregistrerLaRequêteToolStripMenuItem.Enabled = TxRequete.Text.Trim.Length > 0

        'Liés aux résultats
        ExporterRésultatsToolStripMenuItem.Enabled = Not DgResults.DataSource Is Nothing
        EnregistrerMessagesToolStripMenuItem.Enabled = txMessages.Text.Trim.Length > 0
    End Sub
#End Region

#Region "Connexion"
    Private Sub ChargerParametres(Optional ByVal forceChoixDossier As Boolean = False)
        Try
            Cursor.Current = Cursors.WaitCursor

            connString = My.Settings.ConnString

            Dim choixDossier As Boolean = True
            If Not forceChoixDossier Then
                If My.Application.CommandLineArgs.Count > 0 Then
                    Dim sb As New SqlClient.SqlConnectionStringBuilder
                    For Each param As CommandParam In CommandParam.Parse(My.Application.CommandLineArgs)
                        Select Case param.Name
                            Case "-server" : sb.DataSource = param.Value
                            Case "-base" : sb.InitialCatalog = param.Value
                            Case "-pwd" : sb.Password = param.Value
                            Case "-login" : sb.UserID = param.Value
                        End Select
                    Next
                    If sb.DataSource.Length > 0 OrElse sb.InitialCatalog.Length > 0 Then
                        choixDossier = False
                    Else
                        sb.IntegratedSecurity = (sb.UserID.Length = 0)
                        connString = sb.ConnectionString
                    End If
                End If
            End If

            If choixDossier Then
                If ParametresApplication.ChargerParametres(, FormStartPosition.CenterScreen) = Windows.Forms.DialogResult.OK Then
                    Dim sb As New SqlClient.SqlConnectionStringBuilder
                    With sb
                        .DataSource = CStr(ParametresApplication.ValeurParametre("ServeurSQL", ".\AGRIFACT"))
                        .InitialCatalog = CStr(ParametresApplication.ValeurParametre("BASESQL", "Agrifact"))
                        .IntegratedSecurity = False
                        .UserID = "sa"
                        .Password = CStr(ParametresApplication.ValeurParametre("saPwd", "ludo"))
                    End With
                    connString = sb.ConnectionString
                End If
            End If
        Catch ex As Exception
            AppendMessage(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConnect.ButtonClick
        If conn Is Nothing Then
            Try
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()

                'Trouver la chaine de connexion
                Using fr As New FrParametres(connString)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    connString = fr.ConnectionString
                End Using

                Application.DoEvents()

                Dim cn As New SqlProxy(connString) 'Essaie automatiquement d'ouvrir la connexion, donc permet de tester la chaine
                SqlProxy.SetDefaultConnection(connString)
                conn = cn
                conn.ExecuteNonQuery("SET DATEFORMAT dmy")
                AddHandler conn.Connection.InfoMessage, AddressOf ConnectionMessage
                Dim sb As New SqlClient.SqlConnectionStringBuilder(conn.ConnectionString)
                If sb.IntegratedSecurity Then
                    status.Text = String.Format("Connecté à la base {0} sur le serveur {1}", sb.InitialCatalog, sb.DataSource)
                Else
                    status.Text = String.Format("Connecté en tant que {0} à la base {1} sur le serveur {2}", sb.UserID, sb.InitialCatalog, sb.DataSource)
                End If

                Remplirobjects()
                BtConnect.Text = "Déconnexion"
                BtConnect.Image = My.Resources.disconnect

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        Else
            conn = Nothing
            TvObjects.Nodes.Clear()
            status.Text = "Non connecté"
            BtConnect.Text = "Connexion"
            BtConnect.Image = My.Resources.connect
        End If
        MajBoutons()
    End Sub

    Private Sub Remplirobjects()
        If conn Is Nothing Then Exit Sub

        TvObjects.BeginUpdate()
        TvObjects.Nodes.Clear()

        Dim nodeBase As TreeNode = TvObjects.Nodes.Add(conn.Connection.Database)
        With nodeBase
            .Tag = "DB"
            .ImageKey = "db"
            .SelectedImageKey = "db"
        End With
        'Chargement des tables
        Dim nodeTbls As TreeNode = Remplirobjects(nodeBase, "Tables", "U", "TBL", "table")
        'Chargement des Vues
        Remplirobjects(nodeBase, "Vues", "V", "VW", "vue")
        'Chargement des Procstock
        Remplirobjects(nodeBase, "Procédures", "P", "PROC", "proc")

        nodeBase.Expand()
        nodeTbls.Expand()

        TvObjects.EndUpdate()
    End Sub

    Private Function RemplirObjects(ByVal nodeBase As TreeNode, ByVal title As String, ByVal typeObjet As String, ByVal tag As String, ByVal imageKey As String) As TreeNode
        'Noeud dossier
        Dim nodeFolder As TreeNode = nodeBase.Nodes.Add(title)
        With nodeFolder
            .Tag = tag & "S"
            .ImageKey = "folder"
            .SelectedImageKey = "folder"
        End With
        'Trouver les objets
        Dim sql As String
        If typeObjet = "U" Then
            sql = String.Format("select name from sysobjects where xtype='{0}' order by name", typeObjet)
        Else
            sql = String.Format("select name from sysobjects where xtype='{0}' and category=0 order by name", typeObjet)
        End If
        Using dr As SqlDataReader = conn.ExecuteReader(sql)
            While dr.Read
                'Creer les noeuds
                Dim node As TreeNode = nodeFolder.Nodes.Add(CStr(dr("name")))
                With node
                    .Tag = tag
                    .ImageKey = imageKey
                    .SelectedImageKey = imageKey
                End With
            End While
        End Using
        Return nodeFolder
    End Function
#End Region

#Region "Menu contextuel"
    Private Sub MenuItemsEnabled(ByVal enabled As Boolean)
        For Each mnu As ToolStripItem In ctxObjets.Items
            If TypeOf mnu Is ToolStripMenuItem Then mnu.Enabled = enabled
        Next
    End Sub

    Private Sub ctxObjets_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxObjets.Opened
        If TvObjects.SelectedNode Is Nothing Then
            ctxObjets.Enabled = False
        Else
            ctxObjets.Enabled = True
            Select Case CStr(TvObjects.SelectedNode.Tag)
                Case "TBLS", "VWS", "PROCS", "DB"
                    ctxObjets.Enabled = False
                Case "TBL"
                    MenuItemsEnabled(True)
                    mnuExec.Enabled = False
                    mnuAlter.Enabled = False
                Case "VW"
                    MenuItemsEnabled(False)
                    mnuSelect.Enabled = True
                    mnuAlter.Enabled = True
                Case "PROC"
                    MenuItemsEnabled(False)
                    mnuExec.Enabled = True
                    mnuAlter.Enabled = True
            End Select
        End If
    End Sub

    Private Sub mnuRequete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles mnuAlter.Click, mnuDelete.Click, mnuDesc.Click, mnuInsert.Click, mnuSelect.Click, mnuUpdate.Click, mnuExec.Click
        If TvObjects.SelectedNode Is Nothing Then Exit Sub
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim typeObjet As String = CStr(TvObjects.SelectedNode.Tag)
            Dim nomObjet As String = TvObjects.SelectedNode.Text
            If sender Is mnuSelect AndAlso (typeObjet = "TBL" Or typeObjet = "VW") Then
                TxRequete.Text = SelectQuery(nomObjet)
                RequêteToolStripMenuItem.PerformClick()
            ElseIf sender Is mnuUpdate AndAlso typeObjet = "TBL" Then
                TxRequete.Text = UpdateQuery(nomObjet)
            ElseIf sender Is mnuInsert AndAlso typeObjet = "TBL" Then
                TxRequete.Text = InsertQuery(nomObjet)
            ElseIf sender Is mnuDelete AndAlso typeObjet = "TBL" Then
                TxRequete.Text = DeleteQuery(nomObjet)
            ElseIf sender Is mnuDesc Then
                Description(typeObjet, nomObjet)
            ElseIf sender Is mnuAlter AndAlso (typeObjet = "PROC" Or typeObjet = "VW") Then
                TxRequete.Text = AlterQuery(typeObjet, nomObjet)
            ElseIf sender Is mnuExec AndAlso typeObjet = "PROC" Then
                TxRequete.Text = ExecQuery(nomObjet)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Génération SQL"

    Private Sub Description(ByVal typeObjet As String, ByVal nomObjet As String)
        'Préparer la table des colonnes
        Dim dtCols As DataTable
        If typeObjet = "TBL" Or typeObjet = "VW" Then
            dtCols = conn.ExecuteDataTable(String.Format("exec sp_columns '{0}'", nomObjet))
            dtCols.TableName = "Desc"
        ElseIf typeObjet = "PROC" Then
            dtCols = conn.ExecuteDataTable(String.Format("SELECT * FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = N'{0}'", nomObjet))
            dtCols.TableName = "DescProc"
        End If

        If dtCols IsNot Nothing Then
            Dim dvCols As New DataView(dtCols, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)
            'Appel à FrColonnes
            Dim fr As New FrColonnes(dvCols)
            fr.ShowDialog()
        End If
    End Sub

    Private Function AlterQuery(ByVal typeObjet As String, ByVal nomObjet As String) As String
        Dim res As String = ""
        Select Case typeObjet
            Case "PROC", "VW"
                Dim searchString As String = "x%£x"
                Dim replaceString As String = "x%£x"
                If typeObjet = "PROC" Then
                    searchString = "CREATE PROC"
                    replaceString = "ALTER PROC"
                ElseIf typeObjet = "VW" Then
                    searchString = "CREATE VIEW"
                    replaceString = "ALTER VIEW"
                End If
                Dim def As New System.Text.StringBuilder
                Using dr As SqlDataReader = conn.ExecuteReader(SqlProxy.FormatSql("select text from syscomments c inner join sysobjects o on c.id=o.id where o.name={0} order by colid", nomObjet))
                    While dr.Read
                        Dim s As String = Convert.ToString(dr("text"))
                        Dim i As Integer = s.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase)
                        If i >= 0 Then
                            s = s.Replace(s.Substring(i, searchString.Length), replaceString)
                        End If
                        def.Append(s)
                    End While
                End Using
                res = def.ToString
        End Select
        Return res
    End Function

#Region " Requêtes Table "
    Private Function SelectQuery(ByVal nomTable As String) As String
        'Préparer la table des colonnes pour l'aide à la sélection
        Dim dtCols As DataTable = conn.ExecuteDataTable("exec sp_columns '" & nomTable & "'")
        dtCols.TableName = "SelectQuery"
        With dtCols.Columns
            .Add("Select", GetType(Boolean))
            .Add("Operator", GetType(String))
            .Add("Where", GetType(String))
        End With
        For Each dr As DataRow In dtCols.Rows
            dr("Select") = True
            dr("Operator") = "="
            dr("Where") = ""
        Next
        Dim dvCols As New DataView(dtCols, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)

        'Appel à FrColonnes pour déterminer les colonnes à Sélectionner
        Dim fr As New FrColonnes(dvCols)
        If fr.ShowDialog = DialogResult.Cancel Then Return ""

        'Déterminer la chaine SELECT
        dvCols.RowFilter = "Select=True"
        Dim strSelect As String
        If dvCols.Count = 0 Then
            Return ""
        ElseIf dvCols.Count = dtCols.Rows.Count Then
            strSelect = "*"
        Else
            Dim cols As New ArrayList
            For Each drv As DataRowView In dvCols
                cols.Add(String.Format("[{0}]", drv("COLUMN_NAME")))
            Next
            strSelect = Join(cols, ",")
        End If

        'Déterminer la chaine WHERE
        Dim strWhere As String = WhereClause(dvCols)

        'Retourner la requête finale
        Return String.Format("SELECT {0} FROM [{1}] " & vbCrLf & "{2}", strSelect, nomTable, strWhere)
    End Function

    Private Function DeleteQuery(ByVal nomTable As String) As String
        'Préparer la table des colonnes pour l'aide à la sélection
        Dim dtCols As DataTable = conn.ExecuteDataTable("exec sp_columns '" & nomTable & "'")
        dtCols.TableName = "DeleteQuery"
        With dtCols.Columns
            .Add("Operator", GetType(String))
            .Add("Where", GetType(String))
        End With
        For Each dr As DataRow In dtCols.Rows
            dr("Operator") = "="
            dr("Where") = ""
        Next
        Dim dvCols As New DataView(dtCols, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)

        'Appel à FrColonnes pour déterminer les colonnes à Sélectionner
        Dim fr As New FrColonnes(dvCols)
        If fr.ShowDialog = DialogResult.Cancel Then Return ""

        'Déterminer la chaine WHERE
        Dim strWhere As String = WhereClause(dvCols)

        Return String.Format("DELETE FROM [{0}]" & vbCrLf & " {1}", nomTable, strWhere)
    End Function

    Private Function InsertQuery(ByVal nomTable As String) As String
        'Préparer la table des colonnes pour l'aide à la sélection
        Dim dtCols As DataTable = conn.ExecuteDataTable("exec sp_columns '" & nomTable & "'")
        dtCols.TableName = "InsertQuery"
        With dtCols.Columns
            .Add("Value", GetType(String))
        End With
        For Each dr As DataRow In dtCols.Rows
            dr("Value") = ""
        Next
        Dim dvCols As New DataView(dtCols, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)

        'Appel à FrColonnes pour déterminer les colonnes à Sélectionner
        Dim fr As New FrColonnes(dvCols)
        If fr.ShowDialog = DialogResult.Cancel Then Return ""

        'Déterminer la chaine VALUES
        dvCols.RowFilter = "(Value is not null) And (Value<>'')"
        Dim strCols As String
        Dim strValues As String
        If dvCols.Count = 0 Then
            Return ""
        Else
            Dim cols As New ArrayList
            Dim values As New ArrayList
            For Each drv As DataRowView In dvCols
                cols.Add(String.Format("[{0}]", drv("COLUMN_NAME")))
                Dim type As String = Convert.ToString(drv("TYPE_NAME")).Trim
                Dim val As String = Convert.ToString(drv("Value")).Trim
                values.Add(String.Format("{0}", SqlProxy.FormatSqlValue(val, type)))
            Next
            strCols = Join(cols, ",")
            strValues = Join(values, ",")
        End If

        Return String.Format("INSERT INTO [{0}] " & vbCrLf & "({1})" & vbCrLf & " VALUES" & vbCrLf & "({2})", nomTable, strCols, strValues)
    End Function

    Private Function UpdateQuery(ByVal nomTable As String) As String
        'Préparer la table des colonnes pour l'aide à la sélection
        Dim dtCols As DataTable = conn.ExecuteDataTable("exec sp_columns '" & nomTable & "'")
        dtCols.TableName = "UpdateQuery"
        With dtCols.Columns
            .Add("Value", GetType(String))
            .Add("Operator", GetType(String))
            .Add("Where", GetType(String))
        End With
        For Each dr As DataRow In dtCols.Rows
            dr("Value") = ""
            dr("Operator") = "="
            dr("Where") = ""
        Next
        Dim dvCols As New DataView(dtCols, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)

        'Appel à FrColonnes pour déterminer les colonnes à Sélectionner
        Dim fr As New FrColonnes(dvCols)
        If fr.ShowDialog = DialogResult.Cancel Then Return ""

        'Déterminer la chaine SET
        dvCols.RowFilter = "(Value is not null) And (Value<>'')"
        Dim strSet As String
        If dvCols.Count = 0 Then
            Return ""
        Else
            Dim cols As New ArrayList
            For Each drv As DataRowView In dvCols
                Dim val As String = Convert.ToString(drv("Value")).Trim
                Dim type As String = Convert.ToString(drv("TYPE_NAME")).Trim
                cols.Add(String.Format("[{0}]={1}", drv("COLUMN_NAME"), SqlProxy.FormatSqlValue(val, type)))
            Next
            strSet = Join(cols, ",")
        End If

        'Déterminer la chaine WHERE
        Dim strWhere As String = WhereClause(dvCols)

        Return String.Format("UPDATE [{0}] SET " & vbCrLf & "{1}" & vbCrLf & "{2}", nomTable, strSet, strWhere)
    End Function

    Private Function WhereClause(ByVal dvCols As DataView) As String
        dvCols.RowFilter = "(Where is not null) And (Where<>'')"
        Dim strWhere As String
        If dvCols.Count = 0 Then
            strWhere = ""
        Else
            Dim cols As New ArrayList
            For Each drv As DataRowView In dvCols
                Dim val As String = Convert.ToString(drv("Where")).Trim
                Dim op As String = Convert.ToString(drv("Operator")).Trim
                Dim type As String = Convert.ToString(drv("TYPE_NAME")).Trim
                If String.Equals(val, "NULL", StringComparison.CurrentCultureIgnoreCase) Then
                    If op = "<>" Then
                        op = "IS NOT"
                    Else
                        op = "IS"
                    End If
                Else
                    val = SqlProxy.FormatSqlValue(val, type)
                End If
                cols.Add(String.Format("[{0}] {1} {2}", drv("COLUMN_NAME"), op, val))
            Next
            strWhere = "WHERE " & Join(cols, " AND ")
        End If

        Return strWhere
    End Function
#End Region

    Private Function ExecQuery(ByVal nomProc As String) As String
        Dim dtParams As DataTable = conn.ExecuteDataTable(String.Format("SELECT * FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = N'{0}'", nomProc))
        dtParams.TableName = "ExecQuery"
        With dtParams.Columns
            .Add("Value", GetType(String))
        End With
        For Each dr As DataRow In dtParams.Rows
            dr("Value") = ""
        Next
        Dim dvParams As New DataView(dtParams, "", "ORDINAL_POSITION", DataViewRowState.CurrentRows)
        'Appel à FrColonnes pour déterminer les colonnes à Sélectionner
        Dim fr As New FrColonnes(dvParams)
        If fr.ShowDialog = DialogResult.Cancel Then Return ""

        'Déterminer la chaine de Params
        dvParams.RowFilter = "(Value is not null) And (Value<>'')"
        Dim strParams As String
        If dvParams.Count = 0 Then
            Return ""
        Else
            Dim cols As New ArrayList
            For Each drv As DataRowView In dvParams
                Dim type As String = Convert.ToString(drv("DATA_TYPE")).Trim
                Dim val As String = Convert.ToString(drv("Value")).Trim
                cols.Add(String.Format("{0}={1}", drv("PARAMETER_NAME"), SqlProxy.FormatSqlValue(val, type)))
            Next
            strParams = Join(cols, ",")
        End If

        Return String.Format("EXEC {0} {1}", nomProc, strParams)
    End Function

    Private Function Join(ByVal array As IList, ByVal separator As String) As String
        Dim value(array.Count - 1) As String
        array.CopyTo(value, 0)
        Return String.Join(separator, value)
    End Function

#End Region

#Region "Execution"

    Private Sub ChargerScript(ByVal fichier As String)
        If IO.File.Exists(fichier) Then
            Cursor.Current = Cursors.WaitCursor
            Dim sr As New IO.StreamReader(fichier, True)
            TxRequete.Text = sr.ReadToEnd
            sr.Close()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub EnregistrerScript(ByVal fichier As String)
        If TxRequete.Text.Trim.Length > 0 Then
            Cursor.Current = Cursors.WaitCursor
            My.Computer.FileSystem.WriteAllText(fichier, TxRequete.Text, False)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub EnregistrerMessages(ByVal fichier As String)
        If TxRequete.Text.Trim.Length > 0 Then
            Cursor.Current = Cursors.WaitCursor
            My.Computer.FileSystem.WriteAllText(fichier, txMessages.Text, False)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub BtExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitExec.ButtonClick
        If conn Is Nothing Then Exit Sub
        Dim q As String
        If TxRequete.SelectionLength = 0 Then
            q = TxRequete.Text.Trim
        Else
            q = TxRequete.SelectedText.Trim
        End If
        If q.Length = 0 Then Exit Sub
        Try
            Cursor.Current = Cursors.WaitCursor
            conn.RunScript(q)
            'MsgBox("Execution OK", MsgBoxStyle.Information)
            AppendMessage("Execution OK")
        Catch ex As Exception
            AppendMessage(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Sub ExecuterDDLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuterDDLToolStripMenuItem.Click
        If conn Is Nothing Then Exit Sub
        Dim q As String
        If TxRequete.SelectionLength = 0 Then
            q = TxRequete.Text.Trim
        Else
            q = TxRequete.SelectedText.Trim
        End If
        If q.Length = 0 Then Exit Sub
        Try
            Cursor.Current = Cursors.WaitCursor
            conn.RunScript(q, False)
            AppendMessage("Execution OK")
        Catch ex As Exception
            AppendMessage(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequêteToolStripMenuItem.Click
        If conn Is Nothing Then Exit Sub
        Dim q As String
        If TxRequete.SelectionLength = 0 Then
            q = TxRequete.Text.Trim
        Else
            q = TxRequete.SelectedText.Trim
        End If
        If q.Length = 0 Then Exit Sub
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim dt As DataTable = conn.ExecuteDataTable(q)
            'For i As Integer = dt.Columns.Count - 1 To 0 Step -1
            '    If dt.Columns(i).DataType Is GetType(Image) OrElse dt.Columns(i).DataType Is GetType(Byte()) Then
            '        dt.Columns.RemoveAt(i)
            '    End If
            'Next
            status2.Text = String.Format("{0} lignes sélectionnée(s)", dt.Rows.Count)
            AppendMessage(status2.Text, False)
            DgResults.DataSource = dt
            TabControl1.SelectedTab = tpResult
            SplitHorizontal.Panel2Collapsed = False
            MajBoutons()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            AppendMessage(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtClearMessages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViderLesMessagesToolStripMenuItem.Click
        Me.txMessages.Clear()
    End Sub

    Private Sub AppendMessage(ByVal msg As String, Optional ByVal selectTab As Boolean = True)
        Me.txMessages.AppendText(msg & vbCrLf & vbCrLf)
        If selectTab Then TabControl1.SelectedTab = tpMessages
    End Sub

    Private Sub ConnectionMessage(ByVal sender As Object, ByVal e As SqlInfoMessageEventArgs)
        'MsgBox(e.Message, MsgBoxStyle.Information)
        AppendMessage(e.Message)
    End Sub

#End Region

#Region "Exportation"
    Private Sub Exporter()
        'TODO Implémenter d'autres exports : HTML,XMl...
        Dim dt As DataTable = CType(DgResults.DataSource, DataTable)
        With saveDialog
            .Filter = "Fichiers CSV (*.csv)|*.csv"
            .FilterIndex = 0
            .FileName = "export.csv"
            .Title = "Exporter les données"
            If .ShowDialog <> DialogResult.OK Then Exit Sub
        End With
        Dim fichier As String = saveDialog.FileName
        Cursor.Current = Cursors.WaitCursor
        ExporterCSV(dt, fichier)
        Cursor.Current = Cursors.Default
        Process.Start(fichier)
    End Sub

    Private Sub ExporterCSV(ByVal dt As DataTable, ByVal fichier As String)
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        Dim ligne(dt.Columns.Count - 1) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            ligne(i) = String.Format("""{0}""", dt.Columns(i).ColumnName)
        Next
        sw.WriteLine(String.Join(";", ligne))

        ligne.Initialize()
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                ligne(i) = String.Format("""{0}""", dr(i))
            Next
            sw.WriteLine(String.Join(";", ligne))
        Next
        sw.Close()
    End Sub

#End Region

#Region " Sauvegarde/Restauration "
    Private Sub SauvegarderLaBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SauvegarderLaBaseToolStripMenuItem.Click
        If conn Is Nothing Then Exit Sub
        With saveDialog
            .FileName = String.Format("Sauvegarde {0} {1:dd-MM-yyyy}", conn.Connection.Database, Now)
            .Filter = "Fichiers sauvegarde (*.afz)|*.afz"
            .FilterIndex = 0
            .AddExtension = True
            .Title = "Sélectionnez l'emplacement de sauvegarde de la base"
            .DefaultExt = "afz"
            If .ShowDialog = DialogResult.OK Then
                Application.DoEvents()
                SauvegarderBase(.FileName)
            End If
        End With
    End Sub

    Private Sub RestaurerUneBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurerUneBaseToolStripMenuItem.Click
        With openDialog
            .Filter = "Fichiers sauvegarde (*.afz)|*.afz|Tous les fichiers (*.*)|*.*"
            .FilterIndex = 0
            .Title = "Sélectionnez la sauvegarde à restaurer"
            .DefaultExt = "afz"
            If .ShowDialog = DialogResult.OK Then
                Application.DoEvents()
                RestaurerBase(.FileName)
            End If
        End With
    End Sub

    Private Sub SauvegarderBase(ByVal fichier As String)
        If fichier.Length = 0 Then Exit Sub
        Select Case IO.Path.GetExtension(fichier).ToLower
            Case ".afz", ".zip"
                RunTask(AddressOf RunSauvegarde, fichier)
        End Select
    End Sub

    Private Sub RestaurerBase(ByVal fichier As String)
        If fichier.Length = 0 Then Exit Sub
        If MsgBox("Cette opération va écraser les données actuelles de l'application." & vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        'Select Case IO.Path.GetExtension(fichier).ToLower
        'Case ".afz", ".zip"
        RunTask(AddressOf RunRestauration, fichier)
        'End Select
    End Sub

    Private Sub RunSauvegarde(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim gs As New GestionSauvegarde
        gs.Sauvegarder(CStr(e.Argument), Cast(Of System.ComponentModel.BackgroundWorker)(sender))
    End Sub

    Private Sub RunRestauration(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim gs As New GestionSauvegarde
        gs.Restaurer(CStr(e.Argument), Application.StartupPath, Cast(Of System.ComponentModel.BackgroundWorker)(sender))
    End Sub

#End Region

#Region " Gestion taches asynchrones avec barre de progression "
    Private Sub RunTask(ByVal e As System.ComponentModel.DoWorkEventHandler, Optional ByVal argument As Object = Nothing)
        Dim worker As System.ComponentModel.BackgroundWorker = PrepareProgression()
        AddHandler worker.DoWork, e
        worker.RunWorkerAsync(argument)
    End Sub

    Private frProgressionSauvegarde As FrProgressBar

    Private Function PrepareProgression() As System.ComponentModel.BackgroundWorker
        frProgressionSauvegarde = New FrProgressBar
        With frProgressionSauvegarde
            .Maximum = 100
            .Text = ""
            .Show(Me)
        End With
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Application.DoEvents()
        Dim worker As New System.ComponentModel.BackgroundWorker
        With worker
            .WorkerReportsProgress = True
            AddHandler .ProgressChanged, AddressOf frProgressionSauvegarde.UpdateProgress
            AddHandler .RunWorkerCompleted, AddressOf WorkCompleted
        End With
        Return worker
    End Function

    Private Sub WorkCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Not e.Cancelled Then
            If e.Error IsNot Nothing Then
                LogException(e.Error)
                AppendMessage(e.Error.Message)
                MsgBox(e.Error.Message, MsgBoxStyle.Exclamation)
            End If
        End If
        Me.Cursor = Cursors.Default
        Me.Enabled = True
        If frProgressionSauvegarde IsNot Nothing Then
            frProgressionSauvegarde.Close()
            frProgressionSauvegarde = Nothing
        End If
    End Sub
#End Region


    Private Sub ExplorateurDobjetsToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExplorateurDobjetsToolStripMenuItem.CheckedChanged
        SplitVertical.Panel1Collapsed = Not ExplorateurDobjetsToolStripMenuItem.Checked
    End Sub

    Private Sub RésultatsToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RésultatsToolStripMenuItem.CheckedChanged
        SplitHorizontal.Panel2Collapsed = Not RésultatsToolStripMenuItem.Checked
    End Sub

    Private Sub ViderLesRésultatsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViderLesRésultatsToolStripMenuItem.Click
        DgResults.DataSource = Nothing
    End Sub

    Private Sub ctxTab_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxTab.Opening
        If TabControl1.SelectedTab Is tpMessages Then
            ViderLesRésultatsToolStripMenuItem.Visible = False
            ViderLesMessagesToolStripMenuItem.Visible = True
        Else
            ViderLesRésultatsToolStripMenuItem.Visible = True
            ViderLesMessagesToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub DgResults_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgResults.DataError
        e.Cancel = True
    End Sub
End Class
