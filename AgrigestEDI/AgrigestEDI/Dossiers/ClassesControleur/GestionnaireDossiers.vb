Imports System.Data.OleDb

Namespace Dossiers.ClassesControleur
    Public Class GestionnaireDossiers

        Private _DAODossiers As Dossiers.ClassesTechniques.DAODossiers

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAODossiers = New Dossiers.ClassesTechniques.DAODossiers(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetDossier(ByVal DDossier As String) As Dossiers.ClassesMetier.Dossiers
            Return Me._DAODossiers.GetDossier(DDossier)
        End Function

        Public Function GetListeDossiers(ByVal DExpl As String) As Dossiers.ClassesMetier.ListeDossiers
            Return Me._DAODossiers.GetListeDossiers(DExpl)
        End Function

        Public Function GetDDossierPrecedent(ByVal dossier_EnCours As Dossiers.ClassesMetier.Dossiers) As String
            Return Me._DAODossiers.GetDDossierPrecedent(dossier_EnCours)
        End Function

        Public Sub UpdateDMethodeInventaire(ByVal DMethodeInventaire As String, _
                                            ByVal DDossier As String, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAODossiers.UpdateDMethodeInventaire(DMethodeInventaire, DDossier, oleDbTrans)
        End Sub

        Public Sub UpdateDDtClotureTVA(ByVal DDtClotureTVA As Date, _
                                            ByVal DDossier As String, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAODossiers.UpdateDDtClotureTVA(DDtClotureTVA, DDossier, oleDbTrans)
        End Sub
#End Region

    End Class
End Namespace
