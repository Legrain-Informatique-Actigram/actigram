Public Class UltraVnc
    Public CheminVNC As String

    Private Const WIN_VNC As String = "WinVNC.exe"

    Private Shared _instance As UltraVnc
    Public Shared Function Instance() As UltraVnc
        If _instance Is Nothing Then
            _instance = New UltraVnc(My.Settings.CheminVNC)
        End If
        Return _instance
    End Function

    Private Sub New()

    End Sub

    Private Sub New(ByVal CheminVNC As String)
        Me.CheminVNC = CheminComplet(CheminVNC)
    End Sub

    Public Sub StopVNC()
        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            RunVNCCommand("-kill")
            MsgBox("La téléintervention est terminée")
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erreur")
        Finally
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Function StartVNC() As Boolean
        Using fr As New FrParamVNC
            If fr.ShowDialog = DialogResult.OK Then
                Return StartVNC(fr.AdresseVNC, fr.AdresseVNCID)
            Else
                Return False
            End If
        End Using
    End Function


    Public Function StartVNC(ByVal AdresseVNC As String, ByVal AdresseVNCID As Integer) As Boolean
        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            RunVNCCommand("-kill")
            RunVNCCommand("-run", 2000)
            RunVNCCommand(String.Format("-autoreconnect ID:{0} -connect {1}", AdresseVNCID, AdresseVNC))
            MsgBox("La téléintervention peut commencer")
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erreur")
            Return False
        Finally
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub RunVNCCommand(ByVal command As String, Optional ByVal exitTimeout As Integer = Integer.MaxValue)
        Dim pr As Process = Process.Start(IO.Path.Combine(CheminVNC, WIN_VNC), command)
        pr.WaitForExit(exitTimeout)
    End Sub
End Class