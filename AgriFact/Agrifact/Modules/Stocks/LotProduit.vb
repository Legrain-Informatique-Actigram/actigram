Imports System.Data.SqlClient

Namespace Stocks
    Public Class LotProduit

        Private _IdLotProduit As Integer
        Private _nLot As String
        Private _CodeProduit As String

        Private _LibelleProduit As String
        Private _AffichageInfosProduit As String

#Region "Propriétés"
        Public Property IdLotProduit() As Integer
            Get
                Return Me._IdLotProduit
            End Get
            Set(ByVal value As Integer)
                Me._IdLotProduit = value
            End Set
        End Property

        Public Property nLot() As String
            Get
                Return Me._nLot
            End Get
            Set(ByVal value As String)
                Me._nLot = value
            End Set
        End Property

        Public Property CodeProduit() As String
            Get
                Return Me._CodeProduit
            End Get
            Set(ByVal value As String)
                Me._CodeProduit = value
            End Set
        End Property

        Public Property LibelleProduit() As String
            Get
                Return Me._LibelleProduit
            End Get
            Set(ByVal value As String)
                Me._LibelleProduit = value
            End Set
        End Property

        Public Property AffichageInfosProduit() As String
            Get
                Return Me._AffichageInfosProduit
            End Get
            Set(ByVal value As String)
                Me._AffichageInfosProduit = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal idLotProduit As Integer)
            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                Dim lotProduitDT As StocksDataSet.LotProduitDataTable = lotProduitTA.GetDataByIdLotProduit(idLotProduit)

                For Each lotProduitDR As StocksDataSet.LotProduitRow In lotProduitDT.Rows
                    Me.IdLotProduit = lotProduitDR.IdLotProduit
                    Me.nLot = lotProduitDR.nLot
                    Me.CodeProduit = lotProduitDR.CodeProduit
                Next
            End Using

            'Récupération des infos produit
            Using ProduitTA As New StocksDataSetTableAdapters.ProduitTableAdapter
                Dim ProduitDT As StocksDataSet.ProduitDataTable = ProduitTA.GetDataByCodeProduit(Me.CodeProduit)

                If (ProduitDT.Rows.Count > 0) Then
                    Dim ProduitDR As StocksDataSet.ProduitRow = CType(ProduitDT.Rows(0), StocksDataSet.ProduitRow)

                    If Not (ProduitDR.IsLibelleNull) Then
                        Me.LibelleProduit = ProduitDR.Libelle
                        Me.AffichageInfosProduit = Me.CodeProduit & " " & ProduitDR.Libelle
                    Else
                        Me.LibelleProduit = String.Empty
                        Me.AffichageInfosProduit = Me.CodeProduit
                    End If
                End If
            End Using
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Sub SupprimerLotProduit(ByVal lotProduit As Stocks.LotProduit, _
                                            Optional ByVal sqlTrans As SqlTransaction = Nothing)

            'Suppression du produit associé au lot
            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                If Not (sqlTrans Is Nothing) Then
                    lotProduitTA.SetTransaction(sqlTrans)
                End If

                lotProduitTA.DeleteByIdLotProduit(lotProduit.IdLotProduit)
            End Using
        End Sub

        Public Shared Sub AjouterLotProduit(ByVal lotProduit As Stocks.LotProduit, _
                                            Optional ByVal sqlTrans As SqlTransaction = Nothing)

            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                If Not (sqlTrans Is Nothing) Then
                    lotProduitTA.SetTransaction(sqlTrans)
                End If

                lotProduitTA.Insert(lotProduit.nLot, lotProduit.CodeProduit, Now, Nothing)
            End Using
        End Sub

        Public Shared Sub ModifierLotProduit(ByVal lotProduit As Stocks.LotProduit, _
                                            Optional ByVal sqlTrans As SqlTransaction = Nothing)

            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                If Not (sqlTrans Is Nothing) Then
                    lotProduitTA.SetTransaction(sqlTrans)
                End If

                lotProduitTA.Modifier(lotProduit.nLot, lotProduit.CodeProduit, Now, lotProduit.IdLotProduit)
            End Using
        End Sub

        Public Shared Sub SupprimerLotsProduitsParnLot(ByVal nLot As String, _
                                            Optional ByVal sqlTrans As SqlTransaction = Nothing)

            Using lotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                If Not (sqlTrans Is Nothing) Then
                    lotProduitTA.SetTransaction(sqlTrans)
                End If

                lotProduitTA.DeleteBynLot(nLot)
            End Using
        End Sub
#End Region

    End Class
End Namespace
