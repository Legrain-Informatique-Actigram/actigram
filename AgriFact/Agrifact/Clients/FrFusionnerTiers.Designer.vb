<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrFusionnerTiers
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListBoxTiersAFusionner = New System.Windows.Forms.ListBox
        Me.CheckBoxSupprimer = New System.Windows.Forms.CheckBox
        Me.ComboBoxTiersFusion = New System.Windows.Forms.ComboBox
        Me.ButtonAnnuler = New System.Windows.Forms.Button
        Me.ButtonValider = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(44, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(329, 55)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Cette action ne modifie que la référence des tiers dans toutes les tables de prod" & _
            "uction (facture, bon de commande...). "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AgriFact.My.Resources.Resources.warning16
        Me.PictureBox1.Location = New System.Drawing.Point(15, 246)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Tier(s) à fusionner:"
        '
        'ListBoxTiersAFusionner
        '
        Me.ListBoxTiersAFusionner.FormattingEnabled = True
        Me.ListBoxTiersAFusionner.Location = New System.Drawing.Point(12, 24)
        Me.ListBoxTiersAFusionner.Name = "ListBoxTiersAFusionner"
        Me.ListBoxTiersAFusionner.Size = New System.Drawing.Size(357, 134)
        Me.ListBoxTiersAFusionner.TabIndex = 25
        '
        'CheckBoxSupprimer
        '
        Me.CheckBoxSupprimer.AutoSize = True
        Me.CheckBoxSupprimer.Location = New System.Drawing.Point(15, 210)
        Me.CheckBoxSupprimer.Name = "CheckBoxSupprimer"
        Me.CheckBoxSupprimer.Size = New System.Drawing.Size(197, 17)
        Me.CheckBoxSupprimer.TabIndex = 24
        Me.CheckBoxSupprimer.Text = "Supprimer le(s) tier(s) après la fusion:"
        Me.CheckBoxSupprimer.UseVisualStyleBackColor = True
        '
        'ComboBoxTiersFusion
        '
        Me.ComboBoxTiersFusion.FormattingEnabled = True
        Me.ComboBoxTiersFusion.Location = New System.Drawing.Point(171, 172)
        Me.ComboBoxTiersFusion.Name = "ComboBoxTiersFusion"
        Me.ComboBoxTiersFusion.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxTiersFusion.TabIndex = 23
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(211, 304)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnuler.TabIndex = 22
        Me.ButtonAnnuler.Text = "Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'ButtonValider
        '
        Me.ButtonValider.Location = New System.Drawing.Point(294, 304)
        Me.ButtonValider.Name = "ButtonValider"
        Me.ButtonValider.Size = New System.Drawing.Size(75, 23)
        Me.ButtonValider.TabIndex = 21
        Me.ButtonValider.Text = "Valider"
        Me.ButtonValider.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fusionner vers le tier:"
        '
        'FrFusionnerTiers
        '
        Me.AcceptButton = Me.ButtonValider
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.ButtonAnnuler
        Me.ClientSize = New System.Drawing.Size(381, 343)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBoxTiersAFusionner)
        Me.Controls.Add(Me.CheckBoxSupprimer)
        Me.Controls.Add(Me.ComboBoxTiersFusion)
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ButtonValider)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrFusionnerTiers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fusionner tiers"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBoxTiersAFusionner As System.Windows.Forms.ListBox
    Friend WithEvents CheckBoxSupprimer As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxTiersFusion As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents ButtonValider As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
