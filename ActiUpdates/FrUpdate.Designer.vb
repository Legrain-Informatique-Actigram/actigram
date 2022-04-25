<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrUpdate
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
        Dim NomAppliLabel As System.Windows.Forms.Label
        Dim VersionLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim TailleFichierLabel As System.Windows.Forms.Label
        Dim DateFichierLabel As System.Windows.Forms.Label
        Me.DsActiUpdates = New ActiUpdates.dsActiUpdates
        Me.UpdatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UpdatesTableAdapter = New ActiUpdates.dsActiUpdatesTableAdapters.UpdatesTableAdapter
        Me.NomAppliComboBox = New System.Windows.Forms.ComboBox
        Me.ApplicationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VersionTextBox = New System.Windows.Forms.TextBox
        Me.NiveauComboBox = New System.Windows.Forms.ComboBox
        Me.ActifCheckBox = New System.Windows.Forms.CheckBox
        Me.DownloadPathTextBox = New System.Windows.Forms.TextBox
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.TailleFichierLabel1 = New System.Windows.Forms.Label
        Me.DateFichierLabel1 = New System.Windows.Forms.Label
        Me.btBrowse = New System.Windows.Forms.Button
        Me.ApplicationsTableAdapter = New ActiUpdates.dsActiUpdatesTableAdapters.ApplicationsTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        NomAppliLabel = New System.Windows.Forms.Label
        VersionLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        TailleFichierLabel = New System.Windows.Forms.Label
        DateFichierLabel = New System.Windows.Forms.Label
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NomAppliLabel
        '
        NomAppliLabel.AutoSize = True
        NomAppliLabel.Location = New System.Drawing.Point(12, 9)
        NomAppliLabel.Name = "NomAppliLabel"
        NomAppliLabel.Size = New System.Drawing.Size(65, 13)
        NomAppliLabel.TabIndex = 1
        NomAppliLabel.Text = "Application :"
        '
        'VersionLabel
        '
        VersionLabel.AutoSize = True
        VersionLabel.Location = New System.Drawing.Point(12, 36)
        VersionLabel.Name = "VersionLabel"
        VersionLabel.Size = New System.Drawing.Size(45, 13)
        VersionLabel.TabIndex = 3
        VersionLabel.Text = "Version:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(12, 132)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(63, 13)
        DescriptionLabel.TabIndex = 11
        DescriptionLabel.Text = "Description:"
        '
        'TailleFichierLabel
        '
        TailleFichierLabel.AutoSize = True
        TailleFichierLabel.Location = New System.Drawing.Point(160, 42)
        TailleFichierLabel.Name = "TailleFichierLabel"
        TailleFichierLabel.Size = New System.Drawing.Size(38, 13)
        TailleFichierLabel.TabIndex = 13
        TailleFichierLabel.Text = "Taille :"
        '
        'DateFichierLabel
        '
        DateFichierLabel.AutoSize = True
        DateFichierLabel.Location = New System.Drawing.Point(3, 42)
        DateFichierLabel.Name = "DateFichierLabel"
        DateFichierLabel.Size = New System.Drawing.Size(36, 13)
        DateFichierLabel.TabIndex = 15
        DateFichierLabel.Text = "Date :"
        '
        'DsActiUpdates
        '
        Me.DsActiUpdates.DataSetName = "dsActiUpdates"
        Me.DsActiUpdates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UpdatesBindingSource
        '
        Me.UpdatesBindingSource.DataMember = "Updates"
        Me.UpdatesBindingSource.DataSource = Me.DsActiUpdates
        '
        'UpdatesTableAdapter
        '
        Me.UpdatesTableAdapter.ClearBeforeFill = True
        '
        'NomAppliComboBox
        '
        Me.NomAppliComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.UpdatesBindingSource, "NomAppli", True))
        Me.NomAppliComboBox.DataSource = Me.ApplicationsBindingSource
        Me.NomAppliComboBox.DisplayMember = "Nom"
        Me.NomAppliComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NomAppliComboBox.FormattingEnabled = True
        Me.NomAppliComboBox.Location = New System.Drawing.Point(84, 6)
        Me.NomAppliComboBox.Name = "NomAppliComboBox"
        Me.NomAppliComboBox.Size = New System.Drawing.Size(308, 21)
        Me.NomAppliComboBox.TabIndex = 2
        Me.NomAppliComboBox.ValueMember = "Nom"
        '
        'ApplicationsBindingSource
        '
        Me.ApplicationsBindingSource.DataMember = "Applications"
        Me.ApplicationsBindingSource.DataSource = Me.DsActiUpdates
        '
        'VersionTextBox
        '
        Me.VersionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "Version", True))
        Me.VersionTextBox.Location = New System.Drawing.Point(83, 34)
        Me.VersionTextBox.Name = "VersionTextBox"
        Me.VersionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.VersionTextBox.TabIndex = 4
        '
        'NiveauComboBox
        '
        Me.NiveauComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.UpdatesBindingSource, "Niveau", True))
        Me.NiveauComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NiveauComboBox.FormattingEnabled = True
        Me.NiveauComboBox.Location = New System.Drawing.Point(251, 33)
        Me.NiveauComboBox.Name = "NiveauComboBox"
        Me.NiveauComboBox.Size = New System.Drawing.Size(140, 21)
        Me.NiveauComboBox.TabIndex = 6
        '
        'ActifCheckBox
        '
        Me.ActifCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.UpdatesBindingSource, "Actif", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ActifCheckBox.Location = New System.Drawing.Point(189, 32)
        Me.ActifCheckBox.Name = "ActifCheckBox"
        Me.ActifCheckBox.Size = New System.Drawing.Size(56, 24)
        Me.ActifCheckBox.TabIndex = 8
        Me.ActifCheckBox.Text = "Actif"
        '
        'DownloadPathTextBox
        '
        Me.DownloadPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "DownloadPath", True))
        Me.DownloadPathTextBox.Location = New System.Drawing.Point(6, 19)
        Me.DownloadPathTextBox.Name = "DownloadPathTextBox"
        Me.DownloadPathTextBox.Size = New System.Drawing.Size(330, 20)
        Me.DownloadPathTextBox.TabIndex = 10
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "Description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(15, 148)
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DescriptionTextBox.Size = New System.Drawing.Size(376, 263)
        Me.DescriptionTextBox.TabIndex = 12
        Me.DescriptionTextBox.WordWrap = False
        '
        'TailleFichierLabel1
        '
        Me.TailleFichierLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "TailleFichier", True))
        Me.TailleFichierLabel1.Location = New System.Drawing.Point(204, 42)
        Me.TailleFichierLabel1.Name = "TailleFichierLabel1"
        Me.TailleFichierLabel1.Size = New System.Drawing.Size(100, 13)
        Me.TailleFichierLabel1.TabIndex = 14
        Me.TailleFichierLabel1.Text = "13225ko"
        '
        'DateFichierLabel1
        '
        Me.DateFichierLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "DateFichier", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "g"))
        Me.DateFichierLabel1.Location = New System.Drawing.Point(45, 42)
        Me.DateFichierLabel1.Name = "DateFichierLabel1"
        Me.DateFichierLabel1.Size = New System.Drawing.Size(100, 13)
        Me.DateFichierLabel1.TabIndex = 16
        Me.DateFichierLabel1.Text = "00/00/0000 00:00"
        '
        'btBrowse
        '
        Me.btBrowse.Location = New System.Drawing.Point(342, 19)
        Me.btBrowse.Name = "btBrowse"
        Me.btBrowse.Size = New System.Drawing.Size(28, 20)
        Me.btBrowse.TabIndex = 17
        Me.btBrowse.Text = "..."
        Me.btBrowse.UseVisualStyleBackColor = True
        '
        'ApplicationsTableAdapter
        '
        Me.ApplicationsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DownloadPathTextBox)
        Me.GroupBox1.Controls.Add(Me.btBrowse)
        Me.GroupBox1.Controls.Add(Me.TailleFichierLabel1)
        Me.GroupBox1.Controls.Add(DateFichierLabel)
        Me.GroupBox1.Controls.Add(TailleFichierLabel)
        Me.GroupBox1.Controls.Add(Me.DateFichierLabel1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 67)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fichier"
        '
        'BtCancel
        '
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(317, 417)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 19
        Me.BtCancel.Text = "Annuler"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.Location = New System.Drawing.Point(236, 417)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 20
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'FrUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(404, 447)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(DescriptionLabel)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(Me.ActifCheckBox)
        Me.Controls.Add(Me.NiveauComboBox)
        Me.Controls.Add(VersionLabel)
        Me.Controls.Add(Me.VersionTextBox)
        Me.Controls.Add(NomAppliLabel)
        Me.Controls.Add(Me.NomAppliComboBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrUpdate"
        Me.Text = "Mise à jour"
        CType(Me.DsActiUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsActiUpdates As ActiUpdates.dsActiUpdates
    Friend WithEvents UpdatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UpdatesTableAdapter As ActiUpdates.dsActiUpdatesTableAdapters.UpdatesTableAdapter
    Friend WithEvents NomAppliComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents VersionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NiveauComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ActifCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DownloadPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TailleFichierLabel1 As System.Windows.Forms.Label
    Friend WithEvents DateFichierLabel1 As System.Windows.Forms.Label
    Friend WithEvents btBrowse As System.Windows.Forms.Button
    Friend WithEvents ApplicationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ApplicationsTableAdapter As ActiUpdates.dsActiUpdatesTableAdapters.ApplicationsTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
End Class
