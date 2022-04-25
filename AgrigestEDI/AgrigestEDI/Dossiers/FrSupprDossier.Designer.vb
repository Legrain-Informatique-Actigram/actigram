<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSupprDossier
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.btTousExercices = New Ascend.Windows.Forms.GradientNavigationButton
        Me.lbDesc = New System.Windows.Forms.Label
        Me.btSelectedEx = New Ascend.Windows.Forms.GradientNavigationButton
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(268, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(69, 23)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Annuler"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 165)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(345, 45)
        Me.GradientPanel2.TabIndex = 15
        '
        'btTousExercices
        '
        Me.btTousExercices.ActiveGradientHighColor = System.Drawing.Color.White
        Me.btTousExercices.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btTousExercices.ActiveOnClick = False
        Me.btTousExercices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btTousExercices.Border = New Ascend.Border(0)
        Me.btTousExercices.GradientHighColor = System.Drawing.Color.White
        Me.btTousExercices.GradientLowColor = System.Drawing.Color.White
        Me.btTousExercices.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btTousExercices.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.btTousExercices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btTousExercices.Location = New System.Drawing.Point(15, 110)
        Me.btTousExercices.Name = "btTousExercices"
        Me.btTousExercices.ShowBorderOnHighlight = True
        Me.btTousExercices.Size = New System.Drawing.Size(318, 43)
        Me.btTousExercices.StayActiveAfterClick = False
        Me.btTousExercices.TabIndex = 6
        Me.btTousExercices.Text = "Supprimer tous les exercices du dossier {0}"
        '
        'lbDesc
        '
        Me.lbDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDesc.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesc.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbDesc.Location = New System.Drawing.Point(12, 9)
        Me.lbDesc.Name = "lbDesc"
        Me.lbDesc.Size = New System.Drawing.Size(321, 49)
        Me.lbDesc.TabIndex = 5
        Me.lbDesc.Text = "Voulez-vous supprimer tous les exercices ou bien seulement l'exercice en cours ?"
        Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btSelectedEx
        '
        Me.btSelectedEx.ActiveGradientHighColor = System.Drawing.Color.White
        Me.btSelectedEx.ActiveGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btSelectedEx.ActiveOnClick = False
        Me.btSelectedEx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSelectedEx.Border = New Ascend.Border(0)
        Me.btSelectedEx.GradientHighColor = System.Drawing.Color.White
        Me.btSelectedEx.GradientLowColor = System.Drawing.Color.White
        Me.btSelectedEx.HighlightGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btSelectedEx.Image = Global.AgrigestEDI.My.Resources.Resources.task
        Me.btSelectedEx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSelectedEx.Location = New System.Drawing.Point(15, 61)
        Me.btSelectedEx.Name = "btSelectedEx"
        Me.btSelectedEx.ShowBorderOnHighlight = True
        Me.btSelectedEx.Size = New System.Drawing.Size(318, 43)
        Me.btSelectedEx.StayActiveAfterClick = False
        Me.btSelectedEx.TabIndex = 16
        Me.btSelectedEx.Text = "Supprimer seulement l'exercice {0}"
        '
        'FrSupprDossier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(345, 210)
        Me.Controls.Add(Me.btSelectedEx)
        Me.Controls.Add(Me.btTousExercices)
        Me.Controls.Add(Me.lbDesc)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSupprDossier"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suppression de d'exercice"
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents btTousExercices As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents lbDesc As System.Windows.Forms.Label
    Friend WithEvents btSelectedEx As Ascend.Windows.Forms.GradientNavigationButton

End Class
