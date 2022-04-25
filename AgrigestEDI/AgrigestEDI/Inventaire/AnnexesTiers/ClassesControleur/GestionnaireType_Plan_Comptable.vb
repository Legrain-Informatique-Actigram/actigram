Namespace AnnexesTiers.ClassesControleur
    Public Class GestionnaireType_Plan_Comptable

        Private _DAOType_Plan_Comptable As AnnexesTiers.ClassesTechniques.DAOType_Plan_Comptable

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOType_Plan_Comptable = New AnnexesTiers.ClassesTechniques.DAOType_Plan_Comptable(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetType_Plan_Comptable(ByVal ID_TYPE_PLAN_COMPTABLE As Integer) As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim type_PC As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Nothing

            type_PC = Me._DAOType_Plan_Comptable.GetType_Plan_Comptable(ID_TYPE_PLAN_COMPTABLE)

            Return type_PC
        End Function

        Public Function GetType_Plan_Comptable(ByVal CODE_TYPE_PLAN_COMPTABLE As String) As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim type_PC As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Nothing

            type_PC = Me._DAOType_Plan_Comptable.GetType_Plan_Comptable(CODE_TYPE_PLAN_COMPTABLE)

            Return type_PC
        End Function
#End Region

    End Class
End Namespace
