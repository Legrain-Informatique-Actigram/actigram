Public Interface IDataItem
    Sub Insert(ByVal conn As SqlClient.SqlConnection)
    Sub Update(ByVal conn As SqlClient.SqlConnection)
    Sub Delete(ByVal conn As SqlClient.SqlConnection)
    Function Exists(ByVal conn As SqlClient.SqlConnection) As Boolean
    ReadOnly Property NbCol() As Integer
    ReadOnly Property NomCols() As String()
    ReadOnly Property ItemArray() As Object()
End Interface

Public Class Entreprise
    Implements IDataItem

    Public nEntreprise As Long
    Public dateCreation As Date
    Public dateModification As Date
    Public InfoMaj As String
    'Public TypeEntreprise As String
    'Public nOrganisme As String
    'Public nMaisonMere As Integer
    'Public Dep As String
    Public nom As String
    Public adresse As String
    Public CodePostal As String
    Public Ville As String
    Public Telephone As String
    Public Fax As String
    Public Portable As String
    Public SuffixePostal As String
    Public Pays As String
    'Public FormeJuridique As String
    Public TypeClient As String
    'Public CibleCommercial As String
    'Public ModePaiement As String
    'Public Echeance As Integer
    'Public Banque As String
    'Public RIB As String
    'Public CA As Decimal
    Public Email As String
    'Public SiteInternet As String
    Public Observations As String
    'Public FinMois As Boolean
    'Public Remise As Decimal
    'Public TTVA As String
    'Public FacturationTTC As Boolean
    'Public Fournisseur As Boolean
    'Public Client As Boolean
    Public nCompteC As String
    Public nActiviteC As String
    Public Critere1 As String
    Public Critere2 As String
    Public Critere3 As String
    Public Critere4 As String
    Public Civilite As String
    Public NTVAIntraCom As String
    Public ChampsLibres As Dictionary(Of String, Object)

    Public Sub AddChampLibre(ByVal champ As String, ByVal valeur As Object)
        If ChampsLibres Is Nothing Then ChampsLibres = New Dictionary(Of String, Object)
        If ChampsLibres.ContainsKey(champ) Then ChampsLibres.Remove(champ)
        ChampsLibres.Add(champ, valeur)
    End Sub

    Public Sub Insert(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Insert
        If nEntreprise < 0 Then nEntreprise = GetNextNEntreprise(conn)
        Dim sql As String = "INSERT INTO [Entreprise] ([nEntreprise], [DateCreation], [DateModification], [InfoMAJ], [Nom], [Adresse], [CodePostal], [Ville],[Pays], [Observations], [NCompteC], [NActiviteC],Critere1,Critere2,Critere3,Critere4,Civilite,SuffixePostal,Email,TypeClient,NTVAIntraCom) " & _
                            "VALUES({0}, '{1:dd/MM/yyyy HH:mm:ss}', '{2:dd/MM/yyyy HH:mm:ss}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})"
        sql = String.Format(sql, Me.ItemArray)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        'Debug.Print(com.CommandText)
        com.ExecuteNonQuery()


        If ChampsLibres IsNot Nothing Then
            For Each champ As String In Me.ChampsLibres.Keys
                sql = "UPDATE Entreprise Set [{0}]={1} WHERE [nEntreprise]={2}"
                com.CommandText = String.Format(sql, champ, FormatValeur(Me.ChampsLibres(champ)), Me.nEntreprise)
                'Debug.Print(com.CommandText)
                com.ExecuteNonQuery()
            Next
        End If

        InsertTel(conn, "Siege", Telephone)
        InsertTel(conn, "Fax", Fax)
        InsertTel(conn, "Portable", Portable)
    End Sub

    Private Sub InsertTel(ByVal conn As SqlClient.SqlConnection, ByVal type As String, ByVal num As String)
        Dim com As New SqlClient.SqlCommand("", conn)
        If num <> "" Then
            com.CommandText = String.Format("INSERT INTO TelephoneEntreprise VALUES ({0},'{1}',{2})", nEntreprise, type, FormatValeur(num))
            Debug.Print(com.CommandText)
            com.ExecuteNonQuery()
        End If
    End Sub

    Public Sub Update(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Update
        Dim sql As String = "UPDATE [Entreprise] SET " & _
                            "[DateCreation] = '{1:dd/MM/yyyy HH:mm:ss}', " & _
                            "[DateModification] = '{2:dd/MM/yyyy HH:mm:ss}', " & _
                            "[InfoMAJ]={3}, " & _
                            "[Nom]={4}, " & _
                            "[Adresse]={5}, " & _
                            "[CodePostal]={6}, " & _
                            "[Ville]={7}, " & _
                            "[Pays]={8}, " & _
                            "[Observations]={9}, " & _
                            "[NCompteC]={10}, " & _
                            "[NActiviteC]={11}, " & _
                            "[Critere1]={12}, " & _
                            "[Critere2]={13}, " & _
                            "[Critere3]={14}, " & _
                            "[Critere4]={15}, " & _
                            "[Civilite]={16}, " & _
                            "[SuffixePostal]={17}, " & _
                            "[Email]={18}, " & _
                            "[TypeClient]={19}, " & _
                            "[NTVAIntraCom]={20} " & _
                            "WHERE nEntreprise={0}"
        sql = String.Format(sql, Me.ItemArray)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()

        If ChampsLibres IsNot Nothing Then
            For Each champ As String In Me.ChampsLibres.Keys
                sql = "UPDATE Entrerpise Set [{0}]='{1}' WHERE [nEntreprise]={2}"
                com.CommandText = String.Format(sql, champ, FormatValeur(Me.ChampsLibres(champ)), Me.nEntreprise)
                com.ExecuteNonQuery()
            Next
        End If

        com.CommandText = String.Format("DELETE FROM TelephoneEntreprise WHERE nEntreprise={0}", nEntreprise)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()

        InsertTel(conn, "Siege", Telephone)
        InsertTel(conn, "Fax", Fax)
        InsertTel(conn, "Portable", Portable)
    End Sub

    Public Sub Delete(ByVal conn As SqlClient.SqlConnection) Implements IDataItem.Delete
        Dim com As New SqlClient.SqlCommand("", conn)
        com.CommandText = String.Format("DELETE FROM TelephoneEntreprise WHERE nEntreprise={0}", nEntreprise)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()

        com.CommandText = String.Format("DELETE FROM [Entreprise] WHERE nEntreprise={0}", nEntreprise)
        Debug.Print(com.CommandText)
        com.ExecuteNonQuery()
    End Sub

    Public Function GetNextNEntreprise(ByVal conn As SqlClient.SqlConnection) As Integer
        Dim sql As String = "select max(nentreprise) from entreprise"
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Dim res As Object = com.ExecuteScalar
        If IsDBNull(res) Then
            Return 1
        Else
            Return CInt(res) + 1
        End If
    End Function

    Public Function Exists(ByVal conn As SqlClient.SqlConnection) As Boolean Implements IDataItem.Exists
        Dim sql As String = String.Format("select count(*) from entreprise where nEntreprise={0}", nEntreprise)
        Dim com As New SqlClient.SqlCommand(sql, conn)
        Return CType(com.ExecuteScalar(), Integer) > 0
    End Function

    Private Function FormatValeur(ByVal valeur As Object, Optional ByVal valeurNull As String = "NULL") As String
        If valeur Is Nothing OrElse IsDBNull(valeur) Then
            Return valeurNull
        ElseIf TypeOf valeur Is Decimal Then
            Return valeur.ToString.Replace(",", ".")
        ElseIf TypeOf valeur Is Date Then
            Return String.Format("'{0:dd/MM/yyyy HH:mm:ss}'", valeur)
        ElseIf TypeOf valeur Is Boolean Then
            Return IIf(CBool(valeur), "1", "0")
        ElseIf TypeOf valeur Is String Then
            If valeur = "" Then : Return valeurNull
            Else : Return "'" & valeur.Replace("'", "''") & "'"
            End If
        Else
            Return valeur.ToString
        End If
    End Function

    Public ReadOnly Property NbCol() As Integer Implements IDataItem.NbCol
        Get
            Return NomCols.Length
        End Get
    End Property

    Public ReadOnly Property NomCols() As String() Implements IDataItem.NomCols
        Get
            Return New String() {"nEntreprise", "dateCreation", "dateModification", "InfoMaj", "nom", "adresse", "CodePostal", "Ville", "Pays", "Observations", "nCompteC", "nActiviteC", "Critere1", "Critere2", "Critere3", "Critere4", "Civilite", "SuffixePostal", "Email", "TypeClient", "NTVAIntraCom"}
        End Get
    End Property

    Public ReadOnly Property ItemArray() As Object() Implements IDataItem.ItemArray
        Get
            Return New Object() {nEntreprise, dateCreation, dateModification, FormatValeur(InfoMaj), FormatValeur(nom), FormatValeur(adresse), FormatValeur(CodePostal), _
                                FormatValeur(Ville), FormatValeur(Pays), FormatValeur(Observations), FormatValeur(nCompteC), FormatValeur(nActiviteC), FormatValeur(Critere1), FormatValeur(Critere2), _
                                FormatValeur(Critere3), FormatValeur(Critere4), FormatValeur(Civilite), FormatValeur(SuffixePostal), FormatValeur(Email), FormatValeur(TypeClient), FormatValeur(NTVAIntraCom)}
        End Get
    End Property
End Class
