#define InstallComplet "False"

;DEFINITION DES CONSTANTES
;///////////////////////////////////////////////////////////////////////////////////////
#define StandardVersion "False" ;"True"
#define Configuration "Debug"
;#define Configuration "Release"
#define MyProjName "ControleTracabilite"
#define MyAppName "Solstyce"
#define MyAppNameDisplay "Solstyce Tracabilit�"
#define MyAppId "{CF470447-5657-4581-8296-483402728A15}"
;Id d�fini dans projet Visual Studio SetupControleTraca
#define MyAppId2 "{D6312693-1BD9-4CA9-86D4-53D7E01832F5}"
;///////////////////////////////////////////////////////////////////////////////////////

;SCRIPT DE DEPLOIEMENT
#include "C:\Dev\Actigram\InnoSetup\Deploy.iss"

#define RepAppBuild "..\" + MyProjName + "\bin\x86\" + Configuration
#define vers GetFileVersion(RepAppBuild +"\" + MyAppName + ".exe")
#define MyCurrentAppVersion Copy(vers,1,3)

#if InstallComplet=="True"
#define OutputFile "setup" + MyAppName + "." + MyCurrentAppVersion + "_Complet"
#else
#define OutputFile "setup" + MyAppName + "." + MyCurrentAppVersion
#endif

;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
;#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet2_Crystal.iss"

[Setup]
AppID={{CF470447-5657-4581-8296-483402728A15}
;DEFINIT LES PARAMETRES DE L'INSTALLEUR EN FONCTION DES CONSTANTES
#include "C:\Dev\Actigram\InnoSetup\common.iss"
;Embarque et installe le MSI
#include "C:\Dev\Actigram\InnoSetup\installMSI.iss"
;POUR PROPOSER L'INSTALL D'ULTRAVNC
;#include "C:\ACTIGRAM\InnoSetup\ultravnc.iss"
;Utilitaires SQL Server
#include "C:\Dev\Actigram\InnoSetup\utilsSQL.iss"
//FONCTION DE CODE COMMUNES=
#include "C:\Dev\Actigram\InnoSetup\utils.iss"

[Files] 
#if InstallComplet=="True"
Source: ..\Install\Pack\BaseDepart\ParametresInstallation.xml; DestDir: {src}\BaseDepart; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\BaseDepart\SolstyceVide.*; DestDir: {src}\BaseDepart; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\SQLEXPR_FRA.EXE; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86.msi; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86_fr.msi; DestDir: {src}\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\UltraVNC\UltraVNC-102-Setup-Fr.exe; DestDir: {src}\UltraVNC; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\UltraVNC\InstallVNC; DestDir: {src}\UltraVNC; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\X64\NetFx64.exe; DestDir: {src}\Support\System\X64; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\X64\langpack.exe; DestDir: {src}\Support\System\X64; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\x86\dotnetfx.exe; DestDir: {src}\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\Framework\x86\langpack.exe; DestDir: {src}\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:
#endif
;Fichier de transformation
Source: ..\ControleTracabilite\bin\x86\Debug\Etats\impressionControles.xsl; DestDir: {app}\Etats; Flags: ignoreversion; Tasks: ; Languages:

[Code]
procedure CurStepChanged(CurStep: TSetupStep);
var
  Registre: String;
  FichierUninstall: String;
  ErrorCode : Integer;
  MessageErreur: String;
  NomApplication: String;
  NumVersionApplication: String;
  SoftwareVersion: string;
  NetFrameWorkInstalled : Boolean;
begin
  if CurStep = ssInstall then begin
    // Cl� Id de registre
    Registre := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1';
    if RegQueryStringValue( HKLM, Registre, 'QuietUninstallString', FichierUninstall) then begin
      // R�cup�ration du nom de l'application install�e
      RegQueryStringValue( HKLM, Registre, 'DisplayName', NomApplication);
      MessageErreur := 'Une version de l''application Solstyce est d�j� pr�sente sur ce poste. ' 
      + 'Pour continuer l''installation, vous devez la d�sinstaller.' + #13#10 
      + 'Souhaitez vous lancer la d�sinstallation maintenant ? ';
      // Confirmation de la d�sinstallation
      if (Msgbox(MessageErreur, mbConfirmation, MB_YESNO) = IDYES) then begin
        if Exec('cmd', '/c ' + FichierUninstall, '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur lors de la d�sinstallation de l''application : ' + SysErrorMessage(ErrorCode), mbError, MB_OK);
            Abort;
        end;
        //D�sinstallation issue du projet Visual Studio SetupControleTraca
        Registre := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID2}';
        if RegQueryStringValue( HKLM, Registre, 'UninstallString', FichierUninstall) then begin
        	if Exec('cmd', '/c ' + 'MsiExec.exe /X{#MyAppID2} /PASSIVE', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur lors de la d�sinstallation de l''application : ' + SysErrorMessage(ErrorCode), mbError, MB_OK);
            Abort;
        end;
        end;
      end else begin
        Msgbox('Installation annul�e.', mbConfirmation, MB_Ok);
        Abort;
      end;
    end;
  end;
  if CurStep = ssPostInstall then begin
  	//D�tection et installation de .NETFramework 2.0
  	if IsWin64 then
  	begin
  		NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0');
      if not NetFrameWorkInstalled then begin
        // Si le pack d'install du framework n'est pas pr�sent dans {src}
        if (FileExists(ExpandConstant('{src}\Support\System\X64\NetFx64.exe')) = false)
  		    or (FileExists(ExpandConstant('{src}Support\System\X64\langpack.exe')) = false) then begin
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
        // Si le pack d'install du framework n'est pas pr�sent dans {src}
        if (FileExists(ExpandConstant('{src}\Support\System\x86\dotnetfx.exe')) = false)
  		    or (FileExists(ExpandConstant('{src}Support\System\x86\langpack.exe')) = false) then begin
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
  	
  	//D�tection et installation de Crystal Report
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
