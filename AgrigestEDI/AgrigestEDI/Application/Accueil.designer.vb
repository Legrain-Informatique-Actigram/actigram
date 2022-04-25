<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Accueil
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Mon item", "Sous-item"}, -1)
        Me.fond = New Ascend.Windows.Forms.GradientPanel
        Me.lvMenus = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ilIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.toolbar = New System.Windows.Forms.ToolStrip
        Me.LbTitre = New System.Windows.Forms.ToolStripLabel
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.fond.SuspendLayout()
        Me.toolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'fond
        '
        Me.fond.Controls.Add(Me.lvMenus)
        Me.fond.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fond.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.fond.Location = New System.Drawing.Point(0, 25)
        Me.fond.Name = "fond"
        Me.fond.Size = New System.Drawing.Size(345, 282)
        Me.fond.TabIndex = 2
        '
        'lvMenus
        '
        Me.lvMenus.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader2})
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
        Me.lvMenus.HideSelection = False
        ListViewItem1.Group = ListViewGroup1
        Me.lvMenus.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvMenus.LargeImageList = Me.ilIcons
        Me.lvMenus.Location = New System.Drawing.Point(0, 0)
        Me.lvMenus.MultiSelect = False
        Me.lvMenus.Name = "lvMenus"
        Me.lvMenus.ShowItemToolTips = True
        Me.lvMenus.Size = New System.Drawing.Size(345, 282)
        Me.lvMenus.SmallImageList = Me.ilIcons
        Me.lvMenus.TabIndex = 1
        Me.lvMenus.TileSize = New System.Drawing.Size(200, 50)
        Me.lvMenus.UseCompatibleStateImageBehavior = False
        Me.lvMenus.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 200
        '
        'ilIcons
        '
        Me.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilIcons.ImageSize = New System.Drawing.Size(48, 48)
        Me.ilIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'toolbar
        '
        Me.toolbar.AllowMerge = False
        Me.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LbTitre})
        Me.toolbar.Location = New System.Drawing.Point(0, 0)
        Me.toolbar.Name = "toolbar"
        Me.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.toolbar.Size = New System.Drawing.Size(345, 25)
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
        'Accueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 307)
        Me.ControlBox = False
        Me.Controls.Add(Me.fond)
        Me.Controls.Add(Me.toolbar)
        Me.Name = "Accueil"
        Me.ShowInTaskbar = False
        Me.Text = "Accueil"
        Me.fond.ResumeLayout(False)
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbTitre As System.Windows.Forms.ToolStripLabel
    Public WithEvents fond As Ascend.Windows.Forms.GradientPanel
    Public WithEvents toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ilIcons As System.Windows.Forms.ImageList
    Friend WithEvents lvMenus As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class