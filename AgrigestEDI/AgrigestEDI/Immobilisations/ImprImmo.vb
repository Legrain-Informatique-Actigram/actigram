Imports CrystalDecisions.CrystalReports.Engine

Namespace Immobilisations
    Public Class ImprImmo

        Public Enum TypeRptImmo
            SimulAmort
            RecapImmoParClasse
            TabImmo
            TabImmoParAct
            TabDepartImmo
            TabCessionImmo
            TabAmortDerog
            PassageReel
            TabCalculsProv
        End Enum

#Region "Méthodes partagées"
        Public Shared Function GetRptName(ByVal typeRptImmo As ImprImmo.TypeRptImmo) As String
            Dim rptName As String = String.Empty

            Select Case typeRptImmo
                Case ImprImmo.TypeRptImmo.SimulAmort
                    rptName = "rptSimulAmort.rpt"
                Case ImprImmo.TypeRptImmo.RecapImmoParClasse
                    rptName = "EtTabClaImmo.rpt"
                Case ImprImmo.TypeRptImmo.TabImmo
                    rptName = "EtTabimmo.rpt"
                Case ImprImmo.TypeRptImmo.TabImmoParAct
                    rptName = "EtTabimmoAct.rpt"
                Case ImprImmo.TypeRptImmo.TabDepartImmo
                    rptName = "EtTabDebimmo.rpt"
                Case ImprImmo.TypeRptImmo.TabCessionImmo
                    rptName = "EtTabCessImmo.rpt"
                Case ImprImmo.TypeRptImmo.TabAmortDerog
                    rptName = "EtTabAmortDer.rpt"
                Case ImprImmo.TypeRptImmo.PassageReel
                    rptName = "EtPassReelImmo.rpt"
                Case ImprImmo.TypeRptImmo.TabCalculsProv
                    rptName = "EtTabCalImmo.rpt"
            End Select

            Return rptName
        End Function

        Public Shared Function PrepareRpt(ByVal ds As DataSet, ByVal typeRptImmo As ImprImmo.TypeRptImmo) As ReportDocument
            Dim rptName As String = String.Empty

            rptName = ImprImmo.GetRptName(typeRptImmo)

            Dim report As ReportDocument = EcranCrystal.ChargerReport(rptName, ds)

            Return report
        End Function

        Public Shared Function PrepareRpt(ByVal dt As DataTable, ByVal typeRptImmo As ImprImmo.TypeRptImmo) As ReportDocument
            Dim rptName As String = String.Empty

            rptName = ImprImmo.GetRptName(typeRptImmo)

            Dim report As ReportDocument = EcranCrystal.ChargerReport(rptName, dt)

            Return report
        End Function

        Public Shared Sub PrintRpt(ByVal typeRptImmo As ImprImmo.TypeRptImmo)
            Dim ds As DataSet = Nothing

            Select Case typeRptImmo
                Case ImprImmo.TypeRptImmo.RecapImmoParClasse
                    ds = Immobilisations.ImprImmo.GetDataRptRecapImmoParClasse()
                Case ImprImmo.TypeRptImmo.TabImmo, ImprImmo.TypeRptImmo.TabImmoParAct
                    ds = Immobilisations.ImprImmo.GetDataRptTabImmo()
                Case ImprImmo.TypeRptImmo.TabDepartImmo
                    ds = Immobilisations.ImprImmo.GetDataRptTabDepartImmo()
                Case ImprImmo.TypeRptImmo.TabCessionImmo
                    ds = Immobilisations.ImprImmo.GetDataRptTabCessionImmo()
                Case ImprImmo.TypeRptImmo.TabAmortDerog
                    ds = Immobilisations.ImprImmo.GetDataRptTabAmortDerog()
                Case ImprImmo.TypeRptImmo.PassageReel
                    ds = Immobilisations.ImprImmo.GetDataRptPassageReel()
                Case ImprImmo.TypeRptImmo.TabCalculsProv
                    ds = Immobilisations.ImprImmo.GetDataRptTabCalculsProv()
            End Select

            Using report As ReportDocument = Immobilisations.ImprImmo.PrepareRpt(ds, typeRptImmo)
                Immobilisations.ImprImmo.AffichDonneesGen(report)

                Using fr As New EcranCrystal(report)
                    fr.ShowDialog()
                End Using
            End Using
        End Sub

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

        Public Shared Function GetDataRptRecapImmoParClasse() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT Immobilisations.IDossier, Immobilisations.ICpt, " & _
                         "MAX(LEFT(Immobilisations.ICpt, 4)) AS ICatImmo,MAX(iif(Immobilisations.IDtAcquis < #" & _
                         "{0}#, Immobilisations.IValAcquis, " & _
                         "0)) AS IValDebEx, MAX(iif(Immobilisations.IDtAcquis >= #" & _
                         "{0}#, Immobilisations.IValAcquis, " & _
                         "0)) AS IValAugEx,  MAX(iif(NOT ISNULL(IDtCess), immobilisations.IValAcquis, 0)) AS " & _
                         "IValDimEx, MAX(iif(NOT ISNULL(IDtCess), immobilisations.IAmtCumTot + Immobilisations.IAmtExTot, 0)) AS IValDimAmtEx," & _
                         "MAX(Immobilisations.IAmtExMax) AS IAMtExMax, MAX(Immobilisations.IAmtExTot) AS " & _
                         "IAmtExTot, MAX(Immobilisations.IAmtCumTot) AS IAmtCumTot, " & _
                         "MAX(Immobilisations.IValResid) AS IValResid, MAX(Comptes.CLib) AS Clib, " & _
                         "MAX(Immobilisations.IAmtExLin) AS IAmtExLin, MAX(ITypAmt) AS ITypAmt, " & _
                         "MAX(IDerogatoire) as IDerogatoire, max(IAmtCumLin) as IAmtCumLin " & _
                         "FROM (Immobilisations INNER JOIN " & _
                         "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt = " & _
                         "Comptes.CCpt) " & _
                         "WHERE IDossier='{1}' " & _
                         "GROUP BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                         "Immobilisations.IOrdre " & _
                         "ORDER BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                         "Immobilisations.IOrdre", String.Format("{0:MM/dd/yy}", My.Dossier.Principal.DateDebutEx), My.User.Name)

                FillDataTable(ds.ImpTabClaImmo, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptTabImmo() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT IDossier, ICpt, IActi, IOrdre, MAX(ILib) AS ILib, " & _
                            "MAX(ITypAmt) AS ITypAmt, " & _
                            "MAX(IValAcquis) AS IValAcquis, MAX(IDtAcquis) AS IDtAcquis, MAX(IDtForf) " & _
                            "AS IDtForf, MAX(iif(Immobilisations.IDtAcquis <> Immobilisations.IDtForf, " & _
                             "Immobilisations.IDtForf, Immobilisations.IDtAcquis)) AS IDtOrig, MAX(IDuree) " & _
                             "AS IDuree, MAX(Immobilisations.IAmtExMax) AS IAMtExMax, MAX(Immobilisations.IAmtExTot) " & _
                             "AS IAmtExTot, MAX(Immobilisations.IAmtCumTot) AS IAmtCumTot, " & _
                             "MAX(Immobilisations.IValResid) AS IValResid, MAX(Immobilisations.IDureeResid) " & _
                             "AS IDureeResid, Max(Immobilisations.ITVA) As ITVA, Max(Comptes.Clib) As Clib, " & _
                             "MAX(immobilisations.ICoeff) AS ICoeff, MAX(immobilisations.IDtCess) AS IDtCess, " & _
                             "MAX(immobilisations.IAmtExLin) AS IAmtExLin, MAX(immobilisations.IDerogatoire) " & _
                             "AS IDerogatoire, max(ALib) as ALib, max(IValCess) as IValCess, " & _
                             " '{0}' as IDtDebEx " & _
                             "FROM ((Immobilisations INNER JOIN " & _
                              "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt " & _
                              "= Comptes.CCpt) INNER JOIN " & _
                              "Activites ON Immobilisations.IActi = Activites.AActi AND Immobilisations.IDossier " & _
                              "= Activites.ADossier) " & _
                              " WHERE  IDossier='{1}' " & _
                              "GROUP BY Idossier, ICpt, IActi, IOrdre " & _
                             "ORDER BY Idossier, ICpt, IActi, IOrdre ", String.Format("{0:MM/dd/yy}", My.Dossier.Principal.DateDebutEx), My.User.Name)

                FillDataTable(ds.ImpTabImmo, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptTabDepartImmo() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT IDossier, ICpt, IActi, IOrdre, MAX(ILib) AS ILib, MAX(ITypAmt) AS ITypAmt, " & _
                         "MAX(IValAcquis) AS IValAcquis, MAX(IDtAcquis) AS IDtAcquis, MAX(IDtForf) " & _
                         "AS IDtForf, MAX(iif(Immobilisations.IDtAcquis <> Immobilisations.IDtForf, " & _
                         "Immobilisations.IDtForf, Immobilisations.IDtAcquis)) AS IDtOrig, MAX(IDuree) " & _
                         "AS IDuree, MAX(Immobilisations.IAmtExMax) AS IAMtExMax, MAX(Immobilisations.IAmtExTot) " & _
                         "AS IAmtExTot, MAX(Immobilisations.IAmtCumTot) AS IAmtCumTot, " & _
                         "MAX(IValAcquis-Immobilisations.IAmtCumTot) AS IValResid, MAX(Immobilisations.IDureeResid) " & _
                         "AS IDureeResid, Max(Immobilisations.ITVA) As ITVA, Max(Comptes.Clib) As Clib, " & _
                         "MAX(immobilisations.ICoeff) AS ICoeff, MAX(immobilisations.IDtCess) AS IDtCess, " & _
                         "MAX(immobilisations.IAmtExLin) AS IAmtExLin, MAX(immobilisations.IDerogatoire) " & _
                         "AS IDerogatoire  " & _
                         "FROM (Immobilisations INNER JOIN " & _
                         "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt = " & _
                         "Comptes.CCpt) " & _
                         " WHERE IDossier='{0}' And (IDtCess is null or IDtCess>#{1}#) and IDtAcquis<#{1}# " & _
                         "GROUP BY Idossier, ICpt, IActi, IOrdre " & _
                         "ORDER BY Idossier, ICpt, IActi, IOrdre ", My.User.Name, String.Format("{0:MM/dd/yy}", My.Dossier.Principal.DateDebutEx))

                FillDataTable(ds.ImpTabDepImmo, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptTabCessionImmo() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                         "Immobilisations.IOrdre, MAX(Immobilisations.ILib) AS ILib, " & _
                         "MAX(Immobilisations.ITypAmt) AS ITypAmt, MAX(Immobilisations.IValAcquis) " & _
                         "AS IValAcquis, MAX(Immobilisations.IDtAcquis) AS IDtAcquis, " & _
                         "MAX(Immobilisations.IDuree) AS IDuree, MAX(Immobilisations.IValResid) AS IValResid, " & _
                         "MAX(Immobilisations.IDureeResid) AS IDureeResid, MAX(Comptes.CLib) AS Clib,  MAX(Immobilisations.IAmtCumTot) AS " & _
                         "IAmtCumTot, MAX(Immobilisations.ICoeff) AS ICoeff, MAX(Immobilisations.IDtCess) AS IDtCession, " & _
                         "MAX(Immobilisations.IPlusValCt) AS IPlusValCT, MAX(Immobilisations.IPlusValLg) AS " & _
                         "IPlusValLg, MAX(Immobilisations.IDtForf) AS IDtForf, MAX(Immobilisations.IValForf) " & _
                         "AS IValForf, MAX(Immobilisations.IValVenale) AS IValVenale, " & _
                         "MAX(Immobilisations.IValLeasing) AS IValLeasing, " & _
                         "MAX(Immobilisations.IValCess) as IValCession, MAx(IAmtExTot) as IAmtExTot  " & _
                         "FROM (Immobilisations INNER JOIN " & _
                         "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt = " & _
                         "Comptes.CCpt) " & _
                         "WHERE IDossier='{0}' AND not isnull(IDtCess) AND " & _
                         "Immobilisations.ICpt>='20000000' " & _
                         "GROUP BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                         "Immobilisations.IOrdre " & _
                         "ORDER BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                         "Immobilisations.IOrdre", My.User.Name)

                FillDataTable(ds.ImpTabCessImmo, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptTabAmortDerog() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                     "Immobilisations.IOrdre, MAX(Immobilisations.ILib) AS ILib, " & _
                     "MAX(Immobilisations.ITypAmt) AS ITypAmt, MAX(Immobilisations.IValAcquis) AS " & _
                     "IValAcquis, MAX(Immobilisations.IDtAcquis) AS IDtAcquis, " & _
                     "MAX(Immobilisations.IDuree) AS IDuree, MAX(Immobilisations.IAmtExMax) AS IAMtExMax, " & _
                     "MAX(Immobilisations.IAmtExTot) AS IAmtExTot, MAX(Immobilisations.IAmtCumTot) AS " & _
                     "IAmtCumTot, MAX(Immobilisations.IValResid) AS IValResid, " & _
                     "MAX(Immobilisations.IDureeResid) AS IDureeResid, MAX(Comptes.CLib) AS Clib, MAX " & _
                     "(Immobilisations.ICoeff) AS ICoeff, MAX(Immobilisations.IAmtExLin) AS IAmtExLin, MAX(Immobilisations.IAmtCumLin) AS " & _
                     "IAmtCumLin FROM (Immobilisations INNER JOIN " & _
                     "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt = " & _
                     "Comptes.CCpt) " & _
                     "WHERE IDossier='{0}' and " & _
                     "Immobilisations.ITypAmt='D' " & _
                     "GROUP BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                     "Immobilisations.IOrdre " & _
                     "ORDER BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                     "Immobilisations.IOrdre", My.User.Name)

                FillDataTable(ds.ImpAmortDer, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptPassageReel() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                    "Immobilisations.IOrdre, MAX(Immobilisations.ILib) AS ILib, " & _
                    "MAX(Immobilisations.ITypAmt) AS ITypAmt, MAX(Immobilisations.IValAcquis) " & _
                    "AS IValAcquis, MAX(Immobilisations.IDtForf) AS IDtForf, " & _
                    "MAX(Immobilisations.IDureeResid) AS IDureeResid, MAX(Immobilisations.IAmtExTot) AS " & _
                    "IAmtExTot, MAX(Comptes.CLib) AS Clib, MAX(Immobilisations.ICoeff) AS ICoeff," & _
                    "MAX(Immobilisations.IDerogatoire) AS IDerogatoire, MAX(Immobilisations.IValForf) " & _
                    "AS IValForf, MAX(Immobilisations.IValVenale) AS IvalVenale, MAX(Immobilisations.IDuree) " & _
                    "AS IDuree, MAX(Immobilisations.IValResid) " & _
                    "AS IValResid, MAX(Immobilisations.IValLeasing) AS IValLeasing, MAX(IValNetFisc) as IValNetFisc, MAX(IDtAcquis) as IDtAcquis  " & _
                    "FROM (Immobilisations INNER JOIN " & _
                    "Comptes ON Immobilisations.IDossier = Comptes.CDossier AND Immobilisations.ICpt = " & _
                    "Comptes.CCpt) " & _
                    "WHERE IDossier='{0}' AND not isnull(IDtForf)  AND " & _
                    "Immobilisations.ICpt>='20000000' " & _
                    "GROUP BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                    "Immobilisations.IOrdre " & _
                    "ORDER BY Immobilisations.IDossier, Immobilisations.ICpt, Immobilisations.IActi, " & _
                    "Immobilisations.IOrdre", My.User.Name)

                FillDataTable(ds.ImpPassReelImmo, sql, conn)
            End Using

            Return ds
        End Function

        Public Shared Function GetDataRptTabCalculsProv() As DataSet
            Dim ds As New ImprImmoDataSet

            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()

                Dim sql As String = String.Format("SELECT IDossier, ICpt, IActi, IOrdre, MAX(ILib) AS ILib, MAX(ITypAmt) AS ITypAmt, " & _
                               "MAX(IValAcquis) AS IValAcquis, MAX(IDtAcquis) AS IDtAcquis, MAX(IDuree) AS IDuree, " & _
                               "MAX(Immobilisations.IAmtExMax) AS IAMtExMax, " & _
                               "MAX(Immobilisations.IAmtExTot) AS IAmtExTot, " & _
                               "MAX(Immobilisations.IAmtExMin) AS IAmtExMin, Comptes.CLib " & _
                               "FROM (Immobilisations INNER JOIN " & _
                               "Comptes ON Immobilisations.IDossier = Comptes.CDossier  " & _
                               "AND Immobilisations.ICpt = Comptes.CCpt) " & _
                               "WHERE     IDossier = '{0}' " & _
                               "GROUP BY Idossier, ICpt, IActi, IOrdre,CLib " & _
                               "ORDER BY Idossier, ICpt, IActi, IOrdre,CLib", My.User.Name)

                FillDataTable(ds.ImpCalProv, sql, conn)
            End Using

            Return ds
        End Function
#End Region

    End Class
End Namespace
