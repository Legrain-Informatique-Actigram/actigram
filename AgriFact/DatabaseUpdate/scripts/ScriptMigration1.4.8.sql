--Modif de la table VFacture pour l'impression des lettres de relance
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VFacture ADD
	nRelance int NULL,
	DateRelance datetime NULL
GO
ALTER TABLE dbo.VFacture ADD CONSTRAINT
	DF_VFacture_nRelance DEFAULT 0 FOR nRelance
GO
COMMIT