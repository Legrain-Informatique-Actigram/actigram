Public Class TimePicker

    Public Event ValueChanged As EventHandler

#Region "Propriétés"
    Public Property Value() As Date
        Get
            Return Me.DateTimePicker1.Value
        End Get
        Set(ByVal value As Date)
            Me.DateTimePicker1.Value = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        AddHandler Me.DateTimePicker1.ValueChanged, AddressOf OnValueChanged
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNow.Click
        Me.Value = Now
        RaiseEvent ValueChanged(Me, New EventArgs)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub OnValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub
#End Region

End Class
