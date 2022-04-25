<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrToolTip
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
        Me.lbTooltip = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbTooltip
        '
        Me.lbTooltip.AutoSize = True
        Me.lbTooltip.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lbTooltip.Location = New System.Drawing.Point(5, 5)
        Me.lbTooltip.Name = "lbTooltip"
        Me.lbTooltip.Size = New System.Drawing.Size(47, 13)
        Me.lbTooltip.TabIndex = 0
        Me.lbTooltip.Text = "lbTooltip"
        '
        'FrToolTip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(64, 23)
        Me.Controls.Add(Me.lbTooltip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrToolTip"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrToolTip"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbTooltip As System.Windows.Forms.Label
End Class
