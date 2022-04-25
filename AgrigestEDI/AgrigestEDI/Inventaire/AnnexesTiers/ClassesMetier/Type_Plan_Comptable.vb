Namespace AnnexesTiers.ClassesMetier
    Public Class Type_Plan_Comptable

        Private _ID_TYPE_PLAN_COMPTABLE As Long
        Private _CODE_TYPE_PLAN_COMPTABLE As String
        Private _LIBELLE_TYPE_PLAN_COMPTABLE As String

#Region "Propriétés"
        Public Property ID_TYPE_PLAN_COMPTABLE() As Long
            Get
                Return Me._ID_TYPE_PLAN_COMPTABLE
            End Get
            Set(ByVal value As Long)
                Me._ID_TYPE_PLAN_COMPTABLE = value
            End Set
        End Property

        Public Property CODE_TYPE_PLAN_COMPTABLE() As String
            Get
                Return Me._CODE_TYPE_PLAN_COMPTABLE
            End Get
            Set(ByVal value As String)
                Me._CODE_TYPE_PLAN_COMPTABLE = value
            End Set
        End Property

        Public Property LIBELLE_TYPE_PLAN_COMPTABLE() As String
            Get
                Return Me._LIBELLE_TYPE_PLAN_COMPTABLE
            End Get
            Set(ByVal value As String)
                Me._LIBELLE_TYPE_PLAN_COMPTABLE = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
