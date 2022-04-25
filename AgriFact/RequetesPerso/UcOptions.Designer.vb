<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcOptions
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
        Me.controlLayout = New System.Windows.Forms.FlowLayoutPanel
        Me.lbTitre = New Ascend.Windows.Forms.GradientCaption
        Me.SuspendLayout()
        '
        'controlLayout
        '
        Me.controlLayout.AutoSize = True
        Me.controlLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.controlLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.controlLayout.Location = New System.Drawing.Point(0, 24)
        Me.controlLayout.Name = "controlLayout"
        Me.controlLayout.Size = New System.Drawing.Size(170, 31)
        Me.controlLayout.TabIndex = 0
        '
        'lbTitre
        '
        Me.lbTitre.Border = New Ascend.Border(0, 1, 0, 2)
        Me.lbTitre.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.lbTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitre.ForeColor = System.Drawing.SystemColors.MenuText
        Me.lbTitre.GradientHighColor = System.Drawing.SystemColors.InactiveCaption
        Me.lbTitre.GradientLowColor = System.Drawing.SystemColors.Window
        Me.lbTitre.Image = Global.RequetesPerso.My.Resources.Resources.close
        Me.lbTitre.Location = New System.Drawing.Point(0, 0)
        Me.lbTitre.Name = "lbTitre"
        Me.lbTitre.Size = New System.Drawing.Size(170, 24)
        Me.lbTitre.TabIndex = 8
        Me.lbTitre.Text = "Paramètres"
        '
        'UcOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.controlLayout)
        Me.Controls.Add(Me.lbTitre)
        Me.MinimumSize = New System.Drawing.Size(170, 55)
        Me.Name = "UcOptions"
        Me.Size = New System.Drawing.Size(170, 55)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents controlLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbTitre As Ascend.Windows.Forms.GradientCaption

End Class
