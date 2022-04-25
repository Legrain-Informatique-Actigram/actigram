Partial Public Class FrExportationIsagri
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
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
    Friend WithEvents BtExporter As System.Windows.Forms.Button
    Friend WithEvents TxCheminExport As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents saveDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PanProgress As System.Windows.Forms.Panel
    Friend WithEvents lbStatus As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ChkArchiver As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRaccourci As System.Windows.Forms.CheckBox
    Friend WithEvents BtAnnulerExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Label4 As System.Windows.Forms.Label
        Me.BtExporter = New System.Windows.Forms.Button
        Me.TxCheminExport = New System.Windows.Forms.TextBox
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.saveDlg = New System.Windows.Forms.SaveFileDialog
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.PanProgress = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.lbStatus = New System.Windows.Forms.TextBox
        Me.BtAnnulerExport = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.ChkArchiver = New System.Windows.Forms.CheckBox
        Me.ChkRaccourci = New System.Windows.Forms.CheckBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.chkFullCompta = New System.Windows.Forms.CheckBox
        Me.GradientPanel3 = New Ascend.Windows.Forms.GradientPanel
        Me.TxCodeExpl = New System.Windows.Forms.TextBox
        Label4 = New System.Windows.Forms.Label
        Me.PanProgress.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtExporter
        '
        Me.BtExporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtExporter.Location = New System.Drawing.Point(234, 7)
        Me.BtExporter.Name = "BtExporter"
        Me.BtExporter.Size = New System.Drawing.Size(75, 23)
        Me.BtExporter.TabIndex = 1
        Me.BtExporter.Text = "Exporter"
        '
        'TxCheminExport
        '
        Me.TxCheminExport.Location = New System.Drawing.Point(80, 33)
        Me.TxCheminExport.Name = "TxCheminExport"
        Me.TxCheminExport.Size = New System.Drawing.Size(276, 20)
        Me.TxCheminExport.TabIndex = 2
        '
        'BtBrowse
        '
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(359, 31)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.BtBrowse, "Changer le dossier d'exportation...")
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(314, 7)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 2
        Me.BtAnnuler.Text = "Annuler"
        '
        'saveDlg
        '
        Me.saveDlg.DefaultExt = "ecr"
        Me.saveDlg.Filter = "Fichiers ECR (*.ECR)|*.ECR"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(12, 10)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(89, 22)
        Me.pgBar.TabIndex = 0
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.GradientPanel2)
        Me.PanProgress.Location = New System.Drawing.Point(258, 156)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Size = New System.Drawing.Size(128, 56)
        Me.PanProgress.TabIndex = 6
        Me.PanProgress.Visible = False
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.pgBar)
        Me.GradientPanel2.Controls.Add(Me.lbStatus)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(128, 56)
        Me.GradientPanel2.TabIndex = 0
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.BackColor = System.Drawing.Color.White
        Me.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbStatus.Enabled = False
        Me.lbStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbStatus.Location = New System.Drawing.Point(12, 38)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(81, 13)
        Me.lbStatus.TabIndex = 1
        Me.lbStatus.Text = "lbStatus"
        '
        'BtAnnulerExport
        '
        Me.BtAnnulerExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtAnnulerExport.Location = New System.Drawing.Point(12, 7)
        Me.BtAnnulerExport.Name = "BtAnnulerExport"
        Me.BtAnnulerExport.Size = New System.Drawing.Size(112, 23)
        Me.BtAnnulerExport.TabIndex = 0
        Me.BtAnnulerExport.Text = "Annuler un export..."
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Emplacement du fichier d'export:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Répertoire :"
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Location = New System.Drawing.Point(80, 59)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(276, 20)
        Me.TxNomFichier.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fichier :"
        '
        'ChkArchiver
        '
        Me.ChkArchiver.Checked = True
        Me.ChkArchiver.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkArchiver.Location = New System.Drawing.Point(80, 111)
        Me.ChkArchiver.Name = "ChkArchiver"
        Me.ChkArchiver.Size = New System.Drawing.Size(280, 24)
        Me.ChkArchiver.TabIndex = 8
        Me.ChkArchiver.Text = "Archiver automatiquement les exports existants"
        '
        'ChkRaccourci
        '
        Me.ChkRaccourci.Checked = True
        Me.ChkRaccourci.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRaccourci.Location = New System.Drawing.Point(80, 135)
        Me.ChkRaccourci.Name = "ChkRaccourci"
        Me.ChkRaccourci.Size = New System.Drawing.Size(256, 24)
        Me.ChkRaccourci.TabIndex = 9
        Me.ChkRaccourci.Text = "Créer un raccourci sur le bureau"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.TxCodeExpl)
        Me.GradientPanel1.Controls.Add(Label4)
        Me.GradientPanel1.Controls.Add(Me.chkFullCompta)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.TxCheminExport)
        Me.GradientPanel1.Controls.Add(Me.ChkRaccourci)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.ChkArchiver)
        Me.GradientPanel1.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel1.Controls.Add(Me.BtBrowse)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(401, 193)
        Me.GradientPanel1.TabIndex = 0
        '
        'chkFullCompta
        '
        Me.chkFullCompta.Checked = True
        Me.chkFullCompta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFullCompta.Location = New System.Drawing.Point(80, 161)
        Me.chkFullCompta.Name = "chkFullCompta"
        Me.chkFullCompta.Size = New System.Drawing.Size(256, 24)
        Me.chkFullCompta.TabIndex = 10
        Me.chkFullCompta.Text = "Exporter toute la comptabilité"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel3.Controls.Add(Me.BtAnnulerExport)
        Me.GradientPanel3.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel3.Controls.Add(Me.BtExporter)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel3.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel3.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 193)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel3.Size = New System.Drawing.Size(401, 42)
        Me.GradientPanel3.TabIndex = 1
        '
        'TxCodeExpl
        '
        Me.TxCodeExpl.Location = New System.Drawing.Point(190, 85)
        Me.TxCodeExpl.MaxLength = 8
        Me.TxCodeExpl.Name = "TxCodeExpl"
        Me.TxCodeExpl.Size = New System.Drawing.Size(57, 20)
        Me.TxCodeExpl.TabIndex = 7
        Me.TxCodeExpl.Text = "00000000"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(78, 88)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(106, 13)
        Label4.TabIndex = 6
        Label4.Text = "Code dossier export :"
        '
        'FrExportationIsagri
        '
        Me.AcceptButton = Me.BtExporter
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(401, 235)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrExportationIsagri"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exportation Isacompta"
        Me.PanProgress.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel3 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents chkFullCompta As System.Windows.Forms.CheckBox
    Friend WithEvents TxCodeExpl As System.Windows.Forms.TextBox

#End Region

End Class
