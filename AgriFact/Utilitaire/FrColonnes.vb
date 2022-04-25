Public Class FrColonnes
    Inherits System.Windows.Forms.Form

    'TODO Gérer un combo pour les opérateurs

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents DgCols As System.Windows.Forms.DataGrid
    Friend WithEvents colSelect As [ReadOnly].DataGridEnableBoolColumn
    Friend WithEvents colOperator As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colWhere As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colValue As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgStyleSelect As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgStyleDelete As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgStyleInsert As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgStyleUpdate As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgStyleDesc As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colNom As [ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colType As [ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colTaille As [ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colNull As [ReadOnly].DataGridEnableBoolColumn
    Friend WithEvents colDef As [ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents BtSelectAll As System.Windows.Forms.Button
    Friend WithEvents DgStyleExec As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgStyleDescProc As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colNomParam As Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colTypeParam As Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colTailleParam As Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents colValueParam As Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
    Friend WithEvents BtDeselectAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrColonnes))
        Me.DgCols = New System.Windows.Forms.DataGrid
        Me.DgStyleSelect = New System.Windows.Forms.DataGridTableStyle
        Me.colNom = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.colSelect = New Utilitaire.[ReadOnly].DataGridEnableBoolColumn
        Me.colOperator = New System.Windows.Forms.DataGridTextBoxColumn
        Me.colWhere = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgStyleDelete = New System.Windows.Forms.DataGridTableStyle
        Me.DgStyleInsert = New System.Windows.Forms.DataGridTableStyle
        Me.colValue = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgStyleUpdate = New System.Windows.Forms.DataGridTableStyle
        Me.DgStyleDesc = New System.Windows.Forms.DataGridTableStyle
        Me.colType = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.colTaille = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.colNull = New Utilitaire.[ReadOnly].DataGridEnableBoolColumn
        Me.colDef = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.DgStyleExec = New System.Windows.Forms.DataGridTableStyle
        Me.colNomParam = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.colValueParam = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.DgStyleDescProc = New System.Windows.Forms.DataGridTableStyle
        Me.colTypeParam = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.colTailleParam = New Utilitaire.[ReadOnly].DataGridEnableTextBoxColumn
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtSelectAll = New System.Windows.Forms.Button
        Me.BtDeselectAll = New System.Windows.Forms.Button
        CType(Me.DgCols, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgCols
        '
        Me.DgCols.AllowNavigation = False
        Me.DgCols.AllowSorting = False
        Me.DgCols.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgCols.CaptionVisible = False
        Me.DgCols.DataMember = ""
        Me.DgCols.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgCols.Location = New System.Drawing.Point(8, 8)
        Me.DgCols.Name = "DgCols"
        Me.DgCols.ParentRowsVisible = False
        Me.DgCols.RowHeadersVisible = False
        Me.DgCols.Size = New System.Drawing.Size(434, 287)
        Me.DgCols.TabIndex = 0
        Me.DgCols.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DgStyleSelect, Me.DgStyleDelete, Me.DgStyleInsert, Me.DgStyleUpdate, Me.DgStyleDesc, Me.DgStyleExec, Me.DgStyleDescProc})
        '
        'DgStyleSelect
        '
        Me.DgStyleSelect.DataGrid = Me.DgCols
        Me.DgStyleSelect.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNom, Me.colSelect, Me.colOperator, Me.colWhere})
        Me.DgStyleSelect.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleSelect.MappingName = "SelectQuery"
        Me.DgStyleSelect.RowHeadersVisible = False
        '
        'colNom
        '
        Me.colNom.Column = 0
        Me.colNom.Format = ""
        Me.colNom.FormatInfo = Nothing
        Me.colNom.HeaderText = "Colonne"
        Me.colNom.MappingName = "COLUMN_NAME"
        Me.colNom.ReadOnly = True
        Me.colNom.Width = 75
        '
        'colSelect
        '
        Me.colSelect.AllowNull = False
        Me.colSelect.HeaderText = "Afficher"
        Me.colSelect.MappingName = "Select"
        Me.colSelect.NullValue = "True"
        Me.colSelect.Width = 75
        '
        'colOperator
        '
        Me.colOperator.Format = ""
        Me.colOperator.FormatInfo = Nothing
        Me.colOperator.HeaderText = "Opérateur"
        Me.colOperator.MappingName = "Operator"
        Me.colOperator.Width = 75
        '
        'colWhere
        '
        Me.colWhere.Format = ""
        Me.colWhere.FormatInfo = Nothing
        Me.colWhere.HeaderText = "Condition"
        Me.colWhere.MappingName = "Where"
        Me.colWhere.Width = 75
        '
        'DgStyleDelete
        '
        Me.DgStyleDelete.DataGrid = Me.DgCols
        Me.DgStyleDelete.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNom, Me.colOperator, Me.colWhere})
        Me.DgStyleDelete.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleDelete.MappingName = "DeleteQuery"
        Me.DgStyleDelete.RowHeadersVisible = False
        '
        'DgStyleInsert
        '
        Me.DgStyleInsert.DataGrid = Me.DgCols
        Me.DgStyleInsert.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNom, Me.colValue})
        Me.DgStyleInsert.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleInsert.MappingName = "InsertQuery"
        Me.DgStyleInsert.RowHeadersVisible = False
        '
        'colValue
        '
        Me.colValue.Format = ""
        Me.colValue.FormatInfo = Nothing
        Me.colValue.HeaderText = "Valeur"
        Me.colValue.MappingName = "Value"
        Me.colValue.Width = 75
        '
        'DgStyleUpdate
        '
        Me.DgStyleUpdate.DataGrid = Me.DgCols
        Me.DgStyleUpdate.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNom, Me.colValue, Me.colOperator, Me.colWhere})
        Me.DgStyleUpdate.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleUpdate.MappingName = "UpdateQuery"
        Me.DgStyleUpdate.RowHeadersVisible = False
        '
        'DgStyleDesc
        '
        Me.DgStyleDesc.DataGrid = Me.DgCols
        Me.DgStyleDesc.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNom, Me.colType, Me.colTaille, Me.colNull, Me.colDef})
        Me.DgStyleDesc.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleDesc.MappingName = "Desc"
        Me.DgStyleDesc.ReadOnly = True
        Me.DgStyleDesc.RowHeadersVisible = False
        '
        'colType
        '
        Me.colType.Column = 0
        Me.colType.Format = ""
        Me.colType.FormatInfo = Nothing
        Me.colType.HeaderText = "Type"
        Me.colType.MappingName = "TYPE_NAME"
        Me.colType.ReadOnly = True
        Me.colType.Width = 75
        '
        'colTaille
        '
        Me.colTaille.Column = 0
        Me.colTaille.Format = ""
        Me.colTaille.FormatInfo = Nothing
        Me.colTaille.HeaderText = "Taille"
        Me.colTaille.MappingName = "PRECISION"
        Me.colTaille.ReadOnly = True
        Me.colTaille.Width = 75
        '
        'colNull
        '
        Me.colNull.HeaderText = "Nullable"
        Me.colNull.MappingName = "NULLABLE"
        Me.colNull.ReadOnly = True
        Me.colNull.Width = 75
        '
        'colDef
        '
        Me.colDef.Column = 0
        Me.colDef.Format = ""
        Me.colDef.FormatInfo = Nothing
        Me.colDef.HeaderText = "Défaut"
        Me.colDef.MappingName = "COLUMN_DEF"
        Me.colDef.NullText = ""
        Me.colDef.ReadOnly = True
        Me.colDef.Width = 75
        '
        'DgStyleExec
        '
        Me.DgStyleExec.DataGrid = Me.DgCols
        Me.DgStyleExec.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNomParam, Me.colValueParam})
        Me.DgStyleExec.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleExec.MappingName = "ExecQuery"
        '
        'colNomParam
        '
        Me.colNomParam.Column = 0
        Me.colNomParam.Format = ""
        Me.colNomParam.FormatInfo = Nothing
        Me.colNomParam.HeaderText = "Nom"
        Me.colNomParam.MappingName = "PARAMETER_NAME"
        Me.colNomParam.ReadOnly = True
        Me.colNomParam.Width = 75
        '
        'colValueParam
        '
        Me.colValueParam.Column = 0
        Me.colValueParam.Format = ""
        Me.colValueParam.FormatInfo = Nothing
        Me.colValueParam.HeaderText = "Valeur"
        Me.colValueParam.MappingName = "Value"
        Me.colValueParam.Width = 75
        '
        'DgStyleDescProc
        '
        Me.DgStyleDescProc.DataGrid = Me.DgCols
        Me.DgStyleDescProc.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNomParam, Me.colTypeParam, Me.colTailleParam})
        Me.DgStyleDescProc.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgStyleDescProc.MappingName = "DescProc"
        Me.DgStyleDescProc.ReadOnly = True
        '
        'colTypeParam
        '
        Me.colTypeParam.Column = 0
        Me.colTypeParam.Format = ""
        Me.colTypeParam.FormatInfo = Nothing
        Me.colTypeParam.HeaderText = "Type"
        Me.colTypeParam.MappingName = "DATA_TYPE"
        Me.colTypeParam.ReadOnly = True
        Me.colTypeParam.Width = 75
        '
        'colTailleParam
        '
        Me.colTailleParam.Column = 0
        Me.colTailleParam.Format = ""
        Me.colTailleParam.FormatInfo = Nothing
        Me.colTailleParam.HeaderText = "Taille"
        Me.colTailleParam.MappingName = "CHARACTER_MAXIMUM_LENGTH"
        Me.colTailleParam.ReadOnly = True
        Me.colTailleParam.Width = 75
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(282, 303)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 1
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(363, 303)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 2
        Me.BtCancel.Text = "Annuler"
        '
        'BtSelectAll
        '
        Me.BtSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtSelectAll.Location = New System.Drawing.Point(8, 303)
        Me.BtSelectAll.Name = "BtSelectAll"
        Me.BtSelectAll.Size = New System.Drawing.Size(104, 23)
        Me.BtSelectAll.TabIndex = 3
        Me.BtSelectAll.Text = "Tout sélectionner"
        '
        'BtDeselectAll
        '
        Me.BtDeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtDeselectAll.Location = New System.Drawing.Point(120, 303)
        Me.BtDeselectAll.Name = "BtDeselectAll"
        Me.BtDeselectAll.Size = New System.Drawing.Size(120, 23)
        Me.BtDeselectAll.TabIndex = 4
        Me.BtDeselectAll.Text = "Tout désélectionner"
        '
        'FrColonnes
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(450, 333)
        Me.Controls.Add(Me.BtDeselectAll)
        Me.Controls.Add(Me.BtSelectAll)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.DgCols)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrColonnes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramétrage de la requête"
        CType(Me.DgCols, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _source As DataView
    Public Property Colonnes() As DataView
        Get
            Return _source
        End Get
        Set(ByVal Value As DataView)
            _source = Value
        End Set
    End Property

    Public Sub New(ByVal dv As DataView)
        Me.New()
        _source = dv
    End Sub

    Private Sub FrColonnes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _source.AllowNew = False
        _source.AllowDelete = False
        DgCols.DataSource = _source
        BtSelectAll.Visible = (_source.Table.TableName = "SelectQuery")
        BtDeselectAll.Visible = (_source.Table.TableName = "SelectQuery")
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        _source.Table.AcceptChanges()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectAll.Click
        SetSelect(True)
    End Sub

    Private Sub BtDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDeselectAll.Click
        SetSelect(False)
    End Sub

    Private Sub SetSelect(ByVal selected As Boolean)
        If _source.Table.Columns.Contains("Select") Then
            For Each drv As DataRowView In _source
                drv("Select") = selected
            Next
        End If
    End Sub

End Class
