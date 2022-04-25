Imports System.Windows.Forms
Public Class UcOptions

    Public Event ParametersValidated As EventHandler
    Public Event CloseClicked As EventHandler


    Private _conn As SqlClient.SqlConnection
    Public Property Connection() As SqlClient.SqlConnection
        Get
            Return _conn
        End Get
        Set(ByVal value As SqlClient.SqlConnection)
            _conn = value
        End Set
    End Property

    Private _parametres As List(Of Parametre)
    Public Property Parametres() As List(Of Parametre)
        Get
            Return _parametres
        End Get
        Set(ByVal value As List(Of Parametre))
            _parametres = value
            ChargerParametres()
        End Set
    End Property

    Public Function GetParamValues() As Dictionary(Of String, Object)
        Dim res As New Dictionary(Of String, Object)
        For Each ctl As Control In controlLayout.Controls
            If TypeOf ctl Is FlowLayoutPanel Then
                For Each c As Control In ctl.Controls
                    If c.Tag IsNot Nothing AndAlso TypeOf c.Tag Is Parametre Then
                        res.Add(DirectCast(c.Tag, Parametre).Nom, GetValue(c))
                    End If
                Next
            End If            
        Next
        Return res
    End Function

    Public Function GetParamPrintValues() As Dictionary(Of String, String)
        Dim res As New Dictionary(Of String, String)
        For Each ctl As Control In controlLayout.Controls
            If TypeOf ctl Is FlowLayoutPanel Then
                For Each c As Control In ctl.Controls
                    If c.Tag IsNot Nothing AndAlso TypeOf c.Tag Is Parametre Then
                        res.Add(DirectCast(c.Tag, Parametre).Nom, GetPrintValue(c))
                    End If
                Next
            End If
        Next
        Return res
    End Function

    Private loaded As Boolean = False
    Private Sub UcOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChargerParametres()
        loaded = True
    End Sub

    Private Sub ChargerParametres()
        If Not loaded Then Exit Sub
        controlLayout.Controls.Clear()
        If Me.Parametres Is Nothing OrElse Me.Parametres.Count = 0 Then Exit Sub
        For Each p As Parametre In Me.Parametres
            Dim subLayout As New FlowLayoutPanel
            With subLayout
                .AutoSize = True
                .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            End With
            Dim lb As New Label
            With lb
                .AutoSize = False
                .Width = 70
                .TextAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = p.Libelle & ":"
                .Padding = New Padding(0, 5, 0, 0)
            End With
            subLayout.Controls.Add(lb)
            Dim ctl As Control = GetControl(p)
            subLayout.Controls.Add(ctl)
            controlLayout.Controls.Add(subLayout)
        Next
        'Me.MinimumSize = New Drawing.Size(controlLayout.Width, controlLayout.Bottom)
    End Sub

    Private Function GetControl(ByVal p As Parametre) As Control
        If p.Datasource IsNot Nothing Then
            Return GetComboBox(p)
        Else
            Select Case p.Type
                Case "DateTime" : Return GetDateTimePicker(p)
                Case "Boolean" : Return GetCheckBox(p)
                Case "Integer", "Long", "Decimal" : Return GetNumericTextBox(p)
                Case Else : Return GetTextBox(p)
            End Select
        End If
    End Function

    Private Function GetTextBox(ByVal p As Parametre) As TextBox
        Dim res As New TextBox
        res.MinimumSize = New System.Drawing.Size(5, 15)
        If p.Width < 0 Then
            res.Width = 80
        Else
            res.Width = p.Width
        End If
        res.Text = p.ValeurDefaut
        res.Tag = p
        AddHandler res.KeyPress, AddressOf TxKeyPress
        Return res
    End Function

    Private Function GetNumericTextBox(ByVal p As Parametre) As NumericTextbox
        Dim res As New NumericTextbox
        res.Unit = ""
        If p.Width < 0 Then
            res.Width = 80
        Else
            res.Width = p.Width
        End If
        res.Decimals = CInt(IIf(p.Type = "Decimal", 2, 0))
        res.MinimumSize = New System.Drawing.Size(5, 15)
        res.Text = p.ValeurDefaut
        res.Tag = p
        AddHandler res.KeyPress, AddressOf TxKeyPress
        Return res
    End Function

    Private Function GetCheckBox(ByVal p As Parametre) As CheckBox
        Dim res As New CheckBox
        res.MinimumSize = New System.Drawing.Size(5, 15)
        res.Text = ""
        Dim b As Boolean
        If Boolean.TryParse(p.ValeurDefaut, b) Then
            res.Checked = b
        End If
        res.AutoSize = True
        res.Tag = p
        Return res
    End Function

    Private Function GetDateTimePicker(ByVal p As Parametre) As DateTimePicker
        Dim res As New DateTimePicker
        res.MinimumSize = New System.Drawing.Size(5, 15)
        Dim d As Date
        If Date.TryParse(p.ValeurDefaut, d) Then
            res.Value = d
        End If
        res.Format = DateTimePickerFormat.Short
        If p.Width < 0 Then
            res.Width = 80
        Else
            res.Width = p.Width
        End If
        res.Tag = p
        AddHandler res.KeyPress, AddressOf TxKeyPress
        Return res
    End Function

    Private Function GetComboBox(ByVal p As Parametre) As ComboBox
        Dim res As New ComboBox
        Dim items As New List(Of ListboxItem)
        If TypeOf p.Datasource Is SimpleComboDatasource Then
            For Each v As String In CType(p.Datasource, SimpleComboDatasource).Values
                items.Add(New ListboxItem(v, v))
            Next
        ElseIf TypeOf p.Datasource Is SqlComboDatasource Then
            Dim source As SqlComboDatasource = CType(p.Datasource, SqlComboDatasource)
            Using cmd As New SqlClient.SqlCommand(source.SelectQuery, Me.Connection)
                If Me.Connection.State = ConnectionState.Closed Then Me.Connection.Open()
                Using sr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    While sr.Read
                        items.Add(New ListboxItem(Convert.ToString(sr(source.DisplayMember)), sr(source.ValueMember)))
                    End While
                End Using
            End Using
        End If
        If p.Width < 0 Then
            res.Width = 80
        Else
            res.Width = p.Width
        End If
        res.Tag = p
        res.DataSource = items
        res.DisplayMember = "Text"
        res.ValueMember = "Value"
        res.DropDownStyle = ComboBoxStyle.DropDownList
        Return res
    End Function

    Private Function GetValue(ByVal ctl As Control) As Object
        If TypeOf ctl Is TextBox Then : Return ctl.Text
        ElseIf TypeOf ctl Is NumericTextbox Then : Return DirectCast(ctl, NumericTextbox).Value
        ElseIf TypeOf ctl Is DateTimePicker Then : Return DirectCast(ctl, DateTimePicker).Value.Date
        ElseIf TypeOf ctl Is NumericUpDown Then : Return DirectCast(ctl, NumericUpDown).Value
        ElseIf TypeOf ctl Is CheckBox Then : Return DirectCast(ctl, CheckBox).Checked
        ElseIf TypeOf ctl Is ComboBox Then
            Dim cb As ComboBox = DirectCast(ctl, ComboBox)
            If cb.DropDownStyle = ComboBoxStyle.DropDown Then
                Return cb.Text
            Else
                Return cb.SelectedValue
            End If
        Else : Return ctl.Text
        End If
    End Function

    Private Function GetPrintValue(ByVal ctl As Control) As String
        If TypeOf ctl Is TextBox Then : Return ctl.Text
        ElseIf TypeOf ctl Is NumericTextbox Then : Return DirectCast(ctl, NumericTextbox).Text
        ElseIf TypeOf ctl Is DateTimePicker Then : Return DirectCast(ctl, DateTimePicker).Value.Date.ToString("dd/MM/yyyy")
        ElseIf TypeOf ctl Is NumericUpDown Then : Return DirectCast(ctl, NumericUpDown).Value.ToString
        ElseIf TypeOf ctl Is CheckBox Then : Return CStr(IIf(DirectCast(ctl, CheckBox).Checked, "oui", "non"))
        ElseIf TypeOf ctl Is ComboBox Then : Return DirectCast(ctl, ComboBox).Text
        Else : Return ctl.Text
        End If
    End Function

    Private Sub TxKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            RaiseEvent ParametersValidated(Me, EventArgs.Empty)
            e.Handled = True
        End If
    End Sub

    Private Sub lbTitre_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbTitre.MouseClick
        If lbTitre.Right - e.X < 20 Then
            RaiseEvent CloseClicked(Me, EventArgs.Empty)
        End If
    End Sub
End Class
