BEGIN TRANSACTION

IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ModeReglement_Detail')
BEGIN
	CREATE TABLE [dbo].[ModeReglement_Detail](
		[ID_ModeReglement_Detail] [int] IDENTITY(1,1) NOT NULL,
		[ModeReglement] [nvarchar](50) NULL,
		[nBanque] [numeric](18, 0) NULL,
		[RemiseAuto] [bit] NOT NULL,
	 CONSTRAINT [PK_ModeReglement_Detail] PRIMARY KEY CLUSTERED 
	(
		[ID_ModeReglement_Detail] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ModeReglement_Detail]  WITH CHECK ADD  CONSTRAINT [FK_ModeReglement_Detail_Banque] FOREIGN KEY([nBanque])
	REFERENCES [dbo].[Banque] ([nBanque])

	ALTER TABLE [dbo].[ModeReglement_Detail] CHECK CONSTRAINT [FK_ModeReglement_Detail_Banque]

	ALTER TABLE [dbo].[ModeReglement_Detail] ADD  CONSTRAINT [DF_ModeReglement_Detail_RemiseAuto]  DEFAULT ((0)) FOR [RemiseAuto]
	
	GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ModeReglement_Detail]  TO [Utilisateurs]
END
GO

IF NOT EXISTS (	SELECT name 
				FROM sys.indexes
				WHERE name = N'IX_ModeReglement_Detail_nBanque')
BEGIN
	CREATE INDEX IX_ModeReglement_Detail_nBanque 
		ON [dbo].[ModeReglement_Detail](nBanque); 
END
GO

COMMIT TRANSACTION