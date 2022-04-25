<?xml version="1.0" encoding="utf-8"?>
<Requete xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<CommandText>
		SELECT Civilite, Nom, Adresse, CodePostal, Ville, Pays, Critere1, Critere2, Critere3, Critere4 FROM Entreprise WHERE Critere2>=@Critere2 and Inactif=0 AND TypeClient=@TypeClient AND Critere1=@Critere_1_1 OR Critere1=@Critere_1_2  OR Critere1=@Critere_1_3 ORDER BY Nom
	</CommandText>
  	<Parametres>
		<Parametre Nom="@Critere2" Type="String" Libelle="Année >="/>
		<Parametre Nom="@TypeClient" Type="String" Libelle="Type client"/>
		<Parametre Nom="@Critere_1_1" Type="String" Libelle="Critere_1_1"/>
		<Parametre Nom="@Critere_1_2" Type="String" Libelle="Critere_1_2"/>
		<Parametre Nom="@Critere_1_3" Type="String" Libelle="Critere_1_3"/>
	</Parametres>
	<Titre>Liste clients mailing</Titre>
  	<Colonnes>
    		<Colonne Field="Civilite" Entete="Civilité" Format="" />
		<Colonne Field="Nom" Entete="Nom" Format="" />
		<Colonne Field="Adresse" Entete="Adresse" Format="" />
		<Colonne Field="CodePostal" Entete="CodePostal" Format="" />
		<Colonne Field="Ville" Entete="Ville" Format="" />
		<Colonne Field="Pays" Entete="Pays" Format="" />
		<Colonne Field="Critere1" Entete="Critere1" Format="" />
		<Colonne Field="Critere2" Entete="Critere2" Format="" />
		<Colonne Field="Critere3" Entete="Critere3" Format="" />
		<Colonne Field="Critere4" Entete="Critere4" Format="" />
  	</Colonnes>
</Requete>