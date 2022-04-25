Imports CrystalDecisions.CrystalReports.Engine

Public Class FrImpImmo

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.RecapClasseCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.RecapImmoParClasse)
        End If

        If (Me.TabImmoCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabImmo)
        End If

        If (Me.TabImmoActCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabImmoParAct)
        End If

        If (Me.TabDepImmoCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabDepartImmo)
        End If

        If (Me.TabCessCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabCessionImmo)
        End If

        If (Me.AmortDegCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabAmortDerog)
        End If

        If (Me.PassReelCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.PassageReel)
        End If

        If (Me.CalProvCheckBox.Checked) Then
            Immobilisations.ImprImmo.PrintRpt(Immobilisations.ImprImmo.TypeRptImmo.TabCalculsProv)
        End If
    End Sub
#End Region

End Class