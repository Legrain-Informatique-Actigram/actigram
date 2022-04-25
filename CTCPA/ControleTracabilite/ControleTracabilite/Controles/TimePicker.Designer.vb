<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimePicker))
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BtNow = New System.Windows.Forms.Button
        Me.il = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(0, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(70, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'BtNow
        '
        Me.BtNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtNow.ImageIndex = 0
        Me.BtNow.ImageList = Me.il
        Me.BtNow.Location = New System.Drawing.Point(70, 1)
        Me.BtNow.Name = "BtNow"
        Me.BtNow.Size = New System.Drawing.Size(24, 24)
        Me.BtNow.TabIndex = 1
        Me.BtNow.UseVisualStyleBackColor = True
        '
        'il
        '
        Me.il.ImageStream = CType(resources.GetObject("il.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.il.TransparentColor = System.Drawing.Color.Fuchsia
        Me.il.Images.SetKeyName(0, "Control_Timer.bmp")
        '
        'TimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.BtNow)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "TimePicker"
        Me.Size = New System.Drawing.Size(95, 26)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtNow As System.Windows.Forms.Button
    Friend WithEvents il As System.Windows.Forms.ImageList

End Class
