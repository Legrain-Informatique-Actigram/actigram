'Public Class ListItem

'    Private _value As Object
'    Public Property Value() As Object
'        Get
'            Return _value
'        End Get
'        Set(ByVal value As Object)
'            _value = value
'        End Set
'    End Property


'    Private _text As String
'    Public Property Text() As String
'        Get
'            Return _text
'        End Get
'        Set(ByVal value As String)
'            _text = value
'        End Set
'    End Property

'    Public Sub New()

'    End Sub

'    Public Sub New(ByVal value As Object)
'        Me.Value = value
'        Me.Text = value.ToString
'    End Sub

'    Public Sub New(ByVal text As String, ByVal value As Object)
'        Me.Text = text
'        Me.Value = value
'    End Sub

'    Public Overrides Function ToString() As String
'        Return Text
'    End Function

'End Class

Public Module Utils
    Public Function MillimetersToTwips(ByVal val As Integer) As Integer
        Return val * 57
    End Function

    Public Function MillimetersToTwips(ByVal val As System.Drawing.Point) As System.Drawing.Point
        Return New System.Drawing.Point(MillimetersToTwips(val.X), MillimetersToTwips(val.Y))
    End Function
End Module
