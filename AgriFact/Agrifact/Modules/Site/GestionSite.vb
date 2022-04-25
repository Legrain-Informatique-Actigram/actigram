Public Class GestionSite

    Public dsSource As DataSet
    Public login As String
    Public password As String

    Public Sub MajInfosSite()
        If dsSource Is Nothing Then Exit Sub
        If MessageBox.Show("Souhaitez-vous vraiment mettre à jour le site internet avec les données d'Agrifact ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim swSite As New SyncAgrifact.SrvSyncAgrifact
                swSite.Url = FrApplication.Parametres.ServiceGestionSite

                Dim ds As New DataSet
                Dim dt As New DataTable("Produit")
                With dt.Columns
                    '.Add("IdProduit", GetType(Integer))
                    .Add("CodeProduit")
                    .Add("Libelle")
                    .Add("IdCategorie", GetType(Integer))
                    .Add("Description")
                    .Add("Image")
                    .Add("FichierImage")
                    .Add("PrixTTC", GetType(Decimal))
                    .Add("Visible", GetType(Boolean))
                    .Add("TVA", GetType(Decimal))
                End With
                ds.Tables.Add(dt)

                Dim rw As DataRow
                For Each rw In dsSource.Tables("Produit").Rows
                    Dim rwN As DataRow = dt.NewRow
                    With rwn
                        .Item("CodeProduit") = rw("CodeProduit")
                        .Item("Libelle") = rw("Libelle")
                        .Item("Description") = rw("LibelleLong")
                        .Item("PrixTTC") = rw("PrixVTTC")
                        .Item("Visible") = Not CBool(rw("Inactif"))
                        .Item("IdCategorie") = rw("Famille1")
                        If Convert.ToString(rw("TTVA")) <> "" Then
                            Dim rwsTVA() As DataRow = dsSource.Tables("TVA").Select("TTVA='" & Convert.ToString(rw("TTVA")).Replace("'", "''") & "'")
                            If rwsTVA.Length > 0 Then
                                .Item("TVA") = rwsTVA(0).Item("TTaux")
                            End If
                        End If
                        Dim strImage As String = Convert.ToString(rw("Image"))
                        If strImage.Length > 0 Then
                            .Item("Image") = IO.Path.GetFileName(strImage)
                            .Item("FichierImage") = Actigram.Fichiers.ManipulationFichier.FichierToBase64(strImage)
                        End If
                    End With
                    dt.Rows.Add(rwN)
                Next
                swSite.UpDateProduit(login, password, ds)

                Dim dtClient As New DataTable("Client")
                With dtClient.Columns
                    .Add("n°Client", GetType(Integer))
                    .Add("Login")
                    .Add("Password")
                    .Add("TypeAcces")
                End With
                ds.Tables.Add(dtClient)

                For Each rw In dsSource.Tables("Entreprise").Rows
                    Dim rwN As DataRow = dtClient.NewRow
                    With rwn
                        .Item("n°Client") = GetIdSite(rw)
                        .Item("Login") = rw("LoginSite")
                        .Item("Password") = rw("PwdSite")
                        .Item("TypeAcces") = rw("TypeClient")
                    End With
                    dtClient.Rows.Add(rwn)
                Next
                swSite.UpDateClient(login, password, ds)

                MsgBox("Mise à jour du site terminée", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("Erreur lors de la mise à jour du site : " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Public Sub RecupInfosSite()
        If dsSource Is Nothing Then Exit Sub
        If MessageBox.Show("Souhaitez-vous vraiment récupérer les données qui ont été ajoutées au site dans Agrifact ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try

                Dim swSite As New SyncAgrifact.SrvSyncAgrifact
                swSite.Url = FrApplication.Parametres.ServiceGestionSite

                Dim nbFamille As Integer = 0
                Dim nbProduit As Integer = 0
                Dim nbClient As Integer = 0
                Dim nbBonCommande As Integer = 0

                'RECUPERATION DES FAMILLES
                Dim ds As DataSet = swSite.GetCategorie(login, password)
                Dim dtCat As DataTable = ds.Tables(0)
                Dim dtDest As DataTable = dsSource.Tables("Famille")
                Dim rw As DataRow
                For Each rw In dtCat.Rows
                    Dim rws() As DataRow = dtDest.Select("nFamille=" & Convert.ToString(rw.Item("IdCategorie")))
                    If rws.Length = 0 Then
                        Dim rwN As DataRow = dtDest.NewRow
                        With rwN
                            .Item("nFamille") = rw.Item("IdCategorie")
                            .Item("Famille") = rw.Item("Categorie")
                        End With
                        dtDest.Rows.Add(rwn)
                        nbFamille += 1
                    End If
                Next

                'RECUPERATION DES PRODUITS
                ds = swSite.GetProduit(login, password)
                Dim dtProd As DataTable = ds.Tables(0)
                dtDest = dsSource.Tables("Produit")
                For Each rw In dtProd.Rows
                    Dim rws() As DataRow = dtDest.Select("CodeProduit='" & Convert.ToString(rw.Item("CodeProduit")).Replace("'", "''") & "'")
                    If rws.Length = 0 Then
                        Dim rwN As DataRow = dtDest.NewRow
                        With rwn
                            .Item("CodeProduit") = rw.Item("CodeProduit")
                            .Item("Libelle") = rw.Item("Libelle")
                            .Item("Famille1") = rw.Item("IdCategorie")
                            .Item("Inactif") = Convert.ToBoolean(Convert.ToInt32(rw.Item("Visible")) - 1)
                            .Item("PrixVTTC") = rw.Item("PrixTTC")
                            .Item("TypeFacturation") = "U1"
                            .Item("GestionStock") = True
                            .Item("ProduitVente") = True
                            .Item("TTVA") = "19.6"
                            If Not IsDBNull(rw("TVA")) Then
                                Dim rwsT() As DataRow = dsSource.Tables("TVA").Select("TTaux=" & Convert.ToString(rw.Item("TVA")).Replace(",", "."))
                                If rwsT.Length > 0 Then
                                    .Item("TTVA") = rwsT(0).Item("TTVA")
                                End If
                            End If
                        End With
                        dtDest.Rows.Add(rwn)
                        nbProduit += 1
                    End If
                Next

                'RECUPERATION DES CLIENTS COMMANDES
                ds = swSite.GetCommande(login, password)
                Dim dtClients As DataTable = ds.Tables("Client")                
                dtDest = dsSource.Tables("Entreprise")
                For Each rw In dtClients.Rows
                    Dim rws() As DataRow = dtDest.Select("IdSite=" & Convert.ToString(rw.Item("n°Client")))
                    If rws.length = 0 Then rws = dtDest.Select("nEntreprise=" & Convert.ToString(Convert.ToInt32(rw.Item("n°Client")) * 1000 + 999))
                    If rws.Length = 0 Then
                        Dim rwn As DataRow = dtDest.NewRow
                        With rwn
                            .Item("nEntreprise") = Convert.ToInt32(rw.Item("n°Client")) * 1000 + 999
                            .Item("Client") = True
                            .Item("Civilite") = Convert.ToString(rw.Item("Civilite"))
                            .Item("Nom") = String.Format("{0} {1}", rw("Nom"), rw("Prenom")).Trim
                            .Item("Adresse") = rw.Item("Adresse")
                            .Item("CodePostal") = rw.Item("CodePostal")
                            .Item("Ville") = rw.Item("Ville")
                            .Item("AdresseLiv") = rw.Item("AdresseLivraison")
                            .Item("CodePostalLiv") = rw.Item("CodePostalLivraison")
                            .Item("VilleLiv") = rw.Item("VilleLivraison")
                            .Item("Observations") = rw.Item("ObsLivraison")
                            .Item("EMail") = rw.Item("EMail")
                            .Item("TypeClient") = rw.Item("TypeAcces")
                            .Item("IdSite") = rw.Item("n°Client")
                            .Item("LoginSite") = rw.Item("Login")
                            .Item("PwdSite") = rw.Item("Password")
                        End With
                        dtDest.Rows.Add(rwn)
                        dtDest = dsSource.Tables("TelephoneEntreprise")
                        If Convert.ToString(rw("Telephone")) <> "" Then
                            Dim rwnT As DataRow = dtDest.NewRow
                            With rwnT
                                .Item("nEntreprise") = rwn("nEntreprise")
                                .Item("Type") = "Tel"
                                .Item("Numero") = rw("Telephone")
                            End With
                            dtDest.Rows.Add(rwnt)
                        End If
                        If Convert.ToString(rw("Fax")) <> "" Then
                            Dim rwnT As DataRow = dtDest.NewRow
                            With rwnT
                                .Item("nEntreprise") = rwn("nEntreprise")
                                .Item("Type") = "Fax"
                                .Item("Numero") = rw("Fax")
                            End With
                            dtDest.Rows.Add(rwnt)
                        End If
                        If Convert.ToString(rw("TelephoneLivraison")) <> "" Then
                            Dim rwnT As DataRow = dtDest.NewRow
                            With rwnT
                                .Item("nEntreprise") = rwn("nEntreprise")
                                .Item("Type") = "Tel Liv"
                                .Item("Numero") = rw("TelephoneLivraison")
                            End With
                            dtDest.Rows.Add(rwnt)
                        End If
                        nbClient += 1
                    End If
                Next

                'RECUPERATION DES BONS DE COMMANDE
                Dim dtProds As DataTable = ds.Tables("Produit")
                Dim dtComs As DataTable = ds.Tables("BonCommande")
                Dim dtDetail As DataTable = ds.Tables("DetailCommande")
                dtDest = dsSource.Tables("VBonCommande")
                Dim dtDestDetail As DataTable = dsSource.Tables("VBonCommande_Detail")
                Dim nCommande As Integer = 0
                For Each rw In dtComs.Rows
                    nCommande += 1
                    Dim nDevis As Long = nCommande * 1000 + 999
                    Dim rws() As DataRow = dtDest.Select("nDevis=" & nDevis)
                    If rws.Length = 0 Then
                        Dim rwN As DataRow = dtDest.NewRow
                        With rwn
                            .Item("nDevis") = nDevis
                            .Item("nClient") = GetNEnt(CInt(rw("IdClient"))) ' Convert.ToInt32(rw("IdClient")) * 1000 + 999
                            .Item("NFacture") = Pieces.GetNFacture(Pieces.TypePieces.VBonCommande)
                            .Item("DateFacture") = rw("Date")
                            .Item("MontantTTC") = rw("TotalTTC")
                            .Item("FacturationTTC") = True
                        End With
                        dtDest.Rows.Add(rwn)

                        For Each rwDetail As DataRow In dtDetail.Select("IdCommande='" & Convert.ToString(rw("IdCommande")) & "'")
                            Dim rwProduit As DataRow = GetDrProduit(ds.Tables("Produit"), CInt(rwDetail("IdProduit")))
                            If Not rwProduit Is Nothing Then
                                Dim rwND As DataRow = dtDestDetail.NewRow
                                With rwND
                                    .Item("nDevis") = nDevis
                                    .Item("CodeProduit") = rwProduit.Item("CodeProduit")
                                    .Item("Libelle") = rwProduit.Item("Libelle")
                                    .Item("Unite1") = rwDetail.Item("Qt")
                                    If Convert.ToString(rwProduit.Item("Unite1")) <> "" Then
                                        .Item("LibUnite1") = rwProduit.Item("Unite1")
                                    Else
                                        .Item("LibUnite1") = "Bt"
                                    End If
                                    .Item("PrixUTTC") = Convert.ToDecimal(rwDetail.Item("PrixTTC")) / Convert.ToDecimal(rwDetail.Item("Qt"))
                                    .Item("TTVA") = rwProduit.Item("TTVA")
                                    .Item("MontantLigneTTC") = rwDetail.Item("PrixTTC")
                                End With
                                dtDestDetail.Rows.Add(rwND)
                            End If
                        Next

                        If Not IsDBNull(rw("Remise")) Then
                            If CDec(rw("Remise")) <> 0 Then
                                Dim RwND1 As DataRow = dtDestDetail.NewRow
                                With RwND1
                                    .Item("nDevis") = nDevis
                                    .Item("Libelle") = "Remise"
                                    .Item("Unite1") = -1
                                    .Item("TTVA") = "19.6"
                                    .Item("PrixUTTC") = CDec(rw("Remise"))
                                    .Item("MontantLigneTTC") = -CDec(rw("Remise"))
                                End With
                                dtDestDetail.Rows.Add(RwND1)
                            End If
                        End If

                        If Not IsDBNull(rw("Transport")) Then
                            If CDec(rw("Transport")) <> 0 Then
                                Dim RwND1 As DataRow = dtDestDetail.NewRow
                                With RwND1
                                    .Item("nDevis") = nDevis
                                    .Item("Libelle") = "Transport"
                                    .Item("Unite1") = 1
                                    .Item("TTVA") = "19.6"
                                    .Item("PrixUTTC") = CDec(rw("Transport"))
                                    .Item("MontantLigneTTC") = CDec(rw("Transport"))
                                End With
                                dtDestDetail.Rows.Add(RwND1)
                            End If
                        End If
                        nbBonCommande += 1
                    End If
                Next

                Dim tables As String() = {"Famille", "Produit", "Entreprise", "VBonCommande", "VBonCommande_Detail"}
                Using s As New SqlProxy
                    s.UpdateTables(Me.dsSource, tables)
                End Using

                Dim strInfo As New System.Text.StringBuilder
                If nbFamille > 0 Then strInfo.AppendFormat("{0} Famille{1} ajoutée{1}" & vbCrLf, nbFamille, IIf(nbFamille = 1, "", "s"))
                If nbProduit > 0 Then strInfo.AppendFormat("{0} Produit{1} ajouté{1}" & vbCrLf, nbProduit, IIf(nbProduit = 1, "", "s"))
                If nbClient > 0 Then strInfo.AppendFormat("{0} Client{1} ajouté{1}" & vbCrLf, nbClient, IIf(nbClient = 1, "", "s"))
                If nbBonCommande > 0 Then strInfo.AppendFormat("{0} Bon{1} de Commande{1} ajouté{1}" & vbCrLf, nbBonCommande, IIf(nbBonCommande = 1, "", "s"))
                If strInfo.Length = 0 Then strInfo.Append("Il n'y a pas de nouvelles données sur le site.")
                MsgBox(strInfo.ToString.Trim, MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("Erreur lors de la récupération des données du site : " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Function GetNEnt(ByVal idSite As Integer) As Integer
        Dim rws() As DataRow = dsSource.Tables("Entreprise").Select("IdSite=" & idSite)
        If rws.Length = 0 Then rws = dsSource.Tables("Entreprise").Select("nEntreprise=" & Convert.ToString(idSite * 1000 + 999))
        If rws.Length = 0 Then
            Return -1
        Else
            Return CInt(rws(0)("nEntreprise"))
        End If
    End Function

    Private Function GetIdSite(ByVal rw As DataRow) As Long
        Dim res As Long
        If Not IsDBNull(rw("IdSite")) Then
            res = CInt(rw("IdSite"))
        Else
            res = (Convert.ToInt64(rw.Item("nEntreprise")) - 999) \ 1000
        End If
        Return res
    End Function

    Private Function GetDrProduit(ByVal dtSite As DataTable, ByVal idProd As Integer) As DataRow
        Dim drsSite() As DataRow = dtSite.Select("IdProduit=" & idProd)
        If drsSite.Length > 0 Then
            If Not IsDBNull(drsSite(0)("CodeProduit")) Then
                Dim rws() As DataRow = dsSource.Tables("Produit").Select(String.Format("CodeProduit='{0}'", CStr(drsSite(0)("CodeProduit")).Replace("'", "''")))
                If rws.Length > 0 Then
                    Return rws(0)
                End If
            End If
        End If
        Return Nothing
    End Function

End Class
