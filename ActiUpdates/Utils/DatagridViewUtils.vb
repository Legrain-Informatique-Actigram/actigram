Imports System.Windows.Forms.VisualStyles

Module DatagridViewUtils

    Public Sub dg_GestionClicDroit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender Is Nothing Then Exit Sub
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.DataSource Is Nothing Then Exit Sub
        If Not TypeOf dgv.DataSource Is BindingSource Then Exit Sub
        Dim bs As BindingSource = CType(dgv.DataSource, BindingSource)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hi As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
            If hi.Type = DataGridViewHitTestType.Cell Or hi.Type = DataGridViewHitTestType.RowHeader Then
                Dim r As DataGridViewRow = dgv.Rows(hi.RowIndex)
                If r.DataBoundItem IsNot Nothing Then
                    bs.Position = bs.IndexOf(r.DataBoundItem)
                End If
                If r.DataGridView IsNot Nothing Then
                    r.Selected = True
                End If
            End If
        End If
    End Sub

    Public Sub dg_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs)
        If e.DesiredType.Name = "Decimal" Then
            Dim s As String = Convert.ToString(e.Value)
            s = s.Replace(",", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
            s = s.Replace(".", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
            s = s.Replace("%", "")
            s = s.Replace(My.Application.Culture.NumberFormat.CurrencySymbol, "")
            Dim d As Decimal
            If Decimal.TryParse(s.Trim, d) Then
                e.Value = d
                e.ParsingApplied = True
            End If
        End If
    End Sub

    Public Sub dg_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        If TypeOf e.Exception Is ArgumentException AndAlso e.Exception.Message.Contains("DataGridViewComboBoxCell") Then
        ElseIf Not TypeOf e.Exception Is UserCancelledException Then
            MsgBox(e.Exception.Message, MsgBoxStyle.Exclamation, "Erreur")
        End If
        e.ThrowException = False
    End Sub

    Public Sub ApplyStyle(ByVal dgv As DataGridView, Optional ByVal readOnlyGrid As Boolean = True)
        With dgv
            .AllowUserToResizeRows = False
            .AlternatingRowsDefaultCellStyle = alternateCellStyle()
            .BackgroundColor = System.Drawing.Color.Gainsboro
            '.BackgroundColor = System.Drawing.SystemColors.Window
            .CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
            .RowsDefaultCellStyle = cellStyle()
            If readOnlyGrid Then
                .RowHeadersVisible = False
                .SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Else
                AddHandler .DataError, AddressOf dg_DataError
                AddHandler .CellParsing, AddressOf dg_CellParsing
            End If
        End With
    End Sub

    Public Function alternateCellStyle() As System.Windows.Forms.DataGridViewCellStyle
        Dim style As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        With style
            .BackColor = System.Drawing.Color.Lavender
            .SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192)
            .SelectionForeColor = Color.Black
        End With
        Return style
    End Function

    Public Function cellStyle() As System.Windows.Forms.DataGridViewCellStyle
        Dim style As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        With style
            .BackColor = System.Drawing.SystemColors.Window
            .SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192)
            .SelectionForeColor = Color.Black
        End With
        Return style
    End Function
End Module

#Region "DataGridViewDisableButtonColumn"
Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    Private _img As Image
    Public Property Image() As Image
        Get
            Return _img
        End Get
        Set(ByVal value As Image)
            _img = value
            CType(Me.CellTemplate, DataGridViewDisableButtonCell).Image = Me.Image
        End Set
    End Property


    Private _ImageAlign As System.Drawing.ContentAlignment
    Public Property ImageAlign() As System.Drawing.ContentAlignment
        Get
            Return _ImageAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            _ImageAlign = value
        End Set
    End Property


    Public Sub New()
        MyBase.New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub

    Public Overrides Function Clone() As Object
        Dim col As DataGridViewDisableButtonColumn = CType(MyBase.Clone(), DataGridViewDisableButtonColumn)
        col.CellTemplate = Me.CellTemplate
        col.Image = Me.Image()
        col.ImageAlign = Me.ImageAlign
        Return col
    End Function

End Class

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean
    Public Property Enabled() As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property


    Private visibleValue As Boolean
    Public Property ButtonVisible() As Boolean
        Get
            Return visibleValue
        End Get
        Set(ByVal value As Boolean)
            visibleValue = value
        End Set
    End Property


    Private _img As Image
    Public Property Image() As Image
        Get
            Return _img
        End Get
        Set(ByVal value As Image)
            _img = value
        End Set
    End Property


    ' Override the Clone method so that the Enabled property is copied.
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell = CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Cell.ButtonVisible = Me.ButtonVisible
        Cell.Image = Me.Image
        Return Cell
    End Function

    ' By default, enable the button cell.
    Public Sub New()
        MyBase.New()
        Me.enabledValue = True
        Me.visibleValue = True
    End Sub

    Private mouseOverRow As Integer
    Protected Overrides Sub OnMouseEnter(ByVal rowIndex As Integer)
        mouseOverRow = rowIndex
        MyBase.OnMouseEnter(rowIndex)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal rowIndex As Integer)
        If mouseOverRow = rowIndex Then mouseOverRow = -1
        MyBase.OnMouseLeave(rowIndex)
    End Sub

    Private mouseDown As Boolean
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        mouseDown = True
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        mouseDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics, _
        ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, _
        ByVal rowIndex As Integer, _
        ByVal elementState As DataGridViewElementStates, _
        ByVal value As Object, ByVal formattedValue As Object, _
        ByVal errorText As String, _
        ByVal cellStyle As DataGridViewCellStyle, _
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
        ByVal paintParts As DataGridViewPaintParts)

        ' The button cell is disabled, so paint the border,  
        ' background, and disabled button for the cell.
        If Not Me.visibleValue Then
            PaintCell(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle, paintParts)
        Else
            PaintCell(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle, paintParts)

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = CalcButtonArea(cellBounds, advancedBorderStyle)

            Dim buttonText As String = ""
            If Me.UseColumnTextForButtonValue Then
                buttonText = CType(Me.OwningColumn, DataGridViewDisableButtonColumn).Text
            Else
                Try
                    buttonText = CStr(Me.FormattedValue)
                Catch
                End Try
            End If

            Dim buttonState As VisualStyles.PushButtonState
            If Not Me.enabledValue Then
                buttonState = PushButtonState.Disabled
            ElseIf mouseDown Then
                buttonState = PushButtonState.Pressed
            ElseIf mouseOverRow = rowIndex Then
                buttonState = PushButtonState.Hot
            Else
                buttonState = PushButtonState.Normal
            End If

            'If Not Me.enabledValue Then
            ' Draw the disabled button.                
            'ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)
            ' Draw the disabled button text. 
            'If TypeOf Me.FormattedValue Is String Then
            'TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            'End If
            If Me.Image IsNot Nothing Then
                Dim imageArea As Rectangle = CalcImageArea(buttonArea, CType(Me.OwningColumn, DataGridViewDisableButtonColumn).ImageAlign)
                ButtonRenderer.DrawButton(graphics, buttonArea, buttonText, Me.DataGridView.Font, TextFormatFlags.GlyphOverhangPadding Or TextFormatFlags.Left Or TextFormatFlags.VerticalCenter, Me.Image, imageArea, False, buttonState)
            Else
                ButtonRenderer.DrawButton(graphics, buttonArea, buttonText, Me.DataGridView.Font, False, buttonState)
            End If

            'Else
            'If Me.Image IsNot Nothing Then
            'ButtonRenderer.DrawButton(graphics, buttonArea, CStr(Me.FormattedValue), Me.DataGridView.Font, Me.Image, imageArea, False, PushButtonState.Normal)
            'Else
            'ButtonRenderer.DrawButton(graphics, buttonArea, CStr(Me.FormattedValue), Me.DataGridView.Font, False, PushButtonState.Normal)
            'End If
        End If
        'Else
        ' The button cell is enabled, so let the base class 
        ' handle the painting.
        'MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        ' End If
    End Sub


    Private Function CalcButtonArea(ByVal cellBounds As Rectangle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle) As Rectangle
        Dim buttonArea As Rectangle = cellBounds
        Dim buttonAdjustment As Rectangle = Me.BorderWidths(advancedBorderStyle)
        buttonArea.X += buttonAdjustment.X
        buttonArea.Y += buttonAdjustment.Y
        buttonArea.Height -= buttonAdjustment.Height
        buttonArea.Width -= buttonAdjustment.Width
        Return buttonArea
    End Function

    Private Enum Aligns
        Top = &H1
        Left = &H1
        Center = &H2
        Right = &H4
        Middle = &H10
        Bottom = &H100
    End Enum

    Private Function CalcImageArea(ByVal buttonArea As Rectangle, ByVal imageAlign As System.Drawing.ContentAlignment) As Rectangle
        Dim p As New Padding(4) 'ButtonPadding
        Dim s As New Size(16, 16) 'ImageSize
        Dim r As New Rectangle(buttonArea.Location, s)
        Dim vAlign As Aligns
        If imageAlign >= Aligns.Bottom Then : vAlign = Aligns.Bottom
        ElseIf imageAlign >= Aligns.Middle Then : vAlign = Aligns.Middle
        Else : vAlign = Aligns.Top
        End If
        Dim hAlign As Aligns = CType(imageAlign \ vAlign, Aligns)

        If hAlign = Aligns.Left Then
            r.X += p.Left
        ElseIf hAlign = Aligns.Center Then
            r.X += (buttonArea.Width - s.Width) \ 2
        ElseIf hAlign = Aligns.Right Then
            r.X = buttonArea.Right - p.Right - r.Width
        End If

        If vAlign = Aligns.Top Then
            r.Y += p.Top
        ElseIf vAlign = Aligns.Middle Then
            r.Y += (buttonArea.Height - s.Height) \ 2
        ElseIf vAlign = Aligns.Bottom Then
            r.Y = buttonArea.Bottom - p.Bottom - r.Height
        End If

        Return r
    End Function


    Private Sub PaintCell(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        ' Draw the background of the cell, if specified.
        If (paintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            Dim c As Color = cellStyle.BackColor
            If Me.Selected Then
                c = cellStyle.SelectionBackColor
            End If
            Using cellBackground As New SolidBrush(c)
                graphics.FillRectangle(cellBackground, cellBounds)
            End Using
        End If

        ' Draw the cell borders, if specified.
        If (paintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
        End If
    End Sub
End Class
#End Region

#Region "DatagridViewNumericTextBoxColumn"

Public Class DatagridViewNumericTextBoxColumn
    Inherits DataGridViewTextBoxColumn

    Public Sub New()
        Me.CellTemplate = New DatagridViewNumericTextBoxCell()
    End Sub
End Class

Public Class DatagridViewNumericTextBoxCell
    Inherits System.Windows.Forms.DataGridViewTextBoxCell

    Public Overrides ReadOnly Property EditType() As System.Type
        Get
            Return GetType(DataGridViewNumericTextBoxEditingControl)
        End Get
    End Property
End Class

Public Class DataGridViewNumericTextBoxEditingControl
    Inherits DataGridViewTextBoxEditingControl

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        If Not IsValidForNumberInput(e.KeyChar) Then
            e.Handled = True
        Else
            MyBase.OnKeyPress(e)
        End If
    End Sub
End Class
#End Region

#Region "DatagridViewComboboxColumnCustom"
Public Class DatagridViewComboboxColumnCustom
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Me.CellTemplate = New DatagridViewComboboxCellCustom()
    End Sub
End Class

Public Class DatagridViewComboboxCellCustom
    Inherits System.Windows.Forms.DataGridViewComboBoxCell

    Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
        Return MyBase.GetValue(rowIndex)
    End Function

    'Protected Overrides Sub OnEnter(ByVal rowIndex As Integer, ByVal throughMouseClick As Boolean)
    '    MyBase.DataGridView.BeginEdit(True)
    'End Sub

End Class


#End Region
