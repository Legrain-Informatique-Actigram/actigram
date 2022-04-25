Imports System.Drawing.Printing

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
            If My.Settings.PrinterName = "" Then Throw New ApplicationException("L'imprimante n'est pas paramétrée") ' "EPSON TM-U220 Receipt"
            Using printer As New PosPrinterWriter(My.Settings.PrinterName)
                With printer
                    'Ecriture de l'Entete
                    Using dta As New DsAgrifactTableAdapters.ParametresTA
                        .WriteLine(dta.GetValeur(DsAgrifact.ParametresDataTable.Cles.EnTete))
                        .WriteLine(dta.GetValeur(DsAgrifact.ParametresDataTable.Cles.EnTeteDetail))
                    End Using
                    .WriteLine(New String("_"c, .LineWidth))
                    .FeedPaperForward(1)

                    'Infos ticket
                    .WriteLine(String.Format("Facture n°{0} le {1:dd/MM/yy} à {1:HH:mm}", drFacture.nFacture, drFacture.DateFacture))
                    .WriteLine("Client : " & drFacture.AdresseFacture)
                    .FeedPaperForward(1)

                    'Détail de la facture
                    .WriteLine(String.Format("{0,-6}{1,-20}{2,10}", " Qt", " Designation", "Montant "))
                    .WriteLine(New String("_"c, .LineWidth))
                    For Each drDetail As DsAgrifact.VFacture_DetailRow In drFacture.GetVFacture_DetailRows
                        .WriteLine(String.Format("{1,4:#0.#} * {0,-19}{2,10:C2}", Left(drDetail.Libelle, 19), drDetail.Unite1, drDetail.MontantLigneTTC))
                    Next
                    .WriteLine(New String("_"c, .LineWidth))

                    'TOTAL
                    .WriteLine(String.Format("Total TTC: {0,25:C2}", drFacture.MontantTTC))

                    'Faire un récap TVA
                    Dim recaps As List(Of RecapTVA) = Main.CalculerRecapTVA(drFacture)
                    If recaps.Count = 1 Then
                        'Cas simple s'il n'y a qu'un seul taux
                        Dim r As RecapTVA = recaps(0)
                        .WriteLine(String.Format("Total HT:  {0,25:C2}", r.BaseHT))
                        .WriteLine(String.Format("TVA à {1,-6:#0.0#%}:  {0,21:C2}", r.MontantTVA, r.Taux))
                    Else
                        'Si plusieurs taux, on imprime un récap complet en colonne
                        .FeedPaperForward(1)
                        .WriteLine("Taux      HT       TVA      TTC")
                        .WriteLine(New String("-"c, .LineWidth))
                        For Each r As RecapTVA In recaps
                            .WriteLine(String.Format("{0,5:#0.0#} {1,8:# ##0.00} {2,8:# ##0.00} {3,8:# ##0.00}", r.Taux * 100, r.BaseHT, r.MontantTVA, r.MontantTTC))
                        Next
                    End If
                    
                    .FeedPaperForward(1)

                    'Ajouter les informations de réglement
                    Dim resteARegler As Decimal = drFacture.MontantTTC
                    For Each drRD As DsAgrifact.Reglement_DetailRow In drFacture.GetReglement_DetailRows
                        If Not drRD.IsMontantNull Then
                            Dim drR As DsAgrifact.ReglementRow = drRD.ReglementRow
                            .WriteLine("Réglement par {0} : {1,13:C2}", Left(drR.nMode, 6), drRD.Montant)
                            resteARegler -= drRD.Montant + Nullabilify(Of Decimal)(drRD("Perte")).GetValueOrDefault(0) - Nullabilify(Of Decimal)(drRD("Profit")).GetValueOrDefault(0)
                        End If
                    Next
                    If Decimal.Round(resteARegler, 1) <> 0 Then
                        If resteARegler > 0 Then
                            .WriteLine("Reste à régler : {0,19:C2}", resteARegler)
                        Else
                            .WriteLine("Avance de paiement : {0,15:C2}", -resteARegler)
                        End If
                    End If
                    .WriteLine(New String("_"c, .LineWidth))
                    .WriteLine(" MERCI DE VOTRE VISITE ET A BIENTOT ")
                    .FeedPaperForward(3)
                    .Flush()
                End With
                Application.DoEvents()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub TestPrinter()
        Try
            Dim printerName As String = "EPSON TM-U220 Receipt"
            Using printer As New PosPrinterWriter(printerName)
                With printer
                    .WriteLine("Une ligne puis avance")
                    .FeedPaperForward(2)
                    .WriteLine("Trois lignes puis flush")
                    .WriteLine("_________10________20________30________40________50")
                    .WriteLine("MERCI DE VOTRE VISITE ET A BIENTOT")
                    .Flush()
                End With
                Application.DoEvents()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module

Public Class PosPrinterWriter
    Inherits IO.TextWriter

    Public PrinterName As String
    Public LineWidth As Integer = 40

    Private sw As IO.StringWriter
    Private _encoding As System.Text.Encoding = System.Text.Encoding.Default
    Private font As Font = New Font("Courier New", 8, FontStyle.Regular) ' SystemFonts.DefaultFont
    Private lineHeight As Integer = 15
    Private pd As PrintDocument
    Private PrintData As String

#Region "Constructeurs"
    Public Sub New(ByVal printerName As String)
        Me.PrinterName = printerName
        InitStringWriter()
        InitPrinter()
    End Sub
#End Region

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
    Private Sub InitStringWriter()
        sw = New IO.StringWriter
    End Sub

    Public Overrides ReadOnly Property Encoding() As System.Text.Encoding
        Get
            Return _encoding
        End Get
    End Property

    Public Overrides Sub Flush()
        sw.Flush()
        'IMPRIMER LE CONTENU DU STRINGWRITER
        Print(sw.ToString)
        InitStringWriter()
        MyBase.Flush()
    End Sub

    Public Overrides Sub Write(ByVal value As Char)
        sw.Write(value)
    End Sub

    Public Sub FeedPaperForward(ByVal space As Integer)
        For i As Integer = 1 To space
            WriteLine("")
        Next
    End Sub
#End Region

#Region "Gestion de l'imprimante"
    Private Sub InitPrinter()
        pd = New PrintDocument
        AddHandler pd.BeginPrint, AddressOf Me.BeginPrint
        AddHandler pd.PrintPage, AddressOf Me.PrintPage
        AddHandler pd.EndPrint, AddressOf Me.EndPrint
        pd.PrinterSettings.PrinterName = Me.PrinterName
    End Sub

    Private Sub ReleasePrinter()
        If pd Is Nothing Then Exit Sub
        pd.Dispose()
    End Sub

    Private Sub Print(ByVal PrintData As String)
        If pd Is Nothing Then InitPrinter()
        Me.PrintData = PrintData
        pd.Print()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Using sr As New IO.StringReader(PrintData)
            Dim y As Integer = 0
            Dim line As String = sr.ReadLine
            While line IsNot Nothing
                g.DrawString(line, font, Brushes.Black, 0, y)
                y += lineHeight
                line = sr.ReadLine
            End While
        End Using
        PrintData = Nothing
    End Sub

    Private Sub BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        Cursor.Current = Cursors.Default
    End Sub
#End Region

End Class
