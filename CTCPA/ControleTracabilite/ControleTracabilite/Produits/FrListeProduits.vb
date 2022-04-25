Public Class FrListeProduits
    Implements IArgumentable

#Region "Props"
    Private _arguments As String
    Public Property Arguments() As String Implements IArgumentable.Arguments
        Get
            Return _arguments
        End Get
        Set(ByVal value As String)
            _arguments = value
            If value IsNot Nothing AndAlso value.Length > 0 Then
                Me.Filtre = EnumParse(Of AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)(value)
            End If
        End Set
    End Property


    Private _filtreProduits As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits = AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.Tous
    Public Property Filtre() As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits
        Get
            Return _filtreProduits
        End Get
        Set(ByVal value As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)
            _filtreProduits = value
        End Set
    End Property



    Private _nFamille As Short = -1
    Public Property nFamille() As Short
        Get
            Return _nFamille
        End Get
        Set(ByVal value As Short)
            _nFamille = value
        End Set
    End Property


    Private ReadOnly Property CurrentProduitRow() As AgrifactTracaDataSet.ProduitRow
        Get
            If Me.ProduitBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.ProduitBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ProduitRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal filtre As AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits)
        Me.New()
        Me.Filtre = filtre
    End Sub

    Public Sub New(ByVal nFamille As Short)
        Me.New()
        Me.nFamille = nFamille
    End Sub

#End Region

#Region "Donnnées"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            'Me.ProduitDataGridView.UseWaitCursor = True
            Application.DoEvents()
            LogMessage("DoEvents", TraceEventType.Verbose)
            Dim curId As Decimal = -1
            If Me.ProduitBindingSource.Current IsNot Nothing Then
                curId = Me.CurrentProduitRow.nProduit
            End If
            LogMessage("CurID=" & curId, TraceEventType.Verbose)
            Me.ProduitBindingSource.SuspendBinding()
            LogMessage("SuspendBinding", TraceEventType.Verbose)
            With Me.AgrifactTracaDataSet
                .EnforceConstraints = False
                LogMessage("EnforceConstraints = False", TraceEventType.Verbose)
                .Clear()
                LogMessage("Clear", TraceEventType.Verbose)
                If Me.nFamille < 0 Then
                    Me.FamilleTableAdapter.Fill(.Famille)
                    LogMessage("Fill Familles", TraceEventType.Verbose)
                    Me.ProduitTableAdapter.Fill(.Produit, Me.Filtre, True)
                    LogMessage("Fill Produit", TraceEventType.Verbose)
                Else
                    Me.FamilleTableAdapter.FillBynFamille(.Famille, Me.nFamille)
                    LogMessage("Fill Familles " & nFamille, TraceEventType.Verbose)
                    Me.ProduitTableAdapter.FillByNFamille(.Produit, Me.nFamille, True)
                    LogMessage("Fill Produit famille " & nFamille, TraceEventType.Verbose)
                End If
                .EnforceConstraints = True
                LogMessage("EnforceConstraints = True", TraceEventType.Verbose)
            End With
            Me.ProduitBindingSource.ResumeBinding()
            LogMessage("Resume Binding", TraceEventType.Verbose)
            If curId > -1 Then
                Me.ProduitBindingSource.Position = Me.ProduitBindingSource.Find("nProduit", curId)
            End If
            MajBoutons()
            TbFilter_CheckedChanged(Nothing, Nothing)
            LogMessage("Filter Checked Changed", TraceEventType.Verbose)
        Finally
            'Me.ProduitDataGridView.UseWaitCursor = False
            'Me.UseWaitCursor = False
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.ProduitBindingSource.EndEdit()
        If Me.AgrifactTracaDataSet.HasChanges Then
            Me.ProduitTableAdapter.Update(Me.AgrifactTracaDataSet.Produit)
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.ProduitBindingSource.EndEdit()
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

    Private Function DupliquerProduit(ByVal drProd As AgrifactTracaDataSet.ProduitRow) As Decimal
        Cast(Of AgrifactTracaDataSet.ProduitDataTable)(drProd.Table).InitAutoIncrementSeed(Me.ProduitTableAdapter)

        'Dupliquer la ligne de produit
        Dim drNew As AgrifactTracaDataSet.ProduitRow = Cast(Of AgrifactTracaDataSet.ProduitRow)(CloneRow(drProd))
        '=> Affecter un nouveau CodeProduit
        Dim newCode As String = String.Format("{0} (copie)", drNew.CodeProduit)
        Dim i As Integer = 1
        While drProd.Table.Select(String.Format("CodeProduit='{0}'", newCode)).Length > 0
            i += 1
            newCode = String.Format("{0} (copie {1})", drNew.CodeProduit, i)
        End While
        drNew.CodeProduit = newCode
        'Enregistrer en base
        Me.ProduitTableAdapter.Update(drNew)

        'Dupliquer les lignes de composition
        Me.ProduitTableAdapter.DupliquerComposition(drProd.CodeProduit, drNew.CodeProduit)

        'TODO Dupliquer les contrôles ?
        Return drNew.nProduit
    End Function
#End Region

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ConfigDataTableEvents(Me.AgrifactTracaDataSet.Produit, AddressOf MajBoutons)
        ApplyStyle(Me.ProduitDataGridView)
        ChargerDonnees()
        Select Case Me.Filtre
            Case AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.MatieresPremieres
                Me.Text = "Liste des Matières Premières"
            Case AgrifactTracaDataSetTableAdapters.ProduitTableAdapter.FiltreProduits.ProduitsFinis
                Me.Text = "Liste des Produits Finis"
            Case Else
                Me.Text = "Liste des Produits"
        End Select
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = AgrifactTracaDataSet.HasChanges
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbComposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCompo.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        With New FrCompoProduit(Me.CurrentProduitRow.CodeProduit)
            .Owner = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub TbControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbControles.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        If Not FrValidAdmin.ValidAdmin Then Exit Sub
        With New Controles.FrListeControles
            .CodeProduit = Me.CurrentProduitRow.CodeProduit
            .MatierePremiere = Me.CurrentProduitRow.ProduitAchat
            .Owner = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        Try
            Me.ProduitBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        With New FrFicheProduit()
            .Owner = Me
            .nFamille = Me.nFamille
            .TypeProduit = Me.Filtre
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
        End With
    End Sub

    Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        If TbFilter.Checked Then
            Me.ProduitBindingSource.Filter = "inactif=false"
        Else
            Me.ProduitBindingSource.Filter = ""
        End If
    End Sub

    Private Sub TbDupliquer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDupliquer.Click
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub

        If MsgBox(String.Format("Voulez-vous dupliquer le produit {0} ?", Me.CurrentProduitRow.CodeProduit), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim drProd As AgrifactTracaDataSet.ProduitRow = Me.CurrentProduitRow

            Me.ProduitBindingSource.SuspendBinding()
            Dim newNProd As Decimal = DupliquerProduit(drProd)

            Me.ProduitBindingSource.ResumeBinding()
            Me.ProduitBindingSource.Position = Me.ProduitBindingSource.Find("nProduit", newNProd)
        End If
    End Sub
#End Region

#Region "Grid"
    Private Sub ProduitDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles ProduitDataGridView.DataBindingComplete
        For Each r As DataGridViewRow In ProduitDataGridView.Rows
            If Not r.DataBoundItem Is Nothing Then
                If Cast(Of AgrifactTracaDataSet.ProduitRow)(Cast(Of DataRowView)(r.DataBoundItem).Row).Inactif Then
                    r.DefaultCellStyle.ForeColor = SystemColors.GrayText
                End If
            End If
        Next
    End Sub

    Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitDataGridView.DoubleClick
        If Me.ProduitBindingSource.Current Is Nothing Then Exit Sub
        With New FrFicheProduit(CInt(Me.CurrentProduitRow.nProduit))
            .Owner = Me
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
        End With
    End Sub
#End Region

    Private Sub ProduitBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProduitBindingSource.CurrentChanged
        If ProduitBindingSource.Current Is Nothing Then Exit Sub
        Me.TbCompo.Enabled = Me.CurrentProduitRow.ProduitVente
    End Sub

End Class