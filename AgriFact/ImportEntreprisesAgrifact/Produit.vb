Public Class Produit
    Implements IDataItem

    Public nProduit As Integer
    Public CodeProduit As String
    Public Libelle As String
    'Public LibelleLong As String
    Public TTVA As String
    Public PrixAHT As Double
    'Public PrixATTC As Double
    Public PrixVHT As Double
    'Public PrixVTTC As Double
    Public IsPrixHT As Boolean = False
    Public Unite1 As String
    Public Unite2 As String
    Public ProduitAchat As Boolean = True
    Public ProduitVente As Boolean = True
    Public NCompteA As String
    Public NActiviteA As String
    Public NCompteV As String
    Public NActiviteV As String
    Public Famille1 As Short = 1
    'Public Famille2 As String
    'Public Famille3 As String
    'Public U1U2Independant As Boolean
    'Public U1xU2 As Double
    'Public CodeBarre As String
    'Public Inactif As Boolean
    'Public CoefU2 As Double
    Public TypeFacturation As String = "U1"
    'Public CoefAV As Double
    'Public ProduitCompose As Boolean
    'Public Image As String
    'Public GestionStock As Boolean
    'Public DecompteAuto As Boolean
    'Public RefFournisseur As String
    'Public nFournisseur As Integer

    Public Sub Insert(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Insert
        VerifFamille(conn)
        If nProduit < 0 Then nProduit = GetNextNProduit(conn)
        Dim sql As String = "INSERT INTO [Produit] ([nProduit], [CodeProduit], [Libelle], [TTVA], [PrixAHT], [PrixVHT], IsPrixHt, [Unite1], [Unite2], [ProduitAchat], [ProduitVente], [NCompteA],NActiviteA,[NCompteV],NActiviteV,TypeFacturation) " & _
                                    "VALUES({0}, {1}, {2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})"
        sql = String.Format(sql, Me.ItemArray)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()
    End Sub

    Public Sub Update(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Update
        VerifFamille(conn)
        Dim sql As String = "UPDATE [Produit] SET " & _
                                    "[CodeProduit] = {1}, " & _
                                    "[Libelle] = {2}, " & _
                                    "[TTVA]={3}, " & _
                                    "[PrixAHT]={4}, " & _
                                    "[PrixVHT]={5}, " & _
                                    "[Unite1]={6}, " & _
                                    "[Unite2]={7}, " & _
                                    "[ProduitAchat]={8}, " & _
                                    "[ProduitVente]={9}, " & _
                                    "[NCompteA]={10}, " & _
                                    "[NActiviteA]={11}, " & _
                                    "[NCompteV]={12}, " & _
                                    "[NActiviteV]={13}, " & _
                                    "[TypeFacturation]={14}, " & _
                                    "WHERE nEntreprise={0}"
        sql = String.Format(sql, Me.ItemArray)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()
    End Sub

    Public Sub Delete(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Delete
        Dim sql As String = "DELETE FROM [Produit] WHERE nProduit={0}"
        sql = String.Format(sql, nProduit)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()
    End Sub

    Public Function Exists(ByVal conn As SqlClient.SqlConnection) As Boolean Implements IDataItem.Exists
        Dim sql As String = String.Format("select count(*) from produit where nProduit={0}", nProduit)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Return CType(com.ExecuteScalar(), Integer) > 0
    End Function

    Public Sub VerifFamille(ByVal conn As SqlClient.SqlConnection)
        Dim sql As String = String.Format("select count(*) from famille where nFamille={0}", Famille1)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        If CType(com.ExecuteScalar(), Integer) = 0 Then
            sql = String.Format("insert into famille(nFamille, Famille,nGroupe) VALUES({0},{1},{2})", Famille1, "'FAMILLE PAR DEFAUT'", "NULL")
            com.CommandText = sql
            com.ExecuteNonQuery()
        End If
    End Sub

    Public Function GetNextNProduit(ByVal conn As SqlClient.SqlConnection) As Integer
        Dim sql As String = "select max(nproduit) from produit"
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Dim res As Object = com.ExecuteScalar
        If IsDBNull(res) Then
            Return 1
        Else
            Return CInt(res) + 1
        End If
    End Function

    Private Function FormatValeur(ByVal valeur As Object, Optional ByVal valeurNull As String = "NULL") As String
        If valeur Is Nothing OrElse CStr(valeur) = "" Then
            Return valeurNull
        Else
            If TypeOf valeur Is String Then
                Return "'" & valeur.Replace("'", "''") & "'"
            ElseIf TypeOf valeur Is Double Then
                Return CDbl(valeur).ToString().Replace(",", ".")
            ElseIf TypeOf valeur Is Integer Then
                Return CInt(valeur).ToString()
            ElseIf TypeOf valeur Is Date Then
                Return CDate(valeur).ToString("'dd/MM/yyyy HH:mm:ss'")
            ElseIf TypeOf valeur Is Boolean Then
                Return IIf(CBool(valeur), "1", "0")
            Else 'Par défaut : NULL
                Return valeurNull
            End If
        End If
    End Function

    Public ReadOnly Property NbCol() As Integer Implements IDataItem.NbCol
        Get
            Return 16
        End Get
    End Property

    Public ReadOnly Property NomCols() As String() Implements IDataItem.NomCols
        Get
            Return New String() {"nProduit", "CodeProduit", "Libelle", "TTVA", "PrixAHT", "PrixVHT", "IsPrixHT", "Unite1", "Unite2", "ProduitAchat", "ProduitVente", "NCompteA", "NActiviteA", "NCompteV", "NActiviteV", "TypeFacturation"}
        End Get
    End Property

    Public ReadOnly Property ItemArray() As Object() Implements IDataItem.ItemArray
        Get
            Return New Object() {nProduit, FormatValeur(CodeProduit), FormatValeur(Libelle), FormatValeur(TTVA), FormatValeur(PrixAHT), FormatValeur(PrixVHT), FormatValeur(IsPrixHT), FormatValeur(Unite1), FormatValeur(Unite2), FormatValeur(ProduitAchat), FormatValeur(ProduitVente), FormatValeur(NCompteA), FormatValeur(NActiviteA), FormatValeur(NCompteV), FormatValeur(NActiviteV), FormatValeur(TypeFacturation)}
        End Get
    End Property
End Class
