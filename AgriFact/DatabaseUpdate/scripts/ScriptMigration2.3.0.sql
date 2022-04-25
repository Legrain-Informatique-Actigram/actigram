BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='IndEscompteSpecifique' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD IndEscompteSpecifique BIT NOT NULL DEFAULT (0);
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='TauxEscompteSpecifique' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD TauxEscompteSpecifique DECIMAL(9,2) NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='DelaiValiditeEscompte' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD DelaiValiditeEscompte INT NULL;
END
GO

COMMIT TRANSACTION