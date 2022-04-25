Namespace Inventaire.ClassesMetier
    Public Class InventaireMateriel

        Private _ID_InventaireMateriel As Integer
        Private _LibelleMateriel As String
        Private _DDossier As String
        Private _ID_MATERIEL As Nullable(Of Integer)

#Region "Propriétés"
        Public Property ID_InventaireMateriel() As Integer
            Get
                Return Me._ID_InventaireMateriel
            End Get
            Set(ByVal value As Integer)
                Me._ID_InventaireMateriel = value
            End Set
        End Property

        Public Property LibelleMateriel() As String
            Get
                Return Me._LibelleMateriel
            End Get
            Set(ByVal value As String)
                Me._LibelleMateriel = value
            End Set
        End Property

        Public Property DDossier() As String
            Get
                Return Me._DDossier
            End Get
            Set(ByVal value As String)
                Me._DDossier = value
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
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
