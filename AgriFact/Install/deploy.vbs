Main

Sub Main()
Set objArgs = WScript.Arguments
'Vérification des arguments
If objArgs.Count < 1 Then 
    MsgBox "Pas assez d'arguments",vbOkOnly Or vbCritical,"Erreur"
    WScript.Quit
End If

'Question
If MsgBox("Déployer le fichier sur le serveur ?",vbYesNo Or vbQuestion,"Déploiement") = vbNo Then WScript.Quit

Set objFSO = CreateObject("Scripting.FileSystemObject")
'Vérification du fichier source
If not objFSO.FileExists(objArgs(0)) Then MsgBox "Le fichier source est introuvable",vbOkOnly Or vbCritical,"Erreur"
'Vérification du répertoire cible
If not objFSO.FolderExists(objArgs(1)) Then objFSO.CreateFolder(objArgs(1))
'Copie du fichier
objFSO.CopyFile objArgs(0) , objArgs(1), True
MsgBox "Déploiement OK",vbOkOnly Or vbInformation,"Fin"
End Sub