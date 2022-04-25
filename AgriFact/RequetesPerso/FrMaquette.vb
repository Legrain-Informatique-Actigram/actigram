Imports System.Windows.Forms

Public Class FrMaquette

    Const sql1 As String = "select year(datefacture) as annee,sum(montantht) as CAHT from vfacture group by year(datefacture) order by year(datefacture)"
    Const sql2 As String = "select year(datefacture) as annee, month(datefacture) as mois,sum(montantht) as CAHT " & _
                            "from vfacture where year(datefacture)=@annee " & _
                            "group by year(datefacture),month(datefacture)" & _
                            "order by year(datefacture),month(datefacture)"
    Const sql3 As String = "select year(datefacture) as annee, month(datefacture) as mois,e.nom, sum(montantht) as CAHT " & _
                            "from vfacture inner join entreprise e on vfacture.nclient=e.nentreprise " & _
                            "where year(datefacture)=@annee and month(datefacture)=@mois " & _
                            "group by year(datefacture),month(datefacture),nclient,e.nom " & _
                            "order by e.nom"

    Private _conn As SqlClient.SqlConnection
    Public Property Connection() As SqlClient.SqlConnection
        Get
            Return _conn
        End Get
        Set(ByVal value As SqlClient.SqlConnection)
            _conn = value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            If Me.Connection Is Nothing Then
                Return ""
            Else
                Return Me.Connection.ConnectionString
            End If
        End Get
        Set(ByVal value As String)
            If Me.Connection IsNot Nothing AndAlso Me.Connection.State <> ConnectionState.Closed Then
                Me.Connection.Close()
            End If
            If Me.Connection Is Nothing Then
                Me.Connection = New SqlClient.SqlConnection
            End If
            Me.Connection.ConnectionString = value
        End Set
    End Property

    Private Sub FrMaquette_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For i As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
            Dim t As TabPage = TabControl1.TabPages(i)
            TabControl1.TabPages.RemoveAt(i)
            For Each c As Control In t.Controls
                c.Dispose()
            Next
            t.Dispose()
        Next
        ExecuteSql1()
    End Sub

    Private Sub AddPageResult(ByVal dt As DataTable, ByVal titre As String, ByVal nSql As Integer)
        Dim dgv As New DataGridView
        With dgv
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .DataSource = dt
            .Dock = DockStyle.Fill
            .Tag = nSql
            AddHandler .CellDoubleClick, AddressOf dgv_CellDoubleClick
        End With
        Dim tp As New TabPage
        tp.Text = titre
        tp.Controls.Add(dgv)
        Me.TabControl1.TabPages.Add(tp)
        Me.TabControl1.SelectedTab = tp
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ClosePage(Me.TabControl1.SelectedTab)
    End Sub

    Private Sub ClosePage(ByVal t As TabPage)
        If t Is Nothing Then Exit Sub
        Me.TabControl1.TabPages.Remove(t)
        For Each c As Control In t.Controls
            c.Dispose()
        Next
        t.Dispose()
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If CType(sender, DataGridView).Tag Is Nothing Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        Dim r As DataGridViewRow = CType(sender, DataGridView).Rows(e.RowIndex)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim dr As DataRowView = CType(r.DataBoundItem, DataRowView)
        Select Case CInt(CType(sender, DataGridView).Tag)
            Case 1 : ExecuteSql2(CInt(dr("annee")))
            Case 2 : ExecuteSql3(CInt(dr("annee")), CInt(dr("mois")))
            Case 3
        End Select
    End Sub

    Private Sub ExecuteSql1()
        Dim dt As DataTable
        Using sql As New SqlProxy(Me.Connection)
            dt = sql.ExecuteDataTable(sql1)
        End Using
        AddPageResult(dt, "CA HT par année", 1)
    End Sub

    Private Sub ExecuteSql2(ByVal valAnnee As Integer)
        Dim dt As New DataTable
        Using cmd As SqlClient.SqlCommand = BuildSql2Command()
            cmd.Parameters("@annee").Value = valAnnee
            Using dta As New SqlClient.SqlDataAdapter(cmd)
                dta.Fill(dt)
            End Using
        End Using
        AddPageResult(dt, "CA HT par mois pour l'année " & valAnnee.ToString, 2)
    End Sub

    Private Function BuildSql2Command() As SqlClient.SqlCommand
        Dim cmd As New SqlClient.SqlCommand(sql2, Me.Connection)
        cmd.Parameters.Add("@annee", SqlDbType.Int)
        Return cmd
    End Function

    Private Sub ExecuteSql3(ByVal valAnnee As Integer, ByVal valMois As Integer)
        Dim dt As New DataTable
        Using cmd As SqlClient.SqlCommand = BuildSql3Command()
            cmd.Parameters("@annee").Value = valAnnee
            cmd.Parameters("@mois").Value = valMois
            Using dta As New SqlClient.SqlDataAdapter(cmd)
                dta.Fill(dt)
            End Using
        End Using
        AddPageResult(dt, String.Format("CA HT par client pour le mois de {0}/{1}", valMois, valAnnee), 3)
    End Sub

    Private Function BuildSql3Command() As SqlClient.SqlCommand
        Dim cmd As New SqlClient.SqlCommand(sql3, Me.Connection)
        cmd.Parameters.Add("@annee", SqlDbType.Int)
        cmd.Parameters.Add("@mois", SqlDbType.Int)
        Return cmd
    End Function


    Private Sub TabControl1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            For tabIndex As Integer = 0 To TabControl1.TabCount - 1
                If TabControl1.GetTabRect(tabIndex).Contains(e.Location) Then
                    ClosePage(TabControl1.TabPages(tabIndex))
                    Exit For
                End If
            Next
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            For tabIndex As Integer = 0 To TabControl1.TabCount - 1
                If TabControl1.GetTabRect(tabIndex).Contains(e.Location) Then
                    Me.TabControl1.SelectedTab = TabControl1.TabPages(tabIndex)
                    Me.ContextMenuStrip1.Show(Me.TabControl1.PointToScreen(e.Location))
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ActualiserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualiserToolStripMenuItem.Click
        Dim tp As TabPage = Me.TabControl1.SelectedTab
        If tp Is Nothing Then Exit Sub
        If tp.Controls.Count = 0 Then Exit Sub
        Dim dgv As DataGridView = CType(tp.Controls(0), DataGridView)
        If dgv.Tag Is Nothing Then Exit Sub
        Select Case CInt(dgv.Tag)
            Case 1
            Case 2
            Case 3
        End Select
    End Sub

    Private Sub FermerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermerToolStripMenuItem.Click
        ClosePage(Me.TabControl1.SelectedTab)
    End Sub
End Class