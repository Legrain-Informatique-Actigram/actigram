<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRechercheEv
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrRechercheEv))
        Me.dgResults = New System.Windows.Forms.DataGridView
        Me.RechercheBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtGo = New System.Windows.Forms.ToolStripSplitButton
        Me.MotEntierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.RechercheEvTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.RechercheEvTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomAuteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateEvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProduitsPresentesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TxRecherche = New ContactsAgrifact.ToolStripSpringTextBox
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.AutoGenerateColumns = False
        Me.dgResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomAuteurDataGridViewTextBoxColumn, Me.NomClientDataGridViewTextBoxColumn, Me.DateEvDataGridViewTextBoxColumn, Me.ProduitsPresentesDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn})
        Me.dgResults.DataSource = Me.RechercheBindingSource
        Me.dgResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgResults.Location = New System.Drawing.Point(0, 27)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.Size = New System.Drawing.Size(512, 285)
        Me.dgResults.TabIndex = 1
        '
        'RechercheBindingSource
        '
        Me.RechercheBindingSource.DataMember = "RechercheEv"
        Me.RechercheBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TxRecherche, Me.BtGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 1, 2)
        Me.ToolStrip1.Size = New System.Drawing.Size(512, 27)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "Recherche"
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
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 312)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(512, 22)
        Me.StatusStrip2.TabIndex = 5
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lbStatus
        '
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(49, 17)
        Me.lbStatus.Text = "lbStatus"
        '
        'RechercheEvTableAdapter
        '
        Me.RechercheEvTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "type"
        Me.DataGridViewTextBoxColumn1.HeaderText = "type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 63
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Civilite"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Civilite"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 58
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Nom"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CodePostal"
        DataGridViewCellStyle3.Format = "d"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "Code Postal"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 65
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 487
        '
        'NomAuteurDataGridViewTextBoxColumn
        '
        Me.NomAuteurDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomAuteurDataGridViewTextBoxColumn.DataPropertyName = "NomAuteur"
        Me.NomAuteurDataGridViewTextBoxColumn.HeaderText = "Auteur"
        Me.NomAuteurDataGridViewTextBoxColumn.Name = "NomAuteurDataGridViewTextBoxColumn"
        Me.NomAuteurDataGridViewTextBoxColumn.ReadOnly = True
        Me.NomAuteurDataGridViewTextBoxColumn.Width = 63
        '
        'NomClientDataGridViewTextBoxColumn
        '
        Me.NomClientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomClientDataGridViewTextBoxColumn.DataPropertyName = "NomClient"
        Me.NomClientDataGridViewTextBoxColumn.HeaderText = "Client"
        Me.NomClientDataGridViewTextBoxColumn.Name = "NomClientDataGridViewTextBoxColumn"
        Me.NomClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.NomClientDataGridViewTextBoxColumn.Width = 58
        '
        'DateEvDataGridViewTextBoxColumn
        '
        Me.DateEvDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateEvDataGridViewTextBoxColumn.DataPropertyName = "DateEv"
        DataGridViewCellStyle1.Format = "d"
        Me.DateEvDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateEvDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateEvDataGridViewTextBoxColumn.Name = "DateEvDataGridViewTextBoxColumn"
        Me.DateEvDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateEvDataGridViewTextBoxColumn.Width = 55
        '
        'ProduitsPresentesDataGridViewTextBoxColumn
        '
        Me.ProduitsPresentesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ProduitsPresentesDataGridViewTextBoxColumn.DataPropertyName = "ProduitsPresentes"
        Me.ProduitsPresentesDataGridViewTextBoxColumn.HeaderText = "Produit"
        Me.ProduitsPresentesDataGridViewTextBoxColumn.Name = "ProduitsPresentesDataGridViewTextBoxColumn"
        Me.ProduitsPresentesDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProduitsPresentesDataGridViewTextBoxColumn.Width = 65
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TxRecherche
        '
        Me.TxRecherche.AcceptsReturn = True
        Me.TxRecherche.BackColor = System.Drawing.Color.AliceBlue
        Me.TxRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxRecherche.MaxLength = 255
        Me.TxRecherche.Name = "TxRecherche"
        Me.TxRecherche.Size = New System.Drawing.Size(441, 23)
        Me.TxRecherche.Text = "Recherche"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Duree"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Durée"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "UniteDuree"
        Me.DataGridViewTextBoxColumn8.HeaderText = ""
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'FrRechercheEv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 334)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrRechercheEv"
        Me.Text = "Recherche des interventions"
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RechercheBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResults As System.Windows.Forms.DataGridView
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents RechercheBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TxRecherche As ToolStripSpringTextBox
    Friend WithEvents BtGo As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MotEntierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RechercheEvTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.RechercheEvTableAdapter
    Friend WithEvents NomAuteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateEvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProduitsPresentesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
