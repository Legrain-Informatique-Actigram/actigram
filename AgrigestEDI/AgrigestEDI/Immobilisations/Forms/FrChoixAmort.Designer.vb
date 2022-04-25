<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixAmort
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
        Me.ChxAmortRadioButton = New System.Windows.Forms.RadioButton
        Me.AmortMinRadioButton = New System.Windows.Forms.RadioButton
        Me.AmortMaxRadioButton = New System.Windows.Forms.RadioButton
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.ValiderButton = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChxAmortRadioButton)
        Me.GroupBox1.Controls.Add(Me.AmortMinRadioButton)
        Me.GroupBox1.Controls.Add(Me.AmortMaxRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choix de l'amortissement"
        '
        'ChxAmortRadioButton
        '
        Me.ChxAmortRadioButton.AutoSize = True
        Me.ChxAmortRadioButton.Location = New System.Drawing.Point(6, 75)
        Me.ChxAmortRadioButton.Name = "ChxAmortRadioButton"
        Me.ChxAmortRadioButton.Size = New System.Drawing.Size(260, 17)
        Me.ChxAmortRadioButton.TabIndex = 2
        Me.ChxAmortRadioButton.TabStop = True
        Me.ChxAmortRadioButton.Text = "Choisir l'amortissement pour chaque immobilisation"
        Me.ChxAmortRadioButton.UseVisualStyleBackColor = True
        '
        'AmortMinRadioButton
        '
        Me.AmortMinRadioButton.AutoSize = True
        Me.AmortMinRadioButton.Location = New System.Drawing.Point(6, 52)
        Me.AmortMinRadioButton.Name = "AmortMinRadioButton"
        Me.AmortMinRadioButton.Size = New System.Drawing.Size(347, 17)
        Me.AmortMinRadioButton.TabIndex = 1
        Me.AmortMinRadioButton.TabStop = True
        Me.AmortMinRadioButton.Text = "Prendre l'amortissement minimum pour l'ensemble des immobilisations"
        Me.AmortMinRadioButton.UseVisualStyleBackColor = True
        '
        'AmortMaxRadioButton
        '
        Me.AmortMaxRadioButton.AutoSize = True
        Me.AmortMaxRadioButton.Location = New System.Drawing.Point(6, 29)
        Me.AmortMaxRadioButton.Name = "AmortMaxRadioButton"
        Me.AmortMaxRadioButton.Size = New System.Drawing.Size(350, 17)
        Me.AmortMaxRadioButton.TabIndex = 0
        Me.AmortMaxRadioButton.TabStop = True
        Me.AmortMaxRadioButton.Text = "Prendre l'amortissement maximum pour l'ensemble des immobilisations"
        Me.AmortMaxRadioButton.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(314, 122)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'ValiderButton
        '
        Me.ValiderButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ValiderButton.Location = New System.Drawing.Point(233, 122)
        Me.ValiderButton.Name = "ValiderButton"
        Me.ValiderButton.Size = New System.Drawing.Size(75, 23)
        Me.ValiderButton.TabIndex = 2
        Me.ValiderButton.Text = "Valider"
        Me.ValiderButton.UseVisualStyleBackColor = True
        '
        'FrChoixAmort
        '
        Me.AcceptButton = Me.ValiderButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(401, 154)
        Me.Controls.Add(Me.ValiderButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrChoixAmort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choix de l'amortissement"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChxAmortRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AmortMinRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AmortMaxRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents ValiderButton As System.Windows.Forms.Button
End Class
