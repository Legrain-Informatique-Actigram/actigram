Public Class FrOptionsImprBilan

    Private DtDeb As Date = Date.MinValue
    Private DtFin As Date = Date.MinValue

#Region "Form"
    Private Sub FrOptionsImprBilan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DtDeb > Date.MinValue Then
            dtpDtDeb.Value = Me.DtDeb
        Else
            dtpDtDeb.Value = New Date(Today.Year - 1, 1, 1)
        End If

        If Me.DtFin > Date.MinValue Then
            dtpDtFin.Value = Me.DtFin
        Else
            dtpDtFin.Value = New Date(Today.Year - 1, 12, 31)
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub ImprimerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerButton.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim fr As Form = GestionApproFact.ImprimerBilan(dtpDtDeb.Value, dtpDtFin.Value)
            Me.DialogResult = DialogResult.OK
            Me.Close()
            fr.BringToFront()
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ExporterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterButton.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim ds As New DataSet

            RedevancePhyto.ExportBilan.ExporterBilan(dtpDtDeb.Value, dtpDtFin.Value, TxObs.Text.Trim)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

End Class