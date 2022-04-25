Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace Agrigest
    Public Class ExportAgrigestEDI
        Inherits ExportAgrigest

        Private Const COMPTE_PERTE As String = "65800000"
        Private Const COMPTE_PROFIT As String = "75800000"
        Private Const COMPTE_ESCOMPTE As String = "66500000"
        Private Const COMPTE_ESCOMPTE_OBTENUE As String = "76500000"

#Region "Propriétés"

#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

#Region "Méthodes d'export"
        Protected Overrides Function ExporterFactures() As Boolean
            ' FACTURE DE VENTE
            If VFacture = True Then
                Dim CodeJournal As String = TrouverCodeJournal("ve")
                ReportProgress(0, "Exportation des Factures de vente")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebVFacture, DateFinVFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("VFacture").Select(strFiltre, "nFacture")
                Dim i As Integer = 0
                Dim dtExport As Date = Now
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        'Chercher le numéro de dossier de l'exercice correspondant à la facture
                        Dim keepDossier As String = TrouverDossier(rwFacture.Item("DateFacture"))
                        If keepDossier Is Nothing Or keepDossier = "" Then
                            Throw New WarningExport(String.Format("Pas de dossier disponible pour la facture du {0:dd/MM/yy}", rwFacture.Item("DateFacture")))
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
                                If dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTva.Replace("'", "''") & "'", "").Length = 0 Then
                                    Throw New WarningExport(String.Format("Le code TVA '{0}' n'existe pas en comptabilité.", CodeTva))
                                End If
                            End If
                        Next

                        'S'assurer de la présence du compte 488
                        Ajout_Compte(keepDossier, "48800000", "COMPTE DE REPARTITION")
                        Ajout_Activite(keepDossier, "0000", "ACTIVITE GENERALE")
                        Ajout_PlanComptable(keepDossier, "48800000", "0000")

                        'Déterminer le n° de la pièce à utiliser pour la facture
                        Dim NumPiece As Integer
                        If Not IsNumeric(BlocnPieceDebutVFacture) Then BlocnPieceDebutVFacture = 50000
                        If Not IsNumeric(BlocnPieceFinVFacture) Then BlocnPieceFinVFacture = 80000

                        NumPiece = CreerNumeroPiece(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))
                        'NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))

                        Dim libPiece As String = Left(String.Format("Vente {0} du {1:dd/MM/yy}: {2}", rwFacture("nFacture"), rwFacture("DateFacture"), rwEntreprise("Nom")), 50)
                        'Création de la pièce
                        If Ajout_Piece(keepDossier, NumPiece, rwFacture.Item("DateFacture"), libPiece, CodeJournal) Then
                            rwFacture.Item("ExportCompta") = True
                            rwFacture.Item("DateExportCompta") = dtExport
                        End If

                        'Trouver les infos du client de la facture

                        Dim CompteClient As String = rwEntreprise("NCompteC")
                        Dim ActiviteClient As String = rwEntreprise("NActiviteC")

                        'S'assurer de l'exisence du compte  client dans AGRIGEST
                        Ajout_Compte(keepDossier, CompteClient, "CLIENT " & NomClient)
                        Ajout_Activite(keepDossier, ActiviteClient, "ACTIVITE " & ActiviteClient)
                        Ajout_PlanComptable(keepDossier, CompteClient, ActiviteClient)

                        Dim RecapTxTVA As New RecapTVA
                        Dim Ligne As Integer = 0
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis=" & rwFacture.Item("nDevis") & " AND CodeProduit IS NOT NULL AND Codeproduit<>'' AND MontantLigneTTC IS NOT NULL", "NCompte,TTVA,nLigne,CodeProduit")
                        Dim RecapComptesPdt As New RecapComptesProduit

                        Dim nComptePrec As String = String.Empty
                        Dim CodeTVAPrec As String = String.Empty
                        Dim TVASansComptePrec As Boolean = False
                        Dim NomClientPrec As String = String.Empty
                        Dim nActivitePrec As String = String.Empty
                        Dim premierPassage As Boolean = True
                        Dim cumulMontantHT As Decimal = 0
                        Dim cumulQte1 As Decimal = 0
                        Dim cumulQte2 As Decimal = 0
                        Dim sauvegarderMvtsPdtsPrec As Boolean = False

                        'Variables de vérification écart
                        Dim cumulDebit As Decimal = 0
                        Dim cumulCredit As Decimal = 0

                        For Each ligneDetail As DataRow In lignesDetailFacture
                            ' Génération des comptes TVA si nécessaire
                            Dim CodeTVA As String = Convert.ToString(ligneDetail("TTVA"))
                            Dim TauxTva As Decimal = 0
                            Dim TVASansCompte As Boolean = False

                            If CodeTVA <> "" Then
                                If TVASurEncaissement Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                Dim ligneTVA As DataRow = SelectSingleRow(dsAgrigest.Tables("TVA"), "TTVA='{0}'", CodeTVA.Replace("'", "''"))
                                If Not ligneTVA Is Nothing Then
                                    TVASansCompte = (Convert.ToString(ligneTVA("TCpt")).Length = 0)
                                    If Not TVASansCompte Then
                                        Ajout_Compte(keepDossier, ligneTVA("TCpt"), ligneTVA("Libellé"))
                                        Ajout_PlanComptable(keepDossier, ligneTVA("TCpt"), "0000")
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

                            Ajout_Compte(keepDossier, ligneDetail.Item("NCompte"), "PRODUIT " & NomProduit, Unite1, Unite2)
                            Ajout_Activite(keepDossier, ligneDetail.Item("NActivite"), "ACTIVITE " & ligneDetail.Item("NActivite"))
                            Ajout_PlanComptable(keepDossier, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"))

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
                                        If TVASurEncaissement Then cTva = CodeTVAEncaissementCorrespondant(cTva)

                                        RecapTxTVA.AddMontant(cTva, 5.5D, MontantHT55, MontantTTC55)

                                        '25% à 19.6%
                                        Dim MontantTTC196 As Decimal = MontantTTC - MontantTTC55
                                        Dim MontantHT196 As Decimal = MontantHT - MontantHT55
                                        cTva = "19.6"
                                        If TVASurEncaissement Then cTva = CodeTVAEncaissementCorrespondant(cTva)
                                        RecapTxTVA.AddMontant(cTva, 19.6D, MontantHT196, MontantTTC196)
                                    Case Else
                                        RecapTxTVA.AddMontant(CodeTVA, TauxTva, MontantHT, MontantTTC)
                                End Select
                            End If

                            'Si le paramètre compta "Regroupement des comptes de produits lors de l'export
                            'des factures de vente" est coché
                            If (Me.RgpCptsPdtsExportVtes) Then
                                If (Convert.ToString(ligneDetail.Item("NCompte")) Like "70*") Then
                                    'Cumul dans le recap compte
                                    RecapComptesPdt.SetCompte(Convert.ToString(ligneDetail.Item("NCompte")))

                                    'Si c'est le premier passage, le n° de compte précédent est initialisé
                                    'avec le n° de compte en cours
                                    If (premierPassage) Then
                                        nComptePrec = ligneDetail.Item("NCompte")
                                        CodeTVAPrec = CodeTVA
                                        premierPassage = False
                                    End If

                                    'Si le n° de compte précédent est le même que le n° de compte en cours
                                    'on cumule le montant HT et les Quantités
                                    'et on ne crée ni ligne ni mouvements
                                    If (ligneDetail.Item("NCompte") = nComptePrec And CodeTVA = CodeTVAPrec) Then
                                        cumulMontantHT = cumulMontantHT + MontantHT
                                        cumulQte1 = cumulQte1 + Qte1
                                        cumulQte2 = cumulQte2 + Qte2
                                    Else
                                        'On crée la ligne et les mouvements avec les informations cumulées
                                        Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, TVASansComptePrec, CodeTVAPrec, CodeJournal, "", NomClientPrec, "")
                                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", cumulMontantHT, 0, "D", 0, 0, nComptePrec, nActivitePrec)
                                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, nComptePrec, nActivitePrec, 0, cumulMontantHT, "C", cumulQte1, cumulQte2, "48800000", "0000")

                                        Ligne += 1

                                        'Gestion des variables de contrôle d'ecart
                                        cumulDebit = cumulDebit + cumulMontantHT

                                        'Les cumuls des montants HT et des quantités sont réinitialisés
                                        'avec les infos de la ligne de détail en cours
                                        cumulMontantHT = MontantHT
                                        cumulQte1 = Qte1
                                        cumulQte2 = Qte2
                                    End If

                                    'Sauvegarde des informations de la ligne de détail en cours
                                    nComptePrec = ligneDetail.Item("NCompte")
                                    TVASansComptePrec = TVASansCompte
                                    CodeTVAPrec = CodeTVA
                                    NomClientPrec = NomClient
                                    nActivitePrec = ligneDetail.Item("NActivite")

                                    'Indicateur permettant de sauvegarder la dernière ligne de détail concernant 
                                    'un compte de produit
                                    sauvegarderMvtsPdtsPrec = True
                                Else
                                    'On crée la ligne et les mouvements avec les informations cumulées si nécessaire
                                    If (sauvegarderMvtsPdtsPrec) Then
                                        'Créer la ligne et les mouvements correspondant à la ligne de facture
                                        Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, TVASansComptePrec, CodeTVAPrec, CodeJournal, "", NomClientPrec, "")
                                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", cumulMontantHT, 0, "D", 0, 0, nComptePrec, nActivitePrec)
                                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, nComptePrec, nActivitePrec, 0, cumulMontantHT, "C", cumulQte1, cumulQte2, "48800000", "0000")

                                        Ligne += 1

                                        'Gestion des variables de contrôle d'ecart
                                        cumulDebit = cumulDebit + cumulMontantHT

                                        sauvegarderMvtsPdtsPrec = False
                                    End If

                                    'Créer la ligne et les mouvements correspondant à la ligne de facture
                                    Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, TVASansCompte, CodeTVA, CodeJournal, "", NomClient, NomProduit)
                                    Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", MontantHT, 0, "D", 0, 0, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"))
                                    Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"), 0, MontantHT, "C", Qte1, Qte2, "48800000", "0000")

                                    Ligne += 1

                                    'Gestion des variables de contrôle d'ecart
                                    cumulDebit = cumulDebit + MontantHT
                                End If
                            Else
                                'Créer la ligne et les mouvements correspondant à la ligne de facture
                                Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, TVASansCompte, CodeTVA, CodeJournal, "", NomClient, NomProduit)
                                Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", MontantHT, 0, "D", 0, 0, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"))
                                Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"), 0, MontantHT, "C", Qte1, Qte2, "48800000", "0000")

                                Ligne += 1

                                'Gestion des variables de contrôle d'ecart
                                cumulDebit = cumulDebit + MontantHT
                            End If
                        Next

                        'Si le paramètre compta "Regroupement des comptes de produits lors de l'export
                        'des factures de vente" est coché
                        If (Me.RgpCptsPdtsExportVtes) Then
                            'On crée la ligne et les mouvements avec les informations cumulées si nécessaire
                            If (sauvegarderMvtsPdtsPrec) Then
                                Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, TVASansComptePrec, CodeTVAPrec, CodeJournal, "", NomClientPrec, "")
                                Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", cumulMontantHT, 0, "D", 0, 0, nComptePrec, nActivitePrec)
                                Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, nComptePrec, nActivitePrec, 0, cumulMontantHT, "C", cumulQte1, cumulQte2, "48800000", "0000")

                                Ligne += 1

                                'Gestion des variables de contrôle d'ecart
                                cumulDebit = cumulDebit + cumulMontantHT

                                sauvegarderMvtsPdtsPrec = False
                            End If
                        End If

                        ' On génére une ligne par code TVA
                        For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            If codeTVA.Length > 0 Then
                                If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                    'Créer la ligne de TVA :
                                    ' MONTANT TVA AU CREDIT SUR COMPTE TVA

                                    'TV : 20/12/2011
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

                                    Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, "", CodeJournal, codeTVA, NomClient, codeTVA)
                                    Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", montantTTCTaux, 0, "D", 0, 0, "48800000", "0000")
                                    Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 2, RecapTxTVA.GetElementRecap(codeTVA).CompteTVA, "0000", 0, montantTVATaux, "C", 0, 0, "", "0")
                                    Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, "48800000", "0000", 0, montantHTTaux, "C", 0, 0, "48800000", "0000")

                                    'Gestion des variables de contrôle d'ecart
                                    cumulDebit = cumulDebit + montantTTCTaux
                                    cumulCredit = cumulCredit + montantHTTaux

                                    'OLD VERSION
                                    'Dim MontantTTC As Decimal = Decimal.Round(RecapTxTVA.MontantTTCTaux(codeTVA), 2)

                                    'Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, "", CodeJournal, codeTVA, NomClient, codeTVA)
                                    'Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", MontantTTC, 0, "D", 0, 0, "48800000", "0000")
                                    'Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 2, RecapTxTVA.GetElementRecap(codeTVA).CompteTVA, "0000", 0, Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2), "C", 0, 0, "", "0")
                                    'Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, "48800000", "0000", 0, Decimal.Round(RecapTxTVA.MontantHTTaux(codeTVA), 2), "C", 0, 0, "48800000", "0000")

                                    Ligne += 1
                                End If
                            End If
                        Next

                        ' On solde le compte 488 par le compte client
                        Dim montantTTCClient As Decimal = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)

                        Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, "", CodeJournal, "", IIf(CDec(rwFacture.Item("MontantTTC")) > 0, "FACTURE N°", "AVOIR N°"), NumPiece)
                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, CompteClient, ActiviteClient, montantTTCClient, 0, "D", 0, 0, "48800000", "0000")
                        Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, "48800000", "0000", 0, montantTTCClient, "C", 0, 0, CompteClient, ActiviteClient)

                        'Gestion des variables de contrôle d'ecart
                        cumulCredit = cumulCredit + montantTTCClient

                        'Gestion des écarts
                        Dim ecart As Decimal = cumulDebit - cumulCredit

                        If (ecart <> 0) Then
                            Me.GererEcartExportFacture(ecart, CBool(rwFacture("FacturationTTC")), keepDossier, NumPiece, String.Format("{0:dd/MM/yy}", rwFacture.Item("DateFacture")))
                        End If
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

                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateRemise>='{0}' and DateRemise<='{1}')", DateDebVReglement, DateFinVReglement)
                Dim rwRemises() As DataRow = dsAgrifact.Tables("Remise").Select(strFiltre, "nRemise")
                Dim i As Integer = 0
                Dim dtExport As Date = Now

                For Each rwRemise As DataRow In rwRemises
                    Try
                        'Trouver le dossier de l'exercice
                        Dim keepDossier As String = TrouverDossier(rwRemise.Item("DateRemise"))

                        If keepDossier Is Nothing Or keepDossier = "" Then
                            Throw New WarningExport(String.Format("Pas de dossier disponible pour la remise du {0:dd/MM/yy}", rwRemise.Item("DateRemise")))
                        End If

                        'Verifs avant création de la pièce
                        If IsDBNull(rwRemise.Item("nBanque")) Then
                            Throw New WarningExport(String.Format("Pas de banque renseignée pour la remise du {0:dd/MM/yy}", rwRemise.Item("DateRemise")))
                        End If

                        'Vérif que les infos comptables sont renseignées pour la banque de la remise
                        Dim rwBanque As DataRow = dsAgrifact.Tables("Banque").Select("nBanque='" & rwRemise.Item("nBanque") & "'", "")(0)
                        Dim NomBanque As String = rwBanque.Item("Libelle").toUpper

                        If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If

                        'Vérif que les infos comptables du tiers payeur sont renseignées
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

                        'Création si nécessaire du compte 48800000
                        Ajout_Compte(keepDossier, "48800000", "COMPTE DE REPARTITION")
                        Ajout_Activite(keepDossier, "0000", "ACTIVITE GENERALE")
                        Ajout_PlanComptable(keepDossier, "48800000", "0000")

                        'Création si nécessaire du compte banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        Dim ActiviteBanque As String = rwBanque.Item("NActivite")

                        Ajout_Compte(keepDossier, CompteBanque, NomBanque)
                        Ajout_Activite(keepDossier, ActiviteBanque, "ACTIVITE " & ActiviteBanque)
                        Ajout_PlanComptable(keepDossier, CompteBanque, ActiviteBanque)

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

                        'En cas de collision, on incrémente
                        While dsAgrigest.Tables("Pieces").Select(String.Format("PDossier='{0}' And PPiece={1}", keepDossier, NumPiece)).Length > 0
                            NumPiece += 1
                        End While

                        Dim dtRemise As Date = CDate(rwRemise.Item("DateRemise"))
                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Remise {2} n°{0} du {1:dd/MM/yy}", rwRemise("nRemiseBanque"), dtRemise, rwRemise("TypeRemise")), 50)

                        'Créer la piece
                        If Ajout_Piece(keepDossier, NumPiece, dtRemise, libPiece, CodeJournal) Then
                            rwRemise.Item("ExportCompta") = True
                            rwRemise.Item("DateExportCompta") = dtExport
                        End If

                        Dim Ligne As Integer = 0
                        Dim lignesDetailRemise() As DataRow = dsAgrifact.Tables("Remise_Detail").Select("nRemise='" & rwRemise.Item("nRemise") & "'", "nDetailRemise")

                        'POUR CHAQUE REGLEMENT DE LA REMISE
                        For Each ligneDetailRemise As DataRow In lignesDetailRemise
                            Dim rwDetailReglements() As DataRow = dsAgrifact.Tables("Reglement_detail").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")
                            Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)
                            Dim AvanceClient As Decimal = CDec(ReplaceDbNull(rwReglement("Montant"), 0))

                            AvanceClient += CDec(ReplaceDbNull(rwReglement("Perte"), 0))
                            AvanceClient -= CDec(ReplaceDbNull(rwReglement("Profit"), 0))
                            AvanceClient += CDec(ReplaceDbNull(rwReglement("MontantEscompte"), 0))

                            Dim GlobalRecapTxTVA As New RecapTVA
                            Dim RecapTVAEscompte As New RecapTVA
                            Dim montantTTCFacture As Decimal = 0

                            'POUR CHAQUE FACTURE REGLEE PAR LE REGLEMENT
                            For Each rwReglementDetail As DataRow In rwDetailReglements
                                AvanceClient -= CDec(ReplaceDbNull(rwReglementDetail("Montant"), 0))

                                If Not IsDBNull(rwReglementDetail.Item("nFacture")) Then
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

                                    'Créer le compte CLIENT
                                    Ajout_Compte(keepDossier, CompteClient, "CLIENT " & NomClient)
                                    Ajout_Activite(keepDossier, ActiviteClient, "ACTIVITE " & ActiviteClient)
                                    Ajout_PlanComptable(keepDossier, CompteClient, ActiviteClient)

                                    'Créer les lignes pour le réglement
                                    Dim libPaiement As String = NumFacture & " " & rwReglement.Item("nMode")
                                    Dim LibPaiement2 As String = NomClient
                                    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, libPaiement, LibPaiement2, "48800000", "0000", CompteClient, ActiviteClient, Decimal.Round(CDec(rwReglementDetail.Item("Montant")), 2), CodeJournal)
                                    Ligne += 1

                                    ' CALCUL DES SOMMES REGLEES ET DUES POUR LA FACTURE
                                    Dim SommeDue As Decimal = 0
                                    Dim SommePayee As Decimal = 0
                                    Dim SommeDejaPayee As Decimal = 0
                                    'Dim MontantEscompte As Decimal = 0
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
                                    'SommeDue = CDec(rwFacture.Item("MontantTTC")) - MontantEscompte

                                    SommeDue = CDec(rwFacture.Item("MontantTTC"))
                                    montantTTCFacture = CDec(rwFacture.Item("MontantTTC"))

                                    'rwEscompte = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetail.Item("nReglement") & "'", "nReglement")(0)
                                    'Cherche si le réglement à une escompte

                                    'If Not IsDBNull(rwReglement.Item("TxEscompte")) And Not passEscompte Then
                                    '    rwEscompte = rwReglement
                                    '    If rwReglement.Item("TxEscompte") <> 0 Then
                                    '        SommeDue -= Decimal.Round(CDec(rwReglement.Item("MontantEscompte")), 2)
                                    '    End If
                                    '    passEscompte = True
                                    'End If


                                    '15/02/2008 - Jérémie : Modif compte client par 488
                                    '' GESTION DES PERTES ET PROFIT
                                    If Not IsDBNull(rwReglementDetail.Item("Perte")) Then
                                        If rwReglementDetail.Item("Perte") <> 0 Then
                                            Dim perte As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Perte")), 2)

                                            Ajout_Compte(keepDossier, COMPTE_PERTE, "ARRONDI DE PAIEMENT PERTE")
                                            Ajout_PlanComptable(keepDossier, COMPTE_PERTE, "0000")
                                            Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "Arrondi de paiement", "Perte " & NumFacture, COMPTE_PERTE, "0000", "48800000", "0000", perte, CodeJournal)

                                            Ligne += 1

                                            SommePayee += perte
                                        End If
                                    End If
                                    If Not IsDBNull(rwReglementDetail.Item("Profit")) Then
                                        If rwReglementDetail.Item("Profit") <> 0 Then
                                            Dim profit As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Profit")), 2)

                                            Ajout_Compte(keepDossier, COMPTE_PROFIT, "ARRONDI DE PAIEMENT PROFIT")
                                            Ajout_PlanComptable(keepDossier, COMPTE_PROFIT, "0000")
                                            Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "Arrondi de paiement", "Profit " & NumFacture, "48800000", "0000", COMPTE_PROFIT, "0000", profit, CodeJournal)

                                            Ligne += 1

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
                                    Dim rwFacturesDetail() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & nDevis & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")

                                    For Each rwFactureDetail As DataRow In rwFacturesDetail
                                        Dim CodeTVA As String = String.Empty
                                        Dim JournalTVA As String = String.Empty
                                        Dim MontantTVA As String = String.Empty
                                        Dim TauxTva As Decimal = 0

                                        If Convert.ToString(rwFactureDetail("TTVA")).Length > 0 Then
                                            CodeTVA = Convert.ToString(rwFactureDetail("TTVA"))

                                            Dim rwTauxTva() As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'")

                                            If rwTauxTva.Length > 0 Then
                                                Dim rwTVA As DataRow = rwTauxTva(0)

                                                If Convert.ToString(rwTVA("TCpt")).Length > 0 Then
                                                    'CREATION EVENTUELLE DU COMPTE TVA
                                                    Ajout_Compte(keepDossier, rwTVA("TCpt"), rwTVA("Libellé"))
                                                    Ajout_PlanComptable(keepDossier, rwTVA("TCpt"), "0000")
                                                    JournalTVA = rwTVA("TJournal")
                                                    MontantTVA = rwTVA("TCtrlCl_DC")
                                                End If

                                                If Not IsDBNull(rwTVA("TTaux")) Then
                                                    TauxTva = CDec(rwTVA.Item("TTaux"))
                                                End If
                                            End If
                                        End If

                                        'stocker pour chacun des codes TVA présents le montant d'HT qui va être payé par la facture
                                        'TODO : ON NE GERE COMPLETEMENT PAS LA TVA RPCH
                                        If Not IsDBNull(rwFactureDetail("MontantLigneHt")) Then
                                            RecapTxTVA.AddMontant(CodeTVA, TauxTva, Decimal.Round((rwFactureDetail("MontantLigneHt") * ratioPaye), 2), 0)
                                            RecapTVAEscompte.AddMontant(CodeTVA, TauxTva, Decimal.Round(rwFactureDetail("MontantLigneHT"), 2), Decimal.Round(rwFactureDetail("MontantLigneTTC"), 2))
                                        End If
                                    Next

                                    'If TVASurEncaissement OrElse MontantEscompte <> 0 Then
                                    If (TVASurEncaissement) Then
                                        'Si le réglement solde la facture alors on retranche le déjà payé
                                        If SoldeFacture Then
                                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                                Dim rwDejaPayeeII() As DataRow = dsAgrifact.Tables("factureMontantExport").Select("nDevis='" & nDevis & "' And TTVA='" & codeTVA.Replace("'", "''") & "'", "nDevis")
                                                Dim rwDejapayee As DataRow

                                                For Each rwDejapayee In rwDejaPayeeII
                                                    With rwDejapayee
                                                        elRecap.MontantHT -= .Item("MontantHT")
                                                        elRecap.MontantTVA -= .Item("MontantTVA")
                                                        elRecap.MontantTTC -= .Item("MontantTTC")
                                                    End With
                                                Next
                                            Next
                                        End If

                                        ''Calculer la répartition de l'escompte par code TVA
                                        'If MontantEscompte <> 0 Then
                                        '    For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                        '        Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                        '        Dim partEscompte As Decimal = MontantEscompte * elRecap.MontantTTC / SommePayee
                                        '        RecapTVAEscompte.AddMontant(codeTVA, RecapTxTVA.TxTVA(codeTVA), 0, partEscompte)
                                        '    Next
                                        'End If

                                        If TVASurEncaissement Then
                                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                                                Dim rws() As DataRow = dsAgrifact.Tables("FactureMontantExport").Select(String.Format("nDetailReglement={0} AND TTVA='{1}'", rwReglementDetail.Item("nDetailReglement"), codeTVA.Replace("'", "''")))

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

                                                GlobalRecapTxTVA.AddMontant(codeTVA, elRecap.TxTva, elRecap.MontantHT, elRecap.MontantTTC, elRecap.MontantTVA)
                                            Next
                                        End If

                                        'If MontantEscompte <> 0 Then
                                        '    Ajout_Compte(keepDossier, COMPTE_ESCOMPTE, "ESCOMPTE ACCORDEE SUR VENTE")
                                        '    Ajout_PlanComptable(keepDossier, COMPTE_ESCOMPTE, "0000")

                                        '    'TODO REMONTER CA A CHAQUE FACTURE
                                        '    ' On solde le compte client du montant TTC de l'escompte
                                        '    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, NomClient, "Escompte " & NumFacture, "48800000", "0000", CompteClient, ActiviteClient, MontantEscompte, CodeJournal)
                                        '    Ligne += 1

                                        '    ' On solde les compte TVA
                                        '    Dim MontantEscompteTVA As Decimal = 0
                                        '    For Each txTVA As String In RecapTVAEscompte.GetLstTx()
                                        '        If RecapTVAEscompte.MontantTVATaux(txTVA) <> 0 Then
                                        '            MontantEscompteTVA += RecapTVAEscompte.MontantTVATaux(txTVA)
                                        '            If dsAgrigest.Tables("TVA").Select("TTVA='" & txTVA.Replace("'", "''") & "'", "").Length > 0 Then
                                        '                Dim rwTva As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & txTVA.Replace("'", "''") & "'", "")(0)
                                        '                If Not IsDBNull(rwTva.Item("TCpt")) Then
                                        '                    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "REGUL. TVA ESCOMPTE", txTVA & " " & NumFacture, "48800000", "0000", rwTva.Item("TCpt"), "0000", RecapTVAEscompte.MontantTVATaux(txTVA), CodeJournal)
                                        '                    Ligne += 1
                                        '                End If
                                        '            End If
                                        '        End If
                                        '    Next

                                        '    Dim MontantEscompteHT As Decimal = MontantEscompte - MontantEscompteTVA
                                        '    ' on passe le montant HT de l'escompte en escompte
                                        '    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "Escompte Accordée", NumFacture, "48800000", "0000", COMPTE_ESCOMPTE, "0000", MontantEscompteHT, CodeJournal)
                                        '    Ligne += 1
                                        'End If
                                    End If
                                End If
                            Next 'NEXT FACTURE

                            'Traitement de l'escompte
                            'If Not (TVASurEncaissement) Then
                            If Not (rwReglement.IsNull("MontantEscompte")) Then
                                Dim montantEscompteTTC As Decimal = CDec(rwReglement.Item("MontantEscompte"))
                                Dim totalTVASurEscompte As Decimal = 0

                                'ajout du compte Escompte accordé si inexistant
                                Ajout_Compte(keepDossier, COMPTE_ESCOMPTE, "ESCOMPTE ACCORDEE SUR VENTE")
                                Ajout_PlanComptable(keepDossier, COMPTE_ESCOMPTE, "0000")

                                'Ajout des lignes concernant les différents taux de TVA 
                                For Each codeTVA As String In RecapTVAEscompte.GetLstTx()
                                    'Calcul du pourcentage du montant TTC de la facture
                                    Dim pourcentageDuTTC As Decimal = 0

                                    If RecapTVAEscompte.MontantTTCTaux(codeTVA) <> 0 Then
                                        pourcentageDuTTC = RecapTVAEscompte.MontantTTCTaux(codeTVA) / montantTTCFacture
                                    End If

                                    'Calcul de la part de l'escompte TTC
                                    Dim partEscompteTTC As Decimal = 0

                                    partEscompteTTC = montantEscompteTTC * pourcentageDuTTC

                                    'Calcul de la part de l'escompte HT
                                    Dim partEscompteHT As Decimal = 0
                                    Dim tauxTVA As Decimal = 0
                                    Dim compteTVA As String = String.Empty

                                    If dsAgrigest.Tables("TVA").Select("TTVA='" & codeTVA.Replace("'", "''") & "'", "").Length > 0 Then
                                        Dim rwTva As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & codeTVA.Replace("'", "''") & "'", "")(0)

                                        If Not (rwTva.IsNull("TTaux")) Then
                                            tauxTVA = CDec(rwTva.Item("TTaux"))
                                        End If

                                        If Not IsDBNull(rwTva.Item("TCpt")) Then
                                            compteTVA = rwTva.Item("TCpt")
                                        End If
                                    End If

                                    partEscompteHT = partEscompteTTC / (1 + (tauxTVA / 100))

                                    'Calcul de la part de l'escompte TVA
                                    Dim partEscompteTVA As Decimal = 0

                                    partEscompteTVA = Math.Round(partEscompteHT * (tauxTVA / 100), 2)

                                    totalTVASurEscompte = totalTVASurEscompte + partEscompteTVA

                                    If (partEscompteTVA <> 0) Then
                                        'Création de la ligne et des mouvements
                                        If (compteTVA <> String.Empty) Then
                                            Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "REGUL. TVA ESCOMPTE", codeTVA, compteTVA, "0000", "48800000", "0000", partEscompteTVA, CodeJournal)
                                            Ligne += 1
                                        End If
                                    End If
                                Next

                                'Création de la ligne d'escompte HT
                                Dim montantEscompteHT As Decimal = montantEscompteTTC - totalTVASurEscompte

                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "Escompte Accordée", "", COMPTE_ESCOMPTE, "0000", "48800000", "0000", montantEscompteHT, CodeJournal)
                                Ligne += 1
                            End If
                            'End If

                            If TVASurEncaissement = True Then
                                For Each codeTVA As String In GlobalRecapTxTVA.GetLstTx()
                                    Dim MontantHT As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantHTTaux(codeTVA), 2)
                                    Dim MontantTVA As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantTVATaux(codeTVA), 2)
                                    Dim MontantTTC As Decimal = Decimal.Round(MontantHT + MontantTVA, 2)

                                    'Dim txEscompte As Decimal = 0
                                    'If Not IsDBNull(rwReglement.Item("TxEscompte")) Then
                                    '    txEscompte = rwReglement.Item("TxEscompte")
                                    'End If

                                    If dsAgrigest.Tables("TVA").Select("TTVA='" & codeTVA.Replace("'", "''") & "'", "").Length > 0 Then
                                        Dim rwTva As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & codeTVA.Replace("'", "''") & "'", "")(0)

                                        If Not IsDBNull(rwTva.Item("TCpt")) Then
                                            Ajout_Ligne(keepDossier, NumPiece, dtRemise, Ligne, True, "", CodeJournal, codeTVA, "REGUL TVA", "")
                                            Ajout_Mouvement(keepDossier, NumPiece, dtRemise, Ligne, 1, "48800000", "0000", MontantTTC, 0, "D", 0, 0, "48800000", "0000")
                                            Ajout_Mouvement(keepDossier, NumPiece, dtRemise, Ligne, 2, rwTva.Item("TCpt"), "0000", 0, MontantTVA, "C", 0, 0, "", "0")
                                            Ajout_Mouvement(keepDossier, NumPiece, dtRemise, Ligne, 3, "48800000", "0000", 0, MontantHT, "C", 0, 0, "48800000", "0000")
                                            Ligne += 1
                                        End If
                                    End If

                                    Dim CodeTVAEnc As String = CodeTVAEncaissementCorrespondant(codeTVA)

                                    If dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVAEnc.Replace("'", "''") & "'", "").Length > 0 Then
                                        Dim rwTva As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVAEnc.Replace("'", "''") & "'", "")(0)

                                        If Not IsDBNull(rwTva.Item("TCpt")) Then
                                            Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "REGUL. TVA", "", rwTva.Item("TCpt"), "0000", "48800000", "0000", MontantTVA, CodeJournal)
                                            Ligne += 1
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

                                'Créer le compte PAYEUR
                                Ajout_Compte(keepDossier, ComptePayeur, "CLIENT " & NomPayeur)
                                Ajout_Activite(keepDossier, ActivitePayeur, "ACTIVITE " & ActivitePayeur)
                                Ajout_PlanComptable(keepDossier, ComptePayeur, ActivitePayeur)

                                'Créer la ligne
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "AVANCE " & NomPayeur, "", "48800000", "0000", ComptePayeur, ActivitePayeur, AvanceClient, CodeJournal)
                                Ligne += 1
                            End If

                            'Marquer le reglement comme exporté
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = Now
                        Next 'NEXT REGLEMENT

                        'ON SOLDE LA REMISE PAR LA BANQUE
                        'Dim libLigneTotalRemise As String = String.Format("TOTAL REMISE {0}", rwRemise.Item("nRemiseBanque")).Trim
                        Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtRemise, Ligne, "TOTAL REMISE", Convert.ToString(rwRemise("nRemiseBanque")), CompteBanque, ActiviteBanque, "48800000", "0000", Decimal.Round(CDec(rwRemise.Item("Montant")), 2), CodeJournal)

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
                Dim CodeJournal As String = TrouverCodeJournal("ac")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebAFacture, DateFinAFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("AFacture").Select(strFiltre, "nFacture")
                Dim i As Integer = 0
                Dim dtExport As Date = Now
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        Dim keepDossier As String = TrouverDossier(rwFacture.Item("DateFacture"))
                        If keepDossier Is Nothing Or keepDossier = "" Then
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

                        Ajout_Compte(keepDossier, "48800000", "COMPTE DE REPARTITION")
                        Ajout_Activite(keepDossier, "0000", "ACTIVITE GENERALE")
                        Ajout_PlanComptable(keepDossier, "48800000", "0000")

                        Dim NumPiece As Integer = rwFacture.Item("nFacture")
                        If Not IsNumeric(BlocnPieceDebutAFacture) Then BlocnPieceDebutAFacture = 80000
                        If Not IsNumeric(BlocnPieceFinAFacture) Then BlocnPieceFinAFacture = 100000

                        NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutAFacture), CInt(BlocnPieceFinAFacture))

                        Dim libPiece As String = Left(String.Format("Achat {0} du {1:dd/MM/yy}: {2}", rwFacture("nFacture"), rwFacture("DateFacture"), rwFournisseur("Nom")), 50)
                        'Création de la pièce
                        If Ajout_Piece(keepDossier, NumPiece, rwFacture.Item("DateFacture"), libPiece, CodeJournal) Then
                            rwFacture.Item("ExportCompta") = True
                            rwFacture.Item("DateExportCompta") = dtExport
                        End If

                        'Récupération des infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")
                        'Création du compte fournisseur
                        Ajout_Compte(keepDossier, CompteFournisseur, "FOURNISSEUR " & NomFournisseur)
                        Ajout_Activite(keepDossier, ActiviteFournisseur, "ACTIVITE " & ActiviteFournisseur)
                        Ajout_PlanComptable(keepDossier, CompteFournisseur, ActiviteFournisseur)

                        Dim Ligne As Integer = 0
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
                        Dim HTCptCharge As Decimal = 0
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim HTCptImmo As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0
                        For Each ligneDetail As DataRow In lignesDetailFacture
                            Dim CompteProduit As String = ligneDetail.Item("NCompte")
                            Dim CodeTVA As String = ""
                            Select Case CompteProduit.Substring(0, 1)
                                Case "1" 'Pour gérer les comptes 1013 de parts sociales
                                    CodeTVA = ""
                                    HTCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneHT"), 2)
                                    TVACptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTVA"), 2)
                                    TTCCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case "2"
                                    CodeTVA = "02"
                                    HTCptImmo += Decimal.Round(ligneDetail.Item("MontantLigneHT"), 2)
                                    TVACptImmo += Decimal.Round(ligneDetail.Item("MontantLigneTVA"), 2)
                                    TTCCptImmo += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case "6"
                                    CodeTVA = "01"
                                    HTCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneHT"), 2)
                                    TVACptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTVA"), 2)
                                    TTCCptCharge += Decimal.Round(ligneDetail.Item("MontantLigneTTC"), 2)
                                Case Else
                                    MsgBox(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Compte produit incorrect {2}: Le compte doit être en 1,2 ou 6", NumPiece, rwFacture.Item("DateFacture"), CompteProduit))
                                    Return False
                            End Select

                            If CodeTVA <> "" Then
                                Dim rwTVA As DataRow = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'", "")(0)
                                Ajout_Compte(keepDossier, rwTVA.Item("TCpt"), rwTVA.Item("Libellé"))
                                Ajout_PlanComptable(keepDossier, rwTVA.Item("TCpt"), "0000")
                                If TVASurEncaissement Then
                                    CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)
                                End If
                            End If

                            'Informations produit pour création du compte Produit
                            Dim Unite1 As String = ReplaceDbNull(ligneDetail.Item("LibUnite1"), "")
                            Dim Unite2 As String = ReplaceDbNull(ligneDetail.Item("LibUnite2"), "")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper

                            Ajout_Compte(keepDossier, ligneDetail.Item("NCompte"), "PRODUIT " & NomProduit, Unite1, Unite2)
                            Ajout_Activite(keepDossier, ligneDetail.Item("NActivite"), "ACTIVITE " & ligneDetail("NActivite"))
                            Ajout_PlanComptable(keepDossier, ligneDetail.Item("NCompte"), ligneDetail("NActivite"))

                            Dim Qte1 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite1"), 0)), 2)
                            Dim Qte2 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite2"), 0)), 2)
                            Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, "03", CodeJournal, "", NomFournisseur, NomProduit)
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"), Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2), 0, "D", Qte1, Qte2, "48800000", "0000")
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, "48800000", "0000", 0, Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2), "C", 0, 0, ligneDetail.Item("NCompte"), ligneDetail.Item("NActivite"))

                            Ligne += 1
                        Next

                        ' On solde le compte 488 par le compte Fournisseur
                        Dim CodeTVA1 As String = "01"
                        Dim CodeTVA2 As String = "02"
                        If TVASurEncaissement = True Then
                            CodeTVA1 = CodeTVAEncaissementCorrespondant(CodeTVA1)
                            CodeTVA2 = CodeTVAEncaissementCorrespondant(CodeTVA2)
                        End If

                        If HTCptCharge <> 0 Then
                            Dim CompteTva As String = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA1.Replace("'", "''") & "'", "")(0).Item("TCpt")
                            Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, CodeTVA1, CodeJournal, CodeTVA1, "TOTAL ACHAT", NumPiece)
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", Decimal.Round(HTCptCharge, 2), 0, "D", 0, 0, CompteFournisseur, ActiviteFournisseur)
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 2, CompteTva, "0000", Decimal.Round(TVACptCharge, 2), 0, "D", 0, 0, "", "0")
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, CompteFournisseur, ActiviteFournisseur, 0, Decimal.Round(TTCCptCharge, 2), "C", 0, 0, "48800000", "0000")
                            Ligne += 1
                        End If
                        If HTCptImmo <> 0 Then
                            Dim CompteTva As String = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA2.Replace("'", "''") & "'", "")(0).Item("TCpt")
                            Ajout_Ligne(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, True, CodeTVA2, CodeJournal, CodeTVA2, "TOTAL ACHAT IMMO", NumPiece)
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 1, "48800000", "0000", Decimal.Round(HTCptImmo, 2), 0, "D", 0, 0, CompteFournisseur, ActiviteFournisseur)
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 2, CompteTva, "0000", Decimal.Round(TVACptImmo, 2), 0, "D", 0, 0, "", "0")
                            Ajout_Mouvement(keepDossier, NumPiece, rwFacture.Item("DateFacture"), Ligne, 3, CompteFournisseur, ActiviteFournisseur, 0, Decimal.Round(TTCCptImmo, 2), "C", 0, 0, "48800000", "0000")
                        End If
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
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateReglement>='{0}' and DateReglement<='{1}')", DateDebAReglement, DateFinAReglement)
                Dim rwReglementsAExporter() As DataRow = dsAgrifact.Tables("AReglement").Select(strFiltre, "nReglement")
                Dim i As Integer = 0
                Dim dtExport As Date = Now
                For Each rwReglement As DataRow In rwReglementsAExporter
                    Try
                        Dim Escompte As Boolean = False
                        Dim TTCEscompteCharge As Decimal = 0
                        Dim TVAEscompteCharge As Decimal = 0
                        Dim HTEscompteCharge As Decimal = 0
                        Dim TTCEscompteImmo As Decimal = 0
                        Dim TVAEscompteImmo As Decimal = 0
                        Dim HTEscompteImmo As Decimal = 0
                        Dim keepDossier As String = TrouverDossier(rwReglement.Item("DateReglement"))
                        If keepDossier Is Nothing Or keepDossier = "" Then
                            Throw New WarningExport(String.Format("Pas de dossier disponible pour le réglement achat du {0:dd/MM/yy}", rwReglement.Item("DateReglement")))
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

                        'S'assurer que les comptes existent
                        Ajout_Compte(keepDossier, "48800000", "COMPTE DE REPARTITION")
                        Ajout_Activite(keepDossier, "0000", "ACTIVITE GENERALE")
                        Ajout_PlanComptable(keepDossier, "48800000", "0000")

                        'Infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")
                        Ajout_Compte(keepDossier, CompteFournisseur, "FOURNISSEUR " & NomFournisseur)
                        Ajout_Activite(keepDossier, ActiviteFournisseur, "ACTIVITE " & ActiviteFournisseur)
                        Ajout_PlanComptable(keepDossier, CompteFournisseur, ActiviteFournisseur)

                        'Infos banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        Dim ActiviteBanque As String = rwBanque.Item("NActivite")
                        Ajout_Compte(keepDossier, CompteBanque, NomBanque)
                        Ajout_Activite(keepDossier, ActiviteBanque, "ACTIVITE " & ActiviteBanque)
                        Ajout_PlanComptable(keepDossier, CompteBanque, ActiviteBanque)


                        'Déterminer le n° de la piece
                        Dim NumPiece As Integer = rwReglement.Item("nReglement")
                        If Not IsNumeric(BlocnPieceDebutAReglement) Then BlocnPieceDebutAReglement = 150000
                        If Not IsNumeric(BlocnPieceFinAReglement) Then BlocnPieceFinAReglement = 200000

                        'TODO N° à revoir ? => On n'a aucun n° de remise à utiliser
                        NumPiece = CadreFourchette(rwReglement.Item("nReglement"), CInt(BlocnPieceDebutAReglement), CInt(BlocnPieceFinAReglement))

                        While dsAgrigest.Tables("Pieces").Select("PDossier='" & keepDossier & "' And PPiece=" & NumPiece & " And PDate=#" & Convert.ToDateTime(rwReglement.Item("DateReglement")).ToString("MM/dd/yy") & "#", "PDossier").Length = 0
                            NumPiece += 1
                        End While

                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Régl. fourn. {0} du {1:dd/MM/yy}: {3}", rwReglement("nMode"), rwReglement("DateReglement"), NomFournisseur), 50)
                        If Ajout_Piece(keepDossier, NumPiece, rwReglement("DateReglement"), libPiece, CodeJournal) Then
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = dtExport
                        End If

                        If Not IsDBNull(rwReglement.Item("TxEscompte")) AndAlso rwReglement.Item("TxEscompte") <> 0 Then
                            Escompte = True
                        End If

                        'Créer la ligne du réglement
                        Dim DetailFacture As DataRow = dsAgrifact.Tables("AFacture").Select("nDevis=" & dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'")(0).Item("NFacture") & "", "")(0)
                        Dim NumFacture As Integer = DetailFacture.Item("NFacture")
                        If NumFacture < CInt(BlocnPieceDebutAFacture) Then
                            NumFacture = CInt(BlocnPieceDebutAFacture) + NumFacture
                        End If
                        Dim libPaiement As String = "PAIEMENT " & NumFacture
                        Dim LibPaiement2 As String = rwReglement.Item("nMode") & " " & NomFournisseur
                        Ajout_Ligne_SansTVA(keepDossier, NumPiece, rwReglement("DateReglement"), 0, libPaiement, LibPaiement2, CompteFournisseur, ActiviteFournisseur, CompteBanque, ActiviteBanque, Decimal.Round(CDec(rwReglement.Item("Montant")), 2), CodeJournal)

                        'FactureMontantExport
                        Dim SommeDu As Decimal = 0
                        Dim SommePayee As Decimal = 0
                        Dim SommeDejaPayee As Decimal = 0
                        Dim rapportPayeeDu As Decimal = 1
                        Dim SoldeFacture As Boolean = False
                        Dim rwTest As DataRow = dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0)

                        '' Rajouter à la somme payée ce qui a été éventuellement déjà payer et exporter
                        Dim obj As Object = dsAgrifact.Tables("AFactureMontantExport").Compute("Sum(MontantTTC)", "nDevis=" & rwTest.Item("NFacture") & "")
                        If Not obj Is DBNull.Value Then
                            SommeDejaPayee = CDec(obj)
                        End If
                        SommePayee = CDec(rwTest.Item("Montant"))
                        SommeDu = CDec(dsAgrifact.Tables("AFacture").Select("nDevis=" & rwTest.Item("NFacture") & "", "")(0).Item("MontantTTC"))
                        If Not rwReglement.Item("TxEscompte") Is DBNull.Value Then
                            If rwReglement.Item("TxEscompte") <> 0 Then
                                SommeDu -= CDec(rwReglement.Item("MontantEscompte"))
                            End If
                        End If

                        Dim Ligne As Integer = 1
                        If Not rwReglement.Item("Perte") Is DBNull.Value Then
                            If rwReglement.Item("Perte") <> 0 Then
                                Ajout_Compte(keepDossier, COMPTE_PROFIT, "ARRONDI DE PAIEMENT PROFIT")
                                Ajout_PlanComptable(keepDossier, COMPTE_PROFIT, "0000")
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, CDate(rwReglement.Item("DateReglement")), Ligne, "Arrondi de paiement", "Profit " & NumFacture, CompteFournisseur, ActiviteFournisseur, COMPTE_PROFIT, "0000", Decimal.Round(CDec(rwReglement.Item("Perte")), 2), CodeJournal)
                                Ligne += 1
                                SommePayee += rwReglement.Item("Perte")
                            End If
                        End If
                        If Not rwReglement.Item("Profit") Is DBNull.Value Then
                            If rwReglement.Item("Profit") <> 0 Then
                                Ajout_Compte(keepDossier, COMPTE_PERTE, "ARRONDI DE PAIEMENT PERTE")
                                Ajout_PlanComptable(keepDossier, COMPTE_PERTE, "0000")
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, CDate(rwReglement.Item("DateReglement")), Ligne, "Arrondi de paiement", "Perte " & NumFacture, COMPTE_PERTE, "0000", CompteFournisseur, ActiviteFournisseur, Decimal.Round(CDec(rwReglement.Item("Profit")), 2), CodeJournal)
                                Ligne += 1
                                SommePayee -= rwReglement.Item("Profit")
                            End If
                        End If

                        If SommeDu <> SommePayee Then
                            If Math.Abs(SommeDejaPayee + SommePayee - SommeDu) <= 0.2 Then
                                SoldeFacture = True
                            Else
                                rapportPayeeDu = SommePayee / SommeDu
                            End If
                        End If

                        Dim HTCptCharge As Decimal = 0
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim HTCptImmo As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0

                        If SoldeFacture = False Then
                            Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                            For Each ligneDetail As DataRow In lignesDetailFacture
                                Dim CodeTVA As String = ligneDetail.Item("NCompte")
                                If CodeTVA.Substring(0, 1) = "2" Then
                                    CodeTVA = "02"
                                    TVACptImmo += (ligneDetail.Item("MontantLigneTVA") * rapportPayeeDu)
                                    TTCCptImmo += (ligneDetail.Item("MontantLigneTTC") * rapportPayeeDu)
                                    'HTCptImmo = TTCCptImmo - TVACptImmo
                                ElseIf CodeTVA.Substring(0, 1) = "6" Then
                                    CodeTVA = "01"
                                    TVACptCharge += (ligneDetail.Item("MontantLigneTVA") * rapportPayeeDu)
                                    TTCCptCharge += (ligneDetail.Item("MontantLigneTTC") * rapportPayeeDu)
                                    'HTCptCharge = TTCCptCharge - TVACptCharge
                                Else
                                    MsgBox(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Code TVA incorrect !", NumPiece, rwReglement.Item("DateReglement")))
                                    Return False
                                End If
                            Next
                        Else
                            Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                            Dim ligneDetail As DataRow
                            For Each ligneDetail In lignesDetailFacture
                                Dim CodeTVA As String = ligneDetail.Item("NCompte")
                                If CodeTVA.Substring(0, 1) = "2" Then
                                    CodeTVA = "02"
                                    TVACptImmo += ligneDetail.Item("MontantLigneTVA")
                                    TTCCptImmo += ligneDetail.Item("MontantLigneTTC")
                                ElseIf CodeTVA.Substring(0, 1) = "6" Then
                                    CodeTVA = "01"
                                    TVACptCharge += ligneDetail.Item("MontantLigneTVA")
                                    TTCCptCharge += ligneDetail.Item("MontantLigneTTC")
                                End If
                            Next

                            lignesDetailFacture = dsAgrifact.Tables("AFactureMontantExport").Select("nDevis='" & dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture") & "'", "nDevis")
                            For Each ligneDetail In lignesDetailFacture
                                If ligneDetail.Item("TTVA") = "02" Then
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

                        If TVASurEncaissement = True Then
                            If HTCptCharge <> 0 Then
                                Dim CodeTVA As String = "01"
                                Dim rwFactureMontantExport As DataRow = dsAgrifact.Tables("AFactureMontantExport").NewRow
                                With rwFactureMontantExport
                                    .Item("nDevis") = dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture")
                                    .Item("TTVA") = "01"
                                    .Item("MontantHT") = HTCptCharge
                                    .Item("MontantTVA") = TVACptCharge
                                    .Item("MontantTTC") = TTCCptCharge
                                    .Item("DateExportCompta") = Now
                                End With
                                dsAgrifact.Tables("AFactureMontantExport").Rows.Add(rwFactureMontantExport)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))
                                Dim cptTVA As String = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'", "")(0).Item("TCpt")
                                Ajout_Ligne(keepDossier, NumPiece, dtReglement, Ligne, True, "", CodeJournal, CodeTVA, "REGUL. TVA", NumFacture)
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 1, "48800000", "0000", Decimal.Round(CDec(HTCptCharge), 2), 0, "D", 0, 0, "48800000", "0000")
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 2, cptTVA, "0000", Decimal.Round(CDec(TVACptCharge), 2), 0, "D", 0, 0, "", "0")
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 3, "48800000", "0000", 0, Decimal.Round(CDec(TTCCptCharge), 2), "C", 0, 0, "48800000", "0000")
                                Ligne += 1

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)
                                cptTVA = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'", "")(0).Item("TCpt")
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, "REGUL. TVA", NumFacture, "48800000", "0000", cptTVA, "0000", Decimal.Round(CDec(TVACptCharge), 2), CodeJournal)
                                Ligne += 1
                            End If
                            If HTCptImmo <> 0 Then
                                Dim CodeTVA As String = "02"
                                Dim rwFactureMontantExport As DataRow = dsAgrifact.Tables("AFactureMontantExport").NewRow
                                With rwFactureMontantExport
                                    .Item("nDevis") = dsAgrifact.Tables("AReglement_detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'", "nReglement")(0).Item("nFacture")
                                    .Item("TTVA") = "02"
                                    .Item("MontantHT") = HTCptImmo
                                    .Item("MontantTVA") = TVACptImmo
                                    .Item("MontantTTC") = TTCCptImmo
                                    .Item("DateExportCompta") = Now
                                End With
                                dsAgrifact.Tables("AFactureMontantExport").Rows.Add(rwFactureMontantExport)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))
                                Dim cptTVA As String = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'", "")(0).Item("TCpt")

                                Ajout_Ligne(keepDossier, NumPiece, dtReglement, Ligne, True, "", CodeJournal, CodeTVA, "REGUL. TVA", NumFacture)
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 1, "48800000", "0000", Decimal.Round(CDec(HTCptImmo), 2), 0, "D", 0, 0, "48800000", "0000")
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 2, cptTVA, "0000", Decimal.Round(CDec(TVACptImmo), 2), 0, "D", 0, 0, "", "0")
                                Ajout_Mouvement(keepDossier, NumPiece, dtReglement, Ligne, 3, "48800000", "0000", 0, Decimal.Round(CDec(TTCCptImmo), 2), "C", 0, 0, "48800000", "0000")
                                Ligne += 1

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)
                                cptTVA = dsAgrigest.Tables("TVA").Select("TTVA='" & CodeTVA.Replace("'", "''") & "'", "")(0).Item("TCpt")
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, "REGUL. TVA", NumFacture, "48800000", "0000", cptTVA, "0000", Decimal.Round(CDec(TVACptImmo), 2), CodeJournal) 'True, "", "O", "N", "REGUL. TVA", NumFacture)
                            End If
                        End If
                        'End If
                        If Not IsDBNull(rwReglement.Item("TxEscompte")) Then
                            If rwReglement("TxEscompte") <> 0 Then
                                Ligne += 1
                                Dim MontantTTCAvecEscompte As Decimal = Convert.ToDecimal(rwReglement.Item("MontantEscompte")).ToString("0.00")
                                Dim MontantTVAAvecEscompteImmo As Decimal = Convert.ToDecimal(TVACptImmo * rwReglement.Item("TxEscompte")).ToString("0.00")
                                Dim MontantTVAAvecEscompteCharge As Decimal = Convert.ToDecimal(TVACptCharge * rwReglement.Item("TxEscompte")).ToString("0.00")
                                Dim MontantHTAvecEscompte As Decimal = MontantTTCAvecEscompte - (MontantTVAAvecEscompteImmo + MontantTVAAvecEscompteCharge)

                                Dim dtReglement As Date = CDate(rwReglement("DateReglement"))

                                Ajout_Compte(keepDossier, COMPTE_ESCOMPTE_OBTENUE, "ESCOMPTE OBTENUE SUR ACHAT")
                                Ajout_PlanComptable(keepDossier, COMPTE_ESCOMPTE_OBTENUE, "0000")

                                ' On solde le compte fournisseur du montant HT de l'escompte
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, NomFournisseur, "Escompte " & NumFacture, CompteFournisseur, ActiviteFournisseur, "48800000", "0000", MontantTTCAvecEscompte, CodeJournal)
                                ' on passe le montant de l'escompte en escompte
                                Ligne += 1
                                Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, "Escompte Obtenue", NumFacture, "48800000", "0000", COMPTE_ESCOMPTE_OBTENUE, "0000", MontantHTAvecEscompte, CodeJournal)
                                ' On solde les codes TVA
                                If MontantTVAAvecEscompteCharge <> 0 Then
                                    Dim cptTVA As String = dsAgrigest.Tables("TVA").Select("TTVA='01'", "")(0).Item("TCpt")
                                    Ligne += 1
                                    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, "REGUL. TVA ESCOMPTE", NumFacture, "48800000", "0000", cptTVA, "0000", MontantTVAAvecEscompteCharge, CodeJournal)
                                End If
                                If MontantTVAAvecEscompteImmo <> 0 Then
                                    Dim cptTVA As String = dsAgrigest.Tables("TVA").Select("TTVA='02'", "")(0).Item("TCpt")
                                    Ligne += 1
                                    Ajout_Ligne_SansTVA(keepDossier, NumPiece, dtReglement, Ligne, "REGUL. TVA IMMO", "ESCOMPTE " & NumFacture, "48800000", "0000", cptTVA, "0000", MontantTVAAvecEscompteImmo, CodeJournal)
                                End If
                            End If
                        End If
                        rwReglement.Item("ExportCompta") = True
                        rwReglement.Item("DateExportCompta") = Now
                    Catch ex As WarningExport
                        'Probleme sur ce reglement. On logue le message et on passe à la ligne suivante
                        AjouterRapport(ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwReglementsAExporter.Length)
                Next
            End If
            Return True
        End Function
#End Region

#Region "Fonctions Ecriture Agrigest"
        Protected Overloads Function Ajout_Piece(ByVal KeepDossier As String, ByVal NPiece As String, ByVal DatePiece As Date, ByVal LibPiece As String, Optional ByVal Journal As String = Nothing) As Boolean
            'Debug.WriteLine(String.Format("+ PIECE {0}-{1:dd/MM/yyyy} POUR {2}", NPiece, DatePiece, KeepDossier))
            If dsAgrigest.Tables("Pieces").Select(String.Format("PDossier='{0}' And PPiece={1} And PDate=#{2:MM/dd/yy}#", KeepDossier, NPiece, DatePiece), "PDossier").Length = 0 Then
                Dim rwPiece As DataRow = dsAgrigest.Tables("Pieces").NewRow
                rwPiece("PDossier") = KeepDossier
                rwPiece("PPiece") = NPiece
                rwPiece("PDate") = DatePiece.ToString("dd/MM/yy")
                If dsAgrigest.Tables("Pieces").Columns.Contains("Libelle") AndAlso Not LibPiece Is Nothing Then
                    rwPiece("Libelle") = LibPiece
                End If
                If dsAgrigest.Tables("Pieces").Columns.Contains("Journal") AndAlso Not Journal Is Nothing Then
                    rwPiece("Journal") = Journal
                End If
                dsAgrigest.Tables("Pieces").Rows.Add(rwPiece)
                Return True
            Else
                Throw New WarningExport(String.Format("La pièce {0} du {1:dd/MM/yy} existe déjà.", NPiece, DatePiece))
            End If
        End Function

        Protected Overloads Sub Ajout_Ligne_SansTVA(ByVal dossier As String, ByVal NPiece As String, ByVal dtPiece As Date, ByVal Ligne As Long, ByVal NomClient As String, ByVal NomProduit As String, ByVal CptD As String, ByVal ActD As String, ByVal CptC As String, ByVal ActC As String, ByVal Montant As Decimal, ByVal CodeJournal As String)
            Ajout_Ligne(dossier, NPiece, dtPiece, Ligne, False, "", CodeJournal, "", NomClient, NomProduit)
            Ajout_Mouvement(dossier, NPiece, dtPiece, Ligne, 1, CptD, ActD, Montant, 0, "D", 0, 0, CptC, ActC)
            Ajout_Mouvement(dossier, NPiece, dtPiece, Ligne, 3, CptC, ActC, 0, Montant, "C", 0, 0, CptD, ActD)
        End Sub

        Protected Overrides Sub Ajout_Ligne(ByVal KeepDossier As String, ByVal NPiece As String, ByVal DatePiece As Date, ByVal Ligne As Long, ByVal TVASansCompte As Boolean, ByVal CodeTVA As String, ByVal CodeJournal As String, ByVal CodeTVACompte As String, ByVal NomClient As String, ByVal NomProduit As String)
            'Debug.WriteLine(String.Format("+ LIGNE {0}-{1:dd/MM/yyyy} n°{3} POUR {2}", NPiece, DatePiece, KeepDossier, Ligne))
            If dsAgrigest.Tables("Lignes").Select("LDossier='" & KeepDossier & "' And LPiece='" & NPiece & "' And LDate=#" & DatePiece.ToString("MM/dd/yy") & "# And LLig='" & Ligne & "'").Length = 0 Then
                If NomClient.Length > 17 Then NomClient = NomClient.Substring(0, 17)
                If NomProduit.Length > 17 Then NomProduit = NomProduit.Substring(0, 17)
                Dim libelleLigne As String = NomClient & " " & NomProduit
                If libelleLigne.Length > 35 Then libelleLigne = libelleLigne.Substring(0, 35)

                Dim rw As DataRow = dsAgrigest.Tables("Lignes").NewRow
                rw.Item("LDossier") = KeepDossier
                rw.Item("LPiece") = NPiece
                rw.Item("LDate") = DatePiece.Date
                rw.Item("LLig") = Ligne
                rw.Item("LJournal") = CodeJournal
                rw.Item("LTva") = CodeTVA
                rw.Item("LMtTVA") = CodeTVACompte
                rw.Item("LLib") = libelleLigne
                dsAgrigest.Tables("Lignes").Rows.Add(rw)
            End If
        End Sub

        Protected Overrides Sub Ajout_Mouvement(ByVal KeepDossier As String, ByVal NPiece As String, ByVal DatePiece As Date, ByVal Ligne As Long, ByVal NOrdre As Integer, ByVal NCompte As String, ByVal NActi As String, ByVal MtDeb As Decimal, ByVal MtCre As Decimal, ByVal D_C As String, ByVal Qte1 As Decimal, ByVal Qte2 As Decimal, ByVal NCompteCtr As String, ByVal NActiCtr As String)
            'Debug.WriteLine(String.Format("+ MVT {0}-{1:dd/MM/yyyy} n°{3}-{4} POUR {2}", NPiece, DatePiece, KeepDossier, Ligne, NOrdre))
            NCompte = NCompte.PadRight(8, "0"c)
            NActi = NActi.PadRight(4, "0"c)
            NCompteCtr = NCompteCtr.PadRight(8, "0"c)
            NActiCtr = NActiCtr.PadRight(4, "0"c)
            If dsAgrigest.Tables("Mouvements").Select("MDossier='" & KeepDossier & "' And MPiece='" & NPiece & "' And MDate=#" & DatePiece.ToString("MM/dd/yy") & "# And MLig='" & Ligne & "' And MOrdre=" & NOrdre & "").Length = 0 Then
                Dim rw As DataRow = dsAgrigest.Tables("Mouvements").NewRow
                rw.Item("MDossier") = KeepDossier
                rw.Item("MPiece") = NPiece
                rw.Item("MDate") = DatePiece.ToString("dd/MM/yy")
                rw.Item("MLig") = Ligne
                rw.Item("MOrdre") = NOrdre
                rw.Item("MCpt") = NCompte
                rw.Item("MActi") = NActi
                rw.Item("MMtDeb") = MtDeb
                rw.Item("MMtCre") = MtCre
                rw.Item("MD_C") = D_C
                rw.Item("MQte1") = Qte1
                rw.Item("MQte2") = Qte2
                rw.Item("MLettrage") = DBNull.Value
                rw.Item("MCouleur") = DBNull.Value
                rw.Item("MCptCtr") = NCompteCtr
                rw.Item("MActCtr") = NActiCtr
                dsAgrigest.Tables("Mouvements").Rows.Add(rw)
            End If
        End Sub

        Public Overrides Function Ajout_Activite(ByVal KeepDossier As String, ByVal Activite As String, ByVal LibActivite As String, Optional ByVal Enregistrement As Boolean = False) As String
            Activite = Activite.PadRight(4, "0"c)
            If dsAgrigest.Tables("Activites").Select("ADossier='" & KeepDossier & "' And AActi='" & Activite & "'").Length = 0 Then
                Dim rw As DataRow = dsAgrigest.Tables("Activites").NewRow
                rw.Item("ADossier") = KeepDossier
                rw.Item("AActi") = Activite
                If Len(LibActivite) > 20 Then
                    rw.Item("ALib") = LibActivite.Substring(0, 20)
                Else
                    rw.Item("ALib") = LibActivite
                End If
                rw.Item("AQte") = 0
                rw.Item("AUnit") = ""
                dsAgrigest.Tables("Activites").Rows.Add(rw)
                Debug.WriteLine(String.Format("+ ACTIVITE {0}:{1} POUR {2}", Activite, LibActivite, KeepDossier))
                If Enregistrement = True Then
                    DtaActivites.Update(dsAgrigest, "Activites")
                End If
                Return "L'activité a été correctement insérée."
            Else
                Return "Cette activité est déjà présente en comptabilité."
            End If
        End Function

        Public Overrides Function Ajout_Compte(ByVal KeepDossier As String, ByVal Compte As String, ByVal LibCompte As String, Optional ByVal LibU1 As String = "", Optional ByVal LibU2 As String = "", Optional ByVal Enregistrement As Boolean = False) As String
            Compte = Compte.PadRight(8, "0"c)
            If dsAgrigest.Tables("Comptes").Select("CDossier='" & KeepDossier & "' And CCpt='" & Compte & "'").Length = 0 Then
                Dim rw As DataRow = dsAgrigest.Tables("Comptes").NewRow
                rw.Item("CDossier") = KeepDossier
                rw.Item("CCpt") = Compte
                If Len(LibCompte) > 25 Then
                    rw.Item("CLib") = LibCompte.Substring(0, 25)
                Else
                    rw.Item("CLib") = LibCompte
                End If
                If Len(LibU1) > 2 Then
                    rw.Item("CU1") = LibU1.Substring(0, 2)
                Else
                    rw.Item("CU1") = LibU1
                End If
                If Len(LibU2) > 2 Then
                    rw.Item("CU2") = LibU2.Substring(0, 2)
                Else
                    rw.Item("CU2") = LibU2
                End If
                dsAgrigest.Tables("Comptes").Rows.Add(rw)
                Debug.WriteLine(String.Format("+ COMPTE {0}:{1} POUR {2}", Compte, LibCompte, KeepDossier))
                If Enregistrement = True Then
                    DtaComptes.Update(dsAgrigest, "Comptes")
                End If
                Return "Le compte a été correctement inséré."
            Else
                Return "Ce compte est déjà présent en comptabilité."
            End If
        End Function

        Public Overrides Function Ajout_PlanComptable(ByVal KeepDossier As String, ByVal Compte As String, ByVal Activite As String, Optional ByVal Enregistrement As Boolean = False) As String
            Activite = Activite.PadRight(4, "0"c)
            Compte = Compte.PadRight(8, "0"c)
            If dsAgrigest.Tables("PlanComptable").Select("PlDossier='" & KeepDossier & "' And PlCpt='" & Compte & "' And PlActi='" & Activite & "'").Length = 0 Then
                Dim rw As DataRow = dsAgrigest.Tables("PlanComptable").NewRow
                rw.Item("PlDossier") = KeepDossier
                rw.Item("PlCpt") = Compte
                rw.Item("PlActi") = Activite
                rw.Item("PlRepG_D") = 0
                rw.Item("PlRepG_C") = 0
                rw.Item("PlRepG_U1") = 0
                rw.Item("PlRepG_U2") = 0
                rw.Item("PlRepA_D") = 0
                rw.Item("PlRepA_C") = 0
                rw.Item("PlRepA_U1") = 0
                rw.Item("PlRepA_U2") = 0
                rw.Item("PlSoldeG_D") = 0
                rw.Item("PlSoldeG_C") = 0
                rw.Item("PlSoldeG_U1") = 0
                rw.Item("PlSoldeG_U2") = 0
                rw.Item("PlSoldeA_D") = 0
                rw.Item("PlSoldeA_C") = 0
                rw.Item("PlSoldeA_U1") = 0
                rw.Item("PlSoldeA_U2") = 0
                dsAgrigest.Tables("PlanComptable").Rows.Add(rw)
                Debug.WriteLine(String.Format("+ PLC {0}-{1} POUR {2}", Compte, Activite, KeepDossier))
                If Enregistrement = True Then
                    DtaPlanComptable.Update(dsAgrigest, "PlanComptable")
                End If
                Return "Le compte a été correctement inséré."
            Else
                Return "Ce compte est déjà présent en comptabilité."
            End If
        End Function
#End Region

#Region "Méthodes diverses"
        Protected Function TrouverCodeJournal(ByVal typeJournal As String, Optional ByVal cptBanque As String = Nothing) As String
            If dsAgrigest.Tables.Contains("Journal") Then
                If typeJournal = "tr" Then
                    If Not cptBanque Is Nothing Then
                        Dim drJournal() As DataRow = dsAgrigest.Tables("Journal").Select(String.Format("JType='{0}' AND JCompteContre='{1}'", typeJournal, cptBanque))
                        If drJournal.Length > 0 Then
                            Return Convert.ToString(drJournal(0)("JCodeJournal"))
                        Else
                            'SI ON NE TROUVE PAS DE JOURNAL DE TRESO POUR LE COMPTE INDIQUE ?
                            '=> Journal OD
                            drJournal = dsAgrigest.Tables("Journal").Select(String.Format("JType='{0}'", "od"))
                            If drJournal.Length > 0 Then
                                Return Convert.ToString(drJournal(0)("JCodeJournal"))
                            End If
                        End If
                    End If
                Else
                    Dim drJournal() As DataRow = dsAgrigest.Tables("Journal").Select(String.Format("JType='{0}'", typeJournal))
                    If drJournal.Length > 0 Then
                        Return Convert.ToString(drJournal(0)("JCodeJournal"))
                    End If
                End If
            End If
            Return Nothing
        End Function

        Protected Overrides Function CodeTVAEncaissementCorrespondant(ByVal CodeTVA As String) As String
            If CodeTVA = "01" Then : Return "RR1"
            ElseIf CodeTVA = "02" Then : Return "RR2"
            ElseIf CodeTVA = "2.1" Then : Return "RP21"
            ElseIf CodeTVA = "19.6" Then : Return "RP19"
            ElseIf CodeTVA = "20" Then : Return "RP20"
            ElseIf CodeTVA = "5.5" Then : Return "RP55"
            ElseIf CodeTVA = "RR1" Then : Return "01"
            ElseIf CodeTVA = "RR2" Then : Return "02"
            ElseIf CodeTVA = "RP21" Then : Return "2.1"
            ElseIf CodeTVA = "RP19" Then : Return "19.6"
            ElseIf CodeTVA = "RP20" Then : Return "20"
            ElseIf CodeTVA = "RP55" Then : Return "5.5"
            ElseIf CodeTVA = "RPCH" Then : Return "RPCH"
            ElseIf CodeTVA = "A" Then : Return "A1"
            ElseIf CodeTVA = "V" Then : Return "V1"
            ElseIf CodeTVA = "W" Then : Return "W1"
            ElseIf CodeTVA = "A1" Then : Return "A"
            ElseIf CodeTVA = "V1" Then : Return "V"
            ElseIf CodeTVA = "W1" Then : Return "W"
            ElseIf CodeTVA = "D" Then : Return "D"
            ElseIf CodeTVA = "RP10" Then : Return "10"
            ElseIf CodeTVA = "10" Then : Return "RP10"
            Else : Return "0"
            End If
        End Function

        Private Sub GererEcartExportFacture(ByVal ecart As Decimal, ByVal facturationTTC As Boolean, ByVal keepDossier As String, ByVal numPiece As Integer, ByVal dateFacture As String)
            Dim decompteEcart As Decimal = System.Math.Abs(ecart)

            'Seulement si la facture est en FacturationTTC
            If (facturationTTC) Then
                'On récupère la liste des mouvements de la pièce ayant un numéro de 
                'compte commencant par 70 (comptes de vente)
                'Puis on effectue un tri descendant par montant 
                Dim filtre As String = String.Format("MDossier='{0}' AND MPiece={1} AND MDate='{2}' AND MCpt LIKE '{3}'", keepDossier, numPiece, dateFacture, "70*")
                Dim listeMouvementsDR() As DataRow = dsAgrigest.Tables("Mouvements").Select(filtre, "MMtCre DESC")

                If Not (listeMouvementsDR Is Nothing) Then
                    'Affectation de l'écart.
                    'On parcours les mouvements de la liste puis on affecte 0.01 au montant du mouvement 
                    'jusqu'à épuisement de l'écart 
                    If (listeMouvementsDR.Length > 0) Then
                        While (decompteEcart > 0)
                            For Each mouvementsDR As DataRow In listeMouvementsDR
                                If (decompteEcart > 0) Then
                                    'Recherche du 48800000 lié au compte 70
                                    Dim filtre488 As String = String.Format("MDossier='{0}' AND MPiece={1} AND MDate='{2}' AND MLig={3} AND MCpt LIKE '{4}'", keepDossier, numPiece, dateFacture, mouvementsDR.Item("MLig"), "48800000")
                                    Dim listeMvts488DR() As DataRow = dsAgrigest.Tables("Mouvements").Select(filtre488, "MMtCre DESC")
                                    Dim mvts488DR As DataRow

                                    If Not (listeMvts488DR Is Nothing) Then
                                        If (listeMvts488DR.Length > 0) Then
                                            mvts488DR = listeMvts488DR(0)
                                        End If
                                    End If

                                    If (ecart < 0) Then
                                        mouvementsDR("MMtCre") = CDec(mouvementsDR("MMtCre")) + 0.01
                                        mvts488DR("MMtDeb") = CDec(mvts488DR("MMtDeb")) + 0.01
                                    Else
                                        mouvementsDR("MMtCre") = CDec(mouvementsDR("MMtCre")) - 0.01
                                        mvts488DR("MMtDeb") = CDec(mvts488DR("MMtDeb")) - 0.01
                                    End If

                                    decompteEcart = decompteEcart - 0.01
                                End If
                            Next
                        End While
                    End If

                    'Recalcul du montant de contrôle HT des taux de TVA
                    Me.RecalculerMontantHTControleFacture(listeMouvementsDR, keepDossier, numPiece, dateFacture)
                End If
            End If
        End Sub

        Private Sub RecalculerMontantHTControleFacture(ByVal listeMouvementsDR() As DataRow, ByVal keepDossier As String, ByVal numPiece As Integer, ByVal DateFacture As String)
            Dim listeParTxTVA As New Dictionary(Of String, Decimal)

            'On parcours tous les mouvements de la pièce ayant un compte commencant par 70
            For Each mouvementsDR As DataRow In listeMouvementsDR
                'Recherche de la ligne associée au mouvement afin d'obtenir le code TVA
                Dim filtre2 As String = String.Format("LDossier='{0}' AND LPiece={1} AND LDate='{2}' AND LLig={3}", keepDossier, numPiece, DateFacture, mouvementsDR("MLig"))
                Dim listeLignesDR() As DataRow = dsAgrigest.Tables("Lignes").Select(filtre2, "")

                If Not (listeLignesDR Is Nothing) Then
                    If (listeLignesDR.Length > 0) Then
                        Dim lignesDR As DataRow = listeLignesDR(0)
                        Dim TTVA As String = String.Empty

                        If Not (String.IsNullOrEmpty(lignesDR("LTVA"))) Then
                            TTVA = CStr(lignesDR("LTVA"))
                            Dim montantHT As Decimal = CDec(ReplaceDbNull(mouvementsDR.Item("MMtCre"), 0))

                            'On cumule le montant HT par code TVA
                            If Not (listeParTxTVA.ContainsKey(TTVA)) Then
                                listeParTxTVA.Add(TTVA, montantHT)
                            Else
                                Dim value As Decimal = 0

                                listeParTxTVA.TryGetValue(TTVA, value)

                                value = value + montantHT

                                listeParTxTVA(TTVA) = value
                            End If
                        End If
                    End If
                End If
            Next

            'Pour chaque code TVA, on affecte le montant cumulé au mouvement de contrôle du montant HT de la TVA
            'Donc : somme des montants HT des mouvements portant sur un compte 70 et ayant un même code TVA 
            '= montant du mouvement de contrôle du HT du code TVA
            For Each kpv As KeyValuePair(Of String, Decimal) In listeParTxTVA
                'Recherche de la ligne correspondant au code de TVA
                Dim filtre3 As String = String.Format("LDossier='{0}' AND LPiece={1} AND LDate='{2}' AND LMtTVA='{3}'", keepDossier, numPiece, DateFacture, kpv.Key)
                Dim listeLignesDR() As DataRow = dsAgrigest.Tables("Lignes").Select(filtre3, "")

                If Not (listeLignesDR Is Nothing) Then
                    If (listeLignesDR.Length > 0) Then
                        Dim lignesDR As DataRow = listeLignesDR(0)

                        'Recherche du mouvement correspondant à cette ligne ayant l'ordre 3 (HT)
                        Dim filtre4 As String = String.Format("MDossier='{0}' AND MPiece={1} AND MDate='{2}' AND MLig={3} AND MOrdre={4}", keepDossier, numPiece, DateFacture, lignesDR.Item("LLig"), 3)
                        Dim listeMvtsDR() As DataRow = dsAgrigest.Tables("Mouvements").Select(filtre4, "")

                        If Not (listeMvtsDR Is Nothing) Then
                            If (listeMvtsDR.Length > 0) Then
                                Dim mvtsDR As DataRow = listeMvtsDR(0)

                                mvtsDR.Item("MMtCre") = kpv.Value
                            End If
                        End If
                    End If
                End If
            Next
        End Sub

        Private Function CreerNumeroPiece(ByVal nFacture As Integer, ByVal debFourchette As Integer, ByVal finFourchette As Integer) As Integer
            Dim numPiece As Integer
            Dim numPieceStr As String = String.Empty

            numPiece = CadreFourchette(nFacture, debFourchette, finFourchette)

            'Gestion de la case à cocher "Conserver les 5 derniers chiffres du numéro de facture 
            'pour le numéro de pièce" dans les Paramètres compta
            If (VFactureNumFactureAgrifact) Then
                numPiece = Microsoft.VisualBasic.Right(nFacture, 5)
            End If

            'Gestion de la case à cocher "Composer le numéro de pièce (5 positions maximum)" 
            'dans les Paramètres compta
            If (Me.VFactureComposerNumPiece) Then
                If Not (String.IsNullOrEmpty(VFactureRacineNumPiece)) Then
                    numPieceStr = VFactureRacineNumPiece
                End If

                numPieceStr = numPieceStr & Microsoft.VisualBasic.Right(nFacture, 5 - numPieceStr.Length)

                If (IsNumeric(numPieceStr)) Then
                    numPiece = CInt(numPieceStr)
                End If
            End If

            Return numPiece
        End Function
#End Region

    End Class
End Namespace