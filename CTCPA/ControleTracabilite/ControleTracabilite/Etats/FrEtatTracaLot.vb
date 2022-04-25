Namespace Etats
    Public Class FrEtatTracaLot

#Region "Donnnées"
        Private Sub ChargerLots()
            Me.ListeLotsTableAdapter.Fill(Me.EtatsDataset.ListeLots)
        End Sub

        Private Sub LotsBindingSource_ListChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles LotsBindingSource.ListChanged
            If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
                FillCb(LotsBindingSource, cbLot, "nLot", "nLot", Nothing, True)
            End If
        End Sub

        Private Sub ChargerDonnees()
            If cbLot.SelectedIndex < 0 Then Exit Sub
            Try
                Cursor.Current = Cursors.WaitCursor
                Me.EtatTracaLotDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Me.EtatTracaLotBindingSource.SuspendBinding()
                With Me.EtatsDataset
                    .EnforceConstraints = False
                    Me.EtatTracaLotTableAdapter.Fill(.EtatTracaLot, cbLot.Text)
                    If .EtatTracaLot.Rows.Count = 0 Then
                        MsgBox("Aucune information disponible pour ce lot.", MsgBoxStyle.Information)
                    Else
                        EtatTracaLotDataGridView.Focus()
                    End If
                    .EnforceConstraints = True
                End With
                Me.EtatTracaLotBindingSource.ResumeBinding()
            Finally
                Cursor.Current = Cursors.Default
                Me.EtatTracaLotDataGridView.UseWaitCursor = False
            End Try
        End Sub
#End Region

#Region "Page"
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ApplyStyle(Me.EtatTracaLotDataGridView)
            ChargerLots()
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripButton.Click
            ChargerDonnees()
        End Sub
#End Region

#Region "Grid"
        Private Sub EtatTracaLotDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EtatTracaLotDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColControle.Index Then
                Controles.GestionGrilleControle.ClicBouton(Me, Cast(Of DataGridView)(sender), e.RowIndex, e.ColumnIndex)
            End If
        End Sub

        Private Sub EtatTracaLotDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles EtatTracaLotDataGridView.DataBindingComplete
            Controles.GestionGrilleControle.RafraichirIcones(Cast(Of DataGridView)(sender), ColControle.Index, e.ListChangedType, True)
        End Sub

        Private Sub EtatTracaLotDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatTracaLotDataGridView.DoubleClick
            If Me.EtatTracaLotBindingSource.Current Is Nothing Then Exit Sub
            Dim dr As EtatsDataset.EtatTracaLotRow = Cast(Of EtatsDataset.EtatTracaLotRow)(Cast(Of DataRowView)(Me.EtatTracaLotBindingSource.Current).Row)
            If Not dr.IsndevisNull Then
                With New Receptions.FrSaisieBR(CInt(dr.ndevis))
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        ChargerDonnees()
                    End If
                End With
            End If
        End Sub
#End Region

#Region "Boutons"
        Private Sub BtImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImpr.Click
            If Me.EtatsDataset.EtatTracaLot.Count = 0 Then Exit Sub
            Dim titre As String = String.Format("Matières premières utilisées pour la fabrication n°{0}", cbLot.Text)
            EcranCrystal.Apercu("RptEtatTracaLot.rpt", Me.EtatsDataset.EtatTracaLot, titre)
        End Sub
#End Region

    End Class
End Namespace