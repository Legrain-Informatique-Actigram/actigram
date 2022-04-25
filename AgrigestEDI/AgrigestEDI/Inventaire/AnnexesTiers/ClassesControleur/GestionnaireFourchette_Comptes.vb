Namespace AnnexesTiers.ClassesControleur
    Public Class GestionnaireFourchette_Comptes
        Private _DAOFourchette_Comptes As AnnexesTiers.ClassesTechniques.DAOFourchette_Comptes

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOFourchette_Comptes = New AnnexesTiers.ClassesTechniques.DAOFourchette_Comptes(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetFourchette_Comptes(ByVal ID_FOURCHETTE_COMPTES As Integer) As AnnexesTiers.ClassesMetier.Fourchette_Comptes
            Dim fourch_Cpts As AnnexesTiers.ClassesMetier.Fourchette_Comptes = Nothing

            fourch_Cpts = Me._DAOFourchette_Comptes.GetFourchette_Comptes(ID_FOURCHETTE_COMPTES)

            Return fourch_Cpts
        End Function

        Public Function GetListeInventairesLignesParCompte(ByVal compte As String, ByVal id_Type_Plan_Comptable As Integer) _
                                                As AnnexesTiers.ClassesMetier.ListeFourchettes_Comptes

            Return Me._DAOFourchette_Comptes.GetListeInventairesLignesParCompte(compte, id_Type_Plan_Comptable)
        End Function
#End Region

    End Class
End Namespace
