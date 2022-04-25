Imports System.Data.SqlClient

Public Class FrAccueil

#Region "Page"
    Private Sub FrAccueil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Visible = False
    End Sub
#End Region

#Region "Bouton"
    Private Sub ButtonLancerImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLancerImport.Click
        Dim cheminFichierExcel As String = String.Empty

        Try
            With Me.OpenFileDialogChoixFichierExcel
                .Filter = "Fichiers Excel (*.xls)|*.xls"
                .Multiselect = False
                .FileName = ""
                .Title = "Choisir une source de données au format Excel."

                If .ShowDialog = DialogResult.OK Then
                    cheminFichierExcel = .FileName
                End If
            End With

            If (cheminFichierExcel <> String.Empty) Then
                Cursor.Current = Cursors.WaitCursor
                Me.ProgressBar1.Visible = True

                Me.LancerImport(cheminFichierExcel)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            Me.ProgressBar1.Visible = False
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LancerImport(ByVal cheminFichierExcel As String)
        Dim connStringExcel As String = String.Empty
        Dim connStringAgrifact As String = String.Empty
        Dim i As Integer = 0
        Dim sqlTran As SqlTransaction = Nothing

        connStringExcel = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                        "Data Source=" & cheminFichierExcel & ";" & _
                        "Extended Properties=""Excel 8.0;HDR=YES"""

        connStringAgrifact = Me.SqlConnectionConfig1.ConnectionStringBuilder.ConnectionString

        'Vérification des connexions définies
        If Not (Utilitaires.SqlProxy.TestConnection(connStringAgrifact)) Then
            MsgBox("Impossible de se connecter à la base de données Agrifact", MsgBoxStyle.Exclamation, "Connexion impossible")

            Exit Sub
        End If

        If Not (Utilitaires.SqlProxy.TestConnectionExcel(connStringExcel)) Then
            MsgBox("Impossible de se connecter à la source de données Excel", MsgBoxStyle.Exclamation, "Connexion impossible")

            Exit Sub
        End If

        Utilitaires.BaseUtils.SetConnString("AgrifactConnectionString", connStringAgrifact)
        Utilitaires.BaseUtils.SetConnString("EntrepriseImportExcelConnectionString", connStringExcel)

        'Suppression des données dans les tables si nécessaire
        If (Me.CheckBoxVider.Checked) Then
            Me.ViderTables()
        End If

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            sqlConn.Open()

            sqlTran = sqlConn.BeginTransaction("Ajouter_Infos_Entreprises")

            Try
                Using entImportExcelTableAdapter As New DataSetAgrifactTableAdapters.Feuil1_TableAdapter
                    Dim entImportExcelDataTable As DataSetAgrifact._Feuil1_DataTable = entImportExcelTableAdapter.GetData()

                    Using entTableAdapter As New DataSetAgrifactTableAdapters.EntrepriseTableAdapter
                        entTableAdapter.Connection = sqlConn
                        entTableAdapter.Transaction = sqlTran

                        'Vérifie que la table Entreprise est vide
                        If (entTableAdapter.CountnEntreprise() > 0) Then
                            If (MsgBox("La table Entreprise n'est pas vide. Voulez-vous continuer ?", MsgBoxStyle.YesNo, "Table non vide") = MsgBoxResult.No) Then

                                Exit Sub
                            End If
                        End If

                        Using telEntTableAdapter As New DataSetAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
                            telEntTableAdapter.Connection = sqlConn
                            telEntTableAdapter.Transaction = sqlTran

                            Using persTableAdapter As New DataSetAgrifactTableAdapters.PersonneTableAdapter
                                persTableAdapter.Connection = sqlConn
                                persTableAdapter.Transaction = sqlTran

                                For Each entImportExcelRow As DataSetAgrifact._Feuil1_Row In entImportExcelDataTable.Rows
                                    '----CR2ATION Entreprise

                                    'Recherche le nEntreprise max dans la table Entreprise
                                    Dim nEntreprise As Decimal = Convert.ToDecimal(entTableAdapter.MaxnEntreprise()) + 1
                                    Dim dateCreation As Date = Now

                                    Dim nom As String = Nothing
                                    If Not (entImportExcelRow.IsNomNull) Then
                                        nom = entImportExcelRow.Nom
                                    End If

                                    If (entImportExcelRow.Nom = "AZUR ROULEMENTS ") Then
                                        Dim test As String = String.Empty
                                    End If

                                    Dim adresse As String = Nothing
                                    If Not (entImportExcelRow.IsAdresseNull) Then
                                        adresse = Replace(entImportExcelRow.Adresse, Chr(13), Microsoft.VisualBasic.vbCrLf)
                                        adresse = Replace(entImportExcelRow.Adresse, Chr(10), Microsoft.VisualBasic.vbCrLf)
                                    End If

                                    Dim codePostal As String = Nothing
                                    If Not (entImportExcelRow.IsCodePostalNull) Then
                                        If (entImportExcelRow.CodePostal.Length = 4) Then
                                            codePostal = "0" & entImportExcelRow.CodePostal
                                        Else
                                            codePostal = entImportExcelRow.CodePostal
                                        End If
                                    End If

                                    Dim ville As String = Nothing
                                    If Not (entImportExcelRow.IsVilleNull) Then
                                        ville = entImportExcelRow.Ville
                                    End If

                                    Dim pays As String = Nothing
                                    If Not (entImportExcelRow.IsPaysNull) Then
                                        pays = entImportExcelRow.Pays
                                    End If

                                    Dim typeClient As String = Nothing
                                    If Not (entImportExcelRow.IsTypeClientNull) Then
                                        typeClient = entImportExcelRow.TypeClient
                                    End If

                                    Dim email1 As String = Nothing
                                    If Not (entImportExcelRow.IsEmail1Null) Then
                                        email1 = entImportExcelRow.Email1
                                    End If

                                    Dim civilite As String = Nothing
                                    If Not (entImportExcelRow.IsCiviliteNull) Then
                                        civilite = entImportExcelRow.Civilite
                                    End If

                                    Dim nTVAIntraCom As String = Nothing
                                    If Not (entImportExcelRow.IsNTVAIntraComNull) Then
                                        nTVAIntraCom = entImportExcelRow.NTVAIntraCom
                                    End If

                                    Dim observations As String = Nothing
                                    If Not (entImportExcelRow.IsObservationsNull) Then
                                        observations = entImportExcelRow.Observations
                                    End If

                                    Dim critere1 As String = Nothing
                                    If Not (entImportExcelRow.IsCritere1Null) Then
                                        critere1 = entImportExcelRow.Critere1
                                    End If

                                    Dim critere2 As String = Nothing
                                    If Not (entImportExcelRow.IsCritere2Null) Then
                                        critere2 = entImportExcelRow.Critere2
                                    End If

                                    Dim critere3 As String = Nothing
                                    If Not (entImportExcelRow.IsCritere3Null) Then
                                        critere3 = entImportExcelRow.Critere3
                                    End If

                                    Dim critere4 As String = Nothing
                                    If Not (entImportExcelRow.IsCritere4Null) Then
                                        critere4 = entImportExcelRow.Critere4
                                    End If

                                    Dim cibleCommerciale As String = Nothing
                                    If Not (entImportExcelRow.IsCibleCommercialNull) Then
                                        cibleCommerciale = entImportExcelRow.CibleCommercial
                                    End If

                                    'Création dans la table Entreprise
                                    entTableAdapter.InsertReduit(nEntreprise, dateCreation, nom, adresse, codePostal, _
                                                                 ville, pays, typeClient, civilite, nTVAIntraCom, observations, _
                                                                 email1, critere1, critere2, critere3, critere4, cibleCommerciale)

                                    '----CREATION TelephoneEntreprise
                                    If Not (entImportExcelRow.IsTelephone1Null) Then
                                        If (Microsoft.VisualBasic.Left(entImportExcelRow.Telephone1, 1) <> "0" And Not (String.IsNullOrEmpty(entImportExcelRow.Telephone1))) Then
                                            telEntTableAdapter.Insert(nEntreprise, "Téléphone1", "0" & entImportExcelRow.Telephone1)
                                        Else
                                            telEntTableAdapter.Insert(nEntreprise, "Téléphone1", entImportExcelRow.Telephone1)
                                        End If
                                    End If

                                    If Not (entImportExcelRow.IsTelephone2Null) Then
                                        If (Microsoft.VisualBasic.Left(entImportExcelRow.Telephone2, 1) <> "0" And Not (String.IsNullOrEmpty(entImportExcelRow.Telephone2))) Then
                                            telEntTableAdapter.Insert(nEntreprise, "Téléphone2", "0" & entImportExcelRow.Telephone2)
                                        Else
                                            telEntTableAdapter.Insert(nEntreprise, "Téléphone2", entImportExcelRow.Telephone2)
                                        End If
                                    End If

                                    If Not (entImportExcelRow.IsPortableNull) Then
                                        If (Microsoft.VisualBasic.Left(entImportExcelRow.Telephone2, 1) <> "0" And Not (String.IsNullOrEmpty(entImportExcelRow.Telephone2))) Then
                                            telEntTableAdapter.Insert(nEntreprise, "Portable", "0" & entImportExcelRow.Portable)
                                        Else
                                            telEntTableAdapter.Insert(nEntreprise, "Portable", entImportExcelRow.Portable)
                                        End If
                                    End If

                                    If Not (entImportExcelRow.IsFaxNull) Then
                                        If (Microsoft.VisualBasic.Left(entImportExcelRow.Telephone2, 1) <> "0" And Not (String.IsNullOrEmpty(entImportExcelRow.Telephone2))) Then
                                            telEntTableAdapter.Insert(nEntreprise, "Fax", "0" & entImportExcelRow.Fax)
                                        Else
                                            telEntTableAdapter.Insert(nEntreprise, "Fax", entImportExcelRow.Fax)
                                        End If
                                    End If

                                    'Ajout dans la table Personne
                                    Dim nPersonne As Decimal = Convert.ToDecimal(persTableAdapter.MaxnPersonne()) + 1

                                    If Not (entImportExcelRow.IsContact_NomNull) Then
                                        If Not (entImportExcelRow.Contact_Nom = String.Empty) Then
                                            persTableAdapter.InsertReduit(nPersonne, dateCreation, entImportExcelRow.Contact_Nom, nEntreprise)
                                        End If
                                    End If

                                    Me.ProgressBar1.Value = i * 100 \ entImportExcelDataTable.Rows.Count
                                    Application.DoEvents()
                                    i = i + 1
                                Next
                            End Using
                        End Using
                    End Using
                End Using

                sqlTran.Commit()
            Catch ex As Exception
                sqlTran.Rollback()

                Throw New ApplicationException(ex.Message, ex)
            End Try
        End Using

        Me.ProgressBar1.Value = 100

        MsgBox("Import terminé.", MsgBoxStyle.Information, "Import terminé.")
    End Sub

    Private Sub ViderTables()
        Dim sqlTran As SqlTransaction = Nothing

        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnectionString)
            sqlConn.Open()

            sqlTran = sqlConn.BeginTransaction("Vider_Tables")

            Try
                Using entrepriseTA As New DataSetAgrifactTableAdapters.EntrepriseTableAdapter
                    entrepriseTA.Connection = sqlConn
                    entrepriseTA.Transaction = sqlTran

                    Using personneTA As New DataSetAgrifactTableAdapters.PersonneTableAdapter
                        personneTA.Connection = sqlConn
                        personneTA.Transaction = sqlTran

                        Using telephoneEntrepriseTA As New DataSetAgrifactTableAdapters.TelephoneEntrepriseTableAdapter
                            telephoneEntrepriseTA.Connection = sqlConn
                            telephoneEntrepriseTA.Transaction = sqlTran

                            Dim entrepriseDT As DataSetAgrifact.EntrepriseDataTable = entrepriseTA.GetData()

                            For Each entrepriseDR As DataSetAgrifact.EntrepriseRow In entrepriseDT.Rows
                                'Suppression des enregistrement de la table Personne
                                'et liés à la table Entreprise
                                personneTA.DeleteBynEntreprise(entrepriseDR.nEntreprise)

                                'Suppression des enregistrement de la table TelephoneEntreprise
                                'et liés à la table Entreprise
                                telephoneEntrepriseTA.DeleteBynEntreprise(entrepriseDR.nEntreprise)
                            Next

                            'Suppression des enregistrements de la table Entreprise
                            entrepriseTA.DeleteTous()
                        End Using
                    End Using
                End Using

                sqlTran.Commit()
            Catch ex As Exception
                sqlTran.Rollback()

                Throw New ApplicationException(ex.Message, ex)
            End Try
        End Using
    End Sub
#End Region

End Class