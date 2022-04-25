<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrImportPhytoData
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
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.TxtChemin = New System.Windows.Forms.TextBox
        Me.BtParcourir = New System.Windows.Forms.Button
        Me.ChkNouveauInactif = New System.Windows.Forms.CheckBox
        Me.btOk = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.btCancel = New System.Windows.Forms.Button
        Me.openDlg = New System.Windows.Forms.OpenFileDialog
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fichier à importer :"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.TxtChemin)
        Me.GradientPanel1.Controls.Add(Me.BtParcourir)
        Me.GradientPanel1.Controls.Add(Me.ChkNouveauInactif)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(448, 87)
        Me.GradientPanel1.TabIndex = 22
        '
        'TxtChemin
        '
        Me.TxtChemin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtChemin.Location = New System.Drawing.Point(8, 21)
        Me.TxtChemin.Name = "TxtChemin"
        Me.TxtChemin.Size = New System.Drawing.Size(402, 20)
        Me.TxtChemin.TabIndex = 4
        '
        'BtParcourir
        '
        Me.BtParcourir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtParcourir.Location = New System.Drawing.Point(416, 21)
        Me.BtParcourir.Name = "BtParcourir"
        Me.BtParcourir.Size = New System.Drawing.Size(24, 20)
        Me.BtParcourir.TabIndex = 5
        Me.BtParcourir.Text = "..."
        '
        'ChkNouveauInactif
        '
        Me.ChkNouveauInactif.Location = New System.Drawing.Point(12, 47)
        Me.ChkNouveauInactif.Name = "ChkNouveauInactif"
        Me.ChkNouveauInactif.Size = New System.Drawing.Size(264, 24)
        Me.ChkNouveauInactif.TabIndex = 6
        Me.ChkNouveauInactif.Text = "Laisser inactifs les nouveaux produits"
        '
        'btOk
        '
        Me.btOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOk.Location = New System.Drawing.Point(281, 10)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(75, 23)
        Me.btOk.TabIndex = 0
        Me.btOk.Text = "OK"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.btCancel)
        Me.GradientPanel2.Controls.Add(Me.btOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 87)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(448, 45)
        Me.GradientPanel2.TabIndex = 21
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(361, 10)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 1
        Me.btCancel.Text = "Annuler"
        '
        'openDlg
        '
        Me.openDlg.Filter = "Fichiers texte(*.csv;*.txt)|*.csv;*.txt"
        Me.openDlg.Title = "Sélectionnez le fichier Phyto Data à importer"
        '
        'FrImportPhytoData
        '
        Me.AcceptButton = Me.btOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(448, 132)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrImportPhytoData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Phyto Data"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents TxtChemin As System.Windows.Forms.TextBox
    Friend WithEvents BtParcourir As System.Windows.Forms.Button
    Friend WithEvents ChkNouveauInactif As System.Windows.Forms.CheckBox
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents openDlg As System.Windows.Forms.OpenFileDialog
End Class
