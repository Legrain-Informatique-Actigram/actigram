Imports System.Data.OleDb

Namespace DataSetAgrigestTableAdapters
    
    Partial Public Class InventaireGroupesTableAdapter
        Public Sub SetTransaction(ByVal oleDbTrans As OleDbTransaction)
            Me.Connection = oleDbTrans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = oleDbTrans
            End If
            For Each oleDbCommand As OleDbCommand In Me.CommandCollection
                If oleDbCommand IsNot Nothing Then
                    oleDbCommand.Transaction = oleDbTrans
                End If
            Next
        End Sub
    End Class
End Namespace

Namespace DataSetAgrigestTableAdapters
    
    Partial Public Class InventaireLignesTableAdapter
        Public Sub SetTransaction(ByVal oleDbTrans As OleDbTransaction)
            Me.Connection = oleDbTrans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = oleDbTrans
            End If
            For Each oleDbCommand As OleDbCommand In Me.CommandCollection
                If oleDbCommand IsNot Nothing Then
                    oleDbCommand.Transaction = oleDbTrans
                End If
            Next
        End Sub
    End Class
End Namespace

Namespace DataSetAgrigestTableAdapters

    Partial Public Class InventaireMaterielTableAdapter
        Public Sub SetTransaction(ByVal oleDbTrans As OleDbTransaction)
            Me.Connection = oleDbTrans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = oleDbTrans
            End If
            For Each oleDbCommand As OleDbCommand In Me.CommandCollection
                If oleDbCommand IsNot Nothing Then
                    oleDbCommand.Transaction = oleDbTrans
                End If
            Next
        End Sub
    End Class
End Namespace

Namespace DataSetAgrigestTableAdapters

    Partial Public Class DossiersTableAdapter
        Public Sub SetTransaction(ByVal oleDbTrans As OleDbTransaction)
            Me.Connection = oleDbTrans.Connection
            If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                Me.Adapter.InsertCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                Me.Adapter.DeleteCommand.Transaction = oleDbTrans
            End If
            If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                Me.Adapter.UpdateCommand.Transaction = oleDbTrans
            End If
            For Each oleDbCommand As OleDbCommand In Me.CommandCollection
                If oleDbCommand IsNot Nothing Then
                    oleDbCommand.Transaction = oleDbTrans
                End If
            Next
        End Sub
    End Class
End Namespace
Partial Class DataSetAgrigest
End Class
