Namespace Stocks
    Public Class FrOptionsInventaire

#Region " Props "

        Public Property DateInventaire() As Date
            Get
                Return Me.DtpDateInv.Value.Date
            End Get
            Set(ByVal value As Date)
                Me.DtpDateInv.Value = value.Date
            End Set
        End Property

        Public Property Depot() As String
            Get
                Return Me.CbDepot.Text
            End Get
            Set(ByVal value As String)
                Me.CbDepot.SelectedValue = value
            End Set
        End Property

        Public Property GestionLot() As Boolean
            Get
                Return Me.ChkGestionLots.Checked
            End Get
            Set(ByVal value As Boolean)
                Me.ChkGestionLots.Checked = value
            End Set
        End Property

#End Region

#Region "Page"
        Private Sub FrCodeBarre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.DtpDateInv.Value = Now.Date
            Me.ListeChoixTableAdapter.FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeDepots)
        End Sub
#End Region

    End Class
End Namespace