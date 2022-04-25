Namespace Etats
    Public Class FrEtatTracaMP

        Private loading As Boolean = True

#Region "Donnnées"
        Private Sub ChargerProduits()
            Me.ProduitTableAdapter.FillMP(Me.AgrifactTracaDataSet.Produit, False)
        End Sub

        Private Sub ProduitBindingSource_ListChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles ProduitBindingSource.ListChanged
            If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
                'legrain le 4/9/2013, ajout du tri
                ProduitBindingSource.Sort = "CodeProduit ASC"
                FillCb(ProduitBindingSource, cbMP, "CodeProduit", "CodeProduit", Nothing, True)
            End If
        End Sub

        Private Sub ChargerDonnees()
            If cbMP.SelectedIndex < 0 Then Exit Sub
            Try
                Cursor.Current = Cursors.WaitCursor
                Me.EtatTracaMPDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Me.EtatTracaMPBindingSource.SuspendBinding()
                With Me.EtatsDataset
                    .EnforceConstraints = False
                    Me.EtatTracaMPTableAdapter.Fill(.EtatTracaMP, cbMP.Text)
                    If .EtatTracaMP.Rows.Count = 0 Then
                        MsgBox("Aucune fabrication enregistrée pour ce produit.", MsgBoxStyle.Information)
                    Else
                        EtatTracaMPDataGridView.Focus()
                    End If
                    .EnforceConstraints = True
                End With
                Me.EtatTracaMPBindingSource.ResumeBinding()
                FilterChanged(Nothing, Nothing)
            Finally
                Cursor.Current = Cursors.Default
                Me.EtatTracaMPDataGridView.UseWaitCursor = False
            End Try
        End Sub
#End Region

#Region "Page"
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            loading = True
            Me.EntrepriseTableAdapter.FillFournisseurs(Me.AgrifactTracaDataSet.Entreprise, False)
            Me.CbFournisseur.SelectedItem = Nothing
            SetChildFormIcon(Me)
            ApplyStyle(Me.EtatTracaMPDataGridView)

            ChkFourn.Checked = False
            CbFournisseur.Enabled = False

            Dim demain As Date = Now.Date.AddDays(1)
            dtpFin.MaxDate = demain
            dtpDeb.MaxDate = demain
            dtpFin.Value = demain
            dtpDeb.Value = dtpFin.Value.AddDays(-My.Settings.PeriodeHisto)

            ChargerProduits()
            loading = False
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
        Private Sub EtatTracaMPDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EtatTracaMPDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColControle.Index Then
                Controles.GestionGrilleControle.ClicBouton(Me, Cast(Of DataGridView)(sender), e.RowIndex, e.ColumnIndex)
            End If
        End Sub

        Private Sub EtatTracaMPDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles EtatTracaMPDataGridView.DataBindingComplete
            Controles.GestionGrilleControle.RafraichirIcones(Cast(Of DataGridView)(sender), ColControle.Index, e.ListChangedType, True)
        End Sub

        Private Sub EtatTracaMPDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatTracaMPDataGridView.DoubleClick
            If Me.EtatTracaMPBindingSource.Current Is Nothing Then Exit Sub
            Dim dr As EtatsDataset.EtatTracaMPRow = Cast(Of EtatsDataset.EtatTracaMPRow)(Cast(Of DataRowView)(Me.EtatTracaMPBindingSource.Current).Row)
            If Not dr.IsndevisNull Then
                With New Receptions.FrSaisieBR(CInt(dr.ndevis))
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        ChargerDonnees()
                    End If
                End With
            End If
        End Sub
#End Region

#Region "Filtrage"
        Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
            Me.SplitContainer1.Panel2Collapsed = Not Me.TbFilter.Checked
        End Sub

        Private Sub dtpDeb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles dtpDeb.Validating, dtpFin.Validating
            e.Cancel = dtpDeb.Value > dtpFin.Value
        End Sub

        Private Sub FilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CbFournisseur.SelectedIndexChanged, dtpDeb.ValueChanged, dtpFin.ValueChanged
            If Not loading Then
                Dim flt As String = ""
                If ChkFourn.Checked And CbFournisseur.SelectedItem IsNot Nothing Then
                    flt &= String.Format("nEntreprise={0} AND ", CbFournisseur.SelectedValue)
                End If
                flt &= String.Format("DateFacture>='{0:dd/MM/yyyy}' AND DateFacture<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.EtatTracaMPBindingSource.Filter = flt
            End If
        End Sub

        Private Sub ChkFourn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourn.CheckedChanged
            With CbFournisseur
                If ChkFourn.Checked Then
                    .Enabled = True
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                Else
                    .Enabled = False
                    .SelectedItem = Nothing
                End If
            End With
        End Sub
#End Region

#Region "Boutons"
        Private Sub BtImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImpr.Click
            If Me.EtatsDataset.EtatTracaMP.Count = 0 Then Exit Sub
            Dim titre As String = String.Format("Tracabilité pour la matière première {0}", cbMP.Text)
            If ChkFourn.Checked And CbFournisseur.SelectedItem IsNot Nothing Then
                titre &= String.Format(vbCrLf & "venant du fournisseur {0}", CbFournisseur.Text)
            End If
            titre &= String.Format(vbCrLf & "du {0:dd/MM/yyyy} au {1:dd/MM/yyyy}", dtpDeb.Value.Date, dtpFin.Value.Date)
            EcranCrystal.Apercu("RptEtatTracaMP.rpt", Me.EtatTracaMPBindingSource.List, titre)
        End Sub
#End Region

    End Class
End Namespace