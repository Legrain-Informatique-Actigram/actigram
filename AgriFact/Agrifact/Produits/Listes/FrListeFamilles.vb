Public Class FrListeFamilles

#Region "Props"
    Private ReadOnly Property CurrentFamilleRow() As DsAgrifact.FamilleRow
        Get
            If Me.FamilleBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.FamilleBindingSource.Current, DataRowView).Row, DsAgrifact.FamilleRow)
            End If
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.FamilleDataGridView.UseWaitCursor = True
            Application.DoEvents()
            Dim curId As Decimal = -1
            If Me.FamilleBindingSource.Current IsNot Nothing Then
                curId = Me.CurrentFamilleRow.nFamille
            End If

            Me.FamilleBindingSource.SuspendBinding()
            With Me.DsAgrifact
                .EnforceConstraints = False
                Me.FamilleTA.Fill(.Famille)
                .EnforceConstraints = True
            End With
            Me.FamilleBindingSource.ResumeBinding()

            If curId > -1 Then
                Me.FamilleBindingSource.Position = Me.FamilleBindingSource.Find("nFamille", curId)
            End If
            MajBoutons()
        Finally
            Cursor.Current = Cursors.Default
            Me.FamilleDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.FamilleBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Try
                Me.FamilleTA.Update(Me.DsAgrifact.Famille)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
                Me.DsAgrifact.RejectChanges()
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.FamilleBindingSource.EndEdit()
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
        ConfigColSel(Me.FamilleDataGridView, Me.ColSel)
        Using s As New SqlProxy
            With Me.DsAgrifact.Famille.nFamilleColumn
                .AutoIncrement = True
                .AutoIncrementSeed = s.GetMaxValue("Famille", "nFamille")
                .AutoIncrementStep = 1000
            End With
        End Using
        ApplyStyle(Me.FamilleDataGridView, False)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsAgrifact.Famille, AddressOf MajBoutons)
    End Sub
#End Region

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.TbSave.Enabled = DsAgrifact.HasChanges
    End Sub


#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub TbProduits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbProduits.Click
        OuvrirListeProduits()
    End Sub

    Private Sub TbEnvoiBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbEnvoiBalance.Click
        MajBalance()
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerFamille(Me.CurrentFamilleRow.nFamille)
    End Sub
#End Region

#Region "Grid"
    Private Sub FamilleDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles FamilleDataGridView.CellDoubleClick
        If Me.FamilleBindingSource.Current Is Nothing Then Exit Sub
        If e.ColumnIndex = DescriptionDataGridViewTextBoxColumn.Index Then
            FrModifTxt.ZoomTextBoxCell(Cast(Of DataGridViewTextBoxCell)(FamilleDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)))
        Else
            OuvrirListeProduits()
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub OuvrirListeProduits()
        With New FrListeProduits(Me.CurrentFamilleRow.nFamille)
            .StartPosition = FormStartPosition.CenterParent
            If Me.MdiParent IsNot Nothing Then
                .MdiParent = Me.MdiParent
                .WindowState = Me.WindowState
                .Show()
            Else
                .Owner = Me
                .ShowDialog()
            End If
        End With
    End Sub

    Private Sub MajBalance()
        Dim ds As New DataSet
        DefinitionDonnees.Instance.Fill(ds, "TVA")
        Dim Balance As New Actigram.Balance.Mira.GestionMira
        Balance.TableTVA = ds.Tables("TVA")
        Balance.nBalance = 0
        Dim rws As List(Of DataRow) = GetSelectedRows(Me.FamilleDataGridView)
        If rws.Count > 0 Then
            Balance.EnvoiMajFamille(rws.ToArray)
        End If
        Balance.nBalance = 1
    End Sub

    Private Sub ImprimerFamille(ByVal nFamille As Integer)
        Dim ds As New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Famille", String.Format("nFamille={0}", nFamille))
            DefinitionDonnees.Instance.Fill(ds, "Produit", String.Format("Famille1={0}", nFamille))
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)
        With ds.Tables("Produit").Columns
            If Not .Contains("NomFamille") Then .Add("NomFamille", GetType(String), "Parent(FamilleProduit).Famille")
        End With

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(ds, "RptListeProduit.rpt")
        fr.Show(Me)
    End Sub
#End Region

End Class