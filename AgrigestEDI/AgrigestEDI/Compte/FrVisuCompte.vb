Imports CrystalDecisions.CrystalReports.Engine

Public Class FrVisuCompte
    Implements IPrechargement

    Public nCompte As String = ""
    Public nActivite As String = ""
    Private bComboSelected As Boolean = False

#Region "Page"
    Private Sub FrVisuCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.pgBar.Visible = False
            Me.lbStatut.Text = ""

            Me.DbDonneesDataSet.Mouvements.Columns.Add("Qte1U", GetType(Decimal), "iif(MQte1>0,(MMtDeb+MMtCre)/(MQte1),0)")
            Me.DbDonneesDataSet.Mouvements.Columns.Add("Qte2U", GetType(Decimal), "iif(MQte2>0,(MMtDeb+MMtCre)/(MQte2),0)")
            dgvQuantite1U.DataPropertyName = "Qte1U"
            dgvQuantite2U.DataPropertyName = "Qte2U"

            ChargerComptes()

            With dgvMouvements
                AddHandler .DataError, AddressOf dg_DataError
                AddHandler .MouseDown, AddressOf dg_GestionClicDroit
                .DataSource = Nothing
                .DataSource = MouvementsBindingSource
            End With

            cboActDisplay.ResetText()
            dtpDateStart.Value = My.Dossier.Principal.DateDebutEx
            dtpDateEnd.Value = My.Dossier.Principal.DateFinEx

            If Me.nCompte.Length > 0 Then
                Me.CompteBindingSource.Position = Me.CompteBindingSource.Find("CCpt", Me.nCompte)
                Me.cboCompteDisplay.Enabled = False
                If Me.nActivite.Length > 0 Then
                    Me.PlanActiviteBindingSource.Position = Me.PlanActiviteBindingSource.Find("PlActi", Me.nActivite)
                    Me.cboActDisplay.Enabled = False
                End If
                Me.cmsSupprPiece.Enabled = False
                Me.cmsModifPiece.Enabled = False
                LettrageAutomatiqueToolStripMenuItem1.Enabled = False
                RechercheCompteToolStripMenuItem.Enabled = False
            End If

            UpdateSommesTotal(0)
            FilterRow()

            ActionsDdb.DropDown = Me.CMSOptionLigne
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger

        If CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
            Me.cmsSupprPiece.Visible = False
            Me.cmsModifPiece.Visible = False
            Me.cmsModifPiece.Visible = False
        End If
        Return True

    End Function

    Private Sub ComboPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If Not TypeOf sender Is ComboBox Then Exit Sub
        Dim pos As Integer = CType(sender, ComboBox).FindString(CType(sender, ComboBox).Text)
        If pos >= 0 Then
            CType(sender, ComboBox).SelectedIndex = pos
        End If
        'If e.KeyCode = Keys.Enter Then
        '    cboCompteDisplay.Text = CType(sender, ComboBox).Text
        'End If
    End Sub

    Private Sub ComboEnter(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, ComboBox).DroppedDown = True
    End Sub

    Private Sub ChargerComptes()
        Me.DsPLC.EnforceConstraints = False
        'Par souci de performance, on vire les colonnes calculées de la table PlanComptable
        With Me.DsPLC.PlanComptable
            .ActDisplayColumn.Expression = Nothing
            '.ADisplayColumn.Expression = Nothing
            .AQteColumn.Expression = Nothing
            .AUnitColumn.Expression = Nothing
            .CptDisplayColumn.Expression = Nothing
            .CU1Column.Expression = Nothing
            .CU2Column.Expression = Nothing
        End With
        If Me.NafficherQueLesComptesMouvementésToolStripMenuItem.Checked Then
            Me.PlanComptableTableAdapter.FillByDossierMvtes(Me.DsPLC.PlanComptable, My.User.Name)
            Me.ComptesTableAdapter.FillByDossierMvtes(Me.DsPLC.Comptes, My.User.Name)
            Me.ActivitesTableAdapter.FillByDossierMvtes(Me.DsPLC.Activites, My.User.Name)
        Else
            Me.PlanComptableTableAdapter.FillByDossier(Me.DsPLC.PlanComptable, My.User.Name)
            Me.ComptesTableAdapter.FillByDossier(Me.DsPLC.Comptes, My.User.Name)
            Me.ActivitesTableAdapter.FillByDossier(Me.DsPLC.Activites, My.User.Name)
        End If
        Me.DsPLC.EnforceConstraints = True
    End Sub

    Private Sub ChargerEcritures(ByVal cpt As String)
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        With Me.DbDonneesDataSet
            .EnforceConstraints = False
            .Mouvements.Clear()
            .Lignes.Clear()
            .Pieces.Clear()
            Me.PiecesTableAdapter.FillByDossierByCompte(.Pieces, My.User.Name, cpt)
            Me.LignesTableAdapter.FillByDossierByCompte(.Lignes, My.User.Name, cpt)
            Me.MouvementsTableAdapter.FillByDossierByCompte(.Mouvements, My.User.Name, cpt)
            .EnforceConstraints = True
        End With
        Cursor.Current = Cursors.Default
        'Me.PiecesTableAdapter.FillByDossier(Me.DbDonneesDataSet.Pieces, My.User.Name)
        'Me.LignesTableAdapter.FillByDossier(Me.DbDonneesDataSet.Lignes, My.User.Name)
        'Me.MouvementsTableAdapter.FillByDossier(Me.DbDonneesDataSet.Mouvements, My.User.Name)
    End Sub

    Private Sub FilterRow()
        Dim filter As String = String.Format("MDate>=#{0:MM/dd/yyyy}# AND MDate<=#{1:MM/dd/yyyy}# ", dtpDateStart.Value, dtpDateEnd.Value, cboCompteDisplay.SelectedValue)
        If TbFiltrerLettrage.Checked Then filter &= " AND MLettrage IS NULL "
        If Not chkFull.Checked Then filter &= String.Format(" AND MActi = '{0}'", cboActDisplay.SelectedValue)
        Me.MouvementsBindingSource.Filter = filter
    End Sub

    Private Sub HighLightLettrage(ByVal codelettrage As String)
        Try
            For Each dr As DataGridViewRow In dgvMouvements.Rows
                If Not IsDBNull(CType(dr.DataBoundItem, DataRowView)("MLettrage")) _
                AndAlso CStr(CType(dr.DataBoundItem, DataRowView)("MLettrage")) = codelettrage Then
                    dr.DefaultCellStyle.Font = New Font(dgvMouvements.DefaultCellStyle.Font, FontStyle.Bold)
                Else
                    dr.DefaultCellStyle.Font = dgvMouvements.DefaultCellStyle.Font
                End If
            Next
        Catch ex As Exception
        End Try
        dgvMouvements.Refresh()
    End Sub

    Private Function GetSelectedRows(Optional ByVal onlyLettrees As Boolean = False) As List(Of dbDonneesDataSet.MouvementsRow)
        Dim res As New List(Of dbDonneesDataSet.MouvementsRow)
        For Each row As DataGridViewRow In Me.dgvMouvements.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For
            If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For
            Dim dr As dbDonneesDataSet.MouvementsRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, dbDonneesDataSet.MouvementsRow)
            If Not (onlyLettrees AndAlso dr.IsMLettrageNull) Then
                res.Add(dr)
            End If
        Next
        Return res
    End Function

    Private Function GetDDtClotureTVA() As Nullable(Of Date)
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        Return doss.DDtClotureTVA
    End Function
#End Region

#Region "MouvementsBindingSource"
    Private Sub MouvementsBindingSource_BindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles MouvementsBindingSource.BindingComplete
        UpdateSommesTotal()
    End Sub

    Private Sub MouvementsBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvementsBindingSource.CurrentItemChanged
        'If bComboSelected Then
        '    UpdateSommesTotal(0)
        '    'bComboSelected = False
        'Else
        UpdateSommesTotal(MouvementsBindingSource.Position)
        'End If
    End Sub
#End Region

#Region "Calcul des sommes"
    Private Sub UpdateSommesTotal(Optional ByVal nLigneSelected As Integer = 0)
        Try
            Dim recapReport As RecapCompte = GetRecapReport()
            Dim recapGen As New RecapCompte
            Dim recapPro As New RecapCompte

            Dim i As Integer = 0
            For Each xrow As DataRowView In MouvementsBindingSource
                recapGen.Add(CType(xrow.Row, dbDonneesDataSet.MouvementsRow))
                If i <= nLigneSelected Then
                    recapPro.Add(CType(xrow.Row, dbDonneesDataSet.MouvementsRow))
                End If
                i += 1
            Next

            With recapGen
                lblDebitTotalGen.Text = String.Format("{0:C2}", .MontantD)
                lblCreditTotalGen.Text = String.Format("{0:C2}", .MontantC)
                lblQuantite1TotalGen.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt1)
                lblQuantite2TotalGen.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt2)
                lblQuantite1UnitSoldeGen.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", CDec(IIf(.SoldeAbs > 0, .PrixUnit1, 0)))
                lblQuantite2UnitSoldeGen.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", CDec(IIf(.SoldeAbs > 0, .PrixUnit2, 0)))
            End With

            With recapPro
                lblDebitTotalPro.Text = String.Format("{0:C2}", .MontantD)
                lblCreditTotalPro.Text = String.Format("{0:C2}", .MontantC)
                lblQuantite1TotalPro.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt1)
                lblQuantite2TotalPro.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt2)
                lblQuantite1UnitSoldePro.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", CDec(IIf(.SoldeAbs > 0, .PrixUnit1, 0)))
                lblQuantite2UnitSoldePro.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", CDec(IIf(.SoldeAbs > 0, .PrixUnit2, 0)))
            End With


            If recapGen.Solde < 0 Then
                lblDebitSoldeGen.Text = String.Format("{0:C2}", recapGen.SoldeAbs)
                lblCreditSoldeGen.Text = ""
            ElseIf recapGen.Solde > 0 Then
                lblCreditSoldeGen.Text = String.Format("{0:C2}", recapGen.SoldeAbs)
                lblDebitSoldeGen.Text = ""
            Else
                lblCreditSoldeGen.Text = ""
                lblDebitSoldeGen.Text = ""
            End If

            If recapPro.Solde < 0 Then
                lblDebitSoldePro.Text = String.Format("{0:C2}", recapPro.SoldeAbs)
                lblCreditSoldePro.Text = ""
            ElseIf recapPro.Solde > 0 Then
                lblCreditSoldePro.Text = String.Format("{0:C2}", recapPro.SoldeAbs)
                lblDebitSoldePro.Text = ""
            Else
                lblCreditSoldePro.Text = ""
                lblDebitSoldePro.Text = ""
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Function GetRecapReport() As RecapCompte
        If Me.CompteBindingSource.Current Is Nothing Then Return Nothing
        Dim journal As String = My.Dossier.Principal.JournalAN
        Dim drMvt() As dbDonneesDataSet.MouvementsRow
        If chkFull.Checked Then
            drMvt = CType(Me.DbDonneesDataSet.Mouvements.Select(String.Format("MCpt='{0}' AND JournalPiece='{1}'", CType(Me.CompteBindingSource.Current, DataRowView)("CCpt").ToString, journal)), dbDonneesDataSet.MouvementsRow())
        Else
            drMvt = CType(Me.DbDonneesDataSet.Mouvements.Select(String.Format("MCpt='{0}' AND MActi='{1}' AND JournalPiece='{2}'", CType(Me.CompteBindingSource.Current, DataRowView)("CCpt").ToString, CType(Me.PlanActiviteBindingSource.Current, DataRowView)("PlActi").ToString, journal)), dbDonneesDataSet.MouvementsRow())
        End If
        Dim recap As New RecapCompte
        For Each dr As dbDonneesDataSet.MouvementsRow In drMvt
            recap.Add(dr)
        Next
        Return recap
    End Function

    Private Sub UpdateReport()
        Dim recap As RecapCompte = GetRecapReport()
        If recap Is Nothing Then Exit Sub
        With recap
            lbRepD.Text = String.Format("{0:C2}", .MontantD)
            lbRepC.Text = String.Format("{0:C2}", .MontantC)
            lbRepU1.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt1)
            lbRepU2.Text = String.Format("{0:# ##0.000;-# ##0.000;""}", .Qt2)
        End With
    End Sub

    Private Class RecapCompte
        Public MontantC As Decimal = 0
        Public MontantD As Decimal = 0
        Public Qt1 As Decimal = 0
        Public Qt2 As Decimal = 0

        Public ReadOnly Property Solde() As Decimal
            Get
                Return MontantC - MontantD
            End Get
        End Property

        Public ReadOnly Property SoldeAbs() As Decimal
            Get
                Return Math.Abs(Solde)
            End Get
        End Property

        Public ReadOnly Property PrixUnit1() As Decimal
            Get
                If Qt1 > 0 Then
                    Return Me.SoldeAbs / Qt1
                Else
                    Return 0
                End If
            End Get
        End Property

        Public ReadOnly Property PrixUnit2() As Decimal
            Get
                If Qt2 > 0 Then
                    Return Me.SoldeAbs / Qt2
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Sub Add(ByVal recap As RecapCompte)
            Me.MontantC += recap.MontantC
            Me.MontantD += recap.MontantD
            Me.Qt1 += recap.Qt1
            Me.Qt2 += recap.Qt2
        End Sub

        Public Sub Add(ByVal dr As dsPLC.PlanComptableRow)
            Me.MontantC += dr.PlRepG_C
            Me.MontantD += dr.PlRepG_D
            Me.Qt1 += dr.PlRepG_U1
            Me.Qt2 += dr.PlRepG_U2
        End Sub

        Public Sub Add(ByVal dr As dbDonneesDataSet.MouvementsRow)
            Me.MontantC += dr.MMtCre
            Me.MontantD += dr.MMtDeb
            If Not dr.IsMQte1Null Then Me.Qt1 += dr.MQte1
            If Not dr.IsMQte2Null Then Me.Qt2 += dr.MQte2
        End Sub
    End Class
#End Region

    Private Sub PlanActiviteBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PlanActiviteBindingSource.CurrentChanged
        UpdateReport()
        FilterRow()
    End Sub

    Private Sub cboCompteDisplay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompteDisplay.SelectedIndexChanged
        MouvementsBindingSource.MoveFirst()
    End Sub

    Private Sub dtpDateStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateStart.ValueChanged
        FilterRow()
    End Sub

    Private Sub dtpDateEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateEnd.ValueChanged
        FilterRow()
    End Sub

    Private Sub chkFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFull.CheckedChanged
        With cboActDisplay
            If .Items.Count > 0 Then
                If chkFull.Checked Then
                    .Enabled = False
                    .ResetText()
                Else
                    .Enabled = True
                    .SelectedIndex = 0
                End If
                UpdateReport()
                FilterRow()
            End If
        End With
    End Sub

    Private Sub CompteBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CompteBindingSource.CurrentChanged
        If Me.CompteBindingSource.Current Is Nothing Then Exit Sub
        Try
            Dim xCompte As DataRowView = CType(Me.CompteBindingSource.Current, DataRowView)
            If Not xCompte Is Nothing Then
                dgvMouvements.Columns("dgvQuantite1").HeaderText = Convert.ToString(xCompte("CU1"))
                dgvMouvements.Columns("dgvQuantite2").HeaderText = Convert.ToString(xCompte("CU2"))
                dgvMouvements.Columns("dgvQuantite1U").HeaderText = "Prix unitaire en €/" + Convert.ToString(xCompte("CU1"))
                dgvMouvements.Columns("dgvQuantite2U").HeaderText = "Prix unitaire en €/" + Convert.ToString(xCompte("CU2"))
                TlpTotauxUnit.Visible = Convert.ToString(xCompte("CU1")).Length > 0
            End If

            ChargerEcritures(Convert.ToString(xCompte("CCpt")))

            If Me.PlanActiviteBindingSource.Count > 0 Then
                chkFull.Enabled = True
            Else
                chkFull.Enabled = False
                chkFull.Checked = True
                cboActDisplay.ResetText()
            End If
            UpdateReport()
            FilterRow()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

#Region "Gestion menu contextuel"
    Private Sub cmsModifPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cmsModifPiece.Click, cmsVisualiserPiece.Click
        If Me.MouvementsBindingSource.Position < 0 Then Exit Sub
        If Me.CompteBindingSource.Position < 0 Then Exit Sub

        Dim curPiece As dbDonneesDataSet.MouvementsRow = CType(CType(Me.MouvementsBindingSource.Current, DataRowView).Row, dbDonneesDataSet.MouvementsRow)
        Dim piece As Integer = curPiece.MPiece
        Dim pdate As Date = curPiece.MDate
        Dim mlig As Integer = curPiece.MLig
        Dim mordre As Integer = curPiece.MOrdre
        Dim oldPos As Integer = Me.MouvementsBindingSource.Position

        With New FrSaisiePiece
            .NewDatePiece = pdate
            .PieceACharger = piece
            .ReadOnlyData = sender Is cmsVisualiserPiece
            If .ShowDialog() = Windows.Forms.DialogResult.OK AndAlso Not .ReadOnlyData Then
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()
                Try
                    ChargerEcritures(Convert.ToString(CType(Me.CompteBindingSource.Current, DataRowView)("CCpt")))
                    Me.MouvementsBindingSource.ResetBindings(False)
                    Dim dv As DataView = CType(Me.MouvementsBindingSource.List, DataView)
                    dv.Sort = "MDate,MPiece,Mlig"
                    Application.DoEvents()
                    Dim pos As Integer = dv.Find(New Object() {pdate, piece, mlig})
                    If pos < 0 Then pos = oldPos
                    If pos < Me.MouvementsBindingSource.Count Then
                        Me.MouvementsBindingSource.Position = pos
                    End If
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            End If
        End With
    End Sub

    Private Sub cmsSupprPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSupprPiece.Click
        Dim curMvt As dbDonneesDataSet.MouvementsRow = CType(CType(Me.MouvementsBindingSource.Current, DataRowView).Row, dbDonneesDataSet.MouvementsRow)
        If MsgBox(String.Format(My.Resources.Strings.SuppressionPiece, curMvt.MPiece, curMvt.MDate), MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDePiece) = MsgBoxResult.Yes Then
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim oldPos As Integer = Me.MouvementsBindingSource.Position
                Piece.SuppressionPiece(My.User.Name, curMvt.MPiece, curMvt.MDate)
                ChargerEcritures(Convert.ToString(CType(Me.CompteBindingSource.Current, DataRowView)("CCpt")))
                Me.MouvementsBindingSource.ResetBindings(False)
                If oldPos < Me.MouvementsBindingSource.Count Then
                    Me.MouvementsBindingSource.Position = oldPos
                End If
                '                MsgBox(My.Resources.Strings.PieceSupprimee, MsgBoxStyle.Information, My.Resources.Strings.SuppressionDePiece)
            Catch ex As Exception
                Throw New ApplicationException(My.Resources.Strings.ImpossibleDeSupprimerPiece & ex.Message, ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Sub
#End Region

#Region "Toolbar"
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub TbFiltrerLettrage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFiltrerLettrage.CheckedChanged
        FilterRow()
    End Sub

    Private Sub TbFilterMouvementes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NafficherQueLesComptesMouvementésToolStripMenuItem.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            ChargerComptes()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLeCompteToolStripMenuItem.Click
        ReportProgress(0, My.Resources.Strings.Initialisation)
        Cursor.Current = Cursors.WaitCursor


        Dim drcpt As dsPLC.ComptesRow = CType(CType(Me.CompteBindingSource.Current, DataRowView).Row, dsPLC.ComptesRow)
        Dim numActi As String = Nothing
        Dim dtDeb As Date
        Dim dtFin As Date
        Dim Lettr As Boolean

        If chkFull.Checked Then
            Dim drplc As dsPLC.PlanComptableRow = CType(CType(Me.PlanActiviteBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
            numActi = drplc.PlActi
            dtDeb = Me.dtpDateStart.Value
            dtFin = Me.dtpDateEnd.Value
            Lettr = Me.TbFiltrerLettrage.Checked
        End If
        ReportProgress(50, My.Resources.Strings.ChargementDesDonnees)
        Dim ds As DataSet = Compte.GetDataRptVisuCompte(drcpt.CCpt, numActi, dtDeb, dtFin, Lettr)

        ReportProgress(60, My.Resources.Strings.OuvertureEtat)
        Using report As ReportDocument = Compte.PrepareRptVisuCompte(ds, chkFull.Checked)
            ReportProgress(80)
            Compte.AffichDonneesGen(report)
            Using fr As New EcranCrystal(report)
                ReportProgress(100)
                fr.ShowDialog()
            End Using
        End Using
        Me.pgBar.Visible = False
        Me.lbStatut.Text = ""
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As String = Nothing)
        Me.pgBar.Visible = True
        Me.pgBar.Value = percent
        If status IsNot Nothing Then
            Me.lbStatut.Text = status
            Application.DoEvents()
        End If
    End Sub
#End Region

#Region "DataGridView"
    Private Sub dgvMouvements_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvMouvements.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each dr As DataGridViewRow In dgvMouvements.Rows
                If Not IsDBNull(CType(dr.DataBoundItem, DataRowView)("MLettrage")) Then
                    dr.DefaultCellStyle.ForeColor = Color.Red
                Else
                    dr.DefaultCellStyle.ForeColor = dgvMouvements.DefaultCellStyle.ForeColor
                End If
            Next
        End If
    End Sub

    Private Sub dgvMouvements_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMouvements.SelectionChanged
        Dim rws As List(Of dbDonneesDataSet.MouvementsRow) = GetSelectedRows(True)

        If rws.Count > 0 Then
            LettrerToolStripMenuItem.Enabled = False
            DélettrerToolStripMenuItem.Enabled = True
            HighLightLettrage(rws(0).MLettrage)
        Else
            DélettrerToolStripMenuItem.Enabled = False
            Dim solde As Nullable(Of Decimal) = UpdateCompteLettrage()
            LettrerToolStripMenuItem.Enabled = (solde.HasValue AndAlso solde.Value = 0)
            HighLightLettrage("")
        End If

        If Me.MouvementsBindingSource.Position < 0 Then Exit Sub

        Dim curPiece As dbDonneesDataSet.MouvementsRow = CType(CType(Me.MouvementsBindingSource.Current, DataRowView).Row, dbDonneesDataSet.MouvementsRow)
        Dim dateClotureTVA As Nullable(Of Date) = Me.GetDDtClotureTVA()

        If (dateClotureTVA.HasValue) Then
            If (curPiece.MDate <= CDate(dateClotureTVA)) Then
                Me.cmsModifPiece.Enabled = False
                Me.cmsSupprPiece.Enabled = False
            Else
                Me.cmsModifPiece.Enabled = True
                Me.cmsSupprPiece.Enabled = True
            End If
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub LettrerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LettrerToolStripMenuItem.Click
        'Vérifier si les écritures sélectionnées s'équilibrent
        Dim solde As Nullable(Of Decimal) = UpdateCompteLettrage()
        If Not solde.HasValue Then Exit Sub
        If solde.Value <> 0 Then
            MsgBox(String.Format("Le lettrage n'est pas possible, il y a une différence de {0:C2}", solde), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LettrerEtUpdate(GetSelectedRows())
    End Sub

    Private Sub DélettrerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DélettrerToolStripMenuItem.Click
        'Délettrage
        Dim rws As List(Of dbDonneesDataSet.MouvementsRow) = GetSelectedRows(True)
        If rws.Count = 0 Then Exit Sub
        If MsgBox("Voulez-vous vraiment annuler le lettrage des lignes sélectionnées ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Delettrer(rws)
    End Sub

    Private Sub TbLettrageAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LettrageAutomatiqueToolStripMenuItem1.Click
        If MsgBox("Voulez-vous lettrer automatiquement ce compte ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Dim cptLettrage As Integer = 0
        ReportProgress(0, "Lettrage automatique du compte...")
        Me.MouvementsBindingSource.Position = 0
        Dim i As Integer
        Dim codeLettrage As String = CreerCodeLettrage()
        For Each drMvt As dbDonneesDataSet.MouvementsRow In Me.DbDonneesDataSet.Mouvements
            ReportProgress(i * 100 \ Me.DbDonneesDataSet.Mouvements.Count) : i += 1
            If Not drMvt.IsMLettrageNull Then Continue For
            Dim soldeD As Decimal = drMvt.MMtDeb - drMvt.MMtCre
            Dim trouve As Boolean = False
            For Each drMvt2 As dbDonneesDataSet.MouvementsRow In Me.DbDonneesDataSet.Mouvements
                If Not drMvt2.IsMLettrageNull Then Continue For
                Dim soldeD2 As Decimal = drMvt2.MMtDeb - drMvt2.MMtCre
                If soldeD + soldeD2 = 0 Then
                    Lettrer(New List(Of dbDonneesDataSet.MouvementsRow)(New dbDonneesDataSet.MouvementsRow() {drMvt, drMvt2}), codeLettrage)
                    codeLettrage = NextCode(codeLettrage)
                    cptLettrage += 2
                    Exit For
                End If
            Next
        Next
        If Me.DbDonneesDataSet.HasChanges Then
            Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet)
            Me.MouvementsBindingSource.ResetBindings(False)
        End If
        Me.pgBar.Visible = False
        Me.lbStatut.Text = ""
        Cursor.Current = Cursors.Default
        If cptLettrage = 0 Then
            MsgBox("Aucune écriture n'a pu être lettrée", MsgBoxStyle.Information)
        Else
            MsgBox(String.Format("{0} écritures ont été lettrées", cptLettrage), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub RechercheCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercheCompteToolStripMenuItem.Click
        Using fr As New FrRechercheCompte
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If fr.Compte <> "" Then
                    Dim pos As Integer = Me.CompteBindingSource.Find("CCpt", fr.Compte)
                    If pos >= 0 Then Me.CompteBindingSource.Position = pos
                    CompteBindingSource_CurrentChanged(Nothing, Nothing)
                End If
            End If
        End Using
    End Sub
#End Region

#Region "Fonctions Lettrage"
    Private Function UpdateCompteLettrage() As Nullable(Of Decimal)
        'Calculer la balance des lignes sélectionnées et l'afficher
        If Me.dgvMouvements.SelectedRows.Count < 2 Then
            tlpLettrage.Visible = False
            Return New Nullable(Of Decimal)
        Else
            Dim rws As List(Of dbDonneesDataSet.MouvementsRow) = GetSelectedRows()
            Dim mtD As Decimal
            Dim mtC As Decimal
            For Each rw As dbDonneesDataSet.MouvementsRow In rws
                mtD += rw.MMtDeb
                mtC += rw.MMtCre
            Next
            Dim solde As Decimal = mtD - mtC
            'Afficher les valeurs à l'écran
            lbLettreMtD.Text = mtD.ToString("C2")
            lbLettreMtC.Text = mtC.ToString("C2")
            If solde > 0 Then
                lbLettreSoldeD.Text = solde.ToString("C2")
                lbLettreSoldeC.Text = ""
            Else
                lbLettreSoldeC.Text = (-solde).ToString("C2")
                lbLettreSoldeD.Text = ""
            End If
            tlpLettrage.Visible = True
            Return solde
        End If
    End Function

    Private Sub Delettrer(ByVal rwsMvt As List(Of dbDonneesDataSet.MouvementsRow))
        For Each rw As dbDonneesDataSet.MouvementsRow In rwsMvt
            If rw.IsMLettrageNull Then Continue For
            For Each srw As dbDonneesDataSet.MouvementsRow In Me.DbDonneesDataSet.Mouvements.Select(String.Format("MLettrage='{0}'", rw.MLettrage))
                srw.SetMLettrageNull()
            Next
        Next
        'Enregistrer en base
        Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet.Mouvements)
        Me.MouvementsBindingSource.ResetBindings(False)
    End Sub

    Private Sub Lettrer(ByVal rwsMvt As List(Of dbDonneesDataSet.MouvementsRow), ByVal codeLettrage As String)
        'Créer un nouveau code lettrage et l'affecter
        Dim rws As List(Of dbDonneesDataSet.MouvementsRow) = rwsMvt
        For Each rw As dbDonneesDataSet.MouvementsRow In rws
            rw.MLettrage = codeLettrage
        Next
    End Sub

    Private Sub LettrerEtUpdate(ByVal rwsMvt As List(Of dbDonneesDataSet.MouvementsRow))
        Dim codeLettrage As String = CreerCodeLettrage()
        Lettrer(rwsMvt, codeLettrage)
        'Enregistrer en base
        Me.MouvementsTableAdapter.Update(Me.DbDonneesDataSet.Mouvements)
        Me.MouvementsBindingSource.ResetBindings(False)
    End Sub

    Private Function CreerCodeLettrage() As String
        Dim codeLettrage As String = Me.MouvementsTableAdapter.MaxLettrage
        Return NextCode(codeLettrage)
    End Function

    Private Function NextCode(ByVal codeLettrage As String) As String
        If codeLettrage Is Nothing Then Return "000"
        Dim chars() As Char = codeLettrage.ToCharArray
        For i As Integer = chars.Length - 1 To 0 Step -1
            Dim l As Char = chars(i)
            l = NextChar(l)
            chars(i) = l
            If l <> "0"c Then Exit For
        Next
        codeLettrage = New String(chars)
        If codeLettrage = "000" Then Throw New ApplicationException("Tous les codes lettrages ont été utilisés")
        Return codeLettrage
    End Function

    Private Function NextChar(ByVal c As Char) As Char
        Select Case c
            Case "Z"c : Return "0"c
            Case "9"c : Return "A"c
            Case Else : Return Chr(Asc(c) + 1)
        End Select
    End Function
#End Region

End Class
