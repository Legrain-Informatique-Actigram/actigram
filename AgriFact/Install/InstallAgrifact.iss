;PENSER A DEFINIR LES REPERTOIRES A EMBARQUER !!
;"Bajon" "CooPorc" "Arnaud" "RestoBio" "CEFIGA" "Cassar" "Larroque"
;#define Client "LaPerriere"

;Indicateur de création du setup complet
#define InstallComplet "False"

#define MyAppName "Agrifact"
#define StandardVersion "False"
#define ver GetFileVersion("..\Agrifact\bin\Agrifact.exe")
#define MyAppVersion Copy(ver,1,3)
#define MyAppRevision Copy(ver,5)
#undef ver
#define MyAppPublisher "Actigram"
#define MyAppURL "http://www.actigram.com"
#define OutputDir "Pack"
#if InstallComplet=="True"
#define OutputFile "setup" + MyAppName + "." + MyAppVersion + "_Complet"
#else
#define OutputFile "setup" + MyAppName + "." + MyAppVersion
#endif
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
#define MyAppId "{3DDB8A31-D49A-4CE5-8C7B-53D22C42C473}"
;#define MyAppId "{F4235D54-8C7B-4C67-A47B-2D061F9B44DE}"

;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
;#include "prerequis.iss"

[Setup]
AppName={#MyAppName}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir={#OutputDir}
OutputBaseFilename={#OutputFile}
SetupIconFile=Pack\Setup.ico
Compression=lzma/Max
SolidCompression=true
VersionInfoVersion={#MyAppVersion}.{#MyAppRevision}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=Programme d'installation d'{#MyAppName} {#ifdef Client}+ les états {#Client}{#endif}
VersionInfoCopyright={#MyAppPublisher} 2008
MinVersion=0,5.0.2195
PrivilegesRequired=admin
ShowLanguageDialog=no
Uninstallable=false
AlwaysShowComponentsList=false
ShowComponentSizes=false
FlatComponentsList=false
ShowTasksTreeLines=true
ExtraDiskSpaceRequired=367001600
AppID={{3DDB8A31-D49A-4CE5-8C7B-53D22C42C473}
WizardImageBackColor=clWhite
WizardSmallImageFile=img\image_install_petit.bmp
WizardImageFile=img\image_install_grand.bmp

[Languages]
Name: french; MessagesFile: compiler:Languages\French.isl
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[Tasks]
Name: UltraVNC; Description: Installer l'utilitaire de téléintervention UltraVNC; Flags: unchecked; Languages: 
Name: FixAgrifact; Description: Réparer l'installation d'Agrifact; Flags: unchecked; Languages: 

[Files]
Source: ..\SetupAgrifact\bin\Setup.msi; DestDir: {app}; Flags: ignoreversion deleteafterinstall; Check: VerifPrerequis
#ifdef Client
Source: ParamTiers\Parametres{#Client}.xml; DestDir: {app}; DestName: Parametres.xml; Flags: uninsneveruninstall onlyifdoesntexist ignoreversion; Tasks: ; Languages: 
Source: ..\Agrifact\bin\EtatsTiers\{#Client}\*; DestDir: {app}\EtatsTiers\{#Client}; Flags: ignoreversion recursesubdirs createallsubdirs; Tasks: ; Languages: 
#else
Source: ParametresStandard.xml; DestDir: {app}; DestName: Parametres.xml; Flags: uninsneveruninstall onlyifdoesntexist ignoreversion; Tasks: ; Languages: 
#endif
Source: ..\DatabaseUpdate\bin\DatabaseUpdate.exe; DestDir: {app}; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\Utilitaire\bin\Utilitaire.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\AgrifactAdmin\bin\x86\Debug\AgrifactAdmin.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\InstallAuto\bin\InstallAuto.exe; DestDir: {app}\isTmp; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Cubenet\sg_cubenet.msi; DestDir: {app}; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\BaseDepart\ParametresInstallation.xml; DestDir: {app}\BaseDepart; Flags: ignoreversion; Tasks: ; Languages:
#if InstallComplet=="True"
Source: ..\Install\Pack\BaseDepart\ParametresInstallation.xml; DestDir: {src}\BaseDepart; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\BaseDepart\AGRIFACTVide.*; DestDir: {src}\BaseDepart; Flags: ignoreversion; Tasks: ; Languages: 
Source: ..\Install\Pack\Support\Components\SQLEXPR_FRA.EXE; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86.msi; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86_fr.msi; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\UltraVNC\UltraVNC-102-Setup-Fr.exe; DestDir: {src}\UltraVNC; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\UltraVNC\InstallLudo; DestDir: {src}\UltraVNC; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\X64\NetFx64.exe; DestDir: {src}\Support\System\X64; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\X64\langpack.exe; DestDir: {src}\Support\System\X64; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\x86\dotnetfx.exe; DestDir: {src}\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\x86\langpack.exe; DestDir: {src}\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:
#endif

[Dirs]
Name: "{app}\Etats\EtatsTiers"; Flags: uninsneveruninstall

[Run]
;Ce serait bien d'avoir un fallback qui fait un repair /fa si /i ne fait rien
Filename: msiexec.exe; Parameters: "/i ""{app}\Setup.msi"" TARGETDIR=""{app}"" /qb-!"; StatusMsg: Installation du logiciel {#MyAppName}; AfterInstall: AfterInstallAppli
Filename: msiexec.exe; Parameters: "/fa ""{app}\Setup.msi"" TARGETDIR=""{app}"" /qb-!"; StatusMsg: Réparation du logiciel {#MyAppName}; Tasks: FixAgrifact; AfterInstall: AfterInstallAppli
Filename: {app}\InstallAuto.exe; Parameters: -auto {code:GetInstallAutoParm}; WorkingDir: {src}; StatusMsg: Initialisation des données {#MyAppName}; Flags: runhidden; BeforeInstall: CopyDatabaseFiles; Check: AppliInstallee
Filename: {app}\DatabaseUpdate.exe; Parameters: -dossier=tous -auto; StatusMsg: Mise à jour des données {#MyAppName}; Flags: runhidden; Check: AppliInstallee
Filename: {src}\UltraVNC\UltraVNC-102-Setup-Fr.exe; Parameters: "/norestart /verysilent /loadinf=""{src}\UltraVNC\InstallLudo"""; StatusMsg: Installation d'UltraVNC; Flags: runhidden skipifdoesntexist; Tasks: UltraVNC; Check: AppliInstallee
Filename: msiexec.exe; Parameters: "/i ""{app}\sg_cubenet.msi"" TARGETDIR=""{app}"" /qb-!"; StatusMsg: Installation de cubenet

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
		PrerequisCheckResult:=True;
		PrerequisChecked:=true;
	end;
	Result:=PrerequisCheckResult;
end;

// Copier les fichiers de base de données de {src} dans {app}
procedure CopyDatabaseFiles();
begin
	if CopyFolder(ExpandConstant('{src}\BaseDepart'), ExpandConstant('{app}\BaseDepart'))  then
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
	if FileExists(ExpandConstant('{app}\BaseDepart\ParametresInstallation.xml')) then begin
		Result := ExpandConstant(' -parm="{app}\BaseDepart\ParametresInstallation.xml"');
	end else begin
		Result := '';
	end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  Registre: String;
  FichierUninstall: String;
  ErrorCode : Integer;
  MessageErreur: String;
  NomApplication: String;
  SoftwareVersion: string;
  NetFrameWorkInstalled : Boolean;
begin
  if CurStep = ssInstall then begin
    // Clé Id de registre
    Registre := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppId}';
    if RegQueryStringValue( HKLM, Registre, 'UninstallString', FichierUninstall) then begin
      // Récupération du nom de l'application installée
      RegQueryStringValue( HKLM, Registre, 'DisplayName', NomApplication);
      MessageErreur := 'Une version de l''application ' + NomApplication + ' est déjà présente sur ce poste. ' 
      + 'Pour continuer l''installation, vous devez la désinstaller.' + #13#10 
      + 'Souhaitez vous lancer la désinstallation maintenant ? ';
      // Confirmation de la désinstallation
      if (Msgbox(MessageErreur, mbConfirmation, MB_YESNO) = IDYES) then begin
        if Exec('cmd', '/c ' + 'MsiExec.exe /X{#MyAppId} /PASSIVE', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur lors de la désinstallation de l''application : ' + SysErrorMessage(ErrorCode), mbError, MB_OK);
            Abort;
        end;
      end else begin
        Msgbox('Installation annulée.', mbConfirmation, MB_Ok);
        Abort;
      end;
    end;
  //end;
  
  //if CurStep = ssPostInstall then begin
  	//Détection et installation de .NETFramework 2.0
  	if IsWin64 then
  	begin
  		NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0');
      if not NetFrameWorkInstalled then begin
        // Si le pack d'install du framework n'est pas présent dans {src}
        if (FileExists(ExpandConstant('{src}\Support\System\X64\NetFx64.exe')) = false)
  		    or (FileExists(ExpandConstant('{src}\Support\System\X64\langpack.exe')) = false) then begin
          MsgBox('Impossible d''installer .NETFramework 2.0 : fichier d''installation manquant.', mbError, MB_OK);
        end else begin
          // Lancement de l'installation du framework, suivi du language pack
          if Exec(ExpandConstant('{src}\Support\System\X64\NetFx64.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur dans l''installation de .NETFramework 2.0 : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
          end else begin
            if Exec(ExpandConstant('{src}\Support\System\X64\langpack.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
              MsgBox('Erreur dans l''installation de .NETFramework 2.0 language pack : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
            end;
          end;
        end;
      end;
  	end
  	else
  	begin
  		NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0');
      if not NetFrameWorkInstalled then begin
        // Si le pack d'install du framework n'est pas présent dans {src}
        if (FileExists(ExpandConstant('{src}\Support\System\x86\dotnetfx.exe')) = false)
  		    or (FileExists(ExpandConstant('{src}\Support\System\x86\langpack.exe')) = false) then begin
          MsgBox('Impossible d''installer .NETFramework 2.0 : fichier d''installation manquant.', mbError, MB_OK);
        end else begin
          // Lancement de l'installation du framework, suivi du language pack
          if Exec(ExpandConstant('{src}\Support\System\x86\dotnetfx.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur dans l''installation de .NETFramework 2.0 : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
          end else begin
            if Exec(ExpandConstant('{src}\Support\System\x86\langpack.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
              MsgBox('Erreur dans l''installation de .NETFramework 2.0 language pack : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
            end;
          end;
        end;
      end;
  	end;
  	
  	//Détection et installation de Crystal Report
		SoftwareVersion := '';
    RegQueryStringValue(HKLM, 'SOFTWARE\Crystal Decisions\10.2\Crystal Reports', 'BuildNum', SoftwareVersion);
    if (SoftwareVersion < '570') then begin
      if not FileExists(ExpandConstant('{src}\Support\Components\CRRedist2005_x86.msi')) then begin
			 MsgBox('Impossible d''installer Crystal Report : fichier d''installation manquant.', mbError, MB_OK);
		  end else begin
			 // Lancement de l'installation de Crystal Report
			 if Exec('cmd', '/c ' + 'MsiExec.exe /i "' + ExpandConstant('{src}\Support\Components\CRRedist2005_x86.msi') + '" /PASSIVE', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then
			 begin
				  MsgBox('Erreur dans l''installation de Crystal Report : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
			 end else begin	
			 	if not FileExists(ExpandConstant('{src}\Support\Components\CRRedist2005_x86_fr.msi')) then begin
          MsgBox('Impossible d''installer Crystal Report Fr : fichier d''installation manquant.', mbError, MB_OK);
		    end else begin	 
          if Exec('cmd', '/c ' + 'MsiExec.exe /i "' + ExpandConstant('{src}\Support\Components\CRRedist2005_x86_fr.msi') + '" /PASSIVE', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then
			 	   MsgBox('Erreur dans l''installation de Crystal Report Fr : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
          end;
        end;
		  end;
    end;
  end;
end;

//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss")

