Imports System.Windows.Forms

Public Class FrAssistantDemarrage

    Private ds As DataSet
    Private VDef As ValeurDefaultApplication
    Private VParam As ParametresApplication

#Region "Propriétés"
    Public Shared ReadOnly Property CleRegistre() As String
        Get
            Return String.Format("SOFTWARE\{0}\{1}", Application.CompanyName, Application.ProductName)
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "Page"
    Private Sub FrAssistantDemarrage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me, True)

        ChargerDonnees()
        With Me.CbTxTVA
            .DataSource = ds.Tables("TVA")
            .DisplayMember = "TLib"
            .ValueMember = "TTVA"
        End With

        With Me.CbTypeFacturation
            .DataSource = New DataView(ds.Tables("ListeChoix"), "NomChoix='ListeTypeFacturation'", "nOrdreValeur", DataViewRowState.CurrentRows)
            .DisplayMember = "Valeur"
            .ValueMember = "Valeur"
        End With

        VDef = FrApplication.ValeurDefault
        VParam = FrApplication.Parametres

        'Chargement Parametres base
        Me.TxNomSociete.Text = ParametresBase.GetValeur(ds, "EnTete", Nothing, "")
        Me.TxAdresseSociete.Text = ParametresBase.GetValeur(ds, "EnTeteDetail", Nothing, "")
        Me.TxEMail.Text = ParametresBase.GetValeur(ds, "EMail", Nothing, "")
        Me.TxTel.Text = ParametresBase.GetValeur(ds, "NTel", Nothing, "")
        Me.TxFax.Text = ParametresBase.GetValeur(ds, "NFax", Nothing, "")

        'Chargement Parametres appli
        With VParam
            Me.TxNPortModem.Text = .NPortModem.ToString
            Me.TxStandardModem.Text = .StandardModem
        End With

        'Chargement valeurs défaut
        With VDef
            Me.OptFacturationClientHT.Checked = Not .ClientFacturationTTC
            Me.OptFacturationClientTTC.Checked = .ClientFacturationTTC

            Me.OptFacturationAchatHT.Checked = Not .FournisseurFacturationTTC
            Me.OptFacturationAchatTTC.Checked = .FournisseurFacturationTTC

            Me.CbTxTVA.Text = .ProduitTxTVAVente
            Me.CbTypeFacturation.Text = .ProduitTypeFacturation

            Me.OptGestionStockNon.Checked = Not .ProduitGestionStock
            Me.OptGestionStockOui.Checked = .ProduitGestionStock

            Me.OptDecompteAutoNon.Checked = Not .ProduitDecompteStockAuto
            Me.OptDecompteAutoOui.Checked = .ProduitDecompteStockAuto

            Me.OptProduitAchatNon.Checked = Not .ProduitAchat
            Me.OptProduitAchatOui.Checked = .ProduitAchat

            Me.Tx1NFactureAchat.Text = Pieces.GetNFacture(Pieces.TypePieces.AFacture, True).ToString
            Me.Tx1NFactureAchat.Tag = Me.Tx1NFactureAchat.Text 'Pour tester si ca a été modifié
            Me.Tx1NFactureVente.Text = Pieces.GetNFacture(Pieces.TypePieces.VFacture, True).ToString
            Me.Tx1NFactureVente.Tag = Me.Tx1NFactureVente.Text 'Pour tester si ca a été modifié

            Me.TxNCompteClient.Text = .ClientNCompte
            Me.TxNActiviteClient.Text = .ClientNActivite
            Me.TxNCompteFournisseur.Text = .FournisseurNCompte
            Me.TxNActiviteFournisseur.Text = .FournisseurNActivite
            Me.TxNCompteProduitV.Text = .ProduitNCompteV
            Me.TxNActiviteProduitV.Text = .ProduitNActiviteV
            Me.TxNCompteProduitAchat.Text = .ProduitNCompteA
            Me.TxNActiviteProduitAchat.Text = .ProduitNActiviteA

            Me.OptNCompteClientAutoOui.Checked = .ClientNCompteAuto
            Me.OptNCompteClientAutoNon.Checked = Not .ClientNCompteAuto

            Me.OptNCompteFournisseurAutoOui.Checked = .FournisseurNCompteAuto
            Me.OptNCompteFournisseurAutoNon.Checked = Not .FournisseurNCompteAuto

            Me.OptNCompteProduitAAutoOui.Checked = .ProduitNCompteAAuto
            Me.OptNCompteProduitAAutoNon.Checked = Not .ProduitNCompteAAuto

            Me.OptNCompteProduitVAutoOui.Checked = .ProduitNCompteVAuto
            Me.OptNCompteProduitVAutoNon.Checked = Not .ProduitNCompteVAuto
        End With

        Me.wpFourn.Visible = FrApplication.Modules.ModuleAchat
        Me.wpProdsAchats.Visible = FrApplication.Modules.ModuleAchat
        Me.PnlProduitAchat.Visible = FrApplication.Modules.ModuleAchat
        Me.PnlComptaFournisseur.Visible = FrApplication.Modules.ModuleAchat
        Me.pnlFactAchat.Visible = FrApplication.Modules.ModuleAchat
    End Sub
#End Region

#Region "WizardTemplate"
    Private Sub wt_FinishClick() Handles wt.FinishClick
        Dim dtParams As DataTable = ds.Tables("Parametres")
        ParametresBase.SetValeur(dtParams, "EnTete", Nothing, Me.TxNomSociete.Text)
        ParametresBase.SetValeur(dtParams, "EnTeteDetail", Nothing, Me.TxAdresseSociete.Text)
        ParametresBase.SetValeur(dtParams, "EMail", Nothing, Me.TxEMail.Text)
        ParametresBase.SetValeur(dtParams, "NTel", Nothing, Me.TxTel.Text)
        ParametresBase.SetValeur(dtParams, "NFax", Nothing, Me.TxFax.Text)
        Using s As New SqlProxy
            s.UpdateTable(ds, "Parametres")
        End Using

        With VParam
            Try
                .NPortModem = Int16.Parse(Me.TxNPortModem.Text)
            Catch
            End Try
            .StandardModem = Me.TxStandardModem.Text
            .Enregistrer()
        End With

        With VDef
            .ClientFacturationTTC = Me.OptFacturationClientTTC.Checked
            .FournisseurFacturationTTC = Me.OptFacturationAchatTTC.Checked

            .ProduitTxTVAVente = Me.CbTxTVA.Text
            .ProduitTypeFacturation = Me.CbTypeFacturation.Text
            .ProduitGestionStock = Me.OptGestionStockOui.Checked
            .ProduitDecompteStockAuto = Me.OptDecompteAutoOui.Checked
            .ProduitAchat = Me.OptProduitAchatOui.Checked

            Try
                If Me.Tx1NFactureVente.Tag.ToString <> Me.Tx1NFactureVente.Text Then
                    .FacturationClient1 = Integer.Parse(Me.Tx1NFactureVente.Text)
                    Pieces.SetNFacture("VFacture", VDef.FacturationClient1)
                End If
            Catch
            End Try
            Try
                If Me.Tx1NFactureAchat.Tag.ToString <> Me.Tx1NFactureAchat.Text Then
                    .FacturationFournisseur1 = Integer.Parse(Me.Tx1NFactureAchat.Text)
                    Pieces.SetNFacture("AFacture", VDef.FacturationFournisseur1)
                End If
            Catch
            End Try

            .ClientNCompte = Me.TxNCompteClient.Text
            .ClientNActivite = Me.TxNActiviteClient.Text
            .FournisseurNCompte = Me.TxNCompteFournisseur.Text
            .FournisseurNActivite = Me.TxNActiviteFournisseur.Text
            .ProduitNCompteV = Me.TxNCompteProduitV.Text
            .ProduitNActiviteV = Me.TxNActiviteProduitV.Text
            .ProduitNCompteA = Me.TxNCompteProduitAchat.Text
            .ProduitNActiviteA = Me.TxNActiviteProduitAchat.Text

            .ClientNCompteAuto = Me.OptNCompteClientAutoOui.Checked
            .FournisseurNCompteAuto = Me.OptNCompteFournisseurAutoOui.Checked
            .ProduitNCompteAAuto = Me.OptNCompteProduitAAutoOui.Checked
            .ProduitNCompteVAuto = Me.OptNCompteProduitVAutoOui.Checked

            .Enregistrer()
        End With

        'CreerUtilisateur()
        MarquerAssistantPasse()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub wt_CancelClick() Handles wt.CancelClick
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        ds = New DataSet
        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "TVA", s)
            DefinitionDonnees.Instance.Fill(ds, "ListeChoix", s)
            DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
        End Using
    End Sub

    Private Sub CreerUtilisateur()
        'Vérifier le contenu des zones de texte
        Me.TxLogin.Text = Me.TxLogin.Text.Trim
        Me.TxPwd.Text = Me.TxPwd.Text.Trim
        Me.TxNom.Text = Me.TxNom.Text.Trim
        Me.TxPrenom.Text = Me.TxPrenom.Text.Trim

        If Me.TxLogin.Text.Length = 0 Then Exit Sub

        'Récupérer les infos de connexion
        Dim serveur As String = CStr(ParametresApplication.ValeurParametre("ServeurSQL"))
        Dim base As String = CStr(ParametresApplication.ValeurParametre("BASESQL"))
        Dim login As String = "sa"
        Dim pwd As String = CStr(ParametresApplication.ValeurParametre("saPwd"))

        'On ne se bousille pas son propre login
        If Me.TxLogin.Text <> FrApplication.Utilisateur Then
            'Opération de base de données pour déclarer l'utilisateur
            Dim cn As New SqlClient.SqlConnection(String.Format("initial catalog={0};data source={1};user id={2};password={3};persist security info=True", base, serveur, login, pwd))
            cn.Open()
            Dim cmd As New SqlClient.SqlCommand("", cn)

            'Supprimer le user et le login de la base
            '* Supprimer l'Utilisateur des roles
            Try
                cmd.CommandText = "Exec sp_droprolemember 'Utilisateurs','" & Me.TxLogin.Text & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            '* Supprimer l'Utilisateur de la base
            Try
                cmd.CommandText = "Exec sp_dropuser '" & Me.TxLogin.Text & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            '* Supprimer la connexion Sql Server
            Try
                'Tuer les connexions existantes
                cmd.CommandText = "Exec sp_who '" & Me.TxLogin.Text & "'"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim spids As New ArrayList
                While dr.Read
                    spids.Add(dr("spid"))
                End While
                dr.Close()

                For Each spid As String In spids
                    cmd.CommandText = "KILL " & spid
                    cmd.ExecuteNonQuery()
                Next

                cmd.CommandText = "Exec sp_droplogin '" & Me.TxLogin.Text & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            'Créer le user et le login
            Try
                Try
                    '* Creation Nouvelle Connexion au server
                    cmd.CommandText = "Exec sp_addlogin @loginame='" & Me.TxLogin.Text & "',@passwd='" & Me.TxPwd.Text & "',@defdb=" & base
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                End Try

                '* Creation de l'Utilisateur dans la base de données
                cmd.CommandText = "Exec sp_adduser @loginame='" & Me.TxLogin.Text & "',@name_in_db='" & Me.TxLogin.Text & "'"
                cmd.ExecuteNonQuery()

                '* Ajout de l'utilisateur du role utilisateurs
                cmd.CommandText = "Exec sp_addrolemember 'Utilisateurs','" & Me.TxLogin.Text & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            cn.Close()

            VParam.LastLogin = Me.TxLogin.Text
        End If


        'Renseignement des tables Utilisateurs et Personne dans la base
        Dim dvU As New DataView(ds.Tables("Utilisateurs"), "Utilisateur='" & Me.TxLogin.Text & "'", "", DataViewRowState.CurrentRows)
        If dvU.Count = 0 Then
            'Si le login n'existe pas dans la base
            'Déterminer un ID de personne
            Dim nPersonne As Integer = 1
            Dim o As Object = ds.Tables("Personne").Compute("Max(nPersonne)", "nPersonne<1000")
            If Not IsDBNull(o) Then
                nPersonne = CInt(o) + 1
            End If

            'Créer la ligne dans Personne
            Dim drP As DataRow = ds.Tables("Personne").NewRow
            drP("nPersonne") = nPersonne
            drP("Nom") = Me.TxNom.Text
            drP("Prenom") = Me.TxPrenom.Text
            ds.Tables("Personne").Rows.Add(drP)

            'Créer la ligne dans Utilisateur
            Dim dr As DataRow = dvU.Table.NewRow
            dr("Utilisateur") = Me.TxLogin.Text
            dr("Password") = Me.TxPwd.Text
            dr("nPersonne") = nPersonne
            dr("Departement") = "Tous"
            dr("nGroupe") = 1
            dvU.Table.Rows.Add(dr)
        Else
            'Mettre à jour Utilisateur seulement s'il s'agit d'un autre utilisateur
            If Me.TxLogin.Text <> FrApplication.Utilisateur Then
                dvU(0).Item("Password") = Me.TxPwd.Text
                dvU(0).EndEdit()
            End If

            'Mettre à jour Personne
            Dim dvP As New DataView(ds.Tables("Personne"), "nPersonne=" & CStr(dvU(0).Item("nPersonne")), "", DataViewRowState.CurrentRows)
            If dvP.Count > 0 Then
                dvP(0)("Nom") = Me.TxNom.Text
                dvP(0)("Prenom") = Me.TxPrenom.Text
                dvP(0).EndEdit()
            Else
                Dim drP As DataRow = ds.Tables("Personne").NewRow
                drP("nPersonne") = dvU(0).Item("nPersonne")
                drP("Nom") = Me.TxNom.Text
                drP("Prenom") = Me.TxPrenom.Text
                ds.Tables("Personne").Rows.Add(drP)
            End If
        End If

        'Mise à jour de la base de données
        Using s As New SqlProxy
            s.UpdateTables(Me.ds, New String() {"Personne", "Utilisateur"})
        End Using
    End Sub

    Private Sub MarquerAssistantPasse()
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(CleRegistre, True)
        If key Is Nothing Then
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(CleRegistre)
        End If
        key.SetValue("AssistantDemarrage", "OK")
        key.Close()
    End Sub
#End Region

End Class
