Namespace Controles
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GroupeControles
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
            Me.Content = New System.Windows.Forms.TableLayoutPanel
            Me.LbTitreGroupe = New Ascend.Windows.Forms.GradientCaption
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.GradientPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Content
            '
            Me.Content.AutoSize = True
            Me.Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Content.ColumnCount = 3
            Me.Content.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.Content.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.Content.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.Content.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Content.Location = New System.Drawing.Point(0, 0)
            Me.Content.Name = "Content"
            Me.Content.RowCount = 1
            Me.Content.RowStyles.Add(New System.Windows.Forms.RowStyle)
            Me.Content.Size = New System.Drawing.Size(396, 254)
            Me.Content.TabIndex = 1
            '
            'LbTitreGroupe
            '
            Me.LbTitreGroupe.BorderColor = New Ascend.BorderColor(System.Drawing.Color.MidnightBlue)
            Me.LbTitreGroupe.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
            Me.LbTitreGroupe.Dock = System.Windows.Forms.DockStyle.Top
            Me.LbTitreGroupe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LbTitreGroupe.ForeColor = System.Drawing.Color.White
            Me.LbTitreGroupe.GradientHighColor = System.Drawing.Color.AliceBlue
            Me.LbTitreGroupe.GradientLowColor = System.Drawing.Color.SteelBlue
            Me.LbTitreGroupe.HighColorLuminance = 1.2!
            Me.LbTitreGroupe.Location = New System.Drawing.Point(0, 0)
            Me.LbTitreGroupe.LowColorLuminance = 1.5!
            Me.LbTitreGroupe.Name = "LbTitreGroupe"
            Me.LbTitreGroupe.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
            Me.LbTitreGroupe.Size = New System.Drawing.Size(396, 33)
            Me.LbTitreGroupe.TabIndex = 0
            Me.LbTitreGroupe.Text = "LbTitreGroupe"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Border = New Ascend.Border(1, 0, 1, 1)
            Me.GradientPanel1.BorderColor = New Ascend.BorderColor(System.Drawing.Color.MidnightBlue)
            Me.GradientPanel1.Controls.Add(Me.Content)
            Me.GradientPanel1.CornerRadius = New Ascend.CornerRadius(7, 7, 0, 0)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
            Me.GradientPanel1.GradientLowColor = System.Drawing.Color.LightSteelBlue
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 33)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Size = New System.Drawing.Size(396, 254)
            Me.GradientPanel1.TabIndex = 2
            '
            'GroupeControles
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Transparent
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.LbTitreGroupe)
            Me.Margin = New System.Windows.Forms.Padding(0)
            Me.Name = "GroupeControles"
            Me.Size = New System.Drawing.Size(396, 287)
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Content As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents LbTitreGroupe As Ascend.Windows.Forms.GradientCaption
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel

    End Class
End Namespace
