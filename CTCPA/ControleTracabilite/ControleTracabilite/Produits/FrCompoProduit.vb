Public Class FrCompoProduit

    Private modif As Boolean
    Private currentCodeProduit As Object

#Region "Props"
    Private _CodeProduit As String
    Public Property CodeProduit() As String
        Get
            Return _CodeProduit
        End Get
        Set(ByVal value As String)
            _CodeProduit = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal CodeProduit As String)
        Me.New()
        Me.CodeProduit = CodeProduit
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ProduitTableAdapter.FillByInactif(Me.AgrifactTracaDataSet.Produit, False)
        If Me.CodeProduit IsNot Nothing Then
            Me.CompositionProduitTableAdapter.FillByCodeProduit(Me.AgrifactTracaDataSet.CompositionProduit, Me.CodeProduit)
            Me.AgrifactTracaDataSet.CompositionProduit.InitAutoIncrementSeed(Me.CompositionProduitTableAdapter)
            Me.MasterProduitBindingSource.Position = Me.MasterProduitBindingSource.Find("CodeProduit", Me.CodeProduit)
            Me.TxtCoef.Text = "1"
            lbUnit.Text = String.Format(lbUnit.Text, Cast(Of DataRowView)(Me.MasterProduitBindingSource.Current)("Unite1"))
        End If
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.CompositionProduitBindingSource.EndEdit()
        If Me.AgrifactTracaDataSet.HasChanges Then
            Me.CompositionProduitBindingSource.SuspendBinding()
            Dim produitCompose As Boolean = (Me.CompositionProduitBindingSource.Count > 0)
            Using dta As New AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
                dta.SetProduitCompose(produitCompose, Me.CodeProduit)
            End Using
            Dim coef As Decimal = Decimal.Parse(Me.TxtCoef.Text)
            If coef <> 1 Then
                For Each dr As AgrifactTracaDataSet.CompositionProduitRow In Me.AgrifactTracaDataSet.CompositionProduit
                    If Not dr.IsUnite1Null Then dr.Unite1 /= coef
                    If Not dr.IsUnite2Null Then dr.Unite2 /= coef
                Next
            End If
            Me.CompositionProduitTableAdapter.Update(Me.AgrifactTracaDataSet.CompositionProduit)
            If coef <> 1 Then
                For Each dr As AgrifactTracaDataSet.CompositionProduitRow In Me.AgrifactTracaDataSet.CompositionProduit
                    If Not dr.IsUnite1Null Then dr.Unite1 *= coef
                    If Not dr.IsUnite2Null Then dr.Unite2 *= coef
                Next
            End If
            Me.AgrifactTracaDataSet.CompositionProduit.AcceptChanges()
            modif = True
            Me.CompositionProduitBindingSource.ResumeBinding()
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.CompositionProduitBindingSource.EndEdit()
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
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim MeBindingSource As New BindingSource(Me, "Coef")
        'Me.TxtCoef.DataBindings.Add("Text", MeBindingSource, "Coef")
        SetChildFormIcon(Me)
        ConfigDecimalControl(Me.TxtCoef)
        ConfigDataTableEvents(AgrifactTracaDataSet.CompositionProduit, AddressOf MajBoutons)
        ApplyStyle(Me.CompositionProduitDataGridView, False)
        With CompositionProduitDataGridView
            AddHandler .CellDoubleClick, AddressOf dg_ZoomTextBoxCells
        End With

        ChargerDonnees()
    End Sub

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
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        TbSave.Enabled = AgrifactTracaDataSet.HasChanges
    End Sub
#End Region

#Region "ToolBar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub
#End Region

    Private Sub CompositionProduitBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CompositionProduitBindingSource.CurrentChanged
        If CompositionProduitBindingSource.Current Is Nothing Then Exit Sub
        currentCodeProduit = CType(CompositionProduitBindingSource.Current, DataRowView)("CodeProduitComposition")
    End Sub

    Private Sub CompositionProduitDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CompositionProduitDataGridView.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case CompositionProduitDataGridView.Columns(e.ColumnIndex).DataPropertyName
                Case "CodeProduitComposition"
                    Dim rws() As DataRow = AgrifactTracaDataSet.Produit.Select(String.Format("CodeProduit='{0}'", Convert.ToString(CompositionProduitDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).Replace("'", "''")))
                    If rws.Length > 0 Then
                        Dim drProduit As AgrifactTracaDataSet.ProduitRow = CType(rws(0), AgrifactTracaDataSet.ProduitRow)
                        Dim drCompo As AgrifactTracaDataSet.CompositionProduitRow = CType(CType(CompositionProduitBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.CompositionProduitRow)
                        If Not drProduit.IsLibelleNull Then drCompo.Libelle = drProduit.Libelle
                        If Not drProduit.IsUnite1Null Then drCompo.LibUnite1 = drProduit.Unite1
                        If Not drProduit.IsUnite2Null Then drCompo.LibUnite2 = drProduit.Unite2
                        Me.CompositionProduitBindingSource.ResetCurrentItem()
                    End If
                Case "Unite1"
                    Dim u1 As Object = CompositionProduitDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Dim drCompo As AgrifactTracaDataSet.CompositionProduitRow = CType(CType(CompositionProduitBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.CompositionProduitRow)
                    Dim drProduit As AgrifactTracaDataSet.ProduitRow = drCompo.ProduitRowByProduitEnfantCompositionProduit
                    If Not drProduit.IsCoefU2Null Then
                        If IsDBNull(u1) Then
                            drCompo.SetUnite2Null()
                        Else
                            drCompo.Unite2 = drProduit.CoefU2 * CDec(u1)
                        End If
                        Me.CompositionProduitBindingSource.ResetCurrentItem()
                    End If
            End Select
        End If
    End Sub

    Private Sub TbCreerMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCreerMP.Click
        With New FrFicheProduit()
            .Owner = Me
            .TypeProduit = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.ProduitBindingSource.SuspendBinding()
                Me.AgrifactTracaDataSet.EnforceConstraints = False
                Me.ProduitTableAdapter.FillByInactif(Me.AgrifactTracaDataSet.Produit, False)
                Me.AgrifactTracaDataSet.EnforceConstraints = True
                Me.ProduitBindingSource.ResumeBinding()
            End If
        End With
    End Sub
End Class