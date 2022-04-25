<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LongMessageBox
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxDetails = New System.Windows.Forms.TextBox
        Me.lbMessage = New System.Windows.Forms.Label
        Me.pcIcon = New System.Windows.Forms.PictureBox
        Me.buttonsLayout = New System.Windows.Forms.FlowLayoutPanel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.pcIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.buttonsLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(296, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(67, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Button3"
        '
        'TxDetails
        '
        Me.TxDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxDetails.Location = New System.Drawing.Point(12, 58)
        Me.TxDetails.Multiline = True
        Me.TxDetails.Name = "TxDetails"
        Me.TxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxDetails.Size = New System.Drawing.Size(344, 136)
        Me.TxDetails.TabIndex = 1
        Me.TxDetails.Text = "Details"
        Me.TxDetails.WordWrap = False
        '
        'lbMessage
        '
        Me.lbMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbMessage.Location = New System.Drawing.Point(58, 12)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(298, 40)
        Me.lbMessage.TabIndex = 2
        Me.lbMessage.Text = "Message"
        '
        'pcIcon
        '
        Me.pcIcon.Location = New System.Drawing.Point(12, 12)
        Me.pcIcon.Name = "pcIcon"
        Me.pcIcon.Size = New System.Drawing.Size(40, 40)
        Me.pcIcon.TabIndex = 3
        Me.pcIcon.TabStop = False
        '
        'buttonsLayout
        '
        Me.buttonsLayout.BackColor = System.Drawing.SystemColors.Control
        Me.buttonsLayout.Controls.Add(Me.Button3)
        Me.buttonsLayout.Controls.Add(Me.Button2)
        Me.buttonsLayout.Controls.Add(Me.Button1)
        Me.buttonsLayout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonsLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.buttonsLayout.Location = New System.Drawing.Point(0, 200)
        Me.buttonsLayout.Name = "buttonsLayout"
        Me.buttonsLayout.Padding = New System.Windows.Forms.Padding(0, 5, 2, 0)
        Me.buttonsLayout.Size = New System.Drawing.Size(368, 40)
        Me.buttonsLayout.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(223, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(150, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'LongMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(368, 240)
        Me.Controls.Add(Me.buttonsLayout)
        Me.Controls.Add(Me.pcIcon)
        Me.Controls.Add(Me.lbMessage)
        Me.Controls.Add(Me.TxDetails)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(277, 235)
        Me.Name = "LongMessageBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Title"
        CType(Me.pcIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.buttonsLayout.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxDetails As System.Windows.Forms.TextBox
    Friend WithEvents lbMessage As System.Windows.Forms.Label
    Friend WithEvents pcIcon As System.Windows.Forms.PictureBox
    Friend WithEvents buttonsLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
