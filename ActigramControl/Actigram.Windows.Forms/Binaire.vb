Namespace Binaire
    Public Class Binaire
        Shared Function CHexDec(ByVal vnum As String) As Decimal
            '* Converti une valeur Hexadecimale en Decimale
            Dim l As String, strVal As Long, n As Long, lD As Decimal
            n = 0
            Do
                l = Right(vnum, 1)
                vnum = Left(vnum, Len(vnum) - 1)
                'If IsNumeric(l) = False Then
                Select Case UCase(l)
                    Case "A"
                        lD = 10
                    Case "B"
                        lD = 11
                    Case "C"
                        lD = 12
                    Case "D"
                        lD = 13
                    Case "E"
                        lD = 14
                    Case "F"
                        lD = 15
                    Case Else
                        lD = Convert.ToInt32(l)
                End Select
                'End If
                lD = CDec(lD)
                strVal = Convert.ToInt64(strVal + (lD * (16 ^ n)))
                n = n + 1
            Loop While Len(vnum) >= 1
            Return strVal
        End Function

        Shared Function CBin(ByVal vnum As Decimal) As String
            '* Conversion Décimal -> Binaire
            Dim strBin As String = ""
            'If vnum <> "" Then
            Dim r(100), res As Decimal, n As Integer
            n = 1
            Do Until vnum = 0
                res = Fix(vnum) / 2
                If Fix(vnum / 2) = res Then
                    r(n) = 0
                Else
                    r(n) = 1
                End If
                n = n + 1
                vnum = Fix(res)
            Loop
            n = n - 1
            If n > 0 Then
                Do
                    strBin = strBin & r(n)
                    n = n - 1
                Loop While n > 0
            End If
            'Else
            'Return 0
            'End If
            Return strBin
        End Function

        Shared Function CBinDec(ByVal vnum As String) As Decimal
            '* Conversion Binaire -> Décimal
            If vnum <> "" Then
                Dim n As Integer, x As Decimal
                For n = 1 To Len(vnum)
                    x = Convert.ToDecimal(x + (Convert.ToInt32(Mid(vnum, n, 1)) * 2 ^ (Len(vnum) - n)))
                Next n
                Return x
            End If
        End Function
    End Class

End Namespace