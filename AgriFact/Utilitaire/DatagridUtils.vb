Namespace [ReadOnly]

    Public Delegate Sub EnableCellEventHandler(ByVal sender As Object, ByVal e As DataGridEnableEventArgs)

    Public Class DataGridEnableTextBoxColumn
        Inherits DataGridTextBoxColumn

        Public Event CheckTXTEnabled As EnableCellEventHandler

        Private myColumn As Integer
        Public Property Column() As Integer
            Get
                Return myColumn
            End Get
            Set(ByVal Value As Integer)
                myColumn = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal theColumn As Integer)
            myColumn = theColumn
        End Sub

        Protected Overloads Overrides Sub Edit(ByVal theSource As System.Windows.Forms.CurrencyManager, ByVal theRowNum As Integer, ByVal theBounds As System.Drawing.Rectangle, ByVal theReadOnlyFlag As Boolean, ByVal theInstantText As String, ByVal theCellIsVisibleFlag As Boolean)
            Dim aEnabled As Boolean = True
            If Me.ReadOnly Then
                aEnabled = False
            Else
                Dim e As New DataGridEnableEventArgs(theSource, theRowNum, myColumn, aEnabled)
                RaiseEvent CheckTXTEnabled(Me, e)
                aEnabled = e.EnableValue
            End If            
            If aEnabled Then
                MyBase.Edit(theSource, theRowNum, theBounds, theReadOnlyFlag, theInstantText, theCellIsVisibleFlag)
            End If
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
            Dim aEnabled As Boolean = True
            Dim e As New DataGridEnableEventArgs(source, rowNum, myColumn, aEnabled)
            RaiseEvent CheckTXTEnabled(Me, e)
            aEnabled = e.EnableValue
            Dim theBrush As Brush
            If Not aEnabled Then
                theBrush = SystemBrushes.Control
            Else
                theBrush = backBrush
            End If
            MyBase.Paint(g, bounds, source, rowNum, theBrush, foreBrush, alignToRight)
        End Sub

        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
            If Not Me.TextBox Is Nothing Then
                Dim txt As String = Me.TextBox.Text
                txt = txt.Trim
                'Gestion de la saisie de points ou de virgules
                txt = txt.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                txt = txt.Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                'Suppression des espaces
                txt = txt.Replace(" ", "")
                'Gestion des pourcentages
                If txt.EndsWith("%") Then
                    txt = txt.Replace("%", "")
                    Dim val As Decimal = Decimal.Parse(txt)
                    txt = (val / 100D).ToString
                End If
                Me.TextBox.Text = txt
            End If
            Return MyBase.Commit(dataSource, rowNum)
        End Function
    End Class
    

    Public Class DataGridEnableBoolColumn
        Inherits DataGridBoolColumn

        Public Event CheckCkEnabled As EnableCellEventHandler

        Public Sub New()
        End Sub

        Protected Overloads Overrides Sub Edit(ByVal theSource As System.Windows.Forms.CurrencyManager, ByVal theRowNum As Integer, ByVal theBounds As System.Drawing.Rectangle, ByVal theReadOnlyFlag As Boolean, ByVal theInstantText As String, ByVal theCellIsVisibleFlag As Boolean)
            Dim aEnabled As Boolean = True
            If Me.ReadOnly Then
                aEnabled = False
            Else
                Dim e As New DataGridEnableEventArgs(theSource, theRowNum, 0, aEnabled)
                RaiseEvent CheckCkEnabled(Me, e)
                aEnabled = e.EnableValue
            End If            
            If aEnabled Then
                Dim value As Boolean = CBool(Me.GetColumnValueAtRow(theSource, theRowNum))
                Me.SetColumnValueAtRow(theSource, theRowNum, Not value)
                MyBase.Edit(theSource, theRowNum, theBounds, theReadOnlyFlag, theInstantText, theCellIsVisibleFlag)
            End If
        End Sub

        'Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        '    Dim aEnabled As Boolean = True
        '    If Me.ReadOnly Then
        '        aEnabled = False
        '    Else
        '        Dim e As New DataGridEnableEventArgs(source, rowNum, 0, aEnabled)
        '        RaiseEvent CheckCkEnabled(Me, e)
        '        aEnabled = e.EnableValue
        '    End If

        '    Dim theBrush As Brush
        '    If Not aEnabled Then
        '        theBrush = SystemBrushes.Control
        '    Else
        '        theBrush = backBrush
        '    End If
        '    MyBase.Paint(g, bounds, source, rowNum, theBrush, foreBrush, alignToRight)
        'End Sub
    End Class

    Public Class DataGridComboBoxColumn
        Inherits DataGridTextBoxColumn

        Public Event CheckCBOEnabled As EnableCellEventHandler

        Public Sub New()
        End Sub

        Protected Overloads Overrides Sub Edit(ByVal theSource As System.Windows.Forms.CurrencyManager, ByVal theRowNum As Integer, ByVal theBounds As System.Drawing.Rectangle, ByVal theReadOnlyFlag As Boolean, ByVal theInstantText As String, ByVal theCellIsVisibleFlag As Boolean)
            Dim aEnabled As Boolean = True
            Dim e As New DataGridEnableEventArgs(theSource, theRowNum, 0, aEnabled)
            RaiseEvent CheckCBOEnabled(Me, e)
            aEnabled = e.EnableValue
            If aEnabled Then
                MyBase.Edit(theSource, theRowNum, theBounds, theReadOnlyFlag, theInstantText, theCellIsVisibleFlag)
            End If
        End Sub
    End Class

    '
    ' Event argument signature used by the 
    ' EnableCellEventHandlerxxx delegates.
    '
    Public Class DataGridEnableEventArgs
        Inherits EventArgs

        Public Sub New(ByVal theSource As CurrencyManager, ByVal theRowNumber As Integer, ByVal theColumnNumber As Integer, ByVal theValue As Boolean)
            mySource = theSource
            myRowNumber = theRowNumber
            myColumnNumber = theColumnNumber
            myEnableValue = theValue
        End Sub


        Private mySource As CurrencyManager
        Public Property DataSource() As CurrencyManager
            Get
                Return mySource
            End Get
            Set(ByVal Value As CurrencyManager)
                mySource = Value
            End Set
        End Property

        Private myColumnNumber As Integer
        Public Property ColumnNumber() As Integer
            Get
                Return myColumnNumber
            End Get
            Set(ByVal Value As Integer)
                myColumnNumber = Value
            End Set
        End Property


        Private myRowNumber As Integer
        Public Property RowNumber() As Integer
            Get
                Return myRowNumber
            End Get
            Set(ByVal Value As Integer)
                myRowNumber = Value
            End Set
        End Property

        Private myEnableValue As Boolean
        Public Property EnableValue() As Boolean
            Get
                Return myEnableValue
            End Get
            Set(ByVal Value As Boolean)
                myEnableValue = Value
            End Set
        End Property
    End Class

End Namespace
