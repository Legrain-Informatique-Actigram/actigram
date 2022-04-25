BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='nCommercial' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD nCommercial INT NULL;
END
GO

COMMIT TRANSACTION