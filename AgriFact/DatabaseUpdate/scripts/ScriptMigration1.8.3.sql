BEGIN TRANSACTION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FichierClient]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[FichierClient](
	[nFichier] [int] IDENTITY(1,1) NOT NULL,
	[nEntreprise] [decimal](10, 0) NOT NULL,
	[nPersonneAuteur] [decimal](10, 0) NULL,
	[CheminFichier] [nvarchar](512) NOT NULL,
	[IsLocal] [bit] NOT NULL CONSTRAINT [DF_FichierClient_IsLocal]  DEFAULT (1),
	[MachineName] [nvarchar](50) NULL,
	[DateModification] [datetime] NULL,
 CONSTRAINT [PK_FichierClient] PRIMARY KEY CLUSTERED 
(
	[nFichier] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_FichierClient_Entreprise]') AND type = 'F')
ALTER TABLE [dbo].[FichierClient]  WITH NOCHECK ADD  CONSTRAINT [FK_FichierClient_Entreprise] FOREIGN KEY([nEntreprise])
REFERENCES [dbo].[Entreprise] ([nEntreprise])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FichierClient] CHECK CONSTRAINT [FK_FichierClient_Entreprise]
GO
COMMIT TRANSACTION