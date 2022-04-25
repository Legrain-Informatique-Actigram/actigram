Namespace Stocks
    Public Module GestionStock
        Public Enum TypeMouvement
            None
            Fabrication
            Inventaire
            Conditionnement
            Entrées
            Sorties
            Transfert_dépôt
            Régul_stock
            ModeleFab
            Habillage
            Mise_en_bouteille
        End Enum

        Public Function GetProduitStock() As DataTable
            Return ExecDatatable("Select EtatStock.CodeProduit,Produit.Libelle,Sum(EtatStock.Unite1) As Unite1,Produit.Unite1 As LibUnite1,Sum(EtatStock.Unite2) As Unite2,Produit.Unite2 As LibUnite2 From EtatStock Inner Join Produit On EtatStock.CodeProduit=Produit.CodeProduit Where TypeMouvement<>'Commande' Group By EtatStock.CodeProduit,Produit.Libelle,Produit.Unite1,Produit.Unite2 Order By EtatStock.CodeProduit")
        End Function

        Public Function GetProduitCmd() As DataTable
            Return ExecDatatable("Select EtatStock.CodeProduit,Produit.Libelle,Sum(EtatStock.Unite1) As Unite1,Produit.Unite1 As LibUnite1,Sum(EtatStock.Unite2) As Unite2,Produit.Unite2 As LibUnite2 From EtatStock Inner Join Produit On EtatStock.CodeProduit=Produit.CodeProduit Where TypeMouvement='Commande' Group By EtatStock.CodeProduit,Produit.Libelle,Produit.Unite1,Produit.Unite2 Order By EtatStock.CodeProduit")
        End Function

        Public Function GetProduitReApprot() As DataTable
            Return ExecDatatable("Select EtatStock.CodeProduit,Produit.Libelle,EtatStock.nLot,Sum(EtatStock.Unite1) As Unite1,Produit.Unite1 As LibUnite1,Sum(EtatStock.Unite2) As Unite2,Produit.Unite2 As LibUnite2 From EtatStock Inner Join Produit On EtatStock.CodeProduit=Produit.CodeProduit Group By EtatStock.CodeProduit,Produit.Libelle,EtatStock.nLot,Produit.Unite1,Produit.Unite2 Having Sum(EtatStock.Unite1)<0 Order By EtatStock.CodeProduit,EtatStock.nLot")
        End Function

        Public Function ExecDatatable(ByVal strSql As String) As DataTable
            Using s As New SqlProxy
                Return s.ExecuteDataTable(strSql)
            End Using
        End Function
    End Module
End Namespace