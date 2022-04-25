Imports System.Data.SqlClient

Public Class FrAccueil

    Public Enum ModeTaux
        HtToTva
        HtToTtc
        TtcToTva
        TtcToHt
    End Enum

    Private texteCompteRendu As New System.Text.StringBuilder

#Region "Form"
    Private Sub FrAccueil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.InitialiserForm()
    End Sub
#End Region

#Region "Boutons"
    Private Sub ButtonLancerRecalcul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLancerRecalcul.Click
        Me.texteCompteRendu = New System.Text.StringBuilder

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LabelStatut.Visible = True
            Me.ProgressBar1.Visible = True
            Application.DoEvents()

            If (Me.CheckBoxDevisV.Checked) Then
                Me.RecalculerDevisFacturationHT()
                Me.RecalculerDevisFacturationTTC()
            End If

            If (Me.CheckBoxBCV.Checked) Then
                Me.RecalculerBCFacturationHT()
                Me.RecalculerBCFacturationTTC()
            End If

            If (Me.CheckBoxBLV.Checked) Then
                Me.RecalculerBLFacturationHT()
                Me.RecalculerBLFacturationTTC()
            End If

            If (Me.CheckBoxFacturesV.Checked) Then
                Me.RecalculerFacturesFacturationHT()
                Me.RecalculerFacturesFacturationTTC()
            End If

            Me.TextBoxCompteRendu.Text = Me.texteCompteRendu.ToString().Trim()
        Finally
            Me.LabelStatut.Visible = False
            Me.ProgressBar1.Visible = False
            Me.Cursor = Cursors.Default
        End Try

        'Try
        '    Cursor.Current = Cursors.WaitCursor
        '    Me.ProgressBar1.Visible = True
        '    Application.DoEvents()

        '    Me.LancerRecalculPiecesVente()

        '    MsgBox("Traitement terminé.", MsgBoxStyle.Information, "")
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'Finally
        '    Me.ProgressBar1.Visible = False
        '    Cursor.Current = Cursors.Default
        'End Try
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub InitialiserForm()
        Me.ProgressBar1.Visible = False
        Me.LabelStatut.Text = ""
        Me.LabelStatut.Visible = False
        Me.CheckBoxDevisV.Checked = True
        Me.CheckBoxBCV.Checked = True
        Me.CheckBoxBLV.Checked = True
        Me.CheckBoxFacturesV.Checked = True
    End Sub

    Private Sub RecalculerDevisFacturationTTC()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul devis Facturation TTC"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VDevisDA As New DataSetAgrifactTableAdapters.VDevisTableAdapter
            Using VDevisDetailDA As New DataSetAgrifactTableAdapters.VDevis_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement facturationTTC = 1
                    Dim VDevisDT As DataSetAgrifact.VDevisDataTable = VDevisDA.GetDataByFacturationTTC(True)

                    For Each VDevisDR As DataSetAgrifact.VDevisRow In VDevisDT.Rows
                        Dim VDevisDetailDT As DataSetAgrifact.VDevis_DetailDataTable = VDevisDetailDA.GetDataBynDevis(VDevisDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VDevisDetailDR As DataSetAgrifact.VDevis_DetailRow In VDevisDetailDT.Rows
                            If Not (VDevisDetailDR.IsMontantLigneTTCNull) Then
                                If Not (VDevisDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VDevisDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VDevisDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VDevisDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VDevisDetailDR.MontantLigneTTC
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VDevisDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VDevisDetailDR.MontantLigneTTC
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantTTCTotal = montantTTCTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key / (1 + kvp.Key), 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantHTTotal = montantTTCTotal - montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VDevisDR.IsMontantHTNull) Then
                            ancienMontantHT = VDevisDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VDevisDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VDevisDR.IsMontantTVANull) Then
                            ancienMontantTVA = VDevisDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VDevisDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VDevisDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VDevisDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VDevisDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("Devis {0} : ", VDevisDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VDevisDR.MontantHT = montantHTTotal
                            VDevisDR.MontantTVA = montantTVAToTal
                            VDevisDR.MontantTTC = montantTTCTotal

                            VDevisDA.Update(VDevisDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VDevisDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerDevisFacturationHT()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul devis Facturation HT"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VDevisDA As New DataSetAgrifactTableAdapters.VDevisTableAdapter
            Using VDevisDetailDA As New DataSetAgrifactTableAdapters.VDevis_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement des factures facturationTTC = 1
                    Dim VDevisDT As DataSetAgrifact.VDevisDataTable = VDevisDA.GetDataByFacturationTTC(False)

                    For Each VDevisDR As DataSetAgrifact.VDevisRow In VDevisDT.Rows
                        Dim VDevisDetailDT As DataSetAgrifact.VDevis_DetailDataTable = VDevisDetailDA.GetDataBynDevis(VDevisDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VDevisDetailDR As DataSetAgrifact.VDevis_DetailRow In VDevisDetailDT.Rows
                            If Not (VDevisDetailDR.IsMontantLigneHTNull) Then
                                If Not (VDevisDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VDevisDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VDevisDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VDevisDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VDevisDetailDR.MontantLigneHT
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VDevisDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VDevisDetailDR.MontantLigneHT
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantHTTotal = montantHTTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key, 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantTTCTotal = montantHTTotal + montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VDevisDR.IsMontantHTNull) Then
                            ancienMontantHT = VDevisDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VDevisDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VDevisDR.IsMontantTVANull) Then
                            ancienMontantTVA = VDevisDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VDevisDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VDevisDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VDevisDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VDevisDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("Devis {0} : ", VDevisDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VDevisDR.MontantHT = montantHTTotal
                            VDevisDR.MontantTVA = montantTVAToTal
                            VDevisDR.MontantTTC = montantTTCTotal

                            VDevisDA.Update(VDevisDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VDevisDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerBCFacturationTTC()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul BC Facturation TTC"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VBonCommandeDA As New DataSetAgrifactTableAdapters.VBonCommandeTableAdapter
            Using VBonCommandeDetailDA As New DataSetAgrifactTableAdapters.VBonCommande_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement facturationTTC = 1
                    Dim VBonCommandeDT As DataSetAgrifact.VBonCommandeDataTable = VBonCommandeDA.GetDataByFacturationTTC(True)

                    For Each VBonCommandeDR As DataSetAgrifact.VBonCommandeRow In VBonCommandeDT.Rows
                        Dim VBonCommandeDetailDT As DataSetAgrifact.VBonCommande_DetailDataTable = VBonCommandeDetailDA.GetDataBynDevis(VBonCommandeDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VBonCommandeDetailDR As DataSetAgrifact.VBonCommande_DetailRow In VBonCommandeDetailDT.Rows
                            If Not (VBonCommandeDetailDR.IsMontantLigneTTCNull) Then
                                If Not (VBonCommandeDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VBonCommandeDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VBonCommandeDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VBonCommandeDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VBonCommandeDetailDR.MontantLigneTTC
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VBonCommandeDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VBonCommandeDetailDR.MontantLigneTTC
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantTTCTotal = montantTTCTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key / (1 + kvp.Key), 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantHTTotal = montantTTCTotal - montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantHTNull) Then
                            ancienMontantHT = VBonCommandeDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VBonCommandeDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantTVANull) Then
                            ancienMontantTVA = VBonCommandeDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VBonCommandeDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VBonCommandeDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VBonCommandeDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("BC {0} : ", VBonCommandeDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VBonCommandeDR.MontantHT = montantHTTotal
                            VBonCommandeDR.MontantTVA = montantTVAToTal
                            VBonCommandeDR.MontantTTC = montantTTCTotal

                            VBonCommandeDA.Update(VBonCommandeDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VBonCommandeDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerBCFacturationHT()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul BC Facturation HT"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VBonCommandeDA As New DataSetAgrifactTableAdapters.VBonCommandeTableAdapter
            Using VBonCommandeDetailDA As New DataSetAgrifactTableAdapters.VBonCommande_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement des factures facturationTTC = 1
                    Dim VBonCommandeDT As DataSetAgrifact.VBonCommandeDataTable = VBonCommandeDA.GetDataByFacturationTTC(False)

                    For Each VBonCommandeDR As DataSetAgrifact.VBonCommandeRow In VBonCommandeDT.Rows
                        Dim VBonCommandeDetailDT As DataSetAgrifact.VBonCommande_DetailDataTable = VBonCommandeDetailDA.GetDataBynDevis(VBonCommandeDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VBonCommandeDetailDR As DataSetAgrifact.VBonCommande_DetailRow In VBonCommandeDetailDT.Rows
                            If Not (VBonCommandeDetailDR.IsMontantLigneHTNull) Then
                                If Not (VBonCommandeDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VBonCommandeDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VBonCommandeDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VBonCommandeDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VBonCommandeDetailDR.MontantLigneHT
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VBonCommandeDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VBonCommandeDetailDR.MontantLigneHT
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantHTTotal = montantHTTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key, 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantTTCTotal = montantHTTotal + montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantHTNull) Then
                            ancienMontantHT = VBonCommandeDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VBonCommandeDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantTVANull) Then
                            ancienMontantTVA = VBonCommandeDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VBonCommandeDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VBonCommandeDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VBonCommandeDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VBonCommandeDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("BC {0} : ", VBonCommandeDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VBonCommandeDR.MontantHT = montantHTTotal
                            VBonCommandeDR.MontantTVA = montantTVAToTal
                            VBonCommandeDR.MontantTTC = montantTTCTotal

                            VBonCommandeDA.Update(VBonCommandeDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VBonCommandeDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerBLFacturationTTC()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul BL Facturation TTC"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VBonLivraisonDA As New DataSetAgrifactTableAdapters.VBonLivraisonTableAdapter
            Using VBonLivraisonDetailDA As New DataSetAgrifactTableAdapters.VBonLivraison_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement facturationTTC = 1
                    Dim VBonLivraisonDT As DataSetAgrifact.VBonLivraisonDataTable = VBonLivraisonDA.GetDataByFacturationTTC(True)

                    For Each VBonLivraisonDR As DataSetAgrifact.VBonLivraisonRow In VBonLivraisonDT.Rows
                        Dim VBonLivraisonDetailDT As DataSetAgrifact.VBonLivraison_DetailDataTable = VBonLivraisonDetailDA.GetDataBynDevis(VBonLivraisonDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VBonLivraisonDetailDR As DataSetAgrifact.VBonLivraison_DetailRow In VBonLivraisonDetailDT.Rows
                            If Not (VBonLivraisonDetailDR.IsMontantLigneTTCNull) Then
                                If Not (VBonLivraisonDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VBonLivraisonDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VBonLivraisonDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VBonLivraisonDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VBonLivraisonDetailDR.MontantLigneTTC
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VBonLivraisonDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VBonLivraisonDetailDR.MontantLigneTTC
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantTTCTotal = montantTTCTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key / (1 + kvp.Key), 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantHTTotal = montantTTCTotal - montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantHTNull) Then
                            ancienMontantHT = VBonLivraisonDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VBonLivraisonDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantTVANull) Then
                            ancienMontantTVA = VBonLivraisonDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VBonLivraisonDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VBonLivraisonDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VBonLivraisonDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("BL {0} : ", VBonLivraisonDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VBonLivraisonDR.MontantHT = montantHTTotal
                            VBonLivraisonDR.MontantTVA = montantTVAToTal
                            VBonLivraisonDR.MontantTTC = montantTTCTotal

                            VBonLivraisonDA.Update(VBonLivraisonDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VBonLivraisonDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerBLFacturationHT()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul BL Facturation HT"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VBonLivraisonDA As New DataSetAgrifactTableAdapters.VBonLivraisonTableAdapter
            Using VBonLivraisonDetailDA As New DataSetAgrifactTableAdapters.VBonLivraison_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement des factures facturationTTC = 1
                    Dim VBonLivraisonDT As DataSetAgrifact.VBonLivraisonDataTable = VBonLivraisonDA.GetDataByFacturationTTC(False)

                    For Each VBonLivraisonDR As DataSetAgrifact.VBonLivraisonRow In VBonLivraisonDT.Rows
                        Dim VBonLivraisonDetailDT As DataSetAgrifact.VBonLivraison_DetailDataTable = VBonLivraisonDetailDA.GetDataBynDevis(VBonLivraisonDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VBonLivraisonDetailDR As DataSetAgrifact.VBonLivraison_DetailRow In VBonLivraisonDetailDT.Rows
                            If Not (VBonLivraisonDetailDR.IsMontantLigneHTNull) Then
                                If Not (VBonLivraisonDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VBonLivraisonDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VBonLivraisonDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VBonLivraisonDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VBonLivraisonDetailDR.MontantLigneHT
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VBonLivraisonDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VBonLivraisonDetailDR.MontantLigneHT
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantHTTotal = montantHTTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key, 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantTTCTotal = montantHTTotal + montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantHTNull) Then
                            ancienMontantHT = VBonLivraisonDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VBonLivraisonDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantTVANull) Then
                            ancienMontantTVA = VBonLivraisonDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VBonLivraisonDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VBonLivraisonDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VBonLivraisonDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VBonLivraisonDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("BL {0} : ", VBonLivraisonDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour
                            VBonLivraisonDR.MontantHT = montantHTTotal
                            VBonLivraisonDR.MontantTVA = montantTVAToTal
                            VBonLivraisonDR.MontantTTC = montantTTCTotal

                            VBonLivraisonDA.Update(VBonLivraisonDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VBonLivraisonDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerFacturesFacturationTTC()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul factures Facturation TTC"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VFactureDA As New DataSetAgrifactTableAdapters.VFactureTableAdapter
            Using VFactureDetailDA As New DataSetAgrifactTableAdapters.VFacture_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement des factures facturationTTC = 1
                    Dim VFactureDT As DataSetAgrifact.VFactureDataTable = VFactureDA.GetDataByFacturationTTC(True)

                    For Each VFactureDR As DataSetAgrifact.VFactureRow In VFactureDT.Rows
                        Dim VFactureDetailDT As DataSetAgrifact.VFacture_DetailDataTable = VFactureDetailDA.GetDataBynDevis(VFactureDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VFactureDetailDR As DataSetAgrifact.VFacture_DetailRow In VFactureDetailDT.Rows
                            If Not (VFactureDetailDR.IsMontantLigneTTCNull) Then
                                If Not (VFactureDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VFactureDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VFactureDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VFactureDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VFactureDetailDR.MontantLigneTTC
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VFactureDetailDR.MontantLigneTTC)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VFactureDetailDR.MontantLigneTTC
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantTTCTotal = montantTTCTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key / (1 + kvp.Key), 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantHTTotal = montantTTCTotal - montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VFactureDR.IsMontantHTNull) Then
                            ancienMontantHT = VFactureDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VFactureDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VFactureDR.IsMontantTVANull) Then
                            ancienMontantTVA = VFactureDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VFactureDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VFactureDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VFactureDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VFactureDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("Facture {0} : ", VFactureDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour de la facture
                            VFactureDR.MontantHT = montantHTTotal
                            VFactureDR.MontantTVA = montantTVAToTal
                            VFactureDR.MontantTTC = montantTTCTotal

                            VFactureDA.Update(VFactureDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VFactureDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub RecalculerFacturesFacturationHT()
        Dim i As Integer = 0

        Me.LabelStatut.Text = "Recalcul factures Facturation HT"
        Me.ProgressBar1.Value = 0
        Application.DoEvents()

        Using VFactureDA As New DataSetAgrifactTableAdapters.VFactureTableAdapter
            Using VFactureDetailDA As New DataSetAgrifactTableAdapters.VFacture_DetailTableAdapter
                Using tvaTA As New DataSetAgrifactTableAdapters.TVATableAdapter
                    'Traitement des factures facturationTTC = 1
                    Dim VFactureDT As DataSetAgrifact.VFactureDataTable = VFactureDA.GetDataByFacturationTTC(False)

                    For Each VFactureDR As DataSetAgrifact.VFactureRow In VFactureDT.Rows
                        Dim VFactureDetailDT As DataSetAgrifact.VFacture_DetailDataTable = VFactureDetailDA.GetDataBynDevis(VFactureDR.nDevis)
                        Dim recapTVA As New Dictionary(Of Decimal, Decimal)

                        For Each VFactureDetailDR As DataSetAgrifact.VFacture_DetailRow In VFactureDetailDT.Rows
                            If Not (VFactureDetailDR.IsMontantLigneHTNull) Then
                                If Not (VFactureDetailDR.IsTTVANull) Then
                                    'Récupération du taux de TVA
                                    Dim txTVA As Decimal = 0

                                    If Not (VFactureDetailDR.TTVA = String.Empty) Then
                                        Dim tvaDT As DataSetAgrifact.TVADataTable = tvaTA.GetDataByTTVA(VFactureDetailDR.TTVA)

                                        If (tvaDT.Rows.Count > 0) Then
                                            Dim tvaDR As DataSetAgrifact.TVARow = tvaDT.Rows(0)

                                            If Not (tvaDR.IsTTauxNull) Then
                                                txTVA = tvaDR.TTaux / 100
                                            End If
                                        End If
                                    End If

                                    If Not (recapTVA.ContainsKey(txTVA)) Then
                                        recapTVA.Add(txTVA, VFactureDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(txTVA) = recapTVA.Item(txTVA) + VFactureDetailDR.MontantLigneHT
                                    End If
                                Else
                                    If Not (recapTVA.ContainsKey(0)) Then
                                        recapTVA.Add(0, VFactureDetailDR.MontantLigneHT)
                                    Else
                                        recapTVA.Item(0) = recapTVA.Item(0) + VFactureDetailDR.MontantLigneHT
                                    End If
                                End If
                            End If
                        Next

                        Dim montantTTCTotal As Decimal = 0
                        Dim montantTVAToTal As Decimal = 0
                        Dim montantHTTotal As Decimal = 0

                        For Each kvp As KeyValuePair(Of Decimal, Decimal) In recapTVA
                            montantHTTotal = montantHTTotal + kvp.Value

                            'Calcul de la TVA
                            montantTVAToTal = montantTVAToTal + Decimal.Round(kvp.Value * kvp.Key, 2, MidpointRounding.AwayFromZero)
                        Next kvp

                        montantTTCTotal = montantHTTotal + montantTVAToTal

                        Dim ancienMontantHT As Decimal = 0

                        If Not (VFactureDR.IsMontantHTNull) Then
                            ancienMontantHT = VFactureDR.MontantHT
                        End If

                        Dim diffMontantHT As Decimal = 0

                        diffMontantHT = VFactureDR.MontantHT - montantHTTotal

                        Dim ancienMontantTVA As Decimal = 0

                        If Not (VFactureDR.IsMontantTVANull) Then
                            ancienMontantTVA = VFactureDR.MontantTVA
                        End If

                        Dim diffMontantTVA As Decimal = 0

                        diffMontantTVA = VFactureDR.MontantTVA - montantTVAToTal

                        Dim ancienMontantTTC As Decimal = 0

                        If Not (VFactureDR.IsMontantTTCNull) Then
                            ancienMontantTTC = VFactureDR.MontantTTC
                        End If

                        Dim diffMontantTTC As Decimal = 0

                        diffMontantTTC = VFactureDR.MontantTTC - montantTTCTotal

                        If (diffMontantHT <> 0 Or diffMontantTVA <> 0 Or diffMontantTTC <> 0) Then
                            'Traitement Compte rendu
                            texteCompteRendu.Append(String.Format("Facture {0} : ", VFactureDR.nFacture))

                            If (diffMontantHT <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant HT traitée : {0}", diffMontantHT))
                            End If

                            If (diffMontantTVA <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TVA traitée : {0}", diffMontantTVA))
                            End If

                            If (diffMontantTTC <> 0) Then
                                texteCompteRendu.Append(String.Format(" Différence montant TTC traitée : {0}", diffMontantTTC))
                            End If

                            texteCompteRendu.Append(vbCrLf)

                            'Mise à jour de la facture
                            VFactureDR.MontantHT = montantHTTotal
                            VFactureDR.MontantTVA = montantTVAToTal
                            VFactureDR.MontantTTC = montantTTCTotal

                            VFactureDA.Update(VFactureDR)
                        End If

                        Me.ProgressBar1.Value = i * 100 \ VFactureDT.Rows.Count
                        Application.DoEvents()
                        i = i + 1
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub LancerRecalculPiecesVente()
        Dim connStringAgrifact As String = String.Empty

        connStringAgrifact = Me.SqlConnectionConfigAgrifact.ConnectionStringBuilder.ConnectionString

        'Vérification de la connexion définie
        If Not (Utilitaires.SqlProxy.TestConnection(connStringAgrifact)) Then
            MsgBox("Impossible de se connecter à la base de données.", MsgBoxStyle.Exclamation, "Connexion impossible")

            Exit Sub
        End If

        'Mise à jour des paramètres de connexion
        Utilitaires.BaseUtils.SetConnString("AgrifactConnectionString", connStringAgrifact)
        Utilitaires.BaseUtils.SetConnString("AgrifactConnectionStringUserOverride", connStringAgrifact)

        'Recalcul des montants des devis
        Me.RecalculerMontantsVDevis()

        'Recalcul des montants des bons de commande de vente
        Me.RecalculerMontantsVBonsCommande()

        'Recalcul des montants des bons de livraison
        Me.RecalculerMontantsVBonsLivraison()

        'Recalcul des montants des factures de vente
        Me.RecalculerMontantsVFactures()

    End Sub

    Private Sub RecalculerMontantsVDevis()
        Dim i As Integer = 0
        Dim VDevisDT As DataSetAgrifact.VDevisDataTable = Nothing

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            Dim sqlTrans As SqlTransaction

            sqlConn.Open()

            Using VDevisDA As New DataSetAgrifactTableAdapters.VDevisTableAdapter
                VDevisDT = VDevisDA.GetData()

                For Each VDevisDR As DataSetAgrifact.VDevisRow In VDevisDT.Rows
                    Dim facturationTTC As Boolean = False
                    Dim VDevisDetailDT As DataSetAgrifact.VDevis_DetailDataTable = Nothing
                    Dim cumulMontantsHT As Decimal = 0
                    Dim cumulMontantsTVA As Decimal = 0
                    Dim cumulMontantsTTC As Decimal = 0

                    sqlTrans = sqlConn.BeginTransaction

                    Try
                        VDevisDA.SetTransaction(sqlTrans)

                        If Not (VDevisDR.IsFacturationTTCNull) Then
                            facturationTTC = VDevisDR.FacturationTTC
                        End If

                        Using VDevisDetailDA As New DataSetAgrifactTableAdapters.VDevis_DetailTableAdapter
                            VDevisDetailDA.SetTransaction(sqlTrans)

                            VDevisDetailDT = VDevisDetailDA.GetDataBynDevis(VDevisDR.nDevis)

                            For Each VDevisDetailDR As DataSetAgrifact.VDevis_DetailRow In VDevisDetailDT.Rows
                                Dim ProduitDT As DataSetAgrifact.ProduitDataTable = Nothing
                                Dim typeFacturation As String = "U1"
                                Dim unite1 As Decimal = 0
                                Dim unite2 As Decimal = 0
                                Dim montantLigneHT As Decimal = 0
                                Dim montantLigneTTC As Decimal = 0
                                Dim montantLigneTVA As Decimal = 0
                                Dim txTVA As Decimal = 0

                                'Récupération du type de facturation défini au niveau du produit
                                Using ProduitDA As New DataSetAgrifactTableAdapters.ProduitTableAdapter
                                    ProduitDT = ProduitDA.GetDataByCodeProduit(VDevisDetailDR.CodeProduit)

                                    For Each ProduitDR As DataSetAgrifact.ProduitRow In ProduitDT.Rows
                                        If Not (ProduitDR.IsTypeFacturationNull) Then
                                            typeFacturation = ProduitDR.TypeFacturation
                                        End If
                                    Next
                                End Using

                                'Récupération de l'unité 1 
                                If Not (VDevisDetailDR.IsUnite1Null) Then
                                    unite1 = VDevisDetailDR.Unite1
                                End If

                                'Récupération de l'unité 2 
                                If Not (VDevisDetailDR.IsUnite2Null) Then
                                    unite2 = VDevisDetailDR.Unite2
                                End If

                                If Not (facturationTTC) Then
                                    'Calcul du montant HT de la ligne
                                    If Not (VDevisDetailDR.IsPrixUHTNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneHT = unite2 * VDevisDetailDR.PrixUHT
                                            Case "U1xU2" : montantLigneHT = unite1 * unite2 * VDevisDetailDR.PrixUHT
                                            Case Else : montantLigneHT = unite1 * VDevisDetailDR.PrixUHT
                                        End Select

                                        'Application de la remise
                                        If Not (VDevisDetailDR.IsRemiseNull) Then
                                            montantLigneHT = montantLigneHT * (1 - VDevisDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneHT, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Récupération du taux de TVA
                                        If Not (VDevisDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VDevisDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneHT * TransformTaux(txTVA, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VDevisDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VDevisDetailDR.nDetailDevis)
                                    End If
                                Else
                                    'Calcul du montant TTC de la ligne
                                    If Not (VDevisDetailDR.IsPrixUTTCNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneTTC = unite2 * VDevisDetailDR.PrixUTTC
                                            Case "U1xU2" : montantLigneTTC = unite1 * unite2 * VDevisDetailDR.PrixUTTC
                                            Case Else : montantLigneTTC = unite1 * VDevisDetailDR.PrixUTTC
                                        End Select

                                        'Application de la remise
                                        If Not (VDevisDetailDR.IsRemiseNull) Then
                                            montantLigneTTC = montantLigneTTC * (1 - VDevisDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneTTC, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Récupération du taux de TVA
                                        If Not (VDevisDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VDevisDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneTTC * TransformTaux(txTVA, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VDevisDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VDevisDetailDR.nDetailDevis)
                                    End If
                                End If
                            Next
                        End Using

                        'Mise à jour de la pièce
                        VDevisDA.UpdateMontants(cumulMontantsHT, cumulMontantsTVA, cumulMontantsTTC, VDevisDR.nDevis)

                        sqlTrans.Commit()
                    Catch ex As Exception
                        sqlTrans.Rollback()
                    End Try

                    Me.ProgressBar1.Value = i * 100 \ VDevisDT.Rows.Count
                    Application.DoEvents()
                    i = i + 1
                Next
            End Using
        End Using
    End Sub

    Private Sub RecalculerMontantsVBonsCommande()
        Dim i As Integer = 0
        Dim VBonCommandeDT As DataSetAgrifact.VBonCommandeDataTable = Nothing

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            Dim sqlTrans As SqlTransaction

            sqlConn.Open()

            Using VBonCommandeDA As New DataSetAgrifactTableAdapters.VBonCommandeTableAdapter
                VBonCommandeDT = VBonCommandeDA.GetData()

                For Each VBonCommandeDR As DataSetAgrifact.VBonCommandeRow In VBonCommandeDT.Rows
                    Dim facturationTTC As Boolean = False
                    Dim VBonCommandeDetailDT As DataSetAgrifact.VBonCommande_DetailDataTable = Nothing
                    Dim cumulMontantsHT As Decimal = 0
                    Dim cumulMontantsTVA As Decimal = 0
                    Dim cumulMontantsTTC As Decimal = 0

                    sqlTrans = sqlConn.BeginTransaction

                    Try
                        VBonCommandeDA.SetTransaction(sqlTrans)

                        If Not (VBonCommandeDR.IsFacturationTTCNull) Then
                            facturationTTC = VBonCommandeDR.FacturationTTC
                        End If

                        Using VBonCommandeDetailDA As New DataSetAgrifactTableAdapters.VBonCommande_DetailTableAdapter
                            VBonCommandeDetailDA.SetTransaction(sqlTrans)

                            VBonCommandeDetailDT = VBonCommandeDetailDA.GetDataBynDevis(VBonCommandeDR.nDevis)

                            For Each VBonCommandeDetailDR As DataSetAgrifact.VBonCommande_DetailRow In VBonCommandeDetailDT.Rows
                                Dim ProduitDT As DataSetAgrifact.ProduitDataTable = Nothing
                                Dim typeFacturation As String = "U1"
                                Dim unite1 As Decimal = 0
                                Dim unite2 As Decimal = 0
                                Dim montantLigneHT As Decimal = 0
                                Dim montantLigneTTC As Decimal = 0
                                Dim montantLigneTVA As Decimal = 0
                                Dim txTVA As Decimal = 0

                                'Récupération du type de facturation défini au niveau du produit
                                Using ProduitDA As New DataSetAgrifactTableAdapters.ProduitTableAdapter
                                    ProduitDT = ProduitDA.GetDataByCodeProduit(VBonCommandeDetailDR.CodeProduit)

                                    For Each ProduitDR As DataSetAgrifact.ProduitRow In ProduitDT.Rows
                                        If Not (ProduitDR.IsTypeFacturationNull) Then
                                            typeFacturation = ProduitDR.TypeFacturation
                                        End If
                                    Next
                                End Using

                                'Récupération de l'unité 1 
                                If Not (VBonCommandeDetailDR.IsUnite1Null) Then
                                    unite1 = VBonCommandeDetailDR.Unite1
                                End If

                                'Récupération de l'unité 2 
                                If Not (VBonCommandeDetailDR.IsUnite2Null) Then
                                    unite2 = VBonCommandeDetailDR.Unite2
                                End If

                                If Not (facturationTTC) Then
                                    'Calcul du montant HT de la ligne
                                    If Not (VBonCommandeDetailDR.IsPrixUHTNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneHT = unite2 * VBonCommandeDetailDR.PrixUHT
                                            Case "U1xU2" : montantLigneHT = unite1 * unite2 * VBonCommandeDetailDR.PrixUHT
                                            Case Else : montantLigneHT = unite1 * VBonCommandeDetailDR.PrixUHT
                                        End Select

                                        'Application de la remise
                                        If Not (VBonCommandeDetailDR.IsRemiseNull) Then
                                            montantLigneHT = montantLigneHT * (1 - VBonCommandeDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneHT, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Récupération du taux de TVA
                                        If Not (VBonCommandeDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VBonCommandeDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneHT * TransformTaux(txTVA, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VBonCommandeDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VBonCommandeDetailDR.nDetailDevis)
                                    End If
                                Else
                                    'Calcul du montant TTC de la ligne
                                    If Not (VBonCommandeDetailDR.IsPrixUTTCNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneTTC = unite2 * VBonCommandeDetailDR.PrixUTTC
                                            Case "U1xU2" : montantLigneTTC = unite1 * unite2 * VBonCommandeDetailDR.PrixUTTC
                                            Case Else : montantLigneTTC = unite1 * VBonCommandeDetailDR.PrixUTTC
                                        End Select

                                        'Application de la remise
                                        If Not (VBonCommandeDetailDR.IsRemiseNull) Then
                                            montantLigneTTC = montantLigneTTC * (1 - VBonCommandeDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneTTC, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Récupération du taux de TVA
                                        If Not (VBonCommandeDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VBonCommandeDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneTTC * TransformTaux(txTVA, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VBonCommandeDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VBonCommandeDetailDR.nDetailDevis)
                                    End If
                                End If
                            Next
                        End Using

                        'Mise à jour de la pièce
                        VBonCommandeDA.UpdateMontants(cumulMontantsHT, cumulMontantsTVA, cumulMontantsTTC, VBonCommandeDR.nDevis)

                        sqlTrans.Commit()
                    Catch ex As Exception
                        sqlTrans.Rollback()
                    End Try

                    Me.ProgressBar1.Value = i * 100 \ VBonCommandeDT.Rows.Count
                    Application.DoEvents()
                    i = i + 1
                Next
            End Using
        End Using
    End Sub

    Private Sub RecalculerMontantsVBonsLivraison()
        Dim i As Integer = 0
        Dim VBonLivraisonDT As DataSetAgrifact.VBonLivraisonDataTable = Nothing

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            Dim sqlTrans As SqlTransaction

            sqlConn.Open()

            Using VBonLivraisonDA As New DataSetAgrifactTableAdapters.VBonLivraisonTableAdapter
                VBonLivraisonDT = VBonLivraisonDA.GetData()

                For Each VBonLivraisonDR As DataSetAgrifact.VBonLivraisonRow In VBonLivraisonDT.Rows
                    Dim facturationTTC As Boolean = False
                    Dim VBonLivraisonDetailDT As DataSetAgrifact.VBonLivraison_DetailDataTable = Nothing
                    Dim cumulMontantsHT As Decimal = 0
                    Dim cumulMontantsTVA As Decimal = 0
                    Dim cumulMontantsTTC As Decimal = 0

                    sqlTrans = sqlConn.BeginTransaction

                    Try
                        VBonLivraisonDA.SetTransaction(sqlTrans)

                        If Not (VBonLivraisonDR.IsFacturationTTCNull) Then
                            facturationTTC = VBonLivraisonDR.FacturationTTC
                        End If

                        Using VBonLivraisonDetailDA As New DataSetAgrifactTableAdapters.VBonLivraison_DetailTableAdapter
                            VBonLivraisonDetailDA.SetTransaction(sqlTrans)

                            VBonLivraisonDetailDT = VBonLivraisonDetailDA.GetDataBynDevis(VBonLivraisonDR.nDevis)

                            For Each VBonLivraisonDetailDR As DataSetAgrifact.VBonLivraison_DetailRow In VBonLivraisonDetailDT.Rows
                                Dim ProduitDT As DataSetAgrifact.ProduitDataTable = Nothing
                                Dim typeFacturation As String = "U1"
                                Dim unite1 As Decimal = 0
                                Dim unite2 As Decimal = 0
                                Dim montantLigneHT As Decimal = 0
                                Dim montantLigneTTC As Decimal = 0
                                Dim montantLigneTVA As Decimal = 0
                                Dim txTVA As Decimal = 0

                                'Récupération du type de facturation défini au niveau du produit
                                Using ProduitDA As New DataSetAgrifactTableAdapters.ProduitTableAdapter
                                    ProduitDT = ProduitDA.GetDataByCodeProduit(VBonLivraisonDetailDR.CodeProduit)

                                    For Each ProduitDR As DataSetAgrifact.ProduitRow In ProduitDT.Rows
                                        If Not (ProduitDR.IsTypeFacturationNull) Then
                                            typeFacturation = ProduitDR.TypeFacturation
                                        End If
                                    Next
                                End Using

                                'Récupération de l'unité 1 
                                If Not (VBonLivraisonDetailDR.IsUnite1Null) Then
                                    unite1 = VBonLivraisonDetailDR.Unite1
                                End If

                                'Récupération de l'unité 2 
                                If Not (VBonLivraisonDetailDR.IsUnite2Null) Then
                                    unite2 = VBonLivraisonDetailDR.Unite2
                                End If

                                If Not (facturationTTC) Then
                                    'Calcul du montant HT de la ligne
                                    If Not (VBonLivraisonDetailDR.IsPrixUHTNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneHT = unite2 * VBonLivraisonDetailDR.PrixUHT
                                            Case "U1xU2" : montantLigneHT = unite1 * unite2 * VBonLivraisonDetailDR.PrixUHT
                                            Case Else : montantLigneHT = unite1 * VBonLivraisonDetailDR.PrixUHT
                                        End Select

                                        'Application de la remise
                                        If Not (VBonLivraisonDetailDR.IsRemiseNull) Then
                                            montantLigneHT = montantLigneHT * (1 - VBonLivraisonDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneHT, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Récupération du taux de TVA
                                        If Not (VBonLivraisonDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VBonLivraisonDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneHT * TransformTaux(txTVA, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VBonLivraisonDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VBonLivraisonDetailDR.nDetailDevis)
                                    End If
                                Else
                                    'Calcul du montant TTC de la ligne
                                    If Not (VBonLivraisonDetailDR.IsPrixUTTCNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneTTC = unite2 * VBonLivraisonDetailDR.PrixUTTC
                                            Case "U1xU2" : montantLigneTTC = unite1 * unite2 * VBonLivraisonDetailDR.PrixUTTC
                                            Case Else : montantLigneTTC = unite1 * VBonLivraisonDetailDR.PrixUTTC
                                        End Select

                                        'Application de la remise
                                        If Not (VBonLivraisonDetailDR.IsRemiseNull) Then
                                            montantLigneTTC = montantLigneTTC * (1 - VBonLivraisonDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneTTC, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Récupération du taux de TVA
                                        If Not (VBonLivraisonDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VBonLivraisonDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneTTC * TransformTaux(txTVA, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VBonLivraisonDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VBonLivraisonDetailDR.nDetailDevis)
                                    End If
                                End If
                            Next
                        End Using

                        'Mise à jour de la pièce
                        VBonLivraisonDA.UpdateMontants(cumulMontantsHT, cumulMontantsTVA, cumulMontantsTTC, VBonLivraisonDR.nDevis)

                        sqlTrans.Commit()
                    Catch ex As Exception
                        sqlTrans.Rollback()
                    End Try

                    Me.ProgressBar1.Value = i * 100 \ VBonLivraisonDT.Rows.Count
                    Application.DoEvents()
                    i = i + 1
                Next
            End Using
        End Using
    End Sub

    Private Sub RecalculerMontantsVFactures()
        Dim i As Integer = 0
        Dim VFactureDT As DataSetAgrifact.VFactureDataTable = Nothing

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            Dim sqlTrans As SqlTransaction

            sqlConn.Open()

            Using VFactureDA As New DataSetAgrifactTableAdapters.VFactureTableAdapter
                VFactureDT = VFactureDA.GetData()

                For Each VFactureDR As DataSetAgrifact.VFactureRow In VFactureDT.Rows
                    Dim facturationTTC As Boolean = False
                    Dim VFactureDetailDT As DataSetAgrifact.VFacture_DetailDataTable = Nothing
                    Dim cumulMontantsHT As Decimal = 0
                    Dim cumulMontantsTVA As Decimal = 0
                    Dim cumulMontantsTTC As Decimal = 0

                    sqlTrans = sqlConn.BeginTransaction

                    Try
                        VFactureDA.SetTransaction(sqlTrans)

                        If Not (VFactureDR.IsFacturationTTCNull) Then
                            facturationTTC = VFactureDR.FacturationTTC
                        End If

                        Using VFactureDetailDA As New DataSetAgrifactTableAdapters.VFacture_DetailTableAdapter
                            VFactureDetailDA.SetTransaction(sqlTrans)

                            VFactureDetailDT = VFactureDetailDA.GetDataBynDevis(VFactureDR.nDevis)

                            For Each VFactureDetailDR As DataSetAgrifact.VFacture_DetailRow In VFactureDetailDT.Rows
                                Dim ProduitDT As DataSetAgrifact.ProduitDataTable = Nothing
                                Dim typeFacturation As String = "U1"
                                Dim unite1 As Decimal = 0
                                Dim unite2 As Decimal = 0
                                Dim montantLigneHT As Decimal = 0
                                Dim montantLigneTTC As Decimal = 0
                                Dim montantLigneTVA As Decimal = 0
                                Dim txTVA As Decimal = 0

                                'Récupération du type de facturation défini au niveau du produit
                                Using ProduitDA As New DataSetAgrifactTableAdapters.ProduitTableAdapter
                                    ProduitDT = ProduitDA.GetDataByCodeProduit(VFactureDetailDR.CodeProduit)

                                    For Each ProduitDR As DataSetAgrifact.ProduitRow In ProduitDT.Rows
                                        If Not (ProduitDR.IsTypeFacturationNull) Then
                                            typeFacturation = ProduitDR.TypeFacturation
                                        End If
                                    Next
                                End Using

                                'Récupération de l'unité 1 
                                If Not (VFactureDetailDR.IsUnite1Null) Then
                                    unite1 = VFactureDetailDR.Unite1
                                End If

                                'Récupération de l'unité 2 
                                If Not (VFactureDetailDR.IsUnite2Null) Then
                                    unite2 = VFactureDetailDR.Unite2
                                End If

                                If Not (facturationTTC) Then
                                    'Calcul du montant HT de la ligne
                                    If Not (VFactureDetailDR.IsPrixUHTNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneHT = unite2 * VFactureDetailDR.PrixUHT
                                            Case "U1xU2" : montantLigneHT = unite1 * unite2 * VFactureDetailDR.PrixUHT
                                            Case Else : montantLigneHT = unite1 * VFactureDetailDR.PrixUHT
                                        End Select

                                        'Application de la remise
                                        If Not (VFactureDetailDR.IsRemiseNull) Then
                                            montantLigneHT = montantLigneHT * (1 - VFactureDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneHT, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Récupération du taux de TVA
                                        If Not (VFactureDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VFactureDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneHT * TransformTaux(txTVA, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VFactureDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VFactureDetailDR.nDetailDevis)
                                    End If
                                Else
                                    'Calcul du montant TTC de la ligne
                                    If Not (VFactureDetailDR.IsPrixUTTCNull) Then
                                        Select Case typeFacturation
                                            Case "U2" : montantLigneTTC = unite2 * VFactureDetailDR.PrixUTTC
                                            Case "U1xU2" : montantLigneTTC = unite1 * unite2 * VFactureDetailDR.PrixUTTC
                                            Case Else : montantLigneTTC = unite1 * VFactureDetailDR.PrixUTTC
                                        End Select

                                        'Application de la remise
                                        If Not (VFactureDetailDR.IsRemiseNull) Then
                                            montantLigneTTC = montantLigneTTC * (1 - VFactureDetailDR.Remise / 100)
                                        End If

                                        'Arrondi du montant TTC de la ligne
                                        montantLigneTTC = Decimal.Round(montantLigneTTC, 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants HT
                                        cumulMontantsTTC = cumulMontantsTTC + montantLigneTTC

                                        'Récupération du taux de TVA
                                        If Not (VFactureDetailDR.IsTTVANull) Then
                                            Dim TVADT As DataSetAgrifact.TVADataTable = Nothing

                                            Using TVADA As New DataSetAgrifactTableAdapters.TVATableAdapter
                                                TVADT = TVADA.GetDataByTTVA(VFactureDetailDR.TTVA)

                                                For Each TVADR As DataSetAgrifact.TVARow In TVADT.Rows
                                                    If Not (TVADR.IsTTauxNull) Then
                                                        txTVA = TVADR.TTaux / 100
                                                    End If
                                                Next
                                            End Using
                                        End If

                                        'Calcul du montant HT de la ligne
                                        montantLigneHT = Decimal.Round(montantLigneTTC * TransformTaux(txTVA, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)

                                        'Ajout au cumul des montants TTC
                                        cumulMontantsHT = cumulMontantsHT + montantLigneHT

                                        'Calcul du montant TVA de la ligne
                                        montantLigneTVA = montantLigneTTC - montantLigneHT

                                        'Ajout au cumul des montants TVA
                                        cumulMontantsTVA = cumulMontantsTVA + montantLigneTVA

                                        'Mise à jour de la ligne
                                        VFactureDetailDA.UpdateMontants(montantLigneHT, montantLigneTVA, montantLigneTTC, VFactureDetailDR.nDetailDevis)
                                    End If
                                End If
                            Next
                        End Using

                        'Mise à jour de la pièce
                        VFactureDA.UpdateMontants(cumulMontantsHT, cumulMontantsTVA, cumulMontantsTTC, VFactureDR.nDevis)

                        sqlTrans.Commit()
                    Catch ex As Exception
                        sqlTrans.Rollback()
                    End Try

                    Me.ProgressBar1.Value = i * 100 \ VFactureDT.Rows.Count
                    Application.DoEvents()
                    i = i + 1
                Next
            End Using
        End Using
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function TransformTaux(ByVal tx As Decimal, ByVal mode As ModeTaux) As Decimal
        Select Case mode
            Case ModeTaux.HtToTva : Return tx
            Case ModeTaux.HtToTtc : Return (1 + tx)
            Case ModeTaux.TtcToHt : Return 1 / (1 + tx)
            Case ModeTaux.TtcToTva : Return tx / (1 + tx)
        End Select
    End Function
#End Region
    
End Class
