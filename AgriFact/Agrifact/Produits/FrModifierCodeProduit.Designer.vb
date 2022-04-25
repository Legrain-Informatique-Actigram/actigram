<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrModifierCodeProduit
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxAncienCodeProduit = New System.Windows.Forms.TextBox
        Me.TextBoxNouveauCodeProduit = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonValider = New System.Windows.Forms.Button
        Me.ButtonAnnuler = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ancien code produit:"
        '
        'TextBoxAncienCodeProduit
        '
        Me.TextBoxAncienCodeProduit.Enabled = False
        Me.TextBoxAncienCodeProduit.Location = New System.Drawing.Point(152, 22)
        Me.TextBoxAncienCodeProduit.Name = "TextBoxAncienCodeProduit"
        Me.TextBoxAncienCodeProduit.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxAncienCodeProduit.TabIndex = 1
        '
        'TextBoxNouveauCodeProduit
        '
        Me.TextBoxNouveauCodeProduit.Location = New System.Drawing.Point(152, 48)
        Me.TextBoxNouveauCodeProduit.Name = "TextBoxNouveauCodeProduit"
        Me.TextBoxNouveauCodeProduit.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxNouveauCodeProduit.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nouveau code produit:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AgriFact.My.Resources.Resources.warning16
        Me.PictureBox1.Location = New System.Drawing.Point(15, 91)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(44, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(329, 55)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cette action modifie également le code produit dans toutes les tables de producti" & _
            "on (facture, bon de commande...) dans lesquelles le code est utilisé. "
        '
        'ButtonValider
        '
        Me.ButtonValider.Location = New System.Drawing.Point(289, 149)
        Me.ButtonValider.Name = "ButtonValider"
        Me.ButtonValider.Size = New System.Drawing.Size(75, 23)
        Me.ButtonValider.TabIndex = 6
        Me.ButtonValider.Text = "Valider"
        Me.ButtonValider.UseVisualStyleBackColor = True
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(200, 149)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnuler.TabIndex = 7
        Me.ButtonAnnuler.Text = "Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'FrModifierCodeProduit
        '
        Me.AcceptButton = Me.ButtonValider
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.ButtonAnnuler
        Me.ClientSize = New System.Drawing.Size(387, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ButtonValider)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBoxNouveauCodeProduit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxAncienCodeProduit)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrModifierCodeProduit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modifier un code produit"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAncienCodeProduit As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNouveauCodeProduit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonValider As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
End Class
