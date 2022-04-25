<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCloture
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.gpbDate = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDebut = New System.Windows.Forms.DateTimePicker
        Me.dtpFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ClotureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New AgrigestEDI.dbSauvRest
        Me.gpbCloture = New System.Windows.Forms.GroupBox
        Me.rbtProvisoire = New System.Windows.Forms.RadioButton
        Me.rbtDefinitive = New System.Windows.Forms.RadioButton
        Me.cboCompte = New System.Windows.Forms.ComboBox
        Me.CompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.DossiersExistTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
        Me.PlanComptableExistTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.DbSauvRest = New AgrigestEDI.dbSauvRest
        Me.ActivitesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
        Me.DossiersTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
        Me.EmpruntLignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.EmpruntLignesTableAdapter
        Me.ExploitationsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
        Me.ImmobilisationsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ImmobilisationsTableAdapter
        Me.InventaireGroupesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.InventaireGroupesTableAdapter
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.InventaireLignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.InventaireLignesTableAdapter
        Me.PanProgress = New System.Windows.Forms.Panel
        Me.lbStatus = New System.Windows.Forms.TextBox
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.EmpruntGroupesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.EmpruntGroupesTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.gpbOptionsDef = New System.Windows.Forms.GroupBox
        Me.txCptNonLettres = New System.Windows.Forms.TextBox
        Me.lbCptNonLettres = New System.Windows.Forms.Label
        Me.chkReportNonLettre = New System.Windows.Forms.CheckBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.MouvementsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
        Me.ActivitesTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
        Me.PlanComptableTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.MouvementsTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
        Me.LignesTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
        Me.PiecesTableAdapterReport = New AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
        Me.gpbDate.SuspendLayout()
        CType(Me.ClotureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCloture.SuspendLayout()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanProgress.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.gpbOptionsDef.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(145, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(218, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'gpbDate
        '
        Me.gpbDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbDate.Controls.Add(Me.Label2)
        Me.gpbDate.Controls.Add(Me.dtpDebut)
        Me.gpbDate.Controls.Add(Me.dtpFin)
        Me.gpbDate.Controls.Add(Me.Label1)
        Me.gpbDate.Location = New System.Drawing.Point(12, 85)
        Me.gpbDate.Name = "gpbDate"
        Me.gpbDate.Size = New System.Drawing.Size(273, 83)
        Me.gpbDate.TabIndex = 1
        Me.gpbDate.TabStop = False
        Me.gpbDate.Text = "Dates du nouvel exercice"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Début prochain ex."
        '
        'dtpDebut
        '
        Me.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDebut.Location = New System.Drawing.Point(114, 19)
        Me.dtpDebut.Name = "dtpDebut"
        Me.dtpDebut.Size = New System.Drawing.Size(90, 20)
        Me.dtpDebut.TabIndex = 2
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(114, 47)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(90, 20)
        Me.dtpFin.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fin prochain ex."
        '
        'ClotureBindingSource
        '
        Me.ClotureBindingSource.DataMember = "Dossiers"
        Me.ClotureBindingSource.DataSource = Me.ds
        '
        'ds
        '
        Me.ds.DataSetName = "dbSauvRest"
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpbCloture
        '
        Me.gpbCloture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbCloture.Controls.Add(Me.rbtProvisoire)
        Me.gpbCloture.Controls.Add(Me.rbtDefinitive)
        Me.gpbCloture.Location = New System.Drawing.Point(12, 8)
        Me.gpbCloture.Name = "gpbCloture"
        Me.gpbCloture.Size = New System.Drawing.Size(273, 71)
        Me.gpbCloture.TabIndex = 2
        Me.gpbCloture.TabStop = False
        Me.gpbCloture.Text = "Type de clôture"
        '
        'rbtProvisoire
        '
        Me.rbtProvisoire.AutoSize = True
        Me.rbtProvisoire.Location = New System.Drawing.Point(9, 19)
        Me.rbtProvisoire.Name = "rbtProvisoire"
        Me.rbtProvisoire.Size = New System.Drawing.Size(71, 17)
        Me.rbtProvisoire.TabIndex = 4
        Me.rbtProvisoire.Text = "Provisoire"
        Me.rbtProvisoire.UseVisualStyleBackColor = True
        '
        'rbtDefinitive
        '
        Me.rbtDefinitive.AutoSize = True
        Me.rbtDefinitive.Location = New System.Drawing.Point(9, 42)
        Me.rbtDefinitive.Name = "rbtDefinitive"
        Me.rbtDefinitive.Size = New System.Drawing.Size(69, 17)
        Me.rbtDefinitive.TabIndex = 3
        Me.rbtDefinitive.Text = "Définitive"
        Me.rbtDefinitive.UseVisualStyleBackColor = True
        '
        'cboCompte
        '
        Me.cboCompte.DataSource = Me.CompteBindingSource
        Me.cboCompte.DisplayMember = "PlCpt"
        Me.cboCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompte.FormattingEnabled = True
        Me.cboCompte.Location = New System.Drawing.Point(114, 19)
        Me.cboCompte.Name = "cboCompte"
        Me.cboCompte.Size = New System.Drawing.Size(121, 21)
        Me.cboCompte.TabIndex = 9
        Me.cboCompte.ValueMember = "PlCpt"
        '
        'CompteBindingSource
        '
        Me.CompteBindingSource.DataMember = "PlanComptable"
        Me.CompteBindingSource.DataSource = Me.ds
        Me.CompteBindingSource.Filter = "PlCpt like'1%'"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "N° Compte résultat"
        '
        'DossiersExistTableAdapter
        '
        Me.DossiersExistTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableExistTableAdapter
        '
        Me.PlanComptableExistTableAdapter.ClearBeforeFill = True
        '
        'DbSauvRest
        '
        Me.DbSauvRest.DataSetName = "dbSauvRest"
        Me.DbSauvRest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'EmpruntLignesTableAdapter
        '
        Me.EmpruntLignesTableAdapter.ClearBeforeFill = True
        '
        'ExploitationsTableAdapter
        '
        Me.ExploitationsTableAdapter.ClearBeforeFill = True
        '
        'ImmobilisationsTableAdapter
        '
        Me.ImmobilisationsTableAdapter.ClearBeforeFill = True
        '
        'InventaireGroupesTableAdapter
        '
        Me.InventaireGroupesTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'InventaireLignesTableAdapter
        '
        Me.InventaireLignesTableAdapter.ClearBeforeFill = True
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.Location = New System.Drawing.Point(142, 0)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Size = New System.Drawing.Size(128, 56)
        Me.PanProgress.TabIndex = 17
        Me.PanProgress.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.BackColor = System.Drawing.Color.White
        Me.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbStatus.Enabled = False
        Me.lbStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbStatus.Location = New System.Drawing.Point(5, 40)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(104, 13)
        Me.lbStatus.TabIndex = 6
        Me.lbStatus.Text = "lbStatus"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(25, 12)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(112, 22)
        Me.pgBar.TabIndex = 4
        '
        'EmpruntGroupesTableAdapter
        '
        Me.EmpruntGroupesTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.gpbOptionsDef)
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.gpbCloture)
        Me.GradientPanel1.Controls.Add(Me.gpbDate)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(297, 299)
        Me.GradientPanel1.TabIndex = 18
        '
        'gpbOptionsDef
        '
        Me.gpbOptionsDef.Controls.Add(Me.txCptNonLettres)
        Me.gpbOptionsDef.Controls.Add(Me.lbCptNonLettres)
        Me.gpbOptionsDef.Controls.Add(Me.chkReportNonLettre)
        Me.gpbOptionsDef.Controls.Add(Me.cboCompte)
        Me.gpbOptionsDef.Controls.Add(Me.Label5)
        Me.gpbOptionsDef.Location = New System.Drawing.Point(12, 174)
        Me.gpbOptionsDef.Name = "gpbOptionsDef"
        Me.gpbOptionsDef.Size = New System.Drawing.Size(273, 114)
        Me.gpbOptionsDef.TabIndex = 18
        Me.gpbOptionsDef.TabStop = False
        Me.gpbOptionsDef.Text = "Options de clôture pour les comptes"
        '
        'txCptNonLettres
        '
        Me.txCptNonLettres.Location = New System.Drawing.Point(104, 69)
        Me.txCptNonLettres.Name = "txCptNonLettres"
        Me.txCptNonLettres.Size = New System.Drawing.Size(131, 20)
        Me.txCptNonLettres.TabIndex = 13
        '
        'lbCptNonLettres
        '
        Me.lbCptNonLettres.AutoSize = True
        Me.lbCptNonLettres.Location = New System.Drawing.Point(6, 72)
        Me.lbCptNonLettres.Name = "lbCptNonLettres"
        Me.lbCptNonLettres.Size = New System.Drawing.Size(93, 13)
        Me.lbCptNonLettres.TabIndex = 12
        Me.lbCptNonLettres.Text = "pour les comptes :"
        '
        'chkReportNonLettre
        '
        Me.chkReportNonLettre.AutoSize = True
        Me.chkReportNonLettre.Checked = True
        Me.chkReportNonLettre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReportNonLettre.Location = New System.Drawing.Point(9, 46)
        Me.chkReportNonLettre.Name = "chkReportNonLettre"
        Me.chkReportNonLettre.Size = New System.Drawing.Size(110, 17)
        Me.chkReportNonLettre.TabIndex = 11
        Me.chkReportNonLettre.Text = "Reports détaillés :"
        Me.chkReportNonLettre.UseVisualStyleBackColor = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 299)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(297, 45)
        Me.GradientPanel2.TabIndex = 19
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapterReport
        '
        Me.ActivitesTableAdapterReport.ClearBeforeFill = True
        '
        'ComptesTableAdapterReport
        '
        Me.ComptesTableAdapterReport.ClearBeforeFill = True
        '
        'PlanComptableTableAdapterReport
        '
        Me.PlanComptableTableAdapterReport.ClearBeforeFill = True
        '
        'MouvementsTableAdapterReport
        '
        Me.MouvementsTableAdapterReport.ClearBeforeFill = True
        '
        'LignesTableAdapterReport
        '
        Me.LignesTableAdapterReport.ClearBeforeFill = True
        '
        'PiecesTableAdapterReport
        '
        Me.PiecesTableAdapterReport.ClearBeforeFill = True
        '
        'FrCloture
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(297, 344)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrCloture"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Clôture d'exercice"
        Me.gpbDate.ResumeLayout(False)
        Me.gpbDate.PerformLayout()
        CType(Me.ClotureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCloture.ResumeLayout(False)
        Me.gpbCloture.PerformLayout()
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.GradientPanel1.ResumeLayout(False)
        Me.gpbOptionsDef.ResumeLayout(False)
        Me.gpbOptionsDef.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents gpbDate As System.Windows.Forms.GroupBox
    Friend WithEvents gpbCloture As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDefinitive As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProvisoire As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ds As AgrigestEDI.dbSauvRest
    Friend WithEvents ClotureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DossiersExistTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
    Friend WithEvents cboCompte As System.Windows.Forms.ComboBox
    Friend WithEvents CompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanComptableExistTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents DbSauvRest As AgrigestEDI.dbSauvRest
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
    Friend WithEvents EmpruntLignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.EmpruntLignesTableAdapter
    Friend WithEvents ExploitationsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
    Friend WithEvents ImmobilisationsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ImmobilisationsTableAdapter
    Friend WithEvents InventaireGroupesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.InventaireGroupesTableAdapter
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents InventaireLignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.InventaireLignesTableAdapter
    Friend WithEvents PanProgress As System.Windows.Forms.Panel
    Friend WithEvents lbStatus As System.Windows.Forms.TextBox
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents EmpruntGroupesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.EmpruntGroupesTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
    Friend WithEvents ActivitesTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
    Friend WithEvents PlanComptableTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents MouvementsTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
    Friend WithEvents LignesTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
    Friend WithEvents PiecesTableAdapterReport As AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
    Friend WithEvents chkReportNonLettre As System.Windows.Forms.CheckBox
    Friend WithEvents gpbOptionsDef As System.Windows.Forms.GroupBox
    Friend WithEvents txCptNonLettres As System.Windows.Forms.TextBox
    Friend WithEvents lbCptNonLettres As System.Windows.Forms.Label

End Class
