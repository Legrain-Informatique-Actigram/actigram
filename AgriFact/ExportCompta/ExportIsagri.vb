Namespace Isagri
    Public Class ExportIsagri
        Inherits ExportComptaFichierBase

        Private Const COMPTE_PERTE As String = "65800000"
        Private Const COMPTE_PROFIT As String = "75800000"
        Private Const COMPTE_ESCOMPTE As String = "66500000"
        Private Const COMPTE_ESCOMPTE_OBTENUE As String = "76500000"

        Private export As export
        Private options As OptionsExport

        Public Overrides ReadOnly Property Filter() As String
            Get
                Return "Fichiers ECR (*.ecr)|*.ecr|Fichiers ISA (*.isa)|*.isa|"
            End Get
        End Property

        Public Overrides Function DefaultFileName(ByVal nDossier As String) As String
            Return String.Format("{0}-Export du {1:dd-MM-yyy}.ecr", nDossier, Now)
        End Function

        Public Overrides Sub ChargerDonnees(ByVal sqlConnString As String)
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
            'Comment on fait pour les journaux ?
        End Sub


        Protected Overrides Function EnvoiComptaInterne() As Boolean
            Dim res As Boolean = False
            If fichier Is Nothing OrElse fichier.Length = 0 Then
                Throw New ApplicationException("L'emplacement du fichier d'export n'est pas défini.")
            End If

            'Initialiser l'objet export
            If options Is Nothing Then options = New OptionsExport(True, "Test d'export au format IsAgri")
            'VER
            export = New Export(options)

            'DOS
            Dim dossier As New Dossier
            With dossier
                .NumDossier = nDossierCompta
                .LibDossier = NomDossier
            End With
            export.Dossiers.Add(dossier)

            'EXO
            'POTENTIELLEMENT IL Y A PLUSIEURS EXERCICES 
            For Each dr As DataRow In dsAgrifact.Tables("Dossiers").Select(String.Format("DExpl='{0}'", nDossierCompta))
                Dim exo As New Exercice
                With exo
                    .DateDebEx = dr("DDtDebEx")
                    .DateFinEx = dr("DDtFinEx")
                    .ResetEcritures = options.ForcerExportFullPieces
                End With
                dossier.Exercices.Add(exo)
            Next


            'ANA
            If options.ExporterActivites Then
            End If

            'CPT
            If options.ExporterPlanCpt Then
            End If

            'TVA
            If options.ExporterTVA Then
            End If

            'JOU
            If options.ExporterJournaux Then
            End If

            'ECR
            If options.ExporterPieces Then
                res = MyBase.EnvoiComptaInterne()
            End If
            Return res
        End Function

        Private Function TrouverDossier(ByVal dt As Date) As Exercice
            For Each exo As Exercice In CType(export.Dossiers(0), Dossier).Exercices
                If dt >= exo.DateDebEx AndAlso dt <= exo.DateFinEx Then
                    Return exo
                End If
            Next
            Return Nothing
        End Function

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

        Private Function GetRowTVA(ByVal codeTVA As String) As DataRow
            Return SelectSingleRow(dsAgrifact.Tables("TVA"), "TTVA='{0}'", codeTVA.Replace("'", "''"))
        End Function

        Private Sub VerifExistenceTVA(ByVal codeTVA As String)
            If GetRowTVA(codeTVA) Is Nothing Then
                Throw New WarningExport(String.Format("Le code TVA '{0}' n'existe pas.", codeTVA))
            End If
        End Sub

        Private Function CheckTypTVA(ByVal codeTVA As String, ByVal typTVA As String) As Boolean
            Dim dr As DataRow = GetRowTVA(codeTVA)
            If Not dr Is Nothing Then
                Return Convert.ToString(dr("TypTVA")) = typTVA
            End If
            Return False
        End Function

        Protected Overridable Function CodeTVAEncaissementCorrespondant(ByVal CodeTVA As String) As String
            If CodeTVA = "A" Then : Return "A1"
            ElseIf CodeTVA = "V" Then : Return "V1"
            ElseIf CodeTVA = "W" Then : Return "W1"
            ElseIf CodeTVA = "A1" Then : Return "A"
            ElseIf CodeTVA = "V1" Then : Return "V"
            ElseIf CodeTVA = "W1" Then : Return "W"
            ElseIf CodeTVA = "D" Then : Return "D"
            Else : Return "0"
            End If
        End Function

        Private Function TrouverCodeTVA(ByVal typTVA As String, ByVal taux As Decimal, Optional ByVal typJournal As String = "") As String
            If typJournal = "" Then
                Select Case typTVA
                    Case "ac", "im" : typJournal = "A"
                    Case "ve" : typJournal = "V"
                End Select
            End If
            Dim dr As DataRow = SelectSingleRow(dsAgrifact.Tables("TVA"), "TypTVA='{0}' AND TTaux={1} AND TJournal='{2}' ", typTVA, taux, typJournal)
            If Not dr Is Nothing Then
                Return dr("TTVA")
            Else
                Return Nothing
            End If
        End Function

        Protected Overrides Function ExporterFactures() As Boolean
            ' FACTURE DE VENTE
            If VFacture Then
                ReportProgress(0, "Exportation des Factures de vente")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebVFacture, DateFinVFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("VFacture").Select(strFiltre, "nFacture")
                Dim CodeJournal As String = TrouverCodeJournal("ve")
                Dim dtExport As Date = Now
                Dim i As Integer = 0
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        'Chercher le numéro de dossier de l'exercice correspondant à la facture
                        Dim exo As Exercice = TrouverDossier(rwFacture.Item("DateFacture"))
                        If exo Is Nothing Then
                            Throw New WarningExport(String.Format("Pas d'exercice disponible pour la facture du {0:dd/MM/yy}", rwFacture.Item("DateFacture")))
                        End If

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

                        For Each ligneDetail As DataRow In dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            If IsDBNull(ligneDetail.Item("NCompte")) OrElse IsDBNull(ligneDetail.Item("NActivite")) _
                            OrElse CStr(ligneDetail.Item("NCompte")).Length = 0 OrElse CStr(ligneDetail.Item("NActivite")).Length = 0 Then
                                Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le produit {0} dans la facture {1} du {2:dd/MM/yy}", NomProduit, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture")))
                            End If

                            'Vérif TVA
                            If Not IsDBNull(ligneDetail.Item("TTVA")) AndAlso ligneDetail.Item("TTVA") <> "" Then
                                Dim CodeTva As String = ""
                                If TVASurEncaissement = True Then
                                    CodeTva = CodeTVAEncaissementCorrespondant(ligneDetail.Item("TTVA"))
                                Else
                                    CodeTva = CStr(ligneDetail.Item("TTVA"))
                                End If
                                VerifExistenceTVA(CodeTva)
                            End If
                        Next

                        'Déterminer le n° de la pièce à utiliser pour la facture
                        Dim NumPiece As Integer
                        If Not IsNumeric(BlocnPieceDebutVFacture) Then BlocnPieceDebutVFacture = 50000
                        If Not IsNumeric(BlocnPieceFinVFacture) Then BlocnPieceFinVFacture = 80000
                        NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))

                        Dim libPiece As String = Left(String.Format("Vente {0} du {1:dd/MM/yy}: {2}", rwFacture("nFacture"), rwFacture("DateFacture"), rwEntreprise("Nom")), 50)

                        'Création de l'écriture
                        Dim ecr As New Ecriture
                        With ecr
                            .CodeJournal = CodeJournal
                            .DatePiece = rwFacture("DateFacture")
                            .NumPiece = NumPiece
                            .LibEcr = libPiece
                            .CodeSite = ""
                            .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                            .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                            .NonModifiable = False
                            .DateCreation = dtExport
                            .DateModif = dtExport
                        End With


                        'Trouver les infos du client de la facture
                        Dim CompteClient As String = rwEntreprise("NCompteC")
                        Dim ActiviteClient As String = rwEntreprise("NActiviteC")

                        Dim RecapTxTVA As New RecapTVA
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")

                        For Each ligneDetail As DataRow In lignesDetailFacture
                            ' Génération des comptes TVA si nécessaire
                            Dim CodeTVA As String = Convert.ToString(ligneDetail("TTVA"))
                            Dim TauxTva As Decimal = 0
                            Dim TVASansCompte As Boolean = False

                            If CodeTVA <> "" Then
                                If TVASurEncaissement Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                Dim ligneTVA As DataRow = GetRowTVA(CodeTVA)
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

                            Dim Unite1 As String = ReplaceDbNull(ligneDetail.Item("LibUnite1"), "")
                            Dim Unite2 As String = ReplaceDbNull(ligneDetail.Item("LibUnite2"), "")
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
                                    Case Else
                                        RecapTxTVA.AddMontant(CodeTVA, TauxTva, MontantHT, MontantTTC)
                                End Select
                            End If

                            'Créer le mouvement correspondant à la ligne de facture :
                            ' MONTANT HT AU CREDIT SUR COMPTE PRODUIT
                            Dim mvt As New Mouvement
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .LibMvt = Left(NomClient & " " & NomProduit, 30)
                                .MontantC = MontantHT
                                .Qte1 = Qte1
                                .Qte2 = Qte2
                                .CodeTva = Left(CodeTVA, 2)
                                'Association d'activité
                                If Convert.ToString(ligneDetail("NActivite")) <> "0000" Then
                                    .NbAct = 1
                                    .Activites.Add(New MvtActivite(ligneDetail("NActivite")))
                                End If
                            End With
                            ecr.Mouvements.Add(mvt)
                        Next

                        'CREATION DES LIGNES DE TVA
                        For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            If codeTVA.Length > 0 Then
                                If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                    'Créer le mouvement de TVA :
                                    ' MONTANT TVA AU CREDIT SUR COMPTE TVA
                                    Dim mvt As New Mouvement
                                    With mvt
                                        .Compte = RecapTxTVA.GetElementRecap(codeTVA).CompteTVA
                                        .LibMvt = Left(NomClient & " " & codeTVA, 30)
                                        .MontantC = Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2)
                                        .CodeTvaCompte = Left(codeTVA, 2)
                                    End With
                                    ecr.Mouvements.Add(mvt)
                                End If
                            End If
                        Next

                        'ON SOLDE L'ECRITURE
                        'MONTANT TTC FACTURE AU DEBIT SUR COMPTE CLIENT
                        Dim mvtClient As New Mouvement
                        With mvtClient
                            .Compte = CompteClient
                            .LibMvt = Left("TOTAL VENTE " & NumPiece, 30)
                            .MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)
                            'Association d'activité
                            If ActiviteClient <> "0000" Then
                                .NbAct = 1
                                .Activites.Add(New MvtActivite(ActiviteClient))
                            End If
                        End With
                        ecr.Mouvements.Add(mvtClient)

                        'Marquer la facture comme exportée
                        With rwFacture
                            .Item("ExportCompta") = True
                            .Item("DateExportCompta") = dtExport
                        End With

                        'Ajouter l'ecriture à l'export
                        exo.Ecritures.Add(ecr)

                    Catch ex As WarningExport
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
                Dim i As Integer = 0
                For Each rwRemise As DataRow In rwRemises
                    'Trouver le dossier de l'exercice
                    Try
                        Dim exo As Exercice = TrouverDossier(rwRemise.Item("DateRemise"))
                        If exo Is Nothing Then
                            Throw New WarningExport(String.Format("Pas d'exercice disponible pour la remise du {0:dd/MM/yy}", rwRemise.Item("DateRemise")))
                        End If

                        'Verifs avant création de la pièce
                        If IsDBNull(rwRemise.Item("nBanque")) Then
                            Throw New WarningExport(String.Format("Pas de banque renseignée pour la remise du {0:dd/MM/yy}", rwRemise.Item("DateRemise")))
                        End If
                        Dim rwBanque As DataRow = dsAgrifact.Tables("Banque").Select("nBanque='" & rwRemise.Item("nBanque") & "'", "")(0)
                        Dim NomBanque As String = rwBanque.Item("Libelle").toUpper
                        If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If

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

                        'Création du compte banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        Dim ActiviteBanque As String = rwBanque.Item("NActivite")

                        'Déterminer le n° de la piece
                        If Not IsNumeric(BlocnPieceDebutVReglement) Then BlocnPieceDebutVFacture = 100000
                        If Not IsNumeric(BlocnPieceFinVReglement) Then BlocnPieceFinVReglement = 150000

                        Dim NumPiece As Integer = 0
                        Try
                            'On essaye d'utiliser le nRemiseBanque
                            NumPiece = Integer.Parse(rwRemise.Item("nRemiseBanque"))
                        Catch ex As Exception
                        End Try
                        'On cadre le n° de piece dans la fourchette
                        NumPiece = CadreFourchette(NumPiece, CInt(BlocnPieceDebutVReglement), CInt(BlocnPieceFinVReglement))

                        Dim dtRemise As Date = CDate(rwRemise.Item("DateRemise"))
                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Remise {2} n°{0} du {1:dd/MM/yy}", rwRemise("nRemiseBanque"), dtRemise, rwRemise("TypeRemise")), 50)

                        'Création de l'écriture
                        Dim ecr As New Ecriture
                        With ecr
                            .CodeJournal = CodeJournal
                            .DatePiece = dtRemise
                            .NumPiece = NumPiece
                            .LibEcr = libPiece
                            .CodeSite = ""
                            .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                            .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                            .NonModifiable = False
                            .DateCreation = dtExport
                            .DateModif = dtExport
                        End With

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
                                    Dim mvt As New Mouvement
                                    With mvt
                                        .Compte = CompteClient
                                        .LibMvt = Left(libPaiement & " " & LibPaiement2, 30)
                                        .MontantC = Decimal.Round(CDec(rwReglementDetail.Item("Montant")), 2)
                                        'Association d'activité
                                        If ActiviteClient <> "0000" Then
                                            .NbAct = 1
                                            .Activites.Add(New MvtActivite(ActiviteClient))
                                        End If
                                    End With
                                    ecr.Mouvements.Add(mvt)

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
                                            Dim mvtPP As New Mouvement
                                            With mvtPP
                                                .Compte = COMPTE_PERTE
                                                .LibMvt = Left("Arrondi de paiement perte " & NumFacture, 30)
                                                .MontantD = perte
                                            End With
                                            ecr.Mouvements.Add(mvtPP)
                                            SommePayee += perte
                                        End If
                                    End If
                                    If Not IsDBNull(rwReglementDetail.Item("Profit")) Then
                                        If rwReglementDetail.Item("Profit") <> 0 Then
                                            Dim profit As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Profit")), 2)
                                            'Créer le mouvement correspondant au profit :
                                            ' MONTANT DU POFIT AU DEBIT SUR COMPTE PROFIT
                                            Dim mvtPP As New Mouvement
                                            With mvtPP
                                                .Compte = COMPTE_PROFIT
                                                .LibMvt = Left("Arrondi de paiement profit " & NumFacture, 30)
                                                .MontantC = profit
                                            End With
                                            ecr.Mouvements.Add(mvtPP)
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

                                        If TVASurEncaissement Then
                                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                                Dim rws() As DataRow = dsAgrifact.Tables("FactureMontantExport").Select(String.Format("nDetailReglement={0} AND TTVA='{1}'", rwReglementDetail.Item("nDetailReglement"), CodeTVA.Replace("'", "''")))
                                                If rws.Length = 0 Then
                                                    Dim rwFactureMontantExport As DataRow = dsAgrifact.Tables("FactureMontantExport").NewRow
                                                    With rwFactureMontantExport
                                                        .Item("nDevis") = nDevis
                                                        .Item("nDetailReglement") = rwReglementDetail.Item("nDetailReglement")
                                                        .Item("TTVA") = codeTVA
                                                        .Item("MontantHT") = elRecap.MontantHT
                                                        .Item("MontantTVA") = elRecap.MontantTVA
                                                        .Item("MontantTTC") = elRecap.MontantTTC
                                                        .Item("DateExportCompta") = Now
                                                    End With
                                                    dsAgrifact.Tables("FactureMontantExport").Rows.Add(rwFactureMontantExport)
                                                Else
                                                    With rws(0)
                                                        .BeginEdit()
                                                        .Item("nDevis") = nDevis
                                                        .Item("MontantHT") = elRecap.MontantHT
                                                        .Item("MontantTVA") = elRecap.MontantTVA
                                                        .Item("MontantTTC") = elRecap.MontantTTC
                                                        .Item("DateExportCompta") = Now
                                                        .EndEdit()
                                                    End With
                                                End If
                                                GlobalRecapTxTVA.AddMontant(codeTva, elRecap.TxTva, elRecap.MontantHT, elRecap.MontantTTC, elRecap.MontantTVA)
                                                GlobalRecapTxTVA.SetCompte(codeTVA, elRecap.CompteTVA, elRecap.TxTva)
                                            Next
                                        End If

                                        If MontantEscompte <> 0 Then
                                            'TODO REMONTER CA A CHAQUE FACTURE
                                            ' On solde le compte client du montant TTC de l'escompte au débit
                                            Dim mvtEscClient As New Mouvement
                                            With mvtEscClient
                                                .Compte = CompteClient
                                                .LibMvt = Left(NomClient & " escompte " & NumFacture, 30)
                                                .MontantC = MontantEscompte
                                                If ActiviteClient <> "0000" Then
                                                    .NbAct = 1
                                                    .Activites.Add(New MvtActivite(ActiviteClient))
                                                End If
                                            End With
                                            ecr.Mouvements.Add(mvtEscClient)

                                            ' On solde les compte TVA
                                            Dim MontantEscompteTVA As Decimal = 0
                                            For Each codeTVA As String In RecapTVAEscompte.GetLstTx()
                                                If RecapTVAEscompte.MontantTVATaux(codeTVA) <> 0 Then
                                                    MontantEscompteTVA += RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                    Dim mvtEscTva As New Mouvement
                                                    With mvtEscTva
                                                        .Compte = RecapTVAEscompte.GetElementRecap(codeTVA).CompteTVA
                                                        .CodeTvaCompte = CodeTVA
                                                        .LibMvt = Left("REGUL. TVA ESCOMPTE " & codeTVA & " " & NumFacture, 30)
                                                        .MontantC = RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                    End With
                                                    ecr.Mouvements.Add(mvtEscTva)
                                                End If
                                            Next

                                            Dim MontantEscompteHT As Decimal = MontantEscompte - MontantEscompteTVA
                                            ' on passe le montant HT de l'escompte en escompte
                                            Dim mvtEsc As New Mouvement
                                            With mvtEsc
                                                .Compte = COMPTE_ESCOMPTE
                                                .LibMvt = Left("Escompte Accordée " & NumFacture, 30)
                                                .MontantC = MontantEscompteHT
                                            End With
                                            ecr.Mouvements.Add(mvtEsc)
                                        End If
                                    End If
                                End If
                            Next 'NEXT FACTURE

                            If TVASurEncaissement Then
                                For Each codeTVA As String In GlobalRecapTxTVA.GetLstTx()
                                    Dim MontantHT As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantHTTaux(codeTVA), 2)
                                    Dim MontantTVA As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantTVATaux(codeTVA), 2)
                                    Dim MontantTTC As Decimal = Decimal.Round(MontantHT + MontantTVA, 2)

                                    If GlobalRecapTxTVA.GetElementRecap(codetva).CompteTVA.Length > 0 Then
                                        'Ligne de TVA
                                        Dim mvt As New Mouvement
                                        With mvt
                                            .Compte = GlobalRecapTxTVA.GetElementRecap(codetva).CompteTVA
                                            .CodeTvaCompte = CodeTVA
                                            .LibMvt = "REGUL TVA"
                                            .MontantC = MontantTVA
                                        End With
                                        ecr.Mouvements.Add(mvt)
                                    End If
                                    Dim CodeTVAEnc As String = CodeTVAEncaissementCorrespondant(codeTVA)

                                    'Ligne de TVA
                                    Dim rwTva As DataRow = GetRowTVA(CodeTVAEnc)
                                    If Not rwTVA Is Nothing Then
                                        If Not IsDBNull(rwTva("TCpt")) Then
                                            Dim mvt As New Mouvement
                                            With mvt
                                                .Compte = rwTva("TCpt")
                                                .CodeTvaCompte = CodeTVAEnc
                                                .LibMvt = "REGUL TVA"
                                                .MontantD = MontantTVA
                                            End With
                                            ecr.Mouvements.Add(mvt)
                                        End If

                                    End If
                                Next
                            End If

                            'S'il reste de l'avance client :
                            If AvanceClient <> 0 Then
                                'Créer une ligne pour équilibrer la pièce vers le payeur
                                'Déterminer les informations PAYEUR
                                Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement("nEntreprise") & "'", "")(0)
                                Dim NomPayeur As String = rwEntreprise.Item("Nom").toUpper
                                Dim ComptePayeur As String = rwEntreprise.Item("NCompteC")
                                Dim ActivitePayeur As String = rwEntreprise.Item("NActiviteC")

                                Dim mvtAvance As New Mouvement
                                With mvtAvance
                                    .Compte = ComptePayeur
                                    .LibMvt = Left("AVANCE " & NomPayeur, 30)
                                    .MontantC = AvanceClient
                                    If ActivitePayeur <> "0000" Then
                                        .NbAct = 1
                                        .Activites.Add(New MvtActivite(ActivitePayeur))
                                    End If
                                End With
                                ecr.Mouvements.Add(mvtAvance)
                            End If

                            'Marquer le reglement comme exporté
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = Now
                        Next 'NEXT REGLEMENT

                        'ON SOLDE LA REMISE PAR LA BANQUE
                        Dim mvtBq As New Mouvement
                        With mvtBq
                            .Compte = CompteBanque
                            .LibMvt = String.Format("TOTAL REMISE {0}", rwRemise("nRemiseBanque"))
                            .MontantD = Decimal.Round(CDec(rwRemise.Item("Montant")), 2)
                            If ActiviteBanque <> "0000" Then
                                .NbAct = 1
                                .Activites.Add(New MvtActivite(ActiviteBanque))
                            End If
                        End With
                        ecr.Mouvements.Add(mvtBq)

                        'MARQUER LA REMISE COMME EXPORTEE
                        rwRemise.Item("ExportCompta") = True
                        rwRemise.Item("DateExportCompta") = dtExport

                        exo.Ecritures.Add(ecr)

                    Catch ex As WarningExport
                        'Probleme sur cette remise. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwRemises.Length)
                Next 'NEXT REMISE
            End If
            Return True
        End Function

        Protected Overrides Function ExporterFacturesAchat() As Boolean
            If AFacture = True Then
                ReportProgress(0, "Exportation des factures fournisseur")
                ' FACTURES D'ACHAT
                Dim dtExport As Date = Now
                Dim CodeJournal As String = TrouverCodeJournal("ac")
                Dim CodeTVAAchat As String = "A"
                Dim CodeTVAAchatImmo196 As String = "I"
                Dim CodeTVAAchatImmo55 As String = "S"

                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebAFacture, DateFinAFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("AFacture").Select(strFiltre, "nFacture")
                Dim i As Integer = 0
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        Dim exo As Exercice = TrouverDossier(rwFacture("DateFacture"))
                        If exo Is Nothing Then
                            Throw New WarningExport(String.Format("Pas de dossier disponible pour la facture d'achat du {0:dd/MM/yy}", rwFacture.Item("DateFacture")))
                        End If

                        'Verifs avant la création de pièce
                        Dim rwFournisseur As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwFacture.Item("nClient") & "'", "")(0)
                        Dim NomFournisseur As String = rwFournisseur.Item("Nom").toUpper
                        If IsDBNull(rwFournisseur.Item("NCompteF")) OrElse IsDBNull(rwFournisseur.Item("NActiviteF")) _
                        OrElse CStr(rwFournisseur.Item("NCompteF")).Length = 0 OrElse CStr(rwFournisseur.Item("NActiviteF")).Length = 0 Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If

                        For Each ligneDetail As DataRow In dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
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

                        Dim libPiece As String = Left(String.Format("Achat {0} du {1:dd/MM/yy}: {2}", rwFacture("nFacture"), rwFacture("DateFacture"), rwFournisseur("Nom")), 50)

                        'Création de l'écriture
                        Dim ecr As New Ecriture
                        With ecr
                            .CodeJournal = CodeJournal
                            .DatePiece = rwFacture("DateFacture")
                            .NumPiece = NumPiece
                            .LibEcr = libPiece
                            .CodeSite = ""
                            .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                            .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                            .NonModifiable = False
                            .DateCreation = dtExport
                            .DateModif = dtExport
                        End With

                        'Récupération des infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")

                        Dim Ligne As Integer = 0
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0
                        For Each ligneDetail As DataRow In lignesDetailFacture
                            Dim CompteProduit As String = ligneDetail("NCompte")
                            Dim CodeTVA As String
                            Select Case CompteProduit.Substring(0, 1)
                                Case "1" 'Pour gérer les comptes 1013 de parts sociales
                                    CodeTVA = ""
                                    TTCCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case "6" 'ACHAT NORMAL
                                    CodeTVA = TrouverCodeTVA("ac", 0)
                                    TVACptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTVA"), 2)
                                    TTCCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case "2" 'ACHAT D'IMMO                                
                                    CodeTVA = TrouverCodeTVA("im", 0, "A")
                                    TVACptImmo += Decimal.Round(ligneDetail.Item("MontantLigneTVA"), 2)
                                    TTCCptImmo += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case Else
                                    Throw New WarningExport(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Compte produit incorrect {2}: Le compte doit être en 1,2 ou 6", NumPiece, rwFacture.Item("DateFacture"), CompteProduit))
                                    Return False
                            End Select

                            If CodeTVA <> "" And TVASurEncaissement Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                            'Informations produit pour création du compte Produit
                            Dim Unite1 As String = ReplaceDbNull(ligneDetail.Item("LibUnite1"), "")
                            Dim Unite2 As String = ReplaceDbNull(ligneDetail.Item("LibUnite2"), "")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            Dim Qte1 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite1"), 0)), 2)
                            Dim Qte2 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite2"), 0)), 2)

                            Dim mvt As New Mouvement
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .CodeTva = CodeTVA
                                .LibMvt = Left(NomFournisseur & " " & NomProduit, 30)
                                .MontantD = Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2)
                                If Convert.ToString(ligneDetail("NActivite")) <> "0000" Then
                                    .NbAct = 1
                                    .Activites.Add(New MvtActivite(ligneDetail("NActivite")))
                                End If
                            End With
                            ecr.Mouvements.Add(mvt)
                        Next

                        'SOLDER LES CHARGES
                        If TTCCptCharge <> 0 Then
                            Dim CodeTVA As String = TrouverCodeTVA("ac", 0)
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")
                            If TVASurEncaissement = True Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                            Dim mvtTVA As New Mouvement
                            With mvtTVA
                                .Compte = comptetva
                                .CodeTvaCompte = CodeTVA
                                .LibMvt = Left(String.Format("{0} TVA {1}", NomFournisseur, CodeTVA), 30)
                                .MontantD = Decimal.Round(TVACptCharge, 2)
                            End With
                            ecr.Mouvements.Add(mvtTVA)

                            Dim mvtFour As New Mouvement
                            With mvtFour
                                .Compte = CompteFournisseur
                                .LibMvt = Left(String.Format("TOTAL ACHAT {0}", NumPiece), 30)
                                .MontantC = Decimal.Round(TTCCptCharge, 2)
                                If ActiviteFournisseur <> "0000" Then
                                    .NbAct = 1
                                    .Activites.Add(New MvtActivite(ActiviteFournisseur))
                                End If
                            End With
                            ecr.Mouvements.Add(mvtFour)
                        End If

                        'SOLDER LES IMMOS
                        If TTCCptImmo <> 0 Then
                            Dim CodeTVA As String = TrouverCodeTVA("im", 0, "A")
                            If TVASurEncaissement = True Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            Dim mvtTVA As New Mouvement
                            With mvtTVA
                                .Compte = comptetva
                                .CodeTvaCompte = CodeTVA
                                .LibMvt = Left(String.Format("{0} TVA {1} SUR IMMO", NomFournisseur, CodeTVA), 30)
                                .MontantD = Decimal.Round(TVACptImmo, 2)
                            End With
                            ecr.Mouvements.Add(mvtTVA)

                            Dim mvtFour As New Mouvement
                            With mvtFour
                                .Compte = CompteFournisseur
                                .LibMvt = Left(String.Format("TOTAL ACHAT IMMO {0}", NumPiece), 30)
                                .MontantC = Decimal.Round(TTCCptImmo, 2)
                                If ActiviteFournisseur <> "0000" Then
                                    .NbAct = 1
                                    .Activites.Add(New MvtActivite(ActiviteFournisseur))
                                End If
                            End With
                            ecr.Mouvements.Add(mvtFour)
                        End If

                        rwFacture.Item("ExportCompta") = True
                        rwFacture.Item("DateExportCompta") = dtExport

                        exo.Ecritures.Add(ecr)
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
            If AReglement = True Then
                ReportProgress(0, "Exportation des réglements fournisseur")
                ' REMISE ET REGLEMENTS RESULTANT DES ACHATS
                Dim dtExport As Date = Now
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateReglement>='{0}' and DateReglement<='{1}')", DateDebAReglement, DateFinAReglement)
                Dim rwReglementsAExporter() As DataRow = dsAgrifact.Tables("AReglement").Select(strFiltre, "nReglement")
                Dim i As Integer = 0
                For Each rwReglement As DataRow In rwReglementsAExporter
                    Try

                        Dim TTCEscompteCharge As Decimal = 0
                        Dim TVAEscompteCharge As Decimal = 0
                        Dim HTEscompteCharge As Decimal = 0
                        Dim TTCEscompteImmo As Decimal = 0
                        Dim TVAEscompteImmo As Decimal = 0
                        Dim HTEscompteImmo As Decimal = 0
                        Dim exo As Exercice = TrouverDossier(rwReglement("DateReglement"))
                        If exo Is Nothing Then
                            Throw New WarningExport(String.Format("Pas d'exercice disponible pour le réglement achat du {0:dd/MM/yy}", rwReglement.Item("DateReglement")))
                        End If

                        'Verifs avant la création de pièce
                        Dim rwFournisseur As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement.Item("nEntreprise") & "'", "")(0)
                        Dim NomFournisseur As String = rwFournisseur.Item("Nom").toUpper
                        If IsDBNull(rwFournisseur.Item("NCompteF")) Or IsDBNull(rwFournisseur.Item("NActiviteF")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If

                        'Dim rwBanque As DataRow = dsAgrifact.Tables("Banque").Select("nBanque='" & rwReglement.Item("nBanque") & "'", "")(0)
                        'TODO : Probleme pour les reglements d'achat on ne stocke pas le nBanque mais juste son libelle
                        Dim rwsBanque() As DataRow = dsAgrifact.Tables("Banque").Select("Libelle='" & rwReglement("BanqueClient").Replace("'", "''") & "'", "")
                        If rwsBanque.Length = 0 Then
                            Throw New WarningExport(String.Format("La banque {0} est introuvable", rwReglement("BanqueClient")))
                        End If
                        Dim rwBanque As DataRow = rwsBanque(0)
                        Dim NomBanque As String = rwBanque.Item("Libelle").toUpper
                        If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If

                        'Infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")

                        'Infos banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        Dim ActiviteBanque As String = rwBanque.Item("NActivite")

                        'Déterminer le n° de la piece
                        Dim NumPiece As Integer = rwReglement.Item("nReglement")
                        If Not IsNumeric(BlocnPieceDebutAReglement) Then BlocnPieceDebutAReglement = 150000
                        If Not IsNumeric(BlocnPieceFinAReglement) Then BlocnPieceFinAReglement = 200000

                        'TODO N° à revoir ? => On n'a aucun n° de remise à utiliser
                        NumPiece = CadreFourchette(rwReglement.Item("nReglement"), CInt(BlocnPieceDebutAReglement), CInt(BlocnPieceFinAReglement))

                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Régl. fourn. {0} du {1:dd/MM/yy}: {3}", rwReglement("nMode"), rwReglement("DateReglement"), NomFournisseur), 50)

                        'Création de l'écriture
                        Dim ecr As New Ecriture
                        With ecr
                            .CodeJournal = CodeJournal
                            .DatePiece = rwReglement("DateReglement")
                            .NumPiece = NumPiece
                            .LibEcr = libPiece
                            .CodeSite = ""
                            .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                            .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                            .NonModifiable = False
                            .DateCreation = dtExport
                            .DateModif = dtExport
                        End With

                        Dim Escompte As Boolean = (Not rwReglement.IsNull("TxEscompte") AndAlso rwReglement.Item("TxEscompte") <> 0)

                        'Créer la ligne du réglement
                        Dim DetailFacture As DataRow = dsAgrifact.Tables("AFacture").Select("nDevis=" & dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'")(0).Item("NFacture") & "", "")(0)
                        Dim NumFacture As Integer = DetailFacture("NFacture")
                        NumFacture = CadreFourchette(DetailFacture("NFacture"), CInt(BlocnPieceDebutAFacture), CInt(BlocnPieceFinAFacture))

                        Dim libPaiement As String = "PAIEMENT " & NumFacture & " " & rwReglement.Item("nMode") & " " & NomFournisseur

                        'MONTANT DU PAIEMENT AU DEBIT DU COMPTE FOURNISSEUR
                        Dim mvt As New Mouvement
                        With mvt
                            .Compte = CompteFournisseur
                            .LibMvt = Left(libPaiement, 30)
                            .MontantD = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                            If ActiviteFournisseur <> "0000" Then
                                .NbAct = 1
                                mvt.Activites.Add(New MvtActivite(ActiviteFournisseur))
                            End If
                        End With
                        ecr.Mouvements.Add(mvt)

                        'MONTANT DU PAIEMENT AU CREDIT DU COMPTE BANQUE
                        mvt = New Mouvement
                        With mvt
                            .Compte = CompteBanque
                            .LibMvt = Left(libPaiement, 30)
                            .MontantC = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                            If ActiviteBanque <> "0000" Then
                                .NbAct = 1
                                .Activites.Add(New MvtActivite(ActiviteBanque))
                            End If
                        End With
                        ecr.Mouvements.Add(mvt)

                        'FactureMontantExport
                        Dim SommeDue As Decimal = 0
                        Dim SommePayee As Decimal = 0
                        Dim SommeDejaPayee As Decimal = 0
                        Dim rapportPayeeDu As Decimal = 1
                        Dim SoldeFacture As Boolean = False
                        Dim rwTest As DataRow = dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0)

                        ' Rajouter à la somme payée ce qui a été éventuellement déjà payé et exporté
                        Dim obj As Object = dsAgrifact.Tables("AFactureMontantExport").Compute("Sum(MontantTTC)", "nDevis=" & rwTest.Item("NFacture") & "")
                        If Not obj Is DBNull.Value Then
                            SommeDejaPayee = CDec(obj)
                        End If
                        SommePayee = CDec(rwTest.Item("Montant"))
                        SommeDue = CDec(dsAgrifact.Tables("AFacture").Select("nDevis=" & rwTest.Item("NFacture") & "", "")(0).Item("MontantTTC"))
                        If Not rwReglement.Item("TxEscompte") Is DBNull.Value Then
                            If rwReglement.Item("TxEscompte") <> 0 Then
                                SommeDue -= CDec(rwReglement.Item("MontantEscompte"))
                            End If
                        End If

                        '---------------------------------
                        '--- GESTION DES PERTES ET PROFIT
                        '---------------------------------
                        If Not rwReglement.Item("Perte") Is DBNull.Value Then
                            If rwReglement.Item("Perte") <> 0 Then
                                Dim perte As Decimal = Decimal.Round(CDec(rwReglement.Item("Perte")), 2)
                                'Créer le mouvement correspondant à la perte (la perte d'un reglement fournisseur est un profit pour nous) :
                                ' MONTANT DU PROFIT AU CREDIT SUR COMPTE PROFIT
                                Dim mvtPP As New Mouvement
                                With mvtPP
                                    .Compte = COMPTE_PROFIT
                                    .LibMvt = Left("Arrondi de paiement profit " & NumFacture, 30)
                                    .MontantC = perte
                                End With
                                ecr.Mouvements.Add(mvtPP)
                                ' MONTANT DU PROFIT AU DEBIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Mouvement
                                With mvtPP
                                    .Compte = CompteFournisseur
                                    .LibMvt = Left("Arrondi de paiement profit " & NumFacture, 30)
                                    .MontantD = perte
                                    If ActiviteFournisseur <> "0000" Then
                                        .NbAct = 1
                                        .Activites.Add(New MvtActivite(ActiviteFournisseur))
                                    End If
                                End With
                                ecr.Mouvements.Add(mvtPP)
                                SommePayee += perte
                            End If
                        End If
                        If Not rwReglement.IsNull("Profit") Then
                            If rwReglement.Item("Profit") <> 0 Then
                                Dim profit As Decimal = Decimal.Round(CDec(rwReglement.Item("Profit")), 2)
                                'Créer le mouvement correspondant à la perte :
                                ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE PERTE 
                                Dim mvtPP As New Mouvement
                                With mvtPP
                                    .Compte = COMPTE_PERTE
                                    .LibMvt = Left("Arrondi de paiement perte " & NumFacture, 30)
                                    .MontantD = profit
                                End With
                                ecr.Mouvements.Add(mvtPP)
                                ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Mouvement
                                With mvtPP
                                    .Compte = CompteFournisseur
                                    .LibMvt = Left("Arrondi de paiement perte " & NumFacture, 30)
                                    .MontantC = profit
                                    If ActiviteFournisseur <> "0000" Then
                                        .NbAct = 1
                                        .Activites.Add(New MvtActivite(ActiviteFournisseur))
                                    End If
                                End With
                                ecr.Mouvements.Add(mvtPP)
                                SommePayee -= profit
                            End If
                        End If

                        If SommeDue <> SommePayee Then
                            If Math.Abs(SommeDejaPayee + SommePayee - SommeDue) <= 0.2 Then
                                SoldeFacture = True
                            Else
                                rapportPayeeDu = SommePayee / SommeDue
                            End If
                        End If

                        Dim HTCptCharge As Decimal = 0
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim HTCptImmo As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0

                        If Not SoldeFacture Then
                            Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                            For Each ligneDetail As DataRow In lignesDetailFacture
                                Dim CptProduit As String = ligneDetail.Item("NCompte")
                                If CptProduit.StartsWith("2") Then
                                    TVACptImmo += (ligneDetail.Item("MontantLigneTVA") * rapportPayeeDu)
                                    TTCCptImmo += (ligneDetail.Item("MontantLigneTTC") * rapportPayeeDu)
                                ElseIf CptProduit.StartsWith("6") Then
                                    TVACptCharge += (ligneDetail.Item("MontantLigneTVA") * rapportPayeeDu)
                                    TTCCptCharge += (ligneDetail.Item("MontantLigneTTC") * rapportPayeeDu)
                                Else
                                    Throw New WarningExport(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Compte incorrect !", NumPiece, rwReglement.Item("DateReglement")))
                                End If
                            Next
                        Else
                            Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                            Dim ligneDetail As DataRow
                            For Each ligneDetail In lignesDetailFacture
                                Dim CptProduit As String = ligneDetail("NCompte")
                                If CptProduit.StartsWith("2") Then
                                    TVACptImmo += ligneDetail.Item("MontantLigneTVA")
                                    TTCCptImmo += ligneDetail.Item("MontantLigneTTC")
                                ElseIf CptProduit.StartsWith("6") Then
                                    TVACptCharge += ligneDetail.Item("MontantLigneTVA")
                                    TTCCptCharge += ligneDetail.Item("MontantLigneTTC")
                                End If
                            Next

                            lignesDetailFacture = dsAgrifact.Tables("AFactureMontantExport").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "'", "nDevis")
                            For Each ligneDetail In lignesDetailFacture
                                'DETERMINER SI LE CODE TVA EST DE L'IMMO
                                If CheckTypTVA(ligneDetail.Item("TTVA"), "im") Then
                                    TVACptImmo -= ligneDetail.Item("MontantTVA")
                                    TTCCptImmo -= ligneDetail.Item("MontantTTC")
                                Else
                                    TVACptCharge -= ligneDetail.Item("MontantTVA")
                                    TTCCptCharge -= ligneDetail.Item("MontantTTC")
                                End If
                            Next
                        End If

                        TVACptImmo = Decimal.Round(TVACptImmo, 2)
                        TTCCptImmo = Decimal.Round(TTCCptImmo, 2)
                        HTCptImmo = TTCCptImmo - TVACptImmo

                        TVACptCharge = Decimal.Round(TVACptCharge, 2)
                        TTCCptCharge = Decimal.Round(TTCCptCharge, 2)
                        HTCptCharge = TTCCptCharge - TVACptCharge


                        '----------------------------------------
                        '--- GESTION DE LA TVA SUR ENCAISSEMENT
                        '---------------------------------------
                        If TVASurEncaissement Then
                            If HTCptCharge <> 0 Then
                                Dim CodeTVA As String = TrouverCodeTVA("ac", 0)
                                Dim rwFactureMontantExport As DataRow = dsAgrifact.Tables("AFactureMontantExport").NewRow
                                With rwFactureMontantExport
                                    .Item("nDevis") = dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture")
                                    .Item("TTVA") = CodeTVA
                                    .Item("MontantHT") = HTCptCharge
                                    .Item("MontantTVA") = TVACptCharge
                                    .Item("MontantTTC") = TTCCptCharge
                                    .Item("DateExportCompta") = Now
                                End With
                                dsAgrifact.Tables("AFactureMontantExport").Rows.Add(rwFactureMontantExport)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))
                                Dim cptTVA As String = GetRowTVA(codetva)("TCpt")
                                Dim mvtTVA As New Mouvement
                                With mvtTVA
                                    .Compte = cptTVA
                                    .CodeTvaCompte = CodeTVA
                                    .LibMvt = Left("REGUL. TVA " & NumFacture, 30)
                                    .MontantD = Decimal.Round(CDec(TVACptCharge), 2)
                                End With
                                ecr.Mouvements.Add(mvtTVA)

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                cptTVA = GetRowTVA(codetva)("TCpt")
                                mvtTVA = New Mouvement
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = Left("REGUL. TVA " & NumFacture, 30)
                                    .MontantC = Decimal.Round(CDec(TVACptCharge), 2)
                                End With
                                ecr.Mouvements.Add(mvtTVA)
                            End If
                            If HTCptImmo <> 0 Then
                                Dim CodeTVA As String = TrouverCodeTVA("im", 0, "A")
                                Dim rwFactureMontantExport As DataRow = dsAgrifact.Tables("AFactureMontantExport").NewRow
                                With rwFactureMontantExport
                                    .Item("nDevis") = dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture")
                                    .Item("TTVA") = CodeTVA
                                    .Item("MontantHT") = HTCptImmo
                                    .Item("MontantTVA") = TVACptImmo
                                    .Item("MontantTTC") = TTCCptImmo
                                    .Item("DateExportCompta") = Now
                                End With
                                dsAgrifact.Tables("AFactureMontantExport").Rows.Add(rwFactureMontantExport)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))
                                Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                Dim mvtTVA As New Mouvement
                                With mvtTVA
                                    .Compte = cptTVA
                                    .CodeTvaCompte = CodeTVA
                                    .LibMvt = Left("REGUL. TVA SUR IMMO " & NumFacture, 30)
                                    .MontantD = Decimal.Round(CDec(TVACptImmo), 2)
                                End With
                                ecr.Mouvements.Add(mvtTVA)

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                cptTVA = GetRowTVA(codetva)("TCpt")
                                mvtTVA = New Mouvement
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = Left("REGUL. TVA SUR IMMO " & NumFacture, 30)
                                    .MontantC = Decimal.Round(CDec(TVACptImmo), 2)
                                End With
                                ecr.Mouvements.Add(mvtTVA)
                            End If
                        End If

                        '---------------------------------------
                        '--- GESTION DE L'ESCOMPTE
                        '---------------------------------------
                        If Not rwReglement.IsNull("TxEscompte") Then
                            If rwReglement("TxEscompte") <> 0 Then
                                Dim MontantTTCAvecEscompte As Decimal = Decimal.Round(CDec(rwReglement("MontantEscompte")), 2)
                                Dim MontantTVAAvecEscompteImmo As Decimal = Decimal.Round(TVACptImmo * rwReglement.Item("TxEscompte"), 2)
                                Dim MontantTVAAvecEscompteCharge As Decimal = Decimal.Round(TVACptCharge * rwReglement.Item("TxEscompte"), 2)
                                Dim MontantHTAvecEscompte As Decimal = MontantTTCAvecEscompte - (MontantTVAAvecEscompteImmo + MontantTVAAvecEscompteCharge)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))

                                ' On solde le compte fournisseur du montant TTC de l'escompte
                                Dim mvtEsc As New Mouvement
                                With mvtEsc
                                    .Compte = CompteFournisseur
                                    .LibMvt = NomFournisseur & " escompte " & NumFacture
                                    .MontantD = MontantTTCAvecEscompte
                                    If ActiviteFournisseur <> "0000" Then
                                        .NbAct = 1
                                        .Activites.Add(New MvtActivite(ActiviteFournisseur))
                                    End If
                                End With
                                ecr.Mouvements.Add(mvtEsc)

                                ' on passe le montant de l'escompte en escompte
                                mvtEsc = New Mouvement
                                With mvtEsc
                                    .Compte = COMPTE_ESCOMPTE_OBTENUE
                                    .LibMvt = "Escompte Obtenue " & NumFacture
                                    .MontantC = MontantHTAvecEscompte
                                End With
                                ecr.Mouvements.Add(mvtEsc)

                                ' On solde les codes TVA
                                If MontantTVAAvecEscompteCharge <> 0 Then
                                    Dim codeTVA As String = TrouverCodeTVA("ac", 0)
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Mouvement
                                    With mvtEsc
                                        .Compte = cpttva
                                        .LibMvt = "REGUL. TVA ESCOMPTE " & NumFacture
                                        .MontantC = MontantTVAAvecEscompteCharge
                                    End With
                                    ecr.Mouvements.Add(mvtEsc)
                                End If
                                If MontantTVAAvecEscompteImmo <> 0 Then
                                    Dim codeTVA As String = TrouverCodeTVA("im", 0, "A")
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Mouvement
                                    With mvtEsc
                                        .Compte = cpttva
                                        .LibMvt = "REGUL. TVA IMMO ESCOMPTE " & NumFacture
                                        .MontantC = MontantTVAAvecEscompteImmo
                                    End With
                                    ecr.Mouvements.Add(mvtEsc)
                                End If
                            End If
                        End If

                        With rwReglement
                            .Item("ExportCompta") = True
                            .Item("DateExportCompta") = dtExport
                        End With

                        exo.Ecritures.Add(ecr)
                    Catch ex As WarningExport
                        'Probleme sur ce reglement. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwReglementsAExporter.Length)
                Next
            End If
            Return True
        End Function

        Protected Overrides Sub UpdateData()
            'ENREGISTRER LE FICHIER EXPORT
            If export.Dossiers.Count = 0 _
            OrElse CType(export.Dossiers(0), Dossier).Exercices.Count = 0 _
            OrElse CType(CType(export.Dossiers(0), Dossier).Exercices(0), Exercice).Ecritures.Count = 0 Then
                Me.RapportExport.Append("Aucune écriture exportée" & vbCrLf)
            Else
                'Exporter dans le fichier
                ReportProgress(0, "Ecriture du fichier...")
                export.Exporter(fichier, ";", options.ModeExportation)
                'Enregistrement des données
                MyBase.UpdateData()
            End If
        End Sub
    End Class
#Region "Classes util pour export"

    Friend Class OptionsExport
        Public ModeExportation As Utils.ModeExportation = ModeExportation.TailleFixe
        Public TitreExport As String
        Public ExporterActivites As Boolean = True
        Public ExporterPlanCpt As Boolean = True
        Public ExporterTVA As Boolean = False
        Public ExporterJournaux As Boolean = False
        Public ExporterPieces As Boolean = True
        Public ForcerExportFullPieces As Boolean = True

        Public Sub New(ByVal ForceExportFullPiece As Boolean, Optional ByVal titre As String = "", Optional ByVal mode As Utils.ModeExportation = Utils.ModeExportation.TailleFixe, Optional ByVal expAct As Boolean = False, Optional ByVal expCpt As Boolean = False, Optional ByVal expTva As Boolean = False, Optional ByVal expJour As Boolean = False, Optional ByVal expPieces As Boolean = True)
            Me.ModeExportation = mode
            Me.TitreExport = titre
            Me.ExporterActivites = expAct
            Me.ExporterPlanCpt = expCpt
            Me.ExporterTVA = expTva
            Me.ExporterJournaux = expJour
            Me.ExporterPieces = expPieces
            ForcerExportFullPieces = ForceExportFullPiece
        End Sub
    End Class

    Friend Class ModeleExport
        Private FormatDate As String = "ddMMyyyy"

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
            If mode = ModeExportation.Delimite Then
                EcrireLigneSep(tw, sep, FormatDate, GetFields)
            Else
                EcrireLigneFormat(tw, GetFormat, FormatDate, GetFields)
            End If
            For Each item As ModeleExport In GetSubItems() : item.Exporter(tw, sep, mode) : Next
        End Sub
    End Class

    Friend Class Export
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-7}{2,-4}{3,1}{4,-30}{5,1}"
        Private Const FLAG As String = "VER"
        Public VersIsaCompta As String = "0200000"
        Public Zone As String = "0000"
        Public ResetDossier As Boolean = False
        Public LibFichier As String
        Public AnsiEncoding As Boolean = True
        Public Dossiers As New ArrayList
        Public sDossier As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal Opt As OptionsExport)
            Me.New()
            Me.LibFichier = Left(Opt.TitreExport, 30)
            ResetDossier = Opt.ForcerExportFullPieces
        End Sub

        Public Overloads Sub Exporter(ByVal fichier As String, ByVal sep As String, ByVal mode As ModeExportation)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
            Exporter(sw, sep, mode)
            sw.Close()
        End Sub

        Public Overloads Sub LogErreur(ByVal fichier As String, ByVal sLigneErreur As String)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, True, System.Text.Encoding.Default)
            sw.WriteLine(sLigneErreur)
            sw.Close()
        End Sub

        Public Overloads Sub Exporter(ByVal sb As System.Text.StringBuilder, ByVal sep As String, ByVal mode As ModeExportation)
            Exporter(New IO.StringWriter(sb), sep, mode)
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, VersIsaCompta, Zone, ResetDossier, LibFichier, AnsiEncoding}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Dossiers
        End Function

    End Class

    Friend Class Dossier
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-8}{2,-30}{3,8}{4,1}{5,1}{6,1}{7,1}{8,1}{9,1}{10,-2}{11,1}{12,-3}{13,1}"
        Private Const FLAG As String = "DOS"
        Public NumDossier As String
        Public LibDossier As String
        Public DateCloture As Date
        Public MajAnal As Boolean = True
        Public MajCpt As Boolean = True
        Public MajJournaux As Boolean = True
        Public MajTVA As Boolean = True
        Public TailleComptes As Integer
        Public Exercices As New ArrayList

        Public Sub New()
            Me.TailleComptes = 8
        End Sub

        Public Sub New(ByVal rwExpl As DataRow)
            Me.New()
            With Me
                .NumDossier = Mid(rwExpl("EExpl"), 2, 8)
                .LibDossier = Left(rwExpl("ENom1"), 30)
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, NumDossier, LibDossier, DateCloture, MajAnal, MajCpt, MajJournaux, MajTVA, " ", " ", TailleComptes, " ", " ", " "}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Exercices
        End Function
    End Class

    Friend Class Exercice
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,8}{2,8}{3,1}{4,1}{5,-11}{6,-3}"
        Private Const FLAG As String = "EXO"
        Public DateDebEx As Date
        Public DateFinEx As Date
        Public ResetEcritures As Boolean = False
        Public Devise As String
        Public Activites As New ArrayList
        Public Comptes As New ArrayList
        Public TVAs As New ArrayList
        Public Journaux As New ArrayList
        Public Ecritures As New ArrayList

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwDossier As DataRow, ByVal Opt As OptionsExport)
            Me.New()
            With Me
                .DateDebEx = rwDossier("DDtDebEx")
                .DateFinEx = rwDossier("DDtFinEx")
                .ResetEcritures = Opt.ForcerExportFullPieces
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, DateDebEx, DateFinEx, ResetEcritures, " ", " ", Devise}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Dim a As New ArrayList
            With a
                .AddRange(Activites)
                .AddRange(Comptes)
                .AddRange(TVAs)
                .AddRange(Journaux)
                .AddRange(Ecritures)
            End With
            Return a
        End Function
    End Class

    Friend Class Activite
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-6}{2,-2}{3,-40}{4,-6}{5,-5}{6,11:00000000.00}{7,1}{8,-5}{9,11:00000000.00}"
        Private Const FLAG As String = "ANA"
        Public CodeAct As String
        Public CodeDecoupe As String
        Public LibAct As String
        Public Unite1 As String
        Public Qte1 As Decimal
        Public Unite2 As String
        Public Qte2 As Decimal

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwAct As DataRow)
            Me.New()
            With Me
                .CodeAct = Left(rwAct("AActi"), 6)
                .LibAct = Left(rwAct("ALib"), 40)
                .Unite1 = Left(rwAct("AUnit"), 5)
                .Qte1 = CDec(rwAct("AQte"))
            End With
        End Sub

        Public Sub New(ByVal sActivite As String, ByVal sLibelle As String, ByVal sUnite As String, ByVal sQte As Decimal)
            Me.New()
            With Me
                .CodeAct = Left(sActivite, 6)
                .LibAct = Left(sLibelle, 40)
                .Unite1 = Left(sUnite, 5)
                .Qte1 = sQte
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeAct, CodeDecoupe, LibAct, " ", Unite1, Qte1, " ", Unite2, Qte2}
        End Function
    End Class

    Friend Class Compte
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,10}{2,30}{3,-10}{4,-3}{5,-10}{6,-3}{7,-10}{8,1}{9,-3}{10,-2}{11,-7}{12,-10}" & _
                                        "{13,-10}{14,1}{15,-2}{16,-2}{17,1}{18,-10}{19,-10}{20,-10}{21,1}{22,1}{23,1}{24,-30}" & _
                                        "{25,4}{26,3}{27,1}{28,1}{29,1}{30,1}{31,1}{32,1}{33,1}{34,1}{35,1}{36,1}{37,-11}"
        Private Const FLAG As String = "CPT"
        Public NCompte As String
        Public LibCompte As String
        Public CodeAlpha As String
        Public Unite1 As String
        Public LibUnite1 As String
        Public Unite2 As String
        Public LibUnite2 As String
        Public NumAutorise As Boolean
        Public CodeLettrage As String
        Public TypeCompte As String
        Public Tiers As String
        Public CpteDeb As String
        Public CpteCred As String
        Public CentrGdLivre As Boolean
        Public SensSaisi As String
        Public CodeTva As String
        Public TvaAutorise As Boolean
        Public CpteRegroupement As String
        Public CpteLie As String
        Public Lettrable As Boolean
        Public NvxNonLettres As Boolean
        Public Pointable As Boolean
        Public LibMvt As String
        Public AffQte1 As Boolean
        Public AffQte2 As Boolean
        Public ArretTva As Boolean
        Public AffectationObligatoire As Boolean
        Public AffectationPossible As Boolean
        Public DeviseObligatoire As Boolean
        Public RemarquePresente As Boolean
        Public Revision As Boolean
        Public Visa As Boolean
        Public Cycle As Decimal

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwCpt As DataRow)
            Me.New()
            With Me
                .NCompte = Left(rwCpt("CCpt"), 10)
                .LibCompte = Left(rwCpt("CLib"), 30)
                .Unite1 = Left(Convert.ToString(rwCpt("CU1")), 3)
                .LibUnite1 = Left(Convert.ToString(rwCpt("CU1")), 10)
                .Unite2 = Left(Convert.ToString(rwCpt("CU2")), 3)
                .LibUnite2 = Left(Convert.ToString(rwCpt("CU2")), 10)
                .TypeCompte = "ge"
                .SensSaisi = "in"
                .TvaAutorise = True
                .Lettrable = True
                .AffQte1 = True
                .AffQte2 = True
            End With
        End Sub

        Public Sub New(ByVal sCompte As String, ByVal sLibelle As String, ByVal sUnite1 As String, ByVal sUnite1Lib As String, ByVal sUnite2 As String, ByVal sUnite2Lib As String)
            Me.New()
            With Me
                .NCompte = sCompte
                .LibCompte = sLibelle
                .Unite1 = sUnite1
                .LibUnite1 = sUnite1Lib
                .Unite2 = sUnite2
                .LibUnite2 = sUnite2Lib
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, NCompte, LibCompte, CodeAlpha, Unite1, LibUnite1, Unite2, LibUnite2, NumAutorise, _
                        CodeLettrage, TypeCompte, Tiers, CpteDeb, CpteCred, CentrGdLivre, SensSaisi, CodeTva, TvaAutorise, _
                        CpteRegroupement, "", CpteLie, Lettrable, NvxNonLettres, Pointable, LibMvt, "", "", 0, AffQte1, AffQte2, ArretTva, _
                        AffectationObligatoire, AffectationPossible, DeviseObligatoire, RemarquePresente, Revision, Visa, Cycle}
        End Function
    End Class

    Friend Class TVA
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-2}{2,-30}{3,-10}{4:00.00}{5,-2}{6,-2}{7,-5}{8,1}{9,1}{10:000.00}{11,-2}{12,1}"
        Private Const FLAG As String = "TVA"
        Public CodeTva As String
        Public LibTva As String
        Public Cpt As String
        Public Taux As Decimal
        Public Type As String
        Public Positionnement As String
        Public CodeEmplacment As String
        Public TvaSurEncaissement As Boolean
        Public Tva0 As Boolean
        Public TxDeduction As Decimal
        Public Classe As String
        Public TvaSurEncaissementCompta As Boolean

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwTva As DataRow)
            Me.New()
            With Me
                .CodeTva = Left(rwTva("TTVA"), 2)
                .LibTva = Left(rwTva("Libellé"), 30)
                If rwTva.IsNull("TCpt") Then
                    .Cpt = ""
                Else
                    .Cpt = rwTva("TCpt")
                End If
                .Cpt = Left(.Cpt, 10)
                .Taux = CDec(rwTva("TTaux"))
                Select Case Convert.ToString(rwTva("TTVA"))
                    Case "I", "O", "S", "T"
                        .Type = "im"
                    Case Else
                        Select Case Convert.ToString(rwTva("TJournal"))
                            Case "V" : .Type = "ve"
                            Case "A" : .Type = "ac"
                        End Select
                End Select
                Select Case Convert.ToString(rwTva("TCtrlCl_DC"))
                    Case "C" : .Positionnement = "cr"
                    Case "D" : .Positionnement = "de"
                End Select
                Select Case Convert.ToString(rwTva("TTVA"))
                    Case "A1", "V1", "W1"
                        .TvaSurEncaissement = True
                End Select
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeTva, LibTva, Cpt, Taux, Type, Positionnement, CodeEmplacment, TvaSurEncaissement, Tva0, TxDeduction, Classe, TvaSurEncaissementCompta}
        End Function
    End Class

    Friend Class Journal
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-2}{2,-30}{3,-2}{4,-2}{5,-2}{6,-10}"
        Private Const FLAG As String = "JOU"
        Public CodeJournal As String
        Public LibJournal As String
        Public Type As String
        Public Classe As String = "mi"
        Public TypeExtourne As String
        Public CpteCtr As String

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeJournal, LibJournal, Type, Classe, TypeExtourne, CpteCtr}
        End Function
    End Class

    Friend Class Ecriture
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1:00}{2,8}{3,8}{4,-30}{5,-8}{6,-7}{7,-7}{8,-3}{9,-11}{10,1}{11,1}{12,8}" & _
                                        "{13,8}{14,-11}{15,1}{16,-3}{17,-2}{18,1}{19,-10}{20,1}{21,-11}{22,30}{23,3}{24,3}"
        Private Const FLAG As String = "ECR"
        Public CodeJournal As String
        Public DatePiece As Date
        Public NumPiece As String
        Public NumPieceImport As String
        Public LibEcr As String
        Public CodeSite As String
        Public CodeUtil As String
        Public CodeEmetteur As Integer = 1
        Public CodeEcriture As String
        Public NonModifiable As Boolean
        Public DateCreation As Date
        Public DateModif As Date
        Public ADetruire As Boolean
        Public Devise As String
        Public Type As String
        Public CptCtr As String
        Public NumModif As Integer

        Public Mouvements As New ArrayList

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwPiece As DataRow)
            Me.New()
            With Me
                If rwPiece.IsNull("Journal") Then
                    .CodeJournal = "09"
                Else
                    .CodeJournal = Convert.ToString(rwPiece("Journal"))
                End If
                .DatePiece = rwPiece("PDate")
                .NumPiece = Left(rwPiece("PPiece").ToString, 5)
                If Not rwPiece.IsNull("Libelle") Then .LibEcr = rwPiece("Libelle")
                .CodeSite = ""
                .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                .NonModifiable = False
                .DateCreation = rwPiece("PDate")
                .DateModif = rwPiece("PDate")
                If Not rwPiece.IsNull("PPieceImport") AndAlso rwPiece("PPieceImport") <> "" Then .NumPieceImport = rwPiece("PPieceImport")
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            If Me.NumPieceImport <> "" Then
                Return New Object() {FLAG, CodeJournal, DatePiece, NumPieceImport, LibEcr, "", CodeSite, CodeUtil, CodeEmetteur, _
                      CodeEcriture, "", NonModifiable, DateCreation, DateModif, 0, ADetruire, Devise, Type, 0, _
                      CptCtr, 0, NumModif, "", "", ""}
            Else
                Return New Object() {FLAG, CodeJournal, DatePiece, NumPiece, LibEcr, "", CodeSite, CodeUtil, CodeEmetteur, _
                            CodeEcriture, "", NonModifiable, DateCreation, DateModif, 0, ADetruire, Devise, Type, 0, _
                            CptCtr, 0, NumModif, "", "", ""}
            End If
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Mouvements
        End Function
    End Class

    Friend Class Mouvement
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-10}{2,30}{3,13:#0.00}{4,13:#0.00}{5,11:#0.00}{6,11:#0.00}{7,-8}{8,2}{9,2}" & _
                                        "{10,1}{11,-3}{12,8}{13,4}{14,1}{15,8}{16,2}{17,2}{18,3}{19,5}{20,8}{21,8}"
        Private Const FLAG As String = "MVT"
        Public Compte As String
        Public LibMvt As String
        Public MontantD As Decimal
        Public MontantC As Decimal
        Public Qte1 As Decimal
        Public Qte2 As Decimal
        Public Numero As String
        Public CodeTva As String
        Public CodeTvaCompte As String
        Public FlagLettrage As Integer
        Public CodeLettrage As String
        Public DatePointage As Date
        Public NbAct As Integer
        Public HasEcheances As Boolean
        Public DateDeclaration As Date
        Public CodeTva2 As String
        Public CodeTva3 As String
        Public DateValeur As Date
        Public Activites As New ArrayList
        Public Echeances As New ArrayList

        Public Sub New()

        End Sub

        Public Sub New(ByVal rwLigne As DataRow, ByVal rwMvt As DataRow)
            Me.New()
            With Me
                .Compte = Left(rwMvt("MCpt"), 10)
                .LibMvt = Left(rwLigne("LLib"), 30)
                .MontantD = rwMvt("MMtDeb")
                .MontantC = rwMvt("MMtCre")
                .Qte1 = rwMvt("MQte1")
                .Qte2 = rwMvt("MQte2")
                .FlagLettrage = 0

                Select Case CInt(rwMvt("MOrdre"))
                    Case 2
                        .CodeTvaCompte = Left(Convert.ToString(rwLigne.Item("LTva")), 2)
                    Case Else
                        .CodeTva = Left(Convert.ToString(rwLigne.Item("LTva")), 2)
                End Select

                'Association d'activité
                If Convert.ToString(rwMvt.Item("MActi")) <> "0000" Then
                    .NbAct = 1
                    .Activites.Add(New MvtActivite(rwMvt("MActi")))
                End If
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, Compte, LibMvt, MontantD, MontantC, Qte1, Qte2, Numero, CodeTva, CodeTvaCompte, FlagLettrage, _
                        CodeLettrage, DatePointage, NbAct, HasEcheances, DateDeclaration, CodeTva2, CodeTva3, "", "", "", DateValeur}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Dim a As New ArrayList
            With a
                .AddRange(Activites)
                .AddRange(Echeances)
            End With
            Return a
        End Function
    End Class

    Friend Class MvtActivite
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,6}{2,2}{3,-40}{4:0000.00000}{5,1}"
        Private Const FLAG As String = "ANAMVT"
        Public CodeAct As String
        Public CodeDecoupe As String
        Public Libelle As String
        Public Pourcentage As Decimal
        Public Prorata As Boolean = False

        Public Sub New()

        End Sub

        Public Sub New(ByVal CodeAct As String, Optional ByVal Pourcentage As Decimal = 100D)
            Me.New()
            With Me
                .CodeAct = Left(CodeAct, 6)
                .Pourcentage = Pourcentage
            End With
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeAct, CodeDecoupe, Libelle, Pourcentage, Prorata}
        End Function
    End Class

    Friend Class MvtEcheance
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1:0000000000.00}{2:0000.00000}{3,8}"
        Private Const FLAG As String = "ECHMVT"
        Public MontantTTC As Decimal
        Public TauxTTC As Decimal
        Public DateEcheance As Date

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, MontantTTC, TauxTTC, DateEcheance}
        End Function
    End Class
#End Region

End Namespace