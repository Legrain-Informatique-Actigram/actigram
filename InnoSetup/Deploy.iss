#define RepBuild "..\" + MyProjName + "\bin\" + Configuration
#define MyVersionInfoDescription "Programme d'installation d'" + MyAppNameDisplay
#define ver GetFileVersion(RepBuild +"\" + MyAppName + ".exe")
#define MyAppVersion Copy(ver,1,3)
#define MyAppRevision Copy(ver,5)
#undef ver
#define MyAppPublisher "Actigram"
#define MyAppURL "http://www.actigram.com"
#ifndef OutputDir
	#define OutputDir "Pack"
#endif
#ifndef OutputFilePrefix
	#define OutputFilePrefix "setup"
	#ifdef UpdatePackage
		#define OutputFilePrefix "update"
	#endif
#endif
#define OutputFile OutputFilePrefix + MyAppName
#ifdef OutputFileSuffix
	#define OutputFile OutputFile + OutputFileSuffix
#endif
#if StandardVersion != "True"
	#define OutputFile OutputFile + "." + MyAppVersion
#endif
#define RepDeploy "\\serveur\ProduitsActigram\Installs\"
#ifdef Solution
	#define RepDeploy RepDeploy + Solution + "\"
#endif
#define RepDeploy RepDeploy + MyAppName + "\"

#ifdef UpdatePackage
;Les update à la racine ?
#elif OutputFilePrefix=="Patch"
	#define RepDeploy  RepDeploy + "Patchs\"
#else
	#define RepDeploy  RepDeploy + "Install_"+ MyAppName
	#ifdef Client
		#define RepDeploy RepDeploy + "_" + Client
	#endif
	#if StandardVersion == "True"
		#define RepDeploy RepDeploy + "_Standard"
	#else
		#define RepDeploy RepDeploy + "_" + MyAppVersion
	#endif
	#define RepDeploy RepDeploy  + "\"
#endif

[_ISToolPostCompile]
Name: Wscript; Parameters: "C:\ACTIGRAM\InnoSetup\deploy.vbs ""{#OutputDir}\{#OutputFile}.exe"" ""{#RepDeploy}"""


[PostCompile]
Name: Wscript; Parameters: "C:\Dev\Actigram\InnoSetup\deploy.vbs ""{#OutputDir}\{#OutputFile}.exe"" ""{#RepDeploy}"""
