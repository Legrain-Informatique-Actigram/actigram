Namespace RapprochementBancaire
    Public Class CodePointage

#Region "Méthodes partagées"
        Public Shared Function CreerCodePointage(ByVal maxCodePointage As String) As String
            Return NextCodePointage(maxCodePointage)
        End Function

        Public Shared Function NextCodePointage(ByVal codePointage As String) As String
            If codePointage Is Nothing Then Return "000"

            Dim chars() As Char = codePointage.ToCharArray

            For i As Integer = chars.Length - 1 To 0 Step -1
                Dim l As Char = chars(i)
                l = NextChar(l)
                chars(i) = l
                If l <> "0"c Then Exit For
            Next

            codePointage = New String(chars)

            If codePointage = "000" Then Throw New ApplicationException("Tous les codes lettrages ont été utilisés")

            Return codePointage
        End Function

        Public Shared Function NextChar(ByVal c As Char) As Char
            Select Case c
                Case "Z"c : Return "0"c
                Case "9"c : Return "A"c
                Case Else : Return Chr(Asc(c) + 1)
            End Select
        End Function
#End Region

    End Class
End Namespace
