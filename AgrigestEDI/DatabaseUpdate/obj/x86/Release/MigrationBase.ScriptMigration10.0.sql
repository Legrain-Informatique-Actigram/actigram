CREATE TABLE [InventaireMateriel](ID_InventaireMateriel COUNTER,LibelleMateriel Text(255),DDossier Text(8),ID_MATERIEL Long)
GO

ALTER TABLE [InventaireMateriel] ADD CONSTRAINT PK_InventaireMateriel_ID_InventaireMateriel PRIMARY KEY(ID_InventaireMateriel)
GO

ALTER TABLE [InventaireMateriel] ADD CONSTRAINT FK_InventaireMateriel_DDossier FOREIGN KEY(DDossier) REFERENCES Dossiers(DDossier)
GO


CREATE TABLE TypeInventaire(ID_TypeInventaire COUNTER,CodeTypeInventaire Text(1),LibelleTypeInventaire Text(50),[OrdreTypeInventaire] INT)
GO

ALTER TABLE TypeInventaire ADD CONSTRAINT PK_TypeInventaire_ID_TypeInventaire PRIMARY KEY(ID_TypeInventaire)
GO

ALTER TABLE TypeInventaire ADD CONSTRAINT UQ_TypeInventaire_CodeTypeInventaire UNIQUE(CodeTypeInventaire)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('V','Avances aux cultures',5)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('A','Animaux',2)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('F','Façons culturales',4)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('M','Stocks en magasin',1)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('P','Stocks de produits finis',6)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire,OrdreTypeInventaire) VALUES('T','Stocks de produits en terre',3)
GO

INSERT INTO TypeInventaire(CodeTypeInventaire,LibelleTypeInventaire) VALUES('C','Tiers')
GO

ALTER TABLE InventaireGroupes ADD CONSTRAINT FK_InventaireGroupes_INVGTypeInventaire FOREIGN KEY(INVGTypeInventaire) REFERENCES TypeInventaire(CodeTypeInventaire)
GO


ALTER TABLE [InventaireGroupes] ALTER COLUMN [INVGLib] TEXT(50)
GO

ALTER TABLE [InventaireLignes] ALTER COLUMN [INVLLib] TEXT(50)
GO


ALTER TABLE [InventaireLignes] ADD COLUMN [INVLOrdre] INT
GO


ALTER TABLE [Dossiers] ADD COLUMN [DMethodeInventaire] TEXT(25)
GO

				
ALTER TABLE [InventaireLignes] ADD COLUMN [INVLValForfaitaire] CURRENCY
GO


ALTER TABLE [InventaireLignes] ADD COLUMN [INVLNbPass] INT
GO


ALTER TABLE [InventaireGroupes] ADD COLUMN [INVGEstControle] BIT
GO


