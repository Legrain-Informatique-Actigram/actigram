Public Class FrGererFaconsCulturales

#Region "Form"
    Private Sub FrGererFaconsCulturales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ConstruireTitre()

        Me.ChargerDonnees()
    End Sub

    Private Sub FrGererFaconsCulturales_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "FACON_CULTURALEBindingNavigator"
    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        Dim listeLignesSelectionnees As List(Of DataSetBaremes.FACON_CULTURALERow) = Me.RecupererLignesSelectionnees()

        If (listeLignesSelectionnees.Count > 0) Then
            If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                'Si le nombre de lignes supprimées et différent du nombre de lignes
                'sélectionnées -> la différence provient des façons culturales affectées à un barème 
                '(donc non supprimable) 
                If (Me.SupprimerListeFacons_Culturales(listeLignesSelectionnees) <> listeLignesSelectionnees.Count) Then
                    MsgBox("Une ou plusieurs façons culturales n'ont pu être supprimées car elles sont affectées à au moins un barème.", MsgBoxStyle.Exclamation, "Suppression impossible")
                End If
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConstruireTitre()
        Me.Text = "Gérer les façons culturales - " & GetDataSource(My.Settings.BaremesConnectionString)
    End Sub

    Private Sub ChargerDonnees()
        'Chargement des façons culturales
        Me.FACON_CULTURALETableAdapter.Fill(Me.DataSetBaremes.FACON_CULTURALE)

        Me.FACON_CULTURALEBindingSource.Sort = "LIBELLE_FACON_CULTURALE ASC"
    End Sub

    Private Function Enregistrer() As Boolean
        Me.FACON_CULTURALEBindingSource.EndEdit()

        Me.FACON_CULTURALETableAdapter.Update(Me.DataSetBaremes.FACON_CULTURALE)

        Return True
    End Function

    Private Function RecupererLignesSelectionnees() As List(Of DataSetBaremes.FACON_CULTURALERow)
        Dim listeLignesSelectionnees As New List(Of DataSetBaremes.FACON_CULTURALERow)

        For Each dgvr As DataGridViewRow In Me.FACON_CULTURALEDataGridView.SelectedRows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf dgvr.DataBoundItem Is DataRowView Then Continue For

            Dim facon_CulturaleDR As DataSetBaremes.FACON_CULTURALERow = DirectCast(DirectCast(dgvr.DataBoundItem, DataRowView).Row, DataSetBaremes.FACON_CULTURALERow)

            listeLignesSelectionnees.Add(facon_CulturaleDR)
        Next

        Return listeLignesSelectionnees
    End Function

    Private Function SupprimerListeFacons_Culturales(ByVal listeLignesSelectionnees As List(Of DataSetBaremes.FACON_CULTURALERow)) As Integer
        Dim nbLignesSupp As Integer = 0

        For Each facon_CulturaleDR As DataSetBaremes.FACON_CULTURALERow In listeLignesSelectionnees
            'Vérifie que la façon culturale n'est pas affecté à un barème
            Dim gestBareme_Forf As New Baremes.ClassesControleur.GestionnaireBareme_Forfaitaire(My.Settings.BaremesConnectionString)

            If Not (gestBareme_Forf.Facon_CulturaleEstAffecteABareme_Forfaitaire(facon_CulturaleDR.ID_FACON_CULTURALE)) Then
                facon_CulturaleDR.Delete()

                nbLignesSupp += 1
            End If
        Next

        'Mise à jour de la base de données
        If (nbLignesSupp > 0) Then
            Me.Enregistrer()
        End If

        Return nbLignesSupp
    End Function
#End Region

End Class