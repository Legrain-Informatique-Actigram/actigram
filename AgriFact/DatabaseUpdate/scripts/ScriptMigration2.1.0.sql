BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='ObservationLivraison' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD ObservationLivraison NVARCHAR(255) NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='TxCommission' and o.name='vDevis') 
BEGIN
	ALTER TABLE vDevis ADD TxCommission INT NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='TxCommission' and o.name='vBonCommande') 
BEGIN
	ALTER TABLE vBonCommande ADD TxCommission INT NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='TxCommission' and o.name='vBonLivraison') 
BEGIN
	ALTER TABLE vBonLivraison ADD TxCommission INT NULL;
END
GO

COMMIT TRANSACTION