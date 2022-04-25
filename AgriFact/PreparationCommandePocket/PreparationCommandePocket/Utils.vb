Imports System.Data

Namespace My

    Partial Class Application

        Private Shared _company As String
        Private Shared _copyright As String
        Private Shared _description As String
        Private Shared _product As String
        Private Shared _title As String

        Private Shared Sub LoadAttributes()
            Dim objects() As Object = System.Reflection.Assembly.GetExecutingAssembly.GetCustomAttributes(True)
            For Each o As Object In objects
                If TypeOf o Is Reflection.AssemblyCopyrightAttribute Then
                    _copyright = CType(o, Reflection.AssemblyCopyrightAttribute).Copyright
                ElseIf TypeOf o Is Reflection.AssemblyCompanyAttribute Then
                    _company = CType(o, Reflection.AssemblyCompanyAttribute).Company
                ElseIf TypeOf o Is Reflection.AssemblyDescriptionAttribute Then
                    _description = CType(o, Reflection.AssemblyDescriptionAttribute).Description
                ElseIf TypeOf o Is Reflection.AssemblyProductAttribute Then
                    _product = CType(o, Reflection.AssemblyProductAttribute).Product
                ElseIf TypeOf o Is Reflection.AssemblyTitleAttribute Then
                    _title = CType(o, Reflection.AssemblyTitleAttribute).Title
                End If
            Next
        End Sub


        Public Shared ReadOnly Property Company() As String
            Get
                If _company Is Nothing Then LoadAttributes()
                Return _company
            End Get
        End Property


        Public Shared ReadOnly Property Copyright() As String
            Get
                If _copyright Is Nothing Then LoadAttributes()
                Return _copyright
            End Get
        End Property

        Public Shared ReadOnly Property Description() As String
            Get
                If _description Is Nothing Then LoadAttributes()
                Return _description
            End Get
        End Property

        Public Shared ReadOnly Property Product() As String
            Get
                If _product Is Nothing Then LoadAttributes()
                Return _product
            End Get
        End Property

        Public Shared ReadOnly Property Title() As String
            Get
                If _title Is Nothing Then LoadAttributes()
                Return _title
            End Get
        End Property

        Private Shared _version As Version
        Public Shared ReadOnly Property Version() As Version
            Get
                If _version Is Nothing Then
                    _version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
                End If
                Return _version
            End Get
        End Property


        Private Shared _startuppath As String
        Public Shared ReadOnly Property StartupPath() As String
            Get
                If _startuppath Is Nothing Then
                    _startuppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
                End If
                Return _startuppath
            End Get
        End Property

        Private Shared _culture As System.Globalization.CultureInfo
        Public Shared ReadOnly Property Culture() As System.Globalization.CultureInfo
            Get
                If _culture Is Nothing Then
                    _culture = System.Reflection.Assembly.GetExecutingAssembly.GetName.CultureInfo
                End If
                Return _culture
            End Get
        End Property

    End Class

End Namespace

Module DataUtils
    Public Sub CopyRow(ByVal drSource As DataRow, ByVal drDest As DataRow)
        For Each dc As DataColumn In drSource.Table.Columns
            If Not dc.ReadOnly AndAlso Not dc.AutoIncrement Then
                drDest(dc.ColumnName) = drSource(dc.ColumnName)
            End If
        Next
    End Sub
End Module

Module DecimalUtils
    Public Sub ConfigDecimalControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "N" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf DecimalParse
        End With
    End Sub

    Public Sub DecimalParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType.Name = "Decimal" Then
            Dim d As Nullable(Of Decimal) = DecimalParse(Convert.ToString(e.Value))
            If d.HasValue Then
                e.Value = d.Value
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
        Try
            Dim d1 As Decimal = Decimal.Parse(s)
            d = d1
        Catch
        End Try
        Return d
    End Function

    Public Function GetNbDecimals(ByVal d As Decimal, Optional ByVal max As Integer = 5) As Integer
        For i As Integer = 0 To max
            Dim x As Decimal = CDec(d * 10 ^ i)
            If Decimal.Truncate(x) = x Then Return i
        Next
        Return max
    End Function
End Module