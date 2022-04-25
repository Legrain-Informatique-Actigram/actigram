<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrOptionsImprBilan
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
        Me.dtpDtDeb = New System.Windows.Forms.DateTimePicker
        Me.dtpDtFin = New System.Windows.Forms.DateTimePicker
        Me.ExporterButton = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.ImprimerButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.openDlg = New System.Windows.Forms.OpenFileDialog
        Me.TxObs = New System.Windows.Forms.TextBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.Label4 = New System.Windows.Forms.Label
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDtDeb
        '
        Me.dtpDtDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDtDeb.Location = New System.Drawing.Point(36, 33)
        Me.dtpDtDeb.Name = "dtpDtDeb"
        Me.dtpDtDeb.Size = New System.Drawing.Size(96, 20)
        Me.dtpDtDeb.TabIndex = 2
        '
        'dtpDtFin
        '
        Me.dtpDtFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDtFin.Location = New System.Drawing.Point(163, 33)
        Me.dtpDtFin.Name = "dtpDtFin"
        Me.dtpDtFin.Size = New System.Drawing.Size(95, 20)
        Me.dtpDtFin.TabIndex = 3
        '
        'ExporterButton
        '
        Me.ExporterButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExporterButton.Location = New System.Drawing.Point(59, 10)
        Me.ExporterButton.Name = "ExporterButton"
        Me.ExporterButton.Size = New System.Drawing.Size(75, 23)
        Me.ExporterButton.TabIndex = 7
        Me.ExporterButton.Text = "Exporter"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.AnnulerButton)
        Me.GradientPanel2.Controls.Add(Me.ExporterButton)
        Me.GradientPanel2.Controls.Add(Me.ImprimerButton)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 226)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(304, 45)
        Me.GradientPanel2.TabIndex = 22
        '
        'AnnulerButton
        '
        Me.AnnulerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(217, 10)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        '
        'ImprimerButton
        '
        Me.ImprimerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImprimerButton.Location = New System.Drawing.Point(137, 10)
        Me.ImprimerButton.Name = "ImprimerButton"
        Me.ImprimerButton.Size = New System.Drawing.Size(75, 23)
        Me.ImprimerButton.TabIndex = 0
        Me.ImprimerButton.Text = "Imprimer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Bilan des ventes pour la période "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "au"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Du "
        '
        'openDlg
        '
        Me.openDlg.Filter = "Classeur Excel (*.xls)|*.xls"
        Me.openDlg.Title = "Sélectionnez le fichier Phyto Data à importer"
        '
        'TxObs
        '
        Me.TxObs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxObs.Location = New System.Drawing.Point(16, 80)
        Me.TxObs.MaxLength = 500
        Me.TxObs.Multiline = True
        Me.TxObs.Name = "TxObs"
        Me.TxObs.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxObs.Size = New System.Drawing.Size(273, 181)
        Me.TxObs.TabIndex = 8
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.dtpDtDeb)
        Me.GradientPanel1.Controls.Add(Me.dtpDtFin)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.TxObs)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(304, 271)
        Me.GradientPanel1.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Observations :"
        '
        'FrOptionsImprBilan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(304, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrOptionsImprBilan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bilan annuel des ventes"
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpDtDeb As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ExporterButton As System.Windows.Forms.Button
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents ImprimerButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents openDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TxObs As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
