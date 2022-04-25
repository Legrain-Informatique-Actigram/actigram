Namespace Receptions
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeBR
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeBR))
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.BRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.BRDataGridView = New System.Windows.Forms.DataGridView
            Me.DateFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.NomClient = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Observation = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Termine = New System.Windows.Forms.DataGridViewCheckBoxColumn
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.TbFilter = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.TbClose = New System.Windows.Forms.ToolStripButton
            Me.TbSave = New System.Windows.Forms.ToolStripButton
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ABonReceptionTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.ChkFiltreTermine = New System.Windows.Forms.CheckBox
            Me.ChkFourn = New System.Windows.Forms.CheckBox
            Me.dtpFin = New System.Windows.Forms.DateTimePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.dtpDeb = New System.Windows.Forms.DateTimePicker
            Me.Label3 = New System.Windows.Forms.Label
            Me.GcFiltrer = New Ascend.Windows.Forms.GradientCaption
            Me.CbFournisseur = New System.Windows.Forms.ComboBox
            Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BRDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BRBindingSource
            '
            Me.BRBindingSource.DataMember = "ABonReception"
            Me.BRBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.BRBindingSource.Sort = "nFacture desc"
            '
            'BRDataGridView
            '
            Me.BRDataGridView.AllowUserToAddRows = False
            Me.BRDataGridView.AllowUserToDeleteRows = False
            Me.BRDataGridView.AutoGenerateColumns = False
            Me.BRDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateFactureDataGridViewTextBoxColumn, Me.NomClient, Me.Observation, Me.Termine})
            Me.BRDataGridView.DataSource = Me.BRBindingSource
            Me.BRDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BRDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.BRDataGridView.MultiSelect = False
            Me.BRDataGridView.Name = "BRDataGridView"
            Me.BRDataGridView.ReadOnly = True
            Me.BRDataGridView.Size = New System.Drawing.Size(507, 305)
            Me.BRDataGridView.TabIndex = 1
            '
            'DateFactureDataGridViewTextBoxColumn
            '
            Me.DateFactureDataGridViewTextBoxColumn.DataPropertyName = "DateFacture"
            Me.DateFactureDataGridViewTextBoxColumn.FillWeight = 1.0!
            Me.DateFactureDataGridViewTextBoxColumn.HeaderText = "Date"
            Me.DateFactureDataGridViewTextBoxColumn.Name = "DateFactureDataGridViewTextBoxColumn"
            Me.DateFactureDataGridViewTextBoxColumn.ReadOnly = True
            Me.DateFactureDataGridViewTextBoxColumn.Width = 75
            '
            'NomClient
            '
            Me.NomClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.NomClient.DataPropertyName = "NomClient"
            Me.NomClient.FillWeight = 1.0!
            Me.NomClient.HeaderText = "Fournisseur"
            Me.NomClient.Name = "NomClient"
            Me.NomClient.ReadOnly = True
            Me.NomClient.Width = 86
            '
            'Observation
            '
            Me.Observation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.Observation.DataPropertyName = "Observation"
            Me.Observation.HeaderText = "Observation"
            Me.Observation.Name = "Observation"
            Me.Observation.ReadOnly = True
            '
            'Termine
            '
            Me.Termine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.Termine.DataPropertyName = "Termine"
            Me.Termine.HeaderText = "Terminé"
            Me.Termine.Name = "Termine"
            Me.Termine.ReadOnly = True
            Me.Termine.Width = 51
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.BRBindingSource
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFilter, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbClose, Me.TbSave})
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
            'TbFilter
            '
            Me.TbFilter.Checked = True
            Me.TbFilter.CheckOnClick = True
            Me.TbFilter.CheckState = System.Windows.Forms.CheckState.Checked
            Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFilter.Image = Global.ControleTracabilite.My.Resources.Resources.filter
            Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFilter.Name = "TbFilter"
            Me.TbFilter.Size = New System.Drawing.Size(23, 22)
            Me.TbFilter.Text = "Filtrer les bons de réception"
            '
            'BindingNavigatorSeparator2
            '
            Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
            Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorAddNewItem
            '
            Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorAddNewItem.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
            Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
            '
            'BindingNavigatorDeleteItem
            '
            Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
            Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorDeleteItem.Text = "Supprimer"
            '
            'TbClose
            '
            Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbClose.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbClose.Name = "TbClose"
            Me.TbClose.Size = New System.Drawing.Size(23, 22)
            Me.TbClose.Text = "Fermer"
            '
            'TbSave
            '
            Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbSave.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbSave.Name = "TbSave"
            Me.TbSave.Size = New System.Drawing.Size(23, 22)
            Me.TbSave.Text = "Enregistrer"
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
            'ABonReceptionTableAdapter
            '
            Me.ABonReceptionTableAdapter.ClearBeforeFill = True
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
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
            Me.SplitContainer1.Panel1.Controls.Add(Me.BRDataGridView)
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
            Me.Panel1.Controls.Add(Me.ChkFiltreTermine)
            Me.Panel1.Controls.Add(Me.ChkFourn)
            Me.Panel1.Controls.Add(Me.dtpFin)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.dtpDeb)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.GcFiltrer)
            Me.Panel1.Controls.Add(Me.CbFournisseur)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(171, 305)
            Me.Panel1.TabIndex = 1
            '
            'ChkFiltreTermine
            '
            Me.ChkFiltreTermine.AutoSize = True
            Me.ChkFiltreTermine.Location = New System.Drawing.Point(3, 30)
            Me.ChkFiltreTermine.Name = "ChkFiltreTermine"
            Me.ChkFiltreTermine.Size = New System.Drawing.Size(139, 17)
            Me.ChkFiltreTermine.TabIndex = 12
            Me.ChkFiltreTermine.Text = "Afficher les lots terminés"
            Me.ChkFiltreTermine.UseVisualStyleBackColor = True
            '
            'ChkFourn
            '
            Me.ChkFourn.AutoSize = True
            Me.ChkFourn.Location = New System.Drawing.Point(3, 53)
            Me.ChkFourn.Name = "ChkFourn"
            Me.ChkFourn.Size = New System.Drawing.Size(146, 17)
            Me.ChkFourn.TabIndex = 11
            Me.ChkFourn.Text = "Filtrer pour le fournisseur :"
            Me.ChkFourn.UseVisualStyleBackColor = True
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
            Me.GcFiltrer.Image = Global.ControleTracabilite.My.Resources.Resources.filter
            Me.GcFiltrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.GcFiltrer.Location = New System.Drawing.Point(0, 0)
            Me.GcFiltrer.Name = "GcFiltrer"
            Me.GcFiltrer.Size = New System.Drawing.Size(171, 24)
            Me.GcFiltrer.TabIndex = 6
            Me.GcFiltrer.Text = "Filtrer"
            '
            'CbFournisseur
            '
            Me.CbFournisseur.DataSource = Me.EntrepriseBindingSource
            Me.CbFournisseur.DisplayMember = "Nom"
            Me.CbFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CbFournisseur.FormattingEnabled = True
            Me.CbFournisseur.Location = New System.Drawing.Point(3, 76)
            Me.CbFournisseur.Name = "CbFournisseur"
            Me.CbFournisseur.Size = New System.Drawing.Size(160, 21)
            Me.CbFournisseur.TabIndex = 1
            Me.CbFournisseur.ValueMember = "nEntreprise"
            '
            'EntrepriseBindingSource
            '
            Me.EntrepriseBindingSource.DataMember = "Entreprise"
            Me.EntrepriseBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'FrListeBR
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 330)
            Me.ControlBox = False
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrListeBR"
            Me.Text = "Liste des Réceptions"
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BRDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents BRBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BRDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ABonReceptionTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ChkFourn As System.Windows.Forms.CheckBox
        Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GcFiltrer As Ascend.Windows.Forms.GradientCaption
        Friend WithEvents CbFournisseur As System.Windows.Forms.ComboBox
        Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ChkFiltreTermine As System.Windows.Forms.CheckBox
        Friend WithEvents DateFactureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NomClient As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Observation As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Termine As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace
