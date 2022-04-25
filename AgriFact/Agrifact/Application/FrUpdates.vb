Public Class FrUpdates

    Public Enum NiveauUpdate
        Stable = 0
        Beta = 1
        Alpha = 2
    End Enum

    Public dtUpdates As ActiUpdates.dsUpdates.UpdatesDataTable

    Private Const SIMPLE_HEIGHT As Integer = 93
    Private Const FULL_HEIGHT As Integer = 314
    Private tmpFile As String

#Region "Méthodes partagées"
    Public Shared Sub VerifUpdates()
        'Récupérer la liste des mises à jour à l'URL donnée
        Try
            Dim service As New ActiUpdates.Updates
            AddHandler service.GetUpdatesCompleted, AddressOf GetUpdatesCompleted
            service.GetUpdatesAsync(My.Application.Info.ProductName, My.Application.Info.Version.ToString, My.Settings.NiveauUpdate)
        Catch ex As Exception
            'Problème internet ou autre, on s'en va
            LogException(ex)
            Exit Sub
        End Try
    End Sub

    Private Shared Sub GetUpdatesCompleted(ByVal sender As Object, ByVal e As ActiUpdates.GetUpdatesCompletedEventArgs)
        If e.Cancelled Then Exit Sub
        If e.Error IsNot Nothing Then
            LogException(e.Error)
            Exit Sub
        End If
        Dim dtUpdates As ActiUpdates.dsUpdates.UpdatesDataTable = e.Result
        If dtUpdates.Count = 0 Then Exit Sub
        Using fr As New FrUpdates
            fr.dtUpdates = dtUpdates
            If fr.ShowDialog() = Windows.Forms.DialogResult.Abort Then
                End
            End If
        End Using
    End Sub
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.ClientSize = New Size(Me.ClientSize.Width, SIMPLE_HEIGHT)
        Me.GradientPanel2.Height = 45
        Me.BtInstall.Visible = False
        AddHandler Me.TailleFichierLabel1.DataBindings("Text").Format, AddressOf FormatFileSize
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.dtUpdates Is Nothing Then
            Try
                pbLoading.Visible = True
                lbStatus.Text = "Recherche des mises à jour en cours..."
                Application.DoEvents()
                Dim service As New ActiUpdates.Updates
                Me.dtUpdates = service.GetUpdates(My.Application.Info.ProductName, My.Application.Info.Version.ToString, My.Settings.NiveauUpdate)
            Catch ex As Exception
                lbStatus.Text = "Erreur : " & ex.Message
                pbLoading.Image = SystemIcons.Exclamation.ToBitmap
                LogException(ex)
                Exit Sub
            End Try
        End If
        If Me.dtUpdates Is Nothing Then Exit Sub
        If Me.dtUpdates.Count = 0 Then
            lbStatus.Text = "Aucune mise à jour n'est disponible."
            pbLoading.Image = SystemIcons.Information.ToBitmap
            Exit Sub
        End If
        pbLoading.Visible = False
        lbStatus.Text = "Les mises à jour suivantes sont disponibles :"
        Me.UpdatesBindingSource.DataSource = Me.dtUpdates
        Me.UpdatesBindingSource.Position = 0
        Me.ClientSize = New Size(Me.ClientSize.Width, FULL_HEIGHT)
        Me.BtInstall.Visible = True
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtInstall.Click
        If Me.UpdatesBindingSource.Position < 0 Then Exit Sub
        Dim drUpdate As ActiUpdates.dsUpdates.UpdatesRow
        drUpdate = CType(CType(Me.UpdatesBindingSource.Current, DataRowView).Row, ActiUpdates.dsUpdates.UpdatesRow)
        Dim msg As String
        If drUpdate.Niveau > 0 Then
            msg = "Attention ! Cette mise à jour installera une version non finalisée." & vbCrLf & _
                    "Voulez-vous quitter l'application et installer cette mise à jour maintenant ?"
        Else
            msg = "Voulez-vous quitter l'application et installer cette mise à jour maintenant ?"
        End If
        If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Exit Sub
        End If
        Me.pbLoading.Visible = True
        Me.lbStatus.Text = "Téléchargement de la mise à jour..."
        Me.ClientSize = New Size(Me.ClientSize.Width, SIMPLE_HEIGHT)
        Me.BtInstall.Visible = False
        Application.DoEvents()

        Dim urlDownload As String = drUpdate.DownloadPath
        urlDownload &= "&code=" & Actigram.Securite.GetLicence.GetNSerie
        urlDownload &= "&cle=" & Actigram.Securite.GetLicence.GetCle
        Try
            'Créer un fichier temp
            tmpFile = My.Computer.FileSystem.GetTempFileName

            'Télécharger l'installateur
            Dim wc As New Net.WebClient
            AddHandler wc.DownloadFileCompleted, AddressOf DownloadFileCompleted
            wc.DownloadFileAsync(New Uri(urlDownload), tmpFile)
        Catch ex As Exception
            SetError(ex)
        End Try
    End Sub
#End Region

#Region "BindingSource"
    Private Sub UpdatesBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdatesBindingSource.CurrentChanged
        If Me.UpdatesBindingSource.Position < 0 Then Exit Sub
        Dim drUpdate As ActiUpdates.dsUpdates.UpdatesRow
        drUpdate = CType(CType(Me.UpdatesBindingSource.Current, DataRowView).Row, ActiUpdates.dsUpdates.UpdatesRow)
        drUpdate.Description = drUpdate.Description.Replace(vbLf, vbCrLf)
        'Me.UpdatesBindingSource.ResetCurrentItem()
        Select Case drUpdate.Niveau
            Case 0 : Me.NiveauLabel1.Text = ""
            Case 1 : Me.NiveauLabel1.Text = "BETA"
            Case 2 : Me.NiveauLabel1.Text = "ALPHA"
        End Select
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Cancelled Then
            SetError("Mise à jour annulée")
        ElseIf e.Error IsNot Nothing Then
            SetError(e.Error)
        Else
            If Not IO.File.Exists(tmpFile) Then
                SetError("Mise à jour échouée : fichier introuvable.")
                Exit Sub
            End If
            Dim wc As Net.WebClient = CType(sender, Net.WebClient)
            Dim contentDisposition As String = wc.ResponseHeaders.Item("Content-Disposition") 'wc.ResponseHeaders.Item(0)
            contentDisposition = contentDisposition.Replace("inline; filename=", "")
            If Not contentDisposition.EndsWith(".exe") Then contentDisposition &= ".exe"
            Dim fichier As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, contentDisposition)
            IO.File.Copy(tmpFile, fichier, True)
            'Lancer l'installateur
            Process.Start(fichier)
            'Sortir
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Me.Close()
        End If
    End Sub

    Private Sub SetError(ByVal ex As Exception)
        Me.pbLoading.Image = SystemIcons.Exclamation.ToBitmap
        Me.lbStatus.Text = "Erreur : " & ex.Message
        LogException(ex)
    End Sub

    Private Sub SetError(ByVal msg As String)
        Me.pbLoading.Image = SystemIcons.Exclamation.ToBitmap
        Me.lbStatus.Text = msg
    End Sub
#End Region

End Class