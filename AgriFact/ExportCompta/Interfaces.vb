Public Interface IExportCompta
    Event ExportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs)

    Sub ChargerDonnees(ByVal sqlConnectionString As String)
    Function EnvoiCompta() As Boolean

    Sub Close()
    Sub Dispose()
End Interface

Public Interface ISynchroPLC
    Function Ajout_Activite(ByVal KeepDossier As String, ByVal Activite As String, ByVal LibActivite As String, Optional ByVal Enregistrement As Boolean = False) As String
    Function Ajout_Compte(ByVal KeepDossier As String, ByVal Compte As String, ByVal LibCompte As String, Optional ByVal LibU1 As String = "", Optional ByVal LibU2 As String = "", Optional ByVal Enregistrement As Boolean = False) As String
    Function Ajout_PlanComptable(ByVal Dossier As String, ByVal Compte As String, ByVal Activite As String, Optional ByVal Enregistrement As Boolean = False) As String

    Sub Close()
    Sub Dispose()
End Interface

#Region "Utils classes"
Public Class WarningExport
    Inherits Exception

#Region "Constructeurs"
    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub
#End Region

End Class

#Region "RecapTVA"
Public Class ElementRecapTva
    Public CodeTVA As String
    Public CompteTVA As String
    Public TxTva As Decimal = 0
    Public MontantHT As Decimal = 0
    Public MontantTVA As Decimal = 0
    Public MontantTTC As Decimal = 0
End Class

Public Class RecapTVA
    Private LstTx As New Hashtable

#Region "Méthodes diverses"
    Public Sub AddMontant(ByVal TTVA As String, ByVal TxTVA As Decimal, ByVal MontantHT As Decimal, ByVal MontantTTC As Decimal)
        Dim MontantTVA As Decimal
        'If MontantHT <> 0 Then
        If MontantTTC <> 0 Then
            MontantTVA = MontantTTC - MontantHT
        Else
            MontantTVA = (MontantHT * TxTVA / 100)
        End If
        'Else
        'MontantTVA = MontantTTC - (MontantTTC / (1 + TxTVA / 100))
        'End If
        AddMontant(TTVA, TxTVA, MontantHT, MontantTTC, MontantTVA)
    End Sub

    Public Sub AddMontant(ByVal TTVA As String, ByVal TxTVA As Decimal, ByVal MontantHT As Decimal, ByVal MontantTTC As Decimal, ByVal MontantTVA As Decimal)
        If Not LstTx.Contains(TTVA) Then
            Dim Montant As New ElementRecapTva
            With Montant
                .CodeTVA = TTVA
                .TxTva = TxTVA
                .MontantHT = MontantHT
                .MontantTTC = MontantTTC
                .MontantTVA = MontantTVA
            End With
            LstTx.Add(TTVA, Montant)
        Else
            Dim Montant As ElementRecapTva = CType(LstTx.Item(TTVA), ElementRecapTva)
            With Montant
                .MontantHT += MontantHT
                .MontantTTC += MontantTTC
                .MontantTVA += MontantTVA
            End With
        End If
    End Sub

    Public Sub SetCompte(ByVal TTVA As String, ByVal CptTVA As String, ByVal TxTVA As Decimal)
        If Not LstTx.Contains(TTVA) Then
            Dim Montant As New ElementRecapTva
            With Montant
                .CodeTVA = TTVA
                .CompteTVA = CptTVA
                .TxTva = TxTVA
            End With
            LstTx.Add(TTVA, Montant)
        Else
            Dim Montant As ElementRecapTva = CType(LstTx.Item(TTVA), ElementRecapTva)
            Montant.CompteTVA = CptTVA
        End If
    End Sub

    Public Function TxTVA(ByVal TTVA As String) As Decimal
        Return CType(LstTx.Item(TTVA), ElementRecapTva).TxTva
    End Function

    Public Function MontantTVATaux(ByVal TTVA As String) As Decimal
        Return Actigram.MathUtil.ArithmeticRound(CType(LstTx.Item(TTVA), ElementRecapTva).MontantTVA, 2)
    End Function

    Public Function MontantHTTaux(ByVal TTVA As String) As Decimal
        Return CType(LstTx.Item(TTVA), ElementRecapTva).MontantHT
    End Function

    Public Function MontantTTCTaux(ByVal TTVA As String) As Decimal
        Return CType(LstTx.Item(TTVA), ElementRecapTva).MontantTTC
    End Function

    Public Function MontantTVATotal() As Decimal
        Dim MontantTotal As Decimal = 0
        Dim iE As IDictionaryEnumerator = LstTx.GetEnumerator
        Do Until iE.MoveNext = False
            MontantTotal += CType(iE.Value, ElementRecapTva).MontantTVA
        Loop
        Return MontantTotal
    End Function

    Public Function GetLstTx() As String()
        Dim LstTxTVA(LstTx.Keys.Count - 1) As String
        Dim i As Integer = 0
        Dim iE As IDictionaryEnumerator = LstTx.GetEnumerator
        Do Until iE.MoveNext = False
            LstTxTVA.SetValue(Convert.ToString(iE.Key), i)
            i += 1
        Loop
        Return LstTxTVA
    End Function

    Public Function GetElementRecap(ByVal TTVA As String) As ElementRecapTva
        If Not LstTx.Contains(TTVA) Then
            Return Nothing
        Else
            Return CType(LstTx.Item(TTVA), ElementRecapTva)
        End If
    End Function
#End Region

End Class
#End Region

#Region "RecapComptesProduit"
Public Class ElementRecapComptesProduit
    Public CompteProduit As String
    Public MontantHT As Decimal = 0
    Public MontantTVA As Decimal = 0
    Public MontantTTC As Decimal = 0
End Class

Public Class RecapComptesProduit
    Private LstComptesProduit As New Hashtable

#Region "Méthodes diverses"
    Public Sub AddMontant(ByVal compteProduit As String, ByVal MontantHT As Decimal, ByVal MontantTTC As Decimal, ByVal MontantTVA As Decimal)
        If Not LstComptesProduit.Contains(compteProduit) Then
            Dim Montant As New ElementRecapComptesProduit

            With Montant
                .CompteProduit = compteProduit
                .MontantHT = MontantHT
                .MontantTTC = MontantTTC
                .MontantTVA = MontantTVA
            End With

            LstComptesProduit.Add(compteProduit, Montant)
        Else
            Dim Montant As ElementRecapComptesProduit = CType(LstComptesProduit.Item(compteProduit), ElementRecapComptesProduit)

            With Montant
                .MontantHT += MontantHT
                .MontantTTC += MontantTTC
                .MontantTVA += MontantTVA
            End With
        End If
    End Sub

    Public Sub SetCompte(ByVal compteProduit As String)
        If Not LstComptesProduit.Contains(compteProduit) Then
            Dim Montant As New ElementRecapComptesProduit

            With Montant
                .CompteProduit = compteProduit
            End With

            LstComptesProduit.Add(compteProduit, Montant)
        Else
            Dim Montant As ElementRecapComptesProduit = CType(LstComptesProduit.Item(compteProduit), ElementRecapComptesProduit)

            Montant.CompteProduit = compteProduit
        End If
    End Sub
#End Region
End Class
#End Region

#Region "ProgressEventArgs"
Public Class ProgressEventArgs
    Inherits EventArgs

    Private _percent As Integer
    Public Property Percent() As Integer
        Get
            Return _percent
        End Get
        Set(ByVal Value As Integer)
            If Value > 100 Or Value < 0 Then Throw New ArgumentOutOfRangeException
            _percent = Value
        End Set
    End Property

    Private _status As Object
    Public Property Status() As Object
        Get
            Return _status
        End Get
        Set(ByVal Value As Object)
            _status = Value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        Me.New()
        Me.Percent = percent
        Me.Status = status
    End Sub
End Class
#End Region

#End Region

Public MustInherit Class ExportComptaFichierBase
    Inherits ExportComptaBase

    Public fichier As String

    Public MustOverride ReadOnly Property Filter() As String
    Public MustOverride Function DefaultFileName(ByVal nDossier As String) As String

End Class

Public MustInherit Class ExportComptaBase
    Implements IDisposable, IExportCompta

    Protected dsAgrifact As DataSet
    Protected cnAgriFact As SqlClient.SqlConnection

    Protected DtaVFacture As SqlClient.SqlDataAdapter
    Protected DtaReglement As SqlClient.SqlDataAdapter
    Protected DtaAFacture As SqlClient.SqlDataAdapter
    Protected DtaAReglement As SqlClient.SqlDataAdapter
    Protected DtaRemise As SqlClient.SqlDataAdapter
    Protected DtaFactureMontantExport As SqlClient.SqlDataAdapter
    Protected DtaAFactureMontantExport As SqlClient.SqlDataAdapter

    Protected DtaParametres As SqlClient.SqlDataAdapter

    Public Event ExportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs) Implements IExportCompta.ExportProgressed

    Public RapportExport As New System.Text.StringBuilder

#Region "Propriétés"
    'Infos a renseigner avant de commencer l'export
    Public nDossierCompta As String
    Public NomDossier As String

    Public BlocnPieceDebutAFacture As String 'Defaut : 80 000
    Public BlocnPieceFinAFacture As String 'Defaut : 100 000
    Public BlocnPieceDebutAReglement As String 'Defaut : 150 000
    Public BlocnPieceFinAReglement As String 'Defaut : 200 000
    Public BlocnPieceDebutVFacture As String 'Defaut : 50 000
    Public BlocnPieceFinVFacture As String 'Defaut : 80 000
    Public BlocnPieceDebutVReglement As String 'Defaut : 100 000
    Public BlocnPieceFinVReglement As String 'Defaut : 150 000

    Public RgpCptsPdtsExportVtes As Boolean
    Public ChkFourchVFact As Boolean
    Public VFactureNumFactureAgrifact As Boolean
    Public VFactureComposerNumPiece As Boolean
    Public VFactureRacineNumPiece As String

    Public TVASurEncaissement As Boolean

    Public VFacture As Boolean
    Public AFacture As Boolean
    Public VReglement As Boolean
    Public AReglement As Boolean

    Public DateDebVFacture As Date
    Public DateFinVFacture As Date
    Public DateDebAFacture As Date
    Public DateFinAFacture As Date
    Public DateDebVReglement As Date
    Public DateFinVReglement As Date
    Public DateDebAReglement As Date
    Public DateFinAReglement As Date
#End Region

#Region "Méthodes diverses"
    Public Overridable Function GetNbFacturesExportees() As Integer
        Return 0
    End Function

    Public Overridable Function GetNbRemisesExportees() As Integer
        Return 0
    End Function

    Public Overridable Sub ChargerDonnees(ByVal sqlConnectionString As String) Implements IExportCompta.ChargerDonnees
        ChargerDonneesAgrifact(sqlConnectionString)
    End Sub

    Protected Sub ChargerDonneesAgrifact(ByVal sqlConnectionString As String)
        cnAgriFact = New SqlClient.SqlConnection(sqlConnectionString)
        dsAgrifact = New DataSet

        ReportProgress(0, "Chargement des données Agrifact")
        'Initialisation des données Agrifact
        InitAgrifactDta("Entreprise", dsAgrifact, False) : ReportProgress(5)
        If VFacture Or AFacture Then InitAgrifactDta("Produit", dsAgrifact, False) : ReportProgress(15)
        If VReglement Or AReglement Then InitAgrifactDta("Banque", dsAgrifact, False) : ReportProgress(25)

        'TODO Pourquoi ne pas charger que les non exportés ? => La requete serait plus compliquée, on pourrait aussi limiter en fonction des dates
        If VReglement Or VFacture Then DtaVFacture = InitAgrifactDta("VFacture", dsAgrifact) : ReportProgress(30)
        If VReglement Or VFacture Then InitAgrifactDta("VFacture_Detail", dsAgrifact, False) : ReportProgress(35)
        If VReglement Then DtaReglement = InitAgrifactDta("Reglement", dsAgrifact) : ReportProgress(40)
        If VReglement Then InitAgrifactDta("Reglement_Detail", dsAgrifact, False) : ReportProgress(45)
        If VReglement Then DtaRemise = InitAgrifactDta("Remise", dsAgrifact) : ReportProgress(50)
        If VReglement Then InitAgrifactDta("Remise_Detail", dsAgrifact, False) : ReportProgress(55)
        If VReglement Then DtaFactureMontantExport = InitAgrifactDta("FactureMontantExport", dsAgrifact) : ReportProgress(60)

        If AReglement Or AFacture Then DtaAFacture = InitAgrifactDta("AFacture", dsAgrifact) : ReportProgress(70)
        If AReglement Or AFacture Then InitAgrifactDta("AFacture_Detail", dsAgrifact, False) : ReportProgress(75)
        If AReglement Then DtaAReglement = InitAgrifactDta("AReglement", dsAgrifact) : ReportProgress(80)
        If AReglement Then InitAgrifactDta("AReglement_Detail", dsAgrifact, False) : ReportProgress(85)
        If AReglement Then DtaAFactureMontantExport = InitAgrifactDta("AFactureMontantExport", dsAgrifact) : ReportProgress(90)

        DtaParametres = InitAgrifactDta("Parametres", dsAgrifact) : ReportProgress(90)

        ReportProgress(100)
    End Sub

    Public Function EnvoiCompta() As Boolean Implements IExportCompta.EnvoiCompta
        Try
            Dim res As Boolean = EnvoiComptaInterne()
            Return res
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Throw ex
        End Try
    End Function

    Protected Overridable Function EnvoiComptaInterne() As Boolean
        Try
            If Not ExporterFactures() Then Return False
            If Not ExporterRemises() Then Return False
            If Not ExporterFacturesAchat() Then Return False
            If Not ExporterReglementsAchats() Then Return False
        Catch ex As Exception
            Throw New ApplicationException("Erreur lors de l'exportation des pièces.", ex)
        End Try

        'Mise à jours des BDD
        UpdateData()

        Return True
    End Function

    Protected Overridable Sub UpdateData()
        UpdateAgrifact()
    End Sub

    Protected Sub UpdateAgrifact()
        Try
            ReportProgress(0, "Enregistrement des données Agrifact")
            If VReglement Or VFacture Then DtaVFacture.Update(dsAgrifact, "VFacture") : ReportProgress(20)
            If VReglement Then DtaReglement.Update(dsAgrifact, "Reglement") : ReportProgress(30)
            If VReglement Then DtaRemise.Update(dsAgrifact, "Remise") : ReportProgress(40)
            If VReglement Then DtaFactureMontantExport.Update(dsAgrifact, "FactureMontantExport") : ReportProgress(50)

            If AReglement Or AFacture Then DtaAFacture.Update(dsAgrifact, "AFacture") : ReportProgress(60)
            If AReglement Then DtaAReglement.Update(dsAgrifact, "AReglement") : ReportProgress(80)
            If AReglement Then DtaAFactureMontantExport.Update(dsAgrifact, "AFactureMontantExport") : ReportProgress(100)
        Catch ex As Exception
            Throw New ApplicationException("Erreur lors de la mise à jour de la base Agrifact.", ex)
        End Try
    End Sub

    Protected MustOverride Function ExporterFactures() As Boolean
    Protected MustOverride Function ExporterRemises() As Boolean
    Protected MustOverride Function ExporterFacturesAchat() As Boolean
    Protected MustOverride Function ExporterReglementsAchats() As Boolean

    Public Overridable Sub Close() Implements IExportCompta.Close
        Me.Dispose()
    End Sub

    Public Overridable Sub Dispose() Implements System.IDisposable.Dispose, IExportCompta.Dispose
        If Not cnAgriFact Is Nothing AndAlso cnAgriFact.State <> ConnectionState.Closed Then
            cnAgriFact.Close()
        End If
    End Sub
#End Region

#Region "Fonctions de chargement des données"
    Protected Function InitAgrifactDta(ByVal tableName As String, ByVal ds As DataSet, ByVal colFiltreDate As String, ByVal minFiltreDate As Date, ByVal maxFiltreDate As Date, Optional ByVal GenererCommandes As Boolean = True) As SqlClient.SqlDataAdapter
        Return InitAgrifactDta(tableName, String.Format("SELECT {0}.* FROM {0} WHERE {1}>='{2}' AND {1}<='{3}'", tableName, colFiltreDate, minFiltreDate, maxFiltreDate), ds, GenererCommandes)
    End Function

    Protected Function InitAgrifactDta(ByVal tableName As String, ByVal ds As DataSet, Optional ByVal GenererCommandes As Boolean = True) As SqlClient.SqlDataAdapter
        Return InitAgrifactDta(tableName, String.Format("SELECT {0}.* FROM {0}", tableName), ds, GenererCommandes)
    End Function

    Protected Function InitAgrifactDta(ByVal tableName As String, ByVal selectString As String, ByVal ds As DataSet, Optional ByVal GenererCommandes As Boolean = True) As SqlClient.SqlDataAdapter
        Dim dta As New SqlClient.SqlDataAdapter(selectString, cnAgriFact)
        If GenererCommandes Then
            Dim a As New SqlClient.SqlCommandBuilder(dta)
            a.QuoteSuffix = "]"
            a.QuotePrefix = "["
            dta.UpdateCommand = a.GetUpdateCommand
            dta.InsertCommand = a.GetInsertCommand
            dta.DeleteCommand = a.GetDeleteCommand
        End If
        dta.Fill(ds, tableName)
        Return dta
    End Function
#End Region

#Region "Fonctions utilitaires"
    Protected Function CadreFourchette(ByVal num As Integer, ByVal debFourchette As Integer, ByVal finFourchette As Integer) As Integer
        Return (num Mod (finFourchette + 1 - debFourchette)) + debFourchette
    End Function

    Protected Function PlusPetiteDate(ByVal ParamArray dates() As Date) As Date
        Dim minDate As Date = Date.MaxValue
        For Each d As Date In dates
            minDate = IIf(minDate < d, minDate, d)
        Next
        Return minDate
    End Function

    Protected Function PlusGrandeDate(ByVal ParamArray dates() As Date) As Date
        Dim maxDate As Date = Date.MinValue
        For Each d As Date In dates
            maxDate = IIf(maxDate > d, maxDate, d)
        Next
        Return maxDate
    End Function

    Protected Function ReplaceDbNull(ByVal value As Object, ByVal defaultValue As Object) As Object
        Return IIf(IsDBNull(value), defaultValue, value)
    End Function

    Protected Sub AjouterRapport(ByVal msg As String)
        RapportExport.Append(msg & vbCrLf)
    End Sub

    'Protected Sub xEcrireRapport(ByVal ex As Exception)
    '    Dim sw As New IO.StreamWriter("c:\RapportErreurExportCompta.txt", False)
    '    If Not ex Is Nothing Then
    '        sw.WriteLine("Exception : " & ex.ToString)
    '        If Not ex.InnerException Is Nothing Then
    '            sw.WriteLine("InnerException : " & ex.InnerException.ToString)
    '        End If
    '    End If
    '    If Me.RapportExport.Length > 0 Then
    '        sw.WriteLine("Avertissements : " & Me.RapportExport.ToString)
    '    End If
    '    sw.Close()
    'End Sub

    Protected Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        RaiseEvent ExportProgressed(Me, New ProgressEventArgs(percent, status))
    End Sub
#End Region

End Class