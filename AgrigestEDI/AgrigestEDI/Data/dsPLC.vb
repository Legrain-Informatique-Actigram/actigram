Partial Class dsPLC

    Partial Class PlanTypeDataTable

        Private Sub PlanTypeDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.PlCptColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If
        End Sub

    End Class

    Partial Class ComptesDataTable
        Public Function CompteSel() As Integer
            Dim res As Integer = 0
            Dim o As Object = Me.Compute("Count(CCpt)", "CSelected=True")
            If o IsNot Nothing Then
                res = CInt(o)
            End If
            Return res
        End Function
    End Class

End Class

Namespace dsPLCTableAdapters
    Partial Class ActivitesTableAdapter
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

    Partial Class ComptesTableAdapter
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

    Partial Class PlanComptableTableAdapter
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

    Partial Class ModLignesTableAdapter
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

    Partial Class ModMouvementsTableAdapter
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
