Imports GRC
Imports Actigram.Windows.Forms
Imports Actigram.Donnees
Imports System.Data.SqlClient

'TODO : Probleme sur les factures imprimées : le calcul TVA ne se fait pas de la même façon 
'et on peut se prendre une différence de 1ct. 
'Pour bien faire il faudrait récupérer les valeurs du Recap TVA
'Pour super bien faire, les montants ne devraient pas etre recalculés à l'impression => du boulot

Public Class FrBonCommande

    Dim nContact As Integer = -1
    Dim Origine As String
    Dim nOrigine As Integer = -1
    Dim FacturationTTC As Boolean = False

    Private _NomTable As String = "VDevis"
    Private _NomTableDetail As String = "VDevis_Detail"
    Private _NomLiaison As String = "VDevisVDevis_Detail"
    Private _NomLiaisonClient As String = "ClientDevis"
    Private _NomTableReglement As String = "Reglement"
    Private _nclient As Integer = -1
    Private suppressionEnCours As Boolean = False
    Private _stop As Boolean = False
    Private skip As Boolean = False

    Private _ChargementForm As Boolean = False
    Private _FromEntreprise As Boolean = False

    Private _FromListOfPieces As Boolean = False
    Private _ListOfPiecesFilter As String
    Private _FromListOfPiecesEntreprise As Boolean = False

    Private _GoTolist As Boolean = True

#Region " Constructeurs "
    Public Sub New(Optional ByVal fromList As Boolean = False, Optional ByVal listOfPiecesFilter As String = "", _
                    Optional ByVal fromListEntreprise As Boolean = False)
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True

        Me._FromListOfPieces = fromList
        Me._ListOfPiecesFilter = listOfPiecesFilter
        Me._FromListOfPiecesEntreprise = fromListEntreprise
    End Sub

    Public Sub New(ByVal nDevis As Integer, Optional ByVal fromList As Boolean = False, _
                    Optional ByVal listOfPiecesFilter As String = "", Optional ByVal fromListEntreprise As Boolean = False, _
                    Optional ByVal goToList As Boolean = True)
        Me.New()
        Me.id = nDevis
        Me.AjouterEnregistrement = False

        Me._FromListOfPieces = fromList
        Me._ListOfPiecesFilter = listOfPiecesFilter
        Me._FromListOfPiecesEntreprise = fromListEntreprise
        Me._GoTolist = goToList
    End Sub

    Public Sub New(ByVal bNouveau As Boolean, ByVal nEntreprise As Integer, ByVal nContact As Integer)
        Me.New()
        Me.id = -1
        Me.AjouterEnregistrement = bNouveau
        Me.nEntreprise = nEntreprise
        Me.nContact = nContact
    End Sub

    Public Sub New(ByVal bNouveau As Boolean, ByVal strOrigine As String, ByVal nOrigine As Integer, ByVal nEntreprise As Integer, ByVal nContact As Integer)
        Me.New()
        Me.id = -1
        Me.AjouterEnregistrement = bNouveau
        Me.nEntreprise = nEntreprise
        Me.nContact = nContact
        Me.Origine = strOrigine
        Me.nOrigine = nOrigine
    End Sub
#End Region

#Region " Propriétés "

    Private _type As Pieces.TypePieces = Pieces.TypePieces.VFacture
    Public Property TypePiece() As Pieces.TypePieces
        Get
            Return _type
        End Get
        Set(ByVal value As Pieces.TypePieces)
            _type = value
            _NomTable = value.ToString
            _NomTableDetail = _NomTable & "_Detail"
            _NomLiaison = _NomTable & _NomTableDetail
            _NomTableReglement = CStr(IIf(value = Pieces.TypePieces.AFacture, "AReglement", "Reglement"))
            'For Each dr As DataRelation In ds.Tables(value.ToString).ParentRelations
            '    If dr.ParentTable.TableName = "Entreprise" Then
            '        _NomLiaisonClient = dr.RelationName
            '    End If
            'Next
            Me.gcFacturation.Table = _NomTable
            Me.gcEcheance.Table = _NomTable
        End Set
    End Property

    Private _nEnt As Integer = -1
    Public Property nEntreprise() As Integer
        Get
            Return _nEnt
        End Get
        Set(ByVal value As Integer)
            _nEnt = value
        End Set
    End Property

    Private ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.PieceBindingSource.Position < 0 Then Return Nothing
            If Not TypeOf Me.PieceBindingSource.Current Is DataRowView Then Return Nothing
            Return Cast(Of DataRowView)(Me.PieceBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property CurrentDetailDrv() As DataRowView
        Get
            If Me.PieceDetailBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.PieceDetailBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nDevis() As Integer
        Get
            If Me.CurrentDrv Is Nothing Then
                Return -1
            Else
                Return CInt(Me.CurrentDrv("nDevis"))
            End If
        End Get
    End Property

    Public Property FromListOfPieces() As Boolean
        Get
            Return Me._FromListOfPieces
        End Get
        Set(ByVal value As Boolean)
            Me._FromListOfPieces = value
        End Set
    End Property

    Public Property FromEntreprise() As Boolean
        Get
            Return Me._FromEntreprise
        End Get
        Set(ByVal value As Boolean)
            Me._FromEntreprise = value
        End Set
    End Property
#End Region

#Region " Données "
    Private Sub ChargerProduits(ByVal s As SqlProxy)
        Me.ProduitBindingSource.SuspendBinding()
        Me.ds.EnforceConstraints = False

        If FrApplication.Modules.ModuleTarif Then
            s.Fill(ds, "Tarif")
            s.Fill(ds, "Tarif_Detail")
            ds.Tables("Tarif").LoadDataRow(New Object() {-1, ""}, True)
        End If
        DefinitionDonnees.Instance.Fill(ds, "Famille", s)

        Dim filtreProd As String = "Inactif=0"
        If Pieces.GetAV(Me.TypePiece) = "A" Then
            filtreProd &= " AND ProduitAchat=1"
        Else
            filtreProd &= " AND ProduitVente=1"
        End If
        DefinitionDonnees.Instance.Fill(ds, "Produit", s, filtreProd)

        Me.ds.EnforceConstraints = True
        Me.ProduitBindingSource.ResumeBinding()
    End Sub

    Private Sub ChargerLots(ByVal s As SqlProxy)
        Me.ds.EnforceConstraints = False
        If FrApplication.Modules.ModuleStock Then
            DefinitionDonnees.Instance.Fill(ds, "Lot", s, "Termine=0")
        End If
        Me.ds.EnforceConstraints = True
    End Sub

    Private Sub ChargerClients(ByVal s As SqlProxy)
        Dim filtreEntreprise As String
        If Pieces.GetAV(Me.TypePiece) = "A" Then
            'filtreEntreprise = "Fournisseur=1 AND Inactif=0"
            filtreEntreprise = "Fournisseur=1"
        Else
            'filtreEntreprise = "Client=1 AND Inactif=0"
            filtreEntreprise = "Client=1"
        End If
        DefinitionDonnees.Instance.Fill(ds, "Entreprise", s, filtreEntreprise)
        'Pour charger les commerciaux
        DefinitionDonnees.Instance.Fill(ds, "Personne", s)
    End Sub

    Private Sub RechargerPiece()
        If Me.id IsNot Nothing AndAlso CInt(Me.id) >= 0 Then
            Cursor.Current = Cursors.WaitCursor
            Me.PieceDetailBindingSource.SuspendBinding()
            Me.PieceBindingSource.SuspendBinding()
            Dim where As String = String.Format("nDevis={0}", Me.id)
            Using s As New SqlProxy
                ds.EnforceConstraints = False
                ds.Tables(_NomTableDetail).Rows.Clear()
                ds.Tables(_NomTable).Rows.Clear()
                DefinitionDonnees.Instance.Fill(ds, _NomTable, s, where)
                DefinitionDonnees.Instance.Fill(ds, _NomTableDetail, s, where)
                ds.EnforceConstraints = True
            End Using
            Me.PieceBindingSource.ResumeBinding()
            Me.PieceDetailBindingSource.ResumeBinding()
            'Databinding
            Me.gcFacturation.SetDataSource(CType(Me.PieceBindingSource.List, DataView))
            Me.gcEcheance.SetDataSource(CType(Me.PieceBindingSource.List, DataView))
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub RechargerProduit(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.UserClosing Or CloseReason.None
                Cursor.Current = Cursors.WaitCursor
                Using s As New SqlProxy
                    ChargerProduits(s)
                End Using
                Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub ChargerDonnees()
        Cursor.Current = Cursors.WaitCursor
        Me.ds = New DataSet
        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            If FrApplication.Modules.ModuleCompta Then Compta.ChargerDonneesCompta(ds)
            s.Fill(ds, "TVA")
            ds.Tables("TVA").Columns.Add("TVADisplay", GetType(String), "TTVA + iif(TLibelle is null,'',' - ' + TLibelle)")
            ChargerProduits(s)
            ChargerLots(s)
            ChargerClients(s)

            If Me.id IsNot Nothing AndAlso CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("nDevis={0}", Me.id)
                DefinitionDonnees.Instance.Fill(ds, _NomTable, s, where)
                DefinitionDonnees.Instance.Fill(ds, _NomTableDetail, s, where)

                'MODIF TV 06/09/2012 ---------------------
                'Supprime l'autoincrement des colonnes nDevis et nDetailDevis
                Me.SupprimerAutoincrement()
                'FIN MODIF TV ---------------------------

                Me.ds.AcceptChanges()
                DefinitionDonnees.Instance.CreateRelations(ds)
                ConfigDataTableEvents(Me.ds.Tables(_NomTable), AddressOf Datarowchanged, True)
                ConfigDataTableEvents(Me.ds.Tables(_NomTableDetail), AddressOf RowDetailChanged, True)

                With Me.PieceBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With

                If Me.PieceBindingSource.Position >= 0 Then
                    _nclient = CInt(Me.CurrentDrv("nClient"))
                End If
            ElseIf AjouterEnregistrement Then
                If FrApplication.Parametres.TesterLimiteDemoPieces(Me.TypePiece.ToString) Then
                    DefinitionDonnees.Instance.FillSchema(ds, _NomTable, s)
                    DefinitionDonnees.Instance.FillSchema(ds, _NomTableDetail, s)

                    'MODIF TV 06/09/2012 ---------------------
                    'Supprime l'autoincrement des colonnes nDevis et nDetailDevis
                    Me.SupprimerAutoincrement()
                    'FIN MODIF TV ---------------------------

                    DefinitionDonnees.Instance.CreateRelations(ds)
                    ConfigDataTableEvents(Me.ds.Tables(_NomTable), AddressOf Datarowchanged, True)
                    ConfigDataTableEvents(Me.ds.Tables(_NomTableDetail), AddressOf RowDetailChanged, True)
                    With Me.PieceBindingSource
                        .DataSource = ds
                        .DataMember = _NomTable
                    End With
                    Me.PieceBindingSource.AddNew()

                    'MODIF TV 06/09/2012
                    'Affecte un nouveau nDevis
                    Me.CurrentDrv("nDevis") = Pieces.GetNDevis(Me.TypePiece)
                    'FIN MODIF TV-------------

                    ValeurDefautPiece(Me.CurrentDrv, s)
                End If
            Else 'Chargement de plusieurs factures
                Dim filter As String = ""
                If nEntreprise > 0 Then
                    filter &= "nClient=" & nEntreprise
                End If
                If Origine IsNot Nothing AndAlso nOrigine > 0 Then
                    If filter.Length > 0 Then
                        filter &= " AND "
                    End If
                    filter &= String.Format("Origine='{0}' AND nOrigine={1} ", Origine, nOrigine)
                End If
                If filter.Length = 0 Then filter = Me.FiltreType
                DefinitionDonnees.Instance.Fill(ds, _NomTable, s, filter)
                DefinitionDonnees.Instance.Fill(ds, _NomTableDetail, s, filter)
                Me.ds.AcceptChanges()
                DefinitionDonnees.Instance.CreateRelations(ds)
                ConfigDataTableEvents(Me.ds.Tables(_NomTable), AddressOf Datarowchanged, True)
                ConfigDataTableEvents(Me.ds.Tables(_NomTableDetail), AddressOf RowDetailChanged, True)
                With Me.PieceBindingSource
                    .DataSource = ds
                    .DataMember = _NomTable
                End With
            End If
            If FrApplication.Modules.ModuleApproFact Then
                Select Case Me.TypePiece
                    Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VBonCommande, Pieces.TypePieces.VBonLivraison
                        DefinitionDonnees.Instance.Fill(ds, "Appro_BCD_AFD", s)
                End Select
            End If
        End Using
        Cursor.Current = Cursors.Default

        'Pour la création de client/fournisseur => INUTILE
        'With ds.Tables("Entreprise").Columns
        '    If Pieces.GetAV(Me.TypePiece) = "A" Then
        '        .Item("Fournisseur").DefaultValue = True
        '        .Item("Client").DefaultValue = False
        '        .Item("FacturationTTC").DefaultValue = False
        '    Else
        '        .Item("Client").DefaultValue = True
        '        .Item("Fournisseur").DefaultValue = False
        '        .Item("FacturationTTC").DefaultValue = True
        '    End If
        'End With

        AjoutColonnesMarge()
        Databinding()

        If (Me.id IsNot Nothing) AndAlso (CInt(Me.id) >= 0) Then
            Me.Enregistrer()
        End If
    End Sub

    Private Sub AjoutColonnesMarge()
        If Pieces.GetAV(Me.TypePiece) = "A" AndAlso FrApplication.Modules.ModuleGestionMarge Then
            'Me.IndicateurMarge1.ObjectifPr100 = FrApplication.Parametres.ObjectifMarge
            'Dim lbC As Label
            'For Each lbC In Me.PanelColor1.Controls
            '    If Convert.ToString(lbC.Tag) = "Achat" Then
            '        lbC.Visible = True
            '    End If
            'Next
            With Me.ds.Tables(_NomTableDetail).Columns
                If Not .Contains("MargePrCt") Then .Add("MargePrCt", GetType(Decimal))
                If Not .Contains("MargeEuro") Then .Add("MargeEuro", GetType(Decimal))
                If Not .Contains("MargePrCt1") Then .Add("MargePrCt1", GetType(Decimal))
                If Not .Contains("MargeEuro1") Then .Add("MargeEuro1", GetType(Decimal))
                If Not .Contains("PrixVTTCTheo1") Then .Add("PrixVTTCTheo1", GetType(Decimal))
                If Not .Contains("PrixUTTCVente") Then
                    .Add("PrixUTTCVente", GetType(Decimal)).DefaultValue = 0
                    .Add("CoefAV", GetType(Decimal)).DefaultValue = 0
                    .Add("MontantLigneTTCVente", GetType(Decimal)).DefaultValue = 0
                    For Each rw As DataRow In Me.ds.Tables(_NomTableDetail).Rows
                        rw.Item("PrixUTTCVente") = 0
                        rw.Item("CoefAV") = 0
                        rw.Item("MontantLigneTTCVente") = 0
                    Next
                Else
                    .Item("PrixUTTCVente").DefaultValue = 0
                    .Item("CoefAV").DefaultValue = 0
                    .Item("MontantLigneTTCVente").DefaultValue = 0
                End If
            End With
        End If
    End Sub

    Private Sub Databinding()
        With Me.TVABindingSource
            .SuspendBinding()
            .DataSource = ds
            .DataMember = "TVA"
            .ResumeBinding()
        End With
        With Me.TTVADataGridViewTextBoxColumn
            .DataSource = TVABindingSource
            .DisplayMember = "TVADisplay"
            .ValueMember = "TTVA"
        End With

        With Me.ProduitBindingSource
            .SuspendBinding()
            .DataSource = ds
            .DataMember = "Produit"
            .ResumeBinding()
        End With

        With Me.PieceDetailBindingSource
            .SuspendBinding()
            .DataSource = Me.PieceBindingSource
            .DataMember = _NomLiaison
            .ResumeBinding()
        End With
        Me.dgvPieceDetail.DataSource = Me.PieceDetailBindingSource

        Me.LbMontantHT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PieceBindingSource, "MontantHT", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.LbMontantTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PieceBindingSource, "MontantTVA", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.LbMontantTTC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PieceBindingSource, "MontantTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))

        'Databinding
        Me.gcFacturation.SetDataSource(CType(Me.PieceBindingSource.List, DataView))
        Me.gcEcheance.SetDataSource(CType(Me.PieceBindingSource.List, DataView))
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        If Me.PieceBindingSource.Position < 0 Then Exit Function
        res = Me.gcEcheance.VerifContraintes AndAlso Me.gcFacturation.VerifContraintes
        If Not res Then Return False

        Dim drv As DataRowView = Me.CurrentDrv
        If IsDBNull(drv("nClient")) Then
            MsgBox("Vous devez sélectionner un client.", MsgBoxStyle.Exclamation)
            Return False
        End If

        'Vérif des lignes
        If FrApplication.Modules.ModuleCompta Then
            Dim nbLigneAvecMontant As Integer = 0
            For Each rwv As DataRowView In Me.PieceDetailBindingSource
                If Not (IsDBNull(rwv.Item("MontantLigneHT")) AndAlso IsDBNull(rwv.Item("MontantLigneTTC"))) Then
                    If CStr(rwv.Item("CodeProduit")).Length = 0 Then
                        res = False
                        MessageBox.Show("Vous ne pouvez pas avoir une Ligne avec un montant sans code produit", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    nbLigneAvecMontant += 1
                End If
            Next
            If nbLigneAvecMontant = 0 Then
                res = False
                MessageBox.Show("Vous ne pouvez pas avoir une pièce vide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If Not res Then Return False

        'Gestion des remises client
        Try
            If Not drv.Row.GetParentRow(_NomLiaisonClient).Item("Remise") Is DBNull.Value Then
                If Convert.ToDecimal(drv.Row.GetParentRow(_NomLiaisonClient).Item("Remise")) > 0 Then
                    If ds.Tables("DetailDevis").Select("nDevis=" & Convert.ToString(drv("nDevis")) & " And Libelle Like 'Remise*'").GetUpperBound(0) = -1 Then
                        Select Case MessageBox.Show("La remise de ce client n'a pas été affectée ?" & vbCrLf & "Voulez-vous l'affecter maintenant ?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                AffecterRemise()
                            Case DialogResult.No
                            Case DialogResult.Cancel
                                res = False
                        End Select
                    End If
                End If
            End If
        Catch
        End Try
        If Not res Then Return False

        'Gestion des redevances ApproFact
        If FrApplication.Modules.ModuleApproFact Then
            'Lance le recalcul seulement si la pièce n'est pas exportée en comptabilité
            If Not (CBool(Me.CurrentDrv("ExportCompta"))) Then
                If Me.TypePiece = Pieces.TypePieces.VFacture Then GestionApproFact()
                If Me.TypePiece = Pieces.TypePieces.AFacture Then VerifQuantitesApproFact()
            End If
        End If

        If res Then
            res = MyBase.Validate()
        End If
        Return res
    End Function

    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If Not Me.ds.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        'Me.PieceDetailBindingSource.EndEdit()
        Me.PieceBindingSource.EndEdit()

        If Me.ds.HasChanges Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                Case MsgBoxResult.No
                    'On continue sans enregistrer
                Case MsgBoxResult.Yes
                    If Not Enregistrer() Then
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Function Enregistrer(Optional ByVal sender As System.Object = Nothing, Optional ByVal e As System.Windows.Forms.DataGridViewCellEventArgs = Nothing) As Boolean
        If Not (Me._ChargementForm) Then
            If Not (IsDBNull(Me.CurrentDrv("nClient"))) Then
                Dim nEntreprise As Decimal = CDec(Me.CurrentDrv("nClient"))

                Dim listeEntrepriseDR() As DataRow = Me.ds.Tables("Entreprise").Select("nEntreprise=" & nEntreprise)

                If Not (listeEntrepriseDR Is Nothing) Then
                    If (listeEntrepriseDR.Length > 0) Then
                        Dim EntrepriseDR As DataRow = listeEntrepriseDR(0)
                        If (Me.TypePiece = Pieces.TypePieces.VDevis Or Me.TypePiece = Pieces.TypePieces.VBonCommande _
                            Or Me.TypePiece = Pieces.TypePieces.VBonLivraison Or Me.TypePiece = Pieces.TypePieces.VFacture) Then

                            'Vérifie qu'il n'y a pas de litige en cours avec le tiers
                            If (Me.EntrepriseEnLitige(EntrepriseDR)) Then
                                If (MsgBox("Un litige est en cours avec le tiers sélectionné. " & Microsoft.VisualBasic.vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                                    Exit Function
                                End If
                            End If

                            'Vérifie que l'en cours maximum n'est pas depassé
                            If (Me.EnCoursMaxDepasse(EntrepriseDR, Me.TypePiece)) Then
                                If (MsgBox("L'en-cours maximum est depassé pour le tiers sélectionné. " & Microsoft.VisualBasic.vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


        'For Each row As DataGridViewRow In Me.DataGridView.rows()
        'Cast(Of DataGridViewRow)(
        'Dim a As DataGridViewRow()

        'ActionChangementLigneMontant(row, "")
        'Next

        'Enregistrer
        recalcul() 'legrain 17/04/2015
        If Not Me.Validate() Then Return False
        Me.PieceDetailBindingSource.EndEdit()
        Me.PieceBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            'Assigner un n° de facture
            Using s As New SqlProxy
                If Me.CurrentDrv IsNot Nothing Then
                    If IsDBNull(Me.CurrentDrv("nFacture")) Then
                        Me.CurrentDrv("nFacture") = Pieces.GetNFacture(s, Me.TypePiece)
                        Me.PieceBindingSource.EndEdit()
                    End If
                End If
                s.UpdateTables(ds, New String() {_NomTable, _NomTableDetail})
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub ValeurDefautPiece(ByRef rwv As DataRowView, ByVal s As SqlProxy)
        Dim VDef As ValeurDefaultApplication = FrApplication.ValeurDefault
        With rwv
            If FrApplication.nUtilisateur <> -1 Then .Item("nCommercial") = FrApplication.nUtilisateur
            .Item("DateFacture") = Today
            If nEntreprise > 0 Then .Item("nClient") = nEntreprise
            If nContact > 0 Then .Item("nContact") = nContact
            If Not Origine Is Nothing Then
                .Item("Origine") = Origine
                If nOrigine > 0 Then .Item("nOrigine") = nOrigine
            End If
            'TODO les valeurs par défaut d'une nouvelle pièce
            NClientChanged()
        End With
    End Sub

    Private Sub PieceBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PieceBindingSource.CurrentChanged
        Me.gcEcheance.Enabled = (Me.PieceBindingSource.Count > 0)
        Me.gcFacturation.Enabled = (Me.PieceBindingSource.Count > 0)

        If Me.PieceBindingSource.Position < 0 Then
            AutoriseModif(True)
        Else
            Dim rwv As DataRowView = Me.CurrentDrv
            If rwv Is Nothing Then Exit Sub
            'Bloquage en modif pour les factures déjà imprimées
            AutoriseModif(_NomTable <> "VFacture" OrElse IsDBNull(rwv("DateImpr")))

            'dvLigne = rwv.CreateChildView(_NomLiaison)
            'Création de la première ligne
            'If dvLigne.Count = 0 Then dvLigne.AddNew()
            Me.ConfigModeFacturation()
        End If

        CalculMontant()
        MajBoutons()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Rollback, DataRowAction.Change
                MajBoutons()
                If e.Action = DataRowAction.Add Then
                    Me.id = Me.nDevis
                End If
        End Select
    End Sub

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles gcFacturation.MustRefreshTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                ds.EnforceConstraints = False
                Using s As New SqlProxy
                    s.Fill(ds, t)
                End Using
                ds.EnforceConstraints = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles gcFacturation.MustUpdateTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                Using s As New SqlProxy
                    s.UpdateTable(ds, t)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Form"
    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me._ChargementForm = True
        'If Me.MdiParent Is Nothing Then
        '    Me.WindowState = FormWindowState.Normal
        'End If
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption2)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption4)

        AddHandler Me.gcEcheance.CtlValidated, AddressOf CtlValidated
        AddHandler Me.gcFacturation.CtlValidated, AddressOf CtlValidated

        ApplyStyle(Me.dgvPieceDetail, False)

        With dgvPieceDetail
            AddHandler .MouseDown, AddressOf dg_GestionClicDroit
        End With

        Me.dgvPieceDetail.DataSource = Nothing

        If Not FrApplication.Modules.ModuleStock Then
            Me.NLotDataGridViewTextBoxColumn.Visible = False
            Me.ColBtNLot.Visible = False
        End If

        Me.TxCodeBarre.Visible = False

        Dim strFiltreAffichage As String = GestionControles.GetFiltreAffichage

        Me.gcEcheance.FiltreAffichage = strFiltreAffichage
        Me.gcFacturation.FiltreAffichage = strFiltreAffichage

        ChargerDonnees()
        MajBoutons()
        ConfigInterface()

        'Me.Enregistrer()

        'Gestion de l'échéance par défaut
        Me.GererEcheance()

        'Affichage de la colonne PrixAHT seulement si module Achat = True
        Me.dgvPieceDetail.Columns("PrixUAchatHT").Visible = False

        If (FrApplication.Modules.ModuleAchat) Then
            If (Me.dgvPieceDetail.Columns.Contains("PrixUAchatHT")) Then
                Me.dgvPieceDetail.Columns("PrixUAchatHT").Visible = True
            End If
        End If
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                If Me.PieceBindingSource.Position >= 0 AndAlso Not Me.Validate Then
                    If MsgBox("L'enregistrement est impossible, voulez-vous sortir en abandonnant les modifications ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        e.Cancel = False

                        Me.OpenListOfPieces()

                        Exit Sub
                    End If
                End If

                DemanderEnregistrement(e)

                If e.Cancel Then
                    'Me.OpenListOfPieces()

                    Exit Sub
                End If

                If Me.PieceBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nEntreprise)
                End If

                If (Me._GoTolist) Then
                    Me.OpenListOfPieces()
                End If
        End Select
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Me.WindowState = FormWindowState.Maximized
        Me._ChargementForm = False
    End Sub

    Private Sub Me_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.Control And e.KeyCode = Keys.M Then
            'Modification autorisée pour les pièces non exportées en comptabilité
            Dim dr As DataRow = SelectSingleRow(Me.ds.Tables(Me._NomTable), "nDevis=" & Me.nDevis, "")

            If dr IsNot Nothing Then
                If Not (IsDBNull(dr("ExportCompta"))) Then
                    If Convert.ToBoolean(dr("ExportCompta")) Then
                        MsgBox("Modification impossible. Cette pièce a fait l'objet d'un export en comptabilité.", MsgBoxStyle.Exclamation, "Modification impossible")

                        Exit Sub
                    End If
                End If
            End If

            AutoriseModif(True)
        End If
    End Sub
#End Region

#Region "Panel1"
    Private Sub Panel1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Resize
        Me.GpFacturation.Width = Me.Panel1.Width - 20
        Me.GpFacturation.Height = Math.Max(Me.Panel1.Height, Me.gcFacturation.Height + Me.GradientCaption1.Height)
        'Me.gcFacturation.Height = Me.GpFacturation.Height - Me.GradientCaption1.Height
        Me.GbEcheance.Left = Me.GpFacturation.Width - Me.GbEcheance.Width - Me.GbEcheance.Margin.Right
    End Sub
#End Region

#Region " Toolbar "
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        Try
            Dim nDevisDeleted As Integer = Me.nDevis
            Dim nFactureDeleted As Integer = CInt(ReplaceDbNull(Me.CurrentDrv("NFacture"), -1))
            Me.PieceBindingSource.RemoveCurrent()
            If UpdateBase() Then
                Dim TbName As String = Pieces.GetTablePrecedente(Me.TypePiece).ToString
                If TbName <> "" Then
                    Using s As New SqlProxy
                        s.ExecuteNonQuery("UPDATE " & TbName & " SET Paye=0 WHERE nOrigine=" & nDevisDeleted)
                        If nFactureDeleted > 0 Then Pieces.AnnulerNFacture(s, _NomTable, nFactureDeleted)
                    End Using
                End If
                Me.Close()
            End If
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbImprimer_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.ButtonClick
        ImprimerDevis()

        Me.dgvPieceDetail.ClearSelection()
    End Sub

    Private Sub ImpressionDirecteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpressionDirecteToolStripMenuItem.Click
        ImprimerDevis(True)

        Me.dgvPieceDetail.ClearSelection()
    End Sub

    Private Sub ImpressionRelanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpressionRelanceToolStripMenuItem.Click
        ImprimerRelance()

        Me.dgvPieceDetail.ClearSelection()
    End Sub

    Private Sub TbRegler_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRegler.ButtonClick
        Me.Enregistrer()
        Me.MajBoutons()

        RegleFacture()
    End Sub

    Private Sub AffecterUnAcompteavoirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AffecterUnAcompteavoirToolStripMenuItem.Click
        RegleFacture(True)
    End Sub

    Private Sub CréanceIrrécouvrableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CréanceIrrécouvrableToolStripMenuItem.Click
        RegleFactureIrrecouvrable()
    End Sub

    Private Sub TbAfficheReglement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbAfficheReglement.Click
        AfficherReglement()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub CreerLotToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreerLotToolStripButton.Click
        Using fr As New FrLot
            fr.ShowDialog(Me)
        End Using
    End Sub

    Private Sub SuivantToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuivantToolStripButton.Click
        'Recherche du nDevis suivant
        Me.MoveToPiece("SUIVANT")
    End Sub

    Private Sub PrecedentToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrecedentToolStripButton.Click
        'Recherche du nDevis précédent
        Me.MoveToPiece("PRECEDENT")
    End Sub
#End Region

#Region " GUI Events "
    Private Sub gcEcheance_CtlCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gcEcheance.CtlClick
        If _stop Then Exit Sub
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        Me.PieceBindingSource.EndEdit()
        If Convert.ToString(CType(sender, Control).Tag) = "FacturationTTC" Then
            Me.PieceDetailBindingSource.SuspendBinding()
            _stop = True
            Dim drv As DataRowView = Me.CurrentDrv
            drv.BeginEdit()
            drv("FacturationTTC") = Not CBool(drv("FacturationTTC"))
            Me.FacturationTTC = CBool(drv("FacturationTTC")) ' CType(sender, CheckBox).Checked
            ConfigurerColHTTTC()
            If Not Me.FacturationTTC Then CalculTTCToHT() Else CalculHTToTTC()
            CalculMontant()
            'Me.PieceDetailBindingSource.ResetBindings(False)
            Me.PieceDetailBindingSource.ResumeBinding()
            _stop = False
        End If
    End Sub

    Private Sub gcFacturation_CtlnCleChanging(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gcFacturation.CtlnCleChanging
        Dim champ As String = Convert.ToString(sender)
        Select Case champ
            Case "nClient"
                If Not IsDBNull(Me.CurrentDrv("nClient")) Then
                    If MsgBox(String.Format("Voulez-vous affecter ce nouveau {0} ?", IIf(Pieces.GetAV(Me.TypePiece) = "A", "fournisseur", "client")), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub gcFacturation_nClChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gcFacturation.CtlnCleChanged
        If TypeOf sender Is String Then
            If Convert.ToString(sender) = "nClient" Then
                NClientChanged("")
            End If
        ElseIf Convert.ToString(CType(sender, Control).Tag) = "nClient" Then
            Dim nClient As String = ""
            'If TypeOf sender Is ComboBox Then
            nClient = Convert.ToString(CType(sender, ComboBox).SelectedValue)
            'End If
            'If nClient = "" Then
            'nClient = Convert.ToString(Me.CurrentDrv("nClient"))
            'End If

            'MODIF TV 19/01/2012 -------------------
            If (Convert.ToString(Me.CurrentDrv("nClient")) <> Convert.ToString(CType(sender, ComboBox).SelectedValue)) Then
                Me.CurrentDrv("nClient") = CType(sender, ComboBox).SelectedValue
                Me.PieceBindingSource.ResetBindings(True)
            End If
            '---------------------------------------

            NClientChanged(nClient)
        End If
    End Sub
#End Region

#Region " Grid Events "
    Private Sub dgvPieceDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPieceDetail.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If Me.dgvPieceDetail.ReadOnly Then Exit Sub
        If e.ColumnIndex = ColBtCodeProduit.Index Then
            ShowSelectionProduit(Me.dgvPieceDetail.Rows(e.RowIndex).Cells(CodeProduitDataGridViewTextBoxColumn.Index))
        ElseIf e.ColumnIndex = ColBtNLot.Index Then
            ShowSelectionLot(Me.dgvPieceDetail.Rows(e.RowIndex).Cells(NLotDataGridViewTextBoxColumn.Index))
            'Dim drv As DataRowView = Cast(Of DataRowView)(Me.MouvDetailBindingSource.Current)
            'If Convert.ToString(drv("CodeProduit")).Length = 0 Then Exit Sub
            'Using fr As New FrRechLot(Convert.ToString(drv("CodeProduit")))
            '    fr.ExcludedNMvt = CInt(Me.CurrentMouvRow.nMouvement)
            '    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '        Dim cellLot As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.nLot.Index)
            '        cellLot.Value = fr.Result
            '        Cast(Of DataGridView)(sender).Refresh()
            '    End If
            'End Using
        End If
    End Sub

    Private Sub dgvPieceDetail_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPieceDetail.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = CodeProduitDataGridViewTextBoxColumn.Index Then
            Dim cell As DataGridViewTextBoxCell = CType(Me.dgvPieceDetail.Rows(e.RowIndex).Cells(CodeProduitDataGridViewTextBoxColumn.Index), DataGridViewTextBoxCell)
            If Convert.ToString(cell.Value) <> "" Then
                Dim FrP As New FrProduit(Convert.ToString(cell.Value))
                AddHandler FrP.FormClosed, AddressOf RechargerProduit
                FrP.Owner = Me
                FrP.Show()
            End If
        ElseIf e.ColumnIndex = NLotDataGridViewTextBoxColumn.Index Then
            'Dim cell As DataGridViewTextBoxCell = CType(Me.dgvPieceDetail.Rows(e.RowIndex).Cells(NLotDataGridViewTextBoxColumn.Index), DataGridViewTextBoxCell)
            'TODO Dim FrP As New FrLot(ds, Convert.ToString(cell.Value))
            'FrP.Owner = Me
            'FrP.Show()
        ElseIf e.ColumnIndex = LibelleDataGridViewTextBoxColumn.Index Then
            dg_ZoomTextBoxCells(sender, e)
        End If
    End Sub

    Private Sub dgvPieceDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPieceDetail.CellEnter
        Select Case e.ColumnIndex
            Case Unite2DataGridViewTextBoxColumn.Index
                Dim c As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
                If Not c.OwningRow.IsNewRow Then
                    c.ReadOnly = Convert.ToString(c.OwningRow.Cells(LibUnite2DataGridViewTextBoxColumn.Index).Value).Length = 0
                    If c.ReadOnly Then SendKeys.Send("{TAB}") 'Pour passer tout de suite à la cellule suivante               
                End If
        End Select
    End Sub

    'MODIF TV 07/09/2012 -------
    Private Sub dgvPieceDetail_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvPieceDetail.CellValidating
        If e.RowIndex < 0 Then Exit Sub

        If skip Then Exit Sub

        If Not (Me.CurrentDetailDrv Is Nothing) Then
            If (Me.CurrentDetailDrv.IsNew) Then
                Dim row As DataGridViewRow = Cast(Of DataGridView)(sender).Rows(e.RowIndex)

                'Affectation du nDetailDevis
                If (row.Cells(NDetailDevisDataGridViewTextBoxColumn.Index).Value Is Nothing) OrElse IsDBNull(row.Cells(NDetailDevisDataGridViewTextBoxColumn.Index).Value) Then
                    row.Cells(NDetailDevisDataGridViewTextBoxColumn.Index).Value = Pieces.GetNDetailDevis(Me._NomTableDetail)
                End If
            End If
        End If
    End Sub
    'FIN MODIF TV 07/09/2012 -------

    Private Sub dgvPieceDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPieceDetail.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub

        If skip Then Exit Sub

        Dim row As DataGridViewRow = Cast(Of DataGridView)(sender).Rows(e.RowIndex)
        Dim colChanged As String = Cast(Of DataGridView)(sender).Columns(e.ColumnIndex).DataPropertyName

        Select Case colChanged
            Case "CodeProduit"
                ActionChangementCodeProduit(row)
            Case "Unite1", "Unite2", "PrixUHT", "PrixUTTC", "Remise"
                ActionChangementLigneMontant(row, colChanged)
            Case "TTVA"
                ActionChangementLigneMontant(row, colChanged)
            Case "CoefAV"
                If FrApplication.Modules.ModuleGestionMarge Then
                    CalculPrixVenteTTCTheo(row, colChanged)
                End If
            Case "PrixAHT"
            Case Else
        End Select
    End Sub

    Private Sub ctxLigne_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxLigne.Opening
        If Me.dgvPieceDetail.CurrentRow.IsNewRow OrElse Me.dgvPieceDetail.SelectedRows.Count = 0 Then e.Cancel = True
    End Sub

    Private Sub SupprimerLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Me.dgvPieceDetail.CurrentRow.IsNewRow Then
            Me.dgvPieceDetail.CancelEdit()
            Exit Sub
        End If
        'Me.suppressionEnCours = True
        Try
            Me.PieceDetailBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
        'Me.suppressionEnCours = False
    End Sub

    Private Sub DupliquerLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripMenuItem.Click
        If Me.dgvPieceDetail.CurrentRow.IsNewRow Then Exit Sub
        If Me.PieceDetailBindingSource.Position < 0 Then Exit Sub

        Dim curDrv As DataRowView = CType(Me.PieceDetailBindingSource.Current, DataRowView)
        Dim newDrv As DataRowView = CType(Me.PieceDetailBindingSource.AddNew, DataRowView)

        If Not newDrv Is Nothing Then
            newDrv.BeginEdit()
            CopyRow(curDrv.Row, newDrv.Row)

            'MODIF TV 07/09/2012 ----------------
            'Affecte un nouveau nDetailDevis à la ligne dupliquée
            newDrv.Item("nDetailDevis") = Pieces.GetNDetailDevis(Me._NomTableDetail)
            'FIN MODIF TV 07/09/2012 ------------

            newDrv.EndEdit()
            Me.PieceDetailBindingSource.ResetBindings(False)
        End If
    End Sub

    Private Sub recalcul()
        'legrain 17/04/2015 
        'For Each row As DataRow In dgvPieceDetail.Rows
        'For Each row As DataRow In PieceDetailBindingSource.Rows
        If FacturationTTC Then 'legrain 13/01/2016
            CalculTTCToHT() 'legrain 13/01/2016
        Else
            CalculHTToTTC()
        End If
        'For Each view As DataRowView In PieceDetailBindingSource
        'Dim row = View.Row
        'Dim a As DataRowChangeEventArgs
        'a = New DataRowChangeEventArgs(row, DataRowAction.Change)
        'RowDetailChanged(row, a)
        ''Next row
        'Next
    End Sub

    Private Sub RowDetailChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        If skip Then Exit Sub
        If e.Action = DataRowAction.Change Or e.Action = DataRowAction.Add Then
            skip = True
            Dim colBase As String
            Dim colDest As String
            Dim modeTaux As RecapTVA.ModeTaux
            If Me.FacturationTTC Then
                colBase = "MontantLigneTTC"
                colDest = "MontantLigneHT"
                modeTaux = RecapTVA.ModeTaux.TtcToHt
            Else
                colBase = "MontantLigneHT"
                colDest = "MontantLigneTTC"
                modeTaux = RecapTVA.ModeTaux.HtToTtc
            End If

            Dim montantBase As Nullable(Of Decimal) = Nullabilify(Of Decimal)(e.Row(colBase))


            Dim TTVA As String = Convert.ToString(e.Row("TTVA"))
            Dim txTVA As Nullable(Of Decimal) = RecapTVA.GetTauxEffectifTVA(ds.Tables("TVA"), TTVA, modeTaux)

            'Calcul du montant de la ligne
            Dim montantDest As Nullable(Of Decimal) = NullableMult(montantBase, txTVA)
            If montantDest.HasValue Then montantDest = Decimal.Round(montantDest.Value, 2, MidpointRounding.AwayFromZero)

            e.Row.BeginEdit()

            'Mise à jour de la ligne
            e.Row(colDest) = DBNullify(montantDest)

            'Calcul du montant TVA de la ligne
            If Me.FacturationTTC Then
                e.Row("MontantLigneTVA") = DBNullify(NullableOp(AddressOf Decimal.Subtract, montantBase, montantDest))
            Else
                e.Row("MontantLigneTVA") = DBNullify(NullableOp(AddressOf Decimal.Subtract, montantDest, montantBase))
            End If
            e.Row.EndEdit()

            'Recalculer le montant de la facture
            'Il faut gérer la réentrance
            If Not _stop Then CalculMontant()
            skip = False
        ElseIf e.Action = DataRowAction.Delete Then
            CalculMontant()
        End If
        MajBoutons()
    End Sub
#End Region

#Region " Actions Facture "
    Private Sub ConfigModeFacturation()
        Dim drv As DataRowView = Me.CurrentDrv
        Me.FacturationTTC = Not IsDBNull(drv("FacturationTTC")) AndAlso CBool(drv("FacturationTTC"))
        ConfigurerColHTTTC()
    End Sub

    Private Sub ConfigurerColHTTTC()
        If Not Me.FacturationTTC Then
            With Me.PrixUDataGridViewTextBoxColumn
                .HeaderText = "P. " & Pieces.GetAV(Me.TypePiece) & " U HT"
                .DataPropertyName = "PrixUHT"
            End With
            With Me.MontantLigneDataGridViewTextBoxColumn
                .HeaderText = "Montant HT"
                .DataPropertyName = "MontantLigneHT"
            End With
        Else
            With Me.PrixUDataGridViewTextBoxColumn
                .HeaderText = "P. " & Pieces.GetAV(Me.TypePiece) & " U TTC"
                .DataPropertyName = "PrixUTTC"
            End With
            With Me.MontantLigneDataGridViewTextBoxColumn
                .HeaderText = "Montant TTC"
                .DataPropertyName = "MontantLigneTTC"
            End With
        End If
    End Sub

    Private Sub NClientChanged(Optional ByVal nClient As String = "")
        If _stop Then Exit Sub

        'Lors du chargement de la form, ne pas effectuer d'action
        If Not (Me._ChargementForm) Or (Me.FromEntreprise) Then
            Dim rwv As DataRowView = Me.CurrentDrv

            If nClient.Length = 0 Then
                If Not IsDBNull(rwv("nClient")) Then
                    nClient = Convert.ToString(rwv("nClient"))
                End If
            End If

            If nClient.Length = 0 Then Exit Sub

            'If CInt(nClient) = _nclient Then Exit Sub 'Pas de modif du client

            'Me.id = nDevis


            'If (Me.id IsNot Nothing) AndAlso (CInt(Me.id) >= 0) Then 'si en modification
            '    Dim rws() As DataRow = ds.Tables("Entreprise").Select("nEntreprise=" & nClient)

            '    If rws.Length > 0 Then
            '        _stop = True
            '        rwv.BeginEdit()
            '        Dim rwEnt As DataRow = rws(0)

            '        'Gestion de l'Adresse
            '        rwv.Item("AdresseFacture") = Pieces.GetAdresseFacture(CInt(nClient), _NomTable)

            '        'Gestion de la Facturation TTC
            '        If rwEnt.Table.Columns.Contains("FacturationTTC") Then
            '            If CBool(rwv("FacturationTTC")) <> CBool(rwEnt("FacturationTTC")) Then
            '                rwv("FacturationTTC") = rwEnt("FacturationTTC")
            '                Me.FacturationTTC = CBool(rwv("FacturationTTC"))
            '                ConfigurerColHTTTC()
            '                If Me.FacturationTTC Then
            '                    CalculHTToTTC()
            '                Else
            '                    CalculTTCToHT()
            '                End If
            '            End If
            '        End If

            '        rwv.EndEdit()
            '        _stop = False
            '    End If
            'Else 'si en création
            Dim rws() As DataRow = ds.Tables("Entreprise").Select("nEntreprise=" & nClient)

            If rws.Length > 0 Then
                _stop = True
                rwv.BeginEdit()
                Dim rwEnt As DataRow = rws(0)

                'Gestion de l'Adresse
                rwv.Item("AdresseFacture") = Pieces.GetAdresseFacture(CInt(nClient), _NomTable)

                'Gestion de la Facturation TTC
                If rwEnt.Table.Columns.Contains("FacturationTTC") Then
                    If CBool(rwv("FacturationTTC")) <> CBool(rwEnt("FacturationTTC")) Then
                        rwv("FacturationTTC") = rwEnt("FacturationTTC")
                        Me.FacturationTTC = CBool(rwv("FacturationTTC"))
                        ConfigurerColHTTTC()
                        If Me.FacturationTTC Then
                            CalculHTToTTC()
                        Else
                            CalculTTCToHT()
                        End If
                    End If
                End If

                'Gestion de la date d'échéance
                If _NomTable = "VFacture" AndAlso Not IsDBNull(rwv.Item("DateFacture")) Then
                    Dim nbJEch As Integer = 0
                    Dim finM As Boolean = False

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
                        Dim dateEch As Date = CDate(rwv.Item("DateFacture")).AddDays(nbJEch)
                        If finM Then
                            dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
                        End If
                        rwv.Item("DateEcheance") = dateEch
                    End If
                End If

                'Recopier le tarif du client
                If rwEnt.Table.Columns.Contains("nTarif") AndAlso rwv.Row.Table.Columns.Contains("nTarif") Then
                    rwv.Item("nTarif") = rwEnt.Item("nTarif")
                    'AppliquerTarif(Nullabilify(Of Integer)(rwv("nTarif")))
                End If

                'Recopier la remise du client
                If rwEnt.Table.Columns.Contains("Remise") AndAlso rwv.Row.Table.Columns.Contains("Remise") Then
                    rwv.Item("Remise") = rwEnt.Item("Remise")
                    'AppliquerRemise(rwv("Remise"))
                End If

                'Recopier le commercial du client
                If rwEnt.Table.Columns.Contains("nCommercial") AndAlso rwv.Row.Table.Columns.Contains("nCommercial") Then
                    rwv.Item("nCommercial") = rwEnt.Item("nCommercial")
                End If

                'Recopier le tx de comm du client
                If rwEnt.Table.Columns.Contains("TxCommission") AndAlso rwv.Row.Table.Columns.Contains("TxCommission") Then
                    rwv.Item("TxCommission") = rwEnt.Item("TxCommission")
                End If

                'Si le client est marqué pour l'export, appliquer les bons comptes de vente à chaque produit
                If FrApplication.Modules.ModuleCompta Then
                    If rwEnt.Table.Columns.Contains("IsExport") Then
                        AppliquerComptesExport(CBool(ReplaceDbNull(rwEnt("IsExport"), False)))
                        rwv.Item("Remise") = rwEnt.Item("Remise")
                        'AppliquerRemise(rwv("Remise"))
                    End If
                End If

                rwv.EndEdit()
                _stop = False
            End If
            'End If
            'Else
            'Me._ChargementForm = False
        End If
    End Sub

    Private Sub AffecterRemise()
        If Me.PieceBindingSource.Position >= 0 Then
            Me.PieceBindingSource.EndEdit()
            Dim TxRemise As Decimal = 0
            Dim MontantHT As Decimal = 0
            Dim MontantRemise As Decimal = 0
            If Not Me.CurrentDrv.Row.GetParentRow(_NomLiaisonClient).IsNull("Remise") Then
                TxRemise = CDec(Me.CurrentDrv.Row.GetParentRow(_NomLiaisonClient).Item("Remise"))
                MontantHT = CDec(Me.CurrentDrv("MontantHT"))
                MontantRemise = System.Math.Round(MontantHT * TxRemise / 100, 2)

                Dim rwN As DataRow = Me.ds.Tables(_NomTableDetail).NewRow
                With rwN
                    .Item("nDevis") = Me.nDevis
                    .Item("CodeProduit") = "Rem"
                    .Item("Libelle") = "Remise de " & TxRemise & " %"
                    .Item("Unite1") = 1
                    .Item("PrixUHT") = -MontantRemise
                    'rwN.Item("TTVA") = 19.6
                    .Item("MontantLigneHT") = -MontantRemise
                End With
                Me.ds.Tables(_NomTableDetail).Rows.Add(rwN)
            End If
        End If
    End Sub

    Private Sub AppliquerTarif(ByVal nTarif As Nullable(Of Integer))
        For Each drv As DataRowView In Me.PieceDetailBindingSource
            Dim drProduit As DataRow = GetProduitRow(drv)
            If drProduit IsNot Nothing Then
                If Me.FacturationTTC Then
                    drv("PrixUTTC") = DBNullify(Of Decimal)(GetPrixProduit(drProduit, nTarif))
                Else
                    drv("PrixUHT") = DBNullify(Of Decimal)(GetPrixProduit(drProduit, nTarif))
                End If
            End If
        Next
        PieceDetailBindingSource.ResetBindings(False)
    End Sub

    Private Sub AppliquerComptesExport(ByVal isExport As Boolean)
        If Pieces.GetAV(Me.TypePiece) = "A" Then Exit Sub
        For Each drv As DataRowView In Me.PieceDetailBindingSource
            Dim drProduit As DataRow = GetProduitRow(drv)
            If drProduit IsNot Nothing Then
                If isExport Then
                    drv("NCompte") = IIf(drProduit.IsNull("NCompteX"), drProduit("NCompteV"), drProduit("NCompteX"))
                    drv("NActivite") = IIf(drProduit.IsNull("NActiviteX"), drProduit("NActiviteV"), drProduit("NActiviteX"))
                Else
                    drv("NCompte") = drProduit("NCompteV")
                    drv("NActivite") = drProduit("NActiviteV")
                End If
            End If
        Next
        PieceDetailBindingSource.ResetBindings(False)
    End Sub

    Private Sub AppliquerRemise(ByVal remise As Object)
        For Each drv As DataRowView In Me.PieceDetailBindingSource
            drv("Remise") = remise
        Next
        PieceDetailBindingSource.ResetBindings(False)
    End Sub

#Region " Réglements "
    Private Sub RegleFactureIrrecouvrable()
        If Me.TypePiece <> Pieces.TypePieces.VFacture Then Exit Sub

        Me.dgvPieceDetail.EndEdit()
        Me.PieceDetailBindingSource.EndEdit()
        Me.PieceBindingSource.EndEdit()

        If Me.PieceBindingSource.Position >= 0 Then
            Dim drFact As DataRow = Me.CurrentDrv.Row
            If drFact.IsNull("Paye") OrElse Not CBool(drFact("Paye")) Then
                If MsgBox("Le solde des factures sélectionnées sera enregistré comme " & vbCrLf & _
                        "créance irrécouvrable et les factures seront marquées comme réglées." & vbCrLf & _
                        "Voulez-vous continuer ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Créance irrécouvrable") = MsgBoxResult.No Then Exit Sub
                FrReglement.CreerReglementIrrecouvrable(drFact)
                MsgBox("Réglement enregistré", MsgBoxStyle.Information)
                FrReglement_Closed(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub RegleFacture(Optional ByVal stopApresAvances As Boolean = False)
        Me.dgvPieceDetail.EndEdit()
        Me.PieceDetailBindingSource.EndEdit()
        Me.PieceBindingSource.EndEdit()

        If Me.PieceBindingSource.Position < 0 Then Exit Sub

        Dim dr As DataRow = Me.CurrentDrv.Row
        'Vérif que la facture est pas déjà payée
        If Not dr.IsNull("Paye") AndAlso CBool(dr("Paye")) Then Exit Sub
        Dim lstFactures As New List(Of DataRow)
        lstFactures.Add(dr)
        'Gestion des avances
        FrReglement.GestionAvanceClient(CInt(dr("nClient")), lstFactures, stopApresAvances)

        'Si les avances ont suffi à payer la facture
        If (Not dr.IsNull("Paye") AndAlso CBool(dr("Paye"))) OrElse stopApresAvances Then
            FrReglement_Closed(Nothing, Nothing)
            Exit Sub
        End If

        'Sinon, on entre en saisie de réglement
        With New FrReglement(lstFactures)
            If Me.TypePiece = Pieces.TypePieces.AFacture Then
                .TypeRegl = FrListeReglement.TypeReglement.Achat
            Else
                .TypeRegl = FrListeReglement.TypeReglement.Vente
            End If
            .Owner = Me
            AddHandler .Closed, AddressOf FrReglement_Closed
            .Show()
        End With


    End Sub

    Private Sub FrReglement_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.PieceBindingSource.Position < 0 Then Exit Sub

        Me.TbRegler.Enabled = Not (Me.EstFacturePayee(CDec(Me.CurrentDrv("nDevis"))))

        'RechargerPiece()
        'Me.TbRegler.Enabled = Not CBool(ReplaceDbNull(Me.CurrentDrv("Paye"), False))
    End Sub

    Private Sub AfficherReglement()
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, _NomTableReglement & "_Detail", String.Format("nFacture={0}", Me.nDevis))
        End Using
        Dim typeRegl As FrListeReglement.TypeReglement = CType(IIf(Me.TypePiece = Pieces.TypePieces.AFacture, FrListeReglement.TypeReglement.Achat, FrListeReglement.TypeReglement.Vente), FrListeReglement.TypeReglement)
        Dim rw() As DataRow = ds.Tables(_NomTableReglement & "_Detail").Select()
        If rw.Length = 1 Then
            Dim frReglement As New FrReglement(CInt(rw(0)("nReglement")))
            AddHandler frReglement.Closed, AddressOf FrReglement_Closed
            frReglement.TypeRegl = typeRegl
            frReglement.Owner = Me
            frReglement.Show()
        ElseIf rw.Length > 1 Then
            Dim r As DataRow
            Dim nReglement As Integer = CInt(rw(0)("nReglement"))
            Dim OneReglementOnly As Boolean = True
            For Each r In rw
                If nReglement <> CInt(r.Item("nReglement")) Then
                    OneReglementOnly = False
                    Exit For
                End If
            Next
            If OneReglementOnly Then
                Dim frReglement As New FrReglement(nReglement)
                AddHandler frReglement.Closed, AddressOf FrReglement_Closed
                frReglement.TypeRegl = typeRegl
                frReglement.Owner = Me
                frReglement.Show()
            Else
                Dim frLstReglement As New FrListeReglement()
                Dim rwi As DataRow
                Dim strFiltre As String = ""
                For Each rwi In rw
                    If strFiltre.Length > 0 Then
                        strFiltre += " Or "
                    End If
                    strFiltre += "nReglement=" & Convert.ToString(rwi("nReglement"))
                Next
                AddHandler frLstReglement.Closed, AddressOf FrReglement_Closed
                frLstReglement.FiltrePlus = strFiltre
                frLstReglement.TypeRegl = typeRegl
                frLstReglement.Show()
            End If
        Else
            MessageBox.Show("Pas de règlement disponible pour cette pièce.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region

#Region " Impressions "
    Private Sub ImprimerRelance()
        If Me.TypePiece <> Pieces.TypePieces.VFacture Then Exit Sub
        If Me.PieceBindingSource.Position < 0 Then Exit Sub

        Me.PieceBindingSource.EndEdit()
        If CBool(Me.CurrentDrv("Paye")) Then
            MsgBox("Cette facture a déjà été réglée.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim lstFactures As New List(Of Integer)
        lstFactures.Add(Me.nDevis)
        FrListePieces2.ImprimerRelance(lstFactures)
    End Sub

    Private Sub ImprimerDevis(Optional ByVal direct As Boolean = False)
        'On met le focus sur le premier contrôle du conteneur gcFacturation afin de valider les saisies
        If (Me.gcFacturation.Controls.Count > 0) Then
            Me.gcFacturation.Controls(0).Focus()
        End If

        If Not DemanderEnregistrement() Then Exit Sub

        Dim factureMulti As Boolean = False
        Dim ImpressionTTC As Boolean = CBool(Me.CurrentDrv("FacturationTTC"))
        Dim nDevis As Long = CLng(Me.CurrentDrv("nDevis"))
        Dim nClient As Long = CLng(Me.CurrentDrv("nClient"))

        'TODO Impression ABonReception ne marche pas ??
        Dim myDs As DataSet = Pieces.PreparerDataset(Me.TypePiece)
        Dim _NomTableReglement As String = CStr(IIf(Me.TypePiece = Pieces.TypePieces.VFacture, "Reglement", "AReglement"))
        Using s As New SqlProxy
            s.FillBy(myDs, "Entreprise", "nEntreprise=" & nClient, False)
            s.FillBy(myDs, _NomTable, "nDevis=" & nDevis, False)
            If String.Compare(_NomTable, "VFacture") = 0 Then 'legrain modif 8/10/2013
                s.FillBy(myDs, "VBonLivraison", "nOrigine=" & nDevis, False)
            End If
            s.FillBy(myDs, _NomTableDetail, "nDevis=" & nDevis, False)
            Select Case Me.TypePiece
                Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
                    s.FillBy(myDs, _NomTableReglement & "_Detail", "nFacture=" & nDevis, False)
                    s.FillBy(myDs, _NomTableReglement, String.Format("nReglement IN (SELECT nReglement FROM {0}_Detail WHERE nFacture={1})", _NomTableReglement, nDevis), False)

                    'Chargement du nPrescripteur
                    If Not (IsDBNull(Me.CurrentDrv("nPrescripteur"))) Then
                        s.FillBy(myDs, "Entreprise", "nEntreprise=" & CStr(Me.CurrentDrv("nPrescripteur")), False)
                    End If
            End Select
            If Me.TypePiece = Pieces.TypePieces.VFacture Then
                'FACTURE MULTI
                factureMulti = (s.ExecuteScalarInt("SELECT COUNT(*) FROM VBonLivraison WHERE nOrigine=" & CStr(nDevis)) > 1)

                'SITUATION COMPTE CLIENT
                Pieces.AjouterCompteClient(myDs, _NomTable)

                'TRAITE DIRECTEMENT A PARTIR DE L'ETAT DE FACTURE 
                'Facture Approfact : rempli et ajoute la table VFacture_Detail_Redevance
                'au Dataset. Elle contient toutes les lignes de détail de la facture concernant les produits
                'ayant un code produit commencant par RED-
                'Pieces.RemplirVFacture_Detail_Redevance(myDs)
            End If
        End Using

        'DETAIL TVA
        Pieces.RemplisDetailTVA(myDs)

        'Se positionne sur le dernier enregistrement du DataGridView des détails de la pièce
        'car sinon la modification d'un élément de la ligne qui a le focus ne prend pas en compte les modifications
        'tant que l'on reste sur cette ligne
        If (Me.dgvPieceDetail.Rows.Count > 0) Then
            Me.dgvPieceDetail.Rows(Me.dgvPieceDetail.Rows.Count - 1).Cells(1).Selected = True
        End If

        'Recherche du secteur / service
        Dim secteur As String = String.Empty

        If Not (IsDBNull(Me.CurrentDrv("Secteur"))) Then
            If Not (String.IsNullOrEmpty(CStr(Me.CurrentDrv("Secteur")))) Then
                secteur = CStr(Me.CurrentDrv("Secteur"))
            End If
        End If

        Dim fr As FrFusion = Pieces.TrouverRapport(myDs, _NomTable, ImpressionTTC, factureMulti, FrApplication.Modules.ModuleGestionMarge, secteur)
        If Not fr Is Nothing Then
            GestionImpression.AppliquerParametres(fr, _NomTable)
            GestionImpression.GestionLogo(fr)
            fr.nCle = nDevis
            If direct Then
                fr.ImprimerDirectSimple()
                ImpressionFactureClosed(fr, Nothing)
                fr.Dispose()
            Else
                If Me.TypePiece = Pieces.TypePieces.VFacture Then AddHandler fr.Closed, AddressOf ImpressionFactureClosed
                fr.Show()
            End If
        End If
    End Sub

    Private Sub ImpressionFactureClosed(ByVal sender As Object, ByVal e As EventArgs)
        'Gestion de l'option marquer : jamais/demander
        If Not CBool(ParametresApplication.ValeurParametre("MarquerFacturesImprimees", True)) Then Exit Sub
        If _NomTable <> "VFacture" Then Exit Sub

        Dim drv As DataRowView = Me.CurrentDrv

        If Not drv.Row.Table.Columns.Contains("DateImpr") Then Exit Sub

        'Ne marquer que la première impression (evite de reposer toujours la question)
        If Not IsDBNull(drv("DateImpr")) Then Exit Sub

        'Demander s'il faut marquer la facture
        If MsgBox("Voulez-vous marquer la facture comme imprimée ?", MsgBoxStyle.YesNo, "Impression") = MsgBoxResult.No Then Exit Sub

        'Si oui, MAJ le champs DateImpr
        'MODIF TV 16/01/2012

        Using sqlConn As New SqlClient.SqlConnection(My.Settings.AgrifactConnString)
            sqlConn.Open()

            Dim sqlQuery As String = String.Format("UPDATE {0} SET DateImpr=GETDATE() WHERE nDevis={1}", Me.TypePiece.ToString(), CStr(drv("nDevis")))

            Using sqlComm As New SqlClient.SqlCommand(sqlQuery, sqlConn)
                sqlComm.ExecuteNonQuery()
            End Using
        End Using

        'drv("DateImpr") = Now
        'drv.EndEdit()

        'Désactiver le formulaire
        AutoriseModif(False)
    End Sub
#End Region

#Region " ApproFact "
    Private Sub GestionApproFact()
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        AgriFact.GestionApproFact.AjoutLignesRedevance(Me.ds, Me.nDevis)
        'Recalculer le montant de la facture 
        If (Me.ds.HasChanges()) Then
            CalculMontant()
        End If
    End Sub

    Private Sub VerifQuantitesApproFact()
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        If Not Me.ds.Tables.Contains("Appro_BCD_AFD") Then Exit Sub
        'Vérification
        Dim rwFact As DataRow = Me.CurrentDrv.Row
        Dim rwsAFD() As DataRow = rwFact.GetChildRows(_NomLiaison)
        For Each rwAFD As DataRow In rwsAFD
            If Not rwAFD.IsNull("Unite1") Then
                Dim o As Object = Me.ds.Tables("Appro_BCD_AFD").Compute("Sum(AF_Unite1)", "AFD_nDevisDetail=" & CInt(rwAFD("nDetailDevis")))
                If Not IsDBNull(o) Then
                    If CDec(o) <> CDec(rwAFD("Unite1")) Then
                        'MONTRER LA GRILLE DE SAISIE QUI PERMET D'AJUSTER L'AFFECTATION DES QUANTITES A CHAQUE CLIENT POUR CE PRODUIT
                        Dim fr As New FrAjusterCommandeFourn
                        With fr
                            .ds = Me.ds
                            .AF_nDevisDetail = CInt(rwAFD("nDetailDevis"))
                        End With
                        If fr.ShowDialog(Me) = DialogResult.Cancel Then Exit For
                    End If
                End If
            End If
        Next
    End Sub
#End Region

#End Region

#Region " CalculFacture "

#Region " Shared "
    Public Shared Sub CalculMontant(ByRef ds As DataSet, ByRef drFact As DataRow, ByVal _NomLiaison As String, ByVal TypePiece As Pieces.TypePieces, Optional ByRef LstTxTVA As ListView = Nothing, Optional ByRef LbMontantHT As Label = Nothing, Optional ByRef LbMontantTVA As Label = Nothing, Optional ByRef LbMontantTTC As Label = Nothing)
        'TODO C'est là dedans qu'il faut gérer l'ajout ou le calcul des produits liés
        Dim MontantHT As Nullable(Of Decimal) = 0
        Dim MontantTVA As Nullable(Of Decimal) = 0
        Dim MontantTTC As Nullable(Of Decimal) = 0
        Dim MontantHTVente As Nullable(Of Decimal) = 0
        Dim MontantTTCVente As Nullable(Of Decimal) = 0
        Dim recapsTVA As New Dictionary(Of String, RecapTVA)
        Dim GestionMarge As Boolean = FrApplication.Modules.ModuleGestionMarge
        Dim FacturationTTC As Boolean = CBool(ReplaceDbNull(drFact("FacturationTTC"), False))

        '========================================================================
        'SOMME DU MONTANT DE LA FACTURE(HT OU TTC) ET RECENSEMENT DES TAUX DE TVA
        '========================================================================
        Dim hasChanged As Boolean = False
        For Each drDetail As DataRow In drFact.GetChildRows(_NomLiaison)
            hasChanged = hasChanged OrElse (drDetail.RowState = DataRowState.Added) OrElse (drDetail.RowState = DataRowState.Modified)

            'Si on a un montant
            If Not IsDBNull(drDetail("MontantLigneHT")) Or Not IsDBNull(drDetail("MontantLigneTTC")) Then
                'Trouver le taux de TVA de la ligne
                Dim ttva As String = CStr(ReplaceDbNull(drDetail("TTVA"), ""))
                If Not FacturationTTC Then
                    Dim montantLigneHT As Nullable(Of Decimal) = Nullabilify(Of Decimal)(drDetail("MontantLigneHT"))
                    MontantHT = NullableOp(AddressOf Decimal.Add, MontantHT, montantLigneHT)
                    If montantLigneHT.HasValue Then
                        If recapsTVA.ContainsKey(ttva) Then
                            recapsTVA(ttva).AddMontantHT(montantLigneHT.Value)
                        Else
                            Dim r As New RecapTVA(ds, ttva)
                            r.CalculerFromHT(montantLigneHT.Value)
                            recapsTVA.Add(ttva, r)
                        End If
                    End If
                Else
                    Dim montantLigneTTC As Nullable(Of Decimal) = Nullabilify(Of Decimal)(drDetail("MontantLigneTTC"))
                    MontantTTC = NullableOp(AddressOf Decimal.Add, MontantTTC, montantLigneTTC)
                    If montantLigneTTC.HasValue Then
                        If recapsTVA.ContainsKey(ttva) Then
                            recapsTVA(ttva).AddMontantTTC(montantLigneTTC.Value)
                        Else
                            Dim r As New RecapTVA(ds, ttva)
                            r.CalculerFromTTC(montantLigneTTC.Value)
                            recapsTVA.Add(ttva, r)
                        End If
                    End If
                End If
            End If
            'Cas de la gestion de la marge : on calcule aussi les montants de vente
            If Pieces.GetAV(TypePiece) = "A" And GestionMarge Then
                Dim MontantLigneTTCVente As Nullable(Of Decimal) = Nullabilify(Of Decimal)(drDetail("MontantLigneTTCVente"))
                'MontantHTVente = NullableOp(AddressOf Decimal.Add, MontantHTVente, MontantLigneTTCVente / (1 + TauxTva / 100))
                MontantTTCVente = NullableOp(AddressOf Decimal.Add, MontantTTCVente, MontantLigneTTCVente)
            End If
        Next
        '==============================
        'MAJ DES MONTANTS DE LA FACTURE
        '==============================
        'If hasChanged Then
        drFact.BeginEdit()
        If FacturationTTC Then
            drFact("MontantTTC") = DBNullify(MontantTTC)
            'Calculer le montant HT à partir des recap pour eviter les erreurs de centime
            MontantHT = New Nullable(Of Decimal)
            For Each r As RecapTVA In recapsTVA.Values
                If Not MontantHT.HasValue Then
                    MontantHT = r.BaseHT
                Else
                    MontantHT = MontantHT.Value + r.BaseHT
                End If
            Next
            drFact("MontantHT") = DBNullify(MontantHT)
        Else
            drFact("MontantHT") = DBNullify(MontantHT)
            'Calculer le montant TTC à partir des recap pour eviter les erreurs de centime
            MontantTTC = New Nullable(Of Decimal)
            For Each r As RecapTVA In recapsTVA.Values
                If Not MontantTTC.HasValue Then
                    MontantTTC = r.MontantTTC
                Else
                    MontantTTC = MontantTTC.Value + r.MontantTTC
                End If
            Next
            drFact("MontantTTC") = DBNullify(MontantTTC)
        End If
        drFact("MontantTVA") = DBNullify(NullableOp(AddressOf Decimal.Subtract, MontantTTC, MontantHT))
        drFact.EndEdit()

        'End If
        '====================================
        'REMPLISSAGE DU LISTVIEW DE RECAP TVA
        '====================================
        If LstTxTVA IsNot Nothing Then AfficherRecapTVA(LstTxTVA, recapsTVA)

        '=========================================================
        ' MAJ DES MONTANTS TVA ET HT/TTC POUR LES LIGNES DE DETAIL
        '=========================================================


        ''Gestion de la dernière ligne DETAIL
        'Dim MontantTxHTTotal As Decimal = Actigram.MathUtil.ArithmeticRound(RecapTxTVA.MontantHTTaux(tx), 2)
        'Dim MontantTxTVATotal As Decimal = Actigram.MathUtil.ArithmeticRound(RecapTxTVA.MontantTVATaux(tx), 2)
        'Dim MontantTxTTCTotal As Decimal = Actigram.MathUtil.ArithmeticRound(RecapTxTVA.MontantTTCTaux(tx), 2)
        'With rws(rws.Length - 1)
        ''Les montants de cette ligne sont les montants totaux moins ceux affectés aux autres lignes
        ' .Item("MontantLigneTVA") = MontantTxTVATotal - MontantTxTVAAffecte
        ' If Not FacturationTTC Then
        '.Item("MontantLigneTTC") = (MontantTxHTTotal + MontantTxTVATotal) - MontantTxTTCAffecte
        '  Else
        ' .Item("MontantLigneHT") = (MontantTxTTCTotal - MontantTxTVATotal) - MontantTxHTAffecte
        '  End If
        ' End With
        '  Next
        'pierre modif
        'For Each drDetail As DataRow In drFact.GetChildRows(_NomLiaison)
        'hasChanged = hasChanged OrElse (drDetail.RowState = DataRowState.Added) OrElse (drDetail.RowState = DataRowState.Modified)

        'Si on a un montant
        'If Not IsDBNull(drDetail("MontantLigneHT")) Or Not IsDBNull(drDetail("MontantLigneTTC")) Then
        'Trouver le taux de TVA de la ligne
        'Dim ttva As String = CStr(ReplaceDbNull(drDetail("TTVA"), ""))
        'Dim r As New RecapTVA(ds, ttva)
        'If Not FacturationTTC Then
        'Dim montantLigneHT As Nullable(Of Decimal) = Nullabilify(Of Decimal)(drDetail("MontantLigneHT"))
        'r.CalculerFromHT(montantLigneHT.Value)
        'drDetail("MontantLigneTTC") = r.MontantTTC
        ' Else
        ' Dim montantLigneTTC As Nullable(Of Decimal) = Nullabilify(Of Decimal)(drDetail("MontantLigneTTC"))
        'r.CalculerFromTTC(montantLigneTTC.Value)
        'drDetail("MontantLigneHT") = r.BaseHT
        ' End If
        'drDetail("MontantLigneTVA") = r.MontantTTC - r.BaseHT
        'End If

        ' Next
    End Sub

    Private Shared Sub AfficherRecapTVA(ByVal LstTxTVA As ListView, ByVal recapsTVA As Dictionary(Of String, RecapTVA))
        If Not LstTxTVA Is Nothing Then
            If recapsTVA.Count > 1 Then LstTxTVA.BeginUpdate()
            LstTxTVA.Items.Clear()
            For Each taux As String In recapsTVA.Keys
                For Each tx As Decimal In recapsTVA(taux).MontantsTVA.Keys
                    Dim mtBaseHT As Decimal = recapsTVA(taux).DetailBasesHT(tx)
                    Dim mtTVA As Decimal = Math.Round(recapsTVA(taux).MontantsTVA(tx), 2, MidpointRounding.AwayFromZero)
                    'Création du ListViewItem
                    With LstTxTVA.Items.Add(tx.ToString("P2"))
                        .SubItems.Add(mtBaseHT.ToString("C2"))
                        If mtTVA <> 0 Then .SubItems.Add(mtTVA.ToString("C2"))
                    End With
                Next
            Next
            If recapsTVA.Count > 1 Then LstTxTVA.EndUpdate()
        End If
    End Sub
#End Region

    Private Sub CalculMontant()
        'TODO Il faudrait là aussi virer de la réentrance
        If suppressionEnCours Then Exit Sub
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        'Me.PieceBindingSource.EndEdit()
        CalculMontant(ds, Me.CurrentDrv.Row, _NomLiaison, TypePiece, Me.LstTxTVA, Me.LbMontantHT, Me.LbMontantTVA, Me.LbMontantTTC)
    End Sub

    Private Function GetPrixTheo(ByVal PAHT As Decimal, ByVal Coef As Decimal, ByVal TxTaux As Decimal) As Decimal
        Coef = Coef / 100
        If Coef <> 0 Then
            If FrApplication.Parametres.ModeCalculCoefRestoBio = True Then
                Return PAHT * (Coef * 100) * (1 + TxTaux)
            Else
                Return (((-(PAHT * (1 + TxTaux))) / Coef) / (1 - (1 / Coef)))
            End If
        Else
            Return 0
        End If

    End Function

    Private Function GetMargePrCt(ByVal PAHT As Decimal, ByVal PVTTC As Decimal, ByVal TxTaux As Decimal) As Decimal
        If PVTTC <> 0 Then
            Return ((PVTTC - PAHT * (1 + TxTaux / 100)) / PVTTC) * 100
        Else
            Return 0
        End If
    End Function

    Private Function GetMargeEuro(ByVal PAHT As Decimal, ByVal PVTTC As Decimal, ByVal TxTaux As Decimal) As Decimal
        Return PVTTC - PAHT * (1 + TxTaux / 100)
    End Function

    Private Sub CalculHTToTTC()
        For Each drDetail As DataRowView In Me.PieceDetailBindingSource
            If Not IsDBNull(drDetail("nDetailDevis")) Then 'legrain 20/07/2016
                If IsDBNull(drDetail("PrixUHT")) Then
                    drDetail.BeginEdit()
                    drDetail.Item("PrixUTTC") = DBNull.Value
                    drDetail.Item("MontantLigneTTC") = DBNull.Value
                    drDetail.EndEdit()
                Else
                    Dim U1 As Decimal = 0
                    Dim U2 As Decimal = 0
                    Dim Remise As Decimal = 0
                    Dim TxTVA As Decimal = 0
                    Dim PrixUHT As Decimal = CDec(drDetail.Item("PrixUHT"))
                    'Déterminer le nb de décimales du prix TTC pour savoir à combien arrondir le prix HT
                    Dim nbDec As Short = 2
                    While (PrixUHT * 10 ^ nbDec) <> Decimal.Truncate(CDec((PrixUHT * 10 ^ nbDec)))
                        nbDec += 1S
                    End While

                    If Not IsDBNull(drDetail("Unite1")) Then U1 = Convert.ToDecimal(drDetail.Item("Unite1"))
                    If Not IsDBNull(drDetail("Unite2")) Then U2 = Convert.ToDecimal(drDetail.Item("Unite2"))
                    If Not IsDBNull(drDetail("Remise")) Then Remise = Convert.ToDecimal(drDetail.Item("Remise"))
                    If Not IsDBNull(drDetail("TTVA")) Then TxTVA = RecapTVA.GetTauxEffectifTVA(ds.Tables("TVA"), Convert.ToString(drDetail("TTVA"))).GetValueOrDefault
                    Dim PrixUTTC As Decimal = Math.Round(PrixUHT * (1 + TxTVA), nbDec, MidpointRounding.AwayFromZero)
                    Dim PUTTCRemise As Decimal = PrixUTTC * (1 - Remise / 100)
                    Dim PUHTRemise As Decimal = PrixUHT * (1 - Remise / 100) 'legrain 20/07/2016

                    drDetail.BeginEdit()
                    drDetail.Item("PrixUTTC") = PrixUTTC
                    drDetail.Item("MontantLigneHT") = Math.Round((U1 * PUHTRemise), nbDec, MidpointRounding.AwayFromZero) 'legrain 20/07/2016
                    Dim drProduit As DataRow = GetProduitRow(drDetail)
                    If drProduit IsNot Nothing AndAlso ds.Tables("Produit").Columns.Contains("TypeFacturation") Then
                        Select Case Convert.ToString(drProduit("TypeFacturation"))
                            Case "U1xU2"
                                drDetail.Item("MontantLigneTTC") = (U1 * U2 * PUTTCRemise)
                            Case "U2"
                                drDetail.Item("MontantLigneTTC") = (U2 * PUTTCRemise)
                            Case Else
                                drDetail.Item("MontantLigneTTC") = (U1 * PUTTCRemise)
                        End Select
                    Else
                        drDetail.Item("MontantLigneTTC") = (U1 * PUTTCRemise)
                    End If
                    drDetail.EndEdit()
                End If
            End If
        Next
    End Sub

    Private Sub CalculTTCToHT()
        For Each drDetail As DataRowView In Me.PieceDetailBindingSource
            If Not IsDBNull(drDetail("nDetailDevis")) Then 'legrain 20/07/2016
                If IsDBNull(drDetail("PrixUTTC")) Then
                    drDetail.BeginEdit()
                    drDetail.Item("PrixUHT") = DBNull.Value
                    drDetail.Item("MontantLigneHT") = DBNull.Value
                    drDetail.EndEdit()
                Else
                    Dim U1 As Decimal = 0
                    Dim U2 As Decimal = 0
                    Dim Remise As Decimal = 0
                    Dim TxTVA As Decimal = 0
                    Dim PrixUTTC As Decimal = CDec(drDetail.Item("PrixUTTC"))
                    'Déterminer le nb de décimales du prix TTC pour savoir à combien arrondir le prix HT
                    Dim nbDec As Short = 2
                    While (PrixUTTC * 10 ^ nbDec) <> Decimal.Truncate(CDec((PrixUTTC * 10 ^ nbDec)))
                        nbDec += 1S
                    End While

                    If Not IsDBNull(drDetail("Unite1")) Then U1 = Convert.ToDecimal(drDetail.Item("Unite1"))
                    If Not IsDBNull(drDetail("Unite2")) Then U2 = Convert.ToDecimal(drDetail.Item("Unite2"))
                    If Not IsDBNull(drDetail("Remise")) Then Remise = Convert.ToDecimal(drDetail.Item("Remise"))
                    If Not IsDBNull(drDetail("TTVA")) Then TxTVA = RecapTVA.GetTauxEffectifTVA(ds.Tables("TVA"), Convert.ToString(drDetail("TTVA"))).GetValueOrDefault
                    Dim PrixUHT As Decimal = Math.Round(PrixUTTC / (1 + TxTVA), nbDec, MidpointRounding.AwayFromZero)
                    Dim PUHTRemise As Decimal = PrixUHT * (1 - Remise / 100)

                    drDetail.BeginEdit()
                    drDetail.Item("PrixUHT") = PrixUHT
                    Dim drProduit As DataRow = GetProduitRow(drDetail)
                    If drProduit IsNot Nothing AndAlso ds.Tables("Produit").Columns.Contains("TypeFacturation") Then
                        Select Case Convert.ToString(drProduit("TypeFacturation"))
                            Case "U1xU2"
                                drDetail.Item("MontantLigneHT") = (U1 * U2 * PUHTRemise)
                            Case "U2"
                                drDetail.Item("MontantLigneHT") = (U2 * PUHTRemise)
                            Case Else
                                drDetail.Item("MontantLigneHT") = (U1 * PUHTRemise)
                        End Select
                    Else
                        drDetail.Item("MontantLigneHT") = (U1 * PUHTRemise)
                    End If
                    drDetail.EndEdit()
                End If
            End If
        Next
    End Sub

    Private Function GetProduitRow() As DataRow
        Return GetProduitRow(dgvPieceDetail.CurrentRow)
    End Function

    Private Function GetProduitRow(ByVal r As DataGridViewRow) As DataRow
        Return GetProduitRow(Convert.ToString(r.Cells(CodeProduitDataGridViewTextBoxColumn.Index).Value))
    End Function

    Private Function GetProduitRow(ByVal drv As DataRowView) As DataRow
        Return GetProduitRow(drv.Row)
    End Function

    Private Function GetProduitRow(ByVal dr As DataRow) As DataRow
        If dr.Table.Columns.Contains("CodeProduit") Then
            Return GetProduitRow(Convert.ToString(dr("CodeProduit")))
        End If
        Return Nothing
    End Function

    Private Function GetProduitRow(ByVal codeProduit As String) As DataRow
        If codeProduit.Trim.Length = 0 Then Return Nothing
        Return SelectSingleRow(Me.ds.Tables("Produit"), FormatExpression("CodeProduit={0}", codeProduit), "")
    End Function
#End Region

#Region " Gestion marge "
    Private Sub CalculPrixVenteTTCTheo(ByVal row As DataGridViewRow, ByVal colchanged As String)
        If Me.PieceDetailBindingSource.Position < 0 Then Exit Sub
        If Me.PieceBindingSource.Position < 0 Then Exit Sub
        If Pieces.GetAV(Me.TypePiece) = "A" AndAlso FrApplication.Modules.ModuleGestionMarge Then
            Dim Ok As Boolean = False
            Dim txTva As Decimal = RecapTVA.GetTauxEffectifTVA(ds.Tables("TVA"), Convert.ToString(row.Cells(TTVADataGridViewTextBoxColumn.Index).Value)).GetValueOrDefault
            Dim PrixA As Decimal = CDec(ReplaceDbNull(row.Cells(PrixUAchatHT.Index).Value, 0D))
            Dim CoefMarge As Decimal = CDec(ReplaceDbNull(row.Cells(colchanged).Value, 0D)) / 100

            '* Calcul Prix V TTC Pour Formule Calcul Marge PrixVHT-PrixAHT/PrixVTTC
            'Me.LbMontantTTCVenteTheo.Text = (-((-PrixA - (PrixA * txTva / 100)) / (1 - CoefMarge - (CoefMarge * txTva / 100)))).ToString("# ##0.00")

            '* Calcul Prix V TTC Pour Formule Calcul Marge PrixVTTC-PrixATTC/PrixVTTC
            If CoefMarge <> 0 Then
                'Me.LbMontantTTCVenteTheo.Text = (((-(PrixA * (1 + txTva / 100))) / CoefMarge) / (1 - (1 / CoefMarge))).ToString("# ##0.00")
                row.Cells("MontantTTCVenteTheo").Value = GetPrixTheo(PrixA, CoefMarge * 100, txTva).ToString("C2")
            Else
                row.Cells("MontantTTCVenteTheo").Value = ""
            End If

            Dim rwP As DataRow = GetProduitRow(row)
            If rwP IsNot Nothing Then rwP("CoefAV") = CoefMarge
        End If
    End Sub

    'Private Sub LbPrixAHT1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If FrApplication.Modules.ModuleGestionMarge Then
    '        Dim PA As Decimal = DecimalParse(Me.LbPrixAHT1.Text).GetValueOrDefault
    '        Dim Coef As Decimal = DecimalParse(Me.LbCoefAV1.Text).GetValueOrDefault
    '        Dim PV As Decimal = DecimalParse(Me.LbPVBalance1.Text).GetValueOrDefault
    '        Dim TxTaux As Decimal = GetTxTaux(Me.TxTVA.Text)
    '        If PA <> 0 OrElse Coef <> 0 OrElse PV <> 0 Then
    '            Me.LbPVTheo1.Text = Me.GetPrixTheo(PA, Coef, TxTaux).ToString("N2")
    '            Me.LbMargePrCt1.Text = Me.GetMargePrCt(PA, PV, TxTaux).ToString("N2")
    '            Me.LbMargeEuro1.Text = Me.GetMargeEuro(PA, PV, TxTaux).ToString("N2")
    '        Else
    '            Me.LbPVTheo1.Text = ""
    '            Me.LbMargePrCt1.Text = ""
    '            Me.LbMargeEuro1.Text = ""
    '        End If
    '    End If
    'End Sub
#End Region

#Region " Sélection de produit "
    Private Sub VerifChampsTableTarif()
        With ds.Tables("Tarif_Detail").Columns
            If Not .Contains("Libelle") Then .Add("Libelle", GetType(String), "Parent(ProduitTarif_Detail).Libelle")
            If Not .Contains("Inactif") Then .Add("Inactif", GetType(Boolean), "Parent(ProduitTarif_Detail).Inactif")
            'If Not .Contains("Famille1") Then .Add("Famille1", GetType(Integer), "Parent(ProduitTarif_Detail).Famille1")
            If Not .Contains("ProduitAchat") Then .Add("ProduitAchat", GetType(Boolean), "Parent(ProduitTarif_Detail).ProduitAchat")
            If Not .Contains("ProduitVente") Then .Add("ProduitVente", GetType(Boolean), "Parent(ProduitTarif_Detail).ProduitVente")
            If ds.Tables("Produit").Columns.Contains("IsEnVente") AndAlso Not .Contains("IsEnVente") Then .Add("IsEnVente", GetType(Boolean), "Parent(ProduitTarif_Detail).IsEnVente")
            If ds.Tables("Produit").Columns.Contains("FournisseurName") AndAlso Not .Contains("FournisseurName") Then .Add("FournisseurName", GetType(String), "Parent(ProduitTarif_Detail).FournisseurName")
            If ds.Tables("Produit").Columns.Contains("Colisage") AndAlso Not .Contains("Colisage") Then .Add("Colisage", GetType(String), "Parent(ProduitTarif_Detail).Colisage")
        End With
    End Sub

    Private Sub ShowSelectionProduit(ByVal cell As DataGridViewCell)
        If _stop Then Exit Sub
        _stop = True
        Dim r As Rectangle = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
        Dim pt As Point = cell.DataGridView.PointToScreen(r.Location)
        pt.Offset(0, r.Height)

        'Création du Dataview source
        Dim dvs As DataView
        Dim filtres As New List(Of String)
        If Pieces.GetAV(TypePiece) <> "A" Then
            If ds.Tables(_NomTable).Columns.Contains("nTarif") Then
                Dim nTarif As String = Convert.ToString(Me.CurrentDrv("nTarif"))
                If nTarif.Length > 0 AndAlso nTarif <> "0" Then
                    'Utilisation de la table TARIF pour l'affichage des prix
                    VerifChampsTableTarif()
                    dvs = New DataView(ds.Tables("Tarif_Detail"))
                    filtres.Add("nTarif=" & nTarif)
                End If
            End If
        End If
        If dvs Is Nothing Then dvs = New DataView(ds.Tables("Produit"))

        'Filtrage par IsEnVente
        If dvs.Table.Columns.Contains("IsEnVente") Then filtres.Add("IsEnVente=True")

        Dim filtreBase As String = String.Join(" AND ", filtres.ToArray)
        'Filtrage par code produit
        Dim code As String = Convert.ToString(cell.OwningRow.Cells(Me.CodeProduitDataGridViewTextBoxColumn.Index).Value)
        If code.Length > 0 Then
            filtres.Add(FormatExpression("(CodeProduit like {0} OR Libelle like {0})", code & "*"))
        End If

        If filtres.Count > 0 Then dvs.RowFilter = String.Join(" AND ", filtres.ToArray)
        dvs.Sort = "Libelle"

        Dim frSelectionProduit As New FrSelection(cell, 0)

        With frSelectionProduit
            AddHandler .Closed, AddressOf frSelectionProduit_Closed
            .StartPosition = FormStartPosition.Manual
            .Height = 400
            If pt.Y + .Height > My.Computer.Screen.Bounds.Height Then
                pt.Offset(0, -(r.Height + .Height))
            End If
            .FiltreBase = filtreBase
            .Location = pt

            'legrain 12/03/2014
            'prendre toute la largeur restante
            .Width = My.Computer.Screen.Bounds.Width - pt.X

            'legrain 12/03/2014, modification des tailles, taille du "popup" moins tous les colones "fixes" (64 x 4) à partager entre Code et libellé
            '.AddColumn("Code", "CodeProduit", 60, DataGridViewContentAlignment.MiddleCenter)
            '.AddColumn("Produit", "Libelle", 150, , , DataGridViewAutoSizeColumnMode.Fill)
            .AddColumn("Code", "CodeProduit", CInt((.Width - 65 - 65 - 65 - 65) / 3), DataGridViewContentAlignment.MiddleCenter, , DataGridViewAutoSizeColumnMode.None)
            .AddColumn("Produit", "Libelle", CInt((.Width - 65 - 65 - 65 - 65) / 3) * 2, , , DataGridViewAutoSizeColumnMode.None)
            .AddColumn("P. " & Pieces.GetAV(TypePiece) & " U HT", "Prix" & Pieces.GetAV(TypePiece) & "HT", 65, DataGridViewContentAlignment.MiddleCenter, "C2")
            If Pieces.GetAV(TypePiece) = "A" Then
                .AddColumn("P. U TTC V", "PrixVTTC", 65, DataGridViewContentAlignment.MiddleCenter, "C2")
                If ds.Tables("Produit").Columns.Contains("nFournisseur") Then
                    With ds.Tables("Produit").Columns
                        If Not .Contains("FournisseurName") Then .Add("FournisseurName", GetType(String), "Parent(FournisseurProduit).Nom")
                    End With
                    .AddColumn("Four.", "FournisseurName", 65)
                End If
            Else
                .AddColumn("P. U TTC", "PrixVTTC", 65, DataGridViewContentAlignment.MiddleCenter, "C2")
            End If
            If ds.Tables("Produit").Columns.Contains("Colisage") Then .AddColumn("Col.", "Colisage", 65)

            .DataSource = dvs

            .Owner = Me
            .Show()

            With .Liste
                .ClearSelection()
                For Each ro As DataGridViewRow In .Rows
                    If ro.DataBoundItem IsNot Nothing Then
                        If ro.Cells("Libelle").Value.ToString.ToUpper.StartsWith(Convert.ToString(cell.Value).ToUpper) Then
                            ro.Selected = True
                            Exit For
                        End If
                    End If
                Next
            End With
        End With
        'legrain 12/03/2014
        frSelectionProduit.TxRech.Focus()
    End Sub

    Private Sub frSelectionProduit_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dgvPieceDetail.CurrentCell = Me.dgvPieceDetail.CurrentRow.Cells(Me.CodeProduitDataGridViewTextBoxColumn.Index)
        _stop = False

        Me.PieceDetailBindingSource.EndEdit()
    End Sub
#End Region

#Region " Sélection lot "
    Private Sub ShowSelectionLot(ByVal cell As DataGridViewCell)
        If _stop Then Exit Sub
        Dim codeProduit As String = Convert.ToString(cell.OwningRow.Cells(CodeProduitDataGridViewTextBoxColumn.Index).Value)
        If codeProduit = "" Then Exit Sub

        _stop = True

        'MODIF TV 31/01/2012 --> MODIF SUPPRIMEE LE 05/10/2012 car ne marche pas chez Micouleau
        'Dim stocksDS As New StocksDataSet
        'Dim depot As String = "Centrale"
        'Dim dateDeb As DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
        'Dim dateFin As DateTime = New DateTime(9998, 12, 31, 0, 0, 0)

        'If Not (Me.CurrentDrv("Depot") Is Nothing) Then
        '    If Not (IsDBNull(Me.CurrentDrv("Depot"))) Then
        '        depot = CStr(Me.CurrentDrv("Depot"))
        '    End If
        'End If

        'stocksDS.EtatStock.SeuilStockColumn.AllowDBNull = True

        'Using EtatStockTA As New StocksDataSetTableAdapters.EtatStockTA
        '    EtatStockTA.FillEtatStockParCodeProduit(stocksDS.EtatStock, dateDeb, dateFin, depot, True, codeProduit)
        'End Using

        'Dim dvS As DataView = New DataView(stocksDS.EtatStock)
        'FIN MODIF TV 30/01/2012

        Dim dt As StocksDataSet.LotDataTable

        Using dta As New StocksDataSetTableAdapters.LotTA
            'Seuls les lots non terminés pour ce produit sont valides
            dt = dta.GetDataLotsNonTerminesByProduit(codeProduit)

            'MODIF TV 30/01/2012 --> MODIF SUPPRIMEE LE 05/10/2012 car ne marche pas chez Micouleau
            'dt = dta.GetDataLotsNonTerminesByCodeProduit(codeProduit)
            '--------------------------------------
        End Using

        Dim dvS As DataView = New DataView(dt)


        Dim frSelectionLot As New FrSelection(cell, 0)
        With frSelectionLot
            AddHandler .Closed, AddressOf frSelectionLot_Closed
            .Width = 300
            .Height = 400
            .StartPosition = FormStartPosition.Manual
            Dim r As Rectangle = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
            Dim pt As Point = cell.DataGridView.PointToScreen(r.Location)

            pt.Offset(0, r.Height)


            If pt.Y + .Height > My.Computer.Screen.Bounds.Height Then
                pt.Offset(0, -(r.Height + .Height))
            End If
            .Location = pt
            .AddColumn("Lot n°", "NLot", 60, DataGridViewContentAlignment.MiddleLeft, , DataGridViewAutoSizeColumnMode.Fill)
            '.AddColumn("Date", "DateCreation", 60, DataGridViewContentAlignment.MiddleLeft, "d")

            'MODIF TV 05/10/2012
            '.AddColumn("Stock", "StockActuel", 60, DataGridViewContentAlignment.MiddleLeft, "F0")
            'FIN MODIF TV 05/10/2012

            .DataSource = dvS
            .Owner = Me
            .Show()
        End With
    End Sub

    Private Sub frSelectionLot_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dgvPieceDetail.CurrentCell = Me.dgvPieceDetail.CurrentRow.Cells(Me.NLotDataGridViewTextBoxColumn.Index)
        _stop = False
    End Sub
#End Region

#Region " Actions lignes de facture "
    Private Sub ActionChangementCodeProduit(ByVal row As DataGridViewRow)
        skip = True
        Dim nTarif As New Nullable(Of Integer)
        If Me.ds.Tables(_NomTable).Columns.Contains("nTarif") Then
            nTarif = Nullabilify(Of Integer)(Me.CurrentDrv("nTarif"))
        End If
        Dim drProduit As DataRow = GetProduitRow(row)
        Dim drClient As DataRow = SelectSingleRow(Me.ds.Tables("Entreprise"), FormatExpression("nEntreprise={0}", Me.CurrentDrv("nClient")), "")
        If drProduit IsNot Nothing Then
            'Remplir les infos produit et rendre les cellules ReadOnly
            With row
                Dim libelle As String = Convert.ToString(drProduit("Libelle"))
                If Convert.ToString(drProduit("LibelleLong")) <> "" Then
                    libelle &= vbCrLf & Convert.ToString(drProduit("LibelleLong"))
                End If
                .Cells(LibelleDataGridViewTextBoxColumn.Index).Value = libelle
                .Cells(LibUnite1DataGridViewTextBoxColumn.Index).Value = Convert.ToString(drProduit("Unite1"))
                .Cells(LibUnite2DataGridViewTextBoxColumn.Index).Value = Convert.ToString(drProduit("Unite2"))
                Dim prix As Nullable(Of Decimal) = GetPrixProduit(drProduit, nTarif)
                If prix.HasValue Then
                    .Cells(PrixUDataGridViewTextBoxColumn.Index).Value = prix
                End If
                .Cells(RemiseDataGridViewTextBoxColumn.Index).Value = Me.CurrentDrv("Remise")
                'La TVA peut aussi venir du client (export,...)
                If drClient IsNot Nothing AndAlso Not drClient.IsNull("TTVA") Then
                    .Cells(TTVADataGridViewTextBoxColumn.Index).Value = drClient("TTVA")
                Else
                    .Cells(TTVADataGridViewTextBoxColumn.Index).Value = drProduit("TTVA")
                End If
                'Infos compta
                If FrApplication.Modules.ModuleCompta Then
                    If Pieces.GetAV(TypePiece) = "A" Then
                        .Cells(NCompte.Index).Value = drProduit("NCompteA")
                        .Cells(NActivite.Index).Value = drProduit("NActiviteA")
                    ElseIf drClient IsNot Nothing _
                        AndAlso ds.Tables("Entreprise").Columns.Contains("IsExport") _
                        AndAlso Not drClient.IsNull("IsExport") _
                        AndAlso CBool(drClient("IsExport")) Then
                        .Cells(NCompte.Index).Value = IIf(drProduit.IsNull("NCompteX"), drProduit("NCompteV"), drProduit("NCompteX"))
                        .Cells(NActivite.Index).Value = IIf(drProduit.IsNull("NActiviteX"), drProduit("NActiviteV"), drProduit("NActiviteX"))
                    Else
                        .Cells(NCompte.Index).Value = drProduit("NCompteV")
                        .Cells(NActivite.Index).Value = drProduit("NActiviteV")
                    End If
                End If
                'Initialisation des quantités
                Dim u1 As Object = .Cells(Unite1DataGridViewTextBoxColumn.Index).Value
                If u1 Is Nothing OrElse IsDBNull(u1) Then
                    .Cells(Unite1DataGridViewTextBoxColumn.Index).Value = 1D
                End If
            End With
            'Recalculer le montant de la ligne
            ActionChangementLigneMontant(row, "Unite1")
            'If Not rwProduit.IsNull("CoefAV") Then
            '    Me.TxCoef.Text = CStr(rwProduit.Item("CoefAV"))
            'End If
        End If
        skip = False
    End Sub

    Private Function GetPrixProduit(ByVal drProduit As DataRow, ByVal nTarif As Nullable(Of Integer)) As Nullable(Of Decimal)
        Dim ColPrix As String = String.Format("Prix{0}{1}", Pieces.GetAV(Me.TypePiece), IIf(Me.FacturationTTC, "TTC", "HT"))
        If Not nTarif.HasValue Then
            Return Nullabilify(Of Decimal)(drProduit(ColPrix))
        Else
            Dim drTarifD As DataRow = SelectSingleRow(ds.Tables("Tarif_Detail"), FormatExpression("nTarif={0} AND CodeProduit={1}", nTarif.Value, drProduit("CodeProduit")), "")
            If drTarifD Is Nothing OrElse drTarifD.IsNull(ColPrix) Then
                Return Nullabilify(Of Decimal)(drProduit(ColPrix))
            Else
                Return Nullabilify(Of Decimal)(drTarifD(ColPrix))
            End If
        End If
    End Function

    Private Sub ActionChangementLigneMontant(ByVal row As DataGridViewRow, ByVal colChanged As String)
        Dim typeFacturation As String = "U1"
        Dim coefU2 As New Nullable(Of Decimal)
        Dim drProduit As DataRow = GetProduitRow(row)
        If drProduit IsNot Nothing Then
            typeFacturation = CStr(ReplaceDbNull(drProduit("TypeFacturation"), "U1"))
            coefU2 = Nullabilify(Of Decimal)(drProduit("CoefU2"))
        End If

        'Recalculer le montant de la ligne
        Dim u1 As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(Unite1DataGridViewTextBoxColumn.Index).Value)
        'Gestion des unités liées
        If colChanged = "Unite1" AndAlso coefU2.HasValue Then
            row.Cells(Unite2DataGridViewTextBoxColumn.Index).Value = DBNullify(NullableMult(u1, coefU2))
        End If
        Dim u2 As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(Unite2DataGridViewTextBoxColumn.Index).Value)
        Dim prixU As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(PrixUDataGridViewTextBoxColumn.Index).Value)
        Dim remise As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(RemiseDataGridViewTextBoxColumn.Index).Value)

        'Calcul du montant de la ligne
        Dim montant As Nullable(Of Decimal)
        Select Case typeFacturation
            Case "U2" : montant = NullableMult(u2, prixU)
            Case "U1xU2" : montant = NullableMult(u1, u2, prixU)
            Case Else : montant = NullableMult(u1, prixU)
        End Select
        'TODO A AJOUTER POUR LES MARGES : 
        'If Pieces.GetAV(TypePiece) = "A" And FrApplication.Modules.ModuleGestionMarge Then
        '    Me.LbMontantTTCVente.Text = ((u1 * u2 * PrixUVente)).ToString
        'End If

        'Application de la remise
        If remise.HasValue Then
            montant = NullableMult(montant, 1 - remise.Value / 100)
        End If

        montant = NullableArrondi(montant, 2)

        'Affectation du montant
        row.Cells(MontantLigneDataGridViewTextBoxColumn.Index).Value = DBNullify(montant)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub OpenListOfPieces()
        If (Me._FromListOfPieces) Then
            Dim fr As FrListePieces2

            If (Me._FromListOfPiecesEntreprise) Then
                fr = New FrListePieces2(Me.TypePiece, Me._ListOfPiecesFilter, True)

                fr.nClient = Me._nclient
            Else
                fr = New FrListePieces2(Me.TypePiece, Me._ListOfPiecesFilter, Nothing, CDec(Me.id))

                fr.nClient = -1
            End If

            If Me.MdiParent IsNot Nothing Then
                fr.MdiParent = Me.MdiParent
                fr.WindowState = Me.WindowState
            End If

            fr.Show()
        End If
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.PieceBindingSource.EndEdit()

    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.PieceBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbDelete.Enabled = rowExists
        Me.TbImprimer.Enabled = rowExists
        Me.TbRegler.Enabled = rowExists AndAlso (IsDBNull(Me.CurrentDrv("Paye")) OrElse Not CBool(Me.CurrentDrv("Paye")))
    End Sub

    Private Sub ConfigInterface()
        Me.Text = String.Format("{0} - {1}", Pieces.GetLibelle(Me.TypePiece), Pieces.GetLibelleType(Me.TypePiece))
        Me.LbMarge.Text = ""

        Select Case Me._NomTable
            Case "VDevis"
                Me.GradientCaption1.Text = "Devis"
            Case "VBonCommande"
                Me.GradientCaption1.Text = "Bon de commande"
            Case "VBonLivraison"
                Me.GradientCaption1.Text = "Bon de livraison"
            Case "VFacture"
                Me.GradientCaption1.Text = "Facture"
            Case Else
                Me.GradientCaption1.Text = ""
        End Select

        'Visibilité des boutons
        Me.ImpressionRelanceToolStripMenuItem.Visible = (Me.TypePiece = Pieces.TypePieces.VFacture)
        If Me.TypePiece = Pieces.TypePieces.VFacture OrElse Me.TypePiece = Pieces.TypePieces.AFacture Then
            Me.GbEcheance.Visible = FrApplication.Modules.ModuleReglement OrElse (Me.TypePiece = Pieces.TypePieces.AFacture)
            Me.TbAfficheReglement.Visible = FrApplication.Modules.ModuleReglement
            Me.TbRegler.Visible = FrApplication.Modules.ModuleReglement
            Me.CréanceIrrécouvrableToolStripMenuItem.Visible = FrApplication.Modules.ModuleReglement AndAlso (Me.TypePiece = Pieces.TypePieces.VFacture)
        Else
            Me.GbEcheance.Visible = True
            Me.TbAfficheReglement.Visible = False
            Me.TbRegler.Visible = False
            Me.CréanceIrrécouvrableToolStripMenuItem.Visible = False
        End If

        'MODIF TV 26/01/2012
        'Me.PrixUDataGridViewTextBoxColumn.HeaderText = "P. " & Pieces.GetAV(Me.TypePiece) & " U HT"
        '------------------------------

        If Pieces.GetAV(Me.TypePiece) = "A" AndAlso FrApplication.Modules.ModuleGestionMarge Then
            'TODO Remettre module marge

            'Me.gcFacturation.NuméroNiveau1 = 0
            'Me.LbMarge.Visible = False

            'With Me.LbPrixAUHT
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixUHT"
            '    .Text = ""
            '    .BackColor = ColorL1
            'End With

            'With Me.TxPrixUTTCVente
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixUTTCVente"
            '    .Text = "0"
            '    .BackColor = ColorL1
            'End With

            'With Me.TxCoef
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "CoefAV"
            '    .Text = "0"
            '    .BackColor = ColorL1
            'End With

            'With Me.LbMontantTTCVente
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "MontantLigneTTCVente"
            '    .Text = "0"
            '    .BackColor = ColorL1
            'End With

            'With Me.LbMontantTTCVenteTheo
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixUTTCVenteTheo"
            '    .Text = ""
            '    .BackColor = ColorL1
            'End With

            'With Me.LbMargePrCt
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "MargePrCt"
            '    .Text = ""
            '    .BackColor = ColorL1
            'End With

            'With Me.LbMontantMarge
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "MargeEuro"
            '    .Text = ""
            '    .BackColor = ColorL1
            'End With

            'With Me.LbPrixAHT1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixAHT1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.LbCoefAV1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "CoefAV1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.LbPVTheo1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixVTTCTheo1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.LbPVBalance1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "PrixVTTC1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.LbMargePrCt1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "MargePrCt1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.LbMargeEuro1
            '    .Visible = True
            '    .DessinControl = True
            '    .ChampsLie = "MargeEuro1"
            '    .Text = ""
            '    .BackColor = ColorL2
            'End With

            'With Me.TxMontantHT
            '    .DernierCtrlLigne = False
            '    .MoveNextAuto = True
            'End With
        ElseIf Pieces.GetAV(Me.TypePiece) = "A" AndAlso FrApplication.Modules.ModuleApproFact Then
            'Afficher le champ pour le prix SRAP (PVTTC)
            With Me.PrixUDataGridViewTextBoxColumn
                .ToolTipText = "Prix U. HT négocié"
            End With

            With Me.PrixUTTC
                .Visible = True
                .HeaderText = "PU HT SRAP"
                .DataPropertyName = "PrixUTTCVente"
                .ToolTipText = "Seuil de revente à perte"
            End With
        Else
            Me.gcFacturation.NuméroNiveau1 = 0
            Me.LbMarge.Visible = False
        End If
    End Sub

    Private Sub AutoriseModif(ByVal autorise As Boolean)
        Me.GpFacturation.Enabled = autorise
        Me.GbEcheance.Enabled = autorise
        Me.gcEcheance.AutoriseModif = autorise
        Me.gcFacturation.AutoriseModif = autorise
        If Me.PieceDetailBindingSource.DataSource IsNot Nothing Then
            With CType(Me.PieceDetailBindingSource.List, DataView)
                .AllowNew = autorise
                .AllowEdit = autorise
                .AllowDelete = autorise
            End With
        End If
        Me.SupprimerToolStripMenuItem.Enabled = autorise
        Me.DupliquerToolStripMenuItem.Enabled = autorise
        'Grille
        Me.dgvPieceDetail.ReadOnly = Not autorise
        'Pour contrer un bug, on remets ca en place :
        Me.LibUnite1DataGridViewTextBoxColumn.ReadOnly = True
        Me.LibUnite2DataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantLigneDataGridViewTextBoxColumn.ReadOnly = True
    End Sub

    Private Function EstFacturePayee(ByVal nDevis As Decimal) As Boolean
        Using pieceTA As New DsPiecesTableAdapters.PiecesTA
            Dim pieceDT As DsPieces.PiecesDataTable = pieceTA.GetVFactureDataBynDevis(nDevis)

            For Each pieceDR As DsPieces.PiecesRow In pieceDT.Rows
                Return pieceDR.Paye
            Next
        End Using

        Return False
    End Function

    Private Sub GererEcheance()
        'Si on est en création, on va chercher l'échéance par défaut définie dans les paramètres
        If (Me.id Is Nothing) Or (CInt(Me.id) = -1) Then
            'Recherche de la valeur du paramètre "NbJoursEcheance"
            Dim ds As New DataSet
            Dim nbJEch As Decimal = 0

            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
            End Using

            If Not (String.IsNullOrEmpty(ParametresBase.GetValeur(ds, "NbJoursEcheance", Nothing, ""))) Then
                nbJEch = CDec((ParametresBase.GetValeur(ds, "NbJoursEcheance", Nothing, "0")))
            End If

            'Recherche de la valeur du paramètre "FdMEcheance"
            Dim FdMEch As Boolean = False

            FdMEch = CBool((ParametresBase.GetValeur(ds, "FdMEcheance", Nothing, "False")))

            'Affectation de la valeur par défaut
            Dim rwv As DataRowView = Me.CurrentDrv
            Dim dateEch As Date = CDate(rwv.Item("DateFacture")).AddDays(nbJEch)

            If (FdMEch) Then
                dateEch = New Date(dateEch.Year, dateEch.Month, Date.DaysInMonth(dateEch.Year, dateEch.Month))
            End If

            rwv.Item("DateEcheance") = dateEch
        End If
    End Sub

    Private Function EntrepriseEnLitige(ByVal EntrepriseDR As DataRow) As Boolean
        If (Me.ds.Tables("Entreprise").Columns.Contains("LitigeEnCours")) Then
            If Not (EntrepriseDR.IsNull("LitigeEnCours")) Then
                If (CBool(EntrepriseDR.Item("LitigeEnCours"))) Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Private Function EnCoursMaxDepasse(ByVal EntrepriseDR As DataRow, ByVal typePiece As Pieces.TypePieces) As Boolean
        If (Me.ds.Tables("Entreprise").Columns.Contains("EnCoursMax")) Then
            If Not (EntrepriseDR.IsNull("EnCoursMax")) Then
                'Récupération de l'en-cours maximum du tiers
                Dim enCoursMax As Decimal = CDec(EntrepriseDR.Item("EnCoursMax"))

                'Calcul du solde du client
                Dim solde As Decimal = Me.GetSoldeCompteClient(CDec(EntrepriseDR.Item("nEntreprise")))

                'Traitement spécifique si la pièce est une facture : on soustrait le montant TTC de la
                'facture enregistré en base de données
                Select Case typePiece
                    Case Pieces.TypePieces.VFacture
                        'Recherche du montant TTC de la facture actuelle en base de données
                        Dim montantTTCFacture As Decimal = Me.GetMontantTTCFacture(nDevis)

                        'On soustrait le montant TTC de la facture présent en base de données
                        'du solde
                        solde = solde - montantTTCFacture
                End Select

                'On rajoute le montant TTC de la pièce affichée à l'écran
                If Not (IsDBNull(Me.CurrentDrv.Item("MontantTTC"))) Then
                    solde = solde + CDec(Me.CurrentDrv.Item("MontantTTC"))
                End If

                If (enCoursMax > 0) Then
                    If (solde > enCoursMax) Then
                        Return True
                    End If
                End If
            End If
        End If

        Return False
    End Function

    Private Function GetSoldeCompteClient(ByVal nEntreprise As Decimal, Optional ByVal dtDeb As Date = #1/1/2000#, Optional ByVal dtFin As Date = #1/1/2100#) As Decimal
        Dim EntrepriseDS As New DsEntreprises
        Dim solde As Decimal = 0

        Using RecapCompteTA As New DsEntreprisesTableAdapters.RecapCompteTA
            RecapCompteTA.FillByNEntreprise(EntrepriseDS.RecapCompte, nEntreprise, dtDeb.Date, dtFin.Date.AddDays(1))
        End Using

        Dim obj As Object = EntrepriseDS.RecapCompte.Compute("Sum(Montant)", "")

        If Not (IsDBNull(obj)) Then
            solde = CDec(obj)
        End If

        Return solde
    End Function

    Private Function GetMontantTTCFacture(ByVal nDevis As Decimal) As Decimal
        Dim montantTTC As Decimal = 0

        Using PiecesTA As New DsPiecesTableAdapters.PiecesTA
            Dim PiecesDT As DsPieces.PiecesDataTable = PiecesTA.GetVFactureDataBynDevis(nDevis)

            If (PiecesDT.Rows.Count > 0) Then
                Dim PiecesDR As DsPieces.PiecesRow = CType(PiecesDT.Rows(0), AgriFact.DsPieces.PiecesRow)

                If Not (PiecesDR.IsMontantTTCNull) Then
                    montantTTC = PiecesDR.MontantTTC
                End If
            End If

            Return montantTTC
        End Using
    End Function

    Private Sub MoveToPiece(ByVal directionDeplacement As String)
        If Me.id IsNot Nothing AndAlso CInt(Me.id) >= 0 Then
            Dim nDev As Decimal = -1
            Dim sensTri As String = String.Empty
            Dim operateurComp As String = String.Empty

            Select Case directionDeplacement
                Case "SUIVANT"
                    sensTri = "ASC"
                    operateurComp = ">"
                Case "PRECEDENT"
                    sensTri = "DESC"
                    operateurComp = "<"
            End Select

            Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
                sqlConn.Open()

                Dim sqlQuery As String = String.Empty

                sqlQuery = String.Format("SELECT TOP 1 nDevis FROM {0} WHERE nDevis {1} {2} ORDER BY nDevis {3}", Me.TypePiece.ToString(), operateurComp, Me.id, sensTri)

                Using sqlComm As New SqlCommand(sqlQuery, sqlConn)
                    Dim sqlDA As New SqlDataAdapter(sqlComm)
                    Dim ds As New DataSet

                    sqlDA.Fill(ds, "Piece")

                    For Each dr As DataRow In ds.Tables("Piece").Rows
                        nDev = CDec(dr.Item("nDevis"))
                    Next
                End Using
            End Using

            If (nDev > -1) Then
                Dim fr As New FrBonCommande(CInt(nDev), Me._FromListOfPieces, Me._ListOfPiecesFilter, Me._FromListOfPiecesEntreprise, True)

                fr.TypePiece = Me.TypePiece

                If Me.MdiParent IsNot Nothing Then
                    fr.MdiParent = Me.MdiParent
                    fr.WindowState = Me.WindowState
                End If

                fr.Show()

                Me._GoTolist = False

                Me.Close()
            End If
        End If
    End Sub

    'MODIF TV 06/09/2012-----------
    Private Sub SupprimerAutoincrement()
        'Supprime l'autoincrement de la colonne nDevis
        If ds.Tables(_NomTable).Columns.Contains("nDevis") Then
            With ds.Tables(_NomTable).Columns("nDevis")
                .AutoIncrement = False
            End With
        End If

        'Supprime l'autoincrement de la colonne nDetailDevis
        If ds.Tables(_NomTableDetail).Columns.Contains("nDetailDevis") Then
            With ds.Tables(_NomTableDetail).Columns("nDetailDevis")
                .AutoIncrement = False
            End With
        End If
    End Sub
    'FIN MODIF TV 06/09/2012----------

#End Region


End Class