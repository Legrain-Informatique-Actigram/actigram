Public Class Pieces
    Public Enum TypePieces
        None
        ABonReception
        AFacture
        AReglement
        VDevis
        VBonCommande
        VBonLivraison
        VFacture
        Reglement
        Mouvement
    End Enum

#Region "Méthodes partagées"
    Public Shared Function GetAV(ByVal type As TypePieces) As String
        Select Case type
            Case TypePieces.ABonReception, TypePieces.AFacture : Return "A"
            Case Else : Return "V"
        End Select
    End Function

    Public Shared Function GetDestination(ByVal type As TypePieces) As TypePieces
        Select Case type
            Case TypePieces.ABonReception : Return TypePieces.AFacture
            Case TypePieces.AFacture : Return TypePieces.AReglement
            Case TypePieces.VDevis : Return TypePieces.VBonCommande
            Case TypePieces.VBonCommande : Return TypePieces.VBonLivraison
            Case TypePieces.VBonLivraison : Return TypePieces.VFacture
            Case TypePieces.VFacture : Return TypePieces.Reglement
            Case Else : Return TypePieces.None
        End Select
    End Function

    Public Shared Function GetTablePrecedente(ByVal type As TypePieces) As TypePieces
        Select Case type
            Case TypePieces.AReglement : Return TypePieces.AFacture
            Case TypePieces.AFacture : Return TypePieces.ABonReception
            Case TypePieces.VBonCommande : Return TypePieces.VDevis
            Case TypePieces.VBonLivraison : Return TypePieces.VBonCommande
            Case TypePieces.VFacture : Return TypePieces.VBonLivraison
            Case TypePieces.Reglement : Return TypePieces.VFacture
            Case Else : Return TypePieces.None
        End Select
    End Function

    Public Shared Function GetLibelle(ByVal type As TypePieces) As String
        Select Case type
            Case TypePieces.ABonReception : Return "Bon de Reception"
            Case TypePieces.VDevis : Return "Devis"
            Case TypePieces.VBonCommande : Return "Bon de Commande"
            Case TypePieces.VBonLivraison : Return "Bon de Livraison"
            Case TypePieces.VFacture, TypePieces.AFacture : Return "Facture"
            Case TypePieces.Reglement, TypePieces.AReglement : Return "Règlement"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function GetSexe(ByVal type As TypePieces) As String
        Select Case type
            Case TypePieces.VFacture, TypePieces.AFacture : Return "F"
            Case Else : Return "M"
        End Select
    End Function

    Public Shared Function GetLibelleCourt(ByVal type As TypePieces) As String
        Select Case type
            Case TypePieces.VBonCommande : Return "Commande"
            Case TypePieces.VBonLivraison : Return "Livraison"
            Case TypePieces.VFacture, TypePieces.AFacture : Return "Facture"
            Case TypePieces.Reglement, TypePieces.AReglement : Return "Règlement"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function GetLibelleCourtCourt(ByVal type As TypePieces) As String
        Select Case type
            Case TypePieces.VBonCommande : Return "Cmde"
            Case TypePieces.VBonLivraison : Return "Livr"
            Case TypePieces.VFacture, TypePieces.AFacture : Return "Fact"
            Case TypePieces.Reglement, TypePieces.AReglement : Return "Regler"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function GetLibelleType(ByVal type As TypePieces) As String
        Return GetLibelleType(GetAV(type))
    End Function

    Public Shared Function GetLibelleType(ByVal AV As String) As String
        Select Case AV
            Case "A" : Return "Fournisseur"
            Case "V" : Return "Client"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function Pluriel(ByVal libelle As String) As String
        libelle = libelle.Trim
        Dim posSpace As Integer = libelle.IndexOf(" "c)
        Dim premierMot As String = libelle
        Dim reste As String = ""
        If posSpace > -1 Then
            premierMot = libelle.Substring(0, posSpace)
            reste = libelle.Substring(posSpace + 1)
        End If
        If Not premierMot.EndsWith("s") Then
            premierMot &= "s"
        End If
        Return String.Format("{0} {1}", premierMot, reste).Trim
    End Function

    Public Shared Function GetAdresseFacture(ByVal nClient As Integer, ByVal DesTable As String, Optional ByVal adresse As String = "") As String
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
                        Dim nomClient As String = String.Empty

                        If Not (IsDBNull(rwClient("NomLivraison"))) Then
                            nomClient = String.Format("{0}", rwClient("NomLivraison"))
                        Else
                            nomClient = String.Format("{0}", rwClient("Nom"))
                        End If

                        'strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", rwClient("Nom"), rwClient("AdresseLiv"), rwClient("CodePostalLiv"), rwClient("VilleLiv"))
                        strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", nomClient, rwClient("AdresseLiv"), rwClient("CodePostalLiv"), rwClient("VilleLiv"))

                        If dt.Columns.Contains("SuffixePostalLiv") Then
                            strAdresse &= " " & Convert.ToString(rwClient("SuffixePostalLiv"))
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

            'Pour les factures : si la fiche client ne possède pas d'adresse de facturation, on reprend l'adresse 
            'indiquée sur le BL.
            If (DesTable = "VFacture") Then
                Dim adresseFacturationClient As String = String.Empty

                If Not (rwClient.IsNull("Adresse")) Then
                    adresseFacturationClient = CStr(rwClient("Adresse"))
                End If

                If String.IsNullOrEmpty(adresseFacturationClient) Then
                    If Not (String.IsNullOrEmpty(adresse)) Then
                        strAdresse = adresse

                        AdresseOk = True
                    End If
                End If
            End If

            If Not AdresseOk Then
                Dim nomClient As String = String.Empty

                If Not (IsDBNull(rwClient("NomFacturation"))) Then
                    nomClient = String.Format("{0}", rwClient("NomFacturation"))
                Else
                    If Not (IsDBNull(rwClient("Civilite"))) Then
                        nomClient = String.Format("{0}", rwClient("Civilite")) & " " & String.Format("{0}", rwClient("Nom"))
                    Else
                        nomClient = String.Format("{0}", rwClient("Nom"))
                    End If

                End If

                'strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", rwClient("Nom"), rwClient("Adresse"), rwClient("CodePostal"), rwClient("Ville"))
                strAdresse = String.Format("{0}/r/n{1}/r/n{2} {3}", nomClient, rwClient("Adresse"), rwClient("CodePostal"), rwClient("Ville"))

                If dt.Columns.Contains("SuffixePostal") Then
                    strAdresse &= " " & Convert.ToString(rwClient("SuffixePostal"))
                End If

                If dt.Columns.Contains("Pays") Then
                    Dim strPays As String = Convert.ToString(rwClient("Pays"))

                    If strPays.Length > 0 Then
                        strAdresse &= vbCrLf & strPays
                    End If
                End If
            End If
        End If

        Return strAdresse.Replace("/r", vbCr).Replace("/n", vbLf).Trim
    End Function

    Public Shared Sub AnnulerNFacture(ByVal Table As String, ByVal nFacture As Long)
        Using s As New SqlProxy
            AnnulerNFacture(s, Table, nFacture)
        End Using
    End Sub

    Public Shared Sub AnnulerNFacture(ByVal s As SqlProxy, ByVal Table As String, ByVal nFacture As Long)
        s.ExecuteNonQuery(SqlProxy.FormatSql("Exec RemoveLastNFacture {0},{1},{2}", Table, nFacture, False))
    End Sub

    Public Shared Function GetNFacture(ByVal Table As Pieces.TypePieces, Optional ByVal Simulation As Boolean = False) As Long
        Using s As New SqlProxy
            Return GetNFacture(s, Table, Simulation)
        End Using
    End Function

    Public Shared Function GetNFacture(ByVal s As SqlProxy, ByVal Table As Pieces.TypePieces, Optional ByVal Simulation As Boolean = False) As Long
        Dim vDefaut As Long = GetNFactureDefaut(Table)
        Return Math.Max(s.ExecuteScalarInt(SqlProxy.FormatSql("Exec GetNextNFacture {0},{1},{2}", Table.ToString, vDefaut, Simulation)), 1)
    End Function

    'MODIF TV 06/09/2012 --------------------------
    Public Shared Function GetNDevis(ByVal Table As Pieces.TypePieces) As Long
        Using s As New SqlProxy
            Return GetNDevis(s, Table)
        End Using
    End Function

    Public Shared Function GetNDevis(ByVal s As SqlProxy, ByVal Table As Pieces.TypePieces) As Long
        Return Math.Max(s.ExecuteScalarInt(SqlProxy.FormatSql("Exec GetNextNDevis {0}", Table.ToString)), 1)
    End Function

    Public Shared Function GetNDetailDevis(ByVal nomTableDetail As String) As Long
        Using s As New SqlProxy
            Return GetNDetailDevis(s, nomTableDetail)
        End Using
    End Function

    Public Shared Function GetNDetailDevis(ByVal s As SqlProxy, ByVal nomTableDetail As String) As Long
        Return Math.Max(s.ExecuteScalarInt(SqlProxy.FormatSql("Exec GetNextNDetailDevis {0}", nomTableDetail)), 1)
    End Function
    'FIN MODIF TV 06/09/2012 -------------------------------------

    'Pour se recaler sur le véritable dernier n° de facture utilisé (en cas de suppression de plusieurs factures)
    Public Shared Sub ReclaimNFacture(ByVal Table As Pieces.TypePieces)
        Dim vDefaut As Long = GetNFactureDefaut(Table)

        Dim sql As String = "DECLARE @NFacture int; " & vbCrLf & _
                            "CREATE TABLE #tmp (NextNFacture int) " & vbCrLf & _
                            "INSERT INTO #tmp EXEC GetNextNFacture {0},{1},0; " & vbCrLf & _
                            "SELECT @NFacture=NextNFacture FROM #tmp " & vbCrLf & _
                            "DROP TABLE #tmp " & vbCrLf & _
                            "WHILE (NOT EXISTS (SELECT * FROM " & Table & " WHERE nFacture=@nFacture))  " & vbCrLf & _
                            "   AND (@nFacture>0) BEGIN " & vbCrLf & _
                            "   SET @nFacture=@nFacture-1 " & vbCrLf & _
                            "END " & vbCrLf & _
                            "EXEC SetNextNFacture {0},@nFacture " & vbCrLf & _
                            "SELECT @nFacture as NextNFacture;"

        Using conn As New SqlProxy()
            conn.ExecuteNonQuery(SqlProxy.FormatSql(sql, Table, vDefaut))
        End Using
    End Sub

    Public Shared Sub SetNFacture(ByVal nomTable As String, ByVal nFacture As Long)
        Using s As New SqlProxy
            s.ExecuteNonQuery(SqlProxy.FormatSql("Exec SetNextNFacture {0},{1}", nomTable, nFacture))
        End Using
    End Sub

    Public Shared Function GetNFactureDefaut(ByVal Table As Pieces.TypePieces) As Long
        Dim vDefaut As Long
        Select Case Table
            Case TypePieces.AFacture
                vDefaut = FrApplication.ValeurDefault.FacturationFournisseur1
            Case TypePieces.VFacture
                vDefaut = FrApplication.ValeurDefault.FacturationClient1
            Case Else '"VDevis", "VBonCommande", "VBonLivraison", "ABonReception"
                vDefaut = 1
        End Select
        Return vDefaut
    End Function
#End Region

#Region " Shared impression Pieces "
    Public Shared Function PreparerDataset(ByVal type As Pieces.TypePieces) As DataSet
        Dim myDs As New DataSet
        With myDs
            .EnforceConstraints = False
            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(myDs, "Parametres", s, "Cle='Logo'")
                DefinitionDonnees.Instance.Fill(myDs, "TVA", s)
                DefinitionDonnees.Instance.Fill(myDs, "Tarif", s)
                DefinitionDonnees.Instance.Fill(myDs, "Famille", s)
                DefinitionDonnees.Instance.Fill(myDs, "Produit", s)
                DefinitionDonnees.Instance.FillSchema(myDs, "Entreprise", s)
                DefinitionDonnees.Instance.Fill(myDs, "TelephoneEntreprise", s) 'legrain 13/01/2016
                DefinitionDonnees.Instance.FillSchema(myDs, type.ToString, s)
                DefinitionDonnees.Instance.FillSchema(myDs, type.ToString & "_Detail", s)
                Select Case type
                    Case Pieces.TypePieces.AFacture, Pieces.TypePieces.VFacture
                        Dim _NomTableReglement As String = CStr(IIf(type = Pieces.TypePieces.VFacture, "Reglement", "AReglement"))
                        DefinitionDonnees.Instance.FillSchema(myDs, _NomTableReglement, s)
                        DefinitionDonnees.Instance.FillSchema(myDs, _NomTableReglement & "_Detail", s)
                End Select
            End Using
        End With
        Return myDs
    End Function

    Public Shared Function TrouverRapport(ByVal myds As DataSet, ByVal nomTable As String, Optional ByVal impressionTTC As Boolean = False, Optional ByVal factureMulti As Boolean = False, Optional ByVal gestionMarge As Boolean = False, Optional ByVal secteur As String = "") As GRC.FrFusion
        Dim fr As GRC.FrFusion
        Select Case nomTable
            Case "VFacture"
                If factureMulti _
                    AndAlso MessageBox.Show("Voulez-vous imprimer une facture détaillée ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    'Attention, la facture groupe est un état serveur !!
                    'Il n'y a pas de différence HT/TTC sur la facture groupée
                    fr = GestionImpression.TrouverRapport("RptFactureVenteTTCGroupe.rpt", secteur)
                Else
                    fr = GestionImpression.TrouverRapport(myds, String.Format("RptFactureVente{0}.rpt", IIf(impressionTTC, "TTC", "HT")), secteur)
                End If
                fr.TypePiece = "Facture"
            Case "AFacture"
                fr = GestionImpression.TrouverRapport(myds, String.Format("RptFactureAchat{0}.rpt", IIf(impressionTTC, "TTC", "HT")), secteur)
                fr.TypePiece = "Facture d'Apport"
            Case "VBonLivraison"
                'Impression BL chiffré ou non
                Dim sql As String = "SELECT EditionBLNonChiffre FROM Entreprise WHERE nEntreprise=" & String.Format("{0}", myds.Tables("Entreprise").Rows(0).Item("nEntreprise").ToString()) & ";"
                Dim blNonChiffre As Boolean = False

                Using sqlConnexion As New System.Data.SqlClient.SqlConnection(My.Settings.AgrifactConnString)
                    sqlConnexion.Open()

                    Dim sqlCommand As New System.Data.SqlClient.SqlCommand(sql, sqlConnexion)

                    Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = sqlCommand.ExecuteReader()

                    Try
                        While sqlDataReader.Read()
                            If Not (IsDBNull(sqlDataReader("EditionBLNonChiffre"))) Then
                                blNonChiffre = Convert.ToBoolean(sqlDataReader("EditionBLNonChiffre"))
                            End If
                        End While
                    Finally
                        sqlDataReader.Close()
                    End Try
                End Using

                If (blNonChiffre) Then
                    fr = GestionImpression.TrouverRapport(myds, "RptBonLivraisonVenteNonChiffre.rpt", secteur)
                Else
                    fr = GestionImpression.TrouverRapport(myds, String.Format("RptBonLivraisonVente{0}.rpt", IIf(impressionTTC, "TTC", "HT")), secteur)
                End If

                fr.TypePiece = "Bon de Livraison"
            Case "VBonCommande"
                fr = GestionImpression.TrouverRapport(myds, String.Format("RptBonCommandeVente{0}.rpt", IIf(impressionTTC, "TTC", "HT")), secteur)
                fr.TypePiece = "Bon de Commande"
            Case "VDevis"
                fr = GestionImpression.TrouverRapport(myds, String.Format("RptDevisVente{0}.rpt", IIf(impressionTTC, "TTC", "HT")), secteur)
                fr.TypePiece = "Devis"
            Case "ABonReception"
                fr = GestionImpression.TrouverRapport(myds, String.Format("RptABonReception{0}.rpt", IIf(gestionMarge, "Marge", "")), secteur)
                fr.TypePiece = "Bon de Réception"
            Case Else
                MessageBox.Show("Impression Non Disponible")
        End Select
        Return fr
    End Function

    Public Shared Sub RemplisDetailTVA(ByVal myDs As DataSet)
        Dim dt As DataTable = myDs.Tables.Add("TVA_DETAIL")
        With dt.Columns
            .Add("nTVA", GetType(Long))
            .Add("TTVA", GetType(String))
            .Add("TTaux", GetType(Decimal))
            .Add("TCoef", GetType(Decimal))
        End With

        For Each rwTVA As DataRow In myDs.Tables("TVA").Rows
            Select Case Convert.ToString(rwTVA.Item("TTVA"))
                Case "RPCH"
                    Dim rwTVADetail As DataRow = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = 5.5
                        .Item("TTaux") = 5.5
                        .Item("TCoef") = 0.75D '75% du TTC est taxé à 5.5%
                    End With
                    dt.Rows.Add(rwTVADetail)

                    rwTVADetail = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = 19.6
                        .Item("TTaux") = 19.6
                        .Item("TCoef") = 0.25D '25% du TTC est taxé à 19.6%
                    End With
                    dt.Rows.Add(rwTVADetail)
                Case Else
                    Dim rwTVADetail As DataRow = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = Convert.ToString(rwTVA.Item("TTVA"))
                        .Item("TTaux") = rwTVA.Item("TTaux")
                        .Item("TCoef") = 1
                    End With
                    dt.Rows.Add(rwTVADetail)
            End Select
        Next
    End Sub

    Public Shared Sub RemplirVFacture_Detail_Redevance(ByVal myDs As DataSet)
        Dim nDevis As Decimal = 0
        Dim VFacture_Detail_RedevanceDT As DsImpressionFacture.VFacture_Detail_RedevanceDataTable = Nothing

        If (myDs.Tables.Contains("VFacture")) Then
            'recherche du nDevis
            If (myDs.Tables("VFacture").Rows.Count > 0) Then
                Dim dr As DataRow = myDs.Tables("VFacture").Rows(0)

                nDevis = CDec(dr.Item("nDevis"))
            End If

            'Chargement des infos dans la table VFacture_Detail_Redevance
            Using VFacture_Detail_RedevanceTA As New DsImpressionFactureTableAdapters.VFacture_Detail_RedevanceTableAdapter
                VFacture_Detail_RedevanceDT = VFacture_Detail_RedevanceTA.GetDataBynDevis(nDevis)
            End Using

            'Ajout de la table au Dataset
            If Not (VFacture_Detail_RedevanceDT Is Nothing) Then
                myDs.Tables.Add(VFacture_Detail_RedevanceDT)
            End If
        End If
    End Sub

    Public Shared Sub AjouterCompteClient(ByVal myDs As DataSet, ByVal nomTable As String)
        With myDs
            If .Relations.Contains("Client" & nomTable) Then
                With .Tables("Entreprise").Columns
                    If Not .Contains("SituationCompte") Then
                        .Add("SituationCompte", GetType(Decimal))
                    End If
                End With

                Using dta As New DsPiecesTableAdapters.ReglementsTA
                    For Each rw As DataRow In .Tables(nomTable).Rows
                        Dim clientRow As DataRow = rw.GetParentRow("Client" & nomTable)
                        clientRow("SituationCompte") = dta.GetAvanceClient(CDec(clientRow("nEntreprise"))).GetValueOrDefault
                    Next
                End Using
                .AcceptChanges()
            End If
        End With
    End Sub

#End Region

End Class

'#Region "Recap TVA"

'Public Class RecapLigneTVA
'    Private LstTx As New Dictionary(Of String, List(Of DataRow))

'    Public Sub AddLigne(ByVal TTVA As String, ByVal rwLigne As DataRow)
'        If Not LstTx.ContainsKey(TTVA) Then
'            Dim Lst As New List(Of DataRow)
'            Lst.Add(rwLigne)
'            LstTx.Add(TTVA, Lst)
'        Else
'            Dim Lst As List(Of DataRow) = LstTx(TTVA)
'            Lst.Add(rwLigne)
'        End If
'    End Sub

'    Public Function GetRowsTTVA(ByVal TTVA As String) As DataRow()
'        If LstTx.ContainsKey(TTVA) Then
'            Return LstTx(TTVA).ToArray
'        Else
'            Return Nothing
'        End If
'    End Function

'    Public Function GetnRowsTTVA(ByVal TTVA As String) As String()
'        If LstTx.ContainsKey(TTVA) Then
'            Dim lst As List(Of DataRow) = LstTx(TTVA)
'            Dim rws(lst.Count - 1) As String
'            For i As Integer = 0 To lst.Count - 1
'                rws(i) = Convert.ToString(lst(i)("nDetailDevis"))
'            Next
'            Return rws
'        Else
'            Return Nothing
'        End If
'    End Function
'End Class

'Public Class ElementRecapTva
'    Public TxTva As Decimal = 0D
'    Public MontantHT As Decimal = 0D
'    Public MontantTTC As Decimal = 0D

'    Public ReadOnly Property MontantTVA() As Decimal
'        Get
'            Dim res As Decimal
'            If MontantHT <> 0 Then
'                res = Me.MontantHT * (Me.TxTva / 100)
'            Else
'                res = Me.MontantTTC * (Me.TxTva / (100 + Me.TxTva))
'            End If
'            Return Actigram.MathUtil.ArithmeticRound(res, 2)
'        End Get
'    End Property

'    Public Sub New()

'    End Sub

'    Public Sub New(ByVal TxTVA As Decimal, ByVal MontantHT As Decimal, ByVal MontantTTC As Decimal)
'        With Me
'            .TxTva = TxTVA
'            .MontantHT = Actigram.MathUtil.ArithmeticRound(MontantHT, 2)
'            .MontantTTC = Actigram.MathUtil.ArithmeticRound(MontantTTC, 2)
'        End With
'    End Sub

'    Public Sub Add(ByVal montant As ElementRecapTva)
'        With montant
'            If Me.TxTva <> .TxTva Then Throw New ArgumentException("Addition impossible avec des taux de TVA différents")
'            Me.MontantHT += .MontantHT
'            Me.MontantTTC += .MontantTTC
'        End With
'    End Sub

'    Public Shared Function Add(ByVal montant1 As ElementRecapTva, ByVal montant2 As ElementRecapTva) As ElementRecapTva
'        If montant1.TxTva <> montant2.TxTva Then Throw New ArgumentException("Addition impossible avec des taux de TVA différents")
'        Dim montant As New ElementRecapTva
'        With montant
'            .MontantHT = montant1.MontantHT + montant2.MontantHT
'            .MontantTTC = montant1.MontantTTC + montant2.MontantTTC
'        End With
'        Return montant
'    End Function
'End Class

'Public Class RecapTVA
'    Private LstTx As New Dictionary(Of String, ElementRecapTva)

'    Public Sub AddMontant(ByVal TTVA As String, ByVal TxTVA As Decimal, ByVal MontantHT As Decimal, ByVal MontantTTC As Decimal)
'        If TTVA = "RPCH" Then
'            Dim Montant55 As ElementRecapTva
'            Dim Montant196 As ElementRecapTva
'            If MontantTTC = 0D Then
'                Dim CoefTVA55 As Decimal = 0.75D * 1.08704D / 1.055D
'                Montant55 = New ElementRecapTva(5.5D, MontantHT * CoefTVA55, 0)
'                Montant196 = New ElementRecapTva(19.6D, MontantHT - Montant55.MontantHT, 0)
'                AddMontant("5.5", Montant55)
'                AddMontant("19.6", Montant196)
'            Else
'                Dim CoefTVA55 As Decimal = 0.75D
'                Montant55 = New ElementRecapTva(5.5D, 0, MontantTTC * CoefTVA55)
'                Montant196 = New ElementRecapTva(19.6D, 0, MontantTTC - Montant55.MontantTTC)
'            End If
'            AddMontant("5.5", Montant55)
'            AddMontant("19.6", Montant196)
'        Else
'            AddMontant(TTVA, New ElementRecapTva(TxTVA, MontantHT, MontantTTC))
'        End If
'    End Sub

'    Public Sub AddMontant(ByVal TTVA As String, ByVal Montant As ElementRecapTva)
'        If Not LstTx.ContainsKey(TTVA) Then
'            LstTx.Add(TTVA, Montant)
'        Else
'            LstTx(TTVA).Add(Montant)
'        End If
'    End Sub

'    Public Function MontantTVATaux(ByVal TTVA As String) As Decimal
'        Return Actigram.MathUtil.ArithmeticRound(LstTx(TTVA).MontantTVA, 2)
'    End Function

'    Public Function TxTVA(ByVal TTVA As String) As Decimal
'        Return LstTx(TTVA).TxTva
'    End Function

'    Public Function MontantHTTaux(ByVal TTVA As String) As Decimal
'        Return LstTx(TTVA).MontantHT
'    End Function

'    Public Function MontantTTCTaux(ByVal TTVA As String) As Decimal
'        Return LstTx(TTVA).MontantTTC
'    End Function

'    Public Function MontantTVATotal() As Decimal
'        Dim MontantTotal As Decimal = 0
'        For Each el As ElementRecapTva In LstTx.Values
'            MontantTotal += Actigram.MathUtil.ArithmeticRound(el.MontantTVA, 2)
'        Next
'        Return MontantTotal
'    End Function

'    Public Function GetLstTx() As String()
'        Dim LstTxTVA(LstTx.Keys.Count - 1) As String
'        LstTx.Keys.CopyTo(LstTxTVA, 0)
'        Return LstTxTVA
'    End Function

'End Class
'#End Region

Public Class RecapTVA

#Region " Const "
    Public Enum ModeTaux
        HtToTva
        HtToTtc
        TtcToTva
        TtcToHt
    End Enum
#End Region

#Region " Shared "
    Private Shared dicTaux As New Dictionary(Of String, Dictionary(Of Decimal, Decimal))

    Public Shared Function GetTauxEffectifTVA(ByVal dt As DataTable, ByVal TTVA As String, Optional ByVal mode As ModeTaux = ModeTaux.HtToTva) As Nullable(Of Decimal)
        Dim taux As Dictionary(Of Decimal, Decimal) = GetTauxTVA(dt, TTVA)
        If taux.Count = 0 Then
            Return New Nullable(Of Decimal)
        Else
            Dim res As Decimal = 0D
            For Each tx As Decimal In taux.Keys
                res += TransformTaux(tx, mode) * taux(tx)
            Next
            Return res
        End If
    End Function

    Public Shared Function GetTauxTVA(ByVal dt As DataTable, ByVal TTVA As String) As Dictionary(Of Decimal, Decimal)
        Dim tx As Dictionary(Of Decimal, Decimal)
        If dicTaux.ContainsKey(TTVA) Then
            tx = dicTaux(TTVA)
            If tx.Count > 0 Then
                'tx = TransformTaux(tx.Value, mode)
            End If
        Else
            Dim rwTva() As DataRow = dt.Select("TTVA='" & TTVA.Replace("'", "''") & "'")
            If rwTva.Length = 0 Then
                tx = New Dictionary(Of Decimal, Decimal)
            Else
                tx = GetTauxTVA(rwTva(0))
            End If
            dicTaux.Add(TTVA, tx)
            Return tx
        End If
        Return tx
    End Function

    Public Shared Function GetTauxTVA(ByVal dr As DataRow) As Dictionary(Of Decimal, Decimal)
        If dr("TTVA").ToString = "RPCH" Then
            Dim res As New Dictionary(Of Decimal, Decimal)
            res.Add(0.055D, 0.75D)
            res.Add(0.196D, 0.25D)
            Return res
        Else
            If dr.IsNull("TTaux") Then
                Return New Dictionary(Of Decimal, Decimal)
            Else
                Dim tx As Decimal = CDec(dr("TTaux")) / 100
                Dim res As New Dictionary(Of Decimal, Decimal)
                res.Add(tx, 1D)
                Return res
            End If
        End If
    End Function

    Public Shared Function TransformTaux(ByVal tx As Decimal, ByVal mode As ModeTaux) As Decimal
        Select Case mode
            Case ModeTaux.HtToTva : Return tx
            Case ModeTaux.HtToTtc : Return (1 + tx)
            Case ModeTaux.TtcToHt : Return 1 / (1 + tx)
            Case ModeTaux.TtcToTva : Return tx / (1 + tx)
        End Select
    End Function
#End Region

#Region " Props "
    Private _TTVA As String
    Public Property TTVA() As String
        Get
            Return _TTVA
        End Get
        Set(ByVal value As String)
            _TTVA = value
        End Set
    End Property

    Private _taux As New Dictionary(Of Decimal, Decimal)
    Public Property Taux() As Dictionary(Of Decimal, Decimal)
        Get
            Return _taux
        End Get
        Set(ByVal value As Dictionary(Of Decimal, Decimal))
            _taux = value
        End Set
    End Property

    Private _detailBasesHT As New Dictionary(Of Decimal, Decimal)
    Public Property DetailBasesHT() As Dictionary(Of Decimal, Decimal)
        Get
            Return _detailBasesHT
        End Get
        Set(ByVal value As Dictionary(Of Decimal, Decimal))
            _detailBasesHT = value
        End Set
    End Property

    Private _montantsTVA As New Dictionary(Of Decimal, Decimal)
    Public Property MontantsTVA() As Dictionary(Of Decimal, Decimal)
        Get
            Return _montantsTVA
        End Get
        Set(ByVal value As Dictionary(Of Decimal, Decimal))
            _montantsTVA = value
        End Set
    End Property

    Private _baseHT As Decimal
    Public Property BaseHT() As Decimal
        Get
            Return _baseHT
        End Get
        Set(ByVal value As Decimal)
            _baseHT = value
        End Set
    End Property

    Public ReadOnly Property MontantTotalTVA() As Decimal
        Get
            Dim res As Decimal
            For Each tx As Decimal In Me.MontantsTVA.Keys
                res += Me.MontantsTVA(tx)
            Next
            Return res
        End Get
    End Property

    Private _montantTTC As Decimal
    Public Property MontantTTC() As Decimal
        Get
            Return _montantTTC
        End Get
        Set(ByVal value As Decimal)
            _montantTTC = value
        End Set
    End Property
#End Region

#Region " Ctor "
    Public Sub New()

    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal ttva As String)
        Me.New()
        Dim dr As DataRow = SelectSingleRow(ds.Tables("TVA"), FormatExpression("TTVA={0}", ttva), "")
        Init(dr)
    End Sub

    Public Sub New(ByVal dr As DataRow)
        Me.New()
        Init(dr)
    End Sub

    Private Sub Init(ByVal dr As DataRow)
        If dr IsNot Nothing Then
            Me.TTVA = Convert.ToString(dr("TTVA"))
            Me.Taux = GetTauxTVA(dr)
            For Each tx As Decimal In Me.Taux.Keys
                Me.MontantsTVA.Add(tx, 0D)
                Me.DetailBasesHT.Add(tx, 0D)
            Next
        End If
        'TODO GERER RPCH
        'Ajout des lignes de récap TVA avec gestion spéciale pour le RPCH
        'If Convert.ToString(drDetail.Item("TTVA")) = "RPCH" Then
        '    RecapTxLigneTVA.AddLigne("5.5", rwv)
        '    RecapTxLigneTVA.AddLigne("19.6", rwv)
        'Else
        '    RecapTxLigneTVA.AddLigne(Convert.ToString(rwv.Item("TTVA")), rwv)
        'End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Sub CalculerFromTTC(ByVal montantTTC As Decimal)
        Me.MontantTTC = montantTTC
        Me.BaseHT = 0D
        For Each tx As Decimal In Me.Taux.Keys
            Dim ttc As Decimal = Me.MontantTTC * Me.Taux(tx)
            Dim ht As Decimal = Decimal.Round(ttc * TransformTaux(tx, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)
            Me.DetailBasesHT(tx) = ht
            Me.MontantsTVA(tx) = ttc - ht
            Me.BaseHT += ht
        Next
    End Sub

    Public Sub CalculerFromTTC2(ByVal montantTTC As Decimal)
        Me.MontantTTC = Me.MontantTTC + montantTTC
        'Me.BaseHT = 0D
        For Each tx As Decimal In Me.Taux.Keys
            Dim ttc As Decimal = montantTTC * Me.Taux(tx)
            Dim ht As Decimal = Decimal.Round(ttc * TransformTaux(tx, ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)
            Me.DetailBasesHT(tx) = Me.DetailBasesHT(tx) + ht
            Me.MontantsTVA(tx) = Me.MontantsTVA(tx) + (ttc - ht)
            Me.BaseHT += ht
        Next
    End Sub

    Public Sub CalculerFromHT(ByVal montantHT As Decimal)
        Me.BaseHT = montantHT
        Me.MontantTTC = 0D
        For Each tx As Decimal In Me.Taux.Keys
            Dim ht As Decimal = Me.BaseHT * Me.Taux(tx)
            Dim ttc As Decimal = Decimal.Round(ht * TransformTaux(tx, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)
            Me.DetailBasesHT(tx) = ht
            Me.MontantsTVA(tx) = ttc - ht
            Me.MontantTTC += ttc
        Next
    End Sub

    Public Sub CalculerFromHT2(ByVal montantHT As Decimal)
        Me.BaseHT = Me.BaseHT + montantHT
        'Me.MontantTTC = 0D
        For Each tx As Decimal In Me.Taux.Keys
            Dim ht As Decimal = montantHT * Me.Taux(tx)
            Dim ttc As Decimal = Decimal.Round(ht * TransformTaux(tx, ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)
            Me.DetailBasesHT(tx) = Me.DetailBasesHT(tx) + ht
            Me.MontantsTVA(tx) = Me.MontantsTVA(tx) + (ttc - ht)
            Me.MontantTTC += ttc
        Next
    End Sub

    Public Sub AddMontantTTC(ByVal montantTTC As Decimal)
        montantTTC += Me.MontantTTC
        CalculerFromTTC(montantTTC)
    End Sub

    Public Sub AddMontantHT(ByVal montantHT As Decimal)
        montantHT += Me.BaseHT
        CalculerFromHT(montantHT)
    End Sub
#End Region

End Class

Public Class LigneCommande
    Private _CodeProduit As String
    Public Libelle As String
    Public Unite1 As Decimal
    Public Unite2 As Decimal
    Public LibUnite1 As String
    Public LibUnite2 As String
    Public Remise As Decimal
    Public PrixU As Decimal
    Public PrixUHT As Decimal
    Public PrixUTTC As Decimal
    Public TTVA As String
    Public MontantLigne As Decimal
    Public MontantLigneHT As Decimal
    Public MontantLigneTVA As Decimal
    Public MontantLigneTTC As Decimal
    Public MontantLigneTTCVente As Decimal
    Public CoefAv As Decimal
    Public PrixUTTCVente As Decimal
    Public PrixAHT As Decimal
    Public PrixAHT1 As Decimal
    Public CoefAV1 As Decimal
    Public PVTheo1 As Decimal
    Public PVBalance1 As Decimal
    Public MargePrCt1 As Decimal
    Public MargeEuro1 As Decimal
    'Private nClient As Long
    'Private nTarif As Long
    Private TypeFacturationTTC As Boolean
    Private ds As DataSet
    Private rwFact As DataRow
    Private TypePiece As String
    Private _NomTable As String
    Private RecalculAuto As Boolean = True

#Region "Propriétés"
    Public Property U1() As Decimal
        Get
            Return Unite1
        End Get
        Set(ByVal Value As Decimal)
            Unite1 = Value
            PrixUChanged()
        End Set
    End Property

    Public Property U2() As Decimal
        Get
            Return Unite2
        End Get
        Set(ByVal Value As Decimal)
            Unite2 = Value
            PrixUChanged()
        End Set
    End Property

    Public Property PrixUnitaire() As Decimal
        Get
            Return PrixU
        End Get
        Set(ByVal Value As Decimal)
            PrixU = Value
            PrixUChanged()
        End Set
    End Property

    Public Property PrCtRemise() As Decimal
        Get
            Return Remise
        End Get
        Set(ByVal Value As Decimal)
            Remise = Value
            PrixUChanged()
        End Set
    End Property

    Public Property MontantLigneCmd() As Decimal
        Get
            Return MontantLigne
        End Get
        Set(ByVal Value As Decimal)
            MontantLigne = Value
            MontantChanged()
        End Set
    End Property

    Public Property CodeProduit() As String
        Get
            Return _CodeProduit
        End Get
        Set(ByVal Value As String)
            _CodeProduit = Value
            CodeProduitChanged()
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByRef monDs As DataSet, ByRef monrwFacture As DataRow, ByVal nomTable As String, ByVal strCodeProduit As String, ByVal bTypeFacturationTTC As Boolean, ByVal strTypePiece As String)
        ds = monDs
        rwFact = monrwFacture
        TypePiece = strTypePiece
        _NomTable = nomTable
        TypeFacturationTTC = bTypeFacturationTTC
        CodeProduit = strCodeProduit
        'CodeProduitChanged()
    End Sub

    Public Sub New(ByRef monDs As DataSet, ByRef monrwFacture As DataRow, ByVal nomTable As String, ByVal strCodeProduit As String, ByVal strTypePiece As String)
        ds = monDs
        rwFact = monrwFacture
        TypePiece = strTypePiece
        _NomTable = nomTable
        TypeFacturationTTC = CBool(rwFact("FacturationTTC"))
        CodeProduit = strCodeProduit
        'CodeProduitChanged()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub CodeProduitChanged()
        Dim gestionMarge As Boolean = FrApplication.Modules.ModuleGestionMarge
        If _CodeProduit <> "" Then
            Dim rw() As DataRow = ds.Tables("Produit").Select("CodeProduit='" & _CodeProduit.Replace("'", "''") & "'")
            If rw.GetUpperBound(0) = 0 Then
                Libelle = Convert.ToString(rw(0).Item("Libelle"))
                If Convert.ToString(rw(0).Item("LibelleLong")) <> "" Then
                    Libelle += vbCrLf & Convert.ToString(rw(0).Item("LibelleLong"))
                End If
                Unite1 = 1
                LibUnite1 = Convert.ToString(rw(0).Item("Unite1"))
                LibUnite2 = Convert.ToString(rw(0).Item("Unite2"))
                If Not rw(0).Item("CoefAV") Is DBNull.Value Then
                    CoefAv = Convert.ToDecimal(rw(0).Item("CoefAV"))
                End If
                If Not rw(0).Item("CoefU2") Is DBNull.Value Then
                    Unite2 = 1 * Convert.ToDecimal(rw(0).Item("CoefU2"))
                Else
                    If LibUnite2 <> "" Then
                        Unite2 = 1
                    Else
                        Unite2 = 0
                    End If
                End If
                If Convert.ToString(rwFact.Item("nClient")) <> "" Then
                    Dim rwClient() As DataRow = ds.Tables("Entreprise").Select("nEntreprise=" & Convert.ToString(rwFact.Item("nClient")))
                    TTVA = Convert.ToString(rw(0).Item("TTVA"))
                    If rwClient.GetUpperBound(0) >= 0 Then
                        If Convert.ToString(rwClient(0).Item("TTVA")) <> "" Then
                            TTVA = Convert.ToString(rwClient(0).Item("TTVA"))
                        End If
                        If Convert.ToString(rwClient(0).Item("Remise")) <> "" Then
                            Remise = Convert.ToDecimal(rwClient(0).Item("Remise"))
                        End If
                    End If
                End If
                Dim TxTauxTVA As Decimal = Me.GetTxTaux(TTVA)
                Dim _PrixUHT As Object
                Dim _PrixUTTC As Object
                Dim OkPrix As Boolean = False
                Dim rwFacture As DataRow = rwFact
                If TypePiece <> "A" Then
                    If rwFacture.Table.Columns.Contains("nTarif") Then
                        If Not rwFacture.Item("nTarif") Is DBNull.Value Then
                            If Convert.ToDecimal(rwFacture.Item("nTarif")) <> 0 Then
                                Dim rwTarif() As DataRow = ds.Tables("Tarif_Detail").Select("nTarif=" & Convert.ToString(rwFacture.Item("nTarif")) & " And CodeProduit='" & Convert.ToString(rw(0).Item("CodeProduit")).Replace("'", "''") & "'")
                                If rwTarif.GetUpperBound(0) >= 0 Then
                                    _PrixUHT = rwTarif(0).Item("PrixVHT")
                                    _PrixUTTC = rwTarif(0).Item("PrixVTTC")
                                    OkPrix = True
                                End If
                            End If
                        End If
                    End If
                End If
                If OkPrix = False Then
                    _PrixUHT = rw(0).Item("Prix" & TypePiece & "HT")
                    _PrixUTTC = rw(0).Item("Prix" & TypePiece & "TTC")
                End If

                If Convert.ToBoolean(rwFacture.Item("FacturationTTC")) = True Then
                    If Convert.ToString(_PrixUTTC) = "" And Convert.ToString(_PrixUHT) <> "" Then
                        PrixUTTC = Actigram.MathUtil.ArithmeticRound((Convert.ToDecimal(_PrixUHT) * (1 + TxTauxTVA / 100)), 2)
                    Else
                        PrixUTTC = Convert.ToDecimal(_PrixUTTC)
                    End If
                    PrixU = PrixUTTC
                Else
                    If Convert.ToString(_PrixUHT) = "" And Convert.ToString(_PrixUTTC) <> "" Then
                        PrixUHT = Actigram.MathUtil.ArithmeticRound((Convert.ToDecimal(_PrixUTTC) / (1 + TxTauxTVA / 100)), 2)
                    Else
                        If _PrixUHT Is DBNull.Value Then _PrixUHT = 0
                        PrixUHT = Convert.ToDecimal(_PrixUHT)
                    End If
                    PrixU = PrixUHT
                End If
                If Me.TypePiece = "A" And gestionMarge = True Then
                    If Not rw(0).Item("PrixVTTC") Is DBNull.Value Then
                        PrixUTTCVente = Convert.ToDecimal(rw(0).Item("PrixVTTC"))
                    Else
                        PrixUTTCVente = 0
                    End If
                    If Not rw(0).Item("CoefAv") Is DBNull.Value Then
                        CoefAv = Convert.ToDecimal(rw(0).Item("CoefAV"))
                    Else
                        CoefAv = 1
                    End If

                    Dim rwLstBl() As DataRow = ds.Tables(_NomTable & "_Detail").Select("CodeProduit='" & _CodeProduit.Replace("'", "''") & "' And nDevis<" & Convert.ToString(rwFact.Item("nDevis")), "nDevis Desc", DataViewRowState.CurrentRows)
                    If rwLstBl.GetUpperBound(0) >= 0 Then

                        Dim PA As Decimal = 0
                        Dim Coef As Decimal = 0
                        Dim PV As Decimal = 0
                        Dim TxTaux As Decimal = GetTxTaux(TTVA)
                        Try
                            PA = Decimal.Parse(Convert.ToString(rwLstBl(0).Item("PrixUHT")))
                        Catch ex As Exception
                        End Try
                        Try
                            Coef = Decimal.Parse(Convert.ToString(rwLstBl(0).Item("CoefAV")))
                        Catch ex As Exception
                        End Try
                        Try
                            PV = Decimal.Parse(Convert.ToString(rwLstBl(0).Item("PrixUTTCVente")))
                        Catch ex As Exception
                        End Try

                        PrixAHT1 = PA
                        CoefAV1 = Coef
                        PVTheo1 = Me.GetPrixTheo(PA, Coef, TxTaux)
                        PVBalance1 = PV
                        MargePrCt1 = Me.GetMargePrCt(PA, PV, TxTaux)
                        MargeEuro1 = Me.GetMargeEuro(PA, PV, TxTaux)
                    End If
                End If
                CalculMontantLigne()
            End If
        End If
    End Sub

    Private Function GetPrixTheo(ByVal PAHT As Decimal, ByVal Coef As Decimal, ByVal TxTaux As Decimal) As Decimal
        Coef = Coef / 100
        If Coef <> 0 Then
            If FrApplication.Parametres.ModeCalculCoefRestoBio = True Then
                Return PAHT * (Coef * 100) * (1 + TxTaux / 100)
            Else
                Return (((-(PAHT * (1 + TxTaux / 100))) / Coef) / (1 - (1 / Coef)))
            End If
        Else
            Return 0
        End If
    End Function

    Private Function GetMargePrCt(ByVal PAHT As Decimal, ByVal PVTTC As Decimal, ByVal TxTaux As Decimal) As Decimal
        If PVTTC <> 0 Then
            Return ((PVTTC - PAHT * (1 + TxTaux / 100)) / PVTTC) * 100
        Else
            Return 0
        End If
    End Function

    Private Function GetMargeEuro(ByVal PAHT As Decimal, ByVal PVTTC As Decimal, ByVal TxTaux As Decimal) As Decimal
        Return PVTTC - PAHT * (1 + TxTaux / 100)
    End Function

    Private Function GetTxTaux(ByVal strCodeTVA As String) As Decimal
        Dim txTva As Decimal = 0
        If strCodeTVA <> "" Then
            Dim rws() As DataRow = ds.Tables("TVA").Select("TTVA='" & strCodeTVA.Replace("'", "''") & "'")
            If rws.GetUpperBound(0) >= 0 Then
                If Not rws(0).Item("TTaux") Is DBNull.Value Then
                    txTva = Convert.ToDecimal(rws(0).Item("TTaux"))
                End If
            End If
        End If
        Return txTva
    End Function

    Private Sub MontantChanged()
        Dim MontantHT As Decimal = MontantLigne

        If ds.Tables("Produit").Columns.Contains("TypeFacturation") Then
            Select Case Convert.ToString(rwFact.Item("TypeFacturation"))
                Case "U1xU2"
                    PrixU = ((MontantHT / (1 - Remise / 100)) / U1 / U2)
                    'Me.TxMontantHT.Text = ((U1 * U2 * PrixU) * (1 - Remise / 100)).ToString
                Case "U2"
                    PrixU = ((MontantHT / (1 - Remise / 100)) / U2)
                    'Me.TxMontantHT.Text = ((U2 * PrixU) * (1 - Remise / 100)).ToString
                Case Else
                    PrixU = ((MontantHT / (1 - Remise / 100)) / U1)
                    'Me.TxMontantHT.Text = ((U1 * PrixU) * (1 - Remise / 100)).ToString
            End Select
        Else
            PrixU = ((MontantHT / (1 - Remise / 100)) / U1)
        End If
        If Me.TypeFacturationTTC = False Then
            PrixUHT = PrixU
        Else
            PrixUTTC = PrixU
        End If
    End Sub

    Private Sub PrixUChanged()
        If RecalculAuto = False Then Exit Sub
        RecalculAuto = False

        Dim GestionMarge As Boolean = FrApplication.Modules.ModuleGestionMarge
        Dim rw() As DataRow = ds.Tables("Produit").Select("CodeProduit='" & _CodeProduit.Replace("'", "''") & "'")
        Dim Pb As Boolean = False

        If Not rw(0).Item("CoefU2") Is DBNull.Value Then
            U2 = U1 * Convert.ToDecimal(rw(0).Item("CoefU2"))
        End If
        If Me.TypePiece = "A" Then
            Dim Prix As String = PrixU.ToString
            If Prix <> "" Then
                Dim rwP() As DataRow = ds.Tables("Produit").Select("CodeProduit='" & _CodeProduit.Replace("'", "''") & "'")
                If rwP.GetUpperBound(0) = 0 Then
                    If Me.TypeFacturationTTC = True Then
                        rwP(0).Item("PrixATTC") = Prix
                    Else
                        rwP(0).Item("PrixAHT") = Prix
                    End If
                End If
            End If
        End If
        CalculMontantLigne()
        If Me.TypePiece = "A" And GestionMarge = True Then
            PrixAHT = PrixU
        End If
        RecalculAuto = True
    End Sub

    Private Sub CalculMontantLigne()
        Dim GestionMarge As Boolean = FrApplication.Modules.ModuleGestionMarge
        Dim rw() As DataRow = ds.Tables("Produit").Select("CodeProduit='" & _CodeProduit.Replace("'", "''") & "'")

        Dim PrixUVente As Decimal = 0
        PrixUVente = Me.PrixUTTCVente

        If rw.GetUpperBound(0) >= 0 And ds.Tables("Produit").Columns.Contains("TypeFacturation") Then
            Select Case Convert.ToString(rw(0).Item("TypeFacturation"))
                Case "U1xU2"
                    MontantLigne = ((U1 * U2 * PrixU * (1 - Remise / 100)))
                    If TypePiece = "A" And GestionMarge = True Then
                        MontantLigneTTCVente = ((U1 * U2 * PrixUVente))
                    End If
                Case "U2"
                    MontantLigne = ((U2 * PrixU * (1 - Remise / 100)))
                    If TypePiece = "A" And GestionMarge = True Then
                        MontantLigneTTCVente = ((U2 * PrixUVente))
                    End If
                Case Else
                    MontantLigne = ((U1 * PrixU * (1 - Remise / 100)))
                    If TypePiece = "A" And GestionMarge = True Then
                        MontantLigneTTCVente = ((U1 * PrixUVente))
                    End If
            End Select
        Else
            MontantLigne = ((U1 * PrixU * (1 - Remise / 100)))
            If TypePiece = "A" And GestionMarge = True Then
                MontantLigneTTCVente = ((U1 * PrixUVente))
            End If
        End If

        If TypeFacturationTTC = False Then
            MontantLigneHT = Actigram.MathUtil.ArithmeticRound(MontantLigne, 2)
        Else
            MontantLigneTTC = Actigram.MathUtil.ArithmeticRound(MontantLigne, 2)
        End If
    End Sub

    Public Sub GetDataFromRw(ByRef rw As DataRow)
        Libelle = GetValeurString(rw, "Libelle")
        Unite1 = GetValeurDecimal(rw, "Unite1")
        Unite2 = GetValeurDecimal(rw, "Unite2")
        LibUnite1 = GetValeurString(rw, "LibUnite1")
        LibUnite2 = GetValeurString(rw, "LibUnite2")
        PrixUHT = GetValeurDecimal(rw, "PrixUHT")
        PrixUTTC = GetValeurDecimal(rw, "PrixUTTC")
        Remise = GetValeurDecimal(rw, "Remise")
        TTVA = GetValeurString(rw, "TTVA")
        MontantLigneHT = GetValeurDecimal(rw, "MontantLigneHT")
        MontantLigneTTC = GetValeurDecimal(rw, "MontantLigneTTC")
        If Me.TypeFacturationTTC = False Then
            PrixU = PrixUHT
            MontantLigne = MontantLigneHT
        Else
            PrixU = PrixUTTC
            MontantLigne = MontantLigneTTC
        End If
    End Sub

    Private Function GetValeurString(ByRef rw As DataRow, ByVal strChamps As String) As String
        If Not rw.Item(strChamps) Is DBNull.Value Then
            Return Convert.ToString(rw.Item(strChamps))
        Else
            Return ""
        End If
    End Function

    Private Function GetValeurDecimal(ByRef rw As DataRow, ByVal strChamps As String) As Decimal
        If Not rw.Item(strChamps) Is DBNull.Value Then
            Return Convert.ToDecimal(rw.Item(strChamps))
        End If
    End Function

    Public Sub SetDataToRw(ByRef rw As DataRow)
        Dim gestionMarge As Boolean = FrApplication.Modules.ModuleGestionMarge

        rw.BeginEdit()
        rw.Item("CodeProduit") = CodeProduit
        rw.Item("Libelle") = Libelle
        rw.Item("Unite1") = Unite1
        rw.Item("Unite2") = GetValeurDb(Unite2)
        rw.Item("LibUnite1") = LibUnite1
        rw.Item("LibUnite2") = LibUnite2
        rw.Item("Remise") = GetValeurDb(Remise)
        rw.Item("TTVA") = TTVA
        If Me.TypeFacturationTTC = False Then
            rw.Item("PrixUHT") = PrixUHT
            rw.Item("MontantLigneHT") = MontantLigneHT
            rw.Item("PrixUTTC") = DBNull.Value
            rw.Item("MontantLigneTTC") = DBNull.Value
        Else
            rw.Item("PrixUHT") = DBNull.Value
            rw.Item("MontantLigneHT") = DBNull.Value
            rw.Item("PrixUTTC") = PrixUTTC
            rw.Item("MontantLigneTTC") = MontantLigneTTC
        End If
        If Me.TypePiece = "A" And gestionMarge = True Then
            rw.Item("CoefAv") = Me.CoefAv
            rw.Item("PrixUTTCVente") = Me.PrixUTTCVente
        End If
        rw.EndEdit()
    End Sub

    Private Function GetValeurDb(ByVal strDecimal As Decimal) As Object
        If strDecimal <> 0 Then
            Return strDecimal
        Else
            Return DBNull.Value
        End If
    End Function
#End Region

End Class

