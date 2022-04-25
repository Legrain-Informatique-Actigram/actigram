Public Class FrChoixColonnes


    Private _tableName As String
    Public Property TableName() As String
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value
        End Set
    End Property

    Private Sub FrChampsPersos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ChargerDonnees()
    End Sub

    Private Sub ChargerDonnees()
        Dim champs As New List(Of String)
        If My.Settings.ChampsPersos.Length > 0 Then
            champs.AddRange(My.Settings.ChampsPersos.Split(","c))
        End If

        Me.chkChamps.Items.Clear()
        Using sql As New SqlProxy(My.Settings.ConnAgrifact)
            Dim dt As DataTable = sql.ExecuteDataTable(SqlProxy.FormatSql("exec sp_columns {0}", Me.TableName))
            If dt Is Nothing Then Exit Sub
            If dt.Rows.Count = 0 Then Exit Sub
            For Each dr As DataRow In dt.Rows
                Dim ch As String = Convert.ToString(dr("COLUMN_NAME"))
                chkChamps.Items.Add(ch, champs.Contains(ch))
            Next
        End Using
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Dim champs As New List(Of String)
        For Each ch As String In Me.chkChamps.CheckedItems
            champs.Add(ch)
        Next
        My.Settings.ChampsPersos = String.Join(",", champs.ToArray)
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class