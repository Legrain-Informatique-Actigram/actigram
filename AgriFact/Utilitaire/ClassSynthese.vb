Namespace Impression.EtatsSynthese

    Public Class ClassSynthese

        Public Shared Function AnalyseFourchette(ByVal Expression As String) As String
            Dim str() As String
            str = Expression.Split("["c, "]"c)

            Dim i As Integer
            For i = 0 To str.GetUpperBound(0)
                If Expression.IndexOf("[" & str(i) & "]") >= 0 Then
                    Dim strF() As String
                    strF = str(i).Split(";"c)
                    If strF.GetUpperBound(0) = 4 Then
                        str(i) = CalculFourchette(strF(0), strF(1), strF(2), strF(3), strF(4)).ToString
                    End If
                End If
            Next
            Expression = String.Join("", str)
            Return Expression
        End Function

        Private Shared Function CalculFourchette(ByVal TypeFourchette As String, ByVal Operateur As String, ByVal DebutFourchette As String, ByVal FinFourchette As String, ByVal Masque As String) As Decimal
            Return -99
        End Function

    End Class

End Namespace
