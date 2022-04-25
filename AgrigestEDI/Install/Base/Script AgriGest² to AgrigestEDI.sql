ALTER TABLE Lignes DROP CONSTRAINT TVALignes;
ALTER TABLE TVA DROP CONSTRAINT TVARecapTVA;
DROP TABLE TVA;
DROP TABLE TVARecap;
DROP TABLE TVACO;
DROP TABLE Rica;
DROP TABLE RicaCO;
DROP TABLE PlanTypeCO;
DROP TABLE PlanTypeAgricole;
DROP TABLE PlanTypeGeneral;
ALTER TABLE Comptes ADD COLUMN CCptContre TEXT(8) NOT NULL;
ALTER TABLE Comptes ADD COLUMN C_DC TEXT(1) NOT NULL;
ALTER TABLE Comptes ALTER COLUMN CLib TEXT(30);
ALTER TABLE Pieces ADD COLUMN Exporte BIT NULL;
ALTER TABLE Pieces ADD COLUMN DateExport DATETIME NULL;
ALTER TABLE Pieces ADD COLUMN Libelle TEXT(50) NULL;
ALTER TABLE Pieces ADD COLUMN Journal TEXT(50) NULL;
ALTER TABLE Pieces ADD COLUMN PPieceImport TEXT(50) NULL;
ALTER TABLE Lignes ALTER COLUMN LLib TEXT(55);
ALTER TABLE Lignes ALTER COLUMN LMtTVA TEXT(5);
ALTER TABLE ModLignes ALTER COLUMN ModLLib TEXT(55);
ALTER TABLE PlanComptable ADD COLUMN PlLib TEXT(55) NOT NULL;
UPDATE Activites INNER JOIN (Comptes INNER JOIN PlanComptable ON (Comptes.CCpt = PlanComptable.PlCpt) AND (Comptes.CDossier = PlanComptable.PlDossier)) ON (Activites.AActi = PlanComptable.PlActi) AND (Activites.ADossier = PlanComptable.PlDossier) SET PlanComptable.PlLib = [Comptes].[CLib]+' - '+[Activites].[ALib];
UPDATE Pieces SET Pieces.Journal = '09';
UPDATE Pieces SET Pieces.Libelle = 'Piece ' + CSTR(Pieces.PPiece) + ' du ' +  CSTR(Pieces.PDate);
UPDATE Lignes SET LTva='A' Where LTva='01';
UPDATE Lignes SET LTva='T' Where LTva='02';
UPDATE Lignes SET LTva=Null Where LTva='03';