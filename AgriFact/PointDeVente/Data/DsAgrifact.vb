Partial Class DsAgrifact
    Partial Class ParametresDataTable
        Public Enum TypePiece
            [Default]
            VBonLivraison
            VBonCommande
            VDevis
            VFacture
            AFacture
            ABonReception
        End Enum

        Public Enum Cles
            EnTete
            EnTeteDetail
            PiedPageDetail
            InfoLegale
            InfoLegale2
            Logo
        End Enum
    End Class

    Partial Class JournalCaisseDataTable
        Public Enum TypeCaisse
            Fond
            Rentrée
            Vente
            Dépense
            Coffre
        End Enum

        Private Sub JournalCaisseDataTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanged
            If e.Column.ColumnName = "Type" Then
                e.Row.Item("LibType") = [Enum].GetName(GetType(TypeCaisse), CInt(e.ProposedValue))
            End If
        End Sub

        Public Sub InitLibType()
            For Each dr As DataRow In Me.Rows
                dr.Item("LibType") = [Enum].GetName(GetType(TypeCaisse), CInt(dr("Type")))
            Next
        End Sub

    End Class

    Partial Class ProduitDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.ProduitTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.ProduitTA)
            Me.nProduitColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nProduitColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class TarifDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.TarifTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.TarifTA)
            Me.nTarifColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nTarifColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class EntrepriseDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.EntrepriseTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.EntrepriseTA)
            Me.nEntrepriseColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nEntrepriseColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class VFacture_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.VFacture_DetailTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.VFacture_DetailTA)
            Me.nDetailDevisColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nDetailDevisColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class VFactureDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.VFactureTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.VFactureTA)
            Me.nDevisColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nDevisColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class ReglementDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.ReglementTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.ReglementTA)
            Me.nReglementColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nReglementColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class Reglement_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.Reglement_DetailTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.Reglement_DetailTA)
            Me.nDetailReglementColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nDetailReglementColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class FamilleDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.FamilleTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.FamilleTA)
            Me.nFamilleColumn.AutoIncrementSeed = SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nFamilleColumn.ColumnName) + 1
        End Sub
    End Class

    Partial Class TVADataTable
        Public Function GetTauxTVA(ByVal TTVA As String, Optional ByVal mode As TVARow.ModeTaux = TVARow.ModeTaux.HtToTva) As Nullable(Of Decimal)
            Dim dr As TVARow = SelectSingleRow(Of TVARow)(Me, FormatExpression("TTVA={0}", TTVA), "")
            If dr Is Nothing Then
                Return New Nullable(Of Decimal)
            Else
                Return dr.GetTauxTVA(mode)
            End If
        End Function
    End Class

    Partial Class TVARow
        Public Enum ModeTaux
            HtToTva
            HtToTtc
            TtcToTva
            TtcToHt
        End Enum

        Public Function GetTauxTVA(Optional ByVal mode As ModeTaux = ModeTaux.HtToTva) As Nullable(Of Decimal)
            If Me.IsTTauxNull Then
                Return New Nullable(Of Decimal)
            Else
                Dim tx As Decimal = Me.TTaux / 100
                Return TransformTaux(tx, mode)
            End If
        End Function

        Public Shared Function TransformTaux(ByVal tx As Decimal, ByVal mode As ModeTaux) As Decimal
            Select Case mode
                Case ModeTaux.HtToTva : Return tx
                Case ModeTaux.HtToTtc : Return (1 + tx)
                Case ModeTaux.TtcToHt : Return 1 / (1 + tx)
                Case ModeTaux.TtcToTva : Return tx / (1 + tx)
            End Select
        End Function
    End Class

End Class

Namespace DsAgrifactTableAdapters
    Partial Class ListeChoixTA
        Public Enum NomsChoix
            FormeJuridique
            ListeBanque
            ListeDepots
            ListeModeReglement
            ListeTypeFacturation
            ListeTypeMouvement
            ListeUnite
            ListeCibleCommercial
        End Enum

        Public Overloads Sub FillByNomChoix(ByVal dt As DsAgrifact.ListeChoixDataTable, ByVal nomChoix As NomsChoix)
            FillByNomChoix(dt, nomChoix.ToString)
        End Sub

        Public Overloads Function GetDataByNomChoix(ByVal nomChoix As NomsChoix) As DsAgrifact.ListeChoixDataTable
            Return GetDataByNomChoix(nomChoix.ToString)
        End Function
    End Class

    Partial Class VFactureTA
        Public ReadOnly Property PublicAdapter() As SqlClient.SqlDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
    End Class

    Partial Class VFacture_DetailTA
        Public ReadOnly Property PublicAdapter() As SqlClient.SqlDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
    End Class

    Partial Class EntrepriseTA
        Public Enum TypeClient
            Particulier
        End Enum

        Public Overloads Sub FillByTypeClient(ByVal dt As DsAgrifact.EntrepriseDataTable, ByVal typeClient As TypeClient)
            FillByTypeClient(dt, typeClient.ToString.ToUpper)
        End Sub

    End Class

    Partial Class ParametresTA
        Public Shared Function GetParametre(ByVal cle As DsAgrifact.ParametresDataTable.Cles, Optional ByVal piece As DsAgrifact.ParametresDataTable.TypePiece = DsAgrifact.ParametresDataTable.TypePiece.Default) As String
            Using dta As New ParametresTA
                Return dta.GetValeur(cle, piece)
            End Using
        End Function

        Public Function GetValeur(ByVal cle As DsAgrifact.ParametresDataTable.Cles, Optional ByVal piece As DsAgrifact.ParametresDataTable.TypePiece = DsAgrifact.ParametresDataTable.TypePiece.Default) As String
            If piece = DsAgrifact.ParametresDataTable.TypePiece.Default Then
                Return Me.GetDefaultValeurByCle(cle.ToString)
            Else
                Return Me.GetValeurByCleAndPiece(cle.ToString, piece.ToString)
            End If
        End Function
    End Class
End Namespace

Public Class RecapTVA

#Region " Props "
    Private _TTVA As String
    Public Property TTVA() As String
        Get
            Return _TTVA
        End Get
        Set(ByVal value As String)
            _TTVA = value
        End Set
    End Property


    Private _taux As Decimal
    Public Property Taux() As Decimal
        Get
            Return _taux
        End Get
        Set(ByVal value As Decimal)
            _taux = value
        End Set
    End Property


    Private _baseHT As Decimal
    Public Property BaseHT() As Decimal
        Get
            Return _baseHT
        End Get
        Set(ByVal value As Decimal)
            _baseHT = value
        End Set
    End Property


    Private _montantTVA As Decimal
    Public Property MontantTVA() As Decimal
        Get
            Return _montantTVA
        End Get
        Set(ByVal value As Decimal)
            _montantTVA = value
        End Set
    End Property


    Private _montantTTC As Decimal
    Public Property MontantTTC() As Decimal
        Get
            Return _montantTTC
        End Get
        Set(ByVal value As Decimal)
            _montantTTC = value
        End Set
    End Property
#End Region

#Region " Ctor "
    Public Sub New()

    End Sub

    Public Sub New(ByVal ds As DsAgrifact, ByVal ttva As String, Optional ByVal montantTTC As Decimal = 0)
        Me.New()
        Dim dr As DsAgrifact.TVARow = SelectSingleRow(Of DsAgrifact.TVARow)(ds.TVA, FormatExpression("TTVA={0}", ttva), "")
        Init(dr, montantTTC)
    End Sub

    Public Sub New(ByVal dr As DsAgrifact.TVARow, Optional ByVal montantTTC As Decimal = 0)
        Me.New()
        Init(dr, montantTTC)
    End Sub

    Private Sub Init(ByVal dr As DsAgrifact.TVARow, ByVal montantTTC As Decimal)
        If dr IsNot Nothing Then
            Me.TTVA = dr.TTVA
            Me.Taux = dr.GetTauxTVA(DsAgrifact.TVARow.ModeTaux.HtToTva).GetValueOrDefault
        End If
        CalculerFromTTC(montantTTC)
    End Sub
#End Region

    Public Sub CalculerFromTTC(ByVal montantTTC As Decimal)
        Me.MontantTTC = montantTTC
        Me.BaseHT = Decimal.Round(montantTTC * DsAgrifact.TVARow.TransformTaux(Me.Taux, DsAgrifact.TVARow.ModeTaux.TtcToHt), 2, MidpointRounding.AwayFromZero)
        Me.MontantTVA = Me.MontantTTC - Me.BaseHT
    End Sub

    Public Sub CalculerFromHT(ByVal montantHT As Decimal)
        Me.BaseHT = montantHT
        Me.MontantTTC = Decimal.Round(montantHT * DsAgrifact.TVARow.TransformTaux(Me.Taux, DsAgrifact.TVARow.ModeTaux.HtToTtc), 2, MidpointRounding.AwayFromZero)
        Me.MontantTVA = Me.MontantTTC - Me.BaseHT
    End Sub

    Public Sub AddMontantTTC(ByVal montantTTC As Decimal)
        montantTTC += Me.MontantTTC
        CalculerFromTTC(montantTTC)
    End Sub

    Public Sub AddMontantHT(ByVal montantHT As Decimal)
        montantHT += Me.BaseHT
        CalculerFromHT(montantHT)
    End Sub

End Class