Namespace AnnexesTiers.ClassesMetier
    Public Class Actif_Passif

        Private _ID_ACTIF_PASSIF As Long
        Private _CODE_ACTIF_PASSIF As String
        Private _LIBELLE_ACTIF_PASSIF As String

#Region "Propriétés"
        Public Property ID_ACTIF_PASSIF() As Long
            Get
                Return Me._ID_ACTIF_PASSIF
            End Get
            Set(ByVal value As Long)
                Me._ID_ACTIF_PASSIF = value
            End Set
        End Property

        Public Property CODE_ACTIF_PASSIF() As String
            Get
                Return Me._CODE_ACTIF_PASSIF
            End Get
            Set(ByVal value As String)
                Me._CODE_ACTIF_PASSIF = value
            End Set
        End Property

        Public Property LIBELLE_ACTIF_PASSIF() As String
            Get
                Return Me._LIBELLE_ACTIF_PASSIF
            End Get
            Set(ByVal value As String)
                Me._LIBELLE_ACTIF_PASSIF = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
