Public Class FrRechProduits
    Implements IArgumentable

#Region "Props"
    Private _arguments As String
    Public Property Arguments() As String Implements IArgumentable.Arguments
        Get
            Return _arguments
        End Get
        Set(ByVal value As String)
            _arguments = value
            If value IsNot Nothing AndAlso value.Length > 0 Then
                Me.Filtre = EnumParse(Of AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)(value)
            End If
        End Set
    End Property

    Private _filtreProduits As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.Tous
    Public Property Filtre() As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits
        Get
            Return _filtreProduits
        End Get
        Set(ByVal value As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)
            _filtreProduits = value
        End Set
    End Property

    Private ReadOnly Property CurrentProduitRow() As AgrifactTracaDataSet.ProduitRow
        Get
            If Me.ProduitBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.ProduitBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ProduitRow)
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

    Public Sub New(ByVal filtre As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)
        Me.New()
        Me.Filtre = filtre
    End Sub
#End Region

#Region "Donnnées"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            With Me.AgrifactTracaDataSet
                .EnforceConstraints = False
                .Clear()
                Me.FamilleTableAdapter.Fill(.Famille)
                Me.ProduitTableAdapter.Fill(.Produit, Me.Filtre, True)
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
        ApplyStyle(Me.ProduitDataGridView)
        ChargerDonnees()
    End Sub

    Private Sub FrRechProduits_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.TxRech.Control.Select()
        Me.TxRech.SelectAll()
    End Sub
#End Region

#Region "Boutons"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChoisirProduit()
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        Me._result = Me.CurrentProduitRow.CodeProduit
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Filtrer()
        If TxRech.Text.Trim.Length = 0 Then
            Me.ProduitBindingSource.Filter = "inactif=false"
        Else
            Me.ProduitBindingSource.Filter = String.Format("inactif=false AND (CodeProduit like {0} OR Libelle like {0} OR NomFamille like {0})", String.Format("'%{0}%'", Me.TxRech.Text.Trim.Replace("'", "''")))
        End If
    End Sub
#End Region

    Private Sub TxRech_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxRech.KeyPress
        If e.KeyChar = vbCr Then
            If Me.ProduitBindingSource.Count = 1 Then
                ChoisirProduit()
                e.Handled = True
            ElseIf Me.ProduitBindingSource.Count > 1 Then
                Me.ProduitDataGridView.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        Filtrer()
    End Sub

    Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitDataGridView.DoubleClick
        ChoisirProduit()
    End Sub

    Private Sub ProduitDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProduitDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChoisirProduit()
            e.Handled = True
        End If
    End Sub

    Private Sub FrRechProduits_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class