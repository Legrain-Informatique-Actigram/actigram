Namespace Pomo
    Public Class ExportPomo
        Inherits ExportComptaFichierBase

        Private Const COMPTE_PERTE As String = "6718"
        Private Const COMPTE_PROFIT As String = "7718"
        Private Const COMPTE_ESCOMPTE As String = "66500000"
        Private Const COMPTE_ESCOMPTE_OBTENUE As String = "76500000"

        Private export As export
        Private options As OptionsExport



        Public Overrides ReadOnly Property Filter() As String
            Get
                Return "Fichiers texte (*.txt)|*.txt|"
            End Get
        End Property

        Public Overrides Function DefaultFileName(ByVal nDossier As String) As String
            Return "POMO-IMPOR.TXT"
        End Function

        Public Overrides Sub ChargerDonnees(ByVal sqlConnString As String)
            If options Is Nothing Then options = New OptionsExport("Test d'export au format POMO", True, IIf(Me.TVASurEncaissement, OptionTVA.E, OptionTVA.D))

            MyBase.ChargerDonnees(sqlConnString)
            'Charger les infos compta dans la base agrifact
            InitAgrifactDta("TVA", dsAgrifact, False)
            InitAgrifactDta("Journal", dsAgrifact, False)

            'Déterminer quels sont les dossiers à charger
            Dim dates As New ArrayList
            If VFacture Then
                dates.Add(Me.DateDebVFacture)
                dates.Add(Me.DateFinVFacture)
            End If
            If VReglement Then
                dates.Add(Me.DateDebVReglement)
                dates.Add(Me.DateFinVReglement)
            End If
            If AFacture Then
                dates.Add(Me.DateDebAFacture)
                dates.Add(Me.DateFinAFacture)
            End If
            If AReglement Then
                dates.Add(Me.DateDebAReglement)
                dates.Add(Me.DateFinAReglement)
            End If
            Dim MinDate As Date = PlusPetiteDate(CType(dates.ToArray(GetType(Date)), Date()))
            Dim MaxDate As Date = PlusGrandeDate(CType(dates.ToArray(GetType(Date)), Date()))
            Dim sql As String = String.Format("SELECT * FROM Dossiers WHERE DDtDebEx<='{1:dd/MM/yyyy}' AND DDtFinEx>='{0:dd/MM/yyyy}'", MinDate, MaxDate)
            InitAgrifactDta("Dossiers", sql, dsAgrifact, False)
        End Sub

        Protected Overrides Function EnvoiComptaInterne() As Boolean
            If fichier Is Nothing OrElse fichier.Length = 0 Then
                Throw New ApplicationException("L'emplacement du fichier d'export n'est pas défini.")
            End If

            'Initialiser l'objet export
            If options Is Nothing Then options = New OptionsExport("Test d'export au format EPICEA", True)
            export = New Export
            If options.ExporterPieces Then
                Return MyBase.EnvoiComptaInterne()
            End If
        End Function

        Private Function GetRowTVA(ByVal codeTVA As String) As DataRow
            Return SelectSingleRow(dsAgrifact.Tables("TVA"), "TTVA='{0}'", codeTVA.Replace("'", "''"))
        End Function

        Private Function GetRowTVA(ByVal codeTVA As String, ByVal journal As String) As DataRow
            Return SelectSingleRow(dsAgrifact.Tables("TVA"), "TTVA='{0}' and TJournal = '{1}'", codeTVA.Replace("'", "''"), journal)
        End Function

        Private Sub VerifExistenceTVA(ByVal codeTVA As String)
            If GetRowTVA(codeTVA) Is Nothing Then
                Throw New WarningExport(String.Format("Le code TVA '{0}' n'existe pas.", codeTVA))
            End If
        End Sub

        Protected Function TrouverCodeJournal(ByVal typeJournal As String, Optional ByVal cptBanque As String = Nothing) As String
            If dsAgrifact.Tables.Contains("Journal") Then
                If typeJournal = "tr" Then
                    If Not cptBanque Is Nothing Then
                        Dim drJournal() As DataRow = dsAgrifact.Tables("Journal").Select(String.Format("JType='{0}' AND JCompteContre='{1}'", typeJournal, cptBanque))
                        If drJournal.Length > 0 Then
                            Return Convert.ToString(drJournal(0)("JCodeJournal"))
                        Else
                            'SI ON NE TROUVE PAS DE JOURNAL DE TRESO POUR LE COMPTE INDIQUE ?
                            '=> Journal OD
                            drJournal = dsAgrifact.Tables("Journal").Select("JType='od'")
                            If drJournal.Length > 0 Then
                                Return Convert.ToString(drJournal(0)("JCodeJournal"))
                            End If
                        End If
                    End If
                Else
                    Dim drJournal() As DataRow = dsAgrifact.Tables("Journal").Select(String.Format("JType='{0}'", typeJournal))
                    If drJournal.Length > 0 Then
                        Return Convert.ToString(drJournal(0)("JCodeJournal"))
                    End If
                End If
            End If
            Return Nothing
        End Function

#Region "EXPORT VENTE"

        Protected Overrides Function ExporterFactures() As Boolean

            If VFacture Then
                ReportProgress(0, "Exportation des Factures de vente")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebVFacture, DateFinVFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("VFacture").Select(strFiltre, "nFacture")
                Dim codeJournal As String = TrouverCodeJournal("ve")
                Dim dtExport As Date = Now
                Dim i As Integer = 0
                Dim codeTiersEnabled As Boolean = dsAgrifact.Tables("Entreprise").Columns.Contains("CodeTiers")
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        'Verifs avant la création de la pièce
                        If Not IsNumeric(rwFacture.Item("nClient")) Then
                            Throw New WarningExport(String.Format("Le client n'est pas affecté pour la facture du {0:dd/MM/yy}", rwFacture.Item("DateFacture")))
                        End If
                        Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise=" & rwFacture.Item("nClient"), "")(0)
                        Dim NomClient As String = rwEntreprise.Item("Nom").toUpper
                        If IsDBNull(rwEntreprise.Item("NCompteC")) OrElse IsDBNull(rwEntreprise.Item("NActiviteC")) _
                        OrElse CStr(rwEntreprise.Item("NCompteC")).Length = 0 OrElse CStr(rwEntreprise.Item("NActiviteC")).Length = 0 Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le client {0}", NomClient))
                        End If
                        'Trouver les infos du client de la facture
                        Dim CompteClient As String = rwEntreprise("NCompteC")
                        Dim ActiviteClient As String = rwEntreprise("NActiviteC")

                        For Each ligneDetail As DataRow In dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            If IsDBNull(ligneDetail.Item("NCompte")) OrElse IsDBNull(ligneDetail.Item("NActivite")) _
                            OrElse CStr(ligneDetail.Item("NCompte")).Length = 0 OrElse CStr(ligneDetail.Item("NActivite")).Length = 0 Then
                                Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le produit {0} dans la facture {1} du {2:dd/MM/yy}", NomProduit, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture")))
                            End If
                        Next

                        'Déterminer le n° de la pièce à utiliser pour la facture
                        Dim NumPiece As Integer
                        If Not IsNumeric(BlocnPieceDebutVFacture) Then BlocnPieceDebutVFacture = 50000
                        If Not IsNumeric(BlocnPieceFinVFacture) Then BlocnPieceFinVFacture = 80000
                        NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))


                        'Init variables ECR 
                        Dim dtPiece As Date = rwFacture("DateFacture")
                        Dim dtEch As Date = ReplaceDbNull(rwFacture("DateEcheance"), Nothing)
                        Dim p As New Piece(export)
                        With p
                            .CJnl = codeJournal
                            .DatePiece = dtPiece
                            .DateEcheance = dtEch
                            .CPcr = String.Format("VE{0:0000}", NumPiece)
                        End With

                        'MONTANT TTC FACTURE AU DEBIT SUR COMPTE CLIENT
                        Dim mvtClient As New Ligne(p, Me.options)
                        With mvtClient
                            .Tiers = Left(NomClient, 16)
                            .Debit = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)
                            .Activite = ActiviteClient
                            .Compte = CompteClient
                            .Nature = Left("TOTAL VENTE " & NumPiece, 16)
                            p.Equilibre += .Debit

                        End With
                        export.Lignes.Add(mvtClient)

                        Dim RecapTxTVA As New RecapTVA
                        Dim LignesTVA As New Hashtable
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")

                        For Each ligneDetail As DataRow In lignesDetailFacture
                            ' Génération des comptes TVA si nécessaire
                            Dim CodeTVA As String = Convert.ToString(ligneDetail("TTVA"))
                            Dim TauxTva As Decimal = 0
                            Dim TVASansCompte As Boolean = False

                            If CodeTVA <> "" Then
                                'If TVASurEncaissement Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                Dim ligneTVA As DataRow = GetRowTVA(CodeTVA, "V")
                                If Not ligneTVA Is Nothing Then
                                    TVASansCompte = (Convert.ToString(ligneTVA("TCpt")).Length = 0)
                                    If Not TVASansCompte Then
                                        TauxTva = ReplaceDbNull(ligneTVA("TTaux"), 0)
                                        RecapTxTVA.SetCompte(CodeTVA, ligneTVA("TCpt"), TauxTva)
                                    End If
                                Else
                                    TVASansCompte = True
                                End If
                            Else
                                TVASansCompte = True
                            End If

                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper

                            'Récupérer les infos de quantité
                            Dim Qte1 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite1"), 0)), 2)
                            Dim Qte2 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite2"), 0)), 2)

                            'Stocker pour chacun des codes TVA présents les différentes valeurs : HT, TVA et TTC.
                            'TODO : Faire une vérification d'intégrité sur les valeurs HT,TVA et TTC.
                            Dim MontantTTC As Decimal = CDec(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0))
                            Dim MontantHT As Decimal = CDec(ReplaceDbNull(ligneDetail.Item("MontantLigneHT"), 0))
                            If CBool(rwFacture("FacturationTTC")) Then
                                'Au cas ou le montant HT serait mauvais
                                MontantHT = Decimal.Round(MontantTTC / (1 + TauxTva / 100), 2)
                            End If
                            If Not TVASansCompte Then
                                Select Case CodeTVA
                                    Case "RPCH"
                                        'TODO A VIRER QUAND LA CORRECTION AURA ETE FAITE
                                        'Le montant global est taxé à 8.704%
                                        MontantHT = Decimal.Round(MontantTTC / 1.08704D, 2)

                                        '75% à 5.5%
                                        Dim MontantTTC55 As Decimal = MontantTTC * 0.75D
                                        Dim MontantHT55 As Decimal = Decimal.Round(MontantTTC55 / 1.055D, 2)
                                        Dim cTva As String = "5.5"

                                        RecapTxTVA.AddMontant(cTva, 5.5D, MontantHT55, MontantTTC55)

                                        '25% à 19.6%
                                        Dim MontantTTC196 As Decimal = MontantTTC - MontantTTC55
                                        Dim MontantHT196 As Decimal = MontantHT - MontantHT55
                                        cTva = "19.6"
                                        RecapTxTVA.AddMontant(cTva, 19.6D, MontantHT196, MontantTTC196)
                                        RecapTxTVA.AddMontant(CodeTVA, TauxTva, MontantHT, MontantTTC)
                                    Case Else
                                        RecapTxTVA.AddMontant(CodeTVA, TauxTva, MontantHT, MontantTTC)
                                End Select
                            End If

                            'Créer le mouvement correspondant à la ligne de facture :
                            ' MONTANT HT AU CREDIT SUR COMPTE PRODUIT
                            Dim mvt As New Ligne(p, Me.options)
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .Credit = MontantHT
                                p.Equilibre -= .Credit
                                .Nombre = Qte1
                                .Qte = Qte2
                                .Nature = Replace(Replace(ligneDetail("Libelle"), vbCr, " "), vbLf, " ")
                                .Carac = Left(ligneDetail("CodeProduit"), 6)
                            End With
                            export.Lignes.Add(mvt)

                        Next

                        'CREATION DES LIGNES DE TVA
                        'MODIF TV 16/10/2012
                        For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            If codeTVA.Length > 0 And Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2) <> 0 Then
                                If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                    Dim montantTTCTaux As Decimal = 0
                                    Dim montantTVATaux As Decimal = 0
                                    Dim montantHTTaux As Decimal = 0

                                    If CBool(rwFacture("FacturationTTC")) Then
                                        montantTTCTaux = Decimal.Round(RecapTxTVA.MontantTTCTaux(codeTVA), 2, MidpointRounding.AwayFromZero)
                                        montantTVATaux = Decimal.Round(montantTTCTaux - (montantTTCTaux / (1 + (RecapTxTVA.GetElementRecap(codeTVA).TxTva / 100))), 2, MidpointRounding.AwayFromZero)
                                        montantHTTaux = montantTTCTaux - montantTVATaux
                                    Else
                                        montantHTTaux = Decimal.Round(RecapTxTVA.MontantHTTaux(codeTVA), 2, MidpointRounding.AwayFromZero)
                                        montantTVATaux = Decimal.Round(montantHTTaux * (RecapTxTVA.GetElementRecap(codeTVA).TxTva / 100), 2, MidpointRounding.AwayFromZero)
                                        montantTTCTaux = montantHTTaux + montantTVATaux
                                    End If

                                    Dim mvt As New Ligne(p, Me.options)
                                    With mvt
                                        .Credit = montantTVATaux
                                        p.Equilibre -= .Credit
                                        .Compte = RecapTxTVA.GetElementRecap(codeTVA).CompteTVA
                                        .Nature = String.Format("MONTANT TVA {0}", codeTVA)
                                    End With
                                    export.Lignes.Add(mvt)
                                End If
                            End If
                        Next

                        '''OLD
                        'For Each codeTVA As String In RecapTxTVA.GetLstTx()
                        '    If codeTVA.Length > 0 And Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2) <> 0 Then
                        '        Dim mvt As New Ligne(p, Me.options)
                        '        With mvt
                        '            .Credit = Actigram.MathUtil.ArithmeticRound(RecapTxTVA.MontantTVATaux(codeTVA), 2)
                        '            p.Equilibre -= .Credit
                        '            .Compte = RecapTxTVA.GetElementRecap(codeTVA).CompteTVA
                        '            .Nature = String.Format("MONTANT TVA {0}", codeTVA)
                        '        End With
                        '        export.Lignes.Add(mvt)
                        '    End If
                        'Next
                        'FIN MODIF TV 16/108/2012

                        If p.Equilibre <> 0 Then
                            'La piece n'est pas equilibrée
                            export.RemoveLinesByNPiece(p.NPiece)
                            Throw New WarningExport(String.Format("La piece facture de vente {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.NPiece, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture"), Math.Abs(p.Equilibre)))
                        End If

                        'Marquer la facture comme exportée
                        With rwFacture
                            .Item("ExportCompta") = True
                            .Item("DateExportCompta") = dtExport
                        End With

                    Catch ex As Exception
                        'Probleme sur cette facture. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwFacturesAExporter.Length)
                Next
            End If
            Return True
        End Function

        Protected Overrides Function ExporterRemises() As Boolean
            ' REMISE ET REGLEMENTS RESULTANT DES VENTES
            If VReglement = True Then
                ReportProgress(0, "Exportation des règlements clients")
                Dim dtExport As Date = Now
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateRemise>='{0}' and DateRemise<='{1}')", DateDebVReglement, DateFinVReglement)
                Dim rwRemises() As DataRow = dsAgrifact.Tables("Remise").Select(strFiltre, "nRemise")
                Dim codeTiersEnabled As Boolean = dsAgrifact.Tables("Entreprise").Columns.Contains("CodeTiers")
                Dim i As Integer = 0
                For Each rwRemise As DataRow In rwRemises
                    Try
                        'Verifs avant création de la pièce
                        If IsDBNull(rwRemise.Item("nBanque")) Then
                            Throw New WarningExport(String.Format("Pas de banque renseignée pour la remise du {0:dd/MM/yy}", rwRemise.Item("DateRemise")))
                        End If
                        Dim rwBanque As DataRow = dsAgrifact.Tables("Banque").Select("nBanque='" & rwRemise.Item("nBanque") & "'", "")(0)
                        Dim NomBanque As String = rwBanque.Item("Libelle").toUpper
                        If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If
                        'Infos banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        Dim ActiviteBanque As String = rwBanque.Item("NActivite")

                        For Each ligneDetailRemise As DataRow In dsAgrifact.Tables("Remise_Detail").Select("nRemise='" & rwRemise.Item("nRemise") & "'", "nDetailRemise")
                            For Each rwReglementDetail As DataRow In dsAgrifact.Tables("Reglement_detail").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")
                                Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)
                                Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement.Item("nEntreprise") & "'", "")(0)
                                Dim NomClient As String = rwEntreprise.Item("Nom").toUpper
                                If IsDBNull(rwEntreprise.Item("NCompteC")) Or IsDBNull(rwEntreprise.Item("NActiviteC")) Then
                                    Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le client {0}", NomClient))
                                End If
                            Next
                        Next

                        'Déterminer le n° de la piece
                        If Not IsNumeric(BlocnPieceDebutVReglement) Then BlocnPieceDebutVFacture = 100000
                        If Not IsNumeric(BlocnPieceFinVReglement) Then BlocnPieceFinVReglement = 150000

                        Dim NumPiece As Integer = 0
                        Try
                            'On essaye d'utiliser le nRemiseBanque
                            NumPiece = Integer.Parse(Right(ReplaceDbNull(rwRemise.Item("nRemiseBanque"), "0"), 9))
                        Catch ex As Exception
                            Debug.WriteLine(ex.Message)
                        End Try

                        'S'il n'y en a pas, on prend le nRemise
                        If NumPiece = 0 Then NumPiece = rwRemise.Item("nRemise")

                        'On cadre le n° de piece dans la fourchette
                        NumPiece = CadreFourchette(NumPiece, CInt(BlocnPieceDebutVReglement), CInt(BlocnPieceFinVReglement))

                        Dim dtRemise As Date = CDate(rwRemise.Item("DateRemise"))
                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Remise {2} n°{0} du {1:dd/MM/yy}", rwRemise("nRemiseBanque"), dtRemise, rwRemise("TypeRemise")), 50)

                        'Init variables ECR 
                        Dim p As New Piece(export)
                        With p
                            .DatePiece = dtRemise
                            .CPcr = String.Format("VE{0:0000}", NumPiece Mod (10000))
                            .CJnl = CodeJournal
                        End With


                        'MONTANT DE LA REMISE AU DEBIT DE LA BANQUE
                        Dim mvtBq As New Ligne(p, Me.options)
                        With mvtBq
                            .Compte = CompteBanque
                            .Tiers = Left(NomBanque, 16)
                            .Debit = Decimal.Round(CDec(rwRemise.Item("Montant")), 2)
                            .Nature = String.Format("TOTAL REMISE {0}", rwRemise("nRemiseBanque"))
                            p.Equilibre += .Debit
                        End With
                        export.Lignes.Add(mvtBq)

                        Dim lignesDetailRemise() As DataRow = dsAgrifact.Tables("Remise_Detail").Select("nRemise='" & rwRemise.Item("nRemise") & "'", "nDetailRemise")
                        'POUR CHAQUE REGLEMENT DE LA REMISE
                        For Each ligneDetailRemise As DataRow In lignesDetailRemise
                            Dim rwDetailReglements() As DataRow = dsAgrifact.Tables("Reglement_detail").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")
                            Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)

                            Dim AvanceClient As Decimal = CDec(ReplaceDbNull(rwReglement("Montant"), 0))
                            AvanceClient += CDec(ReplaceDbNull(rwReglement("Perte"), 0))
                            AvanceClient -= CDec(ReplaceDbNull(rwReglement("Profit"), 0))

                            Dim GlobalRecapTxTVA As New RecapTVA
                            'POUR CHAQUE FACTURE REGLEE PAR LE REGLEMENT
                            For Each rwReglementDetail As DataRow In rwDetailReglements
                                AvanceClient -= CDec(ReplaceDbNull(rwReglementDetail("Montant"), 0))
                                If Not IsDBNull(rwReglementDetail.Item("nFacture")) Then
                                    Dim RecapTVAEscompte As New RecapTVA
                                    Dim RecapTxTVA As New RecapTVA
                                    Dim SoldeFacture As Boolean = False
                                    Dim nDevis As Long = rwReglementDetail.Item("nFacture")
                                    Dim rwFacture As DataRow = dsAgrifact.Tables("VFacture").Select("nDevis=" & nDevis)(0)
                                    Dim NumFacture As Integer = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))

                                    'Déterminer les informations CLIENT
                                    Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwFacture.Item("nClient") & "'", "")(0)
                                    Dim NomClient As String = rwEntreprise.Item("Nom").toUpper
                                    Dim CompteClient As String = rwEntreprise.Item("NCompteC")
                                    Dim ActiviteClient As String = rwEntreprise.Item("NActiviteC")

                                    'Créer les lignes pour le réglement
                                    Dim libPaiement As String = NumFacture & " " & rwReglement.Item("nMode")
                                    Dim LibPaiement2 As String = NomClient

                                    'Créer le mouvement correspondant à la ligne de réglement :
                                    ' MONTANT DU REGLEMENT AU CREDIT SUR COMPTE CLIENT
                                    Dim mvt As New Ligne(p, Me.options)
                                    With mvt

                                        .Compte = CompteClient
                                        .Tiers = NomClient
                                        .Nature = libPaiement & " " & LibPaiement2
                                        .Credit = Decimal.Round(CDec(rwReglementDetail.Item("Montant")), 2)
                                        p.Equilibre -= .Credit
                                    End With
                                    export.Lignes.Add(mvt)

                                    ' CALCUL DES SOMMES REGLEES ET DUES POUR LA FACTURE
                                    Dim SommeDue As Decimal = 0
                                    Dim SommePayee As Decimal = 0
                                    Dim SommeDejaPayee As Decimal = 0
                                    Dim MontantEscompte As Decimal = 0
                                    Dim ratioPaye As Decimal = 1

                                    With dsAgrifact.Tables("FactureMontantExport")
                                        Dim obj As Object = .Compute("Sum(MontantTTC)", "nDevis=" & nDevis & "")
                                        If Not IsDBNull(obj) Then SommeDejaPayee = Decimal.Round(CDec(obj), 2)
                                    End With

                                    SommePayee = CDec(rwReglementDetail.Item("Montant"))
                                    'TODO A REMETTRE QUAND ON AURA GERE L'ESCOMPTE
                                    'If Not IsDBNull(rwReglementDetail.Item("MtEscompte")) Then
                                    '    MontantEscompte = CDec(rwReglementDetail.Item("MtEscompte"))
                                    'End If
                                    'MontantTotalEscompte += MontantEscompte
                                    SommeDue = CDec(rwFacture.Item("MontantTTC")) - MontantEscompte

                                    'rwEscompte = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetail.Item("nReglement") & "'", "nReglement")(0)
                                    'Cherche si le réglement à une escompte

                                    'If Not IsDBNull(rwReglement.Item("TxEscompte")) And Not passEscompte Then
                                    '    rwEscompte = rwReglement
                                    '    If rwReglement.Item("TxEscompte") <> 0 Then
                                    '        SommeDue -= Decimal.Round(CDec(rwReglement.Item("MontantEscompte")), 2)
                                    '    End If
                                    '    passEscompte = True
                                    'End If


                                    '' GESTION DES PERTES ET PROFIT
                                    If Not IsDBNull(rwReglementDetail.Item("Perte")) Then
                                        If rwReglementDetail.Item("Perte") <> 0 Then
                                            Dim perte As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Perte")), 2)
                                            'Créer le mouvement correspondant à la perte :
                                            ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE PERTE
                                            Dim mvtPP As New Ligne(p, Me.options)
                                            With mvtPP
                                                .Compte = COMPTE_PERTE
                                                .Nature = "Arrondi de paiement perte " & NumFacture
                                                .Debit = perte
                                                p.Equilibre += .Debit
                                            End With
                                            export.Lignes.Add(mvtPP)
                                            SommePayee += perte
                                        End If
                                    End If
                                    If Not IsDBNull(rwReglementDetail.Item("Profit")) Then
                                        If rwReglementDetail.Item("Profit") <> 0 Then
                                            Dim profit As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Profit")), 2)
                                            'Créer le mouvement correspondant au profit :
                                            ' MONTANT DU POFIT AU DEBIT SUR COMPTE PROFIT
                                            Dim mvtPP As New Ligne(p, Me.options)
                                            With mvtPP
                                                .Compte = COMPTE_PROFIT
                                                .Nature = "Arrondi de paiement profit " & NumFacture
                                                .Credit = profit
                                                p.Equilibre -= .Credit
                                            End With
                                            export.Lignes.Add(mvtPP)
                                            SommePayee -= profit
                                        End If
                                    End If

                                    If SommeDue <> SommePayee Then
                                        If Math.Abs(SommeDejaPayee + SommePayee - SommeDue) <= 0.02 Then ' ON EST OBLIGE AFIN DE POUVOIR SOLDER LA FACTURE CF lUDO
                                            SoldeFacture = True
                                            ratioPaye = 1 'Dans ce cas on prend 100% du HT, on retranchera ensuite le déjà payé
                                        Else
                                            ratioPaye = SommePayee / SommeDue
                                        End If
                                    End If

                                    'Faire un récap de la TVA de la facture
                                    If TVASurEncaissement OrElse MontantEscompte <> 0 Then
                                        Dim rwFacturesDetail() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & nDevis & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                                        For Each rwFactureDetail As DataRow In rwFacturesDetail
                                            ' Génération des comptes TVA si nécessaire
                                            Dim CodeTVA As String = Convert.ToString(rwFactureDetail("TTVA"))
                                            Dim TauxTva As Decimal = 0

                                            If CodeTVA.Length > 0 Then
                                                Dim rwTVA As DataRow = GetRowTVA(codeTVA)
                                                If Not rwTVA Is Nothing Then
                                                    TauxTva = ReplaceDbNull(rwTVA.Item("TTaux"), 0)
                                                    If Convert.ToString(rwTVA("TCpt")).Length > 0 Then
                                                        RecapTxTVA.SetCompte(codetva, Convert.ToString(rwTVA("TCpt")), TauxTva)
                                                    End If
                                                End If
                                            End If

                                            'stocker pour chacun des codes TVA présents le montant d'HT qui va être payé par la facture
                                            'TODO : ON NE GERE COMPLETEMENT PAS LA TVA RPCH
                                            If Not IsDBNull(rwFactureDetail("MontantLigneHt")) Then
                                                RecapTxTVA.AddMontant(CodeTVA, TauxTva, Decimal.Round((rwFactureDetail("MontantLigneHt") * ratioPaye), 2), 0)
                                            End If
                                        Next

                                        'Si le réglement solde la facture alors on retranche le déjà payé
                                        If SoldeFacture Then
                                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                                Dim rwDejaPayeeII() As DataRow = dsAgrifact.Tables("factureMontantExport").Select("nDevis='" & nDevis & "' And TTVA='" & CodeTVA.Replace("'", "''") & "'", "nDevis")
                                                For Each rwDejapayee As DataRow In rwDejaPayeeII
                                                    With rwDejapayee
                                                        elRecap.MontantHT -= .Item("MontantHT")
                                                        elRecap.MontantTVA -= .Item("MontantTVA")
                                                        elRecap.MontantTTC -= .Item("MontantTTC")
                                                    End With
                                                Next
                                            Next
                                        End If

                                        'Calculer la répartition de l'escompte par code TVA
                                        If MontantEscompte <> 0 Then
                                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                                Dim partEscompte As Decimal = MontantEscompte * elRecap.MontantTTC / SommePayee
                                                RecapTVAEscompte.AddMontant(codeTVA, RecapTxTVA.TxTVA(codeTVA), 0, partEscompte)
                                            Next
                                        End If

                                        If MontantEscompte <> 0 Then
                                            'TODO REMONTER CA A CHAQUE FACTURE
                                            ' On solde le compte client du montant TTC de l'escompte au débit
                                            Dim mvtEscClient As New Ligne(p, Me.options)
                                            With mvtEscClient
                                                If Not codeTiersEnabled OrElse IsDBNull(rwEntreprise("CodeTiers")) Then
                                                    .Compte = CompteClient
                                                Else
                                                    .Compte = Convert.ToString(rwEntreprise("CodeTiers"))
                                                    .Tiers = CompteClient

                                                End If
                                                .Nature = NomClient & " escompte " & NumFacture
                                                .Credit = MontantEscompte
                                                p.Equilibre -= .Credit
                                            End With
                                            export.Lignes.Add(mvtEscClient)

                                            ' On solde les compte TVA
                                            Dim MontantEscompteTVA As Decimal = 0
                                            For Each codeTVA As String In RecapTVAEscompte.GetLstTx()
                                                If RecapTVAEscompte.MontantTVATaux(codeTVA) <> 0 Then
                                                    MontantEscompteTVA += RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                    Dim mvtEscTva As New Ligne(p, Me.options)
                                                    With mvtEscTva
                                                        .Compte = RecapTVAEscompte.GetElementRecap(codeTVA).CompteTVA
                                                        .Nature = "REGUL. TVA ESCOMPTE " & codeTVA & " " & NumFacture
                                                        .Credit = RecapTVAEscompte.MontantHTTaux(codeTVA)
                                                        p.Equilibre -= .Credit
                                                        '.MtTVAC = RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                        '.CodeTvaCompte = CodeTVA
                                                    End With
                                                    export.Lignes.Add(mvtEscTva)
                                                End If
                                            Next

                                            Dim MontantEscompteHT As Decimal = MontantEscompte - MontantEscompteTVA
                                            ' on passe le montant HT de l'escompte en escompte
                                            Dim mvtEsc As New Ligne(p, Me.options)
                                            With mvtEsc
                                                .Compte = COMPTE_ESCOMPTE
                                                .Nature = Left("Escompte Accordée " & NumFacture, 30)
                                                .Credit = MontantEscompteHT
                                                p.Equilibre -= .Credit
                                            End With
                                            export.Lignes.Add(mvtEsc)
                                        End If
                                    End If
                                End If
                            Next 'NEXT FACTURE
                            'S'il reste de l'avance client :
                            If AvanceClient <> 0 Then
                                'Créer une ligne pour équilibrer la pièce vers le payeur
                                'Déterminer les informations PAYEUR
                                Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement("nEntreprise") & "'", "")(0)
                                Dim NomPayeur As String = rwEntreprise.Item("Nom").toUpper
                                Dim ComptePayeur As String = rwEntreprise.Item("NCompteC")

                                Dim mvtAvance As New Ligne(p, Me.options)
                                With mvtAvance
                                    .Compte = ComptePayeur
                                    .Nature = Left("AVANCE " & NomPayeur, 30)
                                    .Credit = AvanceClient
                                    p.Equilibre -= .Credit
                                End With
                                export.Lignes.Add(mvtAvance)
                            End If


                        Next 'NEXT REGLEMENT


                        If p.Equilibre <> 0 Then
                            'La piece n'est pas equilibrée
                            export.RemoveLinesByNPiece(p.NPiece)
                            Throw New WarningExport(String.Format("La Piece {0} générée à partir de la Remise de Vente {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.CPcr, NumPiece, rwRemise.Item("DateRemise"), Math.Abs(p.Equilibre)))
                        End If

                        'MARQUER LA REMISE COMME EXPORTEE
                        rwRemise.Item("ExportCompta") = True
                        rwRemise.Item("DateExportCompta") = dtExport

                        'POUR CHAQUE REGLEMENT DE LA REMISE
                        For Each ligneDetailRemise As DataRow In lignesDetailRemise
                            Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = dtExport
                        Next

                    Catch ex As WarningExport
                        'Probleme sur cette remise. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwRemises.Length)
                Next 'NEXT REMISE
            End If
            Return True
        End Function

#End Region

#Region "EXPORT ACHAT"

        Protected Overrides Function ExporterFacturesAchat() As Boolean
            If AFacture = True Then
                ReportProgress(0, "Exportation des factures fournisseur")
                ' FACTURES D'ACHAT
                Dim dtExport As Date = Now
                Dim CodeTVAAchat As String
                Dim CodeTVAAchatImmo As String
                Dim CodeJournal As String = TrouverCodeJournal("ac")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebAFacture, DateFinAFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("AFacture").Select(strFiltre, "nFacture")
                Dim hasCodeTiersEnabled As Boolean = dsAgrifact.Tables("Entreprise").Columns.Contains("CodeTiers")
                Dim i As Integer = 0
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        'Verifs avant la création de pièce
                        Dim rwFournisseur As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwFacture.Item("nClient") & "'", "")(0)
                        Dim NomFournisseur As String = rwFournisseur.Item("Nom").toUpper
                        If IsDBNull(rwFournisseur.Item("NCompteF")) OrElse IsDBNull(rwFournisseur.Item("NActiviteF")) _
                        OrElse CStr(rwFournisseur.Item("NCompteF")).Length = 0 OrElse CStr(rwFournisseur.Item("NActiviteF")).Length = 0 Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If
                        'Récupération des infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")

                        For Each ligneDetail As DataRow In dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit is not null And Codeproduit<>''", "nLigne")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            If IsDBNull(ligneDetail.Item("NCompte")) OrElse IsDBNull(ligneDetail.Item("NActivite")) _
                            OrElse CStr(ligneDetail.Item("NCompte")).Length = 0 OrElse CStr(ligneDetail.Item("NActivite")).Length = 0 Then
                                Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le produit {0} dans la facture {1} du {2:dd/MM/yy}", NomProduit, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture")))
                            End If
                        Next

                        Dim NumPiece As Integer = rwFacture.Item("nFacture")
                        If Not IsNumeric(BlocnPieceDebutAFacture) Then BlocnPieceDebutAFacture = 80000
                        If Not IsNumeric(BlocnPieceFinAFacture) Then BlocnPieceFinAFacture = 100000
                        NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutAFacture), CInt(BlocnPieceFinAFacture))

                        'Init variables ECR
                        Dim dtFacture As Date = rwFacture("DateFacture")
                        Dim dtEch As Date = ReplaceDbNull(rwFacture("DateEcheance"), Nothing)
                        Dim p As New Piece(export)
                        With p
                            .DatePiece = dtFacture
                            .nbLigne = 1 'Pour pouvoir insérer la ligne de fournisseur en premier
                            .DateEcheance = dtEch
                            .CPcr = String.Format("AC{0:0000}", NumPiece Mod (10000))
                            .CJnl = CodeJournal
                        End With

                        Dim Ligne As Integer = 0
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit is not null And Codeproduit<>''", "nLigne")
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0

                        For Each ligneDetail As DataRow In lignesDetailFacture
                            Dim CompteProduit As String = ligneDetail("NCompte")



                            Select Case CompteProduit.Substring(0, 1)
                                Case "1" 'Pour gérer les comptes 1013 de parts sociales

                                    TTCCptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case "6" 'ACHAT NORMAL
                                    CodeTVAAchat = LigneDetail("TTVA")
                                    TVACptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTVA"), 0), 2)
                                    TTCCptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case "2" 'ACHAT D'IMMO                                
                                    CodeTVAAchatImmo = LigneDetail("TTVA")
                                    TVACptImmo += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTVA"), 0), 2)
                                    TTCCptImmo += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case Else
                                    Throw New WarningExport(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Compte produit incorrect {2}: Le compte doit être en 1,2 ou 6", NumPiece, rwFacture.Item("DateFacture"), CompteProduit))
                                    Return False
                            End Select

                            'Informations produit pour création du compte Produit
                            Dim Unite1 As String = ReplaceDbNull(ligneDetail.Item("LibUnite1"), "")
                            Dim Unite2 As String = ReplaceDbNull(ligneDetail.Item("LibUnite2"), "")
                            Dim codeProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            Dim libProduit As String = ligneDetail.Item("Libelle")
                            Dim Qte1 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite1"), 0)), 2)
                            Dim Qte2 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite2"), 0)), 2)

                            Dim mvt As New Ligne(p, options)
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .Tiers = NomFournisseur
                                .Nature = libProduit
                                .Debit = Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2)
                                .Carac = codeProduit
                                .Qte = Qte1
                                .Nombre = Qte2
                                .Activite = ActiviteFournisseur
                                p.Equilibre += .Debit
                            End With
                            export.Lignes.Add(mvt)

                        Next

                        'SOLDER LES CHARGES
                        If TTCCptCharge <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchat
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            Dim mvtFour As New Ligne(p, options)
                            With mvtFour
                                .NLigne = 1
                                .Compte = CompteFournisseur
                                .Tiers = Left(NomFournisseur, 16)
                                .Credit = Decimal.Round(TTCCptCharge, 2)
                                .Activite = ActiviteFournisseur
                                p.Equilibre -= .Credit
                            End With
                            export.Lignes.Add(mvtFour)

                        End If

                        'TVA CHARGES
                        If TVACptCharge <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchat
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            Dim mvt As New Ligne(p, Me.options)
                            With mvt
                                .Debit = Decimal.Round(TVACptCharge, 2)
                                .Compte = CompteTva
                                .Nature = String.Format("MONTANT TVA {0}", CodeTVA)
                                p.Equilibre += .Debit
                            End With
                            export.Lignes.Add(mvt)
                        End If

                        'SOLDER LES IMMOS
                        If TTCCptImmo <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchatImmo
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            'If lignesTVA.ContainsKey(CodeTVA) Then
                            '    'CType(lignesTVA(CodeTVA), Ligne).MtTVAD = Decimal.Round(TVACptImmo, 2)
                            'End If

                            Dim mvtFour As New Ligne(p, options)
                            With mvtFour

                                .Compte = CompteFournisseur
                                .Tiers = NomFournisseur
                                .Nature = String.Format("TOTAL ACHAT IMMO {0}", NumPiece)
                                .Credit = Decimal.Round(TTCCptImmo, 2)
                                .Activite = ActiviteFournisseur
                                p.Equilibre -= .Credit
                            End With

                            export.Lignes.Add(mvtFour)

                        End If

                        'TVA IMMOS
                        If TVACptImmo <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchatImmo
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            Dim mvt As New Ligne(p, Me.options)
                            With mvt
                                .Debit = Decimal.Round(TVACptImmo, 2)
                                .Compte = CompteTva
                                .Nature = String.Format("MONTANT TVA {0}", CodeTVA)
                                p.Equilibre += .Debit
                            End With
                            export.Lignes.Add(mvt)
                        End If


                        'If p.Equilibre <> 0 Then
                        '    'La piece n'est pas equilibrée
                        '    export.RemoveLinesByNPiece(p.NPiece)
                        '    Throw New WarningExport(String.Format("La piece {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.NPiece, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture"), Math.Abs(p.Equilibre)))
                        'End If

                        rwFacture.Item("ExportCompta") = True
                        rwFacture.Item("DateExportCompta") = dtExport

                    Catch ex As WarningExport
                        'Probleme sur cette facture. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwFacturesAExporter.Length)
                Next
            End If
            Return True
        End Function

        Protected Overrides Function ExporterReglementsAchats() As Boolean
            Return True
        End Function

#End Region

        Protected Overrides Sub UpdateData()
            'ENREGISTRER LE FICHIER EXPORT
            If export.Lignes.Count = 0 Then
                Me.RapportExport.Append("Aucune écriture exportée" & vbCrLf)
            Else
                'Exporter dans le fichier
                ReportProgress(0, "Ecriture du fichier...")
                export.Exporter(fichier, "", Utils.ModeExportation.TailleFixe)
                'Enregistrement des données
                MyBase.UpdateData()
            End If
        End Sub


    End Class

#Region "Classes util pour export"
    Friend Enum TypePiece
        A 'Achat
        V 'Vente
        T 'Réglement
        O 'OD
    End Enum

    Friend Enum OptionTVA
        E 'TVA sur Encaissement
        D 'TVA sur débits (facturation)
    End Enum

    Friend Class OptionsExport
        Public TitreExport As String
        Public ExporterPieces As Boolean = True
        Public ExigTVA As OptionTVA

        Public Sub New(Optional ByVal titre As String = "", Optional ByVal expPieces As Boolean = True, Optional ByVal optionTVA As OptionTVA = OptionTVA.D)
            Me.TitreExport = titre
            Me.ExporterPieces = expPieces
            Me.ExigTVA = optionTVA
        End Sub
    End Class

    Friend Class ModeleExport
        Private FormatDate As String = "dd/MM/yyyy"

        Public Overridable Function GetFormat() As String
            Return ""
        End Function

        Public Overridable Function GetFields() As Object()
            Return New Object() {}
        End Function

        Public Overridable Function GetSubItems() As ArrayList
            Return New ArrayList
        End Function

        Public Sub Exporter(ByVal tw As IO.TextWriter, ByVal sep As String, ByVal mode As ModeExportation)
            Dim f() As Object = GetFields()
            If f.Length > 0 Then
                If mode = ModeExportation.Delimite Then
                    EcrireLigneSep(tw, sep, FormatDate, f)
                Else
                    EcrireLigneFormat(tw, GetFormat, FormatDate, f)
                End If
            End If
            For Each item As ModeleExport In GetSubItems() : item.Exporter(tw, sep, mode) : Next
        End Sub
    End Class

    Friend Class Export
        Inherits ModeleExport

        Public Lignes As New ArrayList

        Public Sub New()

        End Sub

        Public Overloads Sub Exporter(ByVal fichier As String, ByVal sep As String, ByVal mode As ModeExportation)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
            Exporter(sw, sep, mode)
            sw.Close()
        End Sub

        Public Overloads Sub Exporter(ByVal sb As System.Text.StringBuilder, ByVal sep As String, ByVal mode As ModeExportation)
            Exporter(New IO.StringWriter(sb), sep, mode)
        End Sub

        Public Overrides Function GetFormat() As String
            Return ""
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Lignes
        End Function

        Public Sub RemoveLinesByNPiece(ByVal nPiece As Integer)

            Dim linesToKeep As New ArrayList

            For Each line As Ligne In Lignes
                If line.NPiece <> nPiece Then
                    linesToKeep.Add(line)
                End If
            Next

            Lignes = linesToKeep
            Me.nbPiece -= 1

        End Sub

        Public nbPiece As Integer
    End Class

    Friend Class Piece
        Public NPiece As Integer
        Public DatePiece As Date
        Public DateEcheance As Date
        Public nbLigne As Integer
        Public CPcr As String
        Public CJnl As String
        Public Equilibre As Decimal

        Public Sub New()

        End Sub

        Public Sub New(ByVal ex As Export)
            Me.New()
            Me.NPiece = ex.nbPiece
            ex.nbPiece += 1
        End Sub
    End Class

    Friend Class Ligne
        Inherits ModeleExport

        'Infos Piece
        Public NPiece As Integer
        Public CJnl As String
        Public DateEnreg As Date
        Public CPcr As String

        'Infos ligne
        Public NLigne As Integer
        Public Compte As String
        Public Nature As String
        Public Debit As Decimal
        Public Credit As Decimal
        Public Tiers As String
        Public Nombre As Decimal
        Public Qte As Decimal
        Public Carac As String
        Public Activite As String
        Public DateEcheance As Date


#Region "ctor"
        Public Sub New()
        End Sub

        Public Sub New(ByVal p As Piece, ByVal o As OptionsExport)
            Me.New()
            Me.NPiece = p.NPiece
            Me.CJnl = p.CJnl
            Me.DateEnreg = p.DatePiece
            Me.DateEcheance = p.DateEcheance
            Me.CPcr = p.CPcr
            p.nbLigne += 1
            Me.NLigne = p.nbLigne

        End Sub
#End Region

#Region "overrides"
        Public Overrides Function GetFormat() As String
            Return "{0}" & vbTab & "{1}" & vbTab & "{2}" & vbTab & "{3}" & vbTab & "{4}" & vbTab & "{5}" & vbTab & "{6}" & vbTab & "{7}" & vbTab & "{8}" & vbTab & "{9}" & vbTab & "{10}" & vbTab & "{11}" & vbTab & "{12}"
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {CJnl, DateEnreg, CPcr, Compte, Nature, Debit, Credit, Tiers, Nombre, Qte, Carac, Activite, DateEcheance}
        End Function
#End Region
    End Class
#End Region

End Namespace

