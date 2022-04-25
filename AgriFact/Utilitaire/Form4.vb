Imports System.Xml.Serialization
Imports System.ComponentModel
Imports Utilitaire.Impression.Perso


Public Class Form4
    Inherits System.Windows.Forms.Form
    Dim LstControlImpression As New LstControlSerialisable
    Dim WithEvents popMenu As New ContextMenu(New MenuItem() {New MenuItem("Selectionner", AddressOf MenuSelectionner), New MenuItem("Copy", AddressOf MenuCopy), New MenuItem("Coller", AddressOf MenuColler), New MenuItem("Supprimer", AddressOf MenuSupprimer)})


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
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents BtSerialise As System.Windows.Forms.Button
    Friend WithEvents BtDdeserialise As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents PlEnTete As System.Windows.Forms.Panel
    Friend WithEvents PlBody As System.Windows.Forms.Panel
    Friend WithEvents PlPied As System.Windows.Forms.Panel
    Friend WithEvents PlPage As System.Windows.Forms.Panel
    Friend WithEvents PlConteneur As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.BtSerialise = New System.Windows.Forms.Button
        Me.BtDdeserialise = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.PlPage = New System.Windows.Forms.Panel
        Me.PlPied = New System.Windows.Forms.Panel
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.PlBody = New System.Windows.Forms.Panel
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.PlEnTete = New System.Windows.Forms.Panel
        Me.PlConteneur = New System.Windows.Forms.Panel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PlPage.SuspendLayout()
        Me.PlConteneur.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(576, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "+ Label"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.CommandsVisibleIfAvailable = True
        Me.PropertyGrid1.LargeButtons = False
        Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.PropertyGrid1.Location = New System.Drawing.Point(576, 136)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(208, 264)
        Me.PropertyGrid1.TabIndex = 1
        Me.PropertyGrid1.Text = "PropertyGrid1"
        Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
        Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'BtSerialise
        '
        Me.BtSerialise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSerialise.Location = New System.Drawing.Point(712, 48)
        Me.BtSerialise.Name = "BtSerialise"
        Me.BtSerialise.Size = New System.Drawing.Size(72, 32)
        Me.BtSerialise.TabIndex = 4
        Me.BtSerialise.Text = "Enregistrer"
        '
        'BtDdeserialise
        '
        Me.BtDdeserialise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtDdeserialise.Location = New System.Drawing.Point(712, 0)
        Me.BtDdeserialise.Name = "BtDdeserialise"
        Me.BtDdeserialise.Size = New System.Drawing.Size(72, 32)
        Me.BtDdeserialise.TabIndex = 5
        Me.BtDdeserialise.Text = "Ouvrir"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(712, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Imprimer"
        '
        'PlPage
        '
        Me.PlPage.Controls.Add(Me.PlPied)
        Me.PlPage.Controls.Add(Me.Splitter2)
        Me.PlPage.Controls.Add(Me.PlBody)
        Me.PlPage.Controls.Add(Me.Splitter1)
        Me.PlPage.Controls.Add(Me.PlEnTete)
        Me.PlPage.Location = New System.Drawing.Point(0, 0)
        Me.PlPage.Name = "PlPage"
        Me.PlPage.Size = New System.Drawing.Size(552, 200)
        Me.PlPage.TabIndex = 7
        '
        'PlPied
        '
        Me.PlPied.AllowDrop = True
        Me.PlPied.BackColor = System.Drawing.Color.White
        Me.PlPied.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlPied.Location = New System.Drawing.Point(0, 88)
        Me.PlPied.Name = "PlPied"
        Me.PlPied.Size = New System.Drawing.Size(552, 112)
        Me.PlPied.TabIndex = 4
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.RosyBrown
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 80)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(552, 8)
        Me.Splitter2.TabIndex = 3
        Me.Splitter2.TabStop = False
        '
        'PlBody
        '
        Me.PlBody.AllowDrop = True
        Me.PlBody.BackColor = System.Drawing.Color.White
        Me.PlBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlBody.Location = New System.Drawing.Point(0, 48)
        Me.PlBody.Name = "PlBody"
        Me.PlBody.Size = New System.Drawing.Size(552, 32)
        Me.PlBody.TabIndex = 2
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.RosyBrown
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 40)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(552, 8)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'PlEnTete
        '
        Me.PlEnTete.AllowDrop = True
        Me.PlEnTete.BackColor = System.Drawing.Color.White
        Me.PlEnTete.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlEnTete.Location = New System.Drawing.Point(0, 0)
        Me.PlEnTete.Name = "PlEnTete"
        Me.PlEnTete.Size = New System.Drawing.Size(552, 40)
        Me.PlEnTete.TabIndex = 0
        '
        'PlConteneur
        '
        Me.PlConteneur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlConteneur.AutoScroll = True
        Me.PlConteneur.Controls.Add(Me.PlPage)
        Me.PlConteneur.Location = New System.Drawing.Point(8, 32)
        Me.PlConteneur.Name = "PlConteneur"
        Me.PlConteneur.Size = New System.Drawing.Size(552, 368)
        Me.PlConteneur.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(576, 56)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 72)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = ""
        '
        'Form4
        '
        Me.AllowDrop = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 406)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PlConteneur)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtDdeserialise)
        Me.Controls.Add(Me.BtSerialise)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.PlPage.ResumeLayout(False)
        Me.PlConteneur.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim WithEvents dlgImprimer As New PrintDialog
    Dim WithEvents dlgPreview As New PrintPreviewDialog
    Dim WithEvents doc As New Printing.PrintDocument
    Dim pageSet As New Printing.PageSettings
    Dim PageSetDialog As New PageSetupDialog

    Dim ptDec As Point
    Dim ptDepart As Point
    Dim nbObject As Integer = -1
    Dim LstObj As New LstControl

    Private Sub MenuSelectionner(ByVal sender As Object, ByVal e As EventArgs)
        If Not CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl Is Nothing Then
            Dim ctl As Control
            ctl = CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl
            If LstObj.Contains(ctl) = False Then
                LstObj.Add(ctl)
                CType(ctl, Label).BorderStyle = BorderStyle.FixedSingle
            Else
                LstObj.Remove(ctl)
                CType(ctl, Label).BorderStyle = BorderStyle.None
            End If
            Me.PropertyGrid1.SelectedObjects = LstObj.ToControls
        End If
    End Sub

    Private Sub MenuSupprimer(ByVal sender As Object, ByVal e As EventArgs)
        If Not CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl Is Nothing Then
            Dim ctl As Control
            ctl = CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl
            If Me.LstControlImpression.Contains(ctl) Then
                Me.LstControlImpression.Remove(ctl)
            End If
            If LstObj.Contains(ctl) = True Then
                LstObj.Remove(ctl)
            End If
            Me.PropertyGrid1.SelectedObjects = LstObj.ToControls
            Me.PlConteneur.Controls.Remove(ctl)
            ctl.Dispose()
        End If
    End Sub

    Private Sub MenuCopy(ByVal sender As Object, ByVal e As EventArgs)
        If Not CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl Is Nothing Then
            Dim ctl As Control
            ctl = CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl
            If LstObj.Contains(ctl) = False Then
                LstObj.Add(ctl)
            End If
            Me.PropertyGrid1.SelectedObjects = LstObj.ToControls
        End If
    End Sub

    Private Sub MenuColler(ByVal sender As Object, ByVal e As EventArgs)
        Me.AjouteCtl()
        Me.LstObj.Clear()
    End Sub

    Private Function CalculExpression(ByVal Expression As String) As Decimal
        Expression = AnalyseFourchette(Expression)

        Expression = AnalyseMoins(Expression)

        Dim str() As String

        str = Expression.Split(New Char() {"+"c})

        Dim strI As String
        Dim result As Decimal
        Dim i As Integer

        For i = 0 To str.GetUpperBound(0)
            If i = 0 Then
                result = AnalyseFois(str(i))
                Expression = Expression.Substring(str(i).Length, (Expression.Length - str(i).Length))
            Else
                Select Case Expression.Substring(0, 1)
                    Case "+"
                        result += AnalyseFois(str(i))
                End Select
                Expression = Expression.Substring(str(i).Length + 1, (Expression.Length - str(i).Length - 1))
            End If
        Next
        Return result
    End Function

    Private Function AnalyseMoins(ByVal Expression As String) As String

        Dim str() As String

        str = Expression.Split(New Char() {"-"c})

        Dim strI As String
        Dim result As Decimal
        Dim i As Integer

        For i = 1 To str.GetUpperBound(0)
            Dim strLast As String
            If str(i - 1).Trim.Length > 0 Then
                strLast = str(i - 1).Trim.Substring(str(i - 1).Trim.Length - 1, 1)
                If strLast <> "/" And strLast <> "*" And strLast <> "+" Then
                    str(i - 1) += "+"
                End If
            End If
        Next
        Return String.Join("-", str)
    End Function

    Private Function AnalyseFois(ByVal Expression As String) As Decimal
        Dim str() As String
        str = Expression.Split(New Char() {"*"c, "/"c})

        Dim strI As String
        Dim result As Decimal
        Dim i As Integer

        For i = 0 To str.GetUpperBound(0)
            If i = 0 Then
                result = AnalyseString(str(i))
                Expression = Expression.Substring(str(i).Length, (Expression.Length - str(i).Length))
            Else
                Select Case Expression.Substring(0, 1)
                    Case "*"
                        result *= AnalyseString(str(i))
                    Case "/"
                        result /= AnalyseString(str(i))
                End Select
                Expression = Expression.Substring(str(i).Length + 1, (Expression.Length - str(i).Length - 1))
            End If
        Next
        Return result
    End Function

    Private Function AnalyseString(ByVal str As String) As Decimal
        Return Decimal.Parse(str.Replace(" ", ""))
    End Function

    Private Function AnalyseFourchette(ByVal Expression As String) As String
        Dim str() As String
        str = Expression.Split("["c, "]"c)

        Dim i As Integer
        For i = 0 To str.GetUpperBound(0)
            If Expression.IndexOf("[" & str(i) & "]") >= 0 Then
                Dim strF() As String
                strF = str(i).Split(";"c)
                str(i) = CalculFourchette(strF(0), strF(1), strF(2), strF(3), strF(4)).ToString
            End If
        Next
        Expression = String.Join("", str)
        Return Expression
    End Function

    Private Function CalculFourchette(ByVal TypeFourchette As String, ByVal Operateur As String, ByVal DebutFourchette As String, ByVal FinFourchette As String, ByVal Masque As String) As Decimal
        Return -99
    End Function

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim result As Decimal = CalculExpression("- 10,5 + [RptD;Plus;71000000;72000000;wwwwwwww] +  12 -  5 +  12 /  2 * 2 + 50 + 10*-1")

        Me.PlBody.ContextMenu = popMenu
        doc = New Printing.PrintDocument
        'pageSet = New Printing.PageSettings(dlgImprimer.PrinterSettings)
        'doc.PrinterSettings = dlgImprimer.PrinterSettings
        'doc.DefaultPageSettings = pageSet
        PageSetDialog.Document = doc
        PageSetDialog.ShowDialog()
        doc.DefaultPageSettings = PageSetDialog.PageSettings
        dlgPreview.Document = doc

        Me.PlPage.Width = doc.DefaultPageSettings.Bounds.Width
        Me.PlPage.Height = doc.DefaultPageSettings.Bounds.Height
        Me.PlEnTete.Width = doc.DefaultPageSettings.Bounds.Width
        Me.PlBody.Width = doc.DefaultPageSettings.Bounds.Width
        Me.PlPied.Width = doc.DefaultPageSettings.Bounds.Width
        Me.PlEnTete.Height = 30
        Me.PlBody.Height = doc.DefaultPageSettings.Bounds.Height - 60
        Me.PlPied.Height = 30
    End Sub


    Private Sub Preview()
        dlgImprimer.AllowSelection = True
        dlgImprimer.AllowSomePages = True
        'doc.DocumentName = "Test imprimé sur " & dlgImprimer.PrinterSettings.PrinterName
        If dlgPreview.ShowDialog <> DialogResult.OK Then Exit Sub
        doc.Print()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AjouteCtl()
    End Sub

    Private Sub AjouteCtl()
        If Me.LstObj.Count = 0 Then
            Dim lb As New ObjetsImp
            lb.Top = 0
            lb.Left = 0
            lb.Width = 50
            lb.Height = 30
            lb.Text = "Test"
            Me.PlConteneur.Controls.Add(lb)
            LstControlImpression.Add(lb)
            lb.AllowDrop = True
            lb.BringToFront()
            'AddHandler lb.Click, AddressOf SelectObj
            AddHandler lb.MouseDown, AddressOf Label1_MouseDown
            AddHandler lb.DragEnter, AddressOf Form4_DragEnter
            AddHandler lb.DragDrop, AddressOf Form4_DragDrop
            lb.ContextMenu = popMenu
            lb.BringToFront()
        Else
            Dim ctl As Object
            For Each ctl In LstObj
                If TypeOf ctl Is ObjetsImp Then
                    Dim lb As New ObjetsImp
                    SerialisableControl.CopyProperty(CType(ctl, Label), CType(lb, ObjetsImp))
                    lb.Top = 0
                    lb.Left = 0
                    Me.PlConteneur.Controls.Add(lb)
                    LstControlImpression.Add(lb)
                    lb.AllowDrop = True
                    lb.BringToFront()
                    AddHandler lb.MouseDown, AddressOf Label1_MouseDown
                    AddHandler lb.DragEnter, AddressOf Form4_DragEnter
                    AddHandler lb.DragDrop, AddressOf Form4_DragDrop
                    lb.ContextMenu = popMenu
                End If
            Next
        End If
    End Sub

    Private Sub SelectObj(ByVal sender As Object, ByVal e As EventArgs)
        Me.PropertyGrid1.SelectedObject = sender
        If TypeOf sender Is Control Then
            Me.TextBox1.Text = CType(sender, Control).Text
        End If
    End Sub


    Private Sub Label1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            'If LstObj.Contains(sender) = False Then
            '    LstObj.Add(sender)
            'End If
            'Me.PropertyGrid1.SelectedObjects = LstObj.ToControls
            'Me.PropertyGrid1.SelectedObject = sender
        Else
            ptDec = New Point(e.X, e.Y)
            ptDepart = New Point
            'ptDepart = Me.PointToClient(Me.MousePosition)
            ptDepart = New Point(Me.PointToClient(Me.MousePosition).X, Me.PointToClient(Me.MousePosition).Y)
            If Me.LstObj.Count = 0 Then
                Me.PropertyGrid1.SelectedObject = sender
                If TypeOf sender Is Control Then
                    Me.TextBox1.Text = CType(sender, Control).Text
                End If
            End If
            CType(sender, Control).DoDragDrop(sender, DragDropEffects.Move)
        End If
    End Sub

    Private Sub Form4_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PlConteneur.DragEnter, PlEnTete.DragEnter, PlBody.DragEnter, PlPied.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub Form4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PlConteneur.DragDrop, PlEnTete.DragDrop, PlBody.DragDrop, PlPied.DragDrop
        Dim Lb As Control
        Lb = CType(e.Data.GetData(e.Data.GetFormats()(0), True), ObjetsImp)

        Dim ctl As Control
        For Each ctl In LstObj
            ctl.Left = Lb.Left + (Me.PointToClient(New Point(e.X, e.Y)).X - ptDepart.X - Me.PlConteneur.Left)
            ctl.Top = Lb.Top + (Me.PointToClient(New Point(e.X, e.Y)).Y - ptDepart.Y - Me.PlConteneur.Top)
        Next
        Lb.Left = Me.PointToClient(New Point(e.X, e.Y)).X - ptDec.X - Me.PlConteneur.Left
        Lb.Top = Me.PointToClient(New Point(e.X, e.Y)).Y - ptDec.Y - Me.PlConteneur.Top
    End Sub

    Private Sub BtSerialise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSerialise.Click
        ''Dim xsLst As New Xml.Serialization.XmlSerializer(GetType(LstControlSerialisable))

        ''Dim swLst As New IO.StreamWriter(Application.StartupPath & "\TestLst.xml")
        'Dim lstCtl As New LstControlSerialisable
        'Dim ps As New SerialisableControl
        'ps.Affecte(Me.Label1)
        If Me.SaveFileDialog1.ShowDialog() <> DialogResult.OK Then Exit Sub

        'If MsgBox("Attention vous-allez remplacer le schéma précédent.") <> MsgBoxResult.OK Then Exit Sub

        Dim swBin As New IO.FileStream(Me.SaveFileDialog1.FileName, IO.FileMode.Create)
        Dim oBin As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        'Dim xmlSoap As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter
        'Dim Fl As New IO.FileStream(Application.StartupPath & "\TestSoap.xml", IO.FileMode.Create)

        'lstCtl.Add(ps)

        Dim Lst As New LstControlSerialisable
        Dim sw As SerialisableControl
        Dim ctl As Object
        For Each ctl In Me.LstControlImpression
            sw = New SerialisableControl
            sw.Affecte(CType(ctl, Control))
            Lst.Add(sw)
        Next

        'xmlSoap.Serialize(Fl, Lst)
        'Fl.Close()

        oBin.Serialize(swBin, Lst)
        swBin.Close()


        'xsLst.Serialize(swLst, lstCtl)
        'swLst.Close()


        'Dim xs As New Xml.Serialization.XmlSerializer(GetType(SerialisableControl))
        'Dim sw As New IO.StreamWriter(Application.StartupPath & "\Test.xml")
        ''ps.Nom = Me.Label1.Text
        '''ps.Font = Me.Label1.Font
        '''me.Label1.Font.
        ''ps.BackColor = Me.Label1.BackColor.ToArgb
        ''ps.Position = Me.Label1.Location
        'xs.Serialize(sw, ps)
        'sw.Close()
    End Sub

    Private Sub BtDdeserialise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDdeserialise.Click
        If Me.OpenFileDialog1.ShowDialog <> DialogResult.OK Then Exit Sub

        Dim mFile As New System.IO.FileStream(Me.OpenFileDialog1.FileName, IO.FileMode.Open)
        Dim ms As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim lstLecture As New LstControlSerialisable
        lstLecture = CType(ms.Deserialize(mFile), LstControlSerialisable)

        'Dim fl As New System.io.FileStream(Application.StartupPath & "\TestSoap.xml", IO.FileMode.Open)
        'Dim xmlSoap As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter

        'Me.LstControlImpression = CType(xmlSoap.Deserialize(fl), LstControlSerialisable)

        Dim ctl As SerialisableControl
        For Each ctl In lstLecture
            Dim lb As New ObjetsImp
            ctl.Recup(CType(lb, ObjetsImp))
            Me.PlConteneur.Controls.Add(lb)
            lb.AllowDrop = True
            Me.LstControlImpression.Add(lb)
            lb.BringToFront()
            lb.AllowDrop = True
            AddHandler lb.MouseDown, AddressOf Label1_MouseDown
            AddHandler lb.DragEnter, AddressOf Form4_DragEnter
            AddHandler lb.DragDrop, AddressOf Form4_DragDrop
            lb.ContextMenu = popMenu
        Next

        'fl.Close()
        mFile.Close()

        'Dim xs As New Xml.Serialization.XmlSerializer(GetType(SerialisableControl))
        'Dim sw As New IO.StreamReader(Application.StartupPath & "\Test.xml")
        'Dim ps As SerialisableControl
        'ps = CType(xs.Deserialize(sw), SerialisableControl)
        'ps.Recup(CType(Me.Label1, Object))
        ''Me.Label1.Text = ps.Nom
        '''Me.Label1.Font = ps.Font
        ''Me.Label1.BackColor = Color.FromArgb(ps.BackColor)
        ''Me.Label1.Location = ps.Position
        'sw.Close()
    End Sub


    Private Sub PrintePage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles doc.PrintPage
        Dim ctl As Control
        For Each ctl In Me.PlConteneur.Controls
            If TypeOf ctl Is ObjetsImp Then
                Dim lb As ObjetsImp
                lb = CType(ctl, ObjetsImp)
                Dim rtF As New RectangleF(lb.Left, lb.Top, lb.Width, lb.Height)
                Dim ft As New StringFormat
                'lb.Calcul()
                Select Case lb.TextAlign
                    Case ContentAlignment.MiddleCenter
                        ft.Alignment = StringAlignment.Center
                    Case ContentAlignment.MiddleLeft
                        ft.Alignment = StringAlignment.Near
                    Case ContentAlignment.MiddleRight
                        ft.Alignment = StringAlignment.Far
                End Select
                If lb.BackColor.ToArgb <> Me.BackColor.ToArgb Then
                    e.Graphics.FillRectangle(New SolidBrush(lb.BackColor), rtF)
                End If
                If lb.BorderStyle <> BorderStyle.None Then
                    e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rtF))
                End If
                If Not lb.Image Is Nothing Then
                    e.Graphics.DrawImage(lb.Image, lb.Left, lb.Top, lb.Width, lb.Height)
                End If
                e.Graphics.DrawString(lb.Valeur, lb.Font, New SolidBrush(lb.ForeColor), rtF, ft)
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Preview()
    End Sub

    Private Sub popMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles popMenu.Popup
        If LstObj.Contains(CType(sender, ContextMenu).SourceControl) = True Then
            CType(sender, ContextMenu).MenuItems(0).Text = "DéSelectionner"
        Else
            CType(sender, ContextMenu).MenuItems(0).Text = "Selectionner"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim obj As Object
        For Each obj In Me.PropertyGrid1.SelectedObjects
            If TypeOf obj Is Control Then
                CType(obj, Control).Text = CType(sender, TextBox).Text
            End If
        Next
    End Sub
End Class

<Serializable(), XmlRoot("LstControlSerialisable")> _
Public Class LstControlSerialisable
    Inherits CollectionBase

    Public Function Contains(ByVal value As Object) As Boolean
        Return Me.List.Contains(value)
    End Function

    Public Sub Add(ByVal Value As Object)
        Me.List.Add(Value)
    End Sub

    Public Sub Remove(ByVal value As Object)
        Me.List.Remove(value)
    End Sub

End Class

<Serializable(), XmlRoot("SerialisableControl")> _
Public Class SerialisableControl
    Private _Text As String
    Private _TextAlign As ContentAlignment
    Private _Font As Font
    Private _BackColor As Integer
    Private _ForeColor As Integer
    Private _Location As Point
    Private _Size As Size
    Private _BorderStyle As BorderStyle
    Private _Nom As String
    Private _Expression As String
    Private _Format As String
    'Private _FontName As String
    'Private _FontSize As Single
    'Private _FontStyle As FontStyle
    'Private _FontUnit As GraphicsUnit

    Public Shared Sub CopyProperty(ByRef source As Control, ByRef destination As Control)
        Dim ctl As Control
        Dim lb As ObjetsImp
        Dim ctl1 As ObjetsImp
        ctl = CType(destination, Control)
        If TypeOf ctl Is ObjetsImp Then
            lb = CType(source, ObjetsImp)
            ctl1 = CType(ctl, ObjetsImp)
            ctl1.TextAlign = lb.TextAlign
            ctl1.BorderStyle = lb.BorderStyle
            ctl1.AllowDrop = True
            ctl1.Expression = lb.Expression
            ctl1.Nom = lb.Nom
            ctl1.Format = lb.Format
        End If
        ctl.Text = source.Text
        ctl.ForeColor = Color.FromArgb(source.ForeColor.ToArgb)
        ctl.BackColor = Color.FromArgb(source.BackColor.ToArgb)
        ctl.Location = source.Location
        ctl.Size = source.Size
        ctl.Font = source.Font
    End Sub


    Public Property BorderStyle() As BorderStyle
        Get
            Return _BorderStyle
        End Get
        Set(ByVal Value As BorderStyle)
            _BorderStyle = Value
        End Set
    End Property

    Public Sub Affecte(ByVal Obj As Object)
        Dim ctl As Control
        Dim lb As ObjetsImp
        ctl = CType(Obj, Control)
        If TypeOf ctl Is ObjetsImp Then
            lb = CType(Obj, ObjetsImp)
            _TextAlign = lb.TextAlign
            _BorderStyle = lb.BorderStyle
            lb.AllowDrop = True
            _Nom = lb.Nom
            _Expression = lb.Expression
            _Format = lb.Format
        End If
        _Text = ctl.Text
        _BackColor = ctl.BackColor.ToArgb
        _ForeColor = ctl.ForeColor.ToArgb
        _Location = ctl.Location
        _Size = ctl.Size
        _Font = ctl.Font
        '_FontName = ctl.Font.Name
        '_FontSize = ctl.Font.Size
        '_FontStyle = ctl.Font.Style
        '_FontUnit = ctl.Font.Unit
    End Sub

    Public Sub Recup(ByRef Obj As Object)
        Dim ctl As Control
        Dim lb As ObjetsImp
        ctl = CType(Obj, Control)
        If TypeOf ctl Is ObjetsImp Then
            lb = CType(Obj, ObjetsImp)
            lb.TextAlign = _TextAlign
            lb.BorderStyle = _BorderStyle
            lb.Expression = _Expression
            lb.Nom = _Nom
            lb.Format = _Format
        End If
        ctl.Text = _Text
        ctl.ForeColor = Color.FromArgb(_ForeColor)
        ctl.BackColor = Color.FromArgb(_BackColor)
        ctl.Location = _Location
        ctl.Size = _Size
        ctl.Font = _Font
        'ctl.Font = New Font(_FontName, _FontSize, _FontStyle, _FontUnit)
    End Sub

    Public Property Font() As Font
        Get
            Return _Font
        End Get
        Set(ByVal Value As Font)
            _Font = Value
        End Set
    End Property

    Public Property Nom() As String
        Get
            Return _Nom
        End Get
        Set(ByVal Value As String)
            _Nom = Value
        End Set
    End Property

    Public Property Expression() As String
        Get
            Return _Expression
        End Get
        Set(ByVal Value As String)
            _Expression = Value
        End Set
    End Property

    Public Property Format() As String
        Get
            Return _Format
        End Get
        Set(ByVal Value As String)
            _Format = Value
        End Set
    End Property

    'Public Property FontName() As String
    '    Get
    '        Return _FontName
    '    End Get
    '    Set(ByVal Value As String)
    '        _FontName = Value
    '    End Set
    'End Property

    'Public Property FontSize() As Single
    '    Get
    '        Return _FontSize
    '    End Get
    '    Set(ByVal Value As Single)
    '        _FontSize = Value
    '    End Set
    'End Property

    'Public Property FontStyle() As FontStyle
    '    Get
    '        Return _FontStyle
    '    End Get
    '    Set(ByVal Value As FontStyle)
    '        _FontStyle = Value
    '    End Set
    'End Property

    'Public Property FontUnit() As GraphicsUnit
    '    Get
    '        Return _FontUnit
    '    End Get
    '    Set(ByVal Value As GraphicsUnit)
    '        _FontUnit = Value
    '    End Set
    'End Property

    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal Value As String)
            _Text = Value
        End Set
    End Property

    Public Property TextAlign() As ContentAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            _TextAlign = Value
        End Set
    End Property

    Public Property ForeColor() As Integer
        Get
            Return _ForeColor
        End Get
        Set(ByVal Value As Integer)
            _ForeColor = Value
        End Set
    End Property

    'Public Property Font() As Font
    '    Get
    '        Return _Font
    '    End Get
    '    Set(ByVal Value As Font)
    '        _Font = Value
    '    End Set
    'End Property

    Public Property BackColor() As Integer
        Get
            Return _BackColor
        End Get
        Set(ByVal Value As Integer)
            _BackColor = Value
        End Set
    End Property

    Public Property Size() As Size
        Get
            Return _Size
        End Get
        Set(ByVal Value As Size)
            _Size = Value
        End Set
    End Property

    Public Property Position() As Point
        Get
            Return _Location
        End Get
        Set(ByVal Value As Point)
            _Location = Value
        End Set
    End Property

End Class

Public Class LstControl
    Inherits CollectionBase

    Public Function Contains(ByVal Ctl As Object) As Boolean
        Return Me.List.Contains(Ctl)
    End Function

    Public Sub Add(ByVal Ctl As Object)
        Me.List.Add(Ctl)
    End Sub

    Public Sub Remove(ByVal ctl As Object)
        Me.List.Remove(ctl)
    End Sub

    Public Function GetControl(ByVal i As Integer) As Control
        Return CType(Me.List(i), Control)
    End Function

    Public Function ToControls() As Control()
        Dim Ctl(Me.List.Count - 1) As Control
        Dim i As Integer
        For i = 0 To Me.List.Count - 1
            Ctl(i) = CType(Me.List(i), Control)
        Next
        Return Ctl
    End Function

End Class
