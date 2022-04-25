;PENSER A DEFINIR LES REPERTOIRES A EMBARQUER !!
;"Bajon" "CooPorc" "Arnaud" "RestoBio" "CEFIGA" "Cassar" "Larroque"
;#define Client "LaPerriere"

#define MyAppName "Agrifact"
#define StandardVersion "False"
#define ver GetFileVersion("..\Agrifact\bin\Agrifact.exe")
#define MyAppVersion Copy(ver,1,3)
#define MyAppRevision Copy(ver,5)
#undef ver
#define MyAppPublisher "Actigram"
#define MyAppURL "http://www.actigram.com"
#define OutputDir "Pack"
#define OutputFile "setup"
#define RepDeploy "\\serveur\ProduitsActigram\installs\"+ MyAppName +"\"
#ifdef Client
	#define OutputFile OutputFile + "_" + Client
	#define RepDeploy RepDeploy + "Install_Agrifact_" + Client + "\"
#else
	#if StandardVersion == "True"
		#define RepDeploy RepDeploy + "Install_Agrifact_Standard\"
	#else
		#define RepDeploy RepDeploy + "Install_Agrifact_" + MyAppVersion + "\"
	#endif
#endif

;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
#include "prerequis.iss"

[Setup]
AppName={#MyAppName}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=true
OutputDir={#OutputDir}
OutputBaseFilename={#OutputFile}
SetupIconFile=Pack\Setup.ico
Compression=lzma
SolidCompression=true
VersionInfoVersion={#MyAppVersion}.{#MyAppRevision}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=Programme d'installation d'{#MyAppName} {#ifdef Client}+ les états {#Client}{#endif}
VersionInfoCopyright={#MyAppPublisher} 2008
MinVersion=0,5.0.2195
PrivilegesRequired=poweruser
ShowLanguageDialog=no
Uninstallable=false
AlwaysShowComponentsList=false
ShowComponentSizes=false
FlatComponentsList=false
ShowTasksTreeLines=true
ExtraDiskSpaceRequired=367001600
AppID={{F4235D54-8C7B-4C67-A47B-2D061F9B44DE}
WizardImageBackColor=clWhite
WizardSmallImageFile=img\image_install_petit.bmp
WizardImageFile=img\image_install_grand.bmp

[Languages]
Name: french; MessagesFile: compiler:Languages\French.isl
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[Tasks]
Name: UltraVNC; Description: Installer l'utilitaire de téléintervention UltraVNC
Name: FixAgrifact; Description: Réparer l'installation d'Agrifact; Flags: unchecked; Languages: 

[Files]
Source: ..\SetupAgrifact\bin\SetupAgrifact.msi; DestDir: {app}; Flags: ignoreversion deleteafterinstall; Check: VerifPrerequis
#ifdef Client
Source: ParamTiers\Parametres{#Client}.xml; DestDir: {app}; DestName: Parametres.xml; Flags: uninsneveruninstall onlyifdoesntexist ignoreversion; Tasks: ; Languages: 
Source: ..\Agrifact\bin\EtatsTiers\{#Client}\*; DestDir: {app}\EtatsTiers\{#Client}; Flags: ignoreversion recursesubdirs createallsubdirs; Tasks: ; Languages: 
#else
Source: ParametresStandard.xml; DestDir: {app}; DestName: Parametres.xml; Flags: uninsneveruninstall onlyifdoesntexist ignoreversion; Tasks: ; Languages: 
#endif
Source: ..\DatabaseUpdate\bin\DatabaseUpdate.exe; DestDir: {app}; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\Utilitaire\bin\Utilitaire.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\AgrifactAdmin\bin\AgrifactAdmin.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\InstallAuto\bin\InstallAuto.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages: 

[Run]
;Ce serait bien d'avoir un fallback qui fait un repair /fa si /i ne fait rien
Filename: msiexec.exe; Parameters: "/i ""{app}\Setup.msi"" TARGETDIR=""{app}"" /qb-!"; StatusMsg: Installation du logiciel {#MyAppName}; AfterInstall: AfterInstallAppli
Filename: msiexec.exe; Parameters: "/fa ""{app}\Setup.msi"" TARGETDIR=""{app}"" /qb-!"; StatusMsg: Réparation du logiciel {#MyAppName}; Tasks: FixAgrifact; AfterInstall: AfterInstallAppli

Filename: {app}\InstallAuto.exe; Parameters: -auto {code:GetInstallAutoParm}; StatusMsg: Initialisation des données {#MyAppName}; Flags: runhidden; BeforeInstall: CopyDatabaseFiles; Check: AppliInstallee
Filename: {app}\DatabaseUpdate.exe; Parameters: -dossier=tous -auto; StatusMsg: Mise à jour des données {#MyAppName}; Flags: runhidden; Check: AppliInstallee
Filename: {src}\UltraVNC\UltraVNC-102-Setup-Fr.exe; Parameters: "/norestart /verysilent /loadinf=""{src}\UltraVNC\InstallLudo"""; StatusMsg: Installation d'UltraVNC; Flags: runhidden skipifdoesntexist; Tasks: UltraVNC; Check: AppliInstallee

[_ISToolPostCompile]
Name: Wscript; Parameters: """.\deploy.vbs"" ""{#OutputDir}\{#OutputFile}.exe"" ""{#RepDeploy}"""

[Code]
var
  PrerequisChecked: Boolean;
  PrerequisCheckResult: Boolean;

function CopyFolder(const SourceFolderPath: String; DestinyFolderPath: String): Boolean;
var
  ResultCode: Integer;
begin
	if Exec('cmd', '/c xcopy "'+ SourceFolderPath + '\*" "' + DestinyFolderPath +'\" /y', '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then begin
		Result := true;
	end else begin
		Result := false;
	end;
end;

procedure BackupParametres();
begin
	//Fait un backup du Parametres.xml, au cas ou
	if FileExists(ExpandConstant('{app}\Parametres.xml')) then begin
		FileCopy(ExpandConstant('{app}\Parametres.xml'), ExpandConstant('{app}\Parametres.xml.bak'), false);
	end;
end;

function VerifMSDE(instanceName, saPwd : String): Boolean;
var
	ResultCode : Integer;
begin
	// Detecter si l'instance Agrifact de MSDE est installée
	if not RegKeyExists( HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server\' + instanceName + '\MSSQLServer') then
	begin
		// Si le pack d'install de MSDE n'est pas présent dans {src}
		if not FileExists(ExpandConstant('{src}\Support\MSDE\setup.exe')) then
		begin
			// Message d'erreur et annulation de l'installation
			MsgBox('Impossible d''installer MSDE : fichier d''installation manquant.', mbError, MB_OK);
			Result:=false;
		end else begin
			// Lancement de l'installation de MSDE
			if Exec(ExpandConstant('{src}\Support\MSDE\setup.exe'), 'SAPWD="'+ saPwd +'" SECURITYMODE=SQL INSTANCENAME="'+ instanceName +'" DISABLENETWORKPROTOCOLS=0', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) = False then
			begin
				MsgBox('Erreur dans l''installation de MSDE : ' + SysErrorMessage(ResultCode) , mbError, MB_OK);
				Result:=false;
			end else begin
				Result:=true;
			end;
		end;
	end else begin
		Result:=true;
	end;
end;

function VerifPrerequis() : Boolean;
begin
	if not PrerequisChecked then begin
		BackupParametres();
		PrerequisCheckResult:=VerifMSDE('AGRIFACT','ludo');
		PrerequisChecked:=true;
	end;
	Result:=PrerequisCheckResult;
end;

// Copier les fichiers de base de données de {src} dans {app}
procedure CopyDatabaseFiles();
begin
	if CopyFolder(ExpandConstant('{src}\BaseDepart'), ExpandConstant('{app}\MSDE\BaseDepart'))  then
	begin
	//	Result:=true;
	end else begin
		MsgBox('Echec d''installation des fichiers de base de données.' , mbError, MB_OK);
	//	Result:=False;
	end;
end;

function AppliInstallee() : Boolean;
begin
	if FileExists(ExpandConstant('{app}\AgriFact.exe')) then begin
		Result:=true;
	end else begin
		Result:=False;
	end;
end;

procedure AfterInstallAppli();
begin
	if DirExists(ExpandConstant('{app}\isTmp')) then begin
		CopyFolder(ExpandConstant('{app}\isTmp'), ExpandConstant('{app}'));
		DelTree(ExpandConstant('{app}\isTmp'), True, True, True);
	end;
	if not AppliInstallee() then begin
		MsgBox('L''application n''a pas été installée.', mbError, MB_OK);
	end;
	if not FileExists(ExpandConstant('{app}\Parametres.xml')) and FileExists(ExpandConstant('{app}\Parametres.xml.bak')) then begin
		RenameFile(ExpandConstant('{app}\Parametres.xml.bak'), ExpandConstant('{app}\Parametres.xml'));
	end;
end;

function GetInstallAutoParm(Param: String) : String;
begin
	if FileExists(ExpandConstant('{app}\MSDE\BaseDepart\ParametresInstallation.xml')) then begin
		Result := ExpandConstant(' -parm="{app}\MSDE\BaseDepart\ParametresInstallation.xml"');
	end else begin
		Result := '';
	end;
end;

//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss")
