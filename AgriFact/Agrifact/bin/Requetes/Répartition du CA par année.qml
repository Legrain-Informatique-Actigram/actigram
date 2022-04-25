<?xml version="1.0" encoding="utf-8"?>
<Requete xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <CommandText>
 --Répartition du CA par année
declare @catotal decimal(10,2)
select @catotal = Sum(MontantLigneHT) 
from vfacture f
inner join VFacture_Detail fd on f.ndevis=fd.ndevis
where datefacture between @DtDeb and dateadd(day,1,@DtFin)

select Datepart(year,datefacture)as Annee,Sum(MontantLigneHT) as CAHT,Sum(MontantLigneHT)/@caTotal as PcCATotal
from vfacture f
inner join VFacture_Detail fd on f.ndevis=fd.ndevis
where datefacture between @DtDeb and dateadd(day,1,@DtFin)
group by Datepart(year,datefacture)
</CommandText>
  <Parametres>
	<Parametre Nom="@dtDeb" Type="DateTime" Libelle="Du"/>
	<Parametre Nom="@dtFin" Type="DateTime" Libelle="au"/>
  </Parametres>
  <Titre>Répartition du CA par année</Titre>
  <Colonnes>
    <Colonne Field="Annee" Entete="Année" Format="" />
    <Colonne Field="CAHT" Entete="CA HT" Format="C2"  Align="right"/>
	<Colonne Field="PcCATotal" Entete="Pourcentage" Format="P2"  Align="right"/>
  </Colonnes>
</Requete>