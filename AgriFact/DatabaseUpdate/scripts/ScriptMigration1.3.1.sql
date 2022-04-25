BEGIN TRANSACTION

GO

update vfacture_detail 
set montantLigneHT = round(fd.montantligneTTC/(1+(t.tTaux/100)),2),
montantLigneTVA= case t.tTaux when 0 then 0 else round(fd.montantligneTTC / (1+(100/t.tTaux)),2) end
from VFacture_detail fd
inner join VFacture f on fd.ndevis=f.ndevis
inner join tva t on fd.ttva=t.ttva
where f.facturationttc=1
and abs(montantlignettc - montantligneht - montantlignetva) > 0.01

GO

COMMIT TRANSACTION
GO
