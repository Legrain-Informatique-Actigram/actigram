Public Class Utilisateur
    Public Nom As String = ""
    Public Prenom As String = ""
    Public Login As String = ""
    Public Pwd As String = ""
    Public Departement As String = "Tous"
    Public nPersonne As String = ""
    Public nGroupe As String = ""

    Public Sub New()

    End Sub

    Public Sub New(ByVal rw As DataRow)
        InitValues(rw)
    End Sub

    Private Sub InitValues(ByVal rw As DataRow)
        Login = Convert.ToString(rw.Item("Utilisateur"))
        Pwd = Convert.ToString(rw.Item("Password"))
        nPersonne = Convert.ToString(rw.Item("nPersonne"))
        Departement = Convert.ToString(rw.Item("Departement"))
        nGroupe = Convert.ToString(rw.Item("nGroupe"))
        Nom = Convert.ToString(rw.Item("Nom"))
        Prenom = Convert.ToString(rw.Item("Prenom"))
    End Sub

    Public Shared Function [Select](ByVal cn As SqlClient.SqlConnection) As DataTable
        Dim conn As New SqlProxy(cn)
        Return conn.ExecuteDataTable("Select U.*,P.Nom,P.Prenom From Utilisateurs U Inner Join Personne P On U.nPersonne=P.nPersonne")
    End Function

    Public Sub Supprimer(ByVal cn As SqlClient.SqlConnection)
        Dim conn As New SqlProxy(cn)
        Try
            conn.ExecuteNonQuery("BEGIN TRANSACTION")

            '* Supprimer la liste des Entreprises
            Try
                conn.ExecuteNonQuery("Drop Table [ListeEntreprise" & Nom & "]")
            Catch
            End Try

            '* Supprimer Les Telephones
            conn.ExecuteNonQuery("Delete From Telephone Where nPersonne=" & nPersonne)
            '* Supprimer l'utilisateur
            conn.ExecuteNonQuery("Delete From Utilisateurs Where Utilisateur='" & Login & "'")
            '* Supprimer la Personne
            Try
                conn.ExecuteNonQuery("Delete From Personne Where nPersonne=" & nPersonne)
            Catch ex As SqlClient.SqlException
                If ex.Number = 547 Then
                    'On n'a pas pu supprimer la personne suite à une erreur d'intégrité, mais on continue
                    'pour que l'utilisateur soit bien supprimé (plus d'accès à l'appli)                    
                Else
                    Throw ex
                End If
            End Try
            conn.ExecuteNonQuery("COMMIT TRANSACTION")
        Catch ex As Exception
            conn.ExecuteNonQuery("ROLLBACK TRANSACTION")
            Throw ex
        End Try

        'Les procédures systeme ne peuvent pas s'executer dans une transaction
        '* Supprimer l'Utilisateur des roles
        conn.ExecuteNonQuery("Exec sp_droprolemember 'Utilisateurs','" & Login & "'")
        '* Supprimer l'Utilisateur de la base
        conn.ExecuteNonQuery("Exec sp_dropuser '" & Login & "'")
        Try
            '* Supprimer la connexion Sql Server
            conn.ExecuteNonQuery("Exec sp_droplogin '" & Login & "'")
        Catch ex As SqlClient.SqlException
            'Ne pas bloquer sur l'erreur "alias ou utilisateurs sur d'autres bases"
            If ex.Number <> 15175 Then Throw ex
        End Try
    End Sub

    Public Sub CreerUtilisateur(ByVal cn As SqlClient.SqlConnection)
        Dim conn As New SqlProxy(cn)

        '* Insertion Personne
        Me.nPersonne = CreerPersonne(conn, Me.Nom, Me.Prenom)

        '* Insertion Utilisateur : Normalement le groupe existe car la saisie est restreinte
        conn.ExecuteNonQuery("Insert Into Utilisateurs (Utilisateur,Password,Departement,nPersonne,nGroupe) Values ('" & Me.Login & "','" & Me.Pwd & "','" & Me.Departement & "'," & Me.nPersonne & "," & Me.nGroupe & ")")

        '* Creation Nouvelle Connexion au server
        RecreerUtilisateur(conn, Me.Login, Me.Pwd, CStr(FrGestionParametres.ValeurParametre("BASESQL", "")))

    End Sub

    Private Function CreerPersonne(ByVal conn As SqlProxy, ByVal nom As String, ByVal prenom As String) As String
        Dim oResult As Object = conn.ExecuteScalar("Select Max(nPersonne) From Personne Where nPersonne<1000")
        Dim nPersonne As String = "1"
        If Not IsDBNull(oResult) Then
            nPersonne = (CInt(oResult) + 1).ToString
        End If

        '* Insertion Personne
        conn.ExecuteNonQuery("Insert Into Personne (nPersonne,Nom,Prenom) Values (" & nPersonne & ",'" & nom & "','" & prenom & "')")

        '* Insertion Tel Personne
        conn.ExecuteNonQuery("Insert Into Telephone (nPersonne,Type,Numero) Values (" & nPersonne & ",'Portable','')")

        Return nPersonne
    End Function

    Private Sub RecreerUtilisateur(ByRef cn As SqlProxy, ByVal Utilisateur As String, ByVal Password As String, ByVal BaseSql As String)
        If CInt(cn.ExecuteScalar("select count(*) from master.dbo.syslogins where name='" & Utilisateur & "'")) = 0 Then
            'Si le login n'existe pas, le créer
            cn.ExecuteNonQuery(String.Format("Exec sp_addlogin @loginame=N'{0}',@passwd=N'{1}',@defdb={2}", Utilisateur, Password, BaseSql))
        Else
            'Sinon MAJ son Password
            cn.ExecuteNonQuery(String.Format("Exec sp_password NULL, '{1}', '{0}'", Utilisateur, Password))
        End If

        'Si l'utilisateur de BDD existe, le supprimer
        Try
            cn.ExecuteNonQuery(String.Format("Exec sp_dropuser '{0}'", Utilisateur))
        Catch ex As SqlClient.SqlException
            If ex.Number <> 15008 Then Throw ex
        End Try

        'Créer le user dans la base dans le groupe "Utilisateurs"
        cn.ExecuteNonQuery(String.Format("Exec sp_adduser '{0}','{0}','{1}'", Utilisateur, "Utilisateurs"))
    End Sub

    Public Sub ModifierUtilisateur(ByVal cn As SqlClient.SqlConnection, ByVal oldPwd As String)
        Dim conn As New SqlProxy(cn)
        conn.ExecuteNonQuery("Update Utilisateurs Set Password='" & Me.Pwd & "',Departement='" & Me.Departement & "',nGroupe='" & Me.nGroupe & "' Where Utilisateur='" & Me.Login & "' And Password='" & oldPwd & "'")

        If Me.Pwd <> oldPwd Then
            RecreerUtilisateur(conn, Me.Login, Me.Pwd, CStr(FrGestionParametres.ValeurParametre("BASESQL", "")))
        End If

    End Sub

End Class

Public Class Role
    Public nGroupe As String = ""
    Public Groupe As String = ""
    Public Data As DataRow

    Public Sub New()

    End Sub

    Public Sub New(ByVal nGroupe As Object, ByVal Groupe As Object)
        Me.New()
        If Not IsDBNull(nGroupe) Then Me.nGroupe = CStr(nGroupe)
        If Not IsDBNull(Groupe) Then Me.Groupe = CStr(Groupe)
    End Sub

    Public Sub New(ByVal rw As DataRow)
        Me.New(rw.Item("nGroupeAutorisation"), rw.Item("Groupe"))
        Data = rw
    End Sub

    Public Shared Function [Select](ByVal cn As SqlClient.SqlConnection) As DataTable
        Dim ds As New DataSet
        Dim dta As New SqlClient.SqlDataAdapter("Select * From Autorisations", cn)
        dta.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Sub Supprimer(ByVal cn As SqlClient.SqlConnection)
        Dim conn As New SqlProxy(cn)
        Dim nUtils As Integer = CInt(conn.ExecuteScalar("Select count(*) From Utilisateurs Where nGroupe=" & nGroupe))
        If nUtils > 0 Then
            Throw New Exception("Ce groupe ne peut pas être supprimé car des utilisateurs en font partie.")
        Else
            conn.ExecuteNonQuery("Delete From Autorisations Where nGroupeAutorisation=" & nGroupe)
        End If
    End Sub

    Public Sub ModifRole(ByVal cn As SqlClient.SqlConnection, ByVal autorisations As Hashtable)
        Dim values As New ArrayList
        values.Add("Groupe='" & Me.Groupe & "'")

        For Each k As String In autorisations.Keys
            values.Add(k & "=" & CStr(IIf(CBool(autorisations(k)), "1", "0")))
        Next

        Dim strValues(values.Count - 1) As String
        values.CopyTo(strValues)

        Dim strSql As String = String.Format("Update Autorisations Set {0} Where nGroupeAutorisation={1}", String.Join(", ", strValues), Me.nGroupe)

        Dim conn As New SqlProxy(cn)
        conn.ExecuteNonQuery(strSql)
    End Sub

    Public Sub CreerRole(ByVal cn As SqlClient.SqlConnection, ByVal autorisations As Hashtable)
        Dim champs As New ArrayList
        champs.Add("nGroupeAutorisation")
        champs.Add("Groupe")

        Dim values As New ArrayList
        values.Add(Me.nGroupe)
        values.Add("'" & Me.Groupe & "'")

        For Each k As String In autorisations.Keys
            champs.Add(k)
            values.Add(IIf(CBool(autorisations(k)), "1", "0"))
        Next

        Dim strChamps(champs.Count - 1) As String
        champs.CopyTo(strChamps)
        Dim strValues(values.Count - 1) As String
        values.CopyTo(strValues)

        Dim strSql As String = String.Format("Insert Into Autorisations ({0}) Values ({1})", String.Join(", ", strChamps), String.Join(", ", strValues))
        Dim conn As New SqlProxy(cn)
        conn.ExecuteNonQuery(strSql)
    End Sub
End Class


Public Class ParamNiveau2
    Public nNiveau1 As String = ""
    Public nNiveau2 As String = ""
    Public Table As String = ""
    Public Champs As String = ""
    Public Libelle As String = ""
    Public ListeChoix As String = ""
    Public IsObligatoire As String = ""
    Public Visible As String = ""
    Public FormulaireRecherche As String = ""
    Public ResultatRecherche As String = ""

    Public Data As DataRow

    Public Sub New(ByVal rw As DataRow)
        Data = rw
        nNiveau1 = Convert.ToString(rw.Item("nNiveau1"))
        nNiveau2 = Convert.ToString(rw.Item("nNiveau2"))
        Table = Convert.ToString(rw.Item("Table"))
        Champs = Convert.ToString(rw.Item("Champs"))
        Libelle = Convert.ToString(rw.Item("Libelle"))
        ListeChoix = Convert.ToString(rw.Item("ListeChoix"))

        Visible = CStr(IIf(Not CBool(rw.Item("NpAfficherFormulaire")), "X", ""))
        FormulaireRecherche = CStr(IIf(CBool(rw.Item("AfficherFormulaireRecherche")), "X", ""))
        ResultatRecherche = CStr(IIf(CBool(rw.Item("AfficherRecherche")), "X", ""))
        IsObligatoire = CStr(IIf(CBool(rw.Item("IsObligatoire")), "X", ""))

    End Sub

    Public Shared Function [Select](ByVal XPEnCours As FrAdmin.MenuEnCours, ByVal cn As SqlClient.SqlConnection) As DataTable
        Dim ds As New DataSet
        Dim dta As New SqlClient.SqlDataAdapter("Select * From Niveau2 Where [Table]='" & NomTableSql(XPEnCours) & "' Order By nNiveau1,nNiveau2", cn)
        dta.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Shared Function NomTableSql(ByVal XPEnCours As FrAdmin.MenuEnCours) As String
        Select Case XPEnCours
            Case FrAdmin.MenuEnCours.Organisme : Return "Entreprise"
            Case FrAdmin.MenuEnCours.Contact : Return "Personne"
            Case FrAdmin.MenuEnCours.Evenement : Return "Evenement"
            Case FrAdmin.MenuEnCours.Produit : Return "Produit"
            Case FrAdmin.MenuEnCours.VDevis : Return "VDevis"
            Case FrAdmin.MenuEnCours.Lot : Return "Lot"
            Case FrAdmin.MenuEnCours.GroupeArticle : Return "Groupe"
            Case FrAdmin.MenuEnCours.Famille : Return "Famille"
            Case FrAdmin.MenuEnCours.Mouvement : Return "Mouvement"
            Case FrAdmin.MenuEnCours.ABonReception : Return "ABonReception"
            Case FrAdmin.MenuEnCours.AFacture : Return "AFacture"
            Case FrAdmin.MenuEnCours.VBonCommande : Return "VBonCommande"
            Case FrAdmin.MenuEnCours.VBonLivraison : Return "VBonLivraison"
            Case FrAdmin.MenuEnCours.VFacture : Return "VFacture"
            Case FrAdmin.MenuEnCours.Banque : Return "Banque"
            Case FrAdmin.MenuEnCours.VReglement : Return "Reglement"
            Case FrAdmin.MenuEnCours.AReglement : Return "AReglement"
            Case FrAdmin.MenuEnCours.VRemise : Return "Remise"
            Case Else : Return ""
        End Select
    End Function


    Public Sub Supprimer(ByVal cn As SqlClient.SqlConnection)
        Try

            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlClient.SqlCommand("Select * From [" & Table & "] Where Not [" & Champs & "] Is Null", cn)
            If cmd.ExecuteNonQuery = -1 Then
                Dim strSql As String
                strSql = "Alter Table [" & Table & "]" & vbCrLf
                strSql += "Drop Column [" & Champs & "]"
                cmd.CommandText = strSql
                cmd.ExecuteNonQuery()
            End If

            cmd.CommandText = "Delete From Niveau2 Where nNiveau1=" & nNiveau1 & " And nNiveau2=" & nNiveau2
            cmd.ExecuteNonQuery()

            MessageBox.Show("Suppression Réussi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub Monter(ByVal cn As SqlClient.SqlConnection)
        Dim ds As New DataSet
        Dim dta As New SqlClient.SqlDataAdapter("Select Top 1 * From Niveau2 Where [Table]='" & Table & "' And nNiveau1=" & nNiveau1 & " And nNiveau2<" & nNiveau2 & " Order By nNiveau1,nNiveau2 Desc", cn)
        dta.Fill(ds)
        Dim nNiveauDepart As String = nNiveau2
        Dim nNiveauArrive As String
        If ds.Tables(0).Rows.Count > 0 Then
            nNiveauArrive = Convert.ToString(ds.Tables(0).Rows(0).Item("nNiveau2"))
            ds.Tables(0).Rows(0).Item("nNiveau2") = -1
            '* Deplace la ligne destination
            Dim Cmd As New SqlClient.SqlCommand("UpDate Niveau2 Set nNiveau2=-1 Where nNiveau1=" & nNiveau1 & " And nNiveau2=" & nNiveauArrive, cn)
            Cmd.ExecuteNonQuery()
            '* Deplace La ligne en cours
            Cmd.CommandText = "UpDate Niveau2 Set nNiveau2=" & nNiveauArrive & " Where nNiveau1=" & nNiveau1 & " And nNiveau2=" & nNiveau2
            Cmd.ExecuteNonQuery()
            '* Replace la ligne destination
            Cmd.CommandText = "UpDate Niveau2 Set nNiveau2=" & nNiveauDepart & " Where nNiveau1=" & nNiveau1 & " And nNiveau2=-1"
            Cmd.ExecuteNonQuery()
        End If
    End Sub

    Public Sub Descendre(ByVal cn As SqlClient.SqlConnection)
        Dim ds As New DataSet
        Dim dta As New SqlClient.SqlDataAdapter("Select Top 1 * From Niveau2 Where [Table]='" & Table & "' And nNiveau1=" & nNiveau1 & " And nNiveau2>" & nNiveau2 & " Order By nNiveau1,nNiveau2", cn)
        dta.Fill(ds)
        Dim nNiveauDepart As String = nNiveau2
        Dim nNiveauArrive As String
        If ds.Tables(0).Rows.Count > 0 Then
            nNiveauArrive = Convert.ToString(ds.Tables(0).Rows(0).Item("nNiveau2"))
            ds.Tables(0).Rows(0).Item("nNiveau2") = -1
            '* Deplace la ligne destination
            Dim Cmd As New SqlClient.SqlCommand("UpDate Niveau2 Set nNiveau2=-1 Where nNiveau1=" & nNiveau1 & " And nNiveau2=" & nNiveauArrive, cn)
            Cmd.ExecuteNonQuery()
            '* Deplace La ligne en cours
            Cmd.CommandText = "UpDate Niveau2 Set nNiveau2=" & nNiveauArrive & " Where nNiveau1=" & nNiveau1 & " And nNiveau2=" & nNiveau2
            Cmd.ExecuteNonQuery()
            '* Replace la ligne destination
            Cmd.CommandText = "UpDate Niveau2 Set nNiveau2=" & nNiveauDepart & " Where nNiveau1=" & nNiveau1 & " And nNiveau2=-1"
            Cmd.ExecuteNonQuery()
        End If
    End Sub

End Class