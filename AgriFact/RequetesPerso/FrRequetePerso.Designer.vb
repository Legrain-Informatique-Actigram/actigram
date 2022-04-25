<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRequetePerso
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbExecute = New System.Windows.Forms.ToolStripButton
        Me.TbImprimer = New System.Windows.Forms.ToolStripSplitButton
        Me.ImprimerLesDonnéesBrutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbExporter = New System.Windows.Forms.ToolStripSplitButton
        Me.ExporterLesDonnéesBrutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AffichageToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.ParamètresVisiblesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FractionnementHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FractionnementVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.split = New System.Windows.Forms.SplitContainer
        Me.UcOptions = New RequetesPerso.UcOptions
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.lbTitre = New Ascend.Windows.Forms.GradientCaption
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbStatusQuery = New System.Windows.Forms.ToolStripStatusLabel
        Me.worker = New System.ComponentModel.BackgroundWorker
        Me.ToolStrip1.SuspendLayout()
        Me.split.Panel1.SuspendLayout()
        Me.split.Panel2.SuspendLayout()
        Me.split.SuspendLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbExecute, Me.TbImprimer, Me.TbExporter, Me.AffichageToolStripDropDownButton, Me.TbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(558, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbExecute
        '
        Me.TbExecute.Image = Global.RequetesPerso.My.Resources.Resources.execresults
        Me.TbExecute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbExecute.Name = "TbExecute"
        Me.TbExecute.Size = New System.Drawing.Size(71, 22)
        Me.TbExecute.Text = "Executer"
        '
        'TbImprimer
        '
        Me.TbImprimer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerLesDonnéesBrutesToolStripMenuItem})
        Me.TbImprimer.Image = Global.RequetesPerso.My.Resources.Resources.impr
        Me.TbImprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImprimer.Name = "TbImprimer"
        Me.TbImprimer.Size = New System.Drawing.Size(97, 22)
        Me.TbImprimer.Text = "Imprimer..."
        '
        'ImprimerLesDonnéesBrutesToolStripMenuItem
        '
        Me.ImprimerLesDonnéesBrutesToolStripMenuItem.Image = Global.RequetesPerso.My.Resources.Resources.impr
        Me.ImprimerLesDonnéesBrutesToolStripMenuItem.Name = "ImprimerLesDonnéesBrutesToolStripMenuItem"
        Me.ImprimerLesDonnéesBrutesToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ImprimerLesDonnéesBrutesToolStripMenuItem.Text = "Imprimer les données brutes..."
        '
        'TbExporter
        '
        Me.TbExporter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExporterLesDonnéesBrutesToolStripMenuItem})
        Me.TbExporter.Image = Global.RequetesPerso.My.Resources.Resources.exportcsv
        Me.TbExporter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbExporter.Name = "TbExporter"
        Me.TbExporter.Size = New System.Drawing.Size(91, 22)
        Me.TbExporter.Text = "Exporter..."
        '
        'ExporterLesDonnéesBrutesToolStripMenuItem
        '
        Me.ExporterLesDonnéesBrutesToolStripMenuItem.Image = Global.RequetesPerso.My.Resources.Resources.exportcsv
        Me.ExporterLesDonnéesBrutesToolStripMenuItem.Name = "ExporterLesDonnéesBrutesToolStripMenuItem"
        Me.ExporterLesDonnéesBrutesToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ExporterLesDonnéesBrutesToolStripMenuItem.Text = "Exporter les données brutes..."
        '
        'AffichageToolStripDropDownButton
        '
        Me.AffichageToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParamètresVisiblesToolStripMenuItem, Me.FractionnementHorizontalToolStripMenuItem, Me.FractionnementVerticalToolStripMenuItem})
        Me.AffichageToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AffichageToolStripDropDownButton.Name = "AffichageToolStripDropDownButton"
        Me.AffichageToolStripDropDownButton.Size = New System.Drawing.Size(71, 22)
        Me.AffichageToolStripDropDownButton.Text = "Affichage"
        '
        'ParamètresVisiblesToolStripMenuItem
        '
        Me.ParamètresVisiblesToolStripMenuItem.Checked = True
        Me.ParamètresVisiblesToolStripMenuItem.CheckOnClick = True
        Me.ParamètresVisiblesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ParamètresVisiblesToolStripMenuItem.Name = "ParamètresVisiblesToolStripMenuItem"
        Me.ParamètresVisiblesToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ParamètresVisiblesToolStripMenuItem.Text = "Paramètres"
        '
        'FractionnementHorizontalToolStripMenuItem
        '
        Me.FractionnementHorizontalToolStripMenuItem.Checked = True
        Me.FractionnementHorizontalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FractionnementHorizontalToolStripMenuItem.Name = "FractionnementHorizontalToolStripMenuItem"
        Me.FractionnementHorizontalToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.FractionnementHorizontalToolStripMenuItem.Text = "Fractionnement horizontal"
        '
        'FractionnementVerticalToolStripMenuItem
        '
        Me.FractionnementVerticalToolStripMenuItem.Name = "FractionnementVerticalToolStripMenuItem"
        Me.FractionnementVerticalToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.FractionnementVerticalToolStripMenuItem.Text = "Fractionnement vertical"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.RequetesPerso.My.Resources.Resources.close
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'split
        '
        Me.split.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.split.Location = New System.Drawing.Point(0, 25)
        Me.split.Name = "split"
        Me.split.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'split.Panel1
        '
        Me.split.Panel1.Controls.Add(Me.UcOptions)
        '
        'split.Panel2
        '
        Me.split.Panel2.Controls.Add(Me.dgResult)
        Me.split.Panel2.Controls.Add(Me.lbTitre)
        Me.split.Size = New System.Drawing.Size(558, 358)
        Me.split.SplitterDistance = 40
        Me.split.TabIndex = 1
        '
        'UcOptions
        '
        Me.UcOptions.Connection = Nothing
        Me.UcOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOptions.Location = New System.Drawing.Point(0, 0)
        Me.UcOptions.MinimumSize = New System.Drawing.Size(170, 55)
        Me.UcOptions.Name = "UcOptions"
        Me.UcOptions.Parametres = Nothing
        Me.UcOptions.Size = New System.Drawing.Size(558, 55)
        Me.UcOptions.TabIndex = 0
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgResult.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgResult.Location = New System.Drawing.Point(0, 24)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.ReadOnly = True
        Me.dgResult.Size = New System.Drawing.Size(558, 290)
        Me.dgResult.TabIndex = 0
        '
        'lbTitre
        '
        Me.lbTitre.Border = New Ascend.Border(0, 1, 0, 2)
        Me.lbTitre.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.lbTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbTitre.GradientHighColor = System.Drawing.SystemColors.InactiveCaption
        Me.lbTitre.GradientLowColor = System.Drawing.SystemColors.Window
        Me.lbTitre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTitre.Location = New System.Drawing.Point(0, 0)
        Me.lbTitre.Name = "lbTitre"
        Me.lbTitre.Size = New System.Drawing.Size(558, 24)
        Me.lbTitre.TabIndex = 7
        Me.lbTitre.Text = "lbTitre"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStatusQuery})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 383)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(558, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStatusQuery
        '
        Me.lbStatusQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lbStatusQuery.Name = "lbStatusQuery"
        Me.lbStatusQuery.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.lbStatusQuery.Size = New System.Drawing.Size(81, 17)
        Me.lbStatusQuery.Text = "lbStatusQuery"
        '
        'worker
        '
        Me.worker.WorkerSupportsCancellation = True
        '
        'FrRequetePerso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.split)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrRequetePerso"
        Me.Text = "Requête"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.split.Panel1.ResumeLayout(False)
        Me.split.Panel2.ResumeLayout(False)
        Me.split.ResumeLayout(False)
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents split As System.Windows.Forms.SplitContainer
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents UcOptions As RequetesPerso.UcOptions
    Friend WithEvents TbExecute As System.Windows.Forms.ToolStripButton
    Friend WithEvents AffichageToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ParamètresVisiblesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FractionnementHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FractionnementVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbExporter As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ExporterLesDonnéesBrutesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbImprimer As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimerLesDonnéesBrutesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbTitre As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStatusQuery As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
End Class
