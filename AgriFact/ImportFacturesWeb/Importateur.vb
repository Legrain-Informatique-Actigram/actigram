Imports System.ComponentModel
Public Class Importateur

    Public Sub New()

    End Sub

    Private worker As BackgroundWorker

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As String = Nothing)
        If worker Is Nothing Then Exit Sub
        CheckCancellation()
        worker.ReportProgress(percent, status)
    End Sub

    Private Sub CheckCancellation()
        If worker Is Nothing Then Exit Sub
        If worker.CancellationPending Then
            Throw New UserCancelledException("Importation annulée")
        End If
    End Sub

    Public Sub Importer(ByVal fichier As String, Optional ByVal worker As BackgroundWorker = Nothing)
        Me.worker = worker
        'Charger les données de référence : TVA, Produits, Clients
        ReportProgress(0, "Charger données Agrifact")
        Dim ds As New DsAgrifact
        Using dta As New DsAgrifactTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using
        ReportProgress(10)
        Using dta As New DsAgrifactTableAdapters.ProduitTableAdapter
            dta.Fill(ds.Produit)
        End Using
        ReportProgress(50)
        Using dta As New DsAgrifactTableAdapters.EntrepriseTableAdapter
            dta.Fill(ds.Entreprise)
        End Using
        ReportProgress(90)
        Using dta As New DsAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
            dta.Fill(ds.TelephoneEntreprise)
        End Using
        ReportProgress(100)


        ReportProgress(0, "Compte des lignes")
        Dim nbLignes As Integer = Pretraitement(fichier)


        ReportProgress(0, "Ouverture du fichier")
        Dim errors As New System.Text.StringBuilder
        Dim factures As New List(Of Facture)
        Using tfp As New FileIO.TextFieldParser(fichier, System.Text.Encoding.Default, True)
            With tfp
                .TextFieldType = FileIO.FieldType.Delimited
                .Delimiters = New String() {";"}
                .TrimWhiteSpace = True
            End With
            ReportProgress(0, "Analyse du fichier")
            While Not tfp.EndOfData
                ReportProgress(tfp.LineNumber * 100 \ nbLignes)
                Dim fields() As String = tfp.ReadFields
                Try
                    If fields.Length < 45 Then Throw New FileIO.MalformedLineException("Nombre de champs incorrect.", tfp.LineNumber)
                    factures.Add(TraiterLigne(fields, ds))
                Catch ex As FileIO.MalformedLineException
                    errors.AppendLine(String.Format("Ligne {0}: {1}", ex.LineNumber, ex.Message))
                End Try
            End While
        End Using

        'Insérer les infos en base
        UpdateDatabase(ds, factures, errors)

        If errors.Length > 0 Then
            MsgBox("Des lignes n'ont pas été importées : " & vbCrLf & errors.ToString.Trim, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function TraiterLigne(ByVal fields() As String, ByVal ds As DsAgrifact) As Facture
        Dim res As New Facture
        With res
            'Créer le client
            .Client = New Client
            With .Client
                .Nom = fields(3)
                .Tel = fields(14)
                .Email = fields(7)
                .AdresseFacturation = New Adresse
                With .AdresseFacturation
                    .Adresse = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", fields(5), fields(8), fields(9)).Trim
                    .CodePostal = fields(12)
                    .Ville = fields(10)
                    .Pays = fields(13)
                End With
                .AdresseLivraison = New Adresse
                With .AdresseLivraison
                    .Adresse = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", fields(17), fields(19), fields(20)).Trim
                    .CodePostal = fields(23)
                    .Ville = fields(21)
                    .Pays = fields(24)
                End With
            End With
            'Infos facture
            .nFacture = fields(0)
            .DateFacture = Date.ParseExact(fields(1) & " " & fields(2), "MM/dd/yyyy HH:mm:ss", My.Application.Culture.DateTimeFormat)
            .Adresse = .Client.AdresseFacturation.ToString
            .MontantTTC = DecimalParse(fields(44)).GetValueOrDefault
            .MontantTVA = Decimal.Round(DecimalParse(fields(36)).GetValueOrDefault, 2)
            .MontantHT = .MontantTTC - .MontantTVA
        End With

        'Créer les lignes
        Dim nbLignes As Integer = fields(45)
        For i As Integer = 0 To nbLignes - 1
            Dim offSet As Integer = 66 + i * 6
            If fields(offSet).Length = 0 Then Continue For
            Dim ligne As New LigneFacture
            With ligne
                .ParametrerProduit(ds, fields(offSet))
                .PrixUHT = DecimalParse(fields(offSet + 1)).GetValueOrDefault
                .Quantite = DecimalParse(fields(offSet + 2)).GetValueOrDefault
                .Libelle = fields(offSet + 3)
                .CalculerMontants()
            End With
            res.Lignes.Add(ligne)
        Next

        'Créer la ligne de port
        Dim lignePort As New LigneFacture
        With lignePort
            .ParametrerProduit(ds, My.Settings.CodeProduitPort, False)
            .Libelle = fields(46).Replace("<br />", vbCrLf)
            .Quantite = 1
            .PrixUHT = DecimalParse(fields(39)).GetValueOrDefault
            .CalculerMontants()
        End With
        res.Lignes.Add(lignePort)

        Return res
    End Function

    Private Function Pretraitement(ByVal fichier As String)
        Dim res As Integer = 0
        Using sr As New IO.StreamReader(fichier, True)
            Using sw As New IO.StreamWriter(fichier & ".tmp", False, sr.CurrentEncoding)
                While Not sr.EndOfStream
                    res += 1
                    sw.WriteLine(PretraitementLigne(sr.ReadLine))
                End While
            End Using
        End Using
        If IO.File.Exists(fichier & ".tmp") Then
            IO.File.Delete(fichier)
            IO.File.Move(fichier & ".tmp", fichier)
        End If        
        Return res
    End Function

    Private Function PretraitementLigne(ByVal line As String) As String
        If line.IndexOf("&") >= 0 Then
            If line.Contains("&quot;") Then line = line.Replace("&quot;", """")
            If line.Contains("&apos;") Then line = line.Replace("&apos;", "'")
            If line.Contains("&lt;") Then line = line.Replace("&lt;", "<")
            If line.Contains("&gt;") Then line = line.Replace("&gt;", ">")
            If line.Contains("&nbsp;") Then line = line.Replace("&nbsp;", " ")
            If line.Contains("&iexcl;") Then line = line.Replace("&iexcl;", "¡")
            If line.Contains("&cent;") Then line = line.Replace("&cent;", "¢")
            If line.Contains("&pound;") Then line = line.Replace("&pound;", "£")
            If line.Contains("&curren;") Then line = line.Replace("&curren;", "¤")
            If line.Contains("&yen;") Then line = line.Replace("&yen;", "¥")
            If line.Contains("&brvbar;") Then line = line.Replace("&brvbar;", "¦")
            If line.Contains("&sect;") Then line = line.Replace("&sect;", "§")
            If line.Contains("&uml;") Then line = line.Replace("&uml;", "¨")
            If line.Contains("&copy;") Then line = line.Replace("&copy;", "©")
            If line.Contains("&ordf;") Then line = line.Replace("&ordf;", "ª")
            If line.Contains("&laquo;") Then line = line.Replace("&laquo;", "«")
            If line.Contains("&not;") Then line = line.Replace("&not;", "¬")
            If line.Contains("&shy;") Then line = line.Replace("&shy;", "­")
            If line.Contains("&reg;") Then line = line.Replace("&reg;", "®")
            If line.Contains("&macr;") Then line = line.Replace("&macr;", "¯")
            If line.Contains("&deg;") Then line = line.Replace("&deg;", "°")
            If line.Contains("&plusmn;") Then line = line.Replace("&plusmn;", "±")
            If line.Contains("&sup2;") Then line = line.Replace("&sup2;", "²")
            If line.Contains("&sup3;") Then line = line.Replace("&sup3;", "³")
            If line.Contains("&acute;") Then line = line.Replace("&acute;", "´")
            If line.Contains("&micro;") Then line = line.Replace("&micro;", "µ")
            If line.Contains("&para;") Then line = line.Replace("&para;", "¶")
            If line.Contains("&middot;") Then line = line.Replace("&middot;", "·")
            If line.Contains("&cedil;") Then line = line.Replace("&cedil;", "¸")
            If line.Contains("&sup1;") Then line = line.Replace("&sup1;", "¹")
            If line.Contains("&ordm;") Then line = line.Replace("&ordm;", "º")
            If line.Contains("&raquo;") Then line = line.Replace("&raquo;", "»")
            If line.Contains("&frac14;") Then line = line.Replace("&frac14;", "¼")
            If line.Contains("&frac12;") Then line = line.Replace("&frac12;", "½")
            If line.Contains("&frac34;") Then line = line.Replace("&frac34;", "¾")
            If line.Contains("&iquest;") Then line = line.Replace("&iquest;", "¿")
            If line.Contains("&times;") Then line = line.Replace("&times;", "×")
            If line.Contains("&divide;") Then line = line.Replace("&divide;", "÷")
            If line.Contains("&Agrave;") Then line = line.Replace("&Agrave;", "À")
            If line.Contains("&Aacute;") Then line = line.Replace("&Aacute;", "Á")
            If line.Contains("&Acirc;") Then line = line.Replace("&Acirc;", "Â")
            If line.Contains("&Atilde;") Then line = line.Replace("&Atilde;", "Ã")
            If line.Contains("&Auml;") Then line = line.Replace("&Auml;", "Ä")
            If line.Contains("&Aring;") Then line = line.Replace("&Aring;", "Å")
            If line.Contains("&AElig;") Then line = line.Replace("&AElig;", "Æ")
            If line.Contains("&Ccedil;") Then line = line.Replace("&Ccedil;", "Ç")
            If line.Contains("&Egrave;") Then line = line.Replace("&Egrave;", "È")
            If line.Contains("&Eacute;") Then line = line.Replace("&Eacute;", "É")
            If line.Contains("&Ecirc;") Then line = line.Replace("&Ecirc;", "Ê")
            If line.Contains("&Euml;") Then line = line.Replace("&Euml;", "Ë")
            If line.Contains("&Igrave;") Then line = line.Replace("&Igrave;", "Ì")
            If line.Contains("&Iacute;") Then line = line.Replace("&Iacute;", "Í")
            If line.Contains("&Icirc;") Then line = line.Replace("&Icirc;", "Î")
            If line.Contains("&Iuml;") Then line = line.Replace("&Iuml;", "Ï")
            If line.Contains("&ETH;") Then line = line.Replace("&ETH;", "Ð")
            If line.Contains("&Ntilde;") Then line = line.Replace("&Ntilde;", "Ñ")
            If line.Contains("&Ograve;") Then line = line.Replace("&Ograve;", "Ò")
            If line.Contains("&Oacute;") Then line = line.Replace("&Oacute;", "Ó")
            If line.Contains("&Ocirc;") Then line = line.Replace("&Ocirc;", "Ô")
            If line.Contains("&Otilde;") Then line = line.Replace("&Otilde;", "Õ")
            If line.Contains("&Ouml;") Then line = line.Replace("&Ouml;", "Ö")
            If line.Contains("&Oslash;") Then line = line.Replace("&Oslash;", "Ø")
            If line.Contains("&Ugrave;") Then line = line.Replace("&Ugrave;", "Ù")
            If line.Contains("&Uacute;") Then line = line.Replace("&Uacute;", "Ú")
            If line.Contains("&Ucirc;") Then line = line.Replace("&Ucirc;", "Û")
            If line.Contains("&Uuml;") Then line = line.Replace("&Uuml;", "Ü")
            If line.Contains("&Yacute;") Then line = line.Replace("&Yacute;", "Ý")
            If line.Contains("&THORN;") Then line = line.Replace("&THORN;", "Þ")
            If line.Contains("&szlig;") Then line = line.Replace("&szlig;", "ß")
            If line.Contains("&agrave;") Then line = line.Replace("&agrave;", "à")
            If line.Contains("&aacute;") Then line = line.Replace("&aacute;", "á")
            If line.Contains("&acirc;") Then line = line.Replace("&acirc;", "â")
            If line.Contains("&atilde;") Then line = line.Replace("&atilde;", "ã")
            If line.Contains("&auml;") Then line = line.Replace("&auml;", "ä")
            If line.Contains("&aring;") Then line = line.Replace("&aring;", "å")
            If line.Contains("&aelig;") Then line = line.Replace("&aelig;", "æ")
            If line.Contains("&ccedil;") Then line = line.Replace("&ccedil;", "ç")
            If line.Contains("&egrave;") Then line = line.Replace("&egrave;", "è")
            If line.Contains("&eacute;") Then line = line.Replace("&eacute;", "é")
            If line.Contains("&ecirc;") Then line = line.Replace("&ecirc;", "ê")
            If line.Contains("&euml;") Then line = line.Replace("&euml;", "ë")
            If line.Contains("&igrave;") Then line = line.Replace("&igrave;", "ì")
            If line.Contains("&iacute;") Then line = line.Replace("&iacute;", "í")
            If line.Contains("&icirc;") Then line = line.Replace("&icirc;", "î")
            If line.Contains("&iuml;") Then line = line.Replace("&iuml;", "ï")
            If line.Contains("&eth;") Then line = line.Replace("&eth;", "ð")
            If line.Contains("&ntilde;") Then line = line.Replace("&ntilde;", "ñ")
            If line.Contains("&ograve;") Then line = line.Replace("&ograve;", "ò")
            If line.Contains("&oacute;") Then line = line.Replace("&oacute;", "ó")
            If line.Contains("&ocirc;") Then line = line.Replace("&ocirc;", "ô")
            If line.Contains("&otilde;") Then line = line.Replace("&otilde;", "õ")
            If line.Contains("&ouml;") Then line = line.Replace("&ouml;", "ö")
            If line.Contains("&oslash;") Then line = line.Replace("&oslash;", "ø")
            If line.Contains("&ugrave;") Then line = line.Replace("&ugrave;", "ù")
            If line.Contains("&uacute;") Then line = line.Replace("&uacute;", "ú")
            If line.Contains("&ucirc;") Then line = line.Replace("&ucirc;", "û")
            If line.Contains("&uuml;") Then line = line.Replace("&uuml;", "ü")
            If line.Contains("&yacute;") Then line = line.Replace("&yacute;", "ý")
            If line.Contains("&thorn;") Then line = line.Replace("&thorn;", "þ")
            If line.Contains("&yuml;") Then line = line.Replace("&yuml;", "ÿ")
            If line.Contains("&amp;") Then line = line.Replace("&amp;", "&")
        End If
        Return line
    End Function

    Private Sub UpdateDatabase(ByVal ds As DsAgrifact, ByVal factures As List(Of Facture), ByVal errors As System.Text.StringBuilder)
        If factures.Count = 0 Then Exit Sub
        Using conn As New SqlClient.SqlConnection(My.Settings.ConnAgrifact)
            Using dtaF As New DsAgrifactTableAdapters.VFactureTableAdapter
                dtaF.Connection = conn
                Using dtaFD As New DsAgrifactTableAdapters.VFacture_DetailTableAdapter
                    dtaFD.Connection = conn
                    Using dtaE As New DsAgrifactTableAdapters.EntrepriseTableAdapter
                        dtaE.Connection = conn
                        Using dtaTel As New DsAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
                            dtaTel.Connection = conn
                            Using dtaP As New DsAgrifactTableAdapters.ProduitTableAdapter
                                dtaP.Connection = conn

                                'Initialiser les clés auto
                                ds.Entreprise.InitAutoIncrementSeed(dtaE)
                                ds.Produit.InitAutoIncrementSeed(dtaP)
                                ds.VFacture.InitAutoIncrementSeed(dtaF)
                                ds.VFacture_Detail.InitAutoIncrementSeed(dtaFD)

                                'Importer les factures dans le Dataset
                                ReportProgress(0, "Construction des factures")
                                Dim i As Integer
                                For Each facture As Facture In factures
                                    If My.Settings.VerfiNFact AndAlso dtaF.ExistsNFacture(facture.nFacture).GetValueOrDefault() > 0 Then
                                        If MsgBox(String.Format("La facture n°{0} est déjà présente, voulez-vous continuer l'import ?", facture.nFacture), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                            errors.AppendLine(String.Format("Facture n°{0}: déjà présente en base.", facture.nFacture))
                                            Continue For
                                        Else
                                            Throw New UserCancelledException("Import annulé")
                                        End If
                                    End If
                                    facture.Insert(ds)
                                    i += 1 : ReportProgress(i * 100 \ factures.Count)
                                Next

                                Dim rwsAdded() As DataRow = ds.Entreprise.Select("", "", DataViewRowState.Added)

                                'Maj la base
                                ReportProgress(0, "Ecriture des données")
                                Dim s As New SqlProxy(conn)
                                s.ExecuteNonQuery("BEGIN TRANSACTION")
                                Try
                                    dtaP.Update(ds.Produit) : ReportProgress(10)
                                    dtaE.Update(ds.Entreprise) : ReportProgress(30)
                                    'Pour gérer les code tiers
                                    For Each dr As DsAgrifact.EntrepriseRow In rwsAdded
                                        dtaE.UpdateCodeTiers(dr.nEntreprise, dr.CreerCodeTiers(s))
                                    Next
                                    dtaTel.Update(ds.TelephoneEntreprise) : ReportProgress(50)
                                    dtaF.Update(ds.VFacture) : ReportProgress(75)
                                    dtaFD.Update(ds.VFacture_Detail) : ReportProgress(100)
                                    s.ExecuteNonQuery("COMMIT TRANSACTION")
                                Catch ex As SqlClient.SqlException
                                    Try
                                        s.ExecuteNonQuery("ROLLBACK TRANSACTION")
                                    Catch : End Try
                                    Throw New Exception(ex.Message, ex)
                                End Try
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

End Class
