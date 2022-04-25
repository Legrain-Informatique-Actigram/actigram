Public Class FrParamNV
    Public Property NumSession() As String
        Get
            Return ntxSession.Text
        End Get
        Set(ByVal value As String)
            ntxSession.Text = value
        End Set
    End Property


    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ConfigNumericControl(ntxSession)
        SetChildFormIcon(Me)
    End Sub
End Class

Public Class NetViewer
    Public Shared Sub StartNetViewer()
        Try
            Dim url As String = "http://www.netviewer.fr/joinsession/"
            Process.Start(url)
            'Dim url As String = "http://get.netviewer.com/support/_win/fr/binaries/"
            'Dim nomFic As String = "NV_Support_Participant_FR.exe"
            'Dim idSession As String
            'Using dlg As New FrParamNV
            '    If dlg.ShowDialog = DialogResult.Cancel Then Exit Sub
            '    idSession = dlg.NumSession
            'End Using
            'If idSession <> "" Then
            '    nomFic = String.Format("nvt_sinr{0}_sipwnv64_sitn.exe", idSession)
            'End If
            'url = url & nomFic
            'Cursor.Current = Cursors.WaitCursor
            'Application.DoEvents()
            'Dim fichier As String = IO.Path.Combine(IO.Path.GetTempPath, nomFic)
            'My.Computer.Network.DownloadFile(url, fichier)
            'Process.Start(fichier)
        Catch ex As Exception
            MsgBox("Erreur : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class