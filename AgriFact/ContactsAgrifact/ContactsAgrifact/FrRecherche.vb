Public Class FrRecherche

    'DONE Fiche intervenant avec la liste des interventions
    'DONE Liste des interventions : ne pas revenir en tête de liste à chaque fois qu'on sort du détail de l'inter
    'TODO Gérer l'attachement de fichiers à un client

#Region " Gestion des dossiers "
    Private Sub ChargerDossiers()
        My.Settings.NomDossier = Nothing
        Dim trouve As Boolean = False
        For Each dos As Dossier In My.Settings.Dossiers
            Dim mn As New ToolStripMenuItem(dos.Nom, Nothing, AddressOf ChangeDossier)
            mn.Tag = dos
            If dos.ConnString = My.Settings.ConnAgrifact Then
                trouve = True
                mn.Checked = True
                Me.Text = String.Format("Recherche sur le dossier {0}", dos.Nom)
                My.Settings.NomDossier = dos.Nom
            End If
            DossierToolStripMenuItem.DropDownItems.Insert(0, mn)
        Next
        If Not trouve Then
            Dim sb As New SqlClient.SqlConnectionStringBuilder(My.Settings.ConnAgrifact)
            Me.Text = String.Format("Recherche sur la base {0}\{1}", sb.DataSource, sb.InitialCatalog)
        End If
        ResetAdapters()
    End Sub

    Private Sub ChangeDossier(ByVal sender As Object, ByVal e As EventArgs)
        My.Settings.NomDossier = Nothing
        Dim mn As ToolStripMenuItem = Cast(Of ToolStripMenuItem)(sender)
        If mn.Tag Is Nothing OrElse Not TypeOf mn.Tag Is Dossier Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If SqlProxy.TestConnection(Cast(Of Dossier)(mn.Tag).ConnString) Then
            SqlProxy.SetDefaultConnection(Cast(Of Dossier)(mn.Tag).ConnString)
            For Each i As ToolStripMenuItem In DossierToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
            mn.Checked = True
            Me.Text = String.Format("Recherche sur le dossier {0}", mn.Text)
            My.Settings.NomDossier = mn.Text
            ResetAdapters()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Function TesterConnexion() As Boolean
        If Not SqlProxy.TestDefaultConnection(True) Then
            Return False
        End If
        Dim strVersionBase As String = Nothing
        Try
            Using dta As New DsAgrifactTableAdapters.ParamApplicationTableAdapter
                strVersionBase = dta.GetVersionBase
            End Using
        Catch
        End Try
        If strVersionBase Is Nothing Then strVersionBase = "0.0"
        Dim versionBase As New Version(strVersionBase)
        Dim minVersionBase As New Version(My.Settings.MinVersionBase)
        Dim res As Boolean
        If versionBase.CompareTo(minVersionBase) >= 0 Then
            res = True
        Else
            res = False
            Dim databaseUpdate As String = Dossier.Trouver("DatabaseUpdate.exe")
            If Not databaseUpdate Is Nothing Then
                If IO.File.Exists(databaseUpdate) Then
                    Dim fv As FileVersionInfo = FileVersionInfo.GetVersionInfo(databaseUpdate)
                    If minVersionBase.CompareTo(New Version(fv.FileVersion)) < 0 _
                    AndAlso MsgBox(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}." & vbCrLf & "Voulez-vous effectuer la mise à jour maintenant ?", My.Settings.MinVersionBase), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim pi As New ProcessStartInfo
                        With pi
                            .FileName = databaseUpdate
                            .Arguments = String.Format("-dossier=""{0}"" -auto", My.Settings.NomDossier)
                            .UseShellExecute = True
                        End With
                        Dim p As Process = Process.Start(pi)
                        p.WaitForExit()
                        'Refaire la vérif
                        res = TesterConnexion()
                    End If
                End If
            End If
        End If
        If Not res Then MsgBox(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}.", My.Settings.MinVersionBase))
        Return res
    End Function
#End Region

    Private Sub ResetAdapters()
        If Not TesterConnexion() Then
            Me.RechercheTableAdapter = Nothing
            Me.BtGo.Enabled = False
            Me.FicheUtilisateurToolStripMenuItem.Enabled = False
            Me.InterventionClientToolStripMenuItem.Enabled = False
            Me.RechercherÉvénementToolStripMenuItem.Enabled = False
        Else
            Me.RechercheTableAdapter = New DsAgrifactTableAdapters.RechercheTableAdapter
            Me.BtGo.Enabled = True
            Me.FicheUtilisateurToolStripMenuItem.Enabled = True
            Me.InterventionClientToolStripMenuItem.Enabled = True
            Me.RechercherÉvénementToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private bmpUser As Bitmap
    Private bmpUserAccounts As Bitmap
    Private Sub FrRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bmpUser = My.Resources.user
        bmpUser.MakeTransparent(Color.Magenta)
        bmpUserAccounts = My.Resources.userAccounts
        bmpUserAccounts.MakeTransparent(Color.Magenta)
        lbStatus.Text = ""
        ApplyStyle(Me.dgResults)
        ChargerDossiers()
        CType(Me.BtGo.Image, Bitmap).MakeTransparent(Color.Magenta)
        Me.TxRecherche.Control.Select()
        Me.TxRecherche.SelectAll()
    End Sub

    Private Sub FrRecherche_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Hide()
    End Sub

    Private Sub FrRecherche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            For Each f As Form In childrenToKill
                f.Close()
            Next
            childrenToKill.Clear()
            Me.Hide()
            Me.DsAgrifact.Recherche.Clear()
            e.Cancel = True
            GC.WaitForPendingFinalizers()
            GC.Collect() 'Pour essayer de récupérer la mémoire en mode sommeil.
            SetProcessWorkingSetSize() 'Et encore.
        End If
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Friend Sub SetProcessWorkingSetSize()
        Try
            Dim Mem As Process = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub RechercherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherToolStripMenuItem.Click
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
        If Not Me.ShowInTaskbar Then Me.ShowInTaskbar = True
        Me.TxRecherche.Control.Select()
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub notIcon_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notIcon.DoubleClick
        RechercherToolStripMenuItem.PerformClick()
    End Sub

    Private Sub TxRecherche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRecherche.KeyPress
        If e.KeyChar = vbCr Then
            BtGo.PerformButtonClick()
            e.Handled = True
        End If
    End Sub

    Private Sub BtGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGo.ButtonClick
        If Me.RechercheTableAdapter Is Nothing Then Exit Sub
        Dim search As String = Me.TxRecherche.Text.Trim
        If Me.MotEntierToolStripMenuItem.Checked Then
            search = " " & search & " "
        End If
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.RechercheTableAdapter.SearchBy(Me.DsAgrifact.Recherche, search)
        Me.TxRecherche.SelectAll()
        If Me.RechercheBindingSource.Count = 0 Then
            Me.TxRecherche.Control.Select()
            lbStatus.Text = "Aucun résultat"
        Else
            Me.dgResults.Select()
            lbStatus.Text = String.Format("{0} résultats", Me.RechercheBindingSource.Count)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgResults_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgResults.KeyPress
        If e.KeyChar = vbCr Then
            dgResults_CellMouseDoubleClick(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub dgResults_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgResults.CellMouseDoubleClick
        If Me.RechercheBindingSource.Position < 0 Then Exit Sub
        Dim dr As DsAgrifact.RechercheRow = Cast(Of DsAgrifact.RechercheRow)(Cast(Of DataRowView)(Me.RechercheBindingSource.Current).Row)
        Select Case dr.type
            Case "E" : FrEntreprise.Show(CInt(dr.Cle), Me)
            Case "P" : FrPersonne.Show(CInt(dr.Cle), Me)
        End Select
    End Sub

    Private Sub ParametresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametresToolStripMenuItem.Click
        Using fr As New FrParametres
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                My.Settings.NomDossier = Nothing
                For Each i As ToolStripMenuItem In DossierToolStripMenuItem.DropDownItems
                    i.Checked = False
                Next
                Dim sb As New SqlClient.SqlConnectionStringBuilder(My.Settings.ConnAgrifact)
                Me.Text = String.Format("Recherche sur la base {0}\{1}", sb.DataSource, sb.InitialCatalog)
                ResetAdapters()
            End If
        End Using
    End Sub

    Private Sub FrRecherche_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        notIcon.Text = Me.Text
    End Sub

    Private Sub InterventionClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterventionClientToolStripMenuItem.Click
        Dim fr As New FrIntervention
        fr.Show()
    End Sub

    Private Sub dgResults_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgResults.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each dr As DataGridViewRow In dgResults.Rows
                Select Case CType(dr.DataBoundItem, DataRowView)("Type").ToString
                    Case "P" : Cast(Of DataGridViewImageCell)(dr.Cells(Me.TypeIcon.Index)).Value = bmpUser
                    Case "E" : Cast(Of DataGridViewImageCell)(dr.Cells(Me.TypeIcon.Index)).Value = bmpUserAccounts
                End Select
            Next
        End If
    End Sub

    Private Sub dgResults_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles dgResults.CellToolTipTextNeeded
        If e.ColumnIndex = Me.ColTel.Index Then
            If e.RowIndex < 0 Then Exit Sub
            Dim dr As DataGridViewRow = dgResults.Rows(e.RowIndex)
            If dr.DataBoundItem Is Nothing Then Exit Sub
            Dim sql As String
            Select Case CType(dr.DataBoundItem, DataRowView)("Type").ToString
                Case "P" : sql = SqlProxy.FormatSql("SELECT * FROM Telephone WHERE nPersonne={0}", CType(dr.DataBoundItem, DataRowView)("Cle"))
                Case "E" : sql = SqlProxy.FormatSql("SELECT * FROM TelephoneEntreprise WHERE nEntreprise={0}", CType(dr.DataBoundItem, DataRowView)("Cle"))
            End Select

            Using s As New SqlProxy(My.Settings.ConnAgrifact)
                Dim dt As DataTable = s.ExecuteDataTable(sql)
                Dim tb As New System.Text.StringBuilder
                For Each rw As DataRow In dt.Rows
                    tb.AppendLine(String.Format("{0}: {1}", rw("Type"), rw("Numero")))
                Next
                'e.ToolTipText = tb.ToString.Trim
                Dim r As Rectangle = dgResults.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                ShowTooltip(tb.ToString.Trim, dgResults.PointToScreen(New Point(r.Right - 10, r.Bottom - 10)))
            End Using
        End If
    End Sub

    Dim childrenToKill As New List(Of Form)
    Private Sub ShowTooltip(ByVal str As String, ByVal p As Point)
        For Each f As Form In childrenToKill
            f.Close()
        Next
        childrenToKill.Clear()
        If str.Length = 0 Then Exit Sub
        Dim mp As Point = Form.MousePosition
        For i As Integer = 0 To 5
            Application.DoEvents()
            System.Threading.Thread.Sleep(20)
        Next
        Dim mp2 As Point = Form.MousePosition
        If Not (Math.Abs(mp.X - mp2.X) < 10 AndAlso Math.Abs(mp.Y - mp2.Y) < 10) Then Exit Sub
        Dim fr As New FrToolTip
        fr.Text = str
        fr.Show()
        fr.Location = p
        childrenToKill.Add(fr)
    End Sub

    Private Sub MenuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOpen.Click
        MenuOpen.DropDown = ctxIcon
        MenuOpen.ShowDropDown()
    End Sub

    Private Sub RechercherÉvénementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherÉvénementToolStripMenuItem.Click
        Dim fr As New FrRechercheEv
        fr.Show()
    End Sub

    Private Sub ctxIcon_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxIcon.Opening
        Me.FicheUtilisateurToolStripMenuItem.Enabled = Me.RechercheTableAdapter IsNot Nothing AndAlso (My.Settings.nPersonne > 0)
    End Sub

    Private Sub FicheUtilisateurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FicheUtilisateurToolStripMenuItem.Click
        If My.Settings.nPersonne <= 0 Then Exit Sub
        With New FrPersonne()
            .nPersonne = My.Settings.nPersonne
            .Show()
        End With
    End Sub
End Class
