--Correction pour Approfact : Perte des décimales sur les prix d'achats
BEGIN TRANSACTION
--On corrige la structure de la base
alter table vbonlivraison_detail alter column PrixUAchatHT decimal(18, 2) null;
alter table vfacture_detail alter column PrixUAchatHT decimal(18, 2) null;

COMMIT TRANSACTION