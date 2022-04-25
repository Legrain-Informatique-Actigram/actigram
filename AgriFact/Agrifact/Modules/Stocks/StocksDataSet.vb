Imports System.Data.SqlClient

Partial Class StocksDataSet

    Partial Class MouvementDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New StocksDataSetTableAdapters.MouvementTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As StocksDataSetTableAdapters.MouvementTA)
            Me.nMouvementColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

    Partial Class Mouvement_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New StocksDataSetTableAdapters.Mouvement_DetailTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As StocksDataSetTableAdapters.Mouvement_DetailTA)
            Me.nMouvementDetailColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

End Class

Namespace StocksDataSetTableAdapters
    Partial Class ListeChoixTA
        Public Enum NomsChoix
            FormeJuridique
            ListeBanque
            ListeDepots
            ListeModeReglement
            ListeTypeFacturation
            ListeTypeMouvement
            ListeUnite
        End Enum

        Public Overloads Sub FillByNomChoix(ByVal dt As StocksDataSet.ListeChoixDataTable, ByVal nomChoix As NomsChoix)
            FillByNomChoix(dt, nomChoix.ToString)
        End Sub

        Public Overloads Function GetDataByNomChoix(ByVal nomChoix As NomsChoix) As StocksDataSet.ListeChoixDataTable
            Return GetDataByNomChoix(nomChoix.ToString)
        End Function
    End Class

    Partial Class MouvementTA
        Public Sub DeleteMouvements(ByVal mouvementDT As StocksDataSet.MouvementDataTable)
            Dim drDeleted() As DataRow = mouvementDT.Select("", "", DataViewRowState.Deleted)

            If drDeleted.Length = 0 Then Exit Sub

            For Each dr As DataRow In drDeleted
                Dim nMouvement As Integer = CInt(dr.Item("nMouvement", DataRowVersion.Original))

                If nMouvement <= 0 Then Continue For

                Me.DeleteBynMouvement(nMouvement)

                dr.AcceptChanges()
            Next
        End Sub
    End Class

    Partial Class LotTA
        Public Sub DeleteLots(ByVal lotDT As StocksDataSet.LotDataTable)
            Dim drDeleted() As DataRow = lotDT.Select("", "", DataViewRowState.Deleted)

            If drDeleted.Length = 0 Then Exit Sub

            For Each dr As DataRow In drDeleted
                Dim nLot As String = dr.Item("nLot", DataRowVersion.Original).ToString()

                If nLot = String.Empty Then Continue For

                Me.DeleteQuery(nLot)
            Next
        End Sub
    End Class

    Partial Public Class LotProduitTableAdapter
        Public Sub SetTransaction(ByVal sqlTrans As SqlTransaction)
            Me.Connection = sqlTrans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = sqlTrans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = sqlTrans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = sqlTrans
            End If
            For Each sqlCommand As SqlCommand In Me.CommandCollection
                If sqlCommand IsNot Nothing Then
                    sqlCommand.Transaction = sqlTrans
                End If
            Next
        End Sub
    End Class
End Namespace