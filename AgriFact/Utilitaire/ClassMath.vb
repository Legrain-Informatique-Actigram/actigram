Namespace Math

    Public Class Expressions
        Public Shared Function CalculExpression(ByVal Expression As String) As Decimal

            Expression = AnalyseMoins(Expression)

            Dim str() As String

            str = Expression.Split(New Char() {"+"c})

            Dim strI As String
            Dim result As Decimal
            Dim i As Integer

            For i = 0 To str.GetUpperBound(0)
                If i = 0 Then
                    result = AnalyseFois(str(i))
                    Expression = Expression.Substring(str(i).Length, (Expression.Length - str(i).Length))
                Else
                    Select Case Expression.Substring(0, 1)
                        Case "+"
                            result += AnalyseFois(str(i))
                    End Select
                    Expression = Expression.Substring(str(i).Length + 1, (Expression.Length - str(i).Length - 1))
                End If
            Next
            Return result
        End Function

        Private Shared Function AnalyseMoins(ByVal Expression As String) As String

            Dim str() As String

            str = Expression.Split(New Char() {"-"c})

            Dim strI As String
            Dim result As Decimal
            Dim i As Integer

            For i = 1 To str.GetUpperBound(0)
                Dim strLast As String
                If str(i - 1).Trim.Length > 0 Then
                    strLast = str(i - 1).Trim.Substring(str(i - 1).Trim.Length - 1, 1)
                    If strLast <> "/" And strLast <> "*" And strLast <> "+" Then
                        str(i - 1) += "+"
                    End If
                End If
            Next
            Return String.Join("-", str)
        End Function

        Private Shared Function AnalyseFois(ByVal Expression As String) As Decimal
            Dim str() As String
            str = Expression.Split(New Char() {"*"c, "/"c})

            Dim strI As String
            Dim result As Decimal
            Dim i As Integer

            For i = 0 To str.GetUpperBound(0)
                If i = 0 Then
                    result = AnalyseString(str(i))
                    Expression = Expression.Substring(str(i).Length, (Expression.Length - str(i).Length))
                Else
                    Select Case Expression.Substring(0, 1)
                        Case "*"
                            result *= AnalyseString(str(i))
                        Case "/"
                            result /= AnalyseString(str(i))
                    End Select
                    Expression = Expression.Substring(str(i).Length + 1, (Expression.Length - str(i).Length - 1))
                End If
            Next
            Return result
        End Function

        Private Shared Function AnalyseString(ByVal str As String) As Decimal
            Return Decimal.Parse(str.Replace(" ", ""))
        End Function

    End Class


End Namespace