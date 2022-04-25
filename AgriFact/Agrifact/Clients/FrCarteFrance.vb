Public Class FrCarteFrance
    Inherits System.Windows.Forms.Form
    Private lstDepartement As Departements
    'Dim g As Graphics
    Dim lstSelectionDepart As New ArrayList
    Public Event Selection(ByVal lstDep As ArrayList)


    Public Sub New(ByVal lstDepSelection As ArrayList)
        Me.New()
        lstSelectionDepart = lstDepSelection
    End Sub

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
    Friend WithEvents TxScX As System.Windows.Forms.TextBox
    Friend WithEvents TxScY As System.Windows.Forms.TextBox
    Friend WithEvents TxY As System.Windows.Forms.TextBox
    Friend WithEvents TxX As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ckAfficheDepartement As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxScX = New System.Windows.Forms.TextBox
        Me.TxScY = New System.Windows.Forms.TextBox
        Me.TxY = New System.Windows.Forms.TextBox
        Me.TxX = New System.Windows.Forms.TextBox
        Me.ckAfficheDepartement = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Afficher"
        Me.Button1.Visible = False
        '
        'TxScX
        '
        Me.TxScX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxScX.Location = New System.Drawing.Point(0, 32)
        Me.TxScX.Name = "TxScX"
        Me.TxScX.Size = New System.Drawing.Size(96, 20)
        Me.TxScX.TabIndex = 1
        Me.TxScX.Text = "0,0005"
        Me.TxScX.Visible = False
        '
        'TxScY
        '
        Me.TxScY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxScY.Location = New System.Drawing.Point(0, 56)
        Me.TxScY.Name = "TxScY"
        Me.TxScY.Size = New System.Drawing.Size(96, 20)
        Me.TxScY.TabIndex = 2
        Me.TxScY.Text = "-0,0005"
        Me.TxScY.Visible = False
        '
        'TxY
        '
        Me.TxY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxY.Location = New System.Drawing.Point(0, 104)
        Me.TxY.Name = "TxY"
        Me.TxY.Size = New System.Drawing.Size(96, 20)
        Me.TxY.TabIndex = 4
        Me.TxY.Text = "-2680000"
        Me.TxY.Visible = False
        '
        'TxX
        '
        Me.TxX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxX.Location = New System.Drawing.Point(0, 80)
        Me.TxX.Name = "TxX"
        Me.TxX.Size = New System.Drawing.Size(96, 20)
        Me.TxX.TabIndex = 3
        Me.TxX.Text = "-71000"
        Me.TxX.Visible = False
        '
        'ckAfficheDepartement
        '
        Me.ckAfficheDepartement.Location = New System.Drawing.Point(80, 0)
        Me.ckAfficheDepartement.Name = "ckAfficheDepartement"
        Me.ckAfficheDepartement.Size = New System.Drawing.Size(152, 16)
        Me.ckAfficheDepartement.TabIndex = 5
        Me.ckAfficheDepartement.Text = "AfficheNomDepartement"
        Me.ckAfficheDepartement.Visible = False
        '
        'FrCarteFrance
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(520, 542)
        Me.Controls.Add(Me.ckAfficheDepartement)
        Me.Controls.Add(Me.TxY)
        Me.Controls.Add(Me.TxX)
        Me.Controls.Add(Me.TxScY)
        Me.Controls.Add(Me.TxScX)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrCarteFrance"
        Me.Text = "Carte de France"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChargerDeps()
    End Sub

    Private Sub ChargerDeps()
        lstDepartement = New Departements
        Dim g As Graphics = Me.CreateGraphics

        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

        'Dim im As New Drawing.Bitmap(Application.StartupPath & "\FranceR3.GIF")
        Dim brFrance As New TextureBrush(My.Resources.FranceR3)

        g.ScaleTransform(Convert.ToSingle(TxScX.Text), Convert.ToSingle(TxScY.Text))
        g.TranslateTransform(Convert.ToSingle(TxX.Text), Convert.ToSingle(TxY.Text))

        'Dim stN As New IO.StreamReader(New IO.FileStream(Application.StartupPath & "\dep_france_dom.mid", IO.FileMode.Open))
        Dim stNomsDep As New IO.StreamReader(asm.GetManifestResourceStream("AgriFact.dep_france_dom.mid"))
        Dim LstDep As New Hashtable
        Dim nDep As Integer = 0
        Dim ln As String = stNomsDep.ReadLine
        While Not ln Is Nothing
            Dim line() As String = ln.Split(","c)
            nDep += 1
            LstDep.Add(nDep, line)
            ln = stNomsDep.ReadLine
        End While
        stNomsDep.Close()


        Dim NumberFormat As Globalization.NumberFormatInfo = CType(Application.CurrentCulture.NumberFormat.Clone, Globalization.NumberFormatInfo)
        NumberFormat.NumberDecimalSeparator = "."c

        'Dim st As New IO.StreamReader(New IO.FileStream(Application.StartupPath & "\dep_france_dom.mif", IO.FileMode.Open))
        Dim stPoints As New IO.StreamReader(asm.GetManifestResourceStream("AgriFact.dep_france_dom.mif"))
        Dim lstPt As ArrayList
        Dim nbRegions As Integer = 0
        'Dim RegionOn As Boolean = False
        Dim DoitLireNbPoint As Boolean = False
        Dim NbPointRegion As Long
        Dim DepEnCours As Departement


        nDep = 0
        ln = stPoints.ReadLine
        While Not ln Is Nothing
            Dim values() As String = ln.Split(" "c)
            If Not values Is Nothing Then
                If NbPointRegion = 0 Then
                    If values(0) = "Region" Then
                        'Init du département
                        nDep += 1
                        Dim infosDep() As String = CType(LstDep(nDep), String())
                        Dim PtsTmp() As PointF = New PointF() {New PointF(Convert.ToSingle(infosDep(ColDep.XChefLieu) & "00"), Convert.ToSingle(infosDep(ColDep.YChefLieu) & "00"))}
                        g.Transform.TransformPoints(PtsTmp)

                        DepEnCours = New Departement
                        With DepEnCours
                            .NomDepartement = infosDep(ColDep.NomDepartement).Trim(Chr(34))
                            .NDepartement = infosDep(ColDep.CodeDepartement).Trim(Chr(34))
                            .NRegion = infosDep(ColDep.CodeRegion).Trim(Chr(34))
                            .NomRegion = infosDep(ColDep.NomRegion).Trim(Chr(34))
                            .NomChefLieu = infosDep(ColDep.NomChefLieu).Trim(Chr(34))
                            .XChefLieu = PtsTmp(0).X
                            .YChefLieu = PtsTmp(0).Y
                            .PtChefLieu = PtsTmp(0)
                            .Selected = lstSelectionDepart.Contains(.NDepartement)
                        End With

                        nbRegions = Convert.ToInt32(values(2))
                        DoitLireNbPoint = True
                    Else
                        If DoitLireNbPoint Then
                            NbPointRegion = Long.Parse(values(2))
                            DoitLireNbPoint = False
                            lstPt = New ArrayList
                        End If
                    End If
                Else 'On doit lire des points
                    'If Convert.ToSingle(values(0).Replace("."c, ","c)) = 0 Then
                    '    MsgBox("Bizarre")
                    'End If
                    'Dim pt As New PointF(Convert.ToSingle(a(0).Replace("."c, ","c)), Convert.ToSingle(a(1).Replace("."c, ","c)))
                    'Dim pt As New Point(Convert.ToInt32(Convert.ToSingle(values(0).Replace("."c, ","c)).ToString("0")), Convert.ToInt32(Convert.ToSingle(values(1).Replace("."c, ","c)).ToString("0")))
                    lstPt.Add(New Point(CInt(Single.Parse(values(0), NumberFormat)), CInt(Single.Parse(values(1), NumberFormat))))

                    NbPointRegion -= 1
                    If NbPointRegion = 0 Then 'On a lus tous les points, on crée le poly
                        'Dim pts(lstPt.Count - 1) As Point
                        'lstPt.CopyTo(pts)
                        Dim pts() As Point = CType(lstPt.ToArray(GetType(Point)), Point())
                        g.Transform.TransformPoints(pts)

                        Dim path As New Drawing2D.GraphicsPath
                        path.AddLines(pts)
                        With DepEnCours
                            If .Paths.Count = 0 Then
                                .AddPath(path)
                                .Brush = brFrance
                                Me.ToolTip1.SetToolTip(DepEnCours, .NomRegion & vbCrLf & .NomDepartement & " (" & .NDepartement & ")" & vbCrLf & .NomChefLieu)
                                Me.Controls.Add(DepEnCours)
                            End If
                        End With

                        nbRegions -= 1

                        If nbRegions > 0 Then
                            'Il reste des régions => On passe à la lecture du nb de points
                            DoitLireNbPoint = True
                        Else 'Sinon le département est fini
                            lstDepartement.Add(DepEnCours)
                        End If
                    End If
                End If
            End If
            ln = stPoints.ReadLine
        End While

        stPoints.Close()

    End Sub



#Region "A VIRER"
    'Private Sub FrCarteFrance_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
    '    If Me.ckAfficheDepartement.Checked Then
    '        Me.ToolTip1.SetToolTip(Me, "")

    '        'Dim Pts() As Point = New Point() {New Point(e.X, e.Y)}
    '        'g.Transform.TransformPoints(Pts)
    '        'g.TransformPoints(Drawing2D.CoordinateSpace.World, Drawing2D.CoordinateSpace.Page, Pts)

    '        Dim n As Integer = 0
    '        For Each dep As Departement In Me.lstDepartement
    '            n += 1
    '            If dep.PtIn(Convert.ToInt32(g.VisibleClipBounds.Width / Me.Width * e.X + g.VisibleClipBounds.X), Convert.ToInt32(g.VisibleClipBounds.Height / Me.Height * e.Y + g.VisibleClipBounds.Y)) = True Then
    '                Me.ToolTip1.SetToolTip(Me, "Ok")
    '                Exit For
    '            End If
    '        Next
    '    End If
    'End Sub

    'Dim xDep As Int32
    'Dim yDep As Int32

    'Private Sub FrCarteFrance_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
    '    ''Dim dep As Departement
    '    'Me.ToolTip1.SetToolTip(Me, "")

    '    ''Dim Pts() As Point = New Point() {New Point(e.X, e.Y)}
    '    ''g.Transform.TransformPoints(Pts)
    '    ''g.TransformPoints(Drawing2D.CoordinateSpace.World, Drawing2D.CoordinateSpace.Page, Pts)
    '    'Dim x As Integer
    '    'Dim y As Integer
    '    'x = Convert.ToInt32(g.VisibleClipBounds.Width / Me.Width * e.X + g.VisibleClipBounds.X)
    '    'y = Convert.ToInt32(g.VisibleClipBounds.Height / Me.Height * e.Y + g.VisibleClipBounds.Y)
    '    'xDep = x
    '    'yDep = y
    '    'Exit Sub
    '    'Me.Text = "Started"
    '    'Dim n As Integer = 0
    '    'For n = 0 To Me.lstDepartement.Count - 1
    '    '    If lstDepartement(n).PtIn(x, y) = True Then
    '    '        Me.ToolTip1.SetToolTip(Me, "Ok")
    '    '        Exit For
    '    '    End If
    '    'Next
    '    'Me.Text = "Fin"


    '    ''MsgBox(g.DpiX.ToString & "|" & g.DpiY.ToString & vbCrLf & g.Transform.OffsetX & "|" & g.Transform.OffsetY)
    '    ''MsgBox(g.IsVisible(e.X, e.Y).ToString)
    '    ''Dim str As String = ""
    '    ''str += g.VisibleClipBounds.X & ";"
    '    ''str += g.VisibleClipBounds.Y & ";"
    '    ''str += g.VisibleClipBounds.Height & ";"
    '    ''str += g.VisibleClipBounds.Width & vbCrLf
    '    ''str += g.DpiX.ToString & ";" & g.DpiY.ToString & vbCrLf
    '    ''str += Me.Width & ";" & Me.Height
    '    ''str += "x=" & e.X & ";y=" & e.Y
    '    ''MsgBox(str)
    'End Sub
#End Region

    Private Sub FrCarteFrance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChargerDeps()
    End Sub

    Private Sub FrCarteFrance_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not lstDepartement Is Nothing Then
            Dim d As Departement
            Dim lstDepSelection As New ArrayList
            For Each d In lstDepartement
                If d.Selected = True Then
                    lstDepSelection.Add(d.NDepartement)
                End If
            Next
            RaiseEvent Selection(lstDepSelection)
        End If
    End Sub

    'Private Sub FrCarteFrance_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    Me.Button1_Click(sender, e)
    'End Sub


#Region "Classes Util"
    Public Class Departement
        Inherits Control
        Private _Paths As New GraphicsPathCollection
        Private _Region As String = ""
        Private _Departement As String = ""
        Private _NDepartement As String = ""
        Private _ChefLieu As String = ""
        Private _XChefLieu As Single
        Private _YChefLieu As Single
        Private _PtChefLieu As PointF
        Private _NRegion As String = ""
        Private _Brush As Brush
        Private _Pen As Pen
        Private _Selected As Boolean = False
        Private _SelectedBrush As New SolidBrush(Color.FromArgb(150, 150, 150, 0))

#Region "Propriétés"
        Public Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal Value As Boolean)
                _Selected = Value
            End Set
        End Property

        Public Property PtChefLieu() As PointF
            Get
                Return _PtChefLieu
            End Get
            Set(ByVal Value As PointF)
                _PtChefLieu = Value
            End Set
        End Property

        Public Property NomChefLieu() As String
            Get
                Return _ChefLieu
            End Get
            Set(ByVal Value As String)
                _ChefLieu = Value
            End Set
        End Property

        Public Property XChefLieu() As Single
            Get
                Return _XChefLieu
            End Get
            Set(ByVal Value As Single)
                _XChefLieu = Value
            End Set
        End Property

        Public Property YChefLieu() As Single
            Get
                Return _YChefLieu
            End Get
            Set(ByVal Value As Single)
                _YChefLieu = Value
            End Set
        End Property

        Public Property NDepartement() As String
            Get
                Return _NDepartement
            End Get
            Set(ByVal Value As String)
                _NDepartement = Value
            End Set
        End Property

        Public Property NRegion() As String
            Get
                Return _NRegion
            End Get
            Set(ByVal Value As String)
                _NRegion = Value
            End Set
        End Property

        Public Property Brush() As Brush
            Get
                Return _Brush
            End Get
            Set(ByVal Value As Brush)
                _Brush = Value
            End Set
        End Property

        Public Property Paths() As GraphicsPathCollection
            Get
                Return _Paths
            End Get
            Set(ByVal Value As GraphicsPathCollection)
                _Paths = Value
                MyBase.Region = New Region(_Paths(0))
            End Set
        End Property

        Public Property NomRegion() As String
            Get
                Return _Region
            End Get
            Set(ByVal Value As String)
                _Region = Value
            End Set
        End Property

        Public Property NomDepartement() As String
            Get
                Return _Departement
            End Get
            Set(ByVal Value As String)
                _Departement = Value
            End Set
        End Property

#End Region

        Public Sub AddPath(ByVal path As Drawing2D.GraphicsPath)
            _Paths.Add(path)
            Me.Region = New Region(_Paths(0))
        End Sub

        Public Sub New()
            Me.Top = 0
            Me.Left = 0
            Me.Dock = DockStyle.Fill
            Me.Visible = True
            _Pen = New Pen(Color.Black, 1)
        End Sub

        Public Function PtIn(ByVal x As Integer, ByVal y As Integer) As Boolean
            Return _Paths(0).IsVisible(x, y)
        End Function

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            'MyBase.InvokePaintBackground(Me, pevent)
            'pevent.Graphics.Clear(Me.BackColor)
            If Not Me.Region Is Nothing Then
                pevent.Graphics.FillRegion(_Brush, Me.Region)
            End If
            If Selected = True Then
                pevent.Graphics.FillRegion(_SelectedBrush, Me.Region)
            End If
            If Not Me.Paths(0) Is Nothing Then
                pevent.Graphics.DrawPath(_Pen, Me.Paths(0))
            End If
            If Not _PtChefLieu.IsEmpty Then
                pevent.Graphics.FillEllipse(New SolidBrush(Color.Black), New RectangleF(_PtChefLieu, New SizeF(3, 3)))
            End If
        End Sub

        Private Sub Departement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            Me.Selected = Not Me.Selected
            Me.Refresh()
        End Sub
    End Class

    Public Enum ColDep
        Id = 0
        CodeChefLieu = 1
        NomChefLieu = 2
        XChefLieu = 3
        YChefLieu = 4
        XCentroide = 5
        YCentroide = 6
        NomDepartement = 7
        CodeRegion = 8
        NomRegion = 9
        CodeDepartement = 10
    End Enum


    Public Class Departements
        Inherits CollectionBase

        Public Function Add(ByVal Dep As Departement) As Departement
            Me.List.Add(Dep)
            Return Dep
        End Function

        Default Public ReadOnly Property Item(ByVal iIndex As Int32) As Departement
            Get
                Return CType(Me.List.Item(iIndex), Departement)
            End Get
        End Property
    End Class

    Public Class GraphicsPathCollection
        Inherits CollectionBase

        Public Function Add(ByVal Path As Drawing2D.GraphicsPath) As Drawing2D.GraphicsPath
            Me.List.Add(Path)
            Return Path
        End Function

        Default Public ReadOnly Property Item(ByVal iIndex As Int32) As Drawing2D.GraphicsPath
            Get
                Return CType(Me.List.Item(iIndex), Drawing2D.GraphicsPath)
            End Get
        End Property
    End Class
#End Region

End Class
