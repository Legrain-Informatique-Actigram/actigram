Namespace Fabrications
    Public Class FrImprEtiqCB

#Region "Props"
        Private modif As Boolean

        Private _nMvt As Integer = -1
        Public Property NMouvement() As Integer
            Get
                Return _nMvt
            End Get
            Set(ByVal value As Integer)
                _nMvt = value
            End Set
        End Property

        'Private ReadOnly Property CurrentBRRow() As AgrifactTracaDataSet.ABonReceptionRow
        '    Get
        '        If Me.BRBindingSource.Current Is Nothing Then
        '            Return Nothing
        '        Else
        '            Return DirectCast(DirectCast(Me.BRBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReceptionRow)
        '        End If
        '    End Get
        'End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal nMouvement As Integer)
            Me.New()
            Me.NMouvement = nMouvement
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerDonnees()
            'Me.EntrepriseTableAdapter.FillFournisseurs(Me.AgrifactTracaDataSet.Entreprise, True)
            Me.ProduitTableAdapter.FillByInactif(Me.AgrifactTracaDataSet.Produit, False)
            If Me.NMouvement >= 0 Then
                Me.MouvementTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement, Me.NMouvement)
                Me.Mouvement_DetailTableAdapter.FillBynMouvement(Me.AgrifactTracaDataSet.Mouvement_Detail, Me.NMouvement)
                Me.AgrifactTracaDataSet.Mouvement_Detail.MatPremFromSign()
                'If Me.AgrifactTracaDataSet.Mouvement_Detail.Rows.Count > 0 Then
                '    With Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Me.AgrifactTracaDataSet.Mouvement_Detail.Rows(0))
                '        Me.TxNLot.Text = .nLot
                '    End With
                'End If
            End If
        End Sub
#End Region

#Region "Page"
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ApplyStyle(Mouvement_DetailDataGridView, False)
            ChargerDonnees()
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
            Mouvement_DetailDataGridView.EndEdit()
            Dim dsEtat As New EtatsDataset
            For Each r As DataGridViewRow In Mouvement_DetailDataGridView.Rows
                If r.DataBoundItem IsNot Nothing Then
                    Dim nbEtiq As Integer = 0
                    Integer.TryParse(Convert.ToString(r.Cells(ColNbEtiq.Index).Value), nbEtiq)
                    If nbEtiq > 0 Then
                        Dim drMvtDetail As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                        Dim drMvt As AgrifactTracaDataSet.MouvementRow = drMvtDetail.MouvementRow
                        For i As Integer = 1 To nbEtiq
                            Dim dr As EtatsDataset.EtiqCodeBarreMouvRow = dsEtat.EtiqCodeBarreMouv.NewEtiqCodeBarreMouvRow
                            With dr
                                'If Not drMvt.IsnPieceNull Then .nPiece = drMvt.nPiece
                                .nPiece = Convert.ToString(Me.NMouvement)
                                If Not drMvt.IsDateMouvementNull Then .DateMouvement = drMvt.DateMouvement
                                If Not drMvtDetail.IsCodeProduitNull Then .codeproduit = drMvtDetail.CodeProduit
                                If Not drMvtDetail.IsLibelleNull Then .libelle = drMvtDetail.Libelle
                                If Not drMvtDetail.IsnLotNull Then .nlot = drMvtDetail.nLot
                                If Not drMvtDetail.IsLibUnite1Null Then .libunite1 = drMvtDetail.LibUnite1
                                If Not drMvtDetail.IsUnite1Null Then .unite1 = drMvtDetail.Unite1
                                If Not drMvtDetail.IsLibUnite2Null Then .libunite2 = drMvtDetail.LibUnite2
                                If Not drMvtDetail.IsUnite2Null Then .unite2 = drMvtDetail.Unite2
                                .ConstruireCodeBarre(CodeBarre.TypeCodeBarre.Fabrication, drMvtDetail.ProduitRow, drMvt)
                                .FormaterCodeBarre()
                            End With
                            dsEtat.EtiqCodeBarreMouv.AddEtiqCodeBarreMouvRow(dr)
                        Next
                    End If
                End If
            Next
            If dsEtat.EtiqCodeBarreMouv.Rows.Count = 0 Then
                MsgBox("Aucune étiquette à imprimer.", MsgBoxStyle.Exclamation)
            Else
                EcranCrystal.Apercu("RptEtiquetteFab", dsEtat, "")
            End If
        End Sub
#End Region

#Region "Mouvement_DetailDataGridView"
        Private Sub Mouvement_DetailDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles Mouvement_DetailDataGridView.DataBindingComplete
            If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
                For Each r As DataGridViewRow In Mouvement_DetailDataGridView.Rows
                    If r.DataBoundItem IsNot Nothing Then
                        Dim drMvtDetail As AgrifactTracaDataSet.Mouvement_DetailRow = Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                        If Not drMvtDetail.ProduitRow.IsCodeBarreNull Then
                            r.Cells(ColNbEtiq.Index).Value = 1
                        Else
                            r.Cells(ColNbEtiq.Index).Value = 0
                            r.ReadOnly = True
                            r.DefaultCellStyle.ForeColor = SystemColors.GrayText
                        End If
                    End If
                Next
            End If
        End Sub
#End Region

    End Class
End Namespace
