Imports CrystalDecisions.CrystalReports.Engine

Public Class ImprPLC

#Region "Méthodes partagées"
    Public Shared Function GetDataRptPLC() As DataSet
        Dim ds As New dsImp
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()

            Dim sql As String = String.Format("SELECT     PlLib, PlCpt " & _
            "FROM PlanComptable " & _
            "WHERE     (PlDossier = '{0}')", My.User.Name)

            FillDataTable(ds.ImpPLC, sql, conn)
        End Using
        Return ds
    End Function

    Public Shared Function PrepareRptPLC(ByVal ds As DataSet, ByVal detailActi As Boolean) As ReportDocument
        Dim report As ReportDocument = EcranCrystal.ChargerReport("rptPLC.rpt", ds)
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
