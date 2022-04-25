<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrManagerFichier
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtRestaurer = New System.Windows.Forms.Button
        Me.RestDlg = New System.Windows.Forms.OpenFileDialog
        Me.ErrorDlg = New System.Windows.Forms.SaveFileDialog
        Me.ComptesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.PiecesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
        Me.DatagridViewComboboxColumnCustom1 = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatagridViewComboboxColumnCustom2 = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.LignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
        Me.MouvementsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
        Me.PlanTypeTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
        Me.RicaTableAdapter = New AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
        Me.ModeleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.PanProgress = New Ascend.Windows.Forms.GradientPanel
        Me.lbStatus = New System.Windows.Forms.Label
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.cmdSupprimer = New System.Windows.Forms.Button
        Me.cmdEnregistrer = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboModele = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbtBalance = New System.Windows.Forms.RadioButton
        Me.rbtGL = New System.Windows.Forms.RadioButton
        Me.dgvAffectation = New System.Windows.Forms.DataGridView
        Me.dgvChamp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvProposition = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.lblTextDelimiter = New System.Windows.Forms.Label
        Me.cboCodePage = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkUnicode = New System.Windows.Forms.CheckBox
        Me.lklRefresh = New System.Windows.Forms.LinkLabel
        Me.txtDelimiter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvFile = New System.Windows.Forms.DataGridView
        Me.chkHearder = New System.Windows.Forms.CheckBox
        Me.cboDelimiter = New System.Windows.Forms.ComboBox
        Me.lblDelimiter = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.cboTypeFile = New System.Windows.Forms.ComboBox
        CType(Me.ModeleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.PanProgress.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAffectation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(510, 12)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtRestaurer
        '
        Me.BtRestaurer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtRestaurer.Location = New System.Drawing.Point(430, 12)
        Me.BtRestaurer.Name = "BtRestaurer"
        Me.BtRestaurer.Size = New System.Drawing.Size(75, 23)
        Me.BtRestaurer.TabIndex = 0
        Me.BtRestaurer.Text = "Importer"
        '
        'RestDlg
        '
        Me.RestDlg.DefaultExt = "*"
        Me.RestDlg.Filter = "Tous les fichiers (*.*)|*.*"
        '
        'ErrorDlg
        '
        Me.ErrorDlg.DefaultExt = "*"
        Me.ErrorDlg.Filter = "Tous les fichiers (*.*)|*.*"
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'DatagridViewComboboxColumnCustom1
        '
        Me.DatagridViewComboboxColumnCustom1.DataPropertyName = "Affectation"
        Me.DatagridViewComboboxColumnCustom1.DisplayComboBoxOnCurrentCellOnly = False
        Me.DatagridViewComboboxColumnCustom1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DatagridViewComboboxColumnCustom1.DisplayStyleForCurrentCellOnly = True
        Me.DatagridViewComboboxColumnCustom1.DropDownWidth = 200
        Me.DatagridViewComboboxColumnCustom1.HeaderText = "Proposition"
        Me.DatagridViewComboboxColumnCustom1.Name = "DatagridViewComboboxColumnCustom1"
        Me.DatagridViewComboboxColumnCustom1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatagridViewComboboxColumnCustom1.Width = 200
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Champ"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Champ"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'DatagridViewComboboxColumnCustom2
        '
        Me.DatagridViewComboboxColumnCustom2.DataPropertyName = "Affectation"
        Me.DatagridViewComboboxColumnCustom2.DisplayComboBoxOnCurrentCellOnly = False
        Me.DatagridViewComboboxColumnCustom2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DatagridViewComboboxColumnCustom2.DisplayStyleForCurrentCellOnly = True
        Me.DatagridViewComboboxColumnCustom2.DropDownWidth = 200
        Me.DatagridViewComboboxColumnCustom2.HeaderText = "Proposition"
        Me.DatagridViewComboboxColumnCustom2.Name = "DatagridViewComboboxColumnCustom2"
        Me.DatagridViewComboboxColumnCustom2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatagridViewComboboxColumnCustom2.Width = 200
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'RicaTableAdapter
        '
        Me.RicaTableAdapter.ClearBeforeFill = True
        '
        'ModeleBindingSource
        '
        Me.ModeleBindingSource.DataSource = GetType(AgrigestEDI.GestionParametrageImportFichier.ItemParametrageImport)
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.GradientPanel2)
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.cmdSupprimer)
        Me.GradientPanel1.Controls.Add(Me.cmdEnregistrer)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.cboModele)
        Me.GradientPanel1.Controls.Add(Me.GroupBox2)
        Me.GradientPanel1.Controls.Add(Me.dgvAffectation)
        Me.GradientPanel1.Controls.Add(Me.lblTextDelimiter)
        Me.GradientPanel1.Controls.Add(Me.cboCodePage)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.chkUnicode)
        Me.GradientPanel1.Controls.Add(Me.lklRefresh)
        Me.GradientPanel1.Controls.Add(Me.txtDelimiter)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.dgvFile)
        Me.GradientPanel1.Controls.Add(Me.chkHearder)
        Me.GradientPanel1.Controls.Add(Me.cboDelimiter)
        Me.GradientPanel1.Controls.Add(Me.lblDelimiter)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel1.Controls.Add(Me.BtBrowse)
        Me.GradientPanel1.Controls.Add(Me.cboTypeFile)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(597, 635)
        Me.GradientPanel1.TabIndex = 51
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtRestaurer)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 588)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(597, 47)
        Me.GradientPanel2.TabIndex = 75
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.GradientHighColor = System.Drawing.Color.White
        Me.PanProgress.GradientLowColor = System.Drawing.Color.Lavender
        Me.PanProgress.Location = New System.Drawing.Point(394, 99)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Padding = New System.Windows.Forms.Padding(5)
        Me.PanProgress.Size = New System.Drawing.Size(162, 64)
        Me.PanProgress.TabIndex = 74
        Me.PanProgress.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Location = New System.Drawing.Point(8, 33)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(39, 13)
        Me.lbStatus.TabIndex = 5
        Me.lbStatus.Text = "Label2"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(8, 8)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(146, 22)
        Me.pgBar.TabIndex = 4
        '
        'cmdSupprimer
        '
        Me.cmdSupprimer.Enabled = False
        Me.cmdSupprimer.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.cmdSupprimer.Location = New System.Drawing.Point(394, 33)
        Me.cmdSupprimer.Name = "cmdSupprimer"
        Me.cmdSupprimer.Size = New System.Drawing.Size(32, 23)
        Me.cmdSupprimer.TabIndex = 73
        Me.cmdSupprimer.UseVisualStyleBackColor = True
        '
        'cmdEnregistrer
        '
        Me.cmdEnregistrer.Enabled = False
        Me.cmdEnregistrer.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.cmdEnregistrer.Location = New System.Drawing.Point(356, 33)
        Me.cmdEnregistrer.Name = "cmdEnregistrer"
        Me.cmdEnregistrer.Size = New System.Drawing.Size(32, 23)
        Me.cmdEnregistrer.TabIndex = 72
        Me.cmdEnregistrer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Paramétrage de fichier :"
        '
        'cboModele
        '
        Me.cboModele.DataSource = Me.ModeleBindingSource
        Me.cboModele.DisplayMember = "Nom"
        Me.cboModele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModele.FormattingEnabled = True
        Me.cboModele.Location = New System.Drawing.Point(179, 35)
        Me.cboModele.Name = "cboModele"
        Me.cboModele.Size = New System.Drawing.Size(173, 21)
        Me.cboModele.TabIndex = 70
        Me.cboModele.ValueMember = "Nom"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtBalance)
        Me.GroupBox2.Controls.Add(Me.rbtGL)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(15, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 43)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type d'importation"
        '
        'rbtBalance
        '
        Me.rbtBalance.AutoSize = True
        Me.rbtBalance.Checked = True
        Me.rbtBalance.Location = New System.Drawing.Point(6, 20)
        Me.rbtBalance.Name = "rbtBalance"
        Me.rbtBalance.Size = New System.Drawing.Size(64, 17)
        Me.rbtBalance.TabIndex = 1
        Me.rbtBalance.TabStop = True
        Me.rbtBalance.Text = "Balance"
        Me.rbtBalance.UseVisualStyleBackColor = True
        '
        'rbtGL
        '
        Me.rbtGL.AutoSize = True
        Me.rbtGL.Location = New System.Drawing.Point(76, 20)
        Me.rbtGL.Name = "rbtGL"
        Me.rbtGL.Size = New System.Drawing.Size(76, 17)
        Me.rbtGL.TabIndex = 0
        Me.rbtGL.Text = "Grand livre"
        Me.rbtGL.UseVisualStyleBackColor = True
        '
        'dgvAffectation
        '
        Me.dgvAffectation.AllowUserToAddRows = False
        Me.dgvAffectation.AllowUserToDeleteRows = False
        Me.dgvAffectation.AllowUserToResizeColumns = False
        Me.dgvAffectation.AllowUserToResizeRows = False
        Me.dgvAffectation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAffectation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvChamp, Me.dgvProposition})
        Me.dgvAffectation.Location = New System.Drawing.Point(13, 432)
        Me.dgvAffectation.Name = "dgvAffectation"
        Me.dgvAffectation.RowHeadersVisible = False
        Me.dgvAffectation.Size = New System.Drawing.Size(576, 150)
        Me.dgvAffectation.TabIndex = 68
        '
        'dgvChamp
        '
        Me.dgvChamp.DataPropertyName = "Champ"
        Me.dgvChamp.HeaderText = "Champ"
        Me.dgvChamp.Name = "dgvChamp"
        Me.dgvChamp.ReadOnly = True
        Me.dgvChamp.Width = 250
        '
        'dgvProposition
        '
        Me.dgvProposition.DataPropertyName = "Affectation"
        Me.dgvProposition.DisplayComboBoxOnCurrentCellOnly = False
        Me.dgvProposition.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.dgvProposition.DisplayStyleForCurrentCellOnly = True
        Me.dgvProposition.DropDownWidth = 200
        Me.dgvProposition.HeaderText = "Proposition"
        Me.dgvProposition.Name = "dgvProposition"
        Me.dgvProposition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProposition.Width = 200
        '
        'lblTextDelimiter
        '
        Me.lblTextDelimiter.AutoSize = True
        Me.lblTextDelimiter.Location = New System.Drawing.Point(51, 185)
        Me.lblTextDelimiter.Name = "lblTextDelimiter"
        Me.lblTextDelimiter.Size = New System.Drawing.Size(442, 13)
        Me.lblTextDelimiter.TabIndex = 67
        Me.lblTextDelimiter.Text = "Séparation des colones (indiqué la largeur de chaque colonne séparée par un point" & _
            "-virgule) :"
        Me.lblTextDelimiter.Visible = False
        '
        'cboCodePage
        '
        Me.cboCodePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCodePage.FormattingEnabled = True
        Me.cboCodePage.Location = New System.Drawing.Point(52, 115)
        Me.cboCodePage.Name = "cboCodePage"
        Me.cboCodePage.Size = New System.Drawing.Size(164, 21)
        Me.cboCodePage.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(49, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Codage du fichier :"
        '
        'chkUnicode
        '
        Me.chkUnicode.AutoSize = True
        Me.chkUnicode.Location = New System.Drawing.Point(222, 117)
        Me.chkUnicode.Name = "chkUnicode"
        Me.chkUnicode.Size = New System.Drawing.Size(66, 17)
        Me.chkUnicode.TabIndex = 54
        Me.chkUnicode.Text = "Unicode"
        Me.chkUnicode.UseVisualStyleBackColor = True
        '
        'lklRefresh
        '
        Me.lklRefresh.AutoSize = True
        Me.lklRefresh.Location = New System.Drawing.Point(536, 235)
        Me.lklRefresh.Name = "lklRefresh"
        Me.lklRefresh.Size = New System.Drawing.Size(53, 13)
        Me.lklRefresh.TabIndex = 59
        Me.lklRefresh.TabStop = True
        Me.lklRefresh.Text = "Actualiser"
        '
        'txtDelimiter
        '
        Me.txtDelimiter.Location = New System.Drawing.Point(52, 201)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(186, 20)
        Me.txtDelimiter.TabIndex = 57
        Me.txtDelimiter.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Affection des colonnes :"
        '
        'dgvFile
        '
        Me.dgvFile.AllowUserToAddRows = False
        Me.dgvFile.AllowUserToDeleteRows = False
        Me.dgvFile.AllowUserToResizeColumns = False
        Me.dgvFile.AllowUserToResizeRows = False
        Me.dgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFile.Location = New System.Drawing.Point(13, 251)
        Me.dgvFile.Name = "dgvFile"
        Me.dgvFile.ReadOnly = True
        Me.dgvFile.RowHeadersVisible = False
        Me.dgvFile.Size = New System.Drawing.Size(576, 150)
        Me.dgvFile.TabIndex = 60
        '
        'chkHearder
        '
        Me.chkHearder.AutoSize = True
        Me.chkHearder.Location = New System.Drawing.Point(51, 228)
        Me.chkHearder.Name = "chkHearder"
        Me.chkHearder.Size = New System.Drawing.Size(254, 17)
        Me.chkHearder.TabIndex = 58
        Me.chkHearder.Text = "La première ligne correspond à l'entête du fichier"
        Me.chkHearder.UseVisualStyleBackColor = True
        '
        'cboDelimiter
        '
        Me.cboDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDelimiter.FormattingEnabled = True
        Me.cboDelimiter.Location = New System.Drawing.Point(52, 201)
        Me.cboDelimiter.Name = "cboDelimiter"
        Me.cboDelimiter.Size = New System.Drawing.Size(186, 21)
        Me.cboDelimiter.TabIndex = 56
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.Location = New System.Drawing.Point(49, 185)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(59, 13)
        Me.lblDelimiter.TabIndex = 64
        Me.lblDelimiter.Text = "Délimiteur :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Type de délimitation du fichier :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Fichier :"
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Location = New System.Drawing.Point(52, 67)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(300, 20)
        Me.TxNomFichier.TabIndex = 51
        '
        'BtBrowse
        '
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(355, 64)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 52
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'cboTypeFile
        '
        Me.cboTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeFile.FormattingEnabled = True
        Me.cboTypeFile.Location = New System.Drawing.Point(51, 155)
        Me.cboTypeFile.Name = "cboTypeFile"
        Me.cboTypeFile.Size = New System.Drawing.Size(165, 21)
        Me.cboTypeFile.TabIndex = 55
        '
        'FrManagerFichier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 635)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrManagerFichier"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importation de fichier"
        CType(Me.ModeleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvAffectation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtRestaurer As System.Windows.Forms.Button
    Friend WithEvents RestDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatagridViewComboboxColumnCustom1 As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
    Friend WithEvents DatagridViewComboboxColumnCustom2 As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
    Friend WithEvents RicaTableAdapter As AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
    Friend WithEvents ModeleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents cmdSupprimer As System.Windows.Forms.Button
    Friend WithEvents cmdEnregistrer As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboModele As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtBalance As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGL As System.Windows.Forms.RadioButton
    Friend WithEvents dgvAffectation As System.Windows.Forms.DataGridView
    Friend WithEvents dgvChamp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvProposition As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents lblTextDelimiter As System.Windows.Forms.Label
    Friend WithEvents cboCodePage As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkUnicode As System.Windows.Forms.CheckBox
    Friend WithEvents lklRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents txtDelimiter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvFile As System.Windows.Forms.DataGridView
    Friend WithEvents chkHearder As System.Windows.Forms.CheckBox
    Friend WithEvents cboDelimiter As System.Windows.Forms.ComboBox
    Friend WithEvents lblDelimiter As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents cboTypeFile As System.Windows.Forms.ComboBox
    Friend WithEvents PanProgress As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel

End Class
