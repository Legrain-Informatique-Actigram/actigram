--Update Niveau2 pour permettre l'utilisation de comptes AlphaNumériques

BEGIN TRANSACTION
--On corrige la structure de la base
alter table mouvement_detail alter column Libelle nvarchar(255) null;

UPDATE Niveau2 SET FiltreType='CCpt>''401'' And CCpt<''402''' 							WHERE [Table]='Entreprise' AND Champs='NCompteF';
UPDATE Niveau2 SET FiltreType='CCpt>''411'' And CCpt<''412''' 									WHERE [Table]='Entreprise' AND Champs='NCompteC';
UPDATE Niveau2 SET FiltreType='(CCpt>''511'' And CCpt<''513'') OR (CCpt>''53'' And CCpt<''54'')  OR (CCpt>''58'' And CCpt<''59'')' WHERE [Table]='Banque' AND Champs='NCompte';
UPDATE Niveau2 SET FiltreType='CCpt>''6''' 														WHERE [Table]='Produit' AND Champs='NCompteV';
UPDATE Niveau2 SET FiltreType='(CCpt>''6'' And CCpt<''7'') Or (CCpt>''2'' And CCpt<''3'')' 		WHERE [Table]='Produit' AND Champs='NCompteA';

COMMIT TRANSACTION