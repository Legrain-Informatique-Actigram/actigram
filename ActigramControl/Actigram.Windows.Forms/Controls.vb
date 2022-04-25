Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Math

Namespace Windows.Forms

    Public Class PanelColor
        Inherits Panel
        Private _CouleurDebut As Color
        Private _CouleurFin As Color
        Private _Orientation As System.Drawing.Drawing2D.LinearGradientMode
        Friend _rt As RectangleF

#Region "Propriété"

        <Category("PersoPanelColor")> _
        Public Property CouleurDebut() As Color
            Get
                Return _CouleurDebut
            End Get
            Set(ByVal Value As Color)
                _CouleurDebut = Value
            End Set
        End Property

        <Category("PersoPanelColor")> _
        Public Property CouleurFin() As Color
            Get
                Return _CouleurFin
            End Get
            Set(ByVal Value As Color)
                _CouleurFin = Value
            End Set
        End Property

        <Category("PersoPanelColor")> _
        Public Property Orientation() As System.Drawing.Drawing2D.LinearGradientMode
            Get
                Return _Orientation
            End Get
            Set(ByVal Value As System.Drawing.Drawing2D.LinearGradientMode)
                _Orientation = Value
            End Set
        End Property


#End Region

        Private Sub PanelColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            _rt = New RectangleF
            _rt.Location = e.Graphics.VisibleClipBounds.Location
            _rt.Size = e.Graphics.VisibleClipBounds.Size
            Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(_rt, _CouleurDebut, _CouleurFin, _Orientation)
            e.Graphics.FillRectangle(br, _rt)
        End Sub
    End Class

    Public Class LabelColor
        Inherits Label
        Private _ParentPanel As PanelColor

#Region "Propriété"


        <Category("PersoLabelColor")> _
        Public Property ParentPanelColor() As PanelColor
            Get
                Return _ParentPanel
            End Get
            Set(ByVal Value As PanelColor)
                _ParentPanel = Value
            End Set
        End Property


#End Region

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            If Not _ParentPanel Is Nothing Then
                Dim rt As New RectangleF
                rt.Height = Me.Parent.Height
                rt.Width = Me.Parent.Width
                rt.X = -Me.Left
                rt.Y = -Me.Top
                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rt, _ParentPanel.CouleurDebut, _ParentPanel.CouleurFin, _ParentPanel.Orientation)
                pevent.Graphics.FillRectangle(br, pevent.Graphics.VisibleClipBounds)
            End If
        End Sub
    End Class

End Namespace