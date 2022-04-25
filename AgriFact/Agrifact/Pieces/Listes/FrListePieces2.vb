Imports System.Data.SqlClient

Public Class FrListePieces2

    Private _Filtre As String
    Private _Type As Pieces.TypePieces = Pieces.TypePieces.VFacture
    Private _nClient As Integer = -1

    Private _CustomFilter As Boolean
    Private _IsFiltering As Boolean

    Private _ListFilter As String
    Private _FromEntreprise As Boolean = False

    Private _FromId As Decimal = -1

#Region "Constructeurs"
    Public Sub New(Optional ByVal listFilter As String = "", Optional ByVal fromEntreprise As Boolean = False)
        InitializeComponent()

        Me._ListFilter = listFilter
        Me._FromEntreprise = fromEntreprise
    End Sub

    Public Sub New(ByVal type As Pieces.TypePieces, Optional ByVal listFilter As String = "", Optional ByVal fromEntreprise As Boolean = False, Optional ByVal fromId As Decimal = -1)
        Me.New()
        Me.TypePiece = type

        Me._ListFilter = listFilter
        Me._FromEntreprise = fromEntreprise

        Me._FromId = fromId
    End Sub

    Public Sub New(ByVal type As Pieces.TypePieces, ByVal nClient As Integer, Optional ByVal listFilter As String = "", Optional ByVal fromEntreprise As Boolean = False)
        Me.New(type)
        Me.nClient = nClient

        Me._ListFilter = listFilter
        Me._FromEntreprise = fromEntreprise
    End Sub
#End Region

#Region "Props"
    Public Property FiltrePlus() As String
        Get
            Return Me._Filtre
        End Get
        Set(ByVal value As String)
            Me._Filtre = value
        End Set
    End Property

    Public Property TypePiece() As Pieces.TypePieces
        Get
            Return Me._Type
        End Get
        Set(ByVal value As Pieces.TypePieces)
            Me._Type = value
        End Set
    End Property

    Public Property nClient() As Integer
        Get
            Return Me._nClient
        End Get
        Set(ByVal value As Integer)
            Me._nClient = value
        End Set
    End Property

    Public ReadOnly Property CurrentPieceRow() As DsPieces.PiecesRow
        Get
            If Me.PiecesBindingSource.Position < 0 Then Return Nothing

            Return Cast(Of DsPieces.PiecesRow)(Cast(Of DataRowView)(Me.PiecesBindingSource.Current).Row)
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            Dim curId As Decimal = -1

            If Me.PiecesBindingSource.Position >= 0 Then
                curId = Me.CurrentPieceRow.nDevis
            End If

            'MODIF TV 16/01/2012
            Me.DsPieces = New DsPieces()

            Me.PiecesBindingSource.DataSource = Me.DsPieces
            Me.PiecesBindingSource.ResetBindings(True)
            'FIN MODIF TV 16/01/2012

            With Me.DsPieces
                .EnforceConstraints = False

                If Me.nClient > 0 Then
                    Me.PiecesTA.FillByClient(Me.DsPieces.Pieces, Me.TypePiece, Me.nClient)
                Else
                    Me.PiecesTA.Fill(Me.DsPieces.Pieces, Me.TypePiece)
                End If

                .EnforceConstraints = True
            End With

            If curId > -1 Then
                Me.PiecesBindingSource.Position = Me.PiecesBindingSource.Find("nDevis", curId)
            End If

            If Me._FromId > -1 Then
                Me.PiecesBindingSource.Position = Me.PiecesBindingSource.Find("nDevis", Me._FromId)
            End If

            Me.CalculerTotaux()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.PiecesBindingSource.EndEdit()
        If Me.DsPieces.HasChanges Then
            Try
                'On ne gère que les suppressions à ce niveau là
                Me.PiecesTA.Delete(Me.DsPieces.Pieces, Me.TypePiece)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.PiecesBindingSource.EndEdit()
        If Me.DsPieces.HasChanges Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function

    Public Shared Function CheckForChildObjects(ByVal nDevis As Decimal, ByVal type As Pieces.TypePieces) As Boolean
        Dim dtChildObjects As DsPieces.ChildObjectsDataTable
        Using dta As New DsPiecesTableAdapters.ChildObjectsTA
            dtChildObjects = dta.GetDataNDevisAndTable(nDevis, type.ToString)
        End Using
        If dtChildObjects.Count > 0 Then
            Dim s As String = Pieces.GetSexe(type)
            Dim libpiece As String = Pieces.GetLibelle(type)
            Dim msg As New System.Text.StringBuilder
            msg.AppendFormat("Ce{0} {1} est lié{2} à :" & vbCrLf, IIf(s = "F", "tte", ""), libpiece, IIf(s = "F", "e", ""))
            For Each dr As DsPieces.ChildObjectsRow In dtChildObjects
                msg.AppendFormat("  {0} {1}" & vbCrLf, dr.nb, dr._lib)
            Next
            msg.AppendFormat("Ils devront être supprimés avant de pouvoir supprimer {0} {1}.", IIf(s = "F", "la", "le"), libpiece)
            MsgBox(msg.ToString, MsgBoxStyle.Exclamation)
            Return False
        Else
            UncheckOrigine(nDevis, type)
            Return True
        End If
    End Function

    Private Shared Sub UncheckOrigine(ByVal nDevis As Decimal, ByVal type As Pieces.TypePieces)
        Dim tables() As String = {"ABonReception", "AFacture", "VDevis", "VBonCommande", "VBonLivraison"}
        Dim sql As String = "UPDATE {0} SET Paye=0,Origine=NULL,nOrigine=NULL WHERE Origine like {{1}} AND nOrigine={{0}}"
        Using s As New SqlProxy
            For Each t As String In tables
                s.ExecuteNonQuery(SqlProxy.FormatSql(String.Format(sql, t), nDevis, type.ToString))
            Next
        End Using
    End Sub

    Public Sub Filtrer()
        If Me._CustomFilter Then Exit Sub
        If Me._IsFiltering Then Exit Sub

        Dim filter As String = String.Empty

        If (Me.TbFiltrer.Checked) Then
            filter = "Paye=False"

            Dim rech As String = Me.TxRech.Text.Trim

            If rech.Length > 0 Then
                If IsNumeric(rech) Then
                    filter = FormatExpression("Convert(nFacture,'System.String') like {0}", rech & "%")
                Else
                    filter &= FormatExpression(" AND (Nom like {0} OR Observation like {0})", "%" & rech & "%")
                End If
            End If
        End If

        Me._IsFiltering = True

        If Me.PiecesBindingSource.Filter <> filter Then
            Cursor.Current = Cursors.WaitCursor
            Me.PiecesBindingSource.Filter = filter
            Me.CalculerTotaux()
            Cursor.Current = Cursors.Default
        End If

        Me._IsFiltering = False
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbFiltrer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFiltrer.CheckedChanged
        Me.Filtrer()
    End Sub

    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        If Me.DsPieces.Pieces.Count > 8000 Then Exit Sub
        Filtrer()
    End Sub

    Private Sub TxRech_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxRech.Leave
        Me.Filtrer()
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.PiecesBindingSource.Position >= 0 Then
            Me.PiecesBindingSource.EndEdit()
        End If

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.DsPieces)
            If Pieces.GetAV(Me.TypePiece) = "A" Then
                DefinitionDonnees.Instance.Fill(Me.DsPieces, "Entreprise", "Fournisseur=1 AND Inactif=0")
            Else
                DefinitionDonnees.Instance.Fill(Me.DsPieces, "Entreprise", "Client=1 AND Inactif=0")
            End If
            DefinitionDonnees.Instance.Fill(Me.DsPieces, "Personne", "TypePersonne='Commercial' AND npAfficher=0")
        End Using
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsPieces, Me.DsPieces.Pieces.TableName, Me.TypePiece.ToString)
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf Me.LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        Me._CustomFilter = True
        Me.PiecesBindingSource.Filter = strCritere
        Me.CalculerTotaux()
        Me.TbFiltrer.Checked = True
    End Sub

    Private Sub TbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewPiece()
    End Sub

    Private Sub TbRegler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRegler.ButtonClick, RéglerToolStripMenuItem.Click
        Regler()
    End Sub

    Private Sub TbDupliquer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDupliquer.Click
        Dupliquer()
    End Sub

    Private Sub TbSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSuppr.Click
        Try
            'Pas de suppression possible si pièce réglée
            If (Me.CurrentPieceRow.Paye) Then
                MsgBox("Suppression impossible, la pièce possède un règlement associé.", MsgBoxStyle.Exclamation, "")

                Exit Sub
            End If

            'Si le type de pièce est VFacture -> seule la dernière facture créée peut-être supprimée
            If (Me.TypePiece = Pieces.TypePieces.VFacture) Then
                Using NFactureTA As New DsAgrifactTableAdapters.NFactureTableAdapter
                    Dim NFactureDT As DsAgrifact.NFactureDataTable = NFactureTA.GetDataByTypePiece("VFacture")

                    If (NFactureDT.Rows.Count > 0) Then
                        Dim NFactureDR As DsAgrifact.NFactureRow = CType(NFactureDT.Rows(0), DsAgrifact.NFactureRow)

                        If Not (NFactureDR.NFacture = Me.CurrentPieceRow.nFacture) Then
                            MsgBox("Seule la dernière facture (" & NFactureDR.NFacture & ") peut-être supprimée.", MsgBoxStyle.Exclamation, "")

                            Exit Sub
                        End If
                    End If
                End Using
            End If

            If CheckForChildObjects(Me.CurrentPieceRow.nDevis, Me.TypePiece) Then
                Me.PiecesBindingSource.RemoveCurrent()
            End If
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.ButtonClick, ImprimerToolStripMenuItem.Click
        ImprimerPiece()
    End Sub

    Private Sub ImprimerDirectementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerDirectementToolStripMenuItem.Click
        ImprimerPiece(True)
    End Sub

    Private Sub ImprimerDesLettresDeRelanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerDesLettresDeRelanceToolStripMenuItem.Click, mnuRelancer.Click
        ImprimerRelance()
    End Sub

    Private Sub ExporterInformationsPourToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterInformationsPourToolStripMenuItem.Click
        Me.ExporterRelancesCSV()
    End Sub

    Private Sub ImprimerLaListeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLaListeToolStripMenuItem.Click
        ImprimerListePiece()
    End Sub

    Private Sub ImprimerLaListeParClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLaListeParClientToolStripMenuItem.Click
        ImprimerListePiece(True)
    End Sub

    Private Sub ImprimerLaListeParClientEtParCommercialToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImprimerLaListeParClientEtParCommercialToolStripMenuItem.Click
        ImprimerListePiece(False, True)
    End Sub

    Private Sub ImprimerLaListeDétailléeParClientToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImprimerLaListeDétailléeParClientToolStripMenuItem.Click
        ImprimerListePiece(True, False, True)
    End Sub

    Private Sub ImprimerLaListeDétailléeParClientAvecLesProduitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerLaListeDétailléeParClientAvecLesProduitsToolStripMenuItem.Click
        ImprimerListePiece(True, False, True, True)
    End Sub

    Private Sub CréanceIrrécouvrableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CréanceIrrécouvrableToolStripMenuItem.Click
        RegleFactureIrrecouvrable(Pieces.GetDestination(Me.TypePiece))
    End Sub

    Private Sub AffecterLesAcomptesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AffecterLesAcomptesToolStripMenuItem.Click
        Me.Regler("AffecterAcomptes")
        Me.ChargerDonnees()
    End Sub

    Private Sub GénérerDesFacturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GénérerDesFacturesToolStripMenuItem.Click
        FactureMasse()
    End Sub

    Private Sub GénérerLaCommandeFournisseurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GénérerLaCommandeFournisseurToolStripMenuItem.Click
        CreerCommandeFournisseur()
    End Sub

    Private Sub FactureGroupéeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FactureGroupéeToolStripMenuItem.Click
        FactureGroupee()
    End Sub

    Private Sub CommandeFournisseurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandeFournisseurToolStripMenuItem.Click
        MsgBox("Approfact pas encore migré")
        'TODO CreerCommandeAppro()
    End Sub

    Private Sub GénérerLesBonsDeLivraisonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GénérerLesBonsDeLivraisonToolStripMenuItem.Click
        MsgBox("Approfact pas encore migré")
        'TODO BLAppro()
    End Sub

    Private Sub GénérerLesRemisesDeFinDeCampagneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GénérerLesRemisesDeFinDeCampagneToolStripMenuItem.Click
        MsgBox("Approfact pas encore migré")
        'TODO FactureAvoirAppro()
    End Sub

    Private Sub TbTransformerPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbTransformerPiece.Click, TransformerToolStripMenuItem.Click
        TransformerPiece(Pieces.GetDestination(Me.TypePiece))
    End Sub

    Private Sub TransformerEnBCToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformerEnBCToolStripButton.Click
        Me.TransformerPiece(Pieces.TypePieces.VBonCommande)
    End Sub

    Private Sub TransformerEnBLToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformerEnBLToolStripButton.Click
        Me.TransformerPiece(Pieces.TypePieces.VBonLivraison)
    End Sub

    Private Sub TransformerEnFactureToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformerEnFactureToolStripButton.Click
        Me.TransformerPiece(Pieces.TypePieces.VFacture)
    End Sub

    Private Sub RemplacerCodeProduitToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemplacerCodeProduitToolStripButton.Click
        Me.RemplacerCodeProduit()
    End Sub
#End Region

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.PiecesDataGridView)
        AddHandler Me.PiecesDataGridView.MouseDown, AddressOf dg_GestionClicDroit
        ConfigColSel(Me.PiecesDataGridView, Me.ColSel)
        Me.ChargerDonnees()
        ConfigDataTableEvents(Me.DsPieces.Pieces, AddressOf MajBoutons)

        If Not String.IsNullOrEmpty(Me.FiltrePlus) Then
            Me.PiecesBindingSource.Filter &= " AND ( " & Me.FiltrePlus & ")"
            Me.CalculerTotaux()
        End If

        If Not (String.IsNullOrEmpty(Me._ListFilter)) Then
            Me.PiecesBindingSource.Filter = Me._ListFilter
            Me.CalculerTotaux()
        End If

        Me.ConfigInterface()
        Me.MajBoutons()

        Me.AfficherColonnes()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConfigInterface()
        Me.ImprimerDesLettresDeRelanceToolStripMenuItem.Visible = (Me.TypePiece = Pieces.TypePieces.VFacture)
        Me.mnuRelancer.Visible = (Me.TypePiece = Pieces.TypePieces.VFacture)
        Me.ImprimerLaListeParClientToolStripMenuItem.Visible = (Me.TypePiece = Pieces.TypePieces.VFacture)
        Me.GénérerDesFacturesToolStripMenuItem.Visible = (Me.TypePiece = Pieces.TypePieces.VFacture)
        Me.GénérerLaCommandeFournisseurToolStripMenuItem.Visible = Not FrApplication.Modules.ModuleApproFact AndAlso Me.TypePiece = Pieces.TypePieces.VBonCommande
        Me.FactureGroupéeToolStripMenuItem.Visible = Me.TypePiece = Pieces.TypePieces.ABonReception Or Me.TypePiece = Pieces.TypePieces.VBonLivraison

        'Approfact
        Me.CommandeFournisseurToolStripMenuItem.Visible = FrApplication.Modules.ModuleApproFact AndAlso Me.TypePiece = Pieces.TypePieces.VBonCommande
        Me.GénérerLesBonsDeLivraisonToolStripMenuItem.Visible = FrApplication.Modules.ModuleApproFact AndAlso Me.TypePiece = Pieces.TypePieces.AFacture
        Me.GénérerLesRemisesDeFinDeCampagneToolStripMenuItem.Visible = FrApplication.Modules.ModuleApproFact AndAlso Me.TypePiece = Pieces.TypePieces.VFacture

        If Me.TypePiece = Pieces.TypePieces.VFacture OrElse Me.TypePiece = Pieces.TypePieces.AFacture Then
            Me.TbRegler.Visible = FrApplication.Modules.ModuleReglement
            Me.CréanceIrrécouvrableToolStripMenuItem.Visible = FrApplication.Modules.ModuleReglement AndAlso Me.TypePiece = Pieces.TypePieces.VFacture
            Me.TbTransformerPiece.Visible = False
        Else
            Me.TbRegler.Visible = False
            Me.TbTransformerPiece.Visible = True
            Me.CréanceIrrécouvrableToolStripMenuItem.Visible = False
        End If

        'Libellés des boutons 
        Me.TbTransformerPiece.Text = Pieces.GetLibelleCourt(Pieces.GetDestination(Me.TypePiece))
        Me.TransformerToolStripMenuItem.Text = Me.TbTransformerPiece.Text

        'Gestion des boutons de transformation
        Me.ActiverBoutonsTransformation()

        'TooltipTexts
        Dim libelle As String = Pieces.GetLibelle(Me.TypePiece)
        Dim libDest As String = Pieces.GetLibelle(Pieces.GetDestination(Me.TypePiece))
        Me.Text = String.Format("Liste des {0} - {1}", Pieces.Pluriel(libelle), Pieces.Pluriel(Pieces.GetLibelleType(Me.TypePiece)))
        If Pieces.GetSexe(Me.TypePiece) = "F" Then
            Me.TbNew.ToolTipText = String.Format("Créer une nouvelle {0}", Microsoft.VisualBasic.LCase(libelle))
            Me.TbDupliquer.ToolTipText = String.Format("Dupliquer une {0}", Microsoft.VisualBasic.LCase(libelle))
            Me.TbFiltrer.ToolTipText = String.Format("Afficher toutes les {0}, y compris celles qui ont été transformées en {1}", Pieces.Pluriel(libelle).ToLower, libDest.ToLower)
            Me.TbRegler.ToolTipText = String.Format("Créer un(e) {1} à partir de cette {0}", libelle.ToLower, libDest.ToLower)
        Else
            Me.TbNew.ToolTipText = String.Format("Créer un nouveau {0}", Microsoft.VisualBasic.LCase(libelle))
            Me.TbDupliquer.ToolTipText = String.Format("Dupliquer un {0}", Microsoft.VisualBasic.LCase(libelle))
            Me.TbFiltrer.ToolTipText = String.Format("Afficher tous les {0}, y compris ceux qui ont été transformés en {1}", Pieces.Pluriel(libelle).ToLower, libDest.ToLower)
            Me.TbTransformerPiece.ToolTipText = String.Format("Créer un(e) {1} à partir de ce {0}", libelle.ToLower, libDest.ToLower)
            Me.FactureGroupéeToolStripMenuItem.ToolTipText = "Créer une facture à partir de ces " & Pieces.Pluriel(libelle).ToLower
        End If

        'Grille
        If Me.TypePiece = Pieces.TypePieces.VFacture OrElse Me.TypePiece = Pieces.TypePieces.AFacture Then

        Else
            Me.ResteDataGridViewTextBoxColumn.Visible = False
            Me.lbReste.Visible = False
            Me.DateEcheanceDataGridViewTextBoxColumn.Visible = False
        End If

        'Entrées du menu contextuel
        Me.RéglerToolStripMenuItem.Visible = TbRegler.Visible
        Me.TransformerToolStripMenuItem.Visible = TbTransformerPiece.Visible
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.DsPieces.HasChanges
        'If Me.CurrentPieceRow IsNot Nothing Then
        '    Me.TbSuppr.Enabled = Not Me.CurrentPieceRow.Paye
        'Else
        '    Me.TbSuppr.Enabled = False
        'End If
    End Sub

    Private Sub CreateNewPiece()
        Dim fr As New FrBonCommande(True, Me.PiecesBindingSource.Filter, Me._FromEntreprise)

        fr.MdiParent = Me.ParentForm
        fr.TypePiece = Me.TypePiece
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        'fr.ShowDialog()
        fr.Show()

        'Ajout TV 10/10/2011
        Me.Close()
    End Sub

    Private Sub OpenCurrentPiece()
        If Me.PiecesBindingSource.Position < 0 Then Exit Sub

        Dim fr As New FrBonCommande(CInt(Me.CurrentPieceRow.nDevis), True, Me.PiecesBindingSource.Filter, Me._FromEntreprise)

        fr.TypePiece = Me.TypePiece

        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = Me.WindowState
        End If

        fr.Show()

        'Ajour TV 10/10/2011
        Me.Close()
    End Sub

    Private Function PieceNotPaye(ByVal dr As DataRow) As Boolean
        Return dr.IsNull("Paye") OrElse CBool(dr("Paye")) = False
    End Function

    Private Function PiecePaye(ByVal dr As DataRow) As Boolean
        Return Not dr.IsNull("Paye") AndAlso CBool(dr("Paye"))
    End Function

    Private Sub CalculerTotaux()
        Dim res As Object = Me.DsPieces.Pieces.Compute("Sum(MontantTTC)", Me.PiecesBindingSource.Filter)

        If Not IsDBNull(res) Then
            Me.lbTotal.Text = String.Format("Total : {0:C2}", res)
        Else
            Me.lbTotal.Text = ""
        End If

        Dim resReste As Object = Me.DsPieces.Pieces.Compute("Sum(Reste)", Me.PiecesBindingSource.Filter)

        If Not IsDBNull(resReste) Then
            Me.lbReste.Text = String.Format("Reste : {0:C2}", resReste)
        Else
            Me.lbReste.Text = ""
        End If
    End Sub

    Private Sub ActiverBoutonsTransformation()
        Select Case Me.TypePiece
            Case Pieces.TypePieces.VDevis
                Me.TransformerEnBCToolStripButton.Visible = True
                Me.TransformerEnBLToolStripButton.Visible = True
                Me.TransformerEnFactureToolStripButton.Visible = True
                Me.TbTransformerPiece.Visible = False
            Case Pieces.TypePieces.VBonCommande
                Me.TransformerEnBCToolStripButton.Visible = False
                Me.TransformerEnBLToolStripButton.Visible = True
                Me.TransformerEnFactureToolStripButton.Visible = True
                Me.TbTransformerPiece.Visible = False
            Case Pieces.TypePieces.VBonLivraison
                Me.TransformerEnBCToolStripButton.Visible = False
                Me.TransformerEnBLToolStripButton.Visible = False
                Me.TransformerEnFactureToolStripButton.Visible = True
                Me.TbTransformerPiece.Visible = False
            Case Pieces.TypePieces.VFacture
                Me.TransformerEnBCToolStripButton.Visible = False
                Me.TransformerEnBLToolStripButton.Visible = False
                Me.TransformerEnFactureToolStripButton.Visible = False
                Me.TbTransformerPiece.Visible = False
            Case Else
                Me.TransformerEnBCToolStripButton.Visible = False
                Me.TransformerEnBLToolStripButton.Visible = False
                Me.TransformerEnFactureToolStripButton.Visible = False
                Me.TbTransformerPiece.Visible = True
        End Select
    End Sub

    Private Sub AfficherColonnes()
        Using ColonneListeTA As New ColonneListeDataSetTableAdapters.ColonneListeTableAdapter
            For Each column As DataGridViewColumn In Me.PiecesDataGridView.Columns
                Dim ColonneListeDT As ColonneListeDataSet.ColonneListeDataTable = ColonneListeTA.GetDataByTypeListeEtTypePieceEtDataPropertyName("Pièces", Me.TypePiece.ToString(), column.DataPropertyName)

                If (ColonneListeDT.Rows.Count > 0) Then
                    Dim ColonneListeDR As ColonneListeDataSet.ColonneListeRow = CType(ColonneListeDT.Rows(0), ColonneListeDataSet.ColonneListeRow)

                    column.Visible = ColonneListeDR.Visible

                    If Not (ColonneListeDR.IsWidthNull) Then
                        If (ColonneListeDR.Width > 0) Then
                            column.Width = ColonneListeDR.Width
                        End If
                    End If
                End If
            Next
        End Using
    End Sub

    Private Sub RemplacerCodeProduit()
        If Me.PiecesBindingSource.Position < 0 Then Exit Sub

        Dim listeNFactureNonTraites As New List(Of String)
        Dim listeDR As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)

        'Récupération de la liste des nDevis sélectionnés
        Dim lstNDevis As New List(Of String)

        For Each dr As DataRow In listeDR
            lstNDevis.Add(Convert.ToString(dr("nDevis")))
        Next

        Dim ds As New DataSet
        Dim sqlQuery As String = String.Empty
        Dim listeNDevisATraiter As New List(Of String)

        Using s As New SqlProxy
            s.FillBy(ds, Me.TypePiece.ToString(), "nDevis IN (" & String.Join(",", lstNDevis.ToArray()) & ")", False)

            For Each dr As DataRow In ds.Tables(Me.TypePiece.ToString()).Rows
                'Vérifie que la pièce n'est pas imprimée
                If (ds.Tables(Me.TypePiece.ToString()).Columns.Contains("DateImpr")) Then
                    If Not (dr.IsNull("DateImpr")) Then
                        listeNFactureNonTraites.Add(CStr(dr.Item("nFacture")))

                        Continue For
                    End If
                End If

                'Vérifie que la pièce n'est pas exportée en compta
                If (ds.Tables(Me.TypePiece.ToString()).Columns.Contains("ExportCompta")) Then
                    If (CBool(dr.Item("ExportCompta"))) Then
                        listeNFactureNonTraites.Add(CStr(dr.Item("nFacture")))

                        Continue For
                    End If
                End If

                listeNDevisATraiter.Add(CStr(dr.Item("nDevis")))
            Next
        End Using

        Using fr As New FrRemplacerCodeProduitPiece(listeNDevisATraiter, Me.TypePiece)
            If (fr.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                If (listeNFactureNonTraites.Count > 0) Then
                    MsgBox("Traitement terminé mais certaines pièces n'ont pu être traitées car elles sont soit imprimées, soit exportées en comptabilité, soit les deux (" & String.Join(",", listeNFactureNonTraites.ToArray()) & ").", MsgBoxStyle.Information, "")
                Else
                    MsgBox("Traitement terminé.", MsgBoxStyle.Information, "")
                End If
            End If
        End Using
    End Sub
#End Region

#Region " Control events "
    Private Sub PiecesDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PiecesDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentPiece()
            e.Handled = True
        End If
    End Sub

    Private Sub PiecesDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PiecesDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Me.ColSel.Index Then
        ElseIf e.ColumnIndex = Me.ColImageEtat.Index Then
            'Action spéciale
            Select Case Me.TypePiece
                Case Pieces.TypePieces.AFacture
                    Regler("AReglement")
                Case Pieces.TypePieces.VFacture
                    Regler()
                Case Pieces.TypePieces.ABonReception, Pieces.TypePieces.VDevis, Pieces.TypePieces.VBonCommande, Pieces.TypePieces.VBonLivraison
                    Me.TransformerPiece(Pieces.GetDestination(Me.TypePiece))
            End Select
        Else
            OpenCurrentPiece()
        End If
    End Sub

    Private Sub PiecesDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles PiecesDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In Me.PiecesDataGridView.Rows
                If r.DataBoundItem IsNot Nothing Then
                    Dim drv As DataRowView = Cast(Of DataRowView)(r.DataBoundItem)
                    Dim cellEtat As DataGridViewImageCell = Cast(Of DataGridViewImageCell)(r.Cells(Me.ColImageEtat.Index))
                    If Me.TypePiece = Pieces.TypePieces.VFacture Then
                        'Cas spécial des factures de ventes
                        If CBool(ParametresApplication.ValeurParametre("MarquerFacturesImprimees", True)) AndAlso IsDBNull(drv("DateImpr")) Then
                            r.DefaultCellStyle.ForeColor = Color.Red
                            cellEtat.Value = My.Resources.impr
                            cellEtat.ToolTipText = "La facture n'a pas été imprimée"
                        ElseIf CBool(drv("Paye")) Then
                            r.DefaultCellStyle.ForeColor = SystemColors.GrayText
                            cellEtat.Value = My.Resources.complete16
                        ElseIf Not IsDBNull(drv("DateEcheance")) AndAlso CDate(drv("DateEcheance")) < Today Then
                            r.Cells(Me.DateEcheanceDataGridViewTextBoxColumn.Index).Style.ForeColor = Color.Red
                            cellEtat.Value = My.Resources.warning16
                            cellEtat.ToolTipText = "La date d'échéance est dépassée"
                        ElseIf FrApplication.Modules.ModuleReglement Then
                            cellEtat.Value = My.Resources.Finance16
                            cellEtat.ToolTipText = "La facture est en attente de réglement"
                        End If
                    Else
                        'Pour tout le reste
                        If CBool(drv("Paye")) Then
                            r.DefaultCellStyle.ForeColor = SystemColors.GrayText
                            cellEtat.Value = My.Resources.complete16
                        Else
                            cellEtat.Value = My.Resources.Compta
                            cellEtat.ToolTipText = "Transformer"
                        End If
                    End If

                End If
            Next
        End If
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If Not (e Is Nothing) Then
            Select Case e.CloseReason
                Case CloseReason.None, CloseReason.UserClosing
                    If Not Me.IsDisposed Then Me.ChargerDonnees()
            End Select
        Else
            If Not Me.IsDisposed Then Me.ChargerDonnees()
        End If
    End Sub
#End Region

#Region "Impression"
    Private Sub ImprimerListePiece(Optional ByVal ParClient As Boolean = False, Optional ByVal ParCom As Boolean = False, Optional ByVal Detail As Boolean = False, Optional ByVal Produit As Boolean = False)
        Dim myDs As New DataSet
        With myDs
            .EnforceConstraints = False
            Dim drs As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
            If drs.Count = 0 Then
                .Merge(Me.DsPieces.Pieces.Select(Me.PiecesBindingSource.Filter))
            Else
                .Merge(drs.ToArray)
            End If
            Dim nDeviss As New List(Of String)

            If (myDs.Tables.Contains("Pieces")) Then
                For Each dr As DataRow In myDs.Tables("Pieces").Rows
                    nDeviss.Add(Convert.ToString(dr("nDevis")))
                Next
                myDs.Tables("Pieces").TableName = Me.TypePiece.ToString
                Dim where As String = " nDevis IN (" & String.Join(",", nDeviss.ToArray) & ")"
                Using s As New SqlProxy
                    DefinitionDonnees.Instance.Fill(myDs, Me.TypePiece.ToString & "_Detail", s, where)
                    DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s)
                    If Me.TypePiece = Pieces.TypePieces.VFacture Then
                        DefinitionDonnees.Instance.Fill(myDs, "Reglement", s)
                        DefinitionDonnees.Instance.Fill(myDs, "Reglement_Detail", s)
                    End If
                End Using
            End If
        End With
        Try
            Dim nomRapport As String = String.Format("RptListe{0}{1}{2}{3}.rpt", Me.TypePiece.ToString, IIf(Detail, "Detaillee", ""), IIf(ParClient, "ParClient", IIf(ParCom, "ParClientParCom", "")), IIf(Produit, "Produit", ""))
            Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, nomRapport)
            fr.TypePiece = Pieces.GetLibelle(Me.TypePiece)
            fr.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ImprimerRelance()
        If Me.TypePiece <> Pieces.TypePieces.VFacture Then Exit Sub

        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        If lstFacture.Count = 0 Then
            MsgBox("Vous devez sélectionner au moins une pièce.", MsgBoxStyle.Exclamation, "Sélection")
            Exit Sub
        End If
        If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
            MsgBox("Vous ne devez sélectionner que des pièces non réglées.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim lstNDevis As New List(Of Integer)
        For Each rw As DataRow In lstFacture
            lstNDevis.Add(CInt(rw("nDevis")))
        Next
        ImprimerRelance(lstNDevis)

        SetSelectedAll(Me.PiecesDataGridView, False)
        Me.PiecesBindingSource.ResetBindings(False)
    End Sub

    Public Shared Function ToStringArray(ByVal a() As Integer) As String()
        Dim res(a.Length - 1) As String
        For i As Integer = 0 To a.Length - 1
            res(i) = Convert.ToString(a(i))
        Next
        Return res
    End Function

    Public Shared Sub ImprimerRelance(ByVal lstNDevis As List(Of Integer))
        'TODO : A gérer dans le rapport les pertes & profits
        Dim myDs As New DataSet
        With myDs
            .EnforceConstraints = False
            Dim where As String = " {0} IN (" & String.Join(",", ToStringArray(lstNDevis.ToArray)) & ")"
            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(myDs, "Parametres", s, "Cle='Logo'")
                DefinitionDonnees.Instance.Fill(myDs, "VFacture", s, String.Format(where, "nDevis"))
                DefinitionDonnees.Instance.Fill(myDs, "VFacture_Detail", s, String.Format(where, "nDevis"))
                DefinitionDonnees.Instance.Fill(myDs, "Reglement_Detail", s, String.Format(where, "nFacture"))
                DefinitionDonnees.Instance.Fill(myDs, "Reglement", s, String.Format("nReglement IN (SELECT nReglement FROM Reglement_Detail WHERE {0})", String.Format(where, "nFacture")))
            End Using
        End With

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptLettreRelance.rpt")
        If Not fr Is Nothing Then
            GestionImpression.AppliquerParametres(fr)
            GestionImpression.GestionLogo(fr)
            fr.ShowDialog()
        End If

        If MsgBox("Voulez-vous marquer les factures relancées ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Infos") = MsgBoxResult.Yes Then
            Using s As New SqlProxy
                Dim sql As String = "UPDATE VFacture SET nRelance= CASE WHEN nRelance IS NULL THEN 1 ELSE nRelance+1 END,DateRelance={1} WHERE nDevis={0}"
                For Each rwTmp As DataRow In myDs.Tables("VFacture").Rows
                    s.ExecuteNonQuery(SqlProxy.FormatSql(sql, rwTmp("nDevis"), Today))
                Next
            End Using
        End If
    End Sub

    Private Sub ExporterRelancesCSV()
        If Me.TypePiece <> Pieces.TypePieces.VFacture Then Exit Sub

        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)

        If lstFacture.Count = 0 Then
            MsgBox("Vous devez sélectionner au moins une pièce.", MsgBoxStyle.Exclamation, "Sélection")

            Exit Sub
        End If

        If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
            MsgBox("Vous ne devez sélectionner que des pièces non réglées.", MsgBoxStyle.Exclamation)

            Exit Sub
        End If

        Dim lstNDevis As New List(Of Integer)

        For Each rw As DataRow In lstFacture
            lstNDevis.Add(CInt(rw("nDevis")))
        Next

        Me.ExporterRelancesCSV(lstNDevis)

        SetSelectedAll(Me.PiecesDataGridView, False)
        Me.PiecesBindingSource.ResetBindings(False)
    End Sub

    Public Sub ExporterRelancesCSV(ByVal lstNDevis As List(Of Integer))
        'TODO : A gérer dans le rapport les pertes & profits
        With Me.SaveFileDialog1
            .Filter = "(*.csv)|*.csv"

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim ds As New DataSet
                Dim queryString As String = String.Empty

                'queryString = "SELECT Entreprise.Nom, CAST(Entreprise.Adresse AS VARCHAR) AS Adresse, " & _
                '            "Entreprise.CodePostal, Entreprise.Ville, VFacture.nFacture, " & _
                '            "CONVERT(VARCHAR, VFacture.DateFacture, 103) AS DateFacture, COALESCE (VFacture.MontantTTC, 0) AS MontantFactureTTC, " & _
                '            "COALESCE (VFacture.MontantTTC, 0) - COALESCE (dbo.Reglement_Detail.Montant, 0) AS ResteARegler " & _
                '            "FROM Entreprise INNER JOIN VFacture ON Entreprise.nEntreprise = VFacture.nClient " & _
                '            "LEFT OUTER JOIN Reglement_Detail ON VFacture.nDevis = Reglement_Detail.nFacture " & _
                '            "WHERE (VFacture.nDevis IN (" & String.Join(",", ToStringArray(lstNDevis.ToArray)) & ")) " & _
                '            "GROUP BY Entreprise.Nom, Entreprise.CodePostal, Entreprise.Ville, " & _
                '            "VFacture.nFacture, VFacture.DateFacture, VFacture.MontantTTC, " & _
                '            "Reglement_Detail.Montant, CAST(Entreprise.Adresse AS VARCHAR)"

                queryString = "SELECT Entreprise.Nom, CAST(Entreprise.Adresse AS VARCHAR) AS Adresse, " & _
                                            "Entreprise.CodePostal, Entreprise.Ville, VFacture.nFacture, " & _
                                            "CONVERT(VARCHAR, VFacture.DateFacture, 103) AS DateFacture,CONVERT(VARCHAR, VFacture.DateEcheance, 103) AS DateEcheance, COALESCE (VFacture.MontantTTC, 0) AS MontantFactureTTC, " & _
                                            "COALESCE (VFacture.MontantTTC, 0) - COALESCE (dbo.Reglement_Detail.Montant, 0) AS ResteARegler, Entreprise.EMail, " & _
                                            "Contacts = STUFF((SELECT ' - ' + Nom +' '+Prenom FROM Personne WHERE Personne.nEntreprise = Entreprise.nEntreprise FOR XML PATH ('')),1,2,''), " & _
                                            "Telephones = STUFF((SELECT ' - ' + Type +' '+Numero FROM TelephoneEntreprise WHERE TelephoneEntreprise.nEntreprise = Entreprise.nEntreprise AND Type NOT LIKE '%mail%' AND Type NOT LIKE '%fax%' FOR XML PATH ('')),1,2,'') " & _
                                            "FROM Entreprise INNER JOIN VFacture ON Entreprise.nEntreprise = VFacture.nClient " & _
                                            "LEFT OUTER JOIN Reglement_Detail ON VFacture.nDevis = Reglement_Detail.nFacture " & _
                                            "WHERE (VFacture.nDevis IN (" & String.Join(",", ToStringArray(lstNDevis.ToArray)) & ")) " & _
                                            "GROUP BY Entreprise.EMail,Entreprise.Nom, Entreprise.CodePostal, Entreprise.Ville, " & _
                                            "VFacture.nFacture, VFacture.DateFacture,VFacture.DateEcheance, VFacture.MontantTTC, " & _
                                            "Reglement_Detail.Montant, CAST(Entreprise.Adresse AS VARCHAR), Entreprise.nEntreprise"
                'SELECT nEntreprise, Nom, Prenom FROM Personne ORDER BY nEntreprise

                'SELECT nEntreprise, Type, Numero FROM TelephoneEntreprise WHERE Type NOT LIKE '%mail%' AND Type NOT LIKE '%fax%' ORDER BY nEntreprise

                Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                    sqlConn.Open()

                    Using sqlComm As New SqlCommand(queryString, sqlConn)
                        Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()

                        sqlDA.SelectCommand = sqlComm

                        sqlDA.Fill(ds, "Relance")
                    End Using
                End Using

                'Création fichier CSV à partir du DataGridView
                Dim expCsv As New Utilitaires.ExportCsv(ds.Tables("Relance"), Utilitaires.ExportCsv.SeparateurEnum.POINTVIRGULE, True, .FileName)

                expCsv.Exporter()

                MsgBox("Création du fichier terminé.", MsgBoxStyle.Information, "")
            End If
        End With

        If MsgBox("Voulez-vous marquer les factures relancées ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Infos") = MsgBoxResult.Yes Then
            Dim myDs As New DataSet

            With myDs
                .EnforceConstraints = False
                Dim where As String = " {0} IN (" & String.Join(",", ToStringArray(lstNDevis.ToArray)) & ")"
                Using s As New SqlProxy
                    DefinitionDonnees.Instance.Fill(myDs, "Parametres", s, "Cle='Logo'")
                    DefinitionDonnees.Instance.Fill(myDs, "VFacture", s, String.Format(where, "nDevis"))
                    DefinitionDonnees.Instance.Fill(myDs, "VFacture_Detail", s, String.Format(where, "nDevis"))
                    DefinitionDonnees.Instance.Fill(myDs, "Reglement_Detail", s, String.Format(where, "nFacture"))
                    DefinitionDonnees.Instance.Fill(myDs, "Reglement", s, String.Format("nReglement IN (SELECT nReglement FROM Reglement_Detail WHERE {0})", String.Format(where, "nFacture")))
                End Using
            End With

            Using s As New SqlProxy
                Dim sql As String = "UPDATE VFacture SET nRelance= CASE WHEN nRelance IS NULL THEN 1 ELSE nRelance+1 END,DateRelance={1} WHERE nDevis={0}"
                For Each rwTmp As DataRow In myDs.Tables("VFacture").Rows
                    s.ExecuteNonQuery(SqlProxy.FormatSql(sql, rwTmp("nDevis"), Today))
                Next
            End Using
        End If
    End Sub

    'Private Sub ImprimerPiece(Optional ByVal direct As Boolean = False)
    '    Dim lstFactures As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)

    '    If lstFactures.Count = 0 Then
    '        MsgBox("Vous devez sélectionner au moins une pièce.", MsgBoxStyle.Exclamation, "Sélection")
    '        Exit Sub
    '    End If

    '    Dim myDs As DataSet = Pieces.PreparerDataset(Me.TypePiece)
    '    Dim myDsTTC As DataSet = Pieces.PreparerDataset(Me.TypePiece)
    '    Dim _NomTableReglement As String = CStr(IIf(Me.TypePiece = Pieces.TypePieces.VFacture, "Reglement", "AReglement"))

    '    Using s As New SqlProxy
    '        For Each rw As DataRow In lstFactures
    '            Dim nDevis As Long = CLng(rw("nDevis"))
    '            Dim nClient As Long = CLng(rw("nClient"))
    '            Dim d As DataSet

    '            If rw.IsNull("FacturationTTC") OrElse Not CBool(rw("FacturationTTC")) Then
    '                d = myDs
    '            Else
    '                d = myDsTTC
    '            End If

    '            s.FillBy(d, "Entreprise", "nEntreprise=" & nClient, False)
    '            s.FillBy(d, Me.TypePiece.ToString, "nDevis=" & nDevis, False)
    '            s.FillBy(d, Me.TypePiece.ToString & "_Detail", "nDevis=" & nDevis, False)

    '            Select Case Me.TypePiece
    '                Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
    '                    s.FillBy(d, _NomTableReglement & "_Detail", "nFacture=" & nDevis, False)
    '                    s.FillBy(d, _NomTableReglement, String.Format("nReglement IN (SELECT nReglement FROM {0}_Detail WHERE nFacture={1})", _NomTableReglement, nDevis), False)
    '            End Select
    '        Next
    '    End Using

    '    If myDs.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
    '        ImprimerPieces(myDs, Me.TypePiece.ToString, False, direct)
    '    End If

    '    If myDsTTC.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
    '        ImprimerPieces(myDsTTC, Me.TypePiece.ToString, True, direct)
    '    End If
    'End Sub

    Private Sub ImprimerPiece(Optional ByVal direct As Boolean = False)
        Dim lstFactures As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        Dim _NomTableReglement As String = CStr(IIf(Me.TypePiece = Pieces.TypePieces.VFacture, "Reglement", "AReglement"))

        If lstFactures.Count = 0 Then
            MsgBox("Vous devez sélectionner au moins une pièce.", MsgBoxStyle.Exclamation, "Sélection")
            Exit Sub
        End If

        'Recherche de la valeur du paramètre "UtiliserModelesImpServices"
        Dim ds As New DataSet
        Dim utiliserModelesImpServices As Boolean = False

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
        End Using

        utiliserModelesImpServices = CBool((ParametresBase.GetValeur(ds, "UtiliserModelesImpServices", Nothing, "False")))

        'gestion de l'impression en fonction du paramètre "UtiliserModelesImpServices"
        If (utiliserModelesImpServices) Then
            Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                sqlConn.Open()

                Me.ImprimerPiecesAvecPriseEnCompteSecteur(lstFactures, _NomTableReglement, sqlConn, direct)
            End Using
        Else
            Me.ImprimerPiecesSansPriseEnCompteSecteur(lstFactures, _NomTableReglement, direct)
        End If
    End Sub

    Private Sub ImprimerPiecesAvecPriseEnCompteSecteur(ByVal lstFactures As List(Of DataRow), ByVal _NomTableReglement As String, ByVal sqlConn As SqlConnection, Optional ByVal direct As Boolean = False)
        Me.ImprimerPiecesAvecSecteur(lstFactures, _NomTableReglement, sqlConn, direct)
        Me.ImprimerPiecesSansSecteur(lstFactures, _NomTableReglement, sqlConn, direct)
    End Sub

    Private Sub ImprimerPiecesAvecSecteur(ByVal lstFactures As List(Of DataRow), ByVal _NomTableReglement As String, ByVal sqlConn As SqlConnection, Optional ByVal direct As Boolean = False)
        Using s As New SqlProxy
            Using listeChoixTA As New DsAgrifactTableAdapters.ListeChoixTableAdapter
                listeChoixTA.Connection.ConnectionString = sqlConn.ConnectionString

                'On parcours la liste des secteurs 
                Dim listeChoixDT As DsAgrifact.ListeChoixDataTable = listeChoixTA.GetDataByNomChoix("ListeSecteur")

                For Each listeChoixDR As DsAgrifact.ListeChoixRow In listeChoixDT.Rows
                    Dim myDs As DataSet = Pieces.PreparerDataset(Me.TypePiece)
                    Dim myDsTTC As DataSet = Pieces.PreparerDataset(Me.TypePiece)
                    Dim secteur As String = String.Empty

                    For Each rw As DataRow In lstFactures
                        Dim ds As New DataSet
                        Dim nDevis As Long = CLng(rw("nDevis"))
                        Dim nClient As Long = CLng(rw("nClient"))
                        Dim d As DataSet = Nothing

                        'recherche des infos de la pièce
                        Dim drPiece As DataRow = Me.GetInfosPiece(nDevis, sqlConn)

                        If Not (drPiece Is Nothing) Then
                            If Not (drPiece.IsNull("Secteur")) Then
                                secteur = CStr(drPiece.Item("Secteur"))

                                If (secteur = listeChoixDR.Valeur) Then
                                    If rw.IsNull("FacturationTTC") OrElse Not CBool(rw("FacturationTTC")) Then
                                        d = myDs
                                    Else
                                        d = myDsTTC
                                    End If

                                    s.FillBy(d, "Entreprise", "nEntreprise=" & nClient, False)
                                    s.FillBy(d, Me.TypePiece.ToString, "nDevis=" & nDevis, False)
                                    s.FillBy(d, Me.TypePiece.ToString & "_Detail", "nDevis=" & nDevis, False)

                                    If String.Compare(Me.TypePiece.ToString, "VFacture") = 0 Then 'legrain modif 8/10/2013
                                        s.FillBy(d, "VBonLivraison", "nOrigine=" & nDevis, False)
                                    End If

                                    Select Case Me.TypePiece
                                        Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
                                            s.FillBy(d, _NomTableReglement & "_Detail", "nFacture=" & nDevis, False)
                                            s.FillBy(d, _NomTableReglement, String.Format("nReglement IN (SELECT nReglement FROM {0}_Detail WHERE nFacture={1})", _NomTableReglement, nDevis), False)

                                            'Chargement du prescripteur
                                            s.FillBy(myDs, "Entreprise", String.Format("(nEntreprise=(SELECT nPrescripteur FROM {0} WHERE (nDevis={1})))", Me.TypePiece.ToString(), nDevis), False)
                                    End Select
                                End If
                            End If
                        End If
                    Next

                    If myDs.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
                        ImprimerPieces(myDs, Me.TypePiece.ToString, False, direct, secteur)
                    End If

                    If myDsTTC.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
                        ImprimerPieces(myDsTTC, Me.TypePiece.ToString, True, direct, secteur)
                    End If
                Next
            End Using
        End Using
    End Sub

    Private Sub ImprimerPiecesSansSecteur(ByVal lstFactures As List(Of DataRow), ByVal _NomTableReglement As String, ByVal sqlConn As SqlConnection, Optional ByVal direct As Boolean = False)
        Dim myDs As DataSet = Pieces.PreparerDataset(Me.TypePiece)
        Dim myDsTTC As DataSet = Pieces.PreparerDataset(Me.TypePiece)

        Using s As New SqlProxy
            For Each rw As DataRow In lstFactures
                Dim nDevis As Long = CLng(rw("nDevis"))
                Dim nClient As Long = CLng(rw("nClient"))
                Dim d As DataSet = Nothing
                Dim secteur As String = String.Empty
                Dim ds As New DataSet

                'recherche des infos de la pièce
                Dim drPiece As DataRow = Me.GetInfosPiece(nDevis, sqlConn)

                If Not (drPiece Is Nothing) Then
                    If Not (drPiece.IsNull("Secteur")) Then
                        secteur = CStr(drPiece.Item("Secteur"))
                    End If

                    If (secteur = String.Empty) Then
                        If rw.IsNull("FacturationTTC") OrElse Not CBool(rw("FacturationTTC")) Then
                            d = myDs
                        Else
                            d = myDsTTC
                        End If

                        s.FillBy(d, "Entreprise", "nEntreprise=" & nClient, False)
                        s.FillBy(d, Me.TypePiece.ToString, "nDevis=" & nDevis, False)
                        s.FillBy(d, Me.TypePiece.ToString & "_Detail", "nDevis=" & nDevis, False)

                        If String.Compare(Me.TypePiece.ToString, "VFacture") = 0 Then 'legrain modif 8/10/2013
                            s.FillBy(d, "VBonLivraison", "nOrigine=" & nDevis, False)
                        End If

                        Select Case Me.TypePiece
                            Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
                                s.FillBy(d, _NomTableReglement & "_Detail", "nFacture=" & nDevis, False)
                                s.FillBy(d, _NomTableReglement, String.Format("nReglement IN (SELECT nReglement FROM {0}_Detail WHERE nFacture={1})", _NomTableReglement, nDevis), False)

                                'Chargement du prescripteur
                                s.FillBy(myDs, "Entreprise", String.Format("(nEntreprise=(SELECT nPrescripteur FROM {0} WHERE (nDevis={1})))", Me.TypePiece.ToString(), nDevis), False)
                        End Select
                    End If
                End If
            Next

            If myDs.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
                ImprimerPieces(myDs, Me.TypePiece.ToString, False, direct)
            End If

            If myDsTTC.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
                ImprimerPieces(myDsTTC, Me.TypePiece.ToString, True, direct)
            End If
        End Using
    End Sub

    Private Sub ImprimerPiecesSansPriseEnCompteSecteur(ByVal lstFactures As List(Of DataRow), ByVal _NomTableReglement As String, Optional ByVal direct As Boolean = False)
        Dim myDs As DataSet = Pieces.PreparerDataset(Me.TypePiece)
        Dim myDsTTC As DataSet = Pieces.PreparerDataset(Me.TypePiece)

        Using s As New SqlProxy
            For Each rw As DataRow In lstFactures
                Dim nDevis As Long = CLng(rw("nDevis"))
                Dim nClient As Long = CLng(rw("nClient"))
                Dim d As DataSet

                If rw.IsNull("FacturationTTC") OrElse Not CBool(rw("FacturationTTC")) Then
                    d = myDs
                Else
                    d = myDsTTC
                End If

                s.FillBy(d, "Entreprise", "nEntreprise=" & nClient, False)
                s.FillBy(d, Me.TypePiece.ToString, "nDevis=" & nDevis, False)
                s.FillBy(d, Me.TypePiece.ToString & "_Detail", "nDevis=" & nDevis, False)

                If String.Compare(Me.TypePiece.ToString, "VFacture") = 0 Then 'legrain modif 8/10/2013
                    s.FillBy(d, "VBonLivraison", "nOrigine=" & nDevis, False)
                End If

                Select Case Me.TypePiece
                    Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
                        s.FillBy(d, _NomTableReglement & "_Detail", "nFacture=" & nDevis, False)
                        s.FillBy(d, _NomTableReglement, String.Format("nReglement IN (SELECT nReglement FROM {0}_Detail WHERE nFacture={1})", _NomTableReglement, nDevis), False)

                        'Chargement du prescripteur
                        s.FillBy(myDs, "Entreprise", String.Format("(nEntreprise=(SELECT nPrescripteur FROM {0} WHERE (nDevis={1})))", Me.TypePiece.ToString(), nDevis), False)
                End Select
            Next
        End Using

        If myDs.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
            ImprimerPieces(myDs, Me.TypePiece.ToString, False, direct)
        End If

        If myDsTTC.Tables(Me.TypePiece.ToString).Rows.Count > 0 Then
            ImprimerPieces(myDsTTC, Me.TypePiece.ToString, True, direct)
        End If
    End Sub

    Private Function GetInfosPiece(ByVal nDevis As Long, ByVal sqlConn As SqlConnection) As DataRow
        Dim ds As New DataSet
        Dim queryString As String = "SELECT * FROM " & Me.TypePiece.ToString & " WHERE nDevis = " & nDevis
        Dim dr As DataRow = Nothing

        Using sqlComm As New SqlCommand(queryString, sqlConn)
            Dim sqlDA As New SqlDataAdapter(sqlComm)

            sqlDA.Fill(ds, "InfosPiece")
        End Using

        If (ds.Tables("InfosPiece").Columns.Contains("Secteur")) Then
            If (ds.Tables("InfosPiece").Rows.Count > 0) Then
                dr = ds.Tables("InfosPiece").Rows(0)
            End If
        End If

        Return dr
    End Function

    Private Sub ImprimerPieces(ByVal myDs As DataSet, ByVal nomTable As String, ByVal impressionTTC As Boolean, Optional ByVal direct As Boolean = False, Optional ByVal secteur As String = "")
        If Not myDs Is Nothing Then
            'Calculer l'encours pour chaque client ayant une pièce et le stocker dans la table Entreprise
            If nomTable = "VFacture" Then
                Pieces.AjouterCompteClient(myDs, nomTable)

                'Recap TVA redevance
                Pieces.RemplirVFacture_Detail_Redevance(myDs)
            End If

            '*Gestion Taux de TVA Multiple
            Pieces.RemplisDetailTVA(myDs)
        End If

        Dim fr As GRC.FrFusion = Pieces.TrouverRapport(myDs, nomTable, impressionTTC, , FrApplication.Modules.ModuleGestionMarge, secteur)
        If Not fr Is Nothing Then
            If nomTable <> "ABonReception" Then
                GestionImpression.AppliquerParametres(fr, nomTable)
            End If
            GestionImpression.GestionLogo(fr)
            If direct Then
                fr.ImprimerDirectSimple()
                ImpressionFactureClosed(fr, Nothing)
                fr.Dispose()
            Else
                If nomTable = "VFacture" Then AddHandler fr.Closed, AddressOf ImpressionFactureClosed
                fr.Show()
            End If
        End If
    End Sub

    Private Sub ImpressionFactureClosed(ByVal sender As Object, ByVal e As EventArgs)
        'Gestion de l'option marquer : jamais/demander
        If Not CBool(ParametresApplication.ValeurParametre("MarquerFacturesImprimees", True)) Then Exit Sub
        If Me.TypePiece <> Pieces.TypePieces.VFacture Then Exit Sub
        Dim myDs As DataSet = CType(CType(sender, GRC.FrFusion).Datasource, DataSet)
        If Not myDs.Tables(Me.TypePiece.ToString).Columns.Contains("DateImpr") Then Exit Sub

        'Si toutes les factures sont déjà marquées, on se barre
        Dim [continue] As Boolean = False
        For Each dr As DataRow In myDs.Tables(Me.TypePiece.ToString).Rows
            If IsDBNull(dr("DateImpr")) Then
                [continue] = True
                Exit For
            End If
        Next
        If Not [continue] Then Exit Sub

        'Demander s'il faut marquer les factures
        If MsgBox("Voulez-vous marquer les factures comme imprimées ?", MsgBoxStyle.YesNo, "Impression") = MsgBoxResult.No Then Exit Sub

        Using s As New SqlProxy
            Dim sql As String = String.Format("UPDATE {0} SET DateImpr={{0}} WHERE nDevis={{1}} AND DateImpr IS NULL", Me.TypePiece.ToString)
            For Each dr As DataRow In myDs.Tables(Me.TypePiece.ToString).Rows
                s.ExecuteNonQuery(SqlProxy.FormatSql(sql, Now, dr("nDevis")))
            Next
        End Using

        'Mise à jour de l'affichage
        Me.PiecesBindingSource.ResetBindings(False)
    End Sub
#End Region

#Region "Fonctions sur sélection"

#Region "Approfact"
    'Private Sub CreerCommandeAppro()
    '    Dim nDevis As Integer = GestionApproFact.GenererAchatAppro(Me.ds)
    '    'Ouvrir la facture générée
    '    If nDevis >= 0 Then
    '        With New FrBonCommande(FrApplication.fr.ds, nDevis)
    '            .NomTable = "AFacture"
    '            .Show()
    '        End With
    '    End If
    'End Sub


    '    Private Sub BLAppro()
    '        If Me.Grille1.SelectedGroupe = -1 Then
    '            MsgBox("Vous devez sélectionner une ligne.", MsgBoxStyle.Exclamation)
    '            Exit Sub
    '        End If

    '        Dim drFactureSource As DataRow = dv.Item(Me.Grille1.SelectedGroupe).Row

    '        'Ne marche que sur la facture d'achat surlignée : validation utilisateur
    '        If MsgBox(String.Format("Voulez-vous générer les bons de livraison pour la facture d'achat n°{0} du {1:dd/MM/yy}", drFactureSource("nFacture"), drFactureSource("DateFacture")), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

    '        Dim cnt As Integer = GestionApproFact.GenererBLAppro(CInt(drFactureSource("nDevis")), ds)

    '        With Me.Grille1
    '            .SelectedRows.Clear()
    '            .SelectedGroupe = -1
    '            .Refresh()
    '        End With

    '        If cnt > 0 Then
    '            'Ouvrir la liste des BL générés pour validation et complétion
    '            Dim FrF As New FrBonCommande(ds, False, "AFacture", Convert.ToString(drFactureSource("nDevis")), Nothing, Nothing)
    '            FrF.NomTable = "VBonLivraison"
    '            FrF.Show()
    '        End If
    '    End Sub

    '    Private Sub FactureAvoirAppro()
    '        GestionApproFact.GenererAvoirsAppro(ds)

    '        Me.Grille1.SelectedRows.Clear()
    '        Me.Grille1.SelectedGroupe = -1
    '        Me.Grille1.Refresh()
    '    End Sub
#End Region

    Private Sub FactureMasse()
        Dim lstRows As List(Of DataRowView) = GetSelectedRowViews(Me.PiecesDataGridView)
        If lstRows.Count = 0 Then Exit Sub
        If Not FrApplication.Parametres.TesterLimiteDemoPieces(Me.TypePiece.ToString) Then Exit Sub
        Dim lstFactures As New List(Of Integer)
        For Each rw As DataRowView In lstRows
            lstFactures.Add(CInt(rw("nDevis")))
        Next

        Dim g As New GestionFactureMasse
        g.GenererFactures(lstFactures, Me.TypePiece)
        ChargerDonnees()
        Me.PiecesBindingSource.ResetBindings(False)
    End Sub

    Private Sub FactureGroupee()
        Dim lstFactures As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        If lstFactures.Count = 0 Then Exit Sub
        If Me.TypePiece <> Pieces.TypePieces.VBonLivraison Then Exit Sub
        'Vérif tous les BL sont impayés
        If Not lstFactures.TrueForAll(AddressOf PieceNotPaye) Then
            MsgBox("Erreur de Selection", MsgBoxStyle.Exclamation, "Attention")
            Exit Sub
        End If

        'Vérif tous les BL sont du même client
        Dim nClient As Integer = -1
        For Each rw As DataRow In lstFactures
            If nClient = -1 Then
                nClient = CInt(rw("nClient"))
            Else
                If nClient <> CInt(rw("nClient")) Then
                    MsgBox("Une Facture groupée ne peut se faire que sur le même Client", MsgBoxStyle.Exclamation, "Attention")
                    Exit Sub
                End If
            End If
        Next

        Dim nDevisFactureGroupee As Integer = -1
        Dim DesTable As Pieces.TypePieces = Pieces.GetDestination(Me.TypePiece)
        Dim DesTableDetail As String = DesTable.ToString & "_Detail"
       
        Using s As New SqlProxy

            Dim ds As New DataSet
            'Initialiser les tables
            DefinitionDonnees.Instance.Fill(ds, "TVA", s)
            DefinitionDonnees.Instance.FillSchema(ds, Me.TypePiece.ToString, s)
            DefinitionDonnees.Instance.FillSchema(ds, Me.TypePiece.ToString & "_Detail", s)
            DefinitionDonnees.Instance.FillSchema(ds, DesTable.ToString, s)
            DefinitionDonnees.Instance.FillSchema(ds, DesTableDetail, s)
            DefinitionDonnees.Instance.CreateRelations(ds)
            
            'Charger les données des BL séléctionnés
            For Each dr As DataRow In lstFactures
                s.FillBy(ds, Me.TypePiece.ToString, String.Format("nDevis={0}", dr("nDevis")), False)
                s.FillBy(ds, Me.TypePiece.ToString & "_Detail", String.Format("nDevis={0}", dr("nDevis")), False)

            Next

            Dim dtDetail As DataTable = ds.Tables(DesTableDetail)

            Dim rwFactureGroupe As DataRow
            'Pour chaque facture sélectionnée
            For Each rwBL As DataRow In ds.Tables(Me.TypePiece.ToString).Rows


                'legrain 10/06/2014 date ech
                Dim nbJEch As Integer = 0
                Dim finM As Boolean = False 'legrain 23/09/2016 date ech
                DefinitionDonnees.Instance.Fill(ds, "Entreprise", s, "nEntreprise=" & rwBL("nClient").ToString)
                Dim rws() As DataRow = ds.Tables("Entreprise").Select("nEntreprise=" & CStr(rwBL("nClient")))


                'If rws.Length > 0 Then
                'Dim rwEnt As DataRow = rws(0)
                'If rwEnt.Table.Columns.Contains("Echeance") _
                'AndAlso Not IsDBNull(rwEnt.Item("Echeance")) _
                'AndAlso CStr(rwEnt.Item("Echeance")) <> "" Then
                'nbJEch = CInt(rwEnt.Item("Echeance"))
                'End If
                'End If

                If rws.Length > 0 Then 'legrain 23/09/2016 date ech
                    Dim rwEnt As DataRow = rws(0)


                    If rwEnt.Table.Columns.Contains("FinMois") _
                    AndAlso Not IsDBNull(rwEnt.Item("FinMois")) Then
                        finM = CBool(rwEnt.Item("FinMois"))
                    End If

                    If rwEnt.Table.Columns.Contains("Echeance") _
                    AndAlso Not IsDBNull(rwEnt.Item("Echeance")) _
                    AndAlso CStr(rwEnt.Item("Echeance")) <> "" Then
                        nbJEch = CInt(rwEnt.Item("Echeance"))
                    End If

                    'If finM Or nbJEch > 0 Then
                    'Dim dateEch As Date = CDate(rwN.Item("DateFacture")).AddDays(nbJEch)
                    'If finM Then
                    'dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
                    'End If
                    'rwN.Item("DateEcheance") = dateEch
                    'End If
                End If 'legrain 23/09/2016 date ech

                'legrain 10/06/2014 date ech

                'Créer si besoin la Facture

                If rwFactureGroupe Is Nothing Then
                    rwFactureGroupe = ds.Tables(DesTable.ToString).NewRow
                    CopyRow(rwBL, rwFactureGroupe)
                    With rwFactureGroupe
                        .Item("nFacture") = Pieces.GetNFacture(DesTable)
                        .Item("DateFacture") = Now.Date

                        'legrain 10/06/2014 date ech
                        '.Item("DateEcheance") = Now().AddDays(nbJEch)

                        'legrain 23/09/2016 date ech
                        Dim dateEch As Date = CDate(.Item("DateFacture")).AddDays(nbJEch)
                        If finM Then
                            dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
                        End If
                        .Item("DateEcheance") = dateEch
                        'legrain 23/09/2016 date ech

                        'legrain 10/06/2014 date ech

                        .Item("AdresseFacture") = Pieces.GetAdresseFacture(CInt(.Item("nClient")), DesTable.ToString())
                    End With
                    ds.Tables(DesTable.ToString).Rows.Add(rwFactureGroupe)
                    nDevisFactureGroupee = CInt(rwFactureGroupe("nDevis"))
                Else
                    If dtDetail.Rows.Count <> 0 Then
                        'Intercaler si besoin une ligne vide
                        Dim rwNEspace As DataRow = dtDetail.NewRow
                        rwNEspace.SetParentRow(rwFactureGroupe)
                        dtDetail.Rows.Add(rwNEspace)
                    End If
                End If

                'Créer la ligne intercalaire avec le n° de BL
                'MessageBox.Show("test", "test")
                Dim strLibelle As String = Pieces.GetLibelle(Me.TypePiece)
                If Convert.ToString(rwBL.Item("nFacture")) <> "" Then
                    'MessageBox.Show("test1", "test1")
                    strLibelle &= String.Format(" N°{0}", rwBL.Item("nFacture"))
                End If
                If Not rwBL.IsNull("DateFacture") Then
                    'MessageBox.Show("test2", "test2")
                    strLibelle &= String.Format(" du {0:dd/MM/yy}", rwBL.Item("DateFacture"))
                End If

                Dim rwDesc As DataRow = dtDetail.NewRow
                rwDesc.Item("Libelle") = strLibelle
                rwDesc.SetParentRow(rwFactureGroupe)
                dtDetail.Rows.Add(rwDesc)
                'Créer la ligne intercalaire avec le n°De commande
                'MessageBox.Show("test", "test")
                If Convert.ToString(rwBL.Item("BonCdeOrigine")) <> "" Then
                    strLibelle = "Commande N° "
                    strLibelle &= Convert.ToString(rwBL.Item("BonCdeOrigine"))
                    rwDesc = dtDetail.NewRow
                    rwDesc.Item("Libelle") = strLibelle
                    rwDesc.SetParentRow(rwFactureGroupe)
                    dtDetail.Rows.Add(rwDesc)
                End If




                'Ajouter les lignes de détail
                For Each rwDetailBL As DataRow In rwBL.GetChildRows(Me.TypePiece.ToString & Me.TypePiece.ToString & "_Detail")
                    'MessageBox.Show("test3", "test3")
                    Dim rwDetail As DataRow = dtDetail.NewRow
                    CopyRow(rwDetailBL, rwDetail)
                    rwDetail.SetParentRow(rwFactureGroupe)
                    dtDetail.Rows.Add(rwDetail)
                Next

                'Marquer le BL comme payé
                With rwBL
                    .Item("Origine") = DesTable
                    .Item("nOrigine") = rwFactureGroupe.Item("nDevis")
                    .Item("Paye") = True
                    .EndEdit()
                End With
            Next
            If FrApplication.Modules.ModuleApproFact Then
                GestionApproFact.NettoyerFacture(ds, CInt(rwFactureGroupe("nDevis")))
            End If
            FrBonCommande.CalculMontant(ds, rwFactureGroupe, DesTable.ToString & DesTableDetail, Pieces.TypePieces.VFacture)

            'Mettre à jour la base
            s.UpdateTables(ds, New String() {DesTable.ToString, DesTableDetail, Me.TypePiece.ToString})
        End Using

        MsgBox("Création Terminée", MsgBoxStyle.Information)
        ChargerDonnees()
        Me.PiecesBindingSource.ResetBindings(False)

        'Si elle a été créée, ouvrir la nouvelle facture
        If nDevisFactureGroupee > 0 Then
            Dim FrF As New FrBonCommande(nDevisFactureGroupee)
            FrF.TypePiece = DesTable
            FrF.Show()
        End If
    End Sub

    Private Sub Dupliquer()
        If Me.PiecesBindingSource.Position < 0 Then Exit Sub
        Dim nomTable As String = Me.TypePiece.ToString
        If Not FrApplication.Parametres.TesterLimiteDemoPieces(nomTable) Then Exit Sub

        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, nomTable, s, "nDevis=" & Me.CurrentPieceRow.nDevis)

            If ds.Tables(nomTable).Rows.Count = 0 Then Exit Sub
            Dim rw As DataRow = ds.Tables(nomTable).Rows(0)

            'Copie de la pièce en cours
            Dim rwN As DataRow = ds.Tables(nomTable).NewRow
            CopyRow(rw, rwN)
            With rwN
                .Item("nFacture") = Pieces.GetNFacture(Me.TypePiece)
                .Item("DateFacture") = Today
                .Item("Paye") = False
                .Item("ExportCompta") = False
                .Item("DateExportCompta") = DBNull.Value
                '.Item("DateEcheance") = DBNull.Value
                .Item("DateRelance1") = DBNull.Value
                .Item("DateRelance2") = DBNull.Value
                If nomTable = "VFacture" Then .Item("DateImpr") = DBNull.Value
            End With
            ds.Tables(nomTable).Rows.Add(rwN)

            'Enregistrer les données dans la table
            s.UpdateTable(ds, nomTable, Nothing)

            'RECOPIER LES DETAILS DE LA PIECE
            RecopierDetailPiece(s, nomTable, CInt(rw("nDevis")), nomTable, CInt(rwN("nDevis")))
            'TODO GESTION DU MODULE MARGE A REMETTRE
            'If Me.TypePiece = Pieces.TypePieces.ABonReception AndAlso FrApplication.Modules.ModuleGestionMarge Then
            '    If ds.Tables(_NomTableDetail).Columns.Contains("PrixAHT1") Then
            '        For Each rwE As DataRow In rwN.GetChildRows(_NomTable & _NomTable & "_Detail")
            '            If Convert.ToString(rwE.Item("CodeProduit")) <> "" Then
            '                Dim rwLstBl() As DataRow = ds.Tables(_NomTableDetail).Select("CodeProduit='" & Convert.ToString(rwE.Item("CodeProduit")).Replace("'", "''") & "' And nDevis<" & Convert.ToString(rwE.Item("nDevis")), "nDevis Desc", DataViewRowState.CurrentRows)
            '                If rwLstBl.GetUpperBound(0) >= 0 Then
            '                    rwE.Item("PrixUHT") = rwLstBl(0).Item("PrixUHT")
            '                    rwE.Item("CoefAV") = rwLstBl(0).Item("CoefAV")
            '                    rwE.Item("PrixUTTCVenteTheo") = rwLstBl(0).Item("PrixUTTCVenteTheo")
            '                    rwE.Item("PrixUTTCVente") = rwLstBl(0).Item("PrixUTTCVente")
            '                    rwE.Item("MargePrCt") = rwLstBl(0).Item("MargePrCt")
            '                    rwE.Item("MargeEuro") = rwLstBl(0).Item("MargeEuro")
            '                    rwE.Item("PrixAHT1") = rwLstBl(0).Item("PrixUHT")
            '                    rwE.Item("CoefAV1") = rwLstBl(0).Item("CoefAV")
            '                    rwE.Item("PrixVTTCTheo1") = rwLstBl(0).Item("PrixUTTCVenteTheo")
            '                    rwE.Item("PrixVTTC1") = rwLstBl(0).Item("PrixUTTCVente")
            '                    rwE.Item("MargePrCt1") = rwLstBl(0).Item("MargePrCt")
            '                    rwE.Item("MargeEuro1") = rwLstBl(0).Item("MargeEuro")
            '                    rwE.EndEdit()
            '                End If
            '            End If
            '        Next
            '    End If
            'End If
        End Using
        ChargerDonnees()
        Me.PiecesBindingSource.ResetBindings(False)
        MsgBox("Opération Terminée", MsgBoxStyle.Information)
    End Sub

    ''' <summary>Créer un ABonReception à partir d'un  VBonCommande</summary>
    Private Sub CreerCommandeFournisseur()
        Dim lstCommandes As List(Of DataRowView) = GetSelectedRowViews(Me.PiecesDataGridView)
        If lstCommandes.Count = 0 Then Exit Sub

        'Initaliser VBonCommande_Detail, ABonReception et ABonReception_Detail
        'Il faut se remplir un dataset avec les bonnes données pour bosser dessus
        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Produit", s)
            If Not ds.Tables("Produit").Columns.Contains("nFournisseur") Then
                MsgBox("Les commandes ne peuvent pas être créées, car la table produit ne contient pas de champs nFournisseur", MsgBoxStyle.Exclamation, "Attention")
                Exit Sub
            End If
            DefinitionDonnees.Instance.Fill(ds, "TVA", s) 'Pour calculer le montant des BR 
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            DefinitionDonnees.Instance.FillSchema(ds, "ABonReception", s)
            DefinitionDonnees.Instance.FillSchema(ds, "ABonReception_Detail", s)
            For Each drv As DataRowView In lstCommandes
                s.FillBy(ds, "VBonCommande", String.Format("nDevis={0}", drv("nDevis")), False)
                s.FillBy(ds, "VBonCommande_Detail", String.Format("nDevis={0}", drv("nDevis")), False)
            Next
            DefinitionDonnees.Instance.CreateRelations(ds)
        End Using

        Dim dtBR As DataTable = ds.Tables("ABonReception")
        Dim dtBRDetail As DataTable = ds.Tables("ABonReception_Detail")

        Dim lstCmdFournisseur As New Dictionary(Of Integer, DataRow)

        'Pour chaque bon commande
        For Each drCmd As DataRow In ds.Tables("VBonCommande").Rows
            Dim drDetailCmd() As DataRow = drCmd.GetChildRows("VBonCommandeVBonCommande_Detail")
            Dim lstDrDetail As New Dictionary(Of Integer, List(Of DataRow))
            For Each rwDetailCmd As DataRow In drDetailCmd
                Dim rwProduit() As DataRow = ds.Tables("Produit").Select(FormatExpression("CodeProduit={0}", rwDetailCmd("CodeProduit")))
                If rwProduit.Length > 0 Then
                    With rwProduit(0)
                        If Not .IsNull("nFournisseur") Then
                            If Not lstDrDetail.ContainsKey(CInt(.Item("nFournisseur"))) Then
                                Dim lst As New List(Of DataRow)
                                lst.Add(rwDetailCmd)
                                lstDrDetail.Add(CInt(.Item("nFournisseur")), lst)
                            Else
                                lstDrDetail(CInt(.Item("nFournisseur"))).Add(rwDetailCmd)
                            End If
                        End If
                    End With
                End If
            Next

            For Each nFournisseur As Integer In lstDrDetail.Keys
                Dim drFour As DataRow = SelectSingleRow(ds.Tables("Entreprise"), "nEntreprise=" & nFournisseur, "")
                If drFour IsNot Nothing Then
                    Dim GroupeProduit As Boolean = False
                    If drFour.Table.Columns.Contains("GroupeProduit") Then
                        If Not drFour.IsNull("GroupeProduit") Then GroupeProduit = CBool(drFour("GroupeProduit"))
                    End If

                    Dim lstDr As List(Of DataRow) = lstDrDetail(nFournisseur)
                    If lstDr.Count = 0 Then Continue For

                    'Trouver ou créer la ligne de commande
                    Dim rwNBR As DataRow
                    If lstCmdFournisseur.ContainsKey(nFournisseur) Then
                        'Si on a déjà une commande pour ce fournisseur
                        rwNBR = lstCmdFournisseur(nFournisseur)
                    Else
                        'Sinon on en crée une nouvelle
                        rwNBR = dtBR.NewRow
                        CopyRow(drCmd, rwNBR)
                        With rwNBR
                            .Item("nClient") = drFour("nEntreprise")
                            .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.ABonReception)
                            .Item("DateFacture") = drCmd("DateFacture")
                            .Item("Paye") = False
                            .Item("ExportCompta") = False
                            .Item("DateExportCompta") = DBNull.Value
                            .Item("FacturationTTC") = drFour("FacturationTTC")
                            .Item("AdresseFacture") = Pieces.GetAdresseFacture(CInt(drFour("nEntreprise")), "ABonReception")
                        End With
                        dtBR.Rows.Add(rwNBR)
                        lstCmdFournisseur.Add(nFournisseur, rwNBR)
                    End If

                    'Créer la ligne intercalaire du client
                    If Not GroupeProduit Then
                        Dim rwnLib As DataRow = dtBRDetail.NewRow
                        With rwnLib
                            .Item("nDevis") = rwNBR("nDevis")
                            Dim drClient As DataRow = SelectSingleRow(ds.Tables("Entreprise"), String.Format("nEntreprise={0}", drCmd("nClient")), "")
                            If drClient IsNot Nothing Then .Item("Libelle") = Convert.ToString(drClient("Nom"))
                        End With
                        dtBRDetail.Rows.Add(rwnLib)
                    End If

                    For Each rwDepart As DataRow In lstDr
                        Dim rwNBRDetail As DataRow
                        If Not GroupeProduit Then
                            rwNBRDetail = dtBRDetail.NewRow
                        Else
                            Dim rwsDetailExistant() As DataRow = dtBRDetail.Select(FormatExpression("nDevis={0} AND CodeProduit={1}", rwNBR("nDevis"), rwDepart("CodeProduit")))
                            If rwsDetailExistant.Length > 0 Then
                                rwNBRDetail = rwsDetailExistant(0)
                            Else
                                rwNBRDetail = dtBRDetail.NewRow
                            End If
                        End If
                        rwNBRDetail("nDevis") = rwNBR("nDevis")
                        rwNBRDetail("CodeProduit") = rwDepart("CodeProduit")
                        Dim QtDepart As Decimal = CDec(SqlProxy.ReplaceDbNull(rwNBRDetail("Unite1"), 0D))
                        Dim QtDepart2 As Decimal = CDec(SqlProxy.ReplaceDbNull(rwNBRDetail("Unite2"), 0D))

                        Dim GestLigneCmd As New LigneCommande(ds, rwNBR, Me.TypePiece.ToString, Convert.ToString(rwDepart("CodeProduit")), CBool(rwNBR("FacturationTTC")), "A")
                        With GestLigneCmd
                            If Convert.ToString(rwNBRDetail("Libelle")).Length = 0 Then .Libelle = Convert.ToString(rwDepart("Libelle"))
                            If Not IsDBNull(rwDepart("Unite1")) Then .U1 = CDec(rwDepart("Unite1"))
                            If Not IsDBNull(rwDepart("Unite2")) Then .U2 = CDec(rwDepart("Unite2"))
                            If GroupeProduit Then
                                .U1 += QtDepart
                                .U2 += QtDepart2
                            End If
                            .SetDataToRw(rwNBRDetail)
                        End With
                        If rwNBRDetail.RowState = DataRowState.Detached Then dtBRDetail.Rows.Add(rwNBRDetail)
                    Next
                Else
                    MsgBox("Le fournisseur n'a pas été trouvé", MsgBoxStyle.Exclamation, "Attention")
                End If
            Next 'Next Fournisseur
        Next 'Next Commande

        'Calculer le montant des BR qu'on a créé
        For Each rwNBR As DataRow In dtBR.Rows
            FrBonCommande.CalculMontant(ds, rwNBR, "ABonReceptionABonReception_Detail", Pieces.TypePieces.ABonReception)
        Next
        'Enregistrer les données
        Using s As New SqlProxy
            s.UpdateTables(ds, New String() {"ABonReception", "ABonReception_Detail"})
        End Using

        MsgBox("Création de Bon de Commande Fournisseur Terminé", MsgBoxStyle.Information, "Information")
    End Sub

#End Region

#Region "Fonctions sur ligne"
    'Private Sub Regler()
    '    Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
    '    Dim ok As Boolean = True
    '    If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
    '        MsgBox("Vous ne devez sélectionner que des pièces non réglées.", MsgBoxStyle.Exclamation)
    '    Else
    '        With New FrReglement(lstFacture)
    '            AddHandler .FormClosed, AddressOf ChildForm_Closed
    '            .ShowDialog(Me)
    '        End With
    '    End If
    'End Sub

    Private Sub RegleFacture(ByVal dr As DataRow, Optional ByVal Type As String = "Reglement")
        Dim lstFacture As New List(Of DataRow)
        lstFacture.Add(dr)
        RegleFactures(lstFacture, Type)
    End Sub

    Private Sub Regler(Optional ByVal Type As String = "Reglement")
        If Not (Me.TypePiece = Pieces.TypePieces.VFacture OrElse Me.TypePiece = Pieces.TypePieces.AFacture) Then Exit Sub
        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        If lstFacture.Count = 0 Then
            'Réglement de la ligne surlignée
            If Me.PiecesBindingSource.Position < 0 Then Exit Sub
            If Not Me.CurrentPieceRow.Paye Then
                RegleFacture(Me.CurrentPieceRow, Type)
            End If
        Else
            'Réglement de la sélection
            If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
                MsgBox("Vous ne devez sélectionner que des pièces non réglées.", MsgBoxStyle.Exclamation)
            Else
                RegleFactures(lstFacture, Type)
            End If
        End If
    End Sub

    Private Sub RegleFactures(ByVal lstFacture As List(Of DataRow), Optional ByVal Type As String = "Reglement")
        If (Type = "Reglement") Or (Type = "AffecterAcomptes") Then
            'Gestion des avances
            FrReglement.GestionAvanceClient(CInt(lstFacture(0)("nClient")), lstFacture)

            'Si les avances ont suffi à payer la facture
            If lstFacture.TrueForAll(AddressOf PiecePaye) Then
                ChildForm_Closed(Nothing, New FormClosedEventArgs(CloseReason.UserClosing))
                Exit Sub
            End If
        End If
        If (Type <> "AffecterAcomptes") Then
            If lstFacture.Count > 0 Then
                With New FrReglement(lstFacture)
                    If Type = "Reglement" Then .TypeRegl = FrListeReglement.TypeReglement.Vente Else .TypeRegl = FrListeReglement.TypeReglement.Achat
                    .Owner = Me
                    AddHandler .FormClosed, AddressOf ChildForm_Closed
                    .Show()
                End With
                SetSelectedAll(Me.PiecesDataGridView, False)
            End If
        End If
    End Sub

    Private Sub RegleFactureIrrecouvrable(Optional ByVal Type As Pieces.TypePieces = Pieces.TypePieces.Reglement)
        If Not Me.TypePiece = Pieces.TypePieces.VFacture Then Exit Sub
        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
            MsgBox("Vous ne devez sélectionner que des pièces non réglées.", MsgBoxStyle.Exclamation)
        Else
            If MsgBox("Le solde des factures sélectionnées sera enregistré comme " & vbCrLf & _
                    "créance irrécouvrable et les factures seront marquées comme réglées." & vbCrLf & _
                    "Voulez-vous continuer ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, _
                    "Créance irrécouvrable") = MsgBoxResult.No Then Exit Sub

            FrReglement.CreerReglementIrrecouvrable(lstFacture)
            SetSelectedAll(Me.PiecesDataGridView, False)
            ChildForm_Closed(Nothing, Nothing)
        End If
    End Sub

    Private Sub TransformerPiece(ByVal typeDest As Pieces.TypePieces)
        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
        If lstFacture.Count = 0 Then
            'Transformation de la ligne surlignée
            If Me.PiecesBindingSource.Position < 0 Then Exit Sub
            If Not FrApplication.Parametres.TesterLimiteDemoPieces(typeDest.ToString) Then Exit Sub
            TransformerPiece(typeDest, CInt(Me.CurrentPieceRow.nDevis))
        Else
            'Transformation de toutes les lignes sélectionnées
            If Not lstFacture.TrueForAll(AddressOf PieceNotPaye) Then
                MsgBox("Vous ne devez sélectionner que des pièces non transformées.", MsgBoxStyle.Exclamation)
            Else
                For Each dr As DataRow In lstFacture
                    TransformerPiece(typeDest, CInt(dr("nDevis")), False)
                Next
                'Recharger les données
                ChargerDonnees()
                Me.PiecesBindingSource.ResetBindings(False)
                MsgBox("Transfert Termine", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub TransformerPiece(ByVal typeDest As Pieces.TypePieces, ByVal nDevis As Integer, Optional ByVal rechargerDonnees As Boolean = True)
        Dim DepTable As String = Me.TypePiece.ToString
        Dim DesTable As String = typeDest.ToString
        'Copie de la pièce en cours dans la nouvelle table
        'Initialiser les tables
        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, DepTable, s, "nDevis=" & nDevis)
            If ds.Tables(DepTable).Rows.Count = 0 Then Exit Sub
            DefinitionDonnees.Instance.FillSchema(ds, DesTable, s)
            If typeDest = Pieces.TypePieces.VFacture Then
                DefinitionDonnees.Instance.Fill(ds, "Entreprise", s, "nEntreprise=" & ds.Tables(DepTable).Rows(0)("nClient").ToString)
            End If
        End Using

        Dim rw As DataRow = ds.Tables(DepTable).Rows(0)
        Dim rwN As DataRow = ds.Tables(DesTable).NewRow
        CopyRow(rw, rwN)
        'Gestion de l'option de facturation à la maison mère
        If typeDest = Pieces.TypePieces.VFacture Then
            If ds.Tables("Entreprise").Columns.Contains("FacturerMaisonMere") Then
                Dim drClient As DataRow = SelectSingleRow(ds.Tables("Entreprise"), "nEntreprise=" & rwN("nClient").ToString, "")
                If drClient IsNot Nothing _
                AndAlso Not drClient.IsNull("FacturerMaisonMere") AndAlso CBool(drClient("FacturerMaisonMere")) _
                AndAlso Not drClient.IsNull("nMaisonMere") Then
                    rwN("nClient") = drClient("nMaisonMere")
                End If
            End If
        End If
        rwN("nFacture") = Pieces.GetNFacture(typeDest)
        rwN("DateFacture") = Today
        'Recalculer l'adresse de facture
        rwN("AdresseFacture") = Pieces.GetAdresseFacture(CInt(rwN("nClient")), DesTable, CStr(rwN("AdresseFacture")))
        ds.Tables(DesTable).Rows.Add(rwN)

        'legrain 06/03/2014 , copier et adapter depuis FrBonCommande.vb
        'Gestion de la date d'échéance
        Dim nbJEch As Integer = 0
        Dim finM As Boolean = False
        Dim rws() As DataRow = ds.Tables("Entreprise").Select("nEntreprise=" & CStr(rwN("nClient")))
        If typeDest = Pieces.TypePieces.VFacture AndAlso Not IsDBNull(rwN.Item("DateFacture")) Then
            

            If rws.Length > 0 Then
                Dim rwEnt As DataRow = rws(0)


                If rwEnt.Table.Columns.Contains("FinMois") _
                AndAlso Not IsDBNull(rwEnt.Item("FinMois")) Then
                    finM = CBool(rwEnt.Item("FinMois"))
                End If

                If rwEnt.Table.Columns.Contains("Echeance") _
                AndAlso Not IsDBNull(rwEnt.Item("Echeance")) _
                AndAlso CStr(rwEnt.Item("Echeance")) <> "" Then
                    nbJEch = CInt(rwEnt.Item("Echeance"))
                End If

                If finM Or nbJEch > 0 Then
                    Dim dateEch As Date = CDate(rwN.Item("DateFacture")).AddDays(nbJEch)
                    If finM Then
                        dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
                    End If
                    rwN.Item("DateEcheance") = dateEch
                End If
            End If
            'legrain 28/05/2014 , mise a jour pour le cas bl-> facture ou la date d'échéance facture = date de création facture+ delai client
        Else


            If rws.Length > 0 Then
                Dim rwEnt As DataRow = rws(0)
                If rwEnt.Table.Columns.Contains("FinMois") _
                   AndAlso Not IsDBNull(rwEnt.Item("FinMois")) Then
                    finM = CBool(rwEnt.Item("FinMois"))
                End If
                Dim dateEch As Date = Now().AddDays(nbJEch)
                If finM Then
                    dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
                End If
                rwN.Item("DateEcheance") = dateEch

            End If
        End If

        'Enregistrer les infos d'Origine dans la ligne en cours
        rw("Origine") = DesTable
        rw("nOrigine") = rwN("nDevis")
        rw("Paye") = True

        'Enregistrer les données dans la table de destination
        Using s As New SqlProxy
            s.UpdateTable(ds, DesTable, Nothing)
            s.UpdateTable(ds, DepTable, Nothing)
            'RECOPIER LES DETAILS DE LA PIECE
            RecopierDetailPiece(s, DepTable, nDevis, DesTable, CInt(rwN("nDevis")))
        End Using
        If rechargerDonnees Then
            'Recharger les données
            ChargerDonnees()
            Me.PiecesBindingSource.ResetBindings(False)
            MsgBox("Transfert Termine", MsgBoxStyle.Information)
        End If
    End Sub

    Public Shared Sub RecopierDetailPiece(ByVal s As SqlProxy, ByVal tableSrc As String, ByVal nDevisSrc As Integer, ByVal tableDest As String, ByVal nDevisDest As Integer)
        Dim dtDest As DataTable = s.ExecuteDataTable(String.Format("SELECT * FROM [{0}] WHERE 1=0", tableDest & "_Detail"))
        Dim dtSrc As DataTable = s.ExecuteDataTable(String.Format("SELECT * FROM [{0}] WHERE 1=0", tableSrc & "_Detail"))
        Dim nDetailSrcMin As Integer = s.ExecuteScalarInt(String.Format("SELECT Min(nDetailDevis) as m FROM [{0}] WHERE [nDevis]={1}", tableSrc & "_Detail", nDevisSrc))
        Dim nDetailDestMax As Integer = s.ExecuteScalarInt(String.Format("SELECT Max(nDetailDevis) as m FROM [{0}]", tableDest & "_Detail"))
        Dim colList As New List(Of String)
        Dim valueList As New List(Of String)
        For Each col As DataColumn In dtDest.Columns
            If dtSrc.Columns.Contains(col.ColumnName) Then
                colList.Add(String.Format("[{0}]", col))
                If col.ColumnName = "nDevis" Then
                    valueList.Add("{0}")
                ElseIf col.ColumnName = "nDetailDevis" Then
                    valueList.Add(String.Format("[{0}]+{1}", col, nDetailDestMax + 1 - nDetailSrcMin))
                Else
                    valueList.Add(String.Format("[{0}]", col))
                End If
            End If
        Next
        Dim sql As String = String.Format("INSERT INTO [{0}]({2}) SELECT {3} FROM [{1}] WHERE [nDevis]={{1}}", tableDest & "_Detail", tableSrc & "_Detail", String.Join(",", colList.ToArray), String.Join(",", valueList.ToArray))
        s.ExecuteNonQuery(SqlProxy.FormatSql(sql, nDevisDest, nDevisSrc))
    End Sub

#End Region

    'Private Sub ImprimerListe()
    '    Dim nomTable As String = CStr(IIf(Me.TypeRegl = TypeReglement.Achat, "AReglement", "Reglement"))
    '    Dim nomTableF As String = CStr(IIf(Me.TypeRegl = TypeReglement.Achat, "AFacture", "VFacture"))
    '    Dim myDs As DataSet = DsPieces.Clone
    '    With myDs
    '        .EnforceConstraints = False
    '        Dim drs As List(Of DataRow) = GetSelectedRows(Me.PiecesDataGridView)
    '        If drs.Count = 0 Then
    '            .Merge(Me.DsPieces.Reglement.Select(Me.PiecesBindingSource.Filter))
    '        Else
    '            .Merge(drs.ToArray)
    '        End If
    '        .Tables("Reglement").TableName = nomTable
    '        Dim nRegls As New List(Of String)
    '        For Each dr As DataRow In myDs.Tables(nomTable).Rows
    '            nRegls.Add(Convert.ToString(dr("nReglement")))
    '        Next
    '        Dim where As String = " nReglement IN (" & String.Join(",", nRegls.ToArray) & ")"
    '        Using s As New SqlProxy
    '            DefinitionDonnees.Instance.Fill(myDs, nomTable & "_Detail", s, where)
    '            DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s, String.Format("nEntreprise IN (SELECT nEntreprise FROM {0} WHERE {1})", nomTable, where))
    '            DefinitionDonnees.Instance.Fill(myDs, nomTableF, s, String.Format("nDevis IN (SELECT nDevis FROM {0}_Detail WHERE {1})", nomTable, where))
    '        End Using
    '    End With
    '    Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListe" & nomTable & ".rpt")
    '    fr.Show()
    'End Sub

   
End Class
