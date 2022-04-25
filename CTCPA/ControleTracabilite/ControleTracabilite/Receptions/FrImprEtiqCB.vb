Namespace Receptions
    Public Class FrImprEtiqCB

#Region "Props"
        Private modif As Boolean

        Private _nDevis As Integer = -1
        Public Property NDevis() As Integer
            Get
                Return _nDevis
            End Get
            Set(ByVal value As Integer)
                _nDevis = value
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

        Public Sub New(ByVal nDevis As Integer)
            Me.New()
            Me.NDevis = nDevis
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerDonnees()
            Me.EntrepriseTableAdapter.FillFournisseurs(Me.AgrifactTracaDataSet.Entreprise, True)
            Me.ProduitTableAdapter.FillMP(Me.AgrifactTracaDataSet.Produit, False)
            If Me.NDevis >= 0 Then
                Me.ABonReceptionTableAdapter.FillByNDevis(Me.AgrifactTracaDataSet.ABonReception, Me.NDevis)
                Me.ABonReception_DetailTableAdapter.FillByNDevis(Me.AgrifactTracaDataSet.ABonReception_Detail, Me.NDevis)
                If Me.AgrifactTracaDataSet.ABonReception_Detail.Rows.Count > 0 Then
                    With Cast(Of AgrifactTracaDataSet.ABonReception_DetailRow)(Me.AgrifactTracaDataSet.ABonReception_Detail.Rows(0))
                        Me.TxNLot.Text = .NLot
                    End With
                End If
            End If
        End Sub
#End Region

#Region "Page"
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ApplyStyle(ABonReception_DetailDataGridView, False)
            ChargerDonnees()
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
            ABonReception_DetailDataGridView.EndEdit()
            Dim dsEtat As New EtatsDataset
            For Each r As DataGridViewRow In ABonReception_DetailDataGridView.Rows
                If r.DataBoundItem IsNot Nothing Then
                    Dim nbEtiq As Integer = 0
                    Integer.TryParse(Convert.ToString(r.Cells(ColNbEtiq.Index).Value), nbEtiq)
                    If nbEtiq > 0 Then
                        Dim drBrDetail As AgrifactTracaDataSet.ABonReception_DetailRow = Cast(Of AgrifactTracaDataSet.ABonReception_DetailRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                        Dim drBR As AgrifactTracaDataSet.ABonReceptionRow = drBrDetail.ABonReceptionRow
                        For i As Integer = 1 To nbEtiq
                            Dim dr As EtatsDataset.EtiqCodeBarreRow = dsEtat.EtiqCodeBarre.NewEtiqCodeBarreRow
                            With dr
                                If Not drBR.IsNomClientNull Then .nomFournisseur = drBR.NomClient
                                'If Not drBR.IsnFactureNull Then .nfacture = drBR.nFacture
                                .nfacture = Me.NDevis
                                If Not drBR.IsDateFactureNull Then .datefacture = drBR.DateFacture
                                If Not drBrDetail.IsCodeProduitNull Then .codeproduit = drBrDetail.CodeProduit
                                If Not drBrDetail.IsLibelleNull Then .libelle = drBrDetail.Libelle
                                If Not drBrDetail.IsNLotNull Then .nlot = drBrDetail.NLot
                                If Not drBrDetail.IsLibUnite1Null Then .libunite1 = drBrDetail.LibUnite1
                                If Not drBrDetail.IsUnite1Null Then .unite1 = drBrDetail.Unite1
                                If Not drBrDetail.IsLibUnite2Null Then .libunite2 = drBrDetail.LibUnite2
                                If Not drBrDetail.IsUnite2Null Then .unite2 = drBrDetail.Unite2
                                .ConstruireCodeBarre(CodeBarre.TypeCodeBarre.Reception, drBrDetail.ProduitRow, drBR)
                                .FormaterCodeBarre()
                            End With
                            dsEtat.EtiqCodeBarre.AddEtiqCodeBarreRow(dr)
                        Next
                    End If
                End If
            Next
            If dsEtat.EtiqCodeBarre.Rows.Count = 0 Then
                MsgBox("Aucune étiquette à imprimer.", MsgBoxStyle.Exclamation)
            Else
                EcranCrystal.Apercu("RptEtiquetteBR", dsEtat, "")
            End If
        End Sub
#End Region

#Region "ABonReception_DetailDataGridView"
        Private Sub ABonReception_DetailDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles ABonReception_DetailDataGridView.DataBindingComplete
            If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
                For Each r As DataGridViewRow In ABonReception_DetailDataGridView.Rows
                    If r.DataBoundItem IsNot Nothing Then
                        Dim drBrDetail As AgrifactTracaDataSet.ABonReception_DetailRow = Cast(Of AgrifactTracaDataSet.ABonReception_DetailRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
                        If Not drBrDetail.ProduitRow.IsCodeBarreNull Then
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
