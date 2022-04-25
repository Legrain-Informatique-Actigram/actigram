Namespace Securite.Activation
    Partial Public Class FrActivation

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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents BtOK As System.Windows.Forms.Button
        Friend WithEvents BtCancel As System.Windows.Forms.Button
        Friend WithEvents SaisieCle1 As AgrigestEDI.Securite.Activation.SaisieCle
        Friend WithEvents lbValid As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents TxCodeUtilisateur As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label
            Me.BtOK = New System.Windows.Forms.Button
            Me.BtCancel = New System.Windows.Forms.Button
            Me.SaisieCle1 = New AgrigestEDI.Securite.Activation.SaisieCle
            Me.lbValid = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.TxCodeUtilisateur = New System.Windows.Forms.TextBox
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.Label3 = New System.Windows.Forms.Label
            Me.lbTel = New System.Windows.Forms.Label
            Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
            Me.GradientPanel1.SuspendLayout()
            Me.GradientPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.Label1.Location = New System.Drawing.Point(5, 69)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 23)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Votre clé d'activation:"
            '
            'BtOK
            '
            Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.BtOK.Location = New System.Drawing.Point(164, 8)
            Me.BtOK.Name = "BtOK"
            Me.BtOK.Size = New System.Drawing.Size(75, 23)
            Me.BtOK.TabIndex = 1
            Me.BtOK.Text = "OK"
            '
            'BtCancel
            '
            Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.BtCancel.Location = New System.Drawing.Point(245, 8)
            Me.BtCancel.Name = "BtCancel"
            Me.BtCancel.Size = New System.Drawing.Size(75, 23)
            Me.BtCancel.TabIndex = 2
            Me.BtCancel.Text = "Annuler"
            '
            'SaisieCle1
            '
            Me.SaisieCle1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.SaisieCle1.Cle = CType(0, Long)
            Me.SaisieCle1.CleText = ""
            Me.SaisieCle1.Location = New System.Drawing.Point(125, 59)
            Me.SaisieCle1.Name = "SaisieCle1"
            Me.SaisieCle1.Size = New System.Drawing.Size(200, 40)
            Me.SaisieCle1.TabIndex = 3
            '
            'lbValid
            '
            Me.lbValid.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.lbValid.AutoSize = True
            Me.lbValid.Location = New System.Drawing.Point(133, 99)
            Me.lbValid.Name = "lbValid"
            Me.lbValid.Size = New System.Drawing.Size(38, 13)
            Me.lbValid.TabIndex = 5
            Me.lbValid.Text = "lbValid"
            '
            'Label2
            '
            Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.Label2.Location = New System.Drawing.Point(5, 38)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(100, 23)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Votre code client:"
            '
            'TxCodeUtilisateur
            '
            Me.TxCodeUtilisateur.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.TxCodeUtilisateur.Location = New System.Drawing.Point(133, 35)
            Me.TxCodeUtilisateur.Name = "TxCodeUtilisateur"
            Me.TxCodeUtilisateur.Size = New System.Drawing.Size(184, 20)
            Me.TxCodeUtilisateur.TabIndex = 7
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.Label3)
            Me.GradientPanel1.Controls.Add(Me.lbTel)
            Me.GradientPanel1.Controls.Add(Me.Label2)
            Me.GradientPanel1.Controls.Add(Me.Label1)
            Me.GradientPanel1.Controls.Add(Me.TxCodeUtilisateur)
            Me.GradientPanel1.Controls.Add(Me.SaisieCle1)
            Me.GradientPanel1.Controls.Add(Me.lbValid)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
            Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(332, 117)
            Me.GradientPanel1.TabIndex = 20
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(5, 10)
            Me.Label3.Margin = New System.Windows.Forms.Padding(5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(94, 13)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Tél. support client:"
            '
            'lbTel
            '
            Me.lbTel.AutoSize = True
            Me.lbTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTel.Location = New System.Drawing.Point(133, 10)
            Me.lbTel.Margin = New System.Windows.Forms.Padding(5)
            Me.lbTel.Name = "lbTel"
            Me.lbTel.Size = New System.Drawing.Size(35, 13)
            Me.lbTel.TabIndex = 8
            Me.lbTel.Text = "lbTel"
            '
            'GradientPanel2
            '
            Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
            Me.GradientPanel2.Controls.Add(Me.BtCancel)
            Me.GradientPanel2.Controls.Add(Me.BtOK)
            Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
            Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
            Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
            Me.GradientPanel2.Location = New System.Drawing.Point(0, 117)
            Me.GradientPanel2.Name = "GradientPanel2"
            Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
            Me.GradientPanel2.Size = New System.Drawing.Size(332, 42)
            Me.GradientPanel2.TabIndex = 21
            '
            'FrActivation
            '
            Me.AcceptButton = Me.BtOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.White
            Me.CancelButton = Me.BtCancel
            Me.ClientSize = New System.Drawing.Size(332, 159)
            Me.ControlBox = False
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.GradientPanel2)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FrActivation"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Saisie de la clé d'activation"
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.GradientPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents lbTel As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label

#End Region

    End Class
End Namespace
