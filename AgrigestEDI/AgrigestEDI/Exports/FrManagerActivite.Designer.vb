<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrManagerActivite
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
        Me.dgvAffectationActivite = New System.Windows.Forms.DataGridView
        Me.dgvAvantActivite = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvApresActivite = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.BindingSourceActivite = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.BindingSourceCompte = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.RicaTableAdapter = New AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
        Me.PlanTypeTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtValider = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        CType(Me.dgvAffectationActivite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceActivite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceCompte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAffectationActivite
        '
        Me.dgvAffectationActivite.AllowUserToAddRows = False
        Me.dgvAffectationActivite.AllowUserToDeleteRows = False
        Me.dgvAffectationActivite.AllowUserToResizeColumns = False
        Me.dgvAffectationActivite.AllowUserToResizeRows = False
        Me.dgvAffectationActivite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAffectationActivite.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvAvantActivite, Me.dgvApresActivite})
        Me.dgvAffectationActivite.Location = New System.Drawing.Point(12, 25)
        Me.dgvAffectationActivite.Name = "dgvAffectationActivite"
        Me.dgvAffectationActivite.RowHeadersVisible = False
        Me.dgvAffectationActivite.Size = New System.Drawing.Size(417, 131)
        Me.dgvAffectationActivite.TabIndex = 46
        '
        'dgvAvantActivite
        '
        Me.dgvAvantActivite.DataPropertyName = "dgvAvant"
        Me.dgvAvantActivite.HeaderText = "Champ"
        Me.dgvAvantActivite.Name = "dgvAvantActivite"
        Me.dgvAvantActivite.ReadOnly = True
        Me.dgvAvantActivite.Width = 200
        '
        'dgvApresActivite
        '
        Me.dgvApresActivite.DataPropertyName = "dgvActivite"
        Me.dgvApresActivite.DataSource = Me.BindingSourceActivite
        Me.dgvApresActivite.DisplayComboBoxOnCurrentCellOnly = False
        Me.dgvApresActivite.DisplayMember = "RDisplay"
        Me.dgvApresActivite.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.dgvApresActivite.DisplayStyleForCurrentCellOnly = True
        Me.dgvApresActivite.DropDownWidth = 200
        Me.dgvApresActivite.HeaderText = "Proposition"
        Me.dgvApresActivite.Name = "dgvApresActivite"
        Me.dgvApresActivite.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApresActivite.ValueMember = "RiCode"
        Me.dgvApresActivite.Width = 200
        '
        'BindingSourceActivite
        '
        Me.BindingSourceActivite.DataMember = "Rica"
        Me.BindingSourceActivite.DataSource = Me.DsPLC
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingSourceCompte
        '
        Me.BindingSourceCompte.DataMember = "PlanType"
        Me.BindingSourceCompte.DataSource = Me.DsPLC
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Activités :"
        '
        'RicaTableAdapter
        '
        Me.RicaTableAdapter.ClearBeforeFill = True
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.dgvAffectationActivite)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(442, 213)
        Me.GradientPanel1.TabIndex = 50
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(355, 12)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtValider
        '
        Me.BtValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtValider.Location = New System.Drawing.Point(275, 12)
        Me.BtValider.Name = "BtValider"
        Me.BtValider.Size = New System.Drawing.Size(75, 23)
        Me.BtValider.TabIndex = 0
        Me.BtValider.Text = "Valider"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtValider)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 166)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(442, 47)
        Me.GradientPanel2.TabIndex = 50
        '
        'FrManagerActivite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 213)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrManagerActivite"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Réaffectation des activités"
        CType(Me.dgvAffectationActivite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceActivite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceCompte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAffectationActivite As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSourceActivite As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSourceCompte As System.Windows.Forms.BindingSource
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents RicaTableAdapter As AgrigestEDI.dsPLCTableAdapters.RicaTableAdapter
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtValider As System.Windows.Forms.Button
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dgvAvantActivite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvApresActivite As AgrigestEDI.DatagridViewComboboxColumnCustom

End Class
