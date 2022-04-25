<?xml version="1.0" encoding="utf-8"?>
<Requete xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <CommandText>
  --Récap TVA
select TLibelle,TTaux,Sum(MontantLigneHT) as TotalHT,Sum(MontantLigneTVA) as TotalTVA,Sum(MontantLigneTTC) as TotalTTC
from TVA t
inner join VFacture_Detail fd on t.ttva=fd.ttva
inner join VFacture f on f.ndevis=fd.ndevis
where datefacture between @DtDeb and dateadd(second,-1,dateadd(day,1,@DtFin))
group by TLibelle,TTaux
</CommandText>
  <Parametres>
	<Parametre Nom="@dtDeb" Type="DateTime" Libelle="Du"/>
	<Parametre Nom="@dtFin" Type="DateTime" Libelle="au"/>
  </Parametres>
  <Titre>Récap TVA Vente</Titre>
  <Colonnes>
    <Colonne Field="TLibelle" Entete="Libellé" Format="" />
    <Colonne Field="TTaux" Entete="Taux" Format="#0.00 '%'" Align="right" />
    <Colonne Field="TotalHT" Entete="Total HT" Format="C2" Align="right" />
	<Colonne Field="TotalTVA" Entete="Total TVA" Format="C2" Align="right" />
	<Colonne Field="TotalTTC" Entete="Total TTC" Format="C2" Align="right" />    
  </Colonnes>
</Requete>