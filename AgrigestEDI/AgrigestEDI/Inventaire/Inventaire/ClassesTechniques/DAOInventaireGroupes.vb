Imports System.Data.OleDb

Namespace Inventaire.ClassesTechniques
    Public Class DAOInventaireGroupes

        Private _ConnString As String = Nothing
        Private _InventaireGroupesTA As DataSetAgrigestTableAdapters.InventaireGroupesTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property InventaireGroupesTA() As DataSetAgrigestTableAdapters.InventaireGroupesTableAdapter
            Get
                Return Me._InventaireGroupesTA
            End Get
            Set(ByVal value As DataSetAgrigestTableAdapters.InventaireGroupesTableAdapter)
                Me._InventaireGroupesTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._InventaireGroupesTA = New DataSetAgrigestTableAdapters.InventaireGroupesTableAdapter

            Me.InventaireGroupesTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInventaireGroupes(ByVal INVGDossier As String, ByVal INVGCode As Integer) As Inventaire.ClassesMetier.InventaireGroupes
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = Nothing

            Dim invGroupesDT As DataSetAgrigest.InventaireGroupesDataTable = Me.InventaireGroupesTA.GetDataByINVGDossierEtINVGCode(INVGDossier, INVGCode)

            If (invGroupesDT.Rows.Count > 0) Then
                Dim invGroupesDR As DataSetAgrigest.InventaireGroupesRow = CType(invGroupesDT.Rows(0), DataSetAgrigest.InventaireGroupesRow)

                invGpes = Me.ValoriserInventaireGroupes(invGroupesDR)
            End If

            Return invGpes
        End Function

        Public Function GetInventaireGroupes(ByVal invGroupesDR As DataSetAgrigest.InventaireGroupesRow) As Inventaire.ClassesMetier.InventaireGroupes
            Return Me.ValoriserInventaireGroupes(invGroupesDR)
        End Function

        Public Sub InsertInventaireGroupes(ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireGroupesTA.Insert(invGroupes.INVGDossier, invGroupes.INVGCode, invGroupes.INVGTypeInventaire, _
                                invGroupes.INVGLib, invGroupes.INVGOrdre, invGroupes.INVGCpt, _
                                invGroupes.INVGActi, invGroupes.INVGDecote, invGroupes.INVGUnite, _
                                CBool(invGroupes.INVGEstControle))
        End Sub

        Public Sub UpdateInventaireGroupes(ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireGroupesTA.UpdateByINVGDossier_INVGCode(invGroupes.INVGTypeInventaire, invGroupes.INVGLib, invGroupes.INVGOrdre, _
                                  invGroupes.INVGCpt, invGroupes.INVGActi, invGroupes.INVGDecote, _
                                  invGroupes.INVGUnite, CBool(invGroupes.INVGEstControle), _
                                  invGroupes.INVGDossier, invGroupes.INVGCode)
        End Sub

        Public Sub DeleteInventaireGroupes(ByVal invGroupes As Inventaire.ClassesMetier.InventaireGroupes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)
            'Suppression des lignes associées au groupe
            Using invLignesTA As New DataSetAgrigestTableAdapters.InventaireLignesTableAdapter
                invLignesTA.Connection.ConnectionString = Me.ConnString

                If Not (oleDbTrans Is Nothing) Then
                    invLignesTA.SetTransaction(oleDbTrans)
                End If

                invLignesTA.DeleteByINVLDossier_INVLCode(invGroupes.INVGDossier, invGroupes.INVGCode)
            End Using

            'Suppression du groupe
            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireGroupesTA.DeleteBy_INVGDossier_INVGCode(invGroupes.INVGDossier, invGroupes.INVGCode)
        End Sub

        Public Function MaxINVGCode(ByVal INVGDossier As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Dim max As Integer = 0

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            If Not (IsDBNull(Me.InventaireGroupesTA.MaxINVGCode(INVGDossier))) Then
                max = CInt(Me.InventaireGroupesTA.MaxINVGCode(INVGDossier))
            End If

            Return max
        End Function

        Public Function MaxINVGOrdre(ByVal INVGDossier As String, ByVal INVGTypeInventaire As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Dim max As Integer = 0

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            If Not (IsDBNull(Me.InventaireGroupesTA.MaxINVGOrdre(INVGDossier, INVGTypeInventaire))) Then
                max = CInt(Me.InventaireGroupesTA.MaxINVGOrdre(INVGDossier, INVGTypeInventaire))
            End If

            Return max
        End Function

        Public Function GetListeInventairesGroupes(ByVal INVGDossier As String, ByVal INVGTypeInventaire As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Inventaire.ClassesMetier.ListeInventairesGroupes

            Dim listeInvGpes As New Inventaire.ClassesMetier.ListeInventairesGroupes

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireGroupesTA.SetTransaction(oleDbTrans)
            End If

            Dim invGpesDT As DataSetAgrigest.InventaireGroupesDataTable = Me.InventaireGroupesTA.GetDataByINVGDossierEtINVGTypeInventaire(INVGDossier, INVGTypeInventaire)

            'Chargement des groupes
            For Each invGroupesDR As DataSetAgrigest.InventaireGroupesRow In invGpesDT.Rows
                Dim invGroupes As Inventaire.ClassesMetier.InventaireGroupes = Me.GetInventaireGroupes(invGroupesDR.INVGDossier, invGroupesDR.INVGCode)

                listeInvGpes.Add(invGroupes)
            Next

            Return listeInvGpes
        End Function
#End Region

#Region "Méthodes internes"
        Private Function ValoriserInventaireGroupes(ByVal invGroupesDR As DataSetAgrigest.InventaireGroupesRow) As Inventaire.ClassesMetier.InventaireGroupes
            Dim invGpes As Inventaire.ClassesMetier.InventaireGroupes = Nothing
            Dim gestInvLignes As New Inventaire.ClassesControleur.GestionnaireInventaireLignes(Me.ConnString)

            If Not (invGroupesDR Is Nothing) Then
                invGpes = New Inventaire.ClassesMetier.InventaireGroupes

                invGpes.INVGDossier = invGroupesDR.INVGDossier
                invGpes.INVGCode = invGroupesDR.INVGCode

                If Not (invGroupesDR.IsINVGTypeInventaireNull) Then
                    invGpes.INVGTypeInventaire = invGroupesDR.INVGTypeInventaire
                Else
                    invGpes.INVGTypeInventaire = String.Empty
                End If

                If Not (invGroupesDR.IsINVGLibNull) Then
                    invGpes.INVGLib = invGroupesDR.INVGLib
                Else
                    invGpes.INVGLib = String.Empty
                End If

                If Not (invGroupesDR.IsINVGOrdreNull) Then
                    invGpes.INVGOrdre = invGroupesDR.INVGOrdre
                Else
                    invGpes.INVGOrdre = New Nullable(Of Integer)
                End If

                If Not (invGroupesDR.IsINVGCptNull) Then
                    invGpes.INVGCpt = invGroupesDR.INVGCpt
                Else
                    invGpes.INVGCpt = String.Empty
                End If

                If Not (invGroupesDR.IsINVGActiNull) Then
                    invGpes.INVGActi = invGroupesDR.INVGActi
                Else
                    invGpes.INVGActi = String.Empty
                End If

                If Not (invGroupesDR.IsINVGDecoteNull) Then
                    invGpes.INVGDecote = invGroupesDR.INVGDecote
                Else
                    invGpes.INVGDecote = New Nullable(Of Decimal)
                End If

                If Not (invGroupesDR.IsINVGUniteNull) Then
                    invGpes.INVGUnite = invGroupesDR.INVGUnite
                Else
                    invGpes.INVGUnite = String.Empty
                End If

                If Not (invGroupesDR.IsINVGEstControleNull) Then
                    invGpes.INVGEstControle = invGroupesDR.INVGEstControle
                Else
                    invGpes.INVGEstControle = New Nullable(Of Boolean)
                End If

                'Chargement infos type inventaire
                If Not (invGroupesDR.IsINVGTypeInventaireNull) Then
                    Dim gestTypeInv As New Inventaire.ClassesControleur.GestionnaireTypeInventaire(My.Settings.dbDonneesConnectionString)

                    Dim typeInv As Inventaire.ClassesMetier.TypeInventaire = gestTypeInv.GetTypeInventaire(invGroupesDR.INVGTypeInventaire)

                    invGpes.TypeInventaire = typeInv
                End If

                'Chargement des infos des lignes associées au groupe
                invGpes.ListeInvLignes = gestInvLignes.GetListeInventairesLignes(invGpes.INVGDossier, invGpes.INVGCode)

                'Calcul du total des lignes
                invGpes.CalculerTotalValeurHTLignes()

                'Calcul du total coût par Ha des lignes methode detaillée
                invGpes.CalculerTotalCoutParHaMethodeDetailleeLignes()

                'Calcul du total coût par Ha des lignes methode forfaitaire
                invGpes.CalculerTotalCoutParHaMethodeForfaitaireLignes()

                'Calcul du total coût total façons culturales des lignes methode détaillée
                invGpes.CalculerTotalCoutTotalFaconsCulturalesMethodeDetailleeLignes()

                'Calcul du total coût total façons culturales des lignes methode Forfaitaire
                invGpes.CalculerTotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes()

                'Calcul du total de la valeur HT des lignes Avances aux cultures
                invGpes.CalculerTotalValeurHTAvAuxCulturesLignes()
            End If

            Return invGpes
        End Function
#End Region

    End Class
End Namespace
