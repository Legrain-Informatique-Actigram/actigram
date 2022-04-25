Public Class FrProgressBar

    Public Property Maximum() As Integer
        Get
            Return pgBar.Maximum
        End Get
        Set(ByVal value As Integer)
            pgBar.Maximum = value
        End Set
    End Property

    Public Property Value() As Integer
        Get
            Return pgBar.Value
        End Get
        Set(ByVal value As Integer)
            Dim v As Integer = Math.Min(value, Me.Maximum)
            pgBar.Value = v
        End Set
    End Property

    Private Sub FrProgressBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)
        Me.TopMost = True
        CenterToParent()
    End Sub

    Private Sub FrProgressBar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Me.gcStatus.Text = Me.Text
    End Sub

    Public Sub UpdateProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        With Me
            .Show()
            .Value = e.ProgressPercentage
            If e.UserState IsNot Nothing Then
                .Text = Convert.ToString(e.UserState) & "..."
            End If
            Application.DoEvents()
        End With
    End Sub
End Class