Public Class FrEtatStock

    Private Const PANEL_COLLAPSED As Integer = 36
    Private Const PANEL_EXPANDED As Integer = 71
    Private _panelExpanded As Boolean = False

#Region "Donnnées"
    Private Sub ChargerDonnees()
        Try
            Dim sw As New Stopwatch
            sw.Start()
            Cursor.Current = Cursors.WaitCursor
            Me.EtatStockDataGridView.UseWaitCursor = True
            Application.DoEvents()
            Me.EtatStockBindingSource.SuspendBinding()
            Dim depot As String = Convert.ToString(CbDepot.SelectedValue)
            With Me.StocksDataSet
                .EnforceConstraints = False
                Me.EtatStockTableAdapter.FillEtatStock(.EtatStock, dtpDeb.Value, dtpFin.Value, depot, chkGestionLots.Checked)
                If .EtatStock.Rows.Count = 0 Then
                    MsgBox("Stocks introuvable.", MsgBoxStyle.Information)
                Else
                    EtatStockDataGridView.Focus()
                End If
                '.EnforceConstraints = True
            End With
            Me.EtatStockBindingSource.ResumeBinding()
            Me.NLotDataGridViewTextBoxColumn.Visible = chkGestionLots.Checked
            Me.Depot.Visible = (depot <> "Global")
        Finally
            Cursor.Current = Cursors.Default
            Me.EtatStockDataGridView.UseWaitCursor = False
        End Try
    End Sub
#End Region

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _panelExpanded = True
        BtExpandPanel_Click(Nothing, Nothing)
        SetChildFormIcon(Me)
        CType(BtGo.Image, Bitmap).MakeTransparent(Color.Magenta)
        ApplyStyle(Me.EtatStockDataGridView)

        Me.ListeChoixTableAdapter.FillByNomChoix(Me.StocksDataSet.ListeChoix, StocksDataSetTableAdapters.ListeChoixTA.NomsChoix.ListeDepots)
        Me.StocksDataSet.ListeChoix.AddListeChoixRow("ListeDepots", -2, "Global")
        Me.StocksDataSet.ListeChoix.AddListeChoixRow("ListeDepots", -1, "Tous")
        Me.StocksDataSet.ListeChoix.AcceptChanges()
        Me.ListeChoixBindingSource.Position = 0
        DefinitionDonnees.Instance.Fill(Me.StocksDataSet, "Famille")
        With Me.FamilleBindingSource
            .DataSource = Me.StocksDataSet
            .DataMember = "Famille"
            .Sort = "Famille"
        End With
        FillCb(Me.FamilleBindingSource, CbFamilles, "Famille", "Famille", Nothing, False)
        CbFamilles.Items.Insert(0, New ListboxItem("--Toutes les familles--", Nothing))
        CbFamilles.SelectedIndex = 0

        dtpFin.Value = Now.Date
        dtpDeb.Value = Now.Date.AddMonths(-1)
        FilterChanged()
    End Sub

#Region "Toolbar"
    Private Sub EtatDesStocksParFamilleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatDesStocksParFamilleToolStripMenuItem.Click
        ImprimerStocks("RptEtatStock2.rpt")
    End Sub

    Private Sub EtatDesStocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EtatDesStocksToolStripMenuItem.Click, TbImpr.ButtonClick
        ImprimerStocks("RptEtatStock.rpt")
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub SeulementProduitsEnAlerteToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeulementProduitsEnAlerteToolStripMenuItem.CheckedChanged
        FilterChanged()
    End Sub

    Private Sub AfficherProduitsFinisToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FilterChanged()
    End Sub

    Private Sub AfficherMatièresPremièresToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FilterChanged()
    End Sub

    Private Sub CbFamilles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbFamilles.SelectedIndexChanged
        FilterChanged()
    End Sub

    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        FilterChanged()
    End Sub

    Private Sub TbClearRech_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClearRech.Click
        TxRech.Text = ""
        TxRech.Focus()
    End Sub

    Private Sub AfficherUnité1ToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AfficherU1ToolStripMenuItem.CheckedChanged, AfficherU2ToolStripMenuItem.CheckedChanged
        'U1
        Me.LibUnite1DataGridViewTextBoxColumn.Visible = AfficherU1ToolStripMenuItem.Checked
        Me.DepartDataGridViewTextBoxColumn.Visible = AfficherU1ToolStripMenuItem.Checked
        Me.EntréeDataGridViewTextBoxColumn.Visible = AfficherU1ToolStripMenuItem.Checked
        Me.SortieDataGridViewTextBoxColumn.Visible = AfficherU1ToolStripMenuItem.Checked
        Me.StockActuel.Visible = AfficherU1ToolStripMenuItem.Checked
        'U2
        Me.LibUnite2DataGridViewTextBoxColumn.Visible = AfficherU2ToolStripMenuItem.Checked
        Me.DepartU2DataGridViewTextBoxColumn.Visible = AfficherU2ToolStripMenuItem.Checked
        Me.EntréeU2DataGridViewTextBoxColumn.Visible = AfficherU2ToolStripMenuItem.Checked
        Me.SortieU2DataGridViewTextBoxColumn.Visible = AfficherU2ToolStripMenuItem.Checked
        Me.StockActuelU2.Visible = AfficherU2ToolStripMenuItem.Checked
    End Sub
#End Region

    Private Sub BtGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGo.Click
        ChargerDonnees()
    End Sub

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

    Private Sub FilterChanged()
        Dim flt As String = "(1=1)"
        If SeulementProduitsEnAlerteToolStripMenuItem.Checked Then
            flt &= " AND Attention=False"
        End If
        If CbFamilles.SelectedIndex >= 0 Then
            If Cast(Of ListboxItem)(CbFamilles.SelectedItem).Value IsNot Nothing Then
                flt &= FormatExpression(" AND Famille={0}", Cast(Of DataRow)(Cast(Of ListboxItem)(CbFamilles.SelectedItem).Value)("Famille"))
            End If
        End If
        Dim q As String = TxRech.Text.Trim
        If q.Length > 0 Then
            flt &= FormatExpression(" AND (CodeProduit like {0} OR Famille like {0} OR Libelle like {0} OR nLot like {0})", "%" & q & "%")
        End If
        Cursor.Current = Cursors.WaitCursor
        Me.EtatStockBindingSource.Filter = flt
        Me.TbClearRech.Visible = q.Length > 0
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ImprimerStocks(ByVal etat As String)
        Dim t As String
        Select Case CbDepot.Text
            Case "Global"
                t = " global"
            Case "Tous"
                t = " détaillé"
            Case Else
                t = " du dépot " & CbDepot.Text
        End Select
        Dim titre As String = String.Format("Etat des stocks{0} du {1:dd/MM/yyyy} au {2:dd/MM/yyyy}", t, dtpDeb.Value, dtpFin.Value)
        Dim filter As String = Me.EtatStockBindingSource.Filter
        Dim ds As New StocksDataSet
        ds.EnforceConstraints = False
        ds.Merge(Me.StocksDataSet.EtatStock.Select(filter))
        Dim frFusion As GRC.FrFusion = GestionImpression.TrouverRapport(ds, etat)
        frFusion.Parametres.EnTete = titre
        frFusion.Show(Me)
    End Sub


    Private Sub EtatStockDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles EtatStockDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In EtatStockDataGridView.Rows
                If r.DataBoundItem IsNot Nothing Then
                    Dim drStock As StocksDataSet.EtatStockRow = Cast(Of StocksDataSet.EtatStockRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                    Dim c As DataGridViewImageCell = Cast(Of DataGridViewImageCell)(r.Cells(ColAttention.Index))
                    If drStock.IsAttentionNull OrElse drStock.Attention Then
                        r.DefaultCellStyle.ForeColor = EtatStockDataGridView.ForeColor
                        c.Value = My.Resources.vide
                    Else
                        r.DefaultCellStyle.ForeColor = Color.Red
                        c.Value = My.Resources.warning16
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub EtatStockDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EtatStockDataGridView.CellDoubleClick
        'Double clic sur une ligne => Ouvrir le détail du calcul de l'inventaire
        Dim drv As DataRowView = Cast(Of DataRowView)(Me.EtatStockBindingSource.Current)
        If drv Is Nothing Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Try
            Application.DoEvents()
            Dim codeProduit As String = Convert.ToString(drv("CodeProduit"))
            Dim depot As String
            If CbDepot.Text = "Global" Then
                depot = "1=1"
            ElseIf IsDBNull(drv("Depot")) Then
                depot = "Depot IS NULL"
            Else
                depot = String.Format("Depot='{0}'", Convert.ToString(drv("Depot")).Replace("'", "''"))
            End If
            Dim nLot As String
            If Not chkGestionLots.Checked Then
                nLot = "1=1"
            ElseIf IsDBNull(drv("NLot")) Then
                nLot = "NLot IS NULL"
            Else
                nLot = String.Format("NLot='{0}'", Convert.ToString(drv("NLot")).Replace("'", "''"))
            End If
            Dim u1 As String = Convert.ToString(drv("LibUnite1"))
            Dim u2 As String = Convert.ToString(drv("LibUnite2"))
            Dim filter As String = String.Format("CodeProduit='{0}' AND {1} AND {2} AND LibUnite1='{3}' AND LibUnite2='{4}'", _
                                    codeProduit.Replace("'", "''"), nLot, depot, u1.Replace("'", "''"), u2.Replace("'", "''"))

            Dim ds1 As New DataSet
            Using s As New SqlProxy
                Dim sql As String = String.Format("EXEC CalculEtatStock '{0:dd/MM/yyyy}','{1:dd/MM/yyyy}','{2}',{3},@debug=1", dtpDeb.Value, dtpFin.Value, CbDepot.Text, IIf(chkGestionLots.Checked, 1, 0))
                s.Fill(ds1, sql, "EtatStockDetail", True)
            End Using

            Dim myDs As New DataSet
            myDs.Tables.Add(ds1.Tables("EtatStockDetail").Clone)
            myDs.Merge(ds1.Tables("EtatStockDetail").Select(filter))
            Dim frFusion As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptDetailStock.rpt")
            frFusion.Show(Me)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtExpandPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExpandPanel.Click
        If _panelExpanded Then
            _panelExpanded = False
            Me.GradientPanel1.Height = PANEL_COLLAPSED
            Me.BtExpandPanel.Image = My.Resources.Expand_large
            CType(Me.BtExpandPanel.Image, Bitmap).MakeTransparent(Color.Magenta)
        Else
            _panelExpanded = True
            Me.GradientPanel1.Height = PANEL_EXPANDED
            Me.BtExpandPanel.Image = My.Resources.Collapse_large
            CType(Me.BtExpandPanel.Image, Bitmap).MakeTransparent(Color.Magenta)
        End If
    End Sub
End Class