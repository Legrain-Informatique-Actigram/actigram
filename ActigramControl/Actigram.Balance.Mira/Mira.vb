Public Enum DetailJournalLigne
    HRSP = 0
    HCode = 1
    HControl = 6
    HDepartement = 10
    HScaleNumber = 14
    RecordType = 16
    nTicket = 19
    DateTicket = 23
    TimeTicket = 29
    Departement = 33
    ScaleNumber = 37
    OperatorNumber = 39
    BookingCancel = 41
    BookingType = 42
    PriceType = 43
    PluNumber = 44
    Quantite = 50
    Montant = 61
    Margin = 72
End Enum

Public Enum DetailJournalTotal
    HRSP = 0
    HCode = 1
    HControl = 6
    HDepartement = 10
    HScaleNumber = 14
    RecordType = 16
    nTicket = 19
    DateTicket = 23
    TimeTicket = 29
    Departement = 33
    ScaleNumber = 37
    OperatorNumber = 39
    BookingCancel = 41
    TypeOfSale = 42
    NumberOfEntrie = 43
    TotalWeight = 54
    TotalMontant = 65
    TotalMarge = 77
End Enum

Public Enum DetailJournalTVA
    HRSP = 0
    HCode = 1
    HControl = 6
    HDepartement = 10
    HScaleNumber = 14
    RecordType = 16
    nTicket = 19
    DateTicket = 23
    TimeTicket = 29
    Departement = 33
    ScaleNumber = 37
    OperatorNumber = 39
    BookingCancel = 41
    TVANumber = 42
    TVASales = 44
End Enum


'* Lecture Detail Ticket
Public Class AnalyseTrame512
    Public nDep As Object = DBNull.Value
    Public nBal As Object = DBNull.Value
    Public TypeTrame As Object = DBNull.Value
    Public nTicket As Object = DBNull.Value
    Public dtTicket As Object = DBNull.Value
    Public TimeTicket As Object = DBNull.Value
    Public Vendeur As Object = DBNull.Value
    Public BookingCancel As Object = DBNull.Value
    Public BookingType As Object = DBNull.Value
    Public PriceType As Object = DBNull.Value
    Public Plu As Object = DBNull.Value
    Public Quantite As Object = DBNull.Value
    Public Montant As Object = DBNull.Value
    Public Margin As Object = DBNull.Value
    Public TypeVente As Object = DBNull.Value
    Public NombreEntre As Object = DBNull.Value
    Public TotalPoids As Object = DBNull.Value
    Public TotalMontant As Object = DBNull.Value
    Public TotalMargin As Object = DBNull.Value
    Public TVANumber As Object = DBNull.Value
    Public TVAVentes As Object = DBNull.Value

    Public Function AnalyseTrame(ByVal strTrame As String) As Boolean
        Dim TypeTrame As Integer = CInt(strTrame.Substring(DetailJournalLigne.RecordType, 3))
        Select Case TypeTrame
            Case Is < 3
                nDep = strTrame.Substring(DetailJournalLigne.Departement, 4)
                nBal = strTrame.Substring(DetailJournalLigne.ScaleNumber, 2)
                Me.nTicket = strTrame.Substring(DetailJournalLigne.nTicket, 4)
                Me.dtTicket = CDate(strTrame.Substring(DetailJournalLigne.DateTicket, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 2, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 4, 2))
                Me.TimeTicket = strTrame.Substring(DetailJournalLigne.TimeTicket, 2) & ":" & strTrame.Substring(DetailJournalLigne.TimeTicket + 2, 2)
                Me.Vendeur = strTrame.Substring(DetailJournalLigne.OperatorNumber, 2)
                Me.BookingCancel = strTrame.Substring(DetailJournalLigne.BookingCancel, 1)
                Me.BookingType = strTrame.Substring(DetailJournalLigne.BookingType, 1)
                Me.PriceType = strTrame.Substring(DetailJournalLigne.PriceType, 1)
                Me.Plu = Convert.ToInt32(strTrame.Substring(DetailJournalLigne.PluNumber, 6))
                Me.Quantite = strTrame.Substring(DetailJournalLigne.Quantite, 11)
                Me.Montant = strTrame.Substring(DetailJournalLigne.Montant, 11)
                Me.Margin = strTrame.Substring(DetailJournalLigne.Margin, 11)
            Case 3
                nDep = strTrame.Substring(DetailJournalTotal.Departement, 4)
                nBal = strTrame.Substring(DetailJournalTotal.ScaleNumber, 2)
                Me.nTicket = strTrame.Substring(DetailJournalTotal.nTicket, 4)
                Me.dtTicket = CDate(strTrame.Substring(DetailJournalTotal.DateTicket, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 2, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 4, 2))
                Me.TimeTicket = strTrame.Substring(DetailJournalTotal.TimeTicket, 2) & ":" & strTrame.Substring(DetailJournalTotal.TimeTicket + 2, 2)
                Me.Vendeur = strTrame.Substring(DetailJournalTotal.OperatorNumber, 2)
                Me.BookingCancel = strTrame.Substring(DetailJournalTotal.BookingCancel, 1)
                Me.TypeVente = strTrame.Substring(DetailJournalTotal.TypeOfSale, 1)
                Me.NombreEntre = strTrame.Substring(DetailJournalTotal.NumberOfEntrie, 1)
                Me.TotalPoids = strTrame.Substring(DetailJournalTotal.TotalWeight, 6)
                Me.TotalMontant = strTrame.Substring(DetailJournalTotal.TotalMontant, 11)
                Me.TotalMargin = strTrame.Substring(DetailJournalTotal.TotalMontant, 11)
            Case 6
                nDep = strTrame.Substring(DetailJournalTVA.Departement, 4)
                nBal = strTrame.Substring(DetailJournalTVA.ScaleNumber, 2)
                Me.nTicket = strTrame.Substring(DetailJournalTVA.nTicket, 4)
                Me.dtTicket = CDate(strTrame.Substring(DetailJournalTVA.DateTicket, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 2, 2) & "/" & strTrame.Substring(DetailJournalLigne.DateTicket + 4, 2))
                Me.TimeTicket = strTrame.Substring(DetailJournalTVA.TimeTicket, 2) & ":" & strTrame.Substring(DetailJournalTVA.TimeTicket + 2, 2)
                Me.Vendeur = strTrame.Substring(DetailJournalTVA.OperatorNumber, 2)
                Me.BookingCancel = strTrame.Substring(DetailJournalTVA.BookingCancel, 1)
                Me.TVANumber = strTrame.Substring(DetailJournalTVA.TVANumber, 2)
                Me.TVAVentes = strTrame.Substring(DetailJournalTVA.TVASales, 11)
        End Select
        Return True
    End Function
End Class

Public Enum ArticleData
    Cmd = 0
    Code = 1
    Control = 6
    Departement = 10
    Balance = 14
    Plu = 16
    EAN = 22
    Description = 35
    PrixVente1 = 135
    PrixVente2 = 143
    nTVA = 151
    PrixAchat = 153
    OffreSpecial = 161
    PrixMin = 165
    PrixMax = 173
    PoidsMin = 181
    PoidsMax = 189
    nGroupe = 197
    nTare = 201
    ArticleFlag = 203
    RedYellowLimit = 207
    YellowGreenLimit = 210
    ProductText = 213
End Enum

Public Enum GroupData
    Cmd = 0
    Code = 1
    Control = 6
    Departement = 10
    Balance = 14
    nGroupe = 16
    Description = 20
    nMainGroup = 40
End Enum

Public Enum ArticleDataAction
    Write = 0
    Delete = 1
    ReadEqual = 2
    ReadAll = 7
End Enum

Public Enum ArticleDataProductText
    Without = 0
    DisplayOnly = 1
    DisplayAndPrint = 10
End Enum

Public Enum ArticleDateTrafficLight
    Without = 0
    green = 1
    red = 10
    dependingOnMargin = 11
End Enum

'* Lecture, Suppression, Modification Famille
Public Class AnalyseTrame210
    Private _Cmd As String = "0"
    Private _TypeCommande As ArticleDataAction = ArticleDataAction.ReadEqual
    Private _Code As String = "00210"
    Private _Control As String
    Private _CompareBase As Boolean = False
    Private _DataEqual As Boolean
    Private _nDep As String = "1"
    Private _nBal As String = "0"
    Private _nGroupe As String = "0000"
    Private _Description As String = ""
    Private _nMainGroupe As String = "0000"

#Region "Propriété"

    Public Property Cmd() As String
        Get
            Return _Cmd
        End Get
        Set(ByVal Value As String)
            _Cmd = Value
        End Set
    End Property

    Public Property TypeCommande() As ArticleDataAction
        Get
            Return _TypeCommande
        End Get
        Set(ByVal Value As ArticleDataAction)
            _TypeCommande = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal Value As String)
            _Code = Value
        End Set
    End Property

    Public Property nDep() As String
        Get
            Return _nDep
        End Get
        Set(ByVal Value As String)
            _nDep = Value
        End Set
    End Property

    Public Property nBal() As String
        Get
            Return _nBal
        End Get
        Set(ByVal Value As String)
            _nBal = Value
        End Set
    End Property

    Public Property CompareBase() As Boolean
        Get
            Return _CompareBase
        End Get
        Set(ByVal Value As Boolean)
            _CompareBase = Value
        End Set
    End Property

    Public Property DataEqual() As Boolean
        Get
            Return _DataEqual
        End Get
        Set(ByVal Value As Boolean)
            _DataEqual = Value
        End Set
    End Property

    Public Property nGroupe() As String
        Get
            Return _nGroupe
        End Get
        Set(ByVal Value As String)
            _nGroupe = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal Value As String)
            _Description = Value
        End Set
    End Property

    Public Property nMainGroupe() As String
        Get
            Return _nMainGroupe
        End Get
        Set(ByVal Value As String)
            _nMainGroupe = Value
        End Set
    End Property

#End Region

    Public Function GetTrame() As String
        Dim strtrame As String
        strtrame = "0"
        strtrame += _Code.PadLeft(5, "0")
        GetControl()
        strtrame += _Control
        strtrame += _nDep.PadLeft(4, "0")
        strtrame += "0".PadLeft(2, "0")
        strtrame += _nGroupe.PadLeft(4, "0")
        If _TypeCommande <> ArticleDataAction.Write Then
        Else
            strtrame += _Description.PadRight(20, " ")
            strtrame += _nMainGroupe.PadLeft(4, "0")
        End If
        Return strtrame
    End Function

    Private Sub GetControl()
        _Control = "0"
        If _CompareBase = True Then
            _Control += "2"
        Else
            _Control += "0"
        End If
        _Control += "0"
        _Control += Convert.ToInt32(_TypeCommande).ToString
    End Sub

    Public Function AnalyseTrame(ByVal strTrame As String) As Boolean
        If strTrame.Length = 44 Then
            _Cmd = strTrame.Substring(GroupData.Cmd, 1)
            _Code = strTrame.Substring(GroupData.Code, 5)
            If Convert.ToInt32(_Code) <> 210 Then Return False
            _Control = strTrame.Substring(GroupData.Control, 4)
            If _Control.Substring(1, 1) = "2" Then
                _DataEqual = True
            ElseIf _Control.Substring(1, 1) = "F" Then
                _DataEqual = False
            End If
            _nDep = Convert.ToInt32(strTrame.Substring(GroupData.Departement, 4))
            _nBal = Convert.ToInt32(strTrame.Substring(GroupData.Balance, 2))
            _nGroupe = Convert.ToInt32(strTrame.Substring(GroupData.nGroupe, 4))
            _Description = strTrame.Substring(GroupData.Description, 20).Trim
            _nMainGroupe = strTrame.Substring(GroupData.nMainGroup, 4)
        End If
    End Function

End Class

'* Lecture,Suppression,Modification PLU
Public Class AnalyseTrame207
    Private _Cmd As String = "0"
    Private _TypeCommande As ArticleDataAction = ArticleDataAction.ReadEqual
    Private _Code As String = "00207"
    Private _Control As String
    Private _CompareBase As Boolean = False
    Private _DataEqual As Boolean
    Private _nDep As String = "1"
    Private _nBal As String = "0"
    Private _nPlu As String = "0"
    Private _EAN As String = "0"
    Private _Description As String = ""
    Private _PrixVente1 As String = "0"
    Private _PrixVente2 As String = "0"
    Private _nTVA As String = "0"
    Private _PrixAchat As String = "0"
    Private _OffreSpecial As String = "0"
    Private _PrixMin As String = "0"
    Private _PrixMax As String = "0"
    Private _PoidsMin As String = "0"
    Private _PoidsMax As String = "0"
    Private _nGroupe As String = "0"
    Private _nTare As String = "0"
    Private _ArticleFlag As String
    Private _TypePrixPiece As Boolean = False
    Private _PriceOverwrite As Boolean = False
    Private _BlockArticle As Boolean = False
    Private _EnableDiscount As Boolean = False
    Private _TrafficLight As ArticleDateTrafficLight = ArticleDateTrafficLight.Without
    Private _ProductText As ArticleDataProductText = ArticleDataProductText.Without
    Private _RedYellowLimit As String = "0"
    Private _YellowGreenLimit As String = "0"
    Private _ProductTextNum As String = "0"

#Region "Propriété"
    Public Property Cmd() As String
        Get
            Return _Cmd
        End Get
        Set(ByVal Value As String)
            _Cmd = Value
        End Set
    End Property

    Public Property TypeCommande() As ArticleDataAction
        Get
            Return _TypeCommande
        End Get
        Set(ByVal Value As ArticleDataAction)
            _TypeCommande = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal Value As String)
            _Code = Value
        End Set
    End Property

    Public Property nDep() As String
        Get
            Return _nDep
        End Get
        Set(ByVal Value As String)
            _nDep = Value
        End Set
    End Property

    Public Property nBal() As String
        Get
            Return _nBal
        End Get
        Set(ByVal Value As String)
            _nBal = Value
        End Set
    End Property

    Public Property CompareBase() As Boolean
        Get
            Return _CompareBase
        End Get
        Set(ByVal Value As Boolean)
            _CompareBase = Value
        End Set
    End Property

    Public Property DataEqual() As Boolean
        Get
            Return _DataEqual
        End Get
        Set(ByVal Value As Boolean)
            _DataEqual = Value
        End Set
    End Property

    Public Property nPlu() As String
        Get
            Return _nPlu
        End Get
        Set(ByVal Value As String)
            _nPlu = Value
        End Set
    End Property

    Public Property EAN() As String
        Get
            Return _EAN
        End Get
        Set(ByVal Value As String)
            _EAN = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal Value As String)
            _Description = Value
        End Set
    End Property

    Public Property nTVA() As String
        Get
            Return _nTVA
        End Get
        Set(ByVal Value As String)
            _nTVA = Value
        End Set
    End Property

    Public Property OffreSpecial() As String
        Get
            Return _OffreSpecial
        End Get
        Set(ByVal Value As String)
            _OffreSpecial = Value
        End Set
    End Property

    Public Property nGroupe() As String
        Get
            Return _nGroupe
        End Get
        Set(ByVal Value As String)
            _nGroupe = Value
        End Set
    End Property

    Public Property nTare() As String
        Get
            Return _nTare
        End Get
        Set(ByVal Value As String)
            _nTare = Value
        End Set
    End Property

    Public Property TypePrixPiece() As Boolean
        Get
            Return _TypePrixPiece
        End Get
        Set(ByVal Value As Boolean)
            _TypePrixPiece = Value
        End Set
    End Property

    Public Property PriceOverWrite() As Boolean
        Get
            Return _PriceOverwrite
        End Get
        Set(ByVal Value As Boolean)
            _PriceOverwrite = Value
        End Set
    End Property

    Public Property BlockArticle() As Boolean
        Get
            Return _BlockArticle
        End Get
        Set(ByVal Value As Boolean)
            _BlockArticle = Value
        End Set
    End Property

    Public Property TrafficLight() As ArticleDateTrafficLight
        Get
            Return _TrafficLight
        End Get
        Set(ByVal Value As ArticleDateTrafficLight)
            _TrafficLight = Value
        End Set
    End Property

    Public Property ProductText() As ArticleDataProductText
        Get
            Return _ProductText
        End Get
        Set(ByVal Value As ArticleDataProductText)
            _ProductText = Value
        End Set
    End Property

    Public Property RedYellowLimit() As String
        Get
            Return _RedYellowLimit
        End Get
        Set(ByVal Value As String)
            _RedYellowLimit = Value
        End Set
    End Property

    Public Property YellowGreenLimit() As String
        Get
            Return _YellowGreenLimit
        End Get
        Set(ByVal Value As String)
            _YellowGreenLimit = Value
        End Set
    End Property

    Public Property ProductTextNum() As String
        Get
            Return _ProductTextNum
        End Get
        Set(ByVal Value As String)
            _ProductTextNum = Value
        End Set
    End Property

    Public Property PrixVente1() As Decimal
        Get
            Return Convert.ToInt32(_PrixVente1) / 100
        End Get
        Set(ByVal Value As Decimal)
            _PrixVente1 = Convert.ToInt32(Value * 100)
        End Set
    End Property

    Public Property PrixVente2() As Decimal
        Get
            Return Convert.ToInt32(_PrixVente2) / 100
        End Get
        Set(ByVal Value As Decimal)
            _PrixVente2 = Convert.ToInt32(Value * 100)
        End Set
    End Property

    Public Property PrixAchat() As Decimal
        Get
            Return Convert.ToInt32(_PrixAchat) / 100
        End Get
        Set(ByVal Value As Decimal)
            _PrixAchat = Convert.ToInt32(Value * 100)
        End Set
    End Property

    Public Property PrixMin() As Decimal
        Get
            Return Convert.ToInt32(_PrixMin) / 100
        End Get
        Set(ByVal Value As Decimal)
            _PrixMin = Convert.ToInt32(Value * 100)
        End Set
    End Property

    Public Property PrixMax() As Decimal
        Get
            Return Convert.ToInt32(_PrixMax) / 100
        End Get
        Set(ByVal Value As Decimal)
            _PrixMax = Convert.ToInt32(Value * 100)
        End Set
    End Property
#End Region

    Public Function GetTrame() As String
        Dim strtrame As String
        strtrame = _Cmd.PadLeft(1, "0")
        strtrame += _Code.PadLeft(5, "0")
        GetControl()
        strtrame += _Control
        strtrame += _nDep.PadLeft(4, "0")
        strtrame += "0".PadLeft(2, "0")
        strtrame += _nPlu.PadLeft(6, "0")
        If _TypeCommande = ArticleDataAction.Delete Then
            strtrame += "".PadLeft(13, " ")
            strtrame += "".PadRight(10, " ")
        ElseIf _TypeCommande <> ArticleDataAction.Write Then
            strtrame += _EAN.PadLeft(13, "0")
            strtrame += _Description.PadRight(10, " ")
        Else
            strtrame += _EAN.PadLeft(13, "0")
            strtrame += _Description.PadRight(100, " ")
            strtrame += _PrixVente1.PadLeft(8, "0")
            strtrame += _PrixVente2.PadLeft(8, "0")
            strtrame += _nTVA.PadRight(2, "0")
            strtrame += _PrixAchat.PadLeft(8, "0")
            strtrame += _OffreSpecial.PadLeft(4, "0")
            strtrame += _PrixMin.PadLeft(8, "0")
            strtrame += _PrixMax.PadLeft(8, "0")
            strtrame += _PoidsMin.PadLeft(8, "0")
            strtrame += _PoidsMax.PadLeft(8, "0")
            strtrame += _nGroupe.PadLeft(4, "0")
            strtrame += _nTare.PadLeft(2, "0")
            GetArticleFlag()
            strtrame += _ArticleFlag.PadLeft(4, "0")
            strtrame += _RedYellowLimit.PadLeft(3, "0")
            strtrame += _YellowGreenLimit.PadLeft(3, "0")
            strtrame += _ProductTextNum.PadLeft(3, "0")
        End If
        Return strtrame
    End Function

    Private Sub GetArticleFlag()
        Dim strBitFlag As String = ""
        strBitFlag = Convert.ToInt32(_TypePrixPiece).ToString + strBitFlag
        strBitFlag = Convert.ToInt32(_PriceOverwrite).ToString + strBitFlag
        strBitFlag = "00" + strBitFlag
        strBitFlag = Convert.ToInt32(_BlockArticle).ToString + strBitFlag
        strBitFlag = Convert.ToInt32(_EnableDiscount).ToString + strBitFlag
        strBitFlag = "00" + strBitFlag
        strBitFlag = Convert.ToInt32(_TrafficLight).ToString.PadLeft(2, "0") + strBitFlag
        strBitFlag = Convert.ToInt32(_ProductText).ToString.PadLeft(2, "0") + strBitFlag
        strBitFlag = "0000" + strBitFlag

        _ArticleFlag = Hex(Actigram.Binaire.Binaire.CBinDec(strBitFlag)).PadLeft(4, "0")

    End Sub

    Private Sub GetControl()
        _Control = "0"
        If _CompareBase = True Then
            _Control += "2"
        Else
            _Control += "0"
        End If
        _Control += "0"
        _Control += Convert.ToInt32(_TypeCommande).ToString
    End Sub

    Public Function AnalyseTrame(ByVal strTrame As String) As Boolean
        If strTrame.Length = 216 Then
            _Cmd = strTrame.Substring(ArticleData.Cmd, 1)
            _Code = strTrame.Substring(ArticleData.Code, 5)
            If Convert.ToInt32(_Code) <> 207 Then Return False
            _Control = strTrame.Substring(ArticleData.Control, 4)
            If _Control.Substring(1, 1) = "2" Then
                _DataEqual = True
            ElseIf _Control.Substring(1, 1) = "F" Then
                _DataEqual = False
            End If
            _nDep = Convert.ToInt32(strTrame.Substring(ArticleData.Departement, 4))
            _nBal = Convert.ToInt32(strTrame.Substring(ArticleData.Balance, 2))
            _nPlu = Convert.ToInt32(strTrame.Substring(ArticleData.Plu, 6))
            _EAN = strTrame.Substring(ArticleData.EAN, 13)
            _Description = strTrame.Substring(ArticleData.Description, 100).Trim
            _PrixVente1 = Convert.ToInt32(strTrame.Substring(ArticleData.PrixVente1, 8))
            _PrixVente2 = Convert.ToInt32(strTrame.Substring(ArticleData.PrixVente2, 8))
            _nTVA = Convert.ToInt32(strTrame.Substring(ArticleData.nTVA, 1))
            _PrixAchat = Convert.ToInt32(strTrame.Substring(ArticleData.PrixAchat, 8))
            _OffreSpecial = strTrame.Substring(ArticleData.OffreSpecial, 4)
            _PrixMin = Convert.ToInt32(strTrame.Substring(ArticleData.PrixMin, 8))
            _PrixMax = Convert.ToInt32(strTrame.Substring(ArticleData.PrixMax, 8))
            _PoidsMin = Convert.ToInt32(strTrame.Substring(ArticleData.PoidsMin, 8))
            _PoidsMax = Convert.ToInt32(strTrame.Substring(ArticleData.PoidsMax, 8))
            _nGroupe = Convert.ToInt32(strTrame.Substring(ArticleData.nGroupe, 4))
            _nTare = Convert.ToInt32(strTrame.Substring(ArticleData.nTare, 2))
            _ArticleFlag = strTrame.Substring(ArticleData.ArticleFlag, 4)
            AnalyseArticleFlag(_ArticleFlag)
            _RedYellowLimit = strTrame.Substring(ArticleData.RedYellowLimit, 3)
            _YellowGreenLimit = strTrame.Substring(ArticleData.YellowGreenLimit, 3)
            _ProductTextNum = strTrame.Substring(ArticleData.ProductText, 1)
        End If
    End Function

    Private Sub AnalyseArticleFlag(ByVal strFlag As String)
        Dim Flag As String = Actigram.Binaire.Binaire.CBin(Actigram.Binaire.Binaire.CHexDec(strFlag)).PadLeft(16, "0")

        Me._TypePrixPiece = Flag.Substring(15, 1)
        Me._PriceOverwrite = Flag.Substring(14, 1)
        Me._BlockArticle = Flag.Substring(11, 1)
        Me._EnableDiscount = Flag.Substring(10, 1)
        Me._TrafficLight = Convert.ToInt32(Flag.Substring(7, 1) & Flag.Substring(6, 1))
        Me._ProductText = Convert.ToInt32(Flag.Substring(5, 1) & Flag.Substring(4, 1))
    End Sub

End Class

Public Enum TVAData
    Cmd = 0
    Code = 1
    Control = 6
    Departement = 10
    Balance = 14
    nTVA = 16
    TxTVA = 18
End Enum

Public Class AnalyseTrame218
    Private _Cmd As String = "0"
    Private _TypeCommande As ArticleDataAction = ArticleDataAction.ReadEqual
    Private _Code As String = "00218"
    Private _Control As String
    Private _CompareBase As Boolean = False
    Private _DataEqual As Boolean
    Private _nDep As String = "1"
    Private _nBal As String = "0"
    Private _nTVA As String = "0"
    Private _TxTVA As String = "0"

#Region "Propriété"
    Public Property Cmd() As String
        Get
            Return _Cmd
        End Get
        Set(ByVal Value As String)
            _Cmd = Value
        End Set
    End Property

    Public Property TypeCommande() As ArticleDataAction
        Get
            Return _TypeCommande
        End Get
        Set(ByVal Value As ArticleDataAction)
            _TypeCommande = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal Value As String)
            _Code = Value
        End Set
    End Property

    Public Property nDep() As String
        Get
            Return _nDep
        End Get
        Set(ByVal Value As String)
            _nDep = Value
        End Set
    End Property

    Public Property nBal() As String
        Get
            Return _nBal
        End Get
        Set(ByVal Value As String)
            _nBal = Value
        End Set
    End Property

    Public Property CompareBase() As Boolean
        Get
            Return _CompareBase
        End Get
        Set(ByVal Value As Boolean)
            _CompareBase = Value
        End Set
    End Property

    Public Property DataEqual() As Boolean
        Get
            Return _DataEqual
        End Get
        Set(ByVal Value As Boolean)
            _DataEqual = Value
        End Set
    End Property

    Public Property nTVA() As String
        Get
            Return _nTVA
        End Get
        Set(ByVal Value As String)
            _nTVA = Value
        End Set
    End Property

    Public Property TxTVA() As Decimal
        Get
            Return Convert.ToInt32(_TxTVA) / 100
        End Get
        Set(ByVal Value As Decimal)
            _TxTVA = Convert.ToInt32(Value * 100)
        End Set
    End Property
#End Region

    Private Sub GetControl()
        _Control = "0"
        If _CompareBase = True Then
            _Control += "2"
        Else
            _Control += "0"
        End If
        _Control += "0"
        _Control += Convert.ToInt32(_TypeCommande).ToString
    End Sub

    Public Function GetTrame() As String
        Dim strtrame As String
        strtrame = "0"
        strtrame += _Code.PadLeft(5, "0")
        GetControl()
        strtrame += _Control
        strtrame += _nDep.PadLeft(4, "0")
        strtrame += "0".PadLeft(2, "0")
        strtrame += _nTVA.PadLeft(2, "0")
        If _TypeCommande <> ArticleDataAction.Write Then
        Else
            strtrame += _TxTVA.PadLeft(4, "0")
        End If
        Return strtrame
    End Function

    Public Function AnalyseTrame(ByVal strTrame As String) As Boolean
        If strTrame.Length = 22 Then
            _Cmd = strTrame.Substring(ArticleData.Cmd, 1)
            _Code = strTrame.Substring(ArticleData.Code, 5)
            If Convert.ToInt32(_Code) <> 207 Then Return False
            _Control = strTrame.Substring(ArticleData.Control, 4)
            If _Control.Substring(1, 1) = "2" Then
                _DataEqual = True
            ElseIf _Control.Substring(1, 1) = "F" Then
                _DataEqual = False
            End If
            _nDep = Convert.ToInt32(strTrame.Substring(ArticleData.Departement, 4))
            _nBal = Convert.ToInt32(strTrame.Substring(ArticleData.Balance, 2))
            _nTVA = Convert.ToInt32(strTrame.Substring(TVAData.nTVA, 2))
            _TxTVA = Convert.ToInt32(strTrame.Substring(TVAData.TxTVA, 4))
        End If
    End Function


End Class

Public Class GestionMira
    Dim strDirectory As String = "C:\Transl2"
    Dim strFileIn As String = strDirectory & "\In.txt"
    Dim strFileOut As String = strDirectory & "\Out.txt"
    Dim strTxBalance As String = ""
    Dim strRxBalance As String = ""

    Dim dtTrame As DataTable
    Dim dtTrameVerif As DataTable
    Dim dtProduit As DataTable
    Dim dtGroupe As DataTable
    Dim dtTVA As DataTable

    Dim CodeDemande As Integer = 0
    Dim Rayon As Integer = 1
    Dim Balance As Integer = 1
    Dim PriceOverWrite As Boolean = False

    Public Event RecptionTerminee(ByVal OkFin As Boolean, ByVal Erreur As String)
    Public Event ReceptionProgressed(ByVal sender As Object, ByVal progressPercentage As Integer)

    Private Sub ReportProgress(ByVal value As Integer, ByVal max As Integer)
        RaiseEvent ReceptionProgressed(Me, value * 100 \ max)
    End Sub

#Region "Props"
    Public Property TableTVA() As DataTable
        Get
            Return dtTVA
        End Get
        Set(ByVal Value As DataTable)
            dtTVA = Value
        End Set
    End Property

    Public Property nBalance() As Integer
        Get
            Return Balance
        End Get
        Set(ByVal Value As Integer)
            Balance = Value
        End Set
    End Property

    Public Property FileIn() As String
        Get
            Return strFileIn
        End Get
        Set(ByVal Value As String)
            strFileIn = Value
        End Set
    End Property

    Public Property FileOut() As String
        Get
            Return strFileOut
        End Get
        Set(ByVal Value As String)
            strFileOut = Value
        End Set
    End Property

    Public Sub GetFileOutDefault()
        strFileOut = strDirectory & "\Out.txt"
    End Sub

    Public Sub GetFileInDefault()
        strFileIn = strDirectory & "\In.txt"
    End Sub

    Public Property TableTrame() As DataTable
        Get
            Return dtTrame
        End Get
        Set(ByVal Value As DataTable)
            dtTrame = Value
        End Set
    End Property

    Public Property TableTrameVerif() As DataTable
        Get
            Return dtTrameVerif
        End Get
        Set(ByVal Value As DataTable)
            dtTrameVerif = Value
        End Set
    End Property

    Public Property TableProduit() As DataTable
        Get
            Return dtProduit
        End Get
        Set(ByVal Value As DataTable)
            dtProduit = Value
        End Set
    End Property

    Public Property TableGroupe() As DataTable
        Get
            Return dtGroupe
        End Get
        Set(ByVal Value As DataTable)
            dtGroupe = Value
        End Set
    End Property
#End Region

    Private Function MajFamille(ByVal rw As DataRow) As AnalyseTrame210
        Dim tr As New AnalyseTrame210
        tr.nDep = Me.Rayon
        tr.nBal = Me.Balance
        tr.nGroupe = rw.Item("nFamille")
        tr.Description = rw.Item("Famille")
        If Not rw.Item("nGroupe") Is DBNull.Value Then
            tr.nMainGroupe = rw.Item("nGroupe")
        End If

        Return tr
    End Function

    Private Function MajProduit(ByVal rw As DataRow, Optional ByVal PriceOverWrite As Boolean = False) As AnalyseTrame207
        Dim tr As New AnalyseTrame207
        tr.nDep = Me.Rayon
        tr.nBal = Me.Balance
        tr.nPlu = rw.Item("CodeProduit")
        tr.PriceOverWrite = PriceOverWrite
        If rw.Table.Columns.Contains("CodeBarre") Then
            tr.EAN = Convert.ToString(rw.Item("CodeBarre"))
        End If
        tr.Description = rw.Item("Libelle")
        If Not rw.Item("PrixVTTC") Is DBNull.Value Then
            tr.PrixVente1 = rw.Item("PrixVTTC")
        End If
        If rw.Table.Columns.Contains("PrixVTTC2") Then
            If Not rw.Item("PrixVTTC2") Is DBNull.Value Then
                tr.PrixVente2 = rw.Item("PrixVTTC2")
            End If
        End If
        If dtTVA.Select("TTVA='" & Convert.ToString(rw.Item("TTVA")) & "'").GetUpperBound(0) >= 0 Then
            tr.nTVA = dtTVA.Select("TTVA='" & Convert.ToString(rw.Item("TTVA")) & "'")(0).Item("nTVA")
        End If
        If Not rw.Item("Famille1") Is DBNull.Value Then
            tr.nGroupe = rw.Item("Famille1")
        End If
        If rw.Table.Columns.Contains("nTare") Then
            tr.nTare = rw.Item("nTare")
        End If
        If Convert.ToString(rw.Item("Unite1")) = "P" Then
            tr.TypePrixPiece = True
        Else
            tr.TypePrixPiece = False
        End If
        'If rw.Table.Columns.Contains("TypePrixPiece") Then
        '    If Convert.ToBoolean(rw.Item("TypePrixPiece")) = True Then
        '        tr._TypePrixPiece = True
        '    Else
        '        tr._TypePrixPiece = False
        '    End If
        'End If
        '*Fin250205
        If rw.Table.Columns.Contains("PrixModifiable") Then
            'If Convert.tob Then
            'End If
        End If
        Return tr

    End Function

    Public Sub RecupDetailVentes(ByVal dt As Date, Optional ByVal DepuisFichier As Boolean = False)
        If DepuisFichier = False Then
            Dim tr As New MiraTrame
            Dim dtDepart As String = dt.ToString("ddMMyy")
            Dim nTDepart As String = "0000"
            Dim nTFin As String = "9999"
            tr.AccessCode = "512"
            tr.Dpt = Me.Rayon
            tr.Scale = 0
            strTxBalance = tr.GetHeader & dtDepart & nTDepart & nTFin & vbCrLf
            CodeDemande = 512
            DemandeInfoBalance()
        Else
            CodeDemande = 512
            AnalyseResultat()
        End If
    End Sub

    Public Sub VerifFamille(Optional ByVal DepuisFichier As Boolean = False)
        If DepuisFichier = False Then
            Dim tr As New Mira.AnalyseTrame210
            tr.TypeCommande = ArticleDataAction.ReadAll
            strTxBalance = tr.GetTrame
            CodeDemande = 210
            DemandeInfoBalance()
        Else
            CodeDemande = 210
            AnalyseResultat()
        End If
    End Sub

    Public Sub UpDateBalanceFamille(ByRef dtBalance As DataTable, ByVal dtOrdi As DataTable)
        Dim dt As New DataTable
        dt.Columns.Add("EnvoiBalance", GetType(Boolean)).DefaultValue = True
        dt.Columns.Add("RecupBalance", GetType(Boolean)).DefaultValue = False
        dt.Columns.Add("nPLU")
        dt.Columns.Add("Libelle")
        dt.Columns.Add("PrixOrdi", GetType(String))
        dt.Columns.Add("PrixBalance", GetType(String))
        dt.Columns.Add("TrameEnvoiBalance")


        strTxBalance = ""
        Dim rw As DataRow
        For Each rw In dtOrdi.Rows
            Dim EnvoiLigne As Boolean = False

            Dim rws() As DataRow = dtBalance.Select("nFamille=" & rw.Item("nFamille"), "", DataViewRowState.CurrentRows)
            If rws.GetUpperBound(0) >= 0 Then
                If Convert.ToString(rws(0).Item("Famille")) <> Convert.ToString(rw.Item("Famille")) Then
                    EnvoiLigne = True
                End If
            Else
                EnvoiLigne = True
            End If
            If EnvoiLigne = True Then
                Dim tr As New Mira.AnalyseTrame210
                tr.TypeCommande = ArticleDataAction.Write
                tr.nGroupe = rw.Item("nFamille")
                tr.Description = rw.Item("Famille")
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += tr.GetTrame

                Dim rwInfo As DataRow = dt.NewRow
                rwInfo.Item("nPLU") = rw.Item("nFamille")
                rwInfo.Item("Libelle") = rw.Item("Famille")
                rwInfo.Item("PrixOrdi") = "Ordi"
                If rws.GetUpperBound(0) >= 0 Then
                    rwInfo.Item("PrixBalance") = "Balance"
                End If
                rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
                dt.Rows.Add(rwInfo)

            End If
        Next

        dt.Columns("EnvoiBalance").DefaultValue = False
        dt.Columns("RecupBalance").DefaultValue = True

        For Each rw In dtBalance.Select("", "", DataViewRowState.CurrentRows)
            'Dim EnvoiLigne As Boolean = False

            Dim rws() As DataRow = dtOrdi.Select("nFamille=" & rw.Item("nFamille"), "", DataViewRowState.CurrentRows)
            If rws.GetUpperBound(0) < 0 Then
                Dim tr As AnalyseTrame210 = MajFamille(rw)
                tr.TypeCommande = ArticleDataAction.Delete

                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += tr.GetTrame

                Dim rwInfo As DataRow = dt.NewRow
                rwInfo.Item("nPLU") = rw.Item("nFamille")
                rwInfo.Item("Libelle") = rw.Item("Famille")
                'rwInfo.Item("PrixOrdi") = rw.Item("PrixVTTC")
                rwInfo.Item("PrixBalance") = "Balance"
                rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
                dt.Rows.Add(rwInfo)
            End If
        Next


        CodeDemande = 210

        Dim fr As New FrInfoEnvoiBalance
        fr.TxText.Text = strTxBalance
        fr.dv = New DataView(dt)
        fr.nPLU.HeaderText = "n° Famille"
        fr.Libelle.HeaderText = "Famille"
        If fr.ShowDialog = DialogResult.OK Then
            Dim rwRecupBalance As DataRow
            For Each rwRecupBalance In dt.Select("RecupBalance=" & True, "", DataViewRowState.CurrentRows)
                Dim rwsRecup() As DataRow
                rwsRecup = dtBalance.Select("nFamille=" & rwRecupBalance.Item("nFamille"))
                If rwsRecup.GetUpperBound(0) >= 0 Then
                    Dim rwsOrdi() As DataRow
                    rwsOrdi = dtOrdi.Select("nFamille=" & rwRecupBalance.Item("nFamille"))
                    If rwsOrdi.GetUpperBound(0) >= 0 Then
                        rwsOrdi(0).Item("Famille") = rwsRecup(0).Item("Famille")
                        rwsOrdi(0).Item("nGroupe") = rwsRecup(0).Item("nGroupe")
                    Else
                        Me.dtProduit = dtOrdi
                        Dim tr As AnalyseTrame210 = MajFamille(rwsRecup(0))
                        tr.TypeCommande = ArticleDataAction.Write
                        tr.Cmd = "1"
                        Dim Ok As Boolean
                        Me.AnalyseTrame210(tr.GetTrame, Ok)
                        Me.dtProduit = dtBalance
                    End If
                End If
            Next
            Dim rwEnvoiBalance As DataRow
            strTxBalance = ""
            For Each rwEnvoiBalance In dt.Select("EnvoiBalance=" & True)
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += rwEnvoiBalance.Item("TrameEnvoiBalance")
            Next
            DemandeInfoBalance(False)
        End If

        'Dim fr As New FrInfoEnvoiBalance
        'fr.TxText.Text = strTxBalance
        'If fr.ShowDialog = DialogResult.OK Then
        '    DemandeInfoBalance(False)
        'End If
    End Sub

    Public Sub EnvoiMajFamille(ByVal rws() As DataRow)
        Dim dt As New DataTable
        dt.Columns.Add("EnvoiBalance", GetType(Boolean)).DefaultValue = True
        dt.Columns.Add("RecupBalance", GetType(Boolean)).DefaultValue = False
        dt.Columns.Add("nPLU")
        dt.Columns.Add("Libelle")
        dt.Columns.Add("PrixOrdi", GetType(String))
        dt.Columns.Add("PrixBalance", GetType(String))
        dt.Columns.Add("TrameEnvoiBalance")

        strTxBalance = ""

        Dim rw As DataRow
        For Each rw In rws
            Dim tr As AnalyseTrame210 = MajFamille(rw)
            tr.TypeCommande = ArticleDataAction.Write
            If strTxBalance.Length > 0 Then
                strTxBalance += vbCrLf
            End If
            strTxBalance += tr.GetTrame

            Dim rwInfo As DataRow = dt.NewRow
            rwInfo.Item("nPLU") = rw.Item("nFamille")
            rwInfo.Item("Libelle") = rw.Item("Famille")
            rwInfo.Item("PrixOrdi") = "Ordi"
            If rws.GetUpperBound(0) >= 0 Then
                rwInfo.Item("PrixBalance") = "Balance"
            End If
            rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
            dt.Rows.Add(rwInfo)
        Next


        Dim fr As New FrInfoEnvoiBalance
        fr.TxText.Text = strTxBalance
        fr.dv = New DataView(dt)
        fr.nPLU.HeaderText = "n° Famille"
        fr.Libelle.HeaderText = "Famille"
        fr.PrixOrdi.HeaderText = "Ordi"
        fr.PrixBalance.HeaderText = "Balance"
        If fr.ShowDialog = DialogResult.OK Then
            Dim rwEnvoiBalance As DataRow
            strTxBalance = ""
            For Each rwEnvoiBalance In dt.Select("EnvoiBalance=" & True)
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += rwEnvoiBalance.Item("TrameEnvoiBalance")
            Next
            'Dim fr1 As New FrInfoEnvoiBalance
            'fr1.TxText.Text = strTxBalance
            'fr1.dv = New DataView(dt)
            'If fr1.ShowDialog = DialogResult.OK Then
            DemandeInfoBalance(False)
            'End If
        End If

        'If MessageBox.Show("Voulez-vous envoyer la mise à jour de ce produit sur la balance ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    DemandeInfoBalance(False)
        'End If

    End Sub

    Public Sub EnvoiMajProduit(ByVal drws() As DataRowView, ByVal PriceOverWrite As Boolean)
        Dim rws(drws.Length - 1) As DataRow
        For i As Integer = 0 To drws.Length - 1
            rws(i) = drws(i).Row
        Next
        EnvoiMajProduit(rws, PriceOverWrite)
    End Sub

    Public Sub EnvoiMajProduit(ByVal rws() As DataRow, ByVal PriceOverWrite As Boolean)
        Dim dt As New DataTable
        dt.Columns.Add("EnvoiBalance", GetType(Boolean)).DefaultValue = True
        dt.Columns.Add("RecupBalance", GetType(Boolean)).DefaultValue = False
        dt.Columns.Add("nPLU")
        dt.Columns.Add("Libelle")
        dt.Columns.Add("PrixOrdi", GetType(Decimal))
        dt.Columns.Add("PrixBalance", GetType(Decimal))
        dt.Columns.Add("TrameEnvoiBalance")

        strTxBalance = ""

        For Each rw As DataRow In rws
            Dim tr As AnalyseTrame207 = MajProduit(rw, PriceOverWrite)
            tr.TypeCommande = ArticleDataAction.Write
            If strTxBalance.Length > 0 Then
                strTxBalance += vbCrLf
            End If
            strTxBalance += tr.GetTrame

            Dim rwInfo As DataRow = dt.NewRow
            rwInfo.Item("nPLU") = rw.Item("CodeProduit")
            rwInfo.Item("Libelle") = rw.Item("Libelle")
            rwInfo.Item("PrixOrdi") = rw.Item("PrixVTTC")
            'If rws.GetUpperBound(0) >= 0 Then
            '    rwInfo.Item("PrixBalance") = rws(0).Item("PrixVTTC")
            'End If
            rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
            dt.Rows.Add(rwInfo)
        Next


        Dim fr As New FrInfoEnvoiBalance
        fr.TxText.Text = strTxBalance
        fr.dv = New DataView(dt)
        If fr.ShowDialog = DialogResult.OK Then
            Dim rwEnvoiBalance As DataRow
            strTxBalance = ""
            For Each rwEnvoiBalance In dt.Select("EnvoiBalance=" & True)
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += rwEnvoiBalance.Item("TrameEnvoiBalance")
            Next
            'Dim fr1 As New FrInfoEnvoiBalance
            'fr1.TxText.Text = strTxBalance
            'fr1.dv = New DataView(dt)
            'If fr1.ShowDialog = DialogResult.OK Then
            DemandeInfoBalance(False)
            'End If
        End If

        'If MessageBox.Show("Voulez-vous envoyer la mise à jour de ce produit sur la balance ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    DemandeInfoBalance(False)
        'End If

    End Sub

    Public Sub UpDateBalanceProduit(ByRef dtBalance As DataTable, ByVal dtOrdi As DataTable)
        strTxBalance = ""
        Dim dt As New DataTable
        dt.Columns.Add("EnvoiBalance", GetType(Boolean)).DefaultValue = True
        dt.Columns.Add("RecupBalance", GetType(Boolean)).DefaultValue = False
        dt.Columns.Add("nPLU")
        dt.Columns.Add("Libelle")
        dt.Columns.Add("PrixOrdi", GetType(Decimal))
        dt.Columns.Add("PrixBalance", GetType(Decimal))
        dt.Columns.Add("TrameEnvoiBalance")

        Dim rw As DataRow
        For Each rw In dtOrdi.Select("", "", DataViewRowState.CurrentRows)
            Dim EnvoiLigne As Boolean = False

            Dim rws() As DataRow = dtBalance.Select("CodeProduit='" & rw.Item("CodeProduit") & "'", "", DataViewRowState.CurrentRows)
            If rws.GetUpperBound(0) >= 0 Then
                'If Convert.ToString(rws(0).Item("CodeBarre")) <> Convert.ToString(rw.Item("CodeBarre")) Then
                '    EnvoiLigne = True
                'End If
                If Convert.ToString(rws(0).Item("Libelle")) <> Convert.ToString(rw.Item("Libelle")) Then
                    EnvoiLigne = True
                End If
                If Convert.ToDecimal(rws(0).Item("PrixVTTC")) <> Convert.ToDecimal(rw.Item("PrixVTTC")) Then
                    EnvoiLigne = True
                End If
                If Convert.ToString(rws(0).Item("TTVA")) <> Convert.ToString(rw.Item("TTVA")) Then
                    EnvoiLigne = True
                End If
                If Convert.ToInt32(rws(0).Item("Famille1")) <> Convert.ToInt32(rw.Item("Famille1")) Then
                    EnvoiLigne = True
                End If
                'If Convert.ToInt32(rws(0).Table.Columns.Contains("nTare")) And Convert.ToInt32(rw.Table.Columns.Contains("nTare")) Then
                '    If rws(0).Item("nTare") <> rw.Item("nTare") Then
                '        EnvoiLigne = True
                '    End If
                'End If
                'If rws(0).Table.Columns.Contains("PrixModifiable") And rw.Table.Columns.Contains("PrixModifiable") Then
                '    If Convert.ToBoolean(rws(0).Item("PrixModifiable")) <> Convert.ToBoolean(rw.Item("PrixModifiable")) Then
                '        EnvoiLigne = True
                '    End If
                'End If
            Else
                EnvoiLigne = True
            End If
            If EnvoiLigne = True Then
                Dim tr As AnalyseTrame207 = MajProduit(rw)
                tr.TypeCommande = ArticleDataAction.Write
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += tr.GetTrame

                Dim rwInfo As DataRow = dt.NewRow
                rwInfo.Item("nPLU") = rw.Item("CodeProduit")
                rwInfo.Item("Libelle") = rw.Item("Libelle")
                rwInfo.Item("PrixOrdi") = rw.Item("PrixVTTC")
                If rws.GetUpperBound(0) >= 0 Then
                    rwInfo.Item("PrixBalance") = rws(0).Item("PrixVTTC")
                End If
                rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
                dt.Rows.Add(rwInfo)
            End If
        Next

        dt.Columns("EnvoiBalance").DefaultValue = False
        dt.Columns("RecupBalance").DefaultValue = True

        For Each rw In dtBalance.Select("", "", DataViewRowState.CurrentRows)
            'Dim EnvoiLigne As Boolean = False

            Dim rws() As DataRow = dtOrdi.Select("CodeProduit='" & rw.Item("CodeProduit") & "'", "", DataViewRowState.CurrentRows)
            If rws.GetUpperBound(0) < 0 Then
                Dim tr As AnalyseTrame207 = MajProduit(rw)
                tr.TypeCommande = ArticleDataAction.Delete

                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += tr.GetTrame

                Dim rwInfo As DataRow = dt.NewRow
                rwInfo.Item("nPLU") = rw.Item("CodeProduit")
                rwInfo.Item("Libelle") = rw.Item("Libelle")
                'rwInfo.Item("PrixOrdi") = rw.Item("PrixVTTC")
                rwInfo.Item("PrixBalance") = rw.Item("PrixVTTC")
                rwInfo.Item("TrameEnvoiBalance") = tr.GetTrame
                dt.Rows.Add(rwInfo)
            End If
        Next

        CodeDemande = 207
        Dim fr As New FrInfoEnvoiBalance
        fr.TxText.Text = strTxBalance
        fr.dv = New DataView(dt)
        If fr.ShowDialog = DialogResult.OK Then
            Dim rwRecupBalance As DataRow
            For Each rwRecupBalance In dt.Select("RecupBalance=" & True, "", DataViewRowState.CurrentRows)
                Dim rwsRecup() As DataRow
                rwsRecup = dtBalance.Select("CodeProduit='" & rwRecupBalance.Item("nPLU") & "'")
                If rwsRecup.GetUpperBound(0) >= 0 Then
                    Dim rwsOrdi() As DataRow
                    rwsOrdi = dtOrdi.Select("CodeProduit='" & rwRecupBalance.Item("nPLU") & "'")
                    If rwsOrdi.GetUpperBound(0) >= 0 Then
                        rwsOrdi(0).Item("Libelle") = rwsRecup(0).Item("Libelle")
                        rwsOrdi(0).Item("CodeBarre") = rwsRecup(0).Item("CodeBarre")
                        rwsOrdi(0).Item("Famille1") = rwsRecup(0).Item("Famille1")
                        rwsOrdi(0).Item("Unite1") = rwsRecup(0).Item("Unite1")
                        rwsOrdi(0).Item("PrixVTTC") = rwsRecup(0).Item("PrixVTTC")
                        rwsOrdi(0).Item("TTVA") = rwsRecup(0).Item("TTVA")
                    Else
                        Me.dtProduit = dtOrdi
                        Dim tr As AnalyseTrame207 = MajProduit(rwsRecup(0))
                        tr.TypeCommande = ArticleDataAction.Write
                        tr.Cmd = "1"
                        Dim Ok As Boolean
                        Me.AnalyseTrame207(tr.GetTrame, Ok)
                        Me.dtProduit = dtBalance
                    End If
                End If
            Next
            Dim rwEnvoiBalance As DataRow
            strTxBalance = ""
            For Each rwEnvoiBalance In dt.Select("EnvoiBalance=" & True, "", DataViewRowState.CurrentRows)
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += rwEnvoiBalance.Item("TrameEnvoiBalance")
            Next
            'Dim fr1 As New FrInfoEnvoiBalance
            'fr1.TxText.Text = strTxBalance
            'fr1.dv = New DataView(dt)
            'If fr1.ShowDialog = DialogResult.OK Then
            DemandeInfoBalance(False)
            'End If
        End If
    End Sub

    Public Sub VerifProduit(Optional ByVal DepuisFichier As Boolean = False)
        If DepuisFichier = False Then
            Dim tr As New Mira.AnalyseTrame207
            tr.TypeCommande = ArticleDataAction.ReadAll
            strTxBalance = tr.GetTrame
            CodeDemande = 207
            DemandeInfoBalance()
        Else
            CodeDemande = 207
            AnalyseResultat()
        End If
    End Sub

    Public Sub UpDateBalanceTVA(ByRef dtBalance As DataTable, ByVal dtOrdi As DataTable)
        strTxBalance = ""
        Dim rw As DataRow
        For Each rw In dtOrdi.Rows
            Dim EnvoiLigne As Boolean = False

            Dim rws() As DataRow = dtBalance.Select("nTVA=" & rw.Item("nTVA"))
            If rws.GetUpperBound(0) >= 0 Then
                If Convert.ToString(rws(0).Item("TTaux")) <> Convert.ToString(rw.Item("TTaux")) Then
                    EnvoiLigne = True
                End If
            Else
                EnvoiLigne = True
            End If
            If EnvoiLigne = True Then
                Dim tr As New Mira.AnalyseTrame218
                tr.TypeCommande = ArticleDataAction.Write
                tr.nTVA = rw.Item("nTVA")
                tr.TxTVA = rw.Item("TTaux")
                If strTxBalance.Length > 0 Then
                    strTxBalance += vbCrLf
                End If
                strTxBalance += tr.GetTrame
            End If
        Next
        CodeDemande = 218
        Dim fr As New FrInfoEnvoiBalance
        fr.TxText.Text = strTxBalance
        If fr.ShowDialog = DialogResult.OK Then
            DemandeInfoBalance(False)
        End If
    End Sub

    Public Sub VerifTVA(Optional ByVal DepuisFichier As Boolean = False)
        If DepuisFichier = False Then
            Dim tr As New Mira.AnalyseTrame218
            tr.TypeCommande = ArticleDataAction.ReadAll
            strTxBalance = tr.GetTrame
            CodeDemande = 218
            DemandeInfoBalance()
        Else
            CodeDemande = 218
            AnalyseResultat()
        End If
    End Sub


    Private Sub DemandeInfoBalance(Optional ByVal AnalyseResult As Boolean = True, Optional ByVal Force As Boolean = True)
        'Dim strFileIn As String = strDirectory & "\In.txt"

        Dim flIn As New IO.FileStream(strFileIn, IO.FileMode.Create)
        Dim wFl As New IO.StreamWriter(flIn)

        wFl.Write(strTxBalance & vbCrLf)
        wFl.Close()

        Dim st As New ProcessStartInfo(strDirectory & "\TransL2.exe")
        With st
            .Arguments = "-i in.txt -o out.txt -w 1 -t 30" & IIf(Force, " -e", "")
            .WorkingDirectory = strDirectory
            .UseShellExecute = True
            .WindowStyle = ProcessWindowStyle.Normal
        End With
        Dim Pr As Process = Process.Start(st)
        Pr.WaitForExit()
        If AnalyseResult = True Then
            AnalyseResultat()
        End If
    End Sub

    Private Sub AnalyseResultat()
        Dim strErreur As String = ""

        Dim flOut As New IO.FileStream(strFileOut, IO.FileMode.Open)
        Dim rFl As New IO.StreamReader(flOut)

        Dim strOut As String = rFl.ReadToEnd
        strRxBalance = strOut

        'Me.TxReception.Text = strOut
        rFl.Close()

        'MessageBox.Show("Lecture fichier fini")

        Dim FinOk As Boolean = False

        If CodeDemande = 512 Or CodeDemande = 207 Or CodeDemande = 210 Or CodeDemande = 218 Then
            Dim obj As Object
            Dim nImport As Long
            If Not dtTrame Is Nothing Then
                obj = dtTrame.Compute("Max(nImport)", "")
                If Not obj Is DBNull.Value Then
                    nImport = Convert.ToInt64(obj) + 1
                End If
            End If

            Dim strTrame() As String = strOut.Replace(vbCrLf, "|").Split("|"c)

            ReportProgress(0, strTrame.Length)
            Dim nTrameTmp As Integer = 0
            For Each trame As String In strTrame
                nTrameTmp += 1
                ReportProgress(nTrameTmp, strTrame.Length)
                If trame.Length >= 6 Then
                    If trame.Substring(1, 5) = "00512" Then
                        AnalyseTrame512(trame, FinOk, nImport)
                    ElseIf trame.Substring(1, 5) = "00207" Then
                        AnalyseTrame207(trame, FinOk)
                    ElseIf trame.Substring(1, 5) = "00210" Then
                        AnalyseTrame210(trame, FinOk)
                    ElseIf trame.Substring(1, 5) = "00218" Then
                        AnalyseTrame218(trame, FinOk)
                    End If
                End If
                GetErreur(trame, strErreur)
            Next
            CodeDemande = 0
        End If
        RaiseEvent RecptionTerminee(FinOk, strErreur)
    End Sub

    Private Sub AnalyseTrame210(ByVal trame As String, ByRef FinOk As Boolean)
        Dim at As New AnalyseTrame210
        at.AnalyseTrame(trame)
        If at.Cmd = 3 Or at.Cmd = 1 Then
            Dim rws() As DataRow = Nothing
            If Convert.ToString(at.nGroupe) <> "" Then
                rws = dtGroupe.Select("nFamille=" & at.nGroupe)
            End If
            If rws IsNot Nothing AndAlso rws.Length > 0 Then
                Dim rw As DataRow = rws(0)
                rw.Item("Famille") = at.Description
                If Convert.ToString(at.nMainGroupe) <> "" Then
                    rw.Item("nGroupe") = at.nMainGroupe
                Else
                    rw.Item("nGroupe") = 0
                End If
                rw.EndEdit()
            Else
                Dim rw As DataRow = dtGroupe.NewRow
                If Convert.ToString(at.nGroupe) <> "" Then
                    rw.Item("nFamille") = at.nGroupe
                Else
                    rw.Item("nFamille") = 0
                End If
                rw.Item("Famille") = at.Description
                If Convert.ToString(at.nMainGroupe) <> "" Then
                    rw.Item("nGroupe") = at.nMainGroupe
                Else
                    rw.Item("nGroupe") = 0
                End If
                dtGroupe.Rows.Add(rw)
            End If
            If at.Cmd = 1 Then
                FinOk = True
            End If
        End If
    End Sub

    Private Sub AnalyseTrame207(ByVal trame As String, ByRef FinOk As Boolean)
        Dim at As New AnalyseTrame207
        at.AnalyseTrame(trame)
        If at.Cmd = 3 Or at.Cmd = 1 Then
            Dim rws() As DataRow = dtProduit.Select("CodeProduit='" & at.nPlu & "'")
            If rws.GetUpperBound(0) >= 0 Then
                Dim rw As DataRow = rws(0)
                rw.Item("Libelle") = at.Description
                rw.Item("CodeBarre") = at.EAN
                'rw.Item("PrixAHT") = at.PrixAchat
                rw.Item("PrixVTTC") = at.PrixVente1
                Select Case at.TypePrixPiece
                    Case True
                        rw.Item("Unite1") = "P"
                    Case False
                        rw.Item("Unite1") = "Kg"
                End Select
                If dtTVA.Select("nTVA=" & at.nTVA).GetUpperBound(0) >= 0 Then
                    rw.Item("TTVA") = dtTVA.Select("nTVA=" & Convert.ToInt32(at.nTVA))(0).Item("TTVA")
                End If
                'rw.Item("ProduitAchat") = True
                'rw.Item("ProduitVente") = True
                rw.Item("Famille1") = at.nGroupe
                rw.EndEdit()
            Else
                Dim rw As DataRow = dtProduit.NewRow
                rw.Item("CodeProduit") = at.nPlu
                rw.Item("Libelle") = at.Description
                rw.Item("CodeBarre") = at.EAN
                'rw.Item("PrixAHT") = at.PrixAchat
                rw.Item("PrixVTTC") = at.PrixVente1
                Select Case at.TypePrixPiece
                    Case True
                        rw.Item("Unite1") = "P"
                    Case False
                        rw.Item("Unite1") = "Kg"
                End Select
                If dtTVA.Select("nTVA=" & at.nTVA).GetUpperBound(0) >= 0 Then
                    rw.Item("TTVA") = dtTVA.Select("nTVA=" & Convert.ToInt32(at.nTVA))(0).Item("TTVA")
                End If
                rw.Item("ProduitAchat") = True
                rw.Item("ProduitVente") = True
                rw.Item("GestionStock") = True
                rw.Item("Famille1") = at.nGroupe
                rw.Item("TypeFacturation") = "U1"
                dtProduit.Rows.Add(rw)
            End If
            If at.Cmd = 1 Then
                FinOk = True
            End If
        End If
    End Sub

    Private Sub AnalyseTrame218(ByVal trame As String, ByRef FinOk As Boolean)
        Dim at As New AnalyseTrame218
        at.AnalyseTrame(trame)
        If at.Cmd = 3 Or at.Cmd = 1 Then
            Dim rws() As DataRow
            If Convert.ToString(at.nTVA) <> "" Then
                rws = dtTVA.Select("nTVA=" & at.nTVA)
                If rws.GetUpperBound(0) >= 0 Then
                    Dim rw As DataRow = rws(0)
                    rw.Item("TTaux") = at.TxTVA
                    rw.EndEdit()
                Else
                    Dim rw As DataRow = dtGroupe.NewRow
                    rw.Item("nTVA") = at.nTVA
                    rw.Item("TTaux") = at.TxTVA
                    dtTVA.Rows.Add(rw)
                End If
            End If

            If at.Cmd = 1 Then
                FinOk = True
            End If
        End If
    End Sub

    Private Sub AnalyseTrame512(ByVal trame As String, ByRef FinOk As Boolean, ByVal nImport As Long)
        Dim at As New AnalyseTrame512
        at.AnalyseTrame(trame)
        If at.TypeTrame <= 3 Or at.TypeTrame = 6 Then
            If dtTrameVerif.Select(String.Format("nTicket={0} And dtTicket=#{1:MM/dd/yyyy}# And nImport<>{2}", at.nTicket, at.dtTicket, nImport)).Length = 0 Then
                Dim rw As DataRow = dtTrame.NewRow
                rw.Item("nDep") = at.nDep
                rw.Item("nBal") = at.nBal
                rw.Item("nTicket") = at.nTicket
                rw.Item("dtTicket") = at.dtTicket
                rw.Item("TimeTicket") = at.TimeTicket
                rw.Item("Vendeur") = at.Vendeur
                rw.Item("TypeTrame") = at.TypeTrame
                rw.Item("BookingCancel") = at.BookingCancel
                rw.Item("BookingType") = at.BookingType
                rw.Item("PriceType") = at.PriceType
                rw.Item("Plu") = at.Plu
                If Convert.ToString(at.BookingType) = "0" Then
                    If Not at.Quantite Is DBNull.Value Then
                        If at.Quantite <> "" Then
                            rw.Item("Quantite") = Convert.ToDecimal(at.Quantite) / 1000
                        End If
                    End If
                Else
                    rw.Item("Quantite") = at.Quantite
                End If
                If Not at.Montant Is DBNull.Value Then
                    If at.Montant <> "" Then
                        rw.Item("Montant") = Convert.ToDecimal(at.Montant) / 100
                    End If
                End If
                rw.Item("TypeVente") = at.TypeVente
                rw.Item("NombreEntre") = at.NombreEntre
                If Not at.TotalPoids Is DBNull.Value Then
                    If at.TotalPoids <> "" Then
                        rw.Item("TotalPoids") = Convert.ToDecimal(at.TotalPoids) / 1000
                    End If
                End If
                If Not at.TotalMontant Is DBNull.Value Then
                    If at.TotalMontant <> "" Then
                        rw.Item("TotalMontant") = Convert.ToDecimal(at.TotalMontant) / 100
                    End If
                End If
                If Not at.TotalMargin Is DBNull.Value Then
                    If at.TotalMargin <> "" Then
                        rw.Item("TotalMargin") = Convert.ToDecimal(at.TotalMargin) / 100
                    End If
                End If
                rw.Item("TVANumber") = at.TVANumber
                If Not at.TVAVentes Is DBNull.Value Then
                    If at.TVAVentes <> "" Then
                        rw.Item("TVAVentes") = Convert.ToDecimal(at.TVAVentes) / 100
                    End If
                End If
                rw.Item("nImport") = nImport
                dtTrame.Rows.Add(rw)
            End If
        ElseIf at.TypeTrame = 255 Then
            FinOk = True
        End If
    End Sub

    Private Sub GetErreur(ByVal Trame As String, ByRef strErreur As String)
        Select Case Trame
            Case "02201"
                strErreur = Trame & ":Erreur Read"
            Case "02202"
                strErreur = Trame & ":Erreur Read Timeout"
            Case "02203"
                strErreur = Trame & ":Buffer Overflow"
            Case "02204"
                strErreur = Trame & ":Erreur Check Sum error"
            Case "02205"
                strErreur = Trame & ":Erreur Open Device"
            Case "02206"
                strErreur = Trame & ":Erreur write"
            Case "02207"
                strErreur = Trame & ":Erreur write Timeout"
            Case "02208"
                strErreur = Trame & ":Erreur end of Transmission"
            Case "02209"
                strErreur = Trame & ":Erreur unable to write"
            Case "02210"
                strErreur = Trame & ":Scale detected an error in a record and requests a re-transmission"
            Case "02211"
                strErreur = Trame & ":Erreur Close Device"
            Case "02212"
                strErreur = Trame & ":E_STB"
            Case "02213"
                strErreur = Trame & ":Erreur ioctl g"
            Case "02214"
                strErreur = Trame & ":Erreur ioctl s"
            Case "02215"
                strErreur = Trame & ":Erreur logfile open"
            Case "02216"
                strErreur = Trame & ":Erreur start for text (the expected did not arrive - buffer not cleared; Wait for Scale RS232 reset (approx. 1 min))"
            Case "02300"
                strErreur = Trame & ":Erreur INF"
            Case "02901"
                strErreur = Trame & ":Erreur Command Line err"
            Case "02902"
                strErreur = Trame & ":Erreur user interrupt"
            Case "02E-1"
                strErreur = Trame
            Case "02E-4"
                strErreur = Trame & ":RD All busy"
        End Select
    End Sub

    'Private Sub Pr_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pr.Exited
    '    MessageBox.Show("Exited")
    '    AnalyseResultat()
    'End Sub

    'Private Sub Pr_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pr.disposed
    '    MessageBox.Show("Disposed")
    'End Sub
End Class

Public Class MiraTrame
    Private _CmdRsp As String = "0"
    Private _AccessCode As String = ""
    Private _Ctl As String = "0006"
    Private _Dpt As String = "0000"
    Private _Scale As String = "00"

    Public Property CmdRsp() As String
        Get
            Return _CmdRsp
        End Get
        Set(ByVal Value As String)
            _CmdRsp = Value.PadLeft(1)
        End Set
    End Property

    Public Property AccessCode() As String
        Get
            Return _AccessCode
        End Get
        Set(ByVal Value As String)
            _AccessCode = Value.PadLeft(5, "0")
        End Set
    End Property

    Public Property Ctl() As String
        Get
            Return _Ctl
        End Get
        Set(ByVal Value As String)
            _Ctl = Value.PadLeft(4, "0")
        End Set
    End Property

    Public Property Dpt() As String
        Get
            Return _Dpt
        End Get
        Set(ByVal Value As String)
            _Dpt = Value.PadLeft(4, "0")
        End Set
    End Property

    Public Property Scale() As String
        Get
            Return _Scale
        End Get
        Set(ByVal Value As String)
            _Scale = Value.PadLeft(2, "0")
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Function GetHeader() As String
        Return Me.CmdRsp & Me.AccessCode & Me.Ctl & Me.Dpt & Me.Scale
    End Function

End Class
