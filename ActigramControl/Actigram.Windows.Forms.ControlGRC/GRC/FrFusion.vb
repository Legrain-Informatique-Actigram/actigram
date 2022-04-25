Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrFusion
    Inherits System.Windows.Forms.Form
    Dim oRpt As ReportDocument
    Dim ds As DataSet
    Dim dv As DataView
    Dim strCheminEtat As String
    Dim strLibelle As String = ""
    Dim strFiltre As String = ""
    Dim strTypePiece As String = ""
    Public Parametres As New ParametresEtat

    Public Shared Server As String = "DELL\ACTIGRAM"
    Public Shared Base As String = "AgriFact2"
    Public Shared sa As String = "sa"
    Public Shared pwd As String = "ludo"
    Private dtDebut As Date
    Private dtFin As Date
    Private _LeftEnTete As Integer = -1
    Private _nCle As Long = -1
    Private _LstCle() As String


#Region "Constructeurs"
    Public Sub New(ByVal momDataset As DataSet)
        Me.New()
        ds = momDataset
    End Sub

    Public Sub New(ByVal momdataset As DataSet, ByVal strEtat As String)
        Me.New(momdataset)
        strCheminEtat = strEtat
    End Sub

    Public Sub New(ByVal momDataset As DataSet, ByVal momEtat As ReportDocument)
        Me.New(momDataset)
        oRpt = momEtat
    End Sub

    Public Sub New(ByVal momDataView As DataView, ByVal momEtat As ReportDocument)
        Me.New(momDataView.Table.DataSet)
        dv = momDataView
        oRpt = momEtat
    End Sub

    Public Sub New(ByVal momDataView As DataView, ByVal strEtat As String)
        Me.New(momDataView.Table.DataSet)
        dv = momDataView
        strCheminEtat = strEtat
    End Sub

    Public Sub New(ByVal momEtat As ReportDocument)
        Me.New()
        oRpt = momEtat
    End Sub

    Public Sub New(ByVal strEtat As String)
        Me.New()
        strCheminEtat = strEtat
    End Sub
#End Region

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
    End Sub



    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayBackgroundEdge = False
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(544, 405)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'FrFusion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(544, 405)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrFusion"
        Me.Text = "Impression"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propriétés"


    Private _logoVisible As Boolean=false
    Public Property LogoVisible() As Boolean
        Get
            Return _logoVisible
        End Get
        Set(ByVal value As Boolean)
            _logoVisible = value
        End Set
    End Property

    Private _titre As String
    Public Property TitreRapport() As String
        Get
            Return _titre
        End Get
        Set(ByVal value As String)
            _titre = value
        End Set
    End Property


    Public Property LstCle() As String()
        Get
            Return _LstCle
        End Get
        Set(ByVal Value As String())
            _LstCle = Value
        End Set
    End Property

    Public Property nCle() As Long
        Get
            Return _nCle
        End Get
        Set(ByVal Value As Long)
            _nCle = Value
        End Set
    End Property

    Public Property LeftEnTete() As Integer
        Get
            Return _LeftEnTete
        End Get
        Set(ByVal Value As Integer)
            _LeftEnTete = Value
        End Set
    End Property

    Public Property DateDebut() As Date
        Get
            Return dtDebut
        End Get
        Set(ByVal Value As Date)
            dtDebut = Value
        End Set
    End Property

    Public Property DateFin() As Date
        Get
            Return dtFin
        End Get
        Set(ByVal Value As Date)
            dtFin = Value
        End Set
    End Property

    Public Property TypePiece() As String
        Get
            Return strTypePiece
        End Get
        Set(ByVal Value As String)
            strTypePiece = Value
        End Set
    End Property

    'Public Property PiedPageDetail() As String
    '    Get
    '        Return strPiedPageDetail
    '    End Get
    '    Set(ByVal Value As String)
    '        strPiedPageDetail = Value
    '    End Set
    'End Property

    'Public Property EnTete() As String
    '    Get
    '        Return strEntete
    '    End Get
    '    Set(ByVal Value As String)
    '        strEntete = Value
    '    End Set
    'End Property

    'Public Property EnTeteDetail() As String
    '    Get
    '        Return strEnteteDetail
    '    End Get
    '    Set(ByVal Value As String)
    '        strEnteteDetail = Value
    '    End Set
    'End Property

    Public Property Filtre() As String
        Get
            Return strFiltre
        End Get
        Set(ByVal Value As String)
            strFiltre = Value
        End Set
    End Property

    Public Property LibelleSelection() As String
        Get
            Return strLibelle
        End Get
        Set(ByVal Value As String)
            strLibelle = Value
        End Set
    End Property

    Public Property Datasource() As Object
        Get
            If Not ds Is Nothing Then : Return ds
            ElseIf Not dv Is Nothing Then : Return dv
            Else : Return Nothing
            End If
        End Get
        Set(ByVal Value As Object)
            If TypeOf Value Is DataSet Then : ds = CType(Value, DataSet)
            ElseIf TypeOf Value Is DataView Then : dv = CType(Value, DataView)
            Else : Throw New ArgumentException
            End If
        End Set
    End Property
#End Region

    Private Sub FrFusion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim fr As New Form
        If fr.Icon.Handle.Equals(Me.Icon.Handle) Then
            Dim frParent As Form = Me.MdiParent
            If frParent Is Nothing Then
                frParent = Me.Owner
            End If
            If Not frParent Is Nothing Then
                Me.Icon = CType(frParent.Icon.Clone, Icon)
            End If
        End If

        ChargerReport()

        'TODO A INCLURE DANS LE PARAMETRAGE IMPRESSION
        If oRpt.FilePath Like "*Guitres\RptFactureVenteHT.rpt" Then
            Dim doctoprint As New System.Drawing.Printing.PrintDocument
            'doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+II ESC/P"
            For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                Dim rawKind As Integer
                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "guitres" Then
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                    oRpt.PrintOptions.PaperSize = CType(rawKind, CrystalDecisions.Shared.PaperSize)
                    Exit For
                End If
            Next
        End If

        Me.CrystalReportViewer1.ReportSource = oRpt
    End Sub

    Private Sub ChargerReport()
        Dim openMethod As OpenReportMethod = OpenReportMethod.OpenReportByTempCopy
        If oRpt Is Nothing Then
            If Not strCheminEtat Is Nothing Then
                oRpt = New ReportDocument
                If IO.Path.IsPathRooted(strCheminEtat) Then
                    oRpt.Load(strCheminEtat, openMethod)
                Else
                    If IO.Directory.Exists(Application.StartupPath & "\Etats") Then
                        If IO.Directory.Exists(Application.StartupPath & "\EtatsServer") Then
                            oRpt.Load(String.Format("{0}\Etats{2}\{1}", Application.StartupPath, strCheminEtat, IIf(ds Is Nothing, "Server", "")), openMethod)
                        Else
                            oRpt.Load(String.Format("{0}\Etats\{1}", Application.StartupPath, strCheminEtat), openMethod)
                        End If
                    Else
                        oRpt.Load(String.Format("{0}\{1}", Application.StartupPath, strCheminEtat), openMethod)
                    End If
                End If
            Else
                Exit Sub
            End If
        End If
        'MsgBox(String.Format("Report '{0}' - IsLoaded={1}", oRpt.FilePath, oRpt.IsLoaded))

        Dim tbCurrent As Table
        Dim tliCurrent As TableLogOnInfo

        If Not dv Is Nothing Then
            oRpt.SetDataSource(dv)
        Else
            If Not ds Is Nothing Then
                'Actigram.Donnees.Utils.DebugDataset(ds)
                oRpt.SetDataSource(ds)
            Else
                For Each tbCurrent In oRpt.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .ServerName = Server
                        .UserID = sa
                        .Password = pwd
                        .DatabaseName = Base
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    If tbCurrent.Location <> "Commande" Then
                        Dim strLoc As String = tbCurrent.Location
                        If strLoc.Split("."c).GetUpperBound(0) >= 2 Then
                            tbCurrent.Location = Base & ".dbo." & strLoc.Split("."c)(2)
                        End If
                    End If
                Next tbCurrent
            End If
        End If

        If strFiltre.Length > 0 Then
            oRpt.RecordSelectionFormula = strFiltre
        End If

        If strLibelle <> "" Then
            Try
                CType(oRpt.ReportDefinition.ReportObjects.Item("TxLibelleSelection"), TextObject).Text = strLibelle
            Catch
            End Try
        End If
        If _LeftEnTete <> -1 Then
            Try
                CType(oRpt.ReportDefinition.ReportObjects.Item("TxEnTete"), FieldObject).Left = _LeftEnTete
                CType(oRpt.ReportDefinition.ReportObjects.Item("TxEnTeteDetail"), FieldObject).Left = _LeftEnTete
            Catch ex As Exception

            End Try
        End If
        Try
            CType(oRpt.ReportDefinition.ReportObjects.Item("Field30"), BlobFieldObject).ObjectFormat.EnableSuppress = Not Me.LogoVisible
        Catch ex As Exception
        End Try

        'Gestion de la position de l'adresse
        Dim posAdresse As New Point
        With posAdresse
            .X = CInt(Me.Parametres.GetValue("AdresseLeft", 110))
            .Y = CInt(Me.Parametres.GetValue("AdresseTop", 50))
        End With
        posAdresse = Actigram.MillimetersToTwips(posAdresse)
        Try
            posAdresse.Y -= oRpt.ReportDefinition.Sections("Section2").Height
        Catch ex As Exception
        End Try

        Try
            With CType(oRpt.ReportDefinition.ReportObjects.Item("Text14"), TextObject)
                .Left = posAdresse.X
                .Top = posAdresse.Y
            End With
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        If Me.TitreRapport IsNot Nothing Then
            oRpt.SummaryInfo.ReportTitle = Me.TitreRapport
        End If


        ''Get the collection of parameters from the report
        For Each crParDef As ParameterFieldDefinition In oRpt.DataDefinition.ParameterFields
            Dim crParValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim crValues As ParameterValues = crParDef.CurrentValues

            Select Case crParDef.Name
                Case "DateDebut"
                    If dtDebut <> Date.MinValue Then
                        crParValue.Value = Me.dtDebut
                    End If
                Case "DateFin"
                    If dtFin <> Date.MinValue Then
                        crParValue.Value = Me.dtFin
                    End If
                Case "TypePiece"
                    crParValue.Value = strTypePiece
                Case "nCle"
                    If _nCle <> -1 Then
                        crParValue.Value = _nCle
                    End If
                Case "Cles"
                    If Not LstCle Is Nothing Then
                        If LstCle.Length > 0 Then
                            For Each cle As String In LstCle
                                crParValue = New ParameterDiscreteValue
                                crParValue.Value = cle
                                crValues.Add(crParValue)
                            Next
                        End If
                    End If
                Case Else
                    Dim val As Object = Me.Parametres.GetValue(crParDef.Name)
                    If Not val Is Nothing Then
                        crParValue.Value = val
                    End If
            End Select

            Try
                ''Add the first current value for the parameter field
                If Not crParValue.Value Is Nothing Then
                    If crValues.Count = 0 Then
                        crValues.Add(crParValue)
                    End If
                    ''All current parameter values must be applied for the parameter field.
                    crParDef.ApplyCurrentValues(crValues)
                End If

            Catch ex As Exception
            End Try
        Next
    End Sub


    Public Sub ImprimerDirectDialog()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim printer As New Printing.PrinterSettings
        Dim page As New Printing.PageSettings

        ChargerReport()
        With oRpt
            PrintOptionsCopyTo(oRpt.PrintOptions, printer, page)
            Dim p As New PrintDialog
            With p
                '.AllowCurrentPage = True
                .AllowSelection = False
                .AllowSomePages = True
                .ShowNetwork = True
                '.UseEXDialog = True
                .PrinterSettings = printer
                If .ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End With
            PrintOptionsCopyFrom(oRpt.PrintOptions, printer, page)

            Dim nStartPage As Integer = -1
            Dim nEndPage As Integer = -1
            Select Case printer.PrintRange
                Case Printing.PrintRange.Selection
                    nStartPage = 1
                    nEndPage = 1
                Case Printing.PrintRange.SomePages
                    nStartPage = printer.FromPage
                    nEndPage = printer.ToPage
            End Select
            .PrintToPrinter(printer.Copies, printer.Collate, nStartPage, nEndPage)
        End With
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

#Region "PrintOptions utils"
    Private Shared Sub PrintOptionsCopyTo(ByVal po As PrintOptions, ByVal printer As Printing.PrinterSettings, ByVal page As Printing.PageSettings)
        With page.Margins
            .Left = po.PageMargins.leftMargin
            .Top = po.PageMargins.topMargin
            .Right = po.PageMargins.rightMargin
            .Bottom = po.PageMargins.bottomMargin
        End With
        page.Landscape = (po.PaperOrientation = PaperOrientation.Landscape)
        'page.PaperSize = ConvertPaperSize(po.PaperSize)
        'page.PaperSource = ConvertPaperSource(po.PaperSource)
        printer.Duplex = ConvertDuplex(po.PrinterDuplex)
        printer.PrinterName = po.PrinterName
    End Sub

    Private Shared Sub PrintOptionsCopyFrom(ByVal po As PrintOptions, ByVal printer As Printing.PrinterSettings, ByVal page As Printing.PageSettings)
        'po.PageContentHeight = page.Bounds.Height
        'po.PageContentWidth = 0
        po.ApplyPageMargins(New PageMargins(page.Margins.Left, page.Margins.Top, page.Margins.Right, page.Margins.Bottom))
        If page.Landscape Then
            po.PaperOrientation = PaperOrientation.Landscape
        Else
            po.PaperOrientation = PaperOrientation.DefaultPaperOrientation
        End If
        'po.PaperSize = ConvertPaperSize(page.PaperSize)
        po.PaperSource = ConvertPaperSource(page.PaperSource.Kind)
        po.PrinterDuplex = ConvertDuplex(printer.Duplex)
        po.PrinterName = printer.PrinterName
    End Sub

    Private Shared Function ConvertDuplex(ByVal d As Printing.Duplex) As PrinterDuplex
        Select Case d
            Case Printing.Duplex.Default : Return PrinterDuplex.Default
            Case Printing.Duplex.Horizontal : Return PrinterDuplex.Horizontal
            Case Printing.Duplex.Simplex : Return PrinterDuplex.Simplex
            Case Printing.Duplex.Horizontal : Return PrinterDuplex.Horizontal
        End Select
    End Function

    Private Shared Function ConvertDuplex(ByVal d As PrinterDuplex) As Printing.Duplex
        Select Case d
            Case PrinterDuplex.Default : Return Printing.Duplex.Default
            Case PrinterDuplex.Horizontal : Return Printing.Duplex.Horizontal
            Case PrinterDuplex.Simplex : Return Printing.Duplex.Simplex
            Case PrinterDuplex.Horizontal : Return Printing.Duplex.Horizontal
        End Select
    End Function

    Private Shared Function ConvertPaperSource(ByVal s As PaperSource) As Printing.PaperSourceKind
        Select Case s
            Case PaperSource.Auto : Return Printing.PaperSourceKind.AutomaticFeed
            Case PaperSource.Cassette : Return Printing.PaperSourceKind.Cassette
            Case PaperSource.Envelope : Return Printing.PaperSourceKind.Envelope
            Case PaperSource.EnvManual : Return Printing.PaperSourceKind.ManualFeed
            Case PaperSource.FormSource : Return Printing.PaperSourceKind.FormSource
            Case PaperSource.LargeCapacity : Return Printing.PaperSourceKind.LargeCapacity
            Case PaperSource.LargeFmt : Return Printing.PaperSourceKind.LargeFormat
            Case PaperSource.Lower : Return Printing.PaperSourceKind.Lower
            Case PaperSource.Manual : Return Printing.PaperSourceKind.Manual
            Case PaperSource.Middle : Return Printing.PaperSourceKind.Middle
            Case PaperSource.SmallFmt : Return Printing.PaperSourceKind.SmallFormat
            Case PaperSource.Tractor : Return Printing.PaperSourceKind.TractorFeed
            Case PaperSource.Upper : Return Printing.PaperSourceKind.Upper
        End Select
    End Function

    Private Shared Function ConvertPaperSource(ByVal s As Printing.PaperSourceKind) As PaperSource
        Select Case s
            Case Printing.PaperSourceKind.AutomaticFeed : Return PaperSource.Auto
            Case Printing.PaperSourceKind.Cassette : Return PaperSource.Cassette
            Case Printing.PaperSourceKind.Envelope : Return PaperSource.Envelope
            Case Printing.PaperSourceKind.ManualFeed : Return PaperSource.EnvManual
            Case Printing.PaperSourceKind.FormSource : Return PaperSource.FormSource
            Case Printing.PaperSourceKind.LargeCapacity : Return PaperSource.LargeCapacity
            Case Printing.PaperSourceKind.LargeFormat : Return PaperSource.LargeFmt
            Case Printing.PaperSourceKind.Lower : Return PaperSource.Lower
            Case Printing.PaperSourceKind.Manual : Return PaperSource.Manual
            Case Printing.PaperSourceKind.Middle : Return PaperSource.Middle
            Case Printing.PaperSourceKind.SmallFormat : Return PaperSource.SmallFmt
            Case Printing.PaperSourceKind.TractorFeed : Return PaperSource.Tractor
            Case Printing.PaperSourceKind.Upper : Return PaperSource.Upper
        End Select
    End Function

    Private Shared Function ConvertPaperSize(ByVal s As Printing.PaperSize) As PaperSize
        Throw New NotImplementedException
    End Function

    Private Shared Function ConvertPaperSize(ByVal s As PaperSize) As Printing.PaperSize
        Throw New NotImplementedException
    End Function
#End Region

    Public Sub ImprimerPDF(Optional ByVal printerName As String = Nothing)
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ChargerReport()

        With oRpt
            .ExportToDisk(ExportFormatType.PortableDocFormat, "C:\test.pdf")
        End With

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Public Sub ImprimerDirectSimple(Optional ByVal printerName As String = Nothing)
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ChargerReport()
        With oRpt
            If Not printerName Is Nothing Then .PrintOptions.PrinterName = printerName
            If .FilePath Like "*Guitres\RptFactureVenteHT.rpt" Then
                Dim doctoprint As New System.Drawing.Printing.PrintDocument
                doctoprint.PrinterSettings.PrinterName = .PrintOptions.PrinterName
                For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                    Dim rawKind As Integer
                    If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "guitres" Then
                        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                        .PrintOptions.PaperSize = CType(rawKind, CrystalDecisions.Shared.PaperSize)
                        Exit For
                    End If
                Next
            End If
            .PrintToPrinter(1, True, 1, -1)
        End With

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

End Class

Public Class ParametresEtat
    Private values As New Hashtable

#Region "Propriétés"
    Private Const ENTETE_KEY As String = "EnTete"
    Public Property EnTete() As String
        Get
            Return CStr(GetValue(ENTETE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(ENTETE_KEY, Value)
        End Set
    End Property

    Private Const ENTETEDETAIL_KEY As String = "EnTeteDetail"
    Public Property EnTeteDetail() As String
        Get
            Return CStr(GetValue(ENTETEDETAIL_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(ENTETEDETAIL_KEY, Value)
        End Set
    End Property

    Private Const PIEDPAGEDETAIL_KEY As String = "PiedPageDetail"
    Public Property PiedPageDetail() As String
        Get
            Return CStr(GetValue(PIEDPAGEDETAIL_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(PIEDPAGEDETAIL_KEY, Value)
        End Set
    End Property

    Private Const INFOLEGALE_KEY As String = "InfoLegale"
    Public Property InfoLegale() As String
        Get
            Return CStr(GetValue(INFOLEGALE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(INFOLEGALE_KEY, Value)
        End Set
    End Property

    Private Const INFOLEGALE2_KEY As String = "InfoLegale2"
    Public Property InfoLegale2() As String
        Get
            Return CStr(GetValue(INFOLEGALE2_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(INFOLEGALE2_KEY, Value)
        End Set
    End Property

    Private Const CODEETABLISSEMENT_KEY As String = "CodeEtablissement"
    Public Property CodeEtablissement() As String
        Get
            Return CStr(GetValue(CODEETABLISSEMENT_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(CODEETABLISSEMENT_KEY, Value)
        End Set
    End Property

    Private Const CODEGUICHET_KEY As String = "CodeGuichet"
    Public Property CodeGuichet() As String
        Get
            Return CStr(GetValue(CODEGUICHET_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(CODEGUICHET_KEY, Value)
        End Set
    End Property

    Private Const NCOMPTE_KEY As String = "NCompte"
    Public Property NCompte() As String
        Get
            Return CStr(GetValue(NCOMPTE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(NCOMPTE_KEY, Value)
        End Set
    End Property

    Private Const CLERIB_KEY As String = "CleRib"
    Public Property CleRIB() As String
        Get
            Return CStr(GetValue(CLERIB_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(CLERIB_KEY, Value)
        End Set
    End Property

    Private Const DOMICILIATION_KEY As String = "Domiciliation"
    Public Property Domiciliation() As String
        Get
            Return CStr(GetValue(DOMICILIATION_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(DOMICILIATION_KEY, Value)
        End Set
    End Property

    Private Const TAUXESCOMPTE_KEY As String = "TauxEscompte"
    Public Property TauxEscompte() As String
        Get
            Return CStr(GetValue(TAUXESCOMPTE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(TAUXESCOMPTE_KEY, Value)
        End Set
    End Property

    Private Const DELAIVALIDITEESCOMPTE_KEY As String = "DelaiValiditeEscompte"
    Public Property DelaiValiditeEscompte() As String
        Get
            Return CStr(GetValue(DELAIVALIDITEESCOMPTE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(DELAIVALIDITEESCOMPTE_KEY, Value)
        End Set
    End Property

    Private Const IBANSWIFT_KEY As String = "IBANSWIFT"
    Public Property IBANSWIFT() As String
        Get
            Return CStr(GetValue(IBANSWIFT_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(IBANSWIFT_KEY, Value)
        End Set
    End Property

    Private Const MODERGTPARDEF_KEY As String = "ModeRgtParDef"
    Public Property ModeRgtParDef() As String
        Get
            Return CStr(GetValue(MODERGTPARDEF_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(MODERGTPARDEF_KEY, Value)
        End Set
    End Property

    Private Const NOMABREGEENTITE_KEY As String = "NomAbregeEntite"
    Public Property NomAbregeEntite() As String
        Get
            Return CStr(GetValue(NOMABREGEENTITE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(NOMABREGEENTITE_KEY, Value)
        End Set
    End Property

    Private Const ECHEANCEVISIBLE_KEY As String = "EcheanceVisible"
    Public Property EcheanceVisible() As String
        Get
            Return CStr(GetValue(ECHEANCEVISIBLE_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(ECHEANCEVISIBLE_KEY, Value)
        End Set
    End Property

    Private Const CODEPAYSIBAN_KEY As String = "CodePaysIBAN"
    Public Property CodePaysIBAN() As String
        Get
            Return CStr(GetValue(CODEPAYSIBAN_KEY, ""))
        End Get
        Set(ByVal Value As String)
            SetValue(CODEPAYSIBAN_KEY, Value)
        End Set
    End Property


#End Region

    Public Function GetValue(ByVal key As String, Optional ByVal defaultValue As Object = Nothing) As Object
        If values.Contains(key) Then
            Return values(key)
        Else
            Return defaultValue
        End If
    End Function

    Public Sub SetValue(ByVal key As String, ByVal value As Object)
        If values.Contains(key) Then
            values(key) = value
        Else
            values.Add(key, value)
        End If
    End Sub

End Class