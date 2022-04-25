Public Class FrCodeBarreInventaire

    Public Event CurrentChanged(ByVal sender As Object, ByVal current As Object)

#Region " Props "
    Private _ds As StocksDataSet
    Public Property Datasource() As StocksDataSet
        Get
            Return _ds
        End Get
        Set(ByVal value As StocksDataSet)
            _ds = value
            With Me.InventaireBindingSource
                .DataSource = _ds
                .DataMember = "Inventaire"
            End With
        End Set
    End Property

    Private _gestionLots As Boolean
    Public Property GestionLots() As Boolean
        Get
            Return _gestionLots
        End Get
        Set(ByVal value As Boolean)
            _gestionLots = value
        End Set
    End Property
#End Region

#Region " Ctor "
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As StocksDataSet)
        Me.New()
        Me.Datasource = ds
    End Sub
#End Region

#Region "Page"
    Private Sub FrCodeBarre_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            With Me.InventaireBindingSource
                If .Position >= 0 Then
                    If Cast(Of DataRowView)(.Current).IsEdit Or Cast(Of DataRowView)(.Current).IsNew Then
                        If MsgBox("Valider le produit en cours ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            .EndEdit()
                        Else
                            .CancelEdit()
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub FrCodeBarre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigNumericControl(Me.TxCodeBarre)
        ConfigDecimalControl(Me.Unite1TextBox, 3)
        ConfigDecimalControl(Me.Unite2TextBox, 3)
        Me.TxCodeBarre.Text = ""
        Me.InventaireBindingSource.Filter = "false" '.Position = -1
        Me.TxCodeBarre.Focus()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        With Me.InventaireBindingSource
            If .Position >= 0 Then
                If Cast(Of DataRowView)(.Current).IsEdit Or Cast(Of DataRowView)(.Current).IsNew Then
                    .EndEdit()
                End If
                .Filter = "false"
                Me.TxCodeBarre.Focus()
            End If
        End With
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFermer.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Tx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TxCodeBarre.KeyPress, Unite1TextBox.KeyPress, Unite2TextBox.KeyPress
        If e.KeyChar = vbCr Then
            Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxCodeBarre_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxCodeBarre.Validating
        If TxCodeBarre.Text.Length > 0 And TxCodeBarre.Text.Length < 12 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxCodeBarre_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxCodeBarre.Validated
        If TxCodeBarre.Text.Length > 0 Then
            Dim cb As CodeBarre = CodeBarre.Parse(TxCodeBarre.Text)
            If cb Is Nothing Then
                Me.InventaireBindingSource.Filter = "false"
            Else
                Me.InventaireBindingSource.Filter = ""
                Dim filter As String
                If Me.GestionLots Then
                    filter = String.Format("CodeProduit='{0}' AND (nLot='{1}' OR nLot is null)", cb.CodeProduit.Replace("'", "''"), cb.NLot.Replace("'", "''"))
                Else
                    filter = String.Format("CodeProduit='{0}'", cb.CodeProduit.Replace("'", "''"))
                End If
                Dim drInv As StocksDataSet.InventaireRow = SelectSingleRow(Of StocksDataSet.InventaireRow)(Me.Datasource.Inventaire, filter, "nLot, QteU1 desc")
                If drInv IsNot Nothing Then
                    With Me.InventaireBindingSource
                        Dim i As Integer
                        For i = 0 To Me.InventaireBindingSource.Count
                            If Cast(Of DataRowView)(Me.InventaireBindingSource.Item(i)).Row Is drInv Then Exit For
                        Next
                        If i = Me.InventaireBindingSource.Count Then Exit Sub
                        .Position = i
                        .ResetCurrentItem()
                        Me.Unite1TextBox.Enabled = Me.LibUnite1Label1.Text.Length > 0
                        Me.Unite2TextBox.Enabled = Me.LibUnite2Label1.Text.Length > 0
                    End With
                End If
                Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
                Me.TxCodeBarre.Text = ""
            End If
        End If
    End Sub

    Private Sub InventaireBindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InventaireBindingSource.PositionChanged
        If Me.InventaireBindingSource.Position < 0 Then
            Me.gbProduit.Enabled = False
        Else
            Me.gbProduit.Enabled = True
            Me.Unite1TextBox.Enabled = Me.LibUnite1Label1.Text.Length > 0
            Me.Unite2TextBox.Enabled = Me.LibUnite2Label1.Text.Length > 0
        End If
        RaiseEvent CurrentChanged(Me, Me.InventaireBindingSource.Current)
    End Sub

End Class