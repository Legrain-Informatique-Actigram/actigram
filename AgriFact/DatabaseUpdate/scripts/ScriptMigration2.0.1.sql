BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='NomFacturation' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD NomFacturation NVARCHAR(255) NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='NomLivraison' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD NomLivraison NVARCHAR(255) NULL;
END
GO

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='EditionBLNonChiffre' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD EditionBLNonChiffre BIT DEFAULT 0;
END
GO

UPDATE Entreprise SET EditionBLNonChiffre = 0;
GO

IF NOT EXISTS(	SELECT * 
				FROM sys.default_constraints DC JOIN sys.COLUMNS C ON C.object_id = DC.parent_object_id 
					AND C.column_id = DC.parent_column_id 
				WHERE OBJECT_NAME(parent_object_id) = 'ABonReception' 
					AND DC.name='col_FacturationTTC_def')
BEGIN
	ALTER TABLE ABonReception ADD CONSTRAINT col_FacturationTTC_def DEFAULT 0 FOR FacturationTTC;
END
GO

COMMIT TRANSACTION