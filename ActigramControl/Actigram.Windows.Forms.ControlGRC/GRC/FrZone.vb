Public Class FrZone
    Inherits System.Windows.Forms.Form
    Dim ctl As Control
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Dim StopSaisi As Boolean = False


    Public Sub New(ByVal momCtl As Control)
        Me.New()
        ctl = momCtl
    End Sub

#Region " Code généré par le Concepteur Windows Form "
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
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
    Friend WithEvents RTx As System.Windows.Forms.TextBox
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RTx = New System.Windows.Forms.TextBox
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RTx
        '
        Me.RTx.AcceptsReturn = True
        Me.RTx.AcceptsTab = True
        Me.RTx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTx.Location = New System.Drawing.Point(0, 0)
        Me.RTx.Multiline = True
        Me.RTx.Name = "RTx"
        Me.RTx.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RTx.Size = New System.Drawing.Size(352, 211)
        Me.RTx.TabIndex = 0
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOK.Location = New System.Drawing.Point(189, 10)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 1
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(269, 10)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 2
        Me.BtCancel.Text = "Annuler"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtCancel)
        Me.GradientPanel2.Controls.Add(Me.BtOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 211)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(352, 39)
        Me.GradientPanel2.TabIndex = 19
        '
        'FrZone
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(352, 250)
        Me.Controls.Add(Me.RTx)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrZone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zoom"
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrZone_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ctl Is Nothing Then Exit Sub
        If TypeOf ctl Is Ctl Then
            Dim ct As Ctl = CType(ctl, Ctl)
            If ct.StopSaisi = True Or ct.StopSaisiAutorisation = True Then
                Me.StopSaisi = True
                'Me.RTx.ReadOnly = True
            End If
        End If
        With Me.RTx
            .Text = ctl.Text
            .SelectionLength = 0
            .SelectionStart = 0
        End With
    End Sub

    Private Sub RTx_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RTx.KeyPress
        If StopSaisi Then
            e.Handled = True
        End If
    End Sub

    Private Sub RTx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RTx.KeyDown
        If StopSaisi Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrZone_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ctl Is Nothing Then Exit Sub
        If Me.DialogResult = DialogResult.OK Then
            ctl.Text = Me.RTx.Text
        End If
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
