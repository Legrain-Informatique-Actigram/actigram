-- APPROFACT : Ajout des colonnes
BEGIN TRANSACTION
GO

if not exists (select * from syscolumns cols inner join sysobjects t on t.id=cols.id
	where t.Name='Produit' AND cols.Name='AMM')
ALTER TABLE Produit ADD	
	[AMM] [varchar] (10) COLLATE French_CI_AS NULL ,
	[TAXSM] [decimal](18, 5) NULL ,
	[IsAMM] [bit] NOT NULL DEFAULT 0 ,
	[DateMaj] [datetime] NULL 
GO
if not exists (select * from syscolumns cols inner join sysobjects t on t.id=cols.id
	where t.Name='VDevis_Detail' AND cols.Name='PrixUAchatHT')
ALTER TABLE VDevis_Detail ADD PrixUAchatHT decimal(18, 0) NULL
GO
if not exists (select * from syscolumns cols inner join sysobjects t on t.id=cols.id
	where t.Name='VBonCommande_Detail' AND cols.Name='PrixUAchatHT')
ALTER TABLE VBonCommande_Detail ADD PrixUAchatHT decimal(18, 0) NULL
GO
if not exists (select * from syscolumns cols inner join sysobjects t on t.id=cols.id
	where t.Name='VBonLivraison_Detail' AND cols.Name='PrixUAchatHT')
ALTER TABLE VBonLivraison_Detail ADD PrixUAchatHT decimal(18, 0) NULL
GO
if not exists (select * from syscolumns cols inner join sysobjects t on t.id=cols.id
	where t.Name='VFacture_Detail' AND cols.Name='PrixUAchatHT')
ALTER TABLE VFacture_Detail ADD PrixUAchatHT decimal(18, 0) NULL
GO

COMMIT TRANSACTION