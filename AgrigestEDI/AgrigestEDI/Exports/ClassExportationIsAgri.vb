'DONE Gestion pointage TVA sur chargement/enregistrement de ligne
'TODO Gestion pointage TVA sur sauvegarde/resto
'DONE Gestion pointage TVA sur export Isa
'TODO Faire une vérif des codes TVA inconnus à l'import

Imports System.Text.RegularExpressions
Imports System.Data.OleDb

Namespace Interfaces.IsAgri

    Public Enum ActionDossier
        AddEcritures
        ResetDossier
        Skip
    End Enum

    Public Class Importateur
        Public Event ImportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs)

#Region "Méthodes diverses"
        Public Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
            RaiseEvent ImportProgressed(Me, New ProgressEventArgs(percent, status))
        End Sub

        Public Function Importer(ByRef dsImport As dbSauvRest, ByVal fichier As String, ByVal sVersionFichier As String, ByVal codeExpl As String, Optional ByVal nCodePage As Integer = 0) As Boolean
            ReportProgress(0, My.Resources.Strings.Initialisation)

            'Chargement des données
            ReportProgress(0, My.Resources.Strings.ChargementDesDonnees)

            If Not IO.File.Exists(fichier) Then
                If MsgBox(String.Format(My.Resources.Strings.FichierIntrouvable, IO.Path.GetFileName(fichier)), MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then Return False
            End If

            Dim formats As New GestionFormatFichierIsagri.FormatFichierIsagri
            formats = GestionFormatFichierIsagri.FormatFichierIsagri.ChargerFormatFichierIsagri(sVersionFichier)


            Dim rxVER As New Regex(formats.FormatsLigne("VER"))
            Dim rxDOS As New Regex(formats.FormatsLigne("DOS"), RegexOptions.ExplicitCapture)
            Dim rxEXO As New Regex(formats.FormatsLigne("EXO"), RegexOptions.ExplicitCapture)
            Dim rxECR As New Regex(formats.FormatsLigne("ECR"), RegexOptions.ExplicitCapture)
            Dim rxMVT As New Regex(formats.FormatsLigne("MVT"), RegexOptions.ExplicitCapture)
            Dim rxANAMVT As New Regex(formats.FormatsLigne("ANAMVT"), RegexOptions.ExplicitCapture)
            Dim rxANA As New Regex(formats.FormatsLigne("ANA"))
            Dim rxCPT As New Regex(formats.FormatsLigne("CPT"))

            Dim Export As Export = Nothing
            Dim dossier As Dossier = Nothing
            Dim exo As Exercice = Nothing
            Dim ecr As Ecriture = Nothing
            Dim mvt As Mouvement = Nothing

            Dim bSkipDossier As Boolean = False

            Dim cptLignes As Integer = CompterLignes(fichier)

            Dim sExploitation As String = ""
            Dim sDossier As String = ""
            Dim sPiece As String = ""
            Dim nIndexDossier As Integer = -1
            Dim fs As New System.IO.FileStream(fichier, IO.FileMode.Open, IO.FileAccess.Read)
            Dim xEnc As System.Text.Encoding
            If nCodePage > 0 Then
                xEnc = System.Text.Encoding.GetEncoding(nCodePage)
            Else
                xEnc = System.Text.Encoding.Default
            End If
            Dim sR As New System.IO.StreamReader(fs, xEnc)
            Dim sM As String = sR.ReadLine

            Dim xRowExploitation As dbSauvRest.ExploitationsRow = Nothing
            Dim xRowDossier As dbSauvRest.DossiersRow = Nothing
            Dim xElementDossier As System.Text.RegularExpressions.GroupCollection

            Dim nLigne As Integer = 0
            While sM IsNot Nothing
                nLigne += 1 : ReportProgress(nLigne * 100 \ cptLignes)
                Try
                    Select Case Microsoft.VisualBasic.Left(sM, 6).Trim
                        Case "VER"
                            xElementDossier = rxVER.Match(sM).Groups
                            Export = New Export()
                        Case "DOS"
                            If Export Is Nothing Then
                                MsgBox(My.Resources.Strings.Import_ErreurLignes1, MsgBoxStyle.Information, My.Resources.Strings.Import_ErreurDImportation)
                                Return False
                            End If
                            dossier = New Dossier(sM, rxDOS)
                            If codeExpl IsNot Nothing Then
                                dossier.NumDossier = codeExpl
                            End If
                            Export.Dossiers.Add(dossier)
                            sExploitation = dossier.NumDossier
                            Export.sDossier = sExploitation
                        Case "EXO"
                            bSkipDossier = False
                            If dossier Is Nothing Then
                                MsgBox(My.Resources.Strings.Import_ErreurLignes2, MsgBoxStyle.Information, My.Resources.Strings.Import_ErreurDImportation)
                                Return False
                            End If
                            exo = New Exercice(sM, rxEXO)
                            ecr = Nothing
                            mvt = Nothing
                            Dim dtDossier As New dbSauvRest.DossiersDataTable
                            Using dta As New dbSauvRestTableAdapters.DossiersTableAdapter
                                dta.FillByExpl(dtDossier, dossier.NumDossier)
                            End Using
                            Dim nouveauDossier As Boolean = False
                            Dim xRowListDossier() As dbSauvRest.DossiersRow = DirectCast(dtDossier.Select(String.Format("DDtDebEx=#{0:MM/dd/yyyy}# AND DDtFinEx=#{1:MM/dd/yyyy}#", exo.DateDebEx, exo.DateFinEx)), dbSauvRest.DossiersRow())
                            If xRowListDossier.Length > 0 Then
                                'L'exercice existe déjà
                                sDossier = xRowListDossier(0).DDossier
                            Else
                                'On crée l'exercice
                                sDossier = dossier.NumDossier + Microsoft.VisualBasic.Right(exo.DateDebEx.Year.ToString, 2)
                                Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                                    Dim bAjouter As Boolean = False
                                    Dim i As Integer = 65
                                    While Not bAjouter
                                        If CInt(dtadossier.ExistsDossier(dossier.NumDossier, sDossier)) = 0 Then
                                            bAjouter = True
                                        Else
                                            i += 1
                                            If i = 90 Then
                                                Throw New ApplicationException(My.Resources.Strings.Cloture_PlusDeCodeDispo)
                                            Else
                                                sDossier = dossier.NumDossier + Chr(i) + Microsoft.VisualBasic.Right(exo.DateFinEx.Year.ToString, 1)
                                            End If
                                        End If
                                    End While
                                End Using
                                nouveauDossier = True
                            End If
                            Export.sDossier = sDossier

                            'On demande à l'utilisateur quelle action d'import on doit effectuer
                            'SUPPRIME PAR JEREMIE LE 05/02/09
                            'Dim nActionDossier As FrImportDelete.ActionDossier = FrImportDelete.ActionDossier.AddEcritures
                            'Dim xElement As System.Text.RegularExpressions.GroupCollection = rxEXO.Match(sM).Groups
                            'If CInt(xElementDossier("Destruction").Value) = 1 Then
                            '    nActionDossier = FrImportDelete.ActionDossier.ResetDossier
                            'Else
                            '    nActionDossier = FrImportDelete.ActionDossier.AddEcritures
                            'End If
                            'Using fr As New FrImportDelete
                            '    fr.NouveauDossier = nouveauDossier
                            '    fr.Action = nActionDossier
                            '    fr.sDossier = sDossier
                            '    If fr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Function
                            '    nActionDossier = fr.Action
                            '    Application.DoEvents()
                            'End Using
                            Dim nActionDossier As ActionDossier = ActionDossier.ResetDossier
                            If Not nouveauDossier Then
                                Dim msg As String = String.Format("Le fichier contient des écritures pour l'exercice {0} du {1:dd/MM/yy} au {2:dd/MM/yy}" & vbCrLf & _
                                                                "Voulez-vous remplacer les donneés présentes sur cet ordinateur par celles contenues dans le fichier ?", sDossier, exo.DateDebEx, exo.DateFinEx)
                                If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then nActionDossier = ActionDossier.Skip
                            End If
                            If nActionDossier = ActionDossier.Skip Then
                                bSkipDossier = True
                            Else
                                If nActionDossier = ActionDossier.ResetDossier Then
                                    'Supprimer toutes les pièces existantes
                                    For Each xMouv As DataRow In dsImport.Mouvements.Select(String.Format("MDossier='{0}'", sDossier))
                                        dsImport.Mouvements.Rows.Remove(xMouv)
                                    Next
                                    For Each xLigne As DataRow In dsImport.Lignes.Select(String.Format("LDossier='{0}'", sDossier))
                                        dsImport.Lignes.Rows.Remove(xLigne)
                                    Next
                                    For Each xPiece As DataRow In dsImport.Pieces.Select(String.Format("PDossier='{0}'", sDossier))
                                        dsImport.Pieces.Rows.Remove(xPiece)
                                    Next
                                End If
                                dossier.Exercices.Add(exo)
                                exo.Activites.Add(New Activite("0000", My.Resources.Strings.ACTIVITEGENERALE, "", 0))
                                exo.Comptes.Add(New Compte("48800000", "COMPTE DE REPARTITION", "", "", "", ""))
                            End If
                        Case "ANA"
                            If bSkipDossier Then Exit Select
                            exo.Activites.Add(New Activite(sM, rxANA))
                        Case "CPT"
                            If bSkipDossier Then Exit Select
                            exo.Comptes.Add(New Compte(sM, rxCPT))
                        Case "ECR"
                            If bSkipDossier Then Exit Select
                            If exo Is Nothing Then
                                'Ca peut arriver sur les imports coop
                                exo = New Exercice
                                exo.ResetEcritures = False
                                With CType(dsImport.Dossiers.Rows(0), dbSauvRest.DossiersRow)
                                    sDossier = .DDossier
                                    exo.DateDebEx = .DDtDebEx
                                    exo.DateFinEx = .DDtFinEx
                                End With
                                dossier.Exercices.Add(exo)
                                'MsgBox(My.Resources.Strings.Import_ErreurLignes3, MsgBoxStyle.Information, My.Resources.Strings.Import_ErreurDImportation)
                                'Return False
                            End If
                            ecr = New Ecriture(sM, rxECR, exo.Ecritures)
                            mvt = Nothing
                            If Not ecr.ADetruire Then
                                'On n'ajoute pas les ecritures à détruire à la hiérarchie d'objets à importer comme ca on ne plante pas sur les lignes suivantes
                                'TODO Supprimer vraiment l'écriture dans la base ?
                                exo.Ecritures.Add(ecr)
                            End If
                        Case "MVT"
                            If bSkipDossier Then Exit Select
                            If ecr Is Nothing Then
                                MsgBox(My.Resources.Strings.Import_ErreurFichier, MsgBoxStyle.Information, My.Resources.Strings.Import_ErreurDImportation)
                                Return False
                            End If
                            'Dans certains fichiers (import coop), la ligne peut etre trop courte pour être reconnue par la regexp donc on s'assure qu'elle ait au moins la longueur minimum (159 caractères)
                            sM = sM.PadRight(159)
                            mvt = New Mouvement(sM, rxMVT)
                            ecr.Mouvements.Add(mvt)
                        Case "ANAMVT"
                            If bSkipDossier Then Exit Select
                            If mvt Is Nothing Then
                                MsgBox(My.Resources.Strings.Import_ErreurFichier, MsgBoxStyle.Information, My.Resources.Strings.Import_ErreurDImportation)
                                Return False
                            End If
                            mvt.Activites.Add(New MvtActivite(sM, rxANAMVT))
                    End Select
                    sM = sR.ReadLine
                Catch ex As Exception
                    LogMessage(sM)
                    Throw New Exception(ex.Message, ex)
                End Try
            End While
            sR.Close()
            fs.Close()

            ReportProgress(0, "Vérification des numéros de pièce...")
            Export.ReaffectationNumPieceAnormal(dsImport, sDossier)

            Try
                ReportProgress(20, "Chargement du plan type...")
                Dim dsType As New dsPLC
                Using dt As New dsPLCTableAdapters.PlanTypeTableAdapter
                    dt.Fill(dsType.PlanType)
                End Using
                ReportProgress(30, "Mise en forme des données...")
                Export.FillDataSetImport(dsImport, dsType, sExploitation, sDossier, fichier)
            Catch ex As Exception
                Throw New ApplicationException(My.Resources.Strings.Import_ErreurFichier, ex)
            End Try
            Return True
        End Function
#End Region

    End Class

    Public Class Exportateur
        Public Enum ModeExportation
            Delimite
            TailleFixe
        End Enum

        Public Event ExportProgressed(ByVal sender As Object, ByVal e As ProgressEventArgs)

#Region "Méthodes diverses"
        Public Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
            RaiseEvent ExportProgressed(Me, New ProgressEventArgs(percent, status))
        End Sub

        Public Sub Exporter(ByVal nExpl As String, ByVal nDossier As String, ByVal fichier As String, Optional ByVal options As OptionsExport = Nothing)
            ReportProgress(0, My.Resources.Strings.Initialisation)

            Dim dtExport As Date = Now
            Dim rapportErreur As New System.Text.StringBuilder

            'Eventuellement, prendre les options par défaut
            If options Is Nothing Then options = New OptionsExport(True, "Test d'export au format IsAgri")

            'Chargement des données
            ReportProgress(0, My.Resources.Strings.ChargementDesDonnees)
            Dim dsSource As New dbSauvRest
            Using dta As New dbSauvRestTableAdapters.ExploitationsTableAdapter
                dta.FillByExploitation(dsSource.Exploitations, nDossier.Substring(0, 6))
            End Using
            ReportProgress(20)
            Using dta As New dbSauvRestTableAdapters.DossiersTableAdapter
                dta.FillByDossier(dsSource.Dossiers, nDossier)
            End Using
            ReportProgress(40)
            Using dta As New dbSauvRestTableAdapters.PiecesTableAdapter
                dta.FillByDossier(dsSource.Pieces, nDossier)
            End Using
            ReportProgress(60)
            Using dta As New dbSauvRestTableAdapters.LignesTableAdapter
                dta.FillByDossier(dsSource.Lignes, nDossier)
            End Using
            ReportProgress(80)
            Using dta As New dbSauvRestTableAdapters.MouvementsTableAdapter
                dta.FillByDossier(dsSource.Mouvements, nDossier)
            End Using
            ReportProgress(100)


            'VER
            Dim export As New Export(options)

            'DOS
            Dim rwDossier As dbSauvRest.DossiersRow = dsSource.Dossiers.FindByDDossier(nDossier)
            Dim rwExpl As dbSauvRest.ExploitationsRow = rwDossier.ExploitationsRow
            Dim dossier As New Dossier(rwExpl)
            If nExpl IsNot Nothing Then dossier.NumDossier = nExpl
            export.Dossiers.Add(dossier)

            'EXO
            Dim exo As New Exercice(rwDossier, options)
            dossier.Exercices.Add(exo)

            'ANA
            If options.ExporterActivites Then
                ReportProgress(0, My.Resources.Strings.Export_ExportActi)
                Dim i As Integer = 0
                Dim rwsAct() As dbSauvRest.ActivitesRow = CType(dsSource.Activites.Select(String.Format("ADossier='{0}'", nDossier)), dbSauvRest.ActivitesRow())
                For Each rwAct As dbSauvRest.ActivitesRow In rwsAct
                    exo.Activites.Add(New Activite(rwAct))
                    i += 1 : ReportProgress(i * 100 \ rwsAct.Length)
                Next
            End If

            'CPT
            If options.ExporterPlanCpt Then
                ReportProgress(0, My.Resources.Strings.Export_ExportPLC)
                Dim rwsPlc() As dbSauvRest.PlanComptableRow = CType(dsSource.PlanComptable.Select(String.Format("PlDossier='{0}'", nDossier), "PlCpt"), dbSauvRest.PlanComptableRow())
                Dim prec As String = ""
                Dim i As Integer = 0
                For Each rwPlc As dbSauvRest.PlanComptableRow In rwsPlc
                    If rwPlc.PlCpt <> prec Then 'un compte peut etre défini plusieurs fois dans le PLC
                        prec = rwPlc.PlCpt
                        exo.Comptes.Add(New Compte(rwPlc.ComptesRowParent))
                        i += 1 : ReportProgress(i * 100 \ rwsPlc.Length)
                    End If
                Next
            End If

            'TVA
            If options.ExporterTVA Then
                'ReportProgress(0, My.Resources.Strings.Export_ExportTVA)
                'Dim i As Integer = 0
                'Dim rwsTva() As DataRow = dsSource.Tables("TVA").Select()
                'For Each rwTva As dbSauvRest.TVARow In rwsTva
                '    exo.TVAs.Add(New TVA(rwTva))
                '    i += 1 : ReportProgress(i * 100 \ rwsTva.Length)
                'Next
            End If

            'JOU
            If options.ExporterJournaux Then
                'Générer des écritures "A Nouveau" à partir du PLC ?
            End If

            'ECR
            If options.ExporterPieces Then
                ReportProgress(0, My.Resources.Strings.Export_ExportPieces)
                Dim i As Integer = 0
                'Ne prendre que les pièces non déjà exportées
                Dim rwsPieces() As dbSauvRest.PiecesRow
                If options.ForcerExportFullPieces Then
                    rwsPieces = CType(dsSource.Pieces.Select(String.Format("PDossier='{0}'", nDossier)), dbSauvRest.PiecesRow())
                Else
                    rwsPieces = CType(dsSource.Pieces.Select(String.Format("PDossier='{0}' And (Exporte is null OR Exporte=0)", nDossier)), dbSauvRest.PiecesRow())
                End If
                For Each rwPiece As dbSauvRest.PiecesRow In rwsPieces
                    Try
                        Dim ecr As Ecriture = Nothing
                        'Chaque piece = 1 ecriture
                        For Each rwLigne As dbSauvRest.LignesRow In rwPiece.GetLignesRows
                            'Dim codeJournalLigne As Ecriture.CodeJournaux = Ecriture.DeterminerCodeJournal(rwLigne.LJournal, Ecriture.DeterminerCptBanque(rwLigne.GetMouvementsRows))
                            If ecr Is Nothing Then 'Premiere ligne de la piece, on crée l'ecriture
                                ecr = New Ecriture(rwPiece)
                                'Else 'Sur chaque autre ligne, on valide que le journal reste le même
                                '    ecr.ArbitrerCodeJournal(codeJournalLigne)
                            End If

                            For Each rwMvt As dbSauvRest.MouvementsRow In rwLigne.GetMouvementsRows
                                If Not rwMvt.MCpt.StartsWith("488") Then
                                    'AndAlso Not (rwMvt.MMtCre = 0 And rwMvt.MMtDeb = 0) Then ' Viré par JS le 30/04/10 pour permettre d'exporter des lignes de TVA à 0%
                                    ecr.Mouvements.Add(New Mouvement(rwLigne, rwMvt))
                                End If
                            Next
                        Next
                        If ecr IsNot Nothing Then
                            'Vérif des règles d'intégrité de la pièce
                            ecr.VerifIntegrite()
                            'Consolidation de la TVA
                            'ecr.ConsolidationTVA()
                            'On n'ajoute l'ecriture à l'export que si tout s'est bien passé
                            exo.Ecritures.Add(ecr)
                        End If
                        'Marquer la pièce comme exportée
                        rwPiece("Exporte") = True
                        rwPiece("DateExport") = dtExport.Date
                    Catch ex As ApplicationException
                        'On logue l'erreur et on passe à la pièce suivante
                        rapportErreur.AppendFormat("- {0}" & vbCrLf, ex.Message)
                    End Try
                    i += 1 : ReportProgress(i * 100 \ rwsPieces.Length)
                Next
            End If

            If export.Dossiers.Count = 0 _
            OrElse CType(export.Dossiers(0), Dossier).Exercices.Count = 0 _
            OrElse CType(CType(export.Dossiers(0), Dossier).Exercices(0), Exercice).Ecritures.Count = 0 Then
                rapportErreur.AppendLine(My.Resources.Strings.Export_AucuneEcrExportee)
            End If

            If rapportErreur.Length > 0 Then
#If DEBUG Then
                'Exporter dans le fichier
                ReportProgress(0, My.Resources.Strings.EcritureDuFichier)
                export.Exporter(fichier, ";", options.ModeExportation)
#End If
                Throw New ApplicationException(rapportErreur.ToString)
            Else
                'Exporter dans le fichier
                ReportProgress(0, My.Resources.Strings.EcritureDuFichier)
                export.Exporter(fichier, ";", options.ModeExportation)
            End If

            'Enregistrer les modifs
            Me.MettreAJourInfosExport(dsSource.Pieces)
        End Sub

        Private Sub MettreAJourInfosExport(ByVal piecesDT As dbSauvRest.PiecesDataTable)
            Dim n As Integer = 0

            ReportProgress(0, My.Resources.Strings.EnregistrementDesDonnees)

            Try
                Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                    oleDbConn.Open()

                    Dim oleDbTran As OleDbTransaction = Nothing

                    oleDbTran = oleDbConn.BeginTransaction()

                    Try
                        Using dta As New dbSauvRestTableAdapters.PiecesTableAdapter
                            dta.SetTransaction(oleDbTran)

                            For Each piecesDR As dbSauvRest.PiecesRow In piecesDT.Rows
                                Dim exporte As Boolean = Nothing
                                Dim dateExport As Date = Nothing

                                If Not (piecesDR.IsExporteNull) Then
                                    exporte = piecesDR.Exporte
                                Else
                                    exporte = Nothing
                                End If

                                If Not (piecesDR.IsDateExportNull) Then
                                    dateExport = piecesDR.DateExport
                                Else
                                    dateExport = Nothing
                                End If

                                dta.UpdateInfosExport(exporte, dateExport, piecesDR.PDossier, piecesDR.PPiece, piecesDR.PDate)

                                n += 1 : ReportProgress(n * 100 \ piecesDT.Rows.Count)
                            Next
                        End Using

                        oleDbTran.Commit()
                    Catch ex As Exception
                        If Not (oleDbTran Is Nothing) Then
                            oleDbTran.Rollback()
                        End If
                    End Try
                End Using
            Catch ex As Exception
                Throw New ApplicationException("Erreur lors de la mise à jour des informations d'export des pièces : " & ex.Message, ex)
            End Try

            ReportProgress(100)
        End Sub
#End Region

    End Class

#Region "Classes util pour export"
    Public Class OptionsExport
        Public ModeExportation As Exportateur.ModeExportation = Exportateur.ModeExportation.TailleFixe
        Public TitreExport As String
        Public ExporterActivites As Boolean = True
        Public ExporterPlanCpt As Boolean = True
        Public ExporterTVA As Boolean = False
        Public ExporterJournaux As Boolean = False
        Public ExporterPieces As Boolean = True
        Public ForcerExportFullPieces As Boolean = True

#Region "Constructeurs"
        Public Sub New(ByVal ForceExportFullPiece As Boolean, Optional ByVal titre As String = "", Optional ByVal mode As Exportateur.ModeExportation = Exportateur.ModeExportation.TailleFixe, Optional ByVal expAct As Boolean = False, Optional ByVal expCpt As Boolean = False, Optional ByVal expTva As Boolean = False, Optional ByVal expJour As Boolean = False, Optional ByVal expPieces As Boolean = True)
            Me.ModeExportation = mode
            Me.TitreExport = titre
            Me.ExporterActivites = expAct
            Me.ExporterPlanCpt = expCpt
            Me.ExporterTVA = expTva
            Me.ExporterJournaux = expJour
            Me.ExporterPieces = expPieces
            ForcerExportFullPieces = ForceExportFullPiece
        End Sub
#End Region
    End Class

    Public Class ModeleExport
#Region "Méthodes diverses"
        Public Overridable Function GetFormat() As String
            Return ""
        End Function

        Public Overridable Function GetFields() As Object()
            Return New Object() {}
        End Function

        Public Overridable Function GetSubItems() As ArrayList
            Return New ArrayList
        End Function

        Public Sub Exporter(ByVal tw As IO.TextWriter, ByVal sep As String, ByVal mode As Exportateur.ModeExportation)
            If mode = Exportateur.ModeExportation.Delimite Then
                EcrireLigneSep(tw, sep, GetFields)
            Else
                EcrireLigneFormat(tw, GetFormat, GetFields)
            End If
            For Each item As ModeleExport In GetSubItems() : item.Exporter(tw, sep, mode) : Next
        End Sub
#End Region
    End Class

    Public Class Export
        Inherits ModeleExport

        Public Const DEVISE As String = "EUR"

        Private Const FORMAT As String = "{0,-6}{1,-7}{2,-4}{3,1}{4,-30}{5,1}"
        Private Const FLAG As String = "VER"
        Public VersIsaCompta As String = "0200000"
        Public Zone As String = "0000"
        Public ResetDossier As Boolean = False
        Public LibFichier As String
        Public AnsiEncoding As Boolean = True
        Public Dossiers As New ArrayList
        Public sDossier As String

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal Opt As OptionsExport)
            Me.New()
            Me.LibFichier = Left(Opt.TitreExport, 30)
            ResetDossier = Opt.ForcerExportFullPieces
        End Sub

        'Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
        '    Me.New()
        'End Sub
#End Region

#Region "Méthodes diverses"
        Public Overloads Sub Exporter(ByVal fichier As String, ByVal sep As String, ByVal mode As Exportateur.ModeExportation)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
            Exporter(sw, sep, mode)
            sw.Close()
        End Sub

        Public Overloads Sub LogErreur(ByVal fichier As String, ByVal sLigneErreur As String)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, True, System.Text.Encoding.Default)
            sw.WriteLine(sLigneErreur)
            sw.Close()
        End Sub

        Public Overloads Sub Exporter(ByVal sb As System.Text.StringBuilder, ByVal sep As String, ByVal mode As Exportateur.ModeExportation)
            Exporter(New IO.StringWriter(sb), sep, mode)
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, VersIsaCompta, Zone, ResetDossier, LibFichier, AnsiEncoding}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Dossiers
        End Function

        Public Sub FillDataSetImport(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sExploitation As String, ByVal sDossier As String, ByVal sFichier As String)
            For Each xDossier As Dossier In Me.Dossiers
                If dsImport.Exploitations.Count = 0 Then
                    dsImport.Exploitations.AddExploitationsRow(xDossier.GetExploitationRow(dsImport, dsPlanType, sExploitation, sDossier, sFichier))
                Else
                    xDossier.GetExploitationRow(dsImport, dsPlanType, sExploitation, sDossier, sFichier)
                End If
            Next
        End Sub

        Public Sub ReaffectationNumPieceAnormal(ByVal dsImport As dbSauvRest, ByVal sDossier As String)
            For Each xDossier As Dossier In Me.Dossiers
                xDossier.ReaffectationNumPieceAnormal_Exploitation(dsImport, sDossier)
            Next
        End Sub
#End Region

    End Class

    Public Class Dossier
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-8}{2,-30}{3,8}{4,1}{5,1}{6,1}{7,1}{8,1}{9,1}{10,-2}{11,1}{12,-3}{13,1}"
        Private Const FLAG As String = "DOS"
        Public NumDossier As String
        Public LibDossier As String
        Public DateCloture As Date
        Public MajAnal As Boolean = True
        Public MajCpt As Boolean = True
        Public MajJournaux As Boolean = True
        Public MajTVA As Boolean = True
        Public TailleComptes As Integer
        Public Exercices As New ArrayList

#Region "Constructeurs"
        Public Sub New()
            Me.TailleComptes = 8
        End Sub

        Public Sub New(ByVal rwExpl As dbSauvRest.ExploitationsRow)
            Me.New()
            With Me
                .NumDossier = CInt(Mid(rwExpl.EExpl, 2, 5)).ToString
                .LibDossier = Left(rwExpl.ENom1, 30)
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            With Me
                Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                .NumDossier = "C" + xElement("Exploitation").Value.Trim.PadLeft(5, "0"c)
                .LibDossier = xElement("Nom1").Value.TrimEnd.TrimStart
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetExploitationRow(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sExploitation As String, ByVal sDossier As String, ByVal sFichier As String) As dbSauvRest.ExploitationsRow
            Dim xRow As dbSauvRest.ExploitationsRow = dsImport.Exploitations.NewExploitationsRow
            xRow.EExpl = Me.NumDossier
            xRow.ENom1 = Me.LibDossier
            xRow.EType = "A"
            For Each xExo As Exercice In Me.Exercices
                xExo.GetDossierRow(dsImport, dsPlanType, sExploitation, sDossier, sFichier)
            Next
            Return xRow

        End Function

        Public Sub ReaffectationNumPieceAnormal_Exploitation(ByVal dsImport As dbSauvRest, ByVal sDossier As String)
            For Each xExo As Exercice In Me.Exercices
                xExo.ReaffectationNumPieceAnormal_Dossier(dsImport, sDossier)
            Next
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, NumDossier, LibDossier, DateCloture, MajAnal, MajCpt, MajJournaux, MajTVA, " ", " ", TailleComptes, " ", " ", " "}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Exercices
        End Function
#End Region

    End Class

    Public Class Exercice
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,8}{2,8}{3,1}{4,1}{5,-11}{6,-3}"
        Private Const FLAG As String = "EXO"
        Public DateDebEx As Date
        Public DateFinEx As Date
        Public ResetEcritures As Boolean = False
        Public Devise As String
        Public Activites As New ArrayList
        Public Comptes As New ArrayList
        Public TVAs As New ArrayList
        Public Journaux As New ArrayList
        Public Ecritures As New ArrayList

#Region "Constructeurs"
        Public Sub New()
            Me.Devise = Export.DEVISE
        End Sub

        Public Sub New(ByVal rwDossier As dbSauvRest.DossiersRow, ByVal Opt As OptionsExport)
            Me.New()
            With Me
                .DateDebEx = rwDossier.DDtDebEx
                .DateFinEx = rwDossier.DDtFinEx
                .ResetEcritures = Opt.ForcerExportFullPieces
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            With Me
                Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                .DateDebEx = GetDate(xElement("DateDebEx").Value)
                .DateFinEx = GetDate(xElement("DateFinEx").Value)
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub GetDossierRow(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sExploitation As String, ByVal sDossier As String, ByVal sFichier As String)
            If dsImport.Dossiers.Select(String.Format("DDossier='{0}'", sDossier)).Length = 0 Then
                Dim xRow As dbSauvRest.DossiersRow = dsImport.Dossiers.NewDossiersRow
                xRow.DExpl = sExploitation
                xRow.DDossier = sDossier
                xRow.DDtDebEx = Me.DateDebEx
                xRow.DDtFinEx = Me.DateFinEx
                xRow.SetDDtArreteNull()
                dsImport.Dossiers.AddDossiersRow(xRow)
            End If
            For Each Act As Activite In Me.Activites
                Act.AddActivitesRow(dsImport, sDossier)
            Next

            For i As Integer = Me.Activites.Count - 1 To 0 Step -1
                If DirectCast(Me.Activites(i), Activite).CodeAct = "" Then
                    Me.Activites.RemoveAt(i)
                End If
            Next

            For Each Cpt As Compte In Me.Comptes
                Cpt.AddComptesRow(dsImport, dsPlanType, sDossier)
            Next

            For i As Integer = Me.Comptes.Count - 1 To 0 Step -1
                If DirectCast(Me.Comptes(i), Compte).NCompte = "" Then
                    Me.Comptes.RemoveAt(i)
                End If
            Next

            'IMPORTER LES PIECES
            For Each Ecr As Ecriture In Me.Ecritures
                Ecr.AddPiece(dsImport, dsPlanType, sDossier, CInt(Ecr.NumPiece), sFichier)
            Next

            Dim dtaPlanC As DataTable = AgriTools.SelectDistinct(dsImport.Mouvements, "MCpt", "MActi")

            For Each xRowMouv As DataRow In dtaPlanC.Rows
                If dsImport.PlanComptable.Select(String.Format("PlDossier='{0}' AND PlCpt='{1}' AND PlActi='{2}'", sDossier, Convert.ToString(xRowMouv("MCpt")), Convert.ToString(xRowMouv("MActi")))).Length = 0 And Convert.ToString(xRowMouv("MCpt")).Trim <> "" And Convert.ToString(xRowMouv("MActi")).Trim <> "" Then

                    Dim sLib As String = ""
                    Dim drPlACpt() As dsPLC.PlanTypeRow = DirectCast(dsPlanType.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", Convert.ToString(xRowMouv("MCpt")))), dsPLC.PlanTypeRow())
                    Dim drPlARica() As dsPLC.RicaRow = DirectCast(dsPlanType.Rica.Select(String.Format("RiCode='{0}'", Convert.ToString(xRowMouv("MActi")))), dsPLC.RicaRow())
                    If drPlACpt IsNot Nothing AndAlso drPlACpt.Length > 0 Then sLib += Convert.ToString(drPlACpt(0).Item("PlLib"))
                    If drPlARica IsNot Nothing AndAlso drPlARica.Length > 0 Then sLib += " - " + Convert.ToString(drPlARica(0).Item("RiLib1"))

                    Dim xRow As dbSauvRest.PlanComptableRow = dsImport.PlanComptable.NewPlanComptableRow
                    xRow.PlDossier = sDossier
                    xRow.PlCpt = Convert.ToString(xRowMouv("MCpt"))
                    xRow.PlActi = Convert.ToString(xRowMouv("MActi"))
                    xRow.PlLib = sLib
                    dsImport.PlanComptable.AddPlanComptableRow(xRow)
                End If
            Next
        End Sub

        Public Sub ReaffectationNumPieceAnormal_Dossier(ByVal dsImport As dbSauvRest, ByVal sDossier As String)
            Dim nNumMaxPieceBase As Integer = dsImport.Pieces.FindLastNumPiece(sDossier)
            Dim nNumMaxPieceFile As Integer = 0
            For Each Ecr As Ecriture In Me.Ecritures
                If IsNumeric(Ecr.NumPiece) AndAlso nNumMaxPieceFile < CInt(Ecr.NumPiece) Then
                    nNumMaxPieceFile = CInt(Ecr.NumPiece)
                End If
            Next
            nNumMaxPieceFile += 1
            For Each Ecr As Ecriture In Me.Ecritures
                If Ecr.NumPiece = "" OrElse Not IsNumeric(Ecr.NumPiece) Then
                    Ecr.NumPiece = nNumMaxPieceFile.ToString
                    nNumMaxPieceFile += 1
                End If
            Next
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, DateDebEx, DateFinEx, ResetEcritures, " ", " ", Devise}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Dim a As New ArrayList
            With a
                .AddRange(Activites)
                .AddRange(Comptes)
                .AddRange(TVAs)
                .AddRange(Journaux)
                .AddRange(Ecritures)
            End With
            Return a
        End Function
#End Region
    End Class

    Public Class Activite
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-6}{2,-2}{3,-40}{4,-6}{5,-5}{6,11:00000000.00}{7,1}{8,-5}{9,11:00000000.00}"
        Private Const FLAG As String = "ANA"
        Public CodeAct As String
        Public CodeDecoupe As String
        Public LibAct As String
        Public Unite1 As String
        Public Qte1 As Decimal
        Public Unite2 As String
        Public Qte2 As Decimal

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal rwAct As dbSauvRest.ActivitesRow)
            Me.New()
            With Me
                .CodeAct = Left(rwAct.AActi, 6)
                .LibAct = Left(rwAct.ALib, 40)
                .Unite1 = Left(rwAct.AUnit, 5)
                .Qte1 = CDec(rwAct.AQte)
            End With
        End Sub

        Public Sub New(ByVal sActivite As String, ByVal sLibelle As String, ByVal sUnite As String, ByVal sQte As Decimal)
            Me.New()
            With Me
                .CodeAct = Left(sActivite, 6)
                .LibAct = Left(sLibelle, 40)
                .Unite1 = Left(sUnite, 5)
                .Qte1 = sQte
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            With Me
                Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                .CodeAct = xElement("CodeAct").Value.Trim
                If Len(.CodeAct.Trim) <= 4 Then
                    .CodeAct = .CodeAct.PadRight(4, "0"c)
                ElseIf Len(.CodeAct.Trim) > 4 Then
                    .CodeAct = Right(.CodeAct, 4)
                End If
                .LibAct = Left(xElement("LibAct").Value.TrimStart, 20)
                .Unite1 = xElement("Unite1").Value.Trim
                If xElement("Qte1").Value.Trim <> "" Then
                    .Qte1 = DecimalParse(xElement("Qte1").Value).GetValueOrDefault
                End If
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub AddActivitesRow(ByRef dsImport As dbSauvRest, ByVal sDossier As String)
            If dsImport.Activites.Select(String.Format("ADossier='{0}' AND AActi='{1}'", sDossier, Me.CodeAct)).Length = 0 Then
                Dim xRow As dbSauvRest.ActivitesRow = dsImport.Activites.NewActivitesRow
                xRow.ADossier = sDossier
                xRow.AActi = Me.CodeAct
                xRow.ALib = Me.LibAct
                xRow.AQte = Me.Qte1
                xRow.AUnit = Left(Me.Unite1, 2)
                dsImport.Activites.AddActivitesRow(xRow)
            End If
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeAct, CodeDecoupe, LibAct, " ", Unite1, Qte1, " ", Unite2, Qte2}
        End Function
#End Region
    End Class

    Public Class Compte
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,10}{2,30}{3,-10}{4,-3}{5,-10}{6,-3}{7,-10}{8,1}{9,-3}{10,-2}{11,-7}{12,-10}" & _
                                        "{13,-10}{14,1}{15,-2}{16,-2}{17,1}{18,-10}{19,-10}{20,-10}{21,1}{22,1}{23,1}{24,-30}" & _
                                        "{25,4}{26,3}{27,1}{28,1}{29,1}{30,1}{31,1}{32,1}{33,1}{34,1}{35,1}{36,1}{37,-11}"
        Private Const FLAG As String = "CPT"
        Public NCompte As String
        Public LibCompte As String
        Public CodeAlpha As String
        Public Unite1 As String
        Public LibUnite1 As String
        Public Unite2 As String
        Public LibUnite2 As String
        Public NumAutorise As Boolean
        Public CodeLettrage As String
        Public TypeCompte As String
        Public Tiers As String
        Public CpteDeb As String
        Public CpteCred As String
        Public CentrGdLivre As Boolean
        Public SensSaisi As String
        Public CodeTva As String
        Public TvaAutorise As Boolean
        Public CpteRegroupement As String
        Public CpteLie As String
        Public Lettrable As Boolean
        Public NvxNonLettres As Boolean
        Public Pointable As Boolean
        Public LibMvt As String
        Public AffQte1 As Boolean
        Public AffQte2 As Boolean
        Public ArretTva As Boolean
        Public AffectationObligatoire As Boolean
        Public AffectationPossible As Boolean
        Public DeviseObligatoire As Boolean
        Public RemarquePresente As Boolean
        Public Revision As Boolean
        Public Visa As Boolean
        Public Cycle As Decimal

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal rwCpt As dbSauvRest.ComptesRow)
            Me.New()
            With Me
                .NCompte = Left(rwCpt.CCpt, 10)
                .LibCompte = Left(rwCpt.CLib, 30)
                .Unite1 = Left(Convert.ToString(rwCpt("CU1")), 3)
                .LibUnite1 = Left(Convert.ToString(rwCpt("CU1")), 10)
                .Unite2 = Left(Convert.ToString(rwCpt("CU2")), 3)
                .LibUnite2 = Left(Convert.ToString(rwCpt("CU2")), 10)
                .TypeCompte = "ge"
                .SensSaisi = "in"
                .TvaAutorise = True
                .Lettrable = True
                .AffQte1 = True
                .AffQte2 = True
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            With Me
                Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                .NCompte = Left(xElement("NCompte").Value.Trim, 8)
                .LibCompte = xElement("LibCompte").Value.TrimStart
                .Unite1 = xElement("Unite1").Value.Trim
                .LibUnite1 = xElement("LibUnite1").Value.TrimStart
                .Unite2 = xElement("Unite2").Value.Trim
                .LibUnite2 = xElement("LibUnite2").Value.TrimStart
            End With
        End Sub

        Public Sub New(ByVal sCompte As String, ByVal sLibelle As String, ByVal sUnite1 As String, ByVal sUnite1Lib As String, ByVal sUnite2 As String, ByVal sUnite2Lib As String)
            Me.New()
            With Me
                .NCompte = sCompte
                .LibCompte = sLibelle
                .Unite1 = sUnite1
                .LibUnite1 = sUnite1Lib
                .Unite2 = sUnite2
                .LibUnite2 = sUnite2Lib
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub AddComptesRow(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sDossier As String)
            If dsImport.Comptes.Select(String.Format("CDossier='{0}' AND CCpt='{1}'", sDossier, Me.NCompte)).Length = 0 Then
                Dim xRow As dbSauvRest.ComptesRow = dsImport.Comptes.NewComptesRow

                xRow.CDossier = sDossier
                xRow.CCpt = Me.NCompte

                Dim drPlACpt() As dsPLC.PlanTypeRow = DirectCast(dsPlanType.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", Left(Me.NCompte, 8))), dsPLC.PlanTypeRow())
                If drPlACpt IsNot Nothing AndAlso drPlACpt.Length > 0 Then
                    If Right(Me.LibCompte, 30) = "" Then
                        xRow.CLib = Convert.ToString(drPlACpt(0).Item("PlLib"))
                    Else
                        xRow.CLib = Right(Me.LibCompte, 30)
                    End If
                    If Right(Me.Unite1, 2) = "" Then
                        xRow.CU1 = Convert.ToString(drPlACpt(0).Item("PlU1"))
                    Else
                        xRow.CU1 = Right(Me.Unite1, 2)
                    End If
                    If Right(Me.Unite2, 2) = "" Then
                        xRow.CU2 = Convert.ToString(drPlACpt(0).Item("PlU2"))
                    Else
                        xRow.CU2 = Right(Me.Unite2, 2)
                    End If
                    xRow.C_DC = Convert.ToString(drPlACpt(0).Item("PlD_C"))
                Else
                    xRow.CLib = Right(Me.LibCompte, 30)
                    xRow.CU1 = Right(Me.Unite1, 2)
                    xRow.CU2 = Right(Me.Unite2, 2)
                End If

                dsImport.Comptes.AddComptesRow(xRow)

                Dim drPLC As dbSauvRest.PlanComptableRow = dsImport.PlanComptable.NewPlanComptableRow
                With drPLC
                    .PlDossier = sDossier
                    .PlCpt = xRow.CCpt
                    .PlActi = "0000"
                    .PlLib = xRow.CLib
                End With
                dsImport.PlanComptable.AddPlanComptableRow(drPLC)
            End If
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, NCompte, LibCompte, CodeAlpha, Unite1, LibUnite1, Unite2, LibUnite2, NumAutorise, _
                        CodeLettrage, TypeCompte, Tiers, CpteDeb, CpteCred, CentrGdLivre, SensSaisi, CodeTva, TvaAutorise, _
                        CpteRegroupement, "", CpteLie, Lettrable, NvxNonLettres, Pointable, LibMvt, "", "", 0, AffQte1, AffQte2, ArretTva, _
                        AffectationObligatoire, AffectationPossible, DeviseObligatoire, RemarquePresente, Revision, Visa, Cycle}
        End Function
#End Region

    End Class

#Region "TVA et JOURNAL non traités car faisant parti des plans étalons"
    'Public Class TVA
    '    Inherits ModeleExport

    '    Private Const FORMAT As String = "{0,-6}{1,-2}{2,-30}{3,-10}{4:00.00}{5,-2}{6,-2}{7,-5}{8,1}{9,1}{10:000.00}{11,-2}{12,1}"
    '    Private Const FLAG As String = "TVA"
    '    Public CodeTva As String
    '    Public LibTva As String
    '    Public Cpt As String
    '    Public Taux As Decimal
    '    Public Type As String
    '    Public Positionnement As String
    '    Public CodeEmplacment As String
    '    Public TvaSurEncaissement As Boolean
    '    Public Tva0 As Boolean
    '    Public TxDeduction As Decimal
    '    Public Classe As String
    '    Public TvaSurEncaissementCompta As Boolean

    '    Public Sub New()

    '    End Sub

    '    Public Sub New(ByVal rwTva As dbSauvRest.TVARow)
    '        Me.New()
    '        With Me
    '            .CodeTva = Left(rwTva.TTVA, 2)
    '            .LibTva = Left(rwTva.Libellé, 30)
    '            If rwTva.IsTCptNull Then
    '                .Cpt = ""
    '            Else
    '                .Cpt = rwTva.TCpt
    '            End If
    '            .Cpt = Left(.Cpt, 10)
    '            .Taux = CDec(rwTva.TTaux)
    '            Select Case rwTva.TTVA
    '                Case "I", "O", "S", "T"
    '                    .Type = "im"
    '                Case Else
    '                    Select Case rwTva.TJournal
    '                        Case "V" : .Type = "ve"
    '                        Case "A" : .Type = "ac"
    '                    End Select
    '            End Select
    '            Select Case rwTva.TCtrlCl_DC
    '                Case "C" : .Positionnement = "cr"
    '                Case "D" : .Positionnement = "de"
    '            End Select
    '            Select Case rwTva.TTVA
    '                Case "V1", "W1"
    '                    .TvaSurEncaissement = True
    '            End Select
    '        End With
    '    End Sub

    '    Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
    '        Me.New()
    '        With Me
    '            Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
    '            .CodeTva = xElement("CodeTva").Value
    '            .LibTva = xElement("LibTva").Value
    '            .Cpt = xElement("Cpt").Value
    '            If xElement("Taux").Value.Trim <> "" Then
    '                .Taux = CDec(xElement("Taux").Value)
    '            End If
    '            .Type = xElement("Type").Value
    '            .Positionnement = xElement("Positionnement").Value
    '            .TvaSurEncaissement = CBool(xElement("TvaSurEncaissement").Value)
    '        End With
    '    End Sub

    '    Public Overrides Function GetFormat() As String
    '        Return FORMAT
    '    End Function

    '    Public Overrides Function GetFields() As Object()
    '        Return New Object() {FLAG, CodeTva, LibTva, Cpt, Taux, Type, Positionnement, CodeEmplacment, TvaSurEncaissement, Tva0, TxDeduction, Classe, TvaSurEncaissementCompta}
    '    End Function
    'End Class

    'Public Class Journal
    '    Inherits ModeleExport

    '    Private Const FORMAT As String = "{0,-6}{1,-2}{2,-30}{3,-2}{4,-2}{5,-2}{6,-10}"
    '    Private Const FLAG As String = "JOU"
    '    Public CodeJournal As String
    '    Public LibJournal As String
    '    Public Type As String
    '    Public Classe As String = "mi"
    '    Public TypeExtourne As String
    '    Public CpteCtr As String

    '    Public Overrides Function GetFormat() As String
    '        Return FORMAT
    '    End Function

    '    Public Overrides Function GetFields() As Object()
    '        Return New Object() {FLAG, CodeJournal, LibJournal, Type, Classe, TypeExtourne, CpteCtr}
    '    End Function
    'End Class
#End Region

    Public Class Ecriture
        Inherits ModeleExport

        'Public Enum CodeJournaux
        '    Achat = 1
        '    Vente = 2
        '    Banque1 = 3
        '    Banque2 = 4
        '    Banque3 = 5
        '    Banque4 = 6
        '    Banque5 = 7
        '    Banque6 = 8
        '    Autre = 9
        'End Enum

        Private Const FORMAT As String = "{0,-6}{1:00}{2,8}{3,8}{4,-30}{5,-8}{6,-7}{7,-7}{8,-3}{9,-11}{10,1}{11,1}{12,8}" & _
                                        "{13,8}{14,-11}{15,1}{16,-3}{17,-2}{18,1}{19,-10}{20,1}{21,-11}{22,30}{23,3}{24,3}"
        Private Const FLAG As String = "ECR"
        Public CodeJournal As String
        Public DatePiece As Date
        Public NumPiece As String
        Public NumPieceImport As String
        Public LibEcr As String
        Public CodeSite As String
        Public CodeUtil As String
        Public CodeEmetteur As Integer = 1
        Public CodeEcriture As String
        Public NonModifiable As Boolean
        Public DateCreation As Date
        Public DateModif As Date
        Public ADetruire As Boolean
        Public Devise As String
        Public Type As String
        Public CptCtr As String
        Public NumModif As Integer

        Public Mouvements As New ArrayList

#Region "Constructeurs"
        Public Sub New()
            Me.Devise = Export.DEVISE
        End Sub

        Public Sub New(ByVal rwPiece As dbSauvRest.PiecesRow)
            Me.New()
            With Me
                If rwPiece.IsJournalNull Then
                    .CodeJournal = "09"
                Else
                    .CodeJournal = Left(Convert.ToString(rwPiece.Journal), 2)
                End If
                .DatePiece = rwPiece.PDate
                .NumPiece = Left(rwPiece.PPiece.ToString, 8)
                If Not rwPiece.IsLibelleNull Then .LibEcr = Left(rwPiece.Libelle, 30)
                .CodeSite = ""
                .CodeUtil = Left(Environment.MachineName.ToUpper, 7)
                .CodeEcriture = Left(String.Format("{0:ddMM}{1:00000}", .DatePiece, .NumPiece), 11)
                .NonModifiable = False
                .DateCreation = rwPiece.PDate
                .DateModif = rwPiece.PDate
                If Not rwPiece.IsPPieceImportNull AndAlso rwPiece.PPieceImport <> "" Then .NumPieceImport = rwPiece.PPieceImport
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex, ByVal Ecritures As ArrayList)
            Me.New()
            With Me
                Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                .CodeJournal = xElement("CodeJournal").Value
                .DatePiece = GetDate(xElement("DatePiece").Value)
                .ADetruire = (xElement("ADetruire").Value = "1")
                If IsNumeric(xElement("NumPiece").Value.Trim) Then
                    .NumPiece = xElement("NumPiece").Value.Trim
                    For Each xEcriture As Ecriture In Ecritures
                        If (xEcriture.NumPieceImport = .NumPieceImport Or xEcriture.NumPiece = .NumPiece) AndAlso xEcriture.DatePiece = .DatePiece Then
                            .NumPiece = ""
                        End If
                    Next

                End If
                .NumPieceImport = xElement("NumPiece").Value.Trim
                .LibEcr = xElement("Libelle").Value.TrimEnd.TrimStart
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub AddPiece(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sDossier As String, ByVal nNumPiece As Integer, ByVal sFichier As String)
            Try
                Dim xRowExist() As DataRow
                xRowExist = dsImport.Pieces.Select(String.Format("PDossier='{0}' AND PDate=#{2:MM/dd/yyyy}# AND PPiece='{1}'", sDossier, nNumPiece, Me.DatePiece))
                If xRowExist.Length > 0 Then

                    Me.LogErreur(sFichier + ".erreur", String.Format("La piece {1} existe déjà pour cet exercice " + _
                    vbCrLf + "Dossier : {0}, Piece : {1}, Date : {2}, Libelle : {3}, Journal : {4}, PieceImport : {5}", _
                    sDossier, nNumPiece, Me.DatePiece, Me.LibEcr, Me.CodeJournal, Me.NumPieceImport))
                Else
                    Dim xRow As dbSauvRest.PiecesRow = dsImport.Pieces.NewPiecesRow
                    xRow.PDossier = sDossier
                    xRow.PDate = Me.DatePiece
                    xRow.PPiece = nNumPiece
                    xRow.Libelle = Me.LibEcr
                    xRow.Journal = Me.CodeJournal
                    xRow.PPieceImport = Me.NumPieceImport
                    'xRow.SetDateExportNull()
                    'Une pièce importée est marquée exportée pour ne pas être renvoyée au comptable
                    xRow.DateExport = Today
                    xRow.Exporte = True
                    dsImport.Pieces.AddPiecesRow(xRow)
                    Dim i As Integer = 0
                    For Each Mouv As Mouvement In Me.Mouvements
                        Mouv.AddLigne(dsImport, dsPlanType, sDossier, Me.DatePiece, Me.CodeJournal, nNumPiece, i, False)
                        i += 1
                    Next
                End If

            Catch ex As Exception
                Throw New ApplicationException(ex.Message, ex)
            End Try

        End Sub

        Public Overloads Sub LogErreur(ByVal fichier As String, ByVal sLigneErreur As String)
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fichier)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(fichier))
            End If
            Dim sw As New IO.StreamWriter(fichier, True, System.Text.Encoding.Default)
            sw.WriteLine(sLigneErreur)
            sw.Close()
        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            If Me.NumPieceImport <> "" Then
                Return New Object() {FLAG, CodeJournal, DatePiece, NumPieceImport, LibEcr, "", CodeSite, CodeUtil, CodeEmetteur, _
                      CodeEcriture, "", NonModifiable, DateCreation, DateModif, 0, ADetruire, Devise, Type, 0, _
                      CptCtr, 0, NumModif, "", "", ""}
            Else
                Return New Object() {FLAG, CodeJournal, DatePiece, NumPiece, LibEcr, "", CodeSite, CodeUtil, CodeEmetteur, _
                            CodeEcriture, "", NonModifiable, DateCreation, DateModif, 0, ADetruire, Devise, Type, 0, _
                            CptCtr, 0, NumModif, "", "", ""}
            End If
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Return Mouvements
        End Function

        Public Sub VerifIntegrite()
            'Regle 1 : l'ecriture doit etre equilibrée : Total Crédit = Total Débit
            Dim totC As Decimal, totD As Decimal
            For Each mvt As Mouvement In Me.Mouvements
                totC += mvt.MontantC
                totD += mvt.MontantD
            Next
            If totC <> totD Then
                Throw New ApplicationException(String.Format(My.Resources.Strings.Import_ErreurEquilibre, Me.NumPiece, Me.DatePiece))
            End If
        End Sub

        Public Sub ConsolidationTVA()
            Dim hash As New Dictionary(Of String, Mouvement)
            Dim mvtToRemove As New ArrayList
            'Pour chaque mouvement de l'ecriture
            For Each mvt As Mouvement In Me.Mouvements
                'Si c'est un mouvement de TVA
                If Not mvt.CodeTvaCompte Is Nothing Then
                    Dim mvtConso As Mouvement
                    If hash.ContainsKey(mvt.CodeTvaCompte) Then
                        mvtConso = hash(mvt.CodeTvaCompte)
                    Else
                        mvtConso = New Mouvement
                        With mvtConso
                            .Compte = mvt.Compte
                            .CodeTvaCompte = mvt.CodeTvaCompte
                            .LibMvt = String.Format("{0} TVA {1}", Me.LibEcr, mvt.CodeTvaCompte).Trim
                        End With
                        hash.Add(mvt.CodeTvaCompte, mvtConso)
                    End If
                    mvtConso.MontantC += mvt.MontantC
                    mvtConso.MontantD += mvt.MontantD
                    mvtConso.Qte1 += mvt.Qte1
                    mvtConso.Qte2 += mvt.Qte2
                    mvtToRemove.Add(mvt)
                End If
            Next
            'Ajouter les mouvements consolidés à l'ecriture
            For Each mvt As Mouvement In hash.Values
                Me.Mouvements.Add(mvt)
            Next
            'Virer les mouvements originaux
            For Each mvt As Mouvement In mvtToRemove
                Me.Mouvements.Remove(mvt)
            Next
        End Sub

        'Public Shared Function DeterminerCptBanque(ByVal rwsMvt() As DataRow) As String
        '    For Each rw As DataRow In rwsMvt
        '        If Convert.ToString(rw("MCpt")).StartsWith("512") Then Return Convert.ToString(rw("MCpt"))
        '    Next
        '    Return ""
        'End Function

        'Public Shared Function DeterminerCodeJournal(ByVal journal As String, ByVal cptBanque As String) As CodeJournaux
        '    Dim res As CodeJournaux
        '    Select Case journal
        '        Case "A" : res = CodeJournaux.Achat
        '        Case "V" : res = CodeJournaux.Vente
        '        Case Else
        '            Select Case cptBanque
        '                Case "51211000" : res = CodeJournaux.Banque1
        '                Case "51212000" : res = CodeJournaux.Banque2
        '                Case "51221000" : res = CodeJournaux.Banque3
        '                Case "51222000" : res = CodeJournaux.Banque4
        '                Case "51231000" : res = CodeJournaux.Banque5
        '                Case "51232000" : res = CodeJournaux.Banque6
        '                Case Else : res = CodeJournaux.Autre
        '            End Select
        '    End Select
        '    Return res
        'End Function

        'Public Function DeterminerJournal(ByVal journal As CodeJournaux) As String
        '    Dim res As String
        '    Select Case journal
        '        Case CodeJournaux.Achat : res = "A"
        '        Case CodeJournaux.Vente : res = "V"
        '        Case CodeJournaux.Banque1 : res = "B"
        '        Case CodeJournaux.Banque2 : res = "C"
        '        Case CodeJournaux.Banque3 : res = "D"
        '        Case CodeJournaux.Banque4 : res = "E"
        '        Case CodeJournaux.Banque5 : res = "F"
        '        Case CodeJournaux.Banque6 : res = "G"
        '        Case Else : res = ""
        '    End Select
        '    Return res
        'End Function

        'Public Shared Function DeterminerLibelleEcriture(ByVal rwLigne As dbDonneesDataSet.LignesRow) As String
        '    Dim libEcr As String = rwLigne.LLib
        '    If libEcr.IndexOf("/"c) >= 0 Then
        '        libEcr = libEcr.Substring(0, libEcr.IndexOf("/"c))
        '    Else
        '        libEcr = ""
        '    End If
        '    Return libEcr.Trim
        'End Function
#End Region

#Region "ANCIENNE VERSION : ACHAT OU VENTE PRIORITAIRE SUR BANQUE"
        'Public Sub ArbitrerCodeJournal(ByVal nouveauCodeJournal As CodeJournaux)
        '    If Me.CodeJournal = nouveauCodeJournal Then Exit Sub
        '    'Existant   Nouveau => Resultat
        '    '------------------------------
        '    'ACHAT      VENTE   => Erreur
        '    'ACHAT      BANQUE  => ACHAT
        '    'ACHAT      AUTRE   => ACHAT

        '    'VENTE      ACHAT   => Erreur
        '    'VENTE      BANQUE  => VENTE
        '    'VENTE      AUTRE   => VENTE

        '    'BANQUE     ACHAT   => ACHAT
        '    'BANQUE     VENTE   => VENTE
        '    'BANQUE     BANQUE  => Erreur
        '    'BANQUE     AUTRE   => BANQUE

        '    'AUTRE      ACHAT   => ACHAT
        '    'AUTRE      VENTE   => VENTE
        '    'AUTRE      BANQUE  => BANQUE

        '    'Aucun problème si le nouveau code journal est AUTRE => code inchangé
        '    If nouveauCodeJournal = CodeJournaux.Autre Then Exit Sub

        '    Select Case Me.CodeJournal
        '        Case CodeJournaux.Achat, CodeJournaux.Vente
        '            Select Case nouveauCodeJournal
        '                Case CodeJournaux.Achat, CodeJournaux.Vente
        '                    'Une ligne d'ACHAT + une ligne de VENTE => Erreur
        '                    Throw New ApplicationException(String.Format("La pièce {0} du {1:dd/MM/yyyy} contient des lignes d'achat et de vente.", Me.NumPiece, Me.DatePiece))
        '                Case Else 'BANQUE
        '                    'ACHAT ou VENTE prioritaire sur tout => code inchangé
        '            End Select

        '        Case CodeJournaux.Autre
        '            'Tout code journal est prioritaire sur AUTRE
        '            Me.CodeJournal = nouveauCodeJournal

        '        Case Else 'BANQUE
        '            Select Case nouveauCodeJournal
        '                Case CodeJournaux.Achat, CodeJournaux.Vente
        '                    'ACHAT ou VENTE prioritaire sur BANQUE
        '                    Me.CodeJournal = nouveauCodeJournal
        '                Case Else 'BANQUE (différente de la BANQUE existante) => Erreur
        '                    Throw New ApplicationException(String.Format("La pièce {0} du {1:dd/MM/yyyy} concerne plusieurs trésoreries.", Me.NumPiece, Me.DatePiece))
        '            End Select
        '    End Select
        'End Sub
#End Region

        'NOUVELLE VERSION : BANQUE PRIORITAIRE SUR ACHAT OU VENTE 
        'Public Sub ArbitrerCodeJournal(ByVal nouveauCodeJournal As CodeJournaux)
        '    If Me.CodeJournal = nouveauCodeJournal Then Exit Sub
        '    'Existant   Nouveau => Resultat
        '    '------------------------------
        '    'A/V        V/A     => A/V (inchangé)
        '    'A/V        BANQUE  => BANQUE
        '    'A/V        AUTRE   => A/V

        '    'BANQUE     A/V     => BANQUE
        '    'BANQUE     BANQUE  => Erreur
        '    'BANQUE     AUTRE   => BANQUE

        '    'AUTRE      *       => *

        '    'Aucun problème si le nouveau code journal est AUTRE => code inchangé
        '    If nouveauCodeJournal = CodeJournaux.Autre Then Exit Sub

        '    Select Case Me.CodeJournal
        '        Case CodeJournaux.Autre
        '            'Tout code journal est prioritaire sur AUTRE
        '            Me.CodeJournal = nouveauCodeJournal

        '        Case CodeJournaux.Achat, CodeJournaux.Vente
        '            Select Case nouveauCodeJournal
        '                Case CodeJournaux.Achat, CodeJournaux.Vente
        '                    'Une ligne d'ACHAT + une ligne de VENTE => La première ligne est prioritaire : pas de changement
        '                    'Throw New ApplicationException(String.Format("La pièce {0} du {1:dd/MM/yyyy} contient des lignes d'achat et de vente.", Me.NumPiece, Me.DatePiece))
        '                Case Else 'BANQUE
        '                    'BANQUE prioritaire => changement du code
        '                    Me.CodeJournal = nouveauCodeJournal
        '            End Select

        '        Case Else 'BANQUE
        '            Select Case nouveauCodeJournal
        '                Case CodeJournaux.Achat, CodeJournaux.Vente
        '                    'BANQUE Prioritaire sur tout => Code inchangé
        '                Case Else 'BANQUE (différente de la BANQUE existante) => Erreur
        '                    Throw New ApplicationException(String.Format("La pièce {0} du {1:dd/MM/yyyy} concerne plusieurs trésoreries.", Me.NumPiece, Me.DatePiece))
        '            End Select
        '    End Select
        'End Sub

    End Class

    Public Class Mouvement
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,-10}{2,30}{3,13:#0.00}{4,13:#0.00}{5,11:#0.00}{6,11:#0.00}{7,-8}{8,2}{9,2}" & _
                                        "{10,1}{11,-3}{12,8}{13,4}{14,1}{15,8}{16,2}{17,2}{18,3}{19,5}{20,8}{21,8}"
        Private Const FLAG As String = "MVT"
        Public Compte As String
        Public LibMvt As String
        Public MontantD As Decimal
        Public MontantC As Decimal
        Public Qte1 As Decimal
        Public Qte2 As Decimal
        Public Numero As String
        Public CodeTva As String
        Public CodeTvaCompte As String
        Public FlagLettrage As Integer
        Public CodeLettrage As String
        Public DatePointage As Date
        Public NbAct As Integer
        Public HasEcheances As Boolean
        Public DateDeclaration As Date
        Public CodeTva2 As String
        Public CodeTva3 As String
        Public DateValeur As Date
        Public Activites As New ArrayList
        Public Echeances As New ArrayList

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal rwLigne As dbSauvRest.LignesRow, ByVal rwMvt As dbSauvRest.MouvementsRow)
            Me.New()
            With Me
                .Compte = Left(rwMvt.MCpt, 10)
                .LibMvt = Left(DeterminerLibelleMvt(rwLigne), 30)
                .MontantD = rwMvt.MMtDeb
                .MontantC = rwMvt.MMtCre
                If Not rwMvt.IsMQte1Null Then .Qte1 = rwMvt.MQte1
                If Not rwMvt.IsMQte2Null Then .Qte2 = rwMvt.MQte2

                Select Case rwMvt.MOrdre
                    Case 2
                        .CodeTvaCompte = Left(Convert.ToString(rwLigne.Item("LMtTva")), 2)
                    Case Else
                        .CodeTva = Left(Convert.ToString(rwLigne.Item("LTva")), 2)
                End Select

                If rwMvt.IsMLettrageNull OrElse String.IsNullOrEmpty(rwMvt.MLettrage) Then
                    .FlagLettrage = 0
                    .CodeLettrage = ""
                Else
                    .FlagLettrage = 1
                    .CodeLettrage = rwMvt.MLettrage
                End If
                'Association d'activité
                If Convert.ToString(rwMvt.Item("MActi")) <> "0000" Then
                    .NbAct = 1
                    .Activites.Add(New MvtActivite(rwMvt.MActi))
                End If
                'Infos de pointage à faire passer
                If Not rwLigne.IsDatePointageNull Then .DatePointage = rwLigne.DatePointage
                If Not rwLigne.IsDateDeclarationNull Then .DateDeclaration = rwLigne.DateDeclaration
                If Not rwLigne.IsDateValeurNull Then .DateValeur = rwLigne.DateValeur
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            Try
                With Me
                    Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                    .Compte = Left(xElement("Compte").Value.TrimEnd.TrimStart, 8)
                    .LibMvt = xElement("LibMvt").Value.TrimEnd.TrimStart

                    If xElement("MontantD").Value.Trim <> "" Then
                        .MontantD = DecimalParse(xElement("MontantD").Value.Trim).GetValueOrDefault
                    End If
                    If xElement("MontantC").Value.Trim <> "" Then
                        .MontantC = DecimalParse(xElement("MontantC").Value.Trim).GetValueOrDefault
                    End If
                    If xElement("Qte1").Value.Trim <> "" Then
                        .Qte1 = DecimalParse(xElement("Qte1").Value.Trim).GetValueOrDefault
                    End If
                    If xElement("Qte2").Value.Trim <> "" Then
                        .Qte2 = DecimalParse(xElement("Qte2").Value.Trim).GetValueOrDefault
                    End If
                    .CodeTva = xElement("CodeTva").Value.Trim
                    .CodeTvaCompte = xElement("CodeTvaCompte").Value.Trim
                    If xElement("FlagLettrage").Value <> "" And IsNumeric(xElement("FlagLettrage").Value) Then
                        .FlagLettrage = CInt(DecimalParse(xElement("FlagLettrage").Value.Trim).GetValueOrDefault)
                    End If
                    .CodeLettrage = xElement("CodeLettrage").Value.Trim
                    If xElement("DatePointage").Value.Trim.Length > 0 Then
                        .DatePointage = GetDate(xElement("DatePointage").Value)
                    End If
                    If xElement("NbAct").Value.Trim <> "" Then
                        .NbAct = CInt(DecimalParse(xElement("NbAct").Value.Trim).GetValueOrDefault)
                    End If
                    If xElement("DateDeclaration").Value.Trim.Length > 0 Then
                        .DateDeclaration = GetDate(xElement("DateDeclaration").Value)
                    End If
                    If xElement("DateValeur").Value.Trim.Length > 0 Then
                        .DateValeur = GetDate(xElement("DateValeur").Value)
                    End If
                End With
            Catch ex As Exception
                Throw New ApplicationException(String.Format("Problème d'import des données des mouvements du fichier ({0}) : ", sLigne) & ex.Message, ex)
            End Try
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub VerifCompte(ByRef dsImport As dbSauvRest, ByVal sDossier As String, ByVal sCompte As String, ByVal dsPlanType As dsPLC)
            If dsImport.Comptes.Select(String.Format("CDossier='{0}' AND CCpt='{1}'", sDossier, sCompte)).Length = 0 Then
                Dim drPlanType As dsPLC.PlanTypeRow = DirectCast(SelectSingleRow(dsPlanType.PlanType, "'{0}' like PlRacine+'*'", Left(sCompte, 8)), dsPLC.PlanTypeRow)
                Dim drCompte As dbSauvRest.ComptesRow = dsImport.Comptes.NewComptesRow
                With drCompte
                    .CDossier = sDossier
                    .CCpt = Left(sCompte, 8)
                    If drPlanType IsNot Nothing Then
                        .C_DC = Convert.ToString(drPlanType.Item("PlD_C"))
                        .CLib = Convert.ToString(drPlanType.Item("PlLib"))
                        .CU1 = Convert.ToString(drPlanType.Item("PlU1"))
                        .CU2 = Convert.ToString(drPlanType.Item("PlU2"))
                    End If
                End With
                dsImport.Comptes.AddComptesRow(drCompte)
            End If
        End Sub

        Private Sub VerifCompte(ByRef dsImport As dbSauvRest, ByVal sDossier As String, ByVal sCompte As String, ByVal CLib As String)
            If dsImport.Comptes.Select(String.Format("CDossier='{0}' AND CCpt='{1}'", sDossier, sCompte)).Length = 0 Then
                Dim drCompte As dbSauvRest.ComptesRow = dsImport.Comptes.NewComptesRow
                With drCompte
                    .CDossier = sDossier
                    .CCpt = Left(sCompte, 8)
                    .CLib = CLib
                End With
                dsImport.Comptes.AddComptesRow(drCompte)
            End If
        End Sub

        Public Sub AddLigne(ByRef dsImport As dbSauvRest, ByVal dsPlanType As dsPLC, ByVal sDossier As String, ByVal sDate As Date, ByVal sJournal As String, ByVal nNumPiece As Integer, ByRef nNumLigne As Integer, ByVal bRemove As Boolean)
            Try
                If Me.Activites.Count = 0 Then
                    Me.Activites.Add(New MvtActivite("0000"))
                End If
                'Vérif la présence des activités dans le PLC
                For Each Act As MvtActivite In Me.Activites
                    VerifActi(dsImport, sDossier, Act)
                Next
                'Vérif la présence du compte dans le PLC
                VerifCompte(dsImport, sDossier, "48800000", "COMPTE DE REPARTITION")
                VerifCompte(dsImport, sDossier, Me.Compte, dsPlanType)

                For Each Act As MvtActivite In Me.Activites
                    Dim drLigne As dbSauvRest.LignesRow = dsImport.Lignes.NewLignesRow
                    With drLigne
                        .LDossier = sDossier
                        .LDate = sDate
                        .LPiece = nNumPiece
                        .LLig = nNumLigne
                        .LTva = Me.CodeTva
                        .LMtTVA = Me.CodeTvaCompte
                        .LLib = Me.LibMvt
                        .LJournal = sJournal
                        If Me.DatePointage > Date.MinValue Then .DatePointage = Me.DatePointage
                        If Me.DateDeclaration > Date.MinValue Then .DateDeclaration = Me.DateDeclaration
                        If Me.DateValeur > Date.MinValue Then .DateValeur = Me.DateValeur
                    End With
                    dsImport.Lignes.AddLignesRow(drLigne)
                    AddMouvementsActi(dsImport, sDossier, sDate, sJournal, nNumPiece, nNumLigne, Act)
                    nNumLigne += 1
                Next
            Catch ex As Exception
                Throw New ApplicationException("Problème d'import des données vers le dataset (Ajout des lignes) :" & ex.Message, ex)
            End Try

        End Sub

        Private Sub AddMouvementsActi(ByRef dsImport As dbSauvRest, ByVal sDossier As String, ByVal sDate As Date, _
        ByVal sJournal As String, ByVal nNumPiece As Integer, ByVal nNumLigne As Integer, ByVal xAct As MvtActivite)

            Dim drMouvD As dbSauvRest.MouvementsRow = dsImport.Mouvements.NewMouvementsRow
            With drMouvD
                .MDossier = sDossier
                .MDate = sDate
                .MPiece = nNumPiece
                .MLig = nNumLigne
                .MOrdre = 1
                .MMtCre = 0
                .MD_C = "D"
                .MQte1 = Me.Qte1
                .MQte2 = Me.Qte2
            End With
            Dim drMouvTva As dbSauvRest.MouvementsRow = dsImport.Mouvements.NewMouvementsRow
            With drMouvTva
                .MDossier = sDossier
                .MDate = sDate
                .MPiece = nNumPiece
                .MLig = nNumLigne
                .MOrdre = 2
                .MLettrage = Nothing
                .MCptCtr = ""
                .MQte1 = Me.Qte1
                .MQte2 = Me.Qte2
                .MActCtr = "0000"
            End With
            Dim drMouvC As dbSauvRest.MouvementsRow = dsImport.Mouvements.NewMouvementsRow
            With drMouvC
                .MDossier = sDossier
                .MDate = sDate
                .MPiece = nNumPiece
                .MLig = nNumLigne
                .MOrdre = 3
                .MD_C = "C"
                .MQte1 = Me.Qte1
                .MQte2 = Me.Qte2
                .MLettrage = Nothing
            End With

            Try
                If Me.CodeTvaCompte.Length > 0 Then 'C'EST UNE LIGNE DE TVA
                    'génère la ligne ordre 2 de tva
                    With drMouvTva
                        .MCpt = Me.Compte
                        .MActi = "0000"
                        .MMtDeb = Me.MontantD
                        .MMtCre = Me.MontantC
                        .MD_C = Convert.ToString(IIf(Me.MontantD <> 0, "D", "C"))
                        If Not String.IsNullOrEmpty(Me.CodeLettrage) Then .MLettrage = Me.CodeLettrage
                    End With

                    'génère la ligne ordre 1 et 3 de tva
                    With drMouvD
                        .MCpt = "48800000"
                        .MActi = "0000"
                        .MMtCre = 0
                        .MCptCtr = "48800000"
                        .MActCtr = "0000"
                    End With

                    With drMouvC
                        .MCpt = "48800000"
                        .MActi = "0000"
                        .MMtDeb = 0
                        .MCptCtr = "48800000"
                        .MActCtr = "0000"
                    End With

                    Dim montantHT As Decimal = 0
                    Dim montantTTC As Decimal = montantHT + Me.MontantD + Me.MontantC
                    If Me.MontantD <> 0 Then 'LA TVA EST AU DEBIT
                        drMouvD.MMtDeb = montantHT
                        drMouvC.MMtCre = montantTTC
                    Else 'LA TVA EST AU CREDIT
                        drMouvD.MMtDeb = montantTTC
                        drMouvC.MMtCre = montantHT
                    End If
                Else 'C'est une ligne normale
                    Dim codeAct As String = Convert.ToString(IIf(xAct.CodeAct = "", "0000", xAct.CodeAct))
                    Dim montantD As Decimal = Me.MontantD * xAct.Pourcentage / 100
                    Dim montantC As Decimal = Me.MontantC * xAct.Pourcentage / 100
                    If Me.MontantD <> 0 Then 'AU DEBIT
                        With drMouvD
                            .MCpt = Me.Compte
                            .MActi = codeAct
                            .MMtDeb = montantD
                            .MMtCre = montantC
                            .MCptCtr = "48800000"
                            .MActCtr = "0000"
                            If Not String.IsNullOrEmpty(Me.CodeLettrage) Then .MLettrage = Me.CodeLettrage
                        End With
                        With drMouvC
                            .MCpt = "48800000"
                            .MActi = "0000"
                            .MMtDeb = montantC
                            .MMtCre = montantD
                            .MCptCtr = Me.Compte
                            .MActCtr = codeAct
                        End With
                    Else ' AU CREDIT
                        With drMouvD
                            .MCpt = "48800000"
                            .MActi = "0000"
                            .MMtDeb = montantC
                            .MMtCre = montantD
                            .MCptCtr = Me.Compte
                            .MActCtr = codeAct
                        End With
                        With drMouvC
                            .MCpt = Me.Compte
                            .MActi = codeAct
                            .MMtDeb = montantD
                            .MMtCre = montantC
                            .MCptCtr = "48800000"
                            .MActCtr = "0000"
                            If Not String.IsNullOrEmpty(Me.CodeLettrage) Then .MLettrage = Me.CodeLettrage
                        End With
                    End If
                End If
                dsImport.Mouvements.AddMouvementsRow(drMouvD)
                If Me.CodeTvaCompte <> "" Then dsImport.Mouvements.AddMouvementsRow(drMouvTva)
                dsImport.Mouvements.AddMouvementsRow(drMouvC)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message, ex)
            End Try

        End Sub

        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, Compte, LibMvt, MontantD, MontantC, Qte1, Qte2, Numero, CodeTva, CodeTvaCompte, FlagLettrage, _
                        CodeLettrage, DatePointage, NbAct, HasEcheances, DateDeclaration, CodeTva2, CodeTva3, "", "", "", DateValeur}
        End Function

        Public Overrides Function GetSubItems() As ArrayList
            Dim a As New ArrayList
            With a
                .AddRange(Activites)
                .AddRange(Echeances)
            End With
            Return a
        End Function
#End Region

#Region "Méthodes partagées"
        Private Shared Sub VerifActi(ByRef dsImport As dbSauvRest, ByVal sDossier As String, ByVal Act As MvtActivite)
            If dsImport.Activites.Select(String.Format("ADossier='{0}' AND AActi='{1}'", sDossier, Act.CodeAct)).Length = 0 Then
                Dim drAct As dbSauvRest.ActivitesRow = dsImport.Activites.NewActivitesRow
                With drAct
                    .ADossier = sDossier
                    .AActi = Act.CodeAct
                    .ALib = Act.Libelle
                End With
                dsImport.Activites.AddActivitesRow(drAct)
            End If
        End Sub

        Public Shared Function DeterminerLibelleMvt(ByVal rwLigne As dbSauvRest.LignesRow) As String
            Dim libMvt As String = Convert.ToString(rwLigne("LLib"))
            If libMvt.IndexOf("/"c) >= 0 Then
                If libMvt.IndexOf("/"c) < libMvt.Length - 1 Then
                    libMvt = libMvt.Substring(libMvt.IndexOf("/"c) + 1)
                Else
                    libMvt = ""
                End If
            End If
            Return libMvt.Trim
        End Function
#End Region

    End Class

    Public Class MvtActivite
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1,6}{2,2}{3,-40}{4:0000.00000}{5,1}"
        Private Const FLAG As String = "ANAMVT"
        Public CodeAct As String
        Public CodeDecoupe As String
        Public Libelle As String
        Public Pourcentage As Decimal
        Public Prorata As Boolean = False

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal CodeAct As String, Optional ByVal Pourcentage As Decimal = 100D)
            Me.New()
            With Me
                .CodeAct = Left(CodeAct, 6)
                .Pourcentage = Pourcentage
            End With
        End Sub

        Public Sub New(ByVal sLigne As String, ByVal xReg As System.Text.RegularExpressions.Regex)
            Me.New()
            With Me
                Try
                    Dim xElement As System.Text.RegularExpressions.GroupCollection = xReg.Match(sLigne).Groups
                    If Len(xElement("CodeAct").Value.Trim) <= 4 Then
                        .CodeAct = xElement("CodeAct").Value.ToString.Trim.PadRight(4, "0"c)
                    ElseIf Len(xElement("CodeAct").Value.Trim) > 4 Then
                        .CodeAct = Right(xElement("CodeAct").Value.Trim.ToString, 4)
                    End If
                    If xElement("Pourcentage").Value <> "" Then .Pourcentage = DecimalParse(xElement("Pourcentage").Value.Trim).GetValueOrDefault
                Catch ex As Exception

                End Try
            End With
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, CodeAct, CodeDecoupe, Libelle, Pourcentage, Prorata}
        End Function
#End Region

    End Class

    Public Class MvtEcheance
        Inherits ModeleExport

        Private Const FORMAT As String = "{0,-6}{1:0000000000.00}{2:0000.00000}{3,8}"
        Private Const FLAG As String = "ECHMVT"
        Public MontantTTC As Decimal
        Public TauxTTC As Decimal
        Public DateEcheance As Date

#Region "Méthodes diverses"
        Public Overrides Function GetFormat() As String
            Return FORMAT
        End Function

        Public Overrides Function GetFields() As Object()
            Return New Object() {FLAG, MontantTTC, TauxTTC, DateEcheance}
        End Function
#End Region

    End Class
#End Region

    Public Class ProgressEventArgs
        Public Percent As Integer
        Public Status As Object

#Region "Constructeurs"
        Public Sub New()
        End Sub

        Public Sub New(ByVal percent As Integer, Optional ByVal status As Object = Nothing)
            Me.New()
            If percent < 0 Or percent > 100 Then Throw New ArgumentException
            Me.Percent = percent
            Me.Status = status
        End Sub
#End Region

    End Class

    Public Module Utils
        Public Sub EcrireLigneFormat(ByVal tw As IO.TextWriter, ByVal format As String, ByVal ParamArray fields() As Object)
            Dim values() As Object = ReplaceDefaultValues(fields)
            tw.WriteLine(String.Format(format, values).Replace(",", "."))
        End Sub

        Public Sub EcrireLigneSep(ByVal tw As IO.TextWriter, ByVal sep As String, ByVal ParamArray fields() As Object)
            Dim formattedValues() As String = FormatValues(ReplaceDefaultValues(fields))
            tw.WriteLine(String.Join(sep, formattedValues))
        End Sub

        Public Function ReplaceDefaultValues(ByVal fields() As Object) As Object()
            Dim formattedValues(fields.Length - 1) As Object
            For i As Integer = 0 To fields.Length - 1
                If fields(i) Is Nothing Then
                    formattedValues(i) = ""
                Else
                    If TypeOf fields(i) Is Boolean Then
                        formattedValues(i) = IIf(CBool(fields(i)), "1", "0")
                    ElseIf TypeOf fields(i) Is Date Then
                        If CDate(fields(i)) = Date.MinValue Then
                            formattedValues(i) = ""
                        Else
                            formattedValues(i) = String.Format("{0:ddMMyyyy}", fields(i))
                        End If
                    Else
                        formattedValues(i) = fields(i)
                    End If
                End If
            Next
            Return formattedValues
        End Function

        Public Function FormatValues(ByVal fields() As Object) As String()
            Dim formattedValues(fields.Length - 1) As String
            For i As Integer = 0 To fields.Length - 1
                If TypeOf fields(i) Is Date Then
                    formattedValues(i) = String.Format("{0:ddMMyyyy}", fields(i))
                ElseIf TypeOf fields(i) Is Double Or TypeOf fields(i) Is Decimal Then
                    formattedValues(i) = String.Format("{0:#0.00}", fields(i)).Replace(",", ".")
                Else
                    formattedValues(i) = String.Format("{0}", fields(i))
                End If
            Next
            Return formattedValues
        End Function

        Public Function SelectSingleRow(ByVal dt As DataTable, ByVal expression As String, ByVal ParamArray params() As Object) As DataRow
            Dim dr As DataRow = Nothing
            Dim rws() As DataRow = dt.Select(String.Format(expression, params))
            If rws.Length > 0 Then
                dr = rws(0)
            End If
            Return dr
        End Function

    End Module

End Namespace

