Imports System.Data.SqlClient

Public Class FrFusionnerTiers
    Private _listeTiers As List(Of DataRow)

#Region "Constructeurs"
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me._listeTiers = New List(Of DataRow)
    End Sub

    Public Sub New(ByVal listeTiers As List(Of DataRow))
        Me.New()
        Me._listeTiers = listeTiers
    End Sub
#End Region

#Region "Page"
    Private Sub FrFusionnerProduit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Remplissage de la combobox avec la liste des codes produits
        Dim items As New List(Of ListboxItem)

        For Each pdtDataRow As DataRow In Me._listeTiers
            items.Add(New ListboxItem(Convert.ToString(pdtDataRow.Item("Nom")), Convert.ToInt32(pdtDataRow.Item("nEntreprise"))))
        Next

        With Me.ComboBoxTiersFusion
            .BeginUpdate()
            .DisplayMember = "Nom"
            .ValueMember = "nEntreprise"
            .DataSource = items
            .EndUpdate()
        End With

        'Remplissage de la listebox des tiers � fusionner
        For Each pdtDataRow As DataRow In Me._listeTiers
            Me.ListBoxTiersAFusionner.Items.Add(pdtDataRow.Item("Nom"))
        Next
    End Sub
#End Region

#Region "Boutons"
    Private Sub ButtonValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValider.Click
        'Fusion de la liste des tiers
        Me.FusionnerTiers()

        MsgBox("Fusion termin�e.", MsgBoxStyle.Information, "Fusion termin�e")

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "M�thodes diverses"
    Private Sub FusionnerTiers()
        Dim connString As String = My.Settings.AgrifactConnString

        'R�cup�ration de la liste des tables ayant une contrainte sur la colonne nEntreprise de la table Entreprise
        Dim dataTabListeTablesFKnEntreprise As DataTable = SqlProxy.ListeContraintesParTableEtColonne("Entreprise", "nEntreprise", "FOREIGN KEY", connString)

        If (dataTabListeTablesFKnEntreprise.Rows.Count > 0) Then
            Using sqlConn As New SqlConnection(connString)
                sqlConn.Open()

                Dim sqlComm As SqlCommand = sqlConn.CreateCommand()
                Dim sqlTran As SqlTransaction

                sqlTran = sqlConn.BeginTransaction("FUSIONNER_TIERS")

                sqlComm.Connection = sqlConn
                sqlComm.Transaction = sqlTran

                Try
                    'Construction de la WHERE clause
                    Dim nEntrepriseFusion As String = Replace(Convert.ToString(CType(Me.ComboBoxTiersFusion.SelectedValue, ListboxItem).Value), "'", "''")
                    Dim listenEntreprise As String = String.Empty

                    For Each tiersDataRow As DataRow In Me._listeTiers
                        If (Convert.ToString(tiersDataRow.Item("nEntreprise")) <> nEntrepriseFusion) Then
                            listenEntreprise = listenEntreprise & Convert.ToString(tiersDataRow.Item("nEntreprise")) & ","
                        End If
                    Next

                    'Suppression de la virgule finale
                    listenEntreprise = listenEntreprise.Substring(0, listenEntreprise.Length - 1)

                    'Suppression des contraintes sur la colonne nEntreprise de la table Entreprise
                    For Each dtRowFKEntreprise As DataRow In dataTabListeTablesFKnEntreprise.Rows
                        Dim nomContrainte As String = Convert.ToString(dtRowFKEntreprise.Item("FK_NAME"))
                        Dim nomTableReferencante As String = Convert.ToString(dtRowFKEntreprise.Item("PKTABLE_NAME"))

                        sqlComm.CommandText = _
                              "ALTER TABLE " & nomTableReferencante & " NOCHECK CONSTRAINT " & nomContrainte

                        sqlComm.ExecuteNonQuery()
                    Next

                    'Remplacement de nEntreprise dans les tables (sauf table Entreprise
                    'et table TelephoneEntreprise)
                    For Each dtRow As DataRow In dataTabListeTablesFKnEntreprise.Rows
                        Dim nomTab As String = Convert.ToString(dtRow.Item("PKTABLE_NAME"))
                        Dim nomColonne As String = Convert.ToString(dtRow.Item("PKCOLUMN_NAME"))
                        Dim whereClause As String = "WHERE " & nomColonne & " IN(" & listenEntreprise & ")"

                        If (UCase(nomTab) <> "ENTREPRISE" And UCase(nomTab) <> "TELEPHONEENTREPRISE") Then
                            sqlComm.CommandText = _
                              "UPDATE " & nomTab & " " & _
                              "SET " & nomColonne & "=" & nEntrepriseFusion & " " & _
                              whereClause

                            sqlComm.ExecuteNonQuery()
                        End If
                    Next

                    'Traitement sp�cifique pour la table TelephoneEntreprise car la cl� de cette table est constitu�e
                    'de la colonne nEntreprise et Type. Or si l'entreprise de remplacement poss�de d�j� un t�l�phone
                    'ayant le m�me type que l'entreprise � remplacer impossible de mettre � jour la table
                    Using telephoneEntrepriseTA As New DsAgrifactTableAdapters.TelephoneEntrepriseTA
                        telephoneEntrepriseTA.SetTransaction(sqlTran)

                        'Pour chaque Entreprise � fusionner
                        For Each tiersDataRow As DataRow In Me._listeTiers
                            If (Convert.ToString(tiersDataRow.Item("nEntreprise")) <> nEntrepriseFusion) Then
                                Dim nEntrepriseAFusionner As Decimal = CDec(tiersDataRow.Item("nEntreprise"))
                                Dim telephoneEntrepriseAFusionnerDT As DsAgrifact.TelephoneEntrepriseDataTable = telephoneEntrepriseTA.GetDataBynEntreprise(nEntrepriseAFusionner)

                                'Pour chaque t�l�phone de l'entreprise � fusionner
                                For Each telephoneEntrepriseAFusionnerDR As DsAgrifact.TelephoneEntrepriseRow In telephoneEntrepriseAFusionnerDT.Rows
                                    'V�rifie que l'entreprise de fusion ne poss�de pas d�j� un t�l�phone avec le type
                                    'du t�l�phone de l'entreprise de fusion
                                    Dim telephoneEntrepriseDeFusionDT As DsAgrifact.TelephoneEntrepriseDataTable = telephoneEntrepriseTA.GetDataBynEntrepriseEtType(CDec(nEntrepriseFusion), telephoneEntrepriseAFusionnerDR.Type)

                                    'Si le type existe d�j�, on supprime le t�l�phone de l'entreprise � fusionner
                                    'puis on cr�e un nouveau t�l�phone avec un nouveau type pour l'entreprise de fusion
                                    If (telephoneEntrepriseDeFusionDT.Rows.Count > 0) Then
                                        'suppression
                                        sqlComm.CommandText = _
                                              String.Format("DELETE FROM TelephoneEntreprise " & _
                                              "WHERE nEntreprise={0} AND Type='{1}'", telephoneEntrepriseAFusionnerDR.nEntreprise, _
                                              telephoneEntrepriseAFusionnerDR.Type)

                                        sqlComm.ExecuteNonQuery()

                                        'Ajout
                                        Dim numero As String = String.Empty

                                        If Not (telephoneEntrepriseAFusionnerDR.IsNumeroNull) Then
                                            numero = "'" & telephoneEntrepriseAFusionnerDR.Numero & "'"
                                        Else
                                            numero = "NULL"
                                        End If

                                        sqlComm.CommandText = _
                                              String.Format("INSERT INTO TelephoneEntreprise(nEntreprise,Type,Numero) " & _
                                              "VALUES({0},'{1} {2}',{3})", nEntrepriseFusion, telephoneEntrepriseAFusionnerDR.Type, _
                                              telephoneEntrepriseAFusionnerDR.nEntreprise, numero)

                                        sqlComm.ExecuteNonQuery()
                                    Else
                                        sqlComm.CommandText = _
                                              "UPDATE TelephoneEntreprise " & _
                                              "SET nEntreprise=" & nEntrepriseFusion & " " & _
                                              "WHERE nEntreprise=" & telephoneEntrepriseAFusionnerDR.nEntreprise

                                        sqlComm.ExecuteNonQuery()
                                    End If
                                Next
                            End If
                        Next
                    End Using

                    'R�tablissement des contraintes sur la colonne nEntreprise de la table Entreprise
                    For Each dtRowFKEntreprise As DataRow In dataTabListeTablesFKnEntreprise.Rows
                        Dim nomContrainte As String = Convert.ToString(dtRowFKEntreprise.Item("FK_NAME"))
                        Dim nomTableReferencante As String = Convert.ToString(dtRowFKEntreprise.Item("PKTABLE_NAME"))

                        sqlComm.CommandText = _
                              "ALTER TABLE " & nomTableReferencante & " CHECK CONSTRAINT " & nomContrainte

                        sqlComm.ExecuteNonQuery()
                    Next

                    'Suppression des Entreprises fusionn�es
                    If (Me.CheckBoxSupprimer.Checked = True) Then
                        Dim whereClause As String = "WHERE nEntreprise IN(" & listenEntreprise & ")"

                        sqlComm.CommandText = _
                          "DELETE FROM Entreprise " & whereClause

                        sqlComm.ExecuteNonQuery()
                    End If

                    sqlTran.Commit()
                Catch ex As Exception
                    sqlTran.Rollback()

                    Throw New Exception(ex.Message)
                End Try
            End Using
        End If
    End Sub
#End Region

End Class