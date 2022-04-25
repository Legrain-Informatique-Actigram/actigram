<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRecherche
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
        Me.dgResults = New System.Windows.Forms.DataGridView
        Me.ColImDetails = New System.Windows.Forms.DataGridViewImageColumn
        Me.CiviliteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctxGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FicheClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechercheBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifactBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TxRecherche = New PointDeVente.ToolStripSpringTextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.BtGo = New System.Windows.Forms.ToolStripSplitButton
        Me.MotEntierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechercheTableAdapter = New PointDeVente.DsAgrifactTableAdapters.RechercheTableAdapter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxGrid.SuspendLayout()
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifactBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.AutoGenerateColumns = False
        Me.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColImDetails, Me.CiviliteDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn})
        Me.dgResults.ContextMenuStrip = Me.ctxGrid
        Me.dgResults.DataSource = Me.RechercheBindingSource
        Me.dgResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgResults.Location = New System.Drawing.Point(0, 27)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.Size = New System.Drawing.Size(473, 265)
        Me.dgResults.TabIndex = 1
        '
        'ColImDetails
        '
        Me.ColImDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColImDetails.Description = "Détails..."
        Me.ColImDetails.HeaderText = ""
        Me.ColImDetails.Image = Global.PointDeVente.My.Resources.Resources.liste
        Me.ColImDetails.Name = "ColImDetails"
        Me.ColImDetails.ReadOnly = True
        Me.ColImDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColImDetails.ToolTipText = "Afficher les détails du client."
        Me.ColImDetails.Width = 5
        '
        'CiviliteDataGridViewTextBoxColumn
        '
        Me.CiviliteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CiviliteDataGridViewTextBoxColumn.DataPropertyName = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.HeaderText = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.Name = "CiviliteDataGridViewTextBoxColumn"
        Me.CiviliteDataGridViewTextBoxColumn.ReadOnly = True
        Me.CiviliteDataGridViewTextBoxColumn.Width = 63
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CodePostalDataGridViewTextBoxColumn
        '
        Me.CodePostalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "CP"
        Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
        Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodePostalDataGridViewTextBoxColumn.Width = 47
        '
        'VilleDataGridViewTextBoxColumn
        '
        Me.VilleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
        Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.VilleDataGridViewTextBoxColumn.Width = 52
        '
        'ctxGrid
        '
        Me.ctxGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FicheClientToolStripMenuItem})
        Me.ctxGrid.Name = "ctxGrid"
        Me.ctxGrid.Size = New System.Drawing.Size(130, 26)
        '
        'FicheClientToolStripMenuItem
        '
        Me.FicheClientToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.liste
        Me.FicheClientToolStripMenuItem.Name = "FicheClientToolStripMenuItem"
        Me.FicheClientToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.FicheClientToolStripMenuItem.Text = "Détails..."
        '
        'RechercheBindingSource
        '
        Me.RechercheBindingSource.DataMember = "Recherche"
        Me.RechercheBindingSource.DataSource = Me.DsAgrifactBindingSource
        '
        'DsAgrifactBindingSource
        '
        Me.DsAgrifactBindingSource.DataSource = Me.DsAgrifact
        Me.DsAgrifactBindingSource.Position = 0
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TxRecherche, Me.ToolStripButton1, Me.BtGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 1, 2)
        Me.ToolStrip1.Size = New System.Drawing.Size(473, 27)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "Recherche"
        '
        'TxRecherche
        '
        Me.TxRecherche.AcceptsReturn = True
        Me.TxRecherche.BackColor = System.Drawing.Color.Ivory
        Me.TxRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxRecherche.MaxLength = 255
        Me.TxRecherche.Name = "TxRecherche"
        Me.TxRecherche.Size = New System.Drawing.Size(379, 23)
        Me.TxRecherche.Text = "Recherche"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.PointDeVente.My.Resources.Resources.close
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton1.Text = "Fermer"
        '
        'BtGo
        '
        Me.BtGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtGo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MotEntierToolStripMenuItem})
        Me.BtGo.Image = Global.PointDeVente.My.Resources.Resources.search
        Me.BtGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtGo.Name = "BtGo"
        Me.BtGo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.BtGo.Size = New System.Drawing.Size(32, 20)
        Me.BtGo.Text = "Chercher"
        '
        'MotEntierToolStripMenuItem
        '
        Me.MotEntierToolStripMenuItem.CheckOnClick = True
        Me.MotEntierToolStripMenuItem.Name = "MotEntierToolStripMenuItem"
        Me.MotEntierToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.MotEntierToolStripMenuItem.Text = "Mot entier"
        '
        'RechercheTableAdapter
        '
        Me.RechercheTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgResults)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 292)
        Me.Panel1.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "type"
        Me.DataGridViewTextBoxColumn1.HeaderText = "type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Civilite"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Civilite"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CodePostal"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Code Postal"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'FrRecherche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 292)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recherche"
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxGrid.ResumeLayout(False)
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifactBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgResults As System.Windows.Forms.DataGridView
    Friend WithEvents DsAgrifactBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents RechercheBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RechercheTableAdapter As PointDeVente.DsAgrifactTableAdapters.RechercheTableAdapter
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxRecherche As ToolStripSpringTextBox
    Friend WithEvents BtGo As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MotEntierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FicheClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColImDetails As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CiviliteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
