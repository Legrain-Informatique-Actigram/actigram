Imports Microsoft.PointOfService
Imports System.Reflection

Public Module GestionImpressionTicket
    Public Sub ImprimerTicket(ByVal nDevis As Integer)
        'Charger les données
        Dim ds As New DsAgrifact
        Using dta As New DsAgrifactTableAdapters.VFactureTA
            dta.FillBynDevis(ds.VFacture, nDevis)
        End Using
        If ds.VFacture.Rows.Count = 0 Then Exit Sub
        Using dta As New DsAgrifactTableAdapters.VFacture_DetailTA
            dta.FillBynDevis(ds.VFacture_Detail, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.ReglementTA
            dta.FillBynDevis(ds.Reglement, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.Reglement_DetailTA
            dta.FillBynDevis(ds.Reglement_Detail, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.TVA_TA
            dta.Fill(ds.TVA)
        End Using
        'Lancer l'impression sur drFacture
        ImprimerTicket(Cast(Of DsAgrifact.VFactureRow)(ds.VFacture.Rows(0)))
    End Sub

    Public Sub ImprimerTicket(ByVal drFacture As DsAgrifact.VFactureRow)
        Try
            Dim printerName As String = "printer"
            Using printer As New PosPrinterWriter(printerName)
                With printer
                    'TODO Entete
                    .CurrentOption = PosPrinterWriter.PrintOptions.Bold
                    .WriteLine("Entete")
                    .Flush()
                    .FeedPaperForward(2)

                    'Infos ticket
                    .CurrentOption = PosPrinterWriter.PrintOptions.None
                    .WriteLine(String.Format("Ticket n°{0}", drFacture.nFacture))
                    .WriteLine(String.Format("le {0:dd/MM/yy} à {0:HH:mm}", drFacture.DateFacture))
                    .Flush()
                    .FeedPaperForward(3)

                    'Détail de la facture
                    .WriteLine("Qt Designation   Montant")
                    .WriteLine("------------------------")
                    For Each drDetail As DsAgrifact.VFacture_DetailRow In drFacture.GetVFacture_DetailRows
                        .WriteLine(String.Format("{1,2:#0.#}*{0,-10}{2,10:N2}", Left(drDetail.Libelle, 10), drDetail.Unite1, drDetail.MontantLigneTTC))
                    Next
                    .Flush()
                    .FeedPaperForward(2)

                    'TOTAL
                    .WriteLine(String.Format("Total TTC: {0,15:C2}", drFacture.MontantTTC))
                    .Flush(PosPrinterWriter.PrintOptions.Bold, False)
                    .CurrentOption = PosPrinterWriter.PrintOptions.None
                    .FeedPaperForward(2)

                    'Faire un récap TVA
                    .WriteLine("Taux    HT    TVA   TTC  ")
                    .WriteLine("-------------------------")
                    Dim recaps As IEnumerable(Of RecapTVA) = Main.CalculerRecapTVA(drFacture)
                    For Each r As RecapTVA In recaps
                        .WriteLine(String.Format("{0,5:#0.0#} {1,6:# ##0.00} {2,6:# ##0.00} {3,6:# ##0.00}", r.Taux * 100, r.BaseHT, r.MontantTVA, r.MontantTTC))
                    Next
                    .Flush()
                    .FeedPaperForward(2)

                    'Ajouter les informations de réglement
                    Dim resteARegler As Decimal = drFacture.MontantTTC
                    For Each drRD As DsAgrifact.Reglement_DetailRow In drFacture.GetReglement_DetailRows
                        If Not drRD.IsMontantNull Then
                            Dim drR As DsAgrifact.ReglementRow = drRD.ReglementRow
                            .WriteLine("Réglement par {0} : {1,6:C2}", Left(drR.nMode, 6), drRD.Montant)
                            resteARegler -= drRD.Montant + Nullabilify(Of Decimal)(drRD("Perte")).GetValueOrDefault(0) - Nullabilify(Of Decimal)(drRD("Profit")).GetValueOrDefault(0)
                        End If
                    Next
                    If Decimal.Round(resteARegler, 1) <> 0 Then
                        .FeedPaperForward(1)
                        If resteARegler > 0 Then
                            .WriteLine("Reste à régler : {0,6:C2}", resteARegler)
                        Else
                            .WriteLine("Avance de paiement : {0,6:C2}", -resteARegler)
                        End If
                    End If
                    .Flush()
                    .FeedPaperForward(2)
                    .WriteLine("MERCI DE VOTRE VISITE ET A BIENTOT")
                    .Flush(PosPrinterWriter.PrintOptions.Bold, True)
                End With
                Application.DoEvents()
                Stop
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Module

Public Class PosPrinterWriter
    Inherits IO.TextWriter

    Public ReadyToPrint As Boolean
    Public PrinterName As String

    Public Sub New(ByVal printerName As String)
        Me.PrinterName = printerName
        InitStringWriter()
        InitPrinter()
    End Sub

#Region "Dispose"
    Public Overrides Sub Close()
        MyBase.Close()
    End Sub

    Private disposedValue As Boolean = False        ' Pour détecter les appels redondants
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Me.sw.Close()
            End If
            ReleasePrinter()
        End If
        Me.disposedValue = True
        MyBase.Dispose(disposing)
    End Sub
#End Region

#Region "Gestion du TextWriter"
    Private sw As IO.StringWriter
    Private Sub InitStringWriter()
        sw = New IO.StringWriter
    End Sub

    Private _encoding As System.Text.Encoding = system.Text.Encoding.Default
    Public Overrides ReadOnly Property Encoding() As System.Text.Encoding
        Get
            Return _encoding
        End Get
    End Property

    Public Overloads Sub Flush(ByVal printOptions As PrintOptions, Optional ByVal cutPaper As Boolean = False)
        If printOptions <> PosPrinterWriter.PrintOptions.None Then
            Me.CurrentOption = printOptions
        End If
        Flush()
        If cutPaper Then Me.CutPaper()
    End Sub

    Public Overrides Sub Flush()
        sw.Flush()
        'IMPRIMER LE CONTENU DU STRINGWRITER
        Print(sw.ToString, CurrentOption, False, False)
        InitStringWriter()
        MyBase.Flush()
    End Sub

    Public Overrides Sub Write(ByVal value As Char)
        sw.Write(value)
    End Sub
#End Region

#Region "Gestion de l'imprimante"
    Public CurrentOption As PrintOptions = PrintOptions.None

    'ESC command
    Private Const ESC As String = Chr(&H1B)
    'Printer instance
    Private m_Printer As PosPrinter
    'Now Step.
    Private m_strStep As String = "Impression"
    'Printer cover status.
    Private m_btnStateByCover As Boolean = True
    'Printer paper status.
    Private m_btnStateByPaper As Boolean = True
    'Conversensor flag.
    Private m_bConverSensor As Boolean = False

    Private Sub InitPrinter()
        'Use a Logical Device Name which has been set on the SetupPOS.
        Dim strLogicalName As String = "PosPrinter"
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer

        'Crate PosExplorer
        posExplorer = New PosExplorer

        m_Printer = Nothing

        Try
            deviceInfo = posExplorer.GetDevices(DeviceType.PosPrinter).Item(0)
        Catch ex As Exception
            MessageBox.Show("Fails to get device information.", m_strStep)
            'Nothing can be used.
            ReadyToPrint = False
            Return
        End Try

        Try
            m_Printer = Cast(Of PosPrinter)(posExplorer.CreateInstance(deviceInfo))
        Catch ex As Exception
            MessageBox.Show("Fails to create device instance.", m_strStep)
            ReadyToPrint = False
            Return
        End Try

        'Register OutputCompleteEventHandler.
        AddOutputCompleteEvent(m_Printer, AddressOf OnOutputCompleteEvent)

        'Register ErrorEventEventHandler.
        AddErrorEvent(m_Printer, AddressOf OnErrorEvent)

        'Register StatusUpdateEventHandler.
        AddStatusUpdateEvent(m_Printer, AddressOf OnStatusUpdateEvent)

        Try
            'Open the device
            m_Printer.Open()
        Catch ex As PosControlException
            MessageBox.Show("Fails to open the device.", m_strStep)
            'Nothing can be used.
            ReadyToPrint = False
            Return
        End Try


        Try
            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Printer.Claim(1000)
        Catch ex As PosControlException
            MessageBox.Show("Fails to claim the device.", m_strStep)
            'Nothing can be used.
            ReadyToPrint = False
            Return
        End Try

        Try
            'Enable the device.
            m_Printer.DeviceEnabled = True
        Catch ex As PosControlException
            MessageBox.Show("Disable to use the device.", m_strStep)
            'Nothing can be used.
            ReadyToPrint = False
        End Try

        Try
            'Output by the high quality mode
            m_Printer.RecLetterQuality = True

            'Even if using any printers, 0.01mm unit makes it possible to print neatly.
            m_Printer.MapMode = MapMode.Metric
        Catch ex As PosControlException
        End Try

        ReadyToPrint = True
        m_bConverSensor = m_Printer.CapCoverSensor
        m_Printer.AsyncMode = True
    End Sub

    Private Sub ReleasePrinter()
        If m_Printer Is Nothing Then Exit Sub
        Try
            RemoveOutputCompleteEvent(m_Printer, AddressOf OnOutputCompleteEvent)
            RemoveErrorEvent(m_Printer, AddressOf OnErrorEvent)
            RemoveStatusUpdateEvent(m_Printer, AddressOf OnStatusUpdateEvent)

            'Cancel the device
            m_Printer.DeviceEnabled = False
            'Release the device exclusive control right.
            m_Printer.Release()
        Catch ex As PosControlException
        Finally
            'Finish using the device.
            m_Printer.Close()
        End Try
        m_Printer = Nothing
    End Sub

    Protected Sub OnOutputCompleteEvent(ByVal source As Object, ByVal e As OutputCompleteEventArgs)
        'Notify that printing is completed when it is asnchronous.
        MessageBox.Show("Complete printing : ID = " + e.OutputId.ToString(), m_strStep)
    End Sub

    Protected Sub OnErrorEvent(ByVal source As Object, ByVal e As DeviceErrorEventArgs)
        Dim strMessage As String
        strMessage = "Printer Error" + vbCrLf + vbCrLf + "ErrorCode = " + e.ErrorCode.ToString() _
                    + vbCrLf + "ErrorCodeExtended = " + e.ErrorCodeExtended.ToString()
        Select Case MsgBox(strMessage, MsgBoxStyle.RetryCancel, m_strStep)
            Case MsgBoxResult.Cancel : e.ErrorResponse = ErrorResponse.Clear
            Case MsgBoxResult.Retry : e.ErrorResponse = ErrorResponse.Retry
        End Select
    End Sub

    Protected Sub OnStatusUpdateEvent(ByVal source As Object, ByVal e As StatusUpdateEventArgs)
        'When there is a change of the status on the printer, the event is fired.
        Select Case e.Status
            'Printer cover is open.
            Case PosPrinter.StatusCoverOpen
                m_btnStateByCover = False
            Case PosPrinter.StatusReceiptEmpty
                m_btnStateByPaper = False
                'Printer cover is close.
            Case PosPrinter.StatusCoverOK
                m_btnStateByCover = True
                'Receipt paper is ok.		
            Case PosPrinter.StatusReceiptPaperOK
                m_btnStateByPaper = True
            Case PosPrinter.StatusReceiptNearEmpty
                m_btnStateByPaper = True
        End Select

        If m_btnStateByPaper And (m_btnStateByCover Or Not m_bConverSensor) Then
            ReadyToPrint = True
        Else
            ReadyToPrint = False
        End If
    End Sub

    Private Function GetRecLineChars(ByRef sRecLineChars() As Integer) As Long
        Dim lCount As Integer
        Dim i As Integer

        'Calculate the element count.
        lCount = m_Printer.RecLineCharsList.Length

        If lCount = 0 Then
            GetRecLineChars = 0
        Else
            'Set the element to array.
            ReDim sRecLineChars(lCount)

            For i = 0 To (lCount - 1)
                sRecLineChars(i) = m_Printer.RecLineCharsList(i)
            Next

            GetRecLineChars = lCount
        End If
    End Function

    Private Function MakePrintString(ByVal iRecLineChars As Int32, ByVal strBuf As String, ByVal strPrice As String) As String
        Dim tab As New String(" "c, iRecLineChars - (strBuf.Length + strPrice.Length))
        Return strBuf & tab & strPrice
    End Function

    Private Sub Print(ByVal PrintData As String, Optional ByVal options As PrintOptions = PrintOptions.None, Optional ByVal UseTransaction As Boolean = True, Optional ByVal CutPaperAfterPrint As Boolean = True)
        'When outputting to a printer,a mouse cursor becomes like a hourglass.
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If m_Printer.CapRecPresent = True Then
            Try
                'Batch processing mode
                If UseTransaction Then m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction)

                Using sr As New IO.StringReader(PrintData)
                    Dim line As String = sr.ReadLine
                    While line IsNot Nothing
                        PrintLine(line, options)
                        line = sr.ReadLine
                    End While
                End Using

                If CutPaperAfterPrint Then CutPaper()

                'print all the buffer data. and exit the batch processing mode.
                If UseTransaction Then m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal)
            Catch ex As PosControlException
            End Try
        End If
    End Sub

    Private Sub PrintLine(ByVal printData As String, Optional ByVal options As PrintOptions = PrintOptions.None)
        Debug.WriteLine(printData)
        'ESC|cA =  Aligns following text in the center.
        'ESC|rA =  Aligns following text at the right.
        'ESC|N =  Restores printer characteristics to normal condition.
        'ESC|bC = Bold
        'ESC|uC = Underline
        'ESC|iC = Italic
        'ESC|2C = Wide charcter
        Dim escapeSequence As String
        Select Case options
            Case PrintOptions.RestoreNormal : escapeSequence = ESC & "|N"
            Case PrintOptions.AlignCenter : escapeSequence = ESC & "|cA"
            Case PrintOptions.AlignRight : escapeSequence = ESC & "|rA"
            Case PrintOptions.Bold : escapeSequence = ESC & "|bC"
            Case PrintOptions.Italic : escapeSequence = ESC & "|uC"
            Case PrintOptions.Underline : escapeSequence = ESC & "|iC"
            Case PrintOptions.Wide : escapeSequence = ESC & "|2C"
            Case Else : escapeSequence = ""
        End Select
        m_Printer.PrintNormal(PrinterStation.Receipt, escapeSequence & printData & vbCrLf)
    End Sub

    Public Sub FeedPaperForward(ByVal space As Integer)
        For i As Integer = 1 To space
            Debug.WriteLine("")
        Next
        'ESC|#uF = Line Feed
        m_Printer.PrintNormal(PrinterStation.Receipt, String.Format("{0}|{1}00uF", ESC, space))
    End Sub

    Public Sub CutPaper()
        Debug.WriteLine("________________________________________")
        ''ESC|#fP = Line Feed and Paper cut	
        m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|fP")
    End Sub

    Public Enum PrintOptions
        None
        RestoreNormal
        Bold
        Italic
        Underline
        Wide
        AlignCenter
        AlignRight
    End Enum

#End Region

End Class

Public Module PosUtils
    Public Sub AddOutputCompleteEvent(ByVal eventSource As Object, ByVal e As OutputCompleteEventHandler)
        Dim outputCompleteEvent As EventInfo = eventSource.GetType().GetEvent("OutputCompleteEvent")
        If Not (outputCompleteEvent Is Nothing) Then
            outputCompleteEvent.AddEventHandler(eventSource, e)
        End If
    End Sub

    Public Sub AddStatusUpdateEvent(ByVal eventSource As Object, ByVal e As StatusUpdateEventHandler)
        Dim statusUpdateEvent As EventInfo = eventSource.GetType().GetEvent("StatusUpdateEvent")
        If Not (statusUpdateEvent Is Nothing) Then
            statusUpdateEvent.AddEventHandler(eventSource, e)
        End If
    End Sub

    Public Sub AddErrorEvent(ByVal eventSource As Object, ByVal e As DeviceErrorEventHandler)
        Dim errorEvent As EventInfo =  eventSource.GetType().GetEvent("ErrorEvent")
        If Not (errorEvent Is Nothing) Then
            errorEvent.AddEventHandler(eventSource, e)
        End If
    End Sub

    Public Sub RemoveOutputCompleteEvent(ByVal eventSource As Object, ByVal e As OutputCompleteEventHandler)
        Dim outputCompleteEvent As EventInfo =  eventSource.GetType().GetEvent("OutputCompleteEvent")
        If Not (outputCompleteEvent Is Nothing) Then
            outputCompleteEvent.RemoveEventHandler(eventSource ,e)
        End If
    End Sub

    Public Sub RemoveStatusUpdateEvent(ByVal eventSource As Object, ByVal e As StatusUpdateEventHandler)
        Dim statusupdateEvent As EventInfo =  eventSource.GetType().GetEvent("StatusUpdateEvent")
        If Not (statusupdateEvent Is Nothing) Then
            statusupdateEvent.RemoveEventHandler(eventSource ,e)
        End If
    End Sub

    Public Sub RemoveErrorEvent(ByVal eventSource As Object, ByVal e As DeviceErrorEventHandler)
        Dim errorEvent As EventInfo =  eventSource.GetType().GetEvent("ErrorEvent")
        If Not (errorEvent Is Nothing) Then
            errorEvent.RemoveEventHandler(eventSource ,e)
        End If
    End Sub
End Module