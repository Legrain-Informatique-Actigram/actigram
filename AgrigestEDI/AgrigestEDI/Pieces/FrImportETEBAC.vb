Imports System.Windows.Forms

Public Class FrImportETEBAC

    Private worker As System.ComponentModel.BackgroundWorker

#Region "Propriétés"
    Private _fichier As String
    Public Property Fichier() As String
        Get
            Return _fichier
        End Get
        Set(ByVal value As String)
            _fichier = value
        End Set
    End Property

    Private _ResultatListPiece As List(Of Piece)
    Public Property ResultatListPiece() As List(Of Piece)
        Get
            Return _ResultatListPiece
        End Get
        Set(ByVal value As List(Of Piece))
            _ResultatListPiece = value
        End Set
    End Property
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.PlanComptableTableAdapter.FillByDossier(Me.dsImport.PlanComptable, My.User.Name)
        Me.ComptesTableAdapter.FillByDossier(Me.dsImport.Comptes, My.User.Name)
        Me.PlanTypeTableAdapter.Fill(Me.dsImport.PlanType)
        Me.TVATableAdapter.Fill(Me.dsImport.TVA)

        Me.JournalTableAdapter.FillByType(Me.dbJournal.Journal, "tr")
        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel2.Height
            .BringToFront()
            .Visible = False
        End With
        If Not String.IsNullOrEmpty(Me.Fichier) Then
            Me.TxNomFichier.Text = Me.Fichier
        End If
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

    Private Sub BtImporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImporter.Click
        Try
            If TxNomFichier.Text.Trim.Length = 0 Then Exit Sub
            Dim fichierImport As String = TxNomFichier.Text.Trim
            Importer(fichierImport)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "Méthodes diverses"
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

    Public Sub Importer(ByVal fichierImport As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        Me.worker = worker

        'Vérifie l'existence du fichier
        If Not IO.File.Exists(fichierImport) Then
            MsgBox(String.Format(My.Resources.Strings.FichierIntrouvable, IO.Path.GetFileName(fichierImport)))
            Exit Sub
        End If

        If cboJournal.SelectedItem Is Nothing Then
            MsgBox(My.Resources.Strings.Saisie_SelectionJournal, MsgBoxStyle.Exclamation, "Importation")
            Exit Sub
        End If
        Dim drJournal As dbDonneesDataSet.JournalRow = CType(CType(cboJournal.SelectedItem, DataRowView).Row, dbDonneesDataSet.JournalRow)

        Dim resPieces As New List(Of Piece)
        Cursor.Current = Cursors.WaitCursor
        PanProgress.Visible = True
        Application.DoEvents()
        Try
            Try
                ReportProgress(0, My.Resources.Strings.Initialisation)

                Dim altImport As List(Of Importations.CFONB.Releve) = Importations.CFONB.Importateur.Importer(fichierImport)

                Dim dtPlanC As New dbDonneesDataSet.PlanComptableDataTable
                Using dta As New dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
                    dta.FillByDossier(dtPlanC, My.User.Name)
                End Using

                Dim i As Integer = 0
                Dim nLastPiece As Integer = 0
                For Each releve As Importations.CFONB.Releve In altImport
                    For Each ligne As Importations.CFONB.LigneReleve In releve.Lignes
                        ReportProgress(CInt((80 / altImport.Count) * i), My.Resources.Strings.ChargementDesDonnees)
                        Dim piece As New Piece(drJournal.JCodeJournal, ligne.DateValeur, nLastPiece)
                        nLastPiece = piece.NPiece
                        If ligne.MontantMouvement.Montant > 0 Then
                            piece.MontantDebContrePartie = ligne.MontantMouvement.Montant
                        Else
                            piece.MontantCreContrePartie = ligne.MontantMouvement.Montant
                        End If
                        Dim ligneBanque As New Ligne(ligne, drJournal.JCompteContre, Me.dsImport)
                        Dim ligneContre As New Ligne(ligne, Me.dsImport)
                        piece.Lignes.Add(ligneBanque)
                        piece.Lignes.Add(ligneContre)
                        resPieces.Add(piece)
                    Next
                    i += 1
                Next

                ResultatListPiece = resPieces

                ReportProgress(100)
                MsgBox(My.Resources.Strings.Import_Succes, MsgBoxStyle.Information, "Importation")

                'TODO A TESTER QUE CA SE PASSE BIEN SUR UN IMPORT AU DEMARRAGE
                Using fr As New FrBordereau
                    With fr
                        .ResultatListPiece = resPieces
                        .Journal = Convert.ToString(drJournal("JCodeJournal"))
                        .JournalCptContre = Convert.ToString(drJournal("JCompteContre"))
                        .JournalCptContreLib = Convert.ToString(drJournal("JLibelle"))
                        .JournalLib = Convert.ToString(drJournal("JCodeLibelle"))
                        Me.DialogResult = DialogResult.OK
                        Me.Hide()
                        .ShowDialog()
                    End With
                End Using
            Catch ex As ApplicationException
                LogException(ex)
                If MsgBox(My.Resources.Strings.Import_RecapProblemes & vbCrLf & _
                ex.Message & vbCrLf & My.Resources.Strings.EnregistrerRapport, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                    With RestDlg
                        .DefaultExt = "txt"
                        .Filter = "Fichiers texte (*.txt)|*.txt"
                        .FileName = "Rapport d'erreur importation compta.txt"
                        If .ShowDialog = DialogResult.OK Then
                            My.Computer.FileSystem.WriteAllText(.FileName, ex.Message + vbCrLf + ex.StackTrace, False)
                            Process.Start(.FileName)
                        End If
                    End With
                End If
                Me.DialogResult = DialogResult.Cancel
            Catch ex As Exception
                LogException(ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
            Me.Close()
        Finally
            PanProgress.Visible = False
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

End Class
