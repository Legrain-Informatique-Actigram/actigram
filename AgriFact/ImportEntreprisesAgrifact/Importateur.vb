Public Class ImportEntrepriseAttribute
    Inherits Attribute

    Private _desc As String
    Public Property Description() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal desc As String)
        Me.New()
        Me.Description = desc
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Description
    End Function

    Public Shared Function HasAttribute(ByVal mi As Reflection.MemberInfo) As Boolean
        Return (GetCustomAttribute(mi, GetType(ImportEntrepriseAttribute)) IsNot Nothing)
    End Function

    Public Shared Function HasAttribute(ByVal mi As Reflection.MethodInfo) As Boolean
        Return (GetCustomAttribute(mi, GetType(ImportEntrepriseAttribute)) IsNot Nothing)
    End Function

    Public Shared Function GetAttribute(ByVal mi As Reflection.MemberInfo) As ImportEntrepriseAttribute
        Return GetCustomAttribute(mi, GetType(ImportEntrepriseAttribute))
    End Function

End Class

Public Class ImportProduitAttribute
    Inherits Attribute

    Private _desc As String
    Public Property Description() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal desc As String)
        Me.New()
        Me.Description = desc
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Description
    End Function

    Public Shared Function HasAttribute(ByVal mi As Reflection.MemberInfo) As Boolean
        Return (GetCustomAttribute(mi, GetType(ImportProduitAttribute)) IsNot Nothing)
    End Function

    Public Shared Function HasAttribute(ByVal mi As Reflection.MethodInfo) As Boolean
        Return (GetCustomAttribute(mi, GetType(ImportProduitAttribute)) IsNot Nothing)
    End Function

    Public Shared Function GetAttribute(ByVal mi As Reflection.MemberInfo) As ImportProduitAttribute
        Return GetCustomAttribute(mi, GetType(ImportProduitAttribute))
    End Function
End Class

Public Class Importateur

    Public Connection As SqlClient.SqlConnection

    Public Event ReportProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)

    Public Class ProgressEventArgs

        Private _status As String
        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
            End Set
        End Property


        Private _value As Integer
        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
                _value = value
            End Set
        End Property


        Private _max As Integer
        Public Property Maximum() As Integer
            Get
                Return _max
            End Get
            Set(ByVal value As Integer)
                _max = value
            End Set
        End Property

        Public Sub New(Optional ByVal Status As String = "", Optional ByVal value As Integer = 0, Optional ByVal max As Integer = -1)
            Me.Status = Status
            Me.Value = value
            Me.Maximum = max
        End Sub

    End Class

#Region " Import Entreprises "
    <ImportEntreprise("Import entreprises pour AGP Morlaix")> _
    Public Function ChargerFichierEntreprisesMorlaix(ByVal nomFic As String) As List(Of Entreprise)
        Dim res As New List(Of Entreprise)

        Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
        While Not tfp.EndOfData
            Dim fields() As String = tfp.ReadFields
            If fields.Length < 11 Then
                MsgBox("Ligne malformée")
                Continue While
            End If
            Dim ent As New Entreprise
            With ent
                'Valeurs fichiers
                .nEntreprise = fields(0)
                .nom = String.Format("{2} {0} {1}", fields(1), fields(2), fields(3)).Trim
                .adresse = fields(4)
                .CodePostal = fields(5)
                .Ville = fields(6)
                .Observations = String.Format("Comptable {0}, bureau de {1}", fields(8), fields(7))
                .nCompteC = fields(9)
                .nActiviteC = fields(10)
                'Valeurs par défaut
                .dateCreation = Now
                .dateModification = Now
                .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
            End With
            res.Add(ent)
        End While

        Return res
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     nEntreprise (nCompte = 411 + nEntreprise, nActivité=0000)
    ' B 1     Nom
    ' C 2     Adresse 1
    ' D 3     Adresse 2
    ' E 4     CP
    ' F 5     Ville
    ' G 6     Téléphone
    ' H 7     Remise (ignorée)
    ' I 8     Observations
    ' J 9     Critere1
    ' K 10    Critere2
    ' L 11    Critere3
    ' M 12    Civilité
    ' N 13    Fax
    ' O 14    Pays
    <ImportEntreprise("Import entreprises depuis Agrifact DOS")> _
    Public Function ChargerFichierEntreprises(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0, Optional ByVal NomAvecCivilite As Boolean = False, Optional ByVal nCompte As String = "") As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Try
            Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
            While Not tfp.EndOfData
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
                Dim fields() As String = tfp.ReadFields

                If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

                If fields.Length < 15 Then
                    If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Continue While
                    Else
                        Throw New ApplicationException("Traitement annulé")
                    End If
                End If

                Dim ent As New Entreprise
                With ent
                    'Valeurs fichiers
                    .nEntreprise = fields(0)
                    If NomAvecCivilite Then
                        .nom = String.Format("{0} {1}", fields(12), fields(1)).Trim
                    Else
                        .nom = fields(1)
                    End If
                    .adresse = String.Format("{0}" & vbCrLf & "{1}", fields(2), fields(3)).Trim
                    .CodePostal = fields(4)
                    .Ville = fields(5)
                    .Telephone = fields(6)
                    .Observations = fields(8)
                    .Critere1 = fields(9)
                    .Critere2 = fields(10)
                    .Critere3 = fields(11)
                    .Civilite = fields(12)
                    .Fax = fields(13)
                    .Pays = fields(14)
                    If nCompte = "" Then
                        If fields(0).Length <= 5 Then
                            .nCompteC = "411" & fields(0).PadLeft(5, "0")
                        Else
                            .nCompteC = fields(0).PadRight(8, "0")
                        End If
                    Else
                        .nCompteC = nCompte
                    End If

                    .nActiviteC = "0000"
                    'Valeurs par défaut
                    .dateCreation = Now
                    .dateModification = Now
                    .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
                End With
                res.Add(ent)
            End While
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     nEntreprise (nCompte = 41100000, nActivité=0000)
    ' B 1     Nom
    ' C 2     Civilité
    ' D 3     Adresse
    ' E 4     CP
    ' F 5     Ville
    ' G 6     Téléphone
    ' H 7     Fax
    ' I 8     TypeClient
    ' J 9     Critere1
    <ImportEntreprise("Import entreprises pour Carteron")> _
    Public Function ChargerFichierEntreprisesCarteron(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0, Optional ByVal NomAvecCivilite As Boolean = False) As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Try
            Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
            While Not tfp.EndOfData
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
                Dim fields() As String = tfp.ReadFields

                If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

                If fields.Length < 10 Then
                    If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Continue While
                    Else
                        Throw New ApplicationException("Traitement annulé")
                    End If
                End If

                Dim ent As New Entreprise
                With ent
                    'Valeurs fichiers
                    .nEntreprise = fields(0)
                    If NomAvecCivilite Then
                        .nom = String.Format("{0} {1}", fields(2), fields(1)).Trim
                    Else
                        .nom = fields(1)
                    End If
                    .Civilite = fields(2)
                    .adresse = fields(3)
                    .CodePostal = fields(4)
                    .Ville = fields(5)
                    .Telephone = fields(6)
                    .Fax = fields(7)
                    .TypeClient = fields(8)
                    .Critere1 = fields(9)
                    .nCompteC = "41100000"
                    .nActiviteC = "0000"
                    'Valeurs par défaut
                    .dateCreation = Now
                    .dateModification = Now
                    .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
                End With
                res.Add(ent)
            End While
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     nEntreprise (nCompte = 41100000, nActivité=0000)
    ' B 1     Civilité 
    ' C 2     Nom
    ' D 3     Prénom
    ' E 4     Adresse1
    ' F 5     Adresse2
    ' G 6     CP
    ' H 7     Ville
    ' I 8     Tel
    ' J 9     Pays
    ' K 10    Fax
    ' L 11    Email
    ' M 12    C1
    ' N 13    C2
    ' O 14    C3
    ' P 15    C4
    <ImportEntreprise("Import entreprises pour Laffont")> _
    Public Function ChargerFichierEntreprisesLaffont(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0) As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
        While Not tfp.EndOfData
            RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
            Dim fields() As String = tfp.ReadFields

            If tfp.LineNumber <= nbLinesIgnored Then Continue While

            If fields.Length < 17 Then
                If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Continue While
                Else
                    Throw New ApplicationException("Traitement annulé")
                End If
            End If

            Dim ent As New Entreprise
            With ent
                'Valeurs fichiers
                .nEntreprise = fields(0)
                .Civilite = fields(1)
                .nom = String.Format("{0} {1}", fields(2), fields(3)).Trim
                .adresse = String.Format("{0}" & vbCrLf & "{1}", fields(4), fields(5)).Trim
                .CodePostal = fields(6)
                .Ville = fields(7)
                .Telephone = fields(8)
                .Pays = fields(9)
                .Fax = fields(10)
                .Email = fields(11)
                .Critere1 = fields(12)
                .Critere2 = fields(13)
                .Critere3 = fields(14)
                .Critere4 = fields(15)

                .nCompteC = "411" & fields(0).PadLeft(5, "0")
                .nActiviteC = "0000"
                'Valeurs par défaut
                .dateCreation = Now
                .dateModification = Now
                .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
            End With
            res.Add(ent)
        End While

        Return res
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     Civilité
    ' B 1     Nom
    ' C 2     Adresse
    ' D 3     CP
    ' E 4     Ville
    ' F 5     Pays
    ' G 6     Suffixe
    ' H 7     Tel
    ' I 8     Obs
    <ImportEntreprise("Import entreprises pour CEMA")> _
    Public Function ChargerFichierEntreprisesCEMA(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0) As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
        While Not tfp.EndOfData
            RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
            Dim fields() As String = tfp.ReadFields

            If tfp.LineNumber <= nbLinesIgnored Then Continue While

            If fields.Length < 9 Then
                If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Continue While
                Else
                    Throw New ApplicationException("Traitement annulé")
                End If
            End If

            Dim ent As New Entreprise
            With ent
                'Valeurs fichiers
                .nEntreprise = -1 '-1 pour trouver automatiquement le prochain nEntreprise
                .Civilite = fields(0)
                .nom = fields(1)
                .adresse = fields(2).Trim.Replace(vbLf, vbCrLf)
                .CodePostal = fields(3)
                .Ville = fields(4)
                .Pays = fields(5)
                .SuffixePostal = fields(6)
                .Telephone = fields(7)
                .Observations = fields(8)
                'Valeurs par défaut
                .dateCreation = Now
                .dateModification = Now
                .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
            End With
            res.Add(ent)
        End While

        Return res
    End Function


    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     Nom
    ' B 1     Adresse 1
    ' C 2     Adresse 2
    ' D 3     CP
    ' E 4     Ville
    ' F 5     Téléphone
    ' G 6     Fax
    ' H 7     Observations
    ' I 8     NCompteC
    ' J 9     Civilité
    ' K 10    Critere1
    ' L 11    Pays
    ' M 12    NTVAIntraCom
    ' N 13    Portable
    ' O 14    Mail
    <ImportEntreprise("Import entreprises pour Segonnaux")> _
    Public Function ChargerFichierEntreprisesSegonnaux(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0, Optional ByVal NomAvecCivilite As Boolean = False, Optional ByVal nCompte As String = "") As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Try
            Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
            While Not tfp.EndOfData
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
                Dim fields() As String = tfp.ReadFields

                If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

                If fields.Length < 15 Then
                    If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Continue While
                    Else
                        Throw New ApplicationException("Traitement annulé")
                    End If
                End If

                Dim ent As New Entreprise
                With ent
                    'Valeurs fichiers
                    .nEntreprise = -1
                    If NomAvecCivilite Then
                        .nom = String.Format("{0} {1}", fields(9), fields(0)).Trim
                    Else
                        .nom = fields(0)
                    End If
                    .adresse = String.Format("{0}" & vbCrLf & "{1}", fields(1), fields(2)).Trim
                    .CodePostal = fields(3)
                    .Ville = fields(4)
                    .Telephone = fields(5)
                    .Fax = fields(6)
                    .Observations = fields(7)
                    .nCompteC = fields(8).PadRight(8, "0")
                    .Civilite = fields(9)
                    .Critere1 = fields(10)
                    .Pays = fields(11)
                    .NTVAIntraCom = fields(12)
                    .Portable = fields(13)
                    .Email = fields(14)
                    .nActiviteC = "0000"
                    'Valeurs par défaut
                    .dateCreation = Now
                    .dateModification = Now
                    .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
                End With
                res.Add(ent)
            End While
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     Code Tiers
    ' B 1     Civilité
    ' C 2     Nom
    ' D 3     Prénom
    ' E 4     Adresse1
    ' F 5     Adresse2
    ' G 6     Departement
    ' H 7     CP
    ' I 8     Ville
    ' J 9     Tel
    ' K 10    Fax
    ' L 11    nTarif
    ' M 12    Critere 1
    ' N 13    Critere 2
    ' O 14    Date création
    ' P 15    Der commande
    ' Q 16    NCompteC
    ' R 17    FacturationTTC
    ' S 18    Observations
    ' T 19    Pays
    ' U 20    STOP
    <ImportEntreprise("Import entreprises pour Cogere")> _
    Public Function ChargerFichierEntreprisesCogere(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0, Optional ByVal NomAvecCivilite As Boolean = False, Optional ByVal nCompte As String = "") As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Try
            Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, ";")
            While Not tfp.EndOfData
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
                Dim fields() As String = tfp.ReadFields

                If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

                If fields.Length < 20 Then
                    If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Continue While
                    Else
                        Throw New ApplicationException("Traitement annulé")
                    End If
                End If

                Dim ent As New Entreprise
                With ent
                    'Valeurs fichiers
                    .nEntreprise = -1
                    .Civilite = fields(1)
                    If NomAvecCivilite Then
                        .nom = String.Format("{0} {1} {2}", fields(1), fields(2), fields(3)).Trim
                    Else
                        .nom = String.Format("{0} {1}", fields(2), fields(3)).Trim
                    End If
                    .adresse = String.Format("{0}" & vbCrLf & "{1}", fields(4), fields(5)).Trim
                    .CodePostal = fields(7)
                    .Ville = fields(8)
                    .Pays = fields(19)
                    .Telephone = fields(9)
                    .Fax = fields(10)
                    .Critere1 = fields(12)
                    .Critere2 = fields(13)
                    '.Critere3 = fields(12)
                    If fields(14).Length = 0 Then
                        .dateCreation = Now
                    Else
                        .dateCreation = Date.ParseExact(fields(14), "dd/MM/yyyy", My.Application.Culture.DateTimeFormat)
                    End If
                    .nCompteC = fields(16).PadRight(8, "0")
                    .nActiviteC = "0000"
                    .Observations = String.Format("{0} " & vbCrLf & "Dernière commande : {1}", fields(18), fields(15)).Trim
                    'Code tiers
                    .AddChampLibre("FacturationTTC", (fields(17) = "T"))
                    If fields(11).Length > 0 Then .AddChampLibre("nTarif", CInt(fields(11)))
                    If fields(0).Length > 0 Then .AddChampLibre("CodeTiers", "+" & Left(fields(0), 7).Trim)
                    'Valeurs par défaut
                    .dateModification = Now
                    .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
                End With
                res.Add(ent)
            End While
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    'Structure du fichier :
    ' Col   Contenu
    ' ----- -----------
    ' A 0     Code Tiers
    ' B 1     Nom
    ' C 2     Prénom
    ' D 3     Adresse1
    ' E 4     Adresse2
    ' F 5     Adresse3
    ' G 6     CP
    ' H 7     Ville
    ' I 8     Pays
    ' J 9     Departement
    ' K 10    Civilite
    ' L 11    Surnom
    ' M 12    Civ_ent
    ' N 13    Tel
    ' O 14    Email
    ' P 15    Date derniere facture
    ' Q 16    Der bon liv
    ' R 17    Der devis
    ' S 18    STOP
    <ImportEntreprise("Import entreprises pour Ceres")> _
    Public Function ChargerFichierEntreprisesCeres(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0, Optional ByVal NomAvecCivilite As Boolean = False, Optional ByVal nCompte As String = "") As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Try
            Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, ";")
            While Not tfp.EndOfData
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
                Dim fields() As String = tfp.ReadFields

                If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

                If fields.Length < 19 Then
                    If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Continue While
                    Else
                        Throw New ApplicationException("Traitement annulé")
                    End If
                End If

                Dim ent As New Entreprise
                With ent
                    'Valeurs fichiers
                    .nEntreprise = -1
                    If fields(12).Length > 0 Then
                        .Civilite = fields(12)
                    Else
                        .Civilite = fields(10)
                    End If

                    If NomAvecCivilite Then
                        .nom = String.Format("{0} {1} {2}", .Civilite, fields(1), fields(2)).Trim
                    Else
                        .nom = String.Format("{0} {1}", fields(1), fields(2)).Trim
                    End If
                    .adresse = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", fields(3), fields(4), fields(5)).Trim
                    .CodePostal = fields(6)
                    .Ville = fields(7)
                    .Pays = fields(8)
                    .Telephone = fields(13)
                    .Email = fields(14)
                    .Critere1 = fields(15).Replace("00:00:00.0", "").Trim
                    '.Critere2 = fields(14)
                    '.Critere3 = fields(12)
                    .nCompteC = "41100000"
                    .nActiviteC = "0000"
                    '.Observations = String.Format("Dernière facture : {0}", fields(15).Replace("00:00:00.0", "")).Trim
                    .AddChampLibre("CodeTiers", "+" & Left(fields(1), 6).Trim & Left(fields(2), 1).Trim)
                    'Valeurs par défaut
                    .dateCreation = Now
                    .dateModification = Now
                    .InfoMaj = String.Format("Importé depuis le fichier '{0}'", nomFic)
                End With
                res.Add(ent)
            End While
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

#End Region

#Region " Import Produits "
    <ImportProduit("Import produits depuis Agrifact DOS")> _
    Public Function ChargerFichierProduits(ByVal nomFic As String, Optional ByVal nbLinesIgnored As Integer = 0) As List(Of IDataItem)
        Dim res As New List(Of IDataItem)

        RaiseEvent ReportProgress(Me, New ProgressEventArgs("Analyse du fichier...", 0, CompterLignesFichier(nomFic)))

        Dim tfp As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(nomFic, vbTab)
        While Not tfp.EndOfData
            RaiseEvent ReportProgress(Me, New ProgressEventArgs(, tfp.LineNumber, ))
            Dim fields() As String = tfp.ReadFields

            If tfp.LineNumber <= nbLinesIgnored + 1 Then Continue While

            If fields.Length < 9 Then
                If MsgBox("Ligne malformée." & vbCrLf & "Continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Continue While
                Else
                    Throw New ApplicationException("Traitement annulé")
                End If
            End If

            Dim prod As New Produit
            With prod
                'Valeurs fichiers
                .nProduit = -1 ' fields(0)
                .CodeProduit = fields(0)
                .Libelle = fields(1)
                .NCompteA = fields(2)
                .NCompteV = fields(3)
                .NActiviteA = fields(4).PadLeft(4, "0"c)
                .NActiviteV = fields(4).PadLeft(4, "0"c)
                .TTVA = fields(5)
                .Unite1 = fields(6)
                .PrixAHT = CDbl(fields(7).Replace(".", ","))
                .PrixVHT = CDbl(fields(8).Replace(".", ","))
            End With
            res.Add(prod)
        End While

        Return res
    End Function
#End Region

    Public Sub InsererItems(ByVal items As List(Of IDataItem))
        If Connection Is Nothing Then Throw New Exception("Connexion inexistante")
        If Connection.State <> ConnectionState.Open Then Connection.Open()

        Dim com As New SqlClient.SqlCommand("BEGIN TRANSACTION", Connection)
        com.ExecuteNonQuery()
        Try
            RaiseEvent ReportProgress(Me, New ProgressEventArgs("Ecriture des données...", 0, items.Count))
            'VerifStructureBase()
            Dim i As Integer = 0
            For Each item As IDataItem In items
                i += 1
                RaiseEvent ReportProgress(Me, New ProgressEventArgs(, i, ))
                If item.Exists(Connection) Then
                    item.Update(Connection)
                Else
                    item.Insert(Connection)
                End If
            Next
            com.CommandText = "COMMIT TRANSACTION"
            com.ExecuteNonQuery()
            MsgBox("Import effectué correctement")
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            com.CommandText = "ROLLBACK TRANSACTION"
            com.ExecuteNonQuery()
        End Try
    End Sub

    Private Sub VerifStructureBase()
        AssurerPresenceColonne("Entreprise", "NCompteC", "varchar(8)")
        AssurerPresenceColonne("Entreprise", "NActiviteC", "varchar(4)")
    End Sub

    Private Sub AssurerPresenceColonne(ByVal tableName As String, ByVal colName As String, ByVal type As String)
        Const SQL_VERIFY_COL As String = "select count(*) from information_schema.columns where table_name='{0}' and column_name='{1}'"
        Const SQL_ADD_COL As String = "alter table {0} add ""{1}"" {2}"
        Dim sql As String = String.Format(SQL_VERIFY_COL, tableName, colName)
        Dim cmd As New SqlClient.SqlCommand(sql, Connection)
        If CInt(cmd.ExecuteScalar()) = 0 Then
            cmd.CommandText = String.Format(SQL_ADD_COL, tableName, colName, type)
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Function CompterLignesFichier(ByVal nomFic As String) As Integer
        Dim res As Integer = 0
        Dim sr As IO.StreamReader = IO.File.OpenText(nomFic)
        While Not sr.EndOfStream
            sr.ReadLine()
            res += 1
        End While
        sr.Close()
        Return res
    End Function

End Class
