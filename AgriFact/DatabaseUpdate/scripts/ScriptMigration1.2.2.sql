BEGIN TRANSACTION
GO
CREATE PROCEDURE RemoveLastNFacture (
	@NomTable as Varchar(50),
	@NFactureAAnnuler as int, 
	@Simu as bit) AS
DECLARE @NFacture int;
BEGIN TRANSACTION

-- Trouver valeur courante
Select @NFacture=Max(NFacture) From NFacture Where TypePiece=@NomTable;

-- Calculer la nouvelle valeur et suivant le cas crer la ligne ou la mettre  jour
If @NFacture = @NFactureAAnnuler  begin
	Update NFacture set NFacture =@NFactureAAnnuler-1 where TypePiece=@NomTable;
end

-- On n'enregistre que si on n'est pas en mode simulation
if @Simu=0 begin
	COMMIT TRANSACTION
end else begin
	ROLLBACK TRANSACTION
end
GO
GRANT  EXECUTE  ON [dbo].[RemoveLastNFacture]  TO [Utilisateurs]
GO
COMMIT TRANSACTION
GO
