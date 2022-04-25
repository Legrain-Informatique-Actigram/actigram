Public Class Main

    Private _Stop As Boolean = False
    Private _nDevis As Integer = 0
    Private skip As Boolean = False
    Dim prevNClient As Integer = -1

#Region " Props "
    Public Property NDevis() As Integer
        Get
            Return _nDevis
        End Get
        Set(ByVal value As Integer)
            _nDevis = value
        End Set
    End Property

    Public ReadOnly Property CurrentEntRow() As DsAgrifact.EntrepriseRow
        Get
            If Me.EntrepriseBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
            End If
        End Get
    End Property

    Public ReadOnly Property CurrentFactRow() As DsAgrifact.VFactureRow
        Get
            If Me.VFactureBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return Cast(Of DsAgrifact.VFactureRow)(Cast(Of DataRowView)(Me.VFactureBindingSource.Current).Row)
            End If
        End Get
    End Property

    Public ReadOnly Property CurrentFactDetailRow() As DsAgrifact.VFacture_DetailRow
        Get
            If Me.VFacture_DetailBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return Cast(Of DsAgrifact.VFacture_DetailRow)(Cast(Of DataRowView)(Me.VFacture_DetailBindingSource.Current).Row)
            End If
        End Get
    End Property
#End Region

#Region "Form"
    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Not DemanderEnregistrement() Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TestPrinter()

        Cast(Of Bitmap)(BtFindClient.Image).MakeTransparent(Color.Magenta)

        Me.ImprimerFacturetteToolStripMenuItem.Visible = My.Settings.PrinterEnabled

        ApplyStyle(Me.RecapTVADataGridView)
        AddHandler Me.RecapTVADataGridView.SelectionChanged, AddressOf DeselectAll
        Me.RecapTVADataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ApplyStyle(Me.VFacture_DetailDataGridView, False)

        ConfigPercentControl(RemiseTextBox)
        ConfigZoomTextbox(AdresseFactureTextBox)
        ConfigZoomTextbox(ObservationTextBox)

        With VFacture_DetailDataGridView
            .AutocompletColsMode3.Add(CodeProduitCol)
            .AutocompletColsMode3.Add(TVACol)
            .ConfigAutocompleteCombobox()
            AddHandler .CellDoubleClick, AddressOf dg_ZoomTextBoxCells
            AddHandler .MouseDown, AddressOf dg_GestionClicDroit
        End With

        If Not SqlProxy.TestDefaultConnection Then
            FormEnabled(False)
        Else
            Me.DsAgrifact.VFacture.InitAutoIncrementSeed(Me.VFactureTA)
            Me.DsAgrifact.VFacture_Detail.InitAutoIncrementSeed(Me.VFacture_DetailTA)

            ConfigDataTableEvents(DsAgrifact.VFacture, AddressOf RowChanged)
            ConfigDataTableEvents(DsAgrifact.VFacture_Detail, AddressOf RowDetailChanged)
            ChargerDonnees()
            FormEnabled(True)
        End If
    End Sub
#End Region

#Region " Données "
    Private Sub ChargerDonnees()
        Using dta As New DsAgrifactTableAdapters.TVA_TA
            dta.Fill(Me.DsAgrifact.TVA)
        End Using
        ChargerProduits()
        ChargerClients()
        ChargerFacture()
    End Sub

    Private Sub ChargerProduits()
        Me.ProduitBindingSource.SuspendBinding()
        Me.TarifBindingSource.SuspendBinding()
        Me.DsAgrifact.EnforceConstraints = False

        'Chargement des produits : Inactif = 0 et ProduitVente = 1 et IsEnVente = 1
        Using dta As New DsAgrifactTableAdapters.ProduitTA
            dta.FillEnVente(Me.DsAgrifact.Produit)
        End Using

        'Chargement des tarifs
        Using dta As New DsAgrifactTableAdapters.TarifTA
            dta.Fill(Me.DsAgrifact.Tarif)
            Me.DsAgrifact.Tarif.AddTarifRow("", "")
            Me.DsAgrifact.Tarif.AcceptChanges()
        End Using

        'Chargement des détails des tarifs
        Using dta As New DsAgrifactTableAdapters.Tarif_DetailTA
            dta.Fill(Me.DsAgrifact.Tarif_Detail)
        End Using

        Me.DsAgrifact.EnforceConstraints = True
        Me.ProduitBindingSource.ResumeBinding()
        Me.TarifBindingSource.ResumeBinding()
    End Sub

    Private Sub ChargerClients()
        Me.EntrepriseBindingSource.SuspendBinding()
        Me.DsAgrifact.EnforceConstraints = False

        'Chargement des clients : TypeClient = PARTICULIER
        Using dta As New DsAgrifactTableAdapters.EntrepriseTA
            dta.FillByTypeClient(Me.DsAgrifact.Entreprise, DsAgrifactTableAdapters.EntrepriseTA.TypeClient.Particulier)
        End Using

        Me.DsAgrifact.EnforceConstraints = True
        Me.EntrepriseBindingSource.ResumeBinding()
    End Sub

    Private Sub ChargerFacture()
        If Me.NDevis > 0 Then
            Me.VFactureBindingSource.SuspendBinding()
            Me.DsAgrifact.EnforceConstraints = False

            'Chargement des détails de la facture
            Me.VFacture_DetailTA.FillBynDevis(Me.DsAgrifact.VFacture_Detail, Me.NDevis)

            'Chargement de la facture
            Me.VFactureTA.FillBynDevis(Me.DsAgrifact.VFacture, Me.NDevis)

            Me.DsAgrifact.EnforceConstraints = True
            Me.VFactureBindingSource.ResumeBinding()
            DeterminerSourceProduit()
        Else
            NouvelleFacture()
        End If
        MajBoutons()
    End Sub

    Private Sub NouvelleFacture()
        Me.NDevis = -1
        Me.DsAgrifact.VFacture_Detail.Clear()
        Me.DsAgrifact.VFacture.Clear()
        VFactureBindingSource.AddNew()
        If My.Settings.nClientDefaut >= 0 Then
            Me.CurrentFactRow.nClient = My.Settings.nClientDefaut
            NClientChanged()
        End If
        Me.CurrentFactRow.DateFacture = Now
        VFactureBindingSource.ResetCurrentItem()
        DeterminerSourceProduit()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        If Me.Validate() Then
            Me.VFactureBindingSource.EndEdit()
            'On ne demande pas l'enregistrement s'il n'y a pas de lignes de détail de saisie
            If Me.VFacture_DetailBindingSource.Count = 0 Then
                Me.DsAgrifact.RejectChanges()
            Else
                If Me.DsAgrifact.HasChanges Then
                    Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes
                            Enregistrer()
                        Case MsgBoxResult.No
                            If Me.NDevis < 0 Then
                                'Annuler le NFacture
                                If Not Me.CurrentFactRow.IsnFactureNull Then
                                    AnnulerNFacture(CInt(Me.CurrentFactRow.nFacture))
                                End If
                                VFactureBindingSource.CancelEdit()
                            End If
                        Case MsgBoxResult.Cancel
                            Return False
                    End Select
                End If
            End If
            Return True
        Else
            Return MsgBox("Impossible d'enregistrer les données." & vbCrLf & "Voulez-vous abandonner les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes
        End If
    End Function

    Private Sub Enregistrer()
        Cursor.Current = Cursors.WaitCursor
        Me.Validate()
        Me.VFactureBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            If Me.CurrentFactRow.IsMontantTTCNull OrElse Me.CurrentFactRow.MontantTTC = 0 Then
                MsgBox("Vous ne pouvez pas enregistrer une facture vide", MsgBoxStyle.Exclamation)
            Else
                If Me.CurrentFactRow.IsnFactureNull Then Me.CurrentFactRow.nFacture = GetNFacture()
                Dim changes As DataSet = Me.DsAgrifact.GetChanges
                If changes IsNot Nothing Then
                    If Me.NDevis > 0 Then : SqlProxy.ForceUpdate(Me.VFactureTA.PublicAdapter, changes)
                    Else : SqlProxy.ForceInsert(Me.VFactureTA.PublicAdapter, changes)
                    End If
                    Me.VFacture_DetailTA.Update(Me.DsAgrifact)
                    Me.DsAgrifact.VFacture.AcceptChanges()
                    Me.NDevis = CInt(Me.CurrentFactRow.nDevis)
                End If
            End If
        End If
        Cursor.Current = Cursors.Default
        MajBoutons()
    End Sub

    Private Sub ResetAdapters()
        Me.VFacture_DetailTA = New DsAgrifactTableAdapters.VFacture_DetailTA
        Me.VFactureTA = New DsAgrifactTableAdapters.VFactureTA
        Me.DsAgrifact.VFacture.InitAutoIncrementSeed(Me.VFactureTA)
        Me.DsAgrifact.VFacture_Detail.InitAutoIncrementSeed(Me.VFacture_DetailTA)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub FormEnabled(ByVal enabled As Boolean)
        Me.ToolStripDropDownButton1.Enabled = enabled
        MajBoutons()
        Me.BtCaisse.Enabled = enabled
        Me.BtRecaps.Enabled = enabled
        Me.GroupBox1.Enabled = enabled
        Me.GroupBox2.Enabled = enabled
        Me.GroupBox3.Enabled = enabled
        Me.VFacture_DetailDataGridView.Enabled = enabled
    End Sub

    Private Sub RecalculerLignes()
        For Each r As DataGridViewRow In Me.VFacture_DetailDataGridView.Rows
            ActionChangementLigne(r, "")
        Next
        Me.VFacture_DetailBindingSource.EndEdit()
    End Sub

    Private Sub RowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub DeselectAll(ByVal sender As Object, ByVal e As EventArgs)
        If RecapTVADataGridView.SelectedRows.Count > 0 Then
            RecapTVADataGridView.ClearSelection()
        End If
    End Sub

    Private Sub AfficherRecapTVA(ByVal recapsTVA As IEnumerable(Of RecapTVA))
        RecapTVABindingSource.DataSource = recapsTVA
    End Sub

    Private Sub SearchProduit(ByVal cell As DataGridViewCell)
        If (Me._Stop) Then Exit Sub

        Me._Stop = True

        Dim r As Rectangle = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
        Dim pt As Point = cell.DataGridView.PointToScreen(r.Location)

        pt.Offset(0, r.Height)

        'Création du Dataview source
        Dim dvs As DataView
        Dim filtres As New List(Of String)

        dvs = New DataView(Me.DsAgrifact.Produit)

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

        Dim frSearchProduit As New FrSearch(cell, 0)

        With frSearchProduit
            AddHandler .Closed, AddressOf frSearchProduit_Closed

            .StartPosition = FormStartPosition.Manual

            If pt.Y + .Height > My.Computer.Screen.Bounds.Height Then
                pt.Offset(0, -(r.Height + .Height))
            End If

            .FiltreBase = filtreBase
            .Location = pt

            .AddColumn("Code", "CodeProduit", 60, DataGridViewContentAlignment.MiddleCenter)
            .AddColumn("Produit", "Libelle", 150, , , DataGridViewAutoSizeColumnMode.Fill)
            .AddColumn("PVUHT", "PrixVHT", 65, DataGridViewContentAlignment.MiddleCenter, "C2")
            .AddColumn("PVUTTC", "PrixVTTC", 65, DataGridViewContentAlignment.MiddleCenter, "C2")

            If Me.DsAgrifact.Tables("Produit").Columns.Contains("Colisage") Then .AddColumn("Col.", "Colisage", 65)

            .DataSource = dvs

            .Owner = Me
            .Show()

            With .ListOfResults
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
    End Sub

    Private Sub frSearchProduit_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.VFacture_DetailDataGridView.CurrentCell = Me.VFacture_DetailDataGridView.CurrentRow.Cells(Me.CodeProduitDataGridViewTextBoxColumn.Index)
        Me._Stop = False
    End Sub
#End Region

#Region "NTarifComboBox"
    Private Sub NTarifComboBox_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles NTarifComboBox.Validated
        AppliquerTarif(Nullabilify(Of Integer)(Me.CurrentFactRow("nTarif")))
        DeterminerSourceProduit()
        RecalculerLignes()
    End Sub
#End Region

#Region "RemiseTextBox"
    Private Sub RemiseTextBox_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles RemiseTextBox.Validated
        AppliquerRemise(Me.CurrentFactRow("Remise"))
        RecalculerLignes()
    End Sub
#End Region

#Region " Toolbar "
    Private Sub MajBoutons()
        If Me.VFactureBindingSource.Position < 0 Then
            AnnulerLaFactureToolStripMenuItem.Enabled = False
            TbSplitImprimer.Enabled = False
            ImprimerFacturetteToolStripMenuItem.Enabled = False
            EnregistrerLaFactureToolStripMenuItem.Enabled = False
            TbRegler.Enabled = False
        Else
            AnnulerLaFactureToolStripMenuItem.Enabled = Not Me.CurrentFactRow.Paye
            TbRegler.Text = CStr(IIf(Me.CurrentFactRow.Paye, "Afficher le réglement", "Régler"))
            TbSplitImprimer.Enabled = True
            ImprimerFacturetteToolStripMenuItem.Enabled = My.Settings.PrinterEnabled
            ImprimerFacturetteToolStripMenuItem.Visible = My.Settings.PrinterEnabled
            EnregistrerLaFactureToolStripMenuItem.Enabled = Me.DsAgrifact.HasChanges
            TbRegler.Enabled = Not Cast(Of DataRowView)(Me.VFactureBindingSource.Current).IsNew
        End If
    End Sub

    Private Sub EnregistrerLaFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerLaFactureToolStripMenuItem.Click
        Enregistrer()
    End Sub

    Private Sub AnnulerLaFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerLaFactureToolStripMenuItem.Click
        If VFactureBindingSource.Current Is Nothing Then Exit Sub
        If Me.NDevis < 0 Then
            'Annuler le NFacture
            If MsgBox("Etes-vous sûr de vouloir annuler cette facture ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not Me.CurrentFactRow.IsnFactureNull Then
                    AnnulerNFacture(CInt(Me.CurrentFactRow.nFacture))
                End If
                VFactureBindingSource.CancelEdit()
                If VFactureBindingSource.Count > 0 Then
                    VFactureBindingSource.RemoveCurrent()
                End If
            End If
        Else
            Try
                'Supprimer la facture
                Dim nFacture As Integer = CInt(Me.CurrentFactRow.nFacture)
                VFactureBindingSource.RemoveCurrent()
                VFacture_DetailTA.DeleteByNDevis(Me.NDevis)
                VFactureTA.Update(Me.DsAgrifact.VFacture)
                'Annuler le NFacture
                AnnulerNFacture(nFacture)
            Catch ex As UserCancelledException
            End Try
        End If
    End Sub

    Private Sub NouvelleFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelleFactureToolStripMenuItem.Click
        If DemanderEnregistrement() Then
            NouvelleFacture()
        End If
    End Sub

    Private Sub RechercherUneFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherUneFactureToolStripMenuItem.Click
        If DemanderEnregistrement() Then
            Using fr As New FrListeFactures
                If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Me.NDevis = fr.nDevis
                    ChargerFacture()
                End If
            End Using
        End If
    End Sub

    Private Sub TbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechargerLaFactureToolStripMenuItem.Click
        If DemanderEnregistrement() Then
            ChargerDonnees()
        End If
    End Sub

    Private Sub TbParametres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbParametres.Click
        If DemanderEnregistrement() Then
            Using fr As New FrParametres
                If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If SqlProxy.TestDefaultConnection Then
                        FormEnabled(True)
                        'La chaine de connexion a pu changer
                        ResetAdapters()
                        ChargerDonnees()
                    Else
                        FormEnabled(False)
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub TbRegler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRegler.Click
        If DsAgrifact.HasChanges Then
            Enregistrer()
        End If
        'Ouvrir la fenêtre de réglement
        Using fr As New FrReglement(CInt(Me.CurrentFactRow.nDevis))
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerFacture()
                If Me.CurrentFactRow.Paye AndAlso My.Settings.PrinterEnabled _
                AndAlso MsgBox("Voulez-vous imprimer la facturette ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ImprimerTicket()
                End If
            End If
        End Using
    End Sub

    Private Sub BtCaisse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCaisse.Click
        Using fr As New FrCaisse(My.Settings.CurrentCaisse)
            fr.ShowDialog()
            My.Settings.CurrentCaisse = fr.NCaisse
        End Using
    End Sub

    Private Sub BtRecaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRecaps.Click
        Using fr As New ParamsEtat
            fr.ShowDialog()
        End Using
    End Sub

    Private Sub TbSplitImprimer_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSplitImprimer.ButtonClick
        If TbSplitImprimer.Tag.ToString = "Facturette" Then
            ImprimerFacturetteToolStripMenuItem.PerformClick()
        Else
            ImprimerToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub TbImprimerCrystal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AperçuAvantImpressionToolStripMenuItem.Click, ImprimerToolStripMenuItem.Click
        If Me.CurrentFactRow Is Nothing Then Exit Sub
        If DemanderEnregistrement() Then
            ImprimerFacture(CInt(Me.CurrentFactRow.nDevis), sender Is AperçuAvantImpressionToolStripMenuItem)
        End If
        With TbSplitImprimer
            .Image = My.Resources.impr32
            .Text = "Imprimer"
            .Tag = "Imprimer"
        End With
    End Sub

    Private Sub ImprimerLaFacturetteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerFacturetteToolStripMenuItem.Click
        ImprimerTicket()
        With TbSplitImprimer
            .Image = My.Resources.ticket
            .Text = "Facturette"
            .Tag = "Facturette"
        End With
    End Sub
#End Region

#Region " Menu "
    Private Sub DupliquerLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerLaLigneToolStripMenuItem.Click
        If Me.VFacture_DetailBindingSource.Current Is Nothing Then Exit Sub
        Dim drSource As DsAgrifact.VFacture_DetailRow = Me.CurrentFactDetailRow
        Dim drv As DataRowView = Cast(Of DataRowView)(Me.VFacture_DetailBindingSource.AddNew)
        CopyRow(drSource, drv.Row)
    End Sub

    Private Sub SupprimerLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerLaLigneToolStripMenuItem.Click
        Try
            Me.VFacture_DetailBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub
#End Region

#Region " Grid "
    Private Sub VFacture_DetailDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VFacture_DetailDataGridView.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = Cast(Of DataGridView)(sender).Rows(e.RowIndex)
        Dim colChanged As String = Cast(Of DataGridView)(sender).Columns(e.ColumnIndex).DataPropertyName
        Select Case colChanged
            Case "CodeProduit"
                ActionChangementCodeProduit(row)
            Case "Unite1", "Unite2", "PrixUTTC", "TTVA", "Remise"
                ActionChangementLigne(row, colChanged)
        End Select
    End Sub

    Private Sub VFacture_DetailDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VFacture_DetailDataGridView.CellContentClick
        If (e.RowIndex < 0) Then Exit Sub

        If (Me.VFacture_DetailDataGridView.ReadOnly) Then Exit Sub

        If (e.ColumnIndex = Me.SearchProduitDataGridViewButtonColumn.Index) Then
            Me.SearchProduit(Me.VFacture_DetailDataGridView.Rows(e.RowIndex).Cells(Me.CodeProduitDataGridViewTextBoxColumn.Index))
        End If
    End Sub
#End Region

#Region " Gestion NFacture "
    Public Shared Sub AnnulerNFacture(ByVal nFacture As Long)
        Dim table As String = "VFacture"
        Using conn As New SqlProxy(My.Settings.ConnString)
            conn.ExecuteNonQuery(SqlProxy.FormatSql("Exec RemoveLastNFacture {0},{1},{2}", table, nFacture, False))
        End Using
    End Sub

    Public Shared Sub SetNextNFacture(ByVal nFacture As Long)
        Dim table As String = "VFacture"
        Using conn As New SqlProxy(My.Settings.ConnString)
            conn.ExecuteNonQuery(SqlProxy.FormatSql("Exec SetNextNFacture {0},{1}", table, nFacture))
        End Using
    End Sub

    Public Shared Sub ReclaimNFacture()
        Dim table As String = "VFacture"
        Dim vDefaut As Long = My.Settings.nFactureDefaut

        Dim sql As String = "DECLARE @NFacture int; " & vbCrLf & _
                            "CREATE TABLE #tmp (NextNFacture int) " & vbCrLf & _
                            "INSERT INTO #tmp EXEC GetNextNFacture {0},{1},0; " & vbCrLf & _
                            "SELECT @NFacture=NextNFacture FROM #tmp " & vbCrLf & _
                            "DROP TABLE #tmp " & vbCrLf & _
                            "WHILE (NOT EXISTS (SELECT * FROM " & table & " WHERE nFacture=@nFacture))  " & vbCrLf & _
                            "   AND (@nFacture>0) BEGIN " & vbCrLf & _
                            "   SET @nFacture=@nFacture-1 " & vbCrLf & _
                            "END " & vbCrLf & _
                            "EXEC SetNextNFacture {0},@nFacture " & vbCrLf & _
                            "SELECT @nFacture as NextNFacture;"

        Using conn As New SqlProxy(My.Settings.ConnString)
            conn.ExecuteNonQuery(SqlProxy.FormatSql(sql, table, vDefaut))
        End Using
    End Sub

    Public Shared Function GetNFacture(Optional ByVal Simulation As Boolean = False) As Long
        'Déterminer la valeur par défaut
        'TODO VERIFIER QUE LE N° PRECEDENT A BIEN ETE UTILISE SINON, AVERTO
        Dim table As String = "VFacture"
        Dim vDefaut As Long = My.Settings.nFactureDefaut

        Using conn As New SqlProxy(My.Settings.ConnString)
            Dim nFacture As Long = conn.ExecuteScalarInt(SqlProxy.FormatSql("Exec GetNextNFacture {0},{1},{2}", table, vDefaut, Simulation))
            If nFacture = 0 Then nFacture = 1
            Return nFacture
        End Using
    End Function
#End Region

#Region " Fonctionnel "
    Private Sub ActionChangementCodeProduit(ByVal row As DataGridViewRow)
        Dim codeProduit As String = Convert.ToString(row.Cells(CodeProduitCol.Index).Value)
        Dim drProduit As DsAgrifact.ProduitRow = SelectSingleRow(Of DsAgrifact.ProduitRow)(Me.DsAgrifact.Produit, FormatExpression("CodeProduit={0}", codeProduit), "")
        If drProduit IsNot Nothing Then
            'Remplir les infos produit et rendre les cellules ReadOnly
            If Not drProduit.IsLibelleNull Then row.Cells(LibelleCol.Index).Value = drProduit.Libelle
            With row
                .Cells(LibU1Col.Index).Value = Convert.ToString(drProduit("Unite1"))
                .Cells(U1Col.Index).ReadOnly = drProduit.IsUnite1Null
                .Cells(LibU2Col.Index).Value = Convert.ToString(drProduit("Unite2"))
                .Cells(U2Col.Index).ReadOnly = drProduit.IsUnite2Null
                .Cells(PrixUTTCCol.Index).Value = GetPrixProduit(drProduit, Nullabilify(Of Integer)(Me.CurrentFactRow("nTarif")))
                .Cells(TVACol.Index).Value = drProduit("TTVA")
                .Cells(RemiseCol.Index).Value = Me.CurrentFactRow("Remise")
            End With
            If row.DataBoundItem IsNot Nothing Then
                Dim drv As DataRowView = Cast(Of DataRowView)(row.DataBoundItem)
                drv("NCompte") = drProduit("NCompteV")
                drv("NActivite") = drProduit("NActiviteV")
            End If
        End If
    End Sub

    Private Function GetPrixProduit(ByVal drProduit As DsAgrifact.ProduitRow, ByVal nTarif As Nullable(Of Integer)) As Object
        If Not nTarif.HasValue Then
            Return drProduit("PrixVTTC")
        Else
            Dim drTarifD As DsAgrifact.Tarif_DetailRow = SelectSingleRow(Of DsAgrifact.Tarif_DetailRow)(DsAgrifact.Tarif_Detail, FormatExpression("nTarif={0} AND CodeProduit={1}", nTarif.Value, drProduit.CodeProduit), "")
            If drTarifD Is Nothing OrElse drTarifD.IsPrixVTTCNull Then
                Return drProduit("PrixVTTC")
            Else
                Return drTarifD.PrixVTTC
            End If
        End If
    End Function

    Private Sub DeterminerSourceProduit()
        With Me.ProduitBindingSource
            .SuspendBinding()
            .Sort = ""
            .Filter = ""
            .DataMember = ""
            If Me.CurrentFactRow.IsnTarifNull OrElse Me.CurrentFactRow.nTarif = 0 Then
                .DataSource = Me.DsAgrifact
                .DataMember = "Produit"
                .Filter = ""
            Else
                .DataSource = Me.TarifBindingSource
                .DataMember = "FK_Tarif_Detail_Tarif"
                .Filter = "Libelle is not null AND PrixVTTC is not null"
            End If
            .Sort = "Libelle"
            .ResumeBinding()
        End With
    End Sub

    Private Sub AppliquerTarif(ByVal nTarif As Nullable(Of Integer))
        For Each drv As DataRowView In Me.VFacture_DetailBindingSource
            Dim drProduit As DsAgrifact.ProduitRow = SelectSingleRow(Of DsAgrifact.ProduitRow)(Me.DsAgrifact.Produit, FormatExpression("CodeProduit={0}", drv("CodeProduit")), "")
            If drProduit IsNot Nothing Then
                drv("PrixUTTC") = GetPrixProduit(drProduit, nTarif)
            End If
        Next
        VFacture_DetailBindingSource.ResetBindings(False)
    End Sub

    Private Sub AppliquerRemise(ByVal remise As Object)
        For Each drv As DataRowView In Me.VFacture_DetailBindingSource
            drv("Remise") = remise
        Next
        VFacture_DetailBindingSource.ResetBindings(False)
    End Sub

    Private Sub ActionChangementLigne(ByVal row As DataGridViewRow, ByVal colChanged As String)
        Dim typeFacturation As String = "U1"
        Dim coefU2 As New Nullable(Of Decimal)
        Dim codeProduit As String = Convert.ToString(row.Cells(CodeProduitCol.Index).Value)
        Dim drProduit As DsAgrifact.ProduitRow = SelectSingleRow(Of DsAgrifact.ProduitRow)(Me.DsAgrifact.Produit, FormatExpression("CodeProduit={0}", codeProduit), "")
        If drProduit IsNot Nothing Then
            typeFacturation = CStr(ReplaceDbNull(drProduit("TypeFacturation"), "U1"))
            coefU2 = Nullabilify(Of Decimal)(drProduit("CoefU2"))
        End If

        'Recalculer le montant de la ligne
        Dim u1 As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(U1Col.Index).Value)
        'Gestion des unités liées
        If colChanged = "Unite1" AndAlso coefU2.HasValue Then
            row.Cells(U2Col.Index).Value = DBNullify(NullableMult(u1, coefU2))
        End If
        Dim u2 As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(U2Col.Index).Value)
        Dim prixU As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(PrixUTTCCol.Index).Value)
        Dim remise As Nullable(Of Decimal) = Nullabilify(Of Decimal)(row.Cells(RemiseCol.Index).Value)

        'Calcul du montant TTC de la ligne
        Dim montantTTC As Nullable(Of Decimal)
        Select Case typeFacturation
            Case "U2" : montantTTC = NullableMult(u2, prixU)
            Case "U1xU2" : montantTTC = NullableMult(u1, u2, prixU)
            Case Else : montantTTC = NullableMult(u1, prixU)
        End Select

        'Application de la remise
        If remise.HasValue Then
            montantTTC = NullableMult(montantTTC, 1 - remise.Value / 100)
        End If

        row.Cells(MontantTTCCol.Index).Value = DBNullify(montantTTC)
    End Sub

    Private Sub RowDetailChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        If skip Then Exit Sub
        If e.Action = DataRowAction.Change Or e.Action = DataRowAction.Add Then
            skip = True
            Dim montantTTC As Nullable(Of Decimal) = Nullabilify(Of Decimal)(e.Row("MontantLigneTTC"))
            Dim TTVA As String = CStr(ReplaceDbNull(e.Row("TTVA"), ""))
            Dim txTVA As Nullable(Of Decimal) = DsAgrifact.TVA.GetTauxTVA(TTVA, PointDeVente.DsAgrifact.TVARow.ModeTaux.TtcToHt)
            'Calcul du montant HT de la ligne
            Dim montantHT As Nullable(Of Decimal) = NullableMult(montantTTC, txTVA)
            If montantHT.HasValue Then montantHT = Decimal.Round(montantHT.Value, 2, MidpointRounding.AwayFromZero)
            'Calcul du montant TVA de la ligne
            Dim montantTVA As Nullable(Of Decimal) = NullableOp(AddressOf Decimal.Subtract, montantTTC, montantHT)

            'Mise à jour de la ligne
            e.Row("MontantLigneHT") = DBNullify(montantHT)
            e.Row("MontantLigneTVA") = DBNullify(montantTVA)

            'Recalculer le montant de la facture
            CalculerFacture()
            skip = False
        ElseIf e.Action = DataRowAction.Delete Then
            CalculerFacture()
        End If
        MajBoutons()
    End Sub

    Private Sub VFactureBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VFactureBindingSource.CurrentChanged
        MajBoutons()
        If VFactureBindingSource.Position >= 0 Then
            prevNClient = -1
            CalculerFacture()
        End If
    End Sub

    Private Sub CalculerFacture()
        If Me.VFactureBindingSource.Position < 0 Then Exit Sub
        Dim drFacture As DsAgrifact.VFactureRow = Me.CurrentFactRow
        Dim montantTTC As Nullable(Of Decimal) = 0
        Dim recapsTVA As New Dictionary(Of String, RecapTVA)

        Dim hasChanged As Boolean = False
        For Each dr As DsAgrifact.VFacture_DetailRow In drFacture.GetVFacture_DetailRows
            hasChanged = hasChanged Or (dr.RowState = DataRowState.Added) Or (dr.RowState = DataRowState.Modified)
            Dim ttva As String = CStr(ReplaceDbNull(dr("TTVA"), ""))
            Dim montantLigneTTC As Nullable(Of Decimal) = Nullabilify(Of Decimal)(dr("MontantLigneTTC"))
            montantTTC = NullableOp(AddressOf Decimal.Add, montantTTC, montantLigneTTC)
            If montantLigneTTC.HasValue Then
                If recapsTVA.ContainsKey(ttva) Then
                    recapsTVA(ttva).AddMontantTTC(montantLigneTTC.Value)
                Else
                    recapsTVA.Add(ttva, New RecapTVA(DsAgrifact, ttva, montantLigneTTC.Value))
                End If
            End If
        Next

        If hasChanged Then 'Pas la peine de MAJ la ligne sans raison
            drFacture("MontantTTC") = DBNullify(montantTTC)
            'Calculer le montant HT à partir des recap pour eviter les erreurs de centime
            Dim montantHT As New Nullable(Of Decimal)
            For Each r As RecapTVA In recapsTVA.Values
                If Not montantHT.HasValue Then
                    montantHT = r.BaseHT
                Else
                    montantHT = montantHT.Value + r.BaseHT
                End If
            Next
            drFacture("MontantHT") = DBNullify(montantHT)
            drFacture("MontantTVA") = DBNullify(NullableOp(AddressOf Decimal.Subtract, montantTTC, montantHT))
            Me.VFactureBindingSource.ResetCurrentItem()
        End If
        AfficherRecapTVA(recapsTVA.Values)
    End Sub

    Private Sub CalculerRecapTVA()
        If Me.VFactureBindingSource.Position < 0 Then Exit Sub
        AfficherRecapTVA(CalculerRecapTVA(Me.CurrentFactRow))
    End Sub

    Public Shared Function CalculerRecapTVA(ByVal drFacture As DsAgrifact.VFactureRow) As List(Of RecapTVA)
        Dim recapsTVA As New Dictionary(Of String, RecapTVA)

        For Each dr As DsAgrifact.VFacture_DetailRow In drFacture.GetVFacture_DetailRows
            Dim ttva As String = CStr(ReplaceDbNull(dr("TTVA"), ""))
            Dim montantLigneTTC As Nullable(Of Decimal) = Nullabilify(Of Decimal)(dr("MontantLigneTTC"))
            If montantLigneTTC.HasValue Then
                If recapsTVA.ContainsKey(ttva) Then
                    recapsTVA(ttva).AddMontantTTC(montantLigneTTC.Value)
                Else
                    recapsTVA.Add(ttva, New RecapTVA(Cast(Of DsAgrifact)(drFacture.Table.DataSet), ttva, montantLigneTTC.Value))
                End If
            End If
        Next
        Return (New List(Of RecapTVA)(recapsTVA.Values))
    End Function

    Private Sub ImprimerTicket()
        If Not My.Settings.PrinterEnabled Then Exit Sub
        If Me.CurrentFactRow Is Nothing Then Exit Sub
        Me.DsAgrifact.Reglement_Detail.Clear()
        Me.DsAgrifact.Reglement.Clear()
        Using dta As New DsAgrifactTableAdapters.ReglementTA
            dta.FillBynDevis(Me.DsAgrifact.Reglement, Me.CurrentFactRow.nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.Reglement_DetailTA
            dta.FillBynDevis(Me.DsAgrifact.Reglement_Detail, Me.CurrentFactRow.nDevis)
        End Using
        GestionImpressionTicket.ImprimerTicket(Me.CurrentFactRow)
    End Sub
#End Region

#Region " Gestion Client "
    Private Sub BtNewClient_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BtNewClient.KeyPress
        If e.KeyChar = vbCr Or e.KeyChar = " "c Then
            BtNewClient_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtNewClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNewClient.Click
        If Me.VFactureBindingSource.Current Is Nothing Then Exit Sub
        Using fr As New FrSaisieClient()
            If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Recharger la liste des clients
                ChargerClients()
                'Sélectionner le client
                Me.CurrentFactRow.nClient = fr.NEntreprise
                'Recalculer l'adresse
                NClientChanged()
                Me.VFactureBindingSource.ResetCurrentItem()
            End If
        End Using
    End Sub

    Private Sub BtFindClient_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BtFindClient.KeyPress
        If e.KeyChar = vbCr Or e.KeyChar = " "c Then
            BtFindClient_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtFindClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFindClient.Click
        Using fr As New FrRecherche()
            If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Recharger la liste des clients
                ChargerClients()
                'Sélectionner le client
                Me.CurrentFactRow.nClient = fr.SelectedId
                'Recalculer l'adresse
                NClientChanged()
                Me.VFactureBindingSource.ResetCurrentItem()
            End If
        End Using
    End Sub

    Private Sub NClientComboBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NClientComboBox.Validated
        NClientChanged()
    End Sub

    Private Sub NClientComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles NClientComboBox.SelectionChangeCommitted
        NClientComboBox.DataBindings("SelectedValue").WriteValue()
        NClientChanged()
    End Sub

    Private Sub NClientChanged(Optional ByVal force As Boolean = False)
        If VFactureBindingSource.Current Is Nothing Then Exit Sub
        If Me.CurrentFactRow.IsnClientNull Then Exit Sub
        'Seulement si le nClient à changé
        If Me.CurrentFactRow.nClient <> prevNClient Or force Then
            prevNClient = CInt(Me.CurrentFactRow.nClient)
            Dim drClient As DsAgrifact.EntrepriseRow = SelectSingleRow(Of DsAgrifact.EntrepriseRow)(Me.DsAgrifact.Entreprise, FormatExpression("nEntreprise={0}", prevNClient), "")
            If drClient IsNot Nothing Then
                Dim drv As DataRowView = Cast(Of DataRowView)(VFactureBindingSource.Current)
                'Calculer l'adresse client
                Dim adresse As String = AdresseClient(drClient)
                If Convert.ToString(drv("AdresseFacture")) <> adresse Then
                    drv("AdresseFacture") = adresse
                End If
                'Affecter eventuellement le tarif
                Dim modifLignes As Boolean = False
                If Convert.ToString(drv("nTarif")) <> Convert.ToString(drClient("nTarif")) Then
                    drv("nTarif") = drClient("nTarif")
                    'Propager le tarif aux lignes de facturation
                    AppliquerTarif(Nullabilify(Of Integer)(drv("nTarif")))
                    DeterminerSourceProduit()
                    modifLignes = True
                End If
                'Affecter eventuellement la remise
                If Convert.ToString(drv("Remise")) <> Convert.ToString(drClient("Remise")) Then
                    drv("Remise") = drClient("Remise")
                    'Propager la remise aux lignes de facturation
                    AppliquerRemise(drv("Remise"))
                    modifLignes = True
                End If
                VFactureBindingSource.ResetCurrentItem()
                If modifLignes Then RecalculerLignes()
            End If
        End If
    End Sub

    Private Function AdresseClient(ByVal nClient As Integer) As String
        Dim drClient As DsAgrifact.EntrepriseRow = SelectSingleRow(Of DsAgrifact.EntrepriseRow)(Me.DsAgrifact.Entreprise, FormatExpression("nEntreprise={0}", nClient), "")
        If drClient IsNot Nothing Then
            Return AdresseClient(drClient)
        Else
            Return Nothing
        End If
    End Function

    Private Function AdresseClient(ByVal drClient As DsAgrifact.EntrepriseRow) As String
        Dim strAdresse As String = String.Format("{0} {1}" & vbCrLf & "{2}" & vbCrLf & "{3} {4} {5}" & vbCrLf & "{6}", _
                                    drClient("Civilite"), drClient("Nom"), _
                                    drClient("Adresse"), _
                                    drClient("CodePostal"), drClient("Ville"), drClient("SuffixePostal"), _
                                    drClient("Pays"))
        Return strAdresse.Trim
    End Function

    'Mort pour le moment par manque d'evenement, sinon ajouter un bouton ou un menu ?
    'Private Sub NClientComboBox_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If Me.VFactureBindingSource.Current Is Nothing Then Exit Sub
    '    Using fr As New FrSaisieClient(CInt(Me.CurrentFactRow.nClient))
    '        If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            'Recharger la liste des clients
    '            ChargerClients()
    '            'Sélectionner le client
    '            Me.CurrentFactRow.nClient = fr.NEntreprise
    '            'Recalculer l'adresse
    '            NClientChanged(True)
    '        End If
    '    End Using
    'End Sub
#End Region

    Private Sub ControlValidated(ByVal sender As Object, ByVal e As EventArgs) _
                        Handles DateFactureDateTimePicker.ValueChanged, NClientComboBox.Validated, _
                        AdresseFactureTextBox.Validated, NTarifComboBox.Validated, _
                        RemiseTextBox.Validated, ObservationTextBox.Validated
        Me.VFactureBindingSource.EndEdit()
    End Sub

End Class
