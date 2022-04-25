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
