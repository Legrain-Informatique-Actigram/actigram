Namespace Controles
    Public Class FrDetailBareme

        Private modif As Boolean

#Region " Props "

        Private _controleType As String
        Public Property ControleType() As String
            Get
                Return _controleType
            End Get
            Set(ByVal value As String)
                _controleType = value
            End Set
        End Property


        Private _nbareme As Integer = -1
        Public Property NBareme() As Integer
            Get
                Return _nbareme
            End Get
            Set(ByVal value As Integer)
                _nbareme = value
            End Set
        End Property


        Private _nControle As Integer = -1
        Public Property NControle() As Integer
            Get
                Return _nControle
            End Get
            Set(ByVal value As Integer)
                _nControle = value
            End Set
        End Property


        Private _datasource As AgrifactTracaDataSet.BaremeDataTable
        Public Property Datasource() As AgrifactTracaDataSet.BaremeDataTable
            Get
                Return _datasource
            End Get
            Set(ByVal value As AgrifactTracaDataSet.BaremeDataTable)
                _datasource = value
            End Set
        End Property


        Public ReadOnly Property CurrentBaremeRow() As AgrifactTracaDataSet.BaremeRow
            Get
                If Me.BaremeBindingSource.Position < 0 Then Return Nothing
                Return Cast(Of AgrifactTracaDataSet.BaremeRow)(Cast(Of DataRowView)(Me.BaremeBindingSource.Current).Row)
            End Get
        End Property
#End Region

#Region " Ctor "
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal nBareme As Integer)
            Me.New()
            Me.NBareme = nBareme
        End Sub
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
            If Me.Datasource Is Nothing Then
                ConfigDataTableEvents(Me.AgrifactTracaDataSet.Bareme, AddressOf MajBoutons)
            Else
                ConfigDataTableEvents(Me.Datasource, AddressOf MajBoutons)
            End If
            ChargerDonnees()
        End Sub
#End Region

#Region " Données "
        Private Function HasChanges() As Boolean
            Dim res As Boolean
            If Me.Datasource Is Nothing Then
                res = Me.AgrifactTracaDataSet.HasChanges
            Else
                res = Me.Datasource.DataSet.HasChanges
            End If
            Return res
        End Function

        Private Sub ChargerDonnees()
            If Me.Datasource IsNot Nothing Then
                Me.BaremeBindingSource.DataSource = Me.Datasource
            ElseIf Me.NBareme >= 0 Then
                Me.BaremeTableAdapter.FillByNBareme(Me.AgrifactTracaDataSet.Bareme, Me.NBareme)
            End If

            If Me.NBareme < 0 Then
                Me.BaremeBindingSource.AddNew()
                If Me.NControle >= 0 Then
                    Me.CurrentBaremeRow.nControle = Me.NControle
                End If
            Else
                Me.BaremeBindingSource.Position = Me.BaremeBindingSource.Find("nBareme", Me.NBareme)
            End If

            MajBoutons()
        End Sub

        Private Function Enregistrer() As Boolean
            If Me.Validate() Then
                Me.BaremeBindingSource.EndEdit()
                If Me.HasChanges Then
                    If Me.Datasource Is Nothing Then
                        If Not Me.CurrentBaremeRow.IsCheminDocNull Then
                            If Me.CurrentBaremeRow.CheminDoc.StartsWith(My.Settings.AbsoluteRepPdf) Then
                                Me.CurrentBaremeRow.CheminDoc = Me.CurrentBaremeRow.CheminDoc.Replace(My.Settings.AbsoluteRepPdf, "")
                            End If
                        End If
                        Me.BaremeTableAdapter.Update(Me.AgrifactTracaDataSet.Bareme)
                        modif = True
                    Else
                        modif = True
                    End If
                End If
                MajBoutons()
                Return True
            Else
                Return False
            End If
        End Function

        Private Function DemanderEnregistrement() As Boolean
            If Me.Validate() Then
                Me.BaremeBindingSource.EndEdit()
                If Me.HasChanges Then
                    Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes
                            Return Enregistrer()
                        Case MsgBoxResult.No
                            If Me.Datasource IsNot Nothing Then
                                Me.CurrentBaremeRow.RejectChanges()
                            End If
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

#Region "Méthodes diverses"
        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            Me.TbEnregistrer.Enabled = Me.HasChanges
        End Sub
#End Region

#Region " Toolbar "
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
            Me.Close()
        End Sub

        Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbEnregistrer.Click
            Me.Enregistrer()
        End Sub
#End Region

#Region "Boutons"
        Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
            With OpenFileDialog
                .InitialDirectory = My.Settings.AbsoluteRepPdf
                .Filter = "Documents PDF (*.pdf)|*.pdf|Documents Word (*.doc;*.docx)|*.doc;*.docx|Tous les fichiers|*.*"
                .FilterIndex = 0
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    CheminDocTextBox.Text = .FileName
                End If
            End With
        End Sub
#End Region

        Private Sub ControlValidated(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ExpressionTextBox.Validated, ResultatConformiteCheckBox.CheckedChanged, CheminDocTextBox.Validated, ActionCorrectiveTextBox.Validated
            Me.BaremeBindingSource.EndEdit()
        End Sub

        Private Sub ExpressionTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ExpressionTextBox.Validating
            If ExpressionTextBox.Text.Trim.Length = 0 Then Exit Sub
            Dim valeurTest As String = "Test"
            If Me.ControleType IsNot Nothing Then
                Select Case Me.ControleType
                    Case "DatePicker", "TimePicker" : valeurTest = "01/01/2000 11:05:00"
                    Case "TextBox", "ComboBox", "CheckBox", "RadioButton" : valeurTest = "Test"
                    Case "Expression", "NumericUpDown" : valeurTest = "1.5"
                    Case "Separator" : valeurTest = ""
                End Select
            End If
            Try
                Dim b As New Bareme()
                b.EvaluerResultat(ExpressionTextBox.Text.Trim, valeurTest)
            Catch ex As Exception
                LogMessage(String.Format("Test de l'expression '{0}' avec la valeur '{1}'", ExpressionTextBox.Text.Trim, valeurTest))
                LogException(ex)
                MsgBox("L'expression est incorrecte : " & ex.Message)
                e.Cancel = True
            End Try
        End Sub

    End Class
End Namespace