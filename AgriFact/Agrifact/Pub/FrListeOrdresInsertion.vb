Imports System.Data.SqlClient

Public Class FrlisteOrdresInsertion

    Private Const SERVICE As String = "PUB"
    Private Const CODEPRODUITPUB As String = "PUB"

#Region "Form"
    Private Sub FrlisteOrdresInsertion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ToolStripStatusLabel1.Text = String.Empty
        Me.ToolStripStatusLabel1.Visible = False
        Me.ToolStripProgressBar1.Value = 0
        Me.ToolStripProgressBar1.Visible = False

        Me.ClearFilter()
    End Sub
#End Region

#Region "Button"
    Private Sub FiltrerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrerButton.Click
        Me.LoadData()
    End Sub

    Private Sub DefiltrerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefiltrerButton.Click
        Me.ClearFilter()
    End Sub

    Private Sub ChercherClientButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChercherClientButton.Click
        Me.OpenFormChercherClient()
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub NouveauToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripButton.Click
        Using fr As New FrOrdreInsertion()
            fr.ShowDialog()

            Me.LoadData()
        End Using
    End Sub

    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        Me.SupprimerEvenements()

        Me.LoadData()
    End Sub

    Private Sub AfficherCompteRenduToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfficherCompteRenduToolStripButton.Click
        Dim fr As New FrCompteRendu()

        fr.ShowDialog()
    End Sub

    Private Sub PrefacturerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrefacturerToolStripButton.Click
        Me.Prefacturer()

        Me.LoadData()
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        Me.ImprimerListeOrdresInsertion()
    End Sub

    Private Sub FermerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermerToolStripButton.Click
        Me.Close()
    End Sub
#End Region

#Region "AffichageEvenementDataGridView"
    Private Sub AffichageEvenementDataGridView_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles AffichageEvenementDataGridView.CellMouseDoubleClick
        Me.OuvrirFormOrdreInsertion()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub Prefacturer()
        Dim listeAffichageEvenementDR As List(Of PubDataSet.AffichageEvenementRow)

        If Me.AffichageEvenementBindingSource.Position < 0 Then Exit Sub

        If (MsgBox("Confirmez-vous la pré-facturation des ordres d'insertion sélectionnés ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.AfficherToolStripProgressBar1()
            Me.Enabled = False
            Me.ReportToolStripProgressBar1(0, "Pré-facturation des ordres d'insertion")

            'Récupération de la liste des évènements sélectionnés
            listeAffichageEvenementDR = Me.GetSelectedAffichageEvenementRows()

            For Each AffichageEvenementDR As PubDataSet.AffichageEvenementRow In listeAffichageEvenementDR
                Dim dateEv As String = String.Empty
                Dim nomCl As String = String.Empty

                If Not (AffichageEvenementDR.IsDateEvNull) Then
                    dateEv = CStr(AffichageEvenementDR.DateEv)
                End If

                If Not (AffichageEvenementDR.IsNomClientNull) Then
                    nomCl = AffichageEvenementDR.NomClient
                End If

                'Pas de pré-facturation si l'ordre d'insertion est marqué comme facturé
                If (AffichageEvenementDR.Facture) Then
                    FrCompteRendu.texteCompteRendu.Append(String.Format("L'ordre d'insertion du {0} du client {1} n'a pas pu être pré-facturé car il est déjà pré-facturé." & vbCrLf, dateEv, nomCl))
                Else
                    Dim nPreFacturation As Decimal = 0
                    Dim datePreFact As Date = Now

                    'Calcul du nouveau nPreFacturation
                    nPreFacturation = Me.EvenementTableAdapter.GetMaxnPreFacturation().GetValueOrDefault(0) + 1

                    'Création du BL pour cet évènement
                    Me.CreerBL(AffichageEvenementDR, nPreFacturation, datePreFact)

                    FrCompteRendu.texteCompteRendu.Append(String.Format("L'ordre d'insertion du {0} du client {1} a été pré-facturé." & vbCrLf, dateEv, nomCl))
                End If
            Next

            Me.ReportToolStripProgressBar1(100, "Pré-facturation des ordres d'insertion")

            Me.ToolStripStatusLabel1.Text = "Pré-facturation terminée"

            MsgBox("Traitement terminé.", MsgBoxStyle.Information, "")
        Finally
            Me.Cursor = Cursors.Default
            Me.ToolStripProgressBar1.Visible = False
            Me.Enabled = True
        End Try
    End Sub

    Private Function CreerBL(ByVal AffichageEvenementDR As PubDataSet.AffichageEvenementRow, ByVal nPreFacturation As Decimal, _
                            ByVal datePreFact As Date) As Boolean
        Dim PubDS As New PubDataSet
        Dim EntrepriseDR As PubDataSet.EntrepriseRow
        Dim dateEv As String = String.Empty
        Dim nomCl As String = String.Empty
        Dim dateEcheance As Date = System.DateTime.MinValue
        Dim remise As Decimal = 0

        If Not (AffichageEvenementDR.IsDateEvNull) Then
            dateEv = CStr(AffichageEvenementDR.DateEv)
        End If

        'Pas de création de BL si l'évènement ne possède pas de client
        If (AffichageEvenementDR.IsnClientNull) Then
            FrCompteRendu.texteCompteRendu.Append(String.Format("L'ordre d'insertion du {0} n°{1} n'a pas pu être pré-facturé car aucun client n'est renseigné." & vbCrLf, dateEv, AffichageEvenementDR.nEvenement))

            Return False
        End If

        'Récupération des infos du client à facturer
        Using EntrepriseTA As New PubDataSetTableAdapters.EntrepriseTableAdapter
            Dim EntrepriseDT As PubDataSet.EntrepriseDataTable = EntrepriseTA.GetDataBynEntreprise(AffichageEvenementDR.nClient)

            If (EntrepriseDT.Rows.Count > 0) Then
                EntrepriseDR = CType(EntrepriseDT.Rows(0), PubDataSet.EntrepriseRow)

                'Calcul de l'échéance en fonction des infos du client
                dateEcheance = Me.CalculerEcheance(EntrepriseDR, CDate(String.Format("{0:dd/MM/yyyy}", Now)))

                'Récupération du taux de remise du client
                If Not (EntrepriseDR.IsRemiseNull) Then
                    remise = EntrepriseDR.Remise
                End If
            Else
                Return False
            End If
        End Using

        'Création d'un nouveau BL
        Dim VBonLivraisonDR As PubDataSet.VBonLivraisonRow = PubDS.VBonLivraison.NewVBonLivraisonRow()

        VBonLivraisonDR.nClient = EntrepriseDR.nEntreprise

        'Construction de l'adresse de facturation
        VBonLivraisonDR.AdresseFacture = String.Empty

        If Not (EntrepriseDR.IsCiviliteNull) Then
            VBonLivraisonDR.AdresseFacture = EntrepriseDR.Civilite & " "
        End If

        If Not (EntrepriseDR.IsNomNull) Then
            VBonLivraisonDR.AdresseFacture = VBonLivraisonDR.AdresseFacture & EntrepriseDR.Nom & vbCrLf
        End If

        If Not (EntrepriseDR.IsAdresseNull) Then
            VBonLivraisonDR.AdresseFacture = VBonLivraisonDR.AdresseFacture & EntrepriseDR.Adresse & " "
        End If

        If Not (EntrepriseDR.IsCodePostalNull) Then
            VBonLivraisonDR.AdresseFacture = VBonLivraisonDR.AdresseFacture & EntrepriseDR.CodePostal & " "
        End If

        If Not (EntrepriseDR.IsVilleNull) Then
            VBonLivraisonDR.AdresseFacture = VBonLivraisonDR.AdresseFacture & EntrepriseDR.Ville
        End If

        VBonLivraisonDR.nCommercial = AffichageEvenementDR.nPersonneAuteur
        VBonLivraisonDR.Secteur = SERVICE
        VBonLivraisonDR.FacturationPrescripteur = False
        VBonLivraisonDR.FacturationClient = False
        VBonLivraisonDR.DateFacture = CDate(String.Format("{0:dd/MM/yyyy}", Now))
        VBonLivraisonDR.Paye = False
        VBonLivraisonDR.ExportCompta = False

        If (dateEcheance <> System.DateTime.MinValue) Then
            VBonLivraisonDR.DateEcheance = dateEcheance
        End If

        VBonLivraisonDR.Remise = 0
        VBonLivraisonDR.FacturationTTC = False

        'Création des détails du BL
        'Récupération des infos du produit
        Dim ProduitDT As PubDataSet.ProduitDataTable = Me.ProduitTableAdapter.GetDataByCodeProduit(CODEPRODUITPUB)
        Dim i As Integer = 1
        Dim montantHTFacture As Decimal = 0
        Dim montantTVAFacture As Decimal = 0

        For Each ProduitDR As PubDataSet.ProduitRow In ProduitDT.Rows
            Dim txTVA As Decimal = 0
            Dim montantTTC As Decimal = 0
            Dim montantTVA As Decimal = 0
            Dim montantHT As Decimal = 0
            Dim VBonLivraison_DetailDR As PubDataSet.VBonLivraison_DetailRow = PubDS.VBonLivraison_Detail.NewVBonLivraison_DetailRow()

            'Recherche du taux de TVA du produit
            If Not (ProduitDR.IsTTVANull) Then
                VBonLivraison_DetailDR.TTVA = ProduitDR.TTVA

                Dim TVADT As PubDataSet.TVADataTable = Me.TVATableAdapter.GetDataByTTVA(VBonLivraison_DetailDR.TTVA)

                For Each TVADR As PubDataSet.TVARow In TVADT.Rows
                    If Not (TVADR.IsTTauxNull) Then
                        txTVA = TVADR.TTaux
                    End If
                Next
            End If

            'Recherche du N° de compte et de l'activité du produit
            If Not (ProduitDR.IsNCompteVNull) Then
                VBonLivraison_DetailDR.NCompte = ProduitDR.NCompteV
            End If

            If Not (ProduitDR.IsNActiviteVNull) Then
                VBonLivraison_DetailDR.NActivite = ProduitDR.NActiviteV
            End If

            'Calcul des montants
            If Not (AffichageEvenementDR.IsPrixHTNull) Then
                montantHT = Math.Round(AffichageEvenementDR.PrixHT - (AffichageEvenementDR.PrixHT * (remise / 100)), 2)
            End If

            montantTVA = Math.Round(montantHT * (txTVA / 100), 2)
            montantTTC = montantHT + montantTVA

            montantHTFacture = montantHTFacture + montantHT
            montantTVAFacture = montantTVAFacture + montantTVA

            VBonLivraison_DetailDR.nLigne = i
            VBonLivraison_DetailDR.CodeProduit = ProduitDR.CodeProduit

            'Construction du libellé : Libellé produit + date évènement + saut ligne + Emplacement + saut de ligne 
            '+ Format + saut de ligne + Rubrique + saut de ligne + Observation
            Dim libelle As String = String.Empty

            If Not (ProduitDR.IsLibelleNull) Then
                libelle = ProduitDR.Libelle

                If Not (AffichageEvenementDR.IsDateEvNull) Then
                    libelle = libelle & " " & String.Format("{0:dd/MM/yyyy}", AffichageEvenementDR.DateEv)
                End If
            End If

            If Not (AffichageEvenementDR.IsEmplacementNull) Then
                libelle = libelle & Microsoft.VisualBasic.vbCrLf & AffichageEvenementDR.Emplacement
            End If

            If Not (AffichageEvenementDR.IsFormatNull) Then
                libelle = libelle & Microsoft.VisualBasic.vbCrLf & AffichageEvenementDR.Format
            End If

            If Not (AffichageEvenementDR.IsRubriqueNull) Then
                libelle = libelle & Microsoft.VisualBasic.vbCrLf & AffichageEvenementDR.Rubrique
            End If

            If Not (AffichageEvenementDR.IsObservationNull) Then
                libelle = libelle & Microsoft.VisualBasic.vbCrLf & AffichageEvenementDR.Observation
            End If

            VBonLivraison_DetailDR.Libelle = libelle

            VBonLivraison_DetailDR.Unite1 = 1
            VBonLivraison_DetailDR.TxTva = txTVA
            VBonLivraison_DetailDR.LibUnite1 = "U"
            VBonLivraison_DetailDR.PrixUHT = AffichageEvenementDR.PrixHT
            VBonLivraison_DetailDR.PrixUTTC = Nothing
            VBonLivraison_DetailDR.PrixUTVA = Nothing
            VBonLivraison_DetailDR.MontantLigneHT = montantHT
            VBonLivraison_DetailDR.MontantLigneTTC = montantTTC
            VBonLivraison_DetailDR.MontantLigneTVA = montantTVA
            VBonLivraison_DetailDR.Remise = remise

            VBonLivraison_DetailDR.nDetailDevis = Me.VBonLivraison_DetailTableAdapter.GetMaxnDetailDevis().GetValueOrDefault(0) + 1

            PubDS.VBonLivraison_Detail.AddVBonLivraison_DetailRow(VBonLivraison_DetailDR)

            i += 1
        Next

        'Affectation des montants totaux à la facture 
        VBonLivraisonDR.MontantHT = montantHTFacture
        VBonLivraisonDR.MontantTVA = montantTVAFacture
        VBonLivraisonDR.MontantTTC = montantHTFacture + montantTVAFacture

        VBonLivraisonDR.nFacture = CDec(Me.VBonLivraisonTableAdapter.GetNextNFacture())
        VBonLivraisonDR.nDevis = Me.VBonLivraisonTableAdapter.GetMaxnDevis().GetValueOrDefault(0) + 1

        For Each VBonLivraison_DetailDR As PubDataSet.VBonLivraison_DetailRow In PubDS.VBonLivraison_Detail.Rows
            VBonLivraison_DetailDR.nDevis = VBonLivraisonDR.nDevis
        Next

        PubDS.VBonLivraison.Rows.Add(VBonLivraisonDR)

        'Mise à jour de la base de données
        Me.VBonLivraisonTableAdapter.Update(PubDS.VBonLivraison)
        Me.VBonLivraison_DetailTableAdapter.Update(PubDS.VBonLivraison_Detail)

        'Mise à jour des infos de pré-facturation dans l'évènement
        Me.EvenementTableAdapter.UpdateInfosPreFacturation(True, nPreFacturation, datePreFact, AffichageEvenementDR.nEvenement)

        Return True
    End Function

    Private Function CalculerEcheance(ByVal EntrepriseDR As PubDataSet.EntrepriseRow, ByVal dateFacture As Date) As Date
        Dim dateEcheance As Date = System.DateTime.MinValue
        Dim finMois As New Nullable(Of Boolean)
        Dim echeance As Nullable(Of Decimal)

        'Calcul à partir de la fiche client
        If EntrepriseDR.IsFinMoisNull Then
            finMois = New Nullable(Of Boolean)
        Else
            finMois = EntrepriseDR.FinMois
        End If

        If EntrepriseDR.IsEcheanceNull Then
            echeance = New Nullable(Of Decimal)
        Else
            echeance = EntrepriseDR.Echeance
        End If

        'Calcul à partir du paramètrage
        Dim ds As New DataSet

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
        End Using

        If Not (echeance.HasValue) Then
            If (ParametresBase.GetValeur(ds, "NbJoursEcheance", Nothing, "") = "") Then
                echeance = New Nullable(Of Decimal)
            Else
                echeance = CDec(ParametresBase.GetValeur(ds, "NbJoursEcheance", Nothing, ""))
            End If

            finMois = CBool(ParametresBase.GetValeur(ds, "FdMEcheance", Nothing, "False"))
        End If

        dateEcheance = dateFacture.AddDays(echeance.GetValueOrDefault())

        If (finMois.GetValueOrDefault()) Then
            dateEcheance = New Date(dateEcheance.Year, dateEcheance.Month, Date.DaysInMonth(dateEcheance.Year, dateEcheance.Month))
        End If

        Return dateEcheance
    End Function

    Private Sub SupprimerEvenements()
        Dim listeAffichageEvenementDR As List(Of PubDataSet.AffichageEvenementRow)
        Dim i As Integer = 0

        If Me.AffichageEvenementBindingSource.Position < 0 Then Exit Sub

        If (MsgBox("Confirmez-vous la suppression des ordres d'insertion sélectionnés ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.AfficherToolStripProgressBar1()
            Me.Enabled = False
            Me.ReportToolStripProgressBar1(0, "Suppression des ordres d'insertion")

            'Récupération de la liste des évènements sélectionnés
            listeAffichageEvenementDR = Me.GetSelectedAffichageEvenementRows()

            For Each AffichageEvenementDR As PubDataSet.AffichageEvenementRow In listeAffichageEvenementDR
                Dim dateEv As String = String.Empty
                Dim nomCl As String = String.Empty

                If Not (AffichageEvenementDR.IsDateEvNull) Then
                    dateEv = CStr(AffichageEvenementDR.DateEv)
                End If

                If Not (AffichageEvenementDR.IsNomClientNull) Then
                    nomCl = AffichageEvenementDR.NomClient
                End If

                'Suppression uniquement si évènement ni réalisé ni facturé
                If Not (AffichageEvenementDR.Facture) And Not (AffichageEvenementDR.Realise) Then
                    Me.EvenementTableAdapter.DeleteBynEvenement(AffichageEvenementDR.nEvenement)

                    FrCompteRendu.texteCompteRendu.Append(String.Format("L'ordre d'insertion du {0} du client {1} a été supprimé." & vbCrLf, dateEv, nomCl))
                Else
                    FrCompteRendu.texteCompteRendu.Append(String.Format("L'ordre d'insertion du {0} du client {1} n'a pas pu être supprimé car l'ordre d'insertion est soit facturé soit réalisé." & vbCrLf, dateEv, nomCl))
                End If

                i += 1 : Me.ReportToolStripProgressBar1(i * 100 \ listeAffichageEvenementDR.Count, "Suppression des ordres d'insertion")
            Next

            Me.ReportToolStripProgressBar1(100, "Suppression des ordres d'insertion")

            Me.ToolStripStatusLabel1.Text = "Suppression terminée"
        Finally
            Me.Cursor = Cursors.Default
            Me.ToolStripProgressBar1.Visible = False
            Me.Enabled = True
        End Try
    End Sub

    Private Function GetSelectedAffichageEvenementRows() As List(Of PubDataSet.AffichageEvenementRow)
        Dim listeAffichageEvenementDR As New List(Of PubDataSet.AffichageEvenementRow)

        If (Me.AffichageEvenementDataGridView.SelectedRows.Count > 0) Then
            For Each row As DataGridViewRow In Me.AffichageEvenementDataGridView.SelectedRows
                If row.DataBoundItem Is Nothing Then Continue For

                If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

                Dim AffichageEvenementDR As PubDataSet.AffichageEvenementRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, PubDataSet.AffichageEvenementRow)

                listeAffichageEvenementDR.Add(AffichageEvenementDR)
            Next
        End If

        Return listeAffichageEvenementDR
    End Function

    Private Sub OpenFormChercherClient()
        Dim fr As New FrChercherClient()

        With fr
            .ShowDialog()

            If Not (fr.EntrepriseDR Is Nothing) Then
                If Not (fr.EntrepriseDR.IsNomNull) Then
                    Me.NomClientTextBox.Text = fr.EntrepriseDR.Nom
                Else
                    Me.NomClientTextBox.Text = String.Empty
                End If
            End If
        End With
    End Sub

    Private Sub ClearFilter()
        Me.NomClientTextBox.Text = String.Empty
        Me.DateParutionDebutDateTimePicker.Value = Now
        Me.DateParutionDebutDateTimePicker.Checked = False
        Me.DateParutionFinDateTimePicker.Value = Now
        Me.DateParutionFinDateTimePicker.Checked = False
        Me.FactureCheckBox.CheckState = CheckState.Unchecked
        Me.RealiseCheckBox.CheckState = CheckState.Unchecked
        Me.FacturationMCheckBox.CheckState = CheckState.Indeterminate

        Me.LoadData()

        Me.AffichageEvenementDataGridView.ClearSelection()
    End Sub

    Private Sub LoadData()
        Dim nomClient As String = String.Empty
        Dim dateParutionDebut As Nullable(Of Date)
        Dim dateParutionFin As Nullable(Of Date)
        Dim facture As Nullable(Of Boolean)
        Dim realise As Nullable(Of Boolean)
        Dim facturationM As Nullable(Of Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.AfficherToolStripProgressBar1()
            Me.Enabled = False
            Me.ReportToolStripProgressBar1(50, "Chargement des ordres d'insertion")

            'Gestion de la zone de texte NomClient
            If (Me.NomClientTextBox.Text.Length > 0) Then
                nomClient = Me.NomClientTextBox.Text
            End If

            'Gestion de la date de parution de début
            If (Me.DateParutionDebutDateTimePicker.Checked) Then
                dateParutionDebut = Me.DateParutionDebutDateTimePicker.Value
            Else
                dateParutionDebut = New Nullable(Of Date)
            End If

            'Gestion de la date de parution de fin
            If (Me.DateParutionFinDateTimePicker.Checked) Then
                dateParutionFin = Me.DateParutionFinDateTimePicker.Value
            Else
                dateParutionFin = New Nullable(Of Date)
            End If

            'Gestion case à cocher Facturé
            Select Case Me.FactureCheckBox.CheckState
                Case CheckState.Checked
                    facture = True
                Case CheckState.Unchecked
                    facture = False
            End Select

            'Gestion case à cocher Réalisé
            Select Case Me.RealiseCheckBox.CheckState
                Case CheckState.Checked
                    realise = True
                Case CheckState.Unchecked
                    realise = False
            End Select

            'Gestion case à cocher Facturation mensuelle
            Select Case Me.FacturationMCheckBox.CheckState
                Case CheckState.Checked
                    facturationM = True
                Case CheckState.Unchecked
                    facturationM = False
            End Select

            'Remplissage de PubDataSet.AffichageEvenement en fonction des critères
            Me.RemplirAffichageEvenement(nomClient, dateParutionDebut, dateParutionFin, facture, realise, facturationM)

            Me.ReportToolStripProgressBar1(100, "Chargement des ordres d'insertion")
            Me.ToolStripStatusLabel1.Text = String.Format("{0} ordres d'insertion", Me.AffichageEvenementBindingSource.List.Count)
        Finally
            Me.Cursor = Cursors.Default
            Me.ToolStripProgressBar1.Visible = False
            Me.Enabled = True
        End Try
    End Sub

    Private Sub RemplirAffichageEvenement(ByVal nomClient As String, ByVal dateParutionDebut As Nullable(Of Date), _
                                        ByVal dateParutionFin As Nullable(Of Date), ByVal facture As Nullable(Of Boolean), _
                                        ByVal realise As Nullable(Of Boolean), ByVal facturationM As Nullable(Of Boolean))

        Dim queryString As String = String.Empty
        Dim criteres As String = String.Empty

        queryString = "SELECT Evenement.nEvenement, Evenement.TypeEv, Evenement.DateCreation, Evenement.Origine, " & _
                    "Evenement.nOrigine, Evenement.nImage, Evenement.Dep, Evenement.Type, Evenement.DateEv, " & _
                    "Evenement.Priorite, Evenement.Duree, Evenement.UniteDuree, Evenement.Realise, " & _
                    "Evenement.nPersonneAuteur, Evenement.nPersonneDestinataire, Evenement.nClient, " & _
                    "Evenement.Libelle, Evenement.ProduitsPresentes, Evenement.Observation, Evenement.Dossier, " & _
                    "Evenement.AContacter, Evenement.SuiteADonner, Evenement.DateContact, Evenement.Conclusion, " & _
                    "Evenement.Format, Evenement.Couleur, Evenement.Contenu, Evenement.FaxerBAT, " & _
                    "Evenement.Emplacement, Evenement.Rubrique, Evenement.PrixHT, Evenement.FacturationM, " & _
                    "Evenement.FacturationObs, Evenement.Facture, Evenement.AutreSupport, Evenement.nPreFacturation, " & _
                    "Evenement.DatePreFacturation, Entreprise.Nom AS NomClient, Personne_1.Nom AS NomAuteur, " & _
                    "Personne.Nom AS NomDestinataire " & _
                    "FROM Evenement LEFT OUTER JOIN Personne ON Evenement.nPersonneDestinataire = Personne.nPersonne " & _
                    "LEFT OUTER JOIN Personne AS Personne_1 ON Evenement.nPersonneAuteur = Personne_1.nPersonne " & _
                    "LEFT OUTER JOIN Entreprise ON Evenement.nClient = Entreprise.nEntreprise"

        'Récupération des critères sous forme de String SQL
        criteres = Me.GetSqlCriteres(nomClient, dateParutionDebut, dateParutionFin, facture, realise, facturationM)

        If Not (String.IsNullOrEmpty(criteres)) Then
            queryString = queryString & " WHERE " & criteres
        End If

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            sqlConn.Open()

            Using sqlComm As New SqlCommand(queryString, sqlConn)
                Dim listeEvDA As SqlDataAdapter = New SqlDataAdapter()

                listeEvDA.SelectCommand = sqlComm

                Me.PubDataSet.AffichageEvenement.Clear()

                listeEvDA.Fill(Me.PubDataSet.AffichageEvenement)

                Me.AffichageEvenementBindingSource.ResetBindings(False)
            End Using
        End Using
    End Sub

    Private Function GetSqlCriteres(ByVal nomClient As String, ByVal dateParutionDebut As Nullable(Of Date), _
                                    ByVal dateParutionFin As Nullable(Of Date), ByVal facture As Nullable(Of Boolean), _
                                    ByVal realise As Nullable(Of Boolean), ByVal facturationM As Nullable(Of Boolean)) As String

        Dim sqlCriteres As String = String.Empty
        Dim listeCriteres As New List(Of String)
        Dim i As Integer = 1

        'Seulement les TypeEv OrdreInsertion
        listeCriteres.Add(String.Format("(Evenement.TypeEv = '{0}')", FrOrdreInsertion.TYPEEVORDREINSERTION))

        'Gestion du nomClient
        If Not (String.IsNullOrEmpty(nomClient)) Then
            listeCriteres.Add(String.Format("(Entreprise.Nom LIKE '%{0}%')", nomClient))
        End If

        'Gestion de la date de parution
        If (dateParutionDebut.HasValue) And (dateParutionFin.HasValue) Then
            listeCriteres.Add(String.Format("(Evenement.DateEv >= CONVERT(DATETIME, '{0}', 102) AND Evenement.DateEv < DATEADD(d, 1, CONVERT(DATETIME, '{1}', 102)))", dateParutionDebut.Value.ToString("yyyy-MM-dd"), dateParutionFin.Value.ToString("yyyy-MM-dd")))
        ElseIf (dateParutionDebut.HasValue) Then
            listeCriteres.Add(String.Format("(Evenement.DateEv >= CONVERT(DATETIME, '{0}', 102))", dateParutionDebut.Value.ToString("yyyy-MM-dd")))
        ElseIf (dateParutionDebut.HasValue) Then
            listeCriteres.Add(String.Format("(Evenement.DateEv >= CONVERT(DATETIME, '{0}', 102))", dateParutionFin.Value.ToString("yyyy-MM-dd")))
        End If

        'Gestion de l'indicateur Facturé
        If (facture.HasValue) Then
            If CBool(facture) Then
                listeCriteres.Add("(Evenement.Facture = 1)")
            Else
                listeCriteres.Add("(Evenement.Facture = 0)")
            End If
        End If

        'Gestion de l'indicateur Réalisé
        If (realise.HasValue) Then
            If CBool(realise) Then
                listeCriteres.Add("(Evenement.Realise = 1)")
            Else
                listeCriteres.Add("(Evenement.Realise = 0)")
            End If
        End If

        'Gestion de l'indicateur Réalisé
        If (facturationM.HasValue) Then
            If CBool(facturationM) Then
                listeCriteres.Add("(Evenement.FacturationM = 1)")
            Else
                listeCriteres.Add("(Evenement.FacturationM = 0)")
            End If
        End If

        For Each s As String In listeCriteres
            If (i = listeCriteres.Count) Then
                sqlCriteres = sqlCriteres & s
            Else
                sqlCriteres = sqlCriteres & s & " AND "
            End If

            i = i + 1
        Next

        Return sqlCriteres
    End Function

    Private Sub OuvrirFormOrdreInsertion()
        Dim listeAffichageEvenementDR As List(Of PubDataSet.AffichageEvenementRow)

        If Me.AffichageEvenementBindingSource.Position < 0 Then Exit Sub

        'Récupération des évènements sélectionnés
        listeAffichageEvenementDR = Me.GetSelectedAffichageEvenementRows()

        If (listeAffichageEvenementDR.Count > 0) Then
            Using fr As New FrOrdreInsertion(listeAffichageEvenementDR.Item(0).nEvenement)
                fr.ShowDialog()
            End Using
        End If

        Me.LoadData()
    End Sub

    Private Sub AfficherToolStripProgressBar1()
        Me.ToolStripStatusLabel1.Text = String.Empty
        Me.ToolStripStatusLabel1.Visible = True
        Me.ToolStripProgressBar1.Value = 0
        Me.ToolStripProgressBar1.Visible = True
    End Sub

    Private Sub ReportToolStripProgressBar1(ByVal value As Integer, ByVal statut As String)
        Me.ToolStripStatusLabel1.Text = statut
        Me.ToolStripProgressBar1.Value = value
        Application.DoEvents()
    End Sub

    Private Sub ImprimerListeOrdresInsertion()
        Dim myDS As DataSet = Me.PubDataSet.Clone()

        myDS.Merge(Me.PubDataSet.AffichageEvenement.Select())

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDS, "RptListeOrdresInsertion.rpt")

        fr.Show()
    End Sub
#End Region

End Class