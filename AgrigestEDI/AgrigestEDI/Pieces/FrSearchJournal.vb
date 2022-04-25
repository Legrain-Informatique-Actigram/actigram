Imports System.Windows.Forms

Public Class FrSearchJournal

#Region "Propriétés"
    Private _res As dbDonneesDataSet.JournalRow
    Public ReadOnly Property ResultatJournal() As dbDonneesDataSet.JournalRow
        Get
            Return _res
        End Get
    End Property

    Private _ResultatDateMin As Date
    Public ReadOnly Property ResultatDateMin() As Date
        Get
            Return _ResultatDateMin
        End Get
    End Property

    Private _ResultatDateMax As Date
    Public ReadOnly Property ResultatDateMax() As Date
        Get
            Return _ResultatDateMax
        End Get
    End Property
#End Region

#Region "Page"
    Private Sub FrJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.JournalTableAdapter.FillByType(Me.dbJournal.Journal, "tr")
        With My.Dossier.Principal
            dtpDateStart.Value = .DateDebutEx
            dtpDateStart.MinDate = .DateDebutEx
            dtpDateStart.MaxDate = .DateFinEx
            dtpDateEnd.Value = .DateFinEx
            dtpDateEnd.MinDate = .DateDebutEx
            dtpDateEnd.MaxDate = .DateFinEx
        End With
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cboJournal.SelectedItem Is Nothing Then Exit Sub
        Try
            _res = CType(CType(cboJournal.SelectedItem, DataRowView).Row, dbDonneesDataSet.JournalRow)
            _ResultatDateMin = dtpDateStart.Value
            _ResultatDateMax = dtpDateEnd.Value
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

    Private Sub cboJournal_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJournal.DoubleClick
        OK_Button_Click(Nothing, Nothing)
    End Sub
End Class
