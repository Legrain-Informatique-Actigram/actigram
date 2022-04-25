Imports System.Data.OleDb

Public Class FrExportationBalance

#Region "Form"
    Private Sub FrExportationBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ProgressBar1.Visible = False

        Me.ParametrerPeriode()

        Me.LoadData()

        'Sélection de toutes les activités de la liste
        Dim i As Integer

        For i = 0 To Me.ActivitesListBox.Items.Count - 1
            Me.ActivitesListBox.SetSelected(i, True)
        Next
    End Sub
#End Region

#Region "Button"
    Private Sub ExporterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterButton.Click
        With Me.SaveFileDialog1
            .DefaultExt = "csv"
            .Filter = "Fichiers csv (*.csv)|*.csv"
            .FileName = String.Format("AgrigestEDI_{3}_BalanceDu{0:ddMMyyyy}Au{1:ddMMyyyy}_{2:ddMMyyyyhhmmss}.csv", Me.DateDebDateTimePicker.Value, Me.DateFinDateTimePicker.Value, Now, My.User.Name)

            If (.ShowDialog = DialogResult.OK) Then
                Me.ExporterAuFormatCSV(.FileName)

                Me.Close()
            End If
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ParametrerPeriode()
        'Date début
        Me.DateDebDateTimePicker.MinDate = My.Dossier.Principal.DateDebutEx
        Me.DateDebDateTimePicker.MaxDate = My.Dossier.Principal.DateFinEx
        Me.DateDebDateTimePicker.Value = My.Dossier.Principal.DateDebutEx

        'Date fin
        Me.DateFinDateTimePicker.MinDate = My.Dossier.Principal.DateDebutEx
        Me.DateFinDateTimePicker.MaxDate = My.Dossier.Principal.DateFinEx
        Me.DateFinDateTimePicker.Value = My.Dossier.Principal.DateFinEx
    End Sub

    Private Sub LoadData()
        'Chargement de la liste des activités
        Me.ActivitesTableAdapter.FillByDossier(Me.DbDonneesDataSet.Activites, My.User.Name)
    End Sub

    Private Sub ExporterAuFormatCSV(ByVal nomFichier As String)
        Dim queryString As String = String.Empty
        Dim ds As New DataSet

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ProgressBar1.Visible = True

            Me.ProgressBar1.Value = 50
            Application.DoEvents()

            'Création du filtre Activités
            Dim filtreActivites As String = Me.CreerFiltreActivites()

            queryString = String.Format("SELECT Mouvements.MDossier AS Dossier, Mouvements.MActi AS [Activité], " & _
                                    "'{0}' As Date_Deb_Periode, " & _
                                    "'{1}' AS Date_Fin_Periode, Mouvements.MCpt AS Compte, " & _
                                    "Sum(Mouvements.MMtDeb) AS Debit, Sum(Mouvements.MMtCre) AS Credit, " & _
                                    "Sum(Mouvements.MMtDeb) - Sum(Mouvements.MMtCre) AS Solde, " & _
                                    "Sum(Mouvements.MQte1) AS Qte1, Sum(Mouvements.MQte2) AS Qte2 " & _
                                    "FROM Mouvements " & _
                                    "WHERE (Mouvements.MDate>=#{0:MM/dd/yyyy}#) AND " & _
                                    "(Mouvements.MDate<=#{1:MM/dd/yyyy}#) AND " & _
                                    "(Mouvements.MCpt<>'{2}') " & _
                                    filtreActivites & _
                                    "GROUP BY Mouvements.MDossier, Mouvements.MActi, Mouvements.MCpt " & _
                                    "HAVING (Mouvements.MDossier='{3}') " & _
                                    "ORDER BY Mouvements.MCpt", _
                                    Me.DateDebDateTimePicker.Value, _
                                    Me.DateFinDateTimePicker.Value, _
                                    "48800000", _
                                    My.User.Name)

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                oleDbConn.Open()

                Using oleDbComm As New OleDbCommand(queryString, oleDbConn)
                    Dim mouvementsDA As OleDbDataAdapter = New OleDbDataAdapter()

                    mouvementsDA.SelectCommand = oleDbComm

                    mouvementsDA.Fill(ds, "Mouvements")
                End Using
            End Using

            Me.ProgressBar1.Value = 100
            Application.DoEvents()

            Dim expCsv As New ExportCsv(ds.Tables("Mouvements"), ExportCsv.SeparateurEnum.POINTVIRGULE, True, nomFichier)

            expCsv.Exporter(Me.ProgressBar1)

            MsgBox("Export terminé.", MsgBoxStyle.Information, "")
        Finally
            Me.Cursor = Cursors.Default

            Me.ProgressBar1.Visible = False
        End Try
    End Sub

    Private Function CreerFiltreActivites() As String
        Dim filtre As String = String.Empty
        Dim listeActivites As ListBox.SelectedObjectCollection = Me.ActivitesListBox.SelectedItems

        For Each dr As DataRowView In listeActivites
            Dim ActivitesDR As dbDonneesDataSet.ActivitesRow = CType(CType(dr, DataRowView).Row, dbDonneesDataSet.ActivitesRow)

            filtre = filtre & "'" & ActivitesDR.AActi & "',"
        Next

        'Suppression virgule finale
        If (filtre.Length > 0) Then
            filtre = Microsoft.VisualBasic.Left(filtre, filtre.Length - 1)

            filtre = " AND ([Mouvements].[MActi] IN(" & filtre & ")) "
        End If

        Return filtre
    End Function
#End Region

End Class