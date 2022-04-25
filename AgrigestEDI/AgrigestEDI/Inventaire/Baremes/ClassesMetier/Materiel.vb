Namespace Baremes.ClassesMetier
    Public Class Materiel

        Private _ID_MATERIEL As Integer
        Private _LIBELLE_MATERIEL As String
        Private _ID_TYPE_MATERIEL As Nullable(Of Integer)

#Region "Propriétés"
        Public Property ID_MATERIEL() As Integer
            Get
                Return Me._ID_MATERIEL
            End Get
            Set(ByVal value As Integer)
                Me._ID_MATERIEL = value
            End Set
        End Property

        Public Property LIBELLE_MATERIEL() As String
            Get
                Return Me._LIBELLE_MATERIEL
            End Get
            Set(ByVal value As String)
                Me._LIBELLE_MATERIEL = value
            End Set
        End Property

        Public Property ID_TYPE_MATERIEL() As Nullable(Of Integer)
            Get
                Return Me._ID_TYPE_MATERIEL
            End Get
            Set(ByVal value As Nullable(Of Integer))
                Me._ID_TYPE_MATERIEL = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
