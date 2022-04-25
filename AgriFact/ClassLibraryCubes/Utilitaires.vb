Public Class Utilitaires

#Region "Méthodes partagées"
    Public Shared Function CheminComplet(ByVal fichier As String) As String
        If IO.Path.IsPathRooted(fichier) Then
            Return fichier
        Else
            Return IO.Path.Combine(My.Application.Info.DirectoryPath, fichier)
        End If
    End Function
#End Region

End Class
