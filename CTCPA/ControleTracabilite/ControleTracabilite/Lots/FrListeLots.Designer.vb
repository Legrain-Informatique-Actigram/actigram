Namespace Lots
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeLots
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeLots))
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
            Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
            Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
            Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
            Me.TbFilter = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.TbClose = New System.Windows.Forms.ToolStripButton
            Me.TbSave = New System.Windows.Forms.ToolStripButton
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.LotDataGridView = New System.Windows.Forms.DataGridView
            Me.LotsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.dtpFin = New System.Windows.Forms.DateTimePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.dtpDeb = New System.Windows.Forms.DateTimePicker
            Me.Label3 = New System.Windows.Forms.Label
            Me.GcFiltrer = New Ascend.Windows.Forms.GradientCaption
            Me.LotTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotTableAdapter
            Me.NLotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DateCreationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ObservationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.TermineDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
            Me.ChkFiltreTermine = New System.Windows.Forms.CheckBox
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.LotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.BindingSource = Me.LotsBindingSource
            Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.TbFilter, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbClose, Me.TbSave})
            Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
            Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
            Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
            Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
            Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
            Me.BindingNavigator1.Name = "BindingNavigator1"
            Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
            Me.BindingNavigator1.Size = New System.Drawing.Size(682, 25)
            Me.BindingNavigator1.TabIndex = 3
            Me.BindingNavigator1.Text = "BindingNavigator1"
            '
            'BindingNavigatorCountItem
            '
            Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
            Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
            Me.BindingNavigatorCountItem.Text = "de {0}"
            Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
            '
            'BindingNavigatorMoveFirstItem
            '
            Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
            Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
            '
            'BindingNavigatorMovePreviousItem
            '
            Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
            Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
            '
            'BindingNavigatorSeparator
            '
            Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
            Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorPositionItem
            '
            Me.BindingNavigatorPositionItem.AccessibleName = "Position"
            Me.BindingNavigatorPositionItem.AutoSize = False
            Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
            Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
            Me.BindingNavigatorPositionItem.Text = "0"
            Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
            '
            'BindingNavigatorSeparator1
            '
            Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
            Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorMoveNextItem
            '
            Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
            Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
            '
            'BindingNavigatorMoveLastItem
            '
            Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
            Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
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
            Me.TbFilter.Text = "Filtrer les transformations"
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
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.AutoScroll = True
            Me.SplitContainer1.Panel1.Controls.Add(Me.LotDataGridView)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(682, 305)
            Me.SplitContainer1.SplitterDistance = 523
            Me.SplitContainer1.TabIndex = 4
            '
            'LotDataGridView
            '
            Me.LotDataGridView.AllowUserToAddRows = False
            Me.LotDataGridView.AutoGenerateColumns = False
            Me.LotDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NLotDataGridViewTextBoxColumn, Me.DateCreationDataGridViewTextBoxColumn, Me.ObservationDataGridViewTextBoxColumn, Me.TermineDataGridViewCheckBoxColumn})
            Me.LotDataGridView.DataSource = Me.LotsBindingSource
            Me.LotDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LotDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.LotDataGridView.Name = "LotDataGridView"
            Me.LotDataGridView.ReadOnly = True
            Me.LotDataGridView.Size = New System.Drawing.Size(523, 305)
            Me.LotDataGridView.TabIndex = 0
            '
            'LotsBindingSource
            '
            Me.LotsBindingSource.DataMember = "Lot"
            Me.LotsBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.LotsBindingSource.Sort = "DateCreation desc"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.ChkFiltreTermine)
            Me.Panel1.Controls.Add(Me.dtpFin)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.dtpDeb)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.GcFiltrer)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(155, 305)
            Me.Panel1.TabIndex = 1
            '
            'dtpFin
            '
            Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFin.Location = New System.Drawing.Point(36, 78)
            Me.dtpFin.Name = "dtpFin"
            Me.dtpFin.Size = New System.Drawing.Size(89, 20)
            Me.dtpFin.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(2, 82)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(26, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Au :"
            '
            'dtpDeb
            '
            Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDeb.Location = New System.Drawing.Point(36, 53)
            Me.dtpDeb.Name = "dtpDeb"
            Me.dtpDeb.Size = New System.Drawing.Size(89, 20)
            Me.dtpDeb.TabIndex = 8
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 57)
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
            Me.GcFiltrer.Size = New System.Drawing.Size(155, 24)
            Me.GcFiltrer.TabIndex = 6
            Me.GcFiltrer.Text = "Filtrer"
            '
            'LotTableAdapter
            '
            Me.LotTableAdapter.ClearBeforeFill = True
            '
            'NLotDataGridViewTextBoxColumn
            '
            Me.NLotDataGridViewTextBoxColumn.DataPropertyName = "nLot"
            Me.NLotDataGridViewTextBoxColumn.HeaderText = "Lot"
            Me.NLotDataGridViewTextBoxColumn.Name = "NLotDataGridViewTextBoxColumn"
            Me.NLotDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DateCreationDataGridViewTextBoxColumn
            '
            Me.DateCreationDataGridViewTextBoxColumn.DataPropertyName = "DateCreation"
            Me.DateCreationDataGridViewTextBoxColumn.HeaderText = "Date"
            Me.DateCreationDataGridViewTextBoxColumn.Name = "DateCreationDataGridViewTextBoxColumn"
            Me.DateCreationDataGridViewTextBoxColumn.ReadOnly = True
            Me.DateCreationDataGridViewTextBoxColumn.Width = 75
            '
            'ObservationDataGridViewTextBoxColumn
            '
            Me.ObservationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ObservationDataGridViewTextBoxColumn.DataPropertyName = "Observation"
            Me.ObservationDataGridViewTextBoxColumn.HeaderText = "Observation"
            Me.ObservationDataGridViewTextBoxColumn.Name = "ObservationDataGridViewTextBoxColumn"
            Me.ObservationDataGridViewTextBoxColumn.ReadOnly = True
            '
            'TermineDataGridViewCheckBoxColumn
            '
            Me.TermineDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.TermineDataGridViewCheckBoxColumn.DataPropertyName = "Termine"
            Me.TermineDataGridViewCheckBoxColumn.HeaderText = "Terminé"
            Me.TermineDataGridViewCheckBoxColumn.Name = "TermineDataGridViewCheckBoxColumn"
            Me.TermineDataGridViewCheckBoxColumn.ReadOnly = True
            Me.TermineDataGridViewCheckBoxColumn.Width = 52
            '
            'ChkFiltreTermine
            '
            Me.ChkFiltreTermine.AutoSize = True
            Me.ChkFiltreTermine.Location = New System.Drawing.Point(5, 30)
            Me.ChkFiltreTermine.Name = "ChkFiltreTermine"
            Me.ChkFiltreTermine.Size = New System.Drawing.Size(148, 17)
            Me.ChkFiltreTermine.TabIndex = 11
            Me.ChkFiltreTermine.Text = "Lots en cours uniquement"
            Me.ChkFiltreTermine.UseVisualStyleBackColor = True
            '
            'FrListeLots
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 330)
            Me.ControlBox = False
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrListeLots"
            Me.Text = "Liste des Lots"
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.LotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GcFiltrer As Ascend.Windows.Forms.GradientCaption
        Friend WithEvents LotsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LotDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents LotTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotTableAdapter
        Friend WithEvents NLotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DateCreationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ObservationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TermineDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents ChkFiltreTermine As System.Windows.Forms.CheckBox
    End Class
End Namespace
