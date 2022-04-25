<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrExportationBalance
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ExporterButton = New System.Windows.Forms.Button
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.PeriodeGroupBox = New System.Windows.Forms.GroupBox
        Me.DateFinDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateDebDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.DbDonneesDataSet = New AgrigestEDI.dbDonneesDataSet
        Me.ActivitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ActivitesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ActivitesListBox = New System.Windows.Forms.ListBox
        Me.PeriodeGroupBox.SuspendLayout()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 270)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(298, 10)
        Me.ProgressBar1.TabIndex = 7
        '
        'ExporterButton
        '
        Me.ExporterButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ExporterButton.Location = New System.Drawing.Point(236, 241)
        Me.ExporterButton.Name = "ExporterButton"
        Me.ExporterButton.Size = New System.Drawing.Size(75, 23)
        Me.ExporterButton.TabIndex = 6
        Me.ExporterButton.Text = "Exporter"
        Me.ExporterButton.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(155, 241)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 5
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'PeriodeGroupBox
        '
        Me.PeriodeGroupBox.Controls.Add(Me.DateFinDateTimePicker)
        Me.PeriodeGroupBox.Controls.Add(Me.Label2)
        Me.PeriodeGroupBox.Controls.Add(Me.DateDebDateTimePicker)
        Me.PeriodeGroupBox.Controls.Add(Me.Label1)
        Me.PeriodeGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.PeriodeGroupBox.Name = "PeriodeGroupBox"
        Me.PeriodeGroupBox.Size = New System.Drawing.Size(298, 67)
        Me.PeriodeGroupBox.TabIndex = 4
        Me.PeriodeGroupBox.TabStop = False
        Me.PeriodeGroupBox.Text = "Période"
        '
        'DateFinDateTimePicker
        '
        Me.DateFinDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFinDateTimePicker.Location = New System.Drawing.Point(186, 26)
        Me.DateFinDateTimePicker.Name = "DateFinDateTimePicker"
        Me.DateFinDateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateFinDateTimePicker.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "au :"
        '
        'DateDebDateTimePicker
        '
        Me.DateDebDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDebDateTimePicker.Location = New System.Drawing.Point(39, 26)
        Me.DateDebDateTimePicker.Name = "DateDebDateTimePicker"
        Me.DateDebDateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateDebDateTimePicker.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Du :"
        '
        'DbDonneesDataSet
        '
        Me.DbDonneesDataSet.DataSetName = "dbDonneesDataSet"
        Me.DbDonneesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ActivitesBindingSource
        '
        Me.ActivitesBindingSource.DataMember = "Activites"
        Me.ActivitesBindingSource.DataSource = Me.DbDonneesDataSet
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ActivitesListBox)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 150)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Activité(s)"
        '
        'ActivitesListBox
        '
        Me.ActivitesListBox.DataSource = Me.ActivitesBindingSource
        Me.ActivitesListBox.DisplayMember = "ALib"
        Me.ActivitesListBox.FormattingEnabled = True
        Me.ActivitesListBox.Location = New System.Drawing.Point(6, 19)
        Me.ActivitesListBox.Name = "ActivitesListBox"
        Me.ActivitesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ActivitesListBox.Size = New System.Drawing.Size(285, 121)
        Me.ActivitesListBox.TabIndex = 0
        Me.ActivitesListBox.ValueMember = "AActi"
        '
        'FrExportationBalance
        '
        Me.AcceptButton = Me.ExporterButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(323, 291)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ExporterButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.PeriodeGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrExportationBalance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportation de la Balance"
        Me.PeriodeGroupBox.ResumeLayout(False)
        Me.PeriodeGroupBox.PerformLayout()
        CType(Me.DbDonneesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ExporterButton As System.Windows.Forms.Button
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents PeriodeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DateFinDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateDebDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DbDonneesDataSet As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents ActivitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ActivitesListBox As System.Windows.Forms.ListBox
End Class
