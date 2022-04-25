Public Class FrRecherche

    Private _selectedId As Integer = -1

#Region "Propriétés"
    Public Property SelectedId() As Integer
        Get
            Return _selectedId
        End Get
        Set(ByVal value As Integer)
            _selectedId = value
        End Set
    End Property
#End Region

#Region "Form"
    Private Sub FrRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.dgResults)
        AddHandler Me.dgResults.MouseDown, AddressOf dg_GestionClicDroit
        Me.ToolStrip1.Select()
        Me.TxRecherche.Control.Select()
        Me.TxRecherche.SelectAll()
    End Sub
#End Region

#Region " Toolbar "
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub TxRecherche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRecherche.KeyPress
        If e.KeyChar = vbCr Then
            Recherche()
            e.Handled = True
        End If
    End Sub

    Private Sub BtGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGo.ButtonClick
        Recherche()
    End Sub
#End Region

#Region "ctxGrid"
    Private Sub FicheClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FicheClientToolStripMenuItem.Click
        If Me.RechercheBindingSource.Position < 0 Then Exit Sub
        Dim dr As DsAgrifact.RechercheRow = Cast(Of DsAgrifact.RechercheRow)(Cast(Of DataRowView)(Me.RechercheBindingSource.Current).Row)
        Select Case dr.type
            Case "E"
                Using fr As New FrSaisieClient(CInt(dr.Cle))
                    fr.ShowDialog(Me)
                End Using
            Case "P" 'On ne gère pas les personnes ici
        End Select
    End Sub
#End Region

#Region " Grid "
    Private Sub dgResults_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgResults.KeyPress
        If e.KeyChar = vbCr Then
            dgResults_CellMouseDoubleClick(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub dgResults_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgResults.CellMouseDoubleClick
        If Me.RechercheBindingSource.Position < 0 Then Exit Sub
        If e.ColumnIndex <= ColImDetails.Index Then Exit Sub
        Me.SelectedId = CInt(Cast(Of DsAgrifact.RechercheRow)(Cast(Of DataRowView)(Me.RechercheBindingSource.Current).Row).Cle)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgResults_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResults.CellContentClick
        If e.ColumnIndex = ColImDetails.Index Then
            FicheClientToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

#Region "Gestion du pointeur sur la colonne Détails"
    Private Sub dgResults_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResults.CellMouseEnter
        If e.ColumnIndex = ColImDetails.Index Then
            Cursor.Current = Cursors.Hand
            dgResults.Cursor = Cursors.Hand
        Else
            Cursor.Current = Cursors.Default
            dgResults.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dgResults_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResults.CellMouseLeave
        If e.ColumnIndex = ColImDetails.Index Then
            Cursor.Current = Cursors.Default
            dgResults.Cursor = Cursors.Default
        End If
    End Sub
#End Region
#End Region

#Region "Méthodes diverses"
    Private Sub Recherche()
        Dim search As String = Me.TxRecherche.Text.Trim
        If Me.MotEntierToolStripMenuItem.Checked Then
            search = " " & search & " "
        End If
        Cursor.Current = Cursors.WaitCursor
        Me.RechercheTableAdapter.SearchBy(Me.DsAgrifact.Recherche, search)
        Me.TxRecherche.SelectAll()
        If Me.RechercheBindingSource.Count = 0 Then
            Me.TxRecherche.Control.Select()
        Else
            Me.dgResults.Select()
        End If
        Cursor.Current = Cursors.Default
    End Sub
#End Region

End Class
