Public Class FrClotureTVA

#Region "Form"
    Private Sub FrClotureTVA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ParametrerDateClotureTVADateTimePicker()
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.SetDDtClotureTVA()

        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ParametrerDateClotureTVADateTimePicker()
        'Recherche des infos du dossier en cours
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        If (doss.DDtDebEx.HasValue) And (doss.DDtFinEx.HasValue) Then
            Me.DateClotureTVADateTimePicker.MinDate = CDate(String.Format("{0:dd/MM/yyyy}", doss.DDtDebEx))
            Me.DateClotureTVADateTimePicker.MaxDate = CDate(String.Format("{0:dd/MM/yyyy}", doss.DDtFinEx))

            If (doss.DDtClotureTVA.HasValue) Then
                Me.DateClotureTVADateTimePicker.Value = CDate(doss.DDtClotureTVA)
                Me.DateClotureTVADateTimePicker.Checked = True
            Else
                Me.DateClotureTVADateTimePicker.Value = CDate(doss.DDtDebEx)
                Me.DateClotureTVADateTimePicker.Checked = False
            End If
        Else
            MsgBox("Date de début et/ou de fin d'exercice non définie pour le dossier en cours. Traitement impossible.", MsgBoxStyle.Critical, "")

            Me.Close()
        End If
    End Sub

    Private Sub SetDDtClotureTVA()
        Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
        Dim doss As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(My.User.Name)

        If (Me.DateClotureTVADateTimePicker.Checked) Then
            gestDoss.UpdateDDtClotureTVA(CDate(CType(String.Format("{0:dd/MM/yyyy}", Me.DateClotureTVADateTimePicker.Value), Global.System.Nullable(Of Date))), My.User.Name)
        Else
            gestDoss.UpdateDDtClotureTVA(DateTime.MinValue, My.User.Name)
        End If
    End Sub
#End Region

End Class