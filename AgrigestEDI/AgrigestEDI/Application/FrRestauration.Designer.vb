<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRestauration
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
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.BtRestaurer = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.DbSauvRest = New AgrigestEDI.dbSauvRest
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.RestDlg = New System.Windows.Forms.OpenFileDialog
        Me.ErrorDlg = New System.Windows.Forms.SaveFileDialog
        Me.DossiersWorkTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
        Me.PanProgress = New Ascend.Windows.Forms.GradientPanel
        Me.lbStatus = New System.Windows.Forms.Label
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel3 = New Ascend.Windows.Forms.GradientPanel
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanProgress.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxNomFichier.Location = New System.Drawing.Point(52, 38)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(273, 20)
        Me.TxNomFichier.TabIndex = 20
        '
        'BtBrowse
        '
        Me.BtBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(331, 35)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.BtBrowse, "Changer le dossier d'exportation...")
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'BtRestaurer
        '
        Me.BtRestaurer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtRestaurer.Location = New System.Drawing.Point(202, 11)
        Me.BtRestaurer.Name = "BtRestaurer"
        Me.BtRestaurer.Size = New System.Drawing.Size(75, 23)
        Me.BtRestaurer.TabIndex = 0
        Me.BtRestaurer.Text = "Restaurer"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Emplacement de la sauvegarde à restaurer:"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(283, 11)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 3
        Me.BtAnnuler.Text = "Annuler"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Fichier :"
        '
        'RestDlg
        '
        Me.RestDlg.DefaultExt = "zip"
        Me.RestDlg.Filter = "ichiers ZIP (*.zip)|*.zip|Fichiers XML (*.xml)|*.xml|Tous les fichiers|*.*"
        '
        'ErrorDlg
        '
        Me.ErrorDlg.DefaultExt = "xml"
        Me.ErrorDlg.Filter = "Fichiers texte (*.txt)|*.txt"
        '
        'DossiersWorkTableAdapter
        '
        Me.DossiersWorkTableAdapter.ClearBeforeFill = True
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.GradientHighColor = System.Drawing.Color.White
        Me.PanProgress.GradientLowColor = System.Drawing.Color.Lavender
        Me.PanProgress.Location = New System.Drawing.Point(126, 12)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Padding = New System.Windows.Forms.Padding(5)
        Me.PanProgress.Size = New System.Drawing.Size(162, 64)
        Me.PanProgress.TabIndex = 31
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
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.PanProgress)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.BtBrowse)
        Me.GradientPanel2.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel2.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel2.Size = New System.Drawing.Size(370, 80)
        Me.GradientPanel2.TabIndex = 29
        '
        'GradientPanel3
        '
        Me.GradientPanel3.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel3.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel3.Controls.Add(Me.BtRestaurer)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel3.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel3.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 80)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel3.Size = New System.Drawing.Size(370, 45)
        Me.GradientPanel3.TabIndex = 30
        '
        'FrRestauration
        '
        Me.AcceptButton = Me.BtRestaurer
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(370, 125)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrRestauration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Restauration"
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.GradientPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtRestaurer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents DbSauvRest As AgrigestEDI.dbSauvRest
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RestDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DossiersWorkTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
    Friend WithEvents PanProgress As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel3 As Ascend.Windows.Forms.GradientPanel
End Class
