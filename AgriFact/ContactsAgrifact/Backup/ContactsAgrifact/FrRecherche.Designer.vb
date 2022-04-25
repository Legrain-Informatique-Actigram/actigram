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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrRecherche))
        Me.ctxIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RechercherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DossierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.InterventionClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuOpen = New System.Windows.Forms.ToolStripDropDownButton
        Me.dgResults = New System.Windows.Forms.DataGridView
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeIcon = New System.Windows.Forms.DataGridViewImageColumn
        Me.CiviliteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTel = New System.Windows.Forms.DataGridViewImageColumn
        Me.RechercheBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifactBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.notIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.RechercheTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.RechercheTableAdapter
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TxRecherche = New ContactsAgrifact.ToolStripSpringTextBox
        Me.BtGo = New System.Windows.Forms.ToolStripSplitButton
        Me.MotEntierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctxIcon.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifactBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxIcon
        '
        Me.ctxIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechercherToolStripMenuItem, Me.DossierToolStripMenuItem, Me.ToolStripSeparator1, Me.InterventionClientToolStripMenuItem, Me.ToolStripSeparator2, Me.QuitterToolStripMenuItem})
        Me.ctxIcon.Name = "ctxIcon"
        Me.ctxIcon.Size = New System.Drawing.Size(191, 104)
        '
        'RechercherToolStripMenuItem
        '
        Me.RechercherToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RechercherToolStripMenuItem.Image = Global.ContactsAgrifact.My.Resources.Resources.search
        Me.RechercherToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.RechercherToolStripMenuItem.Name = "RechercherToolStripMenuItem"
        Me.RechercherToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.RechercherToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.RechercherToolStripMenuItem.Text = "Rechercher..."
        '
        'DossierToolStripMenuItem
        '
        Me.DossierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParametresToolStripMenuItem})
        Me.DossierToolStripMenuItem.Image = Global.ContactsAgrifact.My.Resources.Resources.open
        Me.DossierToolStripMenuItem.Name = "DossierToolStripMenuItem"
        Me.DossierToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DossierToolStripMenuItem.Text = "Dossier"
        '
        'ParametresToolStripMenuItem
        '
        Me.ParametresToolStripMenuItem.Name = "ParametresToolStripMenuItem"
        Me.ParametresToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ParametresToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ParametresToolStripMenuItem.Text = "Manuel..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(187, 6)
        '
        'InterventionClientToolStripMenuItem
        '
        Me.InterventionClientToolStripMenuItem.Image = Global.ContactsAgrifact.My.Resources.Resources.ExpirationHS
        Me.InterventionClientToolStripMenuItem.Name = "InterventionClientToolStripMenuItem"
        Me.InterventionClientToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.InterventionClientToolStripMenuItem.Text = "Intervention client..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(187, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'MenuOpen
        '
        Me.MenuOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MenuOpen.Image = Global.ContactsAgrifact.My.Resources.Resources.open
        Me.MenuOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuOpen.Name = "MenuOpen"
        Me.MenuOpen.Size = New System.Drawing.Size(29, 20)
        Me.MenuOpen.Text = "ToolStripDropDownButton1"
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.AutoGenerateColumns = False
        Me.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type, Me.TypeIcon, Me.CiviliteDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn, Me.ColTel})
        Me.dgResults.DataSource = Me.RechercheBindingSource
        Me.dgResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgResults.Location = New System.Drawing.Point(0, 27)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.Size = New System.Drawing.Size(479, 251)
        Me.dgResults.TabIndex = 1
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type.DataPropertyName = "type"
        Me.Type.HeaderText = ""
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Visible = False
        '
        'TypeIcon
        '
        Me.TypeIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TypeIcon.HeaderText = ""
        Me.TypeIcon.Name = "TypeIcon"
        Me.TypeIcon.ReadOnly = True
        Me.TypeIcon.Width = 5
        '
        'CiviliteDataGridViewTextBoxColumn
        '
        Me.CiviliteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CiviliteDataGridViewTextBoxColumn.DataPropertyName = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.HeaderText = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.Name = "CiviliteDataGridViewTextBoxColumn"
        Me.CiviliteDataGridViewTextBoxColumn.ReadOnly = True
        Me.CiviliteDataGridViewTextBoxColumn.Width = 62
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
        Me.CodePostalDataGridViewTextBoxColumn.Width = 46
        '
        'VilleDataGridViewTextBoxColumn
        '
        Me.VilleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
        Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.VilleDataGridViewTextBoxColumn.Width = 51
        '
        'ColTel
        '
        Me.ColTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColTel.HeaderText = "Tel."
        Me.ColTel.Image = Global.ContactsAgrifact.My.Resources.Resources.DialHS
        Me.ColTel.Name = "ColTel"
        Me.ColTel.ReadOnly = True
        Me.ColTel.Width = 31
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
        'notIcon
        '
        Me.notIcon.ContextMenuStrip = Me.ctxIcon
        Me.notIcon.Icon = CType(resources.GetObject("notIcon.Icon"), System.Drawing.Icon)
        Me.notIcon.Text = "Contacts Agrifact"
        Me.notIcon.Visible = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 278)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(479, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'RechercheTableAdapter
        '
        Me.RechercheTableAdapter.ClearBeforeFill = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOpen, Me.TxRecherche, Me.BtGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 1, 2)
        Me.ToolStrip1.Size = New System.Drawing.Size(479, 27)
        Me.ToolStrip1.TabIndex = 4
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
        'BtGo
        '
        Me.BtGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtGo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MotEntierToolStripMenuItem})
        Me.BtGo.Image = Global.ContactsAgrifact.My.Resources.Resources.search
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
        Me.MotEntierToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.MotEntierToolStripMenuItem.Text = "Mot entier"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStatus})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 278)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(479, 22)
        Me.StatusStrip2.TabIndex = 5
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lbStatus
        '
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(49, 17)
        Me.lbStatus.Text = "lbStatus"
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
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'FrRecherche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 300)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrRecherche"
        Me.ShowInTaskbar = False
        Me.Text = "Recherche"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ctxIcon.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifactBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResults As System.Windows.Forms.DataGridView
    Friend WithEvents DsAgrifactBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents RechercheBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents notIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ctxIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RechercherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RechercheTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.RechercheTableAdapter
    Friend WithEvents DossierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxRecherche As ToolStripSpringTextBox
    Friend WithEvents BtGo As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MotEntierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuOpen As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents lbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InterventionClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeIcon As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CiviliteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTel As System.Windows.Forms.DataGridViewImageColumn

End Class
