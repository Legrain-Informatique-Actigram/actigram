<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrProgressBar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrProgressBar))
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gcStatus = New System.Windows.Forms.Label
        Me.BtAnnuler = New Ascend.Windows.Forms.GradientNavigationButton
        Me.GradientPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(12, 55)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(251, 21)
        Me.pgBar.TabIndex = 0
        Me.pgBar.UseWaitCursor = True
        Me.pgBar.Value = 20
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Border = New Ascend.Border(1)
        Me.GradientPanel1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.MidnightBlue)
        Me.GradientPanel1.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel1.Controls.Add(Me.PictureBox1)
        Me.GradientPanel1.Controls.Add(Me.gcStatus)
        Me.GradientPanel1.Controls.Add(Me.pgBar)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(352, 83)
        Me.GradientPanel1.TabIndex = 3
        Me.GradientPanel1.UseWaitCursor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.UseWaitCursor = True
        '
        'gcStatus
        '
        Me.gcStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcStatus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcStatus.ForeColor = System.Drawing.Color.SteelBlue
        Me.gcStatus.Location = New System.Drawing.Point(51, 12)
        Me.gcStatus.Name = "gcStatus"
        Me.gcStatus.Size = New System.Drawing.Size(289, 32)
        Me.gcStatus.TabIndex = 1
        Me.gcStatus.Text = "Label1"
        Me.gcStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.gcStatus.UseWaitCursor = True
        '
        'BtAnnuler
        '
        Me.BtAnnuler.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtAnnuler.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.BtAnnuler.ActiveOnClick = False
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtAnnuler.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAnnuler.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtAnnuler.HighColorLuminance = 1.3!
        Me.BtAnnuler.Image = Global.AgriFact.My.Resources.Resources.suppr
        Me.BtAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAnnuler.Location = New System.Drawing.Point(269, 55)
        Me.BtAnnuler.LowColorLuminance = 1.3!
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtAnnuler.Size = New System.Drawing.Size(71, 21)
        Me.BtAnnuler.StayActiveAfterClick = False
        Me.BtAnnuler.TabIndex = 7
        Me.BtAnnuler.TabStop = True
        Me.BtAnnuler.Text = "Annuler"
        '
        'FrProgressBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 83)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrProgressBar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Progression en cours"
        Me.UseWaitCursor = True
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gcStatus As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As Ascend.Windows.Forms.GradientNavigationButton
End Class
