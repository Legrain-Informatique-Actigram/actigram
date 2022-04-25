[Code]
function AppliInstallee() : Boolean;
begin
	if FileExists(ExpandConstant('{app}\{#MyAppName}.exe')) then begin
		Result:=true;
	end else begin
		Result:=false;
	end;
end;

procedure AfterInstallAppli();
begin
	if not AppliInstallee() then begin
		MsgBox('L''application n''a pas été installée.', mbError, MB_OK);
	//end else begin
	//	ExtractTemporaryFile('AgrigestEDI.exe.config');
	//	FileCopy(ExpandConstant('{tmp}\AgrigestEDI.exe.config'),ExpandConstant('{app}\AgrigestEDI.exe.config'), false);
	end;
end;

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
