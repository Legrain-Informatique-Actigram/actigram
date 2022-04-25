Namespace Fabrications
    Public Class FrSaisieTransfo
        Implements IArgumentable

#Region "Props"
        Private modif As Boolean

        Private _nMouv As Integer = -1
        Public Property NMouvement() As Integer
            Get
                Return _nMouv
            End Get
            Set(ByVal value As Integer)
                _nMouv = value
            End Set
        End Property


        Public Property Parametre() As String Implements IArgumentable.Arguments
            Get
                Return Me.TypeMouvement.ToString
            End Get
            Set(ByVal value As String)
                Me.TypeMouvement = EnumParse(Of Stocks.GestionStock.TypeMouvement)(value)
            End Set
        End Property

        Private _type As Stocks.GestionStock.TypeMouvement = Stocks.GestionStock.TypeMouvement.Conditionnement
        Public Property TypeMouvement() As Stocks.GestionStock.TypeMouvement
            Get
                Return _type
            End Get
            Set(ByVal value As Stocks.GestionStock.TypeMouvement)
                _type = value
            End Set
        End Property

        Private ReadOnly Property CurrentMouvRow() As AgrifactTracaDataSet.MouvementRow
            Get
                If Me.MouvBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.MouvBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.MouvementRow)
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal type As Stocks.GestionStock.TypeMouvement)
            Me.New()
            Me.TypeMouvement = type
        End Sub

        Public Sub New(ByVal nDevis As Integer)
            Me.New()
            Me.NMouvement = nDevis
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerDonnees()
            'AJOUT TV 22/05/2012
            Me.LotFabricationTableAdapter.Fill(Me.AgrifactTracaDataSet.LotFabrication)

            Me.BRDetailTableAdapter.Fill(Me.AgrifactTracaDataSet.ABonReception_Detail)
            Me.BRTableAdapter.Fill(Me.AgrifactTracaDataSet.ABonReception)
            Me.EntrepriseTableAdapter.FillFournisseurs(Me.AgrifactTracaDataSet.Entreprise, True)
            Me.ProduitTableAdapter.FillByInactif(Me.AgrifactTracaDataSet.Produit, False)
            If Me.NMouvement >= 0 Then
                Me.MouvementTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement, Me.NMouvement)
                Me.Mouvement_DetailTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement_Detail, Me.NMouvement)
                Me.AgrifactTracaDataSet.Mouvement_Detail.MatPremFromSign()
            Else
                Me.MouvBindingSource.AddNew()
                With Me.CurrentMouvRow
                    .TypeMouvement = Me.TypeMouvement.ToString
                    .DateMouvement = Now.Date
                    Select Case Me.TypeMouvement
                        Case Stocks.GestionStock.TypeMouvement.Conditionnement
                            .nPiece = Microsoft.VisualBasic.Left(Lots.GetNLotFab(CInt(.nMouvement), Now, Convert.ToString(.Item("Description"))), AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
                        Case Stocks.GestionStock.TypeMouvement.ModeleFab
                            .nPiece = "Nouveau Modèle"
                    End Select
                End With
                Me.MouvBindingSource.ResetCurrentItem()
            End If
            MajBoutons()
        End Sub

        Private Sub Enregistrer()
            Me.Validate()

            'Si en mode création de lot vérifie que le numéro de lot n'existe pas déjà 
            If (Me.NPieceTextBox.Enabled = True) Then
                Dim lotExiste As Nullable(Of Boolean)

                Using dtaLot As New AgrifactTracaDataSetTableAdapters.LotTableAdapter
                    lotExiste = dtaLot.NLotExists(Me.CurrentMouvRow.nPiece)
                End Using

                If (lotExiste.HasValue) Then
                    If (lotExiste.Value = True) Then
                        MsgBox("Le numéro de fabrication existe déjà. Enregistrement impossible.", MsgBoxStyle.Exclamation, "Numéro de fabrication en double")

                        Me.NPieceTextBox.Focus()

                        Exit Sub
                    End If
                End If
            End If

            Me.MouvBindingSource.EndEdit()

            If Me.AgrifactTracaDataSet.HasChanges Then
                'Virer les lignes de mouvement vide
                For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In Me.AgrifactTracaDataSet.Mouvement_Detail
                    If Not dr.RowState = DataRowState.Deleted Then
                        If (dr.IsCodeProduitNull OrElse dr.CodeProduit = "") AndAlso dr.IsUnite1Null Then
                            dr.Delete()
                        End If
                    End If
                Next
                'TODO Marquer automatiquement les lots de MP comme terminés en fonction de l'état des stocks ?
                Me.MouvementTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement)
                Me.AgrifactTracaDataSet.Mouvement_Detail.SignFromMatPrem()
                Me.Mouvement_DetailTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement_Detail)
                Me.AgrifactTracaDataSet.Mouvement_Detail.MatPremFromSign()
                modif = True

                'Création du lot si en mode création de lot
                If (Me.NPieceTextBox.Enabled = True) Then
                    'Création du lot dans la table des lots
                    Using dtaLot As New AgrifactTracaDataSetTableAdapters.LotTableAdapter
                        dtaLot.Insert(Me.CurrentMouvRow.nPiece, Me.CurrentMouvRow.DateMouvement, Nothing, Nothing, Nothing, Nothing, Nothing, False, Nothing)
                    End Using

                    Me.NPieceTextBox.Enabled = False
                    Me.DateFactureDateTimePicker.Enabled = False
                End If
            End If

            CorrectionTableLot()

            MajBoutons()
        End Sub

        'legrain 06/03/2014
        Public Sub CorrectionTableLot()
            For Each mr As AgrifactTracaDataSet.MouvementRow In MouvementTableAdapter.GetDataByType("Conditionnement")
                Dim lotExiste As Nullable(Of Boolean)

                Using dtaLot As New AgrifactTracaDataSetTableAdapters.LotTableAdapter
                    lotExiste = dtaLot.NLotExists(mr.nPiece)
                End Using

                If (lotExiste.HasValue) Then
                    If (lotExiste.Value = False) Then
                        Using dtaLot As New AgrifactTracaDataSetTableAdapters.LotTableAdapter
                            dtaLot.Insert(mr.nPiece, mr.DateMouvement, Nothing, Nothing, Nothing, Nothing, Nothing, False, Nothing)
                        End Using
                    End If
                End If
            Next
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.MouvBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
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
#End Region

#Region "Page"
        Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing Then
                If DemanderEnregistrement() Then
                    If modif Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ConfigZoomTextbox(DescriptionTextBox)
            'Gestion des grilles
            ApplyStyle(ProduitsFinisDataGridView, False)
            'AddHandler ProduitsFinisDataGridView.EditingControlShowing, AddressOf MakeComboDropDown
            ApplyStyle(MatPremsDataGridView, False)
            'AddHandler MatPremsDataGridView.EditingControlShowing, AddressOf MakeComboDropDown

            Select Case Me.TypeMouvement
                Case Stocks.GestionStock.TypeMouvement.Conditionnement
                    Me.TbNewFab.Visible = False
                    Me.TbRefreshNLot.Enabled = My.Settings.FormatLotFab.Length > 0
                Case Stocks.GestionStock.TypeMouvement.ModeleFab
                    Me.TbNewModele.Visible = False
                    Me.ToolStripSeparator4.Visible = False
                    Me.TbAffecterMP.Visible = False
                    Me.TbCodeBarre.Visible = False
                    Me.TbImprimer.Visible = False
                    Me.DateFactureDateTimePicker.Visible = False
                    Me.DateFactureLabel.Visible = False
                    Me.MPnLot.Visible = False
                    Me.ColControle.Visible = False
                    Me.NPieceLabel.Text = "Nom modèle:"
                    Me.TbRefreshNLot.Visible = False
            End Select

            Me.AgrifactTracaDataSet.Mouvement.InitAutoIncrementSeed()
            Me.AgrifactTracaDataSet.Mouvement_Detail.InitAutoIncrementSeed()
            ChargerDonnees()
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Mouvement, AddressOf MajBoutons)
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Mouvement_Detail, AddressOf MajBoutons)
            AddHandler Me.AgrifactTracaDataSet.Mouvement_Detail.RowChanged, AddressOf Mouvement_DetailRowChanged
        End Sub
#End Region

#Region "BindingSource"
        Private Sub MouvBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvBindingSource.CurrentItemChanged
            With Me.CurrentMouvRow
                If Not .IsnPieceNull AndAlso .nPiece.Length > 0 Then Exit Sub
            End With
            TbRefreshNLot_Click(Nothing, Nothing)
        End Sub

        Private Sub MouvMPBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvMPBindingSource.CurrentChanged
            If Me.MouvMPBindingSource.Current Is Nothing Then Exit Sub
            With Cast(Of DataRowView)(Me.MouvMPBindingSource.Current)
                If .IsNew AndAlso Not CBool(.Item("MatPrem")) Then .Item("MatPrem") = True
            End With
        End Sub
#End Region

#Region "Bouton"
        Private Sub TbRefreshNLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRefreshNLot.Click
            If Me.TypeMouvement <> Stocks.GestionStock.TypeMouvement.Conditionnement Then Exit Sub
            If My.Settings.FormatLotFab.Length = 0 Then Exit Sub
            With Me.CurrentMouvRow
                If .IsDateMouvementNull Then Exit Sub
                Dim nLot As String = Microsoft.VisualBasic.Left(Lots.GetNLotFab(CInt(.nMouvement), .DateMouvement, Convert.ToString(.Item("Description"))), AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
                If .nPiece <> nLot Then
                    .nPiece = nLot
                    MouvBindingSource.ResetCurrentItem()
                End If
            End With
        End Sub

        Private Sub TbCodeBarre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCodeBarre.Click
            If TbCodeBarre.Checked Then
                For Each f As Form In Me.OwnedForms
                    If TypeOf f Is FrCodeBarre Then
                        f.Close()
                    End If
                Next
                TbCodeBarre.Checked = False
            Else
                'Ouvrir une petite fenetre qui permet de bipper le code barre et de saisir la quantité
                Dim fr As New FrCodeBarre(Me.CurrentMouvRow)
                With fr
                    .FiltrerMP = True
                    .TopMost = True
                    .Show(Me)
                    AddHandler .FormClosed, AddressOf CodeBarreFormClosed
                End With
                TbCodeBarre.Checked = True
            End If
        End Sub

        Private Sub TbPrintBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbPrintBarcode.Click
            'Le code barre se décompose en :
            ' - Le type R pour reception (matière premiere) ou F pour fabrication (produit fini)
            ' - un EAN produit sur 4 digit 
            ' - l'id du BR ou du mouvement sur 6 digits

            'Il faut enregistrer les modifs avant.
            If DemanderEnregistrement() Then
                Using fr As New FrImprEtiqCB(CInt(Me.CurrentMouvRow.nMouvement))
                    fr.ShowDialog(Me)
                End Using
            End If
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
            Enregistrer()
        End Sub

        Private Sub TbAffecterMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbAffecterMP.Click
            AffecterMatPrem()
        End Sub

        Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
            EcranCrystal.Apercu("RptFabrication", Me.AgrifactTracaDataSet)
            ImprimerControles()
        End Sub

        Private Sub TbNewFab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewFab.Click
            DemanderEnregistrement()
            Dim ds As New AgrifactTracaDataSet
            ds.Merge(New DataRow() {Me.CurrentMouvRow})
            GestionTransfos.ModeleToFab(Cast(Of AgrifactTracaDataSet.MouvementRow)(ds.Mouvement.Rows(0)), Me)
        End Sub

        Private Sub TbNewModele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewModele.Click
            DemanderEnregistrement()
            Dim ds As New AgrifactTracaDataSet
            ds.Merge(New DataRow() {Me.CurrentMouvRow})
            GestionTransfos.FabToModele(Cast(Of AgrifactTracaDataSet.MouvementRow)(ds.Mouvement.Rows(0)), Me)
        End Sub
#End Region

#Region "Grid Produits finis"
        'Private currentCodePF As Object
        'Private Sub ProduitsFinisBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvPFBindingSource.CurrentChanged
        '    If MouvPFBindingSource.Current Is Nothing Then Exit Sub
        '    currentCodePF = CType(MouvPFBindingSource.Current, DataRowView)("CodeProduit")
        'End Sub

        Private Sub ProduitsFinisDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProduitsFinisDataGridView.CellValueChanged
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            Select Case ProduitsFinisDataGridView.Columns(e.ColumnIndex).DataPropertyName
                Case "CodeProduit"
                    Dim rws() As DataRow = AgrifactTracaDataSet.Produit.Select(String.Format("CodeProduit='{0}'", Convert.ToString(ProduitsFinisDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).Replace("'", "''")))
                    If rws.Length > 0 Then
                        Dim drProduit As AgrifactTracaDataSet.ProduitRow = CType(rws(0), AgrifactTracaDataSet.ProduitRow)
                        Dim r As DataGridViewRow = ProduitsFinisDataGridView.Rows(e.RowIndex)
                        Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Cast(Of DataRowView)(Me.MouvPFBindingSource.Current).Row)
                        If Not drProduit.IsLibelleNull Then drMouv_detail.Libelle = Microsoft.VisualBasic.Left(drProduit.Libelle, Me.AgrifactTracaDataSet.Mouvement_Detail.LibelleColumn.MaxLength)
                        If Not drProduit.IsUnite1Null Then
                            drMouv_detail.LibUnite1 = drProduit.Unite1
                            r.Cells(PFUnite1.Index).ReadOnly = False
                        Else
                            r.Cells(PFUnite1.Index).ReadOnly = True
                        End If
                        If Not drProduit.IsUnite2Null Then
                            drMouv_detail.LibUnite2 = drProduit.Unite2
                            r.Cells(PFUnite2.Index).ReadOnly = False
                        Else
                            r.Cells(PFUnite2.Index).ReadOnly = True
                        End If
                        Me.MouvPFBindingSource.ResetCurrentItem()
                        If Me.DescriptionTextBox.Text.Length = 0 Then
                            Me.DescriptionTextBox.Text = Microsoft.VisualBasic.Left(drProduit.Libelle, Me.AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
                        End If
                    End If
                Case "Unite1"
                    Dim u1 As Object = ProduitsFinisDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = CType(CType(MouvPFBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.Mouvement_DetailRow)
                    Dim drProduit As AgrifactTracaDataSet.ProduitRow = drMouv_detail.ProduitRow
                    If drProduit Is Nothing Then Exit Sub
                    If Not drProduit.IsCoefU2Null Then
                        If IsDBNull(u1) Then
                            drMouv_detail.SetUnite2Null()
                        Else
                            drMouv_detail.Unite2 = drProduit.CoefU2 * CDec(u1)
                        End If
                        Me.MouvPFBindingSource.ResetCurrentItem()
                    End If
            End Select

        End Sub


        Private Sub ProduitsFinisDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProduitsFinisDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColControle.Index Then
                Controles.GestionGrilleControle.ClicBouton(Me, Cast(Of DataGridView)(sender), e.RowIndex, e.ColumnIndex)
            ElseIf e.ColumnIndex = ColRechProdPF.Index Then
                Using fr As New FrRechProduits(AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.ProduitsFinis)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim cellCode As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.PFCodeProduit.Index)
                        cellCode.Value = fr.Result
                        Cast(Of DataGridView)(sender).Refresh()
                    End If
                End Using
            End If
        End Sub

        Private Sub ProduitsFinisDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles ProduitsFinisDataGridView.DataBindingComplete
            Controles.GestionGrilleControle.RafraichirIcones(Cast(Of DataGridView)(sender), ColControle.Index, e.ListChangedType)
        End Sub
#End Region

#Region "Grid Matières premières"

        'Private Sub MatPremsDataGridView_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles MatPremsDataGridView.CellParsing
        '    If e.RowIndex >= 0 Then
        '        Select Case MatPremsDataGridView.Columns(e.ColumnIndex).DataPropertyName
        '            Case "nLot"
        '                Dim value As String = Convert.ToString(e.Value)
        '                Dim cb As CodeBarre = CodeBarre.Parse(value, Me.AgrifactTracaDataSet)
        '                If cb IsNot Nothing Then
        '                    e.Value = cb.Datarow.NLot
        '                    e.ParsingApplied = True
        '                End If
        '        End Select
        '    End If
        'End Sub

        'Private currentCodeMP As Object
        'Private Sub MouvMPBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvMPBindingSource.CurrentChanged
        '    If MouvMPBindingSource.Current Is Nothing Then Exit Sub
        '    currentCodeMP = CType(MouvMPBindingSource.Current, DataRowView)("CodeProduit")
        'End Sub

        Private Sub MatPremsDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MatPremsDataGridView.RowEnter
            Dim codeProduit As String = Convert.ToString(MatPremsDataGridView.Rows(e.RowIndex).Cells(MPCodeProduit.Index).Value)
            Me.BRDetailBindingSource.Filter = String.Format("BRTermine=False AND CodeProduit='{0}'", codeProduit.Replace("'", "''"))

            'AJOUT TV 22/05/2012
            Me.LotFabricationBindingSource.Filter = String.Format("Termine=False AND CodeProduit='{0}'", codeProduit.Replace("'", "''"))
        End Sub

        Private Sub MatPremsDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MatPremsDataGridView.CellValueChanged
            If e.RowIndex >= 0 Then
                Select Case MatPremsDataGridView.Columns(e.ColumnIndex).DataPropertyName
                    Case "CodeProduit"
                        Dim codeProduit As String = Convert.ToString(MatPremsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                        Me.BRDetailBindingSource.Filter = String.Format("BRTermine=False AND CodeProduit='{0}'", codeProduit.Replace("'", "''"))

                        'AJOUT TV 22/05/2012
                        Me.LotFabricationBindingSource.Filter = String.Format("Termine=False AND CodeProduit='{0}'", codeProduit.Replace("'", "''"))

                        Dim rws() As DataRow = AgrifactTracaDataSet.Produit.Select(String.Format("CodeProduit='{0}'", codeProduit.Replace("'", "''")))
                        If rws.Length > 0 Then
                            Dim drProduit As AgrifactTracaDataSet.ProduitRow = CType(rws(0), AgrifactTracaDataSet.ProduitRow)
                            Dim r As DataGridViewRow = MatPremsDataGridView.Rows(e.RowIndex)
                            Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Cast(Of DataRowView)(Me.MouvMPBindingSource.Current).Row)
                            If Not drProduit.IsLibelleNull Then drMouv_detail.Libelle = Microsoft.VisualBasic.Left(drProduit.Libelle, Me.AgrifactTracaDataSet.Mouvement_Detail.LibelleColumn.MaxLength)
                            If Not drProduit.IsUnite1Null Then
                                drMouv_detail.LibUnite1 = drProduit.Unite1
                                r.Cells(MPUnite1.Name).ReadOnly = False
                            Else
                                r.Cells(MPUnite1.Name).ReadOnly = True
                            End If
                            If Not drProduit.IsUnite2Null Then
                                drMouv_detail.LibUnite2 = drProduit.Unite2
                                r.Cells(MPUnite2.Name).ReadOnly = False
                            Else
                                r.Cells(MPUnite2.Name).ReadOnly = True
                            End If
                            Me.MouvMPBindingSource.ResetCurrentItem()
                        End If
                    Case "Unite1"
                        Dim u1 As Object = MatPremsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = CType(CType(MouvMPBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.Mouvement_DetailRow)
                        Dim drProduit As AgrifactTracaDataSet.ProduitRow = drMouv_detail.ProduitRow
                        If Not drProduit.IsCoefU2Null Then
                            If IsDBNull(u1) Then
                                drMouv_detail.SetUnite2Null()
                            Else
                                drMouv_detail.Unite2 = drProduit.CoefU2 * CDec(u1)
                            End If
                            Me.MouvMPBindingSource.ResetCurrentItem()
                        End If
                    Case "nLot"
                        Dim nDevis As Integer = CInt(CType(CType(MatPremsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell).Items(0), DataRowView).Row.Item("nDevis"))

                        'legrain le 4/9/2013, ajout d'une checkbox pour controler cet affichage
                        If Me.cbAfficheBR.Checked Then
                            If (nDevis <> -1) Then
                                Using fr As New Receptions.FrSaisieBR(nDevis)
                                    fr.ShowDialog()
                                End Using
                            End If
                        End If
                End Select
            End If
        End Sub


        Private Sub MatPremsDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MatPremsDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColRechProdMP.Index Then
                Using fr As New FrRechProduits(AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim cellCode As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.MPCodeProduit.Index)
                        cellCode.Value = fr.Result
                        Cast(Of DataGridView)(sender).Refresh()
                    End If
                End Using
            End If
        End Sub
#End Region

#Region "Affectation auto des matières premières"
        Private Sub AffecterMatPrem()
            Try
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()

                Me.MouvMPBindingSource.CancelEdit()
                Dim ds As New AgrifactTracaDataSet

                'Charger la définition des compositions de produit
                Using dta As New AgrifactTracaDataSetTableAdapters.CompositionProduitTableAdapter
                    dta.Fill(ds.CompositionProduit)
                End Using

                'Charger l'état des stocks dispo ainsi que les lots
                Dim dtStocks As StocksDataSet.EtatStockDataTable
                Using dta As New StocksDataSetTableAdapters.EtatStockTA
                    dtStocks = dta.GetStockGlobalActuelData()
                End Using

                'Charger les BR
                Using dta As New AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
                    dta.Fill(ds.ABonReception)
                End Using

                Using dta As New AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
                    dta.Fill(ds.ABonReception_Detail)
                End Using

                'Pour chaque produit fini
                'Déterminer la quantité de chaque MP en fonction de la composition et de la quantité
                Dim mp As New Dictionary(Of String, Couple(Of Decimal, Decimal))
                For Each drPF As AgrifactTracaDataSet.Mouvement_DetailRow In AgrifactTracaDataSet.Mouvement_Detail.Select("MatPrem=False", "", DataViewRowState.CurrentRows)
                    Dim mult As Decimal
                    If drPF.IsUnite1Null Then
                        mult = 0
                    Else
                        mult = drPF.Unite1
                    End If

                    Dim compRws() As AgrifactTracaDataSet.CompositionProduitRow = Cast(Of AgrifactTracaDataSet.CompositionProduitRow())(ds.CompositionProduit.Select(String.Format("CodeProduit='{0}'", drPF.CodeProduit.Replace("'", "''"))))
                    For Each compRw As AgrifactTracaDataSet.CompositionProduitRow In compRws
                        Dim c As Couple(Of Decimal, Decimal)
                        If mp.ContainsKey(compRw.CodeProduitComposition) Then
                            c = mp(compRw.CodeProduitComposition)
                        Else
                            c = New Couple(Of Decimal, Decimal)
                            mp.Add(compRw.CodeProduitComposition, c)
                        End If
                        If Not compRw.IsUnite1Null Then c.X += mult * compRw.Unite1
                        If Not compRw.IsUnite2Null Then c.Y += mult * compRw.Unite2
                    Next
                Next

                For Each codeProduit As String In mp.Keys
                    Dim quantites As Couple(Of Decimal, Decimal) = mp(codeProduit)

                    'Retrouver d'eventuelles ligne existantes pour en retrancher les quantités
                    For Each rw As AgrifactTracaDataSet.Mouvement_DetailRow In Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow())(AgrifactTracaDataSet.Mouvement_Detail.Select(String.Format("CodeProduit='{0}' AND MatPrem=True", codeProduit.Replace("'", "''")), "", DataViewRowState.CurrentRows))
                        If Not rw.IsUnite1Null Then quantites.X -= rw.Unite1
                        If Not rw.IsUnite2Null Then quantites.Y -= rw.Unite2
                    Next

                    'S'il y a du produit à affecter
                    If quantites.X > 0 Or quantites.Y > 0 Then
                        'Trouver les lots disponibles non terminé, trié par date de lot
                        'Insérer les lignes de MP en fonction des stocks dispos en commencant par les lots les plus anciens
                        Dim rwLots() As StocksDataSet.EtatStockRow = Cast(Of StocksDataSet.EtatStockRow())(dtStocks.Select(String.Format("CodeProduit='{0}' AND BRTermine=False AND NLot<>'' ", codeProduit.Replace("'", "''")), "BRDate", DataViewRowState.CurrentRows))
                        For Each rwLot As StocksDataSet.EtatStockRow In rwLots
                            Dim q1 As Decimal = Math.Max(0, Math.Min(quantites.X, rwLot.Depart))
                            Dim q2 As Decimal = Math.Max(0, Math.Min(quantites.Y, rwLot.DepartU2))
                            AjouterLigne(codeProduit, rwLot.nLot, q1, q2)
                            quantites.X -= q1
                            quantites.Y -= q2
                            If quantites.X <= 0 And quantites.Y <= 0 Then Exit For
                        Next
                        'S'il y a du reste, on l'ajoute sans lot affecté
                        If quantites.X > 0 Or quantites.Y > 0 Then
                            AjouterLigne(codeProduit, "", quantites.X, quantites.Y)
                        End If
                    End If
                Next
                Me.MouvMPBindingSource.ResetBindings(False)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub AjouterLigne(ByVal codeProduit As String, ByVal nLot As String, ByVal unite1 As Decimal, ByVal unite2 As Decimal)
            Dim existant As AgrifactTracaDataSet.Mouvement_DetailRow = SelectSingleRow(Of AgrifactTracaDataSet.Mouvement_DetailRow)(AgrifactTracaDataSet.Mouvement_Detail, String.Format("CodeProduit='{0}' AND nLot='{1}' AND MatPrem=True", codeProduit.Replace("'", "''"), nLot.Replace("'", "''")), "")
            If existant Is Nothing Then
                Dim drProduit As AgrifactTracaDataSet.ProduitRow = SelectSingleRow(Of AgrifactTracaDataSet.ProduitRow)(AgrifactTracaDataSet.Produit, String.Format("CodeProduit='{0}'", codeProduit.Replace("'", "''")), "")
                With Me.AgrifactTracaDataSet.Mouvement_Detail
                    Dim dr As AgrifactTracaDataSet.Mouvement_DetailRow = .NewMouvement_DetailRow
                    With dr
                        .nMouvement = Me.CurrentMouvRow.nMouvement
                        .CodeProduit = codeProduit
                        .MatPrem = True
                        If nLot.Length > 0 Then .nLot = nLot
                        If Not drProduit.IsLibelleNull Then .Libelle = drProduit.Libelle
                        If Not drProduit.IsUnite1Null Then .LibUnite1 = drProduit.Unite1
                        If Not drProduit.IsUnite2Null Then .LibUnite2 = drProduit.Unite2
                        If unite1 <> 0 Then .Unite1 = unite1
                        If unite2 <> 0 Then .Unite2 = unite2
                    End With
                    .AddMouvement_DetailRow(dr)
                End With
            Else
                With existant
                    .BeginEdit()
                    If .IsUnite1Null Then
                        If unite1 <> 0 Then .Unite1 = unite1
                    Else
                        If unite1 <> 0 Then .Unite1 += unite1
                    End If
                    If .IsUnite2Null Then
                        If unite2 <> 0 Then .Unite2 = unite2
                    Else
                        If unite2 <> 0 Then .Unite2 += unite2
                    End If
                    .EndEdit()
                End With
            End If
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub ImprimerControles()
            'Charger la liste des contrôles des produits finis de la fabrication
            Dim cont As New List(Of Controles.DefinitionControle)
            Dim rows() As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow())(Me.AgrifactTracaDataSet.Mouvement_Detail.Select("MatPrem=False"))
            For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In rows
                If Not dr.IsCodeProduitNull Then
                    cont.AddRange(ControleTracabilite.Controles.DefinitionControle.Charger(dr.CodeProduit))
                End If
            Next
            If cont.Count = 0 Then Exit Sub
            Controles.GroupeControle.Imprimer(cont)
        End Sub

        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            ProduitBindingNavigatorSaveItem.Enabled = Me.AgrifactTracaDataSet.HasChanges
        End Sub

        Private Sub CodeBarreFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            TbCodeBarre.Checked = False
        End Sub

        Private Sub Mouvement_DetailRowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            If e.Action = DataRowAction.Add Then
                If Me.ActiveControl Is Me.MatPremsDataGridView OrElse CBool(e.Row("MatPrem")) Then
                    'e.Row("MatPrem") = True
                Else
                    If IsDBNull(e.Row("nLot")) Then
                        e.Row("NLot") = NPieceTextBox.Text
                    End If
                End If
            End If
        End Sub
#End Region

        Private Sub NPieceTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NPieceTextBox.Validated
            For Each drv As DataRowView In Me.MouvPFBindingSource
                If Convert.ToString(drv("nLot")) <> NPieceTextBox.Text Then
                    drv.BeginEdit()
                    drv("nLot") = NPieceTextBox.Text
                    drv.EndEdit()
                End If
            Next

            ProduitsFinisDataGridView.InvalidateColumn(ColControle.Index)
        End Sub

        Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NPieceTextBox.Validated, DateFactureDateTimePicker.ValueChanged, DescriptionTextBox.Validated
            MouvBindingSource.EndEdit()
        End Sub

        Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAfficheBR.CheckedChanged

        End Sub
    End Class
End Namespace
