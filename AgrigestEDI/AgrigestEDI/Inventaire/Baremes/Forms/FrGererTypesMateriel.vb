Public Class FrGererTypesMateriel

#Region "Form"
    Private Sub FrGererTypesMateriel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ConstruireTitre()

        Me.ChargerDonnees()
    End Sub

    Private Sub FrGererTypesMateriel_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "BindingNavigatorTYPE_MATERIEL"
    Private Sub ToolStripButtonSupprimerTypeMateriel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSupprimerTypeMateriel.Click
        Dim listeLignesSelectionnees As List(Of DataSetBaremes.TYPE_MATERIELRow) = Me.RecupererLignesSelectionnees()

        If (listeLignesSelectionnees.Count > 0) Then
            If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                'Si le nombre de lignes supprimées et différent du nombre de lignes
                'sélectionnées -> la différence provient des types de matériel affecté à un matériel 
                '(donc non supprimable)
                If (Me.SupprimerListeTypesMateriel(listeLignesSelectionnees) <> listeLignesSelectionnees.Count) Then
                    MsgBox("Un ou plusieurs types n'ont pu être supprimés car ils sont affectés à au moins un matériel.", MsgBoxStyle.Exclamation, "Suppression impossible")
                End If
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function Enregistrer() As Boolean
        Me.TYPE_MATERIELBindingSource.EndEdit()

        Me.TYPE_MATERIELTableAdapter.Update(Me.DataSetBaremes.TYPE_MATERIEL)

        Return True
    End Function

    Private Sub ChargerDonnees()
        Me.TYPE_MATERIELTableAdapter.Fill(Me.DataSetBaremes.TYPE_MATERIEL)
    End Sub

    Private Function RecupererLignesSelectionnees() As List(Of DataSetBaremes.TYPE_MATERIELRow)
        Dim listeLignesSelectionnees As New List(Of DataSetBaremes.TYPE_MATERIELRow)

        For Each dgvr As DataGridViewRow In Me.DataGridViewTYPE_MATERIEL.SelectedRows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf dgvr.DataBoundItem Is DataRowView Then Continue For

            Dim type_MaterielDR As DataSetBaremes.TYPE_MATERIELRow = DirectCast(DirectCast(dgvr.DataBoundItem, DataRowView).Row, DataSetBaremes.TYPE_MATERIELRow)

            listeLignesSelectionnees.Add(type_MaterielDR)
        Next

        Return listeLignesSelectionnees
    End Function

    Private Function SupprimerListeTypesMateriel(ByVal listeLignesSelectionnees As List(Of DataSetBaremes.TYPE_MATERIELRow)) As Integer
        Dim nbLignesSupp As Integer = 0

        For Each type_MaterielDR As DataSetBaremes.TYPE_MATERIELRow In listeLignesSelectionnees
            'Vérifie que le mode de paiement n'est pas affecté à un matériel
            Dim gestMateriel As New Baremes.ClassesControleur.GestionnaireMateriel(My.Settings.BaremesConnectionString)

            If Not (gestMateriel.TypeEstAffecteAMateriel(type_MaterielDR.ID_TYPE_MATERIEL)) Then
                type_MaterielDR.Delete()

                nbLignesSupp += 1
            End If
        Next

        'Mise à jour de la base de données
        If (nbLignesSupp > 0) Then
            Me.Enregistrer()
        End If

        Return nbLignesSupp
    End Function

    Private Sub ConstruireTitre()
        Me.Text = "Gérer les types de matériel - " & GetDataSource(My.Settings.BaremesConnectionString)
    End Sub
#End Region

End Class