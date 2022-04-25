<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSearchPiece
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lblPiece1 = New System.Windows.Forms.Label
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker
        Me.gpbDate = New System.Windows.Forms.GroupBox
        Me.lblDate2 = New System.Windows.Forms.Label
        Me.lblDate1 = New System.Windows.Forms.Label
        Me.gpbPiece = New System.Windows.Forms.GroupBox
        Me.lblPiece2 = New System.Windows.Forms.Label
        Me.txtPieceEnd = New System.Windows.Forms.TextBox
        Me.txtPieceStart = New System.Windows.Forms.TextBox
        Me.gpbOrdre = New System.Windows.Forms.GroupBox
        Me.rbtPiece = New System.Windows.Forms.RadioButton
        Me.rbtDate = New System.Windows.Forms.RadioButton
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.ListBoxJournaux = New System.Windows.Forms.ListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gpbDate.SuspendLayout()
        Me.gpbPiece.SuspendLayout()
        Me.gpbOrdre.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(148, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(221, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'lblPiece1
        '
        Me.lblPiece1.AutoSize = True
        Me.lblPiece1.Location = New System.Drawing.Point(6, 22)
        Me.lblPiece1.Name = "lblPiece1"
        Me.lblPiece1.Size = New System.Drawing.Size(37, 13)
        Me.lblPiece1.TabIndex = 0
        Me.lblPiece1.Text = "entre :"
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(61, 19)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(85, 20)
        Me.dtpDateStart.TabIndex = 1
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEnd.Location = New System.Drawing.Point(191, 19)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(85, 20)
        Me.dtpDateEnd.TabIndex = 3
        '
        'gpbDate
        '
        Me.gpbDate.Controls.Add(Me.dtpDateEnd)
        Me.gpbDate.Controls.Add(Me.lblDate2)
        Me.gpbDate.Controls.Add(Me.lblDate1)
        Me.gpbDate.Controls.Add(Me.dtpDateStart)
        Me.gpbDate.Location = New System.Drawing.Point(8, 69)
        Me.gpbDate.Name = "gpbDate"
        Me.gpbDate.Size = New System.Drawing.Size(283, 51)
        Me.gpbDate.TabIndex = 2
        Me.gpbDate.TabStop = False
        Me.gpbDate.Text = "Pièces dont la date est comprise"
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Location = New System.Drawing.Point(152, 23)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(33, 13)
        Me.lblDate2.TabIndex = 2
        Me.lblDate2.Text = "et le :"
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(6, 23)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(48, 13)
        Me.lblDate1.TabIndex = 0
        Me.lblDate1.Text = "entre le :"
        '
        'gpbPiece
        '
        Me.gpbPiece.Controls.Add(Me.lblPiece2)
        Me.gpbPiece.Controls.Add(Me.txtPieceEnd)
        Me.gpbPiece.Controls.Add(Me.txtPieceStart)
        Me.gpbPiece.Controls.Add(Me.lblPiece1)
        Me.gpbPiece.Location = New System.Drawing.Point(8, 12)
        Me.gpbPiece.Name = "gpbPiece"
        Me.gpbPiece.Size = New System.Drawing.Size(283, 51)
        Me.gpbPiece.TabIndex = 1
        Me.gpbPiece.TabStop = False
        Me.gpbPiece.Text = "Pièces ayant un numéro compris"
        '
        'lblPiece2
        '
        Me.lblPiece2.AutoSize = True
        Me.lblPiece2.Location = New System.Drawing.Point(145, 22)
        Me.lblPiece2.Name = "lblPiece2"
        Me.lblPiece2.Size = New System.Drawing.Size(22, 13)
        Me.lblPiece2.TabIndex = 2
        Me.lblPiece2.Text = "et :"
        '
        'txtPieceEnd
        '
        Me.txtPieceEnd.Location = New System.Drawing.Point(191, 19)
        Me.txtPieceEnd.MaxLength = 8
        Me.txtPieceEnd.Name = "txtPieceEnd"
        Me.txtPieceEnd.Size = New System.Drawing.Size(57, 20)
        Me.txtPieceEnd.TabIndex = 3
        Me.txtPieceEnd.Text = "99999999"
        '
        'txtPieceStart
        '
        Me.txtPieceStart.Location = New System.Drawing.Point(61, 19)
        Me.txtPieceStart.MaxLength = 8
        Me.txtPieceStart.Name = "txtPieceStart"
        Me.txtPieceStart.Size = New System.Drawing.Size(55, 20)
        Me.txtPieceStart.TabIndex = 1
        Me.txtPieceStart.Text = "99999999"
        '
        'gpbOrdre
        '
        Me.gpbOrdre.Controls.Add(Me.rbtPiece)
        Me.gpbOrdre.Controls.Add(Me.rbtDate)
        Me.gpbOrdre.Location = New System.Drawing.Point(8, 126)
        Me.gpbOrdre.Name = "gpbOrdre"
        Me.gpbOrdre.Size = New System.Drawing.Size(283, 58)
        Me.gpbOrdre.TabIndex = 3
        Me.gpbOrdre.TabStop = False
        Me.gpbOrdre.Text = "Ordre d'affichage"
        '
        'rbtPiece
        '
        Me.rbtPiece.AutoSize = True
        Me.rbtPiece.Location = New System.Drawing.Point(96, 19)
        Me.rbtPiece.Name = "rbtPiece"
        Me.rbtPiece.Size = New System.Drawing.Size(71, 17)
        Me.rbtPiece.TabIndex = 1
        Me.rbtPiece.Text = "Par Pièce"
        Me.rbtPiece.UseVisualStyleBackColor = True
        '
        'rbtDate
        '
        Me.rbtDate.AutoSize = True
        Me.rbtDate.Checked = True
        Me.rbtDate.Location = New System.Drawing.Point(9, 19)
        Me.rbtDate.Name = "rbtDate"
        Me.rbtDate.Size = New System.Drawing.Size(65, 17)
        Me.rbtDate.TabIndex = 0
        Me.rbtDate.TabStop = True
        Me.rbtDate.Text = "Par date"
        Me.rbtDate.UseVisualStyleBackColor = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 374)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(300, 45)
        Me.GradientPanel2.TabIndex = 15
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.GroupBox2)
        Me.GradientPanel1.Controls.Add(Me.gpbOrdre)
        Me.GradientPanel1.Controls.Add(Me.gpbDate)
        Me.GradientPanel1.Controls.Add(Me.gpbPiece)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(300, 374)
        Me.GradientPanel1.TabIndex = 14
        '
        'ListBoxJournaux
        '
        Me.ListBoxJournaux.FormattingEnabled = True
        Me.ListBoxJournaux.Location = New System.Drawing.Point(6, 19)
        Me.ListBoxJournaux.Name = "ListBoxJournaux"
        Me.ListBoxJournaux.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxJournaux.Size = New System.Drawing.Size(270, 134)
        Me.ListBoxJournaux.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListBoxJournaux)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(283, 170)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rechercher dans"
        '
        'FrSearchPiece
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(300, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSearchPiece"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recherche de pièces"
        Me.gpbDate.ResumeLayout(False)
        Me.gpbDate.PerformLayout()
        Me.gpbPiece.ResumeLayout(False)
        Me.gpbPiece.PerformLayout()
        Me.gpbOrdre.ResumeLayout(False)
        Me.gpbOrdre.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblPiece1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents gpbDate As System.Windows.Forms.GroupBox
    Friend WithEvents gpbPiece As System.Windows.Forms.GroupBox
    Friend WithEvents txtPieceEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtPieceStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPiece2 As System.Windows.Forms.Label
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents gpbOrdre As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPiece As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDate As System.Windows.Forms.RadioButton
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ListBoxJournaux As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
