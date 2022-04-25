Public Class FrListeBanque

#Region "Constructeurs"

#End Region

#Region "Props"
    Public ReadOnly Property CurrentBanqueRow() As DsPieces.BanqueRow
        Get
            If Me.BanqueBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsPieces.BanqueRow)(Cast(Of DataRowView)(Me.BanqueBindingSource.Current).Row)
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.BanqueDataGridView.UseWaitCursor = True
            Application.DoEvents()

            Dim curId As Decimal = -1
            If Me.BanqueBindingSource.Position >= 0 Then
                curId = Me.CurrentBanqueRow.nBanque
            End If

            Me.BanqueTA.Fill(Me.DsPieces.Banque)

            If curId > -1 Then
                Me.BanqueBindingSource.Position = Me.BanqueBindingSource.Find("nBanque", curId)
            End If
        Finally
            Cursor.Current = Cursors.Default
            Me.BanqueDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.BanqueBindingSource.EndEdit()
        If Me.DsPieces.HasChanges Then
            Try
                Me.BanqueTA.Update(Me.DsPieces.Banque)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.BanqueBindingSource.EndEdit()
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

    Private Sub BanqueBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BanqueBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewBanque()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        Try
            Me.BanqueBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
        MajBoutons()
    End Sub

    Private Sub TbFiltrer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFiltrer.CheckedChanged
        If Not TbFiltrer.Checked Then
            Me.BanqueBindingSource.Filter = ""
        End If
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.BanqueBindingSource.Position >= 0 Then
            Me.BanqueBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.DsPieces)
        Compta.ChargerDonneesCompta(Me.DsPieces)
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsPieces, "Banque")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        Me.BanqueBindingSource.Filter = strCritere
        TbFiltrer.Checked = True
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
        ApplyStyle(Me.BanqueDataGridView)
        ConfigDataTableEvents(Me.DsPieces.Banque, Nothing)
        ChargerDonnees()
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.BanqueBindingNavigatorSaveItem.Enabled = Me.DsPieces.HasChanges
    End Sub

#Region " Control events "
    Private Sub BanqueDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BanqueDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentBanque()
            e.Handled = True
        End If
    End Sub

    Private Sub BanqueDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BanqueDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentBanque()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub
#End Region

    Private Sub CreateNewBanque()
        Dim fr As New FrBanque()
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub OpenCurrentBanque()
        If Me.BanqueBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrBanque(CInt(Me.CurrentBanqueRow.nBanque))
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = Me.WindowState
        End If
        fr.Show()
    End Sub

End Class