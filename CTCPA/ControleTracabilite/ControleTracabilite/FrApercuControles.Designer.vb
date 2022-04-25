<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrApercuControles
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtImprimer = New System.Windows.Forms.Button
        Me.GradientPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Content
        '
        Me.Content.AutoScroll = True
        Me.Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Content.ColumnCount = 1
        Me.Content.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Content.Cursor = System.Windows.Forms.Cursors.Default
        Me.Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Content.Location = New System.Drawing.Point(3, 3)
        Me.Content.Name = "Content"
        Me.Content.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Content.RowCount = 1
        Me.Content.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.Content.Size = New System.Drawing.Size(568, 313)
        Me.Content.TabIndex = 0
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Content)
        Me.GradientPanel1.Controls.Add(Me.Panel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.GradientPanel1.Size = New System.Drawing.Size(574, 359)
        Me.GradientPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtImprimer)
        Me.Panel1.Controls.Add(Me.BtCancel)
        Me.Panel1.Controls.Add(Me.BtOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 316)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 40)
        Me.Panel1.TabIndex = 0
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.Image = Global.ControleTracabilite.My.Resources.Resources.close
        Me.BtCancel.Location = New System.Drawing.Point(484, 8)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 1
        Me.BtCancel.Text = "Fermer"
        Me.BtCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Image = Global.ControleTracabilite.My.Resources.Resources.save
        Me.BtOK.Location = New System.Drawing.Point(381, 8)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(97, 23)
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "Enregistrer"
        Me.BtOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'BtImprimer
        '
        Me.BtImprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImprimer.Image = Global.ControleTracabilite.My.Resources.Resources.impr
        Me.BtImprimer.Location = New System.Drawing.Point(296, 8)
        Me.BtImprimer.Name = "BtImprimer"
        Me.BtImprimer.Size = New System.Drawing.Size(79, 23)
        Me.BtImprimer.TabIndex = 2
        Me.BtImprimer.Text = "Imprimer"
        Me.BtImprimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtImprimer.UseVisualStyleBackColor = True
        '
        'FrApercuControles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 359)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MinimizeBox = False
        Me.Name = "FrApercuControles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aperçu du contrôle"
        Me.GradientPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Content As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtImprimer As System.Windows.Forms.Button
End Class
