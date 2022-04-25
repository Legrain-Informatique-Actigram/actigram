Imports CrystalDecisions.CrystalReports.Engine

Public Class EcranCrystal

    Dim oRpt As ReportDocument

#Region "Constructeurs"
    Public Sub New(ByVal momEtat As ReportDocument)
        Me.New()
        oRpt = momEtat
    End Sub
#End Region

#Region "Page"
    Private Sub FrFusion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.rptViewer.ReportSource = oRpt
    End Sub
#End Region

#Region " Shared "
    Public Shared Sub Prechargement()
        Using fr As New EcranCrystal(ChargerReport("dummy.rpt", New AgrifactTracaDataSet))
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
            Using fr As New EcranCrystal(report)
                fr.ShowDialog()
            End Using
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Public Shared Function ChargerReport(ByVal nomReport As String, ByVal datasource As Object, Optional ByVal titre As String = Nothing) As ReportDocument
        Dim chemin As String = IO.Path.Combine(My.Application.RepEtats, nomReport)
        If IO.Path.GetExtension(chemin) = "" Then chemin &= ".rpt"
        If Not IO.File.Exists(chemin) Then Throw New ApplicationException("Etat introuvable")

        Dim report As New ReportDocument
        With report
            .Load(chemin)
            .SetDataSource(datasource)
            If titre IsNot Nothing Then .SummaryInfo.ReportTitle = titre
        End With
        Return report
    End Function
#End Region

End Class
