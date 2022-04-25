<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrImportationIsagri
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
        Me.BtRestaurer = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.DbSauvRest = New AgrigestEDI.dbSauvRest
        Me.ActivitesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
        Me.ExploitationsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
        Me.LignesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
        Me.MouvementsTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
        Me.PiecesTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
        Me.DossiersTableAdapter = New AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
        Me.RestDlg = New System.Windows.Forms.OpenFileDialog
        Me.ErrorDlg = New System.Windows.Forms.SaveFileDialog
        Me.PlanTypeTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
        Me.RicaTableAdapter = New AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFormatFichier = New System.Windows.Forms.ComboBox
        Me.PanProgress = New Ascend.Windows.Forms.GradientPanel
        Me.lbStatus = New System.Windows.Forms.Label
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.PanProgress.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtRestaurer
        '
        Me.BtRestaurer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtRestaurer.Location = New System.Drawing.Point(222, 7)
        Me.BtRestaurer.Name = "BtRestaurer"
        Me.BtRestaurer.Size = New System.Drawing.Size(75, 23)
        Me.BtRestaurer.TabIndex = 0
        Me.BtRestaurer.Text = "Importer"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(302, 7)
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
        'ExploitationsTableAdapter
        '
        Me.ExploitationsTableAdapter.ClearBeforeFill = True
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
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
        'RestDlg
        '
        Me.RestDlg.DefaultExt = "ecr"
        Me.RestDlg.Filter = "Fichiers ECR ou ISA (*.ecr;*.isa)|*.ecr;*.isa"
        '
        'ErrorDlg
        '
        Me.ErrorDlg.DefaultExt = "*"
        Me.ErrorDlg.Filter = "Tous les fichiers (*.*)|*.*"
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'RicaTableAdapter
        '
        Me.RicaTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.cboFormatFichier)
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel1.Controls.Add(Me.BtBrowse)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(389, 96)
        Me.GradientPanel1.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Format du fichier :"
        '
        'cboFormatFichier
        '
        Me.cboFormatFichier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormatFichier.FormattingEnabled = True
        Me.cboFormatFichier.Location = New System.Drawing.Point(102, 58)
        Me.cboFormatFichier.Name = "cboFormatFichier"
        Me.cboFormatFichier.Size = New System.Drawing.Size(150, 21)
        Me.cboFormatFichier.TabIndex = 33
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.GradientHighColor = System.Drawing.Color.White
        Me.PanProgress.GradientLowColor = System.Drawing.Color.Lavender
        Me.PanProgress.Location = New System.Drawing.Point(138, 32)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Padding = New System.Windows.Forms.Padding(5)
        Me.PanProgress.Size = New System.Drawing.Size(162, 64)
        Me.PanProgress.TabIndex = 32
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Fichier :"
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Location = New System.Drawing.Point(49, 32)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(300, 20)
        Me.TxNomFichier.TabIndex = 25
        '
        'BtBrowse
        '
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(352, 29)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 22
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Emplacement du fichier à importer :"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtRestaurer)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 96)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(389, 42)
        Me.GradientPanel2.TabIndex = 33
        '
        'FrImportationIsagri
        '
        Me.AcceptButton = Me.BtRestaurer
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(389, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrImportationIsagri"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importer"
        CType(Me.DbSauvRest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtRestaurer As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents DbSauvRest As AgrigestEDI.dbSauvRest
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ComptesTableAdapter
    Friend WithEvents ExploitationsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.ExploitationsTableAdapter
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.LignesTableAdapter
    Friend WithEvents MouvementsTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.MouvementsTableAdapter
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PiecesTableAdapter
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.PlanComptableTableAdapter
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.dbSauvRestTableAdapters.DossiersTableAdapter
    Friend WithEvents RestDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
    Friend WithEvents RicaTableAdapter As AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanProgress As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFormatFichier As System.Windows.Forms.ComboBox
End Class
