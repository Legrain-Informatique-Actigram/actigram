-- Modifs pour exports compta : gestion des Journaux dans Agrifact
BEGIN TRANSACTION
GO
alter table entreprise alter column Remise decimal(18,2)
GO
alter table Comptes
alter column CLib nVarchar(30)
GO
IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[Journal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[Journal] (
		[JCodeJournal] [nvarchar] (2) COLLATE French_CI_AS NOT NULL ,
		[JCodeLibelle] [nvarchar] (50) COLLATE French_CI_AS NULL ,
		[JType] [varchar] (50) COLLATE French_CI_AS NULL ,
		[JCompteContre] [varchar] (8) COLLATE French_CI_AS NULL ,
		[JLibelle] [nvarchar] (50) COLLATE French_CI_AS NULL 
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Journal] WITH NOCHECK ADD 
		CONSTRAINT [PK_Journal] PRIMARY KEY  CLUSTERED 
		(
			[JCodeJournal]
		)  ON [PRIMARY] 
END
GO
GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Journal]  TO [Utilisateurs]
GO
CREATE TABLE dbo.Tmp_Dossiers
	(
	DDossier nvarchar(8) NOT NULL,
	DExpl nvarchar(6) NULL,
	DDtDebEx smalldatetime NULL,
	DDtFinEx smalldatetime NULL,
	DDtArrete smalldatetime NULL,
	DBqCpt nvarchar(8) NULL,
	DBqVal money NULL,
	DBqFolio1 smallint NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.Dossiers)
	 EXEC('INSERT INTO dbo.Tmp_Dossiers (DDossier, DExpl, DDtDebEx, DDtFinEx, DDtArrete, DBqCpt, DBqVal, DBqFolio1)
		SELECT DDossier, DExpl, DDtDebEx, DDtFinEx, DDtArrete, DBqCpt, DBqVal, DBqFolio1 FROM dbo.Dossiers TABLOCKX')
GO
DROP TABLE dbo.Dossiers
GO
EXECUTE sp_rename N'dbo.Tmp_Dossiers', N'Dossiers', 'OBJECT'
GO
ALTER TABLE dbo.Dossiers ADD CONSTRAINT
	PK_Dossiers PRIMARY KEY CLUSTERED 
	(
	DDossier
	) ON [PRIMARY]

GO
GRANT SELECT ON dbo.Dossiers TO Utilisateurs  AS dbo
GRANT UPDATE ON dbo.Dossiers TO Utilisateurs  AS dbo
GRANT INSERT ON dbo.Dossiers TO Utilisateurs  AS dbo
GRANT DELETE ON dbo.Dossiers TO Utilisateurs  AS dbo
GO
ALTER TABLE dbo.TVA ADD	TypTVA nvarchar(5) NULL
GO
COMMIT TRANSACTION