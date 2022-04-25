BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='IsExport' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD IsExport BIT NULL DEFAULT (0);
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='NCompteX' and o.name='Produit') 
BEGIN
  ALTER TABLE Produit ADD NCompteX NVARCHAR(8) NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='NActiviteX' and o.name='Produit') 
BEGIN
	ALTER TABLE Produit ADD NActiviteX NVARCHAR(4) NULL;
END
GO


COMMIT TRANSACTION