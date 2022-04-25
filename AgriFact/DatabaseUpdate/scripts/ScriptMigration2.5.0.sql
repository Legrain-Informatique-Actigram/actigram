﻿BEGIN TRANSACTION

--Ajout de la valeur 'Habillage' dans la table ListeChoix
DECLARE @NBNOMCHOIX INT

SET @NBNOMCHOIX = (	SELECT COUNT(NomChoix) AS NBNOMCHOIX 
					FROM ListeChoix 
					WHERE (NomChoix = 'ListeTypeMouvement') AND (nOrdreValeur = 81))

IF (@NBNOMCHOIX = 0)
BEGIN
	INSERT INTO ListeChoix(NomChoix, nOrdreValeur, Valeur) VALUES('ListeTypeMouvement', 81, 'Habillage') 
END
GO

--Ajout de la valeur 'Mise en bouteille' dans la table ListeChoix
DECLARE @NBNOMCHOIX INT

SET @NBNOMCHOIX = (	SELECT COUNT(NomChoix) AS NBNOMCHOIX 
					FROM ListeChoix 
					WHERE (NomChoix = 'ListeTypeMouvement') AND (nOrdreValeur = 91))

IF (@NBNOMCHOIX = 0)
BEGIN
	INSERT INTO ListeChoix(NomChoix, nOrdreValeur, Valeur) VALUES('ListeTypeMouvement', 91, 'Mise en bouteille') 
END
GO

--Modification de la procédure stockée CalculEtatStock
--Ajout des types de mouvements 'Habillage' et 'Mise en bouteille' dans le traitement
--Mise en commentaire du traitement sur les compositions BL, BC et facture
ALTER PROC [dbo].[CalculEtatStock](@dtDeb datetime, @dtFin datetime,@depot nvarchar(50),@gestionLot bit=1,@dtInit datetime='01/01/2000',@debug bit=0) AS
/*DECLARE @dtDeb datetime, @dtFin datetime,@depot nvarchar(50),@gestionLot bit,@dtInit datetime,@debug bit
SET @dtInit='01/11/2008'
SET @dtDeb='01/11/2008'
SET @dtFin='31/12/2010'
SET @depot='Global'
SET @gestionLot=0
SET @debug=0*/

SET @dtFin = dateadd(day,1,@dtFin) --On ajoute un jour pour inclure tous les mouvements de @dtFin

IF OBJECT_ID('tempdb..#tmp') IS NOT NULL drop table #tmp
IF OBJECT_ID('tempdb..#tmp2') IS NOT NULL drop table #tmp2

CREATE TABLE #tmp
	(TypeMouvement nvarchar(30),
	TypeMouvement2 nvarchar(15),
	nPiece nVarchar(50),
	DateMouvement datetime,
	Depot nVarchar(50),
	nLot nVarchar(50),
	CodeProduit nVarchar(50),
	Libelle text,
	Unite1 decimal(18,3),
	LibUnite1 nVarchar(50),
	Unite2 decimal(18,3),
	LibUnite2 nVarchar(50))

----------------------------------------------------------------------------------
-- 		MOUVEMENTS DE STOCK
----------------------------------------------------------------------------------

--MOUVEMENTS POSITIFS
--Entrées, Inventaire, Conditionnement, Fabrications pour le produit généré, Mouvements pour le dépot d'arrivée
INSERT INTO #tmp
SELECT TypeMouvement,
	case when Unite1>0 then 'Entrée' else 'Sortie' end, 
	nPiece, DateMouvement, DepotDest AS Depot, nLot, CodeProduit, Libelle,
	Unite1, LibUnite1,
	Unite2, LibUnite2
FROM Mouvement INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement IN ('Entrées','Fabrication','Inventaire','Conditionnement','Transfert dépôt','Régul stock', 'Habillage', 'Mise en bouteille')
AND CodeProduit IS NOT NULL AND CodeProduit <>''
AND DateMouvement>=@dtInit AND DateMouvement<@dtFin


--MOUVEMENTS NEGATIFS
--Sorties, Mouvements pour le dépot de départ
INSERT INTO #tmp
SELECT TypeMouvement,
	case when Unite1>0 then 'Sortie' else 'Entrée' end, 
	nPiece, DateMouvement, DepotDepart, nLot, CodeProduit, Libelle,
	- Unite1, LibUnite1,
	- Unite2, LibUnite2
FROM Mouvement INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement IN ('Sorties','Transfert dépôt')
AND CodeProduit IS NOT NULL AND CodeProduit <>''
AND DateMouvement>=@dtInit AND DateMouvement<@dtFin


--Fabrications sorties pour les produits entrant dans la fabrication
INSERT INTO #tmp
SELECT TypeMouvement + ' Compo','Sortie', nPiece, DateMouvement, DepotDest, nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
      - Mouvement_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
      - Mouvement_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM	   Mouvement
INNER JOIN Mouvement_Detail	ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
INNER JOIN CompositionProduit	ON CompositionProduit.CodeProduit = Mouvement_Detail.CodeProduit
WHERE TypeMouvement IN ('Fabrication', 'Habillage', 'Mise en bouteille')
AND Mouvement_Detail.CodeProduit IS NOT NULL AND Mouvement_Detail.CodeProduit <>''
AND DateMouvement>=@dtInit AND DateMouvement<@dtFin


----------------------------------------------------------------------------------
-- 		ACHATS ET VENTES
----------------------------------------------------------------------------------
-- Configuration
Declare @DepotDefaut nvarchar(50),@DepotVente nvarchar(50), @DirectionAchat nvarchar(50), @DirectionVente nvarchar(50),
	@signeAchat smallint, @signeVente smallint
Set @DepotDefaut='Centrale'
Set @DirectionAchat='Entrée'
Set @DirectionVente='Sortie'
Set @signeAchat = 1
Set @signeVente = -1

--Achats sur les bons de réception
INSERT INTO #tmp
SELECT 'BR',@DirectionAchat, nFacture, DateFacture, Depot, nLot, ABonReception_Detail.CodeProduit, ABonReception_Detail.Libelle,
	@signeAchat * ABonReception_Detail.Unite1,  ABonReception_Detail.LibUnite1,
	@signeAchat * ABonReception_Detail.Unite2, ABonReception_Detail.LibUnite2
FROM 	   ABonReception
INNER JOIN ABonReception_Detail	ON ABonReception.nDevis = ABonReception_Detail.nDevis
INNER JOIN Produit		ON ABonReception_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Achats sur les factures sans BR
INSERT INTO #tmp
SELECT 'Achat',@DirectionAchat, nFacture, DateFacture, Depot, nLot, AFacture_Detail.CodeProduit, AFacture_Detail.Libelle,
	@signeAchat * AFacture_Detail.Unite1,  AFacture_Detail.LibUnite1,
	@signeAchat * AFacture_Detail.Unite2, AFacture_Detail.LibUnite2
FROM 	   AFacture
INNER JOIN AFacture_Detail	ON AFacture.nDevis = AFacture_Detail.nDevis
INNER JOIN Produit		ON AFacture_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND NOT EXISTS (SELECT nOrigine FROM ABonReception WHERE ABonReception.nOrigine = AFacture.nDevis)
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Ventes sur les BL
INSERT INTO #tmp
SELECT 'BL',@DirectionVente, nFacture, DateFacture, Depot, nLot, VBonLivraison_Detail.CodeProduit, VBonLivraison_Detail.Libelle,
	@signeVente * VBonLivraison_Detail.Unite1, VBonLivraison_Detail.LibUnite1,
	@signeVente * VBonLivraison_Detail.Unite2, VBonLivraison_Detail.LibUnite2
FROM 	   VBonLivraison
INNER JOIN VBonLivraison_Detail	ON VBonLivraison.nDevis = VBonLivraison_Detail.nDevis
INNER JOIN Produit		ON VBonLivraison_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Ventes sur les factures n'ayant pas de BL
INSERT INTO #tmp
SELECT 'Vente',@DirectionVente, nFacture, DateFacture, Depot, nLot, VFacture_Detail.CodeProduit, VFacture_Detail.Libelle,
	@signeVente * VFacture_Detail.Unite1, VFacture_Detail.LibUnite1,
	@signeVente * VFacture_Detail.Unite2, VFacture_Detail.LibUnite2
FROM 	   VFacture
INNER JOIN VFacture_Detail	ON VFacture.nDevis = VFacture_Detail.nDevis
INNER JOIN Produit		ON VFacture_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND NOT EXISTS (SELECT nOrigine FROM VBonLivraison WHERE VBonLivraison.nOrigine = VFacture.nDevis)
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Commandes sur les bons de commandes non payés
INSERT INTO #tmp
SELECT 'Commande','EnCommande', nFacture, DateFacture, Depot, nLot, VBonCommande_Detail.CodeProduit, VBonCommande_Detail.Libelle,
	@signeVente * VBonCommande_Detail.Unite1,  VBonCommande_Detail.LibUnite1,
	@signeVente * VBonCommande_Detail.Unite2, VBonCommande_Detail.LibUnite2
FROM 	   VBonCommande
INNER JOIN VBonCommande_Detail	ON VBonCommande.nDevis = VBonCommande_Detail.nDevis
INNER JOIN Produit		ON VBonCommande_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND  (Paye = 0 OR Paye IS NULL)
AND DateFacture>=@dtInit AND DateFacture<@dtFin

-- GESTION DES COMPOSITIONS

--######## Mis en commentaire le 06/01/2011 par TV
/**--Vente sur les BL pour les compositions
INSERT INTO #tmp
SELECT	'BL Compo',@DirectionVente, nFacture, DateFacture, Depot, nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
      @signeVente * VBonLivraison_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
      @signeVente * VBonLivraison_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM 	   VBonLivraison
INNER JOIN VBonLivraison_Detail	ON VBonLivraison.nDevis = VBonLivraison_Detail.nDevis
INNER JOIN CompositionProduit	ON CompositionProduit.CodeProduit = VBonLivraison_Detail.CodeProduit
INNER JOIN Produit		ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Vente sur les factures sans BL pour les compositions
INSERT INTO #tmp
SELECT	'Vente Compo',@DirectionVente, nFacture, DateFacture, Depot, nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
	@signeVente * VFacture_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
	@signeVente * VFacture_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM	   VFacture
INNER JOIN VFacture_Detail	ON VFacture.nDevis = VFacture_Detail.nDevis
INNER JOIN CompositionProduit	ON CompositionProduit.CodeProduit = VFacture_Detail.CodeProduit
INNER JOIN Produit		ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND NOT EXISTS (SELECT nOrigine FROM VBonLivraison WHERE VBonLivraison.nOrigine = VFacture.nDevis)
AND DateFacture>=@dtInit AND DateFacture<@dtFin

--Commandes sur les bons de commandes non payés pour les compositions
INSERT INTO #tmp
SELECT	'Commande Compo','EnCommande', nFacture, DateFacture, Depot, nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
	@signeVente * VBonCommande_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
	@signeVente * VBonCommande_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM	   VBonCommande
INNER JOIN VBonCommande_Detail	ON VBonCommande.nDevis = VBonCommande_Detail.nDevis
INNER JOIN CompositionProduit	ON CompositionProduit.CodeProduit = VBonCommande_Detail.CodeProduit
INNER JOIN Produit		ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND (Paye = 0 OR Paye IS NULL)
AND DateFacture>=@dtInit AND DateFacture<@dtFin
**/

--Ventes via trames balance
INSERT INTO #tmp
SELECT 'Vente Balance',@DirectionVente, nTicket, dtTicket, @DepotVente, '', Trame.Plu, Produit.Libelle,
	@signeVente * Trame.Quantite  AS Unite1, Produit.Unite1 AS LibUnite1,
	0 AS Unite2, '' AS LibUnite2
FROM Trame
INNER JOIN Produit ON Trame.plu = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND dtTicket>=@dtInit AND dtTicket<@dtFin

--Dépot par défaut pour les achats et ventes
UPDATE #tmp Set Depot=@DepotDefaut Where Depot is null

--Gestion de la date de début : tous les mouvements antérieurs sont regroupés dans la colonne "Depart"
UPDATE #tmp Set TypeMouvement2 = 'Depart' Where DateMouvement<@DtDeb and TypeMouvement2<>'EnCommande'

--Correction eventuelle des LibUnites
UPDATE #tmp Set LibUnite1 = '' Where LibUnite1 is null
UPDATE #tmp Set LibUnite2 = '' Where LibUnite2 is null
UPDATE #tmp Set nLot = '' Where nLot is null
UPDATE #tmp Set Depot = 'Centrale' Where Depot is null

DELETE FROM #tmp WHERE Unite1 is null and Unite2 is null

IF @debug=1 select * from #tmp

----------------------------------------------------------------------------------
-- 		CALCUL DES RESULTATS
----------------------------------------------------------------------------------
--Création de la table résultat
CREATE TABLE #tmp2
	(TypeMouvement nVarchar(30),
	Depot nVarchar(50),
	nLot nVarchar(50),
	CodeProduit nVarchar(50),
	LibUnite1 nVarchar(50),
	LibUnite2 nVarchar(50),
	Depart decimal(18,3),
	Entrée decimal(18,3),
	Sortie decimal(18,3),
	EnCommande decimal(18,3),
	DepartU2 decimal(18,3),
	EntréeU2 decimal(18,3),
	SortieU2 decimal(18,3),
	EnCommandeU2 decimal(18,3))

--Ventilation des mouvements
IF @depot='Global' BEGIN -- Pas de détail suivant les dépots
	INSERT INTO #tmp2
	SELECT TypeMouvement,null,nLot,CodeProduit,LibUnite1,LibUnite2,
	Depart =	case when TypeMouvement2='Depart'	then Sum(Unite1) end,
	Entrée =	case when TypeMouvement2='Entrée'	then Sum(Unite1) end,
	Sortie =	case when TypeMouvement2='Sortie'	then Sum(Unite1) end,
	EnCommande =	case when TypeMouvement2='EnCommande'	then Sum(Unite1) end,
	DepartU2 =	case when TypeMouvement2='Depart'	then Sum(Unite2) end,
	EntréeU2 =	case when TypeMouvement2='Entrée'	then Sum(Unite2) end,
	SortieU2 =	case when TypeMouvement2='Sortie'	then Sum(Unite2) end,
	EnCommandeU2 =	case when TypeMouvement2='EnCommande'	then Sum(Unite2) end
	FROM #tmp
	GROUP BY CodeProduit,TypeMouvement,nLot,TypeMouvement2,LibUnite1,LibUnite2

END ELSE IF @depot='Tous' or @depot='' BEGIN 
	INSERT INTO #tmp2
	SELECT TypeMouvement,Depot,nLot,CodeProduit,LibUnite1,LibUnite2,
	Depart =	case when TypeMouvement2='Depart'	then Sum(Unite1) end,
	Entrée =	case when TypeMouvement2='Entrée'	then Sum(Unite1) end,
	Sortie =	case when TypeMouvement2='Sortie'	then Sum(Unite1) end,
	EnCommande =	case when TypeMouvement2='EnCommande'	then Sum(Unite1) end,
	DepartU2 =	case when TypeMouvement2='Depart'	then Sum(Unite2) end,
	EntréeU2 =	case when TypeMouvement2='Entrée'	then Sum(Unite2) end,
	SortieU2 =	case when TypeMouvement2='Sortie'	then Sum(Unite2) end,
	EnCommandeU2 =	case when TypeMouvement2='EnCommande'	then Sum(Unite2) end
	FROM #tmp
	GROUP BY TypeMouvement,CodeProduit,Depot,nLot,TypeMouvement2,LibUnite1,LibUnite2

END ELSE BEGIN -- Pour un dépot en particulier
	INSERT INTO #tmp2
	SELECT TypeMouvement,Depot,nLot,CodeProduit,LibUnite1,LibUnite2,
	Depart =	case when TypeMouvement2='Depart'	then Sum(Unite1) end,
	Entrée =	case when TypeMouvement2='Entrée'	then Sum(Unite1) end,
	Sortie =	case when TypeMouvement2='Sortie'	then Sum(Unite1) end,
	EnCommande =	case when TypeMouvement2='EnCommande'	then Sum(Unite1) end,
	DepartU2 =	case when TypeMouvement2='Depart'	then Sum(Unite2) end,
	EntréeU2 =	case when TypeMouvement2='Entrée'	then Sum(Unite2) end,
	SortieU2 =	case when TypeMouvement2='Sortie'	then Sum(Unite2) end,
	EnCommandeU2 =	case when TypeMouvement2='EnCommande'	then Sum(Unite2) end
	FROM #tmp WHERE Depot=@depot
	GROUP BY TypeMouvement,CodeProduit,Depot,nLot,TypeMouvement2,LibUnite1,LibUnite2
END

-- Gestion des lots
IF @gestionLot=0 BEGIN
	-- Si on ne gère pas les lots, on les mets tous à vide
	UPDATE #tmp2 SET nLot=''
END ELSE BEGIN
	-- Sinon, on ne met à vide que les lots terminés
	UPDATE #tmp2 SET nLot='' WHERE nLot in (SELECT nLot FROM Lot WHERE Termine=1)
END

-- Aggrégation des résultats
SELECT Depot,t.nLot,f.Famille,t.CodeProduit,p.Libelle,p.SeuilStock,p.ProduitAchat,p.ProduitVente,LibUnite1,LibUnite2,
	Sum(Isnull(Depart,0))	    as Depart,
	Sum(Isnull(Entrée,0))	    as Entrée,
	Sum(Isnull(Sortie,0))	    as Sortie,
	Sum(Isnull(EnCommande,0))   as EnCommande,
	Sum(Isnull(DepartU2,0))	    as DepartU2,
	Sum(Isnull(EntréeU2,0))	    as EntréeU2,
	Sum(Isnull(SortieU2,0))	    as SortieU2,
	Sum(Isnull(EnCommandeU2,0)) as EnCommandeU2,
	Max(Case when lt.Nlot is null then 0 else 1 end) as LotTermine
FROM #tmp2 t 
LEFT JOIN Produit p ON p.CodeProduit=t.CodeProduit
LEFT JOIN Famille f ON f.nFamille=p.Famille1
LEFT JOIN LotsTermines lt ON t.CodeProduit=lt.CodeProduit AND t.NLot=lt.NLot
GROUP BY f.Famille,t.CodeProduit,Depot,t.nLot,p.Libelle,p.SeuilStock,p.ProduitAchat,p.ProduitVente,LibUnite1,LibUnite2
ORDER BY f.Famille,t.CodeProduit,Depot,t.nLot

DROP TABLE #tmp
DROP TABLE #tmp2
GO

COMMIT TRANSACTION