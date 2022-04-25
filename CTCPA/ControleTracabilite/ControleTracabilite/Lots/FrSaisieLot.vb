Namespace Lots
    Public Class FrSaisieLot

#Region "Props"
        Private modif As Boolean

        Private _nLot As String
        Public Property NLot() As String
            Get
                Return _nLot
            End Get
            Set(ByVal value As String)
                _nLot = value
            End Set
        End Property

        Private ReadOnly Property CurrentLotRow() As AgrifactTracaDataSet.LotRow
            Get
                If Me.LotBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return Cast(Of AgrifactTracaDataSet.LotRow)(Cast(Of DataRowView)(Me.LotBindingSource.Current).Row)
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal Nlot As String)
            Me.New()
            Me.NLot = Nlot
        End Sub
#End Region

#Region "Données"
        Private Sub ChargerDonnees()
            Me.FamilleTableAdapter.Fill(Me.AgrifactTracaDataSet.Famille)
            If Me.NLot IsNot Nothing Then
                Me.LotTableAdapter.FillByNLot(Me.AgrifactTracaDataSet.Lot, Me.NLot)
            Else
                Me.LotBindingSource.AddNew()
                Me.DateCreationDateTimePicker.Value = Now.Date
                Me.LotBindingSource.ResetCurrentItem()
            End If
            MajBoutons()
        End Sub

        Private Function Enregistrer() As Boolean
            If Me.Validate() Then
                Me.LotBindingSource.EndEdit()
                If Me.AgrifactTracaDataSet.HasChanges Then
                    Me.LotTableAdapter.Update(Me.AgrifactTracaDataSet.Lot)
                    modif = True
                End If
                MajBoutons()
                Return True
            Else
                Dim strErrs As String = GetErrors()
                Dim msg As String = ""
                If strErrs.Length > 0 Then
                    msg = String.Format("Vous devez corriger les erreurs suivantes avant de pouvoir enregistrer :" & vbCrLf & "{0}", strErrs)
                Else
                    msg = "Vous ne pouvez pas enregistrer les données tant que des erreurs sont présentes."
                End If
                MsgBox(msg, MsgBoxStyle.Exclamation)
                Return False
            End If
        End Function

        Private Function DemanderEnregistrement() As Boolean
            If Me.Validate() Then
                Me.LotBindingSource.EndEdit()
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
            ConfigZoomTextbox(ObservationTextBox)
            ChargerDonnees()
            ConfigDataTableEvents(Me.AgrifactTracaDataSet.Lot, AddressOf MajBoutons)
        End Sub

#Region "Validation"
        Private Function GetErrors() As String
            Return Utils.GetErrors(Me, ErrorProvider)
        End Function

        Private Overloads Function Validate() As Boolean
            If MyBase.Validate Then
                Return Not ControlHasErrors(Me, ErrorProvider)
            Else
                Return False
            End If
        End Function

        Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NLotTextBox.Validated, DateCreationDateTimePicker.ValueChanged, Famille1ComboBox.SelectedIndexChanged, ObservationTextBox.Validated, TermineCheckBox.CheckedChanged
            Me.Validate()
            LotBindingSource.EndEdit()
            MajBoutons()
        End Sub

        Private Sub NLotTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NLotTextBox.Validating
            ErrorProvider.SetError(NLotTextBox, "")
            If NLotTextBox.Text.Trim.Length = 0 Then
                ErrorProvider.SetError(NLotTextBox, "Le n° de lot doit être renseigné")
            Else
                If CType(Me.LotBindingSource.Current, DataRowView).IsNew Then
                    If LotTableAdapter.NLotExists(NLotTextBox.Text.Trim).GetValueOrDefault() Then
                        ErrorProvider.SetError(NLotTextBox, "Ce lot existe déjà")
                    End If
                End If
            End If
        End Sub
#End Region

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
#End Region
    End Class
End Namespace