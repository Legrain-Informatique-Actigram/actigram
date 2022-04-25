BEGIN TRANSACTION
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CompositionProduit_Produit2]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE dbo.CompositionProduit DROP CONSTRAINT FK_CompositionProduit_Produit2
GO
COMMIT TRANSACTION
