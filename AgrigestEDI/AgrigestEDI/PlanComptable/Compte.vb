Imports CrystalDecisions.CrystalReports.Engine

Public Class Compte

#Region "Méthodes partagées"
    Public Shared Function GetDataRptVisuCompte(ByVal numCpt As String, _
                Optional ByVal numActi As String = Nothing, Optional ByVal DtDeb As Date = Nothing, Optional ByVal DtFin As Date = Nothing, Optional ByVal Lettr As Boolean = Nothing) As DataSet
        Dim ds As New DataSet

        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()

            Dim strWhereAct As String = ""
            Dim strJoinActi As String = ""
            Dim strPeriode As String = ""
            Dim strLettrage As String = ""
            If numActi IsNot Nothing Then
                'strWhereAct = "AND (Mouvements.MActi='" & numActi & "')"
                strJoinActi = " AND plancomptable.plActi = PL.plActi "
            Else
                strWhereAct = "AND LGENE = 'O' "
            End If
            If Lettr Then
                strLettrage = " AND MLettrage is null "
            End If
            strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", DtDeb.ToString("MM/dd/yy"), DtFin.ToString("MM/dd/yy"))
            Dim strFromPLC As String = String.Format("FROM plancomptable WHERE plancomptable.PLdossier = pl.pldossier AND plancomptable.plcpt = PL.plcpt{0}", strJoinActi)
            Dim sql As String = String.Format("SELECT DISTINCT Mouvements.MDossier, Mouvements.MDate, Mouvements.MPiece, " & _
                    "Mouvements.MLig, Lignes.LLib, " & _
                    "Mouvements.MCpt, Mouvements.MMtDeb AS MontDeb, Mouvements.MMtCre AS MontCre, " & _
                    "Comptes.CU1, Mouvements.MQte1, Comptes.CU2, Mouvements.MQte2, Comptes.CLib, " & _
                      "(SELECT SUM(PlRepG_C) {3}) AS PlRepG_C, " & _
                      "(SELECT SUM(PlRepG_D) {3}) AS PlRepG_D, Mouvements.MCptCtr, Activites.ALib, " & _
                      "Mouvements.MActi, iif(MMtCre < 0 OR  MMtDeb < 0, '-', ' ') AS Signe, " & _
                      "(SELECT SUM(PlRepG_U1) {3}) AS PlRepG_U1, " & _
                      "(SELECT SUM(PlRepG_U2) {3}) AS PlRepG_U2 " & _
                    "FROM ((((Lignes " & _
                    "INNER JOIN Mouvements ON Lignes.LDate = Mouvements.MDate AND Lignes.LDossier = Mouvements.MDossier AND Lignes.LLig = Mouvements.MLig AND Lignes.LPiece = Mouvements.MPiece) " & _
                    "INNER JOIN Comptes ON Mouvements.MDossier = Comptes.CDossier AND Mouvements.MCpt = Comptes.CCpt) " & _
                    "INNER JOIN PlanComptable PL ON Comptes.CCpt = PL.PlCpt AND Comptes.CDossier = PL.PlDossier AND Mouvements.MActi = PL.PlActi) " & _
                    "INNER JOIN Activites ON Mouvements.MActi = Activites.AActi AND Mouvements.MDossier = Activites.ADossier)" & _
                    "WHERE Mouvements.MDossier = '{0}' AND Mouvements.MCpt = '{1}' {2} {4} {5}" & _
                    "Order by Mouvements.MDate, Mouvements.MPiece, Mouvements.MLig", My.User.Name, numCpt, strWhereAct, strFromPLC, strPeriode, strLettrage)


            Dim dt As DataTable = ExecuteDataTable(sql, conn)
            dt.TableName = "ImpVisuCpt"
            ds.Tables.Add(dt)
        End Using

        Return ds
    End Function

    Public Shared Function PrepareRptVisuCompte(ByVal ds As DataSet, ByVal detailActi As Boolean) As ReportDocument
        Dim report As ReportDocument = EcranCrystal.ChargerReport("rptVisuCpt.rpt", ds)
        If TypeOf (report.ReportDefinition.ReportObjects.Item("Fld9999")) Is FieldObject Then
            CType(CType(report.ReportDefinition.ReportObjects.Item("Fld9999"), FieldObject).DataSource, FormulaFieldDefinition).Text = detailActi.ToString
        End If

        ' If TypeOf (report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx")) Is TextObject Then
        'CType(report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx"), TextObject).Text = String.Format("Report au {0:dd/MM/yy} : ", My.Dossier.Principal.DateDebutEx)
        'End If
        Return report
    End Function

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
