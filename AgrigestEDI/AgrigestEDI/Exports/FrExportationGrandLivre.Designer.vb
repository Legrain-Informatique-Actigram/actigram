<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrExportationGrandLivre
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
        Me.PeriodeGroupBox = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateDebDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DateFinDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.ExporterButton = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PeriodeGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PeriodeGroupBox
        '
        Me.PeriodeGroupBox.Controls.Add(Me.DateFinDateTimePicker)
        Me.PeriodeGroupBox.Controls.Add(Me.Label2)
        Me.PeriodeGroupBox.Controls.Add(Me.DateDebDateTimePicker)
        Me.PeriodeGroupBox.Controls.Add(Me.Label1)
        Me.PeriodeGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.PeriodeGroupBox.Name = "PeriodeGroupBox"
        Me.PeriodeGroupBox.Size = New System.Drawing.Size(293, 67)
        Me.PeriodeGroupBox.TabIndex = 0
        Me.PeriodeGroupBox.TabStop = False
        Me.PeriodeGroupBox.Text = "Période"
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
        'DateDebDateTimePicker
        '
        Me.DateDebDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDebDateTimePicker.Location = New System.Drawing.Point(39, 26)
        Me.DateDebDateTimePicker.Name = "DateDebDateTimePicker"
        Me.DateDebDateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateDebDateTimePicker.TabIndex = 1
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
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(149, 85)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'ExporterButton
        '
        Me.ExporterButton.Location = New System.Drawing.Point(230, 85)
        Me.ExporterButton.Name = "ExporterButton"
        Me.ExporterButton.Size = New System.Drawing.Size(75, 23)
        Me.ExporterButton.TabIndex = 2
        Me.ExporterButton.Text = "Exporter"
        Me.ExporterButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 114)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(293, 10)
        Me.ProgressBar1.TabIndex = 3
        '
        'FrExportationGrandLivre
        '
        Me.AcceptButton = Me.ExporterButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(318, 134)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ExporterButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.PeriodeGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrExportationGrandLivre"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportation du Grand Livre"
        Me.PeriodeGroupBox.ResumeLayout(False)
        Me.PeriodeGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PeriodeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DateDebDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateFinDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents ExporterButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
