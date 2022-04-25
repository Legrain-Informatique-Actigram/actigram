Imports System.Data.SqlClient

Namespace DsAgrifactTableAdapters
    Partial Public Class TelephoneEntrepriseTA

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


Partial Public Class DsAgrifact
End Class
