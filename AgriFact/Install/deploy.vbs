Main

Sub Main()
Set objArgs = WScript.Arguments
'V�rification des arguments
If objArgs.Count < 1 Then 
    MsgBox "Pas assez d'arguments",vbOkOnly Or vbCritical,"Erreur"
    WScript.Quit
End If

'Question
If MsgBox("D�ployer le fichier sur le serveur ?",vbYesNo Or vbQuestion,"D�ploiement") = vbNo Then WScript.Quit

Set objFSO = CreateObject("Scripting.FileSystemObject")
'V�rification du fichier source
If not objFSO.FileExists(objArgs(0)) Then MsgBox "Le fichier source est introuvable",vbOkOnly Or vbCritical,"Erreur"
'V�rification du r�pertoire cible
If not objFSO.FolderExists(objArgs(1)) Then objFSO.CreateFolder(objArgs(1))
'Copie du fichier
objFSO.CopyFile objArgs(0) , objArgs(1), True
MsgBox "D�ploiement OK",vbOkOnly Or vbInformation,"Fin"
End Sub