<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrFusionnerProduits
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
        Me.ButtonAnnuler = New System.Windows.Forms.Button
        Me.ButtonValider = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBoxCodeProduitFusion = New System.Windows.Forms.ComboBox
        Me.CheckBoxSupprimer = New System.Windows.Forms.CheckBox
        Me.ListBoxProduitsAFusionner = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(208, 305)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnuler.TabIndex = 13
        Me.ButtonAnnuler.Text = "Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'ButtonValider
        '
        Me.ButtonValider.Location = New System.Drawing.Point(291, 305)
        Me.ButtonValider.Name = "ButtonValider"
        Me.ButtonValider.Size = New System.Drawing.Size(75, 23)
        Me.ButtonValider.TabIndex = 12
        Me.ButtonValider.Text = "Valider"
        Me.ButtonValider.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fusionner vers le Code produit:"
        '
        'ComboBoxCodeProduitFusion
        '
        Me.ComboBoxCodeProduitFusion.FormattingEnabled = True
        Me.ComboBoxCodeProduitFusion.Location = New System.Drawing.Point(168, 173)
        Me.ComboBoxCodeProduitFusion.Name = "ComboBoxCodeProduitFusion"
        Me.ComboBoxCodeProduitFusion.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxCodeProduitFusion.TabIndex = 14
        '
        'CheckBoxSupprimer
        '
        Me.CheckBoxSupprimer.AutoSize = True
        Me.CheckBoxSupprimer.Location = New System.Drawing.Point(12, 211)
        Me.CheckBoxSupprimer.Name = "CheckBoxSupprimer"
        Me.CheckBoxSupprimer.Size = New System.Drawing.Size(215, 17)
        Me.CheckBoxSupprimer.TabIndex = 15
        Me.CheckBoxSupprimer.Text = "Supprimer le(s) produit(s) après la fusion:"
        Me.CheckBoxSupprimer.UseVisualStyleBackColor = True
        '
        'ListBoxProduitsAFusionner
        '
        Me.ListBoxProduitsAFusionner.FormattingEnabled = True
        Me.ListBoxProduitsAFusionner.Location = New System.Drawing.Point(9, 25)
        Me.ListBoxProduitsAFusionner.Name = "ListBoxProduitsAFusionner"
        Me.ListBoxProduitsAFusionner.Size = New System.Drawing.Size(357, 134)
        Me.ListBoxProduitsAFusionner.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Produit(s) à fusionner:"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(41, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(329, 55)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Cette action ne modifie que le(s) code(s) produit(s) dans toutes les tables de pr" & _
            "oduction (facture, bon de commande...). "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AgriFact.My.Resources.Resources.warning16
        Me.PictureBox1.Location = New System.Drawing.Point(12, 247)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'FrFusionnerProduits
        '
        Me.AcceptButton = Me.ButtonValider
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.ButtonAnnuler
        Me.ClientSize = New System.Drawing.Size(374, 349)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBoxProduitsAFusionner)
        Me.Controls.Add(Me.CheckBoxSupprimer)
        Me.Controls.Add(Me.ComboBoxCodeProduitFusion)
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ButtonValider)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrFusionnerProduits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fusionner produits"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents ButtonValider As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCodeProduitFusion As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxSupprimer As System.Windows.Forms.CheckBox
    Friend WithEvents ListBoxProduitsAFusionner As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
