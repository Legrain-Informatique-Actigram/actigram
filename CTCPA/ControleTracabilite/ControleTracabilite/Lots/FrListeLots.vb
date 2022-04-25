Namespace Lots
    Public Class FrListeLots

        Private loading As Boolean


#Region "Props"
        Private ReadOnly Property CurrentLotRow() As AgrifactTracaDataSet.LotRow
            Get
                If Me.LotsBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return Cast(Of AgrifactTracaDataSet.LotRow)(Cast(Of DataRowView)(Me.LotsBindingSource.Current).Row)
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub
#End Region

#Region "Donnnées"
        Private Sub ChargerDonnees()
            Try
                loading = True
                Cursor.Current = Cursors.WaitCursor
                Me.LotDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Dim curLot As String = Nothing
                If Me.LotsBindingSource.Current IsNot Nothing Then
                    curLot = Me.CurrentLotRow.nLot
                End If
                Me.LotsBindingSource.SuspendBinding()
                With Me.AgrifactTracaDataSet
                    .EnforceConstraints = False
                    Me.LotTableAdapter.Fill(.Lot)
                    .EnforceConstraints = True
                End With
                Me.LotsBindingSource.ResumeBinding()
                If curLot IsNot Nothing Then
                    Me.LotsBindingSource.Position = Me.LotsBindingSource.Find("nLot", curLot)
                End If
                MajBoutons()
            Finally
                Cursor.Current = Cursors.Default
                Me.LotDataGridView.UseWaitCursor = False
                loading = False
            End Try
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.LotsBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Me.LotTableAdapter.Update(Me.AgrifactTracaDataSet.Lot)
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.LotsBindingSource.EndEdit()
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
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            loading = True
            ConfigDataTableEvents(AgrifactTracaDataSet.Lot, AddressOf MajBoutons)
            ApplyStyle(Me.LotDataGridView)

            ChkFiltreTermine.Checked = True
            Dim demain As Date = Now.Date.AddDays(1)
            dtpFin.MaxDate = demain
            dtpDeb.MaxDate = demain
            dtpFin.Value = demain
            dtpDeb.Value = dtpFin.Value.AddDays(-My.Settings.PeriodeHisto)

            ChargerDonnees()
            loading = False
            FilterChanged(Nothing, Nothing)
        End Sub

        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            Me.TbSave.Enabled = AgrifactTracaDataSet.HasChanges
        End Sub

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
            Me.Close()
        End Sub

        Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
            Enregistrer()
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.LotsBindingSource.Current Is Nothing Then Exit Sub
            Try
                Me.LotsBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            With New FrSaisieLot()
                .Owner = Me
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub

        Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
            Me.SplitContainer1.Panel2Collapsed = Not TbFilter.Checked
        End Sub
#End Region

#Region "Grid"
        Private Sub MouvementDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotDataGridView.DoubleClick
            If Me.LotsBindingSource.Current Is Nothing Then Exit Sub
            With New FrSaisieLot(Me.CurrentLotRow.nLot)
                .Owner = Me
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub
#End Region


#Region "Filtrage"
        Private Sub dtpDeb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles dtpDeb.Validating, dtpFin.Validating
            e.Cancel = dtpDeb.Value > dtpFin.Value
        End Sub

        Private Sub FilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles dtpDeb.ValueChanged, dtpFin.ValueChanged, ChkFiltreTermine.CheckedChanged
            If Not loading Then
                Dim flt As String = ""
                If ChkFiltreTermine.Checked Then
                    flt = "Termine=False AND "
                End If
                flt &= String.Format("DateCreation>='{0:dd/MM/yyyy}' AND DateCreation<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.LotsBindingSource.Filter = flt
            End If
        End Sub
#End Region
    End Class
End Namespace