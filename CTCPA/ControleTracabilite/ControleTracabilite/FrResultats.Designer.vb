<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrResultats
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrResultats))
        Me.ResultatsDataGridView = New System.Windows.Forms.DataGridView
        Me.IdControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibControle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TestEffectueDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ResultatConformite = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ResultatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ResultatsBaremesCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ResultatsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtClose = New System.Windows.Forms.ToolStripButton
        Me.TbFiltrer = New System.Windows.Forms.ToolStripDropDownButton
        Me.FiltrerEffectuesMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MasquerConformesMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton
        CType(Me.ResultatsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultatsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ResultatsDataGridView
        '
        Me.ResultatsDataGridView.AllowUserToAddRows = False
        Me.ResultatsDataGridView.AllowUserToDeleteRows = False
        Me.ResultatsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.ResultatsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ResultatsDataGridView.AutoGenerateColumns = False
        Me.ResultatsDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.ResultatsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.ResultatsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdControleDataGridViewTextBoxColumn, Me.LibControle, Me.TestEffectueDataGridViewCheckBoxColumn, Me.ResultatConformite, Me.ResultatDataGridViewTextBoxColumn, Me.ResultatsBaremesCount})
        Me.ResultatsDataGridView.DataSource = Me.ResultatsBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ResultatsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ResultatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultatsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ResultatsDataGridView.MultiSelect = False
        Me.ResultatsDataGridView.Name = "ResultatsDataGridView"
        Me.ResultatsDataGridView.ReadOnly = True
        Me.ResultatsDataGridView.RowHeadersVisible = False
        Me.ResultatsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ResultatsDataGridView.Size = New System.Drawing.Size(620, 382)
        Me.ResultatsDataGridView.TabIndex = 1
        '
        'IdControleDataGridViewTextBoxColumn
        '
        Me.IdControleDataGridViewTextBoxColumn.DataPropertyName = "IdControle"
        Me.IdControleDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdControleDataGridViewTextBoxColumn.Name = "IdControleDataGridViewTextBoxColumn"
        Me.IdControleDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdControleDataGridViewTextBoxColumn.Width = 30
        '
        'LibControle
        '
        Me.LibControle.DataPropertyName = "LibControle"
        Me.LibControle.HeaderText = "LibControle"
        Me.LibControle.Name = "LibControle"
        Me.LibControle.ReadOnly = True
        Me.LibControle.Width = 250
        '
        'TestEffectueDataGridViewCheckBoxColumn
        '
        Me.TestEffectueDataGridViewCheckBoxColumn.DataPropertyName = "TestEffectue"
        Me.TestEffectueDataGridViewCheckBoxColumn.HeaderText = "Effectué"
        Me.TestEffectueDataGridViewCheckBoxColumn.Name = "TestEffectueDataGridViewCheckBoxColumn"
        Me.TestEffectueDataGridViewCheckBoxColumn.ReadOnly = True
        Me.TestEffectueDataGridViewCheckBoxColumn.Width = 55
        '
        'ResultatConformite
        '
        Me.ResultatConformite.DataPropertyName = "ResultatConformite"
        Me.ResultatConformite.HeaderText = "Conforme"
        Me.ResultatConformite.Name = "ResultatConformite"
        Me.ResultatConformite.ReadOnly = True
        Me.ResultatConformite.Width = 55
        '
        'ResultatDataGridViewTextBoxColumn
        '
        Me.ResultatDataGridViewTextBoxColumn.DataPropertyName = "Resultat"
        Me.ResultatDataGridViewTextBoxColumn.HeaderText = "Résultat"
        Me.ResultatDataGridViewTextBoxColumn.Name = "ResultatDataGridViewTextBoxColumn"
        Me.ResultatDataGridViewTextBoxColumn.ReadOnly = True
        Me.ResultatDataGridViewTextBoxColumn.Width = 150
        '
        'ResultatsBaremesCount
        '
        Me.ResultatsBaremesCount.DataPropertyName = "ResultatsBaremesCount"
        Me.ResultatsBaremesCount.HeaderText = "Baremes"
        Me.ResultatsBaremesCount.Name = "ResultatsBaremesCount"
        Me.ResultatsBaremesCount.ReadOnly = True
        Me.ResultatsBaremesCount.Width = 55
        '
        'ResultatsBindingSource
        '
        Me.ResultatsBindingSource.DataSource = GetType(ControleTracabilite.Controles.ResultatControle)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtClose, Me.TbFiltrer, Me.DeleteToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtClose
        '
        Me.BtClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(23, 22)
        Me.BtClose.Text = "Fermer"
        '
        'TbFiltrer
        '
        Me.TbFiltrer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FiltrerEffectuesMenuItem, Me.MasquerConformesMenuItem})
        Me.TbFiltrer.Image = CType(resources.GetObject("TbFiltrer.Image"), System.Drawing.Image)
        Me.TbFiltrer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFiltrer.Name = "TbFiltrer"
        Me.TbFiltrer.Size = New System.Drawing.Size(64, 22)
        Me.TbFiltrer.Text = "Filtrer"
        '
        'FiltrerEffectuesMenuItem
        '
        Me.FiltrerEffectuesMenuItem.CheckOnClick = True
        Me.FiltrerEffectuesMenuItem.Name = "FiltrerEffectuesMenuItem"
        Me.FiltrerEffectuesMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.FiltrerEffectuesMenuItem.Text = "Masquer les tests non effectués"
        '
        'MasquerConformesMenuItem
        '
        Me.MasquerConformesMenuItem.CheckOnClick = True
        Me.MasquerConformesMenuItem.Name = "MasquerConformesMenuItem"
        Me.MasquerConformesMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.MasquerConformesMenuItem.Text = "Masquer les tests conformes"
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.Image = Global.ControleTracabilite.My.Resources.Resources.suppr
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.DeleteToolStripButton.Text = "Effacer"
        '
        'FrResultats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 407)
        Me.Controls.Add(Me.ResultatsDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrResultats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Résultats"
        CType(Me.ResultatsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultatsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ResultatsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ResultatsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFiltrer As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FiltrerEffectuesMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasquerConformesMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IdControleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibControle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestEffectueDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ResultatConformite As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ResultatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResultatsBaremesCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton

End Class
