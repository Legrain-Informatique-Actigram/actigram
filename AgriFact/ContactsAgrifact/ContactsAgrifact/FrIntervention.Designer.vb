<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrIntervention
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
        Dim NClientLabel As System.Windows.Forms.Label
        Dim NPersonneAuteurLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim NPersonneDestinataireLabel As System.Windows.Forms.Label
        Dim ConclusionLabel As System.Windows.Forms.Label
        Dim TypeLabel As System.Windows.Forms.Label
        Dim ProduitsPresentesLabel As System.Windows.Forms.Label
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EntrepriseTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter
        Me.EvenementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EvenementTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter
        Me.NClientComboBox = New System.Windows.Forms.ComboBox
        Me.NPersonneAuteurComboBox = New System.Windows.Forms.ComboBox
        Me.PersonneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxElapsed = New System.Windows.Forms.TextBox
        Me.BtStop = New System.Windows.Forms.Button
        Me.BtPauseResume = New System.Windows.Forms.Button
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lnkShow = New System.Windows.Forms.LinkLabel
        Me.PersonneTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter
        Me.ObservationTextBox = New System.Windows.Forms.TextBox
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpIntervention = New System.Windows.Forms.TabPage
        Me.BtListeChoixProduit = New System.Windows.Forms.Button
        Me.BtListeChoixType = New System.Windows.Forms.Button
        Me.ProduitsPresentesComboBox = New System.Windows.Forms.ComboBox
        Me.ListeChoixProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypeComboBox = New System.Windows.Forms.ComboBox
        Me.ListeChoixTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConclusionTextBox = New System.Windows.Forms.TextBox
        Me.BtFicheDest = New System.Windows.Forms.Button
        Me.BtFicheInter = New System.Windows.Forms.Button
        Me.NPersonneDestinataireComboBox = New System.Windows.Forms.ComboBox
        Me.PersonneBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpObs = New System.Windows.Forms.TabPage
        Me.tpPersonnes = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.tpFichiers = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListeChoixTableAdapter = New ContactsAgrifact.DsAgrifactTableAdapters.ListeChoixTableAdapter
        NClientLabel = New System.Windows.Forms.Label
        NPersonneAuteurLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        NPersonneDestinataireLabel = New System.Windows.Forms.Label
        ConclusionLabel = New System.Windows.Forms.Label
        TypeLabel = New System.Windows.Forms.Label
        ProduitsPresentesLabel = New System.Windows.Forms.Label
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpIntervention.SuspendLayout()
        CType(Me.ListeChoixProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonneBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpObs.SuspendLayout()
        Me.tpPersonnes.SuspendLayout()
        Me.tpFichiers.SuspendLayout()
        Me.SuspendLayout()
        '
        'NClientLabel
        '
        NClientLabel.AutoSize = True
        NClientLabel.Location = New System.Drawing.Point(6, 9)
        NClientLabel.Name = "NClientLabel"
        NClientLabel.Size = New System.Drawing.Size(36, 13)
        NClientLabel.TabIndex = 0
        NClientLabel.Text = "Client:"
        '
        'NPersonneAuteurLabel
        '
        NPersonneAuteurLabel.AutoSize = True
        NPersonneAuteurLabel.Location = New System.Drawing.Point(6, 36)
        NPersonneAuteurLabel.Name = "NPersonneAuteurLabel"
        NPersonneAuteurLabel.Size = New System.Drawing.Size(64, 13)
        NPersonneAuteurLabel.TabIndex = 2
        NPersonneAuteurLabel.Text = "Intervenant:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(11, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(39, 13)
        Label1.TabIndex = 5
        Label1.Text = "Durée:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(9, 117)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(40, 13)
        LibelleLabel.TabIndex = 4
        LibelleLabel.Text = "Libelle:"
        '
        'NPersonneDestinataireLabel
        '
        NPersonneDestinataireLabel.AutoSize = True
        NPersonneDestinataireLabel.Location = New System.Drawing.Point(6, 169)
        NPersonneDestinataireLabel.Name = "NPersonneDestinataireLabel"
        NPersonneDestinataireLabel.Size = New System.Drawing.Size(51, 13)
        NPersonneDestinataireLabel.TabIndex = 6
        NPersonneDestinataireLabel.Text = "Suivi par:"
        '
        'ConclusionLabel
        '
        ConclusionLabel.AutoSize = True
        ConclusionLabel.Location = New System.Drawing.Point(6, 143)
        ConclusionLabel.Name = "ConclusionLabel"
        ConclusionLabel.Size = New System.Drawing.Size(62, 13)
        ConclusionLabel.TabIndex = 10
        ConclusionLabel.Text = "Conclusion:"
        '
        'TypeLabel
        '
        TypeLabel.AutoSize = True
        TypeLabel.Location = New System.Drawing.Point(6, 63)
        TypeLabel.Name = "TypeLabel"
        TypeLabel.Size = New System.Drawing.Size(34, 13)
        TypeLabel.TabIndex = 12
        TypeLabel.Text = "Type:"
        '
        'ProduitsPresentesLabel
        '
        ProduitsPresentesLabel.AutoSize = True
        ProduitsPresentesLabel.Location = New System.Drawing.Point(6, 90)
        ProduitsPresentesLabel.Name = "ProduitsPresentesLabel"
        ProduitsPresentesLabel.Size = New System.Drawing.Size(43, 13)
        ProduitsPresentesLabel.TabIndex = 14
        ProduitsPresentesLabel.Text = "Produit:"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Numero"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Numero"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Prenom"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Prénom"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Fonction"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fonction"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Fonction"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fonction"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.DsAgrifact
        Me.EntrepriseBindingSource.Sort = "Nom"
        '
        'EntrepriseTableAdapter
        '
        Me.EntrepriseTableAdapter.ClearBeforeFill = True
        '
        'EvenementBindingSource
        '
        Me.EvenementBindingSource.DataMember = "Evenement"
        Me.EvenementBindingSource.DataSource = Me.DsAgrifact
        '
        'EvenementTableAdapter
        '
        Me.EvenementTableAdapter.ClearBeforeFill = True
        '
        'NClientComboBox
        '
        Me.NClientComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NClientComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "nClient", True))
        Me.NClientComboBox.DataSource = Me.EntrepriseBindingSource
        Me.NClientComboBox.DisplayMember = "Nom"
        Me.NClientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NClientComboBox.FormattingEnabled = True
        Me.NClientComboBox.Location = New System.Drawing.Point(74, 6)
        Me.NClientComboBox.Name = "NClientComboBox"
        Me.NClientComboBox.Size = New System.Drawing.Size(289, 21)
        Me.NClientComboBox.TabIndex = 1
        Me.NClientComboBox.ValueMember = "nEntreprise"
        '
        'NPersonneAuteurComboBox
        '
        Me.NPersonneAuteurComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NPersonneAuteurComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "nPersonneAuteur", True))
        Me.NPersonneAuteurComboBox.DataSource = Me.PersonneBindingSource
        Me.NPersonneAuteurComboBox.DisplayMember = "Nom"
        Me.NPersonneAuteurComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NPersonneAuteurComboBox.FormattingEnabled = True
        Me.NPersonneAuteurComboBox.Location = New System.Drawing.Point(74, 33)
        Me.NPersonneAuteurComboBox.Name = "NPersonneAuteurComboBox"
        Me.NPersonneAuteurComboBox.Size = New System.Drawing.Size(262, 21)
        Me.NPersonneAuteurComboBox.TabIndex = 3
        Me.NPersonneAuteurComboBox.ValueMember = "nPersonne"
        '
        'PersonneBindingSource
        '
        Me.PersonneBindingSource.DataMember = "Personne"
        Me.PersonneBindingSource.DataSource = Me.DsAgrifact
        Me.PersonneBindingSource.Sort = "Nom"
        '
        'TxElapsed
        '
        Me.TxElapsed.Location = New System.Drawing.Point(56, 12)
        Me.TxElapsed.Name = "TxElapsed"
        Me.TxElapsed.Size = New System.Drawing.Size(54, 20)
        Me.TxElapsed.TabIndex = 4
        Me.TxElapsed.Text = "00:00:00"
        Me.TxElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtStop
        '
        Me.BtStop.Image = Global.ContactsAgrifact.My.Resources.Resources.StopHS
        Me.BtStop.Location = New System.Drawing.Point(137, 12)
        Me.BtStop.Name = "BtStop"
        Me.BtStop.Size = New System.Drawing.Size(27, 20)
        Me.BtStop.TabIndex = 7
        Me.BtStop.UseVisualStyleBackColor = True
        '
        'BtPauseResume
        '
        Me.BtPauseResume.Image = Global.ContactsAgrifact.My.Resources.Resources.PlayHS
        Me.BtPauseResume.Location = New System.Drawing.Point(110, 12)
        Me.BtPauseResume.Name = "BtPauseResume"
        Me.BtPauseResume.Size = New System.Drawing.Size(27, 20)
        Me.BtPauseResume.TabIndex = 6
        Me.BtPauseResume.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'lnkShow
        '
        Me.lnkShow.AutoSize = True
        Me.lnkShow.Image = Global.ContactsAgrifact.My.Resources.Resources.Collapsed
        Me.lnkShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkShow.Location = New System.Drawing.Point(12, 35)
        Me.lnkShow.Name = "lnkShow"
        Me.lnkShow.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lnkShow.Size = New System.Drawing.Size(119, 13)
        Me.lnkShow.TabIndex = 8
        Me.lnkShow.TabStop = True
        Me.lnkShow.Text = "Plus d'informations..."
        '
        'PersonneTableAdapter
        '
        Me.PersonneTableAdapter.ClearBeforeFill = True
        '
        'ObservationTextBox
        '
        Me.ObservationTextBox.AcceptsReturn = True
        Me.ObservationTextBox.AcceptsTab = True
        Me.ObservationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Observation", True))
        Me.ObservationTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObservationTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ObservationTextBox.Multiline = True
        Me.ObservationTextBox.Name = "ObservationTextBox"
        Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ObservationTextBox.Size = New System.Drawing.Size(363, 188)
        Me.ObservationTextBox.TabIndex = 7
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(74, 114)
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(289, 20)
        Me.LibelleTextBox.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpIntervention)
        Me.TabControl1.Controls.Add(Me.tpObs)
        Me.TabControl1.Controls.Add(Me.tpPersonnes)
        Me.TabControl1.Controls.Add(Me.tpFichiers)
        Me.TabControl1.Location = New System.Drawing.Point(14, 51)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(377, 220)
        Me.TabControl1.TabIndex = 10
        '
        'tpIntervention
        '
        Me.tpIntervention.AutoScroll = True
        Me.tpIntervention.Controls.Add(Me.BtListeChoixProduit)
        Me.tpIntervention.Controls.Add(Me.BtListeChoixType)
        Me.tpIntervention.Controls.Add(ProduitsPresentesLabel)
        Me.tpIntervention.Controls.Add(Me.ProduitsPresentesComboBox)
        Me.tpIntervention.Controls.Add(TypeLabel)
        Me.tpIntervention.Controls.Add(Me.TypeComboBox)
        Me.tpIntervention.Controls.Add(ConclusionLabel)
        Me.tpIntervention.Controls.Add(Me.ConclusionTextBox)
        Me.tpIntervention.Controls.Add(Me.BtFicheDest)
        Me.tpIntervention.Controls.Add(Me.BtFicheInter)
        Me.tpIntervention.Controls.Add(NPersonneDestinataireLabel)
        Me.tpIntervention.Controls.Add(Me.NPersonneDestinataireComboBox)
        Me.tpIntervention.Controls.Add(LibelleLabel)
        Me.tpIntervention.Controls.Add(NClientLabel)
        Me.tpIntervention.Controls.Add(Me.LibelleTextBox)
        Me.tpIntervention.Controls.Add(Me.NClientComboBox)
        Me.tpIntervention.Controls.Add(Me.NPersonneAuteurComboBox)
        Me.tpIntervention.Controls.Add(NPersonneAuteurLabel)
        Me.tpIntervention.Location = New System.Drawing.Point(4, 22)
        Me.tpIntervention.Name = "tpIntervention"
        Me.tpIntervention.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIntervention.Size = New System.Drawing.Size(369, 194)
        Me.tpIntervention.TabIndex = 0
        Me.tpIntervention.Text = "Intervention"
        Me.tpIntervention.UseVisualStyleBackColor = True
        '
        'BtListeChoixProduit
        '
        Me.BtListeChoixProduit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtListeChoixProduit.Location = New System.Drawing.Point(336, 87)
        Me.BtListeChoixProduit.Name = "BtListeChoixProduit"
        Me.BtListeChoixProduit.Size = New System.Drawing.Size(27, 21)
        Me.BtListeChoixProduit.TabIndex = 17
        Me.BtListeChoixProduit.Text = "+"
        Me.BtListeChoixProduit.UseVisualStyleBackColor = True
        '
        'BtListeChoixType
        '
        Me.BtListeChoixType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtListeChoixType.Location = New System.Drawing.Point(336, 60)
        Me.BtListeChoixType.Name = "BtListeChoixType"
        Me.BtListeChoixType.Size = New System.Drawing.Size(27, 21)
        Me.BtListeChoixType.TabIndex = 16
        Me.BtListeChoixType.Text = "+"
        Me.BtListeChoixType.UseVisualStyleBackColor = True
        '
        'ProduitsPresentesComboBox
        '
        Me.ProduitsPresentesComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProduitsPresentesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "ProduitsPresentes", True))
        Me.ProduitsPresentesComboBox.DataSource = Me.ListeChoixProduitBindingSource
        Me.ProduitsPresentesComboBox.DisplayMember = "Valeur"
        Me.ProduitsPresentesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProduitsPresentesComboBox.FormattingEnabled = True
        Me.ProduitsPresentesComboBox.Location = New System.Drawing.Point(74, 87)
        Me.ProduitsPresentesComboBox.Name = "ProduitsPresentesComboBox"
        Me.ProduitsPresentesComboBox.Size = New System.Drawing.Size(262, 21)
        Me.ProduitsPresentesComboBox.TabIndex = 15
        Me.ProduitsPresentesComboBox.ValueMember = "Valeur"
        '
        'ListeChoixProduitBindingSource
        '
        Me.ListeChoixProduitBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixProduitBindingSource.DataSource = Me.DsAgrifact
        Me.ListeChoixProduitBindingSource.Filter = "NomChoix='ListeProduits'"
        Me.ListeChoixProduitBindingSource.Sort = "nOrdreValeur"
        '
        'TypeComboBox
        '
        Me.TypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "Type", True))
        Me.TypeComboBox.DataSource = Me.ListeChoixTypeBindingSource
        Me.TypeComboBox.DisplayMember = "Valeur"
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Location = New System.Drawing.Point(74, 60)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(262, 21)
        Me.TypeComboBox.TabIndex = 13
        Me.TypeComboBox.ValueMember = "Valeur"
        '
        'ListeChoixTypeBindingSource
        '
        Me.ListeChoixTypeBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixTypeBindingSource.DataSource = Me.DsAgrifact
        Me.ListeChoixTypeBindingSource.Filter = "NomChoix='ListeTypeEv'"
        Me.ListeChoixTypeBindingSource.Sort = "nOrdreValeur"
        '
        'ConclusionTextBox
        '
        Me.ConclusionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConclusionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EvenementBindingSource, "Conclusion", True))
        Me.ConclusionTextBox.Location = New System.Drawing.Point(74, 140)
        Me.ConclusionTextBox.Name = "ConclusionTextBox"
        Me.ConclusionTextBox.Size = New System.Drawing.Size(289, 20)
        Me.ConclusionTextBox.TabIndex = 11
        '
        'BtFicheDest
        '
        Me.BtFicheDest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtFicheDest.Image = Global.ContactsAgrifact.My.Resources.Resources.user
        Me.BtFicheDest.Location = New System.Drawing.Point(336, 166)
        Me.BtFicheDest.Name = "BtFicheDest"
        Me.BtFicheDest.Size = New System.Drawing.Size(27, 21)
        Me.BtFicheDest.TabIndex = 9
        Me.BtFicheDest.UseVisualStyleBackColor = True
        '
        'BtFicheInter
        '
        Me.BtFicheInter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtFicheInter.Image = Global.ContactsAgrifact.My.Resources.Resources.user
        Me.BtFicheInter.Location = New System.Drawing.Point(336, 33)
        Me.BtFicheInter.Name = "BtFicheInter"
        Me.BtFicheInter.Size = New System.Drawing.Size(27, 21)
        Me.BtFicheInter.TabIndex = 8
        Me.BtFicheInter.UseVisualStyleBackColor = True
        '
        'NPersonneDestinataireComboBox
        '
        Me.NPersonneDestinataireComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NPersonneDestinataireComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EvenementBindingSource, "nPersonneDestinataire", True))
        Me.NPersonneDestinataireComboBox.DataSource = Me.PersonneBindingSource1
        Me.NPersonneDestinataireComboBox.DisplayMember = "Nom"
        Me.NPersonneDestinataireComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NPersonneDestinataireComboBox.FormattingEnabled = True
        Me.NPersonneDestinataireComboBox.Location = New System.Drawing.Point(74, 166)
        Me.NPersonneDestinataireComboBox.Name = "NPersonneDestinataireComboBox"
        Me.NPersonneDestinataireComboBox.Size = New System.Drawing.Size(262, 21)
        Me.NPersonneDestinataireComboBox.TabIndex = 7
        Me.NPersonneDestinataireComboBox.ValueMember = "nPersonne"
        '
        'PersonneBindingSource1
        '
        Me.PersonneBindingSource1.DataMember = "Personne"
        Me.PersonneBindingSource1.DataSource = Me.DsAgrifact
        Me.PersonneBindingSource1.Sort = "Nom"
        '
        'tpObs
        '
        Me.tpObs.Controls.Add(Me.ObservationTextBox)
        Me.tpObs.Location = New System.Drawing.Point(4, 22)
        Me.tpObs.Name = "tpObs"
        Me.tpObs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpObs.Size = New System.Drawing.Size(369, 194)
        Me.tpObs.TabIndex = 1
        Me.tpObs.Text = "Observations"
        Me.tpObs.UseVisualStyleBackColor = True
        '
        'tpPersonnes
        '
        Me.tpPersonnes.Controls.Add(Me.Label3)
        Me.tpPersonnes.Location = New System.Drawing.Point(4, 22)
        Me.tpPersonnes.Name = "tpPersonnes"
        Me.tpPersonnes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPersonnes.Size = New System.Drawing.Size(369, 194)
        Me.tpPersonnes.TabIndex = 2
        Me.tpPersonnes.Text = "Personnes"
        Me.tpPersonnes.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Prochainement..."
        '
        'tpFichiers
        '
        Me.tpFichiers.Controls.Add(Me.Label2)
        Me.tpFichiers.Location = New System.Drawing.Point(4, 22)
        Me.tpFichiers.Name = "tpFichiers"
        Me.tpFichiers.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFichiers.Size = New System.Drawing.Size(369, 194)
        Me.tpFichiers.TabIndex = 3
        Me.tpFichiers.Text = "Fichiers"
        Me.tpFichiers.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Faut pas rever non plus"
        '
        'ListeChoixTableAdapter
        '
        Me.ListeChoixTableAdapter.ClearBeforeFill = True
        '
        'FrIntervention
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 283)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lnkShow)
        Me.Controls.Add(Me.BtStop)
        Me.Controls.Add(Me.BtPauseResume)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.TxElapsed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrIntervention"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Intervention"
        Me.TopMost = True
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EvenementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpIntervention.ResumeLayout(False)
        Me.tpIntervention.PerformLayout()
        CType(Me.ListeChoixProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonneBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpObs.ResumeLayout(False)
        Me.tpObs.PerformLayout()
        Me.tpPersonnes.ResumeLayout(False)
        Me.tpPersonnes.PerformLayout()
        Me.tpFichiers.ResumeLayout(False)
        Me.tpFichiers.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EntrepriseTableAdapter
    Friend WithEvents EvenementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EvenementTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.EvenementTableAdapter
    Friend WithEvents NClientComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NPersonneAuteurComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TxElapsed As System.Windows.Forms.TextBox
    Friend WithEvents BtPauseResume As System.Windows.Forms.Button
    Friend WithEvents BtStop As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents lnkShow As System.Windows.Forms.LinkLabel
    Friend WithEvents PersonneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonneTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.PersonneTableAdapter
    Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpIntervention As System.Windows.Forms.TabPage
    Friend WithEvents tpObs As System.Windows.Forms.TabPage
    Friend WithEvents NPersonneDestinataireComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PersonneBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BtFicheInter As System.Windows.Forms.Button
    Friend WithEvents BtFicheDest As System.Windows.Forms.Button
    Friend WithEvents ConclusionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tpPersonnes As System.Windows.Forms.TabPage
    Friend WithEvents tpFichiers As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProduitsPresentesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ListeChoixTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTableAdapter As ContactsAgrifact.DsAgrifactTableAdapters.ListeChoixTableAdapter
    Friend WithEvents BtListeChoixType As System.Windows.Forms.Button
    Friend WithEvents ListeChoixProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtListeChoixProduit As System.Windows.Forms.Button
End Class
