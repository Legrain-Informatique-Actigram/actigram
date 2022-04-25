<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbConnexion = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.SplitOpen = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbConnexion, Me.ToolStripButton2, Me.SplitOpen})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(511, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbConnexion
        '
        Me.TbConnexion.Image = Global.RequetesPersoTestBench.My.Resources.Resources.connect
        Me.TbConnexion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbConnexion.Name = "TbConnexion"
        Me.TbConnexion.Size = New System.Drawing.Size(84, 22)
        Me.TbConnexion.Text = "Connexion"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.RequetesPersoTestBench.My.Resources.Resources.save
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButton2.Text = "Enregistrer"
        Me.ToolStripButton2.Visible = False
        '
        'SplitOpen
        '
        Me.SplitOpen.Image = Global.RequetesPersoTestBench.My.Resources.Resources.open
        Me.SplitOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SplitOpen.Name = "SplitOpen"
        Me.SplitOpen.Size = New System.Drawing.Size(72, 22)
        Me.SplitOpen.Text = "Ouvrir"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 394)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Main"
        Me.Text = "Statistiques"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbConnexion As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitOpen As System.Windows.Forms.ToolStripSplitButton

End Class
