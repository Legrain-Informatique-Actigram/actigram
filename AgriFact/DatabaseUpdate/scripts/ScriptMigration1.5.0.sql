BEGIN TRANSACTION
GO
ALTER TABLE dbo.Parametres ADD
	Cle nvarchar(50) NULL,
    TypePiece nvarchar(50) NULL,
	Valeur ntext NULL
GO
UPDATE dbo.Parametres SET Cle='Logo' WHERE Logo IS NOT NULL
GO
COMMIT