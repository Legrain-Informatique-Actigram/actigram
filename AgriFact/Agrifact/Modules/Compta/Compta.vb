Imports System.Xml.Serialization

Public Class Compta

    Public Enum ModesCompta
        Deconnecte
        Agrigest2
        AgrigestEDI
    End Enum

    Public Enum ModesExport
        Agrigest2
        AgrigestEDI
        Isacompta
        Infovia
        ISTEA
        Epicea
        Pomo
    End Enum


#Region "Membres statiques"

#Region "Constantes"
    'Paramétrage direct dans Agrifac
    Private Const NOMPARAM_AGRIGEST As String = "CheminBaseAgrigest"
    Private Const NOMPARAM_PLANTYPEAGRIGEST As String = "CheminBasePlanTypeAgrigest"

    'Paramétrage Agrigest²
    Private Const EXE_AGRIGEST As String = "Agrigest.exe"
    Private Const PARAM_AGRIGEST As String = "Parametres.xml"
    Private Const PARAM_AGRIGEST_MULTI As String = "Exploitations.xml"
    Private Const REGKEY_AGRIGEST As String = "SOFTWARE\ESAP\AGRIGEST²"
    Private Const DIR_AGRIGEST As String = "c:\Agrigest²"
    Private Const DIR_AGRIGEST_DATA As String = "Dossiers"

    'Paramétrage AgrigestEDI
    Private Const EXE_AGRIGEST_EDI As String = "AgrigestEDI.exe"
    Private Const PARAM_AGRIGEST_EDI As String = "Exploitations.xml"
    Private Const REGKEY_AGRIGEST_EDI As String = "SOFTWARE\ACTIGRAM\AGRIGESTEDI"
    Private Const DIR_AGRIGEST_EDI As String = "{pf}\Actigram\AgrigestEDI"
    Private Const DIR_AGRIGEST_EDI_DATA As String = "{CommonAppData}\Actigram\Agrigest EDI"
#End Region

#Region "Paramètres"
    Public Shared DtaDossier As OleDb.OleDbDataAdapter
    Public Shared ModeCompta As ModesCompta
    Public Shared ModeExport As ModesExport
    Public Shared NDossierCompta As String = ""
    Public Shared NomDossier As String = ""
    Public Shared DebutExCompta As Date = Nothing
    Public Shared FinExCompta As Date = Nothing
    Public Shared TVAEncaissement As Boolean = False
    Public Shared BlocNPieceDebutAFacture As String = ""
    Public Shared BlocNPieceFinAFacture As String = ""
    Public Shared BlocNPieceDebutVFacture As String = ""
    Public Shared BlocNPieceFinVFacture As String = ""
    Public Shared BlocNPieceDebutAReglement As String = ""
    Public Shared BlocNPieceFinAReglement As String = ""
    Public Shared BlocNPieceDebutVReglement As String = ""
    Public Shared BlocNPieceFinVReglement As String = ""
    Private Shared CleCompta As String = ""
    Public Shared RgpCptsPdtsExportVtes As Boolean = False
    Public Shared LimiterCptImportCompta As Boolean = False
    Public Shared VFactureNumFactureAgrifact As Boolean = False
    Public Shared VFactureComposerNumPiece As Boolean = False
    Public Shared VFactureRacineNumPiece As String = String.Empty
    Public Shared ChkFourchVFact As Boolean = False
#End Region

#Region "Propriétés"
    Private Shared _cheminBaseAgrigest As String = ""
    Public Shared ReadOnly Property CheminBaseAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                    If _cheminBaseAgrigest = "" Then
                        _cheminBaseAgrigest = TrouverCheminBaseAgrigest()
                    End If
                    Return _cheminBaseAgrigest
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Private Shared _cheminBasePlanTypeAgrigest As String = ""
    Public Shared ReadOnly Property CheminBasePlanTypeAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                    If _cheminBasePlanTypeAgrigest = "" Then
                        _cheminBasePlanTypeAgrigest = TrouverCheminBasePlanTypeAgrigest()
                    End If
                    Return _cheminBasePlanTypeAgrigest
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property CheminParamAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2
                    If IO.File.Exists(IO.Path.Combine(CheminDossierDataAgrigest, PARAM_AGRIGEST_MULTI)) Then
                        Return IO.Path.Combine(CheminDossierDataAgrigest, PARAM_AGRIGEST_MULTI)
                    Else
                        Return IO.Path.Combine(CheminDossierDataAgrigest, PARAM_AGRIGEST)
                    End If
                Case ModesCompta.AgrigestEDI
                    Return IO.Path.Combine(CheminDossierDataAgrigest, PARAM_AGRIGEST_EDI)
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property CheminAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2
                    Return IO.Path.Combine(CheminDossierAgrigest, EXE_AGRIGEST)
                Case ModesCompta.AgrigestEDI
                    Return IO.Path.Combine(CheminDossierAgrigest, EXE_AGRIGEST_EDI)
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Private Shared _cheminDossierAgrigest As String = ""
    Private Shared ReadOnly Property CheminDossierAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                    If _cheminDossierAgrigest = "" Then
                        _cheminDossierAgrigest = TrouverCheminDossierAgrigest()
                    End If
                    Return _cheminDossierAgrigest
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property CheminDossierDataAgrigest() As String
        Get
            Select Case ModeCompta
                Case ModesCompta.Agrigest2
                    If IO.Directory.Exists(IO.Path.Combine(CheminDossierAgrigest, DIR_AGRIGEST_DATA)) Then
                        Return IO.Path.Combine(CheminDossierAgrigest, DIR_AGRIGEST_DATA)
                    Else
                        Return CheminDossierAgrigest
                    End If
                Case ModesCompta.AgrigestEDI
                    Return DIR_AGRIGEST_EDI_DATA.Replace("{CommonAppData}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
                Case Else
                    Return ""
            End Select
        End Get
    End Property
#End Region

#Region "Méthodes privées"
    Private Shared Function TrouverCheminDossierAgrigest() As String
        Select Case ModeCompta
            Case ModesCompta.Agrigest2
                Return TrouverCheminDossierAgrigest2()
            Case ModesCompta.AgrigestEDI
                Return TrouverCheminDossierAgrigestEDI()
            Case Else
                Return ""
        End Select
    End Function

    Private Shared Function TrouverCheminDossierAgrigest2() As String
        Dim chemin As String = ""
        'En priorité regarder dans la registry la clé "SOFTWARE\ESAP\AGRIGEST²"
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGKEY_AGRIGEST)
        If Not key Is Nothing Then
            chemin = Convert.ToString(key.GetValue("Dossier_Install", ""))
            key.Close()
        End If
        If chemin = "" Then
            'Sinon, voir le dossier "c:\Agrigest²"
            chemin = DIR_AGRIGEST
        End If
        If chemin <> "" Then
            'Vérifier l'existence du chemin trouvé
            If Not IO.Directory.Exists(chemin) Then
                chemin = ""
            End If
        End If
        Return chemin
    End Function

    Private Shared Function GetInstallLocation(ByVal appId As String) As String
        Dim res As String = ""
        Dim cheminKey As String = String.Format("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0}", appId)
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(cheminKey)
        If Not key Is Nothing Then
            res = Convert.ToString(key.GetValue("InstallLocation", ""))
            key.Close()
        End If
        Return res
    End Function

    Private Shared Function TrouverCheminDossierAgrigestEDI() As String
        Dim chemin As String = ""

        'Voir dans les informations de désinstallation
        chemin = GetInstallLocation("{F9C90EB2-DF53-4257-A396-A03FC0719991}_is1") 'Version InnoSetup à partir de 1.0
        If chemin = "" Then
            chemin = GetInstallLocation("{E976DA68-D5C4-4EF3-9F40-230275A30894}") 'Version MSI jusqu'à 0.9
        End If
        If chemin = "" Then 'Sinon, voir le dossier "{pf}\Actigram\AgrigestEDI"
            chemin = DIR_AGRIGEST_EDI.Replace("{pf}", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
        End If

        If chemin <> "" Then
            'Vérifier l'existence du chemin trouvé
            If Not IO.Directory.Exists(chemin) Then
                chemin = ""
            End If
        End If
        Return chemin
    End Function

#Region "Chemin base Agrigest"
    Private Shared Function TrouverCheminBaseAgrigest() As String
        Select Case ModeCompta
            Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                Dim res As String = ""
                'Tenter de trouver le chemin de la base Agrigest dans le paramétrage Agrifac
                res = CStr(ParametresApplication.ValeurParametre(NOMPARAM_AGRIGEST, ""))
                If Not IO.File.Exists(res) Then
                    If ModeCompta = ModesCompta.Agrigest2 Then
                        res = TrouverCheminBaseAgrigest2()
                    Else
                        res = TrouverCheminBaseAgrigestExploit()
                    End If
                End If
                Return res
            Case Else
                Return ""
        End Select
    End Function

    Private Shared Function TrouverCheminBaseAgrigest2() As String
        Dim res As String = ""
        If CheminDossierAgrigest <> "" Then
            If IO.Path.GetFileName(CheminParamAgrigest) = "Exploitations.xml" Then
                res = TrouverCheminBaseAgrigestExploit()
            Else
                res = TrouverCheminBaseAgrigest2Old()
            End If
        End If
        Return res
    End Function

    Private Shared Function TrouverCheminBaseAgrigestExploit() As String
        Dim res As String = ""
        Dim ex As Exploitation = TrouverExploitationAgrigest()
        If Not ex Is Nothing Then
            Dim chemin As String = ex.CheminBase.Replace("|DataDirectory|", CheminDossierAgrigest)
            If IO.File.Exists(chemin) Then
                res = chemin
            End If
        End If
        Return res
    End Function

    Private Shared Function TrouverCheminBaseAgrigest2Old() As String
        Dim res As String = ""

        'Lire le paramétrage Agrigest et trouver la clé <Parametres><CheminAccesBase>
        If IO.File.Exists(CheminParamAgrigest) Then
            Dim dsParamAgrigest As New DataSet
            Try
                dsParamAgrigest.ReadXml(CheminParamAgrigest)
            Catch
            End Try
            If dsParamAgrigest.Tables.Contains("Parametres") Then
                Dim tb As DataTable = dsParamAgrigest.Tables("Parametres")
                If tb.Columns.Contains("CheminAccesBase") Then
                    If tb.Rows.Count > 0 Then
                        Dim chemin As String = Convert.ToString(tb.Rows(0).Item("CheminAccesBase"))
                        If IO.File.Exists(chemin) Then
                            res = chemin
                        End If
                    End If
                End If
            End If
        End If
        Return res
    End Function
#End Region

#Region "Chemin base plan type Agrigest"
    Private Shared Function TrouverCheminBasePlanTypeAgrigest() As String
        Select Case ModeCompta
            Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                Dim res As String = ""
                'Tenter de trouver le chemin de la base Agrigest dans le paramétrage Agrifac
                res = CStr(ParametresApplication.ValeurParametre(NOMPARAM_PLANTYPEAGRIGEST, ""))
                If Not IO.File.Exists(res) Then
                    If ModeCompta = ModesCompta.Agrigest2 Then
                        res = TrouverCheminBasePlanTypeAgrigest2()
                    Else
                        res = TrouverCheminBasePlanTypeAgrigestExploit()
                    End If
                End If
                Return res
            Case Else
                Return ""
        End Select
    End Function

    Private Shared Function TrouverCheminBasePlanTypeAgrigest2() As String
        Dim res As String = ""
        If CheminDossierAgrigest <> "" Then
            If IO.Path.GetFileName(CheminParamAgrigest) = "Exploitations.xml" Then
                res = TrouverCheminBasePlanTypeAgrigestExploit()
            Else
                res = TrouverCheminBasePlanTypeAgrigest2Old()
            End If
        End If
        Return res
    End Function

    Private Shared Function TrouverCheminBasePlanTypeAgrigest2Old() As String
        Dim res As String = ""
        If CheminDossierAgrigest <> "" Then
            'Lire le paramétrage Agrigest et trouver la clé <Parametres><CheminAccesBasePlanType>
            If IO.File.Exists(CheminParamAgrigest) Then
                Dim dsParamAgrigest As New DataSet
                Try
                    dsParamAgrigest.ReadXml(CheminParamAgrigest)
                Catch
                End Try
                If dsParamAgrigest.Tables.Contains("Parametres") Then
                    Dim tb As DataTable = dsParamAgrigest.Tables("Parametres")
                    If tb.Columns.Contains("CheminAccesBasePlanType") Then
                        If tb.Rows.Count > 0 Then
                            Dim chemin As String = Convert.ToString(tb.Rows(0).Item("CheminAccesBasePlanType"))
                            If IO.File.Exists(chemin) Then
                                res = chemin
                            End If
                        End If
                    Else
                        'Pas de paramètrage spécifique du plan type : il doit se trouver dans la même base que la compta
                        res = CheminBaseAgrigest
                    End If
                End If
            End If
        End If
        Return res
    End Function

    Private Shared Function TrouverCheminBasePlanTypeAgrigestExploit() As String
        Dim res As String = ""
        Dim ex As Exploitation = TrouverExploitationAgrigest()
        If Not ex Is Nothing Then
            Dim chemin As String = ex.CheminBasePlanType.Replace("|DataDirectory|", CheminDossierAgrigest)
            If IO.File.Exists(chemin) Then
                res = chemin
            End If
        End If
        Return res
    End Function
#End Region

    Private Shared Function TrouverExploitationAgrigest() As Exploitation
        Dim res As Exploitation = Nothing
        If CheminDossierAgrigest <> "" Then
            If IO.File.Exists(CheminParamAgrigest) Then
                Dim expls() As Exploitation = Exploitation.LoadFromFile(CheminParamAgrigest)
                If Not expls Is Nothing Then
                    'Trouver l'exploitation qui va bien
                    Dim codeEx As String = Left(NDossierCompta, 6)
                    For Each ex As Exploitation In expls
                        If ex.CodeExpl = codeEx Then
                            res = ex
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
        Return res
    End Function

    Private Shared Function ConfigurerLienAgrigest() As EXPORTCOMPTA.Agrigest.ExportAgrigest
        Dim frExport As New EXPORTCOMPTA.Agrigest.ExportAgrigest
        frExport.ChargerDonnees(My.Settings.AgrifactConnString, Compta.CheminBaseAgrigest, Compta.CheminBasePlanTypeAgrigest, Compta.NDossierCompta.Substring(0, 6), True)
        Return frExport
    End Function

    Private Shared Function ConfigurerLienAgrigestEDI() As EXPORTCOMPTA.Agrigest.ExportAgrigestEDI
        Dim frExport As New EXPORTCOMPTA.Agrigest.ExportAgrigestEDI
        frExport.ChargerDonnees(My.Settings.AgrifactConnString, Compta.CheminBaseAgrigest, Compta.CheminBasePlanTypeAgrigest, Compta.NDossierCompta.Substring(0, 6), True)
        Return frExport
    End Function
#End Region

#Region "Méthodes publiques"
    Public Shared Sub ResetCompta(Optional ByVal resetMode As Boolean = True)
        If resetMode Then ModeCompta = ModesCompta.Deconnecte
        _cheminBaseAgrigest = ""
        _cheminBasePlanTypeAgrigest = ""
        _cheminDossierAgrigest = ""
    End Sub

    'Determiner quel est le systeme de compta
    Public Shared Function DeterminerModeCompta() As ModesCompta()
        'Déconnecté par défaut
        Dim res(0) As ModesCompta
        res(0) = ModesCompta.Deconnecte
        Dim chemin As String = TrouverCheminDossierAgrigestEDI()
        'Si AgrigestEDI est présent => AgrigestEDI
        If chemin <> "" Then
            If IO.File.Exists(IO.Path.Combine(chemin, EXE_AGRIGEST_EDI)) Then
                ReDim Preserve res(res.Length)
                res(res.Length - 1) = ModesCompta.AgrigestEDI
            End If
        End If
        'Si Agrigest est présent => Agrigest²
        chemin = TrouverCheminDossierAgrigest2()
        If chemin <> "" Then
            If IO.File.Exists(IO.Path.Combine(chemin, EXE_AGRIGEST)) Then
                ReDim Preserve res(res.Length)
                res(res.Length - 1) = ModesCompta.Agrigest2
            End If
        End If
        Return res
    End Function

    Public Shared Sub OuvrirAgrigest()
        Dim chemin As String = CheminAgrigest()
        If chemin <> "" And IO.File.Exists(chemin) Then
            Process.Start(chemin)
        Else
            MsgBox("Agrigest est introuvable sur cet ordinateur", MsgBoxStyle.Exclamation, "Attention")
        End If
    End Sub

#Region "Gestion des paramètres Agrifact"
    Public Shared Sub ChargerParametres()
        ModeCompta = CType([Enum].Parse(GetType(ModesCompta), CStr(ParametresApplication.ValeurParametre("ModeCompta", "Deconnecte"))), ModesCompta)
        ModeExport = CType([Enum].Parse(GetType(ModesExport), CStr(ParametresApplication.ValeurParametre("ModeExport", "Isacompta"))), ModesExport)
        NDossierCompta = CStr(ParametresApplication.ValeurParametre("NDossierCompta", ""))
        NomDossier = CStr(ParametresApplication.ValeurParametre("NomDossierCompta", ""))
        DebutExCompta = CDate(ParametresApplication.ValeurParametre("DebutExCompta", DebutExCompta))
        FinExCompta = CDate(ParametresApplication.ValeurParametre("FinExCompta", FinExCompta))
        TVAEncaissement = (CStr(ParametresApplication.ValeurParametre("TypeTVA", "")) = "TVA sur Encaissement")
        BlocNPieceDebutAFacture = CStr(ParametresApplication.ValeurParametre("BlocNPieceDebutA", "0", True))
        BlocNPieceDebutVFacture = CStr(ParametresApplication.ValeurParametre("BlocNPieceDebutV", "0", True))
        BlocNPieceFinAFacture = CStr(ParametresApplication.ValeurParametre("BlocNPieceFinA", "99999", True))
        BlocNPieceFinVFacture = CStr(ParametresApplication.ValeurParametre("BlocNPieceFinV", "99999", True))
        BlocNPieceDebutAReglement = CStr(ParametresApplication.ValeurParametre("BlocNPieceDebutAReglement", "0", True))
        BlocNPieceDebutVReglement = CStr(ParametresApplication.ValeurParametre("BlocNPieceDebutVReglement", "0", True))
        BlocNPieceFinAReglement = CStr(ParametresApplication.ValeurParametre("BlocNPieceFinAReglement", "99999", True))
        BlocNPieceFinVReglement = CStr(ParametresApplication.ValeurParametre("BlocNPieceFinVReglement", "99999", True))
        Compta.RgpCptsPdtsExportVtes = CBool(ParametresApplication.ValeurParametre("RgpCptsPdtsExportVtes", Compta.RgpCptsPdtsExportVtes, True))
        Compta.LimiterCptImportCompta = CBool(ParametresApplication.ValeurParametre("LimiterCptImportCompta", Compta.LimiterCptImportCompta, False))
        Compta.VFactureNumFactureAgrifact = CBool(ParametresApplication.ValeurParametre("VFactureNumFactureAgrifact", Compta.VFactureNumFactureAgrifact, True))
        Compta.VFactureComposerNumPiece = CBool(ParametresApplication.ValeurParametre("VFactureComposerNumPiece", Compta.VFactureComposerNumPiece, True))
        Compta.VFactureRacineNumPiece = CStr(ParametresApplication.ValeurParametre("VFactureRacineNumPiece", Compta.VFactureRacineNumPiece, True))
        Compta.ChkFourchVFact = CBool(ParametresApplication.ValeurParametre("ChkFourchVFact", Compta.ChkFourchVFact, True))
    End Sub

    Public Shared Sub EnregistrerParametres(Optional ByVal saveFile As Boolean = True)
        'Enregistrement dans le fichier parametres
        ParametresApplication.EnregistrerParametre("ModeCompta", ModeCompta.ToString, False)
        ParametresApplication.EnregistrerParametre("ModeExport", ModeExport.ToString, False)
        ParametresApplication.EnregistrerParametre("NDossierCompta", NDossierCompta, False)
        ParametresApplication.EnregistrerParametre("NomDossierCompta", NomDossier, False)
        ParametresApplication.EnregistrerParametre("TypeTVA", CStr(IIf(Compta.TVAEncaissement, "TVA sur Encaissement", "TVA sur Facturation")), False)
        ParametresApplication.EnregistrerParametre("DebutExCompta", DebutExCompta, False)
        ParametresApplication.EnregistrerParametre("FinExCompta", FinExCompta, False)

        ParametresApplication.EnregistrerParametre("BlocNPieceDebutA", BlocNPieceDebutAFacture, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceFinA", BlocNPieceFinAFacture, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceDebutV", BlocNPieceDebutVFacture, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceFinV", BlocNPieceFinVFacture, False)

        ParametresApplication.EnregistrerParametre("BlocNPieceDebutAReglement", BlocNPieceDebutAReglement, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceFinAReglement", BlocNPieceFinAReglement, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceDebutVReglement", BlocNPieceDebutVReglement, False)
        ParametresApplication.EnregistrerParametre("BlocNPieceFinVReglement", BlocNPieceFinVReglement, False)

        ParametresApplication.EnregistrerParametre("RgpCptsPdtsExportVtes", Compta.RgpCptsPdtsExportVtes, False)
        ParametresApplication.EnregistrerParametre("LimiterCptImportCompta", Compta.LimiterCptImportCompta, False)

        ParametresApplication.EnregistrerParametre("VFactureNumFactureAgrifact", Compta.VFactureNumFactureAgrifact, False)
        ParametresApplication.EnregistrerParametre("VFactureComposerNumPiece", Compta.VFactureComposerNumPiece, False)
        ParametresApplication.EnregistrerParametre("VFactureRacineNumPiece", Compta.VFactureRacineNumPiece, False)
        ParametresApplication.EnregistrerParametre("ChkFourchVFact", Compta.ChkFourchVFact, False)

        If saveFile Then ParametresApplication.EnregistrerParametres()
    End Sub
#End Region

    Public Shared Sub ChargerDonneesCompta(ByVal ds As DataSet)
        Using s As New SqlProxy
            ChargerDonneesCompta(ds, s)
        End Using
    End Sub

    Public Shared Sub ChargerDonneesCompta(ByVal ds As DataSet, ByVal s As SqlProxy)
        s.Fill(ds, "Comptes")
        s.Fill(ds, "Activites")
        s.Fill(ds, "PlanComptable")
    End Sub

#Region "Chargement des données Compta"
    Public Shared Function ListerDossiers() As DataTable
        Dim res As DataTable = Nothing
        If ModeCompta = ModesCompta.Deconnecte Then
            Return res
        ElseIf ModeCompta = ModesCompta.Agrigest2 And IO.Path.GetFileName(CheminParamAgrigest) = PARAM_AGRIGEST Then
            If DtaDossier Is Nothing Then
                Dim cn As OleDb.OleDbConnection, cnpt As OleDb.OleDbConnection
                ConfigConnections(cn, cnpt)
                CreateDtaDossier(cn)
            End If
            Dim dsCompta As New DataSet
            DtaDossier.Fill(dsCompta, "Dossier")
            If dsCompta.Tables.Contains("Dossier") Then
                dsCompta.Tables("Dossier").DefaultView.Sort = "DDossier"
                res = dsCompta.Tables("Dossier")
            End If
        Else 'AgrigestEDI ou bien Agrigest² multibase
            Dim expls() As Exploitation = Exploitation.LoadFromFile(CheminParamAgrigest)
            If Not expls Is Nothing AndAlso expls.Length > 0 Then
                Dim dtDossier As New DataTable("Dossier")
                dtDossier.Columns.Add("DDossier", GetType(String))
                dtDossier.Columns.Add("NomDossier", GetType(String))
                For Each ex As Exploitation In expls
                    dtDossier.LoadDataRow(New Object() {ex.CodeExpl, ex.Nom}, True)
                Next
                res = dtDossier
                dtDossier.DefaultView.Sort = "DDossier"
            End If
        End If
        Return res
    End Function

    Public Shared Sub ConfigConnections(ByRef cn As OleDb.OleDbConnection, ByRef cnpt As OleDb.OleDbConnection)
        If CheminBaseAgrigest = "" Then
            Throw New ApplicationException("La base de données Agrigest est introuvable sur cet ordinateur.")
        End If

        cn = New OleDb.OleDbConnection(String.Format("Data Source=""{0}"";Provider=""Microsoft.Jet.OLEDB.4.0""", CheminBaseAgrigest))
        If CheminBasePlanTypeAgrigest = CheminBaseAgrigest Then
            cnpt = cn
        Else
            cnpt = New OleDb.OleDbConnection(String.Format("Data Source=""{0}"";Provider=""Microsoft.Jet.OLEDB.4.0""", CheminBasePlanTypeAgrigest))
        End If
    End Sub

    Private Shared Sub CreateDtaDossier(ByVal cn As OleDb.OleDbConnection)
        DtaDossier = New OleDb.OleDbDataAdapter("Select Dossiers.*,Exploitations.ENom1 as NomDossier From Dossiers  INNER JOIN Exploitations ON Dossiers.DExpl=Exploitations.EExpl", cn)
    End Sub

    'Public Shared Sub ChargerDonnees(ByVal dsAgrifact As DataSet)
    Public Shared Sub ChargerDonnees()
        ResetCompta(False)
        'ModeCompta = DeterminerModeCompta()

        Select Case ModeCompta
            Case ModesCompta.Agrigest2, ModesCompta.AgrigestEDI
                'Mode connecté à Agrigest
                Dim frP As New FrProgressBar
                With frP
                    .Maximum = 18
                    .Value = 0
                    .Show()
                End With

                Dim cn As OleDb.OleDbConnection
                Dim cnPt As OleDb.OleDbConnection
                Try
                    frP.Text = "Vérification des paramétres compta..."
                    ChargerParametres()
                    frP.Value += 1

                    ConfigConnections(cn, cnPt)
                    CreateDtaDossier(cn)

                    frP.Value += 1

                    cn.Open()
                    frP.Value += 1

                    If NDossierCompta = "" Then
                        Throw New ApplicationException("Le dossier de compta n'est pas configuré.")
                    End If

                    Dim sql As String
                    If NDossierCompta.Length = 6 Then
                        sql = "Select * From Dossiers INNER JOIN Exploitations ON Dossiers.DExpl=Exploitations.EExpl where DExpl='" & NDossierCompta & "' order by DDtDebEx desc"
                    Else
                        sql = "Select * From Dossiers INNER JOIN Exploitations ON Dossiers.DExpl=Exploitations.EExpl where DDossier='" & NDossierCompta & "'"
                    End If
                    Dim cmd As New OleDb.OleDbCommand(Sql, cn)
                    Dim rdr As OleDb.OleDbDataReader = cmd.ExecuteReader
                    Try
                        If rdr.Read Then
                            Compta.CleCompta = Convert.ToString(rdr("DDossier"))
                            Compta.NomDossier = Convert.ToString(rdr("ENom1"))
                            Compta.DebutExCompta = Convert.ToDateTime(rdr("DDtDebEx"))
                            Compta.FinExCompta = Convert.ToDateTime(rdr("DDtFinEx"))
                            Compta.EnregistrerParametres()
                        Else
                            Throw New ApplicationException(String.Format("Le dossier {0} n'existe pas dans la base Agrigest de ce poste.", NDossierCompta))
                        End If
                    Finally
                        rdr.Close()
                    End Try
                    frP.Value += 1

                    Dim tables() As String = {"Activites", "Comptes", "PlanComptable", "TVA", "Journal"}
                    frP.Text = "Chargement des données Agrigest..."
                    Dim dsCompta As New DataSet
                    DefinitionDonnees.Instance.FillSchema(dsCompta, "TVA")
                    For Each tb As String In tables
                        If tb = "TVA" Or tb = "Journal" Then
                            If Not (tb = "Journal" And Compta.ModeCompta = ModesCompta.Agrigest2) Then
                                CreateOledbAdapter(tb, Compta.CleCompta, cnPt).Fill(dsCompta, tb)
                            End If
                        Else
                            If (Compta.LimiterCptImportCompta And Compta.ModeCompta = ModesCompta.Agrigest2) Then
                                CreateOledbAdapter2(tb, Compta.CleCompta, cn).Fill(dsCompta, tb)
                            Else
                                CreateOledbAdapter(tb, Compta.CleCompta, cn).Fill(dsCompta, tb)
                            End If
                        End If

                        frP.Value += 1
                    Next
                    cn.Close()

                    frP.Text = String.Format("Nettoyage de la base {0}...", Application.ProductName)
                    Using s As New SqlProxy
                        'Vidage en ordre inverse
                        For i As Integer = tables.Length - 1 To 0 Step -1
                            'Vider les tables dans la base SQL
                            s.ExecuteNonQuery(String.Format("Delete from [{0}]", tables(i)))
                            frP.Value += 1
                        Next

                        'Correction des libellés TVA
                        frP.Text = "Vérification de la TVA..."
                        Dim rws() As DataRow = dsCompta.Tables("TVA").Select("TTVA Is Null")
                        If rws.Length > 0 Then
                            rws(0).Item("TTVA") = ""
                            rws(0).Item("TLibelle") = DBNull.Value
                        End If

                        'Vérif des codes TVA présents dans les tables Entreprise, Produit et VFacture_Detail
                        Dim tablesAVerif() As String = {"Entreprise", "Produit", "VFacture_Detail", "VBonCommande_Detail", "VBonLivraison_Detail", "VDevis_Detail", "AFacture_Detail", "ABonReception_Detail"}
                        Dim codesVerif As New Collections.Specialized.StringCollection
                        For Each t As String In tablesAVerif
                            Dim dtVerif As DataTable = s.ExecuteDataTable("SELECT DISTINCT TTVA FROM " & t & " WHERE TTVA is not null and TTVA<>'' ORDER BY TTVA")
                            For Each dr As DataRow In dtVerif.Rows
                                Dim tva As String = Convert.ToString(dr("TTVA"))
                                If Not codesVerif.Contains(tva) Then
                                    If dsCompta.Tables("TVA").Select(String.Format("TTVA='{0}'", tva.Replace("'", "''"))).Length = 0 Then
                                        Throw New ApplicationException(String.Format("Le code TVA '{0}' n'est pas présent en compta, " & vbCrLf & "cela peut entrainer des erreurs de calcul de TVA", tva))
                                    Else
                                        codesVerif.Add(tva)
                                    End If
                                End If
                            Next
                        Next
                        frP.Value += 1

                        'Balancer les updates
                        frP.Text = String.Format("Mise à jour de la base {0}...", Application.ProductName)
                        For Each tb As String In tables
                            If Not (tb = "Journal" And Compta.ModeCompta = ModesCompta.Agrigest2) Then
                                SqlProxy.ForceInsert(CreateSqlAdapter(tb, NDossierCompta, s), dsCompta.Tables(tb))
                                frP.Text = String.Format("Mise à jour de la table {0} terminée...", tb)
                                frP.Value += 1
                            End If
                        Next
                    End Using

                    'Mise en place des relations
                    'With dsCompta.Tables("PlanComptable")
                    '    If Not dsCompta.Relations.Contains("ActivitesPlanComptable") Then
                    '        Dim tbAct As DataTable = DsAgrifact.Tables("Activites")
                    '        DsAgrifact.Relations.Add(New DataRelation("ActivitesPlanComptable", _
                    '                                    New DataColumn() {tbAct.Columns("ADossier"), tbAct.Columns("AActi")}, _
                    '                                    New DataColumn() {.Columns("PlDossier"), .Columns("PlActi")}))
                    '    End If
                    '    If Not DsAgrifact.Relations.Contains("ComptesPlanComptable") Then
                    '        Dim tbCpt As DataTable = DsAgrifact.Tables("Comptes")
                    '        DsAgrifact.Relations.Add(New DataRelation("ComptesPlanComptable", _
                    '                                    New DataColumn() {tbCpt.Columns("CDossier"), tbCpt.Columns("CCpt")}, _
                    '                                    New DataColumn() {.Columns("PlDossier"), .Columns("PlCpt")}))
                    '    End If
                    'End With
                    frP.Value += 1

                    FrApplication.Modules.ModuleCompta = True
                Catch ex As Exception
                    ModeCompta = ModesCompta.Deconnecte
                    MsgBox(ex.Message & vbCrLf & "La liaison avec Agrigest va être désactivée.", MsgBoxStyle.Exclamation, "Attention")
                Finally
                    If Not cn Is Nothing AndAlso Not cn.State = ConnectionState.Closed Then cn.Close()
                    If Not cnPt Is Nothing AndAlso Not cnPt.State = ConnectionState.Closed Then cnPt.Close()
                    frP.Close()
                End Try
            Case Else
                'Mode deconnecté => on utilise seulement les tables Agrifact
                'TODO Il va falloir initialiser CleCompta (pas génial)
                Compta.CleCompta = Compta.NDossierCompta
                Dim dtDossiers As DataTable
                Using s As New SqlProxy
                    dtDossiers = s.ExecuteDataTable("SELECT * FROM Dossiers")
                End Using
                Dim rws() As DataRow = dtDossiers.Select("", "DDtDebEx desc")
                If rws.Length > 0 Then
                    With rws(0)
                        Compta.DebutExCompta = Convert.ToDateTime(.Item("DDtDebEx"))
                        Compta.FinExCompta = Convert.ToDateTime(.Item("DDtFinEx"))
                    End With
                End If
                Compta.EnregistrerParametres()
        End Select
    End Sub

    Private Shared Function CreateOledbAdapter(ByVal tableName As String, ByVal dossier As String, ByVal cn As OleDb.OleDbConnection) As OleDb.OleDbDataAdapter
        Return New OleDb.OleDbDataAdapter(GetQuery(tableName, dossier, True), cn)
    End Function

    Private Shared Function CreateOledbAdapter2(ByVal tableName As String, ByVal dossier As String, ByVal cn As OleDb.OleDbConnection) As OleDb.OleDbDataAdapter
        Return New OleDb.OleDbDataAdapter(GetQuery2(tableName, dossier, True), cn)
    End Function

    Private Shared Function CreateSqlAdapter(ByVal tableName As String, ByVal dossier As String, ByVal s As SqlProxy) As SqlClient.SqlDataAdapter
        Return s.GetAdapter(GetQuery(tableName, dossier, False), True)
    End Function

    Private Shared Function GetQuery(ByVal tableName As String, ByVal dossier As String, Optional ByVal fromAgrigest As Boolean = True) As String
        Dim query As String
        Dim colName As String
        Select Case tableName
            Case "Activites" : colName = "ADossier"
            Case "Comptes" : colName = "CDossier"
            Case "PlanComptable" : colName = "PlDossier"
            Case "TVA" : query = String.Format("Select {1}TTVA,{0}TLibelle,{2}TTaux,TCpt,TJournal From TVA", _
                                                IIf(fromAgrigest, "Libellé As ", ""), IIf(Not fromAgrigest, "nTVA,", ""), IIf(Not fromAgrigest, "TypTVA,", ""))
        End Select
        If query = "" Then
            If colName Is Nothing Then
                query = String.Format("Select * From {0}", tableName)
            Else
                query = String.Format("Select * From {0} where {1}='{2}'", tableName, colName, dossier)
            End If
        End If
        Return query
    End Function

    Private Shared Function GetQuery2(ByVal tableName As String, ByVal dossier As String, Optional ByVal fromAgrigest As Boolean = True) As String
        Dim query As String
        Dim colName As String

        Select Case tableName
            Case "Activites"
                colName = "ADossier"
            Case "Comptes"
                query = String.Format("SELECT * FROM Comptes WHERE CDossier='{0}' AND (CCpt LIKE '5%' OR CCpt LIKE '6%' OR CCpt LIKE '7%')", dossier)
            Case "PlanComptable"
                query = String.Format("SELECT * FROM PlanComptable WHERE PlDossier='{0}' AND (PlCpt LIKE '5%' OR PlCpt LIKE '6%' OR PlCpt LIKE '7%')", dossier)
            Case "TVA" : query = String.Format("Select {1}TTVA,{0}TLibelle,{2}TTaux,TCpt,TJournal From TVA", _
                                                IIf(fromAgrigest, "Libellé As ", ""), IIf(Not fromAgrigest, "nTVA,", ""), IIf(Not fromAgrigest, "TypTVA,", ""))
        End Select
        If query = "" Then
            If colName Is Nothing Then
                query = String.Format("Select * From {0}", tableName)
            Else
                query = String.Format("Select * From {0} where {1}='{2}'", tableName, colName, dossier)
            End If
        End If
        Return query
    End Function
#End Region
#End Region

#End Region

    Private ds As DataSet
    Private bdM As BindingManagerBase
    Private LibelleCompta As String = "Libelle"

    Private _lienCompta As ExportCompta.ISynchroPLC

#Region "Propriétés"
    Private ReadOnly Property LienCompta() As ExportCompta.ISynchroPLC
        Get
            If _lienCompta Is Nothing Then
                Select Case ModeCompta
                    Case ModesCompta.Agrigest2
                        _lienCompta = ConfigurerLienAgrigest()
                    Case ModesCompta.AgrigestEDI
                        _lienCompta = ConfigurerLienAgrigestEDI()
                    Case Else
                End Select
            End If
            Return _lienCompta
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByRef monds As DataSet, ByRef monbdM As BindingManagerBase, ByVal Libelle As String)
        ds = monds
        bdM = monbdM
        LibelleCompta = Libelle
    End Sub
#End Region

#Region " Création des comptes et activité "
    Private Sub AjoutPlanComptable(ByVal nCompte As String, ByVal nActivite As String)
        If bdM.Position <> -1 Then
            If ds.Tables("PlanComptable").Select("PlDossier='" & Compta.CleCompta & "' And PlCpt='" & nCompte & "' And PlActi='" & nActivite & "'").Length = 0 Then
                'Ajout dans la base Agrifact
                Dim rwnPl As DataRow = ds.Tables("PlanComptable").NewRow
                With rwnPl
                    .Item("PlDossier") = Compta.CleCompta
                    .Item("PlCpt") = nCompte
                    .Item("PlActi") = nActivite
                End With
                ds.Tables("PlanComptable").Rows.Add(rwnPl)

                If FrApplication.Modules.ModuleCompta Then
                    If Not Me.LienCompta Is Nothing Then
                        Me.LienCompta.Ajout_PlanComptable(Compta.CleCompta, nCompte, nActivite, True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AjoutNouveauCompte(ByVal param As ParametresCompte)
        Me.AjoutNouveauCompte(param.nCompte, param.NActivite, param.LibCompte, param.U1, param.U2)
    End Sub

    Private Sub AjoutNouveauCompte(ByVal nCompte As String, ByVal nActivite As String, ByVal LibelleCompte As String, Optional ByVal U1 As String = "", Optional ByVal U2 As String = "")
        If bdM.Position <> -1 Then
            If ds.Tables("Comptes").Select("CDossier='" & Compta.CleCompta & "' And CCpt='" & nCompte & "'").Length = 0 Then
                'Ajout dans la base Agrifac
                Dim rwNC As DataRow = ds.Tables("Comptes").NewRow
                With rwNC
                    .Item("CDossier") = Compta.CleCompta
                    .Item("CCpt") = nCompte
                    .Item("CLib") = LibelleCompte
                    .Item("CU1") = U1
                    .Item("CU2") = U2
                End With
                ds.Tables("Comptes").Rows.Add(rwNC)

                If FrApplication.Modules.ModuleCompta Then
                    If Not Me.LienCompta Is Nothing Then
                        Me.LienCompta.Ajout_Compte(Compta.CleCompta, nCompte, LibelleCompte, U1, U2, True)
                    End If
                End If

                'Vérif exist acti
                AjoutNouvelleActivite(nActivite, "ACTIVITE " & nActivite, "", "")
                AjoutPlanComptable(nCompte, nActivite)
            End If
        End If
    End Sub

    Private Sub AjoutNouvelleActivite(ByVal param As ParametresActivite)
        Me.AjoutNouvelleActivite(param.nActivite, param.LibActivite, param.Qte1, param.U1)
    End Sub

    Private Sub AjoutNouvelleActivite(ByVal nActivite As String, ByVal LibActivite As String, ByVal Qte1 As String, ByVal Unite As String)
        If bdM.Position <> -1 Then
            If ds.Tables("Activites").Select("ADossier='" & Compta.CleCompta & "' And AActi='" & nActivite & "'").Length = 0 Then
                'Ajout dans la base Agrifac
                Dim rwNC As DataRow = ds.Tables("Activites").NewRow
                With rwNC
                    .Item("ADossier") = Compta.CleCompta
                    .Item("AActi") = nActivite
                    .Item("ALib") = LibActivite
                    If Qte1 <> "" Then
                        .Item("AQte") = Qte1
                    End If
                    .Item("AUnit") = Unite
                End With
                ds.Tables("Activites").Rows.Add(rwNC)

                If FrApplication.Modules.ModuleCompta Then
                    If Not Me.LienCompta Is Nothing Then
                        Me.LienCompta.Ajout_Activite(Compta.CleCompta, nActivite, LibActivite, True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AjoutComptes(ByVal ChampsCompte As String, ByVal ChampsActivite As String, ByVal Filtre As String)
        If bdM.Position <> -1 Then
            Dim rwv As DataRowView = CType(bdM.Current, DataRowView)

            Dim Param As New ParametresCompte
            With Param
                .nCompte = Convert.ToString(rwv.Item(ChampsCompte))
                .LibCompte = Convert.ToString(rwv.Item(LibelleCompta))
                If rwv.Row.Table.Columns.Contains("Unite1") Then
                    .U1 = Convert.ToString(rwv.Item("Unite1"))
                End If
                If rwv.Row.Table.Columns.Contains("Unite2") Then
                    .U2 = Convert.ToString(rwv.Item("Unite2"))
                End If
                .NActivite = "0000"
            End With

            With New FrCompte(Param, bdM, Filtre)
                If .ShowDialog = DialogResult.OK Then
                    Me.AjoutNouveauCompte(Param)
                    With Param
                        rwv.Item(ChampsCompte) = .nCompte
                        rwv.Item(ChampsActivite) = .NActivite
                        If rwv.Row.Table.Columns.Contains("Unite1") Then
                            rwv.Item("Unite1") = .U1
                        End If
                        If rwv.Row.Table.Columns.Contains("Unite2") Then
                            rwv.Item("Unite2") = .U2
                        End If
                    End With
                    rwv.EndEdit()
                End If
            End With
        End If
    End Sub

    Private Sub AjoutActivites(ByVal ChampsActivite As String, ByVal Filtre As String)
        If bdM.Position <> -1 Then
            Dim rwv As DataRowView = CType(bdM.Current, DataRowView)

            Dim Param As New ParametresActivite
            With Param
                .nActivite = Convert.ToString(rwv.Item(ChampsActivite))
                If rwv.Row.Table.Columns.Contains("Unite1") Then
                    .U1 = Convert.ToString(rwv.Item("Unite1"))
                End If
            End With

            With New FrActivite(Param, bdM, Filtre)
                If .ShowDialog = DialogResult.OK Then
                    Me.AjoutNouvelleActivite(Param)
                    rwv.Item(ChampsActivite) = Param.nActivite
                    rwv.EndEdit()
                End If
            End With
        End If
    End Sub
#End Region

#Region " Delegates pour evenements GestionControles"
    Public Sub VerifValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If bdM.Position = -1 Then Exit Sub

        Dim strTag As String = CStr(CType(sender, Control).Tag)
        Dim rw As DataRowView = CType(bdM.Current, DataRowView)
        If strTag.IndexOf("NCompte") = 0 Or strTag.IndexOf("NActivite") = 0 Then
            Dim champCompte As String = strTag.Replace("Activite", "Compte")
            Dim champActivite As String = strTag.Replace("Compte", "Activite")

            Dim strCompte As String = Convert.ToString(rw.Item(champCompte))
            Dim strActivite As String = Convert.ToString(rw.Item(champActivite))

            'Valeur d'activité en fonction du compte (vide si compte pas renseigné, 0 si compte renseigné et pas activité)
            If strCompte = "" Then
                strActivite = ""
                rw.Item(champCompte) = DBNull.Value
                rw.Item(champActivite) = DBNull.Value
            Else
                If strActivite = "" Then
                    strActivite = "0000"
                    rw.Item(champActivite) = strActivite
                End If
            End If

            'Si compte et activité sont renseignés, on ajoute au plan comptable
            If CType(sender, Control).Text <> "" And strCompte <> "" And strActivite <> "" Then
                AjoutNouveauCompte(strCompte, strActivite, "COMPTE " & strCompte)
            End If
        End If
    End Sub

    Public Sub AfficheNewPerso(ByVal sender As Object, ByVal strType As String)
        If Not (strType = "Comptes" Or strType = "Activites") Then Exit Sub

        'Récupérer le paramètrage
        Dim lst As Hashtable
        If TypeOf CType(sender, Control).Tag Is Hashtable Then
            lst = CType(CType(sender, Control).Tag, Hashtable)
        End If
        Dim strChampsCompte As String = ""
        Dim strChampsActivite As String = ""
        Dim Filtre As String = ""
        If Not lst Is Nothing Then
            If lst.Contains("Champs") Then
                strChampsCompte = Convert.ToString(lst("Champs")).Replace("Activite", "Compte")
                strChampsActivite = Convert.ToString(lst("Champs")).Replace("Compte", "Activite")
                Filtre = Convert.ToString(lst("FiltreType"))
            End If
        End If

        'Appeler la bonne méthode en fonction du type
        Select Case strType
            Case "Comptes"
                AjoutComptes(strChampsCompte, strChampsActivite, Filtre)
            Case "Activites"
                AjoutActivites(strChampsActivite, Filtre)
        End Select
    End Sub
#End Region

#Region " Classe Exploitation pour lecture des paramètres AgrigestEDI "
    Public Class Exploitation

#Region "Props"
        Private _codeExpl As String
        <XmlAttributeAttribute()> _
        Public Property CodeExpl() As String
            Get
                Return _codeExpl
            End Get
            Set(ByVal value As String)
                _codeExpl = value
            End Set
        End Property

        Private _nom As String
        <XmlAttributeAttribute()> _
        Public Property Nom() As String
            Get
                Return _nom
            End Get
            Set(ByVal value As String)
                _nom = value
            End Set
        End Property

        Private _cheminBase As String
        Public Property CheminBase() As String
            Get
                Return _cheminBase
            End Get
            Set(ByVal value As String)
                _cheminBase = value
            End Set
        End Property

        Private _cheminBasePlanType As String
        Public Property CheminBasePlanType() As String
            Get
                Return _cheminBasePlanType
            End Get
            Set(ByVal value As String)
                _cheminBasePlanType = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Display() As String
            Get
                Return String.Format("{0} - {1}", Me.CodeExpl, Me.Nom)
            End Get
        End Property

#End Region

#Region "Gestion XML"
        Public Shared Function LoadFromFile(ByVal path As String) As Exploitation()
            Dim sr As IO.StreamReader
            Try
                sr = New IO.StreamReader(path, True)
                Return LoadFromTextReader(sr)
            Finally
                If Not sr Is Nothing Then sr.Close()
            End Try
        End Function

        Public Shared Function LoadFromString(ByVal s As String) As Exploitation()
            Dim sr As IO.StringReader
            Try
                sr = New IO.StringReader(s)
                Return LoadFromTextReader(sr)
            Finally
                If Not sr Is Nothing Then sr.Close()
            End Try
        End Function

        Private Shared Function LoadFromTextReader(ByVal s As IO.TextReader) As Exploitation()
            Dim res As Exploitation()
            Dim xser As New XmlSerializer(GetType(Exploitation()))
            res = DirectCast(xser.Deserialize(s), Exploitation())
            Return res
        End Function
#End Region
    End Class
#End Region

End Class