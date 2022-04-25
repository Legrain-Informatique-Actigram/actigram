Namespace Epicea
    Public Class ExportEpicea
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
            'TODO VOIR SI ON PEUT DEFINIR LE REPERTOIRE (Emplacement: répertoire contenant les données du dossier comptable)
            Return "E2-IMPOR.TXT"
        End Function

        Public Overrides Sub ChargerDonnees(ByVal sqlConnString As String)
            If options Is Nothing Then options = New OptionsExport("Test d'export au format EPICEA", True, IIf(Me.TVASurEncaissement, OptionTVA.E, OptionTVA.D))

            MyBase.ChargerDonnees(sqlConnString)
            'Charger les infos compta dans la base agrifact
            InitAgrifactDta("TVA", dsAgrifact, False)

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

        Private Sub VerifExistenceTVA(ByVal codeTVA As String)
            If GetRowTVA(codeTVA) Is Nothing Then
                Throw New WarningExport(String.Format("Le code TVA '{0}' n'existe pas.", codeTVA))
            End If
        End Sub

#Region "EXPORT VENTE"
        Protected Overrides Function ExporterFactures() As Boolean
            ' FACTURE DE VENTE
            If VFacture Then
                ReportProgress(0, "Exportation des Factures de vente")
                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebVFacture, DateFinVFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("VFacture").Select(strFiltre, "nFacture")
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
                        'If IsDBNull(rwEntreprise.Item("NCompteC")) OrElse IsDBNull(rwEntreprise.Item("NActiviteC")) _
                        'OrElse CStr(rwEntreprise.Item("NCompteC")).Length = 0 OrElse CStr(rwEntreprise.Item("NActiviteC")).Length = 0 Then
                        'Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le client {0}", NomClient))
                        'End If
                        'legrain 27/01/2014
                        If IsDBNull(rwEntreprise.Item("NCompteC")) _
                        OrElse CStr(rwEntreprise.Item("NCompteC")).Length = 0 Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le client {0}", NomClient))
                        End If
                        'Trouver les infos du client de la facture
                        Dim CompteClient As String = rwEntreprise("NCompteC")
                        'Dim ActiviteClient As String = rwEntreprise("NActiviteC")
                        Dim ActiviteClient As String = "0"

                        For Each ligneDetail As DataRow In dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit not is null And Codeproduit<>''", "nLigne")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            'If IsDBNull(ligneDetail.Item("NCompte")) OrElse IsDBNull(ligneDetail.Item("NActivite")) _
                            'OrElse CStr(ligneDetail.Item("NCompte")).Length = 0 OrElse CStr(ligneDetail.Item("NActivite")).Length = 0 Then
                            'Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le produit {0} dans la facture {1} du {2:dd/MM/yy}", NomProduit, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture")))
                            'End If
                            If IsDBNull(ligneDetail.Item("NCompte")) _
                            OrElse CStr(ligneDetail.Item("NCompte")).Length = 0 Then
                                Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le produit {0} dans la facture {1} du {2:dd/MM/yy}", NomProduit, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture")))
                            End If

                            'Vérif TVA
                            If Not IsDBNull(ligneDetail.Item("TTVA")) AndAlso ligneDetail.Item("TTVA") <> "" Then
                                Dim CodeTva As String = CStr(ligneDetail.Item("TTVA"))
                                VerifExistenceTVA(CodeTva)
                            End If
                        Next

                        'Déterminer le n° de la pièce à utiliser pour la facture
                        Dim NumPiece As Integer
                        If Not IsNumeric(BlocnPieceDebutVFacture) Then BlocnPieceDebutVFacture = 50000
                        If Not IsNumeric(BlocnPieceFinVFacture) Then BlocnPieceFinVFacture = 80000
                        NumPiece = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))

                        'Dim libPiece As String = Left(String.Format("Vente {0} du {1:dd/MM/yy}: {2}", rwFacture("nFacture"), rwFacture("DateFacture"), rwEntreprise("Nom")), 50)

                        'Init variables ECR 
                        Dim dtPiece As Date = rwFacture("DateFacture")
                        Dim p As New Piece(export)
                        With p
                            .Type = TypePiece.V
                            .RefPiece = String.Format("FA{0:0000000}", NumPiece)
                            .DatePiece = dtPiece
                        End With

                        'MONTANT TTC FACTURE AU DEBIT SUR COMPTE CLIENT
                        Dim mvtClient As New Ligne(p, Me.options)

                        
                        'legrain 28/03/2014 ajout du if
                        If CBool(rwFacture("FacturationTTC")) Then
                            '
                            '
                            'Si saisie TTC
                            'Calculer le total des TTC des lignes pour chaque code TVA, puis à partir de ce montant, calculer le montant des TVA
                            'Pour chaque ligne, on peu prendre le HT qui est dans la table
                            'Faire un controle de correspondance entre le HT global et le total des HT des lignes
                            'Si différences de quelques centimes, répercuter cette différence sur le HT de 1 lignes
                            '
                            '

                            With mvtClient
                                If Not codeTiersEnabled OrElse IsDBNull(rwEntreprise("CodeTiers")) Then
                                    .Compte = CompteClient
                                Else
                                    .Compte = Convert.ToString(rwEntreprise("CodeTiers"))
                                    .CompteTiers = CompteClient
                                    .NomTiers = NomClient
                                    .AdresseTiers = Convert.ToString(rwEntreprise("Adresse"))
                                    .CpTiers = Convert.ToString(rwEntreprise("CodePostal"))
                                    .VilleTiers = Convert.ToString(rwEntreprise("Ville"))
                                End If
                                .LibMvt = Left("TOTAL VENTE " & NumPiece, 30)
                                '.MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)
                                'legrain 17/03/2014
                                .MontantD = 0
                                p.Equilibre += .MontantD

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

                                'legrain 17/03/2014
                                mvtClient.MontantD += MontantHT
                                'p.Equilibre += MontantHT

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
                                Dim mvt As New Ligne(p, Me.options)
                                With mvt
                                    .Compte = ligneDetail("NCompte")

                                    'legrain 17/03/2014
                                    '.LibMvt = Left(NomClient & " " & NomProduit, 30)
                                    .LibMvt = ligneDetail("Libelle")

                                    .MontantC = MontantHT
                                    p.Equilibre -= .MontantC
                                    .Qte1 = Qte1
                                    .Qte2 = Qte2
                                    .CodeTvaCompte = CodeTVA
                                    .TauxTVA = TauxTva
                                End With
                                export.Lignes.Add(mvt)
                                'On retient une référence à la dernière ligne utilisant ce code TVA
                                If LignesTVA.ContainsKey(CodeTVA) Then
                                    LignesTVA.Item(CodeTVA) = mvt
                                Else
                                    LignesTVA.Add(CodeTVA, mvt)
                                End If
                            Next

                            'CREATION DES LIGNES DE TVA
                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                If codeTVA.Length > 0 Then
                                    If LignesTVA.ContainsKey(codeTVA) Then
                                        If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                            'Ecrire la TVA sur la dernière ligne correspondant au code :
                                            ' MONTANT TVA AU CREDIT
                                            Dim mvt As Ligne = LignesTVA(codeTVA)

                                            'mvt.MtTVAC = Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2)
                                            'legrain 17/03/2014
                                            'mvt.MtTVAC = Decimal.Round(RecapTxTVA.MontantHTTaux(codeTVA) * RecapTxTVA.TxTVA(codeTVA) / 100, 2)
                                            mvt.MtTVAC = Decimal.Round((RecapTxTVA.MontantTTCTaux(codeTVA) / (1 + RecapTxTVA.TxTVA(codeTVA) / 100)) * (RecapTxTVA.TxTVA(codeTVA) / 100), 2)
                                            mvtClient.MontantD += mvt.MtTVAC

                                            p.Equilibre -= mvt.MtTVAC
                                        End If
                                    End If
                                End If
                            Next

                            'legrain 17/03/2014
                            'mvtClient.MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)

                            ''legrain 17/03/2014
                            'If p.Equilibre <> 0 Then
                            ''If p.Equilibre <> Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2) Then
                            ''If Math.Abs(p.Equilibre) <> mvtClient.MontantD Then
                            ''La piece n'est pas equilibrée
                            'export.RemoveLinesByNPiece(p.NPiece)
                            'Throw New WarningExport(String.Format("La piece facture de vente {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.NPiece, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture"), Math.Abs(p.Equilibre)))
                            'End If

                        Else

                            'FACTURE SAISIE EN HT
                            With mvtClient
                                If Not codeTiersEnabled OrElse IsDBNull(rwEntreprise("CodeTiers")) Then
                                    .Compte = CompteClient
                                Else
                                    .Compte = Convert.ToString(rwEntreprise("CodeTiers"))
                                    .CompteTiers = CompteClient
                                    .NomTiers = NomClient
                                    .AdresseTiers = Convert.ToString(rwEntreprise("Adresse"))
                                    .CpTiers = Convert.ToString(rwEntreprise("CodePostal"))
                                    .VilleTiers = Convert.ToString(rwEntreprise("Ville"))
                                End If
                                .LibMvt = Left("TOTAL VENTE " & NumPiece, 30)
                                '.MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)
                                'legrain 17/03/2014
                                .MontantD = 0
                                p.Equilibre += .MontantD

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

                                'legrain 17/03/2014
                                mvtClient.MontantD += MontantHT
                                'p.Equilibre += MontantHT

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
                                Dim mvt As New Ligne(p, Me.options)
                                With mvt
                                    .Compte = ligneDetail("NCompte")

                                    'legrain 17/03/2014
                                    '.LibMvt = Left(NomClient & " " & NomProduit, 30)
                                    .LibMvt = ligneDetail("Libelle")

                                    .MontantC = MontantHT
                                    p.Equilibre -= .MontantC
                                    .Qte1 = Qte1
                                    .Qte2 = Qte2
                                    .CodeTvaCompte = CodeTVA
                                    .TauxTVA = TauxTva
                                End With
                                export.Lignes.Add(mvt)
                                'On retient une référence à la dernière ligne utilisant ce code TVA
                                If LignesTVA.ContainsKey(CodeTVA) Then
                                    LignesTVA.Item(CodeTVA) = mvt
                                Else
                                    LignesTVA.Add(CodeTVA, mvt)
                                End If
                            Next

                            'CREATION DES LIGNES DE TVA
                            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                                If codeTVA.Length > 0 Then
                                    If LignesTVA.ContainsKey(codeTVA) Then
                                        If RecapTxTVA.GetElementRecap(codeTVA).CompteTVA.Length > 0 Then
                                            'Ecrire la TVA sur la dernière ligne correspondant au code :
                                            ' MONTANT TVA AU CREDIT
                                            Dim mvt As Ligne = LignesTVA(codeTVA)

                                            'mvt.MtTVAC = Decimal.Round(RecapTxTVA.MontantTVATaux(codeTVA), 2)
                                            'legrain 17/03/2014
                                            mvt.MtTVAC = Decimal.Round(RecapTxTVA.MontantHTTaux(codeTVA) * RecapTxTVA.TxTVA(codeTVA) / 100, 2)
                                            mvtClient.MontantD += mvt.MtTVAC

                                            p.Equilibre -= mvt.MtTVAC
                                        End If
                                    End If
                                End If
                            Next

                            'legrain 17/03/2014
                            'mvtClient.MontantD = Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2)

                            ''legrain 17/03/2014
                            'If p.Equilibre <> 0 Then
                            ''If p.Equilibre <> Decimal.Round(CDec(rwFacture.Item("MontantTTC")), 2) Then
                            ''If Math.Abs(p.Equilibre) <> mvtClient.MontantD Then
                            ''La piece n'est pas equilibrée
                            'export.RemoveLinesByNPiece(p.NPiece)
                            'Throw New WarningExport(String.Format("La piece facture de vente {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.NPiece, rwFacture.Item("nFacture"), rwFacture.Item("DateFacture"), Math.Abs(p.Equilibre)))
                            'End If

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
                        'If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                        ' Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        'End If
                        'legrain 27/01/2014
                        If IsDBNull(rwBanque.Item("NCompte")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If
                        'Infos banque
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        'Dim ActiviteBanque As String = rwBanque.Item("NActivite")
                        Dim ActiviteBanque As String = "0"

                        For Each ligneDetailRemise As DataRow In dsAgrifact.Tables("Remise_Detail").Select("nRemise='" & rwRemise.Item("nRemise") & "'", "nDetailRemise")
                            For Each rwReglementDetail As DataRow In dsAgrifact.Tables("Reglement_detail").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")
                                Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)
                                Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement.Item("nEntreprise") & "'", "")(0)
                                Dim NomClient As String = rwEntreprise.Item("Nom").toUpper
                                'If IsDBNull(rwEntreprise.Item("NCompteC")) Or IsDBNull(rwEntreprise.Item("NActiviteC")) Then
                                'Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le client {0}", NomClient))
                                'End If
                                'legrain 27/01/2014
                                If IsDBNull(rwEntreprise.Item("NCompteC")) Then
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
                        'S'il n'y en a pas, on prend le nRemise
                        If NumPiece = 0 Then NumPiece = rwRemise.Item("nRemise")

                        'On cadre le n° de piece dans la fourchette
                        'NumPiece = CadreFourchette(NumPiece, CInt(BlocnPieceDebutVReglement), CInt(BlocnPieceFinVReglement))

                        Dim dtRemise As Date = CDate(rwRemise.Item("DateRemise"))
                        'Dim libPiece As String = Left(String.Format("Remise {2} n°{0} du {1:dd/MM/yy}", rwRemise("nRemiseBanque"), dtRemise, rwRemise("TypeRemise")), 50)

                        'Init variables ECR 
                        Dim p As New Piece(export)
                        With p
                            .Type = TypePiece.T
                            .RefPiece = "" 'String.Format("RE{0}", NumPiece)
                            .DatePiece = dtRemise
                        End With

                        'MONTANT DE LA REMISE AU DEBIT DE LA BANQUE
                        Dim mvtBq As New Ligne(p, Me.options)
                        With mvtBq
                            .Compte = CompteBanque
                            .LibMvt = String.Format("TOTAL REMISE {0}", rwRemise("nRemiseBanque"))
                            .MontantD = Decimal.Round(CDec(rwRemise.Item("Montant")), 2)
                            p.Equilibre += .MontantD
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
                            'legrain 21/03/2014
                            'For Each rwReglementDetail As DataRow In rwDetailReglements
                            'AvanceClient -= CDec(ReplaceDbNull(rwReglementDetail("Montant"), 0))

                            'legrain 21/03/2014
                            'If Not IsDBNull(rwReglementDetail.Item("nFacture")) Then
                            Dim RecapTVAEscompte As New RecapTVA
                            Dim RecapTxTVA As New RecapTVA
                            Dim SoldeFacture As Boolean = False

                            'legrain 21/03/2014
                            'Dim nDevis As Long = rwReglementDetail.Item("nFacture")
                            'Dim rwFacture As DataRow = dsAgrifact.Tables("VFacture").Select("nDevis=" & nDevis)(0)
                            'Dim NumFacture As Integer = CadreFourchette(rwFacture.Item("nFacture"), CInt(BlocnPieceDebutVFacture), CInt(BlocnPieceFinVFacture))

                            'Déterminer les informations CLIENT
                            'legrain 21/03/2014
                            'Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwFacture.Item("nClient") & "'", "")(0)
                            Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement.Item("nEntreprise") & "'", "")(0)
                            Dim NomClient As String = rwEntreprise.Item("Nom").toUpper
                            Dim CompteClient As String = rwEntreprise.Item("NCompteC")
                            'legrain 27/01/2014
                            'Dim ActiviteClient As String = rwEntreprise.Item("NActiviteC")
                            Dim ActiviteClient As String = "0"

                            'Créer les lignes pour le réglement
                            'legrain 21/03/2014
                            'Dim libPaiement As String = NumFacture & " " & rwReglement.Item("nMode")
                            Dim libPaiement As String = rwReglement.Item("nMode") & " " & rwReglement.Item("Observation")
                            Dim LibPaiement2 As String = NomClient

                            'Créer le mouvement correspondant à la ligne de réglement :
                            ' MONTANT DU REGLEMENT AU CREDIT SUR COMPTE CLIENT
                            Dim mvt As New Ligne(p, Me.options)
                            With mvt
                                If Not codeTiersEnabled OrElse IsDBNull(rwEntreprise("CodeTiers")) Then
                                    .Compte = CompteClient
                                Else
                                    .Compte = Convert.ToString(rwEntreprise("CodeTiers"))
                                    .CompteTiers = CompteClient
                                    .NomTiers = NomClient
                                    .AdresseTiers = Convert.ToString(rwEntreprise("Adresse"))
                                    .CpTiers = Convert.ToString(rwEntreprise("CodePostal"))
                                    .VilleTiers = Convert.ToString(rwEntreprise("Ville"))
                                End If
                                .LibMvt = libPaiement & " " & LibPaiement2

                                'legrain 21/03/2014
                                '.MontantC = Decimal.Round(CDec(rwReglementDetail.Item("Montant")), 2)
                                .MontantC = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)

                                p.Equilibre -= .MontantC
                            End With
                            export.Lignes.Add(mvt)

                            'legrain 21/03/2014
                            '    ' CALCUL DES SOMMES REGLEES ET DUES POUR LA FACTURE
                            '    Dim SommeDue As Decimal = 0
                            '    Dim SommePayee As Decimal = 0
                            '    Dim SommeDejaPayee As Decimal = 0
                            '    Dim MontantEscompte As Decimal = 0
                            '    Dim ratioPaye As Decimal = 1

                            '    With dsAgrifact.Tables("FactureMontantExport")
                            '        Dim obj As Object = .Compute("Sum(MontantTTC)", "nDevis=" & nDevis & "")
                            '        If Not IsDBNull(obj) Then SommeDejaPayee = Decimal.Round(CDec(obj), 2)
                            '    End With

                            '    SommePayee = CDec(rwReglementDetail.Item("Montant"))
                            '    'TODO A REMETTRE QUAND ON AURA GERE L'ESCOMPTE
                            '    'If Not IsDBNull(rwReglementDetail.Item("MtEscompte")) Then
                            '    '    MontantEscompte = CDec(rwReglementDetail.Item("MtEscompte"))
                            '    'End If
                            '    'MontantTotalEscompte += MontantEscompte
                            '    SommeDue = CDec(rwFacture.Item("MontantTTC")) - MontantEscompte

                            '    'rwEscompte = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetail.Item("nReglement") & "'", "nReglement")(0)
                            '    'Cherche si le réglement à une escompte

                            '    'If Not IsDBNull(rwReglement.Item("TxEscompte")) And Not passEscompte Then
                            '    '    rwEscompte = rwReglement
                            '    '    If rwReglement.Item("TxEscompte") <> 0 Then
                            '    '        SommeDue -= Decimal.Round(CDec(rwReglement.Item("MontantEscompte")), 2)
                            '    '    End If
                            '    '    passEscompte = True
                            '    'End If


                            '    '' GESTION DES PERTES ET PROFIT
                            '    If Not IsDBNull(rwReglementDetail.Item("Perte")) Then
                            '        If rwReglementDetail.Item("Perte") <> 0 Then
                            '            Dim perte As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Perte")), 2)
                            '            'Créer le mouvement correspondant à la perte :
                            '            ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE PERTE
                            '            Dim mvtPP As New Ligne(p, Me.options)
                            '            With mvtPP
                            '                .Compte = COMPTE_PERTE
                            '                .LibMvt = "Arrondi de paiement perte " & NumFacture
                            '                .MontantD = perte
                            '                p.Equilibre += .MontantD
                            '            End With
                            '            export.Lignes.Add(mvtPP)
                            '            SommePayee += perte
                            '        End If
                            '    End If
                            '    If Not IsDBNull(rwReglementDetail.Item("Profit")) Then
                            '        If rwReglementDetail.Item("Profit") <> 0 Then
                            '            Dim profit As Decimal = Decimal.Round(CDec(rwReglementDetail.Item("Profit")), 2)
                            '            'Créer le mouvement correspondant au profit :
                            '            ' MONTANT DU POFIT AU DEBIT SUR COMPTE PROFIT
                            '            Dim mvtPP As New Ligne(p, Me.options)
                            '            With mvtPP
                            '                .Compte = COMPTE_PROFIT
                            '                .LibMvt = "Arrondi de paiement profit " & NumFacture
                            '                .MontantC = profit
                            '                p.Equilibre -= .MontantC
                            '            End With
                            '            export.Lignes.Add(mvtPP)
                            '            SommePayee -= profit
                            '        End If
                            '    End If

                            '    If SommeDue <> SommePayee Then
                            '        If Math.Abs(SommeDejaPayee + SommePayee - SommeDue) <= 0.02 Then ' ON EST OBLIGE AFIN DE POUVOIR SOLDER LA FACTURE CF lUDO
                            '            SoldeFacture = True
                            '            ratioPaye = 1 'Dans ce cas on prend 100% du HT, on retranchera ensuite le déjà payé
                            '        Else
                            '            ratioPaye = SommePayee / SommeDue
                            '        End If
                            '    End If

                            '    'Faire un récap de la TVA de la facture
                            '    If TVASurEncaissement OrElse MontantEscompte <> 0 Then
                            '        Dim rwFacturesDetail() As DataRow = dsAgrifact.Tables("VFacture_Detail").Select("nDevis='" & nDevis & "' And CodeProduit not is null And Codeproduit<>''", "nDevis")
                            '        For Each rwFactureDetail As DataRow In rwFacturesDetail
                            '            ' Génération des comptes TVA si nécessaire
                            '            Dim CodeTVA As String = Convert.ToString(rwFactureDetail("TTVA"))
                            '            Dim TauxTva As Decimal = 0

                            '            If CodeTVA.Length > 0 Then
                            '                Dim rwTVA As DataRow = GetRowTVA(CodeTVA)
                            '                If Not rwTVA Is Nothing Then
                            '                    TauxTva = ReplaceDbNull(rwTVA.Item("TTaux"), 0)
                            '                    If Convert.ToString(rwTVA("TCpt")).Length > 0 Then
                            '                        RecapTxTVA.SetCompte(CodeTVA, Convert.ToString(rwTVA("TCpt")), TauxTva)
                            '                    End If
                            '                End If
                            '            End If

                            '            'stocker pour chacun des codes TVA présents le montant d'HT qui va être payé par la facture
                            '            'TODO : ON NE GERE COMPLETEMENT PAS LA TVA RPCH
                            '            If Not IsDBNull(rwFactureDetail("MontantLigneHt")) Then
                            '                RecapTxTVA.AddMontant(CodeTVA, TauxTva, Decimal.Round((rwFactureDetail("MontantLigneHt") * ratioPaye), 2), 0)
                            '            End If
                            '        Next

                            '        'Si le réglement solde la facture alors on retranche le déjà payé
                            '        If SoldeFacture Then
                            '            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            '                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                            '                Dim rwDejaPayeeII() As DataRow = dsAgrifact.Tables("factureMontantExport").Select("nDevis='" & nDevis & "' And TTVA='" & codeTVA.Replace("'", "''") & "'", "nDevis")
                            '                For Each rwDejapayee As DataRow In rwDejaPayeeII
                            '                    With rwDejapayee
                            '                        elRecap.MontantHT -= .Item("MontantHT")
                            '                        elRecap.MontantTVA -= .Item("MontantTVA")
                            '                        elRecap.MontantTTC -= .Item("MontantTTC")
                            '                    End With
                            '                Next
                            '            Next
                            '        End If

                            '        'Calculer la répartition de l'escompte par code TVA
                            '        If MontantEscompte <> 0 Then
                            '            For Each codeTVA As String In RecapTxTVA.GetLstTx()
                            '                Dim elRecap As ElementRecapTva = RecapTxTVA.GetElementRecap(codeTVA)
                            '                Dim partEscompte As Decimal = MontantEscompte * elRecap.MontantTTC / SommePayee
                            '                RecapTVAEscompte.AddMontant(codeTVA, RecapTxTVA.TxTVA(codeTVA), 0, partEscompte)
                            '            Next
                            '        End If

                            '        If MontantEscompte <> 0 Then
                            '            'TODO REMONTER CA A CHAQUE FACTURE
                            '            ' On solde le compte client du montant TTC de l'escompte au débit
                            '            Dim mvtEscClient As New Ligne(p, Me.options)
                            '            With mvtEscClient
                            '                If Not codeTiersEnabled OrElse IsDBNull(rwEntreprise("CodeTiers")) Then
                            '                    .Compte = CompteClient
                            '                Else
                            '                    .Compte = Convert.ToString(rwEntreprise("CodeTiers"))
                            '                    .CompteTiers = CompteClient
                            '                    .NomTiers = NomClient
                            '                    .AdresseTiers = Convert.ToString(rwEntreprise("Adresse"))
                            '                    .CpTiers = Convert.ToString(rwEntreprise("CodePostal"))
                            '                    .VilleTiers = Convert.ToString(rwEntreprise("Ville"))
                            '                End If
                            '                .LibMvt = NomClient & " escompte " & NumFacture
                            '                .MontantC = MontantEscompte
                            '                p.Equilibre -= .MontantC
                            '            End With
                            '            export.Lignes.Add(mvtEscClient)

                            '            ' On solde les compte TVA
                            '            Dim MontantEscompteTVA As Decimal = 0
                            '            For Each codeTVA As String In RecapTVAEscompte.GetLstTx()
                            '                If RecapTVAEscompte.MontantTVATaux(codeTVA) <> 0 Then
                            '                    MontantEscompteTVA += RecapTVAEscompte.MontantTVATaux(codeTVA)
                            '                    Dim mvtEscTva As New Ligne(p, Me.options)
                            '                    With mvtEscTva
                            '                        .Compte = RecapTVAEscompte.GetElementRecap(codeTVA).CompteTVA
                            '                        .LibMvt = "REGUL. TVA ESCOMPTE " & codeTVA & " " & NumFacture
                            '                        .MontantC = 0 'RecapTVAEscompte.MontantHTTaux(codeTVA)
                            '                        .MtTVAC = RecapTVAEscompte.MontantTVATaux(codeTVA)
                            '                        .CodeTvaCompte = codeTVA
                            '                        p.Equilibre -= .MtTVAC
                            '                    End With
                            '                    export.Lignes.Add(mvtEscTva)
                            '                End If
                            '            Next

                            '            Dim MontantEscompteHT As Decimal = MontantEscompte - MontantEscompteTVA
                            '            ' on passe le montant HT de l'escompte en escompte
                            '            Dim mvtEsc As New Ligne(p, Me.options)
                            '            With mvtEsc
                            '                .Compte = COMPTE_ESCOMPTE
                            '                .LibMvt = Left("Escompte Accordée " & NumFacture, 30)
                            '                .MontantC = MontantEscompteHT
                            '                p.Equilibre -= .MontantC
                            '            End With
                            '            export.Lignes.Add(mvtEsc)
                            '        End If
                            '    End If
                            'End If
                        Next 'NEXT FACTURE

                        'legrain 21/03/2014
                        ''S'il reste de l'avance client :
                        'If AvanceClient <> 0 Then
                        '    'Créer une ligne pour équilibrer la pièce vers le payeur
                        '    'Déterminer les informations PAYEUR
                        '    Dim rwEntreprise As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwReglement("nEntreprise") & "'", "")(0)
                        '    Dim NomPayeur As String = rwEntreprise.Item("Nom").toUpper
                        '    Dim ComptePayeur As String = rwEntreprise.Item("NCompteC")

                        '    Dim mvtAvance As New Ligne(p, Me.options)
                        '    With mvtAvance
                        '        .Compte = ComptePayeur
                        '        .LibMvt = Left("AVANCE " & NomPayeur, 30)
                        '        .MontantC = AvanceClient
                        '        p.Equilibre -= .MontantC
                        '    End With
                        '    export.Lignes.Add(mvtAvance)
                        'End If

                        'Next 'NEXT REGLEMENT

                        If p.Equilibre <> 0 Then
                            'La piece n'est pas equilibrée
                            export.RemoveLinesByNPiece(p.NPiece)
                            Throw New WarningExport(String.Format("La Piece {0} générée à partir de la Remise de Vente {1} du {2:dd/MM/yy} est déséquilibrée de {3} Euro", p.RefPiece, NumPiece, rwRemise.Item("DateRemise"), Math.Abs(p.Equilibre)))
                        End If

                        'MARQUER LA REMISE COMME EXPORTEE
                        rwRemise.Item("ExportCompta") = True
                        rwRemise.Item("DateExportCompta") = dtExport

                        'POUR CHAQUE REGLEMENT DE LA REMISE
                        For Each ligneDetailRemise As DataRow In lignesDetailRemise
                            Dim rwReglement As DataRow = dsAgrifact.Tables("Reglement").Select("nReglement='" & ligneDetailRemise.Item("nReglement") & "'", "nReglement")(0)
                            rwReglement.Item("ExportCompta") = True
                            rwReglement.Item("DateExportCompta") = Now
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
                Dim CodeTVAAchat As String = "B"
                Dim CodeTVAAchatImmo As String = "I"

                Dim strFiltre As String = String.Format("(ExportCompta=0 or ExportCompta is null) and (DateFacture>='{0}' and DateFacture<='{1}')", DateDebAFacture, DateFinAFacture)
                Dim rwFacturesAExporter() As DataRow = dsAgrifact.Tables("AFacture").Select(strFiltre, "nFacture")
                Dim hasCodeTiersEnabled As Boolean = dsAgrifact.Tables("Entreprise").Columns.Contains("CodeTiers")
                Dim i As Integer = 0
                For Each rwFacture As DataRow In rwFacturesAExporter
                    Try
                        'Verifs avant la création de pièce
                        Dim rwFournisseur As DataRow = dsAgrifact.Tables("Entreprise").Select("nEntreprise='" & rwFacture.Item("nClient") & "'", "")(0)
                        Dim NomFournisseur As String = rwFournisseur.Item("Nom").toUpper
                        'If IsDBNull(rwFournisseur.Item("NCompteF")) OrElse IsDBNull(rwFournisseur.Item("NActiviteF")) _
                        'OrElse CStr(rwFournisseur.Item("NCompteF")).Length = 0 OrElse CStr(rwFournisseur.Item("NActiviteF")).Length = 0 Then
                        'Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        'End If
                        'legrain 27/01/2014
                        If IsDBNull(rwFournisseur.Item("NCompteF")) _
                       OrElse CStr(rwFournisseur.Item("NCompteF")).Length = 0 Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If
                        'Récupération des infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        'Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")
                        Dim ActiviteFournisseur As String = "0"

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
                        Dim p As New Piece(export)
                        With p
                            .Type = TypePiece.A
                            .RefPiece = String.Format("FA{0:0000000}", NumPiece)
                            .DatePiece = dtFacture
                            .nbLigne = 1 'Pour pouvoir insérer la ligne de fournisseur en premier
                        End With

                        Dim Ligne As Integer = 0
                        Dim lignesDetailFacture() As DataRow = dsAgrifact.Tables("AFacture_Detail").Select("nDevis='" & rwFacture.Item("nDevis") & "' And CodeProduit is not null And Codeproduit<>''", "nLigne")
                        Dim TVACptCharge As Decimal = 0
                        Dim TTCCptCharge As Decimal = 0
                        Dim TVACptImmo As Decimal = 0
                        Dim TTCCptImmo As Decimal = 0
                        Dim lignesTVA As New Hashtable
                        For Each ligneDetail As DataRow In lignesDetailFacture
                            Dim CompteProduit As String = ligneDetail("NCompte")
                            Dim CodeTVA As String
                            Select Case CompteProduit.Substring(0, 1)
                                Case "1" 'Pour gérer les comptes 1013 de parts sociales
                                    CodeTVA = ""
                                    TTCCptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case "6" 'ACHAT NORMAL
                                    CodeTVA = CodeTVAAchat
                                    TVACptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTVA"), 0), 2)
                                    TTCCptCharge += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case "2" 'ACHAT D'IMMO                                
                                    CodeTVA = CodeTVAAchatImmo
                                    TVACptImmo += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTVA"), 0), 2)
                                    TTCCptImmo += Decimal.Round(ReplaceDbNull(ligneDetail.Item("MontantLigneTTC"), 0), 2)
                                Case Else
                                    Throw New WarningExport(String.Format("Erreur. Pièce {0} du {1:dd/MM/yy}. Compte produit incorrect {2}: Le compte doit être en 1,2 ou 6", NumPiece, rwFacture.Item("DateFacture"), CompteProduit))
                                    Return False
                            End Select

                            'Informations produit pour création du compte Produit
                            Dim Unite1 As String = ReplaceDbNull(ligneDetail.Item("LibUnite1"), "")
                            Dim Unite2 As String = ReplaceDbNull(ligneDetail.Item("LibUnite2"), "")
                            Dim NomProduit As String = ligneDetail.Item("CodeProduit").toUpper
                            Dim Qte1 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite1"), 0)), 2)
                            Dim Qte2 As Decimal = Decimal.Round(CDec(ReplaceDbNull(ligneDetail.Item("Unite2"), 0)), 2)

                            Dim mvt As New Ligne(p, options)
                            With mvt
                                .Compte = ligneDetail("NCompte")
                                .LibMvt = NomFournisseur & " " & NomProduit
                                .MontantD = Decimal.Round(CDec(ligneDetail.Item("MontantLigneHT")), 2)
                                .CodeTvaCompte = CodeTVA
                                .Qte1 = Qte1
                                .Qte2 = Qte2
                            End With
                            export.Lignes.Add(mvt)
                            'On retient une référence à la dernière ligne utilisant ce code TVA
                            If lignesTVA.ContainsKey(CodeTVA) Then
                                lignesTVA.Item(CodeTVA) = mvt
                            Else
                                lignesTVA.Add(CodeTVA, mvt)
                            End If
                        Next

                        'SOLDER LES CHARGES
                        Dim ligneFourInserted As Boolean = False
                        If TTCCptCharge <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchat
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            If lignesTVA.ContainsKey(CodeTVA) Then
                                CType(lignesTVA(CodeTVA), Ligne).MtTVAD = Decimal.Round(TVACptCharge, 2)
                            End If

                            Dim mvtFour As New Ligne(p, options)
                            With mvtFour
                                .NLigne = 1
                                If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                    .Compte = CompteFournisseur
                                Else
                                    .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                    .CompteTiers = CompteFournisseur
                                    .NomTiers = NomFournisseur
                                    .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                    .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                    .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                                End If
                                .LibMvt = String.Format("TOTAL ACHAT {0}", NumPiece)
                                .MontantC = Decimal.Round(TTCCptCharge, 2)
                            End With
                            export.Lignes.Insert(0, mvtFour)
                            ligneFourInserted = True
                        End If

                        'SOLDER LES IMMOS
                        If TTCCptImmo <> 0 Then
                            Dim CodeTVA As String = CodeTVAAchatImmo
                            Dim CompteTva As String = GetRowTVA(CodeTVA)("TCpt")

                            If lignesTVA.ContainsKey(CodeTVA) Then
                                CType(lignesTVA(CodeTVA), Ligne).MtTVAD = Decimal.Round(TVACptImmo, 2)
                            End If

                            Dim mvtFour As New Ligne(p, options)
                            With mvtFour
                                If Not ligneFourInserted Then .NLigne = 1
                                If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                    .Compte = CompteFournisseur
                                Else
                                    .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                    .CompteTiers = CompteFournisseur
                                    .NomTiers = NomFournisseur
                                    .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                    .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                    .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                                End If
                                .LibMvt = String.Format("TOTAL ACHAT IMMO {0}", NumPiece)
                                .MontantC = Decimal.Round(TTCCptImmo, 2)
                            End With
                            If ligneFourInserted Then
                                export.Lignes.Add(mvtFour)
                            Else
                                export.Lignes.Insert(0, mvtFour)
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
                Dim hasCodeTiersEnabled As Boolean = dsAgrifact.Tables("Entreprise").Columns.Contains("CodeTiers")
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
                        'If IsDBNull(rwFournisseur.Item("NCompteF")) Or IsDBNull(rwFournisseur.Item("NActiviteF")) Then
                        ' Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        'End If
                        'legrain 27/01/2014
                        If IsDBNull(rwFournisseur.Item("NCompteF")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour le fournisseur {0}", NomFournisseur))
                        End If
                        'Infos fournisseur
                        Dim CompteFournisseur As String = rwFournisseur.Item("NCompteF")
                        'Dim ActiviteFournisseur As String = rwFournisseur.Item("NActiviteF")
                        Dim ActiviteFournisseur As String = "0"

                        'Infos banque
                        'Dim rwBanque As DataRow = dsAgrifact.Tables("Banque").Select("nBanque='" & rwReglement.Item("nBanque") & "'", "")(0)
                        'TODO : Probleme pour les reglements d'achat on ne stocke pas le nBanque mais juste son libelle
                        Dim rwsBanque() As DataRow = dsAgrifact.Tables("Banque").Select("Libelle='" & rwReglement("BanqueClient").Replace("'", "''") & "'", "")
                        If rwsBanque.Length = 0 Then
                            Throw New WarningExport(String.Format("La banque {0} est introuvable", rwReglement("BanqueClient")))
                        End If
                        Dim rwBanque As DataRow = rwsBanque(0)
                        Dim NomBanque As String = rwBanque.Item("Libelle").toUpper
                        'If IsDBNull(rwBanque.Item("NCompte")) Or IsDBNull(rwBanque.Item("NActivite")) Then
                        ' Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        'End If
                        If IsDBNull(rwBanque.Item("NCompte")) Then
                            Throw New WarningExport(String.Format("Les infos compta ne sont pas renseignées pour la banque {0}", NomBanque))
                        End If
                        Dim CompteBanque As String = rwBanque.Item("NCompte")
                        'Dim ActiviteBanque As String = rwBanque.Item("NActivite")
                        Dim ActiviteBanque As String = "0"

                        'Déterminer le n° de la piece
                        Dim NumPiece As Integer = rwReglement.Item("nReglement")
                        If Not IsNumeric(BlocnPieceDebutAReglement) Then BlocnPieceDebutAReglement = 150000
                        If Not IsNumeric(BlocnPieceFinAReglement) Then BlocnPieceFinAReglement = 200000

                        'TODO N° à revoir ? => On n'a aucun n° de remise à utiliser
                        'NumPiece = CadreFourchette(rwReglement.Item("nReglement"), CInt(BlocnPieceDebutAReglement), CInt(BlocnPieceFinAReglement))

                        'Init variables ECR 
                        Dim dtReglement As Date = rwReglement("DateReglement")
                        Dim p As New Piece(export)
                        With p
                            .Type = TypePiece.T
                            .RefPiece = ""
                            .DatePiece = dtReglement
                        End With

                        Dim Escompte As Boolean = (Not rwReglement.IsNull("TxEscompte") AndAlso rwReglement.Item("TxEscompte") <> 0)

                        'Créer la ligne du réglement
                        Dim DetailFacture As DataRow = dsAgrifact.Tables("AFacture").Select("nDevis=" & dsAgrifact.Tables("AReglement_Detail").Select("nReglement='" & rwReglement.Item("nReglement") & "'")(0).Item("NFacture") & "", "")(0)
                        Dim NumFacture As Integer = DetailFacture("NFacture")
                        NumFacture = CadreFourchette(DetailFacture("NFacture"), CInt(BlocnPieceDebutAFacture), CInt(BlocnPieceFinAFacture))

                        Dim libPaiement As String = "PAIEMENT " & NumFacture & " " & rwReglement.Item("nMode") & " " & NomFournisseur

                        'MONTANT DU PAIEMENT AU CREDIT DU COMPTE BANQUE
                        Dim mvt As New Ligne(p, options)
                        With mvt
                            .Compte = CompteBanque
                            .LibMvt = libPaiement
                            .MontantC = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                        End With
                        export.Lignes.Add(mvt)

                        'MONTANT DU PAIEMENT AU DEBIT DU COMPTE FOURNISSEUR
                        mvt = New Ligne(p, options)
                        With mvt
                            If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                .Compte = CompteFournisseur
                            Else
                                .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                .CompteTiers = CompteFournisseur
                                .NomTiers = NomFournisseur
                                .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                            End If
                            .LibMvt = libPaiement
                            .MontantD = Decimal.Round(CDec(rwReglement.Item("Montant")), 2)
                        End With
                        export.Lignes.Add(mvt)

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
                                Dim mvtPP As New Ligne(p, options)
                                With mvtPP
                                    .Compte = COMPTE_PROFIT
                                    .LibMvt = "Arrondi de paiement profit " & NumFacture
                                    .MontantC = perte
                                End With
                                export.Lignes.Add(mvtPP)
                                ' MONTANT DU PROFIT AU DEBIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Ligne(p, options)
                                With mvtPP
                                    If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                        .Compte = CompteFournisseur
                                    Else
                                        .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                        .CompteTiers = CompteFournisseur
                                        .NomTiers = NomFournisseur
                                        .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                        .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                        .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                                    End If
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
                                Dim mvtPP As New Ligne(p, options)
                                With mvtPP
                                    .Compte = COMPTE_PERTE
                                    .LibMvt = "Arrondi de paiement perte " & NumFacture
                                    .MontantD = profit
                                End With
                                export.Lignes.Add(mvtPP)
                                ' MONTANT DE LA PERTE AU CREDIT SUR COMPTE FOURNISSEUR
                                mvtPP = New Ligne(p, options)
                                With mvtPP
                                    If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                        .Compte = CompteFournisseur
                                    Else
                                        .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                        .CompteTiers = CompteFournisseur
                                        .NomTiers = NomFournisseur
                                        .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                        .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                        .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                                    End If
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
                                If Convert.ToString(ligneDetail.Item("TTVA")).StartsWith("I") Then
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
                                Dim mvtEsc As New Ligne(p, options)
                                With mvtEsc
                                    If Not hasCodeTiersEnabled OrElse IsDBNull(rwFournisseur("CodeTiers")) Then
                                        .Compte = CompteFournisseur
                                    Else
                                        .Compte = Convert.ToString(rwFournisseur("CodeTiers"))
                                        .CompteTiers = CompteFournisseur
                                        .NomTiers = NomFournisseur
                                        .AdresseTiers = Convert.ToString(rwFournisseur("Adresse"))
                                        .CpTiers = Convert.ToString(rwFournisseur("CodePostal"))
                                        .VilleTiers = Convert.ToString(rwFournisseur("Ville"))
                                    End If
                                    .LibMvt = NomFournisseur & " escompte " & NumFacture
                                    .MontantD = MontantTTCAvecEscompte
                                End With
                                export.Lignes.Add(mvtEsc)

                                ' on passe le montant de l'escompte en escompte
                                mvtEsc = New Ligne(p, options)
                                With mvtEsc
                                    .Compte = COMPTE_ESCOMPTE_OBTENUE
                                    .LibMvt = "Escompte Obtenue " & NumFacture
                                    .MontantC = MontantHTAvecEscompte
                                End With
                                export.Lignes.Add(mvtEsc)

                                ' On solde les codes TVA
                                If MontantTVAAvecEscompteCharge <> 0 Then
                                    Dim codeTVA As String = "A"
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Ligne(p, options)
                                    With mvtEsc
                                        .Compte = cptTVA
                                        .LibMvt = "REGUL. TVA ESCOMPTE " & NumFacture
                                        .MontantC = MontantTVAAvecEscompteCharge
                                    End With
                                    export.Lignes.Add(mvtEsc)
                                End If
                                If MontantTVAAvecEscompteImmo <> 0 Then
                                    Dim codeTVA As String = "I"
                                    Dim cptTVA As String = GetRowTVA(codeTVA)("TCpt")
                                    mvtEsc = New Ligne(p, options)
                                    With mvtEsc
                                        .Compte = cptTVA
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
        Private FormatDate As String = "dd/MM/yy"

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
        Public Type As TypePiece
        Public NPiece As Integer
        Public RefPiece As String
        Public DatePiece As Date
        Public nbLigne As Integer
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
        Public Type As TypePiece
        Private _RefPiece As String
        Public Property RefPiece() As String
            Get
                Return _RefPiece
            End Get
            Set(ByVal Value As String)
                _RefPiece = Left(Value, 9)
            End Set
        End Property
        Public DatePiece As Date
        Public DateEcheance As Date

        'Infos ligne
        Public NLigne As Integer

        'Ou Code Tiers si on gère les Tiers
        Private _cpt As String
        Public Property Compte() As String
            Get
                Return _cpt
            End Get
            Set(ByVal Value As String)
                If Not IsNumeric(Value) AndAlso Not Value.StartsWith("+") Then
                    Value = "+" & Value
                End If
                _cpt = Left(Value, 8)
                'legrain 27/01/2014
                'While _cpt.EndsWith("0")
                '_cpt = _cpt.Substring(0, _cpt.Length - 1)
                'End While
            End Set
        End Property

        Private _libMvt As String
        Public Property LibMvt() As String
            Get
                If _libMvt Is Nothing Then
                    Return Nothing
                Else
                    Return Left(_libMvt, 23)
                End If
            End Get
            Set(ByVal Value As String)
                _libMvt = Value
            End Set
        End Property

        Public MontantD As Decimal
        Public MontantC As Decimal
        Public Qte1 As Decimal
        Public Qte2 As Decimal

        Private _CodeTvaCompte As String
        Public Property CodeTvaCompte() As String
            Get
                If _CodeTvaCompte Is Nothing Then
                    Return Nothing
                ElseIf _CodeTvaCompte.Length = 0 Then
                    Return ""
                Else
                    Return _CodeTvaCompte.Substring(0, 1)
                End If
            End Get
            Set(ByVal Value As String)
                If Value Is Nothing Then
                    _CodeTvaCompte = Nothing
                ElseIf Value.Length = 0 Then
                    _CodeTvaCompte = ""
                Else
                    _CodeTvaCompte = Value.Substring(0, 1)
                End If
            End Set
        End Property

        Public TauxTVA As Decimal
        Public MtTVAD As Decimal
        Public MtTVAC As Decimal
        Public ExigTVA As OptionTVA
        Public DateLivraison As Date

        'Infos tiers
        Public _cptt As String
        Public Property CompteTiers() As String
            Get
                Return _cptt
            End Get
            Set(ByVal Value As String)
                _cptt = Left(Value, 8)
                While _cptt.EndsWith("0")
                    _cptt = _cptt.Substring(0, _cptt.Length - 1)
                End While
            End Set
        End Property

        Private _NomTiers As String
        Public Property NomTiers() As String
            Get
                Return _NomTiers
            End Get
            Set(ByVal Value As String)
                _NomTiers = Left(Value, 30)
            End Set
        End Property

        Private _ad1 As String
        Public Property AdresseTiers1() As String
            Get
                Return _ad1
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    _ad1 = Left(Value.Replace(vbCrLf, " "), 30)
                Else
                    _ad1 = Nothing
                End If
            End Set
        End Property

        Private _ad2 As String
        Public Property AdresseTiers2() As String
            Get
                Return _ad2
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    _ad2 = Left(Value.Replace(vbCrLf, " "), 30)
                Else
                    _ad2 = Nothing
                End If
            End Set
        End Property

        Public WriteOnly Property AdresseTiers() As String
            Set(ByVal Value As String)
                If Value.IndexOf(vbCrLf) >= 0 Then
                    Me.AdresseTiers1 = Value.Substring(0, Value.IndexOf(vbCrLf)).Trim
                    Me.AdresseTiers2 = Value.Substring(Value.IndexOf(vbCrLf) + 1).Trim
                Else
                    Me.AdresseTiers1 = Value
                    Me.AdresseTiers2 = ""
                End If
            End Set
        End Property

        Private _cp As String
        Public Property CpTiers() As String
            Get
                Return _cp
            End Get
            Set(ByVal Value As String)
                _cp = Left(Value, 5)
            End Set
        End Property


        Private _ville As String
        Public Property VilleTiers() As String
            Get
                Return _ville
            End Get
            Set(ByVal Value As String)
                _ville = Left(Value, 25)
            End Set
        End Property


#Region "ctor"
        Public Sub New()
        End Sub

        Public Sub New(ByVal p As Piece, ByVal o As OptionsExport)
            Me.New()
            Me.Type = p.Type
            Me.NPiece = p.NPiece
            Me.RefPiece = p.RefPiece
            Me.DatePiece = p.DatePiece
            Me.ExigTVA = o.ExigTVA
            p.nbLigne += 1
            Me.NLigne = p.nbLigne
        End Sub
#End Region

#Region "overrides"
        Public Overrides Function GetFormat() As String
            Return "{0,5}{1,3}{2}{3,-9}{4,8}" & _
                    "{5,-8}{6,-23}{7,12:#0.00}{8,12:#0.00}{9,9:#0.00}{10,9:#0.00}{11,1}{12,6:#0.00}{13,11:#0.00}{14,11:#0.00}{15,8}" & _
                    "{16,-8}{17,-30}{18,-30}{19,-30}{20,-5}{21,-25}{22}{23,8}"
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {NPiece, NLigne, Type, RefPiece, DatePiece, _
                                Compte, LibMvt, MontantD, MontantC, Qte1, Qte2, CodeTvaCompte, TauxTVA, MtTVAD, MtTVAC, DateEcheance, _
                                CompteTiers, NomTiers, AdresseTiers1, AdresseTiers2, CpTiers, VilleTiers, ExigTVA, DateLivraison}
        End Function
#End Region
    End Class
#End Region
End Namespace