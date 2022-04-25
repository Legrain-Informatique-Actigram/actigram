Public Class FrCaisse

    Private _nCaisse As Integer = -1

#Region "Props"
    Public Property NCaisse() As Integer
        Get
            Return _nCaisse
        End Get
        Set(ByVal value As Integer)
            _nCaisse = value
        End Set
    End Property

    Private ReadOnly Property CurrentJRow() As DsAgrifact.JournalCaisseRow
        Get
            If Me.JournalCaisseBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.JournalCaisseBindingSource.Current, DataRowView).Row, DsAgrifact.JournalCaisseRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nCaisse As Integer)
        Me.New()
        Me.nCaisse = nCaisse
    End Sub
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
        ApplyStyle(Me.JournalCaisseDataGridView)
        ConfigDataTableEvents(Me.DsAgrifact.JournalCaisse, Nothing)
        ChargerDonnees()
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        If Me.NCaisse < 0 Then
            InitCaisse(Me.NCaisse, Me.JournalCaisseTA)
        End If
        'Charger la caisse
        Me.JournalCaisseTA.FillByNCaisse(Me.DsAgrifact.JournalCaisse, Me.NCaisse)
        Me.DsAgrifact.JournalCaisse.InitLibType()
        Me.DsAgrifact.JournalCaisse.AcceptChanges()

        MajTotal()
        MajBoutons()
    End Sub

    Public Shared Function InitCaisse(ByRef nCaisse As Integer, ByVal dta As DsAgrifactTableAdapters.JournalCaisseTA) As DialogResult
        If nCaisse < 0 Then
            Dim i As Nullable(Of Integer) = dta.GetLastNCaisse()
            If i.HasValue Then
                If MsgBox("Reprendre le cours de la dernière caisse ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    nCaisse = i.Value
                End If
            End If
            If nCaisse < 0 Then
                'Saisie d'un nouveau fond de caisse
                Return AjouterOpe(nCaisse, PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond)
            Else
                Return Windows.Forms.DialogResult.OK
            End If
        End If
    End Function

    Private Sub MajTotal()
        Dim o As Object = Me.DsAgrifact.JournalCaisse.Compute("SUM(MontantSigne)", "")
        If Not IsDBNull(o) Then
            lbTotalCaisse.Text = CDec(o).ToString("C2")
        Else
            lbTotalCaisse.Text = ""
        End If
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.JournalCaisseBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Me.JournalCaisseTA.Update(Me.DsAgrifact.JournalCaisse)
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.JournalCaisseBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
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

#Region "JournalCaisseBindingSource"
    Private Sub JournalCaisseBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles JournalCaisseBindingSource.CurrentChanged
        MajBoutons()
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Enregistrer()
    End Sub

    Private Sub SaisirUnFondDeCaisseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaisirUnFondDeCaisseToolStripMenuItem.Click
        AjouterOpe(PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond)
    End Sub

    Private Sub RentréeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RentréeToolStripMenuItem.Click
        AjouterOpe(PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Rentrée)
    End Sub

    Private Sub DépenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DépenseToolStripMenuItem.Click
        AjouterOpe(PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Dépense)
    End Sub

    Private Sub CoffreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoffreToolStripMenuItem.Click
        AjouterOpe(PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Coffre)
    End Sub

    Private Sub BtSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSuppr.Click
        If Me.CurrentJRow Is Nothing Then Exit Sub
        If Me.CurrentJRow.Type = DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond Then Exit Sub
        Try
            Me.JournalCaisseBindingSource.RemoveCurrent()
            Enregistrer()
            MajTotal()
        Catch ex As UserCancelledException
        End Try
    End Sub

#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        BtSave.Enabled = Me.DsAgrifact.HasChanges
        If Me.CurrentJRow IsNot Nothing Then
            BtSuppr.Enabled = Me.CurrentJRow.Type > 0
        Else
            BtSuppr.Enabled = False
        End If
    End Sub

    Private Sub AjouterOpe(ByVal type As DsAgrifact.JournalCaisseDataTable.TypeCaisse)
        If AjouterOpe(Me.NCaisse, type) = Windows.Forms.DialogResult.OK Then
            ChargerDonnees()
            'Dim pos As Integer = Me.JournalCaisseBindingSource.Find("IdMvtCaisse", fr.IdMvtCaisse)
            'If pos >= 0 Then
            Me.JournalCaisseBindingSource.Position = Me.JournalCaisseBindingSource.Count - 1
            'End If
        End If
    End Sub

    Public Shared Function AjouterOpe(ByRef nCaisse As Integer, ByVal type As DsAgrifact.JournalCaisseDataTable.TypeCaisse) As DialogResult
        Using fr As New FrOpeCaisse(nCaisse, type)
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                If type = PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond Then
                    nCaisse = fr.nCaisse
                End If
                Return Windows.Forms.DialogResult.OK
            Else
                Return Windows.Forms.DialogResult.Cancel
            End If
        End Using
    End Function
#End Region

End Class
