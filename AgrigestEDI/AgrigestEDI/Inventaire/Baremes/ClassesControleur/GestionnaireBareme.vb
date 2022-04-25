Namespace Baremes.ClassesControleur
    Public Class GestionnaireBareme

        Private _DAOBareme As Baremes.ClassesTechniques.DAOBareme

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOBareme = New Baremes.ClassesTechniques.DAOBareme(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetBareme(ByVal ID_BAREME As Integer) As Baremes.ClassesMetier.Bareme
            Dim brme As Baremes.ClassesMetier.Bareme = Nothing

            brme = Me._DAOBareme.GetBareme(ID_BAREME)

            Return brme
        End Function

        Public Function MaterielEstAffecteABareme(ByVal ID_MATERIEL As Integer) As Boolean
            Return Me._DAOBareme.MaterielEstAffecteABareme(ID_MATERIEL)
        End Function

        Public Function CopierListeBaremes(ByVal anneeAImporter As String, ByVal anneeImport As String, _
                                        ByVal baremesDS As DataSetBaremes) As Integer

            Return Me._DAOBareme.CopierListeBaremes(anneeAImporter, anneeImport, baremesDS)
        End Function
#End Region

    End Class
End Namespace
