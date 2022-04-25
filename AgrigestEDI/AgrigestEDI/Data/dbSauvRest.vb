Namespace dbSauvRestTableAdapters
    Partial Public Class PiecesTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property

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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

    Partial Public Class ImmobilisationsTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

    Partial Public Class InventaireGroupesTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

    Partial Public Class InventaireLignesTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

    Partial Public Class EmpruntGroupesTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

    Partial Public Class EmpruntLignesTableAdapter
        Public ReadOnly Property GetDataAdapter() As Data.OleDb.OleDbDataAdapter
            Get
                Return Me.Adapter
            End Get
        End Property
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

Partial Public Class dbSauvRest
    Partial Class PlanComptableDataTable

        Public Function FindMouvsByCptAndActi(ByVal cpt As String, ByVal acti As String) As dbSauvRest.PlanComptableRow
            'Trouver en faisant un LIKE sur Acti
            Dim rws() As DataRow = Me.Select(String.Format("PlCpt='{0}' AND PlActi='{1}'", cpt, acti), "PlActi DESC")
            If rws.Length > 0 Then
                Return DirectCast(rws(0), dbSauvRest.PlanComptableRow)
            End If
            Return Nothing
        End Function
    End Class

    Partial Class PiecesDataTable

        Public Function FindLastNumPiece(ByVal sDossier As String) As Integer
            If IsDBNull(Me.Compute("Max(PPiece)", String.Format("PDossier='{0}'", sDossier))) Then
                Return 0
            Else
                Return CType(Me.Compute("Max(PPiece)", String.Format("PDossier='{0}'", sDossier)), Nullable(Of Integer)).GetValueOrDefault(0)
            End If
        End Function
    End Class

End Class
