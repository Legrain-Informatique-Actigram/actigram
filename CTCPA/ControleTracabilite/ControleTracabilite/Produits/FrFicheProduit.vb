Public Class FrFicheProduit

#Region "Props"
    Private modif As Boolean

    Private _nProduit As Integer = -1
    Public Property NProduit() As Integer
        Get
            Return _nProduit
        End Get
        Set(ByVal value As Integer)
            _nProduit = value
        End Set
    End Property

    Private ReadOnly Property CurrentProduitRow() As AgrifactTracaDataSet.ProduitRow
        Get
            If Me.ProduitBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.ProduitBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ProduitRow)
            End If
        End Get
    End Property

    Private _typeProduit As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.Tous
    Public Property TypeProduit() As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits
        Get
            Return _typeProduit
        End Get
        Set(ByVal value As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)
            _typeProduit = value
        End Set
    End Property

    Private _nFamille As Short = -1
    Public Property nFamille() As Short
        Get
            Return _nFamille
        End Get
        Set(ByVal value As Short)
            _nFamille = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nProduit As Integer)
        Me.New()
        Me.NProduit = nProduit
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ListeChoixTableAdapter.FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeUnite)
        Me.FamilleTableAdapter.Fill(Me.AgrifactTracaDataSet.Famille)
        If Me.NProduit >= 0 Then
            Me.ProduitTableAdapter.FillByNProduit(Me.AgrifactTracaDataSet.Produit, Me.NProduit)
            If Me.ProduitBindingSource.Count > 0 Then Me.ProduitBindingSource.MoveFirst()
            Me.TbInactif.Checked = Not Me.CurrentProduitRow.Inactif
        Else
            Me.ProduitBindingSource.AddNew()
            If Me.nFamille >= 0 Then
                Me.CurrentProduitRow.Famille1 = Me.nFamille
            End If
            Me.TbInactif.Checked = Not Me.CurrentProduitRow.Inactif
            Me.CurrentProduitRow.ProduitAchat = (Me.TypeProduit = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres)
            Me.CurrentProduitRow.ProduitVente = (Me.TypeProduit = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.ProduitsFinis)
            Me.ProduitBindingSource.ResetCurrentItem()
        End If
        Me.ChkCoefU2.Checked = Not Me.CurrentProduitRow.IsCoefU2Null
        MajBoutons()
    End Sub

    Private Function Enregistrer() As Boolean
        If Me.Validate() Then
            Me.ProduitBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Dim oldCodeProduit As String = Nothing
                With Me.CurrentProduitRow
                    If Not .ProduitVente AndAlso .ProduitCompose Then .ProduitCompose = False
                    If .RowState = DataRowState.Modified _
                    AndAlso Not IsDBNull(.Item("CodeProduit", DataRowVersion.Original)) _
                    AndAlso .CodeProduit <> Convert.ToString(.Item("CodeProduit", DataRowVersion.Original)) Then
                        'Il y a eu modif du CodeProduit => A repercuter
                        oldCodeProduit = Convert.ToString(.Item("CodeProduit", DataRowVersion.Original))
                    End If
                End With
                Me.ProduitTableAdapter.Update(Me.AgrifactTracaDataSet.Produit)
                If oldCodeProduit IsNot Nothing Then
                    Me.ProduitTableAdapter.UpdateCodeProduit(oldCodeProduit, Me.CurrentProduitRow.CodeProduit)
                End If
                modif = True
            End If
            MajBoutons()
            Return True
        Else
            Dim strErrs As String = GetErrors()
            Dim msg As String = ""
            If strErrs.Length > 0 Then
                msg = String.Format("Vous devez corriger les erreurs suivantes avant de pouvoir enregistrer :" & vbCrLf & "{0}", strErrs)
            Else
                msg = "Vous ne pouvez pas enregistrer les données tant que des erreurs sont présentes."
            End If
            MsgBox(msg, MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function

    Private Function DemanderEnregistrement() As Boolean
        If Me.Validate() Then
            Me.ProduitBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Return Enregistrer()
                    Case MsgBoxResult.No
                    Case MsgBoxResult.Cancel
                        Return False
                End Select
            End If
            Return True
        Else
            Return MsgBox("Impossible d'enregistrer les données." & vbCrLf & "Voulez-vous abandonner les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes
        End If
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
        Me.lbU1.Text = ""
        ConfigDecimalControl(Me.TxSeuilStock, 3)
        ConfigDecimalControl(Me.CoefU2TextBox, 3)
        ConfigDecimalControl(Me.CodeBarreTextBox, 0)
        ConfigZoomTextbox(LibelleLongTextBox)
        With Me.AgrifactTracaDataSet
            .Produit.InitAutoIncrementSeed()
            ConfigDataTableEvents(.Produit, AddressOf MajBoutons)
        End With
        ChargerDonnees()
        ChkCoefU2_CheckedChanged(Nothing, Nothing)
        CoefU2TextBox_Validated(Nothing, Nothing)
        AddHandler ChkCoefU2.CheckedChanged, AddressOf ChkCoefU2_CheckedChanged
    End Sub
#End Region

#Region "Validation"
    Private Function GetErrors() As String
        Return FormsUtils.GetErrors(Me, ErrorProvider)
    End Function

    Private Overloads Function Validate() As Boolean
        If MyBase.Validate Then
            Return Not ControlHasErrors(Me, ErrorProvider)
        Else
            Return False
        End If
    End Function

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CodeProduitTextBox.Validated, Famille1ComboBox.SelectedIndexChanged, LibelleTextBox.Validated, _
    LibelleLongTextBox.Validated, ProduitAchatCheckBox.CheckedChanged, ProduitVenteCheckBox.CheckedChanged, CoefU2TextBox.Validated, CodeBarreTextBox.Validated, _
    Unite1ComboBox.SelectedIndexChanged, Unite2ComboBox.SelectedIndexChanged
        Me.Validate()
        ProduitBindingSource.EndEdit()
        MajBoutons()
    End Sub

    Private Sub Unite1ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Unite1ComboBox.SelectedIndexChanged
        Me.lbU1.Text = Me.Unite1ComboBox.Text
    End Sub

    Private Sub Chk_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ProduitAchatCheckBox.Validating, ProduitVenteCheckBox.Validating
        ErrorProvider.SetError(ProduitVenteCheckBox, "")
        If Not ProduitVenteCheckBox.Checked And Not ProduitAchatCheckBox.Checked Then
            ErrorProvider.SetError(ProduitVenteCheckBox, "Au moins un des choix doit être coché.")
        End If
    End Sub

    Private Sub CodeProduitTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodeProduitTextBox.Validating
        ErrorProvider.SetError(CodeProduitTextBox, "")
        If CodeProduitTextBox.Text.Trim.Length = 0 Then
            ErrorProvider.SetError(CodeProduitTextBox, "Le code produit doit être renseigné")
        Else
            If CType(Me.ProduitBindingSource.Current, DataRowView).IsNew _
            OrElse CodeProduitTextBox.Text.Trim <> Convert.ToString(Me.CurrentProduitRow("CodeProduit")) Then
                If ProduitTableAdapter.CodeProduitExists(CodeProduitTextBox.Text.Trim, Me.CurrentProduitRow.nProduit).GetValueOrDefault() Then
                    ErrorProvider.SetError(CodeProduitTextBox, "Ce code produit existe déjà")
                End If
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
            If Me.ProduitBindingSource.Position >= 0 AndAlso Me.CurrentProduitRow.Inactif Then
                .Text = "Produit inactif"
                .ToolTipText = "Cliquez pour activer le produit."
                .Image = My.Resources.inactif
            Else
                .Text = "Produit actif"
                .ToolTipText = "Cliquez pour désactiver le produit."
                .Image = My.Resources.actif
            End If
        End With
        Me.ChkCoefU2.Enabled = Me.Unite2ComboBox.Text.Length > 0
        Me.TbComposition.Enabled = Me.ProduitVenteCheckBox.Checked
        ProduitBindingNavigatorSaveItem.Enabled = Me.AgrifactTracaDataSet.HasChanges
    End Sub

    Private Sub ChkCoefU2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ChkCoefU2.Checked Then
            Me.CoefU2TextBox.Enabled = True
        Else
            Me.CoefU2TextBox.Enabled = False
            Me.CoefU2TextBox.Text = ""
        End If
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbComposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbComposition.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        If Not DemanderEnregistrement() Then Exit Sub
        With New FrCompoProduit(Me.CurrentProduitRow.CodeProduit)
            .Owner = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub TbControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbControles.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        If Me.CurrentProduitRow.IsCodeProduitNull Then Exit Sub
        If Not DemanderEnregistrement() Then Exit Sub
        If Not FrValidAdmin.ValidAdmin Then Exit Sub
        With New Controles.FrListeControles
            .CodeProduit = Me.CurrentProduitRow.CodeProduit
            .MatierePremiere = Me.CurrentProduitRow.ProduitAchat
            .ProduitFini = Me.CurrentProduitRow.ProduitVente
            .Owner = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub TbInactif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbInactif.CheckedChanged
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        If Me.CurrentProduitRow.Inactif = TbInactif.Checked Then Me.CurrentProduitRow.Inactif = Not TbInactif.Checked
        MajBoutons()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtNewCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNewCB.Click
        'Affecter un nouveau code barre au produit
        If Me.CodeBarreTextBox.Text.Length = 0 OrElse MsgBox("Voulez-vous créer un nouveau code pour ce produit ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.CodeBarreTextBox.Text = Me.ProduitTableAdapter.GetNewCodeBarre
            Controls_Validated(Nothing, Nothing)
        End If
    End Sub
#End Region

    Private Sub CoefU2TextBox_Validated(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Unite1ComboBox.SelectedIndexChanged, Unite2ComboBox.SelectedIndexChanged, CoefU2TextBox.TextChanged
        Dim res As String = ""
        If Me.Unite1ComboBox.Text.Length > 0 AndAlso Me.Unite2ComboBox.Text.Length > 0 _
        AndAlso Me.ChkCoefU2.Checked AndAlso CoefU2TextBox.Text.Length > 0 Then
            res = String.Format("Pour ce produit : 1 {0} équivaut à {2} {1}", Me.Unite1ComboBox.Text, Me.Unite2ComboBox.Text, Me.CoefU2TextBox.Text)
        End If
        lbDescUnites.Text = res
    End Sub

    Private Sub chkStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStock.CheckedChanged
        Me.TxSeuilStock.Enabled = chkStock.Checked
        Me.lbSeuilStock.Enabled = chkStock.Checked
        Me.lbU1.Enabled = chkStock.Checked
    End Sub

    Private Sub LibelleTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibelleTextBox.Validated
        If Me.CurrentProduitRow.IsCodeProduitNull OrElse Me.CurrentProduitRow.CodeProduit.Length = 0 Then
            Me.CurrentProduitRow.CodeProduit = Microsoft.VisualBasic.Left(Me.CurrentProduitRow.Libelle.Replace(" ", ""), 8)
            Me.ProduitBindingSource.ResetCurrentItem()
            CodeProduitTextBox_Validating(Nothing, Nothing)
        End If
    End Sub
End Class