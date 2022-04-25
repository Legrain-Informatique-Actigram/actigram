Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Xml.Schema


#Region " Classes "
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

Public Class UserCancelledException
    Inherits ApplicationException

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal s As String)
        MyBase.New(s)
    End Sub

End Class

Public Class Couple(Of TX, TY)
    Private _x As TX
    Public Property X() As TX
        Get
            Return _x
        End Get
        Set(ByVal value As TX)
            _x = value
        End Set
    End Property


    Private _y As TY
    Public Property Y() As TY
        Get
            Return _y
        End Get
        Set(ByVal value As TY)
            _y = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal X As TX, ByVal Y As TY)
        Me.New()
        Me.X = X
        Me.Y = Y
    End Sub
End Class

Public Class MyFormat
    Implements IFormatProvider
    Implements ICustomFormatter

    ' String.Format calls this method to get an instance of an
    ' ICustomFormatter to handle the formatting.
    Public Function GetFormat(ByVal service As Type) As Object _
    Implements IFormatProvider.GetFormat

        If service.ToString() = GetType(ICustomFormatter).ToString() Then
            Return Me
        Else
            Return Nothing
        End If
    End Function

    ' After String.Format gets the ICustomFormatter, it calls this format
    ' method on each argument.
    Public Function Format(ByVal theformat As String, ByVal arg As Object, ByVal provider As IFormatProvider) As String _
    Implements ICustomFormatter.Format

        If theformat Is Nothing Then
            Return String.Format("{0}", arg)
        End If
        Dim i As Integer = theformat.Length
        ' If the format is not a defined custom code,
        ' use the formatting support in ToString.
        If Not theformat.StartsWith("S") Then
            ' If the object to be formatted supports the IFormattable
            ' interface, pass the format specifier to the 
            ' objects ToString method for formatting.
            If TypeOf arg Is IFormattable Then
                Return CType(arg, IFormattable).ToString(theformat, provider)
            ElseIf Not arg Is Nothing Then
                ' If the object does not support IFormattable, 
                ' call the objects ToString method with no additional
                ' formatting. 
                Return arg.ToString()
            Else
                Return ""
            End If
        End If
        ' Uses the format string to
        ' form the output string.
        theformat = theformat.Trim(New Char() {"S"c})
        Dim length As Integer = Convert.ToInt32(theformat)
        Return Left(Convert.ToString(arg), length)
    End Function


    Public Class ListViewColumnSorter
        Implements IComparer

        Private ObjectCompare As CaseInsensitiveComparer

        Private columnToSort As Integer
        Public Property SortColumn() As Integer
            Get
                Return columnToSort
            End Get
            Set(ByVal value As Integer)
                columnToSort = value
            End Set
        End Property


        Private orderOfSort As SortOrder
        Public Property Order() As SortOrder
            Get
                Return orderOfSort
            End Get
            Set(ByVal value As SortOrder)
                orderOfSort = value
            End Set
        End Property


        Public Sub New()
            columnToSort = 0
            orderOfSort = SortOrder.None
            objectCompare = New CaseInsensitiveComparer
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim compareResult As Integer
            Dim listviewX As ListViewItem = CType(x, ListViewItem)
            Dim listviewY As ListViewItem = CType(y, ListViewItem)
            ' Compare les deux éléments
            compareResult = ObjectCompare.Compare(listviewX.SubItems(columnToSort).Text, listviewY.SubItems(columnToSort).Text)

            ' Calcule la valeur correcte d'après la comparaison d'objets
            If orderOfSort = SortOrder.Ascending Then
                'Le tri croissant est sélectionné, renvoie des résultats normaux de comparaison
                Return compareResult
            ElseIf orderOfSort = SortOrder.Descending Then
                'Le tri décroissant est sélectionné, renvoie des résultats négatifs de comparaison
                Return -compareResult
            Else
                'Renvoie '0' pour indiquer qu'ils sont égaux
                Return 0
            End If
        End Function
    End Class
End Class

Public Class CommandParam
    Public Name As String
    Public Value As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal arg As String)
        Dim c As CommandParam = Parse(arg)
        Me.Name = c.Name
        Me.Value = c.Value
    End Sub

    Public Shared Function Parse(ByVal arg As String) As CommandParam
        Dim c As New CommandParam
        If arg.IndexOf("=") >= 0 Then
            c.Name = arg.Substring(0, arg.IndexOf("=")).ToLower
            c.Value = arg.Substring(arg.IndexOf("=") + 1).Replace(Chr(34), "")
        Else
            c.Name = arg.ToLower
            c.Value = ""
        End If
        c.Name = c.Name.Replace("/"c, "-"c)
        Return c
    End Function

    Public Shared Function Parse(ByVal args As Collections.ObjectModel.ReadOnlyCollection(Of String)) As List(Of CommandParam)
        Dim res As New List(Of CommandParam)
        For Each arg As String In args
            res.Add(Parse(arg))
        Next
        Return res
    End Function
End Class
#End Region

#Region " Modules "

Module NullUtils
    Public Delegate Function DecimalMonoOp(ByVal d1 As Decimal) As Decimal
    Public Delegate Function DecimalOp(ByVal d1 As Decimal, ByVal d2 As Decimal) As Decimal

    Public Function NullableOp(ByVal e As DecimalMonoOp, ByVal d1 As Nullable(Of Decimal)) As Nullable(Of Decimal)
        If d1.HasValue Then
            Return e(d1.Value)
        Else
            Return New Nullable(Of Decimal)
        End If
    End Function

    Public Function NullableOp(ByVal e As DecimalOp, ByVal d1 As Nullable(Of Decimal), ByVal d2 As Nullable(Of Decimal), Optional ByVal useDefault As Boolean = False) As Nullable(Of Decimal)
        If useDefault Then
            Return e(d1.GetValueOrDefault, d2.GetValueOrDefault)
        Else
            If d1.HasValue AndAlso d2.HasValue Then
                Return e(d1.Value, d2.Value)
            Else
                Return New Nullable(Of Decimal)
            End If
        End If
    End Function

    Public Function NullableMult(ByVal ParamArray operandes() As Nullable(Of Decimal)) As Nullable(Of Decimal)
        Dim res As Decimal = 1D
        For Each a As Nullable(Of Decimal) In operandes
            If Not a.HasValue Then
                Return New Nullable(Of Decimal)
            Else
                res *= a.Value
            End If
        Next
        Return res
    End Function

    Public Function NullableArrondi(ByVal val As Nullable(Of Decimal), ByVal arrondi As Integer) As Nullable(Of Decimal)
        Dim res As Decimal = 1D

        If Not val.HasValue Then
            Return New Nullable(Of Decimal)
        Else
            res = Decimal.Round(val.Value, arrondi, MidpointRounding.AwayFromZero)
        End If

        Return res
    End Function

    Public Function DBNullify(Of T As Structure)(ByVal val As Nullable(Of T)) As Object
        If val.HasValue Then
            Return val.Value
        Else
            Return DBNull.Value
        End If
    End Function

    Public Function Nullabilify(Of T As Structure)(ByVal val As Object) As Nullable(Of T)
        Dim res As New Nullable(Of T)
        If Not IsDBNull(val) Then
            res = CType(val, T)
        End If
        Return res
    End Function

    Public Function ReplaceDbNull(ByVal value As Object, ByVal replace As Object) As Object
        Return IIf(IsDBNull(value), replace, value)
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

    Public Sub ConfigDateControl(ByVal c As Control)
        AddHandler c.KeyPress, AddressOf DateKeyPressHandler
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

    Private Sub DateKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Not IsValidForDateInput(e.KeyChar)
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
            Dim d As Nullable(Of Decimal) = PercentParse(Convert.ToString(e.Value))
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
            Dim d As Nullable(Of Decimal) = CurrencyParse(Convert.ToString(e.Value))
            If d.HasValue Then
                e.Value = d.Value
            End If
        End If
    End Sub

    Public Function PercentParse(ByVal s As String) As Nullable(Of Decimal)
        s = s.Replace("%", "")
        Return DecimalParse(s)
    End Function

    Public Function CurrencyParse(ByVal s As String) As Nullable(Of Decimal)
        s = s.Replace(My.Application.Culture.NumberFormat.CurrencySymbol, "")
        Return DecimalParse(s)
    End Function

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

    Public Function IsValidForDateInput(ByVal c As Char) As Boolean
        Return Char.IsDigit(c) OrElse Char.IsControl(c) OrElse c = "/"
    End Function
End Module

Module IOUtils
    Public Function CompareVersions(ByVal a As Version, ByVal b As Version, Optional ByVal fieldCount As Integer = 4) As Integer
        Return String.Compare(a.ToString(fieldCount), b.ToString(fieldCount))
    End Function

    Public Sub OpenMail(ByVal mail As String)
        If mail.Length = 0 Then Exit Sub
        Process.Start(String.Format("mailto:{0}", mail))
    End Sub

    Public Function BuildDate() As DateTime
        Return BuildDate(My.Application.Info.Version)
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
        My.Application.Log.WriteEntry(message)
    End Sub

    Public Sub LogException(ByVal e As Exception, Optional ByVal severity As TraceEventType = TraceEventType.Critical)
        My.Application.Log.WriteException(e, severity, e.StackTrace)
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
            Return IO.Path.Combine(My.Application.Info.DirectoryPath, fichier)
        End If
    End Function

    Public Sub OuvrirFichier(ByVal chemin As String, Optional ByVal verb As String = Nothing, Optional ByVal arguments As String = "")
        If chemin.Contains("|DataDirectory|") Then
            chemin = chemin.Replace("|DataDirectory|", My.Application.Info.DirectoryPath)
        End If
        If Not IO.File.Exists(chemin) AndAlso Not IO.Directory.Exists(chemin) Then
            MsgBox("Fichier ou répertoire introuvable", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            If verb Is Nothing Then
                Process.Start(chemin, arguments)
            Else
                Dim pi As New ProcessStartInfo(chemin)
                pi.Arguments = arguments 'Peut poser problème ??
                pi.Verb = verb
                pi.UseShellExecute = True
                Process.Start(pi)
            End If
        Catch ex As Exception
            LogException(ex)
            MsgBox("Erreur : " & ex.Message)
        End Try
    End Sub

    Public Sub FormatFileSize(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Select Case e.DesiredType.Name
            Case "String"
                e.Value = FormatFileSize(CInt(e.Value))
        End Select
    End Sub

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
        name = name.Replace(" ", "_")
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
    Public Sub VerifSuppr(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        If e.Action = DataRowAction.Delete Then
            VerifSuppr()
        End If
    End Sub

    Public Sub VerifSuppr()
        If MsgBox("Voulez-vous vraiment supprimer cet élément ?", MsgBoxStyle.OkCancel, "Suppression") = MsgBoxResult.Cancel Then Throw New UserCancelledException("Suppression annulée")
    End Sub

    Public Sub ConfigDataTableEvents(ByVal dt As DataTable, ByVal rowChangedHandler As DataRowChangeEventHandler, Optional ByVal warnOnDelete As Boolean = True)
        If dt Is Nothing Then Exit Sub
        If warnOnDelete Then AddHandler dt.RowDeleting, AddressOf VerifSuppr
        If rowChangedHandler IsNot Nothing Then
            AddHandler dt.RowChanged, rowChangedHandler
            AddHandler dt.RowDeleted, rowChangedHandler
        End If
    End Sub

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
            If Not dc.ReadOnly AndAlso Not dc.AutoIncrement And drDest.Table.Columns.Contains(dc.ColumnName) Then
                drDest(dc.ColumnName) = drSource(dc.ColumnName)
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
                res = CDec(value).ToString().Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, ".")
            Else
                res = String.Format("{0}", value)
            End If
        End If
        Return res
    End Function

    Public Sub DebugDataset(ByVal ds As DataSet, Optional ByVal skipEmptyTables As Boolean = True)
        Dim fs As New IO.FileStream("c:\toto.htm", IO.FileMode.Create)
        Dim sw As New IO.StreamWriter(fs, System.Text.Encoding.Default)
        sw.WriteLine("<html><head><style>" & _
                        "body {font-family:arial;font-size: 10pt}" & vbCrLf & _
                        "td {font-family:arial;font-size: 10pt}" & _
                        "</style></head><body><a name=""top"">")
        For Each dt As DataTable In ds.Tables
            If Not skipEmptyTables OrElse dt.Rows.Count > 0 Then
                sw.WriteLine(String.Format("<a href=""#{0}"">Table {0}</a><br>", dt.TableName))
            End If
        Next
        For Each dt As DataTable In ds.Tables
            If Not skipEmptyTables OrElse dt.Rows.Count > 0 Then
                DebugDatatable(dt, sw)
            End If
        Next
        sw.WriteLine("</body></html>")
        sw.Close()
        Process.Start("c:\toto.htm")
    End Sub

    Public Sub DebugDatatable(ByVal dt As DataTable)
        Dim fs As New IO.FileStream("c:\toto.htm", IO.FileMode.Create)
        Dim sw As New IO.StreamWriter(fs, System.Text.Encoding.Default)
        sw.WriteLine("<html><head><style>" & _
                        "body {font-family:arial;font-size: 10pt}" & vbCrLf & _
                        "td {font-family:arial;font-size: 10pt}" & _
                        "</style></head><body><a name=""top"">")
        DebugDatatable(dt, sw)
        sw.WriteLine("</body></html>")
        sw.Close()
        Process.Start("c:\toto.htm")
    End Sub

    Public Sub DebugDatatable(ByVal dt As DataTable, ByVal sw As IO.StreamWriter)
        sw.WriteLine(String.Format("<h1><a name=""{0}"">Table {0} <a href=""#top"">Top</a></h1>", dt.TableName))
        sw.Write("<table cellpadding=""2"" cellspacing=""0"" border=""1"" ><thead><tr>")
        For Each dc As DataColumn In dt.Columns
            sw.Write("<th>" & dc.ColumnName & "</th>")
        Next
        sw.WriteLine("</tr></thead>")
        sw.WriteLine("<tbody>")
        For Each dr As DataRow In dt.Rows
            sw.WriteLine("<tr>")
            For i As Integer = 0 To dt.Columns.Count - 1
                sw.WriteLine("<td>")
                Try
                    sw.Write(CStr(ReplaceDbNull(dr(i), "[NULL]")))
                Catch ex As Exception
                    sw.Write("<span style=""color:red"">" & ex.Message & "</span>")
                End Try
                sw.WriteLine("</td>")
            Next
            sw.WriteLine("</tr>")
        Next
        sw.WriteLine("</tbody></table>")
    End Sub
End Module

Module FormsUtils

    Private defaultIconHandle As IntPtr = IntPtr.Zero

    Public Sub SetChildFormIcon(ByVal fr As Form, Optional ByVal smallFont As Boolean = False)
        If defaultIconHandle = IntPtr.Zero Then
            Using f As New Form
                defaultIconHandle = f.Icon.Handle
            End Using
        End If
        If fr.Icon.Handle = defaultIconHandle Then
            Dim parentForm As Form = Nothing
            If fr.MdiParent IsNot Nothing Then
                parentForm = fr.MdiParent
            ElseIf fr.Owner IsNot Nothing Then
                parentForm = fr.Owner
            ElseIf My.Application.MyMainForm IsNot Nothing Then
                parentForm = My.Application.MyMainForm
            End If

            If parentForm IsNot Nothing Then
                fr.Icon = parentForm.Icon
            End If
        End If
        If smallFont Then
            fr.Font = New Font(SystemFonts.MessageBoxFont.FontFamily, 8.25!)
        Else
            fr.Font = SystemFonts.MessageBoxFont
        End If
        If fr.MdiParent IsNot Nothing Then
            AddHandler fr.Shown, AddressOf MaximizeOnShown
        End If
    End Sub

    Private Sub MaximizeOnShown(ByVal sender As Object, ByVal e As EventArgs)
        With CType(sender, Form)
            .SuspendLayout()
            .WindowState = FormWindowState.Normal
            .WindowState = FormWindowState.Maximized
            .ResumeLayout()
        End With

    End Sub

    Public Sub SetRecursiveCursor(ByVal ctl As Control, ByVal curs As Cursor)
        ctl.Cursor = curs
        For Each c As Control In ctl.Controls
            SetRecursiveCursor(c, curs)
        Next
    End Sub

    Public Sub ConfigAdvanceOnEnter(ByVal c As Control)
        AddHandler c.KeyPress, AddressOf AdvanceOnEnter
    End Sub

    Public Sub AdvanceOnEnter(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            If CType(sender, Control).Parent IsNot Nothing Then
                CType(sender, Control).Parent.SelectNextControl(CType(sender, Control), True, True, True, True)
                e.Handled = True
            End If
        End If
    End Sub

    'Public Sub ConfigZoomTextbox(ByVal txt As TextBox)
    '    AddHandler txt.DoubleClick, AddressOf FrModifTxt.ZoomTextBox
    'End Sub

#Region "Gestion des erreurs sur ErrorProvider"
    Public Function ControlHasErrors(ByVal ctl As Control, ByVal err As ErrorProvider) As Boolean
        For Each c As Control In ctl.Controls
            If err.GetError(c).Length > 0 Then
                Return True
            End If
            If ControlHasErrors(c, err) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetErrors(ByVal ctl As Control, ByVal err As ErrorProvider) As String
        Dim sb As New System.Text.StringBuilder
        AppendErrors(ctl, err, sb)
        Return sb.ToString.Trim
    End Function

    Private Sub AppendErrors(ByVal ctl As Control, ByVal err As ErrorProvider, ByVal sb As System.Text.StringBuilder)
        For Each c As Control In ctl.Controls
            Dim e As String = err.GetError(c)
            If e.Length > 0 Then
                sb.AppendFormat("  - {0}" & vbCrLf, e)
            End If
            AppendErrors(c, err, sb)
        Next
    End Sub
#End Region

    Public Sub FillCb(ByVal t As Type, ByVal cb As ComboBox, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False, Optional ByVal NameAsValue As Boolean = False)
        With cb
            .BeginUpdate()
            Dim items As New List(Of ListboxItem)
            If AddEmptyItem Then
                items.Add(New ListboxItem("", Nothing))
            End If
            For Each v As Object In [Enum].GetValues(t)
                items.Add(New ListboxItem(v.ToString, IIf(NameAsValue, v.ToString, CInt(v))))
            Next
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = items
            .EndUpdate()
            If defaultSelectFirstItem Then
                If .SelectedIndex < 0 Then .SelectedIndex = 0
            End If
        End With
    End Sub

    Public Sub FillCb(ByVal source As BindingSource, ByVal cb As ToolStripComboBox, ByVal displayExpression As String, ByVal valueMember As String, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False)
        With cb
            .BeginUpdate()
            .Items.Clear()
            If AddEmptyItem Then
                .Items.Add(New ListboxItem("", Nothing))
            End If
            For Each d As DataRowView In source
                Dim dr As DataRow = d.Row
                Dim tx As String
                If displayExpression.IndexOf("{"c) >= 0 Then
                    tx = String.Format(displayExpression, dr.ItemArray)
                Else
                    tx = Convert.ToString(dr(displayExpression))
                End If
                .Items.Add(New ListboxItem(tx, dr))
                If selectedValue IsNot Nothing AndAlso dr(valueMember).Equals(selectedValue) Then
                    .SelectedIndex = .Items.Count - 1
                End If
            Next
            .EndUpdate()
            If defaultSelectFirstItem And .Items.Count > 0 Then
                If .SelectedIndex < 0 Then .SelectedIndex = 0
            End If
        End With
    End Sub

    Public Sub FillCb(ByVal datarows() As DataRow, ByVal cb As ComboBox, ByVal displayExpression As String, ByVal valueMember As String, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False)
        With cb
            .BeginUpdate()
            Dim items As New List(Of ListboxItem)
            If AddEmptyItem Then
                items.Add(New ListboxItem("", Nothing))
            End If
            Dim selectedIndex As Integer = -1
            For Each dr As DataRow In datarows
                Dim tx As String
                If displayExpression.IndexOf("{"c) >= 0 Then
                    tx = String.Format(displayExpression, dr.ItemArray)
                Else
                    tx = Convert.ToString(dr(displayExpression))
                End If
                items.Add(New ListboxItem(tx, dr(valueMember)))
                If selectedValue IsNot Nothing AndAlso dr(valueMember).Equals(selectedValue) Then
                    selectedIndex = items.Count - 1
                End If
            Next
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = items
            .EndUpdate()
            If selectedIndex >= 0 Then
                .SelectedIndex = selectedIndex
            End If
            If defaultSelectFirstItem AndAlso .Items.Count > 0 AndAlso .SelectedIndex < 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
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

Module RegistryUtils
    Private Function GetCle() As String
        Return String.Format("SOFTWARE\{0}\{1}", My.Application.Info.CompanyName, My.Application.Info.ProductName)
    End Function

    Private Function GetCleRegistre() As Microsoft.Win32.RegistryKey
        Return Microsoft.Win32.Registry.LocalMachine.OpenSubKey(GetCle, True)
    End Function

    Private Function CreateCleRegistre() As Microsoft.Win32.RegistryKey
        Return Microsoft.Win32.Registry.LocalMachine.CreateSubKey(GetCle)
    End Function

    Public Function GetValueRegistre(ByVal valueName As String, Optional ByVal defaultValue As String = "") As String
        Dim key As Microsoft.Win32.RegistryKey = GetCleRegistre()
        If Not key Is Nothing Then
            Dim val As String = Convert.ToString(key.GetValue(valueName, defaultValue))
            key.Close()
            Return val
        Else
            Return defaultValue
        End If
    End Function

    Public Sub SetValueRegistre(ByVal valueName As String, ByVal value As String)
        Dim key As Microsoft.Win32.RegistryKey = GetCleRegistre()
        If key Is Nothing Then key = CreateCleRegistre()
        key.SetValue(valueName, value)
        key.Close()
    End Sub
End Module

Module XmlSerializationUtils
    Public Function SerializeToString(Of T)(ByVal obj As T) As String
        Dim sb As New System.Text.StringBuilder
        Using tw As New IO.StringWriter(sb)
            Serialize(Of T)(obj, tw)
        End Using
        Return sb.ToString
    End Function

    Public Sub Serialize(Of T)(ByVal obj As T, ByVal destSw As IO.TextWriter)
        Dim x As New Serialization.XmlSerializer(GetType(T))
        x.Serialize(destSw, obj)
    End Sub

    Public Function DeSerializeFromFile(Of T)(ByVal path As String) As T
        Using sr As New IO.StreamReader(path)
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
        Return Cast(Of T)(x.Deserialize(sourceSr))
    End Function
End Module

Module XsltUtils
    Public Function GetTransformXSLTFile(ByVal xmlInput As String, ByVal XSL_Filename As String) As String
        Dim x As New XmlDocument
        x.InnerXml = xmlInput
        Return GetTransformXSLTFile(x, XSL_Filename)
    End Function

    ''' <summary>
    ''' Transformation XSLT d'un fichier XML
    ''' </summary>
    ''' <param name="reader">Le document XML a transformer</param>
    ''' <param name="XSL_Filename">L'URI serveur du fichier xslt de transformation</param>
    Public Function GetTransformXSLTFile(ByVal reader As XmlDocument, ByVal XSL_Filename As String) As String
        'On charge le fichier XSL dans un XmlDocument
        Dim XSLTDocument As New XmlDocument()
        XSLTDocument.Load(XSL_Filename)

        'Création du lecteur XML
        Dim inputReader As XmlNodeReader = New XmlNodeReader(reader)

        'Création du transformateur XSLT 
        Dim xslt As New XslCompiledTransform()
        xslt.Load(XSLTDocument, Nothing, Nothing)

        'là où sera enregistré la transformation
        Dim TransformOutput As New System.Text.StringBuilder

        'paramètre d'écriture du fichier transformé
        Dim settings As New XmlWriterSettings()
        settings.ConformanceLevel = ConformanceLevel.Auto

        'xslt.OutputSettings correspond aux paramètres <xsl:output> dans votre fichier XSL
        'veillez à bien spécifier la sortie en html <xsl:output method="html" /> autrement
        'c'est "xml" par défaut et les balises vides (exemple <div></div>) seront transformées
        'en (</div>)
        Dim htmlDoc As XmlWriter = XmlWriter.Create(TransformOutput, xslt.OutputSettings)
        xslt.Transform(inputReader, Nothing, htmlDoc, New XmlUrlResolver())
        Return TransformOutput.ToString()
    End Function
End Module

Module DrawingUtils
    Public Sub DrawStringSpaced(ByVal g As Graphics, ByVal s As String, ByVal f As Font, ByVal b As Brush, ByVal r As RectangleF, ByVal sf As StringFormat, ByVal spacing As Single)
        Dim chars() As Char = s.ToCharArray
        Dim offsetLeft As Single = 0
        For Each c As Char In chars
            Dim rect As New RectangleF(r.X + offsetLeft, r.Y, spacing, r.Height)
            If rect.Left - r.X > r.Width Then Exit For
            g.DrawString(c.ToString, f, b, rect, sf)
            offsetLeft += spacing
        Next
    End Sub
End Module

Module XSDUtils
    Public Sub ValiderXml(ByVal fichierXSD As String, ByVal fichierXML As String)
        Dim settings As XmlReaderSettings = New XmlReaderSettings()

        settings.Schemas.Add(Nothing, fichierXSD)
        settings.ValidationType = ValidationType.Schema

        AddHandler settings.ValidationEventHandler, AddressOf XmlValidationError

        Dim reader As XmlReader = XmlReader.Create(fichierXML, settings)

        While (reader.Read())
        End While
    End Sub

    Private Sub XmlValidationError(ByVal sender As Object, ByVal e As ValidationEventArgs)
        ' code à exécuter si erreur à la validation du Xml suivant le schéma Xsd
        ' on passe autant de fois dans ce code qu'il y a d'erreurs
        Dim str As String = e.Exception.Message
    End Sub

End Module

#End Region
