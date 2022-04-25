SELECT Sum(Mouvements.MMtDeb)-Sum(Mouvements.MMtCre) AS Solde, IIf(MCpt="48800000","Répartition",IIf(Left([MCpt],1)<"6","Bilan","Gestion")) AS TypeCompte
FROM Mouvements
WHERE (((Mouvements.MDossier)="S0200109"))
GROUP BY IIf(MCpt="48800000","Répartition",IIf(Left([MCpt],1)<"6","Bilan","Gestion"));

SELECT Mouvements.MPiece, Mouvements.MDate, Sum([MMtDeb])-Sum([MMtCre]) AS Solde
FROM Mouvements
WHERE (((Mouvements.MDossier)="S0200109") AND ((Mouvements.MCpt)="48800000"))
GROUP BY Mouvements.MPiece, Mouvements.MDate
HAVING (((Sum([MMtDeb])-Sum([MMtCre]))<>0));

