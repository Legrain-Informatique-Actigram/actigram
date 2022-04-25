Namespace Receptions
    Public Class FrSaisieBR

        Private _nDevis As Integer = -1
        Private _nFournisseur As Integer

        Private currentCodeProduit As Object
        Private modif As Boolean

#Region "Propriétés"
        Public Property nDevis() As Integer
            Get
                Return Me._nDevis
            End Get
            Set(ByVal value As Integer)
                Me._nDevis = value
            End Set
        End Property

        Public Property nFournisseur() As Integer
            Get
                Return Me._nFournisseur
            End Get
            Set(ByVal value As Integer)
                Me._nFournisseur = value
            End Set
        End Property

        Private ReadOnly Property CurrentBRRow() As AgrifactTracaDataSet.ABonReceptionRow
            Get
                If Me.BRBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.BRBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReceptionRow)
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal nDevis As Integer)
            Me.New()
            Me.nDevis = nDevis
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerDonnees()
            Me.EntrepriseTableAdapter.FillFournisseurs(Me.AgrifactTracaDataSet.Entreprise, True)
            Me.ProduitTableAdapter.FillMP(Me.AgrifactTracaDataSet.Produit, False)
            If Me.nDevis >= 0 Then
                Me.ABonReceptionTableAdapter.FillByNDevis(Me.AgrifactTracaDataSet.ABonReception, Me.nDevis)
                Me.ABonReception_DetailTableAdapter.FillByNDevis(Me.AgrifactTracaDataSet.ABonReception_Detail, Me.nDevis)
                If Me.AgrifactTracaDataSet.ABonReception_Detail.Rows.Count > 0 Then
                    With Cast(Of AgrifactTracaDataSet.ABonReception_DetailRow)(Me.AgrifactTracaDataSet.ABonReception_Detail.Rows(0))
                        Me.TxNLot.Text = .NLot
                    End With
                End If
            Else
                Me.BRBindingSource.AddNew()
                With Me.CurrentBRRow
                    If Me.nFournisseur >= 0 Then .nClient = Me.nFournisseur
                    '.nFacture = Me.ABonReceptionTableAdapter.GetNextNFacture.GetValueOrDefault(1)
                    .DateFacture = Now.Date
                    TxNLot.Text = Microsoft.VisualBasic.Left(Lots.GetNLotBR(CInt(.nDevis), Now, Me.NClientComboBox.Text), AgrifactTracaDataSet.ABonReception_Detail.NLotColumn.MaxLength)
                End With
                Me.BRBindingSource.ResetCurrentItem()
            End If
            MajBoutons()
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.BRBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Me.ABonReceptionTableAdapter.Update(Me.AgrifactTracaDataSet)
                Me.ABonReception_DetailTableAdapter.Update(Me.AgrifactTracaDataSet)
                modif = True
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.BRBindingSource.EndEdit()
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

            Me.TbRefreshNLot.Enabled = My.Settings.FormatLotBR.Length > 0

            ConfigZoomTextbox(ObservationTextBox)

            ApplyStyle(ABonReception_DetailDataGridView, False)

            Me.AgrifactTracaDataSet.ABonReception.InitAutoIncrementSeed()
            Me.AgrifactTracaDataSet.ABonReception_Detail.InitAutoIncrementSeed()
            ChargerDonnees()

            ConfigDataTableEvents(Me.AgrifactTracaDataSet.ABonReception, AddressOf MajBoutons, False)
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.ABonReception_Detail, AddressOf MajBoutons)
            AddHandler Me.AgrifactTracaDataSet.ABonReception_Detail.RowChanged, AddressOf ABonReception_Detail_RowChanged

        End Sub

        Private Sub TbRefreshNLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbRefreshNLot.Click
            If My.Settings.FormatLotBR.Length = 0 Then Exit Sub
            With Me.CurrentBRRow
                If .IsDateFactureNull Then Exit Sub
                Dim nLot As String = Microsoft.VisualBasic.Left(Lots.GetNLotBR(CInt(Me.CurrentBRRow.nDevis), Me.CurrentBRRow.DateFacture, Me.NClientComboBox.Text), AgrifactTracaDataSet.ABonReception_Detail.NLotColumn.MaxLength)
                If TxNLot.Text <> nLot Then
                    TxNLot.Text = nLot
                End If
            End With
        End Sub
#End Region

#Region "BRBindingNavigator"
        Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
            'Charger la liste des contrôles des matières premières reçues
            Dim cont As New List(Of Controles.DefinitionControle)
            Dim rows() As AgrifactTracaDataSet.ABonReception_DetailRow = Me.CurrentBRRow.GetABonReception_DetailRows
            For Each dr As AgrifactTracaDataSet.ABonReception_DetailRow In rows
                If Not dr.IsCodeProduitNull Then
                    cont.AddRange(ControleTracabilite.Controles.DefinitionControle.Charger(dr.CodeProduit))
                End If
            Next
            If cont.Count = 0 Then Exit Sub
            Controles.GroupeControle.Imprimer(cont)
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
            Enregistrer()
        End Sub

        Private Sub TbPrintBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbPrintBarcode.Click
            'Le code barre se décompose en :
            ' - Le type R pour reception (matière premiere) ou F pour fabrication (produit fini)
            ' - un EAN produit sur 4 digit 
            ' - l'id du BR ou du mouvement sur 6 digits

            'Il faut enregistrer les modifs avant.
            If DemanderEnregistrement() Then
                Using fr As New FrImprEtiqCB(CInt(Me.CurrentBRRow.nDevis))
                    fr.ShowDialog(Me)
                End Using
            End If
        End Sub

        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub
#End Region

#Region "BindingNavigator1"
        Private Sub ToolStripButtonCopierResultats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAppliquerResultats.Click
            If Me.ABonReception_DetailBindingSource.Current Is Nothing Then Exit Sub

            If (ABonReception_DetailDataGridView.SelectedRows.Count > 1) Then
                MsgBox("Veuillez ne sélectionner qu'une seule ligne.", MsgBoxStyle.Information, "")

                Exit Sub
            End If

            If (Me.ABonReception_DetailDataGridView.SelectedRows.Count > 0) Then
                If MsgBox("Appliquer les résultats des contrôles de la ligne sélectionnée à tous les contrôles similaires de chaque ligne ?" & vbCrLf & "Attention : les anciens résultats seront remplacés.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    'Enregistrement
                    Me.Enregistrer()

                    'Réupération de la ligne sélectionnée
                    Dim bonRecepDetailSelectionDR As AgrifactTracaDataSet.ABonReception_DetailRow = CType(CType(Me.ABonReception_DetailBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReception_DetailRow)

                    Me.ABonReception_DetailBindingSource.SuspendBinding()

                    'Applique les résultats aux lignes du bon de réception
                    Me.AppliquerResultatsControles(bonRecepDetailSelectionDR)

                    Me.ABonReception_DetailBindingSource.ResumeBinding()

                    'Actualisation des valeurs affichées
                    Me.ABonReception_DetailBindingSource.ResetBindings(False)

                    MsgBox("Traitement terminé.", MsgBoxStyle.Information, "")
                End If
            Else
                MsgBox("Veuillez sélectionner une ligne.", MsgBoxStyle.Information, "")

                Exit Sub
            End If
        End Sub
#End Region

#Region "ABonReception_DetailDataGridView"
        Private Sub ABonReception_DetailDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ABonReception_DetailDataGridView.CellValueChanged
            If e.RowIndex >= 0 Then
                Select Case ABonReception_DetailDataGridView.Columns(e.ColumnIndex).DataPropertyName
                    Case "CodeProduit"
                        Dim rws() As DataRow = AgrifactTracaDataSet.Produit.Select(String.Format("CodeProduit='{0}'", Convert.ToString(ABonReception_DetailDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).Replace("'", "''")))
                        If rws.Length > 0 Then
                            Dim drProduit As AgrifactTracaDataSet.ProduitRow = CType(rws(0), AgrifactTracaDataSet.ProduitRow)
                            Dim drBR_detail As AgrifactTracaDataSet.ABonReception_DetailRow = CType(CType(ABonReception_DetailBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReception_DetailRow)
                            If Not drProduit.IsLibelleNull Then drBR_detail.Libelle = drProduit.Libelle
                            If Not drProduit.IsUnite1Null Then drBR_detail.LibUnite1 = drProduit.Unite1
                            If Not drProduit.IsUnite2Null Then drBR_detail.LibUnite2 = drProduit.Unite2
                            Me.ABonReception_DetailBindingSource.ResetCurrentItem()
                        End If
                    Case "Unite1"
                        Dim u1 As Object = ABonReception_DetailDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        Dim drBR_detail As AgrifactTracaDataSet.ABonReception_DetailRow = CType(CType(ABonReception_DetailBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReception_DetailRow)
                        Dim drProduit As AgrifactTracaDataSet.ProduitRow = drBR_detail.ProduitRow
                        If Not drProduit.IsCoefU2Null Then
                            If IsDBNull(u1) Then
                                drBR_detail.SetUnite2Null()
                            Else
                                drBR_detail.Unite2 = drProduit.CoefU2 * CDec(u1)
                            End If
                            Me.ABonReception_DetailBindingSource.ResetCurrentItem()
                        End If
                End Select
            End If
        End Sub

        Private Sub ABonReception_DetailDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ABonReception_DetailDataGridView.CellContentClick
            If e.RowIndex < 0 Then Exit Sub
            If e.ColumnIndex = ColControles.Index Then
                Controles.GestionGrilleControle.ClicBouton(Me, Cast(Of DataGridView)(sender), e.RowIndex, e.ColumnIndex)
            ElseIf e.ColumnIndex = ColRechProd.Index Then
                Using fr As New FrRechProduits(AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres)
                    If fr.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim cellCode As DataGridViewCell = Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(Me.ColCode.Index)
                        cellCode.Value = fr.Result
                        Cast(Of DataGridView)(sender).Refresh()
                    End If
                End Using
            End If
        End Sub

        Private Sub ABonReception_DetailDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles ABonReception_DetailDataGridView.DataBindingComplete
            Controles.GestionGrilleControle.RafraichirIcones(Cast(Of DataGridView)(sender), ColControles.Index, e.ListChangedType)
        End Sub
#End Region

#Region "ABonReception_DetailBindingSource"
        Private Sub ABonReception_DetailBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ABonReception_DetailBindingSource.CurrentChanged
            If ABonReception_DetailBindingSource.Current Is Nothing Then Exit Sub
            currentCodeProduit = CType(ABonReception_DetailBindingSource.Current, DataRowView)("CodeProduit")
        End Sub
#End Region

#Region "BRBindingSource"
        Private Sub BRBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BRBindingSource.CurrentItemChanged
            With Me.CurrentBRRow
                If Not TxNLot.Text.Length > 0 Then Exit Sub
            End With
            'TbRefreshNLot_Click(Nothing, Nothing)
        End Sub
#End Region

#Region "NClientComboBox"
        Private Sub NClientComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NClientComboBox.Validating
            If NClientComboBox.SelectedIndex < 0 Then
                Dim pos As Integer = NClientComboBox.FindString(NClientComboBox.Text)
                If pos < 0 Then
                    e.Cancel = True
                Else
                    NClientComboBox.SelectedIndex = pos
                End If
            End If
        End Sub
#End Region

#Region "Méthodes diverses"
        'Affectation du lot pour les nouvelles lignes
        Private Sub ABonReception_Detail_RowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            If e.Action = DataRowAction.Add AndAlso IsDBNull(e.Row("nLot")) Then
                e.Row("NLot") = TxNLot.Text
            End If
        End Sub

        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            ProduitBindingNavigatorSaveItem.Enabled = Me.AgrifactTracaDataSet.HasChanges
        End Sub

        Private Sub AppliquerResultatsControles(ByVal bonRecepDetailSelectionDR As AgrifactTracaDataSet.ABonReception_DetailRow)
            If Not (bonRecepDetailSelectionDR.IsCodeProduitNull And bonRecepDetailSelectionDR.IsNLotNull) Then
                Dim dsAgrifactTraca As New AgrifactTracaDataSet

                'Récupération des infos de la table ABonReception
                Me.ABonReceptionTableAdapter.FillByNDevis(dsAgrifactTraca.ABonReception, Me.CurrentBRRow.nDevis)

                'Récupération des infos de la table ABonReception_Detail
                Me.ABonReception_DetailTableAdapter.FillByNDevis(dsAgrifactTraca.ABonReception_Detail, Me.CurrentBRRow.nDevis)

                'Récupération des infos des résultats de la ligne sélectionnée
                Dim resultatsControlesLigneSelection As List(Of Controles.ResultatControle) = Controles.ResultatControle.Charger(bonRecepDetailSelectionDR.CodeProduit, bonRecepDetailSelectionDR.NLot, True)

                'Parcours les lignes de détail du bon de réception
                For Each bonRecepDetailDR As AgrifactTracaDataSet.ABonReception_DetailRow In dsAgrifactTraca.ABonReception_Detail
                    If Not (bonRecepDetailDR.IsCodeProduitNull And bonRecepDetailDR.IsNLotNull) Then
                        'Parcours chaque ResultatControle de la ligne sélectionnée
                        For Each resultatControle As Controles.ResultatControle In resultatsControlesLigneSelection
                            'Récupère les infos de la table DefinitionControle correspondant 
                            'au code produit de la ligne de détail et à l'IdControle de la ligne sélectionnée
                            Dim definitionControle As New Controles.DefinitionControle(resultatControle.DefinitionControle.IdControle, bonRecepDetailDR.CodeProduit)

                            If Not (definitionControle Is Nothing) Then
                                'Recherche des infos du barème correspondant au nControle
                                Dim nBareme As Integer = 0

                                For Each bareme As Controles.Bareme In definitionControle.ListeBaremes()
                                    nBareme = bareme.nBareme
                                Next

                                'Récupére les infos des résultats de la ligne de détail
                                'pour le contrôle en cours
                                Dim resultatControleLigneDetail As New Controles.ResultatControle(definitionControle.nControle, resultatControle.nLot, bonRecepDetailDR.CodeProduit)

                                'Si un résultat existe dans la table ResultatControle
                                'pour la ligne de détail, on le met à jour
                                If (resultatControleLigneDetail.nResultatControle <> 0) Then
                                    Controles.ResultatControle.Update(resultatControleLigneDetail.nResultatControle, resultatControle.TestEffectue, resultatControle.Resultat, resultatControle.ResultatConformite)

                                    If (resultatControle.ListeResultatsBaremes.Count > 0) Then
                                        'Parcours chaque ResultatBareme du controle de la ligne sélectionnée
                                        For Each resultatBareme As Controles.ResultatBareme In resultatControle.ListeResultatsBaremes
                                            If (resultatBareme.nResultatBareme <> 0) Then
                                                'Si un résultat existe dans la table ResultatBareme
                                                'pour la ligne de détail pour le contrôle en cours
                                                'on le met à jour
                                                If (resultatControleLigneDetail.ListeResultatsBaremes.Count > 0) Then
                                                    For Each resultatBaremeLigneDetail As Controles.ResultatBareme In resultatControleLigneDetail.ListeResultatsBaremes
                                                        Dim resBar As New Controles.ResultatBareme

                                                        resBar.nResultatBareme = resultatBaremeLigneDetail.nResultatBareme
                                                        resBar.nResultatControle = resultatBaremeLigneDetail.nResultatControle
                                                        resBar.nBareme = nBareme
                                                        resBar.ResultatExpression = resultatBareme.ResultatExpression
                                                        resBar.ResultatConformite = resultatBareme.ResultatConformite
                                                        resBar.ActionCorrectiveEffectuee = resultatBareme.ActionCorrectiveEffectuee
                                                        resBar.Observations = resultatBareme.Observations

                                                        Controles.ResultatBareme.Update(resBar)
                                                    Next
                                                Else 'Sinon on le crée
                                                    Dim resBar As New Controles.ResultatBareme

                                                    resBar.nResultatControle = resultatControleLigneDetail.nResultatControle
                                                    resBar.nBareme = resultatBareme.Bareme.nBareme
                                                    resBar.ResultatExpression = resultatBareme.ResultatExpression
                                                    resBar.ResultatConformite = resultatBareme.ResultatConformite
                                                    resBar.ActionCorrectiveEffectuee = resultatBareme.ActionCorrectiveEffectuee
                                                    resBar.Observations = resultatBareme.Observations

                                                    Controles.ResultatBareme.Insert(resBar)
                                                End If
                                            End If
                                        Next
                                    Else
                                        'On supprime le resultat bareme s'il existe pour la ligne
                                        'du bon de réception mais pas pour la ligne sélectionnée
                                        Controles.ResultatBareme.DeleteBynResultatControle(resultatControleLigneDetail.nResultatControle)
                                    End If
                                Else 'Sinon on crée l'enregistrement dans la table ResultatControle
                                    Dim resCont As New Controles.ResultatControle()

                                    resCont.nControle = definitionControle.nControle
                                    resCont.CodeProduit = bonRecepDetailDR.CodeProduit
                                    resCont.nLot = resultatControle.nLot
                                    resCont.TestEffectue = resultatControle.TestEffectue
                                    resCont.Resultat = resultatControle.Resultat
                                    resCont.ResultatConformite = resultatControle.ResultatConformite

                                    Dim nResultatControleCree As Integer = Controles.ResultatControle.Insert(resCont)

                                    'Puis on crée les lignes dans la table ResultatBareme
                                    For Each resultatBareme As Controles.ResultatBareme In resultatControle.ListeResultatsBaremes
                                        Dim resBar As New Controles.ResultatBareme

                                        resBar.nResultatControle = nResultatControleCree
                                        resBar.nBareme = nBareme
                                        resBar.ResultatExpression = resultatBareme.ResultatExpression
                                        resBar.ResultatConformite = resultatBareme.ResultatConformite
                                        resBar.ActionCorrectiveEffectuee = resultatBareme.ActionCorrectiveEffectuee
                                        resBar.Observations = resultatBareme.Observations

                                        Controles.ResultatBareme.Insert(resBar)
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        End Sub
#End Region

#Region "TxNLot"
        'Propagation de la valeur de lot aux lignes
        Private Sub TxNLot_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxNLot.Validated
            For Each dr As AgrifactTracaDataSet.ABonReception_DetailRow In Me.AgrifactTracaDataSet.ABonReception_Detail.Rows
                dr.NLot = TxNLot.Text
            Next
            ABonReception_DetailDataGridView.InvalidateColumn(ColControles.Index)
        End Sub
#End Region

        Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NClientComboBox.SelectedIndexChanged, DateFactureDateTimePicker.ValueChanged, ObservationTextBox.Validated, TermineCheckBox.CheckedChanged
            BRBindingSource.EndEdit()
        End Sub

    End Class
End Namespace
