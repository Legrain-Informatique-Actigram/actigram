#include "C:\Dev\Actigram\InnoSetup\prerequis.iss"

[Code]
function prerequis_InitializeSetup(): Boolean;
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
