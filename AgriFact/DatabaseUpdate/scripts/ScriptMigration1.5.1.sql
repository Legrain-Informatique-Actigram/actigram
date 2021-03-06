BEGIN TRANSACTION
GO
ALTER TABLE dbo.VFacture ADD DateImpr datetime NULL
GO
-- Init pour les factures existantes ??	

-- Celles dont la date d'échéance est dépassée
UPDATE VFacture SET DateImpr=DateEcheance
WHERE DateEcheance is not null and DateEcheance<GetDate()

-- Celles qui ont des réglements
UPDATE VFacture SET DateImpr=DateReglement 
FROM VFacture 
INNER JOIN Reglement_Detail d ON VFacture.nDevis=d.nFacture
INNER JOIN Reglement r ON d.nReglement=r.nReglement

GO
COMMIT