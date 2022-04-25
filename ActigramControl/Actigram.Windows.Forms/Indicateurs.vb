Imports System.Drawing
Imports System.ComponentModel

Namespace Windows.Forms.Indicateurs

    '    Public Class IndicateurMarge
    '        Inherits System.Windows.Forms.Control

    '        Private _Objectif As Decimal = 0
    '        Private _Value As Decimal = 0

    '#Region "Propriétés"

    '        Public Property Objectif() As Decimal
    '            Get
    '                Return _Objectif
    '            End Get
    '            Set(ByVal Value As Decimal)
    '                _Objectif = Value
    '                Me.Refresh()
    '            End Set
    '        End Property

    '        Public Property Value() As Decimal
    '            Get
    '                Return _Value
    '            End Get
    '            Set(ByVal Value As Decimal)
    '                _Value = Value
    '                Me.Refresh()
    '            End Set
    '        End Property

    '        Public Property ObjectifPr100() As Decimal
    '            Get
    '                Return Objectif / 180 * 100
    '            End Get
    '            Set(ByVal Value As Decimal)
    '                Objectif = Value * 180 / 100
    '            End Set
    '        End Property

    '        Public Property ValuePr100() As Decimal
    '            Get
    '                Return Value / 180 * 100
    '            End Get
    '            Set(ByVal maValue As Decimal)
    '                Value = maValue * 180 / 100
    '            End Set
    '        End Property
    '#End Region

    '        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '            'Dim rayon As Single = 0
    '            'Dim Hauteur As Single = Me.Height * 2
    '            'rayon = Convert.ToSingle(Me.Width / 2)
    '            'e.Graphics.Clear(Me.BackColor)
    '            'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            'e.Graphics.FillPie(New SolidBrush(Drawing.Color.Red), 0, 0, Me.Width, Hauteur, 180, _Objectif)
    '            'Dim GbL As New Drawing2D.LinearGradientBrush(New PointF(rayon, 0), New PointF(Me.Width, Hauteur), Color.Green, Color.Red)
    '            'GbL.WrapMode = Drawing2D.WrapMode.TileFlipXY
    '            'e.Graphics.FillPie(GbL, 0, 0, Me.Width, Hauteur, 180 + _Objectif, 180 - _Objectif)
    '            'e.Graphics.DrawArc(New Pen(Me.ForeColor), 0, 0, Me.Width, Hauteur, 180, 180)
    '            'e.Graphics.DrawLine(New Pen(Me.ForeColor, 2), rayon, Me.Height, Convert.ToSingle(rayon - Math.Cos(_Value / 180 * Math.PI) * rayon), Convert.ToSingle(-Math.Sin(_Value / 180 * Math.PI) * Hauteur / 2))
    '            'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default

    '            Dim rayon As Single = 0
    '            Dim Hauteur As Single = Me.Height * 2
    '            rayon = Convert.ToSingle(Me.Width / 2)

    '            e.Graphics.TranslateTransform(rayon, Me.Height)
    '            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            e.Graphics.DrawLine(New Pen(Me.ForeColor, 2), 0, 0, Convert.ToSingle(-Math.Cos(_Value / 180 * Math.PI) * rayon), Convert.ToSingle(-Math.Sin(_Value / 180 * Math.PI) * Hauteur / 2))
    '            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
    '        End Sub

    '        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    '            Dim rayon As Single = 0
    '            Dim Hauteur As Single = Me.Height * 2
    '            rayon = Convert.ToSingle(Me.Width / 2)
    '            'e.Graphics.Clear(Me.BackColor)

    '            Dim Gp As New Drawing2D.GraphicsPath
    '            Dim rg As New Region(New RectangleF(0, 0, Me.Width, Me.Height))
    '            Gp.AddPie(0, 0, Me.Width, Me.Height * 2, 180, 180)
    '            rg.Exclude(Gp)
    '            pevent.Graphics.FillRegion(New SolidBrush(Me.BackColor), rg)

    '            pevent.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            pevent.Graphics.FillPie(New SolidBrush(Drawing.Color.Red), 0, 0, Me.Width, Hauteur, 180, _Objectif)
    '            'Dim GbL As New Drawing2D.LinearGradientBrush(New PointF(rayon, 0), New PointF(Me.Width, Hauteur), Color.Green, Color.Red)
    '            pevent.Graphics.TranslateTransform(rayon, Me.Height)

    '            'Dim LstPt(90) As Point
    '            Dim i As Integer = 0
    '            'For i = 0 To LstPt.GetUpperBound(0)
    '            '    LstPt(i) = New Point(Convert.ToInt32(-Math.Cos(_Objectif + (180 - _Objectif) / 10 * i / 180 * Math.PI) * rayon), Convert.ToInt32(-Math.Sin(_Objectif + (180 - _Objectif) / 10 * i / 180 * Math.PI) * Me.Height))
    '            'Next
    '            For i = Convert.ToInt32(Math.Floor(_Objectif)) To 179
    '                Dim cl As Integer
    '                cl = Convert.ToInt32(Math.Floor(((255 / (180 - _Objectif)) * (i - _Objectif))))
    '                pevent.Graphics.DrawLine(New Pen(Color.FromArgb(255, cl, 255 - cl, 0), 2), 0, 0, Convert.ToSingle(-Math.Cos(i / 180 * Math.PI) * rayon), Convert.ToSingle(-Math.Sin(i / 180 * Math.PI) * Hauteur / 2))
    '            Next

    '            pevent.Graphics.ResetTransform()

    '            '_GpL = New Drawing2D.PathGradientBrush(LstPt)
    '            '_GpL.WrapMode = _TypeDegrade
    '            '_GpL.CenterColor = Color.FromArgb(255, 0, 255, 0)
    '            '_GpL.CenterPoint = New PointF(rayon, Me.Height)

    '            'Dim LstColor(LstPt.GetUpperBound(0)) As Color
    '            'Dim Cl As Integer = Convert.ToInt32(255 / LstPt.GetUpperBound(0))
    '            'For i = 0 To LstPt.GetUpperBound(0)
    '            '    LstColor(i) = Color.FromArgb(255, Cl * i, 255 - Cl * i, 0)
    '            'Next
    '            '_GpL.CenterPoint = New PointF(rayon, Me.Height)
    '            '_GpL.CenterColor = Color.FromArgb(255, 0, 255, 0)
    '            '_GpL.SurroundColors = LstColor
    '            'e.Graphics.FillPie(_GpL, 0, 0, Me.Width, Hauteur, 180 + _Objectif, 180 - _Objectif)
    '            pevent.Graphics.DrawArc(New Pen(Me.ForeColor), 0, 0, Me.Width, Hauteur, 180, 180)
    '            'pevent.Graphics.Clear(Me.BackColor)
    '        End Sub

    '        Private Sub IndicateurMarge_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '            Me.Refresh()
    '        End Sub
    '    End Class

    '    Public Class IndicateurFeuTriColor
    '        Inherits System.Windows.Forms.Control

    '        Private _Value As Decimal = 0
    '        Private _LimiteVertOrange As Decimal = 0
    '        Private _LimiteOrangeRouge As Decimal = 0
    '        Private _Inverse As Boolean = False

    '#Region "Propriétés"

    '        <DefaultValue(False)> _
    '        Public Property Inverse() As Boolean
    '            Get
    '                Return _Inverse
    '            End Get
    '            Set(ByVal Value As Boolean)
    '                _Inverse = Value
    '                Me.Refresh()
    '            End Set
    '        End Property

    '        Public Property Value() As Decimal
    '            Get
    '                Return _Value
    '            End Get
    '            Set(ByVal maValue As Decimal)
    '                _Value = maValue
    '                Me.Refresh()
    '            End Set
    '        End Property

    '        Public Property LimiteVertOrange() As Decimal
    '            Get
    '                Return _LimiteVertOrange
    '            End Get
    '            Set(ByVal Value As Decimal)
    '                _LimiteVertOrange = Value
    '                Me.Refresh()
    '            End Set
    '        End Property

    '        Public Property LimiteOrangeRouge() As Decimal
    '            Get
    '                Return _LimiteOrangeRouge
    '            End Get
    '            Set(ByVal Value As Decimal)
    '                _LimiteOrangeRouge = Value
    '                Me.Refresh()
    '            End Set
    '        End Property
    '#End Region

    '        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
    '            Dim hauteurFeu As Single = Convert.ToSingle(Me.Height / 4)
    '            Dim i As Integer
    '            Dim rg As New Region(New RectangleF(0, 0, Me.Width, Me.Height))
    '            Dim gp As New Drawing2D.GraphicsPath
    '            For i = 0 To 2
    '                gp.AddEllipse(New RectangleF(hauteurFeu / 4, hauteurFeu / 4 + (hauteurFeu / 4 + hauteurFeu) * i, Me.Width - hauteurFeu / 2, hauteurFeu))
    '            Next
    '            rg.Exclude(gp)
    '            pevent.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            pevent.Graphics.FillRegion(New SolidBrush(Me.BackColor), rg)
    '            pevent.Graphics.DrawRectangle(New Pen(Me.ForeColor), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
    '            pevent.Graphics.FillPath(New SolidBrush(Me.BackColor), gp)
    '            pevent.Graphics.DrawPath(New Pen(Me.ForeColor), gp)
    '            pevent.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
    '        End Sub

    '        Private Sub IndicateurFeuTriColor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '            Me.Refresh()
    '        End Sub

    '        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '            Dim gp As New Drawing2D.GraphicsPath
    '            Dim hauteurFeu As Single = Convert.ToSingle(Me.Height / 4)
    '            Dim i As Integer
    '            Dim P As SolidBrush
    '            If Value < _LimiteVertOrange Then
    '                If _Inverse = True Then
    '                    i = 0
    '                    P = New SolidBrush(Color.Red)
    '                Else
    '                    i = 2
    '                    P = New SolidBrush(Color.Green)
    '                End If
    '            ElseIf Value >= _LimiteVertOrange And Value < _LimiteOrangeRouge Then
    '                i = 1
    '                P = New SolidBrush(Color.Orange)
    '            Else
    '                If _Inverse = True Then
    '                    i = 2
    '                    P = New SolidBrush(Color.Green)
    '                Else
    '                    i = 0
    '                    P = New SolidBrush(Color.Red)
    '                End If
    '            End If
    '            gp.AddEllipse(New RectangleF(hauteurFeu / 4, hauteurFeu / 4 + (hauteurFeu / 4 + hauteurFeu) * i, Me.Width - hauteurFeu / 2, hauteurFeu))
    '            e.Graphics.FillPath(P, gp)
    '        End Sub
    '    End Class

    Public Class Graphique
        Inherits System.Windows.Forms.Control

        Private DecalageX3D As Integer = 5
        Private DecalageY3D As Integer = 5
        Private WithEvents _Valeurs As New LstBarre
        Private WithEvents _Legendes As New LstLegende
        Private LeftLegende As Integer = 25
        Private BasLegende As Integer = 20
        Private _LargeurBarre As Integer = 50
        Private _IntervaleBarre As Integer = 10
        Private LargeurGraph As Integer = 0
        Private HauteurGraph As Integer = 0
        Private _NbSerie As Integer = 1
        Private _GraphBackColor As Color = Color.White
        Private _LegendeXBackColor As Color = Color.White
        Private _LegendeYBackColor As Color = Color.White
        Private _MinValue As Decimal = 0
        Private _MaxValue As Decimal = 1000
        Private _UniteLegende As Decimal = 200
        Private _IntervaleBarreIntraSerie As Integer = 10
        Private _DesignMode As Boolean = True
        Public Event ClickLegende(ByVal sender As Graphique, ByVal nBarre As Integer)


#Region "Propriétés"

        Public Property RefreshAuto() As Boolean
            Get
                Return _DesignMode
            End Get
            Set(ByVal Value As Boolean)
                _DesignMode = Value
                If Value = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property LegendeUnite() As Decimal
            Get
                Return _UniteLegende
            End Get
            Set(ByVal Value As Decimal)
                If Value <> 0 Then
                    _UniteLegende = Value
                    If _DesignMode = True Then
                        Me.Refresh()
                    End If
                End If
            End Set
        End Property

        Public Property ValeurMin() As Decimal
            Get
                Return _MinValue
            End Get
            Set(ByVal Value As Decimal)
                _MinValue = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property ValeurMax() As Decimal
            Get
                Return _MaxValue
            End Get
            Set(ByVal Value As Decimal)
                _MaxValue = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property LegendeXBackColor() As Color
            Get
                Return _LegendeXBackColor
            End Get
            Set(ByVal Value As Color)
                _LegendeXBackColor = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property LegendeYBackColor() As Color
            Get
                Return _LegendeYBackColor
            End Get
            Set(ByVal Value As Color)
                _LegendeYBackColor = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property


        Public Property GraphBackColor() As Color
            Get
                Return _GraphBackColor
            End Get
            Set(ByVal Value As Color)
                _GraphBackColor = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property EspaceLegendeY() As Integer
            Get
                Return LeftLegende
            End Get
            Set(ByVal Value As Integer)
                LeftLegende = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property EspaceLegendeX() As Integer
            Get
                Return BasLegende
            End Get
            Set(ByVal Value As Integer)
                BasLegende = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property NbSerie() As Integer
            Get
                Return _NbSerie
            End Get
            Set(ByVal Value As Integer)
                _NbSerie = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property LargeurBarre() As Integer
            Get
                Return _LargeurBarre
            End Get
            Set(ByVal Value As Integer)
                _LargeurBarre = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property IntervaleBarre() As Integer
            Get
                Return _IntervaleBarre
            End Get
            Set(ByVal Value As Integer)
                _IntervaleBarre = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property IntervaleBarreIntraSerie() As Integer
            Get
                Return _IntervaleBarreIntraSerie
            End Get
            Set(ByVal Value As Integer)
                _IntervaleBarreIntraSerie = Value
                If _DesignMode = True Then
                    Me.Refresh()
                End If
            End Set
        End Property

        Public Property Legendes() As LstLegende
            Get
                Return _Legendes
            End Get
            Set(ByVal Value As LstLegende)
                _Legendes = Value
            End Set
        End Property

        Public Property Valeurs() As LstBarre
            Get
                Return _Valeurs
            End Get
            Set(ByVal Value As LstBarre)
                _Valeurs = Value
            End Set
        End Property

#End Region

        Private Sub Graphique_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            HauteurGraph = Me.Height - BasLegende - DecalageY3D - 1
            LargeurGraph = Me.Width - LeftLegende - DecalageX3D - 1
            Me.Refresh()
        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            Dim gp As New Drawing2D.GraphicsPath
            'Dim HauteurGraph As Integer = Me.Height - 30
            'Dim LargeurGraph As Integer = Me.Width - 23

            Dim Pts() As Point = New Point() {New Point(0, 0), New Point(0, HauteurGraph), New Point(DecalageX3D, HauteurGraph + DecalageY3D), New Point(DecalageX3D + LargeurGraph, HauteurGraph + DecalageY3D), New Point(DecalageX3D + LargeurGraph, DecalageY3D), New Point(LargeurGraph, 0)}

            gp.AddLine(0, 0, 0, HauteurGraph)
            gp.AddLine(0, 0, LargeurGraph, 0)

            Dim mx As New Drawing2D.Matrix(1, 0, 0, -1, LeftLegende, Me.Height - BasLegende)
            'gp.Transform(mx)
            pevent.Graphics.Transform = mx
            pevent.Graphics.Clear(Me.BackColor)
            pevent.Graphics.FillPolygon(New SolidBrush(_GraphBackColor), Pts)
            pevent.Graphics.DrawPath(New Pen(Me.ForeColor), gp)
            pevent.Graphics.DrawLine(New Pen(Me.ForeColor), 0, HauteurGraph, DecalageX3D, HauteurGraph + DecalageY3D)
            pevent.Graphics.DrawLine(New Pen(Me.ForeColor), LargeurGraph, 0, LargeurGraph + DecalageX3D, DecalageY3D)
            pevent.Graphics.DrawLine(New Pen(Me.ForeColor), 0, 0, DecalageX3D, DecalageY3D)
            pevent.Graphics.ResetTransform()

            Dim nBarre As Integer = 0
            Dim Obj As Object
            Dim P As New Pen(Me.ForeColor)
            Dim B As New SolidBrush(Me.ForeColor)
            For Each Obj In _Legendes
                AfficheLegendeX(pevent.Graphics, P, B, nBarre, Convert.ToString(Obj))
                nBarre += 1
            Next

            Dim i As Integer = 0
            'Dim unite As Decimal = (_MaxValue - _MinValue) / HauteurGraph
            Dim NbUnite As Integer = Convert.ToInt32(Math.Floor((_MaxValue - _MinValue) / _UniteLegende))
            Dim Valeur As Integer

            For i = 0 To NbUnite
                Valeur = Convert.ToInt32(((i * _UniteLegende) - _MinValue) * HauteurGraph / (_MaxValue - _MinValue))
                AfficheLegendeY(pevent.Graphics, P, B, Valeur, (i * _UniteLegende).ToString)
            Next

            mx.Translate(DecalageX3D, DecalageY3D)
            gp.AddLine(LargeurGraph, HauteurGraph, LargeurGraph, 0)
            'gp.AddLine(0, HauteurGraph, LargeurGraph, HauteurGraph)
            pevent.Graphics.Transform = mx
            pevent.Graphics.DrawLine(New Pen(Me.ForeColor), 0, HauteurGraph, LargeurGraph, HauteurGraph)
            pevent.Graphics.DrawPath(New Pen(Me.ForeColor), gp)

        End Sub

        Private Sub AfficheLegendeY(ByRef G As Graphics, ByVal P As Pen, ByVal B As Brush, ByVal Valeur As Integer, ByVal Texte As String)
            'Dim LeftBarre As Integer = IntervaleBarre + (IntervaleBarre + LargeurBarre) * nBarre
            Dim stF As New StringFormat
            stF.Alignment = StringAlignment.Center
            Dim Mx As New Drawing2D.Matrix
            Mx.Translate(0, Me.Height - BasLegende)
            Dim MxAv As New Drawing2D.Matrix
            MxAv = G.Transform
            Dim rt As New RectangleF(0, Convert.ToSingle(-Valeur - (Me.FontHeight / 2)), LeftLegende, Me.Font.Height)
            G.Transform = Mx
            G.FillRectangle(New SolidBrush(_LegendeYBackColor), rt)
            G.DrawString(Texte, Me.Font, B, rt, stF)
            Mx.Reset()
            Mx = New Drawing2D.Matrix(1, 0, 0, -1, LeftLegende, Me.Height - BasLegende)
            G.Transform = Mx
            G.DrawLine(P, 0, Valeur, DecalageX3D, Valeur + DecalageY3D)
            G.DrawLine(P, DecalageX3D, Valeur + DecalageY3D, LargeurGraph + DecalageX3D, Valeur + DecalageY3D)
            G.Transform = MxAv
        End Sub

        Private Sub AfficheLegendeX(ByRef G As Graphics, ByVal P As Pen, ByVal B As Brush, ByVal nBarre As Integer, ByVal Texte As String)
            'Dim HauteurGraph As Integer = Me.Height - 30
            'Dim LargeurGraph As Integer = Me.Width - 23
            'Dim LargeurBarre As Integer = 50
            'Dim IntervaleBarre As Integer = 10
            Dim LeftBarre As Integer = GetLeftBarre(nBarre * NbSerie)
            Dim stF As New StringFormat
            stF.Alignment = StringAlignment.Center
            Dim Mx As New Drawing2D.Matrix
            Mx.Translate(LeftLegende, Me.Height - BasLegende + 1)
            Dim MxAv As New Drawing2D.Matrix
            MxAv = G.Transform
            G.Transform = Mx
            Dim rt As New RectangleF(LeftBarre, 0, LargeurBarre * NbSerie + IntervaleBarreIntraSerie * (NbSerie - 1), Me.FontHeight)
            G.FillRectangle(New SolidBrush(_LegendeXBackColor), rt)
            G.DrawString(Texte, Me.Font, B, rt, stF)
            G.Transform = MxAv
        End Sub

        Private Function GetRectangleFLegendeX(ByRef nBarre As Integer) As RectangleF
            Dim LeftBarre As Integer = GetLeftBarre(nBarre * NbSerie)
            Dim stF As New StringFormat
            stF.Alignment = StringAlignment.Center
            Return New RectangleF(LeftBarre + LeftLegende, 0 + (Me.Height - BasLegende + 1), LargeurBarre * NbSerie + IntervaleBarreIntraSerie * (NbSerie - 1), Me.FontHeight)
        End Function

        Private Function GetLeftBarre(ByVal nBarre As Integer) As Integer
            Return Convert.ToInt32(IntervaleBarre + LargeurBarre * nBarre + ((nBarre - (nBarre Mod NbSerie)) / NbSerie) * (IntervaleBarre + IntervaleBarreIntraSerie * (NbSerie - 1)) + (nBarre Mod NbSerie) * IntervaleBarreIntraSerie)
        End Function

        Private Function GetValeurEchelle(ByVal maValeur As Decimal) As Integer
            Return Convert.ToInt32((maValeur - _MinValue) * HauteurGraph / (_MaxValue - _MinValue))
        End Function

        Private Sub AddBarre(ByRef G As Graphics, ByVal P As Pen, ByVal nBarre As Integer, ByVal maBarre As Barre)
            Dim Valeur As Integer
            Dim Valeur2 As Integer = 0
            'Valeur = Convert.ToInt32((maBarre.Valeur - _MinValue) * HauteurGraph / (_MaxValue - _MinValue))
            'Valeur2 = Convert.ToInt32((maBarre.Valeur2 - _MinValue) * HauteurGraph / (_MaxValue - _MinValue))
            Valeur = GetValeurEchelle(maBarre.Valeur)
            Valeur2 = GetValeurEchelle(maBarre.Valeur2)
            'Dim LeftBarre As Integer = IntervaleBarre + (IntervaleBarre + LargeurBarre) * nBarre
            Dim LeftBarre As Integer = GetLeftBarre(nBarre)
            Dim BarreColor As Color = Color.Blue
            If Valeur <> 0 Then
                Dim mxC As New Drawing2D.Matrix
                'Dim LargeurBarre As Integer = 50
                'Dim IntervaleBarre As Integer = 10
                Dim hauteurbarre As Integer = Valeur
                Dim Rt As Rectangle
                'Rt = New Rectangle(LeftBarre + DecalageX3D, DecalageY3D, LargeurBarre, Valeur)
                'G.FillRectangle(B, Rt)
                'G.DrawRectangle(P, Rt)
                Dim DecalageMoins As Integer = 0

                If maBarre.Couleur.IsEmpty = False Then
                    BarreColor = maBarre.Couleur
                End If
                Dim B As Brush = New SolidBrush(BarreColor)

                If Valeur < 0 Then
                    DecalageMoins -= DecalageY3D
                End If
                Dim Pts() As Point = New Point() {New Point(0, DecalageMoins), New Point(LargeurBarre, DecalageMoins), New Point(LargeurBarre, Valeur), New Point(0, Valeur)}
                mxC.Translate(LeftBarre + DecalageX3D, DecalageY3D)
                mxC.TransformPoints(Pts)
                G.FillPolygon(B, Pts)
                G.DrawPolygon(P, Pts)
                mxC.Reset()

                Pts = New Point() {New Point(0, 0), New Point(LargeurBarre, 0), New Point(LargeurBarre, Valeur), New Point(0, Valeur)}
                Rt = New Rectangle(LeftBarre, DecalageMoins, LargeurBarre, Valeur)
                Dim BPlus As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(Rt, Color.White, BarreColor, Drawing2D.LinearGradientMode.Horizontal)
                mxC.Translate(LeftBarre, 0)
                mxC.TransformPoints(Pts)
                G.FillPolygon(BPlus, Pts)
                G.DrawPolygon(P, Pts)
                mxC.Reset()

                'G.FillRectangle(BPlus, Rt)
                'G.DrawRectangle(P, Rt)
                Pts = New Point() {New Point(0, 0), New Point(DecalageX3D, DecalageMoins), New Point(DecalageX3D, hauteurbarre), New Point(0, hauteurbarre)}
                'mxC.Translate(-LeftBarre - LargeurBarre, 0)
                'mxC.TransformPoints(Pts)
                'mxC.Reset()
                mxC.Shear(0, 1)
                mxC.TransformPoints(Pts)
                mxC.Reset()
                mxC.Translate(LeftBarre + LargeurBarre, 0)
                mxC.TransformPoints(Pts)
                G.FillPolygon(B, Pts)
                G.DrawPolygon(P, Pts)
                Pts = New Point() {New Point(0, 0), New Point(LargeurBarre, 0), New Point(LargeurBarre + DecalageX3D, DecalageY3D), New Point(DecalageX3D, DecalageY3D)}
                mxC.Reset()
                If Valeur > 0 Then
                    mxC.Translate(LeftBarre, Valeur)
                Else
                    mxC.Translate(LeftBarre, 0)
                End If
                mxC.TransformPoints(Pts)
                G.FillPolygon(B, Pts)
                G.DrawPolygon(P, Pts)
            End If
            If Valeur2 <> 0 Then
                Dim hauteurbarre As Integer = Valeur2
                Dim DecalageMoins As Integer = 0
                Dim mxC As New Drawing2D.Matrix
                If Valeur < 0 Then
                    DecalageMoins -= DecalageY3D
                End If
                If maBarre.Couleur2.IsEmpty = False Then
                    BarreColor = maBarre.Couleur2
                End If
                Dim B As Brush = New SolidBrush(BarreColor)

                Dim Pts() As Point
                Dim Rt As Rectangle
                Pts = New Point() {New Point(0, 0), New Point(LargeurBarre, 0), New Point(LargeurBarre, Valeur2), New Point(0, Valeur2)}
                Rt = New Rectangle(LeftBarre, DecalageMoins, LargeurBarre, Valeur2)
                Dim BPlus As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(Rt, Color.White, BarreColor, Drawing2D.LinearGradientMode.Horizontal)
                mxC.Translate(LeftBarre, 0)
                mxC.TransformPoints(Pts)
                G.FillPolygon(BPlus, Pts)
                G.DrawPolygon(P, Pts)
                mxC.Reset()

                Pts = New Point() {New Point(0, 0), New Point(DecalageX3D, DecalageMoins), New Point(DecalageX3D, hauteurbarre), New Point(0, hauteurbarre)}
                mxC.Shear(0, 1)
                mxC.TransformPoints(Pts)
                mxC.Reset()
                mxC.Translate(LeftBarre + LargeurBarre, 0)
                mxC.TransformPoints(Pts)
                G.FillPolygon(B, Pts)
                G.DrawPolygon(P, Pts)
                Pts = New Point() {New Point(0, 0), New Point(LargeurBarre, 0), New Point(LargeurBarre + DecalageX3D, DecalageY3D), New Point(DecalageX3D, DecalageY3D)}
                mxC.Reset()
                If Valeur2 >= Valeur Then
                    If Valeur2 > 0 Then
                        mxC.Translate(LeftBarre, Valeur2)
                    Else
                        mxC.Translate(LeftBarre, 0)
                    End If
                    mxC.TransformPoints(Pts)
                    G.FillPolygon(B, Pts)
                    G.DrawPolygon(P, Pts)
                End If
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            'Dim HauteurGraph As Integer = Me.Height - 20
            'Dim LargeurGraph As Integer = Me.Width - 20
            Dim gp As New Drawing2D.GraphicsPath
            Dim P As New Pen(Me.ForeColor)
            Dim B As New SolidBrush(Color.Blue)
            Dim mx As New Drawing2D.Matrix(1, 0, 0, -1, LeftLegende, Me.Height - BasLegende)
            e.Graphics.Transform = mx

            'AddLigne(e.Graphics, _Valeurs, 0)

            Dim nBarre As Integer = 0
            Dim Br As Barre
            For Each Br In _Valeurs
                AddBarre(e.Graphics, P, nBarre, Br)
                nBarre += 1
            Next

            'AddLigne(e.Graphics, _Valeurs, 1)

            'nBarre = 1
            'AddBarre(e.Graphics, P, B, nBarre, 55)
            'nBarre = 2
            'AddBarre(e.Graphics, P, B, nBarre, 35)
        End Sub

        Private Sub AddLigne(ByRef G As Graphics, ByRef mesBarre As LstBarre, ByVal Type As Integer)
            Dim br As Barre
            Dim Pts() As Point
            Dim nBarre As Integer = 0
            Dim nPt As Integer = 0
            For Each br In mesBarre.Items
                If br.Valeur3 <> 0 Then
                    ReDim Preserve Pts(nPt)
                    Pts.SetValue(New Point(GetLeftBarre(nBarre) + Convert.ToInt32(Me._LargeurBarre / 2), GetValeurEchelle(br.Valeur3)), nPt)
                    nPt += 1
                End If
                nBarre += 1
            Next

            If nPt <= 1 Then Exit Sub

            If Type = 1 Then
                G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                G.DrawLines(New Pen(Color.Red, 2), Pts)
                G.SmoothingMode = Drawing2D.SmoothingMode.Default
            End If


            If Type = 2 Then
                'Dim gp As New Drawing2D.GraphicsPath
                Dim PtsGraph() As Point

                'G.DrawLines(New Pen(Me.ForeColor), Pts)

                Dim mx As New Drawing2D.Matrix
                mx.Translate(Me.DecalageX3D, Me.DecalageY3D)



                Dim pt As Point
                Dim nbPt As Integer = 0
                For Each pt In Pts
                    ReDim Preserve PtsGraph(nbPt)
                    PtsGraph.SetValue(pt, nbPt)
                    nbPt += 1
                Next

                Dim Pts2() As Point = Pts

                mx.TransformPoints(Pts2)
                Dim i As Integer
                Dim nbPt2 As Integer = Pts2.GetUpperBound(0)
                For i = 0 To Pts2.GetUpperBound(0)
                    ReDim Preserve PtsGraph(nbPt)
                    PtsGraph.SetValue(Pts2(nbPt2 - i), nbPt)
                    nbPt += 1
                Next

                G.FillPolygon(New SolidBrush(Color.Red), PtsGraph)

                'G.DrawLines(New Pen(Me.ForeColor), Pts2)

                'G.DrawLine(New Pen(Me.ForeColor), Pts(0), Pts2(0))
                'G.DrawLine(New Pen(Me.ForeColor), Pts(Pts.GetUpperBound(0)), Pts2(Pts2.GetUpperBound(0)))
            End If
        End Sub

        Private Sub _Valeurs_CollectionChanged() Handles _Legendes.CollectionChanged
            If _DesignMode = True Then
                Me.Refresh()
            End If
        End Sub

        Private Sub _Valeurs_CollectionChanged1(ByVal maBarre As Barre, ByVal ProprieteChanged As String) Handles _Valeurs.CollectionChanged
            If maBarre.Valeur > Me._MaxValue Then
                Me.ValeurMax = maBarre.Valeur
            End If
            If maBarre.Valeur2 > Me._MaxValue Then
                Me.ValeurMax = maBarre.Valeur2
            End If
            If (Me.ValeurMax - Me.ValeurMin) / Me.LegendeUnite > Me.HauteurGraph / (Me.FontHeight + 2) Then
                Me.LegendeUnite = Decimal.Floor((Me.ValeurMax - Me.ValeurMin) / Convert.ToDecimal((Me.HauteurGraph / (Me.FontHeight + 2))) / 10) * 10
            End If
            If _DesignMode = True Then
                Me.Refresh()
            End If
        End Sub

        Private Sub Graphique_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            Dim Obj As Object
            Dim nBarre As Integer = 0
            For Each Obj In _Legendes
                Dim Rt As RectangleF = Me.GetRectangleFLegendeX(nBarre)
                If Rt.Contains(e.X, e.Y) Then
                    RaiseEvent ClickLegende(Me, nBarre)
                End If
                nBarre += 1
            Next
        End Sub
    End Class

    Public Class LstBarre
        Inherits CollectionBase
        Friend Event CollectionChanged(ByVal maBarre As Barre, ByVal ProprieteChanged As String)

        Public Property Item(ByVal index As Integer) As Barre
            Get
                Return CType(Me.List.Item(index), Barre)
            End Get
            Set(ByVal Value As Barre)
                Me.List(index) = Value
                RaiseEvent CollectionChanged(Value, "Add")
            End Set
        End Property

        Public Function Add(ByVal valeur As Barre) As Barre
            Me.List.Add(valeur)
            RaiseEvent CollectionChanged(valeur, "Add")
            Return valeur
        End Function

        Public Function Add(ByVal valeur As Decimal) As Barre
            Dim br As New Barre(valeur)
            Me.List.Add(br)
            RaiseEvent CollectionChanged(br, "Add")
            Return br
        End Function

        Public Function Items() As Barre()
            Dim TmpIt(Me.List.Count - 1) As Barre
            Dim i As Integer
            For i = 0 To Me.List.Count - 1
                TmpIt.SetValue(Me.List.Item(i), i)
            Next
            Return TmpIt
        End Function

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            CType(value, Barre).maLstBarre = Me
        End Sub

        Public Sub OnCollectionChanged(ByVal maBarre As Barre, ByVal ProprieteChanged As String)
            RaiseEvent CollectionChanged(maBarre, ProprieteChanged)
        End Sub

        'Public Function Item(ByVal index As Integer) As Integer
        '    Return Convert.ToInt32(Me.List.Item(index))
        'End Function

    End Class

    Public Class LstLegende
        Inherits CollectionBase
        Friend Event CollectionChanged()

        Public Property Item(ByVal index As Integer) As String
            Get
                Return Convert.ToString(Me.List.Item(index))
            End Get
            Set(ByVal Value As String)
                Me.List(index) = Value
                RaiseEvent CollectionChanged()
            End Set
        End Property

        Public Function Add(ByVal valeur As String) As String
            Me.List.Add(valeur)
            RaiseEvent CollectionChanged()
            Return valeur
        End Function

        Public Function Items() As String()
            Dim TmpIt(Me.List.Count - 1) As String
            Dim i As Integer
            For i = 0 To Me.List.Count - 1
                TmpIt.SetValue(Me.List.Item(i), i)
            Next
            Return TmpIt
        End Function

    End Class

    Public Class Barre
        Private _Valeur As Decimal = 0
        Private _Valeur2 As Decimal = 0
        Private _Valeur3 As Decimal = 0
        Private _Couleur As Color
        Private _Couleur2 As Color
        Private _Couleur3 As Color
        Public Event ValeurChanged()
        Public Event CouleurChanged()
        Public maLstBarre As LstBarre

#Region "Propriétés"
        Public Property Valeur3() As Decimal
            Get
                Return _Valeur3
            End Get
            Set(ByVal Value As Decimal)
                _Valeur3 = Value
                RaiseEvent ValeurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Valeur3")
                End If
            End Set
        End Property

        Public Property Valeur2() As Decimal
            Get
                Return _Valeur2
            End Get
            Set(ByVal Value As Decimal)
                _Valeur2 = Value
                RaiseEvent ValeurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Valeur2")
                End If
            End Set
        End Property

        Public Property Valeur() As Decimal
            Get
                Return _Valeur
            End Get
            Set(ByVal Value As Decimal)
                _Valeur = Value
                RaiseEvent ValeurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Valeur")
                End If
            End Set
        End Property

        Public Property Couleur() As Color
            Get
                Return _Couleur
            End Get
            Set(ByVal Value As Color)
                _Couleur = Value
                RaiseEvent CouleurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Couleur")
                End If
            End Set
        End Property

        Public Property Couleur2() As Color
            Get
                Return _Couleur2
            End Get
            Set(ByVal Value As Color)
                _Couleur2 = Value
                RaiseEvent CouleurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Couleur2")
                End If
            End Set
        End Property

        Public Property Couleur3() As Color
            Get
                Return _Couleur3
            End Get
            Set(ByVal Value As Color)
                _Couleur3 = Value
                RaiseEvent CouleurChanged()
                If Not maLstBarre Is Nothing Then
                    maLstBarre.OnCollectionChanged(Me, "Couleur3")
                End If
            End Set
        End Property
#End Region

        Public Sub New()

        End Sub

        Public Sub New(ByVal maValeur As Decimal)
            Me.New()
            Valeur = maValeur
        End Sub

        Public Sub New(ByVal maValeur As Decimal, ByVal maCouleur As Color)
            Me.New(maValeur)
            Couleur = maCouleur
        End Sub
    End Class

End Namespace