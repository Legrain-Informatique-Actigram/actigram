Public Class ActigramProtocol
    Public Shared Sub CallApp(ByVal appName As String, ByVal args As Collections.Specialized.StringDictionary)
        Dim url As String = "actigram://" & appName
        If args.Count > 0 Then
            url &= "?"
            For Each name As String In args.Keys
                url = String.Format("{0}{1}={2}&", url, Uri.EscapeDataString(name), Uri.EscapeDataString(args(name)))
            Next
            url = url.Substring(0, url.Length - 1)
        End If
        Try
            Process.Start(url)
        Catch ex As Exception
            'On va dire que la seule exception possible est que le protocole ne soit pas enregistré
            If TryRegisteringProtocol() Then
                Try
                    Process.Start(url)
                Catch ex2 As Exception
                    MsgBox(ex2.Message, MsgBoxStyle.Exclamation)
                End Try
            Else
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End If
        End Try
    End Sub

    Private Shared Function TryRegisteringProtocol() As Boolean
        Dim mdadesktop As String = Dossier.Trouver("MdaDesktop.exe")
        If mdadesktop Is Nothing Then Return False
        If MsgBox("La liaison entre les logiciels Actigram n'est pas active, voulez-vous l'activer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return False
        Dim psi As New ProcessStartInfo()
        With psi
            .FileName = mdadesktop
            .Arguments = "-registerProtocol"
            .Verb = "runas"
            .UseShellExecute = True
        End With
        Try
            Dim p As Process = Process.Start(psi)
            p.WaitForExit()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
