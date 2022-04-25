--Requete DELETE du VFactureTA
BEGIN TRANSACTION
DELETE FROM Reglement_Detail WHERE     (nFacture = @Original_nDevis)
DELETE FROM VFacture_Detail WHERE     (nDevis = @Original_nDevis)
DELETE FROM VFacture WHERE     (nDevis = @Original_nDevis)
COMMIT TRANSACTION