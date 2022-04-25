Public Class FrBordereau
    Implements IPrechargement

    Private bIsLoaded As Boolean = False
    Private bIsCorrectPieces As Boolean = True
    Private nBaseContrePartie As Decimal
    Private chkMontantTTC As ToolStripCheckBox

#Region "Property"
    Private dDateNewPieceVar As Date
    Public Property NewDatePiece() As Date
        Get
            Return dDateNewPieceVar
        End Get
        Set(ByVal value As Date)
            dDateNewPieceVar = value
        End Set
    End Property

    Private bConsultation As Boolean = False
    Public Property Consultation() As Boolean
        Get
            Return bConsultation
        End Get
        Set(ByVal value As Boolean)
            bConsultation = value
        End Set
    End Property

    Private sJournal As String = ""
    Public Property Journal() As String
        Get
            Return sJournal
        End Get
        Set(ByVal value As String)
            sJournal = value
        End Set
    End Property

    Private sJournalCptContre As String = ""
    Public Property JournalCptContre() As String
        Get
            Return sJournalCptContre
        End Get
        Set(ByVal value As String)
            sJournalCptContre = value
        End Set
    End Property

    Private sJournalCptContreLib As String = ""
    Public Property JournalCptContreLib() As String
        Get
            Return sJournalCptContreLib
        End Get
        Set(ByVal value As String)
            sJournalCptContreLib = value
        End Set
    End Property

    Private sJournalLib As String = ""
    Public Property JournalLib() As String
        Get
            Return sJournalLib
        End Get
        Set(ByVal value As String)
            sJournalLib = value
        End Set
    End Property

    Private nNewPieceVar As Integer = 0
    Public Property NewPiece() As Integer
        Get
            Return nNewPieceVar
        End Get
        Set(ByVal value As Integer)
            nNewPieceVar = value
        End Set
    End Property

    Private _ConsultationDateMin As Date
    Public Property ConsultationDateMin() As Date
        Get
            Return _ConsultationDateMin
        End Get
        Set(ByVal value As Date)
            _ConsultationDateMin = value
        End Set
    End Property

    Private _ConsultationDateMax As Date
    Public Property ConsultationDateMax() As Date
        Get
            Return _ConsultationDateMax
        End Get
        Set(ByVal value As Date)
            _ConsultationDateMax = value
        End Set
    End Property

    Private _ResultatListPiece As List(Of Piece)
    Public Property ResultatListPiece() As List(Of Piece)
        Get
            Return _ResultatListPiece
        End Get
        Set(ByVal value As List(Of Piece))
            _ResultatListPiece = value
        End Set
    End Property

#End Region

#Region "Méthodes diverses"
    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT COUNT(*) FROM PlanComptable WHERE PlDossier='" + My.User.Name + "'", conn) = 0 Then
                Return False
            Else
                If AvancedOption Then
                    Dim xJournalForm As New FrSearchJournal
                    If xJournalForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim row As dbDonneesDataSet.JournalRow = xJournalForm.ResultatJournal
                        Me.Journal = Convert.ToString(row("JCodeJournal"))
                        Me.JournalCptContre = Convert.ToString(row("JCompteContre"))
                        Me.JournalCptContreLib = Convert.ToString(row("JLibelle"))
                        Me.JournalLib = Convert.ToString(row("JCodeLibelle"))
                        Me.ConsultationDateMin = xJournalForm.ResultatDateMin
                        Me.ConsultationDateMax = xJournalForm.ResultatDateMax
                        bConsultation = True
                    Else
                        Return False
                    End If
                ElseIf Not AvancedOption And Not CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                    Dim xJournalForm As New FrJournal
                    If xJournalForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim row As dbDonneesDataSet.JournalRow = xJournalForm.Resultat
                        Me.Journal = Convert.ToString(row("JCodeJournal"))
                        Me.JournalCptContre = Convert.ToString(row("JCompteContre"))
                        Me.JournalCptContreLib = Convert.ToString(row("JLibelle"))
                        Me.JournalLib = Convert.ToString(row("JCodeLibelle"))
                    Else
                        Return False
                    End If
                Else
                    MsgBox(My.Resources.Strings.Saisie_BlocageCloture, MsgBoxStyle.Exclamation, My.Resources.Strings.ComptabiliteCloturee)
                    Return False
                End If
                Return True
            End If
        End Using
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If Not bConsultation Then
                If keyData = Keys.Control + Keys.D Then
                    Me.UcGrilleSaisieLignes1.CopieLigne()
                ElseIf keyData = Keys.Control + Keys.T Then
                    ListOfPiecesBindingNavigatorCloseTVAItem_Click(Nothing, Nothing)
                ElseIf keyData = Keys.Control + Keys.E Then
                    If ListOfPiecesBindingNavigatorCloseItem.Enabled Then Me.UcGrilleSaisieLignes1.CloturePiece()
                ElseIf keyData = Keys.Control + Keys.S Then
                    If ListOfPiecesBindingNavigatorSaveItem.Enabled Then
                        EnregistrementPiece(False)
                    Else
                        MsgBox(My.Resources.Strings.Saisie_VerifSolde, MsgBoxStyle.Information, My.Resources.Strings.Enregistrement)
                    End If
                ElseIf keyData = Keys.Control + Keys.N Then
                    If ListOfPiecesBindingNavigatorSaveItem.Enabled Then
                        EnregistrementPiece(True)
                    Else
                        MsgBox(My.Resources.Strings.Saisie_VerifSolde, MsgBoxStyle.Information, My.Resources.Strings.Enregistrement)
                    End If
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
            Return True
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

    Private Sub SetListOfPiecesBindingNavigatorSaveItem(ByVal bAction As Boolean)
        ListOfPiecesBindingNavigatorSaveItem.Enabled = bAction
        CMenuEnregistrer.Enabled = bAction
    End Sub

    Private Sub SetListOfPiecesBindingNavigatorCloseItem(ByVal bAction As Boolean)
        ListOfPiecesBindingNavigatorCloseItem.Enabled = bAction
        CMenuSolde.Enabled = bAction
    End Sub

    Private Sub ChargerComptes()
        With Me.dsAgrigest
            .EnforceConstraints = False
            Me.PiecesTableAdapter.FillByDossier(.Pieces, My.User.Name)
            Me.CompteTotalTableAdapter.FillByDossier(Me.dsAgrigest.CompteTotal, My.User.Name)
            Me.ActivitesTableAdapter.FillByDossier(.Activites, My.User.Name)
            .EnforceConstraints = True

            ChargerCompteOnly()

        End With
    End Sub

    Private Sub ChargerCompteOnly()
        With Me.dsAgrigest
            .EnforceConstraints = False
            Me.ComptesTableAdapter.FillByDossier(.Comptes, My.User.Name)
            Me.PlcTa.FillByDossier(.PlanComptable, My.User.Name)
            'ajout du compte 00000000
            Dim xRowCompte As dbDonneesDataSet.ComptesRow = Me.dsAgrigest.Comptes.NewComptesRow()
            xRowCompte.CDossier = My.User.Name
            xRowCompte.CCpt = "00000000"
            xRowCompte.CLib = My.Resources.Strings.PLC_ChoixDuCompte
            xRowCompte.CCptContre = "00000000"
            xRowCompte.C_DC = ""
            .Comptes.AddComptesRow(xRowCompte)

            'ajout du compte 00000000
            Dim xRowPlanC As dbDonneesDataSet.PlanComptableRow = Me.dsAgrigest.PlanComptable.NewPlanComptableRow()
            xRowPlanC.PlDossier = My.User.Name
            xRowPlanC.PlCpt = "00000000"
            xRowPlanC.PlActi = "0000"
            xRowPlanC.PlLib = My.Resources.Strings.PLC_ChoixDuCompte
            .PlanComptable.AddPlanComptableRow(xRowPlanC)
            .EnforceConstraints = True
        End With
    End Sub

    Private Sub CleanPiece()
        Dim pieces As List(Of Piece) = CType(Me.PiecesBindingSource.DataSource, List(Of Piece))
        Me.PiecesBindingSource.SuspendBinding()
        For i As Integer = pieces.Count - 1 To 0 Step -1
            If pieces(i).Lignes.Count = 1 Then
                If pieces(i).Lignes(0).Compte Is Nothing Or (pieces(i).Lignes(0).MontantCre.HasValue = False And pieces(i).Lignes(0).MontantDeb.HasValue = False) Then
                    pieces.RemoveAt(i)
                End If
            ElseIf pieces(i).Lignes.Count = 0 Then
                pieces.RemoveAt(i)
            End If
        Next
        Me.PiecesBindingSource.ResumeBinding()
    End Sub
#End Region

#Region "Chargement du dossier"

    Private Sub ChargerPiece()
        Dim e As New System.ComponentModel.DoWorkEventArgs(Nothing)
        Dim err As Exception
        Try
            bgWorker_DoWork(Nothing, e)
        Catch ex As Exception
            err = ex
        End Try
        Dim e2 As New System.ComponentModel.RunWorkerCompletedEventArgs(e.Result, err, e.Cancel)
        bgWorker_RunWorkerCompleted(Nothing, e2)
    End Sub

    ''' <summary>
    ''' lancement de la tache de fond du démarage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork

        Me.PiecesBindingSource.SuspendBinding()
        'Me.LignesBindingSource.SuspendBinding()
        'Me.PlcTa.FillByDossier(Me.dsAgrigest.PlanComptable, My.User.Name)
        Dim l As New ListOfPieces
        Dim p As Piece
        If bConsultation Then
            l.ChargerBordereau(Me.ConsultationDateMin, Me.ConsultationDateMax, Me.Journal, Me.JournalCptContre, CType(sender, System.ComponentModel.BackgroundWorker))
            Me.ToolStripSeparator1.Visible = False
            Me.ToolStripSeparator2.Visible = False
            Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
        Else
            If ResultatListPiece Is Nothing Then
                'Me.ListOfPiecesBindingNavigatorCleanItem.Visible = True
                p = New Piece(True, Journal)
                l.AddPiece(p)
            Else
                For Each xPiece As Piece In ResultatListPiece
                    l.AddPiece(xPiece)
                Next
            End If
        End If
        InitContrePartie(l)
        e.Result = l

    End Sub

    ''' <summary>
    ''' récupère le résultat du chargement et fait disparaitre la barre de chargement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted

        Me.PiecesBindingSource.DataSource = e.Result
        Me.PiecesBindingSource.ResumeBinding()
        Me.UcGrilleSaisieLignes1.PieceBindingSource.DataSource = Me.PiecesBindingSource.DataSource
        Me.progressBar.Visible = False

        '

    End Sub

    ''' <summary>
    ''' affiche la barre de progression avec la valeur associé
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged

        Me.progressBar.Visible = True
        Me.progressBar.Value = e.ProgressPercentage

    End Sub
#End Region

#Region "Form"
    Private Sub FrBordereau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        With UcGrilleSaisieLignes1
            AddHandler .CalculContrePartieChanged, AddressOf UpdateContrePartie
            AddHandler .CurrentCompteChanged, AddressOf UpdateSommeCompte
            AddHandler .ActiveSaveButton, AddressOf SetListOfPiecesBindingNavigatorSaveItem
            AddHandler .ActiveCloseButton, AddressOf SetListOfPiecesBindingNavigatorCloseItem
            AddHandler .ReloadTable, AddressOf ChargerComptes
            AddHandler .ReloadTableCompte, AddressOf ChargerCompteOnly
        End With

        With Me.dsAgrigest
            Me.TvaTa.Fill(.TVA)
            Me.PlanTypeTableAdapter.Fill(.PlanType)
            Me.ReglesValidationTableAdapter.Fill(.ReglesValidation)
            ChargerComptes()
            .Comptes.Columns.Add("CntChild", GetType(Integer), "Count(Child.PlCpt)")
        End With

        'With My.Dossier.Principal
        '    Me.PdgvDatePiece.MinDate = .DateDebutEx
        '    Me.PdgvDatePiece.MaxDate = .DateFinEx
        'End With

        progressBar.Visible = False

        With PiecesDgv
            AddHandler .CellParsing, AddressOf dg_CellParsing
            AddHandler .DataError, AddressOf dg_DataError
            AddHandler .MouseDown, AddressOf dg_GestionClicDroit
            If My.Settings.SuggestLibPiece = True Then
                Dim AutoCompleteList As New AutoCompleteStringCollection
                Dim dtaPieces As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                For Each dr As DataRow In dtaPieces.GetDataByDossier(My.User.Name)
                    AutoCompleteList.Add(Convert.ToString(dr("Libelle")))
                Next
                PdgvLibelle.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                PdgvLibelle.AutoCompleteSource = AutoCompleteSource.CustomSource
                PdgvLibelle.AutocompleteString = AutoCompleteList
            End If
            .ConfigAutocompleteCombobox()
        End With

        If Not bConsultation Then
            chkMontantTTC = New ToolStripCheckBox
            chkMontantTTC.Text = My.Resources.Strings.Saisie_CheckSaisieDesMontantsEnTTC
            chkMontantTTC.BackColor = Color.Transparent
            Me.ListOfPiecesBindingNavigator.Items.Add(chkMontantTTC)
        End If

        With Me.UcGrilleSaisieLignes1
            .Dataset = dsAgrigest
            .JournalCptContre = Me.JournalCptContre
            .JournalCptContreLib = Me.JournalCptContreLib
        End With

        If bConsultation Then
            bgWorker.RunWorkerAsync()
        Else
            ChargerPiece()
        End If

        Dim Journal As ToolStripLabel = New ToolStripLabel
        Journal.Text = My.Resources.Strings.Saisie_JournalEnCours + Me.JournalLib + String.Format(My.Resources.Strings.Saisie_SoldeDeBase, nBaseContrePartie)
        Me.ListOfPiecesBindingNavigator.Items.Add(Journal)

        If bConsultation Then
            Me.CMSPieceGrid.Visible = False
            Me.PiecesDgv.AllowUserToAddRows = False
            Me.PiecesDgv.ReadOnly = True
            Me.PiecesDgv.ContextMenuStrip = Me.CMSPieceConsultation
            'Me.PiecesDgv.RowTemplate.ContextMenuStrip = Me.CMSPieceConsultation
            Me.PiecesDgv.RowTemplate.ContextMenuStrip = Nothing
            Me.UcGrilleSaisieLignes1.ReadOnlyData = True
            Me.ListOfPiecesBindingNavigatorCloseItem.Visible = False
            Me.ListOfPiecesBindingNavigatorCloseTVAItem.Visible = False
            Me.ListOfPiecesBindingNavigatorSaveItem.Visible = False
            Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
            Me.ListOfPiecesBindingNavigatorModeleItem.Visible = False
            Me.ListOfPiecesBindingNavigatorAddItem.Visible = False
            Me.AjouterCompteToolStripButton.Visible = False
            Me.ListOfPiecesBindingNavigatorModifPiece.Visible = True
            Me.CMenuModif.Visible = True
            Me.CMenuEnregistrer.Visible = False
            Me.CMenuInsertModele.Visible = False
            Me.CMenuCompte.Visible = False
            Me.CMenuNew.Visible = False
            Me.CMenuReinitialiser.Visible = False
            Me.CMenuSolde.Visible = False
            Me.CMenuTVA.Visible = False
            Me.CMenuModifierUnCompte.Visible = False
            Me.ModifierCompteToolStripButton.Visible = False
            Me.ToolStripSeparator1.Visible = False
            Me.ToolStripSeparator2.Visible = False
            Me.ToolStripSeparator6.Visible = False
            Me.ToolStripSeparator7.Visible = False
            Me.ToolStripSeparator8.Visible = False
            Me.ToolStripSeparator9.Visible = False
            Me.Text = My.Resources.Strings.Saisie_TextConsultationBordereau
            If CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                Me.PiecesDgv.ContextMenuStrip = Nothing
                Me.PiecesDgv.RowTemplate.ContextMenuStrip = Nothing
                Me.ListOfPiecesBindingNavigatorModifPiece.Visible = False
                Me.ListOfPiecesBindingNavigatorDeleteItem.Visible = False
                Me.CMenuModif.Visible = False
                Me.CMenuDelete.Visible = False
            End If
        Else
            'Calcul de la date min de la date de la pièce
            Dim dateClotureTVA As Nullable(Of Date) = Me.GetDDtClotureTVA()

            If (dateClotureTVA.HasValue) Then
                Me.PdgvDatePiece.MinDate = Microsoft.VisualBasic.DateAdd(DateInterval.Day, 1, CDate(dateClotureTVA))
            End If
        End If
    End Sub

    Private Sub FrBordereau_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bConsultation Then
            If NewPiece = 0 Then
                If Me.PiecesBindingSource.Position < 0 Then Exit Sub
                Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                If curPiece Is Nothing Then Exit Sub
                If curPiece.Lignes.Count > 0 Then
                    Dim sMessage As MsgBoxResult = MsgBox(My.Resources.Strings.EnregistrerLesModifications, MsgBoxStyle.YesNoCancel, My.Resources.Strings.Enregistrement)
                    If sMessage = MsgBoxResult.Yes Then
                        If EnregistrementPiece(False) Then
                            e.Cancel = False
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            e.Cancel = True
                        End If
                    ElseIf sMessage = MsgBoxResult.No Then
                        e.Cancel = False
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Validation du numéro de la pièce"

    Private Sub PiecesDgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles PiecesDgv.CellFormatting

        Try
            If PiecesBindingSource.Count <= e.RowIndex Then Exit Sub
            Dim r As DataGridViewRow = PiecesDgv.Rows(e.RowIndex)
            If r.DataBoundItem IsNot Nothing Then
                Dim drv As Piece = CType(r.DataBoundItem, Piece)
                If e.ColumnIndex = PdgvTotalContrePartie.Index Then
                    If drv.SoldeContrePartie >= 0 Then
                        e.CellStyle.ForeColor = Color.Green
                    Else
                        e.CellStyle.ForeColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    Private Sub PiecesDgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles PiecesDgv.CellValidating

        Try
            If e.ColumnIndex = 0 Then
                If NewDatePiece = Nothing AndAlso NewPiece = 0 Then
                    Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                    If curPiece.IsNew Then
                        Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                            If CType(dta.ExistPiece(curPiece.Dossier, CInt(e.FormattedValue), curPiece.DatePiece), Integer) = 0 Then
                                e.Cancel = False
                            Else
                                MsgBox(My.Resources.Strings.Saisie_NumeroExistant, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDeSaisie)
                                e.Cancel = True
                            End If
                        End Using
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

#End Region

#Region "Refresh/Paint de la grille, mise à jour des totaux, autorisation sur les cases de saisie"
    'Ajout TV 20/10/2011
    Private Sub PiecesDgv_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiecesDgv.SelectionChanged
        If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub
        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)

        Dim dateClotureTVA As Nullable(Of Date) = Me.GetDDtClotureTVA()

        If (dateClotureTVA.HasValue) Then
            If (curPiece.DatePiece > CDate(dateClotureTVA)) Then
                Me.CMenuModif.Enabled = True
                Me.CMenuDelete.Enabled = True
                Me.CMSMenuModifConsultPiece.Enabled = True
                Me.ToolStripMenuDeletePiece.Enabled = True
                Me.CMenuModifConsultPiece.Enabled = True
                Me.CMSMenuSupprConsultPiece.Enabled = True
            Else
                Me.CMenuModif.Enabled = False
                Me.CMenuDelete.Enabled = False
                Me.CMSMenuModifConsultPiece.Enabled = False
                Me.ToolStripMenuDeletePiece.Enabled = False
                Me.CMenuModifConsultPiece.Enabled = False
                Me.CMSMenuSupprConsultPiece.Enabled = False
            End If
        End If
    End Sub

    Private Sub PiecesBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PiecesBindingSource.CurrentChanged
        If Not bConsultation Then
            If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If Me.Journal = "" Then
            Else
                Me.UcGrilleSaisieLignes1.LignesDgv.Enabled = True
                ListOfPiecesBindingNavigatorCloseTVAItem.Enabled = True
                ListOfPiecesBindingNavigatorCloseItem.Enabled = True
                ListOfPiecesBindingNavigatorModeleItem.Enabled = True
            End If
        End If

        'Me.UcGrilleSaisieLignes1.PieceDatasource = Me.PiecesBindingSource.Current
        Me.UcGrilleSaisieLignes1.PieceBindingSource.Position = Me.PiecesBindingSource.Position
        Me.UcGrilleSaisieLignes1.ActionsLigne()
        Me.UcGrilleSaisieLignes1.UpdateSommes()

        For Each xRow As DataGridViewRow In PiecesDgv.Rows
            xRow.Cells(PdgvCredit.Index).Tag = "True"
            xRow.Cells(PdgvDebit.Index).Tag = "True"
            xRow.Cells(PdgvTotalContrePartie.Index).Tag = "True"
        Next
    End Sub

    Private Sub PiecesDgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles PiecesDgv.RowsAdded

        For Each xRow As DataGridViewRow In PiecesDgv.Rows
            xRow.Cells(PdgvCredit.Index).Tag = "True"
            xRow.Cells(PdgvDebit.Index).Tag = "True"
            xRow.Cells(PdgvTotalContrePartie.Index).Tag = "True"
        Next
        Me.UcGrilleSaisieLignes1.PieceBindingSource.Position = Me.PiecesBindingSource.Position
        Me.UcGrilleSaisieLignes1.ActionsLigne()
        Me.UcGrilleSaisieLignes1.UpdateSommes()

    End Sub

    Private Sub UpdateSommeCompte(ByVal CurLigne As Ligne)

        Try
            'Gestion des totaux pour le compte en cours
            If Me.PiecesBindingSource.Position < 0 Then Exit Sub
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then Exit Sub
            If CurLigne Is Nothing Then Exit Sub
            Dim sTotalLigneCredit As Decimal = CurLigne.TotalCredit.GetValueOrDefault(0)
            Dim sTotalLigneDebit As Decimal = CurLigne.TotalDebit.GetValueOrDefault(0)
            If curPiece.IsNew Then
                For Each xRow As Ligne In curPiece.Lignes
                    If xRow.Compte = CurLigne.Compte Then
                        If xRow.MontantDeb.HasValue Then
                            sTotalLigneDebit += xRow.MontantDeb.Value
                        ElseIf xRow.MontantCre.HasValue Then
                            sTotalLigneCredit += xRow.MontantCre.Value
                        End If
                    End If
                Next
            End If

            lblCompte.Text = ""
            lblActivite.Text = ""
            Dim drCompte() As DataRow = Me.dsAgrigest.Comptes.Select("CCpt='" + CurLigne.Compte + "'")
            If drCompte.Length > 0 Then
                lblCompte.Text = CurLigne.Compte + " - " + Convert.ToString(drCompte(0)("CLib"))
            End If
            Dim drActivite() As DataRow = Me.dsAgrigest.Activites.Select("AActi='" + CurLigne.ActiviteShowAll + "'")
            If lblCompte.Text <> "" AndAlso drActivite.Length > 0 Then
                If CurLigne.ActiviteShowAll = "0000" Then
                    lblActivite.Text = ""
                Else
                    lblActivite.Text = String.Format("{0} (en {1})", drActivite(0)("ALib"), drActivite(0)("AUnit"))
                End If
            End If

            lblDebit.Text = String.Format("{0:C2}", sTotalLigneDebit)
            lblCredit.Text = String.Format("{0:C2}", sTotalLigneCredit)
            If sTotalLigneDebit > sTotalLigneCredit Then
                lblDebitBalance.Text = String.Format("{0:C2}", sTotalLigneDebit - sTotalLigneCredit)
                lblCreditBalance.Text = ""
            ElseIf sTotalLigneCredit > sTotalLigneDebit Then
                lblDebitBalance.Text = ""
                lblCreditBalance.Text = String.Format("{0:C2}", sTotalLigneCredit - sTotalLigneDebit)
            Else
                lblDebitBalance.Text = ""
                lblCreditBalance.Text = ""
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    Private Sub InitContrePartie(ByVal xListPiece As List(Of Piece))
        If Me.JournalCptContre <> "" Then
            nBaseContrePartie = 0

            Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                Dim dsPLC As New dsPLC
                dsPLC.EnforceConstraints = False
                dta.FillByDossierAndCpt(dsPLC.PlanComptable, My.User.Name, Me.JournalCptContre)
                If dsPLC.PlanComptable.Rows.Count > 0 Then
                    With DirectCast(dsPLC.PlanComptable.Rows(0), dsPLC.PlanComptableRow)
                        nBaseContrePartie += CDec(ReplaceDbNull(.Item("PlRepG_D"), 0)) - CDec(ReplaceDbNull(.Item("PlRepG_C"), 0))
                    End With
                End If
            End Using

            Dim rwsCompteTotal() As dbDonneesDataSet.CompteTotalRow = CType(dsAgrigest.CompteTotal.Select(String.Format("Cpt='{0}' AND Acti='{1}'", Me.JournalCptContre, "0000")), dbDonneesDataSet.CompteTotalRow())
            If rwsCompteTotal.Length > 0 Then
                With rwsCompteTotal(0)
                    nBaseContrePartie += .TotalDebit - .TotalCredit
                End With
            End If
            If bConsultation OrElse ResultatListPiece IsNot Nothing Then
                If xListPiece.Count = 0 Then Exit Sub
                For Each curPiece As Piece In xListPiece
                    nBaseContrePartie -= curPiece.MontantDebContrePartie - curPiece.MontantCreContrePartie
                Next
            End If
        End If
    End Sub

    Private Sub UpdateContrePartie()
        Try
            If Me.PiecesBindingSource.Count = 0 Then Exit Sub

            Dim prevPiece As Piece
            For i As Integer = 0 To Me.PiecesBindingSource.Count - 1
                Dim curPiece As Piece = CType(Me.PiecesBindingSource.Item(i), Piece)
                If curPiece Is Nothing Then Exit For
                If prevPiece Is Nothing Then
                    curPiece.SoldeContrePartie = nBaseContrePartie + curPiece.MontantDebContrePartie - curPiece.MontantCreContrePartie
                Else
                    curPiece.SoldeContrePartie = prevPiece.SoldeContrePartie + curPiece.MontantDebContrePartie - curPiece.MontantCreContrePartie
                End If
                prevPiece = curPiece
            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

#End Region

#Region "Barre d'outil"

    ''' <summary>
    ''' permet de fermer l'application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorSaveItem.Click, CMenuEnregistrer.Click
        If ListOfPiecesBindingNavigatorSaveItem.Enabled Then EnregistrementPiece(True)
    End Sub

    Private Sub ListOfPiecesBindingNavigatorAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorAddItem.Click, CMenuNew.Click
        AjouterPiece()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorDeleteItem.Click, CMenuDelete.Click
        SuppressionPiece()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCleanItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCleanItem.Click, CMenuReinitialiser.Click
        Try
            If MsgBox(My.Resources.Strings.Saisie_VerifResetPiece, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.No Then Exit Sub
            Cursor.Current = Cursors.WaitCursor
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            curPiece.Lignes.Clear()
            ReloadAllGrid(, , False)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCloseTVAItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCloseTVAItem.Click, CMenuTVA.Click
        Me.UcGrilleSaisieLignes1.MontantTTC = chkMontantTTC.ToolStripCheckBoxControl.Checked
        If ListOfPiecesBindingNavigatorCloseTVAItem.Enabled Then Me.UcGrilleSaisieLignes1.ClotureTVA()
        chkMontantTTC.ToolStripCheckBoxControl.Checked = False
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCloseItem.Click, CMenuSolde.Click
        If ListOfPiecesBindingNavigatorCloseItem.Enabled Then Me.UcGrilleSaisieLignes1.CloturePiece()
    End Sub

    Private Sub AjouterCompteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterCompteToolStripButton.Click, CMenuCompte.Click
        Using fr As New FrAssistantCreationCompte()
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerComptes()
            End If
        End Using
    End Sub

    Private Sub ModifierCompteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierCompteToolStripButton.Click, CMenuModifierUnCompte.Click
        Using fr As New FrAssistantCreationCompte()
            fr.Mode = FrAssistantCreationCompte.ModeAssistant.Modification
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerComptes()
            End If
        End Using
    End Sub

    Private Sub ListOfPiecesBindingNavigatorModeleItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorModeleItem.Click, CMenuInsertModele.Click
        Try
            Using fr As New FrModeleChoix
                If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    'Sortir de l'édition en cours
                    Me.UcGrilleSaisieLignes1.EndEdit()
                    Me.UcGrilleSaisieLignes1.CleanLigne()
                    Dim xPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                    If xPiece.Libelle = "" Then xPiece.Libelle = fr.LibellePiece
                    xPiece.Lignes.AddRange(fr.Resultat)
                    Me.UcGrilleSaisieLignes1.ReloadGridLigne(True)
                End If
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorAddModeleItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorAddModeleItem.Click, CMenuEnregistrerModele.Click
        Try

            If Me.PiecesBindingSource.Position < 0 Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurSuppression)
                Exit Sub
            End If
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)

            Dim sName As String = curPiece.Libelle
            Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                If curPiece.Libelle <> "" AndAlso CType(dta.ExistsModele(CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl, sName), Integer) > 0 Then
                    sName += "2"
                End If
                sName = InputBox(My.Resources.Strings.Modele_VeuillezSaisirLeNomDuModele, My.Resources.Strings.Modele_CreationDeModele, sName)
                While CType(dta.ExistsModele(CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl, sName), Integer) > 0
                    sName = InputBox(My.Resources.Strings.Modele_Collision & vbCrLf & My.Resources.Strings.Modele_VeuillezSaisirLeNomDuModele, My.Resources.Strings.Modele_CreationDeModele, sName)
                End While
                If sName <> "" Then
                    Cursor.Current = Cursors.WaitCursor
                    curPiece.SavePieceToModele(sName)
                End If
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorFindCompteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorFindCompteItem.Click, CMenuRecherche.Click
        Using fr As New FrRechercheCompte
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Me.UcGrilleSaisieLignes1.ReadOnlyData = False AndAlso Me.UcGrilleSaisieLignes1.LignesDgv.CurrentCell IsNot Nothing AndAlso Me.UcGrilleSaisieLignes1.LignesDgv.CurrentCell.OwningColumn.Index = Me.UcGrilleSaisieLignes1.Compte.Index Then
                    If fr.Compte <> "" Then
                        Dim xLigne As Ligne = CType(Me.UcGrilleSaisieLignes1.LignesBindingSource.Current, Ligne)
                        xLigne.Compte = fr.Compte
                        Me.UcGrilleSaisieLignes1.LignesDgv.ProcessRightKey(Keys.Enter)
                    End If
                End If
            End If
        End Using
    End Sub

#End Region

#Region "Gestion du contextmenu Piece"

    Private Sub ToolStripMenuAddPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuAddPiece.Click
        AjouterPiece()
    End Sub

    Private Sub ToolStripMenuDeletePiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuDeletePiece.Click
        SuppressionPiece()
    End Sub

    Private Sub ToolStripMenuCopyPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuCopyPiece.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            CleanPiece()
            Dim xPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            Dim xListPiece As List(Of Piece) = CType(Me.PiecesBindingSource.DataSource, List(Of Piece))
            'Me.PiecesBindingSource.SuspendBinding()
            xListPiece.Add(xPiece.Clone(xListPiece(xListPiece.Count - 1).NPiece))
            'Me.PiecesBindingSource.ResumeBinding()
            ReloadAllGrid(True)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Gestion du contextmenu Piece en consultation"

    Private Sub CMenuModifConsultPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSMenuModifConsultPiece.Click, CMenuModifConsultPiece.Click, ListOfPiecesBindingNavigatorModifPiece.Click

        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)

        With New FrSaisiePiece
            .NewDatePiece = curPiece.DatePiece
            .PieceACharger = curPiece.NPiece
            .ReadOnlyData = False
            If .ShowDialog() = Windows.Forms.DialogResult.OK AndAlso Not .ReadOnlyData Then
                If .LastNumPieceRec <> curPiece.NPiece OrElse .LastDatePieceRec <> curPiece.DatePiece Then
                    curPiece.RafraichirBase(.LastNumPieceRec, .LastDatePieceRec)
                Else
                    curPiece.RafraichirBase()
                End If
                ReloadAllGrid(True, , True)
            End If
        End With

    End Sub

    Private Sub ToolStripMenuSupprConsultPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSMenuSupprConsultPiece.Click
        SuppressionPiece()
    End Sub

#End Region

#Region "Méthodes diverses"
    Private Sub AjouterPiece()
        Try
            Cursor.Current = Cursors.WaitCursor
            CleanPiece()
            If Me.PiecesBindingSource.Count = 1 AndAlso CType(Me.PiecesBindingSource.Current, Piece).Lignes.Count = 0 Then Exit Try
            Dim xPiece As Piece = Nothing
            If Me.PiecesBindingSource.Count > 0 Then
                xPiece = CType(Me.PiecesBindingSource.DataSource, List(Of Piece))(Me.PiecesBindingSource.Count - 1)
            End If
            Dim xNewPiece As Piece
            If xPiece Is Nothing Then
                xNewPiece = New Piece(True, Me.Journal)
            Else
                xNewPiece = New Piece(xPiece.Journal, xPiece.DatePiece, xPiece.NPiece)
            End If
            CType(Me.PiecesBindingSource.DataSource, ListOfPieces).Add(xNewPiece)
            ReloadAllGrid(True)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function EnregistrementPiece(ByVal bNewLigne As Boolean) As Boolean
        Dim res As Boolean = False
        Try
            Try
                ValidePiece()
                CleanPiece()
                Me.PiecesBindingSource.Position = 0
                Me.PiecesBindingSource.EndEdit()
                Me.UcGrilleSaisieLignes1.EndEdit()
                If Not bIsCorrectPieces Then
                    MsgBox(My.Resources.Strings.Saisie_ProblemeDateNum, MsgBoxStyle.Exclamation, My.Resources.Strings.Enregistrement)
                ElseIf Me.PiecesBindingSource.Count = 0 Then
                    MsgBox(My.Resources.Strings.Saisie_AucunePiece, MsgBoxStyle.Exclamation)
                Else
                    Cursor.Current = Cursors.WaitCursor
                    Dim xListPiece As List(Of Piece) = CType(Me.PiecesBindingSource.DataSource, List(Of Piece))
                    For Each curPiece As Piece In xListPiece
                        Dim bFind As Boolean = False
                        Me.UcGrilleSaisieLignes1.CleanLigne(curPiece)
                        If curPiece Is Nothing Then
                            MsgBox(My.Resources.Strings.Saisie_PbPieceVide, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                            Exit Try
                        End If
                        For Each xLigne As Ligne In curPiece.Lignes
                            If xLigne.MontantCre.HasValue = False And xLigne.MontantDeb.HasValue = False Then
                                MsgBox(String.Format(My.Resources.Strings.Saisie_LignesSansMontantDansPiece, curPiece.NPiece), MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                                Exit Try
                            End If
                        Next
                        If Not Me.UcGrilleSaisieLignes1.ValidationLigne Then
                            MsgBox(String.Format(My.Resources.Strings.Saisie_LignesEnErreurDansPiece, curPiece.NPiece), MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                            Exit Try
                        ElseIf curPiece.Exporte Then
                            MsgBox(String.Format(My.Resources.Strings.Saisie_PieceDejaExporteDansPiece, curPiece.NPiece), MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                            Exit Try
                        ElseIf Not curPiece.IsEquilibre Then
                            MsgBox(String.Format(My.Resources.Strings.Saisie_ProblemeEquilibrePourPiece, curPiece.NPiece), MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                            Exit Try
                        Else
                            If curPiece.NPrevPiece <> Nothing Then
                                If curPiece.MAJPiece() Then
                                    chkMontantTTC.ToolStripCheckBoxControl.Checked = False
                                End If
                            Else
                                If curPiece.AjoutPiece() Then
                                    chkMontantTTC.ToolStripCheckBoxControl.Checked = False
                                End If
                            End If
                        End If
                    Next
                    If bNewLigne Then
                        Dim xcurPiece As Piece
                        If TypeOf CType(Me.PiecesBindingSource(Me.PiecesBindingSource.Count - 1), Piece) Is Piece Then
                            xcurPiece = CType(Me.PiecesBindingSource(Me.PiecesBindingSource.Count - 1), Piece)
                        Else
                            xcurPiece = CType(Me.PiecesBindingSource.Current, Piece)
                        End If
                        Dim xNewPiece As New Piece(xcurPiece.Journal, xcurPiece.DatePiece, xcurPiece.NPiece)
                        CType(PiecesBindingSource.DataSource, ListOfPieces).Add(xNewPiece)
                        ReloadAllGrid(True, , True)
                    Else
                        ReloadAllGrid()
                        PiecesDgv.Focus()
                    End If
                    res = True
                End If
            Catch ex As Exception
                Throw New ApplicationException(ex.Message, ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            If Not res Then
                ReloadAllGrid()
                PiecesDgv.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return res

    End Function

    Private Sub SuppressionPiece()
        If Me.PiecesBindingSource.Count = 1 Then
            MsgBox(My.Resources.Strings.Saisie_BloquageSupprDernierePiece, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurSuppression)
                Exit Sub
            End If
            If MsgBox(My.Resources.Strings.VerifSuppression, MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDePiece) = MsgBoxResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                    If CType(dta.ExistPiece(curPiece.Dossier, curPiece.NPiece, curPiece.DatePiece), Integer) = 0 Then
                        Me.PiecesBindingSource.RemoveCurrent()
                    Else
                        curPiece.SuppressionPiece()
                        Me.PiecesBindingSource.RemoveCurrent()
                    End If
                End Using
                If Me.PiecesBindingSource.Count = 0 Then
                    AjouterPiece()
                Else
                    ReloadAllGrid()
                End If
                Me.UcGrilleSaisieLignes1.PieceBindingSource.ResetBindings(True)
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ReloadAllGrid(Optional ByVal ModifDataPiece As Boolean = False, Optional ByVal ModifDataLigne As Boolean = False, Optional ByVal RepositoryLigne As Boolean = True)
        Try
            If Me.PiecesBindingSource.Position < 0 Then Exit Sub
            Dim xListPiece As List(Of Piece) = CType(Me.PiecesBindingSource.DataSource, List(Of Piece))
            For Each curPiece As Piece In xListPiece
                If curPiece Is Nothing Then Exit For
                curPiece.SetMontantContrePartie(sJournalCptContre)
            Next
            Me.PiecesBindingSource.ResetBindings(ModifDataPiece)
            Me.UcGrilleSaisieLignes1.LignesBindingSource.ResetBindings(ModifDataLigne)
            Me.UcGrilleSaisieLignes1.LignesBindingSource.Position = 0

            If RepositoryLigne Then
                PiecesDgv.Rows(CInt(IIf(CType(PiecesBindingSource.DataSource, ListOfPieces).Count = 0, 0, CType(PiecesBindingSource.DataSource, ListOfPieces).Count - 1))).Cells(1).Selected = True
                Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                Me.UcGrilleSaisieLignes1.LignesDgv.Rows(CInt(IIf(curPiece.Lignes.Count = 0, 0, curPiece.Lignes.Count - 1))).Cells(2).Selected = True
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Function GetDDtClotureTVA() As Nullable(Of Date)
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        Return doss.DDtClotureTVA
    End Function
#End Region

#Region "Validation de la pièce"

    Private Sub PiecesDgv_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles PiecesDgv.RowValidating
        ValidePiece()
    End Sub

    Private Sub ValidePiece()
        Try
            Cursor.Current = Cursors.WaitCursor
            bIsCorrectPieces = True
            Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                For Each CurPiece As Piece In Me.PiecesBindingSource
                    If CurPiece Is Nothing Then Exit For
                    If CurPiece.IsNew Then
                        If CType(dta.ExistPiece(CurPiece.Dossier, CurPiece.NPiece, CurPiece.DatePiece), Integer) > 0 Then
                            For i As Integer = 0 To PiecesDgv.Rows.Count - 1
                                If PiecesDgv.Rows(i).DataBoundItem Is CurPiece Then
                                    PiecesDgv.Rows(i).Cells(0).Style.BackColor = Color.Red
                                    PiecesDgv.Rows(i).Cells(0).ErrorText = My.Resources.Strings.Saisie_CollisionPiece
                                    PiecesDgv.InvalidateRow(i)
                                    bIsCorrectPieces = False
                                End If
                            Next
                        Else
                            For i As Integer = 0 To PiecesDgv.Rows.Count - 1
                                If PiecesDgv.Rows(i).DataBoundItem Is CurPiece Then
                                    PiecesDgv.Rows(i).Cells(0).Style.BackColor = Color.Empty
                                    PiecesDgv.Rows(i).Cells(0).ErrorText = ""
                                    PiecesDgv.InvalidateRow(i)
                                ElseIf PiecesDgv.Rows(i).DataBoundItem IsNot CurPiece And _
                                CType(PiecesDgv.Rows(i).DataBoundItem, Piece).NPiece = CurPiece.NPiece And _
                                CType(PiecesDgv.Rows(i).DataBoundItem, Piece).DatePiece = CurPiece.DatePiece Then
                                    PiecesDgv.Rows(i).Cells(0).Style.BackColor = Color.Red
                                    PiecesDgv.Rows(i).Cells(0).ErrorText = My.Resources.Strings.Saisie_CollisionPiece
                                    PiecesDgv.InvalidateRow(i)
                                    bIsCorrectPieces = False
                                End If
                            Next
                        End If
                    End If
                Next
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            'Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

End Class