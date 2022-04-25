Imports System.Data.OleDb

Namespace Baremes.ClassesControleur
    Public Class GestionnaireDossiers

        Private _DAODossiers As Baremes.ClassesTechniques.DAODossiers

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAODossiers = New Baremes.ClassesTechniques.DAODossiers(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetDossier(ByVal DDossier As String) As Baremes.ClassesMetier.Dossiers
            Return Me._DAODossiers.GetDossier(DDossier)
        End Function

        Public Function GetListeDossiers(ByVal DExpl As String) As Baremes.ClassesMetier.ListeDossiers
            Return Me._DAODossiers.GetListeDossiers(DExpl)
        End Function

        Public Function GetDDossierPrecedent(ByVal dossier_EnCours As Baremes.ClassesMetier.Dossiers) As String
            Return Me._DAODossiers.GetDDossierPrecedent(dossier_EnCours)
        End Function

        Public Sub UpdateDMethodeInventaire(ByVal DMethodeInventaire As String, _
                                            ByVal DDossier As String, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAODossiers.UpdateDMethodeInventaire(DMethodeInventaire, DDossier, oleDbTrans)
        End Sub
#End Region

    End Class
End Namespace
