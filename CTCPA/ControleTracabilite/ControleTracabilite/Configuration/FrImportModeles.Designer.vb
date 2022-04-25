<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrImportModeles
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
        Dim RepPDFLabel As System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CbAction = New System.Windows.Forms.ComboBox
        Me.BtBrowseFile = New System.Windows.Forms.Button
        Me.CheminFichierTextBox = New System.Windows.Forms.TextBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.nudSkip = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        RepPDFLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.nudSkip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepPDFLabel
        '
        RepPDFLabel.AutoSize = True
        RepPDFLabel.Location = New System.Drawing.Point(9, 11)
        RepPDFLabel.Name = "RepPDFLabel"
        RepPDFLabel.Size = New System.Drawing.Size(90, 13)
        RepPDFLabel.TabIndex = 1
        RepPDFLabel.Text = "Fichier à importer:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.nudSkip)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.CbAction)
        Me.GradientPanel1.Controls.Add(Me.BtBrowseFile)
        Me.GradientPanel1.Controls.Add(RepPDFLabel)
        Me.GradientPanel1.Controls.Add(Me.CheminFichierTextBox)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(347, 138)
        Me.GradientPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Action :"
        '
        'CbAction
        '
        Me.CbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAction.FormattingEnabled = True
        Me.CbAction.Location = New System.Drawing.Point(105, 35)
        Me.CbAction.Name = "CbAction"
        Me.CbAction.Size = New System.Drawing.Size(229, 21)
        Me.CbAction.TabIndex = 6
        '
        'BtBrowseFile
        '
        Me.BtBrowseFile.Image = Global.ControleTracabilite.My.Resources.Resources.open
        Me.BtBrowseFile.Location = New System.Drawing.Point(303, 6)
        Me.BtBrowseFile.Name = "BtBrowseFile"
        Me.BtBrowseFile.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowseFile.TabIndex = 4
        Me.BtBrowseFile.UseVisualStyleBackColor = True
        '
        'CheminFichierTextBox
        '
        Me.CheminFichierTextBox.Location = New System.Drawing.Point(105, 8)
        Me.CheminFichierTextBox.Name = "CheminFichierTextBox"
        Me.CheminFichierTextBox.Size = New System.Drawing.Size(192, 20)
        Me.CheminFichierTextBox.TabIndex = 2
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 93)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(347, 45)
        Me.GradientPanel2.TabIndex = 20
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(268, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(195, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'nudSkip
        '
        Me.nudSkip.Location = New System.Drawing.Point(105, 62)
        Me.nudSkip.Name = "nudSkip"
        Me.nudSkip.Size = New System.Drawing.Size(36, 20)
        Me.nudSkip.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Ne pas importer les"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(141, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "premières lignes"
        '
        'FrImportModeles
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(347, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrImportModeles"
        Me.Text = "Importer des modèles de contrôle"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.nudSkip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtBrowseFile As System.Windows.Forms.Button
    Friend WithEvents CheminFichierTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbAction As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudSkip As System.Windows.Forms.NumericUpDown
End Class
