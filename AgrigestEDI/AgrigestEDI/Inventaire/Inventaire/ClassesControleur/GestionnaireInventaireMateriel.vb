Imports System.Data.OleDb

Namespace Inventaire.ClassesControleur
    Public Class GestionnaireInventaireMateriel

        Private _DAOInventaireMateriel As Inventaire.ClassesTechniques.DAOInventaireMateriel

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOInventaireMateriel = New Inventaire.ClassesTechniques.DAOInventaireMateriel(connString)
        End Sub
#End Region

#Region "M�thodes diverses"
        Public Function GetInventaireMateriel(ByVal ID_InventaireMateriel As Integer) As Inventaire.ClassesMetier.InventaireMateriel
            Dim invMat As Inventaire.ClassesMetier.InventaireMateriel = Nothing

            invMat = Me._DAOInventaireMateriel.GetInventaireMateriel(ID_InventaireMateriel)

            Return invMat
        End Function

        Public Function ImporterInventaireMaterielDeDossierPrecedent(ByVal DDossierEnCours As String) As Integer
            'Recherche du dossier pr�c�dent
            Dim gestDoss As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
            Dim dossier_EnCours As Dossiers.ClassesMetier.Dossiers = gestDoss.GetDossier(DDossierEnCours)
            Dim DDossierPrec As String = gestDoss.GetDDossierPrecedent(dossier_EnCours)

            'Import des enregistrements du dossier pr�c�dent
            If Not (String.IsNullOrEmpty(DDossierPrec)) Then
                Return Me._DAOInventaireMateriel.ImporterInventaireMateriel(DDossierEnCours, DDossierPrec)
            Else
                Return 0
            End If
        End Function

        Public Function GetListeInventairesMateriel(ByVal DDossier As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) _
                                                As Inventaire.ClassesMetier.ListeInventairesMateriel

            Return Me._DAOInventaireMateriel.GetListeInventairesMateriel(DDossier, oleDbTrans)
        End Function
#End Region

    End Class
End Namespace
