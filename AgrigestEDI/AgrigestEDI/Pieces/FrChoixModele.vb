Imports System.Windows.Forms

Public Class FrChoixModele

    Private Ds As New dbDonneesDataSet

#Region "Page"
    Private Sub FrChoixModele_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        LoadCombo()
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Using xModele As New FrModele
            Cursor.Current = Cursors.WaitCursor
            If xModele.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                LoadCombo()
                'cboModele.Invalidate()
                cboModele.SelectedIndex = cboModele.FindString(xModele.ModeleNameACharger)
            End If
            Cursor.Current = Cursors.Default
        End Using
    End Sub

    Private Sub cmdModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModif.Click
        If cboModele.SelectedItem Is Nothing Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Using xModele As New FrModele
            xModele.ModeleNameACharger = Convert.ToString(CType(cboModele.SelectedItem, DataRowView)("ModLPiece"))
            If xModele.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                LoadCombo()
                'cboModele.Invalidate()
                cboModele.SelectedIndex = cboModele.FindString(xModele.ModeleNameACharger)
            End If
            Cursor.Current = Cursors.Default
        End Using
    End Sub

    Private Sub cmdSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSuppr.Click
        If cboModele.SelectedItem Is Nothing Then Exit Sub
        If MsgBox(String.Format(My.Resources.Strings.SuppressionModele, Convert.ToString(CType(cboModele.SelectedItem, DataRowView)("ModLPiece"))), MsgBoxStyle.YesNo, My.Resources.Strings.Modele_Suppression) = MsgBoxResult.Yes Then
            Dim sModele As String = Convert.ToString(CType(cboModele.SelectedItem, DataRowView)("ModLPiece"))
            Dim l As New Modele(sModele)
            If l.SuppressionModele() Then
                MsgBox(My.Resources.Strings.Modele_ModeleSupprime, MsgBoxStyle.Information, My.Resources.Strings.Suppression)
                LoadCombo()
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadCombo()
        'Me.ModLignesTableAdapter.ClearBeforeFill = True
        'Me.Ds.ModLignes.Clear()
        Try
            Me.ModLignesTableAdapter.FillByExpl(Me.Ds.ModLignes, CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl)
        Catch ex As ConstraintException
        End Try
        Dim dvSource As DataView = New DataView(Me.Ds.ModLignes)
        Dim dtDistinct As DataTable = dvSource.ToTable(True, "ModLPiece")
        cboModele.DataSource = dtDistinct
        cboModele.DisplayMember = "ModLPiece"
        cboModele.ValueMember = "ModLPiece"
    End Sub
#End Region

    Private Sub cboModele_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModele.DoubleClick
        cmdModif_Click(Nothing, Nothing)
    End Sub
End Class
