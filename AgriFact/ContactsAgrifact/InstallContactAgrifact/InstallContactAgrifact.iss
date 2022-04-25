;DEFINITION DES CONSTANTES
;///////////////////////////////////////////////////////////////////////////////////////
#define Solution "Agrifact"
#define MyAppName "ContactsAgrifact"
#define MyProjName MyAppName
#define MyAppNameDisplay "Contacts Agrifact"
#define StandardVersion "True"
#define Configuration "Debug"
;///////////////////////////////////////////////////////////////////////////////////////

;SCRIPT DE DEPLOIEMENT
#include "C:\ACTIGRAM\InnoSetup\Deploy.iss"
;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet2_core.iss"
//;SCRIPT DE VERIFICATION DU PROGRAMME EN COURS D'UTILISATION
#include "C:\ACTIGRAM\InnoSetup\issproc.iss"

[Setup]
AppID={{9324E1FF-3C7E-4155-89D1-724F53B583B2}
DirExistsWarning=no
;DEFINIT LES PARAMETRES DE L'INSTALLEUR EN FONCTION DES CONSTANTES
#include "C:\ACTIGRAM\InnoSetup\common.iss"

[Tasks]
Name: Autorun; Description: Lancer à l'ouverture de la session. (recommandé)

;FICHIERS STANDARD DE L'APPLI (exe + dll du rep build)
#include "C:\ACTIGRAM\InnoSetup\applifiles.iss"
[Files]
Source: C:\ACTIGRAM\VBNET1.1\AgriFact2.0\DatabaseUpdate\bin\DatabaseUpdate.exe; DestDir: {app}; Flags: replacesameversion
Source: C:\ACTIGRAM\VBNET2.0\MDA\MdaDesktop\bin\Debug\MdaDesktop.exe; DestDir: {app}; Flags: replacesameversion

[Run]
Filename: {app}\{#MyAppName}.exe; WorkingDir: {app}; Flags: postinstall shellexec; Tasks: ; Languages: ; Description: Lancer {#MyAppNameDisplay}


[Code]
//Wizard Events
function InitializeSetup(): Boolean;
begin
  Result := prerequis_InitializeSetup;
end;

function NextButtonClick(CurPage: Integer): Boolean;
begin
	Result := prerequis_NextButtonClick(CurPage);
	if Result then begin
		Result := issproc_NextButtonClick(CurPage);
  end;
end;
//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss")
