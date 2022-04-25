Imports System.Data
Imports System.collections.Generic
Imports Microsoft.VisualBasic

Public Class Pieces
    Public Shared Function CreerBL(ByVal nDevisBC As Integer) As Integer
        Dim nDevisBL As Integer
        Using s As New SqlProxy
            Dim ds As New DataSet
            'Récupérer les données du BC
            s.FillBy(ds, "VBonCommande", "nDevis=" & nDevisBC)
            If ds.Tables("VBonCommande").Rows.Count = 0 Then
                Throw New ApplicationException("Le bon de commande est introuvable")
            End If
            'Initialiser la table de BL pour recevoir les données
            s.FillSchema(ds, "VBonLivraison")

            'MODIF TV 11/09/2012
            'With ds.Tables("VBonLivraison").Columns("nDevis")
            '    .AutoIncrement = True
            '    .AutoIncrementSeed = s.GetMaxValue("VBonLivraison", "nDevis") + 1
            '    .AutoIncrementStep = 1
            'End With
            'FIN MODIF TV 11/09/2012

            'Recopier la ligne BC en BL
            Dim drBC As DataRow = ds.Tables("VBonCommande").Rows(0)
            Dim drBL As DataRow = ds.Tables("VBonLivraison").NewRow
            CopyRow(drBC, drBL)
            With drBL
                'MODIF TV 11/09/2012
                .Item("nDevis") = GetNDevis("VBonLivraison")
                'FIN MODIF TV 11/09/2012

                '-Modifier l'adresse par l'adresse de livraison
                .Item("nFacture") = GetNFacture("VBonLivraison")
                .Item("DateFacture") = Today
                'Recalculer l'adresse de facture
                .Item("AdresseFacture") = GetAdresseFacture(CInt(drBL("nClient")), "VBonLivraison")
            End With
            ds.Tables("VBonLivraison").Rows.Add(drBL)
            nDevisBL = CInt(drBL("nDevis"))

            'Enregistrer les infos d'Origine dans la ligne en cours
            With drBC
                .Item("Origine") = "VBonLivraison"
                .Item("nOrigine") = drBL("nDevis")
                .Item("Paye") = True
            End With

            'Enregistrer les données dans les tables de destination
            s.UpdateTable(ds, "VBonLivraison", Nothing)
            s.UpdateTable(ds, "VBonCommande", Nothing)
            'RECOPIER LES DETAILS DE LA PIECE
            RecopierDetailPiece(s, "VBonCommande", nDevisBC, "VBonLivraison", nDevisBL)
        End Using
        Return nDevisBL
    End Function

    Public Shared Function GetAdresseFacture(ByVal nClient As Integer, ByVal DesTable As String) As String
        Dim strAdresse As String = ""
        Dim ds As New DataSet
        Using s As New SqlProxy
            s.FillBy(ds, "Entreprise", "nEntreprise=" & Convert.ToString(nClient))
        End Using
        Dim dt As DataTable = ds.Tables("Entreprise")
        If dt.Rows.Count > 0 Then
            Dim rwClient As DataRow = dt.Rows(0)
            '* Gestion Adresse Livraison
            Dim AdresseOk As Boolean = False
            If DesTable = "VBonLivraison" Then
                If rwClient.Table.Columns.Contains("VilleLiv") Then
                    If Convert.ToString(rwClient("VilleLiv")) <> "" Then
                        strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", rwClient("Nom"), rwClient("AdresseLiv"), rwClient("CodePostalLiv"), rwClient("VilleLiv"))
                        If dt.Columns.Contains("SuffixePostalLiv") Then
                            strAdresse &= Convert.ToString(rwClient("SuffixePostalLiv"))
                        End If
                        If dt.Columns.Contains("PaysLiv") Then
                            Dim strPays As String = Convert.ToString(rwClient("PaysLiv"))
                            If strPays.Length > 0 Then
                                strAdresse &= vbCrLf & strPays
                            End If
                        End If
                        AdresseOk = True
                    End If
                End If
            End If
            If Not AdresseOk Then
                strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", rwClient("Nom"), rwClient("Adresse"), rwClient("CodePostal"), rwClient("Ville"))
                If dt.Columns.Contains("SuffixePostal") Then
                    strAdresse &= Convert.ToString(rwClient("SuffixePostal"))
                End If
                If dt.Columns.Contains("Pays") Then
                    Dim strPays As String = Convert.ToString(rwClient("Pays"))
                    If strPays.Length > 0 Then
                        strAdresse &= vbCrLf & strPays
                    End If
                End If
            End If
        End If
        Return strAdresse.Replace("/r", vbCr).Replace("/n", vbLf)
    End Function

    Public Shared Sub AnnulerNFacture(ByVal Table As String, ByVal nFacture As Integer)
        Using s As New SqlProxy
            s.ExecuteNonQuery(String.Format("Exec RemoveLastNFacture '{0}',{1},{2}", Table, nFacture, "0"))
        End Using
    End Sub

    Public Shared Function GetNFacture(ByVal Table As String, Optional ByVal Simulation As Boolean = False) As Integer
        Dim vDefaut As Integer = 1
        Using s As New SqlProxy
            Dim nFacture As Integer = 1
            nFacture = s.ExecuteScalarInt(String.Format("Exec GetNextNFacture '{0}',{1},{2}", Table, vDefaut, IIf(Simulation, "1", "0")))
            Return nFacture
        End Using
    End Function

    'MODIF TV 11/09/2012
    Public Shared Function GetNDevis(ByVal Table As String) As Integer
        Using s As New SqlProxy
            Dim nDevis As Integer = 1
            nDevis = s.ExecuteScalarInt(String.Format("Exec GetNextNDevis '{0}'", Table))
            Return nDevis
        End Using
    End Function

    Public Shared Function GetNDetailDevis(ByVal Table As String) As Integer
        Using s As New SqlProxy
            Dim nDetailDevis As Integer = 1
            nDetailDevis = s.ExecuteScalarInt(String.Format("Exec GetNextNDetailDevis '{0}'", Table))
            Return nDetailDevis
        End Using
    End Function
    'FIN MODIF TV 11/09/2012

    Public Shared Sub RecopierDetailPiece(ByVal s As SqlProxy, ByVal tableSrc As String, ByVal nDevisSrc As Integer, ByVal tableDest As String, ByVal nDevisDest As Integer)
        Dim dtDest As DataTable = s.ExecuteDataTable(String.Format("SELECT * FROM [{0}] WHERE 1=0", tableDest & "_Detail"))
        Dim dtSrc As DataTable = s.ExecuteDataTable(String.Format("SELECT * FROM [{0}] WHERE 1=0", tableSrc & "_Detail"))
        Dim nDetailSrcMin = s.ExecuteScalarInt(String.Format("SELECT Min(nDetailDevis) as m FROM [{0}] WHERE [nDevis]={1}", tableSrc & "_Detail", nDevisSrc))
        Dim nDetailDestMax = s.ExecuteScalarInt(String.Format("SELECT Max(nDetailDevis) as m FROM [{0}]", tableDest & "_Detail"))
        Dim colList As New List(Of String)
        Dim valueList As New List(Of String)
        For Each col As DataColumn In dtDest.Columns
            If dtSrc.Columns.Contains(col.ColumnName) Then
                colList.Add(String.Format("[{0}]", col))
                If col.ColumnName = "nDevis" Then
                    valueList.Add("{0}")
                ElseIf col.ColumnName = "nDetailDevis" Then
                    valueList.Add(String.Format("[{0}]+{1}", col, nDetailDestMax + 1 - nDetailSrcMin))
                Else
                    valueList.Add(String.Format("[{0}]", col))
                End If
            End If
        Next
        Dim sql As String = String.Format("INSERT INTO [{0}]({2}) SELECT {3} FROM [{1}] WHERE [nDevis]={{1}}", tableDest & "_Detail", tableSrc & "_Detail", String.Join(",", colList.ToArray), String.Join(",", valueList.ToArray))
        s.ExecuteNonQuery(SqlProxy.FormatSql(sql, nDevisDest, nDevisSrc))
    End Sub

    Public Shared Sub RecalculerBLs(ByVal ds As DsAgrifact)
        For Each drBL As DsAgrifact.VBonLivraisonRow In ds.VBonLivraison
            RecalculerBL(drBL)
        Next
    End Sub

    Public Shared Sub RecalculerBL(ByVal drBL As DsAgrifact.VBonLivraisonRow)
        If drBL.FacturationTTC Then
            RecalculerBLTTC(drBL)
        Else
            RecalculerBLHT(drBL)
        End If
    End Sub

    Public Shared Sub RecalculerBLHT(ByVal drBL As DsAgrifact.VBonLivraisonRow)
        Dim dtTVA As DsAgrifact.TVADataTable = CType(drBL.Table.DataSet, DsAgrifact).TVA
        Dim recapTVA As New Dictionary(Of String, Decimal)
        Dim montantHT As Decimal
        For Each drBLD As DsAgrifact.VBonLivraison_DetailRow In drBL.GetVBonLivraison_DetailRows
            RecalculerLigneBLHT(dtTVA, drBL, drBLD, recapTVA)
            If Not drBLD.IsMontantLigneHTNull Then montantHT += drBLD.MontantLigneHT
        Next
        'Calculer le montant de la TVA
        Dim montantTVA As Decimal = 0
        For Each ttva As String In recapTVA.Keys
            montantTVA += recapTVA(ttva) * GetTxTVA(dtTVA, ttva)
        Next
        drBL.MontantTVA = Decimal.Round(montantTVA, 2)
        'TTC en fonction du HT
        drBL.MontantHT = montantHT
        drBL.MontantTTC = drBL.MontantHT + drBL.MontantTVA
    End Sub

    Public Shared Sub RecalculerBLTTC(ByVal drBL As DsAgrifact.VBonLivraisonRow)
        Dim dtTVA As DsAgrifact.TVADataTable = CType(drBL.Table.DataSet, DsAgrifact).TVA
        Dim recapTVA As New Dictionary(Of String, Decimal)
        Dim montantTTC As Decimal
        For Each drBLD As DsAgrifact.VBonLivraison_DetailRow In drBL.GetVBonLivraison_DetailRows
            RecalculerLigneBLTTC(dtTVA, drBL, drBLD, recapTVA)
            If Not drBLD.IsMontantLigneTTCNull Then montantTTC += drBLD.MontantLigneTTC
        Next
        'Calculer le montant de la TVA
        Dim montantTVA As Decimal = 0
        For Each ttva As String In recapTVA.Keys
            Dim tx As Decimal = GetTxTVA(dtTVA, ttva)
            If tx <> 0 Then
                montantTVA += recapTVA(ttva) * tx / (1 + tx)
            End If
        Next
        drBL.MontantTTC = montantTTC
        drBL.MontantTVA = Decimal.Round(montantTVA, 2)
        'HT en fonction du TTC
        drBL.MontantHT = drBL.MontantTTC - drBL.MontantTVA
    End Sub

    Public Shared Sub RecalculerLigneBLHT(ByVal dtTVA As DsAgrifact.TVADataTable, ByVal drbl As DsAgrifact.VBonLivraisonRow, ByVal drBLD As DsAgrifact.VBonLivraison_DetailRow, ByVal recapTVA As Dictionary(Of String, Decimal))
        Dim montantHT As Nullable(Of Decimal) = CalculerMontantHT(drBLD)
        If Not montantHT.HasValue Then
            drBLD.SetMontantLigneHTNull()
            drBLD.SetMontantLigneTVANull()
            drBLD.SetMontantLigneTTCNull()
        Else
            drBLD.MontantLigneHT = Decimal.Round(montantHT.Value, 2)
            If drBLD.IsTTVANull Then
                drBLD.MontantLigneTVA = 0
            Else
                drBLD.MontantLigneTVA = Decimal.Round(montantHT * GetTxTVA(dtTVA, drBLD.TTVA), 2)
            End If
            drBLD.MontantLigneTTC = drBLD.MontantLigneHT + drBLD.MontantLigneTVA
            AddMtRecap(recapTVA, drBLD.TTVA, drBLD.MontantLigneHT)
        End If
    End Sub

    Public Shared Sub RecalculerLigneBLTTC(ByVal dtTVA As DsAgrifact.TVADataTable, ByVal drbl As DsAgrifact.VBonLivraisonRow, ByVal drBLD As DsAgrifact.VBonLivraison_DetailRow, ByVal recapTVA As Dictionary(Of String, Decimal))
        Dim montantTTC As Nullable(Of Decimal) = CalculerMontantTTC(drBLD)
        If Not montantTTC.HasValue Then
            drBLD.SetMontantLigneHTNull()
            drBLD.SetMontantLigneTVANull()
            drBLD.SetMontantLigneTTCNull()
        Else
            drBLD.MontantLigneTTC = Decimal.Round(montantTTC.Value, 2)
            If drBLD.IsTTVANull Then
                drBLD.MontantLigneTVA = 0
            Else
                Dim montantTVA As Decimal = 0
                Dim tx As Decimal = GetTxTVA(dtTVA, drBLD.TTVA)
                If tx <> 0 Then montantTVA = montantTTC * tx / (1 + tx)            
                drBLD.MontantLigneTVA = Decimal.Round(montantTVA, 2)
            End If
            drBLD.MontantLigneHT = drBLD.MontantLigneTTC - drBLD.MontantLigneTVA
            AddMtRecap(recapTVA, drBLD.TTVA, drBLD.MontantLigneTTC)
        End If
    End Sub

    Private Shared Function CalculerMontantHT(ByVal drBLD As DsAgrifact.VBonLivraison_DetailRow) As Nullable(Of Decimal)
        Dim montantHT As New Nullable(Of Decimal)
        If Not drBLD.IsPrixUHTNull Then
            montantHT = CalculerMontant(drBLD, drBLD.PrixUHT)
        End If
        Return montantHT
    End Function

    Private Shared Function CalculerMontantTTC(ByVal drBLD As DsAgrifact.VBonLivraison_DetailRow) As Nullable(Of Decimal)
        Dim montantHT As New Nullable(Of Decimal)
        If Not drBLD.IsPrixUTTCNull Then
            montantHT = CalculerMontant(drBLD, drBLD.PrixUTTC)
        End If
        Return montantHT
    End Function

    Private Shared Function CalculerMontant(ByVal drBLD As DsAgrifact.VBonLivraison_DetailRow, ByVal prixU As Decimal) As Nullable(Of Decimal)
        Dim montant As New Nullable(Of Decimal)
        Dim drProduit As DsAgrifact.ProduitRow = SelectSingleRow(Of DsAgrifact.ProduitRow)(CType(drBLD.Table.DataSet, DsAgrifact).Produit, FormatExpression("CodeProduit={0}", drBLD.CodeProduit), "")
        If drProduit IsNot Nothing AndAlso Not drProduit.IsTypeFacturationNull AndAlso Not drProduit.TypeFacturation = "U1" Then
            Select Case drProduit.TypeFacturation.ToUpper
                Case "U2"
                    If Not drBLD.IsUnite2Null Then
                        montant = drBLD.Unite2 * prixU
                    End If
                Case "U1XU2"
                    If Not drBLD.IsUnite1Null AndAlso Not drBLD.IsUnite2Null Then
                        montant = drBLD.Unite1 * drBLD.Unite2 * prixU
                    End If
            End Select
        Else 'Par défaut : facturation sur U1
            If Not drBLD.IsUnite1Null Then
                montant = drBLD.Unite1 * prixU
            End If
        End If
        'Gestion des remises
        If montant.HasValue Then
            If Not drBLD.IsRemiseNull AndAlso drBLD.Remise > 0 Then
                montant = montant * (1 - drBLD.Remise / 100)
            End If
        End If
        Return montant
    End Function

    Private Shared Sub AddMtRecap(ByVal recapTVA As Dictionary(Of String, Decimal), ByVal ttva As String, ByVal montant As Decimal)
        If recapTVA.ContainsKey(ttva) Then
            recapTVA(ttva) += montant
        Else
            recapTVA.Add(ttva, montant)
        End If
    End Sub

    Private Shared Function GetTxTVA(ByVal dtTVA As DsAgrifact.TVADataTable, ByVal ttva As String) As Decimal
        Dim drTVA As DsAgrifact.TVARow = dtTVA.FindByTTVA(ttva)
        If drTVA IsNot Nothing AndAlso Not drTVA.IsTTauxNull Then
            Return drTVA.TTaux / 100
        Else
            Return 0
        End If
    End Function

End Class
