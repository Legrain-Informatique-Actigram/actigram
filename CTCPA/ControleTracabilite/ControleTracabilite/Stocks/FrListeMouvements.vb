Namespace Stocks
    Public Class FrListeMouvements
        '        Implements IArgumentable
        Private loading As Boolean


#Region "Props"
        Private ReadOnly Property CurrentMvtRow() As AgrifactTracaDataSet.MouvementRow
            Get
                If Me.MouvementBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.MouvementBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.MouvementRow)
                End If
            End Get
        End Property

        'Public Property Parametre() As String Implements IArgumentable.Arguments
        '    Get
        '        Return Me.TypeMouvement.ToString
        '    End Get
        '    Set(ByVal value As String)
        '        If value IsNot Nothing Then
        '            Me.TypeMouvement = EnumParse(Of AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement)(value)
        '        End If
        '    End Set
        'End Property

        'Private _type As AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement = AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement.None
        'Public Property TypeMouvement() As AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement
        '    Get
        '        Return _type
        '    End Get
        '    Set(ByVal value As AgrifactTracaDataSetTableAdapters.MouvementTableAdapter.TypeMouvement)
        '        _type = value
        '    End Set
        'End Property
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
                Me.MouvementDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Dim curId As Decimal = -1
                If Me.MouvementBindingSource.Current IsNot Nothing Then
                    curId = Me.CurrentMvtRow.nMouvement
                End If

                Me.MouvementBindingSource.SuspendBinding()
                With Me.AgrifactTracaDataSet
                    .EnforceConstraints = False
                    Me.ListeChoixTableAdapter.FillByNomChoix(.ListeChoix, AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeMouvement)
                    Me.MouvementTableAdapter.Fill(.Mouvement)
                    .ListeChoix.AddListeChoixRow(AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeMouvement.ToString, 0, "")
                    .ListeChoix.AcceptChanges()
                    .EnforceConstraints = True
                End With
                Me.MouvementBindingSource.ResumeBinding()

                If curId > -1 Then
                    Me.MouvementBindingSource.Position = Me.MouvementBindingSource.Find("nMouvement", curId)
                End If
                MajBoutons()
            Finally
                Cursor.Current = Cursors.Default
                Me.MouvementDataGridView.UseWaitCursor = False
                loading = False
            End Try
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.MouvementBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Me.MouvementTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement)
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.MouvementBindingSource.EndEdit()
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
            ConfigDataTableEvents(AgrifactTracaDataSet.Mouvement, AddressOf MajBoutons)
            ApplyStyle(Me.MouvementDataGridView)

            Dim demain As Date = Now.Date.AddDays(1)
            dtpFin.MaxDate = demain
            dtpDeb.MaxDate = demain
            dtpFin.Value = demain
            dtpDeb.Value = dtpFin.Value.AddDays(-My.Settings.PeriodeHisto)

            ChargerDonnees()
            Me.CbTypeMvt.SelectedIndex = 0
            loading = False
            FilterChanged(Nothing, Nothing)
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
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
            Me.Close()
        End Sub

        Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
            Enregistrer()
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            Try
                Me.MouvementBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            With New FrSaisieMouvement()
                .Owner = Me
                If CbTypeMvt.SelectedIndex >= 0 AndAlso CStr(CbTypeMvt.SelectedValue).Length > 0 Then
                    .TypeMouvement = EnumParse(Of Stocks.GestionStock.TypeMouvement)(CStr(CbTypeMvt.SelectedValue))
                End If
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
        Private Sub MouvementDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MouvementDataGridView.DoubleClick
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            With New FrSaisieMouvement(CInt(Me.CurrentMvtRow.nMouvement))
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
        Handles dtpDeb.ValueChanged, dtpFin.ValueChanged, CbTypeMvt.SelectedIndexChanged
            If Not loading Then
                Dim flt As String = ""
                If CbTypeMvt.SelectedIndex >= 0 AndAlso Convert.ToString(CbTypeMvt.SelectedValue).Length > 0 Then
                    flt = String.Format("TypeMouvement='{0}' AND ", CbTypeMvt.SelectedValue)
                Else
                    flt = "TypeMouvement NOT IN ('Fabrication','Conditionnement','ModeleFab') AND "
                End If
                flt &= String.Format("DateMouvement>='{0:dd/MM/yyyy}' AND DateMouvement<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.MouvementBindingSource.Filter = flt
            End If
        End Sub
#End Region

    End Class
End Namespace