Namespace ISTEA
    Public Class ExportISTEA
        Inherits ExportComptaFichierBase

        Private Const COMPTE_PERTE As String = "65800000"
        Private Const COMPTE_PROFIT As String = "75800000"
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
            Return String.Format("{0}-Export du {1:dd-MM-yyy}.txt", nDossier, Now)
        End Function

        Public Overrides Sub ChargerDonnees(ByVal sqlConnString As String)
            If options Is Nothing Then options = New OptionsExport(True, "Test d'export au format ISTEA", Utils.ModeExportation.Delimite, True, True)
            options.ExporterContrepartie = (MsgBox("L'export doit-il contenir les lignes de contrepartie ?" & vbCrLf & _
                                                    "Si vous choisissez non, ISTEA devra définir automatiquement " & vbCrLf & _
                                                    "les contreparties des écritures.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes)

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
            If options Is Nothing Then options = New OptionsExport(True, "Test d'export au format ISTEA")
            export = New Export
            If options.ExporterPieces Then
                Return MyBase.EnvoiComptaInterne()
            End If
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
            Select Case CodeTVA
                Case "71" : Return "75"
                Case "716" : Return "756"
                Case "75" : Return "71"
                Case "756" : Return "716"
                Case Else : Return CodeTVA
            End Select
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

#Region "EXPORT VENTES"
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

                        'Init variables ECR 
                        Dim dtPiece As Date = rwFacture("DateFacture")
                        Dim p As New Piece
                        With p
                            .CodeJournal = CodeJournal
                            .NumPiece = NumPiece
                            .DateOp = dtPiece
                            .NomTiers = NomClient
                        End With

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
                            Dim mvt As New Ligne(p)
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .Activite = Convert.ToString(ligneDetail("NActivite"))
                                .NomProduit = NomProduit
                                .LibMvt = Left(NomClient & " " & NomProduit, 30)
                                .MontantC = MontantHT
                                .Qte1 = Qte1
                                .Qte2 = Qte2
                            End With
                            export.Lignes.Add(mvt)
                        Next

                        'CREATION DES LIGNES DE TVA
                        For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            If codeTVA.Length > 0 Then
                                If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                    'Créer le mouvement de TVA :
                                    ' MONTANT TVA AU CREDIT SUR COMPTE TVA
                                    Dim mvt As New Ligne(p)
                                    With mvt
                                        .Compte = RecapTxTVA.GetElementRecap(codeTVA).CompteTVA
                                        .LibMvt = Left(NomClient & " " & codeTVA, 30)
                                        .MontantC = Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2)
                                        .CodeTvaCompte = Left(codeTVA, 2)
                                        .MontantBaseHT = Decimal.Round(RecapTxTVA.MontantHTTaux(codeTVA), 2)
                                    End With
                                    export.Lignes.Add(mvt)
                                End If
                            End If
                        Next

                        If options.ExporterContrepartie Then
                            'ON SOLDE L'ECRITURE
                            'MONTANT TTC FACTURE AU DEBIT SUR COMPTE CLIENT
                            Dim mvtClient As New Ligne(p)
                            With mvtClient
                                .Compte = CompteClient
                                .Activite = ActiviteClient
                                .LibMvt = Left("TOTAL VENTE " & NumPiece, 30)
                                .MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)
                            End With
                            export.Lignes.Add(mvtClient)
                        End If

                        'Marquer la facture comme exportée
                        With rwFacture
                            .Item("ExportCompta") = True
                            .Item("DateExportCompta") = dtExport
                        End With

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
                            NumPiece = Integer.Parse(rwRemise.Item("nRemiseBanque"))
                        Catch ex As Exception
                        End Try
                        'On cadre le n° de piece dans la fourchette
                        NumPiece = CadreFourchette(NumPiece, CInt(BlocnPieceDebutVReglement), CInt(BlocnPieceFinVReglement))

                        Dim dtRemise As Date = CDate(rwRemise.Item("DateRemise"))
                        Dim CodeJournal As String = TrouverCodeJournal("tr", CompteBanque)
                        Dim libPiece As String = Left(String.Format("Remise {2} n°{0} du {1:dd/MM/yy}", rwRemise("nRemiseBanque"), dtRemise, rwRemise("TypeRemise")), 50)

                        'Init variables ECR 
                        Dim p As New Piece
                        With p
                            .CodeJournal = CodeJournal
                            .NumPiece = NumPiece
                            .DateOp = dtRemise
                            .NomTiers = NomBanque
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
                                    Dim mvt As New Ligne(p)
                                    With mvt
                                        .Compte = CompteClient
                                        .Activite = ActiviteClient
                                        .LibMvt = libPaiement & " " & LibPaiement2
                                        .MontantC = Decimal.Round(CDec(rwReglementDetail.Item("Montant")), 2)
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
                                            Dim mvtPP As New Ligne(p)
                                            With mvtPP
                                                .Compte = COMPTE_PERTE
                                                .LibMvt = "Arrondi de paiement perte " & NumFacture
                                                .MontantD = perte
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
                                            Dim mvtPP As New Ligne(p)
                                            With mvtPP
                                                .Compte = COMPTE_PROFIT
                                                .LibMvt = "Arrondi de paiement profit " & NumFacture
                                                .MontantC = profit
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
                                            Dim mvtEscClient As New Ligne(p)
                                            With mvtEscClient
                                                .Compte = CompteClient
                                                .Activite = ActiviteClient
                                                .LibMvt = NomClient & " escompte " & NumFacture
                                                .MontantC = MontantEscompte
                                            End With
                                            export.Lignes.Add(mvtEscClient)

                                            ' On solde les compte TVA
                                            Dim MontantEscompteTVA As Decimal = 0
                                            For Each codeTVA As String In RecapTVAEscompte.GetLstTx()
                                                If RecapTVAEscompte.MontantTVATaux(codeTVA) <> 0 Then
                                                    MontantEscompteTVA += RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                    Dim mvtEscTva As New Ligne(p)
                                                    With mvtEscTva
                                                        .Compte = RecapTVAEscompte.GetElementRecap(codeTVA).CompteTVA
                                                        .LibMvt = "REGUL. TVA ESCOMPTE " & codeTVA & " " & NumFacture
                                                        .MontantC = RecapTVAEscompte.MontantTVATaux(codeTVA)
                                                        .CodeTvaCompte = CodeTVA
                                                        .MontantBaseHT = RecapTVAEscompte.MontantHTTaux(codeTVA)
                                                    End With
                                                    export.Lignes.Add(mvtEscTva)
                                                End If
                                            Next

                                            Dim MontantEscompteHT As Decimal = MontantEscompte - MontantEscompteTVA
                                            ' on passe le montant HT de l'escompte en escompte
                                            Dim mvtEsc As New Ligne(p)
                                            With mvtEsc
                                                .Compte = COMPTE_ESCOMPTE
                                                .LibMvt = Left("Escompte Accordée " & NumFacture, 30)
                                                .MontantC = MontantEscompteHT
                                            End With
                                            export.Lignes.Add(mvtEsc)
                                        End If
                                    End If
                                End If
                            Next 'NEXT FACTURE

                            For Each codeTVA As String In GlobalRecapTxTVA.GetLstTx()
                                Dim MontantHT As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantHTTaux(codeTVA), 2)
                                Dim MontantTVA As Decimal = Decimal.Round(GlobalRecapTxTVA.MontantTVATaux(codeTVA), 2)
                                Dim MontantTTC As Decimal = Decimal.Round(MontantHT + MontantTVA, 2)

                                If TVASurEncaissement Then
                                    Dim r As ElementRecapTva = GlobalRecapTxTVA.GetElementRecap(codetva)
                                    If Not r.CompteTVA Is Nothing AndAlso r.CompteTVA.Length > 0 Then
                                        'Ligne de TVA
                                        Dim mvt As New Ligne(p)
                                        With mvt
                                            .Compte = r.CompteTVA
                                            .LibMvt = "REGUL TVA"
                                            .MontantC = MontantTVA
                                            .CodeTvaCompte = CodeTVA
                                            .MontantBaseHT = MontantHT
                                        End With
                                        export.Lignes.Add(mvt)
                                    End If
                                    Dim CodeTVAEnc As String = CodeTVAEncaissementCorrespondant(codeTVA)

                                    'Ligne de TVA
                                    Dim rwTva As DataRow = GetRowTVA(CodeTVAEnc)
                                    If Not rwTVA Is Nothing Then
                                        If Not IsDBNull(rwTva("TCpt")) Then
                                            Dim mvt As New Ligne(p)
                                            With mvt
                                                .Compte = rwTva("TCpt")
                                                .LibMvt = "REGUL TVA"
                                                .MontantD = MontantTVA
                                                .CodeTvaCompte = CodeTVAEnc
                                                .MontantBaseHT = MontantHT
                                            End With
                                            export.Lignes.Add(mvt)
                                        End If
                                    End If
                                End If
                            Next

                            'S'il reste de l'avance client :
                            If AvanceClient <> 0 Then
                                'Créer une ligne pour équilibrer la pièce vers le payeur
                                'Déterminer les informations PAYEUR
                                Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement("nEntreprise") & "'", "")(0)
                                Dim NomPayeur As String = rwEntreprise.Item("Nom").toUpper
                                Dim ComptePayeur As String = rwEntreprise.Item("NCompteC")
                                Dim ActivitePayeur As String = rwEntreprise.Item("NActiviteC")

                                Dim mvtAvance As New Ligne(p)
                                With mvtAvance
                                    .Compte = ComptePayeur
                                    .Activite = ActivitePayeur
                                    .LibMvt = "AVANCE " & NomPayeur
                                    .MontantC = AvanceClient
                                End With
                                export.Lignes.Add(mvtAvance)
                            End If

                            'Marquer le reglement comme exporté
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = Now

                        Next 'NEXT REGLEMENT

                        If options.ExporterContrepartie Then
                            'ON SOLDE LA REMISE PAR LA BANQUE
                            Dim mvtBq As New Ligne(p)
                            With mvtBq
                                .Compte = CompteBanque
                                .Activite = ActiviteBanque
                                .LibMvt = String.Format("TOTAL REMISE {0}", rwRemise("nRemiseBanque"))
                                .MontantD = Decimal.Round(CDec(rwRemise.Item("Montant")), 2)
                            End With
                            export.Lignes.Add(mvtBq)
                        End If

                        'MARQUER LA REMISE COMME EXPORTEE
                        rwRemise.Item("ExportCompta") = True
                        rwRemise.Item("DateExportCompta") = dtExport

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

#Region "EXPORT ACHATS"
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

                        'Init variables ECR
                        Dim dtFacture As Date = rwFacture("DateFacture")
                        Dim p As New Piece
                        With p
                            .CodeJournal = CodeJournal
                            .NumPiece = NumPiece
                            .DateOp = dtFacture
                            .NomTiers = NomFournisseur
                        End With

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

                            Dim mvt As New Ligne(p)
                            With mvt
                                .NomProduit = NomProduit
                                .Compte = ligneDetail("NCompte")
                                .Activite = Convert.ToString(ligneDetail("NActivite"))
                                .LibMvt = NomFournisseur & " " & NomProduit
                                .MontantD = Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2)
                                .Qte1 = Qte1
                                .Qte2 = Qte2
                            End With
                            export.Lignes.Add(mvt)
                        Next

                        'SOLDER LES CHARGES
                        If TTCCptCharge <> 0 Then
                            Dim CodeTVA As String = TrouverCodeTVA("ac", 0)
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")
                            If TVASurEncaissement = True Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                            Dim mvtTVA As New Ligne(p)
                            With mvtTVA
                                .Compte = comptetva
                                .LibMvt = String.Format("{0} TVA {1}", NomFournisseur, CodeTVA)
                                .MontantD = Decimal.Round(TVACptCharge, 2)
                                .CodeTvaCompte = CodeTVA
                                .MontantBaseHT = TTCCptCharge - TVACptCharge
                            End With
                            export.Lignes.Add(mvtTVA)

                            If options.ExporterContrepartie Then
                                Dim mvtFour As New Ligne(p)
                                With mvtFour
                                    .Compte = CompteFournisseur
                                    .Activite = ActiviteFournisseur
                                    .LibMvt = String.Format("TOTAL ACHAT {0}", NumPiece)
                                    .MontantC = Decimal.Round(TTCCptCharge, 2)
                                End With
                                export.Lignes.Add(mvtFour)
                            End If
                        End If

                        'SOLDER LES IMMOS
                        If TTCCptImmo <> 0 Then
                            Dim CodeTVA As String = TrouverCodeTVA("im", 0, "A")
                            If TVASurEncaissement = True Then CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            Dim mvtTVA As New Ligne(p)
                            With mvtTVA
                                .Compte = comptetva
                                .LibMvt = String.Format("{0} TVA {1} SUR IMMO", NomFournisseur, CodeTVA)
                                .MontantD = Decimal.Round(TVACptImmo, 2)
                                .CodeTvaCompte = CodeTVA
                                .MontantBaseHT = TTCCptImmo - TVACptImmo
                            End With
                            export.Lignes.Add(mvtTVA)

                            If options.ExporterContrepartie Then
                                Dim mvtFour As New Ligne(p)
                                With mvtFour
                                    .Compte = CompteFournisseur
                                    .Activite = ActiviteFournisseur
                                    .LibMvt = String.Format("TOTAL ACHAT IMMO {0}", NumPiece)
                                    .MontantC = Decimal.Round(TTCCptImmo, 2)
                                End With
                                export.Lignes.Add(mvtFour)
                            End If
                        End If

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
                        'Verifs avant la création de pièce
                        Dim rwFournisseur As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement.Item("nEntreprise") & "'", "")(0)
                        Dim NomFournisseur As String = rwFournisseur.Item("Nom").toUpper
                        If IsDBNull(rwFournisseur.Item("NCompteF")) Or IsDBNull(rwFournisseur.Item("NActiviteF")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If
                        'Infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")

                        'Infos banque
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

                        'Init variables ECR 
                        Dim dtReglement As Date = rwReglement("DateReglement")
                        Dim p As New Piece
                        With p
                            .CodeJournal = CodeJournal
                            .NumPiece = NumPiece
                            .DateOp = dtReglement
                            .NomTiers = NomBanque
                        End With

                        Dim Escompte As Boolean = (Not rwReglement.IsNull("TxEscompte") AndAlso rwReglement.Item("TxEscompte") <> 0)

                        'Créer la ligne du réglement
                        Dim DetailFacture As DataRow = dsAgrifact.Tables("AFacture").Select("nDevis=" & dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'")(0).Item("NFacture") & "", "")(0)
                        Dim NumFacture As Integer = DetailFacture("NFacture")
                        NumFacture = CadreFourchette(DetailFacture("NFacture"), CInt(BlocnPieceDebutAFacture), CInt(BlocnPieceFinAFacture))

                        Dim libPaiement As String = "PAIEMENT " & NumFacture & " " & rwReglement.Item("nMode") & " " & NomFournisseur

                        'MONTANT DU PAIEMENT AU DEBIT DU COMPTE FOURNISSEUR
                        Dim mvt As New Ligne(p)
                        With mvt
                            .Compte = CompteFournisseur
                            .Activite = ActiviteFournisseur
                            .LibMvt = libPaiement
                            .MontantD = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                        End With
                        export.Lignes.Add(mvt)

                        If options.ExporterContrepartie Then
                            'MONTANT DU PAIEMENT AU CREDIT DU COMPTE BANQUE
                            mvt = New Ligne(p)
                            With mvt
                                .Compte = CompteBanque
                                .Activite = ActiviteBanque
                                .LibMvt = libPaiement
                                .MontantC = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                            End With
                            export.Lignes.Add(mvt)
                        End If

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
                                Dim mvtPP As New Ligne(p)
                                With mvtPP
                                    .Compte = COMPTE_PROFIT
                                    .LibMvt = "Arrondi de paiement profit " & NumFacture
                                    .MontantC = perte
                                End With
                                export.Lignes.Add(mvtPP)
                                ' MONTANT DU PROFIT AU DEBIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Ligne(p)
                                With mvtPP
                                    .Compte = CompteFournisseur
                                    .Activite = ActiviteFournisseur
                                    .LibMvt = "Arrondi de paiement profit " & NumFacture
                                    .MontantD = perte
                                End With
                                export.Lignes.Add(mvtPP)
                                SommePayee += perte
                            End If
                        End If
                        If Not rwReglement.IsNull("Profit") Then
                            If rwReglement.Item("Profit") <> 0 Then
                                Dim profit As Decimal = Decimal.Round(CDec(rwReglement.Item("Profit")), 2)
                                'Créer le mouvement correspondant à la perte :
                                ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE PERTE
                                Dim mvtPP As New Ligne(p)
                                With mvtPP
                                    .Compte = COMPTE_PERTE
                                    .LibMvt = "Arrondi de paiement perte " & NumFacture
                                    .MontantD = profit
                                End With
                                export.Lignes.Add(mvtPP)
                                ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Ligne(p)
                                With mvtPP
                                    .Compte = CompteFournisseur
                                    .Activite = ActiviteFournisseur
                                    .LibMvt = "Arrondi de paiement perte " & NumFacture
                                    .MontantC = profit
                                End With
                                export.Lignes.Add(mvtPP)
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

                                Dim cptTVA As String = GetRowTVA(codetva)("TCpt")
                                Dim mvtTVA As New Ligne(p)
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = "REGUL. TVA " & NumFacture
                                    .MontantD = TVACptCharge
                                    .CodeTvaCompte = CodeTVA
                                    .MontantBaseHT = HTCptCharge
                                End With
                                export.Lignes.Add(mvtTVA)

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                cptTVA = GetRowTVA(codetva)("TCpt")
                                mvtTVA = New Ligne(p)
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = "REGUL. TVA " & NumFacture
                                    .MontantC = TVACptCharge
                                    .CodeTvaCompte = CodeTVA
                                    .MontantBaseHT = HTCptCharge
                                End With
                                export.Lignes.Add(mvtTVA)
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

                                Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                Dim mvtTVA As New Ligne(p)
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = "REGUL. TVA SUR IMMO " & NumFacture
                                    .MontantD = TVACptImmo
                                    .CodeTvaCompte = CodeTVA
                                    .MontantBaseHT = HTCptImmo
                                End With
                                export.Lignes.Add(mvtTVA)

                                CodeTVA = CodeTVAEncaissementCorrespondant(CodeTVA)

                                cptTVA = GetRowTVA(codetva)("TCpt")
                                mvtTVA = New Ligne(p)
                                With mvtTVA
                                    .Compte = cptTVA
                                    .LibMvt = "REGUL. TVA SUR IMMO " & NumFacture
                                    .MontantC = TVACptImmo
                                    .CodeTvaCompte = CodeTVA
                                    .MontantBaseHT = HTCptImmo
                                End With
                                export.Lignes.Add(mvtTVA)
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

                                ' On solde le compte fournisseur du montant TTC de l'escompte
                                Dim mvtEsc As New Ligne(p)
                                With mvtEsc
                                    .Compte = CompteFournisseur
                                    .Activite = ActiviteFournisseur
                                    .LibMvt = NomFournisseur & " escompte " & NumFacture
                                    .MontantD = MontantTTCAvecEscompte
                                End With
                                export.Lignes.Add(mvtEsc)

                                ' on passe le montant de l'escompte en escompte
                                mvtEsc = New Ligne(p)
                                With mvtEsc
                                    .Compte = COMPTE_ESCOMPTE_OBTENUE
                                    .LibMvt = "Escompte Obtenue " & NumFacture
                                    .MontantC = MontantHTAvecEscompte
                                End With
                                export.Lignes.Add(mvtEsc)

                                ' On solde les codes TVA
                                If MontantTVAAvecEscompteCharge <> 0 Then
                                    Dim codeTVA As String = TrouverCodeTVA("ac", 0)
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Ligne(p)
                                    With mvtEsc
                                        .Compte = cpttva
                                        .LibMvt = "REGUL. TVA ESCOMPTE " & NumFacture
                                        .MontantC = MontantTVAAvecEscompteCharge
                                    End With
                                    export.Lignes.Add(mvtEsc)
                                End If
                                If MontantTVAAvecEscompteImmo <> 0 Then
                                    Dim codeTVA As String = TrouverCodeTVA("im", 0, "A")
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Ligne(p)
                                    With mvtEsc
                                        .Compte = cpttva
                                        .LibMvt = "REGUL. TVA IMMO ESCOMPTE " & NumFacture
                                        .MontantC = MontantTVAAvecEscompteImmo
                                    End With
                                    export.Lignes.Add(mvtEsc)
                                End If
                            End If
                        End If

                        With rwReglement
                            .Item("ExportCompta") = True
                            .Item("DateExportCompta") = dtExport
                        End With

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

        Protected Overrides Sub UpdateData()
            'ENREGISTRER LE FICHIER EXPORT
            If export.Lignes.Count = 0 Then
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
        Public ModeExportation As ModeExportation = ModeExportation.Delimite
        Public TitreExport As String
        Public ExporterPieces As Boolean = True
        Public ExporterContrepartie As Boolean = True
        Public ForcerExportFullPieces As Boolean = True

        Public Sub New(ByVal ForceExportFullPiece As Boolean, Optional ByVal titre As String = "", Optional ByVal mode As Utils.ModeExportation = Utils.ModeExportation.Delimite, Optional ByVal expPieces As Boolean = True, Optional ByVal expContre As Boolean = True)
            Me.ModeExportation = mode
            Me.TitreExport = titre
            Me.ExporterPieces = expPieces
            Me.ExporterContrepartie = expContre
            ForcerExportFullPieces = ForceExportFullPiece
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

    End Class

    Friend Class Piece
        Public CodeJournal As Integer
        Public DateOp As Date
        Public NumPiece As String
        Public NomTiers As String
    End Class

    Friend Class Ligne
        Inherits ModeleExport

#Region "props"
        Public CodeJournal As Integer
        Public TypeOp As String = "STD"
        Public DateOp As Date
        Public NumPiece As String
        Public Compte As String

        Public Unite1 As String
        Public Unite2 As String
        Public CodeTvaCompte As String
        Public CodeOrigine As String = "AGRIF"

        Private _acti As String
        Public Property Activite() As String
            Get
                Return _acti
            End Get
            Set(ByVal Value As String)
                _acti = IIf(Value = "0000", "", Value)
            End Set
        End Property

        Private _NomTiers As String
        Public Property NomTiers() As String
            Get
                Return _NomTiers
            End Get
            Set(ByVal Value As String)
                _NomTiers = Left(Value, 20)
            End Set
        End Property

        Private _NomProduit As String
        Public Property NomProduit() As String
            Get
                Return _NomProduit
            End Get
            Set(ByVal Value As String)
                _NomProduit = Left(Value, 25)
            End Set
        End Property

        Private _Qte1 As Decimal
        Public Property Qte1() As Decimal
            Get
                Return _Qte1
            End Get
            Set(ByVal Value As Decimal)
                _Qte1 = Decimal.Round(Value, 2)
            End Set
        End Property

        Private _Qte2 As Decimal
        Public Property Qte2() As Decimal
            Get
                Return _Qte2
            End Get
            Set(ByVal Value As Decimal)
                _Qte2 = Decimal.Round(Value, 2)
            End Set
        End Property

        Private _LibMvt As String
        Public Property LibMvt() As String
            Get
                Return _LibMvt
            End Get
            Set(ByVal Value As String)
                _LibMvt = Left(Value, 25)
            End Set
        End Property

        Private _MontantD As Decimal
        Public Property MontantD() As Decimal
            Get
                Return _MontantD
            End Get
            Set(ByVal Value As Decimal)
                _MontantD = Decimal.Round(Value, 2)
            End Set
        End Property

        Private _MontantC As Decimal
        Public Property MontantC() As Decimal
            Get
                Return _MontantC
            End Get
            Set(ByVal Value As Decimal)
                _MontantC = Decimal.Round(Value, 2)
            End Set
        End Property

        Private _MontantBaseHT As Decimal
        Public Property MontantBaseHT() As Decimal
            Get
                Return _MontantBaseHT
            End Get
            Set(ByVal Value As Decimal)
                _MontantBaseHT = Decimal.Round(Value, 2)
            End Set
        End Property

#End Region

#Region "ctor"
        Public Sub New(ByVal CodeJournal As Integer, ByVal NumPiece As String, ByVal DateOp As String, ByVal NomTiers As String)
            Me.CodeJournal = CodeJournal
            Me.NumPiece = NumPiece
            Me.DateOp = DateOp
            Me.NomTiers = NomTiers
        End Sub

        Public Sub New(ByVal p As Piece)
            Me.New(p.CodeJournal, p.NumPiece, p.DateOp, p.NomTiers)
        End Sub

#End Region

#Region "overrides"
        Public Overrides Function GetFormat() As String
            Return ""
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {CodeJournal, TypeOp, DateOp, NumPiece, NomTiers, "", Compte, Activite, "", NomProduit, Qte1, Unite1, Qte2, Unite2, "", "", _
                                DateOp, LibMvt, MontantD, MontantC, "", MontantBaseHT, "", CodeTvaCompte, "", "", "", "", CodeOrigine}
        End Function
#End Region
    End Class
#End Region
End Namespace