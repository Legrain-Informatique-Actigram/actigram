Namespace Inventaire.ClassesControleur
    Public Class GestionnaireTypeInventaire

        Private _DAOTypeInventaire As Inventaire.ClassesTechniques.DAOTypeInventaire

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOTypeInventaire = New Inventaire.ClassesTechniques.DAOTypeInventaire(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetTypeInventaire(ByVal codeTypeInventaire As String) As Inventaire.ClassesMetier.TypeInventaire
            Dim typeInv As Inventaire.ClassesMetier.TypeInventaire = Nothing

            typeInv = Me._DAOTypeInventaire.GetTypeInventaire(codeTypeInventaire)

            Return typeInv
        End Function
#End Region

    End Class
End Namespace
