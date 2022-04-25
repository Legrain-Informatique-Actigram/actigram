Module Main
    Public Sub Main()

        Dim doZip As Boolean = False
        Dim dir As String

        Dim args() As String = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            For Each arg As String In args
                Dim param As CommandParam = CommandParam.Parse(arg)
                Select Case param.Name
                    Case "-help"
                        MsgBox(Usage, MsgBoxStyle.Information)
                        Exit Sub
                    Case "-dir"
                        dir = param.Value
                        If Not IO.Directory.Exists(dir) Then dir = Nothing
                    Case "-auto"
                        doZip = True
                End Select
            Next
        End If

        If doZip AndAlso dir IsNot Nothing Then
            Dim res As Integer = Zipper.ZipDirContent(dir)
            MsgBox(res & " fichiers traités", MsgBoxStyle.Information)
        Else
            Dim fr As New FrMain
            If dir IsNot Nothing Then fr.Dir = dir
            Application.EnableVisualStyles()
            Application.Run(fr)
        End If
    End Sub

    Private Function Usage() As String
        Return "Parametres : " & vbCrLf & _
                vbTab & "-help : Instructions" & vbCrLf & _
                vbTab & "-dir=<CheminDossier> : Chemin du dossier dont les fichiers doivent être traités" & vbCrLf & _
                vbTab & "-auto : Traitement automatique"
    End Function

    Private Class CommandParam
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
                c.Value = arg.Substring(arg.IndexOf("=") + 1).Trim(Chr(34))
            Else
                c.Name = arg.ToLower
                c.Value = "True"
            End If
            Return c
        End Function
    End Class

End Module

