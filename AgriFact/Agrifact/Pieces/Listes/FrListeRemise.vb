Public Class FrListeRemise

#Region "Constructeurs"

#End Region

#Region "Props"
    Public ReadOnly Property CurrentRemiseRow() As DsPieces.RemiseRow
        Get
            If Me.RemiseBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsPieces.RemiseRow)(Cast(Of DataRowView)(Me.RemiseBindingSource.Current).Row)
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            Dim curId As Decimal = -1
            If Me.RemiseBindingSource.Position >= 0 Then
                curId = Me.CurrentRemiseRow.nRemise
            End If

            With Me.DsPieces
                .EnforceConstraints = False
                If .Banque.Count = 0 Then Me.BanqueTA.Fill(.Banque)
                Me.RemiseTA.Fill(.Remise)
                .EnforceConstraints = True
            End With

            If curId > -1 Then
                Me.RemiseBindingSource.Position = Me.RemiseBindingSource.Find("nRemise", curId)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.RemiseBindingSource.EndEdit()
        If Me.DsPieces.HasChanges Then
            Try
                Me.RemiseTA.Update(Me.DsPieces.Remise)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.RemiseBindingSource.EndEdit()
        If Me.DsPieces.HasChanges Then
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

#Region "Toolbar"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub RemisBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemiseBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        Try
            Me.RemiseBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
        MajBoutons()
    End Sub

    Private _customFilter As Boolean = False
    Private Sub TbFiltrer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFiltrer.CheckedChanged
        If Not TbFiltrer.Checked Then
            _customFilter = False
            Me.RemiseBindingSource.Filter = ""
        Else
            If Not _customFilter Then Me.RemiseBindingSource.Filter = "ExportCompta=False"
        End If
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.RemiseBindingSource.Position >= 0 Then
            Me.RemiseBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.DsPieces)
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsPieces, "Remise")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        _customFilter = True
        Me.RemiseBindingSource.Filter = strCritere
        TbFiltrer.Checked = True
    End Sub

    Private Sub ImprimerLaRemiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLaRemiseToolStripMenuItem.Click, ToolStripButton1.ButtonClick
        Me.ImprimerRemise()
    End Sub

    Private Sub ImprimerLaListeDesRemisesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLaListeDesRemisesToolStripMenuItem.Click
        Me.ImprimerLstRemise()
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
        ApplyStyle(Me.RemiseDataGridView)
        ConfigColSel(Me.RemiseDataGridView, Me.ColSel)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsPieces.Remise, Nothing)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.RemiseBindingNavigatorSaveItem.Enabled = Me.DsPieces.HasChanges
    End Sub

#Region " Control events "
    Private Sub RemiseDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RemiseDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentRemise()
            e.Handled = True
        End If
    End Sub

    Private Sub RemiseDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RemiseDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentRemise()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub
#End Region

    Private Sub OpenCurrentRemise()
        If Me.RemiseBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrRemise(CInt(Me.CurrentRemiseRow.nRemise))
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = Me.WindowState
        End If
        fr.Show()
    End Sub

    Private Sub ImprimerRemise()
        If Me.RemiseBindingSource.Position < 0 Then Exit Sub
        Try
            Dim myDs As DataSet = DsPieces.Clone
            With myDs
                .EnforceConstraints = False
                .Merge(New DataRow() {Me.CurrentRemiseRow})
            End With
            Dim nRemise As Integer = CInt(Me.CurrentRemiseRow.nRemise)
            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(myDs, "Banque", s)
                DefinitionDonnees.Instance.Fill(myDs, "Parametres", s)
                DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s, String.Format("nEntreprise IN (SELECT nEntreprise FROM Reglement rg INNER JOIN Remise_Detail rmd ON rmd.nReglement=rg.nReglement WHERE nRemise={0})", nRemise))
                DefinitionDonnees.Instance.Fill(myDs, "VFacture", s, String.Format("nDevis IN (SELECT nDevis FROM Reglement_Detail rgd INNER JOIN Remise_Detail rmd ON rmd.nReglement=rgd.nReglement WHERE nRemise={0})", nRemise))
                DefinitionDonnees.Instance.Fill(myDs, "Reglement", s, String.Format("nReglement IN (SELECT nReglement FROM Remise_Detail WHERE nRemise={0})", nRemise))
                DefinitionDonnees.Instance.Fill(myDs, "Reglement_Detail", s, String.Format("nReglement IN (SELECT nReglement FROM Remise_Detail WHERE nRemise={0})", nRemise))
                DefinitionDonnees.Instance.Fill(myDs, "Remise_Detail", s, "nRemise=" & nRemise)
            End Using
            Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptRemise.rpt")
            GestionImpression.AppliquerParametres(fr, myDs)
            fr.Show()
        Catch
        End Try
    End Sub

    Private Sub ImprimerLstRemise()
        Dim myDs As DataSet = Me.DsPieces.Clone
        With myDs
            .EnforceConstraints = False

            .Merge(Me.DsPieces.Banque)
            Dim drs As List(Of DataRow) = GetSelectedRows(Me.RemiseDataGridView)
            If drs.Count = 0 Then
                .Merge(Me.DsPieces.Remise.Select(Me.RemiseBindingSource.Filter))
            Else
                .Merge(drs.ToArray)
            End If
        End With

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeRemises.rpt")
        fr.Show()
    End Sub

End Class