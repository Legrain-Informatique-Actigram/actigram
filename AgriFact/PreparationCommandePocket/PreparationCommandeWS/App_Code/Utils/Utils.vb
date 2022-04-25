Imports System.Data
Imports System.Diagnostics
Imports System.collections.Generic

#Region " Modules "
Module DecimalUtils
    Public Function GetAccountingFormat(Optional ByVal nbDec As Integer = 0) As String
        Dim decFormat As String = ""
        If nbDec > 0 Then decFormat = "." & New String("0"c, nbDec)
        Return String.Format("{{0:# ##0{0};(# ##0{0});}}", decFormat)
    End Function

    Public Function PercentParse(ByVal s As String) As Nullable(Of Decimal)
        s = s.Replace("%", "")
        Return DecimalParse(s)
    End Function

    Public Function CurrencyParse(ByVal s As String) As Nullable(Of Decimal)
        s = s.Replace(My.Global.Application.Culture.NumberFormat.CurrencySymbol, "")
        Return DecimalParse(s)
    End Function

    Public Function DecimalParse(ByVal s As String) As Nullable(Of Decimal)
        Dim d As New Nullable(Of Decimal)
        If s Is Nothing Then s = ""
        s = s.Replace(",", My.Global.Application.Culture.NumberFormat.NumberDecimalSeparator)
        s = s.Replace(".", My.Global.Application.Culture.NumberFormat.NumberDecimalSeparator)
        Dim d1 As Decimal
        If Decimal.TryParse(s, d1) Then
            d = d1
        End If
        Return d
    End Function

    Public Function IntegerParse(ByVal s As String) As Nullable(Of Integer)
        Dim i As New Nullable(Of Integer)
        If s Is Nothing Then s = ""
        Dim i1 As Integer
        If Integer.TryParse(s, i1) Then
            i = i1
        End If
        Return i
    End Function

    Public Function GetNbDecimals(ByVal d As Decimal, Optional ByVal max As Integer = 5) As Integer
        For i As Integer = 0 To max
            Dim x As Decimal = CDec(d * 10 ^ i)
            If Decimal.Truncate(x) = x Then Return i
        Next
        Return max
    End Function


    Public Function IsValidForNumberInput(ByVal c As Char) As Boolean
        Return Char.IsDigit(c) OrElse Char.IsControl(c) OrElse Char.IsPunctuation(c) OrElse c = "+"
    End Function
End Module

Module IOUtils
    Public Function BuildDate() As DateTime
        Return BuildDate(My.Global.Application.Version)
    End Function

    Public Function BuildDate(ByVal v As System.Version) As DateTime
        'Build dates start from 01/01/2000 
        Dim result As Date = #1/1/2000#

        'Add the number of days (build) 
        result = result.AddDays(v.Build)

        'Add the number of seconds since midnight (revision) multiplied by 2 
        result = result.AddSeconds(v.Revision * 2)


        'If we're currently in daylight saving time add an extra hour 
        If TimeZone.IsDaylightSavingTime(Now, TimeZone.CurrentTimeZone.GetDaylightChanges(Now.Year)) Then result.AddHours(1)

        Return result
    End Function

    Public Sub LogMessage(ByVal message As String)
        My.Log.WriteEntry(message)
    End Sub

    Public Sub LogException(ByVal e As Exception, Optional ByVal severity As TraceEventType = TraceEventType.Critical)
        My.Log.WriteException(e, severity, e.StackTrace)
        If e.InnerException IsNot Nothing Then
            LogException(e.InnerException, severity)
        End If
    End Sub

    Public Function GetTempFileName(Optional ByVal ext As String = ".tmp") As String
        Dim tmp As String = IO.Path.GetTempFileName
        Dim path As String = IO.Path.ChangeExtension(tmp, ext)
        If tmp <> path Then IO.File.Move(tmp, path)
        Return path
    End Function

    Public Function GenerateUniqueFilename(ByVal path As String) As String
        Dim res As String = path
        If IO.File.Exists(res) Then
            Dim i As Integer = 0
            Dim dir As String = IO.Path.GetDirectoryName(res)
            Dim name As String = IO.Path.GetFileNameWithoutExtension(res)
            Dim ext As String = IO.Path.GetExtension(res)
            Do
                i += 1
                res = String.Format("{0}\{1}_{2}{3}", dir, name, i, ext)
            Loop While IO.File.Exists(res)
        End If
        Return res
    End Function

    Public Function CheminComplet(ByVal fichier As String) As String
        If IO.Path.IsPathRooted(fichier) Then
            Return fichier
        Else
            Return My.Request.MapPath(fichier)
        End If
    End Function

    Public Function FormatFileSize(ByVal filelength As Integer) As String
        Dim l As Double = CDbl(filelength)
        Dim units() As String = {"o", "ko", "Mo", "Go"}
        Dim i As Integer = 0
        While l > 1024D And i < units.Length - 1
            l = l / 1024D
            i += 1
        End While
        Return String.Format("{0:N} {1}", l, units(i))
    End Function
End Module

Module GenericsUtils
    Public Function Cast(Of T)(ByVal o As Object) As T
        Return DirectCast(o, T)
    End Function

    Public Function EnumParse(Of T)(ByVal name As String) As T
        Return CType([Enum].Parse(GetType(T), name, True), T)
    End Function
End Module

Module StringUtils

    Public Function FormatEach(ByVal list As IList, ByVal format As String) As List(Of String)
        Dim res As New List(Of String)
        For Each value As Object In list
            res.Add(String.Format(format, value))
        Next
        Return res
    End Function

    Public Function CharIsHexDigit(ByVal c As Char) As Boolean
        Dim chars() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c}
        Return Char.IsDigit(c) OrElse Array.IndexOf(chars, Char.ToUpper(c)) >= 0
    End Function

End Module

Module DataUtils
    Public Function SelectSingleRow(Of T)(ByVal dt As DataTable, ByVal query As String, ByVal sort As String) As T
        If Not (GetType(T) Is GetType(DataRow) OrElse GetType(T).IsSubclassOf(GetType(DataRow))) Then Throw New InvalidCastException("Le type de destination doit hériter de Datarow")
        Return Cast(Of T)(SelectSingleRow(dt, query, sort))
    End Function

    Public Function SelectSingleRow(ByVal dt As DataTable, ByVal query As String, ByVal sort As String) As DataRow
        If dt Is Nothing Then Return Nothing
        Dim rws() As DataRow = dt.Select(query, sort)
        If rws.Length = 0 Then
            Return Nothing
        Else
            Return rws(0)
        End If
    End Function

    Public Function CloneRow(ByVal dr As DataRow) As DataRow
        Dim drDest As DataRow = dr.Table.NewRow
        CopyRow(dr, drDest)
        dr.Table.Rows.Add(drDest)
        Return drDest
    End Function

    Public Sub CopyRow(ByVal drSource As DataRow, ByVal drDest As DataRow)
        For Each dc As DataColumn In drSource.Table.Columns
            If drDest.Table.Columns.Contains(dc.ColumnName) Then
                Dim dcDest As DataColumn = drDest.Table.Columns(dc.ColumnName)
                If Not dcDest.ReadOnly AndAlso Not dcDest.AutoIncrement Then
                    drDest(dc.ColumnName) = drSource(dc.ColumnName)
                End If
            End If            
        Next
    End Sub

    Public Function HasChanges(ByVal dt As DataTable, ByVal rowState As DataRowState) As Boolean
        Dim res As Boolean = False
        For Each dr As DataRow In dt.Rows
            If dr.RowState = rowState Then
                res = True
                Exit For
            End If
        Next
        Return res
    End Function

    Public Function HasChanges(ByVal dt As DataTable) As Boolean
        Dim res As Boolean = False
        For Each dr As DataRow In dt.Rows
            If HasChanges(dr) Then
                res = True
                Exit For
            End If
        Next
        Return res
    End Function

    Public Function HasChanges(ByVal dr As DataRow) As Boolean
        Return dr.RowState <> DataRowState.Unchanged
    End Function

    Public Function FormatExpression(ByVal expression As String, ByVal ParamArray values() As Object) As String
        Dim formattedValues(values.Length) As Object
        For i As Integer = 0 To values.Length - 1
            formattedValues(i) = FormatExpValue(values(i))
        Next
        Return String.Format(expression, formattedValues)
    End Function

    Public Function FormatExpValue(ByVal value As Object) As String
        Dim res As String
        If IsDBNull(value) Or value Is Nothing Then
            res = "NULL"
        Else
            If TypeOf value Is String Then
                res = "'" & CStr(value).Replace("'", "''") & "'"
            ElseIf TypeOf value Is Date Then
                res = String.Format("'{0:dd-MM-yyyy HH:mm:ss}'", value)
            ElseIf TypeOf value Is Decimal Or TypeOf value Is Single Then
                res = CDec(value).ToString().Replace(My.Global.Application.Culture.NumberFormat.NumberDecimalSeparator, ".")
            Else
                res = String.Format("{0}", value)
            End If
        End If
        Return res
    End Function
End Module

Module BarCodeUtils
    Public Function FormatterCodeBarre(ByVal code As String) As String
        If code Is Nothing Then Return Nothing
        code = code.PadLeft(12, "0"c)
        Return CodeBarreC(code)
    End Function

    Private Function CodeBarreC(ByVal str As String) As String
        Dim result As String = ""
        Dim startC As String = Chr(171)
        Dim carStop As String = Chr(172)
        Dim chk As Integer = 105

        For i As Integer = 0 To Len(str) \ 2 - 1
            Dim digit As Integer = Integer.Parse(str.Substring(i * 2, 2))
            result &= encode(digit)
            chk = chk + (i + 1) * digit
        Next
        chk = chk Mod 103
        Return startC & result & encode(chk) & carStop
    End Function

    Private Function encode(ByVal digit As Integer) As String
        Dim result As String = ""
        Select Case digit
            Case 0 : result = Chr(174)
            Case 1 To 94 : result = Chr(digit + 32)
            Case 95 To 106 : result = Chr(digit + 66)
        End Select
        Return result
    End Function
End Module
#End Region
