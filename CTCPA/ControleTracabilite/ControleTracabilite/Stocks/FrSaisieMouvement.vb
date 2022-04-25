Namespace Stocks
    Public Class FrSaisieMouvement
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

        Private _type As Stocks.GestionStock.TypeMouvement = Stocks.GestionStock.TypeMouvement.None
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

        Public Sub New(ByVal nMouvement As Integer)
            Me.New()
            Me.NMouvement = nMouvement
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerListeChoix()
            Me.AgrifactTracaDataSet.ListeChoix.Clear()
            With Me.ListeChoixTableAdapter
                .ClearBeforeFill = False
                .FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeMouvement)
                .FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeDepots)
            End With
        End Sub

        Private Sub ChargerDonnees()
            Me.ProduitTableAdapter.FillByInactif(Me.AgrifactTracaDataSet.Produit, False)
            ChargerListeChoix()
            If Me.NMouvement >= 0 Then
                Me.MouvementTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement, Me.NMouvement)
                Me.Mouvement_DetailTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement_Detail, Me.NMouvement)
            Else
                Me.MouvBindingSource.AddNew()
                With Me.CurrentMouvRow
                    If Me.TypeMouvement <> Stocks.GestionStock.TypeMouvement.None Then
                        .TypeMouvement = Me.TypeMouvement.ToString
                    End If
                    .DateMouvement = Now.Date
                    '.nPiece = Microsoft.VisualBasic.Left(Lots.GetNLotFab(CInt(.nMouvement), Now, Convert.ToString(.Item("Description"))), AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
                End With
                Me.MouvBindingSource.ResetCurrentItem()
            End If
            'Me.AgrifactTracaDataSet.AcceptChanges()
            MajBoutons()
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
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
                Me.MouvementTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement)
                Me.Mouvement_DetailTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement_Detail)
                modif = True
            End If
            MajBoutons()
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
            ApplyStyle(ProduitsDataGridView, False)

            Me.ChoixTypeMvtBindingSource.Filter = String.Format("NomChoix='{0}' AND Valeur NOT IN ('Fabrication','Conditionnement','ModeleFab')", AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeMouvement.ToString)
            Me.ChoixDepotDepartBindingSource.Filter = String.Format("NomChoix='{0}'", AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeDepots.ToString)
            Me.ChoixDepotDestBindingSource.Filter = String.Format("NomChoix='{0}'", AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeDepots.ToString)
            Me.AgrifactTracaDataSet.Mouvement.InitAutoIncrementSeed()
            Me.AgrifactTracaDataSet.Mouvement_Detail.InitAutoIncrementSeed()
            ChargerDonnees()
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Mouvement, AddressOf MajBoutons)
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Mouvement_Detail, AddressOf MajBoutons)
        End Sub

        'Private Sub MouvBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouvBindingSource.CurrentItemChanged
        '    With Me.CurrentMouvRow
        '        If Not .IsnPieceNull AndAlso .nPiece.Length > 0 Then Exit Sub
        '    End With
        '    TbRefreshNLot_Click(Nothing, Nothing)
        'End Sub

        'Private Sub TbRefreshNLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRefreshNLot.Click
        '    If Me.TypeMouvement <> AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement.Conditionnement Then Exit Sub
        '    If My.Settings.FormatLotFab.Length = 0 Then Exit Sub
        '    With Me.CurrentMouvRow
        '        If .IsDateMouvementNull Then Exit Sub
        '        Dim nLot As String = Microsoft.VisualBasic.Left(Lots.GetNLotFab(CInt(.nMouvement), .DateMouvement, Convert.ToString(.Item("Description"))), AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
        '        If .nPiece <> nLot Then
        '            .nPiece = nLot
        '            MouvBindingSource.ResetCurrentItem()
        '        End If
        '    End With
        'End Sub

        Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NPieceTextBox.Validated, DateFactureDateTimePicker.ValueChanged, DescriptionTextBox.Validated, TypeMouvementComboBox.SelectedIndexChanged, DepotDestComboBox.Validated, DepotDepartComboBox.Validated
            MouvBindingSource.EndEdit()
            If sender Is TypeMouvementComboBox Then
                If Me.TypeMouvementComboBox.Text.Length = 0 Then Exit Sub
                Me.TypeMouvement = EnumParse(Of Stocks.GestionStock.TypeMouvement)(Me.TypeMouvementComboBox.Text.Replace(" ", "_"))
                Select Case Me.TypeMouvement
                    Case Stocks.GestionStock.TypeMouvement.Sorties
                        Me.DepotDepartComboBox.Enabled = True
                        Me.DepotDestComboBox.Enabled = False
                        If Not Me.CurrentMouvRow.IsDepotDestNull Then Me.CurrentMouvRow.SetDepotDestNull()
                    Case Stocks.GestionStock.TypeMouvement.Transfert_dépôt
                        Me.DepotDepartComboBox.Enabled = True
                        Me.DepotDestComboBox.Enabled = True
                    Case Else
                        Me.DepotDepartComboBox.Enabled = False
                        Me.DepotDestComboBox.Enabled = True
                        If Not Me.CurrentMouvRow.IsDepotDepartNull Then Me.CurrentMouvRow.SetDepotDepartNull()
                End Select
                Me.ColRechLot.Visible = (Me.TypeMouvement <> GestionStock.TypeMouvement.Entrées)
                Me.TbCodeBarre.Visible = (Me.TypeMouvement <> GestionStock.TypeMouvement.Entrées)
                Me.MouvBindingSource.ResetCurrentItem()
            End If
        End Sub

        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            ProduitBindingNavigatorSaveItem.Enabled = Me.AgrifactTracaDataSet.HasChanges
        End Sub

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
            Enregistrer()
        End Sub

        Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
            If Me.TypeMouvement = GestionStock.TypeMouvement.Inventaire Then
                FrInventaire.ImprimerInventaire(Me.CurrentMouvRow.DateMouvement, Me.CurrentMouvRow.DepotDest)
            Else
                EcranCrystal.Apercu("RptListeMouvement", Me.AgrifactTracaDataSet)
            End If
        End Sub
#End Region

#Region "Grid"
        Private Sub ProduitsFinisDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProduitsDataGridView.CellValueChanged
            If e.RowIndex >= 0 Then
                Select Case ProduitsDataGridView.Columns(e.ColumnIndex).DataPropertyName
                    Case "CodeProduit"
                        Dim rws() As DataRow = AgrifactTracaDataSet.Produit.Select(String.Format("CodeProduit='{0}'", Convert.ToString(ProduitsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).Replace("'", "''")))
                        If rws.Length > 0 Then
                            Dim drProduit As AgrifactTracaDataSet.ProduitRow = CType(rws(0), AgrifactTracaDataSet.ProduitRow)
                            Dim r As DataGridViewRow = ProduitsDataGridView.Rows(e.RowIndex)
                            Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Cast(Of DataRowView)(Me.MouvDetailBindingSource.Current).Row)
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
                            Me.MouvDetailBindingSource.ResetCurrentItem()
                            If Me.DescriptionTextBox.Text.Length = 0 Then
                                Me.DescriptionTextBox.Text = Microsoft.VisualBasic.Left(drProduit.Libelle, Me.AgrifactTracaDataSet.Mouvement.DescriptionColumn.MaxLength)
                            End If
                        End If
                    Case "Unite1"
                        Dim u1 As Object = ProduitsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        Dim drMouv_detail As AgrifactTracaDataSet.Mouvement_DetailRow = CType(CType(MouvDetailBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.Mouvement_DetailRow)
                        Dim drProduit As AgrifactTracaDataSet.ProduitRow = drMouv_detail.ProduitRow
                        If drProduit Is Nothing Then Exit Sub
                        If Not drProduit.IsCoefU2Null Then
                            If IsDBNull(u1) Then
                                drMouv_detail.SetUnite2Null()
                            Else
                                drMouv_detail.Unite2 = drProduit.CoefU2 * CDec(u1)
                            End If
                            Me.MouvDetailBindingSource.ResetCurrentItem()
                        End If
                End Select
            End If
        End Sub

        Private Sub ProduitsFinisDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProduitsDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColRechProd.Index Then
                Using fr As New FrRechProduits(AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.Tous)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim cellCode As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.PFCodeProduit.Index)
                        cellCode.Value = fr.Result
                        Cast(Of DataGridView)(sender).Refresh()
                    End If
                End Using
            ElseIf e.ColumnIndex = ColRechLot.Index Then
                Dim drv As DataRowView = Cast(Of DataRowView)(Me.MouvDetailBindingSource.Current)
                If Convert.ToString(drv("CodeProduit")).Length = 0 Then Exit Sub
                Using fr As New FrRechLot(Convert.ToString(drv("CodeProduit")))
                    fr.ExcludedNMvt = CInt(Me.CurrentMouvRow.nMouvement)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim cellLot As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.nLot.Index)
                        cellLot.Value = fr.Result
                        Cast(Of DataGridView)(sender).Refresh()
                    End If
                End Using
            End If
        End Sub
#End Region

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
                    .SearchInCurrentDs = False
                    .FiltrerMP = False
                    .TopMost = True
                    .Show(Me)
                    AddHandler .FormClosed, AddressOf CodeBarreFormClosed
                End With
                TbCodeBarre.Checked = True
            End If
        End Sub

        Private Sub CodeBarreFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            TbCodeBarre.Checked = False
        End Sub

        Private Sub BtDepots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDepots.Click
            Using fr As New FrListeChoix(AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeDepots)
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'Recharger la liste des dépots
                    ChargerListeChoix()
                End If
            End Using
        End Sub
    End Class
End Namespace
