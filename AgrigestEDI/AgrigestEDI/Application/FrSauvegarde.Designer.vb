<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSauvegarde
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.BtSauvegarder = New System.Windows.Forms.Button
        Me.TxCheminSav = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.saveDlg = New System.Windows.Forms.SaveFileDialog
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.DbSauvRest = New AgrigestEDI.dbSauvRest
        Me.cboDossier = New System.Windows.Forms.ComboBox
        Me.DossierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbDonneesDataSet = New AgrigestEDI.dbDonneesDataSet
        Me.lblDossier = New System.Windows.Forms.Label
        Me.ActivitesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
        Me.EmpruntGroupesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.EmpruntGroupesTableAdapter
        Me.EmpruntLignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.EmpruntLignesTableAdapter
        Me.ExploitationsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
        Me.ImmobilisationsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ImmobilisationsTableAdapter
        Me.InventaireGroupesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.InventaireGroupesTableAdapter
        Me.InventaireLignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.InventaireLignesTableAdapter
        Me.LignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
        Me.ModLignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ModLignesTableAdapter
        Me.ModMouvementsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ModMouvementsTableAdapter
        Me.MouvementsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
        Me.PiecesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.DossiersTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
        Me.DossiersShowTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.ChkZip = New System.Windows.Forms.CheckBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.PanProgress = New Ascend.Windows.Forms.GradientPanel
        Me.lbStatus = New System.Windows.Forms.Label
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DossierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.PanProgress.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Fichier :"
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxNomFichier.Location = New System.Drawing.Point(73, 87)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(280, 20)
        Me.TxNomFichier.TabIndex = 20
        Me.TxNomFichier.Text = "PEAVM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Répertoire :"
        '
        'BtBrowse
        '
        Me.BtBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(356, 61)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.BtBrowse, "Changer le dossier d'exportation...")
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'BtSauvegarder
        '
        Me.BtSauvegarder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSauvegarder.Location = New System.Drawing.Point(218, 11)
        Me.BtSauvegarder.Name = "BtSauvegarder"
        Me.BtSauvegarder.Size = New System.Drawing.Size(80, 23)
        Me.BtSauvegarder.TabIndex = 0
        Me.BtSauvegarder.Text = "Sauvegarder"
        '
        'TxCheminSav
        '
        Me.TxCheminSav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxCheminSav.Location = New System.Drawing.Point(73, 63)
        Me.TxCheminSav.Name = "TxCheminSav"
        Me.TxCheminSav.Size = New System.Drawing.Size(280, 20)
        Me.TxCheminSav.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Emplacement du fichier de sauvegarde :"
        '
        'saveDlg
        '
        Me.saveDlg.DefaultExt = "zip"
        Me.saveDlg.Filter = "Fichiers ZIP (*.zip)|*.zip"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(304, 11)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 3
        Me.BtAnnuler.Text = "Annuler"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(8, 8)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(57, 22)
        Me.pgBar.TabIndex = 4
        '
        'DbSauvRest
        '
        Me.DbSauvRest.DataSetName = "dbSauvRest"
        Me.DbSauvRest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDossier
        '
        Me.cboDossier.DataSource = Me.DossierBindingSource
        Me.cboDossier.DisplayMember = "DDisplay"
        Me.cboDossier.FormattingEnabled = True
        Me.cboDossier.Location = New System.Drawing.Point(72, 8)
        Me.cboDossier.Name = "cboDossier"
        Me.cboDossier.Size = New System.Drawing.Size(280, 21)
        Me.cboDossier.TabIndex = 24
        Me.cboDossier.ValueMember = "DDossier"
        '
        'DossierBindingSource
        '
        Me.DossierBindingSource.DataMember = "Dossiers"
        Me.DossierBindingSource.DataSource = Me.DbDonneesDataSet
        '
        'DbDonneesDataSet
        '
        Me.DbDonneesDataSet.DataSetName = "dbDonneesDataSet"
        Me.DbDonneesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblDossier
        '
        Me.lblDossier.AutoSize = True
        Me.lblDossier.Location = New System.Drawing.Point(9, 11)
        Me.lblDossier.Name = "lblDossier"
        Me.lblDossier.Size = New System.Drawing.Size(54, 13)
        Me.lblDossier.TabIndex = 25
        Me.lblDossier.Text = "Exercice :"
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'EmpruntGroupesTableAdapter
        '
        Me.EmpruntGroupesTableAdapter.ClearBeforeFill = True
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
        'InventaireLignesTableAdapter
        '
        Me.InventaireLignesTableAdapter.ClearBeforeFill = True
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
        '
        'ModLignesTableAdapter
        '
        Me.ModLignesTableAdapter.ClearBeforeFill = True
        '
        'ModMouvementsTableAdapter
        '
        Me.ModMouvementsTableAdapter.ClearBeforeFill = True
        '
        'MouvementsTableAdapter
        '
        Me.MouvementsTableAdapter.ClearBeforeFill = True
        '
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'DossiersShowTableAdapter
        '
        Me.DossiersShowTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.ChkZip)
        Me.GradientPanel1.Controls.Add(Me.lblDossier)
        Me.GradientPanel1.Controls.Add(Me.cboDossier)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.TxCheminSav)
        Me.GradientPanel1.Controls.Add(Me.BtBrowse)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(391, 138)
        Me.GradientPanel1.TabIndex = 26
        '
        'ChkZip
        '
        Me.ChkZip.AutoSize = True
        Me.ChkZip.Checked = True
        Me.ChkZip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkZip.Location = New System.Drawing.Point(73, 113)
        Me.ChkZip.Name = "ChkZip"
        Me.ChkZip.Size = New System.Drawing.Size(141, 17)
        Me.ChkZip.TabIndex = 26
        Me.ChkZip.Text = "Compresser les données"
        Me.ChkZip.UseVisualStyleBackColor = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtSauvegarder)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 138)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(391, 45)
        Me.GradientPanel2.TabIndex = 27
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.GradientHighColor = System.Drawing.Color.White
        Me.PanProgress.GradientLowColor = System.Drawing.Color.Lavender
        Me.PanProgress.Location = New System.Drawing.Point(277, 77)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Padding = New System.Windows.Forms.Padding(5)
        Me.PanProgress.Size = New System.Drawing.Size(73, 53)
        Me.PanProgress.TabIndex = 28
        Me.PanProgress.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Location = New System.Drawing.Point(8, 33)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(45, 13)
        Me.lbStatus.TabIndex = 5
        Me.lbStatus.Text = "lbStatus"
        '
        'FrSauvegarde
        '
        Me.AcceptButton = Me.BtSauvegarder
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(391, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrSauvegarde"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sauvegarde"
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DossierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtSauvegarder As System.Windows.Forms.Button
    Friend WithEvents TxCheminSav As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents saveDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents DbSauvRest As AgrigestEDI.dbSauvRest
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cboDossier As System.Windows.Forms.ComboBox
    Friend WithEvents DossierBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblDossier As System.Windows.Forms.Label
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
    Friend WithEvents EmpruntGroupesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.EmpruntGroupesTableAdapter
    Friend WithEvents EmpruntLignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.EmpruntLignesTableAdapter
    Friend WithEvents ExploitationsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
    Friend WithEvents ImmobilisationsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ImmobilisationsTableAdapter
    Friend WithEvents InventaireGroupesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.InventaireGroupesTableAdapter
    Friend WithEvents InventaireLignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.InventaireLignesTableAdapter
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
    Friend WithEvents ModLignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ModLignesTableAdapter
    Friend WithEvents ModMouvementsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ModMouvementsTableAdapter
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
    Friend WithEvents DbDonneesDataSet As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents DossiersShowTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents PanProgress As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ChkZip As System.Windows.Forms.CheckBox
    Friend WithEvents lbStatus As System.Windows.Forms.Label
End Class
