-------------------------------------------------------------------
--		DEBUT DU SCRIPT
-------------------------------------------------------------------
BEGIN TRANSACTION
GO

-------------------------------------------------------------------
--		MODIFS STRUCTURE
-------------------------------------------------------------------

-- BanqueRemise => Type Remise.nBanque passé de Decimal en Numeric
ALTER TABLE Remise
ALTER COLUMN nBanque numeric(18,0)
GO

-- PrescripteurVFacture => VFacture.Prescripteur passé de précision 18 à 10
ALTER TABLE VFacture
ALTER COLUMN nPrescripteur decimal(10,0)
GO

-- PayeurVFacture => VFacture.Payeur passé de précision 18 à 10
ALTER TABLE VFacture
ALTER COLUMN nPayeur decimal(10,0)
GO

-- EntrepriseContact => Personne.nEntreprise passé de précision 18 à 10
ALTER TABLE Personne
ALTER COLUMN nEntreprise decimal(10,0)
GO

-- EntrepriseFiliale => Entreprise.nMaisonMere passé de précision 18 à 10
ALTER TABLE Entreprise
ALTER COLUMN nMaisonMere decimal(10,0)
GO

-- PersonneUtilisateur => Passage Utilisateur.nPersonne de Int en Decimal(10,0)
ALTER TABLE Utilisateurs
ALTER COLUMN nPersonne decimal(10,0)
GO

-- Ajout (Suite modif états FactureVenteHT et FactureVenteTTC)
alter table Entreprise
add NTVAIntraCom nvarchar (50);
GO

-- Ajouter les colonnes NCompte nVarchar(8) et NActivite nVarchar(4) dans les tables de détail
--VBonCommande_Detail
ALTER TABLE VBonCommande_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE VBonCommande_Detail SET NCompte=NCompteV,NActivite=NActiviteV
FROM Produit WHERE VBonCommande_Detail.CodeProduit=Produit.CodeProduit
GO
--VBonLivraison_Detail
ALTER TABLE VBonLivraison_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE VBonLivraison_Detail SET NCompte=NCompteV,NActivite=NActiviteV
FROM Produit WHERE VBonLivraison_Detail.CodeProduit=Produit.CodeProduit
GO
--VFacture_Detail
ALTER TABLE VFacture_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE VFacture_Detail SET NCompte=NCompteV,NActivite=NActiviteV
FROM Produit WHERE VFacture_Detail.CodeProduit=Produit.CodeProduit
GO
--VDevis_Detail
ALTER TABLE VDevis_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE VDevis_Detail SET NCompte=NCompteV,NActivite=NActiviteV
FROM Produit WHERE VDevis_Detail.CodeProduit=Produit.CodeProduit
GO
--ABonReception_Detail
ALTER TABLE ABonReception_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE ABonReception_Detail SET NCompte=NCompteA,NActivite=NActiviteA
FROM Produit WHERE ABonReception_Detail.CodeProduit=Produit.CodeProduit
GO
--AFacture_Detail
ALTER TABLE AFacture_Detail ADD NCompte nVarchar(8) NULL,NActivite nVarchar(4) NULL;
GO
UPDATE AFacture_Detail SET NCompte=NCompteA,NActivite=NActiviteA
FROM Produit WHERE AFacture_Detail.CodeProduit=Produit.CodeProduit
GO


-------------------------------------------------------------------
-- 		MODIFICATION DE LA PK SUR PRODUIT
-------------------------------------------------------------------

ALTER TABLE [dbo].[Produit] ADD 
	CONSTRAINT [IX_Produit] UNIQUE  NONCLUSTERED 
	(
		[CodeProduit]
	)  ON [PRIMARY] 
GO

-------------------------------------------------------------------
-- 		CREATION DES RELATIONS
-------------------------------------------------------------------

ALTER TABLE [dbo].[ABonReception] ADD 
	CONSTRAINT [FK_ABonReception_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[ABonReception_Detail] ADD 
	CONSTRAINT [FK_ABonReception_Detail_ABonReception] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[ABonReception] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[AFacture] ADD 
	CONSTRAINT [FK_AFacture_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[AFacture_Detail] ADD 
	CONSTRAINT [FK_AFacture_Detail_AFacture] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[AFacture] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[AReglement] ADD 
	CONSTRAINT [FK_AReglement_Banque] FOREIGN KEY 
	(
		[nBanque]
	) REFERENCES [dbo].[Banque] (
		[nBanque]
	),
	CONSTRAINT [FK_AReglement_Entreprise] FOREIGN KEY 
	(
		[nEntreprise]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[AReglement_Detail] ADD 
	CONSTRAINT [FK_AReglement_Detail_AFacture] FOREIGN KEY 
	(
		[nFacture]
	) REFERENCES [dbo].[AFacture] (
		[nDevis]
	),
	CONSTRAINT [FK_AReglement_Detail_AReglement] FOREIGN KEY 
	(
		[nReglement]
	) REFERENCES [dbo].[AReglement] (
		[nReglement]
	)
GO

ALTER TABLE [dbo].[CompositionProduit] ADD 
	CONSTRAINT [FK_CompositionProduit_Produit1] FOREIGN KEY 
	(
		[CodeProduit]
	) REFERENCES [dbo].[Produit] (
		[CodeProduit]
	) ON UPDATE CASCADE ,
	CONSTRAINT [FK_CompositionProduit_Produit2] FOREIGN KEY 
	(
		[CodeProduitComposition]
	) REFERENCES [dbo].[Produit] (
		[CodeProduit]
	)
GO

ALTER TABLE [dbo].[Entreprise] ADD 
	CONSTRAINT [FK_Entreprise_Entreprise] FOREIGN KEY 
	(
		[nMaisonMere]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[Evenement] ADD 
	CONSTRAINT [FK_Evenement_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	),
	CONSTRAINT [FK_Evenement_Personne] FOREIGN KEY 
	(
		[nPersonneAuteur]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	)
GO

ALTER TABLE [dbo].[EvenementPersonne] ADD 
	CONSTRAINT [FK_EvenementPersonne_Entreprise] FOREIGN KEY 
	(
		[nEntreprise]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	),
	CONSTRAINT [FK_EvenementPersonne_Evenement] FOREIGN KEY 
	(
		[nEvenement]
	) REFERENCES [dbo].[Evenement] (
		[nEvenement]
	),
	CONSTRAINT [FK_EvenementPersonne_Personne] FOREIGN KEY 
	(
		[nPersonne]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	)
GO

ALTER TABLE [dbo].[EvenementPiece] ADD 
	CONSTRAINT [FK_EvenementPiece_Evenement] FOREIGN KEY 
	(
		[nEvenement]
	) REFERENCES [dbo].[Evenement] (
		[nEvenement]
	)
GO

ALTER TABLE [dbo].[Fabrication_Detail] ADD 
	CONSTRAINT [FK_Fabrication_Detail_Fabrication] FOREIGN KEY 
	(
		[nFabrication]
	) REFERENCES [dbo].[Fabrication] (
		[nFabrication]
	)
GO

ALTER TABLE [dbo].[Mouvement_Detail] ADD 
	CONSTRAINT [FK_Mouvement_Detail_Mouvement] FOREIGN KEY 
	(
		[nMouvement]
	) REFERENCES [dbo].[Mouvement] (
		[nMouvement]
	)
GO

ALTER TABLE [dbo].[Niveau2] ADD 
	CONSTRAINT [FK_Niveau2_Niveau1] FOREIGN KEY 
	(
		[nNiveau1]
	) REFERENCES [dbo].[Niveau1] (
		[nNiveau]
	)
GO

ALTER TABLE [dbo].[Personne] ADD 
	CONSTRAINT [FK_Personne_Entreprise] FOREIGN KEY 
	(
		[nEntreprise]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[Produit] ADD 
	CONSTRAINT [FK_Produit_Famille] FOREIGN KEY 
	(
		[Famille1]
	) REFERENCES [dbo].[Famille] (
		[nFamille]
	)
GO

ALTER TABLE [dbo].[Reglement] ADD 
	CONSTRAINT [FK_Reglement_Banque] FOREIGN KEY 
	(
		[nBanque]
	) REFERENCES [dbo].[Banque] (
		[nBanque]
	),
	CONSTRAINT [FK_Reglement_Entreprise] FOREIGN KEY 
	(
		[nEntreprise]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[Reglement_Detail] ADD 
	CONSTRAINT [FK_Reglement_Detail_Reglement] FOREIGN KEY 
	(
		[nReglement]
	) REFERENCES [dbo].[Reglement] (
		[nReglement]
	),
	CONSTRAINT [FK_Reglement_Detail_VFacture] FOREIGN KEY 
	(
		[nFacture]
	) REFERENCES [dbo].[VFacture] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[Remise] ADD 
	CONSTRAINT [FK_Remise_Banque] FOREIGN KEY 
	(
		[nBanque]
	) REFERENCES [dbo].[Banque] (
		[nBanque]
	)
GO

ALTER TABLE [dbo].[Remise_Detail] ADD 
	CONSTRAINT [FK_Remise_Detail_Reglement] FOREIGN KEY 
	(
		[nReglement]
	) REFERENCES [dbo].[Reglement] (
		[nReglement]
	),
	CONSTRAINT [FK_Remise_Detail_Remise] FOREIGN KEY 
	(
		[nRemise]
	) REFERENCES [dbo].[Remise] (
		[nRemise]
	)
GO

ALTER TABLE [dbo].[Tarif_Detail] ADD 
	CONSTRAINT [FK_Tarif_Detail_Produit1] FOREIGN KEY 
	(
		[CodeProduit]
	) REFERENCES [dbo].[Produit] (
		[CodeProduit]
	) ON UPDATE CASCADE ,
	CONSTRAINT [FK_Tarif_Detail_Tarif] FOREIGN KEY 
	(
		[nTarif]
	) REFERENCES [dbo].[Tarif] (
		[nTarif]
	)
GO

ALTER TABLE [dbo].[Telephone] ADD 
	CONSTRAINT [FK_Telephone_Personne] FOREIGN KEY 
	(
		[nPersonne]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	)
GO

ALTER TABLE [dbo].[TelephoneEntreprise] ADD 
	CONSTRAINT [FK_TelephoneEntreprise_Entreprise] FOREIGN KEY 
	(
		[nEntreprise]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[Utilisateurs] ADD 
	CONSTRAINT [FK_Utilisateurs_Autorisations] FOREIGN KEY 
	(
		[nGroupe]
	) REFERENCES [dbo].[Autorisations] (
		[nGroupeAutorisation]
	),
	CONSTRAINT [FK_Utilisateurs_Personne] FOREIGN KEY 
	(
		[nPersonne]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	)
GO

ALTER TABLE [dbo].[VBonCommande] ADD 
	CONSTRAINT [FK_VBonCommande_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[VBonCommande_Detail] ADD 
	CONSTRAINT [FK_VBonCommande_Detail_VBonCommande] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[VBonCommande] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[VBonLivraison] ADD 
	CONSTRAINT [FK_VBonLivraison_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[VBonLivraison_Detail] ADD 
	CONSTRAINT [FK_VBonLivraison_Detail_VBonLivraison] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[VBonLivraison] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[VDevis] ADD 
	CONSTRAINT [FK_VDevis_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	)
GO

ALTER TABLE [dbo].[VDevis_Detail] ADD 
	CONSTRAINT [FK_VDevis_Detail_VDevis] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[VDevis] (
		[nDevis]
	)
GO

ALTER TABLE [dbo].[VFacture] ADD 
	CONSTRAINT [FK_VFacture_Entreprise] FOREIGN KEY 
	(
		[nClient]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	),
	CONSTRAINT [FK_VFacture_Entreprise1] FOREIGN KEY 
	(
		[nPayeur]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	),
	CONSTRAINT [FK_VFacture_Entreprise2] FOREIGN KEY 
	(
		[nPrescripteur]
	) REFERENCES [dbo].[Entreprise] (
		[nEntreprise]
	),
	CONSTRAINT [FK_VFacture_Personne] FOREIGN KEY 
	(
		[nContact]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	),
	CONSTRAINT [FK_VFacture_Personne1] FOREIGN KEY 
	(
		[nCommercial]
	) REFERENCES [dbo].[Personne] (
		[nPersonne]
	)
GO

ALTER TABLE [dbo].[VFacture_Detail] ADD 
	CONSTRAINT [FK_VFacture_Detail_VFacture] FOREIGN KEY 
	(
		[nDevis]
	) REFERENCES [dbo].[VFacture] (
		[nDevis]
	)
GO

-------------------------------------------------------------------
-- 		CREATION DE LA TABLE ParamApplication
-------------------------------------------------------------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParamApplication]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ParamApplication]
GO

CREATE TABLE [dbo].[ParamApplication] (
	[Cle] [varchar] (50) COLLATE French_CI_AS NOT NULL ,
	[Valeur] [varchar] (255) COLLATE French_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParamApplication] ADD 
	CONSTRAINT [PK_ParamApplication] PRIMARY KEY  CLUSTERED 
	(
		[Cle]
	)  ON [PRIMARY] 
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ParamApplication]  TO [Utilisateurs]
GO

INSERT INTO ParamApplication VALUES('VersionBase','0.0')
GO


-------------------------------------------------------------------
--	CREATION DES PROCEDURE STOCKEE POUR LA GESTION DES NFACTURE
-------------------------------------------------------------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE GetNextNFacture (
	@NomTable as Varchar(50),
	@ValeurDefaut as int, 
	@Simu as bit) AS
DECLARE @NFacture int;
BEGIN TRANSACTION

-- Trouver valeur courante
Select @NFacture=Max(NFacture) From NFacture Where TypePiece=@NomTable;

-- Calculer la nouvelle valeur et suivant le cas créer la ligne ou la mettre à jour
If @NFacture Is Null  begin
	Set @NFacture = @ValeurDefaut;
	Insert into NFacture Values (0,@NFacture,@NomTable)
end else begin
	Set @NFacture = @NFacture+1;
	Update NFacture Set NFacture=@NFacture Where TypePiece=@NomTable;
end

-- Retour de la valeur
Select @NFacture as "NextNFacture";

-- On n'enregistre que si on n'est pas en mode simulation
if @Simu=0 begin
	COMMIT TRANSACTION
end else begin
	ROLLBACK TRANSACTION
end
GO

CREATE PROCEDURE SetNextNFacture (
	@NomTable as Varchar(50),
	@ValeurDefaut as int) AS
DECLARE @Test int;
BEGIN TRANSACTION

-- Trouver valeur courante
Select @Test=Count(*) From NFacture Where TypePiece=@NomTable;

-- Calculer la nouvelle valeur et suivant le cas créer la ligne ou la mettre à jour
If @Test =0  begin
	Insert into NFacture Values (0,@ValeurDefaut-1,@NomTable)
end else begin
	Update NFacture Set NFacture=@ValeurDefaut-1 Where TypePiece=@NomTable;
end

COMMIT TRANSACTION
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[GetNextNFacture]  TO [Utilisateurs]
GO
GRANT  EXECUTE  ON [dbo].[SetNextNFacture]  TO [Utilisateurs]
GO


-------------------------------------------------------------------
--		ADAPTATION DE LA TABLE NFACTURE
-------------------------------------------------------------------

select Annee, max(NFacture) as NFacture, TypePiece
into #tmpNFacture 
from NFacture 
where Annee=year(getdate())
group by Annee,TypePiece;

delete from NFacture;

insert into NFacture select * from #tmpNFacture;

update NFacture set Annee =0;

drop table #tmpNFacture;

GO

-------------------------------------------------------------------
--		CORRECTION BUG EXPORT COMPTA
-------------------------------------------------------------------

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[FactureMontantExport]  TO [Utilisateurs]

GO

-------------------------------------------------------------------
--		FIN DU SCRIPT
-------------------------------------------------------------------

COMMIT TRANSACTION
GO
