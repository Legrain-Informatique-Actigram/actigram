[Files]
Source: ..\Setup{#MyProjName}\{#Configuration}\Setup.msi; DestDir: {app}; Flags: ignoreversion deleteafterinstall
[Run]
Filename: msiexec.exe; Parameters: "/i ""{app}\Setup.msi"" TARGETDIR=""{app}"" ALLUSERS=1 /qb-!"; StatusMsg: Installation du logiciel {#MyAppNameDisplay}; AfterInstall: AfterInstallAppli
