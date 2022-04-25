Namespace Fabrications
    Public Class FrListeTransfo
        Implements IArgumentable

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

        Public Property Parametre() As String Implements IArgumentable.Arguments
            Get
                Return Me.TypeMouvement.ToString
            End Get
            Set(ByVal value As String)
                Me.TypeMouvement = EnumParse(Of Stocks.GestionStock.TypeMouvement)(value)
            End Set
        End Property

        Private _type As Stocks.GestionStock.TypeMouvement = Stocks.GestionStock.TypeMouvement.Conditionnement
        Public Property TypeMouvement() As Stocks.GestionStock.TypeMouvement
            Get
                Return _type
            End Get
            Set(ByVal value As Stocks.GestionStock.TypeMouvement)
                _type = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub
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
            'TODO : cette ligne de code charge les données dans la table 'AgrifactTracaDataSet.Lot'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            Me.LotTableAdapter.Fill(Me.AgrifactTracaDataSet.Lot)
            SetChildFormIcon(Me)
            loading = True
            ConfigDataTableEvents(AgrifactTracaDataSet.Mouvement, AddressOf MajBoutons)
            ApplyStyle(Me.MouvementDataGridView)

            Select Case Me.TypeMouvement
                Case Stocks.GestionStock.TypeMouvement.Conditionnement
                    Me.TbNewFab.Visible = False
                    Dim demain As Date = Now.Date.AddDays(1)
                    dtpFin.MaxDate = demain
                    dtpDeb.MaxDate = demain
                    dtpFin.Value = demain
                    dtpDeb.Value = dtpFin.Value.AddDays(-My.Settings.PeriodeHisto)
                Case Stocks.GestionStock.TypeMouvement.ModeleFab
                    Me.TbNewFab.Visible = True
                    Me.SplitContainer1.Panel2Collapsed = True
                    dtpFin.Value = dtpFin.MaxDate
                    dtpDeb.Value = dtpDeb.MinDate
                    Me.TbFilter.Visible = False
                    Me.BindingNavigatorSeparator2.Visible = False
                    Me.TbSelfBR.Visible = False
                    Me.ColDate.Visible = False
            End Select

            ChargerDonnees()
            loading = False
            FilterChanged(Nothing, Nothing)
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
                    Me.MouvementTableAdapter.FillByType(.Mouvement, Me.TypeMouvement)
                    .EnforceConstraints = True
                End With
                Me.MouvementBindingSource.ResumeBinding()
                If curId > -1 Then
                    Me.MouvementBindingSource.Position = Me.MouvementBindingSource.Find("nMouvement", curId)
                End If

                'chargement des données de la table Lot
                Me.LotTableAdapter.Fill(Me.AgrifactTracaDataSet.Lot)

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
            Me.LotBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Me.MouvementTableAdapter.Update(Me.AgrifactTracaDataSet.Mouvement)

                'Suppression du lot dans la table Lot
                Me.LotTableAdapter.Update(Me.AgrifactTracaDataSet.Lot)
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
                Dim nLot As String = String.Empty

                If Not (Me.CurrentMvtRow.IsnPieceNull) Then
                    nLot = Replace(Me.CurrentMvtRow.nPiece.ToString(), "'", "''")
                End If

                Me.MouvementBindingSource.RemoveCurrent()

                'Suppression du lot associé
                Using dtaLot As New AgrifactTracaDataSetTableAdapters.LotTableAdapter
                    dtaLot.Delete(nLot)
                End Using
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            With New FrSaisieTransfo()
                .Owner = Me
                .TypeMouvement = Me.TypeMouvement
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub

        Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
            Me.SplitContainer1.Panel2Collapsed = Not TbFilter.Checked
        End Sub

        Private Sub TbSelfBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSelfBR.Click
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            GestionTransfos.ConversionBR(Me.CurrentMvtRow, Me)
        End Sub

        Private Sub TbNewFab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewFab.Click
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            GestionTransfos.ModeleToFab(Me.CurrentMvtRow, Me)
        End Sub
#End Region

#Region "DataGrid"
        Private Sub MouvementDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MouvementDataGridView.DoubleClick
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            With New FrSaisieTransfo(CInt(Me.CurrentMvtRow.nMouvement))
                .TypeMouvement = Me.TypeMouvement
                .Owner = Me
                .NPieceTextBox.Enabled = False
                .DateFactureDateTimePicker.Enabled = False

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
        Handles dtpDeb.ValueChanged, dtpFin.ValueChanged
            If Not loading Then
                Dim flt As String = String.Format("TypeMouvement='{0}' AND ", Me.TypeMouvement)
                flt &= String.Format("DateMouvement>='{0:dd/MM/yyyy}' AND DateMouvement<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.MouvementBindingSource.Filter = flt
            End If
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
        'legrain 06/03/2014
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMajListeLot.Click
            FrSaisieTransfo.CorrectionTableLot()
        End Sub
    End Class
End Namespace