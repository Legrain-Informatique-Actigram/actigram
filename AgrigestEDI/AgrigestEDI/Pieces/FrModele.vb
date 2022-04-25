''' <summary>
''' Classe gérant la forme de la grille de modele
''' </summary>
''' <remarks></remarks>
Public Class FrModele
    Implements IPrechargement

    Private nIndexJournal As Integer = 0
    Private bJumpMontant As Boolean = False

#Region "Property"
    Private sModele As String
    Public Property ModeleNameACharger() As String
        Get
            Return sModele
        End Get
        Set(ByVal value As String)
            sModele = value
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

#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        AddHandler UcGrilleSaisieLignes1.CurrentCompteChanged, AddressOf UpdateSommeCompte
        AddHandler UcGrilleSaisieLignes1.ReloadTable, AddressOf ChargerComptes
        AddHandler UcGrilleSaisieLignes1.ReloadTableCompte, AddressOf ChargerCompteOnly

        Try

            Me.TvaTa.Fill(Me.dsAgrigest.TVA)
            Me.PlanTypeTableAdapter.Fill(Me.dsAgrigest.PlanType)
            Me.JournalTableAdapter.Fill(Me.dsAgrigest.Journal)
            ChargerComptes()
            'ajout du compte 00000000
            Dim xRowCompte As dbDonneesDataSet.ComptesRow = Me.dsAgrigest.Comptes.NewComptesRow()
            xRowCompte.CDossier = My.User.Name
            xRowCompte.CCpt = "00000000"
            xRowCompte.CLib = My.Resources.Strings.PLC_ChoixDuCompte
            xRowCompte.CCptContre = "00000000"
            xRowCompte.C_DC = ""
            Me.dsAgrigest.Comptes.AddComptesRow(xRowCompte)

            'ajout du compte 00000000
            Dim xRowPlanC As dbDonneesDataSet.PlanComptableRow = Me.dsAgrigest.PlanComptable.NewPlanComptableRow()
            xRowPlanC.PlDossier = My.User.Name
            xRowPlanC.PlCpt = "00000000"
            xRowPlanC.PlActi = "0000"
            xRowPlanC.PlLib = My.Resources.Strings.PLC_ChoixDuCompte
            Me.dsAgrigest.PlanComptable.AddPlanComptableRow(xRowPlanC)

            Me.dsAgrigest.Comptes.Columns.Add("CntChild", GetType(Integer), "Count(Child.PlCpt)")
            'Me.CompteBindingSource.Filter = "CCpt<>'48800000' AND CntChild>0"

            progressBar.Visible = False

            If Me.ModeleNameACharger <> "" Then
                Me.PiecesBindingSource.SuspendBinding()
                Me.LignesBindingSource.SuspendBinding()
                Dim p As Modele = New Modele(ModeleNameACharger)
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
                Me.PiecesBindingSource.DataSource = p
                Me.PiecesBindingSource.ResumeBinding()
                Me.LignesBindingSource.ResumeBinding()
            Else
                Me.PiecesBindingSource.SuspendBinding()
                Me.LignesBindingSource.SuspendBinding()
                Dim p As Modele = New Modele
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = True
                Me.PiecesBindingSource.DataSource = p
                Me.PiecesBindingSource.ResumeBinding()
                Me.LignesBindingSource.ResumeBinding()
            End If

            Me.UcGrilleSaisieLignes1.Dataset = dsAgrigest
            Me.UcGrilleSaisieLignes1.PieceDatasource = Me.PiecesBindingSource.Current
            Dim xJournal As DataRowView = CType(Me.JournalBindingSource.Current, DataRowView)
            Me.UcGrilleSaisieLignes1.JournalCptContre = Convert.ToString(xJournal("JCompteContre"))
            Me.UcGrilleSaisieLignes1.JournalCptContreLib = Convert.ToString(xJournal("JLibelle"))
            Me.UcGrilleSaisieLignes1.LignesDgv.Enabled = True

            If bReadOnlyData Then
                GroupBox1.Enabled = False
                PanelLock.Visible = False
                Me.ListOfPiecesBindingNavigatorSaveItem.Visible = False
                Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
                Me.ToolStripSeparator1.Visible = False
                Me.CMenuAction.Visible = False
                Me.Text = "Consultation de la pièce"
                Me.UcGrilleSaisieLignes1.Enabled = False
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    Private Sub FrSaisiePiece_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bReadOnlyData Then
            If ModeleNameACharger = "" Then
                Dim curModele As Modele = CType(Me.PiecesBindingSource.Current, Modele)
                If curModele.Lignes.Count > 0 Then
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
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerComptes()
        With Me.dsAgrigest
            .EnforceConstraints = False
            Me.ComptesTableAdapter.FillByDossier(.Comptes, My.User.Name)
            Me.CompteTotalTableAdapter.FillByDossier(Me.dsAgrigest.CompteTotal, My.User.Name)
            Me.ActivitesTableAdapter.FillByDossier(.Activites, My.User.Name)
            Me.PlcTa.FillByDossier(.PlanComptable, My.User.Name)
            .EnforceConstraints = True
        End With
    End Sub

    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger

        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT COUNT(*) FROM PlanComptable WHERE PlDossier='" + My.User.Name + "'", conn) = 0 Then
                Return False
            Else
                If ModeleNameACharger = "" And CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                    MsgBox(My.Resources.Strings.Saisie_BlocageCloture, MsgBoxStyle.Exclamation, My.Resources.Strings.ComptabiliteCloturee)
                    Return False
                End If
                Return True
            End If
            conn.Close()
        End Using

    End Function

    Private Sub ChargerCompteOnly()
        With Me.dsAgrigest
            .EnforceConstraints = False
            Me.ComptesTableAdapter.FillByDossier(.Comptes, My.User.Name)
            .EnforceConstraints = True
        End With
    End Sub
#End Region

#Region "Refresh/Paint de la grille, mise à jour des totaux, autorisation sur les cases de saisie"
    Private Sub UpdateSommeCompte(ByVal CurLigne As Ligne)
        Try
            'Gestion des totaux pour le compte en cours
            Dim curModele As Modele = CType(Me.PiecesBindingSource.Current, Modele)
            If curModele Is Nothing Then Exit Sub
            If CurLigne Is Nothing Then Exit Sub
            Dim sTotalLigneCredit As Decimal = CurLigne.TotalCredit.GetValueOrDefault(0)
            Dim sTotalLigneDebit As Decimal = CurLigne.TotalDebit.GetValueOrDefault(0)
            If curModele.ExistsInBase Then
                For Each xRow As Ligne In curModele.Lignes
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
                lblActivite.Text = Convert.ToString(drActivite(0)("ALib"))
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
        Me.EnregistrementPiece()
    End Sub

    Private Sub ListOfPiecesBindingNavigatorCleanItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorCleanItem.Click, CMenuReinitialiser.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim l As New Modele
            Me.PiecesBindingSource.DataSource = l
            ReloadAllGrid()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListOfPiecesBindingNavigatorFindCompteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfPiecesBindingNavigatorFindCompteItem.Click
        Using fr As New FrRechercheCompte
            fr.ShowDialog()
        End Using
    End Sub
#End Region

#Region "Gestion du contextmenu"
    Private Sub AjouterUneLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim curLigne As New Ligne()
            Dim curModele As Modele = CType(Me.PiecesBindingSource.Current, Modele)
            curModele.Lignes.Insert(LignesBindingSource.Position, curLigne)
            Me.UcGrilleSaisieLignes1.ReloadGridLigne()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SupprimerLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim curModele As Modele = CType(Me.PiecesBindingSource.Current, Modele)
            curModele.Lignes.RemoveAt(LignesBindingSource.Position)
            Me.UcGrilleSaisieLignes1.ReloadGridLigne()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CopierLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.UcGrilleSaisieLignes1.CopieLigne()
    End Sub
#End Region

#Region "Fonction commune"
    Private Function EnregistrementPiece() As Boolean
        Dim res As Boolean = False
        Try
            Dim curModele As Modele = CType(Me.PiecesBindingSource.Current, Modele)
            If Me.UcGrilleSaisieLignes1.LignesDgv.EditingControl IsNot Nothing Then Me.UcGrilleSaisieLignes1.LignesDgv.EndEdit()
            Me.UcGrilleSaisieLignes1.PieceBindingSource.EndEdit()
            Me.PiecesBindingSource.EndEdit()
            Me.UcGrilleSaisieLignes1.CleanLigne(curModele)
            If curModele Is Nothing Then
                MsgBox(My.Resources.Strings.Modele_ProblemeSelection, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
            Else
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()
                If curModele.PrevModele <> Nothing Then
                    If curModele.AjoutMAJModele(False) Then
                        If ModeleNameACharger <> "" Then
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                        End If
                    End If
                Else
                    If curModele.AjoutMAJModele(True) Then
                        ModeleNameACharger = curModele.Modele
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
            res = True
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return res
    End Function

    Private Sub ReloadAllGrid(Optional ByVal ModifDataPiece As Boolean = False, Optional ByVal ModifDataLigne As Boolean = False, Optional ByVal RepositoryLigne As Boolean = True)
        Me.PiecesBindingSource.ResetBindings(ModifDataPiece)
        Me.LignesBindingSource.ResetBindings(ModifDataLigne)
        If RepositoryLigne Then
            Me.UcGrilleSaisieLignes1.ReloadGridLigne()
        End If
    End Sub

#End Region

    Private Sub LibelleTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LibelleTextBox.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.UcGrilleSaisieLignes1.LignesDgv.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If Not bReadOnlyData Then
                If keyData = Keys.Control + Keys.D Then
                    Me.UcGrilleSaisieLignes1.CopieLigne()
                ElseIf keyData = Keys.Control + Keys.S Then
                    Me.EnregistrementPiece()
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

End Class
