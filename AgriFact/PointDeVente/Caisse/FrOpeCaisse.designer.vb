<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrOpeCaisse
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
        Dim TypeLabel As System.Windows.Forms.Label
        Dim MontantLabel As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim DateCaisseLabel As System.Windows.Forms.Label
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.DateCaisseDateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.JournalCaisseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DateCaisseDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.MontantTextBox = New System.Windows.Forms.TextBox
        Me.TypeComboBox = New System.Windows.Forms.ComboBox
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.JournalCaisseTA = New PointDeVente.DsAgrifactTableAdapters.JournalCaisseTA
        TypeLabel = New System.Windows.Forms.Label
        MontantLabel = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        DateCaisseLabel = New System.Windows.Forms.Label
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.JournalCaisseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TypeLabel
        '
        TypeLabel.AutoSize = True
        TypeLabel.Location = New System.Drawing.Point(8, 37)
        TypeLabel.Name = "TypeLabel"
        TypeLabel.Size = New System.Drawing.Size(34, 13)
        TypeLabel.TabIndex = 3
        TypeLabel.Text = "Type:"
        '
        'MontantLabel
        '
        MontantLabel.AutoSize = True
        MontantLabel.Location = New System.Drawing.Point(225, 37)
        MontantLabel.Name = "MontantLabel"
        MontantLabel.Size = New System.Drawing.Size(22, 13)
        MontantLabel.TabIndex = 5
        MontantLabel.Text = "Mt:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(8, 64)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(40, 13)
        LibelleLabel.TabIndex = 7
        LibelleLabel.Text = "Libelle:"
        '
        'DateCaisseLabel
        '
        DateCaisseLabel.AutoSize = True
        DateCaisseLabel.Location = New System.Drawing.Point(8, 12)
        DateCaisseLabel.Name = "DateCaisseLabel"
        DateCaisseLabel.Size = New System.Drawing.Size(36, 13)
        DateCaisseLabel.TabIndex = 0
        DateCaisseLabel.Text = "Date :"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.DateCaisseDateTimePicker1)
        Me.GradientPanel1.Controls.Add(DateCaisseLabel)
        Me.GradientPanel1.Controls.Add(Me.DateCaisseDateTimePicker)
        Me.GradientPanel1.Controls.Add(LibelleLabel)
        Me.GradientPanel1.Controls.Add(Me.LibelleTextBox)
        Me.GradientPanel1.Controls.Add(MontantLabel)
        Me.GradientPanel1.Controls.Add(Me.MontantTextBox)
        Me.GradientPanel1.Controls.Add(TypeLabel)
        Me.GradientPanel1.Controls.Add(Me.TypeComboBox)
        Me.GradientPanel1.Controls.Add(Me.BtCancel)
        Me.GradientPanel1.Controls.Add(Me.BtOK)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(337, 118)
        Me.GradientPanel1.TabIndex = 0
        '
        'DateCaisseDateTimePicker1
        '
        Me.DateCaisseDateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.JournalCaisseBindingSource, "DateCaisse", True))
        Me.DateCaisseDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateCaisseDateTimePicker1.Location = New System.Drawing.Point(147, 8)
        Me.DateCaisseDateTimePicker1.Name = "DateCaisseDateTimePicker1"
        Me.DateCaisseDateTimePicker1.ShowUpDown = True
        Me.DateCaisseDateTimePicker1.Size = New System.Drawing.Size(72, 20)
        Me.DateCaisseDateTimePicker1.TabIndex = 2
        '
        'JournalCaisseBindingSource
        '
        Me.JournalCaisseBindingSource.DataMember = "JournalCaisse"
        Me.JournalCaisseBindingSource.DataSource = Me.DsAgrifact
        '
        'DateCaisseDateTimePicker
        '
        Me.DateCaisseDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.JournalCaisseBindingSource, "DateCaisse", True))
        Me.DateCaisseDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCaisseDateTimePicker.Location = New System.Drawing.Point(54, 8)
        Me.DateCaisseDateTimePicker.Name = "DateCaisseDateTimePicker"
        Me.DateCaisseDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.DateCaisseDateTimePicker.TabIndex = 1
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JournalCaisseBindingSource, "Libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(54, 61)
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(274, 20)
        Me.LibelleTextBox.TabIndex = 8
        '
        'MontantTextBox
        '
        Me.MontantTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JournalCaisseBindingSource, "Montant", True))
        Me.MontantTextBox.Location = New System.Drawing.Point(253, 34)
        Me.MontantTextBox.Name = "MontantTextBox"
        Me.MontantTextBox.Size = New System.Drawing.Size(75, 20)
        Me.MontantTextBox.TabIndex = 6
        Me.MontantTextBox.Text = "99 999,99 €"
        Me.MontantTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.JournalCaisseBindingSource, "Type", True))
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Location = New System.Drawing.Point(54, 34)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(165, 21)
        Me.TypeComboBox.TabIndex = 4
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(254, 87)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 10
        Me.BtCancel.Text = "Annuler"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(173, 87)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 9
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'JournalCaisseTA
        '
        Me.JournalCaisseTA.ClearBeforeFill = True
        '
        'FrOpeCaisse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(337, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrOpeCaisse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opération de caisse"
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.JournalCaisseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents JournalCaisseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalCaisseTA As PointDeVente.DsAgrifactTableAdapters.JournalCaisseTA
    Friend WithEvents DateCaisseDateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateCaisseDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MontantTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
End Class