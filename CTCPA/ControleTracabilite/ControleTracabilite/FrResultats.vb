Imports ControleTracabilite.Controles
Public Class FrResultats

#Region "Props"
    Public ReadOnly Property CurrentResultat() As ResultatControle
        Get
            Return CType(Me.ResultatsBindingSource.Current, ResultatControle)
        End Get
    End Property

    Private _resultats As List(Of ResultatControle)
    Public Property Resultats() As List(Of ResultatControle)
        Get
            Return _resultats
        End Get
        Set(ByVal value As List(Of ResultatControle))
            _resultats = value
        End Set
    End Property
#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal resultats As List(Of ResultatControle))
        Me.New()
        Me.Resultats = resultats
    End Sub

    Private Sub FrListeControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.ResultatsDataGridView, True)
        Filtrer()
    End Sub

    Private Sub MasquerConformesMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasquerConformesMenuItem.CheckedChanged
        Filtrer()
    End Sub

    Private Sub FiltrerEffectuesMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrerEffectuesMenuItem.CheckedChanged
        Filtrer()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub DataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ResultatsDataGridView.DataError
        e.ThrowException = False
    End Sub

    Private Sub Filtrer()
        Dim list As List(Of ResultatControle) = Me.Resultats
        If Me.FiltrerEffectuesMenuItem.Checked Then
            list = Me.Resultats.FindAll(AddressOf ResultatControle.IsEffectue)
        End If
        If Me.MasquerConformesMenuItem.Checked Then
            list = Me.Resultats.FindAll(AddressOf ResultatControle.IsNonConforme)
        End If
        Me.ResultatsBindingSource.DataSource = list
    End Sub

    Private Sub DataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ResultatsDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If Me.CurrentResultat IsNot Nothing Then
            Using fr As New FrDetailResultat(Me.CurrentResultat)
                fr.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        If MsgBox("Voulez-vous effacer ces résultats de contrôle ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim res As ResultatControle = Me.CurrentResultat
            ResultatControle.Effacer(res.CodeProduit, res.nLot)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Me.Close()
        End If
    End Sub
End Class
