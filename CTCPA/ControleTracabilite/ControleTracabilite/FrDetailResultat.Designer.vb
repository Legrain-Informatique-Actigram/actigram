<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrDetailResultat
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrDetailResultat))
        Dim IdControleLabel As System.Windows.Forms.Label
        Dim LibControleLabel As System.Windows.Forms.Label
        Dim ResultatLabel As System.Windows.Forms.Label
        Me.ResBaremesDataGridView = New System.Windows.Forms.DataGridView
        Me.BaremeExpression = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActionCorrective = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.BtClose = New System.Windows.Forms.ToolStripButton
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.IdControleLabel1 = New System.Windows.Forms.Label
        Me.LibControleLabel1 = New System.Windows.Forms.Label
        Me.ResultatLabel1 = New System.Windows.Forms.Label
        Me.ResultatExpressionDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ResultatConformiteDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ObservationsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ResBaremesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ResultatControleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        IdControleLabel = New System.Windows.Forms.Label
        LibControleLabel = New System.Windows.Forms.Label
        ResultatLabel = New System.Windows.Forms.Label
        CType(Me.ResBaremesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.ResBaremesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultatControleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ResBaremesDataGridView
        '
        Me.ResBaremesDataGridView.AllowUserToAddRows = False
        Me.ResBaremesDataGridView.AllowUserToDeleteRows = False
        Me.ResBaremesDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.ResBaremesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ResBaremesDataGridView.AutoGenerateColumns = False
        Me.ResBaremesDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.ResBaremesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.ResBaremesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BaremeExpression, Me.ResultatExpressionDataGridViewCheckBoxColumn, Me.ResultatConformiteDataGridViewCheckBoxColumn, Me.ActionCorrective, Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn, Me.ObservationsDataGridViewTextBoxColumn})
        Me.ResBaremesDataGridView.DataSource = Me.ResBaremesBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ResBaremesDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ResBaremesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResBaremesDataGridView.Location = New System.Drawing.Point(0, 95)
        Me.ResBaremesDataGridView.MultiSelect = False
        Me.ResBaremesDataGridView.Name = "ResBaremesDataGridView"
        Me.ResBaremesDataGridView.ReadOnly = True
        Me.ResBaremesDataGridView.RowHeadersVisible = False
        Me.ResBaremesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ResBaremesDataGridView.Size = New System.Drawing.Size(636, 312)
        Me.ResBaremesDataGridView.TabIndex = 1
        '
        'BaremeExpression
        '
        Me.BaremeExpression.DataPropertyName = "BaremeExpression"
        Me.BaremeExpression.HeaderText = "Expression"
        Me.BaremeExpression.Name = "BaremeExpression"
        Me.BaremeExpression.ReadOnly = True
        Me.BaremeExpression.Width = 150
        '
        'ActionCorrective
        '
        Me.ActionCorrective.DataPropertyName = "ActionCorrective"
        Me.ActionCorrective.HeaderText = "Action Corrective"
        Me.ActionCorrective.Name = "ActionCorrective"
        Me.ActionCorrective.ReadOnly = True
        Me.ActionCorrective.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(636, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtClose
        '
        Me.BtClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(23, 22)
        Me.BtClose.Text = "Fermer"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(ResultatLabel)
        Me.GradientPanel1.Controls.Add(Me.ResultatLabel1)
        Me.GradientPanel1.Controls.Add(LibControleLabel)
        Me.GradientPanel1.Controls.Add(Me.LibControleLabel1)
        Me.GradientPanel1.Controls.Add(IdControleLabel)
        Me.GradientPanel1.Controls.Add(Me.IdControleLabel1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(636, 70)
        Me.GradientPanel1.TabIndex = 3
        '
        'IdControleLabel
        '
        IdControleLabel.AutoSize = True
        IdControleLabel.Location = New System.Drawing.Point(8, 13)
        IdControleLabel.Name = "IdControleLabel"
        IdControleLabel.Size = New System.Drawing.Size(61, 13)
        IdControleLabel.TabIndex = 0
        IdControleLabel.Text = "Id Controle:"
        '
        'IdControleLabel1
        '
        Me.IdControleLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.IdControleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IdControleLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ResultatControleBindingSource, "IdControle", True))
        Me.IdControleLabel1.Location = New System.Drawing.Point(70, 8)
        Me.IdControleLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.IdControleLabel1.Name = "IdControleLabel1"
        Me.IdControleLabel1.Size = New System.Drawing.Size(100, 23)
        Me.IdControleLabel1.TabIndex = 1
        Me.IdControleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LibControleLabel
        '
        LibControleLabel.AutoSize = True
        LibControleLabel.Location = New System.Drawing.Point(181, 13)
        LibControleLabel.Name = "LibControleLabel"
        LibControleLabel.Size = New System.Drawing.Size(66, 13)
        LibControleLabel.TabIndex = 2
        LibControleLabel.Text = "Lib Controle:"
        '
        'LibControleLabel1
        '
        Me.LibControleLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.LibControleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LibControleLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ResultatControleBindingSource, "LibControle", True))
        Me.LibControleLabel1.Location = New System.Drawing.Point(248, 8)
        Me.LibControleLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.LibControleLabel1.Name = "LibControleLabel1"
        Me.LibControleLabel1.Size = New System.Drawing.Size(380, 23)
        Me.LibControleLabel1.TabIndex = 3
        Me.LibControleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ResultatLabel
        '
        ResultatLabel.AutoSize = True
        ResultatLabel.Location = New System.Drawing.Point(20, 42)
        ResultatLabel.Name = "ResultatLabel"
        ResultatLabel.Size = New System.Drawing.Size(49, 13)
        ResultatLabel.TabIndex = 4
        ResultatLabel.Text = "Resultat:"
        '
        'ResultatLabel1
        '
        Me.ResultatLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ResultatLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ResultatLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ResultatControleBindingSource, "Resultat", True))
        Me.ResultatLabel1.Location = New System.Drawing.Point(70, 37)
        Me.ResultatLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.ResultatLabel1.Name = "ResultatLabel1"
        Me.ResultatLabel1.Size = New System.Drawing.Size(558, 23)
        Me.ResultatLabel1.TabIndex = 5
        Me.ResultatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ResultatExpressionDataGridViewCheckBoxColumn
        '
        Me.ResultatExpressionDataGridViewCheckBoxColumn.DataPropertyName = "ResultatExpression"
        Me.ResultatExpressionDataGridViewCheckBoxColumn.HeaderText = "Validé"
        Me.ResultatExpressionDataGridViewCheckBoxColumn.Name = "ResultatExpressionDataGridViewCheckBoxColumn"
        Me.ResultatExpressionDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ResultatExpressionDataGridViewCheckBoxColumn.Width = 50
        '
        'ResultatConformiteDataGridViewCheckBoxColumn
        '
        Me.ResultatConformiteDataGridViewCheckBoxColumn.DataPropertyName = "ResultatConformite"
        Me.ResultatConformiteDataGridViewCheckBoxColumn.HeaderText = "Conforme"
        Me.ResultatConformiteDataGridViewCheckBoxColumn.Name = "ResultatConformiteDataGridViewCheckBoxColumn"
        Me.ResultatConformiteDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ResultatConformiteDataGridViewCheckBoxColumn.Width = 55
        '
        'ActionCorrectiveEffectueeDataGridViewCheckBoxColumn
        '
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn.DataPropertyName = "ActionCorrectiveEffectuee"
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn.HeaderText = "Effectué"
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn.Name = "ActionCorrectiveEffectueeDataGridViewCheckBoxColumn"
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ActionCorrectiveEffectueeDataGridViewCheckBoxColumn.Width = 55
        '
        'ObservationsDataGridViewTextBoxColumn
        '
        Me.ObservationsDataGridViewTextBoxColumn.DataPropertyName = "Observations"
        Me.ObservationsDataGridViewTextBoxColumn.HeaderText = "Observations"
        Me.ObservationsDataGridViewTextBoxColumn.Name = "ObservationsDataGridViewTextBoxColumn"
        Me.ObservationsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ResBaremesBindingSource
        '
        Me.ResBaremesBindingSource.DataSource = GetType(ControleTracabilite.Controles.ResultatBareme)
        '
        'ResultatControleBindingSource
        '
        Me.ResultatControleBindingSource.DataSource = GetType(ControleTracabilite.Controles.ResultatControle)
        '
        'FrDetailResultat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 407)
        Me.Controls.Add(Me.ResBaremesDataGridView)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrDetailResultat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Résultat des Barèmes"
        CType(Me.ResBaremesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.ResBaremesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultatControleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ResBaremesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ResBaremesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents BaremeExpression As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResultatExpressionDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ResultatConformiteDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ActionCorrective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActionCorrectiveEffectueeDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObservationsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ResultatLabel1 As System.Windows.Forms.Label
    Friend WithEvents ResultatControleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LibControleLabel1 As System.Windows.Forms.Label
    Friend WithEvents IdControleLabel1 As System.Windows.Forms.Label

End Class
