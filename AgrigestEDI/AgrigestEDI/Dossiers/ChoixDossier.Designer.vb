<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoixDossier
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
        Dim DDossierLabel As System.Windows.Forms.Label
        Dim DDtDebExLabel As System.Windows.Forms.Label
        Dim DDtFinExLabel As System.Windows.Forms.Label
        Me.cmdSuppr = New System.Windows.Forms.Button
        Me.cmdNew = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.DbDonneesDataSet = New AgrigestEDI.dbDonneesDataSet
        Me.DossiersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DossiersTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
        Me.DDossierComboBox = New System.Windows.Forms.ComboBox
        Me.ExploitationsTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
        Me.DDtDebExLabel1 = New System.Windows.Forms.Label
        Me.DDtFinExLabel1 = New System.Windows.Forms.Label
        Me.cmdModif = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
        DDossierLabel = New System.Windows.Forms.Label
        DDtDebExLabel = New System.Windows.Forms.Label
        DDtFinExLabel = New System.Windows.Forms.Label
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DDossierLabel
        '
        DDossierLabel.AutoSize = True
        DDossierLabel.Location = New System.Drawing.Point(8, 9)
        DDossierLabel.Name = "DDossierLabel"
        DDossierLabel.Size = New System.Drawing.Size(169, 13)
        DDossierLabel.TabIndex = 2
        DDossierLabel.Text = "Sélectionnez l'exercice à charger :"
        '
        'DDtDebExLabel
        '
        DDtDebExLabel.AutoSize = True
        DDtDebExLabel.Location = New System.Drawing.Point(27, 55)
        DDtDebExLabel.Name = "DDtDebExLabel"
        DDtDebExLabel.Size = New System.Drawing.Size(69, 13)
        DDtDebExLabel.TabIndex = 7
        DDtDebExLabel.Text = "Exercice du :"
        '
        'DDtFinExLabel
        '
        DDtFinExLabel.AutoSize = True
        DDtFinExLabel.Location = New System.Drawing.Point(190, 56)
        DDtFinExLabel.Name = "DDtFinExLabel"
        DDtFinExLabel.Size = New System.Drawing.Size(22, 13)
        DDtFinExLabel.TabIndex = 9
        DDtFinExLabel.Text = "au:"
        '
        'cmdSuppr
        '
        Me.cmdSuppr.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.cmdSuppr.Location = New System.Drawing.Point(203, 86)
        Me.cmdSuppr.Name = "cmdSuppr"
        Me.cmdSuppr.Size = New System.Drawing.Size(97, 23)
        Me.cmdSuppr.TabIndex = 6
        Me.cmdSuppr.Text = "Suppression"
        Me.cmdSuppr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSuppr.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.cmdNew.Location = New System.Drawing.Point(12, 86)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(84, 23)
        Me.cmdNew.TabIndex = 4
        Me.cmdNew.Text = "Création"
        Me.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(169, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(242, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'DbDonneesDataSet
        '
        Me.DbDonneesDataSet.DataSetName = "dbDonneesDataSet"
        Me.DbDonneesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DossiersBindingSource
        '
        Me.DossiersBindingSource.DataMember = "Dossiers"
        Me.DossiersBindingSource.DataSource = Me.DbDonneesDataSet
        Me.DossiersBindingSource.Sort = "DDtDebEx desc"
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'DDossierComboBox
        '
        Me.DDossierComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DDossierComboBox.DataSource = Me.DossiersBindingSource
        Me.DDossierComboBox.DisplayMember = "DDisplay"
        Me.DDossierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DDossierComboBox.FormattingEnabled = True
        Me.DDossierComboBox.Location = New System.Drawing.Point(11, 25)
        Me.DDossierComboBox.Name = "DDossierComboBox"
        Me.DDossierComboBox.Size = New System.Drawing.Size(293, 21)
        Me.DDossierComboBox.TabIndex = 3
        Me.DDossierComboBox.ValueMember = "DDossier"
        '
        'ExploitationsTableAdapter
        '
        Me.ExploitationsTableAdapter.ClearBeforeFill = True
        '
        'DDtDebExLabel1
        '
        Me.DDtDebExLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DDtDebExLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DossiersBindingSource, "DDtDebEx", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
        Me.DDtDebExLabel1.Location = New System.Drawing.Point(102, 54)
        Me.DDtDebExLabel1.Name = "DDtDebExLabel1"
        Me.DDtDebExLabel1.Size = New System.Drawing.Size(82, 19)
        Me.DDtDebExLabel1.TabIndex = 8
        Me.DDtDebExLabel1.Text = "XX/XX/XXXX"
        '
        'DDtFinExLabel1
        '
        Me.DDtFinExLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DDtFinExLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DossiersBindingSource, "DDtFinEx", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
        Me.DDtFinExLabel1.Location = New System.Drawing.Point(218, 54)
        Me.DDtFinExLabel1.Name = "DDtFinExLabel1"
        Me.DDtFinExLabel1.Size = New System.Drawing.Size(82, 19)
        Me.DDtFinExLabel1.TabIndex = 10
        Me.DDtFinExLabel1.Text = "XX/XX/XXXX"
        '
        'cmdModif
        '
        Me.cmdModif.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.cmdModif.Location = New System.Drawing.Point(102, 86)
        Me.cmdModif.Name = "cmdModif"
        Me.cmdModif.Size = New System.Drawing.Size(95, 23)
        Me.cmdModif.TabIndex = 11
        Me.cmdModif.Text = "Modification"
        Me.cmdModif.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdModif.UseVisualStyleBackColor = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(DDossierLabel)
        Me.GradientPanel1.Controls.Add(Me.cmdModif)
        Me.GradientPanel1.Controls.Add(Me.DDossierComboBox)
        Me.GradientPanel1.Controls.Add(DDtFinExLabel)
        Me.GradientPanel1.Controls.Add(Me.cmdNew)
        Me.GradientPanel1.Controls.Add(Me.DDtFinExLabel1)
        Me.GradientPanel1.Controls.Add(Me.cmdSuppr)
        Me.GradientPanel1.Controls.Add(DDtDebExLabel)
        Me.GradientPanel1.Controls.Add(Me.DDtDebExLabel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(316, 170)
        Me.GradientPanel1.TabIndex = 12
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 125)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(316, 45)
        Me.GradientPanel2.TabIndex = 13
        '
        'JournalTableAdapter
        '
        Me.JournalTableAdapter.ClearBeforeFill = True
        '
        'ChoixDossier
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(316, 170)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChoixDossier"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choix de l'exercice"
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DbDonneesDataSet As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents DossiersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
    Friend WithEvents DDossierComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ExploitationsTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdSuppr As System.Windows.Forms.Button
    Friend WithEvents DDtDebExLabel1 As System.Windows.Forms.Label
    Friend WithEvents DDtFinExLabel1 As System.Windows.Forms.Label
    Friend WithEvents cmdModif As System.Windows.Forms.Button
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter

End Class
