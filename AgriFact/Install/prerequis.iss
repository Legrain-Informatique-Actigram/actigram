#include "isxdl.iss"

[CustomMessages]
;configurations
SystemDependenciesDir=Support\System
ComponentsDependenciesDir=Support\Components

MSI20Title=Windows Installer 2.0
MSI31Title=Windows Installer 3.1
IE6Title=Internet Explorer 6
MDACTitle=MDAC 2.8
JETTitle=JET 4
DOTNET20Title=Microsoft .NET Framework 2.0
DOTNET20FRTitle=Microsoft .NET Framework 2.0 French Language Pack
CR20Title=Crystal Reports for .NET Framework 2.0

;memos
en.DependenciesDownloadTitle=Download Dependencies
de.DependenciesDownloadTitle=Abhängigkeiten herunterladen
french.DependenciesDownloadTitle=Téléchargement des prérequis

en.DependenciesInstallTitle=Install Dependencies
de.DependenciesInstallTitle=Abhängigkeiten installieren
french.DependenciesInstallTitle=Installation des prérequis


;messages
en.Win2000Sp3Msg=Windows 2000 Service Pack 3 must be installed before setup can continue. Please install Windows 2000 Service Pack 3 and run Setup again.
de.Win2000Sp3Msg=Windows 2000 Service Pack 3 muss installiert werden bevor das Setup fortfahren kann. Bitte installieren Sie Windows 2000 Service Pack 3 und starten Sie das Setup erneut.
french.Win2000Sp3Msg=Windows 2000 Service Pack 3 doit être installé avant que l’installation puisse continuer. Veuillez installer Windows 2000 Service Pack 3 puis relancer l’installation.

en.WinXPSp2Msg=Windows XP Service Pack 2 must be installed before setup can continue. Please install Windows XP Service Pack 2 and run Setup again.
de.WinXPSp2Msg=Windows XP Service Pack 2 muss installiert werden bevor das Setup fortfahren kann. Bitte installieren Sie Windows XP Service Pack 2 und starten Sie das Setup erneut.
french.WinXPSp2Msg=Windows XP Service Pack 2 doit être installé avant que l’installation puisse continuer. Veuillez installer Windows XP Service Pack 2 puis relancer l’installation.

en.CR20Msg=Crystal Reports  for .NET Framework 2.0 installation files cannot be found. Please run the installation from its original location.
french.CR20Msg=Les fichiers d'installation de Crystal Reports  for .NET Framework 2.0 sont introuvables. Veuillez executer le programme d'installation depuis sont emplacement d'origine.

;en.IISMsg=Microsoft IIS must be installed before setup can continue. Please install Microsoft IIS and run Setup again.
;de.IISMsg=Microsoft IIS muss installiert werden bevor das Setup fortfahren kann. Bitte installieren Sie Microsoft ISS und starten Sie das Setup erneut.

en.DownloadMsg1=The following applications are required before setup can continue:
de.DownloadMsg1=Die folgenden Programme werden benötigt bevor das Setup fortfahren kann:
french.DownloadMsg1=Les applications suivantes sont requises pour que l’installation puisse continuer :

en.DownloadMsg2=Download and install now?
de.DownloadMsg2=Jetzt downloaden und installieren?
french.DownloadMsg2=Télécharger et installer maintenant ?

;install text
en.MSI20DownloadSize=~1.7 MB
en.MSI31DownloadSize=~2.5 MB
en.IE6DownloadSize=~46 MB
en.MDACDownloadSize=~5.4 MB
en.JETDownloadSize=~3.7 MB
en.DOTNET20DownloadSize=~23 MB
en.DOTNET20FRDownloadSize=~2 MB

de.MSI20DownloadSize=~1,7 MB
de.MSI31DownloadSize=~2,5 MB
de.IE6DownloadSize=~46 MB
de.MDACDownloadSize=~5,4 MB
de.JETDownloadSize=~3,7 MB
de.DOTNET20DownloadSize=~23 MB

french.MSI20DownloadSize=~1.7 Mo
french.MSI31DownloadSize=~2.5 Mo
french.IE6DownloadSize=~46 Mo
french.MDACDownloadSize=~5.4 Mo
french.JETDownloadSize=~3.7 Mo
french.DOTNET20DownloadSize=~23 Mo
french.DOTNET20FRDownloadSize=~2 Mo


en.MSI20InstallMsg=Installing Windows Installer 2.0... (May take a few minutes)
de.MSI20InstallMsg=Installiere Windows Installer 2.0... (Kann einige Minuten dauern)
french.MSI20InstallMsg=Installation de Windows Installer 2.0... (Ceci peut prendre quelques minutes)

en.MSI31InstallMsg=Installing Windows Installer 3.1... (This may take a few minutes)
de.MSI31InstallMsg=Installiere Windows Installer 3.1... (Kann einige Minuten dauern)
french.MSI31InstallMsg=Installation de Windows Installer 3.1... (Ceci peut prendre quelques minutes)

en.IE6InstallMsg=Installing Internet Explorer 6... (May take a few minutes)
de.IE6InstallMsg=Installiere Internet Explorer 6... (Kann einige Minuten dauern)
french.IE6InstallMsg=Installation de Internet Explorer 6... (Ceci peut prendre quelques minutes)

en.MDACInstallMsg=Installing MDAC 2.8... (May take a few minutes)
de.MDACInstallMsg=Installiere MDAC 2.8... (Kann einige Minuten dauern)
french.MDACInstallMsg=Installation de MDAC 2.8... (Ceci peut prendre quelques minutes)

en.JETInstallMsg=Installing JET 4... (May take a few minutes)
de.JETInstallMsg=Installiere JET 4... (Kann einige Minuten dauern)
french.JETInstallMsg=Installation de JET 4... (Ceci peut prendre quelques minutes)

en.DOTNET20InstallMsg=Installing Microsoft .NET Framework 2.0... (May take a few minutes)
de.DOTNET20InstallMsg=Installiere Microsoft .NET Framework 2.0... (Kann einige Minuten dauern)
french.DOTNET20InstallMsg=Installation de Microsoft .NET Framework 2.0... (Ceci peut prendre quelques minutes)

en.DOTNET20FRInstallMsg=Installing Microsoft .NET Framework 2.0 French Language Pack... (May take a few minutes)
french.DOTNET20FRInstallMsg=Installation de Microsoft .NET Framework 2.0 French Language Pack... (Ceci peut prendre quelques minutes)

en.CR20InstallMsg=Installing Crystal Reports for .NET Framework 2.0... (May take a few minutes)
french.CR20InstallMsg=Installation de Crystal Reports pour .NET Framework 2.0... (Ceci peut prendre quelques minutes)


[_ISTool]
EnableISX=true

[Run]
Filename: {ini:{tmp}\dep.ini,install,msi20}; Description: {cm:MSI20Title}; StatusMsg: {cm:MSI20InstallMsg}; Parameters: /q; Flags: skipifdoesntexist
Filename: {ini:{tmp}\dep.ini,install,msi31}; Description: {cm:MSI31Title}; StatusMsg: {cm:MSI31InstallMsg}; Parameters: /quiet; Flags: skipifdoesntexist

Filename: {ini:{tmp}\dep.ini,install,ie}; Description: {cm:IE6Title}; StatusMsg: {cm:IE6InstallMsg}; Parameters: "/Q /C:""ie6wzd /QU /R:N /S:#e"""; Flags: skipifdoesntexist

Filename: {ini:{tmp}\dep.ini,install,mdac}; Description: {cm:MDACTitle}; StatusMsg: {cm:MDACInstallMsg}; Parameters: "/Q /C:""setup /QNT"""; Flags: skipifdoesntexist
;Filename: {ini:{tmp}\dep.ini,install,jet}; Description: {cm:JETTitle}; StatusMsg: {cm:JETInstallMsg}; Parameters: /Q; Flags: skipifdoesntexist

Filename: {ini:{tmp}\dep.ini,install,dotnet20}; Description: {cm:DOTNET20Title}; StatusMsg: {cm:DOTNET20InstallMsg}; Parameters: "/Q /T:{tmp}\dotnetfx /C:""install /q"""; Flags: skipifdoesntexist
Filename: {ini:{tmp}\dep.ini,install,dotnet20fr}; Description: {cm:DOTNET20Title}; StatusMsg: {cm:DOTNET20InstallMsg}; Parameters: "/Q /T:{tmp}\langpack /C:""install /q"""; Flags: skipifdoesntexist
Filename: msiexec.exe; Parameters: "/i ""{ini:{tmp}\dep.ini,install,cr20}"" /qb-!"; StatusMsg: {cm:CR20InstallMsg}; Check: FileExists(ExpandConstant('{ini:{tmp}\dep.ini,install,cr20}'))
Filename: msiexec.exe; Parameters: "/i ""{ini:{tmp}\dep.ini,install,cr20fr}"" /qb-!"; StatusMsg: {cm:CR20InstallMsg}; Check: FileExists(ExpandConstant('{ini:{tmp}\dep.ini,install,cr20fr}'))


[Code]
var
  downloadNeeded: boolean;
  neededDependenciesDownloadMemo: string;
  neededDependenciesInstallMemo: string;
  neededDependenciesDownloadMsg: string;

const
  msi20URL		= 'http://download.microsoft.com/download/WindowsInstaller/Install/2.0/W9XMe/EN-US/InstMsiA.exe';
  msi31URL		= 'http://download.microsoft.com/download/1/4/7/147ded26-931c-4daf-9095-ec7baf996f46/WindowsInstaller-KB893803-v2-x86.exe';
  mdacURL		= 'http://download.microsoft.com/download/c/d/f/cdfd58f1-3973-4c51-8851-49ae3777586f/MDAC_TYP.EXE';
  jetURL		= 'http://download.microsoft.com/download/4/3/9/4393c9ac-e69e-458d-9f6d-2fe191c51469/Jet40SP8_9xNT.exe';
  ieURL			= 'http://download.microsoft.com/download/ie6sp1/finrel/6_sp1/W98NT42KMeXP/EN-US/ie6setup.exe';
  dotnet20URL	= 'http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe';
  dotnet20frURL	= 'http://download.microsoft.com/download/9/9/5/995002e9-b8b9-4794-8d09-6eaa8f8b2806/langpack.exe';
  msi20exe		= 'InstMsiA.exe';
  msi31exe		= 'WindowsInstaller-KB893803-v2-x86.exe';
  mdacexe		= 'MDAC_TYP.EXE';
  dotnet20exe	= 'dotnetfx.exe';
  dotnet20frexe	= 'langpack.exe';
  cr20exe		= 'CRRedist2005_x86.msi';
  cr20frexe		= 'CRRedist2005_x86_fr.msi';

// get Windows Installer version
procedure DecodeVersion(const Version: cardinal; var a, b : word);
begin
  a := word(Version shr 16);
  b := word(Version and not $ffff0000);
end;

function IsMinMSIAvailable(HV:Integer; NV:Integer ): boolean;
var  Version,  dummy     : cardinal;
     MsiHiVer,  MsiLoVer  : word;

begin
    Result:=(FileExists(ExpandConstant('{sys}\msi.dll'))) and
        (GetVersionNumbers(ExpandConstant('{sys}\msi.dll'), Version, dummy));
    DecodeVersion(Version, MsiHiVer, MsiLoVer);
    Result:= (Result) and (MsiHiVer >= HV) and (MsiLoVer >= NV);
end;


function AddDependency(depId,cmTitle,cmDownloadSize,cmDir,exeName,url : String): Boolean;
var
	path : String;
begin
	neededDependenciesInstallMemo := neededDependenciesInstallMemo + '      ' + CustomMessage(cmTitle) + #13;
    path := ExpandConstant('{src}') + '\' + CustomMessage(cmDir) + '\' + exeName;
    if not FileExists(path) then begin
      path := ExpandConstant('{tmp}\' + exeName);
      if not FileExists(path) then begin
        neededDependenciesDownloadMemo := neededDependenciesDownloadMemo + '      ' + CustomMessage(cmTitle) + #13;
        neededDependenciesDownloadMsg := neededDependenciesDownloadMsg + CustomMessage(cmTitle) + ' (' + CustomMessage(cmDownloadSize) + ')' + #13;
        isxdl_AddFile(url,path);
        downloadNeeded := true;
      end;
    end;
    SetIniString('install', depId, path, ExpandConstant('{tmp}\dep.ini'));
	Result := true;
end;

function AddLocalDependency(depId,cmDir,exeName : String): Boolean;
var
	path : String;
begin
	path := ExpandConstant('{src}') + '\' + CustomMessage(cmDir) + '\' + exeName;
    if not FileExists(path) then begin
		Result := False;
    end else begin
		SetIniString('install', depId, path, ExpandConstant('{tmp}\dep.ini'));
		Result := true;
    end;
end;


function InitializeSetup(): Boolean;
var
  SoftwareVersion: string;
  WindowsVersion: TWindowsVersion;

begin
  GetWindowsVersionEx(WindowsVersion);
  Result := true;

  // Check for Windows 2000 SP3
  if WindowsVersion.NTPlatform and
     (WindowsVersion.Major = 5) and
     (WindowsVersion.Minor = 0) and
     (WindowsVersion.ServicePackMajor < 3) then
  begin
    MsgBox(CustomMessage('Win2000Sp3Msg'), mbError, MB_OK);
    Result := false;
    exit;
  end;

  // Check for Windows XP SP2
  if WindowsVersion.NTPlatform and
     (WindowsVersion.Major = 5) and
     (WindowsVersion.Minor = 1) and
     (WindowsVersion.ServicePackMajor < 2) then
  begin
    MsgBox(CustomMessage('WinXPSp2Msg'), mbError, MB_OK);
    Result := false;
    exit;
  end;

  // Check for IIS installation
  //if not RegKeyExists(HKLM, 'SYSTEM\CurrentControlSet\Services\W3SVC\Security') then begin
  //  MsgBox(CustomMessage('IISMsg'), mbError, MB_OK);
  //  Result := false;
  //  exit;
  //end;

  // Check for required Windows Installer 2.0 on Windows 98 and ME
  if (not WindowsVersion.NTPlatform) and
     (WindowsVersion.Major >= 4) and
     (WindowsVersion.Minor >= 1) and
     (not IsMinMSIAvailable(2,0)) then
  begin
	AddDependency('msi20','MSI20Title','MSI20DownloadSize','SystemDependenciesDir',msi20exe,msi20URL);
  end;

  // Check for required Windows Installer 3.0 on Windows 2000, XP, Server 2003, Vista or higher
  if WindowsVersion.NTPlatform and
     (WindowsVersion.Major >= 5) and
     (not IsMinMSIAvailable(3,0)) then
  begin
	AddDependency('msi31','MSI31Title','MSI31DownloadSize','SystemDependenciesDir',msi31exe,msi31URL);
  end;

  // Check for required Internet Explorer installation
  // Note that if Internet Explorer 6 is downloaded, the express setup will be downloaded, however it is the same
  // ie6setup.exe that would be available in the ie6 folder. The only difference is that the
  // user will be presented with an option as to where to download Internet Explorer 6 and a progress dialog.
  // Most common components will still be installed automatically.
  SoftwareVersion := '';
  RegQueryStringValue(HKLM, 'Software\Microsoft\Internet Explorer', 'Version', SoftwareVersion);
  if (SoftwareVersion < '5') then begin
	AddDependency('ie','IE6Title','IE6DownloadSize','SystemDependenciesDir','ie6setup.exe',ieURL);
  end;

  // Check for required MDAC installation
  SoftwareVersion := '';
  RegQueryStringValue(HKLM, 'Software\Microsoft\DataAccess', 'FullInstallVer', SoftwareVersion);
  if (SoftwareVersion < '2.7') then begin
	AddDependency('mdac','MDACTitle','MDACDownloadSize','SystemDependenciesDir',mdacexe,mdacURL);
  end;

  // Check for required dotnetfx 2.0 installation
  if (not RegKeyExists(HKLM, 'SOFTWARE\Microsoft\.NETFramework\policy\v2.0')) then begin
    // Framework
    AddDependency('dotnet20','DOTNET20Title','DOTNET20DownloadSize','SystemDependenciesDir',dotnet20exe,dotnet20URL);

    // Language Pack
    AddDependency('dotnet20fr','DOTNET20FRTitle','DOTNET20FRDownloadSize','SystemDependenciesDir',dotnet20frexe,dotnet20frURL);
  end;

  //Crystal Reports : Pas téléchargeable en ligne, si on en a besoin il faut qu'il soit présent avec l'install
  SoftwareVersion := '';
  RegQueryStringValue(HKLM, 'SOFTWARE\Crystal Decisions\10.2\Crystal Reports', 'BuildNum', SoftwareVersion);
  if (SoftwareVersion < '570') then begin
	if not (AddLocalDependency('cr20','ComponentsDependenciesDir',cr20exe) and
			AddLocalDependency('cr20fr','ComponentsDependenciesDir',cr20frexe))then begin
		MsgBox(CustomMessage('CR20Msg'), mbError, MB_OK);
		Result := false;
		exit;
	end;
  end;

end;


function NextButtonClick(CurPage: Integer): Boolean;
var
  hWnd: Integer;

begin
  Result := true;

  if CurPage = wpReady then begin

    hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));

    if downloadNeeded then
      if MsgBox(CustomMessage('DownloadMsg1') + #13 + neededDependenciesDownloadMsg + #13 + CustomMessage('DownloadMsg2'), mbConfirmation, MB_YESNO) = IDNO then Result := false
      else if isxdl_DownloadFiles(hWnd) = 0 then Result := false;
  end;
end;

function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
var
  s: string;

begin
  if neededDependenciesDownloadMemo <> '' then s := s + CustomMessage('DependenciesDownloadTitle') + ':' + NewLine + neededDependenciesDownloadMemo + NewLine;
  if neededDependenciesInstallMemo <> '' then s := s + CustomMessage('DependenciesInstallTitle') + ':' + NewLine + neededDependenciesInstallMemo + NewLine;

  s := s + MemoDirInfo + NewLine + NewLine + MemoGroupInfo
  if MemoTasksInfo <> '' then  s := s + NewLine + NewLine + MemoTasksInfo;

  Result := s
end;


[InnoIDE_Settings]
LogFileOverwrite=false

