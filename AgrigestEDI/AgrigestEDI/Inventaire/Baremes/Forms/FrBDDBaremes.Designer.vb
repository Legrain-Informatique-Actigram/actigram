<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrBDDBaremes
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheminBDDBaremesTextBox = New System.Windows.Forms.TextBox
        Me.OuvrirBoiteDialogueButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Base de données des barèmes:"
        '
        'CheminBDDBaremesTextBox
        '
        Me.CheminBDDBaremesTextBox.Location = New System.Drawing.Point(175, 30)
        Me.CheminBDDBaremesTextBox.Name = "CheminBDDBaremesTextBox"
        Me.CheminBDDBaremesTextBox.Size = New System.Drawing.Size(395, 20)
        Me.CheminBDDBaremesTextBox.TabIndex = 1
        '
        'OuvrirBoiteDialogueButton
        '
        Me.OuvrirBoiteDialogueButton.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.OuvrirBoiteDialogueButton.Location = New System.Drawing.Point(576, 28)
        Me.OuvrirBoiteDialogueButton.Name = "OuvrirBoiteDialogueButton"
        Me.OuvrirBoiteDialogueButton.Size = New System.Drawing.Size(41, 23)
        Me.OuvrirBoiteDialogueButton.TabIndex = 2
        Me.OuvrirBoiteDialogueButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(461, 82)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(542, 82)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 4
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'FrBDDBaremes
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(633, 117)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.OuvrirBoiteDialogueButton)
        Me.Controls.Add(Me.CheminBDDBaremesTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrBDDBaremes"
        Me.Text = "Base de données des barèmes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheminBDDBaremesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OuvrirBoiteDialogueButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
End Class
