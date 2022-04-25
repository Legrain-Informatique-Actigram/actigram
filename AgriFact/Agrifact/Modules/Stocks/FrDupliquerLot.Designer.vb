<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrDupliquerLot
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
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.ObservationTextBox = New System.Windows.Forms.TextBox
        Me.DateCreationDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.nLotTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.ObservationTextBox)
        Me.GradientPanel2.Controls.Add(Me.DateCreationDateTimePicker)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Controls.Add(Me.nLotTextBox)
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(365, 244)
        Me.GradientPanel2.TabIndex = 1
        '
        'ObservationTextBox
        '
        Me.ObservationTextBox.Location = New System.Drawing.Point(126, 102)
        Me.ObservationTextBox.Multiline = True
        Me.ObservationTextBox.Name = "ObservationTextBox"
        Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservationTextBox.Size = New System.Drawing.Size(215, 123)
        Me.ObservationTextBox.TabIndex = 6
        '
        'DateCreationDateTimePicker
        '
        Me.DateCreationDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCreationDateTimePicker.Location = New System.Drawing.Point(126, 76)
        Me.DateCreationDateTimePicker.Name = "DateCreationDateTimePicker"
        Me.DateCreationDateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateCreationDateTimePicker.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Observation"
        '
        'nLotTextBox
        '
        Me.nLotTextBox.Location = New System.Drawing.Point(126, 50)
        Me.nLotTextBox.Name = "nLotTextBox"
        Me.nLotTextBox.Size = New System.Drawing.Size(215, 20)
        Me.nLotTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date de Création"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "N° Lot"
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(365, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Informations générales"
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(302, 262)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 2
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(221, 262)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'FrDupliquerLot
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(395, 297)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrDupliquerLot"
        Me.Text = "Dupliquer un lot"
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents nLotTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateCreationDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
