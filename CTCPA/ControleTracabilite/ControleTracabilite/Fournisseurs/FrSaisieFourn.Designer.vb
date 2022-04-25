Namespace Fournisseurs
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieFourn
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
            Dim NomLabel As System.Windows.Forms.Label
            Dim AdresseLabel As System.Windows.Forms.Label
            Dim CodePostalLabel As System.Windows.Forms.Label
            Dim VilleLabel As System.Windows.Forms.Label
            Dim PaysLabel As System.Windows.Forms.Label
            Dim ObservationsLabel As System.Windows.Forms.Label
            Dim EMailLabel As System.Windows.Forms.Label
            Dim SiteInternetLabel As System.Windows.Forms.Label
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.TbInactif = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.TbBR = New System.Windows.Forms.ToolStripButton
            Me.TbNewBR = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.FournBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.ChkEntreprise = New System.Windows.Forms.CheckBox
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.TelephoneEntrepriseDataGridView = New System.Windows.Forms.DataGridView
            Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Type = New System.Windows.Forms.DataGridViewComboBoxColumn
            Me.Numero = New ControleTracabilite.DatagridViewNumericTextBoxColumn
            Me.TelephoneEntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.SiteInternetTextBox = New System.Windows.Forms.TextBox
            Me.EMailTextBox = New System.Windows.Forms.TextBox
            Me.CiviliteComboBox = New System.Windows.Forms.ComboBox
            Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.NomTextBox = New System.Windows.Forms.TextBox
            Me.AdresseTextBox = New System.Windows.Forms.TextBox
            Me.CodePostalTextBox = New System.Windows.Forms.TextBox
            Me.VilleTextBox = New System.Windows.Forms.TextBox
            Me.PaysTextBox = New System.Windows.Forms.TextBox
            Me.ObservationsTextBox = New System.Windows.Forms.TextBox
            Me.EntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            Me.ListeChoixTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
            Me.TelephoneEntrepriseTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.TelephoneEntrepriseTableAdapter
            NomLabel = New System.Windows.Forms.Label
            AdresseLabel = New System.Windows.Forms.Label
            CodePostalLabel = New System.Windows.Forms.Label
            VilleLabel = New System.Windows.Forms.Label
            PaysLabel = New System.Windows.Forms.Label
            ObservationsLabel = New System.Windows.Forms.Label
            EMailLabel = New System.Windows.Forms.Label
            SiteInternetLabel = New System.Windows.Forms.Label
            Me.ToolStrip1.SuspendLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'NomLabel
            '
            NomLabel.AutoSize = True
            NomLabel.Location = New System.Drawing.Point(8, 12)
            NomLabel.Name = "NomLabel"
            NomLabel.Size = New System.Drawing.Size(32, 13)
            NomLabel.TabIndex = 0
            NomLabel.Text = "Nom:"
            '
            'AdresseLabel
            '
            AdresseLabel.AutoSize = True
            AdresseLabel.Location = New System.Drawing.Point(8, 38)
            AdresseLabel.Name = "AdresseLabel"
            AdresseLabel.Size = New System.Drawing.Size(48, 13)
            AdresseLabel.TabIndex = 3
            AdresseLabel.Text = "Adresse:"
            '
            'CodePostalLabel
            '
            CodePostalLabel.AutoSize = True
            CodePostalLabel.Location = New System.Drawing.Point(59, 116)
            CodePostalLabel.Name = "CodePostalLabel"
            CodePostalLabel.Size = New System.Drawing.Size(24, 13)
            CodePostalLabel.TabIndex = 5
            CodePostalLabel.Text = "CP:"
            '
            'VilleLabel
            '
            VilleLabel.AutoSize = True
            VilleLabel.Location = New System.Drawing.Point(125, 116)
            VilleLabel.Name = "VilleLabel"
            VilleLabel.Size = New System.Drawing.Size(29, 13)
            VilleLabel.TabIndex = 7
            VilleLabel.Text = "Ville:"
            '
            'PaysLabel
            '
            PaysLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            PaysLabel.AutoSize = True
            PaysLabel.Location = New System.Drawing.Point(471, 116)
            PaysLabel.Name = "PaysLabel"
            PaysLabel.Size = New System.Drawing.Size(33, 13)
            PaysLabel.TabIndex = 9
            PaysLabel.Text = "Pays:"
            '
            'ObservationsLabel
            '
            ObservationsLabel.AutoSize = True
            ObservationsLabel.Location = New System.Drawing.Point(59, 207)
            ObservationsLabel.Name = "ObservationsLabel"
            ObservationsLabel.Size = New System.Drawing.Size(72, 13)
            ObservationsLabel.TabIndex = 15
            ObservationsLabel.Text = "Observations:"
            '
            'EMailLabel
            '
            EMailLabel.AutoSize = True
            EMailLabel.Location = New System.Drawing.Point(8, 161)
            EMailLabel.Name = "EMailLabel"
            EMailLabel.Size = New System.Drawing.Size(36, 13)
            EMailLabel.TabIndex = 11
            EMailLabel.Text = "EMail:"
            '
            'SiteInternetLabel
            '
            SiteInternetLabel.AutoSize = True
            SiteInternetLabel.Location = New System.Drawing.Point(8, 184)
            SiteInternetLabel.Name = "SiteInternetLabel"
            SiteInternetLabel.Size = New System.Drawing.Size(54, 13)
            SiteInternetLabel.TabIndex = 13
            SiteInternetLabel.Text = "Site Web:"
            '
            'ToolStrip1
            '
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ProduitBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.TbInactif, Me.ToolStripSeparator2, Me.TbBR, Me.TbNewBR, Me.TbFermer})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(582, 25)
            Me.ToolStrip1.TabIndex = 0
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'ToolStripButton1
            '
            Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton1.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton1.Name = "ToolStripButton1"
            Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton1.Text = "Imprimer le bon de réception"
            '
            'ProduitBindingNavigatorSaveItem
            '
            Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ProduitBindingNavigatorSaveItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
            Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
            Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'TbInactif
            '
            Me.TbInactif.Checked = True
            Me.TbInactif.CheckOnClick = True
            Me.TbInactif.CheckState = System.Windows.Forms.CheckState.Checked
            Me.TbInactif.Image = Global.ControleTracabilite.My.Resources.Resources.actif
            Me.TbInactif.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbInactif.Name = "TbInactif"
            Me.TbInactif.Size = New System.Drawing.Size(114, 22)
            Me.TbInactif.Text = "Fournisseur actif"
            Me.TbInactif.ToolTipText = "Marquer le fournisseur inactif"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'TbBR
            '
            Me.TbBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbBR.Image = Global.ControleTracabilite.My.Resources.Resources.liste
            Me.TbBR.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbBR.Name = "TbBR"
            Me.TbBR.Size = New System.Drawing.Size(23, 22)
            Me.TbBR.Text = "Afficher les bons de réception de ce fournisseur"
            '
            'TbNewBR
            '
            Me.TbNewBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbNewBR.Image = Global.ControleTracabilite.My.Resources.Resources._new
            Me.TbNewBR.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbNewBR.Name = "TbNewBR"
            Me.TbNewBR.Size = New System.Drawing.Size(23, 22)
            Me.TbNewBR.Text = "Saisir un nouveau bon de réception"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'FournBindingSource
            '
            Me.FournBindingSource.DataMember = "Entreprise"
            Me.FournBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.FournBindingSource.Sort = "Nom"
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.ChkEntreprise)
            Me.GradientPanel1.Controls.Add(Me.GroupBox1)
            Me.GradientPanel1.Controls.Add(SiteInternetLabel)
            Me.GradientPanel1.Controls.Add(Me.SiteInternetTextBox)
            Me.GradientPanel1.Controls.Add(EMailLabel)
            Me.GradientPanel1.Controls.Add(Me.EMailTextBox)
            Me.GradientPanel1.Controls.Add(Me.CiviliteComboBox)
            Me.GradientPanel1.Controls.Add(NomLabel)
            Me.GradientPanel1.Controls.Add(Me.NomTextBox)
            Me.GradientPanel1.Controls.Add(AdresseLabel)
            Me.GradientPanel1.Controls.Add(Me.AdresseTextBox)
            Me.GradientPanel1.Controls.Add(CodePostalLabel)
            Me.GradientPanel1.Controls.Add(Me.CodePostalTextBox)
            Me.GradientPanel1.Controls.Add(VilleLabel)
            Me.GradientPanel1.Controls.Add(Me.VilleTextBox)
            Me.GradientPanel1.Controls.Add(PaysLabel)
            Me.GradientPanel1.Controls.Add(Me.PaysTextBox)
            Me.GradientPanel1.Controls.Add(ObservationsLabel)
            Me.GradientPanel1.Controls.Add(Me.ObservationsTextBox)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(582, 359)
            Me.GradientPanel1.TabIndex = 1
            '
            'ChkEntreprise
            '
            Me.ChkEntreprise.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ChkEntreprise.AutoSize = True
            Me.ChkEntreprise.Location = New System.Drawing.Point(62, 330)
            Me.ChkEntreprise.Name = "ChkEntreprise"
            Me.ChkEntreprise.Size = New System.Drawing.Size(251, 17)
            Me.ChkEntreprise.TabIndex = 18
            Me.ChkEntreprise.Text = "Fournisseur utilisé pour les livraisons à soi-même"
            Me.ChkEntreprise.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.TelephoneEntrepriseDataGridView)
            Me.GroupBox1.Location = New System.Drawing.Point(368, 158)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(200, 189)
            Me.GroupBox1.TabIndex = 17
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Téléphone"
            '
            'TelephoneEntrepriseDataGridView
            '
            Me.TelephoneEntrepriseDataGridView.AutoGenerateColumns = False
            Me.TelephoneEntrepriseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.TelephoneEntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.Type, Me.Numero})
            Me.TelephoneEntrepriseDataGridView.DataSource = Me.TelephoneEntrepriseBindingSource
            Me.TelephoneEntrepriseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TelephoneEntrepriseDataGridView.Location = New System.Drawing.Point(3, 16)
            Me.TelephoneEntrepriseDataGridView.Name = "TelephoneEntrepriseDataGridView"
            Me.TelephoneEntrepriseDataGridView.RowHeadersVisible = False
            Me.TelephoneEntrepriseDataGridView.Size = New System.Drawing.Size(194, 170)
            Me.TelephoneEntrepriseDataGridView.TabIndex = 0
            '
            'NEntrepriseDataGridViewTextBoxColumn
            '
            Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
            Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
            Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
            Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False
            '
            'Type
            '
            Me.Type.DataPropertyName = "Type"
            Me.Type.DisplayStyleForCurrentCellOnly = True
            Me.Type.HeaderText = "Type"
            Me.Type.Items.AddRange(New Object() {"Siège", "Portable", "Fax"})
            Me.Type.Name = "Type"
            Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Numero
            '
            Me.Numero.DataPropertyName = "Numero"
            Me.Numero.HeaderText = "Numéro"
            Me.Numero.Name = "Numero"
            Me.Numero.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'TelephoneEntrepriseBindingSource
            '
            Me.TelephoneEntrepriseBindingSource.DataMember = "FK_TelephoneEntreprise_Entreprise"
            Me.TelephoneEntrepriseBindingSource.DataSource = Me.FournBindingSource
            '
            'SiteInternetTextBox
            '
            Me.SiteInternetTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SiteInternetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "SiteInternet", True))
            Me.SiteInternetTextBox.Location = New System.Drawing.Point(62, 184)
            Me.SiteInternetTextBox.Name = "SiteInternetTextBox"
            Me.SiteInternetTextBox.Size = New System.Drawing.Size(301, 20)
            Me.SiteInternetTextBox.TabIndex = 14
            '
            'EMailTextBox
            '
            Me.EMailTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EMailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "EMail", True))
            Me.EMailTextBox.Location = New System.Drawing.Point(62, 158)
            Me.EMailTextBox.Name = "EMailTextBox"
            Me.EMailTextBox.Size = New System.Drawing.Size(300, 20)
            Me.EMailTextBox.TabIndex = 12
            '
            'CiviliteComboBox
            '
            Me.CiviliteComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Civilite", True))
            Me.CiviliteComboBox.DataSource = Me.ListeChoixBindingSource
            Me.CiviliteComboBox.DisplayMember = "Valeur"
            Me.CiviliteComboBox.FormattingEnabled = True
            Me.CiviliteComboBox.Location = New System.Drawing.Point(62, 8)
            Me.CiviliteComboBox.Name = "CiviliteComboBox"
            Me.CiviliteComboBox.Size = New System.Drawing.Size(79, 21)
            Me.CiviliteComboBox.TabIndex = 1
            Me.CiviliteComboBox.ValueMember = "Valeur"
            '
            'ListeChoixBindingSource
            '
            Me.ListeChoixBindingSource.DataMember = "ListeChoix"
            Me.ListeChoixBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'NomTextBox
            '
            Me.NomTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Nom", True))
            Me.NomTextBox.Location = New System.Drawing.Point(147, 9)
            Me.NomTextBox.Name = "NomTextBox"
            Me.NomTextBox.Size = New System.Drawing.Size(423, 20)
            Me.NomTextBox.TabIndex = 2
            '
            'AdresseTextBox
            '
            Me.AdresseTextBox.AcceptsReturn = True
            Me.AdresseTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AdresseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Adresse", True))
            Me.AdresseTextBox.Location = New System.Drawing.Point(62, 35)
            Me.AdresseTextBox.Multiline = True
            Me.AdresseTextBox.Name = "AdresseTextBox"
            Me.AdresseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.AdresseTextBox.Size = New System.Drawing.Size(506, 78)
            Me.AdresseTextBox.TabIndex = 4
            '
            'CodePostalTextBox
            '
            Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "CodePostal", True))
            Me.CodePostalTextBox.Location = New System.Drawing.Point(62, 132)
            Me.CodePostalTextBox.Name = "CodePostalTextBox"
            Me.CodePostalTextBox.Size = New System.Drawing.Size(60, 20)
            Me.CodePostalTextBox.TabIndex = 6
            Me.CodePostalTextBox.Text = "99 999"
            Me.CodePostalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'VilleTextBox
            '
            Me.VilleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Ville", True))
            Me.VilleTextBox.Location = New System.Drawing.Point(128, 132)
            Me.VilleTextBox.Name = "VilleTextBox"
            Me.VilleTextBox.Size = New System.Drawing.Size(339, 20)
            Me.VilleTextBox.TabIndex = 8
            '
            'PaysTextBox
            '
            Me.PaysTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PaysTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Pays", True))
            Me.PaysTextBox.Location = New System.Drawing.Point(473, 132)
            Me.PaysTextBox.Name = "PaysTextBox"
            Me.PaysTextBox.Size = New System.Drawing.Size(95, 20)
            Me.PaysTextBox.TabIndex = 10
            '
            'ObservationsTextBox
            '
            Me.ObservationsTextBox.AcceptsReturn = True
            Me.ObservationsTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ObservationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournBindingSource, "Observations", True))
            Me.ObservationsTextBox.Location = New System.Drawing.Point(62, 223)
            Me.ObservationsTextBox.Multiline = True
            Me.ObservationsTextBox.Name = "ObservationsTextBox"
            Me.ObservationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ObservationsTextBox.Size = New System.Drawing.Size(301, 101)
            Me.ObservationsTextBox.TabIndex = 16
            '
            'EntrepriseTableAdapter
            '
            Me.EntrepriseTableAdapter.ClearBeforeFill = True
            '
            'ListeChoixTableAdapter
            '
            Me.ListeChoixTableAdapter.ClearBeforeFill = True
            '
            'TelephoneEntrepriseTableAdapter
            '
            Me.TelephoneEntrepriseTableAdapter.ClearBeforeFill = True
            '
            'FrSaisieFourn
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(582, 384)
            Me.ControlBox = False
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.ToolStrip1)
            Me.Name = "FrSaisieFourn"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Fiche Fournisseur"
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            CType(Me.FournBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents FournBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents EntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
        Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
        Friend WithEvents AdresseTextBox As System.Windows.Forms.TextBox
        Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
        Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PaysTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ObservationsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents CiviliteComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ListeChoixTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
        Friend WithEvents TelephoneEntrepriseBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TelephoneEntrepriseTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.TelephoneEntrepriseTableAdapter
        Friend WithEvents TelephoneEntrepriseDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Type As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents Numero As ControleTracabilite.DatagridViewNumericTextBoxColumn
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbBR As System.Windows.Forms.ToolStripButton
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents SiteInternetTextBox As System.Windows.Forms.TextBox
        Friend WithEvents EMailTextBox As System.Windows.Forms.TextBox
        Friend WithEvents TbInactif As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TbNewBR As System.Windows.Forms.ToolStripButton
        Friend WithEvents ChkEntreprise As System.Windows.Forms.CheckBox
    End Class
End Namespace