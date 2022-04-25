Imports System.Windows.Forms

Public Class FrChoixCompte

#Region "Propritétés"
    Private _Compte As String
    Public ReadOnly Property Compte() As String
        Get
            Return _Compte
        End Get
    End Property
#End Region

#Region "Page"
    Private Sub FrChoixCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.ComptesTableAdapter.FillByDossier(Me.DsPLC.Comptes, My.User.Name)
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cboCompteDisplay.SelectedIndex > -1 Then
            _Compte = Convert.ToString(cboCompteDisplay.SelectedValue)
        Else
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
#End Region

End Class
