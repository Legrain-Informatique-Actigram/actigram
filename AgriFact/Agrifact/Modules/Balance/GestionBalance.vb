Imports Actigram.Donnees
Imports Actigram.Balance.Mira

Public Class GestionBalance
    Private WithEvents Mira As New GestionMira
    Private ds As DataSet

    Private Sub ChargerDonneesProduit()
        If ds Is Nothing Then ds = New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(Me.ds, "TVA", s)
            DefinitionDonnees.Instance.Fill(Me.ds, "Famille", s)
            DefinitionDonnees.Instance.Fill(Me.ds, "Produit", s)
        End Using
    End Sub

    Private Sub ChargerDonneesVente()
        If ds Is Nothing Then ds = New DataSet
        ChargerDonneesProduit()
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(Me.ds, "Trame", s)
            DefinitionDonnees.Instance.Fill(Me.ds, "VFacture", s)
            DefinitionDonnees.Instance.Fill(Me.ds, "VFacture_Detail", s)
        End Using
    End Sub

    Public Sub New()
    End Sub

    Public Sub MajProduit()
        ChargerDonneesProduit()
        Dim Op As New OpenFileDialog
        Mira.TableTVA = ds.Tables("TVA")

        If MessageBox.Show("Voulez vous Mettre à jour les Familles de la Balance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim dtBalance As DataTable = ds.Tables("Famille").Clone
            Mira.TableGroupe = dtBalance
            Mira.VerifFamille()
            Mira.UpDateBalanceFamille(dtBalance, ds.Tables("Famille"))
        End If

        'If MessageBox.Show("Voulez vous Mettre à jour les Taux de TVA?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    Dim dtBalance As DataTable = fr.ds.Tables("TVA").Clone
        '    Mira.TableGroupe = dtBalance
        '    Mira.VerifTVA()
        '    Mira.UpDateBalanceTVA(dtBalance, fr.ds.Tables("TVA"))
        'End If

        If MessageBox.Show("Voulez vous Mettre à jour les Produits de la Balance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim dtBalance As DataTable = ds.Tables("Produit").Clone
            Mira.TableProduit = dtBalance
            Mira.VerifProduit()
            Mira.UpDateBalanceProduit(dtBalance, ds.Tables("Produit"))
        End If
    End Sub

    Public Sub RecupProduit()
        Dim Op As New OpenFileDialog
        If MessageBox.Show("Voulez vous Importer les Familles de la Balance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim ImportFichier As Boolean
            If MessageBox.Show("Import depuis un fichier ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Op.ShowDialog()
                ImportFichier = True
            Else
                ImportFichier = False
            End If

            If Op.FileName <> "" Then
                Mira.FileOut = Op.FileName
            End If
            ChargerDonneesProduit()
            Mira.TableTVA = ds.Tables("TVA")
            Mira.TableGroupe = ds.Tables("Famille")
            Mira.VerifFamille(ImportFichier)
            Using s As New SqlProxy
                s.UpdateTable(ds, "Famille")
            End Using
        End If

        If MessageBox.Show("Voulez vous Importer les Produits de la Balance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim ImportFichier As Boolean
            If MessageBox.Show("Import depuis un fichier ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Op.ShowDialog()
                ImportFichier = True
            Else
                ImportFichier = False
            End If

            If Op.FileName <> "" Then
                Mira.FileOut = Op.FileName
            End If
            Mira.TableProduit = ds.Tables("Produit")
            Mira.VerifProduit(ImportFichier)
            Using s As New SqlProxy
                s.UpdateTable(ds, "Produit")
            End Using
        End If
    End Sub

    Private frP As FrProgressBar

    Public Function RecupVentes() As Boolean
        Dim frChoixDt As New FrChoixDate
        If frChoixDt.ShowDialog = DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            ChargerDonneesVente()
            Mira.TableTVA = ds.Tables("TVA")
            Mira.TableTrame = ds.Tables("Trame")
            Try
                Using s As New SqlProxy
                    Dim dsTmp As New DataSet
                    s.Fill(dsTmp, "Select * From Trame Where dtTicket='" & frChoixDt.SelectedDate.ToString("dd-MM-yy") & "'", "Trame")
                    Mira.TableTrameVerif = dsTmp.Tables("Trame")
                    AddHandler Mira.ReceptionProgressed, AddressOf BalanceReceptionProgressed
                    Mira.RecupDetailVentes(frChoixDt.SelectedDate)
                    s.UpdateTable(Me.ds, "Trame")
                End Using

                frP.Close()
                frP = Nothing
                RemoveHandler Mira.ReceptionProgressed, AddressOf BalanceReceptionProgressed

                If Not Mira.TableTrame Is Nothing Then
                    Dim obj As Object = Mira.TableTrame.Compute("Max(nImport)", "")
                    If Not IsDBNull(obj) Then
                        If MsgBox("Voulez-vous générer des factures à partir des ventes remontées ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            GenererFacture(CLng(obj))
                        End If
                    End If
                End If
                Return True
            Catch ex As Exception
                LogException(ex)
                MsgBox("Erreur lors de la récupération : " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                Cursor.Current = Cursors.Default
                If Not frP Is Nothing Then frP.Close()
            End Try
        End If
        Return False
    End Function

    Private Sub BalanceReceptionProgressed(ByVal sender As Object, ByVal progressPercentage As Integer)
        If frP Is Nothing Then
            frP = New FrProgressBar
            With frP
                .Maximum = 100
                .Value = 0
                .Text = "0"
                .Show()
            End With
        End If
        frP.UpdateProgress(progressPercentage, String.Format("{0}%", progressPercentage))
    End Sub

    Public Sub GenererFacture(ByVal nImport As Long, Optional ByVal conso As Boolean = True)
        ChargerDonneesVente()
        Mira.TableTVA = ds.Tables("TVA")
        Mira.TableTrame = ds.Tables("Trame")
        AddHandler Mira.ReceptionProgressed, AddressOf BalanceReceptionProgressed
        Try
            Dim gfm As New GestionFactureMasse(ds)
            Dim nClient As Integer = gfm.SelectionnerUnClient
            Dim adresseFacture As String = gfm.AdresseFacturation(nClient)
            If conso Then
                GenererFactureConso(nImport, nClient, adresseFacture)
            Else
                GenererFactureDetail(nImport, nClient, adresseFacture)
            End If
            Dim tables As String() = {"VFacture", "VFacture_Detail"}
            Using s As New SqlProxy
                s.UpdateTables(Me.ds, tables)
            End Using
        Finally
            If Not frP Is Nothing Then frP.Close()
        End Try
    End Sub

    Private Sub GenererFactureDetail(ByVal nImport As Long, ByVal nClient As Long, ByVal adresseFacture As String)
        'Une facture par date ou une facture par ticket, grouper par produit ?
        Dim rwsTrame() As DataRow = Mira.TableTrame.Select(String.Format("nImport={0}", nImport), "dtTicket,nTicket,TypeTrame")
        If rwsTrame.Length = 0 Then Exit Sub

        Dim dtFacture As Date = Date.MinValue
        Dim rwFacture As DataRow
        Dim MontantTVA As Decimal = 0
        Dim MontantTTC As Decimal = 0

        'Pour chaque ligne de trame
        Dim i As Integer = 0
        For Each rwTrame As DataRow In rwsTrame
            i += 1 : BalanceReceptionProgressed(Me, i * 100 \ rwsTrame.Length)
            'S'il faut créer une nouvelle facture
            If dtFacture <> CDate(rwsTrame(0)("dtTicket")).Date Then
                'Boucler la facture précédente
                If Not rwFacture Is Nothing Then
                    With rwFacture
                        .Item("MontantTVA") = MontantTVA
                        .Item("MontantTTC") = MontantTTC
                        .Item("MontantHT") = MontantTTC - MontantTVA
                    End With
                End If
                dtFacture = CDate(rwsTrame(0)("dtTicket")).Date
                'Créer la facture
                rwFacture = ds.Tables("VFacture").NewRow
                With rwFacture
                    .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.VFacture)
                    .Item("nClient") = nClient
                    .Item("AdresseFacture") = adresseFacture
                    .Item("Observation") = String.Format("Ventes balance du {0:dd/MM/yyyy}", dtFacture)
                    .Item("DateFacture") = dtFacture
                    .Item("FacturationTTC") = True
                End With
                ds.Tables("VFacture").Rows.Add(rwFacture)
                MontantTVA = 0
                MontantTTC = 0
            End If

            If CInt(rwTrame("TypeTrame")) = 0 Then
            'Les lignes de détail
            Dim rwProduit As DataRow = Nothing
                Dim rwsProduit() As DataRow = ds.Tables("Produit").Select(String.Format("CodeProduit='{0}'", rwTrame("Plu")))
            If rwsProduit.Length > 0 Then
                rwProduit = rwsProduit(0)
            End If
            Dim rwDetail As DataRow = ds.Tables("VFacture_Detail").NewRow
            With rwDetail
                .Item("nDevis") = rwFacture("nDevis")
                    .Item("CodeProduit") = rwTrame("Plu")
                If Not rwProduit Is Nothing Then
                        .Item("Libelle") = String.Format("Ticket n°{1}  - {0}", rwProduit("Libelle"), rwTrame("nTicket"), rwTrame("dtTicket"))
                    .Item("nCompte") = rwProduit("nCompteV")
                    .Item("nActivite") = rwProduit("nActiviteV")
                    .Item("LibUnite1") = rwProduit("Unite1")
                    .Item("LibUnite2") = rwProduit("Unite2")
                        .Item("TTVA") = rwProduit("TTVA")
                        .Item("PrixUTTC") = rwProduit("PrixVTTC")
                    Else
                        .Item("Libelle") = String.Format("Ticket n°{1} - {0}", rwTrame("Plu"), rwTrame("nTicket"), rwTrame("dtTicket"))
                    End If

                    If Not IsDBNull(rwTrame("Quantite")) Then .Item("Unite1") = rwTrame("Quantite")

                    .Item("MontantLigneTTC") = rwTrame("Montant")
                    If Not IsDBNull(.Item("TTVA")) Then
                        Dim rwsTVA() As DataRow = ds.Tables("TVA").Select(String.Format("TTVA='{0}'", .Item("TTVA")))
                        If rwsTVA.Length > 0 Then
                            .Item("MontantLigneTVA") = CDec(.Item("MontantLigneTTC")) * (CDec(rwsTVA(0)("TTaux")) / (1 + CDec(rwsTVA(0)("TTaux"))))
                        Else
                            .Item("MontantLigneTVA") = 0
                        End If
                Else
                        .Item("MontantLigneTVA") = 0
                End If
                    .Item("MontantLigneHT") = CDec(.Item("MontantLigneTTC")) - CDec(.Item("MontantLigneTVA"))
                    MontantTTC += CDec(.Item("MontantLigneTTC"))
                    MontantTVA += CDec(.Item("MontantLigneTVA"))
                End With

                ds.Tables("VFacture_Detail").Rows.Add(rwDetail)
            ElseIf CInt(rwTrame("TypeTrame")) = 3 Then
                Dim rwDetail As DataRow = ds.Tables("VFacture_Detail").NewRow
                With rwDetail
                    .Item("nDevis") = rwFacture("nDevis")
                    .Item("CodeProduit") = ""
                    .Item("Libelle") = String.Format("    TICKET n°{1} du {2:dd/MM/yy} : {0:C2}" & vbCrLf & "{3}", rwTrame("TotalMontant"), rwTrame("nTicket"), rwTrame("dtTicket"), New String("-"c, 55))
                End With
                ds.Tables("VFacture_Detail").Rows.Add(rwDetail)
                End If
        Next
        'Bouclage de la dernière facture générée
        If Not rwFacture Is Nothing Then
            With rwFacture
                .Item("MontantTVA") = MontantTVA
                .Item("MontantTTC") = MontantTTC
                .Item("MontantHT") = MontantTTC - MontantTVA
            End With
        End If
    End Sub

    Private Sub GenererFactureConso(ByVal nImport As Long, ByVal nClient As Long, ByVal adresseFacture As String)
        'Une facture par date ou une facture par ticket, grouper par produit ?
        Dim sql As String = String.Format("SELECT dtTicket,f.Famille,Plu,Sum(Quantite) AS Quantite, Sum(Montant) AS Montant  " & _
        "FROM Trame t LEFT JOIN Produit p ON t.Plu=p.CodeProduit LEFT JOIN Famille f ON p.Famille1=f.nFamille " & _
        "WHERE nImport={0} AND TypeTrame=0 GROUP BY dtTicket,f.Famille, Plu", nImport)
        Dim dt As New DataTable
        Using s As New SqlProxy
            dt = s.ExecuteDataTable(sql)
        End Using

        If dt.Rows.Count = 0 Then Exit Sub

        Dim dtFacture As Date = Date.MinValue
        Dim rwFacture As DataRow
        Dim MontantTVA As Decimal = 0
        Dim MontantTTC As Decimal = 0
        Dim Famille As String = "xxxx"

        'Pour chaque ligne de trame
        Dim i As Integer = 0
        For Each rwTrame As DataRow In dt.Rows
            i += 1 : BalanceReceptionProgressed(Me, i * 100 \ dt.Rows.Count)

            'S'il faut créer une nouvelle facture
            If dtFacture <> CDate(rwTrame("dtTicket")).Date Then
                'Boucler la facture précédente
                If Not rwFacture Is Nothing Then
                    With rwFacture
                        .Item("MontantTVA") = MontantTVA
                        .Item("MontantTTC") = MontantTTC
                        .Item("MontantHT") = MontantTTC - MontantTVA
                    End With
                End If
                dtFacture = CDate(rwTrame("dtTicket")).Date
                'Créer la facture
                rwFacture = ds.Tables("VFacture").NewRow
                With rwFacture
                    .Item("nFacture") = Pieces.GetNFacture(Pieces.TypePieces.VFacture)
                    .Item("nClient") = nClient
                    .Item("AdresseFacture") = adresseFacture
                    .Item("Observation") = String.Format("Ventes balance du {0:dd/MM/yyyy}", dtFacture)
                    .Item("DateFacture") = dtFacture
                    .Item("FacturationTTC") = True
                End With
                ds.Tables("VFacture").Rows.Add(rwFacture)
                MontantTVA = 0
                MontantTTC = 0
            End If

            If Famille <> Convert.ToString(rwTrame("Famille")) Then
                Famille = Convert.ToString(rwTrame("Famille"))
                Dim rwDetail2 As DataRow = ds.Tables("VFacture_Detail").NewRow
                With rwDetail2
                    .Item("nDevis") = rwFacture("nDevis")
                    .Item("CodeProduit") = ""
                    .Item("Libelle") = String.Format(vbCrLf & "{0}" & vbCrLf & "{1}", Famille.ToUpper, New String("-"c, 55))
                End With
                ds.Tables("VFacture_Detail").Rows.Add(rwDetail2)
            End If

            'Les lignes de détail
            Dim rwProduit As DataRow = Nothing
            Dim rwsProduit() As DataRow = ds.Tables("Produit").Select(String.Format("CodeProduit='{0}'", rwTrame("Plu")))
            If rwsProduit.Length > 0 Then
                rwProduit = rwsProduit(0)
            End If
            Dim rwDetail As DataRow = ds.Tables("VFacture_Detail").NewRow
            With rwDetail
                .Item("nDevis") = rwFacture("nDevis")
                .Item("CodeProduit") = rwTrame("Plu")
                If Not rwProduit Is Nothing Then
                    .Item("Libelle") = rwProduit("Libelle")
                    .Item("nCompte") = rwProduit("nCompteV")
                    .Item("nActivite") = rwProduit("nActiviteV")
                    .Item("LibUnite1") = rwProduit("Unite1")
                    .Item("LibUnite2") = rwProduit("Unite2")
                    .Item("TTVA") = rwProduit("TTVA")
                    .Item("PrixUTTC") = rwProduit("PrixVTTC")
                Else
                    .Item("Libelle") = rwTrame("Plu")
                End If

                If Not IsDBNull(rwTrame("Quantite")) Then .Item("Unite1") = rwTrame("Quantite")

                .Item("MontantLigneTTC") = rwTrame("Montant")
                If Not IsDBNull(.Item("TTVA")) Then
                    Dim rwsTVA() As DataRow = ds.Tables("TVA").Select(String.Format("TTVA='{0}'", .Item("TTVA")))
                    If rwsTVA.Length > 0 Then
                        .Item("MontantLigneTVA") = CDec(.Item("MontantLigneTTC")) * (CDec(rwsTVA(0)("TTaux")) / (1 + CDec(rwsTVA(0)("TTaux"))))
                    Else
                        .Item("MontantLigneTVA") = 0
                    End If
                Else
                    .Item("MontantLigneTVA") = 0
                End If
                .Item("MontantLigneHT") = CDec(.Item("MontantLigneTTC")) - CDec(.Item("MontantLigneTVA"))
                MontantTTC += CDec(.Item("MontantLigneTTC"))
                MontantTVA += CDec(.Item("MontantLigneTVA"))
            End With
            ds.Tables("VFacture_Detail").Rows.Add(rwDetail)
        Next
        'Bouclage de la dernière facture générée
        If Not rwFacture Is Nothing Then
            With rwFacture
                .Item("MontantTVA") = MontantTVA
                .Item("MontantTTC") = MontantTTC
                .Item("MontantHT") = MontantTTC - MontantTVA
            End With
        End If
    End Sub

    Private Sub Mira_RecptionTerminee(ByVal OkFin As Boolean, ByVal strErreur As String) Handles Mira.RecptionTerminee
        If OkFin Then
            MessageBox.Show("Réception Terminée" & vbCrLf & strErreur)
        Else
            MessageBox.Show("La réception ne semble pas s'être terminée correctement" & vbCrLf & strErreur, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class
