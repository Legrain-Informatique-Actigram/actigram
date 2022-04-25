Imports System.Data.SqlClient

Public Class FrFusionnerProduits
    Private _listeProduits As List(Of DataRow)

#Region "Constructeurs"
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me._listeProduits = New List(Of DataRow)
    End Sub

    Public Sub New(ByVal listeProduits As List(Of DataRow))
        Me.New()
        Me._listeProduits = listeProduits
    End Sub
#End Region

#Region "Page"
    Private Sub FrFusionnerProduit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Remplissage de la combobox avec la liste des codes produits
        Dim items As New List(Of ListboxItem)

        For Each pdtDataRow As DataRow In Me._listeProduits
            items.Add(New ListboxItem(Convert.ToString(pdtDataRow.Item("CodeProduit")), Convert.ToInt32(pdtDataRow.Item("nProduit"))))
        Next

        With Me.ComboBoxCodeProduitFusion
            .BeginUpdate()
            .DisplayMember = "CodeProduit"
            .ValueMember = "nProduit"
            .DataSource = items
            .EndUpdate()
        End With

        'Remplissage de la listebox des produits à fusionner
        For Each pdtDataRow As DataRow In Me._listeProduits
            Me.ListBoxProduitsAFusionner.Items.Add(pdtDataRow.Item("CodeProduit"))
        Next
    End Sub
#End Region

#Region "Boutons"
    Private Sub ButtonValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValider.Click
        'Fusion de la liste des produits
        Me.FusionnerProduits()

        MsgBox("Fusion terminée.", MsgBoxStyle.Information, "Fusion terminée")

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub FusionnerProduits()
        Dim connString As String = My.Settings.AgrifactConnString

        'Récupération de la liste des tables ayant une colonne nommée CodeProduit
        Dim dataTabListeTablesAvecCodeProduit As DataTable = SqlProxy.ListeTablesParNomColonne("CodeProduit", connString)

        If (dataTabListeTablesAvecCodeProduit.Rows.Count > 0) Then
            Using sqlConn As New SqlConnection(connString)
                sqlConn.Open()

                Dim sqlComm As SqlCommand = sqlConn.CreateCommand()
                Dim sqlTran As SqlTransaction

                sqlTran = sqlConn.BeginTransaction("FUSIONNER_CODEPRODUIT")

                sqlComm.Connection = sqlConn
                sqlComm.Transaction = sqlTran

                Try
                    'Construction de la WHERE clause
                    Dim codeProduitFusion As String = Replace(CType(Me.ComboBoxCodeProduitFusion.SelectedValue, ListboxItem).Text, "'", "''")
                    Dim listeProduits As String = String.Empty

                    For Each pdtDataRow As DataRow In Me._listeProduits
                        listeProduits = listeProduits & "'" & Replace(Convert.ToString(pdtDataRow.Item("CodeProduit")), "'", "''") & "',"
                    Next

                    'Suppression de la virgule finale
                    listeProduits = listeProduits.Substring(0, listeProduits.Length - 1)

                    Dim whereClause As String = "WHERE CodeProduit <> '" & codeProduitFusion & "' " & _
                                                "AND CodeProduit IN(" & listeProduits & ")"

                    'Récupération de la liste des contraintes sur la colonne CodeProduit de la table Produit
                    Dim dataTabFKProduit As DataTable = SqlProxy.ListeContraintesParTableEtColonne("Produit", "CodeProduit", "FOREIGN KEY", connString)

                    'Suppression des contraintes sur la colonne CodeProduit de la table Produit
                    For Each dtRowFKProduit As DataRow In dataTabFKProduit.Rows
                        Dim nomContrainte As String = Convert.ToString(dtRowFKProduit.Item("FK_NAME"))
                        Dim nomTableReferencante As String = Convert.ToString(dtRowFKProduit.Item("PKTABLE_NAME"))

                        sqlComm.CommandText = _
                              "ALTER TABLE " & nomTableReferencante & " NOCHECK CONSTRAINT " & nomContrainte

                        sqlComm.ExecuteNonQuery()
                    Next

                    'Remplacement du code produit dans les tables (sauf la table Produit)
                    For Each dtRow As DataRow In dataTabListeTablesAvecCodeProduit.Rows
                        Dim nomTab As String = Convert.ToString(dtRow.Item("Name"))

                        If (nomTab <> "Produit") Then
                            sqlComm.CommandText = _
                              "UPDATE " & nomTab & " " & _
                              "SET CodeProduit='" & codeProduitFusion & "' " & _
                              whereClause

                            sqlComm.ExecuteNonQuery()
                        End If
                    Next

                    'Rétablissement des contraintes sur la colonne CodeProduit de la table Produit
                    For Each dtRowFKProduit As DataRow In dataTabFKProduit.Rows
                        Dim nomContrainte As String = Convert.ToString(dtRowFKProduit.Item("FK_NAME"))
                        Dim nomTableReferencante As String = Convert.ToString(dtRowFKProduit.Item("PKTABLE_NAME"))

                        sqlComm.CommandText = _
                              "ALTER TABLE " & nomTableReferencante & " CHECK CONSTRAINT " & nomContrainte

                        sqlComm.ExecuteNonQuery()
                    Next

                    'Suppression des produits fusionnés
                    If (Me.CheckBoxSupprimer.Checked = True) Then
                        sqlComm.CommandText = _
                          "DELETE FROM Produit " & whereClause

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