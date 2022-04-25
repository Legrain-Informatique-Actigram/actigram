Public Class FrRechLot

#Region "Props"

    Private _code As String
    Public Property CodeProduit() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property

    Private _typeLot As String
    Public Property TypeLot() As String
        Get
            Return _typeLot
        End Get
        Set(ByVal value As String)
            _typeLot = value
        End Set
    End Property


    Private _nMvt As Integer = -1
    Public Property ExcludedNMvt() As Integer
        Get
            Return _nMvt
        End Get
        Set(ByVal value As Integer)
            _nMvt = value
        End Set
    End Property


    Private ReadOnly Property CurrentLotsProduitRow() As StocksDataSet.LotsProduitsRow
        Get
            If Me.LotsProduitsBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.LotsProduitsBindingSource.Current, DataRowView).Row, StocksDataSet.LotsProduitsRow)
            End If
        End Get
    End Property

    Private _result As String
    Public ReadOnly Property Result() As String
        Get
            Return _result
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal code As String)
        Me.New()
        Me.CodeProduit = code
    End Sub
#End Region

#Region "Donnnées"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            With Me.StocksDataSet
                .EnforceConstraints = False
                .Clear()
                If String.IsNullOrEmpty(Me.CodeProduit) Then
                    Me.LotsProduitsTA.Fill(Me.StocksDataSet.LotsProduits)
                Else
                    Me.LotsProduitsTA.FillByCodeProduit(Me.StocksDataSet.LotsProduits, Me.CodeProduit, Me.ExcludedNMvt)
                End If
                .EnforceConstraints = True
            End With
            Filtrer()
        Finally
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.LotsDataGridView)
        ChargerDonnees()
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.LotsProduitsBindingSource.Count > 0 Then
            Me.TxRech.Control.Select()
            Me.TxRech.SelectAll()
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChoisirLot()
        If Me.LotsProduitsBindingSource.Current Is Nothing Then Exit Sub
        Me._result = Me.CurrentLotsProduitRow.nlot
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Filtrer()
        Dim flt As String = ""
        If Not String.IsNullOrEmpty(Me.TypeLot) Then
            flt = String.Format("tp='{}'", Me.TypeLot)
        End If
        If TxRech.Text.Trim.Length > 0 Then
            If flt.Length > 0 Then flt &= " AND "
            flt &= String.Format("(nlot like {0} OR tp like {0} OR description like {0})", String.Format("'%{0}%'", Me.TxRech.Text.Trim.Replace("'", "''")))
        End If
        Me.LotsProduitsBindingSource.Filter = flt
    End Sub
#End Region

    Private Sub TxRech_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRech.KeyPress
        If e.KeyChar = vbCr Then
            If Me.LotsProduitsBindingSource.Count = 1 Then
                ChoisirLot()
                e.Handled = True
            ElseIf Me.LotsProduitsBindingSource.Count > 1 Then
                Me.LotsDataGridView.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        Filtrer()
    End Sub

    Private Sub FrRechLot_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotsDataGridView.DoubleClick
        ChoisirLot()
    End Sub

    Private Sub ProduitDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LotsDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChoisirLot()
            e.Handled = True
        End If
    End Sub
End Class