<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrEtats
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Journaux", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Grands livres", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Autres", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Balances", System.Windows.Forms.HorizontalAlignment.Left)
        Me.toolbar = New System.Windows.Forms.ToolStrip
        Me.LbTitre = New System.Windows.Forms.ToolStripLabel
        Me.CloseToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.pgbar = New System.Windows.Forms.ToolStripProgressBar
        Me.ilIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.lvMenus = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ClotureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.toolbar.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.ClotureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolbar
        '
        Me.toolbar.AllowMerge = False
        Me.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LbTitre, Me.CloseToolStripButton, Me.pgbar})
        Me.toolbar.Location = New System.Drawing.Point(0, 0)
        Me.toolbar.Name = "toolbar"
        Me.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.toolbar.Size = New System.Drawing.Size(435, 25)
        Me.toolbar.TabIndex = 4
        Me.toolbar.Text = "ToolStrip1"
        '
        'LbTitre
        '
        Me.LbTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTitre.Name = "LbTitre"
        Me.LbTitre.Size = New System.Drawing.Size(57, 22)
        Me.LbTitre.Text = "LbTitre"
        '
        'CloseToolStripButton
        '
        Me.CloseToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CloseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CloseToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.CloseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseToolStripButton.Name = "CloseToolStripButton"
        Me.CloseToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CloseToolStripButton.Text = "ToolStripButton1"
        '
        'pgbar
        '
        Me.pgbar.Name = "pgbar"
        Me.pgbar.Size = New System.Drawing.Size(100, 22)
        '
        'ilIcons
        '
        Me.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'lvMenus
        '
        Me.lvMenus.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvMenus.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvMenus.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup1.Header = "Journaux"
        ListViewGroup1.Name = "GroupeJournaux"
        ListViewGroup2.Header = "Grands livres"
        ListViewGroup2.Name = "GroupeGrandsLivres"
        ListViewGroup3.Header = "Autres"
        ListViewGroup3.Name = "GroupeAutres"
        ListViewGroup4.Header = "Balances"
        ListViewGroup4.Name = "GroupeBalances"
        Me.lvMenus.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.lvMenus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvMenus.HideSelection = False
        Me.lvMenus.LargeImageList = Me.ilIcons
        Me.lvMenus.Location = New System.Drawing.Point(0, 0)
        Me.lvMenus.MultiSelect = False
        Me.lvMenus.Name = "lvMenus"
        Me.lvMenus.Size = New System.Drawing.Size(145, 282)
        Me.lvMenus.SmallImageList = Me.ilIcons
        Me.lvMenus.TabIndex = 0
        Me.lvMenus.UseCompatibleStateImageBehavior = False
        Me.lvMenus.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 200
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvMenus)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GradientPanel1)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(435, 282)
        Me.SplitContainer1.SplitterDistance = 145
        Me.SplitContainer1.TabIndex = 5
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(280, 276)
        Me.GradientPanel1.TabIndex = 17
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(280, 276)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ClotureBindingSource
        '
        Me.ClotureBindingSource.DataMember = "Dossiers"
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'FrEtats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 307)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolbar)
        Me.Name = "FrEtats"
        Me.ShowInTaskbar = False
        Me.Text = "Gestion des états"
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.ClotureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbTitre As System.Windows.Forms.ToolStripLabel
    Public WithEvents toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents CloseToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ilIcons As System.Windows.Forms.ImageList
    Friend WithEvents lvMenus As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pgbar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ClotureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
End Class