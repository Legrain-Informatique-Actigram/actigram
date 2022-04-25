Imports System.Runtime.InteropServices

Public Class MoveControl

    Private _Ctrl As Control
    Private _AllowMoving As Boolean = True
    Private _AllowResizeFlags As ResizeDirection = ResizeDirection.Bottom Or _
                                                    ResizeDirection.BottomLeft Or _
                                                    ResizeDirection.BottomRight Or _
                                                    ResizeDirection.Left Or _
                                                    ResizeDirection.Right Or _
                                                    ResizeDirection.Top Or _
                                                    ResizeDirection.TopLeft Or _
                                                    ResizeDirection.TopRight
    'Width of the 'resizable border', the area where you can resize.
    Private Const BorderWidth As Integer = 2
    Private _ResizeDir As ResizeDirection = ResizeDirection.None

    <Flags()> _
    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 4
        TopRight = 8
        Right = 16
        BottomRight = 32
        Bottom = 64
        BottomLeft = 128
    End Enum

#Region "Constructeurs"
    Public Sub New(ByVal ctrl As Control)
        Me._Ctrl = ctrl

        If Me._Ctrl IsNot Nothing Then
            AddHandler Me._Ctrl.MouseDown, AddressOf MouseDown
            AddHandler Me._Ctrl.MouseMove, AddressOf MouseMove
        Else
            Throw New ArgumentException("Object 'ctrl' not set to any control.")
        End If
    End Sub
#End Region

#Region "Propriétés"
    Public Property AllowMoving() As Boolean
        Get
            Return Me._AllowMoving
        End Get
        Set(ByVal value As Boolean)
            Me._AllowMoving = value
        End Set
    End Property

    Public Property AllowResizeFlags() As ResizeDirection
        Get
            Return Me._AllowResizeFlags
        End Get
        Set(ByVal value As ResizeDirection)
            Me._AllowResizeFlags = value
        End Set
    End Property

    Private Property resizeDir() As ResizeDirection
        Get
            Return Me._ResizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            Me._ResizeDir = value
            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Me._Ctrl.Cursor = Cursors.SizeWE
                Case ResizeDirection.Right
                    Me._Ctrl.Cursor = Cursors.SizeWE
                Case ResizeDirection.Top
                    Me._Ctrl.Cursor = Cursors.SizeNS
                Case ResizeDirection.Bottom
                    Me._Ctrl.Cursor = Cursors.SizeNS
                Case ResizeDirection.BottomLeft
                    Me._Ctrl.Cursor = Cursors.SizeNESW
                Case ResizeDirection.TopRight
                    Me._Ctrl.Cursor = Cursors.SizeNESW
                Case ResizeDirection.BottomRight
                    Me._Ctrl.Cursor = Cursors.SizeNWSE
                Case ResizeDirection.TopLeft
                    Me._Ctrl.Cursor = Cursors.SizeNWSE
                Case Else
                    Me._Ctrl.Cursor = Cursors.Default
            End Select
        End Set
    End Property
#End Region

#Region " Functions and Constants "
    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
#End Region

#Region " Moving & Resizing methods "
    Private Sub MoveControl(ByVal hWnd As IntPtr)
        ReleaseCapture()
        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Private Sub ResizeControl(ByVal hWnd As IntPtr, ByVal direction As ResizeDirection)
        Dim dir As Integer = -1
        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select

        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(hWnd, WM_NCLBUTTONDOWN, dir, 0)
        End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Location.X < BorderWidth And e.Location.Y < BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.TopLeft) = ResizeDirection.TopLeft Then resizeDir = ResizeDirection.TopLeft
        ElseIf e.Location.X < BorderWidth And e.Location.Y > _Ctrl.Height - BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.BottomLeft) = ResizeDirection.BottomLeft Then resizeDir = ResizeDirection.BottomLeft
        ElseIf e.Location.X > _Ctrl.Width - BorderWidth And e.Location.Y > _Ctrl.Height - BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.BottomRight) = ResizeDirection.BottomRight Then resizeDir = ResizeDirection.BottomRight
        ElseIf e.Location.X > _Ctrl.Width - BorderWidth And e.Location.Y < BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.TopRight) = ResizeDirection.TopRight Then resizeDir = ResizeDirection.TopRight
        ElseIf e.Location.X < BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.Left) = ResizeDirection.Left Then resizeDir = ResizeDirection.Left
        ElseIf e.Location.X > _Ctrl.Width - BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.Right) = ResizeDirection.Right Then resizeDir = ResizeDirection.Right
        ElseIf e.Location.Y < BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.Top) = ResizeDirection.Top Then resizeDir = ResizeDirection.Top
        ElseIf e.Location.Y > _Ctrl.Height - BorderWidth Then
            If (Me.AllowResizeFlags And ResizeDirection.Bottom) = ResizeDirection.Bottom Then resizeDir = ResizeDirection.Bottom
        Else
            resizeDir = ResizeDirection.None
        End If
    End Sub

    Private Sub MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If resizeDir = ResizeDirection.None Then
                If Me.AllowMoving Then MoveControl(_Ctrl.Handle)
            Else
                If (Me.AllowResizeFlags And resizeDir) = resizeDir Then ResizeControl(_Ctrl.Handle, resizeDir)
            End If
        End If
    End Sub
#End Region

End Class