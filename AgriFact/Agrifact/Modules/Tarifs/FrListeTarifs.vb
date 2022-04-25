Public Class FrListeTarifs

#Region "Props"
    Private ReadOnly Property CurrentTarifRow() As DsAgrifact.TarifRow
        Get
            If Me.TarifBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.TarifBindingSource.Current, DataRowView).Row, DsAgrifact.TarifRow)
            End If
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.TarifDataGridView.UseWaitCursor = True
            Application.DoEvents()
            Dim curId As Decimal = -1
            If Me.TarifBindingSource.Current IsNot Nothing Then
                curId = Me.CurrentTarifRow.nTarif
            End If

            Me.TarifBindingSource.SuspendBinding()
            With Me.DsAgrifact
                .EnforceConstraints = False
                Me.TarifTA.Fill(.Tarif)
                .EnforceConstraints = True
            End With
            Me.TarifBindingSource.ResumeBinding()

            If curId > -1 Then
                Me.TarifBindingSource.Position = Me.TarifBindingSource.Find("nTarif", curId)
            End If
            MajBoutons()
        Finally
            Cursor.Current = Cursors.Default
            Me.TarifDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.TarifBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Try
                Me.TarifTA.Update(Me.DsAgrifact.Tarif)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
                Me.DsAgrifact.RejectChanges()
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.TarifBindingSource.EndEdit()
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

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Using s As New SqlProxy
            With Me.DsAgrifact.Tarif.nTarifColumn
                .AutoIncrement = True
                .AutoIncrementSeed = s.GetMaxValue("Tarif", "nTarif")
                .AutoIncrementStep = 1000
            End With
        End Using
        ApplyStyle(Me.TarifDataGridView, False)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsAgrifact.Tarif, AddressOf MajBoutons)
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        With New FrAssistantTarif()
            AddHandler .FormClosed, AddressOf ChildForm_Closed
            .Show(Me)
        End With
    End Sub

    Private Sub TbSaisieTarifs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSaisieTarifs.Click
        SaisirTarif()
    End Sub
#End Region

#Region "grid"
    Private Sub TarifDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TarifDataGridView.CellDoubleClick
        SaisirTarif()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub

    Private Sub SaisirTarif()
        If Me.TarifBindingSource.Position < 0 Then Exit Sub
        With New FrSaisieTarifs()
            .nTarif = CInt(Me.CurrentTarifRow.nTarif)
            .ColTarifVisible = False
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = DsAgrifact.HasChanges
    End Sub
#End Region

End Class