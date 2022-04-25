<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrDebugCodeBarre
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.TxCode = New System.Windows.Forms.TextBox
        Me.TxResult = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TxCode
        '
        Me.TxCode.Location = New System.Drawing.Point(3, 3)
        Me.TxCode.Name = "TxCode"
        Me.TxCode.Size = New System.Drawing.Size(221, 21)
        Me.TxCode.TabIndex = 1
        Me.TxCode.Text = "TxCode"
        '
        'TxResult
        '
        Me.TxResult.Location = New System.Drawing.Point(3, 30)
        Me.TxResult.Multiline = True
        Me.TxResult.Name = "TxResult"
        Me.TxResult.ReadOnly = True
        Me.TxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxResult.Size = New System.Drawing.Size(221, 235)
        Me.TxResult.TabIndex = 2
        Me.TxResult.Text = "TxResult"
        '
        'FrDebugCodeBarre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.TxResult)
        Me.Controls.Add(Me.TxCode)
        Me.Menu = Me.mainMenu1
        Me.Name = "FrDebugCodeBarre"
        Me.Text = "FrDebugCodeBarre"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxCode As System.Windows.Forms.TextBox
    Friend WithEvents TxResult As System.Windows.Forms.TextBox
End Class
