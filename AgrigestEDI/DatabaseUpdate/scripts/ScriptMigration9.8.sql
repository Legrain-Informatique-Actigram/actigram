ALTER TABLE Mouvements ADD MIdANouveau INTEGER, MIdANouveauSuiv INTEGER
GO

ALTER TABLE Pieces ADD PPieceIssueDeCloture BIT DEFAULT 0
GO

ALTER TABLE Dossiers ADD DComptesReportsDetaillesCloture TEXT(255)
GO
