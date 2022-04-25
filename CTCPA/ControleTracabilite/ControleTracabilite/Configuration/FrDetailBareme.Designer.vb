Namespace Controles
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrDetailBareme
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
            Dim ExpressionLabel As System.Windows.Forms.Label
            Dim CheminDocLabel As System.Windows.Forms.Label
            Dim ActionCorrectiveLabel As System.Windows.Forms.Label
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.BaremesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.BaremeTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.ResultatConformiteCheckBox = New System.Windows.Forms.CheckBox
            Me.BaremeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.BtBrowse = New System.Windows.Forms.Button
            Me.CheminDocTextBox = New System.Windows.Forms.TextBox
            Me.ActionCorrectiveTextBox = New System.Windows.Forms.TextBox
            Me.ExpressionTextBox = New System.Windows.Forms.TextBox
            Me.TbEnregistrer = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.ControleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
            ExpressionLabel = New System.Windows.Forms.Label
            CheminDocLabel = New System.Windows.Forms.Label
            ActionCorrectiveLabel = New System.Windows.Forms.Label
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BaremesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.BaremeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ControleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ControleBindingNavigator.SuspendLayout()
            Me.SuspendLayout()
            '
            'ExpressionLabel
            '
            ExpressionLabel.AutoSize = True
            ExpressionLabel.Location = New System.Drawing.Point(8, 11)
            ExpressionLabel.Name = "ExpressionLabel"
            ExpressionLabel.Size = New System.Drawing.Size(104, 13)
            ExpressionLabel.TabIndex = 0
            ExpressionLabel.Text = "Expression à vérifier:"
            '
            'CheminDocLabel
            '
            CheminDocLabel.AutoSize = True
            CheminDocLabel.Location = New System.Drawing.Point(3, 42)
            CheminDocLabel.Name = "CheminDocLabel"
            CheminDocLabel.Size = New System.Drawing.Size(167, 13)
            CheminDocLabel.TabIndex = 4
            CheminDocLabel.Text = "Le document suivant est proposé:"
            '
            'ActionCorrectiveLabel
            '
            ActionCorrectiveLabel.AutoSize = True
            ActionCorrectiveLabel.Location = New System.Drawing.Point(3, 81)
            ActionCorrectiveLabel.Name = "ActionCorrectiveLabel"
            ActionCorrectiveLabel.Size = New System.Drawing.Size(216, 13)
            ActionCorrectiveLabel.TabIndex = 6
            ActionCorrectiveLabel.Text = "L'action corrective suivante doit être menée:"
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BaremeTableAdapter
            '
            Me.BaremeTableAdapter.ClearBeforeFill = True
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.GroupBox1)
            Me.GradientPanel1.Controls.Add(ExpressionLabel)
            Me.GradientPanel1.Controls.Add(Me.ExpressionTextBox)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(424, 352)
            Me.GradientPanel1.TabIndex = 15
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.ResultatConformiteCheckBox)
            Me.GroupBox1.Controls.Add(Me.BtBrowse)
            Me.GroupBox1.Controls.Add(Me.CheminDocTextBox)
            Me.GroupBox1.Controls.Add(CheminDocLabel)
            Me.GroupBox1.Controls.Add(ActionCorrectiveLabel)
            Me.GroupBox1.Controls.Add(Me.ActionCorrectiveTextBox)
            Me.GroupBox1.Location = New System.Drawing.Point(11, 34)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(403, 307)
            Me.GroupBox1.TabIndex = 10
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Si le résultat du contrôle ne vérifie pas l'expression :"
            '
            'ResultatConformiteCheckBox
            '
            Me.ResultatConformiteCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.ResultatConformiteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BaremeBindingSource, "ResultatConformite", True))
            Me.ResultatConformiteCheckBox.Location = New System.Drawing.Point(6, 19)
            Me.ResultatConformiteCheckBox.Name = "ResultatConformiteCheckBox"
            Me.ResultatConformiteCheckBox.Size = New System.Drawing.Size(298, 20)
            Me.ResultatConformiteCheckBox.TabIndex = 3
            Me.ResultatConformiteCheckBox.Text = "Le résultat est quand même considéré comme conforme."
            Me.ResultatConformiteCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft
            '
            'BaremeBindingSource
            '
            Me.BaremeBindingSource.DataMember = "Bareme"
            Me.BaremeBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'BtBrowse
            '
            Me.BtBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtBrowse.Image = Global.ControleTracabilite.My.Resources.Resources.open
            Me.BtBrowse.Location = New System.Drawing.Point(364, 56)
            Me.BtBrowse.Name = "BtBrowse"
            Me.BtBrowse.Size = New System.Drawing.Size(33, 23)
            Me.BtBrowse.TabIndex = 9
            Me.BtBrowse.UseVisualStyleBackColor = True
            '
            'CheminDocTextBox
            '
            Me.CheminDocTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheminDocTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
            Me.CheminDocTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BaremeBindingSource, "CheminDoc", True))
            Me.CheminDocTextBox.Location = New System.Drawing.Point(6, 58)
            Me.CheminDocTextBox.Name = "CheminDocTextBox"
            Me.CheminDocTextBox.Size = New System.Drawing.Size(352, 20)
            Me.CheminDocTextBox.TabIndex = 5
            '
            'ActionCorrectiveTextBox
            '
            Me.ActionCorrectiveTextBox.AcceptsReturn = True
            Me.ActionCorrectiveTextBox.AcceptsTab = True
            Me.ActionCorrectiveTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ActionCorrectiveTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BaremeBindingSource, "ActionCorrective", True))
            Me.ActionCorrectiveTextBox.Location = New System.Drawing.Point(6, 97)
            Me.ActionCorrectiveTextBox.Multiline = True
            Me.ActionCorrectiveTextBox.Name = "ActionCorrectiveTextBox"
            Me.ActionCorrectiveTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ActionCorrectiveTextBox.Size = New System.Drawing.Size(391, 204)
            Me.ActionCorrectiveTextBox.TabIndex = 7
            '
            'ExpressionTextBox
            '
            Me.ExpressionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ExpressionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BaremeBindingSource, "Expression", True))
            Me.ExpressionTextBox.Location = New System.Drawing.Point(118, 8)
            Me.ExpressionTextBox.Name = "ExpressionTextBox"
            Me.ExpressionTextBox.Size = New System.Drawing.Size(296, 20)
            Me.ExpressionTextBox.TabIndex = 1
            '
            'TbEnregistrer
            '
            Me.TbEnregistrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbEnregistrer.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.TbEnregistrer.Name = "TbEnregistrer"
            Me.TbEnregistrer.Size = New System.Drawing.Size(23, 22)
            Me.TbEnregistrer.Text = "Enregistrer les données"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'ControleBindingNavigator
            '
            Me.ControleBindingNavigator.AddNewItem = Nothing
            Me.ControleBindingNavigator.CountItem = Nothing
            Me.ControleBindingNavigator.DeleteItem = Nothing
            Me.ControleBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ControleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbEnregistrer, Me.TbFermer})
            Me.ControleBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.ControleBindingNavigator.MoveFirstItem = Nothing
            Me.ControleBindingNavigator.MoveLastItem = Nothing
            Me.ControleBindingNavigator.MoveNextItem = Nothing
            Me.ControleBindingNavigator.MovePreviousItem = Nothing
            Me.ControleBindingNavigator.Name = "ControleBindingNavigator"
            Me.ControleBindingNavigator.PositionItem = Nothing
            Me.ControleBindingNavigator.Size = New System.Drawing.Size(424, 25)
            Me.ControleBindingNavigator.TabIndex = 14
            Me.ControleBindingNavigator.Text = "BindingNavigator1"
            '
            'OpenFileDialog
            '
            Me.OpenFileDialog.FileName = "OpenFileDialog1"
            '
            'FrDetailBareme
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(424, 377)
            Me.ControlBox = False
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.ControleBindingNavigator)
            Me.Name = "FrDetailBareme"
            Me.Text = "Propriétés du Barème"
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BaremesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.BaremeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ControleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ControleBindingNavigator.ResumeLayout(False)
            Me.ControleBindingNavigator.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BaremesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents BaremeTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents TbEnregistrer As System.Windows.Forms.ToolStripButton
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents ControleBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents BaremeBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ActionCorrectiveTextBox As System.Windows.Forms.TextBox
        Friend WithEvents CheminDocTextBox As System.Windows.Forms.TextBox
        Friend WithEvents ResultatConformiteCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents ExpressionTextBox As System.Windows.Forms.TextBox
        Friend WithEvents BtBrowse As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    End Class
End Namespace
