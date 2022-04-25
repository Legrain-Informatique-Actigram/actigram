<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrApercuActionCo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrApercuActionCo))
        Me.Content = New System.Windows.Forms.TableLayoutPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.GradientPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Content
        '
        Me.Content.AutoScroll = True
        Me.Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Content.ColumnCount = 1
        Me.Content.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Content.Cursor = System.Windows.Forms.Cursors.Default
        Me.Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Content.Location = New System.Drawing.Point(3, 3)
        Me.Content.Name = "Content"
        Me.Content.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Content.RowCount = 1
        Me.Content.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.Content.Size = New System.Drawing.Size(484, 382)
        Me.Content.TabIndex = 2
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Content)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.GradientPanel1.Size = New System.Drawing.Size(490, 388)
        Me.GradientPanel1.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtFermer, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(490, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtFermer
        '
        Me.BtFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtFermer.Image = CType(resources.GetObject("BtFermer.Image"), System.Drawing.Image)
        Me.BtFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtFermer.Name = "BtFermer"
        Me.BtFermer.Size = New System.Drawing.Size(23, 22)
        Me.BtFermer.Text = "Fermer"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'FrApercuActionCo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(490, 413)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrApercuActionCo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aperçu des actions correctives"
        Me.GradientPanel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Content As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
