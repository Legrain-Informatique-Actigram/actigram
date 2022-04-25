Imports CrystalDecisions.CrystalReports.Engine

Public Class FrVisuPiece
    Implements IPrechargement

    Private bIsSearch As Boolean = False
    Private bIsSearchCancel As Boolean = False
    Private bIsLoaded As Boolean = False
    Private nNewPieceVar As Integer = 0
    Private dDateNewPieceVar As Date
    Private hstSearchData As Hashtable

#Region "Property"
    ''' <summary>
    ''' date de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewDatePiece() As Date
        Get
            Return dDateNewPieceVar
        End Get
        Set(ByVal value As Date)
            dDateNewPieceVar = value
        End Set
    End Property

    ''' <summary>
    ''' numéro de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewPiece() As Integer
        Get
            Return nNewPieceVar
        End Get
        Set(ByVal value As Integer)
            nNewPieceVar = value
        End Set
    End Property

    ''' <summary>
    ''' tableau des critères de recherche
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchData() As Hashtable
        Get
            Return hstSearchData
        End Get
        Set(ByVal value As Hashtable)
            hstSearchData = value
        End Set
    End Property
#End Region

#Region "Chargement du dossier"

    ''' <summary>
    ''' lancement de la tache de fond du démarage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork

        Try
            Me.PiecesBindingSource.SuspendBinding()
            Me.LignesBindingSource.SuspendBinding()
            Dim l As New ListOfPieces
            l.Charger(CType(sender, System.ComponentModel.BackgroundWorker), SearchData)
            e.Result = l
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' récupère le résultat du chargement et fait disparaitre la barre de chargement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted

        Me.PiecesBindingSource.DataSource = e.Result
        Me.PiecesBindingSource.ResumeBinding()
        Me.LignesBindingSource.ResumeBinding()
        If NewPiece <> 0 Then
            For i As Integer = 0 To PiecesBindingSource.Count - 1
                If CType(PiecesBindingSource(i), Piece).NPiece = NewPiece AndAlso _
                CType(PiecesBindingSource(i), Piece).DatePiece = NewDatePiece Then
                    PiecesBindingSource.Position = i
                End If
            Next
        End If
        Me.progressBar.Visible = False

    End Sub

    ''' <summary>
    ''' affiche la barre de progression avec la valeur associé
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged

        Me.progressBar.Visible = True
        Me.progressBar.Value = e.ProgressPercentage

    End Sub
#End Region

#Region "Form"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Try
            progressBar.Visible = False
            Me.ComptesTableAdapter.FillByDossier(Me.dsAgrigest.Comptes, My.User.Name)
            Me.JournalTableAdapter.Fill(Me.dsAgrigest.Journal)
            Me.ActivitesTableAdapter.FillByDossier(Me.dsAgrigest.Activites, My.User.Name)

            UpdateSommes()

            With LignesDgv
                AddHandler .CellParsing, AddressOf dg_CellParsing
                AddHandler .DataError, AddressOf dg_DataError
                AddHandler .MouseDown, AddressOf dg_GestionClicDroit
            End With

            bgWorker.RunWorkerAsync()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub
#End Region

#Region "Méthodes diverses"
    ''' <summary>
    ''' Permet de faire le paramétrage de la consulter des pièces via le module de recherche
    ''' </summary>
    ''' <param name="AvancedOption"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger

        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT COUNT(*) FROM PlanComptable WHERE PlDossier='" + My.User.Name + "'", conn) = 0 Then
                Return False
            Else
                If AvancedOption Then
                    Dim frmSearch As New FrSearchPiece
                    If frmSearch.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    Else
                        If CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                            BindingNavigatorAddNewItem.Visible = False
                            BindingNavigatorModifItem.Visible = False
                            BindingNavigatorDeleteItem.Visible = False
                            CMenuNew.Visible = False
                            CMenuModif.Visible = False
                            CMenuDelete.Visible = False
                        End If
                        Me.bIsSearch = True
                        Return True
                    End If
                End If
                If CType(My.User.CurrentPrincipal, DossierPrincipal).IsComptaCloture Then
                    BindingNavigatorAddNewItem.Visible = False
                    BindingNavigatorModifItem.Visible = False
                    BindingNavigatorDeleteItem.Visible = False
                    CMenuNew.Visible = False
                    CMenuModif.Visible = False
                    CMenuDelete.Visible = False
                End If
                Return True
            End If
            conn.Close()
        End Using

    End Function
#End Region

#Region "Refresh de la grille"

    ''' <summary>
    ''' Permet de vérifier le formatage des données saisies
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles LignesDgv.CellValidating

        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Compte.Index Then
            If Convert.ToString(e.FormattedValue).Length = 0 Then Exit Sub
            LignesDgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CStr(e.FormattedValue).PadRight(8, "0"c)
        ElseIf e.ColumnIndex = Compte.Index Then
        End If

    End Sub

    ''' <summary>
    ''' permet de sélectionner la première ligne lorsque la grille est chargé
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles LignesDgv.DataBindingComplete

        bIsLoaded = False
        If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub
        'Debug.Print("databindingcomplete")
        For Each l As Ligne In CType(Me.PiecesBindingSource.Current, Piece).Lignes
            ActionsLigne(l)
            bIsLoaded = True
        Next
        'permet de régénérer graphiquement la colonne indiqué
        LignesDgv.InvalidateColumn(Activite.Index)

    End Sub

    ''' <summary>
    ''' permet de charger les paramètres adapter à la ligne qui vient de changer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LignesBindingSource.CurrentChanged

        ActionsLigne()
        UpdateSommes()
        'permet de régénérer graphiquement la colonne indiqué
        LignesDgv.InvalidateColumn(Activite.Index)

    End Sub

    ''' <summary>
    ''' permet de charger les paramètres adapter à la ligne apres le changement de la cellule
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesBindingSource_CurrentItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LignesBindingSource.CurrentItemChanged

        ActionsLigne()
        UpdateSommes()

    End Sub

    ''' <summary>
    ''' permet d'appeller la fonction qui va paramétrer la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActionsLigne()

        Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
        If curLigne Is Nothing Then Exit Sub
        ActionsLigne(curLigne)

    End Sub

    ''' <summary>
    ''' permet de paramétrer la ligne au niveau des droits
    ''' </summary>
    ''' <param name="curLigne">ligne en cours de traitement</param>
    ''' <remarks></remarks>
    Private Sub ActionsLigne(ByVal curLigne As Ligne)

        Dim curRow As DataGridViewRow = Nothing
        For Each r As DataGridViewRow In LignesDgv.Rows
            If r.DataBoundItem Is curLigne Then
                curRow = r
                Exit For
            End If
        Next
        If curRow Is Nothing Then Exit Sub

        'Dim st As New StackTrace(2)
        'Debug.Print("Ligne Action sur ligne {0} at {1}", curRow.Index, st.GetFrame(0).GetMethod)
        If curLigne.Compte Is Nothing OrElse curLigne.Compte = "" Then
            With curRow
                .Cells(Activite.Name).ReadOnly = True
                'CType(.Cells(Activite.Name), DataGridViewDisableButtonCell).ButtonVisible = False
                .Cells(Libelle.Name).ReadOnly = True
                .Cells(CodeTva.Name).ReadOnly = True
                .Cells(MontantCre.Name).ReadOnly = True
                .Cells(MontantDeb.Name).ReadOnly = True
                .Cells(Quantite1.Name).ReadOnly = True
                .Cells(Quantite2.Name).ReadOnly = True
            End With
        Else
            With curRow
                .Cells(Libelle.Name).ReadOnly = False
                'TVA => Editable seulement sur comptes 6 et 7
                .Cells(CodeTva.Name).ReadOnly = Not (curLigne.Compte.StartsWith("6") Or curLigne.Compte.StartsWith("7"))
                'Crédit renseigné => Débit ReadOnly
                .Cells(MontantCre.Name).ReadOnly = curLigne.MontantDeb.HasValue
                'Débit renseigné => Crédit ReadOnly
                .Cells(MontantDeb.Name).ReadOnly = curLigne.MontantCre.HasValue
                'Compte sans unité => Qté ReadOnly
                .Cells(Quantite1.Name).ReadOnly = (curLigne.Unite1 Is Nothing OrElse curLigne.Unite1.Length = 0)
                .Cells(Quantite2.Name).ReadOnly = (curLigne.Unite2 Is Nothing OrElse curLigne.Unite2.Length = 0)
            End With
        End If

    End Sub

    ''' <summary>
    ''' permet de retourner la liste des activitées associées à un compte
    ''' </summary>
    ''' <param name="nCompte">nom du compte</param>
    ''' <returns>retourne la liste des activités</returns>
    ''' <remarks></remarks>
    Private Function FindActivites(ByVal nCompte As String) As List(Of String)

        Dim rws() As DataRow = Me.dsAgrigest.PlanComptable.Select(String.Format("PlCpt='{0}' And PlActi<>'0000'", nCompte))
        Dim list As New List(Of String)
        For Each rw As dbDonneesDataSet.PlanComptableRow In rws
            list.Add(rw.PlActi)
        Next
        Return list

    End Function

    ''' <summary>
    ''' permet de compter le nombre d'activité lié à un compte
    ''' </summary>
    ''' <param name="nCompte">nom du compte</param>
    ''' <returns>retourne le nombre d'activitées</returns>
    ''' <remarks>permet d'afficher ou pas le bouton dans la colonne</remarks>
    Private Function CountActivites(ByVal nCompte As String) As Integer

        Dim o As Object = Me.dsAgrigest.PlanComptable.Compute("Count(PlActi)", String.Format("PlCpt='{0}' And PlActi<>'0000'", nCompte))
        If Not IsDBNull(o) Then
            Return CInt(o)
        Else
            Return 0
        End If

    End Function

    ''' <summary>
    ''' permet de faire la somme des lignes et le met dans la barre de tâche et aligne les colonnes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateSommes()

        Try

            Dim deb As Decimal = 0
            Dim cre As Decimal = 0
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If Not curPiece Is Nothing Then
                deb = curPiece.CalcSommeDeb
                cre = curPiece.CalcSommeCre
                lbSommeCre.Text = String.Format("{0:C2}", curPiece.CalcSommeCre)
            Else
                lbSommeCre.Text = String.Format("{0:C2}", cre)
            End If
            lbFiller.Width = LignesDgv.RowHeadersWidth
            For Each col As DataGridViewColumn In LignesDgv.Columns
                If col Is Me.MontantDeb Then Exit For
                lbFiller.Width += col.Width
            Next
            lbSommeDeb.Width = Me.MontantDeb.Width
            lbSommeCre.Width = Me.MontantCre.Width
            lbSommeDeb.Text = String.Format("{0:C2}", deb)
            lbSoldePiece.Text = String.Format("{0:C2}", deb - cre)
            If deb - cre <> 0 Then
                lbSoldePiece.ForeColor = Color.Red
            Else
                lbSoldePiece.ForeColor = SystemColors.ControlText
            End If
            UpdateSommeCompte()

        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' met à jour les totaux du la pièce
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateSommeCompte()

        Try
            'Gestion des totaux pour le compte en cours
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If curPiece Is Nothing Then Exit Sub
            Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
            If curLigne Is Nothing Then Exit Sub
            Dim sTotalLigneCredit As Decimal = curLigne.TotalCredit.GetValueOrDefault(0)
            Dim sTotalLigneDebit As Decimal = curLigne.TotalDebit.GetValueOrDefault(0)
            If curPiece.IsNew Then
                For Each xRow As Ligne In curPiece.Lignes
                    If xRow.Compte = curLigne.Compte Then
                        If xRow.MontantDeb.HasValue Then
                            sTotalLigneDebit += xRow.MontantDeb.Value
                        ElseIf xRow.MontantCre.HasValue Then
                            sTotalLigneCredit += xRow.MontantCre.Value
                        End If
                    End If
                Next
            End If

            lblCompte.Text = ""
            lblActivite.Text = ""
            Dim drCompte() As DataRow = Me.dsAgrigest.Comptes.Select("CCpt='" + curLigne.Compte + "'")
            If drCompte.Length > 0 Then
                lblCompte.Text = Convert.ToString(drCompte(0)("CLib"))
            End If
            Dim drActivite() As DataRow = Me.dsAgrigest.Activites.Select("AActi='" + curLigne.ActiviteShowAll + "'")
            If drActivite.Length > 0 Then
                If curLigne.ActiviteShowAll = "0000" Then
                    lblActivite.Text = ""
                Else
                    lblActivite.Text = String.Format("{0} (en {1})", drActivite(0)("ALib"), drActivite(0)("AUnit"))
                End If
            End If

            lblDebit.Text = String.Format("{0:C2}", sTotalLigneDebit)
            lblCredit.Text = String.Format("{0:C2}", sTotalLigneCredit)
            If sTotalLigneDebit > sTotalLigneCredit Then
                lblDebitBalance.Text = String.Format("{0:C2}", sTotalLigneDebit - sTotalLigneCredit)
                lblCreditBalance.Text = ""
            ElseIf sTotalLigneCredit > sTotalLigneDebit Then
                lblDebitBalance.Text = ""
                lblCreditBalance.Text = String.Format("{0:C2}", sTotalLigneCredit - sTotalLigneDebit)
            Else
                lblDebitBalance.Text = ""
                lblCreditBalance.Text = ""
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

#End Region

#Region "Barre d'outil"
    ''' <summary>
    ''' permet de fermer l'application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.Close()

    End Sub

    ''' <summary>
    ''' Permet de supprimer une pièce
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click, CMenuDelete.Click

        Try
            Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
            If MsgBox(String.Format(My.Resources.Strings.SuppressionPiece, curPiece.NPiece, curPiece.DatePiece), MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDePiece) = MsgBoxResult.Yes Then
                curPiece.SuppressionPiece()
                Me.PiecesBindingSource.RemoveCurrent()
                UpdateSommes()
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' Permet d'ouvrir la saisie de pièce pour en créer une nouvelle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click, CMenuNew.Click
        CType(Me.ParentForm, Main).AfficherEcran("FrSaisiePiece", False)
    End Sub

    ''' <summary>
    ''' Permet d'ouvrir la saisie de pièce pour modifier la pièce passer en paramètre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BindingNavigatorModifItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorModifItem.Click, CMenuModif.Click

        Dim frmSaisiePiece As New FrSaisiePiece
        With frmSaisiePiece
            .NewDatePiece = CType(Me.DatePieceDtp.Text, Date)
            .PieceACharger = CType(Me.NPieceTextBox.Text, Integer)
            .ShowDialog()
        End With

        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
        With curPiece
            .NPiece = frmSaisiePiece.PieceACharger
            .NPrevPiece = .NPiece
            .DatePiece = frmSaisiePiece.NewDatePiece
            .PrevDatePiece = .DatePiece
            .RafraichirBase()
        End With

        Me.PiecesBindingSource.ResetBindings(False)
        Me.LignesBindingSource.ResetBindings(False)
        LignesDgv.Invalidate()

    End Sub

    ''' <summary>
    ''' bouton permettant de visualiser un compte
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub VisualiserLeCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualiserLeCompteToolStripMenuItem.Click
        If Me.LignesBindingSource.Current Is Nothing Then Exit Sub

        Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)

        Using fr As New FrVisuCompte()
            With fr
                .nCompte = curLigne.Compte
                .ShowDialog()
            End With
        End Using
    End Sub

    ''' <summary>
    ''' Bouton d'impression
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        ReportProgress(0, My.Resources.Strings.Initialisation)
        Cursor.Current = Cursors.WaitCursor

        ReportProgress(50, My.Resources.Strings.ChargementDesDonnees)
        Dim xPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
        Dim ds As DataSet = ImprPiece.GetDataRptVisuPiece(CStr(xPiece.NPiece), CStr(xPiece.DatePiece))

        ReportProgress(60, My.Resources.Strings.OuvertureEtat)
        Using report As ReportDocument = ImprPiece.PrepareRptVisuPiece(ds, True)
            ReportProgress(80)
            ImprPiece.AffichDonneesGen(report)
            Using fr As New EcranCrystal(report)
                ReportProgress(100)
                fr.ShowDialog()
            End Using

        End Using

        Me.progressBar.Visible = False
        Me.lbStatut.Text = ""
        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "PiecesBindingSource"
    ''' <summary>
    ''' permet de bloquer ou d'activer les boutons du menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PiecesBindingSource_BindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles PiecesBindingSource.BindingComplete
        If PiecesBindingSource.Count > 0 Then
            BindingNavigatorDeleteItem.Enabled = True
            BindingNavigatorModifItem.Enabled = True
            CMenuModif.Enabled = True
            CMenuDelete.Enabled = True
        Else
            BindingNavigatorDeleteItem.Enabled = False
            BindingNavigatorModifItem.Enabled = False
            CMenuModif.Enabled = False
            CMenuDelete.Enabled = False
        End If

        If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub

        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
        Dim dateClotureTVA As Nullable(Of Date) = Me.GetDDtClotureTVA()

        If (dateClotureTVA.HasValue) Then
            If (curPiece.DatePiece <= CDate(dateClotureTVA)) Then
                Me.CMenuModif.Enabled = False
                Me.CMenuDelete.Enabled = False
            Else
                Me.CMenuModif.Enabled = True
                Me.CMenuDelete.Enabled = True
            End If
        End If
    End Sub

    Private Sub PiecesBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiecesBindingSource.CurrentChanged
        If Me.PiecesBindingSource.Current Is Nothing Then Exit Sub

        Dim curPiece As Piece = CType(Me.PiecesBindingSource.Current, Piece)
        Dim dateClotureTVA As Nullable(Of Date) = Me.GetDDtClotureTVA()

        If (dateClotureTVA.HasValue) Then
            If (curPiece.DatePiece <= CDate(dateClotureTVA)) Then
                Me.CMenuModif.Enabled = False
                Me.CMenuDelete.Enabled = False
            Else
                Me.CMenuModif.Enabled = True
                Me.CMenuDelete.Enabled = True
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    ''' <summary>
    ''' Barre de progession du chargement de pièce
    ''' </summary>
    ''' <param name="percent"></param>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As String = Nothing)
        Me.progressBar.Visible = True
        Me.progressBar.Value = percent
        If status IsNot Nothing Then
            '   Me.lbStatut.Text = status
            Application.DoEvents()
        End If
    End Sub

    Private Function GetDDtClotureTVA() As Nullable(Of Date)
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        Return doss.DDtClotureTVA
    End Function
#End Region

End Class
