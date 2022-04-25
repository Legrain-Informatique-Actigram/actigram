BEGIN TRANSACTION

IF not exists(select * from syscolumns c inner join sysobjects o on c.id=o.id where c.name='TxCommission' and o.name='VFacture') 
BEGIN
	ALTER TABLE VFacture ADD TxCommission INT NULL;
END
GO

COMMIT TRANSACTION