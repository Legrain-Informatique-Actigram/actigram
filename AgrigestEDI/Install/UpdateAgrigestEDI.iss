;DEFINITION DES CONSTANTES
;///////////////////////////////////////////////////////////////////////////////////////
#define StandardVersion "False"; "True"
#define Client "CO"
#define Configuration "Debug" ;"Release"
#define MyAppName "AgrigestEDI"
#define MyProjName MyAppName
#define MyAppNameDisplay "Agrigest EDI"
#define UpdatePackage "True"
;///////////////////////////////////////////////////////////////////////////////////////

#define MyInfoOrg "EIP"
#ifdef Client
	#define MyInfoOrg Client
#endif

;SCRIPT DE DEPLOIEMENT
#include "C:\ACTIGRAM\InnoSetup\Deploy.iss"
;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet2_Crystal.iss"

[Setup]
;ATTENTION, SI ON CHANGE CET AppID, ON CASSE LE MODE DE DETECTION D'AGRIFACT
AppID={{F9C90EB2-DF53-4257-A396-A03FC0719991}
;DEFINIT LES PARAMETRES DE L'INSTALLEUR EN FONCTION DES CONSTANTES
#include "C:\ACTIGRAM\InnoSetup\commonUpdate.iss"

;FICHIERS STANDARD DE L'APPLI (exe + dll du rep build)
#include "C:\ACTIGRAM\InnoSetup\applifiles.iss"
[Files]
;Fichiers content
Source: {#RepBuild}\*.pdf; DestDir: {app}; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\Etats\*.rpt; DestDir: {app}\Etats; Flags: ignoreversion overwritereadonly
;Bases de données
Source: Base\*.xml; DestDir: {app}\Data; Flags: overwritereadonly ignoreversion
Source: Base\*.mdb; DestDir: {app}\Data; Flags: ignoreversion overwritereadonly
;Paramétrage FTP pour récupération EDI Cogédis
#ifdef Client
	#if Client="CO"
		; Source: Base\ParamEdi{#Client}.dat; DestDir: {app}\Data\ParamEdi.dat; Flags: ignoreversion overwritereadonly
	#endif
#endif


;MigrationBase
Source: ..\DatabaseUpdate\bin\MigrationBase.exe; DestDir: {app}; Flags: overwritereadonly ignoreversion
;UtilitaireAccess
#define UtilAccess "..\..\..\VBNET2.0\UtilitaireAccess\UtilitaireAccess\bin\Debug\UtilitaireAccess"
Source: {#UtilAccess}.exe; DestDir: {app}; Flags: ignoreversion
Source: {#UtilAccess}.pdb; DestDir: {app}; Flags: ignoreversion
Source: {#UtilAccess}.exe.config; DestDir: {app}; Flags: ignoreversion

[Run]
Filename: {app}\MigrationBase.exe; Parameters: -base=auto -auto; StatusMsg: Mise à jour des données; Check: AppliInstallee
;FONCTION DE CODE COMMUNES
#include "C:\ACTIGRAM\InnoSetup\utils.iss"

//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss"): 
