Imports System.Xml
Imports System.Windows.Forms

Public Class ListboxItem

    Private _value As Object
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property


    Private _text As String
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Object)
        Me.Value = value
        Me.Text = value.ToString
    End Sub

    Public Sub New(ByVal text As String, ByVal value As Object)
        Me.Text = text
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

Module XmlUtils
    Public Function SerializeToString(Of T)(ByVal obj As T) As String
        Dim sb As New System.Text.StringBuilder
        Using tw As New IO.StringWriter(sb)
            Serialize(Of T)(obj, tw)
        End Using
        Return sb.ToString
    End Function

    Public Sub SerializeToFile(Of T)(ByVal obj As T, ByVal filename As String)
        Using tw As New IO.StreamWriter(filename, False)
            Serialize(Of T)(obj, tw)
        End Using
    End Sub


    Public Sub Serialize(Of T)(ByVal obj As T, ByVal destSw As IO.TextWriter)
        Dim x As New Serialization.XmlSerializer(GetType(T))
        x.Serialize(destSw, obj)
    End Sub

    Public Function DeSerializeFromFile(Of T)(ByVal path As String) As T
        Using sr As New IO.StreamReader(path,True)
            Return DeSerialize(Of T)(sr)
        End Using
    End Function

    Public Function DeSerializeFromString(Of T)(ByVal s As String) As T
        Using sr As New IO.StringReader(s)
            Return DeSerialize(Of T)(sr)
        End Using
    End Function

    Public Function DeSerialize(Of T)(ByVal sourceSr As IO.TextReader) As T
        Dim x As New Serialization.XmlSerializer(GetType(T))
        Return DirectCast(x.Deserialize(sourceSr), T)
    End Function
End Module

Module DecimalUtils
    Public Function GetAccountingFormat(Optional ByVal nbDec As Integer = 0) As String
        Dim decFormat As String = ""
        If nbDec > 0 Then decFormat = "." & New String("0"c, nbDec)
        Return String.Format("{{0:# ##0{0};(# ##0{0});}}", decFormat)
    End Function

    Public Sub ConfigNumericControl(ByVal c As Control)
        AddHandler c.KeyPress, AddressOf NumericKeyPressHandler
    End Sub

    Public Sub ConfigDecimalControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        If c.DataBindings("Text") IsNot Nothing Then
            With c.DataBindings("Text")
                .FormatString = "N" & decimals
                .FormattingEnabled = True
                AddHandler .Parse, AddressOf DecimalParse
            End With
        End If
        AddHandler c.KeyPress, AddressOf NumericKeyPressHandler
    End Sub

    Private Sub NumericKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Not IsValidForNumberInput(e.KeyChar)
    End Sub

    Public Sub DecimalParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType.Name = "Decimal" Then
            Dim d As Nullable(Of Decimal) = DecimalParse(Convert.ToString(e.Value))
            If d.HasValue Then
                e.Value = d.Value
            Else
                e.Value = DBNull.Value
            End If
        End If
    End Sub

    Public Sub ConfigPercentControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "P" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf PercentParse
        End With
    End Sub

    Public Sub PercentParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType.Name = "Decimal" Then
            Dim s As String = Convert.ToString(e.Value).Replace("%", "")
            Dim d As Nullable(Of Decimal) = DecimalParse(s)
            If d.HasValue Then
                e.Value = d.Value
            End If
        End If
    End Sub

    Public Sub ConfigCurrencyControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "C" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf CurrencyParse
        End With
    End Sub

    Public Sub CurrencyParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType.Name = "Decimal" Then
            Dim s As String = Convert.ToString(e.Value).Replace(My.Application.Culture.NumberFormat.CurrencySymbol, "")
            Dim d As Nullable(Of Decimal) = DecimalParse(s)
            If d.HasValue Then
                e.Value = d.Value
            End If
        End If
    End Sub


    Public Function DecimalParse(ByVal s As String) As Nullable(Of Decimal)
        Dim d As New Nullable(Of Decimal)
        If s Is Nothing Then s = ""
        s = s.Replace(",", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        s = s.Replace(".", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
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