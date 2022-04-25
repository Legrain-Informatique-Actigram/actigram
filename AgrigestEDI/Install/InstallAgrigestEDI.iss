;DEFINITION DES CONSTANTES
;///////////////////////////////////////////////////////////////////////////////////////
#define StandardVersion "False"; "True"
;#define Client "CO"
#define Configuration "x86\Debug" ;"Release"
#define MyAppName "AgrigestEDI"
#define MyProjName MyAppName
#define MyAppNameDisplay "Agrigest EDI"
#define MyAppId "{F9C90EB2-DF53-4257-A396-A03FC0719991}" 
;///////////////////////////////////////////////////////////////////////////////////////

#define MyInfoOrg "EIP"
#ifdef Client
	#define MyInfoOrg Client
#endif

;SCRIPT DE DEPLOIEMENT
#include "C:\Dev\Actigram\InnoSetup\Deploy.iss"
;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
;#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet2_Crystal_core.iss"
//;SCRIPT DE VERIFICATION DU PROGRAMME EN COURS D'UTILISATION
#include "C:\Dev\Actigram\InnoSetup\issproc.iss"

[Setup]
;ATTENTION, SI ON CHANGE CET AppID, ON CASSE LE MODE DE DETECTION D'AGRIGEST EDI
AppID={{F9C90EB2-DF53-4257-A396-A03FC0719991}
LicenseFile=CLUF Agrigest.rtf
InfoBeforeFile=
;DEFINIT LES PARAMETRES DE L'INSTALLEUR EN FONCTION DES CONSTANTES
#include "C:\Dev\Actigram\InnoSetup\common.iss"
;FICHIERS STANDARD DE L'APPLI (exe + dll du rep build)
#include "C:\Dev\Actigram\InnoSetup\applifiles.iss"

[Files]
;Fichiers content
Source: {#RepBuild}\*.pdf; DestDir: {app}; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\Etats\*.rpt; DestDir: {app}\Etats; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\PlanType\DataPlanType.xml; DestDir: {app}\PlanType; Flags: ignoreversion overwritereadonly
;Bases de données
Source: Base\*.xml; DestDir: {app}\Data; Flags: overwritereadonly ignoreversion
Source: Base\*.mdb; DestDir: {app}\Data; Flags: ignoreversion overwritereadonly
;Paramétrage FTP pour récupération EDI Cogédis
#ifdef Client
#if Client="CO"
Source: Base\ParamEdi{#Client}.dat; DestDir: {app}\Data\; DestName: ParamEdi.dat; Flags: ignoreversion overwritereadonly; Tasks: ParamEdi
#endif
#endif

;MigrationBase
Source: ..\DatabaseUpdate\bin\x86\Release\MigrationBase.exe; DestDir: {app}; Flags: overwritereadonly ignoreversion
;UtilitaireAccess
#define UtilAccess "..\..\UtilitaireAccess\UtilitaireAccess\bin\Debug\UtilitaireAccess"
Source: {#UtilAccess}.exe; DestDir: {app}; Flags: ignoreversion
Source: {#UtilAccess}.pdb; DestDir: {app}; Flags: ignoreversion
Source: {#UtilAccess}.exe.config; DestDir: {app}; Flags: ignoreversion


[Tasks]
#ifdef Client
#if Client="CO"
Name: ParamEdi; Description: Téléchargement automatique des EDI (client Cogédis uniquement)
#endif
#endif
Name: Acrobat; Description: Installer Adobe Acrobat Reader afin de visualiser le fichier d'aide du logiciel (recommandé); Flags: unchecked
[Run]
Filename: {src}\Acrobat\AdbeRdr812_fr_FR.exe; StatusMsg: Installation de Adobe Acrobat Reader 8.12; Tasks: Acrobat; Check: AppliInstallee; Languages: 
Filename: {app}\MigrationBase.exe; Parameters: -base=auto -auto; StatusMsg: Mise à jour des données; Check: AppliInstallee
Filename: {app}\{#MyAppName}.exe; WorkingDir: {app}; Flags: postinstall shellexec; Tasks: ; Languages: ; Description: Lancer {#MyAppNameDisplay}
;POUR PROPOSER L'INSTALL D'ULTRAVNC
#include "C:\Dev\Actigram\InnoSetup\ultravnc.iss"
;FONCTION DE CODE COMMUNES
#include "C:\Dev\Actigram\InnoSetup\utils.iss"

[Code]
//Wizard Events
//function InitializeSetup(): Boolean;
//begin
//  Result := prerequis_InitializeSetup;
//end;

//function NextButtonClick(CurPage: Integer): Boolean;
//begin
//	Result := prerequis_NextButtonClick(CurPage);
//	if Result then begin
//		Result := issproc_NextButtonClick(CurPage);
//  end;
//end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  Registre: String;
  FichierUninstall: String;
  ErrorCode : Integer;
  MessageErreur: String;
  NomApplication: String;
  NumVersionApplication: String;
  SoftwareVersion: string;
begin
  if CurStep = ssInstall then begin
    // Clé Id de registre
    Registre := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1';
    if RegQueryStringValue( HKLM, Registre, 'QuietUninstallString', FichierUninstall) then begin
      // Récupération du nom de l'application installée
      RegQueryStringValue( HKLM, Registre, 'DisplayName', NomApplication);
      MessageErreur := 'Une version de l''application ' + NomApplication + ' est déjà présente sur ce poste. ' 
      + 'Pour continuer l''installation, vous devez la désinstaller.' + #13#10 
      + 'Souhaitez vous lancer la désinstallation maintenant ? ';
      // Confirmation de la désinstallation
      if (Msgbox(MessageErreur, mbConfirmation, MB_YESNO) = IDYES) then begin
        if Exec('cmd', '/c ' + FichierUninstall, '', SW_HIDE, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur lors de la désinstallation de l''application : ' + SysErrorMessage(ErrorCode), mbError, MB_OK);
            Abort;
        end;
      end else begin
        Msgbox('Installation annulée.', mbConfirmation, MB_Ok);
        Abort;
      end;
    end;
  end;
  
  if CurStep = ssPostInstall then begin
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

//#expr SaveToFile("preprocessed.iss"), Exec("notepad.exe", "preprocessed.iss"):

