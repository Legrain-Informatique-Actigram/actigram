Imports CrystalDecisions.CrystalReports.Engine

Public Class FrSimulAmort

    Dim dv As DataView
    Dim tb As DataTable
    Dim classe As Integer
    Dim keepclasse As Integer
    Dim NumAnnee As Integer
    Private Const NB_ANNEE As Integer = 5

    Private _ImmobilisationsDS As ImmobilisationsDataSet

    Dim keepValOrigNImmo(NB_ANNEE - 1) As Decimal
    Dim keepAmtMaxNImmo(NB_ANNEE - 1) As Decimal
    Dim keepAmtMinNImmo(NB_ANNEE - 1) As Decimal
    Dim keepMaxResidNImmo(NB_ANNEE - 1) As Decimal
    Dim keepMinResidNImmo(NB_ANNEE - 1) As Decimal

    Dim keepValOrigNSubv(NB_ANNEE - 1) As Decimal
    Dim keepAmtMaxNSubv(NB_ANNEE - 1) As Decimal
    Dim keepAmtMinNSubv(NB_ANNEE - 1) As Decimal
    Dim keepMaxResidNSubv(NB_ANNEE - 1) As Decimal
    Dim keepMinResidNSubv(NB_ANNEE - 1) As Decimal

    Enum TypeCalculAmort
        Max
        Min
    End Enum

#Region "Constructeurs"
    Public Sub New(ByVal immobilisationsDS As ImmobilisationsDataSet)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._ImmobilisationsDS = immobilisationsDS
    End Sub
#End Region

#Region "Form"
    Private Sub FrSimulAmort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim immobilisationsDT As ImmobilisationsDataSet.ImmobilisationsDataTable = CType(Me._ImmobilisationsDS.Immobilisations.Copy, ImmobilisationsDataSet.ImmobilisationsDataTable)

        Me.InitDatatable()

        Dim strClasse As String = String.Empty
        Dim listeImmobilisationsDR() As ImmobilisationsDataSet.ImmobilisationsRow = CType(immobilisationsDT.Select("ICpt<'29000000'", "Icpt,IActi,IOrdre"), ImmobilisationsDataSet.ImmobilisationsRow())

        For Each immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow In listeImmobilisationsDR
            If (strClasse <> immobilisationsDR.ICpt.Substring(0, 4)) Then
                strClasse = immobilisationsDR.ICpt.Substring(0, 4)

                Dim filterClasse As String = "substring(ICpt,1,4)='" & strClasse & "'"

                Dim rwN As DataRow = tb.NewRow

                With rwN
                    .Item("IDossier") = My.User.Name
                    .Item("Compte") = immobilisationsDR.ICpt
                    .Item("Classe") = strClasse
                End With

                SimulAmorts(immobilisationsDT, filterClasse, rwN)

                tb.Rows.Add(rwN)

                If (Convert.ToString(rwN.Item("Compte")).Substring(0, 1) < "2") Then
                    TotalSubv(rwN)
                Else
                    TotalImmo(rwN)
                End If
            End If
        Next

        Me.dv = New DataView(tb)
        Me.BindingContext(dv).Position = 0

        Me.Databinding()

        Me.Panel3.Visible = False
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub InitDatatable()
        tb = New DataTable
        With tb.Columns
            .Add("IDossier", GetType(String))
            .Add("Classe", GetType(String))
            .Add("Compte", GetType(String))

            .Add("ValOrigAnnee1", GetType(Decimal))
            .Add("ValOrigAnnee2", GetType(Decimal))
            For i As Integer = 1 To NB_ANNEE
                .Add("AmortMaxAnnee" & i, GetType(Decimal))
                .Add("AmortMinAnnee" & i, GetType(Decimal))
                .Add("AmortResidMaxAnnee" & i, GetType(Decimal))
                .Add("AmortResidMinAnnee" & i, GetType(Decimal))
            Next
        End With
    End Sub

    Private Sub SimulAmorts(ByVal immobilisationsDT As ImmobilisationsDataSet.ImmobilisationsDataTable, _
                            ByVal filterClasse As String, ByVal drResultat As DataRow)
        'Calculer en hypothèse MIN
        SimulAmorts(immobilisationsDT, filterClasse, drResultat, TypeCalculAmort.Min)
        'Calculer en hypothèse MAX
        SimulAmorts(immobilisationsDT, filterClasse, drResultat, TypeCalculAmort.Max)
    End Sub

    Private Sub SimulAmorts(ByVal immobilisationsDT As ImmobilisationsDataSet.ImmobilisationsDataTable, _
                            ByVal filterClasse As String, ByVal drResultat As DataRow, ByVal h As TypeCalculAmort)

        Dim immobilisationsCopyDT As ImmobilisationsDataSet.ImmobilisationsDataTable = CType(immobilisationsDT.Copy, ImmobilisationsDataSet.ImmobilisationsDataTable)
        Dim dvImmos As New DataView(immobilisationsCopyDT, filterClasse, "", DataViewRowState.CurrentRows)
        Dim dtDeb As Date = My.Dossier.Principal.DateDebutEx
        Dim dtFin As Date = My.Dossier.Principal.DateFinEx
        Dim mode As Immobilisations.Immobilisation.ModeImmo = Immobilisations.Immobilisation.ModeImmo.Calcul

        For i As Integer = 1 To NB_ANNEE
            Dim gestionImmo As New Immobilisations.Immobilisation(mode)
            Dim valAcquis As Decimal = 0
            Dim amt As Decimal = 0
            Dim amtResid As Decimal = 0

            For Each drv As DataRowView In dvImmos
                If IsDBNull(drv("IDtCess")) OrElse CDate(drv("IDtCess")) > dtDeb Then
                    gestionImmo.CalculerDonneesAmort(drv)
                    'On choisis l'amortissement qui correspond à l'hypothèse
                    drv("IAmtExTot") = drv("IAmtEx" & h.ToString)
                    'Cumuler les résultats
                    valAcquis = valAcquis + CDec(drv("IValAcquis"))
                    amt = amt + CDec(drv("IAmtExTot"))
                    amtResid = amtResid + CDec(drv("IValAcquis")) - (CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot")))
                End If
            Next

            'Enregistrement des résultats dans le datarow
            drResultat("ValOrigAnnee" & Math.Min(i, 2)) = valAcquis
            drResultat(String.Format("Amort{0}Annee{1}", h, i)) = amt
            drResultat(String.Format("AmortResid{0}Annee{1}", h, i)) = amtResid
            dtDeb = dtFin.AddDays(1)
            dtFin = dtFin.AddMonths(12)
            mode = Immobilisations.Immobilisation.ModeImmo.Cloture
        Next
    End Sub

    Private Sub TotalSubv(ByVal rwN As DataRow)
        For i As Integer = 1 To NB_ANNEE
            keepValOrigNSubv(i - 1) = keepValOrigNSubv(i - 1) + CDec(rwN.Item("ValOrigAnnee" & Math.Min(i, 2)))
            keepAmtMaxNSubv(i - 1) = keepAmtMaxNSubv(i - 1) + CDec(rwN.Item("AmortMaxAnnee" & i))
            keepAmtMinNSubv(i - 1) = keepAmtMinNSubv(i - 1) + Math.Max(0, CDec(rwN.Item("AmortMinAnnee" & i)))
            keepMaxResidNSubv(i - 1) = keepMaxResidNSubv(i - 1) + CDec(rwN.Item("AmortResidMaxAnnee" & i))
            keepMinResidNSubv(i - 1) = keepMinResidNSubv(i - 1) + Math.Max(0, CDec(rwN.Item("AmortResidMinAnnee" & i)))
        Next
    End Sub

    Private Sub TotalImmo(ByVal rwN As DataRow)
        For i As Integer = 1 To NB_ANNEE
            keepValOrigNImmo(i - 1) = keepValOrigNImmo(i - 1) + CDec(rwN.Item("ValOrigAnnee" & Math.Min(i, 2)))
            keepAmtMaxNImmo(i - 1) = keepAmtMaxNImmo(i - 1) + CDec(rwN.Item("AmortMaxAnnee" & i))
            keepAmtMinNImmo(i - 1) = keepAmtMinNImmo(i - 1) + Math.Max(0, CDec(rwN.Item("AmortMinAnnee" & i)))
            keepMaxResidNImmo(i - 1) = keepMaxResidNImmo(i - 1) + CDec(rwN.Item("AmortResidMaxAnnee" & i))
            keepMinResidNImmo(i - 1) = keepMinResidNImmo(i - 1) + Math.Max(0, CDec(rwN.Item("AmortResidMinAnnee" & i)))
        Next
    End Sub

    Private Sub Databinding()
        ConfigCurrency(Me.ValOrigNLabel, "ValOrigAnnee1")
        ConfigCurrency(Me.ValOrigN1Label, "ValOrigAnnee2")
        ConfigCurrency(Me.ValOrigN2Label, "ValOrigAnnee2")
        ConfigCurrency(Me.ValOrigN3Label, "ValOrigAnnee2")
        ConfigCurrency(Me.ValOrigN4Label, "ValOrigAnnee2")

        ConfigCurrency(Me.MaxAmtExNLabel, "AmortMaxAnnee1")
        ConfigCurrency(Me.MaxAmtExN1Label, "AmortMaxAnnee2")
        ConfigCurrency(Me.MaxAmtExN2Label, "AmortMaxAnnee3")
        ConfigCurrency(Me.MaxAmtExN3Label, "AmortMaxAnnee4")
        ConfigCurrency(Me.MaxAmtExN4Label, "AmortMaxAnnee5")

        ConfigCurrency(Me.MinAmtExNLabel, "AmortMinAnnee1")
        ConfigCurrency(Me.MinAmtExN1Label, "AmortMinAnnee2")
        ConfigCurrency(Me.MinAmtExN2Label, "AmortMinAnnee3")
        ConfigCurrency(Me.MinAmtExN3Label, "AmortMinAnnee4")
        ConfigCurrency(Me.MinAmtExN4Label, "AmortMinAnnee5")

        ConfigCurrency(Me.MinValResidNLabel, "AmortResidMinAnnee1")
        ConfigCurrency(Me.MinValResidN1Label, "AmortResidMinAnnee2")
        ConfigCurrency(Me.MinValResidN2Label, "AmortResidMinAnnee3")
        ConfigCurrency(Me.MinValResidN3Label, "AmortResidMinAnnee4")
        ConfigCurrency(Me.MinValResidN4Label, "AmortResidMinAnnee5")

        ConfigCurrency(Me.MaxValResidNLabel, "AmortResidMaxAnnee1")
        ConfigCurrency(Me.MaxValResidN1Label, "AmortResidMaxAnnee2")
        ConfigCurrency(Me.MaxValResidN2Label, "AmortResidMaxAnnee3")
        ConfigCurrency(Me.MaxValResidN3Label, "AmortResidMaxAnnee4")
        ConfigCurrency(Me.MaxValResidN4Label, "AmortResidMaxAnnee5")


        Me.TotImmoLabel.DataBindings.Add("Text", dv, "Classe")

        If (Me.TotImmoLabel.Text.Substring(0, 1) < "2") Then
            Me.TotalToolStripButton.Text = "Total subventions"
        Else
            Me.TotalToolStripButton.Text = "Total immobilisations"
        End If
    End Sub

    Private Sub ConfigCurrency(ByVal ctl As Control, ByVal dataMember As String)
        Dim b As New FormatBinding("Text", Me.dv, dataMember, "C2", 0)
        'AddHandler b.Parse, AddressOf CurrencyParse
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub AfficheTotal()
        If Me.TotalToolStripButton.Text = "Total Subventions" Then
            Me.TotOrigNLabel.Text = String.Format("{0:C2}", keepValOrigNSubv(0))
            Me.TotOrigN1Label.Text = String.Format("{0:C2}", keepValOrigNSubv(1))
            Me.TotOrigN2Label.Text = String.Format("{0:C2}", keepValOrigNSubv(2))
            Me.TotOrigN3Label.Text = String.Format("{0:C2}", keepValOrigNSubv(3))
            Me.TotOrigN4Label.Text = String.Format("{0:C2}", keepValOrigNSubv(4))
            Me.TotMaxNLabel.Text = String.Format("{0:C2}", keepAmtMaxNSubv(0))
            Me.TotMaxN1Label.Text = String.Format("{0:C2}", keepAmtMaxNSubv(1))
            Me.TotMaxN2Label.Text = String.Format("{0:C2}", keepAmtMaxNSubv(2))
            Me.TotMaxN3Label.Text = String.Format("{0:C2}", keepAmtMaxNSubv(3))
            Me.TotMaxN4Label.Text = String.Format("{0:C2}", keepAmtMaxNSubv(4))
            Me.TotMinNLabel.Text = String.Format("{0:C2}", keepAmtMinNSubv(0))
            Me.TotMinN1Label.Text = String.Format("{0:C2}", keepAmtMinNSubv(1))
            Me.TotMinN2Label.Text = String.Format("{0:C2}", keepAmtMinNSubv(2))
            Me.TotMinN3Label.Text = String.Format("{0:C2}", keepAmtMinNSubv(3))
            Me.TotMinN4Label.Text = String.Format("{0:C2}", keepAmtMinNSubv(4))
            Me.TotResidMinNLabel.Text = String.Format("{0:C2}", keepMaxResidNSubv(0))
            Me.TotResidMinN1Label.Text = String.Format("{0:C2}", keepMaxResidNSubv(1))
            Me.TotResidMinN2Label.Text = String.Format("{0:C2}", keepMaxResidNSubv(2))
            Me.TotResidMinN3Label.Text = String.Format("{0:C2}", keepMaxResidNSubv(3))
            Me.TotResidMinN4Label.Text = String.Format("{0:C2}", keepMaxResidNSubv(4))
            Me.TotResidMaxNLabel.Text = String.Format("{0:C2}", keepMinResidNSubv(0))
            Me.TotResidMaxN1Label.Text = String.Format("{0:C2}", keepMinResidNSubv(1))
            Me.TotResidMaxN2Label.Text = String.Format("{0:C2}", keepMinResidNSubv(2))
            Me.TotResidMaxN3Label.Text = String.Format("{0:C2}", keepMinResidNSubv(3))
            Me.TotResidMaxN4Label.Text = String.Format("{0:C2}", keepMinResidNSubv(4))
        Else
            Me.TotOrigNLabel.Text = String.Format("{0:C2}", keepValOrigNImmo(0))
            Me.TotOrigN1Label.Text = String.Format("{0:C2}", keepValOrigNImmo(1))
            Me.TotOrigN2Label.Text = String.Format("{0:C2}", keepValOrigNImmo(2))
            Me.TotOrigN3Label.Text = String.Format("{0:C2}", keepValOrigNImmo(3))
            Me.TotOrigN4Label.Text = String.Format("{0:C2}", keepValOrigNImmo(4))
            Me.TotMaxNLabel.Text = String.Format("{0:C2}", keepAmtMaxNImmo(0))
            Me.TotMaxN1Label.Text = String.Format("{0:C2}", keepAmtMaxNImmo(1))
            Me.TotMaxN2Label.Text = String.Format("{0:C2}", keepAmtMaxNImmo(2))
            Me.TotMaxN3Label.Text = String.Format("{0:C2}", keepAmtMaxNImmo(3))
            Me.TotMaxN4Label.Text = String.Format("{0:C2}", keepAmtMaxNImmo(4))
            Me.TotMinNLabel.Text = String.Format("{0:C2}", keepAmtMinNImmo(0))
            Me.TotMinN1Label.Text = String.Format("{0:C2}", keepAmtMinNImmo(1))
            Me.TotMinN2Label.Text = String.Format("{0:C2}", keepAmtMinNImmo(2))
            Me.TotMinN3Label.Text = String.Format("{0:C2}", keepAmtMinNImmo(3))
            Me.TotMinN4Label.Text = String.Format("{0:C2}", keepAmtMinNImmo(4))
            Me.TotResidMaxNLabel.Text = String.Format("{0:C2}", keepMaxResidNImmo(0))
            Me.TotResidMaxN1Label.Text = String.Format("{0:C2}", keepMaxResidNImmo(1))
            Me.TotResidMaxN2Label.Text = String.Format("{0:C2}", keepMaxResidNImmo(2))
            Me.TotResidMaxN3Label.Text = String.Format("{0:C2}", keepMaxResidNImmo(3))
            Me.TotResidMaxN4Label.Text = String.Format("{0:C2}", keepMaxResidNImmo(4))
            Me.TotResidMinNLabel.Text = String.Format("{0:C2}", keepMinResidNImmo(0))
            Me.TotResidMinN1Label.Text = String.Format("{0:C2}", keepMinResidNImmo(1))
            Me.TotResidMinN2Label.Text = String.Format("{0:C2}", keepMinResidNImmo(2))
            Me.TotResidMinN3Label.Text = String.Format("{0:C2}", keepMinResidNImmo(3))
            Me.TotResidMinN4Label.Text = String.Format("{0:C2}", keepMinResidNImmo(4))
        End If
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub MovePreviousToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovePreviousToolStripButton.Click
        If Me.BindingContext(dv).Position > 0 Then
            Me.BindingContext(dv).Position -= 1
            If (Me.TotImmoLabel.Text.Substring(0, 1) < "2") Then
                Me.TotalToolStripButton.Text = "Total Subventions"
            Else
                Me.TotalToolStripButton.Text = "Total Immobilisations"
            End If
        End If
    End Sub

    Private Sub MoveNextToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveNextToolStripButton.Click
        If Me.BindingContext(dv).Position <> -1 Then
            Me.BindingContext(dv).Position += 1
            If (Me.TotImmoLabel.Text.Substring(0, 1) < "2") Then
                Me.TotalToolStripButton.Text = "Total Subventions"
            Else
                Me.TotalToolStripButton.Text = "Total Immobilisations"
            End If
        End If
    End Sub

    Private Sub TotalToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalToolStripButton.Click
        If (Me.TotalToolStripButton.Text <> "Retour simulation") Then
            Me.Panel3.Visible = True
            Me.TotImmoLabel.Visible = False
            Me.AfficheTotal()
            Me.TotalToolStripButton.Text = "Retour simulation"
            Me.MoveNextToolStripButton.Enabled = False
            Me.MovePreviousToolStripButton.Enabled = False
        Else
            TotImmoLabel.Visible = True
            Me.Panel3.Visible = False

            If Me.TotImmoLabel.Text.Substring(0, 1) < "2" Then
                Me.TotalToolStripButton.Text = "Total Subventions"
            Else
                Me.TotalToolStripButton.Text = "Total immobilisations"
            End If

            Me.MoveNextToolStripButton.Enabled = True
            Me.MovePreviousToolStripButton.Enabled = True
        End If
    End Sub

    Private Sub Imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer.Click
        Using report As ReportDocument = Immobilisations.ImprImmo.PrepareRpt(Me.tb, Immobilisations.ImprImmo.TypeRptImmo.SimulAmort)
            Immobilisations.ImprImmo.AffichDonneesGen(report)

            Using fr As New EcranCrystal(report)
                fr.ShowDialog()
            End Using
        End Using
    End Sub
#End Region

End Class