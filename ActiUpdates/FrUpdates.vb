Public Class FrUpdates


    Private ReadOnly Property CurrentUpdateRow() As dsActiUpdates.UpdatesRow
        Get
            If Me.UpdatesBindingSource.Position < 0 Then Return Nothing
            If Me.UpdatesBindingSource.Current Is Nothing Then Return Nothing
            Return CType(CType(Me.UpdatesBindingSource.Current, DataRowView).Row, dsActiUpdates.UpdatesRow)
        End Get
    End Property

    Private _appName As String
    Public Property AppName() As String
        Get
            Return _appName
        End Get
        Set(ByVal value As String)
            _appName = value
        End Set
    End Property

    Private Sub ChargerDonnees()
        If Me.AppName Is Nothing Then Exit Sub
        Me.UpdatesTableAdapter.FillByApp(Me.DsActiUpdates.Updates, Me.AppName)
    End Sub

    Private Sub FrUpdates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.UpdatesDataGridView)
        Me.UpdatesDataGridView.RowHeadersVisible = True
        Me.UpdatesDataGridView.AllowUserToResizeRows = True
        ChargerDonnees()
    End Sub

    Private Sub UpdatesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.UpdatesBindingSource.EndEdit()
        Me.UpdatesTableAdapter.Update(Me.DsActiUpdates.Updates)
    End Sub

    Private Sub UpdatesBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdatesBindingSource.PositionChanged
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbModif.Enabled = Me.UpdatesBindingSource.Position >= 0
        Me.TbSuppr.Enabled = Me.UpdatesBindingSource.Position >= 0
        Me.TbTest.Enabled = Me.UpdatesBindingSource.Position >= 0
    End Sub

    Private Sub TbModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbModif.Click
        Using fr As New FrUpdate
            fr.AppName = Me.AppName
            fr.IdUpdate = Me.CurrentUpdateRow.IdUpdate
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
        End Using
    End Sub

    Private Sub TbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbAdd.Click
        Using fr As New FrUpdate
            fr.AppName = Me.AppName
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
        End Using
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        If Me.UpdatesBindingSource.Position < 0 Then Exit Sub
        If MsgBox("Voulez-vous supprimer cette mise à jour ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If MsgBox("Voulez-vous aussi supprimer les fichiers de mise à jour du site ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim dirUpdate As String = IO.Path.Combine(My.Settings.RepFiles, Me.CurrentUpdateRow.NomAppli)
            dirUpdate = IO.Path.Combine(dirUpdate, Me.CurrentUpdateRow.IdUpdate.ToString)
            If IO.Directory.Exists(dirUpdate) Then
                My.Computer.FileSystem.DeleteDirectory(dirUpdate, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        End If
        Me.UpdatesTableAdapter.Delete(Me.CurrentUpdateRow.IdUpdate)
        ChargerDonnees()
    End Sub

    Private Sub TbTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbTest.Click
        If Not Me.CurrentUpdateRow.Actif Then
            If MsgBox("Cette mise à jour n'est pas activée, voulez-vous l'installer quand-même ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Dim fichierDest As String
        Try
            Dim urlUpdate As String = String.Format("{0}/GetUpdate.aspx?id={1}", My.Settings.URL_Update, Me.CurrentUpdateRow.IdUpdate)
            fichierDest = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, String.Format("setup{0}.{1}.exe", Me.CurrentUpdateRow.NomAppli, Me.CurrentUpdateRow.Version))
            My.Computer.Network.DownloadFile(urlUpdate, fichierDest, "", "", True, 30, True)
        Catch ex As Exception
            MsgBox("Erreur : " & ex.Message)
            Exit Sub
        End Try
        If MsgBox("Téléchargement OK, voulez-vous éxecuter la mise à jour maintenant ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Process.Start(fichierDest)
    End Sub

    Private Sub UpdatesDataGridView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UpdatesDataGridView.MouseDoubleClick
        TbModif.PerformClick()
    End Sub

    Private Sub UpdatesDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles UpdatesDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In Me.UpdatesDataGridView.Rows
                If r.DataBoundItem Is Nothing Then Continue For
                Dim niveau As FrUpdate.NiveauUpdate = CType(CType(r.DataBoundItem, DataRowView)("Niveau"), FrUpdate.NiveauUpdate)
                r.Cells("Niveau").Value = niveau.ToString
                Dim l As Integer = CInt(CType(r.DataBoundItem, DataRowView)("TailleFichier"))
                r.Cells("TailleFichier").Value = FormatFileSize(l)
            Next
        End If
    End Sub
End Class