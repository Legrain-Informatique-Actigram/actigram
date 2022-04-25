Imports System.Data.OleDb

Public Class FrInventaireLignes

    Private _InvGroupes As Inventaire.ClassesMetier.InventaireGroupes

#Region "Constructeurs"
    Public Sub New(ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._InvGroupes = invGroupes
    End Sub
#End Region

#Region "Form"
    Private Sub FrInventaireLignes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.ConstruireTitreForm()
        Me.FiltrerColonnes()
        Me.ChargerDonnees()
        Me.GererContextMenuStrip1()
    End Sub

    Private Sub FrInventaireLignes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub SelectionnerCoutTracteurToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerCoutTracteurToolStripButton.Click
        If (Me.InventaireLignesDataGridView.SelectedRows.Count = 1) Then
            Dim gestType_Mat As New Baremes.ClassesControleur.GestionnaireType_Materiel(My.Settings.BaremesConnectionString)
            Dim type_Mat As Baremes.ClassesMetier.Type_Materiel = gestType_Mat.GetType_Materiel(My.Resources.CODE_TYPEMAT_TRACTEUR)

            Me.OuvrirFormRechercheMateriel(type_Mat)
        Else
            MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub SelectionnerCoutOutilToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerCoutOutilToolStripButton.Click
        If (Me.InventaireLignesDataGridView.SelectedRows.Count = 1) Then
            Dim gestType_Mat As New Baremes.ClassesControleur.GestionnaireType_Materiel(My.Settings.BaremesConnectionString)
            Dim type_Mat As Baremes.ClassesMetier.Type_Materiel = gestType_Mat.GetType_Materiel(My.Resources.CODE_TYPEMAT_OUTIL)

            Me.OuvrirFormRechercheMateriel(type_Mat)
        Else
            MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub SelectionnerValeurForfaitaireToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerValeurForfaitaireToolStripButton.Click
        If (Me.InventaireLignesDataGridView.SelectedRows.Count = 1) Then
            Me.OuvrirFormRechercheValeurForfaitaire()
        Else
            MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub SelectionnerValeurPdtsEnTerreToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerValeurPdtsEnTerreToolStripButton.Click
        If (Me.InventaireLignesDataGridView.SelectedRows.Count = 1) Then
            Dim gestTypeInv As New Inventaire.ClassesControleur.GestionnaireTypeInventaire(My.Settings.dbDonneesConnectionString)
            Dim typeInvALister As Inventaire.ClassesMetier.TypeInventaire = gestTypeInv.GetTypeInventaire(My.Resources.CODE_TYPEINV_STOCKSPRODTERRE)

            Me.OuvrirFormRechercheValeurAvAuxCult(typeInvALister)
        Else
            MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub SelectionnerValeurFacCultToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionnerValeurFacCultToolStripButton.Click
        If (Me.InventaireLignesDataGridView.SelectedRows.Count = 1) Then
            Dim gestTypeInv As New Inventaire.ClassesControleur.GestionnaireTypeInventaire(My.Settings.dbDonneesConnectionString)
            Dim typeInvALister As Inventaire.ClassesMetier.TypeInventaire = gestTypeInv.GetTypeInventaire(My.Resources.CODE_TYPEINV_FACONSCULTURALES)

            Me.OuvrirFormRechercheValeurAvAuxCult(typeInvALister)
        Else
            MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        Dim nomEtat As String = String.Empty
        Dim impressionDS As DataSetImpression = Nothing

        If Not (Me.Enregistrer()) Then
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        Select Case Me._InvGroupes.INVGTypeInventaire
            Case "A", "M", "P", "T"
                nomEtat = "EtListeInv.rpt"
            Case "F"
                'Recherche de la méthode d'inventaire
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._InvGroupes.INVGDossier)

                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1 'Detaillée
                        nomEtat = "EtListeInvFaconCulturale.rpt"
                    Case My.Resources.M2 'Forfaitaire
                        nomEtat = "EtListeInvFaconCulturaleForf.rpt"
                End Select
            Case "V"
                nomEtat = "EtListeInvAvCult.rpt"
        End Select

        impressionDS = Inventaire.ClassesMetier.ImprInventaire.GetDataByINVGDossierEtINVGCode(Me._InvGroupes.INVGDossier, Me._InvGroupes.INVGCode)

        Using rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument = Inventaire.ClassesMetier.ImprInventaire.PrepareRpt(impressionDS, nomEtat, Me._InvGroupes.INVGDossier)
            Using fr As New EcranCrystal(rpt)
                fr.ShowDialog()
            End Using
        End Using

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
            Me.SupprimerInventaireLignes()
        End If
    End Sub

    Private Sub MonterLigneToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonterLigneToolStripButton.Click
        Me.MonterLigne()
    End Sub

    Private Sub DescendreLigneToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescendreLigneToolStripButton.Click
        Me.DescendreLigne()
    End Sub

    Private Sub DeplacerLigneToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeplacerLigneToolStripButton.Click
        Me.DeplacerLigne()
    End Sub

    Private Sub PositionDeplacementLigneToolStripTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PositionDeplacementLigneToolStripTextBox.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))

        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            Me.DeplacerLigneToolStripButton_Click(sender, Nothing)
        End If
    End Sub
#End Region

#Region "InventaireLignesDataGridView"
    Private Sub InventaireLignesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles InventaireLignesDataGridView.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then

        End If
    End Sub

    Private Sub InventaireLignesDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles InventaireLignesDataGridView.CellValidating
        If Not (InventaireLignesDataGridView.Rows(e.RowIndex).IsNewRow) Then
            'Contrôles sur les colonnes ayant un type Nullable(Of Decimal) ou Nullable(Of Integer)
            Dim column As DataGridViewColumn = Me.InventaireLignesDataGridView.Columns(e.ColumnIndex)
            Dim cell As DataGridViewCell = Me.InventaireLignesDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)

            Me.ControlerColonnes(e, column, cell)
        End If
    End Sub

    Private Sub InventaireLignesDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles InventaireLignesDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité        
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Nullable(Of Decimal)
            If (Me.InventaireLignesDataGridView.Columns(InventaireLignesDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Nullable(Of Decimal))) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contrôle sur les colonnes de type Nullable(Of Integer)
            If (Me.InventaireLignesDataGridView.Columns(InventaireLignesDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Nullable(Of Integer))) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            End If
        End If
    End Sub

    Private Sub InventaireLignesDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles InventaireLignesDataGridView.CellValueChanged
        'Recalculer les cellules calculées
        If (e.RowIndex > -1) Then
            If CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

            Dim invLigne As Inventaire.ClassesMetier.InventaireLignes = CType(CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem, Inventaire.ClassesMetier.InventaireLignes)

            Me.RecalculerCellulesCalculees(invLigne)

            Me.CalculerTotauxGeneraux()
        End If
    End Sub
#End Region

#Region "InventaireLignesBindingSource"
    Private Sub InventaireLignesBindingSource_AddingNew(ByVal sender As System.Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles InventaireLignesBindingSource.AddingNew
        Dim invLignes As New Inventaire.ClassesMetier.InventaireLignes

        invLignes.INVLOrdre = Me.InventaireLignesBindingSource.Count + 1

        'Si le type d'inventaire est "Avances aux cultures", le libellé de la ligne 
        'est le même que celui du groupe
        If (Me._InvGroupes.TypeInventaire.CodeTypeInventaire = My.Resources.CODE_TYPEINV_AVAUXCULTURES) Then

            invLignes.INVLLib = Me._InvGroupes.INVGLib
        End If

        e.NewObject = invLignes
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConstruireTitreForm()
        Dim ApplicationTitle As String

        If Not (String.IsNullOrEmpty(My.Application.Info.Title)) Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Me.Text = ApplicationTitle & " - Lignes du groupe : " & Me._InvGroupes.INVGLib

        Me.LabelTitre.Text = "Lignes du groupe : " & Me._InvGroupes.INVGLib
    End Sub

    Private Sub AfficherColonnes(ByVal INVLQte As Boolean, ByVal INVLPrixUnit As Boolean, _
                                ByVal INVLCoutOutil As Boolean, ByVal INVLCoutTracteur As Boolean, _
                                ByVal INVLValForfaitaire As Boolean, _
                                ByVal INVLTempsH As Boolean, ByVal INVLTempsMin As Boolean, _
                                ByVal INVLNbPass As Boolean, _
                                ByVal INVLNbHa As Boolean, ByVal INVLValPdtenTerre As Boolean, _
                                ByVal INVLValFaconcult As Boolean, ByVal Decote As Boolean, _
                                ByVal ValeurHT As Boolean, _
                                ByVal CoutParHaMethodeDetaillee As Boolean, _
                                ByVal CoutParHaMethodeForfaitaire As Boolean, _
                                ByVal CoutTotalFaconsCulturalesMethodeDetaillee As Boolean, _
                                ByVal CoutTotalFaconsCulturalesMethodeForfaitaire As Boolean, _
                                ByVal ValeurHTAvAuxCultures As Boolean)

        Me.InventaireLignesDataGridView.Columns("INVLQte").Visible = INVLQte
        Me.InventaireLignesDataGridView.Columns("INVLPrixUnit").Visible = INVLPrixUnit
        Me.InventaireLignesDataGridView.Columns("INVLCoutOutil").Visible = INVLCoutOutil
        Me.InventaireLignesDataGridView.Columns("INVLCoutTracteur").Visible = INVLCoutTracteur
        Me.InventaireLignesDataGridView.Columns("INVLValForfaitaire").Visible = INVLValForfaitaire
        Me.InventaireLignesDataGridView.Columns("INVLTempsH").Visible = INVLTempsH
        Me.InventaireLignesDataGridView.Columns("INVLTempsMin").Visible = INVLTempsMin
        Me.InventaireLignesDataGridView.Columns("INVLNbPass").Visible = INVLNbPass
        Me.InventaireLignesDataGridView.Columns("INVLNbHa").Visible = INVLNbHa
        Me.InventaireLignesDataGridView.Columns("INVLValPdtenTerre").Visible = INVLValPdtenTerre
        Me.InventaireLignesDataGridView.Columns("INVLValFaconcult").Visible = INVLValFaconcult
        Me.InventaireLignesDataGridView.Columns("Decote").Visible = Decote
        Me.InventaireLignesDataGridView.Columns("ValeurHT").Visible = ValeurHT
        Me.InventaireLignesDataGridView.Columns("CoutParHaMethodeDetaillee").Visible = CoutParHaMethodeDetaillee
        Me.InventaireLignesDataGridView.Columns("CoutParHaMethodeForfaitaire").Visible = CoutParHaMethodeForfaitaire
        Me.InventaireLignesDataGridView.Columns("CoutTotalFaconsCulturalesMethodeDetaillee").Visible = CoutTotalFaconsCulturalesMethodeDetaillee
        Me.InventaireLignesDataGridView.Columns("CoutTotalFaconsCulturalesMethodeForfaitaire").Visible = CoutTotalFaconsCulturalesMethodeForfaitaire
        Me.InventaireLignesDataGridView.Columns("ValeurHTAvAuxCultures").Visible = ValeurHTAvAuxCultures
    End Sub

    Private Sub FiltrerColonnes()
        Select Case Me._InvGroupes.INVGTypeInventaire
            Case "A", "P"
                Me.AfficherColonnes(True, True, False, False, False, False, False, False, False, False, False, _
                                    True, True, False, False, False, False, False)
            Case "M", "T"
                Me.AfficherColonnes(True, True, False, False, False, False, False, False, False, False, False, _
                                    False, True, False, False, False, False, False)
            Case "F"
                'Recherche de la méthode d'évaluation
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._InvGroupes.INVGDossier)

                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1
                        Me.AfficherColonnes(False, False, True, True, False, True, True, False, True, False, False, _
                                            False, False, True, False, True, False, False)
                    Case My.Resources.M2
                        Me.AfficherColonnes(False, False, False, False, True, False, False, True, True, False, False, _
                                            False, False, False, True, False, True, False)
                End Select
            Case "V"
                Me.AfficherColonnes(False, False, False, False, False, False, False, False, False, True, True, _
                                    False, False, False, False, False, False, True)
            Case Else
                Me.AfficherColonnes(False, False, False, False, False, False, False, False, False, False, False, _
                                    False, False, False, False, False, False, False)
        End Select
    End Sub

    Private Sub ChargerDonnees()
        'Chargement des infos du groupe et des lignes associées dans la base de données
        Dim gestInventaireGroupes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)
        Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = gestInventaireGroupes.GetInventaireGroupes(Me._InvGroupes.INVGDossier, Me._InvGroupes.INVGCode)

        If Not (invGpes Is Nothing) Then
            Me._InvGroupes = invGpes

            'Trier la liste par Order
            Inventaire.ClassesMetier.ListeInventairesLignes.Trier(Me._InvGroupes.ListeInvLignes, "INVLOrdre", SortOrder.Ascending)

            Me.InventaireLignesBindingSource.DataSource = Me._InvGroupes

            'Chargement des totaux généraux
            Me.CalculerTotauxGeneraux()
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        Dim i As Integer = 0

        If (Me.InventaireLignesBindingSource.Count >= 0) Then
            Me.InventaireLignesBindingSource.EndEdit()

            Dim listeInvLignes As New Inventaire.ClassesMetier.ListeInventairesLignes

            'Récupération du contenu des lignes du DataGridView dans une liste d'objets
            For i = 0 To Me.InventaireLignesBindingSource.Count - 1
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireLignes)

                invLignes.INVLOrdre = i + 1

                listeInvLignes.Add(invLignes)
            Next

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim oleDbTrans As OleDbTransaction = Nothing

                Try
                    oleDbConn.Open()

                    oleDbTrans = oleDbConn.BeginTransaction

                    Dim gestInvLignes As New Inventaire.ClassesControleur.GestionnaireInventaireLignes(My.Settings.dbDonneesConnectionString)

                    gestInvLignes.UpdateListeInventairesLignes(listeInvLignes, Me._InvGroupes.INVGDossier, Me._InvGroupes.INVGCode, oleDbTrans)

                    oleDbTrans.Commit()
                    oleDbTrans = Nothing
                Catch ex As Exception
                    If Not (oleDbTrans Is Nothing) Then oleDbTrans.Rollback()

                    Throw ex
                End Try
            End Using

            Me.InventaireLignesBindingSource.ResetBindings(False)
        End If

        Return True
    End Function

    Private Sub SupprimerInventaireLignes()
        If (Me.InventaireLignesDataGridView.SelectedRows.Count > 0) Then
            Dim listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes = Me.GetSelectedRows()

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                Me.InventaireLignesBindingSource.Remove(invLignes)
            Next

            'Enregistrement dans la base de données
            If (Me.Enregistrer()) Then
                'Rechargement des données
                Me.ChargerDonnees()
            End If

            'Calcul des totaux généraux 
            Me.CalculerTotauxGeneraux()
        End If
    End Sub

    Private Function GetSelectedRows() As Inventaire.ClassesMetier.ListeInventairesLignes
        Dim listeInvLignes As New Inventaire.ClassesMetier.ListeInventairesLignes

        For Each row As DataGridViewRow In Me.InventaireLignesDataGridView.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is Inventaire.ClassesMetier.InventaireLignes Then Continue For

            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = DirectCast(row.DataBoundItem, Inventaire.ClassesMetier.InventaireLignes)

            listeInvLignes.Add(invLignes)
        Next

        Return listeInvLignes
    End Function

    Private Sub GererContextMenuStrip1()
        If Not (Me._InvGroupes Is Nothing) Then
            'Gestion des items en fonction du type d'inventaire
            Select Case Me._InvGroupes.INVGTypeInventaire
                Case "F"
                    'Recherche de la méthode d'inventaire
                    Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                    Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._InvGroupes.INVGDossier)

                    Select Case dossier.DMethodeInventaire
                        Case My.Resources.M1 'Detaillée
                            Me.SelectionnerCoutTracteurToolStripButton.Visible = True
                            Me.SelectionnerCoutOutilToolStripButton.Visible = True
                            Me.SelectionnerValeurForfaitaireToolStripButton.Visible = False
                        Case My.Resources.M2 'Forfaitaire
                            Me.SelectionnerCoutTracteurToolStripButton.Visible = False
                            Me.SelectionnerCoutOutilToolStripButton.Visible = False
                            Me.SelectionnerValeurForfaitaireToolStripButton.Visible = True
                    End Select
                    
                    Me.SelectionnerValeurPdtsEnTerreToolStripButton.Visible = False
                    Me.SelectionnerValeurFacCultToolStripButton.Visible = False
                Case "V"
                    Me.SelectionnerCoutTracteurToolStripButton.Visible = False
                    Me.SelectionnerCoutOutilToolStripButton.Visible = False
                    Me.SelectionnerValeurPdtsEnTerreToolStripButton.Visible = True
                    Me.SelectionnerValeurFacCultToolStripButton.Visible = True
                    Me.SelectionnerValeurForfaitaireToolStripButton.Visible = False
                Case Else
                    Me.SelectionnerCoutTracteurToolStripButton.Visible = False
                    Me.SelectionnerCoutOutilToolStripButton.Visible = False
                    Me.SelectionnerValeurPdtsEnTerreToolStripButton.Visible = False
                    Me.SelectionnerValeurFacCultToolStripButton.Visible = False
                    Me.ToolStripSeparator3.Visible = False
                    Me.SelectionnerValeurForfaitaireToolStripButton.Visible = False
            End Select
        End If
    End Sub

    Private Sub RecalculerCellulesCalculees(ByVal invLigne As Inventaire.ClassesMetier.InventaireLignes)
        'Recalculer la valeur HT de la ligne
        invLigne.Decote = Me._InvGroupes.INVGDecote
        invLigne.CalculerValeurHT()

        'Recalculer le coût par Ha méthode détaillée
        invLigne.CalculerCoutParHaMethodeDetaillee()

        'Recalculer le coût par Ha méthode forfaitaire
        invLigne.CalculerCoutParHaMethodeForfaitaire()

        'Recalculer le coût total façons culturales méthode détaillée
            invLigne.CalculerCoutTotalFaconsCulturalesMethodeDetaillee()

        'Recalculer le coût total façons culturales méthode forfaitaire
        invLigne.CalculerCoutTotalFaconsCulturalesMethodeForfaitaire()

        'Recalculer la valeur HT avances aux cultures de la ligne
        invLigne.CalculerValeurHTAvAuxCultures()
    End Sub

    Private Sub OuvrirFormRechercheMateriel(ByVal type_Materiel As Baremes.ClassesMetier.Type_Materiel)
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(Me._InvGroupes.INVGDossier)
        Dim frChoixMat As New FrChoixMateriel(type_Materiel, Me._InvGroupes.INVGDossier, CStr(Microsoft.VisualBasic.Year(CDate(dossier.DDtFinEx))))

        With frChoixMat
            .ShowDialog()

            If Not (frChoixMat.Bareme_AffichageDR Is Nothing) Then
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)
                Dim libelle As String = String.Empty

                'On ne prend que les 25 premiers caractères du libellé de la selection
                If Not (String.IsNullOrEmpty(frChoixMat.Bareme_AffichageDR.LibelleMateriel)) Then
                    libelle = Mid(frChoixMat.Bareme_AffichageDR.LibelleMateriel, 1, 25)
                End If

                Select Case type_Materiel.CODE_TYPE_MATERIEL
                    Case My.Resources.CODE_TYPEMAT_TRACTEUR
                        invLignes.INVLCoutTracteur = frChoixMat.Bareme_AffichageDR.COUT_TOTAL_PAR_HEURE
                    Case My.Resources.CODE_TYPEMAT_OUTIL
                        invLignes.INVLCoutOutil = frChoixMat.Bareme_AffichageDR.COUT_TOTAL_PAR_HEURE
                End Select

                'Traitement du libellé de la ligne
                If String.IsNullOrEmpty(invLignes.INVLLib) Then
                    invLignes.INVLLib = libelle
                Else
                    invLignes.INVLLib = Mid(invLignes.INVLLib & " " & libelle, 1, 50)
                End If

                Me.RecalculerCellulesCalculees(invLignes)
                Me.CalculerTotauxGeneraux()
                Me.InventaireLignesBindingSource.ResetBindings(False)
            End If
        End With
    End Sub

    Private Sub OuvrirFormRechercheValeurForfaitaire()
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(Me._InvGroupes.INVGDossier)
        Dim frChoixValeurForf As New FrChoixValeurForfaitaire(Me._InvGroupes.INVGDossier, CStr(Microsoft.VisualBasic.Year(CDate(dossier.DDtFinEx))))

        With frChoixValeurForf
            .ShowDialog()

            If Not (frChoixValeurForf.Bareme_Forfaitaire_AffichageDR Is Nothing) Then
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)

                'On ne prend que les 50 premiers caractères du libellé de la selection
                If Not (String.IsNullOrEmpty(frChoixValeurForf.Bareme_Forfaitaire_AffichageDR.LIBELLE_FACON_CULTURALE)) Then
                    invLignes.INVLLib = Mid(frChoixValeurForf.Bareme_Forfaitaire_AffichageDR.LIBELLE_FACON_CULTURALE, 1, 50)
                End If

                invLignes.INVLValForfaitaire = frChoixValeurForf.Bareme_Forfaitaire_AffichageDR.VALEUR_FORFAITAIRE

                Me.RecalculerCellulesCalculees(invLignes)
                Me.CalculerTotauxGeneraux()
                Me.InventaireLignesBindingSource.ResetBindings(False)
            End If
        End With
    End Sub

    Private Sub OuvrirFormRechercheValeurAvAuxCult(ByVal typeInvALister As Inventaire.ClassesMetier.TypeInventaire)
        Dim frChoixValeur As New FrChoixValeurAvAuxCult(Me._InvGroupes, typeInvALister)

        With frChoixValeur
            .ShowDialog()

            If Not (frChoixValeur.InvGroupesChoisi Is Nothing) Then
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)

                Select Case typeInvALister.CodeTypeInventaire
                    Case My.Resources.CODE_TYPEINV_STOCKSPRODTERRE
                        invLignes.INVLValPdtenTerre = frChoixValeur.InvGroupesChoisi.TotalValeurHTLignes
                    Case My.Resources.CODE_TYPEINV_FACONSCULTURALES
                        'Recherche de la méthode d'inventaire
                        Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                        Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._InvGroupes.INVGDossier)

                        Select Case dossier.DMethodeInventaire
                            Case My.Resources.M1 'Detaillée
                                invLignes.INVLValFaconcult = frChoixValeur.InvGroupesChoisi.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes
                            Case My.Resources.M2 'Forfaitaire
                                invLignes.INVLValFaconcult = frChoixValeur.InvGroupesChoisi.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes
                        End Select

                End Select

                Me.RecalculerCellulesCalculees(invLignes)
                Me.CalculerTotauxGeneraux()
                Me.InventaireLignesBindingSource.ResetBindings(False)
            End If
        End With
    End Sub

    Private Sub CalculerTotauxGeneraux()
        Dim listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes = CType(Me.InventaireLignesBindingSource.List, Inventaire.ClassesMetier.ListeInventairesLignes)

        Me.DataGridViewTotauxGeneraux.Rows.Clear()

        Select Case Me._InvGroupes.INVGTypeInventaire
            Case "A", "P", "M", "T"
                Me.DataGridViewTotauxGeneraux.Rows.Add("Total général valeur HT", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralValeurHT(listeInvLignes)))
            Case "F"
                'Recherche de la méthode d'inventaire
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._InvGroupes.INVGDossier)
                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1 'Detaillée
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général coûts par ha", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralCoutsParHaMethodeDetaillee(listeInvLignes)))
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général façons culturales", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralCoutsFaconsCulturalesMethodeDetaillee(listeInvLignes)))
                    Case My.Resources.M2 'Forfaitaire
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général coûts par ha", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralCoutsParHaMethodeForfaitaire(listeInvLignes)))
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général façons culturales", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralCoutsFaconsCulturalesMethodeForfaitaire(listeInvLignes)))
                End Select
            Case "V"
                Me.DataGridViewTotauxGeneraux.Rows.Add("Total général valeur HT av. cultures", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireLignes.GetTotalGeneralValeurHTAvAuxCultures(listeInvLignes)))
        End Select

        Me.DataGridViewTotauxGeneraux.ClearSelection()
    End Sub

    Private Sub EditingControlDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = CType(sender, DataGridViewTextBoxEditingControl).Text

        'On s'assure que le point ou la virgule n'a été tapé qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du séparateur décimal utilisé dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub

    Private Sub EditingControlInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub

    Private Sub ControlerColonnes(ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs, _
                                ByVal column As DataGridViewColumn, ByVal cell As DataGridViewCell)

        If (column.ValueType Is GetType(Nullable(Of Decimal))) Or _
        (column.ValueType Is GetType(Nullable(Of Integer))) Then
            If String.IsNullOrEmpty(CStr(e.FormattedValue)) Then
                cell.Value = Nothing
            End If
        End If
    End Sub

    Private Sub MonterLigne()
        Me.InventaireLignesBindingSource.RaiseListChangedEvents = False

        Dim pos As Integer = Me.InventaireLignesBindingSource.Position
        Dim i As Integer = 0

        If (pos = 0) Then Exit Sub

        Dim currentInvLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)

        Me.InventaireLignesBindingSource.Remove(currentInvLignes)

        pos -= 1

        Me.InventaireLignesBindingSource.Insert(pos, currentInvLignes)

        Me.InventaireLignesBindingSource.Position = pos

        Me.InventaireLignesBindingSource.RaiseListChangedEvents = True

        For i = 0 To Me.InventaireLignesBindingSource.Count - 1
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireLignes)

            invLignes.INVLOrdre = i + 1
        Next

        Me.InventaireLignesBindingSource.ResetBindings(False)
    End Sub

    Private Sub DescendreLigne()
        Me.InventaireLignesBindingSource.RaiseListChangedEvents = False

        Dim pos As Integer = Me.InventaireLignesBindingSource.Position
        Dim i As Integer = 0

        If (pos = Me.InventaireLignesBindingSource.Count - 1) Then Exit Sub

        Dim currentInvLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)

        Me.InventaireLignesBindingSource.Remove(currentInvLignes)

        pos += 1

        Me.InventaireLignesBindingSource.Insert(pos, currentInvLignes)

        Me.InventaireLignesBindingSource.Position = pos

        Me.InventaireLignesBindingSource.RaiseListChangedEvents = True

        For i = 0 To Me.InventaireLignesBindingSource.Count - 1
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireLignes)

            invLignes.INVLOrdre = i + 1
        Next

        Me.InventaireLignesBindingSource.ResetBindings(False)
    End Sub

    Private Sub DeplacerLigne()
        Dim i As Integer = 0

        Try
            Me.InventaireLignesBindingSource.RaiseListChangedEvents = False

            Dim posCurrent As Integer = Me.InventaireLignesBindingSource.Position

            If String.IsNullOrEmpty(Me.PositionDeplacementLigneToolStripTextBox.Text) Then Exit Sub

            Dim posDeplacement As Integer = Convert.ToInt32(Me.PositionDeplacementLigneToolStripTextBox.Text)

            If (posDeplacement <= 0 Or posDeplacement > Me.InventaireLignesBindingSource.Count) Then
                MsgBox("Position hors limite.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If

            Dim currentInvLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Current, Inventaire.ClassesMetier.InventaireLignes)

            Me.InventaireLignesBindingSource.Remove(currentInvLignes)

            posCurrent = posDeplacement - 1

            Me.InventaireLignesBindingSource.Insert(posCurrent, currentInvLignes)

            Me.InventaireLignesBindingSource.Position = posCurrent

            Me.InventaireLignesBindingSource.RaiseListChangedEvents = True

            For i = 0 To Me.InventaireLignesBindingSource.Count - 1
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = CType(Me.InventaireLignesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireLignes)

                invLignes.INVLOrdre = i + 1
            Next

            Me.InventaireLignesBindingSource.ResetBindings(False)
        Finally
            Me.PositionDeplacementLigneToolStripTextBox.Text = String.Empty
        End Try
    End Sub
#End Region

End Class