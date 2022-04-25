Imports System.Text.RegularExpressions

Public Class CodeBarre
    Public Enum TypeCodeBarre
        Inconnu = 0
        Reception = 1
        Fabrication = 2
    End Enum

#Region " Shared "

    Public Shared Function Parse(ByVal str As String) As CodeBarre
        Dim exp As String = "^(?<type>\d)(?<ean>\d{4})(?<nPiece>\d{7})$"
        Dim re As New Regex(exp)
        Dim m As Match = re.Match(str)
        If m IsNot Nothing AndAlso m.Success Then
            Dim type As TypeCodeBarre = TypeCodeBarre.Inconnu
            Try
                type = Cast(Of TypeCodeBarre)(CInt(m.Groups("type").Value))
            Catch
            End Try
            Dim ean As Integer = CInt(m.Groups("ean").Value)
            Dim nPiece As Integer = CInt(m.Groups("nPiece").Value)
            Dim cb As New CodeBarre(type, ean, nPiece)
            Using s As New SqlProxy
                Dim codeproduit As String = Convert.ToString(s.ExecuteScalar(String.Format("SELECT CodeProduit FROM Produit WHERE CodeBarre='{0:0000}'", ean)))
                If codeproduit.Length > 0 Then
                    cb.CodeProduit = codeproduit
                    Select Case type
                        Case TypeCodeBarre.Reception
                            Dim nlot As String = Convert.ToString(s.ExecuteScalar(SqlProxy.FormatSql("SELECT NLot FROM ABonReception_Detail Where nDevis={0} AND CodeProduit={1}", cb.nPiece, cb.CodeProduit)))
                            If nlot.Length > 0 Then
                                cb.NLot = nlot
                            End If
                        Case TypeCodeBarre.Fabrication
                            Dim nlot As String = Convert.ToString(s.ExecuteScalar(SqlProxy.FormatSql("SELECT NLot FROM Mouvement_Detail Where nMouvement={0} AND CodeProduit={1}", cb.nPiece, cb.CodeProduit)))
                            If nlot.Length > 0 Then
                                cb.NLot = nlot
                            End If
                    End Select
                End If
            End Using
            Return cb
        End If
        Return Nothing
    End Function

    Public Shared Function Parse(ByVal str As String, ByVal ds As AgrifactTracaDataSet) As CodeBarre
        Dim exp As String = "^(?<type>\d)(?<ean>\d{4})(?<nPiece>\d{7})$"
        Dim re As New Regex(exp)
        Dim m As Match = re.Match(str)
        If m IsNot Nothing AndAlso m.Success Then
            Dim type As TypeCodeBarre = TypeCodeBarre.Inconnu
            Try
                type = Cast(Of TypeCodeBarre)(CInt(m.Groups("type").Value))
            Catch
            End Try
            Dim ean As Integer = CInt(m.Groups("ean").Value)
            Dim nPiece As Integer = CInt(m.Groups("nPiece").Value)
            Dim drProd As AgrifactTracaDataSet.ProduitRow = SelectSingleRow(Of AgrifactTracaDataSet.ProduitRow)(ds.Produit, String.Format("CodeBarre='{0:0000}'", ean), "")
            If drProd IsNot Nothing Then
                Dim cb As New CodeBarre(type, ean, nPiece)
                cb.ProduitDatarow = drProd
                cb.CodeProduit = drProd.CodeProduit
                If type = TypeCodeBarre.Reception Then
                    Dim drBR_detail As AgrifactTracaDataSet.ABonReception_DetailRow = _
                                        SelectSingleRow(Of AgrifactTracaDataSet.ABonReception_DetailRow) _
                                        (ds.ABonReception_Detail, String.Format("nDevis={0} AND CodeProduit='{1}'", nPiece, cb.CodeProduit), "")
                    If drBR_detail IsNot Nothing Then
                        cb.Datarow = drBR_detail
                        cb.NLot = drBR_detail.NLot
                        Return cb
                    End If
                ElseIf type = TypeCodeBarre.Fabrication Then
                    Dim drMvt_detail As AgrifactTracaDataSet.Mouvement_DetailRow = _
                                        SelectSingleRow(Of AgrifactTracaDataSet.Mouvement_DetailRow) _
                                        (ds.Mouvement_Detail, String.Format("nMouvement={0} AND CodeProduit='{1}'", nPiece, cb.CodeProduit), "")
                    If drMvt_detail IsNot Nothing Then
                        cb.Datarow = drMvt_detail
                        cb.NLot = drMvt_detail.nLot
                        Return cb
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Shared Function ConstruireCodeBarre(ByVal drBR_detail As AgrifactTracaDataSet.ABonReception_DetailRow) As CodeBarre
        Dim cb As CodeBarre = ConstruireCodeBarre(TypeCodeBarre.Reception, drBR_detail.ProduitRow, drBR_detail.ABonReceptionRow)
        If cb IsNot Nothing Then
            cb.Datarow = drBR_detail
        End If
        Return cb
    End Function

    Public Shared Function ConstruireCodeBarre(ByVal type As TypeCodeBarre, ByVal drProduit As AgrifactTracaDataSet.ProduitRow, ByVal drBR As AgrifactTracaDataSet.ABonReceptionRow) As CodeBarre
        Dim ean As Integer = 0
        Integer.TryParse(Convert.ToString(drProduit("CodeBarre")), ean)
        If ean = 0 Then
            Return Nothing
        Else
            Return New CodeBarre(type, ean, CInt(drBR.nDevis))
        End If
    End Function

    Public Shared Function ConstruireCodeBarre(ByVal drMvt_detail As AgrifactTracaDataSet.Mouvement_DetailRow) As CodeBarre
        Dim cb As CodeBarre = ConstruireCodeBarre(TypeCodeBarre.Reception, drMvt_detail.ProduitRow, drMvt_detail.MouvementRow)
        If cb IsNot Nothing Then
            cb.Datarow = drMvt_detail
        End If
        Return cb
    End Function

    Public Shared Function ConstruireCodeBarre(ByVal type As TypeCodeBarre, ByVal drProduit As AgrifactTracaDataSet.ProduitRow, ByVal drMvt As AgrifactTracaDataSet.MouvementRow) As CodeBarre
        Dim ean As Integer = 0
        Integer.TryParse(Convert.ToString(drProduit("CodeBarre")), ean)
        If ean = 0 Then
            Return Nothing
        Else
            Return New CodeBarre(type, ean, CInt(drMvt.nMouvement))
        End If
    End Function
#End Region

    Public Sub New()

    End Sub

    Public Sub New(ByVal type As TypeCodeBarre, ByVal ean As Integer, ByVal npiece As Integer)
        Me.New()
        With Me
            .Type = type
            .EAN = ean
            .nPiece = npiece
        End With
    End Sub

#Region " Props "
    Private _dr As DataRow
    Public Property Datarow() As DataRow
        Get
            Return _dr
        End Get
        Set(ByVal value As DataRow)
            _dr = value
        End Set
    End Property

    Public Property BRDatarow() As AgrifactTracaDataSet.ABonReception_DetailRow
        Get
            If Me.Type = TypeCodeBarre.Reception Then
                Return Cast(Of AgrifactTracaDataSet.ABonReception_DetailRow)(_dr)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As AgrifactTracaDataSet.ABonReception_DetailRow)
            _dr = value
        End Set
    End Property

    Public Property MouvDatarow() As AgrifactTracaDataSet.Mouvement_DetailRow
        Get
            If Me.Type = TypeCodeBarre.Fabrication Then
                Return Cast(Of AgrifactTracaDataSet.Mouvement_DetailRow)(_dr)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As AgrifactTracaDataSet.Mouvement_DetailRow)
            _dr = value
        End Set
    End Property

    Private _drProd As AgrifactTracaDataSet.ProduitRow
    Public Property ProduitDatarow() As AgrifactTracaDataSet.ProduitRow
        Get
            Return _drProd
        End Get
        Set(ByVal value As AgrifactTracaDataSet.ProduitRow)
            _drProd = value
        End Set
    End Property

    Private _type As TypeCodeBarre
    Public Property Type() As TypeCodeBarre
        Get
            Return _type
        End Get
        Set(ByVal value As TypeCodeBarre)
            _type = value
        End Set
    End Property


    Private _ean As Integer
    Public Property EAN() As Integer
        Get
            Return _ean
        End Get
        Set(ByVal value As Integer)
            _ean = value
        End Set
    End Property


    Private _nPiece As Integer
    Public Property nPiece() As Integer
        Get
            Return _nPiece
        End Get
        Set(ByVal value As Integer)
            _nPiece = value
        End Set
    End Property


    Private _code As String
    Public Property CodeProduit() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property


    Private _lot As String
    Public Property NLot() As String
        Get
            Return _lot
        End Get
        Set(ByVal value As String)
            _lot = value
        End Set
    End Property
#End Region


    Public Overrides Function ToString() As String
        Dim format As String = "{0}{1:0000}{2:0000000}"
        Return String.Format(format, CInt(Me.Type), EAN, nPiece)
    End Function

    Public Function CodeBarreFormate() As String
        Dim str As String = Me.ToString
        If str.Length = 0 OrElse str.Length > 12 Then
            Return Nothing
        Else
            Return FormatterCodeBarre(str)
        End If
    End Function
End Class
