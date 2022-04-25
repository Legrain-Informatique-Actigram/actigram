Public Class Main

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChargerParametres()
        ModeConfig()
    End Sub

    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.bgWorker.IsBusy Then
            If MsgBox("Un import est en cours, êtes-vous sûr de vouloir quitter ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
        Else
            Me.bgWorker.CancelAsync()
        End If
    End Sub

#Region "Background Worker"
    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Dim filename As String = CStr(e.Argument)
        Try
            Call (New Importateur).Importer(filename, sender)
        Catch ex As UserCancelledException
            e.Cancel = True
        End Try
    End Sub

    Private Sub bgWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        pgBar.Value = e.ProgressPercentage
        If e.UserState IsNot Nothing AndAlso TypeOf e.UserState Is String Then
            lbStatus.Text = CStr(e.UserState)
            Application.DoEvents()
        End If
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If e.Cancelled Then
            ModeConfig()
        ElseIf e.Error IsNot Nothing Then
            lbStatus.Text = "Une erreur est survenue : " & e.Error.Message
            MsgBox(lbStatus.Text, MsgBoxStyle.Exclamation)
            ModeConfig()
        Else
            lbStatus.Text = "Import terminé avec succès"
            ModeFin()
        End If
    End Sub
#End Region

#Region "Activations"
    Private Sub ModeConfig()
        SplitContainer1.Panel1Collapsed = False
        SplitContainer1.Panel2Collapsed = True
        Panel1.Enabled = True
        BtOK.Enabled = True
        BtClose.Enabled = True
    End Sub

    Private Sub ModeRun()
        SplitContainer1.Panel1Collapsed = True
        SplitContainer1.Panel2Collapsed = False
        Panel1.Enabled = False
    End Sub

    Private Sub ModeFin()
        SplitContainer1.Panel1Collapsed = True
        SplitContainer1.Panel2Collapsed = False
        Panel1.Enabled = True
        BtOK.Enabled = False
        BtClose.Enabled = True
    End Sub
#End Region


    Private Function Verif() As Boolean
        If Not IO.File.Exists(Me.txChemin.Text) Then
            MsgBox("Fichier introuvable.", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Not SqlProxy.TestDefaultConnection(True) Then
            Return False
        End If
        Return True
    End Function

    Private Sub ChargerParametres()
        Dim dossiers As List(Of Dossier) = Dossier.ChargerDossiersAgrifact
        If dossiers.Count > 0 Then
            Dim trouve As Boolean = False
            If My.Settings.LastDossier.Length > 0 Then
                For Each d As Dossier In dossiers
                    If d.Nom = My.Settings.LastDossier Then
                        SqlProxy.SetDefaultConnection(d.ConnString)
                        trouve = True
                        Exit For
                    End If
                Next
            End If
            If Not trouve Then
                SqlProxy.SetDefaultConnection(dossiers(0).ConnString)
                My.Settings.LastDossier = dossiers(0).Nom
            End If
        End If
    End Sub

#Region "Boutons"
    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Not Verif() Then Exit Sub
        ModeRun()
        bgWorker.RunWorkerAsync(txChemin.Text)
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        Using dlg As New OpenFileDialog
            With dlg
                .Filter = "Fichiers texte (*.csv;*.txt)|*.csv;*.txt"
                If My.Settings.OpenDir.Length > 0 Then .InitialDirectory = My.Settings.OpenDir
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.txChemin.Text = .FileName
                    My.Settings.OpenDir = IO.Path.GetDirectoryName(.FileName)
                End If
            End With
        End Using
    End Sub

    Private Sub lnkSettings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSettings.LinkClicked
        Call (New FrParametres).ShowDialog()
    End Sub
#End Region


End Class
