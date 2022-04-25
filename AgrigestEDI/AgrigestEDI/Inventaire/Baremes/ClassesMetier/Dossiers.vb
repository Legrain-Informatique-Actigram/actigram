Imports System.Data.OleDb

Namespace Baremes.ClassesMetier
    Public Class Dossiers

        Private _DDossier As String
        Private _DExpl As String
        Private _DDtDebEx As Nullable(Of Date)
        Private _DDtFinEx As Nullable(Of Date)
        Private _DDtArrete As Nullable(Of Date)
        Private _DBqCpt As String
        Private _DBqVal As Nullable(Of Decimal)
        Private _DMethodeInventaire As String
        Private _DDtClotureTVA As Nullable(Of Date)

#Region "Propriétés"
        Public Property DDossier() As String
            Get
                Return Me._DDossier
            End Get
            Set(ByVal value As String)
                Me._DDossier = value
            End Set
        End Property

        Public Property DExpl() As String
            Get
                Return Me._DExpl
            End Get
            Set(ByVal value As String)
                Me._DExpl = value
            End Set
        End Property

        Public Property DDtDebEx() As Nullable(Of Date)
            Get
                Return Me._DDtDebEx
            End Get
            Set(ByVal value As Nullable(Of Date))
                Me._DDtDebEx = value
            End Set
        End Property

        Public Property DDtFinEx() As Nullable(Of Date)
            Get
                Return Me._DDtFinEx
            End Get
            Set(ByVal value As Nullable(Of Date))
                Me._DDtFinEx = value
            End Set
        End Property

        Public Property DDtArrete() As Nullable(Of Date)
            Get
                Return Me._DDtArrete
            End Get
            Set(ByVal value As Nullable(Of Date))
                Me._DDtArrete = value
            End Set
        End Property

        Public Property DBqCpt() As String
            Get
                Return Me._DBqCpt
            End Get
            Set(ByVal value As String)
                Me._DBqCpt = value
            End Set
        End Property

        Public Property DBqVal() As Nullable(Of Decimal)
            Get
                Return Me._DBqVal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._DBqVal = value
            End Set
        End Property

        Public Property DMethodeInventaire() As String
            Get
                Return Me._DMethodeInventaire
            End Get
            Set(ByVal value As String)
                Me._DMethodeInventaire = value
            End Set
        End Property

        Public Property DDtClotureTVA() As Nullable(Of Date)
            Get
                Return Me._DDtClotureTVA
            End Get
            Set(ByVal value As Nullable(Of Date))
                Me._DDtClotureTVA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
