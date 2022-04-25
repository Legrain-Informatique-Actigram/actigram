Imports System.Drawing.Drawing2D
Imports Actigram.Securite.SecuriteConverter
Imports Actigram.Windows.Forms
Imports Actigram

Public Class Form2
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As MyBt
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton10 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton11 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton12 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton13 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton14 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton15 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton16 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton17 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton18 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton19 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton20 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton21 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxLum As System.Windows.Forms.TextBox
    Friend WithEvents TxCodeCouleur As System.Windows.Forms.TextBox
    Friend WithEvents ToolBarButton22 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New Utilitaire.MyBt
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton8 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton10 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton11 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton12 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton13 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton14 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton15 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton16 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton17 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton18 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton19 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton20 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton21 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton22 = New System.Windows.Forms.ToolBarButton
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxLum = New System.Windows.Forms.TextBox
        Me.TxCodeCouleur = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(704, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(704, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(720, 120)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 40)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton2, Me.ToolBarButton3, Me.ToolBarButton4, Me.ToolBarButton5, Me.ToolBarButton6, Me.ToolBarButton7, Me.ToolBarButton8, Me.ToolBarButton9, Me.ToolBarButton10, Me.ToolBarButton11, Me.ToolBarButton12, Me.ToolBarButton13, Me.ToolBarButton14, Me.ToolBarButton15, Me.ToolBarButton16, Me.ToolBarButton17, Me.ToolBarButton18, Me.ToolBarButton19, Me.ToolBarButton20, Me.ToolBarButton21, Me.ToolBarButton22})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(880, 44)
        Me.ToolBar1.TabIndex = 3
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.ImageIndex = 0
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.ImageIndex = 1
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.ImageIndex = 2
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.ImageIndex = 3
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.ImageIndex = 4
        '
        'ToolBarButton6
        '
        Me.ToolBarButton6.ImageIndex = 5
        '
        'ToolBarButton7
        '
        Me.ToolBarButton7.ImageIndex = 6
        '
        'ToolBarButton8
        '
        Me.ToolBarButton8.ImageIndex = 7
        '
        'ToolBarButton9
        '
        Me.ToolBarButton9.ImageIndex = 8
        '
        'ToolBarButton10
        '
        Me.ToolBarButton10.ImageIndex = 9
        '
        'ToolBarButton11
        '
        Me.ToolBarButton11.ImageIndex = 10
        '
        'ToolBarButton12
        '
        Me.ToolBarButton12.ImageIndex = 10
        '
        'ToolBarButton13
        '
        Me.ToolBarButton13.ImageIndex = 11
        '
        'ToolBarButton14
        '
        Me.ToolBarButton14.ImageIndex = 12
        '
        'ToolBarButton15
        '
        Me.ToolBarButton15.ImageIndex = 13
        '
        'ToolBarButton16
        '
        Me.ToolBarButton16.ImageIndex = 15
        '
        'ToolBarButton17
        '
        Me.ToolBarButton17.ImageIndex = 16
        '
        'ToolBarButton18
        '
        Me.ToolBarButton18.ImageIndex = 17
        '
        'ToolBarButton19
        '
        Me.ToolBarButton19.ImageIndex = 17
        '
        'ToolBarButton20
        '
        Me.ToolBarButton20.ImageIndex = 18
        '
        'ToolBarButton21
        '
        Me.ToolBarButton21.ImageIndex = 19
        '
        'ToolBarButton22
        '
        Me.ToolBarButton22.ImageIndex = 20
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(704, 176)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 32)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Button4"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(8, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(480, 424)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(544, 240)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(240, 208)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'TxLum
        '
        Me.TxLum.BackColor = System.Drawing.SystemColors.Window
        Me.TxLum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxLum.Location = New System.Drawing.Point(536, 128)
        Me.TxLum.Name = "TxLum"
        Me.TxLum.Size = New System.Drawing.Size(128, 20)
        Me.TxLum.TabIndex = 7
        Me.TxLum.Text = "150"
        '
        'TxCodeCouleur
        '
        Me.TxCodeCouleur.BackColor = System.Drawing.SystemColors.Window
        Me.TxCodeCouleur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxCodeCouleur.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxCodeCouleur.Location = New System.Drawing.Point(536, 168)
        Me.TxCodeCouleur.Name = "TxCodeCouleur"
        Me.TxCodeCouleur.Size = New System.Drawing.Size(128, 20)
        Me.TxCodeCouleur.TabIndex = 8
        Me.TxCodeCouleur.Text = ""
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(608, 56)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(88, 40)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "Button5"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 502)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TxCodeCouleur)
        Me.Controls.Add(Me.TxLum)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim g As Graphics = Me.CreateGraphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim oRectTronc As New Rectangle(-10, -60, 20, 60)
        Dim oRectFeuille As New Rectangle(-30, -100, 60, 60)

        Dim oMatrix As New Drawing2D.Matrix(1, 0, -1, 1, 200, 100)

        g.MultiplyTransform(oMatrix, Drawing2D.MatrixOrder.Append)
        g.FillRectangle(Brushes.Gray, oRectTronc)
        g.FillEllipse(Brushes.Gray, oRectFeuille)
        g.ResetTransform()
        g.TranslateTransform(200, 100)
        g.FillRectangle(Brushes.Maroon, oRectTronc)
        g.FillEllipse(Brushes.Green, oRectFeuille)
        g.Dispose()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim g As Graphics
        g = Me.CreateGraphics
        Dim rtBack As New RectangleF
        Dim rt As New RectangleF
        rt.X = -16
        rt.Y = -32
        rt.Width = 32
        rt.Height = 32
        rtBack.X = rt.X - 1
        rtBack.Y = rt.Y - 1
        rtBack.Height = rt.Height + 2
        rtBack.Width = rt.Width + 2
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim path As New Drawing2D.GraphicsPath
        path.AddEllipse(rt)

        Dim br As New Drawing2D.PathGradientBrush(path)
        br.WrapMode = Drawing2D.WrapMode.Clamp
        br.CenterColor = Color.Green
        br.SurroundColors = New Color() {Color.LightGreen}

        Dim oMat As New Drawing2D.Matrix
        Dim n1 As Single = 6
        Dim n2 As Single = 15

        Dim oMatrix As New Drawing2D.Matrix(1, 0, -0.5, 1, 200, 200)

        g.MultiplyTransform(oMatrix, Drawing2D.MatrixOrder.Append)

        g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), rtBack)
        g.ResetTransform()
        g.TranslateTransform(200, 200)
        g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), rtBack)
        g.FillEllipse(br, rt)


        Dim Fleche As New Drawing2D.GraphicsPath
        Dim op As New Pen(Color.White, 7)
        op.StartCap = Drawing2D.LineCap.Square
        op.EndCap = Drawing2D.LineCap.ArrowAnchor

        Dim Lg As Single = 4
        Dim Lg2 As Single = 9

        g.DrawLine(op, rt.X + rt.Width / Lg, rt.Top + rt.Height / 2, rt.X + rt.Width - (rt.Width / Lg2), rt.Top + rt.Height / 2)

        g.SmoothingMode = Drawing2D.SmoothingMode.None

        g.Dispose()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("Test", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Dim oBit As Bitmap

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        oBit = New Bitmap(400, 400)
        DrawHexa(Convert.ToInt32(Me.TxLum.Text))
        Me.PictureBox1.Image = oBit
    End Sub

    Private Sub DrawHexa(ByVal iLum As Int32)
        Dim op() As Point = {New Point(0, 100 * 2), New Point(50 * 2, 0), New Point(150 * 2, 0), New Point(200 * 2, 100 * 2), New Point(150 * 2, 200 * 2), New Point(50 * 2, 200 * 2)}
        Dim oc() As Color = {Color.Red, Color.Yellow, Color.Green, Color.Aqua, Color.Blue, Color.Fuchsia}
        Dim oB As New PathGradientBrush(op)
        oB.CenterColor = Color.FromArgb(iLum, iLum, iLum)
        oB.SurroundColors = oc

        Dim g As Graphics = Graphics.FromImage(oBit)
        g.FillRectangle(oB, oBit.GetBounds(GraphicsUnit.Pixel))
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim oc As Color = oBit.GetPixel(e.X, e.Y)
            Me.PictureBox2.BackColor = oc
            Me.TxCodeCouleur.Text = oc.A & "," & oc.R & "," & oc.G & "," & oc.B
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim swActigramUpDate As New internet.Service1
        'swActigramUpDate.Url = "http://dell/actigramgrc/service1.asmx"
        swActigramUpDate.Url = "http://internet/serviceslea/service1.asmx"
        Try
            Dim strchemin As String
            Me.OpenFileDialog1.Multiselect = True
            Me.OpenFileDialog1.ShowDialog()

            For Each strchemin In Me.OpenFileDialog1.FileNames
                Dim fl As New IO.FileInfo(strchemin)

                Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strchemin)

                Dim strFichier As String
                Dim strResult As String = ""
                strResult = swActigramUpDate.UpLoadNouvelleVersionFichier(CrypteString("sa"), CrypteString("ludo"), myFileVersionInfo.FileVersion, fl.Name, Fichiers.ManipulationFichier.FichierToBase64(strchemin))
                If strResult <> "" Then
                    MsgBox(strResult)
                End If
            Next
            MsgBox("Chargement Nouvelle Version Terminée")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class

Public Class MyBt
    Inherits Button

    Public Sub New()
        MyBase.New()
    End Sub


    Private Sub MyBt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        PrintImage(e.Graphics)
        'e.Graphics.ResetTransform()

        'e.Graphics.DrawString("test", Me.Font, New SolidBrush(Me.ForeColor), 0, 0)
        'g.SmoothingMode = SmoothingMode.None

        'g.Dispose()
    End Sub

    Private Sub MyBt_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If Selected = False Then
            Selected = True
            PrintImage(Me.CreateGraphics)
        End If
    End Sub

    Private Selected As Boolean = False

    Private Sub PrintImage(ByVal g As Graphics)
        g.Clear(Color.White)
        Dim rtBack As New RectangleF
        Dim rt As New RectangleF
        rt.X = -16
        rt.Y = -32
        rt.Width = 32
        rt.Height = 32
        rtBack.X = rt.X - 1
        rtBack.Y = rt.Y - 1
        rtBack.Height = rt.Height + 2
        rtBack.Width = rt.Width + 2
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim path As New GraphicsPath
        path.AddEllipse(rt)

        Dim br As New PathGradientBrush(path)
        br.WrapMode = WrapMode.Clamp
        br.CenterColor = Color.Green
        br.SurroundColors = New Color() {Color.LightGreen}

        Dim oMat As New Drawing2D.Matrix
        Dim n1 As Single = 6
        Dim n2 As Single = 15
        Dim rtCadre As New Rectangle
        rtCadre.Location = Me.Location
        rtCadre.Size = Me.Size


        If Selected Then
            Dim oMatrix As New Matrix(1, 0, -0.5, 1, rt.Width / 2, rt.Height)

            g.MultiplyTransform(oMatrix, MatrixOrder.Append)

            g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), rtBack)
            g.ResetTransform()
        End If
        'End If
        g.TranslateTransform(rt.Width / 2, rt.Height)
        g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), rtBack)
        g.FillEllipse(br, rt)


        Dim Fleche As New GraphicsPath
        Dim op As New Pen(Color.White, 7)
        op.StartCap = LineCap.Square
        op.EndCap = LineCap.ArrowAnchor

        Dim Lg As Single = 4
        Dim Lg2 As Single = 9

        g.DrawLine(op, rt.X + rt.Width / Lg, rt.Top + rt.Height / 2, rt.X + rt.Width - (rt.Width / Lg2), rt.Top + rt.Height / 2)

        g.SmoothingMode = SmoothingMode.None
    End Sub

    Private Sub MyBt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        Selected = False
        PrintImage(Me.CreateGraphics)
    End Sub
End Class