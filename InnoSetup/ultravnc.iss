[Tasks]
Name: UltraVNC; Description: Installer l'utilitaire de téléintervention UltraVNC; Flags: unchecked
[Run]
Filename: {src}\UltraVNC\UltraVNC-102-Setup-Fr.exe; Parameters: "/norestart /verysilent /loadinf=""{src}\UltraVNC\InstallLudo"""; StatusMsg: Installation d'UltraVNC; Flags: runhidden skipifdoesntexist; Tasks: UltraVNC; Check: AppliInstallee
