Namespace Etats
    Public Class FrEtatNonConf

#Region "Donnnées"
        Private Sub ChargerDonnees()
            Try
                Cursor.Current = Cursors.WaitCursor
                Me.EtatConfDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Me.EtatNonConfBindingSource.SuspendBinding()
                Dim l As New List(Of Controles.ResultatControle)
                With Me.EtatsDataset
                    .EnforceConstraints = False
                    Me.EtatNonConfTableAdapter.Fill(.EtatNonConf, dtpDeb.Value, dtpFin.Value)
                    If .EtatNonConf.Rows.Count = 0 Then
                        MsgBox("Aucune information disponible pour cette période.", MsgBoxStyle.Information)
                    Else
                        EtatConfDataGridView.Focus()
                    End If
                    .EnforceConstraints = True
                End With
                Me.EtatNonConfBindingSource.ResumeBinding()
            Finally
                Cursor.Current = Cursors.Default
                Me.EtatConfDataGridView.UseWaitCursor = False
            End Try
        End Sub
#End Region

#Region "Page"
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            CType(BtGo.Image, Bitmap).MakeTransparent(Color.Magenta)
            ApplyStyle(Me.EtatConfDataGridView)
            dtpFin.MaxDate = Now.Date
            dtpDeb.MaxDate = Now.Date
            dtpFin.Value = Now.Date
            dtpDeb.Value = Now.Date.AddDays(-My.Settings.PeriodeHisto)
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub
#End Region

#Region "Grid"
        Private Sub EtatConfDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatConfDataGridView.DoubleClick
            If Me.EtatNonConfBindingSource.Current Is Nothing Then Exit Sub
            Dim curRes As EtatsDataset.EtatNonConfRow = Cast(Of EtatsDataset.EtatNonConfRow)(Cast(Of DataRowView)(Me.EtatNonConfBindingSource.Current).Row)
            With New Controles.FrResultatBareme(curRes.nresultatbareme)
                .ReadOnly = True
                .ShowDialog()
            End With
        End Sub
#End Region

#Region "Boutons"
        Private Sub BtGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGo.Click
            ChargerDonnees()
        End Sub

        Private Sub BtImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImpr.Click
            If Me.EtatsDataset.EtatNonConf.Count = 0 Then Exit Sub
            EcranCrystal.Apercu("RptEtatNonConf.rpt", Me.EtatsDataset.EtatNonConf)
        End Sub
#End Region

        Private Sub dtpDeb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDeb.ValueChanged
            If dtpDeb.Value > dtpFin.Value Then
                dtpFin.Value = dtpDeb.Value
            End If
        End Sub

        Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
            If dtpFin.Value < dtpDeb.Value Then
                dtpDeb.Value = dtpFin.Value
            End If
        End Sub

    End Class
End Namespace