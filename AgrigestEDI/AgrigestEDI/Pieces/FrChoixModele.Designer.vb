<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixModele
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
        Dim DDossierLabel As System.Windows.Forms.Label
        Me.cmdSuppr = New System.Windows.Forms.Button
        Me.cmdNew = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.cmdModif = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.cboModele = New System.Windows.Forms.ListBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.ModLignesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ModLignesTableAdapter
        DDossierLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DDossierLabel
        '
        DDossierLabel.AutoSize = True
        DDossierLabel.Location = New System.Drawing.Point(12, 9)
        DDossierLabel.Name = "DDossierLabel"
        DDossierLabel.Size = New System.Drawing.Size(170, 13)
        DDossierLabel.TabIndex = 2
        DDossierLabel.Text = "Sélectionnez le modèle à charger :"
        '
        'cmdSuppr
        '
        Me.cmdSuppr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSuppr.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.cmdSuppr.Location = New System.Drawing.Point(204, 227)
        Me.cmdSuppr.Name = "cmdSuppr"
        Me.cmdSuppr.Size = New System.Drawing.Size(97, 23)
        Me.cmdSuppr.TabIndex = 6
        Me.cmdSuppr.Text = "Suppression"
        Me.cmdSuppr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSuppr.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.cmdNew.Location = New System.Drawing.Point(12, 227)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(84, 23)
        Me.cmdNew.TabIndex = 4
        Me.cmdNew.Text = "Création"
        Me.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(234, 7)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Fermer"
        '
        'cmdModif
        '
        Me.cmdModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdModif.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.cmdModif.Location = New System.Drawing.Point(102, 227)
        Me.cmdModif.Name = "cmdModif"
        Me.cmdModif.Size = New System.Drawing.Size(95, 23)
        Me.cmdModif.TabIndex = 11
        Me.cmdModif.Text = "Modification"
        Me.cmdModif.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdModif.UseVisualStyleBackColor = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.cboModele)
        Me.GradientPanel1.Controls.Add(DDossierLabel)
        Me.GradientPanel1.Controls.Add(Me.cmdModif)
        Me.GradientPanel1.Controls.Add(Me.cmdNew)
        Me.GradientPanel1.Controls.Add(Me.cmdSuppr)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(316, 258)
        Me.GradientPanel1.TabIndex = 12
        '
        'cboModele
        '
        Me.cboModele.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboModele.FormattingEnabled = True
        Me.cboModele.Location = New System.Drawing.Point(12, 25)
        Me.cboModele.Name = "cboModele"
        Me.cboModele.Size = New System.Drawing.Size(292, 186)
        Me.cboModele.TabIndex = 12
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 258)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(316, 42)
        Me.GradientPanel2.TabIndex = 13
        '
        'ModLignesTableAdapter
        '
        Me.ModLignesTableAdapter.ClearBeforeFill = True
        '
        'FrChoixModele
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 300)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrChoixModele"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choix du modèle"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdSuppr As System.Windows.Forms.Button
    Friend WithEvents cmdModif As System.Windows.Forms.Button
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ModLignesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ModLignesTableAdapter
    Friend WithEvents cboModele As System.Windows.Forms.ListBox

End Class
