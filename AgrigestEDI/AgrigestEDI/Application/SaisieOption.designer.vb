Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class SaisieOption
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
            Dim RepEtatsLabel As System.Windows.Forms.Label
            Dim Label1 As System.Windows.Forms.Label
            Me.fond = New Ascend.Windows.Forms.GradientPanel
            Me.Label4 = New System.Windows.Forms.Label
            Me.chkExportComplet = New System.Windows.Forms.CheckBox
            Me.GroupBox3 = New System.Windows.Forms.GroupBox
            Me.cbNiveauxUpdate = New System.Windows.Forms.ComboBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.lnkUpdate = New System.Windows.Forms.LinkLabel
            Me.TxUrlUpdate = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.ChkAutoUpdate = New System.Windows.Forms.CheckBox
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.RepEtatsTextBox = New System.Windows.Forms.TextBox
            Me.btBrowseEtats = New System.Windows.Forms.Button
            Me.btBrowseVNC = New System.Windows.Forms.Button
            Me.CheminVNCTextBox = New System.Windows.Forms.TextBox
            Me.BloqueExporteCheckBox = New System.Windows.Forms.CheckBox
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.rbtJournal = New System.Windows.Forms.RadioButton
            Me.rbtGlobal = New System.Windows.Forms.RadioButton
            Me.chkSuggestPiece = New System.Windows.Forms.CheckBox
            Me.toolbar = New System.Windows.Forms.ToolStrip
            Me.EnregistrerToolStripButton = New System.Windows.Forms.ToolStripButton
            Me.LbTitre = New System.Windows.Forms.ToolStripLabel
            Me.BtClose = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog
            Me.chkAutoImportEDI = New System.Windows.Forms.CheckBox
            Me.chkAutoDownloadEdi = New System.Windows.Forms.CheckBox
            Me.GroupBox4 = New System.Windows.Forms.GroupBox
            RepEtatsLabel = New System.Windows.Forms.Label
            Label1 = New System.Windows.Forms.Label
            Me.fond.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.toolbar.SuspendLayout()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'RepEtatsLabel
            '
            RepEtatsLabel.AutoSize = True
            RepEtatsLabel.Location = New System.Drawing.Point(7, 22)
            RepEtatsLabel.Name = "RepEtatsLabel"
            RepEtatsLabel.Size = New System.Drawing.Size(34, 13)
            RepEtatsLabel.TabIndex = 0
            RepEtatsLabel.Text = "Etats:"
            '
            'Label1
            '
            Label1.AutoSize = True
            Label1.Location = New System.Drawing.Point(7, 48)
            Label1.Name = "Label1"
            Label1.Size = New System.Drawing.Size(54, 13)
            Label1.TabIndex = 3
            Label1.Text = "UltraVNC:"
            '
            'fond
            '
            Me.fond.Controls.Add(Me.GroupBox4)
            Me.fond.Controls.Add(Me.Label4)
            Me.fond.Controls.Add(Me.chkExportComplet)
            Me.fond.Controls.Add(Me.GroupBox3)
            Me.fond.Controls.Add(Me.GroupBox2)
            Me.fond.Controls.Add(Me.BloqueExporteCheckBox)
            Me.fond.Controls.Add(Me.GroupBox1)
            Me.fond.Controls.Add(Me.chkSuggestPiece)
            Me.fond.Dock = System.Windows.Forms.DockStyle.Fill
            Me.fond.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
            Me.fond.Location = New System.Drawing.Point(0, 25)
            Me.fond.Name = "fond"
            Me.fond.Size = New System.Drawing.Size(398, 426)
            Me.fond.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(39, 85)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(338, 32)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "à décocher pour les comptas ayant des exports en cours d'années (TVA trimestriell" & _
                "e,...)"
            '
            'chkExportComplet
            '
            Me.chkExportComplet.AutoSize = True
            Me.chkExportComplet.Location = New System.Drawing.Point(17, 65)
            Me.chkExportComplet.Name = "chkExportComplet"
            Me.chkExportComplet.Size = New System.Drawing.Size(192, 17)
            Me.chkExportComplet.TabIndex = 5
            Me.chkExportComplet.Text = "Exporter toute la compta par défaut"
            Me.chkExportComplet.UseVisualStyleBackColor = True
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.cbNiveauxUpdate)
            Me.GroupBox3.Controls.Add(Me.Label3)
            Me.GroupBox3.Controls.Add(Me.lnkUpdate)
            Me.GroupBox3.Controls.Add(Me.TxUrlUpdate)
            Me.GroupBox3.Controls.Add(Me.Label2)
            Me.GroupBox3.Controls.Add(Me.ChkAutoUpdate)
            Me.GroupBox3.Location = New System.Drawing.Point(17, 193)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(366, 119)
            Me.GroupBox3.TabIndex = 4
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Mises à jour"
            '
            'cbNiveauxUpdate
            '
            Me.cbNiveauxUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbNiveauxUpdate.FormattingEnabled = True
            Me.cbNiveauxUpdate.Location = New System.Drawing.Point(130, 68)
            Me.cbNiveauxUpdate.Name = "cbNiveauxUpdate"
            Me.cbNiveauxUpdate.Size = New System.Drawing.Size(230, 21)
            Me.cbNiveauxUpdate.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(9, 71)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(115, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Niveau de mise à jour :"
            '
            'lnkUpdate
            '
            Me.lnkUpdate.AutoSize = True
            Me.lnkUpdate.Location = New System.Drawing.Point(7, 93)
            Me.lnkUpdate.Name = "lnkUpdate"
            Me.lnkUpdate.Size = New System.Drawing.Size(205, 13)
            Me.lnkUpdate.TabIndex = 3
            Me.lnkUpdate.TabStop = True
            Me.lnkUpdate.Text = "Rechercher des mises à jour maintenant..."
            '
            'TxUrlUpdate
            '
            Me.TxUrlUpdate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.AgrigestEDI.My.MySettings.Default, "AgrigestEDI_ActiUpdates_Updates", True))
            Me.TxUrlUpdate.Location = New System.Drawing.Point(130, 42)
            Me.TxUrlUpdate.Name = "TxUrlUpdate"
            Me.TxUrlUpdate.Size = New System.Drawing.Size(230, 20)
            Me.TxUrlUpdate.TabIndex = 2
            Me.TxUrlUpdate.Text = Global.AgrigestEDI.My.MySettings.Default.AgrigestEDI_ActiUpdates_Updates
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(7, 45)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(117, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Service de mise à jour :"
            '
            'ChkAutoUpdate
            '
            Me.ChkAutoUpdate.AutoSize = True
            Me.ChkAutoUpdate.Checked = Global.AgrigestEDI.My.MySettings.Default.AutoUpdate
            Me.ChkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ChkAutoUpdate.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AgrigestEDI.My.MySettings.Default, "AutoUpdate", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.ChkAutoUpdate.Location = New System.Drawing.Point(10, 19)
            Me.ChkAutoUpdate.Name = "ChkAutoUpdate"
            Me.ChkAutoUpdate.Size = New System.Drawing.Size(244, 17)
            Me.ChkAutoUpdate.TabIndex = 0
            Me.ChkAutoUpdate.Text = "Rechercher automatiquement des mises à jour"
            Me.ChkAutoUpdate.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(RepEtatsLabel)
            Me.GroupBox2.Controls.Add(Me.RepEtatsTextBox)
            Me.GroupBox2.Controls.Add(Me.btBrowseEtats)
            Me.GroupBox2.Controls.Add(Me.btBrowseVNC)
            Me.GroupBox2.Controls.Add(Me.CheminVNCTextBox)
            Me.GroupBox2.Controls.Add(Label1)
            Me.GroupBox2.Location = New System.Drawing.Point(17, 396)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(366, 21)
            Me.GroupBox2.TabIndex = 3
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Emplacements"
            Me.GroupBox2.Visible = False
            '
            'RepEtatsTextBox
            '
            Me.RepEtatsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.AgrigestEDI.My.MySettings.Default, "RepEtats", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.ErrorProvider.SetIconAlignment(Me.RepEtatsTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.RepEtatsTextBox.Location = New System.Drawing.Point(67, 19)
            Me.RepEtatsTextBox.Name = "RepEtatsTextBox"
            Me.RepEtatsTextBox.Size = New System.Drawing.Size(261, 20)
            Me.RepEtatsTextBox.TabIndex = 1
            Me.RepEtatsTextBox.Text = Global.AgrigestEDI.My.MySettings.Default.RepEtats
            '
            'btBrowseEtats
            '
            Me.btBrowseEtats.Image = Global.AgrigestEDI.My.Resources.Resources.open
            Me.btBrowseEtats.Location = New System.Drawing.Point(334, 19)
            Me.btBrowseEtats.Name = "btBrowseEtats"
            Me.btBrowseEtats.Size = New System.Drawing.Size(26, 23)
            Me.btBrowseEtats.TabIndex = 2
            Me.btBrowseEtats.UseVisualStyleBackColor = True
            '
            'btBrowseVNC
            '
            Me.btBrowseVNC.Image = Global.AgrigestEDI.My.Resources.Resources.open
            Me.btBrowseVNC.Location = New System.Drawing.Point(334, 42)
            Me.btBrowseVNC.Name = "btBrowseVNC"
            Me.btBrowseVNC.Size = New System.Drawing.Size(26, 23)
            Me.btBrowseVNC.TabIndex = 5
            Me.btBrowseVNC.UseVisualStyleBackColor = True
            '
            'CheminVNCTextBox
            '
            Me.CheminVNCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.AgrigestEDI.My.MySettings.Default, "CheminVNC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.ErrorProvider.SetIconAlignment(Me.CheminVNCTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.CheminVNCTextBox.Location = New System.Drawing.Point(67, 45)
            Me.CheminVNCTextBox.Name = "CheminVNCTextBox"
            Me.CheminVNCTextBox.Size = New System.Drawing.Size(261, 20)
            Me.CheminVNCTextBox.TabIndex = 4
            Me.CheminVNCTextBox.Text = Global.AgrigestEDI.My.MySettings.Default.CheminVNC
            '
            'BloqueExporteCheckBox
            '
            Me.BloqueExporteCheckBox.Checked = Global.AgrigestEDI.My.MySettings.Default.BloqueExporte
            Me.BloqueExporteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AgrigestEDI.My.MySettings.Default, "BloqueExporte", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.BloqueExporteCheckBox.Location = New System.Drawing.Point(17, 35)
            Me.BloqueExporteCheckBox.Name = "BloqueExporteCheckBox"
            Me.BloqueExporteCheckBox.Size = New System.Drawing.Size(287, 24)
            Me.BloqueExporteCheckBox.TabIndex = 1
            Me.BloqueExporteCheckBox.Text = "Empecher la modification des pièces déjà exportées."
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rbtJournal)
            Me.GroupBox1.Controls.Add(Me.rbtGlobal)
            Me.GroupBox1.Location = New System.Drawing.Point(17, 120)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(366, 67)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Nouveaux numéros de pièce"
            '
            'rbtJournal
            '
            Me.rbtJournal.AutoSize = True
            Me.rbtJournal.Location = New System.Drawing.Point(6, 42)
            Me.rbtJournal.Name = "rbtJournal"
            Me.rbtJournal.Size = New System.Drawing.Size(147, 17)
            Me.rbtJournal.TabIndex = 1
            Me.rbtJournal.Text = "Incrémentation par journal"
            Me.rbtJournal.UseVisualStyleBackColor = True
            '
            'rbtGlobal
            '
            Me.rbtGlobal.AutoSize = True
            Me.rbtGlobal.Checked = True
            Me.rbtGlobal.Location = New System.Drawing.Point(6, 19)
            Me.rbtGlobal.Name = "rbtGlobal"
            Me.rbtGlobal.Size = New System.Drawing.Size(132, 17)
            Me.rbtGlobal.TabIndex = 0
            Me.rbtGlobal.TabStop = True
            Me.rbtGlobal.Text = "Incrémentation globale"
            Me.rbtGlobal.UseVisualStyleBackColor = True
            '
            'chkSuggestPiece
            '
            Me.chkSuggestPiece.AutoSize = True
            Me.chkSuggestPiece.Checked = Global.AgrigestEDI.My.MySettings.Default.SuggestLibPiece
            Me.chkSuggestPiece.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkSuggestPiece.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AgrigestEDI.My.MySettings.Default, "SuggestLibPiece", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.chkSuggestPiece.Location = New System.Drawing.Point(17, 12)
            Me.chkSuggestPiece.Name = "chkSuggestPiece"
            Me.chkSuggestPiece.Size = New System.Drawing.Size(163, 17)
            Me.chkSuggestPiece.TabIndex = 0
            Me.chkSuggestPiece.Text = "Suggérer les libellés de pièce"
            Me.chkSuggestPiece.UseVisualStyleBackColor = True
            '
            'toolbar
            '
            Me.toolbar.AllowMerge = False
            Me.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnregistrerToolStripButton, Me.LbTitre, Me.BtClose, Me.ToolStripButton1})
            Me.toolbar.Location = New System.Drawing.Point(0, 0)
            Me.toolbar.Name = "toolbar"
            Me.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
            Me.toolbar.Size = New System.Drawing.Size(398, 25)
            Me.toolbar.TabIndex = 0
            Me.toolbar.Text = "ToolStrip1"
            '
            'EnregistrerToolStripButton
            '
            Me.EnregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.EnregistrerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.save
            Me.EnregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.EnregistrerToolStripButton.Name = "EnregistrerToolStripButton"
            Me.EnregistrerToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.EnregistrerToolStripButton.Text = "&Enregistrer"
            '
            'LbTitre
            '
            Me.LbTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LbTitre.Name = "LbTitre"
            Me.LbTitre.Size = New System.Drawing.Size(57, 22)
            Me.LbTitre.Text = "LbTitre"
            '
            'BtClose
            '
            Me.BtClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.BtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.BtClose.Font = New System.Drawing.Font("Webdings", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
            Me.BtClose.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.BtClose.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtClose.Name = "BtClose"
            Me.BtClose.Size = New System.Drawing.Size(26, 22)
            Me.BtClose.Text = "r"
            Me.BtClose.ToolTipText = "Fermer"
            '
            'ToolStripButton1
            '
            Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.ToolStripButton1.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton1.Name = "ToolStripButton1"
            Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton1.Text = "?"
            Me.ToolStripButton1.ToolTipText = "Aide"
            '
            'ErrorProvider
            '
            Me.ErrorProvider.ContainerControl = Me
            '
            'chkAutoImportEDI
            '
            Me.chkAutoImportEDI.AutoSize = True
            Me.chkAutoImportEDI.Checked = Global.AgrigestEDI.My.MySettings.Default.AutoImportEDI
            Me.chkAutoImportEDI.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAutoImportEDI.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AgrigestEDI.My.MySettings.Default, "AutoImportEDI", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.chkAutoImportEDI.Location = New System.Drawing.Point(6, 42)
            Me.chkAutoImportEDI.Name = "chkAutoImportEDI"
            Me.chkAutoImportEDI.Size = New System.Drawing.Size(248, 17)
            Me.chkAutoImportEDI.TabIndex = 7
            Me.chkAutoImportEDI.Text = "Proposer l'import des fichiers EDI au démarrage"
            Me.chkAutoImportEDI.UseVisualStyleBackColor = True
            '
            'chkAutoDownloadEdi
            '
            Me.chkAutoDownloadEdi.AutoSize = True
            Me.chkAutoDownloadEdi.Checked = Global.AgrigestEDI.My.MySettings.Default.AutoCheckFTP
            Me.chkAutoDownloadEdi.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAutoDownloadEdi.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AgrigestEDI.My.MySettings.Default, "AutoCheckFTP", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.chkAutoDownloadEdi.Location = New System.Drawing.Point(6, 19)
            Me.chkAutoDownloadEdi.Name = "chkAutoDownloadEdi"
            Me.chkAutoDownloadEdi.Size = New System.Drawing.Size(272, 17)
            Me.chkAutoDownloadEdi.TabIndex = 8
            Me.chkAutoDownloadEdi.Text = "Télécharger automatiquement les EDI au démarrage"
            Me.chkAutoDownloadEdi.UseVisualStyleBackColor = True
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.chkAutoDownloadEdi)
            Me.GroupBox4.Controls.Add(Me.chkAutoImportEDI)
            Me.GroupBox4.Location = New System.Drawing.Point(17, 320)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(366, 70)
            Me.GroupBox4.TabIndex = 9
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Interface EDI"
            '
            'SaisieOption
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(398, 451)
            Me.ControlBox = False
            Me.Controls.Add(Me.fond)
            Me.Controls.Add(Me.toolbar)
            Me.Name = "SaisieOption"
            Me.Text = "Options"
            Me.fond.ResumeLayout(False)
            Me.fond.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.toolbar.ResumeLayout(False)
            Me.toolbar.PerformLayout()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox4.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
        Friend WithEvents LbTitre As System.Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
        Public WithEvents fond As Ascend.Windows.Forms.GradientPanel
        Public WithEvents toolbar As System.Windows.Forms.ToolStrip
        Friend WithEvents EnregistrerToolStripButton As System.Windows.Forms.ToolStripButton
        Friend WithEvents btBrowseEtats As System.Windows.Forms.Button
        Friend WithEvents RepEtatsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
        Friend WithEvents chkSuggestPiece As System.Windows.Forms.CheckBox
        Friend WithEvents btBrowseVNC As System.Windows.Forms.Button
        Friend WithEvents CheminVNCTextBox As System.Windows.Forms.TextBox
        Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtJournal As System.Windows.Forms.RadioButton
        Friend WithEvents rbtGlobal As System.Windows.Forms.RadioButton
        Friend WithEvents BloqueExporteCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents ChkAutoUpdate As System.Windows.Forms.CheckBox
        Friend WithEvents lnkUpdate As System.Windows.Forms.LinkLabel
        Friend WithEvents TxUrlUpdate As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cbNiveauxUpdate As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents chkExportComplet As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutoDownloadEdi As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutoImportEDI As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    End Class
End Namespace