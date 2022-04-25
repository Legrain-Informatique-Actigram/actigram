Imports System.Xml.Serialization

Namespace RedevancePhyto

    Public Class ExportBilan

        Private Const URL_SITE_PHYTO As String = "http://redevancephyto.developpement-durable.gouv.fr/distributeur/envoi"
        Friend Const URL_XSD As String = "http://redevancephyto.developpement-durable.gouv.fr/distributeur/telechargerxsd/annee/2013"
        Friend Const MILLESIME As String = "2014"
        'ajout Legrain 2014
        'Friend Const URL_XSD As String = "http://redevancephyto.developpement-durable.gouv.fr/distributeur/telechargerxsd/annee/2013"
        'Friend Const MILLESIME As String = "2013"
        '/ajout Legrain 2014

        'Friend Const URL_XSD As String = "http://redevancephyto.developpement-durable.gouv.fr/distributeur/telechargerxsd/annee/2011"
        'Friend Const MILLESIME As String = "2011"
        'Friend Const URL_XSD As String = "http://redevancephyto.developpement-durable.gouv.fr/distributeur/telechargerxsd/annee/2009"
        'Friend Const MILLESIME As String = "2009"
        'Friend Const URL_XSD_2008 As String = "http://redevancephyto2008.developpement-durable.gouv.fr/saisiexml/telechargerxsd/annee/2008"
        'Friend Const MILLESIME_2008 As String = "2008"

        'Modifications millésime 2009
        '   Ajout du champ OBSERVATIONS sur le bilan
        '   Ajout du fils CONTACT sur le distributeur
        '   Division de la quantité de PRODUIT en 2 semestres

        'Modifications millésime 2011
        '   suppression de la division de la quantité de PRODUIT en 2 semestres

#Region "Méthodes partagées"
        Public Shared Sub ExporterBilan(ByVal dtDeb As Date, ByVal dtFin As Date, ByVal observations As String)
            Dim ApproFactDS As New ApproFactDataSet
            Dim codeInsee As String = String.Empty
            Dim EntrepriseDR As ApproFactDataSet.EntrepriseRow = Nothing

            'Chargement des infos de la table ExportBilanVenteApproFact
            Using ExportBilanVenteApproFactTA As New ApproFactDataSetTableAdapters.ExportBilanVenteApproFactTableAdapter
                ExportBilanVenteApproFactTA.Fill(ApproFactDS.ExportBilanVenteApproFact, dtDeb, dtFin.AddDays(1))

                If (ApproFactDS.ExportBilanVenteApproFact.Rows.Count = 0) Then
                    MsgBox("Aucune vente à exporter sur cette période.", MsgBoxStyle.Information)

                    Exit Sub
                End If
            End Using

            'Chargement des infos du distributeur
            Using EntrepriseTA As New ApproFactDataSetTableAdapters.EntrepriseTableAdapter
                EntrepriseTA.FillByTypeClient(ApproFactDS.Entreprise, "Entreprise")

                If (ApproFactDS.Entreprise.Rows.Count = 0) Then
                    MsgBox("Impossible de retrouver les informations du distributeur", MsgBoxStyle.Exclamation)

                    Exit Sub
                Else
                    EntrepriseDR = CType(ApproFactDS.Entreprise.Rows(0), ApproFactDataSet.EntrepriseRow)
                End If

                'Chargement des téléphones du distributeur
                Using TelephoneEntrepriseTA As New ApproFactDataSetTableAdapters.TelephoneEntrepriseTableAdapter
                    TelephoneEntrepriseTA.FillBynEntreprise(ApproFactDS.TelephoneEntreprise, EntrepriseDR.nEntreprise)
                End Using
            End Using

            'Chargement des infos des contacts liés au distributeur
            Using PersonneTA As New ApproFactDataSetTableAdapters.PersonneTableAdapter
                PersonneTA.FillBynEntreprise(ApproFactDS.Personne, EntrepriseDR.nEntreprise)

                'Chargement des téléphones des contacts
                If (ApproFactDS.Personne.Rows.Count > 0) Then
                    Using TelephoneTA As New ApproFactDataSetTableAdapters.TelephoneTableAdapter
                        For Each PersonneDR As ApproFactDataSet.PersonneRow In ApproFactDS.Personne.Rows
                            TelephoneTA.FillBynPersonne(ApproFactDS.Telephone, PersonneDR.nPersonne)
                        Next
                    End Using
                End If
            End Using

            'Chargement des infos de la table Parametres
            Using ParametresTA As New ApproFactDataSetTableAdapters.ParametresTableAdapter
                ParametresTA.Fill(ApproFactDS.Parametres)
            End Using

            'Recherche du code INSEE de la ville
            Dim ville As String = String.Empty
            If Not (EntrepriseDR.IsVilleNull) Then
                ville = EntrepriseDR.Ville
            End If

            Dim codePostal As String = String.Empty
            If Not (EntrepriseDR.IsCodePostalNull) Then
                codePostal = EntrepriseDR.CodePostal
            End If

            Using s As New SqlProxy
                codeInsee = ExportBilan.TrouverInsee(s, ville, codePostal)
            End Using

            If codeInsee Is Nothing Then Exit Sub

            Dim nomDistributeur As String = String.Empty
            If Not (EntrepriseDR.IsNomNull) Then
                nomDistributeur = EntrepriseDR.Nom
            End If

            Dim adresseDistributeur As String = String.Empty
            If Not (EntrepriseDR.IsAdresseNull) Then
                adresseDistributeur = EntrepriseDR.Adresse
            End If

            Dim eMailDistributeur As String = String.Empty
            If Not (EntrepriseDR.IsEMailNull) Then
                eMailDistributeur = EntrepriseDR.EMail
            End If

            'Affectation des valeurs
            Dim bilan As New BILAN

            With bilan
                .DateCreation = Now
                .OBSERVATIONS = observations

                With .DISTRIBUTEUR
                    .NOM_ORGANISME = ValeurParamImpression(ApproFactDS.Parametres, "EnTete", "", "")
                    .NOM_SIEGE = nomDistributeur
                    .NUMERO_AGREMENT = ValeurParamImpression(ApproFactDS.Parametres, "NumeroAgrement", "", "")
                    .SIRET = ValeurParamImpression(ApproFactDS.Parametres, "Siret", "", "")
                    .CODE_NAF = ValeurParamImpression(ApproFactDS.Parametres, "CodeNAF", "", "")

                    With .ADRESSE
                        .NUMERO_ET_VOIE = adresseDistributeur
                        .INSEE = codeInsee
                    End With

                    If (ApproFactDS.Personne.Rows.Count > 0) Then
                        Dim PersonneDR As ApproFactDataSet.PersonneRow = CType(ApproFactDS.Personne.Rows(0), ApproFactDataSet.PersonneRow)

                        Dim nomContact As String = String.Empty
                        If Not (PersonneDR.IsNomNull) Then
                            nomContact = PersonneDR.Nom
                        End If

                        Dim fonctionContact As String = String.Empty
                        If Not (PersonneDR.IsFonctionNull) Then
                            fonctionContact = PersonneDR.Fonction
                        End If

                        Dim emailContact As String = String.Empty
                        If Not (PersonneDR.IsEMailNull) Then
                            emailContact = PersonneDR.EMail
                        End If

                        .CONTACT = New CONTACT
                        .CONTACT.NOM = nomContact
                        .CONTACT.FONCTION = fonctionContact
                        .CONTACT.COURRIEL = emailContact

                        If (ApproFactDS.Telephone.Rows.Count > 0) Then
                            Dim TelephoneDR As ApproFactDataSet.TelephoneRow = CType(ApproFactDS.Telephone.Rows(0), ApproFactDataSet.TelephoneRow)

                            Dim numero As String = String.Empty
                            If Not (TelephoneDR.IsNumeroNull) Then
                                numero = TelephoneDR.Numero
                            End If

                            .CONTACT.TELEPHONE = numero
                        End If
                    Else
                        .CONTACT = New CONTACT
                        .CONTACT.NOM = nomDistributeur
                        .CONTACT.COURRIEL = eMailDistributeur

                        If (ApproFactDS.TelephoneEntreprise.Rows.Count > 0) Then
                            Dim TelephoneEntrepriseDR As ApproFactDataSet.TelephoneEntrepriseRow = CType(ApproFactDS.TelephoneEntreprise.Rows(0), ApproFactDataSet.TelephoneEntrepriseRow)

                            Dim numero As String = String.Empty
                            If Not (TelephoneEntrepriseDR.IsNumeroNull) Then
                                numero = TelephoneEntrepriseDR.Numero
                            End If

                            .CONTACT.TELEPHONE = numero
                        End If
                    End If
                End With

                Dim etab As New ETABLISSEMENT

                With etab
                    .ADRESSE = bilan.DISTRIBUTEUR.ADRESSE.Clone
                    .SIRET = bilan.DISTRIBUTEUR.SIRET
                    .NOM = bilan.DISTRIBUTEUR.NOM_SIEGE

                    For Each ExportBilanVenteApproFactDR As ApproFactDataSet.ExportBilanVenteApproFactRow In ApproFactDS.ExportBilanVenteApproFact.Rows

                        Dim CODEPOSTALE As String = String.Empty
                        If Not (ExportBilanVenteApproFactDR.IsCODEPOSTALNull) Then
                            CODEPOSTALE = ExportBilanVenteApproFactDR.CODEPOSTAL
                        End If

                        Dim AMM As String = String.Empty
                        If Not (ExportBilanVenteApproFactDR.IsAMMNull) Then
                            AMM = ExportBilanVenteApproFactDR.AMM
                        End If

                        Dim qte As Decimal = 0
                        If Not (ExportBilanVenteApproFactDR.IsQUANTITENull) Then
                            qte = ExportBilanVenteApproFactDR.QUANTITE
                        End If

                        .VENTES.Add(New PRODUIT(CODEPOSTALE, AMM, qte))
                    Next
                End With

                .ETABLISSEMENTS.Add(etab)
            End With

            Dim fichier As String
            Dim dlg As New SaveFileDialog

            With dlg
                .FileName = String.Format("{0}Bilan{1}.xml", bilan.DISTRIBUTEUR.NOM_SIEGE, bilan.ANNEE_BILAN)
                .Filter = "Document XML (*.xml)|*.xml"
                If .ShowDialog = DialogResult.Cancel Then Exit Sub
                fichier = .FileName
            End With

            bilan.WriteXml(fichier)

            If MsgBox("Souhaitez-vous vous rendre maintenant sur le site de télédéclaration ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(URL_SITE_PHYTO)
            End If
        End Sub

        'Public Shared Sub ExporterBilan(ByVal ds As DataSet, ByVal dtDeb As Date, ByVal dtFin As Date, ByVal observations As String)
        '    'Retrouver l'entreprise
        '    Dim dt As DataTable
        '    Dim drEnt As DataRow
        '    Dim drContacts As DataRow()
        '    Dim codeInsee As String
        '    Dim dtParams As DataTable

        '    Using s As New SqlProxy
        '        drEnt = SelectSingleRow(ds.Tables("Entreprise"), "TypeClient='Entreprise'", "")
        '        If drEnt Is Nothing Then
        '            MsgBox("Impossible de retrouver les informations du distributeur", MsgBoxStyle.Exclamation)
        '            Exit Sub
        '        End If
        '        'Trouver un contact
        '        drContacts = drEnt.GetChildRows("EntreprisePersonne")
        '        codeInsee = TrouverInsee(s, Convert.ToString(drEnt("Ville")), Convert.ToString(drEnt("CodePostal")))
        '        If codeInsee Is Nothing Then Exit Sub

        '        'Renseignement des paramètres
        '        dtParams = ds.Tables("Parametres")

        '        'Récup des données
        '        Dim sql As String = String.Format("select p.AMM, " & _
        '                            "Sum(case when datepart(month,f.datefacture)<7 then  fd.unite1 else 0 end) as SumUnite1_S1, " & _
        '                            "Sum(case when datepart(month,f.datefacture)>6 then  fd.unite1 else 0 end) as SumUnite1_S2 " & _
        '                            "FROM VFacture f " & _
        '                            "INNER JOIN VFacture_Detail fd ON f.nDevis=fd.nDevis " & _
        '                            "INNER JOIN Produit p ON fd.CodeProduit = 'RED-' + p.AMM AND p.IsAMM=1 AND p.Inactif=0 " & _
        '                            "WHERE fd.codeproduit like 'RED-%'  AND p.AMM<>'' " & _
        '                            "AND f.datefacture>='{0:dd/MM/yyyy}' AND f.datefacture<'{1:dd/MM/yyyy}' GROUP BY p.AMM", dtDeb, dtFin.AddDays(1))
        '        dt = s.ExecuteDataTable(sql, "BilanVenteApproFact")
        '    End Using

        '    If dt.Rows.Count = 0 Then
        '        MsgBox("Aucune vente a exporter sur cette période.", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    Dim bilan As New BILAN
        '    'Parametrage
        '    With bilan
        '        .DateCreation = Now
        '        .OBSERVATIONS = observations
        '        With .DISTRIBUTEUR
        '            .NOM_ORGANISME = ValeurParamImpression(dtParams, "EnTete", "", "")
        '            .NOM_SIEGE = Convert.ToString(drEnt("Nom"))
        '            .NUMERO_AGREMENT = ValeurParamImpression(dtParams, "NumeroAgrement", "", "")
        '            .SIRET = ValeurParamImpression(dtParams, "Siret", "", "")
        '            .CODE_NAF = ValeurParamImpression(dtParams, "CodeNAF", "", "")
        '            With .ADRESSE
        '                .NUMERO_ET_VOIE = Convert.ToString(drEnt("Adresse"))
        '                .INSEE = codeInsee
        '            End With
        '            If drContacts.Length > 0 Then
        '                .CONTACT = New CONTACT
        '                .CONTACT.NOM = Convert.ToString(drContacts(0)("Nom"))
        '                .CONTACT.FONCTION = Convert.ToString(drContacts(0)("Fonction"))
        '                .CONTACT.COURRIEL = Convert.ToString(drContacts(0)("EMail"))
        '                Dim drTels() As DataRow = drContacts(0).GetChildRows("PersonneTelephone")
        '                If drTels.Length > 0 Then
        '                    .CONTACT.TELEPHONE = Convert.ToString(drTels(0)("Numero"))
        '                End If
        '            Else
        '                .CONTACT = New CONTACT
        '                .CONTACT.NOM = Convert.ToString(drEnt("Nom"))
        '                .CONTACT.COURRIEL = Convert.ToString(drEnt("EMail"))
        '                Dim drTels() As DataRow = drEnt.GetChildRows("EntrepriseTelephoneEntreprise")
        '                If drTels.Length > 0 Then
        '                    .CONTACT.TELEPHONE = Convert.ToString(drTels(0)("Numero"))
        '                End If
        '            End If
        '        End With
        '        Dim etab As New ETABLISSEMENT
        '        With etab
        '            .ADRESSE = bilan.DISTRIBUTEUR.ADRESSE.Clone
        '            .SIRET = bilan.DISTRIBUTEUR.SIRET
        '            .NOM = bilan.DISTRIBUTEUR.NOM_SIEGE
        '            For Each dr As DataRow In dt.Rows
        '                .VENTES.Add(New PRODUIT(Convert.ToString(dr("AMM")), CDec(dr("SumUnite1_S1")), CDec(dr("SumUnite1_S2"))))
        '            Next
        '        End With
        '        .ETABLISSEMENTS.Add(etab)
        '    End With

        '    Dim fichier As String
        '    Dim dlg As New SaveFileDialog
        '    With dlg
        '        .FileName = String.Format("{0}Bilan{1}.xml", bilan.DISTRIBUTEUR.NOM_SIEGE, bilan.ANNEE_BILAN)
        '        .Filter = "Document XML (*.xml)|*.xml"
        '        If .ShowDialog = DialogResult.Cancel Then Exit Sub
        '        fichier = .FileName
        '    End With
        '    bilan.WriteXml(fichier)

        '    If MsgBox("Souhaitez-vous vous rendre maintenant sur le site de télédéclaration ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Process.Start(URL_SITE_PHYTO)
        '    End If
        'End Sub

        Private Shared Function TrouverInsee(ByVal s As SqlProxy, ByVal ville As String, ByVal cp As String) As String
            If (cp.Length = 0) Then
                MsgBox("Code postal de l'entreprise non renseigné." & vbCrLf & "Vérifiez ou completez les coordonnées de l'entreprise.", MsgBoxStyle.Exclamation)

                Return Nothing
            End If

            Using CodeInseeTA As New ApproFactDataSetTableAdapters.CodeInseeTableAdapter
                Dim CodeInseeDT As ApproFactDataSet.CodeInseeDataTable = CodeInseeTA.GetData(cp, ville)

                If (CodeInseeDT.Rows.Count = 0) Then
                    MsgBox("Code INSEE de la commune de l'entreprise introuvable." & vbCrLf & "Vérifiez ou completez les coordonnées de l'entreprise.", MsgBoxStyle.Exclamation)

                    Return Nothing
                Else
                    Dim CodeInseeDR As ApproFactDataSet.CodeInseeRow = CType(CodeInseeDT.Rows(0), ApproFactDataSet.CodeInseeRow)

                    If (CodeInseeDR.note = 5) Then
                        Return CStr(CodeInseeDR.CodeINSEE)
                    Else
                        For Each CodeInseeDR2 As ApproFactDataSet.CodeInseeRow In CodeInseeDT.Rows
                            Dim nomVille As String = String.Empty
                            If Not (CodeInseeDR2.IsNomVilleNull) Then
                                nomVille = CodeInseeDR2.NomVille
                            End If

                            Dim msg As String = String.Format("La commune '{0}' n'a pas été trouvé pour le code postal {1}." & vbCrLf & "Le nom officiel de la commune est-il '{2}' ?", ville, cp, nomVille)

                            Select Case MsgBox(msg, MsgBoxStyle.YesNoCancel)
                                Case MsgBoxResult.Yes
                                    Return CStr(CodeInseeDR2.CodeINSEE)
                                Case MsgBoxResult.Cancel
                                    Return Nothing
                            End Select
                        Next

                        MsgBox("Code INSEE de la commune de l'entreprise introuvable." & vbCrLf & "Vérifiez ou completez les coordonnées de l'entreprise.", MsgBoxStyle.Exclamation)

                        Return Nothing
                    End If
                End If
            End Using

            'Dim sql As String = String.Empty
            'Dim dt As DataTable = Nothing

            'sql = String.Format("DECLARE @ville NVARCHAR(255),@cp INT " & _
            '    "SET @ville = '{0}' " & _
            '    "SET @cp = {1} " & _
            '    "SELECT CASE WHEN nomville=@ville THEN 5 ELSE DIFFERENCE(nomville,@ville) END AS note, " & _
            '    "NomVille, CodePostal, CodeINSEE " & _
            '    "FROM communes WHERE codepostal=@cp and DIFFERENCE(nomville,@ville)>=3 " & _
            '    "ORDER BY (CASE WHEN nomville=@ville THEN 5 ELSE difference (nomville,@ville) END) DESC", _
            '    ville.Replace("'", "''"), cp)

            'dt = s.ExecuteDataTable(sql)

            'If (dt.Rows.Count = 0) Then
            '    MsgBox("Code INSEE de la commune de l'entreprise introuvable." & vbCrLf & "Vérifiez ou completez les coordonnées de l'entreprise.", MsgBoxStyle.Exclamation)

            '    Return Nothing
            'Else
            '    Dim dr As DataRow = dt.Rows(0)

            '    If CInt(dr("note")) = 5 Then
            '        Return Convert.ToString(dr("CodeINSEE"))
            '    Else
            '        For Each dr In dt.Rows
            '            Dim msg As String = String.Format("La commune '{0}' n'a pas été trouvé pour le code postal {1}." & vbCrLf & "Le nom officiel de la commune est-il '{2}' ?", ville, cp, dr("NomVille"))

            '            Select Case MsgBox(msg, MsgBoxStyle.YesNoCancel)
            '                Case MsgBoxResult.Yes
            '                    Return Convert.ToString(dr("CodeINSEE"))
            '                Case MsgBoxResult.Cancel
            '                    Return Nothing
            '            End Select
            '        Next

            '        MsgBox("Code INSEE de la commune de l'entreprise introuvable." & vbCrLf & "Vérifiez ou completez les coordonnées de l'entreprise.", MsgBoxStyle.Exclamation)

            '        Return Nothing
            '    End If
            'End If
        End Function

        Private Shared Function ValeurParamImpression(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
            Dim res As String = valeurDefaut
            If Not dtParams Is Nothing Then
                Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And (TypePiece is null Or TypePiece='{1}')", nomParam, nomTable), "TypePiece desc")
                If rws.Length > 0 Then
                    res = Convert.ToString(rws(0).Item("Valeur"))
                End If
            End If
            Return res
        End Function
#End Region

    End Class

    Public Class BILAN
        <XmlAttributeAttribute(namespace:="http://www.w3.org/2001/XMLSchema-instance")> Public noNamespaceSchemaLocation As String = ExportBilan.URL_XSD
        <XmlAttributeAttribute()> Public ANNEE_BILAN As String = ExportBilan.MILLESIME
        '<XmlAttributeAttribute()> Public SOURCE As String '"XLS" ou "WEB", Facultatif
        Public VERSION As String 'longeur max = 6

        <XmlAttributeAttribute()> Public ReadOnly Property DATE_CREATION() As String
            Get
                Return DateCreation.ToString("yyyy-MM-dd HH:mm:ss")
            End Get
        End Property
        <XmlIgnore()> Public DateCreation As Date

        Public OBSERVATIONS As String = "" 'Max 500 car
        Public DISTRIBUTEUR As New DISTRIBUTEUR
        <XmlArray(), XmlArrayItem("ETABLISSEMENT", GetType(ETABLISSEMENT))> _
        Public ETABLISSEMENTS As New ArrayList 'Pas de SIRET en double

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

#Region "Gestion XML"
        Public Shared Function LoadXml(ByVal filename As String) As BILAN
            If Not IO.File.Exists(filename) Then Return Nothing
            Dim sr As New IO.StreamReader(filename)
            Dim xser As New XmlSerializer(GetType(BILAN))
            Dim res As BILAN = CType(xser.Deserialize(sr), BILAN)
            sr.Close()
            Return res
        End Function

        Public Sub WriteXml(ByVal filename As String)
            Dim fs As New IO.FileStream(filename, IO.FileMode.Create)
            WriteXml(fs)
            fs.Close()
        End Sub

        Public Sub WriteXml(ByVal s As IO.Stream)
            Dim xser As New XmlSerializer(Me.GetType)
            xser.Serialize(s, Me)
        End Sub
#End Region

    End Class

    Public Class DISTRIBUTEUR

        Public NOM_ORGANISME As String 'Max 255
        Public NOM_SIEGE As String 'Max 255
        Public CONTACT As CONTACT
        Public ADRESSE As New ADRESSE
        Public NUMERO_AGREMENT As String
        Public SIRET As String '14 chiffres
        Public CODE_NAF As String '4 chiffres et 1 lettre faisant parti de la liste valide des codes NAF

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class

    Public Class ETABLISSEMENT

        Public NOM As String 'Max 255
        Public SIRET As String '14 chiffres
        Public ADRESSE As New ADRESSE
        <XmlArray(), XmlArrayItem("PRODUIT", GetType(PRODUIT))> _
        Public VENTES As New ArrayList 'Pas d'AMM en double

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

    End Class

    Public Class ADRESSE
        Public BATIMENT As String = "" 'Max 38 car
        Public NUMERO_ET_VOIE As String = "" 'Max 38 car
        Public LIEU_DIT As String = "" 'Max 38 car
        Public INSEE As String = "" 'Code INSEE de la commune sur 5 car

#Region "Méthodes diverses"
        Public Function Clone() As ADRESSE
            Dim res As New ADRESSE
            With res
                .BATIMENT = Me.BATIMENT
                .NUMERO_ET_VOIE = Me.NUMERO_ET_VOIE
                .LIEU_DIT = Me.LIEU_DIT
                .INSEE = Me.INSEE
            End With
            Return res
        End Function
#End Region

    End Class

    Public Class CONTACT
        Public NOM As String = "" 'Max 60 car
        Public FONCTION As String = "" 'Max 60 car
        Public TELEPHONE As String = "" 'Max 20 car
        Public COURRIEL As String = "" 'Max 60 car

#Region "Méthodes diverses"
        Public Function Clone() As CONTACT
            Dim res As New CONTACT
            With res
                .NOM = Me.NOM
                .FONCTION = Me.FONCTION
                .TELEPHONE = Me.TELEPHONE
                .COURRIEL = Me.COURRIEL
            End With
            Return res
        End Function
#End Region

    End Class

    Public Class PRODUIT
        Public AMM As String '7 chiffres
        Public QUANTITE As Double

        'ajout Legrain 2014
        Public CODEPOSTAL As String
        '/ajout Legrain 2014


        'Public QUANTITE_SEMESTRE_1 As Double
        'Public QUANTITE_SEMESTRE_2 As Double

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal CODEPOSTAL As String, ByVal AMM As String, ByVal QUANTITE As Double)
            Me.New()
            Me.AMM = AMM
            Me.QUANTITE = QUANTITE
            'ajout Legrain 2014
            Me.CODEPOSTAL = CODEPOSTAL
            '/ajout Legrain 2014



            'Me.QUANTITE_SEMESTRE_1 = QUANTITE_SEMESTRE_1
            'Me.QUANTITE_SEMESTRE_2 = QUANTITE_SEMESTRE_2
        End Sub
#End Region

    End Class

End Namespace