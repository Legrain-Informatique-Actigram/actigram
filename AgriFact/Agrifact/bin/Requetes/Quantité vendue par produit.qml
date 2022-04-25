<?xml version="1.0" encoding="utf-8"?>
<Requete xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <CommandText>
--Quantité vendue par produit
select p.Codeproduit,p.Libelle, Sum(fd.Unite1) as TotalU1,p.Unite1, Sum(fd.Unite2) as TotalU2,p.Unite2,Sum(MontantLigneHT) as CAHT
from produit p
inner join vfacture_detail fd on p.codeproduit=fd.codeproduit
inner join vfacture f on fd.ndevis=f.ndevis
where datefacture between @DtDeb and dateadd(day,1,@DtFin)
group by p.Codeproduit,p.Libelle,p.Unite1,p.Unite2
</CommandText>
  <Parametres>
	<Parametre Nom="@dtDeb" Type="DateTime" Libelle="Du"/>
	<Parametre Nom="@dtFin" Type="DateTime" Libelle="au"/>
  </Parametres>
  <Titre>Quantité vendue par produit</Titre>
  <Colonnes>
    <Colonne Field="CodeProduit" Entete="Code" Format="" />
    <Colonne Field="Libelle" Entete="Produit" Format="" />
	<Colonne Field="TotalU1" Entete="Unité 1" Format="N2"  Align="right"/>
    <Colonne Field="Unite1" Entete="" Format="" />
	<Colonne Field="TotalU2" Entete="Unité 2" Format="N2"  Align="right"/>
    <Colonne Field="Unite2" Entete="" Format="" />
	<Colonne Field="CAHT" Entete="CA HT" Format="C2"  Align="right"/>
  </Colonnes>
</Requete>