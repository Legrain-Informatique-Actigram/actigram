Imports System.Data.OleDb

Namespace Inventaire.ClassesMetier
    Public Class InventaireLignes

        Private _INVLDossier As String
        Private _INVLCode As Integer
        Private _INVLLig As Integer
        Private _INVLLib As String
        Private _INVLQte As Nullable(Of Decimal)
        Private _INVLPrixUnit As Nullable(Of Decimal)
        Private _INVLCoutOutil As Nullable(Of Decimal)
        Private _INVLCoutTracteur As Nullable(Of Decimal)
        Private _INVLTempsH As Nullable(Of Integer)
        Private _INVLTempsMin As Nullable(Of Integer)
        Private _INVLNbHa As Nullable(Of Decimal)
        Private _INVLValPdtenTerre As Nullable(Of Decimal)
        Private _INVLValFaconcult As Nullable(Of Decimal)
        Private _INVLMtDeb As Nullable(Of Decimal)
        Private _INVLMtCre As Nullable(Of Decimal)
        Private _INVLOrdre As Nullable(Of Integer)
        Private _INVLValForfaitaire As Nullable(Of Decimal)
        Private _INVLNbPass As Nullable(Of Integer)

        Private _ValeurHT As Nullable(Of Decimal)
        Private _Decote As Nullable(Of Decimal)
        Private _CoutParHaMethodeDetaillee As Nullable(Of Decimal)
        Private _CoutParHaMethodeForfaitaire As Nullable(Of Decimal)
        Private _CoutTotalFaconsCulturalesMethodeDetaillee As Nullable(Of Decimal)
        Private _CoutTotalFaconsCulturalesMethodeForfaitaire As Nullable(Of Decimal)
        Private _ValeurHTAvAuxCultures As Nullable(Of Decimal)

#Region "Propriétés"
        Public Property INVLDossier() As String
            Get
                Return _INVLDossier
            End Get
            Set(ByVal value As String)
                _INVLDossier = value
            End Set
        End Property

        Public Property INVLCode() As Integer
            Get
                Return _INVLCode
            End Get
            Set(ByVal value As Integer)
                _INVLCode = value
            End Set
        End Property

        Public Property INVLLig() As Integer
            Get
                Return _INVLLig
            End Get
            Set(ByVal value As Integer)
                _INVLLig = value
            End Set
        End Property

        Public Property INVLLib() As String
            Get
                Return _INVLLib
            End Get
            Set(ByVal value As String)
                Me._INVLLib = Left(value, 50)
            End Set
        End Property

        Public Property INVLQte() As Nullable(Of Decimal)
            Get
                Return _INVLQte
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLQte = value
            End Set
        End Property

        Public Property INVLPrixUnit() As Nullable(Of Decimal)
            Get
                Return _INVLPrixUnit
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLPrixUnit = value
            End Set
        End Property

        Public Property INVLCoutOutil() As Nullable(Of Decimal)
            Get
                Return _INVLCoutOutil
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLCoutOutil = value
            End Set
        End Property

        Public Property INVLCoutTracteur() As Nullable(Of Decimal)
            Get
                Return _INVLCoutTracteur
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLCoutTracteur = value
            End Set
        End Property

        Public Property INVLTempsH() As Nullable(Of Integer)
            Get
                Return Me._INVLTempsH
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _INVLTempsH = value
            End Set
        End Property

        Public Property INVLTempsMin() As Nullable(Of Integer)
            Get
                Return Me._INVLTempsMin
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _INVLTempsMin = value
            End Set
        End Property

        Public Property INVLNbHa() As Nullable(Of Decimal)
            Get
                Return _INVLNbHa
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLNbHa = value
            End Set
        End Property

        Public Property INVLValPdtenTerre() As Nullable(Of Decimal)
            Get
                Return _INVLValPdtenTerre
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLValPdtenTerre = value
            End Set
        End Property

        Public Property INVLValFaconcult() As Nullable(Of Decimal)
            Get
                Return _INVLValFaconcult
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLValFaconcult = value
            End Set
        End Property

        Public Property INVLMtDeb() As Nullable(Of Decimal)
            Get
                Return _INVLMtDeb
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLMtDeb = value
            End Set
        End Property

        Public Property INVLMtCre() As Nullable(Of Decimal)
            Get
                Return _INVLMtCre
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLMtCre = value
            End Set
        End Property

        Public Property INVLOrdre() As Nullable(Of Integer)
            Get
                Return _INVLOrdre
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _INVLOrdre = value
            End Set
        End Property

        Public Property INVLValForfaitaire() As Nullable(Of Decimal)
            Get
                Return _INVLValForfaitaire
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _INVLValForfaitaire = value
            End Set
        End Property

        Public Property INVLNbPass() As Nullable(Of Integer)
            Get
                Return _INVLNbPass
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _INVLNbPass = value
            End Set
        End Property

        Public Property ValeurHT() As Nullable(Of Decimal)
            Get
                Return Me._ValeurHT
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._ValeurHT = value
            End Set
        End Property

        Public Property Decote() As Nullable(Of Decimal)
            Get
                Return Me._Decote
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._Decote = value
            End Set
        End Property

        Public Property CoutParHaMethodeDetaillee() As Nullable(Of Decimal)
            Get
                Return Me._CoutParHaMethodeDetaillee
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._CoutParHaMethodeDetaillee = value
            End Set
        End Property

        Public Property CoutParHaMethodeForfaitaire() As Nullable(Of Decimal)
            Get
                Return Me._CoutParHaMethodeForfaitaire
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._CoutParHaMethodeForfaitaire = value
            End Set
        End Property

        Public Property CoutTotalFaconsCulturalesMethodeDetaillee() As Nullable(Of Decimal)
            Get
                Return Me._CoutTotalFaconsCulturalesMethodeDetaillee
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._CoutTotalFaconsCulturalesMethodeDetaillee = value
            End Set
        End Property

        Public Property CoutTotalFaconsCulturalesMethodeForfaitaire() As Nullable(Of Decimal)
            Get
                Return Me._CoutTotalFaconsCulturalesMethodeForfaitaire
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._CoutTotalFaconsCulturalesMethodeForfaitaire = value
            End Set
        End Property

        Public Property ValeurHTAvAuxCultures() As Nullable(Of Decimal)
            Get
                Return Me._ValeurHTAvAuxCultures
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                Me._ValeurHTAvAuxCultures = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub CalculerValeurHT()
            Dim qte As Decimal = 0
            Dim prixUnitaire As Decimal = 0
            Dim decote As Decimal = 0

            If Not (Me._INVLQte.HasValue) Then
                qte = 0
            Else
                qte = CDec(Me._INVLQte)
            End If

            If Not (Me._INVLPrixUnit.HasValue) Then
                prixUnitaire = 0
            Else
                prixUnitaire = CDec(Me._INVLPrixUnit)
            End If

            If (Me._Decote.HasValue) Then
                decote = Convert.ToDecimal(Me._Decote) / 100
            End If

            Me._ValeurHT = qte * prixUnitaire - (qte * prixUnitaire * decote)
        End Sub

        Public Sub CalculerCoutParHaMethodeDetaillee()
            Dim coutTracteur As Decimal = 0
            Dim coutOutil As Decimal = 0
            Dim heures As Decimal = 0
            Dim minutes As Decimal = 0

            If (Me._INVLCoutTracteur.HasValue) Then
                coutTracteur = CDec(Me._INVLCoutTracteur)
            End If

            If (Me._INVLCoutOutil.HasValue) Then
                coutOutil = CDec(Me._INVLCoutOutil)
            End If

            If (Me._INVLTempsH.HasValue) Then
                heures = CDec(Me._INVLTempsH)
            End If

            If (Me._INVLTempsMin.HasValue) Then
                minutes = CDec(Me._INVLTempsMin)
            End If

            Me.CoutParHaMethodeDetaillee = (coutTracteur + coutOutil) * (heures + (minutes / 60))
        End Sub

        Public Sub CalculerCoutParHaMethodeForfaitaire()
            Dim valForfaitaire As Decimal = 0
            Dim nbPass As Integer = 0

            If (Me.INVLValForfaitaire.HasValue) Then
                valForfaitaire = CDec(Me.INVLValForfaitaire)
            End If

            If (Me.INVLNbPass.HasValue) Then
                nbPass = CInt(Me.INVLNbPass)
            End If

            Me.CoutParHaMethodeForfaitaire = valForfaitaire * nbPass
        End Sub

        Public Sub CalculerCoutTotalFaconsCulturalesMethodeDetaillee()
            Dim nbHa As Decimal = 0
            Dim coutParHa As Decimal = 0

            If (Me.INVLNbHa.HasValue) Then
                nbHa = CDec(Me.INVLNbHa)
            End If

            If (Me.CoutParHaMethodeDetaillee.HasValue) Then
                coutParHa = CDec(Me.CoutParHaMethodeDetaillee)
            End If

            Me.CoutTotalFaconsCulturalesMethodeDetaillee = nbHa * coutParHa
        End Sub

        Public Sub CalculerCoutTotalFaconsCulturalesMethodeForfaitaire()
            Dim nbHa As Decimal = 0
            Dim coutParHa As Decimal = 0

            If (Me.INVLNbHa.HasValue) Then
                nbHa = CDec(Me.INVLNbHa)
            End If

            If (Me.CoutParHaMethodeForfaitaire.HasValue) Then
                coutParHa = CDec(Me.CoutParHaMethodeForfaitaire)
            End If

            Me.CoutTotalFaconsCulturalesMethodeForfaitaire = nbHa * coutParHa
        End Sub

        Public Sub CalculerValeurHTAvAuxCultures()
            Dim valeurHTPdtEnTerre As Decimal = 0
            Dim valeurHTFaconsCulturales As Decimal = 0

            If Not (Me._INVLValPdtenTerre.HasValue) Then
                valeurHTPdtEnTerre = 0
            Else
                valeurHTPdtEnTerre = CDec(Me._INVLValPdtenTerre)
            End If

            If Not (Me._INVLValFaconcult.HasValue) Then
                valeurHTFaconsCulturales = 0
            Else
                valeurHTFaconsCulturales = CDec(Me._INVLValFaconcult)
            End If

            Me._ValeurHTAvAuxCultures = valeurHTPdtEnTerre + valeurHTFaconsCulturales
        End Sub

        Public Function Cloner() As Inventaire.ClassesMetier.InventaireLignes
            Dim invLignes As New Inventaire.ClassesMetier.InventaireLignes

            invLignes.INVLDossier = Me.INVLDossier
            invLignes.INVLCode = Me.INVLCode
            invLignes.INVLLig = Me.INVLLig
            invLignes.INVLLib = Me.INVLLib
            invLignes.INVLQte = Me.INVLQte
            invLignes.INVLPrixUnit = Me.INVLPrixUnit
            invLignes.INVLCoutOutil = Me.INVLCoutOutil
            invLignes.INVLCoutTracteur = Me.INVLCoutTracteur
            invLignes.INVLTempsH = Me.INVLTempsH
            invLignes.INVLTempsMin = Me.INVLTempsMin
            invLignes.INVLNbHa = Me.INVLNbHa
            invLignes.INVLValPdtenTerre = Me.INVLValPdtenTerre
            invLignes.INVLValFaconcult = Me.INVLValFaconcult
            invLignes.INVLMtDeb = Me.INVLMtDeb
            invLignes.INVLMtCre = Me.INVLMtCre
            invLignes.INVLOrdre = Me.INVLOrdre
            invLignes.INVLValForfaitaire = Me.INVLValForfaitaire
            invLignes.INVLNbPass = Me.INVLNbPass

            Return invLignes
        End Function
#End Region

    End Class
End Namespace
