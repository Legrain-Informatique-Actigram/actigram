Namespace Baremes.ClassesControleur
    Public Class GestionnaireType_Materiel

        Private _DAOType_Materiel As Baremes.ClassesTechniques.DAOType_Materiel

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOType_Materiel = New Baremes.ClassesTechniques.DAOType_Materiel(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetType_Materiel(ByVal codeTypeMateriel As String) As Baremes.ClassesMetier.Type_Materiel
            Dim type_Mat As Baremes.ClassesMetier.Type_Materiel = Nothing

            type_Mat = Me._DAOType_Materiel.GetType_Materiel(codeTypeMateriel)

            Return type_Mat
        End Function
#End Region

    End Class
End Namespace
