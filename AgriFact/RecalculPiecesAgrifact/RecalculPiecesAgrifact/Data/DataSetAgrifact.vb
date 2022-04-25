Imports System.Data.SqlClient

Partial Class DataSetAgrifact
End Class

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VFactureTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VFacture_DetailTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VBonCommandeTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VBonCommande_DetailTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VBonLivraisonTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VBonLivraison_DetailTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VDevisTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace

Namespace DataSetAgrifactTableAdapters
    
    Partial Public Class VDevis_DetailTableAdapter

        Public Sub SetTransaction(ByVal trans As SqlTransaction)
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
            For Each cmd As SqlCommand In Me.CommandCollection
                If cmd IsNot Nothing Then
                    cmd.Transaction = trans
                End If
            Next
        End Sub

    End Class
End Namespace
