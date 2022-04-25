Namespace Controles
    Public Class FrDetailControle

        Private modif As Boolean
        'TODO 3 Aide a la saisie des expressions

#Region " Props "
        Private _ncontrole As Integer = -1
        Public Property NControle() As Integer
            Get
                Return _ncontrole
            End Get
            Set(ByVal value As Integer)
                _ncontrole = value
            End Set
        End Property


        Private _ordre As Integer
        Public Property Ordre() As Integer
            Get
                Return _ordre
            End Get
            Set(ByVal value As Integer)
                _ordre = value
            End Set
        End Property


        Private _codeProduit As String
        Public Property CodeProduit() As String
            Get
                Return _codeProduit
            End Get
            Set(ByVal value As String)
                _codeProduit = value
            End Set
        End Property


        Public ReadOnly Property CurrentControleRow() As AgrifactTracaDataSet.DefinitionControleRow
            Get
                If Me.DefinitionControleBindingSource.Position < 0 Then Return Nothing
                Return Cast(Of AgrifactTracaDataSet.DefinitionControleRow)(Cast(Of DataRowView)(Me.DefinitionControleBindingSource.Current).Row)
            End Get
        End Property


        Public ReadOnly Property CurrentBaremeRow() As AgrifactTracaDataSet.BaremeRow
            Get
                If Me.BaremesBindingSource.Position < 0 Then Return Nothing
                Return Cast(Of AgrifactTracaDataSet.BaremeRow)(Cast(Of DataRowView)(Me.BaremesBindingSource.Current).Row)
            End Get
        End Property
#End Region

#Region " Ctor "
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal nControle As Integer)
            Me.New()
            Me.NControle = nControle
        End Sub
#End Region

#Region " Données "
        Private Sub ChargerDonnees()
            If Me.NControle < 0 Then
                Me.DefinitionControleBindingSource.AddNew()
                Me.CurrentControleRow.IdControle = 0
                If Me.CodeProduit IsNot Nothing Then
                    Me.CurrentControleRow.CodeProduit = Me.CodeProduit
                    'chopper le premier IdControle dispo pour le Produit en cours
                    Me.CurrentControleRow.IdControle = Me.DefinitionControleTableAdapter.GetNextId(Me.CodeProduit)
                End If

                Me.CurrentControleRow.Ordre = Me.Ordre
            Else
                Me.DefinitionControleBindingSource.SuspendBinding()
                Me.AgrifactTracaDataSet.EnforceConstraints = False
                Me.DefinitionControleTableAdapter.FillByNControle(Me.AgrifactTracaDataSet.DefinitionControle, Me.NControle)
                Me.BaremeTableAdapter.FillByNControle(Me.AgrifactTracaDataSet.Bareme, Me.NControle)
                Me.AgrifactTracaDataSet.EnforceConstraints = True
                Me.DefinitionControleBindingSource.ResumeBinding()
            End If
            MajBoutons()
        End Sub

        Private Function Enregistrer() As Boolean
            If Me.Validate() Then
                Me.DefinitionControleBindingSource.EndEdit()
                If Me.AgrifactTracaDataSet.HasChanges Then
                    Me.DefinitionControleTableAdapter.Update(Me.AgrifactTracaDataSet.DefinitionControle)
                    Me.BaremeTableAdapter.Update(Me.AgrifactTracaDataSet.Bareme)
                    modif = True
                End If
                MajBoutons()
                Return True
            Else
                Return False
            End If
        End Function

        Private Function DemanderEnregistrement() As Boolean
            If Me.Validate() Then
                Me.DefinitionControleBindingSource.EndEdit()
                If Me.AgrifactTracaDataSet.HasChanges Then
                    Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes
                            Return Enregistrer()
                        Case MsgBoxResult.No
                        Case MsgBoxResult.Cancel
                            Return False
                    End Select
                End If
                Return True
            Else
                Return MsgBox("Impossible d'enregistrer les données." & vbCrLf & "Voulez-vous abandonner les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes
            End If
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

            With Me.TypeComboBox
                .BeginUpdate()
                With .Items
                    .Clear()
                    .Add(New ItemControle("Valeur numérique", "NumericUpDown"))
                    .Add(New ItemControle("Texte libre", "TextBox"))
                    .Add(New ItemControle("Liste déroulante", "ComboBox"))
                    .Add(New ItemControle("Choix simple", "RadioButton"))
                    .Add(New ItemControle("Choix multiple", "CheckBox"))
                    .Add(New ItemControle("Date", "DatePicker"))
                    .Add(New ItemControle("Heure", "TimePicker"))
                    .Add(New ItemControle("Intercalaire", "Separator"))
                    .Add(New ItemControle("Valeur calculée", "Expression"))
                End With
                .EndUpdate()
            End With

            ConfigDataTableEvents(Me.AgrifactTracaDataSet.DefinitionControle, AddressOf MajBoutons)
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Bareme, AddressOf MajBoutons)
            ConfigZoomTextbox(Me.LibelleTextBox)
            ApplyStyle(Me.BaremesDataGridView)
            ChargerDonnees()
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            Me.TbEnregistrer.Enabled = Me.AgrifactTracaDataSet.HasChanges
        End Sub
#End Region

#Region "Paint Combobox"
        Private Sub TypeComboBox_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TypeComboBox.DrawItem
            e.DrawBackground()
            If e.Index >= 0 Then
                CType(TypeComboBox.Items(e.Index), ItemControle).Paint(e, My.Resources.IconesControles.ResourceManager)
            End If
            e.DrawFocusRectangle()
        End Sub

        Private Class ItemControle
            Public Type As String = ""
            Public Text As String = ""

            Public Sub New(ByVal Text As String, ByVal Type As String)
                Me.Type = Type
                Me.Text = Text
            End Sub

            Public Sub Paint(ByVal e As System.Windows.Forms.DrawItemEventArgs, ByVal rm As System.Resources.ResourceManager)
                If Type.Length >= 0 Then
                    Dim im As Bitmap = CType(rm.GetObject(Type.ToString), Bitmap)
                    im.MakeTransparent(Color.Magenta)
                    e.Graphics.DrawImage(im, e.Bounds.X, e.Bounds.Y + 1)
                End If
                Using b As New SolidBrush(e.ForeColor)
                    e.Graphics.DrawString(Text, e.Font, b, e.Bounds.X + 18, e.Bounds.Y + 3)
                End Using
            End Sub

            Public Overrides Function ToString() As String
                Return Text
            End Function
        End Class
#End Region

#Region " Toolbar "
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbEnregistrer.Click
            Me.Enregistrer()
        End Sub
#End Region

        Private Sub ControlValidated(ByVal sender As Object, ByVal e As EventArgs) _
        Handles GroupeControleTextBox.Validated, LibelleTextBox.Validated, ValeursDefautTextBox.Validated, ValeursPossiblesTextBox.Validated, TypeLabel2.Validated
            Me.DefinitionControleBindingSource.EndEdit()
        End Sub

        Private Sub TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeComboBox.SelectedIndexChanged
            If TypeComboBox.SelectedItem Is Nothing Then Exit Sub
            If Me.DefinitionControleBindingSource.Position < 0 Then Exit Sub

            If TypeLabel2.Text <> CType(TypeComboBox.SelectedItem, ItemControle).Type Then
                TypeLabel2.Text = CType(TypeComboBox.SelectedItem, ItemControle).Type
            End If
        End Sub

        Private Sub TypeLabel2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeLabel2.TextChanged
            If TypeLabel2.Text.Length = 0 Then Exit Sub
            Dim index As Integer = -1
            For i As Integer = 0 To Me.TypeComboBox.Items.Count - 1
                If CType(Me.TypeComboBox.Items(i), ItemControle).Type = TypeLabel2.Text Then
                    index = i
                    Exit For
                End If
            Next
            Me.TypeComboBox.SelectedIndex = index
        End Sub

        Private Sub DefinitionControleBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DefinitionControleBindingSource.CurrentItemChanged
            ValeursDefautLabel.Text = "Valeur par défaut:"
            ValeursPossiblesLabel.Text = "Valeurs possibles:"
            ValeursDefautTextBox.Enabled = True
            ValeursPossiblesTextBox.Enabled = True

            If Not Me.CurrentControleRow.IsTypeNull Then
                Select Case Me.CurrentControleRow.Type
                    Case "DatePicker", "TimePicker", "TextBox"
                        ValeursPossiblesLabel.Text = ""
                        ValeursPossiblesTextBox.Enabled = False
                    Case "NumericUpDown"
                        ValeursPossiblesLabel.Text = "Nb décimales:"
                    Case "Expression"
                        ValeursPossiblesLabel.Text = "Formule:"
                        ValeursDefautLabel.Text = ""
                        ValeursDefautTextBox.Enabled = False
                    Case "Separator"
                        ValeursPossiblesLabel.Text = ""
                        ValeursDefautLabel.Text = ""
                        ValeursDefautTextBox.Enabled = False
                        ValeursPossiblesTextBox.Enabled = False
                End Select
            End If
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            If Me.DefinitionControleBindingSource.Position < 0 Then Exit Sub
            Using fr As New FrDetailBareme()
                fr.NControle = Me.CurrentControleRow.nControle
                fr.ControleType = Me.CurrentControleRow.Type
                fr.Datasource = Me.AgrifactTracaDataSet.Bareme
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog(Me)
            End Using
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.BaremesBindingSource.Position < 0 Then Exit Sub
            Try
                Me.BaremesBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BaremesDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BaremesDataGridView.CellDoubleClick
            If Me.DefinitionControleBindingSource.Position < 0 Then Exit Sub
            If Me.BaremesBindingSource.Position < 0 Then Exit Sub
            Using fr As New FrDetailBareme(Me.CurrentBaremeRow.nBareme)
                fr.ControleType = Me.CurrentControleRow.Type
                fr.Datasource = Me.AgrifactTracaDataSet.Bareme
                fr.StartPosition = FormStartPosition.CenterParent
                fr.ShowDialog(Me)
            End Using
        End Sub

    End Class
End Namespace