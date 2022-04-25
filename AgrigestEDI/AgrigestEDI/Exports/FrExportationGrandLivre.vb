Imports System.Data.OleDb
Public Class FrExportationGrandLivre

#Region "Form"
    Private Sub FrExportationGrandLivre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ProgressBar1.Visible = False

        Me.DateDebDateTimePicker.Value = My.Dossier.Principal.DateDebutEx
        Me.DateFinDateTimePicker.Value = My.Dossier.Principal.DateFinEx
    End Sub
#End Region

#Region "Button"
    Private Sub ExporterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterButton.Click
        With Me.SaveFileDialog1
            .DefaultExt = "csv"
            .Filter = "Fichiers csv (*.csv)|*.csv"
            .FileName = String.Format("Agrigest_GLDu{0:ddMMyyyy}Au{1:ddMMyyyy}_{2:ddMMyyyyhhmmss}.csv", Me.DateDebDateTimePicker.Value, Me.DateFinDateTimePicker.Value, Now)

            If (.ShowDialog = DialogResult.OK) Then
                Me.ExporterAuFormatCSV(.FileName)

                Me.Close()
            End If
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ExporterAuFormatCSV(ByVal nomFichier As String)
        Dim queryString As String = String.Empty
        Dim ds As New DataSet

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ProgressBar1.Visible = True

            Me.ProgressBar1.Value = 50
            Application.DoEvents()

            queryString = String.Format("SELECT Mouvements.MDossier AS Dossier, '{0}' AS Date_Deb_Periode, " & _
                                    "'{1}' AS Date_Fin_Periode, Mouvements.MPiece AS Piece, Mouvements.MDate AS Date_Mouvement, " & _
                                    "Mouvements.MCpt AS Compte, Mouvements.MActi AS Activite, Lignes.LLib AS Libelle_Mouvement, " & _
                                    "Lignes.LMtTVA AS CTva, Mouvements.MMtDeb AS Debit, Mouvements.MMtCre AS Credit, " & _
                                    "Mouvements.MQte1 AS Quantite_1, Mouvements.MQte2 AS Quantite_2, Mouvements.MLettrage AS Lettrage " & _
                                    "FROM Lignes INNER JOIN Mouvements ON (Lignes.LLig = Mouvements.MLig) AND (Lignes.LDate = Mouvements.MDate) " & _
                                    "AND (Lignes.LPiece = Mouvements.MPiece) AND (Lignes.LDossier = Mouvements.MDossier) " & _
                                    "WHERE (Mouvements.MDossier = '{2}') AND " & _
                                    "(Mouvements.MDate >= #{0:MM/dd/yyyy}#) AND " & _
                                    "(Mouvements.MDate <= #{1:MM/dd/yyyy}#) AND " & _
                                    "(Mouvements.Mcpt <> '{3}') " & _
                                    "ORDER BY Mouvements.MCpt, Mouvements.MDate", _
                                    Me.DateDebDateTimePicker.Value, _
                                    Me.DateFinDateTimePicker.Value, _
                                    My.User.Name, _
                                    "48800000")

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
#End Region

End Class