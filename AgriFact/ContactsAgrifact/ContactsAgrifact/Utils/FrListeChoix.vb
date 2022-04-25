Public Class FrListeChoix

#Region "Props"
    Private _nomChoix As DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix
    Public Property NomChoix() As DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix
        Get
            Return _nomChoix
        End Get
        Set(ByVal value As DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix)
            _nomChoix = value
        End Set
    End Property

    Private ReadOnly Property CurrentChoixRow() As DsAgrifact.ListeChoixRow
        Get
            If Me.ListeChoixBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.ListeChoixBindingSource.Current, DataRowView).Row, DsAgrifact.ListeChoixRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal type As DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix)
        Me.New()
        Me.NomChoix = type
    End Sub
#End Region

#Region "Donnnées"
    Private modif As Boolean
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            With Me.AgrifactTracaDataSet
                .EnforceConstraints = False
                .Clear()
                Me.ListeChoixTableAdapter.FillByNomChoix(Me.AgrifactTracaDataSet.ListeChoix, Me.NomChoix)
                With Me.AgrifactTracaDataSet.ListeChoix
                    .NomChoixColumn.DefaultValue = Me.NomChoix.ToString
                    Dim maxOrdre As Object = .Compute("max(nOrdreValeur)", "")
                    If IsDBNull(maxOrdre) Then
                        maxOrdre = 0
                    End If
                    With .nOrdreValeurColumn
                        .AutoIncrement = True
                        .AutoIncrementSeed = CInt(maxOrdre) + 1
                        .AutoIncrementStep = 1
                    End With
                End With
                .EnforceConstraints = True
            End With
            modif = False
        Finally
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub


    Private Sub Enregistrer()
        Me.Validate()
        Me.ListeChoixBindingSource.EndEdit()
        If Me.AgrifactTracaDataSet.HasChanges Then
            Me.ListeChoixTableAdapter.Update(Me.AgrifactTracaDataSet.ListeChoix)
            modif = True
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.ListeChoixBindingSource.EndEdit()
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
        ApplyStyle(Me.ListeChoixDataGridView, False)
        ChargerDonnees()
        ConfigDataTableEvents(Me.AgrifactTracaDataSet.ListeChoix, AddressOf MajBoutons)
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        tbSave.Enabled = Me.AgrifactTracaDataSet.HasChanges
    End Sub

    Private Sub ChangeOrdre(ByVal incr As Integer)
        'Test aux limites
        If Me.ListeChoixBindingSource.Position = 0 AndAlso incr < 0 Then Exit Sub
        If Me.ListeChoixBindingSource.Position = Me.ListeChoixBindingSource.Count - 1 AndAlso incr > 0 Then Exit Sub

        Dim switchRow As DsAgrifact.ListeChoixRow = Cast(Of DsAgrifact.ListeChoixRow)(Cast(Of DataRowView)(Me.ListeChoixBindingSource.Item(Me.ListeChoixBindingSource.Position + incr)).Row)
        Dim oldValeur As Object = Me.CurrentChoixRow("Valeur")
        Me.CurrentChoixRow("Valeur") = switchRow("Valeur")
        switchRow("Valeur") = oldValeur
        Me.ListeChoixBindingSource.Position += incr
        Me.ListeChoixDataGridView.Refresh()
    End Sub

    Private Sub TbOrdrePlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOrdrePlus.Click
        ChangeOrdre(1)
    End Sub

    Private Sub TbOrdreMoins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOrdreMoins.Click
        ChangeOrdre(-1)
    End Sub
End Class