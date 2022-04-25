Imports System.Data.OleDb

Namespace Inventaire.ClassesControleur
    Public Class GestionnaireInventaireLignes

        Private _DAOInventaireLignes As Inventaire.ClassesTechniques.DAOInventaireLignes

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOInventaireLignes = New Inventaire.ClassesTechniques.DAOInventaireLignes(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInventaireLignes(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                        ByVal INVLLig As Integer) As Inventaire.ClassesMetier.InventaireLignes
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = Nothing

            invLignes = Me._DAOInventaireLignes.GetInventaireLignes(INVLDossier, INVLCode, INVLLig)

            Return invLignes
        End Function

        Public Function GetInventaireLignes(ByVal invLignesDR As DataSetAgrigest.InventaireLignesRow) As Inventaire.ClassesMetier.InventaireLignes
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = Nothing

            invLignes = Me._DAOInventaireLignes.GetInventaireLignes(invLignesDR)

            Return invLignes
        End Function

        Public Sub DeleteInventaireLignes(ByVal invListes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAOInventaireLignes.DeleteInventaireLignes(invListes, oleDbTrans)
        End Sub

        Public Sub InsertInventaireLignes(ByVal invLignes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAOInventaireLignes.InsertInventaireLignes(invLignes, oleDbTrans)
        End Sub

        Public Sub UpdateInventaireLignes(ByVal invLignes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAOInventaireLignes.UpdateInventaireLignes(invLignes, oleDbTrans)
        End Sub

        Public Function MaxINVLOrdre(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Return Me._DAOInventaireLignes.MaxINVLOrdre(INVLDossier, INVLCode, oleDbTrans)
        End Function

        Public Function MaxINVLLig(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Return Me._DAOInventaireLignes.MaxINVLLig(INVLDossier, INVLCode, oleDbTrans)
        End Function

        Public Function GetListeInventairesLignes(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) _
                                                As Inventaire.ClassesMetier.ListeInventairesLignes

            Return Me._DAOInventaireLignes.GetListeInventairesLignes(INVLDossier, INVLCode, oleDbTrans)
        End Function

        Public Sub UpdateListeInventairesLignes(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes, _
                                                    ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            'Récupération de la liste des lignes pour le dossier et le code
            Dim listeInvLignesDansBDD As Inventaire.ClassesMetier.ListeInventairesLignes = Me.GetListeInventairesLignes(INVLDossier, INVLCode)

            'Suppression des lignes présentes dans la BDD et non présentes dans la liste passée en paramètre
            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignesDansBDD
                Dim existe As Boolean = False

                'Vérifie si le groupe est présent dans la liste passée en paramètre 
                'et dans la base de données
                existe = Inventaire.ClassesControleur.GestionnaireInventaireLignes.InventaireLignesExisteDansListe(listeInvLignes, invLignes)

                'Si la ligne n'existe pas dans la liste passée en paramètre mais 
                'existe dans la base de données, on la supprime de la base de données
                If Not (existe) Then
                    Me.DeleteInventaireLignes(invLignes, oleDbTrans)
                End If
            Next

            'Ajout ou modification des lignes
            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                'Ajout des nouvelles lignes
                If String.IsNullOrEmpty(invLignes.INVLDossier) Then
                    invLignes.INVLDossier = INVLDossier
                    invLignes.INVLCode = CInt(INVLCode)
                    invLignes.INVLLig = Me.MaxINVLLig(INVLDossier, INVLCode, oleDbTrans) + 1

                    Me.InsertInventaireLignes(invLignes, oleDbTrans)
                Else 'Modification des groupes
                    Me.UpdateInventaireLignes(invLignes, oleDbTrans)
                End If
            Next
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Function InventaireLignesExisteDansListe(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes, _
                                                               ByVal invLignes As Inventaire.ClassesMetier.InventaireLignes) As Boolean

            For Each ig As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                If ((ig.INVLDossier = invLignes.INVLDossier) And (ig.INVLCode = invLignes.INVLCode) And (ig.INVLLig = invLignes.INVLLig)) Then
                    Return True
                End If
            Next

            Return False
        End Function

        Public Shared Function GetTotalGeneralValeurHT(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.ValeurHT)
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsParHaMethodeDetaillee(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.CoutParHaMethodeDetaillee)
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsParHaMethodeForfaitaire(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.CoutParHaMethodeForfaitaire)
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsFaconsCulturalesMethodeDetaillee(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.CoutTotalFaconsCulturalesMethodeDetaillee)
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsFaconsCulturalesMethodeForfaitaire(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.CoutTotalFaconsCulturalesMethodeForfaitaire)
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralValeurHTAvAuxCultures(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes) As Decimal
            Dim total As Decimal = 0

            For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                total = total + CDec(invLignes.ValeurHTAvAuxCultures)
            Next

            Return total
        End Function
#End Region

    End Class
End Namespace
