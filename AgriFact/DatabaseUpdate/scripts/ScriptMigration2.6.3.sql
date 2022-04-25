BEGIN TRANSACTION

--Tri le taux de TVA de la fiche produit par libellé
UPDATE Niveau2 SET [TableListeChoixTri]='TLibelle' WHERE [Table]='Produit' AND [Champs]='TTVA'

COMMIT TRANSACTION