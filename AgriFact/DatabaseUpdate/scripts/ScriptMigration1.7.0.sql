BEGIN TRANSACTION
GO
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Appro_BCD_AFD]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) BEGIN

	CREATE TABLE dbo.Appro_BCD_AFD
		(
		BCD_nDevisDetail decimal(10, 0) NOT NULL,
		AFD_nDevisDetail decimal(10, 0) NOT NULL,
		BLD_nDevisDetail decimal(10, 0) NULL,
		BC_Unite1 decimal(10, 3) NULL,
		BC_Unite2 decimal(10, 3) NULL,
		AF_Unite1 decimal(10, 3) NULL,
		AF_Unite2 decimal(10, 3) NULL
		)  ON [PRIMARY]

	ALTER TABLE dbo.Appro_BCD_AFD ADD CONSTRAINT
		PK_Appro_BCD_AFD PRIMARY KEY CLUSTERED 
		(
		BCD_nDevisDetail,
		AFD_nDevisDetail
		) ON [PRIMARY]


	ALTER TABLE dbo.Appro_BCD_AFD ADD CONSTRAINT
		FK_Appro_BCD_AFD_AFacture_Detail FOREIGN KEY
		(
		AFD_nDevisDetail
		) REFERENCES dbo.AFacture_Detail
		(
		nDetailDevis
		) ON DELETE CASCADE

	ALTER TABLE dbo.Appro_BCD_AFD ADD CONSTRAINT
		FK_Appro_BCD_AFD_VBonCommande_Detail FOREIGN KEY
		(
		BCD_nDevisDetail
		) REFERENCES dbo.VBonCommande_Detail
		(
		nDetailDevis
		) ON DELETE CASCADE
	
	GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Appro_BCD_AFD]  TO [Utilisateurs]
END	
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Appro_ProdsEnCommande]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[Appro_ProdsEnCommande]
GO
SET QUOTED_IDENTIFIER ON 
SET ANSI_NULLS ON 
GO

create view Appro_ProdsEnCommande as 
select e.nom, bc.nfacture,bc.datefacture,bcd.nDetailDevis, bcd.codeproduit,p.libelle,
bcd.unite1-sum(case when app.bc_unite1 is null then 0 else app.bc_unite1 end) as unite1,bcd.libunite1,
bcd.unite2-sum(case when app.bc_unite2 is null then 0 else app.bc_unite2 end) as unite2,bcd.libunite2
from vboncommande_detail bcd
inner join vboncommande bc on bcd.ndevis=bc.ndevis
inner join entreprise e on bc.nclient=e.nentreprise
left join produit p on bcd.codeproduit=p.codeproduit
left join Appro_BCD_AFD app on app.BCD_nDevisDetail=bcd.nDetailDevis
where bc.paye=0 and bcd.codeproduit<>''
group by e.nom,bc.nfacture,bc.datefacture,bcd.nDetailDevis,bcd.codeproduit,p.libelle,bcd.libunite1,bcd.libunite2,bcd.unite1,bcd.unite2
having (bcd.unite1-sum(case when app.bc_unite1 is null then 0 else app.bc_unite1 end)<>0)

GO
SET QUOTED_IDENTIFIER OFF 
SET ANSI_NULLS ON 
GO
GRANT  SELECT  ON [dbo].[Appro_ProdsEnCommande]  TO [Utilisateurs]
GO

COMMIT TRANSACTION