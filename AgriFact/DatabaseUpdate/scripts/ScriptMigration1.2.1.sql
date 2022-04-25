BEGIN TRANSACTION
GO

--Produit
ALTER TABLE Produit ALTER COLUMN PrixAHT decimal(18, 5) NULL;
GO
ALTER TABLE Produit ALTER COLUMN PrixATTC decimal(18, 5) NULL;
GO
ALTER TABLE Produit ALTER COLUMN PrixVHT decimal(18, 5) NULL;
GO
ALTER TABLE Produit ALTER COLUMN PrixVTTC decimal(18, 5) NULL;
GO

--Tarif_Detail
ALTER TABLE Tarif_Detail ALTER COLUMN PrixVHT decimal(18, 5) NULL;
GO
ALTER TABLE Tarif_Detail ALTER COLUMN PrixVTTC decimal(18, 5) NULL;
GO

--VBonCommande_Detail
ALTER TABLE VBonCommande_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE VBonCommande_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE VBonCommande_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
--VBonLivraison_Detail
ALTER TABLE VBonLivraison_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE VBonLivraison_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE VBonLivraison_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
--VFacture_Detail
ALTER TABLE VFacture_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE VFacture_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE VFacture_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
--VDevis_Detail
ALTER TABLE VDevis_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE VDevis_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE VDevis_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
--ABonReception_Detail
ALTER TABLE ABonReception_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE ABonReception_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE ABonReception_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
--AFacture_Detail
ALTER TABLE AFacture_Detail ALTER COLUMN PrixUHT decimal(18, 5) NULL;
GO
ALTER TABLE AFacture_Detail ALTER COLUMN PrixUTVA decimal(18, 5) NULL;
GO
ALTER TABLE AFacture_Detail ALTER COLUMN PrixUTTC decimal(18, 5) NULL;
GO
COMMIT TRANSACTION
GO