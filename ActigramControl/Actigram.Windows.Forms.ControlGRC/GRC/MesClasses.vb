Public Class TreeNodesFindText
    Shared Function FindText(ByVal myNodes As TreeNodeCollection, ByVal LibelleSearched As String) As Boolean
        Dim nd As TreeNode
        Dim ndFind As Boolean = False
        For Each nd In myNodes
            If nd.Text = LibelleSearched Then
                ndFind = True
                Exit For
            End If
        Next
        Return ndFind
    End Function
End Class

Public Class Autorisations
    Public Ajt As Boolean
    Public Modif As Boolean
    Public Suppr As Boolean
    Public Prep As Boolean
End Class

#Region "OLD"
'Public Class ListViewComparer
'    Implements IComparer

'    Private nCol As Integer
'    Private momsortOrder As SortOrder

'    Sub New(ByVal NumeroColonne As Integer, ByVal TriOrder As SortOrder)
'        nCol = NumeroColonne
'        momsortOrder = TriOrder
'    End Sub

'    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
'        Dim itX As ListViewItem = DirectCast(x, ListViewItem)
'        Dim itY As ListViewItem = DirectCast(y, ListViewItem)

'        Select Case momsortOrder
'            Case SortOrder.Ascending
'                Return String.Compare(itX.SubItems(nCol).Text, itY.SubItems(nCol).Text)
'            Case SortOrder.Descending
'                Return String.Compare(itY.SubItems(nCol).Text, itX.SubItems(nCol).Text)
'        End Select

'    End Function
'End Class

'Public Enum TypeParticipant
'    Entreprise
'    Contact
'End Enum

'Public Class ParticipantEv
'    Public Cle As Long
'    Public Type As TypeParticipant
'End Class

'Public Class LstParticipantEv
'    Inherits CollectionBase

'    Public Sub New()
'        MyBase.New()
'    End Sub

'    Public Sub Add(ByVal Participant As ParticipantEv)
'        Me.List.Add(Participant)
'    End Sub

'    Public Function Contains(ByVal Participant As ParticipantEv) As Boolean
'        Return Me.List.Contains(Participant)
'    End Function

'    Public Function GetIndex(ByVal Participant As ParticipantEv) As Integer
'        Return Me.List.IndexOf(Participant)
'    End Function

'    Public Function ToArray() As ParticipantEv()
'        Dim Lst(Me.List.Count - 1) As ParticipantEv
'        Dim i As Integer
'        For i = 0 To Me.List.Count - 1
'            Lst(i) = CType(Me.List.Item(i), ParticipantEv)
'        Next
'        Return Lst
'    End Function

'    Public Sub Remove(ByVal Participant As ParticipantEv)
'        Me.List.Remove(Participant)
'    End Sub

'    Public Sub RemoveAtIndex(ByVal Index As Integer)
'        Me.List.RemoveAt(Index)
'    End Sub

'End Class

'Public Class LstRows
'    Inherits CollectionBase

'    Public Sub New()

'    End Sub

'    Public Sub Add(ByVal rw As DataRow)
'        Me.List.Add(rw)
'    End Sub

'    Public Sub Remove(ByVal rw As DataRow)
'        Me.List.Remove(rw)
'    End Sub

'    Public Function ToRows() As DataRow()
'        Dim rw(Me.List.Count - 1) As DataRow
'        Dim i As Integer
'        For i = 0 To Me.List.Count - 1
'            rw(i) = CType(Me.List.Item(i), DataRow)
'        Next
'        Return rw
'    End Function

'End Class
'Public Class Explorer
'    Public Shared Sub Explorer(ByVal strChemin As String)
'        Try
'            Dim uri As New System.Uri(strChemin)
'            Process.Start(uri.ToString)
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'        End Try
'    End Sub

'End Class
#End Region