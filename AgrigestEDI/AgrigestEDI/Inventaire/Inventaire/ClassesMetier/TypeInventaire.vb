Imports System.Data.OleDb

Namespace Inventaire.ClassesMetier
    Public Class TypeInventaire

        Private _ID_TypeInventaire As Integer
        Private _CodeTypeInventaire As String
        Private _LibelleTypeInventaire As String
        Private _OrdreTypeInventaire As Nullable(Of Integer)

#Region "Propriétés"
        Public Property ID_TypeInventaire() As Integer
            Get
                Return Me._ID_TypeInventaire
            End Get
            Set(ByVal value As Integer)
                Me._ID_TypeInventaire = value
            End Set
        End Property

        Public Property CodeTypeInventaire() As String
            Get
                Return Me._CodeTypeInventaire
            End Get
            Set(ByVal value As String)
                Me._CodeTypeInventaire = value
            End Set
        End Property

        Public Property LibelleTypeInventaire() As String
            Get
                Return Me._LibelleTypeInventaire
            End Get
            Set(ByVal value As String)
                Me._LibelleTypeInventaire = value
            End Set
        End Property

        Public Property OrdreTypeInventaire() As Nullable(Of Integer)
            Get
                Return Me._OrdreTypeInventaire
            End Get
            Set(ByVal value As Nullable(Of Integer))
                Me._OrdreTypeInventaire = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
