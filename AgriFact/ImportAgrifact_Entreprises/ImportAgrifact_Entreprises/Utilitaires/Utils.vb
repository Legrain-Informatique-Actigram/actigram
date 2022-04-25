Namespace Utilitaires
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

        Public Sub New(ByVal s As String)
            MyBase.New(s)
        End Sub

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
#End Region

#Region " Modules "
    Module DecimalUtils
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

    Module IOUtils
        Public Sub OpenMail(ByVal mail As String)
            If mail.Length = 0 Then Exit Sub
            Process.Start(String.Format("mailto:{0}", mail))
        End Sub

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

        Public Function CheminComplet(ByVal fichier As String) As String
            If IO.Path.IsPathRooted(fichier) Then
                Return fichier
            Else
                Return IO.Path.Combine(My.Application.Info.DirectoryPath, fichier)
            End If
        End Function

        Public Sub OuvrirFichier(ByVal chemin As String, Optional ByVal verb As String = Nothing, Optional ByVal arguments As String = "")
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
    End Module

    Module GenericsUtils
        Public Function Cast(Of T)(ByVal o As Object) As T
            Return DirectCast(o, T)
        End Function

        Public Function EnumParse(Of T)(ByVal name As String) As T
            Return CType([Enum].Parse(GetType(T), name), T)
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
            If Not GetType(T).IsSubclassOf(GetType(DataRow)) Then Throw New InvalidCastException("Le type de destination doit hériter de Datarow")
            If dt Is Nothing Then Return Nothing
            Dim rws() As DataRow = dt.Select(query, sort)
            If rws.Length = 0 Then
                Return Nothing
            Else
                Return Cast(Of T)(rws(0))
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
                If Not dc.ReadOnly AndAlso Not dc.AutoIncrement Then
                    drDest(dc.ColumnName) = drSource(dc.ColumnName)
                End If
            Next
        End Sub
    End Module

    Module FormsUtils

        Private defaultIconHandle As IntPtr = IntPtr.Zero

        Public Sub SetChildFormIcon(ByVal fr As Form)
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
                End If
                If parentForm IsNot Nothing Then
                    fr.Icon = parentForm.Icon
                End If
            End If
        End Sub

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

        Public Sub FillCb(ByVal source As BindingSource, ByVal cb As ToolStripComboBox, ByVal displayExpression As String, ByVal valueMember As String, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean)
            With cb
                .BeginUpdate()
                .Items.Clear()
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
    End Module

    'Module BarCodeUtils
    '    Public Function FormatterCodeBarre(ByVal code As String) As String
    '        If code Is Nothing Then Return Nothing
    '        code = code.PadLeft(12, "0"c)
    '        Return CodeBarreC(code)
    '    End Function

    '    Private Function CodeBarreC(ByVal str As String) As String
    '        Dim result As String = ""
    '        Dim startC As String = Chr(171)
    '        Dim carStop As String = Chr(172)
    '        Dim chk As Integer = 105

    '        For i As Integer = 0 To Len(str) \ 2 - 1
    '            Dim digit As Integer = Integer.Parse(str.Substring(i * 2, 2))
    '            result &= encode(digit)
    '            chk = chk + (i + 1) * digit
    '        Next
    '        chk = chk Mod 103
    '        Return startC & result & encode(chk) & carStop
    '    End Function

    '    Private Function encode(ByVal digit As Integer) As String
    '        Dim result As String = ""
    '        Select Case digit
    '            Case 0 : result = Chr(174)
    '            Case 1 To 94 : result = Chr(digit + 32)
    '            Case 95 To 106 : result = Chr(digit + 66)
    '        End Select
    '        Return result
    '    End Function
    'End Module

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

    'Module XmlUtils
    '    Public Function GetTransformXSLTFile(ByVal xmlInput As String, ByVal XSL_Filename As String) As String
    '        Dim x As New XmlDocument
    '        x.InnerXml = xmlInput
    '        Return GetTransformXSLTFile(x, XSL_Filename)
    '    End Function

    '    ''' <summary>
    '    ''' Transformation XSLT d'un fichier XML
    '    ''' </summary>
    '    ''' <param name="reader">Le document XML a transformer</param>
    '    ''' <param name="XSL_Filename">L'URI serveur du fichier xslt de transformation</param>
    '    Public Function GetTransformXSLTFile(ByVal reader As XmlDocument, ByVal XSL_Filename As String) As String
    '        'On charge le fichier XSL dans un XmlDocument
    '        Dim XSLTDocument As New XmlDocument()
    '        XSLTDocument.Load(XSL_Filename)

    '        'Création du lecteur XML
    '        Dim inputReader As XmlNodeReader = New XmlNodeReader(reader)

    '        'Création du transformateur XSLT 
    '        Dim xslt As New XslCompiledTransform()
    '        xslt.Load(XSLTDocument, Nothing, Nothing)

    '        'là où sera enregistré la transformation
    '        Dim TransformOutput As New System.Text.StringBuilder

    '        'paramètre d'écriture du fichier transformé
    '        Dim settings As New XmlWriterSettings()
    '        settings.ConformanceLevel = ConformanceLevel.Auto

    '        'xslt.OutputSettings correspond aux paramètres <xsl:output> dans votre fichier XSL
    '        'veillez à bien spécifier la sortie en html <xsl:output method="html" /> autrement
    '        'c'est "xml" par défaut et les balises vides (exemple <div></div>) seront transformées
    '        'en (</div>)
    '        Dim htmlDoc As XmlWriter = XmlWriter.Create(TransformOutput, xslt.OutputSettings)
    '        xslt.Transform(inputReader, Nothing, htmlDoc, New XmlUrlResolver())
    '        Return TransformOutput.ToString()
    '    End Function
    'End Module

    Module BaseUtils
        Public Sub SetConnString(ByVal [property] As String, ByVal connString As String)
            My.Settings.SetUserOverride([property], connString)
        End Sub
    End Module

#End Region
End Namespace
