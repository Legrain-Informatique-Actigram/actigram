Public Class FrParamFab

#Region "Props"
    Private modif As Boolean

    Private _nMvt As Integer
    Public Property nMouvement() As Integer
        Get
            Return _nMvt
        End Get
        Set(ByVal value As Integer)
            _nMvt = value
        End Set
    End Property

    Private _result As Decimal
    Public Property Result() As Decimal
        Get
            Return _result
        End Get
        Set(ByVal value As Decimal)
            _result = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nMouvement As Integer)
        Me.New()
        Me.nMouvement = nMouvement
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        If Me.nMouvement >= 0 Then
            Me.MouvementTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement, Me.nMouvement)
            Me.Mouvement_DetailTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement_Detail, Me.nMouvement)
            ApplyMult()
        End If
    End Sub

    Private Sub ApplyMult()
        Dim mult As Decimal = DecimalParse(Me.TxtCoef.Text).GetValueOrDefault(1)
        Me.AgrifactTracaDataSet.Mouvement_Detail.RejectChanges()
        For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In Me.AgrifactTracaDataSet.Mouvement_Detail
            If Not dr.IsUnite1Null Then dr.Unite1 *= mult
            If Not dr.IsUnite2Null Then dr.Unite2 *= mult
        Next
        Me.FKMouvementDetailMouvementBindingSource.ResetBindings(False)
    End Sub
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtCoef.Text = "1"
        SetChildFormIcon(Me)
        ConfigDecimalControl(Me.TxtCoef)
        ApplyStyle(Me.CompositionProduitDataGridView)
        ChargerDonnees()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.Result = DecimalParse(Me.TxtCoef.Text).GetValueOrDefault(1)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

    Private Sub TxtCoef_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCoef.Validated
        ApplyMult()
    End Sub

End Class