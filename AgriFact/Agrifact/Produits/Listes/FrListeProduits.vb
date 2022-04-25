Public Class FrListeProduits

    Private _customFilter As Boolean
    Private _isFiltering As Boolean

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nFamille As Short)
        Me.New()
        Me.NFamille = nFamille
    End Sub
#End Region

#Region "Props"
    Public ReadOnly Property CurrentProdRow() As DsAgrifact.ProduitRow
        Get
            If Me.ProduitBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsAgrifact.ProduitRow)(Cast(Of DataRowView)(Me.ProduitBindingSource.Current).Row)
        End Get
    End Property


    Private nTarif As Integer = -1

    Private _nFamille As Short = -1
    Public Property NFamille() As Short
        Get
            Return _nFamille
        End Get
        Set(ByVal value As Short)
            _nFamille = value
        End Set
    End Property

#End Region

#Region "Données"
    Private Sub ChargerDonneesRef()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            Me.TarifTableAdapter.Fill(Me.DsAgrifact.Tarif)
            Me.FamilleTA.Fill(Me.DsAgrifact.Famille)

            FillCb(Me.TarifBindingSource, Me.cbTarifs, "Libelle", "nTarif", Nothing, False, True)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ChargerDonnees(Optional ByVal curId As Decimal = -1)
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            Me.DsAgrifact.EnforceConstraints = False

            If curId < 0 AndAlso Me.ProduitBindingSource.Position >= 0 Then
                curId = Me.CurrentProdRow.nProduit
            End If

            If Me.nTarif >= 0 Then
                If Me.NFamille >= 0 Then
                    Me.ProduitTA.FillByTarifAndFamille(Me.DsAgrifact.Produit, Me.nTarif, Me.NFamille)
                Else
                    Me.ProduitTA.FillByTarif(Me.DsAgrifact.Produit, Me.nTarif)
                End If
            Else
                If Me.NFamille >= 0 Then
                    Me.ProduitTA.FillByFamille(Me.DsAgrifact.Produit, Me.NFamille)
                Else
                    Me.ProduitTA.Fill(Me.DsAgrifact.Produit)
                End If
            End If

            Filtrer()

            If curId > -1 Then
                Me.ProduitBindingSource.Position = Me.ProduitBindingSource.Find("nProduit", curId)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.ProduitBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Try
                Me.ProduitTA.Update(Me.DsAgrifact.Produit)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.ProduitBindingSource.EndEdit()
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

    Private Sub Filtrer()
        If _customFilter Then Exit Sub
        If _isFiltering Then Exit Sub
        Dim filter As String = ""
        If Me.TbFilter.Checked Then
            filter = "Inactif=False AND ProduitVente=True"
            If Me.TxRecherche.Text.Trim.Length > 0 Then
                filter &= FormatExpression(" AND (CodeProduit like {0} OR Libelle like {0} OR NomFamille like {0})", "%" & Me.TxRecherche.Text.Trim & "%")
            End If
        End If
        _isFiltering = True
        If Me.ProduitBindingSource.Filter <> filter Then
            Cursor.Current = Cursors.WaitCursor
            Me.ProduitBindingSource.Filter = filter
            Cursor.Current = Cursors.Default
        End If
        _isFiltering = False
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFusionner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFusionner.Click
        Me.FusionnerProduits()

        Me.ChargerDonnees()
    End Sub

    Private Sub TbModifierCodeProduit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbModifierCodeProduit.Click
        Me.ModifierCodeProduit()

        Me.ChargerDonnees()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntrepriseBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewProduit()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.ProduitBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
        MajBoutons()
    End Sub

    Private Sub TbTous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        If Not TbFilter.Checked Then _customFilter = False
        Filtrer()
    End Sub

    Private Sub TxRecherche_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxRecherche.Leave
        Filtrer()
    End Sub

    Private Sub TxRecherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRecherche.TextChanged
        If Me.DsAgrifact.Entreprise.Count > 3000 Then Exit Sub
        Filtrer()
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerListeProduits()
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.ProduitBindingSource.Position >= 0 Then
            Me.ProduitBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.DsAgrifact)
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsAgrifact, "Produit")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        _customFilter = True
        Me.ProduitBindingSource.Filter = strCritere
    End Sub

    Private Sub TbDupliquer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDupliquer.Click
        DupliquerProduits()
    End Sub

    Private Sub TbMajBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbMajBalance.Click
        MajBalance()
    End Sub

    Private Sub TbSaisieTarifs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSaisieTarifs.Click
        Dim fr As New FrSaisieTarifs()
        If cbTarifs.SelectedIndex > 0 Then
            Dim lv As ListboxItem = Cast(Of ListboxItem)(cbTarifs.SelectedItem)
            If lv.Value IsNot Nothing Then
                fr.nTarif = CInt(Cast(Of DsAgrifact.TarifRow)(lv.Value).nTarif)
            End If
        End If
        fr.ShowDialog(Me)
        ChargerDonnees()
    End Sub

    Private Sub cbTarifs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTarifs.SelectedIndexChanged
        Me.nTarif = -1
        If cbTarifs.SelectedIndex >= 0 Then
            Dim lv As ListboxItem = Cast(Of ListboxItem)(cbTarifs.SelectedItem)
            If lv.Value IsNot Nothing Then
                Me.nTarif = CInt(Cast(Of DsAgrifact.TarifRow)(lv.Value).nTarif)
            End If
        End If
        ChargerDonnees()
    End Sub
#End Region

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        If Not FrApplication.Modules.ModuleTarif Then
            Me.LbTarif.Visible = False
            Me.cbTarifs.Visible = False
        End If
        ApplyStyle(Me.ProduitDataGridView)
        ConfigColSel(Me.ProduitDataGridView, Me.ColSel)
        Using s As New SqlProxy
            With Me.DsAgrifact.Produit.nProduitColumn
                .AutoIncrement = True
                .AutoIncrementSeed = s.GetMaxValue("Produit", "nProduit")
                .AutoIncrementStep = 1000
            End With
        End Using
        ChargerDonneesRef()
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsAgrifact.Produit, Nothing)
        MajBoutons()
    End Sub
#End Region

#Region "Boutons"
    Private Sub MajBoutons()
        Me.EntrepriseBindingNavigatorSaveItem.Enabled = Me.DsAgrifact.HasChanges
    End Sub
#End Region

#Region "Control events"
    Private Sub EntrepriseDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProduitDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentProduit()
            e.Handled = True
        End If
    End Sub

    Private Sub EntrepriseDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProduitDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentProduit()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub FusionnerProduits()
        Dim drs As List(Of DataRow) = GetSelectedRows(Me.ProduitDataGridView)

        If (drs.Count <= 1) Then
            MsgBox("Veuillez sélectionner au moins deux produits.", MsgBoxStyle.Exclamation, "Sélection")

            Exit Sub
        End If

        Dim frFusionnerProd As New FrFusionnerProduits(drs)

        If (frFusionnerProd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            frFusionnerProd.Close()
        End If
    End Sub

    Private Sub ModifierCodeProduit()
        Dim drs As List(Of DataRow) = GetSelectedRows(Me.ProduitDataGridView)

        If (drs.Count > 1) Then
            MsgBox("Veuillez ne sélectionner qu'un seul produit.", MsgBoxStyle.Exclamation, "Sélection")

            Exit Sub
        End If

        If (drs.Count = 0) Then
            MsgBox("Veuillez sélectionner un produit.", MsgBoxStyle.Exclamation, "Sélection")

            Exit Sub
        End If

        Dim frModifCodeProd As New FrModifierCodeProduit(CInt(Me.CurrentProdRow.nProduit))

        If (frModifCodeProd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            frModifCodeProd.Close()
        End If
    End Sub

    Private Sub ImprimerListeProduits()
        Dim myDs As DataSet
        myDs = Me.DsAgrifact.Clone
        myDs.EnforceConstraints = False
        myDs.Merge(Me.DsAgrifact.Famille)
        Dim drs As List(Of DataRow) = GetSelectedRows(Me.ProduitDataGridView)
        If drs.Count > 0 Then
            myDs.Merge(drs.ToArray)
        Else
            For Each drv As DataRowView In Me.ProduitBindingSource
                myDs.Merge(New DataRow() {drv.Row})
            Next
        End If
        'TODO Gestion des tarifs

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeProduit.rpt")
        If Me.nTarif > 0 Then
            fr.TitreRapport = "Liste des Produits pour le tarif " & Me.cbTarifs.Text
        End If
        fr.Show()
    End Sub

    Private Sub CreateNewProduit()
        Dim fr As New FrProduit()
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub OpenCurrentProduit()
        If Me.ProduitBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrProduit(CInt(Me.CurrentProdRow.nProduit))
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = Me.WindowState
        End If
        fr.Show()
    End Sub

    Private Sub DupliquerProduits()
        Dim drvs As List(Of DataRowView) = GetSelectedRowViews(Me.ProduitDataGridView)
        If drvs.Count = 0 Then Exit Sub
        Dim lastId As Decimal = -1
        Dim prodsToCopy As New List(Of Couple(Of String, String))
        For Each drv As DataRowView In drvs
            Dim oldRw As DsAgrifact.ProduitRow = Cast(Of DsAgrifact.ProduitRow)(drv.Row)
            Dim newRw As DsAgrifact.ProduitRow = Me.DsAgrifact.Produit.NewProduitRow
            CopyRow(oldRw, newRw)
            newRw.CodeProduit = TrouverNouveauCodeProduit(oldRw.CodeProduit)
            prodsToCopy.Add(New Couple(Of String, String)(oldRw.CodeProduit, newRw.CodeProduit))
            lastId = newRw.nProduit
            Me.DsAgrifact.Produit.AddProduitRow(newRw)
        Next
        Enregistrer()
        For Each c As Couple(Of String, String) In prodsToCopy
            'Composition
            'Tarifs
            Me.ProduitTA.CopyChildRows(c.X, c.Y)
        Next
        ChargerDonnees(lastId)
        MsgBox("Opération Terminée", MsgBoxStyle.Information)
    End Sub

    Private Function TrouverNouveauCodeProduit(ByVal codeOri As String) As String
        Dim res As String = String.Format("{0} (copie)", codeOri)
        Dim i As Integer = 0
        While Me.ProduitTA.CodeExists(res).GetValueOrDefault > 0
            i += 1
            res = String.Format("{1} (copie {0})", i, codeOri)
        End While
        Return res
    End Function

    Private Sub MajBalance()
        DefinitionDonnees.Instance.Fill(Me.DsAgrifact, "TVA")
        Dim drvs As List(Of DataRowView) = GetSelectedRowViews(Me.ProduitDataGridView)
        If drvs.Count = 0 Then Exit Sub
        With New Actigram.Balance.Mira.GestionMira
            .TableTVA = Me.DsAgrifact.Tables("TVA")
            .nBalance = 0
            .EnvoiMajProduit(drvs.ToArray, CBool(ParametresApplication.ValeurParametre("PriceOverWrite", False)))
            .nBalance = 1
        End With
    End Sub
#End Region

End Class