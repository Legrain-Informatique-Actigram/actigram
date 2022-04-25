<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSaisieMotDePasse
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
        Dim CompteDisplayLabel As System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.MotDePasseTextBox = New System.Windows.Forms.TextBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.OKButton = New System.Windows.Forms.Button
        Me.AnnulerButton = New System.Windows.Forms.Button
        CompteDisplayLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CompteDisplayLabel
        '
        CompteDisplayLabel.AutoSize = True
        CompteDisplayLabel.Location = New System.Drawing.Point(12, 29)
        CompteDisplayLabel.Name = "CompteDisplayLabel"
        CompteDisplayLabel.Size = New System.Drawing.Size(77, 13)
        CompteDisplayLabel.TabIndex = 2
        CompteDisplayLabel.Text = "Mot de passe :"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.MotDePasseTextBox)
        Me.GradientPanel1.Controls.Add(CompteDisplayLabel)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(286, 77)
        Me.GradientPanel1.TabIndex = 5
        '
        'MotDePasseTextBox
        '
        Me.MotDePasseTextBox.Location = New System.Drawing.Point(95, 26)
        Me.MotDePasseTextBox.Name = "MotDePasseTextBox"
        Me.MotDePasseTextBox.Size = New System.Drawing.Size(173, 20)
        Me.MotDePasseTextBox.TabIndex = 3
        Me.MotDePasseTextBox.UseSystemPasswordChar = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.OKButton)
        Me.GradientPanel2.Controls.Add(Me.AnnulerButton)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 77)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(286, 42)
        Me.GradientPanel2.TabIndex = 6
        '
        'OKButton
        '
        Me.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OKButton.Location = New System.Drawing.Point(128, 7)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(67, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        '
        'AnnulerButton
        '
        Me.AnnulerButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(201, 7)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(67, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        '
        'FrSaisieMotDePasse
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(286, 119)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSaisieMotDePasse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mot de passe"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents MotDePasseTextBox As System.Windows.Forms.TextBox
End Class
