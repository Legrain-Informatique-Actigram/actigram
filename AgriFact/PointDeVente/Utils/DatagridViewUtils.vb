Imports System.Windows.Forms.VisualStyles

Module DatagridViewUtils

    Public Sub dg_ZoomTextBoxCells(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        If TypeOf Cast(Of DataGridView)(sender).Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
            FrModifTxt.ZoomTextBoxCell(Cast(Of DataGridViewTextBoxCell)(Cast(Of DataGridView)(sender).Rows(e.RowIndex).Cells(e.ColumnIndex)))
        End If
    End Sub

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

''' <summary>
''' Class permettant de gÃ©rer le grid de saisie spÃ©cifique tablÃ© sur un datagrid classique
''' ''' </summary>
''' <remarks></remarks>
Public Class DataGridViewEnter
    Inherits System.Windows.Forms.DataGridView


#Region "Gestion de la navigation dans la grille"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Delete Then
            MyBase.CurrentCell.Value = MyBase.CurrentCell.OwningColumn.DefaultCellStyle.NullValue
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function

    'This override causes the DataGridView to use the enter key in a similar way as
    'the tab key
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Enter Then
            Return Me.ProcessRightKey(keyData)
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private prevCell As DataGridViewCell = Nothing
    Private MousePress As Boolean = False

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnCellMouseDown(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        MousePress = True
        MyBase.OnCellMouseDown(e)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnCellEnter(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If Me.CurrentCell.ReadOnly Then 'If Convert.ToString(MyBase.CurrentCell.Tag) = "True" Then
            If prevCell IsNot Nothing Then
                If prevCell.RowIndex > e.RowIndex OrElse prevCell.ColumnIndex > e.ColumnIndex Then
                    SendKeys.Send("{LEFT}")
                Else
                    If Not MousePress Then
                        SendKeys.Send("{TAB}")
                    End If
                    MousePress = False
                End If
            End If
        Else
            prevCell = MyBase.CurrentCell
            MyBase.OnCellEnter(e)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnCellBeginEdit(ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If Me.CurrentCell.ReadOnly Then 'If Convert.ToString(Me.CurrentCell.Tag) = "True" Then
            e.Cancel = True
        Else
            MyBase.OnCellBeginEdit(e)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overloads Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        Try
            If e.KeyCode = Keys.Enter Then
                Return Me.ProcessRightKey(e.KeyData)
            ElseIf e.KeyCode = Keys.Left Then
                Return Me.ProcessLeftKey(e.KeyData)
            ElseIf e.KeyCode = Keys.Right Then
                Return Me.ProcessRightKey(e.KeyData)
            Else
                Return MyBase.ProcessDataGridViewKey(e)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function ProcessLeftKey(ByVal keyData As Keys) As Boolean
        If MyBase.CurrentCell.ColumnIndex = 0 And MyBase.CurrentCell.RowIndex > 0 Then
            MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex - 1).Cells(MyBase.ColumnCount - 1)
            Return True
        Else
            Return MyBase.ProcessLeftKey(keyData)
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function ProcessRightKey(ByVal keyData As Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)

        If key = Keys.Enter Then
            Dim lastCol As Boolean = (MyBase.CurrentCell.ColumnIndex = (MyBase.ColumnCount - 1))
            Dim lastRow As Boolean = (MyBase.CurrentCell.RowIndex = (MyBase.RowCount - 1))
            If lastCol AndAlso lastRow Then
                'This causes the last cell to be checked for errors
                If MyBase.AllowUserToAddRows Then
                    MyBase.EndEdit()
                    DirectCast(MyBase.DataSource, BindingSource).AddNew()
                    MyBase.CurrentCell = MyBase.Rows(MyBase.NewRowIndex).Cells(0)
                Else
                    Return False
                End If
                Return True
            ElseIf lastCol Then 'AndAlso (MyBase.CurrentCell.RowIndex + 1 <> MyBase.NewRowIndex) Then
                MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex + 1).Cells(0)
                Return True
            ElseIf lastRow And Not lastCol Then
                If MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(0).Value Is Nothing OrElse MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(0).Value.ToString = "0000000" Then
                    MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(0)
                Else
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                    'Return MyBase.ProcessRightKey(keyData)                    
                End If
                Return True
            Else
                Return MyBase.ProcessDialogKey(Keys.Tab)
                'Return MyBase.ProcessRightKey(keyData)               
                'Return MyBase.ProcessDialogKey(Keys.Tab)
            End If
        Else
            Return MyBase.ProcessRightKey(keyData)
        End If
    End Function
#End Region

#Region "Gestion des autocompletes"
    Public AutocompletColsMode1 As New List(Of DataGridViewColumn)
    Public AutocompletColsMode2 As New List(Of DataGridViewColumn)
    Public AutocompletColsMode3 As New List(Of DataGridViewColumn)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConfigAutocompleteCombobox()
        AddHandler Me.EditingControlShowing, AddressOf OnAutocompleteControlShowing
        AddHandler Me.CellLeave, AddressOf OnAutocompleteCellLeave
    End Sub

    Private cb As ComboBox
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnAutocompleteControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        If TypeOf e.Control Is ComboBox Then
            Dim cell As DataGridViewCell = Me.CurrentCell
            If AutocompletColsMode1.Contains(cell.OwningColumn) OrElse AutocompletColsMode2.Contains(cell.OwningColumn) Then
                Dim col As DataGridViewComboBoxColumn = CType(cell.OwningColumn, DataGridViewComboBoxColumn)
                If col.DataSource IsNot Nothing AndAlso TypeOf col.DataSource Is BindingSource Then
                    Dim bs As BindingSource = CType(col.DataSource, BindingSource)
                    If cell.Value Is Nothing Then
                        bs.Position = -1
                    Else
                        bs.Position = bs.Find(col.ValueMember, cell.Value)
                    End If
                End If

                cb = CType(e.Control, ComboBox)
                With cb
                    .DropDownStyle = ComboBoxStyle.DropDown
                    If AutocompletColsMode2.Contains(cell.OwningColumn) Then
                        AddHandler .Enter, AddressOf ComboEnter
                    Else
                        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    End If
                    AddHandler .PreviewKeyDown, AddressOf ComboPreviewKeyDown
                End With
            ElseIf AutocompletColsMode3.Contains(cell.OwningColumn) Then
                cb = CType(e.Control, ComboBox)
                With cb
                    .DropDownStyle = ComboBoxStyle.DropDown
                    AddHandler .Enter, AddressOf ComboEnter
                    AddHandler .PreviewKeyDown, AddressOf ComboPreviewKeyDown
                End With
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If cb Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            cb.Text = CType(sender, DataGridViewComboBoxEditingControl).Text
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboEnter(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, ComboBox).Items.Count > 1 Then
            CType(sender, ComboBox).DroppedDown = True
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnAutocompleteCellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If AutocompletColsMode1.Contains(Me.Columns(e.ColumnIndex)) OrElse AutocompletColsMode2.Contains(Me.Columns(e.ColumnIndex)) Then
            If Not cb Is Nothing Then
                Dim pos As Integer = cb.FindString(cb.Text)
                If pos >= 0 Then
                    cb.SelectedIndex = pos
                End If
            End If
            cb = Nothing
        End If
    End Sub
#End Region

End Class