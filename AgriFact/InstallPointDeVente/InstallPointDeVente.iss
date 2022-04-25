;DEFINITION DES CONSTANTES
;///////////////////////////////////////////////////////////////////////////////////////
#define Solution "Agrifact"
#define MyAppName "PointDeVente"
#define MyProjName MyAppName
#define MyAppNameDisplay "Point De Vente Agrifact"
#define StandardVersion "True" ;"False"
#define Configuration "x86\Debug" ;"Release"
;///////////////////////////////////////////////////////////////////////////////////////

;SCRIPT DE DEPLOIEMENT
#include "C:\Dev\Actigram\InnoSetup\Deploy.iss"
;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
#include "C:\Dev\Actigram\InnoSetup\prerequis_Dotnet2_Crystal.iss"

[Setup]
AppID={{076CD9D5-8C1E-4BC3-B59E-F598ABE0BE36}
;DEFINIT LES PARAMETRES DE L'INSTALLEUR EN FONCTION DES CONSTANTES
#include "C:\Dev\Actigram\InnoSetup\common.iss"

[Tasks]
Name: APD; Description: Installer EPSON Advanced Printer Driver (recommandé)
[Run]
Filename: {src}\Support\Components\APD4Silent.exe; StatusMsg: Installation de EPSON Advanced Printer Driver; Tasks: APD

;FICHIERS STANDARD DE L'APPLI (exe + dll du rep build)
#include "C:\Dev\Actigram\InnoSetup\applifiles.iss"
[Files]
Source: {#RepBuild}\Etats\*.rpt; DestDir: {app}\Etats; Flags: ignoreversion overwritereadonly

;POUR PROPOSER L'INSTALL D'ULTRAVNC
#include "C:\Dev\Actigram\InnoSetup\ultravnc.iss"
;FONCTION DE CODE COMMUNES
#include "C:\Dev\Actigram\InnoSetup\utils.iss"


//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss"): 
