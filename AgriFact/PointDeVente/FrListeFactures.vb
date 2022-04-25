Public Class FrListeFactures

    Private loading As Boolean
    Private _nClient As Integer = -1

    Public nDevis As Integer = -1

#Region "Props"
    Public Property nClient() As Integer
        Get
            Return _nClient
        End Get
        Set(ByVal value As Integer)
            _nClient = value
        End Set
    End Property

    Private ReadOnly Property CurrentFactRow() As DsAgrifact.VFactureRow
        Get
            If Me.FactBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.FactBindingSource.Current, DataRowView).Row, DsAgrifact.VFactureRow)
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
        Me.nClient = nFournisseur
    End Sub
#End Region

#Region "Form"
    'Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If e.CloseReason = CloseReason.UserClosing Then
    '        If DemanderEnregistrement() Then
    '            Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Else
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        loading = True
        'ConfigDataTableEvents(dsAgrifact.VFacture, AddressOf MajBoutons)
        ApplyStyle(Me.FactDataGridView)

        ChkClient.Checked = False
        CbClient.Enabled = False

        Dim demain As Date = Now.Date.AddDays(1)
        dtpFin.MaxDate = demain
        dtpDeb.MaxDate = demain
        dtpFin.Value = Today
        dtpDeb.Value = Today

        Me.ChkFactPayees.Checked = True

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
            Me.FactDataGridView.UseWaitCursor = True
            Application.DoEvents()
            Dim curId As Decimal = -1
            If Me.FactBindingSource.Current IsNot Nothing Then
                curId = Me.CurrentFactRow.nDevis
            End If
            Me.FactBindingSource.SuspendBinding()
            With Me.dsAgrifact
                .EnforceConstraints = False
                If Me.nClient < 0 Then
                    Me.EntrepriseTA.FillByTypeClient(.Entreprise, DsAgrifactTableAdapters.EntrepriseTA.TypeClient.Particulier)
                    Me.VFactureTA.Fill(.VFacture)
                    Me.CbClient.SelectedItem = Nothing
                Else
                    Me.EntrepriseTA.FillByNEnt(.Entreprise, Me.nClient)
                    Me.VFactureTA.FillByNClient(.VFacture, Me.nClient)
                    ChkClient.Enabled = False
                    CbClient.SelectedIndex = 0
                End If
                .EnforceConstraints = True
            End With
            Me.FactBindingSource.ResumeBinding()
            If curId > -1 Then
                Me.FactBindingSource.Position = Me.FactBindingSource.Find("nDevis", curId)
            End If
            MajBoutons()
        Finally
            Cursor.Current = Cursors.Default
            Me.FactDataGridView.UseWaitCursor = False
            loading = False
        End Try
    End Sub

    'Private Sub Enregistrer()
    '    Me.Validate()
    '    Me.FactBindingSource.EndEdit()
    '    If Me.dsAgrifact.HasChanges Then
    '        Me.VFactureTA.Update(Me.dsAgrifact.VFacture)
    '    End If
    '    MajBoutons()
    'End Sub

    'Private Function DemanderEnregistrement() As Boolean
    '    Me.Validate()
    '    Me.FactBindingSource.EndEdit()
    '    If Me.dsAgrifact.HasChanges Then
    '        Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
    '            Case MsgBoxResult.Yes
    '                Enregistrer()
    '            Case MsgBoxResult.No
    '            Case MsgBoxResult.Cancel
    '                Return False
    '        End Select
    '    End If
    '    Return True
    'End Function
#End Region

#Region "Méthodes diverses"
    'Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
    '    MajBoutons()
    'End Sub

    Private Sub MajBoutons()
        '    Me.TbSave.Enabled = dsAgrifact.HasChanges
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        Me.SplitContainer1.Panel2Collapsed = Not TbFilter.Checked
    End Sub
#End Region

#Region "Grid"
    Private Sub ProduitDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FactDataGridView.DoubleClick
        If Me.FactBindingSource.Current Is Nothing Then Exit Sub
        Me.nDevis = CInt(Me.CurrentFactRow.nDevis)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Filtrage"
    Private Sub dtpDeb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                    Handles dtpDeb.Validating, dtpFin.Validating
        e.Cancel = dtpDeb.Value > dtpFin.Value
    End Sub

    Private Sub FilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles CbClient.SelectedIndexChanged, dtpDeb.ValueChanged, dtpFin.ValueChanged, _
                    ChkFactPayees.CheckedChanged
        If Not loading Then
            Dim flt As String = "FacturationTTC=True AND "
            If Not ChkFactPayees.Checked Then
                flt &= "Paye=False AND "
            End If
            If ChkClient.Checked And CbClient.SelectedItem IsNot Nothing Then
                flt &= String.Format("nClient={0} AND ", CbClient.SelectedValue)
            End If
            flt &= String.Format("DateFacture>='{0:dd/MM/yyyy}' AND DateFacture<'{1:dd/MM/yyyy}'", dtpDeb.Value.Date, dtpFin.Value.AddDays(1).Date)
            Me.FactBindingSource.Filter = flt
        End If
    End Sub

    Private Sub ChkFourn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkClient.CheckedChanged
        With CbClient
            If ChkClient.Checked Then
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