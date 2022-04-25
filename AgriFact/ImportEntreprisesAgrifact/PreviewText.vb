Public Class PreviewText

    Public Shared Sub PreviewFile(ByVal fileName As String)
        With New PreviewText
            .TextBox1.Text = My.Computer.FileSystem.ReadAllText(fileName)
            .Show()
            .TextBox1.DeselectAll()
        End With
    End Sub

End Class