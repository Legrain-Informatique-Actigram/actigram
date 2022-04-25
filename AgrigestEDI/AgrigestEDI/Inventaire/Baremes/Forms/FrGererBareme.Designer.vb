<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrGererBareme
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGererBareme))
        Me.BAREMEDataGridView = New System.Windows.Forms.DataGridView
        Me.IDMATERIELDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.MATERIELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.INFO_COMPL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ANNEE_BAREME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BAREMEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ANNEE_BAREMETextBox = New System.Windows.Forms.TextBox
        Me.FiltrerButton = New System.Windows.Forms.Button
        Me.BAREMETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.BAREMETableAdapter
        Me.MATERIELTableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.MATERIELTableAdapter
        Me.ImporterBaremeButton = New System.Windows.Forms.Button
        Me.BAREMEBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.AjouterToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EnregistrerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        CType(Me.BAREMEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATERIELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREMEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREMEBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BAREMEBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'BAREMEDataGridView
        '
        Me.BAREMEDataGridView.AllowUserToAddRows = False
        Me.BAREMEDataGridView.AllowUserToDeleteRows = False
        Me.BAREMEDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BAREMEDataGridView.AutoGenerateColumns = False
        Me.BAREMEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BAREMEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDMATERIELDataGridViewComboBoxColumn, Me.INFO_COMPL, Me.ANNEE_BAREME, Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn})
        Me.BAREMEDataGridView.DataSource = Me.BAREMEBindingSource
        Me.BAREMEDataGridView.Location = New System.Drawing.Point(12, 57)
        Me.BAREMEDataGridView.Name = "BAREMEDataGridView"
        Me.BAREMEDataGridView.Size = New System.Drawing.Size(815, 569)
        Me.BAREMEDataGridView.TabIndex = 0
        '
        'IDMATERIELDataGridViewComboBoxColumn
        '
        Me.IDMATERIELDataGridViewComboBoxColumn.DataPropertyName = "ID_MATERIEL"
        Me.IDMATERIELDataGridViewComboBoxColumn.DataSource = Me.MATERIELBindingSource
        Me.IDMATERIELDataGridViewComboBoxColumn.DisplayMember = "LIBELLE_MATERIEL"
        Me.IDMATERIELDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.IDMATERIELDataGridViewComboBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IDMATERIELDataGridViewComboBoxColumn.HeaderText = "Matériel"
        Me.IDMATERIELDataGridViewComboBoxColumn.MaxDropDownItems = 20
        Me.IDMATERIELDataGridViewComboBoxColumn.Name = "IDMATERIELDataGridViewComboBoxColumn"
        Me.IDMATERIELDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDMATERIELDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IDMATERIELDataGridViewComboBoxColumn.ValueMember = "ID_MATERIEL"
        Me.IDMATERIELDataGridViewComboBoxColumn.Width = 400
        '
        'MATERIELBindingSource
        '
        Me.MATERIELBindingSource.DataMember = "MATERIEL"
        Me.MATERIELBindingSource.DataSource = Me.DataSetBaremes
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'INFO_COMPL
        '
        Me.INFO_COMPL.DataPropertyName = "INFO_COMPL"
        Me.INFO_COMPL.HeaderText = "Info compl."
        Me.INFO_COMPL.Name = "INFO_COMPL"
        Me.INFO_COMPL.Width = 150
        '
        'ANNEE_BAREME
        '
        Me.ANNEE_BAREME.DataPropertyName = "ANNEE_BAREME"
        Me.ANNEE_BAREME.HeaderText = "Année"
        Me.ANNEE_BAREME.Name = "ANNEE_BAREME"
        Me.ANNEE_BAREME.ReadOnly = True
        '
        'COUTTOTALPARHEUREDataGridViewTextBoxColumn
        '
        Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn.DataPropertyName = "COUT_TOTAL_PAR_HEURE"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn.HeaderText = "Coût/h"
        Me.COUTTOTALPARHEUREDataGridViewTextBoxColumn.Name = "COUTTOTALPARHEUREDataGridViewTextBoxColumn"
        '
        'BAREMEBindingSource
        '
        Me.BAREMEBindingSource.DataMember = "BAREME"
        Me.BAREMEBindingSource.DataSource = Me.DataSetBaremes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Année :"
        '
        'ANNEE_BAREMETextBox
        '
        Me.ANNEE_BAREMETextBox.Location = New System.Drawing.Point(59, 30)
        Me.ANNEE_BAREMETextBox.Name = "ANNEE_BAREMETextBox"
        Me.ANNEE_BAREMETextBox.Size = New System.Drawing.Size(59, 20)
        Me.ANNEE_BAREMETextBox.TabIndex = 2
        '
        'FiltrerButton
        '
        Me.FiltrerButton.Location = New System.Drawing.Point(124, 28)
        Me.FiltrerButton.Name = "FiltrerButton"
        Me.FiltrerButton.Size = New System.Drawing.Size(79, 23)
        Me.FiltrerButton.TabIndex = 3
        Me.FiltrerButton.Text = "Filtrer"
        Me.FiltrerButton.UseVisualStyleBackColor = True
        '
        'BAREMETableAdapter
        '
        Me.BAREMETableAdapter.ClearBeforeFill = True
        '
        'MATERIELTableAdapter
        '
        Me.MATERIELTableAdapter.ClearBeforeFill = True
        '
        'ImporterBaremeButton
        '
        Me.ImporterBaremeButton.Location = New System.Drawing.Point(658, 28)
        Me.ImporterBaremeButton.Name = "ImporterBaremeButton"
        Me.ImporterBaremeButton.Size = New System.Drawing.Size(169, 23)
        Me.ImporterBaremeButton.TabIndex = 5
        Me.ImporterBaremeButton.Text = "Importer le barème d'une année"
        Me.ImporterBaremeButton.UseVisualStyleBackColor = True
        '
        'BAREMEBindingNavigator
        '
        Me.BAREMEBindingNavigator.AddNewItem = Nothing
        Me.BAREMEBindingNavigator.BindingSource = Me.BAREMEBindingSource
        Me.BAREMEBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BAREMEBindingNavigator.DeleteItem = Nothing
        Me.BAREMEBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.AjouterToolStripButton, Me.EnregistrerToolStripButton, Me.SupprimerToolStripButton})
        Me.BAREMEBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.BAREMEBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BAREMEBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BAREMEBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BAREMEBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BAREMEBindingNavigator.Name = "BAREMEBindingNavigator"
        Me.BAREMEBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BAREMEBindingNavigator.Size = New System.Drawing.Size(836, 25)
        Me.BAREMEBindingNavigator.TabIndex = 6
        Me.BAREMEBindingNavigator.Text = "BAREMEBindingNavigator"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
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
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AjouterToolStripButton
        '
        Me.AjouterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AjouterToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.NewDocumentHS
        Me.AjouterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AjouterToolStripButton.Name = "AjouterToolStripButton"
        Me.AjouterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AjouterToolStripButton.Text = "Ajouter"
        '
        'EnregistrerToolStripButton
        '
        Me.EnregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EnregistrerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.EnregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EnregistrerToolStripButton.Name = "EnregistrerToolStripButton"
        Me.EnregistrerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.EnregistrerToolStripButton.Text = "Enregistrer"
        '
        'SupprimerToolStripButton
        '
        Me.SupprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.SupprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerToolStripButton.Name = "SupprimerToolStripButton"
        Me.SupprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SupprimerToolStripButton.Text = "Supprimer"
        '
        'FrGererBareme
        '
        Me.AcceptButton = Me.FiltrerButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(836, 638)
        Me.Controls.Add(Me.BAREMEBindingNavigator)
        Me.Controls.Add(Me.ImporterBaremeButton)
        Me.Controls.Add(Me.FiltrerButton)
        Me.Controls.Add(Me.ANNEE_BAREMETextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BAREMEDataGridView)
        Me.Name = "FrGererBareme"
        Me.Text = "Gérer les barèmes"
        CType(Me.BAREMEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATERIELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREMEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREMEBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BAREMEBindingNavigator.ResumeLayout(False)
        Me.BAREMEBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents BAREMEDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ANNEE_BAREMETextBox As System.Windows.Forms.TextBox
    Friend WithEvents FiltrerButton As System.Windows.Forms.Button
    Friend WithEvents BAREMEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BAREMETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.BAREMETableAdapter
    Friend WithEvents MATERIELBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MATERIELTableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.MATERIELTableAdapter
    Friend WithEvents ImporterBaremeButton As System.Windows.Forms.Button
    Friend WithEvents NBHEURESPARANDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMATERIELDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents INFO_COMPL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANNEE_BAREME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUTTOTALPARHEUREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BAREMEBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EnregistrerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
End Class
