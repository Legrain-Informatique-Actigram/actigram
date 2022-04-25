Imports System.Data.OleDb

Public Class FrInventaireGroupes

    Private _TypeInventaire As Inventaire.ClassesMetier.TypeInventaire

    Private Const TRANCHECPTINF As String = "20000000"
    Private Const TRANCHECPTSUP As String = "39999999"

#Region "Propriétés"
    Public ReadOnly Property TypeInventaire() As Inventaire.ClassesMetier.TypeInventaire
        Get
            Return Me._TypeInventaire
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal typeInventaire As Inventaire.ClassesMetier.TypeInventaire)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._TypeInventaire = typeInventaire
    End Sub
#End Region

#Region "Form"
    Private Sub FrInventaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.ConstruireTitreForm()
        Me.FiltrerColonnes()
        Me.ChargerDonnees()
    End Sub

    Private Sub FrInventaireGroupes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub AfficherLignesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfficherLignesToolStripButton.Click
        Dim listeInvGrp As Inventaire.ClassesMetier.ListeInventairesGroupes = Me.GetSelectedRows()

        Me.AfficherFormLignes(listeInvGrp)
    End Sub

    Private Sub DupliquerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripButton.Click
        If (MsgBox("Confirmez-vous la duplication ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
            Me.DupliquerGroupes()
        End If
    End Sub

    Private Sub ReprendreDonneesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprendreDonneesToolStripButton.Click
        If (MsgBox("Reprendre les données de l'année précédente ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
            Me.ReprendreDonnees()
        End If
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        Me.Imprimer()
    End Sub

    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
            Me.SupprimerInventaireGroupes()
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
    End Sub
#End Region

#Region "InventaireGroupesDataGridView"
    Private Sub InventaireGroupesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles InventaireGroupesDataGridView.DataError

    End Sub

    Private Sub InventaireGroupesDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles InventaireGroupesDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité 
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Nullable(Of Decimal)
            If (Me.InventaireGroupesDataGridView.Columns(InventaireGroupesDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Nullable(Of Decimal))) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle 
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contrôle sur les colonnes de type Nullable(Of Integer)
            If (Me.InventaireGroupesDataGridView.Columns(InventaireGroupesDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Nullable(Of Integer))) Then
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

    Private Sub InventaireGroupesDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles InventaireGroupesDataGridView.CellValueChanged
        If (e.RowIndex > -1) Then
            If CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

            Dim invGroupe As Inventaire.ClassesMetier.InventaireGroupes = CType(CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem, Inventaire.ClassesMetier.InventaireGroupes)

            'Recalculer le total des lignes
            invGroupe.CalculerTotalValeurHTLignes()

            'Calcul du total cout par Ha des lignes méthode detaillée
            invGroupe.CalculerTotalCoutParHaMethodeDetailleeLignes()

            'Calcul du total cout par Ha des lignes méthode forfaitaire
            invGroupe.CalculerTotalCoutParHaMethodeForfaitaireLignes()

            'Calcul du total coût total façons culturales des lignes méthode détaillée
            invGroupe.CalculerTotalCoutTotalFaconsCulturalesMethodeDetailleeLignes()

            'Calcul du total coût total façons culturales des lignes méthode forfaitaire
            invGroupe.CalculerTotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes()

            'Par défaut lors du choix d'un numéro de compte, l'activité prend la valeur "0000"
            Dim column As DataGridViewColumn = Me.InventaireGroupesDataGridView.Columns(e.ColumnIndex)
            Dim cell As DataGridViewCell = Me.InventaireGroupesDataGridView.Rows(e.RowIndex).Cells("INVGActi")

            If (column.Name = "INVGCpt") Then
                cell.Value = "0000"
            End If

            'Recalcul des totaux généraux
            Me.CalculerTotauxGeneraux()
        End If
    End Sub

    Private Sub InventaireGroupesDataGridView_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles InventaireGroupesDataGridView.RowValidating
        Dim numCpt As String = String.Empty
        Dim acti As String = String.Empty
        Dim column As DataGridViewColumn = Me.InventaireGroupesDataGridView.Columns(e.ColumnIndex)
        Dim cellCompte As DataGridViewCell = Me.InventaireGroupesDataGridView.Rows(e.RowIndex).Cells("INVGCpt")
        Dim cellActi As DataGridViewCell = InventaireGroupesDataGridView.Rows(e.RowIndex).Cells("INVGActi")
        Dim erreurLigne As Boolean = False

        'Vérifie que le numéro de compte est bien renseigné
        If Not (InventaireGroupesDataGridView.Rows(e.RowIndex).IsNewRow) Then
            If (String.IsNullOrEmpty(cellCompte.FormattedValue.ToString())) Then
                cellCompte.ErrorText = "Compte obligatoire"

                erreurLigne = True
            Else
                cellCompte.ErrorText = String.Empty

                erreurLigne = False
            End If
        End If

        'Vérifie la cohérence entre compte et activité de la liste
        If Not (String.IsNullOrEmpty(cellCompte.FormattedValue.ToString())) Then
            numCpt = Convert.ToString(cellCompte.Value)

            If Not (String.IsNullOrEmpty(cellActi.FormattedValue.ToString())) Then
                acti = Convert.ToString(cellActi.Value)
            End If

            If Not (Me.CompteExiste(My.User.Name, numCpt, acti)) Then
                cellCompte.ErrorText = "Incohérence entre compte et activité"
                cellActi.ErrorText = "Incohérence entre compte et activité"

                erreurLigne = True
            Else
                cellCompte.ErrorText = String.Empty
                cellActi.ErrorText = String.Empty

                erreurLigne = False
            End If
        End If

        If (erreurLigne) Then
            Me.InventaireGroupesDataGridView.Rows(e.RowIndex).ErrorText = "Erreur(s) sur la ligne"
        Else
            Me.InventaireGroupesDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        End If
    End Sub

    Private Sub InventaireGroupesDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles InventaireGroupesDataGridView.CellValidating
        If (Me.InventaireGroupesDataGridView.IsCurrentCellDirty) Then
            Dim column As DataGridViewColumn = Me.InventaireGroupesDataGridView.Columns(e.ColumnIndex)
            Dim cellCompte As DataGridViewCell = Me.InventaireGroupesDataGridView.Rows(e.RowIndex).Cells("INVGCpt")
            Dim cellActi As DataGridViewCell = InventaireGroupesDataGridView.Rows(e.RowIndex).Cells("INVGActi")
            Dim erreurLigne As Boolean = False

            'Vérifie que le numéro de compte est bien renseigné
            If (column.Name = "INVGCpt") Then
                Me.VerifierCoherenceCompteActi(cellCompte, cellActi)

                If (String.IsNullOrEmpty(CStr(cellCompte.EditedFormattedValue))) Then
                    cellCompte.ErrorText = "Compte obligatoire"

                    erreurLigne = True
                Else
                    cellCompte.ErrorText = String.Empty

                    erreurLigne = False
                End If
            End If

            'Vérifie la cohérence entre compte et activité de la liste
            If (column.Name = "INVGActi") Then
                If Not (Me.VerifierCoherenceCompteActi(cellCompte, cellActi)) Then
                    erreurLigne = True
                Else
                    erreurLigne = False
                End If
            End If

            If (erreurLigne) Then
                Me.InventaireGroupesDataGridView.Rows(e.RowIndex).ErrorText = "Erreur(s) sur la ligne"
            Else
                Me.InventaireGroupesDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
            End If
        End If
    End Sub
#End Region

#Region "InventaireGroupesBindingSource"
    Private Sub InventaireGroupesBindingSource_AddingNew(ByVal sender As System.Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles InventaireGroupesBindingSource.AddingNew
        Dim invGpes As New Inventaire.ClassesMetier.InventaireGroupes

        invGpes.INVGDossier = String.Empty
        invGpes.INVGOrdre = Me.InventaireGroupesBindingSource.Count + 1
        invGpes.INVGEstControle = False

        e.NewObject = invGpes
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function AfficherFormLignes(ByVal listeInvGrp As Inventaire.ClassesMetier.ListeInventairesGroupes) As Boolean
        'Enregistrement des groupes dans la base de données
        If Not (Me.Enregistrer()) Then
            Return False
        End If

        'Rechargement des données pour recalcul
        Me.ChargerDonnees()

        If (listeInvGrp.Count > 0) Then
            For Each invGrp As Inventaire.ClassesMetier.InventaireGroupes In listeInvGrp
                Dim frInvLignes As New FrInventaireLignes(invGrp)

                With frInvLignes
                    .ShowDialog()

                    'Rechargement des données pour recalcul
                    Me.ChargerDonnees()
                End With
            Next
        End If

        Return True
    End Function

    Private Sub ConstruireTitreForm()
        Dim ApplicationTitle As String

        If Not (String.IsNullOrEmpty(My.Application.Info.Title)) Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Recherche du libellé du type d'inventaire
        Me.Text = ApplicationTitle & " - Groupes de type : " & Me.TypeInventaire.LibelleTypeInventaire

        Me.LabelTitre.Text = "Groupes de type : " & Me.TypeInventaire.LibelleTypeInventaire
    End Sub

    Private Sub AfficherColonnes(ByVal INVGDecote As Boolean, ByVal INVGUnite As Boolean, _
                                ByVal TotalValeurHTLignes As Boolean, _
                                ByVal TotalCoutParHaLignesMethodeDetaillee As Boolean, _
                                ByVal TotalCoutParHaLignesMethodeForfaitaire As Boolean, _
                                ByVal TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes As Boolean, _
                                ByVal TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes As Boolean, _
                                ByVal TotalValeurHTAvAuxCulturesLignes As Boolean)

        Me.InventaireGroupesDataGridView.Columns("INVGDecote").Visible = INVGDecote
        Me.InventaireGroupesDataGridView.Columns("INVGUnite").Visible = INVGUnite
        Me.InventaireGroupesDataGridView.Columns("TotalValeurHTLignes").Visible = TotalValeurHTLignes
        Me.InventaireGroupesDataGridView.Columns("TotalCoutParHaLignesMethodeDetaillee").Visible = TotalCoutParHaLignesMethodeDetaillee
        Me.InventaireGroupesDataGridView.Columns("TotalCoutParHaLignesMethodeForfaitaire").Visible = TotalCoutParHaLignesMethodeForfaitaire
        Me.InventaireGroupesDataGridView.Columns("TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes").Visible = TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes
        Me.InventaireGroupesDataGridView.Columns("TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes").Visible = TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes
        Me.InventaireGroupesDataGridView.Columns("TotalValeurHTAvAuxCulturesLignes").Visible = TotalValeurHTAvAuxCulturesLignes
    End Sub

    Private Sub FiltrerColonnes()
        Select Case Me._TypeInventaire.CodeTypeInventaire
            Case "A", "P"
                Me.AfficherColonnes(True, True, True, False, False, False, False, False)
            Case "M", "T"
                Me.AfficherColonnes(False, True, True, False, False, False, False, False)
            Case "F"
                'Recherche de la méthode d'inventaire
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)

                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1 'Detaillée
                        Me.AfficherColonnes(False, False, False, True, False, True, False, False)
                    Case My.Resources.M2 'Forfaitaire
                        Me.AfficherColonnes(False, False, False, False, True, False, True, False)
                End Select
            Case "V"
                Me.AfficherColonnes(False, False, False, False, False, False, False, True)
            Case Else
                Me.AfficherColonnes(False, False, False, False, False, False, False, False)
        End Select
    End Sub

    Private Sub ChargerDonnees()
        'Chargement du plan comptable
        Me.PlanComptableTableAdapter.FillByPlDossierParTranchePlCpt(Me.DataSetAgrigest.PlanComptable, My.User.Name, TRANCHECPTINF, TRANCHECPTSUP)

        'Chargement des activités
        Me.ActivitesTableAdapter.FillByADossier(Me.DataSetAgrigest.Activites, My.User.Name)

        'Chargement de la liste des groupes
        Me.ChargerGroupes()
    End Sub

    Private Sub ChargerGroupes()
        Dim listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes = Nothing
        Dim gestInvGpes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)

        'Récupération des groupes du dossier pour le type d'inventaire 
        listeInvGpes = gestInvGpes.GetListeInventairesGroupes(My.User.Name, Me._TypeInventaire.CodeTypeInventaire)

        'Trier la liste par Ordre
        Inventaire.ClassesMetier.ListeInventairesGroupes.Trier(listeInvGpes, "INVGOrdre", SortOrder.Ascending)

        Me.InventaireGroupesBindingSource.DataSource = listeInvGpes

        Me.InventaireGroupesBindingSource.ResetBindings(True)

        'calcul des totaux généraux
        Me.CalculerTotauxGeneraux()
    End Sub

    Private Function CompteExiste(ByVal DDossier As String, ByVal compte As String, ByVal activite As String) As Boolean
        Using PlanComptableTA As New DataSetAgrigestTableAdapters.PlanComptableTableAdapter
            If (CInt(PlanComptableTA.NbComptes(DDossier, compte, activite)) > 0) Then
                Return True
            End If
        End Using

        Return False
    End Function

    Private Function Enregistrer() As Boolean
        Dim i As Integer = 0

        If (Me.InventaireGroupesBindingSource.Count >= 0) Then
            Me.InventaireGroupesBindingSource.AddNew()
            Me.InventaireGroupesBindingSource.RemoveCurrent()

            Me.InventaireGroupesBindingSource.EndEdit()

            If Not (Me.LignesValides()) Then
                MsgBox("Enregistrement impossible." & Microsoft.VisualBasic.vbCrLf & "Au moins une ligne est en erreur.", MsgBoxStyle.Critical, "")

                Return False
            End If

            Dim listeInventairesGroupes As New Inventaire.ClassesMetier.ListeInventairesGroupes

            'Récupération du contenu des lignes du DataGridView dans une liste d'objets
            For i = 0 To Me.InventaireGroupesBindingSource.Count - 1
                Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireGroupes)

                invGpes.INVGOrdre = i + 1

                listeInventairesGroupes.Add(invGpes)
            Next

            'Mise à jour de la liste dans la base de données
            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim oleDbTrans As OleDbTransaction = Nothing
                Dim gestInvGpes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)

                Try
                    oleDbConn.Open()

                    oleDbTrans = oleDbConn.BeginTransaction

                    gestInvGpes.UpdateListeInventairesGroupes(listeInventairesGroupes, My.User.Name, Me._TypeInventaire.CodeTypeInventaire, oleDbTrans)

                    oleDbTrans.Commit()
                    oleDbTrans = Nothing

                    Return True
                Catch ex As Exception
                    If Not (oleDbTrans Is Nothing) Then oleDbTrans.Rollback()

                    Return False

                    Throw ex
                End Try
            End Using

            Me.InventaireGroupesBindingSource.ResetBindings(False)
        End If

        Return True
    End Function

    Private Function LignesValides() As Boolean
        For Each dgvr As DataGridViewRow In Me.InventaireGroupesDataGridView.Rows
            If Not (String.IsNullOrEmpty(dgvr.ErrorText)) Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub SupprimerInventaireGroupes()
        Me.InventaireGroupesBindingSource.EndEdit()

        If (Me.InventaireGroupesDataGridView.SelectedRows.Count > 0) Then
            Dim listeInvGrp As Inventaire.ClassesMetier.ListeInventairesGroupes = Me.GetSelectedRows()

            For Each invGrp As Inventaire.ClassesMetier.InventaireGroupes In listeInvGrp
                Me.InventaireGroupesBindingSource.Remove(invGrp)
            Next

            'Enregistrement dans la base de données
            If (Me.Enregistrer()) Then
                'Rechargement des données
                Me.ChargerGroupes()
            End If

            'Calcul des totaux généraux
            Me.CalculerTotauxGeneraux()
        End If
    End Sub

    Private Function GetSelectedRows() As Inventaire.ClassesMetier.ListeInventairesGroupes
        Dim listeInvGrp As New Inventaire.ClassesMetier.ListeInventairesGroupes

        For Each row As DataGridViewRow In Me.InventaireGroupesDataGridView.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is Inventaire.ClassesMetier.InventaireGroupes Then Continue For

            Dim invGrp As Inventaire.ClassesMetier.InventaireGroupes = DirectCast(row.DataBoundItem, Inventaire.ClassesMetier.InventaireGroupes)

            listeInvGrp.Add(invGrp)
        Next

        Return listeInvGrp
    End Function

    Private Sub ReprendreDonnees()
        Dim DDossierPrec As String = String.Empty

        'Récupération du code du dossier precedent
        Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)

        DDossierPrec = gestDossiers.GetDDossierPrecedent(doss)

        If Not (String.IsNullOrEmpty(DDossierPrec)) Then
            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim oleDbTrans As OleDbTransaction = Nothing

                Try
                    oleDbConn.Open()

                    oleDbTrans = oleDbConn.BeginTransaction

                    Dim gestInvGpes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)

                    gestInvGpes.ReprendreDonneesDeDossierPrecedent(DDossierPrec, My.User.Name, Me._TypeInventaire.CodeTypeInventaire)

                    oleDbTrans.Commit()
                    oleDbTrans = Nothing
                Catch ex As Exception
                    If Not (oleDbTrans Is Nothing) Then oleDbTrans.Rollback()

                    Throw ex
                End Try

                Me.ChargerDonnees()
            End Using

            Me.InventaireGroupesBindingSource.ResetBindings(False)
        Else
            MsgBox("Pas de dossier précédent.", MsgBoxStyle.Exclamation, "")
        End If
    End Sub

    Private Sub CalculerTotauxGeneraux()
        Dim listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes = CType(Me.InventaireGroupesBindingSource.List, Inventaire.ClassesMetier.ListeInventairesGroupes)

        Me.DataGridViewTotauxGeneraux.Rows.Clear()

        Select Case Me._TypeInventaire.CodeTypeInventaire
            Case "A", "P", "M", "T"
                Me.DataGridViewTotauxGeneraux.Rows.Add("Total général valeur HT", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralValeurHT(listeInvGpes)))
            Case "F"
                'Recherche de la méthode d'inventaire
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)

                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1 'Detaillée
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général coûts par ha", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralCoutsParHaMethodeDetaillee(listeInvGpes)))
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général façons culturales", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralCoutsFaconsCulturalesMethodeDetaillee(listeInvGpes)))
                    Case My.Resources.M2 'Forfaitaire
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général coûts par ha", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralCoutsParHaMethodeForfaitaire(listeInvGpes)))
                        Me.DataGridViewTotauxGeneraux.Rows.Add("Total général façons culturales", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralCoutsFaconsCulturalesMethodeForfaitaire(listeInvGpes)))
                End Select
                
            Case "V"
                Me.DataGridViewTotauxGeneraux.Rows.Add("Total général valeur HT av. cultures", String.Format("{0:C2}", Inventaire.ClassesControleur.GestionnaireInventaireGroupes.GetTotalGeneralValeurHTAvAuxCultures(listeInvGpes)))
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

    Private Function VerifierCoherenceCompteActi(ByVal cellCompte As DataGridViewCell, ByVal cellActi As DataGridViewCell) As Boolean
        Dim numCpt As String = String.Empty
        Dim acti As String = String.Empty

        If Not (String.IsNullOrEmpty(cellCompte.FormattedValue.ToString())) Then
            numCpt = Convert.ToString(cellCompte.FormattedValue)

            If Not (String.IsNullOrEmpty(cellActi.EditedFormattedValue.ToString())) Then
                acti = Convert.ToString(cellActi.EditedFormattedValue)
            End If

            If Not (Me.CompteExiste(My.User.Name, numCpt, acti)) Then
                cellCompte.ErrorText = "Incohérence entre compte et activité"
                cellActi.ErrorText = "Incohérence entre compte et activité"

                Return False
            Else
                cellCompte.ErrorText = String.Empty
                cellActi.ErrorText = String.Empty

                Return True
            End If
        End If

        Return True
    End Function

    Private Sub DupliquerGroupes()
        Dim gestInvGpes As New Inventaire.ClassesControleur.GestionnaireInventaireGroupes(My.Settings.dbDonneesConnectionString)
        Dim listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes = Me.GetSelectedRows()

        If (gestInvGpes.DupliquerListeInventairesGroupes(listeInvGpes)) Then
            Me.ChargerGroupes()

            MsgBox("Duplication terminée.", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub Imprimer()
        Dim nomEtat As String = String.Empty
        Dim impressionDS As DataSetImpression = Nothing

        'Enregistrement des groupes dans la base de données
        If Not (Me.Enregistrer()) Then
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        Select Case Me._TypeInventaire.CodeTypeInventaire
            Case "A", "M", "P", "T"
                nomEtat = "EtListeInv.rpt"
            Case "F"
                'Recherche de la méthode d'inventaire
                Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)

                Select Case dossier.DMethodeInventaire
                    Case My.Resources.M1 'Detaillée
                        nomEtat = "EtListeInvFaconCulturale.rpt"
                    Case My.Resources.M2 'Forfaitaire
                        nomEtat = "EtListeInvFaconCulturaleForf.rpt"
                End Select
            Case "V"
                nomEtat = "EtListeInvAvCult.rpt"
        End Select

        impressionDS = Inventaire.ClassesMetier.ImprInventaire.GetDataByTypeInvEtINVGDossier(Me._TypeInventaire.CodeTypeInventaire, My.User.Name)

        Using rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument = Inventaire.ClassesMetier.ImprInventaire.PrepareRpt(impressionDS, nomEtat, My.User.Name)
            Using fr As New EcranCrystal(rpt)
                fr.ShowDialog()
            End Using
        End Using

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MonterLigne()
        Me.InventaireGroupesBindingSource.RaiseListChangedEvents = False

        Dim pos As Integer = Me.InventaireGroupesBindingSource.Position
        Dim i As Integer = 0

        If (pos = 0) Then Exit Sub

        Dim currentInvGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Current, Inventaire.ClassesMetier.InventaireGroupes)

        Me.InventaireGroupesBindingSource.Remove(currentInvGpes)

        pos -= 1

        Me.InventaireGroupesBindingSource.Insert(pos, currentInvGpes)

        Me.InventaireGroupesBindingSource.Position = pos

        Me.InventaireGroupesBindingSource.RaiseListChangedEvents = True

        For i = 0 To Me.InventaireGroupesBindingSource.Count - 1
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireGroupes)

            invGpes.INVGOrdre = i + 1
        Next

        Me.InventaireGroupesBindingSource.ResetBindings(False)
    End Sub

    Private Sub DescendreLigne()
        Me.InventaireGroupesBindingSource.RaiseListChangedEvents = False

        Dim pos As Integer = Me.InventaireGroupesBindingSource.Position
        Dim i As Integer = 0

        If (pos = Me.InventaireGroupesBindingSource.Count - 1) Then Exit Sub

        Dim currentInvGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Current, Inventaire.ClassesMetier.InventaireGroupes)

        Me.InventaireGroupesBindingSource.Remove(currentInvGpes)

        pos += 1

        Me.InventaireGroupesBindingSource.Insert(pos, currentInvGpes)

        Me.InventaireGroupesBindingSource.Position = pos

        Me.InventaireGroupesBindingSource.RaiseListChangedEvents = True

        For i = 0 To Me.InventaireGroupesBindingSource.Count - 1
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireGroupes)

            invGpes.INVGOrdre = i + 1
        Next

        Me.InventaireGroupesBindingSource.ResetBindings(False)
    End Sub

    Private Sub DeplacerLigne()
        Dim i As Integer = 0

        Try
            Me.InventaireGroupesBindingSource.RaiseListChangedEvents = False

            Dim posCurrent As Integer = Me.InventaireGroupesBindingSource.Position

            If String.IsNullOrEmpty(Me.PositionDeplacementLigneToolStripTextBox.Text) Then Exit Sub

            Dim posDeplacement As Integer = Convert.ToInt32(Me.PositionDeplacementLigneToolStripTextBox.Text)

            If (posDeplacement <= 0 Or posDeplacement > Me.InventaireGroupesBindingSource.Count) Then
                MsgBox("Position hors limite.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If

            Dim currentInvGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Current, Inventaire.ClassesMetier.InventaireGroupes)

            Me.InventaireGroupesBindingSource.Remove(currentInvGpes)

            posCurrent = posDeplacement - 1

            Me.InventaireGroupesBindingSource.Insert(posCurrent, currentInvGpes)

            Me.InventaireGroupesBindingSource.Position = posCurrent

            Me.InventaireGroupesBindingSource.RaiseListChangedEvents = True

            For i = 0 To Me.InventaireGroupesBindingSource.Count - 1
                Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = CType(Me.InventaireGroupesBindingSource.Item(i), Inventaire.ClassesMetier.InventaireGroupes)

                invGpes.INVGOrdre = i + 1
            Next

            Me.InventaireGroupesBindingSource.ResetBindings(False)
        Finally
            Me.PositionDeplacementLigneToolStripTextBox.Text = String.Empty
        End Try
    End Sub
#End Region

End Class