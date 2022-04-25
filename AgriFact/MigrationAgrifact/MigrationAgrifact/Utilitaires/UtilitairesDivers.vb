Namespace Utilitaires
    Public Class UtilitairesDivers

#Region "Méthodes partagées"
        Public Shared Sub AddDirectorySecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As Security.AccessControl.FileSystemRights, ByVal ControlType As Security.AccessControl.AccessControlType)
            ' Create a new DirectoryInfoobject.
            Dim dInfo As New System.IO.DirectoryInfo(FileName)

            ' Get a DirectorySecurity object that represents the 
            ' current security settings.
            Dim dSecurity As Security.AccessControl.DirectorySecurity = dInfo.GetAccessControl()

            ' Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(New Security.AccessControl.FileSystemAccessRule(Account, Rights, ControlType))

            ' Set the new access settings.
            dInfo.SetAccessControl(dSecurity)
        End Sub

        Public Shared Sub CreerNouveauFichierParametresXML()
            Dim cheminNouveau As String = ExecParam.CheminFichierParam("Nouvelle")
            Dim cheminAncien As String = ExecParam.CheminFichierParam("Ancienne")

            If Not (System.IO.File.Exists(cheminNouveau)) Then
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(cheminNouveau))
                System.IO.File.Copy(cheminAncien, cheminNouveau)
            End If
        End Sub
#End Region

    End Class
End Namespace
