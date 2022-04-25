Public Class FrUpdate

    Public Enum NiveauUpdate
        Stable = 0
        Beta = 1
        Alpha = 2
    End Enum

    Private ReadOnly Property CurrentUpdateRow() As dsActiUpdates.UpdatesRow
        Get
            If Me.UpdatesBindingSource.Position < 0 Then Return Nothing
            If Me.UpdatesBindingSource.Current Is Nothing Then Return Nothing
            Return CType(CType(Me.UpdatesBindingSource.Current, DataRowView).Row, dsActiUpdates.UpdatesRow)
        End Get
    End Property

    Private _id As Integer
    Public Property IdUpdate() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
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

    Private mustUploadFile As Boolean = False

    Private Sub ChargerDonnees()
        Me.ApplicationsTableAdapter.Fill(Me.DsActiUpdates.Applications)
        If Me.IdUpdate = 0 Then
            Me.UpdatesBindingSource.AddNew()
            With Me.CurrentUpdateRow
                .NomAppli = Me.AppName
                .Niveau = NiveauUpdate.Alpha
            End With
            Me.UpdatesBindingSource.ResetCurrentItem()
        Else
            Me.UpdatesTableAdapter.FillById(Me.DsActiUpdates.Updates, Me.IdUpdate)
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        Me.Validate()
        Me.UpdatesBindingSource.EndEdit()
        If Me.CurrentUpdateRow.Niveau = 0 And Me.CurrentUpdateRow.Actif Then
            If MsgBox("Attention ! Après enregistrement, cette mise à jour sera mise à disposition de tous les clients." & vbCrLf & _
            "Voulez-vous continuer ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Return False
            End If
        End If
        Me.UpdatesTableAdapter.Update(Me.DsActiUpdates.Updates)
        Return UploadFile()
    End Function

    Private Function UploadFile() As Boolean
        If Not mustUploadFile Then Return True
        Dim fichierSrc As String = Me.CurrentUpdateRow.DownloadPath
        Dim dirDest As String = IO.Path.Combine(My.Settings.RepFiles, Me.CurrentUpdateRow.NomAppli)
        If Not IO.Directory.Exists(dirDest) Then IO.Directory.CreateDirectory(dirDest)
        dirDest = IO.Path.Combine(dirDest, Me.CurrentUpdateRow.IdUpdate.ToString)
        If Not IO.Directory.Exists(dirDest) Then IO.Directory.CreateDirectory(dirDest)
        dirDest = IO.Path.Combine(dirDest, IO.Path.GetFileName(fichierSrc))
        If IO.File.Exists(dirDest) Then
            If MsgBox("Le fichier existe déjà sur le serveur, voulez-vous le remplacer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return False
        End If
        IO.File.Copy(fichierSrc, dirDest, True)
        dirDest = dirDest.Replace(My.Settings.RepFiles, "\files")
        dirDest = dirDest.Replace("\", "/")
        Me.CurrentUpdateRow.DownloadPath = dirDest
        Me.UpdatesTableAdapter.Update(Me.DsActiUpdates.Updates)
        mustUploadFile = False
        Return True
    End Function

    Private Sub FrUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        FillCb(GetType(NiveauUpdate), Me.NiveauComboBox, Nothing, True)
        AddHandler Me.TailleFichierLabel1.DataBindings("Text").Format, AddressOf FormatFileSize
        ChargerDonnees()
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Not Enregistrer() Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowse.Click
        Using fr As New OpenFileDialog
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                TraiterFichier(fr.FileName)
            End If
        End Using
    End Sub

    Private Sub TraiterFichier(ByVal fichier As String)
        If Not IO.File.Exists(fichier) Then Exit Sub
        Dim fi As New IO.FileInfo(fichier)
        Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(fichier)
        With Me.CurrentUpdateRow
            .TailleFichier = CInt(fi.Length)
            .DateFichier = fi.LastWriteTime
            .DownloadPath = fichier
            .Version = fvi.FileVersion.Trim
            If .IsDescriptionNull OrElse .Description.Length = 0 Then
                .Description = String.Format("{0}" & vbCrLf & "(c) {1}" & vbCrLf & "{2}", fvi.FileDescription.Trim, fvi.LegalCopyright.Trim, New String("-"c, 60))
            End If
            mustUploadFile = True
        End With
        UpdatesBindingSource.ResetCurrentItem()
    End Sub

    Private Sub FormatFileSize(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType Is GetType(String) And TypeOf e.Value Is Integer Then
            e.Value = DecimalUtils.FormatFileSize(CInt(e.Value))
        End If
    End Sub

End Class