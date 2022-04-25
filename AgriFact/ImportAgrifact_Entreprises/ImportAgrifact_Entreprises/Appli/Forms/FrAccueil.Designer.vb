<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAccueil
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
        Dim ConnectionStringBuilderWrapper1 As ImportAgrifact_Entreprises.Utilitaires.ConnectionStringBuilderWrapper = New ImportAgrifact_Entreprises.Utilitaires.ConnectionStringBuilderWrapper
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAccueil))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig1 = New ImportAgrifact_Entreprises.SqlConnectionConfig
        Me.ButtonLancerImport = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.OpenFileDialogChoixFichierExcel = New System.Windows.Forms.OpenFileDialog
        Me.CheckBoxVider = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig1)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 166)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base de données à mettre à jour"
        '
        'SqlConnectionConfig1
        '
        ConnectionStringBuilderWrapper1.ConnectionString = ""
        ConnectionStringBuilderWrapper1.Database = ""
        ConnectionStringBuilderWrapper1.Login = ""
        ConnectionStringBuilderWrapper1.Password = ""
        ConnectionStringBuilderWrapper1.Server = ""
        Me.SqlConnectionConfig1.ConnectionStringBuilder = ConnectionStringBuilderWrapper1
        Me.SqlConnectionConfig1.Location = New System.Drawing.Point(6, 19)
        Me.SqlConnectionConfig1.Name = "SqlConnectionConfig1"
        Me.SqlConnectionConfig1.Size = New System.Drawing.Size(254, 144)
        Me.SqlConnectionConfig1.TabIndex = 0
        '
        'ButtonLancerImport
        '
        Me.ButtonLancerImport.Location = New System.Drawing.Point(117, 181)
        Me.ButtonLancerImport.Name = "ButtonLancerImport"
        Me.ButtonLancerImport.Size = New System.Drawing.Size(97, 23)
        Me.ButtonLancerImport.TabIndex = 2
        Me.ButtonLancerImport.Text = "Lancer l'import"
        Me.ButtonLancerImport.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(32, 252)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(268, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'OpenFileDialogChoixFichierExcel
        '
        Me.OpenFileDialogChoixFichierExcel.FileName = "OpenFileDialog1"
        '
        'CheckBoxVider
        '
        Me.CheckBoxVider.AutoSize = True
        Me.CheckBoxVider.Location = New System.Drawing.Point(32, 229)
        Me.CheckBoxVider.Name = "CheckBoxVider"
        Me.CheckBoxVider.Size = New System.Drawing.Size(260, 17)
        Me.CheckBoxVider.TabIndex = 5
        Me.CheckBoxVider.Text = "Vider les tables Entreprise et TelephoneEntreprise"
        Me.CheckBoxVider.UseVisualStyleBackColor = True
        '
        'FrAccueil
        '
        Me.AcceptButton = Me.ButtonLancerImport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 287)
        Me.Controls.Add(Me.CheckBoxVider)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonLancerImport)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrAccueil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Entreprises Agrifact"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SqlConnectionConfig1 As ImportAgrifact_Entreprises.SqlConnectionConfig
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonLancerImport As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialogChoixFichierExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CheckBoxVider As System.Windows.Forms.CheckBox
End Class
