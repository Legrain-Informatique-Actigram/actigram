Public Class FrMain

    'DONE Prendre les fichiers d'un dossier et les zipper 1 par 1 en conservant le nom
    'DONE Mettre un mot de passe sur le zip composé du n° de dossier et d'une clé privée
    'TODO Execution en ligne de commande

    Private _dir As String
    Public Property Dir() As String
        Get
            Return _dir
        End Get
        Set(ByVal value As String)
            _dir = value
        End Set
    End Property

    Private Sub FrMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Dir IsNot Nothing Then Me.TxDir.Text = Me.Dir
        Me.TxCle.Text = Zipper.GetCle
    End Sub

    Private Sub BtAideCle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAideCle.Click
        MsgBox("Le mot de passe des fichiers Zip est composé du code dossier et de cette clé séparés par un tiret : DOSSIER-CLE")
    End Sub

    Private Sub BtBrowseDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowseDir.Click
        Using dlg As New FolderBrowserDialog
            dlg.Description = "Sélectionnez le dossier à traiter"
            If IO.Directory.Exists(Me.TxDir.Text) Then
                dlg.SelectedPath = Me.TxDir.Text
            End If
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.TxDir.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub BtZipDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtZipDir.Click
        Me.TxDir.Text = Me.TxDir.Text.Trim
        If Not IO.Directory.Exists(Me.TxDir.Text) Then
            MsgBox("Dossier incorrect.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim res As Integer = Zipper.ZipDirContent(Me.TxDir.Text)
        MsgBox(res & " fichiers traités", MsgBoxStyle.Information)
    End Sub

    Private Sub BtZipFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtZipFile.Click
        Using dlg As New OpenFileDialog
            dlg.Title = "Sélectionnez le fichier à zipper"
            dlg.Multiselect = False
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Zipper.ZipFile(dlg.FileName) = 1 Then
                    MsgBox("Traitement OK", MsgBoxStyle.Information)
                End If
            End If
        End Using
    End Sub
End Class
