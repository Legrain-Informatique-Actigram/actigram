<?xml version="1.0" encoding="utf-8"?>
<Requete xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <CommandText>
    SELECT Entreprise.Civilite, Entreprise.Nom, Entreprise.TypeClient, CAST(Entreprise.Observations AS VARCHAR) AS Observations,
    CAST(Entreprise.Adresse AS VARCHAR) AS Adresse, Entreprise.CodePostal, Entreprise.Ville, Entreprise.Pays, 
    MAX(VFacture.DateFacture) AS MaxDateFacture
    FROM Entreprise LEFT OUTER JOIN
    VFacture ON Entreprise.nEntreprise = VFacture.nClient
    WHERE (Entreprise.Client = 1)
    GROUP BY Entreprise.Civilite, Entreprise.Nom, Entreprise.TypeClient, Entreprise.CodePostal, Entreprise.Ville, 
    Entreprise.Pays, CAST(Entreprise.Observations AS VARCHAR), CAST(Entreprise.Adresse AS VARCHAR)
    ORDER BY Entreprise.Nom
  </CommandText>
  <Parametres>
  </Parametres>
  <Titre>Liste des clients avec date de dernière facture</Titre>
  <Colonnes>
    <Colonne Field="Civilite" Entete="Civilité" Format="left" />
    <Colonne Field="Nom" Entete="Nom" Format="left" />
    <Colonne Field="TypeClient" Entete="Type Client" Format="left" />
    <Colonne Field="Observations" Entete="Observations" Format="left" />
    <Colonne Field="Adresse" Entete="Adresse" Format="left" />
    <Colonne Field="CodePostal" Entete="CP" Format="left" />
    <Colonne Field="Ville" Entete="Ville" Format="left" />
    <Colonne Field="Pays" Entete="Pays" Format="left" />
    <Colonne Field="MaxDateFacture" Entete="Date dernière facture" Align="left"/>
  </Colonnes>
</Requete>