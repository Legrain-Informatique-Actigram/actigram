<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrGererBaremeForfaitaire
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGererBaremeForfaitaire))
        Me.ImporterBaremeButton = New System.Windows.Forms.Button
        Me.FiltrerButton = New System.Windows.Forms.Button
        Me.ANNEE_BAREME_FORFAITAIRETextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BAREME_FORFAITAIREDataGridView = New System.Windows.Forms.DataGridView
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.FACON_CULTURALEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBaremes = New AgrigestEDI.DataSetBaremes
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BAREME_FORFAITAIREBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BAREME_FORFAITAIRETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter
        Me.FACON_CULTURALETableAdapter = New AgrigestEDI.DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter
        Me.BAREME_FORFAITAIREBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        CType(Me.BAREME_FORFAITAIREDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FACON_CULTURALEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREME_FORFAITAIREBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAREME_FORFAITAIREBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BAREME_FORFAITAIREBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImporterBaremeButton
        '
        Me.ImporterBaremeButton.Location = New System.Drawing.Point(642, 28)
        Me.ImporterBaremeButton.Name = "ImporterBaremeButton"
        Me.ImporterBaremeButton.Size = New System.Drawing.Size(187, 23)
        Me.ImporterBaremeButton.TabIndex = 9
        Me.ImporterBaremeButton.Text = "Importer le barème d'une année"
        Me.ImporterBaremeButton.UseVisualStyleBackColor = True
        '
        'FiltrerButton
        '
        Me.FiltrerButton.Location = New System.Drawing.Point(124, 28)
        Me.FiltrerButton.Name = "FiltrerButton"
        Me.FiltrerButton.Size = New System.Drawing.Size(79, 23)
        Me.FiltrerButton.TabIndex = 8
        Me.FiltrerButton.Text = "Filtrer"
        Me.FiltrerButton.UseVisualStyleBackColor = True
        '
        'ANNEE_BAREME_FORFAITAIRETextBox
        '
        Me.ANNEE_BAREME_FORFAITAIRETextBox.Location = New System.Drawing.Point(59, 30)
        Me.ANNEE_BAREME_FORFAITAIRETextBox.Name = "ANNEE_BAREME_FORFAITAIRETextBox"
        Me.ANNEE_BAREME_FORFAITAIRETextBox.Size = New System.Drawing.Size(59, 20)
        Me.ANNEE_BAREME_FORFAITAIRETextBox.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Année :"
        '
        'BAREME_FORFAITAIREDataGridView
        '
        Me.BAREME_FORFAITAIREDataGridView.AllowUserToAddRows = False
        Me.BAREME_FORFAITAIREDataGridView.AllowUserToDeleteRows = False
        Me.BAREME_FORFAITAIREDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BAREME_FORFAITAIREDataGridView.AutoGenerateColumns = False
        Me.BAREME_FORFAITAIREDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BAREME_FORFAITAIREDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFACONCULTURALEDataGridViewComboBoxColumn, Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn, Me.VALEURFORFAITAIREDataGridViewTextBoxColumn})
        Me.BAREME_FORFAITAIREDataGridView.DataSource = Me.BAREME_FORFAITAIREBindingSource
        Me.BAREME_FORFAITAIREDataGridView.Location = New System.Drawing.Point(12, 57)
        Me.BAREME_FORFAITAIREDataGridView.Name = "BAREME_FORFAITAIREDataGridView"
        Me.BAREME_FORFAITAIREDataGridView.Size = New System.Drawing.Size(817, 512)
        Me.BAREME_FORFAITAIREDataGridView.TabIndex = 10
        '
        'IDFACONCULTURALEDataGridViewComboBoxColumn
        '
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.DataPropertyName = "ID_FACON_CULTURALE"
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.DataSource = Me.FACON_CULTURALEBindingSource
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.DisplayMember = "LIBELLE_FACON_CULTURALE"
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.HeaderText = "Façon culturale"
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.MaxDropDownItems = 20
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.Name = "IDFACONCULTURALEDataGridViewComboBoxColumn"
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.ValueMember = "ID_FACON_CULTURALE"
        Me.IDFACONCULTURALEDataGridViewComboBoxColumn.Width = 258
        '
        'FACON_CULTURALEBindingSource
        '
        Me.FACON_CULTURALEBindingSource.DataMember = "FACON_CULTURALE"
        Me.FACON_CULTURALEBindingSource.DataSource = Me.DataSetBaremes
        '
        'DataSetBaremes
        '
        Me.DataSetBaremes.DataSetName = "DataSetBaremes"
        Me.DataSetBaremes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn
        '
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.DataPropertyName = "ANNEE_BAREME_FORFAITAIRE"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.HeaderText = "Année"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.Name = "ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn"
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.ReadOnly = True
        Me.ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn.Width = 258
        '
        'VALEURFORFAITAIREDataGridViewTextBoxColumn
        '
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.DataPropertyName = "VALEUR_FORFAITAIRE"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.HeaderText = "Forfait"
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.Name = "VALEURFORFAITAIREDataGridViewTextBoxColumn"
        Me.VALEURFORFAITAIREDataGridViewTextBoxColumn.Width = 258
        '
        'BAREME_FORFAITAIREBindingSource
        '
        Me.BAREME_FORFAITAIREBindingSource.DataMember = "BAREME_FORFAITAIRE"
        Me.BAREME_FORFAITAIREBindingSource.DataSource = Me.DataSetBaremes
        '
        'BAREME_FORFAITAIRETableAdapter
        '
        Me.BAREME_FORFAITAIRETableAdapter.ClearBeforeFill = True
        '
        'FACON_CULTURALETableAdapter
        '
        Me.FACON_CULTURALETableAdapter.ClearBeforeFill = True
        '
        'BAREME_FORFAITAIREBindingNavigator
        '
        Me.BAREME_FORFAITAIREBindingNavigator.AddNewItem = Nothing
        Me.BAREME_FORFAITAIREBindingNavigator.BindingSource = Me.BAREME_FORFAITAIREBindingSource
        Me.BAREME_FORFAITAIREBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BAREME_FORFAITAIREBindingNavigator.DeleteItem = Nothing
        Me.BAREME_FORFAITAIREBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.AjouterToolStripButton, Me.EnregistrerToolStripButton, Me.SupprimerToolStripButton})
        Me.BAREME_FORFAITAIREBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.BAREME_FORFAITAIREBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BAREME_FORFAITAIREBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BAREME_FORFAITAIREBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BAREME_FORFAITAIREBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BAREME_FORFAITAIREBindingNavigator.Name = "BAREME_FORFAITAIREBindingNavigator"
        Me.BAREME_FORFAITAIREBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BAREME_FORFAITAIREBindingNavigator.Size = New System.Drawing.Size(841, 25)
        Me.BAREME_FORFAITAIREBindingNavigator.TabIndex = 11
        Me.BAREME_FORFAITAIREBindingNavigator.Text = "BindingNavigator1"
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
        'FrGererBaremeForfaitaire
        '
        Me.AcceptButton = Me.FiltrerButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(841, 581)
        Me.Controls.Add(Me.BAREME_FORFAITAIREBindingNavigator)
        Me.Controls.Add(Me.BAREME_FORFAITAIREDataGridView)
        Me.Controls.Add(Me.ImporterBaremeButton)
        Me.Controls.Add(Me.FiltrerButton)
        Me.Controls.Add(Me.ANNEE_BAREME_FORFAITAIRETextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrGererBaremeForfaitaire"
        Me.Text = "Gérer barème forfaitaire"
        CType(Me.BAREME_FORFAITAIREDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FACON_CULTURALEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBaremes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREME_FORFAITAIREBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAREME_FORFAITAIREBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BAREME_FORFAITAIREBindingNavigator.ResumeLayout(False)
        Me.BAREME_FORFAITAIREBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetBaremes As AgrigestEDI.DataSetBaremes
    Friend WithEvents BAREME_FORFAITAIREBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BAREME_FORFAITAIRETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter
    Friend WithEvents FACON_CULTURALEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FACON_CULTURALETableAdapter As AgrigestEDI.DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter
    Friend WithEvents ImporterBaremeButton As System.Windows.Forms.Button
    Friend WithEvents FiltrerButton As System.Windows.Forms.Button
    Friend WithEvents ANNEE_BAREME_FORFAITAIRETextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BAREME_FORFAITAIREDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents IDFACONCULTURALEDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ANNEEBAREMEFORFAITAIREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALEURFORFAITAIREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BAREME_FORFAITAIREBindingNavigator As System.Windows.Forms.BindingNavigator
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
