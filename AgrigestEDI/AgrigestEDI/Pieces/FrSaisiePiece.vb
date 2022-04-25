Public Class FrSaisiePiece
    Implements IPrechargement

    Private bFistLoad As Boolean = False
    Private nIndexJournal As Integer = 0
    Private bJumpMontant As Boolean = False

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

    Private bReadOnlyData As Boolean = False
    Public Property ReadOnlyData() As Boolean
        Get
            Return bReadOnlyData
        End Get
        Set(ByVal value As Boolean)
            bReadOnlyData = value
        End Set
    End Property

    Private nNewPieceVar As Integer = 0
    Public Property PieceACharger() As Integer
        Get
            Return nNewPieceVar
        End Get
        Set(ByVal value As Integer)
            nNewPieceVar = value
        End Set
    End Property

    Private _LastNumPieceRec As Integer
    Public ReadOnly Property LastNumPieceRec() As Integer
        Get
            Return _LastNumPieceRec
        End Get
    End Property

    Private _LastDatePieceRec As Date
    Public ReadOnly Property LastDatePieceRec() As Date
        Get
            Return _LastDatePieceRec
        End Get
    End Property

#End Region

#Region "Chargement du dossier"

    ''' <summary>
    ''' lancement de la tache de fond du démarage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork

        Me.PiecesBindingSource.SuspendBinding()
        'Me.LignesBindingSource.SuspendBinding()
        Dim p As Piece = New Piece(False, "")
        Me.ListOfPiecesBindingNavigatorCleanItem.Visible = True
        e.Result = p

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
        'Me.LignesBindingSource.ResumeBinding()
        Me.progressBar.Visible = False

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
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        AddHandler grille.CurrentCompteChanged, AddressOf UpdateSommeCompte
        AddHandler grille.ActiveSaveButton, AddressOf SetListOfPiecesBindingNavigatorSaveItem
        AddHandler grille.ActiveCloseButton, AddressOf SetListOfPiecesBindingNavigatorCloseItem
        AddHandler grille.ReloadTable, AddressOf ChargerComptes
        AddHandler grille.ReloadTableCompte, AddressOf ChargerCompteOnly

        Try
            ConfigNumericControl(NPieceTextBox)

            With Me.dsAgrigest
                Me.TvaTa.Fill(.TVA)
                Me.PlanTypeTableAdapter.Fill(.PlanType)
                Me.ReglesValidationTableAdapter.Fill(.ReglesValidation)
                Me.JournalTableAdapter.Fill(.Journal)
            End With

            ChargerComptes()
            Me.dsAgrigest.Comptes.Columns.Add("CntChild", GetType(Integer), "Count(Child.PlCpt)")
            'Me.CompteBindingSource.Filter = "CCpt<>'48800000' AND CntChild>0"

            Me.ParametrerDatePieceDtp()

            'With My.Dossier.Principal
            '    DatePieceDtp.MinDate = .DateDebutEx
            '    DatePieceDtp.MaxDate = .DateFinEx
            'End With

            progressBar.Visible = False

            If My.Settings.SuggestLibPiece = True Then
                Dim AutoCompleteList As New AutoCompleteStringCollection
                Dim xLib As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                For Each xRow As DataRow In xLib.GetDataByDossier(My.User.Name)
                    AutoCompleteList.Add(xRow("Libelle").ToString)
                Next
                Me.LibelleTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.LibelleTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.LibelleTextBox.AutoCompleteCustomSource = AutoCompleteList
            End If

            If PieceACharger <> 0 Then
                Me.PiecesBindingSource.SuspendBinding()
                'Me.LignesBindingSource.SuspendBinding()
                Dim p As Piece = New Piece(PieceACharger, dDateNewPieceVar)
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
                bFistLoad = True
                Me.PiecesBindingSource.DataSource = p
                Me.PiecesBindingSource.ResumeBinding()
                'Me.LignesBindingSource.ResumeBinding()
            Else
                Me.PiecesBindingSource.SuspendBinding()
                'Me.LignesBindingSource.SuspendBinding()
                Dim p As Piece = New Piece(False, "")
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = True
                Me.PiecesBindingSource.DataSource = p
                Me.PiecesBindingSource.ResumeBinding()
                'Me.LignesBindingSource.ResumeBinding()
            End If

            Me.grille.Dataset = dsAgrigest
            Me.grille.PieceDatasource = Me.PiecesBindingSource.Current
            Dim xJournal As DataRowView = CType(Me.JournalBindingSource.Current, DataRowView)
            Me.grille.JournalCptContre = Convert.ToString(xJournal("JCompteContre"))
            Me.grille.JournalCptContreLib = Convert.ToString(xJournal("JLibelle"))

            If bReadOnlyData Then
                GroupBox1.Enabled = False
                PanelLock.Visible = False
                Me.ListOfPiecesBindingNavigatorCloseItem.Visible = False
                Me.ListOfPiecesBindingNavigatorCloseTVAItem.Visible = False
                Me.ListOfPiecesBindingNavigatorSaveItem.Visible = False
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
                Me.AjouterCompteToolStripButton.Visible = False
                Me.ListOfPiecesBindingNavigatorModeleItem.Visible = False
                Me.ToolStripSeparator1.Visible = False
                Me.ToolStripSeparator2.Visible = False
                Me.CMenuAction.Visible = False
                Me.Text = My.Resources.Strings.Saisie_TextConsultation
                'Me.grille.Enabled = False
                Me.grille.ReadOnlyData = True
            End If

            If PieceACharger <> 0 Then
                grille.Select()
            Else
                JournalComboBox.Select()
            End If
            bFistLoad = False
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    Private Sub FrSaisiePiece_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bReadOnlyData Then
            'If PieceACharger = 0 Then
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then Exit Sub
            If curPiece.Lignes.Count > 0 Then
                Dim sMessage As MsgBoxResult = MsgBox(My.Resources.Strings.EnregistrerLesModifications, MsgBoxStyle.YesNoCancel, My.Resources.Strings.Enregistrement)
                If sMessage = Windows.Forms.DialogResult.Yes Then
                    If EnregistrementPiece() Then
                        e.Cancel = False
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        e.Cancel = True
                    End If
                ElseIf sMessage = Windows.Forms.DialogResult.No Then
                    e.Cancel = False
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Else
                    e.Cancel = True
                End If
            End If
            'End If
        End If
    End Sub
#End Region

#Region "gestion raccourcis clavier"
    Private Sub JournalComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JournalComboBox.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.JournalComboBox.SelectedItem Is Nothing Then
                    JournalActiveControl(False)
                    Me.JournalComboBox.Focus()
                Else
                    Me.NPieceTextBox.Focus()
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub NPieceTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NPieceTextBox.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.DatePieceDtp.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub DatePieceDtp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DatePieceDtp.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.LibelleTextBox.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub chkMontantTTC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkMontantTTC.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.LibelleTextBox.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub LibelleTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LibelleTextBox.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.grille.LignesDgv.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Not bReadOnlyData Then
            If keyData = Keys.Control + Keys.D Then
                Me.grille.CopieLigne()
            ElseIf keyData = Keys.Control + Keys.T Then
                If ListOfPiecesBindingNavigatorCloseTVAItem.Enabled Then Me.grille.ClotureTVA()
            ElseIf keyData = Keys.Control + Keys.E Then
                If ListOfPiecesBindingNavigatorCloseItem.Enabled Then Me.grille.CloturePiece()
            ElseIf keyData = Keys.Control + Keys.N Then
                If ListOfPiecesBindingNavigatorSaveItem.Enabled Then
                    EnregistrementPiece()
                Else
                    MsgBox(My.Resources.Strings.Saisie_VerifSolde, MsgBoxStyle.Information, My.Resources.Strings.Enregistrement)
                End If
            ElseIf keyData = Keys.Control + Keys.F Then
                Me.RechercherCompte()
            ElseIf keyData = Keys.Control + Keys.R Then
                Me.grille.CopierLibelleLigneSup()
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        Return True
    End Function
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerComptes()
        With Me.dsAgrigest
            .EnforceConstraints = False
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
            xRowCompte.CLib = "Choix du compte..."
            xRowCompte.CCptContre = "00000000"
            xRowCompte.C_DC = ""
            Me.dsAgrigest.Comptes.AddComptesRow(xRowCompte)

            'ajout du compte 00000000
            Dim xRowPlanC As dbDonneesDataSet.PlanComptableRow = Me.dsAgrigest.PlanComptable.NewPlanComptableRow()
            xRowPlanC.PlDossier = My.User.Name
            xRowPlanC.PlCpt = "00000000"
            xRowPlanC.PlActi = "0000"
            xRowPlanC.PlLib = "Choix du compte..."
            Me.dsAgrigest.PlanComptable.AddPlanComptableRow(xRowPlanC)
            .EnforceConstraints = True
        End With
    End Sub

    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT COUNT(*) FROM PlanComptable WHERE PlDossier='" + My.User.Name + "'", conn) = 0 Then
                Return False
            Else
                If PieceACharger = 0 And CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                    MsgBox(My.Resources.Strings.Saisie_BlocageCloture, MsgBoxStyle.Exclamation, My.Resources.Strings.ComptabiliteCloturee)
                    Return False
                End If
                Return True
            End If
            conn.Close()
        End Using
    End Function

    Private Sub SetListOfPiecesBindingNavigatorSaveItem(ByVal bAction As Boolean)
        ListOfPiecesBindingNavigatorSaveItem.Enabled = bAction
        CMenuEnregistrer.Enabled = bAction
    End Sub

    Private Sub SetListOfPiecesBindingNavigatorCloseItem(ByVal bAction As Boolean)
        ListOfPiecesBindingNavigatorCloseItem.Enabled = bAction
        CMenuSolde.Enabled = bAction
    End Sub

    Private Function EnregistrementPiece() As Boolean
        Dim res As Boolean = False

        Try
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If Me.grille.LignesDgv.EditingControl IsNot Nothing Then Me.grille.LignesDgv.EndEdit()
            Me.grille.PieceBindingSource.EndEdit()
            Me.PiecesBindingSource.EndEdit()
            Me.grille.CleanLigne(curPiece)
            If curPiece Is Nothing Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                Return False
            ElseIf curPiece.Lignes.Count <= 0 Then
                MsgBox(My.Resources.Strings.Saisie_VeuillezSaisirDesLignes, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                Return False
            ElseIf Not Me.grille.ValidationLigne Then
                MsgBox(My.Resources.Strings.Saisie_LignesEnErreur, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                Return False
            ElseIf Not curPiece.IsEquilibre Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeEquilibre, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                Return False
            Else
                'On ne vérifie la TVA que sur les journeaux d'achat, de vente et de trésorerie
                Select Case typeJournal
                    Case "ac", "ve", "tr"
                        If Not curPiece.IsTVAClosed(dsAgrigest.TVA) Then
                            MsgBox(My.Resources.Strings.Saisie_VeuillezSaisirLaTVA, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                            Return False
                        End If
                End Select
            End If

            If curPiece.Exporte Then
                If My.Settings.BloqueExporte Then
                    MsgBox(My.Resources.Strings.Saisie_PieceDejaExportee, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                    Return False
                Else
                    If MsgBox("Cette pièce a déjà été exportée, voulez-vous quand-même la modifier ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return False
                End If
            End If

            For Each xLigne As Ligne In curPiece.Lignes
                If xLigne.MontantCre.HasValue = False And xLigne.MontantDeb.HasValue = False Then
                    MsgBox(My.Resources.Strings.Saisie_LignesSansMontant, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                    Return False
                End If
            Next
            Cursor.Current = Cursors.WaitCursor
            If curPiece.NPrevPiece <> Nothing Then
                If curPiece.MAJPiece() Then
                    _LastNumPieceRec = curPiece.NPiece
                    _LastDatePieceRec = curPiece.DatePiece
                    If PieceACharger <> 0 Then
                        Me.PieceACharger = curPiece.NPiece
                        Me.NewDatePiece = curPiece.DatePiece
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                    End If
                End If
            Else
                If curPiece.AjoutPiece() Then
                    _LastNumPieceRec = curPiece.NPiece
                    _LastDatePieceRec = curPiece.DatePiece
                    Dim l As New Piece(curPiece.Journal, curPiece.DatePiece)
                    Me.PiecesBindingSource.DataSource = l
                    Me.grille.PieceDatasource = Me.PiecesBindingSource.Current
                    Dim xJournal As DataRowView = CType(Me.JournalBindingSource.Current, DataRowView)
                    Me.grille.JournalCptContre = Convert.ToString(xJournal("JCompteContre"))
                    Me.grille.JournalCptContreLib = Convert.ToString(xJournal("JLibelle"))
                    chkMontantTTC.Checked = False
                        ReloadAllGrid()
                    LibelleTextBox.Focus()
                End If
            End If
            res = True
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return res
    End Function

    Private Sub ReloadAllGrid(Optional ByVal ModifDataPiece As Boolean = False, Optional ByVal ModifDataLigne As Boolean = False, Optional ByVal RepositoryLigne As Boolean = True)
        Me.PiecesBindingSource.ResetBindings(ModifDataPiece)
        Me.LignesBindingSource.ResetBindings(ModifDataLigne)
        If RepositoryLigne Then
            Me.grille.ReloadGridLigne()
        End If
    End Sub

    Private Sub RechercherCompte()
        Using fr As New FrRechercheCompte
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Me.grille.ReadOnlyData = False AndAlso Me.grille.LignesDgv.CurrentCell IsNot Nothing AndAlso Me.grille.LignesDgv.CurrentCell.OwningColumn.Index = Me.grille.Compte.Index Then
                    If fr.Compte <> "" Then
                        Dim xLigne As Ligne = CType(Me.grille.LignesBindingSource.Current, Ligne)
                        xLigne.Compte = fr.Compte
                        Me.grille.LignesDgv.ProcessRightKey(Keys.Enter)
                    End If
                End If
            End If
        End Using
    End Sub

    Private Sub ParametrerDatePieceDtp()
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        If (doss.DDtClotureTVA.HasValue) Then
            Me.DatePieceDtp.MinDate = Microsoft.VisualBasic.DateAdd(DateInterval.Day, 1, CDate(doss.DDtClotureTVA))
        End If
    End Sub
#End Region

#Region "Validation du numéro de la pièce"

    Private Sub NPieceTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NPieceTextBox.Validating

        If NewDatePiece = Nothing AndAlso PieceACharger = 0 Then
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                If CType(dta.ExistPiece(curPiece.Dossier, CInt(NPieceTextBox.Text), curPiece.DatePiece), Integer) = 0 Then
                    e.Cancel = False
                Else
                    MsgBox(My.Resources.Strings.Saisie_NumeroExistant, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDeSaisie)
                    e.Cancel = True
                End If
            End Using
        End If

    End Sub

    Private Sub DatePieceDtp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatePieceDtp.Validated

        If NewDatePiece = Nothing AndAlso PieceACharger = 0 Then
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                If CType(dta.ExistPiece(curPiece.Dossier, CInt(NPieceTextBox.Text), curPiece.DatePiece), Integer) > 0 Then
                    MsgBox(My.Resources.Strings.Saisie_NumeroExistant, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDeSaisie)
                    NPieceTextBox.Focus()
                End If
            End Using
        End If

    End Sub

#End Region

#Region "Activation du datagridview en fonction de la présence d'un journal"

    Private typeJournal As String = ""
    Private Sub JournalComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalComboBox.SelectedIndexChanged
        If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub
        If JournalComboBox.SelectedValue Is Nothing Then Exit Sub
        Dim drvJournal As DataRowView = CType(JournalComboBox.SelectedItem, DataRowView)
        Me.grille.JournalCptContre = Convert.ToString(drvJournal("JCompteContre"))
        Me.grille.JournalCptContreLib = Convert.ToString(drvJournal("JLibelle"))
        typeJournal = Convert.ToString(drvJournal("JType"))

        If JournalComboBox.SelectedValue.ToString = "" Then
            JournalActiveControl(False)
        Else
            JournalActiveControl(True)
            If Not bReadOnlyData Then
                If Not bFistLoad Then
                    Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                    If curPiece.SetDataPieceFromJournal(JournalComboBox.SelectedValue.ToString, CBool(IIf(curPiece.Lignes.Count > 0, True, False))) Then
                        nIndexJournal = JournalComboBox.SelectedIndex
                    Else
                        JournalComboBox.SelectedIndex = nIndexJournal
                    End If
                    bFistLoad = False
                End If
            End If
            Me.PiecesBindingSource.ResetCurrentItem()
            Me.grille.ActionsLigne()
        End If

    End Sub

    Private Sub PiecesBindingSource_BindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles PiecesBindingSource.BindingComplete

        If JournalComboBox Is Nothing Then Exit Sub
        If Not bReadOnlyData Then
            If JournalComboBox.Text = "" OrElse JournalComboBox.SelectedValue.ToString = "" Then
                JournalActiveControl(False)
            Else
                JournalActiveControl(True)
            End If
        End If

    End Sub

    Private Sub JournalActiveControl(ByVal bActive As Boolean)
        Dim bInverseBool As Boolean = CBool(IIf(bActive, False, True))
        PanelLock.Visible = bInverseBool
        Me.grille.Enabled = bActive
        Me.grille.LignesDgv.Enabled = bActive
        NPieceTextBox.Enabled = bActive
        DatePieceDtp.Enabled = bActive
        Me.ListOfPiecesBindingNavigatorModeleItem.Enabled = bActive
    End Sub

#End Region

#Region "Refresh/Paint de la grille, mise à jour des totaux, autorisation sur les cases de saisie"

    Private Sub UpdateSommeCompte(ByVal CurLigne As Ligne)

        Try
            'Gestion des totaux pour le compte en cours
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
                lblCompte.Text = Convert.ToString(drCompte(0)("CLib"))
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

#End Region

#Region "Barre d'outil"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorSaveItem.Click, CMenuEnregistrer.Click
        EnregistrementPiece()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click, CMenuDelete.Click
        Try
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurSuppression)
                Exit Sub
            End If
            If MsgBox(My.Resources.Strings.VerifSuppression, MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDePiece) = MsgBoxResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                curPiece.SuppressionPiece()
                Me.Close()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click, CMenuNew.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim l As New Piece(False, JournalComboBox.Text)
            Me.PiecesBindingSource.DataSource = l
            ReloadAllGrid()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCleanItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCleanItem.Click, CMenuReinitialiser.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim l As New Piece(False, JournalComboBox.Text)
            Me.PiecesBindingSource.DataSource = l
            Me.grille.PieceBindingSource.DataSource = l
            ReloadAllGrid()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCloseTVAItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCloseTVAItem.Click, CMenuTVA.Click
        Me.grille.ClotureTVA()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCloseItem.Click, CMenuSolde.Click
        Me.grille.CloturePiece()
    End Sub

    Private Sub AjouterCompteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterCompteToolStripButton.Click, CMenuCompte.Click
        Using fr As New FrAssistantCreationCompte()
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerComptes()
            End If
        End Using
    End Sub

    Private Sub ModifierCompteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierUnCompteToolStripButton.Click, CMenuModifierCompte.Click
        Using fr As New FrAssistantCreationCompte()
            fr.Mode = FrAssistantCreationCompte.ModeAssistant.Modification
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerComptes()
            End If
        End Using
    End Sub

    Private Sub ListOfPiecesBindingNavigatorModeleItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorModeleItem.Click, CMenuInsertModele.Click
        Using fr As New FrModeleChoix
            If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    'Sortir de l'édition en cours
                    Me.grille.EndEdit()
                    Dim xPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
                    If xPiece.Libelle = "" Then xPiece.Libelle = fr.LibellePiece
                    xPiece.Lignes.AddRange(fr.Resultat)
                    Me.grille.ReloadGridLigne(True)
                Catch ex As Exception
                    Throw New ApplicationException(ex.Message, ex)
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            End If
        End Using
    End Sub

    Private Sub ListOfPiecesBindingNavigatorAddModeleItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorAddModeleItem.Click, CMenuEnregistrerModele.Click
        Try
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then
                MsgBox(My.Resources.Strings.Saisie_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.Modele_CreationDeModele)
                Exit Sub
            End If

            Dim sName As String = LibelleTextBox.Text
            Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                If CType(dta.ExistsModele(CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl, sName), Integer) > 0 Then
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
        Me.RechercherCompte()

        'Using fr As New FrRechercheCompte
        '    If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        If Me.grille.ReadOnlyData = False AndAlso Me.grille.LignesDgv.CurrentCell IsNot Nothing AndAlso Me.grille.LignesDgv.CurrentCell.OwningColumn.Index = Me.grille.Compte.Index Then
        '            If fr.Compte <> "" Then
        '                Dim xLigne As Ligne = CType(Me.grille.LignesBindingSource.Current, Ligne)
        '                xLigne.Compte = fr.Compte
        '                Me.grille.LignesDgv.ProcessRightKey(Keys.Enter)
        '            End If
        '        End If
        '    End If
        'End Using
    End Sub
#End Region

#Region "Gestion du contextmenu"

    'Private Sub AjouterUneLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        Dim curLigne As New Ligne()
    '        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
    '        curPiece.Lignes.Insert(LignesBindingSource.Position, curLigne)
    '        Me.grille.ReloadGridLigne()
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

    'Private Sub SupprimerLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
    '        curPiece.Lignes.RemoveAt(LignesBindingSource.Position)
    '        Me.grille.ReloadGridLigne()
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub


    'Private Sub ModifierLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.LignesBindingSource.Current Is Nothing Then Exit Sub
    '    Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
    '    Using fr As New FrAssistantCreationCompte()
    '        With fr
    '            .Mode = FrAssistantCreationCompte.ModeAssistant.Modification
    '            .nCompte = curLigne.Compte
    '            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                ChargerComptes()
    '            End If
    '        End With
    '    End Using
    'End Sub

    'Private Sub VisualiserLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Me.LignesBindingSource.Current Is Nothing Then Exit Sub
    '    Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
    '    Using fr As New FrVisuCompte()
    '        With fr
    '            .nCompte = curLigne.Compte
    '            .ShowDialog()
    '        End With
    '    End Using

    'End Sub

    'Private Sub CopierLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.grille.CopieLigne()
    'End Sub

#End Region

    Private Sub chkMontantTTC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMontantTTC.CheckedChanged
        Me.grille.MontantTTC = chkMontantTTC.Checked
    End Sub

End Class
