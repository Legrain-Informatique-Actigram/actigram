'Public Type FactureAgrigest
'    N° As String * 5
'    j As String * 2
'    m As String * 2
'    a As String * 2
'    CptTiers As String * 8
'    NomTiers As String * 15
'    LibProduit As String * 35
'    CptProduit As String * 8
'    ActProduit As String * 4
'    CodeTVA As String * 5
'    U1 As String * 2
'    Qt1 As String * 8
'    U2 As String * 2
'    Qt2 As String * 8
'    MHT As String * 9
'    MTVA As String * 9
'    Avoir As String * 1
'    fin As String * 156
'    DC As String * 1
'    Rt As String * 2
'End Type

Public Class LigneExportAgrigest
    Dim _Numero As String = ""
    Dim _Date As Date
    Dim _CptTiers As String = ""
    Dim _NomTiers As String = ""
    Dim _LibProduit As String = ""
    Dim _CptProduit As String = ""
    Dim _ActProduit As String = ""
    Dim _CodeTVA As String = ""
    Dim _U1 As String = ""
    Dim _Qt1 As String = ""
    Dim _U2 As String = ""
    Dim _Qt2 As String = ""
    Dim _MHT As String = ""
    Dim _MTVA As String = ""
    Dim _Avoir As String = ""

#Region "Property"
    Public Property NumeroPiece() As String
        Get
            Return _Numero.PadLeft(5, "0"c)
        End Get
        Set(ByVal Value As String)
            _Numero = Left(Value.PadLeft(5, "0"c), 5)
        End Set
    End Property

    Public Property DatePiece() As Date
        Get
            Return _Date
        End Get
        Set(ByVal Value As Date)
            _Date = Value
        End Set
    End Property

    Public Property CptTiers() As String
        Get
            Return _CptTiers.PadRight(8, "0"c)
        End Get
        Set(ByVal Value As String)
            _CptTiers = Left(Value.PadRight(8, "0"c), 8)
        End Set
    End Property

    Public Property NomTiers() As String
        Get
            Return _NomTiers.PadRight(15)
        End Get
        Set(ByVal Value As String)
            _NomTiers = Left(Value.PadRight(15), 15)
        End Set
    End Property

    Public Property LibProduit() As String
        Get
            Return _LibProduit.PadRight(35)
        End Get
        Set(ByVal Value As String)
            _LibProduit = Left(Value.PadRight(35), 35)
        End Set
    End Property

    Public Property CptProduit() As String
        Get
            Return _CptProduit.PadRight(8, "0"c)
        End Get
        Set(ByVal Value As String)
            _CptProduit = Left(Value.PadRight(8, "0"c), 8)
        End Set
    End Property

    Public Property ActProduit() As String
        Get
            Return _ActProduit.PadRight(4, "0"c)
        End Get
        Set(ByVal Value As String)
            _ActProduit = Left(Value.PadRight(4, "0"c), 4)
        End Set
    End Property

    Public Property CodeTva() As String
        Get
            Return _CodeTVA.PadRight(5)
        End Get
        Set(ByVal Value As String)
            _CodeTVA = Left(Value.PadRight(5), 5)
        End Set
    End Property

    Public Property Unite1() As String
        Get
            Return _U1.PadRight(2)
        End Get
        Set(ByVal Value As String)
            _U1 = Left(Value.PadRight(2), 2)
        End Set
    End Property

    Public Property Quantite1() As String
        Get
            Return _Qt1.PadLeft(8, "0"c)
        End Get
        Set(ByVal Value As String)
            _Qt1 = Left(Value.PadLeft(8, "0"c), 8)
        End Set
    End Property

    Public Property Unite2() As String
        Get
            Return _U2.PadRight(2)
        End Get
        Set(ByVal Value As String)
            _U2 = Left(Value.PadRight(2), 2)
        End Set
    End Property

    Public Property Quantite2() As String
        Get
            Return _Qt2.PadLeft(8, "0"c)
        End Get
        Set(ByVal Value As String)
            _Qt2 = Left(Value.PadLeft(8, "0"c), 8)
        End Set
    End Property

    Public Property MontantHT() As String
        Get
            Return _MHT.PadLeft(9, "0"c)
        End Get
        Set(ByVal Value As String)
            _MHT = Left(Value.PadLeft(9, "0"c), 9)
        End Set
    End Property

    Public Property MontantTVA() As String
        Get
            Return _MTVA.PadLeft(9, "0"c)
        End Get
        Set(ByVal Value As String)
            _MTVA = Left(Value.PadLeft(9, "0"c), 9)
        End Set
    End Property

    Public Property Avoir() As String
        Get
            Return _Avoir
        End Get
        Set(ByVal Value As String)
            _Avoir = Left(Value, 1)
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}{1:ddMMyy}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}", _
                    NumeroPiece, DatePiece, CptTiers, NomTiers, LibProduit, CptProduit, ActProduit, CodeTva, _
                    Unite1, Quantite1, Unite2, Quantite2, MontantHT, MontantTVA, Avoir)
    End Function

End Class

Public Class CollectionLigneExportAgrigest
    Inherits CollectionBase

    Private Const FIN_LIGNE As String = "*"

    Public Event ExportProgressed(ByVal percent As Integer)

    Public Sub Add(ByVal LigneExport As LigneExportAgrigest)
        Me.List.Add(LigneExport)
    End Sub

    Public Function Item(ByVal index As Integer) As LigneExportAgrigest
        Return DirectCast(Me.List.Item(index), LigneExportAgrigest)
    End Function

    Public Function Items() As LigneExportAgrigest()
        Dim LstLigneExport(Me.List.Count - 1) As LigneExportAgrigest
        Me.List.CopyTo(LstLigneExport, 0)
        Return LstLigneExport
    End Function

    Public Sub ExportVersFichier(ByVal strChemin As String)
        Dim StrWriter As New IO.StreamWriter(strChemin, False, System.Text.Encoding.ASCII)
        With StrWriter
            Try
                Dim _items() As LigneExportAgrigest = Me.Items
                For i As Integer = 0 To _items.Length - 1
                    RaiseEvent ExportProgressed(i * 100 \ _items.Length)
                    With _items(i)
                        .NomTiers = .NomTiers.Replace(vbCr, " ").Replace(vbLf, " ")
                        .LibProduit = .LibProduit.Replace(vbCr, " ").Replace(vbLf, " ")
                        StrWriter.WriteLine(ReplaceAccents(.ToString).PadRight(253, " "c) & FIN_LIGNE)
                    End With
                Next
                RaiseEvent ExportProgressed(100)
                .WriteLine("STOP".PadRight(253, " "c) & FIN_LIGNE)
            Finally
                .Close()
            End Try
        End With
    End Sub

    Private Function ReplaceAccents(ByVal str As String) As String
        str = str.Replace("'", " ")
        str = str.Replace(Chr(34), " ")
        str = str.Replace("@", "a")
        str = str.Replace("à", "a")
        str = str.Replace("â", "a")
        str = str.Replace("ç", "c")
        str = str.Replace("é", "e")
        str = str.Replace("è", "e")
        str = str.Replace("ë", "e")
        str = str.Replace("ê", "e")
        str = str.Replace("î", "i")
        str = str.Replace("ù", "u")
        str = str.Replace("û", "u")
        Return str
    End Function

End Class


#Region "A VIRER"
'Sub Exporter()
'    Dim ms1 As Recordset, ms2 As Recordset, strSql2 As String, strSql1 As String, Fact As FactureAgrigest, nb, MHT, MTVA, rep
'    nb = 0
'    '******************************************************************************
'    '* Fonction permettant d'exporter les factures et les règlements vers agrigest
'    '******************************************************************************
'    FichierExport = strCheminExportCompta & "\ExportBo"
'    rep = dtFileCreat(FichierExport)
'    If rep <> "" Then
'        rep = MsgBox("Attention Vous allez écraser le Fichier d'export cré le : " & rep & "." & vbCr & "Voulez vous continuer ?", vbYesNo, "Attention")
'        If rep = vbNo Then
'            MsgBox("Cette export ne sera pas réalisée pour l'instant !")
'            GoTo fin
'        End If
'        Kill(FichierExport)
'    End If
'Open FichierExport For Random As #1 Len = Len(Fact)
'    If CkFacture.Value = 1 Then
'        If Me.CkToutes.Value = 0 Then
'            strSql1 = "SELECT BonCommande.[n°BC], BonCommande.NFacture, BonCommande.DtFacture, Client.[n°Client], Client.[n°Compte] AS CptClient, Client.Nom, Client.Prénom, Produit.Produit, Produit.[n°Compte] AS CptProduit, Produit.[n°CompteActivite], TVA.[n°Compte] AS CptTVA, Produit.Unite, DetailCommande.Poids, DetailCommande.Remise, DetailCommande.Prix, TVA.TVA, clng(((1 + TVA.TVA / 100) * ((DetailCommande.Prix*DetailCommande.Poids))) * 100) / 100 AS PrixMTTC , clng(((1 + TVA.TVA / 100) * ((DetailCommande.Prix*DetailCommande.Poids))) * 100) / 100 - clng((DetailCommande.Prix* DetailCommande.Poids) * 100) / 100 AS MTVA " & _
'            "FROM TVA INNER JOIN (Produit INNER JOIN ((Client INNER JOIN BonCommande ON Client.[n°Client] = BonCommande.[n°Client]) INNER JOIN DetailCommande ON BonCommande.[n°BC] = DetailCommande.[n°Commande]) ON Produit.[n°Produit] = DetailCommande.[n°Produit]) ON TVA.[n°TVA] = Produit.[n°TVA] " & _
'            "WHERE (((BonCommande.Payé)=True) AND((BonCommande.ExportCompta)=False) AND (BonCommande.DtFacture>#" & InvDate(DtFactureDeb.Value) & "# or BonCommande.DtFacture=#" & InvDate(DtFactureDeb.Value) & "#) AND (BonCommande.DtFacture<#" & InvDate(DtFactureFin.Value) & "# or BonCommande.DtFacture=#" & InvDate(DtFactureFin.Value) & "#)) Order by BonCommande.[NFacture];"
'        Else
'            strSql1 = "SELECT BonCommande.[n°BC], BonCommande.NFacture, BonCommande.DtFacture, Client.[n°Client], Client.[n°Compte] AS CptClient, Client.Nom, Client.Prénom, Produit.Produit, Produit.[n°Compte] AS CptProduit, Produit.[n°CompteActivite], TVA.[n°Compte] AS CptTVA, Produit.Unite, DetailCommande.Poids, DetailCommande.Remise, DetailCommande.Prix, TVA.TVA, clng(((1 + TVA.TVA / 100) * ((DetailCommande.Prix*DetailCommande.Poids))) * 100) / 100 AS PrixMTTC , clng(((1 + TVA.TVA / 100) * ((DetailCommande.Prix*DetailCommande.Poids))) * 100) / 100 - clng((DetailCommande.Prix* DetailCommande.Poids) * 100) / 100 AS MTVA " & _
'            "FROM TVA INNER JOIN (Produit INNER JOIN ((Client INNER JOIN BonCommande ON Client.[n°Client] = BonCommande.[n°Client]) INNER JOIN DetailCommande ON BonCommande.[n°BC] = DetailCommande.[n°Commande]) ON Produit.[n°Produit] = DetailCommande.[n°Produit]) ON TVA.[n°TVA] = Produit.[n°TVA] " & _
'            "WHERE (((BonCommande.ExportCompta)=False) AND (BonCommande.DtFacture>#" & InvDate(DtFactureDeb.Value) & "# or BonCommande.DtFacture=#" & InvDate(DtFactureDeb.Value) & "#) AND (BonCommande.DtFacture<#" & InvDate(DtFactureFin.Value) & "# or BonCommande.DtFacture=#" & InvDate(DtFactureFin.Value) & "#)) Order by BonCommande.[NFacture];"
'        End If
'        ms1 = db.OpenRecordset(strSql1, dbOpenDynaset)
'        If ms1.EOF = False Then
'            ms1.MoveFirst()
'            Do Until ms1.EOF = True
'                nb = nb + 1
'                With Fact
'                .N° = Cpl(ms1.Fields("NFacture"), "0", 5)
'                    .j = Cpl(Day(ms1.Fields("DtFacture")), "0", 2)
'                    .m = Cpl(Month(ms1.Fields("DtFacture")), "0", 2)
'                    .a = Cpl(Right(Year(ms1.Fields("DtFacture")), 2), "0", 2)
'                    If IsNull(ms1.Fields("CptClient")) = False Then
'                        '.CptTiers = Left(CplD(ms1.Fields("cptClient"), "0", 8), 8 - Len(ms1.Fields("n°Client"))) & ms1.Fields("n°Client")
'                        .CptTiers = CplD(ms1.Fields("CptClient"), "0", 8)
'                    Else
'                        .CptTiers = CplD("", "0", 8)
'                    End If
'                    .NomTiers = Left((ms1.Fields("Nom") & " " & Left(ms1.Fields("Prénom"), 1)), 15)
'                    .LibProduit = ms1.Fields("Produit")
'                    If IsNull(ms1.Fields("CptProduit")) = False Then
'                        .CptProduit = CplD(ms1.Fields("CptProduit"), "0", 8)
'                    Else
'                        .CptProduit = CplD("", "0", 8)
'                    End If
'                    If IsNull(ms1.Fields("n°CompteActivite")) = False Then
'                        .ActProduit = Cpl(ms1.Fields("n°CompteActivite"), "0", 4)
'                    Else
'                        .ActProduit = Cpl("", "0", 4)
'                    End If
'                    If IsNull(ms1.Fields("CptTVA")) = False Then
'                        .CodeTVA = CplD(ms1.Fields("CptTVA"), " ", 5)
'                    Else
'                        .CodeTVA = CplD("", " ", 5)
'                    End If
'                    If IsNull(ms1.Fields("Unite")) = False Then
'                        .U1 = Cpl(ms1.Fields("Unite"), " ", 2)
'                    Else
'                        .U1 = "  "
'                    End If
'                    .U2 = "  "
'                    .Qt2 = "000000"
'                    .Qt1 = Cpl(Abs(Fix(ms1.Fields("Poids") * 100)), "0", 6)
'                    MHT = Cpl(Abs(ms1.Fields("PrixMTTC") * 100), "0", 7)
'                    MTVA = Cpl(Abs(CLng(ms1.Fields("MTVA") * 100)), "0", 7)
'                    .MHT = MHT
'                    .MTVA = MTVA
'                    If Abs(Fix(ms1.Fields("Poids") * 100)) <> Fix(ms1.Fields("Poids") * 100) Or _
'                    Abs(ms1.Fields("PrixMTTC") * 100) <> ms1.Fields("PrixMTTC") * 100 Then
'                        .Avoir = "A"
'                    Else
'                        .Avoir = " "
'                    End If
'                .fin = String(156, "_")
'                    .DC = "*"
'                    .Rt = Chr(13) & Chr(10)
'                End With
'                strSql2 = "Select BonCommande.ExportCompta From BonCommande Where BonCommande.[n°BC]=" & ms1.Fields("n°BC") & ";"
'                ms2 = db.OpenRecordset(strSql2, dbOpenDynaset)
'                If ms2.EOF = False Then
'                    ms2.MoveFirst()
'                    ms2.Edit()
'                    ms2.Fields("ExportCompta") = True
'                    ms2.Update()
'                End If
'                ms1.MoveNext()
'            Put #1, nb, Fact
'            Loop
'        End If
'    End If
'    If CkReglement.Value = 1 Then
'        strSql1 = "SELECT Remise.[n°Remise], Remise.NRemise, Remise.Date, Banque.[n°Compte] as CptBanque, Client.[n°Client],Client.Nom, Client.Prénom, Client.[n°Compte] as CptClient, Reglement.[n°Reglement], Reglement.[n°Cheque], Reglement.TypeReglement, Reglement.Montant " & _
'        "FROM (Banque INNER JOIN Remise ON Banque.[n°Banque] = Remise.[n°Banque]) INNER JOIN ((Reglement INNER JOIN Client ON Reglement.[n°Client] = Client.[n°Client]) INNER JOIN DetailRemise ON Reglement.[n°Reglement] = DetailRemise.[n°Reglement]) ON Remise.[n°Remise] = DetailRemise.[n°Remise] " & _
'        "WHERE (((Reglement.ExportCompta)=False) AND (Remise.Date>#" & InvDate(DtReglementDeb.Value) & "# or Remise.Date=#" & InvDate(DtReglementDeb.Value) & "#) AND (Remise.Date<#" & InvDate(DtReglementFin.Value) & "# or Remise.Date=#" & InvDate(DtReglementFin.Value) & "#));"

'        ms1 = db.OpenRecordset(strSql1, dbOpenDynaset)
'        If ms1.EOF = False Then
'            ms1.MoveFirst()
'            Do Until ms1.EOF = True
'                nb = nb + 1
'                With Fact
'                    If ms1.Fields("TypeReglement") = "Chèque" Then
'                .N° = "RE CH"
'                    Else
'                .N° = "RE ES"
'                    End If
'                    .j = Cpl(Day(ms1.Fields("Date")), "0", 2)
'                    .m = Cpl(Month(ms1.Fields("Date")), "0", 2)
'                    .a = Cpl(Right(Year(ms1.Fields("Date")), 2), "0", 2)
'                    If IsNull(ms1.Fields("CptBanque")) = False Then
'                        .CptTiers = CplD(ms1.Fields("CptBanque"), "0", 8)
'                    Else
'                        .CptTiers = CplD("", "0", 8)
'                    End If
'                    .NomTiers = ms1.Fields("n°Cheque")
'                    'Left((ms1.Fields("Nom") & " " & Left(ms1.Fields("Prénom"), 1)), 15)
'                    .LibProduit = Left((ms1.Fields("Nom") & " " & Left(ms1.Fields("Prénom"), 1)), 15)
'                    'ms1.Fields ("Produit")
'                    If IsNull(ms1.Fields("CptClient")) = False Then
'                        .CptProduit = CplD(ms1.Fields("CptClient"), "0", 8)
'                        '.CptProduit = Left(CplD(ms1.Fields("cptClient"), "0", 8), 8 - Len(ms1.Fields("n°Client"))) & ms1.Fields("n°Client")
'                    Else
'                        .CptProduit = CplD("", "0", 8)
'                    End If
'                    'If IsNull(ms1.Fields("n°CompteActivite")) = False Then
'                    '    .ActProduit = Cpl(ms1.Fields("n°Activite"), "0", 4)
'                    'Else
'                    .ActProduit = Cpl("", "0", 4)
'                    'End If
'                    'If IsNull(ms1.Fields("CptTVA")) = False Then
'                    '    .CodeTVA = Cpl(ms1.Fields("CptTVA"), "0", 5)
'                    'Else
'                    .CodeTVA = Cpl("", " ", 5)
'                    'End If
'                    'If IsNull(ms1.Fields("Unite")) = False Then
'                    '    .U1 = Cpl(ms1.Fields("Unite"), " ", 2)
'                    'Else
'                    .U1 = "  "
'                    'End If
'                    .U2 = "  "
'                    .Qt1 = Right(Cpl(ms1.Fields("NRemise"), "0", 6), 6)
'                    .Qt2 = "000000"
'                    '.Qt1 = Cpl(Fix(ms1.Fields("Quantité") * 100), "0", 6)
'                    'MHT = Cpl(Fix(ms1.Fields("Prix") * (1 - ms1.Fields("Remise") / 100) * 100), "0", 7)
'                    'MTVA = Cpl(Fix((ms1.Fields("Prix") * (1 - ms1.Fields("Remise") / 100)) * (ms1.Fields("TVA") / 100) * 100), "0", 7)
'                    .MHT = Cpl(CLng((ms1.Fields("Montant") * 100)), "0", 7)
'                    .MTVA = Cpl("", " ", 7)
'                    .Avoir = " "
'                .fin = String(156, "_")
'                    .DC = "*"
'                    .Rt = Chr(13) & Chr(10)
'                End With
'                strSql2 = "Select Reglement.ExportCompta From Reglement Where Reglement.[n°Reglement]=" & ms1.Fields("n°Reglement") & ";"
'                ms2 = db.OpenRecordset(strSql2, dbOpenDynaset)
'                If ms2.EOF = False Then
'                    ms2.MoveFirst()
'                    ms2.Edit()
'                    ms2.Fields("ExportCompta") = True
'                    ms2.Update()
'                End If
'                ms1.MoveNext()
'            Put #1, nb, Fact
'            Loop
'        End If
'    End If
'    With Fact
'    .N° = "STOP "
'        .j = ""
'        .m = ""
'        .a = ""
'        .CptTiers = ""
'        .NomTiers = ""
'        .LibProduit = ""
'        .CptProduit = ""
'        .ActProduit = ""
'        .CodeTVA = ""
'        .U1 = ""
'        .U2 = ""
'        .Qt2 = ""
'        .Qt1 = ""
'        .MHT = ""
'        .MTVA = ""
'        .Avoir = " "
'    .fin = String(156, "_")
'        Fact.DC = "*"
'        Fact.Rt = Chr(13) & Chr(10)
'    End With
'    Put #1, nb + 1, Fact
'Close #1
'    On Error Resume Next
'    MkDir(App.Path & "\ExportCompta")
'    FileCopy(strCheminExportCompta & "\ExportBo", App.Path & "\ExportCompta\Exp" & Cpl(Day(DtFactureDeb.Value), "0", 2) & Cpl(Month(DtFactureDeb.Value), "0", 2) & Cpl(Day(DtFactureFin.Value), "0", 2) & Cpl(Month(DtFactureFin.Value), "0", 2))
'    MsgBox("Export Terminé")
'    Unload(Me)
'fin:
'End Sub
#End Region