create proc EtatNonConfSchema(@dtDeb datetime,@dtFin datetime)
as
/*declare @dtDeb datetime,@dtFin datetime
set @dtDeb= '01/04/2008'
set @dtFin= '15/05/2008'
set @dtFin = dateadd(day,1,@dtFin)

select distinct codeProduit, nLot, DateMouvement as dtLot
into #tmp
from Mouvement_Detail md
inner join Mouvement m on m.nMouvement=md.nMouvement
where DateMouvement>=@dtDeb and DateMouvement<@dtFin and Unite1>0

insert into #tmp
select distinct codeProduit,nLot,DateFacture as dtlot
from ABonReception_Detail brd
inner join ABonReception br on br.ndevis=brd.ndevis
where DateFacture>=@dtDeb and DateFacture<@dtFin

--select * from #tmp order by dtlot,nlot,codeproduit*/

select DateMouvement as dtLot,res.nLot, res.CodeProduit,
def.groupe,def.libelle,
res.Resultat,
rb.nresultatbareme,b.actioncorrective,
rb.ActionCorrectiveEffectuee--,rb.Observations
from resultatcontrole res
inner join definitioncontrole def on def.ncontrole=res.ncontrole
inner join resultatbareme rb on res.nresultatcontrole=rb.nresultatcontrole
inner join bareme b on rb.nbareme=b.nbareme
inner join mouvement_detail as pr on pr.CodeProduit=res.CodeProduit and pr.nLot = res.nLot
inner join Mouvement m on m.nMouvement=pr.nMouvement
where TestEffectue=1 AND res.ResultatConformite=0 AND rb.ResultatConformite=0
--order by pr.dtLot,res.nLot, res.CodeProduit

--drop table #tmp