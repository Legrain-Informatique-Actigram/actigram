Imports System.Data.OleDb

Namespace Inventaire.ClassesControleur
    Public Class GestionnaireInventaireGroupes

        Private _DAOInventaireGroupes As Inventaire.ClassesTechniques.DAOInventaireGroupes

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._DAOInventaireGroupes = New Inventaire.ClassesTechniques.DAOInventaireGroupes(connString)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInventaireGroupes(ByVal INVGDossier As String, ByVal INVGCode As Integer) As Inventaire.ClassesMetier.InventaireGroupes
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = Nothing

            invGpes = Me._DAOInventaireGroupes.GetInventaireGroupes(INVGDossier, INVGCode)

            Return invGpes
        End Function

        Public Function GetInventaireGroupes(ByVal invGpesDR As DataSetAgrigest.InventaireGroupesRow) As Inventaire.ClassesMetier.InventaireGroupes
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = Nothing

            invGpes = Me._DAOInventaireGroupes.GetInventaireGroupes(invGpesDR)

            Return invGpes
        End Function

        Public Function InsertInventaireGroupes(ByVal invGpes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Me._DAOInventaireGroupes.InsertInventaireGroupes(invGpes, oleDbTrans)
        End Function

        Public Sub UpdateInventaireGroupes(ByVal invGpes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAOInventaireGroupes.UpdateInventaireGroupes(invGpes, oleDbTrans)
        End Sub

        Public Sub DeleteInventaireGroupes(ByVal invGpes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Me._DAOInventaireGroupes.DeleteInventaireGroupes(invGpes, oleDbTrans)
        End Sub

        Public Function MaxINVGCode(ByVal INVGDossier As String, _
                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Return Me._DAOInventaireGroupes.MaxINVGCode(INVGDossier, oleDbTrans)
        End Function

        Public Function MaxINVGOrdre(ByVal INVGDossier As String, ByVal INVGTypeInventaire As String, _
                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Return Me._DAOInventaireGroupes.MaxINVGOrdre(INVGDossier, INVGTypeInventaire, oleDbTrans)
        End Function

        Public Function GetListeInventairesGroupes(ByVal INVGDossier As String, ByVal INVGTypeInventaire As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Inventaire.ClassesMetier.ListeInventairesGroupes


            Return Me._DAOInventaireGroupes.GetListeInventairesGroupes(INVGDossier, INVGTypeInventaire, oleDbTrans)
        End Function

        Public Sub UpdateListeInventairesGroupes(ByVal listeInvGroupes As Inventaire.ClassesMetier.ListeInventairesGroupes, _
                                                    ByVal INVGDossier As String, ByVal INVGTypeInventaire As String, _
                                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            'Récupération de la liste des groupes pour le dossier et le type d'inventaire
            Dim listeInvGpesDansBDD As Inventaire.ClassesMetier.ListeInventairesGroupes = Me.GetListeInventairesGroupes(INVGDossier, INVGTypeInventaire)

            'Suppression des groupes présents dans la BDD et non présent dans la liste passée en paramètre
            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpesDansBDD
                Dim existe As Boolean = False

                'Vérifie si le groupe est présent dans la liste passée en paramètre 
                'et dans la base de données
                existe = Inventaire.ClassesControleur.GestionnaireInventaireGroupes.InventaireGroupesExisteDansListe(listeInvGroupes, invGpes)

                'Si le groupe n'existe pas dans la liste passée en paramètre mais 
                'existe dans la base de données, on le supprime de la base de données
                If Not (existe) Then
                    Me.DeleteInventaireGroupes(invGpes, oleDbTrans)
                End If
            Next

            'Ajout ou modification des groupes
            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGroupes
                'Ajout des nouveaux groupes
                If String.IsNullOrEmpty(invGpes.INVGDossier) Then
                    invGpes.INVGDossier = INVGDossier
                    invGpes.INVGCode = Me.MaxINVGCode(INVGDossier, oleDbTrans) + 1
                    invGpes.INVGTypeInventaire = INVGTypeInventaire

                    Me.InsertInventaireGroupes(invGpes, oleDbTrans)
                Else 'Modification des groupes
                    Me.UpdateInventaireGroupes(invGpes, oleDbTrans)
                End If
            Next
        End Sub

        Public Sub ReprendreDonneesDeDossierPrecedent(ByVal DDossierPrec As String, ByVal DDossierEnCours As String, _
                                    ByVal codeTypeInventaire As String, _
                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            Dim listeInvGpes As New Inventaire.ClassesMetier.ListeInventairesGroupes
            Dim gestInvLignes As New Inventaire.ClassesControleur.GestionnaireInventaireLignes(My.Settings.dbDonneesConnectionString)

            'Récupération des infos des groupes du dossier precedent 
            'et appartenant au même type d'inventaire
            listeInvGpes = Me.GetListeInventairesGroupes(DDossierPrec, codeTypeInventaire, oleDbTrans)

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                Dim listeInvLignes As New Inventaire.ClassesMetier.ListeInventairesLignes

                'Récupération des lignes associées au groupe du dossier precedent
                listeInvLignes = gestInvLignes.GetListeInventairesLignes(invGpes.INVGDossier, invGpes.INVGCode, oleDbTrans)

                'Affectation des infos du dossier en cours
                invGpes.INVGDossier = DDossierEnCours
                invGpes.INVGCode = Me.MaxINVGCode(DDossierEnCours) + 1

                'Ajout du groupe
                Me.InsertInventaireGroupes(invGpes, oleDbTrans)

                For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In listeInvLignes
                    invLignes.INVLDossier = invGpes.INVGDossier
                    invLignes.INVLCode = invGpes.INVGCode
                    invLignes.INVLLig = gestInvLignes.MaxINVLLig(invLignes.INVLDossier, invLignes.INVLCode) + 1

                    'ajout des lignes
                    gestInvLignes.InsertInventaireLignes(invLignes, oleDbTrans)
                Next
            Next
        End Sub

        Public Function DupliquerListeInventairesGroupes(ByVal listeInventaireGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Boolean
            Dim gestInvLignes As New Inventaire.ClassesControleur.GestionnaireInventaireLignes(My.Settings.dbDonneesConnectionString)

            Using oleDbConn As New OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim oleDbTrans As OleDbTransaction = Nothing

                Try
                    oleDbConn.Open()

                    oleDbTrans = oleDbConn.BeginTransaction

                    For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInventaireGpes
                        'Duplication du groupe
                        Dim invGpes_Nouveau As Inventaire.ClassesMetier.InventaireGroupes = invGpes.Cloner()

                        'Personnalisation du nouveau groupe
                        invGpes_Nouveau.INVGCode = Me.MaxINVGCode(invGpes.INVGDossier, oleDbTrans) + 1
                        invGpes_Nouveau.INVGOrdre = Me.MaxINVGOrdre(invGpes.INVGDossier, invGpes.INVGTypeInventaire, oleDbTrans) + 1
                        invGpes_Nouveau.INVGEstControle = False

                        'Insertion du nouveau groupe
                        Me.InsertInventaireGroupes(invGpes_Nouveau, oleDbTrans)

                        'Traitement des lignes associées au groupe
                        For Each invLignes As Inventaire.ClassesMetier.InventaireLignes In invGpes.ListeInvLignes
                            'Duplication de la ligne
                            Dim invLignes_Nouveau As Inventaire.ClassesMetier.InventaireLignes = invLignes.Cloner()

                            'Personnalisation de la nouvelle ligne
                            invLignes_Nouveau.INVLDossier = invGpes_Nouveau.INVGDossier
                            invLignes_Nouveau.INVLCode = invGpes_Nouveau.INVGCode
                            invLignes_Nouveau.INVLLig = gestInvLignes.MaxINVLLig(invGpes_Nouveau.INVGDossier, invGpes_Nouveau.INVGCode, oleDbTrans) + 1

                            'Insertion de la nouvelle ligne
                            gestInvLignes.InsertInventaireLignes(invLignes_Nouveau, oleDbTrans)
                        Next
                    Next

                    oleDbTrans.Commit()
                    oleDbTrans = Nothing

                    Return True
                Catch ex As Exception
                    If Not (oleDbTrans Is Nothing) Then oleDbTrans.Rollback()

                    Return False

                    Throw ex
                End Try
            End Using
        End Function
#End Region

#Region "Méthodes partagées"
        Public Shared Function InventaireGroupesExisteDansListe(ByVal listeInvGroupes As Inventaire.ClassesMetier.ListeInventairesGroupes, _
                                                       ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes) As Boolean

            For Each ig As Inventaire.ClassesMetier.InventaireGroupes In listeInvGroupes
                If ((ig.INVGDossier = invGroupes.INVGDossier) And (ig.INVGCode = invGroupes.INVGCode)) Then
                    Return True
                End If
            Next

            Return False
        End Function

        Public Shared Function GetTotalGeneralValeurHT(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalValeurHTLignes
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsParHaMethodeDetaillee(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalCoutParHaLignesMethodeDetaillee
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsParHaMethodeForfaitaire(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalCoutParHaLignesMethodeForfaitaire
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsFaconsCulturalesMethodeDetaillee(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralCoutsFaconsCulturalesMethodeForfaitaire(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes
            Next

            Return total
        End Function

        Public Shared Function GetTotalGeneralValeurHTAvAuxCultures(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes) As Decimal
            Dim total As Decimal = 0

            For Each invGpes As Inventaire.ClassesMetier.InventaireGroupes In listeInvGpes
                total = total + invGpes.TotalValeurHTAvAuxCulturesLignes
            Next

            Return total
        End Function
#End Region

    End Class
End Namespace
