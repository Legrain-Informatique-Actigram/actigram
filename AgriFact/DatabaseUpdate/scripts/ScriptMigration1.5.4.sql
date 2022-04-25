--Correction export compta : Ajout Montant Escompte plus correction de la régulation de TVA sur encaissement partiel

BEGIN TRANSACTION
GO

ALTER TABLE Reglement_Detail
ADD MtEscompte DECIMAL(18,2);
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FactureMontantExport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE [dbo].[FactureMontantExport];
	CREATE TABLE [dbo].[FactureMontantExport] (
		[nDevis] [decimal](18, 0) NOT NULL ,
		[TTVA] [nvarchar] (50) COLLATE French_CI_AS NOT NULL ,
		[MontantHT] [decimal](18, 2) NULL ,
		[MontantTTC] [decimal](18, 2) NULL ,
		[MontantTVA] [decimal](18, 2) NULL ,
		[DateExportCompta] [datetime] NOT NULL,
		[nDetailReglement] decimal(10, 0) NULL
	) ON [PRIMARY];
	GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[FactureMontantExport]  TO [Utilisateurs];
	ALTER TABLE [dbo].[FactureMontantExport] WITH NOCHECK ADD 
	CONSTRAINT [PK_FactureMontantExport] PRIMARY KEY  CLUSTERED 
	(
		[nDevis],
		[TTVA],
		[DateExportCompta]
	)  ON [PRIMARY] ;
END ELSE BEGIN
	ALTER TABLE dbo.FactureMontantExport ADD
	nDetailReglement decimal(10, 0) NULL
END
GO

COMMIT TRANSACTION