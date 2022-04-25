Imports System.Data.SqlClient

Namespace Stocks
    Public Class ListeLotsProduits
        Inherits List(Of Stocks.LotProduit)

#Region "M�thodes partag�es"
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

            'R�cup�ration de la liste des produits associ�s au lot
            Dim listeLotProduitDansBDD As Stocks.ListeLotsProduits = Stocks.ListeLotsProduits.ListeLotsProduitsParnLot(nLot)

            'Suppression des produits associ�s au lot pr�sents dans la BDD et non pr�sents
            'dans la liste pass�e en param�tre
            For Each lotProduit As Stocks.LotProduit In listeLotProduitDansBDD
                Dim existe As Boolean = False

                'V�rifie si le produit associ� au lot est pr�sent dans la liste pass�e en param�tre
                'et dans la base de donn�es
                existe = Stocks.ListeLotsProduits.LotProduitExisteDansListe(listeLotProduit, lotProduit)

                'Si le produit associ� au lot n'existe pas dans la liste pass�e en param�tre mais
                'existe dans la base de donn�es, on le supprime de la base de donn�es
                If Not (existe) Then
                    Stocks.LotProduit.SupprimerLotProduit(lotProduit, sqlTrans)
                End If
            Next

            'Ajout ou modification des produits associ�s au lot
            For Each lotProduit As Stocks.LotProduit In listeLotProduit
                'Ajout d'un nouveau produit associ� au lot
                If (lotProduit.IdLotProduit = 0) Then
                    lotProduit.nLot = nLot

                    Stocks.LotProduit.AjouterLotProduit(lotProduit, sqlTrans)
                Else 'Modification du produit associ� au lot
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
