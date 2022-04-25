Public Class FrEntreprise

    Public Overloads Shared Sub Show(ByVal nEntreprise As Integer, Optional ByVal owner As Form = Nothing)
        Dim fr As New FrEntreprise
        fr.nEntreprise = nEntreprise
        fr.Show(owner)
    End Sub

    Private _nEntreprise As Integer = -1
    Public Property nEntreprise() As Integer
        Get
            Return _nEntreprise
        End Get
        Set(ByVal value As Integer)
            _nEntreprise = value
        End Set
    End Property

    Private Sub ChargerDonnees()
        If nEntreprise < 0 Then Exit Sub
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
        '
        Me.PersonneBindingSource.Filter = "nEntreprise=" & nEntreprise
        CalculTotalIntervAnnee()
        CalculSoldeClient()
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

    Private Sub FrEntreprise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.TelephoneEntrepriseDataGridView)
        ApplyStyle(Me.PersonneDataGridView)
        ApplyStyle(Me.RecapCompteDataGridView)
        ApplyStyle(Me.RecapProduitsDataGridView)
        ApplyStyle(Me.EvenementDataGridView)
        Me.TelephoneEntrepriseDataGridView.BackgroundColor = Color.White
        ChargerDonnees()
        TbFilter_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub EntrepriseBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EntrepriseBindingSource.CurrentChanged
        If Me.EntrepriseBindingSource.Current Is Nothing Then
            Me.Text = "Fiche entreprise"
        Else
            Dim dr As DsAgrifact.EntrepriseRow = Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
            Me.Text = String.Format("Fiche entreprise : {0} {1}", dr("Civilite"), dr("Nom"))
            Me.TabControl1.SelectedTab = Me.tpCoord

        End If
    End Sub

    Private Sub LnkMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkMail.LinkClicked
        OpenMail(LnkMail.Text)
    End Sub

    Private Sub PersonneDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PersonneDataGridView.CellDoubleClick
        If Me.PersonneBindingSource.Position < 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        Dim dr As DsAgrifact.PersonneRow = Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
        FrPersonne.Show(CInt(dr.nPersonne), Me)
    End Sub

    Private Sub TbIntervention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbIntervention.Click
        Dim fr As New FrIntervention
        AddHandler fr.FormClosed, AddressOf FrIntervention_Closed
        fr.nEntreprise = Me.nEntreprise
        fr.Show()
    End Sub

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
        Me.EvenementTableAdapter.FillBynEntreprise(Me.DsAgrifact.Evenement, nEntreprise)
        CalculTotalIntervAnnee()
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

    Private Sub EMailLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles EMailLinkLabel.LinkClicked
        OpenMail(EMailLinkLabel.Text)
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
        Dim url As String = String.Format("actigram://agrifact/?dos={0}&ent={1}", Uri.EscapeDataString(d), Me.nEntreprise)
        Try
            Process.Start(url)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

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
            Dim url As String = String.Format("actigram://agrifact/?dos={0}&factid={1}", Uri.EscapeDataString(d), drRecap.Id)
            Try
                Process.Start(url)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
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
End Class