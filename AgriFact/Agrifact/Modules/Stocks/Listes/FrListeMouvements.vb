Namespace Stocks
    Public Class FrListeMouvements
        Private loading As Boolean
        Private _customFilter As Boolean

#Region "Props"
        Private ReadOnly Property CurrentMvtRow() As StocksDataSet.MouvementRow
            Get
                If Me.MouvementBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.MouvementBindingSource.Current, DataRowView).Row, StocksDataSet.MouvementRow)
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
        Private Sub CreerMenusNouveau()
            Me.BindingNavigatorAddNewItem.DropDownItems.Clear()

            For Each dr As StocksDataSet.ListeChoixRow In Me.dsListeChoix.ListeChoix
                If dr.Valeur.Length > 0 Then
                    Dim mi As New ToolStripMenuItem
                    With mi
                        '.Text = "Nouveau " & dr.Valeur
                        .Text = dr.Valeur
                        .Tag = dr.Valeur
                        AddHandler .Click, AddressOf BindingNavigatorAddNewItem_Click
                    End With
                    Me.BindingNavigatorAddNewItem.DropDownItems.Add(mi)
                End If
            Next
        End Sub

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
                With Me.StocksDataSet
                    .EnforceConstraints = False
                    Me.MouvementTableAdapter.Fill(.Mouvement)
                    .EnforceConstraints = True
                End With
                With Me.dsListeChoix
                    .EnforceConstraints = False
                    Me.ListeChoixTableAdapter.FillByNomChoix(.ListeChoix, StocksDataSetTableAdapters.ListeChoixTA.NomsChoix.ListeTypeMouvement)
                    .ListeChoix.AddListeChoixRow(StocksDataSetTableAdapters.ListeChoixTA.NomsChoix.ListeTypeMouvement.ToString, 0, "")
                    .ListeChoix.AcceptChanges()
                    .EnforceConstraints = True
                    CreerMenusNouveau()
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
            If Me.StocksDataSet.HasChanges Then
                Me.MouvementTableAdapter.DeleteMouvements(Me.StocksDataSet.Mouvement)
                'Me.MouvementTableAdapter.Update(Me.StocksDataSet.Mouvement)
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.MouvementBindingSource.EndEdit()
            If Me.StocksDataSet.HasChanges Then
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

#Region "Form"
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
            ApplyStyle(Me.MouvementDataGridView)

            Dim demain As Date = Now.Date.AddDays(1)
            dtpFin.MaxDate = demain
            dtpDeb.MaxDate = demain
            dtpFin.Value = demain
            dtpDeb.Value = dtpFin.Value.AddDays(-60)

            ChargerDonnees()
            ConfigDataTableEvents(StocksDataSet.Mouvement, AddressOf MajBoutons)
            Me.CbTypeMvt.SelectedIndex = 0
            loading = False
            FilterChanged(Nothing, Nothing)
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
            Me.Close()
        End Sub

        Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
            Enregistrer()
        End Sub

        Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
            ImprimerListe()
        End Sub

        Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
            If Me.MouvementBindingSource.Position >= 0 Then
                Me.MouvementBindingSource.EndEdit()
            End If
            GestionControles.FillTablesConfig(Me.StocksDataSet)
            Dim myFrRecherche As New GRC.FrRecherche(Me.StocksDataSet, "Mouvement")
            AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
            myFrRecherche.Show(Me)
        End Sub

        Private Sub LancerLaRecherche(ByVal strCritere As String)
            _customFilter = True
            Me.MouvementBindingSource.Filter = strCritere
            TbFilter.Checked = False
        End Sub

        Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            Try
                Me.MouvementBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.ButtonClick
            Dim t As Stocks.TypeMouvement = TypeMouvement.None
            If CType(sender, ToolStripItem).Tag IsNot Nothing Then
                t = EnumParse(Of Stocks.GestionStock.TypeMouvement)(CStr(CType(sender, ToolStripItem).Tag))
            ElseIf CbTypeMvt.SelectedIndex >= 0 AndAlso CStr(CbTypeMvt.SelectedValue).Length > 0 Then
                t = EnumParse(Of Stocks.GestionStock.TypeMouvement)(CStr(CbTypeMvt.SelectedValue))
            End If
            If t = TypeMouvement.None Then
                MsgBox("Choisissez un type de mouvement", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            With New FrMouvement()
                .TypeMouvement = t
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    ChargerDonnees()
                End If
            End With
        End Sub

        Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
            Me.SplitContainer1.Panel2Collapsed = Not TbFilter.Checked
            If TbFilter.Checked Then
                _customFilter = False
                FilterChanged(Nothing, EventArgs.Empty)
            End If
        End Sub
#End Region

#Region "Grid"
        Private Sub MouvementDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MouvementDataGridView.DoubleClick
            If Me.MouvementBindingSource.Current Is Nothing Then Exit Sub
            With New FrMouvement(CInt(Me.CurrentMvtRow.nMouvement))
                AddHandler .FormClosed, AddressOf ChildFormClosed
                If Me.IsMdiChild Then
                    .MdiParent = Me.MdiParent
                Else
                    .Owner = Me
                End If
                .Show()
            End With
        End Sub

        Private Sub ChildFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            If CType(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
                ChargerDonnees()
            End If
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
                End If
                flt &= String.Format("DateMouvement>='{0:dd/MM/yyyy}' AND DateMouvement<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.MouvementBindingSource.Filter = flt
            End If
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub ImprimerListe()
            Dim myDs As DataSet = Me.StocksDataSet.Clone
            myDs.EnforceConstraints = False
            myDs.Merge(Me.StocksDataSet.Mouvement.Select(Me.MouvementBindingSource.Filter, Me.MouvementBindingSource.Sort))
            Using s As New SqlProxy
                For Each dr As DataRow In myDs.Tables("Mouvement").Rows
                    s.Fill(myDs, SqlProxy.FormatSql("SELECT * FROM Mouvement_detail WHERE nMouvement={0}", dr("nMouvement")), "Mouvement_detail", False)
                Next
            End Using
            Try
                Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeMouvement.rpt")
                fr.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            Me.TbSave.Enabled = StocksDataSet.HasChanges
        End Sub
#End Region

    End Class
End Namespace