Namespace Baremes.ClassesMetier
    Public Class Type_Materiel

        Private _ID_TYPE_MATERIEL As Integer
        Private _CODE_TYPE_MATERIEL As String
        Private _LIBELLE_TYPE_MATERIEL As String

#Region "Propriétés"
        Public Property ID_TYPE_MATERIEL() As Integer
            Get
                Return Me._ID_TYPE_MATERIEL
            End Get
            Set(ByVal value As Integer)
                Me._ID_TYPE_MATERIEL = value
            End Set
        End Property

        Public Property CODE_TYPE_MATERIEL() As String
            Get
                Return Me._CODE_TYPE_MATERIEL
            End Get
            Set(ByVal value As String)
                Me._CODE_TYPE_MATERIEL = value
            End Set
        End Property

        Public Property LIBELLE_TYPE_MATERIEL() As String
            Get
                Return Me._LIBELLE_TYPE_MATERIEL
            End Get
            Set(ByVal value As String)
                Me._LIBELLE_TYPE_MATERIEL = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
