Namespace Controles
    Public Class FrListeControles

#Region " Props "
        Private _CodeProduit As String
        Public Property CodeProduit() As String
            Get
                Return _CodeProduit
            End Get
            Set(ByVal value As String)
                _CodeProduit = value
            End Set
        End Property

        Private _matPrem As Boolean
        Public Property MatierePremiere() As Boolean
            Get
                Return _matPrem
            End Get
            Set(ByVal value As Boolean)
                _matPrem = value
            End Set
        End Property

        Private _prodFini As Boolean
        Public Property ProduitFini() As Boolean
            Get
                Return _prodFini
            End Get
            Set(ByVal value As Boolean)
                _prodFini = value
            End Set
        End Property

        Private ReadOnly Property CurrentControle() As DefinitionControle
            Get
                Return CType(Me.DefinitionControleBindingSource.Current, DefinitionControle)
            End Get
        End Property
#End Region

#Region " Ctor "
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal codeProduit As String, ByVal matPrem As Boolean, ByVal prodFini As Boolean)
            Me.New()
            Me.CodeProduit = codeProduit
            Me.MatierePremiere = matPrem
            Me.ProduitFini = prodFini
        End Sub
#End Region

#Region " Données "
        Private Sub ChargerDonnees()
            'Charger les contrôles à partir du code produit
            If Me.CodeProduit IsNot Nothing Then
                Dim controles As List(Of DefinitionControle) = DefinitionControle.Charger(Me.CodeProduit, True)
                If controles.Count = 0 Then
                    'Lancer l'assistant de configuration du produit
                    'TODO 1 Et dans le cas ou un produit est à la fois MP et PF ?!!!
                    Using fr As New FrAssistantConfigurationProduit(Me.CodeProduit, Me.MatierePremiere, Me.ProduitFini)
                        If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                            controles = DefinitionControle.Charger(Me.CodeProduit, False)
                        End If
                    End Using
                End If
                Me.DefinitionControleBindingSource.DataSource = controles
            Else
                Me.DefinitionControleBindingSource.DataSource = New List(Of DefinitionControle)
            End If
        End Sub
#End Region

#Region "Page"
        Private Sub FrListeControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ApplyStyle(Me.DefinitionControleDataGridView, True)
            ChargerDonnees()
        End Sub
#End Region

#Region "Boutons"
        Private Sub TbApercu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbApercu.Click
            If Me.DefinitionControleBindingSource.DataSource Is Nothing Then Exit Sub
            With New FrApercuControles(CType(Me.DefinitionControleBindingSource.DataSource, List(Of DefinitionControle)))
                .Owner = Me
                .ShowDialog()
            End With
        End Sub

        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.DefinitionControleBindingSource.Current Is Nothing Then Exit Sub
            Try
                VerifSuppr()
                DefinitionControle.Delete(Me.CurrentControle.nControle)
                ChargerDonnees()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            Using fr As New FrDetailControle()
                With fr
                    .CodeProduit = Me.CodeProduit
                    .Ordre = Me.DefinitionControleBindingSource.Count
                    .Owner = Me
                    .StartPosition = FormStartPosition.CenterParent
                    If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                        ChargerDonnees()
                    End If
                End With
            End Using
        End Sub

        Private Sub DataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DefinitionControleDataGridView.CellDoubleClick
            If e.RowIndex < 0 Then Exit Sub
            If Me.CurrentControle IsNot Nothing Then
                Using fr As New FrDetailControle(Me.CurrentControle.nControle)
                    With fr
                        .Owner = Me
                        .StartPosition = FormStartPosition.CenterParent
                        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                            ChargerDonnees()
                        End If
                    End With
                End Using
            End If
        End Sub

        Private Sub MoveDownToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveDownToolStripButton.Click
            With Me.DefinitionControleBindingSource
                If .Position = -1 Then Exit Sub
                If .Position >= .Count - 1 Then Exit Sub
            End With

            Dim nextControle As DefinitionControle = Cast(Of DefinitionControle)(Me.DefinitionControleBindingSource.Item(Me.DefinitionControleBindingSource.Position + 1))
            DefinitionControle.EchangeOrdre(Me.CurrentControle, nextControle)
            ResetSort()
        End Sub

        Private Sub MoveUpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveUpToolStripButton.Click
            If Me.DefinitionControleBindingSource.Position <= 0 Then Exit Sub

            Dim prevControle As DefinitionControle = Cast(Of DefinitionControle)(Me.DefinitionControleBindingSource.Item(Me.DefinitionControleBindingSource.Position - 1))
            DefinitionControle.EchangeOrdre(Me.CurrentControle, prevControle)
            ResetSort()
        End Sub
#End Region

#Region "Affichage des icones"
        Private Sub DataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DefinitionControleDataGridView.DataBindingComplete
            If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
                For Each r As DataGridViewRow In DefinitionControleDataGridView.Rows
                    DeterminerIcone(r)
                Next
            ElseIf e.ListChangedType = System.ComponentModel.ListChangedType.ItemChanged Then
                DeterminerIcone(DefinitionControleDataGridView.CurrentRow)
            End If
        End Sub

        Private Sub DeterminerIcone(ByVal def As DefinitionControle)
            For Each r As DataGridViewRow In DefinitionControleDataGridView.Rows
                If r.DataBoundItem Is def Then
                    DeterminerIcone(r, def)
                    Exit For
                End If
            Next
        End Sub

        Private Sub DeterminerIcone(ByVal r As DataGridViewRow)
            Dim def As DefinitionControle = CType(r.DataBoundItem, DefinitionControle)
            DeterminerIcone(r, def)
        End Sub

        Private Sub DeterminerIcone(ByVal r As DataGridViewRow, ByVal def As DefinitionControle)
            Dim c As DataGridViewImageCell = CType(r.Cells(TypeColumn.Name), DataGridViewImageCell)
            If def Is Nothing OrElse def.Type Is Nothing Then
                c.Value = Nothing
            Else
                Try
                    c.Value = My.Resources.IconesControles.ResourceManager.GetObject(def.Type)
                    CType(c.Value, Bitmap).MakeTransparent(Color.Fuchsia)
                Catch ex As Exception
                    c.Value = Nothing
                End Try
            End If
        End Sub

        Private Sub DefinitionControleDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DefinitionControleDataGridView.DataError
            e.ThrowException = False
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub ResetSort()
            With Me.DefinitionControleBindingSource
                If .DataSource Is Nothing Then Exit Sub
                Dim curId As Integer = -1
                If .Position >= 0 Then curId = Me.CurrentControle.IdControle
                .SuspendBinding()
                Cast(Of List(Of DefinitionControle))(.DataSource).Sort(AddressOf DefinitionControle.CompareByOrdre)
                .ResumeBinding()
                If curId >= 0 Then .Position = FindIndex(curId)
                .ResetBindings(False)
            End With
        End Sub

        Private Function FindIndex(ByVal id As Integer) As Integer
            For i As Integer = 0 To Me.DefinitionControleBindingSource.Count - 1
                If Cast(Of DefinitionControle)(Me.DefinitionControleBindingSource.Item(i)).IdControle = id Then
                    Return i
                End If
            Next
            Return -1
        End Function
#End Region

    End Class
End Namespace