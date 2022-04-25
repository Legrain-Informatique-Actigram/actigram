[Files]
;Fichiers exec
Source: {#RepBuild}\{#MyAppName}.exe; DestDir: {app}; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\{#MyAppName}.pdb; DestDir: {app}; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\{#MyAppName}.exe.config; DestDir: {app}; Flags: ignoreversion overwritereadonly
Source: {#RepBuild}\*.dll; DestDir: {app}; Flags: ignoreversion overwritereadonly
