<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrMethodeEvaluation
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MethodeInventaireComboBox = New System.Windows.Forms.ComboBox
        Me.DossiersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetAgrigest = New AgrigestEDI.DataSetAgrigest
        Me.MethodeInventaireBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OKButton = New System.Windows.Forms.Button
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.DossiersTableAdapter = New AgrigestEDI.DataSetAgrigestTableAdapters.DossiersTableAdapter
        Me.GroupBox1.SuspendLayout()
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MethodeInventaireBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MethodeInventaireComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Méthode d'évaluation des avances aux cultures"
        '
        'MethodeInventaireComboBox
        '
        Me.MethodeInventaireComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.DossiersBindingSource, "DMethodeInventaire", True))
        Me.MethodeInventaireComboBox.DataSource = Me.MethodeInventaireBindingSource
        Me.MethodeInventaireComboBox.DisplayMember = "Libelle"
        Me.MethodeInventaireComboBox.FormattingEnabled = True
        Me.MethodeInventaireComboBox.Location = New System.Drawing.Point(6, 19)
        Me.MethodeInventaireComboBox.Name = "MethodeInventaireComboBox"
        Me.MethodeInventaireComboBox.Size = New System.Drawing.Size(325, 21)
        Me.MethodeInventaireComboBox.TabIndex = 1
        Me.MethodeInventaireComboBox.ValueMember = "Libelle"
        '
        'DossiersBindingSource
        '
        Me.DossiersBindingSource.DataMember = "Dossiers"
        Me.DossiersBindingSource.DataSource = Me.DataSetAgrigest
        '
        'DataSetAgrigest
        '
        Me.DataSetAgrigest.DataSetName = "DataSetAgrigest"
        Me.DataSetAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MethodeInventaireBindingSource
        '
        Me.MethodeInventaireBindingSource.DataMember = "MethodeInventaire"
        Me.MethodeInventaireBindingSource.DataSource = Me.DataSetAgrigest
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(193, 69)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(274, 69)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 2
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'FrMethodeEvaluation
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(369, 103)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrMethodeEvaluation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DossiersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MethodeInventaireBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents DataSetAgrigest As AgrigestEDI.DataSetAgrigest
    Friend WithEvents DossiersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DossiersTableAdapter As AgrigestEDI.DataSetAgrigestTableAdapters.DossiersTableAdapter
    Friend WithEvents MethodeInventaireComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MethodeInventaireBindingSource As System.Windows.Forms.BindingSource
End Class
