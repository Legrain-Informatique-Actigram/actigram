Namespace Admin
    Public Class SaisieOption

        Private modif As Boolean
        Public Event EnregistrableChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#Region "Propriétés"
        Public ReadOnly Property Enregistrable() As Boolean
            Get
                Return modif
            End Get
        End Property
#End Region

#Region "Form Events"
        Private Sub Me_EnregistrableChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnregistrableChanged
            Me.EnregistrerToolStripButton.Enabled = Me.Enregistrable
        End Sub

        Private Sub Me_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
            Me.LbTitre.Text = Me.Text
        End Sub

        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            With cbNiveauxUpdate.Items
                .Clear()
                .Add(New ListboxItem("Version stable (recommandé)", FrUpdates.NiveauUpdate.Stable))
                .Add(New ListboxItem("Version en test (beta)", FrUpdates.NiveauUpdate.Beta))
                .Add(New ListboxItem("Version en développement (alpha)", FrUpdates.NiveauUpdate.Alpha))
            End With
            cbNiveauxUpdate.SelectedIndex = My.Settings.NiveauUpdate

            If My.Dossier.Principal IsNot Nothing Then
                Select Case My.Dossier.Principal.IncrementationPiece
                    Case 0 : Me.rbtGlobal.Checked = True
                    Case 1 : Me.rbtJournal.Checked = True
                    Case Else : Me.rbtGlobal.Checked = True
                End Select
                Me.chkExportComplet.Checked = My.Dossier.Principal.ExportComplet
            End If

            If Not FtpCogedis.ParamsFtp.IsAvailable Then
                Me.chkAutoDownloadEdi.Checked = False
                Me.chkAutoDownloadEdi.Enabled = False
                Me.chkAutoImportEDI.Checked = False
                Me.chkAutoImportEDI.Enabled = False
            End If
        End Sub

        Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
            ChargerDonnees()
            AddHandler My.Settings.PropertyChanged, AddressOf MySettings_PropertyChanged
        End Sub

        Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Select Case e.CloseReason
                Case CloseReason.UserClosing, CloseReason.MdiFormClosing, CloseReason.FormOwnerClosing
                    If DemanderEnregistrement() = Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                    End If
                Case Else
            End Select
        End Sub
#End Region

#Region "Données"
        Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
            modif = True
            RaiseEvent EnregistrableChanged(Me, New EventArgs)
        End Sub

        Private Sub ChargerDonnees()
            modif = False
            RaiseEvent EnregistrableChanged(Me, New EventArgs)
        End Sub

        Private Function DemanderEnregistrement() As DialogResult
            'Demander l'enregistrement des modifications
            If Me.Enregistrable Then
                Select Case MsgBox(My.Resources.Strings.EnregistrerLesModifications, MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        EnregistrerDonnees()
                        Return Windows.Forms.DialogResult.Yes
                    Case MsgBoxResult.Cancel
                        Return Windows.Forms.DialogResult.Cancel
                    Case Else
                        My.Settings.Reload()
                        Return Windows.Forms.DialogResult.No
                End Select
            End If
        End Function

        Private Sub EnregistrerDonnees()
            If modif Then
                My.Settings.Save()
                Using dtDossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                    Dim nIncrementation As Short = 0
                    If rbtJournal.Checked Then
                        nIncrementation = 1
                    End If
                    dtDossier.UpdateIncrementationPiece(nIncrementation, My.User.Name)
                    dtDossier.UpdateExportComplet(Me.chkExportComplet.Checked, My.User.Name)
                    My.Dossier.Principal.IncrementationPiece = nIncrementation
                    My.Dossier.Principal.ExportComplet = Me.chkExportComplet.Checked
                End Using
            End If
            modif = False
            RaiseEvent EnregistrableChanged(Me, New EventArgs)
        End Sub
#End Region

#Region "Toolbar"
        Private Sub EnregistrerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripButton.Click
            EnregistrerDonnees()
        End Sub

        Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
            Me.Close()
        End Sub
#End Region

#Region " Gestion des boutons "
        Private Sub btBrowseEtats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowseEtats.Click
            With folderDlg
                .SelectedPath = My.Settings.AbsoluteRepEtats
                .Description = "Indiquez le répertoire contenant les rapports de l'application"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Settings.AbsoluteRepEtats = .SelectedPath
                    Me.RepEtatsTextBox.DataBindings("Text").ReadValue()
                End If
            End With
        End Sub

        Private Sub btBrowseVNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowseVNC.Click
            With folderDlg
                .SelectedPath = My.Settings.AbsoluteCheminVNC
                .Description = "Indiquez le répertoire d'installation d'UltraVNC"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Settings.AbsoluteCheminVNC = .SelectedPath
                    Me.CheminVNCTextBox.DataBindings("Text").ReadValue()
                End If
            End With
        End Sub

        Private Sub RepEtatsTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RepEtatsTextBox.Validating
            Dim rep As String = RepEtatsTextBox.Text
            If Not IO.Path.IsPathRooted(rep) Then
                rep = IO.Path.Combine(My.Application.Info.DirectoryPath, rep)
            End If
            If Not IO.Directory.Exists(rep) Then
                ErrorProvider.SetError(RepEtatsTextBox, "Le répertoire est introuvable.")
                e.Cancel = True
            Else
                ErrorProvider.SetError(RepEtatsTextBox, "")
            End If
        End Sub
#End Region

        Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rbtGlobal.CheckedChanged, rbtJournal.CheckedChanged
            If My.Dossier.Principal Is Nothing Then Exit Sub
            If rbtGlobal.Checked AndAlso My.Dossier.Principal.IncrementationPiece <> 0 Then
                modif = True
                RaiseEvent EnregistrableChanged(Me, New EventArgs)
            ElseIf rbtJournal.Checked AndAlso My.Dossier.Principal.IncrementationPiece <> 1 Then
                modif = True
                RaiseEvent EnregistrableChanged(Me, New EventArgs)
            End If
        End Sub

        Private Sub chkExportComplet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkExportComplet.CheckedChanged
            If My.Dossier.Principal Is Nothing Then Exit Sub
            If chkExportComplet.Checked AndAlso Not My.Dossier.Principal.ExportComplet Then
                modif = True
                RaiseEvent EnregistrableChanged(Me, New EventArgs)
            ElseIf Not chkExportComplet.Checked AndAlso My.Dossier.Principal.ExportComplet Then
                modif = True
                RaiseEvent EnregistrableChanged(Me, New EventArgs)
            End If
        End Sub

        Private Sub cbNiveauxUpdate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNiveauxUpdate.SelectedIndexChanged
            If cbNiveauxUpdate.SelectedIndex < 0 Then Exit Sub
            My.Settings.NiveauUpdate = CInt(CType(cbNiveauxUpdate.SelectedItem, ListboxItem).Value)
        End Sub

        Private Sub lnkUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUpdate.LinkClicked
            Using fr As New FrUpdates
                If fr.ShowDialog = Windows.Forms.DialogResult.Abort Then
                    Application.Exit()
                End If
            End Using
        End Sub

    End Class
End Namespace