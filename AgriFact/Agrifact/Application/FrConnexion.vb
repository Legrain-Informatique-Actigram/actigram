Imports Actigram.Windows.Forms

Public Class FrConnexion
    Inherits System.Windows.Forms.Form

    Dim nbTentative As Integer = 3
    Dim frA As FrApplication
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientNavigationButton1 As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents GradientNavigationButton2 As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtAnnuler As Actigram.Windows.Forms.BoutonImage
    Friend WithEvents BtOk As Actigram.Windows.Forms.BoutonImage
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Private WithEvents TimerAffichage As New Timer

#Region "Constructeurs"
    Public Sub New(ByRef momApplication As FrApplication, Optional ByVal Utilisateur As String = "", Optional ByVal Password As String = "")
        Me.New()

        frA = momApplication
        TxUtilisateur.Text = Utilisateur
        TxPassword.Text = Password
        If TxUtilisateur.Text <> "" Then
            TxPassword.Select()
        Else
            TxUtilisateur.Select()
        End If
    End Sub
#End Region

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
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
    Friend WithEvents TxUtilisateur As System.Windows.Forms.TextBox
    Friend WithEvents TxPassword As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrConnexion))
        Me.TxUtilisateur = New System.Windows.Forms.TextBox
        Me.TxPassword = New System.Windows.Forms.TextBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientNavigationButton1 = New Ascend.Windows.Forms.GradientNavigationButton
        Me.GradientNavigationButton2 = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtAnnuler = New Actigram.Windows.Forms.BoutonImage
        Me.BtOk = New Actigram.Windows.Forms.BoutonImage
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxUtilisateur
        '
        Me.TxUtilisateur.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxUtilisateur.Location = New System.Drawing.Point(141, 118)
        Me.TxUtilisateur.Name = "TxUtilisateur"
        Me.TxUtilisateur.Size = New System.Drawing.Size(152, 23)
        Me.TxUtilisateur.TabIndex = 1
        Me.TxUtilisateur.Text = "12345"
        '
        'TxPassword
        '
        Me.TxPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxPassword.Location = New System.Drawing.Point(141, 145)
        Me.TxPassword.Name = "TxPassword"
        Me.TxPassword.Size = New System.Drawing.Size(152, 23)
        Me.TxPassword.TabIndex = 3
        Me.TxPassword.Text = "12345"
        Me.TxPassword.UseSystemPasswordChar = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Alpha = 50
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.GradientNavigationButton2)
        Me.GradientPanel2.Controls.Add(Me.GradientNavigationButton1)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 176)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(361, 66)
        Me.GradientPanel2.TabIndex = 19
        '
        'GradientNavigationButton1
        '
        Me.GradientNavigationButton1.ActiveGradientHighColor = System.Drawing.Color.Orange
        Me.GradientNavigationButton1.ActiveGradientLowColor = System.Drawing.Color.Gold
        Me.GradientNavigationButton1.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientNavigationButton1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientNavigationButton1.ForeColor = System.Drawing.Color.White
        Me.GradientNavigationButton1.GradientHighColor = System.Drawing.Color.Yellow
        Me.GradientNavigationButton1.GradientLowColor = System.Drawing.Color.Chocolate
        Me.GradientNavigationButton1.HighlightGradientHighColor = System.Drawing.Color.Orange
        Me.GradientNavigationButton1.HighlightGradientLowColor = System.Drawing.Color.Gold
        Me.GradientNavigationButton1.Location = New System.Drawing.Point(141, 17)
        Me.GradientNavigationButton1.Name = "GradientNavigationButton1"
        Me.GradientNavigationButton1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientNavigationButton1.Size = New System.Drawing.Size(101, 26)
        Me.GradientNavigationButton1.TabIndex = 6
        Me.GradientNavigationButton1.Text = "CONNEXION"
        Me.GradientNavigationButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GradientNavigationButton2
        '
        Me.GradientNavigationButton2.ActiveGradientHighColor = System.Drawing.Color.AliceBlue
        Me.GradientNavigationButton2.ActiveGradientLowColor = System.Drawing.Color.LightSkyBlue
        Me.GradientNavigationButton2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientNavigationButton2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientNavigationButton2.ForeColor = System.Drawing.Color.White
        Me.GradientNavigationButton2.GradientHighColor = System.Drawing.Color.Azure
        Me.GradientNavigationButton2.GradientLowColor = System.Drawing.Color.SteelBlue
        Me.GradientNavigationButton2.HighlightGradientHighColor = System.Drawing.Color.AliceBlue
        Me.GradientNavigationButton2.HighlightGradientLowColor = System.Drawing.Color.LightSkyBlue
        Me.GradientNavigationButton2.Location = New System.Drawing.Point(248, 17)
        Me.GradientNavigationButton2.Name = "GradientNavigationButton2"
        Me.GradientNavigationButton2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientNavigationButton2.Size = New System.Drawing.Size(101, 26)
        Me.GradientNavigationButton2.TabIndex = 7
        Me.GradientNavigationButton2.Text = "ANNULER"
        Me.GradientNavigationButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtAnnuler
        '
        Me.BtAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.BtAnnuler.CausesValidation = False
        Me.BtAnnuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAnnuler.ForeColor = System.Drawing.Color.White
        Me.BtAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAnnuler.Location = New System.Drawing.Point(269, 19)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(64, 14)
        Me.BtAnnuler.TabIndex = 5
        Me.BtAnnuler.Text = "ANNULER"
        Me.BtAnnuler.UseVisualStyleBackColor = False
        '
        'BtOk
        '
        Me.BtOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtOk.CausesValidation = False
        Me.BtOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.ForeColor = System.Drawing.Color.White
        Me.BtOk.Location = New System.Drawing.Point(152, 19)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(80, 14)
        Me.BtOk.TabIndex = 4
        Me.BtOk.Text = "CONNEXION"
        Me.BtOk.UseVisualStyleBackColor = False
        '
        'GradientCaption1
        '
        Me.GradientCaption1.Alpha = 0
        Me.GradientCaption1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GradientCaption1.GradientHighColor = System.Drawing.Color.Transparent
        Me.GradientCaption1.GradientLowColor = System.Drawing.Color.Black
        Me.GradientCaption1.Location = New System.Drawing.Point(26, 117)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Flat
        Me.GradientCaption1.Size = New System.Drawing.Size(109, 24)
        Me.GradientCaption1.TabIndex = 20
        Me.GradientCaption1.Text = "UTILISATEUR"
        '
        'GradientCaption2
        '
        Me.GradientCaption2.Alpha = 0
        Me.GradientCaption2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GradientCaption2.GradientHighColor = System.Drawing.Color.Transparent
        Me.GradientCaption2.GradientLowColor = System.Drawing.Color.Black
        Me.GradientCaption2.Location = New System.Drawing.Point(26, 146)
        Me.GradientCaption2.Name = "GradientCaption2"
        Me.GradientCaption2.RenderMode = Ascend.Windows.Forms.RenderMode.Flat
        Me.GradientCaption2.Size = New System.Drawing.Size(115, 24)
        Me.GradientCaption2.TabIndex = 21
        Me.GradientCaption2.Text = "MOT DE PASSE"
        '
        'FrConnexion
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(361, 242)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.TxPassword)
        Me.Controls.Add(Me.TxUtilisateur)
        Me.Controls.Add(Me.GradientCaption1)
        Me.Controls.Add(Me.GradientCaption2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrConnexion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connexion"
        Me.TopMost = True
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Page"
    Private Sub FrConnexion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Dim rt As New RectangleF(0, 0, Me.Width, Me.Height)
        Dim nAngle As Integer = 50
        Dim intervalbordure As Integer = 0
        Dim heightbuttongroup As Integer = Convert.ToInt32(rt.Height)

        Dim ph As New Drawing2D.GraphicsPath
        ph.AddLine(intervalbordure + CInt(nAngle / 2), rt.Y, intervalbordure + rt.Width - CInt(nAngle / 2) - 1, rt.Y)
        ph.AddArc(intervalbordure + rt.Width - nAngle - 1, rt.Y, nAngle, nAngle, -90, 90)
        ph.AddLine(intervalbordure + rt.Width - 1, rt.Y + CInt(nAngle / 2), intervalbordure + rt.Width - 1, rt.Y + heightbuttongroup - 1 - CInt(nAngle / 2))
        ph.AddArc(intervalbordure + rt.Width - 1 - nAngle, rt.Y + heightbuttongroup - 1 - nAngle, nAngle, nAngle, 0, 90)
        ph.AddLine(intervalbordure + rt.Width - 1 - CInt(nAngle / 2), rt.Y + heightbuttongroup - 1, CInt(nAngle / 2), rt.Y + heightbuttongroup - 1)
        ph.AddArc(0, rt.Y + heightbuttongroup - 1 - nAngle, nAngle, nAngle, 90, 90)
        ph.AddLine(intervalbordure + 0, rt.Y + heightbuttongroup - 1 - nAngle, intervalbordure + 0, rt.Y + nAngle)
        ph.AddArc(intervalbordure + 0, rt.Y + 0, nAngle, nAngle, -180, 90)

        Me.Region = New Region(ph)

        Me.Opacity = 0
        TimerAffichage.Interval = 24
        TimerAffichage.Start()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GradientNavigationButton1.Click, BtOk.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Me.TopMost = False
            Select Case DefinitionDonnees.VerifIdentiteServeur(Me.TxUtilisateur.Text, Me.TxPassword.Text)
                Case DialogResult.OK
                    'Succès
                    FrApplication.Utilisateur = Me.TxUtilisateur.Text
                    FrApplication.Pwd = Me.TxPassword.Text
                    frA.Visible = True
                    frA.WindowState = FormWindowState.Maximized

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Case DialogResult.Retry
                    If nbTentative > 0 Then
                        Me.TopMost = True
                        MsgBox("Nom d'utilisateur ou mot de passe incorrect.", MsgBoxStyle.Exclamation, "Attention")
                        TxUtilisateur.Focus()
                        nbTentative -= 1
                    Else
                        MsgBox("Nombre de tentative maximum dépassé.", MsgBoxStyle.Critical, "Erreur")
                        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
                        Me.Close()
                    End If
                Case DialogResult.Abort
                    Me.DialogResult = DialogResult.Abort
                    Me.Close()
            End Select
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GradientNavigationButton2.Click, BtAnnuler.Click
        'End
        Me.DialogResult = DialogResult.Cancel
    End Sub
#End Region

#Region "Timer"
    Private Sub TimerAffichage_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerAffichage.Tick
        If Me.Opacity <= 0.95 Then
            Me.Opacity += 0.05
        Else
            Me.Opacity = 100
            Me.TimerAffichage.Stop()
        End If
    End Sub
#End Region

End Class
