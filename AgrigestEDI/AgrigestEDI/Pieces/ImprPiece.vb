Imports CrystalDecisions.CrystalReports.Engine

Public Class ImprPiece

#Region "Méthodes partagées"
    Public Shared Function GetDataRptVisuPiece(ByVal numPiece As String, ByVal dtPiece As String) As DataSet
        Dim ds As New dsImp
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()

            Dim sql As String = String.Format("SELECT Mouvements.MDossier, left(Mouvements.MPiece,5) as MPiece, " & _
                "Mouvements.MDate, Mouvements.MLig, Lignes.LLib, Mouvements.MCpt AS Cpt, " & _
                "Mouvements.MActi AS Acti, Mouvements.MMtDeb AS Debit, " & _
                "Mouvements.MMtCre AS Credit, Mouvements.MCptCtr AS CptCtr, " & _
                "iif(Mouvements.MActCtr='0','0000',MActCtr) AS ActiCtr, Mouvements.MQte1, " & _
                "Comptes.CU1, Mouvements.MQte2, Comptes.CU2, '-' AS Signe, " & _
                "Lignes.LTva AS LTVA, Libelle " & _
                "FROM (((Mouvements INNER JOIN " & _
                "Lignes ON Lignes.LDossier = Mouvements.MDossier AND " & _
                "Lignes.LPiece = Mouvements.MPiece AND Lignes.LDate = Mouvements.MDate " & _
                "AND Lignes.LLig = Mouvements.MLig) INNER JOIN " & _
                "Comptes ON Comptes.CCpt = Mouvements.MCpt AND " & _
                "Mouvements.MDossier = Comptes.CDossier) INNER JOIN " & _
                "Pieces ON Lignes.LDossier = Pieces.PDossier AND Lignes.LPiece = Pieces.PPiece " & _
                "AND Lignes.LDate = Pieces.PDate) " & _
                "WHERE (Mouvements.MDossier = '{0}') AND (Mouvements.MPiece = {1}) " & _
                " AND " & _
                "(Mouvements.MCpt <> '48800000') " & _
                "order by mdossier,mpiece,mdate,mlig", My.User.Name, numPiece, CDate(dtPiece))

            FillDataTable(ds.ImpVisuPiece, sql, conn)
        End Using
        Return ds
    End Function

    Public Shared Function PrepareRptVisuPiece(ByVal ds As DataSet, ByVal detailActi As Boolean) As ReportDocument
        Dim report As ReportDocument = EcranCrystal.ChargerReport("rptVisuPiece.rpt", ds)
        Return report
    End Function
#End Region

#Region "Méthodes diverses"
    Shared Sub AffichDonneesGen(ByVal report As ReportDocument)
        Dim obj As Object
        obj = report.ReportDefinition.ReportObjects.Item("TxNomExploitant")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxNomExploitant")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxNomExploitant"), TextObject).Text = My.Dossier.Principal.NomExploi1 & " " & My.Dossier.Principal.NomExploi2
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("TxExercice")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxExercice")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxExercice"), TextObject).Text = String.Format(My.Resources.Strings.ExerciceDuDate0AuDate1, My.Dossier.Principal.DateDebutEx, My.Dossier.Principal.DateFinEx)
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("TxDtEdi")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxDtEdi")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxDtEdi"), TextObject).Text = String.Format(My.Resources.Strings.Etats_EditeAvecAgrigestEDI, Today)
            End If
        End If
    End Sub
#End Region

End Class
