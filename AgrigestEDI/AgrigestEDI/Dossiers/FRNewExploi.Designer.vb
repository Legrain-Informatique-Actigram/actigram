<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrNewExploi
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
        Me.DossiersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDbDonnees = New AgrigestEDI.dbDonneesDataSet
        Me.Nom1TextBox = New System.Windows.Forms.TextBox
        Me.ExploitationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Nom2TextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DebutExerciceDtp = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.FinExerciceDtp = New System.Windows.Forms.DateTimePicker
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.DossiersTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
        Me.ExploitationsTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
        Me.CodeExploitationLettreTextBox = New System.Windows.Forms.TextBox
        Me.PiecesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
        Me.PiecesAllTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtJournal = New System.Windows.Forms.RadioButton
        Me.rbtGlobal = New System.Windows.Forms.RadioButton
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDbDonnees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExploitationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DossiersBindingSource
        '
        Me.DossiersBindingSource.DataMember = "Dossiers"
        Me.DossiersBindingSource.DataSource = Me.dsDbDonnees
        '
        'dsDbDonnees
        '
        Me.dsDbDonnees.DataSetName = "dbDonneesDataSet"
        Me.dsDbDonnees.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Nom1TextBox
        '
        Me.Nom1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExploitationsBindingSource, "ENom1", True))
        Me.Nom1TextBox.Location = New System.Drawing.Point(11, 34)
        Me.Nom1TextBox.MaxLength = 40
        Me.Nom1TextBox.Name = "Nom1TextBox"
        Me.Nom1TextBox.Size = New System.Drawing.Size(289, 20)
        Me.Nom1TextBox.TabIndex = 4
        '
        'ExploitationsBindingSource
        '
        Me.ExploitationsBindingSource.DataMember = "Exploitations"
        Me.ExploitationsBindingSource.DataSource = Me.dsDbDonnees
        '
        'Nom2TextBox
        '
        Me.Nom2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExploitationsBindingSource, "ENom2", True))
        Me.Nom2TextBox.Location = New System.Drawing.Point(11, 60)
        Me.Nom2TextBox.MaxLength = 20
        Me.Nom2TextBox.Name = "Nom2TextBox"
        Me.Nom2TextBox.Size = New System.Drawing.Size(289, 20)
        Me.Nom2TextBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Exercice du:"
        '
        'DebutExerciceDtp
        '
        Me.DebutExerciceDtp.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DossiersBindingSource, "DDtDebEx", True))
        Me.DebutExerciceDtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DebutExerciceDtp.Location = New System.Drawing.Point(85, 86)
        Me.DebutExerciceDtp.Name = "DebutExerciceDtp"
        Me.DebutExerciceDtp.Size = New System.Drawing.Size(91, 20)
        Me.DebutExerciceDtp.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "au:"
        '
        'FinExerciceDtp
        '
        Me.FinExerciceDtp.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DossiersBindingSource, "DDtFinEx", True))
        Me.FinExerciceDtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FinExerciceDtp.Location = New System.Drawing.Point(215, 86)
        Me.FinExerciceDtp.Name = "FinExerciceDtp"
        Me.FinExerciceDtp.Size = New System.Drawing.Size(85, 20)
        Me.FinExerciceDtp.TabIndex = 11
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(159, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(232, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'ExploitationsTableAdapter
        '
        Me.ExploitationsTableAdapter.ClearBeforeFill = True
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
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'PiecesAllTableAdapter
        '
        Me.PiecesAllTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.GroupBox1)
        Me.GradientPanel1.Controls.Add(Me.cod)
        Me.GradientPanel1.Controls.Add(Me.CodeExploitationTextBox)
        Me.GradientPanel1.Controls.Add(Me.CodeExploitationLettreTextBox)
        Me.GradientPanel1.Controls.Add(Me.Nom1TextBox)
        Me.GradientPanel1.Controls.Add(Me.FinExerciceDtp)
        Me.GradientPanel1.Controls.Add(Me.Nom2TextBox)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.DebutExerciceDtp)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(311, 188)
        Me.GradientPanel1.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtJournal)
        Me.GroupBox1.Controls.Add(Me.rbtGlobal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 67)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gestion de l'implémentation des numéros de pièce"
        '
        'rbtJournal
        '
        Me.rbtJournal.AutoSize = True
        Me.rbtJournal.Location = New System.Drawing.Point(6, 42)
        Me.rbtJournal.Name = "rbtJournal"
        Me.rbtJournal.Size = New System.Drawing.Size(147, 17)
        Me.rbtJournal.TabIndex = 2
        Me.rbtJournal.Text = "Incrémentation par journal"
        Me.rbtJournal.UseVisualStyleBackColor = True
        '
        'rbtGlobal
        '
        Me.rbtGlobal.AutoSize = True
        Me.rbtGlobal.Checked = True
        Me.rbtGlobal.Location = New System.Drawing.Point(6, 19)
        Me.rbtGlobal.Name = "rbtGlobal"
        Me.rbtGlobal.Size = New System.Drawing.Size(132, 17)
        Me.rbtGlobal.TabIndex = 0
        Me.rbtGlobal.TabStop = True
        Me.rbtGlobal.Text = "Incrémentation globale"
        Me.rbtGlobal.UseVisualStyleBackColor = True
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 188)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(311, 45)
        Me.GradientPanel2.TabIndex = 21
        '
        'JournalTableAdapter
        '
        Me.JournalTableAdapter.ClearBeforeFill = True
        '
        'FrNewExploi
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(311, 233)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrNewExploi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramétrage de l'exercice"
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDbDonnees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExploitationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Nom2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DebutExerciceDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FinExerciceDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents dsDbDonnees As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.DossiersTableAdapter
    Friend WithEvents DossiersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExploitationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExploitationsTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CodeExploitationLettreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
    Friend WithEvents PiecesAllTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtJournal As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGlobal As System.Windows.Forms.RadioButton
End Class
