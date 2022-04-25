<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrModifExploi
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.cod = New System.Windows.Forms.Label
        Me.CodeExploitationTextBox = New System.Windows.Forms.TextBox
        Me.Nom1TextBox = New System.Windows.Forms.TextBox
        Me.ExploitationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.CodeExploitationLettreTextBox = New System.Windows.Forms.TextBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.lnkOptions = New System.Windows.Forms.LinkLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btBrowseBase = New System.Windows.Forms.Button
        Me.BtBrowseBasePlanType = New System.Windows.Forms.Button
        Me.CbCheminBasePlanType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.CbCheminBase = New System.Windows.Forms.ComboBox
        CType(Me.ExploitationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cod
        '
        Me.cod.AutoSize = True
        Me.cod.Location = New System.Drawing.Point(8, 11)
        Me.cod.Name = "cod"
        Me.cod.Size = New System.Drawing.Size(102, 13)
        Me.cod.TabIndex = 2
        Me.cod.Text = "Code d'exploitation :"
        '
        'CodeExploitationTextBox
        '
        Me.CodeExploitationTextBox.Location = New System.Drawing.Point(139, 8)
        Me.CodeExploitationTextBox.MaxLength = 5
        Me.CodeExploitationTextBox.Name = "CodeExploitationTextBox"
        Me.CodeExploitationTextBox.Size = New System.Drawing.Size(45, 20)
        Me.CodeExploitationTextBox.TabIndex = 3
        Me.CodeExploitationTextBox.Text = "99999"
        '
        'Nom1TextBox
        '
        Me.Nom1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExploitationBindingSource, "Nom", True))
        Me.Nom1TextBox.Location = New System.Drawing.Point(116, 34)
        Me.Nom1TextBox.MaxLength = 40
        Me.Nom1TextBox.Name = "Nom1TextBox"
        Me.Nom1TextBox.Size = New System.Drawing.Size(289, 20)
        Me.Nom1TextBox.TabIndex = 4
        '
        'ExploitationBindingSource
        '
        Me.ExploitationBindingSource.DataSource = GetType(AgrigestEDI.Exploitation)
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(265, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(338, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'CodeExploitationLettreTextBox
        '
        Me.CodeExploitationLettreTextBox.Location = New System.Drawing.Point(116, 8)
        Me.CodeExploitationLettreTextBox.MaxLength = 1
        Me.CodeExploitationLettreTextBox.Name = "CodeExploitationLettreTextBox"
        Me.CodeExploitationLettreTextBox.Size = New System.Drawing.Size(17, 20)
        Me.CodeExploitationLettreTextBox.TabIndex = 19
        Me.CodeExploitationLettreTextBox.Text = "A"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.lnkOptions)
        Me.GradientPanel1.Controls.Add(Me.GroupBox1)
        Me.GradientPanel1.Controls.Add(Me.BtBrowseBasePlanType)
        Me.GradientPanel1.Controls.Add(Me.CbCheminBasePlanType)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.cod)
        Me.GradientPanel1.Controls.Add(Me.CodeExploitationTextBox)
        Me.GradientPanel1.Controls.Add(Me.CodeExploitationLettreTextBox)
        Me.GradientPanel1.Controls.Add(Me.Nom1TextBox)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(417, 186)
        Me.GradientPanel1.TabIndex = 20
        '
        'lnkOptions
        '
        Me.lnkOptions.AutoSize = True
        Me.lnkOptions.Image = Global.AgrigestEDI.My.Resources.Resources.Collapsed
        Me.lnkOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOptions.Location = New System.Drawing.Point(12, 97)
        Me.lnkOptions.Name = "lnkOptions"
        Me.lnkOptions.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lnkOptions.Size = New System.Drawing.Size(121, 13)
        Me.lnkOptions.TabIndex = 28
        Me.lnkOptions.TabStop = True
        Me.lnkOptions.Text = "Afficher les options..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CbCheminBase)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btBrowseBase)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 64)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Fichier de données :"
        '
        'btBrowseBase
        '
        Me.btBrowseBase.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.btBrowseBase.Location = New System.Drawing.Point(363, 30)
        Me.btBrowseBase.Name = "btBrowseBase"
        Me.btBrowseBase.Size = New System.Drawing.Size(26, 23)
        Me.btBrowseBase.TabIndex = 25
        Me.btBrowseBase.UseVisualStyleBackColor = True
        '
        'BtBrowseBasePlanType
        '
        Me.BtBrowseBasePlanType.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowseBasePlanType.Location = New System.Drawing.Point(379, 60)
        Me.BtBrowseBasePlanType.Name = "BtBrowseBasePlanType"
        Me.BtBrowseBasePlanType.Size = New System.Drawing.Size(26, 23)
        Me.BtBrowseBasePlanType.TabIndex = 26
        Me.BtBrowseBasePlanType.UseVisualStyleBackColor = True
        '
        'CbCheminBasePlanType
        '
        Me.CbCheminBasePlanType.FormattingEnabled = True
        Me.CbCheminBasePlanType.Location = New System.Drawing.Point(116, 62)
        Me.CbCheminBasePlanType.Name = "CbCheminBasePlanType"
        Me.CbCheminBasePlanType.Size = New System.Drawing.Size(257, 21)
        Me.CbCheminBasePlanType.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Plan Type :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Nom :"
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 186)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(417, 45)
        Me.GradientPanel2.TabIndex = 21
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'CbCheminBase
        '
        Me.CbCheminBase.FormattingEnabled = True
        Me.CbCheminBase.Location = New System.Drawing.Point(9, 32)
        Me.CbCheminBase.Name = "CbCheminBase"
        Me.CbCheminBase.Size = New System.Drawing.Size(348, 21)
        Me.CbCheminBase.TabIndex = 26
        '
        'FrModifExploi
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(417, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrModifExploi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informations d'exploitation"
        CType(Me.ExploitationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cod As System.Windows.Forms.Label
    Friend WithEvents CodeExploitationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Nom1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CodeExploitationLettreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbCheminBasePlanType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtBrowseBasePlanType As System.Windows.Forms.Button
    Friend WithEvents btBrowseBase As System.Windows.Forms.Button
    Friend WithEvents ExploitationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lnkOptions As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CbCheminBase As System.Windows.Forms.ComboBox
End Class
