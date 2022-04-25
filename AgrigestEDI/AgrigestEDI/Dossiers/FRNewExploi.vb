Public Class FrNewExploi

#Region "Propriétés"
    Private _CodeExpl As String = ""
    Public Property CodeExploitation() As String
        Get
            Return _CodeExpl
        End Get
        Set(ByVal value As String)
            _CodeExpl = value
        End Set
    End Property

    Private _CodeDossier As String = ""
    Public Property CodeDossier() As String
        Get
            Return _CodeDossier
        End Get
        Set(ByVal value As String)
            _CodeDossier = value
            If value.Length = 8 Then
                CodeExploitation = value.Substring(0, 6)
            End If
        End Set
    End Property

    Private _dossier As DossierPrincipal
    Public Property Dossier() As DossierPrincipal
        Get
            Return _dossier
        End Get
        Set(ByVal value As DossierPrincipal)
            _dossier = value
            Me.CodeDossier = value.Identity.Name
        End Set
    End Property
#End Region

#Region "Page"
    Private Sub exploitation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ConfigNumericControl(CodeExploitationTextBox)

        If CodeExploitation = "" Then
            Me.Text = My.Resources.Strings.Dossier_TextCreation
            FinExerciceDtp.Value = Today
            DebutExerciceDtp.Value = New Date(Now.Year, 1, 1)
            Me.ExploitationsTableAdapter.Fill(Me.dsDbDonnees.Exploitations)
            Me.DossiersTableAdapter.Fill(Me.dsDbDonnees.Dossiers)
            If My.Settings.CG = "CO" Then
                CodeExploitationLettreTextBox.ReadOnly = True
                CodeExploitationLettreTextBox.Text = "C"
            End If
        Else
            Me.ExploitationsTableAdapter.FillByExpl(Me.dsDbDonnees.Exploitations, CodeExploitation)
            CodeExploitationLettreTextBox.ReadOnly = True
            CodeExploitationLettreTextBox.Text = Me.CodeExploitation.Substring(0, 1)
            CodeExploitationTextBox.Text = Me.CodeExploitation.Substring(1)
            Me.DossiersTableAdapter.FillByExpl(Me.dsDbDonnees.Dossiers, CodeExploitation)
            If CodeDossier = "" Then
                Me.Text = My.Resources.Strings.Dossier_TextCreation
                Dim o As Object = Me.dsDbDonnees.Dossiers.Compute("Max(DDtFinEx)", String.Format("DExpl='{0}'", Me.CodeExploitation))
                If o Is Nothing OrElse IsDBNull(o) Then
                    DebutExerciceDtp.Value = New Date(Now.Year, 1, 1)
                Else
                    DebutExerciceDtp.Value = CDate(o).AddDays(1)
                End If
            Else
                If My.Dossier.Principal Is Nothing Then Exit Sub
                Select Case My.Dossier.Principal.IncrementationPiece
                    Case 0
                        Me.rbtGlobal.Checked = True
                    Case 1
                        Me.rbtJournal.Checked = True
                    Case Else
                        Me.rbtGlobal.Checked = True
                End Select
                Me.Text = My.Resources.Strings.Dossier_TextModif
                Me.DossiersBindingSource.Position = Me.DossiersBindingSource.Find("DDossier", CodeDossier)
                Me.DossiersBindingSource.ResetCurrentItem()
            End If
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.CodeExploitation = "" Then
            NewExploitation()
        ElseIf Me.CodeDossier = "" Then
            NewDossier()
        Else
            Dim bCompleteTranfert As Boolean = False
            Dim bTranfert As Boolean = False
            Dim sMessage As String = ""
            Dim xDossierOrignal As DossierTransfert = New DossierTransfert(Me.Dossier)

            Dim t As OleDb.OleDbTransaction = Nothing
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                Try
                    conn.Open()
                    t = conn.BeginTransaction
                    If DateDiff(DateInterval.Month, DebutExerciceDtp.Value, FinExerciceDtp.Value.AddDays(1)) > 14 Then
                        sMessage = My.Resources.Strings.Date_Ecart14Mois
                    Else
                        If Me.Dossier.DateFinEx <> FinExerciceDtp.Value OrElse Me.Dossier.DateDebutEx <> DebutExerciceDtp.Value Then

                            Dim xDossierDebut As DossierTransfert = Nothing
                            Dim xDossierFin As DossierTransfert = Nothing
                            Dim dtPieceAll As dbDonneesDataSet.PiecesDataTable = New dbDonneesDataSet.PiecesDataTable
                            Me.PiecesAllTableAdapter.Fill(dtPieceAll)

                            'Vérifie que les dates ont été modifié
                            If Me.Dossier.DateDebutEx <> DebutExerciceDtp.Value Then
                                'Retourne la liste des dossiers apres la date début original
                                Dim xDossier() As dbDonneesDataSet.DossiersRow = CType(Me.dsDbDonnees.Dossiers.Select(String.Format("DDtDebEx<#{0:MM/dd/yyyy}#", Me.Dossier.DateDebutEx)), dbDonneesDataSet.DossiersRow())

                                Dim dtMax As Date
                                Dim dtMin As Date
                                Dim xPiece() As DataRow
                                'Vérifie le sens de la modification de la date
                                If Me.Dossier.DateDebutEx > DebutExerciceDtp.Value Then
                                    dtMin = DebutExerciceDtp.Value
                                    dtMax = Me.Dossier.DateDebutEx
                                    'Vérifie s'il existe des pièces pour l'exploitation durant cette période
                                    xPiece = dtPieceAll.Select(String.Format("#{0:MM/dd/yyyy}# < PDate AND PDate< #{1:MM/dd/yyyy}# AND PDossier<>'{2}'", dtMin, dtMax, CodeDossier))
                                Else
                                    dtMin = Me.Dossier.DateDebutEx
                                    dtMax = DebutExerciceDtp.Value
                                    'Vérifie s'il existe des pièces pour l'exploitation durant cette période
                                    xPiece = dtPieceAll.Select(String.Format("#{0:MM/dd/yyyy}# < PDate AND PDate< #{1:MM/dd/yyyy}# AND PDossier='{2}'", dtMin, dtMax, CodeDossier))
                                End If

                                xDossierOrignal.DateMin = DebutExerciceDtp.Value
                                xDossierOrignal.ModifierDates(t)
                                bCompleteTranfert = True
                                If xDossier.LongLength = 0 And xPiece.LongLength > 0 Then
                                    sMessage = My.Resources.Strings.TransfertDossier_PbDossierInexistant
                                    bCompleteTranfert = False
                                ElseIf xPiece.LongLength > 0 Then
                                    Dim xDossierPrincipalDebut As New DossierPrincipal(CType(xDossier(0), dbDonneesDataSet.DossiersRow), CType(Me.dsDbDonnees.Exploitations.Rows(0), dbDonneesDataSet.ExploitationsRow))
                                    xDossierDebut = New DossierTransfert(xDossierPrincipalDebut)

                                    If xPiece.LongLength > 0 Then
                                        xDossierDebut.DateMax = DebutExerciceDtp.Value.AddDays(-1)
                                        Dim bResult As Boolean = False
                                        If Me.Dossier.DateDebutEx > DebutExerciceDtp.Value AndAlso _
                                        MsgBox(String.Format(My.Resources.Strings.TransfertDossier_MsgAttention1 _
                                        + vbCrLf + My.Resources.Strings.TransfertDossier_MsgAttention2FIN _
                                        + vbCrLf + My.Resources.Strings.SouhaitezVousContinuer, xDossierOrignal.Dossier, xDossierDebut.Dossier, xDossierDebut.DateMax), _
                                        MsgBoxStyle.YesNo, My.Resources.Strings.TransfertDossier) = MsgBoxResult.Yes Then
                                            bResult = True
                                        ElseIf Me.Dossier.DateDebutEx < DebutExerciceDtp.Value AndAlso _
                                        MsgBox(String.Format(My.Resources.Strings.TransfertDossier_MsgAttention1 _
                                        + vbCrLf + My.Resources.Strings.TransfertDossier_MsgAttention2FIN _
                                        + vbCrLf + My.Resources.Strings.SouhaitezVousContinuer, xDossierDebut.Dossier, xDossierOrignal.Dossier, xDossierOrignal.DateMax), _
                                        MsgBoxStyle.YesNo, My.Resources.Strings.TransfertDossier) = MsgBoxResult.Yes Then
                                            bResult = True
                                        End If

                                        If bResult Then
                                            If DateDiff(DateInterval.Month, xDossierDebut.DateMin, xDossierDebut.DateMax.AddDays(1)) > 14 Then
                                                sMessage = My.Resources.Strings.Date_Ecart14Mois
                                                bCompleteTranfert = False
                                            Else
                                                xDossierDebut.ModifierDates(t)
                                                bTranfert = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            'Vérifie que les dates ont été modifié
                            If Me.Dossier.DateFinEx <> FinExerciceDtp.Value Then
                                'Retourne la liste des dossiers apres la date fin original
                                Dim xDossier() As dbDonneesDataSet.DossiersRow = CType(Me.dsDbDonnees.Dossiers.Select(String.Format("DDtFinEx>#{0:MM/dd/yyyy}#", Me.Dossier.DateFinEx)), dbDonneesDataSet.DossiersRow())

                                Dim dtMax As Date
                                Dim dtMin As Date
                                Dim xPiece() As DataRow
                                'Vérifie le sens de la modification de la date
                                If Me.Dossier.DateFinEx > FinExerciceDtp.Value Then
                                    dtMin = FinExerciceDtp.Value
                                    dtMax = Me.Dossier.DateFinEx
                                    'Vérifie s'il existe des pièces pour l'exploitation durant cette période
                                    xPiece = dtPieceAll.Select(String.Format("#{0:MM/dd/yyyy}# < PDate AND PDate< #{1:MM/dd/yyyy}# AND PDossier='{2}'", dtMin, dtMax, CodeDossier))
                                Else
                                    dtMin = Me.Dossier.DateFinEx
                                    dtMax = FinExerciceDtp.Value
                                    'Vérifie s'il existe des pièces pour l'exploitation durant cette période
                                    xPiece = dtPieceAll.Select(String.Format("#{0:MM/dd/yyyy}# < PDate AND PDate< #{1:MM/dd/yyyy}# AND PDossier<>'{2}'", dtMin, dtMax, CodeDossier))
                                End If


                                If xDossier.LongLength = 0 And xPiece.LongLength > 0 Then
                                    xDossierFin = New DossierTransfert(Me.Dossier, FinExerciceDtp.Value, t)
                                Else
                                    Dim xDossierPrincipalFin As New DossierPrincipal(xDossier(0), CType(Me.dsDbDonnees.Exploitations.Rows(0), dbDonneesDataSet.ExploitationsRow))
                                    xDossierFin = New DossierTransfert(xDossierPrincipalFin)
                                End If

                                If xDossierFin IsNot Nothing Then
                                    xDossierOrignal.DateMax = FinExerciceDtp.Value
                                    xDossierOrignal.ModifierDates(t)
                                    xDossierFin.DateMin = FinExerciceDtp.Value.AddDays(1)
                                    Dim bResult As Boolean = False
                                    If Me.Dossier.DateFinEx < FinExerciceDtp.Value AndAlso _
                                    MsgBox(String.Format(My.Resources.Strings.TransfertDossier_MsgAttention1 _
                                    + vbCrLf + My.Resources.Strings.TransfertDossier_MsgAttention2DEB _
                                    + vbCrLf + My.Resources.Strings.SouhaitezVousContinuer, xDossierOrignal.Dossier, xDossierFin.Dossier, xDossierFin.DateMin), _
                                    MsgBoxStyle.YesNo, My.Resources.Strings.TransfertDossier) = MsgBoxResult.Yes Then
                                        bResult = True
                                    ElseIf Me.Dossier.DateFinEx > FinExerciceDtp.Value AndAlso _
                                    MsgBox(String.Format(My.Resources.Strings.TransfertDossier_MsgAttention1 _
                                    + vbCrLf + My.Resources.Strings.TransfertDossier_MsgAttention2FIN _
                                    + vbCrLf + My.Resources.Strings.SouhaitezVousContinuer, xDossierFin.Dossier, xDossierOrignal.Dossier, xDossierOrignal.DateMax), _
                                    MsgBoxStyle.YesNo, My.Resources.Strings.TransfertDossier) = MsgBoxResult.Yes Then
                                        bResult = True
                                    End If

                                    If bResult Then
                                        If DateDiff(DateInterval.Month, xDossierFin.DateMin, xDossierFin.DateMax.AddDays(1)) > 14 Then
                                            sMessage = My.Resources.Strings.Date_Ecart14Mois
                                            bCompleteTranfert = False
                                        Else
                                            xDossierFin.ModifierDates(t)
                                            bTranfert = True
                                        End If
                                    End If
                                End If
                            End If

                            If bTranfert Then
                                TransfertData(xDossierOrignal.Dossier, xDossierOrignal.DateMin, xDossierOrignal.DateMax, t)
                                If xDossierDebut IsNot Nothing Then
                                    TransfertData(xDossierDebut.Dossier, xDossierDebut.DateMin, xDossierDebut.DateMax, t)
                                End If
                                If xDossierFin IsNot Nothing Then
                                    TransfertData(xDossierFin.Dossier, xDossierFin.DateMin, xDossierFin.DateMax, t)
                                End If
                                bCompleteTranfert = True
                            Else
                                bCompleteTranfert = True
                            End If
                        Else
                            bCompleteTranfert = True
                        End If

                        If bCompleteTranfert Then
                            ModifExploitation(t)

                            t.Commit()
                            conn.Close()
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        Else
                            MsgBox(IIf(sMessage <> "", sMessage, My.Resources.Strings.TransfertDossier_Pb), MsgBoxStyle.Exclamation, My.Resources.Strings.TransfertDossier)
                            t.Rollback()
                        End If
                    End If
                Catch ex As Exception
                    If t IsNot Nothing Then
                        t.Rollback()
                    End If
                End Try
            End Using
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub NewExploitation()
        If Nom1TextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerfiSaisieNom, MsgBoxStyle.Exclamation, My.Resources.Strings.SaisieIncomplete)
        ElseIf CodeExploitationTextBox.Text = "" Or CodeExploitationLettreTextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerifSaisieCode, MsgBoxStyle.Exclamation, My.Resources.Strings.SaisieIncomplete)
        Else
            Dim sNewExploi As String = Me.CodeExploitationLettreTextBox.Text + Me.CodeExploitationTextBox.Text
            Dim sNewExo As String = sNewExploi + Microsoft.VisualBasic.Right(Today.Year.ToString, 2)
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim t As OleDb.OleDbTransaction = Nothing
                Try
                    conn.Open()
                    t = conn.BeginTransaction
                    ' ajout dans table exploitation
                    Using dtaExploitation As New dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
                        dtaExploitation.SetTransaction(t)
                        If CInt(dtaExploitation.ExistExploitation(sNewExploi)) = 0 Then
                            dtaExploitation.Insert(sNewExploi, Me.Nom1TextBox.Text, CStr(IIf(Me.Nom2TextBox.Text = "", Nothing, Me.Nom2TextBox.Text)), "A")
                        Else
                            Throw New ApplicationException(My.Resources.Strings.Dossier_CodeExplUtilise)
                        End If
                    End Using
                    ' ajout dans table Dossiers
                    Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                        dtadossier.SetTransaction(t)
                        Dim bAjouter As Boolean = False
                        Dim i As Integer = 65
                        While Not bAjouter
                            If CInt(dtadossier.ExistsDossier(sNewExploi, sNewExo)) = 0 Then
                                dtadossier.Insert(sNewExo, sNewExploi, Me.DebutExerciceDtp.Value, Me.FinExerciceDtp.Value, Nothing, Nothing, Nothing, Nothing, 0)
                                bAjouter = True
                            Else
                                If i = 90 Then
                                    Throw New ApplicationException(My.Resources.Strings.Cloture_PlusDeCodeDispo)
                                Else
                                    sNewExo = sNewExploi + Chr(i) + Microsoft.VisualBasic.Right(Me.FinExerciceDtp.Value.Year.ToString, 1)
                                End If
                            End If
                        End While
                    End Using
                    t.Commit()
                    Dim expl As Exploitation = Exploitation.Ajouter(sNewExploi, Me.Nom1TextBox.Text)
                    If expl IsNot Nothing Then expl.Choisir()
                    Me.CodeDossier = sNewExo
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    If t IsNot Nothing Then t.Rollback()
                    Throw ex
                End Try
            End Using
        End If
    End Sub

    Private Sub NewDossier()
        If Nom1TextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerfiSaisieNom, MsgBoxStyle.Exclamation, My.Resources.Strings.SaisieIncomplete)
        ElseIf CodeExploitationTextBox.Text = "" Or CodeExploitationLettreTextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerifSaisieCode, MsgBoxStyle.Exclamation, My.Resources.Strings.SaisieIncomplete)
        ElseIf FinExerciceDtp.Value.Subtract(DebutExerciceDtp.Value).Days < 1 Then
            MsgBox(My.Resources.Strings.Date_Ecart1Jour, MsgBoxStyle.Exclamation, My.Resources.Strings.SaisieIncomplete)
        Else
            'Dim sNewExploi As String = Me.CodeExploitationLettreTextBox.Text + Me.CodeExploitationTextBox.Text
            Dim sNewExo As String = Me.CodeExploitation + Microsoft.VisualBasic.Right(Today.Year.ToString, 2)
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim t As OleDb.OleDbTransaction = Nothing
                Try
                    conn.Open()
                    t = conn.BeginTransaction
                    ' maj dans table exploitation
                    Using dtaExploitation As New dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
                        dtaExploitation.SetTransaction(t)
                        dtaExploitation.Update(Me.Nom1TextBox.Text, CStr(IIf(Me.Nom2TextBox.Text = "", Nothing, Me.Nom2TextBox.Text)), "A", Me.CodeExploitation)
                    End Using
                    ' ajout dans table Dossiers
                    Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                        dtadossier.SetTransaction(t)
                        Dim bAjouter As Boolean = False
                        Dim i As Integer = 65
                        While Not bAjouter
                            If CInt(dtadossier.ExistsDossier(Me.CodeExploitation, sNewExo)) = 0 Then
                                dtadossier.Insert(sNewExo, Me.CodeExploitation, CDate(Me.DebutExerciceDtp.Value.ToShortDateString), CDate(Me.FinExerciceDtp.Value.ToShortDateString), Nothing, Nothing, Nothing, Nothing, 0)
                                Dim nIncrementation As Short = 0
                                If rbtJournal.Checked Then
                                    nIncrementation = 1
                                End If
                                dtadossier.UpdateIncrementationPiece(nIncrementation, My.User.Name)
                                bAjouter = True
                            Else
                                i += 1
                                If i = 90 Then
                                    Throw New ApplicationException(My.Resources.Strings.Cloture_PlusDeCodeDispo)
                                Else
                                    sNewExo = Me.CodeExploitation + Chr(i) + Microsoft.VisualBasic.Right(Me.FinExerciceDtp.Value.Year.ToString, 1)
                                End If
                            End If
                        End While
                    End Using
                    t.Commit()
                    Me.CodeDossier = sNewExo
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    If t IsNot Nothing Then t.Rollback()
                    Throw New Exception(ex.Message, ex)
                End Try
            End Using
        End If
    End Sub

    Private Sub ModifExploitation(ByRef t As OleDb.OleDbTransaction)
        If Nom1TextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerfiSaisieNom, MsgBoxStyle.Information, My.Resources.Strings.SaisieIncomplete)
        ElseIf CodeExploitationTextBox.Text = "" Or CodeExploitationLettreTextBox.Text = "" Then
            MsgBox(My.Resources.Strings.Expl_VerifSaisieCode, MsgBoxStyle.Information, My.Resources.Strings.SaisieIncomplete)
        Else
            Try
                ' modifie dans table exploitation
                Using dtaExploitation As New dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
                    dtaExploitation.SetTransaction(t)
                    If CInt(dtaExploitation.ExistExploitation(CodeExploitation)) > 0 Then
                        dtaExploitation.Update(Me.Nom1TextBox.Text, CStr(IIf(Me.Nom2TextBox.Text = "", Nothing, Me.Nom2TextBox.Text)), "A", CodeExploitation)
                    Else
                        Throw New ApplicationException(String.Format(My.Resources.Strings.Expl_ExplIntrouvable, CodeExploitation))
                    End If
                End Using
                Using dtaDossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                    dtaDossier.SetTransaction(t)
                    If CInt(dtaDossier.ExistsDossier(CodeExploitation, CodeDossier)) > 0 Then
                        dtaDossier.UpdateDateDossier(Me.DebutExerciceDtp.Value, Me.FinExerciceDtp.Value, Nothing, CodeDossier, CodeExploitation)
                        Dim nIncrementation As Short = 0
                        If rbtJournal.Checked Then
                            nIncrementation = 1
                        End If
                        dtaDossier.UpdateIncrementationPiece(nIncrementation, My.User.Name)
                    Else
                        Throw New ApplicationException(String.Format(My.Resources.Strings.Expl_DossierIntrouvable, CodeDossier))
                    End If
                End Using
                Exploitation.Modifier(CodeExploitation, Me.Nom1TextBox.Text, CodeExploitation)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message, ex)
            End Try
        End If
    End Sub

    Public Sub TransfertData(ByVal sDossierSource As String, ByVal dtDateMin As Date, ByVal dtDateMax As Date, ByRef t As OleDb.OleDbTransaction)

        Dim dtNewData As New DataTable
        Dim sCompte As String = ""
        Dim sActivite As String = ""
        'Récupère les comptes et les activités de la table mouvement source en retirant les comptes et activités déjà dans la table plan comptable de la destination
        dtNewData = ExecuteDataTable(String.Format("Select Distinct MDossier, MCpt, MActi FROM Mouvements WHERE (Mouvements.MDate BETWEEN #{0:MM/dd/yyyy}# AND #{1:MM/dd/yyyy}#) AND (MCpt NOT IN (SELECT PlCpt FROM(PlanComptable) WHERE (PlDossier = '{2}')))", dtDateMin, dtDateMax, sDossierSource), t)
        dtNewData.TableName = "CompteTotal"

        Try
            For Each xDossierTransfert As DataRow In AgriTools.SelectDistinct(dtNewData, "MDossier").Rows
                Dim sDossierTransfert As String = Convert.ToString(xDossierTransfert("MDossier"))
                For Each xRowCompte As DataRow In AgriTools.SelectDistinct(dtNewData, "MActi").Rows
                    sActivite = CStr(IIf(Convert.ToString(xRowCompte("MActi")) = "", "0000", Convert.ToString(xRowCompte("MActi"))))
                    ExecuteNonQuery(String.Format("INSERT INTO Activites SELECT '{0}' AS ADossier, A2.AActi, A2.ALib, A2.AQte, A2.AUnit FROM Activites A2 WHERE (A2.ADossier = '{1}') AND (A2.AActi = '{2}') AND NOT EXISTS(SELECT * FROM Activites WHERE ADossier='{0}' AND AActi='{2}')", sDossierSource, sDossierTransfert, sActivite), t)
                Next
                For Each xRowCompte As DataRow In AgriTools.SelectDistinct(dtNewData, "MCpt").Rows
                    sCompte = Convert.ToString(xRowCompte("MCpt"))
                    ExecuteNonQuery(String.Format("INSERT INTO Comptes SELECT '{0}' AS CDossier, C2.CCpt, C2.CLib, C2.CU1, C2.CU2, C2.CCptContre, C2.C_DC  FROM Comptes C2 WHERE (C2.CDossier = '{1}') AND (C2.CCpt = '{2}') AND NOT EXISTS(SELECT * FROM Comptes WHERE CDossier='{0}' AND CCpt='{2}')", sDossierSource, sDossierTransfert, sCompte), t)
                Next
                For Each xRowCompte As DataRow In dtNewData.Rows
                    sCompte = Convert.ToString(xRowCompte("MCpt"))
                    sActivite = CStr(IIf(Convert.ToString(xRowCompte("MActi")) = "", "0000", Convert.ToString(xRowCompte("MActi"))))
                    ExecuteNonQuery(String.Format("INSERT INTO PlanComptable SELECT '{0}' AS PlDossier, PL2.PlCpt, PL2.PlActi, PL2.PlLib FROM PlanComptable PL2 WHERE (PL2.PlDossier = '{1}') AND (PL2.PlCpt = '{2}') AND (PL2.PlActi = '{3}') AND NOT EXISTS(SELECT * FROM PlanComptable WHERE PlDossier='{0}' AND PlCpt='{2}' AND PlActi='{3}')", sDossierSource, sDossierTransfert, sCompte, sActivite), t)
                Next
            Next

            ExecuteNonQuery(String.Format("INSERT INTO Pieces SELECT '{0}' AS PDossier, PPiece, PDate, Exporte, DateExport, Libelle, Journal FROM Pieces P2 WHERE (P2.PDate BETWEEN #{1:MM/dd/yyyy}# AND #{2:MM/dd/yyyy}#) AND (P2.PDossier <> '{0}')", sDossierSource, dtDateMin, dtDateMax), t)
            ExecuteNonQuery(String.Format("INSERT INTO Lignes SELECT '{0}' AS LDossier, LPiece, LDate, LLig, LTva, LLib, LGene, LAna, LJournal, LMtTVA FROM Lignes L2 WHERE (L2.LDate BETWEEN #{1:MM/dd/yyyy}# AND #{2:MM/dd/yyyy}#) AND (L2.LDossier <> '{0}')", sDossierSource, dtDateMin, dtDateMax), t)
            ExecuteNonQuery(String.Format("INSERT INTO Mouvements SELECT '{0}' AS MDossier, MPiece, MDate, MLig, MOrdre, MCpt, MActi, MMtDeb, MMtCre, MD_C, MQte1, MQte2, MLettrage, MEcheance, MFolio, MCptCtr, MActCtr, MCouleur FROM Mouvements M2 WHERE (M2.MDate BETWEEN #{1:MM/dd/yyyy}# AND #{2:MM/dd/yyyy}#) AND (M2.MDossier <> '{0}')", sDossierSource, dtDateMin, dtDateMax), t)
            ExecuteNonQuery(String.Format("DELETE FROM Mouvements WHERE (MDate BETWEEN #{0:MM/dd/yyyy}# AND #{1:MM/dd/yyyy}#) AND (MDossier <> '{2}')", dtDateMin, dtDateMax, sDossierSource), t)
            ExecuteNonQuery(String.Format("DELETE FROM Lignes WHERE (LDate BETWEEN #{0:MM/dd/yyyy}# AND #{1:MM/dd/yyyy}#) AND (LDossier <> '{2}')", dtDateMin, dtDateMax, sDossierSource), t)
            ExecuteNonQuery(String.Format("DELETE FROM Pieces WHERE (PDate BETWEEN #{0:MM/dd/yyyy}# AND #{1:MM/dd/yyyy}#) AND (PDossier <> '{2}')", dtDateMin, dtDateMax, sDossierSource), t)

        Catch ex As Exception
            t.Rollback()
            t = Nothing
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

    Private Sub CodeExploitationTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodeExploitationTextBox.Validating

        If CodeExploitationTextBox.Text.Length > 0 Then
            If Not CodeExploitationTextBox.Text Like "[0-9][0-9][0-9][0-9][0-9]" Then
                If My.Settings.CG = "CO" Then
                    CodeExploitationTextBox.Text = CodeExploitationTextBox.Text.PadLeft(5, CChar("0"))
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub DebutExerciceDtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DebutExerciceDtp.Validating

        If CodeDossier <> "" Then
            If Me.dsDbDonnees.Pieces.Count = 0 Then Me.PiecesTableAdapter.FillByDossier(Me.dsDbDonnees.Pieces, CodeDossier)
            If DateDiff(DateInterval.Month, DebutExerciceDtp.Value, FinExerciceDtp.Value.AddDays(1)) > 14 Then
                MsgBox(My.Resources.Strings.Date_Ecart14Mois, MsgBoxStyle.Information, My.Resources.Strings.SelectionDate)
                e.Cancel = True
            End If
            Using dtaPiece As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                If Me.dsDbDonnees.Pieces.Select(String.Format("PDate<#{0:MM/dd/yyyy}# AND PDossier='{1}'", DebutExerciceDtp.Value, CodeDossier)).LongLength > 0 Then
                    MsgBox(My.Resources.Strings.Dossier_AvertissementTransfert + vbCrLf + My.Resources.Strings.Dossier_AvertissementTransfert2, MsgBoxStyle.Information, My.Resources.Strings.TransfertDossier)
                    e.Cancel = False
                End If
            End Using
        Else
            If Me.dsDbDonnees.Dossiers.Select(String.Format("(DExpl = '{0}') AND (DDtDebEx <= #{1:MM/dd/yyyy}#) AND (DDtFinEx >= #{2:MM/dd/yyyy}#)", CodeExploitation, DebutExerciceDtp.Value, DebutExerciceDtp.Value)).LongLength > 0 Then
                MsgBox(My.Resources.Strings.Dossier_PbChoixDate, MsgBoxStyle.Exclamation, My.Resources.Strings.SelectionDate)
                e.Cancel = True
            End If
            If DateDiff(DateInterval.Month, DebutExerciceDtp.Value, FinExerciceDtp.Value.AddDays(1)) > 14 Then
                MsgBox(My.Resources.Strings.Date_Ecart14Mois, MsgBoxStyle.Information, My.Resources.Strings.SelectionDate)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub FinExerciceDtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FinExerciceDtp.Validating

        If CodeDossier <> "" Then
            If Me.dsDbDonnees.Pieces.Count = 0 Then Me.PiecesTableAdapter.FillByDossier(Me.dsDbDonnees.Pieces, CodeDossier)
            Using dtaPiece As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                If Me.dsDbDonnees.Pieces.Select(String.Format("PDate>#{0:MM/dd/yyyy}# AND PDossier='{1}'", FinExerciceDtp.Value, CodeDossier)).LongLength > 0 Then
                    MsgBox(My.Resources.Strings.Dossier_AvertissementTransfert3 + vbCrLf + My.Resources.Strings.Dossier_AvertissementTransfert2, MsgBoxStyle.Information, My.Resources.Strings.TransfertDossier)
                    e.Cancel = False
                End If
            End Using
        Else
            If Me.dsDbDonnees.Dossiers.Select(String.Format("(DExpl = '{0}') AND (DDtDebEx >= #{1:MM/dd/yyyy}#) AND (DDtFinEx <= #{1:MM/dd/yyyy}#)", CodeExploitation, FinExerciceDtp.Value)).LongLength > 0 Then
                MsgBox(My.Resources.Strings.Dossier_PbChoixDate, MsgBoxStyle.Exclamation, My.Resources.Strings.SelectionDate)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub DebutExerciceDtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebutExerciceDtp.ValueChanged
        FinExerciceDtp.MaxDate = CDate("01/01/3000")
        FinExerciceDtp.MinDate = DebutExerciceDtp.Value.AddDays(1)
        FinExerciceDtp.MaxDate = DebutExerciceDtp.Value.AddMonths(14).AddDays(-1)
        If CodeDossier = "" Then
            FinExerciceDtp.Value = DebutExerciceDtp.Value.AddMonths(12).AddDays(-1)
        End If
    End Sub

    Private Class DossierTransfert

#Region "Property"

        Private _Exploitation As String = ""
        Public Property Exploitation() As String
            Get
                Return _Exploitation
            End Get
            Set(ByVal value As String)
                _Exploitation = value
            End Set
        End Property

        Private _Dossier As String = ""
        Public Property Dossier() As String
            Get
                Return _Dossier
            End Get
            Set(ByVal value As String)
                _Dossier = value
            End Set
        End Property

        Private _DateMin As Date
        Public Property DateMin() As Date
            Get
                Return _DateMin
            End Get
            Set(ByVal value As Date)
                _DateMin = value
            End Set
        End Property

        Private _DateMax As Date
        Public Property DateMax() As Date
            Get
                Return _DateMax
            End Get
            Set(ByVal value As Date)
                _DateMax = value
            End Set
        End Property

#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal xDossier As DossierPrincipal)
            Me.new()
            Me.Exploitation = xDossier.CodeExpl
            Me.Dossier = xDossier.Identity.Name
            Me.DateMin = xDossier.DateDebutEx
            Me.DateMax = xDossier.DateFinEx
        End Sub

        Public Sub New(ByVal xDossierOriginal As DossierPrincipal, ByVal dtDatePicker As Date, ByRef t As OleDb.OleDbTransaction)
            Me.new()
            'Me.DateMin = xDossierOriginal.DateFinEx.AddDays(1)
            Me.DateMin = dtDatePicker.AddDays(1)
            Me.DateMax = Me.DateMin.AddMonths(12).AddDays(-1)
            Me.Exploitation = xDossierOriginal.CodeExpl
            Me.Dossier = Me.Exploitation + Microsoft.VisualBasic.Right(Me.DateMin.Year.ToString, 2)
            CreationDossierFin(t)
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Function CreationDossierFin(ByRef t As OleDb.OleDbTransaction) As Boolean
            Try
                ' ajout dans table Dossiers
                Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                    dtadossier.SetTransaction(t)
                    Dim bAjouter As Boolean = False
                    Dim i As Integer = 65
                    While Not bAjouter
                        If CInt(dtadossier.ExistsDossier(Me.Exploitation, Me.Dossier)) = 0 Then
                            dtadossier.Insert(Me.Dossier, Me.Exploitation, Me.DateMin, Me.DateMax, Nothing, Nothing, Nothing, Nothing, 0)
                            bAjouter = True
                        Else
                            If i = 90 Then
                                Throw New ApplicationException(My.Resources.Strings.Cloture_PlusDeCodeDispo)
                            Else
                                Me.Dossier = Me.Exploitation + Chr(i) + Microsoft.VisualBasic.Right(Me.DateMin.Year.ToString, 1)
                            End If
                        End If
                    End While
                End Using
                Return True
            Catch ex As Exception
                If t IsNot Nothing Then
                    t.Rollback()
                End If
                Return False
            End Try

        End Function

        Public Function ModifierDates(ByRef t As OleDb.OleDbTransaction) As Boolean
            Try
                ' ajout dans table Dossiers
                Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                    dtadossier.SetTransaction(t)
                    If CInt(dtadossier.ExistsDossier(Me.Exploitation, Me.Dossier)) > 0 Then
                        dtadossier.UpdateDateDossier(Me.DateMin, Me.DateMax, Nothing, Me.Dossier, Me.Exploitation)
                    End If
                End Using
                Return True
            Catch ex As Exception
                If t IsNot Nothing Then
                    t.Rollback()
                End If
                Return False
            End Try

        End Function
#End Region

    End Class

End Class