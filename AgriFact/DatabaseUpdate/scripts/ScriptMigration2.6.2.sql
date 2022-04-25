BEGIN TRANSACTION

--Ajout de la colonne LitigeEnCours dans la table Entreprise
IF NOT EXISTS(	SELECT * 
				FROM syscolumns c INNER JOIN sysobjects o ON c.id=o.id 
				WHERE c.name='LitigeEnCours' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD LitigeEnCours BIT DEFAULT(0) NOT NULL;
END
GO

--Ajout de la colonne EnCoursMax dans la table Entreprise
IF NOT EXISTS(	SELECT * 
				FROM syscolumns c INNER JOIN sysobjects o ON c.id=o.id 
				WHERE c.name='EnCoursMax' and o.name='Entreprise') 
BEGIN
	ALTER TABLE Entreprise ADD EnCoursMax DECIMAL(18,2) DEFAULT(0) NULL;
END
GO

COMMIT TRANSACTION