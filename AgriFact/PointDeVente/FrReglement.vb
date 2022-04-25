Public Class FrReglement

    Private totalARegler As Nullable(Of Decimal)
    Private modif As Boolean
    Private _nDevis As Integer = -1
    Private _nRegl As Integer = -1

    Const MODE_CB As String = "Carte Bancaire"
    Const MODE_CHQ As String = "Chèque"
    Const MODE_ESP As String = "Espèce"

#Region "Props"
    Public Property NDevis() As Integer
        Get
            Return _nDevis
        End Get
        Set(ByVal value As Integer)
            _nDevis = value
        End Set
    End Property

    Public Property nReglement() As Integer
        Get
            Return _nRegl
        End Get
        Set(ByVal value As Integer)
            _nRegl = value
        End Set
    End Property

    Private ReadOnly Property CurrentReglRow() As DsAgrifact.ReglementRow
        Get
            If Me.ReglementBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.ReglementBindingSource.Current, DataRowView).Row, DsAgrifact.ReglementRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nDevis As Integer)
        Me.New()
        Me.NDevis = nDevis
    End Sub
#End Region

#Region "Form"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If modif Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        gbCheque.Width = BtModeCB.Right - BtModeEspece.Left
        SynchroPosLoc(gbCB, gbCheque)
        SynchroPosLoc(gbEspece, gbCheque)

        TxEspecePaye.Text = ""
        TxEspeceRendu.Text = ""
        TxReste.Text = ""
        ConfigCurrencyControl(MontantTextBox)
        ConfigCurrencyControl(PerteTextBox)
        ConfigCurrencyControl(ProfitTextBox)
        ConfigCurrencyControl(TxEspecePaye)
        ConfigCurrencyControl(TxEspeceRendu)
        ConfigCurrencyControl(TxReste)

        Me.DsAgrifact.Reglement.InitAutoIncrementSeed()
        Me.DsAgrifact.Reglement_Detail.InitAutoIncrementSeed()
        ConfigDataTableEvents(Me.DsAgrifact.Reglement, AddressOf MajBoutons)
        ChargerDonnees()
        Select Case Convert.ToString(Me.CurrentReglRow("nMode")).ToLower
            Case MODE_CHQ.ToLower : BtMode_Click(BtModeCheque, Nothing)
            Case MODE_CB.ToLower : BtMode_Click(BtModeCB, Nothing)
            Case Else : BtMode_Click(BtModeEspece, Nothing)
        End Select
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ReglementBindingSource.SuspendBinding()
        Me.ListeChoixTA.FillByNomChoix(Me.DsAgrifact.ListeChoix, DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeBanque)
        If Me.nReglement >= 0 Then
            Me.ReglementTA.FillBynReglement(Me.DsAgrifact.Reglement, Me.nReglement)
            Me.Reglement_DetailTA.FillBynReglement(Me.DsAgrifact.Reglement_Detail, Me.nReglement)
            If Me.DsAgrifact.Reglement_Detail.Rows.Count > 0 Then
                With Cast(Of DsAgrifact.Reglement_DetailRow)(Me.DsAgrifact.Reglement_Detail.Rows(0))
                    Me.NDevis = CInt(.nFacture)
                End With
            End If
        Else
            Me.ReglementTA.FillBynDevis(Me.DsAgrifact.Reglement, Me.NDevis)
            Me.Reglement_DetailTA.FillBynDevis(Me.DsAgrifact.Reglement_Detail, Me.NDevis)
            If Me.DsAgrifact.Reglement.Rows.Count > 0 Then
                With Cast(Of DsAgrifact.ReglementRow)(Me.DsAgrifact.Reglement.Rows(0))
                    Me.nReglement = CInt(.nReglement)
                End With
            End If
        End If
        'Trouver le reste à régler de la facture
        totalARegler = VFactureTA.GetResteARegler(Me.NDevis, Me.nReglement)
        Me.ReglementBindingSource.ResumeBinding()

        If Me.nReglement <= 0 Then
            Me.BtSuppr.Visible = False
            Me.ReglementBindingSource.AddNew()
            With Me.CurrentReglRow
                'Trouver le Payeur (qui est le client de la Facture)
                Using dta As New DsAgrifactTableAdapters.EntrepriseTA
                    dta.FillByNDevis(Me.DsAgrifact.Entreprise, Me.NDevis)
                End Using
                If Me.DsAgrifact.Entreprise.Rows.Count > 0 Then
                    Dim dr As DsAgrifact.EntrepriseRow = Cast(Of DsAgrifact.EntrepriseRow)(Me.DsAgrifact.Entreprise.Rows(0))
                    .nEntreprise = dr.nEntreprise
                    If Not dr.IsBanqueNull Then .BanqueClient = dr.Banque
                    If Not dr.IsModePaiementNull Then .nMode = dr.ModePaiement
                End If
                .DateReglement = Now
                .Montant = totalARegler.GetValueOrDefault
            End With
            Me.ReglementBindingSource.EndEdit()
            Me.ReglementBindingSource.ResetCurrentItem()
        End If
        MajBoutons()
    End Sub

    Private Sub UpdateMontants()
        Dim montant As Nullable(Of Decimal) = Nullabilify(Of Decimal)(Me.CurrentReglRow("Montant"))
        Dim perte As Nullable(Of Decimal) = Nullabilify(Of Decimal)(Me.CurrentReglRow("Perte"))
        Dim profit As Nullable(Of Decimal) = Nullabilify(Of Decimal)(Me.CurrentReglRow("Profit"))
        Dim reste As Decimal = Decimal.Round(totalARegler.GetValueOrDefault - montant.GetValueOrDefault - perte.GetValueOrDefault + profit.GetValueOrDefault, 2)
        If Me.TxReste.Text = String.Format("{0:C2}", reste) Then Exit Sub
        If reste > 0 Then
            If profit.GetValueOrDefault <> 0 Then
                Dim regul As Decimal = Math.Min(profit.GetValueOrDefault, reste)
                reste -= regul
                profit = NullableOp(AddressOf Decimal.Subtract, profit, regul, True)
                Me.CurrentReglRow("Profit") = DBNullify(profit)
            End If
            If reste > 0 Then
                If MsgBox(String.Format("Il reste {0:C2} à régler sur la facture, souhaitez-vous le passer en perte ?", reste), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    perte = NullableOp(AddressOf Decimal.Add, perte, reste, True)
                    Me.CurrentReglRow("Perte") = DBNullify(perte)
                    reste = 0
                End If
            End If
        ElseIf reste < 0 Then
            If perte.GetValueOrDefault <> 0 Then
                Dim regul As Decimal = Math.Min(perte.GetValueOrDefault, -reste)
                reste += regul
                perte = NullableOp(AddressOf Decimal.Subtract, perte, regul, True)
                Me.CurrentReglRow("Perte") = DBNullify(perte)
            End If
            If reste < 0 Then
                If MsgBox(String.Format("Il y a {0:C2} de trop perçu, souhaitez-vous le passer en profit ?", -reste), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    profit = NullableOp(AddressOf Decimal.Subtract, profit, reste, True)
                    Me.CurrentReglRow("Profit") = DBNullify(profit)
                    reste = 0
                End If
            End If
        End If
        Me.TxReste.Text = String.Format("{0:C2}", reste)
        Me.ReglementBindingSource.ResetCurrentItem()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.ReglementBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            If Me.nReglement >= 0 Then
                'on supprime les réglements détail existants
                Me.Reglement_DetailTA.DeleteByNReglement(Me.nReglement)
            End If
            'On crée le réglement détail
            Dim dr As DsAgrifact.Reglement_DetailRow = Me.DsAgrifact.Reglement_Detail.NewReglement_DetailRow
            With dr
                .nFacture = Me.NDevis
                .nReglement = Me.CurrentReglRow.nReglement
                .Montant = Me.CurrentReglRow.Montant
                .Item("Perte") = Me.CurrentReglRow("Perte")
                .Item("Profit") = Me.CurrentReglRow("Profit")
            End With
            Me.DsAgrifact.Reglement_Detail.AddReglement_DetailRow(dr)

            'Mise à jour de la base
            Me.ReglementTA.Update(Me.DsAgrifact.Reglement)
            Me.nReglement = CInt(Me.CurrentReglRow.nReglement)
            Me.Reglement_DetailTA.Update(Me.DsAgrifact.Reglement_Detail)
            'Eventuellement marquer la facture comme payée
            VFactureTA.VerifPaye(Me.NDevis)
            'Gestion du journal de caisse
            If String.Equals(Me.CurrentReglRow.nMode, MODE_ESP, StringComparison.CurrentCultureIgnoreCase) Then
                'On vient d'enregistrer un réglement espece => On met à jour le journal de caisse
                EnregistrerCaisse()
            Else
                'Au cas ou, pour etre sur de ne pas avoir d'encaissement pour des réglements non espece
                SupprimerCaisse()
            End If
            modif = True
        End If
        MajBoutons()
    End Sub

    Private Sub EnregistrerCaisse()
        Using dta As New DsAgrifactTableAdapters.JournalCaisseTA
            'SI LA CAISSE A PAS ETE INITIALISEE, on lance l'écran caisse
            If My.Settings.CurrentCaisse < 0 Then
                Dim nCaisse As Integer = -1
                If FrCaisse.InitCaisse(nCaisse, dta) = Windows.Forms.DialogResult.OK Then
                    My.Settings.CurrentCaisse = nCaisse
                End If
            End If

            Dim dt As DsAgrifact.JournalCaisseDataTable
            Dim drJ As DsAgrifact.JournalCaisseRow
            'Essayer de récupérer une ligne de caisse existante pour ce réglement
            dt = dta.GetDataBynReglement(Me.nReglement)
            If dt.Rows.Count > 0 Then
                drJ = dt(0)
            Else
                'Sinon on crée une nouvelle ligne
                drJ = dt.NewJournalCaisseRow
            End If
            With drJ
                .NCaisse = My.Settings.CurrentCaisse
                .Type = CInt(PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Vente)
                .Montant = Me.CurrentReglRow.Montant
                .DateCaisse = Me.CurrentReglRow.DateReglement
                .nReglement = Me.nReglement
                .Libelle = Strip(VFactureTA.GetInfosFacture(Me.NDevis), 255)
            End With
            If drJ.RowState = DataRowState.Detached Then
                dt.AddJournalCaisseRow(drJ)
            End If
            'Enregistrement
            dta.Update(dt)
        End Using
    End Sub

    Private Sub SupprimerCaisse()
        Using dta As New DsAgrifactTableAdapters.JournalCaisseTA
            dta.DeleteBynReglement(Me.nReglement)
        End Using
    End Sub

    Private Function Strip(ByVal s As String, ByVal length As Integer) As String
        If s.IndexOf(vbCrLf) >= 0 Then
            s = s.Substring(0, s.IndexOf(vbCrLf))
        End If
        If s.Length > length Then
            s = s.Substring(0, length)
        End If
        Return s
    End Function

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.ReglementBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function
#End Region

#Region "Button"
    Private Sub BtMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles BtModeEspece.Click, BtModeCheque.Click, BtModeCB.Click
        gbEspece.Visible = sender Is BtModeEspece
        gbCheque.Visible = sender Is BtModeCheque
        gbCB.Visible = sender Is BtModeCB
        If sender Is BtModeEspece Then
            Me.CurrentReglRow.nMode = MODE_ESP
            TxEspecePaye.Text = Me.CurrentReglRow.Montant.ToString("C2")
        ElseIf sender Is BtModeCheque Then : Me.CurrentReglRow.nMode = MODE_CHQ
        ElseIf sender Is BtModeCB Then : Me.CurrentReglRow.nMode = MODE_CB
        End If
        BtModeEspece.Active = sender Is BtModeEspece
        BtModeCheque.Active = sender Is BtModeCheque
        BtModeCB.Active = sender Is BtModeCB
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Enregistrer()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSuppr.Click
        If MsgBox("Voulez-vous supprimer ce réglement ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Using dta As New DsAgrifactTableAdapters.JournalCaisseTA
                dta.DeleteBynReglement(Me.nReglement)
            End Using
            Me.Reglement_DetailTA.DeleteByNReglement(Me.nReglement)
            Me.ReglementTA.DeleteByNReglement(Me.nReglement)
            Me.VFactureTA.VerifPaye(Me.NDevis)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
#End Region

#Region "ReglementBindingSource"
    Private Sub ReglementBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReglementBindingSource.CurrentItemChanged
        If ReglementBindingSource.IsBindingSuspended Then Exit Sub
        If Not IsDBNull(Cast(Of DataRowView)(Me.ReglementBindingSource.Current)("Montant")) Then
            UpdateMontants()
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub SynchroPosLoc(ByVal ctl As Control, ByVal ctlSource As Control)
        With ctl
            .Top = ctlSource.Top
            .Left = ctlSource.Left
            .Width = ctlSource.Width
            .Height = ctlSource.Height
        End With
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        BtOK.Enabled = Me.DsAgrifact.HasChanges
    End Sub
#End Region

#Region "Gestion des paiements en espece"
    Private Sub TxEspecePaye_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxEspecePaye.Validated
        Dim montantPaye As Nullable(Of Decimal) = CurrencyParse(TxEspecePaye.Text)
        If montantPaye.HasValue Then
            TxEspecePaye.Text = montantPaye.Value.ToString("C2")
            Dim aRendre As Decimal = montantPaye.Value - totalARegler.GetValueOrDefault
            TxEspeceRendu.Text = aRendre.ToString("C2")
        End If
    End Sub

    Private Sub TxEspeceRendu_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxEspeceRendu.Validated
        Dim montantPaye As Nullable(Of Decimal) = CurrencyParse(TxEspecePaye.Text)
        Dim montantRendu As Nullable(Of Decimal) = CurrencyParse(TxEspeceRendu.Text)
        If montantPaye.HasValue Then
            If montantRendu.HasValue Then
                TxEspeceRendu.Text = montantRendu.Value.ToString("C2")
            End If
            Me.CurrentReglRow.Montant = montantPaye.Value - montantRendu.GetValueOrDefault
            Me.ReglementBindingSource.ResetCurrentItem()
        End If
    End Sub
#End Region

    Private Sub ctl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                    Handles BanqueClientComboBoxChq.KeyPress, TxReste.KeyPress, TxEspeceRendu.KeyPress, _
                    TxEspecePaye.KeyPress, ProfitTextBox.KeyPress, PerteTextBox.KeyPress, NChequeTextBox.KeyPress, _
                    MontantTextBox.KeyPress, BanqueClientComboBoxCb.KeyPress
        If e.KeyChar = vbCr Then
            Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles ProfitTextBox.Validated, PerteTextBox.Validated, NChequeTextBox.Validated, _
                    MontantTextBox.Validated, DateReglementDateTimePicker.ValueChanged, _
                    BanqueClientComboBoxChq.Validated, BanqueClientComboBoxCb.Validated
        ReglementBindingSource.EndEdit()
    End Sub

End Class
