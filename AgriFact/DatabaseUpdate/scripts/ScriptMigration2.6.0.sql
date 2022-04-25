BEGIN TRANSACTION

--Création de la table ColonneListe
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ColonneListe')
BEGIN              
	CREATE TABLE [dbo].[ColonneListe](
		[ID_ColonneListe] [int] IDENTITY(1,1) NOT NULL,
		[TypeListe] [nvarchar](50) NULL,
		[TypePiece] [nvarchar](50) NULL,
		[DataPropertyName] [nvarchar](255) NULL,
		[Visible] [bit] NOT NULL,
		[Width] [int] NULL,
	 CONSTRAINT [PK_ColonneListe] PRIMARY KEY CLUSTERED 
	(
		[ID_ColonneListe] ASC
	) ON [PRIMARY]
	)ON [PRIMARY]
	
	ALTER TABLE [dbo].[ColonneListe] ADD  CONSTRAINT [DF_ColonneListe_Visible]  DEFAULT ((0)) FOR [Visible]

	ALTER TABLE [dbo].[ColonneListe] ADD  CONSTRAINT [DF_ColonneListe_Width]  DEFAULT ((0)) FOR [Width]
	
	GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ColonneListe]  TO [Utilisateurs]
END
GO

--Création des autorisations pour Utilisateurs sur la table Bareme
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Bareme]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la table DefinitionControle
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[DefinitionControle]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la table ModeleBareme
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ModeleBareme]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la table ModeleDefinitionControle
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ModeleDefinitionControle]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la table ResultatControle
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ResultatControle]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la procèdure stockée CalculEtatStockSchema
GRANT  EXECUTE  ON [dbo].[CalculEtatStockSchema]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la procèdure stockée EtatNonConf
GRANT  EXECUTE  ON [dbo].[EtatNonConf]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la procèdure stockée EtatNonConfSchema
GRANT  EXECUTE  ON [dbo].[EtatNonConfSchema]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la procèdure stockée EtatTracaLot
GRANT  EXECUTE  ON [dbo].[EtatTracaLot]  TO [Utilisateurs]
GO

--Création des autorisations pour Utilisateurs sur la procèdure stockée EtatTracaMP
GRANT  EXECUTE  ON [dbo].[EtatTracaMP]  TO [Utilisateurs]
GO

COMMIT TRANSACTION