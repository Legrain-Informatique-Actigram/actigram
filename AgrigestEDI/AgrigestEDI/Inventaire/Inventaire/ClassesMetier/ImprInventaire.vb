Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Namespace Inventaire.ClassesMetier
    Public Class ImprInventaire

#Region "Méthodes partagées"
        Public Shared Function GetDataByTypeInvEtINVGDossier(ByVal codeTypeInventaire As String, ByVal INVGDossier As String) As DataSetImpression
            Dim impressionDS As New DataSetImpression

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                oleDbConn.Open()

                Dim sql As String = String.Format("SELECT InventaireGroupes.INVGDossier, " & _
                                                  "InventaireGroupes.INVGCode, InventaireGroupes.INVGLib, " & _
                                                  "InventaireGroupes.INVGOrdre, InventaireLignes.INVLLig, " & _
                                                  "InventaireLignes.INVLQte, InventaireLignes.INVLPrixUnit, " & _
                                                  "InventaireGroupes.INVGUnite, InventaireLignes.INVLLib, " & _
                                                  "InventaireGroupes.INVGTypeInventaire, " & _
                                                  "InventaireGroupes.INVGDecote, InventaireGroupes.INVGCpt, " & _
                                                  "InventaireGroupes.INVGActi, InventaireLignes.INVLCoutOutil, " & _
                                                  "InventaireLignes.INVLCoutTracteur, InventaireLignes.INVLTempsH," & _
                                                  "InventaireLignes.INVLTempsMin, InventaireLignes.INVLNbHa, " & _
                                                  "InventaireLignes.INVLValPdtenTerre, InventaireLignes.INVLValFaconcult, " & _
                                                  "InventaireLignes.INVLMtDeb, InventaireLignes.INVLMtCre, InventaireLignes.INVLOrdre, " & _
                                                  "InventaireLignes.INVLValForfaitaire, InventaireLignes.INVLNbPass " & _
                                                  "FROM (InventaireGroupes INNER JOIN " & _
                                                  "InventaireLignes ON InventaireGroupes.INVGCode = InventaireLignes.INVLCode " & _
                                                  "AND InventaireGroupes.INVGDossier = InventaireLignes.INVLDossier) " & _
                                                  "WHERE (InventaireGroupes.INVGTypeInventaire = '{0}') AND (" & _
                                                  "InventaireGroupes.INVGDossier='{1}') " & _
                                                  "ORDER BY InventaireLignes.INVLOrdre", codeTypeInventaire, INVGDossier)

                Dim oleDbComm As New OleDbCommand(sql, oleDbConn)
                Dim oleDbDA As New OleDbDataAdapter(oleDbComm)

                oleDbDA.Fill(impressionDS.ImpListeInv)
            End Using

            Return impressionDS
        End Function

        Public Shared Function GetDataTtTypeInvEtINVGDossier(ByVal INVGDossier As String) As DataSetImpression
            Dim impressionDS As New DataSetImpression

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                oleDbConn.Open()

                Dim sql As String = String.Format("SELECT InventaireGroupes.INVGDossier, " & _
                                                  "InventaireGroupes.INVGCode, InventaireGroupes.INVGLib, " & _
                                                  "InventaireGroupes.INVGOrdre, InventaireLignes.INVLLig, " & _
                                                  "InventaireLignes.INVLQte, InventaireLignes.INVLPrixUnit, " & _
                                                  "InventaireGroupes.INVGUnite, InventaireLignes.INVLLib, " & _
                                                  "InventaireGroupes.INVGTypeInventaire, " & _
                                                  "InventaireGroupes.INVGDecote, InventaireGroupes.INVGCpt, " & _
                                                  "InventaireGroupes.INVGActi, InventaireLignes.INVLCoutOutil, " & _
                                                  "InventaireLignes.INVLCoutTracteur, InventaireLignes.INVLTempsH," & _
                                                  "InventaireLignes.INVLTempsMin, InventaireLignes.INVLNbHa, " & _
                                                  "InventaireLignes.INVLValPdtenTerre, InventaireLignes.INVLValFaconcult, " & _
                                                  "InventaireLignes.INVLMtDeb, InventaireLignes.INVLMtCre, TypeInventaire.OrdreTypeInventaire, " & _
                                                  "TypeInventaire.LibelleTypeInventaire, InventaireLignes.INVLOrdre, " & _
                                                  "InventaireLignes.INVLValForfaitaire, InventaireLignes.INVLNbPass " & _
                                                  "FROM ((InventaireGroupes INNER JOIN " & _
                                                  "InventaireLignes ON InventaireGroupes.INVGCode = InventaireLignes.INVLCode " & _
                                                  "AND InventaireGroupes.INVGDossier = InventaireLignes.INVLDossier) INNER JOIN " & _
                                                  "TypeInventaire ON InventaireGroupes.INVGTypeInventaire = TypeInventaire.CodeTypeInventaire)" & _
                                                  "WHERE (InventaireGroupes.INVGDossier='{0}') and TypeInventaire.CodeTypeInventaire<>'C' " & _
                                                  "ORDER BY TypeInventaire.OrdreTypeInventaire,InventaireLignes.INVLOrdre", INVGDossier)

                Dim oleDbComm As New OleDbCommand(sql, oleDbConn)
                Dim oleDbDA As New OleDbDataAdapter(oleDbComm)

                oleDbDA.Fill(impressionDS.ImpListeInv)
            End Using

            Return impressionDS
        End Function

        Public Shared Function GetDataByINVGDossierEtINVGCode(ByVal INVGDossier As String, ByVal INVGCode As Integer) As DataSetImpression
            Dim impressionDS As New DataSetImpression

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                oleDbConn.Open()

                Dim sql As String = String.Format("SELECT InventaireGroupes.INVGDossier, " & _
                                                  "InventaireGroupes.INVGCode, InventaireGroupes.INVGLib, " & _
                                                  "InventaireGroupes.INVGOrdre, InventaireLignes.INVLLig, " & _
                                                  "InventaireLignes.INVLQte, InventaireLignes.INVLPrixUnit, " & _
                                                  "InventaireGroupes.INVGUnite, InventaireLignes.INVLLib, " & _
                                                  "InventaireGroupes.INVGTypeInventaire, " & _
                                                  "InventaireGroupes.INVGDecote, InventaireGroupes.INVGCpt, " & _
                                                  "InventaireGroupes.INVGActi, InventaireLignes.INVLCoutOutil, " & _
                                                  "InventaireLignes.INVLCoutTracteur, InventaireLignes.INVLTempsH," & _
                                                  "InventaireLignes.INVLTempsMin, InventaireLignes.INVLNbHa, " & _
                                                  "InventaireLignes.INVLValPdtenTerre, InventaireLignes.INVLValFaconcult, " & _
                                                  "InventaireLignes.INVLMtDeb, InventaireLignes.INVLMtCre " & _
                                                  "FROM (InventaireGroupes INNER JOIN " & _
                                                  "InventaireLignes ON InventaireGroupes.INVGCode = InventaireLignes.INVLCode " & _
                                                  "AND InventaireGroupes.INVGDossier = InventaireLignes.INVLDossier) " & _
                                                  "WHERE (InventaireGroupes.INVGDossier='{0}') AND " & _
                                                  "(InventaireGroupes.INVGCode={1})", INVGDossier, INVGCode)

                Dim oleDbComm As New OleDbCommand(sql, oleDbConn)
                Dim oleDbDA As New OleDbDataAdapter(oleDbComm)

                oleDbDA.Fill(impressionDS.ImpListeInv)
            End Using

            Return impressionDS
        End Function

        Public Shared Function PrepareRpt(ByVal impressionDS As DataSetImpression, ByVal nomRpt As String, _
                                    ByVal NumDossier As String, Optional ByVal detail As Boolean = True, _
                                    Optional ByVal MethodeInv As Boolean = True, _
                                    Optional ByVal dtDebPeriode As Date = #1/1/2001#, _
                                    Optional ByVal dtFinPeriode As Date = #1/1/2001#) As ReportDocument

            Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
            Dim Dossier As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(NumDossier)
            Dim strDate As String = String.Empty
            Dim strPeriode As String = String.Empty
            Dim nomExpl As String = String.Empty
            Dim report As ReportDocument = EcranCrystal.ChargerReport(nomRpt, impressionDS)

            Using explTA As New DataSetAgrigestTableAdapters.ExploitationsTableAdapter
                Dim explDT As DataSetAgrigest.ExploitationsDataTable = explTA.GetDataByEExpl(Dossier.DExpl)

                For Each explDR As DataSetAgrigest.ExploitationsRow In explDT.Rows
                    If Not (explDR.IsENom1Null) Then
                        nomExpl = explDR.ENom1
                        If Not (explDR.IsENom2Null) Then
                            nomExpl = nomExpl & " " & explDR.ENom2
                        End If
                    End If
                Next
            End Using

            Dim obj As Object
            obj = report.ReportDefinition.ReportObjects.Item("TxNomExploitant")

            If Not obj Is Nothing Then
                If TypeOf (report.ReportDefinition.ReportObjects.Item("TxNomExploitant")) Is TextObject Then
                    CType(report.ReportDefinition.ReportObjects.Item("TxNomExploitant"), TextObject).Text = nomExpl
                End If
            End If
            obj = report.ReportDefinition.ReportObjects.Item("TxExercice")
            If Not obj Is Nothing Then
                If TypeOf (report.ReportDefinition.ReportObjects.Item("TxExercice")) Is TextObject Then
                    strDate = "Exercice du " & Dossier.DDtDebEx.Value.ToString("dd/MM/yy") & " au " & Dossier.DDtFinEx.Value.ToString("dd/MM/yy")
                    CType(report.ReportDefinition.ReportObjects.Item("TxExercice"), TextObject).Text = strDate
                End If
            End If
            obj = report.ReportDefinition.ReportObjects.Item("TxDtEdi")
            If Not obj Is Nothing Then
                If TypeOf (report.ReportDefinition.ReportObjects.Item("TxDtEdi")) Is TextObject Then
                    strDate = "Edité avec Agrigest² le " & Today.ToString("dd/MM/yy")
                    CType(report.ReportDefinition.ReportObjects.Item("TxDtEdi"), TextObject).Text = strDate
                End If

            End If

            'Passage variable pour la suppression du détail ds le recap des inventaires
            If nomRpt = "EtTtListeInv.rpt" Then
                obj = report.ReportDefinition.ReportObjects.Item("Detail")
                If Not obj Is Nothing Then
                    If TypeOf (report.ReportDefinition.ReportObjects.Item("Detail")) Is FieldObject Then
                        CType(CType(report.ReportDefinition.ReportObjects.Item("Detail"), FieldObject).DataSource, FormulaFieldDefinition).Text = CStr(detail)
                    End If
                End If
                obj = report.ReportDefinition.ReportObjects.Item("MethodeInv")
                If Not obj Is Nothing Then
                    If TypeOf (report.ReportDefinition.ReportObjects.Item("MethodeInv")) Is FieldObject Then
                        CType(CType(report.ReportDefinition.ReportObjects.Item("MethodeInv"), FieldObject).DataSource, FormulaFieldDefinition).Text = CStr(MethodeInv)
                    End If

                End If
            End If

            If nomRpt = "EtListeInvTiers.rpt" Then
                obj = report.ReportDefinition.ReportObjects.Item("TxPeriode")
                If Not obj Is Nothing Then
                    If TypeOf (report.ReportDefinition.ReportObjects.Item("TxPeriode")) Is TextObject Then
                        strPeriode = "Periode du " & dtDebPeriode.ToString("dd/MM/yy") & " au " & dtFinPeriode.ToString("dd/MM/yy")
                        CType(report.ReportDefinition.ReportObjects.Item("TxPeriode"), TextObject).Text = strPeriode
                    End If
                End If
            End If

            Return report
        End Function
#End Region

    End Class
End Namespace
