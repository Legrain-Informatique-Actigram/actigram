#define MyAppName "Agrifact"
#define ver "2.5"
#define MyAppVersion Copy(ver,1,3)
#define MyAppRevision Copy(ver,5)
#undef ver
#define MyAppPublisher "Actigram"
#define MyAppURL "http://www.actigram.com"
#define OutputDir "Pack"
#define OutputFile "setupMigrationAgrifact" + "." + MyAppVersion
#define RepDeploy "\\serveur\ProduitsActigram\installs\"+ MyAppName +"\"
#define RepDeploy RepDeploy + "Install_MigrationAgrifact_" + MyAppVersion + "\"
#define MyAppId "{40C7ABE8-23F2-418B-98C3-3E17B6645CA7}"
#define AppIdAncienAgrifact "{67104DAD-E5C4-4D73-8932-091430A2A4F8}"

;SCRIPT DE DETECTION ET DE TELECHARGEMENT ET D'INSTALLATION DES PREREQUIS
;#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet2_Crystal.iss"

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
VersionInfoDescription=Migration d'{#MyAppName}
VersionInfoCopyright={#MyAppPublisher} 2010
MinVersion=0,5.0.2195
PrivilegesRequired=admin
ShowLanguageDialog=no
Uninstallable=false
AlwaysShowComponentsList=false
ShowComponentSizes=false
FlatComponentsList=false
ShowTasksTreeLines=true
ExtraDiskSpaceRequired=367001600
AppID={{40C7ABE8-23F2-418B-98C3-3E17B6645CA7}
WizardImageBackColor=clWhite
WizardSmallImageFile=img\image_install_petit.bmp
WizardImageFile=img\image_install_grand.bmp
DisableDirPage=yes
DisableStartupPrompt=true
UsePreviousTasks=true
TerminalServicesAware=true
DisableFinishedPage=true
UserInfoPage=false
UsePreviousUserInfo=false

[Languages]
Name: french; MessagesFile: compiler:Languages\French.isl
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[Tasks]

[Files]
Source: ..\MigrationAgrifact\bin\x86\Debug\MigrationAgrifact.exe; DestDir: {src}\Migration_Agrifact; Flags: ignoreversion
Source: ..\MigrationAgrifact\ParamInstallSQLEXPRESS.xml; DestDir: {src}\Migration_Agrifact; Flags: ignoreversion 
Source: ..\Install\Pack\setupAgrifact.2.5.exe; DestDir: {src}\Migration_Agrifact; Flags: ignoreversion
Source: ..\Install\Pack\Support\Components\SQLEXPR32_FRA.EXE; DestDir: {src}\Migration_Agrifact\Support\Components; Flags: ignoreversion
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86.msi; DestDir: {src}\Migration_Agrifact\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\Components\CRRedist2005_x86_fr.msi; DestDir: {src}\Migration_Agrifact\Support\Components; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\dotnetfx.exe; DestDir: {src}\Migration_Agrifact\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:
Source: ..\Install\Pack\Support\System\langpack.exe; DestDir: {src}\Migration_Agrifact\Support\System\x86; Flags: ignoreversion; Tasks: ; Languages:

[Run]
Filename: {src}\Migration_Agrifact\MigrationAgrifact.exe; Parameters:; StatusMsg: Migration d'{#MyAppName}; Flags: runascurrentuser

[_ISToolPostCompile]
Name: Wscript; Parameters: """.\deploy.vbs"" ""{#OutputDir}\{#OutputFile}.exe"" ""{#RepDeploy}"""

[Code]
procedure CurStepChanged(CurStep: TSetupStep);
var
  Registre: String;
  FichierUninstall: String;
  ErrorCode : Integer;
  MessageErreur: String;
  SoftwareVersion: string;
  NetFrameWorkInstalled : Boolean;
begin
  if CurStep = ssInstall then begin
    // Clé Id de registre
    Registre := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#AppIdAncienAgrifact}';
    if RegQueryStringValue( HKLM, Registre, 'UninstallString', FichierUninstall) = False then begin
      MessageErreur := 'Pas d''ancienne version présente sur ce poste. ' 
      + 'Migration annulée.';
      Msgbox(MessageErreur, mbConfirmation, MB_OK);
      Abort;  	
    end;
  end;
  if CurStep = ssPostInstall then begin
  	//Détection et installation de .NETFramework 2.0
    NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0');
    if not NetFrameWorkInstalled then begin
      // Si le pack d'install du framework n'est pas présent dans {src}
      if (FileExists(ExpandConstant('{src}\Migration_Agrifact\Support\System\x86\dotnetfx.exe')) = false)
		    or (FileExists(ExpandConstant('{src}\Migration_Agrifact\Support\System\x86\langpack.exe')) = false) then begin
        MsgBox('Impossible d''installer .NETFramework 2.0 : fichier d''installation manquant.', mbError, MB_OK);
      end else begin
        // Lancement de l'installation du framework, suivi du language pack
        if Exec(ExpandConstant('{src}\Migration_Agrifact\Support\System\x86\dotnetfx.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
          MsgBox('Erreur dans l''installation de .NETFramework 2.0 : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
        end else begin
          if Exec(ExpandConstant('{src}\Migration_Agrifact\Support\System\x86\langpack.exe'), '/Q', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) = False then begin
            MsgBox('Erreur dans l''installation de .NETFramework 2.0 language pack : ' + SysErrorMessage(ErrorCode) , mbError, MB_OK);
          end;
        end;
      end;
    end;
  end;
end;
