<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrParamNV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Label1 As System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.ntxSession = New TextBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Label1 = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(30, 22)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(103, 13)
        Label1.TabIndex = 0
        Label1.Text = "Num�ro de session :"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(78, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(151, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.ntxSession)
        Me.GradientPanel1.Controls.Add(Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(230, 67)
        Me.GradientPanel1.TabIndex = 18
        '
        'ntxSession
        '
        Me.ntxSession.Location = New System.Drawing.Point(139, 18)
        Me.ntxSession.MaxLength = 6
        Me.ntxSession.Name = "ntxSession"
        Me.ntxSession.ReadOnly = False
        Me.ntxSession.Size = New System.Drawing.Size(48, 20)
        Me.ntxSession.TabIndex = 1
        Me.ntxSession.Text = "999999"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 67)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(230, 45)
        Me.GradientPanel2.TabIndex = 19
        '
        'FrParamNV
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(230, 112)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParamNV"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Param�tres de la t�l�intervention"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ntxSession As TextBox

End Class
