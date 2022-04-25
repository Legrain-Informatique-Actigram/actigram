Namespace AnnexesTiers.ClassesControleur
    Public Class GestionnaireActif_Passif

        Private _DAOActif_Passif As AnnexesTiers.ClassesTechniques.DAOActif_Passif

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOActif_Passif = New AnnexesTiers.ClassesTechniques.DAOActif_Passif(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetActif_Passif(ByVal ID_ACTIF_PASSIF As Integer) As AnnexesTiers.ClassesMetier.Actif_Passif
            Dim act_Pass As AnnexesTiers.ClassesMetier.Actif_Passif = Nothing

            act_Pass = Me._DAOActif_Passif.GetActif_Passif(ID_ACTIF_PASSIF)

            Return act_Pass
        End Function

        Public Function GetActif_Passif(ByVal CODE_ACTIF_PASSIF As String) As AnnexesTiers.ClassesMetier.Actif_Passif
            Dim act_Pass As AnnexesTiers.ClassesMetier.Actif_Passif = Nothing

            act_Pass = Me._DAOActif_Passif.GetActif_Passif(CODE_ACTIF_PASSIF)

            Return act_Pass
        End Function
#End Region

    End Class
End Namespace
