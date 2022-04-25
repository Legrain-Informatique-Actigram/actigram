Public Class FrEditLigne


    Private _datarow As SvcAgrifact.DsPrepaCommande.BL_DetailRow
    Public Property Row() As SvcAgrifact.DsPrepaCommande.BL_DetailRow
        Get
            Return _datarow
        End Get
        Set(ByVal value As SvcAgrifact.DsPrepaCommande.BL_DetailRow)
            _datarow = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dr As SvcAgrifact.DsPrepaCommande.BL_DetailRow)
        Me.New()
        Me.Row = dr
    End Sub

    Private Sub FrEditPesee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigDecimalControl(Me.TxQte, 3)
        If Me.Row IsNot Nothing Then
            Dim ds As SvcAgrifact.DsPrepaCommande = CType(Me.Row.Table.DataSet.Clone, SvcAgrifact.DsPrepaCommande)
            With ds
                .BL_Detail.ImportRow(Me.Row)
                '.Produit.ImportRow(Me.Row.ProduitRow)
                .AcceptChanges()
                Me.DetailCommandeBindingSource.DataSource = .BL_Detail.Rows(0)
            End With
            Me.TxNLot.Focus()
            Me.TxNLot.SelectAll()
        End If
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If Me.DetailCommandeBindingSource.Position > -1 Then Me.DetailCommandeBindingSource.EndEdit()
        If e.Button Is Me.TbSave Then
            If Me.DetailCommandeBindingSource.Position > -1 Then
                Dim dr As SvcAgrifact.DsPrepaCommande.BL_DetailRow = CType(Me.DetailCommandeBindingSource.DataSource, SvcAgrifact.DsPrepaCommande.BL_DetailRow)
                If dr.Table.DataSet.HasChanges Then
                    Me.Row.NLot = dr.NLot
                    Me.Row.Unite1 = dr.Unite1
                End If
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf e.Button Is Me.TbFermer Then
            If CheckModif() Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Function CheckModif() As Boolean
        If Me.DetailCommandeBindingSource.DataSource IsNot Nothing Then
            Dim dr As SvcAgrifact.DsPrepaCommande.BL_DetailRow = CType(Me.DetailCommandeBindingSource.DataSource, SvcAgrifact.DsPrepaCommande.BL_DetailRow)
            If dr.Table.DataSet.HasChanges Then
                If MsgBox("Voulez-vous annuler la modification ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub TxQte_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxQte.GotFocus, TxNLot.GotFocus
        Me.ip.Enabled = True
    End Sub

    Private Sub TxQte_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxQte.LostFocus, TxNLot.LostFocus
        Me.ip.Enabled = False
    End Sub
End Class