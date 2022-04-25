Imports System.Text.RegularExpressions

Public Class Lots

#Region "Méthodes partagées"
    'Pour les format, on utilise la classe MyFormat qui gére le Sxxx pour les substring
    Public Shared Function GetNLotBR(ByVal nBR As Integer, ByVal dateBR As Date, ByVal nomFourn As String) As String
        Return GetNLotBR(My.Settings.FormatLotBR, nBR, dateBR, nomFourn)
    End Function

    Public Shared Function GetNLotBR(ByVal format As String, ByVal nBR As Integer, ByVal dateBR As Date, ByVal nomFourn As String) As String
        format = GetFormatString(format, "num", "date", "quant", "nom")
        Return String.Format(New MyFormat, format, nBR, dateBR, dateBR.DayOfYear, nomFourn)
    End Function

    Public Shared Function GetNLotFab(ByVal nBR As Integer, ByVal dateBR As Date, ByVal desc As String) As String
        Return GetNLotFab(My.Settings.FormatLotFab, nBR, dateBR, desc)
    End Function

    Public Shared Function GetNLotFab(ByVal format As String, ByVal nFab As Integer, ByVal dateFab As Date, ByVal desc As String) As String
        format = GetFormatString(format, "num", "date", "quant", "desc")
        Return String.Format(New MyFormat, format, nFab, dateFab, dateFab.DayOfYear, desc)
    End Function

    Private Shared Function GetFormatString(ByVal format As String, ByVal ParamArray varNames() As String) As String
        Dim re As New Regex("\{(?<var>.*?)(:(?<format>.*?))*\}")
        Dim res As String = format
        Dim matches As MatchCollection = re.Matches(format)
        For Each m As Match In matches
            Dim newValue As String = m.Value
            Dim i As Integer = Array.IndexOf(varNames, m.Groups("var").Value)
            newValue = newValue.Replace(m.Groups("var").Value, i.ToString)
            If m.Groups("format").Length > 0 Then
                newValue = newValue.Replace(m.Groups("format").Value, ConvertFormat(m.Groups("format").Value))
            End If
            res = res.Replace(m.Value, newValue)
        Next
        Return res
    End Function

    Private Shared Function ConvertFormat(ByVal format As String) As String
        format = format.Replace("A", "y")
        format = format.Replace("a", "y")
        format = format.Replace("j", "d")
        format = format.Replace("J", "d")
        Return format
    End Function
#End Region

End Class
