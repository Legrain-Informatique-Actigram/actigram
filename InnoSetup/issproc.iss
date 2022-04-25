[Files]
;------ add IssProc (Files In Use Extension)
Source: C:\Dev\Actigram\InnoSetup\IssProc.dll; DestDir: {tmp}; Flags: dontcopy
;------ add IssProc extra language file (you don't need to add this file if you are using english only)
Source: C:\Dev\Actigram\InnoSetup\IssProcLanguage.ini; DestDir: {tmp}; Flags: dontcopy
;------ Copy IssProc in your app folder if you want to use it on unistall
Source: C:\Dev\Actigram\InnoSetup\IssProc.dll; DestDir: {app}
;Source: IssProc.dll; DestDir: {app}
;Source: IssProcLanguage.ini; DestDir: {app}
;------

[Code]
// IssFindModule called on install
function IssFindModule(hWnd: Integer; Modulename: AnsiString; Language: AnsiString; Silent: Boolean; CanIgnore: Boolean ): Integer;
external 'IssFindModule@files:IssProc.dll stdcall setuponly';

// IssFindModule called on uninstall
function IssFindModuleU(hWnd: Integer; Modulename: AnsiString; Language: AnsiString; Silent: Boolean; CanIgnore: Boolean ): Integer;
external 'IssFindModule@{app}\IssProc.dll stdcall uninstallonly';

//********************************************************************************************************************************************
// IssFindModule function returns: 0 if no module found; 1 if cancel pressed; 2 if ignore pressed; -1 if an error occured
//
//  hWnd        = main wizard window handle.
//
//  Modulename  = module name(s) to check. You can use a full path to a DLL/EXE/OCX or wildcard file name/path. Separate multiple modules with semicolon.
//                 Example1 : Modulename='*mymodule.dll';     -  will search in any path for mymodule.dll
//                 Example2 : Modulename=ExpandConstant('{app}\mymodule.dll');     -  will search for mymodule.dll only in {app} folder (the application directory)
//                 Example3 : Modulename=ExpandConstant('{app}\mymodule.dll;*myApp.exe');   - just like Example2 + search for myApp.exe regardless of his path.
//
//  Language    = files in use language dialog. Set this value to empty '' and default english will be used
//                ( see and include IssProcLanguage.ini if you need custom text or other language)
//
//  Silent      = silent mode : set this var to true if you don't want to display the files in use dialog.
//                When Silent is true IssFindModule will return 1 if it founds the Modulename or 0 if nothing found
//
//  CanIgnore   = set this var to false to Disable the Ignore button forcing the user to close those applications before continuing
//                set this var to true to Enable the Ignore button allowing the user to continue without closing those applications
//******************************************************************************************************************************************


function issproc_NextButtonClick(CurPage: Integer): Boolean;
var
  hWnd: Integer;
  sModuleName: String;
  nCode: Integer;  {IssFindModule returns: 0 if no module found; 1 if cancel pressed; 2 if ignore pressed; -1 if an error occured }
begin
  Result := true;

 if CurPage = wpReady then
   begin
      Result := false;
      ExtractTemporaryFile('IssProcLanguage.ini');                          { extract extra language file - you don't need to add this line if you are using english only }
      hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));                     { get main wizard handle }
      sModuleName :=ExpandConstant('{app}\{#MyAppName}.exe');		        { searched modules. Tip: separate multiple modules with semicolon Ex: '*mymodule.dll;*mymodule2.dll;*myapp.exe'}

     nCode:=IssFindModule(hWnd,sModuleName,'fr',false,false);                { search for module and display files-in-use window if found  }
     //sModuleName:=IntToStr(nCode);
    // MsgBox ( sModuleName, mbConfirmation, MB_YESNO or MB_DEFBUTTON2);

     if nCode=1 then  begin                                                 { cancel pressed or files-in-use window closed }
          PostMessage (WizardForm.Handle, $0010, 0, 0);                     { quit setup, $0010=WM_CLOSE }
     end else if (nCode=0) or (nCode=2) then begin                          { no module found or ignored pressed}
          Result := true;                                                   { continue setup  }
     end;

  end;

end;


//function issproc_InitializeUninstall(): Boolean;
//var
//  sModuleName: String;
//  nCode: Integer;  {IssFindModule returns: 0 if no module found; 1 if cancel pressed; 2 if ignore pressed; -1 if an error occured }
//
//begin
//    Result := false;
//     sModuleName := ExpandConstant('*Myprog.exe;');          { searched module. Tip: separate multiple modules with semicolon Ex: '*mymodule.dll;*mymodule2.dll;*myapp.exe'}
//
//     nCode:=IssFindModuleU(0,sModuleName,'enu',false,false); { search for module and display files-in-use window if found  }
//
//     if (nCode=0) or (nCode=2) then begin                    { no module found or ignored pressed}
//          Result := true;                                    { continue setup  }
//     end;
//
//    // Unload the extension, otherwise it will not be deleted by the uninstaller
//    UnloadDLL(ExpandConstant('{app}\IssProc.dll'));
//
//end;
