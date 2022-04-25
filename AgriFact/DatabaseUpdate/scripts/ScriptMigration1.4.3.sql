BEGIN TRANSACTION
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CalculEtatStock]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CalculEtatStock]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROC CalculEtatStock(@dtDeb datetime, @dtFin datetime,@depot nvarchar(50))AS
/*DECLARE @dtDeb datetime, @dtFin datetime,@depot nvarchar(50)
SET @dtDeb='01/08/2007'
SET @dtFin='22/08/2007'
SET @depot='Centrale'*/

SET @dtFin = dateadd(day,1,@dtFin)

IF OBJECT_ID('tempdb..#tmp') IS NOT NULL drop table #tmp
IF OBJECT_ID('tempdb..#tmp2') IS NOT NULL drop table #tmp2

create table #tmp
(TypeMouvement nvarchar(15),
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

--Entr�es
INSERT INTO #tmp
SELECT 'Entr�e','Entr�e', nPiece, DateMouvement, DepotDepart AS Depot, nLot, CodeProduit, Libelle,
	Unite1, LibUnite1,
	Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement = 'Entr�es'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Sorties
INSERT INTO #tmp
SELECT 'Sortie','Sortie', nPiece, DateMouvement, DepotDepart, nLot, CodeProduit, Libelle,
	- Unite1, LibUnite1,
	- Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement = 'Sorties'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Mouvements sorties pour le d�pot de d�part
INSERT INTO #tmp
SELECT 'MouvementS','Sortie', nPiece, DateMouvement, DepotDepart, nLot, CodeProduit, Libelle,
	- Unite1, LibUnite1,
	- Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement = 'Mouvement'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Mouvements entr�es pour le d�pot d'arriv�e
INSERT INTO #tmp
SELECT 'MouvementE','Entr�e', nPiece, DateMouvement, DepotDest, nLot, CodeProduit, Libelle,
	Unite1, LibUnite1,
	Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE  TypeMouvement = 'Mouvement'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Fabrications entr�es pour le produit g�n�r�
INSERT INTO #tmp
SELECT 'FabricationE','Entr�e', nPiece, DateMouvement, DepotDepart, nLot, CodeProduit, Libelle,
	Unite1, LibUnite1,
	Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement = 'Fabrication'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Fabrications sorties pour les produits entrant dans la fabrication
INSERT INTO #tmp
SELECT 'FabricationS','Sortie', nPiece, DateMouvement, DepotDepart, nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
      - Mouvement_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
      - Mouvement_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
INNER JOIN CompositionProduit ON CompositionProduit.CodeProduit = Mouvement_Detail.CodeProduit
WHERE TypeMouvement = 'Fabrication'
AND DateMouvement<@dtFin

--Inventaires
INSERT INTO #tmp
SELECT 'Inventaire',
	case when Unite1>0 then 'Entr�e' else 'Sortie' end, 
	nPiece, DateMouvement, DepotDepart, nLot, CodeProduit, Libelle,
	Unite1, LibUnite1,
	Unite2, LibUnite2
FROM Mouvement
INNER JOIN Mouvement_Detail ON Mouvement.nMouvement = Mouvement_Detail.nMouvement
WHERE TypeMouvement = 'Inventaire'
AND CodeProduit is not null AND CodeProduit <>''
AND DateMouvement<@dtFin

--Achats sur les bons de r�ception
INSERT INTO #tmp
SELECT 'Achat','Entr�e', nFacture, DateFacture, 'Centrale', nLot, ABonReception_Detail.CodeProduit, ABonReception_Detail.Libelle,
	ABonReception_Detail.Unite1,  ABonReception_Detail.LibUnite1,
	ABonReception_Detail.Unite2, ABonReception_Detail.LibUnite2
FROM ABonReception
INNER JOIN ABonReception_Detail ON ABonReception.nDevis = ABonReception_Detail.nDevis
INNER JOIN Produit ON ABonReception_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND DateFacture<@dtFin

--Achats sur les factures sans BR
INSERT INTO #tmp
SELECT 'Achat','Entr�e', nFacture, DateFacture, 'Centrale', nLot, AFacture_Detail.CodeProduit, AFacture_Detail.Libelle,
	AFacture_Detail.Unite1,  AFacture_Detail.LibUnite1,
	AFacture_Detail.Unite2, AFacture_Detail.LibUnite2
FROM AFacture
INNER JOIN AFacture_Detail ON AFacture.nDevis = AFacture_Detail.nDevis
INNER JOIN Produit ON AFacture_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND NOT EXISTS (SELECT nOrigine FROM ABonReception WHERE ABonReception.nOrigine = AFacture.nDevis)
AND DateFacture<@dtFin

--Ventes sur les bons de livraisons
INSERT INTO #tmp
SELECT 'Vente','Sortie', nFacture, DateFacture, 'Centrale', nLot, VBonLivraison_Detail.CodeProduit, VBonLivraison_Detail.Libelle,
	- VBonLivraison_Detail.Unite1, VBonLivraison_Detail.LibUnite1,
	- VBonLivraison_Detail.Unite2, VBonLivraison_Detail.LibUnite2
FROM VBonLivraison
INNER JOIN VBonLivraison_Detail ON VBonLivraison.nDevis = VBonLivraison_Detail.nDevis
INNER JOIN Produit ON VBonLivraison_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND DateFacture<@dtFin

--Ventes sur les factures n'ayant pas de BL
INSERT INTO #tmp
SELECT 'Vente','Sortie', nFacture, DateFacture, 'Centrale', nLot, VFacture_Detail.CodeProduit, VFacture_Detail.Libelle,
	- VFacture_Detail.Unite1, VFacture_Detail.LibUnite1,
	- VFacture_Detail.Unite2, VFacture_Detail.LibUnite2
FROM VFacture
INNER JOIN VFacture_Detail ON VFacture.nDevis = VFacture_Detail.nDevis
INNER JOIN Produit ON VFacture_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND NOT EXISTS (SELECT nOrigine FROM VBonLivraison WHERE VBonLivraison.nOrigine = VFacture.nDevis)
AND DateFacture<@dtFin

--Commandes sur les bons de commandes non pay�s
INSERT INTO #tmp
SELECT 'Commande','EnCommande', nFacture, DateFacture, 'Centrale', nLot, VBonCommande_Detail.CodeProduit, VBonCommande_Detail.Libelle,
	- VBonCommande_Detail.Unite1,  VBonCommande_Detail.LibUnite1,
	- VBonCommande_Detail.Unite2, VBonCommande_Detail.LibUnite2
FROM VBonCommande
INNER JOIN VBonCommande_Detail ON VBonCommande.nDevis = VBonCommande_Detail.nDevis
INNER JOIN Produit ON VBonCommande_Detail.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND  (Paye = 0 OR Paye IS NULL)
AND DateFacture<@dtFin

--Vente sur les BL pour les compositions
INSERT INTO #tmp
SELECT	'Vente','Sortie', nFacture, DateFacture, 'Centrale', nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
      - VBonLivraison_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
      - VBonLivraison_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM VBonLivraison
INNER JOIN VBonLivraison_Detail ON VBonLivraison.nDevis = VBonLivraison_Detail.nDevis
INNER JOIN CompositionProduit ON CompositionProduit.CodeProduit = VBonLivraison_Detail.CodeProduit
INNER JOIN Produit ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND DateFacture<@dtFin

--Vente sur les factures sans BL pour les compositions
INSERT INTO #tmp
SELECT	'Vente','Sortie', nFacture, DateFacture, 'Centrale', nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
	- VFacture_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
	- VFacture_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM	   VFacture
INNER JOIN VFacture_Detail ON VFacture.nDevis = VFacture_Detail.nDevis
INNER JOIN CompositionProduit ON CompositionProduit.CodeProduit = VFacture_Detail.CodeProduit
INNER JOIN Produit ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND NOT EXISTS (SELECT nOrigine FROM VBonLivraison WHERE VBonLivraison.nOrigine = VFacture.nDevis)
AND DateFacture<@dtFin

--Commandes sur les bons de commandes non pay�s pour les compositions
INSERT INTO #tmp
SELECT	'Commande','EnCommande', nFacture, DateFacture, 'Centrale', nLot, CompositionProduit.CodeProduitComposition, CompositionProduit.Libelle,
	- VBonCommande_Detail.Unite1 * CompositionProduit.Unite1 AS Unite1, CompositionProduit.LibUnite1 AS LibUnite1,
	- VBonCommande_Detail.Unite2 * CompositionProduit.Unite2 AS Unite2, CompositionProduit.LibUnite2 AS LibUnite2
FROM	   VBonCommande
INNER JOIN VBonCommande_Detail ON VBonCommande.nDevis = VBonCommande_Detail.nDevis
INNER JOIN CompositionProduit ON CompositionProduit.CodeProduit = VBonCommande_Detail.CodeProduit
INNER JOIN Produit ON CompositionProduit.CodeProduit = Produit.CodeProduit
WHERE Produit.GestionStock = 1 AND Produit.DecompteAuto = 1
AND (Paye = 0 OR Paye IS NULL)
AND DateFacture<@dtFin

--Ventes via trames balance
INSERT INTO #tmp
SELECT 'Vente','Sortie', nTicket, dtTicket, 'Centrale', '', Trame.Plu, Produit.Libelle,
	- Trame.Quantite  AS Unite1, Produit.Unite1 AS LibUnite1,
	0 AS Unite2, '' AS LibUnite2
FROM Trame
INNER JOIN Produit ON Trame.plu = Produit.CodeProduit
WHERE Produit.GestionStock = 1
AND dtTicket<@dtFin

--Regroupement des types de MVT
UPDATE #tmp Set TypeMouvement2 = 'Depart' Where DateMouvement<@DtDeb and TypeMouvement<>'Commande'

--Cr�ation de la table r�sultat
create table #tmp2
(TypeMouvement nVarchar(15),
Depot nVarchar(50),
nLot nVarchar(50),
CodeProduit nVarchar(50),
LibUnite1 nVarchar(50),
LibUnite2 nVarchar(50),
Depart decimal(18,3),
Entr�e decimal(18,3),
Sortie decimal(18,3),
EnCommande decimal(18,3),
DepartU2 decimal(18,3),
Entr�eU2 decimal(18,3),
SortieU2 decimal(18,3),
EnCommandeU2 decimal(18,3))

if @depot='Tous' begin
	insert into #tmp2
	select TypeMouvement,null,null,CodeProduit,
	LibUnite1,LibUnite2,
	Depart = case when TypeMouvement2='Depart' then Sum(Unite1) end,
	Entr�e = case when TypeMouvement2='Entr�e' then Sum(Unite1) end,
	Sortie = case when TypeMouvement2='Sortie' then Sum(Unite1) end,
	EnCommande = case when TypeMouvement2='EnCommande' then Sum(Unite1) end,
	DepartU2 = case when TypeMouvement2='Depart' then Sum(Unite2) end,
	Entr�eU2 = case when TypeMouvement2='Entr�e' then Sum(Unite2) end,
	SortieU2 = case when TypeMouvement2='Sortie' then Sum(Unite2) end,
	EnCommandeU2 = case when TypeMouvement2='EnCommande' then Sum(Unite2) end
	from #tmp
	group by CodeProduit,TypeMouvement,TypeMouvement2,LibUnite1,LibUnite2

end else if @depot='' begin
	insert into #tmp2
	select TypeMouvement,Depot,nLot,CodeProduit,
	LibUnite1,LibUnite2,
	Depart = case when TypeMouvement2='Depart' then Sum(Unite1) end,
	Entr�e = case when TypeMouvement2='Entr�e' then Sum(Unite1) end,
	Sortie = case when TypeMouvement2='Sortie' then Sum(Unite1) end,
	EnCommande = case when TypeMouvement2='EnCommande' then Sum(Unite1) end,
	DepartU2 = case when TypeMouvement2='Depart' then Sum(Unite2) end,
	Entr�eU2 = case when TypeMouvement2='Entr�e' then Sum(Unite2) end,
	SortieU2 = case when TypeMouvement2='Sortie' then Sum(Unite2) end,
	EnCommandeU2 = case when TypeMouvement2='EnCommande' then Sum(Unite2) end
	from #tmp
	group by TypeMouvement,CodeProduit,Depot,nLot,TypeMouvement2,LibUnite1,LibUnite2

end else begin
	insert into #tmp2
	select TypeMouvement,Depot,nLot,CodeProduit,
	LibUnite1,LibUnite2,
	Depart = case when TypeMouvement2='Depart' then Sum(Unite1) end,
	Entr�e = case when TypeMouvement2='Entr�e' then Sum(Unite1) end,
	Sortie = case when TypeMouvement2='Sortie' then Sum(Unite1) end,
	EnCommande = case when TypeMouvement2='EnCommande' then Sum(Unite1) end,
	DepartU2 = case when TypeMouvement2='Depart' then Sum(Unite2) end,
	Entr�eU2 = case when TypeMouvement2='Entr�e' then Sum(Unite2) end,
	SortieU2 = case when TypeMouvement2='Sortie' then Sum(Unite2) end,
	EnCommandeU2 = case when TypeMouvement2='EnCommande' then Sum(Unite2) end
	from #tmp
	where Depot=@depot
	group by TypeMouvement,CodeProduit,Depot,nLot,TypeMouvement2,LibUnite1,LibUnite2
end

SELECT Depot,nLot,f.Famille,t.CodeProduit,p.Libelle,LibUnite1,LibUnite2,
Isnull(Sum(Depart),0) as Depart,
Isnull(Sum(Entr�e),0) as Entr�e,
Isnull(Sum(Sortie),0) as Sortie,
Isnull(Sum(EnCommande),0) as EnCommande,
Isnull(Sum(DepartU2),0) as DepartU2,
Isnull(Sum(Entr�eU2),0) as Entr�eU2,
Isnull(Sum(SortieU2),0) as SortieU2,
Isnull(Sum(EnCommandeU2),0) as EnCommandeU2
FROM #tmp2 t 
inner join Produit p on p.CodeProduit=t.CodeProduit
inner join Famille f on f.nFamille=p.Famille1
group by f.Famille,t.CodeProduit,Depot,nLot,p.Libelle,LibUnite1,LibUnite2
order by f.Famille,t.CodeProduit,Depot,nLot

DROP TABLE #tmp
DROP TABLE #tmp2



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
COMMIT TRANSACTION
