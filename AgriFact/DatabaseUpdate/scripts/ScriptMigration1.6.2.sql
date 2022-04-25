--Modif pour Point De Vente : ajout des tables pour la gestion du Journal de Caisse
BEGIN TRANSACTION
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JournalCaisse]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[JournalCaisse]
GO

CREATE TABLE [dbo].[JournalCaisse] (
	[IdMvtCaisse] [int] IDENTITY (1, 1) NOT NULL ,
	[NCaisse] [int] NOT NULL ,
	[DateCaisse] [datetime] NOT NULL ,
	[Type] [tinyint] NOT NULL ,
	[Montant] [decimal](18, 2) NOT NULL ,
	[Libelle] [varchar] (255) COLLATE French_CI_AS NULL ,
	[nReglement] [int] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JournalCaisse] WITH NOCHECK ADD 
	CONSTRAINT [PK_JournalCaisse] PRIMARY KEY  CLUSTERED 
	(
		[IdMvtCaisse]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[JournalCaisse] ADD 
	CONSTRAINT [DF_JournalCaisse_Montant] DEFAULT (0) FOR [Montant]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[JournalCaisse]  TO [Utilisateurs]
GO
COMMIT TRANSACTION