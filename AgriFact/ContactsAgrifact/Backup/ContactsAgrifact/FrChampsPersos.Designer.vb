<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChampsPersos
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
        Me.ChampsPersosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.ValeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbChoixColonnes = New System.Windows.Forms.ToolStripButton
        Me.TbRefresh = New System.Windows.Forms.ToolStripButton
        CType(Me.ChampsPersosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChampsPersosBindingSource
        '
        Me.ChampsPersosBindingSource.DataMember = "ChampsPersos"
        Me.ChampsPersosBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ValeurDataGridViewTextBoxColumn
        '
        Me.ValeurDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ValeurDataGridViewTextBoxColumn.DataPropertyName = "Valeur"
        Me.ValeurDataGridViewTextBoxColumn.HeaderText = "Valeur"
        Me.ValeurDataGridViewTextBoxColumn.Name = "ValeurDataGridViewTextBoxColumn"
        Me.ValeurDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        Me.LibelleDataGridViewTextBoxColumn.Width = 63
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AutoGenerateColumns = False
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LibelleDataGridViewTextBoxColumn, Me.ValeurDataGridViewTextBoxColumn})
        Me.dgResult.DataSource = Me.ChampsPersosBindingSource
        Me.dgResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgResult.Location = New System.Drawing.Point(0, 25)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.ReadOnly = True
        Me.dgResult.Size = New System.Drawing.Size(292, 241)
        Me.dgResult.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbChoixColonnes, Me.TbRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(292, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbChoixColonnes
        '
        Me.TbChoixColonnes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbChoixColonnes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbChoixColonnes.Image = Global.ContactsAgrifact.My.Resources.Resources.LegendHS
        Me.TbChoixColonnes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbChoixColonnes.Name = "TbChoixColonnes"
        Me.TbChoixColonnes.Size = New System.Drawing.Size(23, 22)
        Me.TbChoixColonnes.Text = "Choisir les champs à afficher"
        '
        'TbRefresh
        '
        Me.TbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbRefresh.Image = Global.ContactsAgrifact.My.Resources.Resources.RefreshDocViewHS
        Me.TbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbRefresh.Name = "TbRefresh"
        Me.TbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.TbRefresh.Text = "Actualiser"
        '
        'FrChampsPersos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.dgResult)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrChampsPersos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Champs Persos"
        CType(Me.ChampsPersosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChampsPersosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents ValeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents TbChoixColonnes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbRefresh As System.Windows.Forms.ToolStripButton
End Class
