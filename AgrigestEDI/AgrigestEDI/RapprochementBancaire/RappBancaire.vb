Imports CrystalDecisions.CrystalReports.Engine 'Ajout HG 04/06/2010

Public Class RappBancaire
    Private Const _filtreComptesBanque As String = "CCpt LIKE '512*'"
    Private _listeCriteresFiltre As RapprochementBancaire.ListeCriteresFiltre

#Region "Constructeurs"
    Public Sub New()
        Me._listeCriteresFiltre = New RapprochementBancaire.ListeCriteresFiltre()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
    End Sub
#End Region

#Region "Form"
    Private Sub RappBancaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Try
            Cursor.Current = Cursors.WaitCursor

            'vidage des champs critères de filtre
            InitialiserAffichageCriteresFiltre()

            'Charge les comptes banque (512)
            Me.ChargerComptesBanque()

            'Définit le filtre à appliquer à la liste des mouvements
            Me.MouvementsBindingSource.Filter = ConstruireFiltreMvts()

            'Calcule le nouveau code pointage
            Me.labelCodePt.Text = RapprochementBancaire.CodePointage.CreerCodePointage(Me.MouvementsTableAdapter.MaxPointage)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "BindingSource"
    Private Sub ComptesBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComptesBindingSource.CurrentChanged
        Dim solde As Decimal = 0
        Dim compte As String = String.Empty

        If Me.ComptesBindingSource.Current Is Nothing Then Exit Sub

        'Récupération du compte sélectionné 
        Dim dataRowViewComptes As DataRowView = CType(Me.ComptesBindingSource.Current, DataRowView)

        compte = Convert.ToString(dataRowViewComptes("CCpt"))

        'Chargement des mouvements relatifs au compte sélectionné
        Me.ChargerMvts(compte)

        'Chargement du solde comptable du compte
        solde = Me.SoldeCompte(compte)

        Me.labelSoldeCptD.Text = ""
        Me.labelSoldeCptC.Text = ""

        If (solde > 0) Then
            Me.labelSoldeCptD.Text = System.Math.Abs(solde).ToString("C")
        ElseIf (solde < 0) Then
            Me.labelSoldeCptC.Text = System.Math.Abs(solde).ToString("C")
        End If
    End Sub

    Private Sub MouvementsBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvementsBindingSource.CurrentChanged
        'If Me.MouvementsBindingSource.Current Is Nothing Then Exit Sub

        'Mise à jour du solde des écritures pointées
        Me.MettreAJourSoldeEcrPt()

        'mise à jour des totaux du dataGridViewMvts
        Me.MettreAJourTotauxDataGridViewMvts()

        'mise à zéro Solde pointage en cours
        Me.labelSoldePtEnCoursD.Text = ""
        Me.labelSoldePtEnCoursC.Text = ""

        'Affichage des critère du filtre
        Me.InitialiserAffichageCriteresFiltre()
        Me.AfficherCriteresFiltre()
    End Sub

    Private Sub MouvementsBindingSource_ListChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles MouvementsBindingSource.ListChanged
        'Déselectionne les cellules de la liste des mouvements
        Me.dataGridViewMvts.ClearSelection()
    End Sub
#End Region

#Region "RadioButton Filtre"
    Private Sub radioButtonNonPt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonNonPt.CheckedChanged
        'Définit le filtre à appliquer à la liste des mouvements 
        Me.MouvementsBindingSource.Filter = Me.ConstruireFiltreMvts()
    End Sub

    Private Sub radioButtonPt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonPt.CheckedChanged
        'Définit le filtre à appliquer à la liste des mouvements
        Me.MouvementsBindingSource.Filter = Me.ConstruireFiltreMvts()
    End Sub

    Private Sub radioButtonToutes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonToutes.CheckedChanged
        'Définit le filtre à appliquer à la liste des mouvements
        Me.MouvementsBindingSource.Filter = Me.ConstruireFiltreMvts()
    End Sub
#End Region

#Region "DateTimePicker"
    Private Sub dateTimePickerDateMaxEcr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateTimePickerDateMaxEcr.ValueChanged
        'Déselectionne les cellules sélectionnées
        Me.dataGridViewMvts.ClearSelection()

        'Définit le filtre à appliquer à la liste des mouvements
        Me.MouvementsBindingSource.Filter = Me.ConstruireFiltreMvts()
    End Sub

    Private Sub dateTimePickerDatePt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateTimePickerDatePt.ValueChanged
        'Déselectionne les cellules sélectionnées
        Me.dataGridViewMvts.ClearSelection()

        'Gestion des autres éléments du filtre à appliquer
        If (Me.dateTimePickerDatePt.Checked) Then
            Me.radioButtonNonPt.Enabled = False
            Me.radioButtonPt.Enabled = False
            Me.radioButtonToutes.Enabled = False
            Me.dateTimePickerDateMaxEcr.Enabled = False
        Else
            Me.radioButtonNonPt.Enabled = True
            Me.radioButtonPt.Enabled = True
            Me.radioButtonToutes.Enabled = True
            Me.dateTimePickerDateMaxEcr.Enabled = True
        End If

        'Définit le filtre à appliquer à la liste des mouvements
        Me.MouvementsBindingSource.Filter = Me.ConstruireFiltreMvts()
    End Sub
#End Region

#Region "DataGridView Mouvements"
    Private Sub dataGridViewMvts_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridViewMvts.CellMouseDoubleClick
        Dim listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows()

        Me.PointerDepointer(listMvtsRow)
    End Sub

    Private Sub dataGridViewMvts_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dataGridViewMvts.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each dr As DataGridViewRow In Me.dataGridViewMvts.Rows
                If Not IsDBNull(CType(dr.DataBoundItem, DataRowView)("Mpointage")) Then
                    dr.DefaultCellStyle.Font = New Font(dataGridViewMvts.Font, FontStyle.Italic)
                    dr.DefaultCellStyle.ForeColor = Color.Gray
                Else
                    dr.DefaultCellStyle.Font = dataGridViewMvts.DefaultCellStyle.Font
                    dr.DefaultCellStyle.ForeColor = dataGridViewMvts.DefaultCellStyle.ForeColor
                End If
            Next
        End If
    End Sub

    Private Sub dataGridViewMvts_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataGridViewMvts.SelectionChanged
        Dim rws As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows(True)

        If rws.Count > 0 Then
            Me.toolStripMenuItemPointer.Enabled = False
            Me.toolStripMenuItemDepointer.Enabled = True
        Else
            Me.toolStripMenuItemPointer.Enabled = True
            Me.toolStripMenuItemDepointer.Enabled = False
        End If
    End Sub

    Private Sub dataGridViewMvts_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridViewMvts.CellClick
        'mise à jour Solde pointage en cours
        Me.MettreAJourSoldePtEnCours()
    End Sub
#End Region

#Region "Boutons"
    Private Sub buttonPt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPt.Click
        Dim listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows()

        Me.Pointer(listMvtsRow)
    End Sub

    Private Sub buttonDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDept.Click
        Dim listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows()

        Me.Depointer(listMvtsRow)
    End Sub

    Private Sub toolStripButtonQuitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripButtonQuitter.Click
        Me.Close()
    End Sub

    Private Sub toolStripButtonRecharger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripButtonRecharger.Click
        Dim compte As String = String.Empty

        'Chargements des mouvements relatifs au compte sélectionné
        Dim dataRowViewComptes As DataRowView = CType(Me.ComptesBindingSource.Current, DataRowView)

        compte = Convert.ToString(dataRowViewComptes("CCpt"))

        Me.ChargerMvts(compte)
    End Sub

    Private Sub toolStripMenuItemPointer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripMenuItemPointer.Click
        Dim listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows()

        Me.Pointer(listMvtsRow)
    End Sub

    Private Sub toolStripMenuItemDepointer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripMenuItemDepointer.Click
        Dim listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow) = Me.GetSelectedRows()

        Me.Depointer(listMvtsRow)
    End Sub

    Private Sub buttonRechAv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRechAv.Click
        Me.AfficherFenetreRechAv()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub AfficherFenetreRechAv()
        Dim rappBancaireRechAv As New RappBancaireRechAv

        With rappBancaireRechAv
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()
                Try
                    'Déselectionne les cellules sélectionnées
                    Me.dataGridViewMvts.ClearSelection()

                    'vide les champs relatifs au solde de pointage en cours
                    labelSoldePtEnCoursD.Text = ""
                    labelSoldePtEnCoursC.Text = ""

                    'Valorise les critères du filtre pour affichage
                    Me._listeCriteresFiltre.EffacerValeursCriteres()
                    Me._listeCriteresFiltre = rappBancaireRechAv.ListeCritereFiltre

                    'applique le filtre sélectionné dans la fenêtre de recherche avancée
                    Me.MouvementsBindingSource.Filter = rappBancaireRechAv.Filtre

                    'Déselectionne les cellules sélectionnées
                    Me.dataGridViewMvts.ClearSelection()
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            End If
        End With
    End Sub

    Private Sub ChargerComptesBanque()
        'Définit le filtre à appliquer à la liste des comptes
        Me.ComptesBindingSource.Filter = _filtreComptesBanque

        Me.DsPLC.EnforceConstraints = False

        'Par souci de performance, on supprime les expressions des colonnes calculées de la table PlanComptable
        With Me.DsPLC.PlanComptable
            .ActDisplayColumn.Expression = Nothing
            '.ADisplayColumn.Expression = Nothing
            .AQteColumn.Expression = Nothing
            .AUnitColumn.Expression = Nothing
            .CptDisplayColumn.Expression = Nothing
            .CU1Column.Expression = Nothing
            .CU2Column.Expression = Nothing
        End With

        'Remplissage des tables du dataset
        Me.PlanComptableTableAdapter.FillByDossier(Me.DsPLC.PlanComptable, My.User.Name)
        Me.ComptesTableAdapter.FillByDossier(Me.DsPLC.Comptes, My.User.Name)
        Me.ActivitesTableAdapter.FillByDossier(Me.DsPLC.Activites, My.User.Name)

        Me.DsPLC.EnforceConstraints = True
    End Sub

    Private Sub ChargerMvts(ByVal compte As String)
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Try
            With Me.DbDonneesDataSet
                .EnforceConstraints = False
                .Mouvements.Clear()
                .Lignes.Clear()
                .Pieces.Clear()
                Me.PiecesTableAdapter.FillByDossierByCompte(.Pieces, My.User.Name, compte)
                Me.LignesTableAdapter.FillByDossierByCompte(.Lignes, My.User.Name, compte)
                Me.MouvementsTableAdapter.FillByDossierByCompte(.Mouvements, My.User.Name, compte)
                .EnforceConstraints = True
            End With
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function SoldeCompte(ByVal compte As String) As Decimal
        Dim solde As Decimal = 0

        If Not (IsDBNull(Me.MouvementsTableAdapter.SoldeCompte(compte, My.User.Name))) Then
            solde = CDec(Me.MouvementsTableAdapter.SoldeCompte(compte, My.User.Name))
        End If

        Return solde
    End Function

    Private Function SoldeCompteDate(ByVal compte As String, ByVal DtSolde As Date, ByVal dossier As String) As Decimal
        Dim solde As Decimal = 0

        If Not (IsDBNull(Me.MouvementsTableAdapter.SoldeComptedate(compte, DtSolde, dossier))) And (Me.MouvementsTableAdapter.SoldeComptedate(compte, DtSolde, dossier).HasValue) Then
            solde = CDec(Me.MouvementsTableAdapter.SoldeComptedate(compte, DtSolde, dossier))
        End If

        Return solde
    End Function

    Private Function ConstruireFiltreMvts() As String
        Dim filtreMvts As String = String.Empty

        Me._listeCriteresFiltre.EffacerValeursCriteres()

        If (Me.dateTimePickerDatePt.Checked) Then
            filtreMvts = "MDatePointage = #" & Me.dateTimePickerDatePt.Value.ToString("yyyy/MM/dd") & "#"

            Me._listeCriteresFiltre.DatePt = Me.dateTimePickerDatePt.Value.ToString("dd/MM/yyyy")
        Else
            If (Me.radioButtonNonPt.Checked) Then
                filtreMvts = " MPointage IS NULL AND "

                Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TexteNonPt
            ElseIf (Me.radioButtonPt.Checked) Then
                filtreMvts = " MPointage IS NOT NULL AND "

                Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TextePt
            Else
                Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TexteToutes
            End If

            filtreMvts = filtreMvts & " MDate <= #" & Me.dateTimePickerDateMaxEcr.Value.ToString("yyyy/MM/dd") & "# "

            Me._listeCriteresFiltre.DateEcrFin = Me.dateTimePickerDateMaxEcr.Value.ToString("dd/MM/yyyy")
        End If

        Return filtreMvts
    End Function

    Private Function SoldeEcrPt() As Decimal
        Dim solde As Decimal = 0

        If (Me.MouvementsTableAdapter.SoldeEcrPt(My.User.Name).HasValue) Then
            solde = CDec(Me.MouvementsTableAdapter.SoldeEcrPt(My.User.Name))
        End If

        Return solde
    End Function

    Private Function SoldeDataGridViewMvts() As Decimal
        Return Me.TotalDebitsDataGridViewMvts() - Me.TotalCreditsDataGridViewMvts()
    End Function

    Private Function TotalDebitsDataGridViewMvts() As Decimal
        Dim mvtsRow As dbDonneesDataSet.MouvementsRow
        Dim sommeDebits As Decimal = 0

        For Each dataRowViewMvts As DataRowView In Me.MouvementsBindingSource
            mvtsRow = CType(dataRowViewMvts.Row, dbDonneesDataSet.MouvementsRow)

            If Not (mvtsRow.IsMMtDebNull) Then
                sommeDebits = sommeDebits + mvtsRow.MMtDeb
            End If
        Next

        Return sommeDebits
    End Function

    Private Function TotalCreditsDataGridViewMvts() As Decimal
        Dim mvtsRow As dbDonneesDataSet.MouvementsRow
        Dim sommeCredits As Decimal = 0

        For Each dataRowViewMvts As DataRowView In Me.MouvementsBindingSource
            mvtsRow = CType(dataRowViewMvts.Row, dbDonneesDataSet.MouvementsRow)

            If Not (mvtsRow.IsMMtCreNull) Then
                sommeCredits = sommeCredits + mvtsRow.MMtCre
            End If
        Next

        Return sommeCredits
    End Function

    Private Sub MettreAJourSoldeEcrPt()
        Dim soldeEcrPt As Decimal = 0
        Dim soldeDataGridViewMvts As Decimal = 0

        soldeEcrPt = Me.SoldeEcrPt()

        Me.labelSoldeEcrPtD.Text = String.Empty
        Me.labelSoldeEcrPtC.Text = String.Empty

        If (soldeEcrPt > 0) Then
            Me.labelSoldeEcrPtD.Text = System.Math.Abs(soldeEcrPt).ToString("C2")
        ElseIf (soldeEcrPt < 0) Then
            Me.labelSoldeEcrPtC.Text = System.Math.Abs(soldeEcrPt).ToString("C2")
        End If
    End Sub

    Private Sub MettreAJourTotauxDataGridViewMvts()
        Dim totalDebitsDataGridViewMvts As Decimal = 0
        Dim totalCreditsDataGridViewMvts As Decimal = 0
        Dim soldeDataGridViewMvts As Decimal = 0

        Me.labelTotalMvtsD.Text = String.Empty
        Me.labelTotalMvtsC.Text = String.Empty
        Me.labelSoldeMvtsD.Text = String.Empty
        Me.labelSoldeMvtsC.Text = String.Empty

        totalDebitsDataGridViewMvts = Me.TotalDebitsDataGridViewMvts()
        totalCreditsDataGridViewMvts = Me.TotalCreditsDataGridViewMvts()
        soldeDataGridViewMvts = Me.SoldeDataGridViewMvts()

        If (totalDebitsDataGridViewMvts <> 0) Then
            Me.labelTotalMvtsD.Text = System.Math.Abs(totalDebitsDataGridViewMvts).ToString("C2")
        End If

        If (totalCreditsDataGridViewMvts <> 0) Then
            Me.labelTotalMvtsC.Text = System.Math.Abs(totalCreditsDataGridViewMvts).ToString("C2")
        End If

        If (soldeDataGridViewMvts > 0) Then
            Me.labelSoldeMvtsD.Text = System.Math.Abs(soldeDataGridViewMvts).ToString("C2")
        ElseIf (soldeDataGridViewMvts < 0) Then
            Me.labelSoldeMvtsC.Text = System.Math.Abs(soldeDataGridViewMvts).ToString("C2")
        End If
    End Sub

    Private Function GetSelectedRows(Optional ByVal lignesPointees As Boolean = False) As List(Of dbDonneesDataSet.MouvementsRow)
        Dim listeMvtsRow As New List(Of dbDonneesDataSet.MouvementsRow)

        For Each row As DataGridViewRow In Me.dataGridViewMvts.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

            Dim mouvementsRow As dbDonneesDataSet.MouvementsRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, dbDonneesDataSet.MouvementsRow)

            If Not (lignesPointees AndAlso mouvementsRow.IsMPointageNull) Then
                listeMvtsRow.Add(mouvementsRow)
            End If
        Next

        Return listeMvtsRow
    End Function

    Private Sub PointerDepointer(ByVal listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow))
        If (listMvtsRow.Count > 0) Then
            For Each mvtsRow As dbDonneesDataSet.MouvementsRow In listMvtsRow
                If (mvtsRow.IsMPointageNull) Then
                    mvtsRow.MPointage = Me.labelCodePt.Text
                    mvtsRow.MDatePointage = Convert.ToDateTime(Now.ToString("yyyy/MM/dd"))
                Else
                    For Each mvtsRowCodePt As dbDonneesDataSet.MouvementsRow In Me.DbDonneesDataSet.Mouvements.Select(String.Format("MPointage='{0}'", mvtsRow.MPointage))
                        mvtsRowCodePt.SetMPointageNull()
                        mvtsRowCodePt.SetMDatePointageNull()
                    Next
                End If
            Next

            Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet.Mouvements)
            Me.MouvementsBindingSource.ResetBindings(False)

            Me.labelCodePt.Text = RapprochementBancaire.CodePointage.CreerCodePointage(Me.MouvementsTableAdapter.MaxPointage)
        End If
    End Sub

    Private Sub Pointer(ByVal listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow))
        If (listMvtsRow.Count > 0) Then
            For Each mvtsRow As dbDonneesDataSet.MouvementsRow In listMvtsRow
                If (mvtsRow.IsMPointageNull) Then
                    mvtsRow.MPointage = Me.labelCodePt.Text
                    mvtsRow.MDatePointage = Convert.ToDateTime(Now.ToString("yyyy/MM/dd"))
                End If
            Next

            Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet.Mouvements)
            Me.MouvementsBindingSource.ResetBindings(False)

            Me.labelCodePt.Text = RapprochementBancaire.CodePointage.CreerCodePointage(Me.MouvementsTableAdapter.MaxPointage)
        End If
    End Sub

    Private Sub Depointer(ByVal listMvtsRow As List(Of dbDonneesDataSet.MouvementsRow))
        If (listMvtsRow.Count > 0) Then
            For Each mvtsRow As dbDonneesDataSet.MouvementsRow In listMvtsRow
                If mvtsRow.IsMPointageNull Then Continue For

                For Each mvtsRowCodePt As dbDonneesDataSet.MouvementsRow In Me.DbDonneesDataSet.Mouvements.Select(String.Format("MPointage='{0}'", mvtsRow.MPointage))
                    mvtsRowCodePt.SetMPointageNull()
                    mvtsRowCodePt.SetMDatePointageNull()
                Next
            Next

            Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet.Mouvements)
            Me.MouvementsBindingSource.ResetBindings(False)

            Me.labelCodePt.Text = RapprochementBancaire.CodePointage.CreerCodePointage(Me.MouvementsTableAdapter.MaxPointage)
        End If
    End Sub

    Private Function SoldePtEnCours() As Decimal
        Dim solde As Decimal = 0

        If Not (Me.MouvementsBindingSource.Current Is Nothing) Then
            For Each row As DataGridViewRow In Me.dataGridViewMvts.SelectedRows
                If row.DataBoundItem Is Nothing Then Continue For

                If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

                Dim mouvementsRow As dbDonneesDataSet.MouvementsRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, dbDonneesDataSet.MouvementsRow)

                If (mouvementsRow.IsMPointageNull) Then
                    solde = solde + (mouvementsRow.MMtDeb - mouvementsRow.MMtCre)
                End If
            Next
        End If

        Return solde
    End Function

    Private Sub MettreAJourSoldePtEnCours()
        Dim soldePtEnCours As Decimal

        soldePtEnCours = Me.SoldePtEnCours()

        Me.labelSoldePtEnCoursD.Text = String.Empty
        Me.labelSoldePtEnCoursC.Text = String.Empty

        If (soldePtEnCours > 0) Then
            Me.labelSoldePtEnCoursD.Text = System.Math.Abs(soldePtEnCours).ToString("C2")
        ElseIf (soldePtEnCours < 0) Then
            Me.labelSoldePtEnCoursC.Text = System.Math.Abs(soldePtEnCours).ToString("C2")
        End If
    End Sub

    Private Sub InitialiserAffichageCriteresFiltre()
        Me.labelTypeEcr.Text = String.Empty
        Me.labelDateEcr.Text = String.Empty
        Me.labelDatePt.Text = String.Empty
        Me.labelMt.Text = String.Empty
        Me.labelNumPiece.Text = String.Empty
        Me.labelLibelle.Text = String.Empty
    End Sub

    Private Sub AfficherCriteresFiltre()
        Me.InitialiserAffichageCriteresFiltre()

        Me.labelTypeEcr.Text = Me._listeCriteresFiltre.TypeEcr

        If (Me._listeCriteresFiltre.DateEcrFin <> String.Empty And Me._listeCriteresFiltre.DateEcrDeb = String.Empty) Then
            Me.labelDateEcr.Text = " jusqu'au " & Me._listeCriteresFiltre.DateEcrFin
        ElseIf (Me._listeCriteresFiltre.DateEcrFin <> String.Empty And Me._listeCriteresFiltre.DateEcrDeb <> String.Empty) Then
            Me.labelDateEcr.Text = "du " & Me._listeCriteresFiltre.DateEcrDeb & " jusqu'au " & Me._listeCriteresFiltre.DateEcrFin
        End If

        Me.labelDatePt.Text = Me._listeCriteresFiltre.DatePt

        If (Me._listeCriteresFiltre.MontantDeb <> String.Empty And Me._listeCriteresFiltre.MontantFin <> String.Empty) Then
            Me.labelMt.Text = Me._listeCriteresFiltre.SensMontant & " de " & CDec(Replace(Me._listeCriteresFiltre.MontantDeb, ".", ",")).ToString("C2") & " à " & CDec(Replace(Me._listeCriteresFiltre.MontantFin, ".", ",")).ToString("C2")
        ElseIf (Me._listeCriteresFiltre.MontantDeb <> String.Empty And Me._listeCriteresFiltre.MontantFin = String.Empty) Then
            Me.labelMt.Text = Me._listeCriteresFiltre.SensMontant & " " & CDec(Replace(Me._listeCriteresFiltre.MontantDeb, ".", ",")).ToString("C2")
        ElseIf (Me._listeCriteresFiltre.MontantFin <> String.Empty And Me._listeCriteresFiltre.MontantDeb = String.Empty) Then
            Me.labelMt.Text = Me._listeCriteresFiltre.SensMontant & " " & CDec(Replace(Me._listeCriteresFiltre.MontantFin, ".", ",")).ToString("C2")
        End If

        Me.labelNumPiece.Text = Me._listeCriteresFiltre.NumPiece
        Me.labelLibelle.Text = Me._listeCriteresFiltre.Libelle
    End Sub

    Private Sub toolStripButtonImprimerRappBancaire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripButtonImprimerRappBancaire.Click
        Cursor.Current = Cursors.WaitCursor
        'Chargements des mouvements relatifs au compte sélectionné
        Dim dataRowViewComptes As DataRowView = CType(Me.ComptesBindingSource.Current, DataRowView)
        Dim Compte As String = String.Empty
        Dim solde As Decimal = 0
        Dim soldeCptBq As Decimal = 0

        Compte = Convert.ToString(dataRowViewComptes("CCpt"))
        soldeCptBq = SoldeCompteDate(Compte, CDate(Me.dateTimePickerDateMaxEcr.Value), My.User.Name)
        solde = Me.SoldeCompte(Compte)

        Dim ds As DataSet = ImprRappBancaire.GetDataRptRappBancaire(CStr(Me.dateTimePickerDateMaxEcr.Value), Compte)
        Using report As ReportDocument = ImprRappBancaire.PrepareRptPLC(ds, True)
            ImprRappBancaire.AffichDonneesGen(report, solde, soldeCptBq, CStr(Me.dateTimePickerDateMaxEcr.Value))
            Using fr As New EcranCrystal(report)
                fr.ShowDialog()
            End Using
        End Using
        Cursor.Current = Cursors.Default
    End Sub

#End Region

End Class