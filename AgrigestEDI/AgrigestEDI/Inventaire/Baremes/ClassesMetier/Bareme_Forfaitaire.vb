Namespace Baremes.ClassesMetier
    Public Class Bareme_Forfaitaire

        Private _ID_BAREME_FORFAITAIRE As Integer
        Private _ANNEE_BAREME_FORFAITAIRE As String
        Private _VALEUR_FORFAITAIRE As Nullable(Of Decimal)
        Private _ID_FACON_CULTURALE As Nullable(Of Integer)

#Region "Propriétés"
        Public Property ID_BAREME_FORFAITAIRE() As Integer
            Get
                Return Me._ID_BAREME_FORFAITAIRE
            End Get
            Set(ByVal value As Integer)
                Me._ID_BAREME_FORFAITAIRE = value
            End Set
        End Property

        Public Property ANNEE_BAREME_FORFAITAIRE() As String
            Get
                Return Me._ANNEE_BAREME_FORFAITAIRE
            End Get
            Set(ByVal value As String)
                Me._ANNEE_BAREME_FORFAITAIRE = value
            End Set
        End Property

        Public Property VALEUR_FORFAITAIRE() As Nullable(Of Decimal)
            Get
                Return Me._VALEUR_FORFAITAIRE
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._VALEUR_FORFAITAIRE = value
            End Set
        End Property

        Public Property ID_FACON_CULTURALE() As Nullable(Of Integer)
            Get
                Return Me._ID_FACON_CULTURALE
            End Get
            Set(ByVal value As Nullable(Of Integer))
                Me._ID_FACON_CULTURALE = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
