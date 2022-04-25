Public Class FrProgressBar

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal Worker As System.ComponentModel.BackgroundWorker)
        Me.New()
        Me.Worker = Worker
    End Sub

    Private _worker As System.ComponentModel.BackgroundWorker
    Public Property Worker() As System.ComponentModel.BackgroundWorker
        Get
            Return _worker
        End Get
        Set(ByVal value As System.ComponentModel.BackgroundWorker)
            _worker = value
        End Set
    End Property

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
        BtAnnuler.Visible = False
        If Me.Worker IsNot Nothing AndAlso Me.Worker.WorkerReportsProgress Then
            AddHandler Worker.ProgressChanged, AddressOf UpdateProgress
            If Me.Worker.WorkerSupportsCancellation Then
                BtAnnuler.Visible = True
            End If
        End If
        If Not BtAnnuler.Visible Then Me.pgBar.Width = Me.BtAnnuler.Bounds.Right - Me.pgBar.Left
        SetChildFormIcon(Me)
        Me.TopMost = True
        CenterToParent()
    End Sub

    Private Sub FrProgressBar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.BtAnnuler.Visible Then
            Me.gcStatus.Select()
            Me.BtAnnuler.Active = False
        End If
    End Sub

    Private Sub FrProgressBar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Me.gcStatus.Text = Me.Text
        Application.DoEvents()
    End Sub

    Public Sub UpdateProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        UpdateProgress(e.ProgressPercentage, e.UserState)
    End Sub

    Public Sub UpdateProgress(ByVal percent As Integer, ByVal status As Object)
        With Me
            .Show()
            .Value = percent
            If status IsNot Nothing Then
                .Text = Convert.ToString(status) & "..."
            End If
            'Application.DoEvents()
        End With
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        If Me.Worker Is Nothing Then Exit Sub
        If Not Me.Worker.WorkerSupportsCancellation Then Exit Sub
        If Not Me.Worker.IsBusy Then Exit Sub
        If Me.Worker.CancellationPending Then Exit Sub
        Me.Worker.CancelAsync()
    End Sub
End Class