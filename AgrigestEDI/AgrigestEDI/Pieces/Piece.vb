Public Class ListOfPieces
    Inherits List(Of Piece)

#Region "Méthodes diverses"
    ''' <summary>
    ''' Permet d'ajouter à la list de pièces une nouvelle pièce
    ''' </summary>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <param name="DataSearch">Tableau des critères de recherche</param>
    ''' <remarks></remarks>
    Public Sub Charger(Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing, Optional ByVal DataSearch As Hashtable = Nothing)
        If DataSearch Is Nothing Then Me.AddRange(Charger(My.User.Name, worker)) Else Me.AddRange(ChargerSearch(My.User.Name, worker, DataSearch))
    End Sub

    ''' <summary>
    ''' permet de charger les pièces d'un bordereau en fonction de dates et du journal 
    ''' </summary>
    ''' <param name="dtDateMin"></param>
    ''' <param name="dtDateMax"></param>
    ''' <param name="sJournal"></param>
    ''' <param name="sJournalContrePartie"></param>
    ''' <param name="worker"></param>
    ''' <remarks></remarks>
    Public Sub ChargerBordereau(ByVal dtDateMin As Date, ByVal dtDateMax As Date, ByVal sJournal As String, ByVal sJournalContrePartie As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        Me.AddRange(ChargerBordereau(My.User.Name, dtDateMin, dtDateMax, sJournal, sJournalContrePartie, worker))
    End Sub

    ''' <summary>
    ''' Permet d'ajouter une piece à la liste existante
    ''' </summary>
    ''' <param name="xPiece">Pièce à ajouter</param>
    ''' <remarks></remarks>
    Public Sub AddPiece(ByRef xPiece As Piece)
        Me.Add(xPiece)
    End Sub
#End Region

#Region "Méthodes partagées"
    ''' <summary>
    ''' Permet de charger l'ensemble des pièces existante pour un exercice pour une exploitation 
    ''' </summary>
    ''' <param name="nDos">numéro du dossier</param>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <returns>retourne la liste des pièces</returns>
    ''' <remarks></remarks>
    Public Shared Function Charger(ByVal nDos As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As List(Of Piece)
        ReportProgress(worker, 0)
        Dim ds As New dbDonneesDataSet
        ReportProgress(worker, 10)
        'Chargement des différentes tables depuis la base de données pour charger les pièces
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, nDos)
        End Using
        ReportProgress(worker, 20)
        Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
            dta.FillByDossier(ds.Pieces, nDos)
        End Using
        ReportProgress(worker, 40)
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using
        ReportProgress(worker, 50)
        Using dta As New dbDonneesDataSetTableAdapters.LignesTableAdapter
            dta.FillByDossier(ds.Lignes, nDos)
        End Using
        ReportProgress(worker, 80)
        Using dta As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
            dta.FillByDossier(ds.Mouvements, nDos)
        End Using
        ReportProgress(worker, 90)
        Using dta As New dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
            dta.FillByDossier(ds.CompteTotal, nDos)
        End Using
        ReportProgress(worker, 100)

        Dim res As New List(Of Piece)(ds.Pieces.Rows.Count)
        Dim i As Integer = 0
        'Chargement des pièces
        For Each dr As dbDonneesDataSet.PiecesRow In ds.Pieces.Rows
            Dim p As New Piece(dr)
            res.Add(p)
            i += 1 : ReportProgress(worker, i, ds.Pieces.Rows.Count)
        Next
        Return res
    End Function

    ''' <summary>
    ''' Permet de charger l'ensemble des pièces existante pour un exercice pour une exploitation pour un journal et pour une période tout cela dans le bordereau
    ''' </summary>
    ''' <param name="nDos">numéro du dossier</param>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <returns>retourne la liste des pièces</returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerBordereau(ByVal nDos As String, ByVal dtDateMin As Date, ByVal dtDateMax As Date, ByVal sJournal As String, ByVal sJournalContrePartie As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As List(Of Piece)
        ReportProgress(worker, 0)
        Dim ds As New dbDonneesDataSet
        ReportProgress(worker, 10)
        'Chargement des différentes tables depuis la base de données pour charger les pièces
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, nDos)
        End Using
        ReportProgress(worker, 20)
        Using xConn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            'construction de la requête pour aller cherche les pièces du bordereau en fonction des critère de date et de journal
            Dim sPieceSql As String = FormatSql("SELECT DateExport, Exporte, Journal, Libelle, PDate, PDossier, " + _
                          "PPiece FROM Pieces WHERE (PDossier = {0}) " + _
                          "AND (PDate BETWEEN {1} AND {2}) ", nDos, dtDateMin, dtDateMax) + _
                          " AND (Journal ='" + sJournal + "')"
            FillDataTable(ds.Pieces, sPieceSql + " ORDER BY PDate", xConn)
        End Using
        ReportProgress(worker, 40)
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using
        ReportProgress(worker, 50)
        Using xConn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            FillDataTable(ds.Lignes, FormatSql("SELECT LDossier, LPiece, LDate, LLig, LTva, LLib, LGene, LAna, LJournal, LMtTVA FROM Lignes WHERE (LDossier = {0}) AND (LDate BETWEEN {1} AND {2})", nDos, _
            dtDateMin, dtDateMax) + " AND (LJournal ='" + sJournal + "')", xConn)
        End Using

        ReportProgress(worker, 80)
        Using dta As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
            dta.FillByDossierByDate(ds.Mouvements, nDos, dtDateMin, dtDateMax)
        End Using
        ReportProgress(worker, 90)
        Using dta As New dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
            dta.FillByDossier(ds.CompteTotal, nDos)
        End Using
        ReportProgress(worker, 100)

        Dim res As New List(Of Piece)(ds.Pieces.Rows.Count)
        Dim i As Integer = 0
        'Chargement des pièces
        For Each dr As dbDonneesDataSet.PiecesRow In ds.Pieces.Rows
            res.Add(New Piece(dr, sJournalContrePartie))
            i += 1 : ReportProgress(worker, i, ds.Pieces.Rows.Count)
        Next

        Return res
    End Function

    ''' <summary>
    ''' Permet de charger l'ensemble des pièces existante pour un exercice pour une exploitation selon des critères de filtrage (recherche)
    ''' </summary>
    ''' <param name="nDos">numéro du dossier</param>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <returns>retourne la liste des pièces</returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerSearch(ByVal nDos As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing, Optional ByVal DataSearch As Hashtable = Nothing) As List(Of Piece)

        ReportProgress(worker, 0)
        Dim ds As New dbDonneesDataSet
        ReportProgress(worker, 10)
        'Chargement des différentes tables depuis la base de données pour charger les pièces
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, nDos)
        End Using

        'récupère les critère de recherche
        If CStr(DataSearch("PieceDebut")).Length = 0 Then DataSearch("PieceDebut") = "0"
        If CStr(DataSearch("PieceFin")).Length = 0 Then DataSearch("PieceFin") = "99999"
        If CStr(DataSearch("DateDebut")).Length = 0 Then DataSearch("DateDebut") = "01/01/00"
        If CStr(DataSearch("DateFin")).Length = 0 Then DataSearch("DateFin") = "31/12/2099"

        ReportProgress(worker, 20)
        Using xConn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            'construit la requête pour retourner les pièces en fonction des critère de rechercher
            Dim sPieceSql As String = FormatSql("SELECT DateExport, Exporte, Journal, Libelle, PDate, PDossier, " + _
                          "PPiece FROM Pieces WHERE (PDossier = {0}) AND (PPiece BETWEEN {1} AND {2}) " + _
                          "AND (PDate BETWEEN {3} AND {4}) ", nDos, CInt(DataSearch("PieceDebut")), _
                          CInt(DataSearch("PieceFin")), CDate(DataSearch("DateDebut")), CDate(DataSearch("DateFin")))

            If (CStr(DataSearch("Journal")) <> "") Then
                sPieceSql = sPieceSql & " AND (Journal IN (" + CStr(DataSearch("Journal")) + "))"
            End If

            'permet de définir le sens de tri de la recherche
            If CStr(DataSearch("Ordre")) = "DATE" Then
                FillDataTable(ds.Pieces, sPieceSql + " ORDER BY PDate", xConn)
            Else
                FillDataTable(ds.Pieces, sPieceSql + " ORDER BY PPiece", xConn)
            End If
        End Using
        ReportProgress(worker, 40)
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using
        ReportProgress(worker, 50)
        Using xConn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim sqlSelect As String = String.Empty

            sqlSelect = FormatSql("SELECT LDossier, LPiece, LDate, LLig, LTva, LLib, LGene, LAna, LJournal, LMtTVA FROM Lignes WHERE (LDossier = {0}) AND (LPiece BETWEEN {1} AND {2}) AND (LDate BETWEEN {3} AND {4})", nDos, CInt(DataSearch("PieceDebut")), CInt(DataSearch("PieceFin")), CDate(DataSearch("DateDebut")), CDate(DataSearch("DateFin")))

            If (CStr(DataSearch("Journal")) <> "") Then
                sqlSelect = sqlSelect & " AND (LJournal IN (" + CStr(DataSearch("Journal")) + "))"
            End If

            'tri par numéro de ligne
            sqlSelect = sqlSelect & " ORDER BY LLig"

            'FillDataTable(ds.Lignes, FormatSql("SELECT LDossier, LPiece, LDate, LLig, LTva, LLib, LGene, LAna, LJournal, LMtTVA FROM Lignes WHERE (LDossier = {0}) AND (LPiece BETWEEN {1} AND {2}) AND (LDate BETWEEN {3} AND {4})", nDos, CInt(DataSearch("PieceDebut")), _
            'CInt(DataSearch("PieceFin")), CDate(DataSearch("DateDebut")), CDate(DataSearch("DateFin"))) + " AND (LJournal IN (" + CStr(DataSearch("Journal")) + "))", xConn)

            FillDataTable(ds.Lignes, sqlSelect, xConn)
        End Using

        ReportProgress(worker, 80)
        Using dta As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
            dta.FillByDossierByPieceByDate(ds.Mouvements, nDos, CInt(DataSearch("PieceDebut")), CInt(DataSearch("PieceFin")), CDate(DataSearch("DateDebut")), CDate(DataSearch("DateFin")))
        End Using
        ReportProgress(worker, 90)
        Using dta As New dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
            dta.FillByDossier(ds.CompteTotal, nDos)
        End Using
        ReportProgress(worker, 100)

        Dim res As New List(Of Piece)(ds.Pieces.Rows.Count)
        Dim i As Integer = 0

        'chargement des pièces
        For Each dr As dbDonneesDataSet.PiecesRow In ds.Pieces.Rows
            res.Add(New Piece(dr))
            i += 1 : ReportProgress(worker, i, ds.Pieces.Rows.Count)
        Next

        Return res
    End Function

    ''' <summary>
    ''' Permet d'implémenter la barre de progression du chargement des données
    ''' </summary>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <param name="value">valeur en cours de progression</param>
    ''' <param name="max">valeur max de la barre de progression</param>
    ''' <remarks></remarks>
    Private Shared Sub ReportProgress(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal value As Integer, Optional ByVal max As Integer = 100)
        If worker Is Nothing Then Exit Sub
        worker.ReportProgress(value * 100 \ max)
    End Sub
#End Region

End Class

Public Class Piece

#Region "Property"
    Public ReadOnly Property GetPiece() As Piece
        Get
            Return Me
        End Get
    End Property

    Private _lignes As New List(Of Ligne)
    ''' <summary>
    ''' liste des lignes associées à la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Property Lignes() As List(Of Ligne)
        Get
            Return _lignes
        End Get
        Set(ByVal value As List(Of Ligne))
            _lignes = value
        End Set
    End Property

    Private _exporte As Boolean
    ''' <summary>
    ''' définie si la pièce a été exporté
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Exporte() As Boolean
        Get
            Return _exporte
        End Get
        Set(ByVal value As Boolean)
            _exporte = value
        End Set
    End Property

    Private _dateExport As Nullable(Of Date)
    ''' <summary>
    ''' date de l'export de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DateExport() As Nullable(Of Date)
        Get
            Return _dateExport
        End Get
        Set(ByVal value As Nullable(Of Date))
            _dateExport = value
        End Set
    End Property

    Private _libelle As String
    ''' <summary>
    ''' libellé de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Private _nPiece As Integer
    ''' <summary>
    ''' numéro de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NPiece() As Integer
        Get
            Return _nPiece
        End Get
        Set(ByVal value As Integer)
            _nPiece = value
        End Set
    End Property

    Private _nPrevPiece As Integer
    ''' <summary>
    ''' numéro de pièce pour permettre des MAJ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NPrevPiece() As Integer
        Get
            Return _nPrevPiece
        End Get
        Set(ByVal value As Integer)
            _nPrevPiece = value
        End Set
    End Property

    Private _datePiece As Date
    ''' <summary>
    ''' date de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DatePiece() As Date
        Get
            Return _datePiece
        End Get
        Set(ByVal value As Date)
            _datePiece = value
        End Set
    End Property

    Private _prevdatePiece As Date
    ''' <summary>
    ''' date de la pièce pour permettre des MAJ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrevDatePiece() As Date
        Get
            Return _prevdatePiece
        End Get
        Set(ByVal value As Date)
            _prevdatePiece = value
        End Set
    End Property

    Private _journal As String
    ''' <summary>
    ''' code journal de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Journal() As String
        Get
            Return _journal
        End Get
        Set(ByVal value As String)
            _journal = value
        End Set
    End Property

    Private _dossier As String
    ''' <summary>
    ''' numéro du dossier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Dossier() As String
        Get
            Return _dossier
        End Get
        Set(ByVal value As String)
            _dossier = value
        End Set
    End Property

    Private _prevdossier As String
    ''' <summary>
    ''' numéro de dossier de la pièce pour permettre des MAJ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrevDossier() As String
        Get
            Return _prevdossier
        End Get
        Set(ByVal value As String)
            _prevdossier = value
        End Set
    End Property

    ''' <summary>
    ''' permet de définir si la pièce est équilibré
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsEquilibre() As Boolean
        Get
            Return (CalcSommeDeb() = CalcSommeCre())
        End Get
    End Property

    Private _IsNew As Boolean
    ''' <summary>
    ''' indique s'il s'agit d'un nouvelle pièce 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsNew() As Boolean
        Get
            Return _IsNew
        End Get
    End Property

    Dim _MontantDebContrePartie As Nullable(Of Decimal)
    ''' <summary>
    ''' permet de définir le montant total de la contre partie au débit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantDebContrePartie() As Decimal
        Get
            Return _MontantDebContrePartie.GetValueOrDefault(0)
        End Get
        Set(ByVal value As Decimal)
            _MontantDebContrePartie = value
        End Set
    End Property

    Dim _MontantCreContrePartie As Nullable(Of Decimal)
    ''' <summary>
    ''' permet de définir le montant total de la contre partie au crédit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantCreContrePartie() As Decimal
        Get
            Return _MontantCreContrePartie.GetValueOrDefault(0)
        End Get
        Set(ByVal value As Decimal)
            _MontantCreContrePartie = value
        End Set
    End Property

    Dim _SoldeContrePartie As Nullable(Of Decimal)
    ''' <summary>
    ''' permet de retourner le solde de la contre partie pour la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SoldeContrePartie() As Decimal
        Get
            Return _SoldeContrePartie.GetValueOrDefault(0)
        End Get
        Set(ByVal value As Decimal)
            _SoldeContrePartie = value
        End Set
    End Property

    ''' <summary>
    ''' permet de cumuler le montant débit-credit de la pièce sur le compte de contre partie
    ''' passer en paramètre (utiliser pour le bordereau)
    ''' </summary>
    ''' <param name="Compte"></param>
    ''' <remarks></remarks>
    Public Sub SetMontantContrePartie(ByVal Compte As String)

        Dim nCalculD As Decimal = 0
        Dim nCalculC As Decimal = 0
        If Compte <> "" Then
            For Each xLigne As Ligne In Me.Lignes
                If Compte = xLigne.Compte Then
                    nCalculD += xLigne.MontantDeb.GetValueOrDefault(0)
                    nCalculC += xLigne.MontantCre.GetValueOrDefault(0)
                End If
            Next
        End If
        _MontantDebContrePartie = nCalculD
        _MontantCreContrePartie = nCalculC
        _SoldeContrePartie = _MontantDebContrePartie.GetValueOrDefault(0) - _MontantCreContrePartie.GetValueOrDefault(0)
    End Sub

#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' constructeur par défaut
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _IsNew = True
    End Sub

    ''' <summary>
    ''' détermine le numéro de pièce en fonction du journal
    ''' </summary>
    ''' <param name="bNewPiece"></param>
    ''' <param name="sJournal"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bNewPiece As Boolean, ByVal sJournal As String)
        Me.New()
        If bNewPiece Then
            Me.NPiece = DefineDateNumPiece(sJournal)
        End If
        Me.Journal = sJournal
        Me.Dossier = My.User.Name
    End Sub

    ''' <summary>
    ''' détermine le numéro de pièce pour le bordereau
    ''' </summary>
    ''' <param name="sJournal"></param>
    ''' <param name="sDate"></param>
    ''' <param name="nLastPieceBordereau"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal sJournal As String, ByVal sDate As Date, Optional ByVal nLastPieceBordereau As Integer = 0)
        Me.New()
        If sJournal <> "" Or sDate <> Nothing Then
            Me.DatePiece = sDate
            Me.Journal = sJournal
            'va cherche le numéro de pièce en fonction du journal
            Dim ntemp As Integer = DefineDateNumPiece(sJournal)
            'donne le bon numéro de pièce en fonction du dernier numéro de pièce du bordereau
            If nLastPieceBordereau >= ntemp Then
                Me.NPiece = nLastPieceBordereau + 1
            Else
                Me.NPiece = ntemp
            End If
            Me.Dossier = My.User.Name
        End If
    End Sub

    ''' <summary>
    ''' constructeur pour charger les propriétées d'une pièce ainsi que les lignes associées
    ''' </summary>
    ''' <param name="nNumPiece"></param>
    ''' <param name="dtDatePiece"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal nNumPiece As Integer, ByVal dtDatePiece As Date)

        'implémente les proprétées de la pièce
        Me.New()
        Dim TempNew As Piece = ChargerPiece(nNumPiece, dtDatePiece)
        With TempNew
            Me._IsNew = False
            Me.NPrevPiece = .NPrevPiece
            Me.NPiece = .NPiece
            Me.PrevDatePiece = .PrevDatePiece
            Me.DatePiece = .DatePiece
            Me.Exporte = .Exporte
            Me.PrevDossier = .PrevDossier
            Me.Dossier = .Dossier
            Me.Libelle = .Libelle
            Me.DateExport = .DateExport
            Me.Journal = .Journal
            Me.Lignes = .Lignes
        End With
    End Sub

    ''' <summary>
    ''' constructeur pour charger les propriétées d'une pièce ainsi que les lignes associées
    ''' </summary>
    ''' <param name="drp">dataset contenant la pièce ainsi que les lignes associées</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal drp As dbDonneesDataSet.PiecesRow)

        'implémente les proprétées de la pièce
        Me.New()
        Dim i As Integer = 0
        Me._IsNew = False
        Me.NPrevPiece = drp.PPiece
        Me.NPiece = drp.PPiece
        Me.PrevDatePiece = drp.PDate
        Me.DatePiece = drp.PDate
        Me.Exporte = drp.Exporte
        Me.PrevDossier = drp.PDossier
        Me.Dossier = drp.PDossier
        If Not drp.IsJournalNull Then Me.Journal = drp.Journal Else Me.Journal = ""
        If Not drp.IsLibelleNull Then Me.Libelle = drp.Libelle Else Me.Libelle = "LIBELLE"
        If drp.IsDateExportNull Then
            Me.DateExport = New Nullable(Of Date)
        Else
            Me.DateExport = drp.DateExport
        End If

        'chargement des lignes de la pièce
        For Each drl As dbDonneesDataSet.LignesRow In drp.GetLignesRows
            'ajoute les lignes de la pièce
            Me.Lignes.AddRange(Ligne.ChargerLignes(drl, i))
            i += 1
        Next
        Me.SetMontantContrePartie("03")
    End Sub

    ''' <summary>
    ''' constructeur pour charger les propriétées d'une pièce ainsi que les lignes associées
    ''' </summary>
    ''' <param name="drp">dataset contenant la pièce ainsi que les lignes associées</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal drp As dbDonneesDataSet.PiecesRow, ByVal sJournalContrePartie As String)

        'implémente les proprétées de la pièce
        Me.New()
        Dim i As Integer = 0
        Me._IsNew = False
        Me.NPrevPiece = drp.PPiece
        Me.NPiece = drp.PPiece
        Me.PrevDatePiece = drp.PDate
        Me.DatePiece = drp.PDate
        Me.Exporte = drp.Exporte
        Me.PrevDossier = drp.PDossier
        Me.Dossier = drp.PDossier
        If Not drp.IsJournalNull Then Me.Journal = drp.Journal Else Me.Journal = ""
        If Not drp.IsLibelleNull Then Me.Libelle = drp.Libelle Else Me.Libelle = "LIBELLE"
        If drp.IsDateExportNull Then
            Me.DateExport = New Nullable(Of Date)
        Else
            Me.DateExport = drp.DateExport
        End If

        'chargement des lignes de la pièce
        For Each drl As dbDonneesDataSet.LignesRow In drp.GetLignesRows
            'ajoute les lignes de la pièce
            Me.Lignes.AddRange(Ligne.ChargerLignes(drl, i))
            i += 1
        Next
        Me.SetMontantContrePartie(sJournalContrePartie)
    End Sub
#End Region

#Region "Méthodes diverses"
    ''' <summary>
    ''' permet grace au journal et à l'option d'incrémentation de la pièce de définir le numéro de pièce et la date
    ''' </summary>
    ''' <param name="sJournal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DefineDateNumPiece(ByVal sJournal As String) As Integer
        With My.Dossier.Principal
            Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                'détermine la date de la pièce
                Dim dt As Date = .DateDebutEx
                Dim num As Integer = 1
                Select Case .IncrementationPiece
                    Case 0 'Incrémentation globale
                        dt = Min(dta.GetMaxDateByDossier(My.User.Name).GetValueOrDefault(.DateDebutEx), .DateFinEx)
                        dt = CDate(dt.ToShortDateString)
                        num = Convert.ToInt32((dta.GetNumMaxPiecePeriodeByDossier(My.User.Name, .DateDebutEx, .DateFinEx))) + 1
                    Case 1 'Incrémentation par journal
                        dt = Min(dta.GetMaxDateByDossierByJournal(My.User.Name, sJournal).GetValueOrDefault(.DateDebutEx), .DateFinEx)
                        dt = CDate(dt.ToShortDateString)
                        num = Convert.ToInt32((dta.GetNumMaxPieceByDossierByJournal(My.User.Name, .DateDebutEx, .DateFinEx, sJournal))) + 1
                End Select

                Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

                If (dossier.DDtClotureTVA.HasValue) Then
                    If (dt <= CDate(dossier.DDtClotureTVA)) Then
                        Me.DatePiece = Microsoft.VisualBasic.DateAdd(DateInterval.Day, 1, CDate(dossier.DDtClotureTVA))
                    Else
                        Me.DatePiece = dt
                    End If
                Else
                    Me.DatePiece = dt
                End If

                'si la pièce existe il va incrémenter de +1 la numéro jusqu'a ce qu'il trouve un numéro de libre
                While CType(dta.ExistPiece(My.User.Name, num, dt), Integer) > 0
                    num += 1
                End While
                Return num
            End Using
        End With
    End Function

    ''' <summary>
    ''' permet de définie en fonction du journal le numéro de ma pièce
    ''' </summary>
    ''' <param name="sJournal"></param>
    ''' <param name="NumLockted"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDataPieceFromJournal(ByVal sJournal As String, ByVal NumLockted As Boolean) As Boolean

        If sJournal <> "" Then
            Me.NPiece = DefineDateNumPiece(sJournal)
        Else
            Me.NPiece = Nothing
            Me.DatePiece = Nothing
        End If
        Return True

    End Function

    ''' <summary>
    ''' permet de cloner une pièce 
    ''' </summary>
    ''' <param name="nLastPieceBordereau"></param>
    ''' <returns></returns>
    ''' <remarks>si celle ci est dans un bordereau il faut faire passer le numéro du dernier enregistrement 
    ''' dans le bordereau pour qu'il puisse créer sur la pièce cloné le bon numéro</remarks>
    Public Function Clone(ByVal nLastPieceBordereau As Integer) As Piece
        Dim xNewPiece As New Piece
        With xNewPiece
            If nLastPieceBordereau >= Me.NPrevPiece Then
                .NPiece = nLastPieceBordereau + 1
            Else
                .NPiece = Me.NPiece + 1
            End If
            .PrevDatePiece = Me.PrevDatePiece
            .DatePiece = Me.DatePiece
            .Exporte = Me.Exporte
            .PrevDossier = Me.PrevDossier
            .Dossier = Me.Dossier
            .Libelle = Me.Libelle
            .DateExport = Me.DateExport
            .Journal = Me.Journal
            .MontantCreContrePartie = Me.MontantCreContrePartie
            .MontantDebContrePartie = Me.MontantDebContrePartie
            For Each xLigne As Ligne In Lignes
                .Lignes.Add(xLigne.Clone)
            Next
        End With
        Return xNewPiece
    End Function

    ''' <summary>
    ''' Chargement d'une pièce d'un exercice pour une exploitation 
    ''' </summary>
    ''' <param name="nPiece">numéro de la pièce</param>
    ''' <param name="dtPiece">date de la pièce</param>
    ''' <returns>retourne la pièce demandée</returns>
    ''' <remarks>My.User.Name est le numéro du dossier en cour de traitement</remarks>
    Public Function ChargerPiece(ByVal nPiece As Integer, ByVal dtPiece As Date) As Piece

        Return ChargerPiece(My.User.Name, nPiece, dtPiece)

    End Function

    ''' <summary>
    ''' Ajoute la pièce indiqué pour un exercice d'un exploitation
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AjoutPiece() As Boolean
        If Me.DatePiece > CDate(FormatDateTime(My.Dossier.Principal.DateFinEx, DateFormat.ShortDate)) OrElse Me.DatePiece < CDate(FormatDateTime(My.Dossier.Principal.DateDebutEx, DateFormat.ShortDate)) Then
            MsgBox(String.Format("La date {0:dd/MM/yyyy} n'est pas dans l'exercice.", Me.DatePiece), MsgBoxStyle.Information, "Enregistrement de pièce")
            Return False
        End If
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            Dim t As OleDb.OleDbTransaction = conn.BeginTransaction
            Try
                Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                    dta.SetTransaction(t)
                    'vérifie que la pièce n'existe pas en base
                    If CType(dta.ExistPiece(Me.Dossier, Me.NPiece, Me.DatePiece), Integer) = 0 Then
                        dta.Insert(My.User.Name, Me.NPiece, Me.DatePiece, Me.Exporte, CDate(IIf(IsDBNull(Me.DateExport), New Nullable(Of Date)(), Me.DateExport)), Me.Libelle, Me.Journal, "")
                        AjoutDataLigne(t)
                    Else
                        MsgBox(String.Format(My.Resources.Strings.Saisie_CollisionPieces, Me.NPiece), MsgBoxStyle.Information, "Enregistrement de pièce")
                        t.Rollback()
                        t = Nothing
                        Return False
                    End If
                End Using
                t.Commit()
                t = Nothing
                'met les données clé de ma pièce à jour afin de permettre la MAJ plus tard si besoin dans l'écran
                Me.PrevDossier = Me.Dossier
                Me.PrevDatePiece = Me.DatePiece
                Me.NPrevPiece = Me.NPiece
            Catch ex As Exception
                If t IsNot Nothing Then t.Rollback()
                Throw ex
            End Try
        End Using
        _IsNew = False
        Return True
    End Function

    ''' <summary>
    ''' MAJ la pièce indiqué pour un exercice d'un exploitation
    ''' </summary>
    ''' <remarks></remarks>
    Public Function MAJPiece() As Boolean
        Try
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                Dim t As OleDb.OleDbTransaction = conn.BeginTransaction
                Try
                    Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                        dta.SetTransaction(t)
                        'vérifie que la pièce mise à jour est la bonne 
                        'et que les clés nouvelles et anciennes ne créer pas de problèmes
                        Dim nDoAction As Integer = 0
                        If Me.NPrevPiece = Me.NPiece AndAlso CType(dta.ExistPiece(Me.Dossier, Me.NPrevPiece, Me.PrevDatePiece), Integer) = 1 Then
                            nDoAction = 1
                        ElseIf Me.NPrevPiece <> Me.NPiece AndAlso CType(dta.ExistPiece(Me.Dossier, Me.NPiece, Me.DatePiece), Integer) = 0 AndAlso CType(dta.ExistPiece(Me.Dossier, Me.NPrevPiece, Me.PrevDatePiece), Integer) = 1 Then
                            nDoAction = 1
                        End If
                        'Si la vérification est correct on supprime tout et on réintègre tout
                        If nDoAction = 1 Then
                            SuppressionDataLigne(t)
                            dta.UpdateTotal(Me.Dossier, Me.NPiece, Me.DatePiece, Me.Exporte, Me.DateExport, Me.Libelle, Me.Journal, Me.PrevDossier, Me.NPrevPiece, Me.PrevDatePiece)
                            AjoutDataLigne(t)
                        Else
                            'MsgBox(String.Format("La pièce {0} du {1:dd/MM/yy} est introuvable en base.", Me.NPrevPiece, Me.PrevDatePiece), MsgBoxStyle.Information, "Enregistrement de pièce")
                        End If
                        VerifLettrage(t)
                    End Using
                    t.Commit()
                Catch ex As Exception
                    Try
                        If t IsNot Nothing Then t.Rollback()
                    Catch
                    End Try
                    Throw New ApplicationException(ex.Message, ex)
                End Try
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        _IsNew = False
        Return True
    End Function

    Private Sub VerifLettrage(ByVal t As OleDb.OleDbTransaction)
        For Each l As Ligne In Me.Lignes
            l.VerifLettrage(t)
        Next
    End Sub

    Public Function CodePointageMvtExiste() As Boolean
        Dim existe As Boolean = False

        For Each l As Ligne In Me.Lignes
            If Not (IsDBNull(l.CodePointageMvt)) Then
                existe = True
            End If
        Next

        Return existe
    End Function

    ''' <summary>
    ''' Supprime la pièce et ses enregistrements de la base de donnée
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SuppressionPiece() As Boolean
        Return SuppressionPiece(Me.Dossier, Me.NPiece, Me.DatePiece)
    End Function

    ''' <summary>
    ''' Ajoute les lignes et les mouvements dans la base de donnée via transaction
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AjoutDataLigne(ByRef t As OleDb.OleDbTransaction)
        Try
            Dim i As Integer = 0
            For Each xline As Ligne In Me.Lignes
                If xline.Compte <> Nothing Then
                    xline.AjouteLigneMouvBase(CStr(IIf(Me.Dossier = Nothing, My.User.Name, Me.Dossier)), Me.NPiece, Me.DatePiece, Me.Journal, i, t)
                    i += 1
                End If
            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Suppression des lignes et des mouvements dans la base de donnée via transaction
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SuppressionDataLigne(ByRef t As OleDb.OleDbTransaction)
        SuppressionDataLigne(t, Me.PrevDossier, Me.NPrevPiece, Me.PrevDatePiece)
    End Sub

    ''' <summary>
    ''' calcule la somme en débit en temps réel 
    ''' </summary>
    ''' <returns>retour le débit</returns>
    ''' <remarks>pour le moment seulement utiliser dans la barre des tâches</remarks>
    Public Function CalcSommeDeb() As Decimal
        Dim res As Decimal
        For Each l As Ligne In Me.Lignes
            If l.MontantDeb.HasValue Then res += l.MontantDeb.Value
        Next
        Return res
    End Function

    ''' <summary>
    ''' calcule la somme en crédit en temps réel 
    ''' </summary>
    ''' <returns>retour le crédit</returns>
    ''' <remarks>pour le moment seulement utiliser dans la barre des tâches</remarks>
    Public Function CalcSommeCre() As Decimal
        Dim res As Decimal
        For Each l As Ligne In Me.Lignes
            If l.MontantCre.HasValue Then res += l.MontantCre.Value
        Next
        Return res
    End Function

    ''' <summary>
    ''' Permet la cloturer les écritures d'une pièce sur un compte
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ClosePiece(ByVal sCpteCloture As String, ByVal sCpteClotureLib As String, ByVal dtCompteTotal As dbDonneesDataSet.CompteTotalDataTable) As Boolean

        Dim xListVenteAchat As New SortedList(Of String, Decimal)
        Try

            If Me.Lignes.Count = 1 AndAlso Me.Lignes(0).Compte = sCpteCloture Then
                MsgBox(My.Resources.Strings.Saisie_SoldeImpossibleSurCpte, MsgBoxStyle.Exclamation, My.Resources.Strings.Saisie_SolderPiece)
                Return False
            End If

            For i As Integer = Me.Lignes.Count - 1 To 0 Step -1
                If Me.Lignes(i).Compte = sCpteCloture Then
                    If MsgBox(My.Resources.Strings.Saisie_AskResetContrepartie + vbCrLf + _
                                My.Resources.Strings.Saisie_AskResetContrePartie2 + vbCrLf + _
                                My.Resources.Strings.SouhaitezVousContinuer, MsgBoxStyle.YesNo, My.Resources.Strings.Saisie_SolderPiece) = MsgBoxResult.Yes Then
                        'supprime les lignes de contre partie existante
                        For j As Integer = Me.Lignes.Count - 1 To 0 Step -1
                            If Me.Lignes(j).Compte = sCpteCloture Then
                                Me.Lignes.RemoveAt(j)
                            End If
                        Next
                        Exit For
                    End If
                End If
            Next

            xListVenteAchat.Add("Debit", 0)
            xListVenteAchat.Add("Credit", 0)
            For Each xLigne As Ligne In Me.Lignes
                xListVenteAchat("Debit") += xLigne.MontantDeb.GetValueOrDefault(0)
                xListVenteAchat("Credit") += xLigne.MontantCre.GetValueOrDefault(0)
            Next
            If xListVenteAchat("Debit") <> xListVenteAchat("Credit") Then
                Dim xNewLigne As New Ligne()
                xNewLigne.Compte = sCpteCloture
                xNewLigne.Activite = "0000"
                xNewLigne.Libelle = "Total - " + sCpteClotureLib
                If xListVenteAchat("Debit") > xListVenteAchat("Credit") Then
                    xNewLigne.MontantCre = xListVenteAchat("Debit") - xListVenteAchat("Credit")
                ElseIf xListVenteAchat("Debit") < xListVenteAchat("Credit") Then
                    xNewLigne.MontantDeb = xListVenteAchat("Credit") - xListVenteAchat("Debit")
                End If

                Dim dtaCompteTotal() As DataRow = dtCompteTotal.Select(String.Format("Cpt='{0}' AND Acti='{1}'", xNewLigne.Compte, xNewLigne.ActiviteShowAll))
                If dtaCompteTotal.Length > 0 Then
                    xNewLigne.TotalDebit = CType(dtaCompteTotal(0).Item("TotalDebit"), Decimal)
                    xNewLigne.TotalCredit = CType(dtaCompteTotal(0).Item("TotalCredit"), Decimal)
                End If

                Me.Lignes.Add(xNewLigne)

                Me._MontantCreContrePartie = 0
                Me._MontantDebContrePartie = 0
                For Each xLigne As Ligne In Me.Lignes
                    If xLigne.Compte = sCpteCloture Then
                        Me._MontantCreContrePartie = xLigne.MontantCre.GetValueOrDefault(0) + Me._MontantCreContrePartie.GetValueOrDefault(0)
                        Me._MontantDebContrePartie = xLigne.MontantDeb.GetValueOrDefault(0) + Me._MontantDebContrePartie.GetValueOrDefault(0)
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            LogException(ex)
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

    ''' <summary>
    ''' permet de rafraichir la pièce sur qui la demande a été faite
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RafraichirBase()

        Dim xTemp As Piece = ChargerPiece(My.User.Name, Me.NPrevPiece, Me.PrevDatePiece)
        Dim i As Integer = 0
        Me.NPrevPiece = xTemp.NPrevPiece
        Me.NPiece = xTemp.NPiece
        Me.PrevDatePiece = PrevDatePiece
        Me.DatePiece = xTemp.DatePiece
        Me.Exporte = xTemp.Exporte
        Me.PrevDossier = xTemp.PrevDossier
        Me.Dossier = xTemp.Dossier
        Me.Libelle = xTemp.Libelle
        Me.DateExport = xTemp.DateExport
        Me.Journal = xTemp.Journal
        Me.Lignes = xTemp.Lignes

    End Sub

    ''' <summary>
    ''' permet de rafraichir les données concernant une pièce précise sur celle en cours
    ''' </summary>
    ''' <param name="nPiece"></param>
    ''' <param name="dtDatePiece"></param>
    ''' <remarks></remarks>
    Public Sub RafraichirBase(ByVal nPiece As Integer, ByVal dtDatePiece As Date)

        Dim xTemp As Piece = ChargerPiece(My.User.Name, nPiece, dtDatePiece)
        Dim i As Integer = 0
        Me.NPrevPiece = xTemp.NPrevPiece
        Me.NPiece = xTemp.NPiece
        Me.PrevDatePiece = PrevDatePiece
        Me.DatePiece = xTemp.DatePiece
        Me.Exporte = xTemp.Exporte
        Me.PrevDossier = xTemp.PrevDossier
        Me.Dossier = xTemp.Dossier
        Me.Libelle = xTemp.Libelle
        Me.DateExport = xTemp.DateExport
        Me.Journal = xTemp.Journal
        Me.Lignes = xTemp.Lignes

    End Sub

    ''' <summary>
    ''' permet de sauvegarder un pièce en tant que modèle
    ''' </summary>
    ''' <param name="sNameModele"></param>
    ''' <remarks></remarks>
    Public Sub SavePieceToModele(ByVal sNameModele As String)

        Dim xModele As New Modele
        xModele.Modele = sNameModele.Replace("'", "''")
        For Each xLigne As Ligne In Me.Lignes
            xModele.Lignes.Add(xLigne)
        Next
        xModele.AjoutMAJModele(True)

    End Sub
#End Region

#Region "Méthodes partagées"
    ''' <summary>
    ''' Chargement d'une pièce d'un exercice pour une exploitation 
    ''' </summary>
    ''' <param name="nDos">numéro du dossier</param>
    ''' <param name="nPiece">numéro de la pièce</param>
    ''' <param name="dtPiece">date de la pièce</param>
    ''' <returns>retourne la pièce demandée</returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerPiece(ByVal nDos As String, ByVal nPiece As Integer, ByVal dtPiece As Date) As Piece

        Dim ds As New dbDonneesDataSet
        'Chargement des différentes tables depuis la base pour charger la pièce
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, nDos)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
            dta.FillByPiece(ds.Pieces, nDos, nPiece, dtPiece)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.LignesTableAdapter
            dta.FillByPiece(ds.Lignes, nDos, nPiece, dtPiece)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
            dta.FillByPiece(ds.Mouvements, nDos, nPiece, dtPiece)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
            dta.FillByDossier(ds.CompteTotal, nDos)
        End Using

        'Initialise des objets
        Dim drp As dbDonneesDataSet.PiecesRow = ds.Pieces.FindByPDossierPPiecePDate(nDos, nPiece, dtPiece)
        If drp IsNot Nothing Then
            Return New Piece(drp)
        Else
            Throw New ApplicationException("Piece introuvable")
        End If
    End Function

    ''' <summary>
    ''' permet de supprimer une pièce dans la base de données
    ''' </summary>
    ''' <param name="nDos"></param>
    ''' <param name="nPiece"></param>
    ''' <param name="dtPiece"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SuppressionPiece(ByVal nDos As String, ByVal nPiece As Integer, ByVal dtPiece As Date) As Boolean
        Try
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                    Try
                        Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                            dta.SetTransaction(t)
                            'vérifie que la pièce existe
                            If CType(dta.ExistPiece(nDos, nPiece, dtPiece), Integer) > 0 Then
                                SuppressionDataLigne(t, nDos, nPiece, dtPiece)
                                dta.Delete(nDos, nPiece, dtPiece)
                            Else
                                MsgBox(My.Resources.Strings.Saisie_PieceInexistante, MsgBoxStyle.Information, My.Resources.Strings.SuppressionDePiece)
                            End If
                        End Using
                        t.Commit()
                    Catch ex As Exception
                        t.Rollback()
                        Throw New ApplicationException(ex.Message, ex)
                    End Try
                End Using
            End Using
            'MsgBox(My.Resources.Strings.Saisie_PieceSupprimee, MsgBoxStyle.Information, My.Resources.Strings.SuppressionDePiece)
            Return True
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

    Private Shared Sub SuppressionDataLigne(ByRef t As OleDb.OleDbTransaction, ByVal nDos As String, ByVal nPiece As Integer, ByVal dtPiece As Date)
        Using dta As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
            dta.SetTransaction(t)
            dta.DeleteMouvFullByLigne(nDos, nPiece, dtPiece)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.LignesTableAdapter
            dta.SetTransaction(t)
            dta.DeleteLigneFull(nDos, nPiece, dtPiece)
        End Using
    End Sub
#End Region

#Region "Gestion de la cloture de TVA"

    ''' <summary>
    ''' Permet la cloture de la TVA pour une pièce au montant HT
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseTVAHT(ByVal bFirst As Boolean, ByVal dtTVA As DataTable) As String

        Dim xListTVA As New Dictionary(Of String, RecapTva)
        Dim sPosition As String = ""
        Try
            If Me.Lignes.Count > 0 Then
                'Charge tous les comptes de TVA dans une chaine de string
                Dim sListTVA As New AutoCompleteStringCollection
                For Each xRow As dbDonneesDataSet.TVARow In dtTVA.Rows
                    sListTVA.Add(xRow("TCpt").ToString)
                Next
                'Vérifie s'il existe déjà des lignes de TVA et propose de tout réinitialiser
                For i As Integer = Me.Lignes.Count - 1 To 0 Step -1
                    If sListTVA.IndexOf(Me.Lignes(i).Compte) >= 0 Then
                        If MsgBox(My.Resources.Strings.Saisie_AskResetTVA + vbCrLf + _
                        My.Resources.Strings.Saisie_AskResetTVA2 + vbCrLf + _
                        My.Resources.Strings.SouhaitezVousContinuer, MsgBoxStyle.YesNo, My.Resources.Strings.Sasie_CalculDeTVA) = MsgBoxResult.Yes Then
                            'supprime les lignes de TVA existante
                            For j As Integer = Me.Lignes.Count - 1 To 0 Step -1
                                If sListTVA.IndexOf(Me.Lignes(j).Compte) >= 0 Then
                                    Me.Lignes.RemoveAt(j)
                                End If
                            Next
                            Exit For
                        End If
                    End If
                Next

                'alimente le tableau des Code TVA
                For Each xLigne As Ligne In Me.Lignes
                    If xLigne.CodeTva IsNot Nothing AndAlso xLigne.CodeTva.Trim <> "" Then
                        If xListTVA.ContainsKey(xLigne.CodeTva) Then
                            xListTVA(xLigne.CodeTva).Add(xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0))
                        Else
                            Dim rws() As DataRow = dtTVA.Select("TTVA='" + xLigne.CodeTva + "'")
                            If rws.Length > 0 Then
                                Dim xRowTemp As DataRow = rws(0)
                                Dim tx As Single = CSng(rws(0).ItemArray.GetValue(5))
                                xListTVA.Add(xLigne.CodeTva, New RecapTva(xLigne.CodeTva, xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0), tx))
                            End If
                        End If
                    End If
                Next

                'Supprime les montant de base HT pour les lignes de TVA qui en ont déjà
                For Each sCodeTVA As String In xListTVA.Keys
                    Dim sCompteTvaACloturer As String = "x"
                    Dim rws() As DataRow = dtTVA.Select("TTVA='" + sCodeTVA + "'")
                    If rws.Length > 0 Then
                        Dim xRowTemp As DataRow = rws(0)
                        sCompteTvaACloturer = rws(0).ItemArray.GetValue(3).ToString
                    End If
                    For Each xLigne As Ligne In Me.Lignes
                        If xLigne.Compte = sCompteTvaACloturer Then
                            If xLigne.MontantBaseHT.HasValue Then
                                If xLigne.MontantDeb.GetValueOrDefault <> 0 Then
                                    xListTVA(sCodeTVA).SubtractValeurHTDeb(xLigne.MontantBaseHT.Value)
                                Else
                                    xListTVA(sCodeTVA).SubtractValeurHTDeb(-xLigne.MontantBaseHT.Value)
                                End If
                            End If
                        End If
                    Next
                Next

                'créer les nouveau compte de TVA
                For Each sCodeTVA As String In xListTVA.Keys
                    If xListTVA(sCodeTVA).GetValeurHT <> 0 Then
                        Dim nTauxTVA As Single
                        Dim sCompteTvaACloturer As String
                        'Va chercher les informations relative au code TVA dans le plan type
                        Dim rws() As DataRow = dtTVA.Select("TTVA='" + sCodeTVA + "'")
                        If rws.Length > 0 Then
                            Dim xRowTemp As DataRow = rws(0)
                            nTauxTVA = CType(xRowTemp.ItemArray.GetValue(5).ToString, Single)
                            sCompteTvaACloturer = rws(0).ItemArray.GetValue(3).ToString
                        End If

                        Dim xNewLigne As New Ligne
                        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                            conn.Open()
                            Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                                xNewLigne.CheckAndCreateComptePlanComptable(sCompteTvaACloturer, t)
                            End Using
                        End Using
                        xNewLigne.Compte = sCompteTvaACloturer
                        xNewLigne.Libelle = "TVA " + sCodeTVA + " - " + Me.Libelle
                        xNewLigne.CodeTVACompte = sCodeTVA
                        xNewLigne.MontantBaseHT = xListTVA(sCodeTVA).GetValeurHT
                        If xListTVA(sCodeTVA).GetValeurTVA <> 0 Then
                            If xListTVA(sCodeTVA).IsDebitTVA Then
                                xNewLigne.MontantDeb = xListTVA(sCodeTVA).GetValeurTVA
                            Else
                                xNewLigne.MontantCre = xListTVA(sCodeTVA).GetValeurTVA
                            End If
                        Else
                            sPosition = sCompteTvaACloturer
                        End If
                        Me.Lignes.Add(xNewLigne)
                        If bFirst Then
                            Exit For
                        End If
                    End If
                Next
            End If
            Return sPosition
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

    ''' <summary>
    ''' permet de savoir lors de la cloture de la pièce si la TVA à bien été réalisé
    ''' </summary>
    ''' <param name="dtTVA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsTVAClosed(ByVal dtTVA As DataTable) As Boolean
        Dim xListTVA As New Dictionary(Of String, RecapTva)
        Try
            If Me.Lignes.Count > 0 Then
                'Fait un récap TVA de la pièce
                For Each xLigne As Ligne In Me.Lignes
                    If xLigne.CodeTva IsNot Nothing AndAlso xLigne.CodeTva.Trim <> "" Then
                        'LIGNE SOUMISE A TVA
                        If xListTVA.ContainsKey(xLigne.CodeTva) Then
                            xListTVA(xLigne.CodeTva).Add(xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0))
                        Else
                            Dim xRowTemp As DataRow = dtTVA.Select("TTVA='" + xLigne.CodeTva + "'")(0)
                            xListTVA.Add(xLigne.CodeTva, _
                                        New RecapTva(xLigne.CodeTva, _
                                                    xLigne.MontantDeb.GetValueOrDefault(0), _
                                                    xLigne.MontantCre.GetValueOrDefault(0), _
                                                    CSng(xRowTemp("TTaux"))))
                        End If
                    ElseIf xLigne.CodeTVACompte IsNot Nothing AndAlso xLigne.CodeTVACompte.Trim <> "" Then
                        'LIGNE DE TVA
                        Dim r As RecapTva
                        If xListTVA.ContainsKey(xLigne.CodeTVACompte) Then
                            r = xListTVA(xLigne.CodeTVACompte)
                        Else
                            Dim xRowTemp As DataRow = dtTVA.Select("TTVA='" + xLigne.CodeTVACompte + "'")(0)
                            r = New RecapTva(xLigne.CodeTVACompte, 0, 0, CSng(xRowTemp("TTaux")))
                            xListTVA.Add(xLigne.CodeTVACompte, r)
                        End If
                        If xLigne.MontantBaseHT.HasValue Then
                            If xLigne.MontantDeb.GetValueOrDefault <> 0 Then
                                r.SubtractValeurHTDeb(xLigne.MontantBaseHT.Value)
                            Else
                                r.SubtractValeurHTDeb(-xLigne.MontantBaseHT.Value)
                            End If
                        End If
                    End If
                Next

                'VERIFIER S'IL EXISTE DES CODES TVA NON SOLDES
                For Each sCodeTVA As String In xListTVA.Keys
                    If xListTVA(sCodeTVA).GetValeurHT <> 0 Then
                        Return False
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

    ''' <summary>
    ''' Permet la cloture de la TVA pour une pièce au montant TTC
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseTVATTC(ByVal bFirst As Boolean, ByVal dtTVA As DataTable) As String

        Dim xListTVATTC As New Dictionary(Of Ligne, RecapTvaInvers)
        Dim xListTVA As New Dictionary(Of String, RecapTvaWithHT)
        Dim sPosition As String = ""
        Try
            If Me.Lignes.Count > 0 Then
                'Charge tous les comptes de TVA dans une chaine de string
                Dim sListTVA As New List(Of String)
                For Each xRow As dbDonneesDataSet.TVARow In dtTVA.Rows
                    sListTVA.Add(xRow("TCpt").ToString)
                Next

                For i As Integer = Me.Lignes.Count - 1 To 0 Step -1
                    If sListTVA.IndexOf(Me.Lignes(i).Compte) >= 0 Then
                        If MsgBox(My.Resources.Strings.Saisie_AskResetTVA + vbCrLf + _
                        My.Resources.Strings.Saisie_AskResetTVA2 + vbCrLf + _
                        My.Resources.Strings.SouhaitezVousContinuer, MsgBoxStyle.YesNo, My.Resources.Strings.Sasie_CalculDeTVA) = MsgBoxResult.Yes Then
                            'supprime les lignes de TVA existante
                            For j As Integer = Me.Lignes.Count - 1 To 0 Step -1
                                If sListTVA.IndexOf(Me.Lignes(j).Compte) >= 0 Then
                                    Me.Lignes.RemoveAt(j)
                                End If
                            Next
                            Exit For
                        End If
                    End If
                Next

                'supprime les lignes de TVA existante
                For i As Integer = Me.Lignes.Count - 1 To 0 Step -1
                    If sListTVA.IndexOf(Me.Lignes(i).Compte) >= 0 Then
                        Me.Lignes.RemoveAt(i)
                    End If
                Next
                'recense les lignes ayant de la TVA à calculer
                For Each xLigne As Ligne In Me.Lignes
                    If xLigne.CodeTva IsNot Nothing AndAlso xLigne.CodeTva.Trim <> "" Then
                        Dim xRowTemp As DataRow = dtTVA.Select("TTVA='" + xLigne.CodeTva + "'")(0)
                        xListTVATTC.Add(xLigne, New RecapTvaInvers(xLigne.CodeTva, xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0), CType(xRowTemp.ItemArray.GetValue(5), Single)))
                    End If
                Next
                'Réaffecte les montants HT aux lignes ayant de la TVA
                For Each xLigne As Ligne In xListTVATTC.Keys
                    Dim xTempLigne As Ligne = Me.Lignes(Me.Lignes.IndexOf(xLigne))
                    If xTempLigne.MontantCre.HasValue Then
                        xTempLigne.MontantCre = xListTVATTC(xLigne).ValeurHT
                    Else
                        xTempLigne.MontantDeb = xListTVATTC(xLigne).ValeurHT
                    End If
                Next
                'implémente la liste des codes TVA avec leur montant HT et TVA
                For Each xLigne As Ligne In xListTVATTC.Keys
                    Dim recap As RecapTvaInvers = xListTVATTC(xLigne)
                    With recap
                        If .CodeTva <> "" Then
                            If xListTVA.ContainsKey(.CodeTva) Then
                                Dim r As RecapTvaWithHT = xListTVA(.CodeTva)
                                If .DebitValue Then
                                    r.DValeurTVA += .ValeurTVA
                                    r.DValeurHT += .ValeurHT
                                Else
                                    r.CValeurTVA += .ValeurTVA
                                    r.CValeurHT += .ValeurHT
                                End If
                            Else
                                xListTVA.Add(.CodeTva, New RecapTvaWithHT(.CodeTva, .DebitValue, .ValeurTVA, .ValeurHT))
                            End If
                        End If
                    End With
                Next
                'créer les nouveau compte de TVA
                Dim bTVANulle As Boolean = False
                For Each sCodeTVA As String In xListTVA.Keys
                    If xListTVA(sCodeTVA).GetValeurTVA = 0 Then
                        bTVANulle = True
                    Else
                        Dim nTauxTVA As Single
                        Dim sCompteTvaACloturer As String
                        'Va chercher les informations relative au code TVA dans le plan type
                        Dim xRowTemp As DataRow = dtTVA.Select("TTVA='" + sCodeTVA + "'")(0)
                        sCompteTvaACloturer = xRowTemp.ItemArray.GetValue(3).ToString
                        nTauxTVA = CType(xRowTemp.ItemArray.GetValue(5).ToString, Single)
                        Dim xNewLigne As New Ligne
                        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                            conn.Open()
                            Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                                xNewLigne.CheckAndCreateComptePlanComptable(sCompteTvaACloturer, t)
                            End Using
                        End Using
                        xNewLigne.Compte = sCompteTvaACloturer
                        xNewLigne.Libelle = "TVA " + sCodeTVA + " - " + Me.Libelle
                        xNewLigne.CodeTVACompte = sCodeTVA
                        xNewLigne.MontantBaseHT = xListTVA(sCodeTVA).GetValeurHT
                        If xListTVA(sCodeTVA).GetValeurTVA = 0 Then
                            sPosition = sCompteTvaACloturer
                        End If
                        If xListTVA(sCodeTVA).IsDebitTVA Then
                            xNewLigne.MontantDeb = xListTVA(sCodeTVA).GetValeurTVA
                        Else
                            xNewLigne.MontantCre = xListTVA(sCodeTVA).GetValeurTVA
                        End If
                        Me.Lignes.Add(xNewLigne)
                        If bFirst Then
                            Exit For
                        End If
                    End If
                Next
                If bTVANulle Then
                    MsgBox(My.Resources.Strings.Saisie_AttentionPasPuCalcTVA, MsgBoxStyle.Information)
                End If
            End If
            Return sPosition
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

    ''' <summary>
    ''' permet de retourner la table récap des codes TVA avec les montant afin de renseigner
    ''' les lignes de TVA pour les pièces qui sont importer depuis un fichier isagri
    ''' </summary>
    ''' <param name="dtTVA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTableTVA(ByVal dtTVA As DataTable) As Dictionary(Of String, RecapTva)

        Dim xListTVA As New Dictionary(Of String, RecapTva)
        Dim sPosition As String = ""
        Try
            If Me.Lignes.Count > 0 Then
                'Charge tous les comptes de TVA dans une chaine de string
                Dim sListTVA As New AutoCompleteStringCollection
                For Each xRow As dbDonneesDataSet.TVARow In dtTVA.Rows
                    sListTVA.Add(xRow("TCpt").ToString)
                Next

                'alimente le tableau des Code TVA
                For Each xLigne As Ligne In Me.Lignes
                    If xLigne.CodeTva IsNot Nothing AndAlso xLigne.CodeTva.Trim <> "" Then
                        If xListTVA.ContainsKey(xLigne.CodeTva) Then
                            xListTVA(xLigne.CodeTva).Add(xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0))
                        Else
                            Dim tx As Single = 0
                            Dim rwsTVA() As DataRow = dtTVA.Select("TTVA='" + xLigne.CodeTva + "'")
                            If rwsTVA.Length > 0 Then
                                tx = CSng(rwsTVA(0)("TTaux"))
                            End If
                            xListTVA.Add(xLigne.CodeTva, New RecapTva(xLigne.CodeTva, xLigne.MontantDeb.GetValueOrDefault(0), xLigne.MontantCre.GetValueOrDefault(0), tx))
                        End If
                    End If
                Next
                'Supprime les montant de base HT pour les lignes de TVA qui en ont déjà
                For Each sCodeTVA As String In xListTVA.Keys
                    'Dim sCompteTvaACloturer As String
                    'sCompteTvaACloturer = dtTVA.Select("TTVA='" + sCodeTVA + "'")(0).ItemArray.GetValue(3).ToString
                    'For Each xLigne As Ligne In Me.Lignes
                    '    If xLigne.Compte = sCompteTvaACloturer Then
                    '        If xLigne.MontantBaseHT.HasValue Then
                    '            If xLigne.MontantDeb.GetValueOrDefault <> 0 Then
                    '                xListTVA(sCodeTVA).SubtractValeurHTDeb(xLigne.MontantBaseHT.Value)
                    '            Else
                    '                xListTVA(sCodeTVA).SubtractValeurHTDeb(-xLigne.MontantBaseHT.Value)
                    '            End If
                    '        End If
                    '    End If
                    'Next
                    For Each xLigne As Ligne In Me.Lignes
                        If xLigne.CodeTVACompte = sCodeTVA Then
                            If xLigne.MontantBaseHT.HasValue Then
                                If xLigne.MontantDeb.GetValueOrDefault <> 0 Then
                                    xListTVA(sCodeTVA).SubtractValeurHTDeb(xLigne.MontantBaseHT.Value)
                                Else
                                    xListTVA(sCodeTVA).SubtractValeurHTDeb(-xLigne.MontantBaseHT.Value)
                                End If
                            End If
                        End If
                    Next
                Next
            End If
            Return xListTVA
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Récapitulatif de code TVA avec leur montant HT 
    ''' avec suppression de montant de TVA existant dans d'autre ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Class RecapTva

        Private sCodeTva As String
        'Private nDValeurHT As Decimal
        'Private nCValeurHT As Decimal
        Private nValeurTotalHT As Decimal
        Private nTauxTVA As Decimal
        Private nValeurTVA As Decimal

        ''' <summary>
        ''' retourne le code TVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetCodeTva() As String
            Get
                Return Convert.ToString(sCodeTva)
            End Get
        End Property

        ''' <summary>
        ''' définie s'il existe un montant TVA à traiter
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDebitTVA() As Boolean
            Get
                Return nValeurTotalHT > 0
            End Get
        End Property

        ''' <summary>
        ''' retourne le montant de la TVA 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetValeurTVA() As Decimal
            Get
                Return Math.Round(Math.Abs(nValeurTotalHT) * nTauxTVA, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' retourne le montant de la base HT du code TVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetValeurHT(Optional ByVal sens As String = "") As Decimal
            Get
                Select Case sens
                    Case "" : Return Math.Abs(nValeurTotalHT)
                    Case "D" : Return nValeurTotalHT
                    Case "C" : Return -nValeurTotalHT
                End Select
            End Get
        End Property

        ''' <summary>
        ''' constructeur par défaut
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Ajoute un nouveau code TVA avec ses montants associés
        ''' </summary>
        ''' <param name="Code"></param>
        ''' <param name="DValeurHT"></param>
        ''' <param name="CValeurHT"></param>
        ''' <param name="TauxTVA"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Code As String, ByVal DValeurHT As Decimal, ByVal CValeurHT As Decimal, ByVal TauxTVA As Single)
            Me.New()
            Me.sCodeTva = Code
            'Me.nDValeurHT = DValeurHT
            'Me.nCValeurHT = CValeurHT
            Me.nTauxTVA = (CType(TauxTVA, Decimal) / 100)
            Me.nValeurTotalHT = (DValeurHT - CValeurHT)
        End Sub

        ''' <summary>
        ''' Ajoute un montant débit crédit pour un code TVA
        ''' </summary>
        ''' <param name="DValeurHT"></param>
        ''' <param name="CValeurHT"></param>
        ''' <remarks></remarks>
        Public Sub Add(ByVal DValeurHT As Decimal, ByVal CValeurHT As Decimal)
            'Me.nDValeurHT = Me.nDValeurHT + DValeurHT
            'Me.nCValeurHT = Me.nCValeurHT + CValeurHT
            Me.nValeurTotalHT += (DValeurHT - CValeurHT)
        End Sub

        ''' <summary>
        ''' soustrait la valeur HT existant d'un autre compte TVA au montant total de la base HT entraint d'être traité
        ''' </summary>
        ''' <param name="ValeurHTDeb"></param>
        ''' <remarks></remarks>
        Public Sub SubtractValeurHTDeb(ByVal ValeurHTDeb As Decimal)
            nValeurTotalHT -= ValeurHTDeb
        End Sub

    End Class

    ''' <summary>
    ''' Tableau récapitulatif pour les codes TVA avec des montants HT
    ''' </summary>
    ''' <remarks></remarks>
    Private Class RecapTvaWithHT
        Public CodeTva As String
        Public CValeurHT As Decimal = 0
        Public CValeurTVA As Decimal = 0
        Public DValeurHT As Decimal = 0
        Public DValeurTVA As Decimal = 0

        ''' <summary>
        ''' retourne la valeur du montant HT de base pour la TVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetValeurHT() As Decimal
            Get
                Return CDec(IIf(CValeurHT > DValeurHT, CValeurHT - DValeurHT, DValeurHT - CValeurHT))
            End Get
        End Property

        ''' <summary>
        ''' retourne la TVA existant
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetValeurTVA() As Decimal
            Get
                Return CDec(IIf(CValeurTVA > DValeurTVA, CValeurTVA - DValeurTVA, DValeurTVA - CValeurTVA))
            End Get
        End Property

        ''' <summary>
        ''' définie si il y a une valeur de TVA à traiter
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDebitTVA() As Boolean
            Get
                Return CBool(IIf(DValeurTVA > CValeurTVA, True, False))
            End Get
        End Property

        ''' <summary>
        ''' constructeur par détaut
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

        End Sub

        ''' <summary>
        ''' permet d'ajouter un code TVA a la liste ainsi que ses montants
        ''' </summary>
        ''' <param name="code"></param>
        ''' <param name="bDebit"></param>
        ''' <param name="valeurTVA"></param>
        ''' <param name="valeurHT"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal code As String, ByVal bDebit As Boolean, ByVal valeurTVA As Decimal, ByVal valeurHT As Decimal)
            Me.New()
            Me.CodeTva = code
            If bDebit Then
                Me.DValeurHT = valeurHT
                Me.DValeurTVA = valeurTVA
            Else
                Me.CValeurHT = valeurHT
                Me.CValeurTVA = valeurTVA
            End If
        End Sub

        ''' <summary>
        ''' permet d'ajouter un débit et un crédit pour le meme code TVA
        ''' </summary>
        ''' <param name="bDebit"></param>
        ''' <param name="valeurTVA"></param>
        ''' <param name="valeurHT"></param>
        ''' <remarks></remarks>
        Public Sub Add(ByVal bDebit As Boolean, ByVal valeurTVA As Decimal, ByVal valeurHT As Decimal)
            If bDebit Then
                Me.DValeurHT = valeurHT
                Me.DValeurTVA = valeurTVA
            Else
                Me.CValeurHT = valeurHT
                Me.CValeurTVA = valeurTVA
            End If
        End Sub

    End Class

    ''' <summary>
    ''' tableau récapitulatif des code TVA pour la cloture TVA en mode TTC
    ''' </summary>
    ''' <remarks></remarks>
    Private Class RecapTvaInvers

        Private sCodeTva As String
        Private nDValeurTTC As Decimal
        Private nCValeurTTC As Decimal
        Private nValeurHT As Decimal
        Private nTauxTVA As Decimal
        Private nValeurTVA As Decimal

        ''' <summary>
        ''' indique le code TVA traité
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CodeTva() As String
            Get
                Return Convert.ToString(sCodeTva)
            End Get
        End Property

        ''' <summary>
        ''' définie s'il existe une valeur en TTC à traiter
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DebitValue() As Boolean
            Get
                Return CBool(IIf(nDValeurTTC <> 0, True, False))
            End Get
        End Property

        ''' <summary>
        ''' détermine la valeur de la  TVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ValeurTVA() As Decimal
            Get
                Return nValeurTVA
            End Get
        End Property

        ''' <summary>
        ''' détermine la valeur de la base HT pour le code TVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ValeurHT() As Decimal
            Get
                Return nValeurHT
            End Get
        End Property

        ''' <summary>
        ''' constructeur par défaut
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' constructeur pour la création d'un nouveau code TVA en mode TTC avec ses informations
        ''' </summary>
        ''' <param name="Code"></param>
        ''' <param name="DValeurTTC"></param>
        ''' <param name="CValeurTTC"></param>
        ''' <param name="TauxTVA"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Code As String, ByVal DValeurTTC As Decimal, ByVal CValeurTTC As Decimal, ByVal TauxTVA As Single)
            Me.New()
            Me.sCodeTva = Code
            Me.nDValeurTTC = DValeurTTC
            Me.nCValeurTTC = CValeurTTC
            Me.nTauxTVA = (CType(TauxTVA, Decimal) / 100) + 1
            Me.nValeurHT = Decimal.Round(CType((DValeurTTC + CValeurTTC) / nTauxTVA, Decimal), 2, System.MidpointRounding.AwayFromZero)
            Me.nValeurTVA = (DValeurTTC + CValeurTTC) - nValeurHT
        End Sub
    End Class

#End Region

End Class

''' <summary>
''' classe de la ligne
''' </summary>
''' <remarks></remarks>
Public Class Ligne

    Public Event CompteChanged As EventHandler
    Public Event ActiviteChanged As EventHandler

#Region "Property"

    Private _nLigne As Integer
    ''' <summary>
    ''' numéro de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NLigne() As Integer
        Get
            Return _nLigne
        End Get
        Set(ByVal value As Integer)
            _nLigne = value
        End Set
    End Property

    Private _codeTVA As String
    ''' <summary>
    ''' code TVA de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeTva() As String
        Get
            Return _codeTVA
        End Get
        Set(ByVal value As String)
            _codeTVA = value
        End Set
    End Property

    Private _lib As String
    ''' <summary>
    ''' libellé de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Libelle() As String
        Get
            Return _lib
        End Get
        Set(ByVal value As String)
            _lib = value
        End Set
    End Property

    Private _cpt As String
    ''' <summary>
    ''' Numéro de compte de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Compte() As String
        Get
            Return _cpt
        End Get
        Set(ByVal value As String)
            If value <> _cpt Then
                _cpt = value
                RaiseEvent CompteChanged(Me, New EventArgs)
            End If
        End Set
    End Property

    Private _acti As String
    ''' <summary>
    ''' code activité de la ligne pour la saisie
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Activite() As String
        Get
            Return CStr(IIf(_acti = "0000", "", _acti))
        End Get
        Set(ByVal value As String)
            If value <> _acti Then
                _acti = CStr(IIf(value = "", "0000", value))
                RaiseEvent ActiviteChanged(Me, New EventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' code activité de la ligne pour le traitement dans le code
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ActiviteShowAll() As String
        Get
            Return _acti
        End Get
    End Property

    Private _montantD As Nullable(Of Decimal)
    ''' <summary>
    ''' Montant du débit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantDeb() As Nullable(Of Decimal)
        Get
            Return _montantD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value.HasValue Then value = Decimal.Round(value.Value, 2, MidpointRounding.AwayFromZero)
            _montantD = value
        End Set
    End Property

    Private _montantC As Nullable(Of Decimal)
    ''' <summary>
    ''' Montant du crédit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantCre() As Nullable(Of Decimal)
        Get
            Return _montantC
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value.HasValue Then value = Decimal.Round(value.Value, 2, MidpointRounding.AwayFromZero)
            _montantC = value
        End Set
    End Property

    Private _qte1 As Nullable(Of Decimal)
    ''' <summary>
    ''' Quantité 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Quantite1() As Nullable(Of Decimal)
        Get
            Return _qte1
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value.HasValue Then value = Decimal.Round(value.Value, 3, MidpointRounding.AwayFromZero)
            _qte1 = value
        End Set
    End Property

    Private _qte2 As Nullable(Of Decimal)
    ''' <summary>
    ''' Quantité 2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Quantite2() As Nullable(Of Decimal)
        Get
            Return _qte2
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value.HasValue Then value = Decimal.Round(value.Value, 3, MidpointRounding.AwayFromZero)
            _qte2 = value
        End Set
    End Property

    Private u1 As String
    ''' <summary>
    ''' unité de la quantité 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Unite1() As String
        Get
            Return u1
        End Get
        Set(ByVal value As String)
            u1 = value
        End Set
    End Property

    Private u2 As String
    ''' <summary>
    '''  unité de la quantité 2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Unite2() As String
        Get
            Return u2
        End Get
        Set(ByVal value As String)
            u2 = value
        End Set
    End Property

    Private _MOrdre As Byte
    ''' <summary>
    ''' Numéro de l'ordre (1-2-3)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MOrdre() As Byte
        Get
            Return _MOrdre
        End Get
        Set(ByVal value As Byte)
            _MOrdre = value
        End Set
    End Property


    Private _codeLettrage As String
    Public Property CodeLettrage() As String
        Get
            Return _codeLettrage
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso value.Length > 3 Then
                Throw New ArgumentException("Longeur max. : 3")
            End If
            _codeLettrage = value
        End Set
    End Property

    Private _MontantBaseHT As Nullable(Of Decimal)
    ''' <summary>
    ''' Montant de la base HT pour les lignes de TVA
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantBaseHT() As Nullable(Of Decimal)
        Get
            Return _MontantBaseHT
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value.HasValue Then value = Decimal.Round(value.Value, 2, MidpointRounding.AwayFromZero)
            _MontantBaseHT = value
        End Set
    End Property

    Private _CodeTVACompte As String
    ''' <summary>
    ''' Numéro du compte de TVA pour faire la cloture de TVA
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeTVACompte() As String
        Get
            Return _CodeTVACompte
        End Get
        Set(ByVal value As String)
            _CodeTVACompte = value
        End Set
    End Property

    Private _TotalDebit As Nullable(Of Decimal)
    ''' <summary>
    ''' Total du débit pour le compte de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalDebit() As Nullable(Of Decimal)
        Get
            Return _TotalDebit
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _TotalDebit = value
        End Set
    End Property

    Private _TotalCredit As Nullable(Of Decimal)
    ''' <summary>
    ''' Total du crédit pour le compte de la ligne
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalCredit() As Nullable(Of Decimal)
        Get
            Return _TotalCredit
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _TotalCredit = value
        End Set
    End Property

    Private _ContrePartie As String
    ''' <summary>
    ''' numéro du compte de contre partie
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContrePartie() As String
        Get
            Return _ContrePartie
        End Get
        Set(ByVal value As String)
            _ContrePartie = value
        End Set
    End Property

    Private _ContrePartieLib As String
    ''' <summary>
    ''' Libellé du compte de contre partie
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContrePartieLib() As String
        Get
            Return _ContrePartieLib
        End Get
        Set(ByVal value As String)
            _ContrePartieLib = value
        End Set
    End Property

    Private _LibelleAuto As Boolean
    ''' <summary>
    ''' détermine si le libellé peut etre mis automatiquement ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>lorsque l'utilisateur a saisie quelques chose dans le libellé
    '''  celui ci ne peut etre changé automatiquement</remarks>
    Public Property LibelleAuto() As Boolean
        Get
            Return _LibelleAuto
        End Get
        Set(ByVal value As Boolean)
            _LibelleAuto = value
        End Set
    End Property

    Private _CodePointageMvt As String
    ''' <summary>
    ''' Code pointage associé au mouvement
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodePointageMvt() As String
        Get
            Return _CodePointageMvt
        End Get
        Set(ByVal value As String)
            _CodePointageMvt = value
        End Set
    End Property

    Private _DatePointageMvt As Nullable(Of Date)
    ''' <summary>
    ''' Date du pointage associé au mouvement
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DatePointageMvt() As Nullable(Of Date)
        Get
            Return _DatePointageMvt
        End Get
        Set(ByVal value As Nullable(Of Date))
            _DatePointageMvt = value
        End Set
    End Property

    Private _MIdANouveau As Nullable(Of Integer)
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MIdANouveau() As Nullable(Of Integer)
        Get
            Return _MIdANouveau
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _MIdANouveau = value
        End Set
    End Property

    Private _MIdANouveauSuiv As Nullable(Of Integer)
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MIdANouveauSuiv() As Nullable(Of Integer)
        Get
            Return _MIdANouveauSuiv
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _MIdANouveauSuiv = value
        End Set
    End Property

#Region "Propriétés utilisées seulement pour l'export ISA"
    Private _dtPointage As Date
    Private Property DatePointage() As Date
        Get
            Return _dtPointage
        End Get
        Set(ByVal value As Date)
            _dtPointage = value
        End Set
    End Property


    Private _dtDecl As Date
    Private Property DateDeclaration() As Date
        Get
            Return _dtDecl
        End Get
        Set(ByVal value As Date)
            _dtDecl = value
        End Set
    End Property


    Private _dtVal As Date
    Private Property DateValeur() As Date
        Get
            Return _dtVal
        End Get
        Set(ByVal value As Date)
            _dtVal = value
        End Set
    End Property
#End Region


    ''' <summary>
    ''' détermine si la ligne est valide
    ''' </summary>
    ''' <param name="dtaRegle"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsDonneeValide(ByVal dtaRegle As dbDonneesDataSet.ReglesValidationDataTable) As DataValidationDetail
        Get
            Return ValidationDonneesSaisies(dtaRegle)
        End Get
    End Property

    ''' <summary>
    ''' structure permettant de retourner les informations sur la validation de la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure DataValidationDetail
        Dim IsValide As Boolean
        Dim CellQte1Oblig As Boolean
        Dim CellErrorQte1ObligText As String
        Dim CellQte2Oblig As Boolean
        Dim CellErrorQte2ObligText As String
        Dim CellErrorRatioHT As Nullable(Of Boolean)
        Dim CellErrorRatioHTText As String
        Dim CellErrorRatioQT As Nullable(Of Boolean)
        Dim CellErrorRatioQTText As String
    End Structure

#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' construteur par defaut de la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.Compte = ""
        Me.Activite = "0000"
        Me.LibelleAuto = True
    End Sub

    ''' <summary>
    ''' Chargement d'un ligne en fonction d'un mouvement
    ''' </summary>
    ''' <param name="drl">dataset de la ligne qui va etre alimenter</param>
    ''' <param name="drMvt">dataset du mouvement</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal drl As dbDonneesDataSet.LignesRow, ByVal drMvt As dbDonneesDataSet.MouvementsRow, ByVal nOrder As Integer)

        'implémente les propriétées
        Me.New()
        Try
            Dim ds As dbDonneesDataSet = CType(drl.Table.DataSet, dbDonneesDataSet)
            Me.NLigne = drl.LLig
            If Not drl.IsLLibNull Then Me.Libelle = drl.LLib
            If Not drl.IsDatePointageNull Then Me.DatePointage = drl.DatePointage
            If Not drl.IsDateDeclarationNull Then Me.DateDeclaration = drl.DateDeclaration
            If Not drl.IsDateValeurNull Then Me.DateValeur = drl.DateValeur
            If drMvt IsNot Nothing Then
                Me.Compte = drMvt.MCpt
                Me.MOrdre = drMvt.MOrdre
                If Not drMvt.IsMLettrageNull Then
                    Me.CodeLettrage = drMvt.MLettrage
                End If
                'met le code TVA
                If Me.MOrdre = 1 Or Me.MOrdre = 3 Then
                    If Not drl.IsLTvaNull Then Me.CodeTva = drl.LTva
                ElseIf Me.MOrdre = 2 Then
                    Me.CodeTva = ""
                    'If Not drl.IsLTvaNull Then Me.CodeTVACompte = drl.LTva
                    If Not drl.IsLMtTVANull Then Me.CodeTVACompte = drl.LMtTVA 'Modif Jérémie le 23/01/09
                    For Each drm As dbDonneesDataSet.MouvementsRow In drl.GetMouvementsRows
                        If drm.MCpt = "48800000" And drm.MD_C = drMvt.MD_C Then
                            'met la base HT de la TVA en fonction du débit credit
                            Me.MontantBaseHT = CType(IIf(drm.MD_C = "D", drm.MMtDeb, drm.MMtCre), Decimal)
                        End If
                    Next
                End If

                Me.Activite = drMvt.MActi
                'indique le débit ou le crédit en fonction de son emplacement dans le mouvement
                If drMvt.MD_C = "D" Then
                    Me.MontantDeb = drMvt.MMtDeb
                Else
                    Me.MontantCre = drMvt.MMtCre
                End If
                'Met les quantité
                If Not drMvt.IsMQte1Null AndAlso drMvt.MQte1 <> 0 Then Me.Quantite1 = drMvt.MQte1
                If Not drMvt.IsMQte2Null AndAlso drMvt.MQte2 <> 0 Then Me.Quantite2 = drMvt.MQte2
                Me.DeterminerUnites(ds)
                'Met la contre partie
                Dim drCpt As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
                If drCpt IsNot Nothing Then
                    If Not drCpt.IsCCptContreNull Then
                        Me.ContrePartie = drCpt.CCptContre
                        If Me.ContrePartie <> "" Then
                            Dim drCptContre As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                            If drCptContre IsNot Nothing Then
                                If Not drCptContre.IsCLibNull Then Me.ContrePartieLib = drCptContre.CLib
                            End If
                        End If
                    End If
                End If
                'Détermine le montant total débit et crédit pour le compte en cours dans la base (pour la visu de l'état du compte)
                Dim dtaCompteTotal() As DataRow = ds.CompteTotal.Select(String.Format("Cpt='{0}' AND Acti='{1}'", Me.Compte, Me.ActiviteShowAll))
                If dtaCompteTotal.Length > 0 Then
                    Me.TotalDebit = CType(dtaCompteTotal(0).Item("TotalDebit"), Decimal)
                    Me.TotalCredit = CType(dtaCompteTotal(0).Item("TotalCredit"), Decimal)
                End If

                'Ajoute les informations concernant le pointage
                If Not (drMvt.IsMPointageNull) Then
                    Me.CodePointageMvt = drMvt.MPointage
                End If

                If Not (drMvt.IsMDatePointageNull) Then
                    Me.DatePointageMvt = drMvt.MDatePointage
                End If

                'Ajoute les informations concernant le MIdANouveau
                If Not (drMvt.IsMIdANouveauNull) Then
                    Me.MIdANouveau = drMvt.MIdANouveau
                End If

                'Ajoute les informations concernant le MIdANouveauSuiv
                If Not (drMvt.IsMIdANouveauSuivNull) Then
                    Me.MIdANouveauSuiv = drMvt.MIdANouveauSuiv
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub
#End Region

#Region "Import Banque"
    ''' <summary>
    ''' constructeur de ligne pour des données provenant de l'importe de fichier bancaire
    ''' </summary>
    ''' <param name="LigneReleveBanque"></param>
    ''' <param name="sCompteBanque"></param>
    ''' <param name="dsBase"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal LigneReleveBanque As Importations.CFONB.LigneReleve, ByVal sCompteBanque As String, ByVal dsBase As dbDonneesDataSet)

        Me.New()
        Try
            Me.Compte = sCompteBanque
            Me.Activite = "0000"
            Me.Libelle = LigneReleveBanque.Libelle
            Me.LibelleAuto = False
            'Détermine le montant débit - crédit
            If LigneReleveBanque.MontantMouvement.Montant > 0 Then
                Me.MontantDeb = LigneReleveBanque.MontantMouvement.Montant
            Else
                Me.MontantCre = -LigneReleveBanque.MontantMouvement.Montant
            End If
            Dim dtaCompteTotal() As DataRow = dsBase.CompteTotal.Select(String.Format("Cpt='{0}' AND Acti='{1}'", Me.Compte, Me.ActiviteShowAll))
            If dtaCompteTotal.Length > 0 Then
                'Détermine le montant total débit et crédit pour le compte en cours dans la base (pour la visu de l'état du compte)
                Me.TotalDebit = CType(dtaCompteTotal(0).Item("TotalDebit"), Decimal)
                Me.TotalCredit = CType(dtaCompteTotal(0).Item("TotalCredit"), Decimal)
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' constructeur de ligne pour des données provenant de l'importe de fichier bancaire 
    ''' pour un compte non défini et mis en attente de validation
    ''' </summary>
    ''' <param name="LigneReleveBanque"></param>
    ''' <param name="dsBase"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal LigneReleveBanque As Importations.CFONB.LigneReleve, ByVal dsBase As dbDonneesDataSet)

        Me.New()
        Try
            Me.LibelleAuto = True
            'met le compte d'attente pour permet de définir le bon compte par l'utilisateur
            Me.Compte = "47000000"
            CheckAndCreateComptePlanComptable(Me.Compte, dsBase, "COMPTE D'ATTENTE")
            Dim drCpt As dbDonneesDataSet.ComptesRow = dsBase.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
            If drCpt IsNot Nothing Then
                'Définie les unitées
                If Not drCpt.IsCU1Null Then
                    Me.Unite1 = drCpt.CU1
                Else
                    Me.Unite1 = ""
                End If
                If Not drCpt.IsCU2Null Then
                    Me.Unite2 = drCpt.CU2
                Else
                    Me.Unite2 = ""
                End If

                ' Définie le compte de contre partie ainsi que le libellé du compte de contre partie
                If Not drCpt.IsCCptContreNull Then
                    Me.ContrePartie = drCpt.CCptContre
                    Dim drCptContrePartie As dbDonneesDataSet.ComptesRow = dsBase.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                    If drCptContrePartie IsNot Nothing Then
                        If Not drCptContrePartie.IsCLibNull Then Me.ContrePartieLib = drCptContrePartie.CLib
                        'Else
                        '    Dim drCpt2 As dbDonneesDataSet.ComptesRow = dsBase.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                        '    If Not drCpt2.IsCLibNull Then Me.ContrePartieLib = drCpt2.CLib
                    End If
                End If

                'Détermine le montant au débit - crédit
                If LigneReleveBanque.MontantMouvement.Montant < 0 Then
                    Me.MontantDeb = -LigneReleveBanque.MontantMouvement.Montant
                Else
                    Me.MontantCre = LigneReleveBanque.MontantMouvement.Montant
                End If

                Dim drPlc() As dbDonneesDataSet.PlanComptableRow = drCpt.GetPlanComptableRows
                If drPlc.Length > 0 Then
                    'Met la première activité associé
                    Me.Activite = Convert.ToString(drPlc(0)("PlActi"))
                    If Me.LibelleAuto Or Me.Libelle = "" Then
                        'Met le libellé du plan comptable
                        Me.Libelle = Convert.ToString(drPlc(0)("PlLib"))
                    End If
                End If

                'Détermine le montant total débit et crédit pour le compte en cours dans la base (pour la visu de l'état du compte)
                Using dtaMouv As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
                    Me.TotalCredit = dtaMouv.GetSumCreditByDossierByCompte(My.User.Name, Me.Compte, Me.ActiviteShowAll)
                    Me.TotalDebit = dtaMouv.GetSumDebitByDossierByCompte(My.User.Name, Me.Compte, Me.ActiviteShowAll)
                End Using

            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub
#End Region

#Region "Gestion des lignes classique"
    ''' <summary>
    ''' boucle que les différents mouvement de la ligne. seul les mouvements n'ayant pas de 48800000 dans la colonne ModMCpt seront traités
    ''' </summary>
    ''' <param name="drl">liste de lignes de mouvement associées à la pièce</param>
    ''' <returns>retourne la liste de lignes bien formaté</returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerLignes(ByVal drl As dbDonneesDataSet.LignesRow, ByVal nOrder As Integer) As List(Of Ligne)

        Dim res As New List(Of Ligne)
        For Each drm As dbDonneesDataSet.MouvementsRow In drl.GetMouvementsRows
            'regarde si le mouvement n'est pas sur un compte de répartition sinon il va créer la ligne
            If drm.MCpt <> "48800000" Then res.Add(New Ligne(drl, drm, nOrder))
        Next
        Return res

    End Function

    Public Sub AjouteLigneMouvBase(ByVal sDossier As String, ByVal nPiece As Integer, ByVal dtPiece As Date, _
                                    ByVal sJournal As String, ByVal nligne As Integer, ByRef t As OleDb.OleDbTransaction)
        Try
            Dim nOrdreD As Byte = 1
            Dim nOrdreTVA As Byte = 2
            Dim nOrdreC As Byte = 3
            Using dtaLigne As New dbDonneesDataSetTableAdapters.LignesTableAdapter
                dtaLigne.SetTransaction(t)
                dtaLigne.Insert(sDossier, nPiece, dtPiece, nligne, CStr(IIf(CodeTva = Nothing, "", Me.CodeTva)), Microsoft.VisualBasic.Left(Libelle, 55), "O", "O", sJournal, Me.CodeTVACompte, NullabilifyDate(Me.DatePointage), NullabilifyDate(Me.DateDeclaration), NullabilifyDate(Me.DateValeur))
                Using dtaMouv As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
                    dtaMouv.SetTransaction(t)
                    'Vérifie que le compte 48800000 existe
                    CheckAndCreateComptePlanComptable("48800000", t)
                    If Microsoft.VisualBasic.Left(Compte, 3) = "512" Then
                        'Vérifie que le compte banque fourni existe
                        CheckAndCreateComptePlanComptable(Compte, t, _acti)
                    End If
                    Using dtaTVA As New dbDonneesDataSetTableAdapters.TVATableAdapter
                        If CInt(dtaTVA.ExistsCompte(Compte)) > 0 Then
                            'Détermine les montant débit et crédit pour chaque ordre
                            Dim Montant1D As Nullable(Of Decimal)
                            Dim Montant2D As Nullable(Of Decimal)
                            Dim Montant2C As Nullable(Of Decimal)
                            Dim Montant3C As Nullable(Of Decimal)
                            If MontantDeb.HasValue Then
                                Montant1D = MontantBaseHT.GetValueOrDefault(0)
                                Montant2D = MontantDeb.Value
                                Montant3C = MontantBaseHT.GetValueOrDefault(0) + MontantDeb.Value
                            ElseIf MontantCre.HasValue Then
                                Montant1D = MontantBaseHT.GetValueOrDefault(0) + MontantCre.Value
                                Montant2C = MontantCre.Value
                                Montant3C = MontantBaseHT.GetValueOrDefault(0)
                            End If
                            'intégration de la premièce ligne de TVA en débit
                            dtaMouv.Insert(sDossier, nPiece, dtPiece, nligne, nOrdreD, "48800000", "0000", _
                                            Montant1D.GetValueOrDefault(0), _
                                            0, "D", 0, 0, Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)

                            CheckAndCreateComptePlanComptable(Me.Compte, t)

                            'intégration de la seconde ligne de TVA 
                            dtaMouv.Insert(sDossier, nPiece, dtPiece, nligne, nOrdreTVA, Compte, _
                                        CStr(IIf(_acti = Nothing, "0000", _acti)), _
                                        CDec(Montant2D.GetValueOrDefault(0)), _
                                        CDec(Montant2C.GetValueOrDefault(0)), _
                                        CStr(IIf(Montant2C.HasValue, "C", "D")), _
                                        0, 0, CodeLettrage, Nothing, Nothing, Nothing, "0", Nothing, Nothing, Nothing, Nothing, Nothing)

                            'intégration de la troisième ligne de TVA en crédit
                            dtaMouv.Insert(sDossier, nPiece, dtPiece, nligne, nOrdreC, "48800000", "0000", _
                                            0, Montant3C.GetValueOrDefault(0), "C", 0, 0, _
                                            Nothing, Nothing, Nothing, "48800000", "0000", Nothing, Nothing, Nothing, Nothing, Nothing)
                        Else
                            CheckAndCreateComptePlanComptable(Me.Compte, t)
                            'intégration des lignes de mouvement pour les ordres 1 et 3
                            'Mouvement sur le compte
                            dtaMouv.Insert(sDossier, nPiece, dtPiece, nligne, CByte(IIf(MontantDeb.HasValue, nOrdreD, nOrdreC)), Compte, CStr(IIf(_acti Is Nothing, "0000", _acti)), CDec(MontantDeb.GetValueOrDefault(0)), CDec(MontantCre.GetValueOrDefault(0)), CStr(IIf(MontantDeb.HasValue, "D", "C")), CDec(Quantite1.GetValueOrDefault(0)), CDec(Quantite2.GetValueOrDefault(0)), CodeLettrage, Nothing, Nothing, "48800000", "0000", Nothing, Me.CodePointageMvt, Me.DatePointageMvt, Me.MIdANouveau, Me.MIdANouveauSuiv)
                            'Mouvement sur le 488
                            dtaMouv.Insert(sDossier, nPiece, dtPiece, nligne, CByte(IIf(MontantDeb.HasValue, nOrdreC, nOrdreD)), "48800000", "0000", CDec(MontantCre.GetValueOrDefault(0)), CDec(MontantDeb.GetValueOrDefault(0)), CStr(IIf(MontantDeb.HasValue, "C", "D")), 0, 0, Nothing, Nothing, Nothing, Compte, CStr(IIf(_acti Is Nothing, "0000", _acti)), Nothing, Nothing, Nothing, Nothing, Nothing)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If t IsNot Nothing Then t.Rollback()
            t = Nothing
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "Gestion des lignes de modèles"

    ''' <summary>
    ''' boucle que les différents mouvement de la ligne. seul les mouvements n'ayant pas de 48800000 dans la colonne ModMCpt seront traités
    ''' </summary>
    ''' <param name="drl"></param>
    ''' <param name="nOrder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerLignes(ByVal drl As dbDonneesDataSet.ModLignesRow, ByVal nOrder As Integer) As List(Of Ligne)

        Dim res As New List(Of Ligne)
        For Each drm As dbDonneesDataSet.ModMouvementsRow In drl.GetModMouvementsRows
            'regarde si le mouvement n'est pas sur un compte de répartition sinon il va créer la ligne
            If drm.ModMCpt <> "48800000" Then res.Add(New Ligne(drl, drm, nOrder))
        Next
        Return res

    End Function

    ''' <summary>
    ''' Permet de chargement d'un ligne de modèle à partie des lignes de mouvements en base et de la ligne asssocié
    ''' </summary>
    ''' <param name="drl"></param>
    ''' <param name="drMvt"></param>
    ''' <param name="nOrder"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal drl As dbDonneesDataSet.ModLignesRow, ByVal drMvt As dbDonneesDataSet.ModMouvementsRow, ByVal nOrder As Integer)

        'implémente les propriétées
        Me.New()
        Try
            Dim ds As dbDonneesDataSet = CType(drl.Table.DataSet, dbDonneesDataSet)
            Me.NLigne = drl.ModLLig
            If Not drl.IsModLLibNull Then Me.Libelle = drl.ModLLib
            If drMvt IsNot Nothing Then
                Me.Compte = drMvt.ModMCpt
                Me.MOrdre = drMvt.ModMOrdre
                'met le code TVA
                If Me.MOrdre = 1 Or Me.MOrdre = 3 Then
                    If Not drl.IsModLTvaNull Then Me.CodeTva = drl.ModLTva
                ElseIf Me.MOrdre = 2 Then
                    Me.CodeTva = ""
                    If Not drl.IsModLMtTVANull Then Me.CodeTVACompte = drl.ModLMtTVA
                    For Each drm As dbDonneesDataSet.ModMouvementsRow In drl.GetModMouvementsRows
                        If drm.ModMCpt = "48800000" And drm.ModMD_C = drMvt.ModMD_C Then
                            'met la base HT de la TVA en fonction du débit credit
                            Me.MontantBaseHT = CType(IIf(drm.ModMD_C = "D", drm.ModMMtDeb, drm.ModMMtCre), Decimal)
                        End If
                    Next
                End If

                Me.Activite = drMvt.ModMActi
                'indique le débit ou le crédit en fonction de son emplacement dans le mouvement
                If drMvt.ModMD_C = "D" Then
                    Me.MontantDeb = drMvt.ModMMtDeb
                Else
                    Me.MontantCre = drMvt.ModMMtCre
                End If
                'Met les quantité
                If drMvt.ModMQte1 <> 0 Then Me.Quantite1 = drMvt.ModMQte1
                If drMvt.ModMQte2 <> 0 Then Me.Quantite2 = drMvt.ModMQte2
                Me.DeterminerUnites(ds)
                'Met la contre partie
                Dim drCpt As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
                If drCpt IsNot Nothing Then
                    If Not drCpt.IsCCptContreNull Then
                        Me.ContrePartie = drCpt.CCptContre
                        If Me.ContrePartie <> "" And Me.ContrePartie <> "00000000" Then
                            Dim drCptContre As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                            If Not drCptContre.IsCLibNull Then Me.ContrePartieLib = Convert.ToString(drCptContre.Item("CLib"))
                        End If
                    End If
                End If
                'Détermine le montant total débit et crédit pour le compte en cours dans la base (pour la visu de l'état du compte)
                Dim dtaCompteTotal() As DataRow = ds.CompteTotal.Select(String.Format("Cpt='{0}' AND Acti='{1}'", Me.Compte, Me.ActiviteShowAll))
                If dtaCompteTotal.Length > 0 Then
                    Me.TotalDebit = CType(dtaCompteTotal(0).Item("TotalDebit"), Decimal)
                    Me.TotalCredit = CType(dtaCompteTotal(0).Item("TotalCredit"), Decimal)
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Intègre les données des mouvements pour la ligne
    ''' </summary>
    ''' <param name="sExploitation"></param>
    ''' <param name="sNomModele"></param>
    ''' <param name="sJournal"></param>
    ''' <param name="nligne"></param>
    ''' <param name="t"></param>
    ''' <remarks></remarks>
    Public Sub AjouteLigneModeleMouvBase(ByVal sExploitation As String, ByVal sNomModele As String, _
      ByVal sJournal As String, ByVal nligne As Integer, ByRef t As OleDb.OleDbTransaction)

        Try
            Dim nOrdreD As Byte = 1
            Dim nOrdreTVA As Byte = 2
            Dim nOrdreC As Byte = 3
            Using dtaLigne As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                dtaLigne.SetTransaction(t)
                dtaLigne.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, CStr(IIf(CodeTva = Nothing, "", Me.CodeTva)), Microsoft.VisualBasic.Left(Libelle, 55), "O", "O", sJournal, Me.CodeTVACompte)
                Using dtaMouv As New dbDonneesDataSetTableAdapters.ModMouvementsTableAdapter
                    dtaMouv.SetTransaction(t)
                    'Vérifie que le compte 48800000 existe
                    CheckAndCreateComptePlanComptable("48800000", t)
                    If Microsoft.VisualBasic.Left(Compte, 3) = "512" Then
                        'Vérifie que le compte banque fourni existe
                        CheckAndCreateComptePlanComptable(Compte, t, _acti)
                    End If
                    Using dtaTVA As New dbDonneesDataSetTableAdapters.TVATableAdapter
                        If CInt(dtaTVA.ExistsCompte(Compte)) > 0 Then
                            'Détermine les montant débit et crédit pour chaque ordre
                            Dim Montant1D As Nullable(Of Decimal)
                            Dim Montant2D As Nullable(Of Decimal)
                            Dim Montant2C As Nullable(Of Decimal)
                            Dim Montant3C As Nullable(Of Decimal)
                            If MontantDeb.HasValue Then
                                Montant1D = MontantBaseHT.GetValueOrDefault(0)
                                Montant2D = MontantDeb.Value
                                Montant3C = MontantBaseHT.GetValueOrDefault(0) + MontantDeb.Value
                            ElseIf MontantCre.HasValue Then
                                Montant1D = MontantBaseHT.GetValueOrDefault(0) + MontantCre.Value
                                Montant2C = MontantCre.Value
                                Montant3C = MontantBaseHT.GetValueOrDefault(0)
                            End If

                            'intégration de la premièce ligne de TVA en débit
                            dtaMouv.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, nOrdreD, "48800000", "0000", _
                                            Montant1D.GetValueOrDefault(0), 0, "D", 0, 0, 0, "48800000", "0000")

                            CheckAndCreateComptePlanComptable(Me.Compte, t)

                            'intégration de la seconde ligne de TVA 
                            dtaMouv.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, nOrdreTVA, Compte, _
                                        CStr(IIf(_acti = Nothing, "0000", _acti)), _
                                        CDec(Montant2D.GetValueOrDefault(0)), _
                                        CDec(Montant2C.GetValueOrDefault(0)), _
                                        CStr(IIf(Montant2C.HasValue, "C", "D")), _
                                        0, 0, 0, Nothing, "0")

                            'intégration de la troisième ligne de TVA en crédit
                            dtaMouv.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, nOrdreC, "48800000", "0000", _
                                            0, Montant3C.GetValueOrDefault(0), "C", 0, 0, 0, "48800000", "0000")
                        Else
                            'intégration des lignes de mouvement pour les ordres 1 et 3
                            'Mouvement sur le compte
                            dtaMouv.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, CByte(IIf(MontantDeb.HasValue, nOrdreD, nOrdreC)), Compte, CStr(IIf(_acti Is Nothing, "0000", _acti)), CDec(MontantDeb.GetValueOrDefault(0)), CDec(MontantCre.GetValueOrDefault(0)), CStr(IIf(MontantDeb.HasValue, "D", "C")), CDec(Quantite1.GetValueOrDefault(0)), CDec(Quantite2.GetValueOrDefault(0)), Nothing, "48800000", "0000")
                            'Mouvement sur 488
                            dtaMouv.Insert(sExploitation, sNomModele.Replace("'", "''"), nligne, CByte(IIf(MontantDeb.HasValue, nOrdreC, nOrdreD)), "48800000", "0000", CDec(MontantCre.GetValueOrDefault(0)), CDec(MontantDeb.GetValueOrDefault(0)), CStr(IIf(MontantDeb.HasValue, "C", "D")), CDec(Quantite2.GetValueOrDefault(0)), CDec(Quantite1.GetValueOrDefault(0)), Nothing, Compte, CStr(IIf(_acti Is Nothing, "0000", _acti)))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            t.Rollback()
            t = Nothing
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

#End Region

#Region "Méthodes diverses"
    Public Sub VerifLettrage(ByVal t As OleDb.OleDbTransaction)
        If Me.CodeLettrage IsNot Nothing Then
            If Not VerifEquilibreCodeLettrage(Me.CodeLettrage, Me.Compte, t) Then
                SupprimerLettrage(Me.CodeLettrage, t)
                Me.CodeLettrage = Nothing
            End If
        End If
    End Sub

    Private Function VerifEquilibreCodeLettrage(ByVal CodeLettrage As String, ByVal t As OleDb.OleDbTransaction) As Boolean
        Dim sql As String = FormatSql("SELECT Sum(MMtDeb) - Sum(MMtCre) AS Solde FROM Mouvements WHERE MLettrage={0}", CodeLettrage)
        Dim solde As Decimal = UtilBase.ExecuteScalarDec(sql, t)
        Return solde = 0D
    End Function

    Private Function VerifEquilibreCodeLettrage(ByVal CodeLettrage As String, ByVal compte As String, ByVal t As OleDb.OleDbTransaction) As Boolean
        Dim sql As String = FormatSql("SELECT Sum(MMtDeb) - Sum(MMtCre) AS Solde FROM Mouvements WHERE MLettrage={0} AND MCpt={1}", CodeLettrage, compte)
        Dim solde As Decimal = UtilBase.ExecuteScalarDec(sql, t)
        Return solde = 0D
    End Function

    Private Sub SupprimerLettrage(ByVal codeLettrage As String, ByVal t As OleDb.OleDbTransaction)
        Dim sql As String = FormatSql("UPDATE Mouvements SET MLettrage=NULL WHERE MLettrage={0}", codeLettrage)
        UtilBase.ExecuteNonQuery(sql, t)
    End Sub

    ''' <summary>
    ''' détermine les unitées du mouvement en fonction de l'exercice en cours
    ''' </summary>
    ''' <param name="ds">dataset</param>
    ''' <remarks></remarks>
    Private Sub DeterminerUnites(ByVal ds As dbDonneesDataSet)

        If Me.Compte Is Nothing Then Exit Sub
        Dim drCpt As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
        If drCpt Is Nothing Then Exit Sub
        If Not drCpt.IsCU1Null Then Me.Unite1 = drCpt.CU1
        If Not drCpt.IsCU2Null Then Me.Unite2 = drCpt.CU2

    End Sub

    ''' <summary>
    ''' chargement des informations du compte dans la ligne en cours 
    ''' </summary>
    ''' <param name="dsAgrigest"></param>
    ''' <param name="TVABindingSource"></param>
    ''' <remarks></remarks>
    Public Sub ChangementLigne(ByRef dsAgrigest As dbDonneesDataSet, ByRef TVABindingSource As BindingSource)

        Try
            Dim drCpt As dbDonneesDataSet.ComptesRow = dsAgrigest.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
            If drCpt IsNot Nothing Then
                'Détermine les unités de quantités en fonction du compte
                If Not drCpt.IsCU1Null Then
                    Me.Unite1 = Convert.ToString(drCpt.Item("CU1"))
                Else
                    Me.Unite1 = ""
                End If
                If Not drCpt.IsCU2Null Then
                    Me.Unite2 = Convert.ToString(drCpt.Item("CU2"))
                Else
                    Me.Unite2 = ""
                End If

                'Détermine le compte de contre partie en fonction du compte 
                If Not drCpt.IsCCptContreNull AndAlso drCpt.CCptContre.Length > 0 Then
                    'met de compte de contre partie
                    Me.ContrePartie = drCpt.CCptContre
                    Dim drCptContrePartie As dbDonneesDataSet.ComptesRow = dsAgrigest.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                    'met le libellé de contre partie du compte
                    If Not drCptContrePartie.IsCLibNull Then
                        Me.ContrePartieLib = Convert.ToString(drCptContrePartie.Item("CLib"))
                    Else
                        Dim drCpt2 As dbDonneesDataSet.ComptesRow = dsAgrigest.Comptes.FindByCDossierCCpt(My.User.Name, Me.ContrePartie)
                        If Not drCpt2.IsCLibNull Then Me.ContrePartieLib = Convert.ToString(drCpt2.Item("CLib"))
                    End If
                End If

                'Détermine le positionement du débit crédit dans le tableau en fonction du compte
                If Not Me.MontantCre.HasValue And Not Me.MontantDeb.HasValue Then
                    If drCpt.IsC_DCNull OrElse drCpt.C_DC = "" Then
                        Me.MontantCre = Nothing
                        Me.MontantDeb = Nothing
                    ElseIf drCpt.C_DC = "C" Then
                        Me.MontantCre = 0
                        Me.MontantDeb = Nothing
                    Else
                        Me.MontantDeb = 0
                        Me.MontantCre = Nothing
                    End If
                End If

                'Détermine les activité associé au compte
                Dim drPlc() As dbDonneesDataSet.PlanComptableRow = drCpt.GetPlanComptableRows
                If drPlc.Length > 0 Then
                    'Met la première activité associé
                    Me.Activite = Convert.ToString(drPlc(0)("PlActi"))
                    If Me.LibelleAuto Or Me.Libelle = "" Then
                        'Met le libellé du plan comptable
                        Me.Libelle = Convert.ToString(drPlc(0)("PlLib"))
                        If Me.Libelle = "" Then
                            'Met le libellé du compte et de l'activité si le plan comptable est vide
                            Dim drAct As dbDonneesDataSet.ActivitesRow = dsAgrigest.Activites.FindByADossierAActi(My.User.Name, Me.ActiviteShowAll)
                            If Convert.ToString(drAct.Item("ALib")) <> "" AndAlso Me.ActiviteShowAll <> "0000" Then
                                Me.Libelle = Convert.ToString(drCpt.Item("CLib")) + " - " + Convert.ToString(drAct.Item("ALib"))
                            Else
                                Me.Libelle = Convert.ToString(drCpt.Item("CLib"))
                            End If
                        End If
                    End If
                End If

                'Détermine le code TVA et filtre le bindingsource
                Me.CodeTva = DefineCodeTVA(dsAgrigest, TVABindingSource, Me.Compte)
                Dim drTVA As DataRow() = dsAgrigest.TVA.Select(String.Format("TCpt='{0}'", Me.Compte))
                If drTVA.Length = 1 Then
                    Me.CodeTVACompte = Convert.ToString(drTVA(0)("TTVA"))
                End If

                'Détermine le montant total débit et crédit pour le compte en cours dans la base (pour la visu de l'état du compte)
                Using dtaMouv As New dbDonneesDataSetTableAdapters.MouvementsTableAdapter
                    Me.TotalCredit = dtaMouv.GetSumCreditByDossierByCompte(My.User.Name, Me.Compte, Me.ActiviteShowAll)
                    Me.TotalDebit = dtaMouv.GetSumDebitByDossierByCompte(My.User.Name, Me.Compte, Me.ActiviteShowAll)
                End Using

            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' chargement du libellé de la ligne en fonction de l'activité saisie
    ''' </summary>
    ''' <param name="dsAgrigest"></param>
    ''' <remarks></remarks>
    Public Sub ChangementLigneA(ByRef dsAgrigest As dbDonneesDataSet)
        Try
            Dim drPCCpt As dbDonneesDataSet.PlanComptableRow = dsAgrigest.PlanComptable.FindByPlDossierPlCptPlActi(My.User.Name, Me.Compte, Me.Activite)
            If drPCCpt IsNot Nothing Then
                If Me.LibelleAuto Or Me.Libelle = "" Then
                    'Met le libellé du plan comptable
                    Me.Libelle = Convert.ToString(drPCCpt.Item("PlLib"))
                    If Me.Libelle = "" Then
                        'Met le libellé du compte et de l'activité si le plan comptable est vide
                        Dim drCpt As dbDonneesDataSet.ComptesRow = dsAgrigest.Comptes.FindByCDossierCCpt(My.User.Name, Me.Compte)
                        Dim drAct As dbDonneesDataSet.ActivitesRow = dsAgrigest.Activites.FindByADossierAActi(My.User.Name, Me.ActiviteShowAll)
                        Me.Libelle = Convert.ToString(drCpt.Item("CLib")) + " - " + Convert.ToString(drAct.Item("ALib"))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Valide la cohérence des données de la ligne
    ''' </summary>
    ''' <returns>retourne les informations concertants l'intégrité de la ligne</returns>
    ''' <remarks></remarks>
    Private Function ValidationDonneesSaisies(ByVal dtaRegle As dbDonneesDataSet.ReglesValidationDataTable) As DataValidationDetail

        Dim xLigneValided As New DataValidationDetail
        Try
            'Charge les résultat de la cohérence des ratios
            Dim xRowRegle As dbDonneesDataSet.ReglesValidationRow = dtaRegle.FindByCptAndActi(Me.Compte, Me.ActiviteShowAll)

            With xLigneValided
                .IsValide = True
                If xRowRegle Is Nothing Then Return xLigneValided

                .CellQte1Oblig = xRowRegle.Qt1Oblig
                .CellQte2Oblig = xRowRegle.Qt2Oblig

                'Vérifie que les quantité obligatoire sont mises et que celle saisie sont correct
                If .CellQte1Oblig Then
                    If Not Me.Quantite1.HasValue Then
                        .CellErrorQte1ObligText = My.Resources.Strings.Saisie_VeuillezSaisirUneQte
                        .IsValide = False
                    Else
                        .CellErrorRatioHT = dtaRegle.VerifRatioHT(Me.Compte, Me.ActiviteShowAll, Me.MontantDeb.GetValueOrDefault(0) + Me.MontantCre.GetValueOrDefault(0), Me.Quantite1)
                        .CellErrorRatioQT = dtaRegle.VerifRatioQt(Me.Compte, Me.ActiviteShowAll, Me.Quantite1, Me.Quantite2)
                        If .CellErrorRatioHT.HasValue AndAlso Not .CellErrorRatioHT.Value Then
                            .CellErrorRatioHTText = My.Resources.Strings.Saisie_VerifConformiteQte
                            .IsValide = False
                        End If
                        If .CellErrorRatioQT.HasValue AndAlso Not .CellErrorRatioQT.Value Then
                            .CellErrorRatioQTText = My.Resources.Strings.Saisie_VerifConformiteQte
                            .IsValide = False
                        End If
                    End If
                End If
                If .CellQte2Oblig Then
                    If Not Me.Quantite2.HasValue Then
                        .CellErrorQte2ObligText = My.Resources.Strings.Saisie_VeuillezSaisirUneQte
                        .IsValide = False
                    End If
                End If
            End With
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return xLigneValided

    End Function

    ''' <summary>
    ''' Vérifie que le compte existe bien dans le plan comptable 
    ''' Si le compte n'existe pas il va le créer ainsi que dans le plan comptable
    ''' si le compte existe mais pas au niveau du plan comptable il va aller le créer
    ''' </summary>
    ''' <param name="sCompte"></param>
    ''' <param name="t"></param>
    ''' <param name="sActivite"></param>
    ''' <remarks></remarks>
    Public Sub CheckAndCreateComptePlanComptable(ByVal sCompte As String, Optional ByRef t As OleDb.OleDbTransaction = Nothing, Optional ByVal sActivite As String = "0000")

        If sActivite = "" Then sActivite = "0000"
        Dim sLibelleCompte As String = ""
        Dim nExistCompte As Integer = 1
        Try
            Using dtaPlan As New dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
                If t IsNot Nothing Then dtaPlan.SetTransaction(t)
                'Vérifie que le compte existe dans le plan comptable
                nExistCompte = CInt(dtaPlan.ExistLigne(sCompte, My.User.Name, sActivite))
                'Charge le libellé du compte dans le plan type s'il exite
                Dim dtaTypeCompte As dbDonneesDataSet.PlanTypeDataTable = New dbDonneesDataSet.PlanTypeDataTable
                Using dtaPlanType As New dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
                    dtaPlanType.FillByCompte(dtaTypeCompte, sCompte)
                End Using
                If dtaTypeCompte.Rows.Count > 0 Then
                    sLibelleCompte = Microsoft.VisualBasic.Left(dtaTypeCompte.Rows(0)("PlALib").ToString, 30)
                End If
                If nExistCompte = 0 Then
                    Using dtaCompte As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                        If t IsNot Nothing Then dtaCompte.SetTransaction(t)
                        'Vérifie que le compte existe bien dans la table compte sinon il va le créer
                        If CInt(dtaCompte.ExistCompte(sCompte, My.User.Name)) = 0 Then
                            If dtaTypeCompte.Rows.Count > 0 Then
                                dtaCompte.Insert(My.User.Name, sCompte, Microsoft.VisualBasic.Left(dtaTypeCompte.Rows(0)("PlALib").ToString, 30), CStr(IIf(dtaTypeCompte.Rows(0)("PlAU1").ToString = "", Nothing, dtaTypeCompte.Rows(0)("PlAU1").ToString)), CStr(IIf(dtaTypeCompte.Rows(0)("PlAU2").ToString = "", Nothing, dtaTypeCompte.Rows(0)("PlAU2").ToString)), "", "")
                            Else
                                If t IsNot Nothing Then
                                    t.Rollback()
                                    t = Nothing
                                End If
                                Throw New ApplicationException(My.Resources.Strings.Saisie_CompteIntrouvableDansLePlanType)
                            End If
                        End If
                    End Using
                    'Ajoute une ligne dans le plan comptable pour le compte
                    dtaPlan.Insert(My.User.Name, sCompte, sActivite, sLibelleCompte)
                End If
            End Using
        Catch ex As Exception
            If t IsNot Nothing Then
                t.Rollback()
                t = Nothing
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Vérifie que le compte existe bien dans le plan comptable 
    ''' Si le compte n'existe pas il va le créer ainsi que dans le plan comptable
    ''' si le compte existe mais pas au niveau du plan comptable il va aller le créer
    ''' </summary>
    ''' <param name="sCompte"></param>
    ''' <param name="ds"></param>
    ''' <param name="sActivite"></param>
    ''' <remarks></remarks>
    Public Sub CheckAndCreateComptePlanComptable(ByVal sCompte As String, ByVal ds As dbDonneesDataSet, Optional ByVal sLibelleCompte As String = "", Optional ByVal sActivite As String = "0000")
        If sActivite = "" Then sActivite = "0000"

        'Vérifie que le compte existe dans le plan comptable
        Dim drPLC As dbDonneesDataSet.PlanComptableRow = ds.PlanComptable.FindByPlDossierPlCptPlActi(My.User.Name, sCompte, sActivite)
        If drPLC Is Nothing Then
            'Charge le libellé du compte dans le plan type s'il exite
            Dim drCpt As dbDonneesDataSet.ComptesRow = ds.Comptes.FindByCDossierCCpt(My.User.Name, sCompte)
            If drCpt Is Nothing Then
                drCpt = ds.Comptes.NewComptesRow
                With drCpt
                    .CDossier = My.User.Name
                    .CCpt = sCompte
                    .CLib = sLibelleCompte
                End With
                ds.Comptes.AddComptesRow(drCpt)
            End If

            Dim drActi As dbDonneesDataSet.ActivitesRow = ds.Activites.FindByADossierAActi(My.User.Name, sActivite)
            If drActi Is Nothing Then
                drActi = ds.Activites.NewActivitesRow
                With drActi
                    .ADossier = My.User.Name
                    .AActi = sActivite
                End With
                ds.Activites.AddActivitesRow(drActi)
            End If
            drPLC = ds.PlanComptable.AddPlanComptableRow(My.User.Name, sCompte, sActivite, "", "", sLibelleCompte)
        End If
    End Sub

    ''' <summary>
    ''' Permet de cloner une ligne
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Ligne

        Dim xLigneNew As New Ligne

        xLigneNew.Activite = Me.Activite
        xLigneNew.CodeTva = Me.CodeTva
        xLigneNew.Compte = Me.Compte
        xLigneNew.Libelle = Me.Libelle
        xLigneNew.MontantCre = Me.MontantCre
        xLigneNew.MontantDeb = Me.MontantDeb
        xLigneNew.MontantBaseHT = Me.MontantBaseHT
        xLigneNew.MOrdre = Me.MOrdre
        xLigneNew.NLigne = Me.NLigne
        xLigneNew.Quantite1 = Me.Quantite1
        xLigneNew.Quantite2 = Me.Quantite2
        xLigneNew.Unite1 = Me.Unite1
        xLigneNew.Unite2 = Me.Unite2
        xLigneNew.TotalCredit = Me.TotalCredit
        xLigneNew.TotalDebit = Me.TotalDebit
        xLigneNew.ContrePartie = Me.ContrePartie
        xLigneNew.ContrePartieLib = Me.ContrePartieLib
        Return xLigneNew

    End Function

    ''' <summary>
    ''' Permet de retourner les lignes d'un modèles pour qu'il soit intégré à une pièce
    ''' </summary>
    ''' <param name="bInsertValeurs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLigneModele(ByVal bInsertValeurs As Boolean) As Ligne

        Dim xLigneNew As New Ligne

        xLigneNew.Activite = Me.Activite
        xLigneNew.CodeTva = Me.CodeTva
        xLigneNew.Compte = Me.Compte
        CheckAndCreateComptePlanComptable(Me.Compte, , Me.Activite)
        xLigneNew.Libelle = Me.Libelle
        If bInsertValeurs Then
            xLigneNew.MontantCre = Me.MontantCre
            xLigneNew.MontantDeb = Me.MontantDeb
            xLigneNew.MontantBaseHT = Me.MontantBaseHT
            xLigneNew.TotalCredit = Me.TotalCredit
            xLigneNew.TotalDebit = Me.TotalDebit
            xLigneNew.Quantite1 = Me.Quantite1
            xLigneNew.Quantite2 = Me.Quantite2
        Else
            If Me.MontantCre.HasValue Then xLigneNew.MontantCre = 0
            If Me.MontantDeb.HasValue Then xLigneNew.MontantDeb = 0
            If Me.MontantBaseHT.HasValue Then xLigneNew.MontantBaseHT = 0
            If Me.TotalCredit.HasValue Then xLigneNew.TotalCredit = 0
            If Me.TotalDebit.HasValue Then xLigneNew.TotalDebit = 0
            If Me.Quantite1.HasValue Then xLigneNew.Quantite1 = 0
            If Me.Quantite2.HasValue Then xLigneNew.Quantite2 = 0
        End If
        xLigneNew.MOrdre = Me.MOrdre
        xLigneNew.NLigne = Me.NLigne
        xLigneNew.Unite1 = Me.Unite1
        xLigneNew.Unite2 = Me.Unite2
        xLigneNew.ContrePartie = Me.ContrePartie
        xLigneNew.ContrePartieLib = Me.ContrePartieLib
        xLigneNew.CodeTVACompte = Me.CodeTVACompte

        Return xLigneNew

    End Function
#End Region

#Region "Méthodes partagées"
    ''' <summary>
    ''' Permet de définir les codes TVA autorisé pour le compte en filtrant le bindingsource
    ''' </summary>
    ''' <param name="dsAgrigest"></param>
    ''' <param name="TVABindingSource"></param>
    ''' <param name="cpt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DefineCodeTVA(ByRef dsAgrigest As dbDonneesDataSet, ByRef TVABindingSource As BindingSource, ByVal cpt As String) As String
        Try

            Dim drPlanType() As dbDonneesDataSet.PlanTypeRow = DirectCast(dsAgrigest.PlanType.Select(String.Format("'{0}' LIKE PlARacine+'*'", cpt), "PlARacine DESC"), dbDonneesDataSet.PlanTypeRow())
            If drPlanType.Length > 0 Then
                'Filtrage du bindingsource
                If drPlanType(0).IsPlTypTVANull Then
                    TVABindingSource.Filter = ""
                Else
                    If drPlanType(0).PlTypTVA.Trim <> "" Then
                        TVABindingSource.Filter = String.Format("TTVA is NULL OR TypTVA='{0}'", drPlanType(0).PlTypTVA)
                    End If
                End If
                'Retourne le premier code TVA trouvé s'il en existe
                If Not drPlanType(0).IsPlTVANull Then
                    Return drPlanType(0).PlTVA
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return ""
    End Function
#End Region

End Class
