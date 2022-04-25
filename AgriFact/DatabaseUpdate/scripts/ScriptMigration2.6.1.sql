BEGIN TRANSACTION

--Rend actif le Nom du payeur lors de la saisie d'un règlement
UPDATE Niveau2 SET [TableListeChoixType]='cb', [TableListeChoixTri]='Nom' WHERE [Table]='Reglement' AND [Champs]='nEntreprise'

COMMIT TRANSACTION