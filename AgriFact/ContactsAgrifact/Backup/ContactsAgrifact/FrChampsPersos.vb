Public Class FrChampsPersos

    Private _nEnt As Integer=-1
    Public Property nEntreprise() As Integer
        Get
            Return _nEnt
        End Get
        Set(ByVal value As Integer)
            _nEnt = value
        End Set
    End Property

    Private Sub FrChampsPersos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(dgResult)
        ChargerDonnees()
    End Sub

    Private Sub ChargerDonnees()
        If Me.nEntreprise < 0 Then Exit Sub
        If My.Settings.ChampsPersos.Length = 0 Then Exit Sub
        Dim table As String = "Entreprise"
        Dim sql As String = String.Format("SELECT {0} FROM {1} WHERE nEntreprise={2}", My.Settings.ChampsPersos, table, Me.nEntreprise)

        Dim dtLibs As DsAgrifact.Niveau2DataTable
        Using dta As New DsAgrifactTableAdapters.Niveau2TA
            dtLibs = dta.GetDataByTable(table)
        End Using
        Dim dt As New DsAgrifact.ChampsPersosDataTable
        Using s As New SqlProxy(My.Settings.ConnAgrifact)
            Using dr As SqlClient.SqlDataReader = s.ExecuteReader(sql)
                While dr.Read
                    For i As Integer = 0 To dr.FieldCount - 1
                        Dim champ As String = dr.GetName(i)
                        dt.AddChampsPersosRow(champ, table, GetLibelle(dtLibs, table, champ), Convert.ToString(dr.GetValue(i)))
                    Next
                End While
            End Using
        End Using
        Me.ChampsPersosBindingSource.DataSource = dt
    End Sub

    Private Function GetLibelle(ByVal dtLibs As DsAgrifact.Niveau2DataTable, ByVal table As String, ByVal champ As String) As String
        Dim res As String = champ
        If dtLibs IsNot Nothing Then
            Dim rws() As DataRow = dtLibs.Select(String.Format("TableName='{0}' AND Champs='{1}'", table, champ))
            If rws.Length > 0 Then
                res = Convert.ToString(rws(0)("Libelle"))
            End If
        End If
        Return res
    End Function

    Private Sub TbChoixColonnes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbChoixColonnes.Click
        Using dlg As New FrChoixColonnes
            dlg.TableName = "Entreprise"
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
        End Using
    End Sub

    Private Sub TbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRefresh.Click
        ChargerDonnees()
    End Sub
End Class