Module UtilsControles
    Public Function CreerLabel(ByVal text As String) As Label
        Dim l As New Label
        With l
            .Text = text
            .AutoSize = True
            .Visible = True
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        Return l
    End Function

    Public Function CreerTextBox(ByVal text As String) As TextBox
        Dim tx As New TextBox
        With tx
            .Text = text
            .Dock = DockStyle.Fill
        End With
        Return tx
    End Function

    Public Function CreerCheckBoxes(ByVal vals() As String, ByVal defaults() As String, Optional ByVal e As EventHandler = Nothing) As FlowLayoutPanel
        Dim layout As New FlowLayoutPanel
        With layout
            .FlowDirection = FlowDirection.LeftToRight
            .Height = 20
            .Dock = DockStyle.Top
            If vals.Length > 0 Then
                For Each s As String In vals
                    .Controls.Add(CreerCheckBox(s, defaults, e))
                Next
            Else
                .Controls.Add(CreerCheckBox("", defaults, e))
            End If
        End With
        Return layout
    End Function

    Private Function CreerCheckBox(ByVal val As String, ByVal defaults() As String, Optional ByVal e As EventHandler = Nothing) As CheckBox
        Dim ck As New CheckBox
        With ck
            .AutoSize = True
            .Text = val
            .Checked = (Array.IndexOf(defaults, val) >= 0)
            .Visible = True
            If e IsNot Nothing Then
                AddHandler .CheckedChanged, e
            End If
        End With
        Return ck
    End Function

    Public Function CreerRadioButtons(ByVal vals() As String, ByVal defaults() As String, Optional ByVal e As EventHandler = Nothing) As FlowLayoutPanel
        Dim layout As New FlowLayoutPanel
        With layout
            .FlowDirection = FlowDirection.LeftToRight
            .Height = 20
            .Dock = DockStyle.Top
            If vals.Length > 0 Then
                For Each s As String In vals
                    .Controls.Add(CreerRadio(s, defaults, e))
                Next
            Else
                .Controls.Add(CreerRadio("", defaults, e))
            End If
        End With
        Return layout
    End Function

    Private Function CreerRadio(ByVal val As String, ByVal defaults() As String, Optional ByVal e As EventHandler = Nothing) As RadioButton
        Dim rb As New RadioButton
        With rb
            .AutoSize = True
            .Text = val
            .Checked = (Array.IndexOf(defaults, val) >= 0)
            .Visible = True
            If e IsNot Nothing Then
                AddHandler .CheckedChanged, e
            End If
        End With
        Return rb
    End Function

    Public Function CreerSeparator(ByVal txt As String) As Ascend.Windows.Forms.GradientCaption
        Dim gc As New Ascend.Windows.Forms.GradientCaption
        With gc
            .Border = New Ascend.Border(1, 1, 1, 2)
            .BorderColor = New Ascend.BorderColor(Color.MidnightBlue)
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .GradientHighColor = Color.SteelBlue
            .GradientLowColor = Color.AliceBlue
            .GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
            .Margin = New Padding(0, 5, 0, 0)
            .Dock = DockStyle.Fill
            .Text = txt
        End With
        Return gc
    End Function

    Public Function CreerCaption(ByVal txt As String) As Ascend.Windows.Forms.GradientCaption
        Dim l As New Ascend.Windows.Forms.GradientCaption
        With l
            .Text = txt
            .BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
            .ForeColor = System.Drawing.SystemColors.ControlText
            .GradientLowColor = System.Drawing.SystemColors.Control
            .RenderMode = Ascend.Windows.Forms.RenderMode.Flat
            .Size = New System.Drawing.Size(150, 20)
            .BackColor = System.Drawing.SystemColors.Control
            .TextAlign = ContentAlignment.MiddleCenter
            .Visible = True
        End With
        Return l
    End Function
End Module
