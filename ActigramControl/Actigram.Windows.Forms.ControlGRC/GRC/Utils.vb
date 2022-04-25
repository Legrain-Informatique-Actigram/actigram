#Region " Classes "
Public Class ListboxItem

    Private _value As Object
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property


    Private _text As String
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Object)
        Me.Value = value
        Me.Text = value.ToString
    End Sub

    Public Sub New(ByVal text As String, ByVal value As Object)
        Me.Text = text
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

Public Class UserCancelledException
    Inherits ApplicationException

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal s As String)
        MyBase.New(s)
    End Sub

End Class

Public Class MyFormat
    Implements IFormatProvider
    Implements ICustomFormatter

    ' String.Format calls this method to get an instance of an
    ' ICustomFormatter to handle the formatting.
    Public Function GetFormat(ByVal service As Type) As Object _
    Implements IFormatProvider.GetFormat

        If service.ToString() = GetType(ICustomFormatter).ToString() Then
            Return Me
        Else
            Return Nothing
        End If
    End Function

    ' After String.Format gets the ICustomFormatter, it calls this format
    ' method on each argument.
    Public Function Format(ByVal theformat As String, ByVal arg As Object, ByVal provider As IFormatProvider) As String _
    Implements ICustomFormatter.Format

        If theformat Is Nothing Then
            Return String.Format("{0}", arg)
        End If
        Dim i As Integer = theformat.Length
        ' If the format is not a defined custom code,
        ' use the formatting support in ToString.
        If Not theformat.StartsWith("S") Then
            ' If the object to be formatted supports the IFormattable
            ' interface, pass the format specifier to the 
            ' objects ToString method for formatting.
            If TypeOf arg Is IFormattable Then
                Return CType(arg, IFormattable).ToString(theformat, provider)
            ElseIf Not arg Is Nothing Then
                ' If the object does not support IFormattable, 
                ' call the objects ToString method with no additional
                ' formatting. 
                Return arg.ToString()
            Else
                Return ""
            End If
        End If
        ' Uses the format string to
        ' form the output string.
        theformat = theformat.Trim(New Char() {"S"c})
        Dim length As Integer = Convert.ToInt32(theformat)
        Return Left(Convert.ToString(arg), length)
    End Function


    Public Class ListViewColumnSorter
        Implements IComparer

        Private ObjectCompare As CaseInsensitiveComparer

        Private columnToSort As Integer
        Public Property SortColumn() As Integer
            Get
                Return columnToSort
            End Get
            Set(ByVal value As Integer)
                columnToSort = value
            End Set
        End Property


        Private orderOfSort As SortOrder
        Public Property Order() As SortOrder
            Get
                Return orderOfSort
            End Get
            Set(ByVal value As SortOrder)
                orderOfSort = value
            End Set
        End Property


        Public Sub New()
            columnToSort = 0
            orderOfSort = SortOrder.None
            ObjectCompare = New CaseInsensitiveComparer
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim compareResult As Integer
            Dim listviewX As ListViewItem = CType(x, ListViewItem)
            Dim listviewY As ListViewItem = CType(y, ListViewItem)
            ' Compare les deux éléments
            compareResult = ObjectCompare.Compare(listviewX.SubItems(columnToSort).Text, listviewY.SubItems(columnToSort).Text)

            ' Calcule la valeur correcte d'après la comparaison d'objets
            If orderOfSort = SortOrder.Ascending Then
                'Le tri croissant est sélectionné, renvoie des résultats normaux de comparaison
                Return compareResult
            ElseIf orderOfSort = SortOrder.Descending Then
                'Le tri décroissant est sélectionné, renvoie des résultats négatifs de comparaison
                Return -compareResult
            Else
                'Renvoie '0' pour indiquer qu'ils sont égaux
                Return 0
            End If
        End Function
    End Class
End Class
#End Region

Module FormsUtils

    Private defaultIconHandle As IntPtr = IntPtr.Zero

    Public Sub SetChildFormIcon(ByVal fr As Form, Optional ByVal smallFont As Boolean = False)
        If defaultIconHandle = IntPtr.Zero Then
            Using f As New Form
                defaultIconHandle = f.Icon.Handle
            End Using
        End If
        If fr.Icon.Handle = defaultIconHandle Then
            Dim parentForm As Form = Nothing
            If fr.MdiParent IsNot Nothing Then
                parentForm = fr.MdiParent
            ElseIf fr.Owner IsNot Nothing Then
                parentForm = fr.Owner
            End If

            If parentForm IsNot Nothing Then
                fr.Icon = parentForm.Icon
            End If
        End If
        If smallFont Then
            fr.Font = New Font(SystemFonts.MessageBoxFont.FontFamily, 8.25!)
        Else
            fr.Font = SystemFonts.MessageBoxFont
        End If
        If fr.MdiParent IsNot Nothing Then
            AddHandler fr.Shown, AddressOf MaximizeOnShown
        End If
    End Sub

    Private Sub MaximizeOnShown(ByVal sender As Object, ByVal e As EventArgs)
        With CType(sender, Form)
            .SuspendLayout()
            .WindowState = FormWindowState.Normal
            .WindowState = FormWindowState.Maximized
            .ResumeLayout()
        End With
    End Sub

    Public Sub FillCb(ByVal t As Type, ByVal cb As ComboBox, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False, Optional ByVal NameAsValue As Boolean = False, Optional ByVal EmptyItemText As String = "")
        With cb
            .BeginUpdate()
            Dim items As New List(Of ListboxItem)
            If AddEmptyItem Then
                items.Add(New ListboxItem(EmptyItemText, Nothing))
            End If
            For Each v As Object In [Enum].GetValues(t)
                items.Add(New ListboxItem(v.ToString, IIf(NameAsValue, v.ToString, CInt(v))))
            Next
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = items
            .EndUpdate()
            If defaultSelectFirstItem Then
                If .SelectedIndex < 0 Then .SelectedIndex = 0
            End If
        End With
    End Sub

    Public Sub FillCb(ByVal source As BindingSource, ByVal cb As ToolStripComboBox, ByVal displayExpression As String, ByVal valueMember As String, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False, Optional ByVal EmptyItemText As String = "")
        With cb
            .BeginUpdate()
            .Items.Clear()
            If AddEmptyItem Then
                .Items.Add(New ListboxItem(EmptyItemText, Nothing))
            End If
            For Each d As DataRowView In source
                Dim dr As DataRow = d.Row
                Dim tx As String
                If displayExpression.IndexOf("{"c) >= 0 Then
                    tx = String.Format(displayExpression, dr.ItemArray)
                Else
                    tx = Convert.ToString(dr(displayExpression))
                End If
                .Items.Add(New ListboxItem(tx, dr))
                If selectedValue IsNot Nothing AndAlso dr(valueMember).Equals(selectedValue) Then
                    .SelectedIndex = .Items.Count - 1
                End If
            Next
            .EndUpdate()
            If defaultSelectFirstItem And .Items.Count > 0 Then
                If .SelectedIndex < 0 Then .SelectedIndex = 0
            End If
        End With
    End Sub

    Public Sub FillCb(ByVal datarows() As DataRow, ByVal cb As ComboBox, ByVal displayExpression As String, ByVal valueMember As String, ByVal selectedValue As Object, ByVal defaultSelectFirstItem As Boolean, Optional ByVal AddEmptyItem As Boolean = False, Optional ByVal EmptyItemText As String = "", Optional ByVal targetType As Type = Nothing)
        With cb
            .BeginUpdate()
            Dim items As New List(Of ListboxItem)
            If AddEmptyItem Then
                items.Add(New ListboxItem(EmptyItemText, Nothing))
            End If
            Dim selectedIndex As Integer = -1
            If targetType IsNot Nothing AndAlso selectedValue IsNot Nothing AndAlso selectedValue.GetType IsNot targetType Then
                selectedValue = Convert.ChangeType(selectedValue, targetType)
            End If
            For Each dr As DataRow In datarows
                Dim tx As String
                If displayExpression.IndexOf("{"c) >= 0 Then
                    tx = String.Format(displayExpression, dr.ItemArray)
                Else
                    tx = Convert.ToString(dr(displayExpression))
                End If
                Dim value As Object
                If targetType Is Nothing OrElse dr(valueMember).GetType Is targetType Then
                    value = dr(valueMember)
                Else
                    value = Convert.ChangeType(dr(valueMember), targetType)
                End If                
                items.Add(New ListboxItem(tx, value))
                If selectedValue IsNot Nothing AndAlso value.Equals(selectedValue) Then
                    selectedIndex = items.Count - 1
                End If
            Next
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = items
            .EndUpdate()
            If selectedIndex >= 0 Then                
                .SelectedIndex = selectedIndex
            End If
            If defaultSelectFirstItem AndAlso .Items.Count > 0 AndAlso .SelectedIndex < 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
End Module
