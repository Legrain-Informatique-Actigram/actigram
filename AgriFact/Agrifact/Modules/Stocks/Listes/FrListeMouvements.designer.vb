Namespace Stocks
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrListeMouvements
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
            Me.StocksDataSet = New AgriFact.StocksDataSet
            Me.BindingNavigator1 = New System.Windows.Forms.ToolStrip
            Me.TbFilter = New System.Windows.Forms.ToolStripButton
            Me.TbImpr = New System.Windows.Forms.ToolStripButton
            Me.TbSearch = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.TbSave = New System.Windows.Forms.ToolStripButton
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripSplitButton
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
            Me.TbClose = New System.Windows.Forms.ToolStripButton
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.MouvementDataGridView = New System.Windows.Forms.DataGridView
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ColTypeMouvement = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DepotDepart = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DepotDest = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.MouvementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.CbTypeMvt = New System.Windows.Forms.ComboBox
            Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.dsListeChoix = New AgriFact.StocksDataSet
            Me.Label1 = New System.Windows.Forms.Label
            Me.dtpFin = New System.Windows.Forms.DateTimePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.dtpDeb = New System.Windows.Forms.DateTimePicker
            Me.Label3 = New System.Windows.Forms.Label
            Me.GcFiltrer = New Ascend.Windows.Forms.GradientCaption
            Me.MouvementTableAdapter = New AgriFact.StocksDataSetTableAdapters.MouvementTA
            Me.ListeChoixTableAdapter = New AgriFact.StocksDataSetTableAdapters.ListeChoixTA
            CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MouvementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dsListeChoix, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'StocksDataSet
            '
            Me.StocksDataSet.DataSetName = "StocksDataSet"
            Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSeparator2, Me.TbImpr, Me.TbSearch, Me.TbFilter, Me.TbClose})
            Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
            Me.BindingNavigator1.Name = "BindingNavigator1"
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
            Me.TbFilter.Image = Global.AgriFact.My.Resources.Resources.filter
            Me.TbFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFilter.Name = "TbFilter"
            Me.TbFilter.Size = New System.Drawing.Size(23, 22)
            Me.TbFilter.Text = "Filtrer les transformations"
            '
            'TbImpr
            '
            Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr
            Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbImpr.Name = "TbImpr"
            Me.TbImpr.Size = New System.Drawing.Size(23, 22)
            Me.TbImpr.Text = "Imprimer"
            '
            'TbSearch
            '
            Me.TbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbSearch.Image = Global.AgriFact.My.Resources.Resources.search
            Me.TbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbSearch.Name = "TbSearch"
            Me.TbSearch.Size = New System.Drawing.Size(23, 22)
            Me.TbSearch.Text = "Rechercher"
            '
            'BindingNavigatorSeparator2
            '
            Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
            Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'TbSave
            '
            Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save16
            Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbSave.Name = "TbSave"
            Me.TbSave.Size = New System.Drawing.Size(23, 22)
            Me.TbSave.Text = "Enregistrer"
            '
            'BindingNavigatorAddNewItem
            '
            Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorAddNewItem.Image = Global.AgriFact.My.Resources.Resources.new16
            Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
            Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(32, 22)
            Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
            '
            'BindingNavigatorDeleteItem
            '
            Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorDeleteItem.Image = Global.AgriFact.My.Resources.Resources.suppr
            Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
            Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorDeleteItem.Text = "Supprimer"
            '
            'TbClose
            '
            Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
            Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbClose.Name = "TbClose"
            Me.TbClose.Size = New System.Drawing.Size(23, 22)
            Me.TbClose.Text = "Fermer"
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
            Me.SplitContainer1.Panel1.Controls.Add(Me.MouvementDataGridView)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(682, 305)
            Me.SplitContainer1.SplitterDistance = 499
            Me.SplitContainer1.TabIndex = 4
            '
            'MouvementDataGridView
            '
            Me.MouvementDataGridView.AllowUserToAddRows = False
            Me.MouvementDataGridView.AutoGenerateColumns = False
            Me.MouvementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.ColDate, Me.ColTypeMouvement, Me.DepotDepart, Me.DepotDest, Me.DataGridViewTextBoxColumn11})
            Me.MouvementDataGridView.DataSource = Me.MouvementBindingSource
            Me.MouvementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MouvementDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.MouvementDataGridView.Name = "MouvementDataGridView"
            Me.MouvementDataGridView.ReadOnly = True
            Me.MouvementDataGridView.Size = New System.Drawing.Size(499, 305)
            Me.MouvementDataGridView.TabIndex = 0
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "nPiece"
            Me.DataGridViewTextBoxColumn3.HeaderText = "N°"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Width = 75
            '
            'ColDate
            '
            Me.ColDate.DataPropertyName = "DateMouvement"
            Me.ColDate.HeaderText = "Date"
            Me.ColDate.Name = "ColDate"
            Me.ColDate.ReadOnly = True
            Me.ColDate.Width = 75
            '
            'ColTypeMouvement
            '
            Me.ColTypeMouvement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ColTypeMouvement.DataPropertyName = "TypeMouvement"
            Me.ColTypeMouvement.HeaderText = "Type"
            Me.ColTypeMouvement.Name = "ColTypeMouvement"
            Me.ColTypeMouvement.ReadOnly = True
            Me.ColTypeMouvement.Width = 56
            '
            'DepotDepart
            '
            Me.DepotDepart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DepotDepart.DataPropertyName = "DepotDepart"
            Me.DepotDepart.HeaderText = "Provenance"
            Me.DepotDepart.Name = "DepotDepart"
            Me.DepotDepart.ReadOnly = True
            Me.DepotDepart.Width = 90
            '
            'DepotDest
            '
            Me.DepotDest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DepotDest.DataPropertyName = "DepotDest"
            Me.DepotDest.HeaderText = "Destination"
            Me.DepotDest.Name = "DepotDest"
            Me.DepotDest.ReadOnly = True
            Me.DepotDest.Width = 85
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "Description"
            Me.DataGridViewTextBoxColumn11.HeaderText = "Description"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            '
            'MouvementBindingSource
            '
            Me.MouvementBindingSource.DataMember = "Mouvement"
            Me.MouvementBindingSource.DataSource = Me.StocksDataSet
            Me.MouvementBindingSource.Sort = "DateMouvement desc"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.CbTypeMvt)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.dtpFin)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.dtpDeb)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.GcFiltrer)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(179, 305)
            Me.Panel1.TabIndex = 1
            '
            'CbTypeMvt
            '
            Me.CbTypeMvt.DataSource = Me.ListeChoixBindingSource
            Me.CbTypeMvt.DisplayMember = "Valeur"
            Me.CbTypeMvt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CbTypeMvt.FormattingEnabled = True
            Me.CbTypeMvt.Location = New System.Drawing.Point(39, 30)
            Me.CbTypeMvt.Name = "CbTypeMvt"
            Me.CbTypeMvt.Size = New System.Drawing.Size(119, 21)
            Me.CbTypeMvt.TabIndex = 12
            Me.CbTypeMvt.ValueMember = "Valeur"
            '
            'ListeChoixBindingSource
            '
            Me.ListeChoixBindingSource.DataMember = "ListeChoix"
            Me.ListeChoixBindingSource.DataSource = Me.dsListeChoix
            Me.ListeChoixBindingSource.Filter = ""
            Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
            '
            'dsListeChoix
            '
            Me.dsListeChoix.DataSetName = "StocksDataSet"
            Me.dsListeChoix.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(-3, 33)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(37, 13)
            Me.Label1.TabIndex = 11
            Me.Label1.Text = "Type :"
            '
            'dtpFin
            '
            Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFin.Location = New System.Drawing.Point(39, 83)
            Me.dtpFin.Name = "dtpFin"
            Me.dtpFin.Size = New System.Drawing.Size(89, 20)
            Me.dtpFin.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(-3, 87)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(26, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Au :"
            '
            'dtpDeb
            '
            Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDeb.Location = New System.Drawing.Point(39, 57)
            Me.dtpDeb.Name = "dtpDeb"
            Me.dtpDeb.Size = New System.Drawing.Size(89, 20)
            Me.dtpDeb.TabIndex = 8
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(-3, 61)
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
            Me.GcFiltrer.Image = Global.AgriFact.My.Resources.Resources.filter
            Me.GcFiltrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.GcFiltrer.Location = New System.Drawing.Point(0, 0)
            Me.GcFiltrer.Name = "GcFiltrer"
            Me.GcFiltrer.Size = New System.Drawing.Size(179, 24)
            Me.GcFiltrer.TabIndex = 6
            Me.GcFiltrer.Text = "Filtrer"
            '
            'MouvementTableAdapter
            '
            Me.MouvementTableAdapter.ClearBeforeFill = True
            '
            'ListeChoixTableAdapter
            '
            Me.ListeChoixTableAdapter.ClearBeforeFill = True
            '
            'FrListeMouvements
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 330)
            Me.ControlBox = False
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrListeMouvements"
            Me.Text = "Liste des Mouvements de stock"
            CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MouvementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MouvementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dsListeChoix, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents StocksDataSet As StocksDataSet
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.ToolStrip
        Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
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
        Friend WithEvents MouvementBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents MouvementTableAdapter As StocksDataSetTableAdapters.MouvementTA
        Friend WithEvents MouvementDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents CbTypeMvt As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ListeChoixTableAdapter As StocksDataSetTableAdapters.ListeChoixTA
        Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColTypeMouvement As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DepotDepart As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DepotDest As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbSearch As System.Windows.Forms.ToolStripButton
        Friend WithEvents dsListeChoix As AgriFact.StocksDataSet
        Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripSplitButton
    End Class
End Namespace
