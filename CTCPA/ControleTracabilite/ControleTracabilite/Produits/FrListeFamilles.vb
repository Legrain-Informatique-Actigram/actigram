Public Class FrListeFamilles

#Region "Props"
    Private ReadOnly Property CurrentFamilleRow() As AgrifactTracaDataSet.FamilleRow
        Get
            If Me.FamilleBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.FamilleBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.FamilleRow)
            End If
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.FamilleDataGridView.UseWaitCursor = True
            Application.DoEvents()
            Dim curId As Decimal = -1
            If Me.FamilleBindingSource.Current IsNot Nothing Then
                curId = Me.CurrentFamilleRow.nFamille
            End If
            Me.FamilleBindingSource.SuspendBinding()
            With Me.AgrifactTracaDataSet
                .EnforceConstraints = False
                Me.FamilleTableAdapter.Fill(.Famille)
                .EnforceConstraints = True
            End With
            Me.FamilleBindingSource.ResumeBinding()
            If curId > -1 Then
                Me.FamilleBindingSource.Position = Me.FamilleBindingSource.Find("nFamille", curId)
            End If
            MajBoutons()
        Finally
            Cursor.Current = Cursors.Default
            Me.FamilleDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.FamilleBindingSource.EndEdit()
        If Me.AgrifactTracaDataSet.HasChanges Then
            Try
                Me.FamilleTableAdapter.Update(Me.AgrifactTracaDataSet.Famille)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
                Me.AgrifactTracaDataSet.RejectChanges()                
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.FamilleBindingSource.EndEdit()
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
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ConfigDataTableEvents(Me.AgrifactTracaDataSet.Famille, AddressOf MajBoutons)
        ApplyStyle(Me.FamilleDataGridView, False)
        ChargerDonnees()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = AgrifactTracaDataSet.HasChanges
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub
#End Region

#Region "Grid"
    Private Sub FamilleDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles FamilleDataGridView.CellDoubleClick
        If Me.FamilleBindingSource.Current Is Nothing Then Exit Sub
        If e.ColumnIndex = DescriptionDataGridViewTextBoxColumn.Index Then
            FrModifTxt.ZoomTextBoxCell(Cast(Of DataGridViewTextBoxCell)(FamilleDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)))
        Else
            With New FrListeProduits(Me.CurrentFamilleRow.nFamille)
                .Owner = Me
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If

    End Sub
#End Region

End Class