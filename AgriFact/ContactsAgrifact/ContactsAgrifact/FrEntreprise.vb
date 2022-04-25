Public Class FrEntreprise

#Region "Shared"
    Public Overloads Shared Sub Show(ByVal nEntreprise As Integer, Optional ByVal owner As Form = Nothing)
        Dim fr As New FrEntreprise
        fr.nEntreprise = nEntreprise
        If owner Is Nothing Then
            fr.Show()
        Else
            fr.Show(owner)
        End If
    End Sub
#End Region

#Region "Props"
    Private _nEntreprise As Integer = -1
    Public Property nEntreprise() As Integer
        Get
            Return _nEntreprise
        End Get
        Set(ByVal value As Integer)
            _nEntreprise = value
        End Set
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        If nEntreprise < 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Try
            Me.TelephoneEntrepriseTableAdapter.FillByNEntreprise(Me.DsAgrifact.TelephoneEntreprise, nEntreprise)
            Me.EntrepriseTableAdapter.FillByNEntreprise(Me.DsAgrifact.Entreprise, nEntreprise)
            With Me.PersonneTableAdapter
                .ClearBeforeFill = False
                .FillBynEntreprise(Me.DsAgrifact.Personne, nEntreprise)
                .FillUtilisateurs(Me.DsAgrifact.Personne)
            End With
            Me.EvenementTableAdapter.FillBynEntreprise(Me.DsAgrifact.Evenement, nEntreprise)
            Me.RecapProduitsTA.FillByNEntreprise(Me.DsAgrifact.RecapProduits, nEntreprise)
            Me.RecapCompteTA.FillByNEntreprise(Me.DsAgrifact.RecapCompte, nEntreprise)
            Me.FichierClientTableAdapter.FillByEntreprise(Me.DsAgrifact.FichierClient, nEntreprise)
            '
            Me.PersonneBindingSource.Filter = "nEntreprise=" & nEntreprise
            CalculTotalIntervAnnee()
            CalculSoldeClient()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CalculTotalIntervAnnee()
        lbTotalInterLabel.Text = String.Format("Total {0:yyyy}:", Today)
        Dim total As Object = Me.DsAgrifact.Evenement.Compute("Sum(duree)", String.Format("DateEv>'01/01/{0:yyyy}'", Today))
        If IsDBNull(total) Then
            Me.lbTotalInter.Text = "aucune"
        Else
            Me.lbTotalInter.Text = String.Format("{0}h{1}", CInt(total) \ 60, CInt(total) Mod 60)
        End If
    End Sub

    Private Sub CalculSoldeClient()
        Dim total As Object = Me.DsAgrifact.RecapCompte.Compute("Sum(montant)", "")
        If IsDBNull(total) Then
            Me.lbTotal.Text = String.Format("{0:C2}", 0)
        Else
            Me.lbTotal.Text = String.Format("{0:C2}", total)
        End If
    End Sub

    Private Sub EntrepriseBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EntrepriseBindingSource.CurrentChanged
        If Me.EntrepriseBindingSource.Current Is Nothing Then
            Me.Text = "Fiche entreprise"
        Else
            Dim dr As DsAgrifact.EntrepriseRow = Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
            Me.Text = String.Format("Fiche entreprise : {0} {1}", dr("Civilite"), dr("Nom"))
        End If
    End Sub
#End Region

#Region "Form events"

    Private Sub FrEntreprise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.TelephoneEntrepriseDataGridView)
        ApplyStyle(Me.PersonneDataGridView)
        ApplyStyle(Me.RecapCompteDataGridView)
        ApplyStyle(Me.RecapProduitsDataGridView)
        ApplyStyle(Me.EvenementDataGridView)
        ApplyStyle(Me.FichierClientDataGridView)
        Me.TelephoneEntrepriseDataGridView.BackgroundColor = Color.White
        ChargerDonnees()
        TbFilter_CheckedChanged(Nothing, Nothing)
        Me.nFichier.Visible = False
    End Sub

    Private Sub FrEntreprise_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Raccourcis claviers
        If e.KeyCode = Keys.F5 Then
            Me.TbActualiser.PerformClick()
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Toolbar"
    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub TbActualiser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbActualiser.Click
        ChargerDonnees()
    End Sub

    Private Sub TbIntervention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbIntervention.Click
        Dim fr As New FrIntervention
        AddHandler fr.FormClosed, AddressOf FrIntervention_Closed
        fr.nEntreprise = Me.nEntreprise
        fr.Show()
    End Sub

    Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        If Not Me.TbFilter.Checked Then
            Me.RecapCompteBindingSource.Filter = ""
            'Me.EvenementBindingSource.Filter = ""
        Else
            Me.RecapCompteBindingSource.Filter = "traite=false or traite is null"
            'Me.EvenementBindingSource.Filter = "realise=false or realise is null"
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fr As New FrChampsPersos
        fr.nEntreprise = Me.nEntreprise
        fr.Show(Me)
    End Sub

    Private Sub TbCopyCoords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCopyCoords.Click
        If Me.EntrepriseBindingSource.Current IsNot Nothing Then
            Dim dr As DsAgrifact.EntrepriseRow = Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
            Dim res As String = String.Format("{0} {1} <{5}>" & vbCrLf & "{2}" & vbCrLf & "{3} {4}", dr("Civilite"), dr("Nom"), dr("Adresse"), dr("CodePostal"), dr("Ville"), dr("Email"))
            res = res.Replace(vbCrLf & vbCrLf, vbCrLf).Trim
            For Each drT As DsAgrifact.TelephoneEntrepriseRow In dr.GetTelephoneEntrepriseRows
                res &= String.Format(vbCrLf & "{0} : {1}", drT("Type"), drT("Numero"))
            Next
            My.Computer.Clipboard.SetText(res.Trim)
        End If
    End Sub

    Private Sub TbGoogleMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbGoogleMaps.ButtonClick, ChercherLadresseComplèteToolStripMenuItem.Click, ChercherLaCommuneUniquementToolStripMenuItem.Click
        If Me.EntrepriseBindingSource.Current Is Nothing Then Exit Sub
        Dim dr As DsAgrifact.EntrepriseRow = Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
        Dim format As String = """{0}"" {1} ""{2}"""
        If sender Is Me.ChercherLaCommuneUniquementToolStripMenuItem Then format = """{0}"" {1}"
        Dim q As String = String.Format(format, Convert.ToString(dr("Ville")).Trim, dr("CodePostal"), Convert.ToString(dr("Adresse")).Trim)
        SearchGoogleMaps(q)
    End Sub

    Private Shared Sub SearchGoogleMaps(ByVal q As String, Optional ByVal openInBrowser As Boolean = False)
        q = q.Replace(vbCrLf, " ")
        q = q.Replace(vbTab, " ")
        q = q.Replace(Chr(34) & Chr(34), "")
        While q.IndexOf("  ") >= 0
            q = q.Replace("  ", " ")
        End While
        q = q.Replace(" ", "+")
        Dim url As String = "http://maps.google.fr/maps?hl=fr&q=" & q
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If openInBrowser Then
            Process.Start(url)
        Else
            Dim fr As New FrGoogleMaps(url)
            fr.Show()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TbOpenAgrifact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOpenAgrifact.Click
        'Ouvrir la fiche client dans Agrifact
        If Me.EntrepriseBindingSource.Current Is Nothing Then Exit Sub
        Dim d As String = ""
        If My.Settings.NomDossier IsNot Nothing Then
            d = My.Settings.NomDossier
        End If
        Dim args As New Collections.Specialized.StringDictionary()
        args.Add("dos", d)
        args.Add("ent", Me.nEntreprise.ToString)
        ActigramProtocol.CallApp("agrifact", args)
    End Sub
#End Region

#Region "Onglet Coordonnées"
    Private Sub EMailLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles EMailLinkLabel.LinkClicked
        OpenMail(EMailLinkLabel.Text)
    End Sub
#End Region

#Region "Onglet Contacts"
    Private Sub PersonneDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PersonneDataGridView.CellDoubleClick
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        Dim dr As DsAgrifact.PersonneRow = Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
        FrPersonne.Show(CInt(dr.nPersonne))
    End Sub
#End Region

#Region "Onglet Interventions"
    Private Sub EvenementDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EvenementDataGridView.CellDoubleClick
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        Dim nEv As Integer = CInt(Cast(Of DataRowView)(Me.EvenementBindingSource.Current)("nEvenement"))
        Dim fr As New FrIntervention
        AddHandler fr.FormClosed, AddressOf FrIntervention_Closed
        fr.nEntreprise = Me.nEntreprise
        fr.nEvenement = nEv
        fr.Show(Me)
    End Sub

    Private Sub FrIntervention_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If Me.IsDisposed Then Exit Sub
        If CType(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Dim currentIndex As Decimal = -1
            If Me.EvenementBindingSource.Position >= 0 Then
                currentIndex = CType(CType(Me.EvenementBindingSource.Current, DataRowView).Row, DsAgrifact.EvenementRow).nEvenement
            End If
            Me.EvenementTableAdapter.FillBynEntreprise(Me.DsAgrifact.Evenement, nEntreprise)
            CalculTotalIntervAnnee()
            If currentIndex > 0 Then Me.EvenementBindingSource.Position = Me.EvenementBindingSource.Find("nEvenement", currentIndex)
        End If
    End Sub
#End Region

#Region "Onglet Compte client"
    Private Sub RecapCompteDataGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RecapCompteDataGridView.CellContentClick
        'Ouvrir la facture dans agrifact
        If e.RowIndex < 0 Then Exit Sub
        If RecapCompteDataGridView.Columns(e.ColumnIndex) IsNot ColAgrifactButton Then Exit Sub
        Dim r As DataGridViewRow = Me.RecapCompteDataGridView.Rows(e.RowIndex)
        Dim c As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells(e.ColumnIndex))
        If Not c.ButtonVisible Then Exit Sub
        If Not c.Enabled Then Exit Sub
        If r.DataBoundItem Is Nothing OrElse Not TypeOf r.DataBoundItem Is DataRowView Then Exit Sub

        Dim drRecap As DsAgrifact.RecapCompteRow = Cast(Of DsAgrifact.RecapCompteRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
        If drRecap.Type = "F" Then
            Dim d As String = ""
            If My.Settings.NomDossier IsNot Nothing Then
                d = My.Settings.NomDossier
            End If
            Dim args As New Collections.Specialized.StringDictionary()
            args.Add("dos", d)
            args.Add("factid", drRecap.Id.ToString)
            ActigramProtocol.CallApp("agrifact", args)
        End If
    End Sub

    Private Sub RecapCompteDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles RecapCompteDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In RecapCompteDataGridView.Rows
                If r.DataBoundItem Is Nothing OrElse Not TypeOf r.DataBoundItem Is DataRowView Then Continue For
                Dim drRecap As DsAgrifact.RecapCompteRow = Cast(Of DsAgrifact.RecapCompteRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                Dim c As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells("ColAgrifactButton"))
                c.ButtonVisible = (drRecap.Type = "F")
            Next
        End If
    End Sub
#End Region

#Region "Onglet fichiers clients"
    Private Sub FichierClientBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichierClientBindingSource.PositionChanged
        If Me.FichierClientBindingSource.Position < 0 Then
            Me.TbDownload.Enabled = False
            Me.TbUpload.Enabled = False
        Else
            Dim dr As DsAgrifact.FichierClientRow = CType(CType(Me.FichierClientBindingSource.Current, DataRowView).Row, DsAgrifact.FichierClientRow)
            Me.TbDownload.Enabled = Not dr.IsLocal
            Me.TbUpload.Enabled = dr.IsLocal AndAlso Not dr.IsMachineNameNull AndAlso dr.MachineName = My.Computer.Name
        End If
    End Sub

#Region "Toolbar"
    Private Sub TbAddFichier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbAddFichier.Click
        Using dlg As New OpenFileDialog
            dlg.Multiselect = True
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each f As String In dlg.FileNames
                    AjouterFichier(f)
                Next
            End If
        End Using
    End Sub

    Private Sub TbRemoveFichier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRemoveFichier.Click
        'If Me.FichierClientBindingSource.Position < 0 Then Exit Sub
        'Me.FichierClientBindingSource.RemoveCurrent()
        'Supprimer les lignes sélectionnées dans la grille
        If Me.FichierClientDataGridView.SelectedRows.Count = 0 Then Exit Sub
        For Each r As DataGridViewRow In Me.FichierClientDataGridView.SelectedRows
            If r.DataBoundItem IsNot Nothing Then
                CType(r.DataBoundItem, DataRowView).Delete()
            End If
        Next
        'Refresh table
        Me.FichierClientTableAdapter.Update(Me.DsAgrifact.FichierClient)
    End Sub

    Private Sub TbOpenFichier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOpenFichier.Click
        For Each r As DataGridViewRow In Me.FichierClientDataGridView.SelectedRows
            If r.DataBoundItem IsNot Nothing Then
                OuvrirFichier(CType(CType(r.DataBoundItem, DataRowView).Row, DsAgrifact.FichierClientRow))
            End If
        Next
    End Sub

    Private Sub TbUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbUpload.Click
        UploadCurrent()
    End Sub

    Private Sub TbDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDownload.Click
        DownloadCurrent(True)
    End Sub

    Private Sub TbSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSaveAs.Click
        DownloadCurrent(False)
    End Sub
#End Region

    Private Sub AjouterFichier(ByVal filename As String)
        'Insert data
        Me.FichierClientTableAdapter.Insert(Me.nEntreprise, filename, True, My.Computer.Name, Now, My.Settings.nPersonne)
        'Refresh table
        Me.FichierClientTableAdapter.FillByEntreprise(Me.DsAgrifact.FichierClient, Me.nEntreprise)
    End Sub

    Private Sub OuvrirFichier(ByVal dr As DsAgrifact.FichierClientRow)
        If dr.IsLocal AndAlso Not dr.IsMachineNameNull AndAlso dr.MachineName <> My.Computer.Name Then
            If MsgBox("Ce fichier semble ne pas se trouver sur cet ordinateur, continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        OuvrirFichier(dr.CheminFichier)
    End Sub

    Private Sub OuvrirFichier(ByVal fichier As String)
        If Not IO.File.Exists(fichier) Then
            MsgBox(String.Format("Le fichier '{0}' est introuvable", fichier), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            Process.Start(fichier)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#Region "Grid Events"
    Private Sub FichierClientDataGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichierClientDataGridView.SelectionChanged
        Me.TbRemoveFichier.Enabled = (FichierClientDataGridView.SelectedRows.Count > 0)
        Me.TbOpenFichier.Enabled = (FichierClientDataGridView.SelectedRows.Count > 0)
    End Sub

    Private Sub FichierClientDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles FichierClientDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In FichierClientDataGridView.Rows
                If r.DataBoundItem Is Nothing OrElse Not TypeOf r.DataBoundItem Is DataRowView Then Continue For
                Dim drFichier As DsAgrifact.FichierClientRow = Cast(Of DsAgrifact.FichierClientRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                Dim c As DataGridViewTextBoxCell = Cast(Of DataGridViewTextBoxCell)(r.Cells(Me.NomFichier.Name))
                c.Value = IO.Path.GetFileName(drFichier.CheminFichier)
                Dim i As DataGridViewImageCell = Cast(Of DataGridViewImageCell)(r.Cells(Me.IconeFichier.Name))
                Dim img As Icon = GetFileIcon(drFichier.CheminFichier)
                If img IsNot Nothing Then i.Value = img.ToBitmap
            Next
        End If
    End Sub

    Private Sub FichierClientDataGridView_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles FichierClientDataGridView.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r As DataGridViewRow = Me.FichierClientDataGridView.Rows(e.RowIndex)
        If r.DataBoundItem IsNot Nothing Then
            OuvrirFichier(CType(CType(r.DataBoundItem, DataRowView).Row, DsAgrifact.FichierClientRow))
        End If
    End Sub

    Private Sub FichierClientDataGridView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FichierClientDataGridView.DragDrop
        If e.Effect = DragDropEffects.Link Then
            If e.Data.GetDataPresent("FileDrop") Then
                Dim files() As String = CType(e.Data.GetData("FileDrop"), String())
                For Each f As String In files
                    AjouterFichier(f)
                Next
            End If
        End If
    End Sub

    Private Sub FichierClientDataGridView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FichierClientDataGridView.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub FichierClientDataGridView_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles FichierClientDataGridView.QueryContinueDrag
        e.Action = DragAction.Continue
        If e.EscapePressed Then
            e.Action = DragAction.Cancel
        Else
            e.Action = DragAction.Continue
        End If
    End Sub
#End Region

#Region "Partage de fichiers sur serveur"
    Private Sub DownloadCurrent(ByVal makeLocal As Boolean)
        If Me.FichierClientBindingSource.Position < 0 Then Exit Sub
        Dim dr As DsAgrifact.FichierClientRow = CType(CType(Me.FichierClientBindingSource.Current, DataRowView).Row, DsAgrifact.FichierClientRow)
        If dr.IsLocal Then
            If dr.IsMachineNameNull OrElse dr.MachineName = My.Computer.Name Then
                MsgBox("Ce fichier se trouve déjà sur l'ordinateur.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Ce fichier n'est pas disponible sur le réseau.", MsgBoxStyle.Exclamation)
            End If
            Exit Sub
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim src As String = dr.CheminFichier
            If Not IO.File.Exists(src) Then
                MsgBox(String.Format("Le fichier '{0}' est introuvable, vérifiez votre connexion au réseau.", src), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim dest As String
            Using dlg As New SaveFileDialog
                dlg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                dlg.FileName = IO.Path.GetFileName(src)
                If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                dest = dlg.FileName
            End Using
            If dest Is Nothing Then Exit Sub
            If IO.File.Exists(dest) Then IO.File.Delete(dest)
            IO.File.Copy(src, dest)

            'Retirer le fichier du serveur
            If makeLocal Then
                If Not IO.File.Exists(dest) Then Exit Sub
                Try
                    IO.File.Delete(src)
                Catch ex As Exception
                    'Ca peut planter en fonction des droits de l'utilisateur sur le partage
                    LogException(ex)
                End Try
                'MAJ la base de données
                With dr
                    .IsLocal = True
                    .MachineName = My.Computer.Name
                    .CheminFichier = dest
                    .DateModification = Now
                    .nPersonneAuteur = My.Settings.nPersonne
                End With
                Me.FichierClientTableAdapter.Update(Me.DsAgrifact.FichierClient)
            End If
            FichierClientBindingSource_PositionChanged(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub UploadCurrent()
        If Me.FichierClientBindingSource.Position < 0 Then Exit Sub
        Dim dr As DsAgrifact.FichierClientRow = CType(CType(Me.FichierClientBindingSource.Current, DataRowView).Row, DsAgrifact.FichierClientRow)
        If Not dr.IsLocal OrElse dr.IsMachineNameNull OrElse dr.MachineName <> My.Computer.Name Then
            MsgBox("Ce fichier ne se trouve pas sur cet ordinateur.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim src As String = dr.CheminFichier
            If Not IO.File.Exists(src) Then
                MsgBox(String.Format("Le fichier '{0}' est introuvable.", src), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim dest As String = IO.Path.Combine(TrouverCheminPartage(Me.nEntreprise, Me.NomTextBox.Text), IO.Path.GetFileName(dr.CheminFichier))
            If dest Is Nothing Then Exit Sub
            If IO.File.Exists(dest) Then IO.File.Delete(dest)
            IO.File.Copy(src, dest)

            'Marquer le fichier comme partagé
            If Not IO.File.Exists(dest) Then Exit Sub
            'MAJ la base de données
            With dr
                .IsLocal = False
                .SetMachineNameNull()
                .CheminFichier = dest
                .DateModification = Now
                .nPersonneAuteur = My.Settings.nPersonne
            End With
            Me.FichierClientTableAdapter.Update(Me.DsAgrifact.FichierClient)
            FichierClientBindingSource_PositionChanged(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function TrouverCheminPartage(ByVal nEntreprise As Decimal, ByVal nom As String) As String
        If Not IO.Directory.Exists(My.Settings.RacinePartageFichiers) Then
            MsgBox(String.Format("Le chemin de partage '{0}' n'est pas disponible", My.Settings.RacinePartageFichiers), MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        Dim dirs As String() = IO.Directory.GetDirectories(My.Settings.RacinePartageFichiers, nEntreprise & " *")
        If dirs.Length > 0 Then
            Return dirs(0)
        Else
            Try
                Dim res As String = IO.Path.Combine(My.Settings.RacinePartageFichiers, FixNom(nEntreprise & " " & nom))
                IO.Directory.CreateDirectory(res)
                Return res
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Return Nothing
            End Try
        End If
    End Function

    Private Function FixNom(ByVal nom As String) As String
        Dim forbiddenChars() As Char = {"."c, "*"c, "\"c, "/"c, "?"c, ":"c, "<"c, ">"c, "|"c, Chr(34)}
        For Each c As Char In forbiddenChars
            nom = nom.Replace(c, "-")
        Next
        Return Microsoft.VisualBasic.Left(nom, 30)
    End Function
#End Region

#End Region

   
End Class