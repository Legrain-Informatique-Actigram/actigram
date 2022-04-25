Namespace GestionMenu
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AscendSidebar
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
            Me.mylayout = New System.Windows.Forms.TableLayoutPanel
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
            Me.mylayout.SuspendLayout()
            Me.GradientPanel1.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'mylayout
            '
            Me.mylayout.AutoScroll = True
            Me.mylayout.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(210, Byte), Integer))
            Me.mylayout.ColumnCount = 1
            Me.mylayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.mylayout.Controls.Add(Me.GradientPanel1, 0, 1)
            Me.mylayout.Controls.Add(Me.GradientCaption1, 0, 0)
            Me.mylayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.mylayout.Location = New System.Drawing.Point(0, 0)
            Me.mylayout.Name = "mylayout"
            Me.mylayout.RowCount = 2
            Me.mylayout.RowStyles.Add(New System.Windows.Forms.RowStyle)
            Me.mylayout.RowStyles.Add(New System.Windows.Forms.RowStyle)
            Me.mylayout.Size = New System.Drawing.Size(184, 345)
            Me.mylayout.TabIndex = 0
            '
            'GradientPanel1
            '
            Me.GradientPanel1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.MidnightBlue)
            Me.GradientPanel1.Controls.Add(Me.FlowLayoutPanel1)
            Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(0, 0, 10, 10)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 26)
            Me.GradientPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Size = New System.Drawing.Size(184, 319)
            Me.GradientPanel1.TabIndex = 3
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
            Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
            Me.FlowLayoutPanel1.Controls.Add(Me.LinkLabel1)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(184, 319)
            Me.FlowLayoutPanel1.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(39, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Label1"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(3, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(39, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Label2"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.Location = New System.Drawing.Point(3, 26)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(59, 13)
            Me.LinkLabel1.TabIndex = 2
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "LinkLabel1"
            '
            'GradientCaption1
            '
            Me.GradientCaption1.Border = New Ascend.Border(0, 1, 0, 0)
            Me.GradientCaption1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.MidnightBlue)
            Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
            Me.GradientCaption1.ForeColor = System.Drawing.Color.White
            Me.GradientCaption1.GradientHighColor = System.Drawing.Color.AliceBlue
            Me.GradientCaption1.GradientLowColor = System.Drawing.Color.SteelBlue
            Me.GradientCaption1.Image = Global.AgrigestEDI.My.Resources.Resources.compta
            Me.GradientCaption1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
            Me.GradientCaption1.Margin = New System.Windows.Forms.Padding(0)
            Me.GradientCaption1.Name = "GradientCaption1"
            Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
            Me.GradientCaption1.Size = New System.Drawing.Size(184, 26)
            Me.GradientCaption1.TabIndex = 1
            Me.GradientCaption1.Text = "GradientCaption1"
            '
            'AscendSidebar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Controls.Add(Me.mylayout)
            Me.Name = "AscendSidebar"
            Me.Size = New System.Drawing.Size(184, 345)
            Me.mylayout.ResumeLayout(False)
            Me.GradientPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mylayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

    End Class
End Namespace