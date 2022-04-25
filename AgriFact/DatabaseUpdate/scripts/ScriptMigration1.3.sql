BEGIN TRANSACTION
GO
-------------------------------------------------------------------
--		MODIFS OPTIONS DE CHAMPS
-------------------------------------------------------------------

update niveau2 set ListeChoix=null where [table]='Vfacture' and Champs='nClient'
GO
update niveau2 set StopSaisi=0 where [table]='Reglement' and Champs='nMode'
GO
UPDATE [Niveau2] SET [IsObligatoire]=0 WHERE [Table] = 'Banque' AND [Champs] = 'NCompte'
GO
UPDATE [Niveau2] SET [IsObligatoire]=0 WHERE [Table] = 'Banque' AND [Champs] = 'NActivite'
GO

-------------------------------------------------------------------
--		Modification du champ Banque de Réglement
-------------------------------------------------------------------

ALTER TABLE dbo.Reglement ADD BanqueClient nvarchar(255) NULL
GO
update Reglement set BanqueClient = B.Libelle from Banque B where Reglement.nBanque=B.nBanque
GO
alter table reglement drop constraint FK_Reglement_Banque
GO
alter table reglement drop column nBanque
GO
UPDATE niveau2
set Champs='BanqueClient',ListeChoix='ListeBanque',TableListeChoixType=NULL,TableListeChoix=NULL,TableListeChoixSelectChamps=NULL,TableListeChoixAfficheChamps=NULL,TableListeChoixTri=NULL,FiltrePlus=NULL
where [table]='Reglement' and Champs='nBanque'
GO

-------------------------------------------------------------------
--		Modification du champ Banque de AReglement
-------------------------------------------------------------------

ALTER TABLE dbo.AReglement ADD BanqueClient nvarchar(255) NULL
GO
update AReglement set BanqueClient = B.Libelle from Banque B where AReglement.nBanque=B.nBanque
GO
alter table AReglement drop constraint FK_AReglement_Banque
GO
alter table AReglement drop column nBanque
GO


-------------------------------------------------------------------
--		Modification du champ Banque de ENTREPRISE
-------------------------------------------------------------------

update Entreprise set Banque = B.Libelle from Banque B where Entreprise.Banque=B.nBanque
GO
update niveau2 
set ListeChoix='ListeBanque',TableListeChoixType=NULL,TableListeChoix=NULL,TableListeChoixSelectChamps=NULL,TableListeChoixAfficheChamps=NULL,TableListeChoixTri=NULL,FiltrePlus=NULL
where [table]='Entreprise' and Champs='Banque'
GO


COMMIT TRANSACTION
GO
