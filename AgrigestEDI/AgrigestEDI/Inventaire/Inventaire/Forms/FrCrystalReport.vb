Imports CrystalDecisions.CrystalReports.Engine

Public Class FrCrystalReport
    Private _RptDocument As ReportDocument

#Region "Constructeur"
    Public Sub New(ByVal rptDoc As ReportDocument)
        Me.New()
        Me._RptDocument = rptDoc
    End Sub
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CrystalReportViewer1.ReportSource = Me._RptDocument
    End Sub
#End Region

#Region " Shared "
    Public Shared Sub PrechargementAsync()
        Dim th As New Threading.Thread(AddressOf Prechargement)
        th.Start()
    End Sub

    Public Shared Sub Prechargement()
        Using fr As New FrCrystalReport(ChargerReport("dummy.rpt", New AgrigestDataSet))
            With fr
                .WindowState = FormWindowState.Minimized
                .Show()
            End With
        End Using
    End Sub

    Public Shared Sub Imprimer(ByVal nomReport As String, ByVal datasource As Object, Optional ByVal titre As String = Nothing)
        Cursor.Current = Cursors.WaitCursor

        Dim printer As New Printing.PrinterSettings
        Dim page As New Printing.PageSettings

        Using report As ReportDocument = ChargerReport(nomReport, datasource, titre)
            With report
                .PrintOptions.CopyTo(printer, page)
                Using p As New PrintDialog
                    With p
                        .AllowCurrentPage = True
                        .AllowSelection = False
                        .AllowSomePages = True
                        .ShowNetwork = True
                        .UseEXDialog = True
                        .PrinterSettings = printer
                        If .ShowDialog = Windows.Forms.DialogResult.Cancel Then
                            Exit Sub
                        End If
                    End With
                End Using
                .PrintOptions.CopyFrom(printer, page)
                Dim nStartPage As Integer = -1
                Dim nEndPage As Integer = -1
                Select Case printer.PrintRange
                    Case Printing.PrintRange.CurrentPage
                        nStartPage = 1
                        nEndPage = 1
                    Case Printing.PrintRange.SomePages
                        nStartPage = printer.FromPage
                        nEndPage = printer.ToPage
                End Select
                .PrintToPrinter(printer.Copies, printer.Collate, nStartPage, nEndPage)
            End With
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Public Shared Sub ImprimerSimple(ByVal nomReport As String, ByVal datasource As Object, ByVal printerName As String, Optional ByVal titre As String = Nothing)
        Cursor.Current = Cursors.WaitCursor

        Using report As ReportDocument = ChargerReport(nomReport, datasource, titre)
            With report
                .PrintOptions.PrinterName = printerName
                .PrintToPrinter(1, True, -1, -1)
            End With
        End Using

        Cursor.Current = Cursors.Default
    End Sub

    Public Shared Sub Apercu(ByVal nomReport As String, ByVal datasource As Object, Optional ByVal titre As String = Nothing)
        Cursor.Current = Cursors.WaitCursor
        Using report As ReportDocument = ChargerReport(nomReport, datasource, titre)
            Using fr As New FrCrystalReport(report)
                fr.ShowDialog()
            End Using
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Public Shared Function ChargerReport(ByVal nomReport As String, ByVal datasource As Object, Optional ByVal titre As String = Nothing) As ReportDocument
        Dim repEtats As String = My.Settings.AbsoluteRepEtats
        If Not IO.File.Exists(repEtats & "\" & nomReport) Then Throw New ApplicationException("Etat introuvable")

        Dim report As New ReportDocument
        With report
            .Load(repEtats & "\" & nomReport)
            .SetDataSource(datasource)
            If titre IsNot Nothing Then .SummaryInfo.ReportTitle = titre
        End With
        Return report
    End Function
#End Region

End Class
