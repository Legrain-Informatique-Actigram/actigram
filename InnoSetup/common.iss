[Setup]
AppName={#MyAppNameDisplay}
AppVerName={#MyAppNameDisplay} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppNameDisplay}
DisableProgramGroupPage=yes
OutputDir={#OutputDir}
OutputBaseFilename={#OutputFile}
SetupIconFile=Pack\Setup.ico
Compression=lzma/Max
SolidCompression=true
VersionInfoVersion={#MyAppVersion}.{#MyAppRevision}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription={#MyVersionInfoDescription}
VersionInfoCopyright={#MyAppPublisher} 2010
MinVersion=0,5.0.2195
PrivilegesRequired=admin
ShowLanguageDialog=no
Uninstallable=true
AlwaysShowComponentsList=false
ShowComponentSizes=false
FlatComponentsList=false
ShowTasksTreeLines=true
WizardImageBackColor=clWhite
WizardSmallImageFile=img\image_install_petit.bmp
WizardImageFile=img\image_install_grand.bmp
AppVersion={#MyAppVersion}
UninstallDisplayIcon={app}\{#MyAppName}.exe
UninstallDisplayName={#MyAppNameDisplay} {#MyAppVersion}

[Icons]
Name: {group}\{#MyAppNameDisplay}; Filename: {app}\{#MyAppName}.exe; Flags: useapppaths
Name: {userdesktop}\{#MyAppNameDisplay}; Filename: {app}\{#MyAppName}.exe; Flags: useapppaths
