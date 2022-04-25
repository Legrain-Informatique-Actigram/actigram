Imports ControleTracabilite.Controles
Public Class FrDetailResultat

#Region "Props"
    Public ReadOnly Property CurrentResultat() As ResultatBareme
        Get
            Return CType(Me.ResBaremesBindingSource.Current, ResultatBareme)
        End Get
    End Property

    Private _resultat As ResultatControle
    Public Property Resultat() As ResultatControle
        Get
            Return _resultat
        End Get
        Set(ByVal value As ResultatControle)
            _resultat = value
        End Set
    End Property
#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal resultat As ResultatControle)
        Me.New()
        Me.Resultat = resultat
    End Sub

    Private Sub FrListeControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.ResBaremesDataGridView, True)
        Me.ResultatControleBindingSource.DataSource = Me.Resultat
        Filtrer()
    End Sub

    Private Sub MasquerConformesMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filtrer()
    End Sub

    Private Sub FiltrerEffectuesMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filtrer()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub DefinitionControleDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ResBaremesDataGridView.DataError
        e.ThrowException = False
    End Sub

    Private Sub Filtrer()
        Dim list As List(Of ResultatBareme) = Me.Resultat.ResultatsBaremes
        Me.ResBaremesBindingSource.DataSource = list
    End Sub
End Class
