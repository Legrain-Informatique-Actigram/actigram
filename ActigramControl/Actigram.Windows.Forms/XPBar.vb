Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization

Namespace Windows.Forms
    <Serializable(), DefaultEvent("ItemClick"), DefaultProperty("Items")> _
    Public Class XPBar
        Inherits Panel
        Private IntervalBordure As Single = 1
        Private HeightButtonGroup As Integer = 30
        Private nAngle As Integer = 15
        Private IntervalGroup As Integer = 5
        Private _oImageList As System.Windows.Forms.ImageList
        Private _oImageListItem As System.Windows.Forms.ImageList
        Private _oCol As XPGroupCollection
        Private ItemHeight As Single = 20
        Public Event GroupClick(ByVal XPGroup As XPGroup)
        Public Event ItemClick(ByVal XPItem As XPItem)
        Private Pict As New Label
        Private IntervalLeft As Single = 2
        Private IntervalImageText As Single = 5
        Private EcartRond As Single = 8
        Private WithEvents Tx As TextBox

        Private SelectedItem As XPItem = Nothing
        Private SelectedGroup As XPGroup = Nothing

        Private TitleBrushColor As New SolidBrush(Color.Blue)
        Private TitleSelectedBrushColor As New SolidBrush(Color.LightBlue)
        Private TitleFont As New Font("Comic Sans MS", 12)
        Private ItemBackBrushColor As New SolidBrush(Color.White)
        Private ItemBrushColor As New SolidBrush(Color.Blue)
        Private ItemFont As New Font("Comic Sans MS", 10)
        Private ItemBrushSelectedColor As New SolidBrush(Color.Blue)
        Private ItemSelectedFont As New Font("Comic Sans MS", 10, FontStyle.Underline)
        Private myDepartColor As Color = System.Drawing.Color.White
        Private myFinishColor As Color = System.Drawing.Color.LightSteelBlue
        Private myDegradeTitre As System.Drawing.Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
        Private myMakeTransparent As Boolean = False
        Private myMonoFleche As Boolean = False
        Private myBackColorFlecheTransparent As Boolean = False
        Private myBackColorFleche As Color = Color.WhiteSmoke
        Private myCadre As Boolean = True
        Private myTransparentColorDepart As Color = Color.Gray
        Private myTransparentcolorFin As Color = Color.White

        Private LeftEcartText As Single
        Private EtatGroupDepart As Hashtable

        'Private TitleBrushColor As New SolidBrush(Color.FromArgb(15, 141, 168))
        'Private ItemBrushColor As New SolidBrush(Color.FromArgb(15, 141, 168))
        'Private ItemBrushSelectedColor As New SolidBrush(Color.FromArgb(150, 15, 141, 168))
        'Private ItemPenColor As Color = Color.FromArgb(15, 141, 168)
        'Private myDepartColor As Color = System.Drawing.Color.White
        'Private myFinishColor As Color = Color.FromArgb(192, 196, 111)

        'momLeftColorFond = Color.FromArgb(192, 196, 111)
        'momRightColorFond = System.Drawing.Color.White
        'myPen.Color = Color.FromArgb(15, 141, 168)

#Region "Propriété"

        <Description("Arrire Plan de la Fleche"), Category("GroupeApparence"), DefaultValue(True)> _
Public Property Cadre() As Boolean
            Get
                Return myCadre
            End Get
            Set(ByVal Value As Boolean)
                myCadre = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Arrire Plan de la Fleche"), Category("GroupeApparence"), DefaultValue(False)> _
Public Property BackColorFlecheTransparent() As Boolean
            Get
                Return myBackColorFlecheTransparent
            End Get
            Set(ByVal Value As Boolean)
                myBackColorFlecheTransparent = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Fleche Unique"), Category("GroupeApparence"), DefaultValue(False)> _
        Public Property MonoFleche() As Boolean
            Get
                Return myMonoFleche
            End Get
            Set(ByVal Value As Boolean)
                myMonoFleche = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Icon Transparent"), Category("GroupeApparence"), DefaultValue(False)> _
        Public Property MakeTransparent() As Boolean
            Get
                Return myMakeTransparent
            End Get
            Set(ByVal Value As Boolean)
                myMakeTransparent = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Fond Flèche"), Category("GroupeApparence")> _
        Public Property TransparentColorDebut() As Color
            Get
                Return Me.myTransparentColorDepart
            End Get
            Set(ByVal Value As Color)
                myTransparentColorDepart = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Fond Flèche"), Category("GroupeApparence")> _
Public Property TransparentColorFin() As Color
            Get
                Return myTransparentcolorFin
            End Get
            Set(ByVal Value As Color)
                myTransparentcolorFin = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Fond Flèche"), Category("GroupeApparence")> _
        Public Property FondFleche() As Color
            Get
                Return myBackColorFleche
            End Get
            Set(ByVal Value As Color)
                myBackColorFleche = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Sens du dégradé"), Category("GroupeApparence")> _
        Public Property TitreDegrade() As System.Drawing.Drawing2D.LinearGradientMode
            Get
                Return myDegradeTitre
            End Get
            Set(ByVal Value As System.Drawing.Drawing2D.LinearGradientMode)
                myDegradeTitre = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property HauteurItem() As Single
            Get
                Return ItemHeight
            End Get
            Set(ByVal Value As Single)
                ItemHeight = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property EcartBordure() As Single
            Get
                Return IntervalBordure
            End Get
            Set(ByVal Value As Single)
                IntervalBordure = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property TailleRond() As Single
            Get
                Return EcartRond
            End Get
            Set(ByVal Value As Single)
                EcartRond = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property EspaceImageText() As Single
            Get
                Return IntervalImageText
            End Get
            Set(ByVal Value As Single)
                IntervalImageText = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property EspaceGauche() As Single
            Get
                Return IntervalLeft
            End Get
            Set(ByVal Value As Single)
                IntervalLeft = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Ecart entre le bord de la XPBar et le texte de l'item"), Category("GroupeApparence")> _
        Public Property LeftItemText() As Single
            Get
                Return LeftEcartText
            End Get
            Set(ByVal Value As Single)
                LeftEcartText = Value
                AfficheGroups()
            End Set
        End Property


        <Description("Couleur du Libellé des Groupes"), Category("GroupeApparence")> _
        Public Property CouleurTitre() As Color
            Get
                Return TitleBrushColor.Color
            End Get
            Set(ByVal Value As Color)
                TitleBrushColor = New SolidBrush(Value)
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Libellé des Groupes"), Category("GroupeApparence")> _
    Public Property CouleurSelectedTitre() As Color
            Get
                Return TitleSelectedBrushColor.Color
            End Get
            Set(ByVal Value As Color)
                TitleSelectedBrushColor = New SolidBrush(Value)
                AfficheGroups()
            End Set
        End Property

        <Description("Police du Libellé des Groupes"), Category("GroupeApparence")> _
        Public Property PoliceTitre() As Font
            Get
                Return TitleFont
            End Get
            Set(ByVal Value As Font)
                TitleFont = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Libellé des Items"), Category("GroupeApparence")> _
        Public Property CouleurFondItem() As Color
            Get
                Return ItemBackBrushColor.Color
            End Get
            Set(ByVal Value As Color)
                ItemBackBrushColor = New SolidBrush(Value)
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Libellé des Items"), Category("GroupeApparence")> _
        Public Property CouleurItem() As Color
            Get
                Return ItemBrushColor.Color
            End Get
            Set(ByVal Value As Color)
                ItemBrushColor = New SolidBrush(Value)
                AfficheGroups()
            End Set
        End Property

        <Description("Police du Libellé des Items"), Category("GroupeApparence")> _
        Public Property PoliceItems() As Font
            Get
                Return ItemFont
            End Get
            Set(ByVal Value As Font)
                ItemFont = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur du Libellé des Items sélectionné"), Category("GroupeApparence")> _
        Public Property CouleurSelectedItem() As Color
            Get
                Return ItemBrushSelectedColor.Color
            End Get
            Set(ByVal Value As Color)
                ItemBrushSelectedColor = New SolidBrush(Value)
                AfficheGroups()
            End Set
        End Property

        <Description("Police du Libellé des Items sélectionnés"), Category("GroupeApparence")> _
        Public Property PoliceItemsSelectionnés() As Font
            Get
                Return ItemSelectedFont
            End Get
            Set(ByVal Value As Font)
                ItemSelectedFont = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur Gauche du dégradé"), Category("GroupeApparence")> _
        Public Property CouleurGauche() As Color
            Get
                Return myDepartColor
            End Get
            Set(ByVal Value As Color)
                myDepartColor = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Couleur Droite du dégradé"), Category("GroupeApparence")> _
        Public Property CouleurDroite() As Color
            Get
                Return myFinishColor
            End Get
            Set(ByVal Value As Color)
                myFinishColor = Value
                AfficheGroups()
            End Set
        End Property


        <Description("Arrondi de l'entête de Groupe"), Category("GroupeApparence")> _
        Public Property Angle() As Integer
            Get
                Return nAngle
            End Get
            Set(ByVal Value As Integer)
                nAngle = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Hauteur de l'entête de Groupe"), Category("GroupeApparence")> _
        Public Property HauteurEntete() As Integer
            Get
                Return HeightButtonGroup
            End Get
            Set(ByVal Value As Integer)
                HeightButtonGroup = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Intervale entre les Groupes"), Category("GroupeApparence")> _
        Public Property IntervalGroupe() As Integer
            Get
                Return IntervalGroup
            End Get
            Set(ByVal Value As Integer)
                IntervalGroup = Value
                AfficheGroups()
            End Set
        End Property

        <Description("Liste d'images pour définir les icones"), Category("GroupeApparence")> _
        Public Property ImageList() As ImageList
            Get
                Return _oImageList
            End Get
            Set(ByVal Value As ImageList)
                _oImageList = Value
            End Set
        End Property

        <Description("Liste d'images pour définir les icones des Items"), Category("GroupeApparence")> _
        Public Property ImageListItem() As ImageList
            Get
                Return _oImageListItem
            End Get
            Set(ByVal Value As ImageList)
                _oImageListItem = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("La collection des Items contenus dans le groupe"), Category("GroupeApparence")> _
        Public ReadOnly Property Items() As XPGroupCollection
            Get
                Return _oCol
            End Get
        End Property
#End Region

        Public Sub New()
            MyBase.New()
            Me.Controls.Add(Pict)
            Pict.Text = ""
            Me.SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
            _oCol = New XPGroupCollection(Me)
            Tx = New TextBox
            Tx.Left = 0
            Tx.Top = 0
            Tx.Width = 0
            Tx.Height = 0
            Tx.TabIndex = 0
            Tx.TabStop = True
            Tx.Visible = True
            Me.Controls.Add(Tx)
        End Sub

        Public Sub ClearItems()
            Dim xpG1 As XPGroup
            For Each xpG1 In Me.Items
                xpG1.Items.Clear()
            Next
            Me.Items.Clear()
            EtatGroupDepart = Nothing
            SelectedItem = Nothing
            'If Not EtatGroupDepart Is Nothing Then
            '    EtatGroupDepart.Clear()
            'End If
            Dim g As Graphics
            g = Me.CreateGraphics
            g.Clear(Me.BackColor)
        End Sub

        Private Sub XPBar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            AfficheGroups()
            If EtatGroupDepart Is Nothing Then
                EtatGroupDepart = New Hashtable
                Dim xpGroup As XPGroup
                For Each xpGroup In _oCol
                    EtatGroupDepart.Add(xpGroup, xpGroup.AfficheListeItem)
                Next
            End If
        End Sub

        Private Sub AfficheGroups()
            Dim XPGroup As XPGroup
            Dim XPItem As XPItem
            Dim strHeight As Single
            'Pict.Top = 0
            'Pict.Left = 0
            'Pict.Width = Me.Width

            For Each XPGroup In _oCol
                If XPGroup.Visible = True Then
                    strHeight += Me.HeightButtonGroup + IntervalGroup
                    If XPGroup.AfficheListeItem = True Then
                        For Each XPItem In XPGroup.Items
                            If XPItem.Visible = True Then
                                strHeight += Me.ItemHeight
                            End If
                        Next
                    End If
                End If
            Next
            Pict.Top = CInt(strHeight) + Me.AutoScrollPosition.Y
            Pict.Left = 0
            Pict.Width = 0
            Pict.Height = 1
            Pict.Visible = True

            Dim g As Graphics
            g = Me.CreateGraphics
            'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            'g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            'g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            Dim i As Integer
            Dim strTop As Single = Me.DisplayRectangle.Top
            strTop += IntervalBordure
            For i = 0 To _oCol.Count - 1
                If _oCol.Item(i).Visible = True Then
                    AfficheGroup(g, _oCol.Item(i), strTop)
                    If _oCol.Item(i).AfficheListeItem = True Then
                        AfficheItems(g, _oCol.Item(i), strTop)
                        'Dim myPen As Pen = CType(System.Drawing.Pens.LightGray.Clone, Pen)
                        'myPen.Width = 2
                        ''g.DrawRectangle(myPen, 1, strTop - _oCol.Item(i).Items.Count * Me.ItemHeight, Me.DisplayRectangle.Width - 3, _oCol.Item(i).Items.Count * Me.ItemHeight)
                        Try
                            If Me.myCadre = True Then
                                Dim ptF(3) As PointF
                                ptF(0) = New PointF(IntervalBordure + 1, strTop - _oCol.Item(i).Items.Count * Me.ItemHeight - 1)
                                ptF(1) = New PointF(IntervalBordure + 1, strTop + 1)
                                ptF(2) = New PointF(Me.DisplayRectangle.Width - IntervalBordure - 1, strTop + 1)
                                ptF(3) = New PointF(Me.DisplayRectangle.Width - IntervalBordure - 1, strTop - _oCol.Item(i).NbItemsVisible * Me.ItemHeight - 1)
                                Dim rtBrush As New RectangleF(ptF(0).X, ptF(0).Y, ptF(2).X + 2, ptF(2).Y + 2)
                                rtBrush.X = 0
                                Dim brs As New System.Drawing.Drawing2D.LinearGradientBrush(rtBrush, myDepartColor, myFinishColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim myPen As New Pen(brs, 2)
                                g.DrawLines(myPen, ptF)
                            End If
                        Catch
                        End Try
                    End If
                    strTop += IntervalGroup
                End If
            Next
        End Sub

        Private Sub AfficheGroup(ByVal g As Graphics, ByVal XPGroup As XPGroup, ByRef strTop As Single, Optional ByVal Refresh As Boolean = False)
            AfficheGroup(g, XPGroup, strTop, TitleBrushColor, Refresh)
        End Sub

        Private Sub AfficheGroup(ByVal g As Graphics, ByVal XPGroup As XPGroup, ByRef strTop As Single, ByVal TitleColor As SolidBrush, Optional ByVal Refresh As Boolean = False)
            Try
                If XPGroup.Visible = False Then Exit Sub
                Dim ph As New System.Drawing.Drawing2D.GraphicsPath
                'Dim nAngle As Integer
                'nAngle = 15
                Dim rt As New RectangleF
                Dim rtBt As New RectangleF
                rt.X = IntervalBordure
                rt.Y = strTop
                rt.Height = HeightButtonGroup
                rt.Width = Me.DisplayRectangle.Width - 2 * IntervalBordure
                If Refresh = False Then
                    strTop += rt.Height
                End If
                ph.AddLine(IntervalBordure + CInt(nAngle / 2), rt.Y, IntervalBordure + rt.Width - CInt(nAngle / 2) - 1, rt.Y)
                ph.AddArc(IntervalBordure + rt.Width - nAngle - 1, rt.Y, nAngle, nAngle, -90, 90)
                ph.AddLine(IntervalBordure + rt.Width - 1, rt.Y + nAngle, IntervalBordure + rt.Width - 1, rt.Y + HeightButtonGroup - 1)
                ph.AddLine(IntervalBordure + rt.Width - 1, rt.Y + HeightButtonGroup - 1, 0, rt.Y + HeightButtonGroup - 1)
                ph.AddLine(IntervalBordure + 0, rt.Y + HeightButtonGroup - 1, IntervalBordure + 0, rt.Y + nAngle)
                ph.AddArc(IntervalBordure + 0, rt.Y + 0, nAngle, nAngle, -180, 90)
                Dim rtBrush As New RectangleF(rt.X, rt.Y - 1, rt.Width + IntervalBordure, rt.Height + 1)
                rtBrush.X = 0
                Dim brs As New System.Drawing.Drawing2D.LinearGradientBrush(rtBrush, myDepartColor, myFinishColor, myDegradeTitre)
                'Dim brs As New System.Drawing.Drawing2D.LinearGradientBrush(rtBrush, System.Drawing.Color.White, System.Drawing.Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.FillPath(brs, ph)
                g.SmoothingMode = Drawing2D.SmoothingMode.None

                Dim hauteurRond As Single

                Dim rtbt2 As New RectangleF
                hauteurRond = rt.Height - EcartRond * 2
                rtBt.X = IntervalBordure + rt.Width - hauteurRond - EcartRond
                rtBt.Y = (rt.Y + rt.Height) - hauteurRond - EcartRond
                rtBt.Width = hauteurRond
                rtBt.Height = hauteurRond

                Dim Ecart2 As Single = 1
                rtbt2.X = rtBt.X - Ecart2
                rtbt2.Y = rtBt.Y - Ecart2
                rtbt2.Height = rtBt.Height + 2 * Ecart2
                rtbt2.Width = rtBt.Width + 2 * Ecart2

                Dim myPen As Pen
                myPen = CType(System.Drawing.Pens.WhiteSmoke.Clone, Pen)
                myPen.Width = 1
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.FillEllipse(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), rtbt2)
                If Me.myBackColorFlecheTransparent = False Then
                    g.FillEllipse(New SolidBrush(myBackColorFleche), rtBt)
                Else
                    g.FillEllipse(brs, rtBt)
                End If
                g.SmoothingMode = Drawing2D.SmoothingMode.None

                Dim fst As New StringFormat
                fst.LineAlignment = StringAlignment.Center
                fst.Alignment = StringAlignment.Near

                If XPGroup.ImageIndex <> -1 Then
                    Dim rtGroupImage As New Rectangle
                    rtGroupImage = New Rectangle
                    rtGroupImage.X = Convert.ToInt32(rt.X + rt.Height / 2 - XPGroup.XPBar.ImageList.ImageSize.Width / 2)
                    rtGroupImage.Y = Convert.ToInt32(rt.Y + rt.Height / 2 - XPGroup.XPBar.ImageList.ImageSize.Height / 2)
                    rtGroupImage.Width = XPGroup.XPBar.ImageList.ImageSize.Width
                    rtGroupImage.Height = XPGroup.XPBar.ImageList.ImageSize.Height

                    Dim oBit As New Bitmap(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex))
                    'oBit.MakeTransparent(Color.White)
                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X, rt.Y)
                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X + ((rtGroupImage.Width - XPGroup.XPBar.ImageList.ImageSize.Width) / 2), rt.Y + ((rt.Height - XPGroup.XPBar.ImageList.ImageSize.Height) / 2))
                    Dim im As New Imaging.ImageAttributes

                    If MakeTransparent = True Then
                        im.SetColorKey(Me.myTransparentColorDepart, Me.myTransparentcolorFin)
                    End If
                    'Dim oItems(,) As Single = {{1, 0, 0, 0, 0}, {0, 1, 0, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 0, 0.5, 0}, {0, 0, 0, 0, 1}}
                    'Dim mx As New Imaging.ColorMatrix
                    'Dim iR As Integer
                    'Dim iC As Integer
                    'For iR = 0 To 4
                    '    For iC = 0 To 4
                    '        mx.Item(iR, iC) = oItems(iR, iC)
                    '    Next
                    'Next
                    'im.SetColorMatrix(mx)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    'g.DrawImage(oBit, rtGroupImage)
                    g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rtGroupImage, 0, 0, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Width, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Height, GraphicsUnit.Pixel, im)
                    'g.DrawImage(oBit, rtGroupImage, 0, 0, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Width, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Height, GraphicsUnit.Pixel, im)
                    'g.DrawImage(oBit, rtGroupImage, 0, 0, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Width, XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex).Height, GraphicsUnit.Pixel, im)
                    'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rtGroupImage)
                    g.SmoothingMode = Drawing2D.SmoothingMode.None


                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X, rt.Y + ((rt.Height - XPGroup.XPBar.ImageList.ImageSize.Height) / 2))
                    Dim rtGroupText As New RectangleF
                    rtGroupText = New RectangleF
                    rtGroupText.X = rtGroupImage.X + rtGroupImage.Width + 2 + IntervalImageText
                    rtGroupText.Y = rt.Y
                    rtGroupText.Width = Me.Width - 1 - rtGroupImage.Width
                    rtGroupText.Height = rt.Height
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    g.DrawString(XPGroup.TextGroupe, TitleFont, TitleColor, rtGroupText, fst)

                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
                Else
                    Dim rtGroupText As New RectangleF
                    rtGroupText = New RectangleF
                    rtGroupText.X = rt.X + Me.IntervalImageText
                    rtGroupText.Y = rt.Y
                    rtGroupText.Width = Me.Width - 1 - Me.IntervalImageText
                    rtGroupText.Height = rt.Height
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    g.DrawString(XPGroup.TextGroupe, TitleFont, TitleColor, rtGroupText, fst)
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
                End If
                Dim flechePt(2) As PointF
                Dim nDx As Single = 3.5
                Dim nDy As Single = 2.5
                Dim nT As Single = rtBt.Height / 8
                flechePt(0).X = rtBt.X + (rtBt.Width / nDx) : flechePt(0).Y = rtBt.Y + (rtBt.Height / nDy)
                flechePt(1).X = rtBt.X + (rtBt.Width / 2) : flechePt(1).Y = rtBt.Y + rtBt.Height - (rtBt.Height / nDy)
                flechePt(2).X = rtBt.X + rtBt.Width - (rtBt.Width / nDx) : flechePt(2).Y = rtBt.Y + (rtBt.Height / nDy)

                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                Dim nMatrix As New Drawing2D.Matrix(1, 0, 0, -1, 0, rtBt.Y * 2 + rtBt.Height)
                If XPGroup.AfficheListeItem = True Then
                    nMatrix.TransformPoints(flechePt)
                End If

                Dim oPath As New Drawing2D.GraphicsPath
                oPath.AddLines(flechePt)
                'nMatrix.Invert()
                'g.MultiplyTransform(nMatrix)
                If myMonoFleche = False Then
                    g.TranslateTransform(0, -nT)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                    g.TranslateTransform(0, +nT * 2)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                Else
                    g.TranslateTransform(0, 0)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                End If

                g.ResetTransform()
                g.SmoothingMode = Drawing2D.SmoothingMode.None

                'flce

                'fst = New StringFormat
                'fst.LineAlignment = StringAlignment.Center
                'fst.Alignment = StringAlignment.Center
                'If XPGroup.AfficheListeItem = True Then
                '    g.DrawString("-", New Font("Comic Sans MS", 12), TitleBrushColor, rtBt, fst)
                'Else
                '    g.DrawString("+", New Font("Comic Sans MS", 12), TitleBrushColor, rtBt, fst)
                'End If
                XPGroup.rtBt = rtBt
                XPGroup.rt = rt
            Catch
            End Try
        End Sub

        Private Sub AfficheGroupText(ByVal g As Graphics, ByVal XPGroup As XPGroup, ByRef strTop As Single, ByVal TitleColor As SolidBrush, Optional ByVal Refresh As Boolean = False)
            Try
                If XPGroup.Visible = False Then Exit Sub

                Dim ph As New System.Drawing.Drawing2D.GraphicsPath
                'Dim nAngle As Integer
                'nAngle = 15
                Dim rt As New RectangleF
                Dim rtBt As New RectangleF
                rt = XPGroup.rt
                rtBt = XPGroup.rtBt

                Dim rtbt2 As New RectangleF

                Dim Ecart2 As Single = 1
                rtbt2.X = rtBt.X - Ecart2
                rtbt2.Y = rtBt.Y - Ecart2
                rtbt2.Height = rtBt.Height + 2 * Ecart2
                rtbt2.Width = rtBt.Width + 2 * Ecart2

                Dim fst As New StringFormat
                fst.LineAlignment = StringAlignment.Center
                fst.Alignment = StringAlignment.Near

                If XPGroup.ImageIndex <> -1 Then
                    Dim rtGroupImage As New RectangleF
                    rtGroupImage = New RectangleF
                    rtGroupImage.X = rt.X
                    rtGroupImage.Y = rt.Y
                    rtGroupImage.Width = XPGroup.XPBar.ImageList.ImageSize.Width + 2
                    rtGroupImage.Height = XPGroup.XPBar.ImageList.ImageSize.Height
                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X, rt.Y)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X + ((rtGroupImage.Width - XPGroup.XPBar.ImageList.ImageSize.Width) / 2), rt.Y + ((rt.Height - XPGroup.XPBar.ImageList.ImageSize.Height) / 2))
                    g.SmoothingMode = Drawing2D.SmoothingMode.None
                    'g.DrawImage(XPGroup.XPBar.ImageList.Images(XPGroup.ImageIndex), rt.X, rt.Y + ((rt.Height - XPGroup.XPBar.ImageList.ImageSize.Height) / 2))
                    Dim rtGroupText As New RectangleF
                    rtGroupText = New RectangleF
                    rtGroupText.X = rtGroupImage.X + rtGroupImage.Width
                    rtGroupText.Y = rt.Y
                    rtGroupText.Width = Me.Width - 1 - rtGroupImage.Width
                    rtGroupText.Height = rt.Height
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    g.DrawString(XPGroup.TextGroupe, TitleFont, TitleColor, rtGroupText, fst)
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
                Else
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                    g.DrawString(XPGroup.TextGroupe, TitleFont, TitleColor, rt, fst)
                    'g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
                End If
                Dim flechePt(2) As PointF
                Dim nDx As Single = 3.5
                Dim nDy As Single = 2.5
                Dim nT As Single = rtBt.Height / 8
                flechePt(0).X = rtBt.X + (rtBt.Width / nDx) : flechePt(0).Y = rtBt.Y + (rtBt.Height / nDy)
                flechePt(1).X = rtBt.X + (rtBt.Width / 2) : flechePt(1).Y = rtBt.Y + rtBt.Height - (rtBt.Height / nDy)
                flechePt(2).X = rtBt.X + rtBt.Width - (rtBt.Width / nDx) : flechePt(2).Y = rtBt.Y + (rtBt.Height / nDy)

                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                Dim nMatrix As New Drawing2D.Matrix(1, 0, 0, -1, 0, rtBt.Y * 2 + rtBt.Height)
                If XPGroup.AfficheListeItem = True Then
                    nMatrix.TransformPoints(flechePt)
                End If

                Dim oPath As New Drawing2D.GraphicsPath
                oPath.AddLines(flechePt)
                'nMatrix.Invert()
                'g.MultiplyTransform(nMatrix)
                If Me.myMonoFleche = False Then
                    g.TranslateTransform(0, -nT)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                    g.TranslateTransform(0, +nT * 2)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                Else
                    g.TranslateTransform(0, 0)
                    g.DrawPath(New Pen(TitleColor, 1.7), oPath)
                End If
                g.ResetTransform()
                g.SmoothingMode = Drawing2D.SmoothingMode.None

            Catch
            End Try
        End Sub

        Private Sub AfficheItems(ByVal g As Graphics, ByVal XPGroup As XPGroup, ByRef strTop As Single)
            Dim i As Integer
            For i = 0 To XPGroup.Items.Count - 1
                If XPGroup.Items(i).Visible = True Then
                    AfficheItem(g, XPGroup.Items(i), strTop)
                End If
            Next
        End Sub

        Private Sub AfficheItem(ByVal g As Graphics, ByVal XPItem As XPItem, ByRef strTop As Single)
            Try
                If XPItem.XPGroup.Visible = False Then Exit Sub
                If XPItem.Visible = False Then Exit Sub
                Dim rtItem As RectangleF
                Dim rtItemImage As Rectangle
                Dim rtItemText As RectangleF

                rtItem = New RectangleF
                rtItem.X = IntervalBordure + 1
                'rtItem.Y = strTop - 1
                rtItem.Y = strTop
                rtItem.Width = Me.DisplayRectangle.Width - IntervalBordure - 1 - rtItem.X
                'rtItem.Height = ItemHeight
                rtItem.Height = ItemHeight
                strTop += rtItem.Height
                rtItemImage = New Rectangle
                rtItemImage.X = Convert.ToInt32(IntervalLeft + IntervalBordure)
                rtItemImage.Y = Convert.ToInt32(rtItem.Y)
                If XPItem.ImageIndex <> -1 Then
                    rtItemImage.Width = XPItem.ImageList.ImageSize.Width
                    rtItemImage.Height = XPItem.ImageList.ImageSize.Height
                Else
                    rtItemImage.Width = Convert.ToInt32(Me.LeftEcartText)
                    rtItemImage.Height = Convert.ToInt32(Me.LeftEcartText)
                End If
                rtItemText = New RectangleF
                rtItemText.X = rtItemImage.X + rtItemImage.Width + IntervalImageText
                rtItemText.Y = rtItem.Y
                rtItemText.Width = Me.DisplayRectangle.Width - IntervalBordure - 1 - rtItemImage.Width - rtItemImage.X - 2
                rtItemText.Height = rtItem.Height

                g.FillRectangle(ItemBackBrushColor, rtItem)
                Dim fts As New StringFormat
                fts.Alignment = StringAlignment.Near
                fts.LineAlignment = StringAlignment.Center
                Dim brsh As SolidBrush
                Dim brshSelected As SolidBrush
                If XPItem.TextColor.IsEmpty = False Then
                    brsh = New SolidBrush(XPItem.TextColor)
                Else
                    brsh = ItemBrushColor
                End If
                If XPItem.TextHoverColor.IsEmpty = False Then
                    brshSelected = New SolidBrush(XPItem.TextHoverColor)
                Else
                    brshSelected = ItemBrushSelectedColor
                End If
                Dim ItFont As Font
                Dim ItFontDep As Font
                If XPItem.Selected = True Then
                    ItFontDep = ItemSelectedFont
                Else
                    ItFontDep = ItemFont
                End If
                If XPItem.Barre = True Then
                    ItFont = New Font(ItFontDep, FontStyle.Strikeout)
                Else
                    ItFont = ItFontDep
                End If
                'If XPItem.Selected = True Then
                '    'g.DrawString(XPItem.Text, ItemSelectedFont, ItemBrushSelectedColor, rtItemText, fts)
                '    g.DrawString(XPItem.Text, ItemSelectedFont, brshSelected, rtItemText, fts)
                'Else
                '    'g.DrawString(XPItem.Text, ItemFont, ItemBrushColor, rtItemText, fts)
                '    g.DrawString(XPItem.Text, ItemFont, brsh, rtItemText, fts)
                'End If
                g.DrawString(XPItem.Text, ItFont, brsh, rtItemText, fts)
                If XPItem.ImageIndex <> -1 Then
                    'g.DrawImage(XPItem.ImageList.Images(XPItem.ImageIndex), rtItem.X, rtItem.Y)
                    'g.DrawImage(XPItem.ImageList.Images(XPItem.ImageIndex), rtItem.X + IntervalLeft + ((rtItemImage.Width - XPItem.ImageList.ImageSize.Width) / 2), rtItem.Y + ((rtItem.Height - XPItem.ImageList.ImageSize.Height) / 2))
                    Dim iAt As New Imaging.ImageAttributes
                    iAt.SetColorKey(Color.LightGray, Color.White)
                    g.DrawImage(XPItem.ImageList.Images(XPItem.ImageIndex), rtItemImage, 0, 0, rtItemImage.Width, rtItemImage.Height, GraphicsUnit.Pixel, iAt)
                End If
                'strTop += ItemHeight
                XPItem.rtItem = rtItem
            Catch
            End Try
        End Sub

        Private Sub AfficheItemText(ByVal g As Graphics, ByVal XPItem As XPItem)
            If XPItem.XPGroup.AfficheListeItem = False Then Exit Sub
            If XPItem.XPGroup.Visible = False Then Exit Sub
            If XPItem.Visible = False Then Exit Sub

            Dim rtItem As RectangleF
            Dim rtItemImage As RectangleF
            Dim rtItemText As RectangleF
            rtItem = XPItem.rtItem
            rtItemImage = New RectangleF
            rtItemImage.X = IntervalLeft + IntervalBordure
            rtItemImage.Y = rtItem.Y
            If XPItem.ImageIndex <> -1 Then
                rtItemImage.Width = XPItem.ImageList.ImageSize.Width
                rtItemImage.Height = XPItem.ImageList.ImageSize.Height
            Else
                rtItemImage.Width = Me.LeftEcartText
                rtItemImage.Height = Me.LeftEcartText
            End If
            rtItemText = New RectangleF
            rtItemText.X = rtItemImage.X + rtItemImage.Width + Me.IntervalImageText
            rtItemText.Y = rtItem.Y
            rtItemText.Width = Me.DisplayRectangle.Width - 1 - rtItemImage.Width - rtItemImage.X - Me.IntervalImageText - Me.IntervalBordure - 2
            rtItemText.Height = XPItem.rtItem.Height
            g.FillRectangle(ItemBackBrushColor, rtItemText)
            Dim fts As New StringFormat
            fts.Alignment = StringAlignment.Near
            fts.LineAlignment = StringAlignment.Center
            Dim brsh As SolidBrush
            Dim brshSelected As SolidBrush
            If XPItem.TextColor.IsEmpty = False Then
                brsh = New SolidBrush(XPItem.TextColor)
            Else
                brsh = ItemBrushColor
            End If
            If XPItem.TextHoverColor.IsEmpty = False Then
                brshSelected = New SolidBrush(XPItem.TextHoverColor)
            Else
                brshSelected = ItemBrushSelectedColor
            End If
            Dim ItFont As Font
            Dim ItFontDep As Font
            If XPItem.Selected = True Then
                ItFontDep = ItemSelectedFont
            Else
                ItFontDep = ItemFont
            End If
            If XPItem.Barre = True Then
                ItFont = New Font(ItFontDep, FontStyle.Strikeout)
            Else
                ItFont = ItFontDep
            End If

            'If XPItem.Selected = True Then
            '    'g.DrawString(XPItem.Text, ItemSelectedFont, ItemBrushSelectedColor, rtItemText, fts)
            '    g.DrawString(XPItem.Text, ItemSelectedFont, brshSelected, rtItemText, fts)
            'Else
            '    'g.DrawString(XPItem.Text, ItemFont, ItemBrushColor, rtItemText, fts)
            '    g.DrawString(XPItem.Text, ItemFont, brsh, rtItemText, fts)
            'End If
            g.DrawString(XPItem.Text, ItFont, brsh, rtItemText, fts)

        End Sub

        Private Sub XPBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            Dim XPGroup As XPGroup
            Dim XPItem As XPItem

            For Each XPGroup In _oCol
                If XPGroup.rt.Contains(e.X, e.Y) And XPGroup.Visible = True Then
                    If XPGroup.AfficheListeItem = False Then
                        XPGroup.AfficheListeItem = True
                        Dim xpG As XPGroup
                        For Each xpG In _oCol
                            If Convert.ToBoolean(EtatGroupDepart(xpG)) = False And Not xpG Is XPGroup Then
                                xpG.AfficheListeItem = False
                                'If Me.SelectedItem.XPGroup.AfficheListeItem = True Then
                                '    Me.SelectedItem.XPGroup.AfficheListeItem = False
                                '    Me.AfficheGroups()
                                'End If
                            End If
                        Next
                        'Me.AfficheGroups()
                        RaiseEvent GroupClick(XPGroup)
                    Else
                        XPGroup.AfficheListeItem = False
                    End If
                    Me.Refresh()
                    Exit Sub
                End If
                For Each XPItem In XPGroup.Items
                    If XPItem.rtItem.Contains(e.X, e.Y) And XPGroup.AfficheListeItem = True And XPItem.Visible = True And XPItem.XPGroup.Visible = True Then
                        If Not SelectedItem Is Nothing Then
                            SelectedItem.Selected = False
                            Me.AfficheItemText(Me.CreateGraphics, SelectedItem)
                        End If
                        SelectedItem = XPItem
                        XPItem.Selected = True
                        Me.AfficheItemText(Me.CreateGraphics, SelectedItem)
                        RaiseEvent ItemClick(XPItem)
                        XPItem.OnClick()
                    Else
                        XPItem.Selected = False
                    End If
                Next
            Next
        End Sub


        Private Sub XPBar_SelectItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim XPGroup As XPGroup
            Dim XPItem As XPItem
            Dim XPGroupVerif As Boolean = False

            For Each XPGroup In _oCol
                If XPGroup.rt.Contains(e.X, e.Y) And XPGroup.Visible = True Then
                    If Not XPGroup Is SelectedGroup Then
                        Dim g As Graphics
                        g = Me.CreateGraphics
                        If Not SelectedGroup Is Nothing Then
                            'SelectedGroup.Selected = False
                            Me.AfficheGroup(g, SelectedGroup, SelectedGroup.rt.Top, TitleBrushColor, True)
                        End If
                        SelectedGroup = XPGroup
                        'XPGroup.Selected = True
                        Me.AfficheGroup(g, SelectedGroup, SelectedGroup.rt.Top, TitleSelectedBrushColor, True)
                    End If
                    XPGroupVerif = True
                End If
                For Each XPItem In XPGroup.Items
                    If XPItem.rtItem.Contains(e.X, e.Y) And XPGroup.AfficheListeItem = True And XPItem.Visible = True And XPItem.XPGroup.Visible = True Then
                        If Not XPItem Is SelectedItem Then
                            Dim g As Graphics
                            g = Me.CreateGraphics
                            If Not SelectedItem Is Nothing Then
                                SelectedItem.Selected = False
                                Me.AfficheItemText(g, SelectedItem)
                            End If
                            SelectedItem = XPItem
                            XPItem.Selected = True
                            Me.AfficheItemText(g, SelectedItem)
                        End If
                    End If
                Next
            Next

            If XPGroupVerif = False Then
                If Not SelectedGroup Is Nothing Then
                    Dim g As Graphics
                    g = Me.CreateGraphics
                    Me.AfficheGroup(g, SelectedGroup, SelectedGroup.rt.Top, TitleBrushColor, True)
                    SelectedGroup = Nothing
                End If
            End If

        End Sub

        Dim LastX As Integer
        Dim LastY As Integer

        Private Sub XPBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
            'If Not Me.Parent Is Nothing Then
            '    Me.Parent.Text = "LX:" & LastX & "|" & Me.MousePosition.X & "|" & e.X & "/LY:" & LastY & "|" & Me.MousePosition.Y & "|" & e.Y
            'End If
            If XPBar.MousePosition.X <> LastX Or XPBar.MousePosition.Y <> LastY Then
                LastX = XPBar.MousePosition.X
                LastY = XPBar.MousePosition.Y
                Me.XPBar_SelectItem(sender, e)
            End If
        End Sub

        Private Sub Tx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tx.KeyDown
            Select Case e.KeyCode
                Case Keys.Down
                    If Not Me.SelectedItem Is Nothing Then
                        Dim xpgroup As XPGroup
                        Dim xpitem As XPItem
                        Dim ok As Boolean = False

                        For Each xpitem In Me.SelectedItem.XPGroup.Items
                            If xpitem.Visible = True And xpitem.XPGroup.Visible = True Then
                                If ok = True Then
                                    Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(xpitem.rtItem.Left + 1), CInt(xpitem.rtItem.Top + 1), 0))
                                    Exit Sub
                                End If
                                If xpitem Is Me.SelectedItem Then
                                    ok = True
                                End If
                            End If
                        Next

                        ok = False
                        For Each xpgroup In _oCol
                            If xpgroup.Visible = True Then
                                If ok = True Then
                                    If Convert.ToBoolean(EtatGroupDepart(Me.SelectedItem.XPGroup)) = False Then
                                        If Me.SelectedItem.XPGroup.AfficheListeItem = True Then
                                            Me.SelectedItem.XPGroup.AfficheListeItem = False
                                            Me.AfficheGroups()
                                        End If
                                    End If
                                    If xpgroup.AfficheListeItem = False Then
                                        xpgroup.AfficheListeItem = True
                                        Me.AfficheGroups()
                                        Me.Refresh()
                                    End If
                                    Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(xpgroup.Items(0).rtItem.Left + 1), CInt(xpgroup.Items(0).rtItem.Top + 1), 0))
                                    Exit Sub
                                End If
                                If xpgroup Is Me.SelectedItem.XPGroup Then
                                    ok = True
                                End If
                            End If
                        Next
                    Else
                        Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(Me.Items(0).Items(0).rtItem.Left + 1), CInt(Me.Items(0).Items(0).rtItem.Top + 1), 0))
                    End If

                Case Keys.Up
                    If Not Me.SelectedItem Is Nothing Then
                        Dim xpgroup As XPGroup
                        Dim xpitem As XPItem
                        Dim LastXpItem As XPItem
                        Dim LastXpGroup As XPGroup

                        For Each xpitem In Me.SelectedItem.XPGroup.Items
                            If xpitem.Visible = True And xpitem.XPGroup.Visible = True Then
                                If xpitem Is Me.SelectedItem Then
                                    If Not LastXpItem Is Nothing Then
                                        Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(LastXpItem.rtItem.Left + 1), CInt(LastXpItem.rtItem.Top + 1), 0))
                                        Exit Sub
                                    End If
                                End If
                                LastXpItem = xpitem
                            End If
                        Next


                        For Each xpgroup In _oCol
                            If xpgroup.Visible = True Then
                                If xpgroup Is Me.SelectedItem.XPGroup Then
                                    If Not lastxpgroup Is Nothing Then
                                        If Convert.ToBoolean(EtatGroupDepart(Me.SelectedItem.XPGroup)) = False Then
                                            If Me.SelectedItem.XPGroup.AfficheListeItem = True Then
                                                Me.SelectedItem.XPGroup.AfficheListeItem = False
                                                Me.AfficheGroups()
                                                Me.Refresh()
                                            End If
                                        End If
                                        If lastxpgroup.AfficheListeItem = False Then
                                            lastxpgroup.AfficheListeItem = True
                                            Me.AfficheGroups()
                                            Me.Refresh()
                                        End If
                                        Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(lastxpgroup.Items(lastxpgroup.Items.Count - 1).rtItem.Left + 1), CInt(lastxpgroup.Items(lastxpgroup.Items.Count - 1).rtItem.Top + 1), 0))
                                    End If
                                End If
                                lastxpgroup = xpgroup
                            End If
                        Next
                    Else
                        Me.XPBar_SelectItem(Me, New System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 1, CInt(Me.Items(0).Items(0).rtItem.Left + 1), CInt(Me.Items(0).Items(0).rtItem.Top + 1), 0))
                    End If

                    'Select Case e.KeyCode
                Case Keys.Enter
                    If Not Me.SelectedItem Is Nothing Then
                        RaiseEvent ItemClick(Me.SelectedItem)
                    End If
                    'End Select
                    'If Me.SelectedItem Is Nothing Then
                    'Me.SelectedItem = Me.Items(0).Items(0)
                    'End If
            End Select
            e.Handled = True
        End Sub

        Private Sub Tx_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tx.KeyUp
            e.Handled = True
        End Sub

        Public Sub SetFocus()
            Me.Tx.Select()
        End Sub

        Protected Overloads Overrides Sub [Select](ByVal directed As Boolean, ByVal forward As Boolean)
            'Me.SelectNextControl(Me.Tx, True, True, True, True)
            'Me.Tx.Select()
            'Me.Tx.SelectAll()
        End Sub

        Private Sub Tx_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tx.KeyPress
            e.Handled = True
        End Sub
    End Class

    Public Class XPGroupCollection
        Inherits CollectionBase
        Private _oXPBar As XPBar

        Public Sub New(ByVal oParent As XPBar)
            _oXPBar = oParent
        End Sub

        Public Function Add(ByVal XPGroup As XPGroup) As XPGroup
            Me.List.Add(XPGroup)
            Return XPGroup
        End Function

        Default Public ReadOnly Property Item(ByVal iIndex As Int32) As XPGroup
            Get
                Return CType(Me.List.Item(iIndex), XPGroup)
            End Get
        End Property

        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            _oXPBar.Invalidate()
        End Sub

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            CType(value, XPGroup).SetImageList(_oXPBar.ImageList)
            CType(value, XPGroup).SetXPMenu(_oXPBar)
            _oXPBar.Invalidate()
        End Sub

    End Class

    '<Serializable()> _
    <TypeConverter(GetType(Actigram.Windows.Forms.XPGroupConverter)), Serializable()> _
    Public Class XPGroup
        Private _oCol As XPItemCollection
        Private _oText As String
        Public rtBt As RectangleF
        Public rt As RectangleF
        Private GroupDeploye As Boolean = False
        Public Event ItemClick(ByVal Item As Actigram.Windows.Forms.XPItem)
        Public Event GroupClick()
        Public SelectedItem As Integer = -1
        Private ItemHeight As Integer = 20
        Private _Visible As Boolean = True

        <NonSerialized()> Private _oImageList As ImageList = Nothing

        Protected Friend Sub SetImageList(ByVal oIlist As ImageList)
            _oImageList = oIlist
        End Sub

        Public ReadOnly Property ImageList() As ImageList
            Get
                Return _oImageList
            End Get
        End Property

        <NonSerialized()> Private _oXPBar As XPBar = Nothing
        Protected Friend Sub SetXPMenu(ByVal oXPMenu As XPBar)
            _oXPBar = oXPMenu
        End Sub

        Private _iImageIndex As Int32 = -1

        <Editor("System.Windows.Forms.Design.ImageIndexEditor", GetType(System.Drawing.Design.UITypeEditor)), TypeConverter(GetType(System.Windows.Forms.ImageIndexConverter)), Description("L'index dans l'ImageList associé"), Category("ItemApparence"), DefaultValueAttribute(-1)> _
        Public Property ImageIndex() As Int32
            Get
                Return _iImageIndex
            End Get
            Set(ByVal Value As Int32)
                _iImageIndex = Value
            End Set
        End Property

        Public ReadOnly Property XPBar() As XPBar
            Get
                Return _oXPBar
            End Get
        End Property

        Public Property AfficheListeItem() As Boolean
            Get
                Return GroupDeploye
            End Get
            Set(ByVal Value As Boolean)
                GroupDeploye = Value
            End Set
        End Property

        Public Property TextGroupe() As String
            Get
                Return _oText
            End Get
            Set(ByVal Value As String)
                _oText = Value
            End Set
        End Property

        <DefaultValue(True)> _
        Public Property Visible() As Boolean
            Get
                Return _Visible
            End Get
            Set(ByVal Value As Boolean)
                If Value <> _Visible Then
                    _Visible = Value
                    If Not Me.XPBar Is Nothing Then
                        Me.XPBar.Refresh()
                    End If
                End If
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            _oCol = New XPItemCollection(Me)
        End Sub

        Public Sub New(ByVal sText As String)
            MyBase.New()
            Me.TextGroupe = sText
            _oCol = New XPItemCollection(Me)
        End Sub


        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar)
            MyBase.New()
            _oXPBar = XPMenu
            Me.TextGroupe = sText
            _oCol = New XPItemCollection(Me)
        End Sub

        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar, ByVal LstXPItem() As XPItem)
            MyBase.New()
            _oXPBar = XPMenu
            _oCol = New XPItemCollection(Me)
            Me.TextGroupe = sText
            Dim i As Integer
            For i = 0 To LstXPItem.GetUpperBound(0)
                _oCol.Add(LstXPItem(i))
            Next
        End Sub

        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar, ByVal LstXPItem() As XPItem, ByVal AfficheGroup As Boolean)
            Me.New(sText, XPMenu, LstXPItem)
            Me.AfficheListeItem = AfficheGroup
        End Sub

        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar, ByVal IndexImage As Integer, ByVal LstXPItem() As XPItem, ByVal AfficheGroup As Boolean)
            Me.New(sText, XPMenu, LstXPItem)
            Me.ImageIndex = IndexImage
            Me.AfficheListeItem = AfficheGroup
        End Sub

        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar, ByVal IndexImage As Integer, ByVal LstXPItem() As XPItem, ByVal AfficheGroup As Boolean, ByVal iVisible As Boolean)
            Me.New(sText, XPMenu, LstXPItem)
            Me.ImageIndex = IndexImage
            Me.AfficheListeItem = AfficheGroup
            Me.Visible = iVisible
        End Sub

        Public Sub New(ByVal sText As String, ByVal XPMenu As XPBar, ByVal IndexImage As Integer, ByVal LstXPItem() As XPItem)
            Me.New(sText, XPMenu, LstXPItem)
            'MyBase.New()
            '_oXPBar = XPMenu
            '_oCol = New XPItemCollection(Me)
            'Me.TextGroupe = sText
            Me.ImageIndex = IndexImage
            'Dim i As Integer
            'For i = 0 To LstXPItem.GetUpperBound(0)
            '_oCol.Add(LstXPItem(i))
            'Next
        End Sub

        '<Description("Liste d'items")> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("La collection des Items contenus dans le groupe"), Category("GroupApparence")> _
        Public ReadOnly Property Items() As XPItemCollection
            Get
                Return _oCol
            End Get
        End Property

        Public ReadOnly Property NbItemsVisible() As Integer
            Get
                Dim nbVisible As Integer = 0
                Dim xpItem As XPItem
                For Each xpItem In Me.Items
                    If xpItem.Visible = True Then
                        nbVisible += 1
                    End If
                Next
                Return nbVisible
            End Get
        End Property


    End Class

    Public Class XPItemCollection
        Inherits CollectionBase

        Private _oXPGroup As XPGroup

        Public Sub New(ByVal oParent As XPGroup)
            _oXPGroup = oParent
        End Sub

        Public Function Add(ByVal XPItem As XPItem) As XPItem
            Me.List.Add(XPItem)
            Return XPItem
        End Function

        Default Public ReadOnly Property Item(ByVal iIndex As Int32) As XPItem
            Get
                Return CType(Me.List.Item(iIndex), XPItem)
            End Get
        End Property

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            If Not _oXPGroup.XPBar.ImageListItem Is Nothing Then
                CType(value, XPItem).SetImageList(_oXPGroup.XPBar.ImageListItem)
            Else
                CType(value, XPItem).SetImageList(_oXPGroup.XPBar.ImageList)
            End If
            CType(value, XPItem).SetXPGroup(_oXPGroup)
        End Sub
    End Class

    '<Serializable()> _
    <TypeConverter(GetType(Actigram.Windows.Forms.XPItemConverter)), Serializable()> _
    Public Class XPItem
        Implements ICloneable
        Public rtItem As RectangleF
        Public Selected As Boolean = False
        Public Tag As Object
        Private _Visible As Boolean = True
        Public Event ItemClick(ByVal Item As Actigram.Windows.Forms.XPItem)

        <NonSerialized()> Private _oImageList As ImageList = Nothing

        Protected Friend Sub SetImageList(ByVal oIlist As ImageList)
            _oImageList = oIlist
        End Sub

        Public ReadOnly Property ImageList() As ImageList
            Get
                Return _oImageList
            End Get
        End Property

        <NonSerialized()> Private _oXPGroup As XPGroup = Nothing
        Protected Friend Sub SetXPGroup(ByVal oXPGroup As XPGroup)
            _oXPGroup = oXPGroup
        End Sub

        Public ReadOnly Property XPGroup() As XPGroup
            Get
                Return _oXPGroup
            End Get
        End Property

        Private _oText As String
        Private _oTextColor As Color
        Private _oTextHoverColor As Color
        Private _oBarre As Boolean = False

        Public Property Text() As String
            Get
                Return _oText
            End Get
            Set(ByVal Value As String)
                _oText = Value
            End Set
        End Property

        Public Property TextColor() As Color
            Get
                Return _oTextColor
            End Get
            Set(ByVal Value As Color)
                _oTextColor = Value
            End Set
        End Property

        Public Property TextHoverColor() As Color
            Get
                Return _oTextHoverColor
            End Get
            Set(ByVal Value As Color)
                _oTextHoverColor = Value
            End Set
        End Property

        <DefaultValue(False)> _
        Public Property Barre() As Boolean
            Get
                Return _oBarre
            End Get
            Set(ByVal Value As Boolean)
                _oBarre = Value
            End Set
        End Property

        <DefaultValue(True)> _
        Public Property Visible() As Boolean
            Get
                Return _Visible
            End Get
            Set(ByVal Value As Boolean)
                _Visible = Value
                If Not Me.XPGroup Is Nothing Then
                    Me.XPGroup.XPBar.Refresh()
                End If
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal strText As String, ByVal oColor As Color, ByVal iImageIndex As Int32)
            'Me.New()
            Me.Text = strText
            Me.TextColor = oColor
            Me.ImageIndex = iImageIndex
        End Sub

        Public Sub New(ByVal strText As String, ByVal oColor As Color, ByVal iImageIndex As Int32, ByVal iVisible As Boolean)
            'Me.New()
            Me.Text = strText
            Me.TextColor = oColor
            Me.ImageIndex = iImageIndex
            Me.Visible = iVisible
        End Sub

        Private _iImageIndex As Int32 = -1
        <Editor("System.Windows.Forms.Design.ImageIndexEditor", GetType(System.Drawing.Design.UITypeEditor)), TypeConverter(GetType(System.Windows.Forms.ImageIndexConverter)), Description("L'index dans l'ImageList associé"), Category("ItemApparence"), DefaultValueAttribute(-1)> _
        Public Property ImageIndex() As Int32
            Get
                Return _iImageIndex
            End Get
            Set(ByVal Value As Int32)
                _iImageIndex = Value
            End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New XPItem(Me.Text, Me.TextColor, Me.ImageIndex)
        End Function

        Friend Sub OnClick()
            RaiseEvent ItemClick(Me)
        End Sub
    End Class

    Public Class XPItemConverter
        Inherits System.ComponentModel.TypeConverter

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overloads Overrides Function CanConvertto(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
            If destinationType Is GetType(InstanceDescriptor) Then
                Return True
            End If
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            If destinationType Is GetType(InstanceDescriptor) Then
                Dim oTypes(3) As Type
                oTypes(0) = GetType(String)
                oTypes(1) = GetType(Drawing.Color)
                oTypes(2) = GetType(Int32)
                oTypes(3) = GetType(Boolean)
                Dim ci As Reflection.ConstructorInfo = GetType(Actigram.Windows.Forms.XPItem).GetConstructor(oTypes)
                Dim oArgs(3) As Object
                Dim oXPItem As XPItem = CType(value, XPItem)
                oArgs(0) = oXPItem.Text
                oArgs(1) = oXPItem.TextColor
                oArgs(2) = oXPItem.ImageIndex
                oArgs(3) = oXPItem.Visible
                Return New InstanceDescriptor(ci, oArgs)
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

    Public Class XPGroupConverter
        Inherits System.ComponentModel.TypeConverter

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overloads Overrides Function CanConvertto(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
            If destinationType Is GetType(InstanceDescriptor) Then
                Return True
            End If
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            If destinationType Is GetType(InstanceDescriptor) Then
                Dim oTypes(5) As Type
                oTypes(0) = GetType(String)
                oTypes(1) = GetType(XPBar)
                oTypes(2) = GetType(Integer)
                oTypes(3) = GetType(XPItem())
                oTypes(4) = GetType(Boolean)
                oTypes(5) = GetType(Boolean)
                Dim ci As Reflection.ConstructorInfo = GetType(Actigram.Windows.Forms.XPGroup).GetConstructor(oTypes)
                Dim oArgs(5) As Object
                Dim oXPGroup As XPGroup = CType(value, XPGroup)
                oArgs(0) = oXPGroup.TextGroupe
                oArgs(1) = oXPGroup.XPBar
                oArgs(2) = oXPGroup.ImageIndex
                Dim myLst(oXPGroup.Items.Count - 1) As XPItem
                Dim i As Integer
                For i = 0 To oXPGroup.Items.Count - 1
                    myLst(i) = oXPGroup.Items.Item(i)
                Next
                oArgs(3) = myLst
                oArgs(4) = oXPGroup.AfficheListeItem
                oArgs(5) = oXPGroup.Visible
                Return New InstanceDescriptor(ci, oArgs)
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class



    '************************************************************************
    '*              Classe de Gestion des Listes Assistant
    '************************************************************************

    '    Public Class ListeAssistant
    '        Dim momLstItem As New Collection
    '        Dim momG As Graphics
    '        Dim selectItem As Integer = -1
    '        Dim momBackColor As Color
    '        Dim momText As String
    '        Dim momLeftColorFond As Color
    '        Dim momRightColorFond As Color
    '        Dim momTextSelectedColor As Color
    '        Dim momTextDepartColor As Color
    '        'Public Event ItemClick(ByVal sender As Object, ByVal e As EventArgs)
    '        'Public WithEvents ctlParent As Control

    '#Region "Propriétés"

    '        Public Property TextSelectedColor() As Color
    '            Get
    '                Return momTextSelectedColor
    '            End Get
    '            Set(ByVal Value As Color)
    '                momTextSelectedColor = Value
    '            End Set
    '        End Property

    '        Public Property TextDepartColor() As Color
    '            Get
    '                Return momTextDepartColor
    '            End Get
    '            Set(ByVal Value As Color)
    '                momTextDepartColor = Value
    '            End Set
    '        End Property

    '        Public Property LeftColorFond() As Color
    '            Get
    '                Return momLeftColorFond
    '            End Get
    '            Set(ByVal Value As Color)
    '                momLeftColorFond = Value
    '                Me.Affiche()
    '            End Set
    '        End Property

    '        Public Property RightColorFond() As Color
    '            Get
    '                Return momRightColorFond
    '            End Get
    '            Set(ByVal Value As Color)
    '                momRightColorFond = Value
    '                Me.Affiche()
    '            End Set
    '        End Property

    '        Public Property SelectedItem() As Integer
    '            Get
    '                Return selectItem
    '            End Get
    '            Set(ByVal Value As Integer)
    '                selectItem = Value
    '                Affiche()
    '            End Set
    '        End Property

    '        Public Property Text() As String
    '            Get
    '                Return momText
    '            End Get
    '            Set(ByVal Value As String)
    '                momText = Value
    '                Affiche()
    '            End Set
    '        End Property

    '#End Region

    '        Sub New(ByVal g As Graphics, ByVal BackColor As Color)
    '            momG = g
    '            momBackColor = BackColor
    '            'momLeftColorFond = System.Drawing.Color.LightGreen
    '            momLeftColorFond = Color.FromArgb(192, 196, 111)
    '            momRightColorFond = System.Drawing.Color.White
    '            momTextDepartColor = System.Drawing.Color.Black
    '            momTextSelectedColor = System.Drawing.Color.Red
    '        End Sub

    '        Sub Add(ByVal lb As Label, ByVal lstRect As Collection)
    '            'Dim it As New ItemAssistantListe(lb, lstRect, ctlParent)
    '            Dim it As New ItemAssistantListe(lb, lstRect)
    '            momLstItem.Add(it)
    '            'AddHandler it.ItemClick, AddressOf oneItemClick
    '        End Sub

    '        Sub Affiche()
    '            momG.Clear(momBackColor)

    '            Dim brs As New System.Drawing.Drawing2D.LinearGradientBrush(momG.VisibleClipBounds, momLeftColorFond, momRightColorFond, Drawing2D.LinearGradientMode.Horizontal)
    '            momG.FillRectangle(brs, momG.VisibleClipBounds)

    '            Dim i As Integer
    '            Dim myBrush As Brush
    '            For i = 1 To momLstItem.Count
    '                If i <= selectItem Then
    '                    Dim myPen As New Pen(momTextSelectedColor)
    '                    'myPen = CType(System.Drawing.Pens.CadetBlue.Clone, Pen)
    '                    'myPen.Color = Color.FromArgb(15, 141, 168)
    '                    myPen.Width = 2
    '                    'myBrush = New System.Drawing.SolidBrush(Color.FromArgb(15, 141, 168))
    '                    myBrush = New System.Drawing.SolidBrush(momTextSelectedColor)
    '                    CType(momLstItem(i), ItemAssistantListe).Affiche(momG, myPen, myBrush)
    '                Else
    '                    Dim myPen As New Pen(momTextDepartColor)
    '                    'myPen = CType(System.Drawing.Pens.Blue.Clone, Pen)
    '                    'myPen.Color = Color.FromArgb(15, 141, 168)
    '                    'myPen.Width = 3
    '                    'CType(momLstItem(i), ItemAssistantListe).Affiche(momG, System.Drawing.Pens.Black, System.Drawing.Brushes.Black)
    '                    myBrush = New System.Drawing.SolidBrush(momTextDepartColor)
    '                    CType(momLstItem(i), ItemAssistantListe).Affiche(momG, mypen, myBrush)
    '                End If
    '            Next
    '        End Sub

    '        'Public Sub oneItemClick(ByVal sender As Object, ByVal e As EventArgs)
    '        '    RaiseEvent ItemClick(sender, e)
    '        'End Sub

    '    End Class

    'Public Class ItemAssistantListe
    '    Dim WithEvents momlb As New Label
    '    Dim momlstDessin As Collection
    '    Dim myParent As ListeAssistant
    '    'Dim WithEvents ctlParent As Control
    '    'Public Event ItemClick(ByVal sender As Object, ByVal e As EventArgs)

    '    'Sub ctlparent_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ctlParent.MouseDown
    '    '    If momlb.Left < e.X And (momlb.Left + momlb.Width) > e.X And momlb.Top < e.Y And (momlb.Top + ctlParent.Height) > e.Y Then
    '    '        RaiseEvent ItemClick(momlb, e)
    '    '    End If
    '    'End Sub

    '    'Sub New(ByVal lb As Label, ByVal lstRect As Collection, ByVal momctlParent As Control)
    '    Sub New(ByVal lb As Label, ByVal lstRect As Collection)
    '        momlb = lb
    '        momlstDessin = lstRect
    '        'ctlParent = momctlParent
    '    End Sub

    '    Public Sub Affiche(ByVal g As Graphics, ByVal myPen As Pen, ByVal myBrush As System.Drawing.Brush)
    '        Dim rt As Rectangle
    '        Dim i As Integer
    '        For i = 1 To momlstDessin.Count
    '            rt = CType(momlstDessin(i), Rectangle)
    '            g.DrawLine(myPen, rt.X, rt.Y, rt.X + rt.Width, rt.Y + rt.Height)
    '        Next
    '        g.DrawString(momlb.Text, momlb.Font, myBrush, momlb.Left, momlb.Top)
    '    End Sub
    'End Class


    Public Class DataGridColoredTextBoxColumnA
        Inherits DataGridTextBoxColumn

        Private _BackColorStart As Color = Color.White
        Private _BackColorEnd As Color = Color.White
        Private _ForeColor As Color = Color.Black
        Private _Orientation As Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Vertical
        Private _Font As Font
        Private _TypeReaction As String


#Region "Propriétés"
        Public Property TypeReaction() As String
            Get
                Return _TypeReaction
            End Get
            Set(ByVal Value As String)
                _TypeReaction = Value
            End Set
        End Property

        Public Property BackColorStart() As Color
            Get
                Return _BackColorStart
            End Get
            Set(ByVal Value As Color)
                _BackColorStart = Value
            End Set
        End Property

        Public Property BackColorEnd() As Color
            Get
                Return _BackColorEnd
            End Get
            Set(ByVal Value As Color)
                _BackColorEnd = Value
            End Set
        End Property

        Public Property ForeColor() As Color
            Get
                Return _ForeColor
            End Get
            Set(ByVal Value As Color)
                _ForeColor = Value
            End Set
        End Property

        Public Property GradientMode() As Drawing2D.LinearGradientMode
            Get
                Return _Orientation
            End Get
            Set(ByVal Value As Drawing2D.LinearGradientMode)
                _Orientation = Value
            End Set
        End Property

        Public Property Font() As Font
            Get
                Return _Font
            End Get
            Set(ByVal Value As Font)
                _Font = Value
            End Set
        End Property
#End Region


        Public Sub New()
            'AddHandler Me.TextBox.KeyPress, AddressOf KeyPress
        End Sub

        Private Sub KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            'If e.KeyChar = "/" Then
            'MsgBox(e.KeyChar)
            'e.Handled = True
            'End If
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            Try
                If _BackColorStart.ToArgb.Equals(_BackColorEnd.ToArgb) Then
                    backBrush = New System.Drawing.SolidBrush(_BackColorStart)
                Else
                    backBrush = New System.Drawing.Drawing2D.LinearGradientBrush(bounds, _BackColorStart, _BackColorEnd, _Orientation)
                    'backBrush = New System.Drawing.Drawing2D.LinearGradientBrush(bounds, Color.Yellow, Color.White, Drawing2D.LinearGradientMode.Horizontal)
                End If

                foreBrush = New SolidBrush(_ForeColor)
                'foreBrush = New SolidBrush(Color.White)
            Catch ex As Exception
            Finally
                'MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

                'Dim [date] As DateTime = CType(getcolumnvalueatrow([source], rowNum), DateTime)
                Dim rect As Rectangle = bounds
                g.FillRectangle(backBrush, rect)
                rect.Offset(0, 2)
                rect.Height -= 2
                If Not Me.Font Is Nothing Then
                    Dim stF As New StringFormat
                    Select Case Me.Alignment
                        Case HorizontalAlignment.Center
                            stF.Alignment = StringAlignment.Center
                        Case HorizontalAlignment.Left
                            stF.Alignment = StringAlignment.Near
                        Case HorizontalAlignment.Right
                            stF.Alignment = StringAlignment.Far
                    End Select
                    Dim strToWrite As String
                    If IsDBNull(getcolumnvalueatrow(source, rowNum)) = True Then
                        strToWrite = Me.NullText
                    Else
                        strToWrite = CType(getcolumnvalueatrow(source, rowNum), String)
                    End If

                    If Me.Format <> "" Then
                        'stF.Alignment = CType(Me.Alignment, StringAlignment)
                        If strToWrite = "" Then strToWrite = "0"
                        g.DrawString(Convert.ToDecimal(strToWrite).ToString(Me.Format), Me.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                    Else
                        g.DrawString(strToWrite, Me.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                    End If
                Else
                    MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
                    'g.DrawString(CType(getcolumnvalueatrow(source, rowNum), String), Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
                End If

            End Try
        End Sub
    End Class


    Public Class DataGridComboBoxColumn
        Inherits DataGridTextBoxColumn
        Public WithEvents cb As New ComboBox
        Private WithEvents tx As System.Windows.Forms.TextBox
        Private WithEvents bt As New System.Windows.Forms.Button
        Private masource As System.Windows.Forms.CurrencyManager
        Private maLigne As Integer
        Public CbDv As DataView
        'Public CbDisplay As String
        Private LstRecup As New Hashtable
        Private _AfficheButton As Boolean = True
        Public Event BtClick()

#Region "Propriétés"

        Public Property AfficheButton() As Boolean
            Get
                Return _AfficheButton
            End Get
            Set(ByVal Value As Boolean)
                _AfficheButton = Value
                If _AfficheButton = True Then
                    cb.Width = Me.TextBox.Width - Me.TextBox.Height + 4
                Else
                    cb.Width = Me.TextBox.Width
                End If
                bt.Left = cb.Width - 2
                Me.bt.Visible = _AfficheButton
            End Set
        End Property

        Public ReadOnly Property ListeRecup() As Hashtable
            Get
                Return LstRecup
            End Get
        End Property

#End Region

        Public Sub New()
            cb.Font = Me.TextBox.Font
            cb.BackColor = Me.TextBox.BackColor
            cb.ForeColor = Me.TextBox.ForeColor
            'cb.Location = Me.TextBox.Location
            cb.Top = Me.TextBox.Top - 2
            cb.Left = Me.TextBox.Left - 2
            cb.Height = Me.TextBox.Height + 4
            cb.Cursor = System.Windows.Forms.Cursors.Hand
            bt.Left = cb.Width - 2
            bt.Top = 0
            bt.Width = Me.TextBox.Height - 6
            bt.Height = Me.TextBox.Height - 3
            bt.FlatStyle = FlatStyle.Flat
            Me.bt.Visible = Me.AfficheButton
            If Me.AfficheButton = True Then
                cb.Width = Me.TextBox.Width - Me.TextBox.Height + 4
            Else
                cb.Width = Me.TextBox.Width
            End If
            Me.TextBox.Controls.Add(bt)
            Me.TextBox.Controls.Add(cb)

            'If Me.ReadOnly = True Then
            '    cb.Enabled = False
            '    bt.Enabled = False
            'Else
            '    cb.Enabled = True
            '    bt.Enabled = True
            'End If

            tx = Me.TextBox
        End Sub

        Private Sub DataGridComboBoxColumn_WidthChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WidthChanged
            'cb.Width = Me.TextBox.Width - Me.TextBox.Height + 2
            'bt.Left = cb.Width
        End Sub

        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            'If [readOnly] = True Then Exit Sub

            MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
            If [readOnly] = True Then
                cb.Enabled = False
                bt.Enabled = False
            Else
                cb.Enabled = True
                bt.Enabled = True
            End If

            Try
                cb.Text = CType(Me.GetColumnValueAtRow(source, rowNum), String)
            Catch
                cb.Text = Me.NullText
            End Try
            If Me.AfficheButton = True Then
                cb.Width = Me.Width - Me.TextBox.Height + 2
                bt.Left = cb.Width - 2
            Else
                cb.Width = Me.Width
            End If
            'masource = source
            'maLigne = rowNum
        End Sub

        Private Sub cb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb.TextChanged
            'tx.Text = cb.Text
            Dim strComp As String = Me.NullText
            Try
                Try
                    If Me.DataGridTableStyle.DataGrid.ReadOnly = True Then Exit Sub
                Catch
                End Try
                masource = CType(Me.DataGridTableStyle.DataGrid.BindingContext(Me.DataGridTableStyle.DataGrid.DataSource, Me.DataGridTableStyle.DataGrid.DataMember), CurrencyManager)
                maLigne = Me.DataGridTableStyle.DataGrid.CurrentRowIndex
                If Not IsDBNull(Me.GetColumnValueAtRow(masource, maLigne)) Then
                    strComp = CType(Me.GetColumnValueAtRow(masource, maLigne), String)
                End If
                If cb.Text <> strComp Then
                    If cb.Text.Length = 0 Then
                        Me.SetColumnValueAtRow(masource, maLigne, DBNull.Value)
                    Else
                        Me.SetColumnValueAtRow(masource, maLigne, cb.Text)
                    End If
                    If cb.Text.Length > 0 Then
                        Dim i As IDictionaryEnumerator
                        If CbDv.Find(cb.Text) >= 0 Then
                            Dim dvR As DataRowView
                            'dvR = CType(cb.DataSource, DataView).Item(CType(cb.DataSource, DataView).Find(cb.Text))
                            dvR = CbDv.Item(CbDv.Find(cb.Text))
                            i = LstRecup.GetEnumerator
                            Do Until i.MoveNext = False
                                If i.Value.GetType.IsValueType Then
                                    Me.DataGridTableStyle.DataGrid(maLigne, Convert.ToInt32(i.Key)) = i.Value
                                Else
                                    Me.DataGridTableStyle.DataGrid(maLigne, Convert.ToInt32(i.Key)) = dvR.Item(Convert.ToString(i.Value))
                                End If
                            Loop
                        Else
                            i = LstRecup.GetEnumerator
                            Do Until i.MoveNext = False
                                Me.DataGridTableStyle.DataGrid(maLigne, Convert.ToInt32(i.Key)) = DBNull.Value
                            Loop
                        End If

                        Me.ColumnStartedEditing(cb)
                        Me.Edit(masource, maLigne, Me.DataGridTableStyle.DataGrid.GetCurrentCellBounds, Me.ReadOnly, cb.Text)
                    Else
                        Me.ColumnStartedEditing(cb)
                        Me.Edit(masource, maLigne, Me.DataGridTableStyle.DataGrid.GetCurrentCellBounds, Me.ReadOnly, cb.Text)
                    End If
                End If
                cb.Select()
                cb.SelectionStart = cb.Text.Length
                'Dim fr As Form
                'Dim ms As CurrencyManager
                'Dim ctl As Control
                'ctl = Me.DataGridTableStyle.DataGrid.Parent
                'Do Until TypeOf ctl Is Form
                'ctl = ctl.Parent
                'Loop
                'fr = CType(ctl, Form)
                'masource = CType(fr.BindingContext(Me.DataGridTableStyle.DataGrid.DataSource, Me.DataGridTableStyle.DataGrid.DataMember).Current, CurrencyManager)
                'Me.SetColumnValueAtRow(masource, Me.DataGridTableStyle.DataGrid.CurrentRowIndex, cb.Text)
            Catch
            End Try
        End Sub

        Private Sub bt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt.Click
            RaiseEvent BtClick()
        End Sub

        Private Sub cb_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb.KeyUp
            Dim strCh As String = ""
            Try
                If Me.ReadOnly = True Then Exit Sub
            Catch
            End Try

            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up _
            Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Delete Then
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                If cb.SelectionStart > 0 Then
                    cb.Text = cb.Text.Substring(0, cb.SelectionStart - 1)
                    cb.SelectionStart = cb.Text.Length
                End If
            End If

            Dim sellen As Integer = 0
            sellen = cb.SelectionStart

            If sellen > 0 Then
                strCh = cb.Text.Substring(0, sellen)

                Dim it As Object
                For Each it In cb.Items
                    If cb.GetItemText(it).ToUpper.StartsWith(strCh.ToUpper) = True Then
                        cb.SelectedIndex = cb.Items.IndexOf(it)
                        cb.SelectionStart = sellen
                        cb.SelectionLength = cb.Text.Length - cb.SelectionStart
                        Exit For
                    End If
                Next
                'Me.SelectionStart += 1
                ''Me.SelectionLength = Me.Text.Length - Me.SelectionStart
                'Me.SelectionLength = 1
            End If
        End Sub

        Private Sub tx_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tx.GotFocus
            Try
                If Me.DataGridTableStyle.DataGrid.ReadOnly = True Then Exit Sub
            Catch
            End Try
            Me.cb.Select()
        End Sub

        Private Sub cb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb.KeyPress
            Try
                If Me.DataGridTableStyle.DataGrid.ReadOnly = True Then Exit Sub
            Catch
            End Try
            If e.KeyChar = ","c Or e.KeyChar = "."c Then
                Dim ciCC As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
                CType(sender, ComboBox).SelectedText = ciCC.NumberFormat.NumberDecimalSeparator
                e.Handled = True
            End If
        End Sub

    End Class

    Public Class DataGridTextBoxColumnParentRelationChampsMultiples
        Inherits DataGridTextBoxColumn

        Private _Liaison As String
        Private _Champs As String
        Private _Expression As String = ""
        Private _ExpressionCleParent As String = ""
        Private _ExpressionCleEnfant As String = ""
        Private _TableCompute As String
        Private _ValeurSiZero As String

#Region "Propriétés"

        Public Property ValeurSiZero() As String
            Get
                Return _ValeurSiZero
            End Get
            Set(ByVal Value As String)
                _ValeurSiZero = Value
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

        Public Property TableCompute() As String
            Get
                Return _TableCompute
            End Get
            Set(ByVal Value As String)
                _TableCompute = Value
            End Set
        End Property

        Public Property ExpressionCleParent() As String
            Get
                Return _ExpressionCleParent
            End Get
            Set(ByVal Value As String)
                _ExpressionCleParent = Value
            End Set
        End Property

        Public Property ExpressionCleEnfant() As String
            Get
                Return _ExpressionCleEnfant
            End Get
            Set(ByVal Value As String)
                _ExpressionCleEnfant = Value
            End Set
        End Property

        Public Property Liaison() As String
            Get
                Return _Liaison
            End Get
            Set(ByVal Value As String)
                _Liaison = Value
            End Set
        End Property

        Public Property Champs() As String
            Get
                Return _Champs
            End Get
            Set(ByVal Value As String)
                _Champs = Value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
            Me.ReadOnly = True
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            Try
                Dim strPb As String = ""
                'Dim rect As Rectangle = bounds
                Dim strToWrite As String = ""
                'Dim stF As New StringFormat
                'Select Case Me.Alignment
                '    Case HorizontalAlignment.Center
                '        stF.Alignment = StringAlignment.Center
                '    Case HorizontalAlignment.Left
                '        stF.Alignment = StringAlignment.Near
                '    Case HorizontalAlignment.Right
                '        stF.Alignment = StringAlignment.Far
                'End Select


                Dim rw As DataRow
                rw = CType(source.List(rowNum), DataRowView).Row

                If Not _Liaison Is Nothing Then
                    Dim a() As String
                    Dim b As String
                    a = _Liaison.Split("."c)
                    For Each b In a
                        rw = rw.GetParentRow(b)
                    Next
                End If

                Dim Obj As Object
                If Not rw Is Nothing Then
                    If Me.Expression <> "" Then
                        'Try
                        Dim a() As String
                        Dim b As String
                        a = Me.Expression.Split("+"c)
                        Dim str As String = ""
                        For Each b In a
                            b = b.Trim
                            If b.IndexOf("'") >= 0 Then
                                b = b.Replace("'", "")
                            Else
                                If rw.Item(b) Is DBNull.Value Then
                                    b = Me.NullText
                                Else
                                    b = Convert.ToString(rw.Item(b))
                                End If
                            End If
                            str += b
                        Next
                        Obj = str

                        'Obj = rw.Table.DataSet.Tables(TableCompute).Compute(Me.Expression, Me.ExpressionCleEnfant & "=" & Convert.ToString(rw.Item(Me.ExpressionCleParent)))

                        'If Not Obj Is DBNull.Value Then
                        '    If Not CType(source.List(rowNum), DataRowView).Item("MontantTTC") Is DBNull.Value Then
                        '        Obj = Convert.ToDecimal(CType(source.List(rowNum), DataRowView).Item("MontantTTC")) - Convert.ToDecimal(Obj)
                        '    End If
                        'End If
                        ''Catch
                        ''strPb = "Expression Non valide"
                        ''End Try
                    Else
                        Obj = rw.Item(_Champs)
                    End If
                End If

                If Not Obj Is Nothing Then
                    If Not Obj Is DBNull.Value Then
                        If Obj.GetType.IsValueType Then
                            If Not _Champs Is Nothing Then
                                If rw.Table.Columns(_Champs).DataType.ToString = GetType(Date).ToString Then
                                    Dim strFormat As String = Me.Format
                                    If Me.Format = "" Then
                                        strFormat = "dd/MM/yyyy"
                                    End If
                                    strToWrite = Convert.ToDateTime(Obj).ToString(strFormat)
                                End If
                            End If
                            If strToWrite = "" Then
                                strToWrite = Convert.ToDecimal(Obj).ToString(Me.Format)
                                If Convert.ToDecimal(Obj) = 0 Then
                                    If Not Me.ValeurSiZero Is Nothing Then
                                        strToWrite = Me.ValeurSiZero
                                    End If
                                End If
                            End If
                        Else
                            strToWrite = Convert.ToString(Obj)
                        End If
                    Else
                        strToWrite = Me.NullText
                    End If
                Else
                    strToWrite = Convert.ToString(rw.Item(_Champs))
                    'strToWrite = Me.NullText
                End If
                'strToWrite = Convert.ToString(CType(source.Current, DataRowView).Row.GetParentRow(_Liaison).Item(_Champs))
                g.FillRectangle(backBrush, bounds)
                'g.DrawString(strToWrite, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                'Else

                'strPb = "La Liaison '" & _Liaison & "' n'existe pas"
                'End If
                If strPb <> "" Then
                    g.FillRectangle(backBrush, bounds)
                    'g.DrawString(strPb, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                    Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                End If
            Catch ex As Exception
                MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            End Try

        End Sub

        Protected Overrides Sub Abort(ByVal rowNum As Integer)

        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        End Function

        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        End Sub

        Protected Overrides Function GetMinimumHeight() As Integer

        End Function

        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

        End Function

        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

        End Function

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)

        End Sub
    End Class

    Public Class DataGridTextBoxColumnParentRelation
        Inherits DataGridTextBoxColumn

        Private _Liaison As String
        Private _Champs As String
        Private _Expression As String = ""
        Private _ExpressionCleParent As String = ""
        Private _ExpressionCleEnfant As String = ""
        Private _TableCompute As String
        Private _ValeurSiZero As String

#Region "Propriétés"

        Public Property TableCompute() As String
            Get
                Return _TableCompute
            End Get
            Set(ByVal Value As String)
                _TableCompute = Value
            End Set
        End Property

        Public Property ValeurSiZero() As String
            Get
                Return _ValeurSiZero
            End Get
            Set(ByVal Value As String)
                _ValeurSiZero = Value
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

        Public Property ExpressionCleParent() As String
            Get
                Return _ExpressionCleParent
            End Get
            Set(ByVal Value As String)
                _ExpressionCleParent = Value
            End Set
        End Property

        Public Property ExpressionCleEnfant() As String
            Get
                Return _ExpressionCleEnfant
            End Get
            Set(ByVal Value As String)
                _ExpressionCleEnfant = Value
            End Set
        End Property

        Public Property Liaison() As String
            Get
                Return _Liaison
            End Get
            Set(ByVal Value As String)
                _Liaison = Value
            End Set
        End Property

        Public Property Champs() As String
            Get
                Return _Champs
            End Get
            Set(ByVal Value As String)
                _Champs = Value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
            Me.ReadOnly = True
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            Try
                Dim strPb As String = ""
                'Dim rect As Rectangle = bounds
                Dim strToWrite As String = ""
                'Dim stF As New StringFormat
                'Select Case Me.Alignment
                '    Case HorizontalAlignment.Center
                '        stF.Alignment = StringAlignment.Center
                '    Case HorizontalAlignment.Left
                '        stF.Alignment = StringAlignment.Near
                '    Case HorizontalAlignment.Right
                '        stF.Alignment = StringAlignment.Far
                'End Select

                Dim rw As DataRow
                rw = CType(source.List(rowNum), DataRowView).Row

                If Not _Liaison Is Nothing Then
                    Dim a() As String
                    Dim b As String
                    a = _Liaison.Split("."c)
                    For Each b In a
                        rw = rw.GetParentRow(b)
                    Next
                End If

                Dim Obj As Object
                If Not rw Is Nothing Then
                    If Me.Expression <> "" Then
                        'Try

                        Obj = rw.Table.DataSet.Tables(TableCompute).Compute(Me.Expression, Me.ExpressionCleEnfant & "=" & Convert.ToString(rw.Item(Me.ExpressionCleParent)))

                        If Not Obj Is DBNull.Value Then
                            If Not CType(source.List(rowNum), DataRowView).Item("MontantTTC") Is DBNull.Value Then
                                Obj = Convert.ToDecimal(CType(source.List(rowNum), DataRowView).Item("MontantTTC")) - Convert.ToDecimal(Obj)
                                'If CType(source.List(rowNum), DataRowView).DataView.Table.Columns.Contains("Paye") Then
                                '    If Convert.ToDecimal(Obj) = 0 And Convert.ToBoolean(CType(source.List(rowNum), DataRowView).Item("Paye")) = False Then
                                '        CType(source.List(rowNum), DataRowView).Item("Paye") = True
                                '        source.EndCurrentEdit()
                                '    End If
                                'End If
                            End If
                        End If
                        'Catch
                        'strPb = "Expression Non valide"
                        'End Try
                    Else
                        Obj = rw.Item(_Champs)
                    End If
                End If

                If Not Obj Is Nothing Then
                    If Not Obj Is DBNull.Value Then
                        If Obj.GetType.IsValueType Then
                            If Not _Champs Is Nothing Then
                                If rw.Table.Columns(_Champs).DataType.ToString = GetType(Date).ToString Then
                                    Dim strFormat As String = Me.Format
                                    If Me.Format = "" Then
                                        strFormat = "dd/MM/yyyy"
                                    End If
                                    strToWrite = Convert.ToDateTime(Obj).ToString(strFormat)
                                End If
                            End If
                            If strToWrite = "" Then
                                strToWrite = Convert.ToDecimal(Obj).ToString(Me.Format)
                                If Convert.ToDecimal(Obj) = 0 Then
                                    If Not Me.ValeurSiZero Is Nothing Then
                                        strToWrite = Me.ValeurSiZero
                                    End If
                                End If
                            End If
                        Else
                            strToWrite = Convert.ToString(rw.Item(_Champs))
                        End If
                    Else
                        strToWrite = Me.NullText
                    End If
                Else
                    strToWrite = Me.NullText
                End If
                'strToWrite = Convert.ToString(CType(source.Current, DataRowView).Row.GetParentRow(_Liaison).Item(_Champs))
                g.FillRectangle(backBrush, bounds)
                'g.DrawString(strToWrite, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                'Else

                'strPb = "La Liaison '" & _Liaison & "' n'existe pas"
                'End If
                If strPb <> "" Then
                    g.FillRectangle(backBrush, bounds)
                    'g.DrawString(strPb, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                    Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                End If
            Catch ex As Exception
                MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            End Try

        End Sub

        Protected Overrides Sub Abort(ByVal rowNum As Integer)

        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        End Function

        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        End Sub

        Protected Overrides Function GetMinimumHeight() As Integer

        End Function

        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

        End Function

        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

        End Function

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)

        End Sub
    End Class

    Public Class DataGridTextBoxColumnDate
        Inherits DataGridTextBoxColumn

        Public Sub New()
            MyBase.New()
            Me.ReadOnly = True
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            Try
                Dim strPb As String = ""
                Dim strToWrite As String = ""
                Dim obj As Object
                obj = GetColumnValueAtRow(source, rowNum)
                Dim Paye As Boolean = False
                If source.Position <> -1 Then
                    If Not CType(source.Current, DataRowView).DataView(rowNum).Item("Paye") Is DBNull.Value Then
                        Paye = Convert.ToBoolean(CType(source.Current, DataRowView).DataView(rowNum).Item("Paye"))
                    End If
                End If

                'If Paye = False Then
                If Not obj Is DBNull.Value Then
                    obj = Now.Subtract(Convert.ToDateTime(obj)).Days
                End If
                'End If

                If Not obj Is Nothing Then
                    If Not obj Is DBNull.Value Then
                        If obj.GetType.IsValueType Then
                            If strToWrite = "" Then
                                strToWrite = Convert.ToInt32(obj).ToString(Me.Format)
                                If Convert.ToDecimal(obj) <= 0 Then
                                    strToWrite = Me.NullText
                                End If
                            End If
                        Else
                            strToWrite = Me.NullText
                        End If
                    Else
                        strToWrite = Me.NullText
                    End If
                Else
                    strToWrite = Me.NullText
                End If
                'strToWrite = Convert.ToString(CType(source.Current, DataRowView).Row.GetParentRow(_Liaison).Item(_Champs))
                g.FillRectangle(backBrush, bounds)
                'g.DrawString(strToWrite, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                If Paye = False Then
                    Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                End If
                'Else

                'strPb = "La Liaison '" & _Liaison & "' n'existe pas"
                'End If
                If strPb <> "" Then
                    g.FillRectangle(backBrush, bounds)
                    'g.DrawString(strPb, Me.DataGridTableStyle.DataGrid.Font, foreBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom), stF)
                    If Paye = False Then
                        Me.PaintText(g, bounds, strToWrite, backBrush, foreBrush, alignToRight)
                    End If
                End If
            Catch ex As Exception
                MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            End Try

        End Sub

        Protected Overrides Sub Abort(ByVal rowNum As Integer)

        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        End Function

        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        End Sub

        Protected Overrides Function GetMinimumHeight() As Integer

        End Function

        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

        End Function

        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

        End Function

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)

        End Sub
    End Class

    Public Class LabelImage
        Inherits Label

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(pevent)
        End Sub

        Private Sub LabelImage_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            Dim rtDepart As New Rectangle
            rtDepart.X = Me.Left
            rtDepart.Y = Me.Top
            rtDepart.Width = Me.Width
            rtDepart.Height = Me.Height
            Dim rtButton As New Rectangle
            rtButton.X = 0
            rtButton.Y = 0
            rtButton.Height = Me.Height
            rtButton.Width = Me.Width

            Dim g As Graphics
            g = e.Graphics
            If Not Me.Parent.BackgroundImage Is Nothing Then
                g.DrawImage(Me.Parent.BackgroundImage, rtButton, rtDepart, GraphicsUnit.Pixel)
            Else
                g.Clear(Me.BackColor)
            End If
            If Not Me.Image Is Nothing Then
                If Me.Enabled = False Then
                    Dim rt As New Rectangle
                    rt.X = Convert.ToInt32(Me.Width / 2 - Me.Image.Width / 2)
                    rt.Y = Convert.ToInt32(Me.Height / 2 - Me.Image.Height / 2)
                    rt.Height = Me.Image.Height
                    rt.Width = Me.Image.Width

                    Dim oBit As New Bitmap(Me.Image)
                    Dim im As New Imaging.ImageAttributes
                    Dim oItems(,) As Single = {{1, 0, 0, 0, 0}, {0, 1, 0, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 0, 0.5, 0}, {0, 0, 0, 0, 1}}
                    Dim mx As New Imaging.ColorMatrix
                    Dim iR As Integer
                    Dim iC As Integer
                    For iR = 0 To 4
                        For iC = 0 To 4
                            mx.Item(iR, iC) = oItems(iR, iC)
                        Next
                    Next
                    im.SetColorMatrix(mx)
                    'g.DrawImage(oBit, rtGroupImage)
                    Select Case Me.ImageAlign
                        Case ContentAlignment.MiddleLeft
                            rt.X = 0
                        Case ContentAlignment.MiddleRight
                            rt.X = rtButton.Width - rt.Width
                    End Select
                    g.DrawImage(oBit, rt, 0, 0, Me.Image.Width, Me.Image.Height, GraphicsUnit.Pixel, im)

                    'g.DrawImage(Me.Image, rt)
                Else
                    Dim rt As New Rectangle
                    rt.X = Convert.ToInt32((Me.Width - Me.Image.Width) / 2)
                    rt.Y = Convert.ToInt32(Me.Height / 2 - Me.Image.Height / 2)
                    rt.Height = Me.Image.Height
                    rt.Width = Me.Image.Width
                    Select Case Me.ImageAlign
                        Case ContentAlignment.MiddleLeft
                            rt.X = 0
                        Case ContentAlignment.MiddleRight
                            rt.X = rtButton.Width - rt.Width
                    End Select
                    g.DrawImage(Me.Image, rt)
                End If
            End If
            Dim ft As New StringFormat
            Select Case Me.TextAlign
                Case ContentAlignment.MiddleLeft
                    ft.Alignment = StringAlignment.Near
                Case ContentAlignment.MiddleRight
                    ft.Alignment = StringAlignment.Far
                Case ContentAlignment.MiddleCenter
                    ft.Alignment = StringAlignment.Center
            End Select
            Dim rtT As New RectangleF
            rtT.X = 0
            rtT.Y = 0
            rtT.Width = Me.Width
            rtT.Height = Me.Height
            Dim sf As New SizeF
            sf.Width = Me.Width
            sf.Height = Me.Height
            rtT.Y = (Me.Height - g.MeasureString(Me.Text, Me.Font, sf, ft).Height) / 2
            g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), rtT, ft)
            'Select Case EtatContour
            '    Case BoutonContour.Down
            '        ContourDown(g)
            '    Case BoutonContour.Up
            '        ContourUp(g)
            '    Case Else
            '        ResetContour(g)
            'End Select
        End Sub

    End Class

    Public Class BoutonImage
        Inherits Button

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(pevent)
        End Sub

        Enum BoutonContour
            Reset = 0
            Up = 1
            Down = 2
        End Enum

        Private EtatContour As BoutonContour = BoutonContour.Reset

        Private Sub MyBtII_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseHover
            EtatContour = BoutonContour.Up
            ContourUp(Me.CreateGraphics)
        End Sub

        Private Sub MyBtII_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
            ResetContour(Me.CreateGraphics)
        End Sub

        Private Sub MyBtII_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            EtatContour = BoutonContour.Down
            ContourDown(Me.CreateGraphics)
        End Sub

        Private Sub MyBtII_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
            Try
                ResetContour(Me.CreateGraphics)
            Catch
            End Try
        End Sub

        Private Sub ContourDown(ByVal g As Graphics)
            'EtatContour = BoutonContour.Down
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            Dim pts(3) As PointF
            pts(0) = New PointF(0, Me.Height)
            pts(1) = New PointF(Me.Width, Me.Height)
            pts(2) = New PointF(Me.Width, 0)
            pts(3) = New PointF(0, 0)
            path.AddLines(pts)
            path.CloseAllFigures()
            g.DrawPath(New Pen(Color.FromArgb(150, 0, 0, 0), 2), path)
            'g.DrawPath(New Pen(Color.Gray, 2), path)
        End Sub

        Private Sub ContourUp(ByVal g As Graphics)
            'EtatContour = BoutonContour.Up
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            Dim pts(2) As PointF
            pts(0) = New PointF(0, Me.Height)
            pts(1) = New PointF(Me.Width, Me.Height)
            pts(2) = New PointF(Me.Width, 0)
            path.AddLines(pts)
            g.DrawPath(New Pen(Color.FromArgb(150, 0, 0, 0), 2), path)
        End Sub

        Private Sub ResetContour(ByVal g As Graphics)
            EtatContour = BoutonContour.Reset
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            Dim pts(3) As PointF
            pts(0) = New PointF(0, Me.Height)
            pts(1) = New PointF(Me.Width, Me.Height)
            pts(2) = New PointF(Me.Width, 0)
            pts(3) = New PointF(0, 0)
            path.AddLines(pts)
            path.CloseAllFigures()
            If Not Me.Parent.BackgroundImage Is Nothing Then
                Dim rt As RectangleF
                rt.X = Me.Left
                rt.Y = Me.Top
                rt.Height = Me.Height
                rt.Width = Me.Width
                Dim br As New TextureBrush(Me.Parent.BackgroundImage, rt)
                g.DrawPath(New Pen(br, 2), path)
            Else
                g.DrawPath(New Pen(Me.BackColor, 2), path)
            End If
        End Sub

        Private Sub BoutonImage_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            Dim rtDepart As New Rectangle
            rtDepart.X = Me.Left
            rtDepart.Y = Me.Top
            rtDepart.Width = Me.Width
            rtDepart.Height = Me.Height
            Dim rtButton As New Rectangle
            rtButton.X = 0
            rtButton.Y = 0
            rtButton.Height = Me.Height
            rtButton.Width = Me.Width

            Dim g As Graphics
            g = e.Graphics
            If Not Me.Parent.BackgroundImage Is Nothing Then
                If Me.BackColor.ToArgb <> Me.Parent.BackColor.ToArgb Then
                    g.Clear(Me.BackColor)
                Else
                    g.DrawImage(Me.Parent.BackgroundImage, rtButton, rtDepart, GraphicsUnit.Pixel)
                End If
            Else
                g.Clear(Me.BackColor)
            End If
            If Not Me.Image Is Nothing Then
                If Me.Enabled = False Then
                    Dim rt As New Rectangle
                    rt.X = Convert.ToInt32(Me.Width / 2 - Me.Image.Width / 2)
                    rt.Y = Convert.ToInt32(Me.Height / 2 - Me.Image.Height / 2)
                    rt.Height = Me.Image.Height
                    rt.Width = Me.Image.Width

                    Dim oBit As New Bitmap(Me.Image)
                    Dim im As New Imaging.ImageAttributes
                    Dim oItems(,) As Single = {{1, 0, 0, 0, 0}, {0, 1, 0, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 0, 0.5, 0}, {0, 0, 0, 0, 1}}
                    Dim mx As New Imaging.ColorMatrix
                    Dim iR As Integer
                    Dim iC As Integer
                    For iR = 0 To 4
                        For iC = 0 To 4
                            mx.Item(iR, iC) = oItems(iR, iC)
                        Next
                    Next
                    im.SetColorMatrix(mx)
                    im.SetColorKey(Color.Gray, Color.White)
                    ''g.DrawImage(oBit, rtGroupImage)
                    Select Case Me.ImageAlign
                        Case ContentAlignment.MiddleLeft
                            rt.X = 0
                        Case ContentAlignment.MiddleRight
                            rt.X = rtButton.Width - rt.Width
                    End Select
                    g.DrawImage(oBit, rt, 0, 0, Me.Image.Width, Me.Image.Height, GraphicsUnit.Pixel, im)

                    'g.DrawImage(Me.Image, rt)
                Else
                    Dim rt As New Rectangle
                    rt.X = Convert.ToInt32((Me.Width - Me.Image.Width) / 2)
                    rt.Y = Convert.ToInt32(Me.Height / 2 - Me.Image.Height / 2)
                    rt.Height = Me.Image.Height
                    rt.Width = Me.Image.Width
                    Select Case Me.ImageAlign
                        Case ContentAlignment.MiddleLeft
                            rt.X = 0
                        Case ContentAlignment.MiddleRight
                            rt.X = rtButton.Width - rt.Width
                    End Select
                    g.DrawImage(Me.Image, rt)
                End If
            End If
            Dim ft As New StringFormat
            Select Case Me.TextAlign
                Case ContentAlignment.MiddleLeft
                    ft.Alignment = StringAlignment.Near
                Case ContentAlignment.MiddleRight
                    ft.Alignment = StringAlignment.Far
                Case ContentAlignment.MiddleCenter
                    ft.Alignment = StringAlignment.Center
            End Select
            Dim rtT As New RectangleF
            rtT.X = 0
            rtT.Y = 0
            rtT.Width = Me.Width
            rtT.Height = Me.Height
            Dim sf As New SizeF
            sf.Width = Me.Width
            sf.Height = Me.Height
            rtT.Y = (Me.Height - g.MeasureString(Me.Text, Me.Font, sf, ft).Height) / 2
            g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), rtT, ft)
            Select Case EtatContour
                Case BoutonContour.Down
                    ContourDown(g)
                Case BoutonContour.Up
                    ContourUp(g)
                Case Else
                    ResetContour(g)
            End Select
        End Sub

        Private Sub BoutonImage_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
            Me.EtatContour = BoutonContour.Up
        End Sub

        Private Sub BoutonImage_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus
            Me.EtatContour = BoutonContour.Reset
        End Sub
    End Class

    Public Class DataGridTextBoxColumnNumber
        Inherits DataGridTextBoxColumn
        Private WithEvents tx As TextBox

        Public Sub New()
            MyBase.New()
            tx = Me.TextBox
        End Sub


        Protected Overrides Sub Abort(ByVal rowNum As Integer)
            MyBase.Abort(rowNum)
        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
            Return MyBase.Commit(dataSource, rowNum)
        End Function

        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
        End Sub

        Protected Overrides Function GetMinimumHeight() As Integer
            Return MyBase.GetMinimumHeight()
        End Function

        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer
            Return MyBase.GetPreferredHeight(g, value)
        End Function

        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size
            Return MyBase.GetPreferredSize(g, value)
        End Function

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)
            MyBase.Paint(g, bounds, source, rowNum)
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, alignToRight)
        End Sub

        Private Sub tx_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx.KeyPress
            If e.KeyChar = ","c Or e.KeyChar = "."c Then
                CType(sender, TextBox).SelectedText = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                e.Handled = True
            End If
        End Sub
    End Class


End Namespace