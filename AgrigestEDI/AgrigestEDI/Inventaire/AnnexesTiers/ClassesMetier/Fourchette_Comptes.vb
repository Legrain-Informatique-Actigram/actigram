Namespace AnnexesTiers.ClassesMetier
    Public Class Fourchette_Comptes

        Private _ID_FOURCHETTE_COMPTE As Long
        Private _COMPTE_DEB As String
        Private _COMPTE_FIN As String
        Private _ID_ACTIF_PASSIF As Nullable(Of Long)
        Private _POSITION As Nullable(Of Long)
        Private _EST_DETAILLE As Nullable(Of Boolean)
        Private _ID_TYPE_PLAN_COMPTABLE As Nullable(Of Long)

        'Infos ACTIF_PASSIF
        Private _Actif_Passif As AnnexesTiers.ClassesMetier.Actif_Passif

        'Infos TYPE_PLAN_COMPTABLE
        Private _Type_Plan_Comptable As AnnexesTiers.ClassesMetier.Type_Plan_Comptable

#Region "Propriétés"
        Public Property ID_FOURCHETTE_COMPTE() As Long
            Get
                Return Me._ID_FOURCHETTE_COMPTE
            End Get
            Set(ByVal value As Long)
                Me._ID_FOURCHETTE_COMPTE = value
            End Set
        End Property

        Public Property COMPTE_DEB() As String
            Get
                Return Me._COMPTE_DEB
            End Get
            Set(ByVal value As String)
                Me._COMPTE_DEB = value
            End Set
        End Property

        Public Property COMPTE_FIN() As String
            Get
                Return Me._COMPTE_FIN
            End Get
            Set(ByVal value As String)
                Me._COMPTE_FIN = value
            End Set
        End Property

        Public Property ID_ACTIF_PASSIF() As Nullable(Of Long)
            Get
                Return Me._ID_ACTIF_PASSIF
            End Get
            Set(ByVal value As Nullable(Of Long))
                Me._ID_ACTIF_PASSIF = value
            End Set
        End Property

        Public Property POSITION() As Nullable(Of Long)
            Get
                Return Me._POSITION
            End Get
            Set(ByVal value As Nullable(Of Long))
                Me._POSITION = value
            End Set
        End Property

        Public Property EST_DETAILLE() As Nullable(Of Boolean)
            Get
                Return Me._EST_DETAILLE
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                Me._EST_DETAILLE = value
            End Set
        End Property

        Public Property ID_TYPE_PLAN_COMPTABLE() As Nullable(Of Long)
            Get
                Return Me._ID_TYPE_PLAN_COMPTABLE
            End Get
            Set(ByVal value As Nullable(Of Long))
                Me._ID_TYPE_PLAN_COMPTABLE = value
            End Set
        End Property

        Public Property Actif_Passif() As AnnexesTiers.ClassesMetier.Actif_Passif
            Get
                Return Me._Actif_Passif
            End Get
            Set(ByVal value As AnnexesTiers.ClassesMetier.Actif_Passif)
                Me._Actif_Passif = value
            End Set
        End Property

        Public Property Type_Plan_Comptable() As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Get
                Return Me._Type_Plan_Comptable
            End Get
            Set(ByVal value As AnnexesTiers.ClassesMetier.Type_Plan_Comptable)
                Me._Type_Plan_Comptable = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
