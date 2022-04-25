<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrCaisse
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.MnuCaisse = New System.Windows.Forms.ToolStripDropDownButton
        Me.SaisirUnFondDeCaisseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CoffreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RentréeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DépenseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.BtSuppr = New System.Windows.Forms.ToolStripButton
        Me.BtSave = New System.Windows.Forms.ToolStripButton
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.JournalCaisseDataGridView = New System.Windows.Forms.DataGridView
        Me.DateCaisseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantSigneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalCaisseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.lbTotalCaisse = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.JournalCaisseTA = New PointDeVente.DsAgrifactTableAdapters.JournalCaisseTA
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.JournalCaisseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JournalCaisseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCaisse, Me.TbFermer, Me.BtSuppr, Me.BtSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(434, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'MnuCaisse
        '
        Me.MnuCaisse.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaisirUnFondDeCaisseToolStripMenuItem, Me.CoffreToolStripMenuItem, Me.RentréeToolStripMenuItem, Me.DépenseToolStripMenuItem})
        Me.MnuCaisse.Image = Global.PointDeVente.My.Resources.Resources.bi0035_16
        Me.MnuCaisse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MnuCaisse.Name = "MnuCaisse"
        Me.MnuCaisse.Size = New System.Drawing.Size(89, 22)
        Me.MnuCaisse.Text = "Opérations"
        '
        'SaisirUnFondDeCaisseToolStripMenuItem
        '
        Me.SaisirUnFondDeCaisseToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.Retry
        Me.SaisirUnFondDeCaisseToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.SaisirUnFondDeCaisseToolStripMenuItem.Name = "SaisirUnFondDeCaisseToolStripMenuItem"
        Me.SaisirUnFondDeCaisseToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SaisirUnFondDeCaisseToolStripMenuItem.Text = "Fond de caisse..."
        '
        'CoffreToolStripMenuItem
        '
        Me.CoffreToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.RolledBack
        Me.CoffreToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.CoffreToolStripMenuItem.Name = "CoffreToolStripMenuItem"
        Me.CoffreToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CoffreToolStripMenuItem.Text = "Coffre..."
        '
        'RentréeToolStripMenuItem
        '
        Me.RentréeToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.Input
        Me.RentréeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.RentréeToolStripMenuItem.Name = "RentréeToolStripMenuItem"
        Me.RentréeToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RentréeToolStripMenuItem.Text = "Rentrée..."
        '
        'DépenseToolStripMenuItem
        '
        Me.DépenseToolStripMenuItem.Image = Global.PointDeVente.My.Resources.Resources.Output
        Me.DépenseToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.DépenseToolStripMenuItem.Name = "DépenseToolStripMenuItem"
        Me.DépenseToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DépenseToolStripMenuItem.Text = "Dépense..."
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.PointDeVente.My.Resources.Resources.close
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'BtSuppr
        '
        Me.BtSuppr.Image = Global.PointDeVente.My.Resources.Resources.suppr
        Me.BtSuppr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtSuppr.Name = "BtSuppr"
        Me.BtSuppr.Size = New System.Drawing.Size(75, 22)
        Me.BtSuppr.Text = "Supprimer"
        '
        'BtSave
        '
        Me.BtSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtSave.Image = Global.PointDeVente.My.Resources.Resources.save
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(23, 22)
        Me.BtSave.Text = "Enregistrer les données"
        Me.BtSave.Visible = False
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.JournalCaisseDataGridView)
        Me.GradientPanel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(434, 309)
        Me.GradientPanel1.TabIndex = 1
        '
        'JournalCaisseDataGridView
        '
        Me.JournalCaisseDataGridView.AllowUserToAddRows = False
        Me.JournalCaisseDataGridView.AllowUserToDeleteRows = False
        Me.JournalCaisseDataGridView.AutoGenerateColumns = False
        Me.JournalCaisseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateCaisseDataGridViewTextBoxColumn, Me.LibTypeDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.MontantSigneDataGridViewTextBoxColumn})
        Me.JournalCaisseDataGridView.DataSource = Me.JournalCaisseBindingSource
        Me.JournalCaisseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalCaisseDataGridView.Location = New System.Drawing.Point(5, 5)
        Me.JournalCaisseDataGridView.Name = "JournalCaisseDataGridView"
        Me.JournalCaisseDataGridView.ReadOnly = True
        Me.JournalCaisseDataGridView.Size = New System.Drawing.Size(424, 270)
        Me.JournalCaisseDataGridView.TabIndex = 0
        '
        'DateCaisseDataGridViewTextBoxColumn
        '
        Me.DateCaisseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateCaisseDataGridViewTextBoxColumn.DataPropertyName = "DateCaisse"
        DataGridViewCellStyle1.Format = "dd/MM/yy HH:mm"
        Me.DateCaisseDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateCaisseDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateCaisseDataGridViewTextBoxColumn.Name = "DateCaisseDataGridViewTextBoxColumn"
        Me.DateCaisseDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateCaisseDataGridViewTextBoxColumn.Width = 56
        '
        'LibTypeDataGridViewTextBoxColumn
        '
        Me.LibTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LibTypeDataGridViewTextBoxColumn.DataPropertyName = "LibType"
        Me.LibTypeDataGridViewTextBoxColumn.HeaderText = "Opération"
        Me.LibTypeDataGridViewTextBoxColumn.Name = "LibTypeDataGridViewTextBoxColumn"
        Me.LibTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.LibTypeDataGridViewTextBoxColumn.Width = 79
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MontantSigneDataGridViewTextBoxColumn
        '
        Me.MontantSigneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantSigneDataGridViewTextBoxColumn.DataPropertyName = "MontantSigne"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantSigneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantSigneDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantSigneDataGridViewTextBoxColumn.Name = "MontantSigneDataGridViewTextBoxColumn"
        Me.MontantSigneDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantSigneDataGridViewTextBoxColumn.Width = 72
        '
        'JournalCaisseBindingSource
        '
        Me.JournalCaisseBindingSource.DataMember = "JournalCaisse"
        Me.JournalCaisseBindingSource.DataSource = Me.DsAgrifact
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.lbTotalCaisse)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 275)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(424, 29)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'lbTotalCaisse
        '
        Me.lbTotalCaisse.AutoSize = True
        Me.lbTotalCaisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalCaisse.Location = New System.Drawing.Point(357, 6)
        Me.lbTotalCaisse.Name = "lbTotalCaisse"
        Me.lbTotalCaisse.Size = New System.Drawing.Size(64, 16)
        Me.lbTotalCaisse.TabIndex = 0
        Me.lbTotalCaisse.Text = "000,00 €"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Caisse :"
        '
        'JournalCaisseTA
        '
        Me.JournalCaisseTA.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DateCaisse"
        DataGridViewCellStyle3.Format = "dd/MM/yy HH:mm"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "LibType"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Opération"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "MontantSigne"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'FrCaisse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(434, 334)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrCaisse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Journal de caisse"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.JournalCaisseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JournalCaisseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents JournalCaisseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents MnuCaisse As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SaisirUnFondDeCaisseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RentréeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DépenseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoffreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbTotalCaisse As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents JournalCaisseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalCaisseTA As PointDeVente.DsAgrifactTableAdapters.JournalCaisseTA
    Friend WithEvents BtSuppr As System.Windows.Forms.ToolStripButton
    Friend WithEvents DateCaisseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantSigneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class