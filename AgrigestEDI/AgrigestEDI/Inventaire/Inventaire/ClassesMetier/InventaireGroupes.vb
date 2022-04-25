Imports System.Data.OleDb

Namespace Inventaire.ClassesMetier
    Public Class InventaireGroupes

        Private _INVGDossier As String
        Private _INVGCode As Integer
        Private _INVGTypeInventaire As String
        Private _INVGLib As String
        Private _INVGOrdre As Nullable(Of Integer)
        Private _INVGCpt As String
        Private _INVGActi As String
        Private _INVGDecote As Nullable(Of Decimal)
        Private _INVGUnite As String
        Private _INVGEstControle As Nullable(Of Boolean)

        'Info type d'inventaire
        Private _TypeInventaire As Inventaire.ClassesMetier.TypeInventaire

        'Info lignes
        Private _ListeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes

        'Infos complémentaires
        Private _TotalValeurHTLignes As Decimal
        Private _TotalCoutParHaLignesMethodeDetaillee As Decimal
        Private _TotalCoutParHaLignesMethodeForfaitaire As Decimal
        Private _TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes As Decimal
        Private _TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes As Decimal
        Private _TotalValeurHTAvAuxCulturesLignes As Decimal

#Region "Propriétés"
        Public Property INVGDossier() As String
            Get
                Return _INVGDossier
            End Get
            Set(ByVal value As String)
                _INVGDossier = value
            End Set
        End Property

        Public Property INVGCode() As Integer
            Get
                Return _INVGCode
            End Get
            Set(ByVal value As Integer)
                _INVGCode = value
            End Set
        End Property

        Public Property INVGTypeInventaire() As String
            Get
                Return _INVGTypeInventaire
            End Get
            Set(ByVal value As String)
                _INVGTypeInventaire = value
            End Set
        End Property

        Public Property INVGLib() As String
            Get
                Return Me._INVGLib
            End Get
            Set(ByVal value As String)
                Me._INVGLib = Microsoft.VisualBasic.Left(value, 50)
            End Set
        End Property

        Public Property INVGOrdre() As Nullable(Of Integer)
            Get
                Return _INVGOrdre
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _INVGOrdre = value
            End Set
        End Property

        Public Property INVGCpt() As String
            Get
                Return _INVGCpt
            End Get
            Set(ByVal value As String)
                _INVGCpt = value
            End Set
        End Property

        Public Property INVGActi() As String
            Get
                Return _INVGActi
            End Get
            Set(ByVal value As String)
                _INVGActi = value
            End Set
        End Property

        Public Property INVGDecote() As Nullable(Of Decimal)
            Get
                Return _INVGDecote
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVGDecote = value
            End Set
        End Property

        Public Property INVGUnite() As String
            Get
                Return _INVGUnite
            End Get
            Set(ByVal value As String)
                Me._INVGUnite = Microsoft.VisualBasic.Left(value, 2)
            End Set
        End Property

        Public Property INVGEstControle() As Nullable(Of Boolean)
            Get
                Return _INVGEstControle
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _INVGEstControle = value
            End Set
        End Property

        Public Property TypeInventaire() As Inventaire.ClassesMetier.TypeInventaire
            Get
                Return Me._TypeInventaire
            End Get
            Set(ByVal value As Inventaire.ClassesMetier.TypeInventaire)
                Me._TypeInventaire = value
            End Set
        End Property

        Public ReadOnly Property LibelleTypeInventaire() As String
            Get
                If Not (Me._TypeInventaire Is Nothing) Then
                    Return Me._TypeInventaire.LibelleTypeInventaire
                End If

                Return String.Empty
            End Get
        End Property

        Public Property ListeInvLignes() As Inventaire.ClassesMetier.ListeInventairesLignes
            Get
                Return _ListeInvLignes
            End Get
            Set(ByVal value As Inventaire.ClassesMetier.ListeInventairesLignes)
                _ListeInvLignes = value
            End Set
        End Property

        Public ReadOnly Property TotalValeurHTLignes() As Decimal
            Get
                Return Me._TotalValeurHTLignes
            End Get
        End Property

        Public ReadOnly Property TotalCoutParHaLignesMethodeDetaillee() As Decimal
            Get
                Return Me._TotalCoutParHaLignesMethodeDetaillee
            End Get
        End Property

        Public ReadOnly Property TotalCoutParHaLignesMethodeForfaitaire() As Decimal
            Get
                Return Me._TotalCoutParHaLignesMethodeForfaitaire
            End Get
        End Property

        Public ReadOnly Property TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes() As Decimal
            Get
                Return Me._TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes
            End Get
        End Property

        Public ReadOnly Property TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes() As Decimal
            Get
                Return Me._TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes
            End Get
        End Property

        Public ReadOnly Property TotalValeurHTAvAuxCulturesLignes() As Decimal
            Get
                Return Me._TotalValeurHTAvAuxCulturesLignes
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            Me._ListeInvLignes = New Inventaire.ClassesMetier.ListeInventairesLignes
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub ValoriserDecoteLignes()
            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                invLigne.Decote = Me._INVGDecote
            Next
        End Sub

        Public Sub ValoriserValeurHTLignes()
            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                invLigne.CalculerValeurHT()
            Next
        End Sub

        Public Sub CalculerTotalValeurHTLignes()
            Dim total As Decimal = 0

            'Valorisation de la décôte pour chaque ligne
            Me.ValoriserDecoteLignes()

            'calcul de la valeur HT de chaque ligne
            Me.ValoriserValeurHTLignes()

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                total = total + CDec(invLigne.ValeurHT)
            Next

            Me._TotalValeurHTLignes = total
        End Sub

        Public Sub CalculerTotalCoutParHaMethodeDetailleeLignes()
            Dim total As Decimal = 0

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                If (invLigne.CoutParHaMethodeDetaillee.HasValue) Then
                    total = total + CDec(invLigne.CoutParHaMethodeDetaillee)
                End If
            Next

            Me._TotalCoutParHaLignesMethodeDetaillee = total
        End Sub

        Public Sub CalculerTotalCoutParHaMethodeForfaitaireLignes()
            Dim total As Decimal = 0

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                If (invLigne.CoutParHaMethodeForfaitaire.HasValue) Then
                    total = total + CDec(invLigne.CoutParHaMethodeForfaitaire)
                End If
            Next

            Me._TotalCoutParHaLignesMethodeForfaitaire = total
        End Sub

        Public Sub CalculerTotalCoutTotalFaconsCulturalesMethodeDetailleeLignes()
            Dim total As Decimal = 0

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                If (invLigne.CoutTotalFaconsCulturalesMethodeDetaillee.HasValue) Then
                    total = total + CDec(invLigne.CoutTotalFaconsCulturalesMethodeDetaillee)
                End If
            Next

            Me._TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes = total
        End Sub

        Public Sub CalculerTotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes()
            Dim total As Decimal = 0

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                If (invLigne.CoutTotalFaconsCulturalesMethodeForfaitaire.HasValue) Then
                    total = total + CDec(invLigne.CoutTotalFaconsCulturalesMethodeForfaitaire)
                End If
            Next

            Me._TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes = total
        End Sub

        Public Sub CalculerTotalValeurHTAvAuxCulturesLignes()
            Dim valeurProduitsEnTerre As Decimal = 0
            Dim valeurFaconsCulturales As Decimal = 0
            Dim total As Decimal = 0

            For Each invLigne As Inventaire.ClassesMetier.InventaireLignes In Me._ListeInvLignes
                If (invLigne.INVLValPdtenTerre.HasValue) Then
                    total = total + CDec(invLigne.INVLValPdtenTerre)
                End If

                If (invLigne.INVLValFaconcult.HasValue) Then
                    total = total + CDec(invLigne.INVLValFaconcult)
                End If
            Next

            Me._TotalValeurHTAvAuxCulturesLignes = total
        End Sub

        Public Function Cloner() As Inventaire.ClassesMetier.InventaireGroupes
            Dim invGpes As New Inventaire.ClassesMetier.InventaireGroupes

            invGpes.INVGDossier = Me.INVGDossier
            invGpes.INVGCode = Me.INVGCode
            invGpes.INVGTypeInventaire = Me.INVGTypeInventaire
            invGpes.INVGLib = Me.INVGLib
            invGpes.INVGOrdre = Me.INVGOrdre
            invGpes.INVGCpt = Me.INVGCpt
            invGpes.INVGActi = Me.INVGActi
            invGpes.INVGDecote = Me.INVGDecote
            invGpes.INVGUnite = Me.INVGUnite
            invGpes.INVGEstControle = Me.INVGEstControle

            Return invGpes
        End Function
#End Region

    End Class
End Namespace
