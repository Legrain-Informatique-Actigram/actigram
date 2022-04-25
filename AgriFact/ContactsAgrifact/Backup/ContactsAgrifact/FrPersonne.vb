Public Class FrPersonne

    Public Overloads Shared Sub Show(ByVal nPersonne As Integer, Optional ByVal owner As Form = Nothing)
        Dim fr As New FrPersonne
        fr.nPersonne = nPersonne
        fr.Show(owner)
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
        Me.TelephoneTableAdapter.FillBynPersonne(Me.DsAgrifact.Telephone, nPersonne)
        Me.PersonneTableAdapter.FillByNPersonne(Me.DsAgrifact.Personne, nPersonne)
        Me.EntrepriseTableAdapter.FillBynPersonne(Me.DsAgrifact.Entreprise, nPersonne)
    End Sub

    Private Sub FrEntreprise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.TelephoneDataGridView)
        Me.TelephoneDataGridView.BackgroundColor = Color.White
        ChargerDonnees()
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
            If TelephoneBindingSource.Count = 0 Then
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
            FrEntreprise.Show(CInt(dr.nEntreprise), Me)
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
End Class