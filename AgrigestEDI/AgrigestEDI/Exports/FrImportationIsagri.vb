Imports AgrigestEDI.Interfaces.IsAgri

Public Class FrImportationIsagri

    Private Const CODEPAGE_DOS As Integer = 850
    Private Const CODEPAGE_WIN As Integer = 0

    Private worker As System.ComponentModel.BackgroundWorker

#Region "Page"
    Private Sub FrRestauration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel2.Height
            .BringToFront()
            .Visible = False
        End With
        With cboFormatFichier
            With .Items
                .Clear()
                .Add(New ListboxItem("(Automatique)", -1))
                .Add(New ListboxItem("Dos", CODEPAGE_DOS))
                .Add(New ListboxItem("Windows", CODEPAGE_WIN))
            End With
            .SelectedIndex = 0
        End With
        TxNomFichier.Text = ""
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        With RestDlg
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                TxNomFichier.Text = .FileName
            End If
        End With
    End Sub

    Private Sub BtImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRestaurer.Click
        If TxNomFichier.Text.Trim.Length = 0 Then Exit Sub
        'Vérifie l'existence du fichier
        Dim fichierImport As String = TxNomFichier.Text
        If Not IO.File.Exists(fichierImport) Then
            MsgBox(String.Format(My.Resources.Strings.FichierIntrouvable, IO.Path.GetFileName(fichierImport)))
        Else
            Importer(fichierImport)
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ExportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs)
        ReportProgress(e.Percent, e.Status)
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
        If worker IsNot Nothing AndAlso worker.WorkerReportsProgress Then
            If status Is Nothing Then
                worker.ReportProgress(percent)
            Else
                worker.ReportProgress(percent, status)
            End If
        End If
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = Convert.ToString(status)
            Application.DoEvents()
        End If
        Me.pgBar.Value = percent
    End Sub

    Private Sub ResetAdapters()
        'Dossiers
        Me.ExploitationsTableAdapter = New dbSauvRestTableAdapters.ExploitationsTableAdapter
        Me.DossiersTableAdapter = New dbSauvRestTableAdapters.DossiersTableAdapter
        'Plan Comptable
        Me.ActivitesTableAdapter = New dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New dbSauvRestTableAdapters.ComptesTableAdapter
        Me.PlanComptableTableAdapter = New dbSauvRestTableAdapters.PlanComptableTableAdapter
        'Pieces
        Me.PiecesTableAdapter = New dbSauvRestTableAdapters.PiecesTableAdapter
        Me.LignesTableAdapter = New dbSauvRestTableAdapters.LignesTableAdapter
        Me.MouvementsTableAdapter = New dbSauvRestTableAdapters.MouvementsTableAdapter
        'Plan Type
        Me.PlanTypeTableAdapter = New dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
        Me.RicaTableAdapter = New dsPLCTableAdapters.RicaTableAdapter
    End Sub

    Private Sub SetAdaptersTransaction(ByVal t As OleDb.OleDbTransaction)
        'Dossiers
        Me.ExploitationsTableAdapter.SetTransaction(t)
        Me.DossiersTableAdapter.SetTransaction(t)
        'Plan Comptable
        Me.ActivitesTableAdapter.SetTransaction(t)
        Me.ComptesTableAdapter.SetTransaction(t)
        Me.PlanComptableTableAdapter.SetTransaction(t)
        'Pieces
        Me.PiecesTableAdapter.SetTransaction(t)
        Me.LignesTableAdapter.SetTransaction(t)
        Me.MouvementsTableAdapter.SetTransaction(t)
    End Sub

    Private Function TrouverExploitation(ByVal nExpl As String) As Exploitation
        Dim ConfigExpl As Exploitation = Exploitation.TrouverByImport(nExpl)
        If ConfigExpl IsNot Nothing AndAlso My.Settings.Exploitation IsNot Nothing _
        AndAlso My.Settings.Exploitation.CodeExpl = ConfigExpl.CodeExpl Then
            'On est déjà sur la bonne exploitation, pas de manips à faire
            ConfigExpl = My.Settings.Exploitation
            ConfigExpl.CodeExplImport = nExpl
        Else
            If ConfigExpl Is Nothing Then
                'NOUVELLE EXPLOITATION
                ConfigExpl = New Exploitation
                With ConfigExpl
                    .CodeExpl = Exploitation.ConstruireCodeExpl(nExpl)
                    .CreerBase()
                    .CheminBasePlanType = My.Settings.CheminBaseConfig
                End With
            End If
            ConfigExpl.CodeExplImport = nExpl
            'ON SE POSITIONNE SUR LA BONNE BASE
            ConfigExpl.Choisir()
            'ON A GAGNE LE DROIT DE REINITIALISER LES DATAADAPTERS
            ResetAdapters()
        End If
        Return ConfigExpl
    End Function

    Public Sub Importer(ByVal fichierImport As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        Me.worker = worker
        Dim prevExpl As Exploitation = My.Settings.Exploitation
        Dim dsImportation As New dbSauvRest
        Dim ConfigExpl As Exploitation
        Dim sDossier As String = ""

        Cursor.Current = Cursors.WaitCursor
        GradientPanel2.Enabled = False
        PanProgress.Visible = True
        Application.DoEvents()
        Try
            Try
                ReportProgress(0, My.Resources.Strings.Initialisation)

                Dim codePage As Integer = -1
                If cboFormatFichier.SelectedItem IsNot Nothing Then
                    codePage = CInt(CType(cboFormatFichier.SelectedItem, ListboxItem).Value)
                End If
                If codePage = -1 Then
                    Select Case IO.Path.GetExtension(fichierImport).ToUpper
                        Case ".ISA" : codePage = CODEPAGE_DOS
                        Case ".ECR" : codePage = CODEPAGE_WIN
                        Case Else : codePage = CODEPAGE_WIN
                    End Select
                End If

                Dim sVersion As String = GetVersionFichier(fichierImport)
                'charge l'expression régulière en fonction de la version du fichier
                Dim formats As GestionFormatFichierIsagri.FormatFichierIsagri = GestionFormatFichierIsagri.FormatFichierIsagri.ChargerFormatFichierIsagri(sVersion)
                If formats Is Nothing Then
                    MsgBox(String.Format(My.Resources.Strings.Import_FormatECRInconnu, IO.Path.GetFileName(fichierImport)), MsgBoxStyle.Critical, "Importation")
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Exit Sub
                End If

                Dim rxDOS As New System.Text.RegularExpressions.Regex(formats.FormatsLigne("DOS").ToString, System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                Dim rxEXO As New System.Text.RegularExpressions.Regex(formats.FormatsLigne("EXO").ToString, System.Text.RegularExpressions.RegexOptions.ExplicitCapture)


                'parcours les première ligne pour récupérer le nom du dossier et de l'exploitation pour faire un préchargement
                'des donnée existantes
                Using fs As New System.IO.FileStream(fichierImport, IO.FileMode.Open, IO.FileAccess.Read)
                    Using sR As New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding(codePage))
                        Dim sM As String = sR.ReadLine
                        While sM IsNot Nothing
                            Select Case Microsoft.VisualBasic.Left(sM, 6).Trim
                                Case "DOS"
                                    Dim nExpl As String = rxDOS.Match(sM).Groups("Exploitation").Value.Trim
                                    ConfigExpl = TrouverExploitation(nExpl)
                                Case "EXO"
                                    Dim Valeurs As System.Text.RegularExpressions.GroupCollection = rxEXO.Match(sM).Groups
                                    Dim DateDebEx As Date = GetDate(Valeurs("DateDebEx").Value)
                                    Dim DateFinEx As Date = GetDate(Valeurs("DateFinEx").Value)

                                    'Retrouver le dossier en fonction du code exploitation et des dates d'exercice
                                    Dim dtDossier As New dbDonneesDataSet.DossiersDataTable
                                    Using dta As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                                        dta.FillByExpl(dtDossier, ConfigExpl.CodeExpl)
                                    End Using
                                    Dim xRowListDossier() As dbDonneesDataSet.DossiersRow = DirectCast(dtDossier.Select(String.Format("DDtDebEx=#{0:MM/dd/yyyy}# AND DDtFinEx=#{1:MM/dd/yyyy}#", DateDebEx, DateFinEx)), dbDonneesDataSet.DossiersRow())
                                    If xRowListDossier.Length > 0 Then
                                        sDossier = xRowListDossier(0).DDossier
                                    End If

                                    ChargerDonneesDossier(dsImportation, ConfigExpl.CodeExpl, sDossier)
                                    Exit While
                                Case "ECR"
                                    'Cas ou on n'a pas de ligne EXO
                                    'Prendre le dernier dossier dispo pour l'exploitation
                                    Dim dtDossier As New dbDonneesDataSet.DossiersDataTable
                                    Using dta As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                                        dta.FillByExpl(dtDossier, ConfigExpl.CodeExpl)
                                    End Using
                                    Dim xRowListDossier() As dbDonneesDataSet.DossiersRow = DirectCast(dtDossier.Select("", "DDtFinEx desc"), dbDonneesDataSet.DossiersRow())
                                    If xRowListDossier.Length > 0 Then
                                        sDossier = xRowListDossier(0).DDossier
                                    Else
                                        Throw New ApplicationException("Aucun dossier correspondant n'a été trouvé.")
                                    End If
                                    ChargerDonneesDossier(dsImportation, ConfigExpl.CodeExpl, sDossier)
                                    Exit While
                            End Select
                            sM = sR.ReadLine
                        End While
                    End Using
                End Using

                'importation des données du fichier dans le dataset
                Dim Import As New Importateur
                AddHandler Import.ImportProgressed, AddressOf ExportProgressed
                If Not Import.Importer(dsImportation, fichierImport, sVersion, ConfigExpl.CodeExpl, codePage) Then
                    Throw New ApplicationException("Import echoué")
                End If

                'vérifie que le chargement s'est bien fait
                If dsImportation.Tables Is Nothing OrElse dsImportation.Tables.Count = 0 Then
                    Throw New ApplicationException(My.Resources.Strings.Import_FichierVide)
                End If

                ReportProgress(0, My.Resources.Strings.EnregistrementDesDonnees)

                'passe chaque dossier pour qu'il soit sauvegardé et mis à disposition via le fichier xml
                For Each drDossier As dbSauvRest.DossiersRow In dsImportation.Dossiers
                    sDossier = drDossier.DDossier
                    My.User.CurrentPrincipal = New DossierPrincipal(drDossier, drDossier.ExploitationsRow)
                    'Récupérer le nom de l'exploitation tel qu'importé
                    ConfigExpl.Nom = dsImportation.Exploitations.Rows(0)("ENom1").ToString
                    'regénère le plan comptable si celui ci n'est pas bon
                    ReportProgress(0, "Vérification du plan comptable")
                    GenererPlanComptable(dsImportation, sDossier)
                    'sauvegarde en base
                    ReportProgress(0, "Enregistrement des données")
                    SaveData(dsImportation, True, drDossier.DExpl, sDossier)
                    'permet de refaire les base HT des comptes TVA (on a besoin que les données soient déjà en bases pour utiliser les objets Piece)
                    ReportProgress(0, "Calcul des bases HT des lignes de TVA")
                    GenerateBaseHT()
                    'Enlever l'exploitation XML qui eventuellement existait déjà
                    Exploitation.Enlever(drDossier.DExpl)
                    'Enregister la liste XML des exploitations
                    Exploitation.Ajouter(ConfigExpl)
                Next

                ReportProgress(100)
                If IO.File.Exists(fichierImport & ".erreur") Then
                    LongMessageBox.ShowMessage("L'importation a réussi avec les avertissements suivants :", My.Computer.FileSystem.ReadAllText(fichierImport & ".erreur"), "Importation", MsgBoxStyle.Information)
                Else
                    MsgBox(My.Resources.Strings.Import_Succes, MsgBoxStyle.Information, "Importation")
                End If

                If prevExpl Is Nothing OrElse prevExpl.CodeExpl <> My.Settings.Exploitation.CodeExpl Then
                    Me.DialogResult = DialogResult.Retry
                Else
                    Me.DialogResult = DialogResult.OK
                End If
            Catch ex As Exception
                LogException(ex)
                If MsgBox(My.Resources.Strings.Import_RecapProblemes & vbCrLf & _
                ex.Message & vbCrLf & My.Resources.Strings.EnregistrerRapport, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                    With ErrorDlg
                        .DefaultExt = "txt"
                        .Filter = "Fichiers texte (*.txt)|*.txt"
                        .FileName = "Rapport d'erreur importation compta.txt"
                        If .ShowDialog = DialogResult.OK Then
                            My.Computer.FileSystem.WriteAllText(.FileName, ex.Message + vbCrLf + ex.StackTrace, False)
                            Process.Start(.FileName)
                        End If
                    End With
                End If
                'on se remet sur l'exploitation précédente pour rétablir les chemins aux bases
                If prevExpl IsNot Nothing Then prevExpl.Choisir()
                Me.DialogResult = DialogResult.Cancel
            End Try
            Me.Close()
        Finally
            PanProgress.Visible = False
            Cursor.Current = Cursors.Default
            GradientPanel2.Enabled = True
        End Try
    End Sub

    Private Sub ChargerDonneesDossier(ByVal ds As dbSauvRest, ByVal sExpl As String, ByVal sDossier As String)
        ReportProgress(0, String.Format(My.Resources.Strings.ChargementDesDonnees, sDossier))
        'chargement des données existantes
        If sDossier <> "" Then
            'Exploitation
            Me.ExploitationsTableAdapter.FillByExploitation(ds.Exploitations, sExpl)
            ReportProgress(1)
            'Dossier
            Me.DossiersTableAdapter.FillByDossier(ds.Dossiers, sDossier)
            ReportProgress(2)
            Me.ActivitesTableAdapter.FillByDossier(ds.Activites, sDossier)
            ReportProgress(5)
            Me.ComptesTableAdapter.FillByDossier(ds.Comptes, sDossier)
            ReportProgress(10)
            Me.PlanComptableTableAdapter.FillByDossier(ds.PlanComptable, sDossier)
            ReportProgress(20)
            Me.PiecesTableAdapter.FillByDossier(ds.Pieces, sDossier)
            ReportProgress(40)
            Me.LignesTableAdapter.FillByDossier(ds.Lignes, sDossier)
            ReportProgress(65)
            Me.MouvementsTableAdapter.FillByDossier(ds.Mouvements, sDossier)
            ReportProgress(100)
        End If
    End Sub

    Private Sub SaveData(ByVal dsRestauration As DataSet, ByVal bDelete As Boolean, ByVal sExploitation As String, ByVal sDossier As String)
        Dim t As OleDb.OleDbTransaction
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Try
                conn.Open()
                t = conn.BeginTransaction
                SetAdaptersTransaction(t)
                ReportProgress(2)

                If bDelete Then
                    DeleteExistingData(t, sExploitation, sDossier)
                End If
                ReportProgress(10)

                If ExecuteScalarInt(String.Format("SELECT count(*) FROM Exploitations WHERE EExpl='{0}'", sExploitation), t) = 0 Then
                    ForceDataAdapter.ForceInsert(Me.ExploitationsTableAdapter.GetDataAdapter, dsRestauration)
                Else
                    ForceDataAdapter.ForceUpdate(Me.ExploitationsTableAdapter.GetDataAdapter, dsRestauration)
                End If
                ReportProgress(11)

                If ExecuteScalarInt(String.Format("SELECT count(*) FROM Dossiers WHERE DDossier = '{0}' AND DExpl='{1}'", sDossier, sExploitation), t) = 0 Then
                    ForceDataAdapter.ForceInsert(Me.DossiersTableAdapter.GetDataAdapter, dsRestauration)
                Else
                    ForceDataAdapter.ForceUpdate(Me.DossiersTableAdapter.GetDataAdapter, dsRestauration)
                End If
                ReportProgress(12)
                ForceDataAdapter.ForceInsert(Me.ActivitesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(15)
                ForceDataAdapter.ForceInsert(Me.ComptesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(20)
                ForceDataAdapter.ForceInsert(Me.PlanComptableTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(30)
                ForceDataAdapter.ForceInsert(Me.PiecesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(45)
                ForceDataAdapter.ForceInsert(Me.LignesTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(60)
                ForceDataAdapter.ForceInsert(Me.MouvementsTableAdapter.GetDataAdapter, dsRestauration)
                ReportProgress(90)
                t.Commit()
                ReportProgress(95)
                conn.Close()
            Catch ex As OleDb.OleDbException
                t.Rollback()
                LogException(ex, TraceEventType.Critical)
                Throw New ApplicationException(ex.Message, ex)
            End Try
        End Using
    End Sub

    Private Sub DeleteExistingData(ByRef t As OleDb.OleDbTransaction, ByVal sExploitation As String, ByVal sDossier As String)
        SupprimerLignes("Mouvements", "MDossier", sDossier, t)
        SupprimerLignes("Lignes", "LDossier", sDossier, t)
        SupprimerLignes("Pieces", "PDossier", sDossier, t)
        SupprimerLignes("PlanComptable", "PlDossier", sDossier, t)
        SupprimerLignes("Activites", "ADossier", sDossier, t)
        SupprimerLignes("Comptes", "CDossier", sDossier, t)
    End Sub

    ''' <summary>
    ''' générateur de plan comptable ou MAJ de celui ci s'il en manque
    ''' </summary>
    ''' <param name="dsImport"></param>
    ''' <param name="sDossier"></param>
    ''' <remarks></remarks>
    Private Sub GenererPlanComptable(ByRef dsImport As dbSauvRest, ByVal sDossier As String)
        'Récupère les comptes et les activités de la table mouvement source en retirant les comptes et activités déjà dans la table plan comptable de la destination
        Dim dtNewData() As DataRow = dsImport.Mouvements.Select(String.Format("MDossier='{0}'", sDossier), "MCpt,MActi")
        'Charger le plan type
        Dim dtaTypeCompte As dbDonneesDataSet.PlanTypeDataTable = Me.PlanTypeTableAdapter.GetData
        Dim dtaTypeActivite As dsPLC.RicaDataTable = Me.RicaTableAdapter.GetData
        Dim prec As String = ""
        Dim i As Integer = 0
        For Each drMouv As DataRow In dtNewData
            ReportProgress(i * 100 \ dtNewData.Length) : i += 1
            Dim couple As String = String.Format("{0}/{1}", drMouv("MCpt"), drMouv("MActi"))
            If couple <> prec Then
                prec = couple
                Dim sCompte As String = Convert.ToString(drMouv("MCpt"))
                Dim sActivite As String = Convert.ToString(drMouv("MActi"))
                'vérifie que le couple Cpt/Act existe
                If dsImport.PlanComptable.Select(String.Format("PlDossier='{0}' AND PlCpt='{1}' AND PlActi='{2}'", sDossier, drMouv("MCpt"), drMouv("MActi"))).Length = 0 Then
                    'vérifie si le compte existe et le créer au besoin
                    If dsImport.Comptes.Select(String.Format("CDossier='{0}' AND CCpt='{1}'", sDossier, drMouv("MCpt"))).Length = 0 Then
                        Dim drCptType As DataRow = SelectSingleRow(dtaTypeCompte, "'{0}' LIKE PlARacine+'*'", drMouv("MCpt"))
                        If drCptType Is Nothing Then Exit Sub
                        Dim xRowCompte As dbSauvRest.ComptesRow = dsImport.Comptes.NewComptesRow
                        With xRowCompte
                            .CDossier = sDossier
                            .CCpt = sCompte
                            .CLib = Microsoft.VisualBasic.Left(drCptType("PlALib").ToString, 30)
                            .CU1 = Convert.ToString(drCptType("PlAU1"))
                            .CU2 = Convert.ToString(drCptType("PlAU2"))
                        End With
                        dsImport.Comptes.AddComptesRow(xRowCompte)
                    End If
                    'vérifie si l'activité existe et la créer au besoin
                    If dsImport.Activites.Select(String.Format("ADossier='{0}' AND AActi='{1}'", sDossier, drMouv("MActi"))).Length = 0 Then
                        If Convert.ToString(drMouv("MActi")) = "0000" Then
                            Dim xRowActi As dbSauvRest.ActivitesRow = dsImport.Activites.NewActivitesRow
                            With xRowActi
                                .ADossier = sDossier
                                .AActi = sActivite
                                .ALib = My.Resources.Strings.ACTIVITEGENERALE
                                .AUnit = ""
                            End With
                            dsImport.Activites.AddActivitesRow(xRowActi)
                        Else
                            Dim xActiviteTypeRow As DataRow = SelectSingleRow(dtaTypeActivite, "RiCode='{0}'", drMouv("MActi"))
                            If xActiviteTypeRow Is Nothing Then Exit Sub
                            Dim xRowActi As dbSauvRest.ActivitesRow = dsImport.Activites.NewActivitesRow
                            With xRowActi
                                .ADossier = sDossier
                                .AActi = Convert.ToString(drMouv("MActi"))
                                .ALib = Microsoft.VisualBasic.Left(xActiviteTypeRow("RiLib1").ToString, 25)
                                .AUnit = Microsoft.VisualBasic.Left(xActiviteTypeRow("RiUnite").ToString, 25)
                            End With
                            dsImport.Activites.AddActivitesRow(xRowActi)
                        End If
                    End If
                    'implémente la création de la ligne dans le plan comptable pour le compte et l'activité
                    dsImport.PlanComptable.AddPlanComptableRow(sDossier, sCompte, sActivite, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' permet de générer les base HT de toutes les lignes TVA pour chaque pièce
    ''' </summary>
    Private Sub GenerateBaseHT()
        'Fait appel à la base de données
        Dim ListPiece As New ListOfPieces
        ListPiece.Charger()

        Dim dtTVA As dbDonneesDataSet.TVADataTable
        Using dt As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dtTVA = dt.GetData
        End Using
        Try
            Dim nb As Integer = 1
            For Each xPiece As Piece In ListPiece
                ReportProgress(nb * 100 \ ListPiece.Count) : nb += 1
                Dim modif As Boolean = False
                'Faire un récap TVA de la pièce
                Dim RecapsTVA As Dictionary(Of String, Piece.RecapTva) = xPiece.GetTableTVA(dtTVA)

                'Pour chaque code TVA
                For Each sCodeTVA As String In RecapsTVA.Keys
                    'Dim xRowTemp As DataRow = dtTVA.Select("TTVA='" + sCodeTVA + "'")(0)
                    'Dim sCompteTvaACloturer As String = xRowTemp("TCpt").ToString

                    'Trouver combien de lignes de TVA on a et lister les montants HT
                    Dim nbCompteTva As Integer = 0
                    'On espère qu'il n'y a pas de HT qui nous echappe là
                    Dim montantsHT As New List(Of Decimal)
                    For Each xLigne As Ligne In xPiece.Lignes
                        If xLigne.CodeTVACompte = sCodeTVA Then
                            nbCompteTva += 1
                        ElseIf xLigne.CodeTva = sCodeTVA Then
                            montantsHT.Add(xLigne.MontantCre.GetValueOrDefault(0) + xLigne.MontantDeb.GetValueOrDefault(0))
                        End If
                    Next

                    If nbCompteTva = 0 Then
                        'Pas de ligne de TVA : On fait rien du tout
                    ElseIf nbCompteTva = 1 OrElse montantsHT.Count > nbCompteTva Then
                        'Si plus de lignes de HT (ou pas du tout) que de lignes de TVA, on répartis également le total HT
                        For Each xLigne As Ligne In xPiece.Lignes
                            If xLigne.CodeTVACompte = sCodeTVA Then
                                xLigne.MontantBaseHT = RecapsTVA(sCodeTVA).GetValeurHT(CStr(IIf(xLigne.MontantDeb.HasValue, "D", "C"))) / nbCompteTva
                                modif = True
                            End If
                        Next
                    Else 'Si moins de lignes de HT que de lignes de TVA, on affecte seulement aux premières (0 pour les autres)
                        Dim i As Integer = 0
                        For Each xLigne As Ligne In xPiece.Lignes
                            If xLigne.CodeTVACompte = sCodeTVA Then
                                If i < montantsHT.Count Then
                                    xLigne.MontantBaseHT = montantsHT(i)
                                    i += 1
                                Else
                                    xLigne.MontantBaseHT = 0
                                End If
                                modif = True
                            End If
                        Next
                    End If
                Next
                If modif Then xPiece.MAJPiece()
            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "Méthodes partagées"
    Private Shared Function GetVersionFichier(ByVal fichierImport As String) As String
        'récupère la version du fichier d'import
        Dim rxVersion As New System.Text.RegularExpressions.Regex("VER   (?<Version>.{7})", System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
        Dim fs As New System.IO.FileStream(fichierImport, IO.FileMode.Open, IO.FileAccess.Read)
        Dim sR As New System.IO.StreamReader(fs)
        Dim sM As String = sR.ReadLine
        Dim sVersion As String = ""
        Do Until sM = ""
            Select Case Microsoft.VisualBasic.Left(sM, 6).Trim
                Case "VER"
                    sVersion = rxVersion.Match(sM).Groups("Version").Value.Trim
                    Exit Do
            End Select
            sM = sR.ReadLine
        Loop
        Return sVersion
    End Function
#End Region

End Class