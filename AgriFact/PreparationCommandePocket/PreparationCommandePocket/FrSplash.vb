Public Class FrSplash

    Private loadok As Boolean = False

    Private Sub FrSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LbTitle.Text = My.Application.Title
        Me.LbDescription.Text = My.Application.Description
        Me.LbCopyright.Text = My.Application.Company & " " & My.Application.Copyright & " "
        Me.LbVersion.Text = String.Format("Client V{0}", My.Application.Version.ToString())
        Me.LbServeur.Text = ""
        Me.TxLog.Text = ""
        Me.TxLog.Visible = False
        Me.Show()
        Application.DoEvents()
    End Sub

    Private Sub FrSplash_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If loadok Then Exit Sub
        Me.TxLog.Text = "Chargement de l'URL..." & vbCrLf
        Application.DoEvents()
        Dim url As String = My.Resources.ServiceURL
        If IO.File.Exists(My.Application.StartupPath & "\url.txt") Then
            Using sr As New IO.StreamReader(My.Application.StartupPath & "\url.txt")
                url = sr.ReadToEnd.Trim
            End Using
        End If
        My.WebServices.ServiceAgrifact.Url = url
        Me.TxLog.Text = String.Format("URL : {0}" & vbCrLf, My.WebServices.ServiceAgrifact.Url)
        RechercheServeur()
        loadok = True
    End Sub

    Private Sub RechercheServeur()
        Me.LbServeur.ForeColor = SystemColors.ControlText
        Me.LbServeur.Text = "Connexion en cours..."
        Me.TxLog.Text = String.Format("URL : {0}" & vbCrLf, My.WebServices.ServiceAgrifact.Url)
        Me.TxLog.Text &= "Recherche du serveur..." & vbCrLf
        Application.DoEvents()
        Me.BtAction.Enabled = False
        Me.BtQuitter.Enabled = False
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim version As String = My.WebServices.ServiceAgrifact.Version
            Me.TxLog.Text &= "Serveur OK"
            Me.LbServeur.Text = String.Format("Serveur V{0}", version)
            Me.BtAction.Text = "Commandes"
            Me.BtAction.Tag = "GO"
        Catch ex As Net.WebException
            Me.LbServeur.ForeColor = Color.Red
            Me.LbServeur.Text = "Serveur KO"
            Me.TxLog.Text &= String.Format("Erreur : {0}", ex.Message)
            Me.BtAction.Text = "Réessayer"
            Me.BtAction.Tag = "RETRY"
        Finally
            Me.BtAction.Enabled = True
            Me.BtQuitter.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAction.Click
        If CStr(Me.BtAction.Tag) = "RETRY" Then
            RechercheServeur()
        ElseIf CStr(Me.BtAction.Tag) = "GO" Then
            Call New FrLectureCodeBarre().Show()
        End If
    End Sub

    Private Sub BtQuitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtQuitter.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub LnkShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkShowDetails.Click
        Me.TxLog.Visible = Not Me.TxLog.Visible
        If Me.TxLog.Visible Then
            LnkShowDetails.Text = "Masquer les détails"
        Else
            LnkShowDetails.Text = "Afficher les détails"
        End If
    End Sub

    Private Sub BtDebug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDebug.Click
        Call New FrDebugCodeBarre().Show()
    End Sub
End Class