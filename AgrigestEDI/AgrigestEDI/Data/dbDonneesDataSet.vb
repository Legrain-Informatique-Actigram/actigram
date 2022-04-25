#Region "TableAdapters"
Namespace dbDonneesDataSetTableAdapters
    Partial Public Class PiecesTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class LignesTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class PlanComptableTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class ActivitesTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class ComptesTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class MouvementsTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class ExploitationsTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class DossiersTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class ModLignesTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class

    Partial Public Class ModMouvementsTableAdapter
        Public Sub SetTransaction(ByVal trans As OleDb.OleDbTransaction)
            Me.Connection = trans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = trans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = trans
            End If
            For Each cmd As OleDb.OleDbCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub
    End Class
End Namespace
#End Region

Partial Public Class dbDonneesDataSet
    Partial Class DossiersDataTable

    End Class

    Partial Class ReglesValidationDataTable

        Public Function VerifRatioHT(ByVal cpt As String, ByVal acti As String, ByVal montant As Nullable(Of Decimal), ByVal qt1 As Nullable(Of Decimal)) As Nullable(Of Boolean)
            Dim res As New Nullable(Of Boolean)
            'Trouver la ligne
            If montant.HasValue AndAlso qt1.HasValue Then
                Dim rw As dbDonneesDataSet.ReglesValidationRow = Me.FindByCptAndActi(cpt, acti)
                If rw IsNot Nothing Then
                    If Not rw.IsRatioHT1minNull Then
                        'Vérifier la fourchette
                        If qt1.Value = 0 Then
                            res = False
                        Else
                            Dim ratio As Decimal = montant.Value / qt1.Value
                            res = (ratio >= rw.RatioHT1min And ratio <= rw.RatioHT1Max)
                        End If
                    End If
                End If
            End If
            Return res
        End Function

        Public Function VerifRatioQt(ByVal cpt As String, ByVal acti As String, ByVal qt1 As Nullable(Of Decimal), ByVal qt2 As Nullable(Of Decimal)) As Nullable(Of Boolean)
            Dim res As New Nullable(Of Boolean)
            'Trouver la ligne
            If qt1.HasValue AndAlso qt2.HasValue Then
                Dim rw As dbDonneesDataSet.ReglesValidationRow = Me.FindByCptAndActi(cpt, acti)
                If rw IsNot Nothing Then
                    If Not rw.IsRatioQtminNull Then
                        'Vérifier la fourchette
                        If qt2.Value = 0 Then
                            res = False
                        Else
                            Dim ratio As Decimal = qt1.Value / qt2.Value
                            res = (ratio >= rw.RatioQtmin And ratio <= rw.RatioQtMax)
                        End If
                    End If
                End If
            End If
            Return res
        End Function

        Public Function FindByCptAndActi(ByVal cpt As String, ByVal acti As String) As dbDonneesDataSet.ReglesValidationRow
            'Trouver en faisant un LIKE sur Acti
            Dim rws() As DataRow = Me.Select(String.Format("Cpt='{0}' AND ('{1}' LIKE IIf(Acti is null,'',Acti)+'*')", cpt, acti), "Acti DESC")
            If rws.Length > 0 Then
                Return DirectCast(rws(0), dbDonneesDataSet.ReglesValidationRow)
            End If
            Return Nothing
        End Function


    End Class

End Class
