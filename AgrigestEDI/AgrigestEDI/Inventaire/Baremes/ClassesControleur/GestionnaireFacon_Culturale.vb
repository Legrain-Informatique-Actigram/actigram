Namespace Baremes.ClassesControleur
    Public Class GestionnaireFacon_Culturale

        Private _DAOFacon_Culturale As Baremes.ClassesTechniques.DAOFacon_Culturale

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOFacon_Culturale = New Baremes.ClassesTechniques.DAOFacon_Culturale(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetFacon_Culturale(ByVal ID_FACON_CULTURALE As Integer) As Baremes.ClassesMetier.Facon_Culturale
            Dim facCult As Baremes.ClassesMetier.Facon_Culturale = Nothing

            facCult = Me._DAOFacon_Culturale.GetFacon_Culturale(ID_FACON_CULTURALE)

            Return facCult
        End Function
#End Region

    End Class
End Namespace
