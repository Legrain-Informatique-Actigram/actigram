Namespace MathUtil
    Public Module MathUtil
        Public Function ArithmeticRound(ByVal d As Decimal, ByVal nDigits As Int16) As Decimal
            d += 0.000000000001D
            Return Decimal.Round(d, nDigits)
        End Function
    End Module
End Namespace

Namespace Dates

    Public Class Dates
        Shared Function GetLastDayOfWeek(ByVal dt As Date) As Date
            Dim dtTmp As Date
            dtTmp = dt
            Do Until dtTmp.DayOfWeek = DayOfWeek.Sunday
                dtTmp = dtTmp.AddDays(1)
            Loop
            Return dtTmp
        End Function

        Shared Function GetNWeek(ByVal dt As Date) As Integer
            '* rem ludo
            Dim rep As Integer
            Dim nbDep As Integer
            Dim nbFin As Integer
            rep = Convert.ToDateTime("01/01/" & Year(dt)).DayOfWeek
            'strDate = CStr(Dt)
            'dt = FormatDateTime(dt, vbShortDate)
            nbDep = 0
            Dim dtTmp As Date = Convert.ToDateTime("01/01/" & dt.Year)
            Do Until dtTmp.AddDays(nbDep).DayOfWeek = DayOfWeek.Monday
                nbDep = nbDep + 1
            Loop
            nbFin = dt.DayOfYear
            If nbFin - nbDep < 0 Then
                If rep <= 4 Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                If rep = 1 Then
                    Return Convert.ToInt32(Fix((nbFin - nbDep) / 7) + 1)
                ElseIf rep <= 4 Then
                    'Week = Fix((nbFin - nbDep) / 7) + 2
                    Return Convert.ToInt32(Fix((nbFin - nbDep) / 7) + 1)
                Else
                    Return Convert.ToInt32(Fix((nbFin - nbDep) / 7) + 1)
                End If
            End If
            dt = CDate(dt)
            'vbMonday
        End Function

        Shared Sub GetWeekDebutFin(ByVal dt As Date, ByRef dtDebut As Date, ByRef dtFin As Date)
            Dim nbJ As Integer = 0
            Do Until dt.AddDays(-nbJ).DayOfWeek = DayOfWeek.Monday
                nbJ -= 1
            Loop
            dtDebut = dt.AddDays(-nbJ)
            dtFin = dtDebut.AddDays(7)
        End Sub


    End Class

End Namespace


