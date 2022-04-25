Imports System.Windows.Forms

Public Class FrRechercheCompte

#Region "Propriétés"
    Private _Compte As String
    Public Property Compte() As String
        Get
            Return _Compte
        End Get
        Set(ByVal value As String)
            _Compte = value
        End Set
    End Property

    Private _CompteDisplay As String
    Public Property CompteDisplay() As String
        Get
            Return _CompteDisplay
        End Get
        Set(ByVal value As String)
            _CompteDisplay = value
        End Set
    End Property
#End Region

#Region "Page"
    Private Sub FrRechercheCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Try
            With Me.DsRecherche
                .EnforceConstraints = False
                Me.ComptesTableAdapter.FillByDossier(.Comptes, My.User.Name)
                Me.PlanComptableTableAdapter.FillByDossier(.PlanComptable, My.User.Name)
            End With
            txtRecherche.Select()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If dgvRecherche.SelectedCells.Count = 0 Then Exit Sub
        ReturnCompte(dgvRecherche.SelectedCells(0).RowIndex)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindResult()
    End Sub

    Private Sub ReturnCompte(ByVal nRowIndex As Integer)
        If dgvRecherche.Rows(nRowIndex).DataBoundItem IsNot Nothing AndAlso TypeOf dgvRecherche.Rows(nRowIndex).DataBoundItem Is DataRowView Then
            Dim xRow As dsPLC.PlanComptableRow = CType(CType(dgvRecherche.Rows(nRowIndex).DataBoundItem, DataRowView).Row, dsPLC.PlanComptableRow)
            Compte = xRow.PlCpt
            CompteDisplay = xRow.CptDisplay
        End If
    End Sub

    Private Sub ReturnCompte()
        Dim xRow As dsPLC.PlanComptableRow = CType(CType(Me.PLCBindingSource.Current, DataRowView).Row, dsPLC.PlanComptableRow)
        Compte = xRow.PlCpt
        CompteDisplay = xRow.CptDisplay
    End Sub

    Private Sub FindResult()
        Try
            Dim rech As String = String.Format("PlCpt like '*{0}*' OR PlLib like '*{0}*' OR CptDisplay like '*{0}*'", txtRecherche.Text)
            Me.PLCBindingSource.Filter = rech
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "dgvRecherche"
    Private Sub dgvRecherche_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecherche.CellDoubleClick
        ReturnCompte(e.RowIndex)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvRecherche_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRecherche.KeyDown
        If e.KeyCode = Keys.Enter Then
            ReturnCompte()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            e.Handled = True
        End If
    End Sub
#End Region

#Region "txtRecherche"
    Private Sub txtRecherche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecherche.KeyPress
        If e.KeyChar = vbCr Then
            FindResult()
            e.Handled = True
        End If
    End Sub

    Private Sub txtRecherche_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecherche.KeyUp
        Select Case e.KeyCode
            Case Keys.Down, Keys.Up
                Me.dgvRecherche.Select()
                If Me.PLCBindingSource.Position > 0 AndAlso e.KeyCode = Keys.Up Then
                    Me.PLCBindingSource.Position -= 1
                ElseIf Me.PLCBindingSource.Position < Me.PLCBindingSource.Count - 1 AndAlso e.KeyCode = Keys.Down Then
                    Me.PLCBindingSource.Position += 1
                End If
                e.Handled = True
        End Select
    End Sub

    Private Sub txtRecherche_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecherche.TextChanged
        FindResult()
    End Sub
#End Region

End Class
