Imports CrystalDecisions.CrystalReports.Engine

Public Class EcranCrystal
    Dim oRpt As ReportDocument

    Public Sub New(ByVal momEtat As ReportDocument)
        Me.New()
        oRpt = momEtat
    End Sub

    Private Sub FrFusion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.rptViewer.ReportSource = oRpt
    End Sub
End Class
