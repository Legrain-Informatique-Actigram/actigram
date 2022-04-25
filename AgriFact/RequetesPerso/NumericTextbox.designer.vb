<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NumericTextbox
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.txValue = New System.Windows.Forms.TextBox
        Me.lbUnit = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txValue
        '
        Me.txValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txValue.Location = New System.Drawing.Point(0, 0)
        Me.txValue.Margin = New System.Windows.Forms.Padding(0)
        Me.txValue.Name = "txValue"
        Me.txValue.Size = New System.Drawing.Size(100, 20)
        Me.txValue.TabIndex = 0
        Me.txValue.Text = "0,00"
        Me.txValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbUnit
        '
        Me.lbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUnit.AutoSize = True
        Me.lbUnit.Location = New System.Drawing.Point(100, 3)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(21, 13)
        Me.lbUnit.TabIndex = 1
        Me.lbUnit.Text = "XX"
        '
        'NumericTextbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txValue)
        Me.Controls.Add(Me.lbUnit)
        Me.Name = "NumericTextbox"
        Me.Size = New System.Drawing.Size(121, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txValue As System.Windows.Forms.TextBox
    Friend WithEvents lbUnit As System.Windows.Forms.Label

End Class
