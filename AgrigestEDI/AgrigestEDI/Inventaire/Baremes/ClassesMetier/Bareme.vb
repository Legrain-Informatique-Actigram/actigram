Namespace Baremes.ClassesMetier
    Public Class Bareme

        Private _ID_BAREME As Integer
        Private _ANNEE_BAREME As String
        Private _COUT_TOTAL_PAR_HEURE As Nullable(Of Decimal)
        Private _ID_MATERIEL As Nullable(Of Integer)
        Private _INFO_COMPL As String

#Region "Propriétés"
        Public Property ID_BAREME() As Integer
            Get
                Return Me._ID_BAREME
            End Get
            Set(ByVal value As Integer)
                Me._ID_BAREME = value
            End Set
        End Property

        Public Property ANNEE_BAREME() As String
            Get
                Return Me._ANNEE_BAREME
            End Get
            Set(ByVal value As String)
                Me._ANNEE_BAREME = value
            End Set
        End Property

        Public Property COUT_TOTAL_PAR_HEURE() As Nullable(Of Decimal)
            Get
                Return Me._COUT_TOTAL_PAR_HEURE
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._COUT_TOTAL_PAR_HEURE = value
            End Set
        End Property

        Public Property ID_MATERIEL() As Nullable(Of Integer)
            Get
                Return Me._ID_MATERIEL
            End Get
            Set(ByVal value As Nullable(Of Integer))
                Me._ID_MATERIEL = value
            End Set
        End Property

        Public Property INFO_COMPL() As String
            Get
                Return Me._INFO_COMPL
            End Get
            Set(ByVal value As String)
                Me._INFO_COMPL = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
