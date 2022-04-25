Public Class FrSaisieClient

    Private modif As Boolean
    Private _nEnt As Integer = -1

#Region "Props"
    Public Property NEntreprise() As Integer
        Get
            Return _nEnt
        End Get
        Set(ByVal value As Integer)
            _nEnt = value
        End Set
    End Property

    Private ReadOnly Property CurrentEntRow() As DsAgrifact.EntrepriseRow
        Get
            If Me.FournBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.FournBindingSource.Current, DataRowView).Row, DsAgrifact.EntrepriseRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.TelephoneEntrepriseDataGridView.AutoGenerateColumns = False
    End Sub

    Public Sub New(ByVal nEntreprise As Integer)
        Me.New()
        Me.NEntreprise = nEntreprise
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

        ConfigZoomTextbox(AdresseTextBox)
        ConfigZoomTextbox(ObservationsTextBox)
        ConfigPercentControl(RemiseTextBox)

        ApplyStyle(Me.TelephoneEntrepriseDataGridView, False)
        With TelephoneEntrepriseDataGridView
            AddHandler .EditingControlShowing, AddressOf MakeComboDropDown
            AddHandler .CellValidating, AddressOf cellvalidating
        End With

        Me.DsAgrifact.Entreprise.InitAutoIncrementSeed()
        ConfigDataTableEvents(Me.DsAgrifact.Entreprise, AddressOf MajBoutons)
        ConfigDataTableEvents(Me.DsAgrifact.TelephoneEntreprise, AddressOf MajBoutons, False)
        ChargerDonnees()
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        'Chargement des tarifs
        Me.TarifTableAdapter.Fill(Me.DsAgrifact.Tarif)

        'Chargement des civilités
        Me.CivilitesBindingSource.DataSource = Me.ListeChoixTA.GetDataByNomChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.FormeJuridique)

        'chargement des modes de paiement
        Me.ModesPaiementBindingSource.DataSource = Me.ListeChoixTA.GetDataByNomChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeModeReglement)

        'Chargement des banques
        Me.BanqueBindingSource.DataSource = Me.ListeChoixTA.GetDataByNomChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeBanque)

        If Me.NEntreprise >= 0 Then
            'Chargement de l'entreprise
            Me.EntrepriseTA.FillBynEnt(Me.DsAgrifact.Entreprise, Me.NEntreprise)

            'Chargement des téléphones de l'entreprise 
            Me.TelephoneEntrepriseTableAdapter.FillBynEnt(Me.DsAgrifact.TelephoneEntreprise, Me.NEntreprise)

            Me.TbInactif.Checked = Not Me.CurrentEntRow.Inactif
            Me.CurrentEntRow.AcceptChanges()
        Else
            Me.FournBindingSource.AddNew()

            'Valeurs par défaut
            With Me.CurrentEntRow
                .TypeClient = DsAgrifactTableAdapters.EntrepriseTA.TypeClient.Particulier.ToString.ToUpper
                .FacturationTTC = True
                .nTarif = My.Settings.nTarifDefaut
                .NCompteC = My.Settings.nCompteDefaut
                .NActiviteC = "0000"
                Me.NEntreprise = CInt(.nEntreprise)
                Me.TbInactif.Checked = Not .Inactif
            End With

            Me.FournBindingSource.ResetCurrentItem()
        End If

        'Chargement des cibles commerciales 
        Me.ListeChoixCibleCommercialBindingSource.DataSource = Me.ListeChoixTA.GetDataByNomChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeCibleCommercial)

        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.FournBindingSource.EndEdit()
        Me.TelephoneEntrepriseBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            'Virer les téléphones de type null
            For Each dr As DataRow In Me.DsAgrifact.TelephoneEntreprise.Select("Type is null OR Type=''")
                dr.Delete()
            Next
            Me.EntrepriseTA.Update(Me.DsAgrifact.Entreprise)
            Me.TelephoneEntrepriseTableAdapter.Update(Me.DsAgrifact.TelephoneEntreprise)
            modif = True
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.FournBindingSource.EndEdit()
        Me.TelephoneEntrepriseBindingSource.EndEdit()
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

#Region "Gestion de la combobox du Type de téléphone"
    Private Sub MakeComboDropDown(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            With CType(e.Control, DataGridViewComboBoxEditingControl)
                .DropDownStyle = ComboBoxStyle.DropDown
            End With
        End If
    End Sub

    Private Sub cellvalidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
        If e.ColumnIndex = Type.Index Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            If TypeOf grid.EditingControl Is DataGridViewComboBoxEditingControl Then
                Dim cmb As DataGridViewComboBoxEditingControl = CType(grid.EditingControl, DataGridViewComboBoxEditingControl)
                Dim value As String = cmb.Text
                If cmb.Items.IndexOf(value) = -1 Then
                    cmb.Items.Add(value)
                    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
                    If cmbCol IsNot Nothing Then cmbCol.Items.Add(value)
                End If
                grid.CurrentCell.Value = value
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        With TbInactif
            If Me.FournBindingSource.Position >= 0 AndAlso Me.CurrentEntRow.Inactif Then
                .Text = "Client inactif"
                .ToolTipText = "Cliquez pour activer le fournisseur."
                .Image = My.Resources.inactif
            Else
                .Text = "Client actif"
                .ToolTipText = "Cliquez pour désactiver le fournisseur."
                .Image = My.Resources.actif
            End If
        End With
        ProduitBindingNavigatorSaveItem.Enabled = Me.DsAgrifact.HasChanges
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    'Private Sub TbBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbBR.Click
    '    If Me.FournBindingSource.Current Is Nothing Then Exit Sub
    '    Using fr As New Receptions.FrListeBR(CInt(Me.CurrentEntRow.nEntreprise))
    '        fr.Owner = Me
    '        fr.StartPosition = FormStartPosition.CenterParent
    '        fr.ShowDialog()
    '    End Using
    'End Sub

    'Private Sub TbNewBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewBR.Click
    '    If Me.FournBindingSource.Current Is Nothing Then Exit Sub
    '    Using fr As New Receptions.FrSaisieBR()
    '        fr.Owner = Me
    '        fr.NFournisseur = CInt(Me.CurrentEntRow.nEntreprise)
    '        fr.StartPosition = FormStartPosition.CenterParent
    '        fr.ShowDialog()
    '    End Using
    'End Sub

    Private Sub TbInactif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbInactif.CheckedChanged
        If Me.FournBindingSource.Position < 0 Then Exit Sub
        Me.CurrentEntRow.Inactif = Not TbInactif.Checked
        MajBoutons()
    End Sub
#End Region

#Region "Button"
    Private Sub AjouterCibleCommercialButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterCibleCommercialButton.Click
        If (Me.CibleCommercialComboBox.SelectedIndex > -1) Then
            Me.CibleCommercialTextBox.Text = Me.CibleCommercialTextBox.Text & CStr(Me.CibleCommercialComboBox.SelectedValue) & Microsoft.VisualBasic.vbCrLf
        End If
    End Sub

    Private Sub NouveauCibleCommercialButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauCibleCommercialButton.Click
        Using fr As New FrListeChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeCibleCommercial)
            If (fr.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Me.ListeChoixCibleCommercialBindingSource.DataSource = Me.ListeChoixTA.GetDataByNomChoix(DsAgrifactTableAdapters.ListeChoixTA.NomsChoix.ListeCibleCommercial)
            End If
        End Using
    End Sub
#End Region

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles CiviliteComboBox.Validated, NomTextBox.Validated, AdresseTextBox.Validated, _
                    CodePostalTextBox.Validated, VilleTextBox.Validated, PaysTextBox.Validated, _
                    ObservationsTextBox.Validated
        FournBindingSource.EndEdit()
    End Sub

End Class
