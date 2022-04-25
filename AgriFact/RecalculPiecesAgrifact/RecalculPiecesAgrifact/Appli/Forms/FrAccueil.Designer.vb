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
        Dim ConnectionStringBuilderWrapper1 As RecalculPiecesAgrifact.Utilitaires.ConnectionStringBuilderWrapper = New RecalculPiecesAgrifact.Utilitaires.ConnectionStringBuilderWrapper
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAccueil))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfigAgrifact = New RecalculPiecesAgrifact.SqlConnectionConfig
        Me.ButtonLancerRecalcul = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelStatut = New System.Windows.Forms.Label
        Me.TextBoxCompteRendu = New System.Windows.Forms.TextBox
        Me.GroupBoxPiecesARecalculer = New System.Windows.Forms.GroupBox
        Me.CheckBoxDevisV = New System.Windows.Forms.CheckBox
        Me.CheckBoxBLV = New System.Windows.Forms.CheckBox
        Me.CheckBoxBCV = New System.Windows.Forms.CheckBox
        Me.CheckBoxFacturesV = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxPiecesARecalculer.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfigAgrifact)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base de données à mettre à jour"
        '
        'SqlConnectionConfigAgrifact
        '
        ConnectionStringBuilderWrapper1.ConnectionString = ""
        ConnectionStringBuilderWrapper1.Database = ""
        ConnectionStringBuilderWrapper1.Login = ""
        ConnectionStringBuilderWrapper1.Password = ""
        ConnectionStringBuilderWrapper1.Server = ""
        Me.SqlConnectionConfigAgrifact.ConnectionStringBuilder = ConnectionStringBuilderWrapper1
        Me.SqlConnectionConfigAgrifact.Location = New System.Drawing.Point(6, 19)
        Me.SqlConnectionConfigAgrifact.Name = "SqlConnectionConfigAgrifact"
        Me.SqlConnectionConfigAgrifact.Size = New System.Drawing.Size(254, 150)
        Me.SqlConnectionConfigAgrifact.TabIndex = 0
        '
        'ButtonLancerRecalcul
        '
        Me.ButtonLancerRecalcul.Location = New System.Drawing.Point(194, 197)
        Me.ButtonLancerRecalcul.Name = "ButtonLancerRecalcul"
        Me.ButtonLancerRecalcul.Size = New System.Drawing.Size(111, 23)
        Me.ButtonLancerRecalcul.TabIndex = 1
        Me.ButtonLancerRecalcul.Text = "Lancer le recalcul"
        Me.ButtonLancerRecalcul.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 25)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(482, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelStatut)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Location = New System.Drawing.Point(12, 507)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 51)
        Me.Panel1.TabIndex = 5
        '
        'LabelStatut
        '
        Me.LabelStatut.AutoSize = True
        Me.LabelStatut.Location = New System.Drawing.Point(3, 9)
        Me.LabelStatut.Name = "LabelStatut"
        Me.LabelStatut.Size = New System.Drawing.Size(61, 13)
        Me.LabelStatut.TabIndex = 1
        Me.LabelStatut.Text = "LabelStatut"
        '
        'TextBoxCompteRendu
        '
        Me.TextBoxCompteRendu.Location = New System.Drawing.Point(12, 226)
        Me.TextBoxCompteRendu.Multiline = True
        Me.TextBoxCompteRendu.Name = "TextBoxCompteRendu"
        Me.TextBoxCompteRendu.Size = New System.Drawing.Size(491, 275)
        Me.TextBoxCompteRendu.TabIndex = 7
        '
        'GroupBoxPiecesARecalculer
        '
        Me.GroupBoxPiecesARecalculer.Controls.Add(Me.CheckBoxDevisV)
        Me.GroupBoxPiecesARecalculer.Controls.Add(Me.CheckBoxBLV)
        Me.GroupBoxPiecesARecalculer.Controls.Add(Me.CheckBoxBCV)
        Me.GroupBoxPiecesARecalculer.Controls.Add(Me.CheckBoxFacturesV)
        Me.GroupBoxPiecesARecalculer.Location = New System.Drawing.Point(300, 12)
        Me.GroupBoxPiecesARecalculer.Name = "GroupBoxPiecesARecalculer"
        Me.GroupBoxPiecesARecalculer.Size = New System.Drawing.Size(200, 137)
        Me.GroupBoxPiecesARecalculer.TabIndex = 8
        Me.GroupBoxPiecesARecalculer.TabStop = False
        Me.GroupBoxPiecesARecalculer.Text = "Pièces à recalculer"
        '
        'CheckBoxDevisV
        '
        Me.CheckBoxDevisV.AutoSize = True
        Me.CheckBoxDevisV.Location = New System.Drawing.Point(6, 29)
        Me.CheckBoxDevisV.Name = "CheckBoxDevisV"
        Me.CheckBoxDevisV.Size = New System.Drawing.Size(89, 17)
        Me.CheckBoxDevisV.TabIndex = 3
        Me.CheckBoxDevisV.Text = "Devis (vente)"
        Me.CheckBoxDevisV.UseVisualStyleBackColor = True
        '
        'CheckBoxBLV
        '
        Me.CheckBoxBLV.AutoSize = True
        Me.CheckBoxBLV.Location = New System.Drawing.Point(6, 75)
        Me.CheckBoxBLV.Name = "CheckBoxBLV"
        Me.CheckBoxBLV.Size = New System.Drawing.Size(142, 17)
        Me.CheckBoxBLV.TabIndex = 2
        Me.CheckBoxBLV.Text = "Bons de livraison (vente)"
        Me.CheckBoxBLV.UseVisualStyleBackColor = True
        '
        'CheckBoxBCV
        '
        Me.CheckBoxBCV.AutoSize = True
        Me.CheckBoxBCV.Location = New System.Drawing.Point(6, 52)
        Me.CheckBoxBCV.Name = "CheckBoxBCV"
        Me.CheckBoxBCV.Size = New System.Drawing.Size(156, 17)
        Me.CheckBoxBCV.TabIndex = 1
        Me.CheckBoxBCV.Text = "Bons de commande (vente)"
        Me.CheckBoxBCV.UseVisualStyleBackColor = True
        '
        'CheckBoxFacturesV
        '
        Me.CheckBoxFacturesV.AutoSize = True
        Me.CheckBoxFacturesV.Location = New System.Drawing.Point(6, 98)
        Me.CheckBoxFacturesV.Name = "CheckBoxFacturesV"
        Me.CheckBoxFacturesV.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxFacturesV.TabIndex = 0
        Me.CheckBoxFacturesV.Text = "Factures (vente)"
        Me.CheckBoxFacturesV.UseVisualStyleBackColor = True
        '
        'FrAccueil
        '
        Me.AcceptButton = Me.ButtonLancerRecalcul
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 565)
        Me.Controls.Add(Me.GroupBoxPiecesARecalculer)
        Me.Controls.Add(Me.TextBoxCompteRendu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonLancerRecalcul)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrAccueil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recalcul pièces Agrifact"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBoxPiecesARecalculer.ResumeLayout(False)
        Me.GroupBoxPiecesARecalculer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfigAgrifact As RecalculPiecesAgrifact.SqlConnectionConfig
    Friend WithEvents ButtonLancerRecalcul As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxCompteRendu As System.Windows.Forms.TextBox
    Friend WithEvents LabelStatut As System.Windows.Forms.Label
    Friend WithEvents GroupBoxPiecesARecalculer As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxDevisV As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBLV As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBCV As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFacturesV As System.Windows.Forms.CheckBox

End Class
