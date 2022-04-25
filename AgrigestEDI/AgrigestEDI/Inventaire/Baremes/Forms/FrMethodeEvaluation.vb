Public Class FrMethodeEvaluation

#Region "Form"
    Private Sub FrParametres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ChargerDonnees()
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)

        gestDossiers.UpdateDMethodeInventaire(CStr(Me.MethodeInventaireComboBox.SelectedValue), My.User.Name)

        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        'Remplissage de la table MethodeInventaire du DataSet
        Dim methodeInventaireDR As DataSetAgrigest.MethodeInventaireRow = Nothing

        methodeInventaireDR = CType(Me.DataSetAgrigest.MethodeInventaire.NewRow(), AgrigestEDI.DataSetAgrigest.MethodeInventaireRow)

        methodeInventaireDR.Libelle = My.Resources.M1

        Me.DataSetAgrigest.MethodeInventaire.AddMethodeInventaireRow(methodeInventaireDR)

        methodeInventaireDR = CType(Me.DataSetAgrigest.MethodeInventaire.NewRow(), AgrigestEDI.DataSetAgrigest.MethodeInventaireRow)

        methodeInventaireDR.Libelle = My.Resources.M2

        Me.DataSetAgrigest.MethodeInventaire.AddMethodeInventaireRow(methodeInventaireDR)

        'Remplissage de la table Dossiers du DataSet
        Me.DossiersTableAdapter.FillByDDossier(Me.DataSetAgrigest.Dossiers, My.User.Name)
    End Sub
#End Region

End Class