Public Class FrListePersonne

#Region "Constructeurs"

#End Region

#Region "Props"
    Public ReadOnly Property CurrentPersRow() As DsAgrifact.PersonneRow
        Get
            If Me.PersonneBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.PersonneDataGridView.UseWaitCursor = True
            Application.DoEvents()

            Dim curId As Decimal = -1
            If Me.PersonneBindingSource.Position >= 0 Then
                curId = Me.CurrentPersRow.nPersonne
            End If

            Me.PersonneTA.Fill(Me.DsAgrifact.Personne)
            Filtrer()

            If curId > -1 Then
                Me.PersonneBindingSource.Position = Me.PersonneBindingSource.Find("nPersonne", curId)
            End If
        Finally
            Cursor.Current = Cursors.Default
            Me.PersonneDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.PersonneBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Try
                Me.PersonneTA.Update(Me.DsAgrifact.Personne)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.PersonneBindingSource.EndEdit()
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

    Private _customFilter As Boolean
    Private _isFiltering As Boolean
    Private Sub Filtrer()
        If _customFilter Then Exit Sub
        If _isFiltering Then Exit Sub
        Dim filter As String = ""
        If Me.TbFilter.Checked Then
            filter = "NpAfficher=False"
            If Me.TxRecherche.Text.Trim.Length > 0 Then
                filter &= FormatExpression(" AND (Nom like {0} OR Prenom like {0} OR CodePostal like {0} OR Ville like {0})", "%" & Me.TxRecherche.Text.Trim & "%")
            End If
        End If
        _isFiltering = True
        If Me.PersonneBindingSource.Filter <> filter Then
            Cursor.Current = Cursors.WaitCursor
            Me.PersonneBindingSource.Filter = filter
            Cursor.Current = Cursors.Default
        End If
        _isFiltering = False
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub EntrepriseBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntrepriseBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewPersonne()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        Try
            Me.PersonneBindingSource.RemoveCurrent()
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
        ImprimerListeContacts()
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.PersonneBindingSource.Position >= 0 Then
            Me.PersonneBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.DsAgrifact)
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsAgrifact, "Personne")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        _customFilter = True
        Me.PersonneBindingSource.Filter = strCritere
    End Sub
#End Region

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
        ApplyStyle(Me.PersonneDataGridView)
        ConfigColSel(Me.PersonneDataGridView, Me.ColSel)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsAgrifact.Personne, Nothing)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.EntrepriseBindingNavigatorSaveItem.Enabled = Me.DsAgrifact.HasChanges
    End Sub

#Region " Control events "
    Private Sub EntrepriseDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PersonneDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentPersonne()
            e.Handled = True
        End If
    End Sub

    Private Sub EntrepriseDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PersonneDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentPersonne()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub
#End Region
    Private Sub ImprimerListeContacts()
        Dim myDs As DataSet
        myDs = Me.DsAgrifact.Clone
        myDs.EnforceConstraints = False

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(myDs, "Telephone", s)
            DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s)
        End Using

        Dim drs As List(Of DataRow) = GetSelectedRows(Me.PersonneDataGridView)
        If drs.Count > 0 Then
            myDs.Merge(drs.ToArray)
        Else
            For Each drv As DataRowView In Me.PersonneBindingSource
                myDs.Merge(New DataRow() {drv.Row})
            Next
        End If

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeContact.rpt")
        fr.LibelleSelection = "Liste Personne"
        fr.Show()
    End Sub

    Private Sub CreateNewPersonne()
        Dim fr As New FrPersonne()
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub OpenCurrentPersonne()
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrPersonne(CInt(Me.CurrentPersRow.nPersonne))
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = FormWindowState.Maximized
        End If
        fr.Show()
    End Sub

End Class