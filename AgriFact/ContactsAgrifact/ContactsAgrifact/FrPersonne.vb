Public Class FrPersonne

    Dim isUtilisateur As Boolean

    Public Overloads Shared Sub Show(ByVal nPersonne As Integer, Optional ByVal owner As Form = Nothing)
        Dim fr As New FrPersonne
        fr.nPersonne = nPersonne
        If owner Is Nothing Then
            fr.Show()
        Else
            fr.Show(owner)
        End If
    End Sub

    Private _nPersonne As Integer = -1
    Public Property nPersonne() As Integer
        Get
            Return _nPersonne
        End Get
        Set(ByVal value As Integer)
            _nPersonne = value
        End Set
    End Property

    Private Sub ChargerDonnees()
        If nPersonne < 0 Then Exit Sub
        'Déterminer si la personne est un utilisateur
        Me.isUtilisateur = Me.PersonneTableAdapter.IsUtilisateur(nPersonne).GetValueOrDefault > 0
        Me.TelephoneTableAdapter.FillBynPersonne(Me.DsAgrifact.Telephone, nPersonne)
        Me.PersonneTableAdapter.FillByNPersonne(Me.DsAgrifact.Personne, nPersonne)
        If Not Me.isUtilisateur Then
            Me.EntrepriseTableAdapter.FillBynPersonne(Me.DsAgrifact.Entreprise, nPersonne)
        Else
            'Charger toutes les entreprises (pour le nom dans les inter)
            Me.EntrepriseTableAdapter.Fill(Me.DsAgrifact.Entreprise)
            'Charger les interventions de l'auteur
            Me.EvenementTableAdapter.FillByNAuteur(Me.DsAgrifact.Evenement, nPersonne)
            CalculTotalIntervAnnee()
        End If
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

    Private Sub FrEntreprise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.TelephoneDataGridView)
        ApplyStyle(Me.EvenementDataGridView)
        Me.TelephoneDataGridView.BackgroundColor = Color.White
        ChargerDonnees()
        If Not Me.isUtilisateur Then
            Me.TabControl1.TabPages.Remove(Me.tpInters)
            Me.TbIntervention.Visible = False
        End If
        Me.NPersonneDataGridViewTextBoxColumn.Visible = False
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub PersonneBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PersonneBindingSource.CurrentChanged
        If Me.PersonneBindingSource.Current Is Nothing Then
            Me.Text = "Fiche personne"
        Else
            Dim dr As DsAgrifact.PersonneRow = Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
            Me.Text = String.Format("Fiche personne : {0} {1}", dr("Nom"), dr("Prenom"))
            If Me.isUtilisateur Then
                Me.TabControl1.SelectedTab = Me.tpInters
            ElseIf TelephoneBindingSource.Count = 0 Then
                Me.TabControl1.SelectedTab = Me.tpCoord
            Else
                Me.TabControl1.SelectedTab = Me.tpTel
            End If
        End If
    End Sub

    Private Sub LnkMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkMail.LinkClicked
        OpenMail(LnkMail.Text)
    End Sub

    Private Sub LnkEntreprise_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEntreprise.LinkClicked
        If Me.PersonneBindingSource.Current Is Nothing Then Exit Sub
        Dim dr As DsAgrifact.PersonneRow = Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
        If Not dr.IsnEntrepriseNull Then
            FrEntreprise.Show(CInt(dr.nEntreprise))
        End If
    End Sub

    Private Sub TbCopyCoords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCopyCoords.Click
        If Me.PersonneBindingSource.Current IsNot Nothing Then
            Dim dr As DsAgrifact.PersonneRow = Cast(Of DsAgrifact.PersonneRow)(Cast(Of DataRowView)(Me.PersonneBindingSource.Current).Row)
            Dim res As String = String.Format("{0} {1} <{5}>" & vbCrLf & "{2}" & vbCrLf & "{3} {4}", dr("Prenom"), dr("Nom"), dr("Adresse"), dr("CodePostal"), dr("Ville"), dr("Email"))
            res = res.Replace(vbCrLf & vbCrLf, vbCrLf).Trim
            For Each drT As DsAgrifact.TelephoneRow In dr.GetTelephoneRows
                res &= String.Format(vbCrLf & "{0} : {1}", drT("Type"), drT("Numero"))
            Next
            My.Computer.Clipboard.SetText(res.Trim)
        End If
    End Sub

    Private Sub TbIntervention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbIntervention.Click
        Dim fr As New FrIntervention
        AddHandler fr.FormClosed, AddressOf FrIntervention_Closed
        fr.nAuteur = Me.nPersonne
        fr.Show()
    End Sub

    Private Sub EvenementDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EvenementDataGridView.CellDoubleClick
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub
        Dim nEv As Integer = CInt(Cast(Of DataRowView)(Me.EvenementBindingSource.Current)("nEvenement"))
        Dim fr As New FrIntervention
        AddHandler fr.FormClosed, AddressOf FrIntervention_Closed
        fr.nAuteur = Me.nPersonne
        fr.nEvenement = nEv
        fr.Show(Me)
    End Sub

    Private Sub FrIntervention_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If CType(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Dim currentIndex As Decimal = -1
            If Me.EvenementBindingSource.Position >= 0 Then
                currentIndex = CType(CType(Me.EvenementBindingSource.Current, DataRowView).Row, DsAgrifact.EvenementRow).nEvenement
            End If
            Me.EvenementTableAdapter.FillByNAuteur(Me.DsAgrifact.Evenement, nPersonne)
            CalculTotalIntervAnnee()
            If currentIndex > 0 Then Me.EvenementBindingSource.Position = Me.EvenementBindingSource.Find("nEvenement", currentIndex)
        End If
    End Sub
End Class