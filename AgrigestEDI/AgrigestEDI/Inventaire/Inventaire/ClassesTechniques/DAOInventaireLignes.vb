Imports System.Data.OleDb

Namespace Inventaire.ClassesTechniques
    Public Class DAOInventaireLignes

        Private _ConnString As String = Nothing
        Private _InventaireLignesTA As DataSetAgrigestTableAdapters.InventaireLignesTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property InventaireLignesTA() As DataSetAgrigestTableAdapters.InventaireLignesTableAdapter
            Get
                Return Me._InventaireLignesTA
            End Get
            Set(ByVal value As DataSetAgrigestTableAdapters.InventaireLignesTableAdapter)
                Me._InventaireLignesTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._InventaireLignesTA = New DataSetAgrigestTableAdapters.InventaireLignesTableAdapter

            Me.InventaireLignesTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInventaireLignes(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                    ByVal INVLLig As Integer) As Inventaire.ClassesMetier.InventaireLignes
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = Nothing

            Dim invLignesDT As DataSetAgrigest.InventaireLignesDataTable = Me.InventaireLignesTA.GetDataByINVLDossierEtINVLCodeEtINVLLig(INVLDossier, INVLCode, INVLLig)

            If (invLignesDT.Rows.Count > 0) Then
                Dim invLignesDR As DataSetAgrigest.InventaireLignesRow = CType(invLignesDT.Rows(0), DataSetAgrigest.InventaireLignesRow)

                invLignes = Me.ValoriserInventaireLignes(invLignesDR)
            End If

            Return invLignes
        End Function

        Public Function GetInventaireLignes(ByVal invLignesDR As DataSetAgrigest.InventaireLignesRow) As Inventaire.ClassesMetier.InventaireLignes
            Return Me.ValoriserInventaireLignes(invLignesDR)
        End Function

        Public Sub DeleteInventaireLignes(ByVal invListes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)
            'Suppression des lignes
            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireLignesTA.DeleteByINVLDossier_INVLCode_INVLLig(invListes.INVLDossier, invListes.INVLCode, invListes.INVLLig)
        End Sub

        Public Sub InsertInventaireLignes(ByVal invLignes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireLignesTA.Insert(invLignes.INVLDossier, invLignes.INVLCode, invLignes.INVLLig, invLignes.INVLLib, _
                               invLignes.INVLQte, invLignes.INVLPrixUnit, invLignes.INVLCoutOutil, _
                               invLignes.INVLCoutTracteur, invLignes.INVLTempsH, invLignes.INVLTempsMin, _
                               invLignes.INVLNbHa, invLignes.INVLValPdtenTerre, invLignes.INVLValFaconcult, _
                               invLignes.INVLMtDeb, invLignes.INVLMtCre, invLignes.INVLOrdre, _
                               invLignes.INVLValForfaitaire, invLignes.INVLNbPass)
        End Sub

        Public Sub UpdateInventaireLignes(ByVal invLignes As Inventaire.ClassesMetier.InventaireLignes, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            Me.InventaireLignesTA.UpdateByINVLDossier_INVLCode_INVLLig(invLignes.INVLDossier, invLignes.INVLCode, invLignes.INVLLig, invLignes.INVLLib, _
                               invLignes.INVLQte, invLignes.INVLPrixUnit, invLignes.INVLCoutOutil, _
                               invLignes.INVLCoutTracteur, invLignes.INVLTempsH, invLignes.INVLTempsMin, _
                               invLignes.INVLNbHa, invLignes.INVLValPdtenTerre, invLignes.INVLValFaconcult, _
                               invLignes.INVLMtDeb, invLignes.INVLMtCre, invLignes.INVLOrdre, _
                               invLignes.INVLValForfaitaire, invLignes.INVLNbPass, _
                               invLignes.INVLDossier, invLignes.INVLCode, invLignes.INVLLig)
        End Sub

        Public Function MaxINVLLig(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Dim max As Integer = 0

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            If Not (IsDBNull(Me.InventaireLignesTA.MaxINVLLig(INVLDossier, CInt(INVLCode)))) Then
                max = CInt(Me.InventaireLignesTA.MaxINVLLig(INVLDossier, INVLCode))
            End If

            Return max
        End Function

        Public Function MaxINVLOrdre(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                    Optional ByVal oleDbTrans As OleDbTransaction = Nothing) As Integer

            Dim max As Integer = 0

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            If Not (IsDBNull(Me.InventaireLignesTA.MaxINVLLig(INVLDossier, CInt(INVLCode)))) Then
                max = CInt(Me.InventaireLignesTA.MaxINVLLig(INVLDossier, INVLCode))
            End If

            Return max
        End Function

        Public Function GetListeInventairesLignes(ByVal INVLDossier As String, ByVal INVLCode As Integer, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) _
                                                As Inventaire.ClassesMetier.ListeInventairesLignes

            Dim listeInvLig As New Inventaire.ClassesMetier.ListeInventairesLignes

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireLignesTA.SetTransaction(oleDbTrans)
            End If

            Dim invLignesDT As DataSetAgrigest.InventaireLignesDataTable = Me.InventaireLignesTA.GetDataByINVLDossierEtINVLCode(INVLDossier, INVLCode)

            For Each invLignesDR As DataSetAgrigest.InventaireLignesRow In invLignesDT.Rows
                Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = Me.GetInventaireLignes(invLignesDR)

                listeInvLig.Add(invLignes)
            Next

            Return listeInvLig
        End Function
#End Region

#Region "Méthodes internes"
        Private Function ValoriserInventaireLignes(ByVal invLignesDR As DataSetAgrigest.InventaireLignesRow) As Inventaire.ClassesMetier.InventaireLignes
            Dim invLignes As Inventaire.ClassesMetier.InventaireLignes = Nothing

            If Not (invLignesDR Is Nothing) Then
                invLignes = New Inventaire.ClassesMetier.InventaireLignes

                invLignes.INVLDossier = invLignesDR.INVLDossier
                invLignes.INVLCode = invLignesDR.INVLCode
                invLignes.INVLLig = invLignesDR.INVLLig

                If Not (invLignesDR.IsINVLLibNull) Then
                    invLignes.INVLLib = invLignesDR.INVLLib
                Else
                    invLignes.INVLLib = String.Empty
                End If

                If Not (invLignesDR.IsINVLQteNull) Then
                    invLignes.INVLQte = invLignesDR.INVLQte
                Else
                    invLignes.INVLQte = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLPrixUnitNull) Then
                    invLignes.INVLPrixUnit = invLignesDR.INVLPrixUnit
                Else
                    invLignes.INVLPrixUnit = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLCoutOutilNull) Then
                    invLignes.INVLCoutOutil = invLignesDR.INVLCoutOutil
                Else
                    invLignes.INVLCoutOutil = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLCoutTracteurNull) Then
                    invLignes.INVLCoutTracteur = invLignesDR.INVLCoutTracteur
                Else
                    invLignes.INVLCoutTracteur = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLTempsHNull) Then
                    invLignes.INVLTempsH = invLignesDR.INVLTempsH
                Else
                    invLignes.INVLTempsH = New Nullable(Of Integer)
                End If

                If Not (invLignesDR.IsINVLTempsMinNull) Then
                    invLignes.INVLTempsMin = invLignesDR.INVLTempsMin
                Else
                    invLignes.INVLTempsMin = New Nullable(Of Integer)
                End If

                If Not (invLignesDR.IsINVLNbHaNull) Then
                    invLignes.INVLNbHa = invLignesDR.INVLNbHa
                Else
                    invLignes.INVLNbHa = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLValPdtenTerreNull) Then
                    invLignes.INVLValPdtenTerre = invLignesDR.INVLValPdtenTerre
                Else
                    invLignes.INVLValPdtenTerre = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLValFaconcultNull) Then
                    invLignes.INVLValFaconcult = invLignesDR.INVLValFaconcult
                Else
                    invLignes.INVLValFaconcult = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLMtDebNull) Then
                    invLignes.INVLMtDeb = invLignesDR.INVLMtDeb
                Else
                    invLignes.INVLMtDeb = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLMtCreNull) Then
                    invLignes.INVLMtCre = invLignesDR.INVLMtCre
                Else
                    invLignes.INVLMtCre = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLOrdreNull) Then
                    invLignes.INVLOrdre = invLignesDR.INVLOrdre
                Else
                    invLignes.INVLOrdre = New Nullable(Of Integer)
                End If

                If Not (invLignesDR.IsINVLValForfaitaireNull) Then
                    invLignes.INVLValForfaitaire = invLignesDR.INVLValForfaitaire
                Else
                    invLignes.INVLValForfaitaire = New Nullable(Of Decimal)
                End If

                If Not (invLignesDR.IsINVLNbPassNull) Then
                    invLignes.INVLNbPass = invLignesDR.INVLNbPass
                Else
                    invLignes.INVLNbPass = New Nullable(Of Integer)
                End If

                'Calcul du coût par ha méthode détaillée
                invLignes.CalculerCoutParHaMethodeDetaillee()

                'Calcul du coût par ha méthode forfaitaire
                invLignes.CalculerCoutParHaMethodeForfaitaire()

                'Calcul du coût total façons culturales methode detaillée
                invLignes.CalculerCoutTotalFaconsCulturalesMethodeDetaillee()

                'Calcul du coût total façons culturales methode forfaitaire
                invLignes.CalculerCoutTotalFaconsCulturalesMethodeForfaitaire()

                'Calcul de la valeur HT Avances aux cultures
                invLignes.CalculerValeurHTAvAuxCultures()
            End If

            Return invLignes
        End Function
#End Region

    End Class
End Namespace
