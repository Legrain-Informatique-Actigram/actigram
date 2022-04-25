Imports System.Xml
Imports System.Data.OleDb

#Region "Classes"
Public Class ListboxItem

#Region "Propriétés"
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
#End Region

#Region "Constructeurs"
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
#End Region

#Region "Méthodes diverses"
    Public Overrides Function ToString() As String
        Return Text
    End Function
#End Region

End Class

Public Class UserCancelledException
    Inherits ApplicationException

#Region "Constructeurs"
    Public Sub New(ByVal s As String)
        MyBase.New(s)
    End Sub
#End Region

End Class

Public Class DataValidationException
    Inherits Data.DataException

#Region "Propriétés"
    Private _columnName As String
    Public Property ColumnName() As String
        Get
            Return _columnName
        End Get
        Set(ByVal value As String)
            _columnName = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String, ByVal columnName As String)
        MyBase.New(message)
        Me.ColumnName = columnName
    End Sub
#End Region

End Class

Public Class CommandParam

    Public Name As String
    Public Value As String

#Region "Constructeurs"
    Public Sub New()
    End Sub

    Public Sub New(ByVal arg As String)
        Dim c As CommandParam = Parse(arg)
        Me.Name = c.Name
        Me.Value = c.Value
    End Sub
#End Region

#Region "Méthodes partagées"""
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
#End Region

End Class

''' <summary>
''' Class permettant de gérer les informations principale lier à un dossier 
''' </summary>
''' <remarks></remarks>
Public Class DossierPrincipal
    Inherits Security.Principal.GenericPrincipal

#Region "Props"
    Private sNomExploi1 As String
    Public Property NomExploi1() As String
        Get
            Return sNomExploi1
        End Get
        Set(ByVal value As String)
            sNomExploi1 = value
        End Set
    End Property

    Private sNomExploi2 As String
    Public Property NomExploi2() As String
        Get
            Return sNomExploi2
        End Get
        Set(ByVal value As String)
            sNomExploi2 = value
        End Set
    End Property

    Private dtDateClotureCompta As Date
    Public Property DateClotureCompta() As Date
        Get
            Return dtDateClotureCompta
        End Get
        Set(ByVal value As Date)
            dtDateClotureCompta = value
        End Set
    End Property

    ''' <summary>
    ''' propriété pour savoir si le dossier est cloturé
    ''' </summary>
    ''' <remarks>Attention il est possible de saisir des pièces même si c'est cloturé car la date 
    ''' est encore dans l'exercice du dossier, celui ci doit etre supérieur à la date de cloture pour 
    ''' qu'il y ai le blocage</remarks>
    Private _IsComptaCloture As Boolean
    Public ReadOnly Property IsComptaCloture() As Boolean
        Get
            If DateClotureCompta = Nothing OrElse DateClotureCompta = Date.MinValue OrElse DateClotureCompta >= Today Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    Private dtDateDebutEx As Date
    Public Property DateDebutEx() As Date
        Get
            Return dtDateDebutEx
        End Get
        Set(ByVal value As Date)
            dtDateDebutEx = value
        End Set
    End Property

    Private dtDateFinEx As Date
    Public Property DateFinEx() As Date
        Get
            Return dtDateFinEx
        End Get
        Set(ByVal value As Date)
            dtDateFinEx = value
        End Set
    End Property

    Private _lettrePlanType As String
    Public Property LettrePlanType() As String
        Get
            Return _lettrePlanType
        End Get
        Set(ByVal value As String)
            _lettrePlanType = value
        End Set
    End Property

    Private _cExpl As String
    Public Property CodeExpl() As String
        Get
            Return _cExpl
        End Get
        Set(ByVal value As String)
            _cExpl = value
        End Set
    End Property

    Private _sJournalAN As String
    Public Property JournalAN() As String
        Get
            If _sJournalAN Is Nothing Then
                Using dta As New dbDonneesDataSetTableAdapters.JournalTableAdapter
                    Dim dt As dbDonneesDataSet.JournalDataTable = dta.GetDataByType("an")
                    If dt.Count > 0 Then
                        _sJournalAN = dt(0).JCodeJournal
                    End If
                End Using
            End If
            Return _sJournalAN
        End Get
        Set(ByVal value As String)
            _sJournalAN = value
        End Set
    End Property

    Private _IncrementationPiece As Integer
    ''' <summary>
    ''' Donne le type d'incrémentation du journal
    ''' </summary>
    Public Property IncrementationPiece() As Integer
        Get
            Return _IncrementationPiece
        End Get
        Set(ByVal value As Integer)
            _IncrementationPiece = value
        End Set
    End Property

    Private _exportComplet As Boolean
    ''' <summary>
    ''' Si vrai, l'option pour exporter tout le dossier est cochée par défaut
    ''' </summary>
    Public Property ExportComplet() As Boolean
        Get
            Return _exportComplet
        End Get
        Set(ByVal value As Boolean)
            _exportComplet = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' constructeur et initialisation des données à Zéro pour un dossier
    ''' </summary>
    ''' <param name="NameDossier">Nom du dossier</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal NameDossier As String)
        MyBase.New(New Security.Principal.GenericIdentity(NameDossier), Nothing)
        Me.DateDebutEx = Date.MinValue
        Me.DateFinEx = Date.MinValue
        Me.DateClotureCompta = Date.MinValue
        Me.NomExploi1 = Nothing
        Me.NomExploi2 = Nothing
        Me.CodeExpl = Nothing
        Me.IncrementationPiece = 0
        Me.ExportComplet = True
    End Sub

    ''' <summary>
    ''' constructeur alimentant la class à partir des lignes de dossier, d'exploitation et de journal
    ''' </summary>
    ''' <param name="xRowDossier">Ligne du dossier</param>
    ''' <param name="xRowExploitation">ligne de l'exploitation</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal xRowDossier As dbDonneesDataSet.DossiersRow, ByVal xRowExploitation As dbDonneesDataSet.ExploitationsRow)
        MyBase.New(New Security.Principal.GenericIdentity(xRowDossier.DDossier), Nothing)
        With Me
            .DateDebutEx = xRowDossier.DDtDebEx
            If Not xRowDossier.IsDDtFinExNull Then .DateFinEx = xRowDossier.DDtFinEx
            If Not xRowDossier.IsDDtArreteNull Then .DateClotureCompta = xRowDossier.DDtArrete
            If Not xRowDossier.IsDBqFolio1Null Then .IncrementationPiece = xRowDossier.DBqFolio1
            If Not xRowDossier.IsDCptOuvertNull Then .ExportComplet = (xRowDossier.DCptOuvert <> 0) Else .ExportComplet = True
            If Not xRowExploitation.IsENom1Null Then .NomExploi1 = xRowExploitation.ENom1
            If Not xRowExploitation.IsENom2Null Then .NomExploi2 = xRowExploitation.ENom2
            .LettrePlanType = xRowExploitation.EType
            .CodeExpl = xRowExploitation.EExpl
        End With
    End Sub

    Public Sub New(ByVal xRowDossier As dbSauvRest.DossiersRow, ByVal xRowExploitation As dbSauvRest.ExploitationsRow)
        MyBase.New(New Security.Principal.GenericIdentity(xRowDossier.DDossier), Nothing)
        With Me
            .DateDebutEx = xRowDossier.DDtDebEx
            If Not xRowDossier.IsDDtFinExNull Then .DateFinEx = xRowDossier.DDtFinEx
            If Not xRowDossier.IsDDtArreteNull Then .DateClotureCompta = xRowDossier.DDtArrete
            If Not xRowDossier.IsDBqFolio1Null Then .IncrementationPiece = xRowDossier.DBqFolio1
            If Not xRowDossier.IsDCptOuvertNull Then .ExportComplet = (xRowDossier.DCptOuvert <> 0) Else .ExportComplet = True
            If Not xRowExploitation.IsENom1Null Then .NomExploi1 = xRowExploitation.ENom1
            If Not xRowExploitation.IsENom2Null Then .NomExploi2 = xRowExploitation.ENom2
            .LettrePlanType = xRowExploitation.EType
            .CodeExpl = xRowExploitation.EExpl
        End With
    End Sub
#End Region

End Class

''' <summary>
''' Class permettant de réaliser un CheckBox dans la barre du tool 
''' </summary>
''' <remarks></remarks>
Class ToolStripCheckBox
    Inherits System.Windows.Forms.ToolStripControlHost

#Region "Constructeurs"
    Public Sub New()
        MyBase.New(New System.Windows.Forms.CheckBox())
    End Sub
#End Region

#Region "Proriétés"
    ''' <summary>
    ''' propriété permettant de retourner le checkbox
    ''' </summary>
    ''' <returns>checkbox</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ToolStripCheckBoxControl() As CheckBox
        Get
            Return TryCast(Control, CheckBox)
        End Get
    End Property

    ''' <summary>
    ''' permet de gérer l'état d'activation de la case à cocher
    ''' </summary>
    ''' <value>boolean</value>
    ''' <returns>boolean</returns>
    ''' <remarks></remarks>
    Public Property ToolStripCheckBoxEnabled() As Boolean
        Get
            Return ToolStripCheckBoxControl.Enabled
        End Get
        Set(ByVal value As Boolean)
            ToolStripCheckBoxControl.Enabled = value
        End Set
    End Property
#End Region

End Class

Public Class FormatBinding
    Inherits Binding

    Public NullValue As Object
    Public FormatString As String = ""
    Public FormattingEnabled As Boolean = False

    Public Sub New(ByVal propertyName As String, ByVal datasource As Object, ByVal dataMember As String, Optional ByVal FormatString As String = Nothing, Optional ByVal NullValue As Object = Nothing)
        MyBase.New(propertyName, datasource, dataMember)
        If Not FormatString Is Nothing Then
            Me.FormatString = FormatString
            Me.FormattingEnabled = True
        End If
        Me.NullValue = NullValue
    End Sub

    Protected Overrides Sub OnFormat(ByVal cevent As System.Windows.Forms.ConvertEventArgs)
        If IsDBNull(cevent.Value) AndAlso Not NullValue Is Nothing Then
            cevent.Value = NullValue
        End If
        If FormattingEnabled Then
            cevent.Value = String.Format("{0:" & Me.FormatString & "}", cevent.Value)
        Else
            MyBase.OnFormat(cevent)
        End If
    End Sub

    'Protected Overrides Sub OnParse(ByVal cevent As System.Windows.Forms.ConvertEventArgs)
    '    Try
    '        If Not NullValue Is Nothing AndAlso cevent.Value = NullValue Then
    '            cevent.Value = DBNull.Value
    '        End If
    '    Catch
    '    End Try
    '    MyBase.OnParse(cevent)
    'End Sub
End Class
#End Region

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
        Return DirectCast(x.Deserialize(sourceSr), T)
    End Function
End Module

Module Utils

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
        'If smallFont Then
        'fr.Font = New Font(SystemFonts.CaptionFont.FontFamily, 8.25!)
        'Else
        'fr.Font = SystemFonts.CaptionFont
        'End If
    End Sub

    Public Function Max(ByVal date1 As Date, ByVal date2 As Date) As Date
        If date1 >= date2 Then
            Return date1
        Else
            Return date2
        End If
    End Function

    Public Function Min(ByVal date1 As Date, ByVal date2 As Date) As Date
        If date1 <= date2 Then
            Return date1
        Else
            Return date2
        End If
    End Function

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

    Public Sub FillCb(ByVal t As Type, ByVal cb As ComboBox, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean)
        With cb
            .BeginUpdate()
            Dim items As New List(Of ListboxItem)
            For Each v As Object In [Enum].GetValues(t)
                items.Add(New ListboxItem(v.ToString, CInt(v)))
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

    Public Sub FillCb(ByVal source As BindingSource, ByVal cb As ToolStripComboBox, ByVal displayExpression As String, ByVal valueExpression As String, ByVal defaultSelectFirstItem As Boolean)
        With cb
            .BeginUpdate()
            .Items.Clear()
            For Each d As DataRowView In source
                Dim dr As DataRow = d.Row
                Dim tx As String
                Dim vl As String
                If displayExpression.IndexOf("{"c) >= 0 Then
                    tx = String.Format(displayExpression, dr.ItemArray)
                    vl = String.Format(valueExpression, dr.ItemArray)
                Else
                    tx = Convert.ToString(dr(displayExpression))
                    vl = Convert.ToString(dr(valueExpression))
                End If
                .Items.Add(New ListboxItem(tx, vl))
            Next
            .EndUpdate()
            If defaultSelectFirstItem And .Items.Count > 0 Then
                If .SelectedIndex < 0 Then .SelectedIndex = 0
            End If
        End With
    End Sub

    Public Sub ConfigNumericControl(ByVal c As Control)
        AddHandler c.KeyPress, AddressOf NumericControlKeyPress
    End Sub

    Public Sub ConfigNumericControl(ByVal c As ToolStripControlHost)
        AddHandler c.KeyPress, AddressOf NumericControlKeyPress
    End Sub

    Public Sub NumericControlKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not IsValidForNumberInput(e.KeyChar) Then e.Handled = True
    End Sub

    Public Function IsValidForNumberInput(ByVal c As Char) As Boolean
        Return Char.IsDigit(c) OrElse Char.IsControl(c) OrElse Char.IsPunctuation(c) OrElse c = "+"
    End Function

    Public Sub FormatFileSize(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Select Case e.DesiredType.Name
            Case "String"
                e.Value = FormatFileSize(CLng(e.Value))
        End Select
    End Sub

    Public Function FormatFileSize(ByVal filelength As Long) As String
        Dim l As Double = CDbl(filelength)
        Dim units() As String = {"o", "ko", "Mo", "Go"}
        Dim i As Integer = 0
        While l > 1024D And i < units.Length - 1
            l = l / 1024D
            i += 1
        End While
        Return String.Format("{0:N} {1}", l, units(i))
    End Function

    Public Sub ConfigDecimalControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "N" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf DecimalParse
        End With
    End Sub

    Public Sub ConfigPercentControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "P" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf PercentParse
        End With
    End Sub

    Public Sub ConfigCurrencyControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        With c.DataBindings("Text")
            .FormatString = "C" & decimals
            .FormattingEnabled = True
            AddHandler .Parse, AddressOf CurrencyParse
        End With
    End Sub

    Public Sub CurrencyParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Select Case e.DesiredType.Name
            Case "Decimal", "Single", "Double"
                Dim s As String = Convert.ToString(e.Value).Replace(My.Application.Culture.NumberFormat.CurrencySymbol, "")
                Dim d As Nullable(Of Decimal) = DecimalParse(s)
                If d.HasValue Then
                    e.Value = d.Value
                End If
        End Select
    End Sub

    Public Function CurrencyParse(ByVal s As String) As Decimal
        If s Is Nothing Then s = ""
        s = s.Replace(Application.CurrentCulture.NumberFormat.CurrencySymbol, "")
        Return CDec(DecimalParse(s))
    End Function

    Public Function DecimalParse(ByVal s As String) As Nullable(Of Decimal)
        Dim d As New Nullable(Of Decimal)
        s = s.Replace(",", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        s = s.Replace(".", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        Dim d1 As Decimal
        If Decimal.TryParse(s, d1) Then
            d = d1
        End If
        Return d
    End Function

    Public Sub DecimalParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Select Case e.DesiredType.Name
            Case "Decimal", "Single", "Double"
                Dim d As Nullable(Of Decimal) = DecimalParse(Convert.ToString(e.Value))
                If d.HasValue Then
                    e.Value = d.Value
                End If
        End Select
    End Sub

    Public Sub ConfigUnboundCurrencyControl(ByVal c As Control, Optional ByVal decimals As Integer = 2)
        AddHandler c.KeyPress, AddressOf NumericKeyPressHandler
        AddHandler c.Validating, AddressOf CurrencyValidating
    End Sub

    Private Sub NumericKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Not IsValidForNumberInput(e.KeyChar)
    End Sub

    Private Sub CurrencyValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim s As String = CType(sender, Control).Text.Trim
        If s.Length = 0 Then Exit Sub

        Dim d As Decimal = CurrencyParse(s)
        If d = Decimal.MinValue Then
            e.Cancel = True
        Else
            CType(sender, Control).Text = d.ToString("C2")
        End If
    End Sub

    Public Sub PercentParse(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Select Case e.DesiredType.Name
            Case "Decimal", "Single", "Double"
                Dim s As String = Convert.ToString(e.Value).Replace("%", "")
                Dim d As Nullable(Of Decimal) = DecimalParse(s)
                If d.HasValue Then
                    e.Value = d.Value
                End If
        End Select
    End Sub

    Public Function Days360(ByVal startDate As Date, ByVal endDate As Date) As Integer
        Dim sDay As Integer = startDate.Day
        Dim eDay As Integer = endDate.Day
        'Dim sfend As Boolean = FebEnd(startDate) 'function used twice so set temp var
        'If sfend Then sDay = 30
        If sDay = 31 OrElse FebEnd(startDate) Then sDay = 30
        If eDay = 31 OrElse FebEnd(endDate) Then eDay = 30
        'If sDay >= 30 AndAlso (eDay = 31 OrElse (sfend AndAlso eDay >= 30)) Then eDay = 30
        Return 360 * (endDate.Year - startDate.Year) + 30 * (endDate.Month - startDate.Month) + (eDay - sDay)
    End Function

    Private Function FebEnd(ByVal Date1 As Date) As Boolean
        If Date1.Month = 2 Then
            Select Case Date1.Day
                Case 29 : Return True
                Case 28 : Return Not DateTime.IsLeapYear(Date1.Year)
                Case Else : Return False
            End Select
        Else
            Return False
        End If
    End Function

    Public Function FormatEach(ByVal list As IList, ByVal format As String) As List(Of String)
        Dim res As New List(Of String)
        For Each value As Object In list
            res.Add(String.Format(format, value))
        Next
        Return res
    End Function

    Public Function SelectDistinct(Of T)(ByVal dt As DataTable, ByVal columnname As String) As List(Of T)
        If Not dt.Columns(columnname).DataType Is GetType(T) Then
            Throw New ApplicationException("le type ne correspond pas")
        End If
        Dim res As New List(Of T)
        For Each r As DataRow In dt.Rows
            If Not IsDBNull(r(columnname)) Then
                Dim value As T = CType(r(columnname), T)
                If Not res.Contains(value) Then
                    res.Add(value)
                End If
            End If
        Next
        Return res
    End Function

    Public Function EnumParse(Of T)(ByVal name As String) As T
        Return CType([Enum].Parse(GetType(T), name), T)
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

    Public Function CheminComplet(ByVal fichier As String) As String
        fichier = fichier.Replace("|DataDirectory|", My.Application.Info.DirectoryPath)
        If IO.Path.IsPathRooted(fichier) Then
            Return fichier
        Else
            Return IO.Path.Combine(My.Application.Info.DirectoryPath, fichier)
        End If
    End Function

    Public Function CompterLignes(ByVal fichier As String) As Integer
        Dim i As Integer = 0
        Using sr As New IO.StreamReader(fichier)
            While sr.ReadLine IsNot Nothing
                i += 1
            End While
        End Using
        Return i
    End Function

    Public Sub DeleteDataRow(ByVal dr As DataRow)
        dr.Delete()
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

    Public Function GenerateUniqueFilename(ByVal path As String) As String
        Dim res As String = path
        If IO.File.Exists(res) Then
            Dim i As Integer = 0
            Dim dir As String = IO.Path.GetDirectoryName(res)
            Dim name As String = IO.Path.GetFileNameWithoutExtension(res)
            Dim ext As String = IO.Path.GetExtension(res)
            Do
                i += 1
                res = String.Format("{0}\{1} ({2}){3}", dir, name, i, ext)
            Loop While IO.File.Exists(res)
        End If
        Return res
    End Function

    Public Function OuvrirFichier(ByVal chemin As String, Optional ByVal verb As String = Nothing, Optional ByVal arguments As String = Nothing, Optional ByVal hideError As Boolean = False) As Boolean
        If Not IO.Path.IsPathRooted(chemin) Then
            chemin = IO.Path.Combine(AppDirPath, chemin)
        End If
        If Not IO.File.Exists(chemin) AndAlso Not IO.Directory.Exists(chemin) Then
            MsgBox("Fichier ou répertoire introuvable", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        Try
            If verb Is Nothing Then
                If arguments Is Nothing Then
                    Process.Start(chemin)
                Else
                    Process.Start(chemin, arguments)
                End If
            Else
                Dim pi As New ProcessStartInfo(chemin)
                pi.Arguments = arguments
                pi.Verb = verb
                pi.UseShellExecute = True
                Process.Start(pi)
            End If
            Return True
        Catch ex As Exception
            LogException(ex)
            If Not hideError Then MsgBox("Erreur : " & ex.Message)
            Return False
        End Try
    End Function

    Public Function AppDirPath() As String
        Dim res As String = My.Application.Info.DirectoryPath
        If Not IO.Directory.Exists(res) Then
            Return IO.Path.GetDirectoryName(res)
        Else
            Return res
        End If
    End Function

    Public Function GetDate(ByVal sdate As String) As Date
        Return Date.ParseExact(sdate.Trim, "ddMMyyyy", My.Application.Culture.DateTimeFormat)
    End Function

    Public Function NullabilifyDate(ByVal dt As Date) As Nullable(Of Date)
        Dim res As New Nullable(Of Date)
        If dt > Date.MinValue Then
            res = dt
        End If
        Return res
    End Function

End Module

Module DAOUtils
    Public Function ConnectionEstValide(ByVal connString As String) As Boolean
        Dim oleDbConn As OleDbConnection = Nothing

        Try
            oleDbConn = New OleDbConnection(connString)

            oleDbConn.Open()

            Return True
        Catch ex As OleDbException
            MsgBox("Connexion à la base de données impossible : " & ex.Message, MsgBoxStyle.Critical, "Erreur")

            Return False
        Finally
            If Not (oleDbConn Is Nothing) Then
                oleDbConn.Close()
                oleDbConn = Nothing
            End If
        End Try
    End Function

    Public Function GetConnStringAccess(ByVal dataSource As String) As String
        Dim builder As New OleDbConnectionStringBuilder()

        builder.DataSource = dataSource
        builder("Provider") = "Microsoft.Jet.OLEDB.4.0"

        Return builder.ConnectionString
    End Function

    Public Function GetDataSource(ByVal connString As String) As String
        Dim builder As New OleDbConnectionStringBuilder(connString)

        Return builder.DataSource
    End Function
End Module

Public Class AgriTools

#Region "Méthodes partagées"
    ''' <summary>
    ''' permet de retourner une table Distint provenant d'un autre table en faisant passer la colonne a filtrer
    ''' </summary>
    ''' <param name="sourceTable">Table contenant les informations</param>
    ''' <param name="sourceColumn">Colonne de filtrage</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SelectDistinct(ByVal sourceTable As DataTable, ByVal sourceColumn As String) As DataTable
        Dim result As DataTable = Nothing
        Try
            result = New DataTable
            result.Columns.Add(sourceColumn, sourceTable.Columns(sourceColumn).DataType)
            Dim ht As Hashtable = New Hashtable
            For Each dr As DataRow In sourceTable.Rows
                If Not ht.ContainsKey(dr(sourceColumn)) Then
                    ht.Add(dr(sourceColumn), Nothing)
                    Dim newRow As DataRow = result.NewRow
                    newRow(sourceColumn) = dr(sourceColumn)
                    result.Rows.Add(newRow)
                End If
            Next
            Return result
        Catch ex As System.Exception
            Return Nothing
        Finally
            If (Not (result) Is Nothing) Then
                result.Dispose()
            End If
        End Try
    End Function

    ''' <summary>
    ''' permet de retourner une table Distint sur deux colonnes provenant d'un autre table en faisant passer la colonne a filtrer
    ''' </summary>
    ''' <param name="sourceTable">Table contenant les informations</param>
    ''' <param name="sourceColumn1">Première colonne de filtrage</param>
    ''' <param name="sourceColumn2">Seconde colonne de filtrage</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SelectDistinct(ByVal sourceTable As DataTable, ByVal sourceColumn1 As String, ByVal sourceColumn2 As String) As DataTable
        Dim result As DataTable = Nothing
        Try
            result = New DataTable
            result.Columns.Add(sourceColumn1, sourceTable.Columns(sourceColumn1).DataType)
            result.Columns.Add(sourceColumn2, sourceTable.Columns(sourceColumn2).DataType)
            Dim ht As Hashtable = New Hashtable
            For Each dr As DataRow In sourceTable.Rows
                If Not ht.ContainsKey(dr(sourceColumn1).ToString + "-" + dr(sourceColumn2).ToString) Then
                    ht.Add(dr(sourceColumn1).ToString + "-" + dr(sourceColumn2).ToString, Nothing)
                    Dim newRow As DataRow = result.NewRow
                    newRow(sourceColumn1) = dr(sourceColumn1)
                    newRow(sourceColumn2) = dr(sourceColumn2)
                    result.Rows.Add(newRow)
                End If
            Next
            Return result
        Catch ex As System.Exception
            Return Nothing
        Finally
            If (Not (result) Is Nothing) Then
                result.Dispose()
            End If
        End Try
    End Function
#End Region

End Class
