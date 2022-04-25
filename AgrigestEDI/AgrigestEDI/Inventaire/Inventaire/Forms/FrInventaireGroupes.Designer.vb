<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrInventaireGroupes
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrInventaireGroupes))
        Me.InventaireGroupesDataGridView = New System.Windows.Forms.DataGridView
        Me.INVGDossier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGTypeInventaire = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGOrdre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGCpt = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetAgrigest = New AgrigestEDI.DataSetAgrigest
        Me.INVGActi = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ActivitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.INVGDecote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGUnite = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalValeurHTLignes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCoutParHaLignesMethodeDetaillee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCoutParHaLignesMethodeForfaitaire = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalValeurHTAvAuxCulturesLignes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGEstControle = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.InventaireGroupesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTotauxGeneraux = New System.Windows.Forms.DataGridView
        Me.Titre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LabelTitre = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.AfficherLignesToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DupliquerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ReprendreDonneesToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ImprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.MonterLigneToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DescendreLigneToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PositionDeplacementLigneToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.DeplacerLigneToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PlanComptableTableAdapter = New AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.DataSetAgrigestTableAdapters.ActivitesTableAdapter
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.InventaireGroupesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventaireGroupesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewTotauxGeneraux, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'InventaireGroupesDataGridView
        '
        Me.InventaireGroupesDataGridView.AllowUserToDeleteRows = False
        Me.InventaireGroupesDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.InventaireGroupesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.InventaireGroupesDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InventaireGroupesDataGridView.AutoGenerateColumns = False
        Me.InventaireGroupesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.InventaireGroupesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.InventaireGroupesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InventaireGroupesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InventaireGroupesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.InventaireGroupesDataGridView.ColumnHeadersHeight = 35
        Me.InventaireGroupesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INVGDossier, Me.INVGCode, Me.INVGTypeInventaire, Me.INVGOrdre, Me.INVGLib, Me.INVGCpt, Me.INVGActi, Me.INVGDecote, Me.INVGUnite, Me.TotalValeurHTLignes, Me.TotalCoutParHaLignesMethodeDetaillee, Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes, Me.TotalCoutParHaLignesMethodeForfaitaire, Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes, Me.TotalValeurHTAvAuxCulturesLignes, Me.INVGEstControle})
        Me.InventaireGroupesDataGridView.DataSource = Me.InventaireGroupesBindingSource
        Me.InventaireGroupesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.InventaireGroupesDataGridView.GridColor = System.Drawing.Color.LimeGreen
        Me.InventaireGroupesDataGridView.Location = New System.Drawing.Point(12, 48)
        Me.InventaireGroupesDataGridView.MultiSelect = False
        Me.InventaireGroupesDataGridView.Name = "InventaireGroupesDataGridView"
        Me.InventaireGroupesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InventaireGroupesDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.InventaireGroupesDataGridView.RowHeadersWidth = 50
        Me.InventaireGroupesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.InventaireGroupesDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.InventaireGroupesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InventaireGroupesDataGridView.Size = New System.Drawing.Size(868, 342)
        Me.InventaireGroupesDataGridView.TabIndex = 0
        '
        'INVGDossier
        '
        Me.INVGDossier.DataPropertyName = "INVGDossier"
        Me.INVGDossier.HeaderText = "INVGDossier"
        Me.INVGDossier.Name = "INVGDossier"
        Me.INVGDossier.ReadOnly = True
        Me.INVGDossier.Visible = False
        '
        'INVGCode
        '
        Me.INVGCode.DataPropertyName = "INVGCode"
        Me.INVGCode.HeaderText = "INVGCode"
        Me.INVGCode.Name = "INVGCode"
        Me.INVGCode.Visible = False
        '
        'INVGTypeInventaire
        '
        Me.INVGTypeInventaire.DataPropertyName = "INVGTypeInventaire"
        Me.INVGTypeInventaire.HeaderText = "INVGTypeInventaire"
        Me.INVGTypeInventaire.Name = "INVGTypeInventaire"
        Me.INVGTypeInventaire.Visible = False
        '
        'INVGOrdre
        '
        Me.INVGOrdre.DataPropertyName = "INVGOrdre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.INVGOrdre.DefaultCellStyle = DataGridViewCellStyle3
        Me.INVGOrdre.HeaderText = "Pos."
        Me.INVGOrdre.Name = "INVGOrdre"
        Me.INVGOrdre.ReadOnly = True
        Me.INVGOrdre.ToolTipText = "Pos."
        Me.INVGOrdre.Width = 40
        '
        'INVGLib
        '
        Me.INVGLib.DataPropertyName = "INVGLib"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.INVGLib.DefaultCellStyle = DataGridViewCellStyle4
        Me.INVGLib.HeaderText = "Libellé du groupe"
        Me.INVGLib.MaxInputLength = 40
        Me.INVGLib.Name = "INVGLib"
        Me.INVGLib.ToolTipText = "Libellé du groupe"
        Me.INVGLib.Width = 300
        '
        'INVGCpt
        '
        Me.INVGCpt.DataPropertyName = "INVGCpt"
        Me.INVGCpt.DataSource = Me.PlanComptableBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INVGCpt.DefaultCellStyle = DataGridViewCellStyle5
        Me.INVGCpt.DisplayMember = "PlCpt"
        Me.INVGCpt.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.INVGCpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.INVGCpt.HeaderText = "N° compte"
        Me.INVGCpt.MaxDropDownItems = 12
        Me.INVGCpt.Name = "INVGCpt"
        Me.INVGCpt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.INVGCpt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.INVGCpt.ToolTipText = "N° de compte rattaché"
        Me.INVGCpt.ValueMember = "PlCpt"
        Me.INVGCpt.Width = 120
        '
        'PlanComptableBindingSource
        '
        Me.PlanComptableBindingSource.DataMember = "PlanComptable"
        Me.PlanComptableBindingSource.DataSource = Me.DataSetAgrigest
        Me.PlanComptableBindingSource.Sort = "PlCpt ASC"
        '
        'DataSetAgrigest
        '
        Me.DataSetAgrigest.DataSetName = "DataSetAgrigest"
        Me.DataSetAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'INVGActi
        '
        Me.INVGActi.DataPropertyName = "INVGActi"
        Me.INVGActi.DataSource = Me.ActivitesBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INVGActi.DefaultCellStyle = DataGridViewCellStyle6
        Me.INVGActi.DisplayMember = "AActi"
        Me.INVGActi.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.INVGActi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.INVGActi.HeaderText = "Activité"
        Me.INVGActi.Name = "INVGActi"
        Me.INVGActi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.INVGActi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.INVGActi.ToolTipText = "Activité"
        Me.INVGActi.ValueMember = "AActi"
        Me.INVGActi.Width = 60
        '
        'ActivitesBindingSource
        '
        Me.ActivitesBindingSource.DataMember = "Activites"
        Me.ActivitesBindingSource.DataSource = Me.DataSetAgrigest
        '
        'INVGDecote
        '
        Me.INVGDecote.DataPropertyName = "INVGDecote"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.NullValue = Nothing
        Me.INVGDecote.DefaultCellStyle = DataGridViewCellStyle7
        Me.INVGDecote.HeaderText = "Décôte (%)"
        Me.INVGDecote.Name = "INVGDecote"
        Me.INVGDecote.ToolTipText = "Décôte (%)"
        Me.INVGDecote.Width = 90
        '
        'INVGUnite
        '
        Me.INVGUnite.DataPropertyName = "INVGUnite"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INVGUnite.DefaultCellStyle = DataGridViewCellStyle8
        Me.INVGUnite.HeaderText = "Unité"
        Me.INVGUnite.MaxInputLength = 2
        Me.INVGUnite.Name = "INVGUnite"
        Me.INVGUnite.ToolTipText = "Unité"
        Me.INVGUnite.Width = 50
        '
        'TotalValeurHTLignes
        '
        Me.TotalValeurHTLignes.DataPropertyName = "TotalValeurHTLignes"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.TotalValeurHTLignes.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalValeurHTLignes.HeaderText = "Total valeur HT"
        Me.TotalValeurHTLignes.Name = "TotalValeurHTLignes"
        Me.TotalValeurHTLignes.ReadOnly = True
        Me.TotalValeurHTLignes.ToolTipText = "Total valeur HT"
        '
        'TotalCoutParHaLignesMethodeDetaillee
        '
        Me.TotalCoutParHaLignesMethodeDetaillee.DataPropertyName = "TotalCoutParHaLignesMethodeDetaillee"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.TotalCoutParHaLignesMethodeDetaillee.DefaultCellStyle = DataGridViewCellStyle10
        Me.TotalCoutParHaLignesMethodeDetaillee.HeaderText = "Total coûts par ha"
        Me.TotalCoutParHaLignesMethodeDetaillee.Name = "TotalCoutParHaLignesMethodeDetaillee"
        Me.TotalCoutParHaLignesMethodeDetaillee.ReadOnly = True
        Me.TotalCoutParHaLignesMethodeDetaillee.ToolTipText = "Total coûts par hectare"
        '
        'TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes
        '
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.DataPropertyName = "TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.DefaultCellStyle = DataGridViewCellStyle11
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.HeaderText = "Total coûts façons culturales"
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.Name = "TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes"
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.ReadOnly = True
        Me.TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes.ToolTipText = "Total coûts façons culturales"
        '
        'TotalCoutParHaLignesMethodeForfaitaire
        '
        Me.TotalCoutParHaLignesMethodeForfaitaire.DataPropertyName = "TotalCoutParHaLignesMethodeForfaitaire"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.TotalCoutParHaLignesMethodeForfaitaire.DefaultCellStyle = DataGridViewCellStyle12
        Me.TotalCoutParHaLignesMethodeForfaitaire.HeaderText = "Total coût par ha"
        Me.TotalCoutParHaLignesMethodeForfaitaire.Name = "TotalCoutParHaLignesMethodeForfaitaire"
        Me.TotalCoutParHaLignesMethodeForfaitaire.ReadOnly = True
        Me.TotalCoutParHaLignesMethodeForfaitaire.ToolTipText = "Total coûts par hectare"
        '
        'TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes
        '
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.DataPropertyName = "TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.DefaultCellStyle = DataGridViewCellStyle13
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.HeaderText = "Total coût facons culturales"
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.Name = "TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes"
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.ReadOnly = True
        Me.TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes.ToolTipText = "Total coûts façons culturales"
        '
        'TotalValeurHTAvAuxCulturesLignes
        '
        Me.TotalValeurHTAvAuxCulturesLignes.DataPropertyName = "TotalValeurHTAvAuxCulturesLignes"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.TotalValeurHTAvAuxCulturesLignes.DefaultCellStyle = DataGridViewCellStyle14
        Me.TotalValeurHTAvAuxCulturesLignes.HeaderText = "Total valeur HT Av. cultures"
        Me.TotalValeurHTAvAuxCulturesLignes.Name = "TotalValeurHTAvAuxCulturesLignes"
        Me.TotalValeurHTAvAuxCulturesLignes.ReadOnly = True
        Me.TotalValeurHTAvAuxCulturesLignes.ToolTipText = "Total valeur HT avances aux cultures"
        '
        'INVGEstControle
        '
        Me.INVGEstControle.DataPropertyName = "INVGEstControle"
        Me.INVGEstControle.HeaderText = "Controlé"
        Me.INVGEstControle.Name = "INVGEstControle"
        Me.INVGEstControle.Width = 60
        '
        'InventaireGroupesBindingSource
        '
        Me.InventaireGroupesBindingSource.DataSource = GetType(AgrigestEDI.Inventaire.ClassesMetier.InventaireGroupes)
        Me.InventaireGroupesBindingSource.Sort = ""
        '
        'DataGridViewTotauxGeneraux
        '
        Me.DataGridViewTotauxGeneraux.AllowUserToAddRows = False
        Me.DataGridViewTotauxGeneraux.AllowUserToDeleteRows = False
        Me.DataGridViewTotauxGeneraux.AllowUserToResizeColumns = False
        Me.DataGridViewTotauxGeneraux.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DataGridViewTotauxGeneraux.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTotauxGeneraux.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewTotauxGeneraux.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewTotauxGeneraux.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridViewTotauxGeneraux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewTotauxGeneraux.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridViewTotauxGeneraux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTotauxGeneraux.ColumnHeadersVisible = False
        Me.DataGridViewTotauxGeneraux.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Titre, Me.Valeur})
        Me.DataGridViewTotauxGeneraux.Enabled = False
        Me.DataGridViewTotauxGeneraux.GridColor = System.Drawing.Color.White
        Me.DataGridViewTotauxGeneraux.Location = New System.Drawing.Point(12, 396)
        Me.DataGridViewTotauxGeneraux.MultiSelect = False
        Me.DataGridViewTotauxGeneraux.Name = "DataGridViewTotauxGeneraux"
        Me.DataGridViewTotauxGeneraux.ReadOnly = True
        Me.DataGridViewTotauxGeneraux.RowHeadersVisible = False
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DataGridViewTotauxGeneraux.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTotauxGeneraux.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridViewTotauxGeneraux.Size = New System.Drawing.Size(300, 40)
        Me.DataGridViewTotauxGeneraux.TabIndex = 3
        '
        'Titre
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.Titre.DefaultCellStyle = DataGridViewCellStyle18
        Me.Titre.HeaderText = "Titre"
        Me.Titre.Name = "Titre"
        Me.Titre.ReadOnly = True
        Me.Titre.Width = 200
        '
        'Valeur
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.NullValue = Nothing
        Me.Valeur.DefaultCellStyle = DataGridViewCellStyle19
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.Name = "Valeur"
        Me.Valeur.ReadOnly = True
        '
        'LabelTitre
        '
        Me.LabelTitre.AutoSize = True
        Me.LabelTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitre.Location = New System.Drawing.Point(8, 25)
        Me.LabelTitre.Name = "LabelTitre"
        Me.LabelTitre.Size = New System.Drawing.Size(89, 20)
        Me.LabelTitre.TabIndex = 4
        Me.LabelTitre.Text = "LabelTitre"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLignesToolStripButton, Me.DupliquerToolStripButton, Me.ReprendreDonneesToolStripButton, Me.ToolStripSeparator1, Me.ImprimerToolStripButton, Me.ToolStripSeparator2, Me.SupprimerToolStripButton, Me.ToolStripSeparator3, Me.MonterLigneToolStripButton, Me.DescendreLigneToolStripButton, Me.PositionDeplacementLigneToolStripTextBox, Me.DeplacerLigneToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(892, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'AfficherLignesToolStripButton
        '
        Me.AfficherLignesToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.TableHS
        Me.AfficherLignesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AfficherLignesToolStripButton.Name = "AfficherLignesToolStripButton"
        Me.AfficherLignesToolStripButton.Size = New System.Drawing.Size(103, 22)
        Me.AfficherLignesToolStripButton.Text = "Afficher lignes"
        Me.AfficherLignesToolStripButton.ToolTipText = "Afficher les lignes du groupe"
        '
        'DupliquerToolStripButton
        '
        Me.DupliquerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.Book_StackOfReportsHS
        Me.DupliquerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DupliquerToolStripButton.Name = "DupliquerToolStripButton"
        Me.DupliquerToolStripButton.Size = New System.Drawing.Size(79, 22)
        Me.DupliquerToolStripButton.Text = "Dupliquer"
        Me.DupliquerToolStripButton.ToolTipText = "Dupliquer un groupe"
        '
        'ReprendreDonneesToolStripButton
        '
        Me.ReprendreDonneesToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.Import
        Me.ReprendreDonneesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReprendreDonneesToolStripButton.Name = "ReprendreDonneesToolStripButton"
        Me.ReprendreDonneesToolStripButton.Size = New System.Drawing.Size(129, 22)
        Me.ReprendreDonneesToolStripButton.Text = "Reprendre données"
        Me.ReprendreDonneesToolStripButton.ToolTipText = "Reprendre les données du dossier précédent"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ImprimerToolStripButton
        '
        Me.ImprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.impr
        Me.ImprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimerToolStripButton.Name = "ImprimerToolStripButton"
        Me.ImprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimerToolStripButton.Text = "Imprimer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'MonterLigneToolStripButton
        '
        Me.MonterLigneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MonterLigneToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.UpArrowShort_Blue
        Me.MonterLigneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MonterLigneToolStripButton.Name = "MonterLigneToolStripButton"
        Me.MonterLigneToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.MonterLigneToolStripButton.Text = "Monter"
        Me.MonterLigneToolStripButton.ToolTipText = "Monter la ligne"
        '
        'DescendreLigneToolStripButton
        '
        Me.DescendreLigneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DescendreLigneToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.DownArrowShort_Blue
        Me.DescendreLigneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DescendreLigneToolStripButton.Name = "DescendreLigneToolStripButton"
        Me.DescendreLigneToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DescendreLigneToolStripButton.Text = "Descendre la ligne"
        Me.DescendreLigneToolStripButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'PositionDeplacementLigneToolStripTextBox
        '
        Me.PositionDeplacementLigneToolStripTextBox.Name = "PositionDeplacementLigneToolStripTextBox"
        Me.PositionDeplacementLigneToolStripTextBox.Size = New System.Drawing.Size(40, 25)
        Me.PositionDeplacementLigneToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DeplacerLigneToolStripButton
        '
        Me.DeplacerLigneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeplacerLigneToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.Sort
        Me.DeplacerLigneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeplacerLigneToolStripButton.Name = "DeplacerLigneToolStripButton"
        Me.DeplacerLigneToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DeplacerLigneToolStripButton.Text = "Deplacer"
        Me.DeplacerLigneToolStripButton.ToolTipText = "Deplacer la ligne à cette position"
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn1.HeaderText = "Titre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn2.HeaderText = "Valeur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'FrInventaireGroupes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(892, 445)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DataGridViewTotauxGeneraux)
        Me.Controls.Add(Me.LabelTitre)
        Me.Controls.Add(Me.InventaireGroupesDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrInventaireGroupes"
        Me.Text = "FrInventaire"
        CType(Me.InventaireGroupesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventaireGroupesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewTotauxGeneraux, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSetAgrigest As AgrigestEDI.DataSetAgrigest
    Friend WithEvents InventaireGroupesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents InventaireGroupesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.DataSetAgrigestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ActivitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.DataSetAgrigestTableAdapters.ActivitesTableAdapter
    Friend WithEvents DataGridViewTotauxGeneraux As System.Windows.Forms.DataGridView
    Friend WithEvents Titre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelTitre As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents AfficherLignesToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DupliquerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReprendreDonneesToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MonterLigneToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DescendreLigneToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PositionDeplacementLigneToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents DeplacerLigneToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents INVGDossier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGTypeInventaire As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGOrdre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGCpt As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents INVGActi As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents INVGDecote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGUnite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValeurHTLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoutParHaLignesMethodeDetaillee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoutTotalFaconsCulturalesMethodeDetailleeLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoutParHaLignesMethodeForfaitaire As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoutTotalFaconsCulturalesMethodeForfaitaireLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValeurHTAvAuxCulturesLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGEstControle As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
