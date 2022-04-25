<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixPrems
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.Cancel = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.BtRestaurer = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtImport = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtNew = New Ascend.Windows.Forms.GradientNavigationButton
        Me.btDemo = New Ascend.Windows.Forms.GradientNavigationButton
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.PasswordLabel.Location = New System.Drawing.Point(12, 9)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(375, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Aucun dossier n'est paramétré, que souhaitez vous-faire ?"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(308, 7)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(70, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "Annuler"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel1.Controls.Add(Me.Cancel)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel1.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel1.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 238)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel1.Size = New System.Drawing.Size(390, 42)
        Me.GradientPanel1.TabIndex = 6
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.BtRestaurer)
        Me.GradientPanel2.Controls.Add(Me.BtImport)
        Me.GradientPanel2.Controls.Add(Me.BtNew)
        Me.GradientPanel2.Controls.Add(Me.btDemo)
        Me.GradientPanel2.Controls.Add(Me.PasswordLabel)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel2.GradientLowColor = System.Drawing.Color.White
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Flat
        Me.GradientPanel2.Size = New System.Drawing.Size(390, 238)
        Me.GradientPanel2.TabIndex = 7
        '
        'BtRestaurer
        '
        Me.BtRestaurer.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtRestaurer.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtRestaurer.ActiveOnClick = False
        Me.BtRestaurer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtRestaurer.Border = New Ascend.Border(0)
        Me.BtRestaurer.GradientHighColor = System.Drawing.Color.White
        Me.BtRestaurer.GradientLowColor = System.Drawing.Color.White
        Me.BtRestaurer.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtRestaurer.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.BtRestaurer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtRestaurer.Location = New System.Drawing.Point(15, 182)
        Me.BtRestaurer.Name = "BtRestaurer"
        Me.BtRestaurer.ShowBorderOnHighlight = True
        Me.BtRestaurer.Size = New System.Drawing.Size(363, 43)
        Me.BtRestaurer.StayActiveAfterClick = False
        Me.BtRestaurer.TabIndex = 7
        Me.BtRestaurer.Text = "Restaurer une sauvegarde AgrigestEDI"
        '
        'BtImport
        '
        Me.BtImport.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtImport.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtImport.ActiveOnClick = False
        Me.BtImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImport.Border = New Ascend.Border(0)
        Me.BtImport.GradientHighColor = System.Drawing.Color.White
        Me.BtImport.GradientLowColor = System.Drawing.Color.White
        Me.BtImport.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtImport.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.BtImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtImport.Location = New System.Drawing.Point(15, 133)
        Me.BtImport.Name = "BtImport"
        Me.BtImport.ShowBorderOnHighlight = True
        Me.BtImport.Size = New System.Drawing.Size(363, 43)
        Me.BtImport.StayActiveAfterClick = False
        Me.BtImport.TabIndex = 6
        Me.BtImport.Text = "Importer des écritures depuis IsaCompta"
        '
        'BtNew
        '
        Me.BtNew.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtNew.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtNew.ActiveOnClick = False
        Me.BtNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtNew.Border = New Ascend.Border(0)
        Me.BtNew.GradientHighColor = System.Drawing.Color.White
        Me.BtNew.GradientLowColor = System.Drawing.Color.White
        Me.BtNew.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtNew.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtNew.Location = New System.Drawing.Point(15, 84)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.ShowBorderOnHighlight = True
        Me.BtNew.Size = New System.Drawing.Size(363, 43)
        Me.BtNew.StayActiveAfterClick = False
        Me.BtNew.TabIndex = 5
        Me.BtNew.Text = "Créer un dossier vide"
        '
        'btDemo
        '
        Me.btDemo.ActiveGradientHighColor = System.Drawing.Color.White
        Me.btDemo.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btDemo.ActiveOnClick = False
        Me.btDemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDemo.Border = New Ascend.Border(0)
        Me.btDemo.GradientHighColor = System.Drawing.Color.White
        Me.btDemo.GradientLowColor = System.Drawing.Color.White
        Me.btDemo.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btDemo.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.btDemo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btDemo.Location = New System.Drawing.Point(15, 35)
        Me.btDemo.Name = "btDemo"
        Me.btDemo.ShowBorderOnHighlight = True
        Me.btDemo.Size = New System.Drawing.Size(363, 43)
        Me.btDemo.StayActiveAfterClick = False
        Me.btDemo.TabIndex = 4
        Me.btDemo.Text = "Consulter le dossier de démonstration"
        '
        'FrChoixPrems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(390, 280)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrChoixPrems"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Première execution"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents btDemo As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtImport As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtNew As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtRestaurer As Ascend.Windows.Forms.GradientNavigationButton

End Class
