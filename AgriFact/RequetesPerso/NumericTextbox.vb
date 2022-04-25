Public Class NumericTextbox
    'Implements IDisableableControl

#Region " Props "

    Private _formatEnabled As Boolean = True
    Public Property FormattingEnabled() As Boolean
        Get
            Return _formatEnabled
        End Get
        Set(ByVal value As Boolean)
            _formatEnabled = value
        End Set
    End Property


    Public Property Value() As Decimal
        Get
            Dim d As Nullable(Of Decimal) = DecimalParse(txValue.Text)
            If d.HasValue Then
                Return d.Value
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Decimal)
            If FormattingEnabled Then
                txValue.Text = value.ToString("N" & Me.Decimals)
            Else
                txValue.Text = value.ToString
            End If
        End Set
    End Property

    Private _dec As Integer = 0
    Public Property Decimals() As Integer
        Get
            Return _dec
        End Get
        Set(ByVal value As Integer)
            _dec = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return Me.lbUnit.Text
        End Get
        Set(ByVal value As String)
            Me.lbUnit.Text = value
            Me.lbUnit.Left = Me.Width - Me.lbUnit.Width
            txValue.Width = Me.lbUnit.Left
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return txValue.Text
        End Get
        Set(ByVal value As String)
            txValue.Text = value
            txValue_Validating(Nothing, New System.ComponentModel.CancelEventArgs)
        End Set
    End Property

    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
            Me.txValue.Font = value
        End Set
    End Property

    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            'MyBase.ForeColor = value
            Me.txValue.ForeColor = value
        End Set
    End Property

    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            'MyBase.BackColor = value
            Me.txValue.BackColor = value
        End Set
    End Property


    Public Property MaxLength() As Integer
        Get
            Return txValue.MaxLength
        End Get
        Set(ByVal value As Integer)
            txValue.MaxLength = value
        End Set
    End Property

    Private _readonly As Boolean
    Public Property [ReadOnly]() As Boolean ' Implements IDisableableControl.ReadOnly
        Get
            Return _readonly
        End Get
        Set(ByVal value As Boolean)
            _readonly = value
        End Set
    End Property


#End Region


    Private Sub txValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txValue.KeyPress
        MyBase.OnKeyPress(e)
        If e.Handled Then Exit Sub
        If Me.ReadOnly Then
            e.Handled = True
        ElseIf e.KeyChar = vbCr Then
            If Me.Parent IsNot Nothing Then
                Me.Parent.SelectNextControl(Me, True, True, True, True)
                e.Handled = True
            End If
        Else
            If Me.Decimals = 0 Then
                e.Handled = Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "-"c)
            Else
                e.Handled = Not IsValidForNumberInput(e.KeyChar)
            End If
        End If
    End Sub

    Private Sub txValue_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txValue.Validated
        'Me.OnValidated(EventArgs.Empty)
        MyBase.OnValidated(EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        'MyBase.OnValidated(e)
    End Sub

    Private Sub txValue_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txValue.Validating
        If txValue.Text.Length > 0 Then
            Dim d As Nullable(Of Decimal) = DecimalParse(txValue.Text)
            If d.HasValue Then
                Me.Value = Decimal.Round(d.Value, Me.Decimals)
            Else
                e.Cancel = True
            End If
        End If        
    End Sub
End Class
