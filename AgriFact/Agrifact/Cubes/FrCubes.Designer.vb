<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCubes
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
        Me.components = New System.ComponentModel.Container
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TreeViewModelesXML = New System.Windows.Forms.TreeView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LancerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageListTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.GradientCaptionModelesXML = New Ascend.Windows.Forms.GradientCaption
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeViewModelesXML)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GradientCaptionModelesXML)
        Me.SplitContainer1.Size = New System.Drawing.Size(720, 431)
        Me.SplitContainer1.SplitterDistance = 356
        Me.SplitContainer1.TabIndex = 16
        '
        'TreeViewModelesXML
        '
        Me.TreeViewModelesXML.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeViewModelesXML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewModelesXML.FullRowSelect = True
        Me.TreeViewModelesXML.HotTracking = True
        Me.TreeViewModelesXML.ImageIndex = 0
        Me.TreeViewModelesXML.ImageList = Me.ImageListTreeView
        Me.TreeViewModelesXML.Location = New System.Drawing.Point(0, 24)
        Me.TreeViewModelesXML.Name = "TreeViewModelesXML"
        Me.TreeViewModelesXML.SelectedImageIndex = 0
        Me.TreeViewModelesXML.Size = New System.Drawing.Size(356, 407)
        Me.TreeViewModelesXML.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LancerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(110, 26)
        '
        'LancerToolStripMenuItem
        '
        Me.LancerToolStripMenuItem.Name = "LancerToolStripMenuItem"
        Me.LancerToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.LancerToolStripMenuItem.Text = "Lancer"
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListTreeView.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTreeView.TransparentColor = System.Drawing.Color.Transparent
        '
        'GradientCaptionModelesXML
        '
        Me.GradientCaptionModelesXML.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaptionModelesXML.GradientHighColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaptionModelesXML.GradientLowColor = System.Drawing.SystemColors.InactiveCaption
        Me.GradientCaptionModelesXML.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaptionModelesXML.Name = "GradientCaptionModelesXML"
        Me.GradientCaptionModelesXML.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaptionModelesXML.Size = New System.Drawing.Size(356, 24)
        Me.GradientCaptionModelesXML.TabIndex = 1
        Me.GradientCaptionModelesXML.Text = "Modèles (click-droit sur une ligne sélectionnée pour lancer le cube)"
        '
        'FrCubes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(720, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrCubes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cubes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeViewModelesXML As System.Windows.Forms.TreeView
    Friend WithEvents GradientCaptionModelesXML As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents ImageListTreeView As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LancerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
