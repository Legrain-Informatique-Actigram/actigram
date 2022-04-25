Public Class FrListeLots

    Private _customFilter As Boolean

#Region " Props "
    Private ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.LotBindingSource.Position < 0 Then Return Nothing
            If Not TypeOf Me.LotBindingSource.Current Is DataRowView Then Return Nothing
            Return Cast(Of DataRowView)(Me.LotBindingSource.Current)
        End Get
    End Property
#End Region

#Region " Form Events "
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FrListeLots_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.LotDataGridView)
        ChargerDonnees()
        TbTous.Checked = True
        ConfigDataTableEvents(Me.StocksDataSet.Lot, AddressOf MajBoutons)
    End Sub
#End Region

#Region " Données "
    Private Sub ChargerDonnees()
        'MODIF TV 30/01/2012 --> MODIF SUPPRIMEE LE 05/10/2012 car ne marche pas chez Micouleau
        'Me.LotTA.FillLots(Me.StocksDataSet.Lot)
        '-------------------------
        Me.LotTA.FillTerm(Me.StocksDataSet.Lot)

    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.LotBindingSource.EndEdit()
        If Me.StocksDataSet.HasChanges Then
            Try
                Me.LotTA.DeleteLots(Me.StocksDataSet.Lot)
                'Me.LotTA.Update(Me.StocksDataSet.Lot)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.LotBindingSource.EndEdit()
        If Me.StocksDataSet.HasChanges Then
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

#Region " Toolbar "
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        Dim fr As New FrLot()
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.LotBindingSource.Position < 0 Then Exit Sub

        'Vérifie que le lot n'est pas utilisé
        Using LotTA As New StocksDataSetTableAdapters.LotTA
            If (CInt(LotTA.LotUtilise(CStr(Me.CurrentDrv("nLot")))) > 0) Then
                MsgBox("Suppression impossible : le lot est référencé.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If
        End Using

        Try
            Me.LotBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try

        MajBoutons()
    End Sub

    Private Sub TbTermine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbTermine.Click
        If Me.LotBindingSource.Position < 0 Then Exit Sub
        If MsgBox("Voulez-vous marquer ce lot comme terminé pour tous les produits qui le composent ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'MODIF TV 30/01/2012
        Me.LotTA.InsertLotsTerminesBynLot(CStr(Me.CurrentDrv("nLot")))
        'legrain 06/03/2014 , la ligne suivante était en commentaire
        Me.LotTA.MarquerTermine(CStr(Me.CurrentDrv("nLot")))
        '---------------------------

        ChargerDonnees()
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        FrLot.ImprimerFicheTraca(Me, Convert.ToString(Me.CurrentDrv("nLot")))
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.LotBindingSource.Position >= 0 Then
            Me.LotBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.StocksDataSet)
        Dim myFrRecherche As New GRC.FrRecherche(Me.StocksDataSet, "Lot")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub DupliquerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripButton.Click
        Me.Dupliquer()
    End Sub

    Private Sub ReactiverLotTermineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReactiverLotTermineToolStripButton.Click
        Me.ReactiverLotTermine()
    End Sub
#End Region

#Region "LotDataGridView"
    Private Sub LotDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LotDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r As DataGridViewRow = Me.LotDataGridView.Rows(e.RowIndex)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim fr As New FrLot(Convert.ToString(CType(r.DataBoundItem, DataRowView)("NLot")))
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.StocksDataSet.HasChanges
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        Me.LotBindingSource.Filter = strCritere
        _customFilter = True
        TbTous.Checked = True
    End Sub

    Private Sub Dupliquer()
        If Me.LotBindingSource.Position < 0 Then Exit Sub

        Using fr As New FrDupliquerLot(CStr(Me.CurrentDrv("nLot")))
            If (fr.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Me.ChargerDonnees()
            End If
        End Using
    End Sub

    Private Sub ReactiverLotTermine()
        If Me.LotBindingSource.Position < 0 Then Exit Sub

        If Not (CBool(Me.CurrentDrv("Termine"))) Then
            MsgBox("Veuillez sélectionner un lot terminé.", MsgBoxStyle.Information, "")

            Exit Sub
        End If

        If MsgBox("Voulez-vous réactiver ce lot ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Using LotsTerminesTA As New StocksDataSetTableAdapters.LotsTerminesTA
            LotsTerminesTA.DeleteBynLot(CStr(Me.CurrentDrv("nLot")))
        End Using

        Me.ChargerDonnees()
    End Sub
#End Region

    Private Sub TbTous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbTous.CheckedChanged
        If Not TbTous.Checked Then
            Me.LotBindingSource.Filter = ""
            _customFilter = False
        ElseIf Not _customFilter Then
            Me.LotBindingSource.Filter = "Termine=false"
        End If
    End Sub

    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        Dim tx As String = TxRech.Text.Trim
        If tx.Length = 0 Then
            _customFilter = False
            TbTous_CheckedChanged(Nothing, EventArgs.Empty)
        Else
            Me.LotBindingSource.Filter = String.Format("nLot like '{0}*'", Replace(tx, "'", "''"))
            _customFilter = True
            TbTous.Checked = True
        End If
    End Sub
    
End Class