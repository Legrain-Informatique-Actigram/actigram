Namespace Fournisseurs
    Public Class FrSaisieFourn

#Region "Props"
        Private modif As Boolean

        Private _nEnt As Integer = -1
        Public Property NEntreprise() As Integer
            Get
                Return _nEnt
            End Get
            Set(ByVal value As Integer)
                _nEnt = value
            End Set
        End Property

        Private ReadOnly Property CurrentEntRow() As AgrifactTracaDataSet.EntrepriseRow
            Get
                If Me.FournBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.FournBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.EntrepriseRow)
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

#Region "Données"
        Private Sub ChargerDonnees()
            Me.ListeChoixTableAdapter.FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.FormeJuridique)
            If Me.NEntreprise >= 0 Then
                Me.EntrepriseTableAdapter.FillByNEnt(Me.AgrifactTracaDataSet.Entreprise, Me.NEntreprise)
                Me.TelephoneEntrepriseTableAdapter.FillByNEnt(Me.AgrifactTracaDataSet.TelephoneEntreprise, Me.NEntreprise)
                Me.TbBR.Enabled = True
                Me.TbInactif.Checked = Not Me.CurrentEntRow.Inactif
                If Not Me.CurrentEntRow.IsTypeClientNull AndAlso Me.CurrentEntRow.TypeClient = "entreprise" Then
                    Me.ChkEntreprise.Checked = True
                End If
                Me.CurrentEntRow.AcceptChanges()
            Else
                Me.FournBindingSource.AddNew()
                Me.TbBR.Enabled = False
                Me.TbInactif.Checked = Not Me.CurrentEntRow.Inactif
            End If
            MajBoutons()
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.FournBindingSource.EndEdit()
            Me.TelephoneEntrepriseBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                'Virer les téléphones de type null
                For Each dr As DataRow In Me.AgrifactTracaDataSet.TelephoneEntreprise.Select("Type is null OR Type=''")
                    dr.Delete()
                Next
                Me.EntrepriseTableAdapter.Update(Me.AgrifactTracaDataSet.Entreprise)
                Me.TelephoneEntrepriseTableAdapter.Update(Me.AgrifactTracaDataSet.TelephoneEntreprise)
                modif = True
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.FournBindingSource.EndEdit()
            Me.TelephoneEntrepriseBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
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

#Region "Page"
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

            ApplyStyle(Me.TelephoneEntrepriseDataGridView, False)
            With TelephoneEntrepriseDataGridView
                AddHandler .EditingControlShowing, AddressOf MakeComboDropDown
                AddHandler .CellValidating, AddressOf cellvalidating
            End With

            Me.AgrifactTracaDataSet.Entreprise.InitAutoIncrementSeed()
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Entreprise, AddressOf MajBoutons)
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.TelephoneEntreprise, AddressOf MajBoutons, False)
            ChargerDonnees()
        End Sub
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
                    .Text = "Fournisseur inactif"
                    .ToolTipText = "Cliquez pour activer le fournisseur."
                    .Image = My.Resources.inactif
                Else
                    .Text = "Fournisseur actif"
                    .ToolTipText = "Cliquez pour désactiver le fournisseur."
                    .Image = My.Resources.actif
                End If
            End With
            ProduitBindingNavigatorSaveItem.Enabled = Me.AgrifactTracaDataSet.HasChanges
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
            Enregistrer()
        End Sub

        Private Sub TbBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbBR.Click
            If Me.FournBindingSource.Current Is Nothing Then Exit Sub
            Using fr As New Receptions.FrListeBR(CInt(Me.CurrentEntRow.nEntreprise))
                fr.Owner = Me
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog()
            End Using
        End Sub

        Private Sub TbNewBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewBR.Click
            If Me.FournBindingSource.Current Is Nothing Then Exit Sub
            Using fr As New Receptions.FrSaisieBR()
                fr.Owner = Me
                fr.NFournisseur = CInt(Me.CurrentEntRow.nEntreprise)
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog()
            End Using
        End Sub

        Private Sub TbInactif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbInactif.CheckedChanged
            If Me.FournBindingSource.Position < 0 Then Exit Sub
            Me.CurrentEntRow.Inactif = Not TbInactif.Checked
            MajBoutons()
        End Sub
#End Region

        Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CiviliteComboBox.Validated, NomTextBox.Validated, AdresseTextBox.Validated, CodePostalTextBox.Validated, VilleTextBox.Validated, PaysTextBox.Validated, ObservationsTextBox.Validated
            FournBindingSource.EndEdit()
        End Sub

        Private Sub ChkEntreprise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEntreprise.CheckedChanged
            If Me.FournBindingSource.Current Is Nothing Then Exit Sub
            Me.CurrentEntRow("TypeClient") = IIf(ChkEntreprise.Checked, "entreprise", DBNull.Value)
        End Sub

    End Class
End Namespace
