<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ConnectionStringBuilderWrapper2 As ImportEntreprisesAgrifact.ConnectionStringBuilderWrapper = New ImportEntreprisesAgrifact.ConnectionStringBuilderWrapper
        Me.btParcourir = New System.Windows.Forms.Button
        Me.txtFic = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btImporter = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.pgBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.nudIgnoreLines = New System.Windows.Forms.NumericUpDown
        Me.BtPreview = New System.Windows.Forms.Button
        Me.BtTestData = New System.Windows.Forms.Button
        Me.SqlConnectionConfig1 = New ImportEntreprisesAgrifact.SqlConnectionConfig
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudIgnoreLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btParcourir
        '
        Me.btParcourir.Location = New System.Drawing.Point(303, 9)
        Me.btParcourir.Name = "btParcourir"
        Me.btParcourir.Size = New System.Drawing.Size(27, 23)
        Me.btParcourir.TabIndex = 1
        Me.btParcourir.Text = "..."
        Me.btParcourir.UseVisualStyleBackColor = True
        '
        'txtFic
        '
        Me.txtFic.Location = New System.Drawing.Point(12, 12)
        Me.txtFic.Name = "txtFic"
        Me.txtFic.Size = New System.Drawing.Size(285, 20)
        Me.txtFic.TabIndex = 0
        '
        'btImporter
        '
        Me.btImporter.Location = New System.Drawing.Point(303, 236)
        Me.btImporter.Name = "btImporter"
        Me.btImporter.Size = New System.Drawing.Size(75, 23)
        Me.btImporter.TabIndex = 3
        Me.btImporter.Text = "Importer"
        Me.btImporter.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 170)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connexion Agrifact"
        '
        'cbType
        '
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(104, 41)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(193, 21)
        Me.cbType.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Type de donnée"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStatus, Me.pgBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 271)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(389, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStatus
        '
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(46, 17)
        Me.lbStatus.Text = "lbStatus"
        '
        'pgBar
        '
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(100, 16)
        Me.pgBar.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(103, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Ignorer les  xxxxxx  premières lignes"
        '
        'nudIgnoreLines
        '
        Me.nudIgnoreLines.Location = New System.Drawing.Point(158, 68)
        Me.nudIgnoreLines.Name = "nudIgnoreLines"
        Me.nudIgnoreLines.Size = New System.Drawing.Size(35, 20)
        Me.nudIgnoreLines.TabIndex = 8
        '
        'BtPreview
        '
        Me.BtPreview.Location = New System.Drawing.Point(336, 10)
        Me.BtPreview.Name = "BtPreview"
        Me.BtPreview.Size = New System.Drawing.Size(42, 23)
        Me.BtPreview.TabIndex = 9
        Me.BtPreview.Text = "Voir"
        Me.BtPreview.UseVisualStyleBackColor = True
        '
        'BtTestData
        '
        Me.BtTestData.Location = New System.Drawing.Point(303, 39)
        Me.BtTestData.Name = "BtTestData"
        Me.BtTestData.Size = New System.Drawing.Size(75, 23)
        Me.BtTestData.TabIndex = 10
        Me.BtTestData.Text = "Vérifier"
        Me.BtTestData.UseVisualStyleBackColor = True
        '
        'SqlConnectionConfig1
        '
        ConnectionStringBuilderWrapper2.ConnectionString = ""
        ConnectionStringBuilderWrapper2.Database = ""
        ConnectionStringBuilderWrapper2.Login = ""
        ConnectionStringBuilderWrapper2.Password = ""
        ConnectionStringBuilderWrapper2.Server = ""
        Me.SqlConnectionConfig1.ConnectionStringBuilder = ConnectionStringBuilderWrapper2
        Me.SqlConnectionConfig1.Location = New System.Drawing.Point(6, 19)
        Me.SqlConnectionConfig1.Name = "SqlConnectionConfig1"
        Me.SqlConnectionConfig1.Size = New System.Drawing.Size(254, 144)
        Me.SqlConnectionConfig1.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 293)
        Me.Controls.Add(Me.BtTestData)
        Me.Controls.Add(Me.BtPreview)
        Me.Controls.Add(Me.nudIgnoreLines)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btImporter)
        Me.Controls.Add(Me.txtFic)
        Me.Controls.Add(Me.btParcourir)
        Me.Name = "Form1"
        Me.Text = "Importation"
        Me.GroupBox1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.nudIgnoreLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btParcourir As System.Windows.Forms.Button
    Friend WithEvents txtFic As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btImporter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pgBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudIgnoreLines As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtPreview As System.Windows.Forms.Button
    Friend WithEvents BtTestData As System.Windows.Forms.Button
    Friend WithEvents SqlConnectionConfig1 As ImportEntreprisesAgrifact.SqlConnectionConfig

End Class
