Public Class FrGererMateriel

#Region "Form"
    Private Sub FrGererMateriel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ConstruireTitre()

        Me.ChargerDonnees()
    End Sub

    Private Sub FrGererMateriel_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "MATERIELBindingNavigator"
    Private Sub SupprimerMaterielToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerMaterielToolStripButton.Click
        Dim listeLignesSelectionnees As List(Of DataSetBaremes.MATERIELRow) = Me.RecupererLignesSelectionnees()

        If (listeLignesSelectionnees.Count > 0) Then
            If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                'Si le nombre de lignes supprim�es et diff�rent du nombre de lignes
                's�lectionn�es -> la diff�rence provient du mat�riel affect� � un bar�me 
                '(donc non supprimable) 
                If (Me.SupprimerListeMateriels(listeLignesSelectionnees) <> listeLignesSelectionnees.Count) Then
                    MsgBox("Un ou plusieurs mat�riels n'ont pu �tre supprim�s car ils sont affect�s � au moins un bar�me.", MsgBoxStyle.Exclamation, "Suppression impossible")
                End If
            End If
        End If
    End Sub
#End Region

#Region "M�thodes diverses"
    Private Function Enregistrer() As Boolean
        Me.MATERIELBindingSource.EndEdit()

        Me.MATERIELTableAdapter.Update(Me.DataSetBaremes.MATERIEL)

        Return True
    End Function

    Private Sub ChargerDonnees()
        'Chargement de la liste du mat�riel
        Me.MATERIELTableAdapter.Fill(Me.DataSetBaremes.MATERIEL)

        Me.MATERIELBindingSource.Sort = "LIBELLE_MATERIEL ASC"

        'Chargement de la liste des types de mat�riel
        Me.TYPE_MATERIELTableAdapter.Fill(Me.DataSetBaremes.TYPE_MATERIEL)
    End Sub

    Private Function RecupererLignesSelectionnees() As List(Of DataSetBaremes.MATERIELRow)
        Dim listeLignesSelectionnees As New List(Of DataSetBaremes.MATERIELRow)

        For Each dgvr As DataGridViewRow In Me.MATERIELDataGridView.SelectedRows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf dgvr.DataBoundItem Is DataRowView Then Continue For

            Dim materielDR As DataSetBaremes.MATERIELRow = DirectCast(DirectCast(dgvr.DataBoundItem, DataRowView).Row, DataSetBaremes.MATERIELRow)

            listeLignesSelectionnees.Add(materielDR)
        Next

        Return listeLignesSelectionnees
    End Function

    Private Function SupprimerListeMateriels(ByVal listeLignesSelectionnees As List(Of DataSetBaremes.MATERIELRow)) As Integer
        Dim nbLignesSupp As Integer = 0

        For Each materielDR As DataSetBaremes.MATERIELRow In listeLignesSelectionnees
            'V�rifie que le mat�riel n'est pas affect� � un bar�me
            Dim gestBareme As New Baremes.ClassesControleur.GestionnaireBareme(My.Settings.BaremesConnectionString)

            If Not (gestBareme.MaterielEstAffecteABareme(materielDR.ID_MATERIEL)) Then
                materielDR.Delete()

                nbLignesSupp += 1
            End If
        Next

        'Mise � jour de la base de donn�es
        If (nbLignesSupp > 0) Then
            Me.Enregistrer()
        End If

        Return nbLignesSupp
    End Function

    Private Sub ConstruireTitre()
        Me.Text = "G�rer le mat�riel - " & GetDataSource(My.Settings.BaremesConnectionString)
    End Sub
#End Region

End Class