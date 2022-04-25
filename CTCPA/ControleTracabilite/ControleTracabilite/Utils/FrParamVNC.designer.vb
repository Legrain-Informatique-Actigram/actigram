<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrParamVNC
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.nudID = New System.Windows.Forms.NumericUpDown
        Me.TxtAdresse = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1.SuspendLayout()
        CType(Me.nudID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(156, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(229, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.nudID)
        Me.GradientPanel1.Controls.Add(Me.TxtAdresse)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(308, 102)
        Me.GradientPanel1.TabIndex = 18
        '
        'nudID
        '
        Me.nudID.Location = New System.Drawing.Point(122, 17)
        Me.nudID.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudID.Name = "nudID"
        Me.nudID.Size = New System.Drawing.Size(37, 20)
        Me.nudID.TabIndex = 3
        Me.nudID.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'TxtAdresse
        '
        Me.TxtAdresse.Location = New System.Drawing.Point(122, 43)
        Me.TxtAdresse.Name = "TxtAdresse"
        Me.TxtAdresse.Size = New System.Drawing.Size(119, 20)
        Me.TxtAdresse.TabIndex = 2
        Me.TxtAdresse.Text = "999.999.999.999:9999"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Code ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom de machine :"
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 102)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(308, 45)
        Me.GradientPanel2.TabIndex = 19
        '
        'FrParamVNC
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(308, 147)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParamVNC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramètres de la téléintervention"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.nudID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents nudID As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtAdresse As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
