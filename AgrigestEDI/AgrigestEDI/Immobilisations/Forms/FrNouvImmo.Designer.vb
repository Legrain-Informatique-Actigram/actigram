<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrNouvImmo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ReelRadioButton = New System.Windows.Forms.RadioButton
        Me.AAARadioButton = New System.Windows.Forms.RadioButton
        Me.SAARadioButton = New System.Windows.Forms.RadioButton
        Me.AcquisExeRadioButton = New System.Windows.Forms.RadioButton
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReelRadioButton)
        Me.GroupBox1.Controls.Add(Me.AAARadioButton)
        Me.GroupBox1.Controls.Add(Me.SAARadioButton)
        Me.GroupBox1.Controls.Add(Me.AcquisExeRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type d'immobilisation"
        '
        'ReelRadioButton
        '
        Me.ReelRadioButton.AutoSize = True
        Me.ReelRadioButton.Location = New System.Drawing.Point(6, 88)
        Me.ReelRadioButton.Name = "ReelRadioButton"
        Me.ReelRadioButton.Size = New System.Drawing.Size(176, 17)
        Me.ReelRadioButton.TabIndex = 3
        Me.ReelRadioButton.TabStop = True
        Me.ReelRadioButton.Text = "Passage au réel de l'exploitation"
        Me.ReelRadioButton.UseVisualStyleBackColor = True
        '
        'AAARadioButton
        '
        Me.AAARadioButton.AutoSize = True
        Me.AAARadioButton.Location = New System.Drawing.Point(6, 65)
        Me.AAARadioButton.Name = "AAARadioButton"
        Me.AAARadioButton.Size = New System.Drawing.Size(265, 17)
        Me.AAARadioButton.TabIndex = 2
        Me.AAARadioButton.TabStop = True
        Me.AAARadioButton.Text = "Saisir en connaissant les amortissements antérieurs"
        Me.AAARadioButton.UseVisualStyleBackColor = True
        '
        'SAARadioButton
        '
        Me.SAARadioButton.AutoSize = True
        Me.SAARadioButton.Location = New System.Drawing.Point(6, 42)
        Me.SAARadioButton.Name = "SAARadioButton"
        Me.SAARadioButton.Size = New System.Drawing.Size(264, 17)
        Me.SAARadioButton.TabIndex = 1
        Me.SAARadioButton.TabStop = True
        Me.SAARadioButton.Text = "Saisir sans connaître les amortissements antérieurs"
        Me.SAARadioButton.UseVisualStyleBackColor = True
        '
        'AcquisExeRadioButton
        '
        Me.AcquisExeRadioButton.AutoSize = True
        Me.AcquisExeRadioButton.Location = New System.Drawing.Point(6, 19)
        Me.AcquisExeRadioButton.Name = "AcquisExeRadioButton"
        Me.AcquisExeRadioButton.Size = New System.Drawing.Size(138, 17)
        Me.AcquisExeRadioButton.TabIndex = 0
        Me.AcquisExeRadioButton.TabStop = True
        Me.AcquisExeRadioButton.Text = "Acquisition de l'exercice"
        Me.AcquisExeRadioButton.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(242, 137)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Location = New System.Drawing.Point(161, 137)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'FrNouvImmo
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(329, 168)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrNouvImmo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Création d'une nouvelle immobilisation"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReelRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AAARadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SAARadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AcquisExeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
