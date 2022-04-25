Imports System.Data.OleDb

Public Class FrPlanTypeJournaux

#Region "Form"
    Private Sub FrJournaux_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.LoadData()
    End Sub

    Private Sub FrJournaux_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (Me.DataSetdbPlanType.HasChanges()) Then
            If (MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                Me.SaveData()
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub SupprimerCompteContreButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerCompteContreButton.Click
        Me.JCompteContreComboBox.SelectedIndex = -1
    End Sub
#End Region

#Region "JournalAvecErreurBindingNavigator"
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Try
            Me.JournalAvecErreurBindingSource.AddNew()
            Me.JCodeJournalTextBox.Enabled = True
            Me.JCodeJournalTextBox.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        Me.DeleteData()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If (Me.SaveData()) Then
            MsgBox("Données enregistrées.", MsgBoxStyle.Information, "")
        End If
    End Sub
#End Region

#Region "JournalAvecErreurDataGridView"
    Private Sub JournalAvecErreurDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles JournalAvecErreurDataGridView.DataError
        MsgBox(e.Exception.Message, MsgBoxStyle.Exclamation, "")

        e.Cancel = True
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        'Chargement des données présentes dans le fichier DataPlanType.xml
        'dans le dataSet DataSetdbPlanType
        Me.LoadXMLData()

        Me.PlanComptableTableAdapter.FillByPlDossier(Me.DataSetAgrigest.PlanComptable, My.User.Name)
        Me.JournalAvecErreurTableAdapter.Fill(Me.DataSetdbPlanType.JournalAvecErreur)

        'Remplissage de la colonne Erreur
        Me.RemplirColonneErreur()

        Me.DataSetdbPlanType.AcceptChanges()

        Me.JournalAvecErreurBindingSource.Sort = "JCodeJournal"
    End Sub

    Private Sub RemplirColonneErreur()
        Using planComptableTA As New DataSetAgrigestTableAdapters.PlanComptableTableAdapter
            For Each journalAvecErreurDR As DataSetdbPlanType.JournalAvecErreurRow In Me.DataSetdbPlanType.JournalAvecErreur.Rows
                If Not (journalAvecErreurDR.IsJCompteContreNull) Then
                    If Not (String.IsNullOrEmpty(journalAvecErreurDR.JCompteContre)) Then
                        Dim planComptableDT As DataSetAgrigest.PlanComptableDataTable = planComptableTA.GetDataByPlDossierEtPlCpt(My.User.Name, journalAvecErreurDR.JCompteContre)

                        If Not (planComptableDT.Rows.Count > 0) Then
                            journalAvecErreurDR.Erreur = "Le compte de contrepartie " & journalAvecErreurDR.JCompteContre & " est inexistant dans le plan comptable d'AgrigestEDI pour ce dossier."
                            journalAvecErreurDR.JCompteContre = String.Empty
                        End If
                    End If
                End If
            Next
        End Using
    End Sub

    Private Function SaveData() As Boolean
        Try
            Me.JournalAvecErreurBindingSource.EndEdit()

            If (Me.ListeJournauxEnErreur()) Then
                If (MsgBox("La liste comporte des erreurs. Voulez-vous quand même continuer ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                    Return False
                End If
            End If

            Me.JournalAvecErreurTableAdapter.Update(Me.DataSetdbPlanType.JournalAvecErreur)

            Me.RemplirColonneErreur()

            MsgBox("Afin de prendre en compte vos modifications, veuillez recharger le dossier.", MsgBoxStyle.Exclamation, "")

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")

            Return False
        End Try
    End Function

    Private Sub DeleteData()
        Try
            If (Me.JournalAvecErreurDataGridView.SelectedRows.Count > 0) Then
                Dim journalAvecErreurDR As DataSetdbPlanType.JournalAvecErreurRow = CType(CType(Me.JournalAvecErreurBindingSource.Current, DataRowView).Row, AgrigestEDI.DataSetdbPlanType.JournalAvecErreurRow)

                If Not (Me.JournalEstUtilise(journalAvecErreurDR.JCodeJournal)) Then
                    Me.JournalAvecErreurBindingSource.RemoveCurrent()
                Else
                    MsgBox("Suppression impossible, ce journal est utilisé dans les pièces.", MsgBoxStyle.Exclamation, "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Function JournalEstUtilise(ByVal codeJournal As String) As Boolean
        Using piecesTA As New DataSetAgrigestTableAdapters.PiecesTableAdapter
            If (piecesTA.NbPiecesParJournal(codeJournal).GetValueOrDefault() > 0) Then
                Return True
            End If
        End Using

        Return False
    End Function

    Private Function ListeJournauxEnErreur() As Boolean
        For Each drv As DataRowView In Me.JournalAvecErreurBindingSource.List
            Dim journalAvecErreurDR As DataSetdbPlanType.JournalAvecErreurRow = CType(CType(drv, DataRowView).Row, AgrigestEDI.DataSetdbPlanType.JournalAvecErreurRow)

            If Not (journalAvecErreurDR.IsErreurNull) Then
                If Not (String.IsNullOrEmpty(journalAvecErreurDR.Erreur)) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Sub LoadXMLData()
        Dim fichierDataXML As String = System.IO.Path.Combine(Application.StartupPath, My.Settings.FichierDataPlanTypeXML)

        Me.DataSetdbPlanType.ReadXml(fichierDataXML)
    End Sub
#End Region

End Class