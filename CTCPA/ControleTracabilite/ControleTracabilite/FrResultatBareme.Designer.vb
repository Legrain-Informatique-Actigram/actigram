Namespace Controles
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrResultatBareme
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
            Me.components = New System.ComponentModel.Container
            Dim ObservationsLabel As System.Windows.Forms.Label
            Dim ActionCorrectiveLabel As System.Windows.Forms.Label
            Me.ActionCorrectiveEffectueeCheckBox = New System.Windows.Forms.CheckBox
            Me.ResultatBaremeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ObservationsTextBox = New System.Windows.Forms.TextBox
            Me.ActionCorrectiveTextBox = New System.Windows.Forms.TextBox
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.BtCancel = New System.Windows.Forms.Button
            Me.BtPrevious = New System.Windows.Forms.Button
            Me.BtNext = New System.Windows.Forms.Button
            Me.lnkDoc = New System.Windows.Forms.LinkLabel
            Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
            ObservationsLabel = New System.Windows.Forms.Label
            ActionCorrectiveLabel = New System.Windows.Forms.Label
            CType(Me.ResultatBaremeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            Me.GradientPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'ObservationsLabel
            '
            ObservationsLabel.AutoSize = True
            ObservationsLabel.Location = New System.Drawing.Point(12, 210)
            ObservationsLabel.Name = "ObservationsLabel"
            ObservationsLabel.Size = New System.Drawing.Size(220, 13)
            ObservationsLabel.TabIndex = 7
            ObservationsLabel.Text = "Sinon, décrivez l'action corrective effectuée :"
            '
            'ActionCorrectiveLabel
            '
            ActionCorrectiveLabel.AutoSize = True
            ActionCorrectiveLabel.Location = New System.Drawing.Point(12, 6)
            ActionCorrectiveLabel.Name = "ActionCorrectiveLabel"
            ActionCorrectiveLabel.Size = New System.Drawing.Size(91, 13)
            ActionCorrectiveLabel.TabIndex = 10
            ActionCorrectiveLabel.Text = "Action Corrective:"
            '
            'ActionCorrectiveEffectueeCheckBox
            '
            Me.ActionCorrectiveEffectueeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ActionCorrectiveEffectueeCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ResultatBaremeBindingSource, "ActionCorrectiveEffectuee", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.ActionCorrectiveEffectueeCheckBox.Location = New System.Drawing.Point(15, 183)
            Me.ActionCorrectiveEffectueeCheckBox.Name = "ActionCorrectiveEffectueeCheckBox"
            Me.ActionCorrectiveEffectueeCheckBox.Size = New System.Drawing.Size(261, 24)
            Me.ActionCorrectiveEffectueeCheckBox.TabIndex = 4
            Me.ActionCorrectiveEffectueeCheckBox.Text = "L'action corrective ci-dessus a-t-elle été réalisée ?"
            '
            'ResultatBaremeBindingSource
            '
            Me.ResultatBaremeBindingSource.DataSource = GetType(ControleTracabilite.Controles.ResultatBareme)
            '
            'ObservationsTextBox
            '
            Me.ObservationsTextBox.AcceptsReturn = True
            Me.ObservationsTextBox.AcceptsTab = True
            Me.ObservationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ResultatBaremeBindingSource, "Observations", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.ObservationsTextBox.Location = New System.Drawing.Point(15, 226)
            Me.ObservationsTextBox.Multiline = True
            Me.ObservationsTextBox.Name = "ObservationsTextBox"
            Me.ObservationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ObservationsTextBox.Size = New System.Drawing.Size(485, 210)
            Me.ObservationsTextBox.TabIndex = 8
            '
            'ActionCorrectiveTextBox
            '
            Me.ActionCorrectiveTextBox.AcceptsReturn = True
            Me.ActionCorrectiveTextBox.AcceptsTab = True
            Me.ActionCorrectiveTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ResultatBaremeBindingSource, "ActionCorrective", True))
            Me.ActionCorrectiveTextBox.Location = New System.Drawing.Point(15, 22)
            Me.ActionCorrectiveTextBox.Multiline = True
            Me.ActionCorrectiveTextBox.Name = "ActionCorrectiveTextBox"
            Me.ActionCorrectiveTextBox.ReadOnly = True
            Me.ActionCorrectiveTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ActionCorrectiveTextBox.Size = New System.Drawing.Size(485, 155)
            Me.ActionCorrectiveTextBox.TabIndex = 11
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.BtCancel)
            Me.GradientPanel1.Controls.Add(Me.BtPrevious)
            Me.GradientPanel1.Controls.Add(Me.BtNext)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
            Me.GradientPanel1.GradientLowColor = System.Drawing.Color.DarkGray
            Me.GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 447)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
            Me.GradientPanel1.Size = New System.Drawing.Size(514, 40)
            Me.GradientPanel1.TabIndex = 12
            '
            'BtCancel
            '
            Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.BtCancel.Location = New System.Drawing.Point(428, 8)
            Me.BtCancel.Name = "BtCancel"
            Me.BtCancel.Size = New System.Drawing.Size(75, 23)
            Me.BtCancel.TabIndex = 2
            Me.BtCancel.Text = "Annuler"
            Me.BtCancel.UseVisualStyleBackColor = True
            '
            'BtPrevious
            '
            Me.BtPrevious.Location = New System.Drawing.Point(266, 8)
            Me.BtPrevious.Name = "BtPrevious"
            Me.BtPrevious.Size = New System.Drawing.Size(75, 23)
            Me.BtPrevious.TabIndex = 1
            Me.BtPrevious.Text = "< Précédent"
            Me.BtPrevious.UseVisualStyleBackColor = True
            '
            'BtNext
            '
            Me.BtNext.Location = New System.Drawing.Point(347, 8)
            Me.BtNext.Name = "BtNext"
            Me.BtNext.Size = New System.Drawing.Size(75, 23)
            Me.BtNext.TabIndex = 0
            Me.BtNext.Text = "Suivant >"
            Me.BtNext.UseVisualStyleBackColor = True
            '
            'LinkLabel1
            '
            Me.lnkDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lnkDoc.AutoSize = True
            Me.lnkDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lnkDoc.Location = New System.Drawing.Point(387, 185)
            Me.lnkDoc.Name = "LinkLabel1"
            Me.lnkDoc.Padding = New System.Windows.Forms.Padding(18, 3, 0, 3)
            Me.lnkDoc.Size = New System.Drawing.Size(113, 19)
            Me.lnkDoc.TabIndex = 13
            Me.lnkDoc.TabStop = True
            Me.lnkDoc.Text = "Document associé"
            Me.lnkDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GradientPanel2
            '
            Me.GradientPanel2.Controls.Add(ActionCorrectiveLabel)
            Me.GradientPanel2.Controls.Add(Me.lnkDoc)
            Me.GradientPanel2.Controls.Add(ObservationsLabel)
            Me.GradientPanel2.Controls.Add(Me.ObservationsTextBox)
            Me.GradientPanel2.Controls.Add(Me.ActionCorrectiveTextBox)
            Me.GradientPanel2.Controls.Add(Me.ActionCorrectiveEffectueeCheckBox)
            Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
            Me.GradientPanel2.Name = "GradientPanel2"
            Me.GradientPanel2.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel2.Size = New System.Drawing.Size(514, 447)
            Me.GradientPanel2.TabIndex = 16
            '
            'FrResultatBareme
            '
            Me.AcceptButton = Me.BtNext
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.BtCancel
            Me.ClientSize = New System.Drawing.Size(514, 487)
            Me.ControlBox = False
            Me.Controls.Add(Me.GradientPanel2)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Name = "FrResultatBareme"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Résultat du Barème"
            CType(Me.ResultatBaremeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel2.ResumeLayout(False)
            Me.GradientPanel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ResultatBaremeBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ActionCorrectiveEffectueeCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents ObservationsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ActionCorrectiveTextBox As System.Windows.Forms.TextBox
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents BtCancel As System.Windows.Forms.Button
        Friend WithEvents BtPrevious As System.Windows.Forms.Button
        Friend WithEvents BtNext As System.Windows.Forms.Button
        Friend WithEvents lnkDoc As System.Windows.Forms.LinkLabel
        Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    End Class
End Namespace