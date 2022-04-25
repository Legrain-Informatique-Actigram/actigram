Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Namespace Impressions

    Public Class ImpJAchat

        Public Shared Function GetDataRptJournalAchat(ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) As DataSet
            Dim ds As New dsImp
            ds.EnforceConstraints = False
            Dim strperiode As String

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                Using dta As New dsImpTableAdapters.JournalTableAdapter
                    dta.Fill(ds.Journal)
                End Using
                strperiode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", CType(dtDebPeriode, Date).ToString("MM/dd/yy"), CType(dtFinPeriode, Date).ToString("MM/dd/yy"))

                Dim sql As String = String.Format("SELECT  Mouvements.MDossier, Mouvements.MDate, Mouvements.MOrdre, Mouvements.MPiece, Mouvements.MLig, Lignes.LLib, Mouvements.MMtDeb, Mouvements.MMtCre, " & _
                     " Lignes.LTva, Lignes.LJournal,  Comptes.CLib, MCpt,MActi, Pieces.Libelle " & _
                        "FROM         (((Mouvements INNER JOIN " & _
                      "Lignes ON Lignes.LDossier = Mouvements.MDossier AND Lignes.LPiece = Mouvements.MPiece AND Lignes.LDate = Mouvements.MDate AND " & _
                      "Lignes.LLig = Mouvements.MLig) INNER JOIN " & _
                      "Comptes ON Mouvements.MCpt = Comptes.CCpt AND Mouvements.MDossier = Comptes.CDossier) INNER JOIN " & _
                      "Pieces ON Lignes.LDossier = Pieces.PDossier AND Lignes.LPiece = Pieces.PPiece AND Lignes.LDate = Pieces.PDate) " & _
                    "WHERE MDossier='{0}' " & _
                    "{1} AND (MCpt <> '48800000')", My.User.Name, strperiode)


                FillDataTable(ds.ImpJournal, sql, conn)
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptJournalAchat(ByVal ds As DataSet, ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) As ReportDocument
            Dim strLibellePeriode As String
            strLibellePeriode = String.Format(My.Resources.Strings.Etats_LibPeriode, dtDebPeriode, dtFinPeriode)
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptJournalAchat.rpt", ds)
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldStPage")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldStPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            Return report
        End Function
    End Class

    Public Class ImpBalGen

        Public Shared Function GetDataRptBalanceG(ByVal FDeb As String, ByVal FFin As String, ByVal dtFinPeriode As String) As DataSet
            Dim ds As New DataSet
            Dim CptFinGes As String
            Dim CptFin As String
            Dim strFourchetteCptM As String
            Dim strFourchetteCptPl As String
            Dim strPeriode As String
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                'Def Fpurchette cpte
                CptFin = FFin
                If FFin >= "60000000" Then
                    CptFinGes = "60000000"
                Else
                    CptFinGes = CptFin
                End If
                strFourchetteCptM = " And (MCpt>='" & FDeb & "' And MCpt<='" & CptFin & "')"
                If CptFin >= "60000000" Then
                    strFourchetteCptPl = " And (PlCpt>='" & FDeb & "' And PlCpt<='" & CptFin & "')"
                Else
                    strFourchetteCptPl = " And (PlCpt>='" & FDeb & "' And PlCpt<='" & CptFin & "')"
                End If
                strFourchetteCptPl = strFourchetteCptPl
                'Def fourchette date
                strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yy"), CType(dtFinPeriode, Date).ToString("MM/dd/yy"))

                Dim sql As String = String.Format("SELECT PlDossier, PlCpt, CLib, SUM(iif(isnull(MMtDeb) = False, MMtDeb, 0)) AS Debit, " & _
                "SUM(iif(isnull(MMtCre) = False, MMtCre, 0)) AS Credit, MAX(0) AS ReportD, MAX(0) AS ReportC, " & _
                "SUM(iif(isnull(MQte1) = False AND isnull(CU1) = False AND CU1 <> '', MQte1, 0)) AS Qt1, SUM(iif(isnull(MQte2) = False " & _
                "AND isnull(CU2) = False AND CU2 <> '', MQte2, 0)) AS Qt2, MAX(0) AS ReportU1, MAX(0) AS ReportU2, CU1, CU2, " & _
                "MAX(PlActi) AS PLActi, MAX(ALib) AS ALib, 0 AS SoldeDebN1, 0 AS SoldeCreN1, " & _
                        "iif(credit - debit = 0, 'O', 'N') AS Cptsolde " & _
                "FROM ((Lignes RIGHT OUTER JOIN " & _
                "(Mouvements RIGHT OUTER JOIN " & _
                "(Activites RIGHT OUTER JOIN " & _
                "PlanComptable PL ON Activites.ADossier = PL.PlDossier AND Activites.AActi = PL.PlActi) " & _
                "ON Mouvements.MActi = PL.PlActi AND " & _
                "Mouvements.MCpt = PL.PlCpt AND Mouvements.MDossier = PL.PlDossier) ON Lignes.LPiece = Mouvements.MPiece AND " & _
                "Lignes.LLig = Mouvements.MLig AND Lignes.LDate = Mouvements.MDate AND Lignes.LDossier = Mouvements.MDossier) " & _
                "RIGHT OUTER JOIN " & _
                "Comptes ON PL.PlCpt = Comptes.CCpt AND PL.PlDossier = Comptes.CDossier) " & _
                "WHERE (MCpt <> '48800000') and (MDossier = '{0}') {1} {2} " & _
                "GROUP BY PlDossier, PlCpt, CLib, CU1, CU2 " & _
                "ORDER BY PlDossier, PlCpt ", My.User.Name, strFourchetteCptPl, strPeriode)

                Dim dt As DataTable = ExecuteDataTable(sql, conn)
                dt.TableName = "ImpbalanceG"
                ds.Tables.Add(dt)
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptRptBBalanceG(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptBalanceG.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)

            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetail401")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetail401"), FieldObject).DataSource, FormulaFieldDefinition).Text = "true"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDet0000")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDet0000"), FieldObject).DataSource, FormulaFieldDefinition).Text = "true"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

    End Class

    Public Class ImpBalAna

        Public Shared Function GetDataRptBalanceA(ByVal FDeb As String, ByVal FFin As String, ByVal FActDeb As String, ByVal FActFin As String, ByVal dtFinPeriode As String) As DataSet
            Dim ds As New DataSet
            Dim CptFinGes As String
            Dim CptFin As String
            Dim strFourchetteCptM As String
            Dim strFourchetteCptPl As String
            Dim strPeriode As String
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                'Def Fourchette cpte
                CptFin = FFin
                If FFin >= "60000000" Then
                    CptFinGes = "60000000"
                Else
                    CptFinGes = CptFin
                End If
                strFourchetteCptM = " And (MCpt>='" & FDeb & "' And MCpt<='" & CptFin & "')"
                If CptFin >= "60000000" Then
                    strFourchetteCptPl = " And (PlCpt>='" & FDeb & "' And PlCpt<='" & CptFin & "')"
                Else
                    strFourchetteCptPl = " And (PlCpt>='" & FDeb & "' And PlCpt<='" & CptFin & "')"
                End If
                strFourchetteCptPl = strFourchetteCptPl
                'Def fourchette acti
                strFourchetteCptPl = strFourchetteCptPl & " And (PlActi>='" & FActDeb & "' And PlActi<='" & FActFin & "') "
                'Def fourchette date
                strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yy"), CType(dtFinPeriode, Date).ToString("MM/dd/yy"))

                Dim sql As String = String.Format("SELECT PlDossier, PlCpt, CLib, SUM(iif(isnull(MMtDeb) = False, MMtDeb, 0)) AS Debit, " & _
                "SUM(iif(isnull(MMtCre) = False, MMtCre, 0)) AS Credit, MAX(0) AS ReportD, MAX(0) AS ReportC, " & _
                "SUM(iif(isnull(MQte1) = False AND isnull(CU1) = False AND CU1 <> '', MQte1, 0)) AS Qt1, SUM(iif(isnull(MQte2) = False " & _
                "AND isnull(CU2) = False AND CU2 <> '', MQte2, 0)) AS Qt2, MAX(0) AS ReportU1, MAX(0) AS ReportU2, CU1, CU2, " & _
                "MAX(PlActi) AS PLActi, MAX(ALib) AS ALib, 0 AS SoldeDebN1, 0 AS SoldeCreN1, " & _
                        "iif(credit - debit = 0, 'O', 'N') AS Cptsolde " & _
                "FROM ((Lignes RIGHT OUTER JOIN " & _
                "(Mouvements RIGHT OUTER JOIN " & _
                "(Activites RIGHT OUTER JOIN " & _
                "PlanComptable PL ON Activites.ADossier = PL.PlDossier AND Activites.AActi = PL.PlActi) " & _
                "ON Mouvements.MActi = PL.PlActi AND " & _
                "Mouvements.MCpt = PL.PlCpt AND Mouvements.MDossier = PL.PlDossier) ON Lignes.LPiece = Mouvements.MPiece AND " & _
                "Lignes.LLig = Mouvements.MLig AND Lignes.LDate = Mouvements.MDate AND Lignes.LDossier = Mouvements.MDossier) " & _
                "RIGHT OUTER JOIN " & _
                "Comptes ON PL.PlCpt = Comptes.CCpt AND PL.PlDossier = Comptes.CDossier) " & _
                "WHERE (MCpt <> '48800000') and (MDossier = '{0}') {1} {2} " & _
                "GROUP BY PlDossier, PlCpt, PLActi,CLib, CU1, CU2 " & _
                "ORDER BY PlDossier, PlCpt ", My.User.Name, strFourchetteCptPl, strPeriode)

                Dim dt As DataTable = ExecuteDataTable(sql, conn)
                dt.TableName = "ImpbalanceG"
                ds.Tables.Add(dt)
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptRptBBalanceA(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptBalanceA.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)

            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetail401")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetail401"), FieldObject).DataSource, FormulaFieldDefinition).Text = "true"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDet0000")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDet0000"), FieldObject).DataSource, FormulaFieldDefinition).Text = "true"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

    End Class

    Public Class ImpGL
        Public Shared Function GetDataRptGL(ByVal cptDeb As String, ByVal cptFin As String, ByVal dtFinPeriode _
                                As String, ByVal Lettr As Boolean) As DataSet
            Dim ds As New DataSet
            Dim strperiode As String
            Dim strlettrage As String

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                strperiode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yy"), CType(dtFinPeriode, Date).ToString("MM/dd/yy"))
                strlettrage = String.Format(" ")
                If Lettr = False Then
                    strlettrage = String.Format(" AND (MLettrage is null) ")
                End If

                Dim Sql As String = String.Format("SELECT PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                       "PlActi, Comptes.CLib, Lignes.LLib, SUM(Mouvements.MMtDeb) AS Debit, " & _
                       "SUM(Mouvements.MMtCre)  AS Credit, MAX(Mouvements.MD_C) AS D_C, " & _
                       "SUM(Mouvements.MQte1) AS Qt1, Sum(Mouvements.MQte2) AS Qt2, " & _
                       "MAX(Mouvements.MActCtr) AS MActCtr, MAX(Mouvements.MCptCtr) AS MCptCtr, " & _
                       "MAX(iif(MMtCre < 0 OR MMtDeb < 0, '-', ' ')) AS Signe, MAX(Comptes.CU1) AS CU1, " & _
                       "MAX(Comptes.CU2) AS CU2, 'O' AS Affichage, MAX(Mouvements.MLettrage) AS MLettrage, " & _
                       "MAX(SELECT   iif(isnull(sum(MMTDeb)),0,sum(MmtDeb))  from  (Mouvements INNER JOIN " & _
                     "Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND " & _
                     "Mouvements.MLig = Lignes.LLig) WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}' {4})  AS PlRepG_D, " & _
                       "MAX(select  iif(isnull(sum(MMTCre)),0,sum(MmtCre)) from  (Mouvements INNER JOIN " & _
                     "Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND " & _
                     "Mouvements.MLig = Lignes.LLig) WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}' {4})  AS PlRepG_C, " & _
                       "0 AS PlRepG_U1, " & _
                       "0 AS PlRepG_U2 " & _
                       "FROM (Comptes LEFT OUTER JOIN " & _
                       "(Lignes RIGHT OUTER JOIN " & _
                       "(Mouvements RIGHT OUTER JOIN " & _
                       "PlanComptable PL ON Mouvements.MActi = PL.PlActi AND Mouvements.MCpt = PL.PlCpt AND " & _
                       "Mouvements.MDossier = PL.PlDossier) ON " & _
                       "Lignes.LDossier = Mouvements.MDossier AND Lignes.LDate = Mouvements.MDate AND " & _
                       "Lignes.LLig = Mouvements.MLig AND " & _
                       "Lignes.LPiece = Mouvements.MPiece) ON Comptes.CCpt = PL.PlCpt AND " & _
                       "Comptes.CDossier = PL.PlDossier) " & _
                       "WHERE (PlDossier = '{0}') AND  (mcpt<>'48800000') and (PlCpt >= '{1}' {3} AND PlCpt <= '{2}' ) AND (LJournal<>'{5}' {4})" & _
                       "GROUP BY PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                       "PlACti, Comptes.CLib, Lignes.LLib, CU1, CU2 " & _
                       "ORDER BY PlDossier, PlCpt, PlActi, Mouvements.MDate, Mouvements.MPiece, Mouvements.MLig " & _
                        "Union SELECT PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                        "PlActi, Comptes.CLib, Lignes.LLib, 0 AS Debit, " & _
                        "0 AS Credit, MAX(Mouvements.MD_C) AS D_C, " & _
                        "SUM(Mouvements.MQte1) AS Qt1, Sum(Mouvements.MQte2) AS Qt2, " & _
                        "MAX(Mouvements.MActCtr) AS MActCtr, MAX(Mouvements.MCptCtr) AS MCptCtr, " & _
                        "MAX(iif(MMtCre < 0 OR MMtDeb < 0, '-', ' ')) AS Signe, MAX(Comptes.CU1) AS CU1, " & _
                        "MAX(Comptes.CU2) AS CU2, 'N' AS Affichage, MAX(Mouvements.MLettrage) AS MLettrage, " & _
                        "MAX(SELECT SUM(Mouvements.MMtDeb)  FROM  (Mouvements INNER JOIN Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND Mouvements.MLig = Lignes.LLig) " & _
                        "WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}') AS PlRepG_D, " & _
                        "MAX(select SUM(Mouvements.MMtCre)  FROM  (Mouvements INNER JOIN Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND Mouvements.MLig = Lignes.LLig) " & _
                        "WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}')  AS PlRepG_C, " & _
                        "0 AS PlRepG_U1, " & _
                        "0 AS PlRepG_U2 " & _
                        "FROM (Comptes LEFT OUTER JOIN " & _
                        "(Lignes RIGHT OUTER JOIN " & _
                        "(Mouvements RIGHT OUTER JOIN " & _
                        "PlanComptable PL ON Mouvements.MActi = PL.PlActi AND Mouvements.MCpt = PL.PlCpt AND " & _
                        "Mouvements.MDossier = PL.PlDossier) ON " & _
                        "Lignes.LDossier = Mouvements.MDossier AND Lignes.LDate = Mouvements.MDate AND " & _
                        "Lignes.LLig = Mouvements.MLig AND " & _
                        "Lignes.LPiece = Mouvements.MPiece) ON Comptes.CCpt = PL.PlCpt AND " & _
                        "Comptes.CDossier = PL.PlDossier) " & _
                        "WHERE (PlDossier = '{0}') AND (MCpt <> '48800000') AND (PlCpt >= '{1}' {3} AND PlCpt <= '{2}' ) AND (LJournal='{5}' {4}) " & _
                        "GROUP BY PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                        "PlACti, Comptes.CLib, Lignes.LLib, CU1, CU2 " & _
                        "ORDER BY PlDossier, PlCpt, PlActi, Mouvements.MDate, Mouvements.MPiece, Mouvements.MLig ", My.User.Name, cptDeb, cptFin, strperiode, strlettrage, My.Dossier.Principal.JournalAN)
                Dim dt As DataTable = ExecuteDataTable(Sql, conn)
                dt.TableName = "ImpGL"
                ds.Tables.Add(dt)
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptRptGL(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptGrandLivreQuantites.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx"), TextObject).Text = "Report au " & My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy") & " : "
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldCptPage")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldCptPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "false"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetailTVA")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetailTVA"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

        '25/08/10 : Ajout HG
        Public Shared Function PrepareRptRptGLPort(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptGrandLivrePortrait.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx"), TextObject).Text = "Report au " & My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy") & " : "
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldCptPage")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldCptPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "false"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetailTVA")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetailTVA"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

    End Class

    Public Class ImpGLAna
        Public Shared Function GetDataRptGLAna(ByVal cptDeb As String, ByVal cptFin As String, ByVal FActDeb As String, ByVal FActFin As String, ByVal dtFinPeriode _
                                As String, ByVal Lettr As Boolean) As DataSet
            Dim ds As New DataSet
            Dim strperiode As String
            Dim strlettrage As String

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                strperiode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#)", My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yy"), CType(dtFinPeriode, Date).ToString("MM/dd/yy"))
                strlettrage = String.Format(" ")
                If Lettr = False Then
                    strlettrage = String.Format(" AND (MLettrage is null) ")
                End If

                Dim Sql As String = String.Format("SELECT PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                       "PlActi, Comptes.CLib, Lignes.LLib, SUM(Mouvements.MMtDeb) AS Debit, " & _
                       "SUM(Mouvements.MMtCre)  AS Credit, MAX(Mouvements.MD_C) AS D_C, " & _
                       "SUM(Mouvements.MQte1) AS Qt1, Sum(Mouvements.MQte2) AS Qt2, " & _
                       "MAX(Mouvements.MActCtr) AS MActCtr, MAX(Mouvements.MCptCtr) AS MCptCtr, " & _
                       "MAX(iif(MMtCre < 0 OR MMtDeb < 0, '-', ' ')) AS Signe, MAX(Comptes.CU1) AS CU1, " & _
                       "MAX(Comptes.CU2) AS CU2, 'O' AS Affichage, MAX(Mouvements.MLettrage) AS MLettrage, " & _
                       "MAX(SELECT   iif(isnull(sum(MMTDeb)),0,sum(MmtDeb))  from  (Mouvements INNER JOIN " & _
                     "Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND " & _
                     "Mouvements.MLig = Lignes.LLig) WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}' {4})  AS PlRepG_D, " & _
                       "MAX(select  iif(isnull(sum(MMTCre)),0,sum(MmtCre)) from  (Mouvements INNER JOIN " & _
                     "Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND " & _
                     "Mouvements.MLig = Lignes.LLig) WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}' {4})  AS PlRepG_C, " & _
                       "0 AS PlRepG_U1, " & _
                       "0 AS PlRepG_U2, Alib " & _
                       "FROM Activites RIGHT JOIN (Lignes RIGHT JOIN (Comptes " & _
                        "LEFT JOIN (Mouvements RIGHT JOIN PlanComptable AS PL ON " & _
                        "(Mouvements.MDossier = PL.PlDossier) AND (Mouvements.MCpt = " & _
                        "PL.PlCpt) AND (Mouvements.MActi = PL.PlActi)) ON (Comptes.CCpt = " & _
                        "PL.PlCpt) AND (Comptes.CDossier = PL.PlDossier)) ON " & _
                        "(Lignes.LLig = Mouvements.MLig) AND (Lignes.LDate = " & _
                        "Mouvements.MDate) AND (Lignes.LPiece = Mouvements.MPiece) AND " & _
                        "(Lignes.LDossier = Mouvements.MDossier)) ON (Activites.AActi " & _
                        "= Mouvements.MActi) AND (Activites.ADossier = Mouvements.MDossier) " & _
                       "WHERE (PlDossier = '{0}') AND  (mcpt<>'48800000') and (PlCpt >= '{1}' {3} AND PlCpt <= '{2}' ) AND (PLActi>='{6}' AND PLActi<='{7}') AND (LJournal<>'{5}' {4})" & _
                       "GROUP BY PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                       "PlACti, Comptes.CLib, Lignes.LLib, CU1, CU2, Alib " & _
                       "ORDER BY PlDossier, PlCpt, PlActi, Mouvements.MDate, Mouvements.MPiece, Mouvements.MLig " & _
                        "Union SELECT PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                        "PlActi, Comptes.CLib, Lignes.LLib, 0 AS Debit, " & _
                        "0 AS Credit, MAX(Mouvements.MD_C) AS D_C, " & _
                        "SUM(Mouvements.MQte1) AS Qt1, Sum(Mouvements.MQte2) AS Qt2, " & _
                        "MAX(Mouvements.MActCtr) AS MActCtr, MAX(Mouvements.MCptCtr) AS MCptCtr, " & _
                        "MAX(iif(MMtCre < 0 OR MMtDeb < 0, '-', ' ')) AS Signe, MAX(Comptes.CU1) AS CU1, " & _
                        "MAX(Comptes.CU2) AS CU2, 'N' AS Affichage, MAX(Mouvements.MLettrage) AS MLettrage, " & _
                        "MAX(SELECT SUM(Mouvements.MMtDeb)  FROM  (Mouvements INNER JOIN Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND Mouvements.MLig = Lignes.LLig) " & _
                        "WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}') AS PlRepG_D, " & _
                        "MAX(select SUM(Mouvements.MMtCre)  FROM  (Mouvements INNER JOIN Lignes ON Mouvements.MDossier = Lignes.LDossier AND Mouvements.MPiece = Lignes.LPiece AND Mouvements.MDate = Lignes.LDate AND Mouvements.MLig = Lignes.LLig) " & _
                        "WHERE  mouvements.mdossier = pl.pldossier AND mouvements.mcpt = PL.plcpt AND LJOURNAL='{5}')  AS PlRepG_C, " & _
                        "0 AS PlRepG_U1, " & _
                        "0 AS PlRepG_U2, Alib " & _
                        "FROM Activites RIGHT JOIN (Lignes RIGHT JOIN (Comptes LEFT JOIN " & _
                        "(Mouvements RIGHT JOIN PlanComptable AS PL ON (Mouvements.MDossier = " & _
                        "PL.PlDossier) AND (Mouvements.MCpt = PL.PlCpt) AND (Mouvements.MActi = " & _
                        "PL.PlActi)) ON (Comptes.CCpt = PL.PlCpt) AND (Comptes.CDossier = " & _
                        "PL.PlDossier)) ON (Lignes.LLig = Mouvements.MLig) AND (Lignes.LDate = " & _
                        "Mouvements.MDate) AND (Lignes.LPiece = Mouvements.MPiece) AND " & _
                        "(Lignes.LDossier = Mouvements.MDossier)) ON (Activites.AActi = " & _
                        "Mouvements.MActi) AND (Activites.ADossier = Mouvements.MDossier) " & _
                        "WHERE (PlDossier = '{0}') AND (MCpt <> '48800000') AND (PlCpt >= '{1}' {3} AND PlCpt <= '{2}' ) AND (PLActi>='{6}' AND PLActi<='{7}') AND (LJournal='{5}' {4}) " & _
                        "GROUP BY PlDossier, Mouvements.MPiece, Mouvements.MDate, Mouvements.MLig, PlCpt, " & _
                        "PlACti, Comptes.CLib, Lignes.LLib, CU1, CU2, Alib " & _
                        "ORDER BY PlDossier, PlCpt, PlActi, Mouvements.MDate, Mouvements.MPiece, Mouvements.MLig ", My.User.Name, cptDeb, cptFin, strperiode, strlettrage, My.Dossier.Principal.JournalAN, FActDeb, FActFin)
                Dim dt As DataTable = ExecuteDataTable(Sql, conn)
                dt.TableName = "ImpGL"
                ds.Tables.Add(dt)
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptRptGLAna(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptGrandLivreQuantites.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx"), TextObject).Text = "Report au " & My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy") & " : "
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldCptPage")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldCptPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "false"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetailTVA")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetailTVA"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

        '25/08/10 : Ajout HG
        Public Shared Function PrepareRptRptGLAnaPort(ByVal ds As DataSet, ByVal dtFinPeriode As String, ByVal FDeb As String, ByVal FFin As String) As ReportDocument
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptGrandLivreAnaPortrait.rpt", ds)
            Dim strLibellePeriode As String = String.Format(My.Resources.Strings.Etats_LibPeriode, My.Dossier.Principal.DateDebutEx.ToString("MM/dd/yyyy"), dtFinPeriode)
            Dim strLibelleCpte As String = String.Format("Compte du {0} au {1}", FDeb, FFin)
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxRpDateDebEx"), TextObject).Text = "Report au " & My.Dossier.Principal.DateDebutEx.ToString("dd/MM/yyyy") & " : "
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldCptPage")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldCptPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "false"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("FldDetailTVA")) Is FieldObject Then
                CType(CType(report.ReportDefinition.ReportObjects.Item("FldDetailTVA"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxtCpte")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxtCpte"), TextObject).Text = strLibelleCpte
            End If
            Return report
        End Function

    End Class

    Public Class ImpRecapTVA

        Public Shared Function GetDataRptRecapTVA(ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) _
        As DataSet
            Dim ds As New DataSet
            Dim strPeriode As String
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                'Def fourchette date
                strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#) ", _
                    CType(dtDebPeriode, Date).ToString("MM/dd/yy"), _
                    CType(dtFinPeriode, Date).ToString("MM/dd/yy"))
                Dim sql As String = String.Format("SELECT '{0}' AS mdossier, TVARecap.TRLigne, TVARecap.TRLib, TVARecap.TRJournal, TVARecap.TRRecup AS Recap,  " & _
                    "[MMtDeb]AS mmtDeb, [MMtCre] as MmtCre, TVA.TLigne,  (SELECT     MD_C " & _
                "   FROM(Mouvements) " & _
                     "   WHERE     (MDossier =l.ldossier) AND (MDate =l.ldate) AND (MPiece =l.lpiece) AND (MLig =l.llig) AND (MOrdre = 2)) as D_C, MOrdre, MPiece " & _
                    "FROM (((Exploitations INNER JOIN (Dossiers INNER JOIN Pieces ON Dossiers.DDossier = " & _
                    "Pieces.PDossier) ON Exploitations.EExpl = Dossiers.DExpl) INNER JOIN (Lignes l INNER " & _
                    "JOIN Mouvements ON (l.LLig = Mouvements.MLig) AND (l.LDate = " & _
                    "Mouvements.MDate) AND (l.LPiece = Mouvements.MPiece) AND (l.LDossier = " & _
                    "Mouvements.MDossier)) ON (Pieces.PDate = l.LDate) AND (Pieces.PPiece = " & _
                    "l.LPiece) AND (Pieces.PDossier = l.LDossier)) INNER JOIN TVA ON " & _
                    " (l.LMtTVA = TVA.TTVA or l.LTVA = TVA.TTVA)) INNER JOIN TVARecap ON (TVA.TLigne = TVARecap.TRLigne) " & _
                    "AND (TVA.TJournal = TVARecap.TRJournal)  " & _
                   "WHERE  Exploitations.EExpl='{1}' {2}  " & _
                 "UNION SELECT     '{0}' AS mdossier, TRLigne, TRLib, TRJournal, TRRecup AS Recap, 0 AS MMtDeb, 0 AS MMtCre, 0 AS TLigne, NULL AS D_C, 0 as MOrdre, 0 as MPiece " & _
                    "FROM(TVARecap) " & _
                 "WHERE     (TRLigne <> 0)", My.User.Name, Left(My.User.Name, 6), strPeriode)
                Dim dt As DataTable = ExecuteDataTable(sql, conn)
                dt.TableName = "ImpRecapTVA"
                ds.Tables.Add(dt)
                ' 
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptRecapTVA(ByVal ds As DataSet, ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) As ReportDocument
            Dim strLibellePeriode As String
            strLibellePeriode = String.Format(My.Resources.Strings.Etats_LibPeriode, dtDebPeriode, dtFinPeriode)
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptRecapTVA.rpt", ds)
            '  If TypeOf (report.ReportDefinition.ReportObjects.Item("FldStPage")) Is FieldObject Then
            'CType(CType(report.ReportDefinition.ReportObjects.Item("FldStPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            '   End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            Return report
        End Function
    End Class

    Public Class ImpTVAVente

        Public Shared Function GetDataRptTVAVente(ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) _
        As DataSet
            Dim ds As New DataSet
            Dim strPeriode As String
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                'Def fourchette date
                strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#) ", _
                    CType(dtDebPeriode, Date).ToString("MM/dd/yy"), _
                    CType(dtFinPeriode, Date).ToString("MM/dd/yy"))
                Dim sql As String = String.Format("SELECT Mouvements.MDossier, Mouvements.MDate, " & _
                    "Mouvements.MPiece, Pieces.Libelle, Sum(IIf([MOrdre]=3,[MMTCre],0)) AS HT, " & _
                    "Sum(IIf([MOrdre]=2,[MMTCRE],0)) AS TVA, Sum(IIf([MOrdre]=1,[MMTdeb],0)) AS TTC, " & _
                    "TVARecap.TRLib, TVA.TJournal " & _
                    "FROM ((Pieces INNER JOIN (Lignes INNER JOIN Mouvements ON (Lignes.LLig = " & _
                    "Mouvements.MLig) AND " & _
                    "(Lignes.LDate = Mouvements.MDate) AND (Lignes.LPiece = Mouvements.MPiece) " & _
                    "AND (Lignes.LDossier = Mouvements.MDossier)) ON " & _
                    "(Pieces.PDate = Lignes.LDate) AND (Pieces.PPiece = Lignes.LPiece) AND " & _
                    "(Pieces.PDossier = Lignes.LDossier)) INNER JOIN TVA " & _
                    "ON Lignes.LMtTVA = TVA.TTVA) INNER JOIN TVARecap ON (TVA.TLigne = " & _
                    "TVARecap.TRLigne) AND (TVA.TJournal = TVARecap.TRJournal) " & _
                    "GROUP BY Mouvements.MDossier, TVARecap.TRLigne,Mouvements.MDate, " & _
                    "Mouvements.MPiece,  Pieces.Libelle, Lignes.LLib, TVA.TJournal, Lignes.LMtTVA, " & _
                    "TVARecap.TRLib " & _
                    "HAVING (Mouvements.MDossier = '{0}') And (TVA.TJournal = 'V')  {1} " & _
                    "ORDER BY TVA.TJournal,TVARecap.TRLigne, mouvements.MDate, Mouvements.MPiece ", My.User.Name, strPeriode)
                Dim dt As DataTable = ExecuteDataTable(sql, conn)
                dt.TableName = "ImpTVAVente"
                ds.Tables.Add(dt)
                ' 
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptTVAVente(ByVal ds As DataSet, ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) As ReportDocument
            Dim strLibellePeriode As String
            strLibellePeriode = String.Format(My.Resources.Strings.Etats_LibPeriode, dtDebPeriode, dtFinPeriode)
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptTVAVente.rpt", ds)
            '  If TypeOf (report.ReportDefinition.ReportObjects.Item("FldStPage")) Is FieldObject Then
            'CType(CType(report.ReportDefinition.ReportObjects.Item("FldStPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            '   End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            Return report
        End Function
    End Class

    Public Class ImpTVAAchat

        Public Shared Function GetDataRptTVAAchat(ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) _
        As DataSet
            Dim ds As New DataSet
            Dim strPeriode As String
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                'Def fourchette date
                strPeriode = String.Format(" And (MDate>=#{0}# And MDate<=#{1}#) ", _
                    CType(dtDebPeriode, Date).ToString("MM/dd/yy"), _
                    CType(dtFinPeriode, Date).ToString("MM/dd/yy"))
                Dim sql As String = String.Format("SELECT Mouvements.MDossier, Mouvements.MDate, " & _
                    "Mouvements.MPiece, Pieces.Libelle, Sum(IIf([MOrdre]=1,[MMTDeb],0)) AS HT, " & _
                    "Sum(IIf([MOrdre]=2,[MMTDeb],0)) AS TVA, Sum(IIf([MOrdre]=3,[MMTCre],0)) AS TTC, " & _
                    "TVARecap.TRLib, TVA.TJournal " & _
                    "FROM ((Pieces INNER JOIN (Lignes INNER JOIN Mouvements ON (Lignes.LLig = " & _
                    "Mouvements.MLig) AND " & _
                    "(Lignes.LDate = Mouvements.MDate) AND (Lignes.LPiece = Mouvements.MPiece) " & _
                    "AND (Lignes.LDossier = Mouvements.MDossier)) ON " & _
                    "(Pieces.PDate = Lignes.LDate) AND (Pieces.PPiece = Lignes.LPiece) AND " & _
                    "(Pieces.PDossier = Lignes.LDossier)) INNER JOIN TVA " & _
                    "ON Lignes.LMtTVA = TVA.TTVA) INNER JOIN TVARecap ON (TVA.TLigne = " & _
                    "TVARecap.TRLigne) AND (TVA.TJournal = TVARecap.TRJournal) " & _
                    "GROUP BY Mouvements.MDossier, TVARecap.TRLigne,Mouvements.MDate, " & _
                    "Mouvements.MPiece,  Pieces.Libelle, Lignes.LLib, TVA.TJournal, Lignes.LMtTVA, " & _
                    "TVARecap.TRLib " & _
                    "HAVING (Mouvements.MDossier = '{0}') And (TVA.TJournal = 'A')  {1} " & _
                    "ORDER BY TVA.TJournal, TVARecap.TRLigne, mouvements.MDate, Mouvements.MPiece ", My.User.Name, strPeriode)
                Dim dt As DataTable = ExecuteDataTable(sql, conn)
                dt.TableName = "ImpTVAVente"
                ds.Tables.Add(dt)
                ' 
            End Using
            Return ds
        End Function

        Public Shared Function PrepareRptTVAAchat(ByVal ds As DataSet, ByVal dtDebPeriode As String, ByVal dtFinPeriode As String) As ReportDocument
            Dim strLibellePeriode As String
            strLibellePeriode = String.Format(My.Resources.Strings.Etats_LibPeriode, dtDebPeriode, dtFinPeriode)
            Dim report As ReportDocument = EcranCrystal.ChargerReport("rptTVAVente.rpt", ds)
            '  If TypeOf (report.ReportDefinition.ReportObjects.Item("FldStPage")) Is FieldObject Then
            'CType(CType(report.ReportDefinition.ReportObjects.Item("FldStPage"), FieldObject).DataSource, FormulaFieldDefinition).Text = "True"
            '   End If
            If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strLibellePeriode
            End If
            Return report
        End Function
    End Class

    Class UtilImp
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
                    CType(report.ReportDefinition.ReportObjects.Item("TxExercice"), TextObject).Text = _
                    String.Format(My.Resources.Strings.ExerciceDuDate0AuDate1, My.Dossier.Principal.DateDebutEx, My.Dossier.Principal.DateFinEx)
                End If
            End If
            obj = report.ReportDefinition.ReportObjects.Item("TxDtEdi")
            If Not obj Is Nothing Then
                If TypeOf (report.ReportDefinition.ReportObjects.Item("TxDtEdi")) Is TextObject Then
                    CType(report.ReportDefinition.ReportObjects.Item("TxDtEdi"), TextObject).Text = String.Format(My.Resources.Strings.Etats_EditeAvecAgrigestEDI, Today)
                End If
            End If
        End Sub
    End Class



    Public Class PrepaTable

        Public Shared Sub RecopierTVA()
            'If FrMDI.Parametres.CheminAccesBase = FrMDI.Parametres.CheminAccesBasePlanType Then Exit Sub
            Dim cn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim cnPlanType As New OleDb.OleDbConnection(My.Settings.dbPlantypeCOConnectionString)
            Try
                cn.Open()
                cnPlanType.Open()
                RecopierTable(cnPlanType, cn, "TVARecap")
                RecopierTable(cnPlanType, cn, "TVA")
            Catch ex As Exception
                Throw ex
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                If cnPlanType.State <> ConnectionState.Closed Then cnPlanType.Close()
            End Try
        End Sub

        Public Shared Sub RecopierTable(ByVal cnSource As OleDb.OleDbConnection, ByVal cnDest As OleDb.OleDbConnection, ByVal tableName As String)
            'Charger la table source pour avoir les infos
            Dim dt As New DataTable
            Dim dta As New OleDb.OleDbDataAdapter(String.Format("Select * from {0}", tableName), cnSource)
            dta.Fill(dt)

            'Supprimer une eventuelle table existante
            Try
                Call New OleDb.OleDbCommand(String.Format("DROP TABLE {0}", tableName), cnDest).ExecuteNonQuery()
            Catch ex As OleDb.OleDbException
            End Try

            'Créer la table
            Dim sql As String = GetSqlCreate(dt, tableName)
            Debug.WriteLine(sql)
            Call New OleDb.OleDbCommand(sql, cnDest).ExecuteNonQuery()

            'Créer les lignes
            sql = GetSqlInsert(dt, tableName)
            Debug.WriteLine(sql)
            For Each dr As DataRow In dt.Rows
                Dim insert As String = String.Format(sql, FormatValues(dr.ItemArray))
                Debug.WriteLine(insert)
                Call New OleDb.OleDbCommand(insert, cnDest).ExecuteNonQuery()
            Next
        End Sub

        Public Shared Function GetSqlCreate(ByVal dt As DataTable, ByVal tablename As String) As String
            Dim cols(dt.Columns.Count - 1) As String
            For i As Integer = 0 To dt.Columns.Count - 1
                With dt.Columns(i)
                    cols(i) = String.Format("[{0}] {1}", .ColumnName, GetSqlType(.DataType))
                End With
            Next
            Return String.Format("CREATE TABLE [{0}] ({1})", tablename, String.Join(",", cols))
        End Function

        Public Shared Function GetSqlInsert(ByVal dt As DataTable, ByVal tablename As String) As String
            Dim cols(dt.Columns.Count - 1) As String
            Dim values(dt.Columns.Count - 1) As String
            For i As Integer = 0 To dt.Columns.Count - 1
                With dt.Columns(i)
                    cols(i) = String.Format("[{0}]", .ColumnName)
                    values(i) = "{" & i & "}"
                End With
            Next
            Return String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tablename, String.Join(",", cols), String.Join(",", values))
        End Function

        Public Shared Function GetSqlType(ByVal t As Type) As String
            If t Is GetType(String) Then : Return "Varchar(255)"
            ElseIf t Is GetType(Double) Then : Return "double"
            ElseIf t Is GetType(Single) Then : Return "single"
            ElseIf t Is GetType(Decimal) Then : Return "numeric"
            ElseIf t Is GetType(Integer) Then : Return "int"
            ElseIf t Is GetType(Long) Then : Return "long"
            ElseIf t Is GetType(Short) Then : Return "short"
            ElseIf t Is GetType(Date) Then : Return "date"
            ElseIf t Is GetType(Boolean) Then : Return "bit"
            ElseIf t Is GetType(Byte) Then : Return "byte"
            Else : Return "Varchar(255)"
            End If
        End Function

        Public Shared Function FormatValues(ByVal values() As Object) As String()
            Dim res(values.Length - 1) As String
            For i As Integer = 0 To values.Length - 1
                res(i) = FormatValue(values(i))
            Next
            Return res
        End Function

        Public Shared Function FormatValue(ByVal value As Object) As String
            If value Is Nothing OrElse IsDBNull(value) Then
                Return "NULL"
            ElseIf TypeOf value Is String Then
                Return String.Format("'{0}'", CStr(value).Replace("'", "''"))
            ElseIf TypeOf value Is Date Then
                Return String.Format("#{MM/dd/yyyy HH:mm:ss}#", value)
            ElseIf TypeOf value Is Boolean Then
                Return CStr(IIf(CBool(value), "True", "False"))
            ElseIf TypeOf value Is Double OrElse TypeOf value Is Single OrElse TypeOf value Is Decimal Then
                Return value.ToString.Replace(",", ".")
            Else
                Return String.Format("{0}", value)
            End If
        End Function
    End Class

End Namespace
