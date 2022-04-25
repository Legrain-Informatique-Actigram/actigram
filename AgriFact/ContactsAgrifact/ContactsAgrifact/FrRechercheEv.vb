Public Class FrRechercheEv

    'DONE Recherche par mots clés sur la maintenance

    Private Sub FrRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbStatus.Text = ""
        ApplyStyle(Me.dgResults)
        CType(Me.BtGo.Image, Bitmap).MakeTransparent(Color.Magenta)
        Me.TxRecherche.Control.Select()
        Me.TxRecherche.SelectAll()
    End Sub

    Private Sub TxRecherche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRecherche.KeyPress
        If e.KeyChar = vbCr Then
            BtGo.PerformButtonClick()
            e.Handled = True
        End If
    End Sub

    Private Sub BtGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGo.ButtonClick
        Dim search As String = Me.TxRecherche.Text.Trim
        If Me.MotEntierToolStripMenuItem.Checked Then
            search = " " & search & " "
        End If
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.RechercheEvTableAdapter.SearchBy(Me.DsAgrifact.RechercheEv, search)
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
        Dim dr As DsAgrifact.RechercheEvRow = Cast(Of DsAgrifact.RechercheEvRow)(Cast(Of DataRowView)(Me.RechercheBindingSource.Current).Row)
        With New FrIntervention
            .nEvenement = CInt(dr.nEvenement)
            .Show()
        End With
    End Sub
End Class
