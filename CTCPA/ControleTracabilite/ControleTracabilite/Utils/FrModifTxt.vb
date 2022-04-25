Public Class FrModifTxt

    Public Shared Sub ZoomTextBoxCell(ByVal cell As DataGridViewTextBoxCell)
        Using fr As New FrModifTxt
            With cell
                fr.MaxLength = .MaxInputLength
                fr.ContentText = CStr(.EditedFormattedValue)
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    .Value = .ParseFormattedValue(fr.ContentText, .Style, Nothing, Nothing)
                    .DataGridView.EndEdit()
                End If
            End With
        End Using
    End Sub

    Public Shared Sub ZoomTextBox(ByVal sender As Object, ByVal e As EventArgs)
        Using fr As New FrModifTxt
            With Cast(Of TextBox)(sender)
                fr.MaxLength = .MaxLength
                fr.ContentText = .Text
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    .Text = fr.ContentText
                    .SelectionStart = .Text.Length
                End If
            End With
        End Using
    End Sub

    Public Property MaxLength() As Integer
        Get
            Return Txt.MaxLength
        End Get
        Set(ByVal value As Integer)
            Txt.MaxLength = value
        End Set
    End Property

    Public Property ContentText() As String
        Get
            Return Txt.Text
        End Get
        Set(ByVal value As String)
            Txt.Text = value
            Txt.SelectionStart = value.Length
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal text As String, Optional ByVal maxlength As Integer = 32767)
        Me.New()
        Me.ContentText = text
        Me.MaxLength = maxlength
    End Sub

End Class