#include "C:\ACTIGRAM\InnoSetup\prerequis_Dotnet35Client_core.iss"

[Code]
function InitializeSetup(): Boolean;
begin
  Result := prerequis_InitializeSetup;
end;

function NextButtonClick(CurPage: Integer): Boolean;
begin
	Result := prerequis_NextButtonClick(CurPage);
end;
