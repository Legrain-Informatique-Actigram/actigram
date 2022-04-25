Partial Public Class FrExportationIsagriAnnulation
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents saveDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ChkExports As System.Windows.Forms.CheckedListBox
    Friend WithEvents BtOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.saveDlg = New System.Windows.Forms.SaveFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.ChkExports = New System.Windows.Forms.CheckedListBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(233, 7)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "OK"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(313, 7)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 3
        Me.BtAnnuler.Text = "Annuler"
        '
        'saveDlg
        '
        Me.saveDlg.DefaultExt = "ecr"
        Me.saveDlg.Filter = "Fichiers ECR (*.ECR)|*.ECR"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Sélectionnez les export à annuler:"
        '
        'ChkExports
        '
        Me.ChkExports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkExports.CheckOnClick = True
        Me.ChkExports.Location = New System.Drawing.Point(6, 35)
        Me.ChkExports.Name = "ChkExports"
        Me.ChkExports.Size = New System.Drawing.Size(385, 184)
        Me.ChkExports.TabIndex = 9
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.ChkExports)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(400, 227)
        Me.GradientPanel1.TabIndex = 10
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 227)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(400, 42)
        Me.GradientPanel2.TabIndex = 4
        '
        'FrExportationIsagriAnnulation
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(400, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrExportationIsagriAnnulation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Annulation d'export Isacompta"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel

#End Region


End Class
