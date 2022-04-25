[Files]
#define CheminSolutionAgrifact "C:\Dev\Actigram\AgriFact"
Source: {#CheminSolutionAgrifact}\Utilitaire\bin\Utilitaire.exe; DestDir: {app}; Flags: ignoreversion; Tasks: ; Languages: 
Source: {#CheminSolutionAgrifact}\InstallAuto\bin\InstallAuto.exe; DestDir: {app}; Flags: ignoreversion; Tasks: ; Languages: 

[Run]
Filename: {app}\InstallAuto.exe; Parameters: -auto {code:GetInstallAutoParm}; WorkingDir: {src}; StatusMsg: Initialisation des données {#MyAppName}; Flags: runhidden; Check: MustLaunchInstallAuto

[Code]
function GetInstallAutoParm(Param: String) : String;
begin
	if FileExists(ExpandConstant('{src}\BaseDepart\ParametresInstallation.xml')) then begin
		Result := ExpandConstant(' -parm="{src}\BaseDepart\ParametresInstallation.xml"');
	end else begin
		Result := '';
	end;
end;

function MustLaunchInstallAuto() : Boolean;
begin
	if FileExists(ExpandConstant('{app}\{#MyAppName}.exe')) then begin
		Result := FileExists(ExpandConstant('{src}\BaseDepart\ParametresInstallation.xml'));
	end else begin
		Result := false;
	end;
end;
