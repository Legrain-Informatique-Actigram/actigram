-- Création de la table DefinitionControle
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'DefinitionControle')
BEGIN
	CREATE TABLE [dbo].[DefinitionControle](
		[nControle] [int] IDENTITY(1,1) NOT NULL,
		[IdControle] [int] NOT NULL,
		[CodeProduit] [nvarchar](255) NOT NULL,
		[Ordre] [int] NOT NULL,
		[Groupe] [nvarchar](100) NULL,
		[Libelle] [nvarchar](255) NULL,
		[Type] [nvarchar](25) NULL,
		[ValeursPossibles] [nvarchar](255) NULL,
		[ValeursDefaut] [nvarchar](255) NULL,
	 CONSTRAINT [PK_DefinitionControle] PRIMARY KEY CLUSTERED 
	(
		[nControle] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[DefinitionControle] ADD  CONSTRAINT [DF_DefinitionControle_Ordre]  DEFAULT (0) FOR [Ordre]
END
GO

-- Création de la table ResultatControle
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ResultatControle')
BEGIN
	CREATE TABLE [dbo].[ResultatControle](
		[nResultatControle] [int] IDENTITY(1,1) NOT NULL,
		[nControle] [int] NOT NULL,
		[CodeProduit] [nvarchar](255) NOT NULL,
		[nLot] [nvarchar](255) NOT NULL,
		[TestEffectue] [bit] NOT NULL,
		[Resultat] [nvarchar](255) NULL,
		[ResultatConformite] [bit] NULL,
	 CONSTRAINT [PK_ResultatControle] PRIMARY KEY CLUSTERED 
	(
		[nResultatControle] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ResultatControle]  WITH NOCHECK ADD  CONSTRAINT [FK_ResultatControle_DefinitionControle] FOREIGN KEY([nControle])
	REFERENCES [dbo].[DefinitionControle] ([nControle])

	ALTER TABLE [dbo].[ResultatControle] CHECK CONSTRAINT [FK_ResultatControle_DefinitionControle]

	ALTER TABLE [dbo].[ResultatControle] ADD  CONSTRAINT [DF_ResultatControle_TestEffectue]  DEFAULT (0) FOR [TestEffectue]
END
GO

-- Création de la table Bareme
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'Bareme')
BEGIN
	CREATE TABLE [dbo].[Bareme](
		[nBareme] [int] IDENTITY(1,1) NOT NULL,
		[nControle] [int] NOT NULL,
		[Expression] [nvarchar](255) NULL,
		[ResultatConformite] [bit] NOT NULL,
		[CheminDoc] [nvarchar](255) NULL,
		[ActionCorrective] [ntext] NULL,
	 CONSTRAINT [PK_Bareme] PRIMARY KEY CLUSTERED 
	(
		[nBareme] ASC
	) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[Bareme]  WITH NOCHECK ADD  CONSTRAINT [FK_Bareme_DefinitionControle] FOREIGN KEY([nControle])
	REFERENCES [dbo].[DefinitionControle] ([nControle])
	ON UPDATE CASCADE
	ON DELETE CASCADE

	ALTER TABLE [dbo].[Bareme] CHECK CONSTRAINT [FK_Bareme_DefinitionControle]

	ALTER TABLE [dbo].[Bareme] ADD  CONSTRAINT [DF_Bareme_ResultatConformite]  DEFAULT (0) FOR [ResultatConformite]
END
GO

-- Création de la table ModeleDefinitionControle
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ModeleDefinitionControle')
BEGIN
	CREATE TABLE [dbo].[ModeleDefinitionControle](
		[nModeleControle] [int] IDENTITY(1,1) NOT NULL,
		[MatPrem] [bit] NOT NULL,
		[TypeCritere] [nvarchar](255) NOT NULL,
		[Critere] [nvarchar](255) NOT NULL,
		[IdControle] [int] NOT NULL,
		[Ordre] [int] NOT NULL,
		[Groupe] [nvarchar](100) NULL,
		[Libelle] [nvarchar](255) NULL,
		[Type] [nvarchar](25) NULL,
		[ValeursPossibles] [nvarchar](255) NULL,
		[ValeursDefaut] [nvarchar](255) NULL,
	 CONSTRAINT [PK_ModeleDefinitionControle] PRIMARY KEY CLUSTERED 
	(
		[nModeleControle] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ModeleDefinitionControle] ADD  CONSTRAINT [DF_ModeleDefinitionControle_MatPrem]  DEFAULT (0) FOR [MatPrem]

	ALTER TABLE [dbo].[ModeleDefinitionControle] ADD  CONSTRAINT [DF_ModeleDefinitionControle_Ordre]  DEFAULT (0) FOR [Ordre]
END
GO

-- Création de la table ModeleBareme
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ModeleBareme')
BEGIN
	CREATE TABLE [dbo].[ModeleBareme](
		[nModeleBareme] [int] IDENTITY(1,1) NOT NULL,
		[nModeleControle] [int] NOT NULL,
		[Expression] [nvarchar](255) NULL,
		[ResultatConformite] [bit] NOT NULL,
		[CheminDoc] [nvarchar](255) NULL,
		[ActionCorrective] [ntext] NULL,
	 CONSTRAINT [PK_ModeleBareme] PRIMARY KEY CLUSTERED 
	(
		[nModeleBareme] ASC
	) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[ModeleBareme]  WITH NOCHECK ADD  CONSTRAINT [FK_ModeleBareme_ModeleDefinitionControle] FOREIGN KEY([nModeleControle])
	REFERENCES [dbo].[ModeleDefinitionControle] ([nModeleControle])
	ON UPDATE CASCADE
	ON DELETE CASCADE

	ALTER TABLE [dbo].[ModeleBareme] CHECK CONSTRAINT [FK_ModeleBareme_ModeleDefinitionControle]

	ALTER TABLE [dbo].[ModeleBareme] ADD  CONSTRAINT [DF_ModeleBareme_ResultatConformite]  DEFAULT (0) FOR [ResultatConformite]
END
GO

-- Création de la table ResultatBareme
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ResultatBareme')
BEGIN
	CREATE TABLE [dbo].[ResultatBareme](
		[nResultatBareme] [int] IDENTITY(1,1) NOT NULL,
		[nResultatControle] [int] NOT NULL,
		[nBareme] [int] NOT NULL,
		[ResultatExpression] [bit] NOT NULL,
		[ResultatConformite] [bit] NOT NULL,
		[ActionCorrectiveEffectuee] [bit] NOT NULL,
		[Observations] [ntext] NULL,
	 CONSTRAINT [PK_ResultatBareme] PRIMARY KEY CLUSTERED 
	(
		[nResultatBareme] ASC
	) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[ResultatBareme]  WITH CHECK ADD  CONSTRAINT [FK_ResultatBareme_Bareme] FOREIGN KEY([nBareme])
	REFERENCES [dbo].[Bareme] ([nBareme])

	ALTER TABLE [dbo].[ResultatBareme] CHECK CONSTRAINT [FK_ResultatBareme_Bareme]

	ALTER TABLE [dbo].[ResultatBareme]  WITH CHECK ADD  CONSTRAINT [FK_ResultatBareme_ResultatControle] FOREIGN KEY([nResultatControle])
	REFERENCES [dbo].[ResultatControle] ([nResultatControle])
	ON UPDATE CASCADE
	ON DELETE CASCADE

	ALTER TABLE [dbo].[ResultatBareme] CHECK CONSTRAINT [FK_ResultatBareme_ResultatControle]

	ALTER TABLE [dbo].[ResultatBareme] ADD  CONSTRAINT [DF_ResultatBareme_ActionCorrectiveEffectuee]  DEFAULT (0) FOR [ActionCorrectiveEffectuee]
END
GO

-- Création de la table ResultatControle
IF NOT EXISTS(SELECT *
              FROM   INFORMATION_SCHEMA.tables 
              WHERE  TABLE_NAME = 'ResultatControle')
BEGIN
	CREATE TABLE [dbo].[ResultatControle](
		[nResultatControle] [int] IDENTITY(1,1) NOT NULL,
		[nControle] [int] NOT NULL,
		[CodeProduit] [nvarchar](255) NOT NULL,
		[nLot] [nvarchar](255) NOT NULL,
		[TestEffectue] [bit] NOT NULL,
		[Resultat] [nvarchar](255) NULL,
		[ResultatConformite] [bit] NULL,
	 CONSTRAINT [PK_ResultatControle] PRIMARY KEY CLUSTERED 
	(
		[nResultatControle] ASC
	) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ResultatControle]  WITH NOCHECK ADD  CONSTRAINT [FK_ResultatControle_DefinitionControle] FOREIGN KEY([nControle])
	REFERENCES [dbo].[DefinitionControle] ([nControle])

	ALTER TABLE [dbo].[ResultatControle] CHECK CONSTRAINT [FK_ResultatControle_DefinitionControle]

	ALTER TABLE [dbo].[ResultatControle] ADD  CONSTRAINT [DF_ResultatControle_TestEffectue]  DEFAULT (0) FOR [TestEffectue]
END
GO

--Procédure stockée CalculEtatStockSchema 
IF OBJECT_ID ( 'CalculEtatStockSchema', 'P' ) IS NOT NULL 
    DROP PROCEDURE CalculEtatStockSchema;
GO

CREATE PROC [dbo].[CalculEtatStockSchema]
	@dtDeb datetime, 
	@dtFin datetime,
	@depot nvarchar(50),
	@gestionLot bit=1
AS

	-- Aggrégation des résultats
	SELECT 
	SPACE(50) as Depot,
	SPACE(50) as nLot,
	f.Famille,
	SPACE(50) as CodeProduit,
	p.Libelle,
	SPACE(50) as LibUnite1,
	SPACE(50) as LibUnite2,
	0.001	as Depart,
	0.001	as Entrée,
	0.001	as Sortie,
	0.001	as EnCommande,
	0.001	as DepartU2,
	0.001	as EntréeU2,
	0.001	as SortieU2,
	0.001	as EnCommandeU2
	FROM Produit p LEFT JOIN Famille f ON f.nFamille=p.Famille1
GO

--Procédure stockée EtatNonConf 
IF OBJECT_ID ( 'EtatNonConf', 'P' ) IS NOT NULL 
    DROP PROCEDURE EtatNonConf;
GO
 
CREATE PROC [dbo].[EtatNonConf]
		@dtDeb datetime,
		@dtFin datetime
AS
	/*declare @dtDeb datetime,@dtFin datetime
	set @dtDeb= '01/04/2008'
	set @dtFin= '15/05/2008'*/
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

	--select * from #tmp order by dtlot,nlot,codeproduit

	select pr.dtLot,res.nLot, res.CodeProduit,
	def.groupe,def.libelle,
	res.Resultat,
	rb.nresultatbareme,b.actioncorrective,
	rb.ActionCorrectiveEffectuee--,rb.Observations
	from resultatcontrole res
	inner join definitioncontrole def on def.ncontrole=res.ncontrole
	inner join resultatbareme rb on res.nresultatcontrole=rb.nresultatcontrole
	inner join bareme b on rb.nbareme=b.nbareme
	inner join #tmp as pr on pr.CodeProduit=res.CodeProduit and pr.nLot = res.nLot
	where TestEffectue=1 AND res.ResultatConformite=0 AND rb.ResultatConformite=0
	order by pr.dtLot,res.nLot, res.CodeProduit

	drop table #tmp
GO

--Procédure stockée EtatNonConfSchema 
IF OBJECT_ID ( 'EtatNonConfSchema', 'P' ) IS NOT NULL 
    DROP PROCEDURE EtatNonConfSchema;
GO

CREATE PROC [dbo].[EtatNonConfSchema]
	@dtDeb datetime,
	@dtFin datetime
AS
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
GO

--Procédure stockée EtatTracaLot 
IF OBJECT_ID ( 'EtatTracaLot', 'P' ) IS NOT NULL 
    DROP PROCEDURE EtatTracaLot;
GO 

CREATE PROC [dbo].[EtatTracaLot]
	@nLot nvarchar(50)
AS
	/*declare @nLot nvarchar(50)
	set @nLot='LOT1'*/

	select e.nom,br.ndevis,br.nfacture,br.datefacture, md.nlot,md.codeproduit,md.libelle,
	abs(md.unite1) as unite1,md.libunite1,abs(md.unite2) as unite2,md.libunite2 
	from mouvement_detail md
	left join abonreception_detail brd on md.codeproduit=brd.codeproduit and md.nlot=brd.nlot
	left join abonreception br on brd.ndevis=br.ndevis
	left join entreprise e on e.nentreprise=br.nclient
	where nmouvement in (select nmouvement from mouvement_detail where nLot=@nLot) 
	and md.nLot<>@nLot
	and md.codeproduit<>''
GO

--Procédure stockée EtatTracaMP 
IF OBJECT_ID ( 'EtatTracaMP', 'P' ) IS NOT NULL 
    DROP PROCEDURE EtatTracaMP;
GO 

CREATE PROC [dbo].[EtatTracaMP]
	@codeProduit nvarchar(50)
AS
	--declare @codeProduit nvarchar(50)
	--set @codeProduit='MANC'

	select e.nentreprise,e.nom,br.ndevis,br.nfacture,br.datefacture, brd.nlot as nlotmp, mdpf.codeproduit, mdpf.libelle, mdpf.nlot,abs(md.unite1) as unite1,md.libunite1,abs(md.unite2) as unite2,md.libunite2 
	from mouvement_detail md
	left join mouvement_detail mdpf on md.nmouvement=mdpf.nmouvement and mdpf.unite1>0
	left join abonreception_detail brd on md.codeproduit=brd.codeproduit and md.nlot=brd.nlot
	left join abonreception br on brd.ndevis=br.ndevis
	left join entreprise e on e.nentreprise=br.nclient
	where md.codeproduit=@codeProduit
	and md.nlot <>''
	--and md.nLot<>@nLot
	--and md.codeproduit<>''
GO