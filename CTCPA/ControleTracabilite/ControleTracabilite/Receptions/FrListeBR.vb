Namespace Receptions
    Public Class FrListeBR

        Private loading As Boolean

        'TODO Z Trouver les BR par produit ? Par lot ?

#Region "Props"

        Private _nFour As Integer = -1
        Public Property nFournisseur() As Integer
            Get
                Return _nFour
            End Get
            Set(ByVal value As Integer)
                _nFour = value
            End Set
        End Property


        Private ReadOnly Property CurrentBRRow() As AgrifactTracaDataSet.ABonReceptionRow
            Get
                If Me.BRBindingSource.Current Is Nothing Then
                    Return Nothing
                Else
                    Return DirectCast(DirectCast(Me.BRBindingSource.Current, DataRowView).Row, AgrifactTracaDataSet.ABonReceptionRow)
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal nFournisseur As Integer)
            Me.New()
            Me.nFournisseur = nFournisseur
        End Sub
#End Region

#Region "Donnnées"
        Private Sub ChargerDonnees()            
            Try
                loading = True
                Cursor.Current = Cursors.WaitCursor
                Me.BRDataGridView.UseWaitCursor = True
                Application.DoEvents()
                Dim curId As Decimal = -1
                If Me.BRBindingSource.Current IsNot Nothing Then
                    curId = Me.CurrentBRRow.nDevis
                End If
                Me.BRBindingSource.SuspendBinding()
                With Me.AgrifactTracaDataSet
                    .EnforceConstraints = False
                    If Me.nFournisseur < 0 Then
                        Me.EntrepriseTableAdapter.FillFournisseurs(.Entreprise, False)
                        Me.ABonReceptionTableAdapter.Fill(.ABonReception)
                        Me.CbFournisseur.SelectedItem = Nothing
                    Else
                        Me.EntrepriseTableAdapter.FillByNEnt(.Entreprise, Me.nFournisseur)
                        Me.ABonReceptionTableAdapter.FillByNClient(.ABonReception, Me.nFournisseur)
                        ChkFourn.Enabled = False
                        CbFournisseur.SelectedIndex = 0
                    End If
                    .EnforceConstraints = True
                End With
                Me.BRBindingSource.ResumeBinding()                
                If curId > -1 Then
                    Me.BRBindingSource.Position = Me.BRBindingSource.Find("nDevis", curId)
                End If
                MajBoutons()
            Finally
                Cursor.Current = Cursors.Default
                Me.BRDataGridView.UseWaitCursor = False
                loading = False
            End Try
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.BRBindingSource.EndEdit()
            If Me.AgrifactTracaDataSet.HasChanges Then
                Me.ABonReceptionTableAdapter.Update(Me.AgrifactTracaDataSet.ABonReception)
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.BRBindingSource.EndEdit()
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
            ConfigDataTableEvents(AgrifactTracaDataSet.ABonReception, AddressOf MajBoutons)
            ApplyStyle(Me.BRDataGridView)

            ChkFourn.Checked = False
            CbFournisseur.Enabled = False

            Dim demain As Date = Now.Date.AddDays(1)
            dtpFin.MaxDate = demain
            dtpDeb.MaxDate = demain
            dtpFin.Value = demain
            dtpDeb.Value = dtpFin.Value.AddDays(-My.Settings.PeriodeHisto)

            ChargerDonnees()
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
            If Me.BRBindingSource.Current Is Nothing Then Exit Sub
            Try
                Me.BRBindingSource.RemoveCurrent()
            Catch ex As UserCancelledException
            End Try
        End Sub

        Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
            With New FrSaisieBR()
                .Owner = Me
                If Me.nFournisseur >= 0 Then
                    .NFournisseur = Me.nFournisseur
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
        Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRDataGridView.DoubleClick
            If Me.BRBindingSource.Current Is Nothing Then Exit Sub
            With New FrSaisieBR(CInt(Me.CurrentBRRow.nDevis))
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
        Handles CbFournisseur.SelectedIndexChanged, dtpDeb.ValueChanged, dtpFin.ValueChanged, ChkFiltreTermine.CheckedChanged
            If Not loading Then
                Dim flt As String = ""
                If Not ChkFiltreTermine.Checked Then
                    flt &= "Termine=False AND "
                End If
                If ChkFourn.Checked And CbFournisseur.SelectedItem IsNot Nothing Then
                    flt &= String.Format("nClient={0} AND ", CbFournisseur.SelectedValue)
                End If
                flt &= String.Format("DateFacture>='{0:dd/MM/yyyy}' AND DateFacture<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
                Me.BRBindingSource.Filter = flt
            End If
        End Sub

        Private Sub ChkFourn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourn.CheckedChanged
            With CbFournisseur
                If ChkFourn.Checked Then
                    .Enabled = True
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                Else
                    .Enabled = False
                    .SelectedItem = Nothing
                End If
            End With
        End Sub
#End Region
    End Class
End Namespace