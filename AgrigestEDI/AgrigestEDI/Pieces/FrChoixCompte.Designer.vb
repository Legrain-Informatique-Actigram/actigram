<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixCompte
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
        Me.components = New System.ComponentModel.Container
        Dim CompteDisplayLabel As System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.CompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.ComptesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
        Me.cboCompteDisplay = New System.Windows.Forms.ComboBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        CompteDisplayLabel = New System.Windows.Forms.Label
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CompteDisplayLabel
        '
        CompteDisplayLabel.AutoSize = True
        CompteDisplayLabel.Location = New System.Drawing.Point(8, 18)
        CompteDisplayLabel.Name = "CompteDisplayLabel"
        CompteDisplayLabel.Size = New System.Drawing.Size(49, 13)
        CompteDisplayLabel.TabIndex = 2
        CompteDisplayLabel.Text = "Compte :"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(116, 7)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(189, 7)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'CompteBindingSource
        '
        Me.CompteBindingSource.DataMember = "Comptes"
        Me.CompteBindingSource.DataSource = Me.DsPLC
        Me.CompteBindingSource.Sort = "CCpt"
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'cboCompteDisplay
        '
        Me.cboCompteDisplay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCompteDisplay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompteDisplay.DataSource = Me.CompteBindingSource
        Me.cboCompteDisplay.DisplayMember = "CDisplay"
        Me.cboCompteDisplay.FormattingEnabled = True
        Me.cboCompteDisplay.Location = New System.Drawing.Point(63, 12)
        Me.cboCompteDisplay.Name = "cboCompteDisplay"
        Me.cboCompteDisplay.Size = New System.Drawing.Size(192, 21)
        Me.cboCompteDisplay.TabIndex = 0
        Me.cboCompteDisplay.ValueMember = "CCpt"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.cboCompteDisplay)
        Me.GradientPanel1.Controls.Add(CompteDisplayLabel)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(268, 54)
        Me.GradientPanel1.TabIndex = 3
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 54)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(268, 42)
        Me.GradientPanel2.TabIndex = 4
        '
        'FrChoixCompte
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(268, 96)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrChoixCompte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choix du compte"
        CType(Me.CompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
    Friend WithEvents cboCompteDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel

End Class
