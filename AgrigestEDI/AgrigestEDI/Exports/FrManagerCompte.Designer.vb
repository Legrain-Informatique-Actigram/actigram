<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrManagerCompte
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
        Me.dgvSaisie = New System.Windows.Forms.DataGridView
        Me.dgvAvant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvCompte = New AgrigestEDI.DatagridViewComboboxColumnCustom
        Me.BindingSourceCompte = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPLC = New AgrigestEDI.dsPLC
        Me.dgvLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvDebit = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.dgvCredit = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtValider = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.PlanTypeTableAdapter = New AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        CType(Me.dgvSaisie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceCompte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSaisie
        '
        Me.dgvSaisie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvSaisie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaisie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvAvant, Me.dgvCompte, Me.dgvLibelle, Me.dgvDebit, Me.dgvCredit})
        Me.dgvSaisie.Location = New System.Drawing.Point(12, 24)
        Me.dgvSaisie.Name = "dgvSaisie"
        Me.dgvSaisie.RowHeadersWidth = 25
        Me.dgvSaisie.Size = New System.Drawing.Size(840, 340)
        Me.dgvSaisie.TabIndex = 0
        '
        'dgvAvant
        '
        Me.dgvAvant.DataPropertyName = "Avant"
        Me.dgvAvant.HeaderText = "Compte chargé"
        Me.dgvAvant.Name = "dgvAvant"
        Me.dgvAvant.ReadOnly = True
        Me.dgvAvant.Width = 150
        '
        'dgvCompte
        '
        Me.dgvCompte.DataPropertyName = "Compte"
        Me.dgvCompte.DataSource = Me.BindingSourceCompte
        Me.dgvCompte.DisplayComboBoxOnCurrentCellOnly = False
        Me.dgvCompte.DisplayMember = "PlDisplay"
        Me.dgvCompte.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.dgvCompte.DisplayStyleForCurrentCellOnly = True
        Me.dgvCompte.DropDownWidth = 200
        Me.dgvCompte.HeaderText = "Compte"
        Me.dgvCompte.Name = "dgvCompte"
        Me.dgvCompte.ValueMember = "CCpt"
        Me.dgvCompte.Width = 250
        '
        'BindingSourceCompte
        '
        Me.BindingSourceCompte.DataMember = "PlanType"
        Me.BindingSourceCompte.DataSource = Me.DsPLC
        '
        'DsPLC
        '
        Me.DsPLC.DataSetName = "dsPLC"
        Me.DsPLC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvLibelle
        '
        Me.dgvLibelle.DataPropertyName = "LibelleCompte"
        Me.dgvLibelle.HeaderText = "Libéllé de compte"
        Me.dgvLibelle.Name = "dgvLibelle"
        Me.dgvLibelle.Width = 300
        '
        'dgvDebit
        '
        Me.dgvDebit.DataPropertyName = "Debit"
        Me.dgvDebit.HeaderText = "Débit"
        Me.dgvDebit.Name = "dgvDebit"
        '
        'dgvCredit
        '
        Me.dgvCredit.DataPropertyName = "Credit"
        Me.dgvCredit.HeaderText = "Crédit"
        Me.dgvCredit.Name = "dgvCredit"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(775, 9)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtValider
        '
        Me.BtValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtValider.Location = New System.Drawing.Point(695, 9)
        Me.BtValider.Name = "BtValider"
        Me.BtValider.Size = New System.Drawing.Size(75, 23)
        Me.BtValider.TabIndex = 0
        Me.BtValider.Text = "Valider"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Comptes :"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.dgvSaisie)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(862, 417)
        Me.GradientPanel1.TabIndex = 17
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 373)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(862, 44)
        Me.GradientPanel2.TabIndex = 17
        '
        'FrManagerCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(862, 417)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrManagerCompte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Saisie de la balance"
        CType(Me.dgvSaisie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceCompte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPLC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSaisie As System.Windows.Forms.DataGridView
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtValider As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents DsPLC As AgrigestEDI.dsPLC
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dsPLCTableAdapters.PlanTypeTableAdapter
    Friend WithEvents BindingSourceCompte As System.Windows.Forms.BindingSource
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dgvAvant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCompte As AgrigestEDI.DatagridViewComboboxColumnCustom
    Friend WithEvents dgvLibelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDebit As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents dgvCredit As AgrigestEDI.DatagridViewNumericTextBoxColumn
End Class
