<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeFactures
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
        Me.dsAgrifact = New PointDeVente.DsAgrifact
        Me.FactBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FactDataGridView = New System.Windows.Forms.DataGridView
        Me.DateFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nFacture = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomClient = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdresseFacture = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantTTC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Termine = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VFactureTA = New PointDeVente.DsAgrifactTableAdapters.VFactureTA
        Me.EntrepriseTA = New PointDeVente.DsAgrifactTableAdapters.EntrepriseTA
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkFactPayees = New System.Windows.Forms.CheckBox
        Me.ChkClient = New System.Windows.Forms.CheckBox
        Me.dtpFin = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpDeb = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GcFiltrer = New Ascend.Windows.Forms.GradientCaption
        Me.CbClient = New System.Windows.Forms.ComboBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(Me.dsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FactBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FactDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dsAgrifact
        '
        Me.dsAgrifact.DataSetName = "dsAgrifact"
        Me.dsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FactBindingSource
        '
        Me.FactBindingSource.DataMember = "VFacture"
        Me.FactBindingSource.DataSource = Me.dsAgrifact
        Me.FactBindingSource.Sort = "nFacture desc"
        '
        'FactDataGridView
        '
        Me.FactDataGridView.AllowUserToAddRows = False
        Me.FactDataGridView.AllowUserToDeleteRows = False
        Me.FactDataGridView.AutoGenerateColumns = False
        Me.FactDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateFactureDataGridViewTextBoxColumn, Me.nFacture, Me.NomClient, Me.AdresseFacture, Me.MontantTTC, Me.Termine})
        Me.FactDataGridView.DataSource = Me.FactBindingSource
        Me.FactDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FactDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.FactDataGridView.MultiSelect = False
        Me.FactDataGridView.Name = "FactDataGridView"
        Me.FactDataGridView.ReadOnly = True
        Me.FactDataGridView.Size = New System.Drawing.Size(507, 305)
        Me.FactDataGridView.TabIndex = 1
        '
        'DateFactureDataGridViewTextBoxColumn
        '
        Me.DateFactureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateFactureDataGridViewTextBoxColumn.DataPropertyName = "DateFacture"
        Me.DateFactureDataGridViewTextBoxColumn.FillWeight = 1.0!
        Me.DateFactureDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateFactureDataGridViewTextBoxColumn.Name = "DateFactureDataGridViewTextBoxColumn"
        Me.DateFactureDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateFactureDataGridViewTextBoxColumn.Width = 56
        '
        'nFacture
        '
        Me.nFacture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nFacture.DataPropertyName = "nFacture"
        Me.nFacture.HeaderText = "N°"
        Me.nFacture.Name = "nFacture"
        Me.nFacture.ReadOnly = True
        Me.nFacture.Width = 45
        '
        'NomClient
        '
        Me.NomClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NomClient.DataPropertyName = "NomClient"
        Me.NomClient.FillWeight = 1.0!
        Me.NomClient.HeaderText = "Client"
        Me.NomClient.Name = "NomClient"
        Me.NomClient.ReadOnly = True
        Me.NomClient.Width = 59
        '
        'AdresseFacture
        '
        Me.AdresseFacture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AdresseFacture.DataPropertyName = "AdresseFacture"
        Me.AdresseFacture.HeaderText = "Adresse"
        Me.AdresseFacture.Name = "AdresseFacture"
        Me.AdresseFacture.ReadOnly = True
        '
        'MontantTTC
        '
        Me.MontantTTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantTTC.DataPropertyName = "MontantTTC"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantTTC.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantTTC.HeaderText = "Montant TTC"
        Me.MontantTTC.Name = "MontantTTC"
        Me.MontantTTC.ReadOnly = True
        Me.MontantTTC.Width = 96
        '
        'Termine
        '
        Me.Termine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Termine.DataPropertyName = "Paye"
        Me.Termine.HeaderText = "Reglé"
        Me.Termine.Name = "Termine"
        Me.Termine.ReadOnly = True
        Me.Termine.Width = 42
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomFamille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unite1"
        Me.DataGridViewTextBoxColumn4.HeaderText = "U1"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
        Me.DataGridViewTextBoxColumn5.HeaderText = "U2"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'VFactureTA
        '
        Me.VFactureTA.ClearBeforeFill = True
        '
        'EntrepriseTA
        '
        Me.EntrepriseTA.ClearBeforeFill = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FactDataGridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(682, 305)
        Me.SplitContainer1.SplitterDistance = 507
        Me.SplitContainer1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ChkFactPayees)
        Me.Panel1.Controls.Add(Me.ChkClient)
        Me.Panel1.Controls.Add(Me.dtpFin)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpDeb)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GcFiltrer)
        Me.Panel1.Controls.Add(Me.CbClient)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(171, 305)
        Me.Panel1.TabIndex = 1
        '
        'ChkFactPayees
        '
        Me.ChkFactPayees.AutoSize = True
        Me.ChkFactPayees.Location = New System.Drawing.Point(3, 30)
        Me.ChkFactPayees.Name = "ChkFactPayees"
        Me.ChkFactPayees.Size = New System.Drawing.Size(156, 17)
        Me.ChkFactPayees.TabIndex = 12
        Me.ChkFactPayees.Text = "Afficher les factures réglées"
        Me.ChkFactPayees.UseVisualStyleBackColor = True
        '
        'ChkClient
        '
        Me.ChkClient.AutoSize = True
        Me.ChkClient.Location = New System.Drawing.Point(3, 53)
        Me.ChkClient.Name = "ChkClient"
        Me.ChkClient.Size = New System.Drawing.Size(120, 17)
        Me.ChkClient.TabIndex = 11
        Me.ChkClient.Text = "Filtrer pour le client :"
        Me.ChkClient.UseVisualStyleBackColor = True
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(45, 131)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(89, 20)
        Me.dtpFin.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Au :"
        '
        'dtpDeb
        '
        Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeb.Location = New System.Drawing.Point(45, 105)
        Me.dtpDeb.Name = "dtpDeb"
        Me.dtpDeb.Size = New System.Drawing.Size(89, 20)
        Me.dtpDeb.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Du :"
        '
        'GcFiltrer
        '
        Me.GcFiltrer.Border = New Ascend.Border(0, 1, 0, 2)
        Me.GcFiltrer.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.GcFiltrer.Dock = System.Windows.Forms.DockStyle.Top
        Me.GcFiltrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GcFiltrer.GradientHighColor = System.Drawing.SystemColors.InactiveCaption
        Me.GcFiltrer.GradientLowColor = System.Drawing.SystemColors.Window
        Me.GcFiltrer.Image = Global.PointDeVente.My.Resources.Resources.filter
        Me.GcFiltrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GcFiltrer.Location = New System.Drawing.Point(0, 0)
        Me.GcFiltrer.Name = "GcFiltrer"
        Me.GcFiltrer.Size = New System.Drawing.Size(171, 24)
        Me.GcFiltrer.TabIndex = 6
        Me.GcFiltrer.Text = "Filtrer"
        '
        'CbClient
        '
        Me.CbClient.DataSource = Me.EntrepriseBindingSource
        Me.CbClient.DisplayMember = "Nom"
        Me.CbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbClient.FormattingEnabled = True
        Me.CbClient.Location = New System.Drawing.Point(3, 76)
        Me.CbClient.Name = "CbClient"
        Me.CbClient.Size = New System.Drawing.Size(160, 21)
        Me.CbClient.TabIndex = 1
        Me.CbClient.ValueMember = "nEntreprise"
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.dsAgrifact
        '
        'TbFilter
        '
        Me.TbFilter.Checked = True
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.PointDeVente.My.Resources.Resources.filter
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 22)
        Me.TbFilter.Text = "Filtrer les factures"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.PointDeVente.My.Resources.Resources.close
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.FactBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFilter, Me.TbClose})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(682, 25)
        Me.BindingNavigator1.TabIndex = 3
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'FrListeFactures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 330)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrListeFactures"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des Factures"
        CType(Me.dsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FactBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FactDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dsAgrifact As DsAgrifact
    Friend WithEvents FactBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FactDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VFactureTA As DsAgrifactTableAdapters.VFactureTA
    Friend WithEvents EntrepriseTA As DsAgrifactTableAdapters.EntrepriseTA
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ChkClient As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GcFiltrer As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents CbClient As System.Windows.Forms.ComboBox
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ChkFactPayees As System.Windows.Forms.CheckBox
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents DateFactureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nFacture As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomClient As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdresseFacture As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantTTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Termine As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
