Namespace Baremes.ClassesControleur
    Public Class GestionnaireMateriel

        Private _DAOMateriel As Baremes.ClassesTechniques.DAOMateriel

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOMateriel = New Baremes.ClassesTechniques.DAOMateriel(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetMateriel(ByVal ID_MATERIEL As Integer) As Baremes.ClassesMetier.Materiel
            Dim mat As Baremes.ClassesMetier.Materiel = Nothing

            mat = Me._DAOMateriel.GetMateriel(ID_MATERIEL)

            Return mat
        End Function

        Public Function TypeEstAffecteAMateriel(ByVal ID_TYPE_MATERIEL As Integer) As Boolean
            Return Me._DAOMateriel.TypeEstAffecteAMateriel(ID_TYPE_MATERIEL)
        End Function
#End Region

    End Class
End Namespace
