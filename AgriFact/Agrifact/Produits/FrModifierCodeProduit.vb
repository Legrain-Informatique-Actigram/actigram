Imports System.Data.SqlClient

Public Class FrModifierCodeProduit

    Private _nProduit As Decimal

#Region "Constructeurs"
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me._nProduit = -1
    End Sub

    Public Sub New(ByVal nProduit As Decimal)
        Me.New()
        Me._nProduit = nProduit
    End Sub
#End Region

#Region "Page"
    Private Sub FrModifierCodeProduit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim codeProduit As String = String.Empty

        If (Me._nProduit <> -1) Then
            'Recherche du code produit avant modification
            Using pdtTableAdapter As New DsProduitsTableAdapters.ProduitTableAdapter
                Dim pdtDataTable As DsProduits.ProduitDataTable = pdtTableAdapter.GetDataBynProduit(Me._nProduit)

                For Each pdtRow As DsProduits.ProduitRow In pdtDataTable.Rows
                    codeProduit = pdtRow.CodeProduit
                Next
            End Using

            Me.TextBoxAncienCodeProduit.Text = codeProduit
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub ButtonValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValider.Click
        If (Me.TextBoxNouveauCodeProduit.TextLength <= 0) Then
            MsgBox("Veuillez saisir un nouveau code produit.", MsgBoxStyle.Exclamation, "Code produit")

            Me.TextBoxNouveauCodeProduit.Focus()

            Exit Sub
        End If

        'Vérifie que le nouveau code produit n'existe pas déjà 
        If (Me.CodeProduitExiste(Me.TextBoxNouveauCodeProduit.Text)) Then
            MsgBox("Modification impossible: le nouveau code produit existe déjà. Veuillez saisir un code produit inexistant.", MsgBoxStyle.Exclamation, "Modification impossible")

            Me.TextBoxNouveauCodeProduit.Focus()
            Me.TextBoxNouveauCodeProduit.Select(0, Me.TextBoxNouveauCodeProduit.TextLength)

            Exit Sub
        End If

        'Modification du code produit
        Me.ModifierCodeProduit()

        MsgBox("Modification du code produit terminé.", MsgBoxStyle.Information, "Modification terminée")

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function CodeProduitExiste(ByVal codeProduit As String) As Boolean
        'Vérifie si le code produit passé en paramètre existe dans la BDD
        Using pdtTableAdapter As New DsProduitsTableAdapters.ProduitTableAdapter
            If (Convert.ToInt16(pdtTableAdapter.CountCodeProduit(codeProduit)) > 0) Then
                Return True
            End If
        End Using

        Return False
    End Function

    Private Sub ModifierCodeProduit()
        Dim connString As String = My.Settings.AgrifactConnString

        'Récupération de la liste des tables ayant une colonne CodeProduit
        Dim dataTabListeTablesAvecCodeProduit As DataTable = SqlProxy.ListeTablesParNomColonne("CodeProduit", connString)

        If (dataTabListeTablesAvecCodeProduit.Rows.Count > 0) Then
            Using sqlConn As New SqlConnection(connString)
                sqlConn.Open()

                Dim sqlComm As SqlCommand = sqlConn.CreateCommand()
                Dim sqlTran As SqlTransaction

                sqlTran = sqlConn.BeginTransaction("MODIFIER_CODEPRODUIT")

                sqlComm.Connection = sqlConn
                sqlComm.Transaction = sqlTran

                Try
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

                    'Remplacement du code produit dans les tables
                    For Each dtRow As DataRow In dataTabListeTablesAvecCodeProduit.Rows
                        Dim nomTab As String = Convert.ToString(dtRow.Item("Name"))

                        sqlComm.CommandText = _
                          "UPDATE " & nomTab & " " & _
                          "SET CodeProduit='" & Replace(Me.TextBoxNouveauCodeProduit.Text, "'", "''") & "' " & _
                          "WHERE CodeProduit='" & Replace(Me.TextBoxAncienCodeProduit.Text, "'", "''") & "'"

                        sqlComm.ExecuteNonQuery()
                    Next

                    'Rétablissement des contraintes sur la colonne CodeProduit de la table Produit
                    For Each dtRowFKProduit As DataRow In dataTabFKProduit.Rows
                        Dim nomContrainte As String = Convert.ToString(dtRowFKProduit.Item("FK_NAME"))
                        Dim nomTableReferencante As String = Convert.ToString(dtRowFKProduit.Item("PKTABLE_NAME"))

                        sqlComm.CommandText = _
                              "ALTER TABLE " & nomTableReferencante & " CHECK CONSTRAINT " & nomContrainte

                        sqlComm.ExecuteNonQuery()
                    Next

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