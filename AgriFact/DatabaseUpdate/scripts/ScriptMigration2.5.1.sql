BEGIN TRANSACTION

--Création de la table LotProduit
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[LotProduit]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[LotProduit](
		[IdLotProduit] [int] IDENTITY(1,1) NOT NULL,
		[nLot] [nvarchar](50) NOT NULL,
		[CodeProduit] [nvarchar](255) NOT NULL,
		[DateCreation] [datetime] NULL,
		[DateModif] [datetime] NULL,
	 CONSTRAINT [PK_LotProduit] PRIMARY KEY CLUSTERED 
	(
		[IdLotProduit] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_LotProduit_Lot]') AND type = 'F')
BEGIN
	ALTER TABLE [dbo].[LotProduit]  WITH NOCHECK ADD  CONSTRAINT [FK_LotProduit_Lot] FOREIGN KEY([nLot])
	REFERENCES [dbo].[Lot] ([nLot])
END
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_LotProduit_Produit]') AND type = 'F')
BEGIN
	ALTER TABLE [dbo].[LotProduit]  WITH NOCHECK ADD  CONSTRAINT [FK_LotProduit_Produit] FOREIGN KEY([CodeProduit])
	REFERENCES [dbo].[Produit] ([CodeProduit])
END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[LotProduit]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	GRANT INSERT, UPDATE, SELECT, DELETE ON OBJECT::LotProduit TO Utilisateurs;	
END
GO

COMMIT TRANSACTION