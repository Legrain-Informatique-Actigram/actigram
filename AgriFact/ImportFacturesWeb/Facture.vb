Public Class Facture

#Region "Props"
    Private _nfacture As Integer
    Public Property nFacture() As Integer
        Get
            Return _nfacture
        End Get
        Set(ByVal value As Integer)
            _nfacture = value
        End Set
    End Property


    Private _date As Date
    Public Property DateFacture() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
        End Set
    End Property


    Private _adresse As String
    Public Property Adresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
        End Set
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


    Private _montantTVA As Decimal
    Public Property MontantTVA() As Decimal
        Get
            Return _montantTVA
        End Get
        Set(ByVal value As Decimal)
            _montantTVA = value
        End Set
    End Property


    Private _montantHT As Decimal
    Public Property MontantHT() As Decimal
        Get
            Return _montantHT
        End Get
        Set(ByVal value As Decimal)
            _montantHT = value
        End Set
    End Property


    Private _obs As String
    Public Property Observations() As String
        Get
            Return _obs
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property


    Private _client As Client
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
        End Set
    End Property


    Private _lignes As New List(Of LigneFacture)
    Public Property Lignes() As List(Of LigneFacture)
        Get
            Return _lignes
        End Get
        Set(ByVal value As List(Of LigneFacture))
            _lignes = value
        End Set
    End Property
#End Region

    Public Sub Insert(ByVal ds As DsAgrifact)
        Dim drFact As DsAgrifact.VFactureRow = ds.VFacture.NewVFactureRow
        With drFact
            .nFacture = Me.nFacture
            .DateFacture = Me.DateFacture
            .AdresseFacture = Me.Adresse
            .EntrepriseRow = Me.Client.GetDatarow(ds)
            .FacturationTTC = False
            .MontantHT = Me.MontantHT
            .MontantTVA = Me.MontantTVA
            .MontantTTC = Me.MontantTTC
            .Observation = Me.Observations
            .Paye = False
            .Remise = 0D
        End With
        ds.VFacture.Rows.Add(drFact)
        For Each l As LigneFacture In Me.Lignes
            l.Insert(ds, drFact)
        Next
    End Sub

End Class

Public Class LigneFacture

#Region "Props"
    Private _code As String
    Public Property CodeProduit() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property

    Private _lib As String
    Public Property Libelle() As String
        Get
            Return _lib
        End Get
        Set(ByVal value As String)
            _lib = value
        End Set
    End Property

    Private _prixUHT As Decimal
    Public Property PrixUHT() As Decimal
        Get
            Return _prixUHT
        End Get
        Set(ByVal value As Decimal)
            _prixUHT = value
        End Set
    End Property


    Private _qte As Decimal
    Public Property Quantite() As Decimal
        Get
            Return _qte
        End Get
        Set(ByVal value As Decimal)
            _qte = value
        End Set
    End Property


    Private _unite As String
    Public Property Unite() As String
        Get
            Return _unite
        End Get
        Set(ByVal value As String)
            _unite = value
        End Set
    End Property

    Private _remise As Decimal
    Public Property Remise() As Decimal
        Get
            Return _remise
        End Get
        Set(ByVal value As Decimal)
            _remise = value
        End Set
    End Property

    Private _ttva As String
    Public Property TTVA() As String
        Get
            Return _ttva
        End Get
        Set(ByVal value As String)
            _ttva = value
        End Set
    End Property

    Private _txTVA As Decimal
    Public Property TxTVA() As Decimal
        Get
            Return _txTVA
        End Get
        Set(ByVal value As Decimal)
            _txTVA = value
        End Set
    End Property

    Private _montantHT As Decimal
    Public Property MontantHT() As Decimal
        Get
            Return _montantHT
        End Get
        Set(ByVal value As Decimal)
            _montantHT = value
        End Set
    End Property


    Private _montantTVA As Decimal
    Public Property MontantTVA() As Decimal
        Get
            Return _montantTVA
        End Get
        Set(ByVal value As Decimal)
            _montantTVA = value
        End Set
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

    Private _nCompte As String
    Public Property NCompte() As String
        Get
            Return _nCompte
        End Get
        Set(ByVal value As String)
            _nCompte = value
        End Set
    End Property

    Private _nActi As String
    Public Property NActivite() As String
        Get
            Return _nActi
        End Get
        Set(ByVal value As String)
            _nActi = value
        End Set
    End Property
#End Region

    Public Sub CalculerMontants()
        Me.MontantHT = Decimal.Round((Me.Quantite * Me.PrixUHT) * (1 - Me.Remise), 2)
        Me.MontantTTC = Decimal.Round(Me.MontantHT * (1 + Me.TxTVA), 2)
        Me.MontantTVA = Me.MontantTTC - Me.MontantHT
    End Sub

    Public Sub ParametrerProduit(ByVal ds As DsAgrifact, ByVal codeProduit As String, Optional ByVal useDefaultTVA As Boolean = True)
        Me.CodeProduit = codeProduit
        Dim drProduit As DsAgrifact.ProduitRow = ds.Produit.FindByCodeProduit(codeProduit)
        If drProduit IsNot Nothing Then
            If Not drProduit.IsUnite1Null Then Me.Unite = drProduit.Unite1
            If Not drProduit.IsTTVANull Then
                Me.ParametrerTVA(ds, drProduit.TTVA)
            ElseIf useDefaultTVA Then
                Me.ParametrerTVA(ds, My.Settings.CodeTVADefaut)
            End If
            If Not drProduit.IsNCompteVNull Then Me.NCompte = drProduit.NCompteV
            If Not drProduit.IsNActiviteVNull Then Me.NActivite = drProduit.NActiviteV
        Else
            Me.Unite = "U"
            Me.ParametrerTVA(ds, My.Settings.CodeTVADefaut)
            Me.NCompte = My.Settings.CompteProduitDefaut
            Me.NActivite = My.Settings.ActiProduitDefaut
        End If
    End Sub

    Public Sub ParametrerTVA(ByVal ds As DsAgrifact, ByVal TTVA As String)
        Me.TTVA = TTVA
        Dim drTVA As DsAgrifact.TVARow = ds.TVA.FindByTTVA(TTVA)
        If drTVA IsNot Nothing Then
            If Not drTVA.IsTTauxNull Then Me.TxTVA = drTVA.TTaux / 100
        End If
    End Sub

    Public Sub Insert(ByVal ds As DsAgrifact, ByVal drFact As DsAgrifact.VFactureRow)
        Dim drDetail As DsAgrifact.VFacture_DetailRow = ds.VFacture_Detail.NewVFacture_DetailRow
        With drDetail
            .VFactureRow = drFact
            .ProduitRow = GetProduitDatarow(ds)
            .Libelle = Me.Libelle
            .Unite1 = Me.Quantite
            .LibUnite1 = Me.Unite
            .PrixUHT = Me.PrixUHT
            .Remise = Me.Remise
            .TTVA = Me.TTVA
            .TxTva = Me.TxTVA
            .MontantLigneHT = Me.MontantHT
            .MontantLigneTVA = Me.MontantTVA
            .MontantLigneTTC = Me.MontantTTC
            .NCompte = Me.NCompte
            .NActivite = Me.NActivite
        End With
        ds.VFacture_Detail.Rows.Add(drDetail)
    End Sub

    Public Function GetProduitDatarow(ByVal ds As DsAgrifact)
        Dim dr As DsAgrifact.ProduitRow = ds.Produit.FindByCodeProduit(Me.CodeProduit)
        If dr Is Nothing Then
            dr = ds.Produit.NewProduitRow
            With dr
                .CodeProduit = Me.CodeProduit
                .Libelle = Me.Libelle
                .TTVA = My.Settings.CodeTVADefaut
                .Unite1 = "U"
                .PrixVHT = Me.PrixUHT
                .NCompteV = My.Settings.CompteProduitDefaut
                .NActiviteV = My.Settings.ActiProduitDefaut
                .Famille1 = My.Settings.FamilleDefaut
                .Inactif = False
            End With
            ds.Produit.AddProduitRow(dr)
        End If
        Return dr
    End Function

End Class

Public Class Client

#Region "Props"

    Private _nom As String
    Public Property Nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _tel As String
    Public Property Tel() As String
        Get
            Return _tel
        End Get
        Set(ByVal value As String)
            _tel = value
        End Set
    End Property


    Private _adrFact As Adresse
    Public Property AdresseFacturation() As Adresse
        Get
            Return _adrFact
        End Get
        Set(ByVal value As Adresse)
            _adrFact = value
        End Set
    End Property


    Private _adrLiv As Adresse
    Public Property AdresseLivraison() As Adresse
        Get
            Return _adrLiv
        End Get
        Set(ByVal value As Adresse)
            _adrLiv = value
        End Set
    End Property

#End Region

    Public Function GetDataRow(ByVal ds As DsAgrifact) As DsAgrifact.EntrepriseRow
        Dim dr As DsAgrifact.EntrepriseRow = ds.Entreprise.FindByNom(Me.Nom)
        If dr Is Nothing Then
            dr = ds.Entreprise.NewEntrepriseRow
            dr.Nom = Me.Nom
            dr.InfoMAJ = "Créé par import web"
            dr.DateCreation = Today
            dr.Inactif = False
            dr.NCompteC = My.Settings.CompteClientDefaut
            dr.NActiviteC = My.Settings.ActiClientDefaut
            ds.Entreprise.AddEntrepriseRow(dr)
        End If
        dr.DateModification = Today        
        dr.Client = True
        dr.EMail = Me.Email
        With Me.AdresseFacturation
            dr.Adresse = .Adresse
            dr.CodePostal = .CodePostal
            dr.Ville = .Ville
            dr.Pays = .Pays
        End With
        With Me.AdresseLivraison
            dr.AdresseLiv = .Adresse
            dr.CodePostalLiv = .CodePostal
            dr.VilleLiv = .Ville
            dr.PaysLiv = .Pays
        End With
        CreateTelDatarow(ds, dr)
        Return dr
    End Function

    Public Sub CreateTelDatarow(ByVal ds As DsAgrifact, ByVal dr As DsAgrifact.EntrepriseRow)
        If Me.Tel.Length = 0 Then Exit Sub
        Dim drTel As DsAgrifact.TelephoneEntrepriseRow = ds.TelephoneEntreprise.FindBynEntrepriseType(dr.nEntreprise, "Siege")
        If drTel Is Nothing Then
            drTel = ds.TelephoneEntreprise.AddTelephoneEntrepriseRow(dr, "Siege", Me.Tel)
        End If
    End Sub

End Class

Public Class Adresse
    Private _adresse As String
    Public Property Adresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
        End Set
    End Property

    Private _cp As String
    Public Property CodePostal() As String
        Get
            Return _cp
        End Get
        Set(ByVal value As String)
            _cp = value
        End Set
    End Property

    Private _ville As String
    Public Property Ville() As String
        Get
            Return _ville
        End Get
        Set(ByVal value As String)
            _ville = value
        End Set
    End Property

    Private _pays As String
    Public Property Pays() As String
        Get
            Return _pays
        End Get
        Set(ByVal value As String)
            _pays = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim res As String = String.Format("{0}" & vbCrLf & "{1} {2}", Me.Adresse, Me.CodePostal, Me.Ville).Trim
        If Me.Pays.Length > 0 AndAlso Not String.Equals(Me.Pays, "france", StringComparison.CurrentCultureIgnoreCase) Then
            res &= vbCrLf & Me.Pays
        End If
        Return res
    End Function
End Class