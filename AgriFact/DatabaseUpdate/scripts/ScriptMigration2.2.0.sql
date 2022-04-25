BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='IsEnVente' and o.name='Produit') 
BEGIN
	ALTER TABLE Produit ADD IsEnVente BIT NOT NULL DEFAULT (1);
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='isComm' and o.name='Produit') 
BEGIN
	ALTER TABLE Produit ADD isComm BIT NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='Conditionnement' and o.name='Produit') 
BEGIN
	ALTER TABLE Produit ADD Conditionnement INT NULL;
END
GO

COMMIT TRANSACTION