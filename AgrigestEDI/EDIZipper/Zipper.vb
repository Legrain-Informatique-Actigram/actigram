Public Class Zipper

    Public Shared Function ZipDirContent(ByVal path As String) As Integer
        If Not IO.Directory.Exists(path) Then
            MsgBox("Le dossier est introuvable", MsgBoxStyle.Exclamation)
            Return 0
        End If
        Dim res As Integer = 0
        For Each f As String In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, "*")
            res += ZipFile(f)
        Next
        Return res
    End Function

    Public Shared Function ZipFile(ByVal filename As String) As Integer
        If Not IO.File.Exists(filename) Then
            MsgBox("Le fichier est introuvable", MsgBoxStyle.Exclamation)
            Return 0
        End If
        If IO.Path.GetExtension(filename).ToLower = ".zip" Then Return 0
        Dim codeDossier As String = ""
        Dim f As String = IO.Path.GetFileNameWithoutExtension(filename)
        If f.Contains("-") Then
            codeDossier = f.Substring(0, f.IndexOf("-"))
        End If
        ZipFile(filename, GetPassword(codeDossier))
        Return 1
    End Function

    Private Shared Sub ZipFile(ByVal filePath As String, ByVal password As String)
        Dim dirName As String = IO.Path.GetDirectoryName(filePath)
        Dim fileName As String = IO.Path.GetFileName(filePath)
        Dim destFile As String = IO.Path.Combine(dirName, IO.Path.ChangeExtension(filePath, "zip"))
        Dim fz As New ICSharpCode.SharpZipLib.Zip.FastZip
        fz.Password = password
        fz.CreateZip(destFile, dirName, False, fileName)        
    End Sub

    Public Shared Function GetCle() As String
        Dim a As UInteger = &H5CAE980E
        Dim b As UShort = &HF009
        Dim c As UShort = &H43EC
        Dim d() As Byte = {&H88, &H84, &H58, &H1D, &H38, &HFC, &H0, &HD}
        'Dim g As New Guid(a, b, c, d(0), d(1), d(2), d(3), d(4), d(5), d(6), d(7))
        Return String.Format("{0:X4}{1:X4}", c, b)
    End Function

    Private Shared Function GetPassword(ByVal codeDossier As String) As String
        Return String.Format("{0}-{1}", codeDossier, GetCle)
    End Function

End Class
