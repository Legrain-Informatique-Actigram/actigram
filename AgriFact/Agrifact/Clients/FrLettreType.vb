Public Class FrLettreType
    Inherits System.Windows.Forms.Form
    Dim currentFont As Font
    Dim currentForeColor As Color
    Dim g As Graphics
    Dim bmp As Bitmap
    Dim nbPageToImp As Integer
    Dim nbPageImp As Integer
    Dim dv As DataView

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    Public Sub New(byRef momDv as DataView)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        dv = momDv
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
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton10 As System.Windows.Forms.ToolBarButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolBarButton11 As System.Windows.Forms.ToolBarButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolBarButton12 As System.Windows.Forms.ToolBarButton
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents ToolBarButton13 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolBarButton14 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton15 As System.Windows.Forms.ToolBarButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrLettreType))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton11 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton15 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton10 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton12 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton13 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton8 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton14 = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AcceptsTab = True
        Me.RichTextBox1.AllowDrop = True
        Me.RichTextBox1.AutoSize = True
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.HideSelection = False
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(640, 464)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton2, Me.ToolBarButton11, Me.ToolBarButton3, Me.ToolBarButton4, Me.ToolBarButton5, Me.ToolBarButton6, Me.ToolBarButton7, Me.ToolBarButton15, Me.ToolBarButton9, Me.ToolBarButton10, Me.ToolBarButton12, Me.ToolBarButton13, Me.ToolBarButton8, Me.ToolBarButton14})
        Me.ToolBar1.Divider = False
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(640, 40)
        Me.ToolBar1.TabIndex = 1
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.ImageIndex = 18
        Me.ToolBarButton1.Text = "Police"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.ImageIndex = 21
        Me.ToolBarButton2.Text = "Couleur"
        '
        'ToolBarButton11
        '
        Me.ToolBarButton11.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.ToolBarButton11.Text = "Puce"
        Me.ToolBarButton11.Visible = False
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.ImageIndex = 27
        Me.ToolBarButton4.Text = "Gauche"
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.ImageIndex = 25
        Me.ToolBarButton5.Text = "Centre"
        '
        'ToolBarButton6
        '
        Me.ToolBarButton6.ImageIndex = 26
        Me.ToolBarButton6.Text = "Droite"
        '
        'ToolBarButton7
        '
        Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton15
        '
        Me.ToolBarButton15.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.ToolBarButton15.Visible = False
        '
        'ToolBarButton9
        '
        Me.ToolBarButton9.ImageIndex = 19
        Me.ToolBarButton9.Text = "Ouvrir"
        '
        'ToolBarButton10
        '
        Me.ToolBarButton10.ImageIndex = 9
        Me.ToolBarButton10.Text = "Enregistrer"
        '
        'ToolBarButton12
        '
        Me.ToolBarButton12.ImageIndex = 23
        Me.ToolBarButton12.Text = "Mettre En Page"
        '
        'ToolBarButton13
        '
        Me.ToolBarButton13.ImageIndex = 24
        Me.ToolBarButton13.Text = "Apercu"
        '
        'ToolBarButton8
        '
        Me.ToolBarButton8.ImageIndex = 22
        Me.ToolBarButton8.Text = "Imprimer"
        '
        'ToolBarButton14
        '
        Me.ToolBarButton14.ImageIndex = 7
        Me.ToolBarButton14.Text = "Fermer"
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Location = New System.Drawing.Point(358, 19)
        Me.PrintPreviewDialog1.MinimumSize = New System.Drawing.Size(375, 250)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty
        Me.PrintPreviewDialog1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 469)
        Me.Panel1.TabIndex = 2
        '
        'FrLettreType
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 509)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Name = "FrLettreType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lettre Type"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Text
            Case "Police"
                Me.FontDialog1.ShowDialog()
                currentFont = Me.FontDialog1.Font
                Me.RichTextBox1.SelectionFont = currentFont
            Case "Couleur"
                Me.ColorDialog1.ShowDialog()
                currentForeColor = Me.ColorDialog1.Color
                Me.RichTextBox1.SelectionColor = currentForeColor
            Case "Gauche"
                Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
            Case "Centre"
                Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            Case "Droite"
                Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
            Case "Puce"
                Me.RichTextBox1.SelectionBullet = e.Button.Pushed
            Case "Apercu"
                Impression(Me.RichTextBox1)
            Case "Ouvrir"
                Me.OpenFileDialog1.Filter = "Fichiers rtf|*.rtf"
                Me.OpenFileDialog1.ShowDialog()
                Me.RichTextBox1.LoadFile(Me.OpenFileDialog1.FileName)
            Case "Enregistrer"
                Me.SaveFileDialog1.FileName = "SavType1.rtf"
                Me.SaveFileDialog1.Filter = "Fichiers rtf|*.rtf"
                Me.SaveFileDialog1.ShowDialog()
                Me.RichTextBox1.SaveFile(Me.SaveFileDialog1.FileName)
            Case "Imprimer"
                nbPageToImp = 1
                nbPageImp = 0
                'Me.PrintDialog1.Document = Me.PrintDocument1
                'Me.PrintDialog1.ShowDialog()
                Me.PrintDocument1.Print()
            Case "Mettre En Page"
                Me.PageSetupDialog1.Document = Me.PrintDocument1
                Me.PageSetupDialog1.ShowDialog()
                DimRichTextBox()
            Case "Fermer"
                Me.Close()
        End Select
    End Sub

    Sub Impression(ByVal myRTF As RichTextBox)
        If dv Is Nothing Then
            nbPageToImp = 1
        Else
            nbPageToImp = dv.Count
        End If

        nbPageImp = 0
        Me.RichTextBox1.Visible = False
        Me.PrintPreviewDialog1.Document = PrintDocument1
        Me.PrintPreviewDialog1.ShowDialog()
        Me.RichTextBox1.Visible = True

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i As Integer
        Dim strTop As Single = 0
        Dim strRtfTextDep As String
        Dim strStringToImp As String

        strRtfTextDep = Me.RichTextBox1.Rtf

        'If nbPageImp = 0 Then
        'bmp = New Bitmap(e.PageBounds.Width, e.PageBounds.Height, Imaging.PixelFormat.Format64bppPArgb)

        'strStringToImp = Me.RichTextBox1.Text

        'strStringToImp = strStringToImp.Replace("{Nom}", "Dupont" & nbPageImp.ToString)
        Do Until Me.RichTextBox1.Text.IndexOf("{") = -1
            Dim nDep As Integer
            nDep = Me.RichTextBox1.Text.IndexOf("{")
            Me.RichTextBox1.SelectionStart = nDep
            Me.RichTextBox1.SelectionLength = Me.RichTextBox1.Text.IndexOf("}"c, nDep) - nDep + 1
            If dv Is Nothing Then
                Me.RichTextBox1.SelectedText = "Dupont" & nbPageImp.ToString
            Else
                Me.RichTextBox1.SelectedText = Convert.ToString(dv.Item(nbPageImp).Item(Me.RichTextBox1.SelectedText.Replace("{", "").Replace("}", "")))
            End If
        Loop
        'If strStringToImp.Substring(nSelStart, 1) = "{" Then
        strStringToImp = Me.RichTextBox1.Text

        Dim g As Graphics
        g = e.Graphics
        'g = g.FromImage(bmp)

        'Dim im As New Bitmap("D:\Photos\Photo\DSCN0032.jpg")


        'g.DrawImage(im, 0, 0, 60, 80)
        Me.RichTextBox1.HideSelection = True
        Me.RichTextBox1.SelectionLength = 1
        Dim nSelStart As Integer = 0
        Me.RichTextBox1.SelectionStart = 0


        For i = 0 To Me.RichTextBox1.Text.Length - 1
            g.DrawString(strStringToImp.Substring(nSelStart, 1), Me.RichTextBox1.SelectionFont, New SolidBrush(Me.RichTextBox1.SelectionColor), Me.RichTextBox1.GetPositionFromCharIndex(Me.RichTextBox1.SelectionStart).X + e.MarginBounds.Left, Me.RichTextBox1.GetPositionFromCharIndex(Me.RichTextBox1.SelectionStart).Y + e.MarginBounds.Top)
            'strTop += Me.RichTextBox1.GetPositionFromCharIndex(Me.RichTextBox1.SelectionStart).X
            'strTop += e.Graphics.MeasureString(Me.RichTextBox1.SelectedText, Me.RichTextBox1.SelectionFont).Height
            nSelStart += 1
            Me.RichTextBox1.SelectionStart = nSelStart
            If Me.RichTextBox1.GetPositionFromCharIndex(nSelStart).X > e.MarginBounds.Height Then
            End If
        Next

        Me.RichTextBox1.HideSelection = False
        'Me.RichTextBox1.Visible = True
        Me.RichTextBox1.Rtf = strRtfTextDep
        'e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        'e.Graphics.DrawImage(bmp, 0, 0)
        nbPageImp += 1
        If nbPageToImp > nbPageImp Then
            e.HasMorePages = True
        End If
        'Else
        '    'e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        '    'e.Graphics.DrawImage(bmp, 0, 0)
        '    nbPageImp += 1
        '    If nbPageToImp > nbPageImp Then
        '        e.HasMorePages = True
        '    End If
        'End If


        'e.Graphics.DrawString("Test", New Font("Arial", 12, FontStyle.Regular), Brushes.Blue, 0, 0)

        'e.HasMorePages = False
    End Sub

    Private Sub FrLettreType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DimRichTextBox()
    End Sub

    Sub DimRichTextBox()
        Me.RichTextBox1.Width = Me.PrintDocument1.DefaultPageSettings.Bounds.Width - Me.PrintDocument1.DefaultPageSettings.Margins.Left - Me.PrintDocument1.DefaultPageSettings.Margins.Right
        Me.RichTextBox1.Height = Me.PrintDocument1.DefaultPageSettings.Bounds.Height - Me.PrintDocument1.DefaultPageSettings.Margins.Top - Me.PrintDocument1.DefaultPageSettings.Margins.Bottom
    End Sub

End Class
