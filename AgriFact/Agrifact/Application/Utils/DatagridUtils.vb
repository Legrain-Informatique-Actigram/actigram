#Region " FormattedNumberTextBoxColumn "
Public Class FormattedNumberTextBoxColumn
    Inherits DataGridTextBoxColumn

    Protected Overrides Function Commit(ByVal cm As CurrencyManager, ByVal RowNum As Integer) As Boolean
        If Not Me.TextBox Is Nothing Then
            Dim txt As String = Me.TextBox.Text
            txt = txt.Trim
            'Gestion de la saisie de points ou de virgules
            txt = txt.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            txt = txt.Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            'Suppression de la monnaie
            txt = txt.Replace(Application.CurrentCulture.NumberFormat.CurrencySymbol, "")
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
        Return MyBase.Commit(cm, RowNum)
    End Function

End Class
#End Region

#Region " ReadOnlyTextBoxColumn "
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

Public Delegate Sub EnableCellEventHandlerTXT(ByVal sender As Object, ByVal e As DataGridEnableEventArgs)

Public Class ReadOnlyTextBoxColumn
    Inherits DataGridTextBoxColumn

    Public Event CheckTXTEnabled As EnableCellEventHandlerTXT

    Private disabledBrush As SolidBrush

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
        disabledBrush = New SolidBrush(SystemColors.GrayText)
    End Sub

    Public Sub New(ByVal theColumn As Integer)
        Me.New()
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

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
        Dim aEnabled As Boolean = True
        Dim e As New DataGridEnableEventArgs(source, rowNum, myColumn, aEnabled)
        RaiseEvent CheckTXTEnabled(Me, e)
        aEnabled = e.EnableValue
        Dim theBrush As Brush
        If Not aEnabled Then
            theBrush = disabledBrush
        Else
            theBrush = foreBrush
        End If
        MyBase.Paint(g, bounds, source, rowNum, backBrush, theBrush, alignToRight)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disabledBrush Is Nothing Then
            Me.disabledBrush.Dispose()
            Me.disabledBrush = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
#End Region