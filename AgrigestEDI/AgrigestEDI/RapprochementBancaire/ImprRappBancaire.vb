Imports CrystalDecisions.CrystalReports.Engine

Public Class ImprRappBancaire

#Region "Méthodes partagées"
    Public Shared Function GetDataRptRappBancaire(ByVal DtRapprochement As String, ByVal NumCpte As String) As DataSet
        Dim ds As New dsImp
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()

            Dim sql As String = String.Format("SELECT Mouvements.MDossier, Mouvements.MCpt, Comptes.CLib, Mouvements.MDate, Mouvements.MPiece, Pieces.Libelle, Lignes.LLib, Mouvements.MMtDeb, " & _
            "mouvements.MMtCre, Mouvements.MPointage, Mouvements.MDatePointage " & _
            "FROM         ((((Lignes INNER JOIN " & _
                      "Mouvements ON Lignes.LDossier = Mouvements.MDossier AND Lignes.LPiece = Mouvements.MPiece AND Lignes.LDate = Mouvements.MDate AND " & _
                      "Lignes.LLig = Mouvements.MLig) INNER JOIN " & _
                      "Pieces ON Lignes.LDossier = Pieces.PDossier AND Lignes.LPiece = Pieces.PPiece AND Lignes.LDate = Pieces.PDate) INNER JOIN " & _
                      "PlanComptable ON Mouvements.MDossier = PlanComptable.PlDossier AND Mouvements.MCpt = PlanComptable.PlCpt AND " & _
                      "Mouvements.MActi = PlanComptable.PlActi) INNER JOIN " & _
                      "Comptes ON PlanComptable.PlDossier = Comptes.CDossier AND PlanComptable.PlCpt = Comptes.CCpt) " & _
            "WHERE     (Mouvements.MDossier = '{0}') AND (Mouvements.MCpt='{1}') AND (Mouvements.MDate <=#{2:MM/dd/yy}#) AND (Mouvements.MDatePointage IS NULL) " & _
            "ORDER BY Mouvements.MDate, Mouvements.MPiece", My.User.Name, NumCpte, CDate(DtRapprochement))
            FillDataTable(ds.ImpRappBancaire, sql, conn)
        End Using
        Return ds
    End Function

    Public Shared Function PrepareRptPLC(ByVal ds As DataSet, ByVal detailActi As Boolean) As ReportDocument
        Dim report As ReportDocument = EcranCrystal.ChargerReport("rptRappBancaire.rpt", ds)
        Return report
    End Function

    Shared Sub AffichDonneesGen(ByVal report As ReportDocument, ByVal solde As Decimal, ByVal soldeCptBq As Decimal, ByVal DtRapprochement As String)
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
        obj = report.ReportDefinition.ReportObjects.Item("IFSoldeCptDep")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("IFSoldeCptDep")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("IFSoldeCptDep"), FieldObject).DataSource, FormulaFieldDefinition).Text = Replace(CStr(solde), ",", ".")
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("IFSoldeCptBq")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("IFSoldeCptBq")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("IFSoldeCptBq"), FieldObject).DataSource, FormulaFieldDefinition).Text = Replace(CStr(soldeCptBq), ",", ".")
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("txtLibSoldeCptBq")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("txtLibSoldeCptBq")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("txtLibSoldeCptBq"), TextObject).Text = String.Format("Solde des écritures comptables au {0:dd/MM/yy} :", CDate(DtRapprochement))
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("TxtDateRapp")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtDateRapp")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtDateRapp"), TextObject).Text = String.Format("Solde comptable au {0:dd/MM/yy} :", Now)
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("txtLibSoldeExtrait")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("txtLibSoldeExtrait")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("txtLibSoldeExtrait"), TextObject).Text = String.Format("Solde de l'extrait bancaire au {0:dd/MM/yy} :", CDate(DtRapprochement))
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("txtLibSoldeEcrNP")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("txtLibSoldeEcrNP")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("txtLibSoldeEcrNP"), TextObject).Text = String.Format("Total des écritures non pointées au {0:dd/MM/yy} :", CDate(DtRapprochement))
            End If
        End If
        obj = report.ReportDefinition.ReportObjects.Item("txtDtRappBancaire")
        If Not obj Is Nothing Then
            If TypeOf (report.ReportDefinition.ReportObjects.Item("txtDtRappBancaire")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("txtDtRappBancaire"), TextObject).Text = String.Format("Date du rapprochement bancaire : {0:dd/MM/yy}", CDate(DtRapprochement))
            End If
        End If
    End Sub
#End Region

End Class
