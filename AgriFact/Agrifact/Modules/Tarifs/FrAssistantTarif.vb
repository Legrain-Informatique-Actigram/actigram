Imports System.Windows.Forms

Public Class FrAssistantTarif

    Private ds As DataSet

    Public Sub New()
        InitializeComponent()
    End Sub

#Region "Donnees"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet
        DefinitionDonnees.Instance.Fill(ds, "Tarif")
        DefinitionDonnees.Instance.FillSchema(ds, "Tarif_Detail")
        Databinding()
    End Sub

    Private Sub Databinding()
        With Me.CbTarifCoef
            .DataSource = ds.Tables("Tarif")
            .DisplayMember = "Libelle"
            .ValueMember = "nTarif"
        End With

        With Me.CbTarifDupliquer
            .DataSource = ds.Tables("Tarif")
            .DisplayMember = "Libelle"
            .ValueMember = "nTarif"
        End With

        Me.rbCoefPrixStandard.Checked = True
        Me.rbDupliPrixStandard.Checked = True
        Me.OptAppliquerCoef.Checked = True

        Me.nudCoef.Value = 100

        Me.rbCoefTarifExistant.Enabled = CbTarifCoef.Items.Count > 0
        Me.rbDupliTarifExistant.Enabled = CbTarifDupliquer.Items.Count > 0
        If CbTarifCoef.Items.Count > 0 Then CbTarifCoef.SelectedIndex = 0
        If CbTarifDupliquer.Items.Count > 0 Then CbTarifDupliquer.SelectedIndex = 0
        CbTarifCoef.Enabled = rbCoefTarifExistant.Checked
        CbTarifDupliquer.Enabled = rbDupliTarifExistant.Checked

        OptAucun_CheckedChanged(Nothing, Nothing)
    End Sub
#End Region

#Region "Form Events"
    Private Sub FrAssistantDemarrage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me, True)
        ChargerDonnees()
    End Sub
#End Region

#Region "Control Events"
    Private Sub OptAppliquerCoef_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OptAppliquerCoef.CheckedChanged, OptDupliquer.CheckedChanged
        If OptAppliquerCoef.Checked Then
            If wt.Pages.Contains(Me.wpDupliquerTarif) Then wt.Pages.Remove(Me.wpDupliquerTarif)
            If Not wt.Pages.Contains(Me.wpAppliquerCoef) Then wt.Pages.Add(Me.wpAppliquerCoef)
        ElseIf OptDupliquer.Checked Then
            If Not wt.Pages.Contains(Me.wpDupliquerTarif) Then wt.Pages.Add(Me.wpDupliquerTarif)
            If wt.Pages.Contains(Me.wpAppliquerCoef) Then wt.Pages.Remove(Me.wpAppliquerCoef)
        End If
    End Sub

    Private Sub OptAucun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OptAucun.CheckedChanged, TxTarif.TextChanged
        If TxTarif.Text.Trim.Length = 0 Then
            Me.wpNom.HasFinishButton = False
            Me.wpNom.HasNextButton = False
        Else
            Me.wpNom.HasFinishButton = OptAucun.Checked
            Me.wpNom.HasNextButton = Not OptAucun.Checked
        End If
    End Sub

    Private Sub rbTarifExistant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles rbDupliTarifExistant.CheckedChanged, rbCoefTarifExistant.CheckedChanged
        CbTarifCoef.Enabled = rbCoefTarifExistant.Checked
        CbTarifDupliquer.Enabled = rbDupliTarifExistant.Checked
    End Sub

    Private Sub nudCoef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudCoef.KeyPress
        If e.KeyChar = "."c Then
            nudCoef.Text &= Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Wizard Events"
    Private Sub wt_FinishClick() Handles wt.FinishClick
        If CreerTarif() Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub wt_CancelClick() Handles wt.CancelClick
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

    Private Function CreerTarif() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim rw As DataRow = ds.Tables("Tarif").NewRow
            rw("Libelle") = Me.TxTarif.Text
            ds.Tables("Tarif").Rows.Add(rw)
            If wt.CurrentPage Is wpNom Then
                'Initialiser les lignes de tarif à 0
                RemplirTarifDepuisPrix(CInt(rw("nTarif")), 0)
            ElseIf wt.CurrentPage Is wpAppliquerCoef Then
                Dim Coef As Decimal = nudCoef.Value / 100
                If rbCoefTarifExistant.Checked Then
                    RemplirTarifDepuisExistant(CInt(rw("nTarif")), CInt(Me.CbTarifCoef.SelectedValue), Coef)
                ElseIf rbCoefPrixStandard.Checked Then
                    RemplirTarifDepuisPrix(CInt(rw("nTarif")), Coef)
                End If
            ElseIf wt.CurrentPage Is wpDupliquerTarif Then
                If rbDupliTarifExistant.Checked Then
                    RemplirTarifDepuisExistant(CInt(rw("nTarif")), CInt(Me.CbTarifDupliquer.SelectedValue), 1)
                ElseIf rbDupliPrixStandard.Checked Then
                    RemplirTarifDepuisPrix(CInt(rw("nTarif")), 1)
                End If
            End If
            Using s As New SqlProxy
                s.UpdateTables(ds, New String() {"Tarif", "Tarif_Detail"})
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub RemplirTarifDepuisExistant(ByVal nTarifDest As Integer, ByVal nTarifSrc As Integer, ByVal Coef As Decimal)
        DefinitionDonnees.Instance.Fill(ds, "Tarif_Detail", "nTarif=" & nTarifSrc)
        For Each rwT As DataRow In ds.Tables("Tarif_Detail").Select
            Dim rwN As DataRow = ds.Tables("Tarif_Detail").NewRow
            With rwN
                .Item("nTarif") = nTarifDest
                .Item("CodeProduit") = rwT("CodeProduit")
                If Not IsDBNull(rwT("PrixVHT")) Then .Item("PrixVHT") = CDec(rwT("PrixVHT")) * Coef
                If Not IsDBNull(rwT("PrixVTTC")) Then .Item("PrixVTTC") = CDec(rwT("PrixVTTC")) * Coef
                If Not IsDBNull(rwT("Coef")) Then .Item("Coef") = CDec(rwT("Coef")) * Coef
            End With
            ds.Tables("Tarif_Detail").Rows.Add(rwN)
        Next
    End Sub

    Private Sub RemplirTarifDepuisPrix(ByVal nTarif As Integer, ByVal Coef As Decimal)
        DefinitionDonnees.Instance.Fill(ds, "Produit")
        For Each rwT As DataRow In ds.Tables("Produit").Rows
            Dim rwN As DataRow = ds.Tables("Tarif_Detail").NewRow
            With rwN
                .Item("nTarif") = nTarif
                .Item("CodeProduit") = rwT("CodeProduit")
                If Not IsDBNull(rwT("PrixVHT")) Then .Item("PrixVHT") = CDec(rwT("PrixVHT")) * Coef
                If Not IsDBNull(rwT("PrixVTTC")) Then .Item("PrixVTTC") = CDec(rwT("PrixVTTC")) * Coef
                .Item("Coef") = Coef
            End With
            ds.Tables("Tarif_Detail").Rows.Add(rwN)
        Next
    End Sub

End Class
