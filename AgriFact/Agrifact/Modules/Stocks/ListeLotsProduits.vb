Imports System.Data.SqlClient

Namespace Stocks
    Public Class ListeLotsProduits
        Inherits List(Of Stocks.LotProduit)

#Region "Méthodes partagées"
        Public Shared Function ListeLotsProduitsParnLot(ByVal nLot As String) As Stocks.ListeLotsProduits
            Dim listeLotsProduits As New Stocks.ListeLotsProduits()

            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                Dim lotProduitDT As StocksDataSet.LotProduitDataTable = lotProduitTA.GetDataBynLot(nLot)

                For Each lotProduitDR As StocksDataSet.LotProduitRow In lotProduitDT.Rows
                    Dim lotProduit As New Stocks.LotProduit(lotProduitDR.IdLotProduit)

                    listeLotsProduits.Add(lotProduit)
                Next
            End Using

            Return listeLotsProduits
        End Function

        Public Shared Sub ModifierListeLotsProduitsParLot(ByVal listeLotProduit As Stocks.ListeLotsProduits, _
                                                            ByVal nLot As String, Optional ByVal sqlTrans As SqlTransaction = Nothing)

            'Récupération de la liste des produits associés au lot
            Dim listeLotProduitDansBDD As Stocks.ListeLotsProduits = Stocks.ListeLotsProduits.ListeLotsProduitsParnLot(nLot)

            'Suppression des produits associés au lot présents dans la BDD et non présents
            'dans la liste passée en paramètre
            For Each lotProduit As Stocks.LotProduit In listeLotProduitDansBDD
                Dim existe As Boolean = False

                'Vérifie si le produit associé au lot est présent dans la liste passée en paramètre
                'et dans la base de données
                existe = Stocks.ListeLotsProduits.LotProduitExisteDansListe(listeLotProduit, lotProduit)

                'Si le produit associé au lot n'existe pas dans la liste passée en paramètre mais
                'existe dans la base de données, on le supprime de la base de données
                If Not (existe) Then
                    Stocks.LotProduit.SupprimerLotProduit(lotProduit, sqlTrans)
                End If
            Next

            'Ajout ou modification des produits associés au lot
            For Each lotProduit As Stocks.LotProduit In listeLotProduit
                'Ajout d'un nouveau produit associé au lot
                If (lotProduit.IdLotProduit = 0) Then
                    lotProduit.nLot = nLot

                    Stocks.LotProduit.AjouterLotProduit(lotProduit, sqlTrans)
                Else 'Modification du produit associé au lot
                    Stocks.LotProduit.ModifierLotProduit(lotProduit, sqlTrans)
                End If
            Next
        End Sub

        Public Shared Function LotProduitExisteDansListe(ByVal listeLotProduit As Stocks.ListeLotsProduits, _
                                                        ByVal lotProduit As Stocks.LotProduit) As Boolean

            For Each lp As Stocks.LotProduit In listeLotProduit
                If (lp.IdLotProduit = lotProduit.IdLotProduit) Then
                    Return True
                End If
            Next

            Return False
        End Function
#End Region
    End Class
End Namespace
