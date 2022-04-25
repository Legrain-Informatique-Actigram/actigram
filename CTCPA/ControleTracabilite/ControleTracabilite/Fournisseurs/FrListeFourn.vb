Namespace Fournisseurs
    Public Class FrListeFourn

#Region "Props"
        Private ReadOnly Property CurrentEntrRow() As AgrifactTracaDataSet.EntrepriseRow
            Get
                If Me.FournBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.FournBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.EntrepriseRow)
                End If
            End Get
        End Property
#End Region

#Region "Donnnées"
        Private Sub ChargerDonnees()
            Try
                Cursor.Current = Cursors.WaitCursor
                Me.FournDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Dim curId As Decimal = -1
                If Me.FournBindingSource.Current IsNot Nothing Then
                    curId = Me.CurrentEntrRow.nEntreprise
                End If
                Me.FournBindingSource.SuspendBinding()
                With Me.AgrifactTracaDataSet
                    .EnforceConstraints = False
                    Me.EntrepriseTableAdapter.FillFournisseurs(.Entreprise, BtFiltrer.Checked)
                    .EnforceConstraints = True
                End With
                Me.FournBindingSource.ResumeBinding()
                If curId > -1 Then
                    Me.FournBindingSource.Position = Me.FournBindingSource.Find("nEntreprise", curId)
                End If
                MajBoutons()
            Finally
                Cursor.Current = Cursors.Default
                Me.FournDataGridView.UseWaitCursor = False
            End Try
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.FournBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Try
                    Me.EntrepriseTableAdapter.Update(Me.AgrifactTracaDataSet.Entreprise)
                Catch ex As SqlClient.SqlException
                    SqlProxy.GererSqlException(ex)
                    Me.AgrifactTracaDataSet.RejectChanges()
                End Try
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.FournBindingSource.EndEdit()
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
            ConfigDataTableEvents(AgrifactTracaDataSet.Entreprise, AddressOf MajBoutons)
            ApplyStyle(Me.FournDataGridView)
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
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
            Me.Close()
        End Sub

        Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
            Enregistrer()
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.FournBindingSource.Current Is Nothing Then Exit Sub
            Try
                Me.FournBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            With New FrSaisieFourn()
                .Owner = Me
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub

        Private Sub BtFiltrer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFiltrer.CheckedChanged
            If DemanderEnregistrement() Then
                ChargerDonnees()
            End If
        End Sub

        Private Sub TbBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbBR.Click
            If Me.FournBindingSource.Position < 0 Then Exit Sub
            Using fr As New Receptions.FrListeBR(CInt(Me.CurrentEntrRow.nEntreprise))
                fr.Owner = Me
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog()
            End Using
        End Sub

        Private Sub TbNewBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewBR.Click
            If Me.FournBindingSource.Position < 0 Then Exit Sub
            Using fr As New Receptions.FrSaisieBR()
                fr.Owner = Me
                fr.NFournisseur = CInt(Me.CurrentEntrRow.nEntreprise)
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog()
            End Using
        End Sub
#End Region

#Region "Grid"
        Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournDataGridView.DoubleClick
            If Me.FournBindingSource.Current Is Nothing Then Exit Sub
            With New FrSaisieFourn(CInt(Me.CurrentEntrRow.nEntreprise))
                .Owner = Me
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub
#End Region

        Private Sub FournBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournBindingSource.PositionChanged
            Me.TbBR.Enabled = Me.FournBindingSource.Position >= 0
        End Sub
    End Class
End Namespace