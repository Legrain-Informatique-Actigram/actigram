<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrImpImmo
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
        Me.TabImmoCheckBox = New System.Windows.Forms.CheckBox
        Me.TabImmoActCheckBox = New System.Windows.Forms.CheckBox
        Me.TabDepImmoCheckBox = New System.Windows.Forms.CheckBox
        Me.RecapClasseCheckBox = New System.Windows.Forms.CheckBox
        Me.TabCessCheckBox = New System.Windows.Forms.CheckBox
        Me.AmortDegCheckBox = New System.Windows.Forms.CheckBox
        Me.PassReelCheckBox = New System.Windows.Forms.CheckBox
        Me.CalProvCheckBox = New System.Windows.Forms.CheckBox
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TabImmoCheckBox
        '
        Me.TabImmoCheckBox.AutoSize = True
        Me.TabImmoCheckBox.Location = New System.Drawing.Point(12, 12)
        Me.TabImmoCheckBox.Name = "TabImmoCheckBox"
        Me.TabImmoCheckBox.Size = New System.Drawing.Size(162, 17)
        Me.TabImmoCheckBox.TabIndex = 0
        Me.TabImmoCheckBox.Text = "Tableaux des immobilisations"
        Me.TabImmoCheckBox.UseVisualStyleBackColor = True
        '
        'TabImmoActCheckBox
        '
        Me.TabImmoActCheckBox.AutoSize = True
        Me.TabImmoActCheckBox.Location = New System.Drawing.Point(12, 35)
        Me.TabImmoActCheckBox.Name = "TabImmoActCheckBox"
        Me.TabImmoActCheckBox.Size = New System.Drawing.Size(217, 17)
        Me.TabImmoActCheckBox.TabIndex = 1
        Me.TabImmoActCheckBox.Text = "Tableaux des immobilisations par activité"
        Me.TabImmoActCheckBox.UseVisualStyleBackColor = True
        '
        'TabDepImmoCheckBox
        '
        Me.TabDepImmoCheckBox.AutoSize = True
        Me.TabDepImmoCheckBox.Location = New System.Drawing.Point(12, 58)
        Me.TabDepImmoCheckBox.Name = "TabDepImmoCheckBox"
        Me.TabDepImmoCheckBox.Size = New System.Drawing.Size(210, 17)
        Me.TabDepImmoCheckBox.TabIndex = 2
        Me.TabDepImmoCheckBox.Text = "Tableaux de départ des immobilisations"
        Me.TabDepImmoCheckBox.UseVisualStyleBackColor = True
        '
        'RecapClasseCheckBox
        '
        Me.RecapClasseCheckBox.AutoSize = True
        Me.RecapClasseCheckBox.Location = New System.Drawing.Point(12, 81)
        Me.RecapClasseCheckBox.Name = "RecapClasseCheckBox"
        Me.RecapClasseCheckBox.Size = New System.Drawing.Size(228, 17)
        Me.RecapClasseCheckBox.TabIndex = 3
        Me.RecapClasseCheckBox.Text = "Récapitulatif des immobilisations par classe"
        Me.RecapClasseCheckBox.UseVisualStyleBackColor = True
        '
        'TabCessCheckBox
        '
        Me.TabCessCheckBox.AutoSize = True
        Me.TabCessCheckBox.Location = New System.Drawing.Point(12, 104)
        Me.TabCessCheckBox.Name = "TabCessCheckBox"
        Me.TabCessCheckBox.Size = New System.Drawing.Size(148, 17)
        Me.TabCessCheckBox.TabIndex = 4
        Me.TabCessCheckBox.Text = "Cessions d'immobilisations"
        Me.TabCessCheckBox.UseVisualStyleBackColor = True
        '
        'AmortDegCheckBox
        '
        Me.AmortDegCheckBox.AutoSize = True
        Me.AmortDegCheckBox.Location = New System.Drawing.Point(12, 127)
        Me.AmortDegCheckBox.Name = "AmortDegCheckBox"
        Me.AmortDegCheckBox.Size = New System.Drawing.Size(160, 17)
        Me.AmortDegCheckBox.TabIndex = 5
        Me.AmortDegCheckBox.Text = "Amortissements dérogatoires"
        Me.AmortDegCheckBox.UseVisualStyleBackColor = True
        '
        'PassReelCheckBox
        '
        Me.PassReelCheckBox.AutoSize = True
        Me.PassReelCheckBox.Location = New System.Drawing.Point(12, 150)
        Me.PassReelCheckBox.Name = "PassReelCheckBox"
        Me.PassReelCheckBox.Size = New System.Drawing.Size(102, 17)
        Me.PassReelCheckBox.TabIndex = 6
        Me.PassReelCheckBox.Text = "Passage au réel"
        Me.PassReelCheckBox.UseVisualStyleBackColor = True
        '
        'CalProvCheckBox
        '
        Me.CalProvCheckBox.AutoSize = True
        Me.CalProvCheckBox.Location = New System.Drawing.Point(12, 173)
        Me.CalProvCheckBox.Name = "CalProvCheckBox"
        Me.CalProvCheckBox.Size = New System.Drawing.Size(113, 17)
        Me.CalProvCheckBox.TabIndex = 7
        Me.CalProvCheckBox.Text = "Calculs provisoires"
        Me.CalProvCheckBox.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(165, 201)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 8
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Location = New System.Drawing.Point(84, 201)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 9
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'FrImpImmo
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(249, 236)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.CalProvCheckBox)
        Me.Controls.Add(Me.PassReelCheckBox)
        Me.Controls.Add(Me.AmortDegCheckBox)
        Me.Controls.Add(Me.TabCessCheckBox)
        Me.Controls.Add(Me.RecapClasseCheckBox)
        Me.Controls.Add(Me.TabDepImmoCheckBox)
        Me.Controls.Add(Me.TabImmoActCheckBox)
        Me.Controls.Add(Me.TabImmoCheckBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrImpImmo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressions des immobilisations "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabImmoCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabImmoActCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabDepImmoCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RecapClasseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabCessCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AmortDegCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PassReelCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CalProvCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
