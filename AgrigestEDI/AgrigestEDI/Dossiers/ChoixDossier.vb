Imports System.Windows.Forms

Public Class ChoixDossier

    Public Dossier As DossierPrincipal

    Private sNewDossier As String = ""
    Private sDossierSelected As String = ""

#Region "Propriétés"
    Private _expl As String
    Public Property CodeExploitation() As String
        Get
            Return _expl
        End Get
        Set(ByVal value As String)
            _expl = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal codeExpl As String)
        Me.New()
        Me.CodeExploitation = codeExpl
    End Sub
#End Region

#Region "Page"
    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ChargerDonnees()
        'Si on n'a aucun dossier, passer directement en création de dossier
        If Me.DossiersBindingSource.Count = 0 Then
            cmdNew_Click(Nothing, Nothing)
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Dossier = GetDossier()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If DossiersBindingSource.Count = 0 Then
            Me.Dossier = Nothing
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        'Si Me.CodeExploitation n'est pas vide sélectionner cette expl par défaut 
        Using xNewExploi As New FrNewExploi
            If Me.CodeExploitation IsNot Nothing Then
                xNewExploi.CodeExploitation = Me.CodeExploitation
            End If
            If xNewExploi.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
                Me.DossiersBindingSource.ResetBindings(False)
                Me.DDossierComboBox.SelectedIndex = Me.DDossierComboBox.FindString(xNewExploi.CodeDossier)
                OK_Button_Click(Nothing, Nothing)
            Else
                ChargerDonnees()
                Me.DossiersBindingSource.ResetBindings(False)
            End If
        End Using
    End Sub

    Private Sub cmdModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModif.Click
        If Me.DossiersBindingSource.Current Is Nothing Then Exit Sub
        Using xNewExploi As New FrNewExploi
            'Dim d As dbDonneesDataSet.DossiersRow = CType(CType(Me.DossiersBindingSource.Current, DataRowView).Row, dbDonneesDataSet.DossiersRow)
            xNewExploi.Dossier = Me.GetDossier
            If xNewExploi.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
                Me.DossiersBindingSource.ResetBindings(False)
                Me.DDossierComboBox.SelectedIndex = Me.DDossierComboBox.FindString(xNewExploi.CodeDossier)
            Else
                ChargerDonnees()
                Me.DossiersBindingSource.ResetBindings(False)
            End If
        End Using
    End Sub

    Private Sub cmdSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSuppr.Click
        If Me.DossiersBindingSource.Current Is Nothing Then Exit Sub
        Using fr As New FrSupprDossier
            fr.Dossier = Me.GetDossier
            If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
                Me.DossiersBindingSource.ResetBindings(False)
                If Me.DossiersBindingSource.Count = 0 Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
            End If
        End Using
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Me.JournalTableAdapter.Fill(Me.DbDonneesDataSet.Journal)
        If Me.CodeExploitation IsNot Nothing Then
            Me.ExploitationsTableAdapter.FillByExpl(Me.DbDonneesDataSet.Exploitations, Me.CodeExploitation)
            Me.DossiersTableAdapter.FillByExpl(Me.DbDonneesDataSet.Dossiers, Me.CodeExploitation)
        Else
            Me.ExploitationsTableAdapter.Fill(Me.DbDonneesDataSet.Exploitations)
            Me.DossiersTableAdapter.Fill(Me.DbDonneesDataSet.Dossiers)
        End If
    End Sub

    Public Function GetDossier() As DossierPrincipal
        Try
            If Me.DDossierComboBox.SelectedItem Is Nothing Then Return Nothing

            Dim drDossier As dbDonneesDataSet.DossiersRow = CType(CType(Me.DDossierComboBox.SelectedItem, DataRowView).Row, dbDonneesDataSet.DossiersRow)
            Dim drExpl As dbDonneesDataSet.ExploitationsRow = drDossier.ExploitationsRow

            Return New DossierPrincipal(drDossier, drExpl)
        Catch ex As Exception
            LogException(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
