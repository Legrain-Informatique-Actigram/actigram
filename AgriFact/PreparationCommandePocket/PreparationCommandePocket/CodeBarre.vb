Public Class CodeBarre
    Public Shared Function Parse(ByVal s As String) As CodeBarre
        If s.Length < 2 Then Return Nothing
        Dim type As String = s.Substring(0, 2)
        If type = "99" Then
            Return CodeBarreBonCommande.Parse(s)
        Else
            Return CodeBarreProduit.Parse(s)
        End If
    End Function

    Public Shared Function IsCodeBarre(ByVal str As String) As Boolean
        For Each c As Char In str.ToCharArray
            If Not (Char.IsDigit(c) OrElse IsGroupSeparator(c)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function IsGroupSeparator(ByVal c As Char) As Boolean
        Return c = "("c OrElse c = ")"c OrElse AscW(c) = 29 OrElse c = My.Resources.FNC1Char
    End Function
End Class

Public Class CodeBarreBonCommande
    Inherits CodeBarre
    Public Type As String
    Public DateBC As Date
    Public nBC As Integer

    Public Shared Shadows Function Parse(ByVal s As String) As CodeBarreBonCommande
        Dim cb As New CodeBarreBonCommande
        cb.ConvertString(s)
        Return cb
    End Function

    Public Sub ConvertString(ByVal myString As String)
        Try
            Me.Type = myString.Substring(0, 2)
            Me.DateBC = Date.ParseExact(myString.Substring(2, 6), "yyMMdd", My.Application.Culture.DateTimeFormat)
            Me.nBC = CInt(myString.Substring(8))
        Catch ex As Exception
            Throw New ApplicationException("Problème de conversion" & vbCrLf & "le type de la chaîne ne correspond au type souhaité")
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Bon de commande" & vbCrLf & "N°{0}" & vbCrLf & "du {1:dd/MM/yy}", Me.nBC, Me.DateBC)
    End Function
End Class

Public Class CodeBarreProduit
    Inherits CodeBarre

    Public CodeProduit As String
    Public DateExp As Date
    Public Lot As String
    Public Qte As Integer

    Public Shared Shadows Function Parse(ByVal s As String) As CodeBarreProduit
        Dim cb As New CodeBarreProduit
        cb.ConvertString(s)
        Return cb
    End Function

    Public Sub ConvertString(ByVal myString As String)
        Dim eans As Dictionary(Of String, String) = ParseEan(myString)
        For Each codeAi As String In eans.Keys
            Select Case codeAi
                Case "02" : Me.CodeProduit = Right(eans(codeAi), 13)
                Case "17" : Me.DateExp = Date.ParseExact(eans(codeAi), "yyMMdd", My.Application.Culture.DateTimeFormat)
                Case "10" : Me.Lot = eans(codeAi)
                Case "37" : Me.Qte = CInt(eans(codeAi))
            End Select
        Next
        If Me.DateExp <> Date.MinValue Then
            'Me.Lot = String.Format("{0:ddMMyy} {1}", Me.DateExp, Me.Lot).Trim
            Me.Lot = String.Format("dluo {0:dd/MM/yyyy} lot{1}", Me.DateExp, Me.Lot).Trim
        End If
    End Sub

    Public Function ParseEan(ByVal myString As String) As Dictionary(Of String, String)
        Dim res As New Dictionary(Of String, String)
        Dim pos As Integer 'Position dans la chaine
        Dim cars() As Char = myString.ToCharArray
        Dim codeAi As String = ""
        Dim curAi As Ean.EanAi = Nothing
        Dim data As String = ""
        While pos < cars.Length
            If curAi Is Nothing Then 'En mode lecture de code AI
                'Sauter les caractères de contrôle
                While IsGroupSeparator(cars(pos))
                    pos += 1
                End While
                'Construire le code AI
                codeAi = codeAi & cars(pos)
                pos += 1
                'Vérifier si le code existe
                If Ean.EanAi.AiDefs.ContainsKey(codeAi) Then
                    'Chopper l'objet
                    curAi = Ean.EanAi.AiDefs(codeAi)
                    If cars(pos) = ")"c Then pos += 1
                    'Initialiser les data ne prenant la longueur minimale
                    'TODO => Il faudrait faire des vérifs sur cette lecture : caracteres spéciaux, fin de chaine,...
                    data = myString.Substring(pos, curAi.MinLength)
                    pos += curAi.MinLength
                    'Si taille fixe, il n'y a pas plus de données à prendre, on se mets en position pour lire le prochain AI
                    If Not curAi.VariableLength Then
                        res.Add(curAi.Code, data)
                        curAi = Nothing
                        codeAi = Nothing
                        data = Nothing
                    End If
                End If
            Else 'En mode lecture de données
                'Vérifier si on n'est pas en fin de données 
                If Not (IsGroupSeparator(cars(pos)) OrElse data.Length = curAi.MaxLength) Then
                    'Si non, enquiller les caractères
                    data &= cars(pos)
                    pos += 1
                Else
                    'Si oui, on enregistre et on se mets en position pour lire le prochain AI
                    res.Add(curAi.Code, data)
                    curAi = Nothing
                    codeAi = Nothing
                    data = Nothing
                End If
            End If
        End While
        'Pour ajouter le dernier AI lu
        If curAi IsNot Nothing AndAlso data IsNot Nothing Then
            res.Add(curAi.Code, data)
        End If
        Return res
    End Function


    Public Overrides Function ToString() As String
        Return String.Format("Produit" & vbCrLf & "GENCOD:{0}" & vbCrLf & "LOT: n°{1} du {2:dd/MM/yy}" & vbCrLf & "QTE:{3}", Me.CodeProduit, Me.Lot, Me.DateExp, Me.Qte)
    End Function
End Class

Namespace Ean
    Public Class EanAi
        Public Code As String
        Public Description As String
        Public VariableLength As Boolean
        Public MinLength As Integer
        Public MaxLength As Integer

        Public Sub New()

        End Sub

        Public Sub New(ByVal code As String, ByVal description As String, ByVal variableLength As Boolean, ByVal minLength As Integer, ByVal MaxLength As Integer)
            Me.New()
            Me.Code = code
            Me.Description = description
            Me.VariableLength = variableLength
            Me.MinLength = minLength
            Me.MaxLength = MaxLength
        End Sub

#Region "Shared"
        Private Shared _AiDefs As Dictionary(Of String, EanAi)
        Public Shared ReadOnly Property AiDefs() As Dictionary(Of String, EanAi)
            Get
                If _AiDefs Is Nothing Then
                    _AiDefs = New Dictionary(Of String, EanAi)
                    Dim ais As List(Of EanAi) = ChargerListeAI()
                    For Each ai As EanAi In ais
                        _AiDefs.Add(ai.Code, ai)
                    Next
                End If
                Return _AiDefs
            End Get
        End Property

        Private Shared Function ChargerListeAI() As List(Of EanAi)
            'TODO Charger les AI => XML ?
            Dim res As New List(Of EanAi)
            res.Add(New EanAi("02", "Number of containers", False, 14, 14)) 'GENCOD produit
            res.Add(New EanAi("10", "Batch Number", True, 1, 20)) 'N° de lot
            res.Add(New EanAi("17", "Expiration Date", False, 6, 6))
            res.Add(New EanAi("37", "Number of Units Contained", True, 1, 8)) 'Quantité
            Return res
        End Function
#End Region

    End Class
End Namespace
