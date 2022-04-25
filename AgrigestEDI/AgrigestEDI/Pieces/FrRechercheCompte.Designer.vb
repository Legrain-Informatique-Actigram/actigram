<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRechercheCompte
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtRecherche = New System.Windows.Forms.TextBox
        Me.PLCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRecherche = New AgrigestEDI.dsPLC
        Me.PlanTypeTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
        Me.dgvRecherche = New System.Windows.Forms.DataGridView
        Me.dgvCompte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlanComptableTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.ComptesTableAdapter = New AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter
        CType(Me.PLCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRecherche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecherche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(385, 7)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(458, 7)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'txtRecherche
        '
        Me.txtRecherche.AcceptsReturn = True
        Me.txtRecherche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecherche.Location = New System.Drawing.Point(12, 12)
        Me.txtRecherche.Name = "txtRecherche"
        Me.txtRecherche.Size = New System.Drawing.Size(513, 20)
        Me.txtRecherche.TabIndex = 0
        '
        'PLCBindingSource
        '
        Me.PLCBindingSource.DataMember = "PlanComptable"
        Me.PLCBindingSource.DataSource = Me.DsRecherche
        '
        'DsRecherche
        '
        Me.DsRecherche.DataSetName = "dsRecherche"
        Me.DsRecherche.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'dgvRecherche
        '
        Me.dgvRecherche.AllowUserToAddRows = False
        Me.dgvRecherche.AllowUserToDeleteRows = False
        Me.dgvRecherche.AllowUserToOrderColumns = True
        Me.dgvRecherche.AllowUserToResizeColumns = False
        Me.dgvRecherche.AllowUserToResizeRows = False
        Me.dgvRecherche.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecherche.AutoGenerateColumns = False
        Me.dgvRecherche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecherche.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvCompte, Me.dgvLib})
        Me.dgvRecherche.DataSource = Me.PLCBindingSource
        Me.dgvRecherche.Location = New System.Drawing.Point(12, 38)
        Me.dgvRecherche.MultiSelect = False
        Me.dgvRecherche.Name = "dgvRecherche"
        Me.dgvRecherche.ReadOnly = True
        Me.dgvRecherche.RowHeadersVisible = False
        Me.dgvRecherche.RowHeadersWidth = 50
        Me.dgvRecherche.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecherche.Size = New System.Drawing.Size(513, 219)
        Me.dgvRecherche.TabIndex = 3
        '
        'dgvCompte
        '
        Me.dgvCompte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvCompte.DataPropertyName = "PlCpt"
        Me.dgvCompte.HeaderText = "Compte"
        Me.dgvCompte.Name = "dgvCompte"
        Me.dgvCompte.ReadOnly = True
        Me.dgvCompte.Width = 68
        '
        'dgvLib
        '
        Me.dgvLib.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvLib.DataPropertyName = "CptDisplay"
        Me.dgvLib.HeaderText = "Libellé du compte"
        Me.dgvLib.Name = "dgvLib"
        Me.dgvLib.ReadOnly = True
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 263)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(537, 42)
        Me.GradientPanel2.TabIndex = 5
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.dgvRecherche)
        Me.GradientPanel1.Controls.Add(Me.txtRecherche)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(537, 263)
        Me.GradientPanel1.TabIndex = 6
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'FrRechercheCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(537, 305)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrRechercheCompte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recherche d'un compte"
        CType(Me.PLCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRecherche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecherche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtRecherche As System.Windows.Forms.TextBox
    Friend WithEvents DsRecherche As AgrigestEDI.dsPLC
    Friend WithEvents PLCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
    Friend WithEvents dgvRecherche As System.Windows.Forms.DataGridView
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanComptableTableAdapter
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dgvCompte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dsPLCTableAdapters.ComptesTableAdapter

End Class
