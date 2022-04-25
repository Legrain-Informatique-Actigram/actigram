Imports System.Data.OleDb

Public Class FrPlanType

#Region "Form"
    Private Sub FrPlanType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.LoadData()
    End Sub

    Private Sub FrPlanType_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (Me.DataSetdbPlanType.HasChanges()) Then
            If (MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                Me.SaveData()
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub SupprimerD_CButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerD_CButton.Click
        Me.PlD_CComboBox.SelectedIndex = -1
    End Sub

    Private Sub SupprimerTypeTVAButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerTypeTVAButton.Click
        Me.PlTypTVAComboBox.SelectedIndex = -1
    End Sub
#End Region

#Region "PlanTypeBindingNavigator"
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Try
            Me.PlanTypeBindingSource.AddNew()

            Me.PlACptTextBox.Focus()
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

#Region "PlanTypeDataGridView"
    Private Sub PlanTypeDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles PlanTypeDataGridView.DataError
        MsgBox(e.Exception.Message, MsgBoxStyle.Exclamation, "")

        e.Cancel = True
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        'Chargement des données présentes dans le fichier DataPlanType.xml
        Me.LoadXMLData()

        Me.PlanTypeTableAdapter.Fill(Me.DataSetdbPlanType.PlanType)
        Me.DataSetdbPlanType.AcceptChanges()
        Me.PlanTypeBindingSource.Sort = "PlACpt"
    End Sub

    Private Function SaveData() As Boolean
        Try
            Me.PlanTypeBindingSource.EndEdit()

            Me.PlanTypeTableAdapter.Update(Me.DataSetdbPlanType.PlanType)

            MsgBox("Afin de prendre en compte vos modifications, veuillez recharger le dossier.", MsgBoxStyle.Exclamation, "")

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")

            Return False
        End Try
    End Function

    Private Sub DeleteData()
        Try
            Me.PlanTypeBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub LoadXMLData()
        Dim fichierDataXML As String = System.IO.Path.Combine(Application.StartupPath, My.Settings.FichierDataPlanTypeXML)

        Me.DataSetdbPlanType.ReadXml(fichierDataXML)
    End Sub
#End Region

End Class