<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSaisieImmo
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
        Me.IdentificationGroupBox = New System.Windows.Forms.GroupBox
        Me.CompoCheckBox = New System.Windows.Forms.CheckBox
        Me.CompoNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.OrdreNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.ActiviteComboBox = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CompteComboBox = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LibTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ObsTextBox = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.DonneesTabPage = New System.Windows.Forms.TabPage
        Me.AmortGroupBox = New System.Windows.Forms.GroupBox
        Me.DureeNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.DerogCheckBox = New System.Windows.Forms.CheckBox
        Me.AideCoeffButton = New System.Windows.Forms.Button
        Me.CoefDTextBox = New System.Windows.Forms.TextBox
        Me.AmortDRadioButton = New System.Windows.Forms.RadioButton
        Me.AmortLRadioButton = New System.Windows.Forms.RadioButton
        Me.CessionGroupBox = New System.Windows.Forms.GroupBox
        Me.ValCessTextBox = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.DtCessDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.ForfGroupBox = New System.Windows.Forms.GroupBox
        Me.ValForfTextBox = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.DureeRestNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.DtForfDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.AcqGroupBox = New System.Windows.Forms.GroupBox
        Me.ValVenaleTextBox = New System.Windows.Forms.TextBox
        Me.MtTVATextBox = New System.Windows.Forms.TextBox
        Me.ValAcquisTextBox = New System.Windows.Forms.TextBox
        Me.DateAcquisDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ResultTabPage = New System.Windows.Forms.TabPage
        Me.PlusValueGroupBox = New System.Windows.Forms.GroupBox
        Me.PlusValLtTextBox = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.PlusValCtTextBox = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.SitFinExGroupBox = New System.Windows.Forms.GroupBox
        Me.DureeResidTextBox = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.ValNetFiscTextBox = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ValResidTextBox = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.AmtExTotTextBox = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.LimAmtGroupBox = New System.Windows.Forms.GroupBox
        Me.AmtExMaxTextBox = New System.Windows.Forms.TextBox
        Me.MaxLinkLabel = New System.Windows.Forms.LinkLabel
        Me.AmtExMinTextBox = New System.Windows.Forms.TextBox
        Me.MinLinkLabel = New System.Windows.Forms.LinkLabel
        Me.SitDebExGroupBox = New System.Windows.Forms.GroupBox
        Me.AnnDDebTextBox = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.AmtCumTotTextBox = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.NewButton = New System.Windows.Forms.Button
        Me.ImmobilisationsDataSet = New AgrigestEDI.ImmobilisationsDataSet
        Me.PlanComptableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlanComptableTableAdapter = New AgrigestEDI.ImmobilisationsDataSetTableAdapters.PlanComptableTableAdapter
        Me.ActivitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ActivitesTableAdapter = New AgrigestEDI.ImmobilisationsDataSetTableAdapters.ActivitesTableAdapter
        Me.ImmobilisationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImmobilisationsTableAdapter = New AgrigestEDI.ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
        Me.ComptesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComptesTableAdapter = New AgrigestEDI.ImmobilisationsDataSetTableAdapters.ComptesTableAdapter
        Me.IdentificationGroupBox.SuspendLayout()
        CType(Me.CompoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdreNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.DonneesTabPage.SuspendLayout()
        Me.AmortGroupBox.SuspendLayout()
        CType(Me.DureeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CessionGroupBox.SuspendLayout()
        Me.ForfGroupBox.SuspendLayout()
        CType(Me.DureeRestNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AcqGroupBox.SuspendLayout()
        Me.ResultTabPage.SuspendLayout()
        Me.PlusValueGroupBox.SuspendLayout()
        Me.SitFinExGroupBox.SuspendLayout()
        Me.LimAmtGroupBox.SuspendLayout()
        Me.SitDebExGroupBox.SuspendLayout()
        CType(Me.ImmobilisationsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImmobilisationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IdentificationGroupBox
        '
        Me.IdentificationGroupBox.Controls.Add(Me.CompoCheckBox)
        Me.IdentificationGroupBox.Controls.Add(Me.CompoNumericUpDown)
        Me.IdentificationGroupBox.Controls.Add(Me.Label4)
        Me.IdentificationGroupBox.Controls.Add(Me.OrdreNumericUpDown)
        Me.IdentificationGroupBox.Controls.Add(Me.Label3)
        Me.IdentificationGroupBox.Controls.Add(Me.ActiviteComboBox)
        Me.IdentificationGroupBox.Controls.Add(Me.Label2)
        Me.IdentificationGroupBox.Controls.Add(Me.CompteComboBox)
        Me.IdentificationGroupBox.Controls.Add(Me.Label1)
        Me.IdentificationGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.IdentificationGroupBox.Name = "IdentificationGroupBox"
        Me.IdentificationGroupBox.Size = New System.Drawing.Size(484, 87)
        Me.IdentificationGroupBox.TabIndex = 0
        Me.IdentificationGroupBox.TabStop = False
        Me.IdentificationGroupBox.Text = "Identification"
        '
        'CompoCheckBox
        '
        Me.CompoCheckBox.AutoSize = True
        Me.CompoCheckBox.Location = New System.Drawing.Point(403, 54)
        Me.CompoCheckBox.Name = "CompoCheckBox"
        Me.CompoCheckBox.Size = New System.Drawing.Size(70, 17)
        Me.CompoCheckBox.TabIndex = 8
        Me.CompoCheckBox.Text = "Composé"
        Me.CompoCheckBox.UseVisualStyleBackColor = True
        Me.CompoCheckBox.Visible = False
        '
        'CompoNumericUpDown
        '
        Me.CompoNumericUpDown.Location = New System.Drawing.Point(325, 51)
        Me.CompoNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.CompoNumericUpDown.Name = "CompoNumericUpDown"
        Me.CompoNumericUpDown.Size = New System.Drawing.Size(55, 20)
        Me.CompoNumericUpDown.TabIndex = 7
        Me.CompoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CompoNumericUpDown.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.CompoNumericUpDown.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "N° composant :"
        Me.Label4.Visible = False
        '
        'OrdreNumericUpDown
        '
        Me.OrdreNumericUpDown.Location = New System.Drawing.Point(325, 24)
        Me.OrdreNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.OrdreNumericUpDown.Name = "OrdreNumericUpDown"
        Me.OrdreNumericUpDown.Size = New System.Drawing.Size(55, 20)
        Me.OrdreNumericUpDown.TabIndex = 5
        Me.OrdreNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.OrdreNumericUpDown.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(239, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "N° ordre :"
        '
        'ActiviteComboBox
        '
        Me.ActiviteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ActiviteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ActiviteComboBox.DisplayMember = "AActi"
        Me.ActiviteComboBox.FormattingEnabled = True
        Me.ActiviteComboBox.Location = New System.Drawing.Point(75, 50)
        Me.ActiviteComboBox.Name = "ActiviteComboBox"
        Me.ActiviteComboBox.Size = New System.Drawing.Size(75, 21)
        Me.ActiviteComboBox.TabIndex = 3
        Me.ActiviteComboBox.ValueMember = "AActi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° activité :"
        '
        'CompteComboBox
        '
        Me.CompteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CompteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CompteComboBox.DisplayMember = "PlCpt"
        Me.CompteComboBox.FormattingEnabled = True
        Me.CompteComboBox.Location = New System.Drawing.Point(75, 23)
        Me.CompteComboBox.Name = "CompteComboBox"
        Me.CompteComboBox.Size = New System.Drawing.Size(158, 21)
        Me.CompteComboBox.TabIndex = 1
        Me.CompteComboBox.ValueMember = "PlCpt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° compte :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Description :"
        '
        'LibTextBox
        '
        Me.LibTextBox.Location = New System.Drawing.Point(93, 109)
        Me.LibTextBox.MaxLength = 35
        Me.LibTextBox.Name = "LibTextBox"
        Me.LibTextBox.Size = New System.Drawing.Size(403, 20)
        Me.LibTextBox.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Observations :"
        '
        'ObsTextBox
        '
        Me.ObsTextBox.AcceptsReturn = True
        Me.ObsTextBox.Location = New System.Drawing.Point(93, 141)
        Me.ObsTextBox.MaxLength = 35
        Me.ObsTextBox.Multiline = True
        Me.ObsTextBox.Name = "ObsTextBox"
        Me.ObsTextBox.Size = New System.Drawing.Size(403, 78)
        Me.ObsTextBox.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.DonneesTabPage)
        Me.TabControl1.Controls.Add(Me.ResultTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 225)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(786, 274)
        Me.TabControl1.TabIndex = 5
        '
        'DonneesTabPage
        '
        Me.DonneesTabPage.Controls.Add(Me.AmortGroupBox)
        Me.DonneesTabPage.Controls.Add(Me.CessionGroupBox)
        Me.DonneesTabPage.Controls.Add(Me.ForfGroupBox)
        Me.DonneesTabPage.Controls.Add(Me.AcqGroupBox)
        Me.DonneesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.DonneesTabPage.Name = "DonneesTabPage"
        Me.DonneesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DonneesTabPage.Size = New System.Drawing.Size(778, 248)
        Me.DonneesTabPage.TabIndex = 0
        Me.DonneesTabPage.Text = "Données"
        Me.DonneesTabPage.UseVisualStyleBackColor = True
        '
        'AmortGroupBox
        '
        Me.AmortGroupBox.Controls.Add(Me.DureeNumericUpDown)
        Me.AmortGroupBox.Controls.Add(Me.Label16)
        Me.AmortGroupBox.Controls.Add(Me.DerogCheckBox)
        Me.AmortGroupBox.Controls.Add(Me.AideCoeffButton)
        Me.AmortGroupBox.Controls.Add(Me.CoefDTextBox)
        Me.AmortGroupBox.Controls.Add(Me.AmortDRadioButton)
        Me.AmortGroupBox.Controls.Add(Me.AmortLRadioButton)
        Me.AmortGroupBox.Location = New System.Drawing.Point(6, 145)
        Me.AmortGroupBox.Name = "AmortGroupBox"
        Me.AmortGroupBox.Size = New System.Drawing.Size(487, 101)
        Me.AmortGroupBox.TabIndex = 3
        Me.AmortGroupBox.TabStop = False
        Me.AmortGroupBox.Text = "Amortissement"
        '
        'DureeNumericUpDown
        '
        Me.DureeNumericUpDown.Location = New System.Drawing.Point(265, 67)
        Me.DureeNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.DureeNumericUpDown.Name = "DureeNumericUpDown"
        Me.DureeNumericUpDown.Size = New System.Drawing.Size(55, 20)
        Me.DureeNumericUpDown.TabIndex = 10
        Me.DureeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DureeNumericUpDown.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(179, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Durée totale d'amortissement (mois) :"
        '
        'DerogCheckBox
        '
        Me.DerogCheckBox.AutoSize = True
        Me.DerogCheckBox.Location = New System.Drawing.Point(333, 43)
        Me.DerogCheckBox.Name = "DerogCheckBox"
        Me.DerogCheckBox.Size = New System.Drawing.Size(79, 17)
        Me.DerogCheckBox.TabIndex = 4
        Me.DerogCheckBox.Text = "dérogatoire"
        Me.DerogCheckBox.UseVisualStyleBackColor = True
        '
        'AideCoeffButton
        '
        Me.AideCoeffButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AideCoeffButton.Location = New System.Drawing.Point(303, 41)
        Me.AideCoeffButton.Name = "AideCoeffButton"
        Me.AideCoeffButton.Size = New System.Drawing.Size(24, 20)
        Me.AideCoeffButton.TabIndex = 3
        Me.AideCoeffButton.TabStop = False
        Me.AideCoeffButton.Text = "?"
        Me.AideCoeffButton.UseVisualStyleBackColor = True
        '
        'CoefDTextBox
        '
        Me.CoefDTextBox.Location = New System.Drawing.Point(265, 41)
        Me.CoefDTextBox.Name = "CoefDTextBox"
        Me.CoefDTextBox.Size = New System.Drawing.Size(32, 20)
        Me.CoefDTextBox.TabIndex = 2
        Me.CoefDTextBox.Text = "1,25"
        Me.CoefDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AmortDRadioButton
        '
        Me.AmortDRadioButton.AutoSize = True
        Me.AmortDRadioButton.Location = New System.Drawing.Point(6, 42)
        Me.AmortDRadioButton.Name = "AmortDRadioButton"
        Me.AmortDRadioButton.Size = New System.Drawing.Size(253, 17)
        Me.AmortDRadioButton.TabIndex = 1
        Me.AmortDRadioButton.TabStop = True
        Me.AmortDRadioButton.Text = "Amortissement dégressif avec un coefficient de :"
        Me.AmortDRadioButton.UseVisualStyleBackColor = True
        '
        'AmortLRadioButton
        '
        Me.AmortLRadioButton.AutoSize = True
        Me.AmortLRadioButton.Location = New System.Drawing.Point(6, 19)
        Me.AmortLRadioButton.Name = "AmortLRadioButton"
        Me.AmortLRadioButton.Size = New System.Drawing.Size(129, 17)
        Me.AmortLRadioButton.TabIndex = 0
        Me.AmortLRadioButton.TabStop = True
        Me.AmortLRadioButton.Text = "Amortissement linéaire"
        Me.AmortLRadioButton.UseVisualStyleBackColor = True
        '
        'CessionGroupBox
        '
        Me.CessionGroupBox.Controls.Add(Me.ValCessTextBox)
        Me.CessionGroupBox.Controls.Add(Me.Label15)
        Me.CessionGroupBox.Controls.Add(Me.DtCessDateTimePicker)
        Me.CessionGroupBox.Controls.Add(Me.Label14)
        Me.CessionGroupBox.Location = New System.Drawing.Point(499, 6)
        Me.CessionGroupBox.Name = "CessionGroupBox"
        Me.CessionGroupBox.Size = New System.Drawing.Size(211, 133)
        Me.CessionGroupBox.TabIndex = 2
        Me.CessionGroupBox.TabStop = False
        Me.CessionGroupBox.Text = "Cession"
        '
        'ValCessTextBox
        '
        Me.ValCessTextBox.Location = New System.Drawing.Point(97, 47)
        Me.ValCessTextBox.Name = "ValCessTextBox"
        Me.ValCessTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValCessTextBox.TabIndex = 9
        Me.ValCessTextBox.Text = "9 999 999,00 €"
        Me.ValCessTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Valeur cession  :"
        '
        'DtCessDateTimePicker
        '
        Me.DtCessDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtCessDateTimePicker.Location = New System.Drawing.Point(97, 21)
        Me.DtCessDateTimePicker.Name = "DtCessDateTimePicker"
        Me.DtCessDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.DtCessDateTimePicker.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Date cession :"
        '
        'ForfGroupBox
        '
        Me.ForfGroupBox.Controls.Add(Me.ValForfTextBox)
        Me.ForfGroupBox.Controls.Add(Me.Label13)
        Me.ForfGroupBox.Controls.Add(Me.DureeRestNumericUpDown)
        Me.ForfGroupBox.Controls.Add(Me.Label12)
        Me.ForfGroupBox.Controls.Add(Me.DtForfDateTimePicker)
        Me.ForfGroupBox.Controls.Add(Me.Label11)
        Me.ForfGroupBox.Location = New System.Drawing.Point(223, 6)
        Me.ForfGroupBox.Name = "ForfGroupBox"
        Me.ForfGroupBox.Size = New System.Drawing.Size(270, 133)
        Me.ForfGroupBox.TabIndex = 1
        Me.ForfGroupBox.TabStop = False
        Me.ForfGroupBox.Text = "Passage au réel"
        '
        'ValForfTextBox
        '
        Me.ValForfTextBox.Location = New System.Drawing.Point(153, 73)
        Me.ValForfTextBox.Name = "ValForfTextBox"
        Me.ValForfTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValForfTextBox.TabIndex = 10
        Me.ValForfTextBox.Text = "9 999 999,00 €"
        Me.ValForfTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Amort. déjà pratiqué :"
        '
        'DureeRestNumericUpDown
        '
        Me.DureeRestNumericUpDown.Location = New System.Drawing.Point(153, 47)
        Me.DureeRestNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.DureeRestNumericUpDown.Name = "DureeRestNumericUpDown"
        Me.DureeRestNumericUpDown.Size = New System.Drawing.Size(55, 20)
        Me.DureeRestNumericUpDown.TabIndex = 8
        Me.DureeRestNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DureeRestNumericUpDown.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Durée d'util. restante (mois) :"
        '
        'DtForfDateTimePicker
        '
        Me.DtForfDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtForfDateTimePicker.Location = New System.Drawing.Point(153, 21)
        Me.DtForfDateTimePicker.Name = "DtForfDateTimePicker"
        Me.DtForfDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.DtForfDateTimePicker.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Date de passage :"
        '
        'AcqGroupBox
        '
        Me.AcqGroupBox.Controls.Add(Me.ValVenaleTextBox)
        Me.AcqGroupBox.Controls.Add(Me.MtTVATextBox)
        Me.AcqGroupBox.Controls.Add(Me.ValAcquisTextBox)
        Me.AcqGroupBox.Controls.Add(Me.DateAcquisDateTimePicker)
        Me.AcqGroupBox.Controls.Add(Me.Label10)
        Me.AcqGroupBox.Controls.Add(Me.Label9)
        Me.AcqGroupBox.Controls.Add(Me.Label8)
        Me.AcqGroupBox.Controls.Add(Me.Label7)
        Me.AcqGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.AcqGroupBox.Name = "AcqGroupBox"
        Me.AcqGroupBox.Size = New System.Drawing.Size(211, 133)
        Me.AcqGroupBox.TabIndex = 0
        Me.AcqGroupBox.TabStop = False
        Me.AcqGroupBox.Text = "Acquisition"
        '
        'ValVenaleTextBox
        '
        Me.ValVenaleTextBox.Location = New System.Drawing.Point(95, 99)
        Me.ValVenaleTextBox.Name = "ValVenaleTextBox"
        Me.ValVenaleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValVenaleTextBox.TabIndex = 7
        Me.ValVenaleTextBox.Text = "9 999 999,00 €"
        Me.ValVenaleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MtTVATextBox
        '
        Me.MtTVATextBox.Location = New System.Drawing.Point(95, 73)
        Me.MtTVATextBox.Name = "MtTVATextBox"
        Me.MtTVATextBox.Size = New System.Drawing.Size(100, 20)
        Me.MtTVATextBox.TabIndex = 6
        Me.MtTVATextBox.Text = "9 999 999,00 €"
        Me.MtTVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ValAcquisTextBox
        '
        Me.ValAcquisTextBox.Location = New System.Drawing.Point(95, 47)
        Me.ValAcquisTextBox.Name = "ValAcquisTextBox"
        Me.ValAcquisTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValAcquisTextBox.TabIndex = 5
        Me.ValAcquisTextBox.Text = "9 999 999,00 €"
        Me.ValAcquisTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DateAcquisDateTimePicker
        '
        Me.DateAcquisDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAcquisDateTimePicker.Location = New System.Drawing.Point(95, 21)
        Me.DateAcquisDateTimePicker.Name = "DateAcquisDateTimePicker"
        Me.DateAcquisDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.DateAcquisDateTimePicker.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Val. vénale  :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "TVA :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Valeur :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Date :"
        '
        'ResultTabPage
        '
        Me.ResultTabPage.Controls.Add(Me.PlusValueGroupBox)
        Me.ResultTabPage.Controls.Add(Me.SitFinExGroupBox)
        Me.ResultTabPage.Controls.Add(Me.AmtExTotTextBox)
        Me.ResultTabPage.Controls.Add(Me.Label19)
        Me.ResultTabPage.Controls.Add(Me.LimAmtGroupBox)
        Me.ResultTabPage.Controls.Add(Me.SitDebExGroupBox)
        Me.ResultTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ResultTabPage.Name = "ResultTabPage"
        Me.ResultTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ResultTabPage.Size = New System.Drawing.Size(778, 248)
        Me.ResultTabPage.TabIndex = 1
        Me.ResultTabPage.Text = "Résultats"
        Me.ResultTabPage.UseVisualStyleBackColor = True
        '
        'PlusValueGroupBox
        '
        Me.PlusValueGroupBox.Controls.Add(Me.PlusValLtTextBox)
        Me.PlusValueGroupBox.Controls.Add(Me.Label24)
        Me.PlusValueGroupBox.Controls.Add(Me.PlusValCtTextBox)
        Me.PlusValueGroupBox.Controls.Add(Me.Label23)
        Me.PlusValueGroupBox.Location = New System.Drawing.Point(302, 125)
        Me.PlusValueGroupBox.Name = "PlusValueGroupBox"
        Me.PlusValueGroupBox.Size = New System.Drawing.Size(156, 113)
        Me.PlusValueGroupBox.TabIndex = 9
        Me.PlusValueGroupBox.TabStop = False
        Me.PlusValueGroupBox.Text = "Plus value"
        '
        'PlusValLtTextBox
        '
        Me.PlusValLtTextBox.Location = New System.Drawing.Point(42, 52)
        Me.PlusValLtTextBox.Name = "PlusValLtTextBox"
        Me.PlusValLtTextBox.ReadOnly = True
        Me.PlusValLtTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PlusValLtTextBox.TabIndex = 12
        Me.PlusValLtTextBox.Text = "9 999 999,00 €"
        Me.PlusValLtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 55)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(26, 13)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "LT :"
        '
        'PlusValCtTextBox
        '
        Me.PlusValCtTextBox.Location = New System.Drawing.Point(42, 26)
        Me.PlusValCtTextBox.Name = "PlusValCtTextBox"
        Me.PlusValCtTextBox.ReadOnly = True
        Me.PlusValCtTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PlusValCtTextBox.TabIndex = 10
        Me.PlusValCtTextBox.Text = "9 999 999,00 €"
        Me.PlusValCtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 29)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "CT :"
        '
        'SitFinExGroupBox
        '
        Me.SitFinExGroupBox.Controls.Add(Me.DureeResidTextBox)
        Me.SitFinExGroupBox.Controls.Add(Me.Label22)
        Me.SitFinExGroupBox.Controls.Add(Me.ValNetFiscTextBox)
        Me.SitFinExGroupBox.Controls.Add(Me.Label21)
        Me.SitFinExGroupBox.Controls.Add(Me.ValResidTextBox)
        Me.SitFinExGroupBox.Controls.Add(Me.Label20)
        Me.SitFinExGroupBox.Location = New System.Drawing.Point(6, 125)
        Me.SitFinExGroupBox.Name = "SitFinExGroupBox"
        Me.SitFinExGroupBox.Size = New System.Drawing.Size(290, 113)
        Me.SitFinExGroupBox.TabIndex = 8
        Me.SitFinExGroupBox.TabStop = False
        Me.SitFinExGroupBox.Text = "Situation en fin d'exercice"
        '
        'DureeResidTextBox
        '
        Me.DureeResidTextBox.Location = New System.Drawing.Point(232, 78)
        Me.DureeResidTextBox.Name = "DureeResidTextBox"
        Me.DureeResidTextBox.ReadOnly = True
        Me.DureeResidTextBox.Size = New System.Drawing.Size(40, 20)
        Me.DureeResidTextBox.TabIndex = 12
        Me.DureeResidTextBox.Text = "99"
        Me.DureeResidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Durée résiduelle :"
        '
        'ValNetFiscTextBox
        '
        Me.ValNetFiscTextBox.Location = New System.Drawing.Point(172, 52)
        Me.ValNetFiscTextBox.Name = "ValNetFiscTextBox"
        Me.ValNetFiscTextBox.ReadOnly = True
        Me.ValNetFiscTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValNetFiscTextBox.TabIndex = 10
        Me.ValNetFiscTextBox.Text = "9 999 999,00 €"
        Me.ValNetFiscTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 13)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Valeur résiduelle fiscale :"
        '
        'ValResidTextBox
        '
        Me.ValResidTextBox.Location = New System.Drawing.Point(172, 26)
        Me.ValResidTextBox.Name = "ValResidTextBox"
        Me.ValResidTextBox.ReadOnly = True
        Me.ValResidTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ValResidTextBox.TabIndex = 8
        Me.ValResidTextBox.Text = "9 999 999,00 €"
        Me.ValResidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Valeur résiduelle :"
        '
        'AmtExTotTextBox
        '
        Me.AmtExTotTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmtExTotTextBox.Location = New System.Drawing.Point(178, 99)
        Me.AmtExTotTextBox.Name = "AmtExTotTextBox"
        Me.AmtExTotTextBox.ReadOnly = True
        Me.AmtExTotTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AmtExTotTextBox.TabIndex = 7
        Me.AmtExTotTextBox.Text = "9 999 999,00 €"
        Me.AmtExTotTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Annuité d'amortissement :"
        '
        'LimAmtGroupBox
        '
        Me.LimAmtGroupBox.Controls.Add(Me.AmtExMaxTextBox)
        Me.LimAmtGroupBox.Controls.Add(Me.MaxLinkLabel)
        Me.LimAmtGroupBox.Controls.Add(Me.AmtExMinTextBox)
        Me.LimAmtGroupBox.Controls.Add(Me.MinLinkLabel)
        Me.LimAmtGroupBox.Location = New System.Drawing.Point(302, 6)
        Me.LimAmtGroupBox.Name = "LimAmtGroupBox"
        Me.LimAmtGroupBox.Size = New System.Drawing.Size(156, 87)
        Me.LimAmtGroupBox.TabIndex = 1
        Me.LimAmtGroupBox.TabStop = False
        Me.LimAmtGroupBox.Text = "Limites d'amortissement"
        '
        'AmtExMaxTextBox
        '
        Me.AmtExMaxTextBox.Location = New System.Drawing.Point(42, 51)
        Me.AmtExMaxTextBox.Name = "AmtExMaxTextBox"
        Me.AmtExMaxTextBox.ReadOnly = True
        Me.AmtExMaxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AmtExMaxTextBox.TabIndex = 9
        Me.AmtExMaxTextBox.Text = "9 999 999,00 €"
        Me.AmtExMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MaxLinkLabel
        '
        Me.MaxLinkLabel.AutoSize = True
        Me.MaxLinkLabel.Location = New System.Drawing.Point(6, 54)
        Me.MaxLinkLabel.Name = "MaxLinkLabel"
        Me.MaxLinkLabel.Size = New System.Drawing.Size(33, 13)
        Me.MaxLinkLabel.TabIndex = 8
        Me.MaxLinkLabel.TabStop = True
        Me.MaxLinkLabel.Text = "Max :"
        '
        'AmtExMinTextBox
        '
        Me.AmtExMinTextBox.Location = New System.Drawing.Point(42, 25)
        Me.AmtExMinTextBox.Name = "AmtExMinTextBox"
        Me.AmtExMinTextBox.ReadOnly = True
        Me.AmtExMinTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AmtExMinTextBox.TabIndex = 7
        Me.AmtExMinTextBox.Text = "9 999 999,00 €"
        Me.AmtExMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MinLinkLabel
        '
        Me.MinLinkLabel.AutoSize = True
        Me.MinLinkLabel.Location = New System.Drawing.Point(6, 28)
        Me.MinLinkLabel.Name = "MinLinkLabel"
        Me.MinLinkLabel.Size = New System.Drawing.Size(30, 13)
        Me.MinLinkLabel.TabIndex = 0
        Me.MinLinkLabel.TabStop = True
        Me.MinLinkLabel.Text = "Min :"
        '
        'SitDebExGroupBox
        '
        Me.SitDebExGroupBox.Controls.Add(Me.AnnDDebTextBox)
        Me.SitDebExGroupBox.Controls.Add(Me.Label18)
        Me.SitDebExGroupBox.Controls.Add(Me.AmtCumTotTextBox)
        Me.SitDebExGroupBox.Controls.Add(Me.Label17)
        Me.SitDebExGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.SitDebExGroupBox.Name = "SitDebExGroupBox"
        Me.SitDebExGroupBox.Size = New System.Drawing.Size(290, 87)
        Me.SitDebExGroupBox.TabIndex = 0
        Me.SitDebExGroupBox.TabStop = False
        Me.SitDebExGroupBox.Text = "Situation en début d'exercice"
        '
        'AnnDDebTextBox
        '
        Me.AnnDDebTextBox.Location = New System.Drawing.Point(232, 51)
        Me.AnnDDebTextBox.Name = "AnnDDebTextBox"
        Me.AnnDDebTextBox.ReadOnly = True
        Me.AnnDDebTextBox.Size = New System.Drawing.Size(40, 20)
        Me.AnnDDebTextBox.TabIndex = 8
        Me.AnnDDebTextBox.Text = "99"
        Me.AnnDDebTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Nombre d'annuités dégressives :"
        '
        'AmtCumTotTextBox
        '
        Me.AmtCumTotTextBox.Location = New System.Drawing.Point(172, 25)
        Me.AmtCumTotTextBox.Name = "AmtCumTotTextBox"
        Me.AmtCumTotTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AmtCumTotTextBox.TabIndex = 6
        Me.AmtCumTotTextBox.Text = "9 999 999,00 €"
        Me.AmtCumTotTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Amortissement cumulé :"
        '
        'AnnulerButton
        '
        Me.AnnulerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(723, 505)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 6
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(642, 505)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 7
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'NewButton
        '
        Me.NewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewButton.Location = New System.Drawing.Point(561, 505)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(75, 23)
        Me.NewButton.TabIndex = 8
        Me.NewButton.Text = "Valider"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'ImmobilisationsDataSet
        '
        Me.ImmobilisationsDataSet.DataSetName = "ImmobilisationsDataSet"
        Me.ImmobilisationsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlanComptableBindingSource
        '
        Me.PlanComptableBindingSource.DataMember = "PlanComptable"
        Me.PlanComptableBindingSource.DataSource = Me.ImmobilisationsDataSet
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'ActivitesBindingSource
        '
        Me.ActivitesBindingSource.DataMember = "Activites"
        Me.ActivitesBindingSource.DataSource = Me.ImmobilisationsDataSet
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'ImmobilisationsBindingSource
        '
        Me.ImmobilisationsBindingSource.DataMember = "Immobilisations"
        Me.ImmobilisationsBindingSource.DataSource = Me.ImmobilisationsDataSet
        '
        'ImmobilisationsTableAdapter
        '
        Me.ImmobilisationsTableAdapter.ClearBeforeFill = True
        '
        'ComptesBindingSource
        '
        Me.ComptesBindingSource.DataMember = "Comptes"
        Me.ComptesBindingSource.DataSource = Me.ImmobilisationsDataSet
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'FrSaisieImmo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(810, 540)
        Me.Controls.Add(Me.NewButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ObsTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LibTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.IdentificationGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSaisieImmo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisie d'une immobilisation"
        Me.IdentificationGroupBox.ResumeLayout(False)
        Me.IdentificationGroupBox.PerformLayout()
        CType(Me.CompoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdreNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.DonneesTabPage.ResumeLayout(False)
        Me.AmortGroupBox.ResumeLayout(False)
        Me.AmortGroupBox.PerformLayout()
        CType(Me.DureeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CessionGroupBox.ResumeLayout(False)
        Me.CessionGroupBox.PerformLayout()
        Me.ForfGroupBox.ResumeLayout(False)
        Me.ForfGroupBox.PerformLayout()
        CType(Me.DureeRestNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AcqGroupBox.ResumeLayout(False)
        Me.AcqGroupBox.PerformLayout()
        Me.ResultTabPage.ResumeLayout(False)
        Me.ResultTabPage.PerformLayout()
        Me.PlusValueGroupBox.ResumeLayout(False)
        Me.PlusValueGroupBox.PerformLayout()
        Me.SitFinExGroupBox.ResumeLayout(False)
        Me.SitFinExGroupBox.PerformLayout()
        Me.LimAmtGroupBox.ResumeLayout(False)
        Me.LimAmtGroupBox.PerformLayout()
        Me.SitDebExGroupBox.ResumeLayout(False)
        Me.SitDebExGroupBox.PerformLayout()
        CType(Me.ImmobilisationsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanComptableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImmobilisationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComptesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IdentificationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents CompteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CompoNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OrdreNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ActiviteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CompoCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LibTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ObsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents DonneesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AcqGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ResultTabPage As System.Windows.Forms.TabPage
    Friend WithEvents MtTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValAcquisTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateAcquisDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ValVenaleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ForfGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DureeRestNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DtForfDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ValForfTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CessionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ValCessTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DtCessDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents AmortGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AideCoeffButton As System.Windows.Forms.Button
    Friend WithEvents CoefDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AmortDRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AmortLRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DureeNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DerogCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SitDebExGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents AmtCumTotTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LimAmtGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AmtExMinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MinLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents AnnDDebTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SitFinExGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ValResidTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents AmtExTotTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents AmtExMaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MaxLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents DureeResidTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ValNetFiscTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PlusValueGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PlusValLtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents PlusValCtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents AmortissementsDataSet As AgrigestEDI.ImmobilisationsDataSet
    Friend WithEvents ImmobilisationsDataSet As AgrigestEDI.ImmobilisationsDataSet
    Friend WithEvents PlanComptableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.ImmobilisationsDataSetTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ActivitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.ImmobilisationsDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents ImmobilisationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImmobilisationsTableAdapter As AgrigestEDI.ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
    Friend WithEvents ComptesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.ImmobilisationsDataSetTableAdapters.ComptesTableAdapter
End Class
