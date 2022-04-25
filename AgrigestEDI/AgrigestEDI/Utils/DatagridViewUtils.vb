Imports System.ComponentModel

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

        If e.DesiredType.FullName Like "*System.Decimal*" Then
            Dim s As String = Convert.ToString(e.Value)
            If s.Length = 0 Then
                Dim col As DataGridViewColumn = CType(sender, DataGridView).CurrentCell.OwningColumn
                e.Value = col.DefaultCellStyle.NullValue
                e.ParsingApplied = True
            Else
                s = s.Replace("%", "")
                s = s.Replace(My.Application.Culture.NumberFormat.CurrencySymbol, "")
                If s.IndexOfAny(New Char() {"+"c, "-"c, "*"c, "/"c}, 0) >= 0 Then
                    s = s.Replace(",", ".")
                    Dim xEval As New Eval.Evaluator
                    Try
                        Dim nResultEval As Double = xEval.EvalDouble(s)

                        e.Value = Convert.ToDecimal(nResultEval)
                    Catch ex As Exception
                    End Try
                    e.ParsingApplied = True
                Else
                    s = s.Replace(",", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
                    s = s.Replace(".", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
                    Dim d As Decimal
                    If Decimal.TryParse(s.Trim, d) Then
                        e.Value = d
                        e.ParsingApplied = True
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub dg_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        If TypeOf e.Exception Is ArgumentException AndAlso e.Exception.Message.Contains("DataGridViewComboBoxCell") OrElse e.Exception.Message.Contains("rowIndex") OrElse e.Exception.Message.Contains("Length") Then
            'If TypeOf e.Exception Is ArgumentException AndAlso e.Exception.Message.Contains("DataGridViewComboBoxCell") OrElse e.Exception.Message.Contains("rowIndex") Then
        ElseIf Not TypeOf e.Exception Is UserCancelledException Then
            LogException(e.Exception)
#If DEBUG Then
            MsgBox("Erreur : " + e.Exception.Message, MsgBoxStyle.Exclamation, "Erreur")
            'MsgBox("Erreur : " + e.Exception.Message + vbCrLf + e.Exception.InnerException.Message + vbCrLf + " Ficher : " + e.Exception.TargetSite.ReflectedType.FullName + "function : " + e.Exception.TargetSite.Name + " Ligne : " + Microsoft.VisualBasic.Right(e.Exception.StackTrace, Len(e.Exception.StackTrace) - InStr(e.Exception.StackTrace.ToString, ":ligne ", CompareMethod.Text) - 6), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
#Else
            MsgBox(e.Exception.Message, MsgBoxStyle.Exclamation, "Erreur" )
#End If
        End If
        e.ThrowException = False
    End Sub

    Public Sub ApplyStyle(ByVal dgv As DataGridView, Optional ByVal readOnlyGrid As Boolean = True)
        With dgv
            .AllowUserToResizeRows = False
            .AlternatingRowsDefaultCellStyle = alternateCellStyle()
            .BackgroundColor = System.Drawing.SystemColors.Window
            .CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
            .RowsDefaultCellStyle = cellStyle()
            If readOnlyGrid Then
                .RowHeadersVisible = False
                .SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            End If
        End With
    End Sub

    Public Function alternateCellStyle() As System.Windows.Forms.DataGridViewCellStyle
        Dim style As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        With style
            .WrapMode = DataGridViewTriState.True
            .BackColor = System.Drawing.Color.Lavender
            .SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192)
            .SelectionForeColor = Color.Black
        End With
        Return style
    End Function

    Public Function cellStyle() As System.Windows.Forms.DataGridViewCellStyle
        Dim style As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        With style
            .WrapMode = DataGridViewTriState.True
            .SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192)
            .SelectionForeColor = Color.Black
        End With
        Return style
    End Function

End Module

#Region "DataGridViewDisableButton"
Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    Private _displayButtonOnCurrentCellOnly As Boolean = False

#Region "Propriétés"
    Public Property DisplayButtonOnCurrentCellOnly() As Boolean
        Get
            Return _displayButtonOnCurrentCellOnly
        End Get
        Set(ByVal value As Boolean)
            _displayButtonOnCurrentCellOnly = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub
#End Region

End Class

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

#Region "Propriétés"
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
#End Region

#Region "Constructeurs"
    Public Sub New()
        Me.enabledValue = True
        Me.visibleValue = True
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell = CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Cell.ButtonVisible = Me.ButtonVisible
        Return Cell
    End Function

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
        Dim vis As Boolean = Me.visibleValue
        If vis AndAlso CType(Me.OwningColumn, DataGridViewDisableButtonColumn).DisplayButtonOnCurrentCellOnly Then
            If Me.DataGridView.CurrentRow IsNot Nothing Then
                vis = (rowIndex = Me.DataGridView.CurrentRow.Index)
            End If
        End If
        If Not vis Then
            PaintCell(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle, paintParts)

            ' Draw the text. 
            If TypeOf formattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(formattedValue), Me.DataGridView.Font, cellBounds, Me.Style.ForeColor)
            End If
        ElseIf Not Me.enabledValue Then
            PaintCell(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle, paintParts)

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle = Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.                
            ButtonRenderer.DrawButton(graphics, buttonArea, VisualStyles.PushButtonState.Disabled)

            ' Draw the disabled button text. 
            If TypeOf formattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(formattedValue), Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            End If
        Else
            ' The button cell is enabled, so let the base class 
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub

    Private Sub PaintCell(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        ' Draw the background of the cell, if specified.
        If (paintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            Using cellBackground As New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
            End Using
        End If

        ' Draw the cell borders, if specified.
        If (paintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
        End If
    End Sub
#End Region

End Class
#End Region

#Region "DatagridViewDatePickerColumn"
Public Class DatagridViewDatePickerColumn
    Inherits DataGridViewColumn

    Private dMinDate As Date
    Private dMaxDate As Date

#Region "Constructeurs"
    Public Sub New()
        MyBase.New(New DatagridViewDatePickerCell())
    End Sub
#End Region

#Region "Propriétés"
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(DatagridViewDatePickerCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

    Public Property MinDate() As Date
        Get
            Return dMinDate
        End Get
        Set(ByVal value As Date)
            dMinDate = value
        End Set
    End Property

    Public Property MaxDate() As Date
        Get
            Return dMaxDate
        End Get
        Set(ByVal value As Date)
            dMaxDate = value
        End Set
    End Property
#End Region

End Class

Public Class DatagridViewDatePickerCell
    Inherits DataGridViewTextBoxCell

#Region "Constructeurs"
    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(DatagridViewDatePickerEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property
#End Region

#Region "Méthodes diverses"
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
         ByVal initialFormattedValue As Object, _
         ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As DatagridViewDatePickerEditingControl = _
            CType(DataGridView.EditingControl, DatagridViewDatePickerEditingControl)
        ctl.Value = CType(Me.Value, DateTime)
        With CType(Me.OwningColumn, DatagridViewDatePickerColumn)
            If .MinDate > Date.MinValue Then ctl.MinDate = .MinDate
            If .MaxDate > Date.MinValue Then ctl.MaxDate = .MaxDate
        End With

        If TypeOf Me.Value Is Date Then
            ctl.Value = CDate(Me.Value)
        Else
            ctl.Value = Today
        End If

    End Sub
#End Region

End Class

Class DatagridViewDatePickerEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

#Region "Constructeurs"
    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub
#End Region

#Region "Propriétés"
    Public Property EditingControlFormattedValue() As Object _
         Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToShortDateString()
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
          As Boolean Implements _
          IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
          Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
          Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
         Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get
    End Property

    Public Property EditingControlRowIndex() As Integer _
          Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property
#End Region

#Region "Méthodes diverses"
    Public Function GetEditingControlFormattedValue(ByVal context _
          As DataGridViewDataErrorContexts) As Object _
          Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
          DataGridViewCellStyle) _
          Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
          ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
          Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey 'False
        End Select
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
         Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
#End Region

End Class
#End Region

#Region "DatagridViewTextBoxAutoCompleteColumn"
''' <summary>
''' Class permettant de gérer un textbox dans un grid avec un système d'autocomplete
''' </summary>
''' <remarks></remarks>
Public Class DatagridViewTextBoxAutoCompleteColumn
    Inherits DataGridViewColumn

    Private sAutocompleteString As AutoCompleteStringCollection
    Private xAutoCompleteMode As AutoCompleteMode
    Private xAutoCompleteSource As AutoCompleteSource
    Private nMaxLenght As Integer

#Region "Constructeurs"
    Public Sub New()
        MyBase.New(New DatagridViewTextBoxAutoCompleteCell())
    End Sub
#End Region

#Region "Propriétés"
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(DatagridViewTextBoxAutoCompleteCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

    <Bindable(True), _
          Category("Appearance"), _
          Description("liste des élements à filter")> _
      Public Overridable Property AutocompleteString() As AutoCompleteStringCollection
        Get
            Return sAutocompleteString
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            sAutocompleteString = value
        End Set
    End Property

    <Bindable(True), _
            Category("Appearance"), _
            DefaultValue(AutoCompleteSource.CustomSource), _
            Description("AutoCompleteSource")> _
        Public Property AutoCompleteSource() As AutoCompleteSource
        Get
            Return xAutoCompleteSource
        End Get
        Set(ByVal value As AutoCompleteSource)
            xAutoCompleteSource = value
        End Set
    End Property

    <Bindable(True), _
            Category("Appearance"), _
            DefaultValue(AutoCompleteMode.SuggestAppend), _
            Description("AutoCompleteMode")> _
        Public Property AutoCompleteMode() As AutoCompleteMode
        Get
            Return xAutoCompleteMode
        End Get
        Set(ByVal value As AutoCompleteMode)
            xAutoCompleteMode = value
        End Set
    End Property

    <Bindable(True), _
             Category("Appearance"), _
             DefaultValue(50), _
             Description("Max Lenght")> _
         Public Property MaxLenght() As Integer
        Get
            Return nMaxLenght
        End Get
        Set(ByVal value As Integer)
            nMaxLenght = value
        End Set
    End Property
#End Region

End Class

Public Class DatagridViewTextBoxAutoCompleteCell
    Inherits DataGridViewTextBoxCell

#Region "Constructeurs"
    Public Sub New()
    End Sub
#End Region

#Region "Propriétés"
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(DatagridViewTextBoxAutoCompleteEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return ""
        End Get
    End Property
#End Region

#Region "Méthodes diverses"
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
         ByVal initialFormattedValue As Object, _
         ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As DatagridViewTextBoxAutoCompleteEditingControl = _
            CType(DataGridView.EditingControl, DatagridViewTextBoxAutoCompleteEditingControl)
        ctl.AutoCompleteCustomSource = CType(Me.OwningColumn, DatagridViewTextBoxAutoCompleteColumn).AutocompleteString
        ctl.AutoCompleteMode = CType(Me.OwningColumn, DatagridViewTextBoxAutoCompleteColumn).AutoCompleteMode
        ctl.AutoCompleteSource = CType(Me.OwningColumn, DatagridViewTextBoxAutoCompleteColumn).AutoCompleteSource
        ctl.MaxLength = CType(Me.OwningColumn, DatagridViewTextBoxAutoCompleteColumn).MaxLenght
    End Sub
#End Region

End Class

Class DatagridViewTextBoxAutoCompleteEditingControl
    Inherits TextBox
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

#Region "Constructeurs"
    Public Sub New()
    End Sub
#End Region

#Region "Propriétés"
    Public Property EditingControlFormattedValue() As Object _
          Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Text()
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Text = CStr(value)
            End If
        End Set
    End Property

    Public Property EditingControlRowIndex() As Integer _
         Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
          As Boolean Implements _
          IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
           Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
          Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
          Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property
#End Region

#Region "Méthodes diverses"
    Public Function GetEditingControlFormattedValue(ByVal context _
           As DataGridViewDataErrorContexts) As Object _
           Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Text()
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
          DataGridViewCellStyle) _
          Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
    End Sub

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
          ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
          Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case key And Keys.KeyCode
            Case Keys.Up, Keys.Down
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey 'False
        End Select
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
          Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnTextChanged(eventargs)
    End Sub
#End Region

End Class
#End Region

#Region "DatagridViewComboboxColumnCustom"
''' <summary>
''' Class permettant de gérer un combobox customisé pour la saisie de N° de compte
''' </summary>
''' <remarks></remarks>
Public Class DatagridViewComboboxColumnCustom
    Inherits DataGridViewComboBoxColumn

#Region "Propriétés"
    Private _displayComboBoxOnCurrentCellOnly As Boolean = False
    Public Property DisplayComboBoxOnCurrentCellOnly() As Boolean
        Get
            Return _displayComboBoxOnCurrentCellOnly
        End Get
        Set(ByVal value As Boolean)
            _displayComboBoxOnCurrentCellOnly = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        Me.CellTemplate = New DatagridViewComboboxCellCustom()
    End Sub
#End Region

End Class

Public Class DatagridViewComboboxCellCustom
    Inherits System.Windows.Forms.DataGridViewComboBoxCell

#Region "Méthodes diverses"
    Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
        'Return MyBase.GetFormattedValue(value, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
        Return MyBase.GetValue(rowIndex)
    End Function

    Protected Overrides Sub OnEnter(ByVal rowIndex As Integer, ByVal throughMouseClick As Boolean)
        If Convert.ToString(Me.Tag) = "True" Then
            MyBase.DataGridView.EndEdit()
        Else
            MyBase.DataGridView.BeginEdit(True)
        End If
    End Sub

    Public Overrides Function ParseFormattedValue(ByVal formattedValue As Object, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal valueTypeConverter As System.ComponentModel.TypeConverter) As Object
        Try
            Return MyBase.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter)
        Catch ex As Exception
            If Len(Convert.ToString(formattedValue)) > 7 Then
                Return Left(Convert.ToString(formattedValue), 8)
            Else
                Return Convert.ToString(formattedValue)
            End If
        End Try
    End Function
#End Region

End Class
#End Region

#Region "DatagridViewNumericTextBoxColumn"
''' <summary>
''' Class permettant de gérer un textbox avec seulement une saisie de numérique.
''' </summary>
''' <remarks></remarks>
Public Class DatagridViewNumericTextBoxColumn
    Inherits DataGridViewTextBoxColumn

#Region "Constructeurs"
    Public Sub New()
        Me.CellTemplate = New DatagridViewNumericTextBoxCell()
    End Sub
#End Region

End Class

Public Class DatagridViewNumericTextBoxCell
    Inherits System.Windows.Forms.DataGridViewTextBoxCell

#Region "Propriétés"
    Public Overrides ReadOnly Property EditType() As System.Type
        Get
            Return GetType(DataGridViewNumericTextBoxEditingControl)
        End Get
    End Property
#End Region

End Class

Public Class DataGridViewNumericTextBoxEditingControl
    Inherits DataGridViewTextBoxEditingControl

#Region "Méthodes diverses"
    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        If Not IsValidForNumberInput(e.KeyChar) Then
            e.Handled = True
        Else
            MyBase.OnKeyPress(e)
        End If
    End Sub
#End Region

End Class
#End Region


''' <summary>
''' Class permettant de gérer le grid de saisie spécifique tablé sur un datagrid classique
''' ''' </summary>
''' <remarks></remarks>
Public Class DataGridViewEnter
    Inherits System.Windows.Forms.DataGridView
    Private Const COL_CRE As Integer = 5
    Private Const COL_DEB As Integer = 4

#Region "Propriétés"
    Private _JumpToMontant As Boolean = False
    ''' <summary>
    ''' Permet de savoir s'il faut sauter ou non vers la case suivante
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>cela sautera a la case suivant dont la propriété readonly est false</remarks>
    Public Property JumpToMontant() As Boolean
        Get
            Return _JumpToMontant
        End Get
        Set(ByVal value As Boolean)
            _JumpToMontant = value
        End Set
    End Property
#End Region

#Region "Gestion de la navigation dans la grille"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Delete Then
            MyBase.CurrentCell.Value = MyBase.CurrentCell.OwningColumn.DefaultCellStyle.NullValue
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function

    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Enter Then
            Return Me.ProcessRightKey(keyData)
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private prevCell As DataGridViewCell = Nothing
    Private MousePress As Boolean = False

    Protected Overrides Sub OnCellMouseDown(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        MousePress = True
        Try
            MyBase.OnCellMouseDown(e)
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnCellEnter(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If Convert.ToString(MyBase.CurrentCell.Tag) = "True" Then '.ReadOnly Then
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

    Protected Overrides Sub OnCellBeginEdit(ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If Convert.ToString(Me.CurrentCell.Tag) = "True" Then
            e.Cancel = True
        Else
            MyBase.OnCellBeginEdit(e)
        End If
    End Sub

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

    Public Shadows Function ProcessLeftKey(ByVal keyData As Keys) As Boolean
        If MyBase.CurrentCell.ColumnIndex = 0 And MyBase.CurrentCell.RowIndex > 0 Then
            MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex - 1).Cells(MyBase.ColumnCount - 1)
            Return True
        Else
            Return MyBase.ProcessLeftKey(keyData)
        End If
    End Function

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
                    If Not JumpToMontant Then
                        Return MyBase.ProcessDialogKey(Keys.Tab)
                        'Return MyBase.ProcessRightKey(keyData)
                    Else
                        If MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_CRE).Value IsNot Nothing Then
                            MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_CRE)
                        Else
                            MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_DEB)
                        End If
                        JumpToMontant = False
                        Return True
                    End If
                End If
                Return True
            Else
                If Not JumpToMontant Then
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                    'Return MyBase.ProcessRightKey(keyData)
                Else
                    If MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_CRE).Value IsNot Nothing Then
                        MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_CRE)
                    Else
                        MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(COL_DEB)
                    End If
                    JumpToMontant = False
                    Return True
                End If
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

    Public Sub ConfigAutocompleteCombobox()
        AddHandler Me.EditingControlShowing, AddressOf OnAutocompleteControlShowing
        AddHandler Me.CellLeave, AddressOf OnAutocompleteCellLeave
    End Sub

    Private cb As ComboBox

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

    Private Sub ComboPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If cb Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            cb.Text = CType(sender, DataGridViewComboBoxEditingControl).Text
            JumpToMontant = False
        End If
    End Sub

    Private Sub ComboEnter(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, ComboBox).Items.Count > 1 Then
            CType(sender, ComboBox).DroppedDown = True
        End If
    End Sub

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
