Namespace Baremes.ClassesMetier
    Public Class Facon_Culturale

        Private _ID_FACON_CULTURALE As Integer
        Private _LIBELLE_FACON_CULTURALE As String

#Region "Propriétés"
        Public Property ID_FACON_CULTURALE() As Integer
            Get
                Return Me._ID_FACON_CULTURALE
            End Get
            Set(ByVal value As Integer)
                Me._ID_FACON_CULTURALE = value
            End Set
        End Property

        Public Property LIBELLE_FACON_CULTURALE() As String
            Get
                Return Me._LIBELLE_FACON_CULTURALE
            End Get
            Set(ByVal value As String)
                Me._LIBELLE_FACON_CULTURALE = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
