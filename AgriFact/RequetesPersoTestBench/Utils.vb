Public Class CommandParam
    Public Name As String
    Public Value As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal arg As String)
        Dim c As CommandParam = Parse(arg)
        Me.Name = c.Name
        Me.Value = c.Value
    End Sub

    Public Shared Function Parse(ByVal arg As String) As CommandParam
        Dim c As New CommandParam
        If arg.IndexOf("=") >= 0 Then
            c.Name = arg.Substring(0, arg.IndexOf("=")).ToLower
            c.Value = arg.Substring(arg.IndexOf("=") + 1).Replace(Chr(34), "")
        Else
            c.Name = arg.ToLower
            c.Value = ""
        End If
        c.Name = c.Name.Replace("/"c, "-"c)
        Return c
    End Function

    Public Shared Function Parse(ByVal args As Collections.ObjectModel.ReadOnlyCollection(Of String)) As List(Of CommandParam)
        Dim res As New List(Of CommandParam)
        For Each arg As String In args
            res.Add(Parse(arg))
        Next
        Return res
    End Function

End Class