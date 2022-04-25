Public Class FrBDDBaremes

#Region "Form"
    Private Sub FrBDDBaremes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        'Affichage du chemin vers la BDD Baremes.mdb défini dans les paramètres de l'application
        If Not (String.IsNullOrEmpty(My.Settings.BaremesConnectionString)) Then
            Me.CheminBDDBaremesTextBox.Text = GetDataSource(My.Settings.BaremesConnectionString)
        End If
    End Sub

    Private Sub FrBDDBaremes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim connString As String = String.Empty

        If Not (String.IsNullOrEmpty(Me.CheminBDDBaremesTextBox.Text)) Then
            connString = GetConnStringAccess(Me.CheminBDDBaremesTextBox.Text)

            'Test de la chaîne de connexion
            If Not (ConnectionEstValide(connString)) Then
                If (MsgBox("La base de données paramétrée n'est pas valide. " & Microsoft.VisualBasic.vbCrLf & "Certaines fonctions de l'application ne fonctionneront pas." & Microsoft.VisualBasic.vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub OuvrirBoiteDialogueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirBoiteDialogueButton.Click
        With OpenFileDialog1
            .DefaultExt = "mdb"
            .Filter = "Base de données Access (*.mdb)|*.mdb"
            .FileName = ""
            .Title = "Sélectionner la base de données des barèmes"

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.CheminBDDBaremesTextBox.Text = .FileName
            End If
        End With
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim connString As String = String.Empty

        If Not (String.IsNullOrEmpty(Me.CheminBDDBaremesTextBox.Text)) Then
            connString = GetConnStringAccess(Me.CheminBDDBaremesTextBox.Text)

            'Test de la chaîne de connexion
            If (ConnectionEstValide(connString)) Then
                'Enregistrement de la chaîne de connexion dans les paramètres de l'application
                My.Settings.SetUserOverride("BaremesConnectionString", connString)
                My.Settings.Save()

                Me.Close()
            End If
        End If
    End Sub
#End Region

End Class