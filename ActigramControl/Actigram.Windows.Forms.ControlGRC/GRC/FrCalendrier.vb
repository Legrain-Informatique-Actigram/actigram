Public Class FrCalendrier
    Inherits System.Windows.Forms.Form
    Dim mysender As TextBox

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal momTextBox As TextBox, ByVal malocation As Point)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.Location = malocation
        mysender = momTextBox
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.MonthCalendar1.Margin = New System.Windows.Forms.Padding(0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'FrCalendrier
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(176, 152)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrCalendrier"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrCalendrier"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle = (parameters.ClassStyle Or &H20000)
            Return parameters
        End Get
    End Property

    Private Sub MonthCalendar1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCalendar1.LostFocus
        'Me.Dispose()
    End Sub

    Private Sub MonthCalendar1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MonthCalendar1.MouseUp
        If Me.MonthCalendar1.HitTest(e.X, e.Y).HitArea = MonthCalendar.HitArea.Date Then
            'If Not mysender.DataBindings("Text") Is Nothing Then
            '    mysender.DataBindings("Text").BindingManagerBase.EndCurrentEdit()
            'End If
            mysender.Text = Me.MonthCalendar1.SelectionStart.ToString("dd/MM/yyyy")
            'If Not mysender.DataBindings("Text") Is Nothing Then
            '    mysender.DataBindings("Text").BindingManagerBase.EndCurrentEdit()
            'End If
            Me.Dispose()
        End If
    End Sub

    Private Sub FrCalendrier_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        mysender.Focus()
        Me.Dispose()
    End Sub

    Private Sub FrCalendrier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Width = Me.MonthCalendar1.Width
        Me.Height = Me.MonthCalendar1.Height
    End Sub
End Class
