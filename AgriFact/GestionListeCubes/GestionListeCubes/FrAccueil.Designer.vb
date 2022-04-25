<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAccueil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAccueil))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.OpenFileDialogChoixFichier = New System.Windows.Forms.OpenFileDialog
        Me.DataGridViewCube = New System.Windows.Forms.DataGridView
        Me.ContextMenuStripCube = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DupliquerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MAJEnFonctionDuParentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BindingSourceCube = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCubes = New ClassLibraryCubes.DataSetCubes
        Me.BindingNavigatorCube = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonEnregistrer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonOuvrir = New System.Windows.Forms.ToolStripButton
        Me.CodeCubeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeParentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SqlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LetitreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FormatdefautDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LechampdateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LetypedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeschampsformulesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LesdimensionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LesdimensionsinvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LesformulesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LesmesuresDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LestitresdimDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LestitresdiminvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LestitresmesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LestypesmesuresDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OuverthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OuvertvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PfroozeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlookDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PmodaleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnomfichierDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PparamDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PonexporteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PsuperutilisateurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PtexteenteteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridViewCube, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripCube.SuspendLayout()
        CType(Me.BindingSourceCube, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCubes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigatorCube, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorCube.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialogChoixFichier
        '
        Me.OpenFileDialogChoixFichier.FileName = "OpenFileDialogChoixFichier"
        '
        'DataGridViewCube
        '
        Me.DataGridViewCube.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewCube.AutoGenerateColumns = False
        Me.DataGridViewCube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCube.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeCubeDataGridViewTextBoxColumn, Me.CodeParentDataGridViewTextBoxColumn, Me.SqlDataGridViewTextBoxColumn, Me.LetitreDataGridViewTextBoxColumn, Me.FormatdefautDataGridViewTextBoxColumn, Me.LechampdateDataGridViewTextBoxColumn, Me.LetypedateDataGridViewTextBoxColumn, Me.LeschampsformulesDataGridViewTextBoxColumn, Me.LesdimensionsDataGridViewTextBoxColumn, Me.LesdimensionsinvDataGridViewTextBoxColumn, Me.LesformulesDataGridViewTextBoxColumn, Me.LesmesuresDataGridViewTextBoxColumn, Me.LestitresdimDataGridViewTextBoxColumn, Me.LestitresdiminvDataGridViewTextBoxColumn, Me.LestitresmesDataGridViewTextBoxColumn, Me.LestypesmesuresDataGridViewTextBoxColumn, Me.OuverthDataGridViewTextBoxColumn, Me.OuvertvDataGridViewTextBoxColumn, Me.PfroozeDataGridViewTextBoxColumn, Me.PlookDataGridViewTextBoxColumn, Me.PmodaleDataGridViewTextBoxColumn, Me.PnomfichierDataGridViewTextBoxColumn, Me.PparamDataGridViewTextBoxColumn, Me.PonexporteDataGridViewTextBoxColumn, Me.PsuperutilisateurDataGridViewTextBoxColumn, Me.PtexteenteteDataGridViewTextBoxColumn})
        Me.DataGridViewCube.ContextMenuStrip = Me.ContextMenuStripCube
        Me.DataGridViewCube.DataSource = Me.BindingSourceCube
        Me.DataGridViewCube.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DataGridViewCube.Location = New System.Drawing.Point(12, 28)
        Me.DataGridViewCube.Name = "DataGridViewCube"
        Me.DataGridViewCube.Size = New System.Drawing.Size(888, 449)
        Me.DataGridViewCube.TabIndex = 0
        '
        'ContextMenuStripCube
        '
        Me.ContextMenuStripCube.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DupliquerToolStripMenuItem, Me.MAJEnFonctionDuParentToolStripMenuItem})
        Me.ContextMenuStripCube.Name = "ContextMenuStripCube"
        Me.ContextMenuStripCube.Size = New System.Drawing.Size(261, 48)
        '
        'DupliquerToolStripMenuItem
        '
        Me.DupliquerToolStripMenuItem.Image = Global.GestionListeCubes.My.Resources.Resources.CopyHS
        Me.DupliquerToolStripMenuItem.Name = "DupliquerToolStripMenuItem"
        Me.DupliquerToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.DupliquerToolStripMenuItem.Text = "Dupliquer"
        Me.DupliquerToolStripMenuItem.ToolTipText = "Dupliquer la ligne"
        '
        'MAJEnFonctionDuParentToolStripMenuItem
        '
        Me.MAJEnFonctionDuParentToolStripMenuItem.Image = Global.GestionListeCubes.My.Resources.Resources.XSDSchema_GraphTopToBtm
        Me.MAJEnFonctionDuParentToolStripMenuItem.Name = "MAJEnFonctionDuParentToolStripMenuItem"
        Me.MAJEnFonctionDuParentToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.MAJEnFonctionDuParentToolStripMenuItem.Text = "Mettre à jour en fonction du parent"
        Me.MAJEnFonctionDuParentToolStripMenuItem.ToolTipText = "Mettre à jour en fonction des informations de la ligne parente"
        '
        'BindingSourceCube
        '
        Me.BindingSourceCube.DataMember = "Cube"
        Me.BindingSourceCube.DataSource = Me.DSCubes
        '
        'DSCubes
        '
        Me.DSCubes.DataSetName = "DataSetCubes"
        Me.DSCubes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCube
        '
        Me.BindingNavigatorCube.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigatorCube.BindingSource = Me.BindingSourceCube
        Me.BindingNavigatorCube.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigatorCube.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigatorCube.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripButtonEnregistrer, Me.ToolStripButtonOuvrir})
        Me.BindingNavigatorCube.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigatorCube.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigatorCube.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigatorCube.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigatorCube.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigatorCube.Name = "BindingNavigatorCube"
        Me.BindingNavigatorCube.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigatorCube.Size = New System.Drawing.Size(912, 25)
        Me.BindingNavigatorCube.TabIndex = 1
        Me.BindingNavigatorCube.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
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
        'ToolStripButtonEnregistrer
        '
        Me.ToolStripButtonEnregistrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonEnregistrer.Image = Global.GestionListeCubes.My.Resources.Resources.saveHS
        Me.ToolStripButtonEnregistrer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEnregistrer.Name = "ToolStripButtonEnregistrer"
        Me.ToolStripButtonEnregistrer.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonEnregistrer.Text = "Enregistrer"
        '
        'ToolStripButtonOuvrir
        '
        Me.ToolStripButtonOuvrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOuvrir.Image = Global.GestionListeCubes.My.Resources.Resources.openfolderHS
        Me.ToolStripButtonOuvrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOuvrir.Name = "ToolStripButtonOuvrir"
        Me.ToolStripButtonOuvrir.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonOuvrir.Text = "Ouvrir un fichier XML"
        '
        'CodeCubeDataGridViewTextBoxColumn
        '
        Me.CodeCubeDataGridViewTextBoxColumn.DataPropertyName = "CodeCube"
        Me.CodeCubeDataGridViewTextBoxColumn.HeaderText = "CodeCube"
        Me.CodeCubeDataGridViewTextBoxColumn.Name = "CodeCubeDataGridViewTextBoxColumn"
        Me.CodeCubeDataGridViewTextBoxColumn.Width = 150
        '
        'CodeParentDataGridViewTextBoxColumn
        '
        Me.CodeParentDataGridViewTextBoxColumn.DataPropertyName = "CodeParent"
        Me.CodeParentDataGridViewTextBoxColumn.HeaderText = "CodeParent"
        Me.CodeParentDataGridViewTextBoxColumn.Name = "CodeParentDataGridViewTextBoxColumn"
        Me.CodeParentDataGridViewTextBoxColumn.Width = 150
        '
        'SqlDataGridViewTextBoxColumn
        '
        Me.SqlDataGridViewTextBoxColumn.DataPropertyName = "Sql"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SqlDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.SqlDataGridViewTextBoxColumn.HeaderText = "Sql"
        Me.SqlDataGridViewTextBoxColumn.Name = "SqlDataGridViewTextBoxColumn"
        Me.SqlDataGridViewTextBoxColumn.Width = 200
        '
        'LetitreDataGridViewTextBoxColumn
        '
        Me.LetitreDataGridViewTextBoxColumn.DataPropertyName = "le_titre"
        Me.LetitreDataGridViewTextBoxColumn.HeaderText = "le_titre"
        Me.LetitreDataGridViewTextBoxColumn.Name = "LetitreDataGridViewTextBoxColumn"
        Me.LetitreDataGridViewTextBoxColumn.Width = 150
        '
        'FormatdefautDataGridViewTextBoxColumn
        '
        Me.FormatdefautDataGridViewTextBoxColumn.DataPropertyName = "format_defaut"
        Me.FormatdefautDataGridViewTextBoxColumn.HeaderText = "format_defaut"
        Me.FormatdefautDataGridViewTextBoxColumn.Name = "FormatdefautDataGridViewTextBoxColumn"
        '
        'LechampdateDataGridViewTextBoxColumn
        '
        Me.LechampdateDataGridViewTextBoxColumn.DataPropertyName = "le_champ_date"
        Me.LechampdateDataGridViewTextBoxColumn.HeaderText = "le_champ_date"
        Me.LechampdateDataGridViewTextBoxColumn.Name = "LechampdateDataGridViewTextBoxColumn"
        '
        'LetypedateDataGridViewTextBoxColumn
        '
        Me.LetypedateDataGridViewTextBoxColumn.DataPropertyName = "le_type_date"
        Me.LetypedateDataGridViewTextBoxColumn.HeaderText = "le_type_date"
        Me.LetypedateDataGridViewTextBoxColumn.Name = "LetypedateDataGridViewTextBoxColumn"
        '
        'LeschampsformulesDataGridViewTextBoxColumn
        '
        Me.LeschampsformulesDataGridViewTextBoxColumn.DataPropertyName = "les_champs_formules"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeschampsformulesDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.LeschampsformulesDataGridViewTextBoxColumn.HeaderText = "les_champs_formules"
        Me.LeschampsformulesDataGridViewTextBoxColumn.Name = "LeschampsformulesDataGridViewTextBoxColumn"
        Me.LeschampsformulesDataGridViewTextBoxColumn.Width = 150
        '
        'LesdimensionsDataGridViewTextBoxColumn
        '
        Me.LesdimensionsDataGridViewTextBoxColumn.DataPropertyName = "les_dimensions"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LesdimensionsDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LesdimensionsDataGridViewTextBoxColumn.HeaderText = "les_dimensions"
        Me.LesdimensionsDataGridViewTextBoxColumn.Name = "LesdimensionsDataGridViewTextBoxColumn"
        Me.LesdimensionsDataGridViewTextBoxColumn.Width = 150
        '
        'LesdimensionsinvDataGridViewTextBoxColumn
        '
        Me.LesdimensionsinvDataGridViewTextBoxColumn.DataPropertyName = "les_dimensions_inv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LesdimensionsinvDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LesdimensionsinvDataGridViewTextBoxColumn.HeaderText = "les_dimensions_inv"
        Me.LesdimensionsinvDataGridViewTextBoxColumn.Name = "LesdimensionsinvDataGridViewTextBoxColumn"
        Me.LesdimensionsinvDataGridViewTextBoxColumn.Width = 150
        '
        'LesformulesDataGridViewTextBoxColumn
        '
        Me.LesformulesDataGridViewTextBoxColumn.DataPropertyName = "les_formules"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LesformulesDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.LesformulesDataGridViewTextBoxColumn.HeaderText = "les_formules"
        Me.LesformulesDataGridViewTextBoxColumn.Name = "LesformulesDataGridViewTextBoxColumn"
        Me.LesformulesDataGridViewTextBoxColumn.Width = 150
        '
        'LesmesuresDataGridViewTextBoxColumn
        '
        Me.LesmesuresDataGridViewTextBoxColumn.DataPropertyName = "les_mesures"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LesmesuresDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.LesmesuresDataGridViewTextBoxColumn.HeaderText = "les_mesures"
        Me.LesmesuresDataGridViewTextBoxColumn.Name = "LesmesuresDataGridViewTextBoxColumn"
        Me.LesmesuresDataGridViewTextBoxColumn.Width = 150
        '
        'LestitresdimDataGridViewTextBoxColumn
        '
        Me.LestitresdimDataGridViewTextBoxColumn.DataPropertyName = "les_titres_dim"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LestitresdimDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.LestitresdimDataGridViewTextBoxColumn.HeaderText = "les_titres_dim"
        Me.LestitresdimDataGridViewTextBoxColumn.Name = "LestitresdimDataGridViewTextBoxColumn"
        Me.LestitresdimDataGridViewTextBoxColumn.Width = 150
        '
        'LestitresdiminvDataGridViewTextBoxColumn
        '
        Me.LestitresdiminvDataGridViewTextBoxColumn.DataPropertyName = "les_titres_dim_inv"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LestitresdiminvDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.LestitresdiminvDataGridViewTextBoxColumn.HeaderText = "les_titres_dim_inv"
        Me.LestitresdiminvDataGridViewTextBoxColumn.Name = "LestitresdiminvDataGridViewTextBoxColumn"
        Me.LestitresdiminvDataGridViewTextBoxColumn.Width = 150
        '
        'LestitresmesDataGridViewTextBoxColumn
        '
        Me.LestitresmesDataGridViewTextBoxColumn.DataPropertyName = "les_titres_mes"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LestitresmesDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.LestitresmesDataGridViewTextBoxColumn.HeaderText = "les_titres_mes"
        Me.LestitresmesDataGridViewTextBoxColumn.Name = "LestitresmesDataGridViewTextBoxColumn"
        Me.LestitresmesDataGridViewTextBoxColumn.Width = 150
        '
        'LestypesmesuresDataGridViewTextBoxColumn
        '
        Me.LestypesmesuresDataGridViewTextBoxColumn.DataPropertyName = "les_types_mesures"
        Me.LestypesmesuresDataGridViewTextBoxColumn.HeaderText = "les_types_mesures"
        Me.LestypesmesuresDataGridViewTextBoxColumn.Name = "LestypesmesuresDataGridViewTextBoxColumn"
        Me.LestypesmesuresDataGridViewTextBoxColumn.Width = 150
        '
        'OuverthDataGridViewTextBoxColumn
        '
        Me.OuverthDataGridViewTextBoxColumn.DataPropertyName = "ouvert_h"
        Me.OuverthDataGridViewTextBoxColumn.HeaderText = "ouvert_h"
        Me.OuverthDataGridViewTextBoxColumn.Name = "OuverthDataGridViewTextBoxColumn"
        Me.OuverthDataGridViewTextBoxColumn.Width = 50
        '
        'OuvertvDataGridViewTextBoxColumn
        '
        Me.OuvertvDataGridViewTextBoxColumn.DataPropertyName = "ouvert_v"
        Me.OuvertvDataGridViewTextBoxColumn.HeaderText = "ouvert_v"
        Me.OuvertvDataGridViewTextBoxColumn.Name = "OuvertvDataGridViewTextBoxColumn"
        Me.OuvertvDataGridViewTextBoxColumn.Width = 50
        '
        'PfroozeDataGridViewTextBoxColumn
        '
        Me.PfroozeDataGridViewTextBoxColumn.DataPropertyName = "p_frooze"
        Me.PfroozeDataGridViewTextBoxColumn.HeaderText = "p_frooze"
        Me.PfroozeDataGridViewTextBoxColumn.Name = "PfroozeDataGridViewTextBoxColumn"
        Me.PfroozeDataGridViewTextBoxColumn.Width = 50
        '
        'PlookDataGridViewTextBoxColumn
        '
        Me.PlookDataGridViewTextBoxColumn.DataPropertyName = "p_look"
        Me.PlookDataGridViewTextBoxColumn.HeaderText = "p_look"
        Me.PlookDataGridViewTextBoxColumn.Name = "PlookDataGridViewTextBoxColumn"
        Me.PlookDataGridViewTextBoxColumn.Width = 150
        '
        'PmodaleDataGridViewTextBoxColumn
        '
        Me.PmodaleDataGridViewTextBoxColumn.DataPropertyName = "p_modale"
        Me.PmodaleDataGridViewTextBoxColumn.HeaderText = "p_modale"
        Me.PmodaleDataGridViewTextBoxColumn.Name = "PmodaleDataGridViewTextBoxColumn"
        Me.PmodaleDataGridViewTextBoxColumn.Width = 50
        '
        'PnomfichierDataGridViewTextBoxColumn
        '
        Me.PnomfichierDataGridViewTextBoxColumn.DataPropertyName = "p_nom_fichier"
        Me.PnomfichierDataGridViewTextBoxColumn.HeaderText = "p_nom_fichier"
        Me.PnomfichierDataGridViewTextBoxColumn.Name = "PnomfichierDataGridViewTextBoxColumn"
        '
        'PparamDataGridViewTextBoxColumn
        '
        Me.PparamDataGridViewTextBoxColumn.DataPropertyName = "p_param"
        Me.PparamDataGridViewTextBoxColumn.HeaderText = "p_param"
        Me.PparamDataGridViewTextBoxColumn.Name = "PparamDataGridViewTextBoxColumn"
        '
        'PonexporteDataGridViewTextBoxColumn
        '
        Me.PonexporteDataGridViewTextBoxColumn.DataPropertyName = "p_on_exporte"
        Me.PonexporteDataGridViewTextBoxColumn.HeaderText = "p_on_exporte"
        Me.PonexporteDataGridViewTextBoxColumn.Name = "PonexporteDataGridViewTextBoxColumn"
        '
        'PsuperutilisateurDataGridViewTextBoxColumn
        '
        Me.PsuperutilisateurDataGridViewTextBoxColumn.DataPropertyName = "p_superutilisateur"
        Me.PsuperutilisateurDataGridViewTextBoxColumn.HeaderText = "p_superutilisateur"
        Me.PsuperutilisateurDataGridViewTextBoxColumn.Name = "PsuperutilisateurDataGridViewTextBoxColumn"
        '
        'PtexteenteteDataGridViewTextBoxColumn
        '
        Me.PtexteenteteDataGridViewTextBoxColumn.DataPropertyName = "p_texte_entete"
        Me.PtexteenteteDataGridViewTextBoxColumn.HeaderText = "p_texte_entete"
        Me.PtexteenteteDataGridViewTextBoxColumn.Name = "PtexteenteteDataGridViewTextBoxColumn"
        '
        'FrAccueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 489)
        Me.Controls.Add(Me.BindingNavigatorCube)
        Me.Controls.Add(Me.DataGridViewCube)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrAccueil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestionListeCubes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewCube, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripCube.ResumeLayout(False)
        CType(Me.BindingSourceCube, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCubes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigatorCube, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorCube.ResumeLayout(False)
        Me.BindingNavigatorCube.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialogChoixFichier As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridViewCube As System.Windows.Forms.DataGridView
    Friend WithEvents DSCubes As ClassLibraryCubes.DataSetCubes
    Friend WithEvents BindingSourceCube As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigatorCube As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ContextMenuStripCube As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DupliquerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonEnregistrer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonOuvrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents MAJEnFonctionDuParentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeCubeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeParentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SqlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LetitreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormatdefautDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LechampdateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LetypedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeschampsformulesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LesdimensionsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LesdimensionsinvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LesformulesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LesmesuresDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LestitresdimDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LestitresdiminvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LestitresmesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LestypesmesuresDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OuverthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OuvertvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PfroozeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlookDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PmodaleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PnomfichierDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PparamDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PonexporteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PsuperutilisateurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PtexteenteteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
