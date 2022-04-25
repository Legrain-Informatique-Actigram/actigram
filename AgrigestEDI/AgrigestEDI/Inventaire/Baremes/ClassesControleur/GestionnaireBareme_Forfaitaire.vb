Namespace Baremes.ClassesControleur
    Public Class GestionnaireBareme_Forfaitaire

        Private _DAOBareme_Forfaitaire As Baremes.ClassesTechniques.DAOBareme_Forfaitaire

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOBareme_Forfaitaire = New Baremes.ClassesTechniques.DAOBareme_Forfaitaire(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetBareme_Forfaitaire(ByVal ID_BAREME_FORFAITAIRE As Integer) As Baremes.ClassesMetier.Bareme_Forfaitaire
            Dim brme_Forf As Baremes.ClassesMetier.Bareme_Forfaitaire = Nothing

            brme_Forf = Me._DAOBareme_Forfaitaire.GetBareme_Forfaitaire(ID_BAREME_FORFAITAIRE)

            Return brme_Forf
        End Function

        Public Function Facon_CulturaleEstAffecteABareme_Forfaitaire(ByVal ID_FACON_CULTURALE As Integer) As Boolean
            Return Me._DAOBareme_Forfaitaire.Facon_CulturaleEstAffecteABareme_Forfaitaire(ID_FACON_CULTURALE)
        End Function

        Public Function CopierListeBaremes_Forfaitaire(ByVal anneeAImporter As String, ByVal anneeImport As String, _
                                        ByVal baremesDS As DataSetBaremes) As Integer

            Return Me._DAOBareme_Forfaitaire.CopierListeBaremes_Forfaitaire(anneeAImporter, anneeImport, baremesDS)
        End Function
#End Region

    End Class
End Namespace
