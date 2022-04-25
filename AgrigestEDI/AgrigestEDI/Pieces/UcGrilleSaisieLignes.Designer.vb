<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcGrilleSaisieLignes
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LignesDgv = New AgrigestEDI.DataGridViewEnter
        Me.Compte = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.CompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsAgrigest = New AgrigestEDI.dbDonneesDataSet
        Me.Activite = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeTVA = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.TVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MontantDeb = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.MontantCre = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Quantite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantBaseHT = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.CMSLigneGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsVisuCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsModifCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cmsAjoutLigne = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsSupprLigne = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.cmsCopieLigne = New System.Windows.Forms.ToolStripMenuItem
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PieceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.lbFiller = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSommeDeb = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSommeCre = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSoldePiece = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.LignesDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLigneGrid.SuspendLayout()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PieceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LignesDgv
        '
        Me.LignesDgv.AllowUserToResizeRows = False
        Me.LignesDgv.AutoGenerateColumns = False
        Me.LignesDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LignesDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LignesDgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LignesDgv.ColumnHeadersHeight = 35
        Me.LignesDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Compte, Me.Activite, Me.Libelle, Me.CodeTVA, Me.MontantDeb, Me.MontantCre, Me.Quantite1, Me.Unite1, Me.Quantite2, Me.Unite2, Me.MontantBaseHT})
        Me.LignesDgv.ContextMenuStrip = Me.CMSLigneGrid
        Me.LignesDgv.DataSource = Me.LignesBindingSource
        Me.LignesDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LignesDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.LignesDgv.GridColor = System.Drawing.Color.LimeGreen
        Me.LignesDgv.JumpToMontant = False
        Me.LignesDgv.Location = New System.Drawing.Point(0, 0)
        Me.LignesDgv.MultiSelect = False
        Me.LignesDgv.Name = "LignesDgv"
        Me.LignesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LignesDgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.LignesDgv.RowHeadersWidth = 25
        Me.LignesDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        Me.LignesDgv.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.LignesDgv.RowTemplate.ContextMenuStrip = Me.CMSLigneGrid
        Me.LignesDgv.Size = New System.Drawing.Size(712, 517)
        Me.LignesDgv.TabIndex = 0
        '
        'Compte
        '
        Me.Compte.DataPropertyName = "Compte"
        Me.Compte.DataSource = Me.CompteBindingSource
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew
        Me.Compte.DefaultCellStyle = DataGridViewCellStyle2
        Me.Compte.DisplayComboBoxOnCurrentCellOnly = False
        Me.Compte.DisplayMember = "CompteDisplay"
        Me.Compte.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Compte.DisplayStyleForCurrentCellOnly = True
        Me.Compte.DropDownWidth = 200
        Me.Compte.HeaderText = "N° du compte"
        Me.Compte.Name = "Compte"
        Me.Compte.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Compte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Compte.ValueMember = "CCpt"
        Me.Compte.Width = 200
        '
        'CompteBindingSource
        '
        Me.CompteBindingSource.AllowNew = True
        Me.CompteBindingSource.DataMember = "Comptes"
        Me.CompteBindingSource.DataSource = Me.dsAgrigest
        Me.CompteBindingSource.Filter = ""
        Me.CompteBindingSource.Sort = "CCpt"
        '
        'dsAgrigest
        '
        Me.dsAgrigest.DataSetName = "dbDonneesDataSet"
        Me.dsAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Activite
        '
        Me.Activite.DataPropertyName = "Activite"
        Me.Activite.DataSource = Me.PlanComptableBindingSource
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew
        Me.Activite.DefaultCellStyle = DataGridViewCellStyle3
        Me.Activite.DisplayComboBoxOnCurrentCellOnly = False
        Me.Activite.DisplayMember = "ActDisplay"
        Me.Activite.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Activite.DisplayStyleForCurrentCellOnly = True
        Me.Activite.DropDownWidth = 80
        Me.Activite.HeaderText = "Activité"
        Me.Activite.Name = "Activite"
        Me.Activite.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Activite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Activite.ValueMember = "PlActi"
        Me.Activite.Width = 80
        '
        'PlanComptableBindingSource
        '
        Me.PlanComptableBindingSource.AllowNew = True
        Me.PlanComptableBindingSource.DataMember = "ComptesPlanComptable"
        Me.PlanComptableBindingSource.DataSource = Me.CompteBindingSource
        Me.PlanComptableBindingSource.Sort = "PlCpt,PlActi"
        '
        'Libelle
        '
        Me.Libelle.DataPropertyName = "Libelle"
        Me.Libelle.HeaderText = "Libellé du mouvement"
        Me.Libelle.MaxInputLength = 55
        Me.Libelle.Name = "Libelle"
        Me.Libelle.Width = 200
        '
        'CodeTVA
        '
        Me.CodeTVA.DataPropertyName = "CodeTva"
        Me.CodeTVA.DataSource = Me.TVABindingSource
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew
        Me.CodeTVA.DefaultCellStyle = DataGridViewCellStyle4
        Me.CodeTVA.DisplayComboBoxOnCurrentCellOnly = False
        Me.CodeTVA.DisplayMember = "TVADisplay"
        Me.CodeTVA.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.CodeTVA.DisplayStyleForCurrentCellOnly = True
        Me.CodeTVA.DropDownWidth = 80
        Me.CodeTVA.HeaderText = "Code TVA"
        Me.CodeTVA.Name = "CodeTVA"
        Me.CodeTVA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodeTVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CodeTVA.ValueMember = "TTVA"
        Me.CodeTVA.Width = 80
        '
        'TVABindingSource
        '
        Me.TVABindingSource.DataMember = "TVA"
        Me.TVABindingSource.DataSource = Me.dsAgrigest
        Me.TVABindingSource.Sort = "TTVA"
        '
        'MontantDeb
        '
        Me.MontantDeb.DataPropertyName = "MontantDeb"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        Me.MontantDeb.DefaultCellStyle = DataGridViewCellStyle5
        Me.MontantDeb.HeaderText = "Montant débit"
        Me.MontantDeb.Name = "MontantDeb"
        Me.MontantDeb.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MontantDeb.Width = 75
        '
        'MontantCre
        '
        Me.MontantCre.DataPropertyName = "MontantCre"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        Me.MontantCre.DefaultCellStyle = DataGridViewCellStyle6
        Me.MontantCre.HeaderText = "Montant crédit"
        Me.MontantCre.Name = "MontantCre"
        Me.MontantCre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MontantCre.Width = 75
        '
        'Quantite1
        '
        Me.Quantite1.DataPropertyName = "Quantite1"
        DataGridViewCellStyle7.Format = "# ##0.000;-# ##0.000;"""""
        Me.Quantite1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Quantite1.HeaderText = "Quantité 1"
        Me.Quantite1.Name = "Quantite1"
        Me.Quantite1.Width = 75
        '
        'Unite1
        '
        Me.Unite1.DataPropertyName = "Unite1"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Honeydew
        Me.Unite1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Unite1.HeaderText = ""
        Me.Unite1.Name = "Unite1"
        Me.Unite1.Width = 30
        '
        'Quantite2
        '
        Me.Quantite2.DataPropertyName = "Quantite2"
        DataGridViewCellStyle9.Format = "# ##0.000;-# ##0.000;"""""
        Me.Quantite2.DefaultCellStyle = DataGridViewCellStyle9
        Me.Quantite2.HeaderText = "Quantité 2"
        Me.Quantite2.Name = "Quantite2"
        Me.Quantite2.Width = 75
        '
        'Unite2
        '
        Me.Unite2.DataPropertyName = "Unite2"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Honeydew
        Me.Unite2.DefaultCellStyle = DataGridViewCellStyle10
        Me.Unite2.HeaderText = ""
        Me.Unite2.Name = "Unite2"
        Me.Unite2.Width = 30
        '
        'MontantBaseHT
        '
        Me.MontantBaseHT.DataPropertyName = "MontantBaseHT"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        Me.MontantBaseHT.DefaultCellStyle = DataGridViewCellStyle11
        Me.MontantBaseHT.HeaderText = "Base HT TVA"
        Me.MontantBaseHT.Name = "MontantBaseHT"
        Me.MontantBaseHT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MontantBaseHT.Width = 60
        '
        'CMSLigneGrid
        '
        Me.CMSLigneGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsVisuCompte, Me.cmsModifCompte, Me.ToolStripSeparator3, Me.cmsAjoutLigne, Me.cmsSupprLigne, Me.ToolStripSeparator4, Me.cmsCopieLigne})
        Me.CMSLigneGrid.Name = "CMSLigneGrid"
        Me.CMSLigneGrid.Size = New System.Drawing.Size(189, 126)
        '
        'cmsVisuCompte
        '
        Me.cmsVisuCompte.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.cmsVisuCompte.Name = "cmsVisuCompte"
        Me.cmsVisuCompte.Size = New System.Drawing.Size(188, 22)
        Me.cmsVisuCompte.Text = "Visualiser le compte..."
        '
        'cmsModifCompte
        '
        Me.cmsModifCompte.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.cmsModifCompte.Name = "cmsModifCompte"
        Me.cmsModifCompte.Size = New System.Drawing.Size(188, 22)
        Me.cmsModifCompte.Text = "Modifier le compte..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(185, 6)
        '
        'cmsAjoutLigne
        '
        Me.cmsAjoutLigne.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.cmsAjoutLigne.Name = "cmsAjoutLigne"
        Me.cmsAjoutLigne.Size = New System.Drawing.Size(188, 22)
        Me.cmsAjoutLigne.Text = "Ajouter une ligne..."
        Me.cmsAjoutLigne.Visible = False
        '
        'cmsSupprLigne
        '
        Me.cmsSupprLigne.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.cmsSupprLigne.Name = "cmsSupprLigne"
        Me.cmsSupprLigne.Size = New System.Drawing.Size(188, 22)
        Me.cmsSupprLigne.Text = "Supprimer la ligne"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(185, 6)
        '
        'cmsCopieLigne
        '
        Me.cmsCopieLigne.Image = Global.AgrigestEDI.My.Resources.Resources.copy
        Me.cmsCopieLigne.Name = "cmsCopieLigne"
        Me.cmsCopieLigne.Size = New System.Drawing.Size(188, 22)
        Me.cmsCopieLigne.Text = "Copier la ligne"
        '
        'LignesBindingSource
        '
        Me.LignesBindingSource.DataMember = "Lignes"
        Me.LignesBindingSource.DataSource = Me.PieceBindingSource
        '
        'PieceBindingSource
        '
        Me.PieceBindingSource.DataSource = GetType(AgrigestEDI.Piece)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbFiller, Me.lbSommeDeb, Me.lbSommeCre, Me.lbSoldePiece})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 492)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(712, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lbFiller
        '
        Me.lbFiller.AutoSize = False
        Me.lbFiller.Name = "lbFiller"
        Me.lbFiller.Size = New System.Drawing.Size(111, 17)
        '
        'lbSommeDeb
        '
        Me.lbSommeDeb.AutoSize = False
        Me.lbSommeDeb.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbSommeDeb.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSommeDeb.Name = "lbSommeDeb"
        Me.lbSommeDeb.Size = New System.Drawing.Size(82, 17)
        Me.lbSommeDeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSommeCre
        '
        Me.lbSommeCre.AutoSize = False
        Me.lbSommeCre.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbSommeCre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSommeCre.Name = "lbSommeCre"
        Me.lbSommeCre.Size = New System.Drawing.Size(79, 17)
        Me.lbSommeCre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSoldePiece
        '
        Me.lbSoldePiece.AutoSize = False
        Me.lbSoldePiece.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lbSoldePiece.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSoldePiece.Name = "lbSoldePiece"
        Me.lbSoldePiece.Size = New System.Drawing.Size(78, 17)
        Me.lbSoldePiece.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UcGrilleSaisieLignes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LignesDgv)
        Me.Name = "UcGrilleSaisieLignes"
        Me.Size = New System.Drawing.Size(712, 517)
        CType(Me.LignesDgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLigneGrid.ResumeLayout(False)
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PieceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LignesDgv As AgrigestEDI.DataGridViewEnter
    Friend WithEvents LignesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsAgrigest As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents CMSLigneGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsVisuCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsModifCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsAjoutLigne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSupprLigne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsCopieLigne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PieceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lbFiller As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSommeDeb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSommeCre As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSoldePiece As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Compte As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents Activite As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeTVA As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents MontantDeb As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents MontantCre As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Quantite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantBaseHT As AgrigestEDI.DatagridViewNumericTextBoxColumn

End Class
