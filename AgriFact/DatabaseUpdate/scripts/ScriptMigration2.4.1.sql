BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='Ingredients' and o.name='Produit') 
BEGIN
	ALTER TABLE Produit ADD Ingredients NTEXT NULL;
END
GO

COMMIT TRANSACTION