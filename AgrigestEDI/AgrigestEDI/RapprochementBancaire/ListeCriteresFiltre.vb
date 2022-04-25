Namespace RapprochementBancaire
    Public Class ListeCriteresFiltre

        Private _listeCriteresFiltre As Dictionary(Of String, String)
        Private Const _texteNonPt As String = "non pointées"
        Private Const _textePt As String = "pointées"
        Private Const _texteToutes As String = "toutes"
        Private Const _texteDebit As String = "(D)"
        Private Const _texteCrebit As String = "(C)"

#Region "Constructeur"
        Public Sub New()
            Me._listeCriteresFiltre = New Dictionary(Of String, String)

            Me._listeCriteresFiltre.Add("TypeEcr", String.Empty)
            Me._listeCriteresFiltre.Add("dateEcrDeb", String.Empty)
            Me._listeCriteresFiltre.Add("dateEcrFin", String.Empty)
            Me._listeCriteresFiltre.Add("datePt", String.Empty)
            Me._listeCriteresFiltre.Add("sensMontant", String.Empty)
            Me._listeCriteresFiltre.Add("montantDeb", String.Empty)
            Me._listeCriteresFiltre.Add("montantFin", String.Empty)
            Me._listeCriteresFiltre.Add("numPiece", String.Empty)
            Me._listeCriteresFiltre.Add("libelle", String.Empty)
        End Sub

        Public Sub New(ByVal typeEcr As String, ByVal dateEcrDeb As String, ByVal dateEcrFin As String, ByVal datePt As String, ByVal sensMontant As String, ByVal montantDeb As String, ByVal montantFin As String, ByVal numPiece As String, ByVal libelle As String)
            Me._listeCriteresFiltre = New Dictionary(Of String, String)

            Me._listeCriteresFiltre.Add("typeEcr", typeEcr)
            Me._listeCriteresFiltre.Add("dateEcrDeb", dateEcrDeb)
            Me._listeCriteresFiltre.Add("dateEcrFin", dateEcrFin)
            Me._listeCriteresFiltre.Add("datePt", datePt)
            Me._listeCriteresFiltre.Add("sensMontant", sensMontant)
            Me._listeCriteresFiltre.Add("montantDeb", montantDeb)
            Me._listeCriteresFiltre.Add("montantFin", montantFin)
            Me._listeCriteresFiltre.Add("numPiece", numPiece)
            Me._listeCriteresFiltre.Add("libelle", libelle)
        End Sub
#End Region

#Region "Propriétés"
        Public Property TypeEcr() As String
            Get
                Return Me._listeCriteresFiltre.Item("TypeEcr")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("TypeEcr") = value
            End Set
        End Property

        Public Property DateEcrDeb() As String
            Get
                Return Me._listeCriteresFiltre.Item("dateEcrDeb")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("dateEcrDeb") = value
            End Set
        End Property

        Public Property DateEcrFin() As String
            Get
                Return Me._listeCriteresFiltre.Item("dateEcrFin")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("dateEcrFin") = value
            End Set
        End Property

        Public Property DatePt() As String
            Get
                Return Me._listeCriteresFiltre.Item("datePt")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("datePt") = value
            End Set
        End Property

        Public Property SensMontant() As String
            Get
                Return Me._listeCriteresFiltre.Item("sensMontant")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("sensMontant") = value
            End Set
        End Property

        Public Property MontantDeb() As String
            Get
                Return Me._listeCriteresFiltre.Item("montantDeb")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("montantDeb") = value
            End Set
        End Property

        Public Property MontantFin() As String
            Get
                Return Me._listeCriteresFiltre.Item("montantFin")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("montantFin") = value
            End Set
        End Property

        Public Property NumPiece() As String
            Get
                Return Me._listeCriteresFiltre.Item("numPiece")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("numPiece") = value
            End Set
        End Property

        Public Property Libelle() As String
            Get
                Return Me._listeCriteresFiltre.Item("libelle")
            End Get
            Set(ByVal value As String)
                Me._listeCriteresFiltre.Item("libelle") = value
            End Set
        End Property

        Public ReadOnly Property ListeCriteres() As Dictionary(Of String, String)
            Get
                Return Me._listeCriteresFiltre
            End Get
        End Property

        Public ReadOnly Property TexteNonPt() As String
            Get
                Return ListeCriteresFiltre._texteNonPt
            End Get
        End Property

        Public ReadOnly Property TextePt() As String
            Get
                Return ListeCriteresFiltre._textePt
            End Get
        End Property

        Public ReadOnly Property TexteToutes() As String
            Get
                Return ListeCriteresFiltre._texteToutes
            End Get
        End Property

        Public ReadOnly Property TexteDebit() As String
            Get
                Return ListeCriteresFiltre._texteDebit
            End Get
        End Property

        Public ReadOnly Property TexteCrebit() As String
            Get
                Return ListeCriteresFiltre._texteCrebit
            End Get
        End Property
#End Region

#Region "Méthodes"
        Public Sub EffacerValeursCriteres()
            Me._listeCriteresFiltre.Item("TypeEcr") = String.Empty
            Me._listeCriteresFiltre.Item("dateEcrDeb") = String.Empty
            Me._listeCriteresFiltre.Item("dateEcrFin") = String.Empty
            Me._listeCriteresFiltre.Item("datePt") = String.Empty
            Me._listeCriteresFiltre.Item("sensMontant") = String.Empty
            Me._listeCriteresFiltre.Item("montantDeb") = String.Empty
            Me._listeCriteresFiltre.Item("montantFin") = String.Empty
            Me._listeCriteresFiltre.Item("numPiece") = String.Empty
            Me._listeCriteresFiltre.Item("libelle") = String.Empty
        End Sub
#End Region

    End Class
End Namespace
