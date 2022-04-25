Option Strict Off

Public Class FrAssistantCreationCompte
    Inherits System.Windows.Forms.Form

    'TODO !! Initialiser la colonne D_C

#Region " Code généré par le Concepteur Windows Form "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    ''' <summary>
    ''' La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    ''' </summary>
    ''' <param name="disposing"></param>
    ''' <remarks></remarks>
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
    Friend WithEvents wizard As GNWizardFrameWork.WizardTemplate
    Friend WithEvents wpSelectionComptes As GNWizardFrameWork.WizardPage
    Friend WithEvents lstDispo As System.Windows.Forms.ListBox
    Friend WithEvents lstSelect As System.Windows.Forms.ListBox
    Friend WithEvents BtAjouterCompte As System.Windows.Forms.Button
    Friend WithEvents BtSupprimerCompte As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSaisieCompte As System.Windows.Forms.TextBox
    Friend WithEvents TxtFiltrerComptes As System.Windows.Forms.TextBox
    Friend WithEvents BtAjouterCompteSaisi As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents wpConfigComptes As GNWizardFrameWork.WizardPage
    Friend WithEvents wpFinish As GNWizardFrameWork.WizardPage
    Friend WithEvents txRecap As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btActivites As System.Windows.Forms.Button
    Friend WithEvents BtSelectAll As System.Windows.Forms.Button
    Friend WithEvents BtDeselect As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxFiltrerComptes2 As System.Windows.Forms.TextBox
    Friend WithEvents dsSelect As AgrigestEDI.dsPLC
    Friend WithEvents ComptesDispoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDispo As AgrigestEDI.dsPLC
    Friend WithEvents ComptesSelectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgvComptes As DataGridViewEnter
    Friend WithEvents ComptesConfigBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompteContreBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsCompteContre As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents SelColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CCptDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLibDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CU1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CU2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivitesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCptContre As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.wizard = New GNWizardFrameWork.WizardTemplate
        Me.wpFinish = New GNWizardFrameWork.WizardPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.txRecap = New System.Windows.Forms.TextBox
        Me.wpSelectionComptes = New GNWizardFrameWork.WizardPage
        Me.BtAjouterCompteSaisi = New System.Windows.Forms.Button
        Me.TxtFiltrerComptes = New System.Windows.Forms.TextBox
        Me.TxtSaisieCompte = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtSupprimerCompte = New System.Windows.Forms.Button
        Me.BtAjouterCompte = New System.Windows.Forms.Button
        Me.lstSelect = New System.Windows.Forms.ListBox
        Me.ComptesSelectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsSelect = New AgrigestEDI.dsPLC
        Me.lstDispo = New System.Windows.Forms.ListBox
        Me.ComptesDispoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDispo = New AgrigestEDI.dsPLC
        Me.wpConfigComptes = New GNWizardFrameWork.WizardPage
        Me.dgvComptes = New AgrigestEDI.DataGridViewEnter
        Me.CompteContreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsCompteContre = New AgrigestEDI.dbDonneesDataSet
        Me.ComptesConfigBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxFiltrerComptes2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtDeselect = New System.Windows.Forms.Button
        Me.BtSelectAll = New System.Windows.Forms.Button
        Me.btActivites = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ComptesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
        Me.SelColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CCptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CLibDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CU1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CU2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivitesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CCptContre = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.wizard.SuspendLayout()
        Me.wpFinish.SuspendLayout()
        Me.wpSelectionComptes.SuspendLayout()
        CType(Me.ComptesSelectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComptesDispoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDispo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpConfigComptes.SuspendLayout()
        CType(Me.dgvComptes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompteContreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCompteContre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComptesConfigBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wizard
        '
        Me.wizard.BannerImage = Nothing
        Me.wizard.CancelButtonText = "&Annuler"
        Me.wizard.Controls.Add(Me.wpFinish)
        Me.wizard.Controls.Add(Me.wpSelectionComptes)
        Me.wizard.Controls.Add(Me.wpConfigComptes)
        Me.wizard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wizard.FinishButtonText = "&Terminer"
        Me.wizard.Location = New System.Drawing.Point(0, 0)
        Me.wizard.Name = "wizard"
        Me.wizard.NextButtonText = "&Suivant"
        Me.wizard.Pages.Add(Me.wpSelectionComptes)
        Me.wizard.Pages.Add(Me.wpConfigComptes)
        Me.wizard.Pages.Add(Me.wpFinish)
        Me.wizard.PreviousButtonText = "&Précédent"
        Me.wizard.Size = New System.Drawing.Size(699, 464)
        Me.wizard.StartItemIndex = 0
        Me.wizard.TabIndex = 0
        '
        'wpFinish
        '
        Me.wpFinish.Controls.Add(Me.Label3)
        Me.wpFinish.Controls.Add(Me.txRecap)
        Me.wpFinish.HasCancelButton = True
        Me.wpFinish.HasFinishButton = True
        Me.wpFinish.HasNextButton = False
        Me.wpFinish.HasPreviousButton = True
        Me.wpFinish.HeaderCaption = "Résumé"
        Me.wpFinish.Location = New System.Drawing.Point(0, 0)
        Me.wpFinish.Name = "wpFinish"
        Me.wpFinish.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpFinish.Size = New System.Drawing.Size(699, 424)
        Me.wpFinish.SubHeaderCaption = "Les comptes suivants vont être créés"
        Me.wpFinish.TabIndex = 6
        Me.wpFinish.Text = "New Tab Item 3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "En cliquant sur Terminer, les comptes suivants seront créés :"
        '
        'txRecap
        '
        Me.txRecap.Location = New System.Drawing.Point(16, 40)
        Me.txRecap.Multiline = True
        Me.txRecap.Name = "txRecap"
        Me.txRecap.ReadOnly = True
        Me.txRecap.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txRecap.Size = New System.Drawing.Size(671, 376)
        Me.txRecap.TabIndex = 0
        Me.txRecap.Text = "txRecap"
        '
        'wpSelectionComptes
        '
        Me.wpSelectionComptes.Controls.Add(Me.BtAjouterCompteSaisi)
        Me.wpSelectionComptes.Controls.Add(Me.TxtFiltrerComptes)
        Me.wpSelectionComptes.Controls.Add(Me.TxtSaisieCompte)
        Me.wpSelectionComptes.Controls.Add(Me.Label2)
        Me.wpSelectionComptes.Controls.Add(Me.Label1)
        Me.wpSelectionComptes.Controls.Add(Me.BtSupprimerCompte)
        Me.wpSelectionComptes.Controls.Add(Me.BtAjouterCompte)
        Me.wpSelectionComptes.Controls.Add(Me.lstSelect)
        Me.wpSelectionComptes.Controls.Add(Me.lstDispo)
        Me.wpSelectionComptes.HasCancelButton = True
        Me.wpSelectionComptes.HasFinishButton = False
        Me.wpSelectionComptes.HasNextButton = False
        Me.wpSelectionComptes.HasPreviousButton = False
        Me.wpSelectionComptes.HeaderCaption = "Sélection des comptes"
        Me.wpSelectionComptes.Location = New System.Drawing.Point(0, 56)
        Me.wpSelectionComptes.Name = "wpSelectionComptes"
        Me.wpSelectionComptes.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpSelectionComptes.Size = New System.Drawing.Size(699, 368)
        Me.wpSelectionComptes.SubHeaderCaption = "Sélectionnez ou saisissez les numéros de compte à ajouter au plan comptable"
        Me.wpSelectionComptes.TabIndex = 4
        Me.wpSelectionComptes.Text = "New Tab Item 1"
        '
        'BtAjouterCompteSaisi
        '
        Me.BtAjouterCompteSaisi.Location = New System.Drawing.Point(176, 14)
        Me.BtAjouterCompteSaisi.Name = "BtAjouterCompteSaisi"
        Me.BtAjouterCompteSaisi.Size = New System.Drawing.Size(32, 20)
        Me.BtAjouterCompteSaisi.TabIndex = 8
        Me.BtAjouterCompteSaisi.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.BtAjouterCompteSaisi, "Ajouter le compte saisi")
        '
        'TxtFiltrerComptes
        '
        Me.TxtFiltrerComptes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFiltrerComptes.Location = New System.Drawing.Point(200, 48)
        Me.TxtFiltrerComptes.MaxLength = 8
        Me.TxtFiltrerComptes.Name = "TxtFiltrerComptes"
        Me.TxtFiltrerComptes.Size = New System.Drawing.Size(56, 20)
        Me.TxtFiltrerComptes.TabIndex = 2
        Me.TxtFiltrerComptes.Text = "00000000"
        '
        'TxtSaisieCompte
        '
        Me.TxtSaisieCompte.Location = New System.Drawing.Point(120, 14)
        Me.TxtSaisieCompte.MaxLength = 8
        Me.TxtSaisieCompte.Name = "TxtSaisieCompte"
        Me.TxtSaisieCompte.Size = New System.Drawing.Size(56, 20)
        Me.TxtSaisieCompte.TabIndex = 7
        Me.TxtSaisieCompte.Text = "00000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Choisir un compte commençant par :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ajouter le compte n° :"
        '
        'BtSupprimerCompte
        '
        Me.BtSupprimerCompte.Location = New System.Drawing.Point(336, 184)
        Me.BtSupprimerCompte.Name = "BtSupprimerCompte"
        Me.BtSupprimerCompte.Size = New System.Drawing.Size(40, 23)
        Me.BtSupprimerCompte.TabIndex = 5
        Me.BtSupprimerCompte.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.BtSupprimerCompte, "Enlever les comptes sélectionnés")
        '
        'BtAjouterCompte
        '
        Me.BtAjouterCompte.Location = New System.Drawing.Point(336, 152)
        Me.BtAjouterCompte.Name = "BtAjouterCompte"
        Me.BtAjouterCompte.Size = New System.Drawing.Size(40, 23)
        Me.BtAjouterCompte.TabIndex = 4
        Me.BtAjouterCompte.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.BtAjouterCompte, "Ajouter les comptes sélectionnés")
        '
        'lstSelect
        '
        Me.lstSelect.DataSource = Me.ComptesSelectBindingSource
        Me.lstSelect.DisplayMember = "CDisplay"
        Me.lstSelect.Location = New System.Drawing.Point(382, 72)
        Me.lstSelect.Name = "lstSelect"
        Me.lstSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelect.Size = New System.Drawing.Size(305, 290)
        Me.lstSelect.TabIndex = 6
        Me.lstSelect.ValueMember = "CCpt"
        '
        'ComptesSelectBindingSource
        '
        Me.ComptesSelectBindingSource.DataMember = "Comptes"
        Me.ComptesSelectBindingSource.DataSource = Me.dsSelect
        '
        'dsSelect
        '
        Me.dsSelect.DataSetName = "dsPLC"
        Me.dsSelect.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lstDispo
        '
        Me.lstDispo.DataSource = Me.ComptesDispoBindingSource
        Me.lstDispo.DisplayMember = "PlDisplay"
        Me.lstDispo.Location = New System.Drawing.Point(8, 72)
        Me.lstDispo.Name = "lstDispo"
        Me.lstDispo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstDispo.Size = New System.Drawing.Size(322, 290)
        Me.lstDispo.TabIndex = 3
        Me.lstDispo.ValueMember = "PlACpt"
        '
        'ComptesDispoBindingSource
        '
        Me.ComptesDispoBindingSource.DataMember = "PlanType"
        Me.ComptesDispoBindingSource.DataSource = Me.dsDispo
        Me.ComptesDispoBindingSource.Filter = "PlCpt like '1*'"
        '
        'dsDispo
        '
        Me.dsDispo.DataSetName = "dsPLC"
        Me.dsDispo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'wpConfigComptes
        '
        Me.wpConfigComptes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wpConfigComptes.Controls.Add(Me.dgvComptes)
        Me.wpConfigComptes.Controls.Add(Me.TxFiltrerComptes2)
        Me.wpConfigComptes.Controls.Add(Me.Label5)
        Me.wpConfigComptes.Controls.Add(Me.Label4)
        Me.wpConfigComptes.Controls.Add(Me.BtDeselect)
        Me.wpConfigComptes.Controls.Add(Me.BtSelectAll)
        Me.wpConfigComptes.Controls.Add(Me.btActivites)
        Me.wpConfigComptes.HasCancelButton = True
        Me.wpConfigComptes.HasFinishButton = False
        Me.wpConfigComptes.HasNextButton = True
        Me.wpConfigComptes.HasPreviousButton = True
        Me.wpConfigComptes.HeaderCaption = "Configuration des comptes"
        Me.wpConfigComptes.Location = New System.Drawing.Point(0, 56)
        Me.wpConfigComptes.Name = "wpConfigComptes"
        Me.wpConfigComptes.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpConfigComptes.Size = New System.Drawing.Size(699, 368)
        Me.wpConfigComptes.SubHeaderCaption = "Saisissez les libellés et unités pour les comptes sélectionnés"
        Me.wpConfigComptes.TabIndex = 5
        Me.wpConfigComptes.Text = "New Tab Item 2"
        '
        'dgvComptes
        '
        Me.dgvComptes.AllowUserToAddRows = False
        Me.dgvComptes.AllowUserToDeleteRows = False
        Me.dgvComptes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComptes.AutoGenerateColumns = False
        Me.dgvComptes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvComptes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComptes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelColumn, Me.CCptDataGridViewTextBoxColumn, Me.CLibDataGridViewTextBoxColumn, Me.CU1DataGridViewTextBoxColumn, Me.CU2DataGridViewTextBoxColumn, Me.ActivitesColumn, Me.CCptContre})
        Me.dgvComptes.DataSource = Me.ComptesConfigBindingSource
        Me.dgvComptes.JumpToMontant = False
        Me.dgvComptes.Location = New System.Drawing.Point(8, 56)
        Me.dgvComptes.Name = "dgvComptes"
        Me.dgvComptes.RowHeadersVisible = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComptes.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComptes.Size = New System.Drawing.Size(681, 274)
        Me.dgvComptes.TabIndex = 8
        '
        'CompteContreBindingSource
        '
        Me.CompteContreBindingSource.AllowNew = False
        Me.CompteContreBindingSource.DataMember = "Comptes"
        Me.CompteContreBindingSource.DataSource = Me.dsCompteContre
        Me.CompteContreBindingSource.Filter = ""
        Me.CompteContreBindingSource.Sort = "CCpt"
        '
        'dsCompteContre
        '
        Me.dsCompteContre.DataSetName = "dbDonneesDataSet"
        Me.dsCompteContre.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComptesConfigBindingSource
        '
        Me.ComptesConfigBindingSource.DataMember = "Comptes"
        Me.ComptesConfigBindingSource.DataSource = Me.dsSelect
        Me.ComptesConfigBindingSource.Sort = "CCpt"
        '
        'TxFiltrerComptes2
        '
        Me.TxFiltrerComptes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxFiltrerComptes2.Location = New System.Drawing.Point(208, 30)
        Me.TxFiltrerComptes2.MaxLength = 8
        Me.TxFiltrerComptes2.Name = "TxFiltrerComptes2"
        Me.TxFiltrerComptes2.Size = New System.Drawing.Size(56, 20)
        Me.TxFiltrerComptes2.TabIndex = 6
        Me.TxFiltrerComptes2.Text = "00000000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Afficher les comptes commençant par :"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(544, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pour affecter d'autres activités aux comptes, sélectionnez-les en cochant leur ca" & _
            "se."
        '
        'BtDeselect
        '
        Me.BtDeselect.Location = New System.Drawing.Point(120, 336)
        Me.BtDeselect.Name = "BtDeselect"
        Me.BtDeselect.Size = New System.Drawing.Size(120, 23)
        Me.BtDeselect.TabIndex = 3
        Me.BtDeselect.Text = "Tout désélectionner"
        '
        'BtSelectAll
        '
        Me.BtSelectAll.Location = New System.Drawing.Point(8, 336)
        Me.BtSelectAll.Name = "BtSelectAll"
        Me.BtSelectAll.Size = New System.Drawing.Size(104, 23)
        Me.BtSelectAll.TabIndex = 2
        Me.BtSelectAll.Text = "Tout sélectionner"
        '
        'btActivites
        '
        Me.btActivites.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btActivites.Location = New System.Drawing.Point(561, 336)
        Me.btActivites.Name = "btActivites"
        Me.btActivites.Size = New System.Drawing.Size(128, 23)
        Me.btActivites.TabIndex = 1
        Me.btActivites.Text = "Affecter les activités"
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'SelColumn
        '
        Me.SelColumn.DataPropertyName = "CSelected"
        Me.SelColumn.HeaderText = "Sel."
        Me.SelColumn.Name = "SelColumn"
        Me.SelColumn.Width = 35
        '
        'CCptDataGridViewTextBoxColumn
        '
        Me.CCptDataGridViewTextBoxColumn.DataPropertyName = "CCpt"
        Me.CCptDataGridViewTextBoxColumn.HeaderText = "Compte"
        Me.CCptDataGridViewTextBoxColumn.Name = "CCptDataGridViewTextBoxColumn"
        Me.CCptDataGridViewTextBoxColumn.ReadOnly = True
        Me.CCptDataGridViewTextBoxColumn.Width = 75
        '
        'CLibDataGridViewTextBoxColumn
        '
        Me.CLibDataGridViewTextBoxColumn.DataPropertyName = "CLib"
        Me.CLibDataGridViewTextBoxColumn.HeaderText = "Libellé"
        Me.CLibDataGridViewTextBoxColumn.MaxInputLength = 30
        Me.CLibDataGridViewTextBoxColumn.Name = "CLibDataGridViewTextBoxColumn"
        Me.CLibDataGridViewTextBoxColumn.Width = 150
        '
        'CU1DataGridViewTextBoxColumn
        '
        Me.CU1DataGridViewTextBoxColumn.DataPropertyName = "CU1"
        Me.CU1DataGridViewTextBoxColumn.HeaderText = "U1"
        Me.CU1DataGridViewTextBoxColumn.Name = "CU1DataGridViewTextBoxColumn"
        Me.CU1DataGridViewTextBoxColumn.Width = 50
        '
        'CU2DataGridViewTextBoxColumn
        '
        Me.CU2DataGridViewTextBoxColumn.DataPropertyName = "CU2"
        Me.CU2DataGridViewTextBoxColumn.HeaderText = "U2"
        Me.CU2DataGridViewTextBoxColumn.Name = "CU2DataGridViewTextBoxColumn"
        Me.CU2DataGridViewTextBoxColumn.Width = 50
        '
        'ActivitesColumn
        '
        Me.ActivitesColumn.DataPropertyName = "CActivites"
        Me.ActivitesColumn.HeaderText = "Activités"
        Me.ActivitesColumn.Name = "ActivitesColumn"
        Me.ActivitesColumn.ReadOnly = True
        Me.ActivitesColumn.Width = 150
        '
        'CCptContre
        '
        Me.CCptContre.DataPropertyName = "CCptContre"
        Me.CCptContre.DataSource = Me.CompteContreBindingSource
        Me.CCptContre.DisplayComboBoxOnCurrentCellOnly = False
        Me.CCptContre.DisplayMember = "CompteDisplay"
        Me.CCptContre.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.CCptContre.DisplayStyleForCurrentCellOnly = True
        Me.CCptContre.DropDownWidth = 200
        Me.CCptContre.HeaderText = "Contre Partie"
        Me.CCptContre.Name = "CCptContre"
        Me.CCptContre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CCptContre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CCptContre.ValueMember = "CCpt"
        Me.CCptContre.Width = 110
        '
        'FrAssistantCreationCompte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(699, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.wizard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrAssistantCreationCompte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant création de comptes"
        Me.wizard.ResumeLayout(False)
        Me.wpFinish.ResumeLayout(False)
        Me.wpFinish.PerformLayout()
        Me.wpSelectionComptes.ResumeLayout(False)
        Me.wpSelectionComptes.PerformLayout()
        CType(Me.ComptesSelectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComptesDispoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDispo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpConfigComptes.ResumeLayout(False)
        Me.wpConfigComptes.PerformLayout()
        CType(Me.dgvComptes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompteContreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCompteContre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComptesConfigBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum ModeAssistant
        Creation
        Modification
    End Enum

    Public Mode As ModeAssistant = ModeAssistant.Creation
    Public nCompte As String
    Public NouveauCompte As dsPLC.PlanComptableRow
    Public Filter As String = ""

#Region "Page"
    Private Sub FrAssistantCreationCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Cursor.Current = Cursors.WaitCursor
        ApplyStyle(Me.dgvComptes, False)
        Me.ComptesTableAdapter.FillByDossier(Me.dsCompteContre.Comptes, My.User.Name)

        'ajout du compte 00000000
        Dim xRowCompte As dbDonneesDataSet.ComptesRow = Me.dsCompteContre.Comptes.NewComptesRow()
        xRowCompte.CDossier = My.User.Name
        xRowCompte.CCpt = "00000000"
        xRowCompte.CLib = My.Resources.Strings.PLC_ChoixDuCompte
        xRowCompte.CCptContre = "00000000"
        xRowCompte.C_DC = ""
        Me.dsCompteContre.Comptes.AddComptesRow(xRowCompte)

        With Me.dgvComptes
            .AllowUserToResizeRows = True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AutocompletColsMode1.Add(CCptContre)
            .ConfigAutocompleteCombobox()
        End With

        Using dta As New dsPLCTableAdapters.ActivitesTableAdapter
            dta.FillByDossier(dsSelect.Activites, My.User.Name)
        End Using
        If Mode = ModeAssistant.Modification Then
            If Me.nCompte <> "" Then
                Using dta As New dsPLCTableAdapters.ComptesTableAdapter
                    dta.FillByDossierAndCpt(dsSelect.Comptes, My.User.Name, Me.nCompte)
                End Using
                Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                    dta.FillByDossierAndCpt(dsSelect.PlanComptable, My.User.Name, Me.nCompte)
                End Using
            Else
                Using dta As New dsPLCTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(dsSelect.Comptes, My.User.Name)
                End Using
                Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                    dta.FillByDossier(dsSelect.PlanComptable, My.User.Name)
                End Using
            End If
        End If

        'Chargement des pages
        If Mode = ModeAssistant.Creation Then wpSelectionComptes_Load()
        wpConfigurationComptes_Load()

        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Gestion du Wizard"
    Private Sub wizard_CancelClick() Handles wizard.CancelClick
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub wizard_FinishClick() Handles wizard.FinishClick
        'Mise à jour du dataset original
        Cursor.Current = Cursors.WaitCursor

        With dsSelect.PlanComptable
            If .Rows.Count > 0 Then
                For Each dr As dsPLC.PlanComptableRow In .Rows
                    If dr.RowState = DataRowState.Added Then
                        NouveauCompte = dr

                        If Not (dr.IsCptDisplayNull) Then
                            'Mise à jour du libellé de la table PlanComptable avec le libellé de la table Comptes
                            dr.PlLib = dr.CptDisplay
                        End If

                        Exit For
                    End If
                Next
                If NouveauCompte Is Nothing Then
                    If Me.nCompte <> "" Then
                        NouveauCompte = .Select(String.Format("PlCpt='{0}'", nCompte))(0)
                    Else
                        NouveauCompte = .Rows(0)
                    End If
                End If
            End If
        End With

        'Update la base
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDb.OleDbTransaction
            Try
                conn.Open()
                t = conn.BeginTransaction
                Using dta As New dsPLCTableAdapters.ActivitesTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.Activites)
                End Using
                Using dta As New dsPLCTableAdapters.ComptesTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.Comptes)
                End Using
                Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.PlanComptable)
                End Using
                t.Commit()
            Catch ex As Exception
                If t IsNot Nothing Then t.Rollback()
                Throw ex
            End Try
        End Using

        Cursor.Current = Cursors.Default
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub wizard_OnMoveNext(ByVal NextWizPanel As GNWizardFrameWork.WizardPage) Handles wizard.OnMoveNext
        TxFiltrerComptes2.Text = ""
        If NextWizPanel Is wpFinish Then wpFinish_Load()
    End Sub
#End Region

#Region " Page Séléction de comptes "
    Private Sub wpSelectionComptes_Load()
        TxtFiltrerComptes.Text = ""
        TxtSaisieCompte.Text = ""

        With dsDispo
            Using dta As New dsPLCTableAdapters.ComptesTableAdapter
                dta.FillByDossier(.Comptes, My.User.Name)
            End Using
            Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                dta.FillByDossier(.PlanComptable, My.User.Name)
            End Using
            Using dta As New dsPLCTableAdapters.PlanTypeTableAdapter
                dta.Fill(.PlanType)
            End Using
        End With


        ComptesDispoBindingSource.Filter = "CCpt is null"

        TxtSaisieCompte.Select()
    End Sub

    Private Sub TxtFiltrerComptes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles TxtFiltrerComptes.KeyPress, TxFiltrerComptes2.KeyPress, TxtSaisieCompte.KeyPress
        'e.Handled = Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub

    Private Sub TxtSaisieCompte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSaisieCompte.KeyPress
        If e.KeyChar = Chr(13) Then
            BtAjouterCompteSaisi.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub TxtFiltrerComptes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFiltrerComptes.TextChanged
        Dim str As String = TxtFiltrerComptes.Text.Trim
        Dim flt As String = "(CCpt is null)"
        If str.Length > 0 Then
            flt = String.Format("{0} and PlCpt like '{1}*'", flt, str)
        End If
        ComptesDispoBindingSource.Filter = flt
    End Sub

    Private Sub lstDispo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDispo.SelectedIndexChanged
        BtAjouterCompte.Enabled = lstDispo.SelectedItems.Count > 0
    End Sub

    Private Sub lstSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSelect.SelectedIndexChanged
        BtSupprimerCompte.Enabled = lstSelect.SelectedItems.Count > 0
    End Sub

    Private Sub TxtSaisieCompte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSaisieCompte.TextChanged
        BtAjouterCompteSaisi.Enabled = TxtSaisieCompte.Text.Trim.Length > 0
    End Sub

    Private Sub lstSelect_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSelect.DoubleClick
        BtSupprimerCompte.PerformClick()
    End Sub

    Private Sub BtSupprimerCompte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSupprimerCompte.Click
        lstSelect.BeginUpdate()
        Dim drToDel As New ArrayList
        For Each drv As DataRowView In lstSelect.SelectedItems
            drToDel.Add(drv.Row)
        Next
        For Each dr As DataRow In drToDel
            dr.Delete()
        Next
        lstSelect.EndUpdate()
        Me.BindingContext(dsSelect, "Comptes").EndCurrentEdit()
        wpSelectionComptes.HasNextButton = lstSelect.Items.Count > 0
    End Sub

    Private Sub BtAjouterCompteSaisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAjouterCompteSaisi.Click
        Dim nCompte As String = TxtSaisieCompte.Text.Trim.PadRight(8, "0"c)
        Dim rws() As DataRow = dsDispo.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", nCompte))
        Try
            If rws.Length = 0 Then
                AjouterCompte(nCompte, "", "", "", DBNull.Value)
            Else
                AjouterCompte(nCompte, rws(0)("PlLib"), rws(0)("PlU1"), rws(0)("PlU2"), rws(0)("PlD_C"))
            End If
        Catch ex As ApplicationException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Attention")
        End Try
        TxtSaisieCompte.SelectAll()
    End Sub

    Private Sub lstDispo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDispo.DoubleClick
        BtAjouterCompte.PerformClick()
    End Sub

    Private Sub BtAjouterCompte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAjouterCompte.Click
        For Each drv As DataRowView In lstDispo.SelectedItems
            Try
                AjouterCompte(CType(drv.Row, dsPLC.PlanTypeRow))
            Catch ex As ApplicationException
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Attention")
            End Try
        Next
    End Sub

    Private Sub AjouterCompte(ByVal drPlType As dsPLC.PlanTypeRow)
        AjouterCompte(drPlType.PlCpt, drPlType("PlLib"), drPlType("PlU1"), drPlType("PlU2"), drPlType("PlD_C"))
    End Sub

    Private Sub AjouterCompte(ByVal ccpt As String, ByVal clib As Object, ByVal cu1 As Object, ByVal cu2 As Object, ByVal dc As Object)
        'TODO Vérifs à faire: 
        '- L'activité 0000 existe
        TestActivite(dsSelect, "0000")
        '- Le compte n'est pas dans le plan comptable... A VOIR
        '- Le compte n'existe pas déjà => A VOIR, il faut alors juste l'ajouter au PLC
        If CompteExiste(dsDispo, ccpt) Then Throw New ApplicationException(String.Format(My.Resources.Strings.PLC_CompteExiste, ccpt))
        '- Le compte n'a pas déjà été ajouté
        If CompteExiste(dsSelect, ccpt) Then Throw New ApplicationException(String.Format(My.Resources.Strings.PLC_CompteDejaSelect, ccpt))
        '- Le compte est acceptable au niveau racine comptable
        If Not VerifRacineComptable(ccpt) Then Throw New ApplicationException(String.Format(My.Resources.Strings.PLC_PasDansPlanType, ccpt))

        'AJOUT DANS LA TABLE COMPTES
        Dim drCpt As dsPLC.ComptesRow
        With dsSelect.Comptes
            drCpt = .NewComptesRow
            With drCpt
                .CDossier = My.User.Name
                .CCpt = ccpt
                If Not IsDBNull(clib) Then .CLib = Microsoft.VisualBasic.Left(clib, 30)
                If Not IsDBNull(cu1) Then .CU1 = cu1
                If Not IsDBNull(cu2) Then .CU2 = cu2
                If Not IsDBNull(dc) Then .C_DC = dc
            End With
            .Rows.Add(drCpt)
        End With

        'AJOUT DANS LE PLAN COMPTABLE AVEC L'ACTIVITE PAR DEFAUT
        With dsSelect.PlanComptable
            Dim dr As dsPLC.PlanComptableRow = .NewPlanComptableRow
            With dr
                .PlDossier = My.User.Name
                .PlCpt = ccpt
                .PlActi = "0000"
                .PlLib = Microsoft.VisualBasic.Left(clib, 30)
                For Each col As DataColumn In dr.Table.Columns
                    If col.ColumnName.StartsWith("PlRep") OrElse col.ColumnName.StartsWith("PlSolde") Then
                        .Item(col.ColumnName) = 0D
                    End If
                Next
            End With
            .Rows.Add(dr)
        End With

        UpdateActivites(drCpt)
        'ForceRefreshDatagrid()

        'Reset de la sélection dans la liste
        For i As Integer = 0 To lstSelect.Items.Count - 1
            If lstSelect.GetSelected(i) Then lstSelect.SetSelected(i, False)
        Next
        'Sélection de l'item qui vient d'être ajouté
        lstSelect.SelectedIndex = lstSelect.Items.Count - 1
        wpSelectionComptes.HasNextButton = lstSelect.Items.Count > 0
    End Sub

    Private Sub TestActivite(ByVal ds As dsPLC, ByVal aacti As String)
        With ds.Activites
            If .FindByADossierAActi(My.User.Name, aacti) Is Nothing Then
                Dim dr As dsPLC.ActivitesRow = .NewActivitesRow
                With dr
                    .ADossier = My.User.Name
                    .AActi = aacti
                    .ALib = My.Resources.Strings.ACTIVITEGENERALE
                    .AQte = 0
                    .AUnit = ""
                End With
                .Rows.Add(dr)
            End If
        End With
    End Sub

    Private Function CompteExiste(ByVal ds As dsPLC, ByVal ccpt As String) As Boolean
        Return ds.Comptes.FindByCDossierCCpt(My.User.Name, ccpt) IsNot Nothing
    End Function

    Private Function VerifRacineComptable(ByVal ccpt As String) As Boolean
        Return dsDispo.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", ccpt)).Length > 0
    End Function
#End Region

#Region " Page Configuration des comptes "
    Private Sub wpConfigurationComptes_Load()
        TxFiltrerComptes2.Text = Filter

        If Mode = ModeAssistant.Modification Then
            For Each dr As DataRow In dsSelect.Comptes.Rows : UpdateActivites(dr) : Next
            With wpConfigComptes
                .HasNextButton = False
                .HasFinishButton = True
                .HasPreviousButton = False
            End With
            Me.wizard.GotoPage(1)
        End If

        If Mode = ModeAssistant.Modification And nCompte <> "" Then
            For Each dr As dsPLC.ComptesRow In dsSelect.Comptes.Rows : dr.CSelected = True : Next
        End If
    End Sub

    Private Sub TxFiltrerComptes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxFiltrerComptes2.TextChanged
        If ComptesConfigBindingSource.DataSource Is Nothing Then Exit Sub
        Dim str As String = TxFiltrerComptes2.Text.Trim
        Dim flt As String = "(CActivites<>'')"
        If str.Length > 0 Then
            flt = String.Format("{0} and CCpt like '{1}*'", flt, str)
        End If
        ComptesConfigBindingSource.Filter = flt
    End Sub

    Private Sub dgvComptes_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComptes.CellContentClick
        If e.ColumnIndex = SelColumn.Index Then
            dgvComptes.EndEdit()
            ComptesConfigBindingSource.EndEdit()
        End If
    End Sub

    Private Sub ComptesConfigBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComptesConfigBindingSource.CurrentItemChanged
        CompteSelection()
    End Sub

    Private Sub CompteSelection()
        Dim cptSel As Integer = dsSelect.Comptes.CompteSel
        btActivites.Enabled = cptSel > 0
        BtSelectAll.Enabled = cptSel < dsSelect.Comptes.Rows.Count
        BtDeselect.Enabled = cptSel > 0
    End Sub

    Private Sub BtSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles BtSelectAll.Click, BtDeselect.Click
        Dim value As Boolean = sender Is BtSelectAll
        For Each dr As dsPLC.ComptesRow In dsSelect.Comptes.Rows
            dr.CSelected = value
        Next
    End Sub

    Private Sub btActivites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActivites.Click
        Dim selection As New List(Of dsPLC.ComptesRow)
        selection.AddRange(dsSelect.Comptes.Select("CSelected=True"))

        'Appeler la fenetre de choix des activités
        With New FrAssistantAffectationActivite(dsSelect, selection)
            If .ShowDialog = DialogResult.Cancel Then Exit Sub
        End With
        'Maj l'affichage des activités
        For Each dr As dsPLC.ComptesRow In selection : UpdateActivites(dr) : Next
        'ForceRefreshDatagrid()
    End Sub

    Private Sub UpdateActivites(ByVal dr As dsPLC.ComptesRow)
        Dim drPl() As dsPLC.PlanComptableRow = dr.GetPlanComptableRows
        Dim sb As New System.Text.StringBuilder
        For Each drP As dsPLC.PlanComptableRow In drPl
            sb.AppendFormat("{0}" & vbCrLf, drP.ActivitesRowParent.ADisplay)
        Next
        dr.CActivites = sb.ToString.Trim
        ComptesConfigBindingSource.ResetCurrentItem()
    End Sub

#End Region

#Region " Page Récap "
    Private Sub wpFinish_Load()
        Me.Cursor = Cursors.WaitCursor
        Dim sb As New System.Text.StringBuilder
        For Each drC As dsPLC.ComptesRow In dsSelect.Comptes.Rows
            sb.AppendFormat("Compte n°{1} : {2}", drC.ItemArray)
            Dim drs() As dsPLC.PlanComptableRow = drC.GetPlanComptableRows
            Select Case drs.Length
                Case 0
                    sb.Append(vbCrLf)
                Case 1
                    sb.Append(" pour l'activité")
                Case Is > 1
                    sb.Append(" pour les activités :" & vbCrLf)
            End Select
            For Each drPl As dsPLC.PlanComptableRow In drs
                If drs.Length > 1 Then
                    sb.Append(vbTab & "-")
                End If
                sb.AppendFormat(" code {1} : {2}" & vbCrLf, drPl.ActivitesRowParent.ItemArray)
            Next
            sb.Append(vbCrLf)
        Next
        txRecap.Text = sb.ToString
        Me.Cursor = Cursors.Default
    End Sub
#End Region

End Class
